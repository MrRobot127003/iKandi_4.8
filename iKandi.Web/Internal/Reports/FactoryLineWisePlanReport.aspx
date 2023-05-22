<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactoryLineWisePlanReport.aspx.cs" Inherits="iKandi.Web.FactoryLineWisePlanReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register src="../../UserControls/Reports/FactoryLineWisePlan.ascx" tagname="FactoryLineWisePlan" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:FactoryLineWisePlan ID="FactoryLineWisePlan1" runat="server" />
    

</asp:Content>