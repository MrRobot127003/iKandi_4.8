<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reallocation_Outhouse_Emb.aspx.cs"
    Inherits="iKandi.Web.Reallocation_Outhouse_Emb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControls/Reports/Reallocation_OutHouse_Emb.ascx" TagName="Reallocation_OutHouse_Emb"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Reallocation_OutHouse_Emb ID="Reallocation_OutHouse_Emb1" runat="server" />
    </div>
    </form>
</body>
</html>
