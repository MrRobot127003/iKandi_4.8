<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveTypes.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.LeaveTypes" %>
<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Holiday Types
        </div>
        <div>
            <asp:GridView ID="gvLeaveTypes" runat="server" AutoGenerateColumns="False" CssClass="item_list fixed-header"
                AllowPaging="True" DataSourceID="odsLesveTypes" DataKeyNames="LeaveTypeID" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUpdateName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtUpdateName" runat="server" Display="Dynamic"
                                ControlToValidate="txtUpdateName" ErrorMessage="Name is required" ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtInsertName" runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtInsertName" runat="server" Display="Dynamic"
                                ControlToValidate="txtInsertName" ErrorMessage="Name is required" ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Holidays Allowed" SortExpression="MaxAllowed">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUpdateMaxAllowed" runat="server" Text='<%# Bind("MaxAllowed") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtUpdateMaxAllowed" runat="server" Display="Dynamic"
                                ControlToValidate="txtUpdateMaxAllowed" ErrorMessage="MaxAllowed is required"
                                ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfv_numeric_txtUpdateMaxAllowed" runat="server" ControlToValidate="txtUpdateMaxAllowed"
                                ErrorMessage="Enter only Numbers" ValidationGroup="EditValidationControls" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MaxAllowed") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtInsertMaxAllowed" runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtInsertMaxAllowed" runat="server" Display="Dynamic"
                                ControlToValidate="txtInsertMaxAllowed" ErrorMessage="MaxAllowed is required"
                                ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfv_numeric_txtInsertMaxAllowed" runat="server" ControlToValidate="txtInsertMaxAllowed"
                                ErrorMessage="Enter only Numbers" ValidationGroup="InsertValidationControls"
                                ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Type" SortExpression="CompanyType">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlUpdateCompanyType" runat="server" SelectedValue='<%#  Bind("CompanyTypeID") %>'>
                                <asp:ListItem Text="iKandi" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Boutique" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CompanyType") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlInsertCompanyType" runat="server" >
                                <asp:ListItem Text="iKandi" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Boutique" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" ValidationGroup="EditValidationControls"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" OnClientClick="return confirm('Are you sure, you want to delete this Leave Type?')" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkBtnInsert" runat="server" CommandName="Insert" OnClick="lnkBtnInsert_Click"
                                ValidationGroup="InsertValidationControls" CausesValidation="true">Insert
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkBtnInsertCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" OnClick="lnkBtnInsertCancel_Click"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
<asp:ObjectDataSource ID="odsLesveTypes" runat="server" DataObjectTypeName="iKandi.Common.LeaveType"  
    DeleteMethod="DeleteLeaveType" InsertMethod="InsertLeaveType" SelectMethod="GetAllLeaveTypes"
    TypeName="iKandi.BLL.LeaveController" UpdateMethod="UpdateLeaveType">
    <DeleteParameters>
        <asp:Parameter Name="LeaveTypeID" Type="Int64" />
    </DeleteParameters>
</asp:ObjectDataSource>
