<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OBPermission.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.OBPermission" %>
<script type="text/javascript">
    function checkboxReadCheckedAll(elem) {

        var chk = elem.id;
        var ctId = elem.id.split('_')[6].substr(2); ;
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

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            for (var i = 4; i <= rowcount; i++) {
                if (i < 10) {
                    FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
                }
                else {
                    FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
                }
                proxy.invoke("SaveOBPermission", { DeptId: DeptId, DesigId: Name, FormsID: FormsID, SectionID: SectionID, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {
                }, onPageError, false, false);
            }
            alert('Permission saved successfully!');
            //debugger; 
            if ($(elem).is(':checked')) {
                //debugger 
                $('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', 'checked');
                $('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
                $('.ddl' + DeptId + Name).attr("disabled", true);
            }
            else {
                //debugger
                $('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $('HW' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
                //$('.ddl' + DeptId + Name).find("input[type=select]").attr("disabled", true);
                $('.ddl' + DeptId + Name).attr("disabled", true);
            }
        }
        else {

            if (checkIsSave == true) {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
            }
            else {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', true);
            }

        }
    }


    function checkboxWriteCheckedAll(elem) {

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
            for (var i = 4; i <= rowcount; i++) {
                if (i < 10) {

                    FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl0" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl0" + i + "_hdnMOCoulmeID" + "']").val());
                }
                else {

                    FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl" + i + "_hdnMOSectionID" + "']").val());
                    SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ctl" + i + "_hdnMOCoulmeID" + "']").val());
                }

                proxy.invoke("SaveOBPermission", { DeptId: DeptId, DesigId: Name, FormsID: FormsID, SectionID: SectionID, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {

                }, onPageError, false, false);
            }
            alert('Permission saved successfully!');

            if ($(elem).is(':checked')) {
                // debugger
                $('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', 'checked');
                $('.R' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
                $('.ddl' + DeptId + Name).attr("disabled", false);
            }
            else {
                //debugger
                $('.W' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $('HR' + DeptId + Name).find("input[type=checkbox]").attr('checked', false);
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkR_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
                $('.ddl' + DeptId + Name).attr("disabled", false);
            }
        }
        else {
            // $('HW' + DeptId + Name).find("input[type=checkbox]").attr('checked', checkIsSave);

            if (checkIsSave == true) {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', false);
            }
            else {
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "HchkW_" + DeptId + "_" + Name + "_" + Chkid + "']").attr('checked', true);
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
        var FormsID = 0;
        var SectionID = 0;
        FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
        SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());
        var PermissionRead = $(elem).is(':checked');
        // debugger;
        var checkIsSave = $(elem).is(':checked');

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            proxy.invoke("SaveOBPermission", { DeptId: DeptId, DesigId: DesigId, FormsID: FormsID, SectionID: SectionID, PermissionRead: PermissionRead, PermissionWrite: false }, function (result) {


                alert('Permission saved successfully!');
            }, onPageError, false, false);

            if ($(elem).is(':checked')) {

                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "chkW" + DeptId + "_" + DesigId + "_" + Name + "']").attr('checked', false);
                // var va = $(elem).closest("tr").find("select").val();
                $(elem).closest("td").find("select").attr("disabled", true);
            }
        }
        else {

            if (checkIsSave == true) {
                $(elem).attr('checked', false);
            }
            else {
                $(elem).attr('checked', true);
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
        var FormsID = 0;
        var SectionID = 0;
        FormsID = parseInt($("#<%= GridView1.ClientID %> input[id*='ct" + ctId + "_hdnMOSectionID" + "']").val());
        SectionID = parseInt($("#<%= GridView1.ClientID %> input[id*='ct" + ctId + "_hdnMOCoulmeID" + "']").val());

        var PermissionWrite = $(elem).is(':checked');
        //debugger;
        var checkIsSave = $(elem).is(':checked');

        var CheckConfirm = confirm("Do You Want To save Permission.");
        if (CheckConfirm == true) {
            proxy.invoke("SaveOBPermission", { DeptId: DeptId, DesigId: DesigId, FormsID: FormsID, SectionID: SectionID, PermissionRead: false, PermissionWrite: PermissionWrite }, function (result) {

                alert('Permission saved successfully!');
            }, onPageError, false, false);

            if ($(elem).is(':checked')) {
                //debugger
                $("#<%= grdPermission.ClientID %> input[id*='ct" + ctId + "_" + "chkR" + DeptId + "_" + DesigId + "_" + Name + "']").attr('checked', false);
                $(elem).closest("td").find("select").attr("disabled", false);

            }
        }
        else {

            if (checkIsSave == true) {
                $(elem).attr('checked', false);
            }
            else {
                $(elem).attr('checked', true);
            }
        }
    }

    function SelectFilterOption(elem, Flag) {
        //debugger; //HW1Manager
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
        background:#3b5998 !important;
        
        width: 100%;
        height: 37px;
        color: White;
        text-transform: capitalize !important;
    }
    
    td
    {
        text-transform: capitalize !important;
        text-align: center;
        height: 20.7px;
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
    
    .thgrid1
    {
        height: 50px;
    }
    .ddlss {
    background-image: url("../../images/arrowvb.png");
    background-position: 200px center;
    background-repeat: no-repeat;
    border: 1px solid #909090;
    border-radius: 5px;
    padding: 3px;
    text-indent: 0.01px;
    text-overflow: "";
}
</style>

    <table>
        <tr>
            <td valign="top" align="left">
                <div style="width: 400px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Height="600px"
                        OnRowCreated="GridView1_RowCreated1" OnRowDataBound="GridView1_RowDataBound">
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
                                    <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("TechnicalFormsID")%>' />
                                    <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("technicalsectionSectionID")%>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="txtalign" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td valign="top" align="left">
                <div style="overflow: auto; width: 1100px;">
                    <asp:GridView ID="grdPermission" runat="server" AutoGenerateColumns="false" OnRowCreated="grdPermission_RowCreated1"
                        Height="600px" OnRowDataBound="grdPermission_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lblSection" Width="170" runat="server" Text='<%#Eval("Section")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtalign" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lblField" Width="170" runat="server" Text='<%#Eval("Field")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnMOSectionID" runat="server" Value='<%#Eval("TechnicalFormsID")%>' />
                                    <asp:HiddenField ID="hdnMOCoulmeID" runat="server" Value='<%#Eval("technicalsectionSectionID")%>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="txtalign" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
       
    </table>

