<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SealersPendingList.ascx.cs"
    Inherits="iKandi.Web.SealersPendingList" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);
var BuyerDDClientID = '<%=ddlClients.ClientID%>' ;
var DeptDDClientID = '<%=ddlDepartment.ClientID%>' ;
var jscriptPageVariables = null;
var selectedDept;
var hdnDeptIdClientID = '<%=hiddenDeptId.ClientID %>';

$(function() 
{
$("#"+BuyerDDClientID,'#main_content').change(function(){
        var clientId = $(this).val();
        populateDepartments($(this).val());
     });
    
     $("#"+DeptDDClientID,'#main_content').change(function()
      {
        selectedDept = $("#"+DeptDDClientID).find("option:selected").text();
        setDeptName();
        
     });
     
     populateDepartments($("#"+BuyerDDClientID,'#main_content').val());


BindControls();
});

function populateDepartments(clientId,selectedDeptID)
{
 
  bindDropdown(serviceUrl,DeptDDClientID, "GetClientDeptsByClientID", {ClientID:clientId},  "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID , onPageError, setDeptName ) 
  if(jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
    jscriptPageVariables.selectedDeptID = '';   
}

function setDeptName()
{ 
 selectedDept = $("#"+DeptDDClientID,"#main_content").val();
  $("#"+hdnDeptIdClientID,"#main_content").val(selectedDept);
 $("#"+DeptDDClientID,"#main_content").children(":first").text("ALL");  
}

 function showFabricPopup(StyleID,OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4,Fabric1Details,Fabric2Details,Fabric3Details,Fabric4Details)
  { 
     proxy.invoke("ShowManageOrderFabricDatesPopup", {StyleID:StyleID,OrderDetailID:OrderDetailID,OrderID:OrderID,ClientID:ClientID,Fabric1:Fabric1,Fabric2:Fabric2,Fabric3:Fabric3,Fabric4:Fabric4,Fabric1Details:Fabric1Details,Fabric2Details:Fabric2Details,Fabric3Details:Fabric3Details,Fabric4Details:Fabric4Details}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
   function ShowFitsPopup(StyleNumber,DepartmentID,OrderDetailID)
  {
   proxy.invoke("ManageOrderFitsInfoPopup", {StyleNumber:StyleNumber,DepartmentID:DepartmentID,OrderDetailID:OrderDetailID}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }


</script>

<div>
    <table width="1000px" cellspacing="5">
        <tr>
            <td>               
                Search Text : &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtsearch" class="do-not-disable" MaxLength="40" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                Select Client : &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList Width="125px" ID="ddlClients" runat="server" CssClass="do-not-disable">
                    <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Select Department : &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList Width="125px" ID="ddlDepartment" runat="server" CssClass="do-not-disable">
                    <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</div>
<div class="form_box">
    <asp:GridView CssClass="item_list fixed-header" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text bold_text">
                <ItemTemplate>
                    <span>
                        <asp:Label ID="lblSerial" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>'
                            runat="server"></asp:Label></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <input type="hidden" id="styleID<%# Container.DataItemIndex + 1 %>" name="styleID<%# Container.DataItemIndex + 1 %>"
                        value='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>' />
                    <input type="hidden" id="clientDepartmentID<%# Container.DataItemIndex + 1 %>" name="clientDepartmentID<%# Container.DataItemIndex + 1 %>"
                        value='<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentID %>' />
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.ClientName %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentName%></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span>
                        <nobr>
                    <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %></nobr>
                        <br />
                        <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>, -1,-1)'>
                            <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                                src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("ParentOrder") as iKandi.Common.Order).Style.SampleImageURL1.ToString()) %>' /></a>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line  No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server"  Height="150px"  Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="Qty." SortExpression="Quantity"
                ItemStyle-CssClass="numeric_text quantity_style vertical_text" DataFormatString="{0:N0}" 
                 HeaderStyle-CssClass="vertical_header"/>
            <asp:TemplateField HeaderText="Fabric" SortExpression="Fabric1" HeaderStyle-Width="250px"
                ItemStyle-Width="250px">
                <ItemTemplate>
                    <div class="fabric_left_style" style="width: 250px ! important;">
                        <span>
                            <nobr>
                            <span >
                            <a title="CLICK TO VIEW APPROVALS FORM" target="FabricApprovalsForm" 
                           href='<%#(Eval("Fabric1Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID        +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))               +"&fabric="+Server.UrlEncode(Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric1Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                               +"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric1Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric1")%></a>
                          <%--  <%# Eval("Fabric1")%>--%>
                        </span>
                    <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric1Details")%></label>
                       
                        <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%
                            )                            
                        </label></nobr>
                            <nobr>
                            <br /><asp:Label Height="100px" ID="lblFabric111" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM1")%>'></asp:Label><br />
                        <span>
                            <a target="FabricApprovalsForm" 
                            href='<%#(Eval("Fabric2Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID   +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))              +"&fabric="+Server.UrlEncode(Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) +"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric2Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&CCGSM11="+Server.UrlEncode(Eval("CCGSM2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&fabric="+Server.UrlEncode(Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric2Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                             <%# Eval("Fabric2")%></a>
                          <%--   <%# Eval("Fabric2")%>--%>
                        </span>
                    
                    <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric2Details")%></label>
                        
                        <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%
                            )
                        </label></nobr>
                            <nobr>
                            <br /><asp:Label Height="100px" ID="lblFabric112" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM2")%>'></asp:Label><br />
                        <span>
                            <a target="FabricApprovalsForm" 
                            href='<%#(Eval("Fabric3Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID          +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                                        +"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID             +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))               +"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")                              +"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric3")%></a>
                           <%-- <%# Eval("Fabric3")%>--%>
                        </span>
                    
                    <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric3Details")%></label>
                        
                        <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%
                            )
                        </label></nobr>
                            <nobr>
                            <br /><asp:Label Height="100px" ID="lblFabric113" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM3")%>'></asp:Label><br />
                         <span>
                            <a target="FabricApprovalsForm" 
                            href='<%#(Eval("Fabric4Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID               +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                             +"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID          +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                     +"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")                       +"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric4")%></a>
                            <%--<%# Eval("Fabric4")%>--%>
                        </span>
                    
                    <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric4Details")%></label>
                        <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>%
                            )
                        </label></nobr>
                        </span>
                    </div>
                    <br /><asp:Label Height="100px" ID="lblFabric114" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM4")%>'></asp:Label><br />
                    <span>
                        <img title="CLICK TO SEE FABRIC POPUP" src="/App_Themes/ikandi/images/view_icon.png"
                            border="0" onclick="showFabricPopup('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderDetailID") %>','<%# Eval("OrderID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric1Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>')" /></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sealer Tgt." SortExpression="" HeaderStyle-CssClass="vertical_header" 
                ItemStyle-CssClass="bold_text vertical_text date_style">
                <ItemTemplate>
                    <div>
                        <%# (Convert.ToDateTime(Eval("SealETA")) == DateTime.MinValue) ? "" : Eval("SealETA", "{0:dd MMM yy (ddd)}")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fit Status" HeaderStyle-Width="200px" ItemStyle-Width="200px"
                ItemStyle-CssClass="  remarks_text2 vertical_top">
                <ItemTemplate>
                    <table class="item_list vertical_top" style="vertical-align: top ! important; text-align: top;
                            padding-top: 0px ! important; align: top;">
                            <tr>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblMon" runat="server" CssClass="" Text="Mon"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblTue" runat="server" CssClass="" Text="Tue"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblWed" runat="server" CssClass="" Text="Wed"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblThu" runat="server" CssClass="" Text="Thu"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblFri" runat="server" CssClass="" Text="Fri"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    <asp:Label ID="lblFitsStatus" Width="180px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" SortExpression="ModeName" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span title='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'>
                        <%# Eval("ModeName")%></span>
                    <asp:Label ID="lblMode" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="date_style vertical_text bold_text">
                <ItemTemplate>
                    <asp:Label ID="lblEx" runat="server" Text=' <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : Eval("ExFactory", "{0:dd MMM yy (ddd)}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Sealer Remarks BIPL" SortExpression="SealerRemarksBIPL"
                HeaderStyle-Width="250px" ItemStyle-Width="250px" ItemStyle-CssClass="remarks_text remarks_text2">
                <ItemTemplate>
                    <div style="width: 250px ! important;">
                        <asp:Label ID="Label1" runat="server" Text='<%# (Eval("SealerRemarksBIPL").ToString().IndexOf("$$") > -1) ? Eval("SealerRemarksBIPL").ToString().Substring(Eval("SealerRemarksBIPL").ToString().LastIndexOf("$$") + 2) : Eval("SealerRemarksBIPL").ToString() %>'></asp:Label>
                    </div>
                    <br />
                    <img alt="Sealer Remarks BIPL" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentID %>','<%# (Eval("SealerRemarksBIPL").ToString().IndexOf("$$") > -1) ? Eval("SealerRemarksBIPL").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("SealerRemarksBIPL").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") %>','SealerRemarksBIPL','SEALERS_PENDING','<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_BIPL)? 1 : 0 %>')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SealerRemarks iKandi" SortExpression="SealerRemarksiKandi"
                HeaderStyle-Width="250px" ItemStyle-Width="250px" ItemStyle-CssClass="remarks_text remarks_text2">
                <ItemTemplate>
                    <div style="width: 250px ! important;">
                        <asp:Label ID="Label2" runat="server" Text='<%# (Eval("SealerRemarksiKandi").ToString().IndexOf("$$") > -1) ? Eval("SealerRemarksiKandi").ToString().Substring(Eval("SealerRemarksiKandi").ToString().LastIndexOf("$$") + 2) : Eval("SealerRemarksiKandi").ToString().ToString() %>'></asp:Label>
                    </div>
                    <br />
                    <img alt="Sealer Remarks iKandi" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentID %>','<%# (Eval("SealerRemarksiKandi").ToString().IndexOf("$$") > -1) ? Eval("SealerRemarksiKandi").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("SealerRemarksiKandi").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") %>','SealerRemarksiKandi','SEALERS_PENDING','<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_IKANDI)? 1 : 0 %>')" />
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
