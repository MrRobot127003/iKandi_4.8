<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOPermissionFormNew.ascx.cs"
  Inherits="iKandi.Web.UserControls.Forms.MOPermissionFormNew" %>
<script type="text/javascript">
  function checkboxReadCheckedAll(elem) {
    //debugger; //HW1Manager
    var chk = elem.id;
    var ctId = elem.id.split('_')[6].substr(2); ;
    var chkid = elem.id.split('_')[7];
    var DeptId = elem.id.split('_')[8];
    var Name = elem.id.split('_')[9];
    var Chkid = elem.id.split('_')[10];
    //        alert(DeptId);
    var isSave = 0;
    var ids = "";
    var SectionId = 0;
    var ColumnId = 0;
    var PermissionRead = $(elem).is(':checked');
    var rowcount = $("#<%=grdPermission.ClientID %> tr").length;
    var checkIsSave = $(elem).is(':checked');

    var CheckConfirm = confirm("Do You Want To save Permission.");
    if (CheckConfirm == true) {
      for (var i = 3; i <= rowcount; i++) {
        if (i < 10) {
            SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
            ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
        }
        else {
            SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
            ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
        }
        var NoPermission = $('.R' + DeptId + Name + ColumnId).find("input[type=checkbox]").attr('disabled') ? true : false;
        if (!NoPermission) {
          proxy.invoke("SavePermissionByIds", { DeptId: DeptId, DesigId: Name, SectionId: SectionId, ColumnId: ColumnId, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {
          }, onPageError, false, false);
          if ($(elem).is(':checked')) {
              $('.R' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", true);
            $('.W' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", false);
          }
          else {
              $('.R' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", false);
          }
        }
      }
      alert('Permission saved successfully!');
      //debugger; 
      if ($(elem).is(':checked')) {
        //$('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', 'checked');
        //$('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
        $('.ddl' + DeptId + Name).attr("disabled", true);
      }
      else {
        // $('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
        $('HW' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
        $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
        //$('.ddl' + DeptId + Name).find("input[type=select]").attr("disabled", true);
        $('.ddl' + DeptId + Name).attr("disabled", true);
      }
    }
    else {

      if (checkIsSave == true) {
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
      }
    else {
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", true);
      }

    }
  }


  function checkboxWriteCheckedAll(elem) {
    //debugger;
    var chk = elem.id;
    var ctId = elem.id.split('_')[6].substr(2);
    var chkid = elem.id.split('_')[7];
    var DeptId = elem.id.split('_')[8];
    var Name = elem.id.split('_')[9];
    var Chkid = elem.id.split('_')[10];

    var ids = "";
    var SectionId = 0;
    var ColumnId = 0;
    var PermissionWrite = $(elem).is(':checked');
    var rowcount = $("#<%=grdPermission.ClientID %> tr").length;
    var checkIsSave = $(elem).is(':checked');

    var CheckConfirm = confirm("Do You Want To save Permission.");
    if (CheckConfirm == true) {
      for (var i = 3; i <= rowcount; i++) {
        if (i < 10) {

            SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
            ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
        }
        else {

            SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
            ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
        }
        var NoPermission = $('.W' + DeptId + Name + ColumnId).find("input[type=checkbox]").attr('disabled') ? true : false;
        if (!NoPermission) {
          proxy.invoke("SavePermissionByIds", { DeptId: DeptId, DesigId: Name, SectionId: SectionId, ColumnId: ColumnId, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {
          }, onPageError, false, false);
          if ($(elem).is(':checked')) {
              $('.W' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", true);
            $('.R' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", false);
          }
          else {
              $('.W' + DeptId + Name + ColumnId).find("input[type=checkbox]").prop("checked", false);
          }
        }
      }
      alert('Permission saved successfully!');
      if ($(elem).is(':checked')) {
        // debugger
        //$('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', 'checked');
        //$('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
        $('.ddl' + DeptId + Name).attr("disabled", false);
      }
      else {
        //debugger
        //$('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
        $('HR' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
        $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
        $('.ddl' + DeptId + Name).attr("disabled", false);
      }
    }
    else {
      // $('HW' + DeptId + Name).find("input[type=checkbox]").attr('checked', checkIsSave);

      if (checkIsSave == true) {
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", false);
      }
    else {
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").prop("checked", true);
      }
    }
  }

  function checkboxReadChecked(elem) {
    //debugger; //HW1Manager
    var chk = elem.id;
    var ctId = elem.id.split('_')[6].substr(2); ;
    var DeptId = elem.id.split('_')[7].substr(4);
    var DesigId = elem.id.split('_')[8];
    var Name = elem.id.split('_')[9];
    var Chkid = elem.id.split('_')[10];
    DesigId = parseInt(DesigId);
    DeptId = parseInt(DeptId);
    var SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
    var ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());
    var PermissionRead = $(elem).is(':checked');
    // debugger;
    var checkIsSave = $(elem).is(':checked');

    var CheckConfirm = confirm("Do You Want To save Permission.");
    if (CheckConfirm == true) {
      proxy.invoke("SavePermissionByIds", { DeptId: DeptId, DesigId: DesigId, SectionId: SectionId, ColumnId: ColumnId, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {

        alert('Permission saved successfully!');
      }, onPageError, false, false);

      if ($(elem).is(':checked')) {

          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "chkW" + DeptId + "_" + DesigId + "_" + Name + "']").prop("checked", false);
        // var va = $(elem).closest("tr").find("select").val();
        $(elem).closest("td").find("select").attr("disabled", true);
      }
    }
    else {

      if (checkIsSave == true) {
          $(elem).prop("checked", false);
      }
    else {
          $(elem).prop("checked", true);
      }
    }
  }

  function checkboxWriteChecked(elem) {
    //debugger; //HW1Manager
    var chk = elem.id;
    var ctId = elem.id.split('_')[6].substr(2); ;
    var DeptId = elem.id.split('_')[7].substr(4);
    var DesigId = elem.id.split('_')[8];
    var Name = elem.id.split('_')[9];
    var Chkid = elem.id.split('_')[10];
    DesigId = parseInt(DesigId);
    DeptId = parseInt(DeptId);
    var SectionId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
    var ColumnId = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());
    var PermissionWrite = $(elem).is(':checked');
    //debugger;
    var checkIsSave = $(elem).is(':checked');

    var CheckConfirm = confirm("Do You Want To save Permission.");
    if (CheckConfirm == true) {
      proxy.invoke("SavePermissionByIds", { DeptId: DeptId, DesigId: DesigId, SectionId: SectionId, ColumnId: ColumnId, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {

        alert('Permission saved successfully!');
      }, onPageError, false, false);

      if ($(elem).is(':checked')) {
        //debugger
          $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "chkR" + DeptId + "_" + DesigId + "_" + Name + "']").prop("checked", false);
        $(elem).closest("td").find("select").attr("disabled", false);

      }
    }
    else {

      if (checkIsSave == true) {
          $(elem).prop("checked", false);
      }
      else {
          $(elem).prop("checked", true);
      }
    }
  }

  function SelectFilterOption(elem, Flag) {
    //HW1Manager
    var chk = elem.id;
    var ctId = elem.id.split('_')[6].substr(2); ;
    var DeptId = elem.id.split('_')[8];
    var DesigId = elem.id.split('_')[9];
    DesigId = parseInt(DesigId);
    DeptId = parseInt(DeptId);

    var OrderBy = parseInt(elem.value);

    proxy.invoke("SaveMO_OrderByFilter", { DeptId: DeptId, DesigId: DesigId, OrderBy: OrderBy, Flag: Flag }, function (result) {

      alert('Permission saved successfully!');
      //jQuery.facebox('Permission saved successfully H!');
    }, onPageError, false, false);

  }


</script>
<style type="text/css">
  .bgimg
  {
    background: #dddfe4 !important;
border: 1px solid #b7b4b4 !important;
    width: 100%;
    height: 37px;
    
    text-transform: capitalize !important;
  }
  
  td
  {
    text-transform: capitalize !important;
    text-align: center;
  }
  .fontbold
  {
    font-weight: normal;
  }
  .txtalign
  {
    text-align: left;
    height: 21px;
  }
  
  hiddenControl
  {
    visibility: hidden;
  }
  
  .hasborder
  {
    border: 1px solid #FFFFFF;
  }
  .thgrid1
  {
    height: 50px;
  }
  .thgrid1
  {
    height: 35px;
    overflow: hidden;
  }
  .thgrid1 span
  {
    height: 1px !important;
    overflow: hidden;
    white-space: nowrap;
  }
  .bgimg
  {
    width: 110px !important;
  }
  span
  {
    text-transform: capitalize;
  }
  .grid-first td
  {
    padding: 1.9px 0px;
  }
  th
  {
    line-height: 15px;
  }
  #ctl00_cph_main_content_MOPermission_grdPermissionHeaderCopy td
  {
      height:24px;
   }
</style>
<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>    
<script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
<link href="../../css/GridviewScroll.css" rel="stylesheet" type="text/css" />
 <link href="../../css/report.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript">
         $(document).ready(function () {
             gridviewScroll();
         });

         function gridviewScroll() {
             var gridWidth = $(window).width() - 50;
             var gridHeight = $(window).height() - 80;

             $('#<%=grdPermission.ClientID%>').gridviewScroll({
                 width: gridWidth,
                 height: gridHeight,
                 arrowsize: 30,
                 varrowtopimg: "../../images/arrowvt.png",
                 varrowbottomimg: "../../images/arrowvb.png",
                 harrowleftimg: "../../images/arrowhl.png",
                 harrowrightimg: "../../images/arrowhr.png",
                 freezesize: 2,
                 headerrowcount: 2
             });
         }
    </script>





  <asp:GridView ID="grdPermission" runat="server" CssClass="AddClass_Table" AutoGenerateColumns="false" OnRowCreated="grdPermission_RowCreated1" OnRowDataBound="grdPermission_RowDataBound">
            <Columns>
              <asp:TemplateField HeaderText="" HeaderStyle-Width="150px">
                <ItemTemplate>
                  <asp:Label ID="lblSection" runat="server" Text='<%#Eval("Section")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="txtalign" Width="150px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="" HeaderStyle-Width="250px">
                <ItemTemplate>
                  <asp:Label ID="lblField" runat="server" Text='<%#Eval("Field")%>'></asp:Label>
                  <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("MOSectionID")%>' />
                  <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("MOCoulmeID")%>' />
                </ItemTemplate>
                <ItemStyle CssClass="txtalign"  Width="250px" />
              </asp:TemplateField>
            </Columns>
          </asp:GridView>


<%--  <table width="100%" cellpadding="0" cellspacing="0">
    <tr>
      <td valign="top" align="left" style="width: 375px; display:none;">
        <div style="width: 375px;">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="30px" OnRowCreated="GridView1_RowCreated1" OnRowDataBound="GridView1_RowDataBound" Width="100%">
            <Columns>
              <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thgrid1">
                <ItemTemplate>
                  <asp:Label ID="lblSection" Width="170" runat="server" Text='<%#Eval("Section")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="txtalign" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thgrid1">
                <ItemTemplate>
                  <asp:Label ID="lblField" Width="170" runat="server" Text='<%#Eval("Field")%>'></asp:Label>
                  <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("MOSectionID")%>' />
                  <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("MOCoulmeID")%>' />
                </ItemTemplate>
                <ItemStyle CssClass="txtalign" />
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </td>
      <td valign="top" align="left">
        
        
        
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
  </table>
--%>
