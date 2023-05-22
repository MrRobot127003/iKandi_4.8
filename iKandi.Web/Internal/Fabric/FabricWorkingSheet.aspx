<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricWorkingSheet.aspx.cs"
    Inherits="iKandi.Web.FabricSheet" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="../../UserControls/Forms/FabricWorkingForm.ascx" TagName="FabricForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:FabricForm ID="FabricForm1" runat="server" />
</asp:Content>
