<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Department.aspx.cs"
    Inherits="iKandi.Web.Internal.Client.Create_Department" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">

        function PopupClose() {
            window.self.close();
            window.opener.location.reload();
        }
        function ShowAlert(Msg) {
            alert(Msg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <div style="width: 500px; margin: 0px auto;">
                    <h2 style="width: 100%; color: #fff; background: #39589c; text-align: center; margin: 5px 0px;
                        padding: 5px;">
                        Parent Department Admin
                    </h2>
                    <br />
                    <asp:GridView runat="server" ID="grdDepartmentAdmin" Width="100%" CellPadding="0"
                        CellSpacing="0" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true"
                        OnRowCommand="grdDepartmentAdmin_OnRowCommand" OnRowUpdating="grdDepartmentAdmin_RowUpdating"
                        OnRowEditing="grdDepartmentAdmin_RowEditing" OnRowCancelingEdit="grdDepartmentAdmin_RowCanceling"
                        CssClass="item_list2">
                        <Columns>
                            <asp:TemplateField HeaderText="Dept. Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDeptName" Text='<%# Eval("DepartmentName") %>' style="text-transform: none !important;"></asp:Label>
                                    <asp:HiddenField ID="hdnDeptID" Value='<%# Eval("Id") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80%" />
                                <HeaderStyle Width="80%" />
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="Edit_TxtDeptName" Width="95%" Text='<%# Eval("DepartmentName") %>'></asp:TextBox>
                                    <asp:HiddenField ID="Edit_hdnDeptID" Value='<%# Eval("Id") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="Foo_TxtDeptName" Width="95%"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
                                HeaderText="Action" ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
                                UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
                                CausesValidation="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:LinkButton runat="server" ID="Submit" CommandName="Insert">
                                        <img alt="" src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <th>
                                        Dept. Name
                                    </th>
                                    <th>
                                        Action
                                    </th>
                                    <th>
                                        &nbsp;
                                    </th>
                                </tr>
                                <tr>
                                    <td width="80%">
                                        <asp:TextBox runat="server" ID="TxtDeptName" Text="" Width="95%"></asp:TextBox>
                                    </td>
                                    <td width="10%">
                                        &nbsp;
                                    </td>
                                    <td width="10%">
                                        <asp:LinkButton runat="server" ID="Submit" CommandName="EmptyInsert">
                                            <img alt="" src="../../images/add-butt.png" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" CssClass="submit" Text="Submit" OnClientClick="Javascript:return PopupClose();" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
