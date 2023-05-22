<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhereAreMyOrdersReport.aspx.cs"
 Inherits="iKandi.Web.WhereAreMyOrdersReport" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Reports/WhereAreMyOrders.ascx" tagname="WhereAreMyOrders" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    

    <uc1:WhereAreMyOrders ID="WhereAreMyOrders1" runat="server" />

    

</asp:Content>