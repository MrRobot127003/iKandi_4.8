<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryDebitNoteView.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryDebitNoteView" %>

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
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 3px;
    }
    .txtColorGray
    {
        color: Gray !important;
    }
    a
    {
        text-decoration:none;
    }
    .underlinecs:hover
    {
      text-decoration: underline;
    }
      th
    {
       color:#575759;
     }
      #sb-wrapper
        {
            width:706px;
         }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boutique International Pvt. Ltd</title>
</head>
<body>
    <script type="text/javascript">
        function ShowDebitNotePopup(DebitNoteId) {
            //debugger;                     
            var SupplierPoId = '<%=this.SupplierPoId %>';            
            sURL = '../../Internal/Accessory/AccessoryDebitNote.aspx?SupplierPoId=' + SupplierPoId + '&DebitNoteId=' + DebitNoteId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 950, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function SBClose() { }

        function ShowSupplierChallanScreen(DebitNoteId, SupplierPoID, ChallanId) {
            var h = 570;
            var w = 800;
            var AccessoryMasterId = '<%=this.AccessoryMasterId %>';
            var sURL = '../../Internal/Accessory/AccessoryInternalChallan.aspx?SupplierPoId=' + SupplierPoID + "&DebitNoteId=" + DebitNoteId + "&ChallanType=" + "DEBITCHALLAN" + "&ChallanId=" + ChallanId + '&AccessoryMasterId=' + AccessoryMasterId;
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
            Accessory Debit Note List
        </h2>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="AddClass_Table"
            style="margin-bottom: 3px;">
            <tr>
               <td rowspan="2" style="vertical-align:top;width:125px;border-right: 0px;border-top-color: #999;">
                    <div style="padding:9px 7px">
                        <img src="../../images/boutique-logo.png"/>
                    </div>
                </td>              
                <td rowspan="2" style="border-left: 0px;border-top-color: #999;">                  
                    <div id="divbipladdress" runat="server" style="line-height: 20px;">
                    </div>

                </td>
                <td style="width: 60px;" class="barder_top_color txtColorGray">
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
                   <%-- <asp:TextBox ID="txtsearchkeyswords" class="search_1" placeholder="Search Debit No./Bill No./Challan No."
                        runat="server" Style="width: 180px !important; text-transform: capitalize; margin: 0px 0px 1px;
                        padding-left: 4px; text-align: left;"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnGoProcess" runat="server" CssClass="btnGo" Text="Go" OnClick="btnGoProcess_Click" />--%>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCreate" Visible="false" runat="server" CssClass="btnbutton_Com do-not-disable"
                        OnClientClick="javascript:return ShowDebitNotePopup(0);" Text="Create New Debit Note"
                        Style="padding: 2px 7px;" />
                </th>
            </tr>
        </table>
        <asp:GridView runat="server" ID="grdDebitNote" Width="100%" CellPadding="0" CellSpacing="0"
            AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" CssClass="AddClass_Table"
            OnRowDataBound="grdDebitNote_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="border_left_color textCenter" Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit No.">
                    <ItemTemplate>
                        <asp:Label ID="lblDebitNo" CssClass="underlinecs" Style="cursor: pointer; color: Blue;"
                            onclick='<%# "ShowDebitNotePopup(" +Eval("DebitNoteId") + " );" %>' Text='<%# Eval("DebitNoteNumber") %>'
                            runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnDebitId" Value='<%# Eval("DebitNoteId") %>' runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Bill No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("PartyBillNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Bill Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PartyBillDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PartyBillDate"))).ToString("dd MMM")%>'></asp:Label>
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
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Challan No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblChallanNo" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
