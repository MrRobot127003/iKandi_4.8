<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frm_pending_cost_confirmation.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.frm_pending_cost_confirmation" %>

<body>
<style type="text/css">
 .gridpadding .header4, .gridpadding .header4  td,.gridpadding .header5 ,.gridpadding .header5 td{
    background: #405D99;
    font-weight: bold;
    color: #fff;
    font-family: arial, halvetica;
    font-size: 10px;
    padding: 0px 0px;
    border-color: #BFBFBF;
    
 }
 .frmPOUPload td
 {
     color:#000 !important;
  }
 </style>
 <asp:GridView ID="grdfrmpendingcostconfirmation" runat="server"  CssClass="gridpadding" AutoGenerateColumns="false" ShowHeader="false"  OnRowDataBound="grdfrmpendingcostconfirmation_RowDataBound">
 </asp:GridView>
 </body> 