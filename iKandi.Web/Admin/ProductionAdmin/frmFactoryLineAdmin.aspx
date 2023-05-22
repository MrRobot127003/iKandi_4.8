<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FrmFactoryLineAdmin.aspx.cs" Inherits="iKandi.Web.Admin.Production_Admin.FrmFactoryLineAdmin" %>
<%@ Register src="../../UserControls/Forms/FrmFactoryLineAdmin.ascx" tagname="FrmFactoryLineAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:FrmFactoryLineAdmin ID="FrmFactoryLineAdmin1" runat="server" />
</asp:Content>

