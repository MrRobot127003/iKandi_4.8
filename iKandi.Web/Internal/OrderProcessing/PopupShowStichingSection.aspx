<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopupShowStichingSection.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.PopupShowStichingSection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>

<script type="text/javascript">


    function NewPage(IsCreated) {
        //debugger;

        window.opener.ClosePageNew(IsCreated);
        this.parent.window.close();
        return false;
    }


</script>
<style>
select option
{
    border-bottom:1px solid #fff !important;
    padding:5px 0px !important;
}

</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>

    <tr>
    <td bgcolor="#717171" style="padding:5px; color:#fff; font-weight:bold;">
     Select Operation
    </td>
    </tr>
    <tr>
    <td>
    <asp:ListBox ID="lstSection" runat="server" SelectionMode="Multiple" Width="200" Height="150" style="font-weight:bold; background:#f2f2f2;"></asp:ListBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" style="background-color:#737373; padding:5px 0px; width:70%; color:#fff; font-weight:bold;" />
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
