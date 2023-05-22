<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryPoSrv.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryPoSrv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            overflow-x: hidden;
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
        .srvtable
        {
            border: 1px solid #999;
            border-collapse: collapse;
        }
        
        .srvtable th
        {
            padding: 2px 2px;
            background: #dddfe4;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial;
            min-width: 40px;
        }
        .srvtable td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
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
        
            /*
           code added by bharat on 21-june
           Click Print button the hide botton
         
           */
            .printHideButton
            {
                display: none;
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
            background: #dddfe4;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial;
            min-width: 50px;
        }
        .HeaderClass td
        {
            border: 1px solid #999 !important;
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
        .PartyTable tr:nth-last-child(1) > td
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
            text-transform: capitalize !important;
        }
        textarea
        {
            text-transform: lowercase;
        }
        .spanHdrColor
        {
            color: #6b6464;
        }
        
        .floatclass{float:right;
                    }
        
        
        /***********dinesh**********/
       #sb-player #ui-datepicker-div
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
    <form id="form1" autocomplete="off" runat="server">
    <script type="text/javascript">
        var SrvId = '<%=this.SrvId %>';
        var SupplierPoId = '<%=this.SupplierPoId %>';
        var Status = '<%=this.Status %>';

        var url = "../../Webservices/iKandiService.asmx";
        $(function () {
           debugger;
            $("input[type=text].accauto").autocomplete("../../Webservices/iKandiService.asmx/SuggestPartyBillNoAcc", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
            $("input[type=text].accauto").result(function () {
                $('.callback').click();
            });
            $(".datepick").datepicker({ dateFormat: 'dd M y (D)' });

            $("#txtGateEntryNo").keypress(function (e) {
                var k;
                document.all ? k = e.keyCode : k = e.which;
                return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
            });
            var SrvQty = $('#txtReceivedqty').val();
            //alert("check");
            debugger;
            if (SrvQty < 0) {

                $('#txtReceivedqty').css({ 'color': '#D59013', 'font-weight': 'bold' }
                );
            }

        });
        function CheckFabricName() {
            //debugger;
            var PartyBillNo = document.getElementById("txtPartyBillNo").value;
            if (PartyBillNo != "") {
                //$('.callback').click();

            }
        }

        function TakeSRV() {
            debugger;      
            var RecievedQty = $('#hdnReceivedqty').val();
            var SrvQty = $('#txtReceivedqty').val();
            if (SrvQty == '')
                SrvQty = 0;

            SrvQty = SrvQty.replace(',', '');

            if (SrvId > 0) {
                //if (parseInt(SrvQty) < parseInt(RecievedQty)) {
                if ((parseFloat(SrvQty) < parseFloat(RecievedQty)) &&  $("#lblCheckedDate").text() != "") {     //modified by raghvinder on 09-11-2020 
                    alert("SRV qty. cannot be less then :" + RecievedQty);
                    SrvQty = RecievedQty;
                    $('#txtReceivedqty').val(numberWithCommas(RecievedQty.toFixed(2)));
                    return;
                }
            }
            var UnitChange = $('#hdnIsUnitChange').val();
            var ConversionVal = $('#hdnConversionVal').val();

            if (UnitChange == '1') {
                //debugger;
                var defaultQty = parseFloat(SrvQty) / parseFloat(ConversionVal);
                $('#hdnDefaultRecievedQty').val(defaultQty.toFixed(2));
                var AfterDecimal = defaultQty.toString().split(".")[1];
                if (AfterDecimal == undefined) {
                    $('#lblDefaultRecievedQty').text(numberWithCommas(defaultQty));
                }
                else {
                    $('#lblDefaultRecievedQty').text(defaultQty.toFixed(2));
                }
            }

        }
        function SRV_Validation() {
            //debugger;           
            var BillCreate = 1;
            var ReceivingVoucherNo = $('[id*=txtReceivingVoucherNo]').val();
            var SrvDate = $('[id*=txtSrvDate]').val();
            var PartyChallanNo = $('[id*=txtPartyChallanNo]').val();
            var GateEntryNo = $('[id*=txtGateEntryNo]').val();
            var UnitName = $('[id*=ddlunitname]').val();
            var Receivedqty = $('[id*=txtReceivedqty]').val();
            var PartyBillNo = $('[id*=txtPartyBillNo]').val();
            var PartyBillDate = $('[id*=txtPartyBillDate]').val();
            var PartyAmount = $('[id*=txtAmount]').val();

            if (ReceivingVoucherNo == "") {
                alert("Please Enter Receiving Voucher Number");
                $('[id*=txtReceivingVoucherNo]').focus();
                return false;
            }

            if (SrvDate == "") {
                alert("Please Enter SRV Date");
                return false;
            }

            if (PartyChallanNo == "") {
                alert("Please Enter Party Challan Number");
                $('[id*=txtPartyChallanNo]').focus();
                return false;
            }

            if (GateEntryNo == "") {
                alert("Please Enter Gate Number");
                $('[id*=txtGateEntryNo]').focus();
                return false;
            }

            if (UnitName == "-1") {
                alert("Please Select Unit Name");
                $('[id*=ddlunitname]').focus();
                return false;
            }

            if (Receivedqty == "") {
                alert("Please Enter Received Quantity");
                $('[id*=txtReceivedqty]').focus();
                return false;
            }

            if (confirm("Quantity cannot be reduced later. Recheck the quantity.") == false) {
                return false;
            }

            if (PartyBillNo == "") {
                BillCreate = 0;
            }
            if (PartyBillDate == "") {
                BillCreate = 0;
            }
            if (PartyBillDate == "") {
                BillCreate = 0;
            }
            var srvid = '<%=this.SrvId %>';
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;
            var check = 0;
            if (srvid != "0") {
                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var chkSelect = $("#<%= grdPartyBill.ClientID %> input[id*='" + gvId + "_chkSelect" + "']");

                    if (chkSelect.is(':checked')) {
                        check = 1;
                    }
                }
                if ((BillCreate == 1) && (check == 0)) {
                    alert('Please check at least one srv');
                    return false;
                }
                else if ((check == 1) && (BillCreate == 0)) {
                    alert('Please fill bill details');
                    return false;
                }
            }

        }

        function ValidateBillNo(obj) {
            var PartyBillNo = $('[id*=txtPartyBillNo]').val();
            var PartyBillDate = $('[id*=txtPartyBillDate]').val();
            var PartyAmount = $('[id*=txtAmount]').val();

            if ($(obj).is(':checked')) {

                if (PartyBillNo == "") {
                    alert("Please Enter Party Bill Number");
                    $(obj).removeAttr("checked");
                    return false;
                }
                if (PartyBillDate == "") {
                    alert("Please Enter Party Bill Date");
                    $(obj).removeAttr("checked");
                    return false;
                }
                if (PartyAmount == "") {
                    alert("Please Enter Party Amount");
                    $(obj).removeAttr("checked");
                    return false;
                }
            }

        }


        function closePage() {
            alert('Saved Successfully!');

            self.parent.parent.PageReload();
            self.parent.Shadowbox.close();
        }

        function PartyBillNo() {

            var x = document.getElementById("tdPartyBill")

            if (x.style.display === "none") {
                x.style.display = "";
            } else {
                x.style.display = "none";
            }
        }

        function disablePage() {
            //debugger;
            $("#<%=Div1.ClientID%> input[type='text']").attr("disabled", true);
            $("#<%=Div1.ClientID%> select").attr("disabled", true);
            $("#txtRemark").attr("disabled", true);
            //debugger;
            if (parseInt(Status) <= 2) {
                $("#tdPartyBill input[type='text']").removeAttr('disabled');
                $("#tdPartyBill input[type='checkbox']").removeAttr('disabled');
                $("#btnSrvSubmit").removeAttr('disabled');
            }
        }

        function CheckChallanNumber() {
            //debugger;       
            var PartyChallanNo = $('[id*=txtPartyChallanNo]').val();

            if (PartyChallanNo != "") {
                proxy.invoke("CheckChallanNumber", { SupplierPoId: SupplierPoId, SRV_Id: SrvId, PartyChallanNumber: PartyChallanNo },
                    function (result) {
                        //debugger;
                        if (result == 'NOTVALID') {
                            alert("Party challan number should not be duplicate");
                            $('[id*=txtPartyChallanNo]').val("");
                        }
                    });
            }
        }

        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        $('#ui-datepicker-div').hide()
      
    </script>
    <div>
        <div id="Div1" class="FabricConainer" runat="server">
            <table class="toptable" style="max-width: 100%; width: 100%; border: 1px solid #999999;padding: 2px 5px 3px;border-bottom:0;" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td style="vertical-align: top; width: 125px;">
                            <div style="padding: 9px 7px">
                                <img src="../../images/boutique-logo.png" />
                            </div>
                        </td>
                        <td style="vertical-align: top; padding-top: 3px;border-right: 1px solid lightgray;">
                            <asp:Label ID="lblCompanyAddress" Style='display: none;' runat="server" Text=''></asp:Label>
                            <div id="divbipladdress" runat="server">
                            </div>
                        </td>
                        <td style="text-align: center;">
                            <span style="font-size: 12px; font-weight: 600;margin-left: 2px;">Accessory <br />Store Receiving Voucher</span>
                        </td>
                    </tr>

                </thead>
            </table>
           <table border='1' cellpadding="5" style="border-collapse: collapse;border-right:0;width:100%;">
            <tr>
                <td>
                 <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 120px;display: inline-block;">Receiving Voucher No:</span>
                 A-<asp:Label ID="lblReivingVoucherNo" runat="server" Text=""></asp:Label>
                </td>

                <td>
                    <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 75px;display: inline-block;">S.R.V. Date: </span>
                    <asp:TextBox ID="txtSrvDate" runat="server" Width="90px" CssClass="th style-eta date_style"></asp:TextBox>
                </td>
                <td>
                    <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 85px;display: inline-block;">Supplier Name:</span>
                    <asp:Label ID="lblSupllierName" runat="server" Text="" Width="270" CssClass="floatclass"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                   <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 125px;display: inline-block;">Party Challan No:<span class="da_astrx_mand">*</span></span>
                    <asp:TextBox ID="txtPartyChallanNo" Width="90px" MaxLength="10" onblur="CheckChallanNumber()" runat="server" CssClass="alpha" Text=""></asp:TextBox>  
                </td>
                <td>
                   <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 125px;display: inline-block;">Gate Entry No:<span class="da_astrx_mand">*</span></span>
                   <asp:TextBox ID="txtGateEntryNo" MaxLength="6" runat="server" Width="90px" CssClass="numeric-field-without-decimal-places" Text=""></asp:TextBox>
                </td>

                <td>

                         <span class="spanHdrColor" style="font-weight: 500;color: #6b6464;width: 125px;display: inline-block;">Unit Name:<span class="da_astrx_mand">*</span></span>
                            <asp:DropDownList ID="ddlunitname" runat="server" Width="83px" style="border-color: lightgray;">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnReceivingVoucherNo" runat="server" />
                            <asp:HiddenField ID="hdnSrvDate" runat="server" />
                            <asp:HiddenField ID="hdnPartyChallanNo" runat="server" />
                            <asp:HiddenField ID="hdnGateNo" runat="server" />
                            <asp:HiddenField ID="hdnRecievedUnit" runat="server" />
                            <asp:HiddenField ID="hdnRemart" runat="server" />
                            <asp:HiddenField ID="hdnRate" runat="server" />
                            <asp:HiddenField ID="hdnIsFourPointCheckedByGM" Value="0" runat="server" />
             </td>
            </tr>
            </table>

            <table border="0" cellpadding="0" cellspacing="0" class="srvtable" style="margin-bottom: 10px">
                <tr>
                    <th style="width: 75px;">
                        PO No.
                    </th>
                    <th style="width: 230px;">
                        Accessory Quality (Size)/Color Print
                    </th>
                    <th style="min-width: 190px;">
                        Received Quantity
                    </th>
                    <th>
                        Remark
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPoNo" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAccessDetails" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <div style="float: left; width: 90px;">
                            <asp:Label ID="lblUnit" runat="server" Style="width: 45px; color: Gray; font-weight: 600" Text=""></asp:Label>
                            <asp:TextBox ID="txtReceivedqty" onchange="TakeSRV()"  runat="server" MaxLength="8" Style="width: 45px;" Text=""></asp:TextBox>
                            <asp:HiddenField ID="hdnReceivedqty" runat="server" />
                            <asp:HiddenField ID="hdnIsUnitChange" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnConversionVal" Value="0" runat="server" />
                        </div>
                        <div style="float: right; width: 90px; text-align: right;">
                            <asp:Label ID="lblDefaultRecievedQty" Style="margin-left: 1px;" ForeColor="gray" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnDefaultRecievedQty" Value="0" runat="server" />
                            <asp:Label ID="lblDefaultUnit" Font-Bold="true" ForeColor="gray" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" Width="99%" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr id="trActualSRV" runat="server" visible="false">
                    <td colspan="2">
                    </td>
                  
                    <td style="text-align:left;">
                            <b style="margin-right:2px;color:Gray;">Actual Received:</b>
                            <asp:Label ID="lblActualSrv" Font-Bold="true" ForeColor="slategray" runat="server"></asp:Label>
                    </td>
           
                </tr>
            </table>
            <div class="bottomtable">
                <table id="tblpartysection" runat="server" style="border: 1px solid darkgray;width: 100%;border-top: 0px;margin-bottom: 10px;" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td style="padding: 3px 0 16px 3px;">
                                <span class="address_head  texttranceform" runat="server" id="lnkpartybill" style="padding-top: 10px; cursor: pointer; color: blue" onclick="PartyBillNo()">Party Bill No:</span>
                                <asp:Label ID="lblPartyBillNo" Style="text-transform: uppercase;" runat="server"></asp:Label>
                            </td>
                            <td style="padding-top: 3px; padding-bottom: 16px;">
                                <span style="color: #6b6464;">Bill Date:</span>
                                <asp:Label ID="lblBillDate" runat="server"></asp:Label>
                            </td>
                            <td colspan="2" style="padding-bottom: 16px; padding-left: 3px;">
                                <span class="address_head  texttranceform" style="padding-top: 10px; color: #6b6464;">Amount:</span>
                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 10px 0px; display: none;" id="tdPartyBill" runat="server" colspan="5">
                                <table class="PartyTable" style="float: left; margin-right: 10px; width: 288px;">
                                    <tr>
                                        <th class="BillWidth">
                                            Bill No.<span class="da_astrx_mand">*</span>
                                        </th>
                                        <th class="BillWidth2">
                                            Bill Date<span class="da_astrx_mand">*</span>
                                        </th>
                                        <th style="width: 70px">
                                            Bill Amount<span class="da_astrx_mand">*</span>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnPartyBillId" runat="server" />
                                            <asp:TextBox ID="txtPartyBillNo" MaxLength="10" onblur="CheckFabricName()" CssClass="alpha txtCenter accauto" runat="server" Text=""></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPartyBillDate" MaxLength="10" Width="85px" CssClass="datepick do-not-allow-typing txtCenter" runat="server" Text=""></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAmount" CssClass="numeric-field-without-decimal-places txtCenter" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdPartyBill" CssClass="PartyTable" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdPartyBill_RowDataBound" Style="float: left; margin-right: 10px;">
                                    <RowStyle CssClass="gvRow" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SRV No.">
                                            <ItemTemplate>
                                                A-<asp:Label ID="lblSrvNo" Text='<%# Eval("SRV_Id") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="padding_2" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Challan No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallanNo" Style="text-transform: capitalize;" Text='<%# Eval("PartyChallanNumber") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="padding_2" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" Checked='<%# Eval("IsChecked") %>' onclick="ValidateBillNo(this)" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="padding_2" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:GridView ID="grdassociatedbill" OnRowDataBound="grdassociatedbill_RowDataBound" CssClass="PartyTable" runat="server" AutoGenerateColumns="false">
                                    <RowStyle CssClass="gvRow" />
                                    <HeaderStyle BackColor="#dddfe4" />
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
                                                <asp:Label ID="lblChallanNo" Style="text-transform: capitalize;" Text='<%# Eval("PartyChallanNumber") %>' runat="server"></asp:Label>
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
                            </td>
                        </tr>
                    </thead>
                </table>
                <table style="max-width: 100%; width: 100%; padding: 5px; border: 0px; border-top: 0px; margin-bottom: 10px;" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="texttranceform" colspan="2" style="text-align: right; padding-right: 10px; font-size: 11px">
                            <b>Receive and checked</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="texttranceform" colspan="2" style="text-align: right; padding-right: 10px; color: #6b6464">
                            <div runat="server" id="divCheckBox2">
                                <span>
                                    <asp:CheckBox runat="server" Checked="false" ID="chkQtyCheckedBy" Style="position: relative; top: 4px; left: 5px" />
                                </span><span style="position: relative; left: 5px;">(Signature)</span>
                            </div>
                            <div runat="server" id="divSignature2" visible="false">
                                <asp:Image ID="imgCheckerSig" runat="server" Height="40px" Width="113px" />
                                <br />
                                <asp:Label ID="lblCheckerName" runat="server" Style="line-height: 20px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblCheckedDate" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="form_buttom" style="width: 200px; margin: 10px auto;">
                <asp:Button ID="btnSrvSubmit" CssClass="btnSubmit" OnClientClick="JavaScript:return SRV_Validation()" runat="server" Text="Save" OnClick="btnSrvSubmit_Click" />
                <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                    Close</div>
                <div class="btnPrint printHideButton" onclick="window.print();return false">
                    Print</div>
                <asp:Button ID="btnhideclick" Style="display: none" class="callback" runat="server" OnClick="btnhideclick_SRVClivk" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
