<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHRSheet.aspx.cs" Inherits="iKandi.Web.frmHRSheet" %>

<%@ Register Src="UserControls/Reports/Test.ascx" TagName="Test" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="http://www.boutique.in/CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js"
        type="text/javascript"></script>
    <link href="http://www.boutique.in/CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css"
        rel="stylesheet" type="text/css" />
    <script src="http://www.boutique.in/CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js"
        type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <uc1:Test ID="Test1" runat="server" />
    </form>
</body>
</html>
