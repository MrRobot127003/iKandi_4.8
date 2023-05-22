<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionDetails.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="iKandi.Web.Internal.Production.ProductionDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 12px;
        color: #787777;
    }
    .borderbottom
    {
        border: 1px solid #000000;
        border-top: none;
        border-right: none;
        border-left: none;
        color: #000;
    }
    .alignLeft
    {
        text-align: left !important;
    }
    .borderbottom td
    {
        height: 22px;
        border-color:  #dbd8d8;
    }
     .borderbottom td:first-child
    {
       
        border-left-color:  #999 !important;
    }
    #grdFaultTypeRescan td:last-child 
    {
       
        border-right-color:  #999 !important;
    }
     #tdRescan td
    {
       
        border-right-color:  #999 !important;
        min-width:180px;
        text-align: left;
    }
    #tdRescan td input[type="text"]
    {
       margin-right:2px;
       width: 30px !important;
        text-align: center !important;
    }
      #tdRescan td div
    {
          padding-right: 0px !important;
        float: none !important;
        display: inline-block;
        width: 35px;
       
    }
   
      #tdRescan td div td input[type="text"]:first-child
    {
        width: 25px;
    }
      #tdRescan td div:first-child
    {
          padding-right: 0px !important;
        float: none !important;
        display: inline-block;
        width: 55px;
       
    }
       .border2 tr:last-child > td
    {
       
        border-bottom-color:  #999 !important;
    }
      .border2 td:first-child
    {
       
        border-left-color:  #999 !important;
    }
    .border2 th
    {
        padding: 0px;
        border-top: 0px;
        font-size:10px !important;
        border:1px solid #999;
    }       
    .border2 td
    {
        text-align: center;
        font-size: 10px;
    }
        .border2 td input[type=text], textarea {
  
    font-size: 10px !important;
   
    }
    {
        text-align: center;
        font-size: 10px;
    }
    .border2 .borderbottom-mid td
    {
        color: #aba5a5;
    }     
        
    input
    {
        margin-top: 0px;
    }
    form
    {
        padding: 0px 15px;
    }
    .sam_heading th
    {
        min-width: 65px;
        text-align: center;
        border-top: 1px solid #b7b4b4;
        font-size: 10px;
    }
    .borderbottom
    {
        text-align: center;
    }
    #ui-datepicker-div
    {
        width: 0em !important;
        padding: inherit !important;
       
    }
   .ui-widget-content
    {
         background:#fff !important;
        border:0px !important;
        }
    .HeaderStyle1{
        background: #3a5795;
        color: #fff;
        text-align: center;
        font-size: 13px;
    }
    .HeaderStyle1 span{
            font-size: 12px;
    }
    .HeaderStyle2{
        background: #3a5795;
        color: #fff;
        text-align: center;
    }
    .HeaderRescanDetail{
        background: #3a5795;
        color: #fff;
        text-align: center;
        font-size:10px;
        height:25px;
    }
        
    .tooltip {
        position: relative;
        display: inline-block;   
        cursor:pointer
    }

    .tooltip .tooltiptext {
        visibility: hidden;
        width: 300px;
        background-color: #ececec;
        color: black;
        text-align: left;
        border-radius: 6px;
        padding: 5px 3px;
        position: absolute;
        z-index: 1;
        top: 150%;
        left: -230%;
        margin-left: -60px;
     font-weight:normal
    }

    .tooltip .tooltiptext::after {
        content: "";
        position: absolute;
        bottom: 100%;
        left: 39%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent #d5d5d5 transparent;
    }

    .tooltip:hover .tooltiptext {
        visibility: visible;
    }



    .OnlineTooltip {
        position: relative;
        display: inline-block;   
    }

    .OnlineTooltip .tooltiptext {
        visibility: hidden;
        width: 200px;
        background-color: #ececec;
        color: black;
        text-align: left;
        border-radius: 6px;
        padding: 5px 3px;
        position: absolute;
        z-index: 1;
        top: 150%;
        left: -18%;
        margin-left: -60px;
        font-size:11px;
     font-weight:normal
    }

    .OnlineTooltip .tooltiptext::after {
        content: "";
        position: absolute;
        bottom: 100%;
        left: 50%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent #d5d5d5 transparent;
    }

    .OnlineTooltip:hover .tooltiptext {
        visibility: visible;
    }
    .disp-block
    {
        display:block;
    }
.rescanac span input[type="checkbox" i] {
    margin: -2px 0px 0px 0px;
    position:relative;
    top:3px;
    cursor:pointer;
}
.rescanl15 input[type="checkbox" i] {
    margin: -2px 0px 0px 0px;
    position:relative;
    top:3px;
}
 input[type="checkbox" i] {
    margin: 1px 0px 0px 0px;
}

.minWidth
{
    min-width:95px;
 }
  .minWidthdate
 {
     min-width:72px;
  }
  .minWidthcutqty
 {
     min-width:50px;
  }
 .minWidthfinqty
 {
     min-width:60px;
  }
  .minWidthcoddate
 {
     min-width:140px;
  }
  .reci11 input[type="checkbox" i] {
    margin: 0px 0px 0px 0px;
    position:relative;
    top:3px;
}
#td11
{
   min-width: 57px;
 }
.fontsize
{
    font-size:12px;
    font-weight:normal;
    height: 18px;
    }
    
  
     .removeborder
     {
         border-top:1px solid #999;
         border-bottom:1px solid #999;
         border-right:1px solid #999;
      }
      
       .hocutqty
       {
           min-width:38px;
        }
        
        
       .cutqtyborleft {
          border-left:1px solid #999;
        } 
        @-moz-document url-prefix() {
    .fontsizehaul {font-size:9px !important;}
    .sam_heading th
       {
        font-size:9px !important;
        }
}
.submit
{
    border-radius:2px;
    cursor:pointer;
    }
 .da_submit_button
{
    border-radius:2px;
     cursor:pointer;
    }
/*.rescanac span
{
    position:relative;
    top:3px;
    left:4px
    }*/
</style>

    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>
    

