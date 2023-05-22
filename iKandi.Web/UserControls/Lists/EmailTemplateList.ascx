<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateList.ascx.cs" Inherits="iKandi.Web.EmailTemplateList" %>
<div class="print-box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">Email Template File</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
<asp:GridView runat="server" ID="grdEmailTemplate" AutoGenerateColumns="false" CssClass="da_header_heading" Width="100%" DataSourceID="odsEmailTemplate" >
<Columns>
<asp:BoundField DataField="Id" HeaderText="Id" Visible="false" ItemStyle-CssClass="da_table_tr_bg" />
<asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-CssClass="da_table_tr_bg" />
<asp:BoundField DataField="Subject" HeaderText="Subject" ItemStyle-CssClass="da_table_tr_bg"  />
<asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="da_table_tr_bg" />
<asp:BoundField DataField="TemplateType" HeaderText="Template Type" SortExpression="TemplateType" ItemStyle-CssClass="da_table_tr_bg" />

<asp:HyperLinkField ItemStyle-VerticalAlign="Top"
        DataNavigateUrlFields="EmailTemplateID" DataNavigateUrlFormatString="~/Admin/EmailTemplate/EmailTemplate.aspx?emailtemplateid={0}"
            Text="Edit" ItemStyle-CssClass="da_edit_delete_link" >
<ItemStyle VerticalAlign="Top"></ItemStyle>
    </asp:HyperLinkField>
</Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsEmailTemplate" runat="server" 
    SelectMethod="GetAllEmailTemplates" TypeName="iKandi.BLL.AdminController">
</asp:ObjectDataSource>
</div>  
