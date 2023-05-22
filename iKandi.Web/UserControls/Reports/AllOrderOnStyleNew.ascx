<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllOrderOnStyleNew.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.AllOrderOnStyleNew" %>
<style type="text/css">
    .style1
    {
        width: 60px;
    }
</style>

<script type="text/javascript">



    //    $(function () {

    //        $('#lightbox-image-details-caption').hide();
    //        $('#lightbox-image-details-currentNumber').hide();
    //        $("a[rel=lightbox]").lightBox({

    //            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

    //            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

    //            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif',
    //            showTitle: false
    //        });

    //        $("#" + txtStyleNoClientID).autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100 });

    //    });

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID) {
        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }


    function ChildClick(chk, HCheckBox) {
        $('#<%=GridView1.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }
</script>

<div class="print-box">
    
  
        <asp:GridView CssClass="GridView1yaten fixed-header item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False"
            OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>

                <asp:TemplateField HeaderText="Order Date"
                    ItemStyle-CssClass="date_style" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <span>
                            <%# (Convert.ToDateTime((Eval("OrderDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("OrderDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%>
                        </span>
                    </ItemTemplate>
                   
                    <ItemStyle CssClass="date_style"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header "
                    ItemStyle-CssClass="hypSerial quantity_style vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerial" runat="server" />
                        <asp:Label ID="lblSerialNumber" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header " Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="hypSerial quantity_style vertical_text"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Eval("DepartmentName") == DBNull.Value) ? String.Empty : Convert.ToString(Eval("DepartmentName"))%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text blue_text"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="60px" ItemStyle-Width="60px">
                    <ItemTemplate>
                         <%# (Eval("StyleNumber") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("StyleNumber"))%>                         
                    </ItemTemplate>
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle Width="60px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Line No." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Eval("LineItemNumber") == DBNull.Value) ? String.Empty : Convert.ToString(Eval("LineItemNumber"))%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contract No" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Eval("ContractNumber") == DBNull.Value) ? String.Empty : Convert.ToString(Eval("ContractNumber"))%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description" Visible="false" SortExpression="Description" HeaderStyle-CssClass="vertical_header "
                    ItemStyle-CssClass="vertical_text ">
                    <ItemTemplate>
                        <asp:Label ID="lblDiscription" runat="server" Height="100px" Text='<%# (Eval("OrderDescription") == DBNull.Value) ? string.Empty :  Convert.ToString(Eval("OrderDescription")) %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header "></HeaderStyle>
                    <ItemStyle CssClass="vertical_text "></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="numeric_text quantity_style"
                    HeaderStyle-Width="60px" ItemStyle-Width="60px">
                    <ItemTemplate>
                        <span style="width: 60px !important">
                            <asp:Label runat="server" ID="lblQty" Text='<%# (Eval("Quantity") == DBNull.Value) ? "0" : (Convert.ToInt32(Eval("Quantity")).ToString("N0"))%>'
                                CssClass="number-with-commas"></asp:Label>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle CssClass="numeric_text quantity_style" Width="60px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric/Details" Visible="false" SortExpression="Fabric1" HeaderStyle-Width="200px"
                    ItemStyle-Width="200px">
                    <ItemTemplate>
                        <div class="fabric_left_style">
                            <span>
                                <nobr>
                            <span>
                               <%# (Eval("Fabric1") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric1"))%>
                        </span>
                    <label class="<%#((Eval("Fabric1Details").ToString().Trim() == "" ) || (Eval("Fabric1Details") == DBNull.Value) ) ? "hide_me": "" %>">
                        : <%# (Eval("Fabric1Details") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric1Details"))%></label>
                       
                       </nobr>
                                <nobr>
                            <br />
                        <span>
                            
                             <%# (Eval("Fabric2") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric2"))%>
                        </span>
                    
                    <label class="<%#((Eval("Fabric2Details").ToString().Trim() == "" ) || (Eval("Fabric2Details") == DBNull.Value )) ? "hide_me": "" %>">
                        : <%# (Eval("Fabric2Details") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric2Details"))%></label>
                        
                    </nobr>
                                <nobr>
                            <br />
                        <span>
                            
                            <%# (Eval("Fabric3") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric3"))%></a>
                        </span>
                    <label class="<%#((Eval("Fabric3Details").ToString().Trim() == "" ) || (Eval("Fabric3Details") == DBNull.Value )) ? "hide_me": "" %>">
                        : <%# (Eval("Fabric3Details") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric3Details"))%></label>
                        
                        
                       </nobr>
                                <nobr>
                            <br />
                             <%# (Eval("Fabric4") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric4"))%>
                               <label class="<%#((Eval("Fabric4Details").ToString().Trim() == "" ) || (Eval("Fabric4Details") == DBNull.Value )) ? "hide_me": "" %>">
                        : <%# (Eval("Fabric4Details") == DBNull.Value) ? string.Empty : Convert.ToString(Eval("Fabric4Details"))%></label>
                        
                      </nobr>
                            </span>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Width="200px"></HeaderStyle>
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STC Tgt." Visible="false" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style"
                    ItemStyle-Width="28px ">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime((Eval("STCUnallocated") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("STCUnallocated")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("STCUnallocated"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text date_style" Width="28px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fit Status" Visible="false" HeaderStyle-CssClass=" " ItemStyle-CssClass="remarks_text2 "
                    HeaderStyle-Width="180px" ItemStyle-Width="180px">
                    <ItemTemplate>
                        <asp:Label Width="180px" CssClass="" ID="lblFitStatus" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass=" " Width="180px"></HeaderStyle>
                    <ItemStyle CssClass="remarks_text2 " Width="180px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top Sent Tgt." Visible="false" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <span>
                            <%# (Convert.ToDateTime((Eval("TopSentTarget") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("TopSentTarget")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("TopSentTarget"))).ToString("dd MMM yy (ddd)")%>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text date_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cutting" Visible="false" HeaderStyle-CssClass="vertical_header percentage_width"
                    ItemStyle-CssClass="vertical_text percentage_width" HeaderStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Label ID="lblCut" runat="server"></asp:Label>
                        %
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header percentage_width" Width="20px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text percentage_width"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stiching" Visible="false" HeaderStyle-CssClass="vertical_header percentage_width"
                    ItemStyle-CssClass="vertical_text percentage_width" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Label ID="lblStitch" runat="server"></asp:Label>
                        %
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header percentage_width"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text percentage_width" Width="20px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Packed" Visible="false" HeaderStyle-CssClass="vertical_header percentage_width "
                    ItemStyle-CssClass="vertical_text percentage_width " HeaderStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Label ID="lblPacked" runat="server"></asp:Label>
                        %
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header percentage_width " Width="20px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text percentage_width "></ItemStyle>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text blue_text"
                    HeaderStyle-Width="140px" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="lblEx" Value='<%# ((Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) || (Eval("ExFactory") == DBNull.Value)) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                        <asp:Label ID="lblExFact" runat="server" Width="140px" Text='<%# (Convert.ToDateTime((Eval("ExFactory") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("ExFactory")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="140px"></HeaderStyle>
                    <ItemStyle CssClass="date_style bold_text blue_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DC Date" SortExpression="DC" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime((Eval("DC") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("DC")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text date_style"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="BIPL Price" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="numeric_text vertical_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <span><asp:Label ID="lblBiplPriceSymbal" runat="server" ></asp:Label>
                            <%#(Eval("BIPLPrice") == DBNull.Value)? string.Empty :(Convert.ToDouble((Eval("BIPLPrice"))).ToString("N2"))%>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="numeric_text vertical_text"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="iKandi Price" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="numeric_text vertical_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <span><asp:Label ID="lblIkandiPriceSymble" runat="server"></asp:Label>
                            <%#(Eval("iKandiPrice") == DBNull.Value) ? string.Empty : (Convert.ToDouble((Eval("iKandiPrice"))).ToString("N2"))%>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="numeric_text vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="lblStatus" />
                        <%# (Eval("StatusMode") == DBNull.Value) ? string.Empty : Eval("StatusMode")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header" Width="28px"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                    <ItemTemplate>
                        <span><a id="hypUnit" runat="server" class="hide_me"></a>
                            <%# (Eval("FactoryCode") == DBNull.Value) ? string.Empty : Eval("FactoryCode")%>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text quantity_style"></ItemStyle>
                </asp:TemplateField>


                
              <asp:TemplateField HeaderText="Is Updated" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="25%" >
                            <ItemTemplate>  <div style="text-align:center; ">
                                   <asp:CheckBox  ID="chkUpdate" Checked="false" runat="server" />
                                   <asp:HiddenField runat="server" ID="hdnOrderId" Value='<%#Eval("Id") %>' /> 
                                    </div>
                            </ItemTemplate>                             
                        </asp:TemplateField>


            </Columns>



            <EmptyDataTemplate>
                <label>No records Found</label></EmptyDataTemplate>
        </asp:GridView>
  
</div>
<div runat="server" id="divPrint">
  
</div>


