<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FrmSlotAdmin.aspx.cs" Inherits="iKandi.Web.Admin.Production_Admin.FrmSlotAdmin" %>
<%@ Register src="../../UserControls/Forms/frmSlotAdmin.ascx" tagname="frmSlotAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:frmSlotAdmin ID="frmSlotAdmin1" runat="server" />
</asp:Content>
