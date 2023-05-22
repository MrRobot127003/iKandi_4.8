<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuyingHouseList.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.BuyingHouseList" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .item_list td
    {
        padding: 5px !important;
    }
    .item_list td:first-child
    {
        border-left-color: #999 !important;
    }
    .item_list td:last-child
    {
        border-right-color: #999 !important;
    }
    .item_list tr:last-child > td
    {
        border-bottom-color: #999 !important;
    }
    .header-text-back
    {
        font-size:15px;
        font-weight:500;
    }
       .da_edit_delete_link_forimage a
    {
        color:transparent;
    }
    .da_edit_delete_link_forimage a:hover
    {
        text-decoration:none;
        color:transparent;
    }
   .da_edit_delete_link_forimage
    {
         background-image: url("../../images/delete-icon.png");
         background-repeat:no-repeat;
         background-position: center;
        }
</style>
<div class="print-box">
    <h2 class="header-text-back">
        Buying House List</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="item_list  da_header_heading"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CompanyName" HeaderText="Name" SortExpression="CompanyName"
                ItemStyle-CssClass="da_table_tr_bg" />
            <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website"
                ItemStyle-CssClass="da_table_tr_bg" />
            <asp:TemplateField HeaderText="Contact Info" SortExpression="Client Info" ItemStyle-Width="30%"
                ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <div align="left">
                        Address:
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
                        Phone:
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buying House Since" SortExpression="ClientSince" ItemStyle-CssClass="date_style da_table_tr_bg">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("ClientSince")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ClientSince"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IsActive" SortExpression="IsActive">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckIsActive" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsActive")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="BuyingHouseID" DataNavigateUrlFormatString="~/internal/buyinghouse/buyinghouseedit.aspx?bhid={0}"
                Text="Edit" ItemStyle-CssClass="da_edit_delete_link da_edit_delete_link_forimage" />
        </Columns>
    </asp:GridView>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    <br />
    <div>
        <asp:Button ID="btnAdd" runat="server" CssClass="da_submit_button" Text="Add" PostBackUrl="~/internal/buyinghouse/buyinghouseedit.aspx">
        </asp:Button>
        <input type="button" id="btnPrint" runat="server" class="da_submit_button" value="Print"
            onclick="return PrintPDFQueryString('','','','&btn=1');" />
    </div>
</div>
