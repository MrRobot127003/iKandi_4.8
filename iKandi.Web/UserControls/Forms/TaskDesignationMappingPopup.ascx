<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskDesignationMappingPopup.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.TaskDesignationMappingPopup" %>
<table width="100%" border="0" cellspacing="0" align="center" cellpadding="3" class="da_table_border">
<tr class="da_table_td ">
  <td colspan="10">Add / Remove Designations For
  <asp:Label ID="lblShow" runat="server" Text='<%#Eval("this.TaskName") %>' Font-Bold="true"></asp:Label>
  </td>
</tr>

  <tr class="da_table_tr_bg " style="width:100%">
  <td style="text-align:left;width:100%">
    <asp:CheckBoxList ID="chkList" runat="server" CellPadding="3" CellSpacing="3"  Width="100%"
          RepeatColumns="4" RepeatDirection="Horizontal" AutoPostBack="true"
          onselectedindexchanged="chkList_SelectedIndexChanged" EnableViewState="true" ></asp:CheckBoxList>
  </td>
  </tr>
 <tr>
    <td colspan="8">
    <asp:Button ID="btnSubmit" Text="Save" class="da_submit_button" runat="server" 
            onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>