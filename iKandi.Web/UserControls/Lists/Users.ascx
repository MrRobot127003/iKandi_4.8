<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="iKandi.Web.UserControls.Users" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style>
    .header-text-back
    {
        padding: 2px 0px !important;
        font-size: 15px !important;
       
    }
    .input_in
    {
        height: 12px !important;
        border-radius: 3px;
    }
    .item_list td:first-child
    {
        border-left-color: #999 !important;
    }
    .item_list td:last-child
    {
        border-right-color: #999 !important;
    }
    .item_list tr:last-child > td
    {
        border-bottom-color: #999 !important;
    }
</style>
<div class="print-box">
    <h2 class="header-text-back">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="1009" style="text-align: left; padding-left: 10px">
                    Users &nbsp; 
                    <asp:DropDownList ID="ddlactiive" Style="width: 100px; height: 18px;" runat="server">
                        <asp:ListItem Text="ALL" Selected="True" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="In-Active" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="202" style="padding-right: 20px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="27%" class="da_search_heading">
                                Search
                            </td>
                            <td width="73%">
                                <asp:TextBox runat="server" ID="txtSearchText" CssClass="input_in"></asp:TextBox>
                            </td>
                            <td width="73%">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="da_go_button go"
                                    OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </h2>
    <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" CssClass="da_header_heading item_list"
        Width="100%" OnRowDataBound="grdUsers_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Company" ItemStyle-CssClass="da_table_tr_bg" HeaderText="Company"
                SortExpression="Company" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%" />
            <asp:TemplateField HeaderText="Registration" ItemStyle-CssClass="da_table_tr_bg"
                SortExpression="Registration" ItemStyle-VerticalAlign="Top" ItemStyle-Width="25%">
                <ItemTemplate>
                    <div>
                        <span class="field_label">Name:</span>
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("FullName") %>'></asp:Label><br />
                        <span class="field_label">Email:</span> <a class="da_edit_delete_link" href="mailto:<%# Eval("Email") %>">
                            <%# Eval("Email") %></a><br />
                        <span class="field_label">Office Phone:</span>
                        <asp:Label ID="Label31" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Allocation" ItemStyle-CssClass="da_table_tr_bg" SortExpression="Allocation"
                ItemStyle-VerticalAlign="Top" ItemStyle-Width="30%">
                <ItemTemplate>
                    <div align="left">
                        <span class="field_label">Username:</span>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                        <span class="field_label">Password:</span>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Password") %>'></asp:Label><br />
                        <span class="field_label">Primary Group (Dept):</span>
                        <asp:Label ID="Label41" runat="server" Text='<%# Eval("PrimaryGroupName") %>'></asp:Label><br />
                        <span class="field_label">Designation:</span>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# (Eval("DesignerCode").ToString() == "-1" ) ? "" : "Code:" + Eval("DesignerCode").ToString() %>'></asp:Label><br />
                        <span class="field_label">Line Manager:</span>
                        <asp:Label ID="Label33" runat="server" Text='<%# Eval("ManagerName") %>'></asp:Label><br />
                        <span class="field_label">Weeks off:</span>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("WeekOff") %>'></asp:Label><br />
                        <span class="field_label">Is Staff:</span>
                        <asp:CheckBox ID="chkisstaff" runat="server" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("IsStaff"))%>' /><br />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Personal" ItemStyle-CssClass="da_table_tr_bg" SortExpression="Personal"
                ItemStyle-VerticalAlign="Top" ItemStyle-Width="30%">
                <ItemTemplate>
                    <div align="left">
                        <a border="0" href='<%# ResolveUrl("~/uploads/photo/" + Eval("PhotoPath").ToString()) %>'
                            class="thickbox <%# (Eval("PhotoPath") == null || string.IsNullOrEmpty(Eval("PhotoPath").ToString()) ) ? "hide_me": "" %>">
                            <img width="80px" border="0" align="right" src='<%# ResolveUrl("~/uploads/photo/" + Eval("PhotoPath").ToString()) %>'
                                visible='<%# (Eval("PhotoPath") == null || string.IsNullOrEmpty(Eval("PhotoPath").ToString()) ) ? false: true %>' />
                        </a><span class="field_label">Address:</span>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
                        <span class="field_label">Email:</span> <a class="da_edit_delete_link" href="mailto:<%# Eval("PersonalEmail") %>">
                            <%# Eval("PersonalEmail")%></a><br />
                        <span class="field_label">Phone:</span>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
                        <span class="field_label">Mobile:</span>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label><br />
                        <span class="field_label">BirthDay:</span>
                        <asp:Label ID="Label34" runat="server" Text='<%# Eval("BirthDay", "{0:dd MMM yy (ddd) }") %>'></asp:Label><br />
                        <span class="field_label">Anniversary:</span>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Anniversary", "{0:dd MMM yy (ddd) }") %>'></asp:Label><br />
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("UserID") %>' Visible="false"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField ItemStyle-VerticalAlign="Top" DataNavigateUrlFields="UserID"
                DataNavigateUrlFormatString="~/internal/users/UserEdit.aspx?userid={0}" Text="Edit"
                ItemStyle-CssClass="da_edit_delete_link" />
        </Columns>
    </asp:GridView>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
</div>
<asp:Button ID="Button1" runat="server" Text="Add" CssClass="da_submit_button submit"
    PostBackUrl="~/internal/Users/UserEdit.aspx"></asp:Button>
<input type="button" id="btnPrint" class="da_submit_button" value="Print" onclick="return PrintPDF();" />