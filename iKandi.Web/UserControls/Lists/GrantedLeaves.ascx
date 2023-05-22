<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GrantedLeaves.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.GrantedLeaves" %>
<div class="booking_calculator">
    <asp:GridView runat="server" ID="gvGrantedLeaves" DataSourceID="odsGrantedLeaves"
        AutoGenerateColumns="False" CssClass="fixed-header" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Employee" SortExpression="Employee" ItemStyle-CssClass="text_align_left">
                <ItemTemplate>
                    <nobr>
                    <asp:Label ID="Label1" runat="server" Text='<%# (Eval("Employee") as iKandi.Common.User).FullName %>' Font-Size=9px></asp:Label>
                    </nobr>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="From" SortExpression="FromDate" ItemStyle-CssClass="date_style text_align_left">
                <ItemTemplate>
                    <nobr>
                    <asp:Label ID="Label2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FromDate")) == DateTime.MinValue )  ? "" : Convert.ToDateTime(Eval("FromDate")).ToString("dd MMM yy (ddd)") %>' Font-Size=10px></asp:Label>
                    </nobr>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To" SortExpression="ToDate" ItemStyle-CssClass="date_style text_align_left">
                <ItemTemplate>
                    <nobr>
                    <asp:Label ID="Label3" runat="server" Text='<%# (Convert.ToDateTime(Eval("ToDate")) == DateTime.MinValue )  ? "" : Convert.ToDateTime(Eval("ToDate")).ToString("dd MMM yy (ddd)") %>' Font-Size=10px></asp:Label>
                    </nobr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<asp:ObjectDataSource runat="server" ID="odsGrantedLeaves" SelectMethod="GetAllGrantedLeaves"
    TypeName="iKandi.BLL.LeaveController" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="Month" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
