<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomErrorPage.aspx.cs" Inherits="iKandi.Web.Internal.CustomErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding-top:50px;">
    <asp:Image ID="imgError" Height="100px" Width="100px" ImageUrl="~/images/Error.svg.png" runat="server" />
    </div>
    <div style="text-align:center; padding-top:10px;">        
        <asp:Label ID="lblMessage" ForeColor="Red" Font-Size="14px" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
