<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Email.ascx.cs" Inherits="iKandi.Web.Email" %>

<div class="print-box">
<asp:GridView ID="grdEmails" runat="server" AutoGenerateColumns="False" DataSourceID="odsEmails" CssClass="item_list fixed-header">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        <asp:BoundField DataField="TemplateType" HeaderText="Template Type" SortExpression="TemplateType" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
        <asp:HyperLinkField DataNavigateUrlFields="EmailTemplateID" DataNavigateUrlFormatString="~/admin/emailtemplate/EmailEdit.aspx?emailtemplateid={0}"
            Text="Edit" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsEmails" runat="server" SelectMethod="GetAllEmailTemplates"
    TypeName="iKandi.BLL.AdminController"></asp:ObjectDataSource>
</div>

 <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />
