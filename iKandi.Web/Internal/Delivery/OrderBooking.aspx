<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="OrderBooking.aspx.cs" Inherits="iKandi.Web.OrderBooking" %>

<%@ Register src="../../UserControls/Lists/Delivery.ascx" tagname="Delivery" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    

    <uc1:Delivery ID="Delivery1" runat="server" />

    

</asp:Content>