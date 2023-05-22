<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SealingPerformanceReport.aspx.cs" Inherits="iKandi.Web.SealingPerformanceReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/SealingPerformance.ascx" tagname="SealingPerformance" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:SealingPerformance ID="SealingPerformance1" runat="server" />
    

</asp:Content>



