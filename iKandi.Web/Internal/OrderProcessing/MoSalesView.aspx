<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoSalesView.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MoSalesView" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Boutique International Pvt. Ltd.</title>
 
    <script src="../../CommonJquery/Js/jquery-1.11.1.js" type="text/javascript"></script>
        <script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  <script type="text/javascript">


//      function disableCheckBox() {
//          debugger;
//          var BH = document.getElementById('hdnBH').value;

//          var StatusUpto = document.getElementById("hdnStatusUpto").value;

//          $("table tr .BEEff").toggle();

//          if (parseInt(StatusUpto) <= 59) {
//              $("table tr .hideCtsl").toggle();
//          }
//          
//          for (var Row = 2; Row < gvSalesView.rows.length - 1; Row++) {
//              if (BH != 1) {
//                  gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = true;

//                  if (gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
//                  }

//                  if (gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
//                  }

//                  if (gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
//                  }
//              }
//              else {


//                  gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;

//                  if (gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
//                  }

//                  if (gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
//                  }

//                  if (gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML == '') {
//                      gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].style.display = 'none';
//                  }
//                  else {
//                      gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = true;
//                  }
//              }
//          }
//      }   

      //below code Commented on 2022-12-08 as no longer need this functionality

//      function CheckOnlyStyleNumber(chkId) {
//          var row = chkId.parentNode.parentNode;
//          var rowIndex = row.rowIndex;
//          var BH = document.getElementById('hdnBH').value;
//          if (BH != 1) {
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//          }
//          else {
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[12].getElementsByTagName("input")[0].checked = false;
//          }
//      }

//      function CheckOnlySTC(chkId) {
//          var row = chkId.parentNode.parentNode;
//          var rowIndex = row.rowIndex;
//          var BH = document.getElementById('hdnBH').value;
//          if (BH != 1) {
//              gvSalesView.rows[rowIndex].cells[8].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//          }
//          else {
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[12].getElementsByTagName("input")[0].checked = false;
//          }
//      }

//      function CheckOnlyBIH(chkId) {
//          var row = chkId.parentNode.parentNode;
//          var rowIndex = row.rowIndex;
//          var BH = document.getElementById('hdnBH').value;
//          if (BH != 1) {
//              gvSalesView.rows[rowIndex].cells[8].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//          }
//          else {
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[12].getElementsByTagName("input")[0].checked = false;
//          }
//      }

