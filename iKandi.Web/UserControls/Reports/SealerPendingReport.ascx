<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SealerPendingReport.ascx.cs"
    Inherits="iKandi.Web.SealerPendingReport" %>
<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Pending STC Report
        </div>
        <div>
            Client:
            <asp:DropDownList runat="server" ID="ddlClients" CssClass="do-not-disable">
                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
            </asp:DropDownList>
            Search:
            <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
        </div>
    </div>
    <div class="form_box">
        <asp:GridView ID="grdSealerPending" runat="server" CssClass="item_list fixed-header"
            AutoGenerateColumns="false" RowStyle-CssClass="grid_row" AlternatingRowStyle-CssClass="grid_row">
            <Columns>
                <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuyer" Text='<%# Eval("Buyer") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Serial No." DataField="SerialNumber" />
                <asp:BoundField HeaderText="Dept." DataField="DepartmentName" />
                <asp:BoundField HeaderText="Style No." DataField="StyleNumber" />
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line/Item No" SortExpression="LineItemNumber" />
                <asp:BoundField DataField="ContractNumber" HeaderText="Order / Contract No" SortExpression="ContractNumber" />
                <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") == DBNull.Value ? "" : Eval("Description").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="QTY" SortExpression="Quantity" ItemStyle-CssClass="numeric_text" />
                <asp:BoundField DataField="Fabric1Details" HeaderText="Color / Print" SortExpression="Fabric1Details"
                    HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
                
                <asp:TemplateField HeaderText="Mode">
                    <ItemTemplate>                      
                      <span title='<%# (Eval("Mode") == DBNull.Value || Eval("Mode").ToString() == "") ? "" : iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'>
                        <%# (Eval("Mode") == DBNull.Value || Eval("Mode").ToString() == string.Empty ) ? "" : iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(Eval("Mode")))%></span>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                        <%# (Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : Eval("ExFactory", "{0:dd MMM yy (ddd)}")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sealer ETA" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                        <%# (Eval("SealETA") == DBNull.Value || Convert.ToDateTime(Eval("SealETA")) == DateTime.MinValue) ? "" : Eval("SealETA", "{0:dd MMM yy (ddd)}")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sealer Remarks BIPL" SortExpression="SealerRemarksBIPL"
                    ItemStyle-CssClass="remarks_text">
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("RemarksBIPL") == DBNull.Value ? "" : Eval("RemarksBIPL").ToString().Replace("$$", "<br />") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SealerRemarks iKandi" SortExpression="SealerRemarksiKandi"
                    ItemStyle-CssClass="remarks_text">
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("RemarksIKANDI") == DBNull.Value ? "" : Eval("RemarksIKANDI").ToString().Replace("$$", "<br />") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
<%--  <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />

--%>