<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pendingimages.ascx.cs"
    Inherits="iKandi.Web.Pendingimages" %>
<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Pending images Report
        </div>
        <div>
            <table width="500px">
                <tr>
                    <td>
                        Client:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClients" AppendDataBoundItems="true" CssClass="do-not-disable">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Search:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSearchText" CssClass="do-not-disable"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" Text="Search" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_box">
        <asp:GridView ID="grdPendingImages" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header">
            <Columns>
                <asp:TemplateField HeaderText="Style Number">
                    <ItemTemplate>
                        <span><a title="CLICK TO VIEW UPLODE IMAGE FORM" href="../Design/UploadDesign.aspx?styleid=<%# Eval("Id")%>">
                            <%# Eval("StyleNumber")%></a> </span>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Buyer">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Buyer")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Department">
     <ItemTemplate>
         <asp:Label ID="Label3" runat="server" Text='<%# Eval("Department")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>--%>
                <%--    <asp:TemplateField HeaderText="Designer">
     <ItemTemplate>
         <asp:Label ID="Label4" runat="server" Text='<%# Eval("DesignerFirstName")%>'></asp:Label>
         <asp:Label ID="Label5" runat="server" Text='<%# Eval("DesignerLastName")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>
     
     <asp:TemplateField HeaderText="ETA">
     <ItemTemplate>
         <asp:Label ID="Label6" runat="server" Text='<%# Eval("ETA")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Targetprice">
     <ItemTemplate>
         <asp:Label ID="Label7" runat="server" Text='<%# Eval("Targetprice")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>
     
      <asp:TemplateField HeaderText="MerchandiserDispatchDate">
     <ItemTemplate>
         <asp:Label ID="Label8" runat="server" Text='<%# Eval("MerchandiserDispatchDate")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>
     
        <asp:TemplateField HeaderText="FactoryName">
     <ItemTemplate>
         <asp:Label ID="Label8" runat="server" Text='<%# Eval("FactoryName")%>'></asp:Label>
     </ItemTemplate>
      </asp:TemplateField>--%>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No Record Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>
<%-- <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
