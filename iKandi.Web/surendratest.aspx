<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="surendratest.aspx.cs" Inherits="iKandi.Web.surendratest" %>







<%--<%@ Register src="UserControls/Reports/Rpt_AM_PerformanceReports.ascx" tagname="frm_pending_cost_confirmation" tagprefix="uc1" %>--%>
<%@ Register src="UserControls/Reports/Rpt_AM_PerformanceReports.ascx" tagname="Rpt_AM_PerformanceReports" tagprefix="uc2" %> 
<%--<%@ Register src="UserControls/Lists/ShipmentByDateControl.ascx" tagname="frm_pending_cost_confirmation" tagprefix="uc1" %>--%>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
       
    </div>
   
    
  <uc2:Rpt_AM_PerformanceReports ID="Rpt_AM_PerformanceReports" runat="server" />
   
   <%-- <uc1:frm_pending_cost_confirmation ID="frm_pending_cost_confirmation1" runat="server" />--%>
   <%-- <uc1:frm_pending_cost_confirmation ID="frm_pending_cost_confirmation" runat="server" />--%>
   
    <br />
 
    
    </form>
</body>
</html>
