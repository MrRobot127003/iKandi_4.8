<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FitDaysForAllClientsReport.ascx.cs"
    Inherits="iKandi.Web.FitDaysForAllClientsReport" %>
<%--<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>--%>
<div class="print-box">
    <div class="form_heading">
        Fit Days
    </div>
    <asp:GridView CssClass="item_list1 fit_days_report" ID="gvFitDays" 
        runat="server" AutoGenerateColumns="False" Width="350px"
        OnPreRender="gvFitDays_PreRender" onrowdatabound="gvFitDays_RowDataBound">
        <RowStyle HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="CompanyName" HeaderText="Client" SortExpression="CompanyName">
                <ItemStyle CssClass="fit_days_report_client_name" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Departments" SortExpression="DepartmentName">
                <ItemStyle CssClass="fit_days_report_dept_name" />
                <ItemTemplate>
                    <%# Eval("DepartmentName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mon" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:Label Width="25px" ID="lblMon" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tue" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:Label Width="25px" ID="lblTue" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Wed" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:Label Width="25px" ID="lblWed" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thu" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:Label ID="lblThu" Width="25px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fri" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:Label ID="lblFri" Width="25px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No Record Found
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <div>
        <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />
    </div>
    <%--<div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        &nbsp;
        </cc1:HyperLinkPager>
    </div>--%>
</div>
