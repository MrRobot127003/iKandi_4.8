<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="iKandi.Web.Users"
    MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Security/UserManagement.ascx" TagName="UserManagement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
    <uc1:UserManagement ID="UserManagement1" runat="server" />
</asp:Content>
