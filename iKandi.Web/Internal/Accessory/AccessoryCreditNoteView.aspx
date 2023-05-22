<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryCreditNoteView.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryCreditNoteView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src="../../js/service.min.js"></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript" src="../../js/form.js"></script>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    span
    {
        font-size: 11px !important;
       /* font-family: Verdana;*/
    }
    #sb-body
    {
        background: #fff;
    }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 3px;
    }
    .txtColorGray
    {
        color: Gray !important;
    }
    .AddClass_Table td 
    {
        height:16px;
     }
      a
    {
        text-decoration:none;
    }
    .underlinecs:hover
    {
      text-decoration: underline;
    }
    .btnGo
   {
       font-size:11px;
    }
    th
    {
        color: #6b6464;
     }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <script type="text/javascript">
     function ShowCreditNotePopup(CreditNoteId) {
         //debugger;                     
         SupplierPoId = '<%=this.SupplierPoId %>';
         sURL = '../../Internal/Accessory/AccessoryCreditNote.aspx?SupplierPoId=' + SupplierPoId + '&CreditNoteId=' + CreditNoteId;
         Shadowbox.init({ animate: true, animateFade: true, modal: true });
         Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
         return false;
     }

     function SBClose() { }

     function ShowSupplierChallanScreen(CreditNoteId, SupplierPoID, ChallanId) {
         var h = 570;
         var w = 910;
         var sURL = '../../Internal/Accessory/AccessoryInternalChallan.aspx?SupplierPoId=' + SupplierPoID + "&CreditNoteId=" + CreditNoteId + "&ChallanType=" + "CreditCHALLAN" + "&ChallanId=" + ChallanId;
         Shadowbox.init({ animate: true, animateFade: true, modal: true });
         Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: h, width: w, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
         return false;


     }

     function PageReload() {
         //alert('reload');
         location.reload(true);
     }
    </script>

    <form id="form1" runat="server">
        <div style="width: 900px; margin: 0px auto;">
        <h2 style="width: 99.8%; border: 1px solid gray;">
            Accessory Credit Note List
        </h2>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="AddClass_Table"
            style="margin-bottom: 3px;">
            <tr>
                <td style="vertical-align:top;width:125px;border-right: 0px;" rowspan="2" class="barder_top_color">
                    <div style=" padding: 9px 7px;">
                        <img src="../../images/boutique-logo.png" />
                    </div>
                </td>
                <%--<td style="width: 350px;border-left:0px; text-align: center;" rowspan="2" class="barder_top_color">--%>
                <td rowspan="2" style="margin-left:3px;border-top-color: #999;width:400px; border-left:0px" >
                    <%--<span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA-201305 (U.P)</span><br />
                    <span class="address_head">Tel. +911206797979, Fax:- 6797999, E-mail-boutique@boutique.in</span>--%>
                    <div id="divbipladdress" runat="server">
                        </div>
                </td>
                <td style="width: 65px;" class="barder_top_color txtColorGray">
                    PO Number
                </td>
                <td style="width: 90px;" class="barder_top_color">
                    <asp:Label ID="lblPoNumber" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="txtColorGray">
                    Supplier
                </td>
                <td>
                    <asp:Label ID="lblSupplier" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th style="text-align: left;" colspan="4">
                    <asp:TextBox ID="txtsearchkeyswords" class="search_1" placeholder="Search Credit No./Bill No./Challan No."
                        runat="server" Style="width: 200px !important;text-transform: capitalize; margin: 0px 0px 1px; padding-left: 4px;
                        text-align: left;"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnGoProcess" runat="server" CssClass="btnGo" Text="Go" OnClick="btnGoProcess_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCreate" Visible="false" runat="server" CssClass="btnbutton_Com do-not-disable"
                        OnClientClick="javascript:return ShowCreditNotePopup(0);" Text="Create New Credit Note"
                        Style="padding: 2px 7px;" />
                </th>
            </tr>
        </table>
        <asp:GridView runat="server" ID="grdCreditNote" Width="100%" CellPadding="0" CellSpacing="0"
            AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" CssClass="AddClass_Table">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="border_left_color textCenter" Width="40px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit No.">
                    <ItemTemplate>
                        <asp:Label ID="lblCreditNo" CssClass="underlinecs" Style="cursor: pointer;color: Blue;"
                            onclick='<%# "ShowCreditNotePopup(" +Eval("CreditNoteId") + " );" %>' Text='<%# Eval("CreditNoteNumber") %>'
                            runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnCreditId" Value='<%# Eval("CreditNoteId") %>' runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Credit Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCreditNoteDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("CreditNoteDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("CreditNoteDate"))).ToString("dd MMM")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Against Bill No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillNumber" runat="server" Text='<%# Eval("PartyBillNumber") == "" ? "N/A" : Eval("PartyBillNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Against Debit No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDebitNo" runat="server" Text='<%# Eval("DebitNoteNumber") == "" ? "N/A" : Eval("DebitNoteNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Debit Date/ Bill Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PartyBillDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PartyBillDate"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                        <asp:Label ID="lblDebitDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("DebitNoteDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DebitNoteDate"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Amount
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
