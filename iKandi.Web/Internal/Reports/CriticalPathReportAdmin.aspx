<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="CriticalPathReportAdmin.aspx.cs" Inherits="iKandi.Web.Internal.Reports.CriticalPathReportAdmin" %>

<%@ Register src="../../UserControls/Reports/CriticalPathReportAdmin.ascx" tagname="CriticalPathReportAdmin" tagprefix="cprA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
   
     <cprA:CriticalPathReportAdmin ID="CriticalPathReportAdmin1" runat="server" />

</asp:Content>