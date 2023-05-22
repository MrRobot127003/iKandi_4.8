<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemainCuttingQty.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.RemainCuttingQty" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script type="text/javascript">
    function isNumberKey(evt) {
      var charCode = (evt.which) ? evt.which : event.keyCode
      if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

      return true;
    }

  </script>
  <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
    .item_list th
    {
      font-weight: bold;
    }
    .item_list td
    {
      font-size: 12px;
      font-family: Arial;
    }
  </style>
</head>
<body bgcolor="#FFFFFF">
  <form id="form1" runat="server">
  <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <div id="frmHed" style="padding: 5px 0px; background-color: #405D99; color: #FFFFFF;
    font-size: 22px; font-family: Arial; text-transform: none; text-align: center">Reshuffle Remain Cutting Quantity</div>
  <br />
  <div style="width: 100%; vertical-align: top; border: 0px solid #787878; text-transform: none;" align="center">
    <asp:HiddenField ID="hdnIsHeader" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <asp:HiddenField ID="hfexFactoryDate" runat="server" />
        <asp:GridView ID="gvReAllocation" runat="server" AutoGenerateColumns="false" Width="98%" HeaderStyle-Height="35px" OnRowDataBound="gvReAllocation_RowDataBound" CssClass="item_list">
          <Columns>
            <asp:BoundField DataField="Factory" HeaderText="Unit" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Unit Qty" ItemStyle-Width="20%">
              <ItemTemplate>
                <asp:HiddenField ID="hdnTotalUnAssignCutQty" runat="server" Value='<%#Eval("TotalUnAssignCutQty") %>' />
                
                <asp:Label ID="lblUnitQty" runat="server" Text='<%#string.Format("{0:#,#0}", Eval("CuttingShare")) %>' Visible="True"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cut Qty" ItemStyle-Width="20%">
              <ItemTemplate>
                <asp:TextBox ID="txtCutQty" runat="server" Text='<%# string.Format("{0:#,#0}",Eval("CutQty")) %>' ReadOnly="true" Visible="True"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remain Cut Qty" ItemStyle-Width="20%">
              <ItemTemplate>
                <asp:TextBox ID="txtRemainCutQty" runat="server" Text='<%#string.Format("{0:#,#0}",Eval("RemainCutQty")) %>' ReadOnly="true" Visible="True"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reshuffle(+)" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:TextBox ID="txtreshflueplus" onkeypress="return isNumberKey(event)" runat="server" MaxLength="5"
                  Text="0"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reshuffle(-)" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:TextBox ID="txtreshflueminus" onkeypress="return isNumberKey(event)" runat="server" MaxLength="5"
                  Text="0"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </ContentTemplate>
    </asp:UpdatePanel>
    <div style="width: 98%; height: 15px; padding-top: 5px; padding-bottom: 5px; vertical-align: top;
      border: 0px solid #000000;" align="right">
      <asp:Label ID="lblnm" runat="server" ForeColor="Red" Font-Names="Arial" Font-Size="12px"></asp:Label>
    </div>
    <div style="width: 98%; vertical-align: top; border: 0px solid #000000;" align="right">
      <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" OnClick="btnSubmit_Click" />
      <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button"  Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>
  </div>
  </form>
</body>
</html>