</head>
<body>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/date.js")%>'></script>
    <script type="text/javascript">


        $(function () {
            var f = $("#<%=hfPosition.ClientID%>");
            window.onload = function () {
                var position = parseInt(f.val());
                if (!isNaN(position)) {
                    $(window).scrollTop(position);
                }
            };
            window.onscroll = function () {
                var position = $(window).scrollTop();
                f.val(position);
            };

            $(".th").datepicker({ dateFormat: 'dd M y (D)', maxDate: new Date() });
            initializer();
            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                //you need to re-bind your jquery events here
                initializer();
            });

        });


        function ValidateRescanCycle(obj, CycleNo) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[1].substr(3);

            var hdnC45_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC45_FinishQty" + "']").val();
            var hdnC47_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC47_FinishQty" + "']").val();
            var hdnD169_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnD169_FinishQty" + "']").val();
            //            var hdnC52_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC52_FinishQty" + "']").val();

            var txtC45Cycle = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_txtC45Cycle" + CycleNo + "']");
            var txtC47Cycle = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_txtC47Cycle" + CycleNo + "']");
            var txtD169Cycle = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_txtD169Cycle" + CycleNo + "']");
            //            var txtC52Cycle = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_txtC52Cycle" + CycleNo + "']");

            var chkCycle = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_chkCycle" + CycleNo + "']");

            if (chkCycle.is(":checked")) {
                //$("#" + Ids).removeAttr("checked");
                if (parseInt(hdnC45_FinishQty) > 0) {
                    txtC45Cycle.removeAttr('placeholder');
                    if (txtC45Cycle.val() == '')
                        txtC45Cycle.val(hdnC45_FinishQty);
                }
                if (parseInt(hdnC47_FinishQty) > 0) {
                    txtC47Cycle.removeAttr('placeholder');
                    if (txtC47Cycle.val() == '')
                        txtC47Cycle.val(hdnC47_FinishQty);
                }
                if (parseInt(hdnD169_FinishQty) > 0) {
                    txtD169Cycle.removeAttr('placeholder');
                    if (txtD169Cycle.val() == '')
                        txtD169Cycle.val(hdnD169_FinishQty);
                }
                //                if (parseInt(hdnC52_FinishQty) > 0) {
                //                    txtC52Cycle.removeAttr('placeholder');
                //                    if (txtC52Cycle.val() == '')
                //                        txtC52Cycle.val(hdnC52_FinishQty);
                //                }
            }
            else {
                txtC45Cycle.val('');
                txtC47Cycle.val('');
                txtD169Cycle.val('');
                //                txtC52Cycle.val('');
                if (parseInt(hdnC45_FinishQty) > 0) {
                    txtC45Cycle.attr("placeholder", "C-45");
                }
                if (parseInt(hdnC47_FinishQty) > 0) {
                    txtC47Cycle.attr("placeholder", "C-47");
                }
                if (parseInt(hdnD169_FinishQty) > 0) {
                    txtD169Cycle.attr("placeholder", "D 169");
                }
                //                if (parseInt(hdnC52_FinishQty) > 0) {
                //                    txtC52Cycle.attr("placeholder", "C-52");
                //                }
            }
        }

        function ValidateRescanCycle_Header(obj, CycleNo) {
            //debugger;
            var Ids = obj.id;
            var RowId = 0;
            var gvId;
            var GridRow = $(".grdRescanRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var hdnC45_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_hdnC45_FinishQty" + "']").val();
                var hdnC47_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_hdnC47_FinishQty" + "']").val();
                var hdnD169_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_hdnD169_FinishQty" + "']").val();
                //                var hdnC52_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_hdnC52_FinishQty" + "']").val();

                var txtC45Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC45Cycle" + CycleNo + "']");
                var txtC47Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC47Cycle" + CycleNo + "']");
                var txtD169Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtD169Cycle" + CycleNo + "']");
                //                var txtC52Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC52Cycle" + CycleNo + "']");

                var chkCycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_chkCycle" + CycleNo + "']");

                if ($("#" + Ids).is(":checked")) {
                    chkCycle.attr("checked", "checked");

                    if (parseInt(hdnC45_FinishQty) > 0) {
                        txtC45Cycle.removeAttr('placeholder');
                        if (txtC45Cycle.val() == '')
                            txtC45Cycle.val(hdnC45_FinishQty);
                    }
                    if (parseInt(hdnC47_FinishQty) > 0) {
                        txtC47Cycle.removeAttr('placeholder');
                        if (txtC47Cycle.val() == '')
                            txtC47Cycle.val(hdnC47_FinishQty);
                    }
                    if (parseInt(hdnD169_FinishQty) > 0) {
                        txtD169Cycle.removeAttr('placeholder');
                        if (txtD169Cycle.val() == '')
                            txtD169Cycle.val(hdnD169_FinishQty);
                    }
                    //                    if (parseInt(hdnC52_FinishQty) > 0) {
                    //                        txtC52Cycle.removeAttr('placeholder');
                    //                        if (txtC52Cycle.val() == '')
                    //                            txtC52Cycle.val(hdnC52_FinishQty);
                    //                    }
                }
                else {
                    txtC45Cycle.val('');
                    txtC47Cycle.val('');
                    txtD169Cycle.val('');
                    //                    txtC52Cycle.val('');
                    chkCycle.removeAttr("checked");
                    if (parseInt(hdnC45_FinishQty) > 0) {
                        txtC45Cycle.attr("placeholder", "C-45");
                    }
                    if (parseInt(hdnC47_FinishQty) > 0) {
                        txtC47Cycle.attr("placeholder", "C-47");
                    }
                    if (parseInt(hdnD169_FinishQty) > 0) {
                        txtD169Cycle.attr("placeholder", "D 169");
                    }
                    //                    if (parseInt(hdnC52_FinishQty) > 0) {
                    //                        txtC52Cycle.attr("placeholder", "C-52");
                    //                    }
                }
            }
        }



        function checkC45Quantity(obj, CycleNo) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[1].substr(3);

            var hdnC45_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC45_FinishQty" + "']").val();

            var Quantity = obj.value.trim();

            if (Quantity == "") {
                Quantity = "0";
            }
            if (Quantity == "0") {
                obj.value = "";
                return false;
            }
            if (hdnC45_FinishQty == "") {
                hdnC45_FinishQty = "0";
            }

            if (parseInt(Quantity) > parseInt(hdnC45_FinishQty)) {
                jQuery.facebox("Rescan qty. can not be greater than total finish qty!");
                obj.value = hdnC45_FinishQty;
                obj.focus();
                return false;
            }

        }

        function checkC47Quantity(obj, CycleNo) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[1].substr(3);

            var hdnC47_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC47_FinishQty" + "']").val();

            var Quantity = obj.value.trim();

            if (Quantity == "") {
                Quantity = "0";
            }
            if (Quantity == "0") {
                obj.value = "";
                return false;
            }
            if (hdnC47_FinishQty == "") {
                hdnC47_FinishQty = "0";
            }

            if (parseInt(Quantity) > parseInt(hdnC47_FinishQty)) {
                jQuery.facebox("Rescan qty. can not be greater than total finish qty!");
                obj.value = hdnC47_FinishQty;
                obj.focus();
                return false;
            }

        }
        function checkD169Quantity(obj, CycleNo) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[1].substr(3);

            var hdnD169_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnD169_FinishQty" + "']").val();

            var Quantity = obj.value.trim();

            if (Quantity == "") {
                Quantity = "0";
            }
            if (Quantity == "0") {
                obj.value = "";
                return false;
            }
            if (hdnD169_FinishQty == "") {
                hdnD169_FinishQty = "0";
            }

            if (parseInt(Quantity) > parseInt(hdnD169_FinishQty)) {
                jQuery.facebox("Rescan qty. can not be greater than total finish qty!");
                obj.value = hdnD169_FinishQty;
                obj.focus();
                return false;
            }

        }
        //        function checkC52Quantity(obj, CycleNo) {
        //            //debugger;
        //            var Ids = obj.id;
        //            var cId = Ids.split("_")[1].substr(3);

        //            var hdnC52_FinishQty = $("#<%= grdRescan.ClientID %> input[id*='ctl" + cId + "_hdnC52_FinishQty" + "']").val();

        //            var Quantity = obj.value.trim();

        //            if (Quantity == "") {
        //                Quantity = "0";
        //            }
        //            if (Quantity == "0") {
        //                obj.value = "";
        //                return false;
        //            }
        //            if (hdnC52_FinishQty == "") {
        //                hdnC52_FinishQty = "0";
        //            }

        //            if (parseInt(Quantity) > parseInt(hdnC52_FinishQty)) {
        //                jQuery.facebox("Rescan qty. can not be greater than total finish qty!");
        //                obj.value = hdnC52_FinishQty;
        //                obj.focus();
        //                return false;
        //            }

        //        }
        function ValidateRescanSubmit(evnt) {
            //debugger;
            var CycleNo = $("#lblCycleNo").html();
            if (CycleNo == '0')
                CycleNo = '1';

            var Checked = 0;
            var C45Totalvalue = 0;
            var C47Totalvalue = 0;
            var D169Totalvalue = 0;
            var C52Totalvalue = 0;

            var RowId = 0;
            var gvId;
            var GridRow = $(".grdRescanRow").length;
            for (var row = 1; row < GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var chkCycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_chkCycle" + CycleNo + "']");
                if (chkCycle.is(':checked')) {
                    Checked = 1;
                }

                var C45Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC45Cycle" + CycleNo + "']").val();
                if (C45Cycle == undefined) {
                    C45Cycle = 0;
                }
                else if (C45Cycle == '') {
                    C45Cycle = 0;
                }
                C45Totalvalue = parseInt(C45Totalvalue) + parseInt(C45Cycle);

                var C47Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC47Cycle" + CycleNo + "']").val();
                if (C47Cycle == undefined) {
                    C47Cycle = 0;
                }
                else if (C47Cycle == '') {
                    C47Cycle = 0;
                }
                C47Totalvalue = parseInt(C47Totalvalue) + parseInt(C47Cycle);

                var D169Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtD169Cycle" + CycleNo + "']").val();
                if (D169Cycle == undefined) {
                    D169Cycle = 0;
                }
                else if (D169Cycle == '') {
                    D169Cycle = 0;
                }
                D169Totalvalue = parseInt(D169Totalvalue) + parseInt(D169Cycle);

                var C52Cycle = $("#<%= grdRescan.ClientID %> input[id*='" + gvId + "_txtC52Cycle" + CycleNo + "']").val();
                if (C52Cycle == undefined) {
                    C52Cycle = 0;
                }
                else if (C52Cycle == '') {
                    C52Cycle = 0;
                }
                C52Totalvalue = parseInt(C52Totalvalue) + parseInt(C52Cycle);

            }
            //debugger;
            if (Checked == 0) {
                jQuery.facebox("Atleast one Rescan Qty must be checked of the currrent cycle!");
                return false;
            }
            var RescanQty_C45 = $("#hdnRescanQty_C45").val();

            if (parseInt(C45Totalvalue) < parseInt(RescanQty_C45)) {
                jQuery.facebox("C45 Mark as Rescan qty " + C45Totalvalue + ", can not be less than Rescan entry " + RescanQty_C45 + "!");
                return false;
            }
            var RescanQty_C47 = $("#hdnRescanQty_C47").val();

            if (parseInt(C47Totalvalue) < parseInt(RescanQty_C47)) {
                jQuery.facebox("C47 Mark as Rescan qty " + C47Totalvalue + ", can not be less than Rescan entry " + RescanQty_C47 + "!");
                //                jQuery.facebox("Total Mark as Rescan qty, can not be less than Rescan entry!");                
                return false;
            }

            var RescanQty_D169 = $("#hdnRescanQty_D169").val();

            if (parseInt(D169Totalvalue) < parseInt(RescanQty_D169)) {
                jQuery.facebox("D169 Mark as Rescan qty " + D169Totalvalue + ", can not be less than Rescan entry " + RescanQty_D169 + "!");
                //                jQuery.facebox("Total Mark as Rescan qty, can not be less than Rescan entry!");                
                return false;
            }

            var RescanQty_C52 = $("#hdnRescanQty_C52").val();

            if (parseInt(C52Totalvalue) < parseInt(RescanQty_C52)) {
                jQuery.facebox("C52 Mark as Rescan qty " + C52Totalvalue + ", can not be less than Rescan entry " + RescanQty_C52 + "!");
                //                jQuery.facebox("Total Mark as Rescan qty, can not be less than Rescan entry!");                
                return false;
            }

            var id = evnt.id;
            $("#" + id).hide();
        }


        function validNumeric(evnt) {
            // debugger;
            return false;
        }

        function ValidateAddCycle() {
            //debugger;
            var RescanChecked = 0;
            var CycleNo = $("#lblCycleNo").html();

            var RowId = 0;
            var gvId;
            var GridRow = $(".grdRescanRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var chkCycle = "#<%= grdRescan.ClientID %>_" + gvId + "_chkCycle" + CycleNo;
                if ($(chkCycle).is(':checked')) {
                    if ($(chkCycle).is(":disabled")) {
                        RescanChecked = 1;
                    }
                }
            }
            var FaultChecked = 0;
            RowId = 0;
            gvId = '';
            var FaultRow = $(".gvFaultRow").length;
            for (var row = 1; row <= FaultRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var chkAction = "#<%= grdFaultTypeRescan.ClientID %>_" + gvId + "_chkAction" + CycleNo;

                if ($(chkAction).is(':checked')) {
                    FaultChecked = 1;
                }
            }


            if (RescanChecked == 0) {
                jQuery.facebox("Last cycle must be saved!");
                return false;
            }
            else if (FaultChecked == 0) {
                jQuery.facebox("atleast one fault of last cycle must be saved !");
                return false;
            }
            else {
                $('#btnAddCycle').hide();

            }


        }

        function validateAndHighlight() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid) {
                        ctrl.style.borderColor = '#FF0000';
                        //ctrl.style.backgroundColor = '#fce697';
                    }
                    else {
                        ctrl.style.borderColor = '';
                        ctrl.style.backgroundColor = '';
                    }
                }
            }
        }
        function UpdateAllCheckBox(elem, type) {
            //debugger;
            var result = 0;
            var OrderDetailId = $("#hdnOrderdetsilid").val();

            if (elem.checked) {
                $(".SelectAllCheckBox" + type + " input").each(function () {
                    //debugger;
                    this.checked = elem.checked;
                    var FaultID = $(this).closest("tr").find(".hidden-FaultID").val();
                    proxy.invoke("UpdateSelectCheckBox", { IsCheked: 1, FaultID: FaultID, OrderDetailId: OrderDetailId, type: type },
                    result = 1
                   );
                });
            }
            else {
                $(".SelectAllCheckBox" + type + " input").each(function () {
                    //debugger;                  
                    $(this).removeAttr("checked");
                    var FaultID = $(this).closest("tr").find(".hidden-FaultID").val();
                    proxy.invoke("UpdateSelectCheckBox", { IsCheked: 0, FaultID: FaultID, OrderDetailId: OrderDetailId, type: type },
                    result = 1
                );
                });
            }
            if (result == 1) {
                jQuery.facebox('Data saved sucessfully.');
            }
        }
        function UpdateSelectCheckBox(elem, type) {
            //debugger;
            var Ids = elem.id;
            var FaultID = $("#" + Ids).closest("tr").find(".hidden-FaultID").val();
            var OrderDetailId = $("#hdnOrderdetsilid").val();
            var IsCheked = 0;
            if (elem.checked) {
                IsCheked = 1;
            }
            else {
                IsCheked = 0;
            }
            proxy.invoke("UpdateSelectCheckBox", { IsCheked: IsCheked, FaultID: FaultID, OrderDetailId: OrderDetailId, type: type },
                         function (result) {
                             //jQuery.facebox('Data saved sucessfully.');
                         });
            //            if ($(".SelectAllCheckBox input").length == $(".SelectAllCheckBox input:checked").length) {
            //                $("#grdFaultTypeRescan_ctl01_chkboxSelectAll1").attr("checked", "checked");
            //            } else {
            //                $("#grdFaultTypeRescan_ctl01_chkboxSelectAll1").removeAttr("checked");
            //            }
        }

        function chechZero(evt) {
            var val = parseInt(evt.value);
            if (val == 0) {
                jQuery.facebox("Zero is not valid.");
                evt.value = "";
                evt.focus();
            }
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function isNumberKeyfloat(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            return true;
        }

        function checkQuantity(evnt) {
            //debugger;
            var id = evnt.id;
            var Failqty = $("#" + id).parent().next().find("input[type='text']").val();
            if (Failqty != "") {
                var thisval = parseFloat(evnt.value.trim());
                var failval = parseFloat(Failqty.trim());
                if (thisval < failval) {
                    jQuery.facebox("Fail qty. can not be greater than rescanned qty.");
                    $("#" + id).closest("table").closest("tr").find("td:eq(4)").find("input").val("");
                    evnt.focus();
                    return;
                }
            }
            var Quantity = $("#" + id).parent().prev().find("span").text();
            Quantity = Quantity.replace(',', '')
            if (Quantity.trim() == "") {
                Quantity = "0";
            }
            var alloc = parseFloat(evnt.value.trim());
            var qty = parseFloat(Quantity.trim());
            if (alloc > qty) {
                jQuery.facebox("Rescanned qty. can not be greater than pending rescan qty!");
                evnt.value = "";
                evnt.focus();
            }
        }

        function EnableFaults(evnt) {
            //debugger;
            var id = evnt.id;
            var Faultstxt = $("#" + id).parent().next().find("input[type='text']");
            var FailVal = $("#" + id).val();
            if (FailVal == '')
                FailVal = 0;

            if (FailVal != 0) {
                Faultstxt.removeAttr('disabled');
            }
            else {
                Faultstxt.attr("disabled", "disabled");
            }
        }

        function AddFaults(elem) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[1].substr(3);
            var TotalFault = 0;
            var gvId = '';
            var FaultRow = document.getElementById("grdRescanFillData_ctl" + cId + "_dlstFaults").rows.length;
            for (var row = 0; row < FaultRow; row++) {
                if (row < 10)
                    gvId = 'ctl0' + row;
                else
                    gvId = 'ctl' + row;

                var FaultVal = document.getElementById("grdRescanFillData_ctl" + cId + "_dlstFaults_" + gvId + "_txtFaultsQty").value;
                if (FaultVal != "") {
                    TotalFault = parseInt(TotalFault) + parseInt(FaultVal);
                }
            }

            var Failqty = $("#<%= grdRescanFillData.ClientID %> input[id*='" + cId + "_txtFailQty" + "']").val();

            if (parseInt(TotalFault) < parseInt(Failqty)) {
                jQuery.facebox("Total fault value can not be less than fail qty!");
                //                $("#" + Ids).val('');
                return false;
            }

        }


        function Submitme(evnt) {
            // debugger;
            var id = evnt.id;
            $("#" + id).hide();
        }

        function initializer() {
            $(".Faults").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100 });
            $(".Faults").result(function () {
                //debugger;            
                var This = $(this);
                var Faults = $(this).val();
                var FaultId = $(this).attr('id');
                //ValidateFaults(Faults, This);
            });
        };

        function CheckValidFault(elem) {
            //debugger;        
            var Faults = elem.value;
            var SearchContext = 'NatureOfFaults';
            if (Faults != '') {
                proxy.invoke("check_for_auto_complete", { searchValue: Faults, searchContext: SearchContext },
            function (result) {
                //debugger;
                if (result == '0') {
                    elem.value = '';
                }
                else {
                    ValidateFaults(Faults, elem);
                }
            });
            }
        }
        function ValidateFaults(Faults, This) {
            //debugger;
            $(".FaultDesc").each(function () {
                //debugger;
                var txtFaults = $(this).text();
                if (txtFaults.trim() == Faults.trim()) {
                    //debugger;
                    jQuery.facebox('Faults is already exist!');
                    $("#txtFaultDescription").val('');
                }
            });
        }


        function ValidateTxtFaults() {
            var txtFaultDescription = $("#txtFaultDescription").val();
            if (txtFaultDescription == '') {
                jQuery.facebox('Please add faults!');
                $("#txtFaultDescription").focus();
                return false;
            }
        }

        function RescanChange() {
            //debugger;
            $(".clsBtnddlRescan").click();
        }

        function ValidateRescanFill(evnt) {
            //debugger;       
            var RowId = 0;
            var gvId;
            var GridRow = $(".grdRescanFillRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var TotalFault = -1;

                var FailQty = $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtFailQty" + "']").val();
                if (FailQty == '')
                    FailQty = 0;

                if (FailQty > 0) {
                    if (document.getElementById("grdRescanFillData_" + gvId + "_dlstFaults") != null) {
                        TotalFault = 0;

                        //                        var FaultRow = document.getElementById("grdRescanFillData_" + gvId + "_dlstFaults").rows.length;
                        //                        var faultId = '';
                        //                        for (var count = 0; count < FaultRow; count++) {
                        //                            if (count < 10)
                        //                                faultId = 'ctl0' + count;
                        //                            else
                        //                                faultId = 'ctl' + count;

                        //                            var FaultVal = document.getElementById("grdRescanFillData_" + gvId + "_dlstFaults_" + faultId + "_txtFaultsQty").value;
                        //                            if (FaultVal != "") {
                        //                                TotalFault = parseInt(TotalFault) + parseInt(FaultVal);
                        //                            }
                        //                        }
                        //                        if (TotalFault <= 0) {
                        //                            jQuery.facebox('Must be add some faults!');
                        //                            return false;
                        //                        }
                        //                        else if (parseInt(TotalFault) < parseInt(FailQty)) {
                        //                            jQuery.facebox("Total fault value can not be less than fail qty!");
                        //                            return false;
                        //                        }
                    }
                }
                //debugger;
                var txtRescannedQty = $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtRescannedQty" + "']").val();
                var txtManPower = $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtManPower" + "']").val();
                var txtWorkingHrs = $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtWorkingHrs" + "']").val();
                var txtBreakDown = $("#<%= grdRescanFillData.ClientID %> textarea[id*='" + gvId + "_txtBreakDown" + "']").val();

                if (txtRescannedQty == '')
                    txtRescannedQty = 0;

                if (txtManPower == '')
                    txtManPower = 0;

                if (txtWorkingHrs == '')
                    txtWorkingHrs = 0;

                if (parseInt(txtRescannedQty) > 0) {

                    if (parseInt(TotalFault) < 0) {
                        jQuery.facebox('There is not any faults available, Please add some faults for this cycle!');
                        return false;
                    }

                    if (parseInt(txtManPower) == 0) {
                        jQuery.facebox('Please enter man power.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtManPower" + "']").focus();
                        return false;
                    }
                    if (parseInt(txtWorkingHrs) == 0) {
                        jQuery.facebox('Please enter working hrs.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtWorkingHrs" + "']").focus();
                        return false;
                    }
                    if (txtBreakDown == '') {
                        jQuery.facebox('Please enter break down remarks.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtBreakDown" + "']").focus();
                        return false;
                    }
                }
                else {
                    if (parseInt(txtManPower) > 0) {
                        jQuery.facebox('Please enter Pass Qty.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtRescannedQty" + "']").focus();
                        return false;
                    }
                    if (parseInt(txtWorkingHrs) > 0) {
                        jQuery.facebox('Please enter Pass Qty.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtRescannedQty" + "']").focus();
                        return false;
                    }
                    if (txtBreakDown != '') {
                        jQuery.facebox('Please enter Pass Qty.');
                        $("#<%= grdRescanFillData.ClientID %> input[id*='" + gvId + "_txtRescannedQty" + "']").focus();
                        return false;
                    }
                }
            }

            var id = evnt.id;
            $("#" + id).hide();
        }
        $(document).ready(function () {
            $(".removeborder").removeAttr('border');
        });

    </script>
    <script language="javascript" type="text/javascript">
        //        $(document).ready(function () {
        //            for (var i = 1; i <= 8; i++) {
        //                if ($(".SelectAllCheckBox" + i + " input").length == $(".SelectAllCheckBox" + i + " input:checked").length) {
        //                    $("#grdFaultTypeRescan_ctl01_chkboxSelectAll" + i).attr("checked", "checked");
        //                }
        //            }
        //        });
        function HideFunction(ele) {
            // debugger;
            var conVal = $(ele).attr('CustomData');
            if (conVal == "1") {
                $('#td10').hide();
            }
            if (conVal == "2") {
                $('#td5').hide();
            }
            if (conVal == "3") {
                $('#td6').hide();
            }
            if (conVal == "4") {
                $('#td2').hide();
            }
        }

