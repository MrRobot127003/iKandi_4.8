<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="CurrencyAdmin.aspx.cs" Inherits="iKandi.Web.Admin.CurrencyAdmin" %>
<%@ Register src="../UserControls/Forms/CurrencyAdmin.ascx" tagname="CurrencyAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:CurrencyAdmin ID="CurrencyAdmin1" runat="server" />
</asp:Content>
