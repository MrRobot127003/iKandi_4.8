<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmonhold.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.frmonhold1" %>

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
 <asp:GridView ID="grdfrmonhold" runat="server"  CssClass="gridpadding"  AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grdfrmonhold_RowDataBound">
 </asp:GridView>
 </body>   