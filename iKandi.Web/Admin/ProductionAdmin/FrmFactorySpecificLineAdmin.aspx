<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FrmFactorySpecificLineAdmin.aspx.cs" Inherits="iKandi.Web.Admin.Production_Admin.FrmFactorySpecificLineAdmin" %>
<%@ Register src="../../UserControls/Forms/FactorySpecificLineAdmin.ascx" tagname="FactorySpecificLineAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
 <uc1:FactorySpecificLineAdmin ID="FactorySpecificLineAdmin1" runat="server" />
</asp:Content>
