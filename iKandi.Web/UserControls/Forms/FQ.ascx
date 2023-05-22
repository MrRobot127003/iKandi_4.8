<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FQ.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FQ" %>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: verdana;
    }
    table
    {
        font-family: verdana;
        border-color: gray;
        border-collapse: collapse;
    }
    th
    {
        background: #dddfe4;
        font-weight: normal;
        color: #575759;
        font-family: arial,halvetica;
        font-size: 10px;
        padding: 5px 0px 5px 0px;
        text-transform: capitalize;
        text-align: center;
        border: 1px solid #b7b4b4;
    }
    table td
    {
        font-size: 10px;
        text-align: center;
        border-color: #aaa;
        text-transform: capitalize;
        color: gray;
    }
    .per
    {
        color: blue;
    }
    .gray
    {
        color: gray;
    }
    h2
    {
        font-size: 12px;
        font-weight: bold;
        padding: 5px;
        background: #39589C;
        color: #fff;
        width: 89.4%;
        text-align: center;
    }
    .row-fir th
    {
        font-weight: bold;
        font-size: 11px;
    }
    table td table td
    {
        border-color: #ddd;
    }
    input, select
    {
        width: 86%;
        padding: 0px;
        height: 90%;
    }
    div select option
    {
        padding: 4px 0px;
        width: 86%;
    }
    div input
    {
        width: 95%;
        color: blue;
        padding: 4px 0px;
    }
    .style_number_box_background
    {
        opacity: 0.9;
        background: grey;
        width: 2400px;
    }
    .style_number_box
    {
        padding: 0px !important;
        width: 550px !important;
        border: none;
    }
    .style_number_box table
    {
        border: 1px solid gray;
        padding-bottom: 5px;
    }
    .style_number_box div
    {
        background-color: #39589c;
        color: #fff;
        font-size: 14px;
        font-weight: bold;
        text-align: center;
        text-transform: capitalize;
        width: 100%;
        padding: 5px 0px;
    }
    .style_number_box
    {
        top: 50px !important;
        left: 50% !important;
        position: absolute !important;
    }
    .hover_row
    {
        background-color: #A1DCF2;
    }
    .inner-table
    {
        border-color: #f2f2f2;
        text-align: left;
    }
    .inner-table td
    {
        text-align: left;
        padding: 0px 0px 0px 3px;
    }
    .foo-input, foo-select
    {
        font-size: 9px;
        height: 13px;
    }
    .inner-table td input
    {
        padding: 0px;
    }
    
    .inner-table select, .inner-table select option
    {
        padding: 0px;
        width: 97%;
        font-size: 9px;
        height: 16px; 
    }
    .disable, .disableF
    {
        background-image: url('../../images/n_a.png');
        height: 16px ;
        width: 20px;
        background-repeat: no-repeat;
        opacity: 0.35;
        border: 1px solid gray !important;
    }
    .fab-reg input
    {
        width:18%;
        height:auto;
    }
    #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
</style>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
    });
  
</script>
<script type="text/javascript">
    function validateAndHighlight() {
        for (var i = 0; i < Page_Validators.length; i++) {
            var val = Page_Validators[i];
            var ctrl = document.getElementById(val.controltovalidate);
            if (ctrl != null && ctrl.style != null) {
                if (!val.isvalid) {
                    ctrl.style.borderColor = '#FF0000';
                    //ctrl.style.backgroundColor = '#fce697';
                }
                else {
                    ctrl.style.borderColor = '';
                    ctrl.style.backgroundColor = '';
                }
            }
        }
    }
