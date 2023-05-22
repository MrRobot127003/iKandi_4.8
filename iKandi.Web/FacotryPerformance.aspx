<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacotryPerformance.aspx.cs" Inherits="iKandi.Web.FacotryPerformance" %>

<%@ Register Src="~/UserControls/Forms/FactoryPerformaceByDHU.ascx" TagName="Factoty_performance" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Forms/FactoryStyleDHU.ascx" TagName="Factoty_Style" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="height:50px;"></div>
  <div>
    <uc1:Factoty_Style ID="Factoty_Style1" runat="server" />
  </div>
 <div style="height:50px;"></div>
  <div>
    <uc1:Factoty_performance ID="Factoty_performance1" runat="server" />
  </div>
    </div>
    </form>
</body>
</html>
