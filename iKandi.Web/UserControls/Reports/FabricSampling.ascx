<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricSampling.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.FabricSampling" %>
<div class="print-box">
<div class="form_box">
        <div class="form_heading">
            Fabric Sampling Report 
        </div>
            <div>
            Search:
            <asp:TextBox runat="server" ID="txtSearchText" CssClass="do-not-disable"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="do-not-disable go"/>
        </div>
    </div>
     <div class="form_box">
     <asp:GridView runat="server" ID="grdFabricSampling" CssClass="item_list fixed-header" AutoGenerateColumns="false" >
     <Columns>
     <asp:TemplateField HeaderText="PRINT/DESIGN NUMBER/LAB DIPS">
     <ItemTemplate>
         <asp:Label ID="Label1" runat="server" Text='<% # Eval("PrintNumber") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label2" runat="server" Text='<% # Eval("ClientName") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Designer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label3" runat="server" Text='<% # Eval("DesignerFirstName") %>'></asp:Label>
         <asp:Label ID="Label31" runat="server" Text='<% # Eval("DesignerLastName") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Merchant" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label4" runat="server" Text='<% # Eval("SampleMerchantFirstName") %>'></asp:Label>
          <asp:Label ID="Label41" runat="server" Text='<% # Eval("SampleMerchantLastName") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
      <asp:TemplateField HeaderText="Mill Name" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label5" runat="server" Text='<% # Eval("MillName") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Mill Design<br/> Number" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label51" runat="server" Text='<% # Eval("MillDesignNumber") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Fabric">
     <ItemTemplate>
         <asp:Label ID="Label6" runat="server" Text='<% # Eval("Fabric") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Print Type" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label7" runat="server" Text='<% # Eval("printType") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="TECHNIQUE <br/> OF PRINT" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label8" runat="server" Text='<% # Eval("PrintTechnology") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="QTY (MTRS.)<br/> ORDERED" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" numeric_text vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label9" runat="server" Text='<% # Eval("QuantityOrdered") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="QTY (MTRS.)<br/> RECEIVED" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" numeric_text vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label9" runat="server" Text='<% # Eval("QuantityReceived") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Origin" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label10" runat="server" Text='<% # Eval("Origin") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="OLD/NEW" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
     <ItemTemplate>
         <asp:Label ID="Label11" runat="server" Text='<% # Eval("IsNew") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="NO. OF COLS/ SCREENS" ItemStyle-CssClass="numeric_text">
     <ItemTemplate>
         <asp:Label ID="Label12" runat="server" Text='<% # Eval("NumberOfScreens") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
        <asp:TemplateField HeaderText="COST PER SCREEN" ItemStyle-CssClass="numeric_text">
     <ItemTemplate>
         <asp:Label ID="Label13" runat="server" Text='<% # Eval("CostPerScreen") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
 <%--       <asp:TemplateField HeaderText="TOTAL AMOUNT">
     <ItemTemplate>
         <asp:Label ID="Label14" runat="server" Text='<% # Eval("TotalAmount") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text remarks_text remarks_text2">
     <ItemTemplate>
         <asp:Label ID="Label15" runat="server" Text='<% # Eval("Remarks") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>
        <asp:TemplateField HeaderText="DATE OF<br/> RECEIVING" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
     <ItemTemplate>
        <%--<asp:Label ID="Label14" CssClass="date_style" runat="server" Text='<% # Eval("DateOfReceiving") %>'></asp:Label>--%> 
        <asp:Label ID="Label14" CssClass="date_style" runat="server" Text='<%# (((Eval("DateOfReceiving")) == DBNull.Value)||(Convert.ToDateTime(Eval("DateOfReceiving")) == DateTime.MinValue)) ? "" : (Convert.ToDateTime( Eval("DateOfReceiving")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
        <asp:TemplateField HeaderText="EXPECTED <br/>ISSUE DATE" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
     <ItemTemplate>
         <%--<asp:Label ID="Label17" runat="server" Text='<% # Eval("ExpectedIssueDate") %>'></asp:Label>--%>
         <asp:Label ID="Label17" CssClass="date_style" runat="server" Text='<%# (((Eval("ExpectedIssueDate")) == DBNull.Value)||(Convert.ToDateTime(Eval("ExpectedIssueDate")) == DateTime.MinValue)) ? "" : (Convert.ToDateTime( Eval("ExpectedIssueDate")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>    
     </ItemTemplate>
         
     </asp:TemplateField>
        <asp:TemplateField HeaderText="ACTUAL ISSUE DATE" ItemStyle-CssClass="date_style">
     <ItemTemplate>
         <%--<asp:Label ID="Label18" runat="server" Text='<% # Eval("ActualIssueDate") %>'></asp:Label>--%>
         <asp:Label Width="100px" ID="Label18" CssClass="date_style" runat="server" Text='<%# (((Eval("ActualIssueDate")) == DBNull.Value)||(Convert.ToDateTime(Eval("ActualIssueDate")) == DateTime.MinValue)) ? "" : (Convert.ToDateTime( Eval("ActualIssueDate")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="STATUS ISSUING">
     <ItemTemplate>
         <asp:Label ID="Label19" runat="server" Text='<% # Eval("StatusIssuing") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="EXPECTED<br/>RECIEPT DATE" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
     <ItemTemplate>
         <%--<asp:Label ID="Label20" runat="server" Text='<% # Eval("ExpectedReceiptDate") %>'></asp:Label>--%>
         <asp:Label ID="Label18" CssClass="date_style" runat="server" Text='<%# (((Eval("ExpectedReceiptDate")) == DBNull.Value)||(Convert.ToDateTime(Eval("ExpectedReceiptDate")) == DateTime.MinValue)) ? "" : (Convert.ToDateTime( Eval("ExpectedReceiptDate")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
        <asp:TemplateField HeaderText="ACTUAL RECIEPT DATE" ItemStyle-CssClass="date_style">
     <ItemTemplate>
         <%--<asp:Label ID="Label21" runat="server" Text='<% # Eval("ActualReceiptDate") %>'></asp:Label>--%>
         <asp:Label Width="100px" ID="Label21" CssClass=date_style" runat="server" Text='<%# (((Eval("ActualReceiptDate")) == DBNull.Value)||(Convert.ToDateTime(Eval("ActualReceiptDate")) == DateTime.MinValue)) ? "" : (Convert.ToDateTime( Eval("ActualReceiptDate")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
      <%--  <asp:TemplateField HeaderText="STATUS RECEIVING">
     <ItemTemplate>
         <asp:Label ID="Label22" runat="server" Text='<% # Eval("StatusReceving") %>'></asp:Label></ItemTemplate>
     </asp:TemplateField>--%>
       </Columns>
       <EmptyDataTemplate><label>NO RECORD FOUND</label></EmptyDataTemplate>
     </asp:GridView>
     </div>
     </div>
     
     <%-- <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
