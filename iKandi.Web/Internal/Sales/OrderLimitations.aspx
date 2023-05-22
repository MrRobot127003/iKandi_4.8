<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderLimitations.aspx.cs"
    Inherits="iKandi.Web.OrderLimitations" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="../../UserControls/Forms/OrderLimitationsForm.ascx" TagName="OrderLimitationsForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:OrderLimitationsForm ID="OrderLimitationsForm1" runat="server" />
</asp:Content>
