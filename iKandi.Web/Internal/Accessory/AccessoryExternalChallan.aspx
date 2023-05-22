<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryExternalChallan.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryExternalChallan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    input
    {
        border-radius: 2px;
        border: 1px solid #999;
        padding-left: 3px !important;
    }
    body
    {
        font-family: Arial !important;
    }
    .debitnote-table
    {
        font-family: Arial !important;
    }
    .debitnote-table .top_heading
    {
        text-transform: capitalize;
        font-size: 15px;
        font-weight: 500;
        padding-top: 3px;
        text-align: center;
        padding-bottom: 5px;
        background: #39589c;
        color: #fff;
    }
    .debitnote-table .address_head
    {
        font-weight: 500;
        font-size: 11px;
        line-height: 15px;
    }
    .debitnote-table .Srnon
    {
        font-weight: 600;
        font-size: 18px;
    }
    tbody td
    {
        padding: 3px 3px;
        font-size: 11px; /* text-transform: uppercase; */
        border: 0px;
    }
    tbody td.borderbottom
    {
        border-bottom: 0px solid #9999;
        border-left: 0px solid #9999;
        padding: 5px 3px;
        font-size: 11px;
        border-collapse: collapse;
    }
    .formcontrol
    {
        width: 98%;
    }
    .formcontrol2
    {
        width: 99%;
    }
    .headerbold
    {
        font-weight: 600;
    }
    ul
    {
        margin: 0;
        padding: 0px 0px;
        max-width: 100%;
        list-style-type: none;
    }
    li
    {
        float: left;
        line-height: 16px;
        padding: 0px;
    }
    .tablewidth
    {
        width: 350px;
        padding: 0px 3px 5px;
        border-bottom: 1px solid #9999;
    }
    .tableto
    {
        width: 80px;
    }
    .bottomborder
    {
        border-bottom: 0px solid #9999;
        padding: 10px 5px;
    }
    .listwidth
    {
        width: 80px;
    }
    tbody td.bordertable
    {
        border-bottom: 0px solid #9999;
        border-left: 0px solid #9999;
        padding: 2px 3px;
        font-size: 11px;
        border-collapse: collapse;
        text-align: center;
    }
    .metercol
    {
        width: 50px;
    }
    .cmcoloum
    {
        width: 40px;
    }
    .checkboxtop
    {
        position: relative;
        top: 2px;
    }
    input
    {
        padding: 1px 0px;
        background: #fff;
        font-size: 10px !important;
        height: 12px;
    }
    .textaria
    {
        width: 82%;
    }
    .inputfield
    {
        width: 95%;
    }
    .bottomborder1
    {
        border-bottom: 0px solid #9999;
        text-align: center;
    }
    .rightborder
    {
        border-right: 0px solid #9999;
    }
    .btnbutton
    {
        background: #1976D2;
        color: #fff;
        border: 1px solid #1976d2;
        padding: 4px;
        border-radius: 3px;
    }
    .headerbacground
    {
        background: #e4e2e2;
        font-size: 11px;
        height: 20px;
        font-weight: 500;
        color: #6b6464;
    }
    
    .p-r-5
    {
        padding-right: 5px;
    }
    .textcenter
    {
        text-align: center;
        font-size: 11px;
    }
    .borderleft
    {
        border-left: 1px solid #9999;
    }
    .borderleft0bottom
    {
        border-bottom: 0px solid #9999;
    }
    .metersr tbody td
    {
        height: 13px;
    }
    .meterQury thead th
    {
        border: 1px solid #999;
        text-align: center;
        font-weight: 500;
    }
    
    .tabletdhei
    {
        height: 16px !important;
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
        line-height: 24px;
        border: none !important;
        border-radius: 2px;
    }
    .btnSubmit:hover
    {
        color: Yellow !important;
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
        line-height: 24px;
        border: none !important;
        border-radius: 2px;
    }
    .btnClose:hover
    {
        color: red;
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
        line-height: 24px;
        border: none !important;
        border-radius: 2px;
    }
    .btnPrint:hover
    {
        color: Yellow !important;
    }
    
    #challanTable2 th
    {
        border: 1px solid #999;
        background: #e4e2e2;
        font-size: 11px;
        height: 20px;
        font-weight: 500;
        color: #6b6464;
    }
    
    .ChallanTable1
    {
        width: 24% !important;
    }
    .TableWidthCha1
    {
        width: 52% !important;
    }
    .FrstHeader
    {
        width: 23% !important;
    }
    .LasttHeader
    {
        width: 21% !important;
    }
    .ChallanTable1Header
    {
        width: 48% !important;
    }
    .txtEditWidth
    {
        text-align: center;
    }
    td #chkProcess td
    {
        padding: 0px 6px 0px 0px !important;
    }
    #chkProcess td input[type="checkbox"]
    {
        position: relative;
        top: 2px;
    }
    .AuthoriImage
    {
        max-width: 150px;
        min-width: 100px;
        min-height: 20px;
        max-height: 45px;
        position: relative;
        top: -5px;
    }
    .AuthoriImage img
    {
        height: 45px;
        margin-top: 5px;
    }
    ::-webkit-scrollbar
    {
        width: 8px;
        height: 8px;
    }
    ::-webkit-scrollbar-thumb
    {
        background: #999;
        border: 1px solid #ddd7d7;
        border-radius: 10px;
    }
    .spanHdrColor
    {
        color: Gray;
    }
    
    .fabric_challan_rategstamout tr td
    {
        padding-right: 40px;
    }
    .fabric_challan_rategstamout tr td span
    {
        font-weight: 600;
        color: gray;
    }
    .fabric_challan_rategstamout tr td .textcolor
    {
        font-weight: 600;
        color: black;
    }
    .textcolor::before
    {
        content: "\20B9";
        margin-right: 5px;
    }
    .textcolor1::after
    {
        content: "%";
        margin-right: 5px;
    }
    
    
    @media print
    {
        .printHideButton
        {
            display: none;
        }
    }
