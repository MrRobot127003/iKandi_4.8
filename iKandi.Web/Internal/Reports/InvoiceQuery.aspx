<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceQuery.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.IKandiInvoivesQuery" %>

<%@ Register src="../../UserControls/Reports/ikandiInvoiceQuery.ascx" tagname="iKandiInvoiceQueryList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    
  
    
    <uc1:iKandiInvoiceQueryList ID="iKandiInvoiceQueryList1" runat="server" />
    
  
    
</asp:Content>
