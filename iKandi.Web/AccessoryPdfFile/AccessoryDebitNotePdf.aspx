<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryDebitNotePdf.aspx.cs" Inherits="iKandi.Web.AccessoryPdfFile.AccessoryDebitNotePdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .HideArrowAndBorder
        {
            -webkit-appearance: none;
            border:0px;       
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
        .gridtable td
        {
            border-bottom: 1px solid #dbd8d8;
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
            font-size: 11px !important;
            color: #6b6464;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 10px !important;
            border-color: #999;
        }
        .grdviewtable td:nth-child(2)
        {
            text-align: left;
            padding-left: 5px;
            word-break: break-all;
            height:20px;
        }
        .txtColorGray
        {
            color: Gray;
        }
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
            border: 1px solid #999;
            color: #6b6464;
        }
        .emptytable td
        {
            text-align: center;
        }
        .grdviewtable
        {
            border-top: 0px;
            max-width: 694px;
            min-width: 694px;
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
            line-height: 24px;
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
            line-height: 24px;
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
            font-size: 10px !important;
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
            font-size: 10px;
        }
        input[type='text']
        {
            font-size: 10px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: arial;
            margin: 2px 0px;
        }
        .txtEditWidth
        {
            width: 88% !important;
            text-align: center;
        }
        .txtEditParticular
        {
            width: 97% !important;
            text-align: left !important;
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
            border-right: 1px solid #999;
            font-size: 10px;
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
            text-align: center;
        }
        .GSTTAbleEmp td
        {
            border: 1px solid #c3bcbc99;
        }
        .GSTTAbleEmp th
        {
            border: 1px solid #999;
        }
        .txtFooterWidth
        {
            width: 89% !important;
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
        th
        {
            color: #6b6464;
        }
        #sb-wrapper
        {
            width: 706px !important;
        }
    </style>    
   
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div class="FabricCreaditNote">
                <asp:HiddenField ID="hdnrowcount" runat="server" />
                <asp:HiddenField ID="hdnDebitnotid" runat="server" />
                <asp:HiddenField ID="hdnGST_No" runat="server" Value="0" />
                <%--new line--%>
                <table style="max-width: 694px; width: 694px; border: 1px solid #999999; border-bottom: 0px solid #999999"
                    cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" class="top_heading">
                                Accessory Debit Note
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 125px; border-right: 0px;">
                                <div style="padding: 9px 7px">
                                 <asp:Image ID="boutiqueImg" runat="server" />
                                    <%--<img id="ctl00_boutiquelogo" src="../../images/boutique-logo.png" />--%>
                                </div>
                            </td>
                            <td style="width: 370px; text-align: left; border-left: 0px;">
                                <div id="divbipladdress" runat="server">
                                </div>
                            </td>
                            <td style="width: 150px; font-size: 11px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 46%;" class="txtColorGray">
                                            Debit Number: 
                                        </td>
                                        <td style="width: 45%;">
                                            <asp:Label ID="lblDebitNo" Style="font-size: 11px; font-weight: bold;" runat="server"
                                                Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="gridtable" style="max-width: 694px; width: 694px; border: 1px solid #999999;
                    border-bottom: 0px solid #999999; border-top-color: #dbd8d8;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td style="width: 200px; font-size: 12px; padding: 5px; border-top-color: #dbd8d8">
                                <span style="padding-bottom: 10px;" class="txtColorGray">M/S:</span>
                                <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label>
                            </td>
                            <td style="width: 110px; font-size: 11px; border-right: 1px solid #dbd8d8; border-top-color: #dbd8d8">
                                <span class="txtColorGray">Date:</span>
                                <%--<asp:TextBox ID="txtDate" runat="server" onkeypress="return false;" CssClass="th style-eta date_style txtwdth"
                                    Text=""></asp:TextBox>--%>
                                    <asp:Label ID="txtDate" runat="server" CssClass="th style-eta date_style txtwdth" ></asp:Label>
                            </td>
                            <td style="width: 270px; font-size: 10px; padding-left: 5px; border-top-color: #dbd8d8">
                                <span class="txtColorGray">Against Bill No.</span>
                                <asp:DropDownList ID="ddlBillNo" runat="server" CssClass="HideArrowAndBorder" 
                                    Width="218px" style="font-size:10px;">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnBillAmount" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnSRVQty" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnGarmentUnitName" Value="" runat="server" />
                            </td>
                        </tr>
                    <%--rajeevs--%>
                     <tr>
                        <td colspan="2" style="font-size: 11px; border-bottom-color: #999; text-align: left;
                                padding-right: 10px;" >
                         <span class="txtColorGray" runat="server" id="spn_HSNCode"></span>
                             <asp:Label ID="lblHSNCode" runat="server" ></asp:Label>
                        </td>
                         <td style="border-bottom: 0!important;padding-left: 10px;">                          
                      </td>
                    </tr>
                    <%--rajeevs--%>
                        <tr>
                            <td colspan="2" style="padding: 5px 5px; font-size: 11px; border-bottom-color: #999">
                                We have debited in front of your account as per details given below :-
                            </td>
                            <td colspan="2" style="font-size: 11px; border-bottom-color: #999; text-align: right;
                                padding-right: 10px;">
                                <asp:Label ID="lblFailQty" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        
                    </thead>
                </table>
                <div>
                    <asp:GridView ID="grdAccessoryDebitNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                        OnRowDataBound="grdAccessoryDebitNot_RowDataBound" style="width:694px;border-bottom:0px">
                        <RowStyle CssClass="gvRow" />
                        <FooterStyle CssClass="footerClass" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnId" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="50" CssClass="border_left" />
                                <HeaderStyle Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Particulars">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitParticur" runat="server" Text='<%# Eval("ParticularName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnParticularId" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                                    <asp:HiddenField ID="hdnDebitNote_SRVID" runat="server" Value='<%# Eval("Acc_DebitNote_SRVID") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="372" />
                                <ItemStyle Width="372" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Debit Type
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraQty" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnIsExtrQty" Value='<%# Eval("IsExtraQty") %>' runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="64" />
                                <ItemStyle Width="64" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblQtyHeader" runat="server" Text=""></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitQty" Style="text-transform: capitalize;" runat="server" Text='<%# Eval("DebitQuantity") %>'></asp:Label>
                                    <asp:Label ID="lblunits" Style="text-transform: capitalize;" runat="server"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="64" />                                
                                <ItemStyle Width="64" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblDebitRate" runat="server" Text='<%# Eval("DebitRate") %>'></asp:Label>
                                </ItemTemplate>                                
                                <ItemStyle Width="64" />
                                <HeaderStyle Width="64" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnAmount" Value='<%# Eval("Amount") %>' runat="server" />
                                </ItemTemplate>                                
                                <ItemStyle Width="80" />
                                <HeaderStyle Width="80" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        OnClientClick="javascript:return HideShowGST()">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');HideShowGST()"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                </ItemTemplate>                                
                                <ItemStyle Width="100" CssClass="border_right" />
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" class="emptytable GSTTAbleEmp" cellspacing="0" style="max-width: 694px;
                                border-top: 0px solid !important;border-left: solid 1px #999;">
                                <tr>
                                    <th style="width: 50px;">
                                        Sr. No.
                                    </th>
                                    <th style="width: 372px;">
                                        Particulars
                                    </th>
                                    <th style="width: 64px;">
                                        Debit Type
                                    </th>
                                    <th style="width: 64px;">
                                        <asp:Label ID="lblEmptyQtyHeader" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th style="width: 64px;">
                                        Rate
                                    </th>
                                    <th style="width: 80px;">
                                        Amount
                                    </th>
                                    <%--<th style="width: 75px;">
                                        Action
                                    </th>--%>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDebitParticular_Empty" CssClass="txtEditParticular"
                                            Width="96%" Text=""></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Label ID="lblExtrQty_Empty" runat="server" Text="N/A"></asp:Label>
                                        <asp:HiddenField ID="hdnExtrQty_Empty" Value="-1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDebitQty_Empty" MaxLength="8" onkeypress="return isNumberKey(event)"
                                            Width="90%" Text="" onblur="CalculateGridAmount(this, 'Empty', 'Qty')"></asp:TextBox>
                                    </td>
                                    <td class="txtLeft" style="padding-left: 2px;">
                                        <asp:TextBox runat="server" ID="txtDebitRate_Empty" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                            Width="69%" Text="" onblur="CalculateGridAmount(this, 'Empty', 'Rate')"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Label ID="lblAmount_Empty" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnAmount_Empty" Value="0" runat="server" />
                                    </td>
                                    <%--<td>
                                        <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Empty');"
                                            CommandName="AddEmpty">
                                        <img src="../../images/add-butt.png" />
                                        </asp:LinkButton>
                                    </td>--%>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div>
                    <table cellpadding="0" class="emptytable GSTTAble GST_TAble" cellspacing="0" style="max-width: 694px; width:694px;border-collapse: collapse;
                        border-top: 0px solid !important; border-color: #d0cece; ">
                        <tr class="clsIGST" runat="server" id="clsIGST">
                            <td colspan="2" style="width: 486px; max-width:486px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999;border-right: 1px solid #999; width: 65px; max-width:65px;" class="txtColorGray">
                                IGST
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 65px; max-width:65px;" >
                                <%--<asp:TextBox runat="server" ID="txtIGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 1);" Enabled="false"></asp:TextBox>--%>
                                      <asp:Label ID="txtIGST" runat="server" width="50%" ></asp:Label>
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 81px; max-width:81px;" >
                                <asp:Label ID="lblIgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                            </td>
                            <%--<td style="width: 82px; max-width:82px; border-bottom: 1px solid #999;border:1px solid #999; border-right: 1px solid #999;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr class="clsCGST" runat="server" id="clsCGST">
                            <td colspan="2" style="width: 486px; max-width:486px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999;width: 65px; max-width:65px" class="txtColorGray">
                                CGST
                            </td>
                            <td style="border-bottom: 1px solid #999;width: 65px;max-width:65px">
                                <%--<asp:TextBox runat="server" ID="txtCGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 2);" Enabled="false"></asp:TextBox>--%>
                                    <asp:Label ID="txtCGST" runat="server" widht="50%" ></asp:Label>                                
                            </td>
                            <td style="border-bottom: 1px solid #999; border-top: 0px;width: 81px; max-width:81px">
                                <asp:Label ID="lblCgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                            </td>
                            <%--<td style="border-bottom: 1px solid #999;border:1px solid #999; border-right: 1px solid #999;width: 82px; max-width:80px;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr class="clsSGST" runat="server" id="clsSGST">
                            <td colspan="2" style="width: 486px; max-width:486px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 65px; max-width:65px;" class="txtColorGray">
                                SGST
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 65px; max-width:65px;">
                                <%--<asp:TextBox runat="server" ID="txtSGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 3);" Enabled="false"></asp:TextBox>--%>
                                    <asp:Label ID="txtSGST" runat="server" widht="50%" ></asp:Label>                                
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 81px; max-width:81px;">
                                <asp:Label ID="lblSgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                            </td>
                            <%--<td style="border-bottom: 1px solid #999; border-right: 1px solid #999; width: 80px; max-width:80px; border:1px solid #999">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <%--<td style="width: 486px; max-width:486px; border-right: 1px solid #999;border:1px solid #999;" colspan="2">
                                &nbsp;
                            </td>--%>
                            <td style="width: 486px; max-width:486px;" colspan="2">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999;font-size: 12px;font-weight: 600; width:172px; max-width:172px" colspan="2" class="txtColorGray" >
                                Total
                            </td>
                            <td style="border-bottom: 1px solid #999;">
                                <asp:Label ID="lblGranTotalCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblGrandTotalAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                            </td>
                            <%--<td style="border-bottom: 1px solid #999; border-right: 1px solid #999;border:1px solid #999; width:80px; max-width:80px">
                                &nbsp;
                            </td>--%>
                        </tr>
                    </table>
                </div>
                <div style="max-width: 694px; height: 15px;">
                </div>
                <div class="bottomtable">
                    <table style="max-width: 694px; width: 694px; border: 1px solid #999999; border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <td style="width: 137px; border-bottom: 1px solid #999999; padding-left: 5px;height: 15px;" class="txtColorGray">
                                    Returned Challan No. <span></span>
                                </td>
                                <td style="border-right: 1px solid #999999; width: 118px; border-bottom: 1px solid #999999;height: 15px;">
                                   <%-- <asp:TextBox ID="txtReturnChallan" Width="90%" Enabled="false" runat="server" Text=""></asp:TextBox>--%>
                                   <asp:Label ID="txtReturnChallan" runat="server" widht="50%" ></asp:Label>
                                </td>
                                <td style="width: 32px; border-bottom: 1px solid #999999; padding-left: 2px;height: 15px;" class="txtColorGray">
                                    Date:
                                </td>
                                <td style="border-right: 1px solid #999999; width: 120px;height: 15px; border-bottom: 1px solid #999999">
                                    <%--<asp:TextBox ID="txtreturndate" Enabled="false" Width="94%" runat="server" CssClass="th style-eta date_style"
                                        Text=""></asp:TextBox>--%>
                                        <asp:Label ID="txtreturndate" runat="server" widht="50%" ></asp:Label>
                                </td>
                                <td style="width: 42px; border-bottom: 1px solid #999999;height: 15px; padding-left: 2px;color: #000;font-weight: 600;" class="txtColorGray">
                                    Rupees
                                </td>
                                <td style="width: 360px; border-bottom: 1px solid #999999; height: 15px;font-size: 11px">
                                    <asp:Label ID="lblRupees" Font-Bold="true" ForeColor="#000" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="max-width: 694px; width: 694px; border: none" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td colspan="4" style="width: 60%">
                                    &nbsp;
                                    <asp:Label ID="lblGstMsg" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="padding-top: 15px; color: #000;
                                    font-size: 12px;float:right;">
                                    <span style="font-weight: bold;float: right;">Boutique International Pvt. Ltd.</span>
                                    <div id="divChkAuthorized" runat="server">
                                        <asp:CheckBox ID="chkAuthorised" runat="server" />
                                        (Authorized Signature)
                                    </div>
                                    <div id="divSigAuthorized" runat="server" visible="false" style="float: right;">
                                        <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                        <br />
                                        <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;float: right;"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblAuthorizedOnDate" runat="server" style="float: right;"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            
                        </thead>
                    </table>                    
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
