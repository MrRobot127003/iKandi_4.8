<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="OBEdit.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.OBEdit" MaintainScrollPositionOnPostback="true" EnableEventValidation="false"%>
<%@ Register src="../../UserControls/Forms/OBMainForm.ascx" tagname="OBMainForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
  <uc1:OBMainForm ID="OBMainForm1" runat="server" />
</asp:Content>
