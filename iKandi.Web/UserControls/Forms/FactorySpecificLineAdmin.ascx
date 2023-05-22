<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactorySpecificLineAdmin.ascx.cs"
  Inherits="iKandi.Web.UserControls.Forms.FactorySpecificLineAdmin" %>
<script type="text/javascript">
  function BindDropDown(elem) {
    //debugger;
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(2);
    var LastId = Ids.split("_")[6].substr(3);

    //var FactoryId = $(".Factory").val();
    var FactoryId = elem.options[elem.selectedIndex].value;

    var TCount = $("#<%= hdnTableCount.ClientID %>").val();

    var row = elem.parentNode.parentNode;
    var rowIndex = row.rowIndex - 1;

    var array = $("#<%= hdnIdCount.ClientID %>").val().split(",");
    var strId = $("#<%= hdnIdCount.ClientID %>").val();

    if (CheckFactoryUnit(elem) == false) {
      //alert("Line Count per factory is already define you cann't incresed from hear")
      //$(".btnFactory").click();
      return false;
    }

    $('.DesigName' + rowIndex).empty();
    $('.DesigName' + rowIndex).append($("<option></option>").val(-1).html("SELECT"));
    var FactoryId = FactoryId;
    proxy.invoke("GetDesignationnames", { FactoryId: FactoryId, strId: strId }, function (result) {
      $.each(result, function (key, value) {
        for (var i = 0; i < array.length; i++) {
          //debugger;
          if (value.DesignationId == array[i]) {
            $('.DesigName' + rowIndex + "_" + array[i]).append($("<option></option>").val(value.Id).html(value.Name));
          }
        }
      });
    });

    $('.Floor' + rowIndex).empty();
    var FactoryId = FactoryId;
    proxy.invoke("GetFloorNames", { FactoryId: FactoryId }, function (result) {
      $.each(result, function (key, value) {
        $('.Floor' + rowIndex).append($("<option></option>").val(value.Id).html(value.Name));
      });
    });

    $('.Line' + rowIndex).empty();
    var FactoryId = FactoryId;
    proxy.invoke("GetLineNames", { FactoryId: FactoryId }, function (result) {
      $.each(result, function (key, value) {
        //debugger;
        $('.Line' + rowIndex).append($("<option></option>").val(value.Id).html(value.Name));
      });
    });
  }

  function SaveFactoryLine(elem) {
    //debugger;
    var Ids = elem.id;

    var cId = Ids.split("_")[6].substr(3);
    var desigId = Ids.split("_")[8];
    var row = elem.parentNode.parentNode;
    var rowIndex = row.rowIndex - 1;

    var Id = $("#<%= grdLine.ClientID %> input[id$='" + cId + "_hdnFactoryLineId']").val();
    var FactoryUnitId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFactory']").val();
    var FloorId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFloor']").val();
    var LineId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlLine']").val();

    var DesignationName = elem.options[elem.selectedIndex].text;
    var designationId = desigId;
    if (Id == "") {
      Id = 0;
    }

    if (validation(cId) == false) {

      elem.value = "-1";
      return false;
    }
    else {
      proxy.invoke("InsertFactoryLine", { Id: Id, FactoryUnitId: FactoryUnitId, FloorId: FloorId, LineId: LineId, DesignationName: DesignationName, designationId: designationId }, function (result) {
        if (result) {
          //debugger;
          alert('Save Successfully');
          $(".btnFactory").click();
        }
      }, onPageError, false, false);
    }
  }

  function SaveLineAndFloor(elem) {
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    var desigId = Ids.split("_")[8];
    var Id = $("#<%= grdLine.ClientID %> input[id$='" + cId + "_hdnFactoryLineId']").val();
    var FactoryUnitId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFactory']").val();
    var FloorId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFloor']").val();
    var LineId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlLine']").val();

    if (Id == "") {
      Id = 0;
    }

    if (FactoryUnitId == 0 || FactoryUnitId == -1) {
      alert('Please Select Factory Unit');
      return false;
    }

    proxy.invoke("InsertLine", { Id: Id, FactoryUnitId: FactoryUnitId, FloorId: FloorId, LineId: LineId }, function (result) {
      if (result == -1) {
        alert("Same Line Cann't Associated multiple times with same Factory ");
        $(".btnFactory").click();
      }
      else {
        alert('Save Successfully');
        $(".btnFactory").click();
      }
    }, onPageError, false, false);
  }

  function SaveIsClosed(elem) {
     // alert(elem);
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    var LastId = Ids.split("_")[8];
    //debugger;
    var isClose;
    var Id = $("#<%= grdLine.ClientID %> input[id$='" + cId + "_hdnFactoryLineId']").val();
    var IsAct = $("#<%= grdLine.ClientID %> input[id*='ctl" + cId + "_rbtn_" + LastId + "']");

    var radio = IsAct;

    for (var i = 0; i < radio.length; i++) {
      if (radio[i].checked) {
        isClose = radio[i].value;
      }
    }

    if (validation(cId) == false) {

      elem.value = "-1";
      return false;
    }
    else {
      proxy.invoke("FactoryisClosed", { Id: Id, isClose: isClose }, function (result) {
        if (result > 1 || result > -1) {
         // debugger;
          alert('Save Successfully');
          // $(".btnFactory").click();
        } else {
          alert("Please select factory Unit")
          return;
        }
      }, onPageError, false, false);
    }
  }

  function validation(cId) {
    var FactoryUnitId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFactory']").val();
    var FloorId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFloor']").val();
    var LineId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlLine']").val();

    if (FactoryUnitId == 0 || FactoryUnitId == -1) {
      alert('Please Select Factory Unit');
      return false;
    }
    if (FloorId == 0 || FloorId == -1) {
      alert('Please Select Floor');
      return false;
    }
    if (LineId == 0 || LineId == -1) {
      alert('Please Select Line');
      return false;
    }
  }

  function CheckFactoryUnit(elem) {
    var Ids = elem.id;
    var cId = Ids.split("_")[6].substr(3);
    var desigId = Ids.split("_")[8];

    var FactoryUnitId = $("#<%= grdLine.ClientID %> select[id$='" + cId + "_ddlFactory']").val();
    //alert(1);
    proxy.invoke("CheckFacrotyUnit", { FactoryUnitId: FactoryUnitId }, function (result) {
      if (result.length > 0) {

        if (result[0].Unit1 == result[0].Unit2) {
          alert("Factory has already predefine count which is" + " " + result[0].Unit1)
          $(".btnFactory").click();
          return false;
        }
      }
    }, onPageError, false, false);
  }
