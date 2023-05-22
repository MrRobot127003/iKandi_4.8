<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmHistoryFabricRemarks.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.frmHistoryFabricRemarks" %>
<div>
<table width="100%" cellpadding="0" cellspacing="0" border="1" style="padding:5px; border:1px solid #000000;">
<tr>
<td align="center" style="font-family:Lucida Sans Unicode; font-size:20px; border:none;">Remarks</td>
</tr>
<tr>
<td>
<div style="overflow:auto; height:450px; width:500px; border-top:7px solid #000000; padding:5px; font-family:Lucida Sans Unicode; font-size:11px;" >
<asp:Literal ID="litRemarks" runat="server"></asp:Literal>
</div>
</td>
</tr>
<tr>
<td style="border:none; padding-top:10px;">
<input type="button" onclick="window.close();" class="close do-not-disable" />
</td>
</tr>
</table>
</div>