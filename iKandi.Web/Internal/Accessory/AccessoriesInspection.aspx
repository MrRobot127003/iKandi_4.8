<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoriesInspection.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoriesInspection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src="../../js/service.min.js"></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript" src="../../js/form.js"></script>
<script type="text/javascript" src="../../js/facebox.js"></script>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var totalActualLength = 0;
    function isNumber(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 || iKeyCode == 46))
            return false;

        return true;
    }

    //added by raghvinder on 07-012021 start

    //new code
//    function ValidateReceivedFourPoint(elem) {
//        debugger;
//        //new code start
//        var count = 0;
//        totalActualLength = 0;
//        var counter = 1;
//        $("#grv_Accessories_Inspection tr").each(function (e) {
//            //debugger;
//            var length = $("#grv_Accessories_Inspection tr").length;
//            
//            //var rowid = s.split("_")[2];
//            if (length < 9) {
//                if ((count + 1) < (length - 1)) {
//                    var lblactuallengh = $("#grv_Accessories_Inspection_ctl0" + (counter + 1) + "_lblActLength").text();
//                    if (lblactuallengh != "" && lblactuallengh != undefined) {
//                        totalActualLength = totalActualLength + parseInt(lblactuallengh.replace(/\,/g, ''));
//                    }
//                }
//            }
//            else {
//                if ((count + 1) < (length - 1)) {
//                    var lblactuallengh = $("#grv_Accessories_Inspection_ctl" + (counter + 1) + "_lblActLength").text();
//                    if (lblactuallengh != "" && lblactuallengh != undefined) {
//                        totalActualLength = totalActualLength + parseInt(lblactuallengh.replace(/\,/g, ''));
//                    }
//                }
//            }
//            counter = counter + 1;
//        });
//        debugger;
//        // var ReceivedQty = $("#txtTotalQuantity").val();
//        var ReceivedQty = elem.value;
//        if (parseInt(totalActualLength) < parseInt(ReceivedQty.replace(/\,/g, ''))) {
//            alert("Received Quantity can't be greater than Actual Quantity");
//            elem.value = elem.defaultValue.toLocaleString();
//        }     
//    }
    //new code

    function ActualLengthColor(elem, type) {
        //debugger;
        var rowid = elem.id.split("_")[3];

        if (type == 'edit') {
            var claimedQty = $("#grv_Accessories_Inspection_" + rowid + "_txtClaimedLength_Edit").val();
            var actuallength = $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").val();

            if (parseInt(actuallength) < parseInt(claimedQty)) {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#FDFD96;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#FDFD96;color:#000');
            }
            else if (parseInt(actuallength) > parseInt(claimedQty)) {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#FFB7B2;color:#000');
            }
            else {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").parent().attr('style', 'background-color:#fff;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength").attr('style', 'background-color:#fff;color:#000');
            }
        }

        if (type == 'footer') {
            var claimedQty = $("#grv_Accessories_Inspection_" + rowid + "_txtClaimedLength_Footer").val();
            var actuallength = $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").val();

            if (parseInt(actuallength) < parseInt(claimedQty)) {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#FDFD96;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#FDFD96;color:#000');
            }
            else if (parseInt(actuallength) > parseInt(claimedQty)) {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#FFB7B2;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#FFB7B2;color:#000');
            }
            else {
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").parent().attr('style', 'background-color:#fff;color:#000');
                $("#grv_Accessories_Inspection_" + rowid + "_txtActLength_Footer").attr('style', 'background-color:#fff;color:#000');
            }
        }
    }

    //added by raghvinder on 07-01-2021 end

    function CheckCheckedQuantity(elem, type) {
        //debugger;
        var Idsn = elem.id.split("_")[3];
        var checkedqnt = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val().replace(',', '');
       
        var actlength = $("#grv_Accessories_Inspection_" + Idsn + "_txtActLength" + type).val().replace(',', '');

        if (parseInt(checkedqnt) > parseInt(actlength)) {
            alert("Checked Quantity cannot greater than Act length!");
            $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val("");
        }
    }


    //added bu abhishek prevent doing less qty
    function CheckPass() {       
        //debugger;
        var pass = $("#txtPass").val().replace(',', '');
        var StorepassQty = $("#hdnpassqty").val().replace(',', '');
        if (StorepassQty == "") {
            StorepassQty = 0;
        }
        if (pass == "") {
            pass = 0;
        }
        if (parseInt(StorepassQty) > 0) {
            if (parseInt(pass) < parseInt(StorepassQty)) {
                alert("Pass Qty cannot be less then " + StorepassQty);
                $("#txtPass").val(StorepassQty);
            }
        }
    }
    function CheckDecision(elem, type) {       
        //debugger;
        var Idsn = elem.id.split("_")[3];
        var pass = $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val().replace(',', '');

        if (pass == "") {
            pass = 0;
        }
        var fail = $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val().replace(',', '');
        var checked = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val().replace(',', '');
        
        
        if (pass != "" && fail != "") {
            if ((parseInt(pass) + parseInt(fail)) != parseInt(checked)) {
                alert("(Pass + Fail) Quantity should be equal Checked Quantity!");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
            }
            if (((parseInt(fail) * 100) / parseInt(checked)) > 10) {
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
            }
            else {
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
            }
        }
        else if (pass != "" && fail == "") {
            if ((parseInt(pass) + 0) > parseInt(checked)) {
                alert("Pass + Fail Quantity cannot greater than Checked Quantity!");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
            }
            if (((parseInt(fail) * 100) / parseInt(checked)) > 10) {                
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
            }
            else {
                //  $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail_" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
            }
        }
        else if (pass == "" && fail == "") {
            $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).removeAttr("checked");
            $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).removeAttr("checked");
        }

        else {
            if ((0 + parseInt(fail)) > parseInt(checked)) {
                alert("Pass + Fail Quantity cannot greater than Checked Quantity!");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
            }
            if (((parseInt(fail) * 100) / parseInt(checked)) > 10) {
                // $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass_" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail" + type).attr('checked', 'checked');
            }
            else {
                // $("#grv_Accessories_Inspection_" + Idsn + "_rbtFail_" + type).removeAttr("checked");
                $("#grv_Accessories_Inspection_" + Idsn + "_rbtPass" + type).attr('checked', 'checked');
            }
        }

    }

    function ValidateCheckerName() {
        //debugger;
        if ($('#txtCheckerName1').val() == "") {
            alert("Checker Name First cannot blank!");
        }
    }
    function ValidateUnit() {
        if ($('#ddlAllocatedUnit :selected').text() == "Select") {
            alert("Select Allocated Unit!");
        }
    }
    function ValidateReceived() {
        if ($('#txtReceived').val() == "") {
            alert("Received cannot blank!");
        }
        var hdnRecievedVal = $('#hdnReceivedQty').val();
        if (parseInt($('#txtReceived').val().replace(',', '')) > parseInt($('#txtTotalQuantity').val().replace(',', ''))) {
            alert("Received Quantity cannot greater than total Quantity, You need to revise SRV Quantity!");
            if (parseInt(hdnRecievedVal) > 0) {
                $("#txtReceived").val(hdnRecievedVal);
            }
            else {
                $("#txtReceived").val('');
            }         
        }
    }
    function ValidateChecked() {
        if ($('#txtChecked').val() == "") {
            alert("Checked cannot blank!");
        }
        if (parseInt($('#txtChecked').val().replace(',', '')) > parseInt($('#txtReceived').val().replace(',', ''))) {
            alert("Checked quantities cannot greater than received quantity!");
            $("#txtChecked").val("");
        }
    }
    function ValidatePassHoldFail() {
        //debugger;
        var pass = $('#txtPass').val() == "" ? 0 : parseInt($('#txtPass').val().replace(',', ''));
        var fail = $('#txtFail').val() == "" ? 0 : parseInt($('#txtFail').val().replace(',', ''));
        var hold = $('#txtHold').val() == "" ? 0 : parseInt($('#txtHold').val().replace(',', ''));
        if ((pass + fail + hold) != parseInt($('#txtChecked').val().replace(',', ''))) {
            alert("(Pass + Fail + Hold) Quantity should be equal to Checked Quantity!");
            $("#txtPass").val("");
            $("#txtFail").val("");
            $("#txtHold").val("");
            //debugger;
            var holdval = $("#txtHold").val();
            if (holdval != "") {
                $('#chkAccessoriesQA').attr("disabled", true);
                $('#chkAccessoriesGM').attr("disabled", true);
            }
            else {
                $('#chkAccessoriesQA').attr("disabled", false);
                $('#chkAccessoriesGM').attr("disabled", false);
                $("#chkAccessoriesGM").attr('checked', false);
                $("#chkAccessoriesQA").attr('checked', false);
            }
            return false;
        }
    }

    function closePage() {
        //debugger;
        jQuery.facebox('Saved Successfully!');
        self.parent.parent.PageReload();
        self.parent.Shadowbox.close();
    }

    function disablePage() {
        for (var i = 0; i < document.forms[0].elements.length; i++) {
            document.forms[0].elements[i].disabled = true;
        }
    }
    function ShowDiv(StockQty) {
       
        $('#lblRaiseMsg').text("Are you sure to raise debit for " + StockQty + " Qty.");
        $("#modalshow").show();
    }
    function Raise_DebitNote(flag) {
        //alert();
        //debugger;
        var SupplierPoId = $('#hdnSupplierPoId').val();
        var InspectionId = $('#hdnInspectionId').val();
        var StockQty = $('#hdnStockQty').val();


        proxy.invoke("Stock_Qty_Update_ToRaise_DebitNote", { SupplierPO_Id: SupplierPoId, InspectionID: InspectionId, flag: flag, StockQty: StockQty },
                    function (result) {
                        //debugger;
                        closePage();
                    });
                }
            function CheckHoldQty() {
                //debugger;
                var holdval = $("#txtHold").val();
                if (holdval != "") {
                    $('#chkAccessoriesQA').attr("disabled", true);
                    $('#chkAccessoriesGM').attr("disabled", true);
                    $("#chkAccessoriesGM").attr('checked', false);
                    $("#chkAccessoriesQA").attr('checked', false);
                }
                else {
                    $('#chkAccessoriesQA').attr("disabled", false);
                    $('#chkAccessoriesGM').attr("disabled", false);
                }
            }
