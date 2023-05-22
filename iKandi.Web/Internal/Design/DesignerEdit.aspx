<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="DesignerEdit.aspx.cs" EnableEventValidation="false" Inherits="iKandi.Web.DesignerEdit" %>

<%@ Register Src="~/UserControls/Forms/DesignerForm.ascx" TagName="DesignerForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.core.js")%>'></script>
   <%-- <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/jquery-ui-1.7.2.custom.min.js")%>'></script>--%>
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>

  <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
 
  <script type="text/javascript">

      $(function () {

          $(".th").datepicker({ dateFormat: 'dd M y (D)', minDate: 0 });

      });
  
    </script>
    
    <uc1:DesignerForm ID="DesignerForm1" runat="server" />
    
</asp:Content>
