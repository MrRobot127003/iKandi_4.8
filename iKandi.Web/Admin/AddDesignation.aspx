<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDesignation.aspx.cs" Inherits="iKandi.Web.Admin.AddDesignation" %>
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
    .txtHeader
    {
      color:#FFFFFF;
      font-size:17px;
      font-family:Arial;
      font-weight:200;
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
    <table border="0" cellpadding="0" cellspacing="0" width="750px" align="center">
      <tr>
        <td>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td colspan="4" align="center" style="height:34px; background-color:#405D99; color:#FFFFFF; font-size:20px; font-weight:bold; text-align:center; font-family: Arial;">
                <asp:Label ID="lblHeader" runat="server" CssClass="txtHeader"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:25px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Division</td>
              <td align="left" style="padding-top:25px; padding-bottom:5px; width:25%;">
                <asp:Label ID="lblDivision" runat="server" CssClass="txt"></asp:Label>
              </td>
              <td align="left" style="padding-top:25px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Department</td>
              <td align="left" style="padding-top:25px; padding-bottom:5px; width:25%;">
                <asp:Label ID="lblDepartment" runat="server" CssClass="txt"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Designation</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:TextBox ID="txtDesignation" runat="server" Width="150px" CssClass="txt" MaxLength="30"></asp:TextBox>
              </td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Type</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:DropDownList ID="ddlDesignationType" runat="server" Width="155px" CssClass="txt"></asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Line Department</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:DropDownList ID="ddlLineDepartment" runat="server" Width="155px" CssClass="txt" AutoPostBack="true" OnSelectedIndexChanged="ddlLineDepartment_SelectedIndexChanged"></asp:DropDownList>
              </td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; padding-left:50px; width:25%; color:#7E7E7E; font-size:14px; font-weight:bold; font-family:Arial;">Line Designation</td>
              <td align="left" style="padding-top:5px; padding-bottom:5px; width:25%;">
                <asp:DropDownList ID="ddlLineDesignation" runat="server" Width="155px" CssClass="txt"></asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td align="left" style="padding-top:5px; padding-bottom:15px;width:10%;"></td>
              <td colspan="3" align="left" style="font-family:Arial; padding-top:5px; padding-bottom:15px; height:15px;">
                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="center" colspan="4">
                <asp:Button ID="btnSubmit" Width="80px" runat="server" Text="Submit" CssClass="do-not-include submit" onclick="btnSubmit_Click"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="close da_submit_button" Width="80px" OnClick="btnClose_Click" />
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
