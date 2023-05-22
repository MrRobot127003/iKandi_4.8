<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCFaults.ascx.cs" Inherits="iKandi.Web.QCFaults" %>
<%@ Register Assembly="iKandi.Common" Namespace="iKandi.Common" TagPrefix="cc1" %>
<%@ Register Assembly="iKandi.Common" Namespace="iKandi.Common" TagPrefix="cc2" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.item_list th
{
    font-weight:bold;
}
.item_list TD input[type=text], .item_list TD textarea {
    width: 98%;
}
</style>
<h2 class="header-text-back">QA Faults </h2>
        
 
  

<div class="form_box">
    <asp:GridView ID="grdFaults" runat="server" Width="100%" CssClass="da_header_heading item_list"
        AutoGenerateColumns="false" OnRowDataBound="grdFaults_RowDataBound" AllowPaging="true"
        PageSize="20" OnPageIndexChanging="grdFaults_OnPageIndexChanging" DataKeyNames="Id"
        DataSourceID="ObjectDataSource1" ShowFooter="true" 
        OnRowUpdating="grdFaults_RowUpdating" 
         OnRowDeleting="grdFaults_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Code" ItemStyle-CssClass="da_table_tr_bg" SortExpression="FaultCode">
                <ItemTemplate>
                    <asp:HiddenField ID="hiddenId" Value='<%# Eval("Id") %>' runat="server"  />
                    <asp:Label runat="server" ID="lblFaultCode" Text='<%# Eval("FaultCode") %>' CssClass="da_table_tr_bg"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtFaultCode" Text='<%# Bind("FaultCode") %>' CssClass="input_in"></asp:TextBox>
                    <div class="form_error">
                        <asp:RequiredFieldValidator ID="rfv_txtFaultCode" runat="server" Display="Dynamic" 
                            ControlToValidate="txtFaultCode" ErrorMessage="Fault Code is required" ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                    </div>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtNewFaultCode" CssClass="text_align_left CalculatedColumns input_in"></asp:TextBox>
                    <div class="form_error">
                        <asp:RequiredFieldValidator ID="rfv_txtNewFaultCode" runat="server" Display="Dynamic"
                            ControlToValidate="txtNewFaultCode" ErrorMessage="Fault Code is required" ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                    </div>
                </FooterTemplate>
                <ItemStyle CssClass="text_align_left"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fault Description" ItemStyle-CssClass="da_table_tr_bg" 
                SortExpression="FaultDescription">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblFault" Text='<%# Eval("FaultDescription") %>' CssClass="da_table_tr_bg"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtFault" Text='<%# Bind("FaultDescription") %>' CssClass="input_in"></asp:TextBox>
                     <div class="form_error">
                        <asp:RequiredFieldValidator ID="rfv_txtFault" runat="server" Display="Dynamic"
                            ControlToValidate="txtFault" ErrorMessage="Fault Description is required" ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                    </div>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtNewFault" CssClass="text_align_left CalculatedColumns input_in"></asp:TextBox>
                    <div class="form_error">
                        <asp:RequiredFieldValidator ID="rfv_txtNewFault" runat="server" Display="Dynamic"
                            ControlToValidate="txtNewFault" ErrorMessage="Fault Description is required" ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                    </div>
                </FooterTemplate>
                <ItemStyle CssClass="text_align_left"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category/Subcategory" SortExpression="CategoryType" ItemStyle-CssClass="da_table_tr_bg">
                <EditItemTemplate>
                    <cc1:GroupDropDownList ID="ddlNewCategory" runat="server" CssClass="input_in">
                    </cc1:GroupDropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <%# Eval("CategoryType") %><asp:Label runat="server" ID="lblCategory"  Text='/'></asp:Label>
                    <%# Eval("SubCategoryType") %>
                </ItemTemplate>
                <FooterTemplate>
                    <cc1:GroupDropDownList ID="GroupDropDownList1" runat="server" CssClass="CalculatedColumns input_in">
                    </cc1:GroupDropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Classification" SortExpression="FaultType" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblClassification" Text='<%# (Convert.ToInt32(Eval("FaultType")) == 1 ? "Critical" : Convert.ToInt32(Eval("FaultType")) == 2 ? "Major" : "Minor") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlClassification" CssClass="input_in" SelectedValue='<%# Bind("FaultType") %>'>
                        <asp:ListItem Text="Critical" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Major" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Minor" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server" ID="ddlNewClassification" CssClass="CalculatedColumns input_in">
                        <asp:ListItem Text="Critical" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Major" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Minor" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update" CssClass="da_edit_delete_link" ValidationGroup="EditValidationControls"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" CssClass="da_edit_delete_link"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                         CssClass="da_edit_delete_link"><img src="../../images/edit2.png"/></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" OnClientClick="return confirm('Are you sure, you want to delete this fault?')"
                       runat="server" CausesValidation="False" CommandName="Delete" CssClass="da_edit_delete_link">
                       <img src="../../images/delete-icon.png" style="margin-left:15px;"/>
                       </asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="LinkInsert" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert" OnClick="LinkInsert_Click" CssClass="CalculatedColumns da_edit_delete_link" ValidationGroup="InsertValidationControls"></asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetQAFaults" TypeName="iKandi.BLL.AdminController" UpdateMethod="UpdateFaults"
        DeleteMethod="DeleteFault" InsertMethod="InsertFaults" 
        OnInserting="ObjectDataSource1_Inserting" 
         >
        <UpdateParameters>
            <asp:Parameter Name="FaultCode" Type="String" />
            <asp:Parameter Name="FaultDescription" Type="String" />
            <asp:Parameter Name="SubcategoryType" Type="Int32" />
            <asp:Parameter Name="FaultType" Type="Int32" />
            <asp:Parameter Name="original_Id" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FaultCode" Type="String" />
            <asp:Parameter Name="FaultDescription" Type="String" />
            <asp:Parameter Name="SubcategoryType" Type="Int32" />
            <asp:Parameter Name="FaultType" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
</div>