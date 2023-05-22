<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VAMinRate_Rrport.aspx.cs"
    Inherits="iKandi.Web.VAMinRate_Rrport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .CommoAdmin_Table td
        {
            height: 20px;
        }
        .alignCenter
        {
          text-align:center;   
         }
          .CommoAdmin_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .CommoAdmin_Table th
        {
           background: #e4e2e2; 
           border: 1px solid #dbd8d8;
           border-collapse: collapse;
           font-size: 11px; 
           font-weight: 500; 
           padding: 3px 5px;
           text-align:left;
           color: #575759;
        }
        .CommoAdmin_Table td
        {
            width:100px;
            border: 1px solid #dbd8d8;
            font-size: 11px; 
            padding: 3px 5px;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="VAMinRate" runat="server"> </div><br />
         <div id="VendorService" runat="server"> </div>
       
    </div>
    </form>
</body>
</html>
