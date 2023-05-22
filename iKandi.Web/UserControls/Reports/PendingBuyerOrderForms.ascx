<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendingBuyerOrderForms.ascx.cs"
    Inherits="iKandi.Web.PendingBuyerOrderForms" %>

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


    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID) {
        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }
  
  
 
  
</script>

<div class="form_box">
    <div class="form_heading">
        PENDING BUYER ORDER FORMS REPORT
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
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                <ItemTemplate>
                    <span>
                        <%# (Convert.ToDateTime((Eval("OrderDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("OrderDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass=" " ItemStyle-CssClass="hypSerial quantity_style "
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <%# (Eval("SerialNumber")) == DBNull.Value ? string.Empty : Eval("SerialNumber").ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <%# (Eval("DepartmentName") == DBNull.Value) ? string.Empty : Eval("DepartmentName").ToString() %></a></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                <nobr>
                    <%# (Eval("StyleNumber") == DBNull.Value) ? string.Empty : Eval("StyleNumber").ToString() %></nobr>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("StyleID")).ToString()+",-1,"+Eval("Id").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("SampleImageURL1")).ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <asp:Label ID="lblLineNo" runat="server" Text='<%# Eval("LineItemNumber") == DBNull.Value ? string.Empty : Eval("LineItemNumber").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contract No" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px">
                <ItemTemplate>
                    <asp:Label ID="lblContNo" runat="server" Text='<%# Eval("ContractNumber") == DBNull.Value ? string.Empty : Eval("ContractNumber").ToString()%>'></asp:Label>
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
                        <asp:Label runat="server" ID="lblQty" Text='<%# (Eval("Quantity") == DBNull.Value || Eval("Quantity").ToString() == "") ? "0" : (Convert.ToInt32(Eval("Quantity")).ToString("N0"))%>'
                            CssClass="number-with-commas"></asp:Label>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric" SortExpression="Fabric1" HeaderStyle-Width="200px"
                ItemStyle-Width="200px">
                <ItemTemplate>
                    <div class="fabric_left_style">
                        <span>
                            <nobr>
                            <span>
                               <%# Eval("Fabric1") == DBNull.Value ? string.Empty : Eval("Fabric1").ToString()%>
                        </span>
                    <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" || Eval("Fabric1Details") == DBNull.Value ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric1Details") == DBNull.Value ? string.Empty : Eval("Fabric1Details").ToString() %></label>                     
                        
                        </nobr>
                            <nobr>
                            <br />
                        <span>
                            
                             <%# Eval("Fabric2") == DBNull.Value ? string.Empty : Eval("Fabric2").ToString() %>
                        </span>
                    
                    <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" || Eval("Fabric2Details") == DBNull.Value) ? "hide_me": "" %>">
                        : <%# Eval("Fabric2Details") == DBNull.Value ? string.Empty : Eval("Fabric2Details").ToString() %></label>                        
                       </nobr>
                            <nobr>
                            <br />
                        <span>
                            
                            <%# Eval("Fabric3") == DBNull.Value ? string.Empty : Eval("Fabric3").ToString() %></a>
                        </span>
                    
                    <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" || Eval("Fabric3Details") == DBNull.Value ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric3Details") == DBNull.Value ? string.Empty : Eval("Fabric3Details").ToString() %></label>
                        
                        </nobr>
                            <nobr>
                            <br />
                         <span>
                            
                            <%# Eval("Fabric4") == DBNull.Value ? string.Empty : Eval("Fabric4").ToString() %>
                        </span> 
                    
                    <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" || Eval("Fabric4Details") == DBNull.Value ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric4Details") == DBNull.Value ? string.Empty : Eval("Fabric4Details").ToString() %></label>
                       </nobr>
                        </span>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="STC Tgt." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style"
                ItemStyle-Width="28px ">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("STCUnallocated") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("STCUnallocated")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("STCUnallocated"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fits" HeaderStyle-CssClass=" " ItemStyle-CssClass="remarks_text2 "
                HeaderStyle-Width="180px" ItemStyle-Width="180px">
                <ItemTemplate>
                    <asp:Label Width="180px" CssClass="" ID="lblFitStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Top Sent Tgt." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                <ItemTemplate>
                    <span>
                        <%# (Convert.ToDateTime((Eval("TopSentTarget") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("TopSentTarget")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("TopSentTarget"))).ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cutting" HeaderStyle-CssClass="vertical_header percentage_width"
                ItemStyle-CssClass="vertical_text percentage_width" HeaderStyle-Width="20px">
                <ItemTemplate>
                    <asp:Label ID="lblCut" runat="server" Text='<%# (Eval("PcsCut") == DBNull.Value || Eval("PcsCut").ToString().Trim() == string.Empty) ? "0%" : ( Eval("Quantity") == DBNull.Value || Eval("Quantity") == "0" ) ? "0%": (Convert.ToDouble(Eval("PcsCut")) / (Convert.ToDouble(Eval("Quantity"))) * 100).ToString("N0") + "%"%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stiching" HeaderStyle-CssClass="vertical_header percentage_width"
                ItemStyle-CssClass="vertical_text percentage_width" ItemStyle-Width="20px">
                <ItemTemplate>
                    <asp:Label ID="lblStitch" runat="server" Text='<%# (Eval("PcsStitched") == DBNull.Value || Eval("PcsStitched").ToString().Trim() == string.Empty) ? "0%" : (Eval("Quantity") == DBNull.Value || Eval("Quantity") == "0") ? "0%" : (Convert.ToDouble(Eval("PcsStitched")) / (Convert.ToDouble(Eval("Quantity"))) * 100).ToString("N0") + "%"%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Packed" HeaderStyle-CssClass="vertical_header percentage_width "
                ItemStyle-CssClass="vertical_text percentage_width " HeaderStyle-Width="20px">
                <ItemTemplate>
                    <asp:Label ID="lblPacked" runat="server" Text='<%# (Eval("PcsPacked") == DBNull.Value || Eval("PcsPacked").ToString().Trim() == string.Empty) ? "0%" : (Eval("Quantity") == DBNull.Value || Eval("Quantity") == "0") ? "0%" : (Convert.ToDouble(Eval("PcsPacked")) / (Convert.ToDouble(Eval("Quantity"))) * 100).ToString("N0") + "%"%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text blue_text"
                HeaderStyle-Width="120px">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="lblEx" Value='<%# ( Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                    <div style="width: 120px ! important;">
                    </div>
                    <%# (Convert.ToDateTime((Eval("ExFactory") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("ExFactory")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DC Date" SortExpression="DC" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                <ItemTemplate>
                    <%# (Convert.ToDateTime((Eval("DC") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("DC")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="numeric_text vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <span>
                        <nobr>
                    <asp:Label ID="lblPriceSign" runat="server"></asp:Label>  
                             <asp:Label ID="lblPrice" runat="server" Text='<%# (Eval("BIPLPrice") == DBNull.Value  || (Eval("BIPLPrice").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToDouble((Eval("BIPLPrice"))).ToString("N2")) %>'></asp:Label>                
                    </nobr>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="lblStatus" />
                    <%# Eval("StatusMode") == DBNull.Value ? string.Empty : Eval("StatusMode").ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <span><a id="hypUnit" runat="server" class="hide_me"></a>
                        <%# (Eval("FactoryCode") == DBNull.Value ? string.Empty : Eval("FactoryCode").ToString())%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buyer Contract" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblFileExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblLineNOExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contract No" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblContractNoExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric Detail" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblFabricDetailsExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bipl Price" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblBiplPriceExistExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ikandi Price" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblIkandiPriceExistExist" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
