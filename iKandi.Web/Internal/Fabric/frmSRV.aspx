<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSRV.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.frmSRV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        body
        {
            font-family: Arial;
        }
        .FabricConainer
        {
            width: 100%;
            margin: 0 auto;
        }
        .toptable thead span
        {
            line-height: 20px;
        }
        .toptable thead input[type="text"]
        {
            width: 76px;
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
        }
        .bottomtable input[type="text"]
        {
            width: 80px;
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
        }
        .srvtable input[type="text"]
        {
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
        }
        .header1
        {
            background: #dddfe4;
        }
        .srvtable td
        {
            padding: 2px 3px;
        }
        .widhcol1
        {
            width: 100px;
        }
        .widhcol2
        {
            width: 120px;
        }
        .widhcol3
        {
            width: 40px;
        }
        .srvtable
        {
            width: 100%;
        }
        
        .srvtable th
        {
            padding: 2px 2px;
            text-align: center;
            font-weight: 500;
            background: #dddfe4;
            text-transform: capitalize;
            color: #6b6464;
            border: 1px solid #999;
            font-size: 11px;
        }
        .srvtable td
        {
            border: 1px solid #dbd8d8;
            font-size: 10px;
        }
        #secure_banner_cor
        {
            margin-left: 0px !important;
        }
        td
        {
            font-size: 11px;
        }
        .srvtable td
        {
            text-align: center;
        }
        .da_astrx_mand
        {
            color: Red;
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
            text-align: center;
            font-family: Arial;
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
        {
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
            margin-left: 5px;
            font-family: Arial;
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
            text-align: center;
            font-family: Arial;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        
        .border_right_color
        {
            border-right-color: #999 !important;
        }
        .border_left_color
        {
            border-left-color: #999 !important;
        }
        .srvtable tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        
        .PartyTable
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .PartyTable th
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial;
            min-width: 50px;
        }
        
        .PartyTable td
        {
            border: 1px solid #dbd8d8;
            font-size: 10px;
            padding: 3px 3px;
            color: #272626;
            height: 12px;
            font-family: Arial;
            text-align: center;
        }
        .PartyTable td:first-child
        {
            border-left-color: #999 !important;
        }
        .PartyTable td:last-child
        {
            border-right-color: #999 !important;
        }
        .PartyTable tr:nth-last-child(1) td
        {
            border-bottom-color: #999 !important;
        }
        .BillWidth
        {
            width: 80px;
        }
        .BillWidth2
        {
            width: 90px;
        }
        .PartyTable td input
        {
            width: 80%;
        }
        .PartyTable td input[type="date"]
        {
            width: 108px;
        }
        .padding_2
        {
            padding: 2px 3px !important;
        }
        .txtCenter
        {
            text-align: center;
        }
        td.HeadeOtherPo
        {
            border-top: 1px solid #999;
            border-bottom: 1px solid #999;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #272626;
            font-family: Arial;
        }
        .txtColorGray
        {
            color: #504c4c !important;
        }
        
        #spinner
        {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 999999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat;
        }
        textarea
        {
            text-transform: capitalize;
        }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #999;
            border: 1px solid #ddd7d7;
            border-radius: 10px;
        }
        
        .ui-widget-content
        {
            display: none;
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
    <%-- <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>--%>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <form id="form1" runat="server">
    <script type="text/javascript">
        
        var ChallanID = '<%=this.Challan_ID %>';        

        $(window).load(function () { $("#spinner").fadeOut("slow"); });

        $(document).ready(function () {

            //            $('#srvgrid_ctl02_txtReceivedqty').on('input propertychange paste', function () {
            //                alert("reeciveqty changes");
            //            });

            //            $(document).on("input", ".numeric", function () {
            //                this.value = this.value.replace(/\D/g, '');

            var RecQty = $('#srvgrid_ctl02_txtReceivedqty').val();
            // alert(RecQty);
            if (parseInt(RecQty) < 0) {
                // $('#srvgrid_ctl02_txtReceivedqty').style("color:#D59013;");
                //                document.getElementById("srvgrid_ctl02_txtReceivedqty").value = "#D59013";
                $("#srvgrid_ctl02_txtReceivedqty").css({ "color": "#D59013", "font-weight": "bold" });

            }
            //            });


            $(".datepick").datepicker({ dateFormat: 'dd M y (D)' });
            $('input').keyup(function () {
                $(this).val($(this).val().toUpperCase());
            });

            //            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $("#secure_greyline").hide();
            $('input').attr('autocomplete', 'off');

            //            $(".noonly").keypress(function (e) {
            //                //if the letter is not digit then display error and don't type anything
            //                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //                    return false;
            //                }
            //            });
            //            $('[id*=txtReceivingVoucherNo]').attr('readonly', 'true');
            $('[id*=txtSrvDate]').attr('readonly', 'true');

            $('[id*=txtPartyChallanNo]').keypress(function (e) {
                var regex = new RegExp("^[a-zA-Z0-9]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                    return true;
                }

                e.preventDefault();
                return false;
            });

            $('input.alpha[$id=txtPartyBillNo]').keyup(function () {
                if (this.value.match(/[^a-zA-Z0-9 ]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z0-9 ]/g, '');
                }
            });

            $("#srvgrid_ctl02_txtReceivedqty").bind("keyup", function (event) {
                var conversionvalue = $('#srvgrid_ctl02_hdnconver').val();
                if (conversionvalue == "") {
                    conversionvalue = 1;
                }
                var v = isNaN(Math.round((parseFloat($('#srvgrid_ctl02_txtReceivedqty').val().replace(',', ''))) / (parseFloat(conversionvalue)), 0)) ? 0 : parseInt(Math.round((parseFloat($('#srvgrid_ctl02_txtReceivedqty').val().replace(',', ''))) / (parseFloat(conversionvalue)), 0));
                var old = isNaN(Math.round((parseFloat($('#srvgrid_ctl02_hdnReceivedqty').val())) / (parseFloat(conversionvalue)), 0)) ? 0 : parseInt(Math.round((parseFloat($('#srvgrid_ctl02_hdnReceivedqty').val())) / (parseFloat(conversionvalue)), 0));
                $('[id*=lbldefualtunitreceiveQty]').text((v == "0" ? numberWithCommas(old) : numberWithCommas(v)));
            });

        });
        function TakeSRV() {
            var MinQty = $('#srvgrid_ctl02_hdnReceivedqty').val();
            var char = $('#srvgrid_ctl02_txtReceivedqty').val().replace(',', '');
            if (ChallanID > 0) {
                if ((parseInt(char) < parseInt(MinQty)) && $("#lblCheckedInchargeDate").text() != "") {
                    alert("SRV qty. cannot be less then :" + MinQty);
                    $('#srvgrid_ctl02_txtReceivedqty').val(numberWithCommas(MinQty));
                }
            }
        }        
        function callparentpage(postatus) {
            window.parent.CallThisPage(postatus);
        }

        function closeIframe() {
            $("#somediv").hide();
        }        

        function pageLoad() {
        }

        function ValidateBillNo(obj) {
//            var PartyBillNo = $('[id*=txtpartybillno]').val();
//            var PartyBillDate = $('[id*=txtPartyBillDate]').val();
//            var PartyAmount = $('[id*=txtAmount]').val();

//            if ($(obj).is(':checked')) {

//                if (PartyBillNo == "") {
//                    alert("Please Enter Party Bill Number");
//                    $(obj).removeAttr("checked");
//                    return false;
//                }
//                if (PartyBillDate == "") {
//                    alert("Please Enter Party Bill Date");
//                    $(obj).removeAttr("checked");

//                    return false;
//                }
//                if (PartyAmount == "") {
//                    alert("Please Enter Party Amount");
//                    $(obj).removeAttr("checked");
//                    return false;
//                }
//            }

        }

        function CheckPartyChallan(elem) {
            var PartyChallanNo = $('[id*=txtPartyChallanNo]').val();
            var partychallanComma = $('[id*=hdnpartychallanQue]').val();

            var count = 0;
            if (partychallanComma != "") {
                var Idsn = partychallanComma.split(",");
                var arrayLength = Idsn.length;
                for (var i = 0; i < arrayLength; i++) {
                    if (PartyChallanNo.trim() == Idsn[i].trim()) {
                        count = count + 1;
                    }
                }
                if (ChallanID > 0) {
                    if (count > 1) {
                        alert("Party challan number should not be duplicate");
                        elem.value = elem.defaultValue;
                    }
                }
                else if (ChallanID <= 0) {
                    if (count > 0) {
                        alert("Party challan number should not be duplicate");
                        elem.value = elem.defaultValue;
                    }
                }
            }
        }

        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        function calculateqty() {
            var conversionvalue = $('#srvgrid_ctl02_hdnconver').val();
            if (conversionvalue == "") {
                conversionvalue = 1;
            }
            var calulatedqtydefualtunit = numberWithCommas(Math.round((parseFloat($('#srvgrid_ctl02_hdnReceivedqty').val())) / (parseFloat(conversionvalue)), 0));
            alert(calulatedqtydefualtunit)
            $('[id*=lbldefualtunitreceiveQty]').text(calulatedqtydefualtunit);
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;
            else if (charCode == 13) return false;

            return true;
        }

        function SRV_Validation() {

        // new work start :girish
            var SRVQuantity = parseInt($('[id*=txtReceivedqty]').val().replace(',', ''));
            var PreviousSRVQuantity = parseInt($('[id*=hdnSrvReceivedQty]').val().replace(',', ''));


            if (SRVQuantity != PreviousSRVQuantity) {
                if (confirm("Quantity cannot be reduced Later. Please recheck the quantity.") == false) {
                    return false;
                }
            }

            // new work end :girish

            var SrvDate = $('[id*=txtSrvDate]').val();
            var PartyChallanNo = $('[id*=txtPartyChallanNo]').val();
            var GateEntryNo = $('[id*=txtGateEntryNo]').val();
            var UnitName = $('[id*=ddlunitname]').val();
            var Receivedqty = $('[id*=txtReceivedqty]').val();


            var vals = $("#srvgrid_ctl02_txtReceivedqty").val().replace(',', '');
            var PartyAmount = $('[id*=txtAmount]').val();

            if (vals == "") {
                vals = 0;
            }

            if (SrvDate == "") {
                alert("Please Enter SRV Date");
                return false;
            }

            if (PartyChallanNo == "") {
                alert("Please Enter Party Challan Number");
                return false;
            }

            if (GateEntryNo == "") {
                alert("Please Enter Gate Number");
                return false;
            }

            if (UnitName == "-1") {
                alert("Please Select Unit Name");
                return false;
            }

            if (Receivedqty == "") {
                alert("Please Enter Received Quantity");
                return false;
            }
            if (parseInt(vals) <= 0) {
                alert("SRV quantity cannot be zero or empty");
                return false;
            }

            debugger;

            //girish new work Start
            debugger;
            var BillCreate = 0;

            if ($('[id*=lnkpartybill]').length) {
                var lastRowID = $("#<%=grdbill.ClientID%> tr:last td").find(".inputBoxClass").attr('id');
                var split = lastRowID.split("txtBillDate");
                var CheckBoxId = split[0].concat("chkSelectBill");

                if (!($('#' + CheckBoxId).length) || $('#' + CheckBoxId).is(':checked')) {                    

                    var txtBillDate = split[0].concat("txtBillDate");
                    var txtBillAmount = split[0].concat("txtBillAmount");
                    var txtBillNumber = split[0].concat("txtBillNumber");

                    var PartyBillDate = $('#' + txtBillDate).val();
                    var PartyBillAmount = $('#' + txtBillAmount).val();
                    var PartyBillNo = $('#' + txtBillNumber).val();

                    $('#' + split[0].concat("hdnBillDate")).val(PartyBillDate);
                    $('#' + split[0].concat("hdnBillAmount")).val(PartyBillAmount);


                    if ($('#' + CheckBoxId).is(':checked')) {
                        if (PartyBillNo == "") {
                            alert('Please Enter Bill Number.');
                            return false;
                        }
                    }

                    if (PartyBillDate == "" && PartyBillNo != "") {
                        BillCreate = 0;
                        alert('Please fill Bill Date.');
                        return false;
                    }
                    if (PartyBillAmount == "" && PartyBillNo != "") {
                        BillCreate = 0;
                        alert('Please fill Bill Amount.');
                        return false;
                    }
                    if (PartyBillDate != "" && PartyBillAmount != "" && PartyBillNo != "") {
                        BillCreate = 1;
                    }

                    var RowId = 0;
                    var gvId;
                    var GridRow = $(".gvRow").length;
                    var check = 0;

                    if (GridRow > 0) {
                        for (var row = 1; row <= GridRow; row++) {
                            RowId = parseInt(row) + 1;
                            if (RowId < 10)
                                gvId = 'ctl0' + RowId;
                            else
                                gvId = 'ctl' + RowId;

                            var chkSelect = $("#<%= grdPartyBill.ClientID %> input[id*='" + gvId + "_chkSelect" + "']");
                            if (chkSelect.is(':checked')) {
                                check = check + 1;
                            }
                        }
                        if (PartyBillDate != "" && PartyBillAmount != "" && PartyBillNo != "") {
                            if (check == 0) {
                                alert('Please check at least one srv');
                                return false;
                            }
                        }
                    }
                    if ((check > 0) && (BillCreate == 0)) {
                        alert('Please fill bill details');
                        return false;
                    }
                }
            }
            //girish new work End
        }

        //new work start : 2023-01-27 :Girish

        var url = "../../Webservices/iKandiService.asmx";

        $(document).ready(function () {
            var date = new Date();
            var threeMonthsAgo = new Date(date.getFullYear(), date.getMonth() - 3, date.getDate());
            $('[id$=txtBillDate]').datepicker({
                minDate: threeMonthsAgo,
                maxDate:new Date(),
                dateFormat: "dd M y (D)"
            });
        });

        function PartyBillNo() {
            var x = document.getElementById("ManageBill");

            if (x.style.display === "none") {
                x.style.display = "";
            } else {
                x.style.display = "none";
            }
        }

        $(document).ready(function () {

            $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestPartyBillNo", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

            $("input[type=text].costing-style").result(function () {

                CheckPartyBillNo(this);
            });
        });

        function CheckPartyBillNo(obj) {           

            if ($(obj).attr("readonly") == "") {           

                var part = (obj).id.split("txtBillNumber");

                var Idpart = part[0];

                var SrvId = $('#lblReceivingVoucherNo').html();

                url = "../../Webservices/iKandiService.asmx";
                $.ajax({
                    type: "POST",
                    url: url + "/Get_Srv_detailsProxy",
                    data: "{ PartyBillNo:'" + $(obj).val() + "', Flag:'" + 'GETALLBILLNO' + "', SrvId:'" + SrvId + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall

                });

                function OnSuccessCall(response) {

                    var Billdate = response.d[0];
                    var PartyBillId = response.d[1];
                    var PartyAmount = response.d[2];
                    var AlertMsg = response.d[3];
                    var IsFreeze = response.d[4];

                    var BillNo = $(obj).val();

                    var txtBillDate = Idpart.concat("txtBillDate");
                    var hdnBillDate = Idpart.concat("hdnBillDate");
                    var hdnBillDateEnabledValue = Idpart.concat("hdnBillDateEnabledValue");

                    var txtBillAmount = Idpart.concat("txtBillAmount");
                    var hdnAmount = Idpart.concat("hdnAmount");

                    $('#' + txtBillDate).val(Billdate);
                    $('#' + hdnBillDate).val(Billdate);

                    $('#' + txtBillAmount).val(PartyAmount);
                    $('#' + hdnAmount).val(PartyAmount);


                    if (AlertMsg == "") {
                        if ($('#' + txtBillDate).val() != "" && IsFreeze == "True") {
                            $('#' + txtBillDate).attr('disabled', 'disabled');
                        }
                        else {
                            if (BillNo != "") {
                                $('#' + txtBillDate).attr('disabled', '');
                                $('#' + hdnBillDateEnabledValue).val('True');

                            }
                            else {
                                $('#' + txtBillDate).attr('disabled', 'disabled');
                                $('#' + hdnBillDateEnabledValue).val('False');
                            }
                        }

                        if ($('#' + txtBillAmount).val() != "" && IsFreeze == "True") {
                            $('#' + txtBillAmount).attr('disabled', 'disabled');
                        }
                        else {
                            if (BillNo != "") {
                                $('#' + txtBillAmount).attr('disabled', '');
                            }
                            else {
                                $('#' + txtBillAmount).attr('disabled', 'disabled');
                            }
                        }
                    }
                    else {
                        $('#' + Idpart.concat("txtBillNumber")).val('');
                        $('#' + txtBillDate).val('');
                        $('#' + hdnBillDateEnabledValue).val('False');
                        $('#' + txtBillAmount).val('');
                        $('#' + txtBillDate).attr('disabled', 'disabled');
                        $('#' + txtBillAmount).attr('disabled', 'disabled');
                        alert(AlertMsg);
                    }
                }
                function OnErrorCall(response) {
                    alert(response.status + " " + response.statusText);
                }
            }
        }
        //new work End : Girish
        
    </script>
    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btnSrvSubmit.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;




        function CheckForDecimal(event) {          
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                if (event.keyCode !== 8 && event.keyCode !== 46) { //exception
                    event.preventDefault();
                }
            }
            if (($(this).val().indexOf('.') != -1) && ($(this).val().substring($(this).val().indexOf('.'), $(this).val().indexOf('.').length).length > 2)) {
                if (event.keyCode !== 8 && event.keyCode !== 46) { //exception
                    event.preventDefault();
                }
            }
        }
            

        

    </script>
    <div id="spinner" class="fade-in">
    </div>
    <%--  <asp:ScriptManager  ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePannel1" runat="server">
             <ContentTemplate>--%>
    <div id="Div1" class="FabricConainer" runat="server">
        <asp:HiddenField ID="hdnpartychallanQue" runat="server" />

        <table class="toptable" style="max-width: 100%; width: 100%; border: 1px solid #999999;
            padding: 2px 5px 3px; border-bottom: 0;" cellspacing="0" cellpadding="0">
            <thead>
                <tr>
                    <td style="vertical-align: top; width: 125px;">
                        <div style="padding: 9px 0px">
                            <img src="../../images/boutique-logo.png" />
                        </div>
                    </td>
                    <td style="vertical-align: top; padding-top: 3px; border-right: 1px solid lightgray;">
                        <asp:Label ID="lblCompanyAddress" runat="server" Text=''></asp:Label>
                        <div id="divbipladdress" runat="server">
                        </div>
                    </td>
                    <td>
                        <span style="font-size: 12px; font-weight: 600; margin-left: 2px;">Fabric Store Receiving
                            Voucher</span>
                    </td>
                </tr>
            </thead>
        </table>

        <table border='1' cellpadding="5" style="border-collapse: collapse; border-right: 0;
            width: 100%;">
            <tr>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 125px; display: inline-block;">
                        Receiving Voucher No: </span>F-<asp:Label ID="lblReceivingVoucherNo" runat="server"
                            Text='<%# Eval("Receiving_Voucher_No") %>'></asp:Label>
                </td>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 90px; display: inline-block;">
                        Supplier Name:</span>
                    <asp:Label ID="lblSupllierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                </td>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 125px; display: inline-block;">
                        S.R.V. Date: </span>
                    <asp:TextBox ID="txtSrvDate" runat="server" Width="90px" CssClass="th style-eta date_style"
                        Style="margin-right: 20px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 110px; display: inline-block;">
                        Party Challan No:<span class="da_astrx_mand">*</span> </span>
                    <asp:TextBox ID="txtPartyChallanNo" onblur="CheckPartyChallan(this)" MaxLength="10"
                        runat="server" Width="90px" CssClass="alpha" Text='<%# Eval("PartyChallanNumber") %>'
                        Style="margin-right: 20px;"></asp:TextBox>
                </td>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 90px; display: inline-block;">
                        Gate Entry No:<span class="da_astrx_mand">*</span></span>
                    <asp:TextBox ID="txtGateEntryNo" MaxLength="6" onkeypress="return isNumberKey(event)"
                        runat="server" Width="90px" class="noonly numeric" Text='<%# Eval("GateNumber") %>'></asp:TextBox>
                </td>
                <td>
                    <span class="" style="font-weight: 500; color: #6b6464; width: 125px; display: inline-block;">
                        Unit Name:<span class="da_astrx_mand">*</span></span>
                    <asp:DropDownList ID="ddlunitname" runat="server" Width="83px" Style="border-color: lightgray;">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtUnitName" Visible="false" runat="server" Text='<%# Eval("ReceivedUnit") %>'></asp:TextBox>
                </td>
            </tr>
        </table>

        <asp:GridView ID="srvgrid" runat="server" CellPadding="0" ShowHeader="true" CssClass="srvtable"
            OnRowDataBound="srvgrid_RowDatabound" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="PO No.">
                    <ItemTemplate>
                        <asp:Label ID="lblPoNo" runat="server" ForeColor="black" Text='<%# Eval("PO_Number") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol1 border_left_color" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric Quality (GSM) C&C Width">
                    <ItemTemplate>
                        <asp:Label ID="lblFabricDetails" runat="server" Text='<%# Eval("SRVFabric") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Color/Print">
                    <ItemTemplate>
                        <asp:Label ID="lblColorPrint" Font-Bold="true" runat="server" Text='<%# Eval("Print") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol2" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Received Quantity">
                    <ItemTemplate>
                        <div style="float: left; width: 47%; text-align: left">
                            <asp:Label ID="lblunitconvert" ForeColor="Gray" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox ID="txtReceivedqty" onkeypress="return isNumberKey(event)" CssClass="numeric-field-without-decimal-places"
                                runat="server" MaxLength="6" onchange="TakeSRV()" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToDecimal(Eval("ReceivedQty")).ToString("N0")%>'
                                Style="width: 47%;"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hdnSrvReceivedQty" Value='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToDecimal(Eval("ReceivedQty")).ToString("N0")%>' />
                        </div>
                        <div style="float: right; width: 52%; text-align: right">
                            <asp:HiddenField ID="hdnReceivedqty" runat="server" Value='<%# Eval("ReceivedQty") %>' />
                            <asp:HiddenField ID="hdnconver" runat="server" Value='<%# Eval("ConversionValue") %>' />
                            <asp:Label ID="lbldefualtunitreceiveQty" runat="server" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToDecimal(Eval("ReceivedQty")).ToString("N0")%>'></asp:Label>
                            <asp:Label ID="lblUnit" ForeColor="Gray" Font-Bold="true" runat="server" Style="width: 40%;"
                                Text='<%# Eval("GarmentUnit") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="170px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" Text='<%# Eval("SRVRemarks") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="Rate">
                    <ItemTemplate>
                        <asp:Label ID="txtRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol3 border_right_color" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="bottomtable">
            <table id="tableActualSRV" runat="server" visible="false" width="100%" style="border-bottom: 1px solid #abaaaa;">
                <tr>
                    <td style="width: 54%;">
                    </td>
                    <td>
                        <b style="color: Gray;">Actual Received:</b>
                        <asp:Label ID="lblActualSrv" Font-Bold="true" ForeColor="gray" runat="server" Style="color: slategray;
                            font-weight: bold; width: 30%; display: inline-block; padding-left: 15px;"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        
        <span class="" runat="server" id="lnkpartybill" style="cursor: pointer; color: blue;border-left: 1px solid lightslategray; padding-left: 4px; display: inline-block;" onclick="PartyBillNo()" visible="false">Party Bill No.</span>
        <div style="display: none;" id="ManageBill">

            <asp:GridView ID="grdbill" runat="server" AutoGenerateColumns="False" Style="float: left;
                margin-right: 10px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" EnableModelValidation="True" OnRowDataBound="grdbill_RowDataBound">
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle CssClass="gvRow" ForeColor="#000066" />
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#e4e2e2"  ForeColor="#6b6464" Font-Size="11px" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnBillNumber" runat="server" Value='<%# Eval("PartyBillNo") %>'  />
                            <asp:CheckBox ID="chkSelectBill" style="width:10px;" runat="server" OnCheckedChanged="RefreshGridWithID_grdPartyBill" AutoPostBack="true" Checked='<%# Eval("Checked") %>' Visible='<%# Eval("CheckedVisibility") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                        <HeaderStyle />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bill No.<span class='da_astrx_mand'>*</span>">
                        <ItemTemplate>

                            <asp:HiddenField runat="server" ID="CheckForNewRow" Value='<%# Eval("NewRowExist") %>' />
                            <asp:TextBox ID="txtBillNumber" Text='<%# Eval("PartyBillNo") %>' runat="server"
                                MaxLength="10" Width="90%" onblur="CheckPartyBillNo(this)"  ReadOnly='<%# Eval("ReadOnly") %>'></asp:TextBox>
                            
                        </ItemTemplate>
                        <ItemStyle CssClass="BillWidth" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill Date<span class='da_astrx_mand'>*</span>">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnBillDate" runat="server" Value='<%# Eval("PartyBillDate")==""? "" : Convert.ToDateTime(Eval("PartyBillDate")).ToString("dd MMM yy (ddd)") %>' />
                            <asp:HiddenField ID="hdnBillDateEnabledValue" runat="server"  Value='<%# Eval("Enabled") %>' />

                            <asp:TextBox ID="txtBillDate" Text='<%# Eval("PartyBillDate")==""? "" : Convert.ToDateTime(Eval("PartyBillDate")).ToString("dd MMM yy (ddd)") %>'
                                runat="server" MaxLength="10" Width="95px" CssClass="inputBoxClass" Enabled='<%# Eval("Enabled") %>' ReadOnly="true"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="BillWidth" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill Amount<span class='da_astrx_mand'>*</span>">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnBillAmount" runat="server" Value='<%# Eval("Amount") %>' />
                            <asp:TextBox ID="txtBillAmount" Text='<%# Eval("Amount") %>' runat="server" Width="90%"
                                Enabled='<%# Eval("Enabled") %>' onkeypress="CheckForDecimal(event);"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="BillWidth" />
                        <HeaderStyle />
                    </asp:TemplateField>

                    
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:GridView>

            <asp:GridView ID="grdPartyBill" CssClass="PartyTable" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="grdPartyBill_RowDataBound" Style="float: left; margin-right: 10px">
                <RowStyle CssClass="gvRow" />
                <HeaderStyle BackColor="#e4e2e2" />
                <Columns>
                    <asp:TemplateField HeaderText="SRV No.">
                        <ItemTemplate>
                            F-<asp:Label ID="lblSrvNo" Text='<%# Eval("SRV_Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Challan No.">
                        <ItemTemplate>
                            <asp:Label ID="lblChallanNo" Text='<%# Eval("PartyChallanNumber") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" Checked='<%# Eval("IsChecked") %>'
                                onclick="ValidateBillNo(this)" runat="server" Enabled='<%# Eval("Enabled") %>' />                                    
                                                
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:GridView ID="grdassociatedbill" OnRowDataBound="grdassociatedbill_RowDataBound"
                CssClass="PartyTable" runat="server" AutoGenerateColumns="false">
                <RowStyle CssClass="gvRow" />
                <HeaderStyle BackColor="#e4e2e2" />
                <Columns>
                    <asp:TemplateField HeaderText="SRV No.">
                        <ItemTemplate>
                            <asp:Label ID="lblSrvNo" Text='<%# Eval("SRV_Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Challan No.">
                        <ItemTemplate>
                            <asp:Label ID="lblChallanNo" Text='<%# Eval("PartyChallanNumber") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO No.">
                        <ItemTemplate>
                            <asp:Label ID="lblponumber" Text='<%# Eval("PO_Number") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="padding_2" />
                        <HeaderStyle />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        <table id="tblpartysection" runat="server" style="max-width: 100%; width: 100%; padding: 5px;
            border: 1px solid #999999; border-top: 0px; margin-bottom: 10px;" cellspacing="0"
            cellpadding="0">
            <thead>
                <tr>
                    <td style="padding-top: 3px; padding-bottom: 16px;">
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px 0px; display: none;" id="tdPartyBill" runat="server" colspan="5">
                        <table class="PartyTable" style="float: left; margin-right: 10px; width: 288px;">
                            <tr>
                                <th style="background-color: #e4e2e2;" class="BillWidth">
                                    Bill No.<span class="da_astrx_mand">*</span>
                                </th>
                                <th style="background-color: #e4e2e2;" class="BillWidth2">
                                    Bill Date<span class="da_astrx_mand">*</span>
                                </th>
                                <th style="background-color: #e4e2e2;" class="BillWidth">
                                    Bill Amount<span class="da_astrx_mand">*</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtpartybillno" MaxLength="10" Width="90%" CssClass="costing-style alpha txtCenter"
                                        runat="server" Text="" onblur="CheckPartyBillNo(this)"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPartyBillDate" MaxLength="10" Width="95px" CssClass="do-not-allow-typing txtCenter"
                                        runat="server" disabled="disabled" Text=""></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount" Width="90%" CssClass="numeric-field-without-decimal-places txtCenter"
                                        runat="server" disabled="disabled" Text="" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </thead>
        </table>
        <div class="bottomtable">
            <table style="max-width: 100%; width: 100%; padding: 5px; border: 0px solid #999999;
                border-top: 0px; margin-bottom: 10px;" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td style="padding: 5px 0px; padding-left: 10px; width: 60%; color: #000; font-size: 12px;
                            text-align: right; padding-right: 10px;">
                            <span class=""><b>Boutique International Pvt. Ltd.</b></span>
                        </td>
                        <%--  <td class="texttranceform" style="text-align: right; padding-right: 10px;">
                        <%--<b>Qty. Checked By</b>--%>
                        <%--</td>--%>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px; padding-left: 3px; text-align: right; padding-right: 12px;"
                            class="txtColorGray">
                            <div runat="server" id="divCheckBox1">
                                <span>
                                    <asp:CheckBox Enabled="false" runat="server" Checked="false" ID="chkStoreIncharge"
                                        Style="position: relative; top: 4px; left: 5px" />
                                </span><span style="position: relative; left: 5px;">(Receive and checked)</span>
                            </div>
                            <div runat="server" id="divSignature1" visible="false" style="padding-left: 10px;">
                                <span>
                                    <asp:Image ID="imgInchargeSig" runat="server" Height="40px" Width="125px" />
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblInchargeName" runat="server" Style="line-height: 20px;"></asp:Label>
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblCheckedInchargeDate" runat="server"></asp:Label>
                                </span>
                            </div>
                        </td>

                        <%--    <td style="padding-top: 5px; text-align: right; padding-right: 10px;" class="txtColorGray">--%>
                        <%--<div runat="server" id="divCheckBox2">
                                <span>
                                    <asp:CheckBox Enabled="false" runat="server" Checked="false" ID="chkQtyCheckedBy"
                                        Style="position: relative; top: 4px; left: 5px" />
                                </span><span style="position: relative; left: 5px;">(Signature)</span>
                            </div>
                            <div runat="server" id="divSignature2" visible="false">
                                <span>
                                    <asp:Image ID="imgCheckerSig" runat="server" Height="40px" Width="110px" />
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblCheckerName" runat="server" Style="line-height: 20px;"></asp:Label>
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblCheckedDate" runat="server"></asp:Label>
                                </span>
                            </div>--%>
                        <%--    </td>--%>
                    </tr>
                </thead>
            </table>
        </div>
        <div class="form_buttom" style="width: 188px; margin: 10px auto 0px">
            <asp:Button ID="btnSrvSubmit" CssClass="btnSubmit printHideButton" OnClientClick="JavaScript:return SRV_Validation()"
                runat="server" Text="Save" OnClick="btn_SRVClivk" />
            <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close()">
                Close</div>
            <div class="btnPrint printHideButton" onclick="window.print();return false">
                Print</div>
            <%--<asp:Button ID="btnhideclick" Style="display: none" class="callback" runat="server"
                OnClick="btnhideclick_SRVClivk" />--%>
        </div>
    </div>
    <%--</ContentTemplate>
           </asp:UpdatePanel>--%>
    </form>
</body>
</html>
