<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricExhallanPdfPage.aspx.cs" Inherits="iKandi.Web.Internal.Reports.FabricExhallanPdfPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style>
        table
        {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
            border-spacing: 0;
            width:600px;
            font-size: 11px;
        }
        
        
        table td
        {
            border: 1px solid #999;
            text-align: center;
            font-weight: 500;
            color: #575759;
            padding: 3px 3px;
            min-width: 50px;
            font-size: 11px;
        }
        
        
        table th
        {
            background-color: #dddfe4;
            border: 1px solid #999;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            font-weight: 500;
            color: #575759;
            border-top:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 10px 0px 0px 10px;">
          <div id="TopSection" runat="server"></div>
        </div>
        <div style="margin: 10px 0px 0px 10px;">
          <div id="AccessoryRemaQty" runat="server"></div>
        </div>
        <div style='padding:10px 10px;margin-top:0px;width:762px'>
              <div id="FabricSignature" runat="server"></div>
        
          </div>
    </form>
</body>
</html>
