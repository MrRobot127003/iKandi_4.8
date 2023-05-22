<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmPoUploadPendingBreakDown.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.frmPoUploadPendingBreakDown" %>
<body>
<style type="text/css">
 .gridpadding .header4, .gridpadding .header4  td,.gridpadding .header5 ,.gridpadding .header5, .gridpadding .header6, .gridpadding .header6 td{
    background: #405D99;
    font-weight: bold;
    color: #fff;
    font-family: arial, halvetica;
    font-size: 10px;
    padding: 0px 0px;
    border-color: #BFBFBF;
    
 }
 
 
</style>
 <asp:GridView ID="grdPoUploadPendingBreakDown" runat="server" CssClass="gridpadding" 
       AutoGenerateColumns="false"  onrowdatabound="grdPoUploadPendingBreakDown_RowDataBound" ShowHeader="false">
</asp:GridView>
</body>