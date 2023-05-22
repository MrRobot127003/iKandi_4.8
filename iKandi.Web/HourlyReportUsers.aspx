<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HourlyReportUsers.aspx.cs" Inherits="iKandi.Web.HourlyReportUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="~/UserControls/Lists/HourlyStitchingReportUser.ascx" TagName="HourlyStitchingReportUser" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
    <uc1:HourlyStitchingReportUser ID="HourlyStitchingReportUser1" 
       runat="server" />
    </form>
</body>
</html>
