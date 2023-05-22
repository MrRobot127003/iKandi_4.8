<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricInspectionFourPointCheck.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricInspectionFourPointCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Boutique International Pvt. Ltd.</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body
        {
            font-family: Arial;
            font-size: 10px;
        }
        .AddClass_Table
        {
            border-collapse: collapse;
            font-family: Arial;
            max-width: 975px;
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
        td.Header1
        {
            background: #dddfe4;
            border: 1px solid #999 !important;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 1px;
            color: #6b6464;
            font-family: Arial;
            text-align: center;
        }
        td.Header2
        {
            background: #dddfe4;
            border: 1px solid #999 !important;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 1px;
            color: #6b6464;
            font-family: Arial;
            text-align: center;
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
        .AddClass_Table.TopTable td
        {
            border-right-color: #999;
        }
        #grdfourpointcheck td
        {
            border-color: #dbd8d8;
            text-align: center;
            min-width: 40px;
            max-width: 40px;
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
            top: 0px;
        }
        .TopHeader
        {
            width: 100%;
            font-size: 12px;
            color: #fff;
            text-align: center;
            background: #39589C;
            margin-bottom: 2px;
            padding: 3px 0px;
            position: relative;
            display: flex;
        }
        
        .bottom_serialno
        {
            background-color: #39589C;
            color: #d8d8d8;
            padding: 6px;
            font-size: 12px;
        }
        .bottom_serialno span
        {
            color: #d8d8d8;
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
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 0px;
        }
        .GMCheckbox
        {
            text-align: right;
            padding-right: 10px;
            padding-top: 10px;
            padding-bottom: 0px;
            font-size: 12px;
        }
        .QACheckbox2
        {
            text-align: right;
        }
        
        .QACheckbox
        {
            text-align: left;
            padding-right: 10px;
            padding-top: 10px;
            font-size: 12px;
            width: 302px;
            float: left;
        }
        .QACheckbox
        {
            color: Gray;
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
            padding: 5px 7px;
            color: #fff;
            background: green; /* background: #f38e22;*/
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid green; /*border: 1px solid #f38e22;*/
            cursor: pointer;
            float: left;
            width: 65px;
            height: 24px;
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
            width: 52px;
            float: left;
        }
        .btnPrint
        {
            font-size: 12px;
            padding: 4px 7px;
            color: #fff;
            background: #39589C;
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid #39589C;
            cursor: pointer;
            width: 51px;
            float: left;
        }
        .RightSide span
        {
            color: #6b6464;
        }
        .DisplayBlock
        {
            display: block;
            width: 125px;
        }
        .DisplayBlock .txtRaise
        {
            width: 42px;
            height: 11px;
            text-align: center;
            margin: 2px 2px;
        }
        .DisInlineBlock
        {
            width: 67px;
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
        .LavContainer input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        .Passfail
        {
            background: #fff1f1;
        }
        .PassfailLabDec
        {
            background: white;
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
        #grdfourpointcheck td input[type="text"]
        {
            font-size: 10px;
            width: 83%;
            text-transform: capitalize;
            margin: 2px 0px;
            text-align: center;
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
            width: 1234px;
            max-width: 1234px;
        }
        .TotalTable td
        {
            border: 1px solid #dbd8d8;
            border-top: 0px;
            min-width: 40px;
            max-width: 40px;
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
            font-size: 11px;
            font-weight: bold;
        }
        label
        {
            position: relative;
            top: -2px;
        }
        #grv_Accessories_Inspection
        {
            max-width: 975px;
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
        
        td .EmptyTable td input[type="text"]
        {
            width: 78%;
        }
        td .EmptyTable td.Header1
        {
            border-bottom: 0px !important;
            border-left: 0px !important;
            border-top: 1px solid #999;
        }
        td .EmptyTable td.Header2
        {
            border: 1px solid #999;
            border-left: 0px !important;
        }
        td .EmptyTable td
        {
            border-right: 1px solid #9999;
            border-bottom: 1px solid #9999;
            border-bottom-color: #999 !important;
        }
        td[colspan="28"]
        {
            border: 0px;
            padding: 0px 0px;
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
        .innertable
        {
            width: 95%;
        }
        td table.innertable td
        {
            border: 0px;
        }
        td.roll_no_30
        {
            min-width: 30px;
            border-left-color: #999 !important;
        }
        td.Status_63
        {
            min-width: 49px !important;
        }
        td.Actiont_63
        {
            border-right-color: #999 !important;
        }
        
        .Stage1
        {
            position: sticky; /*margin-left:173px;*/
            font-size: 12px;
            margin-top: 1px;
        }
        .Stage2
        {
            position: sticky; /* margin-left:210px;*/
            font-size: 12px;
            margin-top: 1px;
        }
        .Stage3
        {
            position: sticky; /* margin-left:284px;*/
            font-size: 12px;
            margin-top: 1px;
        }
        .Stage4
        {
            position: sticky; /*margin-left:375px;*/
            font-size: 12px;
            margin-top: 1px;
        }
        .FabricInspection
        {
            /*margin-right: 165px;
            position: sticky;
            margin-left: 35%;*/
            margin-right: 280px;
            position: sticky;
            margin-left: 45%;
        }
        .FabricInspectionFinish
        {
            /*margin-right: 381px;
            position: sticky;
            margin-left: 35%;
            margin-right: 455px;
            position: sticky;
            margin-left: 45%;*/
        }
        #sb-wrapper.FourPointCheckLef
        {
            top: 0px !important;
            left: 150px !important;
        }
        #sb-wrapper-inner.FourPointCheck
        {
            min-height: 640px !important;
            max-height: 780px;
            overflow: auto !important;
            width: 1243px;
        }
        .tooltip
        {
            position: relative;
            display: inline-block;
            border-bottom: 1px dotted black;
        }
        
        .tooltip .tooltiptext
        {
            visibility: hidden;
            width: 120px;
            background-color: #555;
            color: #fff;
            text-align: center;
            border-radius: 6px;
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
        .positionclass
        {
            position: relative;
        }
        
        .ui-widget-content
        {
            display: none;
        }
    </style>
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
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
    <script src='<%= Page.ResolveUrl("~/js/CostRange/ProDuctShadowBox.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript">

        function FailExtraQtyValidationSubmit() {
            var TotalFailQty = 0;
            var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseInt($("#lblTotalFailQty").text().replace(',', ''));
            var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseInt($("#txtFailedRaisedDebit").val().replace(',', ''));
            var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseInt($("#txtFailedStock").val().replace(',', ''));
            var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseInt($("#txtFailedGoodStock").val().replace(',', ''));
            var Userid = $("#hdnUserid").val();
            if (failQty != 0) {
                TotalFailQty = FailRaisedQty + FailStockQty + FailGoodQty;
                if (hdnGM_Manager.value == "1" || hdnQAManager.value == "1") {
                    if (Userid != 148) {

                        if (TotalFailQty > 0) {
                            if (FailGoodQty > 0) {
                                alert('Must resolve the usable stock quantity segregation.');
                                return false;
                            }

                            if (TotalFailQty == 0) {
                                alert('Must resolve the fail quantity segregation.');
                                return false;
                            }

                            else if (TotalFailQty != failQty) {
                                alert('Must resolve the fail quantity segregation.');
                                return false;
                            }

                            if (FailRaisedQty > 0) {
                                if ($("#txtFailedParticular").val() == "") {
                                    alert("Particular can't blank.");
                                    $("#txtFailedParticular").focus();
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            var TotalExtraQty = 0;
            var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseInt($("#lblInspectExtraQty").text().replace(',', ''));
            var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseInt($("#txtInspectRaisedDebit").val().replace(',', ''));
            var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseInt($("#txtInspectUsableStock").val().replace(',', ''));
            if (ExtraQty != 0) {
                TotalExtraQty = ExtraRaisedQty + ExtraUsableQty;
                if (hdnGM_Manager.value == "1" || hdnQAManager.value == "1") {
                    if (TotalExtraQty > 0) {
                        if (TotalExtraQty == 0) {
                            alert('Must resolve the extra quantity segregation.');
                            return false;
                        }
                        else if (TotalExtraQty != ExtraQty) {
                            alert('Must resolve the extra quantity segregation.');
                            return false;
                        }

                        if (ExtraRaisedQty > 0) {
                            if ($("#txtInspectParticular").val() == "") {
                                alert("Particular can't blank.");
                                $("#txtInspectParticular").focus();
                                return false;
                            }
                        }
                    }
                }
            }

        }

        function Callfile(elem) {
            if (elem == 'internal') {
                $("#hdnInternalIsFile").val("1");
                $("#uploadInternalLabReport").trigger('click');

                if ($('#chkExternalReceivedInLab').is(':checked')) {
                    if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1" && $("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                        $("#chkLabManager").attr("disabled", false);
                    }
                    else {

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
                    if ($("#chkExternalReceivedInLab").is(':checked') && $("#hdnExternalIsFile").val() == "1" && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
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

        function InternalReceiveInLabValidation() {
            if ($('#chkInternalReceivedInLab').is(':checked')) {
                $('#hylnkInternalLabReportText').css("display", "");
                $('#hylnkInternalLabReportText').css('visibility', 'visible');
            }
            else {
                $('#hylnkInternalLabReportText').css('visibility', 'hidden');
                $('#uploadInternalLabReport').val('');
                $("#chkLabManager").attr("checked", false);
                $("#chkLabManager").attr("disabled", true);
            }
        }

        function ExternalReceiveInLabValidation() {
            if ($('#chkExternalReceivedInLab').is(':checked')) {

                $('#hylnkExternalLabReportText').css("display", "");
                $('#hylnkExternalLabReportText').css('visibility', 'visible');
            }
            else {
                $('#hylnkExternalLabReportText').css('visibility', 'hidden');
                $('#uploadExternalLabReport').val('');
                $("#chkLabManager").attr("checked", false);
                $("#chkLabManager").attr("disabled", true);

            }
        }

        function EnableDisableParticular(elem, type) {
            var RaiseDebit = elem.value;
            if (type == 'FailedQty') {
                if (RaiseDebit == "") {
                    $("#txtFailedParticular").attr("readonly", true);
                    $("#txtFailedParticular").attr("placeholder", "");
                }
                else {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtFailedParticular").attr("readonly", false);
                        $("#txtFailedParticular").attr("placeholder", "Debit Particular");
                    }
                    else {
                        $("#txtFailedParticular").attr("readonly", true);
                    }
                }
            }
            if (type == 'ExtraQty') {
                if (RaiseDebit == "") {
                    $("#txtInspectParticular").attr("readonly", true);
                    $("#txtInspectParticular").attr("placeholder", "");
                }
                else {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtInspectParticular").attr("readonly", false);
                        $("#txtInspectParticular").attr("placeholder", "Debit Particular");
                    }
                    else {
                        $("#txtInspectParticular").attr("readonly", true);
                    }
                }
            }

        }

        function InternalSentoLabValid() {
            var specimancount = $("#txtInternalLabSpecimanCount").val();
            if (specimancount != "" && specimancount != 0) {
                $("#chkInternalSentToLab").attr('disabled', false);
            }

            if (specimancount == "" && specimancount == 0) {
                $("#chkInternalSentToLab").attr('checked', false);
                $("#chkInternalSentToLab").attr('disabled', true);
            }
        } // added by shubhendu

        function SBClose() { }

        function OpenTestReport(url) {
            var url = url + "&SrvNO=" + '<%= Request.QueryString["SrvID"] %>';
            var sURL = url;

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function OpenTestReport2(url) {
            var url = url + "&SrvNO=" + '<%= Request.QueryString["SrvID"] %>';
            window.open(url, 'popUpWindow', 'height=500,width=700,left=500,top=250,Bottam=250,scrollbars=no,menubar=no,status=no,resizable=no,copyhistory=no,titlebar=no,location=no')

            return false;
        }

        function ExternalSentoLabValid() {
            var specimancount = $("#txtExternalLabSpecimanCount").val();
            if (specimancount != "" && specimancount != 0) {
                $("#chkExternalSentToLab").attr('disabled', false);
            }
            if (specimancount == "" && specimancount == 0) {
                $("#chkExternalSentToLab").attr('checked', false);
                $("#chkExternalSentToLab").attr('disabled', true);
            }
        }

        function specimanInternalCountValidation() {
            var speciCount = $('#txtInternalLabSpecimanCount').val();
            if ($('#chkInternalSentToLab').is(':checked')) {
                if (speciCount == "" && speciCount == 0) {
                    alert("Internal Specimen count can't blank.");
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

            var TotalFailQty = 0;
            var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseInt($("#lblTotalFailQty").text().replace(',', ''));
            var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseInt($("#txtFailedRaisedDebit").val().replace(',', ''));
            var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseInt($("#txtFailedStock").val().replace(',', ''));
            var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseInt($("#txtFailedGoodStock").val().replace(',', ''));
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
            var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseInt($("#lblInspectExtraQty").text().replace(',', ''));
            var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseInt($("#txtInspectRaisedDebit").val().replace(',', ''));
            var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseInt($("#txtInspectUsableStock").val().replace(',', ''));
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

        function ValidateCheckerName() {
            if ($('#txtcheckname1').val() == "") {
                $('#txtcheckname1').css('border-color', 'red');
            }
            else {
                $('#txtcheckname1').css('border-color', 'black');
            }
        }

        function LabFileReportView(elem) {
            var sURL = $(elem).attr("href");
            //            alert(sURL);

            var splitUrl = sURL.split("$");
            //            alert(splitUrl[2]);
        }

        function OnHoldQtyValidation() {

            if ($('#ChkFabricQa').attr("checked")) {
                if ($("#lblTotalHold").text() != "" && $("#lblTotalHold").text() != "0") {
                    alert("Make sure you don't have hold quantity.");
                    $('#ChkFabricQa').attr("checked", false);
                }

                var TotalChecked = $("#lblTotalChecked").text() == "" ? 0 : parseInt($("#lblTotalChecked").text().replace(',', ''));
                var TotalActualLength = $("#lblTotalActualLength").text() == "" ? 0 : parseInt($("#lblTotalActualLength").text().replace(',', ''));

                if (parseInt(TotalChecked) < parseInt(TotalActualLength)) {
                    var UncheckedLength = (parseInt(TotalActualLength) - parseInt(TotalChecked));
                    if (confirm("Are you sure to sign as " + UncheckedLength + " quantity left to check ?")) {
                        $('#ChkFabricQa').attr("checked", true);
                    }
                    else {
                        $('#ChkFabricQa').attr("checked", false);
                    }
                }
            }
        }


        //new code for freeze all textboxes when Signature checked by GM start
        function FreezeFailExtraQuantityOnGMSignatureCheckedValidation() {

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

        }
        //new code for freeze all textboxes when Signature checked by GM end

        function MaterialGM_UsableStockValidation() {

            var TotalFailQty = 0;
            var failQty = $("#lblTotalFailQty").text() == "" ? 0 : parseInt($("#lblTotalFailQty").text().replace(',', ''));
            var FailRaisedQty = $("#txtFailedRaisedDebit").val() == "" ? 0 : parseInt($("#txtFailedRaisedDebit").val().replace(',', ''));
            var FailStockQty = $("#txtFailedStock").val() == "" ? 0 : parseInt($("#txtFailedStock").val().replace(',', ''));
            var FailGoodQty = $("#txtFailedGoodStock").val() == "" ? 0 : parseInt($("#txtFailedGoodStock").val().replace(',', ''));
            if (failQty != 0) {
                TotalFailQty = FailRaisedQty + FailStockQty + FailGoodQty;

                if (FailGoodQty > 0) {
                    alert('Must resolve the usable stock quantity segregation.');
                    $('#ChkFabricGM').attr("checked", false);
                    FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                    return;
                }

                if (TotalFailQty == 0) {
                    alert('Must resolve the fail quantity segregation.');
                    $('#ChkFabricGM').attr("checked", false);
                    FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                    return;
                }

                else if (TotalFailQty != failQty) {
                    alert('Must resolve the fail quantity segregation.');
                    $('#ChkFabricGM').attr("checked", false);
                    FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                    return;
                }

                if (FailRaisedQty > 0) {
                    if ($("#txtFailedParticular").val() == "") {
                        alert("Particular can't blank.");
                        $('#ChkFabricGM').attr("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        $("#txtFailedParticular").focus();
                        return;
                    }
                }
            }

            var TotalExtraQty = 0;
            var ExtraQty = $("#lblInspectExtraQty").text() == "" ? 0 : parseInt($("#lblInspectExtraQty").text().replace(',', ''));
            var ExtraRaisedQty = $("#txtInspectRaisedDebit").val() == "" ? 0 : parseInt($("#txtInspectRaisedDebit").val().replace(',', ''));
            var ExtraUsableQty = $("#txtInspectUsableStock").val() == "" ? 0 : parseInt($("#txtInspectUsableStock").val().replace(',', ''));
            if (ExtraQty != 0) {
                TotalExtraQty = ExtraRaisedQty + ExtraUsableQty;
                if (TotalExtraQty == 0) {
                    alert('Must resolve the extra quantity segregation.');
                    $('#ChkFabricGM').attr("checked", false);
                    FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                    return;
                }
                else if (TotalExtraQty != ExtraQty) {
                    alert('Must resolve the extra quantity segregation.');
                    $('#ChkFabricGM').attr("checked", false);
                    FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                    return;
                }

                if (ExtraRaisedQty > 0) {
                    if ($("#txtInspectParticular").val() == "") {
                        alert("Particular can't blank.");
                        $('#ChkFabricGM').attr("checked", false);
                        FreezeFailExtraQuantityOnGMSignatureCheckedValidation();
                        $("#txtInspectParticular").focus();
                        return;
                    }
                }
            }

        }

        function closePage() {
            parent.location.reload();
            self.parent.Shadowbox.close();
        }

        function MyFunction() {

            if ($("#rdyBtnLabDecPassInter").is(':checked')) {
                $("#hdnIntPass").val(1);
            }

            if ($("#rdyBtnLabDecFailInter").is(':checked')) {
                $("#hdnIntFail").val(0);
            }

            if ($("#rdyBtnLabDecPassExt").is(':checked')) {
                $("#hdnExtPass").val(1);
            }

            if ($("#rdyBtnLabDecFailExt").is(':checked')) {
                $("#hdnExtFail").val(0);
            }
        }

        $(document).ready(function () {

            $("#rdyBtnLabDecPassExt").attr("disabled", true);
            $("#rdyBtnLabDecFailExt").attr("disabled", true);

            if ($("#ChkFabricQa").is(':checked')) {
                if ($("#rbtFinalDecisionPass").is(':checked') || $("#rdybtnComeercialPass").is(':checked') || $("#rbtFinalDecisionFail").is(':checked')) {
                    $("#finalDecission").attr('data-disabled', 'true');
                    $("#rbtFinalDecisionPass").attr("disabled", true);
                    $("#rdybtnComeercialPass").attr("disabled", true);
                    $("#rbtFinalDecisionFail").attr("disabled", true);
                    if ($("#hdnLoginId").val() == "148") {
                        $("#btnSubmit").attr("disabled", true);
                    }
                }
            }
            if ($("#ChkFabricQa").is(':checked') && $("#chkLabManager").is(':checked') && $("#ChkFabricGM").is(':checked')) {

                $("#btnSubmit").attr("disabled", true);
            }
            if ($("#chkLabManager").is(':checked') || $("#ChkFabricQa").is(':checked')) {

                if ($("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                    $("#rdyBtnLabDecPassInter").attr("disabled", true);
                    $("#rdyBtnLabDecFailInter").attr("disabled", true);

                }
                if ($("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
                    $("#rdyBtnLabDecFailExt").attr("disabled", true);
                    $("#rdyBtnLabDecPassExt").attr("disabled", true);

                }
                if ($("#hdnLoginId").val() == "40" && $("#chkLabManager").is(':checked')) {
                    $("#btnSubmit").attr("disabled", true);
                }

            }
            if ($("#hdnLoginId").val() == "15") {
                if (!$("#ChkFabricGM").is(':checked')) {
                    if ($("#rdybtnComeercialPass").is(':checked')) {
                        $("#hdnDecissionCommercialpass").val(1);
                        $("#hdnFinalDecissionPass").val(1);
                    }
                    else if ($("#rbtFinalDecisionPass").is(':checked')) {
                        $("#hdnFinalDecissionPass").val(1);
                    }
                    else if ($("#rbtFinalDecisionFail").is(':checked')) {
                        $("#hdnFinalDecissionFail").val(0);
                        $("#hdnDecissionCommercialpass").val(-1);
                    }
                }
            }

            if (parseInt($("#hdnInternalIsFile").val()) > 0 && (!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked'))) {

                $("#rdyBtnLabDecPassInter").attr("disabled", "");
                $("#rdyBtnLabDecFailInter").attr("disabled", "");
                $("#rdyBtnLabDecPassExt").attr("disabled", true);
                $("#rdyBtnLabDecFailExt").attr("disabled", true);

                if ((!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked')) && ($("#chkInternalSentToLab").is(':checked') && $("#chkExternalSentToLab").is(':checked'))) {

                    $("#btnSubmit").attr("disabled", false);
                    $("#chkLabManager").attr("checked", false);
                    $("#chkLabManager").attr("disabled", false);
                    $("#lblFabLabManagerName").hide();
                    $("#lblLabDatetime").hide();
                }

            }
            else {
                if (parseInt($("#hdnInternalIsFile").val()) < 1 && (!$("#rdyBtnLabDecPassInter").is(':checked') && !$("#rdyBtnLabDecFailInter").is(':checked'))) {
                    $("#rdyBtnLabDecPassInter").attr("disabled", true);
                    $("#rdyBtnLabDecFailInter").attr("disabled", true);
                    $("#btnSubmit").attr("disabled", false);
                    $("#chkLabManager").attr("checked", false);

                    $("#chkLabManager").attr("disabled", false);
                    $("#lblFabLabManagerName").hide();
                    $("#lblLabDatetime").hide();

                }
            }
            if (parseInt($("#hdnExternalIsFile").val()) > 0 && (!$("#rdyBtnLabDecPassExt").is(':checked') && !$("#rdyBtnLabDecFailExt").is(':checked')) && $("#hdnLabId").val() == "1") {

                $("#rdyBtnLabDecPassExt").attr("disabled", "");
                $("#rdyBtnLabDecFailExt").attr("disabled", "");

                if (($("#rdyBtnLabDecPassExt").is(':checked') && $("#rdyBtnLabDecFailExt").is(':checked')) && ($("#chkInternalSentToLab").is(':checked') && $("#chkExternalSentToLab").is(':checked'))) {
                    $("#chkLabManager").attr("disabled", false);
                }
                else {
                    $("#chkLabManager").attr("disabled", true);
                }

                $("#chkLabManager").attr("checked", false);
                $("#btnSubmit").attr("disabled", false);
                $("#lblFabLabManagerName").hide();
                $("#lblLabDatetime").hide();

            }
            else {
                if (parseInt($("#hdnExternalIsFile").val()) < 1 && (!$("#rdyBtnLabDecPassExt").is(':checked') && !$("#rdyBtnLabDecFailExt").is(':checked')) && ($("#chkInternalSentToLab").is(':checked') && $("#chkExternalSentToLab").is(':checked'))) {

                    $("#rdyBtnLabDecPassExt").attr("disabled", true);
                    $("#rdyBtnLabDecFailExt").attr("disabled", true);
                    $("#btnSubmit").attr("disabled", false);

                    if (($("#rdyBtnLabDecPassExt").is(':checked') && $("#rdyBtnLabDecFailExt").is(':checked')) && ($("#chkInternalSentToLab").is(':checked') && $("#chkExternalSentToLab").is(':checked'))) {
                        $("#chkLabManager").attr("disabled", false);
                    }

                    $("#chkLabManager").attr("checked", false);
                    $("#lblFabLabManagerName").hide();
                    $("#lblLabDatetime").hide();

                }

            }
            if ($("#hdnLoginId").val() != "40") {
                $("#chkLabManager").attr("disabled", true);
            }

            if ($("#hdnUserid").val() == "148") {
            }

            $("#ChkFabricGM").click(function () {
                if ($("#ChkFabricGM").is(':checked')) {
                    $("#btnSubmit").attr("disabled", false);
                }
                else {
                    $("#btnSubmit").attr("disabled", true);
                }

                if ($("#hdnLoginId").val() != "148") {
                    $("#rbtFinalDecisionPass").attr("disabled", true);
                    $("#rdybtnComeercialPass").attr("disabled", true);
                    $("#rbtFinalDecisionFail").attr("disabled", true);

                }
            });

            if ($("#lblTotalFailQty").text() == "") {
                $("#txtFailedRaisedDebit").attr("readonly", true);
                $("#txtFailedStock").attr("readonly", true);
                $("#txtFailedGoodStock").attr("readonly", true);
                $("#txtFailedParticular").attr("readonly", true);
            }
            else {
                if ($("#txtFailedRaisedDebit").val() != "") {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtFailedParticular").attr("placeholder", "Debit Particular");
                        $("#txtFailedParticular").attr("readonly", false);
                    }
                    else {
                        $("#txtFailedParticular").attr("readonly", true);
                    }
                }
                else {
                    $("#txtFailedParticular").attr("readonly", true);
                }
            }

            if ($("#lblInspectExtraQty").text() == "") {
                $("#txtInspectRaisedDebit").attr("readonly", true);
                $("#txtInspectUsableStock").attr("readonly", true);
                $("#txtInspectParticular").attr("readonly", true);
            }
            else {
                if ($("#txtInspectRaisedDebit").val() != "") {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtInspectParticular").attr("placeholder", "Debit Particular");
                        $("#txtInspectParticular").attr("readonly", false);
                    }
                    else {
                        $("#txtInspectParticular").attr("readonly", true);
                    }
                }
                else {
                    $("#txtInspectParticular").attr("readonly", true);
                }
            }

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
                                if ($("#txtExternalLabSpecimanCount").val() != "" && $("#chkExternalSentToLab").is(':checked') && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
                                    $("#chkLabManager").attr("disabled", false);
                                }

                                else if ($("#rdyBtnLabDecPassInter").is(':checked') || $("#rdyBtnLabDecFailInter").is(':checked')) {
                                    $("#chkLabManager").attr("disabled", false);
                                }
                                else {
                                    $("#chkLabManager").attr("disabled", true);
                                }
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

                if (parseInt(LabId) == 1 && LabManager == 0) {
                    if ($('#chkExternalSentToLab').is(':checked')) {
                        if ($('#chkExternalReceivedInLab').is(':checked')) {
                            if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1" && $("#rdyBtnLabDecPassExt").is(':checked') || $("#rdyBtnLabDecFailExt").is(':checked')) {
                                $("#chkLabManager").attr("disabled", false);
                            }
                            else {
                                if ($("#txtInternalLabSpecimanCount").val() != "" && $("#chkInternalSentToLab").is(':checked')) {
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
        });

        var totalActualLength = 0, totalDyeLot = 0, totalClaimedLength = 0, totalChkd = 0, totalPass = 0, totalFail = 0, totalHold = 0;  //new line
        var totalThaans = 0; //new line
        function PageLoad() {
            if ($("#lblTotalFailQty").text() == "") {
                $("#txtFailedRaisedDebit").attr("readonly", true);
                $("#txtFailedStock").attr("readonly", true);
                $("#txtFailedGoodStock").attr("readonly", true);
                $("#txtFailedParticular").attr("readonly", true);

            }
            else {
                if ($("#txtFailedRaisedDebit").val() != "") {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtFailedParticular").attr("placeholder", "Debit Particular");
                        $("#txtFailedParticular").attr("readonly", false);

                    }
                    else {
                        $("#txtFailedParticular").attr("disabled", false);
                    }
                }
                else {
                    $("#txtFailedParticular").attr("readonly", true);
                }
            }

            if ($("#lblInspectExtraQty").text() == "") {
                $("#txtInspectRaisedDebit").attr("readonly", true);
                $("#txtInspectUsableStock").attr("readonly", true);
                $("#txtInspectParticular").attr("readonly", true);
            }
            else {
                if ($("#txtInspectRaisedDebit").val() != "") {
                    if ($('#ChkFabricGM').is(':checked') == false) {
                        $("#txtInspectParticular").attr("placeholder", "Debit Particular");
                        $("#txtInspectParticular").attr("readonly", false);
                    }
                    else {
                        $("#txtInspectParticular").attr("readonly", true);
                    }
                }
                else {
                    $("#txtInspectParticular").attr("readonly", true);
                }
            }

            var LabId = $('#hdnLabId').val();
            var LabManager = $('#hdnLabManager').val() == "" ? -1 : parseInt($('#hdnLabManager').val());
            if ($("#hdnLoginId").val() == "40") {
                if (parseInt(LabId) == 0 && LabManager == 0) {
                    if ($('#chkInternalSentToLab').is(':checked')) {
                        if ($('#chkInternalReceivedInLab').is(':checked')) {
                            if ($("#chkExternalReceivedInLab").is(':checked') && $("#hdnExternalIsFile").val() == "1") {
                                $("#chkLabManager").attr("disabled", false);
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

                if (parseInt(LabId) == 1 && LabManager == 0) {
                    if ($('#chkExternalSentToLab').is(':checked')) {
                        if ($('#chkExternalReceivedInLab').is(':checked')) {
                            if ($("#chkInternalReceivedInLab").is(':checked') && $("#hdnInternalIsFile").val() == "1") {
                                $("#chkLabManager").attr("disabled", false);
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

            $(function () {
                $('.addbnn').dblclick(false);
            });

            $(".datesfileds").on("keydown", function (e) {
                if (e.which === 8 && !$(e.target).is("input:not([readonly]), textarea")) {
                    e.preventDefault();
                }
            });

            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $('input').attr('autocomplete', 'off');
            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();
            });

            $(".noonly").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

            $('[id*=lblfab]').attr('readonly', 'true');
            $('[id*=txtprintcolor]').attr('readonly', 'true');
            $('[id*=txtsuppliername]').attr('readonly', 'true');
            $('[id*=txtponumber]').attr('readonly', 'true');
            $('[id*=txttotalqty]').attr('readonly', 'true');

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

            $('input[name="number"]').keyup(function (e) {
                if (/\D/g.test(this.value)) {
                    // Filter non-digits from input value.
                    this.value = this.value.replace(/\D/g, '');
                }
            });

            CalculateOnLoad();
        }

        function isDoubleClicked(element) {
            //if already clicked return TRUE to indicate this click is not allowed
            if (element.data("isclicked")) return true;

            //mark as clicked for 1 second
            element.data("isclicked", true);
            setTimeout(function () {
                element.removeData("isclicked");
            }, 1000);

            //return FALSE to indicate this click was allowed
            return false;
        }


        $(document).ready(function () {

            //added by Girish on 2023-04-17:Start
            var postatus = '<%=this.postatus %>';

            if (postatus == 1) {
                $("input, textarea, button, select link ").attr("disabled", "disabled");
                $("#grdfourpointcheck").attr("disabled", "disabled");

                $("a").attr("href", "javascript:void(0);")
                $("a").attr("onclick", "javascript:void(0);")
                $("a").attr("onclick", "javascript:void(0);")
                $("#btnSubmit").hide();
            }
            else if ($('#ChkFabricGM').is(':checked')) {
                if ($('#hdnDesignationId').val() == "40" && $('#lblFabGMName').html() == 'Bipladmin Admin') {
                    $("textarea:not(.LavContainer textarea), button:not(.LavContainer button), select:not(.LavContainer select) link:not(.LavContainer link) ").attr("disabled", "disabled");

                    $("#grdfourpointcheck").attr("disabled", "disabled");

                    $("input[type='text']:not(#btnSubmit)").attr("disabled", true);

                    $("a:not(.LavContainer a)").attr("href", "javascript:void(0);")
                    $("a:not(.LavContainer a)").attr("onclick", "javascript:void(0);")
                    $("a:not(.LavContainer a)").attr("onclick", "javascript:void(0);")

                    if (!$('#lblFabGMName').html() == 'Bipladmin Admin') {
                        $("#btnSubmit").hide();
                    }
                }
                else {
                    $("input, textarea, button, select link ").attr("disabled", "disabled");
                    $("#grdfourpointcheck").attr("disabled", "disabled");

                    $("a").attr("href", "javascript:void(0);")
                    $("a").attr("onclick", "javascript:void(0);")
                    $("a").attr("onclick", "javascript:void(0);")
                    $("#btnSubmit").hide();
                }


            }
            //added by Girish on 2023-04-17:End

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            }

            $(function () {
                $('.addbnn').dblclick(false);
            });

            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();

            });

            $('input[name="number"]').keyup(function (e) {
                if (/\D/g.test(this.value)) {
                    // Filter non-digits from input value.
                    this.value = this.value.replace(/\D/g, '');
                }
            });

            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $('input').attr('autocomplete', 'off');
            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();

            });

            $(".noonly").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

            $('[id*=lblfab]').attr('readonly', 'true');
            $('[id*=txtprintcolor]').attr('readonly', 'true');
            $('[id*=txtsuppliername]').attr('readonly', 'true');
            $('[id*=txtponumber]').attr('readonly', 'true');
            $('[id*=txttotalqty]').attr('readonly', 'true');

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

            CalculateOnLoad();
        });

        function SRV_Validation() {

            var ReceivingVoucherNo = $('[id*=txtReceivingVoucherNo]').val();
            var SrvDate = $('[id*=txtSrvDate]').val();
            var PartyChallanNo = $('[id*=txtPartyChallanNo]').val();
            var GateEntryNo = $('[id*=txtGateEntryNo]').val();
            var UnitName = $('[id*=ddlunitname]').val();
            var Receivedqty = $('[id*=txtReceivedqty]').val();
            var PartyBillNo = $('[id*=txtPartyBillNo]').val();

            if (ReceivingVoucherNo == "") {
                alert("Please Enter Receiving Voucher Number");
                return false;
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

            if (PartyBillNo == "") {
                alert("Please Enter Party Bill Number");
                return false;
            }
        }

        function callparentpage() {
            window.parent.CallThisPage();
        }

        $(".noonly").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });

        function checkzero(elem) {
            var txtVal = elem.value;
            if (parseFloat(txtVal) <= 0 || txtVal === parseInt(txtVal, 10)) {
                alert("input value cannot be zero!")
                elem.value = elem.defaultValue;
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode >= 48 && charCode <= 57)
                return true;

            return false;
        }

        //new code for pass fail validation onblur start

        function RemoveComma(elem) {
            var ValueWithoutComma = elem.value.replace(',', '');
            elem.value = ValueWithoutComma;
        }

        var isFunctionRunning = false;

        function CheckCheckedQuantity(elem, type, flag) {
            //code updated by Girish on 2023-03-13
            if (isFunctionRunning) {
                return;
            }

            var IsError = "";
            var Idsn = elem.id.split("_")[1];
            var checkedqnt;
            var actlength;
            if (flag == '1') {
                checkedqnt = $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val() == "" ? 0 : parseInt($("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val().replace(',', ''));
                actlength = $("#grdfourpointcheck_" + Idsn + "_txtactlenght" + type).val() == "" ? 0 : parseInt($("#grdfourpointcheck_" + Idsn + "_txtactlenght" + type).val().replace(',', ''));
            }
            else if (flag == '2') {
                checkedqnt = $("#grdfourpointcheck_" + Idsn + "_txtchecked" + type).val() == "" ? 0 : parseInt($("#grdfourpointcheck_" + Idsn + "_txtchecked" + type).val().replace(',', ''));
                actlength = $("#grdfourpointcheck_" + Idsn + "_txtactlenght_emptyrow").val() == "" ? 0 : parseInt($("#grdfourpointcheck_" + Idsn + "_txtactlenght_emptyrow").val().replace(',', ''));
            }

            if (actlength > 0) {
                if (parseInt(checkedqnt) == 0) {
                    alert("Checked Quantity can't blank!");
                    isFunctionRunning = true;

                    IsError = "True";
                    if (flag == '1') {
                        $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val("");
                        $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val("");
                        $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val("");
                        $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val("");
                    }
                    else if (flag == '2') {
                        $("#grdfourpointcheck_" + Idsn + "_txtcheckedlength_emptyrow").val("");
                        $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                        $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                        $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                    }
                }
            }
            else {
                IsError = "True";

                if (flag == '1') {
                    $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val("");
                }
                else if (flag == '2') {
                    $("#grdfourpointcheck_" + Idsn + "_txtcheckedlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                }
            }

            if (IsError != "True" && parseInt(checkedqnt) > parseInt(actlength)) {
                alert("Checked quantity can't be greater than Actual length!");
                isFunctionRunning = true;
                IsError = "True";

                if (flag == '1') {
                    $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val("");
                }
                else if (flag == '2') {
                    $("#grdfourpointcheck_" + Idsn + "_txtcheckedlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                }
            }
            if (IsError = "True") {
                isFunctionRunning = false;
                return false;
            }
        }

        function CheckPassFailValidation(elem, type, flag) {

            //below code updated by Girish on 2023-03-13
            if (isFunctionRunning) {
                return;
            }

            var IsError = "";
            var checked;
            var Idsn = elem.id.split("_")[1];

            if (flag == '1') {
                checked = $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val().replace(',', '');
            }
            else if (flag == '2') {
                checked = $("#grdfourpointcheck_" + Idsn + "_txtchecked" + type).val().replace(',', '');
            }
            if (checked == "") {
                alert("Check Quantity shouldn't blank.");
                IsError = "True";
                isFunctionRunning = true;

                if (flag == '1') {
                    $("#grdfourpointcheck_" + Idsn + "_txtchkd" + type).val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                    $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                    $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                }
                else if (flag == '2') {
                    $("#grdfourpointcheck_" + Idsn + "_txtcheckedlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                }
            }

            var pass = $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val().replace(',', '') == "" ? 0 : $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val().replace(',', '');

            if (IsError != "True" && parseInt(pass) > parseInt(checked)) {
                alert("Pass Qty Cannot be greater than Checked Qty.");
                IsError = "True";
                isFunctionRunning = true;

                if (flag == '1') {
                    $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                    $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                    $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                }
                else if (flag == '2') {
                    $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                    $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                }
            }

            var fail = $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val().replace(',', '');
            var hold = $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val().replace(',', '');

            if (IsError != "True") {

                if (pass != "" && fail != "" && hold != "") {
                    if ((parseInt(pass) + parseInt(fail) + parseInt(hold)) > parseInt(checked)) {
                        alert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass != "" && fail == "" && hold == "") {
                    if ((parseInt(pass) + 0) > parseInt(checked)) {
                        alert("Pass + Fail Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass == "" && fail == "" && hold != "") {
                    if ((parseInt(hold) + 0) > parseInt(checked)) {
                        alert("Pass + Fail + Hold Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass == "" && fail != "" && hold == "") {
                    if ((parseInt(fail) + 0) > parseInt(checked)) {
                        alert("Pass + Fail + Hold Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass != "" && fail != "" && hold == "") {
                    if ((parseInt(pass)) + (parseInt(fail)) > parseInt(checked)) {
                        alert("Pass + Fail + Hold Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass != "" && fail == "" && hold != "") {
                    if ((parseInt(pass)) + (parseInt(hold)) > parseInt(checked)) {
                        alert("Pass + Fail + Hold Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else if (pass == "" && fail != "" && hold != "") {
                    if ((parseInt(fail)) + (parseInt(hold)) > parseInt(checked)) {
                        alert("Pass + Fail + Hold Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txthold" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtholdlength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
                else {
                    if ((0 + parseInt(fail)) > parseInt(checked)) {
                        alert("Pass + Fail Quantity can't be greater than Checked Quantity!");
                        IsError = "True";
                        isFunctionRunning = true;

                        if (flag == '1') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpass" + type).val('');
                            $("#grdfourpointcheck_" + Idsn + "_txtfail" + type).val('');
                        }
                        else if (flag == '2') {
                            $("#grdfourpointcheck_" + Idsn + "_txtpasslength_emptyrow").val("");
                            $("#grdfourpointcheck_" + Idsn + "_txtfaillength_emptyrow").val("");
                        }
                    }
                }
            }

            if (IsError = "True") {
                return false;
                isFunctionRunning = false;
            }
        }
        //new code for pass fail validation onblur end

        function Calculatetotals(elem, type) {
            var w1 = 1;
            var w2 = 2;
            var w3 = 3;
            var w4 = 4;
            var pattamultiplier = 4;
            var holemultiplier = 4;

            var Defectsmultiplier1 = 1;
            var Defectsmultiplier2 = 2;
            var Defectsmultiplier3 = 3;
            var Defectsmultiplier4 = 4;

            var firsttotal = 0;
            var pattaholetotal = 0;
            var thridtotal = 0;
            if (type == 'empty') {

                var rowid = elem.id.split("_")[1];
                //1st Total==============================================================================
                var widths = $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").val();
                if (widths == "") {
                    widths = 0;
                }

                $("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val("");
                $("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val("");
                $("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val("");
                $("#grdfourpointcheck_" + rowid + "_txtweapointyard_emptyrow").val("");
                var weaving1 = $("#grdfourpointcheck_" + rowid + "_txtweaving_1_emptyrow").val();
                var weaving2 = $("#grdfourpointcheck_" + rowid + "_txtweaving_2_emptyrow").val();
                var weaving3 = $("#grdfourpointcheck_" + rowid + "_txtweaving_3_emptyrow").val();
                var weaving4 = $("#grdfourpointcheck_" + rowid + "_txtweaving_4_emptyrow").val();

                if (weaving1 == "") {
                    weaving1 = 0;
                }
                if (weaving2 == "") {
                    weaving2 = 0;
                }
                if (weaving3 == "") {
                    weaving3 = 0;
                }
                if (weaving4 == "") {
                    weaving4 = 0;
                }
                firsttotal = ((parseFloat(weaving1) * parseFloat(w1)) + (parseFloat(weaving2) * parseFloat(w2)) + (parseFloat(weaving3) * parseFloat(w3)) + (parseFloat(weaving4) * parseFloat(w4)))
                if (firsttotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val(Math.round(firsttotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val('');
                    }
                }
                //2nd Total==============================================================================
                var pattaval = $("#grdfourpointcheck_" + rowid + "_txtpatta_emptyrow").val();
                var holeval = $("#grdfourpointcheck_" + rowid + "_txthole_emptyrow").val();
                if (pattaval == "") {
                    pattaval = 0;
                }
                if (holeval == "") {
                    holeval = 0;
                }
                pattaholetotal = ((parseFloat(pattaval) * parseFloat(pattamultiplier)) + (parseFloat(holeval) * parseFloat(holemultiplier)));

                if (pattaholetotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val(Math.round(pattaholetotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val('');
                    }
                }
                //3rd Total==============================================================================  
                var defacts1 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts1_emptyrow").val();
                var defacts2 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts2_emptyrow").val();
                var defacts3 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts3_emptyrow").val();
                var defacts4 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts4_emptyrow").val();
                if (defacts1 == "") {
                    defacts1 = 0;
                }
                if (defacts2 == "") {
                    defacts2 = 0;
                }
                if (defacts3 == "") {
                    defacts3 = 0;
                }
                if (defacts4 == "") {
                    defacts4 = 0;
                }
                thridtotal = ((parseFloat(defacts1) * parseFloat(Defectsmultiplier1)) + (parseFloat(defacts2) * parseFloat(Defectsmultiplier2)) + (parseFloat(defacts3) * parseFloat(Defectsmultiplier3)) + (parseFloat(defacts4) * parseFloat(Defectsmultiplier4)))
                if (thridtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val(Math.round(thridtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val('');
                    }
                }

                //                3 Total Points============================================================================== 
                var t1 = $("#grdfourpointcheck_" + rowid + "_txttotal1_emptyrow").val();
                var t2 = $("#grdfourpointcheck_" + rowid + "_txttotal2_emptyrow").val();
                var t3 = $("#grdfourpointcheck_" + rowid + "_txttotal3_emptyrow").val();

                if (t1 == "") {
                    t1 = 0;
                }
                if (t2 == "") {
                    t2 = 0;
                }
                if (t3 == "") {
                    t3 = 0;
                }

                var subtotal = (parseFloat(t1) + parseFloat(t2) + parseFloat(t3))
                if (subtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotalpoint_emptyrow").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotalpoint_emptyrow").val(Math.round(subtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotalpoint_emptyrow").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotalpoint_emptyrow").val('');
                    }
                }
                var rollvalue = $("#grdfourpointcheck_" + rowid + "_txtrollno_emptyrow").val();
                var claimedlength = $("#grdfourpointcheck_" + rowid + "_txtclaimedlength_emptyrow").val();   //new line
                var actuallengh = $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").val();


                //new code start                

                if (parseInt(actuallengh.replace(',', '')) < parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallengh.replace(',', '')) > parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_emptyrow").attr('style', 'background-color:#fff;color:#000');
                }
                //new code end



                var with_sw = $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").val();
                if (actuallengh == "0") {
                    actuallengh = 0;
                }
                if (claimedlength == "0") {
                    claimedlength = 0;
                }
                if (with_sw == "0") {
                    with_sw = 0;
                }



                //new code start
                var with_mw = $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").val();
                var with_lw = $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").val();
                if (with_sw != "" || with_sw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_sw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_sw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_s_emptyrow").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_mw != "" || with_mw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_mw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_mw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_M_emptyrow").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_lw != "" || with_lw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_lw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_lw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwithd_E_emptyrow").attr('style', 'background-color:#fff;color:#000');
                    }
                }
                //new code end




                if (parseFloat(actuallengh.replace(',', '')) > 0 && parseFloat(with_sw.replace(',', '')) > 0) {
                    finalvalues = (parseFloat(subtotal * 3600) / (with_sw.replace(',', '') * actuallengh.replace(',', '')));

                    if (finalvalues <= 0) {
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_emptyrow").val("");
                    }
                    else {
                        if (finalvalues <= 40) {

                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_emptyrow").val("1");
                        }
                        else {
                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_emptyrow").val("2");
                        }
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_emptyrow").val(Math.round(finalvalues));
                        if ($("#grdfourpointcheck_" + rowid + "_txtweapointyard_emptyrow").val() == "0") {
                            $("#grdfourpointcheck_" + rowid + "_txtweapointyard_emptyrow").val('');
                        }
                    }
                }
            }
            if (type == 'foter') {
                var rowid = elem.id.split("_")[1];
                //                first total==============================================================================

                var widths = $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").val();
                if (widths == "") {
                    widths = 0;
                }

                $("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val("");
                $("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val("");
                $("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val("");
                $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Footer").val("");
                $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Footer").val("");

                var weaving1 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving1_Footer").val();
                var weaving2 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving2_Footer").val();
                var weaving3 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving3_Footer").val();
                var weaving4 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving4_Footer").val();

                if (weaving1 == "") {
                    weaving1 = 0;
                }
                if (weaving2 == "") {
                    weaving2 = 0;
                }
                if (weaving3 == "") {
                    weaving3 = 0;
                }
                if (weaving4 == "") {
                    weaving4 = 0;
                }
                firsttotal = ((parseFloat(weaving1) * parseFloat(w1)) + (parseFloat(weaving2) * parseFloat(w2)) + (parseFloat(weaving3) * parseFloat(w3)) + (parseFloat(weaving4) * parseFloat(w4)))
                if (firsttotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val(Math.round(firsttotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val('');
                    }
                }
                //                2 total==============================================================================
                var pattaval = $("#grdfourpointcheck_" + rowid + "_txtpatta_Footer").val();
                var holeval = $("#grdfourpointcheck_" + rowid + "_txthole_Footer").val();
                if (pattaval == "") {
                    pattaval = 0;
                }
                if (holeval == "") {
                    holeval = 0;
                }
                pattaholetotal = ((parseFloat(pattaval) * parseFloat(pattamultiplier)) + (parseFloat(holeval) * parseFloat(holemultiplier)));

                if (pattaholetotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val(Math.round(pattaholetotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val('');
                    }
                }
                //                3 total==============================================================================  
                var defacts1 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts1_Footer").val();
                var defacts2 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts2_Footer").val();
                var defacts3 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts3_Footer").val();
                var defacts4 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts4_Footer").val();
                if (defacts1 == "") {
                    defacts1 = 0;
                }
                if (defacts2 == "") {
                    defacts2 = 0;
                }
                if (defacts3 == "") {
                    defacts3 = 0;
                }
                if (defacts4 == "") {
                    defacts4 = 0;
                }
                thridtotal = ((parseFloat(defacts1) * parseFloat(Defectsmultiplier1)) + (parseFloat(defacts2) * parseFloat(Defectsmultiplier2)) + (parseFloat(defacts3) * parseFloat(Defectsmultiplier3)) + (parseFloat(defacts4) * parseFloat(Defectsmultiplier4)))
                if (thridtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val(Math.round(thridtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val('');
                    }
                }

                //                3 Total Points============================================================================== 
                var t1 = $("#grdfourpointcheck_" + rowid + "_txttotal_Footer").val();
                var t2 = $("#grdfourpointcheck_" + rowid + "_txtTotal2_Footer").val();
                var t3 = $("#grdfourpointcheck_" + rowid + "_txtTotal3_Footer").val();

                if (t1 == "") {
                    t1 = 0;
                }
                if (t2 == "") {
                    t2 = 0;
                }
                if (t3 == "") {
                    t3 = 0;
                }

                var subtotal = (parseFloat(t1) + parseFloat(t2) + parseFloat(t3))
                if (subtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Footer").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Footer").val(Math.round(subtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtpointTotal_Footer").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Footer").val('');
                    }
                }
                var rollvalue = $("#grdfourpointcheck_" + rowid + "_txtrollno_Footer").val();
                var actuallengh = $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").val();

                //new code start
                //                if (actuallengh != "" && actuallengh != undefined) {
                //                    totalActualLength = totalActualLength + parseInt(actuallengh);
                //                }
                //                if (rollvalue != "" && rollvalue != undefined) {
                //                    totalThaans = totalThaans + parseInt(rollvalue);
                //                }
                var claimedlength = $("#grdfourpointcheck_" + rowid + "_txtclaimedlength_Footer").val();
                if (parseInt(actuallengh.replace(',', '')) < parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallengh.replace(',', '')) > parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Footer").attr('style', 'background-color:#fff;color:#000');
                }
                //new code end
                var with_sw = $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").val();
                if (actuallengh == "0") {
                    actuallengh = 0;
                }
                if (with_sw == "0") {
                    with_sw = 0;
                }
                //new code start
                var with_mw = $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").val();
                var with_lw = $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").val();
                if (with_sw != "" || with_sw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_sw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_sw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Footer").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_mw != "" || with_mw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_mw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_mw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Footer").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_lw != "" || with_lw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_lw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_lw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Footer").attr('style', 'background-color:#fff;color:#000');
                    }
                }
                //new code end
                if (parseFloat(actuallengh.replace(',', '')) > 0 && parseFloat(with_sw.replace(',', '')) > 0) {
                    finalvalues = (parseFloat(subtotal * 3600) / (with_sw.replace(',', '') * actuallengh.replace(',', '')));

                    if (finalvalues <= 0) {
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Footer").val("");
                    }
                    else {
                        if (finalvalues <= 40) {

                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_Footer").val("1");
                        }
                        else {
                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_Footer").val("2");
                        }
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Footer").val(Math.round(finalvalues));
                        if ($("#grdfourpointcheck_" + rowid + "_txtweapointyard_Footer").val() == "0") {
                            $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Footer").val('');
                        }
                    }
                }
            }
            if (type == 'edit') {

                var rowid = elem.id.split("_")[1];
                //                first total==============================================================================

                var widths = $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").val();
                if (widths == "") {
                    widths = 0;
                }

                $("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val("");
                $("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val("");
                $("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val("");
                $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Edit").val("");
                $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Edit").val("");

                var weaving1 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving1_Edit").val();
                var weaving2 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving2_Edit").val();
                var weaving3 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving3_Edit").val();
                var weaving4 = $("#grdfourpointcheck_" + rowid + "_txtwidth_weaving4_Edit").val();

                if (weaving1 == "") {
                    weaving1 = 0;
                }
                if (weaving2 == "") {
                    weaving2 = 0;
                }
                if (weaving3 == "") {
                    weaving3 = 0;
                }
                if (weaving4 == "") {
                    weaving4 = 0;
                }
                firsttotal = ((parseFloat(weaving1) * parseFloat(w1)) + (parseFloat(weaving2) * parseFloat(w2)) + (parseFloat(weaving3) * parseFloat(w3)) + (parseFloat(weaving4) * parseFloat(w4)))
                if (firsttotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val(Math.round(firsttotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val('');
                    }
                }
                //                2 total==============================================================================
                var pattaval = $("#grdfourpointcheck_" + rowid + "_txtpatta_Edit").val();
                var holeval = $("#grdfourpointcheck_" + rowid + "_txthole_Edit").val();
                if (pattaval == "") {
                    pattaval = 0;
                }
                if (holeval == "") {
                    holeval = 0;
                }
                pattaholetotal = ((parseFloat(pattaval) * parseFloat(pattamultiplier)) + (parseFloat(holeval) * parseFloat(holemultiplier)));

                if (pattaholetotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val(Math.round(pattaholetotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val('');
                    }
                }
                //                3 total==============================================================================  
                var defacts1 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts1_Edit").val();
                var defacts2 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts2_Edit").val();
                var defacts3 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts3_Edit").val();
                var defacts4 = $("#grdfourpointcheck_" + rowid + "_txtprintdyeingdefacts4_Edit").val();
                if (defacts1 == "") {
                    defacts1 = 0;
                }
                if (defacts2 == "") {
                    defacts2 = 0;
                }
                if (defacts3 == "") {
                    defacts3 = 0;
                }
                if (defacts4 == "") {
                    defacts4 = 0;
                }
                thridtotal = ((parseFloat(defacts1) * parseFloat(Defectsmultiplier1)) + (parseFloat(defacts2) * parseFloat(Defectsmultiplier2)) + (parseFloat(defacts3) * parseFloat(Defectsmultiplier3)) + (parseFloat(defacts4) * parseFloat(Defectsmultiplier4)))
                if (thridtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val(Math.round(thridtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val('');
                    }
                }

                //                3 Total Points============================================================================== 
                var t1 = $("#grdfourpointcheck_" + rowid + "_txttotal_Edit").val();
                var t2 = $("#grdfourpointcheck_" + rowid + "_txtTotal2_Edit").val();
                var t3 = $("#grdfourpointcheck_" + rowid + "_txtTotal3_Edit").val();

                if (t1 == "") {
                    t1 = 0;
                }
                if (t2 == "") {
                    t2 = 0;
                }
                if (t3 == "") {
                    t3 = 0;
                }

                var subtotal = (parseFloat(t1) + parseFloat(t2) + parseFloat(t3))
                if (subtotal <= 0) {
                    $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Edit").val("");
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Edit").val(Math.round(subtotal));
                    if ($("#grdfourpointcheck_" + rowid + "_txtpointTotal_Edit").val() == "0") {
                        $("#grdfourpointcheck_" + rowid + "_txtpointTotal_Edit").val('');
                    }
                }
                var rollvalue = $("#grdfourpointcheck_" + rowid + "_txtrollno_Edit").val();
                var actuallengh = $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").val();

                var claimedlength = $("#grdfourpointcheck_" + rowid + "_txtclaimedlength_Edit").val();
                if (parseInt(actuallengh.replace(',', '')) < parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallengh.replace(',', '')) > parseInt(claimedlength.replace(',', ''))) {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").parent().attr('style', 'background-color:#fff;color:#000');
                    $("#grdfourpointcheck_" + rowid + "_txtactlenght_Edit").attr('style', 'background-color:#fff;color:#000');
                }
                //new code end
                var with_sw = $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").val();
                if (actuallengh == "0") {
                    actuallengh = 0;
                }
                if (with_sw == "0") {
                    with_sw = 0;
                }

                //new code start
                var with_mw = $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").val();
                var with_lw = $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").val();
                if (with_sw != "" || with_sw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_sw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_sw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_S_Edit").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_mw != "" || with_mw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_mw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_mw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_M_Edit").attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_lw != "" || with_lw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_lw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").parent().attr('style', 'background-color:#FDFD96;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_lw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").parent().attr('style', 'background-color:#fff;color:#000');
                        $("#grdfourpointcheck_" + rowid + "_txtwidth_E_Edit").attr('style', 'background-color:#fff;color:#000');
                    }
                }
                //new code end
                if (parseFloat(actuallengh) > 0 && parseFloat(with_sw) > 0) {
                    finalvalues = (parseFloat(subtotal * 3600) / (with_sw.replace(',', '') * actuallengh.replace(',', '')));

                    if (finalvalues <= 0) {
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Edit").val("");
                    }
                    else {
                        if (finalvalues <= 40) {

                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_Edit").val("1");
                        }
                        else {
                            $("#grdfourpointcheck_" + rowid + "_ddlstatus_Edit").val("2");
                        }
                        $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Edit").val(Math.round(finalvalues));
                        if ($("#grdfourpointcheck_" + rowid + "_txtweapointyard_Edit").val() == "0") {
                            $("#grdfourpointcheck_" + rowid + "_txtweapointyard_Edit").val('');
                        }
                    }
                }
            }
        }
        //new code.

        function ValidateReceivedFourPoint(elem) {
            var actualQty = $("#lblQty").text();
            var ReceivedQty = $("#txtReceivedfourpoint").val();
            if (parseInt(actualQty.replace(/\,/g, '')) < parseInt(ReceivedQty.replace(/\,/g, ''))) {
                alert("Received Quantity can't be greater than Actual Quantity");
                elem.value = elem.defaultValue.toLocaleString();
            }
        }
        //new code

        //new function start
        function CalculateActualLength(elem, type) {

            if (type == 'actualLength') {
                totalActualLength = 0;
            }
            if (type == 'rolls') {
                totalThaans = 0;
            }
            var count = 0;
            $("#grdfourpointcheck tr").each(function (e) {


                var footerid = elem.id.split("_")[1];
                var s = $(this).find("td").eq(2).html().trim();


                var rowid = s.split("_")[1];
                var Controlid = s.split("_")[2];
                var length = $("#grdfourpointcheck tr").length;

                //if (Controlid.slice(0, 3) == "lbl") {
                if ((count + 1) < length) {

                    if (type == 'actualLength') {
                        var lblactuallengh = $("#grdfourpointcheck_" + rowid + "_lblactlenght_item").text();
                        if (lblactuallengh != "" && lblactuallengh != undefined) {
                            totalActualLength = totalActualLength + parseInt(lblactuallengh.replace(',', ''));
                        }
                    }
                    if (type == 'rolls') {
                        var lblrollvalue = $("#grdfourpointcheck_" + rowid + "_lblrollno_item").text();
                        if (lblrollvalue != "" && lblrollvalue != undefined) {
                            totalThaans = totalThaans + parseInt(lblrollvalue.replace(',', ''));
                        }
                    }
                }

                if ((count + 1) == length) {

                    if (type == 'actualLength') {
                        var actuallengh = $("#grdfourpointcheck_" + footerid + "_txtactlenght_Footer").val();
                        if (actuallengh != "" && actuallengh != undefined) {
                            totalActualLength = totalActualLength + parseInt(actuallengh.replace(',', ''));
                        }
                    }
                    if (type == 'rolls') {
                        var rollvalue = $("#grdfourpointcheck_" + footerid + "_txtrollno_Footer").val();
                        if (rollvalue != "" && rollvalue != undefined) {
                            totalThaans = totalThaans + parseInt(rollvalue.replace(',', ''));
                        }
                    }
                }
                count = count + 1;
            });

        }
        //new function end

        function CalculateOnLoad() {

            $("#grdfourpointcheck tr").each(function (e) {
                var w1 = 1;
                var w2 = 2;
                var w3 = 3;
                var w4 = 4;
                var pattamultiplier = 4;
                var holemultiplier = 4;

                var Defectsmultiplier1 = 1;
                var Defectsmultiplier2 = 2;
                var Defectsmultiplier3 = 3;
                var Defectsmultiplier4 = 4;

                var firsttotal = 0;
                var pattaholetotal = 0;
                var thridtotal = 0;
                var s = $(this).find("td").eq(2).html().trim();
                var ctlid = s.split("_")[1];
                var widths = $("#grdfourpointcheck_" + ctlid + "_lblwidth_S_item").text();
                if (widths == "") {
                    widths = 0;
                }

                $("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text();
                $("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text();
                $("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text();
                $("#grdfourpointcheck_" + ctlid + "_lblweapointyard_item").text();

                var weaving1 = $("#grdfourpointcheck_" + ctlid + "_lblwidth_weaving1_item").text();
                var weaving2 = $("#grdfourpointcheck_" + ctlid + "_lblwidth_weaving2_item").text();
                var weaving3 = $("#grdfourpointcheck_" + ctlid + "_lblwidth_weaving3_item").text();
                var weaving4 = $("#grdfourpointcheck_" + ctlid + "_lblwidth_weaving4_item").text();
                if (weaving1 == "") {
                    weaving1 = 0;
                }
                if (weaving2 == "") {
                    weaving2 = 0;
                }
                if (weaving3 == "") {
                    weaving3 = 0;
                }
                if (weaving4 == "") {
                    weaving4 = 0;
                }
                firsttotal = ((parseFloat(weaving1) * parseFloat(w1)) + (parseFloat(weaving2) * parseFloat(w2)) + (parseFloat(weaving3) * parseFloat(w3)) + (parseFloat(weaving4) * parseFloat(w4)))
                if (firsttotal <= 0) {
                    $("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text();
                }
                else {
                    $("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text(Math.round(firsttotal));
                    if ($("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text() == "0") {
                        $("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text('');
                    }
                }
                //2 total==============================================================================
                var pattaval = $("#grdfourpointcheck_" + ctlid + "_lblpatta_item").text();
                var holeval = $("#grdfourpointcheck_" + ctlid + "_lblhole_item").text();
                if (pattaval == "") {
                    pattaval = 0;
                }
                if (holeval == "") {
                    holeval = 0;
                }
                pattaholetotal = ((parseFloat(pattaval) * parseFloat(pattamultiplier)) + (parseFloat(holeval) * parseFloat(holemultiplier)));

                if (pattaholetotal <= 0) {
                    $("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text();
                }
                else {
                    $("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text(Math.round(pattaholetotal));
                    if ($("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text() == "0") {
                        $("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text('');
                    }
                }
                //3 total==============================================================================  
                var defacts1 = $("#grdfourpointcheck_" + ctlid + "_lblprintdyeingdefacts1_item").text();
                var defacts2 = $("#grdfourpointcheck_" + ctlid + "_lblprintdyeingdefacts2_item").text();
                var defacts3 = $("#grdfourpointcheck_" + ctlid + "_lblprintdyeingdefacts3_item").text();
                var defacts4 = $("#grdfourpointcheck_" + ctlid + "_lblprintdyeingdefacts4_item").text();
                if (defacts1 == "") {
                    defacts1 = 0;
                }
                if (defacts2 == "") {
                    defacts2 = 0;
                }
                if (defacts3 == "") {
                    defacts3 = 0;
                }
                if (defacts4 == "") {
                    defacts4 = 0;
                }
                thridtotal = ((parseFloat(defacts1) * parseFloat(Defectsmultiplier1)) + (parseFloat(defacts2) * parseFloat(Defectsmultiplier2)) + (parseFloat(defacts3) * parseFloat(Defectsmultiplier3)) + (parseFloat(defacts4) * parseFloat(Defectsmultiplier4)))
                if (thridtotal <= 0) {
                    $("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text();
                }
                else {
                    $("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text(Math.round(thridtotal));
                    if ($("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text() == "0") {
                        $("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text('');
                    }
                }
                //3 Total Points============================================================================== 
                var t1 = $("#grdfourpointcheck_" + ctlid + "_lbltotal_item").text();
                var t2 = $("#grdfourpointcheck_" + ctlid + "_lblTotal2_item").text();
                var t3 = $("#grdfourpointcheck_" + ctlid + "_lblTotal3_item").text();
                if (t1 == "") {
                    t1 = 0;
                }
                if (t2 == "") {
                    t2 = 0;
                }
                if (t3 == "") {
                    t3 = 0;
                }
                var subtotal = (parseFloat(t1) + parseFloat(t2) + parseFloat(t3))
                if (subtotal <= 0) {
                    $("#grdfourpointcheck_" + ctlid + "_lblpointTotal_item").text();
                }
                else {
                    $("#grdfourpointcheck_" + ctlid + "_lblpointTotal_item").text(Math.round(subtotal));
                    if ($("#grdfourpointcheck_" + ctlid + "_lblpointTotal_item").text() == "0") {
                        $("#grdfourpointcheck_" + ctlid + "_lblpointTotal_item").text('');
                    }
                }
                var rollvalue = $("#grdfourpointcheck_" + ctlid + "_lblrollno_item").text();
                var actuallengh = $("#grdfourpointcheck_" + ctlid + "_lblactlenght_item").text();
                //new code start
                if (actuallengh != "" && actuallengh != undefined) {
                    totalActualLength = totalActualLength + parseInt(actuallengh.replace(',', ''));
                }
                if (rollvalue != "" && rollvalue != undefined) {
                    totalThaans = totalThaans + parseInt(rollvalue.replace(',', ''));
                }
                var claimedQty = $("#grdfourpointcheck_" + ctlid + "_lblclaimedlength_item").text();
                if (parseInt(actuallengh.replace(',', '')) < parseInt(claimedQty.replace(',', ''))) {
                    $("#grdfourpointcheck_" + ctlid + "_lblactlenght_item").parent().attr('style', 'background-color:#FDFD96;color:#000');
                }
                else if (parseInt(actuallengh.replace(',', '')) > parseInt(claimedQty.replace(',', ''))) {
                    $("#grdfourpointcheck_" + ctlid + "_lblactlenght_item").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                }
                else {
                    $("#grdfourpointcheck_" + ctlid + "_lblactlenght_item").parent().attr('style', 'background-color:#fff;color:#000');
                }
                //new code end
                var with_sw = $("#grdfourpointcheck_" + ctlid + "_lblwidth_S_item").text();
                if (actuallengh == "0") {
                    actuallengh = 0;
                }
                if (with_sw == "0") {
                    with_sw = 0;
                }

                //new code start
                var with_mw = $("#grdfourpointcheck_" + ctlid + "_lblwidth_M_item").text();
                var with_lw = $("#grdfourpointcheck_" + ctlid + "_lblwidth_E_item").text();
                if (with_sw != "" || with_sw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_sw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_S_item").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_sw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_S_item").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_S_item").parent().attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_mw != "" || with_mw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_mw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_M_item").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_mw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_M_item").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_M_item").parent().attr('style', 'background-color:#fff;color:#000');
                    }
                }

                if (with_lw != "" || with_lw != undefined) {
                    var cutWidth = $("#hdnCutWidth").val();
                    //var cutWidth = $("#ctl00_cph_main_content_hdnworkingdays").val();
                    if (parseFloat(with_lw.replace(',', '')) < parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_E_item").parent().attr('style', 'background-color:#FDFD96;color:#000');
                    }
                    else if (parseFloat(with_lw.replace(',', '')) > parseFloat(cutWidth.replace(',', ''))) {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_E_item").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                    }
                    else {
                        $("#grdfourpointcheck_" + ctlid + "_lblwidth_E_item").parent().attr('style', 'background-color:#fff;color:#000');
                    }
                }
                //new code end

                if (parseFloat(actuallengh.replace(',', '')) > 0 && parseFloat(with_sw.replace(',', '')) > 0) {
                    finalvalues = (parseFloat(subtotal * 3600) / (with_sw.replace(',', '') * actuallengh.replace(',', '')));
                    if (finalvalues <= 0) {
                        $("#grdfourpointcheck_" + ctlid + "_lblweapointyard_item").text("");
                    }
                    else {
                        $("#grdfourpointcheck_" + ctlid + "_lblweapointyard_item").text(Math.round(finalvalues));
                        if ($("#grdfourpointcheck_" + ctlid + "_lblweapointyard_item").text() == "0") {
                            $("#grdfourpointcheck_" + ctlid + "_lblweapointyard_item").text('');
                        }
                    }
                }

            });
        }

        function ShowCurrentTime() {
            PageMethods.GetCurrentTime(GetCurrentTime(), OnSuccess);
        }

        function OnSuccess(response, userContext, methodName) {
        }

        function validateRecivedQty() {

            //added by Girish on 2023-03-13
            if ($("[id$='btnupdate']").length) {
                alert("Cannot be Save in Edit Mode.");
                $('#ChkFabricQa').removeAttr('checked');
                return false;
            }
            //added by Girish on 2023-03-13

            if ($("#hdnLoginId").val() == "33") {
                alert("You don't have Permission !");
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

        }

        function AddRecord() {
            window.top.close();
        }

        function UpdateQty() {
            var IsValid = true;
            var receiveqty = 0;
            var checkedqty = 0;
            var Passedqty = 0;
            var holdqty = 0;
            var failqty = 0;

            receiveqty = $("#txtReceivedfourpoint").val().replace(',', '');
            checkedqty = $("#txtchecedQtyfourpointchecK").val().replace(',', '');
            Passedqty = $("#txtpassfourpointcheck").val().replace(',', '');
            holdqty = $("#txtholdfourpointcheck").val().replace(',', '');
            failqty = $("#txtfailfourpointcheck").val().replace(',', '');

            StorepassQty = $("#hdnpassqty").val().replace(',', '');

            if (holdqty == "") {
                holdqty = 0;
            }
            if (failqty == "") {
                failqty = 0;
            }
            if (Passedqty == "") {
                Passedqty = 0;
            }
            if (StorepassQty == "") {
                StorepassQty = 0;
            }
            if (StorepassQty > 0) {
                if (parseInt(Passedqty) < parseInt(StorepassQty)) {
                    alert("pass qty cannot be less then :" + StorepassQty);
                    $("#txtpassfourpointcheck").val(StorepassQty);
                }
            }

            if (Passedqty > 0 || failqty > 0 || holdqty > 0) {
                $('#txtholdfourpointcheck').removeAttr("disabled");
                $('#txtfailfourpointcheck').removeAttr("disabled");
                $('#txtpassfourpointcheck').removeAttr("disabled");
            }

            if (parseInt(receiveqty) <= 0) {
                $("#txtchecedQtyfourpointchecK").val("");
                $("#txtpassfourpointcheck").val("");
                $("#txtholdfourpointcheck").val("");
                $("#txtfailfourpointcheck").val("");

                $('#txtchecedQtyfourpointchecK').attr("disabled", "disabled");
                $('#txtpassfourpointcheck').attr("disabled", "disabled");
                $('#txtholdfourpointcheck').attr("disabled", "disabled");
                $('#txtfailfourpointcheck').attr("disabled", "disabled");

                alert("Receive Qty cannot be empty");

                IsValid = false;
            }

            if (IsValid == true) {
                if (parseInt(checkedqty) <= 0) {
                    $("#txtpassfourpointcheck").val("");
                    $("#txtholdfourpointcheck").val("");
                    $("#txtfailfourpointcheck").val("");

                    $('#txtpassfourpointcheck').attr("disabled", "disabled");
                    $('#txtholdfourpointcheck').attr("disabled", "disabled");
                    $('#txtfailfourpointcheck').attr("disabled", "disabled");

                    alert("Checked Qty can't be empty");
                    IsValid = false;
                }
                else {
                    if (parseInt(checkedqty) == parseInt(Passedqty)) {
                        $("#txtholdfourpointcheck").val("");
                        $("#txtfailfourpointcheck").val("");

                        $('#txtholdfourpointcheck').attr("disabled", "disabled");
                        $('#txtfailfourpointcheck').attr("disabled", "disabled");
                        IsValid = false;
                    }
                    else {

                        if (parseInt(Passedqty) < parseInt(checkedqty)) {
                            $('#txtholdfourpointcheck').removeAttr("disabled");
                            $('#txtfailfourpointcheck').removeAttr("disabled");
                            IsValid = true;
                        }
                        else if (parseInt(Passedqty) > parseInt(checkedqty)) {
                            $("#txtpassfourpointcheck").val("");
                            IsValid = false;
                        }
                    }
                }
            }

            if (IsValid == true) {
                if (parseInt(checkedqty) == parseInt(holdqty)) {
                    $("#txtpassfourpointcheck").val("");
                    $("#txtfailfourpointcheck").val("");

                    $('#txtpassfourpointcheck').attr("disabled", "disabled");
                    $('#txtfailfourpointcheck').attr("disabled", "disabled");
                    IsValid = false;
                }
                else {
                    if (parseInt(holdqty) < parseInt(checkedqty)) {
                        $('#txtpassfourpointcheck').removeAttr("disabled");
                        $('#txtfailfourpointcheck').removeAttr("disabled");
                        IsValid = true;
                    }
                    else if (parseInt(holdqty) > parseInt(checkedqty)) {
                        $("#txtholdfourpointcheck").val("");
                        IsValid = false;
                    }
                }
            }

            if (IsValid == true) {
                if (parseInt(checkedqty) == parseInt(failqty)) {
                    $("#txtpassfourpointcheck").val("");
                    $("#txtholdfourpointcheck").val("");

                    $('#txtpassfourpointcheck').attr("disabled", "disabled");
                    $('#txtholdfourpointcheck').attr("disabled", "disabled");
                    IsValid = false;

                }
                else {
                    if (parseInt(failqty) < parseInt(checkedqty)) {
                        $('#txtpassfourpointcheck').removeAttr("disabled");
                        $('#txtholdfourpointcheck').removeAttr("disabled");
                        IsValid = true;
                    }
                    else if (parseInt(failqty) > parseInt(checkedqty)) {
                        $("#txtfailfourpointcheck").val("");
                        IsValid = false;
                    }
                }
            }

        }

        //added by Girish: Start
        function AddActualReceivedQty(id) {
            $('#' + id).val($('#hdnActualReceivedQty').val());
            $('#lblTotalClaimedLength').html($('#hdnActualReceivedQty').val());
            $('#grdfourpointcheck_ctl01_txtactlenght_emptyrow').trigger('change');

        }

        $(document).ready(function () {
            AddActualReceivedQty('grdfourpointcheck_ctl01_txtclaimedlength_emptyrow');
        })
        //added by Girish:End


    </script>
    <form id="form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="debitnote-table" style="max-width: 1234px; margin: 0px auto;">
                <div class="TopHeader">
                    <span class="GreigeShrnk" style="flex-grow: 3; text-align: left; padding-left: 10px;">
                        <span id="GreigeShrnk" runat="server">Greige Shrnk:</span>
                        <asp:Label ID="lblWastage" Font-Bold="true" runat="server"></asp:Label>
                        <span id="ResidShrnk" runat="server">Res. Shrnk: </span>
                        <asp:Label ID="lblShrinkage" Font-Bold="true" runat="server"></asp:Label>
                    </span><span id="FabricInspectionId" runat="server" style="flex-grow: 6; font-size: 15px;">
                        Fabric Inspection System</span>
                    <div class="Greige_Dyed_printed" style="flex-grow: 3; text-align: right;">
                        <asp:Label ID="lblStage1" runat="server" Text="" CssClass="Stage1"></asp:Label>
                        <asp:Label ID="lblStage2" runat="server" Text="" CssClass="Stage2"></asp:Label>
                        <asp:Label ID="lblStage3" runat="server" Text="" CssClass="Stage3"></asp:Label>
                        <asp:Label ID="lblStage4" runat="server" Text="" CssClass="Stage4"></asp:Label>
                    </div>
                </div>
                <div class="bottom_serialno">
                    <span style="margin-right: 5px;">SerialNumber:<asp:Label ID="lblSerialNumber" runat="server"></asp:Label></span>
                </div>
                <asp:HiddenField ID="hdnLabId" Value="-1" runat="server" />
                <asp:HiddenField ID="hdnDesignationId" Value="-1" runat="server" />

                <asp:HiddenField ID="hdnLabManager" Value="-1" runat="server" />
                <asp:HiddenField ID="hdnGM_Manager" Value="-1" runat="server" />
                <asp:HiddenField ID="hdnQAManager" Value="-1" runat="server" />
                <asp:HiddenField ID="hdnLoginId" Value="0" runat="server" />
                <asp:HiddenField ID="hdnUserid" runat="server" />
                <asp:HiddenField ID="hdnFinalDecissionPass" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnDecissionCommercialpass" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnFinalDecissionFail" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnIntPass" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnIntFail" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnExtPass" runat="server" Value="-1" />
                <asp:HiddenField ID="hdnExtFail" runat="server" Value="-1" />
                <table class="AddClass_Table TopTable" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-bottom: 0px solid #999999; margin-bottom: 5px"
                    cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th>
                                Fabric
                            </th>
                            <td style="border-top-color: #999">
                                <%--<span class="ColorBlue">14x14 Cotton Twill</span><span class="ColorGary"> (325) 14x14/90x78
                        54"</span>--%>
                                <asp:Label ID="lblfab" runat="server" class="ColorBlue"></asp:Label>
                                <asp:HiddenField ID="hdnCutWidth" runat="server" Value="0" />
                            </td>
                            <th>
                                Supplier Name
                            </th>
                            <td style="border-top-color: #999;">
                                <%--<span>Baweja Texfab Pvt. Ltd.</span>--%>
                                <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                            </td>
                            <td rowspan="5" style="border-top-color: #999; border-bottom-color: #999">
                                <table class="innertable">
                                    <tr>
                                        <td colspan="2">
                                            Length of defect in fabric, either length or width point allotted
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Up to 3 inches
                                        </td>
                                        <td>
                                            1
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Over to 3 inches up to 6 inches
                                        </td>
                                        <td>
                                            2
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Over to 6 inches up to 9 inches
                                        </td>
                                        <td>
                                            3
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Over 9 inches
                                        </td>
                                        <td>
                                            4
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hole
                                        </td>
                                        <td>
                                            4
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Patta
                                        </td>
                                        <td>
                                            4
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="width: 96px; display: inline-block;">Points per 100<br>
                                                square yards </span><span style="position: relative; top: -6px; right: 10px">=
                                            </span><span style="display: inline-block;"><span>Total points scored in the roll x
                                                3600<br>
                                                <div style="border-top: 1px solid #ccc; margin: 1px 0px">
                                                    Fabric width in inches x Total mtrs inspected</div>
                                            </span></span>
                                        </td>
                                        <td style="width: 24px;">
                                            4
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Acceptance criteria 40 points per 100 sq. yards
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Color/Print
                            </th>
                            <td>
                                <%--<span class="ColorBlackBold">4996 brush stroke-4996</span>--%>
                                <asp:Label ID="lblPrintColor" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>
                            </td>
                            <th>
                                PO Number (SRV No.) Party Challan No
                            </th>
                            <td>
                                <%--<span class="ColorBlackBold">BTPLF1 (F- 59)</span>--%>
                                <asp:Label ID="lblPONo" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>
                                &nbsp;
                                <div class=" tooltip" id="for_hide_tooltip">
                                    (<asp:Label ID="SRVNo" runat="server" ForeColor="#000" Font-Bold="true" ToolTip='<%# Eval("Remarks") %>'></asp:Label>)
                                    <span class=" tooltiptext">
                                        <asp:Label ID="lblsrvremarks" runat="server" ForeColor="#000" Font-Bold="true" Text='<%# Eval("Remarks") %>'
                                            Style="color: White;"></asp:Label>
                                    </span>
                                </div>
                                &nbsp;
                                <asp:Label ID="PartyChallanNo" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="3">
                                Checker Name<span class="ColorRedStrick">*</span>
                            </th>
                            <td>
                                <%--<input type="text" value="Srgrg" class="GrdtxtControl">--%>
                                <asp:TextBox ID="txtcheckname1" runat="server" onblur="ValidateCheckerName();" class="formcontrol"></asp:TextBox>
                            </td>
                            <th>
                                Date
                                <br />
                                <br />
                                OverAll PoQty
                            </th>
                            <td>
                                <%-- <input type="text" value="19 Jan 21 (Tue)" style="width: 80px;" class="GrdtxtControl">--%>
                                <asp:TextBox ID="txtdates" CssClass="th datesfileds shoedatepicker" onkeypress="return false;"
                                    runat="server" class="formcontrol" ReadOnly="true" Height="15" Style="margin-bottom: 5px;"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblReceivedQty" runat="server" class="formcontrol"></asp:Label>
                                <span id="unitName" runat="server"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<input type="text" value="" class="GrdtxtControl">--%>
                                <asp:TextBox ID="txtcheckname2" runat="server" class="formcontrol"></asp:TextBox>
                            </td>
                            <th>
                                SRV Quantity
                            </th>
                            <td>
                                <%--<span>50</span> <span class="ColorGaryBold">Meter</span>--%>
                                <asp:Label ID="lblQty" runat="server"></asp:Label>
                                <asp:HiddenField runat="server" Value="" ID="hdnActualReceivedQty" />
                                <%--added by Girish To Show ClaimedQty By Default--%>
                                <asp:Label ID="lblunitname" Font-Bold="true" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom-color: #999">
                                <%--<input type="text" value="" class="GrdtxtControl">--%>
                                <asp:TextBox ID="txtcheckname3" runat="server" class="formcontrol"></asp:TextBox>
                            </td>
                            <th>
                                Allocated Unit
                            </th>
                            <td style="border-bottom-color: #999">
                                <%--<select>
                        <option>C 45-46</option>
                        <option>C 47</option>
                        <option>D 69</option>
                        <option>C 52</option>
                    </select>--%>
                                <asp:DropDownList ID="ddlunitname" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <!-- <tr>
                        
                        <td class="borderbottom "  colspan="8"><input type="text" class="formcontrol"></td>
                    </tr>
                    <tr>
                         
                        <td class="borderbottom "  colspan="8"><input type="text" class="formcontrol"></td>
                    </tr> -->
                    </tbody>
                </table>
                <table class="AddClass_Table" style="max-width: 1100px; display: none;">
                    <tr>
                        <%--<th class="bottomborder1 textcenter headerbacground borderlft" style="min-width: 25px">
                                    Sr. No.
                                </th>--%>
                        <th class="borderbottom textcenter headerbacground">
                            Roll No.
                        </th>
                        <th class=" borderbottom textcenter headerbacground">
                            Dye Lot
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Claimed Length
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Act. Length
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Chkd
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Pass
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Hold
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Fail
                        </th>
                        <th class="borderbottom textcenter headerbacground" colspan="3">
                            Width
                        </th>
                        <th class="borderbottom textcenter headerbacground" colspan="4">
                            Weaving
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Total
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Patta
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Hole
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Total
                        </th>
                        <th class="borderbottom textcenter headerbacground" colspan="4">
                            Printed &amp; Dyeing Defects
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Total
                        </th>
                        <th class="borderbottom textcenter headerbacground">
                            Total Points
                        </th>
                        <th class="borderbottom textcenter headerbacground ">
                            Weak Points per 100 sq Yards
                        </th>
                        <th class="borderbottom textcenter headerbacground ">
                            Status
                        </th>
                        <th class="borderbottom headerbacground ">
                            Action
                        </th>
                    </tr>
                    <tr>
                        <th class="bottomborder1 headerbacground borderlft" style="min-width: 35px">
                        </th>
                        <th class="borderbottom headerbacground" style="min-width: 35px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 43px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 39px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 39px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 39px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 39px">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 39px">
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301" style="min-width: 30px">
                            Start
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301" style="min-width: 35px">
                            Middle
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301" style="min-width: 30px">
                            End
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            1
                        </th>
                        <th class="borderbottom headerbacground textcenter  widtd_301">
                            2
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            3
                        </th>
                        <th class="borderbottom textcenter headerbacground widtd_301">
                            4
                        </th>
                        <th class="borderbottom headerbacground widtd_301">
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            4
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            4
                        </th>
                        <th class="borderbottom headerbacground widtd_301">
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            1
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            2
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            3
                        </th>
                        <th class="borderbottom headerbacground textcenter widtd_301">
                            4
                        </th>
                        <th class="borderbottom headerbacground widtd_301">
                        </th>
                        <th class="borderbottom headerbacground widtd_301">
                        </th>
                        <th class="borderbottom headerbacground widtd_301">
                        </th>
                        <th class="borderbottom headerbacground " style="min-width: 47px;">
                        </th>
                        <th class="borderbottom headerbacground" style="min-width: 52px;">
                        </th>
                    </tr>
                </table>
                <asp:GridView ID="grdfourpointcheck" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                    HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCancelingEdit="grdfourpointcheck_RowCancelingEdit"
                    OnRowCommand="grdfourpointcheck_RowCommand" OnRowDataBound="grdfourpointcheck_RowDataBound"
                    OnRowDeleting="grdfourpointcheck_RowDeleting" OnRowEditing="grdfourpointcheck_RowEditing"
                    OnRowUpdating="grdfourpointcheck_RowUpdating" ShowFooter="false" ShowHeader="false"
                    Width="1234px" Style="border-top: 0px; border-bottom: 0px;" OnRowCreated="grdfourpointcheck_RowCreated">
                    <FooterStyle CssClass="FooterRowTd" />
                    <%--<EmptyDataRowStyle CssClass="EmptyRowtd" />--%>
                    <Columns>
                        <%--                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="Sr_no border_left_color Sr_width" />
                                    <FooterStyle CssClass="border_left_color" />
                                </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnrowid" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                                <asp:HiddenField ID="hdnSRV_item" runat="server" />
                                <asp:HiddenField ID="hdnSupplierPO_item" runat="server" />
                                <asp:Label ID="lblrollno_item" runat="server" Text='<%# (Eval("RollNumber") == DBNull.Value  || (Eval("RollNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("RollNumber").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="roll_no_30" HorizontalAlign="Center" />
                            <FooterStyle CssClass="roll_no_30" HorizontalAlign="Center" />
                            <FooterTemplate>
                                <asp:HiddenField ID="hdmrowidauto_foter" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                                <asp:HiddenField ID="hdnSRV_Footer" runat="server" />
                                <asp:HiddenField ID="hdnSupplierPO_Footer" runat="server" />
                                <asp:TextBox ID="txtrollno_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    onchange="Calculatetotals(this,'edit');CalculateActualLength(this,'rolls')" CssClass="noonly"
                                    MaxLength="7" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txtrollno_Footer" runat="server" Display="None"
                                    ValidationGroup="gfoter" ControlToValidate="txtrollno_Footer" ErrorMessage="Enter roll No. value"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdmrowidauto" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                                <asp:HiddenField ID="hdnSRV_item" runat="server" />
                                <asp:HiddenField ID="hdnSupplierPO_item" runat="server" />
                                <asp:TextBox ID="txtrollno_Edit" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                    runat="server" onkeypress="return isNumberKey(event)" MaxLength="7" onchange="checkzero(this)"
                                    Text='<%# (Eval("RollNumber") == DBNull.Value  || (Eval("RollNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("RollNumber").ToString().Trim() %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txtrollno_Edit" runat="server" Display="None"
                                    ValidationGroup="gedit" ControlToValidate="txtrollno_Edit" ErrorMessage="Enter roll no. value"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbldeilot_item" runat="server" Text='<%# (Eval("DeitLotNumber") == DBNull.Value  || (Eval("DeitLotNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("DeitLotNumber").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="deilot_name" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtdeilot_Edit" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                    runat="server" CssClass="noonly" onkeypress="return isNumberKey(event)" MaxLength="7"
                                    onchange="checkzero(this)" Text='<%# (Eval("DeitLotNumber") == DBNull.Value  || (Eval("DeitLotNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("DeitLotNumber").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtdeilot_Footer" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                    runat="server" CssClass="noonly" onkeypress="return isNumberKey(event)" MaxLength="7"
                                    onchange="checkzero(this)"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--new code start 05 Jan 2021--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblclaimedlength_item" runat="server" Text='<%# (Eval("ClaimedQty") == DBNull.Value  || (Eval("ClaimedQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ClaimedQty").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_name1" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtclaimedlength_Edit" runat="server" onkeydown="if (event.keyCode == 9) return true; else return false;"
                                    onclick="AddActualReceivedQty(this.id);" MaxLength="7" onchange="Calculatetotals(this,'edit')"
                                    Text=''></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtclaimedlength_Footer" onchange="Calculatetotals(this,'foter')"
                                    onclick="AddActualReceivedQty(this.id);" runat="server" onkeydown="if (event.keyCode == 9) return true; else return false;"
                                    MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--new code end 05 Jan 2021--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblactlenght_item" runat="server" Text='<%# (Eval("ActualLength") == DBNull.Value  || (Eval("ActualLength").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ActualLength").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_Len" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtactlenght_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    onclick="RemoveComma(this);" MaxLength="7" onchange="Calculatetotals(this,'edit')"
                                    Text='<%# (Eval("ActualLength") == DBNull.Value  || (Eval("ActualLength").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ActualLength").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtactlenght_Footer" onchange="Calculatetotals(this,'foter');CalculateActualLength(this,'actualLength');"
                                    onclick="RemoveComma(this);" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--new code start 02-02-2021 --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblchkd_item" runat="server" Text='<%# (Eval("CheckedQty") == DBNull.Value  || (Eval("CheckedQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("CheckedQty").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_Len" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtchkd_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    onclick="RemoveComma(this);" onblur="CheckCheckedQuantity(this,'_Edit','1');"
                                    MaxLength="7" Text='<%# (Eval("CheckedQty") == DBNull.Value  || (Eval("CheckedQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("CheckedQty").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtchkd_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    onclick="RemoveComma(this);" onblur="CheckCheckedQuantity(this,'_Footer','1');"
                                    MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblpass_item" Style="color: Green; caret-color: black;" runat="server"
                                    Text='<%# (Eval("PassQty") == DBNull.Value  || (Eval("PassQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PassQty").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_Len" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtpass_Edit" Style="color: Green; caret-color: black;" runat="server"
                                    onclick="RemoveComma(this);" onkeypress="return isNumberKey(event)" onblur="CheckPassFailValidation(this,'_Edit','1')"
                                    MaxLength="7" Text='<%# (Eval("PassQty") == DBNull.Value  || (Eval("PassQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PassQty").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtpass_Footer" Style="color: Green; caret-color: black;" runat="server"
                                    onkeypress="return isNumberKey(event)" onblur="CheckPassFailValidation(this,'_Footer','1')"
                                    onclick="RemoveComma(this);" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblhold_item" runat="server" Text='<%# (Eval("HoldQty") == DBNull.Value  || (Eval("HoldQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("HoldQty").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_Len" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txthold_Edit" runat="server" onclick="RemoveComma(this);" onkeypress="return isNumberKey(event)"
                                    onblur="CheckPassFailValidation(this,'_Edit','1')" MaxLength="7" Text='<%# (Eval("HoldQty") == DBNull.Value  || (Eval("HoldQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("HoldQty").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txthold_Footer" runat="server" onclick="RemoveComma(this);" onkeypress="return isNumberKey(event)"
                                    onblur="CheckPassFailValidation(this,'_Footer','1')" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblfail_item" Style="color: Red; caret-color: black;" runat="server"
                                    Text='<%# (Eval("FailQty") == DBNull.Value  || (Eval("FailQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("FailQty").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="actlent_Len" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtfail_Edit" Style="color: Red; caret-color: black;" runat="server"
                                    onclick="RemoveComma(this);" onkeypress="return isNumberKey(event)" onblur="CheckPassFailValidation(this,'_Edit','1')"
                                    MaxLength="7" Text='<%# (Eval("FailQty") == DBNull.Value  || (Eval("FailQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("FailQty").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtfail_Footer" Style="color: Red; caret-color: black;" runat="server"
                                    onclick="RemoveComma(this);" onkeypress="return isNumberKey(event)" onblur="CheckPassFailValidation(this,'_Footer','1')"
                                    MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--new code end 02-02-2021--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_S_item" runat="server" Text='<%# (Eval("Width_S") == DBNull.Value  || (Eval("Width_S").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_S").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_StartMeEnd" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_S_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_S") == DBNull.Value  || (Eval("Width_S").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_S").ToString().Trim() %>'></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfv_txtdeilot_Edit" runat="server" Display="None"
                                ValidationGroup="gedit" ControlToValidate="txtwidth_S_Edit" ErrorMessage="Enter Width (s)"></asp:RequiredFieldValidator>--%>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_S_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfv_txtdeilot_Footer" runat="server" Display="None"
                                ValidationGroup="gfoter" ControlToValidate="txtwidth_S_Footer" ErrorMessage="Enter Width (s) value"></asp:RequiredFieldValidator>--%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_M_item" runat="server" Text='<%# (Eval("Width_M") == DBNull.Value  || (Eval("Width_M").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_M").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_StartMeEnd" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_M_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_M") == DBNull.Value  || (Eval("Width_M").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_M").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_M_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="checkzero(this);Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_E_item" runat="server" Text='<%# (Eval("Width_E") == DBNull.Value  || (Eval("Width_E").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_E").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_StartMeEnd" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_E_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_E") == DBNull.Value  || (Eval("Width_E").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_E").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_E_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="checkzero(this);Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_weaving1_item" runat="server" Text='<%# (Eval("Weaving_1") == DBNull.Value  || (Eval("Weaving_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_1").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_weaving1_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_1") == DBNull.Value  || (Eval("Weaving_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_1").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_weaving1_Footer" runat="server" onchange="Calculatetotals(this,'foter')"
                                    onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_weaving2_item" runat="server" Text='<%# (Eval("Weaving_2") == DBNull.Value  || (Eval("Weaving_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_2").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_weaving2_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_2") == DBNull.Value  || (Eval("Weaving_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_2").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_weaving2_Footer" onchange="Calculatetotals(this,'foter')"
                                    runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_weaving3_item" runat="server" Text='<%# (Eval("Weaving_3") == DBNull.Value  || (Eval("Weaving_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_3").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_weaving3_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_3") == DBNull.Value  || (Eval("Weaving_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_3").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_weaving3_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblwidth_weaving4_item" runat="server" Text='<%# (Eval("Weaving_4") == DBNull.Value  || (Eval("Weaving_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_4").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtwidth_weaving4_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_4") == DBNull.Value  || (Eval("Weaving_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_4").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtwidth_weaving4_Footer" onchange="Calculatetotals(this,'foter')"
                                    runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbltotal_item" Text='<%# (Eval("total1") == DBNull.Value  || (Eval("total1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total1").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txttotal_Edit" Enabled="false" runat="server" Text='<%# (Eval("total1") == DBNull.Value  || (Eval("total1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total1").ToString().Trim() %>'
                                    Style="background: gainsboro;" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txttotal_Footer" Style="background: gainsboro;" Enabled="false"
                                    runat="server" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblpatta_item" runat="server" Text='<%# (Eval("Patta") == DBNull.Value  || (Eval("Patta").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Patta").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtpatta_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Patta") == DBNull.Value  || (Eval("Patta").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Patta").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtpatta_Footer" runat="server" onchange="Calculatetotals(this,'foter')"
                                    onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblhole_item" runat="server" Text='<%# (Eval("Hole") == DBNull.Value  || (Eval("Hole").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Hole").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txthole_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Hole") == DBNull.Value  || (Eval("Hole").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Hole").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txthole_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblTotal2_item" CssClass="datesfileds" Text='<%# (Eval("total2") == DBNull.Value  || (Eval("total2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total2").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTotal2_Edit" Enabled="false" Text='<%# (Eval("total2") == DBNull.Value  || (Eval("total2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total2").ToString().Trim() %>'
                                    runat="server" Style="background: gainsboro;" CssClass="noonly datesfileds" MaxLength="3"
                                    onkeypress="return false;"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTotal2_Footer" Enabled="false" Style="background: gainsboro;"
                                    runat="server" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblprintdyeingdefacts1_item" runat="server" Text='<%# (Eval("PrintedDefectes_1") == DBNull.Value  || (Eval("PrintedDefectes_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_1").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts1_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_1") == DBNull.Value  || (Eval("PrintedDefectes_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_1").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts1_Footer" onchange="Calculatetotals(this,'foter')"
                                    runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblprintdyeingdefacts2_item" runat="server" Text='<%# (Eval("PrintedDefectes_2") == DBNull.Value  || (Eval("PrintedDefectes_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_2").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts2_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_2") == DBNull.Value  || (Eval("PrintedDefectes_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_2").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts2_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblprintdyeingdefacts3_item" runat="server" Text='<%# (Eval("PrintedDefectes_3") == DBNull.Value  || (Eval("PrintedDefectes_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_3").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts3_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_3") == DBNull.Value  || (Eval("PrintedDefectes_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_3").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts3_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblprintdyeingdefacts4_item" runat="server" onkeypress="checkzero(this)"
                                    Text='<%# (Eval("PrintedDefectes_4") == DBNull.Value  || (Eval("PrintedDefectes_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_4").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts4_Edit" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_4") == DBNull.Value  || (Eval("PrintedDefectes_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_4").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtprintdyeingdefacts4_Footer" runat="server" onkeypress="return isNumberKey(event)"
                                    MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblTotal3_item" Text='<%# (Eval("total3") == DBNull.Value  || (Eval("total3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total3").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTotal3_Edit" Text='<%# (Eval("total3") == DBNull.Value  || (Eval("total3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total3").ToString().Trim() %>'
                                    Style="background: gainsboro;" runat="server" CssClass="noonly" MaxLength="3"
                                    onkeypress="return false;"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTotal3_Footer" Style="background: gainsboro;" runat="server"
                                    CssClass="noonly datesfileds" Enabled="false" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblpointTotal_item" CssClass="datesfileds" Text='<%# (Eval("TotalPoints") == DBNull.Value  || (Eval("TotalPoints").ToString().Trim() == string.Empty)) ? string.Empty : Eval("TotalPoints").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="widtd_30" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtpointTotal_Edit" Enabled="false" Text='<%# (Eval("TotalPoints") == DBNull.Value  || (Eval("TotalPoints").ToString().Trim() == string.Empty)) ? string.Empty : Eval("TotalPoints").ToString().Trim() %>'
                                    Style="background: gainsboro;" runat="server" CssClass="noonly" MaxLength="3"
                                    onkeypress="return false;"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtpointTotal_Footer" Style="background: gainsboro;" runat="server"
                                    CssClass="noonly datesfileds" Enabled="false" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblweapointyard_item" runat="server" Text='<%# (Eval("WeaPointsPerSquirdYards") == DBNull.Value  || (Eval("WeaPointsPerSquirdYards").ToString().Trim() == string.Empty)) ? string.Empty : Eval("WeaPointsPerSquirdYards").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="totalpoint_63" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:TextBox ID="txtweapointyard_Edit" Enabled="false" Style="background: gainsboro;"
                                    runat="server" onkeypress="return false;" MaxLength="7" onchange="Calculatetotals(this,'edit')"
                                    Text='<%# (Eval("WeaPointsPerSquirdYards") == DBNull.Value  || (Eval("WeaPointsPerSquirdYards").ToString().Trim() == string.Empty)) ? string.Empty : Eval("WeaPointsPerSquirdYards").ToString().Trim() %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtweapointyard_Footer" Enabled="false" Style="background: gainsboro;"
                                    onkeypress="return false;" runat="server" MaxLength="7" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblstatus_item" runat="server" Text='<%# (Eval("Statusstring") == DBNull.Value  || (Eval("Statusstring").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Statusstring").ToString().Trim() %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="Status_63" />
                            <FooterStyle HorizontalAlign="Center" />
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlstatus_Edit" runat="server" SelectedValue='<%# Eval("Status") %>'>
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Pass</asp:ListItem>
                                    <asp:ListItem Value="2">Fail</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlstatus_Footer" Width="52px" runat="server">
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Pass</asp:ListItem>
                                    <asp:ListItem Value="2">Fail</asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" Text="../../images/edit2.png" alt="edit" CommandName="Edit"
                                    runat="server"><img src="../../images/edit2.png" alt="edit"  /></asp:LinkButton>
                                <asp:Button ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="black"
                                    Style="border: none; position: absolute; left: 18px; top: 2px; opacity: 0" OnClientClick="return confirm('Are you sure you want to delete?')"
                                    ToolTip="Delete" Visible="false" Width="20px" />
                                <img src="../../images/del-butt.png" style="display: none;" />
                            </ItemTemplate>
                            <ItemStyle CssClass="Actiont_63 border_right_color positionclass" />
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" ValidationGroup="gedit" CommandName="Update"
                                    Text="Update"><img style="width: 11px;height: 12px;" src="../../App_Themes/ikandi/images/green_tick.gif" /></asp:LinkButton>
                                <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"><img src="../../images/Cancel1.jpg" style="position: relative;top:2px;width:17px" /></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center;" class="iSlnkHide">
                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" Text="Add" ValidationGroup="gfoter"
                                        CssClass="addbnn" CommandName="Insert" runat="server"><img src="../../images/add-butt.png" alt="edit" /> </asp:LinkButton>
                                </div>
                            </FooterTemplate>
                            <FooterStyle Width="40px" CssClass="border_right_color Actiont_63" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table border="0" class="EmptyTable" cellpadding="0" cellspacing="0" width="100%"
                            style="border-top: 0px; border-bottom: 0px; border-color: #999; border-left: 0;
                            border-right: 0;">
                            <tr align="center" style="font-family: Arial;">
                                <td class="Header1">
                                    Roll<br />
                                    No.
                                </td>
                                <td class="Header1">
                                    Dye Lot
                                </td>
                                <td class="Header1">
                                    Claimed Length
                                </td>
                                <td class="Header1">
                                    Act. Length
                                </td>
                                <td class="Header1">
                                    Chkd
                                </td>
                                <td class="Header1">
                                    Pass
                                </td>
                                <td class="Header1">
                                    Hold
                                </td>
                                <td class="Header1">
                                    Fail
                                </td>
                                <td class="Header1" colspan="3">
                                    Width
                                </td>
                                <td class="Header1" colspan="4">
                                    Weaving
                                </td>
                                <td class="Header1">
                                    Total
                                </td>
                                <td class="Header1">
                                    Patta
                                </td>
                                <td class="Header1">
                                    Hole
                                </td>
                                <td class="Header1">
                                    Total
                                </td>
                                <td class="Header1" colspan="4">
                                    Printed &amp; Dyeing Defects
                                </td>
                                <td class="Header1">
                                    Total
                                </td>
                                <td class="Header1">
                                    Total Points
                                </td>
                                <td class="Header1">
                                    Weak Points per 100 sq Yards
                                </td>
                                <td class="Header1">
                                    Status
                                </td>
                                <td class="Header1" style="border-right: 0px !important;">
                                    Action
                                </td>
                            </tr>
                            <tr align="center" style="font-family: Arial;">
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                    Start
                                </td>
                                <td class="Header2">
                                    Middle
                                </td>
                                <td class="Header2">
                                    End
                                </td>
                                <td class="Header2">
                                    1
                                </td>
                                <td class="Header2">
                                    2
                                </td>
                                <td class="Header2">
                                    3
                                </td>
                                <td class="Header2">
                                    4
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                    4
                                </td>
                                <td class="Header2">
                                    4
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                    1
                                </td>
                                <td class="Header2">
                                    2
                                </td>
                                <td class="Header2">
                                    3
                                </td>
                                <td class="Header2">
                                    4
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2">
                                </td>
                                <td class="Header2" style="border-right: 0px !important;">
                                </td>
                            </tr>
                            <tr style="text-align: center;">
                                <%--<td style="min-width: 31px; border-top: 0px; border-bottom: 0px; border-left: 0px"
                                class="border_left_coor">
                            </td>--%>
                                <td style="border-top: 0px;">
                                    <asp:HiddenField ID="hdmrowidauto_empty" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                                    <asp:TextBox ID="txtrollno_emptyrow" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtrollno_emptyrow" runat="server" Display="None"
                                        ValidationGroup="gempty" ControlToValidate="txtrollno_emptyrow" ErrorMessage="Enter roll No. value"></asp:RequiredFieldValidator>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtdeilot_emptyrow" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7" onchange="checkzero(this)"></asp:TextBox>
                                </td>
                                <%--new code start--%>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtclaimedlength_emptyrow" runat="server" onkeydown="if (event.keyCode == 9) return true; else return false;"
                                        onclick="AddActualReceivedQty(this.id);" MaxLength="7" onchange="Calculatetotals(this,'empty')"></asp:TextBox>
                                </td>
                                <%--new code end--%>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtactlenght_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        onclick="RemoveComma(this);" MaxLength="7" onchange="Calculatetotals(this,'empty')"></asp:TextBox>
                                </td>
                                <%--new code start 02-02-2021--%>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtcheckedlength_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        onclick="RemoveComma(this);" onblur="CheckCheckedQuantity(this,'length_emptyrow','2');"
                                        MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtpasslength_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        onclick="RemoveComma(this);" onblur="CheckPassFailValidation(this,'length_emptyrow','2')"
                                        MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtholdlength_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        onclick="RemoveComma(this);" onblur="CheckPassFailValidation(this,'length_emptyrow','2')"
                                        MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtfaillength_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        onclick="RemoveComma(this);" onblur="CheckPassFailValidation(this,'length_emptyrow','2')"
                                        MaxLength="7"></asp:TextBox>
                                </td>
                                <%--new code end 02-02-2021--%>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtwithd_s_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                        onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtdeilot_emptyrow" runat="server" Display="None"
                                        ValidationGroup="gempty" ControlToValidate="txtwithd_s_emptyrow" ErrorMessage="Enter width (s) value"></asp:RequiredFieldValidator>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtwithd_M_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        MaxLength="7" onchange="checkzero(this);Calculatetotals(this,'empty')"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtwithd_E_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                        MaxLength="7" onchange="checkzero(this);Calculatetotals(this,'empty')"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtweaving_1_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtweaving_2_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtweaving_3_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px">
                                    <asp:TextBox ID="txtweaving_4_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txttotal1_emptyrow" Style="background: gainsboro;" runat="server"
                                        CssClass="datesfileds" Enabled="false" MaxLength="7" onchange="checkzero(this)"
                                        onkeypress="return false;"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtpatta_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                        onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txthole_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                        onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txttotal2_emptyrow" Style="background: gainsboro;" runat="server"
                                        CssClass="datesfileds" Enabled="false" MaxLength="7" onchange="checkzero(this)"
                                        onkeypress="return false;"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtprintdyeingdefacts1_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtprintdyeingdefacts2_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtprintdyeingdefacts3_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtprintdyeingdefacts4_emptyrow" onchange="Calculatetotals(this,'empty')"
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txttotal3_emptyrow" Style="background: gainsboro;" runat="server"
                                        CssClass="datesfileds" Enabled="false" onkeypress="return false;"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txttotalpoint_emptyrow" Enabled="false" Style="background: gainsboro;"
                                        CssClass="datesfileds" runat="server" onkeypress="return false;"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px;">
                                    <asp:TextBox ID="txtweapointyard_emptyrow" Style="background: gainsboro;" onkeypress="return false;"
                                        MaxLength="7" onchange="checkzero(this)" runat="server"></asp:TextBox>
                                </td>
                                <td style="border-top: 0px; min-width: 50px">
                                    <asp:DropDownList ID="ddlstatus_emptyrow" Width="50px" runat="server">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Pass</asp:ListItem>
                                        <asp:ListItem Value="2">Fail</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-top: 0px; border-right: 0px" class="border_right_coor">
                                    <asp:LinkButton ID="addbutton" runat="server" CommandName="addnew" CssClass="iSlnkHide addbnn"
                                        ValidationGroup="gempty" ForeColor="black" ToolTip="Insert New Record"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="gempty"
                            ShowMessageBox="True" ShowSummary="False" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="gedit"
                            ShowMessageBox="True" ShowSummary="False" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="gfoter"
                            ShowMessageBox="True" ShowSummary="False" />
                    </EmptyDataTemplate>
                </asp:GridView>
                <table id="totalAccInspection" runat="server" class="TotalTable" visible="false">
                    <tr>
                        <td style='border-left-color: #999; min-width: 40px;'>
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
                        <td style='border-left-color: #999; width: 65px; border-right: 0px;'>
                            <asp:Label ID="lblTotalwidth_S_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_M_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_E_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_weaving1_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_weaving2_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_weaving3_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalwidth_weaving4_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotaltotal_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalpatta_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalhole_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalTotal2_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalprintdyeingdefacts1_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalprintdyeingdefacts2_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalprintdyeingdefacts3_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalprintdyeingdefacts4_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalTotal3_item" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalpointTotal_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalweapointyard_item" Style="text-align: center;" runat="server"
                                Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; min-width: 50px; border-right: 0px; border-left: 0px;'>
                            <asp:Label ID="lblTotalStatus" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                        <td style='border-left-color: #999; border-right-color: #999 !important; min-width: 38px;
                            border-left: 0px;'>
                            <asp:Label ID="lblAction" Style="text-align: center;" runat="server" Text=''></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; margin-top: 5px;">
                    <div style="width: 55%; float: left">
                        <span style="font-size: 13px;">Comments</span>
                        <asp:TextBox ID="txtComments" autocomplete="off" runat="server" Height="20px" TextMode="MultiLine"
                            Width="97%"></asp:TextBox>
                        <div id="dvHistory" runat="server">
                        </div>
                        <div class="LavContainer ">
                            <table>
                                <tr>
                                    <th style='width: 40px; text-align: center;'>
                                        Report
                                    </th>
                                    <th style='width: 40px; text-align: center;'>
                                        Lab Specimen Count
                                    </th>
                                    <th style="width: 123px; text-align: center;">
                                        Sent To Lab (Date & Time)
                                    </th>
                                    <th style='width: 110px; text-align: center;'>
                                        Received in Lab (Date & Time)
                                    </th>
                                    <th style='width: 50px; text-align: center;'>
                                        Lab Report
                                    </th>
                                    <th style='width: 50px; text-align: center;'>
                                        Lab Decision:
                                    </th>
                                    <th style='width: 108px; text-align: center;'>
                                        Final Decision
                                    </th>
                                </tr>
                                <tr id="InternalRowId" runat="server">
                                    <td style="text-align: center; background: #f2f2f2; border-left-color: #999; border-right-color: #999">
                                        <span>Internal</span>
                                    </td>
                                    <td class="BalckgroundColor" style="text-align: center;">
                                        <asp:TextBox ID="txtInternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                            autocomplete="off" runat="server" onkeypress="javascript:return isNumberKey(event)"
                                            onchange="InternalSentoLabValid()"></asp:TextBox>
                                    </td>
                                    <td style='text-align: left;' class="BalckgroundColor">
                                        <asp:CheckBox ID="chkInternalSentToLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblInternalSentToLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnInternalSentToLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkInternalSentToLab" runat="server" Value="0" />
                                    </td>
                                    <td style='text-align: left;'>
                                        <asp:CheckBox ID="chkInternalReceivedInLab" Checked="false" runat="server" onchange="InternalReceiveInLabValidation()" />
                                        <asp:Label ID="lblInternalReceivedIndLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnInternalReceivedInLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkInternalReceivedInLab" runat="server" Value="0" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnInternalIsFile" runat="server" Value="0" />
                                        <asp:HyperLink ID="hylnkInternalLabReportText" CssClass="hypavgfile" runat="server"
                                            onclick="OpenTestReport('FileUploadTest.aspx?Type=1&Flag=1')" Text="" ForeColor="Blue"
                                            Target="_blank" Style="cursor: pointer;">
                                            <img id="InternalImage" alt="#" src="../../images/uploadimg.png" style="width: 20px;
                                                height: 18px; position: relative; top: 0px;"><asp:Label ID="lblInternalFileName"
                                                    runat="server"></asp:Label>
                                        </asp:HyperLink>
                                        <asp:FileUpload ID="uploadInternalLabReport" AllowMultiple="true" runat="server"
                                            Style="display: none;" />
                                        <%-- here type is external(2) and internal(1) Type--%>
                                        <asp:HyperLink ID="hylnkInternalLabReport" runat="server" Target="_blank" onclick="OpenTestReport('FileUploadTest.aspx?Type=1&Flag=1')"
                                            Style="cursor: pointer; float: right"> 
                                            <img src="../../images/view-icon.png" style="width: 16px;height: 16px; position: relative;top:2px;" alt="" /> </asp:HyperLink>
                                    </td>
                                    <td style='border-right-color: #999; border-bottom-color: #999' class="PassfailLabDec">
                                        <asp:RadioButton ID="rdyBtnLabDecPassInter" GroupName="decision1" Text="Pass" runat="server"
                                            onclick="MyFunction();" />
                                        <asp:RadioButton ID="rdyBtnLabDecFailInter" GroupName="decision1" Text="Fail" runat="server"
                                            onclick="MyFunction();" />
                                        <asp:Label ID="Label2" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                    <td id="finalDecission" rowspan="2" style='border-right-color: #999; border-bottom-color: #999'
                                        class="Passfail">
                                        <asp:RadioButton ID="rbtFinalDecisionPass" GroupName="Internaldecision" Text="Pass"
                                            runat="server" /><br />
                                        <asp:RadioButton ID="rdybtnComeercialPass" GroupName="Internaldecision" Text="CommercialPass"
                                            runat="server" /><br />
                                        <asp:RadioButton ID="rbtFinalDecisionFail" GroupName="Internaldecision" Text="Fail"
                                            runat="server" />
                                        <asp:Label ID="lblFinalDecisionDate" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="ExternalRowId" runat="server">
                                    <td style="text-align: center; background: #f2f2f2; border-right-color: #999; border-left-color: #999;
                                        border-bottom-color: #999">
                                        <span>External</span>
                                    </td>
                                    <td style="text-align: center; border-bottom-color: #999;" class="BalckgroundColor">
                                        <asp:TextBox ID="txtExternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                            autocomplete="off" runat="server" onkeypress="javascript:return isNumberKey(event)"
                                            onchange="ExternalSentoLabValid()"></asp:TextBox>
                                    </td>
                                    <td style='text-align: left; border-bottom-color: #999' class="BalckgroundColor">
                                        <asp:CheckBox ID="chkExternalSentToLab" Checked="false" runat="server" />
                                        <asp:Label ID="lblExternalSentToLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnExternalSentToLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkExternalSentToLab" runat="server" Value="0" />
                                    </td>
                                    <td style='text-align: left; border-bottom-color: #999'>
                                        <asp:CheckBox ID="chkExternalReceivedInLab" Checked="false" runat="server" onchange="ExternalReceiveInLabValidation()" />
                                        <asp:Label ID="lblExternalReceivedInLabDate" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnExternalReceivedInLabDate" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnchkExternalReceivedInLab" runat="server" Value="0" />
                                    </td>
                                    <td style='border-right-color: #999; border-bottom-color: #999'>
                                        <asp:HiddenField ID="hdnExternalIsFile" runat="server" Value="0" />
                                        <%-- here type is external(2) and internal(1) Type--%>
                                        <asp:HyperLink ID="hylnkExternalLabReportText" onclick="OpenTestReport('FileUploadTest.aspx?Type=2&Flag=1')"
                                            CssClass="hypavgfile" runat="server" Text="" ForeColor="Blue" Target="_blank"
                                            Style="cursor: pointer;">
                                            <img alt="#" src="../../images/uploadimg.png" style="width: 20px; height: 18px; position: relative;
                                                top: 0px;"><asp:Label ID="Label1" runat="server"></asp:Label>
                                        </asp:HyperLink>
                                        <asp:FileUpload ID="uploadExternalLabReport" runat="server" Style="display: none;" />
                                        <asp:HyperLink ID="hylnkExternalLabReport" runat="server" Target="_blank" Style="cursor: pointer;
                                            float: right"> <img src="../../images/view-icon.png"  style="width: 16px;height: 17px; position: relative;top:2px;"  onclick="OpenTestReport('FileUploadTest.aspx?Type=2&Flag=1')" /> </asp:HyperLink>
                                    </td>
                                    <td style='border-right-color: #999; border-bottom-color: #999' class="PassfailLabDec">
                                        <asp:RadioButton ID="rdyBtnLabDecPassExt" GroupName="decision" Text="Pass" runat="server"
                                            onclick="MyFunction();" />
                                        <asp:RadioButton ID="rdyBtnLabDecFailExt" GroupName="decision" Text="Fail" runat="server"
                                            onclick="MyFunction();" />
                                        <asp:Label ID="Label3" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="QACheckbox">
                            <span style="text-align: right;">
                                <asp:CheckBox ID="chkLabManager" Checked="false" runat="server" />
                                <label>
                                    (Lab Manager)</label><br />
                                <div style="padding-left: 26px; text-align: left;">
                                    <%--<label id="lblFabLabManagerName" runat="server" style="display: none">
                                        Binod Kumar</label>--%>
                                    <asp:Label ID="lblFabLabManagerName" runat="server" Style="display: none;"></asp:Label>
                                    <br />
                                    <%--<label id="lblLabDatetime" runat="server" ></label>--%>
                                    <asp:Label ID="lblLabDatetime" runat="server" Style="display: none;"></asp:Label>
                                </div>
                            </span>
                        </div>
                        <div class="QACheckbox">
                            <div class="QACheckbox2">
                                <span style="text-align: right;" id="spn_ChkFabricQa">
                                    <asp:CheckBox ID="ChkFabricQa" Checked="false" Enabled="false" onchange="OnHoldQtyValidation()"
                                        onkeypress="return false;" runat="server" />
                                    <label style="padding-right: 0px;">
                                        (Fabric QA Manager)</label><br />
                                    <div style="padding-right: 5px; text-align: right;">
                                        <%--<label id="lblFabQAName" runat="server" style="display: none">
                                            Deepak Dureja</label>--%>
                                        <asp:Label ID="lblFabQAName" runat="server" Style="display: none;"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblQADatetime" runat="server" Style="display: none;"></asp:Label>
                                    </div>
                                    <%--<label id="lblQADatetime" runat="server" ></label>--%>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="RightSide" style="width: 42%; float: left;">
                        <table style="margin: 0px auto; width: 100%">
                            <tr id="FailedQtyId" runat="server">
                                <td style="text-align: center; width: 70px;">
                                    <span style="color: #6b6464">Fail Qty.</span>
                                    <asp:Label ID="lblTotalFailQty" runat="server"></asp:Label>
                                </td>
                                <td style='text-align: left; width: 125px;'>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                        <asp:TextBox ID="txtFailedRaisedDebit" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onblur="EnableDisableParticular(this, 'FailedQty');" onkeypress="javascript:return isNumberKey(event)"></asp:TextBox></span>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Fail Stock</span>
                                        <asp:TextBox ID="txtFailedStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumberKey(event)"></asp:TextBox>
                                    </span><span class="DisplayBlock"><span class="DisInlineBlock">Usable Stock</span>
                                        <asp:TextBox ID="txtFailedGoodStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumberKey(event)"></asp:TextBox>
                                    </span>
                                </td>
                                <td style='text-align: left;'>
                                    <asp:TextBox ID="txtFailedParticular" Rows="5" autocomplete="off" runat="server"
                                        TextMode="MultiLine" Width="98%" Height="65px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="ExtraQtyId" runat="server">
                                <td style="text-align: center; width: 130px;">
                                    <span style="color: #6b6464">Extra Qty.</span>
                                    <asp:Label ID="lblInspectExtraQty" runat="server"></asp:Label>
                                    <br />
                                    <span runat="server" id="spn_ExcessQty">Actual Required Qty.</span>
                                    <asp:Label ID="lblExcessQty" runat="server"></asp:Label>
                                </td>
                                <td style='text-align: left; width: 125px;'>
                                    <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                        <asp:TextBox ID="txtInspectRaisedDebit" CssClass="txtRaise" autocomplete="off" runat="server"
                                            onblur="EnableDisableParticular(this, 'ExtraQty');" onkeypress="javascript:return isNumberKey(event)"></asp:TextBox>
                                    </span><span class="DisplayBlock"><span class="DisInlineBlock">Usable Stock</span>
                                        <asp:TextBox ID="txtInspectUsableStock" CssClass="txtRaise" autocomplete="off" runat="server"
                                            onkeypress="javascript:return isNumberKey(event)"></asp:TextBox>
                                    </span>
                                </td>
                                <td style='text-align: left;'>
                                    <asp:TextBox ID="txtInspectParticular" autocomplete="off" Rows="5" Columns="20" runat="server"
                                        TextMode="MultiLine" Width="98%" Height="65px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="GMCheckbox">
                            <span style="text-align: right;">
                                <asp:CheckBox ID="ChkFabricGM" Checked="false" Enabled="false" onchange="MaterialGM_UsableStockValidation()"
                                    runat="server" />
                                <label style="padding-right: 16px">
                                    (Material GM)</label>
                                <div style="padding-right: 3px">
                                    <%--<label id="lblAccGMName" runat="server" style="display: none; color: Black;">
                                        Hemant Thakur</label>--%>
                                    <asp:Label ID="lblFabGMName" runat="server" Style="display: none;"></asp:Label>
                                </div>
                                <%--<label id="lblGMDateTime" runat="server" ></label>--%>
                                <asp:Label ID="lblGMDateTime" runat="server" Style="display: none; color: Black;"></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</tbody> </table>--%>
    <table style="width: 1234px; border-top: 0px; margin: 0px auto" cellspacing="0" cellpadding="0">
        <thead>
            <%-- <tr>
                            <td colspan="2" style="padding-top: 10px; border-bottom: 0px;" class="headerbold border_left_color border_right_color">
                                Inspected By
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" style="padding-top: 5px; border-bottom: 1px solid #dbd8d8; padding-bottom: 7px;"
                                class="headerbold border_left_color">
                                <span style="float: left">
                                    <asp:CheckBox Enabled="false" runat="server" Checked="false" ID="ChkFabricQa" Style="position: relative;
                                        left: -31px;" /><span style="position: relative; top: -17px; left: 18px;">(Fabric QA)</span></span>
                            </td>
                            <td colspan="" style="padding-top: 5px; border-bottom: 1px solid #dbd8d8; padding-bottom: 7px;"
                                class="headerbold border_right_color">
                                <span style="float: left">
                                    <asp:CheckBox Enabled="false" runat="server" Checked="false" ID="ChkFabricGM" Style="position: relative;
                                        left: -57px;" />
                                    <span style="position: relative; top: -17px; left: 18px;">(Fabric QA Manager)</span></span>
                            </td>
                        </tr>--%>
            <tr>
                <td colspan="3" class="border_right_color border_left_color" style="text-align: center;
                    padding-top: 15px; border-bottom-color: #999; padding-bottom: 10px;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnSubmit printHideButton"
                        OnClientClick="javascript:return validateRecivedQty();" OnClick="btnsubmit_Click" />
                    <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();"
                        runat="server" style="height: 15px; line-height: 15px;">
                        Close</div>
                    <div class="btnPrint printHideButton" onclick="window.print();return false" style="line-height: 18px;
                        height: 18px;">
                        Print</div>
                </td>
            </tr>
        </thead>
    </table>
    <%--</div>--%>
    <asp:Button ID="Button1" di="btncallback" Style="display: none" CssClass="callme"
        runat="server" OnClick="btncallback_Click" />
    <div id="divstock" runat="server" visible="false">
        <div class="TxtHeader">
            <%-- <span onclick="CloseFun()">X</span>--%>
        </div>
        <div style="width: 100%; padding: 10px 10px">
            Are you sure to raise debit for:
            <asp:Label ID="lblqtys" runat="server"></asp:Label>
            " Qty"
        </div>
        <div class="footerCotent">
            <asp:Button ID="btnok" runat="server" Text="Yes" CssClass="btnSubmit printHideButton"
                OnClick="btnok_Click" />
            <asp:Button ID="Btncancel" runat="server" Text="No" CssClass="btnSubmit printHideButton"
                OnClick="Btncancel_Click" />
        </div>
    </div>
    </form>
</body>
</html>
