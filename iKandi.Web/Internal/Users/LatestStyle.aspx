<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LatestStyle.aspx.cs" Inherits="iKandi.Web.Internal.Users.LatestStyle" %>
<%@ Register Src="~/UserControls/Forms/CostingAndEnquiries.ascx" TagName="CostingAndEnquiries"
    TagPrefix="uc" %>
    <%@ Register Src="~/UserControls/Forms/FactoryPerformaceByDHU.ascx" TagName="FactoryPerformaceByDHU"
    TagPrefix="uc1" %>
    <%@ Register Src="~/UserControls/Forms/FactoryStyleDHU.ascx" TagName="FactoryStyleDHU"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <uc:CostingAndEnquiries ID="CostingAndEnquiries" runat="server" /> 
  <%-- <uc1:FactoryPerformaceByDHU ID="FactoryPerformaceByDHU" runat="server" />--%>
  <%--  <uc2:FactoryStyleDHU ID="FactoryStyleDHU1" runat="server" />--%>
    </div>
    </form>
</body>
</html>
