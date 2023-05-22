<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="QualityControl.aspx.cs" Inherits="iKandi.Web.QualityControl"  MasterPageFile="~/layout/Secure.Master"%>

<%@ Register Src="../../UserControls/Forms/QualityControlForm.ascx" TagName="QualityControlForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:QualityControlForm ID="QualityControlForm1" runat="server" />
</asp:Content>

