<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStatusSorting.aspx.cs" Inherits="iKandi.Web.Admin.UpdateStatusSorting" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script type="text/javascript">
    function isNumberKey(evt) {
      evt = (evt) ? evt : window.event;
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
      }
      return true;
    }
  </script>
</head>
<body bgcolor="#FFFFFF">
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
      <tr>
        <td>
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td align="center" style="height:34px; background-color:#405D99; color:#FFFFFF; font-size:20px; font-weight:bold; text-align:center; font-family: Arial;">Update Designation Sorting</td>
            </tr>
            <tr>
              <td align="center" style="padding-top:25px; padding-bottom:5px; font-family:Arial;">
                <asp:GridView ID="gvTargetAdminStatus" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="25px" HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="false"
                  HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E">
                  <Columns>             
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                      <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="225px">
                          <tr><td align="center" style="padding-top:5px; padding-bottom:5px; background-color:#405D99; color:#FFFFFF;">Status</td></tr>
                        </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:HiddenField ID="hdnStatusId" runat="server" Value='<%#Eval("StatusModeId") %>' />
                        <asp:Label ID="lblStatus" runat="server" Font-Size="12px" Text='<%#Eval("StatusModeName") %>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                      <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100px">
                          <tr><td align="center" style="padding-top:5px; padding-bottom:5px; background-color:#405D99; color:#FFFFFF;">Order</td></tr>
                        </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:TextBox ID="txtOrder" runat="server" Width="25px" Text='<%#Eval("OrderId") %>' ForeColor="#7E7E7E" MaxLength="2" onkeypress="Javascript:return isNumberKey(event);"></asp:TextBox>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td align="center" style="font-family:Arial; padding-top:5px; padding-bottom:15px; height:15px;">
                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="center" style="padding-bottom:25px;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClick="btnClose_Click" />
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
