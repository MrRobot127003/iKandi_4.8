<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalAuditReplica.aspx.cs"
    Inherits="iKandi.Web.AuditTestReplica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        li
        {
            margin: 2px 0px;
        }
        a:hover
        {
            text-decoration: underline !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 80%; margin-left: 20px; font-size: 12px;">
        <h4 style="font-size: 12px; font-weight: 500; margin: 5px 0px 0px; font-family: arial,halvetica;">
            Hi Team BIPL,</h4>
        <br />
        Please follow the below links to access the factory specific Internal Audit Report,<br />
        <ul>
            <asp:Repeater ID="rptLink" runat="server">
                <ItemTemplate>
                    <div style="font-size: 14px;">
                        <span style="font-weight: bold">
                            <li><a href='<%# Bind("Unithref") %>' runat="server" id="aLinkInternalAudit" style="text-decoration: none;
                                font-family: arial,halvetica; color: Blue">
                                <asp:Label ID="unitName" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label></a>
                            </li>
                        </span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <br />
    <br />
    <div style="margin-left: 20px; font-size: 12px;">
        <strong>Thanks & Best Regards </strong>
        <br />
        HR Teams</div>
    <div style='margin-top: 10px; margin-left: 20px;'>
        <img src='http://boutique.in/images/certificate.jpg' /></div>
    </form>
</body>
</html>
