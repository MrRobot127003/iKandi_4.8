<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketingAdmin.aspx.cs" Inherits="iKandi.Web.Admin.MarketingAdmin" %>

<%@ Register src="../UserControls/Forms/frmCollection.ascx" tagname="frmCollection" tagprefix="uc1" %>
<%@ Register src="../UserControls/Forms/frmTagMarketing.ascx" tagname="frmTagMarketing" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>    
    <style type="text/css">
        .AddClass_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .AddClass_Table th
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            text-transform: unset;
        }
        .AddClass_Table td:first-child
        {
            border-left-color: #999 !important;
        }
        .AddClass_Table td:last-child
        {
            border-right-color: #999 !important;
        }
        .AddClass_Table tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .AddClass_Table td input[type="text"]
        {
            width: 98%;
            height: 12px;
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            padding-left: 2px;
            margin: 2px 0px;
            text-transform: unset;
            text-align: center;
            border-radius:2px;
        }
        .AddClass_Table td textarea
        {
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            margin: 1px 0px;
            width: 95%;
           text-transform: unset;
        }
      
        .facolor
        {
            font-size: 14px;
            cursor: pointer;
        }
        .floatLeft
        {
            margin-right: 10px;
            float:left;
        }
      input[type='submit'].btnSearch {
            background: #13a747;
            color: #fff;
            font-size: 11px;
            border: 1px solid #13a747;
            border-radius: 2px;
            margin: 3px 0px;
            cursor:pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div style="width:850px;margin:0 auto;">
    <uc1:frmCollection ID="frmCollection1" runat="server" style='float:left;margin-right:10px;' />
    <uc2:frmTagMarketing ID="frmTagMarketing1" runat="server" />
  </div>
    </form>
</body>
</html>
