<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SealingPerformance.ascx.cs"
    Inherits="iKandi.Web.SealingPerformance" %>
<div class="form_box">
    <div class="form_heading">
        Sealing Performance Report
    </div>
    <div>
        <table>
            <tr>
                <td>
                    Order Date
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrderDt" runat="server">
                        <asp:ListItem Text="Last 1 Month" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Last 3 Months" Value="-3"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="Last 6 Months" Value="-6"></asp:ListItem>
                        <asp:ListItem Text="Last 1 Year" Value="-12"></asp:ListItem>
                        <asp:ListItem Text="Last 2 Years" Value="-24"></asp:ListItem>
                        <asp:ListItem Text="Last 3 Years" Value="-35"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:GridView ID="grdSealing" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header" OnRowDataBound="grdSealing_OnRowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Buyer">
                <ItemTemplate>
                    <%# Eval("CompanyName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <%# Eval("DepartmentName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="-3 Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# ( Eval("-3").ToString() == "0" ) ? "" :   Eval("-3").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="-2 Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%#  ( Eval("-2").ToString() == "0" ) ? "" :   Eval("-2").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="-1 Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%#  ( Eval("-1").ToString() == "0" ) ? "" :   Eval("-1").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="0 Week">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%#  ( Eval("0").ToString() == "0" ) ? "" :   Eval("0").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="1 Week">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# ( Eval("1").ToString() == "0" ) ? "" :   Eval("1").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="2 Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%#  ( Eval("2").ToString() == "0" ) ? "" :   Eval("2").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="3 Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%#  ( Eval("3").ToString() == "0" ) ? "" :   Eval("3").ToString()+"%" %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Avg. Weeks">
                <ItemTemplate>
                    <asp:Label ID="Label111" runat="server" Text='<%#  ( Eval("AvgWeeks").ToString() == "0.00" ) ? "" :   Eval("AvgWeeks").ToString() %>'></asp:Label>
                    </ItemTemplate>   
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                NO RECORD FOUND</label></EmptyDataTemplate>
    </asp:GridView>
</div>
