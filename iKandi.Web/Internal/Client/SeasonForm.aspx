<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="SeasonForm.aspx.cs" Inherits="iKandi.Web.Internal.Client.SeasonForm" %>
<%@ Register src="../../UserControls/Forms/SeasonForm.ascx" tagname="SeasonForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:SeasonForm ID="SeasonForm1" runat="server" />
</asp:Content>
