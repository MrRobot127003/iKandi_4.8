<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricDebitNoteList.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricDebitNoteList" %>

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
        height: 560px !important;
    }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 4px;
    }
    #sb-wrapper
    {
        top: 20% !important;
        left: 50% !important;
        width: 900px !important;
        transform: translate(-50%, -10%);
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
    .underlinecs:hover
    {
        text-decoration: underline;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function ShowDebitNotePopup(DebitNoteId) {
            SupplierPoId = '<%=this.SupplierPoId %>';
            var Srv_id = '<%=this.Srv_id %>';
            sURL = '../../Internal/Fabric/FabricDebitNote.aspx?SupplierPoId=' + SupplierPoId + '&DebitNoteId=' + DebitNoteId + '&srv_id=' + Srv_id;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 950, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function SBClose() { }

        function ShowSupplierChallanScreen(DebitNote_Id, SupplierPoID, challanid, Type, DebitId) {            
            var h = 550;
            var w = 850;
            var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoID=" + SupplierPoID + "&ChallanType=" + "DEBITCHALLAN" + "&ChallanID=" + challanid + "&FabType=" + Type + "&IsNewChallan=" + '' + "&DebitNote_Id=" + DebitId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: h, width: w, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;


        }
        function CallThisPage() {

            this.window.location.reload();
        }

        function ShowAlert() {
            alert("Plese Check Party Bill No. as Associated Party Bill No. are Less Than 3 months Old.");
            return false;
        }
    </script>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnemaildebitid" runat="server" />
    <asp:HiddenField ID="hdnemailpoid" runat="server" />
    <asp:HiddenField ID="hdnhtml" runat="server" />
    <asp:HiddenField ID="hdnBillNumber" runat="server" Value="0" />
    <asp:HiddenField ID="hdnPO_Number" runat="server" Value="0" />
    <div style="width: 900px; margin: 0px auto;">
        <h2 style="width: 99.8%; border: 1px solid gray; background-color: #39589c; color: #fff;
            padding: 0px 0px; text-align: center;">
            Fabric Debit Note List
        </h2>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="AddClass_Table">
            <tr>
                <td rowspan="2" style="vertical-align: top; width: 125px; border-right: 0px; border-top-color: #999;">
                    <div style="padding: 9px 7px">
                        <img id="ctl00_boutiquelogo" src="../../images/boutique-logo.png" />
                    </div>
                </td>
                <td style="width: auto; text-align: left; padding: 5px 0; border-left: 0px" rowspan="2"
                    class="barder_top_color">
                    <%-- <span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA-201305 (U.P)</span><br />
                    <span class="address_head">Tel. +911206797979, Fax:- 6797999, E-mail-boutique@boutique.in</span>--%>
                    <div id="divbipladdress" runat="server">
                    </div>
                </td>
                <td style="width: 60px;" class="barder_top_color txtColorGray">
                    PO Number
                </td>
                <td style="width: 115px;" class="barder_top_color">
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
                    <%--  <asp:TextBox ID="txtsearchkeyswords" BorderWidth="0" class="search_1" placeholder="Debit No./Bill No./Challan No."
                        runat="server" Style="width: 180px !important; text-transform: capitalize !important; margin: 0px 0px 1px;
                        padding-left: 4px; text-align: left;"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnGoProcess" runat="server" CssClass="btnGo" Text="Go" />
                    &nbsp;&nbsp;--%>
                    <asp:Button ID="btnCreate" runat="server" CssClass="btnbutton_Com do-not-disable"
                        Visible="false" OnClientClick="javascript:return ShowDebitNotePopup(-1);" Text="Create New Debit Note"
                        Style="padding: 2px 7px;" />
                    <asp:Button ID="btnCreate_ForAlert" runat="server" CssClass="btnbutton_Com do-not-disable"
                        Visible="false" OnClientClick="javascript:return ShowAlert();" Text="Create New Debit Note"
                        Style="padding: 2px 7px;" />
                </th>
            </tr>
        </table>
        <asp:GridView runat="server" ID="grdDebitNote" Width="100%" CellPadding="0" CellSpacing="0"
            AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" OnRowDataBound="grdDebitNote_RowDataBound"
            CssClass="AddClass_Table" Style="margin-top: 3px">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="border_left_color" />
                    <HeaderStyle Width="40px" CssClass="border_top_0" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit No.">
                    <ItemTemplate>
                        <asp:Label ID="lblDebitNo" Style="cursor: pointer; color: Blue;" CssClass="underlinecs"
                            onclick='<%# "ShowDebitNotePopup(" +Eval("DebitNote_Id") + " );" %>' Text='<%# Eval("DebitNoteNumber") %>'
                            runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("MasterPO_Id") %>' />
                        <asp:HiddenField ID="hdnDebitId" Value='<%# Eval("DebitNote_Id") %>' runat="server" />
                        <asp:HiddenField ID="hdnfab" Value='<%# Eval("Fabtype") %>' runat="server" />
                        <asp:HiddenField ID="hdnchallno" Value='<%# Eval("ReturnChallanNumber") %>' runat="server" />
                        <asp:HiddenField ID="hdnchallanid" Value='<%# Eval("Challan_Id") %>' runat="server" />
                        <asp:HiddenField ID="hdnsupplierid" Value='<%# Eval("SupplierID") %>' runat="server" />
                        <asp:HiddenField ID="hdndebitnotenumber" Value='<%# Eval("DebitnoteNumber") %>' runat="server" />
                        <asp:HiddenField ID="hdnponumber" Value='<%# Eval("PO_Number") %>' runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="140px" CssClass="border_top_0" />
                    <ItemStyle CssClass="textCenter" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Bill No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("PartyBillNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                    <HeaderStyle CssClass="border_top_0" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="120px">
                    <HeaderTemplate>
                        Bill Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillDate" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                    <HeaderStyle CssClass="border_top_0" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Amount
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="textCenter" />
                    <HeaderStyle CssClass="border_top_0" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px">
                    <HeaderTemplate>
                        Challan No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblChallanNo" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="border_top_0" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
