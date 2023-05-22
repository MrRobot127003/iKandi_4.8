<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="QualityControlHistory.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.QualityControlHistory" %>


<%@ Register src="../../UserControls/Forms/QualityControlHistory.ascx" tagname="QualityControlHistory" tagprefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    
    <uc1:QualityControlHistory ID="QualityControlHistory1" runat="server" />
    
</asp:Content>
