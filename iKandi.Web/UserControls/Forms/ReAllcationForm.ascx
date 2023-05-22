<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReAllcationForm.ascx.cs"
  Inherits="iKandi.Web.UserControls.Forms.ReAllcationForm" %>
<script type="text/javascript">

  function CheckAll(cbId, elem) {
    //debugger;
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    var chk = document.getElementById(cbId).checked;
    var cbsId = cbId.substring(0, cbId.indexOf('01_CheckHeader'));
    $("input[type=checkbox]:regex(id," + cbsId + ")").each(function () {
      if (this.id != cbId) {
        $(this).attr('checked', chk);
      }
    });

    if (chk == true) {
      $(".IsEnable").attr("disabled", '')
      // $(".IsEnable").attr("disabled", true)
      $("#<%=hdnIsHeader.ClientID %>").val(0);
    }
    else {
      $(".IsEnable").attr("disabled", true);
      $("#<%=hdnIsHeader.ClientID %>").val(1);
    }
  }

  function ShowLink(elem) {
    //debugger;
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    $(elem).is(':checked')
    {
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_imgbtnAdd" + "']").show();
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_rbtnPartial" + "']").attr('checked', 'checked');
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_rbtnFull" + "']").attr('checked', false);
    }
  }

  function hideLink(elem) {
    //debugger;
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    $(elem).is(':checked')
    {
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_imgbtnAdd" + "']").hide();
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_rbtnPartial" + "']").attr('checked', false);
      $("#<%= gvReAllocation.ClientID %> input[id*='ctl" + cId + "_rbtnFull" + "']").attr('checked', 'checked');
    }
  }
</script>
<script type="text/javascript">
  function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
      return false;
    return true;
  }
</script>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript">
  function OpenShadowbox(obj) {
    var sURL = obj.href;
    Shadowbox.init({ animate: true, animateFade: true, modal: true });
    Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 225, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    $("#sb-nav-close").css({ "visibility": "hidden" });
    return false;
  }
  function OpenStitchingShadowbox(obj) {
    var sURL = obj.href;
    Shadowbox.init({ animate: true, animateFade: true, modal: true });
    Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 225, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    $("#sb-nav-close").css({ "visibility": "hidden" });
    return false;
  }
  function SBClose() { }
