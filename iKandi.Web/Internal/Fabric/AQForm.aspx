<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="AQForm.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.AQForm"  EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Forms/AQ.ascx" tagname="AQForm" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<uc1:AQForm ID="AQ123" runat="server" />
</asp:Content>
