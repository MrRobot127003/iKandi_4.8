<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryInternalChallan.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryInternalChallan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input
        {
            border-radius: 2px;
            border: 1px solid #999;
            padding-left: 3px !important;
        }
        body
        {
            font-family: Arial !important;
        }
        .debitnote-table
        {
            font-family: Arial !important;
        }
        .debitnote-table .top_heading
        {
            text-transform: capitalize;
            font-size: 15px;
            font-weight: 500;
            padding-top: 2px;
            text-align: center;
            padding-bottom: 3px;
            background: #39589c;
            color: #fff;
        }
        .debitnote-table .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .debitnote-table .Srnon
        {
            font-weight: 600;
            font-size: 18px;
        }
        tbody td
        {
            padding: 3px 3px;
            font-size: 11px; /* text-transform: uppercase; */
        }
        tbody td.borderbottom
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
            width: 150px;
            border-collapse: collapse;
        }
        .formcontrol
        {
            width: 98%;
        }
        .formcontrol2
        {
            width: 99%;
        }
        .headerbold
        {
            font-weight: 600;
        }
        ul
        {
            margin: 0;
            padding: 0px 0px;
            max-width: 100%;
            list-style-type: none;
        }
        li
        {
            float: left;
            line-height: 16px;
            padding: 0px;
        }
        .tablewidth
        {
            padding: 0px 3px 5px;
            border-bottom: 1px solid #9999;
        }
        .tableto
        {
            width: 80px;
        }
        .bottomborder
        {
            border-bottom: 1px solid #9999;
            padding: 10px 5px;
        }
        .listwidth
        {
            width: 80px;
        }
        tbody td.bordertable
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
            border-collapse: collapse;
            text-align: center;
        }
        .metercol
        {
            width: 50px;
        }
        .cmcoloum
        {
            width: 40px;
        }
        .checkboxtop
        {
            position: relative;
            top: 2px;
        }
        input
        {
            padding: 0px 3px;
        }
        .textaria
        {
            width: 82%;
        }
        .inputfield
        {
            width: 95%;
        }
        .bottomborder1
        {
            border-bottom: 1px solid #9999;
            text-align: center;
        }
        .rightborder
        {
            border-right: 1px solid #9999;
        }
        .btnbutton
        {
            background: #1976D2;
            color: #fff;
            border: 1px solid #1976d2;
            padding: 4px;
            border-radius: 3px;
        }
        .headerbacground
        {
            background: #e4e2e2;
            font-size: 11px;
            height: 20px;
            font-weight: 500;
            color: #6b6464;
        }
        
        .p-r-5
        {
            padding-right: 5px;
        }
        .textcenter
        {
            text-align: center;
            font-size: 11px;
        }
        
        
        select
        {
            font-size: 11px;
        }
        input
        {
            font-size: 11px;
        }
        .borderleft
        {
            border-left: 1px solid #9999;
        }
        .borderleft0bottom
        {
            border-bottom: 0px solid #9999;
            color: gray;
        }
        .metersr tbody td
        {
            height: 13px;
        }
        .meterQury thead th
        {
            border: 1px solid #999;
            text-align: center;
            font-weight: 500;
        }
        /* .meterQury tbody td
        {
            border:1px solid #9999;
            text-align:center;
        }*/
        .tabletdhei
        {
            height: 16px !important;
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
        
        
        .FrstHeader
        {
            width: 23% !important;
        }
        .LasttHeader
        {
            width: 21% !important;
        }
        .txtEditWidth
        {
            text-align: center;
        }
        td #chkProcess td
        {
            padding: 0px 6px 0px 0px !important;
            color: #000;
        }
        
        input[type='text']
        {
            padding-left: 3px;
        }
        .spanHdrColor
        {
            color: Gray;
        }
        #chkProcess input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        
        
        
        
        .fabric_challan_rategstamout tr td
        {
            padding-right: 40px;
        }
        .fabric_challan_rategstamout tr td span
        {
            font-weight: 600;
            color: gray;
        }
        .fabric_challan_rategstamout tr td .textcolor
        {
            font-weight: 600;
            color: black;
        }
        .textcolor::before
        {
            content: "\20B9";
            margin-right: 5px;
        }
        .textcolor1::after
        {
            content: "%";
            margin-right: 5px;
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
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
    <script type="text/javascript">

        //new code start
        function DontAllowDecimal(val, event) {

            //paste event 
            if (event.type === "paste") {
                setTimeout(function () {
                    $(that).val($(that).val().replace(/[^\d].+/, ""));
                }, 100);
            } else {

                if (event.which < 48 || event.which > 57) {
                    event.preventDefault();
                } else {
                    $(this).val($(this).val().replace(/[^\d].+/, ""));
                }
            }
        }

        function DisplaySendMail() {
 
            if ($("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                $("#dvSendMail").css("display", "")
                return false;
            }
            else {
                $("#dvSendMail").css("display", "none")
                return false;
            }

        }
        //new code end

        $(function () {
            $("#ctl00cph_main_contentSubmit").click(function () {
       
                if (parseFloat(("#txtStockqty").val()) + parseFloat(("#ctl00_cph_main_content_txtDebitqty")) == parseFloat(("#ctl00_cph_main_content_lblleftmoveqty").val())) {
                    return true;
                }
                else {
                    return false;
                }
            });
            var POMinDate = new Date().addDays(-30);
            var POMaxDate = new Date().addDays(30);
            $(".PODate").datepicker({ dateFormat: "dd M y (D)", minDate: POMinDate, maxDate: POMaxDate }).val();


        });

        function ChangeChallanQty(obj) {
      
            var ChallanQty = $(obj).val();
            ChallanQty = ChallanQty.replace(",", "");

            if (ChallanQty == '') {
                ChallanQty = 0;
            }
            var rate = $("#<%=lblrate.ClientID %>").text();
            var cgst = $("#<%=lblcgst.ClientID %>").text();
            var sgst = $("#<%=lblsgst.ClientID %>").text();
            var igst = $("#<%=lbligst.ClientID %>").text();
            var gst = parseFloat(cgst) + parseFloat(sgst);
            if (cgst != "" && sgst != "") {
                var totalAmount = ((parseFloat($(obj).val()) * parseFloat(rate)) * (100 + gst)) / 100;
            }
            else {
                if (igst != "") {

                    var totalAmount = ((parseFloat($(obj).val()) * parseFloat(rate)) * (100 + parseFloat(igst))) / 100;
                }
                else
                    TotalAmount = ((parseFloat($(obj).val()) * parseFloat(rate)));

            }

            $("#<%=lblTotalAmount.ClientID %>").text(totalAmount.toFixed(2));




            var hdnRemainingQty = $("#" + hdnRemainingQtyClientId).val();
            var hdnTotalPcs = $("#" + hdnTotalPcsClientId).val();

            var RemainingQty = parseFloat(hdnRemainingQty) + (parseFloat(hdnTotalPcs) - parseFloat(ChallanQty));

            if (ChallanQty == 0) {
                alert('Please fill Challan Qty');
                $(obj).val('');
                if (RemainingQty >= 0) {
                    if (RemainingQty == 0) {
                        $("#" + lblAvailableQty).text('');
                        $('#lblAvailableQtyUnit').text('');
                    }
                    else {
                        $("#" + lblAvailableQty).text(numberWithCommas(RemainingQty.toFixed(2)));
                    }
                }
                return false;
            }

            if (RemainingQty >= 0) {
                if (RemainingQty == 0) {
                    $("#" + lblAvailableQty).text('');
                    $('#lblAvailableQtyUnit').text('');
                }
                else {
                    $("#" + lblAvailableQty).text(numberWithCommas(RemainingQty.toFixed(2)));
                }
            }
            else {
                alert('This Qty can not be greater than Total Qty');
                $(obj).val(hdnTotalPcs);
                $(obj).val('');
                //ChangeChallanQty(obj);
                return false;
            }
        }

        function closePage() {
            self.parent.parent.PageReload();
            self.parent.Shadowbox.close()
        }

        function disablePage() {
            for (var i = 0; i < document.forms[0].elements.length; i++) {
                //document.forms[0].elements[i].disabled = true;
                $('input[type=text]').attr('readonly', 'readonly');
                $('textarea').attr('disabled', 'disabled');
                $('input[type=checkbox]').attr('disabled', 'disabled');
            }
        }

        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        //Validate if NumberKey/Decimal Key Start :Created by Girish

        function isNumberWithDecimal(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;

            if (dotcontains)
                if (charCode == 46) return false;

            if (charCode == 46) return true;

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            var str = value.toString();
            var parts = str.split('.');

            if (parts.length > 1) {
                if (parts[1].length > 1)
                    return false;
                else
                    return true;
            }
            return true;
        }

        function isNumberKey(txt, evt) {
            var id = txt.id;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            if (id.includes("txtNoOfItems")) {
                if (charCode == 48) { //check for first zero

                    if ($('#' + id).val() == "")
                        return false;
                    else
                        return true;
                }
                else if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
                else {
                    var id2 = id.split("txtNoOfItems");
                    if (parseFloat($('#' + id2[0].concat("hdnAvailableQty")).val()) > 0) {

                        $("[id$='txtNoOfItems']").each(function () {

                            var elementid = (this).id.split("txtNoOfItems");
                            if (txt.id == (this).id) return;
                            var elementValue = $('#' + elementid[0].concat("txtQtyToIssue")).val();
                            if (elementValue === "")
                                $(this).val('');
                        });
                        $("[id$='txtNoOfItems']").css("border", "1px solid #CCCCCC");
                        return true;
                    }
                    else return false;
                }
            }
            else if (id.includes("txtQtyToIssue")) {

                if ($('#' + id).val().length > parseInt(12))
                    return false;

                var id2 = id.split("txtQtyToIssue");
                if ($('#' + id2[0].concat("hdnAvailableQty")).val() == "")
                    return false;

                else if ($('#' + id2[0].concat("txtNoOfItems")).val() == "" && parseFloat($('#' + id2[0].concat("hdnAvailableQty")).val()) > 0) {

                    $("[id$='txtNoOfItems']").css("border", "1px solid #CCCCCC");
                    $('#' + id2[0].concat("txtNoOfItems")).css("border", "1px solid red");
                    return false;
                }
                else if (charCode == 46) {
                    //Check if the text already contains the . character
                    if (txt.value.indexOf('.') === -1)
                        return true;
                    else return false;
                }
                else if (charCode == 48) {
                    //check for first zero
                    if ($('#' + id).val() == "")
                        return false;
                    else
                        return true;
                }
                else {
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) //check for non-numeric character is pressed
                        return false;
                }
                var str = $('#' + id).val().toString();
                var parts = str.split('.');

                if (parts.length > 1) {
                    if (parts[1].length > 1)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            return true;
        }
        //Validate if NumberKey/Decimal Key End :Created by Girish

        //Calucalate Total Stat:Created by Girish
        function calculateTotal(CurrentId) {
             
            if (CurrentId.includes("txtNoOfItems")) {
                if ($('#' + CurrentId).val() == "" || $('#' + CurrentId).val() == "0") {
                    var unitIdpart = CurrentId.split("txtNoOfItems")                   
                    $('#' + unitIdpart[0].concat("txtQtyToIssue")).val('');
                    $('#' + unitIdpart[0].concat("txtNoOfItems")).val('');
                    calculateTotal("txtQtyToIssue");
                }
                var sum = 0;
                $("[id$='txtNoOfItems']").each(function () {
                    sum = parseInt(sum) + parseInt($(this).val() == '' ? 0 : $(this).val());
                });
                if (sum != "" && sum != "0" && isNaN(sum) != true)
                    $('#Total_No_Of_Items').html(" " + sum.toString());
                else
                    $('#Total_No_Of_Items ').html('');
            }

            else if (CurrentId.includes("txtQtyToIssue")) {
          
                var sums = {};
                var Total = {};
                $("[id$='txtQtyToIssue']").each(function () {
           
                    var unitIdpart = (this).id.split("txtQtyToIssue");
                    var unit = $('#' + unitIdpart[0].concat("shortunit")).html();
                    var qty = $(this).val();
                    if (qty != '') {
                        if (!sums[unit])
                            sums[unit] = 0; //initializes the value
                        Total[unit]=0
                        sums[unit] = (parseFloat(sums[unit]) + parseFloat(qty)); //.toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 }).replace(/\.00$/, '');
                        Total[unit] = parseFloat(sums[unit]).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 }).replace(/\.00$/, ''); ;
                    }

                });
                var sumsArray = [];
                for (var unit in sums) {
                    sumsArray.push(Total[unit].toString() + " " + unit);
                }
                var sumsString = sumsArray.join(", ");
                $('#Total_Issued_Qty').html(" " + sumsString); 

//                var sumsArray = [];
//                for (var unit in sums) {
//                    sumsArray.push(sums[unit].toString() + " " + unit);
//                }
//                var sumsString = sumsArray.join(", ");
//                $('#Total_Issued_Qty').html(" " + sumsString); 
            }
        }
        //Calucalate Total End:Created by Girish

        // Validate IssueQty: Start Created by Girish
        function ValidateIssueQty(txt, evt) {
            var IssueQtyId = txt.id;
            var dynamicIdPart = IssueQtyId.split("txtQtyToIssue");

            var AvailableQtyId = dynamicIdPart[0].concat("hdnAvailableQty");
            var OriginalIssuedQtyId = dynamicIdPart[0].concat("hdnIssuedQty");
            var NoOfItemsId = dynamicIdPart[0].concat("txtNoOfItems");

            if (parseFloat($('#' + IssueQtyId).val() == "" ? 0 : $('#' + IssueQtyId).val()) > parseFloat($('#' + AvailableQtyId).val() == "" ? 0 : $('#' + AvailableQtyId).val())) {
                alert("Issue Qty Cannot be greater than Available Qty.");
                $('#' + IssueQtyId).val($('#' + OriginalIssuedQtyId).val());
                calculateTotal(txt.id);
                return false;
            }
            calculateTotal(txt.id);
            return true;
        }
        // Validate IssueQty End: Created by Girish

        // Validate ReturnQty Start: Created by Girish
        function ValidateReturnQty(txt, evt) {
            var ReturnedQtyId = txt.id;
            var dynamicIdPart = ReturnedQtyId.split("txtReturnedQty");

            var OriginalReturnedQtyId = dynamicIdPart[0].concat("hdnReturnedQty");
            var IssuedQtyId = dynamicIdPart[0].concat("txtQtyToIssue");
            var MinimumQtyThatCanBeReturnedId = dynamicIdPart[0].concat("hdnMinimumQtyThatCanBeReturned");
            var MaximumQtyThatCanBeReturnedId = dynamicIdPart[0].concat("hdnMaximumQtyThatCanBeReturned");

            var ReturnedQty = parseFloat($('#' + ReturnedQtyId).val() == "" ? 0 : $('#' + ReturnedQtyId).val());
            var OriginalReturnedQty = parseFloat($('#' + OriginalReturnedQtyId).val() == "" ? 0 : $('#' + OriginalReturnedQtyId).val());
            var MinimumQtyThatCanBeReturned = parseFloat($('#' + MinimumQtyThatCanBeReturnedId).val() == "" ? 0 : $('#' + MinimumQtyThatCanBeReturnedId).val());
            var MaximumQtyThatCanBeReturned = parseFloat($('#' + MaximumQtyThatCanBeReturnedId).val() == "" ? 0 : $('#' + MaximumQtyThatCanBeReturnedId).val());

            if (ReturnedQty > MaximumQtyThatCanBeReturned) {
                alert("You Cannot Return more than " + MaximumQtyThatCanBeReturned + "");
                $('#' + ReturnedQtyId).val(OriginalReturnedQty == 0 ? "" : OriginalReturnedQty);
                return false;
            }
            else if (ReturnedQty < OriginalReturnedQty) {

                if (ReturnedQty < MinimumQtyThatCanBeReturned) {
                    alert("You Cannot Return Less than " + MinimumQtyThatCanBeReturned + "");
                    $('#' + ReturnedQtyId).val(OriginalReturnedQty == 0 ? "" : OriginalReturnedQty);
                    return false;
                }
            }
        }
        // Validate ReturnQty End: Created by Girish

        //On Change Of Production Unit in Internal Challan (Girish) : Start

        function ddlProductionUnitChanged() {
            var SelectedUnit = $("#ddlProductionUnit option:selected").val();
            var commaSeparatedUnits = $("#hdnInternalUnitIds").val();

            var unitIds = commaSeparatedUnits.split(',');
            if (unitIds.includes(SelectedUnit)) {
                $('#divToShowGSTNoForInternalChallan').css('display', 'none');
                $('#txtGSTNoForInternalChallan').val('');
            }
            else {
                $('#divToShowGSTNoForInternalChallan').css('display', 'block');

                if (SelectedUnit == $('#hdnSelectedSupplier').val()) {
                    $('#txtGSTNoForInternalChallan').val($('#hdnGSTNoForInternalChallan').val());
                }
                else {
                    $('#txtGSTNoForInternalChallan').val('');
                }
            }
        }
        //On Change Of Production Unit in Internal Challan (Girish) : End


        //        function displayNone(obj) {
        //          
        //            var id = obj.id;
        //            $('#' + id).css("display", "none");

        //            $('#Closesbox').css("display", "none");
        //            $('#print').css("display", "none");

        //            $('#dvSendMail').css("display", "none");

        //            return true;
        //        }

        function HSNValidate() {
            if ($('#lblHSNCode').val() == "") {
                alert("Please Enter HSNCode Of Items.");
                return false;
            }
            else {
                $('#btnSubmit').css("display", "none");
                $('#Closesbox').css("display", "none");
                $('#print').css("display", "none");
                $('#dvSendMail').css("display", "none");
            }
        }

        function allowAlphaNumericSpace(e) {
            var code = ('charCode' in e) ? e.charCode : e.keyCode;
            if (!(code > 47 && code < 58) && // numeric (0-9)
    !(code > 64 && code < 91) && // upper alpha (A-Z)
    !(code > 96 && code < 123)) { // lower alpha (a-z)
                e.preventDefault();
            }
        }

    </script>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnChallan_Number" Value="0" runat="server" />
    <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
    <asp:HiddenField ID="hdnAccessoryQuality" Value="" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 8%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="debitnote-table" style="max-width: 99.8%; margin: 0px auto; border: 0px solid #999;">
                <table cellpadding="0" cellspacing="0" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-bottom: 0px;">
                    <thead>
                        <tr>
                            <td style="border-bottom: 1px solid #999999;">
                            </td>
                            <td class="top_heading texttranceform bottomborder1" colspan="">
                                Accessory challan
                            </td>
                        </tr>
                    </thead>
                </table>
                <table style="width:100%;">
                    <tbody>
                        <tr>
                            <td style="vertical-align: top; width: 125px; border-bottom: 1px solid #9999" colspan='2'>
                                <div style="padding: 2px 7px 5px; width: 125px; float: left">
                                    <img src="../../images/boutique-logo.png" />
                                </div>
                                <div id="divbipladdress" runat="server" style="padding-top: 5px;">
                                </div>
                            </td>
                        </tr>
                    <tbody>
                </table>
                <table class="" style="max-width: 100%; width: 100%; border: none; border-top: 0px; border-bottom: 0px; float: left; line-height: 12px;" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td style="width: 77px;">
                                <div class="spanHdrColor">
                                    Challan No:</div>
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 13px">
                                <asp:Label ID="lblChallan" Font-Bold="true" ForeColor="Black" runat="server" Text=""
                                    Style="margin-left: 5px;"></asp:Label>
                                <asp:HiddenField ID="hdnSupplyType" Value="0" runat="server" />
                            </td>
                            <asp:HiddenField ID="hdnChallan" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                        </tr>
                        <tr id="trPO" runat="server">
                            <td class=" texttranceform borderleft0bottom">
                                <div class="spanHdrColor">
                                    PO No:</div>
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 13px;">
                                <asp:Label ID="lblPoNo" runat="server" Text="" Style="margin-left: 5px;"></asp:Label>
                            </td>
                        </tr>
                        <%--rajeev --%>
                        <tr id="tr1" runat="server">
                            <td class=" texttranceform borderleft0bottom">
                                <span runat="server" id="spn_HSNCode"></span>
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 13px;">
                                <asp:TextBox ID="lblHSNCode" runat="server" onkeypress="allowAlphaNumericSpace(e)"></asp:TextBox>
                                <%--<asp:Label ID="lblHSNCode" runat="server" ></asp:Label>--%>
                            </td>
                        </tr>
                        <%--rajeevs ---%>
                        <tr>
                            <td>
                                <div class="spanHdrColor">
                                    Date:
                                </div>
                            </td>
                            <td class=" texttranceform borderleft0bottom">
                                <asp:Label ID="txtChallanDate" runat="server" Width="88px" Style="margin-left: 5px;
                                    text-transform: capitalize; border: 0px;"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td class="borderleft0bottom" style="width: 80px;">
                                Select:
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 44px; padding: 3px 0px">
                                <asp:CheckBoxList ID="chkProcess" RepeatDirection="Horizontal" RepeatColumns="7"
                                    runat="server" Style="margin-left: 2px;">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                        <td class="borderleft0bottom spanHdrColor"><span style="">To:</span></td>
                            <td class="borderleft0bottom spanHdrColor" runat="server" id="tdCompanyType">                                
                                <asp:DropDownList ID="ddlType" runat="server" Visible="false">
                                    <asp:ListItem Value="1" Text="External"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Internal"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnType" Value="0" runat="server" />



                                 <span style="font-weight: bold; margin-left: 5px;">M/S:</span><span style="color: Red;
                                    font-size: 12px;">*</span> &nbsp;
                                <div id="dvUnit" runat="server" style="display: inline-block">
                                    <asp:DropDownList ID="ddlProductionUnit" runat="server" Style="margin-left: 8px;"
                                        onchange="ddlProductionUnitChanged()">
                                    </asp:DropDownList>
                                    <asp:HiddenField runat="server" ID="hdnSelectedSupplier" Value='' />
                                </div>
                                <div id="dvSupplier" class="spanHdrColor" runat="server" style="display: inline-block">
                                    <asp:Label ID="lblSupplierName" ForeColor="Black" runat="server"></asp:Label>
                                </div>
                                <%--added by Girish For Internal Challan Only--%>
                                <asp:HiddenField runat="server" ID="hdnInternalUnitIds" Value="" />
                                <div runat="server" id="divToShowGSTNoForInternalChallan" style="display: none;">
                                    <asp:Label runat="server" Style="font-weight: bold; margin-left: 3px;" ID="lblGSTNoForInternalChallan"
                                        Text="GST No."></asp:Label>
                                    <asp:TextBox runat="server" Style="border: 1px solid #4F4F4F; margin-top: 10px; margin-bottom: 10px;
                                        height: 13px;" ID="txtGSTNoForInternalChallan"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="hdnGSTNoForInternalChallan" Value='' />
                                </div>
                            </td>
                        </tr>
                        <tr id="gstt" runat="server">
                            <td>
                                <span class="spanHdrColor">GST No.:</span> &nbsp;
                            </td>
                            <td style="padding-left: 8px;">
                                <asp:Label ID="lblSupplierGstNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="aaddress" runat="server">
                            <td>
                                <span class="spanHdrColor">Address:</span> &nbsp;
                            </td>
                            <td style="padding-left: 8px;">
                                <asp:Label ID="lblSupplierAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_StyleNo">
                            <td class="borderleft0bottom spanHdrColor" style="width: 20%">
                                Style No:
                            </td>
                            <td>
                                <div id="dvStyle" runat="server" style="width: 20%">
                                    <asp:Label ID="lblStyleNo" ForeColor="Black" runat="server" Style="margin-left: 5px;"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_SerialNo">
                            <td class="borderleft0bottom spanHdrColor">
                                Serial No:
                            </td>
                            <td>
                                <asp:Label ID="lblSerialNo" Style="color: #330099; font-weight: bold; margin-left: 5px;"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
                            <td class='borderleft0bottom'>
                                Accessory (Size)
                            </td>
                            <td class="borderleft0bottom spanHdrColor" style="text-align: left">
                                <span>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="Blue" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnSize" runat="server" />
                                </span>
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
                            <td class="borderleft0bottom spanHdrColor">
                                Color Print:
                            </td>
                            <td>
                                <asp:Label ID="lblcolorprint" Height="15px" Font-Bold="true" ForeColor="Black" Text=""
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="old_description" visible="false">
                            <td class="spanHdrColor">
                                Description:
                            </td>
                            <td class="spanHdrColor">
                                <span style="margin-left: 5px;">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="98%" runat="server"
                                        Style="margin-top: 1px; text-transform: lowercase;"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 1px solid #999999; border-top: 1px solid #999999" cellspacing="0" cellpadding="0"
                    id="old_table" runat="server" visible="false">
                    <tbody>
                        <tr>
                            <td class="rightborder spanHdrColor">
                                No. of Items
                            </td>
                            <td class="rightborder spanHdrColor" style="">
                                <asp:TextBox ID="txtTotalUnit" ForeColor="Gray" Font-Bold="true" MaxLength="4" onkeypress="return DontAllowDecimal(this,event);"
                                    Width="80px" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnRowCount" Value="0" runat="server" />
                                <span style="color: gray">Rolls/Boxes</span>
                            </td>
                            <td class="rightborder spanHdrColor">
                                Total Qty.
                                <asp:TextBox ID="txtChallanQty" onchange="ChangeChallanQty(this)" MaxLength="9" Width="80px"
                                    runat="server"></asp:TextBox>
                                <asp:Label ID="lblUnitName" Style="text-transform: capitalize; color: gray; font-weight: bold;"
                                    runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalPcs" Value="0" runat="server" />
                            </td>
                            <td class="rightborder spanHdrColor" style="" id="tdAvailableQty" runat="server">
                                Available Qty.
                                <asp:Label ID="lblAvailableQty" min-Width="50" runat="server"></asp:Label>
                                <asp:Label ID="lblAvailableQtyUnit" Style="text-transform: capitalize; color: gray;
                                    font-weight: bold; margin-left: 3px" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnRemainingQty" Value="0" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <%--New Table Created by Girish--%>
                <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                    Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    OnDataBound="GridView1_DataBoundEvent">
                    <Columns>
                        <asp:TemplateField HeaderText="AccessoryName">
                            <ItemStyle Width="250px" />
                            <ItemTemplate>
                                <%# Eval("AccessoryName") %>
                                <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemStyle Width="80px" />
                            <ItemTemplate>
                                <%# Eval("size")%>
                                <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("size") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ColorPrint">
                            <ItemStyle Width="80px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("Color_Print")%>
                                <asp:HiddenField ID="hdnColorPrint" runat="server" Value='<%# Eval("Color_Print") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contract No.">
                            <ItemStyle Width="80px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("ContractNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Qty.">
                            <ItemStyle Width="60px" Font-Bold="true" />
                            <ItemTemplate>
                                <%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>
                                <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value=' <%#  Eval("OrderDetailID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Available Qty.">
                            <ItemStyle Width="100px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("AvailableQty").ToString() == "0.00" ? "" : Convert.ToDecimal(Eval("AvailableQty")).ToString("#,##.##") + " <span style='color:#808080;'>" + Eval("ShortUnitName").ToString() + "</span>" %>
                                <asp:HiddenField ID="hdnAvailableQty" runat="server" Value=' <%# Eval("AvailableQty").ToString() == "0.00" ? "" : Eval("AvailableQty") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No. Of Items">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtNoOfItems" Style="width: 80%" onkeyPress="return isNumberKey(this,event)"
                                    onChange="calculateTotal(this.id)" Text='<%# Eval("NoOfItems").ToString() == "0" ? "" : Eval("NoOfItems")  %>'
                                    ReadOnly='<%# Eval("ReadOnly") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Issued Qty.">
                            <ItemStyle Width="124px" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtQtyToIssue" Style="width: 65%;" onkeyPress="return isNumberKey(this,event)"
                                    onChange="return ValidateIssueQty(this,event)" Text='<%# Eval("QtyToIssue").ToString() == "0" ? "" : Convert.ToDecimal(Eval("QtyToIssue")).ToString(".##") %>'
                                    ReadOnly='<%# Eval("ReadOnly") %>' MaxLength="12" onpaste="return false;"></asp:TextBox>
                                <span style='color: #808080' id="shortunit" runat="server">
                                    <%# Eval("AvailableQty").ToString() == "" ? "" : Eval("ShortUnitName").ToString()%></span>
                                <asp:HiddenField runat="server" ID="hdnIssuedQty" Value='<%# Eval("QtyToIssue").ToString() == "0" ? "" : Convert.ToDecimal(Eval("QtyToIssue")).ToString(".##") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Returned Qty." Visible="false">
                            <ItemStyle Width="124px" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtReturnedQty" Style="width: 65%;" onkeyPress="return isNumberWithDecimal(event,this)"
                                    Text='<%# Eval("ReturnedQty").ToString() == "0" ? "" : Convert.ToDecimal(Eval("ReturnedQty")).ToString(".##") %>'
                                    MaxLength="12" OnTextChanged="ReturnedQty_TextChanged" onChange="return ValidateReturnQty(this,event)"
                                    AutoPostBack="false" ReadOnly='<%# Eval("isReadOnly") %>'></asp:TextBox>
                                <%--AutoPostBack is set to false as validating Returned Qty through javascript so there's no need to PostBack--%>
                                <span style='color: #808080' id="returnedQtyshortunit" runat="server">
                                    <%# Eval("ShortUnitName").ToString()%></span>
                                <asp:HiddenField runat="server" ID="hdnReturnedQty" Value='<%# Eval("ReturnedQty") %>' />
                                <asp:HiddenField runat="server" ID="hdnMinimumQtyThatCanBeReturned" Value='<%# Eval("MinimumQtyThatCanBeReturned") %>' />
                                <asp:HiddenField runat="server" ID="hdnMaximumQtyThatCanBeReturned" Value='<%# Eval("MaximumQtyThatCanBeReturned") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemStyle Width="200" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Style="width: 98%;
                                    border: none;" Text='<%# Eval("Description") %>' ReadOnly='<%# Eval("ReadOnly") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#DDDFE4" Font-Bold="True" ForeColor="#808080" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                </asp:GridView>
                <%--New Table Created by Girish--%>
                <br />
                <div style="float: left; width: 50%; display: inline-block;" runat="server" id="div_TotalNoOfItems"
                    visible="false">
                    <span style="font-weight: bold; margin-left: 53%;">Total No. Of Items :</span><span
                        id="Total_No_Of_Items"></span></div>
                <div>
                    <span style="font-weight: bold; margin-left: 5%;" runat="server" id="div_TotalIssuedQty"
                        visible="false">Total Issued Qty :</span><span id="Total_Issued_Qty"></span></div>
                <%--New Table End Girish--%>
                <table class="fabric_challan_rategstamout" id="fabric_challan_rategst" runat="server">
                    <tr>
                        <td>
                            <span>Rate:&nbsp;</span>
                            <asp:Label ID="lblrate" runat="server" class="textcolor"></asp:Label>
                        </td>
                        <td runat="server" id="licgst">
                            <span>CGST:&nbsp;</span>
                            <asp:Label ID="lblcgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="lisgst">
                            <span>SGST:&nbsp;</span>
                            <asp:Label ID="lblsgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="igst">
                            <span>IGST:&nbsp;</span>
                            <asp:Label ID="lbligst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td id="Totalamount" runat="server">
                            <span>Total Amount</span>
                            <asp:Label ID="lblTotalAmount" runat="server" class="textcolor"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="MarginTop8" style="max-width: 100%; margin-bottom: 10px; font-size: 12px;
                    width: 100%; margin-top: 5px; border: none; border-top: 0px solid #999;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" style="padding: 5px 0px 5px 10px; width: 60%;" class="headerbold">
                                Received the goods in good condition
                            </td>
                            <td style="padding: 5px 10px 5px; text-align: right" colspan="">
                                <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 12px;
                                font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkReceive">
                                    <asp:CheckBox ID="chkrecivegood" runat="server" Text="(Receiver's Signature)" onclick="DisplaySendMail()" />
                                    <asp:HiddenField ID="hdnReceiverIsChecked" Value="0" runat="server" />
                                </div>
                                <div runat="server" id="divSigReceive" visible="false">
                                    <asp:Image ID="imgReceiver" runat="server" Height="40px" Width="130px" />
                                    <br />
                                    <asp:Label ID="lblReceiverName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblReceivedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                                padding-right: 15px; font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkAuthorized">
                                    <asp:CheckBox ID="chkAuthorised" runat="server" Text="(Authorized Signature)" onclick="DisplaySendMail()" />
                                    <asp:HiddenField ID="hdnAuthoriseIsChecked" Value="0" runat="server" />
                                </div>
                                <div runat="server" id="divSigAuthorized" visible="false">
                                    <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                    <br />
                                    <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 0px solid #999999; border-top: 0px solid #999999" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="5" style="text-align: center; padding-top: 5px;">
                            <div class="form_buttom" style="float: left;">
                                <%-- UseSubmitBehavior="False"--%>
                                <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" ClientIDMode="Static"
                                    runat="server" Text="Save" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                Close</div>
                            <div class="btnPrint printHideButton" onclick="window.print();return false" id="print">
                                Print</div>
                            <div id="dvSendMail" style="width: 400px; font-weight: bold; top: 5px; display: none"
                                runat="server" class="printHideButton">
                                &nbsp; &nbsp; Is E-Mail Send:
                                <asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail" runat="server" CssClass="printHideButton" />
                                <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server"
                                    CssClass="printHideButton" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
