<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AverageLeadTimesReport.aspx.cs" Inherits="iKandi.Web.AverageLeadTimesReport"  MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register src="../../UserControls/Reports/AverageLeadTimes.ascx" tagname="AverageLeadTimes" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:AverageLeadTimes ID="AverageLeadTimes1" runat="server" />
    

</asp:Content>