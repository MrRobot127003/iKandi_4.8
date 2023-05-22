<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageDesignation.aspx.cs"
    Inherits="iKandi.Web.Admin.ManageDesignation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript">
        function SaveDefaultLanding(DropDownList, DepartmentId, DesignationId) {
            var ApplicationModuleId = DropDownList;
            var hdnId = "hdn_" + DepartmentId + "_" + DesignationId;
            var Id = "ddl_" + DepartmentId + "_" + DesignationId;

            if (ApplicationModuleId == 0) {
                alert("Please select a Default Landing Page.");
                var DropDownListId = DropDownList.id;
                document.getElementById(Id).value = $("#" + hdnId).val();
                return false;
            }
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateDefaultLandingPage",
                data: "{ DepartmentId:'" + DepartmentId + "', DesignationId:'" + DesignationId + "', ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                document.getElementById(Id).value = ApplicationModuleId;
                document.getElementById(hdnId).value = ApplicationModuleId;
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function SavePermission(DropDownList, DepartmentId, DesignationId, ApplicationModuleId) {
            if (confirm('All the dependent designation will lose/achieve this permission when you change this from here. Are you sure?')) {
                Save(DropDownList, DepartmentId, DesignationId, ApplicationModuleId);
            }
            else {
                var hdnId = "hdn_" + ApplicationModuleId + "_" + DepartmentId + "_" + DesignationId;
                var Id = "ddl_" + ApplicationModuleId + "_" + DepartmentId + "_" + DesignationId;

                document.getElementById(Id).value = $("#" + hdnId).val();
            }
        }

        function Save(DropDownList, DepartmentId, DesignationId, ApplicationModuleId) {
            var PermissionType = DropDownList;
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdatePermission",
                data: "{PermissionType: '" + PermissionType + "', DepartmentId:'" + DepartmentId + "', DesignationId:'" + DesignationId + "', ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                if (response.d == 'You cannot change permission for this designation of this form because write permission is given in the Section permission form.')
                    alert(response.d);
                else
                    alert("Saved Sucessfully");
                SelectPermission(DepartmentId, ApplicationModuleId);
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function SelectPermission(DepartmentId, ApplicationModuleId) {
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetPermissionValue",
                data: "{ ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                var Id;
                var hdnId;

                for (var i = 0; i < response.d.length; i++) {
                    Id = "ddl_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"] + "_" + response.d[i]["DesignationId"];
                    hdnId = "hdn_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"] + "_" + response.d[i]["DesignationId"];
                    document.getElementById(Id).value = response.d[i]["PermissionTypeNo"];
                    document.getElementById(hdnId).value = response.d[i]["PermissionTypeNo"];
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function SaveApplicationIsActive(checkbox) {
            var row;
            var rowIndex;
            var ApplicationModuleId;
            // for the 1st Application Module (Forms)
            if (checkbox.id == "gvManageDesignation_ctl02_chkIsActive_freezeitem") {
                ApplicationModuleId = 1;
            }
            // for the 1st Application Module (File)
            else if (checkbox.id == "gvManageDesignation_ctl52_chkIsActive_freezeitem") {
                ApplicationModuleId = 2;
            }
            // for the 1st Application Module (Reports)
            else if (checkbox.id == "gvManageDesignation_ctl83_chkIsActive_freezeitem") {
                ApplicationModuleId = 94;
            }
            // for the 1st Application Module (Menu Icons)
            else if (checkbox.id == "gvManageDesignation_ctl85_chkIsActive_freezeitem") {
                ApplicationModuleId = 241;
            }
            else {
                row = checkbox.parentNode.parentNode;
                rowIndex = row.rowIndex - 1;
                ApplicationModuleId = row.cells[0].getElementsByTagName("input")[0].value;
            }

            var IsActive = false;
            if (checkbox.checked) {
                IsActive = true;
            }
            else {
                IsActive = false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateApplicationModuleIsActive",
                data: "{ ApplicationModuleId:'" + ApplicationModuleId + "', IsActive:'" + IsActive + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                if (response.d == 'You cannot change permission for this form because read/write permission is given in the Section permission form.') {
                    alert(response.d);
                    document.getElementById(checkbox.id).checked = true;
                }
                else {
                    alert("Saved Sucessfully");
                    ChangePermission(checkbox, ApplicationModuleId);
                }
            }
            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function ChangePermission(checkbox, ApplicationModuleId) {
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetPermissionValue",
                data: "{ ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                for (var i = 0; i < response.d.length; i++) {
                    CheckBoxId = "chk_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"];
                    DropDownListId = "ddl_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"] + "_" + response.d[i]["DesignationId"];
                    TextBoxId = "txt_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"] + "_" + response.d[i]["DesignationId"];
                    hdnId = "hdn_" + ApplicationModuleId + "_" + response.d[i]["DepartmentId"] + "_" + response.d[i]["DesignationId"];

                    DepartmentCheckBoxId = "checkbox" + response.d[i]["DepartmentId"] + "_Copy";

                    if (checkbox.checked) {
                        document.getElementById(CheckBoxId).checked = true;
                        if (document.getElementById(DepartmentCheckBoxId).checked == true) {
                            document.getElementById(CheckBoxId).disabled = false;
                        }
                        document.getElementById(DropDownListId).style.display = 'block';
                        document.getElementById(TextBoxId).style.display = 'none';
                    }
                    else {
                        document.getElementById(CheckBoxId).checked = false;
                        document.getElementById(CheckBoxId).disabled = true;
                        document.getElementById(DropDownListId).style.display = 'none';
                        document.getElementById(TextBoxId).style.display = 'block';
                    }
                    document.getElementById(DropDownListId).value = response.d[i]["PermissionTypeNo"];
                    document.getElementById(hdnId).value = response.d[i]["PermissionTypeNo"];
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateDeparmentActive(checkbox, DepartmentId) {
            var IsActive = false;
            if (checkbox.checked) {
                IsActive = true;
            }
            else {
                IsActive = false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateDeparmentActive",
                data: "{ DepartmentId:'" + DepartmentId + "', IsActive:'" + IsActive + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                var chkAdd = "chkAdd_" + DepartmentId;
                var chkOrder = "chkOrder_" + DepartmentId;

                if (checkbox.checked) {
                    document.getElementById(chkAdd).style.visibility = 'visible';
                    document.getElementById(chkOrder).style.visibility = 'visible';
                }
                else {
                    document.getElementById(chkAdd).style.visibility = 'hidden';
                    document.getElementById(chkOrder).style.visibility = 'hidden';
                }
                DisablePermissionType(checkbox, DepartmentId);
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function DisablePermissionType(checkbox, DepartmentId) {
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetDepartmentActive",
                data: "{DepartmentId:'" + DepartmentId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                for (var i = 0; i < response.d.length; i++) {
                    DropDownListId = "ddl_" + response.d[i]["ApplicationModuleId"] + "_" + DepartmentId + "_" + response.d[i]["DesignationId"];
                    DefaultDropDownListId = "ddl_" + DepartmentId + "_" + response.d[i]["DesignationId"];
                    CheckboxId = "chk_" + response.d[i]["ApplicationModuleId"] + "_" + DepartmentId;
                    AnchorTagId = "chkUpdate_" + response.d[i]["DesignationId"];

                    if (checkbox.checked) {
                        document.getElementById(DropDownListId).disabled = false;
                        document.getElementById(DefaultDropDownListId).disabled = false;
                        document.getElementById(CheckboxId).disabled = false;
                        document.getElementById(AnchorTagId).style.visibility = 'visible';
                    }
                    else {
                        document.getElementById(DropDownListId).disabled = true;
                        document.getElementById(DefaultDropDownListId).disabled = true;
                        document.getElementById(CheckboxId).disabled = true;
                        document.getElementById(AnchorTagId).style.visibility = 'hidden';
                    }
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function Check_UpdateRestrictDepartment(checkbox, ApplicationModuleId, DepartmentId) {

            if (checkbox.checked) {
                UpdateRestrictDepartment(checkbox, ApplicationModuleId, DepartmentId);
            }
            else {
                CheckRestrictDepartment(checkbox, DepartmentId, ApplicationModuleId);
            }
        }

        function CheckRestrictDepartment(checkbox, DepartmentId, ApplicationModuleId) {
            var url = "../Webservices/iKandiService.asmx";
            //debugger;
            $.ajax({
                type: "POST",
                url: url + "/CheckIsRestrictDepartmentAvailable",
                data: "{ DepartmentId:'" + DepartmentId + "', ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                //debugger;
                if (response.d) {

                    UpdateRestrictDepartment(checkbox, ApplicationModuleId, DepartmentId);
                }
                else {
                    alert("Depandency of Designation with another Department. Please check.");
                    document.getElementById(checkbox.id).checked = true;
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateRestrictDepartment(checkbox, ApplicationModuleId, DepartmentId) {
            var IsActive = false;
            if (checkbox.checked) {
                IsActive = true;
            }
            else {
                IsActive = false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateRestrictDepartment",
                data: "{ ApplicationModuleId:'" + ApplicationModuleId + "', DepartmentId:'" + DepartmentId + "', IsActive:'" + IsActive + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                if (response.d == 'You cannot change permission for this department of this form because read/write permission is given in the Section permission form.') {
                    alert(response.d);
                    document.getElementById(checkbox.id).checked = true;
                }
                else {
                    alert("Saved Sucessfully");
                    ChangePermissionValue(checkbox, ApplicationModuleId, DepartmentId);
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function ChangePermissionValue(checkbox, ApplicationModuleId, DepartmentId) {
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetPermissionType",
                data: "{ DepartmentId:'" + DepartmentId + "', ApplicationModuleId:'" + ApplicationModuleId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                for (var i = 0; i < response.d.length; i++) {
                    DropDownListId = "ddl_" + ApplicationModuleId + "_" + DepartmentId + "_" + response.d[i]["DesignationId"];
                    TextBoxId = "txt_" + ApplicationModuleId + "_" + DepartmentId + "_" + response.d[i]["DesignationId"];
                    hdnId = "hdn_" + ApplicationModuleId + "_" + DepartmentId + "_" + response.d[i]["DesignationId"];

                    if (checkbox.checked) {
                        document.getElementById(DropDownListId).style.display = 'block';
                        document.getElementById(TextBoxId).style.display = 'none';
                    }
                    else {
                        document.getElementById(DropDownListId).style.display = 'none';
                        document.getElementById(TextBoxId).style.display = 'block';
                    }
                    document.getElementById(DropDownListId).value = response.d[i]["PermissionTypeNo"];
                    document.getElementById(hdnId).value = response.d[i]["PermissionTypeNo"];
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        var PreDepartmentId;
        function GetPreviousValue(DropDownList) {
            PreDepartmentId = DropDownList.options[DropDownList.selectedIndex].value;
        }

        function SaveMenuShowDepartment(DropDownList) {
            var row;
            var rowIndex;
            var ApplicationModuleId;
            // for the 1st Application Module (Forms)
            if (DropDownList.id == "gvManageDesignation_ctl02_ddlDepartment_freezeitem") {
                ApplicationModuleId = 1;
            }
            // for the 1st Application Module (File)
            else if (DropDownList.id == "gvManageDesignation_ctl52_ddlDepartment_freezeitem") {
                ApplicationModuleId = 2;
            }
            // for the 1st Application Module (File)
            else if (DropDownList.id == "gvManageDesignation_ctl83_ddlDepartment_freezeitem") {
                ApplicationModuleId = 94;
            }
            else {
                row = DropDownList.parentNode.parentNode;
                rowIndex = row.rowIndex - 1;
                ApplicationModuleId = row.cells[0].getElementsByTagName("input")[0].value;
            }

            var PreviousDepartmentId = PreDepartmentId;
            var DepartmentId = DropDownList.options[DropDownList.selectedIndex].value;

            if (DepartmentId == 0) {
                alert("Please select a Department");
                var DropDownListId = DropDownList.id;
                document.getElementById(DropDownListId).value = PreviousDepartmentId;
                return false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateMenuShowDepartment",
                data: "{ ApplicationModuleId:'" + ApplicationModuleId + "', DepartmentId:'" + DepartmentId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function OpenAddDepartment(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 225, width: 400, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function OpenAddDesignation(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 225, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function OpenUpdateDesignationOrder(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function SBClose() { }
    </script>
    <script type="text/javascript" src="../js/jquery-1.9.0-jquery.min.js"></script>
    <script src="../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            var gridWidth = $(window).width() - 10;
            var gridHeight = $(window).height() - 80;

            var headerHeight = $("#divHeader").height();

            gridHeight = gridHeight - headerHeight;

            $('#gvManageDesignation').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                arrowsize: 30,
                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png",
                freezesize: 4
            });
        }
    </script>
    <style type="text/css">
        .rotate
        {
            display: block; /*Firefox*/
            -moz-transform: rotate(-90deg); /*Safari*/
            -webkit-transform: rotate(-90deg); /*Opera*/
            -o-transform: rotate(-90deg);
            -ms-transform: rotate(-90deg);
            color: #405d9a;
            font-weight: bold;
            font-size: 15px;
            font-family: arial;
            padding: 0px;
            overflow: hidden;
            font-family: ‘Trebuchet MS’, Helvetica, sans-serif;
            margin-top: 25px;
            margin-bottom: 25px;
            text-transform: none;
        }
        .txt
        {
            color: #7E7E7E;
            text-transform: none;
        }
        .header-text-back
        {
            font-size: 17px;
            background: #405d99;
            padding: 5px 0px;
            color: #fff;
            font-weight: 500;
            width: 98%;
            margin: 0;
            margin-left: 10px;
        }
        input[type=text]
        {
            margin:0px 2px;
        }
        select
        {
            margin:0px 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 100%; text-align: center; clear: both; margin: 5px 0px 0px;">
            <h2 class="header-text-back">
                Manage Designation</h2>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="font-family: Arial;
            width: 99%">
            <%-- <tr>
                <td align="center" style="background-color: #405D99; height: 35px; color: #FFFFFF; font-size: 22px;">Manage Designation</td>
            </tr>--%>
            <tr>
                <td align="right" style="height: 24px; padding-right: 25px;">
                    <asp:ImageButton ID="btnAddApplicationModule" runat="server" OnClick="btnAddApplicationModule_OnClick"
                        ImageUrl="../images/add-butt-white.png" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="gvManageDesignation" runat="server" AutoGenerateColumns="false"
                        HeaderStyle-Height="136px" HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="false"
                        HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#F2F2F2" RowStyle-Height="35px"
                        RowStyle-ForeColor="#7E7E7E" OnDataBound="gvManageDesignation_DataBound" OnRowDataBound="gvManageDesignation_RowDataBound">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="125px">
                                        <tr>
                                            <td align="center" style="padding-top: 22px; padding-bottom: 15px; background-color: #405D99;
                                                color: #FFFFFF;">
                                                Entity
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnEntity" runat="server" Value='<%#Eval("Entity") %>' />
                                    <asp:Label ID="lblEntity" runat="server" CssClass="rotate" Font-Size="20px" Font-Bold="true"
                                        Text='<%#Eval("Entity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="225px">
                                        <tr>
                                            <td align="center" style="width: 50%; padding-top: 20px; padding-bottom: 15px; background-color: #405D99;
                                                color: #FFFFFF;">
                                                Name
                                            </td>
                                            <td align="right" style="width: 50%; padding-top: 20px; padding-bottom: 15px; background-color: #405D99;
                                                color: #FFFFFF;">
                                                <a rel="shadowbox;width=400;height=225;" href="/Admin/AddDepartment.aspx" onclick='return OpenAddDepartment(this);'>
                                                    <img src='../images/add-butt-white.png' alt='' /></a> Add Dept.
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="225px">
                                        <tr>
                                            <td align="left" style="width: 80%;">
                                                <asp:HiddenField ID="hdnModuleId" runat="server" Value='<%#Eval("Id") %>' />
                                                <asp:Label ID="lblName" runat="server" CssClass="txt" Font-Size="12px" Text='<%#Eval("Name") %>'></asp:Label>
                                            </td>
                                            <td align="center" style="width: 20%;">
                                                <asp:Image ID="imgApplication" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="165px">
                                        <tr>
                                            <td align="center" style="padding-top: 22px; padding-bottom: 15px; background-color: #405D99;
                                                color: #FFFFFF;">
                                                Department
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDepartment" runat="server" Value='<%#Eval("DepartmentID") %>' />
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="txt" Font-Size="12px"
                                        Width="150px" onchange="SaveMenuShowDepartment(this)" onfocus="GetPreviousValue(this)">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="75px">
                                        <tr>
                                            <td align="center" style="padding-top: 22px; padding-bottom: 15px; background-color: #405D99;
                                                color: #FFFFFF;">
                                                Is Active
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsActive" runat="server" onclick="SaveApplicationIsActive(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
