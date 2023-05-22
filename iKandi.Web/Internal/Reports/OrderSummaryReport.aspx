<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSummaryReport.aspx.cs" Inherits="iKandi.Web.OrderSummaryReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%--<%@ Register src="../../UserControls/Reports/CriticalPathReports.ascx" tagname="CriticalPathReport" tagprefix="cpr" %>--%>
<%@ Register src="../../UserControls/Reports/OrderSummary.ascx" tagname="OrderSummary" tagprefix="osr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    
 <osr:OrderSummary ID="OrderSummary" runat="server" />
     <%--<cpr:CriticalPathReport ID="CriticalPathReport1" runat="server" />--%>

</asp:Content>
