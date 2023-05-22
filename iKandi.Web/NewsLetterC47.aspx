<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterC47.aspx.cs" Inherits="iKandi.Web.NewsLetterC47" %>



<%@ Register src="~/UserControls/Lists/NewsLetterMaterialLateC47.ascx" tagname="NewsLetterMaterialLateC47" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Lists/NewsLetterLinePlanC47.ascx" tagname="NewsLetterLinePlanC47" tagprefix="uc2" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
   <div>
        <uc1:NewsLetterMaterialLateC47 ID="NewsLetterMaterialLateC471" runat="server" />
   </div>
   <div>
        <uc2:NewsLetterLinePlanC47 ID="NewsLetterLinePlanC471" runat="server" />
   </div>
    
    </form>
</body>
</html>
