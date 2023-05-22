<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoBudget_Formulas.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MoBudget_Formulas" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="750px" align="center" style="font-family:Arial; background-color:#F7F7F7;">
      <tr>
        <td style="width:33%;"></td>
        <td align="center" style="width:34%;font-size:22px; font-weight:bold;">Formulas</td>
        <td align="right" style="width:33%; padding-right:10px; padding-bottom:2px;"><asp:LinkButton ID="lnkClose" runat="server" ToolTip="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" Font-Size="15px" CausesValidation="false"><img src="../../images/close-icon.png" /></asp:LinkButton></td>
      </tr>
    </table>
    <asp:Panel ID="pnlBudget" runat="server">
      <table border="1" cellpadding="0" cellspacing="0" width="750px" align="center" style="font-family:Arial; background-color:#F7F7F7;">
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 150px; font-size:16px; font-weight:bold; padding-left:5px;">Working Hours</td>
                <td style="width: 600px; font-size:12px; padding-left:5px;">Please see table below:<br /><br />
                  <table border="1" cellpadding="0" cellspacing="0" width="99%" align="center">
                    <tr>
                      <td></td>
                      <td align="left" style="padding-left:2px;">Normal Hours</td>
                      <td align="left" style="padding-left:2px;">OT1</td>
                      <td align="left" style="padding-left:2px;">OT2</td>
                      <td align="left" style="padding-left:2px;">OT3</td>
                      <td align="left" style="padding-left:2px;">OT4</td>
                    </tr>
                    <tr>
                      <td align="left" style="padding-left:2px;">No Of Hours</td>
                      <td align="left" style="padding-left:2px;">Fixed Hours</td>
                      <td align="left" style="padding-left:2px;">2</td>
                      <td align="left" style="padding-left:2px;">1</td>
                      <td align="left" style="padding-left:2px;">1</td>
                      <td align="left" style="padding-left:2px;">6</td>
                    </tr>
                    <tr>
                      <td align="left" style="padding-left:2px;">No Of Days</td>
                      <td align="left" style="padding-left:2px;"><span style="background-color:Yellow;">(((Working Days in a Month * 12) / 52) * No of Weeks Called for Budget)</span><br />Consider as <b>'A'</b></td>
                      <td align="left" style="padding-left:2px;">20</td>
                      <td align="left" style="padding-left:2px;">10</td>
                      <td align="left" style="padding-left:2px;">4</td>
                      <td align="left" style="padding-left:2px;">1</td>
                    </tr>
                  </table>
                  <br />So Formula to get Working Hours is:<br /><span style="padding-left:25px;"><b>Working Hrs = ((A * Fixed Hours) + (20 * 2) + (10 * 1) + (4 * 1) + (1 * 6)) / A</b></span>
                  <br />
                  <br />
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 150px; font-size:16px; font-weight:bold; padding-left:5px;">Budget Section</td>
                <td style="width: 600px; font-size:12px; padding-left:5px;">Please see table below:<br /><br />
                  <table border="1" cellpadding="0" cellspacing="0" width="99%" align="center">
                    <tr>
                      <td colspan="2"></td>
                      <td align="center" colspan="4" style="padding-left:2px;">Factory Name Consider as <b>'C-47'</b></td>
                    </tr>
                    <tr>
                      <td colspan="2"></td>
                      <td align="center" colspan="2" style="padding-left:2px;">Man Power</td>
                      <td align="center" colspan="2" style="padding-left:2px;">Cost</td>
                    </tr>
                    <tr>
                      <td align="center" style="padding-left:2px;"></td>
                      <td align="center" style="padding-left:2px;">Worker Type</td>
                      <td align="center" style="padding-left:2px;">Calc Count</td>
                      <td align="center" style="padding-left:2px;">Bud Count</td>
                      <td align="center" style="padding-left:2px;">Calc Cost</td>
                      <td align="center" style="padding-left:2px;">Bud Cost</td>
                    </tr>
                    <tr>
                      <td align="center" rowspan="2" style="padding-left:2px;">Cutting</td>
                      <td align="center" style="padding-left:2px;">Cutting Master</td>
                      <td align="center" style="padding-left:2px;">200</td>
                      <td align="center" style="padding-left:2px;">250</td>
                      <td align="center" style="padding-left:2px;"><b>CC (Lacs)</b></td>
                      <td align="center" style="padding-left:2px;"><b>BC (Lacs)</b></td>
                    </tr>
                    <tr>
                      <td align="center" style="padding-left:2px;">Cutting supervisor</td>
                      <td align="center" style="padding-left:2px;">100</td>
                      <td align="center" style="padding-left:2px;">50</td>
                      <td align="center" style="padding-left:2px;"><b>CC (Lacs)</b></td>
                      <td align="center" style="padding-left:2px;"><b>BC (Lacs)</b></td>
                    </tr>
                    <tr>
                      <td align="center" rowspan="3" style="padding-left:2px;">Stitching</td>
                      <td align="center" style="padding-left:2px;">Production Incharge</td>
                      <td align="center" style="padding-left:2px;">20</td>
                      <td align="center" style="padding-left:2px;">15</td>
                      <td align="center" style="padding-left:2px;"><b>CC (Lacs)</b></td>
                      <td align="center" style="padding-left:2px;"><b>BC (Lacs)</b></td>
                    </tr>
                    <tr>
                      <td align="center" style="padding-left:2px;">Lineman</td>
                      <td align="center" style="padding-left:2px;">100</td>
                      <td align="center" style="padding-left:2px;">125</td>
                      <td align="center" style="padding-left:2px;"><b>CC (Lacs)</b></td>
                      <td align="center" style="padding-left:2px;"><b>BC (Lacs)</b></td>
                    </tr>
                    <tr>
                      <td align="center" style="padding-left:2px;">Needle Supervisor</td>
                      <td align="center" style="padding-left:2px;">100</td>
                      <td align="center" style="padding-left:2px;">150</td>
                      <td align="center" style="padding-left:2px;"><b>CC (Lacs)</b></td>
                      <td align="center" style="padding-left:2px;"><b>BC (Lacs)</b></td>
                    </tr>
                    <tr>
                      <td align="center" colspan="2" style="padding-left:2px;">Budget Period Total</td>
                      <td align="center" colspan="2" style="padding-left:2px;">Total Count</td>
                      <td align="center" colspan="2" style="padding-left:2px;"><b>Total Cost (Cr)</b></td>
                    </tr>
                    <tr>
                      <td align="center" colspan="2" style="padding-left:2px;">Monthly Total</td>
                      <td align="center" colspan="4" style="padding-left:2px;">((Budget Period Total / Total No of Week in Budget) * 4)</td>
                    </tr>
                  </table>
                  <br />Formula to get <b>Calc Cost</b> is:<br /><span style="padding-left:25px;"><b>Calc Cost = Calc Count * ((Per Hr Normal wage * 8 * A) + (Per Hr OT1 * 2 * 20) + (Per Hr OT2 * 1 * 10) + (Per Hr OT3 * 1 * 4) + (Per Hr OT4 * 6 * 1))</b></span><br />
                  <br />Formula to get <b>Bud Cost</b> is:<br /><span style="padding-left:25px;"><b>Bud Cost = Bud Count * ((Per Hr Normal wage * 8 * A) + (Per Hr OT1 * 2 * 20) + (Per Hr OT2 * 1 * 10) + (Per Hr OT3 * 1 * 4) + (Per Hr OT4 * 6 * 1))</b></span><br />
                  <br />Formula to get <b>Overhead</b> is:<br /><span style="padding-left:25px;"><b>Overhead = (Monthly Overhead / Working Days in a Month) * No of Weeks Called for Budget * Working Days in a Week</b></span><br />
                  <br />Formula to get <b>Costed Production Cost</b> is:<br /><span style="padding-left:25px;"><b>Costed Production Cost = Sum of (Total Qty * CMTCosted)</b></span><br />
                  <br /><b>Note:</b>
                  <ul>
                    <li>Per Hr Normal Wage = ((Salary / Working Days in a Month) / 8)</li>
                    <li>Calc Count comes from existing data and Bud Count puts at the time of Budget Creation.</li>
                  </ul>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 150px; font-size:16px; font-weight:bold; padding-left:5px;">CPAM Section</td>
                <td style="width: 600px; font-size:12px; padding-left:5px;">Now Formula to get <b>CPAM</b> for Department wise is:<br /><br /><span style="padding-left:25px;"><b>CPAM = (Bud Cost / (Bud Count * Working Hours * ((Working Days in a Month * 12) / 52) * Total No of Week in Budget * 60))</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Share % = (CPAM / Total CPAM) * 100</b></span><br />
                  <br /><span style="padding-left:25px;"><b>CMT Cost = (Average CMT * (CPAM / Total CPAM))</b></span><br />
                  <br /><b>Note:</b>
                  <ul>
                    <li>Average CMT = (Sum of (Quantity * CmtCosted) / Sum of (Quantity))</li>
                  </ul>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 150px; font-size:16px; font-weight:bold; padding-left:5px;">Budget Summary</td>
                <td style="width: 600px; font-size:12px; padding-left:5px;">Formulas for <b>Budget Summary</b> are:<br />
                  <br /><span style="padding-left:25px;"><b>Bud MMR = Total Bud Count / Total Bud Count of those Workers whose works on machine</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Average SAM (Minutes) = (Sum of (Quantity * SamCosted) / Sum of (Quantity))</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Average CMT = (Sum of (Quantity * CmtCosted) / Sum of (Quantity))</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Average Budget CMT = (Total Bud Cost / Sum of (Quantity))</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Budgeted Breakeven Efficiency = (Avg. SAM / Avg. CMT) * CMT Total</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Average FOB Price = (Sum of (Quantity * AgreedPrice) / Sum of (Quantity))</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Sale FOB Value = Sum of (Quantity * AgreedPrice)</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Costed CMT = Average CMT / Average FOB Price</b></span><br />
                  <br /><span style="padding-left:25px;"><b>Budgeted CMT to sale = Total Bud Cost / Sale FOB Value</b></span><br />
                  <br />
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="pnlMMRDailyReport" runat="server">
      <table border="0" cellpadding="0" cellspacing="0" width="750px" align="center" style="font-family:Arial; background-color:#F7F7F7;">
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">1st Grid - Summary Report</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Reference to the 3rd Grid everything is just summary of all the departments.</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Actual MMR</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Total Actual Man power count for the day) / (Actual Manpower count sum of those whose part of machine count says yes)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Budget MMR</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Total Budgeted Man power count for the day) / (Budgeted Manpower count sum of those whose part of machine count says yes)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Productive Machine</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Manpower count sum of those whose part of machine count says yes For Budget and Actual both</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Available Minute Budget</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Manpower count sum of those whose part of machine count says yes For Budget) * Average Working hrs in a day * 60</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  2nd Grid - Available Minute Actual
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  ((Actual Normal attendance count*Normal working Hrs)+(OT1 Count for the day * OT1
                  hr ) + (OT2 Count for the day * OT2 hr ) + (OT3 Count for the day * OT3 hr ) + (OT4
                  Count for the day * OT4 hr )) * 60 Whose part of machine count says yes
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - CPAM</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Take a reference from 4th Grid</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  3rd Grid - Budgeted cost
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Budget Man power Count * ((No of normal hrs * per hr wage normal) + (OT1 per day hrs
                  * Ot1 per hr wage) + (OT2 per day hrs * Ot2 per hr wage) + (OT3 per day hrs * Ot3
                  per hr wage) + (OT4 per day hrs * Ot14 per hr wage))
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  3rd Grid - Actual cost
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  ((Actual Normal attendance count * Normal working Hrs*Normal per hr wage) + (OT1 Count
                  for the day * OT1 hr *OT1 per hr wage) + (OT2 Count for the day * OT2 hr *OT2 per
                  hr wage) + (OT3 Count for the day * OT3 hr *OT3 per hr wage) + (OT4 Count for the day
                  * OT4 hr * OT4 per hr wage))
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">3rd Grid - Monthly Total</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Multiply by 24.33 in the Per Day Total</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">3rd Grid - Overhead</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Monthly Over Head/24.33</td>
              </tr>
            </table>
          </td>
        </tr>
         <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - CPAM Budget (Cutting) - Same can be applied for Stitching,Finishing,
                  Misc and Xny
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  (Cutting Department all designation Budgeted Cost total for a day) / (((normal no
                  of hr which is defined for particular budget * 60) + ( OT1 hr of the day which is defined
                  for particular budget * 60) + (OT2 hr of the day which is defined for particular budget 
                  * 60) + (OT3 hr of the day which is defined for particular budget * 60) + (OT4 hr of
                  the day which is defined for particular budget * 60)) * Budget Total Count for Cutting
                  Staff)
                  <br />Note: OT1 hr of the day which is defined for particular budget = (OT1 hrs
                  from budget * OT1 Day from budget) / total working day of the budget Similarly can
                  be calculated for OT2,OT3,OT4.
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - CPAM Actual (Cutting) - Same can be applied for Stitching,Finishing,
                  Misc and Xny
                </td>
                <td valign="top" style="width: 550px; font-size: 12px; padding-left: 5px;">
                  (Cutting Department all designation actual Cost total for a day) / ((Normal Attendance
                  for the day * no of hr which is 8 here * 60) + SUM(OT1 Attendance count for the day * OT1
                  hr of the day * 60) + SUM(OT2 Attendance count for the day * OT12hr of the day * 60) + SUM(OT3
                  Attendance count for the day * OT3 hr of the day * 60) + SUM (OT4 Attendance count for
                  the day * OT4 hr of the day * 60))
                </td>
              </tr>
            </table>
          </td>
        </tr>
       
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - Budgeted Overhead CPAM
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Per day Factory overhead = Factory Overhead / 24.33 CPAM = Per day Factory overhead /
                  (Budget Man Power Count total of the day who are part of Machine count * Average Working
                  Hrs * 60)
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - Actual Overhead CPAM
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Per day Factory overhead = Factory Overhead / 24.33 CPAM = Per day Factory overhead / 
                  (((Normal Attendance Count total for the day who are part of Machine count * 8) + SUM
                  (OT1 Attendance Count total for the day individuals who are part of Machine count 
                  * OT1 Hrs individuals) + SUM (OT2 Attendance Count total for the day individuals
                  who are part of Machine count * OT2 Hrs individuals) + SUM (OT3 Attendance Count
                  total for the day individuals who are part of Machine count * OT13Hrs individuals) 
                  + SUM (OT4 Attendance Count total for the day individuals who are part of Machine
                  count * OT4 Hrs individuals)) * 60)
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">Total Ordered Quantity for a day</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Ordered Quantity for Budget Period/Budget Period Working Day</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">Budget Period Working Day</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Budget Period Week count * (24.33 * 12 / 52)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">4th Grid - Actual CMT Cost</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Actual Production Cost for the day for cutting/Total Ordered Quantity for a day</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">4th Grid - Budgeted CMT Cost</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Budgeted Production Cost for the day for cutting/Total Ordered Quantity for a day</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="pnlMMRReportDateRange" runat="server">
      <table border="0" cellpadding="0" cellspacing="0" width="750px" align="center" style="font-family:Arial; background-color:#F7F7F7;">
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">1st Grid - Summary Report</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Reference to the 3rd Grid everything is just summary of all the departments.</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Actual MMR</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Total Actual Man power count for the working day) / (Actual Manpower count sum of those whose part of machine count says yes for said working days)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Budget MMR</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Total Budgeted Man power count for the said working days) / (Budgeted Manpower count sum of those whose part of machine count says yes for said working days)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Productive Machine</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Manpower count sum of those whose part of machine count says yes For Budget and Actual both for said working days</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - Available Minute Budget</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Manpower count sum of those whose part of machine count says yes For Budget) * Average Working hrs in a day * 60 * working days</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  2nd Grid - Available Minute Actual
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  SUM of all working days (((Actual Normal attendance count*Normal working Hrs) + (OT1
                  Count for the day * OT1 hr ) + (OT2 Count for the day * OT2 hr ) + (OT3 Count for
                  the day * OT3 hr ) + (OT4 Count for the day * OT4 hr )) * 60) Whose part of machine count says yes
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">2nd Grid - CPAM</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Take a reference from 4th Grid</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  3rd Grid - Budgeted cost
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Budget Man power Count * ((No of normal hrs * per hr wage normal) + (OT1 per day hrs
                  * Ot1 per hr wage) + (OT2 per day hrs * Ot2 per hr wage) + (OT3 per day hrs * Ot3
                  per hr wage) + (OT4 per day hrs * Ot14 per hr wage)) * No of Working Days
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  3rd Grid - Actual cost
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  ((Actual Normal attendance count*Normal working Hrs * Normal per hr wage) + SUM (OT1
                  Count for the day * OT1 hr *OT1 per hr wage) + SUM(OT2 Count for the day * OT2 hr 
                  * OT2 per hr wage) + SUM(OT3 Count for the day * OT3 hr *OT3 per hr wage) + SUM(OT4
                  Count for the day * OT4 hr *OT4 per hr wage))
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">3rd Grid - Monthly Total</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Multiply by 24.33 in the Per Day Total</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">3rd Grid - Overhead</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">(Monthly Over Head / 24.33) * No of working days in selected date range</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - CPAM Actual (Cutting) - Same can be applied for Stitching,Finishing,
                  Misc and Xny
                </td>
                <td valign="top" style="width: 550px; font-size: 12px; padding-left: 5px;">
                  (Cutting Department all designation actual Cost total for given days) / ((Normal
                  Attendance for those day * no of hr which is 8 here*60) + SUM(OT1 Attendance count
                  for the whole date range * OT1 hr of the whole date range * 60) + SUM(OT2 Attendance
                  count for the whole date range * OT12hr of the whole date range * 60) + SUM(OT3 Attendance
                  count for the whole date range * OT3 hr of the whole date range * 60) + SUM (OT4 Attendance
                  count for the whole date range * OT4 hr of the whole date range * 60))
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - CPAM Actual (Cutting) - Same can be applied for Stitching,Finishing,
                  Misc and Xny
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  (Cutting Department all designation Budgeted Cost total for given day) / (((normal
                  no of hr which is which is defined for particular budget * 60) + ( OT1 hr of the day
                  which is defined for particular budget * 60) + (OT2 hr of the day which is defined
                  for particular budget * 60) + (OT3 hr of the day which is defined for particular budget 
                  * 60) + (OT4 hr of the day which is defined for particular budget * 60)) * Budget Total
                  Count for Cutting Staff) * total number of working days
                  <br />Note: OT1 hr of the day which
                  is defined for particular budget = (OT1 hrs from budget * OT1 Day from budget) / total
                  working day of the budget Similarly can be calculated for OT2, OT3, OT4.
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - Budgeted Overhead CPAM
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Per day Factory overhead = Factory Overhead / 24.33 Overhead for given date range
                  = Per day Factory overhead * days count in date range CPAM = Overhead for given date
                  range / (Period total Budget Man Power Count who are part of Machine count * Average
                  Working Hrs * 60)
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size: 14px; font-weight: bold;
                  padding-left: 5px;">
                  4th Grid - Actual Overhead CPAM
                </td>
                <td style="width: 550px; font-size: 12px; padding-left: 5px;">
                  Per day Factory overhead = Factory Overhead / 24.33 Overhead for given date range
                  = Per day Factory overhead * days count in date range CPAM = Overhead for given date
                  range / (((Normal Attendance Count total for the day who are part of Machine count 
                  * 8) + SUM (OT1 Attendance Count total for the day individuals who are part of Machine
                  count * OT1 Hrs individuals) + SUM (OT2 Attendance Count total for the day individuals
                  who are part of Machine count * OT2 Hrs individuals) + SUM (OT3 Attendance Count total
                  for the day individuals who are part of Machine count * OT13Hrs individuals) + SUM
                  (OT4 Attendance Count total for the day individuals who are part of Machine count
                  * OT4 Hrs individuals)) * 60) The whole denominator need to be calculated for all date
                  in given range and need to be sum.
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">Total Ordered Quantity for a day</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Ordered Quantity for Budget Period / Budget Period Working Day</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">Budget Period Working Day</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Budget Period Week count * (24.33 * 12 / 52)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">4th Grid - Actual CMT Cost</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Actual Production Cost for the date range for cutting / (Total Ordered Quantity for a day * Total number of day count given)</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" align="center">
              <tr>
                <td align="left" valign="top" style="width: 200px; font-size:14px; font-weight:bold; padding-left:5px;">4th Grid - Budgeted CMT Cost</td>
                <td style="width: 550px; font-size:12px; padding-left:5px;">Total Budgeted Production Cost for the date range for cutting / (Total Ordered Quantity for a day * Total number of day count given)</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </asp:Panel>
  </div>
  </form>
</body>
</html>
