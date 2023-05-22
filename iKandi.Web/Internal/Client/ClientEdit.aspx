﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientEdit.aspx.cs" EnableEventValidation="false" Inherits="iKandi.Web.ClientEdit" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/ClientForm.ascx" TagName="ClientForm"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

<%--
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.core.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/jquery-ui-1.7.2.custom.min.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.mask.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>--%>

   
        <uc1:ClientForm ID="ClientForm1" runat="server" />
   
</asp:Content>
