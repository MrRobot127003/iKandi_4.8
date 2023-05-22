<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoSalesViewBudget.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MoSalesViewTest" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Boutique International Pvt. Ltd.</title>
  <script type="text/javascript">
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
      window.opener.UpdatePageForSale();
    }

    function closeSalesView() {
      //debugger;
      window.opener.ClosePageForSale();
      this.parent.window.close();
      return false;
    }
  </script>
  <style type="text/css">
  .SalesReportHeader th, .SalesReportHeader td
  {
      background:#f6f7f9 !important;
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
  .breff {
    color: #385eaf !important;
  }
    .breakeven {
      color: #100cc8 !important;
      font-weight: bold;
  }
  .unsti {
      color: #666666 !important;

  }
  .total {
      color: #141823 !important;
      font-weight: bold;
  }
</style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upSalesView" runat="server">
      <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="font-family: Arial;">
          <tr>
            <td align="center">
              <asp:HiddenField ID="hdnBH" Value="0" runat="server" />
              <asp:HiddenField ID="hdnWeekHeader" Value="0" runat="server" /> 
              <asp:GridView ID="gvSalesView" runat="server" AutoGenerateColumns="false" ShowFooter="true" FooterStyle-HorizontalAlign="Center" FooterStyle-Height="30px"
                RowStyle-CssClass="RangeStyle" Width="99%" OnRowDataBound="gvSalesView_RowDataBound" OnRowCreated="gvSalesView_RowCreated" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false">
                <Columns>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Year</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate><asp:CheckBox ID="chkMonthHeader" runat="server" AutoPostBack="true" OnCheckedChanged="chkMonthHeader_CheckedChanged" />&nbsp;Month</HeaderTemplate>
                    <ItemTemplate>
                      <asp:CheckBox ID="chkMonth" runat="server" AutoPostBack="true" OnCheckedChanged="chkMonth_CheckedChanged" />
                      <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month_Name") %>'></asp:Label>
                      <asp:HiddenField ID="hdnMonthHeader" Value='<%#Eval("Month") %>' runat="server" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Week</HeaderTemplate>
                    <ItemTemplate>
                      <asp:CheckBox ID="chkDateRange" runat="server" AutoPostBack="true" OnCheckedChanged="chkDateRange_CheckedChanged" />
                      <asp:HiddenField ID="hdnYear" Value='<%#Eval("Year") %>' runat="server" />
                      <asp:HiddenField ID="hdnMonthNameCheck" Value='<%#Eval("Month_Name_Check") %>' runat="server" />
                      <asp:HiddenField ID="hdnMonthNameUnCheck" Value='' runat="server" />
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
                      <asp:Label ID="lblTotalIkandiPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>FOB Sales</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblBiplPrice" Font-Size="11px" CssClass="blue-text" runat="server" Text='<%# (Convert.ToDecimal(Eval("BIPLPrice")) > 0)? Eval("BIPLPrice") : "0.00" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalBiplPrice" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Material Cost (%)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblTotalFabricAndAccessoryCost" CssClass="blue-text" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("TotalFabricAndAccessoryCost")) > 0)? Eval("TotalFabricAndAccessoryCost") : "0.00" %>'></asp:Label>
                      <asp:Label ID="lblTotalFabricAndAccessoryCostPer" CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalFabricAndAccessoryCost_Sum" Font-Size="13px" Font-Bold="true" CssClass="blue-text" runat="server"></asp:Label>
                      <asp:Label ID="lblTotalFabricAndAccessoryCost_SumPer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>CMT Costed (%)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblCMTValue" CssClass="blue-text" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("CMTValue")) > 0)? Eval("CMTValue") : "0.00" %>'></asp:Label>
                      <%--<asp:Label ID="lblAvgCMT" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("AvgCMT")) > 0)? Eval("AvgCMT") : "0.00" %>'></asp:Label>--%>
                      <asp:Label ID="lblCMTValuePer" CssClass="breff" Font-Size="11px" runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalCMTValue" Font-Size="13px" CssClass="blue-text" runat="server"></asp:Label>
                      <%--<asp:Label ID="lblTotalAvgCMT" Font-Size="13px" CssClass="breff" runat="server"></asp:Label>--%>
                      <asp:Label ID="lblTotalCMTValuePer" Font-Size="13px" Font-Bold="true" CssClass="breff" runat="server"></asp:Label>
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
               <%--   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>BE Eff. (%)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblBreakevenEfficiency" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("BreakevenEfficiency")) > 0)? Eval("BreakevenEfficiency") : "0.00" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalBreakevenEfficiency" Font-Size="13px" Font-Bold="true" runat="server" CssClass="breff"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>--%>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>No. Of Styles (Seal)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblStyleNumber" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("StyleCount")) > 0)? Eval("StyleCount") : "0" %>'></asp:Label>
                      <asp:Label ID="lblSealCount" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("SealCount")) > 0)? Eval("SealCount") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalStyleNumber" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                      <asp:Label ID="lblTotalSealCount" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Order Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblQuantity" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%#(Convert.ToInt32(Eval("Quantity")) > 0)? Eval("Quantity") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalQuantity" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Cut Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblQuantity_Cut" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("CutQty")) > 0)? Eval("CutQty") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalQuantity_Cut" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Stitched Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblQuantity_Stitch" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("Stitch")) > 0)? Eval("Stitch") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalQuantity_Stitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Packed Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblQuantity_Packed" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("PackedQty")) > 0)? Eval("PackedQty") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalQuantity_Packed" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Unstitched Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblQuantity_Unstitch" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("Quantity_Unstitch")) > 0)? Eval("Quantity_Unstitch") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalQuantity_Unstitch" Font-Size="13px" Font-Bold="true" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Shipped Qty</HeaderTemplate>
                    <ItemTemplate>
                      <asp:HiddenField ID="hdnShippedQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualShippedQty")) > 0)? Eval("ActualShippedQty") : "0" %>' />
                      <asp:Label ID="lblShippedQty" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%# (Convert.ToInt32(Eval("ShippedQty")) > 0)? Eval("ShippedQty") : "0" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotalShippedQty" Font-Size="13px" runat="server" Font-Bold="true" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>CTSL (%)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# (Convert.ToInt32(Eval("ActualCutQty")) > 0)? Eval("ActualCutQty") : "0" %>' />
                      <asp:Label ID="lblCTSL" CssClass="breff" Font-Size="11px" runat="server" Text='<%# (Convert.ToInt32(Eval("CTSL")) > 0)? Eval("CTSL") : "0" %>'></asp:Label>
                      <asp:Label ID="lblCTSLDiff" Font-Size="11px" runat="server" ForeColor="#0F0F0F"></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                      <asp:Label ID="lblTotalCTSL" Font-Size="13px" runat="server" Font-Bold="true" CssClass="breff"></asp:Label>
                      <asp:Label ID="lblTotalCTSLDiff" Font-Size="13px" runat="server" Font-Bold="true" ForeColor="#0F0F0F"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>
