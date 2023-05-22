<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricApprovalPendingReport.ascx.cs"
    Inherits="iKandi.Web.FabricApprovalPendingReport" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
 <script type="text/javascript">

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);
var BuyerDDClientID = '<%=ddlClients.ClientID%>' ;
var DeptDDClientID = '<%=ddlDepartment.ClientID%>' ;
var jscriptPageVariables = null;
var selectedDept;
var hdnDeptIdClientID = '<%=hiddenDeptId.ClientID %>';

$(function () {
// added by yaten
    $(".loadingimage").hide();
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


// added by yaten
function PrintPDFFabricApprovalPendingReport(Url, height, width) {
    //$.showprogress();
    $(".loadingimage").show();
    $(".print").hide();
    var url;
    var ht = parseInt($(document).height()) - 130;
    var wd = parseInt($(document).width()) - 100;

    if (height != '' && height != null) {
        ht = height;
    }
    if (width != '' && width != null) {
        wd = width;
    }

    if (Url == '' || Url == null) {
        url = window.location.pathname;
    }
    else {
        url = Url;
    }

    if (url.indexOf('/') != 0)
        url = '/' + url;
    //   debugger;
    //alert(wd + " - " + ht);
    proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {

        if ($.trim(result) == '') {
            //$.hideprogress();
            jQuery.facebox("Some error occured on the server, please try again later.");
        }
        else {
            //$.hideprogress();
            window.open(result);
            $(".loadingimage").hide();
            $(".print").show();
        }
    });

    return false;
}



</script>


<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Fabric Approval Pending Report
        </div>
        <div>
            <table width="1050px" cellspacing="10">
                <tr>
                    <td>Buyer :
                        <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenClientId" Value="-1" />
                    </td>
                    <td>Department :
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
                    </td>
                    <td>
                        <asp:RadioButtonList ID="radioStage" runat="server" CssClass="do-not-disable" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Both" Selected="true" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Lab/Dip Strike Off" Selected="false" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Bulk" Selected="false" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:HiddenField runat="server" ID="hiddenStage" Value="-1" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_box">
        <asp:GridView CssClass=" fixed-header item_list1" ID="grdApprovals" runat="server"
            AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdApprovals_RowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <span>
                            <%# Eval("CompanyName")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <span>
                            <%# Eval("DepartmentName")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order Dt." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                        <span>
                             <%# (Convert.ToDateTime((Eval("OrderDate"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("OrderDate"))).ToString("dd MMM yy (ddd)"))%>
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
                <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                    <ItemTemplate>
                        <span>
                            <asp:HiddenField ID="hdnSerial" runat="server" />
                            <%# Eval("SerialNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" >
                    <ItemTemplate>
                        <span>
                            <%# Eval("LineItemNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" >
                    <ItemTemplate>
                        <span>
                            <%# Eval("ContractNumber")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Desc" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" >
                    <ItemTemplate>
                        <span>
                            <asp:Label ID="lblDiscription" runat="server" Height="100px"  Text='<%# Eval("Description") %>'></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Fabric">
                    <ItemTemplate>
                        <span>
                            <%# Eval("FabricName") %><asp:Label ID="lblFabricDetails" runat="server" ></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="L.D/S.O Approval Target" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <span>
                            <%# (Convert.ToDateTime((Eval("LabDipTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("LabDipTarget"))).ToString("dd MMM yy (ddd)"))%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bulk Approval Target" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <span>
                            <%# (Convert.ToDateTime((Eval("BulkApprovalTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("BulkApprovalTarget"))).ToString("dd MMM yy (ddd)"))%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chasing For">
                    <ItemTemplate>
                        <span>
                           <%# Eval("Stage") == DBNull.Value ? string.Empty : ((Convert.ToInt32(Eval("Stage")) == 1) ? "Lab Dip/Strike Off Approval" : "Bulk Approval")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="numeric_text quantity_style" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                    <ItemTemplate>
                        <span>
                            <%# Eval("Quantity")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AWB">
                    <ItemTemplate>
                        <span>
                          <asp:HyperLink ID="hlkAwb" Target="_blank" runat="server"><%# Eval("DHLNumber") %></asp:HyperLink>
                            
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dispatch Date"  ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblSent" Text='<%# ((Eval("SentDate") == DBNull.Value) ||((Convert.ToDateTime(Eval("SentDate")) == DateTime.MinValue))) ? "" : (Convert.ToDateTime(Eval("SentDate"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Sealer ETA"  ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                           <%# (Convert.ToDateTime(Eval("SealETA")) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("SealETA"))).ToString("dd MMM yy (ddd)"))%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
                <%--<asp:TemplateField HeaderText="Bulk In House Target" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <span>
                            <%# (Convert.ToDateTime((Eval("BulkTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("BulkTarget"))).ToString("dd MMM yy (ddd)"))%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Remarks" ItemStyle-CssClass="remarks_text remarks_text2" HeaderStyle-Width="300px" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <span>
                            <%# Eval("Remarks") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric Approval Form">
                    <ItemTemplate>
                        <span>
                         <span>
                           <asp:HyperLink title="CLICK TO VIEW APPROVALS FORM" target="FabricApprovalsForm" runat="server" id="hlkApprovals">
                           <img title="CLICK TO GO TO APPROVALS FORM" src="/App_Themes/ikandi/images/view_icon.png" border="0" />
                           </asp:HyperLink>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        
                             <asp:HiddenField ID="hdnStatus" runat="server" />
                            <%# Eval("StatusMode")%>
                        
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
</div>
 <%--added by yaten--%>
 <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" meta:resourcekey="LoadImgResource1" />
<input type="button" id="btnPrint" class="print"  
onclick="return PrintPDFFabricApprovalPendingReport((('<%= hiddenClientId.Value%>' == -1)&&('<%= hiddenDeptId.Value%>' == -1)&&('<%= hiddenStage.Value%>' == -1)) ? '' : '/Internal/Reports/FabricApprovalPending.aspx?clientid='+'<%= hiddenClientId.Value%>'+'&deptId='+'<%= hiddenDeptId.Value%>'+'&stage='+'<%= hiddenStage.Value%>');" />
