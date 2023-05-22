<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZipRateEdit.aspx.cs" Inherits="iKandi.Web.Admin.ZipRate.ZipRateEdit"  MasterPageFile="~/layout/Secure.Master" %>
<%@ Register Src="~/UserControls/Forms/ZipRateForm.ascx" TagName="ZipRateForm" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
 <uc1:ZipRateForm ID="ZipRate1" runat="server" />
</asp:Content>