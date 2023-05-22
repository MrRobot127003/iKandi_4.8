<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmComplianceAuditC45_Report.aspx.cs" Inherits="iKandi.Web.FrmComplianceAuditReportC45" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .FirstChild
    {
        background:#DDDFE4;
        font-weight:normal;
    }
    table.inputfixed th.HeaderStyle1
    {
        background-color: #bfbdbd;
    }
    .footerback td:nth-child(2)
    {
        font-weight:bold;
    }
    table tr td,table tr th
    {
        border-color:Gray;
    }
    .GreenColor span
    {
        color:Green;
        font-weight:600;
      }
    .RedColor span
    {
        color:red;
      }
    .BlackColor span
    {
        color:#000;
      }
      td
      {
          font-size:10px;
       }
      .AddClass_Table th
      {
          font-size:10px;
          color:#6b6464 !important;
       }
      .headerColor
      {
          color:#6b6464 !important;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="grdComplianceQAuditReportC45" BorderWidth="0" runat="server" CssClass="AddClass_Table inputfixed"
        AutoGenerateColumns="false" 
            OnRowDataBound="grdComplianceQAuditReportC45_RowDataBound">
    </asp:GridView>
    </div>
    </form>
</body>
</html>
