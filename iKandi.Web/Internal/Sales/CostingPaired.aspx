<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostingPaired.aspx.cs" Inherits="iKandi.Web.Internal.Sales.CostingPaired" %>

<%@ Register src="../../UserControls/Lists/PairingCosting.ascx" tagname="PairingCosting" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" padding:0px;">
    <uc1:PairingCosting ID="PairingCosting1" runat="server" />
    </div>
    </form>
</body>
</html>
