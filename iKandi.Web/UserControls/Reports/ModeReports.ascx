<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModeReports.ascx.cs"
    Inherits="iKandi.Web.ModeReports" %>
    
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
    
    </script>
    
<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Mode Reports
        </div>
        <div>
            WorkFlow Mode
            <asp:DropDownList ID="ddlWorkFlowMode" runat="server" CssClass="do-not-disable">
                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
        </div>
    </div>
    <asp:GridView runat="server" ID="grdModeReports" AutoGenerateColumns="false" CssClass="item_list fixed-header"
        OnRowDataBound="grdModeReports_RowDataBound">
        <Columns>
            <%--<asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd MMM yy (ddd)}"/>--%>
            <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <div style="width: 100px">
                        <%# (Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial No.">
                <ItemTemplate>
                    <asp:Label ID="lblIkandiSerial" runat="server" Text='<% # Eval("SerialNumber") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepartmentName" HeaderText="Dept." />
            <asp:BoundField DataField="StyleNumber" HeaderText="Style No." HeaderStyle-Width="65px"
                ItemStyle-Width="65px" />
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="numeric_text" />
            <asp:TemplateField HeaderText="Fabric/Detail">
                <ItemTemplate>
                    <asp:Label ID="lblFabric" runat="server"><%# Eval("Fabric1") %></asp:Label>
                    <asp:Label ID="lblFabricDetail" runat="server"><%# Int32.TryParse(Eval("Fabric1Details").ToString(), out result) ? ":PRD" + Eval("Fabric1Details") : (string.IsNullOrEmpty(Eval("Fabric1Details").ToString()) ? "" :":"+ Eval("Fabric1Details"))%></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Mode" HeaderText="Mode"  />--%>
            <asp:TemplateField HeaderText="Mode">
                <ItemTemplate>
                   <%-- <%# iKandi.Common.Constants.GetOrderDeliveryMode(Convert.ToInt32(Eval("Mode"))) %>--%>
                   <span title='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'>
                    <%# iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(Eval("Mode")))%></span>
                    </ItemTemplate>
            </asp:TemplateField>
            <%-- <asp:BoundField DataField="ExFactory" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="STC Target"
            SortExpression="ExFactory" />--%>
            <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <div style="width: 100px">
                        <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="Fit"
            SortExpression="ExFactory" />--%>
            <%-- <asp:BoundField DataField="ExFactory" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="Top Sent Target"
            SortExpression="ExFactory" />--%>
            <asp:TemplateField HeaderText="Top Sent Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <div style="width: 100px">
                        <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:HyperLink ID="hlkLiability" NavigateUrl='<%# "javascript:showWorkflowHistory2("+ Eval("StyleID").ToString() + "," + Eval("OrderID").ToString() + "," + Eval("OrderDetailID").ToString() + ");" %>' runat="server"> <%# Eval("StatusMode") %> </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <div style="width: 100px">
                        <%# (Eval("ActionDate") == DBNull.Value) ? "" : ((Convert.ToDateTime(Eval("ActionDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ActionDate"))).ToString("dd MMM yy (ddd)"))%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                NO RECORD FOUND</label></EmptyDataTemplate>
    </asp:GridView>
</div>
<br />
<div>
    <%--<input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />--%>
</div>
