<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExFactoryQuantity.ascx.cs" Inherits="iKandi.Web.ExFactoryQuantity" %>
<div class="form_box">
    <div class="form_heading">
        ExFactory Quantity REPORT
    </div>
</div> 
<div class="form_box">
    <asp:GridView ID="grdExFactoryQty" runat="server" CssClass="item_list fixed-header"
        AutoGenerateColumns="true" OnRowDataBound="grdExFactoryQty_RowDataBound" 
        OnRowCreated="grdExFactoryQty_RowCreated" OnDataBound="grdExFactoryQty_DataBound" AlternatingRowStyle-BackColor="Gray">
        <Columns>
           <%-- <asp:TemplateField HeaderText="Week ending" ItemStyle-CssClass="date_style quantity_style">
                <ItemTemplate>
                    <%# Convert.ToDateTime((System.Text.ASCIIEncoding.ASCII.GetString((byte[])Eval("WeekDate")))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
                <FooterTemplate>
                    Total
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buyer">
                <ItemTemplate>
                    <span>
                        <%# Eval("CompanyName")%>
                    </span>
                </ItemTemplate>
               
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="quantity_style numeric_text ">
                <ItemTemplate>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No. of orders" ItemStyle-CssClass="quantity_style numeric_text ">
                <ItemTemplate>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="% Fillup" ItemStyle-CssClass="quantity_style numeric_text ">
                <ItemTemplate>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>--%>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found
            </label>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