</script>
<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;
    var GroupDDClientID = '<%=ddlGroup.ClientID%>';
    var SubGroupDDClientID = '<%=ddlSubGroup.ClientID%>';
    var hdnSubGroupClientID = '<%=hiddenSubGroupId.ClientID %>';
    var gdvFQMaster = '<%= gdvFQMaster.ClientID %>';
    var Supplier = -1;
    //$('<%=((HiddenField)gdvFQMaster.FooterRow.FindControl("hiddenSubGroupFooterId")).ClientID %>');

    $(function () {

        var Greige_Imported = $('#<%=gdvFQDetails.ClientID%> input.Greige-imported');
        var Dyed_Imported = $('#<%=gdvFQDetails.ClientID%> input.Dyed-imported');
        var Printed_Imported = $('#<%=gdvFQDetails.ClientID%> input.Printed-imported');
        var Digital_Imported = $('#<%=gdvFQDetails.ClientID%> input.Digital-imported');

        var Greige_Indian = $('#<%=gdvFQDetails.ClientID%> input.Greige-indian');
        var Dyed_Indian = $('#<%=gdvFQDetails.ClientID%> input.Dyed-indian');
        var Printed_Indian = $('#<%=gdvFQDetails.ClientID%> input.Printed-indian');
        var Digital_Indian = $('#<%=gdvFQDetails.ClientID%> input.Digital-indian');

        $("#" + GroupDDClientID, '#main_content').change(function () {
            var groupId = $(this).val();
            populateSubGroups($(this).val());
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function () {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
        });

        $('.GroupDDFooter').change(function () {
            var groupId = $(this).val();
            populateSubGroupsFooter($(this).val());
        });

        $('.GroupDDGrid').change(function () {
            var groupId = $(this).val();
            populateSubGroupsGrid($(this).val());
        });


        $('.SubGroupDDFooter').change(function () {
            $('#<%=gdvFQMaster.ClientID %>').find('input:hidden[id$="hiddenSubGroupFooterId"]').val($(this).val());

        });

        $('.SubGroupDDGrid').change(function () {
            $('#<%=gdvFQMaster.ClientID %>').find('input:hidden[id$="hiddenSubGroupIdGrid"]').val($(this).val());
        });

        $("input.fabricquality-tradename").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualityTradeName", { dataType: "xml", datakey: "string", max: 100 });
//        $("input.fabricquality-suppliername").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualitySupplierReference", { dataType: "xml", datakey: "string", max: 100 });

        $('.OriginF').change(function () {
            $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenOriginFooter"]').val($(this).val());
            Supplier = $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenSupplierFooter"]').val();
            EnableDisable_GDPD_Footer($(this).val(), Supplier);
        });

        $('.SupplierF').change(function () {
            $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenSupplierFooter"]').val($(this).val());
            var Origin = $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenOriginFooter"]').val();
            EnableDisable_GDPD_Footer(Origin, $(this).val());
        });


        $('.OriginE').change(function () {
            $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenOrigin"]').val($(this).val());
            Supplier = $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenSupplier"]').val();
            EnableDisable_GDPD($(this).val(), Supplier);
        });

        $('.SupplierE').change(function () {
            $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenSupplier"]').val($(this).val());
            var Origin = $('#<%=gdvFQDetails.ClientID %>').find('input:hidden[id$="hiddenOrigin"]').val();
            EnableDisable_GDPD(Origin, $(this).val());
        });


        $('.btnSubmitDetail').click(function (e) {
            var isValid = true;
            $('#<%=gdvFQDetails.ClientID%> .requiredF, .requiredF').each(function () {
                if ($.trim($(this).val()) == '' || $.trim($(this).val()) == '-1') {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red"
                    });
                }
                else {
                    $(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });
            if (isValid == false)
                e.preventDefault();
           
        });

        $('.lkbUpdate').click(function (e) {
            var isValid = true;
            $('#<%=gdvFQDetails.ClientID%> .required, .required').each(function () {
                if ($.trim($(this).val()) == '' || $.trim($(this).val()) == '-1') {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red"
                    });
                }
                else {
                    $(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });
            if (isValid == false)
                e.preventDefault();       
        });

    });


    function populateSubGroups(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setSubGroup() {
        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }


    function populateSubGroupsFooter(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, '.SubGroupDDFooter', "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroupFooter);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        // $('.SubGroupDDFooter').val($(hdnFooterSubGroupClientID).val());
    }

    function setSubGroupFooter() {
        selectedSubGroup = $('.SubGroupDDFooter').val();
        // $('.SubGroupDDFooter').val($(hdnFooterSubGroupClientID).val());
    }


    function populateSubGroupsGrid(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, '.SubGroupDDGrid', "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroupGrid);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $('.SubGroupDDGrid').val($(hdnSubGroupClientID).val());
    }

    function setSubGroupGrid() {
        selectedSubGroup = $('.SubGroupDDGrid').val();
        $('.SubGroupDDGrid').val($(hdnSubGroupClientID).val());
    }

    function extractNumber(obj, decimalPlaces, allowNegative) {
        var temp = obj.value;

        // avoid changing things if already formatted correctly
        var reg0Str = '[0-9]*';
        if (decimalPlaces > 0) {
            reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
        } else if (decimalPlaces < 0) {
            reg0Str += '\\.?[0-9]*';
        }
        reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
        reg0Str = reg0Str + '$';
        var reg0 = new RegExp(reg0Str);
        if (reg0.test(temp)) return true;

        // first replace all non numbers
        var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
        var reg1 = new RegExp(reg1Str, 'g');
        temp = temp.replace(reg1, '');

        if (allowNegative) {
            // replace extra negative
            var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
            var reg2 = /-/g;
            temp = temp.replace(reg2, '');
            if (hasNegative) temp = '-' + temp;
        }

        if (decimalPlaces != 0) {
            var reg3 = /\./g;
            var reg3Array = reg3.exec(temp);
            if (reg3Array != null) {
                // keep only first occurrence of .
                //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                reg3Right = reg3Right.replace(reg3, '');
                reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
            }
        }
        obj.value = temp;
    }


    function EnableDisable_GDPD_Footer(Origin, Supplier) {
        //debugger;
        proxy.invoke("GetSupplier_SupplyType", { SupplierID: Supplier }, function (result) {
            //alert(JSON.stringify(result));
            var SupplyType = [] = result;

            $('#<%=gdvFQDetails.ClientID%> .Greige-importedF, .Dyed-importedF, .Printed-importedF, .Digital-importedF, .Greige-indianF, .Dyed-indianF, .Printed-indianF, .Digital-indianF').each(function () {
                $(this).attr('disabled', 'disabled');
                $(this).removeClass('requiredF');
                $(this).addClass('disableF');
            });
            
            // INDIAN 
            if (Origin == 1) {

                if ($.inArray('1', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Greige-indianF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('2', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Dyed-indianF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('3', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Printed-indianF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('4', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Digital-indianF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

            }

            // IMPORTED
            else if (Origin == 2) {

                if ($.inArray('1', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Greige-importedF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('2', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Dyed-importedF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('3', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Printed-importedF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }

                if ($.inArray('4', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Digital-importedF').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('requiredF');
                        $(this).removeClass('disableF');
                    });
                }
            }



        });
    }

    function EnableDisable_GDPD(Origin, Supplier) {
        //debugger;
        proxy.invoke("GetSupplier_SupplyType", { SupplierID: Supplier }, function (result) {
            //alert(JSON.stringify(result));
            var SupplyType = [] = result;

            $('#<%=gdvFQDetails.ClientID%> .Greige-imported, .Dyed-imported, .Printed-imported, .Digital-imported, .Greige-indian, .Dyed-indian, .Printed-indian, .Digital-indian').each(function () {
                $(this).attr('disabled', 'disabled');
                $(this).removeClass('required');
                $(this).addClass('disable');
            });

            // INDIAN 
            if (Origin == 1) {

                if ($.inArray('1', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Greige-indian').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('2', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Dyed-indian').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('3', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Printed-indian').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('4', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Digital-indian').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

            }

            // IMPORTED
            else if (Origin == 2) {

                if ($.inArray('1', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Greige-imported').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('2', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Dyed-imported').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('3', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Printed-imported').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }

                if ($.inArray('4', SupplyType) > -1) {

                    $('#<%=gdvFQDetails.ClientID%> .Digital-imported').each(function () {
                        $(this).removeAttr("disabled");
                        $(this).addClass('required');
                        $(this).removeClass('disable');
                    });
                }
            }



        });
    }

</script>
<script type="text/javascript">
    var GrdIndex;
    function ShowAddRemarks(index) {
        GrdIndex = index - 1;
        var hdnFldRemarks = $('.hdnFldRemarks').eq(GrdIndex)
        $('#<%=txtRemarks.ClientID%>').val(hdnFldRemarks.val());
        $('#divRemarksFQ_background').show();
        $('#divRemarksFQ').show();
    }

    function HideRemarks() {
        $('#divRemarksFQ').hide();
        $('#divRemarksFQ_background').hide();
    }

    function Cancel() {
        HideRemarks();
    }

    function SaveRemarks() {
        var txtRemarks = $('#<%=txtRemarks.ClientID%>').val();
        $('.hdnFldRemarks').eq(GrdIndex).val(txtRemarks);
        HideRemarks();
    }

    function UploadFile(index) {
        GrdIndex = index - 1;
        var FileName = $('.hdnFldFilePath').eq(GrdIndex).val();
        var url = '../Merchandising/QCUpload.aspx?index=' + GrdIndex + '&FileName=' + FileName;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 330, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    }

    function SBClose() {
    }

    function SaveFile(index, FileName) {
        $('.hdnFldFilePath').eq(GrdIndex).val(FileName);
    }

    $(function () {
        $("[id*=gdvFQMaster] td").hover(function () {
            $("td", $(this).closest("tr")).addClass("hover_row");
        }, function () {
            $("td", $(this).closest("tr")).removeClass("hover_row");
        });
    });

</script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        ShowImagePreview();
    });
    // Configuration of the x and y offsets
    function ShowImagePreview() {
        xOffset = 250;
        yOffset = 100;
        $("a.preview").hover(function (e) {
            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:400px !important; width:300px !important;'/>" + c + "</p>");
            $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
        },

function () {
    this.title = this.t;
    $("#preview").remove();
});

        $("a.preview").mousemove(function (e) {
            $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
        });
    };

    </script>
<h2>
    Fabric Quality Form
</h2>
<table cellspacing="0" cellpadding="0" border="1" width="90%">
    <thead>
        <tr>
            <th width="40">
                Search
            </th>
            <td width="135">
                <asp:TextBox ID="txtSearch" ToolTip="Search for supplier name or trade name or supplier ref or identification no " runat="server"></asp:TextBox>
            </td>
            <th width="40">
                Group
            </th>
            <td width="120">
                <asp:DropDownList ID="ddlGroup" runat="server">
                    <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <th width="60">
                Sub Group
            </th>
            <td width="120">
                <asp:DropDownList ID="ddlSubGroup" runat="server">
                    <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
            </td>
            <th width="40">
                Trade
            </th>
            <td width="120">
                <asp:TextBox ID="txtTrade" runat="server" CssClass="fabricquality-tradename"></asp:TextBox>
            </td>
            <th width="45">
                Unit
            </th>
            <td width="45">
                <asp:DropDownList ID="DDlUnit" runat="server">
                    <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                    <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                </asp:DropDownList>
            </td>
            <th width="45">
                Origin
            </th>
            <td width="55">
                <asp:DropDownList ID="DDlOrigin" runat="server">
                    <asp:ListItem Text="--All--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
             <th width="60">
                Fabric Type
            </th>
            <td width="100">
                <asp:DropDownList ID="ddlfabrictype" runat="server">
                    <asp:ListItem Text="--All--" Value="-1"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="Reg Fabric" Value="1"></asp:ListItem>
                    <asp:ListItem  Text="Un Reg Fabric" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="HiddenField1" Value="-1" />
            </td>
            <td width="35">
                <asp:LinkButton ID="lkbGo" runat="server" CssClass="submit" Text="Search" style="float:right" CausesValidation="false" OnClick="lkbGo_Click">
                                    <%--<img src="../../App_Themes/ikandi/images/MO_go.jpg" alt="Search" title="Search"
                                     border="0" />--%>
                </asp:LinkButton>
            </td>
        </tr>
    </thead>
</table>
<div style="height: 10px;">
</div>
<asp:GridView ID="gdvFQMaster" runat="server" DataKeyNames="FabricMaster_ID" Width="90%"
    ShowFooter="True" OnRowCommand="gdvFQMaster_RowCommand" OnPageIndexChanging="gdvFQMaster_PageIndexChanging"
    AutoGenerateColumns="false" OnRowEditing="gdvFQMaster_RowEditing" OnRowCancelingEdit="gdvFQMaster_RowCancelingEdit"
    OnRowUpdating="gdvFQMaster_RowUpdating" AllowPaging="true" PageSize="10">
    <SelectedRowStyle BackColor="#A1DCF2" />
    <Columns>
        <asp:TemplateField HeaderText="S.No.">
            <ItemStyle HorizontalAlign="Center" Width="5%" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Group" HeaderStyle-Width="20%">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="GroupDDGrid">
                    <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlGroup" runat="server" ErrorMessage="" CssClass="errorMsg"
                    InitialValue="-1" ControlToValidate="ddlGroup" Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="ddlFooterGroup" runat="server" CssClass="GroupDDFooter">
                    <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlFooterGroup" runat="server" ErrorMessage=""
                    ValidationGroup="F" CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlFooterGroup"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                <asp:HiddenField ID="hdnfGroupID" runat="server" Value='<%# Eval("CategoryId") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sub Group" HeaderStyle-Width="20%">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlSubGroup" runat="server" CssClass="SubGroupDDGrid">
                    <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hiddenSubGroupIdGrid" Value="-1" />
                <asp:RequiredFieldValidator ID="rfvSubGroup" runat="server" ErrorMessage="" CssClass="errorMsg"
                    InitialValue="-1" ControlToValidate="ddlSubGroup" Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="ddlFooterSubGroup" runat="server" CssClass="SubGroupDDFooter">
                    <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hiddenSubGroupFooterId" Value="-1" />
                <asp:RequiredFieldValidator ID="rfvddlFooterSubGroup" runat="server" ErrorMessage=""
                    ValidationGroup="F" CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlFooterSubGroup"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblSubGroup" runat="server" Text='<%# Eval("SubGroupName") %>'></asp:Label>
                <asp:HiddenField ID="hdnfSubGroup" runat="server" Value='<%# Eval("SubCategoryId") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trade Name" HeaderStyle-Width="25%">
            <EditItemTemplate>
                <asp:TextBox ID="txtTradeName" runat="server" Text='<%# Eval("TradeName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTradeNameE" runat="server" ErrorMessage="" ControlToValidate="txtTradeName"
                    CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txtFooterTradeName" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTradeName" runat="server" ErrorMessage="" ControlToValidate="txtFooterTradeName"
                    ValidationGroup="F" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblTradeName" runat="server" Text='<%# Eval("TradeName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="10%">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlUnit" runat="server">
                    <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                    <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="ddlFooterUnit" runat="server">
                    <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                    <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlFooterUnit" runat="server" ErrorMessage=""
                    ValidationGroup="F" CssClass="errorMsg" InitialValue="0" ControlToValidate="ddlFooterUnit"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fabric Type" HeaderStyle-Width="10%">
            <%--<EditItemTemplate>
                <asp:RadioButton ID="rdofabrictypeReg" runat="server" Checked="true" GroupName="rdofabrictype" />
                <asp:RadioButton ID="rdofabrictypeUnReg" runat="server" GroupName="rdofabrictype" />
            </EditItemTemplate>
            <FooterTemplate>
                <asp:RadioButton ID="rdofooterfabrictypeReg" runat="server" Checked="true" GroupName="rdofabrictype" />
                <asp:RadioButton ID="rdofooterfabrictypeUnReg" runat="server" GroupName="rdofabrictype" />              
            </FooterTemplate>--%>
            <ItemTemplate>
                <asp:Label ID="lblFabrictype" runat="server" Text='<%# Eval("FabricType") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
            ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
            UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
            CausesValidation="true">
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:CommandField>
        <%--      <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:LinkButton ID="lkbEdit" runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'>
                                    <img src="../../images/edit2.png" alt="Edit Record" title="Edit"
                                     border="0" />
                </asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lkbUpdate" runat="server" CausesValidation="true" CommandName="Update" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'>
                                    <img src="../../App_Themes/ikandi/images/update.jpg" alt="Update Record" title="Update"
                                     border="0" />
                </asp:LinkButton>
                <asp:LinkButton ID="lkbCancel" runat="server" CausesValidation="false" CommandName="Cancel">
                                    <img src="../../App_Themes/ikandi/images/cancel.jpg" alt="Cancel" title="Cancel"
                                     border="0" />
                </asp:LinkButton>
            </EditItemTemplate>
            
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:LinkButton ID="lkSelect" runat="server" CausesValidation="False" CommandName="Select"
                    Text="Select">
                </asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert"
                    ValidationGroup="F">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                </asp:LinkButton>
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="height: 10px;">
</div>
<table cellspacing="0" cellpadding="0" border="1" width="1841px">
    <thead>
        <tr>
            <th width="63" rowspan="4">
             Identification
            </th>
            <th>
                Supplier Name
            </th>
            <th rowspan="3">
               Stock Details 
            </th>
            <th>
                Technical Details
            </th>
            <th>
                Limitation
            </th>
            <th colspan="12">
              Financial
            </th>
            <th width="80" rowspan="3">
              Upload
            </th>
            <th width="86" rowspan="3">
            Comments
            </th>
            <th width="50" rowspan="3" colspan="2">
                Action
            </th>
        </tr>
        <tr>
            <th width="101">
                Supplier Ref.
            </th>
            <th width="90">
                Composition
            </th>
            <th width="104">
                Test Date
            </th>
            <th colspan="8">
                Imported
            </th>
            <th colspan="4" rowspan="2">
                Indian
            </th>
        </tr>
        <tr>
            <th width="101">
                Originie
            </th>
            <th width="90">
                Technical Name
            </th>
            <th width="104">
                MoQ Print
            </th>
            <th colspan="4">
                Air
            </th>
            <th colspan="4">
                Sea
            </th>
        </tr>
        <tr>
            <th width="101">
                Min stk qty
            </th>
            <th width="104">
                Count / Construction
            </th>
            <th width="90">
                Upload Base Test
            </th>
            <th width="104">
                Moq Solid
            </th>
            <th width="90">
                Greige
            </th>
            <th width="93">
                Dyed
            </th>
            <th width="91">
                Potery Print
            </th>
            <th width="93">
                Digital Print
            </th>
            <th width="94">
                Greige
            </th>
            <th width="91">
                Dyed
            </th>
            <th width="95">
                Potery Print
            </th>
            <th width="93">
                Digital Print
            </th>
            <th width="93">
                Greige
            </th>
            <th width="94">
                Dyed
            </th>
            <th width="98">
                Potery Print
            </th>
            <th width="92">
                Digital Print
            </th>
            <th width="90">
                Upload Pic
            </th>
            <th>
            Fabric Type
            </th>
            <th width="30">
                Edit
            </th>
            <th width="30">
                Del
            </th>
        </tr>
    </thead>
</table>
<asp:GridView ID="gdvFQDetails" runat="server" DataKeyNames="FQMasterID, FabricQualityID"
    Width="1841px" ShowHeader="false" ShowFooter="True" OnRowCommand="gdvFQDetails_RowCommand"
    OnPageIndexChanging="gdvFQDetails_PageIndexChanging" AutoGenerateColumns="false"
    OnRowEditing="gdvFQDetails_RowEditing" OnRowCancelingEdit="gdvFQDetails_RowCancelingEdit"
    OnRowUpdating="gdvFQDetails_RowUpdating" OnRowDataBound="gdvFQDetails_RowDataBound" CellPadding="0" OnRowDeleting="gdvFQDetails_RowDeleting"
    AllowPaging="true" PageSize="10">
    <Columns>
        <asp:TemplateField ItemStyle-Width="63" FooterStyle-Width="63">
            <FooterTemplate>
                <asp:Label ID="lblIdentificationF" runat="server" ForeColor="DarkBlue"></asp:Label>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblIdentification" runat="server" Text='<%# Eval("Identification") %>'
                    ForeColor="DarkBlue"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="101" FooterStyle-Width="101">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="15px">
                        <asp:Label ID="lblIdentifications" Visible="false" runat="server" Text='<%# Eval("Identification") %>'
                    ForeColor="DarkBlue"></asp:Label>
                            <asp:HiddenField runat="server" ID="hiddenSupplier" Value="-1" />
                            <asp:DropDownList ID="ddlSupplierName" runat="server" CssClass="SupplierE">
                                <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ErrorMessage="" InitialValue="-1"
                                ControlToValidate="ddlSupplierName" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:TextBox ID="txtSupplierReference" runat="server" CssClass="fabricquality-suppliername"
                                MaxLength="43" Text='<%# Eval("SupplierReference") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSupplierReferenc" runat="server" Display="Dynamic"
                                ControlToValidate="txtSupplierReference" ErrorMessage=""></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:HiddenField runat="server" ID="hiddenOrigin" Value="-1" />
                            <asp:DropDownList runat="server" ID="ddlOrigin" CssClass="OriginE">
                                <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlOrigin" runat="server" ErrorMessage="" CssClass="errorMsg"
                                InitialValue="-1" ControlToValidate="ddlOrigin" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:TextBox ID="txtQty" runat="server" onkeyup="extractNumber(this,0,false);" Text='<%# Eval("MinStockQuality") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQty" runat="server" Display="Dynamic" ControlToValidate="txtQty"
                                ErrorMessage=""></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="15px">
                            <asp:HiddenField runat="server" ID="hiddenSupplierFooter" Value="-1" />
                            <asp:DropDownList ID="ddlSupplierNameF" runat="server" CssClass="SupplierF">
                                <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvSupplierNameF" runat="server" ErrorMessage=""
                                InitialValue="-1" ControlToValidate="ddlSupplierNameF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:TextBox ID="txtSupplierReferenceF" MaxLength="15" runat="server" CssClass="fabricquality-suppliername"
                               ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvSupplierReferenceF" runat="server" ErrorMessage=""
                                ControlToValidate="txtSupplierReferenceF" ValidationGroup="FD" CssClass="errorMsg"
                              ForeColor="Red"   Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:HiddenField runat="server" ID="hiddenOriginFooter" Value="-1" />
                            <asp:DropDownList runat="server" ID="ddlOriginF" CssClass="OriginF">
                                <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="rfvddlOriginF" runat="server" ErrorMessage="" ValidationGroup="FD"
                                CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlOriginF" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:TextBox ID="txtQtyF" runat="server" onkeyup="extractNumber(this,0,false);" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQtyF" runat="server" ErrorMessage="" ControlToValidate="txtQtyF"
                                ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="15px">
                            <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:Label ID="lblSupplierReference" runat="server" Text='<%# Eval("SupplierReference") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:Label ID="lblOrigin" runat="server" Text='<%# Eval("Origin")!=DBNull.Value ? ( Convert.ToInt32(Eval("Origin"))== 1 ? "Indian" : "Imported"):""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                            <asp:Label ID="lblMinStockQuantity" runat="server" Text='<%# Eval("MinStockQuality") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="104" FooterStyle-Width="104">
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="txtCount" MaxLength="48" Text='<%# Eval("CountConstruction") %>'></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="rfvCount" runat="server" Display="Dynamic" ControlToValidate="txtCount"
                    ErrorMessage=""></asp:RequiredFieldValidator>--%>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox runat="server" ID="txtCountF" MaxLength="48"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvCountF" runat="server" ErrorMessage="" ControlToValidate="txtCountF"
                    ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="lblCount" runat="server" Text='<%# Eval("CountConstruction") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="90" FooterStyle-Width="90">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtComposition" MaxLength="98" Text='<%# Eval("Composition") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvComposition" runat="server" Display="Dynamic"
                                ControlToValidate="txtComposition" ErrorMessage=""></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtFabric" MaxLength="43" Text='<%# Eval("Fabric") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:FileUpload runat="server" ID="fileBaseTest" />
                            <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePath" Value='<%# Eval("UpdateBaseTestFile") %>' />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtCompositionF" MaxLength="98"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCompositionF" runat="server" ErrorMessage="" ControlToValidate="txtCompositionF"
                                ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtFabricF" MaxLength="43" Text='<%# Eval("Fabric") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:FileUpload runat="server" ID="fileBaseTestF" />
                            <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePathF" Value='<%# Eval("UpdateBaseTestFile") %>' />
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblComposition" runat="server" Text='<%# Eval("Composition") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblFabric" runat="server" Text='<%# Eval("Fabric") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                        <%--<span class="preview" title="<%# ResolveUrl("~/uploads/Quality/" + (Eval("UpdateBaseTestFile"))) %>">
            
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UpdateBaseTestFile"))) %>' height="20px" width="20px" style="float:left;" onmouseover="ShowBiggerImage(this);" onmouseout="ShowDefaultImage(this);" Visible='<%# String.IsNullOrEmpty(Eval("UpdateBaseTestFile").ToString()) ? false : true %>'/> </span>--%>

            <asp:HyperLink ID="HyperLink1" runat="server" visible='<%# String.IsNullOrEmpty(Eval("UpdateBaseTestFile").ToString()) ? false : true %>' class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UpdateBaseTestFile"))) %>'
                                    Target="_blank">
                                             <img width="20px" height="20px" alt="" onclick="javascript:void(0)" border="0px" src='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UpdateBaseTestFile"))) %>'/>
                                </asp:HyperLink>

                            <%--<a target="_blank" href='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UpdateBaseTestFile"))) %>'
                                visible='<%# String.IsNullOrEmpty(Eval("UpdateBaseTestFile").ToString()) ? false : true %>'
                                runat="server" id="basetestfile" style="float:left;">
                                <img src="../../images/view-icon.png" title="View File" alt="View File" />
                            </a>--%>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="104" FooterStyle-Width="104">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtTestConductedOn" MaxLength="98" Text='<%# Eval("TestConductedOn") %>'
                                Font-Size="X-Small" CssClass="th"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtMOQPrint" CssClass="numeric-field-with-two-decimal-places"
                                MaxLength="10" Text='<%# Eval("MOQPrint") != DBNull.Value ? (Convert.ToDouble(Eval("MOQPrint")) <= 0 ? "" : Eval("MOQPrint")) : "" %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtMOQ" CssClass="numeric-field-with-two-decimal-places"
                                MaxLength="10" Text='<%# Eval("MinimumOrderQuantity") != DBNull.Value ? (Convert.ToDouble(Eval("MinimumOrderQuantity")) <= 0 ? "" : Eval("MinimumOrderQuantity")) : "" %>'></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtTestConductedOnF" MaxLength="98" CssClass="th"
                                Font-Size="X-Small"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtMOQPrintF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:TextBox runat="server" ID="txtMOQF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblTestConductedOn" runat="server" Text='<%# Eval("TestConductedOn")!=DBNull.Value? (Convert.ToDateTime(Eval("TestConductedOn"))!= DateTime.MinValue ? (DateTime.Parse(Eval("TestConductedOn").ToString()).ToString("dd MMM yy (ddd) ")) : ""):"" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblMOQPrint" runat="server" Text='<%# Eval("MOQPrint") != DBNull.Value ? (Convert.ToDouble(Eval("MOQPrint")) <= 0 ? "" : Eval("MOQPrint")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblMOQ" runat="server" Text='<%# Eval("MinimumOrderQuantity") != DBNull.Value ? (Convert.ToDouble(Eval("MinimumOrderQuantity")) <= 0 ? "" : Eval("MinimumOrderQuantity")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <%--=================Air================--%>
        <asp:TemplateField ItemStyle-Width="90" FooterStyle-Width="90">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceForGreigeByAir" Text='<%# Eval("PriceForGreigeByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForGreigeByAir")) <= 0 ? "" : Eval("PriceForGreigeByAir")) : "" %>'
                                CssClass="numeric-field-with-two-decimal-places Greige-imported "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeAir" CssClass="numeric-field-with-two-decimal-places Greige-imported  required"
                                MaxLength="10" Text='<%# Eval("GSMGreigeAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeAir")) <= 0 ? "" : Eval("GSMGreigeAir")) : "" %> '></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMGreigeAir" runat="server" Display="Dynamic" 
                                ControlToValidate="txtGSMGreigeAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeAir" CssClass="WidthInch numeric-field-with-decimal-places Greige-imported  required"
                                MaxLength="7" Text='<%# Eval("WidthGreigeAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeAir")) <= 0 ? "" : Eval("WidthGreigeAir")) : ""%>'></asp:TextBox>
                            <%--    <asp:RequiredFieldValidator ID="rfvWidthGreigeAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthGreigeAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeAir" CssClass="numeric-field-with-two-decimal-places Greige-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageGreigeAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeAir")) <= 0 ? "" : Eval("ResidualShrinkageGreigeAir")) : "" %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageGreigeAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceForGreigeByAirF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Greige-importedF "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeAirF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Greige-importedF requiredF"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMGreigeAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMGreigeAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeAirF" CssClass="WidthInch numeric-field-with-decimal-places Greige-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthGreigeAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthGreigeAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeAirF" CssClass="numeric-field-with-two-decimal-places Greige-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageGreigeAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:Label ID="lblPriceForGreigeByAir" runat="server" Text='<%# Eval("PriceForGreigeByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForGreigeByAir")) <= 0 ? "" : Eval("PriceForGreigeByAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMGreigeAir" runat="server" Text='<%#  Eval("GSMGreigeAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeAir")) <= 0 ? "" : Eval("GSMGreigeAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthGreigeAir" runat="server" Text='<%#  Eval("WidthGreigeAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeAir")) <= 0 ? "" : Eval("WidthGreigeAir")) : ""   %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                        
                            <asp:Label ID="lblResidualShrinkageGreigeAir" runat="server" Text='<%#  Eval("ResidualShrinkageGreigeAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeAir")) <= 0 ? "" : Eval("ResidualShrinkageGreigeAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="93" FooterStyle-Width="93">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDyedByAir" Text='<%# Eval("PriceForDyedByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDyedByAir")) <= 0 ? "" : Eval("PriceForDyedByAir")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Dyed-imported Dyed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedAir" CssClass="numeric-field-with-two-decimal-places Dyed-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMDyedAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedAir")) <= 0 ? "" : Eval("GSMDyedAir")) : ""   %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvGSMDyedAir" runat="server" Display="Dynamic" ControlToValidate="txtGSMDyedAir"
                                ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedAir" CssClass="WidthInch numeric-field-with-decimal-places Dyed-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthDyedAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedAir")) <= 0 ? "" : Eval("WidthDyedAir")) : ""  %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthDyedAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDyedAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedAir" CssClass="numeric-field-with-two-decimal-places Dyed-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDyedAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedAir")) <= 0 ? "" : Eval("ResidualShrinkageDyedAir")) : "" %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDyedAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDyedByAirF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Dyed-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedAirF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Dyed-importedF requiredF"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMDyedAirF" runat="server" ErrorMessage="" ControlToValidate="txtGSMDyedAirF"
                                ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedAirF" CssClass="WidthInch numeric-field-with-decimal-places Dyed-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthDyedAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDyedAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedAirF" CssClass="numeric-field-with-two-decimal-places Dyed-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDyedAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForDyedByAir" runat="server" Text='<%# Eval("PriceForDyedByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDyedByAir")) <= 0 ? "" : Eval("PriceForDyedByAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDyedAir" runat="server" Text='<%#  Eval("GSMDyedAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedAir")) <= 0 ? "" : Eval("GSMDyedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDyedAir" runat="server" Text='<%#  Eval("WidthDyedAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedAir")) <= 0 ? "" : Eval("WidthDyedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDyedAir" runat="server" Text='<%#  Eval("ResidualShrinkageDyedAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedAir")) <= 0 ? "" : Eval("ResidualShrinkageDyedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="91" FooterStyle-Width="91">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForPrintedByAir" Text='<%#  Eval("PriceForPrintedByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForPrintedByAir")) <= 0 ? "" : Eval("PriceForPrintedByAir")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Printed-imported Printed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedAir" CssClass="numeric-field-with-two-decimal-places Printed-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMPrintedAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMPrintedAir")) <= 0 ? "" : Eval("GSMPrintedAir")) : ""    %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMPrintedAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMPrintedAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedAir" CssClass="WidthInch numeric-field-with-decimal-places Printed-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthPrintedAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedAir")) <= 0 ? "" : Eval("WidthPrintedAir")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthPrintedAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthPrintedAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedAir" CssClass="numeric-field-with-two-decimal-places Printed-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkagePrintedAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedAir")) <= 0 ? "" : Eval("ResidualShrinkagePrintedAir")) : ""  %>'></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkagePrintedAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForPrintedByAirF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Printed-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedAirF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Printed-importedF requiredF"></asp:TextBox>
                            <%--      <asp:RequiredFieldValidator ID="rfvGSMPrintedAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMPrintedAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedAirF" CssClass="WidthInch numeric-field-with-decimal-places Printed-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvWidthPrintedAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthPrintedAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedAirF" CssClass="numeric-field-with-two-decimal-places Printed-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkagePrintedAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForPrintedByAir" runat="server" Text='<%# Eval("PriceForPrintedByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForPrintedByAir")) <= 0 ? "" : Eval("PriceForPrintedByAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMPrintedAir" runat="server" Text='<%#  Eval("GSMPrintedAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMPrintedAir")) <= 0 ? "" : Eval("GSMPrintedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthPrintedAir" runat="server" Text='<%#  Eval("WidthPrintedAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedAir")) <= 0 ? "" : Eval("WidthPrintedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkagePrintedAir" runat="server" Text='<%#  Eval("ResidualShrinkagePrintedAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedAir")) <= 0 ? "" : Eval("ResidualShrinkagePrintedAir")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="93" FooterStyle-Width="93">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalByAir" Text='<%#  Eval("PriceForDigitalByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalByAir")) <= 0 ? "" : Eval("PriceForDigitalByAir")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Digital-imported Digital-Element "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalAir" CssClass="numeric-field-with-two-decimal-places Digital-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMDigitalAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalAir")) <= 0 ? "" : Eval("GSMDigitalAir")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMDigitalAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMDigitalAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalAir" CssClass="WidthInch numeric-field-with-decimal-places Digital-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthDigitalAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalAir")) <= 0 ? "" : Eval("WidthDigitalAir")) : ""  %>'></asp:TextBox>
                            <%--     <asp:RequiredFieldValidator ID="rfvWidthDigitalAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDigitalAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalAir" CssClass="numeric-field-with-two-decimal-places Digital-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDigitalAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalAir")) <= 0 ? "" : Eval("ResidualShrinkageDigitalAir")) : "" %>'></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalAir" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDigitalAir" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalByAirF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Digital-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalAirF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Digital-importedF requiredF"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMDigitalAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMDigitalAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalAirF" CssClass="WidthInch numeric-field-with-decimal-places Digital-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthDigitalAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDigitalAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalAirF" CssClass="numeric-field-with-two-decimal-places Digital-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalAirF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDigitalAirF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForDigitalByAir" runat="server" Text='<%# Eval("PriceForDigitalByAir") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalByAir")) <= 0 ? "" : Eval("PriceForDigitalByAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDigitalAir" runat="server" Text='<%#  Eval("GSMDigitalAir") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalAir")) <= 0 ? "" : Eval("GSMDigitalAir")) : ""   %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDigitalAir" runat="server" Text='<%#  Eval("WidthDigitalAir") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalAir")) <= 0 ? "" : Eval("WidthDigitalAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDigitalAir" runat="server" Text='<%#  Eval("ResidualShrinkageDigitalAir") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalAir")) <= 0 ? "" : Eval("ResidualShrinkageDigitalAir")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <%--=================Sea================--%>
        <asp:TemplateField ItemStyle-Width="94" FooterStyle-Width="94">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceForGreigeBySea" Text='<%# Eval("PriceForGreigeBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForGreigeBySea")) <= 0 ? "" : Eval("PriceForGreigeBySea")) : "" %>'
                                CssClass="numeric-field-with-two-decimal-places Greige-imported "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeSea" CssClass="numeric-field-with-two-decimal-places Greige-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMGreigeSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeSea")) <= 0 ? "" : Eval("GSMGreigeSea")) : "" %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMGreigeSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMGreigeSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeSea" CssClass="WidthInch numeric-field-with-decimal-places Greige-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthGreigeSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeSea")) <= 0 ? "" : Eval("WidthGreigeSea")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvWidthGreigeSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthGreigeSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeSea" CssClass="numeric-field-with-two-decimal-places Greige-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageGreigeSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeSea")) <= 0 ? "" : Eval("ResidualShrinkageGreigeSea")) : "" %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageGreigeSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceForGreigeBySeaF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Greige-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeSeaF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Greige-importedF requiredF"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvGSMGreigeSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMGreigeSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeSeaF" CssClass="WidthInch numeric-field-with-decimal-places Greige-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthGreigeSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthGreigeSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeSeaF" CssClass="numeric-field-with-two-decimal-places Greige-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageGreigeSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:Label ID="lblPriceForGreigeBySea" runat="server" Text='<%# Eval("PriceForGreigeBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForGreigeBySea")) <= 0 ? "" : Eval("PriceForGreigeBySea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMGreigeSea" runat="server" Text='<%#  Eval("GSMGreigeSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeSea")) <= 0 ? "" : Eval("GSMGreigeSea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthGreigeSea" runat="server" Text='<%#  Eval("WidthGreigeSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeSea")) <= 0 ? "" : Eval("WidthGreigeSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageGreigeSea" runat="server" Text='<%#  Eval("ResidualShrinkageGreigeSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeSea")) <= 0 ? "" : Eval("ResidualShrinkageGreigeSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="91" FooterStyle-Width="91">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDyedBySea" Text='<%# Eval("PriceForDyedBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDyedBySea")) <= 0 ? "" : Eval("PriceForDyedBySea")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Dyed-imported Dyed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedSea" CssClass="numeric-field-with-two-decimal-places Dyed-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMDyedSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedSea")) <= 0 ? "" : Eval("GSMDyedSea")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMDyedSea" runat="server" Display="Dynamic" ControlToValidate="txtGSMDyedSea"
                                ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedSea" CssClass="WidthInch numeric-field-with-decimal-places Dyed-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthDyedSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedSea")) <= 0 ? "" : Eval("WidthDyedSea")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvWidthDyedSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDyedSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedSea" CssClass="numeric-field-with-two-decimal-places Dyed-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDyedSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedSea")) <= 0 ? "" : Eval("ResidualShrinkageDyedSea")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDyedSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDyedBySeaF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Dyed-importedF Dyed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedSeaF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Dyed-importedF requiredF"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMDyedSeaF" runat="server" ErrorMessage="" ControlToValidate="txtGSMDyedSeaF"
                                ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedSeaF" CssClass="WidthInch numeric-field-with-decimal-places Dyed-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvWidthDyedSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDyedSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedSeaF" CssClass="numeric-field-with-two-decimal-places Dyed-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDyedSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForDyedBySea" runat="server" Text='<%# Eval("PriceForDyedBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDyedBySea")) <= 0 ? "" : Eval("PriceForDyedBySea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDyedSea" runat="server" Text='<%#  Eval("GSMDyedSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedSea")) <= 0 ? "" : Eval("GSMDyedSea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDyedSea" runat="server" Text='<%#  Eval("WidthDyedSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedSea")) <= 0 ? "" : Eval("WidthDyedSea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDyedSea" runat="server" Text='<%#  Eval("ResidualShrinkageDyedSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedSea")) <= 0 ? "" : Eval("ResidualShrinkageDyedSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="95" FooterStyle-Width="95">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForPrintedBySea" Text='<%#  Eval("PriceForPrintedBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForPrintedBySea")) <= 0 ? "" : Eval("PriceForPrintedBySea")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Printed-imported Printed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedSea" CssClass="numeric-field-with-two-decimal-places Printed-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMPrintedSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMPrintedSea")) <= 0 ? "" : Eval("GSMPrintedSea")) : ""  %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvGSMPrintedSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMPrintedSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedSea" CssClass="WidthInch numeric-field-with-decimal-places Printed-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthPrintedSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedSea")) <= 0 ? "" : Eval("WidthPrintedSea")) : ""  %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthPrintedSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthPrintedSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedSea" CssClass="numeric-field-with-two-decimal-places Printed-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkagePrintedSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedSea")) <= 0 ? "" : Eval("ResidualShrinkagePrintedSea")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkagePrintedSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForPrintedBySeaF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Printed-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedSeaF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Printed-importedF requiredF"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMPrintedSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMPrintedSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedSeaF" CssClass="WidthInch numeric-field-with-decimal-places Printed-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvWidthPrintedSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthPrintedSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedSeaF" CssClass="numeric-field-with-two-decimal-places Printed-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkagePrintedSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForPrintedBySea" runat="server" Text='<%# Eval("PriceForPrintedBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForPrintedBySea")) <= 0 ? "" : Eval("PriceForPrintedBySea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMPrintedSea" runat="server" Text='<%#  Eval("GSMPrintedSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMPrintedSea")) <= 0 ? "" : Eval("GSMPrintedSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthPrintedSea" runat="server" Text='<%#  Eval("WidthPrintedSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedSea")) <= 0 ? "" : Eval("WidthPrintedSea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkagePrintedSea" runat="server" Text='<%#  Eval("ResidualShrinkagePrintedSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedSea")) <= 0 ? "" : Eval("ResidualShrinkagePrintedSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="93" FooterStyle-Width="93">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalBySea" Text='<%#  Eval("PriceForDigitalBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalBySea")) <= 0 ? "" : Eval("PriceForDigitalBySea")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Digital-imported Digital-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalSea" CssClass="numeric-field-with-two-decimal-places Digital-imported required"
                                MaxLength="10" Text='<%#  Eval("GSMDigitalSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalSea")) <= 0 ? "" : Eval("GSMDigitalSea")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMDigitalSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMDigitalSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalSea" CssClass="WidthInch numeric-field-with-decimal-places Digital-imported required"
                                MaxLength="7" Text='<%#  Eval("WidthDigitalSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalSea")) <= 0 ? "" : Eval("WidthDigitalSea")) : ""  %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthDigitalSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDigitalSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalSea" CssClass="numeric-field-with-two-decimal-places Digital-imported required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDigitalSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalSea")) <= 0 ? "" : Eval("ResidualShrinkageDigitalSea")) : ""  %>'></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalSea" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDigitalSea" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalBySeaF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Digital-importedF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalSeaF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Digital-importedF requiredF"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvGSMDigitalSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMDigitalSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalSeaF" CssClass="WidthInch numeric-field-with-decimal-places Digital-importedF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthDigitalSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDigitalSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalSeaF" CssClass="numeric-field-with-two-decimal-places Digital-importedF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalSeaF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDigitalSeaF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForDigitalBySea" runat="server" Text='<%# Eval("PriceForDigitalBySea") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalBySea")) <= 0 ? "" : Eval("PriceForDigitalBySea")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDigitalSea" runat="server" Text='<%#  Eval("GSMDigitalSea") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalSea")) <= 0 ? "" : Eval("GSMDigitalSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDigitalSea" runat="server" Text='<%#  Eval("WidthDigitalSea") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalSea")) <= 0 ? "" : Eval("WidthDigitalSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDigitalSea" runat="server" Text='<%#  Eval("ResidualShrinkageDigitalSea") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalSea")) <= 0 ? "" : Eval("ResidualShrinkageDigitalSea")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <%--===============Indian==============--%>
        <asp:TemplateField ItemStyle-Width="93" FooterStyle-Width="93">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceGreigeIndian" Text='<%# Eval("PriceGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceGreigeIndian")) <= 0 ? "" : Eval("PriceGreigeIndian")) : "" %>'
                                CssClass="numeric-field-with-two-decimal-places Greige-indian Greige-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeIndian" CssClass="numeric-field-with-two-decimal-places Greige-indian required"
                                MaxLength="10" Text='<%#  Eval("GSMGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeIndian")) <= 0 ? "" : Eval("GSMGreigeIndian")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMGreigeIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMGreigeIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeIndian" CssClass="WidthInch numeric-field-with-decimal-places Greige-indian required"
                                MaxLength="7" Text='<%#  Eval("WidthGreigeIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeIndian")) <= 0 ? "" : Eval("WidthGreigeIndian")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthGreigeIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthGreigeIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeIndian" CssClass="numeric-field-with-two-decimal-places Greige-indian required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeIndian")) <= 0 ? "" : Eval("ResidualShrinkageGreigeIndian")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageGreigeIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:TextBox runat="server" ID="txtPriceGreigeIndianF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Greige-indianF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMGreigeIndianF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Greige-indianF requiredF"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMGreigeIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMGreigeIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthGreigeIndianF" CssClass="WidthInch numeric-field-with-decimal-places Greige-indianF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthGreigeIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthGreigeIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageGreigeIndianF" CssClass="numeric-field-with-two-decimal-places Greige-indianF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageGreigeIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageGreigeIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="68%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="32%">
                            <asp:Label ID="lblPriceForGreigeByIndian" runat="server" Text='<%# Eval("PriceGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceGreigeIndian")) <= 0 ? "" : Eval("PriceGreigeIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMGreigeIndian" runat="server" Text='<%#  Eval("GSMGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMGreigeIndian")) <= 0 ? "" : Eval("GSMGreigeIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthGreigeIndian" runat="server" Text='<%#  Eval("WidthGreigeIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthGreigeIndian")) <= 0 ? "" : Eval("WidthGreigeIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageGreigeIndian" runat="server" Text='<%#  Eval("ResidualShrinkageGreigeIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageGreigeIndian")) <= 0 ? "" : Eval("ResidualShrinkageGreigeIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="94" FooterStyle-Width="94">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceDyedIndian" Text='<%# Eval("PriceDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceDyedIndian")) <= 0 ? "" : Eval("PriceDyedIndian")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Dyed-indian Dyed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedIndian" CssClass="numeric-field-with-two-decimal-places Dyed-indian required"
                                MaxLength="10" Text='<%#  Eval("GSMDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedIndian")) <= 0 ? "" : Eval("GSMDyedIndian")) : ""  %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMDyedIndian" runat="server" Display="Dynamic" ControlToValidate="txtGSMDyedIndian"
                                ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedIndian" CssClass="WidthInch numeric-field-with-decimal-places Dyed-indian required"
                                MaxLength="7" Text='<%#  Eval("WidthDyedIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedIndian")) <= 0 ? "" : Eval("WidthDyedIndian")) : "" %>'></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvWidthDyedIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDyedIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedIndian" CssClass="numeric-field-with-two-decimal-places Dyed-indian required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedIndian")) <= 0 ? "" : Eval("ResidualShrinkageDyedIndian")) : ""  %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDyedIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceDyedIndianF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Dyed-indianF "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDyedIndianF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Dyed-indianF requiredF"></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvGSMDyedIndianF" runat="server" ErrorMessage="" ControlToValidate="txtGSMDyedIndianF"
                                ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDyedIndianF" CssClass="WidthInch numeric-field-with-decimal-places Dyed-indianF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvWidthDyedIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDyedIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDyedIndianF" CssClass="numeric-field-with-two-decimal-places Dyed-indianF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDyedIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDyedIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceDyedIndian" runat="server" Text='<%# Eval("PriceDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceDyedIndian")) <= 0 ? "" : Eval("PriceDyedIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDyedIndian" runat="server" Text='<%#  Eval("GSMDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDyedIndian")) <= 0 ? "" : Eval("GSMDyedIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDyedIndian" runat="server" Text='<%#  Eval("WidthDyedIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDyedIndian")) <= 0 ? "" : Eval("WidthDyedIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDyedIndian" runat="server" Text='<%#  Eval("ResidualShrinkageDyedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDyedIndian")) <= 0 ? "" : Eval("ResidualShrinkageDyedIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="98" FooterStyle-Width="98">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPricePrintedIndian" Text='<%#  Eval("PricePrintedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PricePrintedIndian")) <= 0 ? "" : Eval("PricePrintedIndian")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Printed-indian Printed-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedIndian" CssClass="numeric-field-with-two-decimal-places Printed-indian required"
                                MaxLength="10" Text='<%#  Eval("GSMPrintedIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("GSMPrintedIndian")) <= 0 ? "" : Eval("GSMPrintedIndian")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvGSMPrintedIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMPrintedIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedIndian" CssClass="WidthInch numeric-field-with-decimal-places Printed-indian required"
                                MaxLength="7" Text='<%#  Eval("WidthPrintedIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedIndian")) <= 0 ? "" : Eval("WidthPrintedIndian")) : "" %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthPrintedIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthPrintedIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedIndian" CssClass="numeric-field-with-two-decimal-places Printed-indian required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkagePrintedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedIndian")) <= 0 ? "" : Eval("ResidualShrinkagePrintedIndian")) : "" %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkagePrintedIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPricePrintedIndianF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Printed-indianF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMPrintedIndianF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Printed-indianF requiredF"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvGSMPrintedIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMPrintedIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthPrintedIndianF" CssClass="WidthInch numeric-field-with-decimal-places Printed-indianF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvWidthPrintedIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthPrintedIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkagePrintedIndianF" CssClass="numeric-field-with-two-decimal-places Printed-indianF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="rfvResidualShrinkagePrintedIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkagePrintedIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPricePrintedIndian" runat="server" Text='<%# Eval("PricePrintedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PricePrintedIndian")) <= 0 ? "" : Eval("PricePrintedIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMPrintedIndian" runat="server" Text='<%#  Eval("GSMPrintedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMPrintedIndian")) <= 0 ? "" : Eval("GSMPrintedIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthPrintedIndian" runat="server" Text='<%#  Eval("WidthPrintedIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthPrintedIndian")) <= 0 ? "" : Eval("WidthPrintedIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkagePrintedIndian" runat="server" Text='<%#  Eval("ResidualShrinkagePrintedIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkagePrintedIndian")) <= 0 ? "" : Eval("ResidualShrinkagePrintedIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="92" FooterStyle-Width="92">
            <EditItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalByIndian" Text='<%#  Eval("PriceForDigitalByIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalByIndian")) <= 0 ? "" : Eval("PriceForDigitalByIndian")) : ""%>'
                                CssClass="numeric-field-with-two-decimal-places Digital-indian Digital-Element"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalIndian" CssClass="numeric-field-with-two-decimal-places Digital-indian required"
                                MaxLength="10" Text='<%#  Eval("GSMDigitalIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalIndian")) <= 0 ? "" : Eval("GSMDigitalIndian")) : ""  %>'></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvGSMDigitalIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtGSMDigitalIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalIndian" CssClass="WidthInch numeric-field-with-decimal-places Digital-indian required"
                                MaxLength="7" Text='<%#  Eval("WidthDigitalIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalIndian")) <= 0 ? "" : Eval("WidthDigitalIndian")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthDigitalIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtWidthDigitalIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalIndian" CssClass="numeric-field-with-two-decimal-places Digital-indian required"
                                MaxLength="10" Text='<%#  Eval("ResidualShrinkageDigitalIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalIndian")) <= 0 ? "" : Eval("ResidualShrinkageDigitalIndian")) : ""  %>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalIndian" runat="server" Display="Dynamic"
                                ControlToValidate="txtResidualShrinkageDigitalIndian" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:TextBox runat="server" ID="txtPriceForDigitalByIndianF" MaxLength="6" CssClass="numeric-field-with-two-decimal-places Digital-indianF"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGSMDigitalIndianF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places Digital-indianF requiredF"></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="rfvGSMDigitalIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtGSMDigitalIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWidthDigitalIndianF" CssClass="WidthInch numeric-field-with-decimal-places Digital-indianF requiredF"
                                MaxLength="7"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvWidthDigitalIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtWidthDigitalIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtResidualShrinkageDigitalIndianF" CssClass="numeric-field-with-two-decimal-places Digital-indianF requiredF"
                                MaxLength="10"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvResidualShrinkageDigitalIndianF" runat="server" ErrorMessage=""
                                ControlToValidate="txtResidualShrinkageDigitalIndianF" ValidationGroup="FD" CssClass="errorMsg"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tr>
                        <td width="67%" height="15px" class="light-gray-text">
                            Rate
                        </td>
                        <td width="33%">
                            <asp:Label ID="lblPriceForDigitalByIndian" runat="server" Text='<%# Eval("PriceForDigitalByIndian") != DBNull.Value ? (Convert.ToDouble(Eval("PriceForDigitalByIndian")) <= 0 ? "" : Eval("PriceForDigitalByIndian")) : "" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Gsm
                        </td>
                        <td>
                            <asp:Label ID="lblGSMDigitalIndian" runat="server" Text='<%#  Eval("GSMDigitalIndian") != DBNull.Value ? (Convert.ToDouble(Eval("GSMDigitalIndian")) <= 0 ? "" : Eval("GSMDigitalIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            Width
                        </td>
                        <td>
                            <asp:Label ID="lblWidthDigitalIndian" runat="server" Text='<%#  Eval("WidthDigitalIndian") != DBNull.Value ? (Convert.ToDecimal(Eval("WidthDigitalIndian")) <= 0 ? "" : Eval("WidthDigitalIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" class="light-gray-text">
                            R Shkg%
                        </td>
                        <td>
                            <asp:Label ID="lblResidualShrinkageDigitalIndian" runat="server" Text='<%#  Eval("ResidualShrinkageDigitalIndian") != DBNull.Value ? (Convert.ToDouble(Eval("ResidualShrinkageDigitalIndian")) <= 0 ? "" : Eval("ResidualShrinkageDigitalIndian")) : ""  %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="90" FooterStyle-Width="90">
            <EditItemTemplate>
                <a style="cursor: pointer; color:Blue;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    id="BrowseFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO UPLOAD FILE">Browse
                </a>
                <input id="hdnFldFilePath" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
            </EditItemTemplate>
            <FooterTemplate>
                <a style="cursor: pointer; color:Blue;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    id="BrowseFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO UPLOAD FILE">Browse
                </a>
                <input id="hdnFldFilePathF" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
            </FooterTemplate>
            <ItemTemplate>
                <a style="cursor: pointer;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    id="ViewFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO VIEW FILE">
                    <img src="../../images/view-icon.png" alt="View File" />
                </a>
                <input id="hdnFldFilePathI" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="86" FooterStyle-Width="86">
            <EditItemTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tbody>
                    <tr>
                        <td height="20px">
                <a style="cursor: pointer;" onclick='<%# "ShowAddRemarks(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    title="CLICK TO SEE REMARKS">Remarks </a>
                <input id="hdnFldRemarks" type="hidden" runat="server" class="hdnFldRemarks" value='<%#DataBinder.Eval(Container.DataItem, "Comments")%>' />
                </td>
                        </tr>
                        <tr>
                        <td height="20px">
                        <asp:RadioButton ID="rdoeditfabrictypeReg" runat="server" Checked="true" Text="Reg Fab." CssClass="fab-reg" GroupName="rdofabrictypeedit" TextAlign="Left" />
                       
                         <asp:RadioButton ID="rdoeditfabrictypeUnReg" runat="server" Text="UnReg Fab." CssClass="fab-reg" GroupName="rdofabrictypeedit" TextAlign="Left" />  
                        </td>
                        </tr>
                        <tbody>
                        </table>
            </EditItemTemplate>
            <FooterTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tbody>
                    <tr>
                        <td height="20px">
                         <a style="cursor: pointer;" onclick='<%# "ShowAddRemarks(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    title="CLICK TO SEE REMARKS">Remarks </a>
                <input id="hdnFldRemarksF" type="hidden" runat="server" class="hdnFldRemarks" value='<%#DataBinder.Eval(Container.DataItem, "Comments")%>' />
                        </td>
                        </tr>
                        <tr>
                        <td height="20px">
                        <asp:RadioButton ID="rdofooterfabrictypeReg" runat="server" Checked="true" Text="Reg Fab." CssClass="fab-reg" GroupName="rdofabrictype" TextAlign="Left" />
                       
                         <asp:RadioButton ID="rdofooterfabrictypeUnReg" runat="server" Text="UnReg Fab." CssClass="fab-reg" GroupName="rdofabrictype" TextAlign="Left" />  
                        </td>
                        </tr>
                        <tbody>
                        </table>

             

                
               

            </FooterTemplate>
            <ItemTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all" class="inner-table">
                    <tbody>
                    <tr>
                        <td height="20px">
                        <a style="cursor: pointer;" onclick='<%# "ShowAddRemarks(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                    title="CLICK TO SEE REMARKS">Remarks </a>
                <input id="hdnFldRemarksI" type="hidden" runat="server" class="hdnFldRemarks" value='<%#DataBinder.Eval(Container.DataItem, "Comments")%>' />
                        </td>
           </tr>
            <tr>
                        <td height="20px">
                <asp:Label ID="lblfabrictypefooter" runat="server" Text='<%# Eval("FabricTypeReg_UnReg") %>'></asp:Label>
                </td>
                </tr>
                </tbody>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
            ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
            UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
            CausesValidation="true">
            <ItemStyle HorizontalAlign="Center" Width="30" />
            <FooterStyle HorizontalAlign="Center" Width="30" />
        </asp:CommandField>--%>

         <asp:TemplateField HeaderText="Action" ItemStyle-Width="30" FooterStyle-Width="30">
            <ItemTemplate>
                <asp:LinkButton ID="lkbEdit" runat="server" CausesValidation="False" CommandName="Edit">
                <img src="../../images/edit2.png" alt="Edit Record" title="Edit Record" border="0"/>
                </asp:LinkButton>             
            </ItemTemplate>

            <EditItemTemplate>
             <asp:LinkButton ID="lkbUpdate" runat="server" CausesValidation="true" CommandName="Update" CssClass="lkbUpdate">
                <img src="../../images/update.gif" alt="Update Record" title="Update Record" border="0"/>
              </asp:LinkButton>    

                <asp:LinkButton ID="lkbcancel" runat="server" CausesValidation="False" CommandName="Cancel">
                <img src="../../images/cancel.jpg" alt="Cancel" title="Cancel" border="0"/>
                </asp:LinkButton>    
            </EditItemTemplate>

            <FooterTemplate>
                <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert"
                  ValidationGroup="FD"  CssClass="btnSubmitDetail">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                </asp:LinkButton>
            </FooterTemplate>

            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Action" ItemStyle-Width="30" FooterStyle-Width="30">
            <ItemTemplate>
                <asp:LinkButton ID="lkbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick="return confirm('Are you sure to delete the current record?');">
                <img src="../../images/delete-icon.png" alt="Delete Record" title="Delete Record" border="0"/>
                </asp:LinkButton>
            </ItemTemplate>
           
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<h2 style="width: 300px; float: left; margin: 0px; background:#dddfe4; color:Gray;">
    Authorized Signatures <span style="font-size: 12px;">(Date) </span>
</h2>
<div style="float: left; padding-top: 4px; padding-right: 4px; padding-left: 4px;
    padding-bottom: 4px; border: 1px solid #333333; width: 300px; font-size: 12px; ">
    <asp:TextBox runat="server" ID="txtApprovedOn" MaxLength="20" CssClass="th" style="height: 10px;"></asp:TextBox>
</div>
<p>
    &nbsp;</p>
<div class="style_number_box_background" id="divRemarksFQ_background">
</div>
<div class="style_number_box" id="divRemarksFQ">
    <div>
        Comments
    </div>
    <table width="100%" cellpadding="6px" class="mid">
        <tr>
            <td class="b" valign="top" style="width: 25%;">
                Enter Comments:
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="70px" Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <input type="button" class="submit" value="Save" onclick="javascript: return SaveRemarks();" style="width: auto;" />
                <input type="button" class="da_submit_button" value="Cancel" onclick="javascript: return Cancel();" />
            </td>
        </tr>
    </table>
</div>
