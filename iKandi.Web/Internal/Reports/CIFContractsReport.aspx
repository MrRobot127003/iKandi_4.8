<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CIFContractsReport.aspx.cs"
 Inherits="iKandi.Web.CIFContractsReport" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="../../UserControls/Reports/CIFContracts.ascx" tagname="CIFContracts" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:CIFContracts ID="CIFContracts1" runat="server" />
</asp:Content>
