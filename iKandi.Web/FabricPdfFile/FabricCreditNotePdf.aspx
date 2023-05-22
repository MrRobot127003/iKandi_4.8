<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricCreditNotePdf.aspx.cs"
    Inherits="iKandi.Web.FabricPdfFile.FabricCreditNotePdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fabric Credit Note Pdf</title>
    <style type="text/css">
        .FabricCreaditNote
        {
            max-width: 99.8%;
            margin: 0 auto;
            font-family: arial; /*width:70%;*/
        }
        .top_heading
        {
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 2px;
            background: #39589c;
            color: #fff;
        }
        .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .border_right
        {
            border-right: 1px solid #999999 !important;
        }
        .border_left
        {
            border-left: 1px solid #999999 !important;
        }
        .headerbold
        {
            background: #e4e2e2;
            text-align: center;
            border-right: 1px solid #999999;
        }
        .gridtable td
        {
            border-bottom: 1px solid #dbd8d8;
        }
        .txtwdth
        {
            width: 69%;
        }
        .txtbillwidth
        {
            width: 45%;
        }
        input
        {
            font-size: 10px !important;
        }
        .txtdatewidth
        {
            width: 54%;
        }
        .inputfildwidth
        {
            width: 95% !important;
        }
        
        .grdviewtable th
        {
            background: #e4e2e2;
            text-align: center;
            font-weight: 500;
            font-size: 12px !important;
            color: #575759;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 11px !important;
            border-color: #999999;
        }
        .grdviewtable td:nth-child(2)
        {
            text-align: left;
            padding-left: 5px;
        }
        
        .grdviewtable
        {
            border-top: 0px;
        }
        .grdviewtable th
        {
            border-top: 0px;
            border-color: #999999;
        }
        
        a
        {
            text-decoration: none;
        }
        .bottomtable td
        {
            font-size: 11px;
        }
        .textCenter
        {
            text-align: center;
        }
        input[type='text']
        {
            font-size: 11px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: Arial;
            height: 12px;
            margin: 2px 0px;
        }
        
        .TaskFabricTable
        {
            width: 800px !important;
            margin-top: 5px;
        }
        
        td input[type="text"].txtCenter
        {
            text-align: center;
        }
        
        .indianCurr::after
        {
            content: "₹";
            color: green;
        }
        
        .HideArrowAndBorder
        {
            -webkit-appearance: none;
            border: 0px;
        }
        
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
        }
        .emptytable td
        {
            text-align: center;
            font-size: 11px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="FabricCreaditNote">
        <asp:HiddenField ID="hdnrowcount" runat="server" />
        <asp:HiddenField ID="hdnDebitnotid" runat="server" />
        <asp:HiddenField ID="hdndbptids" runat="server" />
        <asp:HiddenField ID="hdnGST_No" runat="server" Value="0" />
        <asp:HiddenField ID="hdnDebitNoteNumber" Value="0" runat="server" />
        <table style="max-width: 938px; width: 938px; border: 1px solid #999999; border-bottom: 0px solid #999999"
            cellspacing="0" cellpadding="0">
            <thead>
                <tr>
                    <td colspan="3" class="top_heading">
                        Fabric Credit Note
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 125px;">
                        <div style="padding: 9px 7px">
                            <asp:Image ID="boutiqueImg" runat="server" />
                            <%--<img src="../../images/boutique-logo.png" />--%>
                        </div>
                    </td>
                    <td style="width: auto; text-align: left; border-left: 0px; border-right: 1px solid lightgray;">
                        <div id="divbipladdress" runat="server">
                        </div>
                    </td>
                    <td style="font-size: 11px; width: 200px; padding-left: 5px; font-size: 11px;">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="color: gray">
                                    <span>Credit Number:</span>
                                    <asp:Label ID="lblDebitNo" Style="font-size: 11px; font-weight: bold;" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </thead>
        </table>
        <table class="gridtable" style="max-width: 938px; width: 938px; border: 1px solid #999999;
            border-bottom: 0px solid #999999; border-top-color: #999999;" cellspacing="0"
            cellpadding="0">
            <thead>
                <tr>
                    <td style="width: 200px; font-size: 12px; padding: 5px; border-bottom-color: #999999;
                        border-top-color: #999999">
                        <span style="padding-bottom: 10px; color: gray">M/S:</span>
                        <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label>
                    </td>
                    <td style="width: 110px; font-size: 11px; border-right: 1px solid #dbd8d8; border-bottom-color: #999999;
                        border-top-color: #dbd8d8">
                        <span class="txtGyay">Date:</span>
                        <%--<asp:TextBox ID="txtDate" runat="server" Enabled="false" style="border:none;"
                                    CssClass="th style-eta date_style txtwdth" Text=""></asp:TextBox>--%>
                        <asp:Label ID="txtDate" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width: 270px; border-bottom-color: #999999; font-size: 11px; padding-left: 5px;
                        border-top-color: #dbd8d8">
                        <%-- <span class="txtGyay">Against Bill No.</span>--%>
                        <asp:DropDownList ID="ddltypes" AutoPostBack="true" runat="server" CssClass="HideArrowAndBorder">
                            <asp:ListItem Selected="True" Value="0">
                               Against Debit Note No.-
                            </asp:ListItem>
                            <asp:ListItem disabled Value="1">
                               Against Bill No.-
                            </asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlBillNo" runat="server" CssClass="HideArrowAndBorder" Width="200px">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnBillAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 5px 5px; font-size: 11px; border-bottom-color: #999999">
                        We have Debited your account as per details given below:-
                    </td>
                </tr>
            </thead>
        </table>
        <div>
            <asp:GridView ID="grdAccessoryDebitNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                OnRowDataBound="grdAccessoryDebitNot_RowDataBound" Style="width: 938px; max-width: 938px;">
                <RowStyle CssClass="gvRow" />
                <FooterStyle CssClass="footerClass" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdnDebitnote" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="50" CssClass="border_left" />
                        <HeaderStyle Width="44" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Particulars">
                        <ItemTemplate>
                            <asp:Label ID="lblDebitParticur" Style="text-transform: capitalize;" runat="server"
                                Text='<%# Eval("ParticularName") %>'></asp:Label>
                            <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="550" />
                        <FooterStyle Width="550" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblDebitQty" Style="text-transform: capitalize;" runat="server" Text='<%# Eval("DebitQuantity") %>'></asp:Label>
                            <asp:Label ID="lblunits" Style="text-transform: capitalize;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                            <span class="indianCurr"></span>
                            <asp:Label ID="lblDebitRate" runat="server" Text='<%# Eval("DebitRate") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <span class="indianCurr"></span>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                            <asp:HiddenField ID="hdnAmount" Value='<%# Eval("Amount") %>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="100" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="margin-bottom: -8px">
            <table cellpadding="0" class="emptytable" cellspacing="0" style="max-width: 938px;
                width: 938px; border-top: 0px solid !important; border-right-color: #999999;
                border-left: 1px solid #9999; margin-bottom: 10px;">
                <tr id="tdIIGST" visible="false" runat="server" class="clsIGST">
                    <td style="width: 600px; border-right: 1px solid #999999;" colspan="2">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; width: 77px; border-bottom: 1px solid #999999;
                        text-align: center; color: gray" class="PrientClass4">
                        IGST
                    </td>
                    <td style="border-right: 1px solid #999999; width: 89px; border-bottom: 1px solid #999999;
                        text-align: center;" class="PrientClass3">
                        <%--<asp:TextBox runat="server" ID="txtIGST" Enabled="false" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 1);"></asp:TextBox>--%>
                        <asp:Label runat="server" ID="txtIGST" CssClass="txtCenter" Text=""></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999; width: 111px; border-bottom: 1px solid #999999;
                        text-align: center" class="PrientClass2">
                        <asp:Label ID="lblIgstACurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr class="clsCGST_SGST" visible="false" id="tdCGST" runat="server">
                    <td style="border-right: 1px solid #999999; width: 460px;" colspan="2">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 95px;
                        color: gray; text-align: center;">
                        CGST
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 89px;
                        text-align: center;">
                        <%--<asp:TextBox runat="server" ID="txtCGST" Enabled="false" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 2);"></asp:TextBox>--%>
                        <asp:Label runat="server" ID="txtCGST" CssClass="txtCenter" Text=""></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 111px;
                        text-align: center">
                        <asp:Label ID="lblCGSTACurrentcy" runat="server"></asp:Label>
                        <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr class="clsCGST_SGST" visible="false" id="tdSGST" runat="server">
                    <td style="border-right: 1px solid #999999; width: 600px;" colspan="2">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 77px;
                        color: gray; text-align: center;">
                        SGST
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 89px;
                        text-align: center;">
                        <%--<asp:TextBox runat="server" Enabled="false" ID="txtSGST" MaxLength="5" Width="40px"
                                    CssClass="txtCenter number" Text="" onblur="CalculateGSTAmount(this, 3);"></asp:TextBox>--%>
                        <asp:Label runat="server" ID="txtSGST" CssClass="txtCenter" Text=""></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 111px;
                        text-align: center">
                        <asp:Label ID="lblSGSTACurrentcy" runat="server"></asp:Label>
                        <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="border-right: 1px solid #999999; width: 600px;" colspan="2">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; height: 18px; border-bottom: 1px solid #999999;
                        width: 250px; color: gray; text-align: center;" colspan="2">
                        <b>Total</b>
                    </td>
                    <%-- <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999; color: gray">
                            </td>--%>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 100px;
                        text-align: center">
                        <asp:Label ID="lblGranToCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblGrandTotalAmount" class="gtotal" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                    </td>
                    <%--<td style="border-right: 1px solid #999; border-bottom: 1px solid #999;">
                                &nbsp;
                            </td>--%>
                </tr>
            </table>
        </div>
        <div class="bottomtable">
            <table style="max-width: 938px; width: 938px; border: 1px solid #999999; border-collapse: collapse;">
                <tbody>
                    <tr>
                        <td style="width: 100%; border-bottom: 1px solid #999999; font-size: 11px">
                            <span style="color: #000; font-weight: 600;" class="txtGray">Rupees</span>
                            <asp:Label ID="lblrs" Font-Bold="true" runat="server" Style=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="max-width: 938px; width: 938px; border: none" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td style="text-align: left; padding-right: 8px; padding-top: 15px; color: #000;
                            font-size: 12px;">
                        </td>
                        <td style="text-align: right; padding-right: 10px">
                            <br />
                            <br />
                            <span style="font-weight: 600">Boutique International Pvt. Ltd.</span>
                            <div runat="server" style="float: inherit; margin-right: 57px;" id="divSignature2"
                                visible="false">
                                <span>
                                    <asp:Image ID="imgCheckerSig" runat="server" Height="40px" Width="110px" />
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblCheckerName" runat="server" Style="line-height: 20px; padding-left: 10px;"></asp:Label>
                                </span>
                                <br />
                                <span>
                                    <asp:Label ID="lblCheckedDate" runat="server" Style='padding-left: 10px;'></asp:Label>
                                </span>
                            </div>
                            <div runat="server" id="divCheckBox2">
                                <asp:CheckBox runat="server" Checked="false" ID="chkQtyCheckedBy" Style="position: relative;
                                    top: 4px; left: 5px" />
                                <span style="position: relative; left: 5px; margin-right: 92px;">(Signature)</span>
                            </div>
                        </td>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
