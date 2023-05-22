<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionReport.ascx.cs" Inherits="iKandi.Web.ProductionReport" %>

<script type="text/javascript">
$(function() 
{
BindControls();


var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
 var proxy = new ServiceProxy(serviceUrl);
});
</script>

<div class="print-box">
<div class="form_box">
        <div class="form_heading">
            Production Report
        </div>
        <div>
            <table width="800px" cellspacing="10">
                <tr>
                    <td>
                        <asp:Label ID="lablsearch" Text="Search Text" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtsearch" class="do-not-disable" MaxLength="40" runat=server></asp:TextBox>
                    </td>
                    <td>
                        ExFactory
                    </td>
                    <td>
                        <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat=server id="txtfrom" class="date-picker do-not-disable"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat=server id="txtTo" class="date-picker do-not-disable"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                         <asp:ListItem Selected=True Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlUnit" runat="server" CssClass="do-not-disable">
                          <asp:ListItem Selected=True Text="Select.." Value="-1"></asp:ListItem>
                         </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button runat=server class="go do-not-disable" OnClick="btnSearch_Click" 
                            ID="btnSearch" />
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
    <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" 
     AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.CompanyName%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="
            "  HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <span> 
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                     <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." >
                <ItemTemplate>
                    <span>
                      <nobr>  <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %></nobr>
                      <br />                    
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID +",-1,"+Eval("OrderDetailID").ToString()%>)'>
                        <img style="height : 75px ! important"  title="CLICK TO VIEW ENLARGED IMAGE" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("ParentOrder") as iKandi.Common.Order).Style.SampleImageURL1.ToString()) %>' /></a>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line/Item No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />                
            <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="vertical_header " ItemStyle-CssClass="vertical_text ">
                <ItemTemplate>
                    <asp:Label ID="lblDesc" runat="server" Height="100px" Text=' <%# (Eval("ParentOrder") as iKandi.Common.Order).Description%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="vertical_header " ItemStyle-CssClass="numeric_text vertical_text quantity_style">
                <ItemTemplate>
                    <span>
                         <%# Convert.ToInt32( Eval("Quantity")).ToString("N0") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMode" Text=' <%# Eval("ModeName")%>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header"  ItemStyle-CssClass="date_style vertical_text ">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblEx" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnStatus" runat="server" />
                       <%# (Eval("ParentOrder") as iKandi.Common.Order).WorkflowInstanceDetail.StatusMode %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sealer Tgt." SortExpression="SealETA" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("STCUnallocated")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("STCUnallocated"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sealer Actual" SortExpression="SealDate" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <asp:Label ID="lblSealDate" Text='  <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).Fits.SealDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).Fits.SealDate.ToString("dd MMM yy (ddd)")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric Details" SortExpression="Fabric1" >
                <ItemTemplate>
                <div class="fabric_left_style">
                    <nobr><span>
                         <%# Eval("Fabric1")%>
                    </span>
                    <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>"> :  <%# Eval("Fabric1Details")%></label>            
                    
                    <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent.ToString().Trim() == "0" ) ? "hide_me": "" %>"> (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%)</label>
                    
                    </nobr>
                    <br />
                    <nobr><span>
                          <%# Eval("Fabric2")%>
                        </span>
                    <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>"> : <%# Eval("Fabric2Details")%></label>
                    &nbsp;
                    
                    <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent.ToString().Trim() == "0" ) ? "hide_me": "" %>"> (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%)</label>
                    
                    </nobr>
                    <br />
  
                    <nobr><span>
                        <%# Eval("Fabric3")%>
                        </span>
                    <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>"> : <%# Eval("Fabric3Details")%></label>
                    &nbsp;
                    
                    <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent.ToString().Trim() == "0" ) ? "hide_me": "" %>">  (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%)</label>
                    
                    </nobr>
                     <br />   
                        
                    <nobr><span>
                        <%# Eval("Fabric4")%>
                        </span>
                    <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>"> : <%# Eval("Fabric4Details")%></label>
                    &nbsp;
                    
                    <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent.ToString().Trim() == "0" ) ? "hide_me": "" %>"> (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>%)</label>
                    
                    </nobr>
                   </div>
                                        
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Accessories" ItemStyle-CssClass="remarks_text2 remarks_text">
                <ItemTemplate>
                <div style="width : 250px ! important">                    
                    <asp:Label ID="lblAccessary" runat="server"></asp:Label>                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inline Cut<br/> Date" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <label><%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate.ToString("dd MMM yy (ddd)")%> </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cutting <br/> Actual" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <label><%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).CuttingHistory.Date) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).CuttingHistory.Date.ToString("dd MMM yy (ddd)")%> </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PCS cut" ItemStyle-CssClass="numeric_text vertical_header" HeaderStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).CuttingDetail.PcsCut.ToString("N0") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PCS issued" ItemStyle-CssClass="numeric_text vertical_header" HeaderStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).CuttingDetail.PcsIssued.ToString("N0")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs cut %" HeaderStyle-CssClass="vertical_header  " ItemStyle-CssClass="vertical_text  ">
                <ItemTemplate>
                    <asp:Label ID="lblPcsCutPercent" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).CuttingHistory.PercentagePcsCut.ToString("N0")%>'></asp:Label>
                    %
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"  >
                <ItemTemplate>
                 <span>
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                      <%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryName%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Top Target" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <span>
                      <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Top Actual" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <span>
                        <asp:HiddenField ID="hdnTopActual" runat="server" />
                      <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Stiched<br/> Today" HeaderStyle-CssClass="vertical_header"  ItemStyle-CssClass="numeric_text vertical_text" >
                <ItemTemplate>
                    <label><%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.TotalPcsStitchedToday.ToString("N0") %> </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Stiched<br/> Overall" ItemStyle-CssClass="numeric_text vertical_text" HeaderStyle-CssClass="vertical_header"  >
                <ItemTemplate>
                    <label><%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OverallPcsStitched.ToString("N0") %> </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Stitched %" HeaderStyle-CssClass="vertical_header  " ItemStyle-CssClass="vertical_text  ">
                <ItemTemplate>
                    <asp:Label ID="lblPcsStitchedPercent" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PercentageOverallPcsStitched.ToString("N0")%>'></asp:Label>
                    %
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Packed" HeaderStyle-CssClass="vertical_header  " ItemStyle-CssClass="vertical_text  ">
                <ItemTemplate>
                    <asp:Label ID="lblPacked" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PercentageOverallPcsPacked.ToString("N0")%>'></asp:Label>
                    %
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bal On Mach." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text numeric_text"  >
                <ItemTemplate>
                    <label><%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.BalOnMach.ToString("N0") %> </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Packed<br/> Today" ItemStyle-CssClass="numeric_text vertical_text" HeaderStyle-CssClass="vertical_header" >
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PcsPackedToday.ToString("N0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pcs Packed<br/> Overall" ItemStyle-CssClass="numeric_text vertical_text" HeaderStyle-CssClass="vertical_header" >
                <ItemTemplate>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.OverallPcsPacked.ToString("N0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Production Remarks"   ItemStyle-CssClass="remarks_text remarks_text2 " HeaderStyle-Width="200px" ItemStyle-Width="200px"  >
                <ItemTemplate>
                   
                    <div class="" style=" width : 200px! important">
                        <%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Substring((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$")+2) : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString()%> 
                    </div>
                    
                            <img alt="Fits Resolution" title="CLICK TO SEE RESOLUTION HISTORY" src="/App_Themes/ikandi/images/remark.gif"
                            border="0" onclick="showRemarks(0,0,'<%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().IndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','ProductionRemarks','Production_Reports',0)" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    
    
    
</div>
<asp:Button ID="btnPdf" Text="" CssClass="print" runat="server" OnClick="btnPdf_click" />

</div>