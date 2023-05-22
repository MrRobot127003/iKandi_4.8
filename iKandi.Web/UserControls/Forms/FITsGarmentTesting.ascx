<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FITsGarmentTesting.ascx.cs"
    Inherits="iKandi.Web.FITsGarmentTesting" %>
<div class="form_box">
    <div class="form_heading">
        Garment Testing
    </div>
    <div class="form_box">
        <asp:GridView runat="server" ID="gridGarmentTesting" AutoGenerateColumns="false"
            OnRowDataBound="gridGarmentTesting_RowDataBound" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--<%# (Eval("OrderDetail") as iKandi.Common.OrderDetail).ParentOrder.OrderDate.ToString("MM/dd/yyyy") %>--%>
                        <%# (Convert.ToDateTime((Eval("OrderDetail") as iKandi.Common.OrderDetail).ParentOrder.OrderDate) == DateTime.MinValue) ? "" : (Eval("OrderDetail") as iKandi.Common.OrderDetail).ParentOrder.OrderDate.ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                        <%# (Eval("OrderDetail") as iKandi.Common.OrderDetail).ParentOrder.SerialNumber %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line Number">
                    <ItemTemplate>
                        <%# (Eval("OrderDetail") as iKandi.Common.OrderDetail).LineItemNumber %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contract Number">
                    <ItemTemplate>
                        <%# (Eval("OrderDetail") as iKandi.Common.OrderDetail).ContractNumber %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric1">
                    <ItemTemplate>
                        <%# (Eval("OrderDetail") as iKandi.Common.OrderDetail).Fabric1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory Date" ItemStyle-CssClass="date_style">
                    <ItemTemplate>                                            
                        <%# (Convert.ToDateTime((Eval("OrderDetail") as iKandi.Common.OrderDetail).ExFactory) == DateTime.MinValue) ? "" : (Eval("OrderDetail") as iKandi.Common.OrderDetail).ExFactory.ToString("dd MMM yy (ddd)")%>
                        <asp:HiddenField ID="hdnEx" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Testing Completion Target" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtTestingCompletionTarget" ReadOnly="true" CssClass="date_style" Text='<%# (DateTime.Parse(Eval("TestingCompletionDate").ToString()).ToString("MM/dd/yyyy") == "01/01/0001") ? "" : DateTime.Parse(Eval("TestingCompletionDate").ToString()).ToString("dd MMM yy (ddd)") %>' ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="test completion actual" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtGarmentTestReport" CssClass="date_style date-picker" Text='<%# (DateTime.Parse(Eval("ReportCompletionDate").ToString()).ToString("MM/dd/yyyy") == "01/01/0001") ? "" : DateTime.Parse(Eval("ReportCompletionDate").ToString()).ToString("dd MMM yy (ddd)") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
<asp:TemplateField HeaderText="Bulk Test Report" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileUploadBulkTest" class="multi" maxlength="5" Width="150px" />
                        <div>
                            <asp:Repeater ID="rptBulkTestLinkAttachment" runat="server" OnItemDataBound="rptBulkTestLinkAttachment_ItemDataBound"
                                OnItemCommand="rptBulkTestLinkAttachment_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:LinkButton ID="lnkBulkTestBtnAttachment" runat="server" Text="X" CommandName='<%# Eval("UploadedReportFilePath") %>'
                                            CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                        <a target="_blank" href='<%# ResolveUrl("~/" + System.Configuration.ConfigurationManager.AppSettings["garment.testing.docs.folder"] + Eval("UploadedReportFilePath").ToString()) %>'
                                            class="<%# (Eval("UploadedReportFilePath") == null || string.IsNullOrEmpty(Eval("UploadedReportFilePath").ToString()) ) ? "hide_me": "" %>">
                                            View File -<asp:Label ID="lblBulkTestAttachment" runat="server"></asp:Label></a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Upload Garment Test Report" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileUploadGarmentTest" class="multi" maxlength="5" Width="150px" />
                        <div>
                            <asp:Repeater ID="rptLinkAttachment" runat="server" OnItemDataBound="rptLinkAttachment_ItemDataBound"
                                OnItemCommand="rptLinkAttachment_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:LinkButton ID="lnkBtnAttachment" runat="server" Text="X" CommandName='<%# Eval("UploadedReportFilePath") %>'
                                            CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                        <a target="_blank" href='<%# ResolveUrl("~/" + System.Configuration.ConfigurationManager.AppSettings["garment.testing.docs.folder"] + Eval("UploadedReportFilePath").ToString()) %>'
                                            class="<%# (Eval("UploadedReportFilePath") == null || string.IsNullOrEmpty(Eval("UploadedReportFilePath").ToString()) ) ? "hide_me": "" %>">
                                            View File -<asp:Label ID="lblAttachment" runat="server"></asp:Label></a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="90px">
                            <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Complete" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
            <HeaderStyle CssClass="item_list" />
            <RowStyle CssClass="item_list" />
        </asp:GridView>
    </div>
</div>
<div>
    <asp:Button ID="btnSaveAll" runat="server" CssClass="save" OnClick="btnSaveAll_Click" />
    <br />
    <br />
</div>
