<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PrintSoldUnslodDetails.aspx.cs"
    Inherits="iKandi.Web.Internal.Design.PrintSoldUnslodDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:GridView ID="grdPrint" runat="server" AutoGenerateColumns="False" AllowPaging="false"
        CssClass="item_list fixed-header" EmptyDataRowStyle-HorizontalAlign="Center"
        OnRowDataBound="grdPrint_RowDataBound">
        <Columns>
            <asp:BoundField DataField="PrintID" HeaderText="PrintID" SortExpression="PrintID"
                Visible="false" />
            <%--<asp:BoundField DataField="DatePurchased" HeaderText="Date" SortExpression="DatePurchased"
            DataFormatString="{0:dd MMM yy (ddd)}" ItemStyle-CssClass="vertical_text" />--%>
            <asp:TemplateField HeaderText="Date" SortExpression="DatePurchased" ItemStyle-CssClass=" date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("DatePurchased")) == DateTime.MinValue) ? "" : Eval("DatePurchased", "{0:dd MMM yy (ddd)}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Print Number" SortExpression="PrintNumber">
                <ItemTemplate>
                    PRD
                    <%# Eval("PrintNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="PrintRefNo" HeaderText="Print Description" SortExpression="PrintRefNo" />
            <asp:BoundField DataField="PrintType" HeaderText="Print Type" SortExpression="PrintType" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="DesignerName" HeaderText="Designer" SortExpression="DesignerName" />
            <asp:BoundField DataField="ClientName" HeaderText="Buyer" SortExpression="ClientName" />
            <asp:BoundField DataField="PrintCompany" HeaderText="Print Company" SortExpression="PrintCompany" />--%>
            <asp:BoundField DataField="fabric" HeaderText="Fabric" SortExpression="fabric" />
            <asp:TemplateField HeaderText="Print Company Reference" Visible="false" SortExpression="PrintCompanyReference">
                <ItemTemplate>
                    <%# Eval("PrintCompanyReference")%>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Print Cost" Visible="false" SortExpression="PrintCost"
                ItemStyle-CssClass="numeric_text">
                <ItemTemplate>
                    <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%# (Convert.ToDouble(Eval("PrintCost"))).ToString("N2") %>'></asp:Label>
                    <%--<asp:Label ID="Label3" runat="server" Text='<%#   (Eval("PrintCostCurrency") == null) ? string.Empty : Convert.ToString((iKandi.Common.Currency) Convert.ToInt32(Eval("PrintCostCurrency"))) %>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("ImageUrl").ToString()) %>'
                        class="thickbox <%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? "hide_me": "" %>">
                        <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("ImageUrl").ToString()) %>'
                            visible='<%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? false: true %>' />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Developed Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("DevelopedImageUrl").ToString()) %>'
                        class="thickbox <%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? "hide_me": "" %>">
                        <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("DevelopedImageUrl").ToString()) %>'
                            visible='<%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? false: true %>' />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="Status">
                <ItemTemplate>
                    <%--<asp:Label ID="lblstatus" runat="server" Text='<%#  Eval("Status")  %>'></asp:Label>--%>
                </ItemTemplate>
                <%--<ItemStyle BackColor="#FF9933" />--%>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lbl_RecordNotFound" Text="No records found." runat="server" Font-Size="Larger"
                ForeColor="#E91677"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:GridView ID="grdprintunslod" runat="server" AllowPaging="false" AutoGenerateColumns="False"
        CssClass="item_list fixed-header" EmptyDataRowStyle-HorizontalAlign="Center"
        OnRowDataBound="grdprintunslod_RowDataBound">
        <Columns>
            <asp:BoundField DataField="PrintID" HeaderText="PrintID" SortExpression="PrintID"
                Visible="false" />
            <%--<asp:BoundField DataField="DatePurchased" HeaderText="Date" SortExpression="DatePurchased"
            DataFormatString="{0:dd MMM yy (ddd)}" ItemStyle-CssClass="vertical_text" />--%>
            <asp:TemplateField HeaderText="Date" SortExpression="DatePurchased" ItemStyle-CssClass=" date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("DatePurchased")) == DateTime.MinValue) ? "" : Eval("DatePurchased", "{0:dd MMM yy (ddd)}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Print Number" SortExpression="PrintNumber">
                <ItemTemplate>
                    PRD
                    <%# Eval("PrintNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%-- <asp:BoundField DataField="PrintRefNo" HeaderText="Print Description" SortExpression="PrintRefNo" />
            <asp:BoundField DataField="PrintType" HeaderText="Print Type" SortExpression="PrintType" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="DesignerName" HeaderText="Designer" SortExpression="DesignerName" />
            <asp:BoundField DataField="ClientName" HeaderText="Buyer" SortExpression="ClientName" />
            <asp:BoundField DataField="PrintCompany" HeaderText="Print Company" SortExpression="PrintCompany" />--%>
            <%--<asp:BoundField DataField="PrintCompanyReference" HeaderText="Print Company <br/> Reference"
            SortExpression="PrintCompanyReference" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"/>--%>
            <asp:BoundField DataField="fabric" HeaderText="Fabric" SortExpression="fabric" />
            <asp:TemplateField HeaderText="Print Company Reference" SortExpression="PrintCompanyReference">
                <ItemTemplate>
                    <%# Eval("PrintCompanyReference")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Print Cost" Visible="false" SortExpression="PrintCost"
                ItemStyle-CssClass="numeric_text">
                <ItemTemplate>
                    <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%# (Convert.ToDouble(Eval("PrintCost"))).ToString("N2") %>'></asp:Label>
                    <%--<asp:Label ID="Label3" runat="server" Text='<%#   (Eval("PrintCostCurrency") == null) ? string.Empty : Convert.ToString((iKandi.Common.Currency) Convert.ToInt32(Eval("PrintCostCurrency"))) %>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("ImageUrl").ToString()) %>'
                        class="thickbox <%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? "hide_me": "" %>">
                        <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("ImageUrl").ToString()) %>'
                            visible='<%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? false: true %>' />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Developed Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("DevelopedImageUrl").ToString()) %>'
                        class="thickbox <%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? "hide_me": "" %>">
                        <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("DevelopedImageUrl").ToString()) %>'
                            visible='<%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? false: true %>' />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="Status">
                <ItemTemplate>
                    <%-- <asp:Label ID="lblstatus" runat="server" Text='<%#  Eval("Status")  %>'></asp:Label>--%>
                </ItemTemplate>
                <%--<ItemStyle BackColor="#FF9933" />--%>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lbl_RecordNotFound" Text="No records found." runat="server" Font-Size="Larger"
                ForeColor="#E91677"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>

     
    </form>
</body>
</html>
