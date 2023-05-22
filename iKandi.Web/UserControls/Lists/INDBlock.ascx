<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="INDBlock.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.INDBlock" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">
    $(function () {
        BindControls();
    });
 
 
 
 </script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
 <style type="text/css">
 

.form_box {
    background: #fff none repeat scroll 0 0;
 
}
 </style>
<div class="print-box" style="min-width:100%;">

    <h2 class="header-text-back">IND Blocks </h2>
    <div class="form_box">
    <div style="margin-top:2px;">
    <fieldset class="da_fieldset_filters">
<legend><b>Filters</b></legend>
 <table width="35%" border="0" cellspacing="0" cellpadding="2">
  <tr>
    <td> Client:</td>
    <td><asp:DropDownList runat="server" ID="ddlClients" CssClass="do-not-disable">
    <asp:ListItem Value="-1" Text="ALL"></asp:ListItem>
    </asp:DropDownList></td>
    <td>Search:</td>
    <td><asp:TextBox runat="server" ID="txtSearch" CssClass="do-not-disable"></asp:TextBox></td>
    <td><asp:Button ID="btnSearch" runat="server"  onclick="btnSearch_Click" Text="Search" CssClass="do-not-disable da_go_button go"   /></td>
  </tr>
</table>
</fieldset>
</div>
<%--<div class="grid_heading">
    Prints</div>--%>

<asp:GridView ID="grdPrint" runat="server" AutoGenerateColumns="False"
    CssClass="da_header_heading fixed-header" EmptyDataRowStyle-HorizontalAlign="Center" Width="100%" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:BoundField DataField="BlockID" HeaderText="BlockID" SortExpression="BlockID" 
            Visible="false" />
        <%--<asp:BoundField DataField="DatePurchased" HeaderText="Date" SortExpression="DatePurchased"
            DataFormatString="{0:dd MMM yy (ddd)}" ItemStyle-CssClass="vertical_text" />--%>
            <asp:TemplateField HeaderText="Date" SortExpression="DatePurchased"  ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("DatePurchased")) == DateTime.MinValue) ? "" : Eval("DatePurchased", "{0:dd MMM yy (ddd)}")%>
                </ItemTemplate>
            </asp:TemplateField>
            
      <asp:TemplateField HeaderText="Block Number" SortExpression="BlockNumber" ItemStyle-CssClass="da_table_tr_bg" >
                <ItemTemplate>
                     <%# Eval("BlockNumber")%>
                </ItemTemplate>
            </asp:TemplateField> 
            
        
        <asp:BoundField DataField="Description" HeaderText="Block Description" SortExpression="Description" ItemStyle-CssClass="da_table_tr_bg" />
        <asp:BoundField DataField="DesignerName" HeaderText="Designer" SortExpression="DesignerName" ItemStyle-CssClass="da_table_tr_bg"  />
        <asp:BoundField DataField="ClientName" HeaderText="Buyer" SortExpression="ClientName" ItemStyle-CssClass="da_table_tr_bg"  />
        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" ItemStyle-CssClass="da_table_tr_bg" />
        <%--<asp:BoundField DataField="PrintCompanyReference" HeaderText="Print Company <br/> Reference"
            SortExpression="PrintCompanyReference" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"/>--%>
       <asp:TemplateField HeaderText="Reference" SortExpression="Reference" ItemStyle-CssClass="da_table_tr_bg" >
                <ItemTemplate>
                    <%# Eval("Reference")%>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Block Cost" SortExpression="BlockCost" ItemStyle-CssClass="da_table_tr_bg">
            <ItemTemplate>
            <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text='<%# (Convert.ToDouble(Eval("BlockCost"))).ToString("N2") %>'></asp:Label>
                <%--<asp:Label ID="Label3" runat="server" Text='<%#   (Eval("PrintCostCurrency") == null) ? string.Empty : Convert.ToString((iKandi.Common.Currency) Convert.ToInt32(Eval("PrintCostCurrency"))) %>'></asp:Label>--%>
                
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign=Center>
            <ItemTemplate>
            <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/indblock/" + Eval("ImageUrl").ToString()) %>' class="thickbox <%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? "hide_me": "" %>"> 
                <img height="75px" border=0 src='<%# ResolveUrl("~/uploads/indblock/thumb-" + Eval("ImageUrl").ToString()) %>'
                    visible='<%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? false: true %>' />
                    </a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="BlockID" DataNavigateUrlFormatString="~/internal/design/INDBlock.aspx?blockid={0}"
            Text="Edit" ItemStyle-CssClass="da_edit_delete_link"  />
         </Columns>
    <EmptyDataTemplate>
       <asp:Label ID="lbl_RecordNotFound" Text="Please Select Client To View The Results" runat="server" Font-Size="Larger" ForeColor="#E91677"  ></asp:Label>
       </EmptyDataTemplate>
</asp:GridView>
</div>
  <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    
</div>
<br />
<div>
<%--<a href="~/internal/Design/PrintEdit.aspx" runat="server">Add Print</a>--%>
<asp:Button ID="Button1" runat="server" CssClass="add da_submit_button" Text="Add" PostBackUrl="~/internal/Design/INDBlock.aspx"></asp:Button>
 <%--<input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
</div>

 