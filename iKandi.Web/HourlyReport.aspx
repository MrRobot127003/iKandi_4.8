<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HourlyReport.aspx.cs" Inherits="iKandi.Web.HourlyReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="~/UserControls/Lists/HourlyReportStyleCodeNew.ascx" tagname="HourlyReportStyleCodeNew" tagprefix="uc1" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
</head>
<body>
    <form id="form1" runat="server">
         
    <uc1:HourlyReportStyleCodeNew ID="HourlyReportStyleCodeNew1" runat="server" /> 
    
    </form>
</body>
</html>
