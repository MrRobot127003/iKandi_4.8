<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommingUpHolidays.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.CommingUpHolidays" %>
<div class="booking_calculator" style="overflow: auto;
height: 100px;" >
    <asp:GridView runat="server" ID="gvCommingUpHolidays" DataSourceID="odsCommingUpHolidays"
        AutoGenerateColumns="False" CssClass="item_list fixed-header align_left_table_data"
        OnRowDataBound="gvCommingUpHolidays_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <span style="text-align: left" title='<%# Eval("Description") %>'>
                        <%# Eval("Title").ToString() + " " + ((Convert.ToInt32(Eval("Type")) == (int)iKandi.Common.HolidayType.Event) ? "(E)" : "(H)")%></span>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:TemplateField HeaderText="Company" SortExpression="Company">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# ((iKandi.Common.Company) Convert.ToInt32(Eval("Company"))).ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Date"   HeaderText="From Date" SortExpression="Date" ItemStyle-CssClass="date_style" DataFormatString="{0:dd MMM yy (ddd)}" />--%>
            <asp:TemplateField HeaderText="From Date" SortExpression="Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <nobr> <%# Convert.ToDateTime(Eval("Date")).ToString("dd MMM yy (ddd)") %></nobr>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="TillDate"   HeaderText="To Date" SortExpression="TillDate" ItemStyle-CssClass="date_style" DataFormatString="{0:dd MMM yy (ddd)}" />--%>
            <asp:TemplateField HeaderText="To Date" SortExpression="TillDate" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <nobr> <%# Convert.ToDateTime(Eval("TillDate")).ToString("dd MMM yy (ddd)")%></nobr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<asp:ObjectDataSource runat="server" ID="odsCommingUpHolidays" SelectMethod="GetComingHolidays"
    TypeName="iKandi.BLL.LeaveController">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="Month" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
