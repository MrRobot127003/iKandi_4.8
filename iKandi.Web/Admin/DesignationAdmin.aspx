<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="DesignationAdmin.aspx.cs" Inherits="iKandi.Web.Admin.DesignationAdmin" %>
<%@ Register src="../UserControls/Forms/DesignationAdmin.ascx" tagname="DesignationAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:DesignationAdmin ID="DesignationAdmin1" runat="server" />
</asp:Content>
