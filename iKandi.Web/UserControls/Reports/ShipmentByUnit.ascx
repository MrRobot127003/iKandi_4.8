<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShipmentByUnit.ascx.cs"
    Inherits="iKandi.Web.ShipmentByUnit" %>
<div class="form_box">
    <div class="form_heading">
        Shipments By Unit
    </div>
</div>
<div class="form_box">
    <asp:GridView CssClass=" fixed-header item_list" ID="gvShipmentByUnit" runat="server"
        AutoGenerateColumns="True" OnRowCreated="GridView1_OnRowCreated" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
