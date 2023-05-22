<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMTAdminfrom.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.frmCMTAdmin" %>
<style type="text/css">
    .pras th
    {
        background-color: #e6e6e6;
        text-transform: capitalize;
        height: 30px;
        font-weight: normal;
        font-size: 14px;
    }
    
    .header1 td
    {
        background-color: #e6e6e6;
        color: #575759 !important;
        font-size: 11px;
        border: 1px solid #999;
    }
    .pras td
    {
        background-color: #ffffff;
        text-transform: capitalize;
        height: 30px;
        border: 1px solid #e6e6e6;
    }
    .pras .link
    {
        color: #0000ee;
        font-size: 14px;
        text-decoration: underline;
        text-transform: capitalize;
    }
    .link
    {
        color: #0000ee;
        font-size: 14px;
        text-decoration: underline;
        text-transform: capitalize;
    }
    input
    {
        width: 90%;
        padding: 3px 0px;
        text-align: center;
    }
    table
    {
        text-transform: capitalize;
    }
    
    
    .item_list th
    {
        padding: 5px 0px !important;
    }
    .headerAccessories
    {
        background: #39589c;
        text-align: center;
        color: White;
        width: 1050px;
        margin:0 auto;
      
    }
    .item_list TD input[type="text"] {
    width: 95%;
}
  .item_list TD:first-child
  {
      border-left-color:#999 !important;
   }
    .item_list TD:last-child
  {
      border-right-color:#999 !important;
   }
   .item_list tr:last-child > td
  {
      border-bottom-color:#999 !important;
   }
 
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">



    //debugger;
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    function UpdateAccDetails1(ctrl) {
             
        var Cst = $("#<%=txtAvilMinCost.ClientID%>").val();
        var H = $("#<%=txtHour.ClientID%>").val();
        var Barrier = $("#<%=txtBarrierDays.ClientID%>").val();
        var CMTId = $("#<%=hdnCMT.ClientID%>").val();
        var hdnUId = $("#<%=hdnUId.ClientID%>").val();
        var txtpro_availble_mincost = $("#<%=txtpro_availble_mincost.ClientID%>").val();
        var txtproductionhrs = $("#<%=txtproductionhrs.ClientID%>").val();        

        if (txtpro_availble_mincost == "") {
            alert('Please Enter production availble min cost ');
            ctrl.value = ctrl.defaultValue;
            return false;
        }

        var Cost = Math.round(Cst * 100) / 100
        var Hour = Math.round(H * 100) / 100
        var BarrierDays = Barrier

        if (numbersonly(BarrierDays) == true) {
            if (BarrierDays > 30) {
                alert('Please Enter Valid Barrier Days.')
                ctrl.value = ctrl.defaultValue;
                return false;
            }
        }
        else {
            alert('Please Enter Valid Barrier Days.')
            ctrl.value = ctrl.defaultValue;
            return false;
        }

        if (checkhourVal(Hour) == true) {
        }
        else {
            alert('Please Enter Valid Hour.')
            ctrl.value = ctrl.defaultValue;
            return false;
        }
        
        var txtVal = Math.round(ctrl.value * 100) / 100;
        
        if (txtVal != 0) {
            if (isNaN(parseFloat(txtVal)) != "") {
                alert('Please Enter Valid No.');
                ctrl.value = ctrl.defaultValue;
                return false;
            }
            else {
                //debugger;
                proxy.invoke("InsertAvailableMin", { CMTId: CMTId, Cost: Cost, Hour: Hour, BarrierDays: BarrierDays, hdnUId: hdnUId, txtpro_availble_mincost: txtpro_availble_mincost, pro_hours: txtproductionhrs }, function (result) {
                    jQuery.facebox(result);
                    jQuery.facebox('Data has been saved successfully!');

                }, onPageError, false, false);
            }

        }
        else {
            alert('Please Enter Valid No.')
            ctrl.value = ctrl.defaultValue;
            return false;
        }
    }

    // add code by bharat on 25-july
    function UpdateCRTOrderQty(ele, Flag) {
        //debugger;
        var textval = ele.value;
        var objId = ele.id.split("_")[6];
        var Sr_No = $("#<%= grdorderquantity.ClientID %>_" + objId + "_hdnCmtExtraQtyid").val();

        if (isNaN(parseFloat(textval)) != "") {
            alert('Please Enter Valid No.')
            return false;
        }
        else {
            //debugger;
            proxy.invoke("InsertCRTOrderQty", { textval: textval, Sr_No: Sr_No, Flag: Flag }, function (result) {
                jQuery.facebox(result);
                jQuery.facebox('Data has been saved successfully!');

            }, onPageError, false, false);
        }



    }
    // end

    function ReplaceComa(elem) {
        //debugger;
        var ss = elem.value.replace(/,/g, "");
        elem.value = ss;

    }
    function validNumber(elem) {

        var value = elem.value;        
        var txtVal = Math.round(value * 100) / 100
        if (txtVal != 0) {
            if (isNaN(parseFloat(txtVal)) != "") {
                alert('Please Enter Valid No.')
                elem.value = elem.defaultValue;
                return false;
            }
            else {
                return true;
            }
        }
        else {
            alert('Please Enter Valid No.')
            elem.value = elem.defaultValue;
            return false;
        }

    }

    function numbersonly(elem) {
        //debugger;

        var value = elem.value;
        if (value != "") {
            if (value == undefined) {
                var regs = /^\d*[0-9](\d*[0-9])?$/;
                if (value != "") {
                    if (regs.exec(elem)) {
                        return true;
                    }
                    else {
                        //
                        //alert('Enter Only Numeric Value')
                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
            else {
                //var regs = /^\d*[0-9](\.\d*[0-9])?$/;
                regs = /^(-)?\d+(\d\d)?$/;
                if (value != "") {
                    if (regs.exec(value)) {
                        return true;
                    }
                    else {
                        // alert('Enter Only Numeric Value')

                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
        }
        else {

        }

    }

    function checkhourVal(elem) {
        //debugger;
        if (elem > 24.00) {
            return false;
        }
        else {
            return true;
        }


    }

  
    function validNumeric(elem) {
        //debugger;        

        //alert(value);
        var value = elem.value;
        var txtVal = Math.round(value * 100) / 100
        if (isNaN(parseInt(txtVal)) != "") {
            alert('Please Enter Valid No.')
            elem.value = elem.defaultValue;
            return false;
        }
        else if (txtval == "") {
            alert('Field cannot be blank!.')
        }
        else {
            return true;
        }

    }


    function validNumerichousr(elem) {
        //debugger;
        var value = elem.value;
        var txtVal = Math.round(value * 100) / 100
        if (isNaN(parseFloat(txtVal)) != "") {
            alert('Please Enter Valid value.')
            elem.value = elem.defaultValue;
            return false;
        }
        else {
            return true;
        }

    }

    //     Added by abhishek on 27/8/2015

    function UpdateCmtOt(elem) {

        //            var Ids = elem.id;
        //            var cId = Ids.split("_")[6].substr(3);
        var ot1 = document.getElementById('<%= txtot1.ClientID%>').value;
        var ot2 = document.getElementById('<%= txtot2.ClientID%>').value;
        var ot3 = document.getElementById('<%= txtot3.ClientID%>').value;
        var ot4 = document.getElementById('<%= txtot4.ClientID%>').value;

        proxy.invoke("Update_getOtCMTdetails", { ot1: ot1, ot2: ot2, ot3: ot3, ot4: ot4 }, function (result) {

            jQuery.facebox('Data has been updated successfully!');

        }, onPageError, false, false);

    }


    function UpdateProductionPieces(elem) {

        //            var Ids = elem.id;
        //            var cId = Ids.split("_")[6].substr(3);
        var Stiching = document.getElementById('<%= txtStiching.ClientID%>').value;
        var Finishing = document.getElementById('<%= txtFinishing.ClientID%>').value;


        proxy.invoke("Update_getProductionPieces", { Stiching: Stiching, Finishing: Finishing }, function (result) {

            jQuery.facebox('Data has been updated successfully!');

        }, onPageError, false, false);

    }

    //new code 10 feb 2020 starts
    function addCommas(x) {
        //debugger;
        var parts = x.toString().split(".");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        return parts.join(".");
    }
    //new code 10 feb 2020 ends

    function UpdateOBCostPerPieces(elem) {
        //debugger;
        var ActualSalary=0;
        var costPerDay=0;
        var CuttingCost = document.getElementById('<%= txtCuttingCost.ClientID%>').value;
        var FactoryOverHead = document.getElementById('<%= txtOverHeadCost.ClientID%>').value;
        var OBPerPicesCost = document.getElementById('<%= txtOBPerCost.ClientID%>').value;
        var FinishingCost = document.getElementById('<%= txtFinishingCost.ClientID%>').value;
        var FabricCost = document.getElementById('<%= txtFabric.ClientID%>').value;
        var AccesoriesCost = document.getElementById('<%= txtAccesories.ClientID%>').value;

        var ActualWorkingDays = document.getElementById('<%= txtActualWorkingDays.ClientID%>').value;

        
        var WorkingDays = ActualWorkingDays/12;
        //new code 07 feb 2020 start

        var LabourBaseSalary = document.getElementById('<%= txtLabourBaseSalary.ClientID%>').value;
        LabourBaseSalary.replace(",", ""); 
        $("#<%= txtLabourBaseSalary.ClientID %>").val(addCommas(LabourBaseSalary));

        var IGST = document.getElementById('<%= txtIGST.ClientID%>').value;
        var CGST = document.getElementById('<%= txtCGST.ClientID%>').value;
        var SGST = document.getElementById('<%= txtSGST.ClientID%>').value;
        IGST = IGST == "" ? 0 : IGST.toString();
        CGST = CGST == "" ? 0 : CGST.toString();
        SGST = SGST == "" ? 0 : SGST.toString();

        if (LabourBaseSalary == "") {
            LabourBaseSalary = 0;
        }
        else {
             LabourBaseSalary = LabourBaseSalary.toString().replace(",", "");            
        }

        var PFESI = document.getElementById('<%= txtPFEsi.ClientID%>').value;
        if (PFESI == "") {
            PFESI = 0;
        }

        var DiwaliGift = document.getElementById('<%= txtGovtBonus.ClientID%>').value;
        if (DiwaliGift == "") {
            DiwaliGift = 0;
        }
        var Gratuity = document.getElementById('<%= txtGraduatity.ClientID%>').value;
        if (Gratuity == "") {
            Gratuity = 0;
        }

        //var WorkingDays = document.getElementById('<%= txtWorkPerMonth.ClientID%>').value;

        //var WorkingDays = workingPerMonth;        //11 feb 2020

        //new code 07 feb 2020 end

        var cmtOHslot = 0;
        cmtOHslot = document.getElementById('<%= txtCMTOH.ClientID%>').value;
        


        proxy.invoke("Update_OBCostPerPieces", { CuttingCost: CuttingCost, FactoryOverHead: FactoryOverHead, OBPerPicesCost: OBPerPicesCost, FinishingCost: FinishingCost, FabricCost: FabricCost, AccesoriesCost: AccesoriesCost, LabourBaseSalary: LabourBaseSalary, PFESI: PFESI, DiwaliGift: DiwaliGift, Gratuity: Gratuity, ActualWorkingDays: ActualWorkingDays, WorkingDays: WorkingDays,IGST:IGST, CGST:CGST, SGST:SGST,CMTOHSLOT:cmtOHslot }, function (result) {

            jQuery.facebox('Data has been updated successfully!');

        }, onPageError, false, false);

        if (LabourBaseSalary > 0 && PFESI > 0 && DiwaliGift > 0 && Gratuity > 0) {
            ActualSalary = parseFloat(LabourBaseSalary) + (((parseFloat(PFESI) + parseFloat(DiwaliGift) + parseFloat(Gratuity)) * parseFloat(LabourBaseSalary)) / 100);
            //$('#txtActualSalary').val(ActualSalary);
            //            document.getElementById('<%= txtActualSalary.ClientID%>').value = ActualSalary.toString();
            var actual_salary = Math.round(ActualSalary);
            //document.getElementById('<%= txtActualSalary.ClientID%>').value = actual_salary;
            $("#<%= txtActualSalary.ClientID %>").val(addCommas(actual_salary));

             //Math.Round(ActualSalary).toString()

            //costPerDay = parseFloat(ActualSalary) / parseFloat(WorkingDays);

            costPerDay = parseFloat(ActualSalary) / 25.25;
            var cost_perDay = Math.round(costPerDay);
            //            document.getElementById('<%= txtCostPerDay.ClientID%>').value = costPerDay.toFixed(2).toString();
            document.getElementById('<%= txtCostPerDay.ClientID%>').value = cost_perDay;
            //Math.Round(roundText, 0).ToString();

            costPerHour = costPerDay / 8;
            var cost_perHour = Math.round(costPerHour);
            //            document.getElementById('<%= txtCostPerHour.ClientID%>').value = costPerHour.toFixed(2).toString();
            document.getElementById('<%= txtCostPerHour.ClientID%>').value = cost_perHour;

            document.getElementById('<%= txtWorkPerMonth.ClientID%>').value = Math.round(WorkingDays);

        }
        //        if(ActualSalary > 0 && WorkingDays > 0)
        //        {
        //            costPerDay = parseFloat(ActualSalary) / parseFloat(WorkPerMonth);
        //            document.getElementById('<%= txtCostPerDay.ClientID%>').value = costPerDay.toString();
        //        }
        //        if (costPerDay > 0)
        //        {
        //            costPerHour = costPerDay / 8;
        //            document.getElementById('<%= txtCostPerHour.ClientID%>').value = costPerHour.toString();
        //        }
    }



    function UpdateFinancialMonth(elem) {

        //            var Ids = elem.id;
        //            var cId = Ids.split("_")[6].substr(3);
        var MonthFrom = $('#<%= ddlFromMonth.ClientID %> option:selected').val();
        var MonthTo = $('#<%= ddlToMonth.ClientID %> option:selected').val();
        proxy.invoke("Update_FinancialDetail", { MonthFrom: MonthFrom, MonthTo: MonthTo }, function (result) {

            jQuery.facebox('Data has been updated successfully!');

        }, onPageError, false, false);

    }

    // end by abhishek on 27/8/2015

    //     Added by abhishek on 26/10/2015

    function UpdatebarrieDays(elem, Colname) {
        var Ids = elem.id;
        var value = elem.value;
        //            var cId = Ids.split("_")[6].substr(3);
        if (value != "") {
            proxy.invoke("Update_CMT_barrieday", { Colname: Colname, Colval: value }, function (result) {
                jQuery.facebox('Data has been updated successfully!');
            }, onPageError, false, false);
        }
    }

    // end by abhishek on 26/10/2015

    // Added By Ravi kumar on 18-4-18 for Update sunday working
    function UpdateSundayWorking(elem) {
        //debugger;
        var IsSundayWorking;
        if ($(elem).is(':checked')) {
            IsSundayWorking = 1;
        }
        else {
            IsSundayWorking = 0;
        }
        proxy.invoke("UpdateSundayWorking", { IsSundayWorking: IsSundayWorking }, function (result) {
            jQuery.facebox('Data has been updated successfully!');
        }, onPageError, false, false);

    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))

            return false;
        return true;
    }


</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="font-size: 13px; text-align: center; background: #fff;">
    <%--abhishek 27/8/2015--%>
    <%--abhishek 26/10/2015--%>
      <div style="width:100%;clear:both">
        <h2 class="headerAccessories">CMT Admin</h2>
    </div>
    <table width="1050px" cellpadding="0" cellspacing="0" border="0" style="margin:0 auto;">
        <tbody>
            <tr>
                <td width="48%" style="display: none;">
                    <table width="530px" cellpadding="0" cellspacing="0" class="pras" border="0">
                        <tr>
                            <th>
                                Costing parameters
                            </th>
                            <th>
                                &nbsp;
                            </th>
                            <th>
                                Production parameters
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <table width="300" cellpadding="0" cellspacing="0" class="item_list">
                                    <thead>
                                        <tr>
                                            <th width="200px" align="center">
                                                Available Min Cost
                                            </th>
                                            <th width="150px" align="center">
                                                Hours
                                            </th>
                                            <th width="150px" align="center">
                                                Barrier Days
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                <asp:HiddenField ID="hdnCMT" runat="server" />
                                                <asp:HiddenField ID="hdnUId" runat="server" />
                                                <asp:TextBox ID="txtAvilMinCost" MaxLength="5" runat="server" onchange="UpdateAccDetails1(this)"
                                                    ForeColor="#0000ee"></asp:TextBox>
                                            </td>
                                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                <asp:TextBox ID="txtHour" MaxLength="5" runat="server" onchange="UpdateAccDetails1(this)"
                                                    ForeColor="#0000ee"></asp:TextBox>
                                            </td>
                                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                <asp:TextBox ID="txtBarrierDays" MaxLength="5" runat="server" onkeyup="numbersonly(this)"
                                                    onchange="UpdateAccDetails1(this)" ForeColor="#0000ee"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table width="225" cellpadding="0" cellspacing="0" class="item_list">
                                    <thead>
                                        <tr>
                                            <th width="150px" align="center">
                                                Prod Available Min Cost
                                            </th>
                                            <th width="150px" align="center">
                                                Prod Hours
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                <asp:TextBox ID="txtpro_availble_mincost" MaxLength="5" runat="server" onkeyup="validNumerichousr(this)"
                                                    onchange="UpdateAccDetails1(this)" ForeColor="#0000ee"></asp:TextBox>
                                                <%-- <asp:RegularExpressionValidator ID="RegxAmount" runat="server" ControlToValidate="txtpro_availble_mincost"
                                ValidationExpression="^(?=.*\d)\d*(?:\.\d\d)?$" Display="dynamic" ErrorMessage="Not a valid format"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                <asp:TextBox ID="txtproductionhrs" MaxLength="5" runat="server" onkeyup="validNumerichousr(this)"
                                                    onchange="UpdateAccDetails1(this)" ForeColor="#0000ee"></asp:TextBox>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtproductionhrs"
                                ValidationExpression="^(?=.*\d)\d*(?:\.\d\d)?$" Display="dynamic" ErrorMessage="Not a valid Hours"></asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%--end abhishek 26/10/2015--%>
                </td>
                <td width="10px" style="display: none;">
                    &nbsp;&nbsp;
                </td>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0" class="pras item_list">
                        <tr>
                            <th colspan="4" style='font-weight:600'>
                                Overtime Attendance
                            </th>
                            <th colspan="2" style='font-weight:600'>
                                Financial Month
                            </th>                            
                            <th colspan="3">
                            </th>
                        </tr>
                        <tr>
                            <th width="200px" align="center">
                                OT1
                            </th>
                            <th width="150px" align="center">
                                OT2
                            </th>
                            <th width="150px" align="center">
                                OT3
                            </th>
                            <th width="150px" align="center">
                                OT4
                            </th>
                            <th width="150px" align="center">
                                Financial Start Month
                            </th>
                            <th width="150px" align="center">
                                Financial End Month
                            </th>
                           
                            <th width="150px" align="center">
                                This Sunday working
                            </th>
                            <th width="150px" align="center">
                                Costing Fabric Quality Barrier (%)
                            </th>
                            <th width="150px" align="center">
                                Costing Accesories Quality Barrier (%)
                            </th>
                        </tr>
                        <tr>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtot1" MaxLength="4" runat="server" onchange="UpdateCmtOt(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtot2" runat="server" MaxLength="4" onchange="UpdateCmtOt(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtot3" runat="server" MaxLength="4" onchange="UpdateCmtOt(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtot4" runat="server" MaxLength="4" onchange="UpdateCmtOt(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:DropDownList ID="ddlFromMonth" runat="server" ForeColor="#0000ee" onchange="UpdateFinancialMonth(this)">
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">March</asp:ListItem>
                                    <asp:ListItem Value="04">April</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">June</asp:ListItem>
                                    <asp:ListItem Value="07">July</asp:ListItem>
                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:DropDownList ID="ddlToMonth" runat="server" ForeColor="#0000ee" onchange="UpdateFinancialMonth(this)">
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">March</asp:ListItem>
                                    <asp:ListItem Value="04">April</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">June</asp:ListItem>
                                    <asp:ListItem Value="07">July</asp:ListItem>
                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                            <td>
                                <asp:CheckBox ID="chkSundayWorking" OnClick="javascript:UpdateSundayWorking(this)"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFabric" runat="server" MaxLength="2" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccesories" runat="server" MaxLength="2" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="margin-top: 15px" cellpadding="0" cellspacing="0" border="0" class="pras item_list border">
                        <tr>
                            <th colspan="17" style="font-weight:600">
                                Factory & Cutting Cost
                            </th>
                        </tr>
                        <tr>
                            <th width="150px" align="center">
                                Stitching Per OB/Hrly Cost
                            </th>
                            <th width="150px" align="center">
                                Finishing Per OB/Hrly Cost
                            </th>
                            <th width="150px" align="center">
                                Cutting Cost/Per Pcs.
                            </th>
                            <th width="150px" align="center">
                                Factory Overhead/Per Pcs.
                            </th>
                            <th width="150px" align="center">
                                Finishing Cost Per Pcs.
                            </th>
                            <th width="150px" align="center">
                                Labour Base Salary
                            </th>
                            <th width="150px" align="center">
                                PF ESI (%)
                            </th>
                            <th width="150px" align="center">
                                Govt. Mandatory yearly Bonus + Diwali Gifts (%)
                            </th>
                            <th width="150px" align="center">
                            Absenteeism, work stoppage, notice pay, gratuity etc (%)
                            </th>
                            <th width="150px" align="center">
                                Actual Salary 
                            </th>
                            <th width="150px" align="center">
                                Actual Working Days
                            </th>
                            <th width="150px" align="center">
                                Working Days Per Month
                            </th>
                            <th width="150px" align="center">
                                Cost Per day
                            </th>
                            <th width="150px" align="center">
                               Cost Per Hour
                            </th>                                                        
                            <th width="150px" align="center">
                               IGST
                            </th>
                            <th width="150px" align="center">
                               CGST
                            </th>
                            <th width="150px" align="center">
                               SGST
                            </th>
                        </tr>
                        <tr style="margin-top: 2px; margin-bottom: 2px">
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtStiching" runat="server" MaxLength="2" onchange="UpdateProductionPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtFinishing" runat="server" MaxLength="2" onchange="UpdateProductionPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtCuttingCost" runat="server" MaxLength="2" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtOverHeadCost" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtFinishingCost" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">                                
                                <asp:TextBox ID="txtLabourBaseSalary" runat="server"  onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" onclick="ReplaceComa(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtPFEsi" runat="server" MaxLength="5" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtGovtBonus" runat="server" MaxLength="5" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtGraduatity" runat="server" MaxLength="5" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtActualSalary" runat="server" MaxLength="2" ForeColor="#0000ee"
                                    ReadOnly></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">                            
                                <asp:TextBox ID="txtActualWorkingDays" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                                           
                                <asp:TextBox ID="txtWorkPerMonth" runat="server" MaxLength="2" onchange="UpdateOBCostPerPieces(this)"
                                    onkeyup="validNumeric(this)" ForeColor="#0000ee" ReadOnly></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtCostPerDay" runat="server" MaxLength="2" ForeColor="#0000ee"
                                    ReadOnly></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtCostPerHour" runat="server" MaxLength="2" ForeColor="#0000ee"
                                    ReadOnly></asp:TextBox>
                            </td>

                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtIGST" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)" onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtCGST" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)" onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>
                            <td align="center" style="color: #0000ee; font-size: 14px;">
                                <asp:TextBox ID="txtSGST" runat="server" MaxLength="3" onchange="UpdateOBCostPerPieces(this)" onkeyup="validNumeric(this)" ForeColor="#0000ee"></asp:TextBox>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdorderquantity" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                        OnRowDataBound="grdorderquantity_RowDatabound" Style="margin-top: 15px; width: 300px;">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("CMT_AllowedExtraQuantity_Id") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnCmtExtraQtyid" runat="server" Value='<%#Eval("CMT_AllowedExtraQuantity_Id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtminQty" runat="server" Text='<%# Eval("Min_Qty") %>' onchange="UpdateCRTOrderQty(this,'Min')"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Max">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtmaxQty" runat="server" Text='<%# Eval("Max_Qty") %>' onchange="UpdateCRTOrderQty(this,'Max')"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allowed Extra">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAllowedExtra" runat="server" Text='<%# Eval("AllowedExtra") %>'
                                        onchange="UpdateCRTOrderQty(this,'Allowed')"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            
        </tbody>
    </table>
    <br />
    
    <%--end abhishek 27/8/2015--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grdTargetDays" />
        </Triggers>
        <ContentTemplate>
            <div style="width: 1050px; padding-top: 20px; margin:0 auto;">
                <div style="float: left; width: 520px;">
                    <asp:GridView ID="grdTargetDays" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                        Width="520px" CellPadding="0" CellSpacing="0" class="item_list" OnRowCommand="grdTargetDays_RowCommand"
                        OnRowEditing="grdTargetDays_RowEditing" OnRowUpdating="grdTargetDays_RowUpdating"
                        PageSize="14" AllowPaging="false" OnPageIndexChanging="grdTargetDays_PageIndexChanging"
                        OnRowCancelingEdit="grdTargetDays_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="29%" ItemStyle-CssClass="border" HeaderText="Days">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblDays" align="center" Style="color: #0000ee; font-size: 14px;" runat="server"
                                            Text='<%#Eval("Day")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtDays" onkeyup="numbersonly(this)" MaxLength="3" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" Text='<%#Eval("Day")%>' runat="server">%</asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtTDaysFooter" onkeyup="validNumber(this)" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                    </div>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle CssClass="border" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="border" HeaderText="Prod Target Days Eff">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblTDayEff" align="center" Style="color: #0000ee; font-size: 14px;"
                                            runat="server" Text='<%#Eval("TargetDayEff")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtTDayEff" MaxLength="3" onchange="validNumber(this)" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" align="center" Text='<%#Eval("TargetDayEff")%>'
                                            runat="server"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtTDayEffFooter" onkeyup="validNumber(this)" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                    </div>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" ItemStyle-CssClass="border" HeaderText="Costing Target Days Eff">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblCostingTeFF" align="center" Style="color: #0000ee; font-size: 14px;"
                                            runat="server" Text='<%#Eval("CostingTargetDayEff")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtCostingDayEff" MaxLength="3" onchange="validNumber(this)" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" align="center" Text='<%#Eval("CostingTargetDayEff")%>'
                                            runat="server"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:TextBox ID="txtCostingTDayEffFooter" onkeyup="validNumber(this)" Style="text-align: center;
                                            color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                    </div>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="border" HeaderText="Action">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="link">Edit</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="link">Update</asp:LinkButton>
                                        <asp:HiddenField ID="hdnTargetEffID" runat="server" Value='<%#Eval("TargetEffID")%>' />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="link">Cancel</asp:LinkButton></div>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:LinkButton ID="abtnAdd" runat="server" CommandName="Insert" CssClass="link"
                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                    </div>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle CssClass="border" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                <tr style="text-align: center;">
                                    <td width="29%" style="background-color: #e6e6e6;">
                                        <asp:Label ID="lblDaysEmpty" runat="server" Font-Bold="true" Text="Days"></asp:Label>
                                    </td>
                                    <td style="background-color: #e6e6e6;">
                                        <asp:Label ID="lblTDate" runat="server" Font-Bold="true" Text="Target Days Eff"></asp:Label>
                                    </td>
                                    <td style="background-color: #e6e6e6;">
                                        <asp:Label ID="lblAction" runat="server" Font-Bold="true" Text="Action"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="text-align: center;">
                                    <td align="center">
                                        <asp:TextBox ID="txtDaysEmpty" onkeyup="numbersonly(this)" Style="text-align: center;"
                                            Width="80px" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTDayEffEmpty" onkeyup="validNumber(this)" Style="text-align: center;"
                                            Width="80px" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                            CssClass="link" Text="Add" OnClientClick="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" colspan="4">
                                                    Record Not Found!
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div style="float: left; width: 500px; padding-left: 25px;">
                    <table width="520px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center">
                                <%--added by abhishek on 26/10/2015--%>
                                <asp:GridView ID="grdBarrierDays" Visible="false" ShowFooter="false" AutoGenerateColumns="false"
                                    runat="server" Width="520px" CellPadding="0" CellSpacing="0" class="pras" PageSize="10"
                                    AllowPaging="false" OnRowCancelingEdit="grdBarrierDays_RowCancelingEdit" OnRowCommand="grdBarrierDays_RowCommand"
                                    OnRowDataBound="grdBarrierDays_RowDataBound" OnRowEditing="grdBarrierDays_RowEditing"
                                    OnRowUpdating="grdBarrierDays_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25%" ItemStyle-CssClass="border" HeaderText="StartMin">
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:Label ID="lblStartMin" align="center" Width="100px" Style="color: #0000ee; font-size: 14px;"
                                                        runat="server" Text='<%#Eval("StartMin")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtStartMin" onkeyup="validNumeric(this)" Width="100px" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" Text='<%#Eval("StartMin")%>' runat="server"></asp:TextBox>
                                                </div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtStartMinFooter" Width="100px" onkeyup="validNumeric(this)" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                                </div>
                                            </FooterTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle CssClass="border" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="25%" ItemStyle-CssClass="border" HeaderText="EndMin">
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:Label ID="lblEndMin" align="center" Width="100px" Style="color: #0000ee; font-size: 14px;"
                                                        runat="server" Text='<%#Eval("EndMin")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtEndMin" onkeyup="validNumeric(this)" Width="100px" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" align="center" Text='<%#Eval("EndMin")%>' runat="server"></asp:TextBox>
                                                </div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtEndMinffFooter" onkeyup="validNumeric(this)" Width="100px" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-CssClass="border" HeaderText="Barrier">
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:Label ID="lblBarrier" align="center" Width="95px" Style="color: #0000ee; font-size: 14px;"
                                                        runat="server" Text='<%#Eval("Barrier")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtBarrier" onkeyup="validNumeric(this)" Width="95px" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" align="center" Text='<%#Eval("Barrier")%>'
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: center;">
                                                    <asp:TextBox ID="txtBarrierffFooter" Width="95px" onkeyup="validNumeric(this)" Style="text-align: center;
                                                        color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="30%" ItemStyle-CssClass="border" HeaderText="Action">
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="link">Edit</asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="link">Update</asp:LinkButton>
                                                    <asp:HiddenField ID="hdnBarrierId" runat="server" Value='<%#Eval("BarrierId")%>' />
                                                    <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="link">Cancel</asp:LinkButton></div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: center;">
                                                    <asp:LinkButton ID="abtnAdd" runat="server" CommandName="Insert" CssClass="link"
                                                        Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle CssClass="border" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="25%" style="background-color: #e6e6e6;">
                                                    <asp:Label ID="lblDays" runat="server" Font-Bold="true" Text="StartMin"></asp:Label>
                                                </td>
                                                <td style="background-color: #e6e6e6;">
                                                    <asp:Label ID="lblEndMin" runat="server" Font-Bold="true" Text="EndMin"></asp:Label>
                                                </td>
                                                <td style="background-color: #e6e6e6;">
                                                    <asp:Label ID="lblBarrier" runat="server" Font-Bold="true" Text="Barrier"></asp:Label>
                                                </td>
                                                <td style="background-color: #e6e6e6;">
                                                    <asp:Label ID="lblAction" runat="server" Font-Bold="true" Text="Action"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td align="center">
                                                    <asp:TextBox ID="txtStartMinEmpty" onkeyup="numbersonly(this)" Style="text-align: center;"
                                                        Width="50px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBarrierEmpty" onkeyup="validNumber(this)" Style="text-align: center;"
                                                        Width="50px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEndMinEmpty" onkeyup="validNumber(this)" Style="text-align: center;"
                                                        Width="50px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                        CssClass="link" Text="Add" OnClientClick="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    Record Not Found!
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; display: none;" align="left">
                                BIH = PCD - &nbsp;<asp:TextBox ID="txtbih" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'BIHDays');"
                                    Style="text-align: center;" Width="30px" runat="server" MaxLength="2" />
                                Day
                                <hr style="width: 100%; text-align: left;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px;" align="left">
                                Plan Efficiency Before Production &nbsp;<asp:TextBox ID="txtOBPerCost" runat="server"
                                    MaxLength="2" onchange="UpdateOBCostPerPieces(this)" onkeyup="validNumeric(this)"
                                    Width="30px" ForeColor="#0000ee"></asp:TextBox>&nbsp; %
                                <hr style="width: 100%; text-align: left;" />
                            </td>
                            <td style="font-size: 12px;" align="left">
                                CMT Slot OverHead &nbsp;<asp:TextBox ID="txtCMTOH" runat="server"
                                    MaxLength="8" onchange="UpdateOBCostPerPieces(this)" onkeyup="validNumeric(this)"
                                    Width="50px" ForeColor="#0000ee"></asp:TextBox>&nbsp; 
                                <hr style="width: 100%; text-align: left;" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td style="font-size: 12px;" align="left">
                                <table width="100%" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                                    <tr>
                                        <td>
                                            If Calculated Barrier Days Between 0 to
                                            <asp:TextBox ID="txtBarrierDaysSlot1Max" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_1_Max');"
                                                Style="text-align: center;" Width="20px" runat="server" MaxLength="2" />
                                            then Add
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtbarrierdaysCalculate" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_1_Values');"
                                                Style="text-align: center;" Width="30px" runat="server" MaxLength="2" />
                                            Days in buffer
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="border-bottom: 1px solid #000; line-height: 5px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="line-height: 1px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: 1px solid #000;">
                                        <td>
                                            If Calculated Barrier Days between
                                            <asp:TextBox ID="txtBarrierDaysSlot2Min" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_2_Min');"
                                                Style="text-align: center;" Width="20px" runat="server" MaxLength="2" />
                                            to
                                            <asp:TextBox ID="txtBarrierDaysSlot2Max" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_2_Max');"
                                                Style="text-align: center;" Width="20px" runat="server" MaxLength="2" />
                                            then Add &nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtbarriedaycalu2" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_2_Values');"
                                                Style="text-align: center;" Width="30px" runat="server" MaxLength="2" />
                                            Days in buffer
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="border-bottom: 1px solid #000; line-height: 3px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="line-height: 1px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            If Calculated Barrier Days More than or Equal to
                                            <asp:TextBox ID="txtBarrierDaysSlot3Min" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_3_Min');"
                                                Style="text-align: center;" Width="20px" runat="server" MaxLength="2" />
                                            then Add
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtbarriedaycal3" onkeyup="numbersonly(this)" onChange="javascript:return UpdatebarrieDays(this,'Barrier_Days_Slot_3_Values');"
                                                Style="text-align: center;" Width="30px" runat="server" MaxLength="2" />
                                            Days in buffer
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="border-bottom: 1px solid #000; line-height: 3px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h2 style="width: 210px; color: #fff; background: #39589c; text-align: center; margin: 5px 0px;
                                    padding: 1px; font-size: 12px;">
                                    Style Code Range</h2>
                                <asp:GridView ID="grdStyleCodeInterval" ShowHeader="true" AutoGenerateColumns="false"
                                    runat="server" Width="210px" CellPadding="0" BorderColor="Gray" ShowFooter="true"
                                    OnRowCommand="grdStyleCodeInterval_OnRowCommand" CssClass="item_list1" OnRowDeleting="grdStyleCodeInterval_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderText="From">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnRowID" runat="server" Value='<%# Eval("P_Id") %>' />
                                                <asp:Label ID="txtfromQty" Style="text-align: center;" MaxLength="7" Text='<%# Eval("FromRange") %>'
                                                    runat="server" Width="90%" onkeypress="return isNumberKey(event)"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="foo_txtfromQty" Style="text-align: center;" MaxLength="7" runat="server"
                                                    Width="90%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderText="To">
                                            <ItemTemplate>
                                                <asp:Label ID="txttoQty" Style="text-align: center;" MaxLength="7" Text='<%# Eval("ToRange") %>'
                                                    runat="server" Width="90%" onkeypress="return isNumberKey(event)"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="Foo_txttoQty" Style="text-align: center;" MaxLength="7" runat="server"
                                                    Width="90%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Delete" CausesValidation="False">
                                <img src="../../images/del-butt.png" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton runat="server" ID="Submit" OnClick="Add_data" CommandName="Insert">
                               <img src="../../images/add-butt.png" />
                                                </asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <th style="width: 90px;">
                                                    From
                                                </th>
                                                <th style="width: 90px;">
                                                    To
                                                </th>
                                                <th style="width: 40px;">
                                                    Action
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_Empty_fromQty" Text="" Width="95%" MaxLength="7"
                                                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_Empty_toQty" Text="" Width="95%" MaxLength="7"
                                                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="Submit" OnClick="Add_data" CommandName="EmptyInsert">
                        <img src="../../images/add-butt.png" />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <br />
                                <asp:Button runat="server" ID="btnDeleteAll" CssClass="submit" Text="Delete & Recreate Interval"
                                    Style="float: left; width: auto;" OnClick="DeleteAllData" OnClientClick="return confirm('Are you sure to delete the current record?');" />
                            </td>
                        </tr>
                        <%--end by abhishek 26/10/2015--%>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <div style="width:27.2%; float:left; text-align:right;" class="link">Add</div>--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grdAchiev" />
        </Triggers>
        <ContentTemplate>
            <div style="width: 100%; float: left; padding-top: 50px;">
                <asp:GridView ID="grdAchiev" AutoGenerateColumns="false" ShowFooter="true" runat="server"
                    Width="500px" CellPadding="0" CellSpacing="0" class="item_list" PageSize="10"
                    AllowPaging="true" OnPageIndexChanging="grdAchiev_PageIndexChanging" OnRowCancelingEdit="grdAchiev_RowCancelingEdit"
                    OnRowCommand="grdAchiev_RowCommand" OnRowEditing="grdAchiev_RowEditing" OnRowUpdating="grdAchiev_RowUpdating"
                    Style="display: none;">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="70%" ItemStyle-CssClass="border" HeaderText="Achievement Labels">
                            <ItemTemplate>
                                <div style="text-align: center;">
                                    <asp:Label ID="lblAchivementlabels" align="center" Style="color: #0000ee; font-size: 14px;"
                                        runat="server" Text='<%#Eval("Achivementlabels")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div style="text-align: center;">
                                    <asp:TextBox ID="txtAchivementlabels" MaxLength="3" onkeyup="validNumber(this)" Style="text-align: center;
                                        color: #0000ee; font-size: 14px;" Text='<%#Eval("Achivementlabels")%>' runat="server">%</asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center;">
                                    <asp:TextBox ID="txtAchivementlabelsFooter" onkeyup="validNumber(this)" Style="text-align: center;
                                        color: #0000ee; font-size: 14px;" runat="server"></asp:TextBox>
                                </div>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle CssClass="border" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="border" HeaderStyle-Width="30%" HeaderText="Action">
                            <ItemTemplate>
                                <div style="text-align: center;">
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="link">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div style="text-align: center;">
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="link">Update</asp:LinkButton>
                                    <asp:HiddenField ID="hdnAchievementlabelsID" runat="server" Value='<%#Eval("AchievementlabelsID")%>' />
                                    <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="link">Cancel</asp:LinkButton></div>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center;">
                                    <asp:LinkButton ID="abtnAdd" runat="server" CommandName="Insert" CssClass="link"
                                        Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                </div>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle CssClass="border" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                            <tr style="text-align: center;">
                                <td width="50%" style="background-color: #e6e6e6;">
                                    <asp:Label ID="lblAchievementEmpty" runat="server" Style="text-align: center; color: #0000ee;
                                        font-size: 14px;" Font-Bold="true" Text="Achievement Labels"></asp:Label>
                                </td>
                                <td style="background-color: #e6e6e6;">
                                    <asp:Label ID="lblAction" runat="server" Font-Bold="true" Text="Action"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align: center;">
                                <td align="center">
                                    <asp:TextBox ID="txtAchievementEmpty" onkeyup="validNumber(this)" Style="text-align: center;
                                        color: #0000ee; font-size: 14px;" Width="80%" runat="server" />
                                </td>
                                <td>
                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                        CssClass="link" Text="Add" OnClientClick="" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    Record Not Found!
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div style="clear: both;">
</div>
