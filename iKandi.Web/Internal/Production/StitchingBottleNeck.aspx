
<%@ Page Language="C#"  AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="StitchingBottleNeck.aspx.cs" Inherits="iKandi.Web.Internal.Production.StitchingBottleNeck" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi.css" />
 <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi1.css" />
 <style type="text/css">
 #grdBottleNeck th 
 {
     font-size:11px;     
 }
 .BackgroundColor
 {
     background-color:#f5f59f;
 }
 .duplicate {
    border: 1px solid red;
    color: red;
}
.romove
{
border: 1px solid #cccccc;    }
 </style>
</head>
<body> 

 <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script> 
    <script type="text/javascript" src="../../js/service.min.js"></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
  
     

   <script type="text/javascript">
       var hdnStyleIdClientID = '<%=hdnStyleId.ClientID %>';
       var serviceUrl = "../../Webservices/iKandiService.asmx";
      // var url = "../../Webservices/iKandiService.asmx";
       var proxy = new ServiceProxy(serviceUrl);

       
       function isNumber(evt) {
           evt = (evt) ? evt : window.event;
           var charCode = (evt.which) ? evt.which : evt.keyCode;
           if (charCode > 31 && (charCode < 48 || charCode > 57)) {
               return false;
           }
           return true;
       }


       $(function () {
           initializer();
//           var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
//           prmInstance.add_endRequest(function () {             
//               initializer();
//           });

       });
       function pageLoad() {
           initializer();
       }
       function initializer() {
           $(".clusterStyleNumber").autocomplete("/Webservices/iKandiService.asmx/GetOB_Operation_ByStyle_Autocompl", { dataType: "xml", datakey: "string", max: 100 });
           $(".clusterStyleNumber").result(function () {
               var This = $(this);
               var EnterVal = $(this).val();
              // alert(Faults);           
           });
       };
       function ValidateDuplicate(elem, type) {
           //debugger;
           var Ids = elem.id;
           var ElemId = Ids.split("_")[1];
           if (type == 'Footer') {

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection_Footer" + "']").val();
               var OBoperation = $(".ac_over").text();
              // alert(OBoperation);
               //alert($(OBoperation).text());
               var CombinedValue = ddlOBSection + OBoperation;
               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#grdBottleNeck_" + gvId + "_txtOBOpration_Item").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (CombinedValue.trim().toUpperCase() == CombinedValueRow.trim().toUpperCase()) {

                       alert('Operation already exist!');
                       $("#grdBottleNeck_" + gvId + "_txtOBOpration_Foter").val("");
                       return false;
                   }
               }
           } 
       }
       function ValidateFaults(elem, type) {
           // alert(type);
       
       var Ids = elem.id;
           var ElemId = Ids.split("_")[1];
           //debugger;
           if (type == 'Footer') {
                            //  debugger;
               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection_Footer" + "']").val();
               var OBoperation = $(".ac_over").text();
               if (OBoperation == "") {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration_Foter").val();

               }
               if ($("#grdBottleNeck_" + ElemId + "_txtOBOpration_Foter").val().length > $(".ac_over").text().length) {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration_Foter").val();
               }
               // alert(OBoperation);
               //alert($(OBoperation).text());
               var CombinedValue = ddlOBSection + OBoperation;
               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#grdBottleNeck_" + gvId + "_txtOBOpration_Item").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (CombinedValue.trim().toUpperCase() == CombinedValueRow.trim().toUpperCase()) {

                       alert('Operation already exist!');
                       $(elem).val("");
                       $(".ac_results").hide();
                       return false;
                   }
               }
           }


           else if (type == 'ROW') {
               //debugger;
                OBoperation = $(".ac_over").text();
               if (OBoperation == "") {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration_Item").val();

               }
               if ($("#grdBottleNeck_" + ElemId + "_txtOBOpration_Item").val().length > $(".ac_over").text().length) {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration_Item").val();
               }
               
           }
           else if (type == 'Empty') {
              // debugger;
                OBoperation = $(".ac_over").text();
               if (OBoperation == "") {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration__Empty").val();
               }
               if ($("#grdBottleNeck_" + ElemId + "_txtOBOpration__Empty").val().length > $(".ac_over").text().length) {
                   OBoperation = $("#grdBottleNeck_" + ElemId + "_txtOBOpration__Empty").val();
               }           
           }
            
           var id = elem.id;
           //           var vals = $(elem).val();
           var vals = OBoperation.trim();
                             
           var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
           var proxy = new ServiceProxy(serviceUrl);
           proxy.invoke("ValidateFactoryWorkSpace", { FactoryWorkSpace: vals }, function (result) {
               if (result == 'NOTEXISTS') {
                   //                   alert("Invalid OB operation name");
                   elem.value = elem.defaultValue;
               }                                             
           }, onPageError, false, false);

       }
       function ValidateFaults_cehck(elem) {
           var id = elem.id;
           var vals = $(elem).val();
           var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
           var proxy = new ServiceProxy(serviceUrl);
           proxy.invoke("ValidateFactoryWorkSpace", { FactoryWorkSpace: vals }, function (result) {
               if (result == 'NOTEXISTS') {
                   //                   alert("Invalid OB operation name");
                   elem.value = "";
               }
           }, onPageError, false, false);

       }
       function GetObNamefoter(elem, type) {
           //debugger;
           $('#' + elem.id).css('border', '1px solid #cccccc');
           $('#' + elem.id).css('background', '#FFFFFF');
           var id = elem.id;
           var ctl = elem.id.split('_')[2];
           var ctld = elem.id.split('_')[1];
           //alert(ctl);
           var e = "";
           var strUser = "";
           var ddl = "";
           if (type == 'Footer') {
               ddl = "grdBottleNeck_" + ctld + "_ddlOBSection_Footer";
               e = document.getElementById(ddl);
               strUser = e.options[e.selectedIndex].value;
           }
          else if (type == 'Item') {
              ddl = "grdBottleNeck_" + ctld + "_" + "ddlOBSection";
              e = document.getElementById(ddl);
              strUser = e.options[e.selectedIndex].value;
           }
          else if (type == 'Empty') {

              ddl = "grdBottleNeck_" + ctld + "_" + "hdnOBoperation_Empty";
              strUser= ($("#grdBottleNeck_" + ctld + "_hdnOBoperation_Empty").val());
               //ddl = "grdBottleNeck_" + ctld + "_" + "ddlOBoperation_Empty";

           }
          
           var StyleId = '<%=this.StyleID_Session %>';
//           alert($("#"+ddl).val());
           var obj = {};
           obj.ON = strUser;
           obj.styleid = StyleId;
           $.ajax({
               type: "POST",
               url: "StitchingBottleNeck.aspx/setsession",
               data: JSON.stringify(obj),
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (r) {
               }
           });
           return false;
       }             
       function ValidateDDlOBoperation(elem, type) {
          // debugger;
           var Ids = elem.id;
           var ElemId = Ids.split("_")[1];
          
           if (type == 'Footer') {
                          
               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection_Footer" + "']").val();
               var OBoperation = elem.options[elem.selectedIndex].value;
               var CombinedValue = ddlOBSection + OBoperation;              
               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation" + "']").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (CombinedValue == CombinedValueRow) {

                       alert('Operation already exist!');
                       $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBOperation_Footer" + "']").val("Select").attr("selected", "selected");
                       return false;
                   }
               }
           }

           if (type == 'Row') {
               var OBSectionPrev = $("#<%= grdBottleNeck.ClientID %> input[id*='" + ElemId + "_hdnOBSection" + "']").val();
               var OBOperationPrev = $("#<%= grdBottleNeck.ClientID %> input[id*='" + ElemId + "_hdnOBOperation" + "']").val();               

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection" + "']").val();
               var OBoperation = elem.options[elem.selectedIndex].value;
              
              // var PrevCombinedValue = OBSectionPrev + OBOperationPrev;

               var CombinedValue = ddlOBSection + OBoperation;
               //alert(CombinedValue);
               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation" + "']").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (ElemId != gvId) {

                       if (CombinedValue == CombinedValueRow) {

                           alert('Operation already exist!');

                           $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection" + "']").val(OBSectionPrev).attr("selected", "selected");
                           $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBOperation" + "']").val("Select").attr("selected", "selected");
                           return false;
                       }
                   }
               }
           }
       }
       
       function ValidateDDlOBoperation_txt(elem, type) {
           
           var Ids = elem.id;
           var ElemId = Ids.split("_")[1];
//           alert("ss");
           if (type == 'Footer') {

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection_Footer" + "']").val();

               var OBoperation = elem.options[elem.selectedIndex].value;

               var CombinedValue = ddlOBSection + OBoperation;

               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation" + "']").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (CombinedValue == CombinedValueRow) {

                       alert('Operation already exist!');
                       $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBOperation_Footer" + "']").val("Select").attr("selected", "selected");
                       return false;
                   }
               }
           }

           if (type == 'Row') {
               //debugger;
               var OBSectionPrev = $("#<%= grdBottleNeck.ClientID %> input[id*='" + ElemId + "_hdnOBSection" + "']").val();
               var OBOperationPrev = $("#<%= grdBottleNeck.ClientID %> input[id*='" + ElemId + "_hdnOBOperation" + "']").val();

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection" + "']").val();
               //               var OBoperation = elem.options[elem.selectedIndex].value;
               var OBoperation = $(elem).val();
               
               // var PrevCombinedValue = OBSectionPrev + OBOperationPrev;

               var CombinedValue = ddlOBSection + OBoperation;

               var RowId = 0;
               var gvId;
               var GridRow = $(".gvRow").length;

               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSectionRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   var ddlOBoperationRow = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_txtOBOpration_Item" + "']").val();
                   var CombinedValueRow = ddlOBSectionRow + ddlOBoperationRow;

                   if (ElemId != gvId) {

                       if (CombinedValue == CombinedValueRow) {

                           alert('Operation already exist!');

                           $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_ddlOBSection" + "']").val(OBSectionPrev).attr("selected", "selected");
                           $("#<%= grdBottleNeck.ClientID %> select[id*='" + ElemId + "_txtOBOpration_Item" + "']").val("");
                           return false;
                       }
                   }
               }
           }
       }
       function ValiDateEmptyData(elem) {
          // debugger;

           if ($('#<%= chkwk.ClientID %>').is(':checked') == false) {
              // alert('s');

               var Ids = elem.id;
               var gvId = Ids.split("_")[1];

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Empty" + "']").val();
               if (ddlOBSection == 'Select') {
                   alert('Please Select OB Section!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Empty" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var ddlOBoperation = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Empty" + "']").val();
               if (ddlOBoperation == 'Select') {
                   alert('Please Select OB Operation!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Empty" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").val();
               if ((AgreedQty == '') || (AgreedQty == '0')) {
                   alert('Please fill Tgt Agrd Qty!');
                   $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }
           }
           if ($('#<%= chkwk.ClientID %>').is(':checked') == true) {
//               alert('s');

               var Ids = elem.id;
               var gvId = Ids.split("_")[1];

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Empty" + "']").val();
               if (ddlOBSection == 'Select') {
                   alert('Please Select OB Section!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Empty" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var ddlOBoperation = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_txtOBOpration__Empty" + "']").val();
               if (ddlOBoperation == 'Select') {
                   alert('Please Enter OB Operation!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Empty" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").val();
               if ((AgreedQty == '') || (AgreedQty == '0')) {
                   alert('Please fill Tgt Agrd Qty!');
                   $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }
           }
       }

       function ValiDateFooterData(elem) {
           //debugger;
           if ($('#<%= chkwk.ClientID %>').is(':checked') == false) {
//               alert('A');

               var Ids = elem.id;
               var gvId = Ids.split("_")[1];

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Footer" + "']").val();
               if (ddlOBSection == 'Select') {
                   alert('Please Select OB Section!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var ddlOBoperation = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Footer" + "']").val();
               if (ddlOBoperation == 'Select') {
                   alert('Please Select OB Operation!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed_Footer" + "']").val();
               if ((AgreedQty == '') || (AgreedQty == '0')) {
                   alert('Please fill Tgt Agrd Qty!');
                   $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }
           }
           if ($('#<%= chkwk.ClientID %>').is(':checked') == true) {
               //alert('A');

               var Ids = elem.id;
               var gvId = Ids.split("_")[1];

               var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Footer" + "']").val();
               if (ddlOBSection == 'Select') {
                   alert('Please Select OB Section!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var ddlOBoperation = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_txtOBOpration_Foter" + "']").val();
               if (ddlOBoperation == '') {
                   alert('Please Enter OB Operation!');
                   $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }

               var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed_Footer" + "']").val();
               if ((AgreedQty == '') || (AgreedQty == '0')) {
                   alert('Please fill Tgt Agrd Qty!');
                   $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed_Footer" + "']").css({ 'background': '#f5f59f' });
                   return false;
               }
           }
       }

       function ValidateAllData() {
           //debugger;

           var OBoperation = '';          
           var RowId = 0;
           var gvId;
           var GridRow = $(".gvRow").length;
           if ($('#<%= chkwk.ClientID %>').is(':checked') == false) {
               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   if (ddlOBSection == 'Select') {
                       alert('Please Select OB Section!');
                       $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").css({ 'background': '#f5f59f' });
                       return false;
                   }

                   var ddlOBoperation = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation" + "']").val();
                   if (ddlOBoperation == 'Select') {
                       alert('Please Select OB Operation!');
                       $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBOperation" + "']").css({ 'background': '#f5f59f' });
                       return false;
                   }

                   var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").val();
                   if ((AgreedQty == '') || (AgreedQty == '0')) {
                       alert('Please fill Tgt Agrd Qty!');
                       $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").css({ 'background': '#f5f59f' });
                       return false;
                   }
               }
           }
           if ($('#<%= chkwk.ClientID %>').is(':checked') == true) {
               //debugger;
               for (var row = 1; row <= GridRow; row++) {
                   RowId = parseInt(row) + 1;
                   if (RowId < 10)
                       gvId = 'ctl0' + RowId;
                   else
                       gvId = 'ctl' + RowId;

                   var ddlOBSection = $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").val();
                   if (ddlOBSection == 'Select') {
                       alert('Please Select OB Section!');
                       $("#<%= grdBottleNeck.ClientID %> select[id*='" + gvId + "_ddlOBSection" + "']").css({ 'background': '#f5f59f' });
                       return false;
                   }

                   var txtOBoperation = $("#grdBottleNeck_" + gvId + "_txtOBOpration_Item").val(); 
                   if (txtOBoperation == '') {
                       alert('Please Enter OB Operation!');
                       $("#grdBottleNeck_" + gvId + "_txtOBOpration_Item").css({ 'background': '#f5f59f' });
                       return false;
                   }

                   var AgreedQty = $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").val();
                   if ((AgreedQty == '') || (AgreedQty == '0')) {
                       alert('Please fill Tgt Agrd Qty!');
                       $("#<%= grdBottleNeck.ClientID %> input[id*='" + gvId + "_txtAgreed" + "']").css({ 'background': '#f5f59f' });
                       return false;
                   }
               }
           }
       }
       function SavedSuccessfully() {
           alert('Saved Successfully.');           
           self.parent.Shadowbox.close();
       }
       function ErrorAlert(msg) {
           alert(msg);

       }
       function setempty(elem) {
           var id = elem.id;
           var subs = id.split("_")[1];
           var vals = $(elem).val();
           $("#grdBottleNeck_" + subs + "_hdnOBoperation_Empty").val(vals); 

    
          
           
       }
//       $(function () {
//           $("[id*=btnSubmit]").live("click", function () {
//               var errorText = "";
//               alert("yoyo");
//               debugger;
//               try {
//                   $(".clusterStyleNumber").each(function () {
//                       if (jQuery.trim($(this).text()) != "") {
//                           var text = $(this).val();
//                           $(".clusterStyleNumber").not($(this)).each(function () {
//                               if (text == jQuery.trim($(this).text())) {
//                                   errorText = "The text '" + text + "' appeared multiple times which is not allowed.";
//                                   throw "";
//                               }
//                           });
//                       }
//                   });
//               } catch (e) {
//                   alert(errorText);
//                   return false;
//               }
//           });
//       });
   </script> 

    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <asp:HiddenField ID="hdnfldVariable" runat="server" />
 <asp:CheckBox ID="chkwk" AutoPostBack="true" runat="server" Checked="true" 
            oncheckedchanged="chkwk_CheckedChanged" />  
            <span style="color: Red; text-align: left; font-size: 12px;">All * (Asterisk) Mark
        Fields Are Mandatory.</span>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
           
               
                
                        <div style="padding: 2px 0px; padding-left:0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                            font-size: 14px; text-transform: none; width:97%; margin:0px auto; margin-right:15px; text-align:center;">
                             <div style="float:left; font-size:10px; padding-left:5px;"> <asp:Label ID="lblLineNo" runat="server" Text=""></asp:Label>,&nbsp; <asp:Label ID="lblSerialNo" runat="server" Text=""></asp:Label>
                           </div>
                           Stitching Bottleneck Detail
                     </div>
                <asp:HiddenField ID="hdnStyleId" runat="server" />

                                <asp:GridView ID="grdBottleNeck" runat="server" AutoGenerateColumns="false"
                                RowStyle-HorizontalAlign="Center" ShowFooter="true"
                                Width="97%" RowStyle-ForeColor="#7E7E7E" CssClass="item_list2" 
                                onrowdatabound="grdBottleNeck_RowDataBound" 
                                onrowcommand="grdBottleNeck_RowCommand" 
                            style="margin:0px auto; margin-right:15px;" 
                            onrowdeleting="grdBottleNeck_RowDeleting"> 
                                <RowStyle CssClass="gvRow"  />
                                <Columns>
                                 <asp:TemplateField ItemStyle-Width="100px" ItemStyle-VerticalAlign="Top">
                                 <HeaderTemplate>OB Section <sup style="color: Red; text-align: left; font-size: 12px;">*</sup></HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlOBSection" AutoPostBack="true"  OnSelectedIndexChanged="ddlOBSection_SelectedIndexChanged"  Width="100%" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnOBSection" runat="server" />
                                            <asp:HiddenField ID="hdnBottleNeckId" Value='<%# Eval("BottleNeckId") %>' runat="server" />
                                        </ItemTemplate> 
                                        <FooterTemplate>
                                        <asp:DropDownList ID="ddlOBSection_Footer" AutoPostBack="true"  OnSelectedIndexChanged="ddlOBSection_Footer_SelectedIndexChanged"  Width="100%" runat="server">                                        
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>                                      
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="240px">
                                    <HeaderTemplate>OB Operation <sup style="color: Red; text-align: left; font-size: 12px;">*</sup></HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlOBOperation" style="display:none" onchange="javascript:return ValidateDDlOBoperation(this,'Row');"  Width="100%" runat="server">
                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtOBOpration_Item" style="text-transform: lowercase;" Text='<%# Eval("FactoryWorkSpace") %>' onclick="GetObNamefoter(this,'Item')"  onchange="ValidateFaults(this,'ROW');" class="clusterStyleNumber" Width="100%" runat="server"></asp:TextBox>                                          
                                            <asp:HiddenField ID="hdnOBOperation" runat="server" />
                                        </ItemTemplate> 
                                         <FooterTemplate>
                                        <asp:DropDownList ID="ddlOBOperation_Footer" style="display:none" onchange="javascript:return ValidateDDlOBoperation(this,'Footer');"  Width="100%" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtOBOpration_Foter" style="text-transform: lowercase;" onclick="GetObNamefoter(this,'Footer')" class="clusterStyleNumber"  onchange="ValidateFaults(this,'Footer');" Width="100%" runat="server"></asp:TextBox>                                          
                                            
                                        </FooterTemplate>                                        
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>Is Btl Neck <sup style="color: Red; text-align: left; font-size: 12px;">*</sup></HeaderTemplate>
                                     <HeaderStyle Width="40px" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBottleneck" Checked='<%# Eval("IsBottleNeck") %>' runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                         <asp:CheckBox ID="chkBottleneck_Footer" runat="server" />
                                        </FooterTemplate>                                        
                                    </asp:TemplateField>

                                     <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>Dump Pcs</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDumpPcs" style="text-align:center;" Text='<%# Eval("DumpPcs") %>' Width="40px" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </ItemTemplate> 
                                         <FooterTemplate>
                                         <asp:TextBox ID="txtDumpPcs_Footer" Width="40px"  style="text-align:center;" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </FooterTemplate>                                       
                                    </asp:TemplateField>

                                     <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>Tgt Agrd Qty/Hr. <sup style="color: Red; text-align: left; font-size: 12px;">*</sup></HeaderTemplate>
                                    <HeaderStyle Width="65px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAgreed" style="text-align:center;" Text='<%# Eval("TgtAgrdQuantity") %>' Width="40px" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </ItemTemplate>  
                                        <FooterTemplate>
                                         <asp:TextBox ID="txtAgreed_Footer" style="text-align:center;" Width="40px" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </FooterTemplate>                                      
                                    </asp:TemplateField>

                                     <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>Per Hr. Pcs</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPerHrPcs" style="text-align:center;" Text='<%# Eval("PerHrPcs") %>' Width="40px" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                         <asp:TextBox ID="txtPerHrPcs_Footer" style="text-align:center;" Width="40px" onkeypress="return isNumber(event)" MaxLength="4" runat="server"></asp:TextBox>
                                        </FooterTemplate>                                        
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>Add</HeaderTemplate>
                                        <ItemTemplate>   
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/del-butt.png" OnClientClick="return confirm('Are you sure you want to delete?');"  CommandName="Delete" />                                                                             
                                        </ItemTemplate>   
                                        <FooterTemplate>
                                         <asp:ImageButton ID="btnAdd_Footer" runat="server" ImageUrl="~/images/add-butt.png" OnClientClick="javascript:return ValiDateFooterData(this);"  CommandName="AddFooter" />
                                        </FooterTemplate>                                     
                                    </asp:TemplateField>
                                   
                                </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="0" cellspacing="0" class="item_list2" rules="none" border="0">
                                            <tr>
                                                <th>
                                                    OB Section <sup style="color: Red; text-align: left; font-size: 12px;">*</sup>
                                                </th>
                                                <th>
                                                    OB Operation <sup style="color: Red; text-align: left; font-size: 12px;">*</sup>
                                                </th>
                                                <th style="width:40px">
                                                    Is Btl Neck <sup style="color: Red; text-align: left; font-size: 12px;">*</sup>
                                                </th>
                                                <th>
                                                    Dump Pcs
                                                </th>
                                                <th style="width:65px">
                                                    tgt Agrd Qty/Hr. <sup style="color: Red; text-align: left; font-size: 12px;">*</sup>
                                                </th>
                                                <th>
                                                    Per Hr. Pcs
                                                </th>
                                                <th>
                                                    Add
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:DropDownList ID="ddlOBSection_Empty" AutoPostBack="true" onchange="setempty(this);" OnSelectedIndexChanged="ddlOBSection_Empty_SelectedIndexChanged"
                                                        Width="100%" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnOBoperation_Empty" runat="server" />
                                                </td>
                                                <td style="width: 240px">
                                                    <asp:DropDownList ID="ddlOBoperation_Empty"  style="display:none;" Width="100%" runat="server">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    
                                                    <asp:TextBox ID="txtOBOpration__Empty" style="text-transform: lowercase;" onclick="GetObNamefoter(this,'Empty')" class="clusterStyleNumber" Onchange="ValidateFaults(this,'Empty');" Width="100%" runat="server"></asp:TextBox>                                          
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkBottleneck_Empty" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDumpPcs_Empty" Style="text-align: center;" onkeypress="return isNumber(event)"
                                                        MaxLength="4" Width="40px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAgreed_Empty" Style="text-align: center;" onkeypress="return isNumber(event)"
                                                        MaxLength="4" Width="40px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPerHrPcs_Empty" Style="text-align: center;" onkeypress="return isNumber(event)"
                                                        MaxLength="4" Width="40px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnAdd_Empty" OnClientClick="javascript:return ValiDateEmptyData(this);"
                                                        CommandName="AddEmpty" runat="server" ImageUrl="~/images/add-butt.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                            </asp:GridView>

                <div style="margin: 10px auto; text-align: center; width:97%; margin-right:15px;">
                    <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip" OnClientClick="javascript:return ValidateAllData();"
                        Text="Submit" onclick="btnSubmit_Click" />
                    <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                        Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                </div>
                  
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    </form>
</body>
</html>
