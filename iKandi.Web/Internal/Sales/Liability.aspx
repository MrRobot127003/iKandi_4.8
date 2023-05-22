<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liability.aspx.cs" Inherits="iKandi.Web.Liability"  MasterPageFile="~/layout/Secure.Master"%>

<%@ Register Src="../../UserControls/Forms/LiabilityForm.ascx" TagName="LiabilityForm"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="cph_main_content" runat="server">
     <uc1:LiabilityForm ID="LiabilityForm1" runat="server" />
</asp:content>