</script>

<style type="text/css">
.head-back
{
    color: #ffffff !important; 
    font-family:Verdana,Arial,sans-serif; 
    font-size:14px;   
    background-color:#39589c;  
    text-transform: capitalize !important; 
   
    text-align:center; 
    padding: 4px; 
    font-weight:bold;
}
.head-back th
{
    color: #ffffff !important; 
    font-family:Verdana,Arial,sans-serif !important; 
    font-size:12px;   
    background-color:#39589c;  
    text-transform: capitalize !important; 
   
    text-align:center; 
    padding: 10px; 
    font-weight:bold;
}
select
{
    width:90%;
    font-size:12px;
    font-family:Verdana,Arial,sans-serif !important;
}
.choose-dept
{
    width:100px !important;
    font-size:12px;
    font-family:Verdana,Arial,sans-serif !important;
}
</style>
<div>
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <div>
    <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="0">
          <tr><td class="head-back"><asp:Label ID="lblHeading" runat="server" Text="Factory Specific Line Admin"></asp:Label></td></tr>
          <tr>
            <td>
              <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="true" CssClass="choose-dept" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"></asp:DropDownList>
              <asp:HiddenField ID="hdnTableCount" runat="server" />
              <asp:HiddenField ID="hdnIdCount" runat="server" />
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblIsRecordFound" runat="server" Visible="false" Text="Record Not Found"></asp:Label>
              <div id="divgrd" runat="server">
                <%-- <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">         
                <ContentTemplate>--%>
                <asp:Button ID="btnFactory" CssClass="btnFactory" Style="display: none;" runat="server" Text="Button" OnClick="btnFactory_Click" />
                <asp:GridView ID="grdLine" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grdLine_RowDataBound" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                  <Columns>
                    <asp:TemplateField HeaderText="Factory Name">
                      <ItemTemplate>
                        <asp:DropDownList ID="ddlFactory" runat="server" AutoPostBack="false" CssClass="Factory" onchange="BindDropDown(this)" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged"></asp:DropDownList>
                        <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
                        <asp:HiddenField ID="hdnFactoryLineId" runat="server" Value='<%#Eval("id") %>' />
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Floor No">
                      <ItemTemplate>
                        <asp:DropDownList ID="ddlFloor" runat="server" onchange="SaveLineAndFloor(this)"></asp:DropDownList>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Line">
                      <ItemTemplate>
                        <asp:DropDownList ID="ddlLine" runat="server" onchange="SaveLineAndFloor(this)"></asp:DropDownList>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
              </div>
            </td>
          </tr>
          <tr><td align="right"><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td></tr>
        </table>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</div>
