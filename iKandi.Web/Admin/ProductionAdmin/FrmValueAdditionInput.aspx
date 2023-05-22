<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="FrmValueAdditionInput.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.FrmValueAdditionInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="cph_main_content" runat="server" >
<style type="text/css">
  .item_list_new th
        {
        background-color:#39589C !important;
        background-image:none !important;
        padding:5px 0px;
         vertical-align:middle !important;
         color:#fff;
         font-weight:bold;
         text-transform:capitalize;
         font-size:11PX;
        }
        .item_list_new 
        {
            background:#fff;
            font-size:11px;
            font-family:Verdana;
        }

</style>
<table cellpadding="0" cellspacing="0" width="550px" class="item_list_new" align="center">
<tr>
<td>

<asp:GridView ID="grdValaddtion" runat="server" CssClass="font" AutoGenerateColumns="False" Width="550px" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px"  >
<Columns>

<asp:TemplateField HeaderText="From Status">
<ItemTemplate>
<asp:Label ID="lblfromst" runat="server" Text='<%#Eval("FromStatus")%>'></asp:Label>


</ItemTemplate>
<ItemStyle Width="150px" />
 


</asp:TemplateField>

<asp:TemplateField HeaderText="To Status">
<ItemTemplate>

<asp:Label ID="lbltost" runat="server" Text='<%#Eval("Tostatus")%>'></asp:Label>

</ItemTemplate>
<ItemStyle Width="150px" />
</asp:TemplateField>


<asp:TemplateField HeaderText="VA Name">
<ItemTemplate>

<asp:Label ID="ValueAddtionName" runat="server" Text='<%#Eval("ValueAddtionName")%>'></asp:Label>
<asp:HiddenField ID="hidriskid" runat="server" Value='<%#Eval("riskvalid")%>' />

</ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Sequence">
<ItemTemplate>

<asp:Label ID="seq" runat="server" Text='<%#Eval("Sequences")%>'></asp:Label>


</ItemTemplate>
<ItemStyle HorizontalAlign="Center" />



</asp:TemplateField>


<asp:TemplateField HeaderText="Capacity Qty">
<ItemTemplate>

<asp:TextBox ID="txtcapcity" Width="90%" runat="server" Text='<%#Eval("CapacityQty")%>'></asp:TextBox>


</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="100px" />




</asp:TemplateField>



</Columns>


</asp:GridView>


</td>

</tr>
<tr> <td colspan="5"> &nbsp; </td></tr>
<tr>
<td align="Right" colspan="5">

<asp:ImageButton ID="btnsumbi" ImageUrl="~/images/submit.png" onclick="btnsumbit_Click" runat="server" />
</td>

</tr>

</table>

</asp:Content>
