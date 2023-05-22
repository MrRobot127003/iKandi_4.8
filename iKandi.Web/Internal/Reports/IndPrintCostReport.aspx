<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndPrintCostReport.aspx.cs" Inherits="iKandi.Web.IndPrintCostReport" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Reports/IndPrintCost.ascx" tagname="IndPrintCost" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

  <uc1:IndPrintCost ID="IndPrintCost1" runat="server" />
    

</asp:Content>