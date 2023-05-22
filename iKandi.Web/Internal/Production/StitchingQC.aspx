<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StitchingQC.aspx.cs" Inherits="iKandi.Web.Internal.Production.StitchingQC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi.css" />
    <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi1.css" />
    <style type="text/css">
        .delete-current-slot-data
        {
            background: none;
            border: none;
            padding: 0px;
            font-size: 10px;
            float: left;
            color: blue;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/date.js")%>'></script>
    <script type="text/javascript">
        $(function () {
            initializer();
            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                //you need to re-bind your jquery events here
                initializer();
            });

        });

        function initializer() {
       
            $(".Faults").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100 });
            $(".Faults").result(function () {
                //debugger;            
                var This = $(this);
                var Faults = $(this).val();
                ValidateFaults(Faults, This);
            });
        };

        function CheckValidFault(elem) {
            debugger; 
                   
            var Faults = elem.value;
            var SearchContext = 'NatureOfFaults';
            if (Faults != '') {
                proxy.invoke("check_for_auto_complete", { searchValue: Faults, searchContext: SearchContext },
            function (result) {
                // debugger;
                if (result == '0') {
                    elem.value = '';
                    //jQuery.facebox('This is not valid faults');

                }
            });
            }
        }

        function ValidateFaults(Faults, This) {
            //debugger;
            var elemId = This.attr('id').split("_")[1];
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var txtFaults = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults" + "']").val();
                if (elemId != gvId) {
                    if (txtFaults == Faults) {
                        jQuery.facebox('Fault already exist!');
                        This.val('');
                        return false;
                    }
                }
            }
            var FooterRowId = '';
            GridRow = GridRow + 2;
            if (GridRow < 10)
                FooterRowId = 'ctl0' + GridRow;
            else
                FooterRowId = 'ctl' + GridRow;

            var txtFaults = $("#<%= grdQC.ClientID %> input[id*='" + FooterRowId + "_txtFaults_Footer" + "']").val();
            if (elemId != FooterRowId) {
                if (txtFaults == Faults) {
                    jQuery.facebox('Fault already exist!');
                    This.val('');
                    return false;
                }
            }
        }

        function ValiDateFaultData(elem, type) {
            var Ids = elem.id;
            var gvId = Ids.split("_")[1];
            var pcsChecked = parseInt($('#pcsChecked').val());

            if (type == 'Empty') {
                var txtFaults = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults_Empty" + "']").val();
                if (txtFaults == '') {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults_Empty" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please fill Fault code detail!');
                    return false;
                }
                var FaultCount = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount_Empty" + "']").val();
                if (FaultCount == '' || parseInt(FaultCount) < 1 || parseInt(FaultCount) > pcsChecked) {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount_Empty" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please enter fail count betweem 1 to ' + pcsChecked);
                    return false;
                }
            }
            if (type == 'Footer') {
                var txtFaults = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults_Footer" + "']").val();
                if (txtFaults == '') {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults_Footer" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please fill Fault code detail!');
                    return false;
                }

                var FaultCount = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount_Footer" + "']").val();
                if (FaultCount == '' || parseInt(FaultCount) < 1 || parseInt(FaultCount) > pcsChecked) {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount_Footer" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please enter fail count betweem 1 to ' + pcsChecked);
                    return false;
                }
            }
        }
        function ValidateDataOnSubmit() {
            //debugger;
            var ddlQC = '<%=ddlQC.ClientID %>';
            var QCVal = $("#" + ddlQC).val();
            if (QCVal == '0') {
                $("#" + ddlQC).css({ 'background': '#f5f59f' });
                jQuery.facebox('Please Select QC!');
                return false;
            }

            var RowId = 0;
            var gvId;
            var gvIdFooter;
            var GridRow = $(".gvRow").length;

            var FaultCount_Empty = parseInt($("#grdQC_ctl01_txtFaultCount_Empty").val());
            if (GridRow == 0 && (FaultCount_Empty == 0 || FaultCount_Empty > parseInt($('#pcsChecked').val()))) {
                $("#grdQC_ctl01_txtFaultCount_Empty").css({ 'background': '#f5f59f' });
                jQuery.facebox('Failed Count can not be 0 or greater than Pcs Checked');
                return false;
            }

            var txtFault_Empty = $("#grdQC_ctl01_txtFaults_Empty").val();
            if (GridRow == 0 && txtFault_Empty == '' && $("#grdQC_ctl01_txtFaultCount_Empty").val() != '') {
                $("#grdQC_ctl01_txtFaults_Empty").css({ 'background': '#f5f59f' });
                jQuery.facebox('Please fill Fault code detail!');
                return false;
            }

            if ($('#pcsChecked').val() == '' || $('#pcsChecked').val() == '0') {
                $("#pcsChecked").css({ 'background': '#f5f59f' });
                jQuery.facebox('Pcs Checked can not be empty or 0');
                return false;
            }

            if ($('#pcsFailed').val() == '' || parseInt($('#pcsFailed').val()) > parseInt($('#pcsChecked').val())) {
                $("#pcsFailed").css({ 'background': '#f5f59f' });
                jQuery.facebox('Pcs Failed can not be empty or greater than Pcs Checked');
                return false;
            }

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10) {
                    gvId = 'ctl0' + RowId;
                    gvIdFooter = 'ctl0' + (RowId + 1);
                }
                else {
                    gvId = 'ctl' + RowId;
                    gvIdFooter = 'ctl' + (RowId + 1);
                }

                var txtFaults = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults" + "']").val();
                if (txtFaults == '') {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaults" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please fill Fault code detail!');
                    return false;
                }

                var FaultCount = $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount" + "']").val();
                if (FaultCount == '' || parseInt(FaultCount) < 1 || parseInt(FaultCount) > parseInt($('#pcsChecked').val())) {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvId + "_txtFaultCount" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please enter fail count betweem 1 to ' + $('#pcsChecked').val());
                    return false;
                }

                var FaultCountFooter = $("#<%= grdQC.ClientID %> input[id*='" + gvIdFooter + "_txtFaultCount_Footer" + "']").val();
                var FaultFooter = $("#<%= grdQC.ClientID %> input[id*='" + gvIdFooter + "_txtFaults_Footer" + "']").val();
                if (FaultFooter != '' && (FaultCountFooter == '' || parseInt(FaultCountFooter) < 1 || parseInt(FaultCountFooter) > parseInt($('#pcsChecked').val()))) {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvIdFooter + "_txtFaultCount_Footer" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please enter fail count betweem 1 to ' + parseInt($('#pcsChecked').val()));
                    return false;
                }

                if (FaultCountFooter != '' && FaultFooter == '') {
                    $("#<%= grdQC.ClientID %> input[id*='" + gvIdFooter + "_txtFaults_Footer" + "']").css({ 'background': '#f5f59f' });
                    jQuery.facebox('Please fill Fault code detail!');
                    return false;
                }

            }
        }

        function EmptyFault() {
            jQuery.facebox('Please add atleast one fault!');
            return false;
        }

        function SavedSuccessfully() {
            // debugger;
            alert('Saved Successfully.');
            self.parent.Shadowbox.close();
        }

        function CheckAll(elem) {
            // debugger;
            if ($(elem).is(':checked')) {
                // debugger;
                $('.chkRow').find("input[type=checkbox]").attr('checked', 'checked');
            }
            else {
                // debugger;           
                $('.chkRow').find("input[type=checkbox]").attr('checked', false);
            }

        }

        function DeleteSuccessfully() {
            //  debugger;
            alert('Deleted Successfully.');
            self.parent.Shadowbox.close();
        }

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 || iKeyCode == 46))
                return false;

            return true;
        }    
    </script>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div style="padding: 2px 0px; padding-left: 0px; background-color: #405D99; color: #FFFFFF;
                    font-weight: bold; font-size: 14px; text-transform: none; width: 97%; margin: 0px auto;
                    margin-right: 15px; text-align: center;">
                    <div style="float: left; font-size: 10px;text-align:left; padding-left: 5px;width:35%">
                        <asp:Label ID="lblLineNo" runat="server" Text=""></asp:Label>,&nbsp;
                        <asp:Label ID="lblSerialNo" runat="server" Text=""></asp:Label>
                    </div>
                    QC Update
                    <div style="float:right;width:42%">
                        <div style=" font-size: 10px;float:left; padding-right: 0px;">
                            Pcs Checked :
                            <asp:TextBox ID="pcsChecked" runat="server" MaxLength="3" Width="27px" onkeypress="javascript:return isNumber(event)">5</asp:TextBox>
                        </div>
                        <div style="font-size: 10px; padding-right: 0px;">
                            Pcs Failed :
                            <asp:TextBox ID="pcsFailed" runat="server" MaxLength="3" Width="27px" onkeypress="javascript:return isNumber(event)">0</asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="height: 5px;">
                </div>
                <table border="1px" style="border-color: Gray; margin: 0PX 6PX 0PX 5PX;" width="96%"
                    cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td>
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rbtnFMFI" runat="server" Style="float: left;
                                padding-right: 27px;" CellPadding="0" CellSpacing="0">
                                <asp:ListItem Text="FM" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="FI" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                            <div style="clear: both;">
                            </div>
                        </td>
                        <td style="width: 250PX;">
                            <div style="width: 100px; margin-left: 5px; vertical-align: text-bottom; float: left;
                                padding-top: 2px;">
                                FM/FI Decision:
                            </div>
                            <asp:RadioButtonList ID="rbtnPassFail" RepeatDirection="Horizontal" runat="server"
                                CellPadding="0" CellSpacing="0">
                                <asp:ListItem Text="Pass" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Rescan" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp; QC: &nbsp;
                            <asp:DropDownList ID="ddlQC" Width="130px" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="height: 5px;">
                </div>
                <div style="margin-left: 0px;">
                    <asp:GridView ID="grdQC" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                        ShowFooter="true" Width="96%" RowStyle-ForeColor="#7E7E7E" CssClass="item_list2"
                        Style="margin: 0PX 6PX 0PX 5PX;" OnRowCommand="grdQC_RowCommand" OnRowDataBound="grdQC_RowDataBound">
                        <RowStyle CssClass="gvRow" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="300px" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    Fault Code Detail</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFaults" onpaste="return false;" CssClass="Faults" MaxLength="100"
                                        Style="text-align: left; text-transform: capitalize;" onblur="javascript:return CheckValidFault(this);"
                                        Text='<%# Eval("FaultCode") %>' Width="100%" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnFaults" Value='<%# Eval("FaultCode") %>' runat="server" />
                                    <asp:HiddenField ID="hdnQCId" Value='<%# Eval("QCSlotWiseId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnQCFaultsId" Value='<%# Eval("QCSlotWiseFaultsId") %>' runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFaults_Footer" onpaste="return false;" onblur="javascript:return CheckValidFault(this);"
                                        CssClass="Faults" Style="text-align: left; text-transform: capitalize;" Width="100%"
                                        MaxLength="100" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px">
                                <HeaderTemplate>
                                    Failed Count</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFaultCount" Width="100%" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                    <asp:HiddenField ID="hdnOBOperation" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFaultCount_Footer" Width="100%" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterStyle-Width="30px" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    Delete All
                                    <asp:CheckBox ID="chkDeleteAll" CssClass="chkHeader" OnClick="javascript:CheckAll(this)"
                                        runat="server" /></HeaderTemplate>
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/del-butt.png" OnClientClick="return confirm('Are you sure you want to delete?');"  CommandName="Delete" />  --%>
                                    <asp:CheckBox ID="chkDelete" CssClass="chkRow" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnAdd_Footer" runat="server" ImageUrl="~/images/add-butt.png"
                                        OnClientClick="javascript:return ValiDateFaultData(this, 'Footer');" CommandName="AddFooter" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" class="item_list2" rules="none" border="0">
                                <tr>
                                    <th>
                                        Fault Code Detail
                                    </th>
                                    <th>
                                        Failed Count
                                    </th>
                                    <th>
                                        Add
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 300px">
                                        <asp:TextBox ID="txtFaults_Empty" Style="text-align: left; text-transform: capitalize;"
                                            Text="" Width="100%" CssClass="Faults" onblur="javascript:return CheckValidFault(this);"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 60px">
                                        <asp:TextBox ID="txtFaultCount_Empty" Width="100%" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                    </td>
                                    <td style="width: 30px;">
                                        <asp:ImageButton ID="btnAdd_Empty" runat="server" ImageUrl="~/images/add-butt.png"
                                            OnClientClick="javascript:return ValiDateFaultData(this, 'Empty');" CommandName="AddEmpty" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div style="margin: 10px auto; text-align: center; width: 97%; margin-right: 15px;">
                    <asp:Button ID="btnDeleteCurrentSlotDetail" runat="server" CssClass="delete-current-slot-data"
                        Text="Delete Current Slot Detail" OnClick="btnDeleteCurrentSlotDetail_Click"
                        OnClientClick="return confirm('Are you sure you want to delete?')" />
                    <asp:Button ID="btnSubmit" runat="server" title="Save record !" OnClientClick="javascript:return ValidateDataOnSubmit();"
                        CssClass="do-not-include submit tooltip" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                        Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
