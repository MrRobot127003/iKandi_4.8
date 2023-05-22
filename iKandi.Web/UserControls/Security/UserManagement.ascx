<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.ascx.cs" Inherits="iKandi.Web.UserControls.Security.UserManagement" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="print-box">
<h2 class="header-text-back">
<asp:Label runat="server" ID="Label1">Users</asp:Label></h2>

<div class="content_middle" align="center">
    <div>
        <asp:Label ID="LabelMessage" runat="server" ForeColor="red"></asp:Label>
    </div>
    <asp:GridView ID="GridViewMemberUser" runat="server" AutoGenerateColumns="False"
        DataKeyNames="UserName" DataSourceID="ObjectDataSourceMembershipUser"
         CssClass="da_header_heading item_list" Width="100%" EmptyDataText="No user(s) found in the database"
        PageSize="20" OnPageIndexChanging="GridViewMemberUser_PageIndexChanging" OnRowUpdated="GridViewMemberUser_RowUpdated"
        OnRowUpdating="GridViewMemberUser_RowUpdating" OnRowEditing="GridViewMemberUser_RowEditing"
        OnRowDeleted="GridViewMemberUser_RowDeleted" 
        OnRowDeleting="GridViewMemberUser_RowDeleting" AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="Username" SortExpression="UserName">
                <EditItemTemplate>
                    <asp:Label ID="UserName" CssClass="da_table_tr_bg"  runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="UserName" CssClass="da_table_tr_bg" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    <div>
                 
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:CheckBoxField DataField="IsApproved" HeaderText="Is Approved" SortExpression="IsApproved" />
            <asp:TemplateField HeaderText="Roles">
                <EditItemTemplate>
                     
                                <asp:CheckBoxList CssClass="da_table_tr_bg" ID="roleList" runat="server" DataSourceID="ObjectDataSource1" OnDataBound="roleList_DataBound">
                                </asp:CheckBoxList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
                                    InsertMethod="GetUsersInRole" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRoles"
                                    TypeName="iKandi.BLL.Security.RoleDataObject">
                                    <DeleteParameters>
                                        <asp:Parameter Name="roleName" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="roleName" Type="String" />
                                    </InsertParameters>
                                </asp:ObjectDataSource>
                          
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" CssClass="da_table_tr_bg" runat=server Text='<%# GetAllUserRoles(Eval("UserName").ToString()) %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" >
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update" CssClass="da_edit_delete_link"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" CssClass="da_edit_delete_link"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit" CssClass="da_edit_delete_link"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" Visible=false OnClientClick="return confirm('Are you sure, you want to delete this member?')"
                        runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       
    </asp:GridView>
    <%--<asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/App_Data/Industry.xml">
    </asp:XmlDataSource>--%>
    <asp:ObjectDataSource ID="ObjectDataSourceMembershipUser" runat="server" DeleteMethod="Delete"
        SelectMethod="GetMembers" TypeName="iKandi.BLL.Security.MembershipUserODS" OldValuesParameterFormatString="original_{0}"
        UpdateMethod="UpdateUsers" SortParameterName="SortData">
        <DeleteParameters>
            <asp:Parameter Name="UserName" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <%--<asp:Parameter Name="UserName" Type="String" />--%>
            <asp:Parameter Name="isApproved" Type="Boolean" DefaultValue="True"  />
            <asp:Parameter Name="firstName" Type="String" />
           <%--<asp:Parameter Name="middleName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <%--<asp:Parameter Name="industry" Type="Int32" />
            <asp:Parameter Name="address1" Type="String" />
            <asp:Parameter Name="address2" Type="String" />--%>
            <asp:Parameter Name="cityProvince" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="country" Type="String" />
            <asp:Parameter Name="phoneNumber" Type="String" />
            <asp:Parameter Name="company" Type="String" />
            <%--<asp:Parameter Name="areaOfPCInterest" Type="String" />--%>
            <asp:Parameter Name="original_UserName" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter Name="sortData" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
</div><br />
<input type="button" id="btnPrint" value="Print" class="da_submit_button" onclick="return PrintPDF();" />
