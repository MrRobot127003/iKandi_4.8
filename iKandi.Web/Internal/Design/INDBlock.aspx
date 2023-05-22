<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="INDBlock.aspx.cs" Inherits="iKandi.Web.INDBlock" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/INDBlockForm.ascx" TagName="INDBlockForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.core.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/jquery-ui-1.7.2.custom.min.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.mask.js")%>'></script>

    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>

    
        <uc1:INDBlockForm ID="INDBlockForm1" runat="server" />
    
</asp:Content>