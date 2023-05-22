<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourierStylesPending.ascx.cs"
    Inherits="iKandi.Web.CourierStylesPending" %>
<div class="form_heading">
    STYLES PENDING
</div>
<div class="middle_portlet_content divpendingtask" id="divPendingTask" style="height: 300px;
    overflow-y: auto; overflow-x: hidden">
    <asp:GridView ID="grdPendingTasks" runat="server" AutoGenerateColumns="False" Width="100%"
        CssClass="item_list dashboard_font_style fixed-header">
        <Columns>
            <asp:TemplateField HeaderText="Client">
                <ItemTemplate>
                    <asp:Label ID="lblClient" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.Buyer %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Par.Dept(Sub.Dept)">
                <ItemTemplate>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.DepartmentName %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sampling Merchandiser">
                <ItemTemplate>
                    <asp:Label ID="lblSamplingMerchandisingManagerName" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.SamplingMerchandisingManagerName %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number" SortExpression="" ItemStyle-CssClass=" ">
                <ItemTemplate>
                    <input type="hidden" value="<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleID %>"
                        id="hdnStyleID" />
                    <asp:Label ID="lblStyleNumber" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleNumber %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ETA" HeaderText="ETA" SortExpression="ETA" HeaderStyle-Width="150px"
                ItemStyle-Width="150px" ItemStyle-CssClass="  date_style" DataFormatString="{0:dd MMM yy (ddd)}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkPendingCourier" CssClass="checkboxpending" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<br />
<asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClientClick="return AddCourierEntries()"
    CssClass="submit" />
