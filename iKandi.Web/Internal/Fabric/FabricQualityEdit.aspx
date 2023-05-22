<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricQualityEdit.aspx.cs"
    Inherits="iKandi.Web.FabricQualityEdit" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register src="../../UserControls/Forms/FabricQualityForm.ascx" tagname="FabricQualityForm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">



    <uc1:FabricQualityForm ID="FabricQualityForm1" runat="server" />



</asp:Content>
