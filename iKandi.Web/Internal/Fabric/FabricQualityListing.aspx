<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricQualityListing.aspx.cs" Inherits="iKandi.Web.FabricQualityListing" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>


<%@ Register src="../../UserControls/Lists/FabricQualityList.ascx" tagname="FabricQualityList" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">


    <uc1:FabricQualityList ID="FabricQualityList1" runat="server" />


</asp:Content>