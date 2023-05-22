<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="OBPermissionForm.aspx.cs" Inherits="iKandi.Web.Admin.Permission.OBPermissionForm" %>
<%@ Register src="../../UserControls/Forms/OBPermission.ascx" tagname="OBPermission" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
   
   

    <uc1:OBPermission ID="OBPermission1" runat="server" />
   
   

</asp:Content>
