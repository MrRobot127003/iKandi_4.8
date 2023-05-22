<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingOrdersReport.aspx.cs" Inherits="iKandi.Web.PendingOrdersReport" MasterPageFile="~/layout/Secure.Master" %>




<%@ Register src="../../UserControls/Reports/PendingOrders.ascx" tagname="PendingOrders" tagprefix="uc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">


   


    <uc1:PendingOrders ID="PendingOrders1" runat="server" />


   


</asp:Content>
