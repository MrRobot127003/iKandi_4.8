<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="CurrencyConversion.aspx.cs" Inherits="iKandi.Web.CurrencyConversion" %>

<%@ Register src="../UserControls/Lists/ConverstionRateList.ascx" tagname="ConverstionRateList" tagprefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="cph_main_content">
    <uc1:ConverstionRateList ID="ConverstionRateList1" runat="server" />
</asp:Content>
