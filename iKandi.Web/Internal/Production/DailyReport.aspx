<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="DailyReport.aspx.cs" Inherits="iKandi.Web.Internal.Production.DailyReport" %>
<%@ Register src="~/UserControls/Reports/DailyMMR_Summery.ascx" tagname="DailyMMR_Summery" tagprefix="uc2" %>
<%@ Register src="~/UserControls/Reports/DailyPerformance.ascx" tagname="DailyPerformance" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<div>
<uc2:DailyMMR_Summery ID="DailyMMR_Summery1" runat="server" />
</div>
<div>
<uc1:DailyPerformance ID="DailyPerformance1" runat="server" />
</div>


</asp:Content>
