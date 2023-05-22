<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.ManageCategories" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<%--<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>--%>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<%--<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>--%>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<style type="text/css">
    .paging
    {
        text-transform: capitalize;
        border: 0px solid #dedede;
        padding: 3px;
        font: bold 12px/14px Helvetica,Arial,Verdana,sans-serif;
        color: #bdc3cf;
        text-align: center;
    }
    
    .TextColor
    {
        color: #0088cc;
        text-transform: none;
        font: 12px/14px Arial, Helvetica, sans-serif;
        border: 1px solid #b7b4b4;
    }
    .ColorAndAlign
    {
        text-align: left;
        font: normal 12px/14px Arial, Helvetica, sans-serif;
        background: #dddfe4;
        text-transform: none;
        color: #575759;
        width: 194px;
        border: 1px solid #b7b4b4;
    }
    .ColorAndAlign th
    {
        padding: 8px 0px;
        border: 1px solid #999;
    }
    .td-sub_headings th
    {
        font-weight: normal !important;
    }
    .modalNew
    {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }
    .modal-content
    {
        width: 600px;
        margin: auto;
        background: #fff;
        border: 5px solid #999;
        border-radius: 5px;
        min-height: 300px;
        max-height: 320px;
        overflow: auto;
    }
    .HistoryHeader
    {
        background: #39589c;
        color: #fff;
        text-align: center;
        font-size: 14px;
    }
    #HistoryDescription
    {
        padding: 7px !important;
    }
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        background: #f7f7f7;
        border: solid 1px #d7d7d7;
        padding: 5px;
        height: 29px;
    }
    
    .TextColor
    {
        color: #000;
        text-transform: none;
        padding: 0px 5px;
        font: 12px/14px Arial, Helvetica, sans-serif;
    }
    
    .ColorAndAlign th
    {
        font-weight: normal;
        text-align: center;
    }
    .item_list th
    {
        height: auto;
    }
    .item_list td
    {
        border: 1px solid #dbd8d8;
        height: 20px;
    }
    input[type="text"], select
    {
        width: 85% !important;
        border: 1px solid #b7b4b4 !important;
    }
    .item_list td p
    {
        margin: 0px;
    }
    .item_list TD select
    {
        color: Gray;
    }
    .capitalize
    {
        text-transform: capitalize;
    }
    .move-left
    {
        text-align: left !important;
    }
    
    .selectRow td
    {
        background-color: #A1DCF2;
    }
    td[colspan="8"]
    {
        border-right-color: #999 !important;
    }
    td[colspan="8"]
    {
        border-left-color: #999 !important;
    }
    .bottomAdd.item_list.bottomRow tr:nth-last-child(2) > td
    {
        border-bottom-color: #999 !important;
    }
    td[colspan="10"]
    {
        border: 0px;
        padding: 2px 0px !important;
    }
    td[colspan="10"] table td
    {
        border: 0px;
    }
    td[colspan="10"] table td span
    {
        color: Blue;
        cursor: default;
    }
    td[colspan="10"] table td a
    {
        color: gray;
    }
    #ctl00_cph_main_content_ManageCategories1_gvCategories
    {
        border-left: 0px;
        border-right: 0px;
        border-bottom: 0px;
    }
    table tr:nth-last-child(1) > td
    {
        border-bottom-color: #999;
    }
    
    .hidetemplate
    {
        display:none;
        }
    .first_child_hide
    {
         display:none;
        }

