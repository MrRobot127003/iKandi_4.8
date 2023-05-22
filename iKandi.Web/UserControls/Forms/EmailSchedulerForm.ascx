<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailSchedulerForm.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.EmailSchedulerForm" %>

<script type="text/javascript">
    jQuery.expr[':'].regex = function(elem, index, match) {
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

    $(document).ready(function() {
        $("select:regex(id,ddlPlan)").each(function() {
            var id = $(this).attr("id");
            var txt = $("#" + id + " option:selected").text();
            var chk = true;
            if (txt.toUpperCase() == "WEEKLY")
                chk = false;
            else
                chk = true;
            $("input[type=checkbox]:regex(id," + id.substring(0, id.indexOf("ddlPlan")) + "cblWeek" + ")").attr('disabled', chk);
        });

        $("select:regex(id,ddlPlan)").each(function() {
            var id = $(this).attr("id");
            $("#" + id).change(function() {
                var txt = $("#" + id + " option:selected").text();
                var chk = true;
                if (txt.toUpperCase() == "WEEKLY")
                    chk = false;
                else
                    chk = true;
                $("input[type=checkbox]:regex(id," + id.substring(0, id.indexOf("ddlPlan")) + "cblWeek" + ")").attr('disabled', chk);
            });
        });
    });

    function checkAll() {
        var chk = true;
        $("select:regex(id,ddlPlan)").each(function() {
            var id = $(this).attr("id");
            var txt = $("#" + id + " option:selected").text();
            if (txt.toUpperCase() == "WEEKLY") {
                var flag = false;
                $("input[type=checkbox]:regex(id," + id.substring(0, id.indexOf("ddlPlan")) + "cblWeek" + ")").each(function() {
                    if ($(this).is(":checked") == true) {
                        flag = true;
                        return;
                    }
                });
                if (flag == false) {
                    alert("Please select check box for Title : " + $("#" + id.substring(0, id.indexOf("ddlPlan")) + "lblTitle").html());
                    chk = false;
                    return;
                }
            }
        });
        return chk;
    }
</script>

<asp:Panel ID="pnlEmailTemplateForm" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td class="da_table_heading_bg">
                <span class="da_h1">Email Scheduler</span>
            </td>
            <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>
        </tr>
    </table>
    <div style="text-align: center;">
        <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEmail_RowDataBound"
            CssClass="item_list fixed-header da_header_heading" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>' />
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Bind("EmailTemplateID")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <%#Eval("Description")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Plan" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlPlan" runat="server">
                            <asp:ListItem Text="Daily" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Weekly" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Days" ControlStyle-Width="400px">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="cblWeek" runat="server" RepeatDirection="Horizontal" CssClass="item_listtable">
                        </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlTime" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <div align="left">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
            CssClass="da_submit_button" OnClientClick="JavaScript:return checkAll();" />
            </div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
</asp:Panel>