</script>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlupdt" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:HiddenField runat="server" ID="hfPosition" Value="" />
 <div style="margin:0 auto;">
        <table border="0" class="tablewidth" cellpadding="0" cellspacing="0"" align="center" style="padding: 0px 5px;max-width:1500px; overflow: auto;">
        <tr><td>
    <table cellpadding="0" style="min-width:1000px; margin-bottom: 10px;"  class="bottoborder" cellspacing="0" align="left">
        <tr>
            <td colspan="10">
                <h3 style="background: #3a5795; padding: 2px 0px;font-size:17px; color: #fff; text-align: center; margin-bottom: 0;">
                    Production Detail
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="color: gray; font-weight: bold; padding: 5px 0px 5px 0px;"
                valign="top">
                Serial Number :-&nbsp;
                <asp:Label ID="ltrlSerialNumber" ForeColor="Black" runat="server" Style="text-transform: uppercase;"></asp:Label>&nbsp;&nbsp;
                Style Number :-&nbsp;<asp:Label ID="ltrlStyleNumber" ForeColor="Black" runat="server" Style="text-transform: uppercase;"></asp:Label>&nbsp;&nbsp;
                Order Qty :-&nbsp;
                <asp:Label ID="ltrlQuantity" ForeColor="Black" runat="server"></asp:Label>&nbsp;Pcs.
                <asp:HiddenField ID="CheckValue" runat="server" />
                <asp:HiddenField ID="UncheckValue" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="min-width: 170px;" id="td1" valign="top">
                <asp:GridView ID="grdProductionDetails" Font-Bold="true" runat="server" AutoGenerateColumns="false"
                    RowStyle-Font-Size="12px" Width="100%" DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true"
                    ShowFooter="false" EmptyDataRowStyle-ForeColor="Red" OnRowDataBound="grdProductionDetails_RowDataBound" EmptyDataText="There is no history for this contract."
                    CssClass="border2 removeborder cutqtyborleft">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Date" HeaderStyle-Width="90px"
                            ItemStyle-Width="70px" HeaderStyle-Height="39px" HeaderStyle-CssClass="addborder">
                            <ItemTemplate>
                                <%# Eval("Date").ToString() == "Grand Total" ? Eval("Date") : Convert.ToDateTime(Eval("Date")).ToString("dd MMM (ddd)")%>
                                <asp:HiddenField ID="hdndate" runat="server" Value='<%# Eval("Date") %>'/>
                            </ItemTemplate>
                            <ItemStyle ForeColor="#aba5a5" Font-Bold="true" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="addborder" HeaderText="Cut Qty." HeaderStyle-Width="50px"
                            ItemStyle-Width="40px" HeaderStyle-Height="39px">
                            <ItemTemplate>                              
                                <%# Eval("CutQty", "{0:#,##}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cut Rdy Qty."
                           
                            HeaderStyle-Width="50px" HeaderStyle-CssClass="addborder" ItemStyle-Width="50px" HeaderStyle-Height="39px">
                            <ItemTemplate>                           
                                <%# Eval("CutReadyQty", "{0:#,##}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td10" runat="server" valign="top">
                <asp:GridView ID="grdoutcut" Font-Bold="true" runat="server" AutoGenerateColumns="false"
                    RowStyle-Font-Size="12px" Width="100%" DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true"
                    ShowFooter="false" EmptyDataRowStyle-ForeColor="Red" EmptyDataText="There is no history for this contract."
                    CssClass="border2 removeborder">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="OH Cut Issue <span style='position: relative; top: -22px; cursor: pointer;float: right; right: 5px;' CustomData='1' onclick ='HideFunction(this)'>...</span>" HeaderStyle-Width="50px"
                            ItemStyle-Width="50px" HeaderStyle-CssClass="addborder hocutqty" HeaderStyle-Height="39px">
                            <ItemTemplate>
                                <%# Eval("CutIssue", "{0:#,##}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td2" runat="server" valign="top" visible="false">
                <div class="fontsizehaul" style="background: #dddfe4; font-size: 10px; font-weight: bold; color: #575759;
                    border-top: 1px solid #999;border-right:1px solid #999; text-align: center; height: 23px;line-height: 22px;">
                    Half Stitch Detail <span style='position: relative;top: -7px;cursor: pointer;float: right;right: 5px;color:Blue;font-size:18px;' CustomData='4' onclick ='HideFunction(this)'>...</span></div>
                <asp:GridView ID="grdSAM" runat="server" DataFormatString="{0:#,##}" AutoGenerateColumns="true"
                    Font-Bold="true" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder fhalfqty" HeaderStyle-Height="16px"
                    ShowFooter="false" OnDataBound="grdSAM_DataBound" OnRowDataBound="grdSAM_RowDataBound">
                    <RowStyle CssClass="borderbottom borderbottom-mid" />
                </asp:GridView>
            </td>
            <td id="td5" runat="server" valign="top">
                <asp:GridView ID="grdhalfstitchInHouse" runat="server" DataFormatString="{0:#,##}"
                    Font-Bold="true" AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%"
                    CssClass="border2 removeborder" ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="<div><span style='position:relative;top:-15px;right:5px;float: right;cursor:pointer;font-size:18px;color:blue;' CustomData='2' onclick ='HideFunction(this)'>...</span></div><span>Full Stitch I.H.</span>" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="85px" HeaderStyle-Height="39px">
                            <ItemTemplate>                             
                                <asp:Label ID="lblHalfstcInHouse" Text='<%# Eval("HalfStitchInHouseQty", "{0:#,##}")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td6" runat="server" valign="top">
                <asp:GridView ID="grdhalfstitchOuthouse" runat="server" DataFormatString="{0:#,##}"
                    Font-Bold="true" AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%"
                    CssClass="border2 removeborder" ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Full stitch O.H. <span style='position:relative;top:-22;cursor:pointer;float: right;right:5px' CustomData='3' onclick ='HideFunction(this)'>...</span>"
                           HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="70px" HeaderStyle-Height="39px">
                            <ItemTemplate>
                                <%--<asp:HiddenField ID="hdnDate" Value='<%# Eval("Date")%>' runat="server"  /> --%>
                                <asp:Label ID="lblHalfstcOutStch" Text='<%# Eval("HalfStitchOutHouseQty", "{0:#,##}")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>


            <td id="td3" runat="server" valign="top">
                <asp:GridView ID="grdFinish" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Total Full Stitch"
                            HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="70px" HeaderStyle-Height="39px">
                            <ItemTemplate>
                                <%# Eval("StitchQty", "{0:#,##}")%>
                            </ItemTemplate>
                        </asp:TemplateField>                     
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td4" style="display: none" runat="server" valign="top">
                <asp:GridView ID="grdva" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2"
                    ShowFooter="false" OnRowDataBound="grdva_RowDataBound">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="VA Qty" HeaderStyle-Width="50px"
                             HeaderStyle-CssClass="minWidthdate" HeaderStyle-Height="39px">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnDate" Value='<%# Eval("Date")%>' runat="server" />                            
                                <asp:Label ID="lblVa" Text='<%# Eval("Date").ToString() == "Grand Total" ? Eval("Date") : Convert.ToDateTime(Eval("Date")).ToString("dd MMM (ddd)")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td7" runat="server" valign="top">
                <asp:GridView ID="grdv1" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="50px"
                            HeaderStyle-Height="39px">
                            <ItemTemplate>                                
                                <asp:Label ID="lblv1" Text='<%# Eval("V1Qty", "{0:#,##}")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td8" runat="server" valign="top">
                <asp:GridView ID="grdv2" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="50px"
                            HeaderStyle-Height="39px">
                            <ItemTemplate>                               
                                <asp:Label ID="lblv2" Text='<%# Eval("V2Qty", "{0:#,##}")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td11" runat="server" valign="top">
                <asp:GridView ID="grdv3" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="50px"
                            HeaderStyle-Height="39px">
                            <ItemTemplate>                               
                                <asp:Label ID="lblv2" Text='<%# Eval("V3Qty", "{0:#,##}")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td12" runat="server" valign="top">
                <asp:GridView ID="grdv4" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="50px"
                            HeaderStyle-Height="39px">
                            <ItemTemplate>                               
                                <asp:Label ID="lblv2" Text='<%# Eval("V4Qty", "{0:#,##}")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td13" runat="server" valign="top">
                <asp:GridView ID="grdv5" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="minWidthcutqty addborder" ItemStyle-Width="50px"
                            HeaderStyle-Height="39px">
                            <ItemTemplate>                               
                                <asp:Label ID="lblv2" Text='<%# Eval("V5Qty", "{0:#,##}")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="td9" runat="server" valign="top">
                <asp:GridView ID="grdfinshs" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder finqty"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Finish Qty."
                            HeaderStyle-CssClass="minWidthfinqty addborder " HeaderStyle-Height="39px">
                            <ItemTemplate>
                                <%# Eval("FinishQty", "{0:#,##}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
             <td id="tddoonline"  valign="top">
                <asp:GridView ID="grddoonline" runat="server" Font-Bold="true"
                    AutoGenerateColumns="false" OnRowDataBound="grddoonline_RowDataBound" OnDataBound="grddoonline_DataBound" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CQD insp Date"
                            HeaderStyle-CssClass="minWidthcoddate addborder" HeaderStyle-Height="39px" >
                            <ItemTemplate>
                               <asp:Label ID="lbldoonlinefail"  Font-Size="9px" Visible="false" CssClass="OnlineTooltip" runat="server" Text='<%# Eval("OnLineFailDate") %>'></asp:Label>
                               <asp:HiddenField ID="hdnfsilcounts" runat="server" Value='<%# Eval("IsDoOnlie_Rescan") %>' />
                               <asp:HiddenField ID="hdnQualityID" runat="server" Value='<%# Eval("QualityControlID") %>' />
                               <asp:HiddenField ID="hdndate" runat="server" Value='<%# Eval("Date") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignLeft" />
                        </asp:TemplateField>
                          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="QC Fail%" HeaderStyle-CssClass="minWidthfinqty addborder"
                            ItemStyle-Width="50px" HeaderStyle-Height="20px">
                            <ItemTemplate>
                               <asp:Label ID="lbldoonlinefailss" CssClass="tooltip" ForeColor="Red" runat="server" Text='<%# Eval("fail") %>'></asp:Label>
                              
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td id="tdRescan" runat="server" valign="top">
                <asp:HiddenField ID="hdnOrderdetsilid" runat="server" />
                <asp:HiddenField ID="hdnRescanQty_C47" runat="server" />
                <asp:HiddenField ID="hdnRescanQty_C45" runat="server" />
                  <asp:HiddenField ID="hdnRescanQty_D169" runat="server" />
                <asp:GridView ID="grdRescan" runat="server" DataFormatString="{0:#,##}" Font-Bold="true"
                    AutoGenerateColumns="false" RowStyle-Font-Size="12px" Width="100%" CssClass="border2 removeborder"
                    ShowFooter="false" onrowdatabound="grdRescan_RowDataBound">
                    <RowStyle CssClass="borderbottom grdRescanRow" />
                    <Columns>
                     <%--Cycle 1--%>
                        <asp:TemplateField HeaderStyle-Height="39px" Visible="false" HeaderStyle-CssClass="minWidth">
                            <HeaderTemplate>
                                Rescan Cl1<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader1" Enabled="false" onclick="ValidateRescanCycle_Header(this, 1)" runat="server"  style="margin:0px 0px;cursor:pointer"/> C45 &nbsp;|&nbsp;C47|&nbsp;D169</div>                                
                            </HeaderTemplate>
                            <ItemTemplate>                                
                                <asp:HiddenField ID="hdnC45_FinishQty" runat="server" Value='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("C45_FinishQty"))) ? Eval("C45_FinishQty") : ""%>' />
                                <asp:HiddenField ID="hdnC47_FinishQty" runat="server" Value='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("C47_FinishQty"))) ? Eval("C47_FinishQty") : ""%>' />
                                 <asp:HiddenField ID="hdnD169_FinishQty" runat="server" Value='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("D169_FinishQty"))) ? Eval("D169_FinishQty") : ""%>' />
                                  <%--<asp:HiddenField ID="hdnC52_FinishQty" runat="server" Value='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("C52_FinishQty"))) ? Eval("C52_FinishQty") : ""%>' />--%>
                                <asp:HiddenField ID="hdnUnit1" runat="server" Value='<%# Eval("UnitId1") %>' />
                                <asp:HiddenField ID="hdnUnit2" runat="server" Value='<%# Eval("UnitId2") %>' />
                                 <asp:HiddenField ID="hdnUnit3" runat="server" Value='<%# Eval("UnitId3") %>' />
                                <asp:HiddenField ID="hdnRescanDate" runat="server" Value='<%# Eval("Date") %>' />                              
                                <div id="dvC45_1" runat="server" class="rescanac" style="float:left;width:57px !important">
                                <asp:CheckBox ID="chkCycle1" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 1)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle1" runat="server" style="margin-right:3px" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 1);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:3px;" class="inputboxqty">
                                <asp:TextBox ID="txtC47Cycle1" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 1);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                      <div style="float:left; padding-right:3px;" class="inputboxqty">
                                <asp:TextBox ID="txtD169Cycle1" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 1);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>
                                  <%--  <div  style="float:left; padding-right:3px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle1" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 1);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--Cycle 2--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                Rescan Cl2<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader2" Enabled="false" onclick="ValidateRescanCycle_Header(this, 2)" runat="server" /> C45 &nbsp;|&nbsp; C47 |&nbsp; D169|&nbsp;C52</div>                                
                            </HeaderTemplate>
                        <ItemTemplate>
                        <div id="dvC45_2" runat="server" class="rescanac" style="float:left;">                            
                              <asp:CheckBox ID="chkCycle2" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 2)"  CssClass="CheckboxDisable2"/>

                                <asp:TextBox ID="txtC45Cycle2" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 2);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle2" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 2);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                      <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle2" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 2);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                    <%--<div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle2" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 2);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>

                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 3--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                  Rescan Cl3<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader3" Enabled="false" onclick="ValidateRescanCycle_Header(this, 3)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>
                         <div id="dvC45_3" runat="server" class="rescanac" style="float:left;">                               
                              <asp:CheckBox ID="chkCycle3" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 3)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle3" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 3);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle3" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 3);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                       <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle3" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 3);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                 <%--   <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle3" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 3);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>

                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 4--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl4<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader4" Enabled="false" onclick="ValidateRescanCycle_Header(this, 4)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>       
                         <div id="dvC45_4" runat="server" class="rescanac" style="float:left;">                         
                             <asp:CheckBox ID="chkCycle4" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 4)" CssClass="CheckboxDisable4"/>

                                <asp:TextBox ID="txtC45Cycle4" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 4);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle4" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 4);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle4" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 4);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                    <%--<div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle4" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 4);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>

                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 5--%>
                      <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                Rescan Cl5<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader5" Enabled="false" onclick="ValidateRescanCycle_Header(this, 5)" runat="server" /> C45 &nbsp;|&nbsp;C47|&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>    
                         <div id="dvC45_5" runat="server" class="rescanac" style="float:left;">                           
                             <asp:CheckBox ID="chkCycle5" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 5)"  CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle5" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 5);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle5" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 5);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>

                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle5" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 5);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                   <%-- <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle5" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 5);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>

                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 6--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl6<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader6" Enabled="false" onclick="ValidateRescanCycle_Header(this, 6)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>      
                         <div id="dvC45_6" runat="server" class="rescanac" style="float:left;">                          
                             <asp:CheckBox ID="chkCycle6" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 6)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle6" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 6);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle6" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 6);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle6" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 6);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                    <%--<div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle6" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 6);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 7--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl7<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader7" Enabled="false" onclick="ValidateRescanCycle_Header(this, 7)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>     
                         <div id="dvC45_7" runat="server" class="rescanac" style="float:left;">                           
                             <asp:CheckBox ID="chkCycle7" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 7)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle7" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 7);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle7" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 7);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle7" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 7);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                   <%-- <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle7" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 7);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 8--%>
                       <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                  Rescan Cl8<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader8" Enabled="false" onclick="ValidateRescanCycle_Header(this, 8)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>
                             <div id="dvC45_8" runat="server" class="rescanac" style="float:left;">    
                             <asp:CheckBox ID="chkCycle8" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 8)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle8" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 8);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle8" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 8);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                      <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle8" runat="server" Width="30px" Height="10px" MaxLength="4" Visible="false" Enabled="false" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 8);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>
