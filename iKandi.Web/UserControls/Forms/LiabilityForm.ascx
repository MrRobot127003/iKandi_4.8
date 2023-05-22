<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiabilityForm.ascx.cs"
    Inherits="iKandi.Web.LiabilityForm" %>

<script type="text/javascript">
    var quantity;
    var txtAmount;
    var txtCost;
    var txtCalcellationCostClientID = '<%=txtCalcellationCost.ClientID %>';
    var txtFabric1PriceClientID = '<%=txtFabric1Price.ClientID %>';
    var txtFabric2PriceClientID = '<%=txtFabric2Price.ClientID %>';
    var txtFabric3PriceClientID = '<%=txtFabric3Price.ClientID %>';
    var txtFabric4PriceClientID = '<%=txtFabric4Price.ClientID %>';
    var txtAmtFab1ClientID = '<%=txtAmountFabric1.ClientID %>';
    var txtAmtFab2ClientID = '<%=txtAmountFabric2.ClientID %>';
    var txtAmtFab3ClientID = '<%=txtAmountFabric3.ClientID %>';
    var txtAmtFab4ClientID = '<%=txtAmountFabric4.ClientID %>';
    var txtQtyFabClientID1 = '<%=lblFab1Length.ClientID %>';
    var txtQtyFabClientID2 = '<%=lblFab2Length.ClientID %>';
    var txtQtyFabClientID3 = '<%=lblFab3Length.ClientID %>';
    var txtQtyFabClientID4 = '<%=lblFab4Length.ClientID %>';
    var radioCustInvoiceClientID = '<%=chkCustInvoice.ClientID %>';
    var objCurSign = '<%= hdnCurrencySign.ClientID  %>';

    $(function() {
      //  debugger;
        cursign = $("#" + objCurSign).val();
        //alert(cursign);
        $(".currency-sign").text(cursign);

        quantity = $('span.quantity-for-calculation', "#main_content");
        txtAmount = $('input.amount', "#main_content");
        txtCost = $('input.cost', "#main_content");

        Calc(txtAmount, $('input.cost', "#main_content"));

        objAmtFab1ClientID = $("#" + txtAmtFab1ClientID, "#main_content");
        objAmtFab2ClientID = $("#" + txtAmtFab2ClientID, "#main_content");
        objAmtFab3ClientID = $("#" + txtAmtFab3ClientID, "#main_content");
        objAmtFab4ClientID = $("#" + txtAmtFab4ClientID, "#main_content");
        objtxtFabric1PriceClientID = $("#" + txtFabric1PriceClientID, "#main_content");
        objtxtFabric2PriceClientID = $("#" + txtFabric2PriceClientID, "#main_content");
        objtxtFabric3PriceClientID = $("#" + txtFabric3PriceClientID, "#main_content");
        objtxtFabric4PriceClientID = $("#" + txtFabric4PriceClientID, "#main_content");
        objtxtAmtFab1ClientID = $("#" + txtAmtFab1ClientID, "#main_content");
        objtxtAmtFab2ClientID = $("#" + txtAmtFab2ClientID, "#main_content");
        objtxtAmtFab3ClientID = $("#" + txtAmtFab3ClientID, "#main_content");
        objtxtAmtFab4ClientID = $("#" + txtAmtFab4ClientID, "#main_content");
        objtxtQtyFabClientID1 = $("#" + txtQtyFabClientID1, "#main_content");
        objtxtQtyFabClientID2 = $("#" + txtQtyFabClientID2, "#main_content");
        objtxtQtyFabClientID3 = $("#" + txtQtyFabClientID3, "#main_content");
        objtxtQtyFabClientID4 = $("#" + txtQtyFabClientID4, "#main_content");
        objtxtCalcellationCostClientID = $("#" + txtCalcellationCostClientID, "#main_content");

        objAmtFab1ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID1.val())) * (parseFloat(objtxtFabric1PriceClientID.val()))).toFixed(2));
        if (isNaN(objAmtFab1ClientID.val()))
            objAmtFab1ClientID.val(0);
        objAmtFab2ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID2.val())) * (parseFloat(objtxtFabric2PriceClientID.val()))).toFixed(2));
        if (isNaN(objAmtFab2ClientID.val()))
            objAmtFab2ClientID.val(0);
        objAmtFab3ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID3.val())) * (parseFloat(objtxtFabric3PriceClientID.val()))).toFixed(2));
        if (isNaN(objAmtFab3ClientID.val()))
            objAmtFab3ClientID.val(0);
        (objAmtFab4ClientID).val(parseFloat((parseFloat(objtxtQtyFabClientID4.val())) * (parseFloat(objtxtFabric4PriceClientID.val()))).toFixed(2));
        if (isNaN(objAmtFab4ClientID.val()))
            objAmtFab4ClientID.val(0);

        CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);

        $('input.amount', "#main_content").keyup(function(e) {
            Calc(txtAmount, $('input.cost', "#main_content"));
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtFabric1PriceClientID, "#main_content").change(function() {
            objAmtFab1ClientID.val(parseFloat((parseInt(objtxtQtyFabClientID1.val())) * (parseFloat((objtxtFabric1PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab1ClientID.val()))
                objAmtFab1ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtQtyFabClientID1, "#main_content").change(function() {

            objAmtFab1ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID1.val())) * (parseFloat((objtxtFabric1PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab1ClientID.val()))
                objAmtFab1ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtFabric2PriceClientID, "#main_content").change(function() {
            objAmtFab2ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID2.val())) * (parseFloat((objtxtFabric2PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab2ClientID.val()))
                objAmtFab2ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtQtyFabClientID2).change(function() {
            objAmtFab2ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID2.val())) * (parseFloat((objtxtFabric2PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab2ClientID.val()))
                objAmtFab2ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtFabric3PriceClientID, "#main_content").change(function() {
            objAmtFab3ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID3.val())) * (parseFloat((objtxtFabric3PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab3ClientID.val()))
                objAmtFab3ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtQtyFabClientID3, "#main_content").change(function() {
            objAmtFab3ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID3.val())) * (parseFloat((objtxtFabric3PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab3ClientID.val()))
                objAmtFab3ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtFabric4PriceClientID, "#main_content").change(function() {
            objAmtFab4ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID4.val())) * (parseFloat((objtxtFabric4PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab4ClientID.val()))
                objAmtFab4ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("#" + txtQtyFabClientID4, "#main_content").change(function() {
            objAmtFab4ClientID.val(parseFloat((parseFloat(objtxtQtyFabClientID4.val())) * (parseFloat((objtxtFabric4PriceClientID.val())))).toFixed(2));
            if (isNaN(objAmtFab4ClientID.val()))
                objAmtFab4ClientID.val(0);
            CalcCancelCost(objAmtFab1ClientID, objAmtFab2ClientID, objAmtFab3ClientID, objAmtFab4ClientID);
        });

        $("span.liability-docs", "#main_content").each(function() {
            SetupLinks($(this));
        });

    });

    function SetupLinks(container) {
        var html = '';
        var data = container.text();
        var dataArr = data.split('$$');

        for (i = 0; i < dataArr.length; i = i + 2) {
            html += '<span><a  href="/uploads/delivery/' + dataArr[i + 1] + '" target="_blank">' + dataArr[i] + '</a></span><br />';
        }

        container.html(html);
    }

    function Calc(txtAmt, txtTotalCost) {
      
       var AssTotal = 0;
       var amt = 0;
        for (var i = 0; i < quantity.length; i++) {
            var total = 0;
             //amt = parseFloat(txtAmt[i].value).toFixed(2);
            if (txtAmt[i].value == "") {
                amt = 0;
            }
            else
                amt = parseFloat(txtAmt[i].value).toFixed(2);
            total = parseFloat(amt * (quantity[i].innerHTML)).toFixed(2);
           AssTotal = AssTotal + parseFloat(total);
         //  AssTotal = parseFloat(AssTotal + total);
            
            if (!isNaN(total)) {
                txtTotalCost[i].value = total;
            }
            if (isNaN(txtTotalCost[i].value))
                txtTotalCost[i].value = 0;
            //txtTotalCost[i].val('');
        }
        //  var ss = document.getElementById('<%=lblAssSum.ClientID %>');
     
      try {
          if (AssTotal == "undefined") {
              AssTotal = 0;
          }     
        document.getElementById('<%=lblAssSum.ClientID %>').innerHTML ="£ " + parseFloat(AssTotal);
        }
        catch(e)
        {
        }
    }

    function CalcCancelCost(amtFab1, amtFab2, amtFab3, amtFab4) {
     //   debugger;
        var total = 0;
        var f1;
        var f2;
        var f3;
        var f4;

        for (var i = 0; i < txtCost.length; i++) {
            var amt = parseInt(txtCost[i].value);

            total = total + amt;
            objtxtCalcellationCostClientID.val(total);
            if (isNaN(objtxtCalcellationCostClientID.val()))
                objtxtCalcellationCostClientID.val(0);
        }

        if (isNaN(amtFab1.val()) || amtFab1.val() == null || amtFab1.val() == undefined || amtFab1.length == 0)
            f1 = 0;
        else
            f1 = amtFab1.val();
        if (isNaN(amtFab2.val()) || amtFab2.val() == null || amtFab2.val() == undefined || amtFab2.length == 0)
            f2 = 0;
        else
            f2 = amtFab2.val();
        if (isNaN(amtFab3.val()) || amtFab3.val() == null || amtFab3.val() == undefined || amtFab3.length == 0)
            f3 = 0;
        else
            f3 = amtFab3.val();
        if (isNaN(amtFab4.val()) || amtFab4.val() == null || amtFab4.val() == undefined || amtFab4.length == 0)
            f4 = 0;
        else
            f4 = amtFab4.val();


        total = parseFloat(total + parseFloat(f1) + parseFloat(f2) + parseFloat(f3) + parseFloat(f4)).toFixed(2);

        objtxtCalcellationCostClientID.val(total);
        if (isNaN(objtxtCalcellationCostClientID.val()))
            objtxtCalcellationCostClientID.val(0);
    }

    function isConfirmed() {
        var isSave = true;
        var designationID = '<%= iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID %>';
        if (parseInt(designationID) == 19 && objtxtCalcellationCostClientID.val() == null || objtxtCalcellationCostClientID.val() == undefined || parseFloat(objtxtCalcellationCostClientID.val()) == 0) {
            isSave = confirm("CANCELLATION COST OF THIS ORDER IS ZERO. ARE YOU SURE, YOU STILL WANT TO SAVE?");
        }
        return isSave;
    }

</script>

<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="form_box">
            <div class="form_heading">
                <strong>LIABILITY FORM</strong>
            </div>
            <div align="center" style="background-color: #F9DDF4; padding: 10px;">
                <asp:Label ID="lblBuyer" runat="server" Text="Order Details" BackColor="#F9DDF4"
                    CssClass="hide_me"></asp:Label>
                <asp:HiddenField ID="hdnCurrencySign" runat="server" Value="" />
                <strong>Order Details </strong>
            </div>
            <table width="100%" class="item_list">
                <tbody>
                    <tr>
                        <th style="text-align: left">
                            Order Date
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblOrderDate" runat="server" CssClass="date_style blue-text"></asp:Label>
                        </th>
                        <th style="text-align: left">
                            Serial No.
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblSerial" runat="server" CssClass="blue-text"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th style="text-align: left">
                            Department
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblDepartment" runat="server" CssClass="blue-text"></asp:Label>
                        </th>
                        <th style="text-align: left">
                            Contract
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblContracts" runat="server" CssClass="blue-text"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th style="text-align: left">
                            Style
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblStyle" runat="server" CssClass="blue-text"></asp:Label>
                        </th>
                        <th style="text-align: left">
                            Description
                        </th>
                        <th style="text-align: left">
                            <asp:Label ID="lblDescription" runat="server" CssClass="blue-text"></asp:Label>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th colspan="8">
                        <strong>Overall Liability</strong>
                    </th>
                </tr>
                <tr>
                    <th width="12.5%" style="text-align: left">
                        Liability Number
                    </th>
                    <td width="12.5%" style="text-align: left">
                        <asp:Label ID="lblLbtyNo" runat="server"></asp:Label>
                    </td>
                    <th width="12.5%" style="text-align: left">
                        Date Cancelled
                    </th>
                    <td width="12.5%" style="text-align: left">
                        <asp:TextBox ID="txtDateCancelled" Width="90%" runat="server" CssClass="date-picker date_style"></asp:TextBox>
                    </td>
                    <th width="12.5%" style="text-align: left">
                        Quantity Cancelled
                    </th>
                    <td width="12.5%" style="text-align: left">
                        <asp:TextBox ID="txtQuantityCancelled" Width="90%" runat="server" CssClass="numeric-field-without-decimal-places"></asp:TextBox>
                    </td>
                    <th width="12.5%" style="text-align: left">
                        Cancellation Cost
                    </th>
                    <td width="12.5%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblCanceledCostSign" CssClass="currency-sign" runat="server"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtCalcellationCost" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </nobr>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th colspan="8" align="center">
                        <asp:Label ID="lblfabric1" runat="server" Text="Fabric1" CssClass="blue-text"></asp:Label>
                    </th>
                </tr>
                <tr runat="server" id="trFabric1">
                    <th width="12.6%" style="text-align: left">
                        Meters/KG in house
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <asp:TextBox ID="lblFab1Length" runat="server" Width="90%" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Average
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:TextBox ID="lblFabric1Avg" runat="server"></asp:TextBox>
               
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Price per KG/Meter
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblFabric1PriceSign" CssClass="currency-sign"  runat="server"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtFabric1Price" runat="server" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Amount
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblAmountFabric1Sign"  runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtAmountFabric1" runat="server" CssClass="fab1-amount do-not-allow-typing"></asp:TextBox>
                        </nobr>
                    </td>
                </tr>
                <tr>
                    <th colspan="8" align="center">
                        <asp:Label ID="lblfabric2" runat="server" Text="Fabric2" CssClass="blue-text"></asp:Label>
                    </th>
                </tr>
                <tr runat="server" id="trFabric2">
                    <th width="12.6%" style="text-align: left">
                        Meters/KG in house
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <asp:TextBox ID="lblFab2Length" runat="server" Width="90%" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Average
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:TextBox ID="lblFabric2Avg" runat="server"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Price per KG/Meter
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                       <asp:Label ID="lblFabric2Sign" runat="server" CssClass="currency-sign"></asp:Label>
                       <asp:TextBox style="width:80%" ID="txtFabric2Price" runat="server" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                       </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Amount
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                         <asp:Label ID="lblAmountFabric2Sign" runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtAmountFabric2" runat="server" CssClass="fab2-amount numeric-field-with-two-decimal-places do-not-allow-typing"></asp:TextBox>
                        </nobr>
                    </td>
                </tr>
                <tr>
                    <th colspan="8" align="center">
                        <asp:Label ID="lblfabric3" runat="server" Text="Fabric3" CssClass="blue-text"></asp:Label>
                    </th>
                </tr>
                <tr runat="server" id="trFabric3">
                    <th width="12.6%" style="text-align: left">
                        Meters/KG in house
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <asp:TextBox ID="lblFab3Length" Width="90%" runat="server" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Average
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:TextBox ID="lblFabric3Avg" runat="server"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Price per KG/Meter
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblFabric3PriceSign" runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtFabric3Price" runat="server" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Amount
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblAmountFabric3Sign" runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtAmountFabric3" runat="server" CssClass="fab3-amount numeric-field-with-two-decimal-places do-not-allow-typing"></asp:TextBox>
                        </nobr>
                    </td>
                </tr>
                <tr>
                    <th colspan="8" align="center">
                        <asp:Label ID="lblfabric4" runat="server" Text="Fabric4" CssClass="blue-text"></asp:Label>
                    </th>
                </tr>
                <tr runat="server" id="trFabric4">
                    <th width="12.6%" style="text-align: left">
                        Meters/KG in house
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <asp:TextBox ID="lblFab4Length" runat="server" Width="90%" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Average
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:TextBox ID="lblFabric4Avg" runat="server"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Price per KG/Meter
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="LblFabricPriceSign" runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtFabric4Price" runat="server" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                        </nobr>
                    </td>
                    <th width="12.6%" style="text-align: left">
                        Amount
                    </th>
                    <td width="12.6%" style="text-align: left">
                        <nobr>
                        <asp:Label ID="lblAmountFabric4Sign" runat="server" CssClass="currency-sign"></asp:Label>
                        <asp:TextBox style="width:80%" ID="txtAmountFabric4" runat="server" CssClass="fab4-amount numeric-field-with-two-decimal-places do-not-allow-typing"></asp:TextBox>
                        </nobr>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th colspan="5" align="center">
                        <strong>Accessories</strong>
                    </th>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Accessories in house
                    </th>
                    <th>
                        Quantity In House
                    </th>
                    <th>
                        Total Quantity Required <br /> (With 4.4 % Extra)
                    </th>
                    <th>
                        Rate
                    </th>
                    <th style="text-align: right">
                        Amount
                    </th>
                </tr>
                <asp:Repeater ID="repeaterAccessories" runat="server">
                    <ItemTemplate>
                        <tr class="boundry">
                            <td class="boundry" style="text-align: left">
                                <%# (Eval("AccessoryWorkingDetail") as iKandi.Common.AccessoryWorkingDetail).AccessoryName %>
                            </td>
                            <td class="boundry">
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# (Eval("AccessoryWorkingDetail") as iKandi.Common.AccessoryWorkingDetail).Quantity %>'
                                    CssClass="quantity-for-calculation numeric-field-with-three-decimal-places"></asp:Label>
                            </td>
                            <td class="boundry">
                                <asp:Label ID="lblTotalQuantity" runat="server" Text='<%# (Eval("AccessoryWorkingDetail") as iKandi.Common.AccessoryWorkingDetail).TotalQuantity %>'
                                    CssClass="totalquantity-for-calculation numeric-field-with-three-decimal-places"></asp:Label>
                            </td>
                            <td class="boundry">
                                <nobr>
                                <asp:Label ID="lblAccessaryRateSign" runat="server" CssClass="currency-sign"></asp:Label>
                                <asp:TextBox style="width:80%"  ID="txtAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Amount")%>'
                                    CssClass="amount numeric-field-with-two-decimal-places"></asp:TextBox>
                                     </nobr>
                            </td>
                            <td class="boundry" style="text-align: right">
                                <nobr>
                                <asp:Label ID="lblAccessaryAmountSign" runat="server" CssClass="currency-sign"></asp:Label>
                                <asp:TextBox style="width:80%" ID="txtCost" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Cost")%>'
                                    CssClass="cost do-not-allow-typing"></asp:TextBox>
                                     </nobr>
                                <asp:HiddenField ID="hiddenId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"Id")%>' />
                                <asp:HiddenField ID="hiddenAccessoryWorkingDetailID" runat="server" Value='<%# (Eval("AccessoryWorkingDetail") as iKandi.Common.AccessoryWorkingDetail).Id %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
               
            <tr style="border-top:solid 1px #ccc;">
            <td colspan="5" ><table cellpadding="0" cellspacing="0" align="right" width="13%" style="margin-right:70px;">
              <tr>
              <td><b>Total:</b></td>
                <td>
                  <b><asp:Label ID="lblAssSum" runat="server" ></asp:Label> </b>
                  </td>
              </tr>
            </table></td>
            </tr>
            </table>
            
            
        </div>
        
        
        
        
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th colspan="6" align="center">
                        <strong>Boutique Settlement Section</strong>
                    </th>
                </tr>
                <tr>
                    <th style="width: 16.6%; text-align: left">
                        Owner
                    </th>
                    <td style="width: 16.6%; text-align: left">
                        <asp:DropDownList ID="ddlOwner" runat="server">
                        </asp:DropDownList>
                    </td>
                    <th style="width: 16.6%; text-align: left">
                        Hold Till
                    </th>
                    <td style="width: 16.6%; text-align: left">
                        <asp:TextBox ID="txtHoldTillDate" Width="90" runat="server" CssClass="date-picker date_text date_style"></asp:TextBox>
                    </td>
                    <th style="width: 16.6%; text-align: left">
                        Upload documents
                    </th>
                    <td style="width: 16.6%; text-align: left">
                        <asp:HiddenField ID="hdnLiabilityDocs" runat="server" />
                        <asp:Label ID="lblLibilityDocs" runat="server" CssClass="liability-docs"></asp:Label>
                        <asp:FileUpload ID="fileUploadLiabilityDocs" CssClass="multi" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Invoice Number
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtInvoiceNumber" Width="90%" runat="server"></asp:TextBox>
                    </td>
                    <th style="text-align: left">
                        Invoice Date
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtInvoiceDate" Width="90%" runat="server" CssClass="date-picker date_text date_style"></asp:TextBox>
                    </td>
                    <th style="text-align: left">
                        Payment Status
                    </th>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlPayment" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list" runat="server" id="tblIkandi">
                <tr>
                    <th colspan="6" align="center">
                        <strong>Settlement Section</strong>
                    </th>
                </tr>
                <tr>
                    <th style="width: 16%; text-align: left">
                        Acknowledge
                    </th>
                    <td style="width: 10%; text-align: left">
                        <nobr>
                        <asp:CheckBox ID="chkAck" runat="server" Checked="false" />
                        <asp:Label runat="server" ID="lblAckDate"></asp:Label>
                        </nobr>
                    </td>
                    <th style="width: 16%; text-align: left">
                        acceptance to settle
                    </th>
                    <td style="width: 10%; text-align: left">
                        <nobr>
                        <asp:CheckBox ID="chkSettle" runat="server" Checked="false" />
                        <asp:Label runat="server" ID="lblSettlementDate"></asp:Label>
                        </nobr>
                    </td>
                    <th style="width: 16%; text-align: left">
                        raise customer invoice
                    </th>
                    <td style="width: 10%; text-align: left">
                        <nobr>
                        <asp:CheckBox ID="chkCustInvoice" runat="server" Checked="false" />
                        <asp:Label runat="server" ID="lblRaiseInvoiceDate"></asp:Label>
                        </nobr>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th align="center">
                        <strong>Merchant Remarks</strong>
                    </th>
                </tr>
                <tr>
                    <td width="100%">
                        <asp:TextBox ID="txtMerchantRemarks" runat="server" TextMode="MultiLine" Width="99.9%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list">
                <tr>
                    <th align="center">
                        <strong>Documentation Remarks</strong>
                    </th>
                </tr>
                <tr>
                    <td width="100%">
                        <asp:TextBox ID="txtDocumentationRemarks" runat="server" TextMode="MultiLine" Width="99.9%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" CssClass="submit" OnClick="btnSubmit_Click"
            OnClientClick="return isConfirmed();" />
        <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />
        <asp:HiddenField ID="Avg1" Value="" runat="server" />
        <asp:HiddenField ID="Avg2" Value="" runat="server" />
        <asp:HiddenField ID="Avg3"  Value="" runat="server" />
        <asp:HiddenField ID="Avg4" Value="" runat="server" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Liability information have been saved into the system successfully!
            <br />
            <a id="A1" href="~/Internal/Reports/LiabilityReportForm.aspx" runat="server">Click here</a>
            to Liability Report.
        </div>
    </div>
</asp:Panel>
