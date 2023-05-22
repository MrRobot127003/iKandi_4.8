<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoriesFourPointCheckInspection.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoriesFourPointCheckInspection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boutique International Pvt. Ltd.</title>
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <style>
        body
        {
            font-family: Arial;
            font-size: 11px;
        }
        .AddClass_Table
        {
            border-collapse: collapse;
            font-family: Arial;
            border: 1px solid #999;
        }
        .AddClass_Table th
        {
            background: #dddfe4;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial;
            text-align: left;
        }
        .RightSide table
        {
            border-collapse: collapse;
        }
        .RightSide table th
        {
            color: #6b6464;
            font-weight: 500;
            border: 1px solid #d2d2d2;
            padding: 5px 5px;
        }
        .RightSide table td
        {
            border: 1px solid #dbd8d8;
            padding: 5px 5px;
        }
        .minWidthTh
        {
            min-width: 80px;
        }
        .minWidthThSize
        {
            min-width: 120px;
        }
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial;
            min-width: 80px;
        }
        .AddClass_Table td:first-child
        {
            border-left-color: #999 !important;
        }
        .AddClass_Table td:last-child
        {
            border-right-color: #999 !important;
        }
        
        .AddClass_Table.MarTop th
        {
            text-align: center;
        }
        .AddClass_Table.MarTop td
        {
            text-align: center;
        }
        .ColorBlackBold
        {
            color: #000;
            font-weight: 600;
        }
        .ColorBlue
        {
            color: blue;
        }
        .ColorGray
        {
            color: gray;
        }
        .ColorGrayBold
        {
            color: gray;
            font-weight: 600;
        }
        .ColorRedStrick
        {
            color: red;
            position: relative;
            top: -2px;
        }
        .TopHeader
        {
            width: 1178px;
            font-size: 15px;
            color: #fff;
            text-align: center;
            background: #39589C;
            margin-bottom: 2px;
            padding: 3px 0px;
            position: relative;
        }
        .bottom_serialno
        {
            background-color: #39589C;
            color: #d8d8d8;
            padding: 6px;
            font-size: 12px;
            width: 1166px;
        }
        .bottom_serialno span
        {
            color: #d8d8d8;
        }
        .TopHeader span
        {
            color: #fff;
        }
        
        td.minWidth
        {
            min-width: 104px;
        }
        .txtCenter
        {
            text-align: center;
        }
        th.txtCenter
        {
            text-align: center;
        }
        .GrdtxtControl
        {
            width: 85%;
            margin: 2px 2px;
        }
        .MarTop
        {
            margin-top: 5px;
        }
        td.RadioLable
        {
            width: 100px;
        }
        td.RadioLable label
        {
            position: relative;
            top: -3px;
        }
        .facolor
        {
            font-size: 15px;
        }
        .bordertable i
        {
            font-size: 12px;
            margin: 0 2px;
        }
        .editbucolor
        {
            color: green;
        }
        .m-r-5
        {
            margin-right: 5px;
        }
        .TotalRw td
        {
            text-align: center;
            font-size: 13px;
            background: #f1f1f1;
            font-weight: 600;
            padding: 3px 5px;
        }
        ul
        {
            margin: 0px;
            padding: 5px 0px 0px 14px;
        }
        ul li
        {
            padding: 5px 0px 0px 0px;
            color: gray;
        }
        .RightSide input[type="radio"]
        {
            position: relative;
            top: 2px;
        }
        .RightSide
        {
            /* box-shadow: -13px -2px 36px -2px #ccc; */
            box-shadow: 1px 0px 5px 1px #ccc;
            padding: 10px 10px;
            position: relative;
            top: 6px;
            padding-top: 30px;
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        .GMCheckbox
        {
            text-align: left;
            padding-right: 10px;
            padding-top: 60px;
            padding-bottom: 0px;
            font-size: 12px;
            width: 117px;
            float: right;
        }
        .GMCheckbox label, span
        {
            color: gray;
        }
        .QACheckbox
        {
            text-align: left;
            padding-right: 10px;
            padding-top: 10px;
            font-size: 12px;
            width: 246px;
            float: left;
        }
        .QACheckbox2
        {
            text-align: right;
        }
        .AllChecker
        {
            text-align: center;
            padding-top: 30px;
            clear: both;
        }
        .btnSubmit
        {
            font-size: 12px;
            padding: 5px 10px;
            color: #fff;
            background: green;
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid green;
            cursor: pointer;
        }
        .btnClose
        {
            font-size: 12px;
            padding: 5px 10px;
            color: #fff;
            background: green;
            margin-right: 5px;
            border-radius: 2px;
            cursor: pointer;
        }
        .btnPrint
        {
            font-size: 12px;
            padding: 5px 15px;
            color: #fff;
            background: #39589C;
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid #39589C;
            cursor: pointer;
        }
        .RightSide span
        {
            color: #6b6464;
        }
        .GreigeShrnk
        {
            position: absolute;
            left: 5px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
        }
        .ReshShrnk
        {
            position: absolute;
            left: 133px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
        }
        
        .ChangePositionReshShrnk
        {
            position: fixed;
            left: 0px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
            margin-left: 10px;
        }
        .ChangePositionlblShrinkage
        {
            position: fixed;
            left: 77px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
        }
        .GreigeShrnk span
        {
            color: #d8d8d8;
        }
        .ReshShrnk span
        {
            color: #d8d8d8;
        }
        .DisplayBlock
        {
            display: block;
            width: 116px;
        }
        .DisplayBlock .txtRaise
        {
            width: 36px;
            height: 11px;
            text-align: center;
            margin: 2px 2px;
        }
        .DisInlineBlock
        {
            width: 65px;
            display: inline-block;
        }
        .LavContainer
        {
            padding-top: 1px;
        }
        .LavContainer span
        {
            color: #6b6464;
        }
        .LavContainer table
        {
            border-collapse: collapse;
            width: 98%;
        }
        .LavContainer table th
        {
            color: #6b6464;
            font-weight: 500;
            border: 1px solid #999;
            padding: 5px 5px;
            background: #f2f2f2;
        }
        .LavContainer table td
        {
            border: 1px solid #d2d2d2;
            padding: 4px 4px;
        }
        .txtWidth
        {
            float: left;
            height: 10px;
            width: 30px;
        }
        #fileToUpload
        {
            width: 84px;
            font-size: 10px;
        }
        select
        {
            font-size: 10px;
        }
        .RightSidedate
        {
            float: right;
            position: relative;
            top: 2px;
        }
        
        .Passfail
        {
            background: #fff1f1;
        }
        .Passfail label
        {
            position: relative;
            top: -2px;
        }
        input[type="text"]
        {
            font-size: 11px;
            width: 95%;
            text-transform: capitalize;
            margin: 2px 0px;
        }
        .BalckgroundColor
        {
            background: #fff1f1;
        }
        textarea
        {
            text-transform: capitalize;
            font-size: 10px;
        }
        #dvHistory
        {
            width: 98%;
            padding: 6px 0px;
            height: 47px;
            max-height: 47px;
            overflow: auto;
        }
        a
        {
            text-decoration: none;
        }
        .TotalTable
        {
            border: 0px;
            border-collapse: collapse;
            width: 1178px;
        }
        .TotalTable td
        {
            border: 1px solid #d2d2d2;
            border-top: 0px;
            min-width: 98px;
            padding: 5px 0px;
            border-bottom-color: #999;
        }
        
        #grv_Accessories_Inspection td input[type='text']
        {
            text-align: center;
            font-size: 11px;
            height: 13px;
            margin: 2px 0px;
        }
        #totalAccInspection td
        {
            text-align: center;
            font-size: 12px;
            font-weight: bold;
        }
        
        #grv_Accessories_Inspection td
        {
            min-width: 90px;
            max-width: 90px;
        }
        .EmptyRowTable td
        {
            padding: 0px 0px !important;
            border: 0px;
        }
        .EmptyRowTable td[colspan="10"]
        {
            padding: 0px 0px !important;
            border: 0px;
        }
        .EmptyRowTable td table.EmptyTable
        {
            width: 100%;
        }
        .EmptyRowTable td .EmptyTable th
        {
            min-width: 90px;
            max-width: 90px;
        }
        .EmptyRowTable td .EmptyTable td
        {
            border: 1px solid #9999;
        }
        .EmptyRowTable td .EmptyTable td input[type="text"]
        {
            width: 85%;
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
        ul
        {
            margin: 0px;
            padding: 5px 0px 0px 14px;
        }
        li
        {
            padding: 5px 0px 0px 0px;
            color: gray;
            list-style: none;
        }
        div.historyDiv
        {
            margin: 2px 0px;
        }
        div span.CommentBullet
        {
            width: 5px;
            height: 5px;
            border-radius: 50%;
            display: inline-block;
            background: gray;
            margin-right: 4px;
            margin-left: 5px;
            position: relative;
            top: -1px;
        }
        
        .GreigeStage
        {
            position: absolute;
            margin-left: 290px;
            font-size: 12px;
            margin-top: 2px;
        }
        .ProcessStage
        {
            position: absolute;
            margin-left: 336px;
            font-size: 12px;
            margin-top: 2px;
        }
        .FinishStage
        {
            position: absolute;
            margin-left: 346px;
            font-size: 12px;
            margin-top: 2px;
        }
        
        
        .tooltip
        {
            position: relative;
            display: inline-block;
        }
        
        .tooltip .tooltiptext
        {
            visibility: hidden;
            width: 120px;
            background-color: #555;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            position: absolute;
            z-index: 1;
            bottom: 125%;
            left: 50%;
            margin-left: -60px;
            opacity: 0;
            transition: opacity 0.3s;
        }
        
        .tooltip .tooltiptext::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 50%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #555 transparent transparent transparent;
        }
        
        .tooltip:hover .tooltiptext
        {
            visibility: visible;
            opacity: 1;
        }
    </style>
    <script type="text/javascript">
        function GetParameterValues(param) {

            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0].toLowerCase() == param.toLowerCase()) {
                    return urlparam[1];
                }
            }
        };

        var serviceUrl = "../../Webservices/iKandiService.asmx";
        var proxy = new ServiceProxy(serviceUrl);
        var totalActualLength = 0;
        function isNumber(val, evt) {


            //            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //            if (charCode != 46 && charCode > 31
            //            && (charCode < 48 || charCode > 57))
            //                return false;
            //  alert(evt.which);
            console.log(val.value);
            if ((evt.which != 46 || val.value.indexOf('.') != -1) && (evt.which < 48 || evt.which > 57)) {
                //event it's fine
                return false;

            }
            var input = val.value;
            if ((input.indexOf('.') != -1) && (input.substring(input.indexOf('.')).length > 2)) {
                return false;
            }
        }

        $(document).ready(function () {
            $(".allownumericwithoutdecimal").on("keypress keyup blur paste", function (event) {
                var that = this;
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

            });

            if ($("#chkLabManager").is(':checked') || $("#chkAccessoriesQA").is(':checked')) {
                var checked = 1;
                if ($("#hdnLoginId").val() == "40" && $("#chkLabManager").is(':checked')) {
                    $("#btnSubmit").attr("disabled", true);
                }
            }
            else {
                var checked = 0;
            }
            if ($("#hdnLoginId").val() != "15" && $("#chkAccessoriesQA").is(':checked') && $("#chkLabManager").is(':checked')) {
                $("#btnSubmit").attr("disabled", true);
            }

            if ($("#rbtFinalDecisionPass").is(':checked') || $("#rdybtnCommercialPass").is(':checked') || $("#rbtFinalDecisionFail").is(':checked')) {
                if (!$("#chkAccessoriesQA").is(':checked')) {
                    $("#chkAccessoriesQA").attr("disabled", false);
                    $("#rbtFinalDecisionPass").attr("disabled", false);
                    $("#rdybtnCommercialPass").attr("disabled", false);
                    $("#rbtFinalDecisionFail").attr("disabled", false);
                }
                else {
                    $("#chkAccessoriesQA").attr("disabled", true);

                    $("#rbtFinalDecisionPass").attr("disabled", true);
                    $("#rdybtnCommercialPass").attr("disabled", true);
                    $("#rbtFinalDecisionFail").attr("disabled", true);
                }
            }
            //            else if ($("#hdnLoginId").val() == "148") {
            //                $("#rbtFinalDecisionPass").attr("disabled", false);
            //                $("#rdybtnCommercialPass").attr("disabled", false);
            //                $("#rbtFinalDecisionFail").attr("disabled", false);
            //            }

            if ($("#chkAccessoriesQA").is(':checked')) {
                if ($("#rbtFinalDecisionPass").is(':checked') || $("#rdybtnComeercialPass").is(':checked') || $("#rbtFinalDecisionFail").is(':checked')) {
                    $("#finalDecission").attr('data-disabled', 'true');

                    if ($("#rbtFinalDecisionPass").is(':checked')) {
                        $("#hdnDecissionPass").val('1');
                    }
                    if ($("#rdybtnComeercialPass").is(':checked')) {

                        $("#hdnDecissionCommercialpass").val('1');
                        //                        alert(x);

                    }
                    if ($("#rbtFinalDecisionFail").is(':checked')) {

                        $("#hdnDecissionFail").val('1');

                    }
                    $("#rbtFinalDecisionPass").attr("disabled", true);
                    $("#rdybtnCommercialPass").attr("disabled", true);
                    $("#rbtFinalDecisionFail").attr("disabled", true);
                    //alert($("#hdnLoginId").val());
                    if ($("#hdnLoginId").val() == "148") {
                        $("#btnSubmit").attr("disabled", true);
                    }
                }

            }
            if ($("#chkLabManager").is(':checked') || $("#chkAccessoriesQA").is(':checked')) {

                if ($("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                    $("#rdyBtnLabDecPassInter").attr("disabled", true);
                    $("#rdyBtnLabDecFailInter").attr("disabled", true);

                }
                if ($("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {

                    $("#rdyBtnLabDecPassExt").attr("disabled", true);
                    $("#rdyBtnLabDecFailExt").attr("disabled", true);

                }
            }
            //            if ($("#chkAccessoriesQA").is(':checked')) {

            //                $("#rbtFinalDecisionPass").attr("disabled", true);
            //                $("#rdybtnCommercialPass").attr("disabled", true);
            //                $("#rbtFinalDecisionFail").attr("disabled", true);
            //            }
            if ($("#chkAccessoriesQA").is(':checked') && $("#chkLabManager").is(':checked') && $("#chkAccessoriesGM").is(':checked')) {
                //  aler("hello9");
                $("#btnSubmit").attr("disabled", true);
                //$("#btnSubmit").tooltip("Please do Signature");
            }
            //            else if ($("#chkAccessoriesQA").is(':checked') && $("#chkLabManager").is(':checked') && $("#chkAccessoriesGM").is(':checked')) {
            //                $("#btnSubmit").attr("disabled", true);
            //                // $("#btnSubmit").tooltip("");



            //            }
            else {

                //   $("#btnSubmit").attr("disabled", false);
            }

            $("#chkAccessoriesGM").change(function () {
                if ($("#chkAccessoriesGM").is(':checked')) {

                    $("#btnSubmit").attr("disabled", false);

                }
            });
            $("#btnSubmit").click(function () {
                if ($("#hdnLoginId").val() == "25") {
                    alert("You don't have permission !");
                    return false;

                }

                var isGmChecked = $("#chkAccessoriesGM").is(':checked') ? 1 : 0;
                var FailedRaisedDebit = $("#txtFailedRaisedDebit").val() == "" ? 0 : $("#txtFailedRaisedDebit").val();
                var FailedStock = $("#txtFailedStock").val() == "" ? 0 : $("#txtFailedStock").val();
                var FailedGoodStock = $("#txtFailedGoodStock").val() == "" ? 0 : $("#txtFailedGoodStock").val();
                var InspectRaisedDebit = $("#txtInspectRaisedDebit").val() == "" ? 0 : $("#txtInspectRaisedDebit").val();
                var InspectUsableStock = $("#txtInspectUsableStock").val() == "" ? 0 : $("#txtInspectUsableStock").val();
                var srv_id = GetParameterValues('SrvID');

                //  alert(srv_id);
                proxy.invoke("UpdateAccessoryGMSignature", { isGmChecked: isGmChecked, FailedRaisedDebit: FailedRaisedDebit, FailedStock: FailedStock, FailedGoodStock: FailedGoodStock, InspectRaisedDebit: InspectRaisedDebit, InspectUsableStock: InspectUsableStock, Srv_id: srv_id },
                    function (result) {
                        //closePage();
                        alert("Updated successfully");
                    });
            });

            $("#rbtFinalDecisionPass").change(function () {
                if ($("#rbtFinalDecisionPass").is(':checked')) {
                    $("#hdnFinalPass").val('1');
                    $("#hdnCommercialPass").val('-1');
                    $("#HdnFinalFail").val('-1');
                }

            });

            $("#rdybtnCommercialPass").change(function () {

                if ($("#rdybtnCommercialPass").is(':checked')) {

                    $("#hdnCommercialPass").val('1');
                    $("#hdnFinalPass").val('1');
                    $("#HdnFinalFail").val('-1');

                }

            });
            $("#rbtFinalDecisionFail").change(function () {

                if ($("#rbtFinalDecisionFail").is(':checked')) {

                    $("#HdnFinalFail").val('0');
                    $("#hdnCommercialPass").val('-1');
                    $("#hdnFinalPass").val('-1');


                } s



            });

        });
        //new code for edit mode validation start
        function EditModeValidation() {


            //grv_Accessories_Inspection_ctl04_lkEdit
            //grv_Accessories_Inspection_ctl04_lkUpdate
            //            var length = $("#grv_Accessories_Inspection tr").length;
            //            var updateStatus = '';
            //            for (var i = 2; i <= length; i++) {

            //            
            //                Box = $("#grv_Accessories_Inspection_ctl0" + i.toString() + "_lblRollNo").text() == "" ? 0 : parseInt($("#grv_Accessories_Inspection_ctl0" + i.toString() + "_lblRollNo").text().replace(/,/g, ''));
            //            }


            //            if ($("table[id*=grv_Accessories_Inspection] input[id*='txtRollNo']").length > 0) {
            //                //$("#lkUpdate").trigger('click');

            //                // $("input[id*='lkUpdate']").trigger('click');
            //                //$('[id$="lkUpdate"]').trigger('click');
            //               
            //                alert("Please finish editing order and then submit");
            //                //alert($("input[id*='txtRollNo']").val());
            //                return false;
            //               
            //            }
            //            else {
            //                return true;
            //            }
        }
        //new code for edit mode validation end

        function FailExtraQtyValidationSubmit() {

            var TotalFailQty = 0;
            var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseFloat($("#lblTotalFailQty").text().replace(/,/g, ''));
            var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseFloat($("#txtFailedRaisedDebit").val().replace(/,/g, ''));
            var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseFloat($("#txtFailedStock").val().replace(/,/g, ''));
            var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseFloat($("#txtFailedGoodStock").val().replace(/,/g, ''));
            if (failQty != 0) {
                TotalFailQty = FailRaisedQty + FailStockQty + FailGoodQty;
                //if (hdnGM_Manager.val() == "1" || hdnQAManager.val() == "1") {
                if (hdnGM_Manager.value == "1" || hdnQAManager.value == "1") {
                    if (TotalFailQty > 0) {
                        if (FailGoodQty > 0) {
                            alert('Must resolve the usable stock quantity segregation.');
                            //$(this).prop("checked", false);
                            return false;
                        }

                        if (TotalFailQty == 0) {
                            alert('Must resolve the fail quantity segregation.');
                            // $(this).prop("checked", false);
                            return false;
                        }

                        else if (TotalFailQty != failQty) {
                            alert('Must resolve the fail quantity segregation.');
                            //$(this).prop("checked", false);
                            return false;
                        }

                        if (FailRaisedQty > 0) {
                            if ($("#txtFailedParticular").val() == "") {
                                alert("Particular can't blank.");
                                //$(this).prop("checked", false);
                                return false;
                            }
                        }
                    }
                }
            }

            var TotalExtraQty = 0;
            var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseFloat($("#lblInspectExtraQty").text().replace(/,/g, ''));
            var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseFloat($("#txtInspectRaisedDebit").val().replace(/,/g, ''));
            var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseFloat($("#txtInspectUsableStock").val().replace(/,/g, ''));
            if (ExtraQty != 0) {
                TotalExtraQty = ExtraRaisedQty + ExtraUsableQty;
                if (hdnGM_Manager.value == "1" || hdnQAManager.value == "1") {
                    if (TotalExtraQty > 0) {
                        //                    if (ExtraUsableQty > 0) {
                        //                        alert('Must resolve the usable stock quantity segregation.');
                        //                        $(this).prop("checked", false);
                        //                        return;
                        //                    }                    

                        if (TotalExtraQty == 0) {

                            alert('Must resolve the extra quantity segregation.');
                            // $(this).prop("checked", false);
                            return false;
                        }
                        else if (TotalExtraQty != ExtraQty) {
                            alert('Must resolve the extra quantity segregation.');
                            //$(this).prop("checked", false);
                            return false;
                        }
                        if (ExtraRaisedQty > 0) {
                            if ($("#txtInspectParticular").val() == "") {
                                alert("Particular can't blank.");
                                // $(this).prop("checked", false);
                                return false;
                            }
                        }
                    }
                }
            }
        }

        function EnableDisableParticular(elem, type) {

            var RaiseDebit = elem.value;
            if (type == 'FailedQty') {
                if (RaiseDebit == "") {
                    $("#txtFailedParticular").attr("disabled", true);
                    $("#txtFailedParticular").attr("placeholder", "");
                }
                else {
                    //placeholder = "Debit Particular"
                    if ($('#chkAccessoriesGM').is(':checked') == false) {
                        $("#txtFailedParticular").attr("placeholder", "Debit Particular");
                        $("#txtFailedParticular").attr("disabled", false);
                    }
                    else {
                        $("#txtFailedParticular").attr("disabled", true);
                    }

                }
            }
            if (type == 'ExtraQty') {
                if (RaiseDebit == "") {
                    $("#txtInspectParticular").attr("disabled", true);
                    $("#txtInspectParticular").attr("placeholder", "");
                }
                else {
                    if ($('#chkAccessoriesGM').is(':checked') == false) {
                        $("#txtInspectParticular").attr("placeholder", "Debit Particular");
                        $("#txtInspectParticular").attr("disabled", false);
                    }
                    else {
                        $("#txtInspectParticular").attr("disabled", true);
                    }
                }
            }

        }
        //txtFailedRaisedDebit
        function InternalSentoLabValid() {
            var specimancount = $("#txtInternalLabSpecimanCount").val();

            if (specimancount != "" && specimancount != 0) {
                $("#chkInternalSentToLab").attr('disabled', false);
                //$("#chkInternalReceivedInLab").attr('disabled', false);
                //$("#hylnkInternalLabReportText").attr('disabled', false);
            }
            if (specimancount == "" && specimancount == 0) {
                //$("#chkInternalSentToLab").attr('disabled', 'disabled');
                $("#chkInternalSentToLab").prop('checked', false);
                $("#chkInternalSentToLab").prop('disabled', true);
                //$("#chkInternalReceivedInLab").attr('disabled', true);


            }
        }

        function ExternalSentoLabValid() {
            var specimancount = $("#txtExternalLabSpecimanCount").val();

            if (specimancount != "" && specimancount != 0) {
                $("#chkExternalSentToLab").attr('disabled', false);
            }
            if (specimancount == "" && specimancount == 0) {
                //$("#chkExternalSentToLab").attr('disabled', 'disabled');
                $("#chkExternalSentToLab").prop('checked', false);
                $("#chkExternalSentToLab").prop('disabled', true);
            }
        }

        function specimanInternalCountValidation() {
            var speciCount = $('#txtInternalLabSpecimanCount').val();
            if ($('#chkInternalSentToLab').is(':checked')) {
                if (speciCount == "" && speciCount == 0) {
                    alert("Internal Specimen count can't blank.");
                    $('#txtInternalLabSpecimanCount').val(defaultValue)
                    return false;
                }
            }
        }

        function specimanExternalCountValidation() {
            var speciCount = $('#txtExternalLabSpecimanCount').val();
            if ($('#chkExternalSentToLab').is(':checked')) {
                if (speciCount == "" && speciCount == 0) {
                    alert("External Specimen count can't blank.");
                    return false;
                }
            }
        }



        function FailExtraValidation() {

            //alert('Hello!');
            var TotalFailQty = 0;
            var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseFloat($("#lblTotalFailQty").text().replace(/,/g, ''));
            var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseFloat($("#txtFailedRaisedDebit").val().replace(/,/g, ''));
            var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseFloat($("#txtFailedStock").val().replace(/,/g, ''));
            var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseFloat($("#txtFailedGoodStock").val().replace(/,/g, ''));
            if (failQty != 0) {
                if (FailRaisedQty != 0 || FailStockQty != 0 || FailGoodQty != 0) {
                    TotalFailQty = FailRaisedQty + FailStockQty + FailGoodQty;

                    if (TotalFailQty != failQty) {
                        alert('(Raised Debit + Fail Stock + Usable Stock) should equal to fail Quantity');
                        return false;
                    }
                }
            }

            var TotalExtraQty = 0;
            var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseFloat($("#lblInspectExtraQty").text().replace(/,/g, ''));
            var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseFloat($("#txtInspectRaisedDebit").val().replace(/,/g, ''));
            var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseFloat($("#txtInspectUsableStock").val().replace(/,/g, ''));
            if (ExtraQty != 0) {
                if (ExtraRaisedQty != 0 || ExtraUsableQty != 0) {
                    TotalExtraQty = ExtraRaisedQty + ExtraUsableQty;

                    if (TotalExtraQty != ExtraQty) {
                        alert('(Raised Debit + Usable Stock) should equal to Extra Quantity');
                        return false;
                    }
                }
            }
        }

        function Callfile(elem) {

            if (elem == 'internal') {
                $("#hdnInternalIsFile").val("1");
                $("#uploadInternalLabReport").trigger('click');

                if ($('#chkExternalReceivedInLab').is(':checked')) {
                    if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1") {
                        $("#chkLabManager").attr("disabled", false);



                        if ($("#txtInternalLabSpecimanCount").val() != "" && $("#chkInternalSentToLab").is(':checked')) {
                            $("#chkLabManager").attr("disabled", true);
                        }
                        else {
                            $("#chkLabManager").attr("disabled", true);
                        }
                    }
                }
                else {
                    if ($("#txtExternalLabSpecimanCount").val() != "" && $("#chkExternalSentToLab").is(':checked')) {
                        $("#chkLabManager").attr("disabled", true);
                    }
                    else {
                        $("#chkLabManager").attr("disabled", false);
                    }
                }
            }
            if (elem == 'external') {
                $("#hdnExternalIsFile").val("1");
                $("#uploadExternalLabReport").trigger('click');

                if ($('#chkInternalReceivedInLab').is(':checked')) {
                    if ($("#chkExternalReceivedInLab").is(':checked') && $("#hdnExternalIsFile").val() == "1") {
                        $("#chkLabManager").attr("disabled", false);
                    }
                    else {
                        if ($("#txtExternalLabSpecimanCount").val() != "" && $("#chkExternalSentToLab").is(':checked')) {
                            $("#chkLabManager").attr("disabled", true);
                        }
                        else {
                            $("#chkLabManager").attr("disabled", true);
                        }
                    }
                }
                else {
                    if ($("#txtInternalLabSpecimanCount").val() != "" && $("#chkInternalSentToLab").is(':checked')) {
                        $("#chkLabManager").attr("disabled", true);
                    }
                    else {
                        $("#chkLabManager").attr("disabled", false);
                    }
                }
            }
        }


        function ActualLengthColor(elem, type) {

            //CalculateTotalClaimedLength(elem,type);

            var rowid = elem.id.split("_")[3];

            var claimedQty = 0, actuallength = 0;
            if (type == 'empty') {
                claimedQty = $("#grv_Accessories_Inspection_" + rowid + "_txtClaimedLength_Empty").val().replace(/,/g,'');
                actuallength = $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").val().replace(/,/g, '');

                if (parseInt(actuallength) < parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallength) > parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Empty").attr('style', 'background-color:#fff;color:#000');
                }
            }

            if (type == 'edit') {
                claimedQty = $("#grv_Accessories_Inspection_" + rowid + "_txtClaimedLength_Edit").val().replace(/,/g, '');
                actuallength = $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").val().replace(/,/g, '');

                if (parseInt(actuallength) < parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallength) > parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#fff;color:#000');
                }
            }

            if (type == 'footer') {
                claimedQty = $("#grv_Accessories_Inspection_" + rowid + "_txtClaimedLength_Footer").val().replace(/,/g, '');
                actuallength = $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").val().replace(/,/g, '');

                if (parseInt(actuallength) < parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallength) > parseInt(claimedQty)) {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#fff;color:#000');
                }
            }

            CalculateTotaLClaimedLength(elem, type, claimedQty);
        }
        //added by raghvinder on 07-01-2021 end  


        //added by raghvinder on 11-06-20021 start
        function CalculateTotaLClaimedLength(ele, type, claimedQtyValue) {

            var rowid = ele.id.split("_")[3];
            var rowidLength = rowid.length;
            var ControlID = rowid.substring(3, rowidLength);
            //            var ControlType = ele.id.split("_")[4].substring(0, 3);
            //            var Type = ele.id.split("_")[5];
            var length = $("#grv_Accessories_Inspection tr").length;
            var TotalClaimedQty = 0, Claimed = 0;


            for (var i = 1; i <= length; i++) {
                if (i < 10) {
                    if (ControlID.toString() != "0" + i.toString()) {
                        Claimed = $("#grv_Accessories_Inspection_ctl0" + i.toString() + "_lblClaimedLength").text() == "" ? 0 : ($("#grv_Accessories_Inspection_ctl0" + i.toString() + "_lblClaimedLength").text().replace(/,/g, ''));
                        TotalClaimedQty = parseFloat(Claimed) + parseFloat(TotalClaimedQty);
                    }
                }
                else {
                    if (ControlID.toString() != i.toString()) {
                        Claimed = $("#grv_Accessories_Inspection_ctl" + i.toString() + "_lblClaimedLength").text() == "" ? 0 : ($("#grv_Accessories_Inspection_ctl" + i.toString() + "_lblClaimedLength").text().replace(/,/g, ''));
                        TotalClaimedQty = parseFloat(Claimed) + parseFloat(TotalClaimedQty);
                    }
                }
            }

            TotalClaimedQty = parseFloat(claimedQtyValue) + parseFloat(TotalClaimedQty.toFixed(2));
            debugger;
            var totalquantity=$("#txtTotalQuantity").val().replaceAll(',', '');
            if (TotalClaimedQty > totalquantity) {
                alert("Claimed Quantity can not greater than Total Quantity.");
                var ID = ele.id;
                $("#" + ID.toString()).val('');
                return false;
            }
        }



        function CheckCheckedQuantity(elem, type) {
            var Idsn = elem.id.split("_")[3];
            var checkedqnt = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val().replace(/,/g, '');

            var actlength = $("#grv_Accessories_Inspection_" + Idsn + "_txtActLength" + type).val().replace(/,/g, '');

            if (parseFloat(checkedqnt) > parseFloat(actlength)) {
                alert("Checked Quantity can't greater than Act length!");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val("");
            }
            if (checkedqnt == "") {
                alert("Check Quantity shouldn't blank.");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val('');
                $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val('');
                $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val('');
            }
        }


        //added bu abhishek prevent doing less qty
        function CheckPass() {

            var pass = $("#txtPass").val().replace(/,/g, '');
            var StorepassQty = $("#hdnpassqty").val().replace(/,/g, '');
            if (StorepassQty == "") {
                StorepassQty = 0;
            }
            if (pass == "") {
                pass = 0;
            }
            if (parseInt(StorepassQty) > 0) {
                if (parseInt(pass) < parseInt(StorepassQty)) {
                    alert("Pass Qty can't be less then " + StorepassQty);
                    $("#txtPass").val(StorepassQty);
                }
            }
        }
        function CheckDecision(elem, type) {
            var Idsn = elem.id.split("_")[3];
            var checkQuantity = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val().replace(/,/g, '');
            if (checkQuantity == "") {
                alert("Check Quantity shouldn't blank.");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val('');
                $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val('');
                $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val('');
            }
            var pass = $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val().replace(/,/g, '');

            if (pass == "") {
                pass = 0;
            }
            var fail = $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val().replace(/,/g, '');
            var hold = $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val().replace(/,/g, '');
            var checked = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val().replace(/,/g, '');


            if (pass != "" && fail != "" && hold != "") {
                if ((parseFloat(pass) + parseFloat(fail) + parseFloat(hold)) > parseFloat(checked)) {
                    alert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);

                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }
            else if (pass != "" && fail == "" && hold == "") {
                if ((parseFloat(pass) + 0) > parseFloat(checked)) {
                    alert("Pass + Fail Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    //  $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail_" + type).removeAttr("checked");


                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass == "" && fail == "" && hold != "") {
                if ((parseFloat(hold) + 0) > parseFloat(checked)) {
                    alert("Pass + Fail + Hold Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass == "" && fail != "" && hold == "") {
                if ((parseFloat(fail) + 0) > parseFloat(checked)) {
                    alert("Pass + Fail + Hold Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass != "" && fail != "" && hold == "") {
                if ((parseFloat(pass)) + (parseFloat(fail)) > parseFloat(checked)) {
                    alert("Pass + Fail + Hold Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass != "" && fail == "" && hold != "") {
                if ((parseFloat(pass)) + (parseFloat(hold)) > parseFloat(checked)) {
                    alert("Pass + Fail + Hold Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass == "" && fail != "" && hold != "") {
                if ((parseFloat(fail)) + (parseFloat(hold)) > parseFloat(checked)) {
                    alert("Pass + Fail + Hold Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtHold" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

            else if (pass == "" && fail == "") {
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
            }

            else {
                if ((0 + parseFloat(fail)) > parseFloat(checked)) {
                    alert("Pass + Fail Quantity can't greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                }
                if (((parseFloat(fail) * 100) / parseFloat(checked)) > 10) {
                    // $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass_" + type).removeAttr("checked");


                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).prop('checked', true);
                }
                else {
                    // $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail_" + type).removeAttr("checked");


                    //                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
                    $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).prop('checked', true);
                }
            }

        }
        $("#rdyBtnLabDecPassInter").change(function () {










        });
        function ValidateCheckerName() {

            if ($('#txtCheckerName1').val() == "") {

                $('#txtCheckerName1').css('border-color', 'red');
            }
            else {
                $('#txtCheckerName1').css('border-color', 'black');
            }
        }
        function ValidateUnit() {
            if ($('#ddlAllocatedUnit :selected').text() == "Select") {
                alert("Select Allocated Unit!");
            }
        }
        function ValidateReceived() {
            if ($('#txtReceived').val() == "") {
                alert("Received can't blank!");
            }
            var hdnRecievedVal = $('#hdnReceivedQty').val();
            if (parseFloat($('#txtReceived').val().replace(/,/g, '')) > parseFloat($('#txtTotalQuantity').val().replace(/,/g, ''))) {
                alert("Received Quantity can't greater than total Quantity, You need to revise SRV Quantity!");
                if (parseFloat(hdnRecievedVal) > 0) {
                    $("#txtReceived").val(hdnRecievedVal);
                }
                else {
                    $("#txtReceived").val('');
                }
            }
        }
        function ValidateChecked() {
            if ($('#txtChecked').val() == "") {
                alert("Checked can't blank!");
            }
            if (parseFloat($('#txtChecked').val().replace(/,/g, '')) > parseFloat($('#txtReceived').val().replace(/,/g, ''))) {
                alert("Checked quantities can't greater than received quantity!");
                $("#txtChecked").val("");
            }
        }
        function ValidatePassHoldFail() {

            //added by Girish on 2023-03-22
            if ($("[id$='lkUpdate']").length) {
                alert("Cannot be Save in Edit Mode.");
                $('#chkAccessoriesQA').removeAttr('checked');
                return false;
            }
            //added by Girish on 2023-03-22

            //            if ($("#rbtFinalDecisionPass").is(':checked')) {
            //                // $("#hdnDecissionPass").val(1);
            //            }
            //            if ($("#rdybtnComeercialPass").is(':checked')) {
            //                //  $("#hdnDecissionCommercialpass").val(1);
            //                //                        alert(x);
            //            }
            //            if ($("#rbtFinalDecisionFail").is(':checked')) {
            //                //  $("#hdnDecissionFail").val(1);
            //            }
            var pass = $('#lblTotalPass').text() == "" ? 0 : parseFloat($('#lblTotalPass').text().replace(/,/g, ''));
            var fail = $('#lblTotalFailed').text() == "" ? 0 : parseFloat($('#lblTotalFailed').text().replace(/,/g, ''));
            var hold = $('#lblTotalHold').text() == "" ? 0 : parseFloat($('#lblTotalHold').text().replace(/,/g, ''));
            var checked = $('#lblTotalChecked').text() == "" ? 0 : parseFloat($('#lblTotalChecked').text().replace(/,/g, ''));


            if ((pass + fail + hold) != checked) {
                alert("(Pass + Fail + Hold) Quantity should be equal to Checked Quantity!");

                var holdval = $("#lblTotalHold").val();
                if (holdval != "") {
                    $('#chkAccessoriesQA').attr("disabled", true);
                    if ($("#hdnLoginId").val() == "15") {
                        $('#chkAccessoriesGM').attr("disabled", true);
                    }
                    else {
                        $('#chkAccessoriesGM').attr("disabled", false);
                    }
                }
                else {
                    // $('#chkAccessoriesQA').attr("disabled", false);
                    if ($("#hdnLoginId").val() == "15") {
                        $('#chkAccessoriesGM').attr("disabled", false);
                    }
                    else {
                        $('#chkAccessoriesGM').attr("disabled", true);
                    }
                    $("#chkAccessoriesGM").attr('checked', false);
                }
                return false;
            }
            var result = FailExtraValidation();
            if (result == false) {
                return false;
            }

            var SpeciInternalSentoLabValid = specimanInternalCountValidation();
            if (SpeciInternalSentoLabValid == false) {
                return false;
            }

            var SpeciExternalSentoLabValid = specimanExternalCountValidation();
            if (SpeciExternalSentoLabValid == false) {
                return false;
            }

            var ParticularValidation = FailExtraQtyValidationSubmit();
            if (ParticularValidation == false) {
                return false;
            }

            var EditModeValid = EditModeValidation();
            if (EditModeValid == false) {
                return false;
            }

        }

        function closePage() {
            self.parent.parent.PageReload();
            self.parent.Shadowbox.close();
        }

        function disablePage() {
            for (var i = 0; i < document.forms[0].elements.length; i++) {
                document.forms[0].elements[i].disabled = true;
            }
        }
        function ShowDiv(StockQty) {

            $('#lblRaiseMsg').text("Are you sure to raise debit for " + StockQty + " Qty.");
            $("#modalshow").show();
        }
        function Raise_DebitNote(flag) {

            var SupplierPoId = $('#hdnSupplierPoId').val();
            var InspectionId = $('#hdnInspectionId').val();
            var StockQty = $('#hdnStockQty').val();


            proxy.invoke("Stock_Qty_Update_ToRaise_DebitNote", { SupplierPO_Id: SupplierPoId, InspectionID: InspectionId, flag: flag, StockQty: StockQty },
                    function (result) {
                        closePage();
                    });
        }
        function CheckHoldQty() {
            var holdval = $("#txtHold").val();
            if (holdval != "") {
                $('#chkAccessoriesQA').attr("disabled", true);
                if ($("#hdnLoginId").val() == "15") {
                    $('#chkAccessoriesGM').attr("disabled", true);
                }
                else {
                    $('#chkAccessoriesGM').attr("disabled", false);
                }
                $("#chkAccessoriesGM").attr('checked', false);
                $("#chkAccessoriesQA").attr('checked', false);
            }
            else {
                // $('#chkAccessoriesQA').attr("disabled", false);
                if ($("#hdnLoginId").val() == "15") {
                    $('#chkAccessoriesGM').attr("disabled", false);
                }
                else {
                    $('#chkAccessoriesGM').attr("disabled", true);
                }
            }
        }



        function pageLoad() {
            //new code for display none fileupload start
            if ($("#chkInternalReceivedInLab").is(":checked")) {
                $('#hylnkInternalLabReportText').css('display', '');
                $('#hylnkInternalLabReportText').css('visibility', 'visible');

            }
            else {
                $('#hylnkInternalLabReportText').css('visibility', 'hidden');
                $('#uploadInternalLabReport').val('');
            }

            if ($("#chkExternalReceivedInLab").is(":checked")) {
                $('#hylnkExternalLabReportText').css('display', '');
                $('#hylnkExternalLabReportText').css('visibility', 'visible');
            }
            else {
                $('#hylnkExternalLabReportText').css('visibility', 'hidden');
                $('#uploadExternalLabReport').val('');
            }
            //new code for display none fileupload end
            $("#chkInternalReceivedInLab").click(function () {
                if ($('#chkInternalReceivedInLab').is(':checked')) {
                    //$('#hylnkInternalLabReportText').attr("style", "display:block");
                    $('#hylnkInternalLabReportText').css('display', '');
                    $('#hylnkInternalLabReportText').css('visibility', 'visible');



                    //                    if ($("#chkExternalReceivedInLab").is(':checked') && $("#hdnExternalIsFile").val() == "1") {
                    //                        $("#chkLabManager").attr("disabled", false);
                    //                    }
                    //                    else {
                    //                        if ($("#txtExternalLabSpecimanCount").val() != "" && $("#chkExternalSentToLab").is(':checked')) {
                    //                            $("#chkLabManager").attr("disabled", true);
                    //                        }
                    //                        else {
                    //                            $("#chkLabManager").attr("disabled", true);
                    //                        }
                    //                    }
                }
                else {
                    //                    if ($('#chkLabManager').is(':checked')) {
                    //$('#hylnkInternalLabReportText').attr("style", "display:none");
                    $('#hylnkInternalLabReportText').css('visibility', 'hidden');
                    $('#uploadInternalLabReport').val('');
                    //                    }
                    $("#chkLabManager").prop("checked", false);
                    $("#chkLabManager").attr("disabled", true);
                }
            });

            $("#chkExternalReceivedInLab").click(function () {
                if ($('#chkExternalReceivedInLab').is(':checked')) {
                    //$('#hylnkExternalLabReportText').attr("style", "display:block");
                    $('#hylnkExternalLabReportText').css('display', '');
                    $('#hylnkExternalLabReportText').css('visibility', 'visible');


                    //                    if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1") {
                    //                        $("#chkLabManager").attr("disabled", false);
                    //                    }
                    //                    else {

                    //                        if ($("#txtInternalLabSpecimanCount").val() != "" && $("#chkInternalSentToLab").is(':checked')) {
                    //                            $("#chkLabManager").attr("disabled", true);
                    //                        }
                    //                        else {
                    //                            $("#chkLabManager").attr("disabled", true);
                    //                        } 
                    //                    }
                }
                else {
                    //                    if ($('#chkLabManager').is(':checked')) {
                    //$('#hylnkExternalLabReportText').attr("style", "display:none");
                    $('#hylnkExternalLabReportText').css('visibility', 'hidden');
                    $('#uploadExternalLabReport').val('');
                    //                    }
                    $("#chkLabManager").prop("checked", false);
                    $("#chkLabManager").attr("disabled", true);

                }
            });



            // $(document).ready(function () {


            $('#chkLabManager').click(function () {
                var internalCount = $('#txtInternalLabSpecimanCount').val();
                var internalsentToLabChecked = $('#chkInternalSentToLab').is(':checked');
                var externalCount = $('#txtExternalLabSpecimanCount').val();
                var externalsentToLabChecked = $('#chkExternalSentToLab').is(':checked');

                if (internalCount != "" && internalsentToLabChecked == true && externalCount != "" && externalsentToLabChecked == true) {
                    $(this).attr("disabled", false);
                }
                //  if ($('#chkInternalSentToLab').is(':checked')) {
            });


            $('#chkAccessoriesQA').click(function () {
                //if ($("#lblTotalHoldQty").text() != "" || $("#lblTotalHoldQty").text() != "0") {
                if ($("#lblTotalHold").text() != "" && $("#lblTotalHold").text() != "0") {
                    alert("Make sure you don't have hold quantity.");
                    $(this).prop("checked", false);
                }
            });


            function FreezeFailExtraQuantityOnGMSignatureCheckedValidation() {
                //new code for freeze all textboxes when Signature checked by GM start

                if ($('#chkAccessoriesGM').is(':checked') == true) {
                    $("#txtFailedRaisedDebit").attr("readonly", "readonly");
                    $("#txtFailedStock").attr("readonly", "readonly");
                    $("#txtFailedGoodStock").attr("readonly", "readonly");
                    $("#txtFailedParticular").attr("readonly", "readonly");

                    $("#txtInspectRaisedDebit").attr("readonly", "readonly");
                    $("#txtInspectUsableStock").attr("readonly", "readonly");
                    $("#txtInspectParticular").attr("readonly", "readonly");
                }
                else {
                    $("#txtFailedRaisedDebit").attr("readonly", false);
                    $("#txtFailedStock").attr("readonly", false);
                    $("#txtFailedGoodStock").attr("readonly", false);
                    $("#txtFailedParticular").attr("readonly", false);

                    $("#txtInspectRaisedDebit").attr("readonly", false);
                    $("#txtInspectUsableStock").attr("readonly", false);
                    $("#txtInspectParticular").attr("readonly", false);

                    $("#txtFailedRaisedDebit").attr("disabled", false);
                    $("#txtFailedStock").attr("disabled", false);
                    $("#txtFailedGoodStock").attr("disabled", false);
                    $("#txtFailedParticular").attr("disabled", false);

                    $("#txtInspectRaisedDebit").attr("disabled", false);
                    $("#txtInspectUsableStock").attr("disabled", false);
                    $("#txtInspectParticular").attr("disabled", false);
                }
                //new code for freeze all textboxes when Signature checked by GM end
            }

            $('#chkAccessoriesGM').click(function () {

                FreezeFailExtraQuantityOnGMSignatureCheckedValidation();

                var TotalFailQty = 0;
                var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseFloat($("#lblTotalFailQty").text().replace(/,/g, ''));
                var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseFloat($("#txtFailedRaisedDebit").val().replace(/,/g, ''));
                var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseFloat($("#txtFailedStock").val().replace(/,/g, ''));
                var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseFloat($("#txtFailedGoodStock").val().replace(/,/g, ''));
                if (failQty != 0) {
                    TotalFailQty = FailRaisedQty + FailStockQty + FailGoodQty;

                    if (FailGoodQty > 0) {
                        alert('Must resolve the usable stock quantity segregation.');
                        $(this).prop("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        return;
                    }

                    if (TotalFailQty == 0) {
                        alert('Must resolve the fail quantity segregation.');
                        $(this).prop("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        return;
                    }

                    else if (TotalFailQty != failQty) {
                        alert('Must resolve the fail quantity segregation.');
                        $(this).prop("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        return;
                    }

                    if (FailRaisedQty > 0) {
                        if ($("#txtFailedParticular").val() == "") {
                            alert("Particular can't blank.");
                            $(this).prop("checked", false);
                            FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                            return;
                        }
                    }

                }

                var TotalExtraQty = 0;
                var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseFloat($("#lblInspectExtraQty").text().replace(/,/g, ''));
                var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseFloat($("#txtInspectRaisedDebit").val().replace(/,/g, ''));
                var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseFloat($("#txtInspectUsableStock").val().replace(/,/g, ''));
                if (ExtraQty != 0) {
                    TotalExtraQty = ExtraRaisedQty + ExtraUsableQty;

                    //                    if (ExtraUsableQty > 0) {
                    //                        alert('Must resolve the usable stock quantity segregation.');
                    //                        $(this).prop("checked", false);
                    //                        return;
                    //                    }                    

                    if (TotalExtraQty == 0) {
                        alert('Must resolve the extra quantity segregation.');
                        $(this).prop("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        return;
                    }
                    else if (TotalExtraQty != ExtraQty) {
                        alert('Must resolve the extra quantity segregation.');
                        $(this).prop("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        return;
                    }
                    if (ExtraRaisedQty > 0) {
                        if ($("#txtInspectParticular").val() == "") {
                            alert("Particular can't blank.");
                            $(this).prop("checked", false);
                            FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                            return;
                        }
                    }
                }
            });


            if ($("#lblTotalFailQty").text() == "") {
                $("#txtFailedRaisedDebit").attr("disabled", true);
                $("#txtFailedStock").attr("disabled", true);
                $("#txtFailedGoodStock").attr("disabled", true);
                $("#txtFailedParticular").attr("disabled", true);
            }
            else {
                if ($("#txtFailedRaisedDebit").val() != "") {
                    if ($('#chkAccessoriesGM').is(':checked') == false) {
                        $("#txtFailedParticular").attr("disabled", false);
                        $("#txtFailedParticular").attr("placeholder", "Debit Particular");
                    }
                    else {
                        $("#txtFailedParticular").attr("disabled", true);
                    }
                }
                else {
                    $("#txtFailedParticular").attr("disabled", true);
                }
            }

            if ($("#lblInspectExtraQty").text() == "") {
                $("#txtInspectRaisedDebit").attr("disabled", true);
                $("#txtInspectUsableStock").attr("disabled", true);
                $("#txtInspectParticular").attr("disabled", true);
            }
            else {
                if ($("#txtInspectRaisedDebit").val() != "") {
                    if ($('#chkAccessoriesGM').is(':checked') == false) {
                        $("#txtInspectParticular").attr("placeholder", "Debit Particular");
                        $("#txtInspectParticular").attr("disabled", false);
                    }
                    else {
                        $("#txtInspectParticular").attr("disabled", true);
                    }
                }
                else {
                    $("#txtInspectParticular").attr("disabled", true);
                }
            }

            //            if ($("#txtFailedRaisedDebit").val() != "" || $("#txtFailedStock").val() != "" || $("#txtFailedGoodStock").val() != "") {
            //                $("#txtFailedParticular").attr("disabled", true);
            //            }

            //            if ($("#txtInspectRaisedDebit").val() != "" || $("#txtInspectUsableStock").val() != "") {
            //                $("#txtInspectParticular").attr("disabled", true);
            //            }


            var LabId = $('#hdnLabId').val();
            var LabManager = $('#hdnLabManager').val() == "" ? -1 : parseInt($('#hdnLabManager').val());
            if ($("#hdnLoginId").val() == "40") {

                if (parseInt(LabId) == 0 && LabManager == 0) {
                    if ($('#chkInternalSentToLab').is(':checked')) {
                        if ($('#chkInternalReceivedInLab').is(':checked') && $("#hdnInternalIsFile").val() == "1" && $("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                            $("#chkLabManager").attr("disabled", false);
                            if ($("#chkExternalReceivedInLab").is(':checked') && $("#hdnExternalIsFile").val() == "1" && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
                                $("#chkLabManager").attr("disabled", false);
                            }
                            else {
                                if ($("#txtExternalLabSpecimanCount").val() != "" && $("#chkExternalSentToLab").is(':checked') && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked') && $("#hdnExternalIsFile").val() == "1") {
                                    $("#chkLabManager").attr("disabled", true);
                                }
                                else {
                                    $("#chkLabManager").attr("disabled", false);
                                }

                                //                                else if($("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                                //                                    $("#chkLabManager").attr("disabled", false);
                                //                                }

                            }
                        }
                        else {

                            $("#chkLabManager").attr("disabled", true);
                        }
                    }
                    else {
                        $("#chkInternalReceivedInLab").attr("disabled", true);
                        $("#chkLabManager").attr("disabled", true);
                    }
                }
            }

            if ($("#hdnLoginId").val() == "40") {
                $("chkAccessoriesQA").attr("disabled", true);
                if (parseInt(LabId) == 1 && LabManager == 0) {
                    if ($('#chkExternalSentToLab').is(':checked')) {
                        if ($('#chkExternalReceivedInLab').is(':checked') && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
                            if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1") {
                                if (!$("#chkLabManager").is(':checked')) {
                                    $("#chkLabManager").attr("disabled", false);
                                }
                                else {

                                    $("#chkLabManager").attr("disabled", true);
                                    $("#btnSubmit").attr("disabled", true);
                                }
                            }
                            else {

                                if ($("#txtInternalLabSpecimanCount").val() != "" && $("#chkInternalSentToLab").is(':checked')) {
                                    $("#chkLabManager").attr("disabled", true);
                                }
                                else {
                                    $("#chkLabManager").attr("disabled", false);
                                }
                            }
                        }
                        else {
                            $("#chkLabManager").attr("disabled", true);
                        }
                    }
                    else {
                        $("#chkExternalReceivedInLab").attr("disabled", true);
                        $("#chkLabManager").attr("disabled", true);
                    }
                }
            }


            //            if ($('#chkExternalSentToLab').is(':checked')) {
            //                $("#chkExternalReceivedInLab").attr("disabled", false);
            //            }
            //            else {
            //                $("#chkExternalReceivedInLab").attr("disabled", true);
            //            }
            if ($("#hdnExternalIsFile").val() == "1" && (!$("#rdyBtnLabDecPassExt").is(':checked') && !$("#rdyBtnLabDecFailExt").is(':checked'))) {

                $("#rdyBtnLabDecPassExt").attr("disabled", false);
                $("#rdyBtnLabDecFailExt").attr("disabled", false);
                if (!$("#rdyBtnLabDecPassExt").is(':checked') && !$("#rdyBtnLabDecFailExt").is(':checked')) {

                    $("#btnSubmit").attr("disabled", false);
                    $("#chkLabManager").attr("checked", false);
                    $("#chkLabManager").attr("disabled", false);
                    $("#lblAccLabManagerName").hide();
                    $("#lblLabDatetime").hide();
                }

            }
            else {
                if ($("#hdnExternalIsFile").val() != "1" && (!$("#rdyBtnLabDecPassExt").is(':checked') && !$("#rdyBtnLabDecFailExt").is(':checked')) && $("#chkExternalSentToLab").is(':checked') && $("#hdnLabId").val() == "1") {

                    $("#rdyBtnLabDecPassExt").attr("disabled", true);
                    $("#rdyBtnLabDecFailExt").attr("disabled", true);
                    $("#btnSubmit").attr("disabled", false);
                    if ($("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {

                        $("#chkLabManager").attr("disabled", false);
                    }
                    else {
                        $("#chkLabManager").attr("disabled", true);
                    }
                    $("#chkLabManager").attr("checked", false);
                    $("#lblAccLabManagerName").hide();
                    $("#lblLabDatetime").hide();


                }


            }
            if ($("#hdnInternalIsFile").val() == "1" && (!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked'))) {

                $("#rdyBtnLabDecPassInter").attr("disabled", false);
                $("#rdyBtnLabDecFailInter").attr("disabled", false);
                if (!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked')) {

                    $("#btnSubmit").attr("disabled", false);
                    if ($("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                        $("#chkLabManager").attr("checked", false);
                        $("#chkLabManager").attr("disabled", false);
                    }
                    $("#lblAccLabManagerName").hide();
                    $("#lblLabDatetime").hide();
                }
            }
            else {
                if ($("#hdnInternalIsFile").val() != "1" && (!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked'))) {
                    $("#rdyBtnLabDecPassInter").attr("disabled", true);
                    $("#rdyBtnLabDecFailInter").attr("disabled", true);
                    $("#btnSubmit").attr("disabled", false);
                    //                    $("#chkLabManager").attr("checked", false);
                    //                    $("#chkLabManager").attr("disabled", false);
                    $("#lblAccLabManagerName").hide();
                    $("#lblLabDatetime").hide();
                }
            }

            if ($("#hdnLoginId").val() != "40") {
                $("#chkLabManager").attr("disabled", true);
            }

            if ($("#hdnLoginId").val() == "148") {
                if ($('#chkExternalSentToLab').is(':checked')) {
                    if ($('#chkExternalSentToLab').is(':checked') && $("#txtExternalLabSpecimanCount").val() != "" && $("#rbtFinalDecisionPass").is(':checked') || $("#rdybtnCommercialPass").is(':checked') || $("#rbtFinalDecisionFail").is(':checked')) {
                        if (!$("#chkAccessoriesQA").is(':checked')) {
                            $("#chkAccessoriesQA").attr("disabled", false);
                        }
                    }
                    else {
                        $("#chkAccessoriesQA").attr("disabled", true);
                    }
                }
                else {
                    $("#chkExternalReceivedInLab").attr("disabled", true);
                    $("#chkLabManager").attr("disabled", true);
                }
            }
        }

        //added by Girish: Start
        function AddActualReceivedQty(id) {
            $('#' + id).val($('#hdnActualReceivedQty').val());
            $('#lblTotalClaimedLength').html(parseFloat($('#hdnActualReceivedQty').val().replace(/,/g,'')).toFixed(3));
        }

        $(document).ready(function () {
            AddActualReceivedQty('grv_Accessories_Inspection_ctl01_txtClaimedLength_Empty');
        })
        //added by Girish:End

       
    </script>
</head>
<body>
    <script type="text/javascript" src="../../js/facebox.js"></script>
    <script src='<%= Page.ResolveUrl("~/js/CostRange/ProDuctShadowBox.js")%>' type="text/javascript"></script>
    <script type="text/javascript">
        function SBClose() { }
        function OpenTestReport(url) {
            //  alert("Check");
            var url = url + "&SrvNO=" + '<%= Request.QueryString["SrvID"] %>';
            var sURL = url;

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

    </script>
    <form id="form1" runat="server">
    <div class="debitnote-table" style="max-width: 1178px; margin: 0px auto;">
        <div class="TopHeader">
            <%--<span class="GreigeShrnk"><span>Greige Shrnk:</span> <span>2% </span></span>--%>
            <%--<span class="ReshShrnk"><span>Res. Shrnk/Wstg: </span><span>2% </span></span>--%>
            <span class="GreigeShrnk"><span id="ResidShrnk" runat="server">Res. Shrnk/Wstg:</span>
                <span>
                    <asp:Label ID="lblWastage" Font-Bold="true" runat="server"></asp:Label></span></span>
            <span class="ReshShrnk"><span id="GreigeShrnk" runat="server">Greige Shrnk:</span> <span>
                <asp:Label ID="lblShrinkage" Font-Bold="true" runat="server"></asp:Label></span></span>
            <span>Accessory Inspection System</span>
            <asp:Label ID="lblGreige" runat="server" Text="Greige" CssClass="GreigeStage"></asp:Label>
            <asp:Label ID="lblProcess" runat="server" Text="Process" CssClass="ProcessStage"></asp:Label>
            <asp:Label ID="lblFinish" runat="server" Text="Finish" CssClass="FinishStage"></asp:Label>
        </div>
        <div class="bottom_serialno">
            <span style="margin-right: 5px;">SerialNumber:</span><span><asp:Label ID="lblSerialNumber"
                runat="server" /></span>
        </div>
        <asp:HiddenField ID="hdnLabId" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnLabManager" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnGM_Manager" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnQAManager" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnLoginId" Value="0" runat="server" />
        <asp:HiddenField ID="hdnCommercialPass" Value="0" runat="server" />
        <asp:HiddenField ID="hdnFinalPass" Value="-1" runat="server" />
        <asp:HiddenField ID="HdnFinalFail" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnintLabDec" Value="-1" runat="server" />
        <asp:HiddenField ID="hdnExtLabDec" Value="-1" runat="server" />
        <table class="AddClass_Table">
            <tr>
                <th style="min-width: 86px;">
                    PO No.
                </th>
                <td style="border-top-color: #999; border-right-color: #999">
                    <%--<span class="ColorBlackBold">ITPA51</span>--%>
                    <asp:Label ID="lblPO_No" Font-Bold="true" runat="server"></asp:Label>
                </td>
                <th class="minWidthThSize">
                    Accessory Quality (Size)
                </th>
                <td class="minWidth" style="border-top-color: #999; border-right-color: #999">
                    <asp:Label ID="lblAccessories" CssClass="ColorBlue" runat="server"></asp:Label>
                    <%-- <span class="ColorBlue">Coffin Box</span> <span class="ColorGray">(ASO)</span>--%>
                </td>
                <th class="minWidthTh">
                    Supplier Name
                </th>
                <td class="minWidth" style="border-top-color: #999; border-right-color: #999">
                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                    <%--<span>boutique pvt. ltd.</span>--%>
                </td>
                <th class="minWidthTh">
                    Inspection Date
                </th>
                <td style="border-top-color: #999; border-right-color: #999">
                    <%--18 Dec 20--%>
                    <asp:TextBox ID="txtDate" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                </td>
                <th rowspan="2" class="minWidthTh">
                    Checker Name<span class="ColorRedStrick">*</span>
                </th>
                <td class="minWidth txtCenter" style="border-top-color: #999; border-right-color: #999">
                    <%--<input type="text" value="Rakesh" class="txtControl">--%>
                    <asp:TextBox ID="txtCheckerName1" CssClass="txtControl" autocomplete="off" onblur="ValidateCheckerName();"
                        runat="server"></asp:TextBox>
                </td>
                <th rowspan="2" class="minWidthTh">
                    OverAll PoQty.
                </th>
                <td rowspan="2" class="txtCenter" style="border-top-color: #999; border-right-color: #999;
                    padding-right: 0;">
                    <%--<input type="text" value="Rakesh" class="txtControl">--%>
                    <asp:Label ID="lblReceivedQtyPO" runat="server"></asp:Label>&nbsp; <span id="sp7"
                        runat="server"></span>
                </td>
            </tr>
            <tr>
                <th style="line-height: 15px;">
                    SRV No.<br />
                    Party Challan No
                </th>
                <td style="border-bottom-color: #999; border-right-color: #999;">
                    <%--<span>A-22</span>--%>
                    <div class="tooltip" style="line-height: 15px;">
                        <asp:Label ID="lblSrvNo" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblpartychallannumber" runat="server"></asp:Label>
                        <span class="tooltiptext">
                            <asp:Label ID="lblSrvRemarks" runat="server" Style="color: White;" /></span>
                    </div>
                </td>
                <th>
                    Color/Print
                </th>
                <td style="border-bottom-color: #999; border-right-color: #999">
                    <%--<span class="ColorBlackBold">Black</span>--%>
                    <asp:Label ID="lblPrintCol" Font-Bold="true" ForeColor="Black" CssClass="ColorBlackBold"
                        runat="server"></asp:Label>
                </td>
                <th>
                    <%-- Total Qty.<span style="color: gray; font-weight: 600;">(Meter)</span>--%>
                    Total Qty.
                </th>
                <td style="border-bottom-color: #999; border-right-color: #999">
                    <%--<span>50</span>--%>
                    <asp:TextBox ID="txtTotalQuantity" autocomplete="off" Width="50%" runat="server"
                        Enabled="false"></asp:TextBox>
                    <asp:HiddenField runat="server" Value="" ID="hdnActualReceivedQty" />
                    <%--added by Girish To Show ClaimedQty By Default--%>
                    <span runat="server" style="color: gray; font-weight: 600;" id="Span6"></span>
                </td>
                <th>
                    Allocated Unit<span class="ColorRedStrick">*</span>
                </th>
                <td style="border-bottom-color: #999; border-right-color: #999">
                    <asp:DropDownList ID="ddlAllocatedUnit" onchange="ValidateUnit();" runat="server"
                        Height="16px" Width="98px">
                    </asp:DropDownList>
                </td>
                <td style="border-bottom-color: #999; border-right-color: #999" class="minWidth txtCenter">
                    <%--<input type="text" class="txtControl">--%>
                    <asp:TextBox ID="txtCheckerName2" autocomplete="off" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <%--new code 10 july 2020 start--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="updateAccessoryInspection" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="0">
            <ProgressTemplate>
                <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                    z-index: 52111; top: 40%; left: 45%; width: 6%;" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <%--new code 10 july 2020 end--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grv_Accessories_Inspection" runat="server" AutoGenerateColumns="false"
                    CssClass="AddClass_Table MarTop" Width="1178px" BorderWidth="0" OnRowDataBound="grv_Accessories_Inspection_RowDataBound"
                    ShowFooter="false" OnRowCommand="grv_Accessories_Inspection_RowCommand" OnRowDeleting="grv_Accessories_Inspection_RowDeleting"
                    OnRowEditing="grv_Accessories_Inspection_RowEditing" OnRowUpdating="grv_Accessories_Inspection_RowUpdating"
                    OnRowCancelingEdit="grv_Accessories_Inspection_RowCancelingEdit">
                    <EmptyDataRowStyle CssClass="EmptyRowTable" />
                    <Columns>
                        <asp:TemplateField HeaderText="Volume">
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Text='<%# Bind("BoxNo") %>'></asp:Label>
                                <asp:HiddenField ID="hdnId" Value='<%# Eval("InspectionParticular_Id") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                            <FooterStyle Width="50px" HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRollNo" Style="text-align: center" runat="server" autocomplete="off"
                                    Text='<%# Bind("BoxNo") %>' onkeypress="javascript:return isNumber1(this,event)"></asp:TextBox>
                                <asp:HiddenField ID="hdnParticularId" Value='<%# Eval("InspectionParticular_Id") %>'
                                    runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRollNo_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                    onkeypress="javascript:return isNumber1(this,event)"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dyed Lot">
                            <ItemTemplate>
                                <asp:Label ID="lblDeiLot" runat="server" Text='<%# Bind("DieLot") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDeiLot" autocomplete="off" runat="server" Text='<%# Bind("DieLot") %>'
                                    onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDeiLot_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                    onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                        <%--added on 07 Jan 2021 start--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblClaimedLengthHeader" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClaimedLength" runat="server" Text='<%# Bind("ActLength") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtClaimedLength_Edit" autocomplete="off" runat="server" Text='<%# Bind("ActLength") %>'
                                   onkeydown="if (event.keyCode == 9) return true; else return false;" onchange="ActualLengthColor(this,'edit')"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtClaimedLength_Footer" autocomplete="off" TextMode="SingleLine"
                                    runat="server" onkeypress="javascript:return isNumber(this,event)" onchange="ActualLengthColor(this,'footer')"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <%--added on 07 Jan 2021 end--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblLengthHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblActLength" runat="server" Text='<%# Bind("ActLength") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtActLength" autocomplete="off" runat="server" Text='<%# Bind("ActLength") %>'
                                    onchange="ActualLengthColor(this,'edit')" onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtActLength_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                    onchange="ActualLengthColor(this,'footer')" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Checked">
                            <HeaderTemplate>
                                <asp:Label ID="lblcheckedHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblChecked" runat="server" Text='<%# Bind("CheckedQty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtChecked" autocomplete="off" onblur="CheckCheckedQuantity(this,'');"
                                    runat="server" Text='<%# Bind("CheckedQty") %>' onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtChecked_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                    onkeypress="javascript:return isNumber(this,event)" onblur="CheckCheckedQuantity(this,'_Footer');"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pass">
                            <HeaderTemplate>
                                <asp:Label ID="lblPassHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPass" Style="color: Green; caret-color: black;" runat="server"
                                    Text='<%# Bind("PassQty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPass" Style="color: Green; caret-color: black;" autocomplete="off"
                                    onchange="CheckDecision(this,'');" runat="server" Text='<%# Bind("PassQty") %>'
                                    onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPass_Footer" Style="color: Green; caret-color: black;" autocomplete="off"
                                    TextMode="SingleLine" runat="server" onkeypress="javascript:return isNumber(this,event)"
                                    onchange="CheckDecision(this,'_Footer');"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hold">
                            <HeaderTemplate>
                                <asp:Label ID="lblHoldHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHold" runat="server" Text='<%# Bind("HoldQty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtHold" autocomplete="off" onchange="CheckDecision(this,'');" runat="server"
                                    Text='<%# Bind("FailQty") %>' onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtHold_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                    onkeypress="javascript:return isNumber(this,event)" onchange="CheckDecision(this,'_Footer');"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fail">
                            <HeaderTemplate>
                                <asp:Label ID="lblFailHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFail" Style="color: Red; caret-color: black;" runat="server" Text='<%# Bind("FailQty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFail" Style="color: Red; caret-color: black;" autocomplete="off"
                                    onchange="CheckDecision(this,'');" runat="server" Text='<%# Bind("FailQty") %>'
                                    onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtFail_Footer" Style="color: Red; caret-color: black;" autocomplete="off"
                                    TextMode="SingleLine" runat="server" onkeypress="javascript:return isNumber(this,event)"
                                    onchange="CheckDecision(this,'_Footer');"></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="74px" />
                            <FooterStyle Width="74px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Decision">
                            <ItemTemplate>
                                <asp:RadioButton ID="rbtPass" GroupName="decision" Text="Pass" runat="server" />
                                <asp:RadioButton ID="rbtFail" GroupName="decision" Text="Fail" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <EditItemTemplate>
                                <asp:RadioButton ID="rbtPass" GroupName="decision" Text="Pass" runat="server" />
                                <asp:RadioButton ID="rbtFail" GroupName="decision" Text="Fail" runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:RadioButton ID="rbtPass_Footer" GroupName="decision" Text="Pass" runat="server" />
                                <asp:RadioButton ID="rbtFail_Footer" GroupName="decision" Text="Fail" runat="server" />
                            </FooterTemplate>
                            <FooterStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkEdit" runat="server" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                </asp:LinkButton>
                                <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" Visible="false"
                                    OnClientClick="javascript:CalculateAccessoryInspection(this)" CommandName="Delete"><img src="../../images/del-butt.png" /> </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkUpdate" runat="server" OnClientClick="javascript:CalculateAccessoryInspection(this)"
                                    CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" />
                                </asp:LinkButton>
                                <asp:LinkButton ID="lkCancel" runat="server" OnClientClick="javascript:CalculateAccessoryInspection(this)"
                                    CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 2px;"/>
                                </asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="btnAdd_Footer" runat="server" ImageUrl="~/images/add-butt.png"
                                    OnClientClick="javascript:CalculateAccessoryInspection(this)" CommandName="AddFooter" />
                            </FooterTemplate>
                            <FooterStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="AddClass_Table EmptyTable" border="0" cellpadding="0" cellspacing="0"
                            style="border: 0px;">
                            <tr>
                                <th>
                                    Volume
                                </th>
                                <th>
                                    Dye Lot
                                </th>
                                <th>
                                    Claimed Quantity
                                </th>
                                <th>
                                    Actual Quantity
                                </th>
                                <th>
                                    Checked
                                </th>
                                <th>
                                    Pass
                                </th>
                                <th>
                                    Hold
                                </th>
                                <th>
                                    Fail
                                </th>
                                <th style="width: 100px">
                                    Decision
                                </th>
                                <th>
                                    Add
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRollNo_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        class="allownumericwithoutdecimal"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeiLot_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        class="allownumericwithoutdecimal"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClaimedLength_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        onkeydown="if (event.keyCode == 9) return true; else return false;" onclick="AddActualReceivedQty(this.id);" onchange="ActualLengthColor(this,'empty')"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActLength_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        onkeypress="javascript:return isNumber(this,event)" onchange="ActualLengthColor(this,'empty')"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChecked_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        onkeypress="javascript:return isNumber(this,event)" onblur="CheckCheckedQuantity(this,'_Empty');"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPass_Empty" autocomplete="off" runat="server" Style="text-align: center;
                                        color: Green;" onkeypress="javascript:return isNumber(this,event)" onchange="CheckDecision(this,'_Empty');"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHold_Empty" autocomplete="off" runat="server" Style="text-align: center"
                                        onkeypress="javascript:return isNumber(this,event)" onchange="CheckDecision(this,'_Empty');"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFail_Empty" autocomplete="off" runat="server" Style="text-align: center;
                                        color: Red;" onkeypress="javascript:return isNumber(this,event)" onchange="CheckDecision(this,'_Empty');"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtPass_Empty" GroupName="decision" Text="Pass" runat="server" />
                                    <asp:RadioButton ID="rbtFail_Empty" GroupName="decision" Text="Fail" runat="server" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnAdd_Empty" runat="server" ImageUrl="~/images/add-butt.png"
                                        OnClientClick="javascript:CalculateAccessoryInspection(this)" CommandName="AddEmpty" />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <table id="totalAccInspection" runat="server" class="TotalTable" visible="false">
                    <tr>
                        <td style='border-left-color: #999;'>
                            <asp:Label ID="lblTotalRollNo" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalDyedNo" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalClaimedLength" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalActualLength" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalChecked" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalPass" Style="text-align: center; color: green;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td id="tdTotalHold" runat="server">
                            <asp:Label ID="lblTotalHold" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalFailed" Style="text-align: center; color: red;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style="min-width: 98px;">
                        </td>
                        <td style='border-right-color: #999'>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; margin-top: 5px;">
                    <div style="width: 61%; float: left">
                        <span style="font-size: 13px;">Comments</span>
                        <asp:TextBox ID="txtComments" autocomplete="off" runat="server" Height="20px" TextMode="MultiLine"
                            Width="97%"></asp:TextBox>
                        <div id="dvHistory" runat="server">
                        </div>
                        <div class="LavContainer ">
                            <table>
                                <tr>
                                    <th style='width: 40px; text-align: center; border-top-color: #999; border-left-color: #999;'>
                                        Report
                                    </th>
                                    <th style='width: 40px; text-align: center; border-top-color: #999;'>
                                        Lab Specimen Count
                                    </th>
                                    <th style="width: 125px; text-align: center; border-top-color: #999;">
                                        Sent To Lab (Date & Time)
                                    </th>
                                    <th style='width: 125px; text-align: center; border-top-color: #999;'>
                                        Received in Lab (Date & Time)
                                    </th>
                                    <th style='width: 50px; text-align: center; border-top-color: #999;'>
                                        Lab Report
                                    </th>
                                    <th style='width: 50px; text-align: center; border-top-color: #999;'>
                                        Lab Decision
                                    </th>
                                    <th style='width: 84px; text-align: center; border-top-color: #999; border-right-color: #999;'>
                                        Final Decision
                                    </th>
                                </tr>
                                <tr id="InternalRowId" runat="server">
                                    <td style="text-align: center; border-color: #999; background: #f2f2f2">
                                        <span>Internal</span>
                                    </td>
                                    <td class="BalckgroundColor" style="text-align: center;">
                                        <%--<input type="text" class="" value="5" style="width: 30px; height: 11px; text-align: center;">--%>
                                        <asp:TextBox ID="txtInternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                            autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event);"
                                            onchange="InternalSentoLabValid()"></asp:TextBox>
                                    </td>
                                    <td style='text-align: left;' class="BalckgroundColor">
                                        <%--<input type="checkbox" id="SentLab" name="AccessoriesGM" value="AccessoriesGM">
                                <span class="RightSidedate">(<span>18 Dec 20</span> <span>10 AM</span>)</span>--%>
                                        <asp:CheckBox ID="chkInternalSentToLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblInternalSentToLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnInternalSentToLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkInternalSentToLab" runat="server" Value="0" />
                                    </td>
                                    <td style='text-align: left;'>
                                        <%--<input type="checkbox" id="SentLab" name="AccessoriesGM" value="AccessoriesGM">
                                <span class="RightSidedate">(<span>18 Dec 20</span> <span>11 AM</span>)</span>--%>
                                        <asp:CheckBox ID="chkInternalReceivedInLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblInternalReceivedIndLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnInternalReceivedInLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkInternalReceivedInLab" runat="server" Value="0" />
                                    </td>
                                    <td>
                                        <%--<input type="file" name="fileToUpload" id="fileToUpload">--%>
                                        <asp:HiddenField ID="hdnInternalIsFile" runat="server" Value="0" />
                                        <asp:HyperLink ID="hylnkInternalLabReportText" onclick="OpenTestReport('AccessoryLabMultipleFileUpload.aspx?Type=1')"
                                            CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue" Target="_blank"
                                            Style="cursor: pointer; display: none">
                                            <img id="InternalImage" alt="#" src="../../images/uploadimg.png" style="width: 20px;
                                                height: 18px; position: relative; top: 0px;"><asp:Label ID="lblInternalFileName"
                                                    runat="server"></asp:Label>
                                        </asp:HyperLink>
                                        <asp:HyperLink ID="hylnkInternalLabReport" runat="server" onclick="OpenTestReport('AccessoryLabMultipleFileUpload.aspx?Type=1')"
                                            Target="_blank" Style="cursor: pointer; float: right"> <img src="../../images/view-icon.png" style="width: 16px;height: 16px; position: relative;top:2px;" /> </asp:HyperLink>
                                        <asp:FileUpload ID="uploadInternalLabReport" runat="server" Style="display: none;" />
                                    </td>
                                    <td class="" style="border-right-color: #999; border-bottom-color: #999;">
                                        <asp:RadioButton ID="rdyBtnLabDecPassInter" GroupName="decisionINt" Text="Pass" runat="server" />
                                        <asp:RadioButton ID="rdyBtnLabDecFailInter" GroupName="decisionINt" Text="Fail" runat="server" />
                                    </td>
                                    <td rowspan="2" class="Passfail" style="border-right-color: #999; border-bottom-color: #999;
                                        width: 110px;">
                                        <%--<input type="radio" id="male" name="gender" value="male">
                                <label for="male">
                                    Pass</label>
                                <input type="radio" id="female" name="gender" value="female">
                                <label for="female">
                                    Fail</label>--%>
                                        <asp:RadioButton ID="rbtFinalDecisionPass" GroupName="decision" Text="Pass" runat="server" /><br />
                                        <asp:RadioButton ID="rdybtnCommercialPass" GroupName="decision" Text="CommercialPass"
                                            runat="server" /><br />
                                        <asp:RadioButton ID="rbtFinalDecisionFail" GroupName="decision" Text="Fail" runat="server" />
                                        <asp:Label ID="lblFinalDecisionDate" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="ExternalRowId" runat="server">
                                    <td style="text-align: center; border-color: #999; background: #f2f2f2">
                                        <span>External</span>
                                    </td>
                                    <td style="text-align: center; border-bottom-color: #999;" class="BalckgroundColor">
                                        <%--<input type="text" value="2" class="" style="width: 30px; height: 11px; text-align: center;">--%>
                                        <asp:TextBox ID="txtExternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                            autocomplete="off" runat="server" onkeypress="javascript:return isNumber(this,event)"
                                            onchange="ExternalSentoLabValid()"></asp:TextBox>
                                    </td>
                                    <td style='text-align: left; border-bottom-color: #999;' class="BalckgroundColor">
                                        <%--<input type="checkbox" id="SentLab" name="AccessoriesGM" value="AccessoriesGM">
                                <span class="RightSidedate">(<span>18 Dec 20</span> <span>10 AM</span>)</span>--%>
                                        <asp:CheckBox ID="chkExternalSentToLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblExternalSentToLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnExternalSentToLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkExternalSentToLab" runat="server" Value="0" />
                                    </td>
                                    <td style='text-align: left; border-bottom-color: #999;'>
                                        <%--<input type="checkbox" id="SentLab" name="AccessoriesGM" value="AccessoriesGM">
                                <span class="RightSidedate">(<span>18 Dec 20</span> <span>11 AM</span>)</span>--%>
                                        <asp:CheckBox ID="chkExternalReceivedInLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblExternalReceivedInLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnExternalReceivedInLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkExternalReceivedInLab" runat="server" Value="0" />
                                    </td>
                                    <td style="border-right-color: #999; border-bottom-color: #999;">
                                        <%--<input type="file" name="fileToUpload" id="fileToUpload">--%>
                                        <asp:HiddenField ID="hdnExternalIsFile" runat="server" Value="0" />
                                        <asp:HyperLink ID="hylnkExternalLabReportText" onclick="OpenTestReport('AccessoryLabMultipleFileUpload.aspx?Type=2')"
                                            CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue" Target="_blank"
                                            Style="cursor: pointer; display: none">
                                            <img alt="#" src="../../images/uploadimg.png" style="width: 20px; height: 18px; position: relative;
                                                top: 0px;"><asp:Label ID="Label1" runat="server"></asp:Label>
                                        </asp:HyperLink>
                                        <asp:HyperLink ID="hylnkExternalLabReport" runat="server" onclick="OpenTestReport('AccessoryLabMultipleFileUpload.aspx?Type=2')"
                                            Target="_blank" Style="cursor: pointer; float: right"> <img src="../../images/view-icon.png"  style="width: 16px;height: 17px; position: relative;top:2px;" /> </asp:HyperLink>
                                        <asp:FileUpload ID="uploadExternalLabReport" runat="server" Style="display: none;" />
                                    </td>
                                    <td class="" style="border-right-color: #999; border-bottom-color: #999;">
                                        <asp:RadioButton ID="rdyBtnLabDecPassExt" GroupName="decisionExt" Text="Pass" runat="server" />
                                        <asp:RadioButton ID="rdyBtnLabDecFailExt" GroupName="decisionExt" Text="Fail" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="QACheckbox">
                            <span style="text-align: right;">
                                <%--<input type="checkbox" id="vehicle1" name="vehicle1" value="Bike">--%>
                                <asp:CheckBox ID="chkLabManager" Checked="false" runat="server" Enabled="false" />
                                <label>
                                    (Lab Manager)</label><br />
                                <div style="padding-left: 26px; text-align: left;">
                                    <%--<label id="lblAccLabManagerName" runat="server" style="display: none">
                                    Binod Kumar</label>--%>
                                    <asp:Label ID="lblAccLabManagerName" runat="server" Style="display: none;"></asp:Label>
                                    <%--<label id="lblLabDatetime" runat="server" style="display: none"></label>--%>
                                    <asp:Label ID="lblLabDatetime" runat="server" Style="display: none;"></asp:Label>
                                </div>
                            </span>
                        </div>
                        <div class="QACheckbox">
                            <div class="QACheckbox2">
                                <span style="text-align: right;">
                                    <%--<input type="checkbox" id="vehicle1" name="vehicle1" value="Bike">--%>
                                    <asp:CheckBox ID="chkAccessoriesQA" Checked="false" runat="server" />
                                    <label>
                                        (Accessories QA Manager)</label><br />
                                    <div style="padding-right: 11px;">
                                        <%--<label id="lblAccQAName" runat="server" style="display: none">
                                    Deepak Dureja</label>--%>
                                        <asp:Label ID="lblAccQAName" runat="server" Style="display: none;"></asp:Label>
                                    </div>
                                    <%--<label id="lblQADatetime" runat="server" style="display: none">--%>
                                    <div style="padding-right: 11px;">
                                        <asp:Label ID="lblQADatetime" runat="server" Style="display: none;"></asp:Label>
                                        </label>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="RightSide" style="width: 36.7%; float: left;">
                        <table>
                            <tr id="FailedQtyId" runat="server">
                                <td style="text-align: center; width: 100px;">
                                    <%--<span>Fail Qty.</span> <span style="color: red">20</span>--%>
                                    <span style="color: #6b6464">Fail Qty.</span>
                                    <asp:Label ID="lblTotalFailQty" runat="server"></asp:Label>
                                </td>
                                <td style='text-align: left;'>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                        <asp:TextBox ID="txtFailedRaisedDebit" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumber(this,event);" onblur="EnableDisableParticular(this, 'FailedQty');"></asp:TextBox></span>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Fail Stock</span>
                                        <asp:TextBox ID="txtFailedStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                                    </span><span class="DisplayBlock"><span class="DisInlineBlock">Usable Stock</span>
                                        <asp:TextBox ID="txtFailedGoodStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                                    </span>
                                    <%--<span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span><input type="text" class="txtRaise"></span> 
                            <span class="DisplayBlock"><span class="DisInlineBlock">Fail Stock</span><input type="text" class="txtRaise"></span> 
                            <span class="DisplayBlock"><span class="DisInlineBlock">Good Stock</span><input type="text" class="txtRaise"></span>--%>
                                </td>
                                <td style='text-align: left;'>
                                    <%--<input type="text" value="Particular" style="width: 170px; height: 30px; color: gray">--%>
                                    <asp:TextBox ID="txtFailedParticular" Rows="3" Columns="18" autocomplete="off" runat="server"
                                        Enabled="false" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="ExtraQtyId" runat="server">
                                <td style="text-align: center; width: 130px;">
                                    <%--<span>Extra Qty.</span> <span style="color: #000">14</span>--%>
                                    <span style="color: #6b6464">Extra Qty.</span>
                                    <asp:Label ID="lblInspectExtraQty" runat="server"></asp:Label>
                                    <br />
                                    <span runat="server" id="spn_ExcessQty">Actual Required Qty.</span>
                                    <asp:Label ID="lblExcessQty" runat="server"></asp:Label>
                                </td>
                                <td style='text-align: left;'>
                                    <%--<span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                <input type="text" class="txtRaise"></span> <span class="DisplayBlock"><span class="DisInlineBlock">
                                    Usable Stock</span>
                                    <input type="text" class="txtRaise"></span>--%>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                        <asp:TextBox ID="txtInspectRaisedDebit" CssClass="txtRaise" autocomplete="off" runat="server"
                                            onblur="EnableDisableParticular(this, 'ExtraQty');" onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                                    </span><span class="DisplayBlock"><span class="DisInlineBlock">Usable Stock</span>
                                        <asp:TextBox ID="txtInspectUsableStock" CssClass="txtRaise" autocomplete="off" runat="server"
                                            onkeypress="javascript:return isNumber(this,event)"></asp:TextBox>
                                    </span>
                                </td>
                                <td style='text-align: left;'>
                                    <%--<input type="text" value="Particular" style="width: 170px; height: 30px; color: gray">--%>
                                    <asp:TextBox ID="txtInspectParticular" autocomplete="off" Rows="3" Columns="18" runat="server"
                                        Enabled="false" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="GMCheckbox">
                            <span style="text-align: left;">
                                <%--<input type="checkbox" id="AccessoriesGM" name="AccessoriesGM" value="AccessoriesGM">--%>
                                <asp:CheckBox ID="chkAccessoriesGM" Checked="false" runat="server" />
                                <label for="AccessoriesGM">
                                    (Material GM)</label><br />
                                <div style="padding-left: 25px">
                                    <%--<label id="lblAccGMName" runat="server" style="display: none;">
                                    Hemant Thakur</label>--%>
                                    <asp:Label ID="lblAccGMName" runat="server" Style="display: none;"></asp:Label>
                                    <%--<label id="lblGMDateTime" runat="server" style="display: none">
                                </label>--%>
                                    <asp:Label ID="lblGMDateTime" runat="server" Style="display: none;"></asp:Label>
                                </div>
                            </span>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="modalHide" id="modalshow" style="display: none;">
            <div class="txtContainer">
                <div class="TxtHeader">
                    <%--  <span onclick="CloseFun()">X</span>--%>
                </div>
                <div class="TxtContent">
                    <asp:Label ID="lblRaiseMsg" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hdnSupplierPoId" Value="-1" runat="server" />
                    <asp:HiddenField ID="hdnInspectionId" Value="-1" runat="server" />
                    <asp:HiddenField ID="hdnStockQty" Value="-1" runat="server" />
                </div>
                <div class="footerCotent">
                    <span class="btnYesColo" onclick="Raise_DebitNote(1)" id="btnYes">Yes</span> <span
                        class="btnNoColo" onclick="Raise_DebitNote(0)" id="btnNo">No</span>
                </div>
            </div>
        </div>
        <div style="text-align: center; padding-top: 40px; clear: both;">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btnSubmit printHideButton" Text="Submit"
                OnClick="btnSubmit_Click" OnClientClick="javascript:return ValidatePassHoldFail();" />
            <input type="button" id="CloseButton" class="btnSubmit printHideButton" value="Close"
                onclick="javascript:self.parent.Shadowbox.close();" runat="server" />
            <asp:Button ID="btnPrint" runat="server" CssClass="btnPrint btnBackColor printHideButton"
                Text="Print" OnClientClick="window.print()" />
        </div>
    </div>
    </form>
</body>
</html>
