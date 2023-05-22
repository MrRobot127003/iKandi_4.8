<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientsWeeklyStylesQuantityReport.ascx.cs"
    Inherits="iKandi.Web.ClientsWeeklyStylesQuantityReport" %>
    <div class="form_box">
    <div class="form_heading">
        Sampling Room
    </div>
    </div>
<div class="form_box">
    <asp:GridView CssClass="fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="True"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
