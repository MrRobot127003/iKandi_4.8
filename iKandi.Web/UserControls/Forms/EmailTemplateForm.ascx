<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateForm.ascx.cs"
    Inherits="iKandi.Web.EmailTemplateForm"  %>
<%--<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>--%>
<style type="text/css">
    .style1
    {
        width: 524px;
    }
    .print
    {
        height: 26px;
    }
</style>

<script type="text/javascript">

    $(function() {
        $(".chk-department").click(function() {

            var chkBox = $(this).find("input:checked");
            var desList = $(this).parents(".department-list").find(".designations-list");

            if (chkBox.is(':checked')) {

                desList.find("input:checked").each(function() {

                    if ($(this).is(':checked')) {
                        $(this).attr("checked", false);
                    }
                });
            }
        });

        $(".chk-designation").click(function() {

            var chkBox = $(this).find("input");

            if (chkBox.is(':checked')) {

                $(this).parents(".department-list").find(".chk-department").find("input").attr("checked", false);

            }

        });

    });


</script>

<asp:Panel ID="pnlEmailTemplateForm" runat="server">
    <div class="print-box">
        <div class="form_box">
            <div class="form_heading">
                <strong>Email Template</strong>
            </div>
            <table cellspacing="15" width="100%" style="height: 241px">
                <tr>
                    <td class="style1">
                        Title
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" Width="100%" runat="server" MaxLength="43"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Subject
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" Width="100%" runat="server" MaxLength="253"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Description
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" Width="100%" runat="server" MaxLength="498"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Content
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtContent" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>--%>
                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" ToolbarSet="MyToolbar" EnableViewState="false"
                            Width="100%" StartupFocus="false" Height="200px" BasePath="~/fckeditor/">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Recepients
                    </td>
                    <td>
                        <asp:Repeater runat="server" ID="rptDepartments" OnItemDataBound="rptDepartments_ItemDataBound">
                            <ItemTemplate>
                                <div class="department-list">
                                    <asp:CheckBox runat="server" CssClass="chk-department" ID="chkDepartment" Text='<%# Eval("DepartmentName") %>' />
                                    <asp:HiddenField runat="server" ID="hdnDepartmentID" Value='<%# Eval("DepartmentID") %>' />
                                    <div style="margin-left: 15px" class="designations-list">
                                        <asp:Repeater runat="server" ID="rptDesignations" OnItemDataBound="rptDesignations_ItemDataBound">
                                            <ItemTemplate>
                                                <div>
                                                    <asp:CheckBox runat="server" CssClass="chk-designation" ID="chkDesignation" Text='<%# Eval("Name") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnDesignationID" Value='<%# Eval("DesignationID") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Email Template have been saved into the system successfully!
            <br />
            <a id="A1" href="../../Admin/EmailTemplate/EmailTemplateListing.aspx" runat="server">
                Click here </a>to Email Template List.</div>
    </div>
</asp:Panel>
