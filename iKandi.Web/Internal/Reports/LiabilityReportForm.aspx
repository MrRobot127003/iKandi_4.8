<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiabilityReportForm.aspx.cs" Inherits="iKandi.Web.LiabilityReportForm" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>


<%@ Register src="../../UserControls/Reports/LiabilityReport.ascx" tagname="LiabilityReport" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:LiabilityReport ID="LiabilityReport1" runat="server" />
    

</asp:Content>