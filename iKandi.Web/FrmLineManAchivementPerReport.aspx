<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLineManAchivementPerReport.aspx.cs" Inherits="iKandi.Web.FrmLineManAchivementPerReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="../../css/report.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
      .f-16px
    {
        font-size: 12px !important;
    }
    .f-14px
    {
        font-size: 12px !important;
    }
      .TotalCQDFUHo
    {
        position: relative;
        display: inline-block;
    }
    
    .TotalCQDFUHo .tooltiptext
    {
          visibility: hidden;
        width: 98px;
        background-color: #565454;
        color: #fff;
        text-align: center;
        border-radius: 6px;
        padding: 3px 0;
        position: absolute;
        z-index: 1;
        top: 100%;
        left: 59%;
        margin-left: -60px;
        line-height: 13px;
        font-size: 12px;
    }
    
    .TotalCQDFUHo .tooltiptext::after
    {
       content: "";
      position: absolute;
      bottom: 100%;
      left: 50%;
      margin-left: -5px;
      border-width: 5px;
      border-style: solid;
      border-color: transparent transparent  #565454 transparent;
    }
    
    .TotalCQDFUHo:hover .tooltiptext
    {
            visibility: visible;
            text-align: left;
            padding-left: 8px;
    }
    ul
    {
        margin: 5px 0px;
        padding-left: 18px;
    }
    li
    {
        font-size: 9px;
        color: #545454;
        line-height: 15px;
    }
  </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div runat="server" id="frmLineWiseEffeciency"></div>

      <ul style='margin-top: 20px'>
                <li><b>Note: </b><span>Following figures are used to calculate scores</span>
                    <ul>
                        <li>Achievement (Line man Achievement)</li>
                        <li>Quality Audit  (Based on QC)</li>
                        <li>Compliance Audit (Factory Specific)</li>
                        <li>Rescan</li>
                        <li>Capacity 60 Lacs</li>
                        <li>Actual Fob -> All Pcs actual (Shipped Unshipped/Qty*Bipl Price*Export Conversion Rate)</li>
                    </ul>
                </li>
            </ul>
            
    </div>
    </form>
</body>
</html>
