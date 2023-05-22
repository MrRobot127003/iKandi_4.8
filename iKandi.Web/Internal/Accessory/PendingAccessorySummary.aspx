<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="PendingAccessorySummary.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.PendingAccessorySummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <link href="../../css/CommanTooltip.css" rel="stylesheet" type="text/css" />
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
        }
        table
        {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border-color: #b3aaaa;
            border: 1px solid #999;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
            color: gray;
            padding: 3px 0px;
            font-family: arial;
            border: 1px solid #dbd8d8;
        }
        .item_list1 td, .item_list1 th
        {
            padding: 5px 0px !important;
        }
        .item_list1 td
        {
            border-color: #c1bfbf;
        }
        
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        h2
        {
            font-size: 15px;
            font-weight: 500;
            padding: 2px 0px;
            background: #39589C;
            color: #fff;
            width: 845px;
            text-align: center;
            text-transform: capitalize;
            letter-spacing: 1px;
        }
        
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #ddd;
        }
        
        
        .SUPPLY-MANA td input
        {
            width: 35%;
        }
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        .process
        {
            padding: 0px;
            margin: 0px;
        }
        .process li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li input
        {
            width: 10%;
        }
        .supply_type
        {
            padding: 0px;
            margin: 0px;
        }
        .supply_type li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li:last-child
        {
            border-bottom: 0px;
        }
        input[type="text"]
        {
            width: 95% !important;
            color: gray !important;
            text-transform: capitalize !important;
            background-color: White;
        }
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }
        .ths
        {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: sans-serif;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }
        .grds
        {
            margin-left: 20px;
        }
        input[type="file"]
        {
            width: 90%;
            overflow: hidden;
            display: none;
        }
        .show, .hide
        {
            cursor: pointer;
        }
        a.UpdateBtn
        {
            background: url(../../images/update-icon.png) no-repeat left top;
            padding-left: 25px;
        }
        
        a.DeleteBtn
        {
            background: url(../../images/delete-icon.png) no-repeat left top;
            padding-left: 25px;
            padding-top: 3px;
        }
        /* The Modal (background) */
        .modal
        {
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
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 550px;
            margin-top: 12%;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        .inputborder
        {
            border: 1px solid #cccccc !important;
        }
        h2.pending_order_heading
        {
            background: #dddfe4;
            width: 948px;
            margin: 0px;
            color: #575759;
            border: 1px solid #999;
            border-bottom: 0px;
            font-weight: 600;
            font-family: sans-serif;
            font-size: 13px;
        }
        .backcolorstages
        {
            background: #fdfd96e0 !important;
        }
        .hidesstages
        {
            display: none;
        }
        select
        {
            background: #fdfd96e0;
            color: Blue;
            width: 93% !important;
        }
        select:disabled
        {
            color: Gray;
        }
        .border_none_top_current
        {
            border-bottom: 0px !important;
        }
        .border_none_top_previus
        {
            border-top: 0px !important;
            border-bottom: 0px !important;
        }
        
        displaynone
        {
            display: none;
        }
        .headertopfixed tr td div.GridCellDiv
        {
            width: 100% !important;
        }
        #ctl00_cph_main_content_GrdAccessory
        {
            border-top: 0px;
            border-width: 0px !important;
        }
        #ctl00_cph_main_content_GrdAccessory tr:nth-child(2) td
        {
            height: 31px;
            padding: 0px 0px;
            border-top: 0px;
        }
        
        .headertopfixed tr th:first-child div.GridCellDiv
        {
            width: 100% !important;
        }
        .headertopfixed tr th:not(:first-child) div.GridCellDiv
        {
            width: 100% !important;
        }
        
        #ctl00_cph_main_content_GrdAccessoryCopy th
        {
            font-size: 11px !important;
        }
        #ctl00_cph_main_content_GrdAccessoryPanelHeader
        {
            width: 1110px !important;
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdAccessoryPanelItem
        {
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdAccessoryVerticalRail
        {
            width: 5px !important;
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdAccessoryVerticalBar
        {
            width: 5px !important;
            right: 10px !important;
            cursor: pointer;
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
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .headertopfixed td:first-child
        {
            border-left-color: #999 !important;
            padding-left: 2px;
        }
        .headertopfixed td:last-child
        {
            border-right-color: #999 !important;
        }
        .headertopfixed tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        td.border_last_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        /* @media screen and (max-width: 1366px) 
        {
            .pending_order_heading
            {
             margin-left: 0px;   
             }
            
          }*/
        .txtLeft
        {
            text-align: left;
            padding-left: 2px !important;
        }
        #ctl00_cph_main_content_GrdAccessoryCopy
        {
            margin-left: 0px !important;
        }
        #ctl00_cph_main_content_GrdAccessory
        {
            margin-left: 0px !important;
        }
        select.borderColorRed
        {
            border: 1px solid red !important;
        }
        .headerStickyPe
        {
            color: #fff;
            background: #39589c;
            text-align: center;
            margin: 0px 0px;
            font-weight: normal;
            font-size: 15px;
            width: 99%;
            margin-left: 0px;
            clear: both;
        }
        @media (min-width: 1601px) and (max-width: 1920px)
        {
             .table_width
            {
               
                width: 1010px;
                height: 550px;
                height: 700px;
                 margin: 0 auto;
            }
             .ContainerWidth
            {
                 margin: 0 auto;
                 width: 1010px;
                 clear:both;
            }
        }
        @media (min-width: 1367px) and (max-width: 1600px)
        {
            .table_width
            {
               
                width: 1010px;
                height: 550px;
                height: 600px;
                 margin: 0 auto;
            }
             .ContainerWidth
            {
                 margin: 0 auto;
                 width: 1010px;
                  clear:both;
            }
        
        }
        @media (min-width: 1281px) and (max-width: 1366px)
        {
            .table_width
            {
                margin: 0 auto;
                width: 1010px;
                height: 550px;
            }
             .ContainerWidth
            {
                 margin: 0 auto;
                 width: 1010px;
                  clear:both;
            }
        
        }
        @media screen and (max-width: 1280px)
        {
            .table_width
            {
                margin: 0 auto;
                width: 960px;
                height: 500px;
            }
        
        
        }
        .RowBackColor
        {
            background: #f1eaf0;
        }
        td[colspan="10"]
        {
            border: 0px;
            padding-left: 0px !important;
        }
    </style>
    <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        $(function () {
            ManipulateGrid();
            gridviewScroll();            

        });

        function ManipulateGrid() {
            //debugger;
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var Stage1 = $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage1" + "']").find("option:selected").val();
                if ((Stage1 == -1) || (Stage1 == 2)) {
                    $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").attr("disabled", "disabled");
                }

                
                var ContactNumberMaxVal = $("#<%= GrdAccessory.ClientID %>_" + gvId + "_hdnContactNumber").val();
                var ContactMaxLen = ContactNumberMaxVal.length;
                // alert(ContactNumberMaxVal);
                if (ContactMaxLen > 14) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });

                    $("#<%= GrdAccessory.ClientID %>_" + gvId + "_lblContractNumber").attr('data-title', ContactNumberMaxVal);

                }
                var LineNumberMaxVal = $("#<%= GrdAccessory.ClientID %>_" + gvId + "_hdnLineItemNumber").val();
                var LineMaxLen = LineNumberMaxVal.length;
                if (LineMaxLen > 8) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });
                    $("#<%= GrdAccessory.ClientID %>_" + gvId + "_lblLineItemNumber").attr('data-title', LineNumberMaxVal);

                }
                
            }
        }

        function UpdateStageBySerialNo(elem, flag) {
            debugger;
           // alert("test");
            var Ids = elem.id;
            var ThisId = Ids.split("_")[5].substr(3);

            var Stage1 = $("#<%= GrdAccessory.ClientID %> select[id*='ctl" + ThisId + "_ddlStage1" + "']").find("option:selected").val();
            var Stage2 = $("#<%= GrdAccessory.ClientID %> select[id*='ctl" + ThisId + "_ddlStage2" + "']").find("option:selected").val();
            var OrderId = $("#<%= GrdAccessory.ClientID %> input[id*='ctl" + ThisId + "_hdnOrderId" + "']").val();
            var AccessoryMasterId = $("#<%= GrdAccessory.ClientID %> input[id*='ctl" + ThisId + "_hdnAccessoryMasterId" + "']").val();
            var SizeId = $("#<%= GrdAccessory.ClientID %> input[id*='ctl" + ThisId + "_hdnSizeId" + "']").val();
            var ColorPrint = $("#<%= GrdAccessory.ClientID %> input[id*='ctl" + ThisId + "_hdnColorPrint" + "']").val();

            if ((flag == 2) && (ColorPrint.toUpperCase() == 'TBD')) {
                alert("Must fill Color/Print first");
                $("#<%= GrdAccessory.ClientID %> select[id*='ctl" + ThisId + "_ddlStage2" + "']").val('-1');
                return false;
            }
            if ((parseInt(Stage1) == 2) && (ColorPrint.toUpperCase() == 'TBD')) {
                alert("Can not select Finish with TBD as color");
                $("#<%= GrdAccessory.ClientID %> select[id*='ctl" + ThisId + "_ddlStage1" + "']").val('-1');
                return false;
            }
           
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var OrderId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnOrderId" + "']").val();
                var AccessoryMasterId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnAccessoryMasterId" + "']").val();
                var SizeId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnSizeId" + "']").val();
                var ColorPrint_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnColorPrint" + "']").val();    
                     
                if ((OrderId == OrderId_Row) && (AccessoryMasterId == AccessoryMasterId_Row) && (SizeId == SizeId_Row) && (ColorPrint == ColorPrint_Row)) {
                    //debugger;
                    if (flag == 1) {
                        $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage1" + "']").val(Stage1).attr("selected", "selected");

                        if ((Stage1 == -1) || (Stage1 == 2) || (ColorPrint == 'N/A')) {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").val('-1');
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").attr("disabled", "disabled");
                        }
                        else {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").removeAttr('disabled', 'disabled');
                        }
                    }
                    else if (flag == 2) {
                        $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").val(Stage2).attr("selected", "selected");
                    }
                    //debugger;
                        var OrderDetailId = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnOrderDetailId" + "']").val();
                        var AccessoryWorkingDetailId = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdAccessoryWorkingDetailId" + "']").val();
                        //alert('222Stage2= ' + Stage2);
                        proxy.invoke("Update_AccessoryPending_Orders", { OrderDetailID: OrderDetailId, AccessoryworkingdetailId: AccessoryWorkingDetailId, Stage1: Stage1, Stage2: Stage2 },
                        function (result) {
                            //debugger;
                            var Stage1SRVQty = result.Stage1SRVReceivedQty;
                            var Stage2SRVQty = result.Stage2SRVReceivedQty;
                           
                            if ((parseInt(Stage1SRVQty) > 0) || (parseInt(Stage2SRVQty) > 0)) {
                                DisableStage(Stage1SRVQty, Stage2SRVQty, OrderId, AccessoryMasterId, SizeId, ColorPrint);
                            }

                        });

                        if ((flag == 1) && (Stage1 == 1) && (ColorPrint.toUpperCase() != 'N/A') && (ColorPrint.toUpperCase() != 'TBD')) {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").addClass("borderColorRed");                            
                        }
                        else {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").removeClass("borderColorRed");
                        }
                        if ((flag == 2) && (Stage2 != -1) && (ColorPrint != 'N/A')) {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage1" + "']").attr("disabled", "disabled");
                        }
                        if ((flag == 2) && (Stage2 == -1) && (ColorPrint != 'N/A')) {
                            $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage1" + "']").removeAttr("disabled", "disabled");
                        }
                        
                    }               

                }
                //alert("aaaa");
                if ((flag == 1) && (Stage1 == 1) && (ColorPrint != 'N/A') && (ColorPrint.toUpperCase() != 'TBD')) {
                    alert("Must select second stage");
                    return false;
                }

            }

            function DisableStage(Stage1SRVQty, Stage2SRVQty, OrderId, AccessoryMasterId, SizeId, ColorPrint) {
                //debugger;
                var RowId = 0;
                var gvId;
                var GridRow = $(".gvRow").length;

                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var OrderId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnOrderId" + "']").val();
                    var AccessoryMasterId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnAccessoryMasterId" + "']").val();
                    var SizeId_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnSizeId" + "']").val();
                    var ColorPrint_Row = $("#<%= GrdAccessory.ClientID %> input[id*='" + gvId + "_hdnColorPrint" + "']").val();

                    if ((OrderId == OrderId_Row) && (AccessoryMasterId == AccessoryMasterId_Row) && (SizeId == SizeId_Row) && (ColorPrint == ColorPrint_Row)) {
                        //debugger;
                                if (parseInt(Stage1SRVQty) > 0) {
                                    $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage1" + "']").attr("disabled", "disabled");
                                }
                                if (parseInt(Stage2SRVQty) > 0) {
                                    $("#<%= GrdAccessory.ClientID %> select[id*='" + gvId + "_ddlStage2" + "']").attr("disabled", "disabled");
                                }
                    }
                }

            }


        function gridviewScroll() {
            var gridWidth = $('#widthdiv').width() + 10;
            var gridHeight = $('#widthdiv').height() + 10;
            $('.headertopfixed').gridviewScroll({
                width: gridWidth,
                height: gridHeight
            });
        }

        //Add code By Bharat On 7-Oct-20 for Row Highlight
        $(document).ready(function () {
            $('.PendingSummaryTable tr td').click(function () {
                //debugger;
                $('td').removeClass('RowBackColor');
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });
            $('.PendingSummaryTable tr td').click(function () {
                $('td[rowspan]').removeClass('RowBackColor');
            });
            $('.PendingSummaryTable tr td[rowspan]:first-child').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                //  $('td[rowspan]').addClass('RowBackColor'); ;
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });
            $('.PendingSummaryTable tr td[rowspan]:nth-child(2)').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                $('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
            });
            $('.PendingSummaryTable tr td[rowspan]:nth-child(3)').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                $('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
                $('td[rowspan]:nth-child(2)').removeClass('RowBackColor');
            });
        })

        function pageLoad() {
            ManipulateGrid();
            gridviewScroll();
            $('.PendingSummaryTable tr td').click(function () {
                //debugger;
                $('td').removeClass('RowBackColor');
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });
            $('.PendingSummaryTable tr td').click(function () {
                $('td[rowspan]').removeClass('RowBackColor');
            });
            $('.PendingSummaryTable tr td[rowspan]:first-child').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                //  $('td[rowspan]').addClass('RowBackColor'); ;
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });
            $('.PendingSummaryTable tr td[rowspan]:nth-child(2)').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                $('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
            });
            $('.PendingSummaryTable tr td[rowspan]:nth-child(3)').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                $('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
                $('td[rowspan]:nth-child(2)').removeClass('RowBackColor');
            });

            var maxRow = 0;
            var rowSpan = 0;
            $('.PendingSummaryTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRow) {
                    maxRow = row;
                    rowSpan = 0;
                }
                if ($(this).attr('rowspan') > rowSpan) rowSpan = $(this).attr('rowspan');
            });
            if (maxRow == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpan - 1)) {
                $('.PendingSummaryTable td[rowspan]').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRow && $(this).attr('rowspan') == rowSpan) $(this).addClass('border_bottom_color');
                });
            }

            var maxRowCol = 0;
            var rowSpanCol = 0;
            $('.PendingSummaryTable td[rowspan].GriegeTableCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowCol) {
                    maxRowCol = row;
                    rowSpanCol = 0;
                }
                if ($(this).attr('rowspan') > rowSpanCol) rowSpanCol = $(this).attr('rowspan');
            });
            if (maxRowCol == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanCol - 1)) {
                $('.PendingSummaryTable td[rowspan].GriegeTableCol').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowCol && $(this).attr('rowspan') == rowSpanCol) $(this).addClass('border_bottom_color');
                });
            }
            var maxRowColSt = 0;
            var rowSpanColSt = 0;
            $('.PendingSummaryTable td[rowspan].GriegeTableSt').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowColSt) {
                    maxRowColSt = row;
                    rowSpanColSt = 0;
                }
                if ($(this).attr('rowspan') > rowSpanColSt) rowSpanColSt = $(this).attr('rowspan');
            });
            if (maxRowColSt == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanColSt - 1)) {
                $('.PendingSummaryTable td[rowspan].GriegeTableSt').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowColSt && $(this).attr('rowspan') == rowSpanColSt) $(this).addClass('border_bottom_color');
                });
            }
            //new code added by raghvinder on 27 Jan 2021 start
            //debugger;
            $('input.accessory', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/AutoComplete_Accessory_Pending_OrderSummary", { dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                 {
                     stno: "",
                     ClientID: -999,
                     PrintCategory: 0
                 }
            });
             //new code added by raghvinder on 27 Jan 2021 end
        }

        //End Code
    </script>
    <%--  end--%>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <div class="ContainerWidth">
            <div class="headerStickyPe">Accessory Pending Order for stage selection</div>
                <div style="float: left; margin: 4px 0px;">
                    <asp:TextBox ID="txtsearchkeyswords" class="accessory" placeholder="Search Accessory Quality/Style No/Serial No"
                        runat="server" Style="width: 300px !important; margin: 0px 0px 1px; padding-left: 4px;
                        text-align: left; font-size: 11px;"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                        Style="padding: 2px 7px;" OnClick="btnSearch_Click" />
                </div>
          </div>
            <div id="widthdiv" class="table_width">
              
                <asp:GridView ID="GrdAccessory" runat="server" AutoGenerateColumns="False" CssClass="grds headertopfixed PendingSummaryTable"
                    ShowHeader="true" EmptyDataText="No Record Found!" Width="1000px" HeaderStyle-Font-Names="Arial"
                    HeaderStyle-HorizontalAlign="Center" BorderWidth="1" rules="all" HeaderStyle-CssClass="ths"
                    Style="margin: 0 auto;" OnRowDataBound="GrdAccessory_RowDataBound" OnDataBound="GrdAccessory_DataBound">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <RowStyle CssClass="gvRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print">
                            <ItemStyle HorizontalAlign="Center" CssClass="txtLeft GriegeTableCol" Height="20px"
                                Width="200px" />
                            <HeaderStyle HorizontalAlign="Center" Width="201px" />
                            <ItemTemplate>
                            <a href='AccessoryOrderPlacement.aspx?AccessoryName=<%# Eval("AccessoryName") %>&stage1=<%# Eval("Stage1")%>'target="_blank" title="Raise & Revise Accessory Po" style="text-decoration:none">
                                <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'
                                    runat="server"></asp:Label></a>
                                <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Style Number">
                            <ItemTemplate>
                                <asp:Label ID="lblstylenumber" ForeColor="Black" Text='<%# Eval("StyleNumber")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="98px" CssClass="GriegeTableSt" />
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial No.(Order Date)">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" ForeColor="Black" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>&nbsp;
                                (<asp:Label ID="lblOrderDate" Text='<%# (Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM")%>'
                                    runat="server"></asp:Label>)
                            </ItemTemplate>
                            <ItemStyle Width="100px" CssClass="positionstyle_span" />
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line No. <br>(Ex-Factory)">
                            <ItemTemplate>
                               <div class="TooltipVal" data-maxlength='14'>  <asp:Label ID="lblLineItemNumber" Text='<%# Eval("LineItemNumber")%>' runat="server"></asp:Label></div>
                                <asp:Label ID="lblExFactory" CssClass="txtRight" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                                <asp:HiddenField ID="hdnLineItemNumber" runat="server" Value='<%# Eval("LineItemNumber")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="99px" />
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contract Number">
                            <ItemTemplate>
                                <div class="TooltipVal" data-maxlength='14'>
                                    <asp:Label ID="lblContractNumber" Text='<%# Eval("ContractNumber")%>' runat="server"></asp:Label>
                                </div>
                                <asp:HiddenField ID="hdnContactNumber" runat="server" Value='<%# Eval("ContractNumber")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="92px" />
                            <HeaderStyle HorizontalAlign="Center" Width="92px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Qty.">
                            <ItemTemplate>
                                <asp:Label ID="lblContractQty" ForeColor="Black" Text='<%# Convert.ToString(Eval("ContractQty")) == "0" ? "" : Convert.ToInt32(Eval("ContractQty")).ToString("N0")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Avg.">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryAvg" Text='<%# Convert.ToString(Eval("AccessoryAvg")) == "0" ? "" : Convert.ToString(Eval("AccessoryAvg")).ToString()%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accessories Qty.">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQty" ForeColor="Black" Text='<%# Convert.ToString(Eval("AccessoryQty")) == "0" ? "" : Convert.ToString(Eval("AccessoryQty")).ToString()%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>' runat="server" />
                                <asp:HiddenField ID="hdnSizeId" Value='<%# Eval("AccessoryQualitySizeId")%>' runat="server" />
                                <asp:HiddenField ID="hdnColorPrint" Value='<%# Eval("Color_Print")%>' runat="server" />
                                <asp:HiddenField ID="hdAccessoryWorkingDetailId" Value='<%# Eval("AccessoryWorkingDetailId")%>' runat="server" />

                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailId")%>' runat="server" />
                                <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("OrderId")%>' runat="server" />
                                <asp:HiddenField ID="hdnIsAccessoryFinish" Value='<%# Eval("IsAccessoryFinish")%>' runat="server" />
                                <asp:HiddenField ID="hdnIsDefaultAccessory" Value='<%# Eval("IsDefaultAccessory")%>' runat="server" />
                                
                            </ItemTemplate>
                            <ItemStyle Width="71px" />
                            <HeaderStyle HorizontalAlign="Center" Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stage 1">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlStage1" onchange="javascript:UpdateStageBySerialNo(this, 1);" runat="server">
                                    <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Greige"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Finish"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnStage1" Value='<%# Eval("Stage1")%>' runat="server" />
                                <asp:HiddenField ID="hdnStage1SrvQty" Value='<%# Eval("Stage1SRVReceivedQty")%>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="80px" CssClass="Stage1 backcolorstages" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stage 2">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlStage2" onchange="javascript:UpdateStageBySerialNo(this, 2);" runat="server">
                                    <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Process"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnStage2" Value='<%# Eval("Stage2")%>' runat="server" />
                                <asp:HiddenField ID="hdnStage2SrvQty" Value='<%# Eval("Stage2SRVReceivedQty")%>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="80px" CssClass="Stage2 backcolorstages" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="grds headertopfixed PendingSummaryTable" cellspacing="0" rules="all"
                            border="1" style="border-width: 1px; border-style: solid; width: 1000px; border-collapse: collapse;
                            margin: 0 auto;">
                            <tbody>
                                <tr class="ths" align="center" style="font-family: Arial;" id="ctl00_cph_main_content_GrdAccessoryHeaderCopy">
                                    <th align="center" scope="col" style="width: 201px;">
                                        <div class="GridCellDiv" style="width: 200px;">
                                            Accessory Quality (Size)<br>
                                            Color/Print</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 100px;">
                                        <div class="GridCellDiv" style="width: 98px;">
                                            Style Number</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 100px;">
                                        <div class="GridCellDiv" style="width: 100px;">
                                            Serial No.(Order Date)</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 100px;">
                                        <div class="GridCellDiv" style="width: 99px;">
                                            Line No.
                                            <br>
                                            (Ex-Factory)</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 92px;">
                                        <div class="GridCellDiv" style="width: 92px;">
                                            Contract Number</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 50px;">
                                        <div class="GridCellDiv" style="width: 50px;">
                                            Order Qty.</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 50px;">
                                        <div class="GridCellDiv" style="width: 50px;">
                                            Avg.</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 70px;">
                                        <div class="GridCellDiv" style="width: 71px;">
                                            Accessories Qty.</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 80px;">
                                        <div class="GridCellDiv" style="width: 80px;">
                                            Stage 1</div>
                                    </th>
                                    <th align="center" scope="col" style="width: 80px;">
                                        <div class="GridCellDiv" style="width: 79px;">
                                            Stage 2</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="10" style="border: 1px solid #999; border-top: 0px; text-align: center">
                                        <img src="../../images/sorry.png" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
