<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingBuyingSamplesReport.aspx.cs" Inherits="iKandi.Web.PendingBuyingSamplesReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false"  %>

<%@ Register src="../../UserControls/Reports/PendingBuyingSamples.ascx" tagname="PendingBuyingSamples" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:PendingBuyingSamples ID="PendingBuyingSamples1" runat="server" />
    

</asp:Content>
