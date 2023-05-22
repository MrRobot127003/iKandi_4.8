<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryPerformanceReport.aspx.cs" Inherits="iKandi.Web.AccessoryPerformanceReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/AccessoryPerformance.ascx" tagname="AccessoryPerformance" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:AccessoryPerformance ID="AccessoryPerformance1" runat="server" />
    

</asp:Content>