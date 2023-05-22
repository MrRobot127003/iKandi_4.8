<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Master_Monthly_Performance_Report.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.Master_Monthly_Performance_Report" %>

 <style type="text/css">
     .fontsize{
             font-size: 12px !important;
             color:#fff;
         }
        .InternalAdminTable{
            border:1px solid #999;
            border-collapse:collapse;
            font-family: Arial, Helvetica, sans-serif
        }
        .InternalAdminTable th{
            background: #39589c;
            border:1px solid #999;
            border-collapse:collapse;
            font-size: 11px;
            font-weight: 500;
            padding:3px 0px;
            color: #e7e4fb;
            font-family: Arial;
            min-width: 66px;
            height: 12px;
        }
        .InternalAdminTable td{
            border:1px solid #999;
            font-size: 10px;
            padding:3px 3px;
            color: #272626;
            height: 12px;
            font-family: Arial;
            height: 12px;
            text-align: center !important;
        } 
        .InternalAdminTable td:first-child{
           text-align: left;
        }
        .fontweightblod{
           font-weight: 600;
           text-align: left
        }
        
        .textcolorGray{
         color:gray !important;
         /* float: right;*/
        }
        .totaltextColorBack{
           font-weight: 600;
           background: #fff0a5;
        }
        .colorRed{
           color:red !important;
           /*float: right;*/
        }
        .txtright{
         /*float: right;*/
        }
        .textLeft{
           text-align: left !important
        }
        .textcolorName
        {
            color:Gray !important;
         }
      </style>

    <div id="Master_MonthlyPerformance_Report" runat="server">  </div><br />
    <table border="0" cellpadding="0" cellspacing="0">
     <tr>
        <td>
         <div id="Tailor_MonthlyPerformance_Report" runat="server">  </div>
        </td>
        <td style="vertical-align: top;">
          <div id="TailorWip_Report" runat="server">  </div>

        </td>
     </tr>
    </table>
    
    
  