<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComplienceAuditReport.aspx.cs" Inherits="iKandi.Web.ComplienceAuditReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .mainheader
        {
            padding:9px 0px;
            background:#dddfe4 !important;
            color: #575759 !important;
            font-size:12px;
            text-align:center;
            margin:0px auto;
            border:1px solid #9999;
            border-bottom: 0px;
        }
           body
        {
            font-size: 11px !important;
font-family: Lucida Sans Unicode;
        }
        .item_list1
        {
            border-collapse:collapse;
        }
        .item_list1 td
        {
            border: 1px solid #b7b4b4;
            text-transform: capitalize !important;
           
        }
        .item_list1 td:first-child
        {
             padding-left: 5px;
        }
        .item_list1 th {
    background: #dddfe4 !important;
    border: 1px solid #b7b4b4 !important;
    color: #575759 !important;
    padding: 4px;
    font-weight:normal;
}
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="scriptmgr" runat="server">    </asp:ScriptManager>
<h2  runat="server" id="mainhead" class="mainheader"> 
<asp:Label runat="server" ID="lblProcessName" Text=""></asp:Label> 
</h2>   
    <asp:UpdatePanel ID="pnlupdate" runat="server">
        <ContentTemplate>
            <div runat="server" id="ProductOccuPational" class="ShowDiv">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
