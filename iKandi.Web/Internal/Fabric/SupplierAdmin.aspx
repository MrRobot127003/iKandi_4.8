<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="SupplierAdmin.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.SupplierAdmin" %>

<%@ Register Src="../../UserControls/Forms/SupplierAdmin.ascx" TagName="SupplierAdmin"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:SupplierAdmin ID="SupplierAdmin1" runat="server" />
</asp:Content>
