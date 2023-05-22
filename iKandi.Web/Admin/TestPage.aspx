<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="iKandi.Web.Admin.TestPage" %>
<%@ Register Src="~/UserControls/Forms/FactorySpecificLineAdminControl.ascx" TagName="FactorySpecificLineAdminControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<uc1:FactorySpecificLineAdminControl ID="FactorySpecificLineAdminControl1" runat="server" />
</asp:Content>
