<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFabricHistory.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.frmFabricHistory" %>

<%@ Register src="~/UserControls/Lists/frmHistoryFabricRemarks.ascx"tagname="frmHistoryFabricRemarks" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:frmHistoryFabricRemarks ID="frmHistoryFabricRemarks1" runat="server" />
    
    </div>
    </form>
</body>
</html>
