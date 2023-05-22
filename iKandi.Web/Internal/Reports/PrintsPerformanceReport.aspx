<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintsPerformanceReport.aspx.cs" Inherits="iKandi.Web.PrintsPerformanceReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false"  %>

<%--
<%@ Register src="~/UserControls/Reports/ClientDepartmentSalesReport.ascx" tagname="ClientDepartmentSalesReport" tagprefix="uc1" %>--%>
<%@ Register src="~/UserControls/Reports/PrintPerformance.ascx" tagname="PrintPerformanceReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

  <uc1:PrintPerformanceReport ID="PrintsPerformanceReport1" runat="server" />
    

</asp:Content>