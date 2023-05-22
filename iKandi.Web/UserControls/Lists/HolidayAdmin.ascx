<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayAdmin.ascx.cs"
    Inherits="iKandi.Web.HolidayAdmin" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<%--<link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>
 <script type="text/javascript">

     $(function () {
         $(".th").datepicker({ dateFormat: 'dd M y (D)' });
     });
  
  </script> 
  <link href="../../css/report.css" rel="stylesheet" type="text/css" />
  <style>
     .header-text-back
     {
         padding:0px 5px;
         font-size: 16px;
         clear:both;
      }
      .AddClass_Table td {
    padding: 4px 3px;
    color: #0c0c0c;
    text-align:center;
}
.txtLeft
{
    text-align:left !important;
 }
.AddClass_Table td[colspan="7"] > table td
{
    border:0px;
 }
 .AddClass_Table td input[type="text"] {
    width: 97%;
 }
  </style>
<div class="print-box">
<h2 class="header-text-back"> Holidays</h2>
    
        <asp:ObjectDataSource ID="odsHolidays" runat="server" DataObjectTypeName="iKandi.Common.Holiday"
            TypeName="iKandi.BLL.LeaveController" SelectMethod="GetAllHolidays" UpdateMethod="UpdateHoliday"
            DeleteMethod="DeleteHoliday" InsertMethod="InsertHoliday"></asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="odsHolidays" CssClass="da_header_heading AddClass_Table"
            AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="Id"
            OnRowCommand="GridView1_RowCommand" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# Eval("Title") %>
                    </ItemTemplate>
                    <ItemStyle CssClass="txtLeft" />
                    <EditItemTemplate>
                        <asp:TextBox ID="tbUpdateTitle" CssClass="input_in" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_tbUpdateTitle" runat="server" Display="Dynamic"
                            ControlToValidate="tbUpdateTitle" ErrorMessage="Holiday Name is required"  ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tbInsertTitle" runat="server"  CssClass="input_in"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_tbInsertTitle" runat="server" Display="Dynamic"
                            ControlToValidate="tbInsertTitle" ErrorMessage="Holiday Name is required" CssClass="da_error_msg" ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# Eval("Description") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbUpdateDescription" CssClass="input_in" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tbInsertDescription" CssClass="input_in" runat="server"></asp:TextBox>
                    </FooterTemplate>
                      <ItemStyle CssClass="txtLeft" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# Eval("DateString") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbUpdateDate" runat="server" CssClass="th input_in" Text='<%# Bind("DateString") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_tbUpdateDate" runat="server" Display="Dynamic"
                            ControlToValidate="tbUpdateDate" ErrorMessage="Holiday Date is required" ValidationGroup="EditValidationControls"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tbInsertDate" CssClass="th input_in" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_tbInsertDate" runat="server" Display="Dynamic"
                            ControlToValidate="tbInsertDate" ErrorMessage="Holiday Date is required" CssClass="da_error_msg" ValidationGroup="InsertValidationControls"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Till Date" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# Eval("TillDateString") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbTillUpdateDate" runat="server" CssClass="th input_in" Text='<%# Bind("TillDateString") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tbInsertTillDate" CssClass="th input_in" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Type" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# (iKandi.Common.Company) Convert.ToInt32( Eval("Company")) %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList CssClass="input_in" ID="ddlUpdateCompany" runat="server" SelectedValue='<%# Bind("Company") %>'>
                            <asp:ListItem Text="iKandi" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Boutique" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlInsertCompany" runat="server" CssClass="input_in" SelectedValue='<%# Bind("Company") %>'>
                            <asp:ListItem Text="iKandi" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Boutique" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Holiday Type" ItemStyle-CssClass="da_table_tr_bg">
                    <ItemTemplate>
                        <%# (iKandi.Common.HolidayType) Convert.ToInt32( Eval("Type")) %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList CssClass="input_in" ID="ddlUpdateType" runat="server" SelectedValue='<%# Bind("HolidayTypeID") %>'>
                            <asp:ListItem Text="National" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Event" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlInsertType" runat="server" CssClass="input_in" SelectedValue='<%# Bind("HolidayTypeID") %>'>
                            <asp:ListItem Text="National" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Event" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" CssClass="da_edit_delete_link">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure, you want to delete this Holiday?')" CommandName="Delete"
                            Text="Delete" CssClass="da_edit_delete_link">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lbUpdate" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" ValidationGroup="EditValidationControls" CssClass="da_edit_delete_link"></asp:LinkButton>
                        <asp:LinkButton ID="lbCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" CssClass="da_edit_delete_link"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="lbInsert" runat="server" CssClass="da_edit_delete_link" CommandName="Insert" OnClick="lbInsert_Click"
                            ValidationGroup="InsertValidationControls" CausesValidation="true">Insert
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="da_edit_delete_link" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" OnClick="LinkButton2_Click"></asp:LinkButton>
                    </FooterTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
             
        </asp:GridView>
 
</div>