</script>
<head runat="server">
    <title></title>
    <style type="text/css">
        h2
        {
            margin: 0px;
            padding: 3px 0px;
        }
        .AddClass_Table td
        {
            border-bottom:1px solid #9999;
                height: 14px;
        }
        .AddClass_Table.innerTable td
        {
            text-align: center;
            padding: 0px 0px;
        }
        .AddClass_Table.innerTable td input[type="text"]
        {
            width: 80%;
            text-align: center;
            margin: 2px 0px;
            text-transform: capitalize;
        }
        .AddClass_Table td input[type="text"], .AddClass_Table td textarea
        {
            margin: 1px 0px;
            text-transform: capitalize !important;
        }
        
        .EmptyRowTable td[colspan="8"]
        {
            border: 0px;
            padding: 0px;
        }
        .EmptyRowTable td
        {
            border: 0px;
        }
        .EmptyRowTable td table td
        {
            border: 1px solid #9999;
        }
        .EmptyRowTable td[colspan="10"] input[type="text"]
        {
            width: 80%;
            text-align: center;
            margin: 1px 0px;
        }
        .AddClass_Table.innerTable td a
        {
            text-decoration: none;
        }
        .AddClass_Table.innerTable td label
        {
            position: relative;
            top: -2px;
        }
        .border_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        .bottomTable
        {
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #0c0c0c;
            font-family: Arial, Helvetica, sans-serif;
        }
        .btnBackColor
        {
            background: #39589c !important;
            border: 1px solid #39589c !important;
        }
        .AddClass_Table.innerTable th
        {
            border-top: 0px;
        }
        .txtColorGray
        {
            color: #504c4c !important;
            text-transform: capitalize;
        }
        .btnClose
        {
            color: rgb(255, 255, 255);
            font-size: 11px !important;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 20px;
            line-height: 14px;
            border: none !important;
            border-radius: 2px;
            text-align: center;
        }
        .btnClose:hover
        {
            color: red;
        }
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
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        SELECT
        {
            margin: 1px 0px;
        }
        
        .modalHide
        {
            display: none;
            position: fixed;
            z-index: 1;
            padding-top: 100px;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }
        
        /* Modal Content */
        .txtContainer
        {
            background-color: #fefefe;
            margin: auto;
            padding: 0px 0px 2px 0px;
           /* border: 4px solid #888;*/
            width: 36%;
            border-radius: 5px;
        }
        .TxtHeader
        {
            width: 97%;
            text-align: right;
            padding-right: 5px;
            background: #39589c;
            padding: 8px 4px;
        }
        .TxtHeader span
        {
            color:#fff;
            cursor:pointer;
         }
        .TxtContent
        {
            width: 100%;
            margin: 10px auto;
            padding: 0px 5px 0px 7px;
        }
        .footerCotent
        {
            height: auto;
            width: 94%;
            margin: 5px auto;
            text-align: right;
        }
        .btnYesColo
        {
            background: green;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid green;
            border-radius: 2px;
            font-size: 11px;
        }
        .btnNoColo
        {
            background: red;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid red;
            border-radius: 2px;
            font-size: 11px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:HiddenField ID="hdnTotalQuantity" runat="server" Value="0" />
            <div class="debitnote-table" style="max-width: 900px; margin: -1px auto 5px;">
                <table style="max-width: 100%; width: 100%; border: none; border: 1px solid #999999;
                    border-bottom: 0px solid #999999; margin-bottom: 5px" cellspacing="0" cellpadding="0"
                    class="AddClass_Table">
                    <tbody>
                        <tr>
                            <td class="top_heading " style="padding: 0px 0px;" colspan="3">
                                <h2>
                                    Accessory Inspection System <span style="float: right; cursor: pointer; padding-right: 5px;"
                                        onclick="javascript:self.parent.Shadowbox.close();">X</span></h2>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px;" class="txtColorGray">
                                Accessory (Size)
                            </td>
                            <td class="borderbottom border_right" style="width: 115px;padding-left:5px">
                                <asp:Label ID="lblAccessories" runat="server"></asp:Label>
                            </td>
                            <td rowspan="10" style="vertical-align: top; padding: 0px">
                                <asp:GridView ID="grv_Accessories_Inspection" runat="server" AutoGenerateColumns="false"
                                    Width="100%" CssClass="AddClass_Table innerTable" BorderWidth="0" OnRowDataBound="grv_Accessories_Inspection_RowDataBound"
                                    ShowFooter="true" OnRowCommand="grv_Accessories_Inspection_RowCommand" OnRowDeleting="grv_Accessories_Inspection_RowDeleting"
                                    OnRowEditing="grv_Accessories_Inspection_RowEditing" OnRowUpdating="grv_Accessories_Inspection_RowUpdating"
                                    OnRowCancelingEdit="grv_Accessories_Inspection_RowCancelingEdit">
                                    <EmptyDataRowStyle CssClass="EmptyRowTable" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Roll/Box No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRollNo" runat="server" Text='<%# Bind("BoxNo") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnId" Value='<%# Eval("InspectionParticular_Id") %>' runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRollNo" runat="server" autocomplete="off" Text='<%# Bind("BoxNo") %>'
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>

                                                    <asp:HiddenField ID="hdnParticularId" Value='<%# Eval("InspectionParticular_Id") %>' runat="server" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRollNo_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dyed Lot">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeiLot" runat="server" Text='<%# Bind("DieLot") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDeiLot" autocomplete="off" runat="server" Text='<%# Bind("DieLot") %>'
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDeiLot_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                        </asp:TemplateField>
                                        <%--added on 07 Jan 2021 start--%>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblClaimedLengthHeader" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblClaimedLength" runat="server" Text='<%# Bind("ActLength") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtClaimedLength_Edit" autocomplete="off" runat="server" Text='<%# Bind("ActLength") %>'
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtClaimedLength_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="74px" />
                                            <FooterStyle Width="74px" />
                                        </asp:TemplateField>
                                        <%--added on 07 Jan 2021 end--%>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblLengthHdr" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblActLength" runat="server" Text='<%# Bind("ActLength") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtActLength" autocomplete="off" runat="server" Text='<%# Bind("ActLength") %>' onchange="ActualLengthColor(this,'edit')"
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtActLength_Footer" autocomplete="off" TextMode="SingleLine" runat="server" onchange="ActualLengthColor(this,'footer')"
                                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="74px" />
                                            <FooterStyle Width="74px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Checked">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChecked" runat="server" Text='<%# Bind("CheckedQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtChecked" autocomplete="off" onchange="CheckCheckedQuantity(this,'');"
                                                    runat="server" Text='<%# Bind("CheckedQty") %>' onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtChecked_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)" onchange="CheckCheckedQuantity(this,'_Footer');"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="74px" />
                                            <FooterStyle Width="74px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pass">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPass" runat="server" Text='<%# Bind("PassQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPass" autocomplete="off" onchange="CheckDecision(this,'');" runat="server"
                                                    Text='<%# Bind("PassQty") %>' onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                   
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtPass_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)" onchange="CheckDecision(this,'_Footer');"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="74px" />
                                            <FooterStyle Width="74px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fail">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFail" runat="server" Text='<%# Bind("FailQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFail" autocomplete="off" onchange="CheckDecision(this,'');" runat="server"
                                                    Text='<%# Bind("FailQty") %>' onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFail_Footer" autocomplete="off" TextMode="SingleLine" runat="server"
                                                    onkeypress="javascript:return isNumber(event)" onchange="CheckDecision(this,'_Footer');"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemStyle Width="74px" />
                                            <FooterStyle Width="74px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Decision">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="rbtPass" GroupName="decision" Text="Pass" runat="server" />
                                                <asp:RadioButton ID="rbtFail" GroupName="decision" Text="Fail" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                            <EditItemTemplate>
                                                <asp:RadioButton ID="rbtPass" GroupName="decision" Text="Pass" runat="server" />
                                                <asp:RadioButton ID="rbtFail" GroupName="decision" Text="Fail" runat="server" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:RadioButton ID="rbtPass_Footer" GroupName="decision" Text="Pass" runat="server" />
                                                <asp:RadioButton ID="rbtFail_Footer" GroupName="decision" Text="Fail" runat="server" />
                                            </FooterTemplate>
                                            <FooterStyle Width="130px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkEdit" runat="server" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                                </asp:LinkButton>
                                                <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"><img src="../../images/del-butt.png" /> </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lkUpdate" runat="server" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" />
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lkCancel" runat="server" CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 2px;"/>
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="btnAdd_Footer" runat="server" ImageUrl="~/images/add-butt.png"
                                                    CommandName="AddFooter" />
                                            </FooterTemplate>
                                            <FooterStyle Width="80px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table class="AddClass_Table" border="0" cellpadding="0" cellspacing="0" style="border: 0px;">
                                            <tr>
                                                <th>
                                                    Roll/Box No.
                                                </th>
                                                <th>
                                                    Dye Lot
                                                </th>
                                                <th>
                                                    Claimed Length
                                                </th> 
                                                <th>
                                                    Act. Length/Pcs
                                                </th>
                                                <th>
                                                    Checked
                                                </th>
                                                <th>
                                                    Pass
                                                </th>
                                                <th>
                                                    Fail
                                                </th>
                                                <th style="width: 100px">
                                                    Decision
                                                </th>
                                                <th>
                                                    Add
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtRollNo_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDeiLot_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtClaimedLength_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtActLength_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtChecked_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"
                                                        onchange="CheckCheckedQuantity(this,'_Empty');"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPass_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"
                                                        onchange="CheckDecision(this,'_Empty');"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFail_Empty" autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"
                                                        onchange="CheckDecision(this,'_Empty');"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbtPass_Empty" GroupName="decision" Text="Pass" runat="server" />
                                                    <asp:RadioButton ID="rbtFail_Empty" GroupName="decision" Text="Fail" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnAdd_Empty" runat="server" ImageUrl="~/images/add-butt.png"
                                                        CommandName="AddEmpty" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray" colspan="">
                                Color/Print
                            </td>
                            <td class="borderbottom border_right" style='padding-left: 5px'>
                                <asp:Label ID="lblPrintCol" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray">
                                Supplier Name
                            </td>
                            <td class="borderbottom" style='padding-left: 5px'>
                                <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray">
                                PO No.
                            </td>
                            <td class="borderbottom border_right" style='padding-left: 5px'>
                                <asp:Label ID="lblPO_No" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray">
                                Srv. No.
                            </td>
                            <td class="borderbottom border_right" style='padding-left: 5px'>
                                <asp:Label ID="lblSrvNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray" rowspan="2">
                                Checker Name <span style="color:Red; font-size:12px;">*</span>
                            </td>
                            <td class="txtColorGray" colspan="">
                                <asp:TextBox ID="txtCheckerName1" autocomplete="off" onchange="ValidateCheckerName();"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="borderbottom border_right" colspan="">
                                <asp:TextBox ID="txtCheckerName2" autocomplete="off" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray">
                                Date
                            </td>
                            <td class="borderbottom ">
                                <asp:TextBox ID="txtDate" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray" colspan="" rowspan="">
                                <span runat="server" id="Span6">Total Quantity</span>
                            </td>
                            <td class="borderbottom border_right" colspan="" rowspan="">
                                <asp:TextBox ID="txtTotalQuantity" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray ">
                                Allocated Unit <span style="color:Red; font-size:12px;">*</span>
                            </td>
                            <td class=" border_right">
                                <asp:DropDownList ID="ddlAllocatedUnit" onchange="ValidateUnit();" runat="server"
                                    Height="16px" Width="98px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray">
                                Total (Rolls/Boxes)
                            </td>
                            <td id="tdTotalPcs" runat="server">
                                <asp:Label ID="lblTotalPcs" Text="" runat="server"></asp:Label>
                            </td>
                             <td class=" txtColorGray border_bottom_color" rowspan="6" style=" vertical-align:top; padding-top:2px; padding-bottom:2px;">
                               <span style="color:Black; font-weight:bold;">Comments</span> 
                                <br />
                                <asp:TextBox ID="txtComments" autocomplete="off" runat="server" Height="20px" TextMode="MultiLine"
                                    Width="95%"></asp:TextBox>
                                <div id="dvHistory" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray textcenter" colspan="">
                                Received <span style="color:Red; font-size:12px;">*</span>
                            </td>
                            <td class=" borderbottom textcenter">
                                <asp:TextBox ID="txtReceived" autocomplete="off" onchange="ValidateReceived();" runat="server"
                                    Style="width: 64px" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <span runat="server" id="Span1" style='text-transform: capitalize;color:Gray;font-weight:600'></span>
                                <asp:HiddenField ID="hdnReceivedQty" Value="0" runat="server" />
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="txtColorGray textcenter" colspan="">
                                Checked <span style="color:Red; font-size:12px;">*</span>
                            </td>
                            <td class=" borderbottom textcenter">
                                <asp:TextBox ID="txtChecked" autocomplete="off" onchange="ValidateChecked();" runat="server"
                                    Style="width: 64px" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <span runat="server" id="Span2" style='text-transform: capitalize;color:Gray;font-weight:600'></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray textcenter" colspan="">
                                Pass
                            </td>
                            <td class=" borderbottom textcenter">
                                <asp:TextBox ID="txtPass" autocomplete="off" Style="width: 64px" runat="server" onchange="CheckPass()" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                  <asp:HiddenField ID="hdnpassqty"   runat="server" />
                                <span runat="server" id="Span3" style='text-transform: capitalize;color:Gray;font-weight:600'></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray textcenter" colspan="">
                                Hold
                            </td>
                            <td class=" borderbottom textcenter">
                                <asp:TextBox ID="txtHold" autocomplete="off" Style="width: 64px" runat="server" onchange="javascript:return CheckHoldQty()" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <span runat="server" id="Span4" style='text-transform: capitalize;color:Gray;font-weight:600'></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="txtColorGray textcenter" colspan="">
                                Fail
                            </td>
                            <td class=" borderbottom textcenter">
                                <asp:TextBox ID="txtFail" autocomplete="off" Style="width: 64px" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <span runat="server" id="Span5" style='text-transform: capitalize;color:Gray;font-weight:600'></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table class="bottomTable" style="max-width: 100%; width: 100%;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" style="padding-top: 10px; padding-left: 10px;" class="headerbold">
                                <b>Inspected By</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" style="padding-top: 5px; padding-left: 3px;" class="txtColorGray">
                                <div runat="server" id="divAccessoriesQA">
                                    <asp:CheckBox ID="chkAccessoriesQA" runat="server" />
                                    (Accessories QA)
                                </div>
                                <div runat="server" id="divSigAccessoriesQA" visible="false">
                                    <asp:Image ID="imgAccessoriesQA" runat="server" Height="40px" Width="130px" />
                                    <br />
                                    <asp:Label ID="lblAccessoriesQAName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblAccessoriesQADate" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td colspan="" style="padding-top: 5px; width: 60%" class="headerbold">
                            </td>
                            <td colspan="" style="padding-top: 5px;" class="txtColorGray">
                                <span style="">
                                    <div runat="server" id="divAccessoriesGM">
                                        <asp:CheckBox ID="chkAccessoriesGM" runat="server" />
                                        (Accessories GM)
                                    </div>
                                    <div runat="server" id="divSigAccessoriesGM" visible="false">
                                        <asp:Image ID="imgAccessoriesGM" runat="server" Height="40px" Width="115px" />
                                        <br />
                                        <asp:Label ID="lblAccessoriesGMName" runat="server" Style="line-height: 20px;"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblAccessoriesGMDate" runat="server"></asp:Label>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="printHideButton" style="border-bottom: 2px solid #999; height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center; padding-top: 15px;">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btnbutton_Com printHideButton"
                                    Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return ValidatePassHoldFail()" />
                                <input type="button" class="btnClose printHideButton" value="Close" onclick="javascript:self.parent.Shadowbox.close();" />
                                <asp:Button ID="btnPrint" runat="server" CssClass="btnbutton_Com btnBackColor printHideButton"
                                    Text="Print" OnClientClick="window.print()" />
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="modalHide" id="modalshow">
                <div class="txtContainer">
                    <div class="TxtHeader">
                   <%--  <span onclick="CloseFun()">X</span>--%>
                    </div>
                   
                    <div class="TxtContent">
                        <asp:Label ID="lblRaiseMsg" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnSupplierPoId" Value="-1" runat="server" />
                        <asp:HiddenField ID="hdnInspectionId" Value="-1" runat="server" />
                        <asp:HiddenField ID="hdnStockQty" Value="-1" runat="server" />
                    </div>
                    <div class="footerCotent">
                        <span class="btnYesColo" onclick="Raise_DebitNote(1)" id="btnYes">Yes</span> <span
                            class="btnNoColo" onclick="Raise_DebitNote(0)" id="btnNo">No</span>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
