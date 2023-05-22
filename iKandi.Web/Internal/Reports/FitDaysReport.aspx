<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitDaysReport.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.Internal.Reports.FitDaysReport" %>






<%@ Register src="../../UserControls/Reports/FitDaysForAllClientsReport.ascx" tagname="FitDaysForAllClientsReport" tagprefix="uc1" %>






<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    
    

    
    
    

    <uc1:FitDaysForAllClientsReport ID="FitDaysForAllClientsReport1" 
        runat="server" />
    
    

    
    
    

</asp:Content>
