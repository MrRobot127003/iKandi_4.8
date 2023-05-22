<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserHolidayEntitlement.ascx.cs"
    Inherits="iKandi.Web.UserHolidayEntitlement" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="print-box">
<h2  class="header-text-back">

User Entitled Holidays</h2>
        
     
            <asp:GridView runat="server" ID="gvUserHolidays" CssClass="da_header_heading item_list"
                AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name" ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width=25%>
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" runat="server" Text='<%# (Eval("User") as iKandi.Common.User).FullName %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company" SortExpression="Company" ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width=25%>
                        <ItemTemplate>
                            <asp:Label ID="lblCompany" runat="server" Text='<%# (Eval("User") as iKandi.Common.User).Company.ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Holidays" SortExpression="Holidays" HeaderStyle-Width=25%>
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hdnUHEID" Value='<%# Bind("ID") %>' />
                            <asp:HiddenField runat="server" ID="hdnUserID" Value='<%# (Eval("User") as iKandi.Common.User).UserID %>' />
                            <asp:TextBox ID="txtHolidays" CssClass="numeric-field-without-decimal-places input_in" runat="server"
                                Text='<%# Convert.ToInt32( Eval("Holidays")) ==0 ? "" :Eval("Holidays")  %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HolidayUsed" SortExpression="HolidayUsed" HeaderStyle-Width=25% ItemStyle-CssClass="input_in" >
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToInt32( Eval("HolidayUsed")) ==0 ? "" : Eval("HolidayUsed") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
     
        <br />
    <asp:Button ID="btnSubmit" runat="server" CssClass="da_submit_button" Text="Submit" OnClick="btnSubmit_Click" />
</div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="iKandi.Common.UserHolidayEntitlement"
    SelectMethod="GetUserEntitledHolidays" TypeName="iKandi.BLL.AdminController">
</asp:ObjectDataSource>
