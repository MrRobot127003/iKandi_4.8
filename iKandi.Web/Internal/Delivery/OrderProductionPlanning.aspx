<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProductionPlanning.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.OrderProductionPlanning" %>

<%@ Register src="../../UserControls/Lists/ProductionPlanning.ascx" tagname="ProductionPlanning" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">



    <uc1:ProductionPlanning ID="ProductionPlanning1" runat="server" />



    


</asp:Content>
