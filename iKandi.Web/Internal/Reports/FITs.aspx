<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FITs.aspx.cs" Inherits="iKandi.Web.FITs" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register src="~/UserControls/Reports/FITsReport.ascx" tagname="FITsReport" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:FITsReport ID="FITsReport1" runat="server" />
    

</asp:Content>