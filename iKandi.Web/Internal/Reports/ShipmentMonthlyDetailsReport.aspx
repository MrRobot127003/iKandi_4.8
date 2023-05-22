<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipmentMonthlyDetailsReport.aspx.cs" 
Inherits="iKandi.Web.ShipmentMonthlyDetailsReport" MasterPageFile="~/layout/Secure.Master"%>



<%@ Register src="../../UserControls/Reports/ShipmentMonthlyDetails.ascx" tagname="ShipmentMonthlyDetails" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">





    <uc1:ShipmentMonthlyDetails ID="ShipmentMonthlyDetails1" runat="server" />





</asp:Content>
