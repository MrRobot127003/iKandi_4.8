<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoSalesView.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.MoSalesView" %>
<script type="text/javascript">
  function disableCheckBox() {
    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;
    for (var Row = 2; Row < MoSalesView1_gvSalesView.rows.length - 1; Row++) {
      if (BH != 1) {
        MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = true;

        if (MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
        }

        if (MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
        }

        if (MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
        }
      }
      else {
        MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;

        if (MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
        }

        if (MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
        }

        if (MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].style.display = 'none';
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = true;
        }
      }
    }
  }

  function closeSalesView() {
    //debugger;
    window.opener.ClosePageForSale();
    this.parent.window.close();
    return false;
  }

  function CheckOnlySTC(chkId) {
    var row = chkId.parentNode.parentNode;
    var rowIndex = row.rowIndex;
    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;
    if (BH != 1) {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
    }
    else {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[12].getElementsByTagName("input")[0].checked = false;
    }
  }

  function CheckOnlyBIH(chkId) {
    var row = chkId.parentNode.parentNode;
    var rowIndex = row.rowIndex;
    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;
    if (BH != 1) {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
    }
    else {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[12].getElementsByTagName("input")[0].checked = false;
    }
  }

  function CheckOnlyBIHSTC(chkId) {
    var row = chkId.parentNode.parentNode;
    var rowIndex = row.rowIndex;
    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;
    if (BH != 1) {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[9].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
    }
    else {
      MoSalesView1_gvSalesView.rows[rowIndex].cells[10].getElementsByTagName("input")[0].checked = false;
      MoSalesView1_gvSalesView.rows[rowIndex].cells[11].getElementsByTagName("input")[0].checked = false;
    }
  }

  function CheckMonthWise(ChkId, ChkNo) {
    //debugger;
    var check = '';
    var IkandiPrice = 0;
    var FOBSales = 0;
    var MaterialCost = 0;
    var CMTCosted = 0;
    var NoOfStyles = 0;
    var SealCount = 0;
    var BIHCount = 0;
    var BIHSealCount = 0;
    var OrderQty = 0;
    var CutQty = 0;
    var StitchedQty = 0;
    var PackedQty = 0;
    var UnstitchedQty = 0;
    var ShippedQty = 0;
    var UnstitchedMin = 0;

    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;

    var TotalIkandiPrice = 0;
    var TotalFOBSales = 0;
    var TotalMaterialCost = 0;
    var TotalCMTCosted = 0;
    var TotalNoOfStyles = 0;
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

    for (var Row = 2; Row < MoSalesView1_gvSalesView.rows.length - 1; Row++) {
      //debugger;
      YearCount = MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[1].value;
      MonthCount = MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[2].value;

      if ((MonthCount == Month) && (YearCount == Year)) {
        if (BH != 1) {
          if (check == 'True') {
            MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = true;
            MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;
          }
          if (check == 'False') {
            MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
          }
        }
        else {
          if (check == 'True') {
            MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = true;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = false;
          }
          if (check == 'False') {
            MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
            MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].checked = false;
            MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = true;
          }
        }
      }

      if (MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked == true) {
        //debugger;
        if (BH != 1) {
          if (MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled == true) {
            MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;
          }

          FOBSales = MoSalesView1_gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          MaterialCost = MoSalesView1_gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          CMTCosted = MoSalesView1_gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          NoOfStyles = MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML;
          SealCount = MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML;
          BIHCount = MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML;
          BIHSealCount = MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML;
          OrderQty = MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          CutQty = MoSalesView1_gvSalesView.rows[Row].cells[13].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          StitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[14].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          PackedQty = MoSalesView1_gvSalesView.rows[Row].cells[15].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[16].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          ShippedQty = MoSalesView1_gvSalesView.rows[Row].cells[17].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedMin = MoSalesView1_gvSalesView.rows[Row].cells[19].getElementsByTagName("span")[0].innerHTML.replace(" L", "");
        }
        else {
          if (MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled == true) {
            MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;
            MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = false;
          }

          IkandiPrice = MoSalesView1_gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("£ ", "").replace(" Million", "");
          FOBSales = MoSalesView1_gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          MaterialCost = MoSalesView1_gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          CMTCosted = MoSalesView1_gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          NoOfStyles = MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML;
          SealCount = MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML;
          BIHCount = MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML;
          BIHSealCount = MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML;
          OrderQty = MoSalesView1_gvSalesView.rows[Row].cells[13].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          CutQty = MoSalesView1_gvSalesView.rows[Row].cells[14].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          StitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[15].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          PackedQty = MoSalesView1_gvSalesView.rows[Row].cells[16].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[17].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          ShippedQty = MoSalesView1_gvSalesView.rows[Row].cells[18].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedMin = MoSalesView1_gvSalesView.rows[Row].cells[20].getElementsByTagName("span")[0].innerHTML.replace(" L", "");
        }

        if (IkandiPrice == '') {
          IkandiPrice = 0;
        }
        if (FOBSales == '') {
          FOBSales = 0;
        }
        if (MaterialCost == '') {
          MaterialCost = 0;
        }
        if (CMTCosted == '') {
          CMTCosted = 0;
        }
        if (NoOfStyles == '') {
          NoOfStyles = 0;
        }
        if (SealCount == '') {
          SealCount = 0;
        }
        if (BIHCount == '') {
          BIHCount = 0;
        }
        if (BIHSealCount == '') {
          BIHSealCount = 0;
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
        if (UnstitchedMin == '') {
          UnstitchedMin = 0;
        }

        TotalIkandiPrice = parseFloat(TotalIkandiPrice) + parseFloat(IkandiPrice);
        TotalFOBSales = parseFloat(TotalFOBSales) + parseFloat(FOBSales);
        TotalMaterialCost = parseFloat(TotalMaterialCost) + parseFloat(MaterialCost);
        TotalCMTCosted = parseFloat(TotalCMTCosted) + parseFloat(CMTCosted);
        TotalNoOfStyles = parseInt(TotalNoOfStyles) + parseInt(NoOfStyles);
        TotalSealCount = parseInt(TotalSealCount) + parseInt(SealCount);
        TotalBIHCount = parseInt(TotalBIHCount) + parseInt(BIHCount);
        TotalBIHSealCount = parseInt(TotalBIHSealCount) + parseInt(BIHSealCount);
        TotalOrderQty = parseInt(TotalOrderQty) + parseInt(OrderQty);
        TotalCutQty = parseInt(TotalCutQty) + parseInt(CutQty);
        TotalStitchedQty = parseInt(TotalStitchedQty) + parseInt(StitchedQty);
        TotalPackedQty = parseInt(TotalPackedQty) + parseInt(PackedQty);
        TotalUnstitchedQty = parseInt(TotalUnstitchedQty) + parseInt(UnstitchedQty);
        TotalShippedQty = parseInt(TotalShippedQty) + parseInt(ShippedQty);
        TotalUnstitchedMin = parseInt(TotalUnstitchedMin) + parseInt(UnstitchedMin);
      }
      else {
        if (BH != 1) {
          MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = true;
        }
      }
    }

    //debugger;
    if (BH == 1) {
      if (TotalIkandiPrice > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedIkandiPrice")).ClientID %>').innerHTML = "£ " + TotalIkandiPrice.toFixed(2) + " Million"; }
      else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedIkandiPrice")).ClientID %>').innerHTML = ""; }
    }
  debugger;
    //girish;
    if (TotalFOBSales > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBiplPrice")).ClientID %>').innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBiplPrice")).ClientID %>').innerHTML = ""; }

    if (TotalMaterialCost > 0) {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_Sum")).ClientID %>').innerHTML = "₹ " + TotalMaterialCost.toFixed(2) + " Cr";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_SumPer")).ClientID %>').innerHTML = " (" + ((TotalMaterialCost / TotalFOBSales) * 100).toFixed(0) + "%)";
    }
    else {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_Sum")).ClientID %>').innerHTML = "";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_SumPer")).ClientID %>').innerHTML = "";
    }

    if (TotalCMTCosted > 0) {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValue")).ClientID %>').innerHTML = "₹ " + TotalCMTCosted.toFixed(2) + " Cr";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValuePer")).ClientID %>').innerHTML = " (" + ((TotalCMTCosted / TotalFOBSales) * 100).toFixed(0) + "%)";
    }
    else {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValue")).ClientID %>').innerHTML = "";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValuePer")).ClientID %>').innerHTML = "";
    }

    if (TotalNoOfStyles > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedStyleNumber")).ClientID %>').innerHTML = TotalNoOfStyles; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedStyleNumber")).ClientID %>').innerHTML = ""; }

    if (TotalSealCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedSealCount")).ClientID %>').innerHTML = TotalSealCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedSealCount")).ClientID %>').innerHTML = ""; }

    if (TotalBIHCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHCount")).ClientID %>').innerHTML = TotalBIHCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHCount")).ClientID %>').innerHTML = ""; }

    if (TotalBIHSealCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHSealCount")).ClientID %>').innerHTML = TotalBIHSealCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHSealCount")).ClientID %>').innerHTML = ""; }

    if (TotalOrderQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity")).ClientID %>').innerHTML = TotalOrderQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity")).ClientID %>').innerHTML = ""; }

    if (TotalCutQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Cut")).ClientID %>').innerHTML = TotalCutQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Cut")).ClientID %>').innerHTML = ""; }

    if (TotalStitchedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Stitch")).ClientID %>').innerHTML = TotalStitchedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Stitch")).ClientID %>').innerHTML = ""; }

    if (TotalPackedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Packed")).ClientID %>').innerHTML = TotalPackedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Packed")).ClientID %>').innerHTML = ""; }

    if (TotalUnstitchedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Unstitch")).ClientID %>').innerHTML = TotalUnstitchedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Unstitch")).ClientID %>').innerHTML = ""; }

    if (TotalShippedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedShippedQty")).ClientID %>').innerHTML = TotalShippedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedShippedQty")).ClientID %>').innerHTML = ""; }

    if (TotalUnstitchedMin > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedMinutes_Unstitch")).ClientID %>').innerHTML = TotalUnstitchedMin + " L"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedMinutes_Unstitch")).ClientID %>').innerHTML = ""; }
  }

  function ClearAll() {
    //debugger;
    var frm = document.forms[0];
    for (i = 0; i < frm.elements.length; i++) {
      if (frm.elements[i].type == "checkbox") {
        frm.elements[i].checked = false;
      }
    }
  }

  function CheckAll() {
    //debugger;
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

  function UpdateManageOrder() {
    //debugger;
    var check = '';
    var IkandiPrice = 0;
    var FOBSales = 0;
    var MaterialCost = 0;
    var CMTCosted = 0;
    var NoOfStyles = 0;
    var SealCount = 0;
    var BIHCount = 0;
    var BIHSealCount = 0;
    var OrderQty = 0;
    var CutQty = 0;
    var StitchedQty = 0;
    var PackedQty = 0;
    var UnstitchedQty = 0;
    var ShippedQty = 0;
    var UnstitchedMin = 0;

    var BH = document.getElementById('<%=hdnBH.ClientID%>').value;

    var TotalIkandiPrice = 0;
    var TotalFOBSales = 0;
    var TotalMaterialCost = 0;
    var TotalCMTCosted = 0;
    var TotalNoOfStyles = 0;
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

    for (var Row = 2; Row < MoSalesView1_gvSalesView.rows.length - 1; Row++) {
      if (BH != 1) {
        if (MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].style.display = 'none';
        }
        if (MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
        }
        if (MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
        }
      }
      else {
        if (MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].style.display = 'none';
        }
        if (MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].style.display = 'none';
        }
        if (MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML == '') {
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].style.display = 'none';
        }
      }

      if (MoSalesView1_gvSalesView.rows[Row].cells[2].getElementsByTagName("input")[0].checked == true) {
        //debugger;
        if (BH != 1) {
          MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;

          FOBSales = MoSalesView1_gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          MaterialCost = MoSalesView1_gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          CMTCosted = MoSalesView1_gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          NoOfStyles = MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("span")[0].innerHTML;
          SealCount = MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML;
          BIHCount = MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML;
          BIHSealCount = MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML;
          OrderQty = MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          CutQty = MoSalesView1_gvSalesView.rows[Row].cells[13].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          StitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[14].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          PackedQty = MoSalesView1_gvSalesView.rows[Row].cells[15].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[16].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          ShippedQty = MoSalesView1_gvSalesView.rows[Row].cells[17].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedMin = MoSalesView1_gvSalesView.rows[Row].cells[19].getElementsByTagName("span")[0].innerHTML.replace(" L", "");
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = false;
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = false;

          IkandiPrice = MoSalesView1_gvSalesView.rows[Row].cells[3].getElementsByTagName("span")[0].innerHTML.replace("£ ", "").replace(" Million", "");
          FOBSales = MoSalesView1_gvSalesView.rows[Row].cells[4].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          MaterialCost = MoSalesView1_gvSalesView.rows[Row].cells[5].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          CMTCosted = MoSalesView1_gvSalesView.rows[Row].cells[6].getElementsByTagName("span")[0].innerHTML.replace("₹ ", "").replace(" Cr", "");
          NoOfStyles = MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("span")[0].innerHTML;
          SealCount = MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("span")[0].innerHTML;
          BIHCount = MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("span")[0].innerHTML;
          BIHSealCount = MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("span")[0].innerHTML;
          OrderQty = MoSalesView1_gvSalesView.rows[Row].cells[13].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          CutQty = MoSalesView1_gvSalesView.rows[Row].cells[14].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          StitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[15].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          PackedQty = MoSalesView1_gvSalesView.rows[Row].cells[16].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedQty = MoSalesView1_gvSalesView.rows[Row].cells[17].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          ShippedQty = MoSalesView1_gvSalesView.rows[Row].cells[18].getElementsByTagName("span")[0].innerHTML.replace(" k", "");
          UnstitchedMin = MoSalesView1_gvSalesView.rows[Row].cells[20].getElementsByTagName("span")[0].innerHTML.replace(" L", "");
        }

        if (IkandiPrice == '') {
          IkandiPrice = 0;
        }
        if (FOBSales == '') {
          FOBSales = 0;
        }
        if (MaterialCost == '') {
          MaterialCost = 0;
        }
        if (CMTCosted == '') {
          CMTCosted = 0;
        }
        if (NoOfStyles == '') {
          NoOfStyles = 0;
        }
        if (SealCount == '') {
          SealCount = 0;
        }
        if (BIHCount == '') {
          BIHCount = 0;
        }
        if (BIHSealCount == '') {
          BIHSealCount = 0;
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
        if (UnstitchedMin == '') {
          UnstitchedMin = 0;
        }

        TotalIkandiPrice = parseFloat(TotalIkandiPrice) + parseFloat(IkandiPrice);
        TotalFOBSales = parseFloat(TotalFOBSales) + parseFloat(FOBSales);
        TotalMaterialCost = parseFloat(TotalMaterialCost) + parseFloat(MaterialCost);
        TotalCMTCosted = parseFloat(TotalCMTCosted) + parseFloat(CMTCosted);
        TotalNoOfStyles = parseInt(TotalNoOfStyles) + parseInt(NoOfStyles);
        TotalSealCount = parseInt(TotalSealCount) + parseInt(SealCount);
        TotalBIHCount = parseInt(TotalBIHCount) + parseInt(BIHCount);
        TotalBIHSealCount = parseInt(TotalBIHSealCount) + parseInt(BIHSealCount);
        TotalOrderQty = parseInt(TotalOrderQty) + parseInt(OrderQty);
        TotalCutQty = parseInt(TotalCutQty) + parseInt(CutQty);
        TotalStitchedQty = parseInt(TotalStitchedQty) + parseInt(StitchedQty);
        TotalPackedQty = parseInt(TotalPackedQty) + parseInt(PackedQty);
        TotalUnstitchedQty = parseInt(TotalUnstitchedQty) + parseInt(UnstitchedQty);
        TotalShippedQty = parseInt(TotalShippedQty) + parseInt(ShippedQty);
        TotalUnstitchedMin = parseInt(TotalUnstitchedMin) + parseInt(UnstitchedMin);
      }
      else {
        if (BH != 1) {
          MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[8].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
        }
        else {
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[9].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[10].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[11].getElementsByTagName("input")[0].disabled = true;
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].checked = false;
          MoSalesView1_gvSalesView.rows[Row].cells[12].getElementsByTagName("input")[0].disabled = true;
        }
      }
    }

    if (BH == 1) {
      if (TotalIkandiPrice > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedIkandiPrice")).ClientID %>').innerHTML = "£ " + TotalIkandiPrice.toFixed(2) + " Million"; }
      else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedIkandiPrice")).ClientID %>').innerHTML = ""; }
    }
  debugger;
    //girish
    if (TotalFOBSales > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBiplPrice")).ClientID %>').innerHTML = "₹ " + TotalFOBSales.toFixed(2) + " Cr"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBiplPrice")).ClientID %>').innerHTML = ""; }

    if (TotalMaterialCost > 0) {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_Sum")).ClientID %>').innerHTML = "₹ " + TotalMaterialCost.toFixed(2) + " Cr";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_SumPer")).ClientID %>').innerHTML = " (" + ((TotalMaterialCost / TotalFOBSales) * 100).toFixed(0) + "%)";
    }
    else {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_Sum")).ClientID %>').innerHTML = "";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedFabricAndAccessoryCost_SumPer")).ClientID %>').innerHTML = "";
    }

    if (TotalCMTCosted > 0) {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValue")).ClientID %>').innerHTML = "₹ " + TotalCMTCosted.toFixed(2) + " Cr";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValuePer")).ClientID %>').innerHTML = " (" + ((TotalCMTCosted / TotalFOBSales) * 100).toFixed(0) + "%)";
    }
    else {
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValue")).ClientID %>').innerHTML = "";
      document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedCMTValuePer")).ClientID %>').innerHTML = "";
    }

    if (TotalNoOfStyles > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedStyleNumber")).ClientID %>').innerHTML = TotalNoOfStyles; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedStyleNumber")).ClientID %>').innerHTML = ""; }

    if (TotalSealCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedSealCount")).ClientID %>').innerHTML = TotalSealCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedSealCount")).ClientID %>').innerHTML = ""; }

    if (TotalBIHCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHCount")).ClientID %>').innerHTML = TotalBIHCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHCount")).ClientID %>').innerHTML = ""; }

    if (TotalBIHSealCount > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHSealCount")).ClientID %>').innerHTML = TotalBIHSealCount; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedBIHSealCount")).ClientID %>').innerHTML = ""; }

    if (TotalOrderQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity")).ClientID %>').innerHTML = TotalOrderQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity")).ClientID %>').innerHTML = ""; }

    if (TotalCutQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Cut")).ClientID %>').innerHTML = TotalCutQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Cut")).ClientID %>').innerHTML = ""; }

    if (TotalStitchedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Stitch")).ClientID %>').innerHTML = TotalStitchedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Stitch")).ClientID %>').innerHTML = ""; }

    if (TotalPackedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Packed")).ClientID %>').innerHTML = TotalPackedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Packed")).ClientID %>').innerHTML = ""; }

    if (TotalUnstitchedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Unstitch")).ClientID %>').innerHTML = TotalUnstitchedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedQuantity_Unstitch")).ClientID %>').innerHTML = ""; }

    if (TotalShippedQty > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedShippedQty")).ClientID %>').innerHTML = TotalShippedQty + " k"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedShippedQty")).ClientID %>').innerHTML = ""; }

    if (TotalUnstitchedMin > 0) { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedMinutes_Unstitch")).ClientID %>').innerHTML = TotalUnstitchedMin + " L"; }
    else { document.getElementById('<%=((Label)gvSalesView.FooterRow.FindControl("lblBreakedMinutes_Unstitch")).ClientID %>').innerHTML = ""; }

    window.opener.UpdatePageForSale();
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
</style>
<div align="center" style="font-family: Arial;">
  <asp:HiddenField ID="hdnBH" Value="0" runat="server" />
  <asp:HiddenField ID="hdnWeekHeader" Value="0" runat="server" />
  <asp:HiddenField ID="hdnShipedCheck" runat="server" />
  <asp:GridView ID="gvSalesView" runat="server" AutoGenerateColumns="false" ShowFooter="true" FooterStyle-HorizontalAlign="Center" RowStyle-CssClass="RangeStyle" Width="99%"
    OnRowDataBound="gvSalesView_RowDataBound" OnRowCreated="gvSalesView_RowCreated" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-Height="25px">
    <Columns>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Year</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Month</HeaderTemplate>
        <ItemTemplate>
          <asp:CheckBox ID="chkMonth" onclick="javascript:return CheckMonthWise(this, 1);" runat="server" />
          <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month_Name") %>'></asp:Label>
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
          <asp:Label CssClass="RangeStyle" ID="lblWeekNo" runat="server" Text='<%#Eval("Week_Count") %>'></asp:Label>&nbsp;
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
          <asp:Label ID="lblBiplPrice" Font-Size="11px" CssClass="blue-text" runat="server" Text='<%# (Convert.ToDecimal(Eval("BIPLPrice")) > 0)? Eval("BIPLPrice") : "0.00" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBiplPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBiplPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Material Cost (%)</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblTotalFabricAndAccessoryCost" CssClass="blue-text" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("TotalFabricAndAccessoryCost")) > 0)? Eval("TotalFabricAndAccessoryCost") : "0.00" %>'></asp:Label>
          <asp:Label ID="lblTotalFabricAndAccessoryCostPer" CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td align="center" style="height:30px;">
                <asp:Label ID="lblTotalFabricAndAccessoryCost_Sum" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                <asp:Label ID="lblTotalFabricAndAccessoryCost_SumPer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
              </td>
            </tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr>
              <td align="center" style="height:30px; background-color:#CCCCCC;">
                <asp:Label ID="lblBreakedFabricAndAccessoryCost_Sum" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                <asp:Label ID="lblBreakedFabricAndAccessoryCost_SumPer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
              </td>
            </tr>
          </table>          
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>CMT Costed (%)</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblCMTValue" CssClass="blue-text" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("CMTValue")) > 0)? Eval("CMTValue") : "0.00" %>'></asp:Label>
          <asp:Label ID="lblCMTValuePer" CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td align="center" style="height:30px;">
                <asp:Label ID="lblTotalCMTValue" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                <asp:Label ID="lblTotalCMTValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
              </td>
            </tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr>
              <td align="center" style="height:30px; background-color:#CCCCCC;">
                <asp:Label ID="lblBreakedCMTValue" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                <asp:Label ID="lblBreakedCMTValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
              </td>
            </tr>
          </table> 
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Average SAM (OB W/S)</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblAvgSAM" Font-Size="11px" runat="server" CssClass="unsti" Text='<%# (Convert.ToDecimal(Eval("AvgSAM")) > 0)? Eval("AvgSAM") : "0.00" %>'></asp:Label>
          <asp:Label ID="lblOB" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("OB")) > 0)? Eval("OB") : "0.00" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <asp:Label ID="lblTotalAvgSAM" Font-Size="13px" Font-Bold="true" runat="server" CssClass="unsti"></asp:Label>
          <asp:Label ID="lblTotalOB" Font-Size="13px" Font-Bold="true" runat="server"></asp:Label>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>BE Eff. (%)</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblBreakevenEfficiency" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("BreakevenEfficiency")) > 0)? Eval("BreakevenEfficiency") : "0.00" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <asp:Label ID="lblTotalBreakevenEfficiency" Font-Size="13px" Font-Bold="true" runat="server" CssClass="breff"></asp:Label>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>&nbsp;&nbsp;Styles&nbsp;&nbsp;</HeaderTemplate>
        <ItemTemplate>
          <asp:CheckBox ID="chkStyleNumber" runat="server" />
          &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblStyleNumber" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("StyleCount")) > 0)? Eval("StyleCount") : "0" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalStyleNumber" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedStyleNumber" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>&nbsp;&nbsp;STC&nbsp;&nbsp;</HeaderTemplate>
        <ItemTemplate>
          <asp:CheckBox ID="chkSealCount" runat="server" onclick="javascript:return CheckOnlySTC(this);" />
          &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSealCount" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("SealCount")) > 0)? Eval("SealCount") : "0" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>&nbsp;&nbsp;&nbsp;BIH&nbsp;&nbsp;&nbsp;</HeaderTemplate>
        <ItemTemplate>
          <asp:CheckBox ID="chkBIHCount" runat="server" onclick="javascript:return CheckOnlyBIH(this);" />
          &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBIHCount" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("BIHCount")) > 0)? Eval("BIHCount") : "0" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBIHCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBIHCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>BIH + STC</HeaderTemplate>
        <ItemTemplate>
          <asp:CheckBox ID="chkBIHSealCount" runat="server" onclick="javascript:return CheckOnlyBIHSTC(this);" />
          &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBIHSealCount" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("BIH_SealCount")) > 0)? Eval("BIH_SealCount") : "0" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalBIHSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedBIHSealCount" Font-Size="13px" Font-Bold="true" ForeColor="#0F0F0F" runat="server"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Order Qty</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblQuantity" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%#(Convert.ToInt32(Eval("Quantity")) > 0)? Eval("Quantity") : "0" %>'></asp:Label>
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
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>CTSL (%)</HeaderTemplate>
        <ItemTemplate>
          <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualCutQty")) > 0)? Eval("ActualCutQty") : "0" %>' />
          <asp:Label ID="lblCTSL" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("CTSL")) > 0)? Eval("CTSL") : "0" %>'></asp:Label>
          <asp:Label ID="lblCTSLDiff" Font-Size="11px" runat="server" ForeColor="#0F0F0F"></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <asp:Label ID="lblTotalCTSL" Font-Size="13px" runat="server" Font-Bold="true" CssClass="breff"></asp:Label>
          <asp:Label ID="lblTotalCTSLDiff" Font-Size="13px" runat="server" Font-Bold="true" ForeColor="#0F0F0F"></asp:Label>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <HeaderTemplate>Unstitched Min</HeaderTemplate>
        <ItemTemplate>
          <asp:Label ID="lblMinutes_Unstitch" CssClass="unsti" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("Minutes_Unstitch")) > 0)? Eval("Minutes_Unstitch") : "0.0" %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" style="height:30px;"><asp:Label ID="lblTotalMinutes_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" CssClass="unsti"></asp:Label></td></tr>
            <tr><td style="height:1px; background-color:#000000;"></td></tr>
            <tr><td align="center" style="height:30px; background-color:#CCCCCC;"><asp:Label ID="lblBreakedMinutes_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" CssClass="unsti"></asp:Label></td></tr>
          </table>
        </FooterTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
  <div style="text-align: left; font-size: 13px; font-family: Arial; color: Gray; height:15px; padding-top:15px;">
    <asp:Label ID="lblSelect" runat="server" Text=""></asp:Label>
  </div>
  <%--<div>
    N.B:<asp:Label ID="lblStitchMsg" Style="font-size: 11px; font-weight: bold; font-family: Arial;
      color: black; padding: 1px; text-transform: lowercase;" runat="server" Text=" Machine count = Min Unstitched (in lakhs) / (60 minutes  11.25 working hours per day  no. of working days). Please note working days does not include Sundays and calculations are based on 100% achievement levels and 5% extra machines given for absenteeism."></asp:Label>
  </div>--%>
  <div align="right" style="padding-bottom: 10px;">
    <asp:Button ID="btnSubmit" OnClientClick="JavaScript:return CheckAll();" CssClass="submitmo" runat="server" Text="" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnClear" runat="server" OnClientClick="JavaScript:ClearAll();" CssClass="clear" Text="" />
    <asp:Button ID="btnClose" runat="server" OnClientClick="JavaScript:closeSalesView();" CssClass="close" Text="" />&nbsp;&nbsp;
  </div>
</div>
