<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFabricInHouseEntry.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.frmFabricInHouseEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>
    <style type="text/css">
        input[type=radio]
        {
            vertical-align: middle;
        }
        img
        {
            vertical-align: middle;
        }
        
        body
        {
            font-size: 11px;
            font-family: Arial;
        }
        
        .table-wrap
        {
            width: 500px;
            max-height: 109px;
            overflow: auto;
            z-index: 1;
            overflow-x: hidden;
        }
        .header-class
        {
            color: White;
            background-color: #405D99;
            font-size: 13px;
            font-weight: bold;
            height: 35px;
        }
        .border-top td
        {
            border-top: 0px;
        }
        .border-bottom
        {
            border-bottom-color: #F0F3F2;
            border-bottom: 1px solid #f0f3f2 !important;
        }
        table.item_list2
        {
            margin: auto;
            text-transform: capitalize;
        }
        input[type="text"], textarea, select
        {
            text-transform: capitalize;
        }
        .challandiv
        {
            background-color: White;
            border-bottom: 1px solid #cccccc;
            text-align: center;
        }
        select
        {
            text-align: center;
            height: 20px;
        }
        .gray
        {
            color: Gray;
        }
        .black
        {
            color: black;
        }
        .blue
        {
            color: blue;
        }
        .orange
        {
            color: orange;
        }
        .red
        {
            color: red;
        }
        .challan-parent
        {
            padding: 0px !important;
        }
        .challan-parent span .challandiv:last-child
        {
            border: 0px;
        }
        input[type="checkbox"]
        {
            vertical-align: middle;
        }
        .header td
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize;
            border: 1px solid #cccccc;
            text-align: center;
            padding: 5px;
            font-weight: normal;
        }
         .Refill
        { 
            background-color: red !important;
        }
       .Refill:hover
        { 
            background-color: red !important;
        }
    </style>
    <script type="text/javascript">

        function pageLoad() {
            $(function () {
                $(".th").datepicker({ dateFormat: 'dd-mm-yy' });
                $('.tooltip').tooltipster();

                var rowCount = $("[id*=grdFabricInhouse] td").closest("tr").length;
                if (Math.abs(rowCount - 2) <= 0) {
                    $('#txtissue_issue').attr('disabled', 'disabled');
                    $('#txtissue_challan').attr('disabled', 'disabled');
                    $('#chkIsissue').attr('disabled', 'disabled');
                }
            });
            $('input[type="checkbox"]').click(function () {
                //debugger;
                var id = $(this).attr('id');
                if (id == "ChlIsInHouse") {

                }
                if (id == "ChlIsInHouse") {
                    if ($(this).is(":checked")) {

                        $('#txtInhouse').removeAttr('disabled');
                        $('#txtInhouse').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtInhouse').attr('disabled', 'disabled');
                        $("#txtInhouse").val("");
                        $("#txtInhouse").attr('title', 'please select in house for make entry');
                    }
                }
                if (id == "chkIsissue") {
                    if ($(this).is(":checked")) {

                        $('#txtissue_issue').removeAttr('disabled');
                        $('#txtissue_issue').removeAttr('title');

                        $('#txtissue_challan').removeAttr('disabled');
                        $('#txtissue_challan').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtissue_issue').attr('disabled', 'disabled');
                        $("#txtissue_issue").val("");
                        $("#txtissue_issue").attr('title', 'please select issue for make entry');

                        $('#txtissue_challan').attr('disabled', 'disabled');
                        $("#txtissue_challan").val("");
                        $("#txtissue_challan").attr('title', 'please select issue for make entry');
                    }
                }
                if (id == "ChkHoldchk") {
                    if ($(this).is(":checked")) {
                        $('#txtonhold').removeAttr('disabled');
                        $('#txtonhold').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtonhold').attr('disabled', 'disabled');
                        $("#txtonhold").val("");
                        $("#txtonhold").attr('title', 'please select onhold for make entry');
                    }
                }
                if (id == "chkRjectchk") {
                    if ($(this).is(":checked")) {
                        $('#txtreject').removeAttr('disabled');
                        $('#txtreject').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtreject').attr('disabled', 'disabled');
                        $("#txtreject").val("");
                        $("#txtreject").attr('title', 'please select onhold for make entry');
                    }
                }

                else {


                    if ($(this).is(":checked")) {
                        $('.addnewrwo').attr('disabled', 'disabled');
                        //$("#txtreject").attr('title', 'please select onhold for make entry'); 
                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('.addnewrwo').removeAttr('disabled');
                        // $('#txtreject').removeAttr('title');
                    }
                }
            });
        }
        $(function () {
            $('#txtissue_challan').keydown(function (e) {
                //                    if (e.shiftKey || e.ctrlKey || e.altKey) {
                //                        e.preventDefault();
                //                    } else {
                var key = e.keyCode;
                // alert(key)
                if (key == 188) {
                    e.preventDefault();
                }
                //}
            });
        });
        //   }

        $(document).ready(function () {
            // ValidateCutIssueEntryQty();
            var rowCount = $("[id*=grdFabricInhouse] td").closest("tr").length;
            if (Math.abs(rowCount - 2) <= 0) {
                $('#txtissue_issue').attr('disabled', 'disabled');
                $('#txtissue_challan').attr('disabled', 'disabled');
                $('#chkIsissue').attr('disabled', 'disabled');
            }

            //alert(rowCount);
            $('input[type="checkbox"]').click(function () {
                //debugger;
                var id = $(this).attr('id');
                if (id == "ChlIsInHouse") {

                }
                if (id == "ChlIsInHouse") {
                    if ($(this).is(":checked")) {

                        $('#txtInhouse').removeAttr('disabled');
                        $('#txtInhouse').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtInhouse').attr('disabled', 'disabled');
                        $("#txtInhouse").val("");
                        $("#txtInhouse").attr('title', 'please select in house for make entry');
                    }
                }
                if (id == "chkIsissue") {
                    if ($(this).is(":checked")) {

                        $('#txtissue_issue').removeAttr('disabled');
                        $('#txtissue_issue').removeAttr('title');

                        $('#txtissue_challan').removeAttr('disabled');
                        $('#txtissue_challan').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtissue_issue').attr('disabled', 'disabled');
                        $("#txtissue_issue").val("");
                        $("#txtissue_issue").attr('title', 'please select issue for make entry');

                        $('#txtissue_challan').attr('disabled', 'disabled');
                        $("#txtissue_challan").val("");
                        $("#txtissue_challan").attr('title', 'please select issue for make entry');
                    }
                }
                if (id == "ChkHoldchk") {
                    if ($(this).is(":checked")) {
                        $('#txtonhold').removeAttr('disabled');
                        $('#txtonhold').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtonhold').attr('disabled', 'disabled');
                        $("#txtonhold").val("");
                        $("#txtonhold").attr('title', 'please select onhold for make entry');
                    }
                }
                if (id == "chkRjectchk") {
                    if ($(this).is(":checked")) {
                        $('#txtreject').removeAttr('disabled');
                        $('#txtreject').removeAttr('title');

                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('#txtreject').attr('disabled', 'disabled');
                        $("#txtreject").val("");
                        $("#txtreject").attr('title', 'please select onhold for make entry');
                    }
                }

                else {


                    if ($(this).is(":checked")) {
                        $('.addnewrwo').attr('disabled', 'disabled');
                        //$("#txtreject").attr('title', 'please select onhold for make entry'); 
                    }
                    else if ($(this).is(":not(:checked)")) {
                        $('.addnewrwo').removeAttr('disabled');
                        // $('#txtreject').removeAttr('title');
                    }
                }
            });

        });
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;


            return true;
        }
        $(function () {
            $(".th").datepicker({ dateFormat: 'dd-mm-yy' });
        });
        $(function () {
            $('#txtissue_challan').keydown(function (e) {
                //                if (e.shiftKey || e.ctrlKey || e.altKey) {
                //                    e.preventDefault();
                //                } else {
                var key = e.keyCode;
                //  alert(key);
                //                    if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                //                        e.preventDefault();
                //   
                //}
                if (key == 188) {
                    e.preventDefault();
                }
                //}
            });
        });
        function alertMessage(dd) {
            // debugger; 
            //            var issue = document.getElementById('txtissue_issue').value;
            //            var hold = document.getElementById('txtonhold').value;
            //            var reject = document.getElementById('txtreject').value;
            //            issue = (issue == "" ? 0 : issue);
            //            hold = (hold == "" ? 0 : hold);
            //            reject = (reject == "" ? 0 : reject);
            //            dd = (parseInt(dd)) - (parseInt(issue) + parseInt(hold) + parseInt(reject));

            alert("You cannot enter qty more then available inhouse qty extra enterd qty.: " + Math.abs(dd));
        }
        function alertMessage2(dd) {
            alert("You cannot enter qty more then available inhouse qty.");
        }
        function Showalert() {
            alert('Inhouse quantity cannot be less then sum of other quantity.');
        }
    </script>
