<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RejectedQaContracts.ascx.cs"
    Inherits="iKandi.Web.RejectedQaContracts" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<div class="form_box">
    <div class="form_heading">
        Rejected QA Contracts Report
    </div>
    <div>
        <table>
            <tr>
                <td>
                    Client
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlClient" AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
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
    <asp:GridView CssClass="item_list1 fixed-header" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" PageSize="10">
        <Columns>
            <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <a id="hypSerial" runat="server" class="hide_me"></a><span><a title="CLICK TO VIEW QUALITY ASSURANCE FORM"
                        target="QualityControlForm" href="../Merchandising/QualityControl.aspx?orderDetailID=<%# Eval("OrderDetailID") %>">
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></span></a> </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:TemplateField HeaderText="Department" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.DepartmentName%></span><br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <ItemTemplate>
                <nobr>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>
                    </nobr>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID +",-1,"+Eval("OrderDetailID").ToString() %>)'>
                        <img style="height: 75px" title="CLICK TO VIEW ENLARGED IMAGE" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("ParentOrder") as iKandi.Common.Order).Style.SampleImageURL1.ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Fabric1Details" HeaderText="Colour/Print" SortExpression="Fabric1Details"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="80px" ItemStyle-Width="80px">
                <ItemTemplate>
                    <%#  Eval("Quantity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Top Sent Tgt." SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <asp:Label ID="lblTopsendTgt" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Top Actual App." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <asp:Label ID="lblTopActualapp" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopActualApproval) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopActualApproval.ToString("dd MMM yy (ddd)")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory " ItemStyle-CssClass=" date_style bold_text"
                HeaderStyle-Width="120px" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label runat="server" Width="120px" ID="lblEx" Text=' <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <span>
                        <%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryCode %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).WorkflowInstanceDetail.StatusMode %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MDA Number" HeaderStyle-CssClass="vertical_header">
                <ItemTemplate>
                    <label>
                        <%# Eval("MDANumber") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cutting Received" ItemStyle-CssClass="numeric_text"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.CuttingReceived%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cutting Pending" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.CuttingPending.ToString("N0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stiching Info/ Exp. Completion" HeaderStyle-Width="100px"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <div style="width: 100px">
                        <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ExpectedFinishDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ExpectedFinishDate.ToString("dd MMM yy (ddd)")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Pcs Stiched Today" ItemStyle-CssClass="numeric_text"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.TotalPcsStitchedToday %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Overall Pcs Stiched" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OverallPcsStitched %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bal On Mach." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.BalOnMach %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Qty Bal" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OrderQtyBal %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Sent" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PcsSent%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Received" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PcsReceived%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Recvd" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PcsReceivedPack %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Packed Today" ItemStyle-CssClass="numeric_text"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PcsPackedToday%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Overall Pcs Packed" ItemStyle-CssClass="quantity_style"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OverallPcsPacked%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bal.In Packing" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text numeric_text">
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.BalInPack %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Qty Bal." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text numeric_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OrderQtyBalPck.ToString("N0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Production Remarks" ItemStyle-CssClass="remarks_text remarks_text2 "
                HeaderStyle-Width="200px" ItemStyle-Width="200px">
                <ItemTemplate>
                    <div style="width: 200px ! important">
                        <asp:Label ID="Label1" runat="server" Text='<%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().IndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Substring((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2) : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString() %>'></asp:Label>
                    </div>
                    <br />
                    <img alt="Production Remarks" title="CLICK TO SEE REMARKS HISTORY" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ID %>','<%# Eval("OrderDetailID") %>','<%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().IndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','ProdRemarks','MANAGE_ORDER_FILE','<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_STITCHING_PRODUCTION_REMARKS)? 1 : 0 %>')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
<div style="margin-top: 5px; text-align: right;">
    <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
    </cc1:HyperLinkPager>
</div>

