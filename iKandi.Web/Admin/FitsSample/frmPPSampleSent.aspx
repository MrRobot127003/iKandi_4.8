<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPPSampleSent.aspx.cs" Inherits="iKandi.Web.Admin.FitsSample.frmPPSampleSent" MasterPageFile="~/layout/Secure.Master" %>
<%@ Register Src="~/UserControls/Forms/frmPPSampleSent_ContractWise.ascx" TagName="PPSampleSent"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:PPSampleSent ID="PPSampleSent" runat="server" />
</asp:Content>

