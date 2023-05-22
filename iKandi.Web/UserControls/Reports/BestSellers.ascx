<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestSellers.ascx.cs"
    Inherits="iKandi.Web.BestSellers" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<div class="form_box">
    <div class="form_heading">
        Bestsellers Report
    </div>
    <div>
        <table width="500px">
            <tr>
                <td>
                    DC Date
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLimit" AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="Select.." Selected="True"></asp:ListItem>
                        <asp:ListItem Value="-1" Text="One Month" Selected="False"></asp:ListItem>
                        <asp:ListItem Value="-3" Text="Three Months" Selected="False"></asp:ListItem>
                        <asp:ListItem Value="-6" Text="Six Months" Selected="False"></asp:ListItem>
                        <asp:ListItem Value="-12" Text="One Year" Selected="False"></asp:ListItem>
                        <asp:ListItem Value="-24" Text="Two Years" Selected="False"></asp:ListItem>
                        <asp:ListItem Value="-36" Text="Three Years" Selected="False"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                   Bestseller
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlBest" AppendDataBoundItems="true">
                        <asp:ListItem Value="-1" Text="Select.."></asp:ListItem>
                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" class="go" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:GridView ID="grdBestsellers" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header">
        <Columns>
            <asp:TemplateField HeaderText="Buyer">
                <ItemTemplate>
                    <%# (Eval("CompanyName") == DBNull.Value) ? "" : (Eval("CompanyName")).ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <%# (Eval("DepartmentName") == DBNull.Value) ? "" : (Eval("DepartmentName")).ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                     <a id="anchorQuantity" runat="server" href='<%# (Eval("StyleNumber") == DBNull.Value) ? "#" : "/internal/reports/AllOrdersOnStyleReport.aspx?styleNo=" + (Eval("StyleNumber")).ToString() %>'  target=_blank
                                    style="text-decoration: none; color: Blue; font-size: 14px">
                    <%# (Eval("StyleNumber") == DBNull.Value) ? "" : (Eval("StyleNumber")).ToString()%>
                    </a>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# Eval("StyleId")+",-1,-1"%>)'>
                        <img alt="img" style="height: 150px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL units" ItemStyle-CssClass="quantity_style numeric_text ">
                <ItemTemplate>
                    <%# (Eval("OrderQty") == DBNull.Value) ? "" : Convert.ToInt32( Eval("OrderQty")).ToString("N0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DC Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("DC") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("DC")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Bestseller" ItemStyle-CssClass="">
                <ItemTemplate>
                    <%# (Eval("IsBestSeller") == DBNull.Value) ? "" : (Convert.ToInt32(Eval("IsBestSeller"))==1 ? "Yes" : "No")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                NO RECORD FOUND</label></EmptyDataTemplate>
    </asp:GridView>
</div>
<div style="margin-top: 5px; text-align: right;">
    <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
    </cc1:HyperLinkPager>
</div>
