<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="CategoryListing.aspx.cs" Inherits="iKandi.Web.CategoryListing" %>


<%@ Register src="../../UserControls/Lists/Categories.ascx" tagname="Categories" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:Categories ID="Categories1" runat="server" />
</asp:Content>