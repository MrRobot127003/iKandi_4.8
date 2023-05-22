<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryFileUpload.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.AccessoryFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
         .UploadFileHeader
        {
            width: 99%;
            padding: 2px;
            background: #1f335d;
            color: #f8f8f8;
            margin: 0px 0px 3px 0px;
            text-align:center;
        } 
        .submit {
        background: #13a747 !important;
        padding: 4px 9px 5px;
        color: #f5f5f5;
        font-size: 11px;
        border: none !important;
        font-weight: bold;
        height: 20px;
        border-radius:3px;
        cursor:pointer;
    }   
     .submit:hover {
        background: #13a747 !important;
        padding: 4px 9px 5px;
        color: yellow;
        font-size: 11px;
        border: none !important;
        font-weight: bold;
        height: 20px;
        border-radius:3px;
    }      
    </style>
</head>
<body>
<script type="text/javascript">
    function CallParentPage() {
        self.parent.Shadowbox.close();
    }
</script>
    <form id="form1" runat="server">
     <div>

             <div class="UploadFileHeader">
                <asp:Label ID="lblUploadText" runat="server" Text="Upload Accessory File"></asp:Label> <span style="float: right; padding: 0px 3px; cursor: pointer;"
                    onclick="CallParentPage();">X</span>                 
            </div>     
            <div style="padding-left:5%; margin-top:8%;">
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td style="width:130px;">Upload Test Report: </td>
                <td style="text-align:left;"><asp:FileUpload ID="UploadTestReport" Width="160px" Font-Size="10px" runat="server"/></td>
                <td style="width:50px;"><asp:HyperLink ID="hlnkTestReport" ToolTip="View Test Report" ImageUrl="~/images/magnify-glass.png" Target="_blank" style="display:none;" runat="server"></asp:HyperLink></td>
                </tr>
                <tr>
                <td style="width:130px; padding-top:5px;">Upload File: </td>
                <td style="text-align:left; padding-top:5px;"><asp:FileUpload ID="UploadFile" Width="160px" Font-Size="10px" runat="server"/></td>
                <td style="width:50px;"><asp:HyperLink ID="hlnkUploadFile" ToolTip="View Upload File" ImageUrl="~/images/magnify-glass.png" Target="_blank" style="display:none;" runat="server"></asp:HyperLink></td>
                </tr>
                <tr><td colspan="3" style="text-align:right; padding-right:10px; padding-top:10px;"><asp:Button ID="btnUpload" runat="server" CssClass="submit" Text="Upload this" OnClick="btnUpload_Click" /></td></tr>
                </table>   
            </div>              
           
    </div>    
    </form>
</body>
</html>
