<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientsWeeklyStylesQuantity.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.ClientsWeeklyStylesQuantity" %>


<%@ Register Src="~/UserControls/Reports/ClientsWeeklyStylesQuantityReport.ascx" TagName="ClientsWeeklyStylesQuantityReport"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
 <uc1:ClientsWeeklyStylesQuantityReport ID="ClientsWeeklyStylesQuantityReport1" runat="server" />
</asp:Content>