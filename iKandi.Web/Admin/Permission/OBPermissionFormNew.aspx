<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="OBPermissionFormNew.aspx.cs" Inherits="iKandi.Web.Admin.Permission.OBPermissionFormNew" %>
<%@ Register src="~/UserControls/Forms/OBPermission_New.ascx" tagname="OBPermissionNew" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:OBPermissionNew ID="OBPermission1" runat="server" />
</asp:Content>
