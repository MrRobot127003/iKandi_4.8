<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLaxmanReport.aspx.cs" Inherits="iKandi.Web.frmLaxmanReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="~/UserControls/Lists/ShipmentByDateControl.ascx" tagname="ShipmentByDateControl" tagprefix="uc2" %>

<%--<%@ Register src="UserControls/Reports/frmFactoryPerformanceReports.ascx" tagname="frmFactoryPerformanceReports" tagprefix="uc1" %>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <uc2:ShipmentByDateControl ID="ShipmentByDateControl1" runat="server" />
    <%--<uc1:frmFactoryPerformanceReports ID="frmFactoryPerformanceReports1" 
        runat="server" />--%>
     
       

    </form>
</body>
</html>
