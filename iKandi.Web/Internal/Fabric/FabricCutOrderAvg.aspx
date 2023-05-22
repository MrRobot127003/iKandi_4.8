<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricCutOrderAvg.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricCutOrderAvg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/facebox.js"></script>
    <script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script>
        function CloseWin() {
            alert('Saved successfully!');
            window.parent.Shadowbox.close();
        }
    </script>
    <script type="text/javascript">

        $(function () {
            $('input').attr('autocomplete', 'off');
            //            $(".hypavgfile").click(function () {               
            //                $(this).siblings("input").trigger('click');
            //            });            

            $(".HyclickCutAvgFile").click(function () {
                $(this).siblings("input").trigger('click');
            });
        });
        function Callfile(seq) {
            $("#grdcutavg_ctl01_uploderavgfile" + seq).trigger('click');

        }
        function UploadFile(fileUpload) {

            //            if (fileUpload.value != '') {
            //                $("#btnUpload").click();
            //            }
        }
        $(document).ready(function () {

            $('.groupOfTexbox').keypress(function (event) {
                return isNumber(event, this)
            });
            var elmnt = document.getElementById("grdcutavg");

            window.parent.Setwidthwastagescreen(parseInt(elmnt.offsetWidth) + 27, parseInt(elmnt.offsetHeight) + 30);
        });
        // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
        function isNumber(evt, element) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            if (
            (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function closeAccesButtion() {
            //Actual Quantity;
            // this code added by bharat on 26-june for new tab close
            var hdnTabClose = $('#hdnorderTabClose').val();
            if (hdnTabClose == "-1") {
                self.parent.Shadowbox.close();
            }
            else {
                var win = window.open("", "_self");
                win.close();
            }
            //end
        }
        // code added by bharat on 25-june
        $(document).ready(function () {
            //var RowCount = $('.RowCount').length;
            var hdnTabClose = $('#hdnorderTabClose').val();
            //alert(RowCount);
            //            if (hdnTabClose !== "-1") {
            //                $('#HeightTable').addClass("AddHeight");
            //                $("#widthdiv").addClass("table_width");
            //                gridviewScrollRow1();
            //            }
            //            else {
            //                $("#widthdiv").addClass("tablewidthPop");
            //                $("#PopTableW").addClass("PopHeaderW");
            // gridviewScroll();
            //  }


        });
        //end

       
    </script>
    <%-- this code added by bharat on 25-june for header fixed--%>
    <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script>
        var serviceUrl = "../../Webservices/iKandiService.asmx";
        var proxy = new ServiceProxy(serviceUrl);

        function gridviewScroll() {
            //            var gridWidth = $('#widthdiv').width()+15;
            //            var gridHeight = $('#widthdiv').height()-10;
            $('.headertopfixed').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                freezesize: 2
            });
        }
        //        function gridviewScrollRow1() {
        //            var gridWidth = $('#widthdiv').width() + 10;
        //            var gridHeight = $('#widthdiv').height() + 10;
        //            $('.headertopfixed').gridviewScroll({
        //                width: gridWidth,
        //                height: gridHeight,
        //                freezesize: 2
        //            });
        //        }

        //        function BindUnitName(elem) {
 
        //            var Unit = elem.value;           

        //            var grid = document.getElementById("grdcutavg");
        //            var objId = elem.id.split("_")[1].substr(3);
        //            rowscount = grid.rows.length;

        //            var RowId = elem.id.split("_")[1].substr(3);
        //            var UnitId = elem.id.split("_")[3].substr(4);

        //            for (var i = 1; i <= rowscount; i++) {
        //                if (i < 9) {
        //                    $("#grdcutavg_ctl0" + (i + 1) + "_ddlcutAvg_Unit" + UnitId).val(Unit);
        //                }
        //                else {
        //                    $("#grdcutavg_ctl" + (i + 1) + "_ddlcutAvg_Unit" + UnitId).val(Unit);
        //                }
        //            }
        //            //$(".UnitName").val(Unit);            
        //        }


        function OrderAvgFreeze(ele) {
            //Actual Quantity;

            var gridID = ele.id.split("_")[0];
            var objId = ele.id.split("_")[1].substr(3);
            var ControlID = ele.id.split("_")[2];
            var i = ControlID.substr(ControlID.length - 1);
            var table = document.getElementById("grdcutavg");
            var length = table.rows.length;

            if (ele.value != "") {
                //$("#grdcutavg_ctl01_txtorderavg" + i.toString()).attr("readonly", true);
                $("#grdcutavg_ctl" + objId.toString() + "_txtorderavg" + i.toString()).attr("readonly", true);
            }
            else {
                //$("#grdcutavg_ctl01_txtorderavg" + i.toString()).attr("readonly", false);
                $("#grdcutavg_ctl" + objId.toString() + "_txtorderavg" + i.toString()).attr("readonly", false);
            }
        }


        function isDecimalNumber(event, c) {
            //Actual Quantity;
            $('.numericTwoDecimal').keypress(function (event) {
                //Actual Quantity;
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 3) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 3)) {
                    event.preventDefault();
                }
            });
        }

        function OrderAvgBlank(ele) {

            var ControlID = ele.id.split("_")[2];
            var i = ControlID.substr(ControlID.length - 1);

            var CostAvg = document.getElementById("hdnCostingAvg" + i.toString()).value;

            var OrderAvg = ele.value;

            if (parseFloat(OrderAvg) > parseFloat(CostAvg)) {
                alert("Order Average can not be greater than Costing Average.");
                ele.value = ele.defaultValue;
            }
            else {
                ele.value = OrderAvg;
            }

            //uncomment after testing start
            //            var chkCheck = $("#chkboxAccountMgr").prop("checked");
            //            if (chkCheck == true) {
            //                var EleId = ele.id;

            //                var EleVal = ele.value;
            //                if (EleVal == "") {
            //                    alert("Any order average cannot be blank!");
            //                    ele.value = ele.defaultValue;
            //                    return;
            //                }
            //            }
            //uncomment after testing end
        }


        function showhistory(flag, elem) {

            //            alert(flag + ' ' + text)
            if (elem.id != "") {
                if (elem.id == 'lnkHistory') {
                    $("#lblh").html($("#lblHistory").html());
                }
                else {
                    var Idsn = elem.id.split("_")[1];
                    $("#lblh").html($("#grdcutavg_" + Idsn + "_lblh1").html());
                }
            }

            $("#divhistory").css("display", flag);


        }
        function showhistoryhide(flag, elem) {



            $("#divhistory").css("display", flag);


        }

        function temploader() {
            $("#spinnL").fadeIn("slow");

        }


        //added by raghvinder on 10-11-2020 start
        function CheckboxClick(elem) {

    
            //alert("check");
            var CheckValue = 1;
            var OrderID = parseInt(document.getElementById("hdnOrderID").value);
            var CreatedBy = parseInt(document.getElementById("hdnUserId").value);


            var res = confirm("Are you sure all your entries are correct?");

            if (res) {

                if ($("#chkboxAccountMgr").is(':checked') == true) {
                    proxy.invoke("/FabricApproved_History", { Type: 'FAB_CHECK', OrderID: OrderID, CheckValue: CheckValue, CreatedBy: CreatedBy }, function (result) {
                        if (result > 0) {
      
                            // alert(result);
                            $("#chkboxAccountMgr").attr('disabled', 'disabled');
                             window.location.reload();
                            //  self['location']['replace'](self.location['href'])
                             $("#hdnchkboxAccountMgr").val(1);

                        }
                    }, onPageError, false, false);

                }
            }

            else {
                $("#chkboxAccountMgr").prop("checked", false);
                $("#hdnchkboxAccountMgr").val(0);
            }
        }

        //added by raghvinder on 10-11-2020 end

        //added by raghvinder on 01-12-2020 start
        function FileUploadValidation(ele) {
          //  alert("cjk");
            var table = document.getElementById("grdcutavg");
            var rowlength = table.rows.length;

            var FabCount = $("#hdnFabricCount").val();
            var length = parseInt(FabCount);
            // Added by shubhendu for validation 6/12/2021
            for (i = 1; i <= length; i++) {

                var ordAvgVal = $("#grdcutavg_ctl02_txtorderavg" + i.toString()).val();

                var cutAvg = $("#grdcutavg_ctl02_txtcutavg" + i.toString()).val();

                if (ordAvgVal == "" && cutAvg == "") {


                    alert("Please provide order avg");

                }
                else if (cutAvg != "" && ordAvgVal == "") {

                    alert("Please provide order avg");
                    return false

                }


            }

            // till here

            //new code start
            for (var j = 2; j <= rowlength; j++) {
                for (var i = 1; i <= length; i++) {
                    if (j < 10) {
                        var cutAvgFile = document.getElementById("grdcutavg_ctl0" + j.toString() + "_cutAvgfile" + i.toString()).files.length;
                        var txtcutavg = document.getElementById("grdcutavg_ctl0" + j.toString() + "_txtcutavg" + i.toString()).value;
                        var hdncutavg = document.getElementById("grdcutavg_ctl0" + j.toString() + "_hdnCutAvg" + i.toString()).value;
                        var txtCutWidth = document.getElementById("grdcutavg_ctl0" + j.toString() + "_txtCutWidth" + i.toString()).value;

                        if (txtcutavg != "") {

                            if (txtcutavg != "") {
                            }
                            else {
                                alert("Please fill Cut Avg. for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }

                            if (cutAvgFile > 0 || hdncutavg != "0") {
                            }
                            else {
                                alert("Please upload Cut Avg. File for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }
                            if (txtCutWidth != "") {
                            }
                            else {
                                alert("Please fill Cut width for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }
                        }
                    }
                    else {
                        //                        if (document.getElementById("grdcutavg_ctl" + j.toString() + "_txtcutavg" + i.toString()).value != "") {
                        //                            if (document.getElementById("grdcutavg_ctl" + j.toString() + "_cutAvgfile" + i.toString()).files.length > 0) {
                        //                            }
                        //                            else {
                        //                                alert("Please upload Cut Avg. File for Fabric " + i.toString() + " Contract " + (j-1).toString());
                        //                                return false;
                        //                            }
                        //                        }
                        var cutAvgFile = document.getElementById("grdcutavg_ctl" + j.toString() + "_cutAvgfile" + i.toString()).files.length;
                        var txtcutavg = document.getElementById("grdcutavg_ctl" + j.toString() + "_txtcutavg" + i.toString()).value;
                        var hdncutavg = document.getElementById("grdcutavg_ctl" + j.toString() + "_hdnCutAvg" + i.toString()).value;
                        var txtCutWidth = document.getElementById("grdcutavg_ctl" + j.toString() + "_txtCutWidth" + i.toString()).value;

                        if (txtcutavg != "") {

                            if (txtcutavg != "") {
                            }
                            else {
                                alert("Please fill Cut Avg. for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }

                            if (cutAvgFile > 0 || hdncutavg != "0") {
                            }
                            else {
                                alert("Please upload Cut Avg. File for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }
                            if (txtCutWidth != "") {
                            }
                            else {
                                alert("Please fill Cut width for Fabric " + i.toString() + " Contract " + (j - 1).toString());
                                return false;
                            }
                        }
                    }
                }
            }

            //new code end


            for (var i = 1; i <= length; i++) {
                if (document.getElementById("grdcutavg_ctl01_uploderavgfile" + i.toString()).files.length > 0 || document.getElementById("grdcutavg_ctl01_hdnFileUpload" + i.toString()).value != "0") {
                }
                else {
                    alert("Please upload Order Avg. File for Fabric " + i.toString());
                    return false;
                }
            }
            var FabCOunt = $("#hdnFabricCount").val();


        }

        //alert("chekc");
        // CloseWindow();

        //added by raghvinder on 01-12-2020 end
        
       
    </script>
    <style>
        #spinnL
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        #grdcutavgFreeze
        {
            border-top: 0px;
        }
        #grdcutavgFreeze td:first-child
        {
            border-top: 0px;
        }
        #grdcutavgFreeze tr:nth-child(2) td
        {
            border-top: 0px;
        }
        
        .AddHeight
        {
            min-height: auto !important;
        }
        .fab_avg_table
        {
            border-collapse: separate !important;
        }
        .fab_avg_table th
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize;
            border: 0px;
            border-right: 1px solid #999;
            text-align: center;
            padding: 0px 0px;
            font-weight: normal;
            font-size: 11px;
            font-family: Arial;
        }
        .fab_avg_table td
        {
            color: #575759;
            text-transform: capitalize;
            border: 1px solid #dbd8d8;
            text-align: center;
            padding: 0px 0px;
            font-weight: normal;
            font-size: 11px;
            font-family: Arial;
            height: 20px;
            border-bottom: 0px;
        }
        input[type=text], textarea
        {
            width: 98%;
            text-align: center;
        }
        
        
        .groupOfTexbox
        {
            width: 82% !important;
            margin: 1px 0px;
        }
        .uplaofileicon
        {
            height: 13px;
            position: relative;
            top: 3px;
        }
        td.mibwidthcontactnumber
        {
            min-width: 116px;
            max-width: 116px;
            background-color: #dddfe4;
            position: sticky;
            left: 0px;
            z-index: 8 !important;
            border: 1px solid #999;
            border-left: 0px;
            border-bottom: 0px;
        }
        td.ContQry
        {
            position: sticky;
            left: 117px;
            z-index: 8 !important;
            border: 1px solid #999;
            border-left: 0px;
            border-bottom: 0px;
        }
        
        input[type="checkbox"]
        {
            cursor: pointer;
        }
        
        .DynamicHeader1
        {
            width: 100%;
        }
   /*    .DynamicHeader2
        {
            width: 1215px !important;
        }*/
        
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
        /* tr:nth-child(even)
        {
            background: #efefef;
        }*/
        .AddHeight table tr:nth-child(even)
        {
            background: #fff !important;
        }
        
        .fab_avg_table td:first-child
        {
            border-left-color: #999 !important;
        }
        .fab_avg_table td:last-child
        {
            border-right-color: #999 !important;
        }
        
        td.minwidthfab
        {
            border-right-color: #999 !important;
        }
        .border_right_color
        {
            border-right-color: #999 !important;
            background-color: #dddfe4;
            border-color: #999 !important;
        }
        .Contact_width
        {
            min-width: 115px;
            max-width: 115px;
            position: sticky;
            left: 0px;
            z-index: 12 !important;
        }
        .HeaderContQty
        {
            width: 58px;
            position: sticky;
            left: 117px;
            z-index: 12 !important;
        }
        .popup .body .content
        {
            min-width: 150px;
            overflow: hidden !important;
        }
        
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-track
        {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #bdbbbb;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb:hover
        {
            background: #969191;
        }
        @media print
        {
            .printButtonHide
            {
                display: none;
            }
        }
        
        #grdcutavgHorizontalBar
        {
            height: 5px !important;
            cursor: pointer;
            background: rgb(118, 114, 114) !important;
        }
        #grdcutavgHorizontalRail
        {
            height: 6px !important;
        }
        #grdcutavgPanelHeader
        {
            background: #fff !important;
        }
        #grdcutavgPanelItem
        {
            background: #fff !important;
        }
        #grdcutavgVerticalRail
        {
            width: 5px !important;
            background: #fff !important;
        }
        #grdcutavgVerticalBar
        {
            width: 5px !important;
            right: 10px !important;
            cursor: pointer;
            background: rgb(118, 114, 114) !important;
        }
        
        
        
        .ModelPo2
        {
            background: #fff;
            width: 90%;
            z-index: 100000;
            max-height: 136px;
            line-height: 15px;
            text-align: left;
            position: fixed;
            top: calc(10% - 10px/2);
            left: calc(15% - 100px/2);
            overflow:auto;
                }
        
        a.HistoryAnchor:hover
        {
            text-decoration: underline;
            cursor: pointer;
        }
        .maxWidthHist
        {
            max-height: 300px;
            overflow-y: auto;
        }
        #lblh
        {
            padding-top: 10px;
        }
        .maxWidthHist ul
        {
            padding-left: 15px;
            margin: 0px 0px 0px;
        }
        .groupHeaderTexbox
        {
            width: 26px !important;
            height: 14px;
            position: relative;
            top: -1px;
        }
        .PaddRight
        {
            margin-right: 10px;
        }
        .DynamicFab1
        {
            width: 690px;
        }
        .FabMarLeft
        {
            margin-left: 262px;
        }
        /*   .FabCutInnerTable td
    {
        height:45px;
     }*/
        body
        {
            font-family: arial;
        }
        .fab_avg_table th
        {
            position: sticky;
            top: 48px;
            z-index: 9;
            border-bottom: 1px solid #999;
        }
        tr.Innertable th
        {
            min-width: 60px;
            max-width: 60px;
        }
        tr.Innertable td
        {
            min-width: 60px;
            max-width: 60px;
        }
        .FabCutInnerTable td
        {
            min-width: 60px;
            max-width: 60px;
        }
        .FabCutInnerTable td input[type="text"]
        {
            width: 30px;
            background: transparent;
        }
        /*      .FabCutInnerTable td:nth-child(even)
        {
            background-color: #dedede;
        }
         .FabCutInnerTable td:nth-child(odd)
        {
            background-color: #f2f2f2;
        }*/
        
        ul
        {
            list-style: none;
            margin-left: 0;
            padding-left: 1.2em;
            text-indent: -1.2em;
        }
        
        li:before
        {
            content: "•";
            display: block;
            float: left;
            font-size: 20px;
            margin-right: 13px;
            margin-top: 0px;
            color: gray;
        }
        @media screen and (min-width: 1600px)
        {
            .DynamicHeaderTask
            {
                width: 1600px !important;
            }
            .DynamicHeaderTaks
            {
                width: 1600px !important;
            }
        }
        @media screen and (max-width: 1366px)
        {
            .DynamicHeaderTask
            {
                width: 1366px !important;
            }
            .DynamicHeaderTaks
            {
                width: 1194px !important;
            }
        }
    </style>
</head>
<body>
    <div id="spinnL">
    </div>
    <form id="form1" runat="server">
    <div>
        <div style="max-width: 100%; padding: 0px 0px; overflow: auto; position: fixed; top: 0;
            background: #fff; z-index: 9;">
            <div id="DynamicHeaderWidth" runat="server" style="width: 686px;">
                <h2 style="width: 100%; margin: -2px 0px 4px 0px; font-weight: 500; background: #3b5998;
                    color: White; text-align: center; padding: 6px 0px; line-height: 11px; height: 12px;
                    font-size: 14px; position: relative;" id="PopTableW">
                    Fabric Details <a id="lnkHistory" style="color: White; position: absolute; right: 30px;
                        top: 3px; font-size: 12px" class="HistoryAnchor" runat="server" onclick="showhistory('block',this)"
                        target="_blank">
                        <img src="../../images/history.png" /></a>
                    <%--<span class="HistoryDescription"></span>--%>
                    <asp:Label ID="lblHistory" Style="display: none" runat="server"></asp:Label>
                    <span style="float: right; padding-right: 10px; margin-top: 0px; font-size: 14px;
                        cursor: pointer" onclick="closeAccesButtion()">X</span>
                    <asp:HiddenField ID="hdnorderTabClose" runat="server" />
                    <asp:HiddenField ID="hdnUserId" runat="server" />
                    <asp:HiddenField ID="hdnOrderID" runat="server" />
                    <asp:HiddenField ID="hdnCostingAvg1" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnCostingAvg2" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnCostingAvg3" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnCostingAvg4" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnCostingAvg5" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnCostingAvg6" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnFabricCount" runat="server" Value="0" />
                </h2>
                <table runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                    <tr>
                        <td style="text-align: left; border: 1px solid #999999; background: #dddfe4; padding: 3px 3px;
                            border-bottom: 1px solid #999">
                            <span style="color: gray">Serial Number: </span>
                            <asp:Label ID="lblserialno" Style="padding-right: 10px; font-weight: 600; color: #000;
                                text-transform: capitalize;" runat="server"></asp:Label>
                            <span style="color: gray">Style Number:
                                <asp:Label ID="lblstylenumber" Style="color: #000; font-weight: 600; text-transform: capitalize;"
                                    runat="server"></asp:Label></span> <span style="color: gray; margin-left: 10px;">AM:
                                        <asp:Label ID="lblacname" Style="color: #000; font-weight: 600; text-transform: capitalize;"
                                            runat="server"></asp:Label>
                                    </span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:Button ID="btnUpload" Text="Upload" CssClass="callme" runat="server" OnClick="Upload"
            Style="display: none" />
        <div style="max-width: 100%; padding: 0px 0px;" id="HeightTable">
            <div id="DynamicTableWidth" runat="server">
                <div id="widthdiv" runat="server" style="max-height: 350px;">
                    <asp:GridView runat="server" ID="grdcutavg" CssClass="fab_avg_table headertopfixed"
                        CellPadding="0" CellSpacing="0" BorderWidth="0" AutoGenerateColumns="false" OnRowDataBound="grdcutavg_RowDataBound"
                        HeaderStyle-Height="15px" EmptyDataText="No Record Found" Style="margin: 0px 0px 0px;
                        font-size: 10px !important; border-color: Gray; border-bottom: 1px solid #999;
                        margin-top: 47px;">
                        <RowStyle CssClass="RowCount" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="" id="etaheader" frame="void"
                                        rules="all">
                                        <%--<tr>
                                            <th style="border-bottom: 1px solid #7c7676 !important; text-align: left;">
                                                Serial No.
                                                <asp:Label ID="lblserialno" runat="server"></asp:Label>
                                            </th>
                                        </tr>--%>
                                        <tr>
                                            <th style="border-bottom: 0px solid #c2b9b9 !important;">
                                                Contract No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important; border-top: 0px !important;">
                                                Ex-Factory
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="Contact_width" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnOderDetailID" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                    <asp:HiddenField ID="hdnFabCount" Value='<%# Eval("FabricCount") %>' runat="server" />
                                    <table cellpadding="0" cellspacing="0" width="100%" border="" frame="void" rules="all">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:Label ID="lblh1" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <a id="lnkhistoryshow1" style="color: Blue; float: left" class="HistoryAnchor" runat="server"
                                                    onclick="showhistory('block',this)" target="_blank">
                                                    <img src="../../images/Fabhistory.png" /></a>
                                                <asp:Label ID="lblContactNo" Text='<%# Eval("ContractNumber") %>' runat="server"
                                                    Style="min-width: 100px; word-break: break-all;"></asp:Label>
                                                <asp:HiddenField ID="hdncc" runat="server" Value='<%# Eval("ContractNumber") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background: #dddfe4;">
                                                <b>
                                                    <asp:Label ID="lblExFactory" Text='<%# Eval("ExFactory") %>' runat="server"></asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="mibwidthcontactnumber" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="58px" border="1" frame="void" rules="all">
                                        <tr>
                                            <th colspan="2" style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Contract
                                                <br>
                                                Qty.
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="HeaderContQty" Width="58px" />
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="58px" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="border: 1px solid lightgray !important;">
                                                <asp:Label runat="server" Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0")%>'
                                                    ID="lblQuantity"> </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="border_right_color ContQry" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" class="" cellspacing="0" border="0" frame="void" rules="all"
                                        style="width: 100%;">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName1" CssClass="PaddRight" runat="server"></asp:Label>
                                                <asp:Label ID="lblCCgsm1" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition1" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab1" runat="server" Value="1" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext1" onclick="Callfile('1')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile1" CssClass="fileavgfile1" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload1" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile1" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px; position: relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%-- <span>Ord. Avg.</span>
                                                    <asp:TextBox ID="txtorderavg1" MaxLength="5" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)" CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal"
                                                        runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOrderAvg1" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit1" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        position: relative; top: -1px; margin-left: 2px">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost<br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order<br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut
                                                <br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.<br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost<br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order<br />
                                                Width
                                            </th>
                                            <th class="Cutwidth" style="border-right: 0px;">
                                                Cut<br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo1" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID1" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID1" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile1" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile1" runat="server" Target="_blank"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg1" MaxLength="5" onblur="OrderAvgBlank(this)" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg1" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile1" CssClass="fileavgfile1" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext1" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;"> </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile1" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="Cutavgwidth1">
                                                <asp:TextBox ID="txtcutavg1" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile1" CssClass="cutAvgfile1" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile1" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;"> </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile1" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg1" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth1" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth1" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth1" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit1" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">                                                    
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" style="width: 100%;">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName2" runat="server" CssClass="PaddRight"></asp:Label>
                                                <asp:Label ID="lblCCgsm2" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition2" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab2" runat="server" Value="2" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext2" onclick="Callfile('2')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile2" CssClass="fileavgfile2" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload2" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile2" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%--<span>Ord. Avg.</span>
                                                     <asp:TextBox ID="txtorderavg2" MaxLength="5" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)" CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal"
                                                        runat="server"></asp:TextBox>
                                                     <asp:HiddenField ID="hdnOrderAvg2" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit2" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        position: relative; top: -1px; margin-left: 2px">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost<br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order<br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut<br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.<br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost<br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order<br />
                                                Width
                                            </th>
                                            <th class="Cutwidth" style="border-right: 0px;">
                                                Cut<br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo2" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID2" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID2" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile2" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile2" runat="server" Target="_blank"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg2" MaxLength="5" onblur="OrderAvgBlank(this)" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg2" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile2" CssClass="fileavgfile2" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext2" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;"> </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile2" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="Cutavgwidth1">
                                                <asp:TextBox ID="txtcutavg2" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile2" CssClass="cutAvgfile2" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile2" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile2" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg2" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth2" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth2" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth2" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit2" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">                                                    
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" style="width: 100%;">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName3" CssClass="PaddRight" runat="server"></asp:Label>
                                                <asp:Label ID="lblCCgsm3" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition3" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab3" runat="server" Value="3" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext3" onclick="Callfile('3')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile3" CssClass="fileavgfile3" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload3" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile3" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%--<span>Ord. Avg.</span>
                                                    <asp:TextBox ID="txtorderavg3" MaxLength="5" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)" CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal"
                                                        runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOrderAvg3" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit3" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        margin-left: 2px; position: relative; top: -1px;">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost<br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order<br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut<br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.<br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost<br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order<br />
                                                Width
                                            </th>
                                            <th class="Cutwidth">
                                                Cut<br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo3" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID3" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID3" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile3" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile3" runat="server" Target="_blank"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg3" MaxLength="5" onblur="OrderAvgBlank(this)" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg3" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile3" CssClass="fileavgfile3" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext3" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"> <img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;"> </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile3" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtcutavg3" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile3" CssClass="cutAvgfile3" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile3" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile3" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg3" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth3" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth3" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth3" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit3" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">                                                    
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" style="width: 100%;">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName4" CssClass="PaddRight" runat="server"></asp:Label>
                                                <asp:Label ID="lblCCgsm4" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition4" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab4" runat="server" Value="4" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext4" onclick="Callfile('4')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile4" CssClass="fileavgfile4" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload4" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile4" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%--<span>Ord. Avg.</span>
                                                    <asp:TextBox ID="txtorderavg4" MaxLength="5" Width="100px" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)"
                                                        CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOrderAvg4" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit4" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        margin-left: 2px; position: relative; top: -1px;">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px;">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost<br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order<br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut<br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.<br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost<br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order<br />
                                                Width
                                            </th>
                                            <th class="Cutwidth">
                                                Cut
                                                <br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo4" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID4" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID4" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile4" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile4" runat="server" Target="_blank"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg4" onblur="OrderAvgBlank(this)" MaxLength="5" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg4" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile4" CssClass="fileavgfile4" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext4" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;"> </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile4" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtcutavg4" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile4" CssClass="cutAvgfile4" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile4" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile4" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width:12px ;height:12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg4" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth4" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth4" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth4" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit4" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" style="width: 100%;">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName5" CssClass="PaddRight" runat="server"></asp:Label>
                                                <asp:Label ID="lblCCgsm5" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition5" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab5" runat="server" Value="5" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext5" onclick="Callfile('5')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile5" CssClass="fileavgfile5" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload5" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile5" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%--<span>Ord. Avg.</span>
                                                        <asp:TextBox ID="txtorderavg5" MaxLength="5" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)" CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal"
                                                            runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hdnOrderAvg5" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit5" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        margin-left: 2px; position: relative; top: -1px;">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px;">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost<br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order
                                                <br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut
                                                <br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.<br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost
                                                <br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order<br />
                                                Width
                                            </th>
                                            <th class="Cutwidth">
                                                Cut<br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo5" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID5" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID5" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile5" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile5" runat="server" Target="_blank"> <img src="../../images/view-icon.png"  class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg5" MaxLength="5" onblur="OrderAvgBlank(this)" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg5" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile5" CssClass="fileavgfile5" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext5" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile5" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width:12px;height:12px" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtcutavg5" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile5" CssClass="cutAvgfile5" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile5" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile5" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width:12px;height:12px" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg5" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth5" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth5" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth5" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit5" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" style="width: 100%;
                                        height: 100%">
                                        <tr>
                                            <th colspan="10" style="border-bottom: 1px solid #999 !important; font-size: 12px;
                                                height: 31px;">
                                                <asp:Label ID="lblFabricName6" CssClass="PaddRight" runat="server"></asp:Label>
                                                <asp:Label ID="lblCCgsm6" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblValueAddition6" runat="server"></asp:Label><br />
                                                <asp:HiddenField ID="hdnfab6" runat="server" Value="6" />
                                                <%--new code start--%>
                                                <div class="HeaderWidth">
                                                    <div style="width: 23%; float: left;">
                                                        <span>Ord. Avg. File<span style="color: Red;">*</span></span>
                                                        <asp:HyperLink ID="hyplwithtext6" onclick="Callfile('6')" CssClass="hypavgfile" runat="server"
                                                            Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 12px;position:relative;top:2px;"> </asp:HyperLink>
                                                        <asp:FileUpload ID="uploderavgfile6" CssClass="fileavgfile6" runat="server" Style="display: none;" />
                                                        <asp:HiddenField ID="hdnFileUpload6" runat="server" Value="0" />
                                                        <asp:HyperLink ID="hyporderavgfile6" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width: 12px;height: 12px;position:relative;top:2px;" /> </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <div style="float: right;">
                                                    <%-- <span>Ord. Avg.</span>  <asp:TextBox ID="txtorderavg6" MaxLength="5" onblur="OrderAvgBlank(this)" onkeypress="return isDecimalNumber(event,this)" CssClass="groupOfTexbox groupHeaderTexbox numericTwoDecimal"
                                                        runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOrderAvg6" runat="server" />--%>
                                                    <span>Unit</span>
                                                    <asp:DropDownList ID="ddlcutAvg_Unit6" CssClass="UnitName" runat="server" Style="font-size: 12px;
                                                        margin-left: 2px; position: relative; top: -1px">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--new code end--%>
                                            </th>
                                        </tr>
                                        <tr class="Innertable">
                                            <th class="colorprintwidth" style="min-width: 81px">
                                                Color/Print
                                            </th>
                                            <th class="costavgwidth">
                                                Cost
                                                <br />
                                                Avg.
                                            </th>
                                            <th class="orderavgwidth">
                                                Order<br />
                                                Avg.
                                            </th>
                                            <%--<th class="costavgwidth" style="min-width: 55px">
                                                Order Avg. File
                                            </th>--%>
                                            <th class="orderavgwidth">
                                                Cut<br />
                                                Avg.
                                            </th>
                                            <th class="costavgwidth">
                                                Cut Avg.
                                                <br />
                                                File
                                            </th>
                                            <th class="costwidth">
                                                Cost
                                                <br />
                                                Width
                                            </th>
                                            <th class="Orderwidth">
                                                Order
                                                <br />
                                                Width
                                            </th>
                                            <th class="Cutwidth">
                                                Cut
                                                <br />
                                                Width
                                            </th>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<th class="UnitHeader">
                                                Unit
                                            </th>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="maxtablewidth" />
                                <ItemTemplate>
                                    <table cellpadding="0" class="FabCutInnerTable" cellspacing="0" border="0" frame="void"
                                        rules="all" style="width: 100%; height: 100%">
                                        <tr>
                                            <td class="colorprintwidth1" style="border: 1px solid lightgray !important; min-width: 80px;
                                                max-width: 80px;">
                                                <asp:Label runat="server" ID="lblColorprintNo6" ForeColor="black"> </asp:Label>
                                                <asp:HiddenField ID="hdnOderDetailID6" Value='<%# Eval("orderdetailid") %>' runat="server" />
                                                <asp:HiddenField ID="hdnCostingID6" Value='<%# Eval("CostingID") %>' runat="server" />
                                            </td>
                                            <td class="costavgwidth1">
                                                <asp:Label runat="server" ID="lblCostAvgFile6" ForeColor="black"> </asp:Label>
                                                <asp:HyperLink ID="hyplCostAvgFile6" runat="server" Target="_blank"> <img src="../../images/view-icon.png" class="uplaofileicon" /> </asp:HyperLink>
                                            </td>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtorderavg6" onblur="OrderAvgBlank(this)" CssClass="groupOfTexbox numericTwoDecimal"
                                                    onkeypress="return isDecimalNumber(event,this)" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderAvg6" runat="server" />
                                            </td>
                                            <%--<td class="costavgwidth12">
                                                <asp:FileUpload ID="uploderavgfile6" CssClass="fileavgfile6" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="hyplwithtext6" CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue"
                                                    Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="hyporderavgfile6" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="height:12px;width:12px" /> </asp:HyperLink>
                                            </td>--%>
                                            <td class="orderavgwidth1">
                                                <asp:TextBox ID="txtcutavg6" MaxLength="5" CssClass="groupOfTexbox" onblur="OrderAvgFreeze(this)"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="costavgwidth12">
                                                <asp:FileUpload ID="cutAvgfile6" CssClass="cutAvgfile6" runat="server" Style="display: none;" />
                                                <asp:HyperLink ID="HyclickCutAvgFile6" CssClass="HyclickCutAvgFile" runat="server"
                                                    Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;"><img alt="#" src="../../images/uploadimg.png" style="width: 15px;height: 14px;">  </asp:HyperLink>
                                                <asp:HyperLink ID="HyViewCutAvgFile6" runat="server" Target="_blank" Style="cursor: pointer;"> <img src="../../images/view-icon.png" style="width:12px;height:12px" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnCutAvg6" runat="server" Value="0" />
                                            </td>
                                            <td class="costwidth1">
                                                <asp:TextBox ID="txtCostWidth6" MaxLength="5" CssClass="groupOfTexbox do-not-allow-typing"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Orderwidth1">
                                                <asp:TextBox ID="txtOrderWidth6" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Cutwidth1">
                                                <asp:TextBox ID="txtCutWidth6" MaxLength="5" CssClass="groupOfTexbox" runat="server"></asp:TextBox>
                                            </td>
                                            <%--added by raghvinder on 19-08-2020 start--%>
                                            <%--<td class="Unit1">
                                                <asp:DropDownList ID="ddlcutAvg_Unit6" onchange="BindUnitName(this)" CssClass="UnitName"
                                                    runat="server" Style="font-size: 12px;">
                                                </asp:DropDownList>
                                            </td>--%>
                                            <%--added by raghvinder on 19-08-2020 end--%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="minwidthfab" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div id="Fab1Left" runat="server">
                        <div style="margin:10px;">
                            AVG Checked and Smart Marker Uploaded by Account Manager
                            <asp:CheckBox ID="chkboxAccountMgr" runat="server" onClick="CheckboxClick(this)"
                                Enabled="true" Style="position: relative; cursor: poniter; top: 3px;" />
                                <asp:HiddenField ID="hdnchkboxAccountMgr" runat="server" />
                                <span style="color: red;
                                    font-size: 11px; margin-left: 5px;" id="messageHide" runat="server">All avg. are
                                    not filled!</span>
                        </div>
                        <div style="margin:10px;display: flex;">
                            <%--<asp:Button ID="btnSubmit" runat="server" OnClientClick="temploader(); return FileUploadValidation()"
                            Text="Submit" CssClass="do-not-include btnSubmit submitbtn printButtonHide" OnClick="btnSubmit_Click" />--%>
                            <asp:Button ID="btnSubmit" runat="server" OnClientClick="return FileUploadValidation(this);"
                                Text="Submit" CssClass="do-not-include btnSubmit submitbtn printButtonHide" OnClick="btnSubmit_Click" />
                            <%--<input type="button" id="btnPrint" class="print do-not-include doNotPressAgain btnPrint printButtonHide"
                            value="Print" onclick="javascript:window.print();" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="ModelPo2" id="divhistory" runat="server" style="display: none">
        <h2 style='background: #39589c !important; width: 89% !important; font-size: 15px;
            margin: 0px 0px; color: #fff !important; margin-left: 0px; font-weight: 500;
            text-align: center;position:fixed;'>
            History<span style='float: right; margin-right: 8px; cursor: pointer; color: #fff'
                title='Close' onclick="showhistoryhide('none','');">X</span>
        </h2>
        <div class="">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 50%; text-align: left; padding: 20px 10px 22px; line-height: 12px;
                        font-size: 10px">
                        <asp:Label ID="lblh" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(window).load(function () { $("#spinnL").fadeOut("slow"); }); //Gajendra 
    </script>
    </form>
</body>
</html>
