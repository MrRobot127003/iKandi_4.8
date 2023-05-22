<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCreditNotes.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FrmCreditNotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .FabricCreaditNote
        {
            max-width: 99.8%;
            margin: 0 auto;
            font-family: arial;
        }
        .top_heading
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
        
        .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .border_right
        {
            border-right: 1px solid #999 !important;
        }
        .border_left
        {
            border-left: 1px solid #999 !important;
        }
        .headerbold
        {
            background: #e4e2e2;
            text-align: center;
            border-right: 1px solid #999999;
        }
        .gridtable td
        {
            border-bottom: 1px solid #dbd8d8;
        }
        .txtwdth
        {
            width: 69%;
        }
        .txtbillwidth
        {
            width: 45%;
        }
        input
        {
            font-size: 10px !important;
        }
        .txtdatewidth
        {
            width: 54%;
        }
        .inputfildwidth
        {
            width: 95% !important;
        }
        
        .grdviewtable th
        {
            background: #e4e2e2;
            text-align: center;
            font-weight: 500;
            font-size: 12px !important;
            color: #575759;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 11px !important;
            border-color: #9999;
        }
        .grdviewtable td:nth-child(2)
        {
            text-align: left;
            padding-left: 5px;
        }
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
        }
        .emptytable td
        {
            text-align: center;
            font-size: 11px;
        }
        .grdviewtable
        {
            border-top: 0px;
            max-width: 100%;
            min-width: 100%;
        }
        .grdviewtable th
        {
            border-top: 0px;
            border-color: #999;
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
            line-height: 23px;
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
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        .footerClass td
        {
            border-bottom-color: #9999;
        }
        .footerClass td:first-child
        {
            border-left-color: #999;
            border-bottom-color: #999 !important;
        }
        .footerClass td:nth-child(2)
        {
            border-left-color: #999;
            border-bottom-color: #999 !important;
        }
        .footerClass td:last-child
        {
            border-right-color: #999;
        }
        a
        {
            text-decoration: none;
        }
        .bottomtable td
        {
            font-size: 11px;
        }
        .textCenter
        {
            text-align: center;
        }
        input[type='text']
        {
            font-size: 11px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: Arial;
            height: 12px;
            margin: 2px 0px;
        }
        .txtEditWidth
        {
            width: 97% !important;
            text-align: left;
        }
        .txtEditWidth2
        {
            width: 88% !important;
            text-align: center;
        }
        .TaskFabricTable
        {
            width: 800px !important;
            margin-top: 5px;
        }
        .EmptyRow td[colspan="6"]
        {
            padding: 0px 0px !important;
            border-top: 0px;
            border-color: #999;
        }
        .emptytable td input[type="text"]
        {
            text-align: left;
        }
        td input[type="text"].txtCenter
        {
            text-align: center;
        }
        /*
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
            .printHideButton
            {
                display: none;
            }
            .FabricCreaditNote
            {
                max-width: 99.8% !important;
            }
            .PrientClass
            {
                width: 618px !important;
            }
            .PrientClass1
            {
                width: 74px !important;
            }
            .PrientClass2
            {
                width: 75px !important;
            }
            .PrientClass3
            {
                width: 59px !important;
            }
        
            .PrientClass4
            {
                width: 56px !important;
            }
        }
        
        .indianCurr::after
        {
            content: "₹";
            color: green;
        }
        input[type=text], textarea
        {
            border: 1px solid #cccccc;
            text-transform: capitalize;
            font-size: 11px;
        }
        #sb-wrapper-inner
        {
            border: 5px solid #999;
            border-radius: 3px;
        }
        .txtGyay
        {
            color: Gray;
        }
        .txtCenter
        {
            text-align: center;
        }
        td[colspan="6"]
        {
            padding: 0px;
            border: 0px;
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
    <%-- <script type="text/javascript">

         var txtIGSTClientID = '<%=txtIGST.ClientID %>';
         var txtCGSTClientID = '<%=txtCGST.ClientID %>';
         var txtSGSTClientID = '<%=txtSGST.ClientID %>';
         var lblIGSTAmountClientID = '<%=lblIGSTAmount.ClientID %>';
         var lblCGSTAmountClientID = '<%=lblCGSTAmount.ClientID %>';
         var lblSGSTAmountClientID = '<%=lblSGSTAmount.ClientID %>';

         var hdnIGSTAmountClientID = '<%=hdnIGSTAmount.ClientID %>';
         var hdnCGSTAmountClientID = '<%=hdnCGSTAmount.ClientID %>';
         var hdnSGSTAmountClientID = '<%=hdnSGSTAmount.ClientID %>';
         var lblGrandTotalAmountClientID = '<%=lblGrandTotalAmount.ClientID %>';
         var hdnTotalAmount = '<%=hdnTotalAmount.ClientID %>';
         var hdnGrandTotalAmountClientID = '<%=hdnGrandTotalAmount.ClientID %>';
         var hdnBillAmountClientID = '<%=hdnBillAmount.ClientID %>';


         function CalculateGridAmount(obj, type) {
             //debugger;
             var TotalAmount = 0;

             var value = $(obj).val();
             if (value == 0) {
                 alert('this value can not be Empty or zero');
                 return false;
             }
             var TotalDebitQty = 0;
             var TotalDebitRate = 0;
             var IGSTAmount = 0;
             var CGSTAmount = 0;
             var SGSTAmount = 0;
             var GrandTotalAmount = 0;

             if (type == 'Empty') {
                 var gvId = "ctl01";
                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();

                 if (DebitQty == '')
                     DebitQty = 0;

                 if (DebitRate == '')
                     DebitRate = 0;

                 if ((DebitQty == 0) || (DebitRate == 0)) {
                     return false;
                 }
                 TotalDebitQty = DebitQty;
                 TotalDebitRate = DebitRate;

                 TotalAmount = parseInt(DebitQty) * parseInt(DebitRate);
                 $("#" + hdnTotalAmount).val(TotalAmount);

                 $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text(TotalAmount);
                 $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount);
             }
             if (type == 'Edit') {
                 var Ids = obj.id;
                 var gvId = Ids.split("_")[1].substr(3);

                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();

                 if (DebitQty == '')
                     DebitQty = 0;

                 if (DebitRate == '')
                     DebitRate = 0;

                 if ((DebitQty == 0) || (DebitRate == 0)) {
                     return false;
                 }
                 TotalDebitQty = DebitQty;
                 TotalDebitRate = DebitRate;

                 var EditAmount = parseInt(DebitQty) * parseInt(DebitRate);
                 $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text(EditAmount);
                 $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount);

                 var GridRow = $(".gvRow").length;
                 var RowId = 0;
                 gvId = '';
                 for (var row = 1; row <= GridRow; row++) {
                     RowId = parseInt(row) + 1;
                     if (RowId < 10)
                         gvId = 'ctl0' + RowId;
                     else
                         gvId = 'ctl' + RowId;

                     var Amount = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount" + "']").val();

                     TotalAmount = parseInt(TotalAmount) + parseInt(Amount);
                 }

                 //TotalAmount = $("#" + hdnTotalAmount).val();
                 TotalAmount = parseInt(TotalAmount) + parseInt(EditAmount);
                 $("#" + hdnTotalAmount).val(TotalAmount);


             }
             if (type == 'Footer') {
                 var GridRow = $(".grdRow").length;
                 var RowId = parseInt(GridRow) + 2;
                 var gvId;
                 if (RowId < 10)
                     gvId = 'ctl0' + RowId;
                 else
                     gvId = 'ctl' + RowId;

                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();

                 if (DebitQty == '')
                     DebitQty = 0;

                 if (DebitRate == '')
                     DebitRate = 0;

                 if ((DebitQty == 0) || (DebitRate == 0)) {
                     return false;
                 }
                 TotalDebitQty = DebitQty;
                 TotalDebitRate = DebitRate;

                 var FooterAmount = parseInt(DebitQty) * parseInt(DebitRate);
                 TotalAmount = $("#" + hdnTotalAmount).val();
                 TotalAmount = parseInt(TotalAmount) + parseInt(FooterAmount);
                 $("#" + hdnTotalAmount).val(TotalAmount);

                 $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text(FooterAmount);
                 $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount);

             }

             var GSTRate = $("#" + txtIGSTClientID).val();
             var GSTRate = $("#" + txtIGSTClientID).val();
             if ((GSTRate == '') || (GSTRate == '0')) {
                 $("#" + hdnIGSTAmountClientID).val(0);
                 $("#" + lblIGSTAmountClientID).text('');
             }
             else {
                 var Amount = Math.round((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100);
                 $("#" + hdnIGSTAmountClientID).val(Amount);
                 $("#" + lblIGSTAmountClientID).text(Amount);
             }

             var CGSTRate = $("#" + txtCGSTClientID).val();
             if ((CGSTRate == '') || (CGSTRate == '0')) {
                 $("#" + hdnCGSTAmountClientID).val(0);
                 $("#" + lblCGSTAmountClientID).text('');
             }
             else {
                 var Amount = Math.round((parseFloat(CGSTRate) * parseFloat(TotalAmount)) / 100);
                 $("#" + hdnCGSTAmountClientID).val(Amount);
                 $("#" + lblCGSTAmountClientID).text(Amount);
             }

             var SGSTRate = $("#" + txtSGSTClientID).val();
             var Amount = Math.round((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100);

             if ((SGSTRate == '') || (SGSTRate == '0')) {
                 $("#" + hdnSGSTAmountClientID).val(0);
                 $("#" + lblSGSTAmountClientID).text('');
             }
             else {
                 var Amount = Math.round((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100);
                 $("#" + hdnSGSTAmountClientID).val(Amount);
                 $("#" + lblSGSTAmountClientID).text(Amount);
             }

             IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
             if (IGSTAmount == null)
                 IGSTAmount = 0;

             CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
             if (CGSTAmount == null)
                 CGSTAmount = 0;

             SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
             if (SGSTAmount == null)
                 SGSTAmount = 0;

             GrandTotalAmount = Math.round(parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount));

             var BillAmount = $("#" + hdnBillAmountClientID).val();
             if (BillAmount != "") {
                 if (parseInt(GrandTotalAmount) > parseInt(BillAmount)) {
                     alert('Total Amount can not be greater than bill amount');
                     return false;
                 }
             }

             $("#" + hdnGrandTotalAmountClientID).val((GrandTotalAmount));
             $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount);
         }

         function CalculateGSTAmount(obj, type) {
             //debugger;
             var TotalAmount = 0;
             TotalAmount = $("#" + hdnTotalAmount).val();
             if (parseInt(TotalAmount) > 0) {

                 if (type == 1) {
                     var GSTRate = $("#" + txtIGSTClientID).val();
                     if ((GSTRate == '') || (GSTRate == '0')) {
                         $("#" + hdnIGSTAmountClientID).val(0);
                         $("#" + lblIGSTAmountClientID).text('');
                     }
                     else {
                         var Amount = Math.round((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100);
                         $("#" + hdnIGSTAmountClientID).val(Amount);
                         $("#" + lblIGSTAmountClientID).text(Amount);
                     }
                 }

                 if (type == 2) {
                     var GSTRate = $("#" + txtCGSTClientID).val();
                     if ((GSTRate == '') || (GSTRate == '0')) {
                         $("#" + hdnCGSTAmountClientID).val(0);
                         $("#" + lblCGSTAmountClientID).text('');
                     }
                     else {
                         var Amount = Math.round((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100);
                         $("#" + hdnCGSTAmountClientID).val(Amount);
                         $("#" + lblCGSTAmountClientID).text(Amount);
                     }

                 }

                 if (type == 3) {
                     var GSTRate = $("#" + txtSGSTClientID).val();
                     var Amount = Math.round((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100);

                     if ((GSTRate == '') || (GSTRate == '0')) {
                         $("#" + hdnSGSTAmountClientID).val(0);
                         $("#" + lblSGSTAmountClientID).text('');
                     }
                     else {
                         var Amount = Math.round((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100);
                         $("#" + hdnSGSTAmountClientID).val(Amount);
                         $("#" + lblSGSTAmountClientID).text(Amount);
                     }

                 }

                 var IGSTAmount = 0;
                 var CGSTAmount = 0;
                 var SGSTAmount = 0;

                 IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
                 if (IGSTAmount == null)
                     IGSTAmount = 0;

                 CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
                 if (CGSTAmount == null)
                     CGSTAmount = 0;

                 SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
                 if (SGSTAmount == null)
                     SGSTAmount = 0;

                 var GrandTotalAmount = Math.round(parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount));

                 var BillAmount = $("#" + hdnBillAmountClientID).val();
                 if (BillAmount != "") {
                     if (parseInt(GrandTotalAmount) > parseInt(BillAmount)) {
                         alert('Total Amount can not be greater than bill amount');
                         return false;
                     }
                 }

                 $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount);
                 $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount);
             }
         }

         function ValidateGrid(obj, type) {
             //debugger;
             var DebitParticular = '';
             var DebitQty = '';
             var DebitRate = '';
             if (type == 'Empty') {
                 var gvId = "ctl01";
                 var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular_Empty" + "']").val();
                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();
             }
             if (type == 'Edit') {
                 var Ids = obj.id;
                 var gvId = Ids.split("_")[1].substr(3);

                 var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular" + "']").val();
                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();
             }
             if (type == 'Footer') {
                 var GridRow = $(".grdRow").length;
                 var RowId = parseInt(GridRow) + 2;
                 var gvId;
                 if (RowId < 10)
                     gvId = 'ctl0' + RowId;
                 else
                     gvId = 'ctl' + RowId;

                 var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticur_Footer" + "']").val();
                 var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                 var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();
             }

             if (DebitQty == '')
                 DebitQty = '0';

             if (DebitRate == '')
                 DebitRate = '0';

             if (DebitParticular == '') {
                 alert('Debit Particular can not be Empty');
                 return false;
             }
             if (DebitQty == '0') {
                 alert('Debit Quantity can not be Empty or zero');
                 return false;
             }
             if (DebitRate == '0') {
                 alert('Debit Rate can not be Empty or zero');
                 return false;
             }
         }

         function closePage() {
//             alert('Saved Successfully!');
               self.parent.Shadowbox.close()
             self.parent.parent.PageReload();
            // window.location.reload();             
            
         }

     </script>--%>
    <script type="text/javascript">
        function DisplaySendMail() {
            //debugger;
            if ($("#chkQtyCheckedBy").is(':checked')) {
                $("#dvSendMail").css("display", "")
                return false;
            }
            else {
                $("#dvSendMail").css("display", "none")
                return false;
            }

        }

        var txtIGSTClientID = '<%=txtIGST.ClientID %>';
        var txtCGSTClientID = '<%=txtCGST.ClientID %>';
        var txtSGSTClientID = '<%=txtSGST.ClientID %>';
        var lblIGSTAmountClientID = '<%=lblIGSTAmount.ClientID %>';
        var lblCGSTAmountClientID = '<%=lblCGSTAmount.ClientID %>';
        var lblSGSTAmountClientID = '<%=lblSGSTAmount.ClientID %>';

        var hdnIGSTAmountClientID = '<%=hdnIGSTAmount.ClientID %>';
        var hdnCGSTAmountClientID = '<%=hdnCGSTAmount.ClientID %>';
        var hdnSGSTAmountClientID = '<%=hdnSGSTAmount.ClientID %>';
        var lblGrandTotalAmountClientID = '<%=lblGrandTotalAmount.ClientID %>';
        var hdnTotalAmount = '<%=hdnTotalAmount.ClientID %>';
        var hdnGrandTotalAmountClientID = '<%=hdnGrandTotalAmount.ClientID %>';
        var hdnBillAmountClientID = '<%=hdnBillAmount.ClientID %>';
        var hdnRupeesClientID = '<%=hdnRupees.ClientID %>';


        //new code start
        $(document).ready(function () {
            //debugger;
            //            var GSTNo = $("#hdnGST_No").val();
            //            if (GSTNo == "") {
            //                $('.clsIGST').css("display", "display");
            //                $('.clsCGST_SGST').css("display", "display");
            //            }
            //            else {
            //                if (GSTNo != "") {
            //                    var stateId = GSTNo.substr(0, 2);

            //                    if (stateId == '09') {
            //                        $('.clsIGST').css("display", "none");
            //                        $('.clsCGST_SGST').css("display", "display");
            //                    }
            //                    else {
            //                        $('.clsIGST').css("display", "display");
            //                        $('.clsCGST_SGST').css("display", "none");
            //                    }
            //                }
            //            }
        })

        function HideShowGST() {
            //            alert("Hello");
            //            debugger;
            //            var GSTNo = $("#hdnGST_No").val();
            //            if (GSTNo == "" || GSTNo == "0") {
            //                $('.clsIGST').css("display", "display");
            //                $('.clsCGST_SGST').css("display", "display");
            //            }
            //            else {
            //                if (GSTNo != "") {
            //                    var stateId = GSTNo.substr(0, 2);

            //                    if (stateId == '09') {
            //                        $('.clsIGST').css("display", "none");
            //                        $('.clsCGST_SGST').css("display", "display");
            //                    }
            //                    else {
            //                        $('.clsIGST').css("display", "display");
            //                        $('.clsCGST_SGST').css("display", "none");
            //                    }
            //                }
            //            }
        }
        //new code end


        function CalculateGridAmount(obj, type) {
            //debugger;
            var TotalAmount = 0;
            var value = $(obj).val();
            if (value == 0) {
                alert('this value can not be Empty or zero');
                obj.value = obj.defaultValue;
                return false;
            }

            var seq = obj.id.split("_")[1];


            var TotalDebitQty = 0;
            var TotalDebitRate = 0;
            var IGSTAmount = 0;
            var CGSTAmount = 0;
            var SGSTAmount = 0;
            var GrandTotalAmount = 0;

            if (type == 'Empty') {
                var gvId = "ctl01";
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                if ((DebitQty == 0) || (DebitRate == 0)) {
                    return false;
                }
                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                TotalAmount = parseFloat(parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1));
                // $("#" + hdnTotalAmount).val(TotalAmount);

                //                $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text(TotalAmount);
                //                $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount);
            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                if ((DebitQty == 0) || (DebitRate == 0)) {
                    return false;
                }
                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                var EditAmount = parseFloat((parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1)));
                //                $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text(EditAmount);
                //                $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount);

                var GridRow = $(".gvRow").length;
                var RowId = 0;
                gvId = '';
                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;


                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;
                    if (seq != gvId) {
                        var Amount = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount" + "']").val();
                        TotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(Amount)).toFixed(1));
                    }
                }

                TotalAmount = parseFloat(TotalAmount) + parseFloat(EditAmount);
                // $("#" + hdnTotalAmount).val(TotalAmount);
            }
            if (type == 'Footer') {
                var GridRow = $(".gvRow").length;
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                if ((DebitQty == 0) || (DebitRate == 0)) {
                    return false;
                }
                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                var FooterAmount = parseFloat(parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1));
                TotalAmount = $("#" + hdnTotalAmount).val();
                TotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(FooterAmount)).toFixed(1));

                //$("#" + hdnTotalAmount).val(TotalAmount);

                //                $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text(FooterAmount);
                //                $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount);

            }



            var GSTRate = $("#" + txtIGSTClientID).val();
            var GSTRate = $("#" + txtIGSTClientID).val();
            if ((GSTRate == '') || (GSTRate == '0')) {
                $("#" + hdnIGSTAmountClientID).val(0);
                $("#" + lblIGSTAmountClientID).text('');
            }
            else {
                var Amount = parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                $("#" + hdnIGSTAmountClientID).val(Amount);
                //                $("#" + lblIGSTAmountClientID).text(Amount);
            }

            var CGSTRate = $("#" + txtCGSTClientID).val();
            if ((CGSTRate == '') || (CGSTRate == '0')) {
                $("#" + hdnCGSTAmountClientID).val(0);
                $("#" + lblCGSTAmountClientID).text('');
            }
            else {
                var Amount = parseFloat(parseFloat((parseFloat(CGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                $("#" + hdnCGSTAmountClientID).val(Amount);
                //                $("#" + lblCGSTAmountClientID).text(Amount);
            }

            var SGSTRate = $("#" + txtSGSTClientID).val();
            var Amount = parseFloat(parseFloat((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));

            if ((SGSTRate == '') || (SGSTRate == '0')) {
                $("#" + hdnSGSTAmountClientID).val(0);
                $("#" + lblSGSTAmountClientID).text('');
            }
            else {
                var Amount = parseFloat(parseFloat((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                $("#" + hdnSGSTAmountClientID).val(Amount);
                //                $("#" + lblSGSTAmountClientID).text(Amount);
            }

            IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
            if (IGSTAmount == null)
                IGSTAmount = 0;

            CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
            if (CGSTAmount == null)
                CGSTAmount = 0;

            SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
            if (SGSTAmount == null)
                SGSTAmount = 0;

            GrandTotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount)).toFixed(1));

            var BillAmount = $("#" + hdnBillAmountClientID).val();
            //  alert(GrandTotalAmount + ' ' + BillAmount)
            if (BillAmount != "") {
                if (parseFloat(GrandTotalAmount) > parseFloat(BillAmount)) {
                    alert('Total Amount can not be greater than bill amount');
                    //                    alert(obj.defaultValue)
                    obj.value = obj.defaultValue;
                    // return false
                    // $("#btnRefresh").click();

                }
                else {
                    //debugger;
                    $("#" + hdnIGSTAmountClientID).val("0");
                    $("#" + hdnCGSTAmountClientID).val("0");
                    $("#" + hdnSGSTAmountClientID).val("0");
                    TotalAmount = 0;


                    TotalDebitQty = 0;
                    TotalDebitRate = 0;
                    IGSTAmount = 0;
                    CGSTAmount = 0;
                    SGSTAmount = 0;
                    GrandTotalAmount = 0;



                    if (type == 'Empty') {
                        var gvId = "ctl01";
                        var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                        var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();

                        if (DebitQty == '')
                            DebitQty = 0;

                        if (DebitRate == '')
                            DebitRate = 0;

                        if ((DebitQty == 0) || (DebitRate == 0)) {
                            return false;
                        }
                        TotalDebitQty = DebitQty;
                        TotalDebitRate = DebitRate;

                        TotalAmount = parseFloat(parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1));
                        $("#" + hdnTotalAmount).val(TotalAmount);
                        //alert(TotalAmount)
                        $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text(TotalAmount);
                        $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount);
                    }
                    if (type == 'Edit') {
                        var Ids = obj.id;
                        var gvId = Ids.split("_")[1].substr(3);

                        var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                        var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();

                        if (DebitQty == '')
                            DebitQty = 0;

                        if (DebitRate == '')
                            DebitRate = 0;

                        if ((DebitQty == 0) || (DebitRate == 0)) {
                            return false;
                        }
                        TotalDebitQty = DebitQty;
                        TotalDebitRate = DebitRate;


                        var EditAmount = parseFloat(parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1));
                        $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text(EditAmount);
                        $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount);

                        var GridRow = $(".gvRow").length;
                        var RowId = 0;
                        gvId = '';
                        for (var row = 1; row <= GridRow; row++) {
                            RowId = parseInt(row) + 1;
                            if (RowId < 10)
                                gvId = 'ctl0' + RowId;
                            else
                                gvId = 'ctl' + RowId;

                            var Amount = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount" + "']").val();
                            TotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(Amount)).toFixed(1));
                        }

                        //TotalAmount = parseFloat(TotalAmount) + parseFloat(EditAmount);
                        $("#" + hdnTotalAmount).val(TotalAmount);
                    }
                    if (type == 'Footer') {
                        var GridRow = $(".gvRow").length;
                        var RowId = parseInt(GridRow) + 2;
                        var gvId;
                        if (RowId < 10)
                            gvId = 'ctl0' + RowId;
                        else
                            gvId = 'ctl' + RowId;

                        var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                        var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();

                        if (DebitQty == '')
                            DebitQty = 0;

                        if (DebitRate == '')
                            DebitRate = 0;

                        if ((DebitQty == 0) || (DebitRate == 0)) {
                            return false;
                        }
                        TotalDebitQty = DebitQty;
                        TotalDebitRate = DebitRate;

                        var FooterAmount = parseFloat(parseFloat(parseFloat(DebitQty) * parseFloat(DebitRate)).toFixed(1));
                        TotalAmount = $("#" + hdnTotalAmount).val();
                        //TotalAmount = ($("#" + lblGrandTotalAmount).text() == "" ? "0" : $("#" + lblGrandTotalAmount).text());
                        // alert("TotalAmount :" + TotalAmount + " " + "FooterAmount " + FooterAmount)
                        TotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(FooterAmount)).toFixed(1));
                        //alert(TotalAmount)
                        $("#" + hdnTotalAmount).val(TotalAmount);

                        $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text(FooterAmount);
                        $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount);

                    }

                    var GSTRate = $("#" + txtIGSTClientID).val();
                    var GSTRate = $("#" + txtIGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnIGSTAmountClientID).val(0);
                        $("#" + lblIGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                        $("#" + hdnIGSTAmountClientID).val(Amount);
                        $("#" + lblIGSTAmountClientID).text(Amount);
                    }

                    var CGSTRate = $("#" + txtCGSTClientID).val();
                    if ((CGSTRate == '') || (CGSTRate == '0')) {
                        $("#" + hdnCGSTAmountClientID).val(0);
                        $("#" + lblCGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat((parseFloat(CGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                        $("#" + hdnCGSTAmountClientID).val(Amount);
                        $("#" + lblCGSTAmountClientID).text(Amount);
                    }

                    var SGSTRate = $("#" + txtSGSTClientID).val();
                    var Amount = parseFloat(parseFloat((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));

                    if ((SGSTRate == '') || (SGSTRate == '0')) {
                        $("#" + hdnSGSTAmountClientID).val(0);
                        $("#" + lblSGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat((parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                        $("#" + hdnSGSTAmountClientID).val(Amount);
                        $("#" + lblSGSTAmountClientID).text(Amount);
                    }

                    IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
                    if (IGSTAmount == null)
                        IGSTAmount = 0;

                    CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
                    if (CGSTAmount == null)
                        CGSTAmount = 0;

                    SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
                    if (SGSTAmount == null)
                        SGSTAmount = 0;

                    GrandTotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount)).toFixed(1));

                    //  alert(GrandTotalAmount)
                    $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount);
                    $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount);
                    document.getElementById('lblrs').innerHTML = inWords(GrandTotalAmount);
                    //$("#" + hdnRupeesClientID).val(inWords(GrandTotalAmount));
                    $("#" + hdnRupeesClientID).val($('#lblrs').text());
                }
            }


        }

        function CalculateGSTAmount(obj, type) {
            //debugger;
            var TotalAmount = 0;
            TotalAmount = $("#" + hdnTotalAmount).val();
            if (parseFloat(TotalAmount) > 0) {

                if (type == 1) {
                    var GSTRate = $("#" + txtIGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnIGSTAmountClientID).val(0);
                        $("#" + lblIGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1)));
                        $("#" + hdnIGSTAmountClientID).val(Amount);
                        $("#" + lblIGSTAmountClientID).text(Amount);
                    }
                }

                if (type == 2) {
                    var GSTRate = $("#" + txtCGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnCGSTAmountClientID).val(0);
                        $("#" + lblCGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                        $("#" + hdnCGSTAmountClientID).val(Amount);
                        $("#" + lblCGSTAmountClientID).text(Amount);
                    }
                }

                if (type == 3) {
                    var GSTRate = $("#" + txtSGSTClientID).val();
                    var Amount = parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));

                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnSGSTAmountClientID).val(0);
                        $("#" + lblSGSTAmountClientID).text('');
                    }
                    else {
                        var Amount = parseFloat(parseFloat((parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100).toFixed(1));
                        $("#" + hdnSGSTAmountClientID).val(Amount);
                        $("#" + lblSGSTAmountClientID).text(Amount);
                    }
                }
                var IGSTAmount = 0;
                var CGSTAmount = 0;
                var SGSTAmount = 0;

                IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
                if (IGSTAmount == null)
                    IGSTAmount = 0;

                CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
                if (CGSTAmount == null)
                    CGSTAmount = 0;

                SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
                if (SGSTAmount == null)
                    SGSTAmount = 0;

                var GrandTotalAmount = parseFloat(parseFloat(parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount)).toFixed(1));

                var BillAmount = $("#" + hdnBillAmountClientID).val();

                if (BillAmount != "") {
                    if (parseFloat(GrandTotalAmount) > parseFloat(BillAmount)) {
                        alert('Total Amount can not be greater than bill amount');
                        $("#btnRefresh").click();
                    }
                }
                $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount);
                $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount);
                document.getElementById('lblrs').innerHTML = inWords(GrandTotalAmount);
                //$("#" + hdnRupeesClientID).val(inWords(GrandTotalAmount));
                $("#" + hdnRupeesClientID).val($('#lblrs').text());
            }
        }

        function ValidateGrid(obj, type) {
            //debugger;
            var DebitParticular = '';
            var DebitQty = '';
            var DebitRate = '';
            if (type == 'Empty') {
                var gvId = "ctl01";
                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular_Empty" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();
            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();
            }
            if (type == 'Footer') {
                var GridRow = $(".gvRow").length;
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticur_Footer" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();
            }

            if (DebitQty == '')
                DebitQty = '0';

            if (DebitRate == '')
                DebitRate = '0';

            if (DebitParticular == '') {
                alert('Debit Particular can not be Empty');
                return false;
            }
            if (DebitQty == '0') {
                alert('Debit Quantity can not be Empty or zero');
                return false;
            }
            if (DebitRate == '0') {
                alert('Debit Rate can not be Empty or zero');
                return false;
            }
        }

        function ChangeBillNumber() {
            //debugger;
            var BillDetails = $("#ddlBillNo option:selected").text();
            var BillPart1 = BillDetails.split("(");
            var BillPart2 = BillPart1[1].split(")");
            var sAmount = BillPart2[0].trim();
            $("#" + hdnBillAmountClientID).val(sAmount);

            $("#btnRefresh").click();
        }

        function closePage() {
            // alert('Saved Successfully!');
            if ($("#hdnMailSentStatus").val() == "0") {
                alert('Saved Successfully!');
            }

            //            self.parent.parent.PageReload();
            //            self.parent.Shadowbox.close()
            window.parent.CallThisPage();
            window.parent.Shadowbox.close();
        }

        function pageLoad() {
            $('input').attr('autocomplete', 'off');
            //alert("aaa");
            $('.number').keypress(function (event) {
                var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();
                if ((event.which == 46) && (text.indexOf('.') == -1)) {
                    setTimeout(function () {
                        if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                            $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                        }
                    }, 1);
                }

                if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

            $('.number').bind("paste", function (e) {
                var text = e.originalEvent.clipboardData.getData('Text');
                if ($.isNumeric(text)) {
                    if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                        e.preventDefault();
                        $(this).val(text.substring(0, text.indexOf('.') + 3));
                    }
                }
                else {
                    e.preventDefault();
                }
            });
            document.getElementById('lblrs').innerHTML = inWords($("#" + lblGrandTotalAmountClientID).text());
            //$("#" + hdnRupeesClientID).val(inWords($("#" + lblGrandTotalAmountClientID).text()));
            $("#" + hdnRupeesClientID).val($('#lblrs').text());
            var IsSignatureDone = '<%=this.IsSignatureDone %>';
            if (IsSignatureDone == 1) {
                // $('#mydiv').find('input, textarea, button, select').attr('disabled', 'disabled');
                $("input, textarea, button, select link ").attr("disabled", "disabled");
                $("#grdAccessoryDebitNot").attr("disabled", "disabled");
                $("#rbtnYes").removeAttr('disabled');
                $("#rbtnNo").removeAttr('disabled');
                $("#btnSubmit").removeAttr('disabled');


                //                $("a").hide();
                $("a").attr("href", "javascript:void(0);")
                $("a").attr("onclick", "javascript:void(0);")
            }
            //            var GSTNo = $("#hdnGST_No").val();
            //            if (GSTNo == "") {
            //                $('.clsIGST').css("display", "display");
            //                $('.clsCGST_SGST').css("display", "display");
            //            }
            //            else {
            //                if (GSTNo != "") {
            //                    var stateId = GSTNo.substr(0, 2);

            //                    if (stateId == '09') {
            //                        $('.clsIGST').css("display", "none");
            //                        $('.clsCGST_SGST').css("display", "display");
            //                    }
            //                    else {
            //                        $('.clsIGST').css("display", "display");
            //                        $('.clsCGST_SGST').css("display", "none");
            //                    }
            //                }
            //            }
        }
        function DisableButton() {
            document.getElementById("<%=btnSubmit.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
        //        var a = ['', 'one ', 'two ', 'three ', 'four ', 'five ', 'six ', 'seven ', 'eight ', 'nine ', 'ten ', 'eleven ', 'twelve ', 'thirteen ', 'fourteen ', 'fifteen ', 'sixteen ', 'seventeen ', 'eighteen ', 'nineteen '];
        //        var b = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

        //        function inWords(num) {
        //            if ((num = num.toString()).length > 9) return 'overflow';
        //            n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
        //            if (!n) return; var str = '';
        //            str += (n[1] != 0) ? (a[Number(n[1])] || b[n[1][0]] + ' ' + a[n[1][1]]) + 'crore ' : '';
        //            str += (n[2] != 0) ? (a[Number(n[2])] || b[n[2][0]] + ' ' + a[n[2][1]]) + 'lakh ' : '';
        //            str += (n[3] != 0) ? (a[Number(n[3])] || b[n[3][0]] + ' ' + a[n[3][1]]) + 'thousand ' : '';
        //            str += (n[4] != 0) ? (a[Number(n[4])] || b[n[4][0]] + ' ' + a[n[4][1]]) + 'hundred ' : '';
        //            str += (n[5] != 0) ? ((str != '') ? ' ' : '') + (a[Number(n[5])] || b[n[5][0]] + ' ' + a[n[5][1]]) + '' : '';
        //            str = str.charAt(0).toUpperCase() + str.slice(1);
        //            return str;
        //        }
        function inWords(number) {
            var digit = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
            var elevenSeries = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
            var countingByTens = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
            var shortScale = ['', 'thousand', 'million', 'billion', 'trillion'];

            number = number.toString();
            number = number.replace(/[\, ]/g, '');
            if (number != parseFloat(number))
                return '';


            //new code start
            var pieces = [];
            var LenAfterDot = 0;
            if (number.includes(".")) {
                pieces = number.split(".");
                LenAfterDot = pieces[1].length;
            }
            else {
                pieces = number;
            }
            //new code end
            //            //alert(LenAfterDot);
            //            if (LenAfterDot == 1) {
            //                number = number + '0';
            //            }

            var x = number.indexOf('.');
            if (x == -1)
                x = number.length;

            if (x > 15) return 'too big';

            var n = number.split('');
            var str = '';
            var sk = 0;
            for (var i = 0; i < x; i++) {
                if ((x - i) % 3 == 2) {
                    if (n[i] == '1') {
                        str += elevenSeries[Number(n[i + 1])] + ' ';
                        i++;
                        sk = 1;
                    }
                    else if (n[i] != 0) {
                        str += countingByTens[n[i] - 2] + ' ';
                        sk = 1;
                    }
                }
                else if (n[i] != 0) {
                    str += digit[n[i]] + ' ';
                    if ((x - i) % 3 == 0)
                        str += 'hundred ';
                    sk = 1;
                }
                if ((x - i) % 3 == 1) {
                    if (sk) str += shortScale[(x - i - 1) / 3] + ' ';
                    sk = 0;
                }
            }
            if (x != number.length) {
                var y = number.length;
                str += 'and ';
                for (var i = x + 1; i < y; i++)
                    str += digit[n[i]] + ' ';
            }
            str = str.replace(/\number+/g, ' ');
            //alert(str.trim().charAt(0).toUpperCase() + str.slice(1) + ".");
            if (LenAfterDot > 0) {
                //                if (str.slice(1) == 0) {
                //                    return str.trim().charAt(0).toUpperCase() + str.slice(2) + " paise";
                //                }
                //                else {
                return str.trim().charAt(0).toUpperCase() + str.slice(1) + " paise";
                //                }
            }
            else {
                return str.trim().charAt(0).toUpperCase() + str.slice(1)
            }
        }

    </script>
    <form id="form1" autocomplete="off" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div class="FabricCreaditNote">
                <asp:HiddenField ID="hdnrowcount" runat="server" />
                <asp:HiddenField ID="hdnDebitnotid" runat="server" />
                <asp:HiddenField ID="hdndbptids" runat="server" />
                <asp:HiddenField ID="hdnGST_No" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDebitNoteNumber" Value="0" runat="server" />
                <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnMailSentStatus" Value="0" runat="server" />
                <%--new line--%>
                <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999"
                    cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" class="top_heading">
                                Fabric Credit Note
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 125px;">
                                <div style="padding: 9px 7px">
                                    <img src="../../images/boutique-logo.png" />
                                </div>
                            </td>
                            <td style="width: auto; text-align: left; border-left: 0px; border-right: 1px solid lightgray;">
                                <%-- <span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA-201305 (U.P)</span><br />
                                <span class="address_head">Tel. +911206797979, Fax:- 6797999, mailto:E-mail-boutique@boutique.in</span>--%>
                                <div id="divbipladdress" runat="server">
                                </div>
                            </td>
                            <td style="font-size: 11px; width: 150px; padding-left: 5px; font-size: 11px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="color: gray">
                                            Credit Number: &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDebitNo" Style="font-size: 11px; font-weight: bold;" runat="server"
                                                Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="gridtable" style="max-width: 100%; width: 100%; border: 1px solid #999999;
                    border-bottom: 0px solid #999999; border-top-color: #9999;" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td style="font-size: 11px; padding: 6px; width: 50%; border-top-color: #dbd8d8;
                                border-right: 1px solid #dbd8d8;">
                                <span style="padding-bottom: 10px; color: gray; width: 75px; display: inline-block;">
                                    M/S:</span> <span>
                                        <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label></span>
                                <br>
                                <span style="padding-bottom: 10px; color: gray; width: 75px; display: inline-block;">
                                GST No:</span> <span>
                                <asp:Label ID="lblgstno" runat="server" Text=""></asp:Label>
                                </span>
                                <br>

                                <span style="padding-bottom: 10px; color: gray; width: 75px; display: inline-block;">
                                Address:</span>
                                <asp:Label ID="lbladdress" runat="server" 
                                    Style="display: inline-block; width: 275px; line-height: 15px; vertical-align: middle;" 
                                    Text=""></asp:Label>
                                </br>
                           
                            </td>
                            <td style="font-size: 11px; padding: 6px; width: 50%; border-top-color: #dbd8d8">
                                <span class="txtGyay" style="width: 135px; display: inline-block;">Date:</span>
                                <asp:TextBox ID="txtDate" runat="server" CssClass="th style-eta date_style txtwdth"
                                    Enabled="false" onkeypress="return false;" Style="outline: none; max-width: 130px;
                                    width: 100px; padding: 3px; margin: 10px 0; line-height: 12px;" Text=""></asp:TextBox>
                                <br />
                                <%-- <span class="txtGyay">Against Bill No.</span>--%>
                                <asp:DropDownList ID="ddltypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddltypes_SelectedIndexChanged"
                                    Style="border: 1px solid lightgray; color: gray; width: 135px;">
                                    <asp:ListItem Selected="True" Value="0">
                                       Against Debit Note No.
                                    </asp:ListItem>
                                    <asp:ListItem disabled="" Value="1">
                                                Against Bill No.
                                    </asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlBillNo" runat="server" CssClass="txt" onchange="javascript:ChangeBillNumber();"
                                    Style="border: 1px solid lightgray; width: initial;">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnBillAmount" runat="server" Value="0" />
                            </td>
                        </tr>
                    </thead>
                    <caption>
                        <tr>
                            <td colspan="4" style="padding: 5px 5px; font-size: 11px; border-bottom-color: #999">
                                We have Debited your account as per details given below:-
                            </td>
                        </tr>
                        </thead>
                    </caption>
                </table>
                <div>
                    <asp:GridView ID="grdAccessoryDebitNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                        OnRowDataBound="grdAccessoryDebitNot_RowDataBound" OnRowCommand="grdAccessoryDebitNot_RowCommand"
                        OnRowDeleting="grdAccessoryDebitNot_RowDeleting" ShowFooter="true" OnRowEditing="grdAccessoryDebitNot_RowEditing"
                        OnRowUpdating="grdAccessoryDebitNot_RowUpdating" OnRowCancelingEdit="grdAccessoryDebitNot_RowCancelingEdit">
                        <RowStyle CssClass="gvRow" />
                        <FooterStyle CssClass="footerClass" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnDebitnote" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnDebitnoteEdit" Value='<%# Container.DataItemIndex + 1 %>'
                                        runat="server" />
                                </EditItemTemplate>
                                <HeaderStyle Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Particulars">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitParticur" Style="text-transform: capitalize;" runat="server"
                                        Text='<%# Eval("ParticularName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitParticur" CssClass="txtEditWidth" runat="server" Text='<%# Eval("ParticularName") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnIdEdit" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitParticur_Footer" Width="97%" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="250" />
                                <FooterStyle Width="250" />
                                <HeaderStyle Width="250" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitQty" Style="text-transform: capitalize;" runat="server" Text='<%# Eval("DebitQuantity") %>'></asp:Label>
                                    <asp:Label ID="lblunits" Style="text-transform: capitalize;" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitQty" MaxLength="8" CssClass="txtEditWidth2" onchange="CalculateGridAmount(this, 'Edit')"
                                        onkeypress="return isNumberKey(event)" Text='<%# Eval("DebitQuantity") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitQty_Footer" onchange="CalculateGridAmount(this, 'Footer')"
                                        CssClass="txtEditWidth2" MaxLength="8" onkeypress="return isNumberKey(event)"
                                        runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="75" />
                                <HeaderStyle Width="75" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblDebitRate" runat="server" Text='<%# Eval("DebitRate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitRate" MaxLength="5" CssClass="txtEditWidth2 number" onchange="CalculateGridAmount(this, 'Edit')"
                                        runat="server" Text='<%# Eval("DebitRate") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitRate_Footer" CssClass="txtEditWidth2 number" onchange="CalculateGridAmount(this, 'Footer')"
                                        MaxLength="5" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle Width="90" />
                                <ItemStyle Width="90" />
                                <HeaderStyle Width="90" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnAmount" Value='<%# Eval("Amount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <span id="lblIgstACurrency" class="indianCurr"></span>
                                    <asp:Label ID="lblAmountEdit" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnAmountEdit" Value='<%# Eval("Amount") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div id="indianCurrS" runat="server">
                                    </div>
                                    <asp:Label ID="lblAmount_Footer" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnAmount_Footer" Value='<%# Eval("Amount") %>' runat="server" />
                                </FooterTemplate>
                                <ItemStyle Width="100" />
                                <HeaderStyle Width="100" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');HideShowGST()"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lkUpdate" runat="server" ValidationGroup="Edit" CausesValidation="true"
                                        OnClientClick="javascript:return ValidateGrid(this, 'Edit');HideShowGST()" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;"/>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton runat="server" ID="Submit" CommandName="Insert">
                                  <img src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="80" CssClass="border_right" />
                                <HeaderStyle Width="80" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" class="emptytable" cellspacing="0" width="100%" style="max-width: 983px;
                                border: 0px solid #999; min-width: 100%; border-color: #999; border-bottom-color: #9999">
                                <tr>
                                    <th style="width: 50px; border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                        Sr. No.
                                    </th>
                                    <th style="width: 250px; border-right: 1px solid #999; border-bottom: 1px solid #999;"
                                        class="PrientClass">
                                        Particulars
                                    </th>
                                    <th style="width: 75px; border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                        Quantity
                                    </th>
                                    <th style="width: 90px; border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                        Rate
                                    </th>
                                    <th style="width: 100px; border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                        Amount
                                    </th>
                                    <th style="width: 80px; border-bottom: 1px solid #999;">
                                        Action
                                    </th>
                                </tr>
                                <tr>
                                    <td style="border-right: 1px solid #9999">
                                        &nbsp;
                                    </td>
                                    <td style="border-right: 1px solid #9999">
                                        <asp:TextBox runat="server" ID="txtDebitParticular_Empty" Width="96%" CssClass="inputPartidwidth"
                                            Text=""></asp:TextBox>
                                    </td>
                                    <td style="border-right: 1px solid #9999">
                                        <asp:TextBox runat="server" ID="txtDebitQty_Empty" MaxLength="8" onkeypress="return isNumberKey(event)"
                                            Width="86%" CssClass="txtCenter" Text="" onchange="CalculateGridAmount(this, 'Empty')"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 1px solid #9999">
                                        <asp:TextBox runat="server" ID="txtDebitRate_Empty" MaxLength="5" Width="86%" CssClass="number txtCenter"
                                            Text="" onchange="CalculateGridAmount(this, 'Empty')"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 1px solid #9999">
                                        &nbsp;
                                        <asp:Label ID="lblAmount_Empty" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnAmount_Empty" Value="0" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Empty');"
                                            CommandName="AddEmpty">
                            <img src="../../images/add-butt.png" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div style="margin-bottom: -8px">
                    <table cellpadding="0" class="emptytable" cellspacing="0" style="max-width: 983px;
                        border-top: 0px solid !important; border-right-color: #999; border-left: 1px solid #9999;
                        min-width: 100%; margin-bottom: 10px;">
                        <tr id="tdIIGST" visible="false" runat="server" class="clsIGST">
                            <td style="width: 46.5%; border-right: 1px solid #999; border-bottom: 1px solid #9999;">
                            </td>
                            <td style="width: 75px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;
                                color: gray" class="PrientClass4">
                                IGST
                            </td>
                            <td style="width: 90px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;"
                                class="PrientClass3">
                                <asp:TextBox runat="server" ID="txtIGST" Enabled="false" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 1);"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="width: 100px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;"
                                class="PrientClass2">
                                <asp:Label ID="lblIgstACurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="width: 80px; border-right: 1px solid #999; border-bottom: 1px solid #9999;"
                                class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="clsCGST_SGST" visible="false" id="tdCGST" runat="server">
                            <td style="width: 46.5%; border-right: 1px solid #999; border-bottom: 1px solid #9999;">
                            </td>
                            <td style="width: 75px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;
                                color: gray">
                                CGST
                            </td>
                            <td style="width: 90px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;">
                                <asp:TextBox runat="server" ID="txtCGST" Enabled="false" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 2);"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="width: 100px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;">
                                <asp:Label ID="lblCGSTACurrentcy" runat="server"></asp:Label>
                                <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="width: 80px; border-right: 1px solid #999; border-bottom: 1px solid #9999;"
                                class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="clsCGST_SGST" visible="false" id="tdSGST" runat="server">
                            <td style="width: 46.5%; border-right: 1px solid #999; border-bottom: 1px solid #9999;">
                            </td>
                            <td style="width: 75px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;
                                color: gray">
                                SGST
                            </td>
                            <td style="width: 90px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;">
                                <asp:TextBox runat="server" Enabled="false" ID="txtSGST" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 3);"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="width: 100px; border-right: 1px solid #9999; border-bottom: 1px solid #9999;">
                                <asp:Label ID="lblSGSTACurrentcy" runat="server"></asp:Label>
                                <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="width: 80px; border-right: 1px solid #999; border-bottom: 1px solid #9999;"
                                class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; border-right: 1px solid #999; border-bottom: 1px solid #9999;">
                            </td>
                            <td style="border-right: 1px solid #9999; height: 18px; border-bottom: 1px solid #999;
                                color: gray">
                                Total
                            </td>
                            <%-- <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999; color: gray">
                            </td>--%>
                            <td style="width: 90px; border-right: 1px solid #9999; border-bottom: 1px solid #999;">
                                <asp:Label ID="lblGranToCurrency" runat="server" Visible="false"></asp:Label>
                                <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                            </td>
                            <td style="width: 100px; border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                <asp:Label ID="lblGrandTotalAmount_currency" class="gtotal" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblGrandTotalAmount" class="gtotal" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 80px; border-right: 1px solid #999; border-bottom: 1px solid #9999;"
                                class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- <div style="max-width: 100%; border-left:1px solid #999;border-right:1px solid #999; height:15px;"></div>--%>
                <div class="bottomtable">
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <%--<td style="width: 578px; border-bottom: 1px solid #999999; padding-left: 2px; color: gray;height: 20px;">
                                <span style="color: #000;font-weight: 600;" class="txtGray">Rupees</span>    
                                </td>--%>
                                <td style="width: 390px; border-bottom: 1px solid #999999; font-size: 11px">
                                    <span style="color: #000; font-weight: 600;" class="txtGray">Rupees</span>
                                    <asp:Label ID="lblrs" Font-Bold="true" runat="server" Style=""></asp:Label>
                                    <asp:HiddenField ID="hdnRupees" runat="server" />
                                    <%-- <asp:Label ID="lblRupees" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="max-width: 100%; width: 100%; border: none" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td style="text-align: center; padding-top: 15px;">
                                    <div class="form_buttom" style="float: left;">
                                        <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" OnClientClick="JavaScript:return Debitnote_Validation()"
                                            runat="server" Text="Save" OnClick="btnSubmit_Click" />
                                    </div>
                                    <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                        Close</div>
                                    <div class="btnPrint printHideButton" onclick="window.print();return false">
                                        Print</div>
                                    <div id="dvSendMail" style="width: 400px; font-weight: bold; top: 5px; display: none;"
                                        runat="server">
                                        &nbsp; &nbsp; Is E-Mail Send:
                                        <asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail" runat="server" />
                                        <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server" />
                                    </div>
                                </td>
                                <td style="text-align: center; width: 230px; padding-right: 10px">
                                    <br />
                                    <br />
                                    <span style="font-weight: 600">Boutique International Pvt. Ltd.</span>
                                    <div runat="server" style="float: inherit; margin-right: 57px;" id="divSignature2"
                                        visible="false">
                                        <span>
                                            <asp:Image ID="imgCheckerSig" runat="server" Height="40px" Width="110px" />
                                        </span>
                                        <br />
                                        <span>
                                            <asp:Label ID="lblCheckerName" runat="server" Style="line-height: 20px; padding-left: 10px;"></asp:Label>
                                        </span>
                                        <br />
                                        <span>
                                            <asp:Label ID="lblCheckedDate" runat="server" Style='padding-left: 10px;'></asp:Label>
                                        </span>
                                    </div>
                                    <div runat="server" id="divCheckBox2">
                                        <asp:HiddenField ID="hdnIsChecked" Value="0" runat="server" />
                                        <asp:CheckBox runat="server" Checked="false" ID="chkQtyCheckedBy" Style="position: relative;
                                            top: 4px; left: 5px" onclick="DisplaySendMail()" />
                                        <span style="position: relative;">(Signature)</span>
                                    </div>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <asp:Button ID="btnRefresh" Style="display: none;" runat="server" Text="" OnClick="btnRefresh_Click" />
                    <asp:Label ID="lblGstMsg" Visible="false" runat="server" Style="color: Red; font-weight: bold;"
                        Text=" GST No. not available for this Supplier, hence you can not raise Debit Note!"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