</script>
<style type="text/css">
  .bgheading
  {
    background-color: #405D99 !important;
    color: #ffffff;
    height: 31px;
    font-size:12px;
  }
  .isdisplay
  {
    display: none;
  }
  .item_list th table th
  {
      border:none !important;
      border-right:1px solid #fff !important;
  }
  .item_list th
  {
      padding:0px !important;
      font-weight:bold !important;    
  }
  .item_list td
  {
      padding:0px !important;
  }
  a.disable {
   pointer-events: none;
   cursor: default;
   background-color:#E3E3E3;
  }
  a.enable {
   cursor:text;
   background-color:#FFFFFF;
  }
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div id="mcontent" style="padding: 5px;">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdatePanel ID="upTargetAdmin" runat="server">
    <ContentTemplate>
      <table width="100%" cellpadding="0" border="0" cellspacing="0" style="text-transform: capitalize;">
        <tr>
          <td colspan="2" align="center" style="height: 40px; background-color: #405D99; color: #FFFFFF; font-size: 22px; font-family: Arial; text-transform: none;">Style Re-Allocation</td>
        </tr>
        <tr>
          <td colspan="2" style="height: 30px;">
          </td>
        </tr>
        <tr>
          <td width="15%" class="bgheading" style="border-bottom: 1px solid #FFFFFF; border-top: 1px solid #787878;
            border-right: 1px solid #787878;">
            <div class="tempClass" style="padding-left: 20px; font-size: 16px; font-weight: bold;
              font-family: Arial;">
              Style Number:</div>
          </td>
          <td width="220px" style="border-bottom: 1px solid #787878; border-top: 1px solid #787878;
            border-right: 1px solid #787878;">
            <div style="width: 100%; overflow: auto  ! important; padding-left: 5px; font-size: 14px;
              text-transform: uppercase;">
              <asp:Label ID="lblStyleNumber" runat="server" ForeColor="#787878" />
            </div>
          </td>
        </tr>
        <tr>
          <td class="bgheading" valign="top" style="color: White !important; height: 40px !important;
            background-repeat: repeat-x; border-top: 1px solid #FFFFFF; vertical-align: middle;
            border-bottom: 1px solid #787878; border-right: 1px solid #787878;">
            <div class="tempClass" style="padding-left: 20px; padding-top: 10px; font-size: 16px;
              font-weight: bold; font-family: Arial;">
              Remarks:</div>
          </td>
          <td valign="top" style="border-top: 1px solid #787878; border-bottom: 1px solid #787878;
            border-right: 1px solid #787878;">
            <div style="width: 99%; vertical-align: top; height: 100px; overflow: auto; padding-left: 5px;
              font-size: 14px;">
              <asp:Label ID="lblShowRemark" Style="text-transform: capitalize !important;" runat="server"
                ForeColor="#787878" />
            </div>
          </td>
        </tr>
      </table>
      <br />
      <div style="width: 100%; vertical-align: top; min-height: 400px; border: 0px solid #787878;
        text-transform: none;" align="center">
        <asp:HiddenField ID="hdnIsHeader" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
          <ContentTemplate>
            <asp:HiddenField ID="hfexFactoryDate" runat="server" />
            <asp:GridView ID="gvReAllocation" runat="server" AutoGenerateColumns="false" Width="100%"
              OnRowDataBound="gvReAllocation_rowdatabound" OnRowCommand="gvReAllocation_RowCommand"
              HeaderStyle-Height="35px" CssClass="item_list" RowStyle-ForeColor="#787878">
              <Columns>
                <asp:BoundField DataField="SerialNumber" HeaderText="Serial No." ItemStyle-Width="8%"
                  ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Line" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <asp:Label ID="lblline" runat="server" Text='<%#Eval("LinesNo") %>'></asp:Label>
                    <asp:HiddenField ID="hdnOrderDetailsId" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract No." ItemStyle-Width="8%"
                  ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Quantity">
                  <ItemTemplate> 
                    <a id="txtQuantity" runat="server" rel="shadowbox;width=600;height=225;" onclick="return OpenShadowbox(this)" style="text-decoration:none;cursor:text;">
                      <div style="width:95%; height:100%;"><%# Eval("Quantity")%></div>
                    </a>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Fabric1Detail" HeaderText="Print/Color" ItemStyle-Width="8%"
                  ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="ExFactory" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <%# Eval("ExFactoryInString")%></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DC Date" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center"
                  Visible="false">
                  <ItemTemplate>
                    <%# Eval("DCInString")%></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ModeName" HeaderText="Mode" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField Visible="true" ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                  <HeaderTemplate>
                    <asp:CheckBox ID="CheckHeader" OnClick="JavaScript:CheckAll(this.id,this);" AutoPostBack="true"
                      runat="server" OnCheckedChanged="CheckHeader_CheckedChanged" />
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:HiddenField ID="hf" runat="server" Value='<%#Bind("OrderId") %>' />
                    <asp:CheckBox ID="cb" runat="server" OnCheckedChanged="cb_CheckedChanged" AutoPostBack="true" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Partial/Full" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <asp:RadioButtonList ID="rbtnPartialFull" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                      OnSelectedIndexChanged="rbtnPartialFull_SelectedIndexChanged" Font-Size="12px"
                      ForeColor="#787878">
                      <asp:ListItem Text="Partial" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Full" Value="0" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <asp:GridView ID="gvChildReallocation" runat="server" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="gvChildReallocation_RowDataBound" Width="100%"
                      OnRowDeleting="gvChildReallocation_RowDeleting" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="12px" RowStyle-Font-Names="Arial" RowStyle-Font-Size="12px"
                      RowStyle-ForeColor="#787878">
                      <Columns>
                        <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:DropDownList ID="ddlFactory" runat="server" Width="95%" Height="100%" AutoPostBack="true"
                              OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged">
                            </asp:DropDownList>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:TextBox ID="txtStichingunallocated" runat="server" Width="95%" Height="100%"
                              Text='<%# Eval("UnAllocatedQty")%>' Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:TextBox ID="txtCutting" runat="server" Width="95%" Height="100%" Text='<%# Eval("Cutting")%>'
                              Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:TextBox ID="txtStitching" runat="server" Width="95%" Height="100%" Text='<%# Eval("Stitching")%>'
                              Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:HiddenField ID="hdnUnAlloctedQty" runat="server" Value='<%# Eval("UnAllocatedQty")%>' />
                            <asp:HiddenField ID="StitchingValueOriginal" runat="server" Value='<%# Eval("Stitching")%>' />
                            <a id="txtStitching1" runat="server" rel="shadowbox;width=700;height=225;" onclick="return OpenStitchingShadowbox(this)" visible="false" style="text-decoration:none;">
                              <div align="center" style="width:98%; height:100%; background-color:#A8D9A1;"><%# Eval("Stitching")%></div>
                            </a>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:TextBox ID="txtFinishing" runat="server" Text='<%# Eval("Finishing")%>' Width="95%"
                              Height="100%" Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:HiddenField ID="hdnReAllocation" runat="server" Value='<%# Eval("ReallocationID")%>'>
                            </asp:HiddenField>
                            <asp:HiddenField ID="hdnlineQty" runat="server" Value='<%# Eval("LineQty")%>' />
                            <asp:HiddenField ID="hdnorderdetail" runat="server" Value='<%# Eval("OrderDetailID")%>' />
                            <asp:HiddenField ID="hdnunitid" runat="server" Value='<%# Eval("UnitID")%>' />
                            <asp:HiddenField ID="hdnStitching" runat="server" Value='<%# Eval("DoneStitching")%>' />
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                          DeleteImageUrl="../../images/del-butt.png" />
                      </Columns>
                    </asp:GridView>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <asp:ImageButton ID="imgbtnAdd" runat="server" CssClass="IsEnable" CommandName="AddNew"
                      CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ImageUrl="~/images/add-butt.png" />
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div style="width: 99%; vertical-align: top; border: 0px solid #000000;" align="right">
          <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" OnClick="btnSubmit_Click" />
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</div>
