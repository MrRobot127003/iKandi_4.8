<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanCalender.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.ProductionPlanCalender" %>

<%@ Register src="../../UserControls/Forms/ProductionPlanCalenderForm.ascx" tagname="ProductionPlanCalenderForm" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ProductionPlanCalenderForm ID="ProductionPlanCalenderForm1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
