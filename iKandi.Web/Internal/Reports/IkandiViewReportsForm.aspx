<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IkandiViewReportsForm.aspx.cs" Inherits="iKandi.Web.IkandiViewReportsForm" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Reports/IkandiViewReports.ascx" tagname="IkandiViewReports" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:IkandiViewReports ID="IkandiViewReports1" runat="server" />

</asp:Content>