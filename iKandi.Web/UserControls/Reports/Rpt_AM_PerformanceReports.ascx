<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rpt_AM_PerformanceReports.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.Rpt_AM_PerformanceReports" %>
    <style>
   
     .Report_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .Report_Table th
        {
            background: #405D99 !important;
            border-color: #bfbfbf;
            color: #ffffff !important;
            font-weight: normal;
            font-size: 10px;
            padding: 2px 0px !important;
            font-family: arial, halvetica;
            text-transform: capitalize;
              border: 1px solid #999;
        }
        .Report_Table td
        {
            
            text-align: center;
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
              border: 1px solid #999;
        }
    .total
    {
        background: #FFF0A5;
        font-weight:600;
    }
    .total_prv_financial_year
    {
        font-weight:600;
        color:Gray;
    }
        
    .firstCol
    {
        color: Gray;
    }
    .priviousyear
    {
        background: #f3f3f3;
        color: Gray;
    }
    .green
    {
        background: green;
        color:Yellow;
    }
   .red
    {
        background:red;
        color:Yellow;
    }
    .previousTotal
    {
        font-weight:600;
      }
</style>

<div id="AM_Performance_Report" runat="server">
</div>
<br />
<br />
<table border='0' style="width:1100px">
<div id="ScoretableVal" runat="server"></div>

</table>
