<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitsReUsePopup.aspx.cs" Inherits="iKandi.Web.Admin.FitsSample.FitsReUsePopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" language="javascript">
    function GotoNew() {
        //debugger;
        window.opener.Fits_CreateNew();
        this.parent.window.close();       
        return false;
    }

    function NewWithRefrence(NewStyleID, NewStyleNumber) {
        //debugger;
        window.opener.Fits_NewRefrence(NewStyleID, NewStyleNumber);
        this.parent.window.close();
        return false;
    }

    function ReUse(ReUseStyleID, ReUseStyleNumber) {
        //debugger;
        window.opener.Fits_ReUse(ReUseStyleID, ReUseStyleNumber);
        this.parent.window.close();
        return false;
    }



</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <a id="frame" href="#">
    <div>
    <table width="100%">
    <div style="background:#39589c; color:#fff; text-align:center; margin:0px; font-weight:bold; font-size:16px; padding:5px;"> Create New / Link with Style 

    </div>
           
     <tr>
     <td>
             <table width="95%" border="0" cellpadding="0" cellspacing="0" align="center">
             <tr>

    <td align="center"><asp:HiddenField ID="hdnTab" Value="0" runat="server" />        
        <asp:Button ID="btnCreateNew" CssClass="btn" OnClientClick="javascript:return GotoNew();" runat="server" Text="Create New" />  
         /      <asp:DropDownList CssClass="ddlStyle" ID="ddlNewWithRefrence" AutoPostBack="true" runat="server" style="font-family: verdana; width:215px; font-size: 13px; color: #262626; background:#efefef" onselectedindexchanged="ddlNewWithRefrence_SelectedIndexChanged">
        <asp:ListItem Value="0" Text="Link with Style"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList CssClass="ddlStyle" ID="ddlReUse" AutoPostBack="true" runat="server" style="font-family: verdana; width:215px; font-size: 13px; color: #262626; background:#efefef" onselectedindexchanged="ddlReUse_SelectedIndexChanged">
        <asp:ListItem Value="0" Text="Link with Style"></asp:ListItem>
        </asp:DropDownList>
        </td>  
           
    </tr>
    </table>
    </td>
    </tr>
    </table>
    </div>
    </a>
    </div>
    </form>
</body>
</html>
