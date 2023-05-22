<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BestSellersReport.aspx.cs" Inherits="iKandi.Web.BestSellersReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/BestSellers.ascx" tagname="BestSellers" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:BestSellers ID="BestSellers1" runat="server" />
    

</asp:Content>



