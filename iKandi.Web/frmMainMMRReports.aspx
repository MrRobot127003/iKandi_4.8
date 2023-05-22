<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMainMMRReports.aspx.cs" Inherits="iKandi.Web.frmMainMMRReporets" %>


<%@ Register src="UserControls/Reports/KeyManPowerSummaryMMR.ascx" tagname="KeyManPowerSummaryMMR" tagprefix="uc1" %>
<%@ Register src="UserControls/Reports/MMRReport.ascx" tagname="MMRReport" tagprefix="uc2" %>
<%@ Register src="UserControls/Reports/BIPLBudgetShortfall.ascx" tagname="BIPLBudgetShortfall" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    
</head>
<body>

    <form id="form1" runat="server">
    <div style="width:100%">
      <span>Dear All,</span><br /><br />
          <span> &nbsp;&nbsp;&nbsp; Please find below Manpower-MMR-Financial as on <b id="getdate" runat="server"></b></span><br />
    
     <uc2:MMRReport id ="MMRReport1" runat="server"/><br />  
     <uc1:KeyManPowerSummaryMMR ID="KeyManPowerSummaryMMR1" runat="server" /><br />

    <uc3:BIPLBudgetShortfall id ="BIPLBudgetShortfall1" runat="server"/>
     <br />
    <br />
        <div style="margin-left: 20px; font-size: 12px;">
            <strong>Thanks & Best Regards </strong>
            <br />
            BIPL Admin
       </div>
        <div style='margin-top: 10px; margin-left: 20px;'>
            <img src='http://boutique.in/images/certificate.jpg' />
         </div>
      </div>
    </form>
   
</body>
</html>
