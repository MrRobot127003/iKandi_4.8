<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingCalucaltor.aspx.cs" Inherits="iKandi.Web.Internal.Users.BookingCalucaltor" %>

  <%@ Register Src="~/UserControls/Forms/BookingCalculator.ascx" TagName="BookingCalculator"
    TagPrefix="uc1" %>
    <script src="../../js/jquery-1.4.4.min.js" type="text/javascript"></script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <uc1:BookingCalculator ID="BookingCalculator1" runat="server" />
    </div>
    </form>
</body>
</html>
