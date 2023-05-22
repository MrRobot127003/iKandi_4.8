<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricSupplierChallanDetails.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricSupplierChallanDetails" %>

<meta http-equiv="CACHE-CONTROL" content="NO-CACHE">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        #spinner
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        body
        {
            font-family: sans-serif !important;
            margin: 0px;
            padding: 0px;
            font-size: 11px;
            color: #040404;
        }
        
        input
        {
            border-radius: 2px;
            border: 1px solid #999;
            padding-left: 3px;
        }
        input[type="text"]
        {
            padding-left: 3px;
            font-size: 10px;
            text-transform: capitalize !important;
        }
        .debitnote-table
        {
            font-family: Arial !important;
        }
        .debitnote-table .top_heading
        {
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 2px;
            background: #39589c;
            color: #fff;
        }
        .debitnote-table .address_head
        {
            font-weight: 500;
            font-size: 10px;
            line-height: 15px;
            padding-left: 0px;
        }
        .debitnote-table .Srnon
        {
            font-weight: 600;
            font-size: 18px;
        }
        tbody td
        {
            padding: 3px 3px;
            font-size: 11px; /* text-transform: uppercase; */
            border-color: #dbd8d8;
            color: #040404;
        }
        .DyedPrintDivWidth
        {
            overflow: hidden;
        }
        .DyedPrintDivWidth tbody td
        {
            border: 0px !important;
        }
        tbody td.borderbottom
        {
            border-bottom: 1px solid #dbd8d8;
            border-left: 1px solid #dbd8d8;
            padding: 0px 3px;
            font-size: 11px; /* text-transform: uppercase; */
            width: 150px;
            border-collapse: collapse;
        }
        .formcontrol
        {
            width: 98%;
        }
        .formcontrol2
        {
            width: 99%;
        }
        .headerbold
        {
            font-weight: 600;
        }
        
        .texttranceform
        {
            /* text-transform: uppercase; */
        }
        
        ul
        {
            margin: 0;
            padding: 0px 0px;
            max-width: 100%;
            list-style-type: none;
        }
        li
        {
            float: left;
            line-height: 16px;
            padding: 0px;
            color: #040404;
        }
        .tablewidth
        {
            width: 350px;
            padding: 0px 3px 5px;
            border-bottom: 1px solid #dbd8d8;
        }
        .tableto
        {
            width: 80px;
        }
        .bottomborder
        {
            border-bottom: 1px solid #dbd8d8;
            padding: 10px 5px;
        }
        .listwidth
        {
            min-width: 130px;
            margin-top: 2px;
        }
        tbody td.bordertable
        {
            border-bottom: 1px solid #dbd8d8;
            border-left: 1px solid #dbd8d8;
            padding: 2px 3px;
            font-size: 11px; /* text-transform: capitalize; */
            border-collapse: collapse;
            text-align: center;
        }
        .metercol
        {
            width: 50px;
        }
        .cmcoloum
        {
            width: 40px;
        }
        .checkboxtop
        {
            position: relative;
            top: 2px;
        }
        input
        {
            padding: 0px 0px;
        }
        .textaria
        {
            width: 74%;
        }
        .inputfield
        {
            width: 95%;
        }
        .bottomborder1
        {
            border-bottom: 1px solid #dbd8d8;
            text-align: center;
        }
        .rightborder
        {
            border-right: 1px solid #dbd8d8;
        }
        .btnbutton
        {
            background: #1976D2;
            color: #fff;
            border: 1px solid #1976d2;
            padding: 4px;
            border-radius: 3px;
        }
        .headerbacground
        {
            background: #e4e2e2;
            color: #6b6464;
        }
        .facolor
        {
            cursor: pointer;
            color: #000;
        }
        .p-r-5
        {
            padding-right: 5px;
        }
        .textcenter
        {
            text-align: center;
            font-size: 11px;
        }
        .removebucolor
        {
            color: red;
            cursor: pointer;
        }
        .editbucolor
        {
            color: green;
            cursor: pointer;
        }
        .txtcenter
        {
            text-align: center;
        }
        select
        {
            font-size: 11px;
        }
        input
        {
            font-size: 11px;
        }
        .borderleft
        {
            border-left: 1px solid #dbd8d8;
        }
        .borderleft0bottom
        {
            border-bottom: 1px solid #dbd8d8;
        }
        .metersr tbody td
        {
            height: 13px;
            border-color: #dbd8d8;
        }
        .tabletdhei
        {
            height: 16px !important;
        }
        .borderhightlight
        {
            border: 1px solid red !important;
        }
        
        
        .metersr tbody td:nth-last-child(2)
        {
            color: gray !important;
        }
        .fabric_challan_rategstamout tr td
        {
            padding-right: 20px;
        }
        .fabric_challan_rategstamout tr td span
        {
            font-weight: 600;
            color: gray;
        }
        .fabric_challan_rategstamout tr td .textcolor
        {
            font-weight: 600;
            color: black;
        }
        .textcolor_bracket{color:gray!important;}
        
      /*.textcolor_bracket::before
        {
            content: "( \20B9";
            margin-right: 2px;
           color:Gray;
        } 
        
     .textcolor_bracket::after
        {
            content: " )";
            margin-right: 2px;
            color:Gray;
        }   */
        
        .textcolor::before
        {
            content: "\20B9";
            margin-right: 2px;
            color:Gray;
        }
        .textcolor1{color:Black!important;}
        .textcolor1::after
        {
            content: " %";
            margin-right: 5px;
        }
        
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        
        .borderhightlight1
        {
            position: relative;
            display: inline-block;
            border-bottom: 1px dotted black;
        }
        
        .borderhightlight1 .messagetooltop
        {
            width: 120px;
            background-color: black;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            position: absolute;
            z-index: 1;
            top: 0%;
            right: 0%;
            margin-left: -60px;
        }
        table#tblisdayed
        {
            border: 0px;
            border-collapse: collapse;
        }
        #tblisdayed td
        {
            border: 1px solid #999 !important;
            border-left-color: #9999;
            border-right-color: #9999 !important;
            height: 16px;
        }
        .borderhightlight1 .messagetooltop::after
        {
            content: " ";
            position: absolute;
            top: 100%; /* At the bottom of the tooltip */
            right: 50%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: black transparent transparent transparent;
        }
        .supplieretadatetable td input[type="text"]
        {
            width: 92%;
            margin: 1px 0px;
            padding-left: 3px;
            color: #040404;
            text-transform: capitalize !important;
            font-size: 11px;
        }
        
        .supplieretadatetable th
        {
            padding: 3px 3px;
            border: 1px solid #999;
        }
        .supplieretadatetable td
        {
            text-align: center;
            padding: 1px 3px;
            border: 1px solid #dbd8d8;
        }
        th
        {
            font-weight: normal;
            font-size: 11px;
            font-family: Arial;
            background: #dddfe4;
            border-color: #999;
        }
        #grdmaster th
        {
            background: #dddfe4;
            padding: 2px 2px;
            width: 98px;
            text-align: center;
            border-color: #999;
        }
        .CloneRow
        {
            padding: 0px 3px !important; /*border-color: #999 !important;*/
        }
        .gridClass td
        {
            /* padding: 0px 3px !important;*/
        }
        .gridClass
        {
            margin-top: -13px;
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
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
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
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .supplieretadatetable
        {
            border-collapse: collapse;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        input[type='checkbox']
        {
            position: relative;
            top: 2px;
            margin: 1px 0px 0px 4px;
        }
        .border_left_color
        {
            border-left-color: #999 !important;
        }
        .border_right_color
        {
            border-right-color: #999 !important;
        }
        #grdmaster tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        /* Code added by bharat on 11-june*/
        #secure_footer
        {
            display: none;
        }
        .DyedPrintDivWidth
        {
            /*max-width: 545px !important;*/
            width: 100%;
            max-width: 100% !important;
        }
        .DyedPrintTableWidth .textaria
        {
            width: 75%;
        }
        .DyedPrintTableWidth .formcontrol
        {
            width: 34%;
            height: 16px !important;
            font-size: 10px;
        }
        .DyedPrintTableWidth .padding_top10
        {
            padding-top: 10px;
        }
        #divsend
        {
            position: relative;
            top: 0px;
            padding-left: 1px;
            border: 1px solid #999;
            padding: 4px 0px;
            border-right: 0px;
            border-left: 0px;
        }
        .DyedPrintTableWidth
        {
            width: 100% !important;
            border: 0px !important;
            margin-bottom: 0px !important;
        }
        .DyedPrintTableWidth .ToLeft
        {
            padding-right: 10px;
        }
        
        .DyedPrintTableWidth .DesLeft
        {
            padding-left: 20% !important;
            position: relative;
            top: -20px;
        }
        .DyedPrintTableWidth .FabricColorPrint
        {
            float: left;
            padding-left: 4.5% !important;
        }
        /* .DyedPrintTableWidth .inputtextwidth
        {
            width: 129% !important;
        }*/
        .DyedPrintTableWidth .bottom_border
        {
            border-bottom: 1px solid #999;
        }
        .widthCollCha
        {
            width: 20% !important;
        }
        .Paading5
        {
            padding-top: 5px !important;
        }
        .Margin_top8
        {
            margin-top: 0px !important;
        }
        .Paading_top0
        {
            padding-top: 0px !important;
        }
        .DiveBordernone
        {
            border-right: 0px !important;
            border-bottom: 0px !important;
        }
        
        .CloneRow.txtcenter.border_left_color
        {
            height: 17px;
        }
        #GridView1 td.CloneRow:first-child
        {
            border-left-color: #999 !important;
            height: 21px;
        }
        #GridView1 th
        {
            height: 19px;
        }
        #GridView1 td.CloneRow:last-child
        {
            border-right-color: #999 !important;
        }
        #GridView1 tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        .MainTableWidth
        {
            /* width: 41.6% !important;*/
            width: 41.6% !important;
        }
        .MasterTableWidth
        {
            min-width: 250px !important;
            max-width: 250px !important;
        }
        .TableHeight
        {
            height: 411px !important;
        }
        
        .TableHeight .FabricColorPrint
        {
            width: 1% !important;
        }
        .MainTableWidth .ToLeft
        {
            padding-left: 21% !important;
        }
        .MainTableWidth .MSLeft
        {
            padding-left: 20% !important;
        }
        .MainTableWidth .DesLeft
        {
            padding-left: 26% !important;
        }
        .MainTableWidth .inputtextwidth
        {
            width: 225px !important;
        }
        .ChallanNoWi
        {
            width: 29% !important;
        }
        .formcontrol4
        {
            width: 61%;
        }
        .NoTotalTable td
        {
            border: 0px !important;
        }
        
        /*.internalTable{
            height:411px !important;
        }*/
        .interButtonP
        {
            padding-top: 4px !important;
        }
        .PaddingTopPa0
        {
            padding-top: 2px !important;
        }
        .interTablewi #trchallantype .interwi
        {
            width: 37% important;
        }
        .bottom_border_color_h
        {
            border-bottom-color: #999 !important;
        }
        .interTablewi
        {
            height: 393px !important;
        }
        .interTablbeHei
        {
            height: 369px !important;
        }
        .MSWidthI
        {
            width: 70px !important;
        }
        .returnedchallanqty
        {
            display: none;
        }
        @media screen and (max-width: 1366px)
        {
            .TableHeight
            {
                height: 427px !important;
            }
            .DyedPrintTableWidth .MSLeft
            {
                padding-left: 0% !important;
            }
        
        }
        .TableHeight .MainTableWidth
        {
            height: 403px !important;
        }
        
        /*end*/
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
        @media print
        {
            .printHideButton
            {
                display: none;
            }
        }
        textarea
        {
            text-transform: capitalize !important;
        }
        td.input-validation-error
        {
            border: 1px solid #ff0000 !important;
            background-color: #ffeeee;
        }
        /** End */
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
        .RemoveStyle
        {
            color: Gray;
        }
        .hide
        {
            opacity: 0;
            pointer-events: none;
        }
    </style>
    <title>Fabric Challan Entry</title>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery1.6.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery1.6min.js")%>'></script>
    <%--<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>--%>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript">

        $(document).ready(function () {           
            var Challantype;
            Challantype = '<%=this.ChallanType %>';
            var ChallanNumber = $('#txtchallanno').val();
            proxy.invoke("../../Webservices/iKandiService.asmx/GetReturnedChallanQty", { Flag: 'ReturnChallanQty', ChallanNumber: ChallanNumber },
                function (result) {
                    if (Challantype == 'INTERNAL') {
                        $("#internalreturnchallanqty").val(result[0]);
                    }
                    else if (Challantype == 'SENDQTYCHALLAN') {
                        $('#externalreturnchallanqty').val(result[0]);
                    }

                }, onPageError, false, false
                );
        });

        $(window).load(function () {
            $("#spinner").fadeOut("slow");
        });


        function openFocExtraPercent(str) {
            if (str == "") {
                var display = $('#focextrapercentbox').css('display');
                if (display == "none") {
                    focextrapercenttext.innerHTML = "Foc Extra % :";
                    $('#focextrapercentbox').css("display", 'inline-block');
                }
                if (display == "inline-block") {
                    focextrapercenttext.innerHTML = "";
                    $('#focextrapercentbox').css("display", 'none');
                }
            }
            else {
                focextrapercenttext.innerHTML = "Foc Extra % :";
                $('#focextrapercentbox').css("display", 'inline-block');
            }
        }

        function CheckIfNumber(event) {
            var regex = new RegExp("[0123456789]");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        }

        function allowAlphaNumericSpace(e) {
            var code = ('charCode' in e) ? e.charCode : e.keyCode;
            if (!(code > 47 && code < 58) && // numeric (0-9)
            !(code > 64 && code < 91) && // upper alpha (A-Z)
            !(code > 96 && code < 123)) { // lower alpha (a-z)
                e.preventDefault();
            }
        }


        function DisplaySendMail() {
            var Challantype = '<%=this.ChallanType %>';
            if (Challantype != 'INTERNAL') {

                if ($("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                    $("#dvSendMail").css("display", "")
                    return false;
                }
                else {
                    $("#dvSendMail").css("display", "none")
                    return false;
                }
            }
        }

        function closePage() {
            window.parent.CallThisPage();
            window.parent.Shadowbox.close();
        }

        function pageLoad() {           
            var FabType = '<%=this.FabType %>';
            var issueComplete = $('')
            var GridRow = $(".MasterRow").length;
            $(".noonly").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            if (GridRow > 0) {
                $('#ChallanTable').addClass('MainTableWidth');
                $('.supplieretadatetable').addClass('MasterTableWidth');
                //                $('#grdmaster').addClass('MasterTableWidth');
                $('.DiveBorder').addClass('TableHeight');
                $('.challanColWidth').addClass("ChallanNoWi");
            }

            //            var grdmasterRow = $(".grdmasterRow").length;
            //            if (grdmasterRow >= 1) {
            //                $('.addBottom').removeClass('bottom_border_color_h');
            //            }

            var Challantype = '<%=this.ChallanType %>';

            if (Challantype == 'INTERNAL' || Challantype == 'ExtraStockIssue') {
                $('.hideInternalPo').hide();
                $('.debitnote-table').addClass('DyedPrintDivWidth');
                $('#ChallanTable').addClass('DyedPrintTableWidth');
                $('.challanColWidth').addClass('widthCollCha');
                $("#secure_footer").css('display', 'none');
                $('.toppadding10').addClass('Paading5');
                $('.MarginTop8').addClass('Margin_top8');
                $('.PaddingTop0').addClass('Paading_top0');
                $('.DiveBorder').addClass('DiveBordernone');
                $('.RemoveStyle').removeAttr('style');
                $('#tblmeterentry').hide();
                $('#hdn_AvailableDebitChallanQty').val();
                $('#suppliergstno').css("display", "none");
                $('#supplieraddress').css("display", "none");
            }
            else if (Challantype == 'DEBITCHALLAN') {
                $('.debitnote-table').addClass('DyedPrintDivWidth');
                $('#ChallanTable').addClass('DyedPrintTableWidth');
                $('.challanColWidth').addClass('widthCollCha');
                $("#secure_footer").css('display', 'none');
                $('.toppadding10').addClass('Paading5');
                $('.MarginTop8').addClass('Margin_top8');
                $('.PaddingTop0').addClass('Paading_top0');
                $('.DiveBorder').addClass('DiveBordernone');
                $('.RemoveStyle').removeAttr('style');
                $('#tblmeterentry').hide();

            }
            if (Challantype == 'SENDQTYCHALLAN' || Challantype == 'INTERNAL') {

                if (FabType == 'Dyed' || FabType == 'Printed' || FabType == 'RFD' || FabType == 'Embellishment' || FabType == 'Embroidery' || Challantype == 'INTERNAL') {
                    $('.debitnote-table').addClass('DyedPrintDivWidth');
                    $('#ChallanTable').addClass('DyedPrintTableWidth');
                    $('.challanColWidth').addClass('widthCollCha');
                    $("#secure_footer").css('display', 'none');
                    $('.toppadding10').addClass('Paading5');
                    $('.MarginTop8').addClass('Margin_top8');
                    $('.PaddingTop0').addClass('Paading_top0');
                    $('.DiveBorder').addClass('DiveBordernone');
                    $('.RemoveStyle').removeAttr('style');
                    $('#tblmeterentry').hide();
                }
            }


            if (Challantype == 'INTERNAL') {
                $('#dvSendMail').hide();
            }
            Totalremaningqty = '<%=this.Totalremaining %>';

            var conversionvalue = $('#hdnconversionvalue').val();
            if (conversionvalue == "") {
                conversionvalue = 1;
            }
            $('input').attr('autocomplete', 'off');
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $(".noonly").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();
            });
            var hdnchkReceiver = $('#<%= hdnchkReceiver.ClientID %>').val();
            var hdnchkAuthorized = $('#<%= hdnchkAuthorized.ClientID %>').val();


            if (hdnchkReceiver == "1" && hdnchkAuthorized == "1") {
                $("form :input").attr("disabled", "disabled");
                $("#rbtnYes").removeAttr('disabled');
                $("#rbtnNo").removeAttr('disabled');
                $("#btnSubmit").removeAttr('disabled');
                $('#txtdiscription').removeAttr('disabled');
                $('#externalreturnchallanqty').removeAttr('disabled');
            }
            Totalremaningqtyleft = $('#hdnsendtotalrening').val();
            $("#txtsendqtyforinfo").blur(function () {
                debugger; //05052023
                var conversionvalue = $('#hdnconversionvalue').val();
                var Rate = $("#<%=lblrate.ClientID  %>").text();
                var Gst = $("#<%=hdnGst.ClientID  %>").val();
                var GSTNo = $("#<%=lblgstno.ClientID  %>").text();
                var GSTType = GSTNo.slice(0, 2);
                var sendQty = 0;
                if ($("#txtsendqtyforinfo").val() == "") {
                    sendQty = 0;
                } else {
                    sendQty = $("#txtsendqtyforinfo").val().replace(',', '');
                }

                var TotalAmount = (((parseFloat(Rate) * Math.round(parseFloat(sendQty) / parseFloat(conversionvalue), 0)) * (100 + parseFloat(Gst))) / 100).toFixed(2);
                $("#<%=lblTotalAmount.ClientID%>").text(TotalAmount);

//                if (GSTType === 09){
                    var SGSTValue = (parseFloat(TotalAmount) - parseFloat(TotalAmount) * 100 / (100 + (parseFloat(Gst) / 2))).toFixed(2);
                    var CGSTValue = (parseFloat(TotalAmount) - parseFloat(TotalAmount) * 100 / (100 + (parseFloat(Gst) / 2))).toFixed(2);
                    $("#<%=lblSGSTValue.ClientID%>").text(SGSTValue);
                    $("#<%=lblCGSTValue.ClientID%>").text(CGSTValue);
//                }
//                else {
                    var IGSTValue = (parseFloat(TotalAmount) - parseFloat(TotalAmount) * 100 / (100 + parseFloat(Gst))).toFixed(2);
                    $("#<%=lblIGSTValue.ClientID%>").html(IGSTValue);
//                }
            });
            EnterdQty = $('#txtsendqtyforinfo').val();
            if (Totalremaningqty == "") {
                Totalremaningqty = 0;
            }
            if (Challantype == 'INTERNAL') {
                var status = $('#hdnstatus').val();
                if (status != '2' && $("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                    $('.returnedchallanqty').removeClass("ReturnedChallanQty");
                    $('#internalreturnchallanqty').prop('disabled', false);
                    $('#txtdiscription').removeAttr('disabled');
                }
                if (status == '2') {
                    $('.returnedchallanqty').removeClass("ReturnedChallanQty");
                }

            }

            if (Challantype == 'ExtraStockIssue') {
                if ($("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                    $('.returnedchallanqty').removeClass("ReturnedChallanQty");
                    $('#internalreturnchallanqty').prop('disabled', false);
                    $('#txtdiscription').removeAttr('disabled');
                }
            }
        }
        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        $(document).ready(function () {
            function closePage() {
                self.parent.parent.PageReload();
                self.parent.Shadowbox.close();
            }
            $('input').attr('autocomplete', 'off');
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $(".noonly").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();
            });
            // add code by bharat on 11-june
            var FabType = '<%=this.FabType %>';
            var Challantype = '<%=this.ChallanType %>';
            var IsClose = '<%=this.IsClose %>';

            if (IsClose == "1") {

                // $('.chkoption').attr('disabled', 'disabled');
                $('input[type=checkbox]').attr('disabled', 'true');
                if (Challantype == 'DEBITCHALLAN') {

                    ChallanID = $('#hdnchallanid').val();
                    if ($("#chkrecivegood").is(':checked') == false && $("#chkAuthorised").is(':checked') == false) {
                        $("#btnSubmit").show()
                        $('input[type=checkbox]').removeAttr('disabled');
                    }
                }
            }
            var hdnchkReceiver = $('#<%= hdnchkReceiver.ClientID %>').val();
            var hdnchkAuthorized = $('#<%= hdnchkAuthorized.ClientID %>').val();

            if (hdnchkReceiver == "1" && hdnchkAuthorized == "1") {

                $("form :input").attr("disabled", "disabled");
                $("form").attr({ "title": "After both checkbox done all fields will be disabled"
                });
                $("#rbtnYes").removeAttr('disabled');
                $("#rbtnNo").removeAttr('disabled');
                $("#btnSubmit").removeAttr('disabled');
                $('#txtdiscription').removeAttr('disabled');
                $('#externalreturnchallanqty').removeAttr('disabled');
            }
            if ($('#hdnstatus').val() != '2' && $("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                $("#internalreturnchallanqty").removeAttr('disabled');
            }
            var conversionvalue = $('#hdnconversionvalue').val();
            if (conversionvalue == "") {
                conversionvalue = 1;
            }

            //alert(hdnchkReceiver + " " + hdnchkAuthorized);
            if (Challantype == 'SENDQTYCHALLAN' || Challantype == 'INTERNAL') {

                if (FabType == 'Dyed' || FabType == 'Printed' || FabType == 'RFD' || FabType == 'Embellishment' || FabType == 'Embroidery' || Challantype == 'INTERNAL') {
                    //alert(FabType);
                    $('.debitnote-table').addClass('DyedPrintDivWidth');
                    $('#ChallanTable').addClass('DyedPrintTableWidth');
                    $('.challanColWidth').addClass('widthCollCha');
                    $("#secure_footer").css('display', 'none');
                    $('.toppadding10').addClass('Paading5');
                    $('.MarginTop8').addClass('Margin_top8');
                    $('.PaddingTop0').addClass('Paading_top0');
                    $('.DiveBorder').addClass('DiveBordernone');
                    $('.RemoveStyle').removeAttr('style');
                    $('#tblmeterentry').hide();
                }
            }
            //end

            Totalremaningqtyleft = $('#hdnsendtotalrening').val();

            if (Challantype == 'INTERNAL') {

                $('#dvSendMail').hide();
            }
        });
        function GetUnitname(unitid) {
            if (unitid == "1") {
                return "Mtr"
            }
            if (unitid == "3") {
                return "Kg"
            }
            if (unitid == "4") {
                return "yard"
            }
            if (unitid == "5") {
                return "pcs"
            }
            if (unitid == "7") {
                return "box"
            }
        }
        function Savemtervalue() {
            alert("Details Saved Successfully");
            window.parent.CallThisPage();
            window.parent.Shadowbox.close();
        }
        function removeclass(elem) {
            $(elem).removeClass('borderhightlight');
        }

        function checkreturnqty() {

            var IsError = "";

            var Challantype = '<%=this.ChallanType %>';

            if (Challantype != "FOC_CHALLAN") {

                var enteredexternalreturnchallanqty = $('#externalreturnchallanqty').val();
                var remainingqty = $('#hdnremainingqty').val();
                var originalreturnchallanqty = $('#hdnreturnedchallanqty').val();
                var sendqty = $('#txtsendqtyforinfo').val().replace(",", "");

                if (originalreturnchallanqty == "") {
                    originalreturnchallanqty = 0;
                }

                if (remainingqty == "") {
                    remainingqty = 0;
                }

                if (parseInt(enteredexternalreturnchallanqty) < parseInt(originalreturnchallanqty)) {
                    if (parseInt(enteredexternalreturnchallanqty) >= (parseInt(originalreturnchallanqty) - parseInt(remainingqty))) {
                    } else {
                        alert("You can't return that much quantity, Please check and enter again.");
                        $('#externalreturnchallanqty').val(originalreturnchallanqty);
                        IsError = "false";
                    }
                }
                else if (parseInt(enteredexternalreturnchallanqty) > parseInt(originalreturnchallanqty)) {
                    if (parseInt(enteredexternalreturnchallanqty) > parseInt(sendqty)) {
                        alert("Return Qty. cannot be greater than Send Qty.");
                        if (originalreturnchallanqty == 0) originalreturnchallanqty = "";
                        $('#externalreturnchallanqty').val(originalreturnchallanqty);
                        IsError = "false";
                    }
                }
                if (IsError == "false") {
                    return false;
                }
            }

        }

        function ValidateForm() {
            debugger;        
            var IsError = "";
            var Challantype = '<%=this.ChallanType %>';
            var totalmtr = $('[id*=txtqtytotal]').val();
            var maxtotalmtr = $('#<%= hdnmaxcount.ClientID %>').val();
            var availableqty = $('#<%= hdnmaxavailbleqty.ClientID %>').val();
            var than = $('[id*=txtThan]').val();

            if (totalmtr == "") {
                totalmtr = 0;
            }           
            if (maxtotalmtr == "") {
                maxtotalmtr = 0;
            }
            if (availableqty == "") {
                availableqty = 0;
            }
            //            Challantype == "ExtraStockIssue"

            if (Challantype == "ExtraStockIssue") {
                debugger;
                if ($('#txtqtytotal').val() == "") {
                    alert("Please Enter Challan Qty.");
                    IsError = "false";
                }

                if (IsError != "false") {
                    if ($('#txtthanvalue').val() == "") {
                        alert("Please Enter No. Of Items.");
                        IsError = "false";
                    }
                }
                if (IsError != "false") {
                    if ($('#txtThan').val() == "") {
                        alert("Please Enter No. Of Than.");
                        IsError = "false";
                    }
                }

                if (IsError != "false") {
                    var SelectedUnit = $('[id*=ddlsuppliername]').val();
                    if (parseInt(SelectedUnit) == -1) {
                        alert("Please select Factory Unit.");
                        IsError = "false";
                    }
                }

                if (IsError != "false") {
                    var n = $(".chkoption input:checked").length;
                    if (n == 0) {
                        alert("Please Select Process.");
                        $(".rpterror").addClass('borderhightlight');
                        IsError = "false";
                    }
                }

                if (IsError != "false" && $('#hdnisnewchallan').val() == 'NEWCHALLAN') {

                    var ChallanNumber = $('#txtchallanno').val();
                    var urls = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: urls + "/CheckIfChallanNumberExist",
                        data: "{ ChallanNumber:'" + ChallanNumber + "',ReturnQty:'" + 0 + "'}",
                        dataType: 'JSON',
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {

                        if (response.d == "Challan Already Existed.") {
                            alert("Challan Number Already Exist.Please Close this page and make Challan again.");
                            IsError = "false";
                        }
                    }

                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }

                }
            }
            //            Challantype == "FOC_CHALLAN"
            else if (Challantype == "FOC_CHALLAN") {

                var AuthorisedSign = $('#hdnchkAuthorized').val();
                var ReceiverSign = $('#hdnchkReceiver').val();

                var ChallanNumber = $('#txtchallanno').val();

                EnterdQty = $('#txtsendqtyforinfo').val().replace(",", "");

                if (EnterdQty == "" || EnterdQty == "0") {
                    alert("Please Enter Valid Foc Challan Qty.");
                    IsError = "false";
                }
                if (IsError != "false" && parseInt(AuthorisedSign) != 1 && parseInt(ReceiverSign) != 1) {
                    if ($('#lblHSNCode').val() == "") {
                        alert("Please Enter HSNCode Of Items.");
                        return false;
                    }
                }
                //New Work Start :Girish

                var externalreturnchallanqty = $('#externalreturnchallanqty').val() == null ? "0" : $('#externalreturnchallanqty').val().replace(",", "");

                if ((externalreturnchallanqty == "" || externalreturnchallanqty == "0") && IsError != "false" && parseInt(AuthorisedSign) == 1 && parseInt(ReceiverSign) == 1) {
                    alert("Please Submit Only after Entering valid Foc Reverse Challan Qty. / Close this Page.");
                    IsError = "false";
                }

                if (IsError != "false" && $('#hdnisnewchallan').val() == 'NEWCHALLAN') {

                    var ChallanNumber = $('#txtchallanno').val();
                    var urls = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: urls + "/CheckIfChallanNumberExist",
                        data: "{ ChallanNumber:'" + ChallanNumber + "',ReturnQty:'" + 0 + "'}",
                        dataType: 'JSON',
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {

                        if (response.d == "Challan Already Existed.") {
                            alert("Challan Number Already Exist.Please Close this page and make Challan again.");
                            IsError = "false";
                        }
                    }

                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }

                }
                //New Work End :Girish
            }
            //            Challantype == "DEBITCHALLAN" || Challantype == "INTERNAL"
            else if (Challantype == "DEBITCHALLAN" || Challantype == "INTERNAL") {
                var thanvals = $('[id*=txtthanvalue]').val();
                var thanunits = $('[id*=ddlthanunitsvalue]').val();
                var chkAuthorised = $('[id*=chkAuthorised]').is(":checked");
                var SelectedUnit = $('[id*=ddlsuppliername]').val();

                if (thanvals == "") {
                    thanvals = 0;
                }

                var n = $(".chkoption input:checked").length;
                if (n == 0) {
                    alert("Please Select Process.");
                    $(".rpterror").addClass('borderhightlight');
                    IsError = "false";
                }
                if (IsError != "false") {
                    if (parseInt(SelectedUnit) == -1) {
                        alert("Select factory Unit.");
                        IsError = "false";
                    }
                }
                if (IsError != "false") {
                    if (parseInt(totalmtr) <= 0) {
                        alert("Total Issued must have value");
                        IsError = "false";
                    }
                }
                if (IsError != "false") {
                    if (parseInt(thanvals) <= 0) {
                        alert("Enter No. of Pieces");
                        IsError = "false";
                    }
                }
                if (Challantype == "DEBITCHALLAN") {
                    if (IsError != "false") {
                        if ($('#lblHSNCode').val() == "") {
                            alert("Please Enter HSNCode Of Items.");
                            return false;
                        }
                    }
                }

                var InternalChallanAvailableQty = 0;

                //New Work Start :Girish

                if (IsError != "false" && Challantype == "INTERNAL" && $('#hdnchkReceiver').val() != "1" && $('#hdnchkAuthorized').val() != "1") {
                    InternalChallanAvailableQty = $('#hdnInternalRemainingQty').val();

                    if (parseInt(totalmtr) > parseInt(InternalChallanAvailableQty)) {
                        alert("Send Quantity Cannot be greater than Available Qty.");
                        $('[id*=txtqtytotal]').val('');
                        IsError = "false";
                    }
                }

                if (IsError != "false" && $('#hdnisnewchallan').val() != 'NEWCHALLAN') {

                    if ($('#hdnstatus').val() != '2' && $("#chkrecivegood").is(':checked') && $("#chkAuthorised").is(':checked')) {
                        if (Challantype == "INTERNAL") {
                            var totalmtr = $('[id*=txtqtytotal]').val().replace(',', '');
                            var qty = $('#internalreturnchallanqty').val();
                            if (qty == '') {
                                qty = 0;
                            }
                            if (parseInt(qty) <= parseInt(totalmtr))
                                $('#hdnreturnedchallanqty').val(qty);

                            else {
                                alert("Error! Returned Qty. cannot be greater than Challan Qty.");
                                IsError = "false";
                            }
                        }
                    }
                }
                if (IsError != "false" && $('#hdnisnewchallan').val() == 'NEWCHALLAN') {

                    var ChallanNumber = $('#txtchallanno').val();
                    var urls = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: urls + "/CheckIfChallanNumberExist",
                        data: "{ ChallanNumber:'" + ChallanNumber + "',ReturnQty:'" + 0 + "'}",
                        dataType: 'JSON',
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {
                        if (response.d == "Challan Already Existed.") {
                            alert("Challan Number Already Exist.Please Close this page and make Challan again.");
                            IsError = "false";
                        }
                    }

                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }
                }
                //New Work End :Girish

                if (IsError != "false") {
                    $("#btnSubmit").addClass("hide");
                    $(".btnClose").addClass("hide");
                    $(".btnPrint").addClass("hide");
                    $("#dvSendMail").addClass("hide");
                }

            }
            //Challantype == "SENDQTYCHALLAN" New Work Start :Girish

            else if (Challantype == "SENDQTYCHALLAN") {

                var AuthorisedSign = $('#hdnchkAuthorized').val();
                var ReceiverSign = $('#hdnchkReceiver').val();

                var isSamplingSelected = "";
                var isSampleProcessChecked = "";

                $("[id$='challanProcess']").each(function () {
                    if ($('#' + (this).id).is(':checked')) {
                        isSampleProcessChecked = "true";
                        var split = (this).id.split("challanProcess");
                        var txtid = split[0];
                        if ($('#' + txtid.concat('lblfabricoprationType')).html() == "Sampling") {
                            isSamplingSelected = "true";
                        }
                    }
                });

                //code added on 2023-03-15 by Girish

                if (isSampleProcessChecked != "true") {
                    alert("Please Select Process.");
                    IsError = "false";
                }

                if (isSamplingSelected == "true" && (parseInt(AuthorisedSign) == 0 && parseInt(ReceiverSign) == 0)) {
                    if ($.trim($('#txtSuppliername').val()) == "") {
                        alert("Please Enter Supplier Name.");
                        IsError = "false";
                    }
                    else if ($.trim($('#txtGSTNo').val()) == "") {
                        alert("Please Enter GST No.");
                        IsError = "false";
                    }
                    else if ($.trim($('#txtSupplierAddress').val()) == "") {
                        alert("Please Enter Supplier Address.");
                        IsError = "false";
                    }
                    else if ($.trim($('#txtThan').val()) == "") {
                        alert("Please Enter No of Than.");
                        IsError = "false";
                    }
                }
                //code added on 2023-03-15 by Girish

                var AlreadyReturned = $('#hdnreturnedchallanqty').val();
                var enteredreturnqty = parseInt($('#externalreturnchallanqty').val() == "" ? 0 : $('#externalreturnchallanqty').val());

                ChallanID = $('#hdnchallanid').val();
                EnterdQty = $('#txtsendqtyforinfo').val().replace(",", "");
                savedsendqty = $('#hdnsavedsendqty').val();
                var Rate = $("#<%=lblrate.ClientID  %>").text();

                if (Rate == "" || Rate == null) {
                    Rate = 0;
                    $('#hdnrate').val(Rate);
                }
                else {
                    $('#hdnrate').val(Rate);
                }
                if (EnterdQty == "") {
                    EnterdQty = 0;
                }
                if (ChallanID == "") {
                    ChallanID = 0;
                }
                if (savedsendqty == "") {
                    savedsendqty = 0;
                }
                var Totalremaningqty;

                Totalremaningqty = $('#hdnexternalchallanremainingqty').val();

                if (parseInt(EnterdQty) <= 0) {
                    EnterdQty = 0;
                    alert("Send Quantity Cannot be Empty.");
                    IsError = "false";
                }

                if ($('#txtThan').val() == "") {
                    alert("Please Enter No of Than.");
                    return false;
                }
                if ($('#txtThan').val() <= 0) {
                    alert("Than Should not be less than one.");
                    return false;
                }
                   
                if (IsError != "false") {
                    if ($('#lblHSNCode').val() == "") {
                        alert("Please Enter HSNCode Of Items.");
                        return false;
                    }                 
                }


                // Below Condition Checks for Challan Qty cannot be greater than Remaining Qty.         

                if (IsError != "false" && parseInt(AuthorisedSign) != 1 && parseInt(ReceiverSign) != 1) {
                    if (parseInt(EnterdQty) > parseInt(Totalremaningqty)) {

                        alert("Entered Send Quantity Cannot be Greater than Remaining Quantity :" + Totalremaningqty);
                        IsError = "false";

                    }
                }
                // Below Condition Check for Returned Qty should not be greater than Challan Qty.

                if (IsError != "false" && $('#hdnisnewchallan').val() != 'NEWCHALLAN' && parseInt(AuthorisedSign) == 1 && parseInt(ReceiverSign) == 1 && enteredreturnqty != AlreadyReturned) {
                    if ($('#externalreturnchallanqty').val() == "" || $('#externalreturnchallanqty').val() == null)
                        externalreturnchallanqty = 0;

                    else externalreturnchallanqty = $('#externalreturnchallanqty').val();

                    if (parseInt(externalreturnchallanqty) <= parseInt(EnterdQty))
                        $('#hdnreturnedchallanqty').val(externalreturnchallanqty);

                    else {
                        alert("Error! Returned Qty. Cannot be greater than Send Qty.");
                        IsError = "false";
                    }
                }

                // Below Condition Checks for duplicate Challan Number in Case multiple Challan Pages are opened without saving previous ones

                if (IsError != "false" && $('#hdnisnewchallan').val() == 'NEWCHALLAN') {
                    var ChallanNumber = $('#txtchallanno').val();
                    var urls = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: urls + "/CheckIfChallanNumberExist",
                        data: "{ ChallanNumber:'" + ChallanNumber + "',ReturnQty:'" + 0 + "'}",
                        dataType: 'JSON',
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {
                        if (response.d == "Challan Already Existed.") {
                            alert("Challan Number Already Exist.Please Close this page and make Challan again.");
                            IsError = "false";
                        }
                    }
                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }
                }

                //                Below Condition checks if returned qty enterd in EXTS Challan is Valid or not in case EXTFOC Challan is already Made.

                if (IsError != "false" && $('#hdnisnewchallan').val() != 'NEWCHALLAN' && parseInt(AuthorisedSign) == 1 && parseInt(ReceiverSign) == 1 && enteredreturnqty != AlreadyReturned && enteredreturnqty > AlreadyReturned) {
                    var ChallanNumber = $('#txtchallanno').val();
                    var externalreturnqty = $('#externalreturnchallanqty').val()

                    var urls = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: urls + "/CheckIfChallanNumberExist",
                        data: "{ ChallanNumber:'" + ChallanNumber + "',ReturnQty:'" + externalreturnqty + "' }",
                        dataType: 'JSON',
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {
                        if (response.d == "NotValid") {
                            alert("You cannot return that much Quantity(" + enteredreturnqty + ") Please Check Again.");
                            IsError = "false";
                            $('#hdnreturnedchallanqty').val(AlreadyReturned);
                            $('#externalreturnchallanqty').val(AlreadyReturned == "0" ? "" : AlreadyReturned);
                        }
                    }
                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }
                }
                if (IsError != "false") {
                    $("#btnSubmit").addClass("hide");
                    $(".btnClose").addClass("hide");
                    $(".btnPrint").addClass("hide");
                    $("#dvSendMail").addClass("hide");
                }

            }
            //New Work Start :Girish

            if (IsError == "false") {
                return false;
            }

        }

        function checkAvailable() {           
            var Challantype = '<%=this.ChallanType %>';
            if (Challantype == "INTERNAL") {
                var totalmtr = $('[id*=txtqtytotal]').val();

                var InternalChallanAvailableQty = $('#hdnInternalRemainingQty').val();

                if (parseInt(totalmtr) > parseInt(InternalChallanAvailableQty)) {
                    alert("Send Quantity Cannot be greater than Available Qty.");
                    $('[id*=txtqtytotal]').val('');

                    $('#lblavailableqtydebitchallan').val(InternalChallanAvailableQty);
                    return false;
                }
            }
        }



        function DeleteRow() {
            if (confirm("Are you sure want to delete row!")) {
                var td = event.target.parentNode;
                var tr = td.parentNode; // the row to be removed
                tr.parentNode.removeChild(tr);
                SetSeqFirstgrd();
            }
            return false;
        }
        //        function updatecm(elem) {

        //            var multiplayer = 0;
        //            if ($('[id*=lblunitname]').text() == "Meter") {
        //                multiplayer = 100;
        //            }
        //            else if ($('[id*=lblunitname]') == "kg") {
        //                multiplayer = 1000;
        //            }
        //            else if ($('[id*=lblunitname]').text() == "yard") {
        //                multiplayer = 90;
        //            }
        //            var thanvals = $('[id*=txtmeter]').val();
        //            var txtcm = $('[id*=txtcm]').val();
        //            var x = (parseInt(thanvals) * multiplayer);

        //            $('[id*=txtcm]').val(x);

        //            if (isNaN(x)) {
        //                $('[id*=txtcm]').val("");

        //            }

        //        }

        (function (b) { var c = { allowFloat: false, allowNegative: false }; b.fn.numericInput = function (e) { var f = b.extend({}, c, e); var d = f.allowFloat; var g = f.allowNegative; this.keypress(function (j) { var i = j.which; var h = b(this).val(); if (i > 0 && (i < 48 || i > 57)) { if (d == true && i == 46) { if (g == true && a(this) == 0 && h.charAt(0) == "-") { return false } if (h.match(/[.]/)) { return false } } else { if (g == true && i == 45) { if (h.charAt(0) == "-") { return false } if (a(this) != 0) { return false } } else { if (i == 8) { return true } else { return false } } } } else { if (i > 0 && (i >= 48 && i <= 57)) { if (g == true && h.charAt(0) == "-" && a(this) == 0) { return false } } } }); return this }; function a(d) { if (d.selectionStart) { return d.selectionStart } else { if (document.selection) { d.focus(); var f = document.selection.createRange(); if (f == null) { return 0 } var e = d.createTextRange(), g = e.duplicate(); e.moveToBookmark(f.getBookmark()); g.setEndPoint("EndToStart", e); return g.text.length } } return 0 } } (jQuery));
        $(function () {
            $(".anyNumber").numericInput({ allowFloat: false, allowNegative: false });
        });

        //new work Start :Girish
        function Repeater1CheckBoxChanged(id) {
            $("[id$='challanProcess']").each(function () {
                if (id != (this).id) {
                    var check = (this).id;
                    $(this).prop('checked', false);
                }
            });

            var split = id.split("challanProcess")
            var txtid = split[0];

            if ($('#' + txtid.concat('lblfabricoprationType')).html() == "Sampling") {
                $('#lblsuppliername').html('');
                $('#txtSuppliername').prop('disabled', false);
                $('#txtSuppliername').css('border', '1px solid black');
                $('#txtSuppliername').css('display', 'inline-block');

                $('#lblgstno').html('');
                $('#txtGSTNo').prop('disabled', false);
                $('#txtGSTNo').css('border', '1px solid black');
                $('#txtGSTNo').css('display', 'inline-block');

                $('#lbladdress').html('');
                $('#txtSupplierAddress').prop('disabled', false);
                $('#txtSupplierAddress').css('border', '1px solid black');
                $('#txtSupplierAddress').css('display', 'inline-block');

            }
            else {
                $('#lblsuppliername').html($('#ddlsuppliername option:selected').text());
                $('#lblsuppliername').css('display', 'inline-block');
                $('#txtSuppliername').css('display', 'none');
                $('#txtSuppliername').prop('disabled', true);
                $('#txtSuppliername').css('border', 'none');

                $('#lblgstno').html($('#hdnforlblgstno').val());
                $('#lblgstno').css('display', 'inline-block');
                $('#txtGSTNo').css('display', 'none');
                $('#txtGSTNo').prop('disabled', true);
                $('#txtGSTNo').css('border', 'none');

                $('#lbladdress').html($('#hdnForlbladdress').val());
                $('#lbladdress').css('display', 'inline-block');
                $('#txtSupplierAddress').css('display', 'none');
                $('#txtSupplierAddress').prop('disabled', true);
                $('#txtSupplierAddress').css('border', 'none');
            }
        }

        function ddlProductionUnitChanged() {
            var SelectedUnit = $("#ddlsuppliername option:selected").val();
            var commaSeparatedUnits = $("#hdnInternalUnitIds").val();

            var unitIds = commaSeparatedUnits.split(',');
            if (unitIds.includes(SelectedUnit)) {
                $('#trToShowGSTNoForInternalChallan').css('display', 'none');
                $('#txtGSTNoForInternalChallan').val();
            }
            else {
                $('#trToShowGSTNoForInternalChallan').css('display', 'contents');

                if (SelectedUnit == $('#hdnSelectedSupplier').val()) {
                    $('#txtGSTNoForInternalChallan').val($('#hdnGSTNoForInternalChallan').val());
                }
                else {
                    $('#txtGSTNoForInternalChallan').val('');
                }
            }
        }

        //new work End :Girish

    

    </script>
    <asp:HiddenField ID="hdnchkReceiver" runat="server" Value="0" />
    <asp:HiddenField ID="hdnInternalRemainingQty" runat="server" Value="0" />
    <asp:HiddenField ID="hdnchkAuthorized" runat="server" Value="0" />
    <asp:HiddenField ID="hdntotalmeter" runat="server" Value="0" />
    <asp:HiddenField ID="hdnsendtotalrening" runat="server" Value="0" />
    <asp:HiddenField ID="hdnConvertedQuantityForPdf" runat="server" Value="0" />
    <asp:HiddenField ID="hdnsentRemainingQty" runat="server" Value="0" />
    <asp:HiddenField ID="hdnexternalchallanremainingqty" runat="server" Value="0" />
    <asp:HiddenField ID="hdnsentRemainingUnit" runat="server" Value="0" />
    <asp:HiddenField ID="hdnsavedsendqty" runat="server" Value="0" />
    <asp:HiddenField ID="hdnchallanid" runat="server" Value="0" />
    <asp:HiddenField ID="hdnFabricQuality" Value="" runat="server" />
    <asp:HiddenField ID="hdnGst" runat="server" Value="-1" />
    <asp:HiddenField ID="hdnSendQty" runat="server" Value="-1" />
    <asp:HiddenField ID="hdnstatus" Value="" runat="server" />
    <asp:HiddenField ID="hdnreturnedchallanqty" Value="-1" runat="server" />
    <asp:HiddenField ID="hdnrate" Value="0" runat="server" />
    <asp:HiddenField ID="hdnremainingqty" Value="0" runat="server" />
    <asp:HiddenField ID="hdnactualchallanqty" Value="0" runat="server" />
    <asp:HiddenField ID="hdnSavedChallanQty" Value="0" runat="server" />
    <div id="spinner">
    </div>
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="updatepnl"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading128.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnmaxcount" runat="server" />
            <asp:HiddenField ID="hdnmaxavailbleqty" runat="server" />
            <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
            <asp:HiddenField ID="hdnChallan_Number" Value="0" runat="server" />
            <asp:HiddenField ID="hdnisnewchallan" Value="" runat="server" />
            <div class="debitnote-table">
                <div class="DiveBorder" style="border-right: 1px solid #999999; width: 100%;">
                    <%--Challan Page Heading Start --%>
                    <table style="max-width: 100%; width: 100%; border: none; border: 1px solid #999999;
                        border-bottom: 0px;" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td class="top_heading texttranceform bottomborder1" colspan="">
                                    <span id="ChallanPageHeading" runat="server"></span>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <%--Challan Page Heading End --%>
                    <table id="ChallanTable" style="max-width: 100%;" cellspacing="0" cellpadding="0">
                        <%--Address And Logo Section Start--%>
                        <thead>
                            <tr>
                                <td style="vertical-align: top; width: 125px; border-bottom: 1px solid #9999" class="bottom_border">
                                    <div style="padding: 9px 7px">
                                        <img src="../../images/boutique-logo.png" />
                                    </div>
                                </td>
                                <td style="text-align: left; border-left: 0px; border-bottom: 1px solid #9999" rowspan="2"
                                    class="barder_top_color">
                                    <div id="divbipladdress" runat="server">
                                    </div>
                                </td>
                            </tr>
                        </thead>
                        <%--Address And Logo Section End--%>
                        <%--Body Section untill Description Start--%>
                        <tbody style="padding: 5px;">
                            <tr>
                                <td class="texttranceform  challanColWidth padding_top10" style="width: 19%; color: gray">
                                    <span>Challan No.</span>
                                </td>
                                <td class="padding_top10">
                                    <asp:TextBox ID="txtchallanno" Style="background: #fff; width: 40%; border: 0px;
                                        font-weight: 600; font-size: 11px; color: #000; margin-top: 1px;" class="formcontrol"
                                        runat="server" Enabled="false"></asp:TextBox></span>
                                </td>
                            </tr>
                            <tr class="hideInternalPo">
                                <td class=" texttranceform  challanColWidth" style="width: 19%; color: gray">
                                    PO No.
                                </td>
                                <td class="">
                                    <asp:Label ID="txtponumber" class="formcontrol" Style="margin: 2px;" runat="server"
                                        Enabled="false"></asp:Label>
                                </td>
                            </tr>
                            <tr class="hideInternalPo">
                                <%--rajeevs --%>
                                <td class=" texttranceform  challanColWidth" style="width: 19%; color: gray">
                                    <span style="padding-bottom: 10px; color: gray" runat="server" id="spn_HSNCode">
                                    </span>
                                    <%--  <span style="color: red; font-size: 12px;">*</span></td>--%>
                                    <td>
                                        <asp:TextBox ID="lblHSNCode" Style="margin: 2px;" class="formcontrol" runat="server"
                                            Enabled="true" Width="110px" onkeypress="allowAlphaNumericSpace(event)"></asp:TextBox>
                                        <%--<asp:Label ID="lblHSNCode" Style="margin: 2px;"  class="formcontrol" runat="server" Enabled="false"></asp:Label>--%>
                                    </td>
                                    <%--end --%>
                            </tr>
                            <tr>
                                <td class=" texttranceform  challanColWidth" style="width: 19%; color: gray">
                                    Date
                                </td>
                                <td class=" ">
                                    <asp:TextBox ID="txtpodate" class="formcontrol th datesfileds" runat="server" Style="height: 13px;
                                        background: #fff; width: 80px; border: 0px" disabled="disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="texttranceform  rpterror" style="padding-left: 3px; color: gray">
                                    Select
                                </td>
                                <td onclick="removeclass(this)" class="texttranceform  rpterror" colspan="" style="padding-left: 0px">
                                    <ul>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <li class="listwidth">
                                                    <asp:CheckBox Class="chkoption" ID="chkprocess" runat="server" />
                                                    <%--added by Girish on 2023-02-28 For External And Internal Challan Only (Start)--%>
                                                    <input class="isChecked" id="challanProcess" type="checkbox" runat="server" visible="false"
                                                        onchange="Repeater1CheckBoxChanged(this.id)" />
                                                    <%--added by Girish on 2023-02-28 For External And Internal Challan Only (End)--%>
                                                    <asp:Label ID="lblfabricoprationType" Text='<%#Eval("ProcessName")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnChallan_Process_Admin_Id" runat="server" Value='<%#Eval("Challan_Process_Admin_Id")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; color: gray" class="">
                                    <span style="display: inline-flex">To</span>
                                </td>
                                <td class="" style='color: gray'>
                                    <table style='color: gray'>
                                        <tr>
                                            <td runat="server" id="tdCompanyType">
                                                <span class="ToLeft">
                                                    <asp:DropDownList ID="ddlext" Enabled="false" Style="width: 70px;" runat="server">
                                                        <asp:ListItem Value="0">Internal</asp:ListItem>
                                                        <asp:ListItem Value="1">External</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                            </td>
                                            <td>
                                                <span>M/S:</span> <span style="color: Red;font-size: 14px;width: 30px;left: 10%;display: inline-block;">*</span><span
                                                    class="MSLeft" style="padding-left: 0px">
                                                    <asp:DropDownList Style="width: 125px;" ID="ddlsuppliername" class="msinternal" runat="server"
                                                        onchange="ddlProductionUnitChanged()">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField runat="server" ID="hdnSelectedSupplier" Value='' />
                                                    <span>
                                                        <asp:Label ID="lblsuppliername" Visible="false" runat="server"></asp:Label>
                                                        <%--added by Girish on 2023-02-28 for External Challan Start (girish)--%>
                                                        <asp:TextBox ID="txtSuppliername" Visible="false" runat="server" Style="border: none;
                                                            background-color: White;" Enabled="false"></asp:TextBox>
                                                        <%--added by Girish on 2023-02-28 for External Challan End (girish)--%>
                                                    </span>
                                            </td>
                                        </tr>
                                        <%--added by Girish For Internal Challan Only--%>
                                        <asp:HiddenField runat="server" ID="hdnInternalUnitIds" Value="" />
                                        <tr runat="server" id="trToShowGSTNoForInternalChallan" style="display: none;">
                                           <td>
                                             <asp:Label runat="server" Style="font-weight: bold;width: 55px;display: inline-block;" ID="lblGSTNoForInternalChallan" Text="GST No."></asp:Label>
                                              <asp:TextBox runat="server" Style="border: 1px solid #4F4F4F; height: 15px;" ID="txtGSTNoForInternalChallan"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="hdnGSTNoForInternalChallan" Value='' />
                                         
                                            </td>
                                  
                                        </tr>
                                        <%--added by Girish For Internal Challan Only--%>
                                        <tr runat="server" id="externalChallantr">
                                            <td>
                                                <span id="suppliergstno" style="padding-bottom: 10px; color: gray">GST No:</span>
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblgstno" Text="" runat="server"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnforlblgstno" Value="" />
                                                    <%--added by Girish on 2023-03-15 for External Challan Start (girish)--%>
                                                    <asp:TextBox ID="txtGSTNo" Visible="true" runat="server" Style="border: none; background-color: White;"
                                                        Enabled="false"></asp:TextBox>
                                                    <%--added by Girish on 2023-03-15 for External Challan End (girish)--%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="externalchallantr2">
                                            <td>
                                                <span id="supplieraddress" style="padding-bottom: 10px; color: gray">Address:</span>
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lbladdress" Text="" runat="server"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnForlbladdress" Value="" />
                                                    <%--added by Girish on 2023-03-15 for External Challan Start (girish)--%>
                                                    <asp:TextBox ID="txtSupplierAddress" Visible="false" runat="server" Style="border: none;
                                                        background-color: White;" Enabled="false"></asp:TextBox>
                                                    <%--added by Girish on 2023-03-15 for External Challan End (girish)--%>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--Style and Serial Number Section For Internal Challan (By Default Display:none)  Start--%>
                            <tr id="intstylenumber" runat="server" visible="false">
                                <td class="borderbottom interwi">
                                    <span style="color: gray; width: 123px; display: inline-block;">Style No. </span>
                                </td>
                                <td>
                                    <asp:Label ID="txtstylenumber" runat="server" class="formcontrol" Style="background: #fff;
                                        font-weight: bold; color: #000"></asp:Label>
                                </td>
                            </tr>
                            <tr id="intserialnumber" runat="server" visible="false">
                                <td class="borderbottom interwi">
                                    <span style="color: gray; width: 123px; display: inline-block;">Serial No. </span>
                                </td>
                                <td>
                                    <asp:Label ID="txtserialnumber" runat="server" class="formcontrol" Style="width: 106px;
                                        font-weight: bold; color: Blue; background: #fff;"></asp:Label>
                                </td>
                            </tr>
                            <%--Style and Serial Number Section For Internal Challan (By Default Display:none)  End--%>
                            <tr>
                                <td class="" style="padding-left: 1px;">
                                    <span style="float: left; padding-left: 2px; color: gray; width: 160px; text-align: left;">
                                        Fabric Quality/ ColorPrint</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcolorprint" runat="server" Visible="false" Enabled="false" class="formcontrol inputtextwidth"
                                        Style="width: 275%; background: #fff; display: none;"></asp:TextBox>
                                    <span id="lblcolorprintdetails" runat="server" style="float: left"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="RemoveStyle">Description</span>
                                </td>
                                <td>
                                    <span>
                                        <asp:TextBox ID="txtdiscription" runat="server" class="" contenteditable="true" Style="width: 100%"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </span>
                                </td>
                            </tr>
                        </tbody>
                        <%--Body Section untill Description End--%>
                    </table>
                </div>
                <span runat="server" visible="false" id="extrastockissue"><span style="width: 34%;
                    float: left; color: Gray;">Total Qty. Issued Till Now : <span runat="server" id="totalqtyissuedtillnow"
                        style="color: Black; font-weight: bold;"></span><span runat="server" id="totalqtyissuedtillnow_unit"
                            style="color: Black; font-weight: bold;"></span></span><span style="width: 33%; color: Gray;
                                float: left;">Total Issued From Stock : <span runat="server" id="totalissuedfromstock"
                                    style="color: Black; font-weight: bold;"></span><span runat="server" id="totalissuedfromstock_unit"
                                        style="color: Black; font-weight: bold;"></span></span><span style="width: 33%; color: Gray;">
                                            Balance In Stock : <span runat="server" id="balanceinstock" style="color: Black;
                                                font-weight: bold;"></span><span runat="server" id="balanceinstock_unit" style="color: Black;
                                                    font-weight: bold;"></span><span runat="server" id="balanceinstock_stage" style="color: Black;
                                                        font-weight: bold;"></span></span></span>
                <table runat="server" class="NoTotalTable" visible="false" id="tblisdayed" style="width: 100%;
                    border: none; margin: 5px 0px;" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="rightborder" style="padding-left: 5px; color: gray">
                                No. of Items <b>:</b>
                                <asp:TextBox ID="txtthanvalue" runat="server" Style="width: 50px; height: 17px;"
                                    MaxLength="5" class="noonly formcontrol numeric-field-without-decimal-places"></asp:TextBox>
                            </td>
                            <td class="rightborder">
                                <asp:Label ID="lbldebitnochallacaption" ForeColor="Gray" Text="Quantity <b>:</b>"
                                    runat="server"></asp:Label>
                                <asp:TextBox ID="txtqtytotal" MaxLength="8" AutoPostBack="true" OnTextChanged="txtqtytotal_TextChanged"
                                    onblur="checkAvailable()" runat="server" Style="background: #fff; width: 59px;"
                                    class="formcontrol noonly"></asp:TextBox>
                                <b>
                                    <asp:Label ID="lblinternalconverttounit" ForeColor="gray" Visible="false" runat="server"
                                        Text="Mtr"></asp:Label></b> <b>
                                            <asp:Label ID="lblinternaldefualtremaningqty" ForeColor="gray" Visible="false" runat="server"></asp:Label></b>
                                <asp:Label ID="lblinternaldefualtunit" Visible="false" ForeColor="gray" runat="server"></asp:Label>
                                <b>
                            </td>
                            <%--Returned Qty Section For Internal Challan only Start(By Defualt Display:none)--%>
                            <td class="rightborder ReturnedChallanQty" style="color: gray;">
                                Returned Qty. <b>:</b>
                                <asp:TextBox ID="internalreturnchallanqty" runat="server" Style="width: 50px; height: 17px;"
                                    AutoPostBack="true" OnTextChanged="internalreturnchallanqty_TextChanged" MaxLength="6"
                                    class="noonly formcontrol numeric-field-without-decimal-places">
                                </asp:TextBox>
                                <b>
                                    <asp:Label ID="lblreturnqtyunit" ForeColor="gray" Text="Mtr" Visible="true" runat="server"></asp:Label></b>
                                <b>
                            </td>
                            <%--Returned Qty Section For Internal Challan only End--%>
                            <td class="rightborder" id="tdRightBorder" runat="server">
                                <asp:Label ID="lblavailbledebittext" Visible="false" ForeColor="Gray" runat="server"
                                    Text="Available Qty: "></asp:Label>
                                <asp:Label Visible="false" ID="lblavailableqtydebitchallan" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdn_AvailableDebitChallanQty" runat="server" Value="0" />
                                <b>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblavailabelqtyunitname" ForeColor="gray" Visible="false"
                                    runat="server"></asp:Label></b>
                                <asp:HiddenField ID="hdndebitavailebaleqty" runat="server" Value="0" />
                                <asp:Label Visible="false" ID="Label1" runat="server"></asp:Label>
                                <b>&nbsp;&nbsp;&nbsp;<asp:Label Visible="false" ID="lbldebitdefualtqty" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdn_DebitDefaultQty" runat="server" Value="0" />
                                    <asp:Label ID="lbldebitdefualtunitstaticinfo" ForeColor="gray" Visible="false" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <%--challan after Description but before Rate Start --%>
                <span runat="server" visible="false" id="focrequiredinfo"><span style="width: 34%;
                    float: left; color: Gray;">Total Send Qty. Without Foc : <span runat="server" id="TotalSendQtyWithoutFoc"
                        style="color: Black; font-weight: bold;"></span><span runat="server" id="Withoutfocunit"
                            style="color: Black; font-weight: bold;"></span></span><span style="width: 33%; color: Gray;
                                float: left;">Total Send Qty (Foc): <span runat="server" id="TotalSendQtyWithFoc"
                                    style="color: Black; font-weight: bold;"></span><span runat="server" id="Withfocunit"
                                        style="color: Black; font-weight: bold;"></span></span><span style="width: 33%; color: Gray;">
                                            Stock Available Qty.: <span runat="server" id="FocStockAvailableQty" style="color: Black;
                                                font-weight: bold;"></span><span runat="server" id="stockqtyunit" style="color: Black;
                                                    font-weight: bold;"></span><span runat="server" id="StockAvailableQtyAtStage" style="color: Black;
                                                        font-weight: bold;"></span></span></span>
                <div id="divsend" runat="server" style="clear: both; margin-top: 15px;">

                <span style="padding-left: 2px; color: gray" id="Span1" runat="server">Than</span>
                    <span style="color: red; font-size: 12px;">*</span>
                    <asp:TextBox ID="txtThan" runat="server" MaxLength="4" Style="font-size: 10px; color: blue; width: 7% !important;
                        height: 16px; text-align: center;" class="anyNumber" onkeypress="CheckIfNumber(event)"> </asp:TextBox>

                    <span style="padding-left: 2px; color: gray" id="sendqtyy" runat="server"></span>
                    <span style="color: red; font-size: 12px;">*</span>
                    <asp:TextBox ID="txtsendqtyforinfo" AutoPostBack="true" OnTextChanged="txtsendqtyforinfo_TextChanged"
                        runat="server" MaxLength="6" Style="font-size: 10px; color: blue; width: 7% !important;
                        height: 16px; text-align: center;" class="anyNumber" title="Send Qty" onkeypress="CheckIfNumber(event)"> </asp:TextBox>
                    <b>
                        <asp:Label ID="lblconverttounit" ForeColor="gray" Visible="false" runat="server"></asp:Label>
                    </b>&nbsp; &nbsp;
                    <asp:Label ID="lbldefualtremaningqty" Visible="false" ForeColor="gray" runat="server"></asp:Label>
                    <b>
                        <asp:Label ID="lbldefualtunit" ForeColor="gray" Visible="false" runat="server"></asp:Label>
                    </b>
                    <%--Return Challan Qty for External only Start (By Defualt Visible:False)--%>
                    <span id="externalreturnchallanqtytitle" visible="false" style="padding-left: 32px;
                        color: gray;" runat="server"></span>
                    <asp:TextBox ID="externalreturnchallanqty" Visible="false" AutoPostBack="true" runat="server"
                        MaxLength="6" Style="font-size: 10px; color: blue; width: 7% !important; height: 16px;
                        text-align: center;" class="anyNumber" title="Returned Challan Qty" onChange="checkreturnqty()"
                        OnTextChanged="ExternalReturnChallanQty_TextChanged"> 
                    </asp:TextBox>
                    <asp:HiddenField runat="server" Value="" ID="hdnexternalreturnchallanqty" />
                    <b>
                        <asp:Label ID="lblconverttounit2" ForeColor="gray" Visible="false" runat="server"></asp:Label>
                    </b>&nbsp; &nbsp;
                    <%--Returned Challan Qty for External only end--%>
                    &nbsp; &nbsp;
                    <%-- <div id="focextrapercent" runat="server" disabled="disabled" visible="false" style="margin-left: 44px;padding-left:12px;width:2%;color: Black;cursor:pointer;font-weight:bold;display:inline-block;" onclick="openFocExtraPercent('')">  *
                    </div>--%>
                    <span><span runat="server" id="focextrapercenttext" style="color: Gray;" visible="false">
                        FOC Extra %</span>
                        <asp:TextBox ID="focextrapercentbox" runat="server" AutoPostBack="true" MaxLength="2"
                            Style="font-size: 10px; color: blue; width: 7% !important; height: 16px; text-align: center;"
                            class="anyNumber" title="Extra Percent For Foc Challan" Enabled="false" Visible="false"
                            OnTextChanged="addExtraPercentInFoc"> 
                        </asp:TextBox></span>
                    <asp:Label ID="lblsendreaming" Style="color: gray;" runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdn_exts_remainingqty" Value="0" />
                    <asp:HiddenField ID="hdndefaultunit" runat="server" />
                    <asp:HiddenField ID="hdnconverttounit" runat="server" />
                    <asp:HiddenField ID="hdnconversionvalue" runat="server" />
                    <asp:HiddenField ID="hdnoldqty" runat="server" />
                    &nbsp; &nbsp; <b>
                        <asp:Label ID="lbldefualtunitstaticinfo" Visible="false" ForeColor="gray" runat="server"></asp:Label>
                        <asp:Label ID="lbldefualtinitinfo" ForeColor="gray" Visible="false" runat="server"></asp:Label>
                    </b>
                </div>
                <span runat="server" id="focnote" style="color: gray"></span>
                <%--challan after Description but before Rate End --%>
                <!---- gst,rate,total amount start----->
                <table class="fabric_challan_rategstamout" id="fabric_challan_rategst" runat="server">
                    <tr>
                        <td>
                            <span>Rate:</span>
                            <asp:Label ID="lblrate" runat="server" class="textcolor"></asp:Label>
                        </td>
                        <td runat="server" id="licgst" style="padding-right:0">
                            <span>CGST:&nbsp;</span>
                            <asp:Label ID="lblcgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="TdCGSTValue">
                          <asp:Label ID="lblCGSTValue" runat="server" class="textcolor_bracket"></asp:Label>
                        </td>
                        <td runat="server" id="lisgst" style="padding-right:0">
                            <span>SGST:&nbsp;</span>
                            <asp:Label ID="lblsgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="TdSGSTValue">
                           <asp:Label ID="lblSGSTValue" runat="server" class="textcolor_bracket" ></asp:Label>
                        </td>
                        <td runat="server" id="igst" style="padding-right:0">
                            <span>IGST:&nbsp;</span>
                            <asp:Label ID="lbligst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="Td3" class="textcolor_bracket">
                           <asp:Label ID="lblIGSTValue" runat="server"></asp:Label>
                        </td>
                        <td id="Totalamount" runat="server">
                            <span>Total Amount:</span>
                            <asp:Label ID="lblTotalAmount" runat="server" class="textcolor"></asp:Label>
                        </td>
                    </tr>
                </table>
                <!---- gst,rate,total amount end----->
                <%--Footer Section Including Signature, Save and Close Button Start--%>
                <table style="font-size: 12px; width: 100%; margin-left: 1px; margin-top: 1px; border: none;border-top: 1px solid darkgray;" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td style="padding: 5px 0px 5px 10px;" class="headerbold">
                                Received the goods in good condition
                            </td>
                            <td style="text-align: right; padding-right: 15px;">
                                <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table class="MarginTop8" style="max-width: 100%; font-size: 12px; width: 100%; margin-left: 1px;
                    margin-top: 5px; border: none; border-top: 0px solid #999;" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 5px;
                                font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkReceive">
                                    <asp:CheckBox ID="chkrecivegood" onclick="DisplaySendMail()" runat="server" />
                                    Receiver's Signature
                                </div>
                                <div runat="server" id="divSigReceive" visible="false">
                                    <asp:Image ID="imgReceiver" runat="server" Height="40px" Width="125px" />
                                    <br />
                                    <asp:Label ID="lblReceiverName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblReceivedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                                padding-right: 15px; font-size: 11px; color: #6b6464" onclick="removeclass(this)">
                                <div runat="server" id="divChkAuthorized">
                                    <asp:CheckBox ID="chkAuthorised" onclick="DisplaySendMail()" runat="server" />
                                    Authorized Signature
                                </div>
                                <div runat="server" id="divSigAuthorized" visible="false">
                                    <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                    <br />
                                    <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="toppadding10" colspan="2" style="text-align: center; float: left; padding-top: 8px;
                                width: 366px; max-width: 366px;">
                                <div class="form_buttom" style="float: left;">
                                    <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" ClientIDMode="Static"
                                        OnClientClick="return ValidateForm();" runat="server" Text="Save" OnClick="btnDebitNoteSave" />
                                </div>
                                <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                    Close</div>
                                <div class="btnPrint printHideButton" onclick="window.print();return false">
                                    Print</div>
                                <div id="dvSendMail" style="font-weight: bold; top: 5px; width: 400px; display: none"
                                    runat="server" class="printHideButton">
                                    &nbsp; &nbsp; Is E-Mail Send:
                                    <asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail" runat="server" CssClass="printHideButton" />
                                    <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server"
                                        CssClass="printHideButton" />
                                </div>
                            </td>
                        </tr>
                    </thead>
                </table>
                <%--Footer Section Including Signature, Save and Close Button End--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
