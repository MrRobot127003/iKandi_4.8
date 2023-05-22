<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Clients.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.Clients" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<style type="text/css">
    .topalign
    {
        vertical-align: top;
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
    .item_list td .innerTable
    {
        width:100%;
     }
    .item_list td .innerTable td
    {
           border: 0px;
         border-bottom: 1px solid #dedede;
         word-break: break-all;
     }
    .item_list td .innerTable td:first-child
    { 
         border-right: 1px solid #dedede;
     }
   
     .item_list td .innerTable tr:last-child > td
    { 
         border-bottom: 0px;
     }
     td.TdPadding
     {
         padding:0px 0px !important;
      }
      
     .da_submit_button {
    font-size: 12px;
    padding: 4px 9px;
    margin-bottom: 40px;
    height: auto;
    line-height: inherit;
    float: left;
      }
      .da_header_heading tr th
      {
          position:sticky;
          top:-1px;
          }
      .addscroll 
      {
         max-height: 205px;
         overflow-y: auto; 
          }
  .clearfix
  {
      clear: both;
      }
</style>


<div class="print-box">
    <fieldset style="margin-bottom: 5px; font: normal 12px/14px Arial, Helvetica, sans-serif;
        color: #3c3c3c; text-transform: capitalize;">
        <legend><b>Filters</b></legend>
        <table width="60%" border="0" cellspacing="2" cellpadding="2">
            <tr>
                <td>
                    Buying House:
                </td>
                <td class="da_search_heading">
                    <asp:DropDownList ID="ddlBuyingHouse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBuyingHouse_SelectedIndexChanged"
                        Width="170px" CssClass="input_in">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;&nbsp;Client:
                </td>
                <td>
                    <asp:DropDownList ID="ddlClient" runat="server" Width="160px" CssClass="input_in">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Search" CssClass="da_go_button go"
                        OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <h2 style="background: #39589c; margin: 0px; padding: 5px 10px; font-weight: bold;
        color: #fff; text-transform: capitalize; border-radius: 5px 5px 0px 0px;">
        <span class="da_h1">Clients</span>
    </h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="item_list  da_header_heading"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <%-- <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-VerticalAlign="Top"
                ItemStyle-Width="10%" SortExpression="CompanyName" ItemStyle-CssClass="da_table_tr_bg">
                <ItemStyle VerticalAlign="Top" CssClass="da_table_tr_bg" Width="10%"></ItemStyle>
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="Company Name" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%"
                SortExpression="CompanyName" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <asp:Label ID="lblCompany" Text='<%# Eval("CompanyName") %>' runat="server"></asp:Label><br />
                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="da_table_tr_bg" Width="10%"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website"
                ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="da_table_tr_bg">
                <ItemStyle VerticalAlign="Top" CssClass="da_table_tr_bg"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Parent (Department) /Assignments" SortExpression="Assignments"
                ItemStyle-VerticalAlign="Top" ItemStyle-Width="30%" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnClientID" runat="server" Value='<%# Eval("ClientID") %>' />
                    <div class="addscroll">
                    <asp:GridView ID="grdAssisment" BorderWidth="0" runat="server" BorderStyle="None" AutoGenerateColumns="false"
                        CssClass="innerTable" ShowHeader="false" OnRowDataBound="grdAssisment_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Department Name" HeaderStyle-Width="80px" ItemStyle-Width="80px"
                                ItemStyle-CssClass="da_table_tr_bg topalign">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDeptID" Value='<%# Bind("ID") %>' runat="server" />
                                    <asp:Label ID="lblDepartmentName" runat="server" Width="80px" Text='<%# Eval("DepartmentName") %>'
                                        ToolTip='<%# Eval("DepartmentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div align="left">
                                        <asp:Repeater ID="rptUSERLIST" runat="server">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserList" runat="server" Text='<%# Eval("UserList")%>'> </asp:Label>
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>

                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="da_table_tr_bg TdPadding" Width="30%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Info" SortExpression="Client Info" ItemStyle-Width="20%"
                ItemStyle-CssClass="da_table_tr_bg" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div align="left">
                        Address:
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
                        Phone:
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
                    </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="da_table_tr_bg" Width="20%"></ItemStyle>
            </asp:TemplateField>
            <%-- <asp:BoundField DataField="Address" HeaderText="Address" 
            SortExpression="Address" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
        <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />--%>
            <%--<asp:BoundField DataField="ClientSince" HeaderText="Client Since" 
           DataFormatString="{0:dd MMM yy (ddd)}" SortExpression="ClientSince" />--%>
            <asp:TemplateField HeaderText="Client Since" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%"
                SortExpression="ClientSince" ItemStyle-CssClass="date_style da_table_tr_bg">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("ClientSince")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ClientSince"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="date_style da_table_tr_bg" Width="10%">
                </ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buying House" ItemStyle-VerticalAlign="Top" SortExpression="BuyingHouseName"
                ItemStyle-CssClass="date_style da_table_tr_bg">
                <ItemTemplate>
                    <asp:Label ID="lblBH" runat="server" Text='<%# Eval("BuyingHouseName") %>'></asp:Label><br />
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="date_style da_table_tr_bg"></ItemStyle>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="ClientID" ItemStyle-CssClass="da_edit_delete_link"
                DataNavigateUrlFormatString="~/internal/client/clientedit.aspx?clientid={0}"
                Text="Edit" ItemStyle-VerticalAlign="Top">
                <ItemStyle VerticalAlign="Top" CssClass="da_edit_delete_link topalign"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>
                        NO RECORD FOUND
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    <div style="margin-top: 5px; text-align: right;  color: #3e539c;">

       <asp:Button ID="btnAdd" runat="server" CssClass="da_submit_button" Text="ADD" Visible="false"
            PostBackUrl="~/internal/Client/ClientEdit.aspx"></asp:Button>
        <input type="button" id="btnPrint" class="da_submit_button" value="Print" onclick="return PrintPDF();" />

        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    <div claa="clearfix"></div>
    <%--<asp:ObjectDataSource ID="odsClients" runat="server" SelectMethod="GetAllClients"
        TypeName="iKandi.BLL.ClientController"></asp:ObjectDataSource>--%>
</div>
