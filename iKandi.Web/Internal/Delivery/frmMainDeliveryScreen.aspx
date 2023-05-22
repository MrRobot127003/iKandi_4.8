<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMainDeliveryScreen.aspx.cs"
    Inherits="iKandi.Web.Internal.Delivery.frmMainDeliveryScreen" %>

<%@ Register Src="../../UserControls/Forms/PackingDelivery.ascx" TagName="psckingDelivery"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="../../css/technical-module.css" />
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>
    
    <style type="text/css">
        

  
 
</style>

    <script type="text/javascript">

        


     function pageLoad() {
         var devliaryj = jQuery.noConflict();        

         devliaryj('input.do-not-allow-typing, textarea.do-not-allow-typing').keydown(function () { return false; });
         devliaryj(".th").datepicker({ dateFormat: 'dd M y (D)' });

         if (Flag == 'CONSOLIDATION') {

             jQuery(".shipConsolidate").hide();
             jQuery(".widthTable").css("width", "auto");
             jQuery(".fieldsetPacking").show();

         }
         else {
             jQuery(".fieldsetPacking").removeClass("fieldsetPacking1");
             jQuery(".widthTable").removeClass("widthTable1");
             jQuery("div").removeClass("divSearch1");
             jQuery(".shipConsolidate").show();
             jQuery(".fieldsetPacking").hide();
             jQuery(".widthTable").css("width", "100%");
         }

         if (Flag == 'INVOICEPAYMENT') {
             jQuery(".divpacking").hide();

             //             jQuery(".modal").show();

             
         }
         else
         { jQuery(".divpacking").show(); }

       
     
     }
    
     function isNumber(evt) {
         evt = (evt) ? evt : window.event;
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         return true;
     }
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
             return false;

         return true;
     }
     function fun_AllowOnlyAmountAndDot(txt) {
         if (event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46) {
             var txtbx = document.getElementById(txt);
             var amount = document.getElementById(txt).value;
             var present = 0;
             var count = 0;

             if (amount.indexOf(".", present) || amount.indexOf(".", present + 1));
             {
                 // alert('0');
             }

             /*if(amount.length==2)
             {
             if(event.keyCode != 46)
             return false;
             }*/
             do {
                 present = amount.indexOf(".", present);
                 if (present != -1) {
                     count++;
                     present++;
                 }
             }
             while (present != -1);
             if (present == -1 && amount.length == 0 && event.keyCode == 46) {
                 event.keyCode = 0;
                 //alert("Wrong position of decimal point not  allowed !!");
                 return false;
             }

             if (count >= 1 && event.keyCode == 46) {

                 event.keyCode = 0;
                 //alert("Only one decimal point is allowed !!");
                 return false;
             }
             if (count == 1) {
                 var lastdigits = amount.substring(amount.indexOf(".") + 1, amount.length);
                 if (lastdigits.length >= 2) {
                     //alert("Two decimal places only allowed");
                     event.keyCode = 0;
                     return false;
                 }
             }
             return true;
         }
         else {
             event.keyCode = 0;
             //alert("Only Numbers with dot allowed !!");
             return false;
         }

     }
    
     //int ShipemntPkID,string OldBankRefNo,string NewBankRefNo
//     function UpdateBankRefNo(InvoiceID, OldBankRefNo, NewBankRefNo) {
//         var url = "../../Webservices/iKandiService.asmx";
//         $.ajax({
//             type: "POST",
//             url: url + "/UpdateBankRefNo",
//             data: "{ ShipemntPkID:'" + InvoiceID + "', OldBankRefNo:'" + OldBankRefNo + "', NewBankRefNo:'" + NewBankRefNo + "'}",
//             contentType: "application/json; charset=utf-8",
//             dataType: "json",
//             success: OnSuccessCall,
//             error: OnErrorCall
//         });
//         function OnSuccessCall(response) {
//             alert("Bank ref updated successfully");
//             document.getElementById("psckingDelivery1_btntrackedcancel").click();

//         }
//         function OnErrorCall(response) {

//             alert(response.status + " " + response.statusText);
//         }
//     }
    </script>
    <script type="text/javascript">
        //    $(function () {
        //        //debugger;
        //        $('input.do-not-allow-typing, textarea.do-not-allow-typing').keydown(function () { return false; });
        //        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
        //        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        //        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);



        //    });

        // updated code by bharat 8-jan-19

        jQuery(document).ready(function () {
            jQuery(window).scroll(function () {
                var height = jQuery(window).scrollTop();
                if (height > 200) {
                    jQuery('.headertop').show().addClass('topfixed');
                   jQuery('.headermain').hide();
                     
                }
                else {
                    jQuery('.headermain').show();
                    jQuery('.headertop').hide();
                }

            });
        })
        //end
    </script>
    <style type="text/css">
        input[type=text], textarea
        {
            border: 1px solid #cccccc !important;
        }
        .item_list table td
        {
            border-color: #f2f2f2;
        }
        .topfixed
        {
            position:fixed;
            top:0;
          }
       
    </style>
</head>

<body>



    <form id="form1" runat="server" enctype="multipart/form-data">

  


    <uc1:psckingDelivery ID="psckingDelivery1" runat="server" />
    </form>
</body>
</html>
