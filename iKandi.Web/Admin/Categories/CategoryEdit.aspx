<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="iKandi.Web.CategoryEdit" %>
<%@ Register src="../../UserControls/Forms/CategoryForm.ascx" tagname="CategoryForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:CategoryForm ID="CategoryForm1" runat="server" />
</asp:Content>
