<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartnerRegistrationList.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.PartnerRegistrationList" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="print-box">

         <h2  class="header-text-back">Partner Registration List</h2>
     
    <asp:GridView runat="server" AutoGenerateColumns="False" 
    AllowPaging="True"  CssClass="item_list" Width="100%"
    PageSize="10" ID="grdPartnerRegistration" 
    DataSourceID="odsPartnerRegistration" 
    onselectedindexchanged="grdPartnerRegistration_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="PartnerName" HeaderText="Official Partner Name" 
                SortExpression="PartnerName" ItemStyle-CssClass="da_table_tr_bg" />
                <asp:BoundField DataField="PartnerCode" HeaderText="Partner Code" 
                SortExpression="PartnerCode" ItemStyle-CssClass="da_table_tr_bg"  />
            <asp:BoundField DataField="Website" HeaderText="Website" 
                SortExpression="Website" ItemStyle-CssClass="da_table_tr_bg"  />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" ItemStyle-CssClass="da_table_tr_bg"  />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-CssClass="da_table_tr_bg"  />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" ItemStyle-CssClass="da_table_tr_bg"  />
                <asp:TemplateField HeaderText="Delivery Mode" SortExpression="DeliveryMode" ItemStyle-CssClass="da_table_tr_bg" >
	                <ItemTemplate>
                       <asp:Label ID="lblDeliveryMode" runat="server" Text='<%# Eval("DeliveryMode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Partner Type" SortExpression="PartnerType" ItemStyle-CssClass="da_table_tr_bg" >
	                <ItemTemplate>
                       <%--<asp:Label ID="lblPartnerType" runat="server" Text='<%# Eval("PartnerType") %>'></asp:Label>--%>
                       
<%# ((iKandi.Common.PartnerType)Convert.ToInt32(Eval("PartnerType")) == iKandi.Common.PartnerType.UNKNOWN) ? "" : ((iKandi.Common.PartnerType)Convert.ToInt32(Eval("PartnerType"))).ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
	            <ItemTemplate>
	            <asp:Label ID="lblPartnerID" runat="server" Text='<%# Bind("PartnerID") %>' Visible="false"></asp:Label>
		        <asp:HyperLink ID="editPartner" runat="server" 
               NavigateUrl='<%# Eval("PartnerID", "~/Internal/Users/PartnerRegistrationForm.aspx?PartnerID={0}") %>'
               Text="Edit" CssClass="da_edit_delete_link">
          </asp:HyperLink>
	    </ItemTemplate>
    </asp:TemplateField>     
       
        </Columns>
    </asp:GridView>
    </div>
   <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="da_submit_button" PostBackUrl="~/Internal/Users/PartnerRegistrationForm.aspx"></asp:Button>
     <input type="button" id="btnPrint" class="da_submit_button" value="Print" onclick="return PrintPDF();" />
<asp:ObjectDataSource ID="odsPartnerRegistration" runat="server" 
    TypeName="iKandi.BLL.PartnerController" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllPartner">
</asp:ObjectDataSource>