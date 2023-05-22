<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SamplingStatus.ascx.cs"
    Inherits="iKandi.Web.SamplingStatusReport" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);

var companyDDClientID = '<%=ddlClients.ClientID %>' ;
var styleDDClientID = '<%=ddlStyles.ClientID %>' ;
var jscriptPageVariables = null;

$(function()
 {
    $("#"+companyDDClientID).change(function(){
        
        OnCompanyChange();

    });  
    
    OnCompanyChange();  
 });
 
 function OnCompanyChange()
 {
        var clientId = $("#"+companyDDClientID).val();
        
        if(clientId != -1 && clientId != '-1')
        {
            //alert(clientId);
            bindDropdown(serviceUrl,styleDDClientID, "GetClientStyles", {ClientID:clientId},  "StyleNumber", "StyleID", true, ( jscriptPageVariables != null) ? jscriptPageVariables.currentStyleID : '-1', onPageError )        
        }
 
 }
 
 function onPageError(error)
{
  alert(error.Message + ' -- ' +error.detail);
}


</script>


<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Sampling Status Report
        </div>
        <div>
            Client:
            <asp:DropDownList runat="server" ID="ddlClients" AppendDataBoundItems="true" CssClass="do-not-disable">
                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
            </asp:DropDownList>
            Style:
            <asp:DropDownList runat="server" ID="ddlStyles" AppendDataBoundItems="true" CssClass="do-not-disable">
                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
            </asp:DropDownList>
            From Date:
            <asp:TextBox runat="server" ID="txtFromDate" CssClass="date-picker date_style do-not-disable"></asp:TextBox>
            To Date:
            <asp:TextBox runat="server" ID="txtToDate" CssClass="date-picker date_style do-not-disable"></asp:TextBox>
            Search:
            <asp:TextBox runat="server" ID="txtSearchText" CssClass="do-not-disable"></asp:TextBox>
            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
        </div>
    </div>
    <div class="form_box">
        <asp:GridView runat="server" ID="grdSamplingStatus" CssClass="item_list fixed-header" AutoGenerateColumns="false"
          OnRowDataBound="grdSamplingStatus_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Style">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#  Eval("StyleNumber")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Factory Name">
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%#  Eval("FactoryName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assigned To">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#  Eval("SamplingFirstName")%>'></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%#  Eval("SamplingLastName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Buyer">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#  Eval("Buyer")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric">
                    <ItemTemplate>
                        <asp:Label ID="LabelFabric" runat="server" Text='<%#  Eval("Fabric")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Issued On" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label6" runat="server" Text='<%#  Eval("IssuedOn", "{0:dd MMM yy (ddd)}" )%>'></asp:Label>--%>
                        <asp:Label ID="Label6" runat="server" Text='<%#  (Convert.ToDateTime((Eval("IssuedOn") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("IssuedOn")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("IssuedOn"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Expected Date (ETA)" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label7" runat="server" Text='<%#  Eval("ETA")%>'></asp:Label>--%>
                        <asp:Label ID="Label7" runat="server" Text='<%#  (Convert.ToDateTime((Eval("ETA") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("ETA")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ETA"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Expected Dispatch Date (ETD)" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label8" runat="server" Text='<%#  Eval("MerchandiserDispatchDate", "{0:dd MMM yy (ddd)}")%>'></asp:Label>--%>
                        <asp:Label ID="Label8" runat="server" Text='<%# (Convert.ToDateTime((Eval("MerchandiserDispatchDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("MerchandiserDispatchDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("MerchandiserDispatchDate"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Couriered On" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label9" runat="server" Text='<%#  Eval("SentToiKandiOn", "{0:dd MMM yy (ddd)}")%>'></asp:Label>--%>
                        
                       <%--<%# (Convert.ToDateTime((Eval("SentToiKandiOn") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("SentToiKandiOn")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("SentToiKandiOn"))).ToString("dd MMM yy (ddd)")%>--%>
                         <asp:Label ID="Label9" runat="server" Text='<%# (Convert.ToDateTime((Eval("SentToiKandiOn") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("SentToiKandiOn")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("SentToiKandiOn"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                         
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Counter Complete">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%#  Eval("CounterComplete")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblPriority" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%#  Eval("SamplingStatusRemarks")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                       <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%#  Eval("Status")%>'></asp:Label>
                    </ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate><label>NO RECORD FOUND</label></EmptyDataTemplate>
        </asp:GridView>
         <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    </div>
</div>
 <div class="form_buttom">
<%-- <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
</div>