//      function CheckOnlyBIHSTC(chkId) {
//          var row = chkId.parentNode.parentNode;
//          var rowIndex = row.rowIndex;
//          var BH = document.getElementById('hdnBH').value;
//          if (BH != 1) {
//              gvSalesView.rows[rowIndex].cells[8].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//          }
//          else {
//              gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
//              gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
//          }
//      }


      //      below function modified on 2022-12-08 by Girish.

      function CheckMonthWise(ChkId, ChkNo) {
    
          var check = '';
          var SessionId = document.getElementById("hdnSession").value;
          var DateRange = '';
          var IkandiPrice = 0;
          var FOBSales = 0;
          var FabricCost = 0;
          var BIPLSales = 0;
          var FabricBIH = 0;
          var MaterialCost = 0;
          var CMTCosted = 0;
          var NoOfStyles = 0;
          var SealCount = 0;
          var OrderQty = 0;
          var CutQty = 0;
          var StitchedQty = 0;
          var PackedQty = 0;
          var UnstitchedQty = 0;
          var ShippedQty = 0;
          var UnstitchedMin = 0;
          var SessionId = document.getElementById("hdnSession").value;   
          var AverageSam = 0;
          var AverageOB = 0;
          var PercentEff = 0;  
          var BH = document.getElementById('hdnBH').value;
          var CompleteDateRange = '';
          var TotalIkandiPrice = 0;
          var TotalFOBSales = 0;
          var TotalFabricCost = 0;
          var TotalFabricBIH = 0;
          var TotalFabricBIH = 0;
          var TotalMaterialCost = 0;
          var TotalCMTCosted = 0;
          var TotalNoOfStyles = 0;
          var TotalNoOfStyleCode = 0;
          var TotalSealCount = 0;
          var TotalBIHCount = 0;
          var TotalBIHSealCount = 0;
          var TotalOrderQty = 0;
          var TotalCutQty = 0;
          var TotalStitchedQty = 0;
          var TotalPackedQty = 0;
          var TotalUnstitchedQty = 0;
          var TotalShippedQty = 0;
          var TotalUnstitchedMin = 0;
          var TotalAverageSam = 0;
          var TotalAverageOB = 0;
          var TotalSam = 0;
          var TotalPercentEff = 0;
          var calSam = 0;
          var calOB = 0;
          var calPeak = 0;
          var latestBudgetCPAM = '1.9';
          var CheckSplit = '';


          if (ChkNo == 1) {

              var CurrentRow = ChkId.parentNode.parentNode;
              if (ChkId.checked) {
                  check = 'True';
              }
              else {
                  check = 'False';
              }

              var HeaderMonth = CurrentRow.cells[1].getElementsByTagName("input")[1].value;
              var Year = CurrentRow.cells[2].getElementsByTagName("input")[1].value;
              var Month = CurrentRow.cells[2].getElementsByTagName("input")[2].value;
          }

          for (var Row = 2; Row < gvSalesView.rows.length - 1; Row++) {
 
              YearCount = gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[1].value;
              MonthCount = gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[2].value;

              if ((MonthCount == Month) && (YearCount == Year)) {
                                             
                if (check == 'True') {
                    gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = true;                          
                }
                else if (check == 'False') {
                    gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = false;                          
                } 
              }

              if (gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked == true) {
                
                  if (BH != 1) {

                      DateRange = gvSalesView.rows[Row].cells[2].getElementsByTagName("span")[1].innerHTML;

                      FOBSales = gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");

                      OrderQty = gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      CutQty = gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      StitchedQty = gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      PackedQty = gvSalesView.rows[Row].cells[7].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      UnstitchedQty = gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      ShippedQty = gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                  }
                  else {

                      DateRange = gvSalesView.rows[Row].cells[2].getElementsByTagName("span")[1].innerHTML;

                      IkandiPrice = gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("£ ", "").replace(" Million", "");

                      FOBSales = gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");

                      OrderQty = gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      CutQty = gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      StitchedQty = gvSalesView.rows[Row].cells[7].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      PackedQty = gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      UnstitchedQty = gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
              
                      ShippedQty = gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                  }

                  if (IkandiPrice == '') {
                      IkandiPrice = 0;
                  }
                  if (FOBSales == '') {
                      FOBSales = 0;
                  }  
                 
                  if (OrderQty == '') {
                      OrderQty = 0;
                  }
                              
                  if (CutQty == '') {
                      CutQty = 0;
                  }
                  if (StitchedQty == '') {
                      StitchedQty = 0;
                  }
                  if (PackedQty == '') {
                      PackedQty = 0;
                  }
                  if (UnstitchedQty == '') {
                      UnstitchedQty = 0;
                  }
                  if (ShippedQty == '') {
                      ShippedQty = 0;
                  }

                  CompleteDateRange += '__' + DateRange + '__,';

                  TotalIkandiPrice = parseFloat(TotalIkandiPrice) + parseFloat(IkandiPrice);

                  TotalFOBSales = parseFloat(TotalFOBSales) + parseFloat(FOBSales);

                  TotalOrderQty = parseInt(TotalOrderQty) + parseInt(OrderQty);

                  TotalCutQty = parseInt(TotalCutQty) + parseInt(CutQty);

                  TotalStitchedQty = parseInt(TotalStitchedQty) + parseInt(StitchedQty);

                  TotalPackedQty = parseInt(TotalPackedQty) + parseInt(PackedQty);

                  TotalUnstitchedQty = parseInt(TotalUnstitchedQty) + parseInt(UnstitchedQty);

                  TotalShippedQty = parseInt(TotalShippedQty) + parseInt(ShippedQty);                 
              }              
          }

          CompleteDateRange = CompleteDateRange.substring(0, CompleteDateRange.length - 1);

          if (CompleteDateRange == '') {
              CompleteDateRange = '____'
          }
          SessionId = '__' + SessionId + '__';

          var url = "../../Webservices/iKandiService.asmx";
          $.ajax({
              type: "POST",
              url: url + "/GetBreakedStyleDetails",
              data: "{ CompleteDateRange:'" + CompleteDateRange + "', SessionId:'" + SessionId + "' }",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: OnSuccessCall,
              error: OnErrorCall
          });

          function OnSuccessCall(response) {             
              if (BH != 1) {

                  if (TotalFOBSales > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalOrderQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = TotalOrderQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalCutQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = TotalCutQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalStitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = TotalStitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalPackedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = TotalPackedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalUnstitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = TotalUnstitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalShippedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = TotalShippedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = "";
                  }                 
              }
              else {
                  if (TotalIkandiPrice > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "£ " + TotalIkandiPrice.toFixed(2) + " Million";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalFOBSales > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalOrderQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = TotalOrderQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalCutQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = TotalCutQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalStitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = TotalStitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalPackedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = TotalPackedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalUnstitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = TotalUnstitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = "";
                  }
              }
          }
          function OnErrorCall(response) {
              alert(response.status + " " + response.statusText);
          }
      }

      function ClearAll() {      

          var frm = document.forms[0];
          for (i = 0; i < frm.elements.length; i++) {
              if (frm.elements[i].type == "checkbox") {
                  frm.elements[i].checked = false;
              }
          }
      }       


      function CheckAll() {
          var check = 'false';
          var counter = 0;
          var frm = document.forms[0];
          for (i = 0; i < frm.elements.length; i++) {

              if (frm.elements[i].type == "checkbox") {
                  if (frm.elements[i].checked) {
                      check = 'true';
                  }
              }
          }
          if (check == 'false') {
              alert('Please Select at least one');
              return false;
          }

      }

