<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="PartnerRegistrationForm.aspx.cs" Inherits="iKandi.Web.UserPartnerRegistrationForm" %>
<%@ Register src="../../UserControls/Forms/PartnerRegistrationForm.ascx" tagname="PartnerRegistrationForm" tagprefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

<uc1:PartnerRegistrationForm ID="PartnerRegForm" runat="server" />

</asp:Content>