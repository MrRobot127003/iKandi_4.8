<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyFrom.aspx.cs" Inherits="iKandi.Web.Admin.CopyFrom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script type="text/javascript">
    function Confirm() {
      var confirm_value = document.createElement("INPUT");
      confirm_value.type = "hidden";
      confirm_value.name = "confirm_value";
      if (confirm("This Client's predecessors and associated designations will get update by selected client. Are you sure to do so?")) {
        confirm_value.value = "Yes";
      } else {
        confirm_value.value = "No";
      }
      document.forms[0].appendChild(confirm_value);
    }
</script>
  <style type="text/css">
    .txt
    {
      font-family:Arial;
      color:#7E7E7E;
      text-transform:none;
      padding-left:5px;
    }
  </style>
</head>
<body bgcolor="#FFFFFF">
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
      <tr>
        <td align="center" style="background-color: #405D99; height:50px; color: #FFFFFF; font-size: 22px; font-family:Arial; font-weight:bold;">Copy Data</td>
      </tr>
      <tr>
        <td style="height:30px;"></td>
      </tr>
      <tr>
        <td align="center">
          <asp:Label ID="lblCopyFrom" runat="server" CssClass="txt" Font-Size="14px" Text="Copy Data From"></asp:Label>&nbsp;&nbsp;
          <asp:DropDownList ID="ddlCopyFrom" runat="server" Font-Size="14px" CssClass="txt" Height="22px" Width="200px" onchange="Confirm()" AutoPostBack="true" OnSelectedIndexChanged="ddlCopyFrom_SelectedIndexChanged"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td align="center" style="padding-top:15px;">
          <asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClick="btnClose_Click" />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
