<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RejectedQaContractsReport.aspx.cs" Inherits="iKandi.Web.RejectedQaContractsReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/RejectedQaContracts.ascx" tagname="RejectedQaContracts" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:RejectedQaContracts ID="RejectedQaContracts1" runat="server" />
    

</asp:Content>