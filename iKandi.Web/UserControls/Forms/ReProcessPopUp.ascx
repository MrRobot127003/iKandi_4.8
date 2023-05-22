<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReProcessPopUp.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.ReProcessPopUp" %>
<div id="divReprocess">
        <table cellpadding="0" id="tblReProcess" class="sub_table edit-drag" cellspacing="0" width="100%">
        <tr><td colspan="4">Rejection Management</td>
        </tr>
        <tr id="trDebt"><td>Qty to be Debitede</td>
        <td>&nbsp;&nbsp;<input type="text" id="txtQtyDebt" /><asp:TextBox ID="TextBox4" runat="server" CssClass="input_in" Text="test"></asp:TextBox>
        </td>
        <td>Rate for debit</td>
        <td><br />kuldeep
        <asp:TextBox ID="txtRateDebt" runat="server" CssClass="input_in" Text="test">err</asp:TextBox></td>
        </tr>
        <tr id="trRej"><td id="td1"> &nbsp;&nbsp;&nbsp;<asp:Label ID="lblText" runat="server" Text="Qty to be Returned"></asp:Label></td>
        <td id="td2"><asp:TextBox ID="txtQtyReturn" runat="server"></asp:TextBox><asp:CheckBox ID="chkReusable" runat="server" /></td>
        <td id="td3">New PO Qty.</td><td id="td4"><asp:TextBox ID="txtQtyPO" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td colspan="2"><asp:Button ID="btnSubmitReprocess" runat="server" 
                Text="Submit" onclick="btnSubmitReprocess_Click" /></td>
        </tr>
        </table>
</div>