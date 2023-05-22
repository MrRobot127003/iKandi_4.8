<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SanjeevTest.aspx.cs" Inherits="iKandi.Web.SanjeevTest" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            width: 100%;
        }
        table, th, td
        {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 5px;
        }

     .fontsize{
             font-size: 12px !important;
             color:#fff;
         }
        .InternalAdminTable{
            border:1px solid #999;
            border-collapse:collapse;
            font-family: Arial, Helvetica, sans-serif
        }
        .InternalAdminTable th{
            background: #39589c;
            border:1px solid #999;
            border-collapse:collapse;
            font-size: 11px;
            font-weight: 500;
            padding:3px 0px;
            color: #e7e4fb;
            font-family: Arial;
            min-width: 66px;
            height: 12px;
        }
        .InternalAdminTable td{
            border:1px solid #999;
            font-size: 10px;
            padding:3px 3px;
            color: #272626;
            height: 12px;
            font-family: Arial;
            height: 12px;
            text-align: center !important;
        } 
        .InternalAdminTable td:first-child{
           text-align: left;
        }
        .fontweightblod{
           font-weight: 600;
           text-align: left
        }
        
        .textcolorGray{
         color:gray !important;
         /* float: right;*/
        }
        .totaltextColorBack{
           font-weight: 600;
           background: #fff0a5;
        }
        .colorRed{
           color:red !important;
           /*float: right;*/
        }
        .txtright{
         /*float: right;*/
        }
        .textLeft{
           text-align: left !important
        }
        .textcolorName
        {
            color:Gray !important;
         }
      </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <%--<asp:Button Text="GeneratePdf" ID="BtnGenRate" runat="server" 
            onclick="BtnGenRate_Click"   />--%>
        <asp:Label ID="lblsplitHistory" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
