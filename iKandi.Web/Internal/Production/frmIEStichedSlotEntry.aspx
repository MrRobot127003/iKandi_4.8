<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="frmIEStichedSlotEntry.aspx.cs" Inherits="iKandi.Web.Internal.Production.frmIEStichedSlotEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        .border2 th
        {
            padding: 5px 0px !important;
            font-size: 11px !important;
        }
        .slot-table td
        {
            padding: 5px 0px !important;
        }
        thead th
        {
            font-weight: bold !important;
        }
        iframe
        {
            background: #fff !important;
            padding: 5px;
        }
        .secure_center_contentWrapper
        {
            font-family: Helvetica !important;
        }
        .item_list th
        {
            font-family: Helvetica !important;
        }
        .submit-hide
        {
            display: none;
        }
        .trrptlengh table td
        {
            padding:2px 1px;
        }
        .trrptlengh td
        {
            padding:2px 0px;
        }
        .repadd input
        {
            padding:0px;
            margin:5px 0px;
        }
        .disp-none
        {
            display:none;
        }
        .scroll-table
        {
             height: calc(100% - 246px);
        }
        .QClink
        {
            color:Green !important;
            font-weight:bold;
            font-size:10px !important;
        }
        .QClinkBlue
        {
            color:blue !important;
            font-weight:bold;
            font-size:10px !important;
        }
        .QClinkyellow
        {
            color:#ec750a !important;
            font-weight:bold;
            font-size:10px !important;
        }
        .QClinkgreen
        {
            color:Green !important;
            font-weight:bold;
            font-size:10px !important;
        }
       .scroll-table select 
        {
            width:95%;
            text-transform:capitalize;
        }
        span
        {
         margin:2px 0px;
        }
        input[type="text"]
        {
         margin:3px 0px;
        }
        SELECT 
            {
                height:20px;
             }
             .error {
    border: 1px solid #c00;
} 
    </style>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script language="javascript" type="text/javascript">
        var elamget = "";
        var hdnSlotCloseClientID = '<%=hdnSlotClose.ClientID %>';
        var btnSubmitClientID = '<%=btnSubmit.ClientID %>';
        var btnSubmit1ClientID = '<%=btnSubmit1.ClientID %>';
        var orderIDs;
        function validateSlotpass(elem) {
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);
            var cIdline = Ids.split("_")[5];
            var Qclineman = $("#ctl00_cph_main_content_gvIEStitchedSlot_" + cIdline + "_ddllQclineMan option:selected").text();
            if (Qclineman == 'Select') {
                if ($("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val() != "") {
                   $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');                    
                    alert('Please select Roaming QC');
                    return false;
                }
            }
            else {
                $("#ctl00_cph_main_content_gvIEStitchedSlot_" + cIdline + "_ddllQclineMan").removeClass("error")
            }            
        }
        function ValidateStitchEntry(elem) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);
            var cIdline = Ids.split("_")[5];
                   
            var Qclineman = $("#ctl00_cph_main_content_gvIEStitchedSlot_" + cIdline + "_ddllQclineMan option:selected").text();
            if (Qclineman == 'Select') {
                if ($("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val() != "") {
                    
                    $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');
                    $("#ctl00_cph_main_content_gvIEStitchedSlot_" + cIdline + "_ddllQclineMan").addClass("error");
                    alert('Please select Roaming QC');
                    return false;
                }
            }
            else {
                $("#ctl00_cph_main_content_gvIEStitchedSlot_" + cIdline + "_ddllQclineMan").removeClass("error")
            }
            
            var EntryStitchQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val();
            var StitchBalance = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnStitchBalance" + "']").val();
            var SlotOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txlActualOB" + "']").val();
            var TargetQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnTargetQty" + "']").val();
            var SlotId = '<%=this.SlotId %>';
            var SlotDate = '<%=this.StartDate %>';
            var StyleId = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnStyleId" + "']").val();
            var SerialNo = $("#<%= gvIEStitchedSlot.ClientID %> span[id*='ctl" + cId + "_lblSerialNumber" + "']").text();
            var LineNo = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineNo" + "']").val();
            var LinePlanningId = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLinePlanningId" + "']").val();
            var OrderDetailsID = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailId" + "']").val();

            if (EntryStitchQty != '') {
                if (SlotOB != '') {
                    if (StitchBalance == '') {
                        StitchBalance = 0;
                    }
                    if (parseInt(EntryStitchQty) > parseInt(StitchBalance)) {
                        alert('Stitch Qty can not be greater than Cut Rdy qty');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');
                        return false;
                    }
                    else {
                        var LineStitchBalance = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineStitchBalance" + "']").val();
                        if (LineStitchBalance != '') {
                            LineStitchBalance = parseInt(LineStitchBalance) - parseInt(EntryStitchQty)
                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtBalanceLineStichedQty" + "']").val(LineStitchBalance);
                        }
                    }
                    if (parseInt(SlotId) > 1) {
                        if ((TargetQty != '0') && (TargetQty != '')) {
                            var Achievement = Math.round((parseInt(EntryStitchQty) / parseInt(TargetQty)) * 100)
                            if (Achievement < 85) {
                                var sURL = "StitchingBottleNeck.aspx?SlotId=" + SlotId + "&StyleId=" + StyleId + "&LineNo=" + LineNo + "&SerialNo=" + SerialNo + "&OrderDetailId=" + OrderDetailsID + "&LinePlanningId=" + LinePlanningId + "&SlotDate=" + SlotDate;
                                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                                Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 655, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                                return false;
                            }
                        }
                    }
                }
                else {
                    alert('Act.OB W/S can not be empty');
                    $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');
                    return false;
                }
            }
            else {
                var LineStitchBalance = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineStitchBalance" + "']").val();
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtBalanceLineStichedQty" + "']").val(LineStitchBalance);
            }
        }

        function OpenBottleNeck(elem) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);

            var SlotId = '<%=this.SlotId %>';
            var SlotDate = '<%=this.StartDate %>';
            var StyleId = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnStyleId" + "']").val();
            var SerialNo = $("#<%= gvIEStitchedSlot.ClientID %> span[id*='ctl" + cId + "_lblSerialNumber" + "']").text();
            var LineNo = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineNo" + "']").val();
            var LinePlanningId = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLinePlanningId" + "']").val();
            var OrderDetailsID = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailId" + "']").val();

            var sURL = "StitchingBottleNeck.aspx?SlotId=" + SlotId + "&StyleId=" + StyleId + "&LineNo=" + LineNo + "&SerialNo=" + SerialNo + "&OrderDetailId=" + OrderDetailsID + "&LinePlanningId=" + LinePlanningId + "&SlotDate=" + SlotDate;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 655, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function OpenQCPopup(elem, type) {
            debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);

            var rptcId = Ids.split("_")[7];
            var UnitID = '<%=this.ProductionUnit %>';
            var ClusterId = 0;
            var SlotId = '<%=this.SlotId %>';
            var SlotDate = '<%=this.StartDate %>';
            var SerialNo;
            var LineNo;
            var LinePlanningId;
            var OrderDetailsID;

            if (type == 'Cluster') {
                var Currentlen = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_ctl" + cId + "_clusterCount").innerHTML;
                if (Currentlen != '') {
                    ClusterId = Currentlen.replace("Cluster ", "");
                }
                SerialNo = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_ctl" + cId + "_rptcluster_" + rptcId + "_txtSerialNumber").value;
                //LineNo = 0;
                LineNo = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_ctl" + cId + "_CLusterName").innerHTML;
                LinePlanningId = 0;
                OrderDetailsID = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_ctl" + cId + "_rptcluster_" + rptcId + "_hdnOrderDetailsID").value
            }

            else {
                SerialNo = $("#<%= gvIEStitchedSlot.ClientID %> span[id*='ctl" + cId + "_lblSerialNumber" + "']").text();
                LineNo = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineNo" + "']").val();
                LinePlanningId = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLinePlanningId" + "']").val();
                OrderDetailsID = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailId" + "']").val();
            }

            var sURL = "StitchingQC.aspx?SlotId=" + SlotId + "&LineNo=" + LineNo + "&SerialNo=" + SerialNo + "&OrderDetailId=" + OrderDetailsID + "&LinePlanningId=" + LinePlanningId + "&SlotDate=" + SlotDate + "&ClusterId=" + ClusterId + "&UnitID=" + UnitID;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 550, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function ValidateAltEntry(elem) {
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);

            var EntryAltQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotAlt" + "']").val();
            var TotalAltQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnAltPcsTotal" + "']").val();
            if (EntryAltQty != '') {
                if (TotalAltQty == '') {
                    TotalAltQty = 0;
                }
                var TotalAltQty = (parseInt(TotalAltQty) + parseInt(EntryAltQty));
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtAltPcsTotal" + "']").val(TotalAltQty);
            }
            else {
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtAltPcsTotal" + "']").val(TotalAltQty);
            }
        }

        function ValidateFinish_OBEntry(elem, type) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);
            var ActualFinishOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActualFinishOB" + "']").val();
            var ActTCOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActTCOB" + "']").val();
            var ActPressOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActPressOB" + "']").val();
            if (ActTCOB == '')
                ActTCOB = 0;
            if (ActPressOB == '')
                ActPressOB = 0;
            if (ActualFinishOB != '') {
                if (type == 'TCOB') {
                    if ((parseInt(ActTCOB) + parseInt(ActPressOB)) > parseInt(ActualFinishOB)) {
                        alert('Sum of Act. TC OB and Act. Press OB can not be greater than Act. Total OB');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActTCOB" + "']").val('');
                        return false;
                    }
                }
                if (type == 'PressOB') {
                    if ((parseInt(ActTCOB) + parseInt(ActPressOB)) > parseInt(ActualFinishOB)) {
                        alert('Sum of Act. TC OB and Act. Press OB can not be greater than Act. Total OB');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActPressOB" + "']").val('');
                        return false;
                    }
                }
            }
            else {
                alert('First of all fill Act. Total OB!');
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActTCOB" + "']").val('');
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActPressOB" + "']").val('');
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActualFinishOB" + "']").focus();
                return false;
            }
        }


        function ValidateFinishEntry(elem) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);

            var EntryFinishQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val();
            //var LineFinishedQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineFinishedQty" + "']").val();
            var OrderFinishQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderFinishedQty" + "']").val();
            //var LineStitchedQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnLineStitchedQty" + "']").val();
            var OrderStitchQty = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderStichedQty" + "']").val();
            var hdnToBeFinish = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnToBeFinish" + "']").val();
            var SlotOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActualFinishOB" + "']").val();
            var OrderDetailsID = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailId" + "']").val();
            var UnitID = '<%=this.ProductionUnit %>';
            if (EntryFinishQty != '') {
                if (SlotOB != '') {
                    if (OrderFinishQty == '') {
                        OrderFinishQty = 0;
                    }
                    if (OrderStitchQty == '') {
                        OrderStitchQty = 0;
                    }
                    OrderFinishQty = (parseInt(OrderFinishQty) + parseInt(EntryFinishQty));

                    if (parseInt(OrderFinishQty) > parseInt(OrderStitchQty)) {
                        alert('Finish Qty can not be greater than Stitch qty');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                        if (hdnToBeFinish != '0') {
                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(hdnToBeFinish);
                        }
                        return false;
                    }
                    else {
                        if (hdnToBeFinish != '0') {
                            var ToBeFinish = parseInt(hdnToBeFinish) - parseInt(EntryFinishQty)
                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(ToBeFinish);
                        }
                        else {
                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                            return false;
                        }
                    }
                    //UpdateFinishBal(EntryFinishQty, OrderDetailsID, UnitID) 
                }
                else {
                    alert('Act.Total OB W/S can not be 0 or empty');
                    $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                    return false;
                }
            }
            else {
                if (hdnToBeFinish != '0') {
                    $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(hdnToBeFinish);
                }
            }

        }


        function CheckSlotClose(obj) {
            debugger; 
            $("#" + btnSubmitClientID).addClass("submit-hide");
            $("#" + btnSubmit1ClientID).addClass("submit-hide");

            var TotalSlotPassAlt = 0;
            var CheckSlotClose = 1;
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvIEStitchedSlotRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var SlotPass = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtSlotPass" + "']").val();
                var SlotAlt = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtSlotAlt" + "']").val();
                var SlotOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txlActualOB" + "']").val();
                var SlotOBBorder = "#<%= gvIEStitchedSlot.ClientID %>_" + gvId + "_txlActualOB";
                var FinishSlotPass = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtSlotPassFinish" + "']").val();

                //-------------add By Prabhaker----------------//
                //debugger;
                var chkRequiredActualOB = "#<%= gvIEStitchedSlot.ClientID %>_" + gvId + "_chkRequiredActualOB";

                // alert(chkRequiredActualOB);

                if ($(chkRequiredActualOB).is(':checked') && SlotOB == "") {
                    $(SlotOBBorder).css('border-color', 'red');
                    $("#" + btnSubmitClientID).removeClass("submit-hide");
                    $("#" + btnSubmit1ClientID).removeClass("submit-hide");
                    alert("Please Enter Act OB/WS")
                    return false;
                }
                else {
                    $(SlotOBBorder).css('border-color', '#cccccc');
                }

                //-----------End Of Code-------------------//


                if (SlotPass == '')
                    SlotPass = 0;
                if (SlotAlt == '')
                    SlotAlt = 0;
                //                if (SlotOB == '')
                //                    SlotOB = 0;
                if (FinishSlotPass == '')
                    FinishSlotPass = 0;
                var SlotPassAlt = parseInt(SlotPass) + parseInt(SlotAlt);
                //               if (SlotPassAlt == 0) {
                //                   CheckSlotClose = 1;
                //               }
                if (SlotPassAlt != 0) {
                    if (SlotOB == '') {
                        alert('Act.OB W/S can not be empty');
                        $("#" + btnSubmitClientID).removeClass("submit-hide");
                        $("#" + btnSubmit1ClientID).removeClass("submit-hide");
                        return false;
                    }
                }

                var PeakCapecity = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtPeakCapecity" + "']").val();
                var PeakOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtPeakOB" + "']").val();
                if (PeakCapecity != '') {
                    if (PeakOB == '') {
                        alert('Peak OB can not be empty if Capecity fill');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtPeakOB" + "']").focus();
                        $("#" + btnSubmitClientID).removeClass("submit-hide");
                        $("#" + btnSubmit1ClientID).removeClass("submit-hide");
                        return false;
                    }
                }
                if (PeakOB != '') {
                    if (PeakCapecity == '') {
                        alert('Peak Capecity can not be empty if Peak OB fill');
                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='" + gvId + "_txtPeakCapecity" + "']").focus();
                        $("#" + btnSubmitClientID).removeClass("submit-hide");
                        $("#" + btnSubmit1ClientID).removeClass("submit-hide");
                        return false;
                    }
                }
            }
            if (CheckSlotClose == 1) {
                //debugger;
                if (confirm("Do you want to close the task for this slot ?\n If total packing entry is beyond stitching than cluster entry may not save !") == true) {
                    //debugger;
                    $("#" + hdnSlotCloseClientID).val(1);
                }
            }
        }


        function SBClose() { }


        function StitchNilClick(cb) {
            //debugger;
            var Ids = cb.id;
            var cId = Ids.split("_")[5].substr(3);
            var ActualOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txlActualOB" + "']").val();
            var res = Ids.replace("chkpass", "txtSlotPass");
            if (cb.checked) {
                if (ActualOB != '') {
                    $('#' + res).attr('readonly', true);
                    $('#' + res).val("");
                    document.getElementById("hdnZeroProductvity").value = "1";
                }
                else {
                    alert('Act.OB W/S can not be empty');
                    cb.checked = false;
                    return false;
                }
            }
            else {
                $('#' + res).attr('readonly', false);
            }
        }

        function FinishNilClick(cb) {
            //debugger;
            var Ids = cb.id;
            var cId = Ids.split("_")[5].substr(3);
            var ActualOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActualFinishOB" + "']").val();
            var res = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']");
            if (cb.checked) {
                if (ActualOB != '') {
                    res.val('');
                    res.attr('readonly', true);
                    //                    $('#' + res).val("");                    
                }
                else {
                    alert('Act.Total OB W/S can not be 0 or empty');
                    cb.checked = false;
                    return false;
                }
            }
            else {
                res.attr('readonly', false);
            }
        }
    
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            ShowImagePreview();

            $(".scroll-table").height($(window).height() - 270);

        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            xOffset = -20;
            yOffset = 40;
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:350px !important; width:320px !important;'/>" + c + "</p>");
                $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $("a.preview").mousemove(function (e) {
                $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
            });
        };



        //        function openShipedPopu(OrderDetailsID, ProductionUnit, LinePlanID) {

        //            debugger;
        //            window.open("IEStichedSlotEntryFaultPopUp.aspx?OrderDetailID=" + OrderDetailsID + "&ProductionUnit=" + ProductionUnit + "&hdnLinePlanningId=" + LinePlanID + "&Flag=" + "linkopen", "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=no,resizable=0,width=1000,height=400");
        //            return false;


        //        }
        //added by abhishek on 15/11/2016
        function openShipedPopu(OrderDetailsID, ProductionUnit, LinePlanID, checkID, startDate) {
            var sURL = "IEStichedSlotEntryFaultPopUp.aspx?OrderDetailID=" + OrderDetailsID + "&ProductionUnit=" + ProductionUnit + "&hdnLinePlanningId=" + LinePlanID + "&Flag=" + "linkopen" + "&ID=" + checkID + "&startdate=" + startDate;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 635, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }
        function Showmgs() {
            // alert("Popup could not open because alt sum is 0");
            //            var Ids = ID;
            //            var cId = Ids.split("_")[5].substr(3);                     
            //            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_chkMarkAsDayClose" + "']").attr('checked', false);

        }
        function Uncheckbox(Flag, ID) {

            var Ids = ID;
            var cId = Ids.split("_")[5].substr(3);

            window.parent.Shadowbox.close();

            if (Flag == 'YES') {
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_chkMarkAsDayClose" + "']").attr('checked', true);
            }
            else {
                $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_chkMarkAsDayClose" + "']").attr('checked', false);
            }

        }
        //end

        /*------------------Abhishek code part start---------------*/
        $(function () {
            initializer();
        });
        var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
        prmInstance.add_endRequest(function () {
            //you need to re-bind your jquery events here
            initializer();
        });

        function initializer() {
            // debugger;//serial numnber will be unit wise
            jQuery("input.clusterStyleNumber", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesClusterForUnit", { dataType: "xml", datakey: "string", max: 100 });
            jQuery("input.clusterStyleNumber", "#main_content").result(function () {
                //debugger
                //alert('xyz');
                var p = $(this).val().split('-');
                var This = $(this);
                var StyleNumber = $(this).val();
                var ControlID = $(this).attr('id');
                var Ids = ControlID;
                var RowID = Ids.split("_")[5];
                var cId = Ids.split("_")[7];

                FinalID = "ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtstylenumber";
                ExactControlID = "ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_ddlPrintColorQuantity";

                populateSerialNumber(StyleNumber, FinalID, RowID, cId, ExactControlID);
                // bindDropdown(serviceUrl, ExactControlID, "GetPrintColorQty", { OrderID: -1 }, "PrintColorQty", "OrderDetailsID", true, '', onPageError)
                BindPrintColorQty(StyleNumber, ExactControlID, RowID, cId);


            });
        };

        function populateSerialNumber(StyleNumber, FinalID, RowID, cId, ExactControlID) {
            // debugger;
            var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
            var proxy = new ServiceProxy(serviceUrl);

            //  bindDropdown(serviceUrl, groupDDClientID, "GetSerialNumber", { StyleNumber: SerialNumber }, "SerialNumber", "OrderID", true, '', onPageError)

            proxy.invoke("GetSerialNumber", { StyleNumber: StyleNumber }, function (result) {
                document.getElementById(FinalID).value = result[0].SerialNumber;
            }, onPageError, false, false);

        }
        //int flag, string serialNumber = ""
        function BindPrintColorQty(StyleNumber, ExactControlID, RowID, cId) {
            // debugger;
            var OrderID;
            proxy.invoke("getUsp_GetOderID", { flag: 'ORDERID', StyleNumber: StyleNumber }, function (result) {
                OrderID = result[0].OrderID;
                //alert(OrderID);

                if (OrderID != "") {
                    ExactControlID = "ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_ddlPrintColorQuantity";
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnserialNo").value = OrderID;
                    bindDropdown(serviceUrl, ExactControlID, "GetPrintColorQty", { OrderID: OrderID }, "PrintColorQty", "OrderDetailsID", true, '', onPageError)

                }

            }, onPageError, false, false);

        }

        function jsFunctions(sel) {
            //alert('s');
            //  debugger;
            var OrderDetailsID = sel.options[sel.selectedIndex].value;
            var This = $(this);
            var ControlID = sel.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var cId = Ids.split("_")[7];


            var GridRow = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdncount").value;
            for (var row = 0; row < GridRow; row++) {

                if (row < 10)
                    isID = 'ctl0' + row;
                else
                    isID = 'ctl' + row;



                var e = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + isID + "_ddlPrintColorQuantity");

                if (e.length != 0) {
                    var OderDetailsIDs = e.options[e.selectedIndex].value;
                    //alert(e.selectedIndex);
                    if (OderDetailsIDs != '-1') {

                        if (cId != isID)
                            if (OderDetailsIDs == OrderDetailsID) {


                                alert("Selected contract order already taken please choose another");
                                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_ddlPrintColorQuantity").value = "-1";
                                return row;
                            }
                    }
                }
            }

            document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnprintColorqty").value = OrderDetailsID;
            OrderID = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnprintColorqty").value
            var UnitID = '<%=this.ProductionUnit %>';
            proxy.invoke("Getfinishingsam", { OrderdetailsID: OrderDetailsID, OrderID: 0, UnitID: UnitID, Flag: 'FINSHINGOB' }, function (result) {

                var a = 0;
                var b = 0;
                var p = "";

                p = result.split('_');
                a = p[0];
                b = p[1];
                //alert(a+'_'+b)
                if (a <= 0) {

                    a = '';
                }
                if (b <= 0) {
                    b = '';
                }

                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_lblFinishOB").innerHTML = a;
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_lblLinePlanning_FinishSAM").innerHTML = b;

            }, onPageError, false, false);


            //debugger;
            proxy.invoke("Getfinishingsam", { OrderdetailsID: OrderDetailsID, OrderID: 0, UnitID: UnitID, Flag: 'FINSHINGQTY' }, function (result) {
                //debugger;
                var px = "";
                px = result.split('_');
                var x = px[0];
                var y = px[1];

                if (x <= 0) {

                    x = '';
                }
                if (y <= 0) {
                    y = '';
                }
                //alert(x + '_' + y)

                //debugger;
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_lblLineStitchQty").innerHTML = x;
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").innerHTML = y;
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnToBeFinish").value = y;
                //alert(document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnToBeFinish").value);


            }, onPageError, false, false);
        }

        function ValidateFinish_OBEntry_Cluster(elem, type) {
            //debugger;
            var ControlID = elem.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var cId = Ids.split("_")[7];

            var ActualFinishOB = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActualFinishOB").value;
            var ActTCOB = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActTCOB").value;
            var ActPressOB = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActPressOB").value;
            var hdnToBeFinish = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnToBeFinish").value;
            var PreviousPassVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnpassvalue").value;
            var SlotPassFinshVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value;
            if (hdnToBeFinish == '') {
                hdnToBeFinish = 0;
            }
            //debugger;;
            if (ActTCOB == '')
                ActTCOB = 0;
            if (ActPressOB == '')
                ActPressOB = 0;
            if (ActualFinishOB != '') {
                if (type == 'TCOB') {
                    if ((parseInt(ActTCOB) + parseInt(ActPressOB)) > parseInt(ActualFinishOB)) {
                        alert('Sum of Act. TC OB and Act. Press OB can not be greater than Act. Total OB');
                        //$("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActTCOB" + "']").val('');
                        document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActTCOB").value = '';
                        return false;
                    }
                }
                if (type == 'PressOB') {
                    if ((parseInt(ActTCOB) + parseInt(ActPressOB)) > parseInt(ActualFinishOB)) {
                        alert('Sum of Act. TC OB and Act. Press OB can not be greater than Act. Total OB');
                        //$("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActPressOB" + "']").val('');
                        document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActPressOB").value = '';
                        return false;
                    }

                }
                if (type == 'ACTOB') {
                    if (parseInt(hdnToBeFinish) == 0) {
                        return true;
                    }
                }
            }
            else {
                alert('First of all fill Act. Total OB!');
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActTCOB").value = '';
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActPressOB").value = '';
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                //document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActualFinishOB").focus();

                return false;
            }

            if (type == 'SlotEntry') {
                CheckPassFinshBal(elem);
            }
        }

        function ValidateFinishEntryCluster(elem) {
            //debugger;

            var ControlID = elem.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var cId = Ids.split("_")[7];

            var EntryFinishQty = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value;
            var SlotOB = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActualFinishOB").value;
            var hdnToBeFinish = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnToBeFinish").value;
            var LineFinishedQty = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnLineFinishedQty").value;

            if (hdnToBeFinish == '') {
                hdnToBeFinish = 0;
            }

            if (EntryFinishQty != '') {
                if (SlotOB != '' && hdnToBeFinish != 0) {

                    if (LineFinishedQty == '') {
                        LineFinishedQty = 0;
                    }

                    if (parseInt(EntryFinishQty) > parseInt(hdnToBeFinish)) {
                        alert('Finish Qty can not be greater than Finish Balance qty');
                        //                        $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                        document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                        if (hdnToBeFinish != '0') {
                            //                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(hdnToBeFinish);
                            document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").value = hdnToBeFinish;
                        }
                        return false;
                    }
                    else {
                        if (hdnToBeFinish != '0') {
                            var ToBeFinish = parseInt(hdnToBeFinish) - parseInt(EntryFinishQty)
                            //$("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(ToBeFinish);
                            document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").value = ToBeFinish;
                        }
                        else {
                            //                            $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                            document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                            return false;
                        }
                    }
                }
                else {
                    alert('Act.Total OB and finish balance  can not be 0 or empty');
                    //                    $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']").val('');
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                    return false;
                }
            }
            else {
                if (hdnToBeFinish != '0') {
                    // $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtToBeFinish" + "']").val(hdnToBeFinish);
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").value = hdnToBeFinish;
                }
            }

        }

        function FinishNilClickCluster(cb) {
            //debugger;
            //            var Ids = cb.id;
            //            var cId = Ids.split("_")[5].substr(3);

            var ControlID = cb.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var cId = Ids.split("_")[7];


            //            var ActualOB = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtActualFinishOB" + "']").val();
            //            var res = $("#<%= gvIEStitchedSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPassFinish" + "']");
            var ActualOB = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActualFinishOB").value;
            var res = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish");

            var PreviousPassVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnpassvalue").value;
            var SlotPassFinshVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value;
            if (cb.checked) {
                if (ActualOB != '') {
                    res.value = '';
                    //res.attr('readonly', true);
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").readOnly = true;

                }
                else {
                    alert('Act.Total OB W/S can not be 0 or empty');
                    cb.checked = false;
                    return false;
                }
            }
            else {
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").readOnly = false;

            }
        }
        function CheckPassFinshBal(elem) {
            // debugger;
            var ControlID = elem.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var cId = Ids.split("_")[7];

            var finshBal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnToBeFinish").value;
            var SlotPassFinshVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value;
            var PreviousPassVal = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_hdnpassvalue").value;
            if (finshBal == '') {
                finshBal = 0;
            }
            if (finshBal != '0') {

                if (SlotPassFinshVal == '') {
                    SlotPassFinshVal = 0;
                }

                if (parseInt(finshBal) >= parseInt(SlotPassFinshVal)) {

                    var totalFinishBal = (parseInt(finshBal) - parseInt(SlotPassFinshVal));
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").innerHTML = totalFinishBal;
                }
                else {

                    alert('Pass qty cannot be greater than finshed qty');
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                    document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtToBeFinish").innerHTML = finshBal == '0' ? '' : finshBal;
                }

            }
            else {
                alert('No balance qty available for finsh');
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").value = '';
                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtActualFinishOB").value = '';
                //                document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_rptcluster_" + cId + "_txtSlotPassFinish").readOnly = true;
            }
        }


        function validateinput(elem) {
            //debugger;
            var ControlID = elem.id;
            var Ids = ControlID;
            var RowID = Ids.split("_")[5];
            var Currentlen = document.getElementById("ctl00_cph_main_content_grdfinshingCluster_" + RowID + "_lblClusterCount").innerHTML;
            var val = $(elem).val();
            if (val > 0 && val <= 25) {
            }
            else {
                alert("You can only enter cluster between 1 to 25");
                elem.value = "";
                return;
            }

            if (Currentlen != '') {
                var len = Currentlen.replace("+", "");
                var lefttotal = parseInt(25) - (parseInt(len));


                if (lefttotal > 0 && lefttotal <= 325) {
                    if (val > lefttotal) {

                        alert("You have only " + lefttotal + " contract to add");
                        elem.value = "";
                        return;
                    }
                    else
                    { return true; }

                }
                else {
                    //alert("You can only enter cluster between 1 to 9");
                    alert("You can only enter cluster between 1 to 15");
                    elem.value = "";
                    return;
                }

            }
            else {
                return true;
            }
        }

        $(document).ready(function () {

            var lodedSize = 0;
            var number_of_media = $("body img").length;

            doProgress();

            // function for the progress bar
            function doProgress() {
                $("img").load(function () {
                    lodedSize++;
                    var newWidthPercentage = (lodedSize / number_of_media) * 100;
                    animateLoader(newWidthPercentage + '%');
                })
            }

            //Animate the loader
            function animateLoader(newWidth) {
                $("#progressBar").width(newWidth);
                if (lodedSize >= number_of_media) {
                    setTimeout(function () {
                        $("#progressBar").animate({ opacity: 0 });
                    }, 500);
                }
            }

            //Add By prabhaker shukla on 23-aug-18
            $(".ddlIeNameChange").change(function () {
                //debugger;
                var LineNumber = $(this).siblings('.LineNumber').html();
                var SelectedValue = $(this).val();
                //                alert(LineNumber);
                //                alert(SelectedValue);
                $(".ddlIeNameChange").each(function () {
                    if ($(this).siblings('.LineNumber').html() == LineNumber) {
                        $(this).val(SelectedValue);

                    }

                });
            });
            //End of Code


        })
       
    </script>
    <%--   <div id="spinner"></div>--%>
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:updatepanel ID="Updatepanel1"  runat="server">
    <ContentTemplate> 
    <table style="width: 1530px; table-layout: fixed; font-size: 12px;" cellpadding="0"
        cellspacing="0">
        <tr>
            <td>
                <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;">
                    Stitching / Finishing Entry
                </h2>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom:4px;">
                <asp:DropDownList ID="ddlSlot" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlot_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <div style="float: right;">
                    <asp:Button ID="btnSubmit1" runat="server" class="submit" OnClick="btnSubmit_Click"
                        OnClientClick="javascript:return CheckSlotClose(this);" Text="Submit" />
                </div>
            </td>
        </tr>
    <%--    <tr>
            <td>
                &nbsp;
                <asp:TextBox runat="server" Width="45%" CssClass="costing-style" ID="txtStylenumber" style="display:none;"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td>
                <table id="tblStitchHeader" runat="server" border="1" cellpadding="0" cellspacing="0" class="border2" style="border-collapse: collapse;
                    text-align: center;" width="1530px">
                    <thead>
                        <tr>
                            <th colspan="8">
                                <asp:Label ID="lblFactory" runat="server" Style="font-size: 16px;" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnProductionUnit" runat="server" />
                                <asp:HiddenField ID="hdnSlotId" runat="server" />
                                <asp:HiddenField ID="hdnCurrentSlotId" runat="server" />
                                <asp:HiddenField ID="hdnStartDate" runat="server" />
                                <asp:HiddenField ID="hdnStatus" runat="server" Value="" />
                                <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnparmtotalentrySum" runat="server" Value="0" />
                                <asp:HiddenField ID="hdntotalAltpcs" runat="server" Value="0" />
                                <asp:HiddenField ID="hdnSlotName" runat="server" Value="" />
                                &nbsp;&nbsp;
                                <asp:Label ID="lblSlot" runat="server" Style="font-size: 15px;" Text=""></asp:Label>
                            </th>
                            <th align="center" colspan="3">
                                <span style="font-size: 15px;">Stitching</span>
                            </th>
                            <th align="center" colspan="2">
                                <span style="font-size: 15px;">Finishing</span>
                            </th>
                            <th align="center" rowspan="2" style="width: 45px;">
                                Fin Cmpt
                                <br />
                                Sti Cmpt
                            </th>
                            <th align="center" rowspan="2" style="width: 40px;">
                                Day
                                <br />
                                Closed
                            </th>
                            <th align="center" rowspan="2" style="width: 150px;">
                                Remark
                            </th>
                        </tr>
                        <tr>
                            <th style="width: 75px">
                                Thumbnail
                            </th>
                            <th align="center" style="width: 80px;">
                                Location
                                <br />
                                Supervisor
                                 <br />
                                 Roaming QC
                            </th>
                            <th align="center" style="width: 180px;">
                                Serial No.
                                <br />
                                Style No. / Contract No.
                                <br />
                                Print Color / COT
                            </th>
                            <th align="center" style="width: 80px;">
                                F OB (S OB)
                                <br />
                                F Sam (S Sam)
                                <br />
                                Plan S Sam
                            </th>
                            <th style="width: 80px;">
                                Contract Qty
                                <br />
                                Ex. Fact. Date
                            </th>
                            <th align="center" style="width: 60px;">
                                Cut Rdy Qty
                                <br />
                                Line Qty
                                <br />
                            </th>
                            <th align="center" style="width: 60px;">
                                Sti. Bal.
                                <br />
                                Alt Pcs Tot
                            </th>
                            <th align="center" style="width: 80px;">
                            Is Loading Start<br />
                                Act.
                                <br />
                                OB W/S
                                <br />
                                SAM <br />
                                Working SAM<br />
                                Sq. Frame
                            </th>
                            <th align="center" style="width: 70px;">
                            Target Qty.
                            <br />
                                Pass/Nil Prd.
                                <br />
                                Alt / Rej.
                                <br />
                                half Stitch
                            </th>
                            <th align="center" width="90px">
                                Peak Cap. Pcs/Hr
                                <br />
                                Peak OB
                                <br />
                                peak Eff.
                            </th>
                            <th align="center" style="width: 90px;">
                                Total Stch(Line Stch)
                                <br />
                                To Be Fin.
                                <br />
                                F. SAM
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. Total OB
                                <br />
                                Act. Press OB
                         <%--       PK Cap Tot
                                <br />
                                PK OB
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. T.C OB
                                <br />
                                PK Cap T.C
                                <br />
                                PK T.C OB
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. Press OB
                                <br />
                                PK Cap Press
                                <br />
                                PK Press OB--%>
                            </th>
                            <th align="center" width="70px">
                                Pass/Nil Prd.
                            </th>
                        </tr>
                    </thead>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top;">
            <td>
            <div class="scroll-table" style="width:1540px; overflow-y:scroll;overflow-x:hidden">
                <asp:GridView ID="gvIEStitchedSlot" runat="server" AutoGenerateColumns="false" BackColor="White"
                    CellPadding="0" CellSpacing="0" CssClass="border2 slot-table" OnRowDataBound="gvIEStitchedSlot_RowDataBound"
                    ShowHeader="false" Width="1530px">
                    <RowStyle CssClass="gvIEStitchedSlotRow" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-Font-Size="14px" HeaderStyle-Width="75px" ItemStyle-HorizontalAlign="Center"
                            ItemStyle-Width="75px">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    Target="_blank">
                                             <img width="65px" height="65px" alt="" onclick="javascript:void(0)" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnLinePlanningId" runat="server" Value='<%# Eval("LinePlanningID") %>' />
                                <asp:HiddenField ID="hdnLineNo" runat="server" Value='<%# Eval("Line_No") %>' />  
                                <asp:HiddenField ID="hdnQcLinnManID" runat="server" Value='<%# Eval("QcLinnManID") %>' />                              
                                <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LineNumber") %>' CssClass="LineNumber"></asp:Label>
                                <br></br>
                                <asp:Label ID="lblIEName" runat="server" Text='<%# Eval("LineDesignationName") %>' style="display:none;"></asp:Label>
                                  
                                 <%-- --------------Add By Prabhaker 23-aug-18-------------------%>
                                     <asp:DropDownList runat="server" ID="ddlIEName" CssClass="ddlIeNameChange">
                                     
                                     </asp:DropDownList>

                                     <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddllQclineMan"  onchange="validateSlotpass(this)" >
                                     <asp:ListItem Value="-1">Select</asp:ListItem>
                                     </asp:DropDownList>

                                 <%------------------------End Of Code----------------------------%>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblSerialNumber" runat="server" Style="font-weight: bold;" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblStyleNumber" runat="server" Style="color: Blue;" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                                    &nbsp;/&nbsp;<asp:Label ID="lblContractNumber" runat="server" Style="color: Gray;"
                                        Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblFabricDetails" runat="server" ForeColor="Gray" Text=""></asp:Label>
                                    &nbsp; &nbsp;
                                    <asp:TextBox ID="txtcot" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="4" Style="float: right; margin-right: 15px;" Text='<%# Eval("cotsvalue") %>'
                                        Width="40px"></asp:TextBox>
                                    <asp:HiddenField ID="hdnStyleId" runat="server" Value='<%# Eval("StyleID") %>' />
                                    <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%# Eval("OrderID") %>' />
                                    <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value='<%# Eval("OrderDetailsID") %>' />
                                    <asp:HiddenField ID="hdnStyleNumber" runat="server" Value='<%# Eval("StyleNumber") %>' />
                                     <asp:HiddenField ID="hdnFrameStyleId" Value='<%# Eval("FrameStyleId") %>' runat="server" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblFinishOB" runat="server" Text='<%# Eval("LinePlan_FinishOB") %>'></asp:Label>
                                    (<asp:Label ID="lblStitchOB" runat="server" Text='<%# Eval("LinePlan_StitchOB") %>'></asp:Label>
                                    )
                                </div>
                                <div>
                                    <asp:Label ID="lblFinishSAM" runat="server" Text=""></asp:Label>
                                    (<asp:Label ID="lblStitchSAM" runat="server" Text='<%# Eval("SAM") %>'></asp:Label>
                                    )
                                    <asp:HiddenField ID="hdnEfficiency" runat="server" Value='<%# Eval("Efficiency") %>' />
                                </div>
                                 <div>
                                    <asp:Label ID="lblStitchPlanSam" runat="server" Text='<%# Eval("LinePlanningSAM") %>'></asp:Label>                                    
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField ItemStyle-Width="80px">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblContractQty" runat="server" Text='<%# Eval("OrderQuantity") %>'
                                        Width="60px"></asp:Label>
                                </div>
                                <div>
                                    <span style="color: Gray">
                                        <%# Eval("ExFactory")%></span>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
                            <ItemTemplate>
                                <div>
                                    <asp:TextBox ID="txtCutReady" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                        Style="text-align: center" Text='<%# Eval("CutRdyQty") %>' Width="80%"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtLineQty" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                        Style="text-align: center" Text="" Width="80%"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
                            <ItemTemplate>
                                <div>
                                    <asp:TextBox ID="txtBalanceLineStichedQty" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                        Style="text-align: center" Text="" Width="80%"></asp:TextBox>
                                </div>
                                <div style="height: 22px;">
                                    <asp:TextBox ID="txtAltPcsTotal" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                        Style="text-align: center" Text='<%# Eval("AltpcsTotal") %>' Width="80%"></asp:TextBox>
                                    <asp:HiddenField ID="hdnAltPcsTotal" runat="server" Value='<%# Eval("AltpcsTotal") %>' />
                                    <asp:HiddenField ID="hdnLineStitchBalance" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnStitchBalance" runat="server" Value='<%# Eval("BalanceStichedQty") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80">
                            <ItemTemplate>
                            <div>
                            <asp:CheckBox runat="server" ID="chkRequiredActualOB" style="padding:0px; margin:0px" />
                            <asp:HiddenField ID="hdnCheckRequiredActualOb" runat="server" Value='<%# Eval("CheckRequiredActualOb") %>' />
                            </div>
                                <div>
                                    <asp:TextBox ID="txlActualOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center;margin-bottom:2px;" Text="" Width="40px"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblLinePlanningSAM" runat="server" Text='<%# Eval("HalfStitchSAM")%>'></asp:Label>
                                </div>
                                   <div>
                                   <asp:TextBox ID="txtSlotSAM" runat="server" CssClass="numeric-field-with-two-decimal-places"
                                        MaxLength="5" Style="text-align: center" Text="" Width="40px"></asp:TextBox>
                                         </div>
                            <asp:CheckBox runat="server" ID="chkSeqCheck" style="padding:0px; margin:0px" />
                            <asp:HiddenField ID="hdnchkSeqCheck" runat="server" Value='<%# Eval("Sequenceframe")%>'  />
                            <asp:HiddenField ID="hdnIsSequence" runat="server" Value='<%# Eval("IsSequence")%>'  />
                           
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# Eval("CutQty") %>' />
                                <asp:HiddenField ID="hdnOrderQuantity" runat="server" Value='<%# Eval("OrderQuantity") %>' />
                                <asp:HiddenField ID="hdnOrderStichedQty" runat="server" Value='<%# Eval("OrderStichedQty") %>' />
                                <asp:HiddenField ID="hdnLineStitchedQty" runat="server" Value='<%# Eval("LineStichedQty") %>' />
                                 <asp:HiddenField ID="hdnTargetQty" runat="server" Value='<%# Eval("TargetQty") %>' />
                                   <div>                                  
                                   <asp:Label runat="server" ID="lblTargetQty" Text='<%# Eval("TargetQty") %>'></asp:Label> &nbsp;
                                    <asp:HyperLink ID="hlinkBottleNeck" style="cursor:pointer; font-size:9px; color:Blue;" Visible="false" onclick="javascript:OpenBottleNeck(this);" runat="server">Btl Neck</asp:HyperLink>
                                  
                                   </div>
                                <div>
                                    <asp:TextBox ID="txtSlotPass" style="text-align:center;" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="4" onblur="javascript:return ValidateStitchEntry(this);" Text="" Width="40px"></asp:TextBox>
                                    <asp:HiddenField ID="hdnZeroProductvity" runat="server" Value="0" />
                                    <asp:HiddenField ID="Zeroproeduct" runat="server" Value='<%# Eval("SlotZeroProductivity") %>' />
                                    <input id="chkpass" runat="server" onclick="StitchNilClick(this);" type="checkbox"></input>
                                </div>
                                <div style=" text-align: left; padding-left: 7px;">
                                    <asp:TextBox ID="txtSlotAlt" style="text-align:center;" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="4" onblur="javascript:return ValidateAltEntry(this);" Text='<%# Eval("SlotAlt") %>'
                                        Width="40px"></asp:TextBox> &nbsp;
                                        <asp:CheckBox ID="chkHalfStitch" runat="server" Checked='<%# Eval("IsHalfStitch") %>'
                                        Enabled="false" CssClass="repadd" />
                                </div>                              
                               
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="90px">
                            <ItemTemplate>
                                <div>
                                    <asp:TextBox ID="txtPeakCapecity" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="4" Style="text-align: center; width: 40px" Text='<%# Eval("PeakCapecity") %>'></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPeakOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 40px" Text='<%# Eval("PeakOB") %>'></asp:TextBox>
                                </div>
                                <div style="text-align: center; width: 40px; padding-top: 10px">
                                    <asp:Label ID="PkEff" runat="server" Text='<%# (Eval("PeakEff") == DBNull.Value || (Eval("PeakEff").ToString().Trim() == "0")) ? string.Empty : (Convert.ToInt32((Eval("PeakEff"))).ToString())%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div>
                                <asp:Label ID="lblOrderStitchQty" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblLineStitchQty" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnLineFinishedQty" runat="server" Value='<%# Eval("LineFinishedQty") %>' />
                                    <asp:HiddenField ID="hdnOrderFinishedQty" runat="server" Value='<%# Eval("OrderFinishingQty") %>' />
                                </div>
                                <div>
                                    <asp:TextBox ID="txtToBeFinish" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                        Style="text-align: center" Width="80%"></asp:TextBox>
                                    <asp:HiddenField ID="hdnToBeFinish" runat="server" Value="0" />
                                </div>
                                <div>
                                    <asp:Label ID="lblLinePlanning_FinishSAM" runat="server" Text=""></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div>
                                    <asp:TextBox ID="txtActualFinishOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                                <div class="disp-none">
                                    <asp:TextBox ID="txtPeakCapTotal" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                                <div>
                                <asp:TextBox ID="txtActPressOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" onblur="javascript:return ValidateFinish_OBEntry(this, 'PressOB');"
                                        Style="text-align: center" Text="" Width="70%"></asp:TextBox>
                                    <asp:TextBox ID="txtPeakOB_Finish" runat="server" CssClass="numeric-field-without-decimal-places disp-none"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div>
                                    <asp:TextBox ID="txtActTCOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" onblur="javascript:return ValidateFinish_OBEntry(this, 'TCOB');"
                                        Style="text-align: center" Text="" Width="70%"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPeakCapTC" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPeakTCOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="60px" CssClass="disp-none" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div>
                                    
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPeakCapPress" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                                <div style="height: 20px;">
                                    <asp:TextBox ID="txtPeakPressOB" runat="server" CssClass="numeric-field-without-decimal-places"
                                        MaxLength="3" Style="text-align: center; width: 70%"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="60px" CssClass="disp-none" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSlotPassFinish" runat="server" CssClass="numeric-field-without-decimal-places"
                                    MaxLength="4" onblur="javascript:return ValidateFinishEntry(this);" Text="" Width="40px" style="margin-bottom: 6px; text-align:center;"></asp:TextBox>
                             
                                    <input id="chkpassFinish" runat="server" onclick="FinishNilClick(this);" type="checkbox"></input>                                                                   
                                    <asp:HyperLink ID="hlnkQC" style="cursor:pointer; font-size:9px; color:Blue;" onclick="javascript:OpenQCPopup(this, 'Finish');" runat="server">Slot QC</asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkmarkfinish" runat="server" />
                                <br />
                                <asp:CheckBox ID="chkMarkAsStyle" runat="server" Checked='<%# Eval("IsStitched") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMarkAsDayClose" runat="server" Checked='<%# Eval("IsDayClosed") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtComment" runat="server" Height="30px" Text='<%# Eval("SlotDescription") %>'
                                    TextMode="MultiLine" Width="140px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
          <td style="height:30px;border:0px;"></td>
        </tr>
        <tr>
            <td>
                <table id="tblClusterHeader" runat="server" border="1" cellpadding="0" cellspacing="0" class="border2" style="border-collapse: collapse;text-align: center; width: 1152px">
                    <thead>
                        <tr>
                            <th colspan="5">
                            <span Style="font-size: 16px; float:left; padding-left:10px;"> Cluster Entry </span>
                                <asp:Label ID="lblfactoryslotname" runat="server" Style="font-size: 16px;" Text=""></asp:Label>&nbsp;&nbsp
                                <asp:Label ID="lblslots" runat="server" Style="font-size: 15px;" Text=""></asp:Label>
                            </th>
                            <th align="center" colspan="2">
                                <span style="font-size: 15px;">Finishing</span>
                            </th>
                            <th align="center" rowspan="2" style="width: 70px;">
                                Fin Cmpt
                                <br />
                                Day Closed
                            </th>
                            <th align="center" rowspan="2" style="width: 120px;">
                                Remark
                            </th>
                        </tr>
                        <tr>
                            <th align="center" style="width: 97px;">
                                Unit
                                <br />
                                Cluster Name
                                <br />
                                No. of Contracts
                            </th>
                            <th align="center" style="width: 250px;">
                                 Serial No. / Style No.
                                <br />
                                Contract No. Print Color / Quantity
                            </th>
                            <th style="width: 75px">
                                Thumbnail
                            </th>
                            <th align="center" style="width: 80px;">
                                F OB
                                <br />
                                F Sam
                            </th>
                            <th style="width: 80px;">
                                Total Qty. To Fin.
                                <br />
                                Finish Balance
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. Total OB
                                <br />
                                 Act. Press OB
                           <%--     PK Cap Tot
                                <br />
                                PK OB
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. T.C OB
                                <br />
                                PK Cap T.C
                                <br />
                                PK T.C OB
                            </th>
                            <th align="center" style="width: 60px;">
                                Act. Press OB
                                <br />
                                PK Cap Press
                                <br />
                                PK Press OB--%>
                            </th>
                            <th align="center" width="70px">
                                Pass/Nil Prd.
                            </th>
                        </tr>
                    </thead>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top;">
            <td>
                <asp:UpdateProgress runat="server" ID="uproAttandanceList" AssociatedUpdatePanelID="updateCluster"
                    DisplayAfter="0">
                    <ProgressTemplate>
                        <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                            z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="updateCluster" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdfinshingCluster" runat="server" AutoGenerateColumns="false"
                            BackColor="White" CellPadding="0" CellSpacing="0" CssClass="border2" OnRowDataBound="grdfinshingCluster_RowDataBound"
                            ShowHeader="false" Width="1152px">
                            <RowStyle CssClass="gvIEFinsihSlotRow" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-Font-Size="14px" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="114px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfactoryname" runat="server" Text='<%# Eval("factoryName") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="clusterCount" Style="display: none" runat="server" Text='<%# Eval("SequenceofCluster") %>'></asp:Label>
                                        <asp:Label ID="CLusterName" ToolTip="Cluster Name" runat="server" Text='<%# Eval("ClusterName") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblClusterCount" runat="server"></asp:Label><asp:TextBox ID="txtcluster"
                                            CssClass="numeric-field-without-decimal-places numeric_text input_in" Width="60px"
                                            AutoPostBack="True" OnTextChanged="txtcluster_TextChanged" runat="server" Text='<%# Eval("ClusterCount") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table border="1" cellpadding="0" id="rptlengh" cellspacing="0" width="100%" frame="void"
                                            rules="all">
                            <asp:Repeater ID="rptcluster" runat="server" OnItemDataBound="rptcluster_OnItemDataBound">
                                <ItemTemplate>
                                    <tr class="trrptlengh">
                                        <td style="width: 252px">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #ccc">
                                                        <asp:TextBox runat="server" Width="85px" CssClass="clusterStyleNumber" ID="txtSerialNumber"
                                                            Text='<%# Eval("SerialNumber") %>'></asp:TextBox>                                                               
                                                        <asp:TextBox ID="txtstylenumber" Text='<%# Eval("StyleNumber") %>' runat="server"
                                                            Width="165px" Style="pointer-events: none"></asp:TextBox>
                                                        <asp:HiddenField ID="hdnserialNo" runat="server" />
                                                        <asp:HiddenField ID="hdnOrderID" Value='<%# Eval("OrderID") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnOrderDetailsID" Value='<%# Eval("OrderDetailsID") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnunitID" Value='<%# Eval("UnitID") %>' runat="server" />
                                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPrintColorQuantity" onchange="jsFunctions(this);" OnSelectedIndexChanged="ddlPrintColorQuantity_SelectedIndexChanged"
                                        Width="98%" runat="server">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnprintColorqty" runat="server" />
                                    <asp:HiddenField ID="hdnCheckRepOrderDetailsID" runat="server" />
                                    <asp:HiddenField ID="hdncount" runat="server" />
                                    <asp:HiddenField ID="hdnisfinsh" Value='<%# Eval("IsFinished") %>' runat="server" />
                                    <asp:HiddenField ID="hdnsampleimageurl" Value='<%# Eval("SampleImageURL1") %>' runat="server" />
                                    <asp:HiddenField ID="hdnslotdescription" Value='<%# Eval("SlotDescription") %>' runat="server" />
                                    <asp:HiddenField ID="hdnfabric1Details" Value='<%# Eval("FabricDetails") %>' runat="server" />
                                    <asp:HiddenField ID="hdnexfact" Value='<%# Eval("ExFactory") %>' runat="server" />
                                    <asp:HiddenField ID="hdnexfactdate" Value='<%# Eval("ExFactoryDate") %>' runat="server" />                                    
                                </td>
                            </tr>
                            </table> </td>
                            <td style="padding: 0px !important; width: 75px">
                                <asp:HyperLink ID="HyperLink2" runat="server" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    Target="_blank">
                                                             <img  alt="" style="width: 100%;height: 65px;" onclick="javascript:void(0)" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/> 
                                </asp:HyperLink>
                            </td>
                            <td style="width: 80px; text-align: center;">
                                <div style="width: 100%; height: 20px; border-bottom: 1px solid #ccc">
                                    <asp:Label ID="lblFinishOB" runat="server" Text='<%# Eval("LinePlan_FinishOB") %>'></asp:Label>
                                </div>
                                <div style="width: 100%; height: 20px;">
                                    <asp:Label ID="lblLinePlanning_FinishSAM" runat="server" Text='<%# Eval("LinePlan_FinishSAM") %>'></asp:Label>
                                </div>
                            </td>
                            <td style="width: 80px; text-align: center;">
                                <div style="width: 100%; height: 20px; border-bottom: 1px solid #ccc">
                                    <asp:Label ID="lblLineStitchQty" viewstate="true" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnLineFinishedQty" runat="server" Value='<%# Eval("LineFinishedQty") %>' />
                                </div>
                                <div style="width: 100%; height: 20px;">
                                    <asp:Label ID="txtToBeFinish" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnToBeFinish" runat="server" Value="0" />
                                </div>
                            </td>
                            <td style="width: 60px">
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;">
                                    <asp:TextBox ID="txtActualFinishOB" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        onchange="javascript:return ValidateFinish_OBEntry_Cluster(this, 'ACTOB');" runat="server"
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        Style="text-align: center; height: 12px; width: 70%"></asp:TextBox>
                                </div>
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;" class="disp-none">
                                    <asp:TextBox ID="txtPeakCapTotal" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        runat="server" CssClass="numeric-field-without-decimal-places numeric_text input_in"
                                        MaxLength="3" Style="text-align: center; height: 12px; width: 70%"></asp:TextBox>
                                </div>
                                <div style="height: 20px; text-align: center;">
                                <asp:TextBox ID="txtActPressOB" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        onchange="javascript:return ValidateFinish_OBEntry_Cluster(this, 'PressOB');"
                                        Style="text-align: center; height: 12px;" Text="" Width="70%"></asp:TextBox>

                                    <asp:TextBox ID="txtPeakOB_Finish" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        runat="server" CssClass="numeric-field-without-decimal-places numeric_text input_in disp-none"
                                        MaxLength="3" Style="text-align: center; height: 12px; width: 70%"></asp:TextBox>
                                </div>
                            </td>
                            <td style="width: 60px" class="disp-none">
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;">
                                    <asp:TextBox ID="txtActTCOB" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        onchange="javascript:return ValidateFinish_OBEntry_Cluster(this, 'TCOB');" Style="text-align: center;
                                        height: 12px;" Text="" Width="70%"></asp:TextBox>
                                </div>
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;">
                                    <asp:TextBox ID="txtPeakCapTC" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        Style="text-align: center; width: 70%; height: 12px;"></asp:TextBox>
                                </div>
                                <div style="height: 20px; text-align: center;">
                                    <asp:TextBox ID="txtPeakTCOB" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        Style="text-align: center; width: 70%; height: 12px;"></asp:TextBox>
                                </div>
                            </td>
                            <td style="width: 60px" class="disp-none">
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;">
                    
                                </div>
                                <div style="height: 20px; border-bottom: 1px solid #f0f0f0; text-align: center;">
                                    <asp:TextBox ID="txtPeakCapPress" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        runat="server" CssClass="numeric-field-without-decimal-places numeric_text input_in"
                                        MaxLength="3" Style="text-align: center; height: 12px; width: 70%"></asp:TextBox>
                                </div>
                                <div style="height: 20px; text-align: center;">
                                    <asp:TextBox ID="txtPeakPressOB" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="numeric-field-without-decimal-places numeric_text input_in" MaxLength="3"
                                        Style="text-align: center; width: 70%; height: 12px;"></asp:TextBox>
                                </div>
                            </td>
                            <td style="width: 70px; text-align: center;">
                                <asp:TextBox ID="txtSlotPassFinish" runat="server" CssClass="numeric-field-without-decimal-places"
                                    MaxLength="4" Style="text-align: center;" onchange="javascript:return ValidateFinish_OBEntry_Cluster(this, 'SlotEntry');"
                                    onkeypress='return event.charCode >= 48 && event.charCode <= 57' Text="" Width="40px"></asp:TextBox>
                                <asp:TextBox ID="txtlastvalue" Visible="false" Style="text-align: center;" runat="server"
                                    Width="40px" ReadOnly="true" ToolTip="Last Inserted pass value"></asp:TextBox>
                                <asp:HiddenField ID="hdnpassvalue" runat="server" Value="0" />
                                <label>
                                    <input id="chkpassFinish" runat="server" onclick="FinishNilClickCluster(this);" type="checkbox"></input></label>

                                    <br />&nbsp;
                                     <asp:HyperLink ID="hlnkQC" style="cursor:pointer; font-size:9px; color:Blue;" onclick="javascript:OpenQCPopup(this, 'Cluster')" runat="server">Slot QC</asp:HyperLink>
                            </td>
                            <td style="width: 70px; text-align: center;">
                                <asp:CheckBox ID="chkmarkfinish" runat="server" />                               
                                <br />
                                <asp:CheckBox ID="chkMarkAsDayClose" runat="server" Checked='<%# Eval("IsDayClosed") %>' />
                            </td>
                            <td style="width: 120px">
                                <asp:TextBox ID="txtComment" runat="server" Height="30px" Text='<%# Eval("SlotDescription") %>'
                                    TextMode="MultiLine" Width="95%"></asp:TextBox>
                            </td>
                            </tr> 
            </ItemTemplate> 
            </asp:Repeater> 
            </table> </ItemTemplate>
            <itemstyle width="955px" cssclass="padding-class" />
            </asp:TemplateField> </Columns> </asp:GridView>
            <br />
            <asp:HiddenField ID="hdnSlotClose" runat="server" Value="0" />
            <asp:Button ID="btnSubmit" runat="server" class="submit" OnClick="btnSubmit_Click"
                OnClientClick="javascript:return CheckSlotClose(this);" Text="Submit" />
            </ContentTemplate>
            <triggers>
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </triggers>
            </asp:UpdatePanel> </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:updatepanel>
</asp:Content>
