<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BharatTest.aspx.cs" Inherits="iKandi.Web.BharatTest" %>


<%@ Register src="UserControls/Reports/Rpt_AM_PerformanceReports.ascx" tagname="Rpt_AM_PerformanceReports" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Rpt_AM_PerformanceReports ID="Rpt_AM_PerformanceReports1" runat="server" />
    </div>
    </form>
</body>
</html>
