<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplingFitsCycleHistory.aspx.cs" Inherits="iKandi.Web.Admin.FitsSample.SamplingFitsCycleHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/UserControls/Lists/SamplingFitsCycleHistory.ascx" TagName="FitsHistory" TagPrefix="uc1" %> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <uc1:FitsHistory ID="FitsHistory1" runat="server" />
    </div>
    </form>
</body>
</html>
