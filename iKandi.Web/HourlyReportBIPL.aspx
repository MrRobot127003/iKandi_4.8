<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HourlyReportBIPL.aspx.cs" Inherits="iKandi.Web.HourlyReportBIPL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="~/UserControls/Lists/HourlyStitchingReport.ascx" tagname="HourlyStitchingReport" tagprefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <uc2:HourlyStitchingReport ID="HourlyStitchingReport1" 
       runat="server" />
    </form>
</body>
</html>
