<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipmentByUnitReport.aspx.cs"
 Inherits="iKandi.Web.ShipmentByUnitReport" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Reports/ShipmentByUnit.ascx" tagname="ShipmentByUnit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:ShipmentByUnit ID="ShipmentByUnit1" runat="server" />

</asp:Content>

