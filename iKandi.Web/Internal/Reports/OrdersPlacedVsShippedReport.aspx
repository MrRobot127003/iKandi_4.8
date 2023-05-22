<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersPlacedVsShippedReport.aspx.cs"
 Inherits="iKandi.Web.OrdersPlacedVsShippedReport" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="../../UserControls/Reports/OrdersPlacedVsShipped.ascx" tagname="OrdersPlacedVsShipped" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">


    <uc1:OrdersPlacedVsShipped ID="OrdersPlacedVsShipped1" runat="server" />


</asp:Content>