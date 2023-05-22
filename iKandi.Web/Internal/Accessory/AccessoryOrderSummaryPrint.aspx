<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryOrderSummaryPrint.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryOrderSummaryPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .AddClass_Table {
            margin-left: 15px;
            margin-top: 5px;
        }
        .AddClass_Table th {
            padding: 0px 3px;
            background-color: #DDDFE4;
            height: 20px;
            font-size: 10px;
            text-transform: capitalize;
        }
        .AddClass_Table td {
            padding: 0px 0px;
            text-align: center;
            font-size: 10px;
        }
        .FloatLeft {
            float: left;
        }
        .FloatRight {
            float: right;
        }
        .CellWidth {
            min-width: 80px;
            max-width: 80px;
        }
        .CellWidth1 {
            min-width: 83px;
            max-width: 83px;
        }
        .CellWidth2 {
            min-width: 82px;
            max-width: 82px;
        }
        td.CellWidth3 {
            min-width: 76px;
            max-width: 76px;
            padding: 0px 0px !important;
        }
        .txtCenter {
            text-align: center;
            padding: 2px 0px !important;
            line-height: 15px;
        }
        th.TopHeader {
            background: #39589c !important;
            color: White;
            padding: 3px 0px;
            font-size: 14px;
        }
        th .Inner_Table th {
            border: 0px;
            height: 16px;
        }
        .Inner_Table {
            width: 100%;
        }
        td .Inner_Table td {
            border: 0px;
            height: 50px;
            border: 0px;
        }
        .Inner_Table .CellWidth {
            min-width: 80px;
            max-width: 80px;
        }
        
        .TooltipShrnkWat {
            position: relative;
            display: inline-block;
        }
        
        .TooltipShrnkWat .TooltipContent {
            visibility: hidden;
            width: 80px;
            background-color: #555;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            position: absolute;
            z-index: 1;
            top: -25px;
            left: -3px;
        }
        .TooltipShrnkWat .TooltipContent::after {
            content: "";
            position: absolute;
            top: 100%;
            left: 10px;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #555 transparent transparent transparent;
        }
        
        .TooltipShrnkWat:hover .TooltipContent {
            visibility: visible;
        }
        .FooterTable {
            width: 100%;
            border: 0px;
        }
        .FooterTable td {
            border: 1px solid #9999;
            border-bottom: 0px;
            border-left: 0px;
            height: 23px;
            color: #000;
            font-weight: 600;
            font-size: 12px;
        }
        table.Inner_TableContent {
            width: 100%;
        }
        table.Inner_TableContent td {
            height: 27px !important;
        }
        @media print {
            .printButtonHide {
                display: none;
            }
        }
        @media print {
            pre, blockquote {
                page-break-inside: avoid;
            }
        }
        
        ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-thumb {
            background: #999;
            border: 1px solid #ddd7d7;
            border-radius: 10px;
        }
    </style>
    <style type="text/css">
        th.TopHeader {
            background: #39589c !important;
            color: White !important;
            padding: 3px 0px !important;
            font-size: 14px !important;
        }
        
        
        
        
        
        ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-thumb {
            background: #999;
            border: 1px solid #ddd7d7;
            border-radius: 10px;
        }
        
        
        .OrderSummery_Table {
            margin-left: 15px;
            margin-top: 5px;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .OrderSummery_Table th {
            padding: 0px 3px;
            background-color: #DDDFE4;
            height: 20px;
            font-size: 10px;
            text-transform: capitalize;
            background: #dddfe4;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .OrderSummery_Table td {
            padding: 0px 0px;
            text-align: center;
            font-size: 10px;
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial, Helvetica, sans-serif;
        }
        
        .OrderSummery_Table td:first-child {
            border-left-color: #999 !important;
        }
        .OrderSummery_Table td:last-child {
            border-right-color: #999 !important;
        }
        .OrderSummery_Table tr:last-child > td {
            border-bottom-color: #999 !important;
            border-right-color: #999 !important;
        }
        
        .AccessDetail {
            min-width: 150px;
            max-width: 150px;
            border-collapse: collapse !important;
        }
        .QualityPrintTable {
            min-width: 100px;
            max-width: 100px;
            border-collapse: collapse !important;
        }
        .Total {
            min-width: 100px;
            max-width: 150px;
        }
        .Swatches {
            min-width: 150px;
            max-width: 150px;
        }
        .OrderSummery_Table input[type=text], .OrderSummery_Table textarea {
            border: 1px solid #ffffff !important;
            text-transform: capitalize;
            font-size: 11px;
        }
        
        @media print {
            .printButtonHide {
                display: none;
            }
        }
        @media print {
            pre, blockquote {
                page-break-inside: avoid;
            }
        }
    </style>
</head>
<body>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <form id="form1" autocomplete="off" runat="server">
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        function PrintPage() {
            window.print();
        }

        function SaveDescription(OrderDetailId, elem) {
            debugger;
            var id = elem.id;
            var ComVal = $('#' + id).val().trim();
            var Flag = 'Accessory_Description';
            if (ComVal != '') {
                proxy.invoke("Save_Accessory_Description", { OrderDetailId: OrderDetailId, ComVal: ComVal, Flag: Flag },
                    function (result) {
                    });
            }
        }

        function SaveDescriptionRemarks(elem) {
            debugger;
            var id = elem.id;
            var hdnvalue = $("#hdnOrderid").val();
            var Orderid = parseInt(hdnvalue);
            var ComVal = $('#' + id).val().trim();
            if (ComVal != '') {
                proxy.invoke("Save_Accessory_AccessoryRemarks", { orderid: Orderid, ComVal: ComVal },
                    function (result) {
                    });
            }
        }

        $(function () {
            debugger;
            $('input[name="type"]').on('click', function () {
                if ($(this).val() == 'V') {
                    $('#AccessoryPrintSummary').show();
                    $('#AccessoryPrintSummaryNew').hide();
                    $('#RemarkTable').width($('.AddClass_Table').width());
                    $('#ThRemarkTable').css("min-width", "170px");
                }
                else {
                    $('#AccessoryPrintSummary').hide();
                    $('#AccessoryPrintSummaryNew').show();
                    $('#RemarkTable').width($('.OrderSummery_Table').width());
                    $('#ThRemarkTable').css("min-width", "170px");
                }
            });

            $('#RemarkTable').width($('.OrderSummery_Table').width());
            $('#ThRemarkTable').css("min-width", "170px");
        });
    </script>
    <div>
        <div style="margin-top: 5px; margin-left: 150px;" class="print printButtonHide">
            <input type="radio" name="type" value="V">
            Vertical &nbsp;
            <input type="radio" name="type" value="H" checked="checked">
            Horizontal &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnPrint" runat="server" CssClass="print da_submit_button printButtonHide" Text="Print" OnClientClick="javascript:PrintPage();" />
        </div>
        <div id="AccessoryPrintSummary" runat="server" style="display: none;">
        </div>
        <div id="AccessoryPrintSummaryNew" runat="server">
        </div>
        <br />
        <div style="margin-top: 5px; margin-left: 15px;">
            <table id="RemarkTable" class='OrderSummery_Table' style="margin-left: 0px !important;" border='0' cellspacing='0' cellpadding='0'>
                <tr>
                    <th id="ThRemarkTable" class="AccessDetail">
                        Remarks :
                    </th>
                    <td style="width: 95%">
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtRemarks" Style="width: 99%;" Rows="5" cols="5" onblur="SaveDescriptionRemarks(this);" spellcheck="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnOrderid" runat="server" />
            AVG Checked and Smart Marker Uploaded by Account Manager
            <asp:CheckBox ID="chkboxAccountMgr" runat="server" Enabled="false" Style="position: relative; cursor: poniter; top: 3px;" />
            &nbsp; &nbsp; &nbsp; Approved by Accessory Manager
            <asp:CheckBox ID="chkboxAccessoryMgr" runat="server" Enabled="false" Style="position: relative; cursor: poniter; top: 3px;" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
    </form>
</html>
