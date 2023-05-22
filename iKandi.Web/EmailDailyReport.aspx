<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailDailyReport.aspx.cs" Inherits="iKandi.Web.EmailDailyReport" %>
<%@ Register Src="~/UserControls/Reports/DailyPerformance.ascx" TagName="DailyPerformance" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Reports/DailyMMR_Summery.ascx" TagName="DailyMMR_Summery" TagPrefix="uc1" %>
<%--<%@ Register Src="~/UserControls/Forms/FactoryPerformaceByDHU.ascx" TagName="Factoty_performance" TagPrefix="uc1" %>--%>
<%--<%@ Register Src="~/UserControls/Forms/FactoryStyleDHU.ascx" TagName="Factoty_Style" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Reports/Penalty_Matrics.ascx" TagName="Penalty_Matrics" TagPrefix="uc1" %>--%>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
   
</head>
<body>
  <form id="form1" runat="server">

   <div><uc1:DailyMMR_Summery ID="DailyMMR_Summery1" runat="server" /></div>
 <div><uc1:DailyPerformance ID="DailyPerformance1" runat="server" /></div>

 
   
    
 
    
  </form>
</body>
</html>
