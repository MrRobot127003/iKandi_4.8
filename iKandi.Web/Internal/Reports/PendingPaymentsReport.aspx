<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingPaymentsReport.aspx.cs" EnableEventValidation="false"
 Inherits="iKandi.Web.PendingPaymentsReport" MasterPageFile="~/layout/Secure.Master" Theme="ikandi" %>


<%@ Register src="../../UserControls/Reports/PendingPayments.ascx" tagname="PendingPayments" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:PendingPayments ID="PendingPayments1" runat="server" />

</asp:Content>