<%--
                                    <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle8" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 8);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <%--Cycle 9--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                  Rescan Cl9<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader9" Enabled="false" onclick="ValidateRescanCycle_Header(this, 9)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>
                             <div id="dvC45_9" runat="server" class="rescanac" style="float:left;">    
                             <asp:CheckBox ID="chkCycle9" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 9)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle9" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 9);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle9" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 9);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle9" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 9);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                    <%--<div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle9" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 9);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <%--Cycle 10--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl10<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader10" Enabled="false" onclick="ValidateRescanCycle_Header(this, 10)" runat="server" /> C45 &nbsp;|&nbsp;C47|&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>     
                         <div id="dvC45_10" runat="server" class="rescanac" style="float:left;">                           
                             <asp:CheckBox ID="chkCycle10" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 10)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle10" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 10);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle10" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 10);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                      <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle10" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 10);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                    <%--<div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle10" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 10);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>

                        <%--Cycle 11--%>
                       <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl11<br />
                                <div style="float:;" class="rescanac reci11"><asp:CheckBox ID="chkCycleHeader11" Enabled="false" onclick="ValidateRescanCycle_Header(this, 11)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>
                            <div id="dvC45_11" runat="server" class="rescanac" style="float:left;">    
                             <asp:CheckBox ID="chkCycle11" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 11)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle11" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 11);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle11" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 11);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                      <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle11" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 11);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                   <%-- <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle11" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 11);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>

                        <%--Cycle 12--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                  Rescan Cl12<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader12" Enabled="false" onclick="ValidateRescanCycle_Header(this, 12)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>
                             <div id="dvC45_12" runat="server" class="rescanac" style="float:left;">    
                             <asp:CheckBox ID="chkCycle12" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 12)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle12" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 12);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle12" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 12);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                    <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle12" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 12);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                  <%--  <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle12" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 12);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>

                         <%--Cycle 13--%>
                       <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                Rescan Cl13<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader13" Enabled="false" onclick="ValidateRescanCycle_Header(this, 13)" runat="server" /> C45 &nbsp;|&nbsp;C47|&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>  
                         <div id="dvC45_13" runat="server" class="rescanac" style="float:left;">                              
                             <asp:CheckBox ID="chkCycle13" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 13)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle13" runat="server" Width="30px" Visible="false" Enabled="false" Height="10px" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 13);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle13" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 13);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle13" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 13);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                  <%--  <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle13" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 13);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>

                         <%--Cycle 14--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                 Rescan Cl14<br />
                                <div style="float:;" class="rescanac"><asp:CheckBox ID="chkCycleHeader14" Enabled="false" onclick="ValidateRescanCycle_Header(this, 14)" runat="server" /> C45 &nbsp;|&nbsp;C47 |&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>   
                         <div id="dvC45_14" runat="server" class="rescanac" style="float:left;">                            
                             <asp:CheckBox ID="chkCycle14" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 14)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle14" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 14);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle14" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 14);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>

                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle14" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 14);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                 <%--   <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle14" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 14);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>

                         <%--Cycle 15--%>
                        <asp:TemplateField HeaderStyle-CssClass="minWidth" HeaderStyle-Height="39px" Visible="false">
                        <HeaderTemplate>                               
                                  Rescan Cl15<br />
                                <div style="float:;" class="rescanl15"><asp:CheckBox ID="chkCycleHeader15" Enabled="false" onclick="ValidateRescanCycle_Header(this, 15)" runat="server" /> C45 &nbsp;|&nbsp;C47|&nbsp;D169|&nbsp;C52</div> 
                            </HeaderTemplate>
                        <ItemTemplate>   
                         <div id="dvC45_15" runat="server" class="rescanac"  style="float:left;">                             
                             <asp:CheckBox ID="chkCycle15" runat="server" Visible="false" Enabled="false" onclick="ValidateRescanCycle(this, 15)" CssClass="CheckboxDisable1"/>

                                <asp:TextBox ID="txtC45Cycle15" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC45Quantity(this, 15);"
                                    title="C-45" placeholder="C-45"></asp:TextBox></div>
                                <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtC47Cycle15" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC47Quantity(this, 15);"
                                    title="C-47" placeholder="C-47" ></asp:TextBox></div>
                                     <div style="float:left; padding-right:5px;" class="inputboxqty">

                                <asp:TextBox ID="txtD169Cycle15" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkD169Quantity(this, 15);"
                                    title="D 169" placeholder="D 169" ></asp:TextBox></div>

                                   <%-- <div style="float:left; padding-right:5px;" class="inputboxqty">
                                <asp:TextBox ID="txtC52Cycle115" runat="server" Width="30px" Height="10px" Visible="false" Enabled="false" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="return checkC52Quantity(this, 15);"
                                    title="C 52" placeholder="C-52" ></asp:TextBox></div>--%>
                        </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </td>          

        </tr>
        <tr>
            <td colspan="3" style="border-bottom: 0px; padding-top:5px;">
                <asp:Label ID="lblCycle" runat="server" Text="Cycle Count:"></asp:Label>&nbsp;
                <asp:Label ID="lblCycleNo" runat="server" Text="0"></asp:Label>&nbsp;
                <asp:Button ID="btnAddCycle" OnClientClick="javascript:return ValidateAddCycle();" runat="server" CssClass="submit" 
                    Text="Add New Cycle" onclick="btnAddCycle_Click" />
            </td>
            <td style="padding-top:5px;" align="right" colspan="9">
                <asp:Button ID="btnRescanCheckSubmit" runat="server" Text="Submit" CssClass="submit"
                    OnClick="btnRescanCheckSubmit_Click" OnClientClick="javascript:return ValidateRescanSubmit(this);" />
                &nbsp;
                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
                   OnClientClick="javascript:window.open('','_self').close();" />
            </td>
        </tr>
    </table>
    <br />
     <br />
   
    <table cellpadding="0" cellspacing="0" align="center"  style="min-width:1000px;margin-top:10px;" id="tableFaultTypeRescan" runat="server"
                visible="false">
                <tr>
                    <td>
                        <asp:GridView ID="grdFaultTypeRescan" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdFaultTypeRescan_rowdatabound"
                            EmptyDataText="No Record found." EmptyDataRowStyle-HorizontalAlign="Center" CssClass="border2"
                            Width="100%">
                            <RowStyle CssClass="gvFaultRow" />
                            <Columns>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr><td style="text-align:center;height:19px; font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblFaultSummery" runat="server" Text="Fault Summary"></asp:Label>
                                        </td></tr>
                                    <tr><td style="height:15px;">&nbsp;
                                        </td></tr>
                                    </table>                                    
                                    </HeaderTemplate>
                                    <HeaderStyle  />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFaultDescription" runat="server" CssClass="FaultDesc" Style=" padding-left:5px; color: Black; font-weight: normal;font-size:11px;"
                                            Text='<%# Eval("FaultDescription") %>'></asp:Label>                                                                                    
                                        <input type="hidden" id="hdnFaultId" class="hidden-FaultID" runat="server" value='<%# Eval("FaultID") %>' />
                                        <asp:HiddenField ID="hdnFlag" value='<%# Eval("Flag") %>' runat="server" />
                                        <asp:HiddenField ID="hdnFaultDone" value='<%# Eval("FaultDone") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="alignLeft" />
                                </asp:TemplateField>                               
                                <asp:TemplateField>
                                    <HeaderTemplate>  
                                      <table width="100%"  cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center; height:19px; font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblCQDPercent" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        CQD (Pcs Chkd.)</td></tr>
                                    </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>                  
                                             <asp:Label runat="server" Style="font-size:10px;" ID="lblOccurrence" ForeColor="Black"
                                            Text='<%# Eval("CQD") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center; height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblQCPercent" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        QC (Pcs Chkd.)</td></tr>
                                    </table>
                                    
                                    </HeaderTemplate>
                                    <ItemTemplate>                                     
                                             <asp:Label runat="server" Style="font-size:10px; color:Black;" ID="lblQc"
                                            Text='<%# Eval("QC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                     <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center; font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblTotalPercent" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center; height:15px;">
                                        Total (Pcs Chkd.)</td></tr>
                                    </table>                                    
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                             <asp:Label runat="server" Style="font-size:12px;color:Red;font-weight:bold;" ID="lbltotal"
                                            Text='<%# Eval("Total") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               <%-- Cycle 1--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px; height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr1" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center; height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll1" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 1)" runat="server" />  
                                        </td></tr>
                                    </table>                                  
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction1" Enabled="false" runat="server" CssClass="SelectAllCheckBox1" Checked='<%# Eval("RescanCycle1") %>' onclick="javascript:return UpdateSelectCheckBox(this, 1)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                  <%-- Cycle 2--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate> 
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px; height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr2" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center; height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll2" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 2)" runat="server" />   
                                        </td></tr>
                                    </table>                                    
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction2" Enabled="false" runat="server" CssClass="SelectAllCheckBox2" Checked='<%# Eval("RescanCycle2") %>' onclick="javascript:return UpdateSelectCheckBox(this, 2)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 3--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                     <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr3" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center; height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll3" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 3)" runat="server" />   
                                        </td></tr>
                                    </table>   
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction3" Enabled="false" runat="server" CssClass="SelectAllCheckBox3" Checked='<%# Eval("RescanCycle3") %>' onclick="javascript:return UpdateSelectCheckBox(this, 3)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 4--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>    
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr4" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center; height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll4" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 4)" runat="server" />   
                                        </td></tr>
                                    </table>                                      
                                                                             
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction4" Enabled="false" runat="server" CssClass="SelectAllCheckBox4" Checked='<%# Eval("RescanCycle4") %>' onclick="javascript:return UpdateSelectCheckBox(this, 4)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 5--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate> 
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center; min-width: 30px;height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr5" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;font-weight: normal;font-size:12px; height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll5" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 5)" runat="server" />   
                                        </td></tr>
                                    </table>                                         
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction5" Enabled="false" runat="server" CssClass="SelectAllCheckBox5" Checked='<%# Eval("RescanCycle5") %>' onclick="javascript:return UpdateSelectCheckBox(this, 5)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 6--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>    
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;font-weight: normal;min-width: 30px;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr6" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll6" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 6)" runat="server" />   
                                        </td></tr>
                                    </table>     
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction6" Enabled="false" runat="server" CssClass="SelectAllCheckBox6" Checked='<%# Eval("RescanCycle6") %>' onclick="javascript:return UpdateSelectCheckBox(this, 6)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 7--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate> 
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr7" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll7" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 7)" runat="server" />   
                                        </td></tr>
                                    </table>                                         
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction7" Enabled="false" runat="server" CssClass="SelectAllCheckBox7" Checked='<%# Eval("RescanCycle7") %>' onclick="javascript:return UpdateSelectCheckBox(this, 7)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <%-- Cycle 8--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr8" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll8" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 8)" runat="server" />   
                                        </td></tr>
                                    </table>                                         
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction8" Enabled="false" runat="server" CssClass="SelectAllCheckBox8" Checked='<%# Eval("RescanCycle8") %>' onclick="javascript:return UpdateSelectCheckBox(this, 8)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                               

                                <%-- Cycle 9--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>  
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr9" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll9" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 9)" runat="server" />   
                                        </td></tr>
                                    </table>                                        
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction9" Enabled="false" runat="server" CssClass="SelectAllCheckBox9" Checked='<%# Eval("RescanCycle9") %>' onclick="javascript:return UpdateSelectCheckBox(this, 9)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                  
                                <%-- Cycle 10--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>   
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;font-weight: normal;font-size:12px; height:19px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr10" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll10" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 10)" runat="server" />   
                                        </td></tr>
                                    </table>                                       
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction10" Enabled="false" runat="server" CssClass="SelectAllCheckBox10" Checked='<%# Eval("RescanCycle10") %>' onclick="javascript:return UpdateSelectCheckBox(this, 10)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                                <%-- Cycle 11--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>  
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr11" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll11" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 11)" runat="server" />   
                                        </td></tr>
                                    </table> 
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction11" Enabled="false" runat="server" CssClass="SelectAllCheckBox11" Checked='<%# Eval("RescanCycle11") %>' onclick="javascript:return UpdateSelectCheckBox(this, 11)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                                <%-- Cycle 12--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>   
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr12" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll12" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 12)" runat="server" />   
                                        </td></tr>
                                    </table>                                     
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction12" Enabled="false" runat="server" CssClass="SelectAllCheckBox12" Checked='<%# Eval("RescanCycle12") %>' onclick="javascript:return UpdateSelectCheckBox(this, 12)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                                <%-- Cycle 13--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>  
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr13" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll13" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 13)" runat="server" />   
                                        </td></tr>
                                    </table>                                        
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction13" Enabled="false" runat="server" CssClass="SelectAllCheckBox13" Checked='<%# Eval("RescanCycle13") %>' onclick="javascript:return UpdateSelectCheckBox(this, 13)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                                <%-- Cycle 14--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>   
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr14" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll14" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 14)" runat="server" />   
                                        </td></tr>
                                    </table>                                       
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction14" Enabled="false" runat="server" CssClass="SelectAllCheckBox14" Checked='<%# Eval("RescanCycle14") %>' onclick="javascript:return UpdateSelectCheckBox(this, 14)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                                <%-- Cycle 15--%>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate> 
                                      <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr><td style="text-align:center;min-width: 30px;height:19px;font-weight: normal;font-size:12px;" class="HeaderStyle2">
                                        <asp:Label ID="lblHdr15" runat="server" Text=""></asp:Label>
                                        </td></tr>
                                        <tr><td style="text-align:center;height:15px;">
                                        <asp:CheckBox ID="chkboxSelectAll15" Enabled="false" onclick="javascript:return UpdateAllCheckBox(this, 15)" runat="server" />   
                                        </td></tr>
                                    </table> 
                                    </HeaderTemplate>
                                    <ItemTemplate>                                   
                                        <asp:CheckBox ID="chkAction15" Enabled="false" runat="server" CssClass="SelectAllCheckBox15" Checked='<%# Eval("RescanCycle15") %>' onclick="javascript:return UpdateSelectCheckBox(this, 15)" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>  

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left; color: gray; font-weight: bold; padding: 5px 0px 5px 0px;">
                        <table cellpadding="0" cellspacing="0" class="border2" ><tr><td style="text-align:center;">Add new Fault</td><td>Add</td></tr>
                        <tr><td style="width:500px;">
                         <asp:TextBox ID="txtFaultDescription" runat="server" Style="text-align: left;
                                            text-transform: capitalize;" Text="" Width="100%" CssClass="Faults" onblur="javascript:return CheckValidFault(this);"></asp:TextBox>
                        </td><td style="width:40px; text-align:center;">
                          <asp:ImageButton ID="btnFaultInsert" OnClientClick="javascript:return ValidateTxtFaults();" ImageUrl="../../images/add-butt.png" runat="server" onclick="btnFaultInsert_Click" />
                        </td></tr></table>
                    </td>
                </tr>
            </table>

             <table border="0" id="tableRescandetails" runat="server" class="tablewidth" cellpadding="0" cellspacing="0" align="center"  style="min-width:1000px;margin-top:10px;" visible="false">
        <tr id="trFaultType" runat="server">
            <td>
                           
            </td>
        </tr>
        <tr id="trFaultTypeView" runat="server">
            <td style="width: 300px;">
                <asp:GridView ID="grdFultView" runat="server" HeaderStyle-CssClass="HeaderStyle1" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                    EmptyDataText="No Record found." EmptyDataRowStyle-HorizontalAlign="Center" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No." HeaderStyle-CssClass="fontsize">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblSno" runat="server" Text='<%#Container.DataItemIndex+1 %>' Style="text-align: center;
                                    color: Black;"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fault Description" HeaderStyle-CssClass="fontsize">
                            <ItemTemplate>
                                <asp:Label ID="lblSubFaultDescription" runat="server" Text='<%# Eval("FaultDescription") %>'
                                    Style="text-align: center; color: Black;"></asp:Label>
                                <asp:HiddenField ID="hdnScan_FaultDetailsID" runat="server" Value='<%# Eval("Scan_FaultDetailsID") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignLeft" />
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false" HeaderText="Cl1" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction1" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle1") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        <asp:TemplateField Visible="false" HeaderText="Cl2" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction2" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle2") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl3" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction3" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle3") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl4" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction4" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle4") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl5" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction5" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle5") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl6" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction6" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle6") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl7" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction7" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle7") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>     
                        <asp:TemplateField Visible="false" HeaderText="Cl8" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction8" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle8") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 

                        <asp:TemplateField Visible="false" HeaderText="Cl9" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction9" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle9") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>   
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl10" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction10" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle10") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl11" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction11" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle11") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl12" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction12" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle12") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl13" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction13" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle13") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl14" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction14" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle14") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        
                        <asp:TemplateField Visible="false" HeaderText="Cl15" HeaderStyle-CssClass="fontsize">                                   
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkAction15" Enabled="false" runat="server" Checked='<%# Eval("RescanCycle15") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                         
                                             
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr><td style="padding: 5px 0px; text-align: left; margin-bottom: 0;width: 800px;" >
                Rescan Entry Cycle : &nbsp; 
            <asp:DropDownList ID="ddlRescanCycle" Width="100px" runat="server" onchange="RescanChange();"> </asp:DropDownList>             
          
            <asp:Button ID="btnddlRescan" CssClass="clsBtnddlRescan" style="display:none;" runat="server" Text="" 
                    onclick="btnddlRescan_Click" />
                    </td></tr>
        <tr id="trRescanEntryHdr" runat="server">
            <td>
                <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; font-size:12px;    font-weight: normal; text-align: center;min-width: 1000px;
                    margin-bottom: 0;">
                    Rescan Entry&nbsp; 
                    <asp:Label ID="lblCycleEntryNo" runat="server" Text=""></asp:Label>               
                </h2>
            </td>
        </tr>
        <tr id="trRescanEntry" runat="server">
            <td style="width: 1000px;">
                <asp:GridView ID="grdRescanFillData" runat="server" AutoGenerateColumns="false" Width="100%"
                    CssClass="border2">
                    <RowStyle CssClass="grdRescanFillRow" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <HeaderTemplate>
                                Unit</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%# Eval("UnitId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Date
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtDate" runat="server" Style="text-align: center; color: Blue;"
                                    Width="100px" CssClass="date-picker th do-not-allow-typing"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="70px">
                            <HeaderTemplate>
                                Pending Rescan Qty.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="70px" Style="text-align: center; color: Black;
                                    font-weight: bold;" ID="lblPendingRescannedQty" Text='<%# Eval("Pending_rescan_qty", "{0:#,##}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Pass Qty.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtRescannedQty" runat="server" Width="50px" MaxLength="4" Height="24px"
                                    Style="text-align: center; color: Blue;" onkeypress="return isNumberKey(event)"
                                    onchange="checkQuantity(this);chechZero(this);" Text=""></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="80px">
                            <HeaderTemplate>
                                Fail Qty.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtFailQty" Width="50px" Height="24px" MaxLength="4"
                                    Style="text-align: center; color: Red;" onchange="EnableFaults(this);" onkeypress="return isNumberKey(event)"
                                    Text="" ></asp:TextBox>
                                <asp:CheckBox ID="chkIncludedRescan" runat="server" ToolTip="Included in rescan." Checked="true"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderStyle-Width="350px" ItemStyle-Width="350px">
                            <HeaderTemplate>
                                Faults
                            </HeaderTemplate>
                            <ItemTemplate>
                                  <asp:DataList ID="dlstFaults" RepeatDirection="Vertical" Width="100%" runat="server" frame="void" rules="all">
                                  <ItemStyle CssClass="FaultsCount" />
                                    <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>                                   
                                    <td style="text-align:left; padding-left:5px;width:80%;">
                                        <asp:Label ID="lblFaults" runat="server" Text='<%#Eval("FaultDescription")%>'></asp:Label> 
                                        <asp:HiddenField ID="hdnFaultsId" Value='<%#Eval("FaultID")%>' runat="server" />
                                    </td>
                                     <td style="text-align:right; width:20%; padding-right:5px;">                                       
                                    <input type="text" id="txtFaultsQty" maxlength="4" runat="server" style="width:30px; height:10px; color:Red; text-align: center;"
                                    onkeypress="return isNumberKey(event)" disabled="disabled" />
                                    </td>
                                        </tr></table>                                                      
                                    </ItemTemplate>
                                    <ItemStyle Width="33%" />
                                </asp:DataList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Man Power
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtManPower" runat="server" Width="50px" Height="24px" Style="text-align: center;
                                    color: Blue;" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"
                                    MaxLength="3" Text=""></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Working Hrs.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtWorkingHrs" Width="50px" Height="24px" Style="text-align: center;
                                    color: Blue;" onchange="chechZero(this);" onkeypress="return isNumberKeyfloat(event)"
                                    MaxLength="6" Text=""></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                M/P Breakdown/ Remarks
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtBreakDown" runat="server" TextMode="MultiLine" Width="95%" Height="50px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <div style="width: 99%; vertical-align: top; border: 0px solid #000000;" align="right">
                    <asp:Button ID="btnRescanSubmit" runat="server" Text="Submit" CssClass="submit" OnClick="btnRescanSubmit_Click"
                        OnClientClick="javascript:return ValidateRescanFill(this);" />
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="close da_submit_button" Text="Close"
                       OnClientClick="javascript:window.open('','_self').close();" />
                </div>
            </td>
        </tr>
        <tr><td style="padding-top:10px; text-align:left;">
         <asp:GridView ID="grdRescanDetails" Width="1000px" runat="server" FooterStyle-HorizontalAlign="Center"
                DataFormatString="{0:#,##}" HeaderStyle-HorizontalAlign="Center" FooterStyle-Font-Size="10px"
                    AutoGenerateColumns="false" RowStyle-Font-Size="10px" HeaderStyle-CssClass="HeaderRescanDetail"
                    ShowFooter="true" onrowdatabound="grdRescanDetails_RowDataBound" FooterStyle-Height="30px"
                     FooterStyle-Font-Bold="true"
                     RowStyle-ForeColor="Gray"
                ondatabound="grdRescanDetails_DataBound">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                     <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="60px"
                            ItemStyle-Width="60px" HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                Unit
                            </HeaderTemplate>
                            <ItemTemplate>                                     
                                <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("FactoryName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                            Total
                            </FooterTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                            ItemStyle-Width="80px" HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                Date
                            </HeaderTemplate>
                            <ItemTemplate>               
                                 <%# Convert.ToDateTime(Eval("ReScanDate")).ToString("dd MMM yy (ddd)")%>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="90px"
                            ItemStyle-Width="90px" HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                Rescan Pass <br />(Fail) Qty
                            </HeaderTemplate>
                            <ItemTemplate>               
                                <asp:Label ID="lblPass" runat="server" Text='<%# Eval("ReScanQty", "{0:#,##}")%>'></asp:Label>&nbsp;
                                <asp:Label ID="lblFail" runat="server" Text=""></asp:Label>   
                            </ItemTemplate>
                            <FooterTemplate>
                              <asp:Label ID="lblPassFooter" ForeColor="Black" runat="server" Text=""></asp:Label>&nbsp;
                                <asp:Label ID="lblFailFooter" runat="server" Text=""></asp:Label>   
                            </FooterTemplate>                          
                        </asp:TemplateField>

                         <asp:TemplateField HeaderStyle-Width="250px"
                            ItemStyle-Width="250px"  HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                Faults
                            </HeaderTemplate>
                            <ItemTemplate>                           
                             <div style="text-align:left; padding-left:5px;"><asp:Label ID="lblFaults" runat="server" Text=""></asp:Label></div>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                            ItemStyle-Width="80px" HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                Man Power <br /> (Work. Hrs)
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("ManPower", "{0:#,##}")%>&nbsp;<%# Eval("WorkingHrs").ToString() == "" ? "" : "("%><span
                                    style="color: Gray"><%# Eval("WorkingHrs")%></span><%# Eval("WorkingHrs").ToString() == "" ? "" : ")"%>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="250px"
                            ItemStyle-Width="250px"  HeaderStyle-CssClass="fontsize">
                            <HeaderTemplate>
                                M/P Breakdown And Remarks
                            </HeaderTemplate>
                            <ItemTemplate>                           
                              <div style="text-align:left; padding-left:5px;"><asp:Label ID="lblBreakdown" runat="server" Text=""></asp:Label></div>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </td></tr>
        <tr><td>&nbsp;</td></tr>
    </table>

   </td></tr></table>    
    <br />   
  
  </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