</style>
<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(function () {
        $("#dvHistory").css("display", "none");
        var rowCount = $('.bottomRow tr').length;
        if (rowCount > 20) {
            //alert();
            $(".bottomRow").addClass('bottomAdd');
        }



    });

    function CatInValid() {
        //alert("keypress");
        $("#" + '<%=hfCatValid.ClientID%>').val("0");
        $("#" + '<%=btnSubmit.ClientID%>').attr("disabled", true);
    }
    function Validation(obj) {

        if (/\D/g.test(obj.value)) {
            // Filter non-digits from input value.
            obj.value = obj.value.replace(/\D/g, '');

        }
    }
    var CategoryGrid = '<%=gvCategories.ClientID %>';






    function UpdatedGreigeDays(obj) {

    debugger;
        
        var row = $(obj).closest("tr");
        var rowindex = row[0].rowIndex - 1;



        var hdnCategoryID = row.find('input[id$=hdncategoryID2]').val();
        var userid = $("#HndUserid").val();

        var txtfab_Griegday = row.find('input:text[id$="txtfab_Griegday"]').val();

        if (txtfab_Griegday == '' || txtfab_Griegday == null) {
            txtfab_Griegday = 0;
        }


        var txtfab_Griegday_drange = row.find('input:text[id$="txtfab_Griegday_drange"]').val();

        if (txtfab_Griegday_drange == '' || txtfab_Griegday_drange == null) {
            txtfab_Griegday_drange = 0;
        }


        var txtfab_DyedDay = row.find('input:text[id$="txtfab_DyedDay"]').val();
        if (txtfab_DyedDay == '' || txtfab_DyedDay == null) {
            txtfab_DyedDay = 0;

        }

        var txtfab_DyedDay_drange = row.find('input:text[id$="txtfab_DyedDay_drange"]').val();

        if (txtfab_DyedDay_drange == '' || txtfab_DyedDay_drange == null) {

            txtfab_DyedDay_drange = 0;
        }
        var txtfab_PrintDay = row.find('input:text[id$="txtfab_PrintDay"]').val();
        if (txtfab_PrintDay == '' || txtfab_PrintDay == null) {

            txtfab_PrintDay = 0;
        }


        var txtfab_PrintDay_drange = row.find('input:text[id$="txtfab_PrintDay_drange"]').val();
        if (txtfab_PrintDay_drange == '' || txtfab_PrintDay_drange == null) {

            txtfab_PrintDay_drange = 0;
        }

        var txtfab_ProcessDay = row.find('input:text[id$="txtfab_ProcessDay"]').val();

        if (txtfab_ProcessDay == '' || txtfab_ProcessDay == null) {

            txtfab_ProcessDay = 0;
        }
        var txtProcess_drange = row.find('input:text[id$="txtProcess_drange"]').val();
        if (txtProcess_drange == '' || txtProcess_drange == null) {

            txtProcess_drange = 0;
        }


        var txtfab_PrintDay_drange = row.find('input:text[id$="txtfab_PrintDay_drange"]').val();
        if (txtfab_PrintDay_drange == '' || txtfab_PrintDay_drange == null) {

            txtfab_PrintDay_drange = 0;
        }

        var txtfab_fab_FinishDay = row.find('input:text[id$="txtfab_fab_FinishDay"]').val();
        if (txtfab_fab_FinishDay == '' || txtfab_fab_FinishDay == null) {

            txtfab_fab_FinishDay = 0;
        }


        var txtfab_fab_FinishDayge = row.find('input:text[id$="txtfab_FinishDay_drange"]').val();

        if (txtfab_fab_FinishDayge == '' || txtfab_fab_FinishDayge == null) {

            txtfab_fab_FinishDayge = 0;
        }

        var txtfab_RFDDay_stage1 = row.find('input:text[id$="txtfab_RFDDay_stage1"]').val();
        if (txtfab_RFDDay_stage1 == '' || txtfab_RFDDay_stage1 == null) {

            txtfab_RFDDay_stage1 = 0;
        }


        var txtfab_RFD_stage1drange = row.find('input:text[id$="txtfab_RFD_stage1drange"]').val();

        if (txtfab_RFD_stage1drange == '' || txtfab_RFD_stage1drange == null) {

            txtfab_RFD_stage1drange = 0;
        }

        var txtfab_RFD_stage2 = row.find('input:text[id$="txtfab_RFD_stage2"]').val();
        if (txtfab_RFD_stage2 == '' || txtfab_RFD_stage2 == null) {

            txtfab_RFD_stage2 = 0;
        }


        var txtfab_RFD_stage2drange = row.find('input:text[id$="txtfab_RFD_stage2drange"]').val();

        if (txtfab_RFD_stage2drange == '' || txtfab_RFD_stage2drange == null) {

            txtfab_RFD_stage2drange = 0;
        }


        var txtfab_EmbroderyDay = row.find('input:text[id$="txtfab_EmbroderyDay"]').val();

        if (txtfab_EmbroderyDay == '' || txtfab_EmbroderyDay == null) {

            txtfab_EmbroderyDay = 0;
        }

        var txtfab_Embroderydrange = row.find('input:text[id$="txtfab_EmbroderyDay_drange"]').val();
        if (txtfab_Embroderydrange == '' || txtfab_Embroderydrange == null) {

            txtfab_Embroderydrange = 0;
        }

        var txtfab_EmbellisDay = row.find('input:text[id$="txtFab_EmbellishmentDay"]').val();
        if (txtfab_EmbellisDay == '' || txtfab_EmbellisDay == null) {

            txtfab_EmbellisDay = 0;
        }


        var txtFab_Embellishment_drange = row.find('input:text[id$="txtFab_Embellishment_drange"]').val();

        if (txtFab_Embellishment_drange == '' || txtFab_Embellishment_drange == null) {

            txtFab_Embellishment_drange = 0;
        }

        proxy.invoke("UpdateCategorySupplierDays", { CategoryID: hdnCategoryID, grgDays: txtfab_Griegday, grgrange: txtfab_Griegday_drange, dyedDays: txtfab_DyedDay, dyedrange: txtfab_DyedDay_drange, ProcessDays: txtfab_ProcessDay, Process_drange: txtProcess_drange, PrintDays: txtfab_PrintDay, PrintRange: txtfab_PrintDay_drange, FinishDays: txtfab_fab_FinishDay, FinishRange: txtfab_fab_FinishDayge, RFDstg1day: txtfab_RFDDay_stage1, RFDstg1Range: txtfab_RFD_stage1drange, RFDstg2Days: txtfab_RFD_stage2, RFDstg2range: txtfab_RFD_stage2drange, embrDays: txtfab_EmbroderyDay, embrRange: txtfab_Embroderydrange, embllDays: txtfab_EmbellisDay, embllRange: txtFab_Embellishment_drange, Userid: 122 }, function (result) {

            result = '<div class="">' + result + "</div>";

            //jQuery.facebox(result);

        }, onPageError, false, false);

    }
    function CheckType() {

        if ($("#" + '<%=ddlTypes.ClientID%>').val() == "-1") {
            jQuery.facebox("Type should be Fabric or Accessory");
            $("#" + '<%=ddlTypes.ClientID%>').focus();
            return false;
        }

    }

    function CheckCatValid() {    
        if ($("#" + '<%=hfCatValid.ClientID%>').val() == "0") {
            jQuery.facebox("Category is not valid");
            return false;
        }
        else if ($("#" + '<%=tbCategoryName.ClientID%>').val() == "") {
            jQuery.facebox("Please enter group name");
            $("#" + '<%=tbCategoryName.ClientID%>').focus();
            return false;
        }
        else if ($("#" + '<%=tbCategoryCode.ClientID%>').val() == "") {
            jQuery.facebox("Please enter group code");
            $("#" + '<%=tbCategoryCode.ClientID%>').focus();
            return false;
        }
        else if ($("#" + '<%=ddlUnit.ClientID%>').val() == "") { 
            jQuery.facebox("Please select unit");
            $("#" + '<%=ddlUnit.ClientID%>').focus();
            return false;
        }
        return true;
    }

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;

        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

    function isNumberKeyfloat(evt, val) {
        //debugger;
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
            return false;
        else {
            var len = val.value.length;
            var index = val.value.indexOf('.');

            if (index > 0 && charCode == 46) {
                return false;
            }
            if (index > 0) {
                var CharAfterdot = (len + 1) - index;
                if (CharAfterdot > 3) {
                    return false;
                }
            }
        }
        return true;
    }

    function allowAlphaNumericSpace(e) {
        var code = ('charCode' in e) ? e.charCode : e.keyCode;
        if (!(code > 47 && code < 58) && // numeric (0-9)
    !(code > 64 && code < 91) && // upper alpha (A-Z)
    !(code > 96 && code < 123)) { // lower alpha (a-z)
            e.preventDefault();
        }
    }

    function TwoDigitBeforeAndAfterDecimal(evt, val) {

        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
            return false;
        else {
            var len = val.value.length;
            var index = val.value.indexOf('.');

            if (len >= 2 && charCode == 46) {
                if (index > 0 && charCode == 46) {
                    return false;
                }
                return true;
            }
            else if (len >= 2 && charCode != 46) {
                if (val.value.includes('.') == false) {
                    var v = val.value.substring(0, 1);
                    $(this).val(v);
                    return false;
                }
                else {
                    if (len > 0) {
                        var pieces = val.value.split(".");
                        var LenAfterDot = pieces[1].length;
                        //var CharAfterdot = (LenAfterDot + 1) - index;
                        if (LenAfterDot > 1) {
                            return false;
                        }
                    }
                }
            }
            else {
                if (index > -1 && charCode == 46 && len > 0) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    function CreateGroupCode(obj) {
        //debugger;
        var Ids = obj.id;
        var gvId = Ids.split("_")[6].substr(3);
        var GroupCode = '';

        var GroupName = $(obj).val();

        if (GroupName != "") {
            if (GroupName.length < 3) {
                jQuery.facebox('Please enter at least three character!');
                $("#<%= gvCategories.ClientID %> input[id*='" + gvId + "_txtCategoryCode" + "']").val('')
                return false;
            }
            var GroupString = GroupName.split(" ");

            if (GroupString.length == 1) {

                GroupCode += GroupString[0].substr(0, 3);
            }
            else {
                for (var i = 0; i < GroupString.length; i++) {
                    if (/^[a-zA-Z0-9- ]*$/.test(GroupString[i].substr(0, 1)) == true) {
                        GroupCode += GroupString[i].substr(0, 1);

                        if (GroupString.length > 1) {
                            GroupCode += GroupString[i].substr(1, 1);
                        }
                    }
                }
            }

            $("#<%= gvCategories.ClientID %> input[id*='" + gvId + "_txtCategoryCode" + "']").val(GroupCode.toUpperCase())
            return false;
        }
    }
    function ShowHistory() {
        debugger;
        var GroupType = $("#" + '<%=ddlTypes.ClientID%>').val();

        var FieldName = "";
        if (GroupType == 1)
            FieldName = "Fabric";
        else if (GroupType == 2)
            FieldName = "Accessory";
        else
            FieldName = "All";

        var type = 1;

        proxy.invoke("GetAdminHistory", { typeflag: type, FieldName: FieldName },
            function (result) {
                debugger;
                var History = result;
                var vDesc = '';
                for (var i = 0; i < History.length; i++) {
                    debugger;
                    vDesc = vDesc + '<li>' + History[i] + '</li>';
                }
                $("#HistoryDescription").html(vDesc);
                $("#dvHistory").css("display", "block");

                if (GroupType == 1)
                    $("#Historytitle").text('Fabric History');
                else if (GroupType == 2)
                    $("#Historytitle").text('Accessory History');
                else
                    $("#Historytitle").text('History');

            });
    }
    function SpiltContactClose() {
        $("#dvHistory").hide();
    }
    function pageLoad() {
        var rowCount = $('.bottomRow tr').length;
        // alert(rowCount);
        if (rowCount > 20) {
            $(".bottomRow").addClass('bottomAdd');
        }

    }
    
</script>
<div class="print-box" style="width: 100%; margin: 0px auto;">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlupdtForm" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h2 style="border: 1px solid gray; margin: 3px 0px 2px">
                Manage Group <span style="float: right; color: White; width: 200px; font-size: 10px;
                    padding-right: 5px; line-height: 21px; cursor: pointer; position: relative;">
                    <asp:HyperLink ID="hlnkHistory" Text="Show History" onclick="ShowHistory()" runat="server"
                        Style="position: absolute; right: 10px;"></asp:HyperLink>
                </span>
            </h2>
            <table border="0" cellspacing="0" cellpadding="0" style="width: 400px; margin-bottom: 2px;"
                class="item_list">
                <tr>
                    <th width="100px" valign="bottom">
                        Type
                    </th>
                    <th width="100px" valign="bottom">
                        Group name
                    </th>
                    <th width="100px" valign="bottom">
                        &nbsp;
                    </th>
                </tr>
                <tr>
                    <td class="border_left_color">
                        <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="true" CssClass="do-not-disable TextColor"
                            OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="All" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlParentCategories" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="border_right_color">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="da_go_button go" OnClick="btnSearch_Click" />
                        &nbsp;
                        <asp:Button ID="btnadd" OnClientClick="javascript:return CheckType()" runat="server"
                            Text="Add" class="da_go_button" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="addpnl" runat="server" Visible="false">
                <table width="900px" border="0" cellspacing="0" cellpadding="0" class="item_list"
                    style="margin-top: 3px">
                    <tr>
                        <th style="border-bottom: 0px; font-size: 12px;">
                            <span>Add/Update Group (<span class="da_astrx_mand">*</span>Please fill all required
                                fields)</span>
                        </th>
                    </tr>
                </table>
                <asp:HiddenField Value="1" runat="server" ID="hfCatValid" />
                <table width="900px" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;"
                    class="item_list">
                    <tr>
                     <%-- RajeevS code for HSNCode implementation--%>
                       <%-- <th width="65px" valign="bottom">
                            HSNCode<span class="da_astrx_mand">*</span>
                        </th>--%>
                     <%-- RajeevS code for HSNCode implementation--%>
                        <th width="100px" valign="bottom">
                            Group Name<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="65px" valign="bottom">
                            Group Code<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="100px" valign="bottom">
                            Group Type
                        </th>
                        <%-- <th width="60px" valign="bottom" id="tdDyedRateMeg" runat="server">
                            Dyed Rate
                        </th>
                        <th width="60px" valign="bottom" id="tdPrintRateMeg" runat="server">
                            Screen Print Rate
                        </th>
                        <th width="60px" valign="bottom" id="tdDigitalPrintRateMeg" visible="false" runat="server">
                            Digital Print Rate
                        </th>--%>
                        <th width="80px" valign="bottom" id="tdIsCANDCMeg" runat="server">
                            Is C&C Mandatory
                        </th>
                        <th width="70px" valign="bottom">
                            Unit<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="50px" valign="bottom" id="tdwastageMeg" runat="server">
                            Wastage %<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="50px" valign="bottom" id="tdGriegeGst_header" runat="server">
                            Griege GST %<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="50px" valign="bottom" id="tdProcessGst_header" runat="server">
                            Process GST %<span class="da_astrx_mand">*</span>
                        </th>
                        <th width="50px" valign="bottom" id="tdGstNoMeg" runat="server">
                        </th>
                    </tr>
                    <tr>
                   <%-- RajeevS code for HSNCode implementation--%>
                        <%--<td>
                            <asp:TextBox ID="txtHSNCode" CssClass="TextColor" runat="server" MaxLength="20" onkeypress="allowAlphaNumericSpace(event)"></asp:TextBox>
                        </td>--%>
                 <%-- RajeevS code for HSNCode implementation--%>
                        <td class="border_left_color">
                            <asp:TextBox ID="tbCategoryName" AutoPostBack="True" CssClass="categorynameCss" runat="server"
                                MaxLength="50" Width="90%" OnTextChanged="tbCategoryName_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbCategoryCode" CssClass="TextColor" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategoryType" CssClass="TextColor" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCategoryType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <%-- <td id="tdDyedRate" runat="server">
                            <asp:TextBox runat="server" ID="txtDyedRate" onkeypress="return isNumberKeyfloat(event, this)"
                                MaxLength="6"></asp:TextBox>
                        </td>
                        <td id="tdPrintRate" runat="server">
                            <asp:TextBox runat="server" ID="txtPrintRate" onkeypress="return isNumberKeyfloat(event, this)"
                                MaxLength="6"></asp:TextBox>
                        </td>
                        <td id="tdDigitalRate" runat="server">
                            <asp:TextBox runat="server" ID="txtDigitalRate" onkeypress="return isNumberKeyfloat(event, this)"
                                MaxLength="6"></asp:TextBox>
                        </td>--%>
                        <td id="tdCANDC" runat="server" class="border_right_color">
                            <asp:DropDownList runat="server" ID="ddlCANDC1">
                                <asp:ListItem Value="0" Selected="True">False</asp:ListItem>
                                <asp:ListItem Value="1">True</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="border_right_color">
                            <asp:DropDownList runat="server" ID="ddlUnit">
                            </asp:DropDownList>
                        </td>
                        <td id="tdwastagetextbox" runat="server">
                            <asp:TextBox ID="txtwastage" MaxLength="5" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                CssClass="input_in"></asp:TextBox>
                        </td>
                        <td id="tdGriegeGST" runat="server">
                            <asp:TextBox ID="txtGriegeGST" runat="server" onkeypress="return TwoDigitBeforeAndAfterDecimal(event, this)"></asp:TextBox>
                        </td>
                        <td id="tdProcessGST" runat="server">
                            <asp:TextBox ID="txtProcessGST" runat="server" onkeypress="return TwoDigitBeforeAndAfterDecimal(event, this)"></asp:TextBox>
                        </td>
                        <td id="tdGSTNo" runat="server">
                            <asp:TextBox ID="txtGST" runat="server" onkeypress="return TwoDigitBeforeAndAfterDecimal(event, this)"></asp:TextBox>
                        </td>
                        <%--<td style="display: none" class="border_right_color">
                            <asp:DropDownList ID="ddlParentCategory" CssClass="input_in TextColor" runat="server">
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                </table>
                <div style="float: right; padding-top: 5px; margin-bottom: 5px;" class="form_buttom">
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="da_submit_button submit"
                        OnClick="Submit_Click" OnClientClick="JavaScript:return CheckCatValid();" />
                    <input type="button" id="Button1" value="Print" class="da_submit_button" onclick="return PrintPDF();"
                        style="display: none;" />
                </div>
            </asp:Panel>
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                PageSize="20" DataKeyNames="CategoryID" OnPageIndexChanged="gvCategories_PageIndexChanged"
                BackColor="White" OnRowDataBound="gvCategories_RodataBound" CssClass="item_list bottomRow multi_header"
                OnPageIndexChanging="gvCategories_PageIndexChanging" OnRowCancelingEdit="gvCategories_RowCancelingEdit"
                OnRowEditing="gvCategories_RowEditing" OnRowUpdating="gvCategories_RowUpdating"
                Style="margin-top: 2px; width: 100%;">
                <%--    <PagerSettings PageButtonCount="5" />--%>

                <%--If any column Added or removed need to Update the code in Cs page for visibility (Girish)--%>
                <SelectedRowStyle CssClass="selectRow" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <tr>
                                <th runat="server" id="thGroupDescription">
                                    Group description
                                </th>
                                <th runat="server" id="thETADays">
                                    Eta Days
                                </th>
                                <th runat="server" id="thGeneralDescription">
                                    General description
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="first_child_hide" />
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle CssClass="hidetemplate" />
                    </asp:TemplateField>
                   <%-- RajeevS HSNCode Implementation--%>
                   <%-- <asp:TemplateField HeaderText="HSN Code" ItemStyle-CssClass="TextColor capitalize"
                        HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "HSNCode")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtHSNCodeUpdate" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "HSNCode")%>'
                                runat="server" onkeypress="allowAlphaNumericSpace(event)"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="90px" />
                        <ItemStyle CssClass="TextColor capitalize border_left_color" Width="140px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Group Name" ItemStyle-CssClass="TextColor capitalize"
                        HeaderStyle-Width="140px">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "CategoryName")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryName" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'
                                onblur="CreateGroupCode(this)" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnCategoryID" Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>'
                                runat="server" />
                        </EditItemTemplate>
                        <HeaderStyle Width="140px" />
                        <ItemStyle CssClass="TextColor capitalize border_left_color" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Group Code" ItemStyle-CssClass="TextColor capitalize"
                        HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "CategoryCode")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryCode" CssClass="do-not-allow-typing" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryCode")%>'
                                runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="60px" />
                        <ItemStyle CssClass="TextColor capitalize" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type" ItemStyle-CssClass="TextColor capitalize" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <%#(iKandi.Common.CategoryTypeNew)DataBinder.Eval(Container.DataItem, "Type")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblType" runat="server" Text='<%#(iKandi.Common.CategoryTypeNew)DataBinder.Eval(Container.DataItem, "Type")%>'></asp:Label>
                        </EditItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle CssClass="TextColor capitalize" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Griege" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_Griegday" runat="server" Text='<%# (int) Eval("fab_Griegday") == 0 ? "" : Eval("fab_Griegday") %>'
                                onchange="UpdatedGreigeDays(this);" CssClass="Validation" onkeyup="Validation(this);"></asp:TextBox>
                            <asp:HiddenField ID="hdncategoryID2" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_Griegday_drange" runat="server" Text='<%# (int) Eval("fab_Griegday_drange") == 0 ? "" : Eval("fab_Griegday_drange") %> '
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dyed" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_DyedDay" runat="server" Text='<%# (int) Eval("fab_DyedDay") == 0 ? "" : Eval("fab_DyedDay")  %>'
                                onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_DyedDay_drange" runat="server" Text='<%# (int) Eval("fab_DyedDay_drange") == 0 ? "" : Eval("fab_DyedDay_drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Process" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_ProcessDay" runat="server" Text='<%# (int) Eval("Process_day") == 0 ? "" : Eval("Process_day") %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtProcess_drange" runat="server" Text='<%# (int) Eval("Process_drange") == 0 ? "" : Eval("Process_drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Print" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_PrintDay" runat="server" Text='<%# (int) Eval("fab_PrintDay") == 0 ? "" : Eval("fab_PrintDay")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_PrintDay_drange" runat="server" Text='<%# (int) Eval("fab_PrintDay_drange") == 0 ? "" : Eval("fab_PrintDay_drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Finish" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_fab_FinishDay" runat="server" Text='<%# (int) Eval("fab_FinishDay") == 0 ? "" : Eval("fab_FinishDay")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_FinishDay_drange" runat="server" Text='<%# (int) Eval("fab_FinishDay_drange") == 0 ? "" : Eval("fab_FinishDay_drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RFD At 1st Stage" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_RFDDay_stage1" runat="server" Text='<%# (int) Eval("fab_RFDDay_stage1") == 0 ? "" : Eval("fab_RFDDay_stage1")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_RFD_stage1drange" runat="server" Text='<%# (int) Eval("fab_RFD_stage1drange") == 0 ? "" : Eval("fab_RFD_stage1drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RFD At 2nd Stage" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_RFD_stage2" runat="server" Text='<%# (int) Eval("fab_RFD_stage2") == 0 ? "" : Eval("fab_RFD_stage2")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_RFD_stage2drange" runat="server" Text='<%# (int) Eval("fab_RFD_stage2drange") == 0 ? "" : Eval("fab_RFD_stage2drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Embroidery" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_EmbroderyDay" runat="server" Text='<%# (int) Eval("fab_EmbroderyDay") == 0 ? "" : Eval("fab_EmbroderyDay")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtfab_EmbroderyDay_drange" runat="server" Text='<%# (int) Eval("fab_EmbroderyDay_drange") == 0 ? "" : Eval("fab_EmbroderyDay_drange")   %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Embellishment" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFab_EmbellishmentDay" runat="server" Text='<%# (int) Eval("Fab_EmbellishmentDay") == 0 ? "" : Eval("Fab_EmbellishmentDay")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="+Days" ItemStyle-CssClass="capitalize TextColor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFab_Embellishment_drange" runat="server" Text='<%# (int) Eval("Fab_Embellishment_drange") == 0 ? "" : Eval("Fab_Embellishment_drange")  %>'
                                onchange="UpdatedGreigeDays(this);" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Is C&C Mandatory" ItemStyle-CssClass="TextColor" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lblCANDC" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Is_CANDC")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" Width="60px" ID="ddlCANDC">
                                <asp:ListItem Value="0">False</asp:ListItem>
                                <asp:ListItem Value="1">True</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnIsCANDC" Value='<%#DataBinder.Eval(Container.DataItem, "Is_CANDC")%>'
                                runat="server" />
                        </EditItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Unit" ItemStyle-CssClass="TextColor" HeaderStyle-Width="40px">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "unit")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" Width="60px" ID="ddlUnit">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnUnit" Value='<%#DataBinder.Eval(Container.DataItem, "UnitId")%>'
                                runat="server" />
                        </EditItemTemplate>
                        <HeaderStyle Width="60px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wastage%" ItemStyle-CssClass="TextColor" HeaderStyle-Width="60px">
                        <ItemTemplate>
                        <asp:Label ID="lblwastage" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "wastage_")%>'></asp:Label>
                           <%-- <p>
                                <%#DataBinder.Eval(Container.DataItem, "wastage_")%>
                            </p>--%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWastage" MaxLength="5" onkeypress="return isNumberKeyfloat(event, this)"
                                Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "wastage_")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Griege GST %" ItemStyle-CssClass="TextColor" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lblGriegeGSTNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GriegeGST")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGriegeGSTNo" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "GriegeGST")%>'
                                runat="server" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Process GST %" ItemStyle-CssClass="TextColor" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lblProcessGSTNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProcessGST")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProcessGSTNo" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "ProcessGST")%>'
                                runat="server" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="GST %" ItemStyle-CssClass="TextColor" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lblFinishGSTNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GST")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFinishGSTNo" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "GST")%>'
                                runat="server" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle CssClass="TextColor" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" ToolTip="Edit this"
                                CommandName="Edit" runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                CommandName="Update" runat="server" />
                            <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                Style="width: 25px;" CommandName="Cancel" runat="server" />
                        </EditItemTemplate>
                        <ItemStyle CssClass="border_right_color" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    No Record Found
                </EmptyDataTemplate>
            </asp:GridView>
            <div style="margin-top: 5px; text-align: right;">
            </div>
            <div>
                <asp:Button ID="btnPrint" Visible="false" Text="Print" CssClass="da_submit_button"
                    runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" ID="pnlError" Visible="false">
        <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10" class="da_table_heading_bg_left">
                    &nbsp;
                </td>
                <td width="1205" class="da_table_heading_bg">
                    <span class="da_h1">Confirmation</span>
                </td>
                <td width="13" class="da_table_heading_bg_right">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div class="form_box">
            <div class="text-content">
                Data has Been Saved Successfully
                <br />
                <a id="A2" href="~/Admin/Categories/ManageCategoryListing.aspx" runat="server">Click
                    here</a> to Category List.</div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMessage" Visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="1205" class="ColorAndAlign">
                    <span class="da_h1">&nbsp; Confirmation</span>
                </td>
            </tr>
        </table>
        <div class="form_box">
            <div class="text-content">
                Category have been saved into the system successfully!
                <br />
                <a id="A1" href="~/Admin/Categories/ManageCategoryListing.aspx" runat="server">Click
                    here</a> to Category List.</div>
        </div>
    </asp:Panel>
    <div id="dvHistory" class="modalNew">
        <div class="modal-content">
            <div class="HistoryHeader">
                <span id="Historytitle"></span><span style="float: right; padding: 0px 3px; cursor: pointer;"
                    onclick="SpiltContactClose();">X</span>
            </div>
            <div id="HistoryDescription">
            </div>
        </div>
        <div style="clear: both">
            <asp:HiddenField ID="HndUserid" Value="-1" runat="server" />
        </div>
    </div>
</div>
