<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="Targetdate.aspx.cs" Inherits="iKandi.Web.Admin.WebForm1" %>
 <%@ Register Src="~/UserControls/Lists/Targetdateadmin.ascx" TagName="Targetdateadmin" TagPrefix="uc1" %>
  <%@ Register Src="~/UserControls/Lists/TargetAdminQA.ascx" TagName="TargetAdminQA"  TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <div>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <uc1:Targetdateadmin ID="mb" runat="server" />
</div><br />
<br />

<div>
    <uc2:TargetAdminQA ID="mf" runat="server" />
    
</div>
</asp:Content>
