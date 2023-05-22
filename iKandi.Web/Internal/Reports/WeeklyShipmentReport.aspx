<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeeklyShipmentReport.aspx.cs"
 Inherits="iKandi.Web.WeeklyShipmentReport" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="../../UserControls/Reports/WeeklyShipment.ascx" tagname="WeeklyShipment" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">


    <uc1:WeeklyShipment ID="WeeklyShipment1" runat="server" />


</asp:Content>
