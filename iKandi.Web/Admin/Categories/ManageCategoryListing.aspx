<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" CodeBehind="ManageCategoryListing.aspx.cs" Inherits="iKandi.Web.Admin.Categories.ManageCategoryListing" %>

<%@ Register src="../../UserControls/Lists/ManageCategories.ascx" tagname="ManageCategories" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:ManageCategories ID="ManageCategories1" runat="server" />

</asp:Content>