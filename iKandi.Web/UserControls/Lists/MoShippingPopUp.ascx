<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoShippingPopUp.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.MoShippingPopUp" %>
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi.css" />

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
                $(this).attr('checked', chk);
            }
        });
    }

    function UpdateMoShipping() {
        //alert('test')
        // debugger;
        var ids = "";
        var IsPCdateChange = 0;
        $("#" + '<%=gv.ClientID%>' + " tbody tr").each(function () {
            if ($(this).find("input[type=hidden]").length > 0) {
                if ($(this).find("input[type=checkbox]").attr('checked') == true) {
                    if (ids.length > 0)
                        ids += ",";
                    ids += $(this).find("input[type=hidden]").val();
                }
            }
        });
        var rem = $("#" + '<%=txtremarks.ClientID%>').val();
        var exfactory = $("#" + '<%=txtExFactory.ClientID%>').val();

        if (ids.length < 1) {
            alert('Please select the contract to replicate shipping remarks and exfactory date');
            return;
        }
        if (exfactory != '') {
            var r = confirm("Do You Want To change PC date also!");
            if (r == true) {
                IsPCdateChange = 1;
            }
        }
        //isBackSlashKey();
        UpdateMoShippingRemark(ids, rem, exfactory, IsPCdateChange);
    }


    function UpdateMoShippingRemark(ids, rem, exfactory, isPCdateChange) {
        //debugger;
        //alert('helo');
        proxy.invoke("UpdateRemarksShipping", { Remarks: rem, Ids: ids, ExFactoryDate: exfactory, IsPcDateChanged: isPCdateChange }, function () {
            jQuery.facebox("Remarks have been submitted successfully");
            $(".divRemarksMo").html("");
            $(".divRemarksMo").hide();
            jQuery(document).trigger('close.facebox');
            $(".go").click();
        }, onPageError, false, false);
    }

    $(document).ready(function () {
        $('input.date-picker1', '#mcontent').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });
    });


    //    function isBackSlashKey() {
    //        debugger;
    //        var evt = $("#" + '<%=txtremarks.ClientID%>').val();
    //        evt = (evt) ? evt : window.event;
    //        var charCode = (evt.which) ? evt.which : evt.keyCode;
    //        if (charCode === 92) { //If you want allow back space than check it (charcode === 92 || charcode === 8)
    //            return true;
    //        }
    //        return false;
    //    }
</script>

<div class="form_box" id="mcontent"> 
    <div id="frmHed" class="form_heading">
        Remarks</div>
    <br />
    <table width="100%" style="" cellpadding="6px">
        <tr>
            <td style="width: 40%; max-height: 150px; vertical-align: top;">
                <div class="tempClass">
                    Style Number :
                </div>
            </td>
            <td style="width: 60%; vertical-align: top;">
                <div style="width: 100%; overflow: auto  ! important;">
                    <asp:Label ID="lblStyleNumber" runat="server" CssClass="label-remarks" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="max-height: 150px; vertical-align: top;">
                <div class="tempClass">
                    Remarks :
                </div>
            </td>
            <td style="vertical-align: top;">
                <div style="width: 100%; overflow: auto  ! important;">
                    <asp:Label ID="lblShowRemark" runat="server" CssClass="label-remarks" />
                </div>
            </td>
        </tr>
        <tr class="permission-text-remarks">
            <td style="vertical-align: top;">
                Enter Remarks :
            </td>
            <td style="vertical-align: top ! important;">
                <asp:TextBox Columns="80" Rows="5" ID="txtremarks" class="text-remarks" runat="server"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="max-height: 150px; vertical-align: middle;">
                <div class="tempClass">
                    Ex Factory Date :
                </div>
            </td>
            <td style="vertical-align: top;">
                <div style="width: 100%; overflow: auto  ! important;">
                    <asp:TextBox ID="txtExFactory" runat="server" CssClass="date-picker1 do-not-disable"/>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <fieldset>
            <asp:HiddenField ID="hfexFactoryDate" runat="server" />
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" CssClass="item_list1 fixed-header" Width="100%" OnRowDataBound="gv_rowdatabound">
                <Columns>
                    <asp:BoundField DataField="SerialNumber" HeaderText="Serial Number" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="ContractNumber" HeaderText="Contract Number" />
                    <asp:TemplateField HeaderText="ExFactory">
                        <ItemTemplate>
                            <label style='<%# " width : 140px ! important; font-size:11px; background-color :" + Eval("ExFactoryColor").ToString() %>' class="blue-text"><%# Eval("ExFactoryInString")%></label>
                            <br /><br />
                            <label style="font-size:9px;" ><%# (Eval("PlannedExInString").ToString() == "" ? "" : string.Format("({0})",Eval("PlannedExInString")))%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DC Date">
                        <ItemTemplate>
                            <%# Eval("DCInString")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ModeName" HeaderText="Mode" />
                    <asp:TemplateField Visible="true">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckHeader" OnClick="JavaScript:CheckAll(this.id);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hf" runat="server" Value='<%#Bind("OrderId") %>' />
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <br />
    <div>
        <input type="button" id="btnSubmit" class="submit" runat="server" onclick="JavaScript:UpdateMoShipping();" />
        <input type="button" onclick="JavaScript:closeMoRemarks()" class="close do-not-disable" />
    </div>
</div>
