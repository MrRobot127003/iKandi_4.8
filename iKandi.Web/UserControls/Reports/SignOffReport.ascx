<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignOffReport.ascx.cs"
    Inherits="iKandi.Web.SignOffReport" %>

<script type="text/javascript">

    $(function() {

        $('#lightbox-image-details-caption').hide();
        $('#lightbox-image-details-currentNumber').hide();
        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',
            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',
            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif',
            showTitle: false
        });

    });

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
     
</script>

<div class="form_box">
    <div class="form_heading">
        SIGN OFFS REPORT
    </div>
    <div>
        <table width="300px" cellspacing="10">
            <tr>
                <td>
                    Buyer :
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:HiddenField ID="hdnPagesize" runat="server" />
    <asp:HiddenField ID="hdnPageIndex" runat="server" />
    <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
    <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
    <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" AllowPaging="true"
        PageSize="10" OnPageIndexChanging="GridView1_OnPageIndexChanging" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
        <Columns>
            <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                <ItemTemplate>
                    <span>
                        <%# (Convert.ToDateTime((Eval("OrderDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("OrderDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass=" " ItemStyle-CssClass="hypSerial quantity_style">
                <ItemTemplate>
                    <%# (Eval("SerialNumber") == DBNull.Value) ? string.Empty : (Eval("SerialNumber").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <%# (Eval("Buyer") == DBNull.Value) ? string.Empty : Eval("Buyer").ToString() %></a></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <%# Eval("DepartmentName") == DBNull.Value ?  string.Empty : Eval("DepartmentName").ToString()%></a></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="70px" ItemStyle-Width="70px">
                <ItemTemplate>
                    <nobr><%# (Eval("StyleNumber") == DBNull.Value) ? string.Empty : Eval("StyleNumber").ToString() %></nobr>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("StyleID")).ToString()+",-1,"+Eval("Id").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("SampleImageURL1")).ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-CssClass="vertical_header "
                ItemStyle-CssClass="vertical_text ">
                <ItemTemplate>
                    <asp:Label ID="lblDiscription" runat="server" Height="100px" Text='<%# Eval("OrderDescription") == DBNull.Value ? string.Empty : Eval("OrderDescription").ToString()  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span style="width: 60px !important">
                        <asp:Label runat="server" ID="lblQty" Text='<%# (Eval("OrderQuantity") == DBNull.Value) ? "0" : (Convert.ToInt32(Eval("OrderQuantity")).ToString("N0"))%>'
                            CssClass="number-with-commas"></asp:Label>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("StatusMode") == DBNull.Value ? string.Empty : Eval("StatusMode").ToString() %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Merchandising Mgr." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOFMerchandisingMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BIPL Sales Mgr." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOFBiplSalesMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ACCOUNT MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblFFAccountMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FABRIC MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblFFFabricMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ACCOUNT MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblAFAccountMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ACCESSORY MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblAFAccessoryMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FABRIC MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOLFFabricMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ACCESSORIES MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOLFAccessoryMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PRODUCTION MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOLFProdMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MERCHANDISING MGR." HeaderStyle-CssClass="" ItemStyle-CssClass="">
                <ItemTemplate>
                    <asp:Label ID="lblOLFMerchandMgr" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
