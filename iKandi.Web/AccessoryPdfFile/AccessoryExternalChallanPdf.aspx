<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryExternalChallanPdf.aspx.cs"
    Inherits="iKandi.Web.AccessoryPdfFile.AccessoryExternalChallanPdf" %>

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
    td
    {
        border-top: 0px;
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
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="debitnote-table" style="max-width: 100%; margin: 0px auto; border: 0px solid #999;">
        <table cellpadding="0" cellspacing="0" style="max-width: 100%; width: 100%; border: none;
            border: 1px solid #999999; border-bottom: 0px;">
            <thead>
                <tr>
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
                            <asp:Image ID="boutiqueImg" runat="server" />
                            <%--<img src="../../images/boutique-logo.png" />--%>
                        </div>
                    </td>
                    <td>
                        <div id="divbipladdress" style="margin-top: 3px" runat="server">
                        </div>
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="border-top: 1px solid #9999; width: 118px;height: 24px;">
                        Challan No:
                    </td>
                    <td class="borderbottom" style="border-top: 1px solid #9999;height: 24px;">
                        <asp:Label ID="lblChallan" Font-Bold="true" runat="server" Text=""></asp:Label>
                    </td>
                    <asp:HiddenField ID="hdnChallan" runat="server" />
                    <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                </tr>
                <tr id="trPO" runat="server">
                    <td class=" spanHdrColor borderleft0bottom" style="height: 24px;">
                        PO No:
                    </td>
                    <td style="height: 24px;">
                        <asp:Label ID="lblPoNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%--RajeevS --%>
                <tr>
                <td class="spanHdrColor borderleft0bottom" style="height:24px;">
                <span runat="server" id="spn_HSNCode"></span>
                </td>
                <td><asp:Label runat="server" ID="lblHSNcode"></asp:Label></td>
                </tr>
                <%--RajeevS --%>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="height: 24px;">
                        Date:
                    </td>
                    <td class="borderbottom " style="height: 24px;">
                        <%--<asp:TextBox ID="txtChallanDate" Width="80px" runat="server" style="border:0px;" CssClass="do-not-allow-typing"></asp:TextBox>--%>
                       <span style=""> <asp:Label ID="lblChallanDate" Width="80px" runat="server" Style="border: 0px;height:12px;" ></asp:Label></span> 
                    </td>
                </tr>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="vertical-align: inherit;height:24px;">
                        Select:
                    </td>
                    <td class=" texttranceform borderleft0bottom" style="height: 24px;">
                        <%--<asp:CheckBoxList ID="chkProcess" RepeatDirection="Horizontal" RepeatColumns="5"
                            runat="server">
                        </asp:CheckBoxList>--%>
                        <asp:Label ID="lblCheckedList" runat="server" Style="width: 90%; margin-left: 3px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="height: 24px;">
                        <b>To:</b> &nbsp;
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Value="1" Text="External"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Internal"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="spanHdrColor borderleft0bottom" style="height: 24px;">
                        <div id="dvSupplier">
                            <b>M/S:</b> &nbsp;
                            <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="height: 24px;">
                        Acc./Color Print:
                    </td>
                    <td class="bottomborder1" style="text-align: left; height:24px;">
                        <span>
                            <asp:Label ID="lblAccessoryQuality" ForeColor="Blue" Text="" runat="server"></asp:Label>
                            <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                            <asp:Label ID="lblcolorprint" Height="15px" ForeColor="Black" Font-Bold="true" Text=""
                                runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="spanHdrColor borderleft0bottom" style="height: 24px;">
                        Description:
                    </td>
                    <td style="height: 24px;">
                        <%--<asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="93%" runat="server"
                            ReadOnly="true" Style="margin-top: 1px; text-transform: inherit; margin-bottom: 5px"></asp:TextBox>--%>
                        <asp:Label ID="lblDescription" Height="25px" runat="server" style="color:Gray"></asp:Label>
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
                        <%--<asp:TextBox ID="txtSendQty" onkeypress="return isNumberKey(event)" onblur="ChangeSendQty(this)"
                            Width="60px" runat="server"></asp:TextBox>--%>
                        <asp:Label ID="lblSendQty" Height="25px" runat="server"></asp:Label>
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
                        <asp:CheckBox ID="chkReciever" runat="server" />
                        <asp:Label ID="lblRecieverSign" runat="server" Text="Receiver's Signature"></asp:Label><br />
                        <asp:Label ID="lblRecierverDate" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                        padding-right: 2px; font-size: 11px; color: #6b6464">
                        <div class="AuthoriImage">
                            <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" />
                        </div>
                        <asp:CheckBox ID="chkAuthorise" runat="server" />
                        <asp:Label ID="lblAuthoRiseSign" runat="server" Text="Authorized Signature"></asp:Label><br />
                        <asp:Label ID="lblAuthoriseDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </thead>
        </table>
    </div>
    </form>
</body>
</html>
