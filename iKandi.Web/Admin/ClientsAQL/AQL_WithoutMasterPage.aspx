<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQL_WithoutMasterPage.aspx.cs" Inherits="iKandi.Web.Admin.ClientsAQL.AQL_WithoutMasterPage" %>

<%@ Register src="../../UserControls/Forms/AQL_Admin.ascx" tagname="AQL_Admin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <uc1:AQL_Admin ID="AQL_Admin1" runat="server" />
       
    </div>
    </form>
</body>
</html>
