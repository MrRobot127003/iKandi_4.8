<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricPricesReport.aspx.cs" Inherits="iKandi.Web.FabricPricesReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/FabricPrices.ascx" tagname="FabricPrices" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:FabricPrices ID="FabricPrices1" runat="server" />
    

</asp:Content>