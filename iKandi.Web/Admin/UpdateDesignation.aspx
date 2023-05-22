<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDesignation.aspx.cs" Inherits="iKandi.Web.Admin.UpdateDesignation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
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
        <td align="center" style="background-color: #405D99; height:50px; color: #FFFFFF; font-size: 22px; font-family:Arial;">Update Designation</td>
      </tr>
      <tr>
        <td style="height:30px;"></td>
      </tr>
      <tr>
        <td>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td align="left" style="width:40%; padding-left:10px;">
                <asp:ListBox ID="lstDesignation" runat="server" CssClass="txt" Font-Size="12px" Height="200px" Width="350px" SelectionMode="Multiple"></asp:ListBox>
              </td>
              <td align="center" style="width:20%;">
                <asp:Button ID="btnAddAll" runat="server" Width="50px" Text=">>" Font-Bold="true" OnClick="btnAddAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Width="50px" Text=">" Font-Bold="true" OnClick="btnAdd_Click" /><br /><br /><br /><br />
                <asp:Button ID="btnRemove" runat="server" Width="50px" Text="<" Font-Bold="true" OnClick="btnRemove_Click" />
                <asp:Button ID="btnRemoveAll" runat="server" Width="50px" Text="<<" Font-Bold="true" OnClick="btnRemoveAll_Click" />
              </td>
              <td align="right" style="width:40%; padding-right:10px;">
                <asp:ListBox ID="lstUpdatedDesignation" runat="server" CssClass="txt" Font-Size="12px" Height="200px" Width="350px" SelectionMode="Multiple"></asp:ListBox>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td align="center" style="font-family:Arial; padding-top:5px; padding-bottom:15px; height:15px;">
          <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
        </td>
      </tr>
      <tr>
        <td align="center" style="padding-bottom:25px;">
          <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" OnClick="btnSubmit_Click" />
          <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" text="Close"  OnClick="btnClose_Click" />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>