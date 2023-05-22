<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FactorySpecificLineAdmin.aspx.cs" EnableEventValidation="false" Inherits="iKandi.Web.Admin.FactorySpecificLineAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
  <script type="text/javascript">
    function SaveFloor(elem) {
      var UserId = $("#<%= hdnUserId.ClientID %>").val();
      var RowId = elem.id.replace(elem.id.split("_")[6], "");
      var UnitId = $("#" + RowId + "hdnUnitId").val();
      var LineNo = $("#" + RowId + "lblLine").text().replace("Line ", "");
      var FloorNo = $("#" + RowId + "ddlFloor").val();

      if (FloorNo > 0) {
        proxy.invoke("UpdateLineFloor", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, UserId: UserId }, function (result) {
          if (result > 1 || result > -1) {
            //debugger;
            alert('Save Successfully');
          }
        }, onPageError, false, false);
      }
      else {
        alert("Please select Floor No.");
        $("#" + RowId + "ddlFloor").value = "0";
        return false;
      }
    }

    function SaveIsClosed(elem) {
      var IsClosed;
      var UserId = $("#<%= hdnUserId.ClientID %>").val();
      var RowId = elem.id.replace(elem.id.split("_")[6], "");
      var UnitId = $("#" + RowId + "hdnUnitId").val();
      var LineNo = $("#" + RowId + "lblLine").text().replace("Line ", "");
      var FloorNo = $("#" + RowId + "ddlFloor").val();

      if ($('#' + RowId + 'rbtn input[type=radio]:checked').val() == "Yes") {
        IsClosed = true;
      }
      else {
        IsClosed = false;
      }
      if (FloorNo > 0) {
        proxy.invoke("UpdateLineIsClosed", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, IsClosed: IsClosed, UserId: UserId }, function (result) {
          if (result > 1 || result > -1) {
            //debugger;
            alert('Save Successfully');
          }
        }, onPageError, false, false);
      }
      else {
        alert("Please select Floor No.");
        return false;
      }
    } 

    function SaveFactoryLine(elem) {
      //debugger;
      var UserId = $("#<%= hdnUserId.ClientID %>").val();
      var RowId = elem.id.replace(elem.id.split("_")[6], "");
      var str = RowId;
      var LineDesignationId = str.substring(str.length - 1, str.length);
      RowId = str.substring(0, str.length - 2);

      var UnitId = $("#" + RowId + "hdnUnitId").val();
      var LineNo = $("#" + RowId + "lblLine").text().replace("Line ", "");
      var FloorNo = $("#" + RowId + "ddlFloor").val();
      var DesignationName = $("#" + RowId + "ddl_" + LineDesignationId).val();

      if (FloorNo > 0) {
        proxy.invoke("UpdateLineStatusDesignation", { UnitId: UnitId, LineNoId: LineNo, LineDesignationId: LineDesignationId, DesignationName: DesignationName, UserId: UserId }, function (result) {
          if (result > 1 || result > -1) {
            //debugger;
            alert('Save Successfully');
          }
        }, onPageError, false, false);
      }
      else {
        alert("Please select Floor No.");
        $("#" + RowId + "ddl_" + LineDesignationId).val("Select");
        return false;
      }
    }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
  <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
  <asp:updatepanel ID="Updatepanel1" UpdateMode="Always" runat="server">
    <ContentTemplate>
  <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="text-transform:none !important;">
    <tr>
      <td align="center" style="padding-left: 25px; height: 40px; background-color: #405D99; color: #FFFFFF;">
        <span style="font-weight: bold; font-size:16px;">Line Status</span>
        <asp:HiddenField ID="hdnUserId" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="left" style="padding-top:15px; padding-left:15px;">
        <asp:DropDownList ID="ddlFactorySearch" runat="server" AutoPostBack="true" Width="75px" Height="25px" Font-Size="15px" OnSelectedIndexChanged="ddlFactorySearch_SelectedIndexChanged"></asp:DropDownList>
        <asp:HiddenField ID="hdnTableCount" runat="server" />
        <asp:HiddenField ID="hdnIdCount" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" style="padding-top:15px;">
        <asp:GridView ID="gvLineStatus" runat="server"  AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" Width="100%"
          HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="35px"
          RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvLineStatus_RowDataBound">
          <Columns>
            <asp:TemplateField HeaderText="Factory Name" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("UnitName") %>'></asp:Label>
                <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line_No") %>' Font-Bold="true"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Floor No" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:DropDownList ID="ddlFloor" runat="server" Width="60px" onchange="SaveFloor(this)"></asp:DropDownList>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  </ContentTemplate>
  </asp:updatepanel>
</asp:Content>
