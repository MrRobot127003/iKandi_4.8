<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiabilityReport.ascx.cs"
    Inherits="iKandi.Web.LiabilityReport" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(function() {
        $("input.liability-contract", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestContractNumbers", { dataType: "xml", datakey: "string", max: 100 });
    });

    function LaunchLiabilityForm() {
        var clientID = $(".liability-client", "#main_content").val();
        var contract = $(".liability-contract", "#main_content").val();
        var ss = document.getElementById('<%=txtContractNumber.ClientID %>').value;
        
        if ($.trim(contract) == '') {
            alert('Please fill the contract number');
            return false;
        }

        proxy.invoke("FindOrderIDBreakdownByBuyerAndContract", { ClientID: clientID, Contract: contract }, function(result) {
            if (parseInt(result) == 0)
                alert("No contract found!");
            else if (parseInt(result) > 0)
                window.open("/Internal/sales/Liability.aspx?orderdetailid=" + result);
            else {
                proxy.invoke("GetOrderBreakdownByBuyerAndContractView", { ClientID: clientID, Contract: contract }, function(result) {
                    jQuery.facebox(result);
                }, onPageError, false, false);
            }
        }, onPageError, false, false);
        return false;
    }
    
</script>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Liabilty Report
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        Search
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" Width="187px"></asp:TextBox>
                    </td>
                    <td>
                        Buyer
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBuyer" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                    <nobr>
                        Payment Status
                        </nobr>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaymentStatus" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Paid"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Unpaid" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Partially Paid"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Waived Off"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Cancelled With No Liability"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    <nobr>
                        From Date
                        </nobr>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="date-picker date_style"></asp:TextBox>
                    </td>
                    <td>
                    <nobr>
                        To Date
                        </nobr>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="date-picker date_style"></asp:TextBox>
                    </td>
                    <td>
                        Year
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlYear" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" class="go" />
                    </td>
                    <td width="50px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Panel runat="server" ID="pnlLiabilitySearchForm">
                            <nobr>
                            <span style="width: 100px">Create Liability Form </span>Client&nbsp;<asp:DropDownList
                                runat="server" ID="ddlClients" CssClass="liability-client">
                            </asp:DropDownList>
                            &nbsp;&nbsp; Contract Number&nbsp;<asp:TextBox runat="server" ID="txtContractNumber"
                                CssClass="liability-contract"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Button runat="server" ID="Button1" OnClientClick="return LaunchLiabilityForm()"
                                class="go" Text="" />
                           </nobr>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_box">
        <asp:GridView runat="server" ID="grdLiability" Width="150%" CssClass="item_list" AutoGenerateColumns="false"
            OnRowDataBound="grdLiability_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="LBTY No." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Eval("LiabilityNumber") == DBNull.Value ? string.Empty : Eval("LiabilityNumber").ToString())%></a></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cancellation </br> Date" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:Label ID="lblCancelledDate" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header "
                    ItemStyle-CssClass="hypSerial quantity_style vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerial" runat="server" />
                        <%# (Eval("SerialNumber") == DBNull.Value ? string.Empty : Eval("SerialNumber").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text blue_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <%# (Eval("DepartmentName") == DBNull.Value) ? string.Empty : Eval("DepartmentName").ToString() %></a></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="187px" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <%# (Eval("StyleNumber") == DBNull.Value) ? string.Empty : Eval("StyleNumber").ToString()%>
                        <br />
                        <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("StyleID")).ToString()+",-1,"+Eval("Id").ToString() %>)'>
                            <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                                src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("SampleImageURL1")).ToString()) %>' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty </br> Cancelled" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text quantity_style ">
                    <ItemTemplate>
                        <asp:Label ID="lblQtyCancelled" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Owner" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="Label101" runat="server" Text='<%#  Eval("Owner") == DBNull.Value  ? string.Empty : Eval("Owner").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField  HeaderText="Fabric Liability" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                      <asp:Label ID="lblFabricLiabilitySign" runat="server"></asp:Label>
                        <asp:Label ID="lblFabricLiabilityPrice" runat="server"></asp:Label>
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                 <asp:TemplateField  HeaderText="Accessory Liability" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                         <asp:Label ID="lblAsscesoriesLiabilitySign" runat="server"></asp:Label>        
                          <asp:Label ID="lblAsscesoriesLiabilityAmount" Text='<%# Bind("TotalQty") %>' runat="server"></asp:Label>                        
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                <asp:TemplateField Visible="false"  HeaderText="Fabric1 Price" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                          <asp:Label ID="lblFab1PriceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFab1Price" runat="server"></asp:Label>
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  Visible="false"  HeaderText="Fabric1 Qty" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text quantity_style vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblFab1Qty" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"  HeaderText="Fabric2 Price" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                        <asp:Label ID="lblFab2PriceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFab2Price" runat="server"></asp:Label>
                         </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  Visible="false"  HeaderText="Fabric2 Qty" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text quantity_style vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblFab2Qty" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  Visible="false"  HeaderText="Fabric3 Price" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                        <asp:Label ID="lblFab3PriceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFab3Price" runat="server"></asp:Label>
                      </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"  HeaderText="Fabric3 Qty" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text quantity_style vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblFab3Qty" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"  HeaderText="Fabric4 Price" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                        <asp:Label ID="lblFab4PriceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFab4Price" runat="server"></asp:Label>
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"  HeaderText="Fabric4 Qty" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text quantity_style vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblFab4Qty" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cancellation Cost" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <nobr>
                        <asp:Label ID="lblCancelCostSign" runat="server"></asp:Label>
                        <asp:Label ID="lblCancelCost" runat="server"></asp:Label>
                       </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice No." HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="LabelInNo" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice Date" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" >
                    <ItemTemplate>
                        <nobr>
                           <asp:Label ID="Label6"   runat="server" Text='<%# ((iKandi.Common.PaymentStatus)Convert.ToInt32(Eval("PaymentStatus"))).ToString() %>'></asp:Label>
                        </nobr>
                        <br />
                        <nobr>
                           <asp:Label  runat="server" ID="lblRaisedOn" ></asp:Label>
                        </nobr>
                        <nobr>
                          <asp:Label runat="server" ID="lblNextActionDate" ></asp:Label>
                        </nobr>
                        <nobr>
                          <asp:Label runat="server" ID="lblAcknowledgedOn" ></asp:Label>
                        </nobr>
                        <nobr>
                          <asp:Label runat="server" ID="lblHoldTillDate" ></asp:Label>
                        </nobr>
                        <nobr>
                          <asp:Label runat="server" ID="lblAcceptedOn" ></asp:Label>
                        </nobr>
                        <nobr>
                          <asp:Label runat="server" ID="lblInvoiceRaisedOn" ></asp:Label>
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Merchant Remarks" ItemStyle-CssClass="remarks_text remarks_text2">
                    <ItemTemplate>
                        <asp:Label ID="Label102" runat="server" Text='<%#  Eval("MerchantRemarks") == DBNull.Value ? string.Empty : Eval("MerchantRemarks").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Documentation Remarks" >
                    <ItemTemplate>
                        <asp:Label ID="Label103" runat="server" Text='<%#  Eval("DocumentationRemarks") == DBNull.Value ? string.Empty : Eval("DocumentationRemarks").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/internal/sales/Liability.aspx?liabilityID={0}"
                    Text="Edit" />
            </Columns>
            <EmptyDataTemplate>
                <label>No records Found </label>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    <div>
    <asp:Button runat="server" ID="btnPrint" CssClass="print" onclick="btnPrint_Click" />
    </div>
</div>

