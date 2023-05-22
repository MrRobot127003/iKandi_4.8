<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OBPermission_New.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.OBPermission_New" %>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script type="text/javascript">

    function checkboxReadCheckedAll(elem) {
         debugger;
        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var chkid = elem.id.split('_')[7];
        var DeptId = elem.id.split('_')[8];
        var Name = elem.id.split('_')[9];
        var Chkid = elem.id.split('_')[10];
        //        alert(DeptId);
        var isSave = 0;
        var ids = "";
        var FormsID = 0;
        var SectionID = 0;
        var PermissionRead = $(elem).is(':checked');
        var rowcount = $("#<%=grdPermission.ClientID %> tr").length;
        var checkIsSave = $(elem).is(':checked');
        //alert(rowcount);
        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            for (var i = 3; i <= rowcount; i++) {
                if (i < 10) {
                    FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
                }
                else {
                    FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
                }
                var NoPermission = $('.R' + DeptId + Name + SectionID).find("input[type=checkbox]").attr('disabled') ? true : false;
                if (!NoPermission) {
                    proxy.invoke("SaveOBPermissionNew", { DeptId: DeptId, DesigId: Name, FormsID: FormsID, SectionID: SectionID, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {
                    }, onPageError, false, false);
                    if ($(elem).is(':checked')) {
                        $('.R' + DeptId + Name + SectionID).find("input").prop("checked", true);
                        $('.W' + DeptId + Name + SectionID).find("input").prop("checked", false);
                    }
                    else {
                        //debugger
                        $('.R' + DeptId + Name + SectionID).find("input").prop("checked", false);
                    }
                }
            }
            alert('Permission saved successfully!');
            debugger; 
            if ($(elem).is(':checked')) {

                $("input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);

            }
            else {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);
            }
        }
        else {

            if (checkIsSave == true) {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);
            }
            else {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", true);
            }

        }
    }


    function checkboxWriteCheckedAll(elem) {
        debugger;
        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var chkid = elem.id.split('_')[7];
        var DeptId = elem.id.split('_')[8];
        var Name = elem.id.split('_')[9];
        var Chkid = elem.id.split('_')[10];

        var ids = "";
        var FormsID = 0;
        var SectionID = 0;
        var PermissionWrite = $(elem).is(':checked');
        var rowcount = $("#<%=grdPermission.ClientID %> tr").length;
        var checkIsSave = $(elem).is(':checked');

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            for (var i = 3; i <= rowcount; i++) {
                if (i < 10) {

                    FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
                }
                else {

                    FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
                }
                var NoPermission = $('.W' + DeptId + Name + SectionID).find("input[type=checkbox]").attr('disabled') ? true : false;
                if (!NoPermission) {
                    proxy.invoke("SaveOBPermissionNew", { DeptId: DeptId, DesigId: Name, FormsID: FormsID, SectionID: SectionID, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {

                    }, onPageError, false, false);
                    if ($(elem).is(':checked')) {
                        // debugger                       
                        $('.W' + DeptId + Name + SectionID).find("input[type=checkbox]").prop("checked", true);
                        $('.R' + DeptId + Name + SectionID).find("input[type=checkbox]").prop("checked", false);
                    }
                    else {
                        //debugger
                        $('.W' + DeptId + Name + SectionID).find("input[type=checkbox]").prop("checked", false);
                    }
                }
            }
            alert('Permission saved successfully!');


            if ($(elem).is(':checked')) {
                // debugger
                //$('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', 'checked');
                //$('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);

            }
            else {
                //debugger
                //$('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $('HR' + DeptId + Name).find("input[type=checkbox]").prop('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);

            }
        }
        else {
            // $('HW' + DeptId + Name).find("input[type=checkbox]").attr('checked', checkIsSave);

            if (checkIsSave == true) {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", false);
            }
            else {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "_Copy']").prop("checked", true);
            }
        }
    }

    function checkboxReadChecked(elem) {
        debugger; //HW1Manager
        alert("tet");
        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2); ;
        var DeptId = elem.id.split('_')[7].substr(4);
        var DesigId = elem.id.split('_')[8];
        var Name = elem.id.split('_')[9];
        var Chkid = elem.id.split('_')[10];
        DesigId = parseInt(DesigId);
        DeptId = parseInt(DeptId);
        var FormsID = 0;
        var SectionID = 0;
        FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
        SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());
        var PermissionRead = $(elem).is(':checked');
        // debugger;
        var checkIsSave = $(elem).is(':checked');

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            proxy.invoke("SaveOBPermissionNew", { DeptId: DeptId, DesigId: DesigId, FormsID: FormsID, SectionID: SectionID, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {


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
        debugger; //HW1Manager
        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2); ;
        var DeptId = elem.id.split('_')[7].substr(4);
        var DesigId = elem.id.split('_')[8];
        var Name = elem.id.split('_')[9];
        var Chkid = elem.id.split('_')[10];
        DesigId = parseInt(DesigId);
        DeptId = parseInt(DeptId);
        var FormsID = 0;
        var SectionID = 0;
        FormsID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
        SectionID = parseInt($("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());

        var PermissionWrite = $(elem).is(':checked');
        //debugger;
        var checkIsSave = $(elem).is(':checked');

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            proxy.invoke("SaveOBPermissionNew", { DeptId: DeptId, DesigId: DesigId, FormsID: FormsID, SectionID: SectionID, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {

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
        debugger; //HW1Manager
        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2); ;
        var DeptId = elem.id.split('_')[8];
        var DesigId = elem.id.split('_')[9];
        DesigId = parseInt(DesigId);
        DeptId = parseInt(DeptId);

        var Column = parseInt(elem.value);



    }


</script>
<style type="text/css">
    .bgimg
    {
        background: #dddfe4 !important;
        border: 1px solid #b7b4b4 !important;
        padding: 10px 0px;
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
    }
    
    hiddenControl
    {
        visibility: hidden;
    }
    
    .hasborder
    {
        border: 1px solid #FFFFFF;
    }
    /*-----------------Add By Prabhaker-----------------------*/
    /* .thgrid1
    {
        height: 50px;
    }
    .thgrid1
    {
        height: 34px;
        overflow: hidden;
    }
    .thgrid1 span
    {
        height: 1px !important;
        overflow: hidden;
        white-space: nowrap;
    }*/
    /* .bgimg
    {
        width: 110px !important;
    }*/
    span
    {
        text-transform: capitalize;
    }
    /* .grid-first td
    {
        padding:1.425px 0px; 
        height: 40px;
    }
    /* .grid-second td
    {
         padding:1.425px 0px; 
        height: 40px;
    }*/
    th
    {
        line-height: 15px;
    }
    
    /*---
     .grid-first tr:first-child
    
    {
        position:fixed;
    }
    .grid-first tr:second-child
    
    {
        position:fixed;
    }
    .grid-first tr:third-child
    
    {
        position:fixed;
    }
     .grid-second tr:first-child
    
    {
        position:fixed;
    }
    .grid-second tr:second-child
    
    {
        position:fixed;
    }
    .grid-second tr:third-child
    
    {
        position:fixed;
    }
    
-----------------Add By Prabhaker-----------------------*/
    /* .wrapper1
    {
        height: 600px;
        width: 100%;
        overflow-x: scroll;
        overflow-y: hidden;
    }
    .wrapper2
    {
        height: 600px;
        overflow-x: scroll;
        overflow-y: scroll;
    }
    .div1
    {
        height: auto;
        margin-bottom: 20px;
    }*/
    .div2
    {
        width: 100%;
        height: auto;
        margin-bottom: 20px;
    }
    .grid-first
    {
        max-height: 600px;
    }
    .grid-second
    {
        max-height: 600px;
    }
    /*    .grid-first tr:nth-child(2) {display : none;}
    .grid-second tr:nth-child(2) {display : none;}*/
    
    
    /*-----------------End of Add by abhishek-----------------------*/
</style>
<script type="text/javascript">

    //    abhishek 29/6/2016
    $(document).ready(function () {
        $("#<%=ddlfilterforms.ClientID%>").change(function () {
            //debugger;
            window.location = '/Admin/Permission/OBPermissionFormNew.aspx?search=' + escape($("#<%=ddlfilterforms.ClientID%>").val());

        });
    });
</script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
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
<style type="text/css">
    .ddlss
    {
        border: 1px solid #090909;
        border-radius: 5px;
        padding: 3px;
        -webkit-appearance: none;
        background-image: url('../../images/arrowvb.png');
        background-position: 200px;
        background-repeat: no-repeat;
        text-indent: 0.01px; /*In Firefox*/
        text-overflow: ''; /*In Firefox*/
        font-weight: bold;
        text-transform: capitalize;
    }
    .txtWidth
    {
        min-width: 301px;
        max-width: 301px;
        word-break: break-all;
    }
    input[type="checkbox"]
    {
        position:relative;
        top:3px;
     }
       .header-text-back
     {
         font-size: 15px;
        text-align: center;
        color: #e7e4fb;
        font-family: verdana;
        font-weight: 500;
        padding: 4px 0px;
        background-color: #405D99;
        text-transform: capitalize;
      }
      .AddClass_Table td {
    height: 36px !important;
    font-size:10px !important;
}
</style>
  <link href="../../css/report.css" rel="stylesheet" type="text/css" />
  <div style="width:100%;text-align:center;clear:both;">
   <h2 class="header-text-back">Permission</h2>
  </div>
<%--<h2 class="header-text-back"></h2>--%>
<table>
   
    <tr>
        <td>
            <asp:DropDownList ID="ddlfilterforms" runat="server" Width="221px" BackColor="#f2f2f2"
                ForeColor="#090909" Font-Names="Helvetica" CssClass="ddlss">
            </asp:DropDownList>
        </td>
    </tr>
</table>
<asp:GridView ID="grdPermission" runat="server" CssClass="AddClass_Table" AutoGenerateColumns="false" OnRowCreated="grdPermission_RowCreated1"
    OnRowDataBound="grdPermission_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:Label ID="lblSection" runat="server" Text='<%#Eval("Section")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="txtalign" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:Label ID="lblField" runat="server" Text='<%#Eval("Field")%>'></asp:Label>
                <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("TechnicalFormsID")%>' />
                <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("technicalsectionSectionID")%>' />
            </ItemTemplate>
            <ItemStyle CssClass="txtalign txtWidth" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<!------------Unwanted-Part----------------->
<%--
<div id="fixed-table" style="display:none;">
    <table width="100%" cellpadding="0" cellspacing="0" style="table-layout: fixed;">       
        <tr>
            <td valign="top" align="left" style="width: 560px; display:none;">
                <div class="wrapper1">
                    <div class="div1">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                            OnRowCreated="GridView1_RowCreated1" OnRowDataBound="GridView1_RowDataBound"
                            CssClass="grid-first">
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thgrid1" ItemStyle-Width="160px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSection" runat="server" Text='<%#Eval("Section")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtalign" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thgrid1" ItemStyle-Width="420px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblField" runat="server" Text='<%#Eval("Field")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("TechnicalFormsID")%>' />
                                        <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("technicalsectionSectionID")%>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtalign" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </td>
            <td valign="top" align="left">
                <div class="wrapper2">
                    <div class="div2">
              
                    </div>
                </div>
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
    
</div>--%>
<!----------------End Of Unwanted Part----------->
7