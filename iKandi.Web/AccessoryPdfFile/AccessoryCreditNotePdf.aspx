<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryCreditNotePdf.aspx.cs"
    Inherits="iKandi.Web.AccessoryPdfFile.AccessoryCreditNotePdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accessory Credit Note Pdf</title>
    <style type="text/css">
        .HideArrowAndBorder
        {
            -webkit-appearance: none;
            border: 0px;
        }
        
        .FabricCreaditNote
        {
            max-width: 99.8%;
            margin: 0 auto;
            font-family: arial;
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
            border-right: 1px solid #999 !important;
        }
        .border_left
        {
            border-left: 1px solid #999 !important;
        }
        .headerbold
        {
            background: #e4e2e2;
            text-align: center;
            border-right: 1px solid #999999;
        }
        .txtwdth
        {
            width: 71%;
        }
        .txtbillwidth
        {
            width: 45%;
        }
        input
        {
            font-size: 10px !important;
            font-family: Arial !important;
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
            color: #6b6464;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 11px !important;
            border-color: #999999;
        }
        .txtColorGray
        {
            color: Gray;
        }
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
            border: 1px solid #999999;
        }
        .emptytable td
        {
            text-align: center;
        }
        .grdviewtable
        {
            border-top: 0px;
            max-width: 100%;
            min-width: 100%;
        }
        .grdviewtable th
        {
            border-top: 0px;
            border-color: #999;
            color: #6b6464;
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
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnClose:hover
        {
            color: red;
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
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
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
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        /* .footerClass td
        {
            border-bottom-color: #999;
        }*/
        .footerClass td:first-child
        {
            border-left-color: #999;
        }
        .footerClass td:last-child
        {
            border-right-color: #999;
        }
        a
        {
            text-decoration: none;
        }
        .bottomtable td
        {
            font-size: 11px;
        }
        input[type='text']
        {
            font-size: 11px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: arila;
            margin: 2px 0px;
            text-transform: capitalize;
        }
        .txtEditWidth
        {
            width: 88% !important;
            text-align: center;
        }
        .txtEditParticular
        {
            width: 97% !important;
            text-align: left;
            text-transform: inherit !important;
        }
        .TaskFabricTable
        {
            width: 800px !important;
            margin-top: 5px;
        }
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
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
            .GST_TAble
            {
                min-width: 100% !important;
                max-width: 100% !important;
            }
            .FabricCreaditNote
            {
                max-width: 99.8% !important;
            }
            .PrientClass
            {
                width: 501px !important;
            }
            .PrientClass1
            {
                width: 84px !important;
            }
            .PrientClass2
            {
                width: 84px !important;
            }
            .PrientClass3
            {
                width: 67px !important;
            }
        
            .PrientClass4
            {
                width: 64px !important;
            }
            .GST_TAble td input[type="text"]
            {
                width: 40px !important;
                text-align: center;
            }
            input[type='text']
            {
                margin: 2px 0px;
            }
        }
        
        .indianCurr::after
        {
            content: "₹";
            color: green;
        }
        input[type=text], textarea
        {
            border: 1px solid #cccccc;
            text-transform: capitalize;
            font-size: 11px;
        }
        
        .GSTTAble td input[type="text"]
        {
            margin: 2px 0px;
            font-size: 11px;
        }
        .GSTTAble td
        {
            border-right: 1px solid #999999;
            font-size: 11px;
            height: 20px;
        }
        .EmptyRow td[colspan="6"]
        {
            border: 0px;
        }
        .GSTTAbleEmp td input[type="text"]
        {
            margin: 2px 0px;
            font-size: 11px;
            text-transform: inherit;
        }
        .GSTTAbleEmp td
        {
            border: 1px solid #c3bcbc99;
        }
        .GSTTAbleEmp th
        {
            border: 1px solid #999999;
        }
        .txtFooterWidth
        {
            width: 75% !important;
        }
        .txtLeft
        {
            text-align: left !important;
        }
        .footerClass td:first-child
        {
            border-bottom-color: #999 !important;
        }
        .footerClass td:nth-child(2)
        {
            border-bottom-color: #999 !important;
        }
        .GST_TAble td input[type="text"]
        {
            text-align: center;
        }
        .grdviewtable td:nth-child(2)
        {
            padding-left: 2px;
            text-align: left;
            word-break: break-all;
        }
        .grdviewtable td:input[type="text"]
        {
            text-transform: inherit;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="FabricCreaditNote" style="width: 80%; margin-top: 12px; margin-left: 20px;">
        <asp:HiddenField ID="hdnrowcount" runat="server" />
        <asp:HiddenField ID="hdnCreditnotid" runat="server" />
        <asp:HiddenField ID="hdnGST_No" runat="server" Value="0" />
        <table style="max-width: 938px; width: 938px; border: 1px solid #999999;" cellspacing="0"
            cellpadding="0">
            <thead>
                <tr>
                    <td colspan="3" class="top_heading">
                        Accessory Credit Note
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 97px;">
                        <div style="padding: 9px 7px">
                            <asp:Image ID="boutiqueImg" runat="server" />
                            <%--<img src="../../images/boutique-logo.png"/>--%>
                        </div>
                    </td>
                    <td style="width: 331px; text-align: left; padding-left: 10px;">
                        <div id="divbipladdress" runat="server" style="font-size: 10px">
                        </div>
                    </td>
                    <td style="width: 198px; font-size: 11px;">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 46%;" class="txtColorGray">
                                    Credit Number: &nbsp;
                                </td>
                                <td style="width: 54%;">
                                    <asp:Label ID="lblCreditNo" Style="font-size: 11px; font-weight: bold;" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </thead>
        </table>
        <table class="gridtable" style="max-width: 938px; width: 938px; border-right: 1px solid #999999;
            border-left: 1px solid #999999;" cellspacing="0" cellpadding="0">
            <thead>
                <tr>
                    <td style="width: 200px; font-size: 12px; padding: 5px; border-bottom:1px solid #999999;">
                        <span style="padding-bottom: 10px;" class="txtColorGray">M/S:</span>
                        <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label>
                    </td>
                    <td style="width: 110px; font-size: 11px;  border-bottom:1px solid #999999;">
                        <span class="txtColorGray">Date:</span>
                        <%--<asp:TextBox ID="txtDate" runat="server" CssClass="th style-eta date_style txtwdth"
                                    Text=""></asp:TextBox>--%>
                        <asp:Label ID="txtDate" runat="server" CssClass="th style-eta date_style txtwdth"
                            Text=""></asp:Label></br>
                     <%-- rajeevS --%>
                                <span style="width:112px;display:inline-block;" class="txtColorGray" runat="server" id="spn_HSNCode"></span>
                                <asp:Label ID="lblHSNCode" Text="" runat="server" CssClass="th style-eta date_style txtwdth" style="max-width: 200px;width: 100px;padding: 3px;"></asp:Label> <br />                         
                     <%-- rajeevS --%>
                    </td>                   
                    <td style="width: 270px; font-size: 11px; padding-left: 5px; border-bottom:1px solid #999999;">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="HideArrowAndBorder">
                            <asp:ListItem Value="DEBIT" Text="Against Debit No."></asp:ListItem>
                            <asp:ListItem Value="BILL" Text="Against Bill No."></asp:ListItem>
                        </asp:DropDownList><b>-</b>
                        <asp:DropDownList ID="ddlBillNo" runat="server" Width="218px" CssClass="HideArrowAndBorder">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnBillAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 5px 5px; font-size: 11px; border-bottom-color: #999">
                        We have Credited your account as per details given below:-
                    </td>
                </tr>
            </thead>
        </table>
        <div style="width: 938px; max-width: 938px;">
            <asp:GridView ID="grdAccessoryCreditNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                OnRowDataBound="grdAccessoryCreditNot_RowDataBound" ShowFooter="false" Style="border: 1px solid #999999;
                width: 938px; max-width: 938px;">
                <RowStyle CssClass="gvRow" />
                <FooterStyle CssClass="footerClass" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdnId" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdnIdEdit" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </EditItemTemplate>
                        <ItemStyle Width="50" CssClass="border_left" />
                        <HeaderStyle Width="50" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Particulars">
                        <ItemTemplate>
                            <asp:Label ID="lblCreditParticur" runat="server" Text='<%# Eval("ParticularName") %>'></asp:Label>
                            <asp:HiddenField ID="hdnParticularId" runat="server" Value='<%# Eval("CreditNoteParticularId") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="550" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblCreditQty" runat="server" Text='<%# Eval("CreditQuantity") %>'></asp:Label>
                            <asp:Label ID="lblunits" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                            <span class="indianCurr"></span>
                            <asp:Label ID="lblCreditRate" runat="server" Text='<%# Eval("CreditRate") %>'></asp:Label>
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
        <div>
            <table cellpadding="0" class="emptytable GSTTAble GST_TAble" cellspacing="0" style="max-width: 938px;
                width: 938px; border-top: 0px solid !important; border-color: #d0cece">
                <tr class="clsIGST" runat="server" id="clsIGST">
                    <td style="width: 630px; max-width: 630; border-right: 1px solid #999999;" class="PrientClass ">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; width: 75px;
                        max-width: 75px;" class="PrientClass4 txtColorGray">
                        IGST
                    </td>
                    <td style="border-right: 1px solid #999999;  width: 85px;
                        max-width: 85px;" class="PrientClass3">
                        <%--<asp:TextBox runat="server" ID="txtIGST" MaxLength="5" 
                                    Width="50%" Text=""  Enabled="false"></asp:TextBox>--%>
                        <asp:Label ID="txtIGST" runat="server" Width="50%" style="text-align: right;margin-left: -28px;"></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999;  width: 106px;
                        max-width: 106px;" class="PrientClass2">
                        <asp:Label ID="lblIgstCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr class="clsCGST_SGST" runat="server" id="clsCGST">
                    <td style="border-right: 1px solid #999999; width: 630px; max-width: 630px;">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 75px;
                        max-width: 75px;" class="txtColorGray">
                        CGST
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 85px;
                        max-width: 85px;">
                        <%--<asp:TextBox runat="server" ID="txtCGST" MaxLength="5" 
                                    Width="50%" Text="" Enabled="false"></asp:TextBox>--%>
                        <asp:Label ID="txtCGST" runat="server" widht="50%" style="text-align: right;margin-left: -28px;"></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999; border-bottom: 1px solid #999999; width: 106px;
                        max-width: 106px;">
                        <asp:Label ID="lblCgstCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr class="clsCGST_SGST" runat="server" id="clsSGST">
                    <td style="border-right: 1px solid #999999; width: 630px; max-width: 630px;">
                        &nbsp;
                    </td>
                    <td style="border-right: 1px solid #999999; width: 75px; max-width: 75px;" class="txtColorGray">
                        SGST
                    </td>
                    <td style="border-right: 1px solid #999999; width: 85px; max-width: 85px;">
                        <%--<asp:TextBox runat="server" ID="txtSGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 3);" Enabled="false"></asp:TextBox>--%>
                        <asp:Label ID="txtSGST" runat="server" widht="50%" style="text-align: right;margin-left: -28px;"></asp:Label>
                        <span>%</span>
                    </td>
                    <td style="border-right: 1px solid #999999; width: 106px; max-width: 106px;">
                        <asp:Label ID="lblSgstCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 600px; max-width: 600px;" colspan="1">
                        &nbsp;
                    </td>
                    <td style=" border-bottom: 1px solid #999999;border-top: 1px solid #999999; font-size: 12px;
                        font-weight: 600; width: 150px; max-width: 150px" colspan="2" class="txtColorGray">
                        <b><span style="float: right; margin-right: 75px;">Total </span></b>
                    </td>
                    <td style="border-bottom: 1px solid #999999;border-top: 1px solid #999999; border-right: 1px solid #999999;
                        width: 100px;">
                        <asp:Label ID="lblGranTotalCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblGrandTotalAmount" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="bottomtable" style="margin-top: 10px;">
            <table style="max-width: 938px; width: 938px; border: 1px solid #999999; border-collapse: collapse;">
                <tbody>
                    <tr>
                        <td style="width: 100%; border-bottom: 1px solid #999999; font-size: 11px">
                            <span style="color: #000000; text-transform: capitalize; font-weight: bold; margin-left: 3px;">
                                Rupees</span>
                            <asp:Label ID="lblRupees" Font-Bold="true" Style="color: #000000; text-transform: capitalize;" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="max-width: 938px; width: 938px; border: none" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td colspan="4" style="width: 70%">
                            &nbsp;
                        </td>
                        <td style="text-align: center; padding-right: 8px; padding-top: 15px; color: #000;
                            font-size: 12px;float:right;">
                            <span style="font-weight: bold">Boutique International Pvt. Ltd.</span>
                            <div id="divChkAuthorized" runat="server">
                                <asp:CheckBox ID="chkAuthorised" runat="server" onclick="DisplaySendMail()" />
                                (Authorized Signature)
                            </div>
                            <div id="divSigAuthorized" runat="server" visible="false">
                                <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                <br />
                                <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
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
