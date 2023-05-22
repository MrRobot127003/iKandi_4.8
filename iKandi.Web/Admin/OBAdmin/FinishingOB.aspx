<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FinishingOB.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.FinishingOB" %>
<%@ Register src="../../UserControls/Forms/FinishingOB.ascx" tagname="FinishingOB" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:FinishingOB ID="FinishingOB1" runat="server" />
</asp:Content>