</style>
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
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript">

    //new code start



    function isNumberKey(txt, evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode == 46) {
            //Check if the text already contains the . character
            if (txt.value.indexOf('.') === -1) {
                return true;
            } else {
                return false;
            }
        } else {
            if (charCode > 31 &&
          (charCode < 48 || charCode > 57))
                return false;
        }
        return true;
    }
    function DisplaySendMail() {
        if ($("#chkReciever").is(':checked') && $("#chkAuthorise").is(':checked')) {
            $("#dvSendMail").css("display", "")
            return false;
        }
        else {
            $("#dvSendMail").css("display", "none")
            return false;
        }

    }
    //new code end

    function allowAlphaNumericSpace(e) {
        var code = ('charCode' in e) ? e.charCode : e.keyCode;
        if (!(code > 47 && code < 58) && // numeric (0-9)
    !(code > 64 && code < 91) && // upper alpha (A-Z)
    !(code > 96 && code < 123)) { // lower alpha (a-z)
            e.preventDefault();
        }
    }
    //new code


    var hdnRemainingQtyClientId = '<%=hdnRemainingQty.ClientID%>';
    var hdnSendQtyClientId = '<%=hdnSendQty.ClientID%>';
    var lblRemainingQty = '<%=lblRemainingQty.ClientID%>';
    var txtSendQtyClientId = '<%=txtSendQty.ClientID%>';



    function ChangeSendQty(obj) {
        var rate = $('#<%=lblRate.ClientID %>').text();
        var Cgst = $('#<%=lblcgst.ClientID %>').text();
        var sgst = $('#<%=lblsgst.ClientID %>').text();
        var Igst = $('#<%=lbligst.ClientID %>').text();

        if (Igst == "N/A") {
            Igst = 0;
        }
        if (Cgst == "N/A") {
            Cgst = 0;
        }
        if (sgst == "N/A") {
            sgst = 0;
        }
        var SendQty = $(obj).val();

        SendQty = SendQty.replace(",", "");
        //debugger;
        if (SendQty == '') {
            SendQty = 0;
        }
        if (Cgst != "" && sgst != "") {
            var gst = parseFloat(Cgst) + parseFloat(sgst)
            var TotalAmount = ((parseFloat(SendQty) * parseFloat(rate)) * (100 + gst)) / 100;
        }
        else {
            if (Igst != "") {
                TotalAmount = ((parseFloat(SendQty) * parseFloat(rate)) * (100 + parseFloat(Igst))) / 100;
            }
            else
                TotalAmount = ((parseFloat(SendQty) * parseFloat(rate)));
        }

        $('#<%=lblTotalAmount.ClientID %>').text(TotalAmount.toFixed(2));
        var hdnRemainingQty = $("#" + hdnRemainingQtyClientId).val();
        var hdnSendQty = $("#" + hdnSendQtyClientId).val();
        var SendQtyUnitName = $('#hdnDefault_SendQtyUnitName').val();
        var UnitChange = $('#hdnIsUnitChange').val();
        var ConversionVal = $('#hdnConversionValue').val();

        var RemainingQty = parseFloat(hdnRemainingQty) + (parseFloat(hdnSendQty) - parseFloat(SendQty));

        if (UnitChange == '1') {
            var defaultSendQty = Math.round((parseFloat(SendQty) / parseFloat(ConversionVal)), 2);
            $('#hdnDefaultSendQty').val(defaultSendQty);
            $('#lblDefaultSendQty').text(defaultSendQty);
            $('#lblDefault_SendQtyUnitName').text(SendQtyUnitName);
            var defaultRemainingQty = Math.round(parseFloat(RemainingQty) / parseFloat(ConversionVal), 0);

            $('#hdnDefaultRemainingQty').val(defaultRemainingQty);
            if (parseInt(defaultRemainingQty) > 0) {
                $('#lblDefaultRemainingQty').text(numberWithCommas(defaultRemainingQty));
                $('#lblDefault_RemainingQtyUnitName').text(SendQtyUnitName);
            }
            else {
                $('#lblDefaultRemainingQty').text('');
                $('#lblDefault_RemainingQtyUnitName').text('');
            }
        }

        if (SendQty == 0) {
            alert('Please fill Send Qty');
            $(obj).val('');
            if (RemainingQty >= 0) {
                if (RemainingQty == 0) {
                    $("#" + lblRemainingQty).text('');
                    $('#lblRemainingQtyUnitName').text('');
                }
                else {
                    $("#" + lblRemainingQty).text(numberWithCommas(RemainingQty.toFixed(2)));
                }
            }
            return false;
        }

        if (RemainingQty >= 0) {
            if (RemainingQty == 0) {
                $("#" + lblRemainingQty).text('');
                $('#lblRemainingQtyUnitName').text('');
            }
            else {
                $("#" + lblRemainingQty).text(numberWithCommas(RemainingQty.toFixed(2)));
            }
        }
        else {
            alert('This Qty can not be greater than Total Po Send Qty');
            $(obj).val(numberWithCommas(hdnSendQty));
            return false;
        }
    }
    function HSNValidate() {
        if ($('#lblHSNCode').val() == "") {
            alert("Please Enter HSNCode Of Items.");
            return false;
        }
        else {
            ValidateSubmit();
        }
    }
    function ValidateSubmit() {

        debugger;
        var Rate = $('#<%=lblRate.ClientID %>').text();

        if (Rate == "" || Rate == null) {
            Rate = 0;
            $('#hdnrate').val(Rate);
        }
        else {
            $('#hdnrate').val(Rate);
        }

        var ProDucUnit = $("#ddlProductionUnit").val();
        if (ProDucUnit == "-1") {
            alert("Please Select Production Unit!");
            return false;
        }
        var SendQty = $("#" + txtSendQtyClientId).val();
        if ((SendQty == '') || (SendQty == '0')) {
            alert('Please fill Send Qty');
            return false;
            $("#" + txtSendQtyClientId).focus();
        }
    }
    function closePage() {
        self.parent.parent.PageReload();
        self.parent.Shadowbox.close()
    }

    function disablePage() {
        for (var i = 0; i < document.forms[0].elements.length; i++) {
            //document.forms[0].elements[i].attr('disabled', 'disabled');   
            $('input[type=text]').attr('readonly', 'readonly');
            $('textarea').attr('disabled', 'disabled');
            $('input[type=checkbox]').attr('disabled', 'disabled');
        }

        //        $("#rbtnNo").attr('disabled', false);
        //        $("#rbtnYes").attr('disabled', false);
        //$("#btnSubmit").attr('disabled', false);
    }

    function numberWithCommas(x) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="uproExternalChanllan" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="0">
                <ProgressTemplate>
                    <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                        z-index: 52111; top: 40%; left: 45%; width: 8%;" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="debitnote-table" style="max-width: 100%; margin: 0px auto; border: 0px solid #999;">
                <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnChallan_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnAccessoryQuality" Value="" runat="server" />
                <asp:HiddenField ID="hdnrate" Value="0" runat="server" />
                <table cellpadding="0" cellspacing="0" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-bottom: 0px;">
                    <thead>
                        <tr>
                            <td style="border-bottom: 1px solid #999999;">
                            </td>
                            <td class="top_heading texttranceform bottomborder1" colspan="">
                                Accessory challan
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="TableWidthCha" style="width: 100%; border: none; border: 1px solid #999999;
                    border-top: 0px; border-bottom: 0px; float: left" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td style="width: 85px; border-right: 0px;" rowspan="2" class="barder_top_color">
                                <div style="padding: 9px 7px">
                                    <img src="../../images/boutique-logo.png" />
                                </div>
                            </td>
                            <td>
                                <div id="divbipladdress" runat="server">
                                </div>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom" style="border-top: 1px solid #9999; width: 118px;">
                                Challan No:
                            </td>
                            <td class="borderbottom" style="border-top: 1px solid #9999;">
                                <asp:Label ID="lblChallan" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </td>
                            <asp:HiddenField ID="hdnChallan" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                        </tr>
                        <tr id="trPO" runat="server">
                            <td class=" spanHdrColor borderleft0bottom" style="height: 13px;">
                                PO No:
                            </td>
                            <td>
                                <asp:Label ID="lblPoNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class=" spanHdrColor borderleft0bottom" style="height: 13px;">
                                <span id="spn_HSNCode" runat="server"></span>
                                <%--  <span style="color: red; font-size: 12px;">*</span>--%>
                            </td>
                            <td>
                                <asp:TextBox ID="lblHSNCode" runat="server" Text="" onkeypress="allowAlphaNumericSpace(event)"></asp:TextBox>
                                <%--<asp:Label ID="lblHSNCode" runat="server" Text=""></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom">
                                Date:
                            </td>
                            <td class="borderbottom ">
                                <asp:Label ID="lblChallanDate" runat="server" Text=""></asp:Label>
                                <%--<asp:TextBox ID="txtChallanDate" Width="80px" runat="server" Style="border: 0px;"
                            CssClass="do-not-allow-typing"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom">
                                Select:
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="padding-left: 0px; height: 44px;">
                                <asp:CheckBoxList ID="chkProcess" RepeatDirection="Horizontal" RepeatColumns="5"
                                    runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom">
                                <b>To:</b> &nbsp;
                                <asp:DropDownList ID="ddlType" runat="server">
                                    <asp:ListItem Value="1" Text="External"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Internal"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="spanHdrColor borderleft0bottom">
                                <div id="dvSupplier">
                                    <b>M/S:</b> &nbsp;
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr id="gstt" runat="server">
                            <td class="spanHdrColor borderleft0bottom">
                                <b>GST No.:</b> &nbsp;
                            </td>
                            <td class="spanHdrColor borderleft0bottom">
                                <asp:Label ID="lblSupplierGstNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="aaddress" runat="server">
                            <td class="spanHdrColor borderleft0bottom">
                                <b>Address:</b> &nbsp;
                            </td>
                            <td class="spanHdrColor borderleft0bottom">
                                <asp:Label ID="lblSupplierAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom">
                                Accessories/Color Print:
                            </td>
                            <td class="bottomborder1" style="text-align: left">
                                <span>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="Blue" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblcolorprint" Height="15px" ForeColor="Black" Font-Bold="true" Text=""
                                        runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="spanHdrColor borderleft0bottom">
                                Description
                            </td>
                            <td>
                                <span>
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="93%" runat="server"
                                        Style="margin-top: 1px; text-transform: inherit; margin-bottom: 5px"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 1px solid #999999; border-top: 1px solid #999999" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="rightborder" style="width: 15%;">
                                Send Qty.<span style="color: Red; font-size: 12px;">*</span>
                            </td>
                            <td class="rightborder" style="width: 35%;">
                                <asp:TextBox ID="txtSendQty" onkeypress="return isNumberKey(this, event);" onChange="ChangeSendQty(this)"
                                    Width="60px" runat="server"></asp:TextBox>
                                <asp:Label ID="lblSendQtyUnitName" Style="margin-left: 3px; font-weight: 600" ForeColor="gray"
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnSendQty" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnConversionValue" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnIsUnitChange" Value="0" runat="server" />
                                <asp:Label ID="lblDefaultSendQty" Style="margin-left: 3px;" ForeColor="gray" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnDefaultSendQty" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnDefault_SendQtyUnitName" Value="" runat="server" />
                                <asp:Label ID="lblDefault_SendQtyUnitName" ForeColor="gray" runat="server"></asp:Label>
                            </td>
                            <td class="rightborder" id="tdRemainingQuantity" runat="server" style="width: 20%;">
                                Remaining Qty.
                            </td>
                            <td class="rightborder" style="width: 30%;">
                                <asp:Label ID="lblRemainingQty" Style="text-transform: capitalize; color: gray" runat="server"
                                    Text=""></asp:Label>
                                <asp:HiddenField ID="hdnRemainingQty" Value="0" runat="server" />
                                <asp:Label ID="lblRemainingQtyUnitName" Style="margin-left: 3px; font-weight: 600"
                                    ForeColor="gray" runat="server"></asp:Label>
                                <asp:Label ID="lblDefaultRemainingQty" Style="margin-left: 3px;" ForeColor="gray"
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnDefaultRemainingQty" Value="0" runat="server" />
                                <asp:Label ID="lblDefault_RemainingQtyUnitName" Style="margin-left: 3px; font-weight: 600"
                                    ForeColor="gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblaccExtChallan" runat="server" class="fabric_challan_rategstamout">
                    <tr>
                        <td>
                            <span>Rate:&nbsp;</span>
                            <asp:Label ID="lblRate" runat="server" class="textcolor"></asp:Label>
                        </td>
                        <td runat="server" id="licgst">
                            <span>CGST:&nbsp;</span>
                            <asp:Label ID="lblcgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="lisgst">
                            <span>SGST:&nbsp;</span>
                            <asp:Label ID="lblsgst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td runat="server" id="igst">
                            <span>IGST:&nbsp;</span>
                            <asp:Label ID="lbligst" runat="server" class="textcolor1"></asp:Label>
                        </td>
                        <td>
                            <span>Total Amount:&nbsp;</span>
                            <asp:Label ID="lblTotalAmount" runat="server" class="textcolor"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="MarginTop8" style="max-width: 100%; margin-bottom: 10px; font-size: 12px;
                    width: 100%; margin-top: 5px; border: none; border-top: 0px solid #999;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="" style="padding: 5px 0px 5px 10px; width: 60%;" class="headerbold">
                                Received the goods in good condition
                            </td>
                            <td style="padding: 5px 10px 5px; text-align: right" colspan="">
                                <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 12px;
                                font-size: 11px; color: #6b6464">
                                <div class="AuthoriImage" style="padding-right: 10px;">
                                    <asp:Image ID="imgpartysingature" runat="server" />
                                </div>
                                <asp:CheckBox ID="chkReciever" runat="server" onclick="DisplaySendMail()" />
                                <asp:HiddenField ID="hdnReceiverIsChecked" Value="0" runat="server" />
                                <asp:Label ID="lblRecieverSign" runat="server" Text="Receiver's Signature"></asp:Label><br />
                                <asp:Label ID="lblRecierverDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                                padding-right: 2px; font-size: 11px; color: #6b6464">
                                <div class="AuthoriImage">
                                    <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" />
                                </div>
                                <asp:CheckBox ID="chkAuthorise" runat="server" onclick="DisplaySendMail()" />
                                <asp:HiddenField ID="hdnAuthoriseIsChecked" Value="0" runat="server" />
                                <asp:Label ID="lblAuthoRiseSign" runat="server" Text="Authorized Signature"></asp:Label><br />
                                <asp:Label ID="lblAuthoriseDate" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 0px solid #999999; border-top: 0px solid #999999" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="5" style="text-align: center; padding-top: 5px;">
                            <div class="form_buttom" style="float: left;">
                                <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" ClientIDMode="Static"
                                    OnClientClick="return HSNValidate();" runat="server" Text="Save" OnClick="btnSubmit_Click" />
                            </div>
                            <%-- UseSubmitBehavior="False" OnClientClick="this.disabled = true; ValidateSubmit();"--%>
                            <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                Close</div>
                            <div class="btnPrint printHideButton" onclick="window.print();return false">
                                Print</div>
                            <div id="dvSendMail" style="width: 400px; font-weight: bold; top: 5px; display: none"
                                runat="server" class="printHideButton">
                                &nbsp; &nbsp; Is E-Mail Send:<asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail"
                                    runat="server" CssClass="printHideButton" />
                                <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server"
                                    CssClass="printHideButton" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