//      below function modified on 2022-12-08 by Girish.

      function UpdateManageOrder() {

          var check = '';
          var SessionId = document.getElementById("hdnSession").value;
          var DateRange = '';
          var IkandiPrice = 0;
          var FOBSales = 0;
          var FabricCost = 0;
          var BIPLSales = 0;
          var FabricBIH = 0;
          var MaterialCost = 0;
          var CMTCosted = 0;
          var NoOfStyles = 0;
          var SealCount = 0;
          //      var BIHCount = 0;
          //      var BIHSealCount = 0;
          var OrderQty = 0;
          var CutQty = 0;
          var StitchedQty = 0;
          var PackedQty = 0;
          var UnstitchedQty = 0;
          var ShippedQty = 0;
          var UnstitchedMin = 0;

          var BH = document.getElementById('hdnBH').value;

          var CompleteDateRange = '';
          var TotalIkandiPrice = 0;
          var TotalFOBSales = 0;
          var TotalFabricCost = 0;
          var TotalFabricBIH = 0;
          var TotalMaterialCost = 0;
          var TotalCMTCosted = 0;
          var TotalNoOfStyles = 0;
          var TotalNoOfStyleCode = 0;
          var TotalSealCount = 0;
          var TotalBIHCount = 0;
          var TotalBIHSealCount = 0;
          var TotalOrderQty = 0;
          var TotalAverageSam = 0;
          var TotalAverageOB = 0;
          var TotalSam = 0;
          var TotalPercentEff = 0;
          var TotalCutQty = 0;
          var TotalStitchedQty = 0;
          var TotalPackedQty = 0;
          var TotalUnstitchedQty = 0;
          var TotalShippedQty = 0;
          var TotalUnstitchedMin = 0;
          var calSam = 0;
          var calOB = 0
          var SamSum = 0;
          var calPeak = 0;
          var latestBudgetCPAM = '1.9';

          for (var Row = 2; Row < gvSalesView.rows.length - 1; Row++) {

              if (gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked == true) {

                  if (BH != 1) {

                      DateRange = gvSalesView.rows[Row].cells[2].getElementsByTagName("span")[1].innerHTML;

                      FOBSales = gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");

                      OrderQty = gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      CutQty = gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      StitchedQty = gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      PackedQty = gvSalesView.rows[Row].cells[7].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      UnstitchedQty = gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      ShippedQty = gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML.replace(" k", "");


                  }
                  else {

                      DateRange = gvSalesView.rows[Row].cells[2].getElementsByTagName("span")[1].innerHTML;

                      IkandiPrice = gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("£ ", "").replace(" Million", "");

                      FOBSales = gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");

                      OrderQty = gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      CutQty = gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      StitchedQty = gvSalesView.rows[Row].cells[7].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      PackedQty = gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      UnstitchedQty = gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                      ShippedQty = gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML.replace(" k", "");

                  }

                  if (IkandiPrice == '') {
                      IkandiPrice = 0;
                  }
                  if (FOBSales == '') {
                      FOBSales = 0;
                  }

                  if (OrderQty == '') {
                      OrderQty = 0;
                  }

                  if (CutQty == '') {
                      CutQty = 0;
                  }
                  if (StitchedQty == '') {
                      StitchedQty = 0;
                  }
                  if (PackedQty == '') {
                      PackedQty = 0;
                  }
                  if (UnstitchedQty == '') {
                      UnstitchedQty = 0;
                  }
                  if (ShippedQty == '') {
                      ShippedQty = 0;
                  }

                  CompleteDateRange += '__' + DateRange + '__,';

                  TotalIkandiPrice = parseFloat(TotalIkandiPrice) + parseFloat(IkandiPrice);

                  TotalFOBSales = parseFloat(TotalFOBSales) + parseFloat(FOBSales);

                  TotalOrderQty = parseInt(TotalOrderQty) + parseInt(OrderQty);

                  TotalCutQty = parseInt(TotalCutQty) + parseInt(CutQty);

                  TotalStitchedQty = parseInt(TotalStitchedQty) + parseInt(StitchedQty);

                  TotalPackedQty = parseInt(TotalPackedQty) + parseInt(PackedQty);

                  TotalUnstitchedQty = parseInt(TotalUnstitchedQty) + parseInt(UnstitchedQty);

                  TotalShippedQty = parseInt(TotalShippedQty) + parseInt(ShippedQty);
                 
              }              
          }

          CompleteDateRange = CompleteDateRange.substring(0, CompleteDateRange.length - 1);

          if (CompleteDateRange == '') {
              CompleteDateRange = '____'
          }
          SessionId = '__' + SessionId + '__';

          var url = "../../Webservices/iKandiService.asmx";
          $.ajax({
              type: "POST",
              url: url + "/GetBreakedStyleDetails",
              data: "{ CompleteDateRange:'" + CompleteDateRange + "', SessionId:'" + SessionId + "' }",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: OnSuccessCall,
              error: OnErrorCall
          });

          function OnSuccessCall(response) {

              if (BH != 1) {
                  if (TotalFOBSales > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalOrderQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = TotalOrderQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalCutQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = TotalCutQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalStitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = TotalStitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalPackedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = TotalPackedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalUnstitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = TotalUnstitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalShippedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = TotalShippedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = "";
                  }
              }
              else {

                  if (TotalIkandiPrice > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "£ " + TotalIkandiPrice.toFixed(2) + " Million";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[1].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalFOBSales > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[2].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalOrderQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = TotalOrderQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[3].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalCutQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = TotalCutQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[4].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalStitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = TotalStitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[5].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalPackedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = TotalPackedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[6].getElementsByTagName("span")[1].innerHTML = "";
                  }

                  if (TotalUnstitchedQty > 0) {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = TotalUnstitchedQty + " k";
                  }
                  else {
                      gvSalesView.rows[gvSalesView.rows.length - 1].cells[7].getElementsByTagName("span")[1].innerHTML = "";
                  }
              }
          }

          function OnErrorCall(response) {
              alert(response.status + " " + response.statusText);
          }

          window.opener.UpdatePageForSale();
      }

      function closeSalesView() {
          window.opener.ClosePageForSale();
          this.parent.window.close();
          return false;
      }


  </script>
  <style type="text/css">
  .SalesReportHeader th, .SalesReportHeader td
  {
    background: #f6f7f9 !important;
    padding: 5px 0;
  }
  .RangeStyle td
  {
    padding: 5px 0;
  }
  .blue-text
  {
    color: #000066 !important;
  }
  .breff
  {
    color: #385eaf !important;
  }
  .breakeven
  {
    color: #100cc8 !important;
    font-weight: bold;
  }
  .unsti
  {
    color: #666666 !important;
  }
  .total
  {
    color: #141823 !important;
    font-weight: bold;
  }
   input[type='checkbox']{
    -moz-margin:0px 0px 0px 3px
  }
  .hiddencol
  {
    display: none;
  }
