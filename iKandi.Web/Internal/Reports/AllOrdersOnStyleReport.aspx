<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllOrdersOnStyleReport.aspx.cs" Inherits="iKandi.Web.AllOrdersOnStyleReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/AllOrdersOnStyle.ascx" tagname="AllOrdersOnStyle" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:AllOrdersOnStyle ID="AllOrdersOnStyle1" runat="server" />
    

</asp:Content>

