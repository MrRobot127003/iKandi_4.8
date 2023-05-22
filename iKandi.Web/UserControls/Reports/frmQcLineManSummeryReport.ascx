<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmQcLineManSummeryReport.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.frmQcLineManSummeryReport" %>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .grdproc td
    {
        padding: 0px 0px !important;
        border-color: gray;
    }
    .grdproc th
    {
        font-size: 9px;
        padding: 0px 0px !important;
        height: 16px;
    }
    .f-16px
    {
        font-size: 12px !important;
    }
    .f-14px
    {
        font-size: 12px !important;
    }
    
    .TotalCQDFUHo
    {
        position: relative;
        display: inline-block;
    }
    
    .TotalCQDFUHo .tooltiptext
    {
        visibility: hidden;
        width: 98px;
        background-color: #565454;
        color: #fff;
        text-align: center;
        border-radius: 6px;
        padding: 3px 0;
        position: absolute;
        z-index: 1;
        top: 100%;
        left: 59%;
        margin-left: -60px;
        line-height: 13px;
        font-size: 12px;
    }
    
    .TotalCQDFUHo .tooltiptext::after
    {
        content: "";
        position: absolute;
        bottom: 100%;
        left: 50%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent #565454 transparent;
    }
    
    .TotalCQDFUHo:hover .tooltiptext
    {
        visibility: visible;
        text-align: left;
        padding-left: 8px;
    }
    /*  table.frmlineqctable tr td table tr th
    {
          background:#dddfe4 !important;
          padding:2px 0px !important;
      } 
     table.frmlineqctable tr td table.grdproc tr td
    {
        border-left:1px solid #999 !important;
      }
       table.frmlineqctable tr td table.grdproc tr th
    {
        border-right:1px solid #999 !important;
      }
      table.frmlineqctable table td
      {
          font-size:11px !important;
        }*/
    ul
    {
        margin: 5px 0px;
        padding-left: 18px;
    }
    li
    {
        font-size: 9px;
        color: #545454;
        line-height: 15px;
    }
</style>
<table cellpadding="0" cellspacing="0" border="0" style="max-width: 1640px;margin-left:20px;" class="frmlineqctable">
    <tr>
        <td style="max-width: 840px; vertical-align: top;">
            <div runat="server" id="frmQCsummeryReport">
            </div>
        </td>
        <td style="width: 20px;">
            &nbsp;
        </td>
      
    </tr>
    <tr>
        <td colspan="2">
            <ul style='margin-top: 20px'>
                <li><b>Note: </b><span>Following figures are used to calculate scores</span>
                    <ul>
                        <li>Actual quality Audit (Weight 20%)</li>
                        <li>Rescan  (Weight 80%)</li>
                        <li>Actual Pcs. Handled
                            <ul>
                                <li>For OH-QC 10% of the Output</li>
                                <li>Roaming QC-> All Associated Lines Avg. Rescan & Avg. Pcs. Handled are in use to
                                    calculate score
                             
                                 <li>If today date is not end of month date <b>Actual Pcs=(Total Pcs*25.25/total days till today)</b></li>
                      
                                 <li>   today date is equals to end of month date <b>Actual Pcs=Total Pcs</b> </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </td>
    </tr>
</table>