</style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <div align="center" style="font-family: Arial;">
    <asp:HiddenField ID="hdnStatusUpto" runat="server" />
    <asp:HiddenField ID="hdnSession" runat="server" />
    <asp:HiddenField ID="hdnBH" Value="0" runat="server" />
    <asp:HiddenField ID="hdnWeekHeader" Value="0" runat="server" />
    <asp:HiddenField ID="hdnShipedCheck" runat="server" />
    <asp:GridView ID="gvSalesView" runat="server" AutoGenerateColumns="false" ShowFooter="true" FooterStyle-HorizontalAlign="Center" RowStyle-CssClass="RangeStyle" Width="99%"
      OnRowDataBound="gvSalesView_RowDataBound" OnRowCreated="gvSalesView_RowCreated" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-Height="25px">
      <Columns>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Year</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblYear" runat="server" ForeColor="Gray" Text='<%#Eval("Year") %>'></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Month</HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkMonth" onclick="javascript:return CheckMonthWise(this, 1);" runat="server" />
            <asp:Label ID="lblMonth" runat="server" Font-Bold="true" Text='<%#Eval("Month_Name") %>'></asp:Label>
            <asp:HiddenField ID="hdnMonthHeader" Value='<%#Eval("Month") %>' runat="server" />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Week</HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkDateRange" onclick="javascript:return CheckMonthWise(this, 2);" runat="server" />
            <asp:HiddenField ID="hdnYear" Value='<%#Eval("Year") %>' runat="server" />
            <asp:HiddenField ID="hdnMonth" Value='<%#Eval("Month") %>' runat="server" />
            <asp:HiddenField ID="hdnWeek" Value='<%#Eval("Week") %>' runat="server" />
            <asp:HiddenField ID="hdnFromDate" Value='<%#Eval("From") %>' runat="server" />
            <asp:HiddenField ID="hdnToDate" Value='<%#Eval("To") %>' runat="server" />
            <asp:HiddenField ID="hdnIsWeekSelect" Value="0" runat="server" />
            <asp:Label CssClass="RangeStyle" ID="lblWeekNo" style="display:none;" runat="server"  Text='<%#Eval("Week_Count") %>'></asp:Label>&nbsp;
            <asp:Label CssClass="RangeStyle" ID="lblDateRange" runat="server" Text='<%#Eval("DateRange") %>'></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Ikandi FOB</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblIkandiPrice" Font-Size="11px" CssClass="blue-text" runat="server" Text='<%# (Convert.ToDecimal(Eval("IKANDIPrice")) > 0)? Eval("IKANDIPrice") : "0.00" %>'></asp:Label>
            
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalIkandiPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedIkandiPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>FOB Sales</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblBiplPrice" ForeColor="Green" Font-Bold="true" Font-Size="11px"  runat="server" Text='<%# Eval("BIPLPrice") %>'></asp:Label>
            <asp:Label ID="hdnCMT" Text='<%#Eval("AvgCMT") %>' runat="server" style="display:none;"></asp:Label>
            <asp:HiddenField ID="hdnFabricBIH" Value='<%# (Convert.ToDecimal(Eval("FabricBIH")) > 0)? Eval("FabricBIH") : "0.00" %>' runat="server" />
            <asp:HiddenField ID="hdnBIPLPrice" Value='<%# (Convert.ToDecimal(Eval("BIPLPrice")) > 0)? Eval("BIPLPrice") : "0.00" %>' runat="server" />
             <asp:HiddenField ID="hdnTotalFabricCost" Value='<%# (Convert.ToDecimal(Eval("FabricCostingCost")) > 0)? Eval("FabricCostingCost") : "0.00" %>' runat="server" />
             <asp:HiddenField ID="hdnCostingCost" Value='<%# (Convert.ToDecimal(Eval("FabricCostingCost")) > 0)? Eval("FabricCostingCost") : "0.00" %>' runat="server" />

          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBiplPrice" Font-Size="13px" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
              <asp:HiddenField ID="hdnTotalBiplPrice" runat="server" />
              </td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBiplPrice" Font-Size="13px" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
          <%--<HeaderTemplate>Material Cost (%)[Fabric BIH] (FBIH %)</HeaderTemplate>--%>
          <HeaderTemplate>Material Cost (%)</HeaderTemplate>
          <ItemTemplate>
            <%--<asp:Label ID="lblTotalFabricAndAccessoryCost" ForeColor="Green" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("TotalFabricAndAccessoryCost")) > 0)? Eval("TotalFabricAndAccessoryCost") : "0.00" %>'></asp:Label>--%>
            <asp:Label ID="lblTotalFabricAndAccessoryCostPer" style="display:none"; CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr>
                <td align="center" style="height:30px;">
                  <asp:Label ID="lblTotalFabricAndAccessoryCost_Sum" Font-Size="13px" Font-Bold="true" ForeColor="green" runat="server"></asp:Label>
                 <asp:Label ID="lblTotalFabricAndAccessoryCost_SumPer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                </td>
              </tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr>
                <td align="center" style="height:30px; background-color:#CCCCCC;">
                  <asp:Label ID="lblBreakedFabricAndAccessoryCost_Sum" Font-Size="13px" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                  <asp:Label ID="lblBreakedFabricAndAccessoryCost_SumPer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                </td>
              </tr>
            </table>          
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
          <HeaderTemplate>CMT Costed (%)</HeaderTemplate>
          <ItemTemplate>
            <%--<asp:Label ID="lblCMTValue" ForeColor="Green" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("CMTValue")) > 0)? Eval("CMTValue") : "0.00" %>'></asp:Label>--%>
            <asp:Label ID="lblCMTValuePer" CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr>
                <td align="center" style="height:30px;">
                  <asp:Label ID="lblTotalCMTValue" Font-Size="13px" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                      <asp:Label ID="lblTotalCMTValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                </td>
              </tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr>
                <td align="center" style="height:30px; background-color:#CCCCCC;">
                  <asp:Label ID="lblBreakedCMTValue" Font-Size="13px" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                  <asp:Label ID="lblBreakedCMTValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                </td>
              </tr>
            </table> 
          </FooterTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Average SAM (OB W/S)</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblAvgSAM" Font-Size="11px" runat="server" CssClass="unsti" Text='<%# (Convert.ToDecimal(Eval("AvgSAM")) > 0)? Eval("AvgSAM") : "0.00" %>'></asp:Label>
            <asp:Label ID="lblOB" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("OB")) > 0)? Eval("OB") : "0.00" %>'></asp:Label>
          </ItemTemplate>
        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="height: 30px;">
                                        <asp:Label ID="lblTotalAvgSAM" Font-Size="13px" Font-Bold="true" runat="server" CssClass="AvgSAMS blue-text"></asp:Label>
                                        <asp:Label ID="lblTotalOB" Font-Size="13px" Font-Bold="true" CssClass="TotalOBS breff" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 1px; background-color: #000000;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 30px; background-color: #CCCCCC;">
                                        <asp:Label ID="lblAverageobValuesam" Font-Size="13px" Font-Bold="true" CssClass="blue-text"
                                            runat="server"></asp:Label>
                                        <asp:Label ID="lblAverageobValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
        </asp:TemplateField>--%>       
        <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>&nbsp;&nbsp;Styles(StyleCode)</HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkStyleNumber" runat="server" onclick="javascript:return CheckOnlyStyleNumber(this);" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStyleNumber" Font-Size="11px" style=" margin-left:-7px;" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("StyleCount")) > 0)? Eval("StyleCount") : "0" %>'></asp:Label>&nbsp;(&nbsp;
            <asp:Label ID="lblStyleCode" Font-Size="11px" style=" margin-left:-7px;" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("StyleCode")) > 0)? Eval("StyleCode") : "0" %>'></asp:Label>)

          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="left" style="height:30px; padding-left:26px;"><asp:Label ID="lblTotalStyleNumber" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label>
              (<asp:Label ID="lblTotalStylecode" Font-Size="13px" Font-Bold="true" CssClass="TotalOBS breff" runat="server"></asp:Label>)
              </td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr>
                <td align="left" style="height:30px; padding-left:26px;  background-color:#CCCCCC;">
                  <asp:Label ID="lblBreakedStyleNumber" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label>
                  <asp:Label ID="lblBreakedStyleCode" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                  <asp:HiddenField ID="hdnBreakedStyleNumber" runat="server" />
                </td>
              </tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>--%>
        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>&nbsp;&nbsp;STC&nbsp;&nbsp;</HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkSealCount" runat="server" onclick="javascript:return CheckOnlySTC(this);" />
            &nbsp;&nbsp;<asp:Label ID="lblSealCount" Font-Size="11px" style=" margin-left:-7px;" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("SealCount")) > 0)? Eval("SealCount") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>--%>
        <%--   <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>&nbsp;&nbsp;BIH&nbsp;&nbsp;</HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkBIHCount" runat="server" onclick="javascript:return CheckOnlyBIH(this);" />
            &nbsp;&nbsp;<asp:Label ID="lblBIHCount" style=" margin-left:-7px;" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("BIHCount")) > 0)? Eval("BIHCount") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBIHCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBIHCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>--%>
        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        
        
          <HeaderTemplate>BIH + STC</HeaderTemplate>
          <HeaderStyle  CssClass="hiddencol"/>
          <ItemTemplate>
            <asp:CheckBox ID="chkBIHSealCount" runat="server" onclick="javascript:return CheckOnlyBIHSTC(this);" />
            &nbsp;&nbsp;<asp:Label ID="lblBIHSealCount" Font-Size="11px" style=" margin-left:-7px;" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("BIH_SealCount")) > 0)? Eval("BIH_SealCount") : "0" %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle  CssClass="hiddencol" />
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBIHSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBIHSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
          <FooterStyle CssClass="hiddencol"/>
        </asp:TemplateField>--%>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Order Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblQuantity" Font-Size="11px" runat="server" Font-Bold="true" ForeColor="#0F0F0F" Text='<%#(Convert.ToInt32(Eval("Quantity")) > 0)? Eval("Quantity") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalQuantity" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedQuantity" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Cut Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblQuantity_Cut" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("CutQty")) > 0)? Eval("CutQty") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalQuantity_Cut" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedQuantity_Cut" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Stitched Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblQuantity_Stitch" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("Stitch")) > 0)? Eval("Stitch") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalQuantity_Stitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedQuantity_Stitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Packed Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblQuantity_Packed" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("PackedQty")) > 0)? Eval("PackedQty") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalQuantity_Packed" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedQuantity_Packed" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Unstitched Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:Label ID="lblQuantity_Unstitch" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("Quantity_Unstitch")) > 0)? Eval("Quantity_Unstitch") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalQuantity_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedQuantity_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>Shipped Qty</HeaderTemplate>
          <ItemTemplate>
            <asp:HiddenField ID="hdnShippedQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualShippedQty")) > 0)? Eval("ActualShippedQty") : "0" %>' />
            <asp:Label ID="lblShippedQty" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("ShippedQty")) > 0)? Eval("ShippedQty") : "0" %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalShippedQty" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedShippedQty" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label></td></tr>
            </table>
          </FooterTemplate>
          <FooterStyle  CssClass="hideCtsl"/>
          <ItemStyle  CssClass="hideCtsl"/>
          <HeaderStyle CssClass="hideCtsl"/>
        </asp:TemplateField>
      <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
          <HeaderTemplate>CTSL (%)</HeaderTemplate>
          <ItemTemplate >
            <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualCutQty")) > 0)? Eval("ActualCutQty") : "0" %>' />
            <asp:Label ID="lblCTSL" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("CTSL")) > 0)? Eval("CTSL") : "0" %>'></asp:Label>
            <asp:Label ID="lblCTSLDiff" Font-Size="11px" runat="server" ForeColor="#0F0F0F"></asp:Label>
          </ItemTemplate>
          <FooterTemplate >
            <asp:Label ID="lblTotalCTSL" Font-Size="13px" runat="server" Font-Bold="true" CssClass="breff"></asp:Label>
            <asp:Label ID="lblTotalCTSLDiff" Font-Size="13px" runat="server" Font-Bold="true" ForeColor="#0F0F0F"></asp:Label>
          </FooterTemplate>
          <FooterStyle  CssClass="hideCtsl"/>
          <ItemStyle  CssClass="hideCtsl"/>
          <HeaderStyle CssClass="hideCtsl"/>
        </asp:TemplateField>--%>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
          <HeaderTemplate>Unstitched Min</HeaderTemplate>
          <ItemTemplate>
           <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualCutQty")) > 0)? Eval("ActualCutQty") : "0" %>' />
           <%-- <asp:Label ID="lblMinutes_Unstitch" CssClass="unsti" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("Minutes_Unstitch")) > 0)? Eval("Minutes_Unstitch") : "0.0" %>'></asp:Label>--%>
          </ItemTemplate>
          <FooterTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr><td align="center" style="height:30px;"><!--<asp:Label ID="lblTotalMinutes_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" CssClass="unsti"></asp:Label>--></td></tr>
              <tr><td style="height:1px; background-color:#000000;"></td></tr>
              <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><!--<asp:Label ID="lblBreakedMinutes_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" CssClass="unsti"></asp:Label>--></td></tr>
            </table>
          </FooterTemplate>
          <FooterStyle  CssClass="BEEff"/>
          <ItemStyle  CssClass="BEEff"/>
          <HeaderStyle CssClass="BEEff"/>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
    <div style="text-align: center; font-size: 25px; font-family: Arial; color: Gray; height:15px; padding-top:50px;">
      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <%--<div>
      N.B:<asp:Label ID="lblStitchMsg" Style="font-size: 11px; font-weight: bold; font-family: Arial;
        color: black; padding: 1px; text-transform: lowercase;" runat="server" Text=" Machine count = Min Unstitched (in lakhs) / (60 minutes  11.25 working hours per day  no. of working days). Please note working days does not include Sundays and calculations are based on 100% achievement levels and 5% extra machines given for absenteeism."></asp:Label>
    </div>--%>
    <div align="right" style="padding-bottom: 10px;">
      <asp:Button ID="btnSubmit" OnClientClick="JavaScript:return CheckAll();" CssClass="submitmo submit" runat="server" Text=" Submit" OnClick="btnSubmit_Click" />
      <asp:Button ID="btnClear" runat="server" OnClientClick="JavaScript:ClearAll();" CssClass="clear da_submit_button" Text="Clear" />
      <asp:Button ID="btnClose" runat="server" OnClientClick="JavaScript:closeSalesView();" CssClass="close da_submit_button" Text="Close" />&nbsp;&nbsp;
    </div>
  </div>
  </div>
  </form>
</body>
</html>
