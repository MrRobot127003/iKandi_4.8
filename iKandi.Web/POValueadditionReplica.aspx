<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POValueadditionReplica.aspx.cs" Inherits="iKandi.Web.POValueadditionReplica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div style="width: 80%; margin-left: 20px; font-size: 12px;">
        <h4 style="font-size: 12px; font-weight: 500; margin: 5px 0px 0px; font-family: arial,halvetica;">
            Hi <span id="SupplierName" runat="server"></span>,</h4>
            
        <br />
        Please Find the Value Addition PO 
         <%-- <asp:HyperLink ID="hlkPO" runat="server">Click</asp:HyperLink>--%>
       
    </div>
    <br />
    <br />
    <div style="margin-left: 20px; font-size: 12px;">
        <strong>Thanks & Best Regards </strong>
        <br />
        BIPL Team</div>
    <div style='margin-top: 10px; margin-left: 20px;'>
        <img src='http://boutique.in/images/certificate.jpg' /></div>
    </form>
</body>
</html>
