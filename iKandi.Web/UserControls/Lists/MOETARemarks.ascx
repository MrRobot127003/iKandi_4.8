<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOETARemarks.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.MOETARemarks" %>

<div>
<table width="100%" cellpadding="0" cellspacing="0" border="1" style="padding:5px; border:1px solid #999999;">
<tr>
<td align="center" style="font-family:Lucida Sans Unicode; font-size:15px;color: #fff; border:none;background:#39589c">Remarks</td>
</tr>
<tr>
<td>
<div style="overflow:auto; max-height:450px; width:760px; border-top:0px solid #000000; padding:5px; font-family:Lucida Sans Unicode; font-size:11px;" >
<asp:Literal ID="litRemarks" runat="server"></asp:Literal>
</div>
</td>
</tr>
<tr>
<td style="border:none; padding-top:10px;">
<input type="button" onclick="window.close();" value="Close" class="close do-not-disable da_submit_button" />
</td>
</tr>
</table>
</div>
