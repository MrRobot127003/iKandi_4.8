<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricCreditNoteList.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricCreditNoteList" %>

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
        font-family: arial;
    }
    #sb-body
    {
        background: #fff;
    }
      th
    {
       color:#575759;
     }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 3px;
    }
    th.border_top_0
    {
        border-top: 0px;
    }
    .border_left_color
    {
        text-align: center;
    }
    .txtColorGray
    {
        color: Gray !important;
    }
   .AddClass_Table td
    {
        height: 16px;
    }
   .btnGo
   {
       font-size:11px;
    }
    .underlinecs:hover
    {
        text-decoration:underline;
     }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function ShowDebitNotePopup(DebitNoteId) {
            debugger;
            SupplierPoId = '<%=this.SupplierPoId %>';
            sURL = '../../Internal/Fabric/FrmCreditNotes.aspx?SupplierPoId=' + SupplierPoId + '&DebitNoteId=' + DebitNoteId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function SBClose() { }


        function CallThisPage() {
       // alert("hi i called back")
            location.reload();

        } 
    </script>
    <form id="form1" runat="server">
    <div style="width: 900px; margin: 0px auto;">
        <h2 style="width: 99.8%; border: 1px solid gray; text-align: center;">
            Fabric Credit Note List
        </h2>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="AddClass_Table" style="margin-bottom:3px;">
            <tr>
                <td  rowspan="2" style="vertical-align:top;width:125px;border-right:0px; border-top-color:#999;">
                        <div style="padding:9px 7px">
                            <img id="ctl00_boutiquelogo" src="../../images/boutique-logo.png" />
                        </div>
                </td>
                <td style="width: auto; border-top-color: #999; text-align: left;border-left:0px" rowspan="2">
                  <%--  <span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA-201305 (U.P)</span><br />
                    <span class="address_head">Tel. +911206797979, Fax:- 6797999, E-mail-boutique@boutique.in</span>--%>
                    <div id="divbipladdress" runat="server" ></div>
                </td>
                <td style="width: 60px; border-top-color: #999" class="txtColorGray">
                    PO Number
                </td>
                <td style="width: 115px; border-top-color: #999">
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
                <th style="text-align: left;" colspan="5">
                    <asp:TextBox ID="txtsearchkeyswords" class="search_1" placeholder="Debit No./Bill No./Challan No"
                        runat="server" Style="width: 180px !important;text-transform: capitalize !important; margin: 0px 0px 1px; padding-left: 4px;
                        text-align: left;"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnGoProcess" runat="server" CssClass="btnGo" Text="Go" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCreate" runat="server" CssClass="btnGo do-not-disable" title="generate new credit note for particular debit amount" Visible="false"
                        OnClientClick="javascript:return ShowDebitNotePopup(0);" Text="Create New Credit Note"
                        Style="padding: 2px 7px;" />
                </th>
            </tr>
        </table>
        <asp:GridView runat="server" ID="grdDebitNote" Width="100%" CellPadding="0" CellSpacing="0"
            AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" OnRowDataBound="grdDebitNote_RowDataBound"
            CssClass="AddClass_Table">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="border_left_color textCenter" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit No.">
                    <ItemTemplate>
                        <asp:Label ID="lblDebitNo" title='view credit note' CssClass="underlinecs" Style="cursor: pointer; color:Blue;font-weight: 500;"
                            onclick='<%# "ShowDebitNotePopup(" +Eval("CreditNote_Id") + " );" %>' Text='<%# Eval("CreditNoteNumber") %>'
                            runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("MasterPO_Id") %>' />
                        <asp:HiddenField ID="hdnDebitId" Value='<%# Eval("CreditNote_Id") %>' runat="server" />
                        <asp:HiddenField ID="hdnfab" Value='<%# Eval("Fabtype") %>' runat="server" />
                        <asp:HiddenField ID="hdnchallno" Value='<%# Eval("ReturnChallanNumber") %>' runat="server" />
                        <asp:HiddenField ID="hdnchallanid" Value='<%# Eval("Challan_Id") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Against Bill No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillNo" style="font-weight: bold;" runat="server" Text='<%# Eval("PartyBillNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Against Debit No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldebitnos" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Debit Date/ Bill Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillDate" runat="server"></asp:Label>
                        <asp:Label ID="lbldebtdate" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Amount
                    </HeaderTemplate>
                    <ItemTemplate>
                    <span style="color:Green" >&#8377;  </asp:Label> </span> <asp:Label ID="lblAmount" runat="server"></asp:Label>
                        
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
