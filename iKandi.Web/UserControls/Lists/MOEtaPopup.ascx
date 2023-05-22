<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOEtaPopup.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.MOEtaPopup" %>
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi.css" />
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
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
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
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
<script type="text/javascript">
    jQuery.expr[':'].regex = function (elem, index, match) {
        var matchParams = match[3].split(','),
        validLabels = /^(data|css):/,
        attr = {
            method: matchParams[0].match(validLabels) ?
                        matchParams[0].split(':')[0] : 'attr',
            property: matchParams.shift().replace(validLabels, '')
        },
        regexFlags = 'ig',
        regex = new RegExp(matchParams.join('').replace(/^\s+|\s+$/g, ''), regexFlags);
        return regex.test(jQuery(elem)[attr.method](attr.property));
    }

    function CheckAll(cbId) {
        var chk = document.getElementById(cbId).checked;
        var cbsId = cbId.substring(0, cbId.indexOf('01_CheckHeader'));
        $("input[type=checkbox]:regex(id," + cbsId + ")").each(function () {
            if (this.id != cbId) {
                //debugger;
                $(this).attr('checked', chk);
            }
        });
    }

    function UpdateMoEtaRemarks() {
        debugger;
        var ids = "";
        var StyleID = "";
        var AccessId = "";
        var AccessoryWorkingID = "";
        $("#" + '<%=gvNew.ClientID%>' + " tbody tr").each(function () {
            //debugger;
            if ($(this).find("input[type=text]").length > 0) {
                //debugger;
                if ($(this).find("input[type=checkbox]").attr('checked') == true) {
                    if (ids.length > 0)
                    //debugger;
                        ids += ",";
                    ids += $(this).find("input[type=text][id$='txtOrderId']").val();

                    if (StyleID.length > 0)
                        StyleID += ",";
                    StyleID += $(this).find("input[type=text][id$='txtNewStyleId']").val();


                    if ($(this).find('tr .Accessory .txtAccessoryWorkingDetailID').length > 0) {
                        AccessoryWorkingID += ",";
                        AccessoryWorkingID += $(this).find('tr .Accessory .txtAccessoryWorkingDetailID').val();
                    }
                    else {
                        AccessoryWorkingID += "";
                    }



                }

            }
        });

        debugger;
        var rem = $("#" + '<%=txtremarks.ClientID%>').val();
        //debugger;
        var BIHStart = $("#" + '<%=lblBIHStart.ClientID%>').val();
        var BIHEnd = $("#" + '<%=lblBIHEnd.ClientID%>').val();
        var Name = $("#" + '<%=lblName.ClientID%>').text();
        var print = $("#" + '<%=lblPrint.ClientID%>').text();
        var sRemarks = Name + " " + print


        var Flag1 = $("#" + '<%=hdnFlag1.ClientID%>').val();
        var Flag2 = $("#" + '<%=hdnFlag2.ClientID%>').val();
        if (Flag2 != 'FitsETA') {
            if (Flag1 != 'Access') {
                if (ids.length < 1) {
                    alert('Please select at least one contract');
                    return;
                }
            }
        }
        if (Flag2 == 'FitsETA') {
            StyleID = $("#" + '<%=hdnstyleid.ClientID%>').val();
            BIHEnd = BIHStart;

            if (BIHStart == "") {
                alert("Please Enter ETA");
                return;
            }

        }
        //debugger;
        if (Flag1 != 'Access') {

            if (BIHStart == "") {
                alert("Please Enter ETA");
                return;
            }
        }

        if (Flag1 == 'Access') {

            StyleID = jQuery('[id$=txtStyleID]').val();

            BIHStart = BIHEnd;
            if (BIHEnd == "") {
                alert("Please Enter ETA");
                return;
            }
        }

        if (Flag2 == 'FitsETA') {

            StyleID = $("#" + '<%=hdnstyleid.ClientID%>').val();
            BIHStart = BIHEnd;
        }

        if (Flag1 == 'Packed') {
            BIHEnd = BIHStart

            if (BIHStart == "") {
                alert("Please Enter ETA");
                return;
            }
        }



        UpdateEtaRemarks(Flag1, Flag2, rem, sRemarks, ids, BIHStart, BIHEnd, StyleID, AccessoryWorkingID);
    }

    function UpdateEtaRemarks(Flag1, Flag2, rem, sRemarks, ids, BIHStart, BIHEnd, StyleID, AccessoryWorkingID) {
        //debugger;
        proxy.invoke("UpdateEtaRemarks", { Flag1: Flag1, Flag2: Flag2, remarks: rem, Name: sRemarks, ids: ids, SDate: BIHStart, EDate: BIHEnd, StyleId: StyleID, AccessoryWorkingID: AccessoryWorkingID }, function (result) {
            // debugger;
            // result = '<div class="">' + result + "</div>";
            //jQuery.facebox(result); OrderID
            //alert(result);
            if (result == "0") {
                alert("Start Date should be less Or equal End Date Please Check & Try Again !")
                // $(".divRemarksMo").html("");
                $(".divRemarksMoETA").show();
            }
            else {
                //jQuery.facebox("Remarks have been submitted successfully");
                $(".divRemarksMoETA").html("");
                $(".divRemarksMoETA").hide();
                window.close();
                jQuery(document).trigger('close.facebox');
                $(".go").click();
            }
        }, onPageError, false, false);
    }


    $(document).ready(function () {
        $('input.date-picker1', '#mcontent').datepicker({ changeYear: true, yearRange: '1900:2050', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });
    });
    function CloseWindow() {
        $(".divRemarksMoETA").html("");
        $(".divRemarksMoETA").hide();
        window.close();
        jQuery(document).trigger('close.facebox');
    }

