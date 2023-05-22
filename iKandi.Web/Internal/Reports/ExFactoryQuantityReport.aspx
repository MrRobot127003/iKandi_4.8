<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExFactoryQuantityReport.aspx.cs" Inherits="iKandi.Web.ExFactoryQuantityReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/ExFactoryQuantity.ascx" tagname="ExFactoryQuantity" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:ExFactoryQuantity ID="ExFactoryQuantity1" runat="server" />
    

</asp:Content>