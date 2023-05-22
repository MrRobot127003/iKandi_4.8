<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="TaskMapping.aspx.cs" Inherits="iKandi.Web.Internal.TaskMapping" %>
<%@ Register src="../UserControls/Forms/TaskMapping.ascx" tagname="TaskMapping" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:TaskMapping ID="TaskMap" runat="server" />
</asp:Content>
