<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplingStatus.aspx.cs" EnableEventValidation="false" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.SamplingStatusReportContainer" %>

<%@ Register src="../../UserControls/Reports/SamplingStatus.ascx" tagname="SamplingStatus" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">




    <uc1:SamplingStatus ID="SamplingStatus1" runat="server" />




</asp:Content>
