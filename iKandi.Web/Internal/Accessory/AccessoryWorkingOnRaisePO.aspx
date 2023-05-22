<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="AccessoryWorkingOnRaisePO.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryWorkingOnRaisePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        body
        {
            background: #fff none repeat scroll 0 0;
            font-family: arial !important;
        }
        
        .GSTTAbleEmp td
        {
            border: 1px solid #999 !important;
        }
        .gridviewWidth td[colspan="22"]
        {
            border: 0px;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        
        
        
        @media print
        {
            .printButtonHide
            {
                display: none;
            }
            .headerSticky
            {
                display: none;
            }
            #secure_greyline
            {
                display: none;
            }
            #topcontrols
            {
                display: none;
            }
            #srchdiv
            {
                display: none;
            }
        
        }
        .da_submit_button
        {
            background: #3b5998;
            width: auto;
            border: 0px;
            padding: 5px 9px;
            cursor: pointer;
            color: #fff;
            text-decoration: none;
            text-align: center;
            height: 22px;
            font-size: 12px;
            line-height: 14px;
            cursor: pointer;
            border-radius: 2px;
        }
        
        .btnrpo
        {
            cursor: pointer;
            background-color: blue;
            color: #fff;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 3px 2px;
            float: right;
            margin: 0 2px;
        }
    </style>
    <style type="text/css">
        .per
        {
            color: blue;
        }
        
        .gray
        {
            color: gray;
        }
        
        h2 .row-fir th
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
            font-family: arial,sans-serif !important;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }
        
        .backcolorstages
        {
            background: #fdfd96e0;
        }
        
        input[type="text"]
        {
            border-color: White;
            width: 34% !important;
            border: 1px solid #999 !important;
            border-radius: 2px;
            height: 13px;
            color: Blue;
            font-size: 10px !important;
        }
        input[type="text"].inptunoneborder
        {
            border-color: transparent;
            border: 1px solid transparent !important;
            background: transparent;
            color: Blue;
            font-size: 10px !important;
            outline: -webkit-focus-ring-color auto 0px;
        }
        input[type="text"].inptunoneborder:focus
        {
            border-color: transparent;
            border: 1px solid transparent !important;
            background: transparent;
            color: Blue;
            outline: -webkit-focus-ring-color auto 0px;
            font-size: 10px !important;
        }
        /* :focus
    {
       outline: -webkit-focus-ring-color auto 0px;
     }*/
        .float_left
        {
            float: left;
            padding-left: 3px;
        }
        
        .float_right
        {
            float: right;
            padding-ight: 3px;
        }
        
        .color_black
        {
            color: Black;
        }
        
        
        
        .maincontentcontainer
        {
            width: 1100px;
            margin: 20px 0 0px;
        }
        
        #data tbody > tr:last-child > td
        {
            border-bottom: 0 !important;
        }
        
        .btnrpo
        {
            cursor: pointer;
            background-color: blue;
            color: #fff;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 3px 2px;
            float: right;
            margin: 0 2px;
        }
        .inptunoneborder
        {
            border: 0px !important;
            background: transparent;
        }
        .inptunoneborder:focus
        {
            border: 0px !important;
            background: transparent;
        }
        
        .btnrepo
        {
            cursor: pointer;
            background-color: #FFA500;
            color: #000;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 3px 2px;
            float: left;
            margin: 0 2px;
        }
        
        p:nth-last-child(2)
        {
            background: red;
        }
        td.process:last-child
        {
            height: 24px;
        }
        
        .HideRaisebtn
        {
            display: none !important;
        }
        
        .divspplier
        {
            position: absolute;
            top: 50%;
            left: 43%; /* width: 30em; */
            min-height: 200px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
        }
        
        .topsupplier
        {
            border-collapse: collapse;
        }
        
        .topsupplier th
        {
            background: #536EA9;
            color: #d4d4d4f8;
            text-align: center;
            border: 1px solid #999;
            font-size: 10px !important;
        }
        
        .topsupplier td
        {
            text-align: center;
            border: 1px solid #999;
            font-weight: bold;
            font-size: 10px !important;
        }
        
        #sb-wrapper-inner
        {
            border: 5px solid #999;
            border-radius: 5px;
        }
        .highlight
        {
            background-color: #f7d6dc;
        }
        
        .plusshow
        {
            background: url('./../images/plus_icon.gif');
        }
        
        #sb-wrapper-inner
        {
            background: #fff;
            width: 98%;
        }
        
        input[type='text']
        {
            text-align: center;
        }
        td.ColunWidth
        {
            min-width: 44px !important;
        }
        td.ColunWidthTotalqty
        {
            min-width: 130px !important;
            max-width: 130px !important;
        }
        
        .gridviewWidth
        {
            min-width: 1340px;
            width: 100%;
            border: 1px solid #999;
        }
        
        .challanTable td.challantd
        {
            min-width: 80px !important;
            max-width: 80px !important;
        }
        td.PlusWidth
        {
            min-width: 25px !important;
            max-width: 25px !important;
        }
        .challanTable td.challanimgtd
        {
            min-width: 19px !important;
            max-width: 19px !important;
            vertical-align: top;
            padding-top: 6px;
        }
        .gridviewWidth td:first-child
        {
            border-left-color: #999 !important;
        }
        .gridviewWidth tr:first-child td
        {
            border-top: 0px !important;
        }
        .gridviewWidth td:last-child
        {
            border-right-color: #999 !important;
        }
        
        .gridviewWidth tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        td.TypeWidth
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        td.DateWidth
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        td.PlusWidth
        {
            min-width: 20px !important;
            max-width: 20px !important;
        }
        td.ChallanWidth
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        td.ChallanWidth td
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        td.SuppWidth
        {
            min-width: 50px !important;
            max-width: 80px !important;
        }
        td.TadNameWidth
        {
            min-width: 130px !important;
            max-width: 130px !important;
            text-align: left;
            padding-left: 2px;
        }
        .headerSticky
        {
            width: 100% !important;
        }
        
        .btnSrv
        {
            cursor: pointer;
            background-color: #122bde;
            color: #f5f5f5 !important;
            width: 20px;
            font-size: 9px;
            border-radius: 20px;
            padding: 1px 2px;
            float: right;
            margin: 0 2px;
            text-align: center;
        }
        .btnCancel
        {
            cursor: pointer;
            background-color: #824007;
            color: #f5f5f5 !important;
            width: 38px;
            font-size: 9px;
            border-radius: 20px;
            padding: 2px 2px;
            float: right;
            margin: 0 2px;
        }
        .btnClosePo
        {
            cursor: pointer;
            background-color: #af0c0ce6;
            color: #f5f5f5 !important;
            width: 36px;
            font-size: 9px;
            border-radius: 20px;
            padding: 2px 2px;
            float: right;
            margin: 0 2px;
        }
        .btnlink
        {
            background: #99a91a;
            padding: 3px 5px;
            border-radius: 2px;
            color: #fff;
        }
        .btnlinkPe
        {
            /* background: #66b534;*/
            padding: 3px 5px;
            border-radius: 2px;
            color: #fff;
            text-decoration: underline;
            cursor: pointer;
            font-size: 11px;
            text-decoration: none;
        }
        .btnlinkRe
        {
            background: #c34a66;
            padding: 3px 5px;
            border-radius: 2px;
            color: #fff;
        }
        .btnlinkPe a:hover
        {
            color: yellow !important;
            text-decoration: underline;
        }
        .btnlinkRe a:hover
        {
            color: yellow !important;
        }
        .btnlink a
        {
            color: #f5f5f5 !important;
        }
        .btnlinkPe a
        {
            color: #f5f5f5 !important;
        }
        .btnlinkRe a
        {
            color: #f5f5f5 !important;
        }
        .btnlink a:hover
        {
            color: yellow !important;
        }
        a
        {
            text-decoration: none;
        }
        a:hover
        {
            text-decoration: none;
        }
        .ths th
        {
            height: 32px;
            border-left: 0px;
        }
        .ths th:first-child
        {
            border-left: 1px solid #999;
        }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        /*.table_width
        {
            width: 1313px;
            max-height: 480px;
            min-height: 150px;
            overflow-y:auto;
        }*/
        .m-t-8
        {
            margin-top: 8px;
        }
        .m-t-10
        {
            margin-top: 10px;
        }
        @media screen and (max-width: 1366px)
        {
            /*  #main_content
        {
            min-width: 1310px;
            max-width: 1366px;
            overflow:auto;
           
        }*/
            .m-t-8
            {
                margin-top: 0px;
            }
            .m-t-10
            {
                margin-top: 4px;
            }
        }
        .HideRaisebtn
        {
            display: none !important;
        }
        
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
        
        table
        {
            border-collapse: collapse;
        }
        
        .table-layout
        {
            text-align: center;
            border: 1px solid black;
            border-collapse: collapse;
            font-family: "Trebuchet MS";
            margin: 0 auto 0;
        }
        .table-layout td, .table-layout th
        {
            border: 1px solid grey;
            padding: 5px 5px 0;
        }
        .table-layout td
        {
            text-align: left;
        }
        .selected
        {
            color: red;
            background-color: yellow;
        }
        
        td.PotalQty
        {
            min-width: 130px !important;
            max-width: 130px !important;
        }
        td.PotalQty .PoQtyTable td.QtyWi
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        td.PotalQty .PoQtyTable td.bottonTD
        {
            min-width: 90px !important;
            max-width: 90px !important;
        }
        .highlighted
        {
            background: #f1eaf0 !important;
        }
        .Unhighlighted
        {
            background: #fff !important;
        }
        /*.TadNameWidth
   {
       background:#fff;
    }*/
        .do-not-disable
        {
            border-radius: 2px;
        }
        #ctl00_cph_main_content_upnl
        {
            margin-top: 5px;
            max-width: 1980px;
            width: 100%;
        }
        td.ColunWidthCredit
        {
            min-width: 40px !important;
            max-width: 40px !important;
        }
        .green
        {
            background-color: green;
        }
        .btnSrv
        {
            cursor: pointer;
            background-color: #122bde;
            color: #f5f5f5 !important;
            width: 20px;
            font-size: 9px;
            border-radius: 20px;
            padding: 1px 2px;
            float: right;
            margin: 0 2px;
        }
        td.TadNameWidth
        {
            background: #fff !important;
            border-left: 1px solid #999;
        }
        .rowBackCancel
        {
            background: #fbcba2;
        }
        .rowBackClose
        {
            background: #ffc9c6;
        }
        .txtLeft
        {
            text-align: left;
            padding-left: 2px;
        }
        .backColorYellow
        {
            background: #ffff80;
            display: block;
            padding: 3px 0px;
        }
        
        
        .Acctooltip
        {
            position: relative;
            display: inline-block;
            width: 100%;
        }
        
        .Acctooltip .Acctooltiptext
        {
            visibility: hidden;
            position: absolute;
            top: -28px;
            left: -90px;
            width: auto;
            padding: 5px 8px;
            background: #767676;
            color: #fff;
            z-index: 9;
            font-size: 10px;
            height: auto;
            line-height: 12px;
            border-radius: 3px;
            white-space: pre-line;
            word-wrap: break-word;
            width: 350px;
        }
        
        .Acctooltip .Acctooltiptext::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 100px;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #565656 transparent transparent transparent;
        }
        
        .Acctooltip:hover .Acctooltiptext
        {
            visibility: visible;
        }
        [data-title]
        {
            position: relative;
        }
        
        [data-title]:hover::after
        {
            content: attr(data-title);
            position: absolute;
            top: 15px;
            left: 0px;
            min-width: 170px;
            padding: 5px 8px;
            background: #FF0000;
            color: #fff;
            z-index: 9;
            font-size: 10px;
            height: auto;
            line-height: 12px;
            border-radius: 3px;
            white-space: pre-line;
            word-wrap: break-word;
            text-align: left;
        }
        [data-title]:hover::before
        {
            content: '';
            position: absolute;
            bottom: -8px;
            left: 5px;
            display: inline-block;
            color: #fff;
            border: 8px solid transparent;
            border-bottom: 8px solid #565656;
        }
        .PlusWidth table td:first-child
        {
            border-left: 0px !important;
        }
        .SrNumberPopup
        {
            position: relative;
            display: inline-block;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .SrNumberPopup td span
        {
            color: #575759;
        }
        .SrNumberPopup td
        {
            border: 0px !important;
            text-align: left;
            padding-left: 15px !important;
            padding-top: 3px;
        }
        .SrNumberPopup th
        {
            background: #39589c;
            border-bottom: 0px;
            color: #fff;
            font-size: 11px;
            padding: 3px 0px;
            border: 0px !important;
            text-align: left;
            padding-left: 15px;
        }
        
        .SrNumberPopup .SrNoPopupContent
        {
            visibility: hidden;
            width: 120px;
            background-color: #fff;
            color: #000;
            text-align: center;
            border-radius: 6px;
            padding: 0px 0px 5px;
            position: absolute;
            z-index: 1;
            top: 33px;
            left: -12px;
            margin-left: 20px;
            z-index: 10;
            margin-top: -17px;
            box-shadow: 1px 2px 3px 2px #ccc;
        }
        .SrNumberPopup .SrNoPopupContent::after
        {
            content: "";
            position: absolute;
            top: 1px;
            left: 0%;
            margin-left: -18px;
            border-width: 9px;
            border-style: solid;
            border-color: transparent #39589c transparent transparent;
        }
        
        .SrNumberPopup .SrNoShow
        {
            visibility: visible;
        }
        .SrNoPopupContent tr:nth-child(odd)
        {
            background: #f1eaf0;
        }
        .AccessoryInspection
        {
            width: 1210px !important;
        }
        
        
        .RaiseDebitTooltip
        {
            position: relative;
            display: inline-block;
            width: 100%;
        }
        
        .RaiseDebitTooltip .RaiseDebitTooltipText
        {
            visibility: hidden;
            position: absolute;
            top: -42px;
            left: -90px;
            width: auto;
            padding: 5px 8px;
            background: #767676;
            color: #fff;
            z-index: 9;
            font-size: 10px;
            height: auto;
            line-height: 14px;
            border-radius: 3px;
            white-space: pre-line;
            word-wrap: break-word;
            width: 100px;
            text-align: left;
        }
        
        .RaiseDebitTooltip .RaiseDebitTooltipText::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 100px;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #767676 transparent transparent transparent;
        }
        
        .RaiseDebitTooltip:hover .RaiseDebitTooltipText
        {
            visibility: visible;
        }
    </style>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <script src="../../CommonJquery/Js/jquery.autocomplete_new.js" type="text/javascript"></script>
    <script type="text/javascript">

        // location.reload();
        //    $(window).focus(function () {
        //        location.reload();
        //    });
        function PrintWindow() {
            var css = '@page { size: landscape; }',
          head = document.head || document.getElementsByTagName('head')[0],
          style = document.createElement('style');

            style.type = 'text/css';
            style.media = 'print';

            if (style.styleSheet) {
                style.styleSheet.cssText = css;
            } else {
                style.appendChild(document.createTextNode(css));
            }

            head.appendChild(style);

            window.print();
        }

        function ShowAccessorySendChallan(SupplierPoId, ChallanId) {
            //debugger;
            sURL = '../../Internal/Accessory/AccessoryExternalChallan.aspx?SupplierPoId=' + SupplierPoId + '&ChallanId=' + ChallanId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 590, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("AccessoryInspection");
            return false;
        }

        function ShowSrvPopup(SupplierPoId, SrvId, Status) {
            //debugger;        
            sURL = '../../Internal/Accessory/AccessoryPoSrv.aspx?SupplierPoId=' + SupplierPoId + '&SrvId=' + SrvId + '&Status=' + Status;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("AccessoryInspection");
            return false;
        }
        function ShowAccessInspectionPopup(SupplierPoId, SrvId, Status, UnitId) {
            //debugger;
            //alert();
            //        sURL = '../../Internal/Accessory/AccessoriesInspection.aspx?SupplierPoId=' + SupplierPoId + '&SrvId=' + SrvId + '&Status=' + Status + '&UnitId=' + UnitId;
            sURL = '../../Internal/Accessory/AccessoriesFourPointCheckInspection.aspx?SupplierPoId=' + SupplierPoId + '&SrvId=' + SrvId + '&Status=' + Status + '&UnitId=' + UnitId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 1205, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            //$('#sb-wrapper').addClass("AccessoryInspection");
            return false;
        }

        function ShowDebitNotePopup(SupplierPoId, DebitNoteId, AccessoryMasterId) {
            //debugger;
            sURL = '../../Internal/Accessory/AccessoryDebitNoteView.aspx?SupplierPoId=' + SupplierPoId + '&AccessoryMasterId=' + AccessoryMasterId;
            window.open(sURL, 'height=500,width=600,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no, _newtab');
            return false;
        }

        function ShowCreditNotePopup(SupplierPoId, CreditNoteId) {
            //debugger;
            sURL = '../../Internal/Accessory/AccessoryCreditNoteView.aspx?SupplierPoId=' + SupplierPoId;
            window.open(sURL, 'height=500,width=600,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no, _newtab');
            return false;
        }

        function SBClose() { }

        function PageReload() {
            //alert('reload');
            //location.reload(true);
            $('#<%= btnSearch.ClientID %>').click();
        }
        function fncCancelPO(elem, flag) {
            if (flag == "Close") {
                var isYes = confirm("Do you want to Closed PO");
            }
            else {
                var isYes = confirm("Do you want to Cancel PO");
            }
            //            return isYes;
            var SupplierPoId = elem;

            if (isYes == true) {
                $("#spinner").fadeIn("slow");
                proxy.invoke("AccessoryCancel_Close_PO", { SupplierPoId: SupplierPoId, field: flag }, function (result) {

                    if (flag == 'Close') {
                        $("#spinner").fadeOut("slow");
                        alert('PO has been closed successfully');
                        $('#<%= btnSearch.ClientID %>').click();
                    }
                    else {
                        proxy.invoke("SendAccessoryPoMail", { SupplierPO_Id: SupplierPoId }, function (result) {
                            $("#spinner").fadeOut("slow");
                            alert('PO has been Cancelled successfully !!');
                            $('#<%= btnSearch.ClientID %>').click();
                        }, onPageError, false, false);
                    }
                }, onPageError, false, false);
            }
            else {
                $("#spinner").fadeOut("slow");
            }
        }

        function ShowPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPoId, type) {
            //debugger;
            var url = '../../Internal/Accessory/AccessoryPurchaseOrderView.aspx?AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&SupplierPoId=' + SupplierPoId + '&AccessoryType=' + type + '&FromPage=' + 2;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("AccessoryInspection");
            return false;
        }
        function SBClose() { }
        function ShowSerialNo(elem) {
            $(".SrNoPopupContent").css('visibility', 'hidden');
            var Ids = elem.id;
            var CId = Ids.split("_")[5]
            //              var popup = document.getElementById("ctl00_cph_main_content_grdraisedpoworking_"+CId+"_grdpo");
            //              popup.classList.toggle("SrNoShow");
            $("#ctl00_cph_main_content_grdraisedpoworking_" + CId + "_grdpo").css('visibility', 'visible');
        }
        function closepop(elem) {
            $(".SrNoPopupContent").css('visibility', 'hidden');

        }

        function pageLoad() {
            var selectVal = $('#<%=ddlstatus.ClientID %>').val();
            // alert(selectVal);
            $('.gridviewWidth tr ').click(function () {
                $('.gridviewWidth tr').removeClass('highlighted');
                $('.gridviewWidth tr').removeClass('Unhighlighted');
                if (selectVal == 1) {
                    $(this).addClass('rowBackCancel');
                } else if (selectVal == 2) {
                    $(this).addClass('rowBackClose ');
                }
                else {
                    $(this).addClass('highlighted');
                }
            });
        }

        //below created by Girish on 2023-04-28
        function pageLoad(sender, args) {

            if ($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 1) {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Accessory Quality");
            }
            else if ($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 2) {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By ColorPrint");
            }
            else if ($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 3) {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Supplier");
            }
            else if ($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 4) {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By PO_Number");
            }

            var autoCompleteOptions = {
                dataType: "xml",
                datakey: "string",
                max: 100,
                width: "300px",
                cacheLength: 0,
                extraParams: {
                    DropDownType: $("#ctl00_cph_main_content_ddlSearchOption option:selected").val(),
                    POStatus: $("#ctl00_cph_main_content_ddlstatus option:selected").val(),
                    Type:"Accessory"
                }
            };

            $("input[type=text].Suggestion").autocomplete("/Webservices/iKandiService.asmx/GetAutoPopulateResult", autoCompleteOptions);

            $("#ctl00_cph_main_content_ddlSearchOption").change(function () {

                autoCompleteOptions.extraParams.DropDownType = $(this).val();

                //                    $('#ctl00_cph_main_content_txtsearchkeyswords').val('');         

                if ($(this).val() == 1) {
                    $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Accessory Quality");
                }
                else if ($(this).val() == 2) {
                    $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By ColorPrint");
                }
                else if ($(this).val() == 3) {
                    $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Supplier");
                }
                else if ($(this).val() == 4) {
                    $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By PO_Number");
                }
            });

            $("#ctl00_cph_main_content_ddlstatus").change(function () {

                autoCompleteOptions.extraParams.POStatus = $(this).val();

            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:HiddenField ID="hdnsetfocusid" runat="server" />
    <input type="hidden" id="div_position" name="div_position" />
    <div id="somediv" title="this is a dialog" style="display: none;">
        <iframe id="thedialog" width="900" height="600"></iframe>
    </div>
    <asp:ScriptManager ID="srptmng" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="upnl"
        DisplayAfter="0">
        <ProgressTemplate>
            <%--  <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />--%>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upnl" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="headerSticky">
                <span id="lnkPendingOrderSuppary" runat="server" style="position: absolute; left: 10px;
                    top: 0px;" class="btnlinkPe"><a href="PendingAccessorySummary.aspx" target="_blank">
                        Pending Order Summary</a></span><span id="lnkSupplierQuotation" runat="server" style="position: absolute;
                            left: 170px; top: 0px;" class="btnlinkPe"><a href="../SupplierQuotationScreen.aspx?SupplyType=3"
                                target="_blank">Supplier Quoted</a></span><span id="lnkRaisePo" runat="server" style="position: absolute;
                                    left: 280px; top: 0px;" class="btnlinkPe"><a href="AccessoryOrderPlacement.aspx"
                                        target="_blank">Raise PO</a> </span>Manage Accessory Purchase
                Order <span style="font-size: 12px;">(SRV, QC, Debit, Credit, Challan)</span>
            </div>
            <div id="srchdiv" style="width: 100%; z-index: 2; float: left; position: sticky;
                display: flex; align-items: center; top: 23px; background: #fff; padding: 5px 0px;"
                class="m-t-8">
                <asp:DropDownList ID="ddlSearchOption" runat="server" Style="padding: 3px 0;">
                    <asp:ListItem Value="1">Accessory Quality</asp:ListItem>
                    <asp:ListItem Value="2">Color Print</asp:ListItem>
                    <asp:ListItem Value="3">Supplier Name</asp:ListItem>
                    <asp:ListItem Value="4">PO Number</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtsearchkeyswords" class="Suggestion" runat="server" Style="width: 300px !important;
                    margin: 0px 3px 1px; padding-left: 4px; text-align: left;"></asp:TextBox>
                &nbsp; status
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem Value="-1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="0">Open</asp:ListItem>
                    <asp:ListItem Value="1">Cancel</asp:ListItem>
                    <asp:ListItem Value="2">Closed</asp:ListItem>
                    <%--<asp:ListItem Value="3">Archive</asp:ListItem>
                    <asp:ListItem Value="4">UnUsed Po</asp:ListItem>--%>
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                    OnClick="btnSearch_Click" Style="padding: 2px 7px; margin: 0px 10px 0px 2px;" />
                <div style="width: 55px !important; position: relative; float: left; padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #ffc9c6; float: left; border-radius: 50%;
                        border: 1px solid gray;"></span>&nbsp;<sapn style="color: gray; position: relative;
                            top: 0px; left: -1px">Close </sapn>
                </div>
                <div style="width: 65px; float: left; padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #fbcba2; float: left; border-radius: 50%;
                        border: 1px solid gray;"></span>&nbsp;
                    <sapn style="color: gray; position: relative; top: 0px; left: -4px">Cancel </sapn>
                </div>
            </div>
            <!--           <div style="width: 913px; float: left; position: sticky; top: 23px; background: #fff; padding: 5px 0px; z-index: 8">
                <div style="width: 55px !important; position: relative; float: left; padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #ffc9c6; float: left; border-radius: 50%; border: 1px solid gray;"></span>&nbsp;<sapn style="color: gray; position: relative; top: 0px; left: -1px">Close </sapn>
                </div>
                <div style="width: 65px; float: left; padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #fbcba2; float: left; border-radius: 50%; border: 1px solid gray;"></span>&nbsp;
                    <sapn style="color: gray; position: relative; top: 0px; left: -4px">Cancel </sapn>
                </div>
            </div>-->
            <div id="widthdiv" runat="server">
                <asp:GridView ID="grdraisedpoworking" AllowSorting="True" ShowHeader="true" ShowHeaderWhenEmpty="True"
                    runat="server" AutoGenerateColumns="False" HeaderStyle-Font-Names="Arial" OnRowCommand="grdraisedpoworking_OnRowCommand"
                    HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" OnRowDataBound="grdraisedpoworking_RowDataBound"
                    HeaderStyle-CssClass="ths" CssClass="gridviewWidth headertopfixed" Style="border-bottom: 0px;"
                    OnDataBound="grdraisedpoworking_DataBound">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality (Size)<br /> Color/Print">
                            <ItemStyle HorizontalAlign="Center" CssClass="TadNameWidth" Width="120px" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="TadNameWidth" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQuality" ForeColor="Blue" Text='<%# Eval("AccessoryName")%>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblcolorprint" Height="15px" Font-Bold="true" ForeColor="Black" Text='<%# Eval("Color_Print")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" CssClass="PlusWidth" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="margin: 0 auto;">
                                    <tr>
                                        <td style="min-width: 20px !important; border: 0px">
                                            <asp:LinkButton ID="lnkplus" Style="display: none" CommandName="Plus" OnClientClick="toggleplusminus(this,'../../images/plus-w.png')"
                                                CssClass="plusshow" Text="<img title='collapse' src='../../images/plus-w.png'  style='width:15px'/>"
                                                runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkminus" Style="display: none" CommandName="Minus" OnClientClick="toggleplusminus(this,'../../images/minus.png')"
                                                CssClass="plusshow" Text="<img title='collapse' src='../../images/minus.png' style='width:18px' />"
                                                runat="server"></asp:LinkButton><nobar></nobar>
                                            <asp:HiddenField ID="hdnSrvCount" runat="server" Value='<%# Eval("SrvCount")%>' />
                                        </td>
                                        <td style="min-width: 30px !important; border: 0px" runat="server" id="tdnewsrv">
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdnSupplierPoId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier PO <br/> (units)">
                            <ItemStyle HorizontalAlign="Center" CssClass="SuppWidth" Width="80px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="margin: 0 auto;">
                                    <tr>
                                        <td style="min-width: 30px !important; border: 0px !important;">
                                            <asp:Label ID="lblponumber" Style="cursor: pointer; color: Blue;" Text='<%# (Eval("PoNumber") == DBNull.Value  || (Eval("PoNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PoNumber").ToString().Trim() %>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="border-right: 0px; border: 0px !important; position: relative">
                                            <div class="SrNumberPopup">
                                                <asp:GridView ID="grdpo" ShowHeader="true" runat="server" AutoGenerateColumns="False"
                                                    EmptyDataText="No Record Found!" CssClass="SrNoPopupContent" HeaderStyle-Font-Names="Arial"
                                                    HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all">
                                                    <SelectedRowStyle BackColor="#A1DCF2" />
                                                    <RowStyle CssClass="DyedRowCount" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Serial Number <span style="position: absolute; right: 5px;"><a onclick="closepop(this)">
                                                                    X</a></span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="borderDy" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <tr>
                                            <td style="min-width: 46px !important; border: 0px; position: relative;">
                                                <div class="Acctooltip">
                                                    (<asp:Label ID="lblunits" Font-Bold="true" Text='<%# Eval("DefaultGarmentUnitName")%>'
                                                        runat="server"></asp:Label>)
                                                    <asp:Label ID="lblAccUnitTooltip" runat="server"></asp:Label>
                                                </div>
                                                <asp:HyperLink ID="hplk" runat="server" ToolTip="View Serial No." Style="cursor: pointer;
                                                    position: absolute; top: 0; right: -10px;" onclick="ShowSerialNo(this)" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                                    Target="_blank"></asp:HyperLink>
                                                <asp:HiddenField ID="hdAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>'
                                                    runat="server" />
                                                <asp:HiddenField ID="hdnAccessoryQualitySize" Value='<%# Eval("Size")%>' runat="server" />
                                                <asp:HiddenField ID="hdnColorprint" Value='<%# Eval("Color_Print")%>' runat="server" />
                                                <asp:HiddenField ID="hdnStatus" Value='<%# Eval("Status")%>' runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="min-width: 30px !important; border: 0px;">
                                                <asp:Label ID="lblbiplsign" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnIsAuthorizedSignatory" runat="server" Value='<%# Eval("IsAuthorizedSignatory")%>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="min-width: 30px !important; border: 0px;">
                                                <asp:Label ID="lblsuppliersign" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccesstype" Text='<%# Eval("AccessoryType")%>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnSendQty" Value='<%# Eval("SendQty")%>' runat="server" />
                                <asp:HiddenField ID="hdnTotalSendChallanQty" Value='<%# Eval("TotalSendChallanQty")%>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnGreigePassQty" Value='<%# Eval("GreigePassQty")%>' runat="server" />
                                <asp:HiddenField ID="hdnSrvReceiveqty" Value='<%# Convert.ToString(Eval("TotalQtyRecieved")) == "0" ? "" : Convert.ToDecimal(Eval("TotalQtyRecieved")).ToString("N0")%>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnTotalCheckedQty" Value='<%# Convert.ToString(Eval("TotalCheckedQty")) == "0" ? "" : Convert.ToDecimal(Eval("TotalCheckedQty")).ToString("N0")%>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnTotalPassQty" Value='<%# Convert.ToString(Eval("TotalPassQty")) == "0" ? "" : Convert.ToDecimal(Eval("TotalPassQty")).ToString("N0")%>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnTotalHoldQty" Value='<%# Convert.ToString(Eval("TotalHoldQty")) == "0" ? "" : Convert.ToDecimal(Eval("TotalHoldQty")).ToString("N0")%>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnTotalFailQty" Value='<%# Convert.ToString(Eval("TotalFailQty")) == "0" ? "" : Convert.ToDecimal(Eval("TotalFailQty")).ToString("N0")%>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="TypeWidth" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblSupplierName" Text='<%# Eval("SupplierName")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Placed On Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblplacedon" ForeColor="#000" Text='<%# (Convert.ToDateTime(Eval("PoDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PoDate")).ToString("dd MMM")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Cmitd.<br> Start Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblcommtdstartdate" ForeColor="#000" Text='<%# (Convert.ToDateTime(Eval("CommitedStartDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CommitedStartDate")).ToString("dd MMM")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Cmitd.<br> End Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblcommtdEnddate" ForeColor="#000" Text='<%# (Convert.ToDateTime(Eval("PoEta")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PoEta")).ToString("dd MMM")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Send Challan No.">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblsendchallanno" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit (Gate)">
                            <ItemStyle HorizontalAlign="Center" Width="55px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblunitgatenumber" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SRV No.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ChallanWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblChallanNo" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblbalanceQty" ForeColor="#7f4009" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total PO Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="PotalQty" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" class="PoQtyTable" style="width: 100%">
                                    <tr>
                                        <td class="QtyWi" style="border: 0px;">
                                            <asp:Label ID="lblTotalpoQty" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToDecimal(Eval("ReceivedQty")).ToString("N0")%>'
                                                runat="server" Style="float: left; padding-left: 2px;"></asp:Label>
                                        </td>
                                        <td style="text-align: center; border: 0px;" class="bottonTD">
                                            <asp:LinkButton ID="lnkCancel" Style="font-size: 11px; cursor: pointer; color: blue;
                                                display: none;" CssClass="test btnCancel" Text="Cancel" runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkClose" Style="font-size: 11px; cursor: pointer; color: blue;
                                                display: none;" CssClass="test btnClosePo" Text="Close" runat="server"></asp:LinkButton>
                                            <asp:Label ID="lblCloseMsg" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Qty. Rcvd.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbltotalqtyreceived" Text='<%# Convert.ToInt32(Eval("TotalQtyRecieved")) == 0 ? "" : Convert.ToDecimal(Eval("TotalQtyRecieved")).ToString("N0")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="send Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblsendQty" ForeColor="black" Font-Bold="true" Text='<%# Convert.ToString(Eval("SendQty")) == "0" ? "" : Convert.ToDecimal(Eval("SendQty")).ToString("N0")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SRV Qty. Rcvd.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblSrvReceiveqty" runat="server" Text='<%# Convert.ToInt32(Eval("TotalQtyRecieved")) == 0 ? "" : Convert.ToDecimal(Eval("TotalQtyRecieved")).ToString("N0")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Checked Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCheckedQty" CssClass="do-not-allow-typing" runat="server" Style="width: 84% !important;
                                    color: Blue;" Text='<%# Convert.ToInt32(Eval("TotalCheckedQty")) == 0 ? "" : Convert.ToDecimal(Eval("TotalCheckedQty")).ToString("N0")%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pass Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <div class="RaiseDebitTooltip">
                                    <asp:Label ID="lblPassqty" ForeColor="green" Text='<%# Convert.ToInt32(Eval("TotalPassQty")) == 0 ? "" : Convert.ToDecimal(Eval("TotalPassQty")).ToString("N0")%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblInspectionTootip" runat="server" Text=""></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="On Hold Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblOnHoldqty" Text='<%# Convert.ToInt32(Eval("TotalHoldQty")) == 0 ? "" : Convert.ToDecimal(Eval("TotalHoldQty")).ToString()%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fail Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblfailqty" Text='<%# Convert.ToInt32(Eval("TotalFailQty")) == 0 ? "" : Convert.ToDecimal(Eval("TotalFailQty")).ToString()%>'
                                    ForeColor="red" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Raise Debit <span style='text-transform: lowercase;'>And</span> SRV">
                            <ItemStyle CssClass="txtLeft" Width="83px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDebitNote" runat="server" Text="Debit Note"></asp:Label>
                                <asp:LinkButton ID="lnkSrv" CssClass="test btnSrv" Text="Srv" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Raise credit note">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidthCredit" Width="60px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                    <tr runat="server" id="tdsrv">
                                        <td style='border: 0px;'>
                                            <%--<asp:Label ID="lblCreditNote" runat="server" Text="Credit Note"></asp:Label>--%>
                                            <asp:Image ID="imgEdit" Style="position: relative; top: -2px;" ImageUrl="../../images/edit.png"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" class="GSTTAbleEmp" cellspacing="0" style="max-width: 100%;
                            min-width: 100%; border-top: 0px solid !important;">
                            <tr>
                                <th style="">
                                    Accessory Quality (Size) Color/Print
                                </th>
                                <th>
                                </th>
                                <th>
                                    Supplier PO (Units)
                                </th>
                                <th style="">
                                    Type
                                </th>
                                <th style="">
                                    Supplier Name
                                </th>
                                <th style="">
                                    Placed On Date
                                </th>
                                <th style="">
                                    Cmitd. Start Date
                                </th>
                                <th>
                                    Cmitd. End Date
                                </th>
                                <th>
                                    Send Challan No.
                                </th>
                                <th>
                                    Unit (Gate)
                                </th>
                                <th>
                                    SRV No.
                                </th>
                                <th>
                                    Balance Qty.
                                </th>
                                <th>
                                    Total PO Qty.
                                </th>
                                <th>
                                    Total Qty. Rcvd.
                                </th>
                                <th>
                                    Send Qty.
                                </th>
                                <th>
                                    SRV Qty. Rcvd.
                                </th>
                                <th>
                                    Checked Qty.
                                </th>
                                <th>
                                    Pass Qty.
                                </th>
                                <th>
                                    On Hold Qty.
                                </th>
                                <th>
                                    Fail Qty.
                                </th>
                                <th>
                                    Raise Debit And SRV
                                </th>
                                <th>
                                    Credit Note
                                </th>
                            </tr>
                            <tr>
                                <td colspan="22">
                                    <img src='../../images/sorry.png' />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnshow" runat="server" Style="display: none;" CssClass="btnshowsrv"
        OnClick="btnshow_Click" />
    <asp:Button ID="btnPrint" runat="server" OnClientClick="PrintWindow();" Text="Print"
        CssClass="printButtonHide print da_submit_button" />
</asp:Content>
