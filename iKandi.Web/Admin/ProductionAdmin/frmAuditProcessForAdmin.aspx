<%@ Page Language="C#" Title="Audit Process For Admin" MasterPageFile="~/layout/Secure.Master"
    AutoEventWireup="true" CodeBehind="frmAuditProcessForAdmin.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.frmAuditProcessForAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        body
        {
            text-transform: capitalize;
        }
        .item_list2 th
        {
            border-color: #999;
        }
        .item_list2 td
        {
            font-size: 11px !important;
            text-align: justify;
        }
        .item_list2 td:first-child
        {
            border-left-color: #999;
        }
        .item_list2 td:last-child
        {
            border-right-color: #999;
        }
        .item_list2 tr:last-child > td
        {
            border-bottom-color: #999;
        }
        span
        {
            color: Gray;
        }
        a
        {
            text-decoration: none;
        }
        input[type="radio"]
        {
            position: relative;
            top: 3px;
            margin: 0px 5px 0px 0px;
        }
        label
        {
            margin-right: 10px;
        }
        .go
        {
            font-weight: 500;
            padding: 2px 10px;
            margin-bottom: 5px;
            border-radius: 2px;
        }
        .go:hover
        {
            font-weight: 500;
            padding: 2px 10px;
            margin-bottom: 5px;
            border-radius: 2px;
        }
        .txtCenter
        {
            text-align:center !important;
         }
         .submit
         {
             border-radius:2px;
             cursor:pointer;
         }
         input[type="text"]
         {
            font-size: 11px !important;
          }
    </style>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateData() {
            // debugger;
            var $elems = $('.checkSequence');
            var values = [];
            var isDuplicated = false;
            $elems.each(function () {
                if (!this.value) return true;
                if (values.indexOf(this.value) !== -1) {
                    icheck = 1
                }
                values.push(this.value);
            });

            if (icheck == 1) {
                alert("You have already entered a Sequence more than once");
                return false;
            }
        }

        function ShowAlert(Msg) {
            alert(Msg);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div style="width: 500px; margin: 0px auto;">
                <h2 style="width: 100%; color: #fff; background: #39589c; text-align: center; margin: 5px 0px;
                    padding: 0px 0px;">
                    Compliance & QC Process Admin
                </h2>
                <div style="width: 50%; float: left;">
                    <asp:RadioButtonList ID="rdoCompliance" runat="server" RepeatDirection="Horizontal"
                        CellPadding="0" CellSpacing="0">
                        <asp:ListItem Value="1" Text="Compliance" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="QC Process"></asp:ListItem>
                        <asp:ListItem Value="-1" Text="Out House" style="display: none;"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div style="float: left; width: 25%; position: relative; top: 1px;">
                    <asp:DropDownList runat="server" ID="ddlUnit" Width="90%" OnSelectedIndexChanged="OnSelectedfactorychanged"
                        AutoPostBack="true">
                        <%--  <asp:ListItem Value="3" Text="C-47"></asp:ListItem>
       <asp:ListItem Value="11" Text="C-45-46"> </asp:ListItem>
        <asp:ListItem Value="-1" Text="Out House"> </asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div style="float: left">
                    <asp:Button ID="btnGoProcess" runat="server" OnClick="btn_Go" CssClass="go" Text="Go" />
                </div>
                <br />
                <asp:GridView runat="server" ID="grdComplianceAdmin" Width="100%" CellPadding="0"
                    CellSpacing="0" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true"
                    OnRowDataBound="grdComplianceAdmin_RowDataBound" OnRowCommand="grdComplianceAdmin_OnRowCommand"
                    OnRowUpdating="grdComplianceAdmin_RowUpdating" OnRowDeleting="grdComplianceAdmin_RowDeleting"
                    OnRowEditing="grdComplianceAdmin_RowEditing" OnRowCancelingEdit="grdComplianceAdmin_RowCanceling"
                    CssClass="item_list2">
                    <Columns>
                        <asp:TemplateField HeaderText="ProcessName">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblComplianceProcess" Text='<%# Eval("ProcessName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnInternal_Audit_ProcessID" Value='<%# Eval("Internal_Audit_ProcessID") %>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="80%" />
                            <HeaderStyle Width="80%" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="Edit_TxtComplianceProcess" Width="95%" Text='<%# Eval("ProcessName") %>'></asp:TextBox>
                                <asp:HiddenField ID="Edit_hdnInternal_Audit_ProcessID" Value='<%# Eval("Internal_Audit_ProcessID") %>'
                                    runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="Foo_TxtComplianceProcess" Width="95%"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Action" EditImageUrl="../../images/edit2.png" ShowEditButton="True"
                            ButtonType="Image" CancelImageUrl="../../images/del-butt.png" ShowDeleteButton="true"
                            UpdateImageUrl="../../images/update.gif" DeleteImageUrl="../../images/delete-icon.png"
                            CausesValidation="true">
                            <ItemStyle HorizontalAlign="Center" CssClass="txtCenter" Width="12%" />
                            <HeaderStyle Width="12%" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="Submit" OnClick="Add_data" CommandName="Insert">
                       <img src="../../images/add-butt.png" />
                                </asp:LinkButton>
                            </FooterTemplate>
                            <ItemStyle Width="10%" />
                            <FooterStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <th>
                                    ProcessName
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
                                    <asp:TextBox runat="server" ID="TxtComplianceProcess" Text="" Width="95%"></asp:TextBox>
                                </td>
                                <td width="10%">
                                    &nbsp;
                                </td>
                                <td width="10%">
                                    <asp:LinkButton runat="server" ID="Submit" OnClick="Add_data" CommandName="EmptyInsert">
    <img src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
             
                <%--OnRowCancelingEdit="grdbindprocessadmin_RowCancelingEdit" OnRowUpdating="grdbindprocessadmin_RowUpdating" 
      onrowediting="grdbindprocessadmin_RowEditing"--%>
                <asp:GridView runat="server" ID="grdbindprocessadmin" Width="100%" CellPadding="0"
                    CellSpacing="0" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true"
                    CssClass="item_list2" OnRowDataBound="grdbindprocessadmin_RowDataBound" OnRowCommand="grdbindprocessadmin_OnRowCommand"
                    OnRowCancelingEdit="grdbindprocessadmin_RowCancelingEdit" OnRowUpdating="grdbindprocessadmin_RowUpdating"
                    OnRowEditing="grdbindprocessadmin_RowEditing" style="margin-top:5px;">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="30px">
                            <HeaderTemplate>
                               No.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                            <ItemStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <HeaderTemplate>
                                Sequence
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlSequence" runat="server" AppendDataBoundItems="true" CssClass="checkSequence">
                                </asp:DropDownList>
                                <asp:Label runat="server" ID="lblSequence" Text='<%# Eval("SequenceNumber") %>' Style="display: none;"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnQAComplaine_TypeAdminID" Value='<%# Eval("QAComplaine_TypeAdminID")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSequence" runat="server" AppendDataBoundItems="true" CssClass="checkSequence"
                                    Enabled="false">
                                </asp:DropDownList>
                                <asp:Label runat="server" ID="lblSequence" Text='<%# Eval("SequenceNumber") %>' Style="display: none;"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnSequence" Value='<%# Eval("SequenceNumber") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                              <ItemStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="180px">
                            <HeaderTemplate>
                                Audit Parameter
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAuditParameter" Text='<%# Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtAuditParameter" Text='<%# Eval("Description") %>'></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hdnQAComplaine_TypeAdminID" Value='<%# Eval("QAComplaine_TypeAdminID")%>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtfooAuditParameter" Width="80%"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="90px">
                            <HeaderTemplate>
                                Is Active
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlIsActive" Width="80%">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%# Eval("IsActive") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlIsActive" Width="80%" Enabled="false">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%# Eval("IsActive") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList runat="server" ID="ddlFooIsActive" Width="80%">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemStyle CssClass="txtCenter" />
                            <FooterStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="30px">
                            <HeaderTemplate>
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="BtnEdit" CommandName="Edit">
                       <img src="../../images/edit2.png" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" ID="BtnUpdate" CommandName="Update">
                       <img src="../../images/update.gif" />
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="BtnCancel" CommandName="Cancel">
                       <img src="../../images/del-butt.png" />
                                </asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="BtnSubmit" CommandName="Insert">
                       <img src="../../images/add-butt.png" />
                                </asp:LinkButton>
                            </FooterTemplate>
                            <ItemStyle CssClass="txtCenter" />
                            <FooterStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="submit"
                    Text="Submit" style="margin-top:5px;" OnClientClick="Javascript:return ValidateData();" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
