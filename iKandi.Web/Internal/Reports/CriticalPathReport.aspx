<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriticalPathReport.aspx.cs" Inherits="iKandi.Web.CriticalPathReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%--<%@ Register src="../../UserControls/Reports/ProductionReport.ascx" tagname="ProductionReport" tagprefix="uc1" %>--%>
<%@ Register src="../../UserControls/Reports/CriticalPathReports.ascx" tagname="CriticalPathReport" tagprefix="cpr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <%--<uc1:ProductionReport ID="ProductionReport1" runat="server" />--%>
     <cpr:CriticalPathReport ID="CriticalPathReport1" runat="server" />

</asp:Content>
