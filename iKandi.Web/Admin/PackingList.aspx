<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackingList.aspx.cs" Inherits="iKandi.Web.Admin.PackingList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style type="text/css">
    .txt
    {
      font-family:Arial;
      text-transform:none;
    }
 
  
  </style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="725px" align="center">
      <tr>
        <td style="width:33%; height:35px; background-color:#405D99;"></td>
        <td align="center" style="width:34%; height:35px; background-color:#405D99; color:#FFFFFF; font-size:22px; text-align:center; font-family:Arial; font-weight: bold;">Packing List</td>
        <td align="right" style="width:33%; height:35px; background-color:#405D99; padding-right:10px;">
          <%--<asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />--%>
        </td>
      </tr>
      <tr><td colspan="3" style="height:10px;"></td></tr>
      <tr>
        <td colspan="3" align="center">
          <asp:GridView ID="gvPackingList" runat="server" AutoGenerateColumns="false" RowStyle-Height="35px" RowStyle-VerticalAlign="Middle" OnRowDataBound="gvPackingList_RowDataBound" ShowHeader="false">
          </asp:GridView>
          <asp:Label ID="lblMessage" runat="server" Text="There are no Size Available for this Contrat." Visible="false" Font-Size="20px" Font-Names="Arial" ForeColor="#7E7E7E"></asp:Label>
        </td>
      </tr>
      <tr>
      <td colspan="3">  &nbsp; </td>
      </tr>
        <tr>
            <td colspan="3" align="right" style="padding-right: 10px;bottom:20px;">
                <asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </td>
        </tr>
    </table>
  </div>
  </form>
</body>
</html>
