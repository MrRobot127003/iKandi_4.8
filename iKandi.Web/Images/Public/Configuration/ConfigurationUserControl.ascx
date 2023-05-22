﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationUserControl.ascx.cs" Inherits="iKandi.Web.UserControls.Configuration.ConfigurationUserControl" %>
<div class="print-box">
<asp:GridView ID="SystemConfiguration" runat="server"
    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%" CssClass="fixed-header" >
    <Columns>
        <asp:TemplateField HeaderText="Name" SortExpression="Name" > 
            <EditItemTemplate>
                <asp:TextBox ID="Label1" runat="server" Enabled="false" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value" />
        <asp:CommandField ShowEditButton="True"  />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllKeyValues" 
    TypeName="iKandi.BLL.Configuration.Configuration" UpdateMethod="Update">
    <UpdateParameters>
        <asp:Parameter Name="value" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>

<%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Phoenix.PC30 %>"
    SelectCommand="sp_Confirguration_GetAllKeyValues" UpdateCommand="sp_Confirguration_Update"
    UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
    <UpdateParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Value" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>--%>
</div>
<input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />
