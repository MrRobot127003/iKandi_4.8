<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeReportsForm.aspx.cs" Inherits="iKandi.Web.ModeReportsForm" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="../../UserControls/Reports/ModeReports.ascx" tagname="ModeReports" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    
    

    <uc1:ModeReports ID="ModeReports1" runat="server" />
    
    

</asp:Content>
