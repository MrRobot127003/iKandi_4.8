<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="PartnerRegistrationListing.aspx.cs" Inherits="iKandi.Web.PartnerRegistrationListing"  %>

 <%@ Register src="../../UserControls/Lists/PartnerRegistrationList.ascx" tagname="Partners" tagprefix="uc1" %>
 
 <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

<uc1:Partners ID="PartnerRegForm" runat="server" />

</asp:Content>