<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PentlyReportNew.aspx.cs" Inherits="iKandi.Web.PentlyReportNew" %>
<%@ Register Src="~/UserControls/Reports/Penality_MatrixNew.ascx" TagName="Penality_MatrixNew" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc1:Penality_MatrixNew ID="Penalty_MatrixNew" runat="server" />
    </div>
    </form>
</body>
</html>
