<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClosedResolutionTask.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.ClosedResolutionTask" %>
<asp:GridView ID="grdClosedTask" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#f0f0f0"
 CssClass="item_list1 dashboard_font_style fixed-header" CellPadding="3" CellSpacing="0">
    <Columns>
        <asp:TemplateField HeaderText="Serial No." HeaderStyle-BackColor="#f2f2f2" ItemStyle-ForeColor="Black">
            <ItemTemplate>
                <%#Eval("SerialNumber")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="style No." HeaderStyle-BackColor="#f2f2f2" ItemStyle-ForeColor="Black">
            <ItemTemplate>
                <%#Eval("StyleNumber")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Contract No." HeaderStyle-BackColor="#f2f2f2" ItemStyle-ForeColor="Black">
            <ItemTemplate>
                <%#Eval("ContractNumber")%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
