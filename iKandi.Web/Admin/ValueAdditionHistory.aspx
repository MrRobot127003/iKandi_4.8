<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValueAdditionHistory.aspx.cs" Inherits="iKandi.Web.Admin.ValueAdditionHistory" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
  <style type="text/css">
      .remove-head th
      {
          display: none;
      }
      
      .txt
      {
          color: #7E7E7E;
          font-family: Arial;
          text-transform: none;
          text-align: center;
      }
      .ValuQty
      {
          border-top: 1px solid grey;
          display: inline-block;
          width: 100%;
      }
  </style>
  <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
  <script type="text/javascript">
    $(document).ready(function () {
      FillTotalValueAddQtyHistory();
    });

    function FillTotalValueAddQtyHistory() {
      var cell;
      var TotalValueAddQty = 0;
      var gvDrv = document.getElementById("gvValueAdditionHistory");
      var RowCount = parseInt(gvDrv.rows.length);
      var ColumnCount = parseInt(document.getElementById("hdnColumnCount").value);

      for (i = 2; i < RowCount; i++) {
        if (gvDrv.rows[i].cells.length == 19) {
          for (j = 3; j < (ColumnCount + 3); j++) {
            if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
              TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
            }
          }

          if (TotalValueAddQty > 0) {
            gvDrv.rows[i].cells[ColumnCount + 3].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
          }
          else {
            gvDrv.rows[i].cells[ColumnCount + 3].getElementsByTagName("span")[0].innerHTML = '';
          }
          TotalValueAddQty = 0;
        }
        else if (gvDrv.rows[i].cells.length == 18) {
          for (j = 2; j < (ColumnCount + 2); j++) {
            if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
              TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
            }
          }

          if (TotalValueAddQty > 0) {
            gvDrv.rows[i].cells[ColumnCount + 2].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
          }
          else {
            gvDrv.rows[i].cells[ColumnCount + 2].getElementsByTagName("span")[0].innerHTML = '';
          }
          TotalValueAddQty = 0;
        }
        else {
          for (j = 1; j < (ColumnCount + 1); j++) {
            if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
              TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
            }
          }
          if (TotalValueAddQty > 0) {
            gvDrv.rows[i].cells[ColumnCount + 1].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
          }
          else {
            gvDrv.rows[i].cells[ColumnCount + 1].getElementsByTagName("span")[0].innerHTML = '';
          }
          TotalValueAddQty = 0;
        }
      }
    }  
  </script>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" bgcolor="#fff">
      <tr>
        <td style="width: 33%; height: 25px; background-color: #405D99; color: #FFFFFF; font-size: 22px;  text-align: center; font-family: Arial;">Unit&nbsp;-&nbsp;'<asp:Label ID="lblUnit" runat="server"></asp:Label>'</td>
        <td align="center" style="width: 34%; height: 35px; background-color: #405D99; color: #FFFFFF; font-size: 22px; text-align: center; font-family: Helvetica;">Value Addition History</td>
        <td align="right" style="width: 33%; height: 35px; background-color: #405D99; padding-right: 10px;"></td>
      </tr>
      <tr>
        <td colspan="3" style="height: 10px; border:1px solid #0f0f0f; text-align:left;">
        
        <b><asp:Label ID="lbltotal" runat="server"></asp:Label> </b>
          <asp:HiddenField ID="hdnColumnCount" runat="server" />
        
        </td>
      </tr>
      <tr>
        <td colspan="3" align="center">

        
          <asp:GridView ID="gvValueAdditionHistory" runat="server" AutoGenerateColumns="false" Width="100%"
            OnRowDataBound="gvValueAdditionHistory_RowDataBound" OnRowCreated="gvValueAdditionHistory_RowCreated" OnDataBound="gvValueAdditionHistory_DataBound" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"
            RowStyle-VerticalAlign="Middle" RowStyle-Font-Names="Arial" RowStyle-Font-Size="12px" CssClass="remove-head" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="14px" HeaderStyle-BackColor="#405D99"
            HeaderStyle-ForeColor="#FFFFFF">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
               <%-- <HeaderTemplate>
                </HeaderTemplate>--%>
                <ItemTemplate>
                  <asp:Label ID="lblFromStatus_ToStatus" runat="server" Text='<%#Eval("FromStatus_ToStatus") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <%--  <HeaderTemplate>
                </HeaderTemplate>--%>
                <ItemTemplate>
                  <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <%--<HeaderTemplate>
                </HeaderTemplate>--%>
                <ItemTemplate>
                  <asp:HiddenField ID="hdnValueAdditionId" runat="server" Value='<%#Eval("ValueAdditionID") %>' />
                  <asp:Label ID="lblValueAdditionName" runat="server" Text='<%#Eval("ValueAdditionName") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
      <tr id="trMessage" runat="server" visible="false">
        <td colspan="3" align="center">
          <asp:Label ID="lblMessage" runat="server" Text="There are no Size Available for this Contrat." Visible="false" Font-Size="20px" Font-Names="Arial" ForeColor="#7E7E7E"></asp:Label>
        </td>
      </tr>
      <tr>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr>
        <td colspan="3" align="right" style="padding-right: 10px; bottom: 20px;">
          <asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>