<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterC45_46.aspx.cs" Inherits="iKandi.Web.NewsLetterC45_46" %>

<%@ Register src="~/UserControls/Lists/NewsLetterMaterialLateC45_46.ascx" tagname="NewsLetterMaterialLateC45_46" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Lists/NewsLetterLinePlanC45_46.ascx" tagname="NewsLetterLinePlanC45_46" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:NewsLetterMaterialLateC45_46 ID="NewsLetterMaterialLateC45_461" runat="server" />
   </div>
   <div>
        <uc2:NewsLetterLinePlanC45_46 ID="NewsLetterLinePlanC45_461" runat="server" />
   </div>
    </form>
</body>
</html>
