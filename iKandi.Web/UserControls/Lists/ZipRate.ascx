<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZipRate.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.ZipRate" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="print-box">
<h2  class="header-text-back">

Zip Rate</h2>
<asp:GridView ID="grdZipRate" runat="server" AutoGenerateColumns="False" DataSourceID="odsZipRate"
    CssClass="da_header_heading item_list" AllowPaging="True" OnRowDeleting="grdZipRate_OnRowDeleting" PageSize="20" Width="100%">
    <Columns>
        <asp:BoundField DataField="Detail" HeaderText="Detail" SortExpression="Detail" ItemStyle-CssClass="da_table_tr_bg" />
        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" ItemStyle-CssClass="da_table_tr_bg" />
        <asp:BoundField DataField="Size" HeaderText="Size (Inch)" SortExpression="Size" ItemStyle-CssClass="da_table_tr_bg" />
        <asp:BoundField DataField="Rate" HeaderText="Rate (INR)" SortExpression="Rate" ItemStyle-CssClass="da_table_tr_bg" />
          <asp:TemplateField>
	            <ItemTemplate>
	            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
		        <asp:HyperLink ID="editZipRate" runat="server" NavigateUrl='<%# Eval("Id", "~/Admin/ZipRate/ZipRateEdit.aspx?Id={0}") %>'
               Text="Edit" CssClass="da_edit_delete_link">
          </asp:HyperLink>
	    </ItemTemplate>
    </asp:TemplateField>     
       
             <asp:TemplateField>
	            <ItemTemplate>
		        <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" CssClass="da_edit_delete_link" Text="Delete"
			    OnClientClick="return confirm('Are you sure you want to delete ?');" />
	    </ItemTemplate>
    </asp:TemplateField> 
    </Columns>
</asp:GridView> 
<asp:HiddenField ID="hiddenId" runat="server" /><br />
</div>
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="da_submit_button" PostBackUrl="~/Admin/ZipRate/ZipRateEdit.aspx"></asp:Button>
     <input type="button" id="btnPrint" value="Print" class="da_submit_button"  onclick="return PrintPDF();" />
<asp:ObjectDataSource ID="odsZipRate" runat="server" SelectMethod="GetZipRate" TypeName="iKandi.BLL.AdminController"
    DeleteMethod="DeleteZipRate">
    <DeleteParameters>
        <asp:ControlParameter Name="ZipRateId" Type="Int32" ControlID="hiddenId" PropertyName="Value" />
    </DeleteParameters>
</asp:ObjectDataSource>
