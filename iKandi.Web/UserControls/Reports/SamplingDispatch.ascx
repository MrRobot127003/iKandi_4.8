<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SamplingDispatch.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.SamplingDispatch" %>
<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Sampling Dispatch Report
        </div>
        <div>
            Courier Date:
            <asp:TextBox runat="server" ID="txtCourierDate" CssClass="date-picker do-not-disable"></asp:TextBox>
            Search:
            <asp:TextBox runat="server" ID="txtSearchText" CssClass="do-not-disable" MaxLength="40"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
        </div>
    </div>
    <div class="form_box">
        <asp:GridView runat="server" ID="grdSamplingDispatch" CssClass="item_list fixed-header"
            AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="ATTN">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ContactName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Buyer">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<% # Eval("ClientName") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REF">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<% # Eval("StyleNumber")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<% # Eval("Item")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<% # Eval("Quantity")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<% # Eval("Fabric")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purpose">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<% # Eval("Purpose")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Courier AWB NUMBER">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<% # Eval("CourierNumber")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Courier Company">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<% # Eval("CourierCompany")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="From">
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<% # Eval("SentByFirstName")%>'></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text='<% # Eval("SentByLastName")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    NO RECORD FOUND</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>
<%--<input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />--%>
<%--
 <asp:ListBox runat="server" ID="listClient" SelectionMode="Multiple"></asp:ListBox>
     <asp:Button runat="server" ID="btnTest" OnClick="btnTest_click" Text="Test" />--%>