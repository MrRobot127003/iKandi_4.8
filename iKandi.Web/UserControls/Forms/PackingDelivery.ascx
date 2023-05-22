<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PackingDelivery.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.psckingDelivery" %>
<%--<script src="../../CommonJquery/JqueryLibrary/form.js" type="text/javascript"></script>--%>
<style type="text/css">

<style type="text/css">
    body
    {
        background:#f2f2f2;
    }
    .ddd
    {
        color:Red;
        }
    .searchserial
    {
       
        padding-left: 5px;
      
      
    }
    .item_list td {
    color: gray;
    font-size: 10px;
    }
    .required
    {
        color: White;
    } 
    .repeatChange div
    {
        border-bottom:1px solid #cac3c3;
    }
    .repeatChange div:last-child
    {
         border-bottom:0px;
    }
    .fieldsetPacking1
    {
        float:left;
        width:430px;
    }
    .widthTable1
    {
        float:left;
        
        margin-right:1%;
    }
    .divSearch1
    {
        float:left;
        width:25%;
        margin-top:15px !important;
    }
   #psckingDelivery1_pnlDisable
   {
       position:relative;
    }
</style>
<script type="text/javascript" src="../../js/facebox.js"></script>
<script src="../../CommonJquery/Js/form.js" type="text/javascript"></script>
<script src="../../js/form.js" type="text/javascript"></script>
<script type="text/javascript">


    var Flag = '<%=this.Flag %>';
    var PaymentDueDate = ("<%=txtPaymentDueDate.ClientID %>");
    var Landingeta = ("<%=txtlandingETA.ClientID %>");
    var txtInvoiceNo = ("<%=txtInvoiceNo.ClientID %>");
    var UpInvoice = ("<%=UpInvoice.ClientID %>");
    var HdninvoiceFile = ("<%=hdnnovicelistfile.ClientID %>");
    var txtInvoiceAmt = ("<%=txtInvoiceAmt.ClientID %>");

    var UpPackingFile = ("<%=UpPackingFile.ClientID %>");
    var hdnpackinglistfile = ("<%=hdnpackinglistfile.ClientID %>");
    var invoiceDate = ("<%=txtinvoiceDate.ClientID %>");
    function ShowConfirm(elem) {
        debugger;
        var ControlID = elem.id;
        var Ids = ControlID;
        var RowID = Ids.split("_")[2].substr(3, 4);
        //alert(RowID);
        var selectoption = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_ddlBankRefNo");
        var NewBankRefNo = selectoption.options[selectoption.selectedIndex].text;
        var oldBankRefNo = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnbnkrefno").value;
        var InvoiceID = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnInvoiceID").value;
        //alert(selectoption.options[selectoption.selectedIndex].innerHTML);
        var hdnShipmentNo__PkID = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnShipmentNo__PkID").value;

        if (confirm("Are you sure want to change bank reference number ?") == true) {
            var url = "../../Webservices/iKandiService.asmx";
            jQuery.ajax({
                type: "POST",
                url: url + "/UpdateBankRefNo",
                data: "{ ShipemntPkID:'" + hdnShipmentNo__PkID + "', OldBankRefNo:'" + oldBankRefNo + "', NewBankRefNo:'" + NewBankRefNo + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {

                //                        alert("PaymentClearDate_" + response.d[0]["PaymentClearDate"].toString());
                //                        alert("Tenure_" + response.d[0]["Tenure"].toString());
                //                        alert("PaymentDueDate_" + response.d[0]["PaymentDueDate"].toString());
                //                        alert("PaymentReceiveDate_" + response.d[0]["PaymentReceiveDate"].toString());
                debugger;
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtBankrefNo").value = selectoption.options[selectoption.selectedIndex].text;

                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtpaymentClearDate").value = response.d[0]["PaymentClearDate"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtTenure").value = response.d[0]["Tenure"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtPaymentDueDate").value = response.d[0]["PaymentDueDate"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtPaymentRecDate").value = response.d[0]["PaymentReceiveDate"].toString();

                jQuery.facebox("Bank ref number updated successfully");
            }
            function OnErrorCall(response) {
            }
        }
        else {
            // alert(oldBankRefNo);
            var dd = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_ddlBankRefNo");
            for (var i = 0; i < dd.options.length; i++) {
                if (dd.options[i].text == oldBankRefNo) {
                    dd.options[i].selected = "true";
                    break;
                }
            }
            return false;
        }
    }
    function BankRefValidate(elem) {
        debugger;
        var ControlID = elem.id;
        var Ids = ControlID;
        var RowID = Ids.split("_")[2].substr(3, 4);
        //alert(RowID);
        var selectoption = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_ddlBankRefNo");
        //var NewBankRefNo = selectoption.options[selectoption.selectedIndex].text;

        var NewBankRefNo = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtBankrefNo").value;
        var oldBankRefNo = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnbnkrefno").value;
        var InvoiceID = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnInvoiceID").value;
        // alert(selectoption.options[selectoption.selectedIndex].innerHTML);
        var hdnShipmentNo__PkID = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnShipmentNo__PkID").value;



        if (confirm("Are you sure want to change bank reference number ?") == true) {
            var url = "../../Webservices/iKandiService.asmx";
            jQuery.ajax({
                type: "POST",
                url: url + "/UpdateBankRefNo",
                data: "{ ShipemntPkID:'" + hdnShipmentNo__PkID + "', OldBankRefNo:'" + oldBankRefNo + "', NewBankRefNo:'" + NewBankRefNo + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {
                debugger;
                //selectoption.options[selectoption.selectedIndex].text = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtBankrefNo").value;
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtpaymentClearDate").value = response.d[0]["PaymentClearDate"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtTenure").value = response.d[0]["Tenure"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtPaymentDueDate").value = response.d[0]["PaymentDueDate"].toString();
                document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtPaymentRecDate").value = response.d[0]["PaymentReceiveDate"].toString();

                jQuery.facebox("Bank ref number updated successfully");

            }
            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
        else {
            // alert(oldBankRefNo);
            //                var dd = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_ddlBankRefNo");
            //                for (var i = 0; i < dd.options.length; i++) {
            //                    if (dd.options[i].text == oldBankRefNo) {
            //                        dd.options[i].selected = "true";
            //                        break;
            //                    }
            //                }
            elem.value = elem.defaultValue;
            return false;
        }

    }
    function isNumberKeyWithDecimal(evt, obj) {
        //      debugger;
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
    var specialKeys = new Array();
    specialKeys.push(8); //Backspace
    specialKeys.push(9); //Tab
    specialKeys.push(46); //Delete
    specialKeys.push(36); //Home
    specialKeys.push(35); //End
    specialKeys.push(37); //Left
    specialKeys.push(39); //Right
    function IsAlphaNumeric(e) {
        var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
        var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
        return ret;
    }
    $(document).ready(function () {
        //attach with the id od deductions
        var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
        var proxy = new ServiceProxy(serviceUrl);

    });
    function SetDefualtValue(elem) {

        var Values = elem.value;
        //  debugger;
        var Ids = elem.id;
        //var CId = Ids.substr(38);
        var SplitId = Ids.split('_');
        var CtlID = SplitId[2].substring(2, 5);
        var OldBnkRefNo = jQuery("#<%= grdinvoice.ClientID %> input[id*='ct" + CtlID + "_hdnBankRefNo" + "']").val();
        var CurrencyType = jQuery("#<%= grdinvoice.ClientID %> input[id*='ct" + CtlID + "_hdnconvertto" + "']").val();
        var hdnShipmentNo__PkID = jQuery("#<%= grdinvoice.ClientID %> input[id*='ct" + CtlID + "_hdnShipmentNo__PkID" + "']").val();
        var OldBnkRefNo = jQuery("#<%= grdinvoice.ClientID %> input[id*='ct" + CtlID + "_hdnBankRefNoCopy" + "']").val();

        var selectoption = jQuery("#<%= grdinvoice.ClientID %> input[id*='ct" + CtlID + "_ddlBankRefNo" + "']").val();
        //var NewBnkRef=selectoption.options[selectoption.selectedIndex].innerHTML;

        if (Values == '') {
            jQuery.facebox("Bank ref number could not be blank");
            elem.value = elem.defaultValue;
        }
        else {

            //            proxy.invoke("ValidateBnkRefNo", { BnkRefNo: Values, CurrencyType: CurrencyType }, function (result) {
            //                if (result[0].toString() != 'NOTALLOW') {
            //                    alert('Different currency could not be merge');
            //                    elem.value = elem.defaultValue;
            //                }
            //            }, onPageError, false, false);



            var url = "../../Webservices/iKandiService.asmx";
            jQuery.ajax({
                type: "POST",
                url: url + "/ValidateBnkRefNo",
                data: "{ BnkRefNo:'" + Values + "', CurrencyType:'" + CurrencyType + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {
                if (response.d.toString() != 'ALLOW') {
                    //  alert(response.d[0].toString());
                    alert('Different currency Invoice could not be merge');
                    elem.value = elem.defaultValue;
                }
                else {
                    BankRefValidate(elem);
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
    }
    function GetBankChangeRefNo() {

        var url = "../../Webservices/iKandiService.asmx";
        jQuery.ajax({
            type: "POST",
            url: url + "/UpdateBankRefNo",
            data: "{ ShipemntPkID:'" + hdnShipmentNo__PkID + "', OldBankRefNo:'" + OldBnkRefNo + "', NewBankRefNo:'" + NewBnkRef + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });
        function OnSuccessCall(response) {



            //  alert(response.d[0].toString());
            alert('Different currency Invoice could not be merge');
            elem.value = elem.defaultValue;

        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
    function numberWithCommas(x) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
    function operation() {

        //alert("ss");
        // debugger;
        // var OldValue = parseInt(document.getElementById('<%=txtInvoiceAmt.ClientID %>').value); 
        var OldValue = parseFloat(document.getElementById('<%=hdninvoicetotalAmt.ClientID %>').value);
        var shipValue = parseFloat(document.getElementById('<%=txtInvoiceAmt.ClientID %>').value);

        var txtfrightchargeValue = parseFloat(document.getElementById('<%=txtfrightcharge.ClientID %>').value); //+
        var txtInsuranceAmtValue = parseFloat(document.getElementById('<%=txtInsuranceAmt.ClientID %>').value); //+

        var txtDiscountAmtValue = parseFloat(document.getElementById('<%=txtDiscountAmt.ClientID %>').value); //-
        var txtFourthNumberValue = parseFloat(document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value);
        var hdntotalamtValue = parseFloat(document.getElementById('<%=hdntotalamt.ClientID %>').value);

        if (txtfrightchargeValue == "" || isNaN(txtfrightchargeValue))
            txtfrightchargeValue = 0;

        if (txtInsuranceAmtValue == "" || isNaN(txtInsuranceAmtValue))
            txtInsuranceAmtValue = 0;

        if (txtDiscountAmtValue == "" || isNaN(txtDiscountAmtValue))
            txtDiscountAmtValue = 0;

        if (txtFourthNumberValue == "" || isNaN(txtFourthNumberValue))
            txtFourthNumberValue = 0;
        var result = ((txtfrightchargeValue + txtInsuranceAmtValue) - (txtDiscountAmtValue)).toFixed(2);
        if (!isNaN(result)) {
            if (result > 0) {
                //                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = (parseFloat(OldValue) + parseFloat(result)).toFixed(2);
                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = numberWithCommas((parseFloat(OldValue) + parseFloat(result)).toFixed(2));
                document.getElementById('<%=hdntotalamt.ClientID %>').value = (parseFloat(OldValue) + parseFloat(result)).toFixed(2); ;
            }
            else if (result < 0) {
                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = numberWithCommas((parseFloat(OldValue) - Math.abs(parseFloat(result))).toFixed(2));
                //                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = (parseFloat(OldValue) - Math.abs(parseFloat(result))).toFixed(2);
                document.getElementById('<%=hdntotalamt.ClientID %>').value = (parseFloat(OldValue) - Math.abs(parseFloat(result))).toFixed(2);
            }
            else {
                // alert(numberWithCommas(parseFloat(shipValue).toFixed(2)));
                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = numberWithCommas(parseFloat(OldValue).toFixed(2));
                //                document.getElementById('<%=txtinvoicetotalAmt.ClientID %>').value = parseFloat(shipValue).toFixed(2);
                document.getElementById('<%=hdntotalamt.ClientID %>').value = parseFloat(shipValue).toFixed(2);
            }

        }

        return true;

    }
    function Validate(sender, args) {

        if (Flag == 'INVOICEPAYMENT') {
            var gridView = document.getElementById("<%=grdinvoice.ClientID %>");
            var checkBoxes = gridView.getElementsByTagName("input");
            var grid = document.getElementById("<%= grdinvoice.ClientID%>");

            for (var i = 0; i < grid.rows.length - 1; i++) {
                var BnkRefNo = jQuery("input[id*=hdnbnkrefno]")
                var ChkActions = jQuery("input[id*=chkaction]")
                if (ChkActions[i].type == "checkbox" && ChkActions[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
        else {
            var grid = document.getElementById("<%= grdpacking.ClientID%>");
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var ChkConsoli = jQuery("input[id*=ChkConsoli]")
                if (ChkConsoli[i].type == "checkbox" && ChkConsoli[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    }
    function ValidatePayChk() {
        //debugger;
        //alert(Flag);
        if (Flag == 'INVOICED') {
            // debugger;
            var inputVal = jQuery("#" + PaymentDueDate).val();
            if (jQuery("#" + PaymentDueDate).val() == "") {
                jQuery.facebox("please select payment due date")
                return false;
            }
            if (jQuery("#" + Landingeta).val() == "") {
                jQuery.facebox("Please select Landing ETA it could not be blank")
                return false;
            }
            if (jQuery("#" + txtInvoiceNo).val() == "") {
                jQuery.facebox("Please enter invoice number")
                return false;
            }
            if (jQuery("#" + UpInvoice).val() == "" && jQuery("#" + HdninvoiceFile).val() == "") {
                jQuery.facebox("Please select invoice document")
                return false;
            }
            if (jQuery("#" + txtInvoiceAmt).val() == "") {
                jQuery.facebox("Ship value cannot be 0 or empty")
                return false;
            }
            if (jQuery("#" + invoiceDate).val() == "") {
                jQuery.facebox("Please select invoice date")
                return false;
            }

        }
        else if (Flag == 'CONSOLIDATION') {
            //debugger;
            //var inputVal = jQuery("#" + PaymentDueDate).val();
            if (jQuery("#" + Landingeta).val() == "") {
                jQuery.facebox("Please select Landing ETA it could not be blank")
                return false;
            }
            if (jQuery("#" + UpPackingFile).val() == "" && jQuery("#" + hdnpackinglistfile).val() == "") {
                jQuery.facebox("Please select packing file");
                return false;
            }
            var gridView = document.getElementById("<%=grdpacking.ClientID %>");
            var checkBoxes = gridView.getElementsByTagName("input");
            var grid = document.getElementById("<%= grdpacking.ClientID%>");
            var CheckCountCons = 0;
            for (var i = 0; i < grid.rows.length; i++) {

                var ChkActions = jQuery("input[id*=ChkConsoli]")
                if (ChkActions[i].type == "checkbox" && ChkActions[i].checked) {
                    CheckCountCons += 1;
                }

            }

            if (CheckCountCons <= 0) {
                //debugger;



                jQuery.facebox("Please select at least one record.")
                return false;
            }
            else {
                jQuery.facebox("Please make sure you are saving again invoice page just after this activity");
            }
        }
        else if (Flag == 'INVOICEPAYMENT') {
            //debugger;
            var gridView = document.getElementById("<%=grdinvoice.ClientID %>");
            var checkBoxes = gridView.getElementsByTagName("input");
            var grid = document.getElementById("<%= grdinvoice.ClientID%>");
            var CheckCount = 0;
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var BnkRefNo = jQuery("input[id*=hdnbnkrefno]")
                var ChkActions = jQuery("input[id*=chkaction]")
                if (ChkActions[i].type == "checkbox" && ChkActions[i].checked) {
                    CheckCount += 1;
                }
            }
            if (CheckCount <= 0) {
                //debugger;
                //jQuery.facebox("Please select at least one record.")
                //                var r = confirm("If you have changed any thing then click ok else cancel ");
                //                if (r == true) {
                //                    
                //                    return false;
                //                } else {
                //                    return false;
                //                                }
                //                jQuery.facebox("Please select at least one record.");
                return true;

            }
        }
        else {
            return true;
        }

    }
    //    function ValidateInvoice(sender, args) {
    //        var gridView = document.getElementById("<%=grdinvoice.ClientID %>");
    //        var checkBoxes = gridView.getElementsByTagName("input");
    //        for (var i = 0; i < checkBoxes.length; i++) {
    //            if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
    //                args.IsValid = true;
    //                return;
    //            }
    //        }
    //        args.IsValid = false;
    //    }
    //    function ValidateInvoice() {
    //        if (Flag == 'INVOICEPAYMENT') {
    //            var gridView = document.getElementById("<%=grdinvoice.ClientID %>");
    //            var checkBoxes = gridView.getElementsByTagName("input");
    //            for (var i = 0; i < checkBoxes.length; i++) {
    //                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
    //                    args.IsValid = true;
    //                    return;
    //                }
    //            }
    //            args.IsValid = false;
    //        }
    //    }

    function IsFullPaymentCheck(elem) {
        //        debugger;
        var ControlID = elem.id;
        var Ids = ControlID;
        var RowID = Ids.split("_")[2].substr(3, 4);
        var txtBankrefNo = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtBankrefNo").value;
        if (document.getElementById(ControlID).checked == true) {
            if (txtBankrefNo.toLowerCase().includes('new')) {
                jQuery('#' + ControlID).prop('checked', false);
                jQuery.facebox("Bank Ref No is not updated \r\n  So Full Payment Recived NAplicable.")
                return false;
            }
        }
    }

    function BankReFAction(elem) {
        //debugger;
        var ControlID = elem.id;
        var Ids = ControlID;
        var RowID = Ids.split("_")[2].substr(3, 4);
        var oldBankRefNo = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_hdnbnkrefno").value;
        if (document.getElementById(ControlID).checked == true) {
            // alert("checked");
            var grid = document.getElementById("<%= grdinvoice.ClientID%>");
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var BnkRefNo = jQuery("input[id*=hdnbnkrefno]")
                var ChkActions = jQuery("input[id*=chkaction]")
                if (BnkRefNo[i].value != '') {
                    if (BnkRefNo[i].value == oldBankRefNo) {
                        jQuery(ChkActions[i]).prop('checked', true)
                    }
                }
            }
        }
        else {
            //alert("Checkbox is unchecked.");

            var grid = document.getElementById("<%= grdinvoice.ClientID%>");
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var BnkRefNo = jQuery("input[id*=hdnbnkrefno]")
                var ChkActions = jQuery("input[id*=chkaction]")
                if (BnkRefNo[i].value != '') {
                    if (BnkRefNo[i].value == oldBankRefNo) {
                        jQuery(ChkActions[i]).prop('checked', false)
                    }
                }
            }
        }
    }
    function close_window() {
        if (confirm("Close Window?")) {
            close();
        }
    }
</script>
<script type="text/javascript">


    $(document).ready(function () {
        debugger;
        // alert("ss");
        //after executing some functions
        // jQuery.facebox('Please check Sample Sent');
        // alert(Flag);
        //        jQuery(".loadingimage").show();

        if (Flag == 'CONSOLIDATION') {

            jQuery(".shipConsolidate").hide();
            jQuery(".widthTable").css("width", "auto");
            jQuery(".fieldsetPacking").show();

        }
        else {
            jQuery(".fieldsetPacking").removeClass("fieldsetPacking1");
            jQuery(".widthTable").removeClass("widthTable1");
            jQuery("div").removeClass("divSearch1");
            jQuery(".shipConsolidate").show();
            jQuery(".fieldsetPacking").hide();
            jQuery(".widthTable").css("width", "100%");
        }

        if (Flag == 'INVOICEPAYMENT') {
            debugger;
            // alert("sdsd");
            jQuery(".divpacking").hide();

        }
        else
        { jQuery(".divpacking").show(); }

    });
    function CalculatePayDueDate(elem) {

        debugger;
        var ControlID = elem.id;
        var Ids = ControlID;
        var RowID = Ids.split("_")[2].substr(3, 4);
        //var BankRefDate = elem.value;
        var BankRefDate = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtpaymentClearDate").value;
        var Tenure = document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtTenure").value;
        if (Tenure == '') {
            Tenure = 0;
        }
        if (BankRefDate != '') {
            var DueDate = addDays(ParseDateToSimpleDate(BankRefDate), parseInt(Tenure));
            var dd = ParseDateToDateWithDay(DueDate).substr(0, 15);
            var DateArray = dd.split(" ");
            Exactdate = DateArray[2] + ' ' + DateArray[1] + ' ' + DateArray[3].substr(2, 3) + ' ' + '(' + DateArray[0] + ')';
            //alert(ParseDateToDateWithDay(DueDate));
            document.getElementById("psckingDelivery1_grdinvoice_ctl" + RowID + "_txtPaymentDueDate").value = Exactdate;
        }
        return false;

    }
    function addDays(date, days) {
        var result = new Date(date);
        result.setDate(result.getDate() + days);
        return result;
    }
    function ParseDateToSimpleDate(dateObject) {
        var index = dateObject.indexOf('(');
        if (index > -1) {
            dateObject = (dateObject.substring(0, index)).trim();

        }
        //dateObject = Date.parse(dateObject);
        dateObject = Date.parse(dateObject);
        return dateObject;
    }

    function ParseDateToDateWithDay(dateObject) {

        var date = new Date(dateObject);
        var newDate = date.toString("dd MMM yy (ddd)");
        return newDate;

    }
    function validateFloatKeyPress(el, evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        var number = el.value.split('.');
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        if (number.length > 1 && charCode == 46) {
            return false;
        }
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
</script>
<script type="text/javascript">    //Prevent enter F5
    window.onload = function () {
        document.onkeydown = function (e) {
            return (e.which || e.keyCode) != 116;
        };
    }


    function disablePage() {
        $("table").attr('disabled', true);
        $("input[type=checkbox]").attr('disabled', true);
        $("Select").attr('disabled', true);
        $(".submit").hide();
        $("input[type=text]").attr('disabled', true);



    }

</script>
<div style="width: 1070px; margin: 0px auto;">
    <asp:HiddenField ID="hdntotalamt" runat="server" Value="0" />
    <asp:Panel ID="pnlDisable" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdnnovicelistfile" Value="" runat="server" />
        <asp:HiddenField ID="hdnpackinglistfile" Value="" runat="server" />
        <h1 style="position: sticky; top: 0px; background-color: #39589c !important; color: #fff;
            padding: 5px 0px; margin: 10px 0px 0px; font-size: 15px; font-weight: 200; text-align: center;">
            <span style="float: left; color: #fff; padding-left: 10px; font-weight: normal; font-size: 10px;
                position: absolute; left: 0">All <span style="color: Red; font-size: 12px;">*</span>
                Fields Are Mandatory. </span>
                <span style="display: inline-flex;">
                    <asp:TextBox ID="txtSearch2" runat="server" ToolTip="Invoice No." placeholder="Invoice No."></asp:TextBox>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" style="margin: 0;border: 0;border-radius: 0px 4px 4px 0px;padding: 3px 3px 3px;" OnClick="BtnSearch_Click" />

                    </span>
            <asp:Label ID="Headertext" runat="server"></asp:Label>
            <div style="display: inline-block;float: right; margin-right: 1%;">
                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
                    Width="73px" OnClientClick="javascript:close_window();" OnClick="btnClose_Click"
                    Visible="false" />
                <%--   <asp:Button ID="btnSave" OnClientClick="javascript:return ValidatePayChk();" runat="server"
                Text="Submit" CssClass="save da_submit_button submit" OnClick="btnSave_Click" />--%>
                <asp:Button ID="btnSave" CssClass="save da_submit_button submit" runat="server" OnClick="btnSave_Click"
                    Text="Submit" OnClientClick="javascript:return ValidatePayChk();" />
            </div>
            <h1>
            </h1>
            <table id="tblinvoice" runat="server" cellpadding="0" cellspacing="0" class="item_list widthTable widthTable1">
                <tr>
                    <th style="text-align: right; padding-right: 10px !important;">
                        Shipment No.<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td id="th_con_ddlshipingno" runat="server" width="150px">
                        <asp:DropDownList ID="ddlshipingno" runat="server" Width="90%">
                        </asp:DropDownList>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        Invoice No.<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td class="shipConsolidate" width="150px">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtInvoiceNo" runat="server" autocomplete="off" AutoPostBack="true"
                                    MaxLength="100" onCopy="return false" onDrag="return false" onDrop="return false"
                                    onPaste="return false" OnTextChanged="txtInvoiceNo_TextChanged" Style="text-transform: uppercase;"
                                    Width="90%"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:HiddenField ID="hdninvoiceno" runat="server" />
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        (+)Total Ship Value &nbsp;&nbsp;<asp:Label ID="lblCurrencySy" runat="server" Visible="false"></asp:Label>
                        <%-- <span
                        style="color: red; font-size: 12px;" title="mendatory field">*</span>--%>
                    </th>
                    <td class="shipConsolidate">
                        <%--onkeypress="Javascript:return isNumberKeyWithDecimal(event, this); "--%>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtInvoiceAmt" runat="server" autocomplete="off" Enabled="false"
                                    MaxLength="10" onCopy="return false" onDrag="return false" onDrop="return false"
                                    onkeypress="return false;" onPaste="return false" Style="text-transform: uppercase;"
                                    Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqvshipvalue" runat="server" ControlToValidate="txtInvoiceAmt"
                                    CssClass="required" Display="Dynamic" ErrorMessage="Total ship amount cannot be empty"
                                    SetFocusOnError="true" Style="color: White;" Text="'" ValidationGroup="invoice" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; padding-right: 10px !important;">
                        Landing ETA<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td width="150px">
                        <asp:TextBox ID="txtlandingETA" runat="server" autocomplete="off" class="do-not-allow-typing th"
                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"
                            Style="text-transform: lowercase;" Width="90%"></asp:TextBox>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        Invoice Date<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td class="shipConsolidate" width="150px">
                        <asp:TextBox ID="txtinvoiceDate" runat="server" autocomplete="off" class="do-not-allow-typing th"
                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"
                            Style="text-transform: th;" Width="90%"></asp:TextBox>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        (+) Freight charge&nbsp;&nbsp;<asp:Label ID="lblcur1" runat="server" Visible="false"></asp:Label>
                    </th>
                    <td class="shipConsolidate">
                        <asp:TextBox ID="txtfrightcharge" runat="server" autocomplete="off" MaxLength="8"
                            onCopy="return false" onDrag="return false" onDrop="return false" onkeypress="return validateFloatKeyPress(this,event);"
                            onkeyup="Javascript:return operation();" onPaste="return false" Style="text-transform: uppercase;
                            background-color: #90EE90;" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; padding-right: 10px !important;">
                        AWB/BI No.
                    </th>
                    <td width="150px">
                        <asp:TextBox ID="txtAwb" runat="server" autocomplete="off" MaxLength="50" onCopy="return false"
                            onDrag="return false" onDrop="return false" onPaste="return false" Style="text-transform: uppercase;"
                            Width="90%"></asp:TextBox>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        Upload Invoice<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td class="shipConsolidate" width="150px">
                        <asp:FileUpload ID="UpInvoice" runat="server" onchange="javascript:Getfiles(this,'Invoice');"
                            Width="80%" />
                        <asp:HyperLink ID="hyplnkinvoice" runat="server" ImageUrl="~/App_Themes/ikandi/images/info.jpg"
                            Target="_blank" Text="" ToolTip="VIEW invoice List" Visible="false"></asp:HyperLink>
                        <asp:Button ID="btnInovieUpload" runat="server" CssClass="da_submit_button" OnClick="btnInovieUpload_Click"
                            Style="display: none;" Text="Upload" />
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        (+) Insurance&nbsp;&nbsp;<asp:Label ID="lblcur2" runat="server" Visible="false"></asp:Label>
                    </th>
                    <td class="shipConsolidate">
                        <asp:TextBox ID="txtInsuranceAmt" runat="server" autocomplete="off" MaxLength="8"
                            onCopy="return false" onDrag="return false" onDrop="return false" onkeypress="return validateFloatKeyPress(this,event);"
                            onkeyup="Javascript:return operation();" onPaste="return false" Style="text-transform: uppercase;
                            background-color: #90EE90;" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: right; padding-right: 10px !important;">
                        Enter Flight/Sailing Detail
                    </th>
                    <td width="150px">
                        <asp:TextBox ID="txtFlightDetails" runat="server" autocomplete="off" MaxLength="100"
                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"
                            Style="text-transform: uppercase;" Width="90%"></asp:TextBox>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        SB No.
                    </th>
                    <td class="shipConsolidate" width="150px">
                        <asp:TextBox ID="txtsbNo" runat="server" autocomplete="off" MaxLength="7" onCopy="return false"
                            onDrag="return false" onDrop="return false" onPaste="return false" Style="text-transform: uppercase;"
                            Width="90%"></asp:TextBox>
                    </td>
                    <th class="shipConsolidate" style="text-align: right; padding-right: 10px !important;">
                        (-) Discount&nbsp;&nbsp;<asp:Label ID="lblcur3" runat="server" Visible="false"></asp:Label>
                    </th>
                    <td class="shipConsolidate">
                        <asp:TextBox ID="txtDiscountAmt" runat="server" autocomplete="off" MaxLength="8"
                            onCopy="return false" onDrag="return false" onDrop="return false" onkeypress="return validateFloatKeyPress(this,event);"
                            onkeyup="Javascript:return operation();" onPaste="return false" Style="text-transform: uppercase;
                            background-color: #FAFAD2;" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr class="shipConsolidate">
                    <th style="text-align: right; padding-right: 10px !important;">
                        Payment Due date<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                    </th>
                    <td width="150px">
                        <asp:TextBox ID="txtPaymentDueDate" runat="server" autocomplete="off" class="do-not-allow-typing th"
                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"
                            Text='<%# Eval("PaymentDueDate") %>' Width="90%"></asp:TextBox>
                    </td>
                    <th style="text-align: right; padding-right: 10px !important;">
                        SB Date
                    </th>
                    <td width="150px">
                        <asp:TextBox ID="txtsbDate" runat="server" autocomplete="off" class="do-not-allow-typing th"
                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"
                            Style="text-transform: lowercase;" Width="90%"></asp:TextBox>
                    </td>
                    <th style="text-align: right; padding-right: 10px !important;">
                        Total Invoice Amount&nbsp;&nbsp;<asp:Label ID="lblcur4" runat="server" Visible="false"></asp:Label>
                        <%-- <span
                        style="color: red; font-size: 12px;" title="mendatory field">*</span>--%>
                    </th>
                    <td width="150px">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtinvoicetotalAmt" runat="server" autocomplete="off" Enabled="false"
                                    MaxLength="6" onCopy="return false" onDrag="return false" onDrop="return false"
                                    onkeypress="Javascript:return isNumberKeyWithDecimal(event, this);" onPaste="return false"
                                    Style="text-transform: uppercase;" Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdtotalinvoiceamt" runat="server" ControlToValidate="txtinvoicetotalAmt"
                                    CssClass="required" Display="Dynamic" ErrorMessage="Total invoice amount cannot be empty"
                                    SetFocusOnError="true" Style="color: White;" Text="'" ValidationGroup="invoice" />
                                <asp:HiddenField ID="hdninvoicetotalAmt" runat="server" Value="0" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trlInvoice2" runat="server" style="display: none;">
                    <th width="160px">
                    </th>
                </tr>
                <tr id="trlInvoice4" runat="server" style="display: none;">
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="fieldsetPacking fieldsetPacking1">
                <strong>Packing List:</strong><br />
                <table id="tblPacking" runat="server" cellpadding="0" cellspacing="0" class="item_list"
                    style="width: 400px !important; margin-top: 3px;" visible="false">
                    <tr>
                        <th style="width: 125px">
                            Upload Packing List<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                        </th>
                        <td style="width: 250px">
                            <asp:FileUpload ID="UpPackingFile" runat="server" ToolTip="Select packing documents here"
                                Width="90%" />
                        </td>
                        <td style="width: 40px">
                            <asp:Button ID="btnUploadDoc" runat="server" CssClass="da_submit_button" OnClick="btnUploadDoc_Click"
                                Style="display: none;" Text="Upload" />
                            <asp:HyperLink ID="viewpackinglist" runat="server" ImageUrl="~/App_Themes/ikandi/images/info.jpg"
                                Target="_blank" Text="" ToolTip="VIEW Packing List" Visible="false"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divSearch" runat="server" class="divSearch1" style="height: 35px; display: none;
                margin-top: 10px;">
                <asp:TextBox ID="txtsearch" runat="server" autocomplete="off" CssClass="searchserial"
                    MaxLength="20" onCopy="return false" onDrag="return false" onDrop="return false"
                    onPaste="return false" placeholder="Search" Style="height: 22px !important; text-transform: capitalize;"
                    ToolTip="Enter search text">
                </asp:TextBox>
                &nbsp;&nbsp;<asp:Button ID="btnsaerch" runat="server" CssClass="submit" OnClick="btnsaerch_Click"
                    Text="GO" ToolTip="Search" ValidationGroup="searchserial" />
                <%--<asp:RegularExpressionValidator runat="server" ID="rexNumber" Display="Dynamic" onpaste="return false"
            ControlToValidate="txtsearch" SetFocusOnError="true" ValidationGroup="searchserial"
            ValidationExpression="^[a-zA-Z0-9_\s]*$" ErrorMessage="Please enter valid serial number" />--%>
                <%-- <asp:RegularExpressionValidator ID="Regex1" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
            ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
            SetFocusOnError="true" ControlToValidate="txtInvoiceAmt" Display="Dynamic" />--%>
            </div>
            <div style="clear: both;">
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional">
                <ContentTemplate>
                    <div class="divpacking" style="width: 100%; margin-top: 5px">
                        <table border="1" cellpadding="0" cellspacing="0" class="item_list" style="width: 1070px">
                            <thead class="headermain">
                                <tr>
                                    <th scope="col" style="width: 160px">
                                        Serial No.
                                        <br>Style No.
                                            <br>Order Date </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 233px">
                                        Shipped Quantity
                                        <br>Line No.
                                            <br>Contract No. </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 305px">
                                        Main Fabric
                                        <br>Color Print </br>
                                    </th>
                                    <th scope="col" style="width: 150px">
                                        Status
                                        <br>Mode
                                            <br>Ex. Factory </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 102px">
                                        Select To Consolidate
                                    </th>
                                </tr>
                            </thead>
                            <thead class="headertop" style="display: none;">
                                <tr>
                                    <th scope="col" style="width: 177px">
                                        Serial No.
                                        <br>Style No.
                                            <br>Order Date </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 261px">
                                        Shipped Quantity
                                        <br>Line No.
                                            <br>Contract No. </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 341px">
                                        Main Fabric
                                        <br>Color Print </br>
                                    </th>
                                    <th scope="col" style="width: 169px">
                                        Status
                                        <br>Mode
                                            <br>Ex. Factory </br>
                                        </br>
                                    </th>
                                    <th scope="col" style="width: 115px">
                                        Select To Consolidate
                                    </th>
                                </tr>
                            </thead>
                        </table>
                        <div style="/*max-height: 500px; overflow-y: auto*/">
                            <asp:GridView ID="grdpacking" runat="server" AutoGenerateColumns="false" CssClass="item_list"
                                EmptyDataText="No data found!" HorizontalAlign="Center" OnPageIndexChanging="grdpacking_PageIndexChanging"
                                OnRowDataBound="grdpacking_RowDataBound" ShowHeader="false" ShowHeaderWhenEmpty="true"
                                Style="margin: 0px auto;" Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Serail No.
                                            <br />
                                            Style No.
                                            <br />
                                            Order Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:HiddenField ID="hdnOrderDetailID" runat="server" Value='<%#Eval("OrderDatailsID") %>' />
                                                        <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Eval("OrderID") %>' />
                                                        <%--<asp:HiddenField ID="hdnBankRefID" runat="server" Value='<%# Eval("BnkRefID") %>' />--%>
                                                        <asp:Label ID="lblSerialNo" runat="server" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblStyleNo" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblOrderDate" runat="server" ForeColor="Gray" Text='<%#Eval("OrderDate") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="159px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Quantity
                                            <br />
                                            Line No.
                                            <br />
                                            Contract No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblLineNo" runat="server" ForeColor="Gray" Text='<%#Eval("LineNos") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblContractNo" runat="server" ForeColor="Gray" Text='<%#Eval("ContractNumber") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="234px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Main Fabric
                                            <br />
                                            Color Print
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                                <tr>
                                                    <td style="height: 30px">
                                                        <asp:Label ID="lblMainFabric" runat="server" ForeColor="Gray" Text='<%#Eval("Fabric1") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblColorPrint" runat="server" ForeColor="Gray" Text='<%#Eval("PrintRef") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="306px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Status
                                            <br />
                                            Mode
                                            <br />
                                            Ex. Factory
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblStatus" runat="server" ForeColor="Gray" Text='<%#Eval("status_modename") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblMode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblExfa" runat="server" Text='<%#Eval("ExFactory") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Select To Consolidate
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkConsoli" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsPackingUpload"))%>'
                                                Visible="false" />
                                            <asp:CheckBox ID="Chkinvice" runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("IsPackingUpload"))%>'
                                                OnCheckedChanged="Chkinvice_CheckChanged" Visible="false" />
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <h1>
                                        No Data Found.</h1>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                <ContentTemplate>
                    <asp:GridView ID="grdinvoice" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        CssClass="item_list" EmptyDataText="No data found!" HorizontalAlign="Center"
                        OnPageIndexChanging="grdinvoice_PageIndexChanging" OnRowDataBound="grdinvoice_RowDataBound"
                        PageSize="200" ShowHeader="true" Style="margin: 0px auto;" Visible="false" Width="100%">
                        <SelectedRowStyle BackColor="#E6E6FA" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Serial No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr style="display: none;">
                                            <td style="height: 15px">
                                                <asp:HiddenField ID="hdnOrderDetailID" runat="server" Value='<%#Eval("OrderDetailsID") %>' />
                                                <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Eval("OrderID") %>' />
                                                <%--<asp:Label ID="lblSerialNo" runat="server" Text='<%#Eval("SerialNumber") %>'></asp:Label>--%>
                                                <asp:HiddenField ID="hdnRepeatCount" runat="server" Value='<%#Eval("BankRefNoCount") %>' />
                                                <%--<asp:HiddenField ID="hdnConvertTo" runat="server" Value='<%#Eval("ConvertTo") %>' />--%>
                                                <asp:HiddenField ID="hdnBankRefID" runat="server" Value='<%# Eval("BankRefID") %>' />
                                                <asp:HiddenField ID="hdnBankRefNo" runat="server" Value='<%# Eval("BankRefNumber") %>' />
                                                <asp:HiddenField ID="hdnIsSingle" runat="server" Value='<%# Eval("IsSingle") %>' />
                                                <asp:HiddenField ID="hdnShipmentNo__PkID" runat="server" Value='<%# Eval("ShipmentNo__PkID") %>' />
                                                <asp:HiddenField ID="hdnconvertto" runat="server" Value='<%# Eval("ConvertTo") %>' />
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptserial" runat="server" OnItemDataBound="rptserial_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblSerialNo" runat="server" CssClass="repeatChange" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                                        <%--<asp:Label ID="lblStyleNo" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>--%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Invoice No.
                                    <br />
                                    Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblinvoiceNo" runat="server" Font-Bold="true" Text='<%#Eval("InvoiceNumber") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblinvoiceDate" runat="server" Text='<%#Eval("InvoiceDate") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    SB No.
                                    <br />
                                    SB Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 30px">
                                                <asp:Label ID="lblSbNo" runat="server" ForeColor="Gray" Text='<%#Eval("SBno") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblSbDate" runat="server" ForeColor="Gray" Text='<%#Eval("SBDate") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="110px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Invoice Amount
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblinvoiceAmt" runat="server" Text='<%#Eval("InvoiceAmount") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Shipment No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblshipmentNo" runat="server" Text='<%#Eval("ShippingNo") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Total BE Amount<br />
                                    <br />
                                    Pending Amount
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lbltotalBeAmount" runat="server" Font-Size="11px" Style="color: Gray;"
                                                    Text='<%#Eval("TotalBEAmount") %>' ToolTip="Total BE amount"></asp:Label>
                                            </td>
                                        </tr>
                                        <br />
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblPendingAmt" runat="server" Font-Size="11px" Text='<%#Eval("BankPendingAmt") %>'
                                                    ToolTip="Pending amount"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Bank Ref. No.<span style="color: red; font-size: 12px;" title="mendatory field">*</span>
                                    <br />
                                    Bank Ref. Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <%--<asp:Label ID="lblBankrefNo" runat="server" Text='<%#Eval("BankRefNumber") %>'></asp:Label>--%>
                                                <asp:TextBox ID="txtBankrefNo" runat="server" CssClass="bnsl" display="None" Enabled="false"
                                                    MaxLength="18" Onchange="javascript:SetDefualtValue(this);" Style="text-transform: uppercase;"
                                                    Text='<%#Eval("BankRefNumber") %>'></asp:TextBox>
                                                <asp:HiddenField ID="hdnBankRefNoCopy" runat="server" Value='<%# Eval("BankRefNumber") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                </span>
                                                <asp:TextBox ID="txtpaymentClearDate" runat="server" class="do-not-allow-typing th FCSaleDate"
                                                    onchange="javascript:CalculatePayDueDate(this);" Text='<%#Eval("PaymentClearDate") %>'
                                                    ToolTip="select payment Clear Date"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Tenure
                                    <br />
                                    Payment Due Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="txtTenure" runat="server" autocomplete="off" CssClass="numeric-field-without-decimal-places tooltip"
                                                    MaxLength="3" onchange="javascript:CalculatePayDueDate(this);" onCopy="return false"
                                                    onDrag="return false" onkeypress="return isNumber(event)" Text='<%#Eval("Tenure") %>'
                                                    ToolTip="Enter Tenure"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="txtPaymentDueDate" runat="server" autocomplete="off" class="do-not-allow-typing tooltip"
                                                    onCopy="return false" onDrag="return false" Text='<%# Eval("PaymentDueDate") %>'
                                                    ToolTip="Payment due date"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="110px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Payment Rec/Clear Date
                                    <br />
                                    Amt.&amp; is Full payment Received
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkIsSplit" runat="server" AutoPostBack="true" CssClass="tooltip"
                                                    OnCheckedChanged="chkIsSplit_CheckChanged" Text="Split payment" ToolTip="Check split payment option if you want payment would be individual for each contract" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="txtPaymentRecDate" runat="server" class="do-not-allow-typing th"
                                                    Style="text-transform: lowercase;" Text='<%#Eval("PaymentReceiveDate") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Label ID="lblCurrencyTag" runat="server"></asp:Label>
                                                <asp:TextBox ID="txtPaymentRecAmt" runat="server" autocomplete="off" MaxLength="9"
                                                    onkeypress="Javascript:return isNumberKeyWithDecimal(event, this);" Text='<%#(Eval("BankPaymentRecAmt") == "0" ? "" : Eval("BankPaymentRecAmt"))%>'
                                                    Width="100px"></asp:TextBox>
                                                <asp:CheckBox ID="ChkIsFullPayemntRec" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsFullPaymentCleard"))%>'
                                                    onclick="javascript:IsFullPaymentCheck(this)" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Group Invoice For Bank Ref. No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlBankRefNo" runat="server" onChange="javascript: return ShowConfirm(this);">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnbnkrefno" runat="server" Value='<%# Eval("BankRefNumber") %>' />
                                    <asp:HiddenField ID="hdnInvoiceID" runat="server" Value='<%# Eval("ShipmentNo__PkID") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Action
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RequiredFieldValidator ID="reqBankrefNo" runat="server" ControlToValidate="txtBankrefNo"
                                        CssClass="required" Display="Dynamic" ErrorMessage="Please enter bank ref no."
                                        SetFocusOnError="true" Style="color: White;" Text="'" />
                                    <asp:CheckBox ID="chkaction" runat="server" onclick="javascript:BankReFAction(this)" />
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" onclick="javascript:BankReFAction(this)" OnCheckedChanged="chkaction_CheckChanged" />--%>
                                    <%--<asp:CustomValidator ID="CustomValidator1" ControlToValidate="chkaction"   Display="None" runat="server" ErrorMessage="Please select at least one record."
                ClientValidationFunction="Validate" ForeColor="Red"></asp:CustomValidator>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID="txtinvoicetotalAmt" EventName="textchanged" />--%>
                </Triggers>
            </asp:UpdatePanel>
            <%-- <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
        Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" OnClick="btnClose_Click" />--%>
            <h1>
            </h1>
            <h1>
            </h1>
            <h1>
            </h1>
            <h1>
            </h1>
        </h1>
    </asp:Panel>
</div>
<asp:Button ID="btntrackedcancel" Style="display: none;" OnClick="btntrackedcancel_Click"
    runat="server" />
<asp:ValidationSummary ID="vsSummary" runat="server" ShowSummary="False" HeaderText="Please correct the fields; "
    ShowMessageBox="true" />
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="invoice" runat="server"
    ShowSummary="False" HeaderText="Please correct the fields; " ShowMessageBox="true" />