<%--                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Unstitched Min</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblMinutes_Unstitch" CssClass="unsti" Font-Size="11px" runat="server" Text='<%# (Convert.ToDecimal(Eval("Minutes_Unstitch")) > 0)? Eval("Minutes_Unstitch") : "0.0" %>'></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                      <asp:Label ID="lblTotalMinutes_Unstitch" Font-Size="13px" runat="server" Font-Bold="true" CssClass="unsti"></asp:Label>
                    </FooterTemplate>
                  </asp:TemplateField>--%>
                  <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Calc Machines / Operators</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblOB_Unstitch" Font-Size="11px" runat="server" Text='<%# (Convert.ToDouble(Eval("OB_Unstitch")) == 0)? "" : Eval("OB_Unstitch") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>--%>
                  <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Calc Others</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblCalcOthers" Font-Size="11px" runat="server" Text='<%# (Convert.ToInt32(Eval("CalcOthers")) == 0)? "0" : Eval("CalcOthers") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>--%>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
          <tr><td style="height:20px;"></td></tr>
          <tr>
            <td align="right">
              <asp:Button ID="btnSubmit" OnClientClick="JavaScript:return CheckAll();" CssClass="submitmo submit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
              <asp:Button ID="btnClear" runat="server" OnClientClick="JavaScript:ClearAll();" CssClass="clear da_submit_button" Text="Clear" />
              <asp:Button ID="btnClose" runat="server" OnClientClick="JavaScript:closeSalesView();" CssClass="close da_submit_button" Text="Close" />
            </td>
          </tr>
          <tr><td style="height:20px;"></td></tr>
          <tr>
            <td align="center">
              <asp:GridView ID="gvBreakedSalesView" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Size="8" HeaderStyle-Font-Bold="false"
                RowStyle-CssClass="RangeStyle" Width="99%" OnRowDataBound="gvBreakedSalesView_RowDataBound" OnRowCreated="gvBreakedSalesView_RowCreated">
                <Columns>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="blue-text" ID="lblSalesValue" runat="server" Text='<%#Eval("SalesValue") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate>Total CMT</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="blue-text" ID="lblTotalCMT" runat="server" Text='<%#Eval("TotalCMT") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate>CMT Per Pc</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="blue-text" ID="lblCMTValuePerPc" Font-Size="11px" runat="server" Text='<%#Eval("CMTValuePerPc") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate>CMT (%)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="breff" ID="lblCMTPercentage" Font-Size="11px" runat="server" Text='<%#Eval("CMTPercentage") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="breff" ID="lblBreakevenEff" Font-Size="11px" runat="server" Text='<%#Eval("Unstiched_BreakevenEff") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate>Total</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ForeColor="#0F0F0F" ID="lblTotalQty" Font-Size="11px" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                    <HeaderTemplate>Unstitched</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ForeColor="#0F0F0F" ID="lblUnstitchedQty" Font-Size="11px" runat="server" Text='<%#Eval("Quantity_Unstitch") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <HeaderTemplate>Total</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="unsti" ID="lblAvailMin" Font-Size="11px" runat="server" Text='<%#Eval("AvailMin") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                    <HeaderTemplate>Unstitched</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label CssClass="unsti" ID="lblMinutesUnstitch" Font-Size="11px" runat="server" Text='<%#Eval("Minutes_Unstitch") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblPackedQty" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%#Eval("PackedQty") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblShippedQty" Font-Size="11px" runat="server" ForeColor="#0F0F0F" Text='<%#Eval("ShippedQty") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblUnstiched_SamValue" CssClass="unsti" Font-Size="11px" runat="server" Text='<%#Eval("Unstiched_SamValue") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblUnstitchStyles" Font-Size="11px" ForeColor="#0F0F0F" runat="server" Text='<%#Eval("UnstitchStyles") %>'></asp:Label>
                      <asp:Label ID="lblSealCount" Font-Size="11px" ForeColor="#0F0F0F" runat="server" Text='<%#Eval("SealCount") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblAverageOrderSize_Unstitched" ForeColor="#0F0F0F" Font-Size="11px" runat="server" Text='<%#Eval("AverageOrderSize_Unstitched") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblMachines" Font-Size="11px" runat="server" Text='<%#Eval("Machines") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>--%>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </ContentTemplate>
    </asp:UpdatePanel>
    <div style="text-align: center; font-size: 25px; font-family: Arial; color: Gray; height:15px; padding-top:50px;">
      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
  </div>
  </form>
</body>
</html>