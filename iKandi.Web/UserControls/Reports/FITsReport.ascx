<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FITsReport.ascx.cs"
    Inherits="iKandi.Web.FITsReport" %>
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

function ShowFitsPopup(StyleNumber,DepartmentID,OrderDetailID)
  {
   proxy.invoke("ManageOrderFitsInfoPopup", {StyleNumber:StyleNumber,DepartmentID:DepartmentID,OrderDetailID:OrderDetailID}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }

</script>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            FITs PENDING REPORT
        </div>
        <div>
            <table width="850px" cellspacing="10">
                <tr>
                    <td>
                        Buyer :
                        <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hiddenClientId" runat="server" Value="-1" />
                    </td>
                    <td>
                        Department :
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
                    </td>
                    <td>
                      Suggested Fits Date :
                        <asp:TextBox ID="txtSuggestedFitsDate" runat="server" CssClass="date-picker date_style do-not-disable"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hdnSuggestedFitsDate" Value="01/01/0001 12:00:00" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_box">
        <asp:GridView ID="grdFITs" runat="server" CssClass="item_list1 fixed-header" AutoGenerateColumns="false"
            OnRowDataBound="grdFITs_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuyer" Text='<%# Eval("Buyer") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header "
                    ItemStyle-CssClass="vertical_text quantity_style">
                    <ItemTemplate>
                        <span>
                            <asp:HiddenField ID="hdnSerial" runat="server" />
                            <%# Eval("SerialNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text ">
                    <ItemTemplate>
                        <span>
                            <%# Eval("DepartmentName")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style No.">
                    <ItemTemplate>
                        <span>
                        <nobr>
                            <%# Eval("StyleNumber")%>
                        </nobr>
                        </span>
                        <br />
                        <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# Eval("StyleId")+",-1,"+Eval("OrderDetailID")%>)'>
                            <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                                src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <span>
                            <%# Eval("LineItemNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <span>
                            <%# Eval("ContractNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Desc" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDescription" Height="100px" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="QTY" SortExpression="Quantity" ItemStyle-CssClass="numeric_text quantity_style"
                    HeaderStyle-Width="60px" ItemStyle-Width="60px" />
                <asp:TemplateField HeaderText="Fabric/Details" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <span>
                            <%# Eval("Fabric1")%><asp:Label ID="lblFabric1Details" runat="server"></asp:Label>
                            <br />
                            <%# Eval("Fabric2")%><asp:Label ID="lblFabric2Details" runat="server"></asp:Label>
                            <br />
                            <%# Eval("Fabric3")%><asp:Label ID="lblFabric3Details" runat="server"></asp:Label>
                            <br />
                            <%# Eval("Fabric4")%><asp:Label ID="lblFabric4Details" runat="server"></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                    Visible="false">
                    <ItemTemplate>                        
                        <span title='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'>
                            <%# iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(Eval("Mode")))%></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style bold_text" Visible="false">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="lblEx" Value='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                        <div>
                            <%# (Convert.ToDateTime((Eval("ExFactory"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("ExFactory"))).ToString("dd MMM yy (ddd)"))%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STC Target" ItemStyle-CssClass="date_style bold_text"
                    HeaderStyle-Width="100px" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="lblSTC" Width="100px" runat="server" Text='<%# (Convert.ToDateTime((Eval("SealETA"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("SealETA"))).ToString("dd MMM yy (ddd)"))%>'
                            Style="width: 120px ! important;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FITs Status" HeaderStyle-Width="180px" ItemStyle-Width="180px"
                    ItemStyle-CssClass="remarks_text2">
                    <ItemTemplate>
                        <div>
                            <asp:Label Width="180px" CssClass="" ID="lblFitStatus" runat="server"></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Next Planned FIT Date" ItemStyle-CssClass="date_style quantity_style"
                    HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <%# (Eval("NextPlannedDate") == DBNull.Value ||  Convert.ToDateTime((Eval("NextPlannedDate"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("NextPlannedDate"))).ToString("dd MMM yy (ddd)"))%>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="FITS Specs">
                    <ItemTemplate>
                        <div>
                            <asp:HyperLink ID="hlkViewMeSpecs" runat="server" NavigateUrl='<%# ResolveUrl("~/uploads/fits/" + Eval("FilePath").ToString())%>'
                                Visible='<%#  Eval("FilePath").ToString().Length >0 ? Convert.ToBoolean(true) : Convert.ToBoolean(false) %>'
                                Target="_blank" Text="View File"></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sealer Remarks BIPL" ItemStyle-CssClass="remarks_text remarks_text2"
                    HeaderStyle-Width="300px" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblRemarksBIPL" Width="300px" runat="server" Text='<%# Eval("RemarksBIPL").ToString().Replace("$$", "<br />") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sealer Remarks iKandi" ItemStyle-CssClass="remarks_text remarks_text2"
                    HeaderStyle-Width="300px" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblRemarksIkandi" Width="300px" runat="server" Text='<%# Eval("RemarksIKANDI").ToString().Replace("$$", "<br />") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No records Found</label></EmptyDataTemplate>
        </asp:GridView>
        <div style="margin-top: 5px; text-align: right;">
            <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
            </cc1:HyperLinkPager>
        </div>
    </div>
</div>
