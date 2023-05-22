<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryLiabilityform.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.Accessory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         .submitDiv
        {
            width: 967px;
            margin: 0 auto;
            margin-top: 5px;            
            text-align:right;
            padding-right:10px;
            border-collapse: collapse;
        }
        .FbaricPurtable
        {
            width: 967px;
            margin: 0 auto;
            margin-top: 5px;
            border-collapse: collapse;
        }
        .FbaricPurtable
        {
            width: 967px;
            margin: 0 auto;
            margin-top: 5px;
            border-collapse: collapse;
        }
        .FbaricPurtable td
        {
            border: 1px solid #dbd8d8;
            border-collapse: collapse;
            padding: 3px 5px;
            font-family: Arial;
            font-size: 10px;
        }
        .FbaricPurtable th
        {
            border: 1px solid #999;
            border-collapse: collapse;
            padding: 3px 5px;
            font-weight: 500;
            background: #dddfe4;
            color: #575759;
            font-family: Arial;
            font-size: 10px;
        }
        .FbaricPurtable td:first-child
        {
            border-left-color: #999 !important;
        }
        .FbaricPurtable td:last-child
        {
            border-right-color: #999 !important;
        }
        .FbaricPurtable tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        .FbaricPurtable td input[type="text"]
        {
            width: 90%;
        }
        .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 55px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
            margin-left: 5px;
            text-align: center;
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
            text-align: center;
            text-transform: capitalize;
        }
        .FbaricPurtable.topTable td
        {
            width: 25%;
            border:1px solid #999;
        }
        .txtCenter
        {
            text-align:center;
        }
    </style>
</head>
<body>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
   
    <script type="text/javascript">
        var hdnSrvQtyClientId = '<%=hdnSrvQty.ClientID%>';
        var hdnLiabilityQtyClientId = '<%=hdnLiabilityQty.ClientID%>';
        var txtLiabilityQtyClientId = '<%=txtLiabilityQty.ClientID%>';

        function OnLiablityChange(obj) {
            var SrvQty = $("#" + hdnSrvQtyClientId).val();
            var Liability = $(obj).val();
            if (parseInt(Liability) > 0) {
                if (parseInt(Liability) > parseInt(SrvQty)) {
                    jQuery.facebox('Liability Qty can not be greater than SrvQty');
                    $(obj).val('');
                    return false;
                }
            }
            $("#" + hdnLiabilityQtyClientId).val(Liability);
        }

        function ValidateLiability() {
            var Liability = $("#" + txtLiabilityQtyClientId).val();
            if ((Liability == '') || (Liability == '0')) {
                jQuery.facebox('Liability Qty can not be 0 or Empty');
                $("#" + txtLiabilityQtyClientId).focus();
                return false;
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <form id="form1" runat="server">
    <div>
        <table border="0" class="FbaricPurtable topTable" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="8" style="color: #fff; background: #39589c; font-weight: normal !important;
                    font-size: 14px; border-color: #999">
                    <span>Accessory Liability Form</span>
                </th>
            </tr>
        </table>
        <table class="FbaricPurtable topTable" width="100%" style="margin-top: 5px; border: #999;
            border-left-color: #999;">
            <tbody>
                <tr>
                    <td style="border-left-color: #999;">
                        PO. No:
                        <asp:Label ID="lblPoNo" Width="80px" Style="font-weight: bold; font-size: 12px;"
                            runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnPoNo" runat="server" />
                        <asp:HiddenField ID="hdnSupplierPoId" Value="-1" runat="server" />
                    </td>
                    <td>
                        PO. Date:
                        <asp:TextBox ID="txtPoDate" Width="100px" CssClass="PODate do-not-allow-typing" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Supplier:
                        <asp:Label ID="lblSupplier" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        ETA Date:
                        <asp:TextBox ID="txtETADate" Width="100px" onkeypress="return false;" CssClass="EtaDate do-not-allow-typing"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" class="FbaricPurtable">
            <thead>
                <tr>
                    <th class="ths">
                        Accessory Quality (Size) Color/Print
                    </th>
                    <th class="ths" style="width: 60px;">
                        Shrinkage
                    </th>
                    <th class="ths" style="width: 60px;">
                        Wastage
                    </th>
                    <th class="ths" style="width: 60px;">
                        Accessory Type
                    </th>
                    <th class="ths" style="width: 80px;">
                        Po Qty.
                    </th>
                    <th class="ths" style="width: 80px;">
                        Contract Qty.
                    </th>
                    <th class="ths" style="width: 80px;">
                        Send Qty.
                    </th>
                    <th class="ths" style="width: 80px;">
                        SRV Qty.
                    </th>
                    <th class="ths" style="width: 80px;">
                        Liability against SRV
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="lblAccessoryQuality" ForeColor="Black" Text="" runat="server"></asp:Label>
                        <asp:Label ID="lblSize" Text="" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblcolorprint" ForeColor="Black" Text="" runat="server"></asp:Label>
                    </td>
                    <td class="txtCenter">
                        <asp:Label ID="lblShrinkage" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="txtCenter">
                        <asp:Label ID="lblWastage" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="txtCenter">
                        <asp:Label ID="lblAccessType" runat="server"></asp:Label>
                    </td>
                    <td class="txtCenter" >
                        <asp:Label ID="lblPoQty" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnPoQty" runat="server" />
                        <asp:HiddenField ID="hdnOrderQty" runat="server" />
                    </td>
                    <td class="txtCenter" >
                        <asp:Label ID="lblContractQty" runat="server" Text=""></asp:Label>                       
                    </td>
                    <td class="txtCenter" >
                        <asp:Label ID="lblSendQty" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnSendQty" runat="server" />
                    </td>
                    <td class="txtCenter" >
                        <asp:Label ID="lblSrvQty" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnSrvQty" runat="server" />
                    </td>
                    <td class="txtCenter">
                        <asp:TextBox ID="txtLiabilityQty" onkeypress="return isNumberKey(event)" MaxLength="6"
                            Style="width: 95% !important; text-align: center;" onblur="javascript:return OnLiablityChange(this)"
                            runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hdnLiabilityQty" Value="0" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="submitDiv">            
            <asp:Button ID="btnSubmit" Style="" runat="server" Text="Submit" OnClientClick="javascript:return ValidateLiability()"
                CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            <div class="btnClose printHideButton" onclick="

              
        </div>        
    </div>
    </form>
</body>
</html>
