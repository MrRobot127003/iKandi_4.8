<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConverstionRateList.ascx.cs"
    Inherits="iKandi.Web.ConverstionRateList" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style>
  .item_list td:first-child
  {
      border-left-color:#999 !important;
   }
    .item_list td:last-child
  {
      border-right-color:#999 !important;
   }
    .item_list tr:last-child > td
  {
      border-bottom-color:#999 !important;
   }
</style>
<div class="print-box">
 <h2 class="header-text-back"> Currency Conversion Rate</h2>

            <asp:GridView runat="server" ID="gvClientCostingDefaults" CssClass=" item_list"
                AutoGenerateColumns="False" DataKeyNames="ID" Width="100%" 
        DataSourceID="odsCurrencyConversion" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="From" HeaderText="From" SortExpression="From" ItemStyle-CssClass="da_table_tr_bg" ControlStyle-CssClass="da_phone_field" />
                    <asp:BoundField DataField="To" HeaderText="To" SortExpression="To" ItemStyle-CssClass="da_table_tr_bg" ControlStyle-CssClass="da_phone_field" />
                    <asp:BoundField DataField="ConversionRate" HeaderText="Cost Conversion rate" SortExpression="ConversionRate" ItemStyle-CssClass="da_table_tr_bg" ControlStyle-CssClass="da_phone_field"  DataFormatString="{0:N3}" />
                    <asp:BoundField DataField="ExportConversionRate" HeaderText="Exp. Conversion Rate" ItemStyle-CssClass="da_table_tr_bg" ControlStyle-CssClass="da_phone_field" SortExpression="ExportConversionRate"  DataFormatString="{0:N3}" />
                    <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="da_edit_delete_link" />
                </Columns>
            </asp:GridView>

</div>
<asp:ObjectDataSource runat="server" ID="odsCurrencyConversion"  SelectMethod="GetAllConversionRate"
    DataObjectTypeName="iKandi.Common.CurrencyConversion" TypeName="iKandi.BLL.AdminController"
    UpdateMethod="SaveConversionRate">
    <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="Rate" Type="Single" />
         <asp:Parameter Name="ExportConversionRate" Type="Single" />
    </UpdateParameters>
</asp:ObjectDataSource>