<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllocatedWithFactory.aspx.cs"
  Inherits="iKandi.Web.Internal.Merchandising.AllocatedWithFactory" %>

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
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <div id="frmHed" style="padding: 5px 0px; background-color: #405D99; color: #FFFFFF; font-size: 22px; font-family: Arial; text-transform: none; text-align: center">Reshuffle Not Loaded Quantity</div>
  <div style=" padding-top:10px; padding-left:5px; padding-bottom:10px; color:#405D99; font-size:14px; font-family:Arial; font-weight:bold; text-align:left;">Total Quantity: <asp:Label ID="lblTotalQty" runat="server" ForeColor="#787878"></asp:Label></div>
  <div style="width: 100%; vertical-align: top; border: 0px solid #787878; text-transform: none;" align="center">
    <asp:HiddenField ID="hdnIsHeader" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <asp:HiddenField ID="hfexFactoryDate" runat="server" />
        <asp:GridView ID="gvReAllocation" runat="server" AutoGenerateColumns="false" Width="98%" HeaderStyle-Height="35px" CssClass="item_list"
           OnRowDataBound="gvReAllocation_RowDataBound" ShowFooter="true">
          <Columns>
            <asp:TemplateField>
              <FooterStyle HorizontalAlign="Right" />
              <FooterTemplate>
                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="../../images/add-butt.png" OnClick="btnAdd_Click" />
              </FooterTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Factory" HeaderText="Unit" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center" />--%>
            <asp:TemplateField HeaderText="Factory" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:DropDownList ID="ddlFactory" runat="server" Width="95%" Height="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged"></asp:DropDownList>
              </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="UnAllocatedQty" HeaderText="Not Loaded Qty" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />--%>
            <asp:TemplateField HeaderText="Not Loaded Qty" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Label ID="lblUnAllocatedQty" runat="server" Text='<%# string.Format("{0:#,#0}",Eval("UnAllocatedQty")) %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line Qty" ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Label ID="lblLineQty" runat="server" Text='<%# string.Format("{0:#,#0}",Eval("LineQty")) %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reshuffle Not Loaded Qty" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:TextBox ID="txtUnAllocated" runat="server" Text='<%# string.Format("{0:#,#0}",Eval("UnAllocatedQty")) %>' MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>
                <asp:HiddenField ID="hdnUnit" runat="server" Value='<%#Eval("UnitID") %>' />
                <asp:HiddenField ID="hdnReallocationID" runat="server" Value='<%#Eval("ReallocationID") %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </ContentTemplate>
    </asp:UpdatePanel>
    <div style="width: 98%; height:15px; padding-top:5px; padding-bottom:5px; vertical-align: top; border: 0px solid #000000;" align="right">
      <asp:Label ID="lblnm" runat="server" ForeColor="Red" Font-Names="Arial" Font-Size="12px"></asp:Label>
    </div>
    <div style="width: 98%; vertical-align: top; border: 0px solid #000000;" align="right">
      <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" OnClick="btnSubmit_Click" />
      <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>
  </div>
  </form>
</body>
</html>