</script>
<style type="text/css">
    .btn-disable
    {
        display: none;
    }
    /*add by bharta 28-12-18*/
    table td
    {
        border-color: #999999 !important;
      
    }
   table.toptable td
    {
        border-color: #999999 !important;
        border:1px solid #999999;
      
    }
     table.toptable th
    {
        border-color: #999999 !important;
        border:1px solid #999999;
        background: #dddfe4;
        padding: 5px;
        color: #575759;
        text-transform: capitalize;
      
    }
    textarea
    {
        width:99.4% !important;
    }
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="form_box" id="mcontent" style="width: 1210px; font-family: Lucida Sans Unicode;
    font-size: 11px; padding: 5px;">
    <%--<div id="mcontent"> --%>
    <div id="frmHed" class="form_heading">
        <span style="text-transform: capitalize !important;">Remarks And ETA Management For
            <asp:Label ID="lblVA" Style="color: Blue; font-weight: bold; font-size: 20px;" runat="server"></asp:Label></span>
        <asp:Label ID="lblName" Style="color: Blue; font-weight: bold; font-size: 20px;"
            runat="server"></asp:Label>
        <asp:Label ID="lblPrint" Style="color: Blue; font-weight: bold; font-size: 20px;"
            runat="server"></asp:Label>
    </div>
    <div style="width: 100%; float: left;">
        <table width="100%" cellpadding="4" cellspacing="0" class="toptable" border="0" style="border-collapse: collapse;"
            class="border2">
            <tr>
                <th style="width: 9%;">
                    <div class="tempClass">
                        Style Number :
                    </div>
                </th>
                <td colspan="3">
                    <asp:Label ID="lblStyleNumber" runat="server" CssClass="label-remarks blue-text" />
                </td>
            </tr>
            <tr>
                <th>
                    <div class="tempClass">
                        Remarks :
                    </div>
                </th>
                <%-- Edited by abhi 3/2/2016--%>
                <td colspan="3" valign="top">
                    <div id="DivFabricsatus" runat="server" style="display: none">
                        <div style="width: 78%; vertical-align: top; height: 100px; overflow: auto; float: left;">
                            <asp:Label ID="lblShowRemark" runat="server" CssClass="label-remarks" />
                        </div>
                        <div style="float: right; width: 20%; font-size: 10px; border: 1px solid #999999;
                            padding: 2px;">
                            <div>
                                Clr/Prnt Ref Revd:
                                <asp:Label ID="lblprintReveddate" runat="server" ForeColor="Blue"></asp:Label>
                            </div>
                            <div>
                                Fabric Qnty Aprd :
                                <asp:Label ID="lblQntyAprddate" runat="server" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="SpnFabricQntyApp" runat="server"></asp:Label>
                            </div>
                            <div>
                                Initial Aprd :
                                <asp:Label ID="lblInitialdate" runat="server" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="SpnInitialApp" runat="server"></asp:Label>
                            </div>
                            <div>
                                Bulk Aprd:
                                <asp:Label ID="lblBulkdate" runat="server" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="SpnBulkApp" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </td>
                <%--end by abhi 3/2/2016--%>
            </tr>
            <tr class="permission-text-remarks">
                <th>
                    Enter Remarks :
                </th>
                <td colspan="3" style="vertical-align: top ! important;">
                    <asp:TextBox Columns="80" Rows="5" Height="90" Width="99.4%" ID="txtremarks" class="text-remarks"
                        runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblbihs" runat="server" Text="Start Eta  :"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="lblBIHStart" runat="server" Style="text-transform: capitalize !important;"
                        CssClass="date-picker1 do-not-disable blue-text" />
                </td>
                <th>
                    <asp:Label ID="lblbihe" runat="server" Text="End Eta  :"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="lblBIHEnd" runat="server" Style="text-transform: capitalize !important;"
                        CssClass="date-picker1 do-not-disable blue-text" />
                    <asp:HiddenField ID="hdnName" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnFlag1" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnFlag2" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnstyleid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnOrderID" runat="server"></asp:HiddenField>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" style="width: 100%; float: left; padding-top: 15px;">
        <fieldset style="border: none; margin: 0px; padding: 0px;">
            <div align="center" style="border: 1px solid #999999; padding: 0px;">
                <asp:GridView ID="gvNew" runat="server" AutoGenerateColumns="false" CssClass="fixed-header item_list"
                    OnRowDataBound="gvNew_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="<label>&nbsp;Serial No.</label>" ItemStyle-VerticalAlign="Top"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="width: 60px !important; float: left;">
                                    <asp:Label ID="lblCalBIH" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<label>&nbsp;Style No.</label>" ItemStyle-VerticalAlign="Top"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="width: 60px !important; float: left; height: 20px;">
                                    <asp:Label ID="lblSDate" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;Contract No.<br/>&nbsp;&nbsp;&nbsp;Quantity</label>"
                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="width: 90px !important; float: left; text-align: center;">
                                    <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label><br />
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="80px"></HeaderStyle>
                            <ItemStyle Width="80px" CssClass="newcss2"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fabric</label><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;<br/>Quality/Decription&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Eta"
                            HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="width: 100%; height: 20px; font-weight: bold;">
                                    B.I.H:&nbsp;&nbsp;<asp:Label ID="lblBIH" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIH")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIH")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                </div>
                                <div style="width: 100%;">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr id="tbl1" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" style="text-align: left;" id="tdFabric1" runat="server">
                                                            <asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric1")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdprint1" runat="server">
                                                            <asp:Label ID="lblFabric1Percent" runat="server" Text='<%# Eval("FabricPercent1")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric1DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric1DetailsRef" runat="server" Text='<%# Eval("Fabric1Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate1" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate1" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tbl2" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" id="tdFabric2" runat="server">
                                                            <asp:Label ID="lblFabric2" runat="server" Text='<%# Eval("Fabric2")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdFabric2Percent" runat="server">
                                                            <asp:Label ID="lblFabric2Percent" runat="server" Text='<%# Eval("FabricPercent2")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric2DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric2DetailsRef" runat="server" Text='<%# Eval("Fabric2Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate2" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate2" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tbl3" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" style="text-align: left;" id="tdFabric3" runat="server">
                                                            <asp:Label ID="lblFabric3" runat="server" Text='<%# Eval("Fabric3")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdFabric3Percent" runat="server">
                                                            <asp:Label ID="lblFabric3Percent" runat="server" Text='<%# Eval("FabricPercent3")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric3DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric3DetailsRef" runat="server" Text='<%# Eval("Fabric3Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate3" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate3" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tbl4" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" style="text-align: left;" id="tdFabric4" runat="server">
                                                            <asp:Label ID="lblFabric4" runat="server" Text='<%# Eval("Fabric4")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdFabric4Percent" runat="server">
                                                            <asp:Label ID="lblFabric4Percent" runat="server" Text='<%# Eval("FabricPercent4")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric4DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric4DetailsRef" runat="server" Text='<%# Eval("Fabric4Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate4" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate4" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                         <tr id="tbl5" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" style="text-align: left;" id="tdFabric5" runat="server">
                                                            <asp:Label ID="lblFabric5" runat="server" Text='<%# Eval("Fabric5")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdFabric5Percent" runat="server">
                                                            <asp:Label ID="lblFabric5Percent" runat="server" Text='<%# Eval("FabricPercent5")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric5DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric5DetailsRef" runat="server" Text='<%# Eval("Fabric5Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate5" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate5" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate5")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate5")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate5" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate5" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate5")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate5")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                         <tr id="tbl6" runat="server" visible="false">
                                            <td align="left" style="width: 250px !important; float: left;">
                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                    <tr>
                                                        <td align="left" style="text-align: left;" id="tdFabric6" runat="server">
                                                            <asp:Label ID="lblFabric6" runat="server" Text='<%# Eval("Fabric6")%>'></asp:Label>
                                                        </td>
                                                        <td colspan="2" id="tdFabric6Percent" runat="server">
                                                            <asp:Label ID="lblFabric6Percent" runat="server" Text='<%# Eval("FabricPercent6")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;" id="tdFabric6DetailsRef" runat="server">
                                                            <asp:Label ID="lblFabric6DetailsRef" runat="server" Text='<%# Eval("Fabric6Details")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricStartETAdate6" runat="server">
                                                            <asp:Label ID="lblFabricStartETAdate6" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate6")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate6")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" id="tdFabricEndETAdate6" runat="server">
                                                            <asp:Label ID="lblFabricEndETAdate6" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate6")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate6")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="200px"></HeaderStyle>
                            <ItemStyle Width="200px" VerticalAlign="Top" CssClass="newcss2 marginpadding verttop">
                            </ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accessories</label><br/><br/>Quality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Recd&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tot&nbsp;&nbsp;&nbsp;Act Dat/End ETA"
                            ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Repeater ID="rptAccessories" runat="server" OnItemDataBound="rptAccessories_ItemDataBound">
                                                    <ItemTemplate>
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list3">
                                                            <tr>
                                                                <td align="left" style="text-align: left;">
                                                                    <div style="width: 105px; float: left;" id="divAccessoriesName" runat="server">
                                                                        <asp:Label ID="lblAccessories" Width="110" runat="server" Text='<%#Eval("AccessoriesName") %>'
                                                                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="width: 20px; float: left;" id="divpercentInHouse" runat="server">
                                                                        <asp:Label ID="lblPercentInHouse" runat="server" Text='<%#Eval("percentInHouse") %>'
                                                                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="width: 60px; float: left;" id="divQuantityAvail" runat="server">
                                                                        <asp:Label ID="txtQuantityAvail" Width="40" Style="color: #000000; background-color: transparent;
                                                                            font-size: 8px;" runat="server" Text='<%#Eval("QuantityAvail") %>'></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <%-- <td>
            <div style="width:35px; float:left;">
            <asp:Label ID="lblBIHETAAcc"  Width="60" style="font-size:8px; color:#807F80 !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM(ddd)") %>' ></asp:Label>
            </div>
            </td>--%>
                                                                <td>
                                                                    <div style="width: 35px; float: left;" id="divRequired" runat="server">
                                                                        <asp:Label ID="txtRequired" Width="40" runat="server" Text='<%#Eval("Required") %>'
                                                                            Style="font-size: 8px !important; background-color: transparent;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="width: 60px; float: left;" id="divAccesoriesETA" runat="server" class="Accessory">
                                                                        <asp:Label ID="lblAccessoriesETA" Width="60" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM (ddd)")%>'
                                                                            runat="server" Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                        <asp:TextBox ID="txtAccessoryWorkingDetailID" CssClass="hide_me txtAccessoryWorkingDetailID"
                                                                            runat="server" Text='<%#Bind("AccessoryWorkingDetailID") %>'></asp:TextBox>
                                                                        <asp:HiddenField ID="hdnRemark" Value='<%#Eval("BIHETARemark") %>' runat="server" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="200px"></HeaderStyle>
                            <ItemStyle Width="200px" CssClass="newcss2 marginpadding"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Technical</label><br/><br/>Deliverable&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ETA"
                            ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="width: 150px; vertical-align: text-top; font-weight: bold; height: 20px;">
                                    PCD:&nbsp;&nbsp;<asp:Label ID="lblPCD" runat="server" Text='<%# (Convert.ToDateTime(Eval("PCD")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PCD")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                    <%--Added By Ashish on 4/3/2015--%>
                                    &nbsp;&nbsp; Fits:&nbsp;&nbsp;<asp:Label ID="lblFitsDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsStatusETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FitsStatusETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                </div>
                                <div style="width: 150px; vertical-align: text-top;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                        <tr>
                                            <td style="text-align: left; width: 90px;" id="tdstc" runat="server">
                                                Stc
                                            </td>
                                            <td id="tdLabel6" runat="server">
                                                <asp:Label ID="Label6" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" id="tdPatternSample" runat="server">
                                                Pattern Sample
                                            </td>
                                            <td id="tdPatternETA" runat="server">
                                                <asp:Label ID="lblPatternETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" id="tdtop" runat="server">
                                                TOP Sent
                                            </td>
                                            <td id="tdTOPETA" runat="server">
                                                <asp:Label ID="lblTOPETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="150px"></HeaderStyle>
                            <ItemStyle Width="150px" CssClass="newcss2 marginpadding"></ItemStyle>
                        </asp:TemplateField>
                        <%--abhishek hide production sec 13/1/2016--%>
                        <asp:TemplateField Visible="false" HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Production</label><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End ETA"
                            ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <div style="vertical-align: top; width: 215px; font-weight: bold; height: 20px;">
                                    Ex Fac:&nbsp;&nbsp;<asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                    <%--<asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderID") %>'></asp:TextBox>--%>
                                    <asp:TextBox ID="txtStyleID" CssClass="hide_me" runat="server" Text='<%#Eval("StyleID") %>'></asp:TextBox>
                                </div>
                                <div style="vertical-align: top; width: 215px;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                        <tr>
                                            <td style="text-align: left; width: 65px;" id="tdCutReady" runat="server">
                                                <asp:Label ID="lvlCutReady" runat="server" Text="Cut Ready"></asp:Label>
                                            </td>
                                            <td style="width: 30px;" id="tdCutPercentInhouse" runat="server">
                                                <asp:Label ID="lblCutPercentInhouse" runat="server" Text='<%#Eval("CutPercentInhouse") %>'></asp:Label>
                                            </td>
                                            <td style="width: 60px;" id="tdCutreadyStartETA" runat="server">
                                                <asp:Label ID="lblCutreadyStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                            <td style="width: 60px;" id="tdCutreadyENDETA" runat="server">
                                                <asp:Label ID="lblCutreadyENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" id="tdStitched" runat="server">
                                                <asp:Label ID="lblStitched" runat="server" Text="Stitched"></asp:Label>
                                            </td>
                                            <td id="tdStitchedPercentInhouse" runat="server">
                                                <asp:Label ID="lblStitchedPercentInhouse" runat="server" Text='<%#Eval("StitchedPercentInhouse") %>'></asp:Label>
                                            </td>
                                            <td id="tdStichedStartETA" runat="server">
                                                <asp:Label ID="lblStichedStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                            <td id="tdStichedENDETA" runat="server">
                                                <asp:Label ID="lblStichedENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVA" runat="server" style="text-align: left;">
                                                <asp:Label ID="lvlVA" runat="server" Text="V.A."></asp:Label>
                                            </td>
                                            <td id="tdVAPercentInhouse" runat="server">
                                                <asp:Label ID="lblVAPercentInhouse" runat="server" Text='<%#Eval("VAPercentInhouse") %>'></asp:Label>
                                            </td>
                                            <td id="tdVAStartETA" runat="server">
                                                <asp:Label ID="lblVAStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                            <td id="tdVAENDETA" runat="server">
                                                <asp:Label ID="lblVAENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" id="tdlPacked" runat="server">
                                                <asp:Label ID="lblPacked" runat="server" Text="Packed"></asp:Label>
                                            </td>
                                            <td id="tdPackedPercentInhouse" runat="server">
                                                <asp:Label ID="lblPackedPercentInhouse" runat="server" Text='<%#Eval("PackedPercentInhouse") %>'></asp:Label>
                                            </td>
                                            <td id="tdPackedETA" runat="server" colspan="2">
                                                <asp:Label ID="lblPackedETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PackedETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PackedETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Width="215px"></HeaderStyle>
                            <ItemStyle Width="215px" CssClass="newcss2 marginpadding"></ItemStyle>
                        </asp:TemplateField>
                        <%--end --%>
                        <asp:TemplateField Visible="true">
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckHeader" OnClick="JavaScript:CheckAll(this.id);" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderDetailID") %>'></asp:TextBox>
                                <asp:TextBox ID="txtNewStyleId" CssClass="hide_me" runat="server" Text='<%#Bind("StyleID") %>'></asp:TextBox>
                                <asp:CheckBox ID="cb" runat="server" Checked="true" />
                            </ItemTemplate>
                            <HeaderStyle Width="20px"></HeaderStyle>
                            <ItemStyle Width="20px" CssClass="newcss2 marginpadding"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div align="center" style="width: 100%; float: left; padding-top: 15px;">
                <fieldset style="border: none; margin: 0px; padding: 0px;">
                    <asp:HiddenField ID="hfexFactoryDate" runat="server" />
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" CssClass="item_list1 fixed-header"
                        Width="100%" OnRowDataBound="gv_rowdatabound">
                        <Columns>
                            <asp:BoundField DataField="ContractNumber" HeaderText="Contract Number" ItemStyle-Font-Size="10px"
                                ItemStyle-CssClass="marginpadding" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Font-Size="10px"
                                ItemStyle-CssClass="marginpadding" />
                            <asp:TemplateField HeaderText="Calculated B.I.H" ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top"
                                FooterStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <%-- <%# Eval("CalculatedBIH")%>--%>
                                    <asp:Label ID="lblCalBIH" runat="server" Text='<%# Eval("CalculatedBIH")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="StartETAdate" HeaderText="B.I.H Start ETA" />--%>
                            <asp:TemplateField HeaderText="B.I.H Start ETA">
                                <ItemTemplate>
                                    <%--<%# Eval("StartETAdate")%>--%>
                                    <asp:Label ID="lblSDate" runat="server" Text='<%# Eval("StartETAdate")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="newcss2 marginpadding"></ItemStyle>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="EndETAdate" HeaderText="B.I.H End ETA" />--%>
                            <asp:TemplateField HeaderText="B.I.H End ETA">
                                <ItemTemplate>
                                    <%--<%# Eval("EndETAdate")%>--%>
                                    <asp:Label ID="lblEDate" runat="server" Text='<%# Eval("EndETAdate")%>'></asp:Label>
                                    <asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderID") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckHeader" OnClick="JavaScript:CheckAll(this.id);" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderDetailID") %>' />
                                    <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%#Bind("StyleID") %>' />
                                    <asp:TextBox ID="txtId" CssClass="hide_me" runat="server" Text='<%#Bind("StyleID") %>'></asp:TextBox>
                                    <%--<asp:HiddenField ID="hdnAccessoryId" runat="server" Value='<%#Bind("AccessoryId") %>' />
                            <asp:HiddenField ID="hdnAccessoryName" runat="server" Value='<%#Bind("AccessoryName") %>' />
                            <asp:HiddenField ID="hdnCutDetailId" runat="server" Value='<%#Bind("CutDetailId") %>' />
                            <asp:HiddenField ID="hdnStitchingDetailID" runat="server" Value='<%#Bind("StitchingDetailID") %>' />
                            <asp:HiddenField ID="hdnOnlyEmbhistoryID" runat="server" Value='<%#Bind("OnlyEmbhistoryID") %>' />--%>
                                    <asp:CheckBox ID="cb" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" Visible="false" runat="server" AutoGenerateColumns="false"
                        CssClass="item_list1 fixed-header" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ContractNumber" HeaderText="Contract Number" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="SerialNumber" HeaderText="SerialNumber" />
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%#Bind("StyleID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </div>
            <asp:GridView ID="GvFitsETA" Visible="false" runat="server" AutoGenerateColumns="false"
                CssClass="item_list1 fixed-header" Width="100%">
                <Columns>
                    <asp:BoundField DataField="ContractNumber" HeaderText="Contract Number" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="SerialNumber" HeaderText="SerialNumber" />
                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%#Bind("StyleID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <div>
        <input type="button" id="btnSubmit1" class="submit" value="Submit" runat="server"
            onclick="JavaScript:UpdateMoEtaRemarks();" />
        <asp:Button ID="btnAccess" runat="server" class="submit" Text="Submit" OnClick="btnAccess_Click" />
        <input type="button" onclick="window.close();" value="Close" class="close do-not-disable da_submit_button" />
    </div>
</div>
