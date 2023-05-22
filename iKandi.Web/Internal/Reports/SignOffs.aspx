<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignOffs.aspx.cs" Inherits="iKandi.Web.SignOffs" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false"  %>

<%@ Register src="~/UserControls/Reports/SignOffReport.ascx" tagname="SignOffReport" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:SignOffReport ID="SignOffReport1" runat="server" />
    

</asp:Content>
