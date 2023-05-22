<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingImages.aspx.cs" Inherits="iKandi.Web.PendingImages" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="../../UserControls/Reports/Pendingimages.ascx" tagname="Pendingimages" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:Pendingimages ID="Pendingimages1" runat="server" />

</asp:Content>
