<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDepartmentList.aspx.cs"
    Inherits="iKandi.Web.ClientDepartmentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        th
        {
            background: #405D99 !important;
            border-color: #bfbfbf;
            color: #ffffff !important;
            font-weight: normal;
            font-size: 10px;
            padding: 5px 0px;
            font-family: arial,halvetica;
            text-transform:capitalize;
        }
        body
        {
            margin: 0;
            padding: 0;
            font-size: 10px;
            font-family: verdana;
        }
        td
        {
            padding: 5px 0px;
            text-align: center;
            color: Gray;
        }
           td table tr td
           {
                padding: 0px 0px !important;
           }
        .boldblack span
        {
            color: Black !important; font-weight: bold;font-size: 14px;
        }
        .boldblacknew
        {
            font-size: 14px;
            font-weight: bold;
        }
        .boldblacknew table td span
        {
            font-size: 14px;
            font-weight: bold;
        }
        ul li
        {
            color:Gray;
        }
      
        .footerback
        {
            background:#FFF0A5;
        }
        .footerback .Background-red
        {
            background:#FFF0A5 !important;
            text-align:center;   
        }
        .footerback .Background-green
        {
            background:#FFF0A5 !important;
            text-align:center;   
        }
        .footerback .Background-red span
        {
            color:gray !important;
            font-weight:bold;
         }
         .footerback td span
        {
            color:gray !important;
            font-weight:bold;
         }
        .inputfixed span
        {
            border:0px;
            text-align:center;          
            text-transform:capitalize;
            color:Gray;
            border-color:White;
        }       
        .Background-red
        {
            background-color:Red;           
            text-align:center;
        }
        .Background-red span
        {
            color:Yellow; 
        }
        .Background-green
        {
            background-color:Green;
            
        }
        .gridpadding .header1 td
        {
            background: #405D99;
    font-weight: bold;
    color: #fff;
    font-family: arial, halvetica;
    font-size: 10px;
    padding: 0px 0px;
    border-color: #BFBFBF;
        }
        .gridpadding .header2 td
        {
            background: #405D99;
           font-weight: bold;
          color: #fff;
         font-family: arial, halvetica;
         font-size: 10px;
        padding: 0px 0px;
         border-color: #BFBFBF;
        }
        
        .gridpadding .header3 td
        {
            background: #405D99;
           font-weight: bold;
            color: #fff;
            font-family: arial, halvetica;
          font-size: 10px;
           padding: 0px 0px;
          border-color: #BFBFBF;
        }
        .blacktext
        { 
           color: #000000 !important;
            }
    </style>
  <script language="javascript" type="text/javascript">
      function refreshHtml() {
          document.getElementById('hdn_container').value = document.head.innerHTML + document.body.innerHTML;
          alert(document.getElementById('hdn_container').value);
      }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hdn_container" /> 
  
    <div runat="server" id="innerdiv">
   
        <table cellpadding="0" cellspacing="0" border="0" style="width: 900px; margin: 10px auto;"
            align="center">
            <%--<tr>
                <td style="text-align: left;">
                    <strong style="font-size: 16px;">Sampling Report </strong>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 960px; margin: 10px auto;
                        text-align: center;" align="center">
                        <tr>
                            <th>
                                Client Department List
                            </th>
                        </tr>
                    </table>
                    <asp:GridView ID="grdclientdept" AutoGenerateColumns="false" runat="server" ShowFooter="false"
                        ShowHeader="true" Width="960px" CellPadding="0" BorderWidth="1" HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="20px" HeaderText="AM">
                                <ItemTemplate>
                                    <asp:Label ID="lblusername" Text='<%# Eval("UserName")%>' ForeColor="Black" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="108px" height= "24px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client (Department)">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientDepartmentDetails" Text='<%# Eval("ClientDepartmentDetails")%>'
                                        runat="server" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="780px" VerticalAlign="Top" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <span style="font-size: 12px; color: Black;">Record not available</span></EmptyDataTemplate>
                        <EmptyDataRowStyle Height="60px" />
                    </asp:GridView>
                </td>
            </tr>

            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">AM Performance: </strong>
                </td>
            </tr>
            <tr>
                <td>
                
                    <ul style="text-align: left; font-size: 10px; margin: 0px;color:Black;">
                       <li><b>Sealing:</b>
                          <ul>
                            <li><b>Q1&Q2</b>
                                <ul>
                                <li><b>Base criteria (Considering Minimum STC ETA date after order date only and ETA is between the previous quarters).</b></li>
                                <li><b>On Time -> </b> (AM's total sealed  contract count in previous quarters on time or before / number of contracts whose sealing Targets is in previous quarters and done) * 100.</li>
                                <li><b>Avg ETA Day -> </b> Considering the base criteria taking the sum of the difference between the Order Date and Eta and dividing by total number of contracts having base criteria.</li>
                                <li><b>Avg Delay Day -> </b> In above if Sealing date (STC approved date) is before order date, then exclude this from the scope.</li>
                                </ul>
                            </li>
                            <li><b>Q3</b>
                                <ul>
                                <li><b>Base criteria (Considering Minimum STC ETA date after order date only and ETA belongs to current quarter till today date only).</b></li>
                                <li><b>On Time -> </b> (AM's total sealed  contract count in previous quarters on time or before / number of contracts whose sealing Targets is in previous quarters and done) * 100.</li>
                                <li><b>Avg ETA Day -> </b> Considering the base criteria taking the sum of the difference between the Order Date and Eta and dividing by total number of contracts having base criteria.</li>
                                <li><b>Avg Delay Day -> </b> Considering the base criteria taking sum of the differences between Action date and Order date and dividing the total number of contracts having same criteria.</li>
                                </ul>
                            </li>
                            <li>BG color will be Green if   Sealing Performance > 80% else Red.</li>
                          </ul>
                         </li>
                      </ul>
                      <br />
                       <ul style="text-align: left; font-size: 10px; margin: 0px;color:Black;">
                            <li><b >Bulk Inhouse (Bulk In house achieved only when the contract have all fabric inhouse greater than or equals to 90% or more.)</b>
                        <ul>
                          <li><b>Q1&Q2</b>
                                <ul>
                                <li><b>Base criteria (Considering all the contracts whose BIH ETA between the previous quarters).</b></li>
                                <li><b>On Time -> </b> (AM's total BIH done contract count in previous quarters on time or before it’s ETA / number of contracts whose BIH Targets is in previous quarters) * 100.</li>
                                <li><b>Avg ETA Day -> </b> Considering the base criteria taking the sum of the difference between the Order Date and Eta and dividing by total number of contracts having base criteria.</li>
                                <li><b>Avg Delay Day -> </b> Considering the base criteria taking sum of the differences between Action date and Order date and dividing the total number of contracts having same criteria.</li>
                                </ul>
                            </li>
                            <li> <b>Q3</b>
                                <ul>
                                <li><b>Base criteria (Considering all the contracts whose BIH ETA date belongs to current quarter till today date only).</b></li>
                                <li><b>On Time -> </b> (AM's total BIH done contract count in current quarters on time or before it’s ETA  with base criteria/ number of contracts whose BIH Targets is in current quarters till date only) * 100.</li>
                                <li><b>Avg ETA Day -> </b> Considering the base criteria taking the sum of the difference between the Order Date and Eta and dividing by total number of contracts having Base criteria.</li>
                                <li><b>Avg Delay Day -> </b> Considering the base criteria taking sum of the differences between Action date and Order date and dividing the total number of contracts having same criteria.</li>
                                </ul>
                            </li>
                              <li>BG color will be Green if   BIH Performance > 80% else Red.</li>
                            </ul>
                         </li>
                      </ul>
                      <br />
                        <ul style="text-align: left; font-size: 10px; margin: 0px;color:Black;">
                              <li><b>Style code Share</b> (Particular AM's different style code current financial year / Total number of Style code in current financial year) * 100.</li>
                           
                        </ul>
                       
                </td>
               
            </tr>

            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Handover Section: </strong>
                </td>
            </tr>
            <tr>
                <td>
                
                    <ul style="text-align: left; font-size: 10px; margin: 0px;color:Black;">
                   
                        <li ><b >Task pending:</b>  <span >pending task for handover in sampling based on PD. Total</span>
                            is the complete pending handovers for sampling. </li>
                        <li ><b>Task Delay: </b>All the handover delayed based on PD till date. Total shows the
                            complete delays in handover for sampling. </li>
                        <li ><b>Avg.LT time 1 month: Avg. </b>Lead time in weeks, this is calculated based on
                            the Style created and handover done date difference. Taking the handover done date
                            range in last 30 days.
                            <br />
                            For styles whose Handover done in last 30 days = <b>((Handover done date – Style created
                                date)/Style count) / 7 </b></li>
                        <li >Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
               
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Pattern Ready Section: </strong>
                </td>
            </tr>
            <tr>
                <td >
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li ><b >Task pending:</b> Total pending task for Pattern Ready in sampling based on PD.
                            Total is the complete pending Pattern Ready for sampling. </li>
                        <li ><b>Task Delay: </b>All the Pattern Ready delayed based on PD till date. Total shows
                            the complete delays in Pattern Ready for sampling. </li>
                        <li ><b>Avg.LT time 1 month: Avg. </b>this is calculated based on the Style created and
                            Pattern Ready done date difference. Taking the Pattern Ready done date range in
                            last 30 days
                            <br />
                            For styles whose Pattern Ready done in last 30 days = <b>((Pattern Ready done date –
                                Style created date)/Style count) / 7 </b></li>
                        <li >Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Sample Sent Section: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li ><b>Task pending:</b> Total pending task for Sample Sent in sampling based on PD.
                            Total is the complete pending Sample Sent for sampling. </li>
                        <li ><b>Task Delay: </b>All the Sample Sent delayed based on PD till date. Total shows
                            the complete delays in Sample sent for sampling. </li>
                        <li ><b>Avg.LT time 1 month: Avg. </b>this is calculated based on the Style created and
                            Sample sent done date difference. Taking the Sample Sent done date range in last
                            30 days
                            <br />
                            For styles whose Sample Sent done in last 30 days = <b>((Sample Sent done date – Style
                                created date)/Style count) / 7 </b></li>
                        <li >Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Costing Price Quoted: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li ><b>Task pending:</b>Total pending price quoted till date based on PD. Total shows
                            the complete total Pending price quoted. </li>
                        <li ><b>Task Delay: </b>All the Price quoted delayed task count based on PD. Total shows
                            the complete total of the Price quoted delayed count. </li>
                        <li ><b>Avg.LT time 1 month: Avg. </b>calculated for those costing for which price quoted
                            done in last 30 days
                            <br />
                            For styles whose Price quoted done in last 30 days = <b>((Costing Creation date – Price
                                quoted done date)/Number of costing) / 7 </b></li>
                        <li >Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
           <%-- <tr> 
                <td style="text-align: left;">
                    <strong style="font-size: 16px;">Fits Report </strong>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Handover Section: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li><b>Task pending:</b> Total pending task for handover in Fits Cycle based on AM.
                            Total is the complete pending handovers for Fits Cycle. </li>
                        <li><b>Task Delay: </b>All the handover delayed based on AM till date. Total shows the
                            complete delays in handover for Fits Cycle. </li>
                        <li><b>Avg.LT time 1 month: Avg. </b>Avg. Lead time in weeks, this is calculated based
                            on the Order Date and handover done date difference. Taking the handover done date
                            range in last 30 days.
                            <br />
                            For styles whose Handover done in last 30 days = <b>((Handover done date – Order created
                                date)/No of Contract) / 7 </b></li>
                        <li>Total Avg. LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Pattern Ready Section: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li><b>Task pending:</b>Total pending task for Pattern Ready in Fit Cycle based on AM.
                            Total is the complete pending Pattern Ready for Fits Cycle. </li>
                        <li><b>Task Delay: </b>: All the Pattern Ready delayed based on AM till date. Total
                            shows the complete delays in Pattern Ready for Fits Cycles</li>
                        <li><b>Avg.LT time 1 month: Avg. </b>this is calculated based on the Order Date and
                            Pattern Ready done date difference. Taking the Pattern Ready done date range in
                            last 30 days
                            <br />
                            For styles whose Pattern Ready done in last 30 days = <b>((Pattern Ready done date –
                                Order created date)/No of Contract) / 7 </b></li>
                        <li>Total Avg. LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Sample Sent Section: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li><b>Task pending:</b>Total pending task for Sample Sent in Fits Cycle based on AM.
                            Total is the complete pending Sample Sent for Fits Cycle. </li>
                        <li><b>Task Delay: </b>All the Sample Sent delayed based on AM till date. Total shows
                            the complete delays in Sample sent for Fits Cycle. </li>
                        <li><b>Avg.LT time 1 month: Avg. </b>this is calculated based on the Order created and
                            Sample sent done date difference. Taking the Sample Sent done date range in last
                            30 days
                            <br />
                            For styles whose Sample Sent done in last 30 days = <b>((Sample Sent done date – Order
                                created date)/Number of contract) / 7 </b></li>
                        <li>Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Costing Price Quoted: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li><b>Task pending:</b>Total pending Fit Comments Upload till date based on AM. Total
                            shows the complete total Pending Fit Comments Upload. </li>
                        <li><b>Task Delay: </b>All the Fit Comments Upload delayed task count based on AM. Total
                            shows the complete total of the Fit Comments Upload delayed count. </li>
                        <li><b>Avg.LT time 1 month: Avg. </b>calculated for those Contracts for which Fit Comments
                            Upload done in last 30 days
                            <br />
                            For styles whose Fit Comments Upload done in last 30 days = <b>((Fit Comments Upload
                                – Order done date)/Number of Contracts) / 7 </b></li>
                        <li>Total Avg.LT time 1 month is the average </li>
                    </ul>
                </td>
            </tr>--%>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Master Monthly Performance Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >Here in this report we are showing each masters every day activity count then showing
                            the total and BIP Performance which is <b>(Total/ No of Masters)</b> </li>
                        <li >Here excluding the Sunday and Holidays in the report for calculations too. </li>
                        <li >In the bottom of the report there are two rows as follows:
                            <ul>
                                <li >Master Average is the
                                    <br />
                                    <b>(Sum of all the style count done/ Total number of working days) </b></li>
                                <li >ii) WIP has two values total pending task count allocated to the master after handover
                                    and then in bracket (total pending task count allocated to the master after handover/
                                    Master average) as in Days </li>
                            </ul>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">TOP Summary Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >This report works based on Account Managers. </li>
                        <li >Here excluding the Sunday and Holidays in the report for calculations too. </li>
                        <li >In first column showing TOP sent pending count which is contract specific and based
                            on the account manager.</li>
                        <li >TOP Pending approval the second column will have all those contracts whose Ex-factory
                            is less than equal to Todays Date + 7 day. </li>
                        <li >The third and last column has week value for last 3 month and last 1 year. The range
                            is based on the Ex-Factory date and for those contracts for which TOP SENT done.
                            Calculated week as <b>((Ex-Factory – TOP Sent Date)/ No of Contract)/ 7</b>
                        </li >
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Excel attached Reports: </strong>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 11px;">HandOver Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul  style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >Showing all the pending handovers in the excel report separated as pre order and
                            post order.</li>
                        <li>Ordering done based on ETA,PD Manager, Account Manager </li>
                    </ul>
                </td>
            </tr>
            
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size:12px;">Pattern Ready Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >Showing all the pending Pattern Ready detail in the excel report separated as pre
                            order and post order.</li>
                        <li >Ordering done based on ETA,PD Manager, Account Manager </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Sample Sent Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >Showing all the pending Sample Sent detail in the excel report separated as pre
                            order and post order.</li>
                        <li >Ordering done based on ETA,PD Manager, Account Manager</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">Fits Comment Upload Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >Showing all the pending Fit Comment Upload detail in the excel report separated
                            as pre order and post order. </li>
                        <li >Ordering done based on ETA Descending ,PD Manager, Account Manager</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">TOP Pending to send report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >All pending contracts where ex factory is less than 3 week away or less and TOP
                            has not been sent. </li>
                        <li >Sort Order : Style number-> Ex- Factory -> Department</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <strong style="font-size: 12px;">TOP Pending Approval Report: </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <ul style="text-align: left; font-size: 10px; margin: 0px;">
                        <li >This is the TOP Pending report where ex-factory less than or equals to today date
                            + 7 days </li>
                        <li >Ordering done based on Style Number, Ex-factory and Department name in descending
                            order</li>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
  
    </form>
</body>
</html>
