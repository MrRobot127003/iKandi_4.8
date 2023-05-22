<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="iKandi.Web.Admin.AddDepartment" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style type="text/css">
    .txt
    {
      color:#7E7E7E;
      text-transform:none;
      font-size:12px;
      font-family:Arial;
    }
    input.txt
    {
      color:#7E7E7E;
      text-transform:none;
      font-size:12px;
      font-family:Arial;
    }
  </style>
</head>
<body bgcolor="#FFFFFF">
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="400px" align="center">
      <tr>
        <td>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td colspan="2" align="center" style="height:34px; background-color:#405D99; color:#FFFFFF; font-size:14px; font-weight:bold; text-align:center; font-family: Lucida Sans Unicode;">Add Department</td>
            </tr>
            <tr>
              <td align="left" style="padding-top:25px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Division</td>
              <td align="left" style="padding-top:25px; padding-bottom:5px; width:25%;">
                <asp:DropDownList ID="ddlDivision" runat="server" CssClass="txt" Width="154px"></asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Department</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:TextBox ID="txtDepartment" runat="server" CssClass="txt" MaxLength="30" Width="150px"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Is Active</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:5px;width:25%;"></td>
              <td align="left" style="font-family:Arial; padding-top:5px; padding-bottom:5px; height:15px;">
                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="do-not-include submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="close" Width="86px" OnClick="btnClose_Click" />
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table> 
  </div>
  </form>
</body>
</html>
