<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="AQL_Admin.aspx.cs" Inherits="iKandi.Web.Admin.ClientsAQL.AQL_Admin" %>
<%@ Register src="../../UserControls/Forms/AQL_Admin.ascx" tagname="AQL_Admin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:AQL_Admin ID="AQL_Admin1" runat="server" />
</asp:Content>
