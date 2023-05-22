<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZipRateListing.aspx.cs" Inherits="iKandi.Web.Admin.ZipRate.ZipRateListing" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Lists/ZipRate.ascx" TagName="ZipRate" TagPrefix="uc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
      <uc1:ZipRate ID="ZipRate" runat="server" />
 </asp:Content>