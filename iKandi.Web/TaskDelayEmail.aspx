<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskDelayEmail.aspx.cs" Inherits="iKandi.Web.Admin.TaskDelayEmail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>

  <style type="text/css">
      body
      {
          font-family: Arial;
      }
    .txt
    {
      color: #7E7E7E;
      text-transform: none;
      font-family: Arial;
    }
.taskdelay td
{
    border-color:Gray;
    font-family: Arial;
}
.taskdelay th
{
    border-color:#bfbfbf;
    font-family: Arial;
}
  </style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="98%" align="center">
      <tr>
        <td align="center" style="height:25px; background-color:#405D99; color:#FFFFFF; font-size:12px; font-weight:bold; text-align:center; font-family: Lucida Sans Unicode; width:100%;">
          Feeding Detailed Performance
        </td>
      </tr>
      <tr>
        <td align="center" style="padding-top:5px;">
          <asp:GridView ID="gvDelayMonitoring" runat="server" Width="100%" ShowFooter="false" CssClass="taskdelay"  AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E"
            OnRowDataBound="gvDelayMonitoring_RowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="200px" ItemStyle-BackColor="#f2f2f2">
                <HeaderTemplate>Task Name</HeaderTemplate>
                <ItemTemplate>
                  <asp:HiddenField ID="hdnStatusModeId" runat="server" Value='<%#Eval("StatusModeID") %>' />
                  <asp:Label ID="lblStatusMode" runat="server" Font-Size="12px" Font-Bold="true" Text='<%#Eval("StatusMode") %>' ForeColor="Black"></asp:Label>
                </ItemTemplate> 
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle forecolor="#98a9ca" />
              </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="125px" ItemStyle-BackColor="#f2f2f2">
                <HeaderTemplate>Department Name</HeaderTemplate>
                <ItemTemplate>
                  <asp:Label ID="lblDepartMentDescription" runat="server" Font-Size="9px" Text='<%#Eval("DepartMentDescription") %>' ForeColor="gray"></asp:Label>
                </ItemTemplate> 
              <ItemStyle HorizontalAlign="Left" /> 
              <HeaderStyle forecolor="#98a9ca" />
              </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="125px" ItemStyle-BackColor="#f2f2f2">
                <HeaderTemplate>Target Logic</HeaderTemplate>
                <ItemTemplate>
                  <asp:Label ID="lblTargetLogic" runat="server" Font-Size="9px"  Text='<%#Eval("Details") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle forecolor="#98a9ca" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="80px">
               <%-- <HeaderTemplate>
                <table style="border-collapse:collapse; text-align:center;font-size: 9px;" width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                <tr> 
                <td colspan="2" style="border-bottom:1px solid #bfbfbf;font-weight:bold;font-size: 12px; color:#ffffff;" width="100%" height="20px">Total </td>  </tr>
                <tr> 
                <td style="border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:normal; color:#98a9ca;" width="50%" height="20px"> Dly </td> 
                <td id="tdStchActOB" runat="server" style=" border-bottom:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;" width="50%">  Avg Dly Day(3 M) </td>  
                </tr>
                <tr> 
                <td style="border-right:1px solid #bfbfbf; font-weight:normal;color:#98a9ca;" width="50%" height="20px"> % Dly </td> 
                <td id="tdFinActOB" runat="server" style="font-weight:normal;color:#98a9ca;" width="50%"> Avg Dly Day(1 Y)</td> 
                </tr>
                </tbody>
                </table>
                
                
                
                
                </HeaderTemplate>--%>
                <ItemTemplate>
                <%--<table cellpadding="0" cellspacing="0" width="100%" border="0" style="border-collapse:collapse; text-align:center;font-size: 11px;">
                <tbody>--%>
              <%--  <tr> 
                <td width="50%" style="border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; height:14px">
               <asp:Label ID="lblTotalStatusModeCount" runat="server" Font-Bold="true" ForeColor="Black" CssClass="txt" Font-Size="12px"  Text='<%#Eval("TotalStatusModeCount") %>'></asp:Label>
                </td> 
                <td id="tdStchActOB" runat="server" width="50%" style=" border-bottom:1px solid #bfbfbf; color:gray;"> 
               <asp:Label ID="lblAvgDelayDay" runat="server" CssClass="txt" Font-Bold="true" Font-Size="12px" Text='<%#Eval("totalAvgDelayDay") %>'></asp:Label>
                </td>  
                </tr>--%>
              <%--  <tr> 
                <td id="tdt2" runat="server" width="50%" style="border-right:1px solid #bfbfbf; height:14px">
                 <asp:Label ID="lblpercentdelay" runat="server" CssClass="txt" Font-Size="12px"  Text='<%#Eval("percentdelay") %>'></asp:Label>
              
                </td> 
                <td id="tdFinActOB" runat="server" style="color:gray;" width="50%"> 
               <asp:Label ID="lblMaxDelayDay" runat="server" CssClass="txt" ForeColor="Gray" Font-Size="12px" Text='<%#Eval("MaxDelayDay") %>'></asp:Label>
                </td> 
                </tr>--%>
                <%--</tbody>
                </table>--%>
                  
                </ItemTemplate>
                <FooterTemplate>

                </FooterTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>

      </table>
      <br />
      <table border="0" cellpadding="0" cellspacing="0" style="width:1350px" align="center">

       <tr>
        <td align="center" style="height:25px; background-color:#405D99; color:#FFFFFF; font-size:12px; font-weight:bold; text-align:center; font-family: Lucida Sans Unicode;">
          Feeding KPI Performance
        </td>
      </tr>
       <tr>
        <td align="center" style="padding-top:5px;">
          <asp:GridView ID="grdViewLeadTime" runat="server" Width="1450px" ShowFooter="false" CssClass="taskdelay"  AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E"
            OnRowDataBound="grdViewLeadTime_RowDataBound" CellPadding="0">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-BackColor="#f2f2f2">
                <HeaderTemplate>Task Name</HeaderTemplate>
                <ItemTemplate>
                  <asp:HiddenField ID="hdnLeadTimeStatusModeId" runat="server" Value='<%#Eval("StatusModeID") %>' />
                  <asp:Label ID="lblLeadTimeStatusMode" runat="server" Font-Size="12px" Font-Bold="true" Text='<%#Eval("StatusMode") %>' ForeColor="Black"></asp:Label>
                </ItemTemplate> 
              <ItemStyle HorizontalAlign="Left" />

              <HeaderStyle  Width="110" />
              </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="77px"  ItemStyle-BackColor="#f2f2f2" Visible="false">
                <HeaderTemplate>Department Name</HeaderTemplate>
                <ItemTemplate>
                  <asp:Label ID="lblLeadTimeDepartMentDescription" runat="server" Font-Size="9px" Text='<%#Eval("DepartMentDescription") %>' ForeColor="gray"></asp:Label>
                </ItemTemplate> 
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle forecolor="#98a9ca" />
              <FooterTemplate>
                <asp:Label ID="lblfooter" runat="server" Text="footer"></asp:Label>
                </FooterTemplate>
              </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="110px" ItemStyle-BackColor="#f2f2f2" Visible="false">
                <HeaderTemplate>Target Logic</HeaderTemplate>
                <ItemTemplate>
                  <asp:Label ID="lblLeadTimeTargetLogic" runat="server" Font-Size="9px"  Text='<%#Eval("Details") %>'></asp:Label>
                  <div ID="footertable" runat="server">  </div> 
                </ItemTemplate>
                <HeaderStyle forecolor="#98a9ca" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="100px" HeaderStyle-Width="100px">
                <%--<HeaderTemplate>
                <table style="border-collapse:collapse; text-align:center;font-size: 9px;" width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                <tr> 
                <td colspan="2" style="border-bottom:1px solid #bfbfbf;font-weight:bold;font-size: 12px; color:#ffffff;" width="100%" height="20px">Total (Wk) </td>  </tr>
                <tr> 
                 <td style="border-right:1px solid #bfbfbf; font-weight:normal;color:#98a9ca; border-right:1px solid #bfbfbf;" width="50%" height="20px" rowspan="2"> Task Lead Time(Wk) </td> 
                <td style="border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:normal; color:#98a9ca;" width="50%" height="20px"> Order Lead Time 1 Year </td> 
                <td id="tdLeadTimeStchActOB" runat="server" style=" border-bottom:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;" width="50%"> (3 M) Lead Time Avg (Wk) </td>  
                </tr>
                <tr> 
               
                <td id="tdLeadTimeFinActOB" runat="server" style="font-weight:normal;color:#98a9ca; border-left:1px solid #bfbfbf; height:20px" width="50%"> (1 Y) Lead Time Avg(Wk)</td> 
                </tr>
                </tbody>
                </table>
                
                
                
                
                </HeaderTemplate>--%>
                <ItemTemplate>
                <%--<table cellpadding="0" cellspacing="0" width="100%" border="0" style="border-collapse:collapse; text-align:center;font-size: 11px;">
                <tbody>
                <tr> 
                 <td id="tdLeadTimet2" runat="server" width="50%" style="border-right:1px solid #bfbfbf; height:28px" rowspan="2">
                 <asp:Label ID="lblLeadTimepercentdelay" runat="server" CssClass="txt" Font-Size="12px"  Text='<%#Eval("percentdelay") %>'></asp:Label>
                 <asp:HiddenField ID="hdnLeadTimepercentdelay" runat="server" Value='<%#Eval("Percentdelay_Dummy") %>' />
                  <asp:Label ID="lblLeadTimeTotalStatusModeCount" runat="server" Font-Bold="true" ForeColor="Black" CssClass="txt" Font-Size="12px" style="display:none;"  Text='<%#Eval("TotalStatusModeCount") %>'></asp:Label>
                </td> 
               <td width="50%" style="border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; height:14px; display:none;">
              
                </td>
                <td id="tdLeadTimeStchActOB" runat="server" width="50%" style=" border-bottom:1px solid #bfbfbf; color:gray; height:14px;"> 
               <asp:Label ID="lblLeadTimeAvgDelayDay" runat="server" CssClass="txt" Font-Bold="true" Font-Size="12px" Text='<%#Eval("totalAvgDelayDay") %>'></asp:Label>
                <asp:HiddenField ID="hdnLeadTimeAvgDelayDay" runat="server" Value='<%#Eval("TotalStatusModeCount_Dummy") %>' />
                </td>  
                </tr>
                <tr> --%>
               <%-- <td id="tdLeadTimet2" runat="server" width="50%" style="border-right:1px solid #bfbfbf; height:14px">
                 <asp:Label ID="lblLeadTimepercentdelay" runat="server" CssClass="txt" Font-Size="12px"  Text='<%#Eval("percentdelay") %>'></asp:Label>
                </td> --%>
             <%--   <td id="tdFinActOB" runat="server" style="color:gray; height:14px;" width="50%"> 
               <asp:Label ID="lblLeadTimeMaxDelayDay" runat="server" CssClass="txt" ForeColor="Gray" Font-Size="12px" Text='<%#Eval("MaxDelayDay") %>'></asp:Label>
                </td> 
                </tr>
                </tbody>
                </table>--%>
                  
                </ItemTemplate>
                
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
      <tr>
      <td>
      <b style="color:gray; font-size:9px;"><u> Note: </u> </b>
      <br /> 
      <b style="color:gray; font-size:9px;"><u>Feeding Detailed Performance</u> :- </b>
      <ul style="list-style:value; font-size:8px; padding:0px 16px; margin:0px; line-height:18px; color:gray"> 
      <li>
      <b>Dly: </b> No of Total contracts which are not done even after ETA passed.
      </li>
      <li>
      <b>Task LT: </b> For all the contracts have Ex Factory 1 jan 2016 or Later ((ETA - Order Date) / No. Of Contract) / No of days in a week .
      </li>
      <li>
      <b> 3 M LT : </b> For those Contracts Whose Action Date in Last 3 Months ((Action Date - Order Date) / No. Of Contract ) / No of days in a week . 
      </li>
      <li>
      <b>1 Y LT :</b> For those Contracts Whose Action Date in Last 1 Year ((Action Date - Order Date) / No. Of Contract ) / No of days in a week . 
      </li>
      
      <li>
   
      <b> Color Logic : </b>
      <ul>
      <li>
      <b>3 M LT :-</b>
    <ul>
                      <li> If 3 M LT &lt;= Total Lead Time then colour would be green.</li>
                   <li>If 3 M LT &gt; Total Lead Time then colour would be Red. </li>
                   
                      </ul>
                     

      </li>
     
      </ul>
      </li>    
      </ul>        
      <b style="color:gray; font-size:9px;"><u> Feeding KPI Performance :</u> </b>
      <ul style="list-style:value; font-size:8px; padding:0px 16px; margin:0px; line-height:18px; color:Gray;">
    
     <li>
      <b>Total: </b> For all the contracts have Ex Factory 1 jan 2016 or Later ((ETA - Order Date) / No. Of Contract) / No of days in a week .
      </li>
      <li>
      <b> 3 Month : </b> For those Contracts Whose Action Date in Last 3 Months ((Action Date - Order Date) / No. Of Contract ) / No of days in a week . 
      </li>
      <li>
      <b>1 Year  :</b> For those Contracts Whose Action Date in Last 1 Year ((Action Date - Order Date) / No. Of Contract ) / No of days in a week . 
      </li>
     
      <li>
   
      <b> Color Logic : </b>
      <ul>
      <li>
      <b>3 Month :-</b>
    <ul>
                      <li> If 3 Month &lt;= Total Lead Time then colour would be green.</li>
                   <li>If 3 Month &gt; Total Lead Time then colour would be Red. </li>
                   
                      </ul>
                     

      </li>
     
      </ul>
      </li> 
      <li>
      <ul>
      <li>
      <b>Ex. Month: </b>  This Contains 4 Rows as Follows:

        <ul>
           <li>
            Current & Previous Month
           </li>
           <li> Current Month + 1  </li>
           <li>
           Current Month + 2
           </li>
           <li>
           Current Month + 3
           </li>
        </ul>
      </li>
      <li> <b>Comp. : </b> Total Completed Style No. Count in the said month. </li>
      <li> <b>Pend. : </b> Total Pending Style No. Count in the said month. </li>
      </ul>
      </li>
      
         
    <li> 
     	<b> Total Lead Time 1 Year (Wk): </b>Total Order Lead Time in Year for all status between New order to Approve To Ex based on:
        <b>(Sum (Exfactory Date-Order date)/No of contracts)/No of days in a week. </b>
      </li>
      <li>
      <b>No of style : </b> Total No. of Style with Account Manager Which have Orders From new order Status to Approved To Ex.
      </li>
      </ul>
      
      
      </td>
      </tr>

    </table>
  </div>
  </form>
</body>
</html>
