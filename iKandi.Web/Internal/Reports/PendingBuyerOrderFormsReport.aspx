<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingBuyerOrderFormsReport.aspx.cs" Inherits="iKandi.Web.PendingBuyerOrderFormsReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/PendingBuyerOrderForms.ascx" tagname="PendingBuyerOrderForms" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:PendingBuyerOrderForms ID="PendingBuyerOrderForms1" runat="server" />
    

</asp:Content>

