<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="SizeCmtAdmin.aspx.cs" Inherits="iKandi.Web.Admin.CMTAdmin.SizeCmtAdmin" %>
<%@ Register src="../../UserControls/Forms/SizeSetAdmin.ascx" tagname="SizeSetAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:SizeSetAdmin ID="SizeSetAdmin1" runat="server" />
</asp:Content>
