<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/layout/Secure.Master"
    CodeBehind="UserEdit.aspx.cs"  EnableEventValidation="false"  Inherits="iKandi.Web.UserEdit" %>
<%@ Register Src="~/UserControls/Forms/UserForm.ascx" TagName="UserForm"
    TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">
    <%--<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/jquery-ui-1.7.2.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>--%>
    <uc1:UserForm ID="UserForm1" runat="server" />
    
</asp:Content>
