<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientDepartmentorderReport.ascx.cs"
    Inherits="iKandi.Web.ClientDepartmentorderReport" %>
<div class="print-box">
    <div class="form_heading">
        Client Department Orders
    </div>
    <asp:GridView CssClass="item_list" ID="grdClientOrderDept" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Eval("OrderDate") == DBNull.Value || Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSerialNumber" Text='<% #(Eval("SerialNumber") == DBNull.Value) ? "" : Eval("SerialNumber").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDept" Text='<% # Eval("DepartmentName") == DBNull.Value ? "" : Eval("DepartmentName").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblStyleNumber" Text='<% # (Eval("StyleNumber") == DBNull.Value) ? "" : Eval("StyleNumber").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"
                ItemStyle-CssClass="numeric_text" />
            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1">
                <ItemTemplate>
                    <%# Eval("Fabric1") == DBNull.Value ? string.Empty : Eval("Fabric1").ToString()%>
                    :
                    <label>
                        <%# Eval("Fabric1Details") == DBNull.Value ? string.Empty : Eval("Fabric1Details").ToString() %></label><br />
                    <%# Eval("Fabric2") == DBNull.Value ? string.Empty : Eval("Fabric2").ToString() %>
                    :
                    <label>
                        <%# Eval("Fabric2Details") == DBNull.Value ? string.Empty : Eval("Fabric2Details").ToString() %></label><br />
                    <%# Eval("Fabric3") == DBNull.Value ? string.Empty : Eval("Fabric3").ToString() %>
                    :
                    <label>
                        <%# Eval("Fabric3Details") == DBNull.Value ? string.Empty : Eval("Fabric3Details")%></label><br />
                    <%# Eval("Fabric4") == DBNull.Value ? string.Empty : Eval("Fabric4")%>:
                    <label>
                        <%# Eval("Fabric4Details") == DBNull.Value ? string.Empty : Eval("Fabric4Details") %></label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="STC Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="Fit"
                SortExpression="ExFactory" ItemStyle-CssClass="date_style" />
            <asp:TemplateField HeaderText="Top Sen Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode">
                <ItemTemplate>
                    <span title='<%# (Eval("Mode") == DBNull.Value || Eval("Mode").ToString() == "") ? "" : iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'>
                        <%# (Eval("Mode") == DBNull.Value || Eval("Mode").ToString() == "") ? "" : iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(Eval("Mode")))%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Eval("ExFactory") ==  DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DC Date" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Eval("DC") == DBNull.Value || Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ikandiPrice" HeaderText="Price" SortExpression="ikandiPrice"
                ItemStyle-CssClass="numeric_text" />
            <asp:TemplateField HeaderText="Sanjeev's Remarks" SortExpression="SealerRemarks"
                ItemStyle-CssClass="remarks_text">
                <ItemTemplate>
                    <label id="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>" name="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>">
                        <%# Eval("SanjeevRemarks") == DBNull.Value ? string.Empty : Eval("SanjeevRemarks").ToString().Replace("$$", "<br/>")%></label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Merchant Notes" SortExpression="SealerRemarks" ItemStyle-CssClass="remarks_text">
                <ItemTemplate>
                    <label id="lblmerchantNotes<%# Container.DataItemIndex + 1 %>" name="lblmerchantNotes<%# Container.DataItemIndex + 1 %>">
                        <%# Eval("MerchantNotes") == DBNull.Value ? string.Empty : Eval("MerchantNotes").ToString().Replace("$$", "<br/>")%></label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L.D/S.O Appvl Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("LabDipTarget") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("LabDipTarget")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("LabDipTarget"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L.D/S.O Appvl Actual" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("LabDipStrikeOffActual") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("LabDipStrikeOffActual")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("LabDipStrikeOffActual"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bulk Approval Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("BulkApprovalTarget") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("BulkApprovalTarget")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("BulkApprovalTarget"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bulk Approval Actual" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("BulkApprovalActual") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("BulkApprovalActual")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("BulkApprovalActual"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FITS Target" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("FITTarget") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("FITTarget")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("FITTarget"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FITS Actual" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("FITActual") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("FITActual")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("FITActual"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Fits Stage" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                    <%# Eval("CurrentFitStage") == DBNull.Value ? string.Empty : Eval("CurrentFitStage").ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
