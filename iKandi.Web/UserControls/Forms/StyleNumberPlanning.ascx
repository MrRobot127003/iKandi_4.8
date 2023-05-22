<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StyleNumberPlanning.ascx.cs"
    Inherits="iKandi.Web.StyleNumberPlanning" %>

<script type="text/javascript">
$(function() 
{
});
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    
 function showDetails(OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4,StyleID,DepartmentID,PrintNumber)
  {
    $(".odi").val(OrderDetailID);
    showFabricDetails(OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4);
    showFitsDetails(StyleID,DepartmentID,OrderDetailID);
    showStyleImages(StyleID,PrintNumber);
  }
 
  function showFabricDetails(OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4)
  { 
     proxy.invoke("ShowStyleNumberPlanningFabricDetails", {OrderDetailID:OrderDetailID,OrderID:OrderID,ClientID:ClientID,Fabric1:Fabric1,Fabric2:Fabric2,Fabric3:Fabric3,Fabric4:Fabric4}, function(result)
     {
     if(result.length > 0)
     {
        $("#fab-accessory").html(result);
         $("#fab-accessory").show();
         $("#tbl-details").show();
      }
     },  onPageError, false, false);
  }

  function showFitsDetails(StyleID, DepartmentID, OrderDetailID)
  {
      proxy.invoke("ShowStyleNumberPlanningFitsDetails", { StyleNumber: StyleID, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function(result)
     { 
     if(result.length > 0)
     {
        $("#fits-details").html(result);
         $("#fits-details").show();
        $("#tbl-details").show();
         
     }
     },  onPageError, false, false);
  }
  
   function showStyleImages(StyleID,PrintNumber)
  { 
     proxy.invoke("ShowStyleNumberPlanningImages", {StyleID:StyleID,PrintNumber:PrintNumber}, function(result)
     { 
     if(result.length > 0)
     {
        $("#style-images").html(result);
         $("#style-images").show();
        $("#tbl-details").show();
         
     }
     },  onPageError, false, false);
  }
  
  function submitForm()
  {
  var fabvalue = $(".fab-owners").val();
  var fitsvalue = $(".fits-owner").val();
  var fitsrem = $(".fits-rem").val();
  var fabrem = $(".fab-rem").val();
  var date = $(".dispatch-date").val();
  var fitstrackid = $(".hdn-id").html();
  var odi = $(".odi").val();
  
    proxy.invoke("StyleFileInsertOwnerInfo", {OrderDetailID:odi,FitsOwnerID:fitsvalue,FabricOwnerID:fabvalue,FitsRemarks:fitsrem,FabricRemarks:fabrem,PlannedDispatchDate:date,FitsTrackID:fitstrackid}, function(result)
        {
         jQuery.facebox('Data has been saved successfully!');
                 
       },  onPageError, false, false ); 
     
             
  }
  function onPageError(error)
 {
   alert(error.Message + ' -- ' +error.detail);
 }
 
</script>

<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="grid_heading">
            <strong>Contract Details</strong>
        </div>
        <br />
        <div class="form_box">
            <asp:GridView CssClass="item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
                Border="0px" DataSourceID="odsBasicInfo" OnRowDataBound="GridView_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <span>
                                <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.CompanyName%>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text date_style">
                        <ItemTemplate>
                            <input type="hidden" id="orderDetailID<%# Container.DataItemIndex + 1 %>" name="orderDetailID<%# Container.DataItemIndex + 1 %>"
                                value='<%# Eval("OrderDetailID") %>' class="odi" />
                            <input type="hidden" id="RemarksID<%# Container.DataItemIndex + 1 %>" name="RemarksID<%# Container.DataItemIndex + 1 %>"
                                value='<%# Eval("RemarksID") %>' />
                            <input type="hidden" id="OrderID<%# Container.DataItemIndex + 1 %>" name="OrderID<%# Container.DataItemIndex + 1 %>"
                                value='<%# Eval("OrderID") %>' />
                            <input type="hidden" id="ClientID<%# Container.DataItemIndex + 1 %>" name="ClientID<%# Container.DataItemIndex + 1 %>"
                                value='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>' />
                            <input type="hidden" id="StatusFileId<%# Container.DataItemIndex + 1 %>" name="StatusFileId<%# Container.DataItemIndex + 1 %>"
                                value='<%# Eval("StatusFileId")%>' />
                            <input type="hidden" id="hdnDate" name="hdnDate" value="" />
                            <span>
                                <%--<%# (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)")%>--%>
                                <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)")%>
                            </span><span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Serial No.">
                        <ItemTemplate>
                        <a id="hypSerial" runat="server" class="hide_me"></a>
                            <span><a href="#" title="CLICK TO VIEW CORROSPONDING FITS/FABRIC/ACCESSORIES DETAIL" onclick="showDetails('<%# Eval("OrderDetailID") %>','<%# Eval("OrderID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# Eval("Fabric1")%>','<%# Eval("Fabric2")%>','<%# Eval("Fabric3")%>','<%# Eval("Fabric4")%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>','<%# Eval("Fabric1Details") %>')" />
                                <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></a></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <span>
                                <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contract" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <span>
                                <%# Eval("ContractNumber")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"
                        HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Qty" ItemStyle-CssClass="numeric_text" DataFormatString="{0:N0}" />
                    <asp:TemplateField HeaderText="Fabric1" SortExpression="Fabric1" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <label id="Fabric1" name="Fabric1">
                                <%# Eval("Fabric1")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fabric2" SortExpression="Fabric2" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <label id="Fabric2" name="Fabric2">
                                <%# Eval("Fabric2")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fabric3" SortExpression="Fabric3" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <label id="Fabric3" name="Fabric3">
                                <%# Eval("Fabric3")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fabric4" SortExpression="Fabric4" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text">
                        <ItemTemplate>
                            <label id="Fabric4" name="Fabric4">
                                <%# Eval("Fabric4")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="Mode" HeaderText="Mode" SortExpression="Mode" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text " />--%>
                        <asp:TemplateField HeaderText="Mode" SortExpression="Mode" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="vertical_text ">
                            <ItemTemplate>
                                <asp:Label ID="lblMode" runat="server" Text='<%# Eval("Mode") %>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField DataField="iKandiPrice" HeaderText="BIPL Price" SortExpression="iKandiPrice"
                        HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text numeric_text" DataFormatString="£ {0:N2}" />
                    <%--<asp:TemplateField HeaderText="Stat." HeaderStyle-CssClass="vertical_header">
                        <ItemTemplate>
                            <img title="CLICK TO VIEW CORROSPONDING WORKFLOW HISTORY" src="/App_Themes/ikandi/images/view_icon.png" border="0" onclick="showWorkflowHistory2('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderID") %>','<%# Eval("OrderDetailID") %>')" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <a id="hypstatusmode" runat="server" class="hide_me"></a>
                    <span>
                        <a href="javascript:void(0)"  title="CLICK TO SEE WORKFLOW HISTORY POPUP" onclick="showWorkflowHistory2('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderID") %>','<%# Eval("OrderDetailID") %>')">
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).WorkflowInstanceDetail.StatusMode %></a>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>

                    <asp:TemplateField HeaderText="STC Target" ItemStyle-CssClass="date_style">
                        <ItemTemplate>
                            <asp:Label ID="lblStcStatus" Text='<%# (Convert.ToDateTime(Eval("STCUnallocated")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("STCUnallocated")).ToString("dd MMM yy (ddd)")%>' runat="server" Width="120px"></asp:Label></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cutting" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" numeric_text percentage_text vertical_text">
                        <ItemTemplate>
                            <span>
                          <asp:Label ID="lblCutting" text=' <%# (Eval("ParentOrder") as iKandi.Common.Order).CuttingDetail.PercentagePcsCut%>' runat="server"></asp:Label> %</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text ">
                        <ItemTemplate>
                            <asp:Label ID="lblUnit" text='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryCode %>' runat="server"></asp:Label></span></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pcs Stitched" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass=" numeric_text percentage_text vertical_text">
                        <ItemTemplate>
                            <span>
                              <asp:Label ID="lblPcsStitched" Text='   <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PercentageOverallPcsStitched%>' runat="server"></asp:Label> %</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pcs Packed" HeaderStyle-CssClass="vertical_header"
                        ItemStyle-CssClass="percentage_text numeric_text vertical_text">
                        <ItemTemplate>
                            <span>
                               <asp:Label ID="lblPcsPacked" Text='  <%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.PercentageOverallPcsPacked%>' runat="server"></asp:Label> %</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sanjeev's Remarks" SortExpression="SanjeevRemarks"
                        ItemStyle-CssClass="remarks_text remarks_text2 ">
                        <ItemTemplate>
                            <label id="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>" name="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>">
                                <%# Eval("SanjeevRemarks")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Merchant Notes" SortExpression="MerchantNotes" ItemStyle-CssClass="remarks_text remarks_text2 ">
                        <ItemTemplate>
                            <label id="lblmerchantNotes<%# Container.DataItemIndex + 1 %>" name="lblmerchantNotes<%# Container.DataItemIndex + 1 %>">
                                <%# Eval("MerchantNotes")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                <label>No records Found</label></EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsBasicInfo" runat="server" SelectMethod="GetStyleFileInfoByStyleID"
                TypeName="iKandi.BLL.OrderController"></asp:ObjectDataSource>
        </div>
        <div class="form_box hide_me" id="tbl-details">
            <table width="100%">
                <tr>
                    <td width="50%" style="vertical-align:top">
                        <div class="form_box hide_me" id="fits-details">
                        </div>
                        <div class="form_box hide_me" id="style-images">
                        </div>
                    </td>
                    <td width="50%" style="vertical-align:top">
                        <div class="form_box hide_me" id="fab-accessory">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <input type="button" class="submit" onclick="submitForm();return false;" />
    <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />
</asp:Panel>