</head>
<body>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        function ValidateExsitingPlannedDate(elem) {
            debugger;
            alert(elem);
            var datee = elem;
            //alert(FrameNo);
            var OrderDetailIDs = 13384;
            var FabricTypes = 1;

            proxy.invoke("ValidateExsitingPlannedDate", { dates: datee, OrderDetailID: OrderDetailIDs, FabricType: FabricTypes }, function (result) {
                if (result > 0) {


                    // window.location.reload();

                }
            }, onPageError, false, false);

        }

        function ValidateCutIssueEntryQty(CutIssueVal) {
            var InHouseQty = $('.CssInHouseQty').attr("value");
            var CutIssueQty = $('.CssCutIssueQty').attr("value");
            var IssueQty = 0; var CutissueQty = 0;
            //debugger;
            var grid = document.getElementById("<%= grdFabricInhouse.ClientID%>");
            for (var i = 2; i <= grid.rows.length - 1; i++) {
                var ID;
                var RowID;

                if (i <= 9) {
                    ID = "grdFabricInhouse_ctl0" + i + "_lblInHouse";
                }
                else {
                    ID = "grdFabricInhouse_ctl" + i + "_lblInHouse";
                }
                RowID = ID.split("_")[1].substr(3, 4);
                var vals = $("#<%= grdFabricInhouse.ClientID %> span[id*='ctl" + RowID + "_lblInHouse" + "']").html().replace(',', '');
                var CutissueQtySum = $("#<%= grdFabricInhouse.ClientID %> span[id*='ctl" + RowID + "_lblQty" + "']").html().replace(',', '');
                if (vals != '') {
                    IssueQty = IssueQty + parseInt(vals);
                }
                if (CutissueQtySum != '') {
                    CutissueQty = CutissueQty + parseInt(CutissueQtySum);
                }
                //alert(vals + "_" + CutissueQty);
            }
            var TotalavailableQty = IssueQty - CutissueQty;
            if (TotalavailableQty != 0) {

                if (CutIssueVal > TotalavailableQty) {
                    alert("You cannot enter issued qty more than total inhouse qty. Available qty,: " + TotalavailableQty);

                    document.getElementById('txtissue_issue').value = "";
                    return false;
                    //$('.submit').attr('disabled', 'disabled');         
                }
                else {
                    //$('#submit').removeAttr('disabled');
                    return true;
                }
            }
            else {
                return true;
            }

        }
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            confirm_value.value = "";
            confirm_value.value = "";
            if (confirm("Do you want delete?")) {
                confirm_value.value = "Yes";
            } else {

                confirm_value.value = "No";
                // return false;
            }
            document.forms[0].appendChild(confirm_value);

        }
      
    </script>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnorderdeta" runat="server" Value="0" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="Updatepanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="Updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div id="divfb" runat="server">
                <br />
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 95%"
                    align="center">
                    <tr>
                        <td style="padding: 3px 0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                            font-size: 16px; text-transform: none;" colspan="6">
                            Fabric Entry
                        </td>
                        <caption>
                        </caption>
                    </tr>
                </table>
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 95%"
                    align="center">
                    <tr>
                        <th style="width: 15%">
                            Required
                        </th>
                        <th style="width: 15%">
                            Inhouse &nbsp;
                            <asp:CheckBox ID="ChlIsInHouse" Checked="false" CssClass="inhousechk" runat="server" />
                        </th>
                        <th colspan="2">
                            Issued &nbsp;
                            <asp:CheckBox ID="chkIsissue" Checked="false" CssClass="Isissuechk" runat="server" />
                        </th>
                        <th style="width: 15%">
                            OnHold &nbsp;
                            <asp:CheckBox ID="ChkHoldchk" Checked="false" CssClass="inHoldchk" runat="server" />
                        </th>
                        <th style="width: 15%">
                            Reject &nbsp;
                            <asp:CheckBox ID="chkRjectchk" Checked="false" CssClass="Rjectchkchk" runat="server" />
                        </th>
                        <td rowspan="2" style="width: 10%">
                            <asp:Button ID="btnadd" Style="vertical-align: top" runat="server" CssClass="submit"
                                Text="Add" OnClick="btnadd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <%-- <asp:TextBox ID="txtReuired" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblReuired" Style="text-align: center;" class="gray" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInhouse" Enabled="false" Text="" Style="text-align: center;"
                                placeholder="Inhouse" class="gray" onkeypress="return isNumberKey(event);" MaxLength="5"
                                runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td style="width: 15%">
                        <%--onchange="javascript:ValidateCutIssueEntryQty(this.value)"--%>
                            <asp:TextBox ID="txtissue_issue" 
                                Enabled="false" Text="" class="gray" Style="text-align: center" placeholder="issue"
                                onkeypress="return isNumberKey(event);" MaxLength="5" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtissue_challan" Enabled="false" Text="" Style="text-align: center;
                                text-transform: capitalize;" class="gray" placeholder="challan" ondrop="return false;"
                                onpaste="return false;" MaxLength="20" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtonhold" Enabled="false" Text="" Style="text-align: center" placeholder="onhold"
                                onkeypress="return isNumberKey(event);" class="gray" MaxLength="5" runat="server"
                                Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtreject" Enabled="false" Text="" Style="text-align: center" placeholder="reject"
                                onkeypress="return isNumberKey(event);" class="gray" MaxLength="5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 95%"
                    align="center">
                    <tr>
                        <th rowspan="2" style="width: 16.5%;">
                            Date
                        </th>
                        <th rowspan="2" style="width: 16.5%;">
                            Inhouse Qty
                        </th>
                        <th colspan="2">
                            Issued
                        </th>
                        <th rowspan="2" style="width: 16.5%;">
                            Onhold
                        </th>
                        <th rowspan="2" style="width: 16.5%;">
                            Reject
                        </th>
                    </tr>
                    <tr>
                        <th style="width: 14%;">
                            Qty
                        </th>
                        <th style="width: 19%;">
                            Challan
                        </th>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" style="padding: 0px;">
                            <asp:GridView ID="grdFabricInhouse" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                RowStyle-HorizontalAlign="Center" OnRowDataBound="grdFabricInhouse_RowDataBound"
                                Width="100%" RowStyle-ForeColor="#7E7E7E" CssClass="item_list2" frame="void"
                                rules="all">
                                <Columns>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEntryDate" CssClass="gray" Text='<%#Eval("EntryInHoseDates") %>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="16.5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                         <div style="float: right; width: 30%;">
                                                <asp:ImageButton ID="hypedit" Style="cursor: pointer; float: right;" class="tooltip"
                                                    title="Edit Qty !" Visible='<%# (Convert.ToString(Eval("EntryInHoseDates")) == "Pending Required" || Convert.ToString(Eval("EntryInHoseDates")) == "Total" ) ? false : true %>'
                                                    runat="server" OnClick="hypedit_Click" ImageUrl="../../images/edit.png" Text=""
                                                    CommandName="edit" />
                                            </div>
                                            <asp:Label ID="lblInHouse" Text='<%# (Convert.ToString(Eval("InHouseQty")) == "" || Convert.ToString(Eval("InHouseQty")) == "0") ? "" : Convert.ToInt32(Eval("InHouseQty")).ToString("N0")%>'
                                                CssClass="CssInHouseQty black" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="16.5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" Text='<%# (Convert.ToString(Eval("IssueQty")) == "" || Convert.ToString(Eval("IssueQty")) == "0") ? "" : Convert.ToInt32(Eval("IssueQty")).ToString("N0")%>'
                                                CssClass="CssCutIssueQty black" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallan" CssClass="gray" Text='<%#Eval("ChallanQty") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="19%" CssClass="challan-parent" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                           
                                            <div style="float: left; width: 65%">
                                                <asp:Label ID="lblOnhold" CssClass="orange" Text='<%# (Convert.ToString(Eval("OnHoldQty")) == "" || Convert.ToString(Eval("OnHoldQty")) == "0") ? "" : Convert.ToInt32(Eval("OnHoldQty")).ToString("N0")%>'
                                                    runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="16.5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReject" CssClass="red" Text='<%# (Convert.ToString(Eval("RejectQty")) == ""|| Convert.ToString(Eval("RejectQty")) == "0") ? "" : Convert.ToInt32(Eval("RejectQty")).ToString("N0")%>'
                                                ForeColor="Red" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="16.5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 95%"
                    align="center">
                    <tr>
                        <td style="padding: 3px 0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                            font-size: 16px; text-transform: none;" colspan="6">
                            Fabric Planned Inhouse
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 16.5%">
                            Inhouse
                        </th>
                        <td style="width: 16.5%">
                            <asp:Label ID="lblinhouse_FabInHouseTotalQty" CssClass="black" runat="server"></asp:Label>
                        </td>
                        <th style="width: 16.5%">
                            Required
                        </th>
                        <td style="width: 16.5%">
                            <asp:Label ID="lblinhouse_ReqQty" CssClass="black" runat="server"></asp:Label>
                        </td>
                        <th style="width: 16.5%">
                            Pending
                        </th>
                        <td style="width: 16.5%">
                            <asp:Label ID="lblinhouse_Pending" CssClass="black" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grdfabInhousePlanned" runat="server" AutoGenerateColumns="false"
                    ShowHeader="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false"
                    HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-HorizontalAlign="Center"
                    ShowFooter="true" Width="95%" OnPreRender="grdfabInhousePlanned_PreRender" CssClass="item_list2"
                    OnRowDataBound="grdfabInhousePlanned_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Planned ETA" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnP_ID" Value='<%#Eval("P_Id") %>' runat="server" />
                                <asp:HiddenField ID="hdnplannedETA" Value='<%#Eval("PlannedETA") %>' runat="server" />
                                <asp:TextBox ID="txtplannedETA" Text='<%#Eval("PlannedETA") %>' runat="server" Style="height: 15px;
                                    text-align: center" Font-Bold="true" class="th black" OnTextChanged="TxtId_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delayed Days" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnP_DelaysDays" Value='<%#Eval("DelaysDays") %>' runat="server" />
                                <asp:DropDownList ID="ddldelaysday" runat="server" CssClass="blue">
                                    <asp:ListItem Selected="True" Value="-1">Days</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" Text='<%# (Convert.ToString(Eval("Quantity")) == ""||Convert.ToString(Eval("Quantity")) == "0") ? "" : Convert.ToInt32(Eval("Quantity")).ToString("N0")%>'
                                    runat="server" CssClass="black" onkeypress="return isNumberKey(event);" Style="text-align: center;
                                    height: 15px; text-align: center; font: bold" MaxLength="6"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Complete" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="margin: 0px auto; width: 40px;">
                                    <div style="float: left; width: 20px;">
                                        <asp:HiddenField ID="hdnisComplete" Value='<%#Eval("IsComplete") %>' runat="server" />
                                        <asp:CheckBox title="Click here for make entry is complete !" ID="ChkIscomplete"
                                            CssClass="iscompletes tooltip" Visible="false" runat="server" Checked="false" />
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton ID="imgRow" class="tooltip" title="Delete record!" OnClientClick="Confirm()"
                                            OnClick="btnDelete_Click" CommandName="delete" runat="server" Style="vertical-align: middle;"
                                            ImageUrl="../../images/del-butt.png" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="25%" HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:ImageButton Style="width: 15px !important;" title="Add new row !" ID="btnAddnew"
                                    CssClass="addnewrwo tooltip" runat="server" ImageUrl="../../images/icon.jpg"
                                    OnClick="btnAddnew_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div style="margin: 10px auto; text-align: center">
                    <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
                        Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                        Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                         <asp:Button ID="btnRecreate" runat="server" title="Scrap and Refill !" CssClass="do-not-include submit Refill tooltip"
                        Text="Scrap and Refill" OnClick="btnRecreate_Click" />
                </div>
            </div>
            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server">
                <br />
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" border="0" style="width: 95%"
                    align="center">
                    <tr>
                        <td style="padding: 0px 0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                            font-size: 16px; text-transform: none; border: 0px;">
                            Manage Onhold Quantity<asp:Label ID="lbloverallinhouseQty" runat="server" Text="1200" style="float:right;"></asp:Label>
                            <asp:HiddenField ID="hdninhouseqty" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="border: 0px; padding: 0px;">
                     
                            <asp:GridView ID="grdfabinhouse_resuffle" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" Width="100%"
                                OnRowDataBound="grdfabinhouse_resuffle_RowDataBound" OnRowCreated="grdfabinhouse_resuffle_RowCreated" CssClass="item_list2">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sequence" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            <asp:HiddenField ID="hdndate" runat="server" Value='<%#Eval("EntryInHoseDate") %>' />
                                            <asp:HiddenField ID="p_id" runat="server" Value='<%#Eval("p_id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEntryDate" Text='<%#Eval("EntryInHoseDates") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inhouse Qty" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            Inhouse Qty
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblInHouseQty" tital="In house qty" Text='<%# (Convert.ToString(Eval("InHouseQty")) == "" || Convert.ToString(Eval("InHouseQty")) == "0") ? "" : Convert.ToInt32(Eval("InHouseQty")).ToString("N0")%>'
                                                CssClass="CssInHouseQty tooltip" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inhouse Qty Sub" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            (-) Subtract
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <div>
                                            <asp:TextBox ID="txtInhousesub" title='<%# "Enter qty could not be more then inhouse qty:" + DataBinder.Eval(Container.DataItem, "InHouseQty")%>'
                                                onkeypress="return isNumberKey(event);" Style="text-align: center; height: 15px;
                                                text-align: center; width: 83px; font: bold" Font-Size="12px" MaxLength="5"  OnTextChanged="txtInhousesub_TextChanged" CssClass="CssInHouseQty tooltip"
                                                runat="server" ></asp:TextBox><br />
                                            <asp:regularexpressionvalidator id="revInhouseQty" runat="server" errormessage="Must be greater than 0"
                                                controltovalidate="txtInhousesub" validationexpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$"
                                                Display="Dynamic" setfocusonerror="true" validationgroup="qtyholdcheck" xmlns:asp="#unknown">
                                            </asp:regularexpressionvalidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInhousesub"
                                                Display="Dynamic" ErrorMessage="You can't enter qty more than inhouse qty" Style="text-transform: capitalize;"
                                                ForeColor="Red" MaximumValue='<%# Convert.ToInt32(Eval("InHouseQty")) %>' MinimumValue="0"
                                                Type="Integer" ValidationGroup="qtyholdcheck" />
                                                </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issued Qty" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            Inhouse Qty
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssuedQty" tital="Issued qty" Text='<%# (Convert.ToString(Eval("IssueQty")) == "" || Convert.ToString(Eval("IssueQty")) == "0") ? "" : Convert.ToInt32(Eval("IssueQty")).ToString("N0")%>'
                                                CssClass="CssInHouseQty tooltip" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issued Qty Sub" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            (-) Subtract
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <div>
                                            <asp:TextBox ID="txtIssuedsub" title='<%# "Enter qty could not be more then inhouse qty:" + DataBinder.Eval(Container.DataItem, "InHouseQty")%>'
                                                onkeypress="return isNumberKey(event);" Style="text-align: center; height: 15px;
                                                text-align: center; width: 83px; font: bold" Font-Size="12px" MaxLength="5"  CssClass="CssInHouseQty tooltip"
                                                runat="server" ></asp:TextBox><br />
                                            <asp:regularexpressionvalidator id="revissuedQty" runat="server" errormessage="Must be greater than 0"
                                                controltovalidate="txtIssuedsub" validationexpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$"
                                                Display="Dynamic" setfocusonerror="true" validationgroup="qtyholdcheck" xmlns:asp="#unknown">
                                            </asp:regularexpressionvalidator>
                                            <asp:RangeValidator ID="RangeValidatorIssuedsub" runat="server" ControlToValidate="txtIssuedsub"
                                                Display="Dynamic" ErrorMessage="You can't enter qty more than inhouse qty" Style="text-transform: capitalize;"
                                                ForeColor="Red" MaximumValue='<%# (Convert.ToString(Eval("InHouseQty")) == "" || Convert.ToString(Eval("InHouseQty")) == "0") ? Convert.ToInt32(Eval("IssueQty")) : Convert.ToInt32(Eval("InHouseQty"))%>' MinimumValue="0"
                                                Type="Integer" ValidationGroup="qtyholdcheck" />
                                                </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hold Qty" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            Inhouse Qty
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblhold" Text='<%# (Convert.ToString(Eval("OnHoldQty")) == "" || Convert.ToString(Eval("OnHoldQty")) == "0") ? "" : Convert.ToInt32(Eval("OnHoldQty")).ToString("N0")%>'
                                                CssClass="CssInHouseQty" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hold Qty Sub" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            (-) Subtract
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtholdsub" title='<%# "Enter qty could not be more then hold qty:" + DataBinder.Eval(Container.DataItem, "OnHoldQty")%>'
                                                onkeypress="return isNumberKey(event);" Style="text-align: center; height: 15px;
                                                text-align: center; width: 83px; font: bold" Font-Size="12px" MaxLength="5" CssClass="CssInHouseQty tooltip"
                                                runat="server"></asp:TextBox><br />
                                            <asp:regularexpressionvalidator id="revAvailablePeriod" runat="server" errormessage="Must be greater than 0"
                                                controltovalidate="txtholdsub" validationexpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$"
                                                display="Dynamic" setfocusonerror="true" validationgroup="qtyholdcheck" xmlns:asp="#unknown">
                                            </asp:regularexpressionvalidator>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtholdsub"
                                                Display="Dynamic" ErrorMessage="You can't enter qty more than hold qty" Style="text-transform: capitalize;"
                                                ForeColor="Red" MaximumValue='<%# Convert.ToInt32(Eval("OnHoldQty")) %>' MinimumValue="0"
                                                Type="Integer" ValidationGroup="qtyholdcheck" />
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reject Qty" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreject" Text='<%# (Convert.ToString(Eval("RejectQty")) == "" || Convert.ToString(Eval("RejectQty")) == "0") ? "" : Convert.ToInt32(Eval("RejectQty")).ToString("N0")%>'
                                                CssClass="CssInHouseQty" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reject Qty Sub" ItemStyle-VerticalAlign="Top">
                                        <HeaderTemplate>
                                            (-) Subtract
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRejectQtysub" title='<%# "Enter qty could not be more then reject qty:" + DataBinder.Eval(Container.DataItem, "RejectQty")%>'
                                                onkeypress="return isNumberKey(event);" Style="text-align: center; height: 15px;
                                                text-align: center; width: 83px; font: bold" Font-Size="12px" MaxLength="5" CssClass="CssInHouseQty tooltip"
                                                runat="server"></asp:TextBox><br />
                                            <asp:regularexpressionvalidator id="revRejectQty" runat="server" errormessage="Must be greater than 0"
                                                controltovalidate="txtRejectQtysub" validationexpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$"
                                                display="Dynamic" setfocusonerror="true" validationgroup="qtyholdcheck" xmlns:asp="#unknown">
                                            </asp:regularexpressionvalidator>
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtRejectQtysub"
                                                Display="Dynamic" ErrorMessage="You can't enter qty more than reject qty" Style="text-transform: capitalize;"
                                                ForeColor="Red" MaximumValue='<%# Convert.ToInt32(Eval("RejectQty")) %>' MinimumValue="0"
                                                Type="Integer" ValidationGroup="qtyholdcheck" />
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td align="right" style="border: 0px;">
                            <asp:Button ID="Button2sav" ValidationGroup="qtyholdcheck" runat="server" title="Save record !"
                                CssClass="do-not-include submit tooltip" Text="Submit" OnClick="Button2sav_Click" />
                            <%-- <asp:Button ID="Button3" title="Close this popup !" runat="server" OnClientClick="javascript:self.parent.Shadowbox.close();"
                                CssClass="close da_submit_button tooltip" Text="Close" />--%>
                            <asp:Button ID="Button3close" Visible="false" title="Close this popup !" runat="server"
                                CssClass="close da_submit_button tooltip" Text="Close" OnClick="Button3close_Click" />
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
