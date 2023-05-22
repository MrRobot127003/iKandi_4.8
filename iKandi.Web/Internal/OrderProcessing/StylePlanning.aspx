<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StylePlanning.aspx.cs" Inherits="iKandi.Web.StylePlanning" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/StyleNumberPlanning.ascx" TagName="StyleNumberPlanning"
    TagPrefix="uc1" %>
<asp:Content ID="content1" ContentPlaceHolderID="cph_main_content" runat="server">
<uc1:StyleNumberPlanning ID="StyleNumberPlanning1" runat="server" />
</asp:Content>


