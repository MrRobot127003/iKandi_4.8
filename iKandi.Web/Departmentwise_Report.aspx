<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departmentwise_Report.aspx.cs"
    Inherits="iKandi.Web.Departmentwise_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            text-transform: capitalize;
        }
        body
        {
            margin: 0;
            padding: 0;
            font-size: 12px;
            font-family: arial,halvetica;
        }
        td
        {
            padding: 5px 0px;
            text-align: center;
            color: Gray;
            border-color:gray;
        }
        
        .boldblack span
        {
            color: Black !important;
            font-weight: bold;
            font-size: 14px;
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
        
        
        .DepartmentGrid td
        {
            color: Black;
        }
    
         #grdDepartmentSpecificDelayReport {
           
            
            width:1670px !important;
         }
         #GridView1  {
        
         
            width:1640px !important;
         }
        form
        {
            margin-left:10px !important;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" style="width: 1163px;max-width: 1163px; margin: 0px 0px 5px !important;

        text-align: center; float:left;">
        <tr>
            <th>
                Sampling Report <span style="color: #c7c5c5;">(For further reference please view <b
                    style="font-size: 11px">FITS and Sampling Reports</b> excel) </span>
            </th>
        </tr>
    </table>
    <br />
  
    <asp:GridView ID="grdsampling" AutoGenerateColumns="false" runat="server" ShowFooter="false"
        ShowHeader="false" OnRowDataBound="grdsampling_RowDataBound" CellPadding="0" BorderWidth="1" BorderColor="#e1e1e1" style="max-width:1163px;">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblusername" Text='<%# Eval("UserName")%>' runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblStylePendingCount" Text='<%# Eval("PendingStyleCount")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblhandtaskpending" Text='<%# Eval("HandOver_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblHandOver_taskdelay" Text='<%# Eval("HandOver_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblhandtaskpending2" Text='<%# Eval("HandOver_avgLt")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_taskpending" Text='<%# Eval("Patter_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_taskdelay" Text='<%# Eval("Patter_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_avgLt" Text='<%# Eval("Patter_avgLt")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_taskpending" Text='<%# Eval("Sample_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_taskdelay" Text='<%# Eval("Sample_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_avgLt" Text='<%# Eval("Sample_avgLt")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblIntialCostingBIPLPending" Text='<%# Eval("IntialCostingBIPLPending")%>'
                        runat="server" ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblIntialCostingBIPLDelay" Text='<%# Eval("IntialCostingBIPLDelay")%>'
                        runat="server" ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblIntialCostingBIPLAvg" Text='<%# Eval("IntialCostingBIPLAvg")%>'
                        runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFits_taskpending" Text='<%# Eval("Fits_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFits_taskdelay" Text='<%# Eval("Fits_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                
                    <asp:Label ID="lblFits_avgLt" Text='<%# Eval("Fits_avgLt")%>' runat="server" ForeColor="gray"></asp:Label>
                    
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSales_Qty" Text='<%# Eval("BookedQty")%>' runat="server" ForeColor="black"></asp:Label>
                      
                </ItemTemplate>
                <ItemStyle Width="59px" VerticalAlign="Top" />
            </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                  
                    <asp:Label ID="lblSales_Val" Text='<%# Eval("BookedValue")%>' runat="server" ForeColor="green"></asp:Label>
                      
                </ItemTemplate>
                <ItemStyle Width="80px" VerticalAlign="Top"  />
               
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="60px" />
    </asp:GridView>
    
   
    <br />
    <br />
    <table cellpadding="0" cellspacing="0" border="0" style="width: 1640px;  text-align: center;  margin:0px 0px 5px !important; float:left;">
        <tr>
            <th>
                PD Specific Delay Report
            </th>
        </tr>
    </table>
<br />

             <asp:GridView runat="server" ID="GridView1" Width="1740px" ShowHeader="false" AutoGenerateColumns="false"
                   OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound"
                    ShowFooter="true" CssClass="DepartmentGrid" CellPadding="0">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPdMerchant" Text='<%# Eval("FirstName")%>' runat="server" ForeColor="Black"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label runat="server" ID="lblFoo_total"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblDepartmentName" Text='<%# Eval("DepartmentName")%>' runat="server" ForeColor="gray"></asp:Label>          --%>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPendingSampleSent" Style="font-weight: bold;" Text='<%# Eval("TotalPendingSampleSent").ToString()=="0" ? "" : Eval("TotalPendingSampleSent")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_TotalPendingSampleSent" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPendingSampleSent_WithOneweek" Text='<%# Eval("PendingSampleSent_WithOneweek").ToString()=="0" ? "" : Eval("PendingSampleSent_WithOneweek")%>'
                                    runat="server" ForeColor="black"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_TotalPendingSampleSent_WithOneweek" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="70px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblETA_In_One_Week" Text='<%# Eval("ETA_In_One_Week").ToString()=="0" ? "" : Eval("ETA_In_One_Week")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_ETA_In_One_Week" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblOne_Week_Delay" Text='<%# Eval("One_Week_Delay").ToString()=="0" ? "" : Eval("One_Week_Delay")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_One_Week_Delay" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblTwoWeekDlyInweek" Text='<%# Eval("TwoWeekDlyInweek").ToString()=="0" ? "" : Eval("TwoWeekDlyInweek")%>'
                                    runat="server" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_TwoWeekDlyInweek" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCompletedHandover" Text='<%# Eval("CompletedHandover").ToString()=="0" ? "" : Eval("CompletedHandover")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_CompletedHandover" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblHandOver_Avg_Leadtime" Text='<%# Eval("HandOver_Avg_Leadtime").ToString()=="0" ? "" : Eval("HandOver_Avg_Leadtime")%>'
                                    runat="server" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_HandOver_Avg_Leadtime" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblHandOver_Completed_In_Two_Days" ForeColor="Green" Text='<%# Eval("HandOver_Completed_In_Two_Days")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_HandOver_Completed_In_Two_Days" ForeColor="Green" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblHandOver_Completed_Beyond_Two_Days" ForeColor="Red" Text='<%# Eval("HandOver_Completed_Beyond_Two_Days")%>'
                                    runat="server" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_HandOver_Completed_Beyond_Two_Days" ForeColor="Red" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCompletedPatternReady" Text='<%# Eval("CompletedPatternReady").ToString()=="0" ? "" : Eval("CompletedPatternReady")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_CompletedPatternReady" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPatternReady_Avg_Leadtime" Text='<%# Eval("PatternReady_Avg_Leadtime").ToString()=="0" ? "" : Eval("PatternReady_Avg_Leadtime")%>'
                                    runat="server" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_PatternReady_Avg_Leadtime" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPatternReady_Completed_In_three_Days" ForeColor="Green" Text='<%# Eval("PatternReady_Completed_In_three_Days")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_PatternReady_Completed_In_three_Days" ForeColor="Green" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPatternReady_Completed_Beyond_four_Days" ForeColor="Red" Text='<%# Eval("PatternReady_Completed_Beyond_four_Days")%>'
                                    runat="server" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_PatternReady_Completed_Beyond_four_Days" ForeColor="Red" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblAverage_TimeLine_Givendays" Text='<%# Eval("Average_TimeLine_Givendays").ToString()=="0" ? "" : Eval("Average_TimeLine_Givendays")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Average_TimeLine_Givendays" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblAverage_TimeTaken_days" Text='<%# Eval("Average_TimeTaken_days")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Average_TimeTaken_days" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblAvg_style_created_all" Text='<%# Eval("Avg_style_created_all").ToString()=="0" ? "" : Eval("Avg_style_created_all")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Avg_style_created_all" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblAvg_style_created_With_sample" Text='<%# Eval("Avg_style_created_With_sample").ToString()=="0" ? "" : Eval("Avg_style_created_With_sample")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Avg_style_created_With_sample" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPercent_On_time_sample_sent" ForeColor="Green" Text='<%# Eval("Percent_On_time_sample_sent")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Percent_On_time_sample_sent" ForeColor="Green" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPercent_One_Week_Delay_In_Sample" ForeColor="Red" Text='<%# Eval("Percent_One_Week_Delay_In_Sample")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Percent_One_Week_Delay_In_Sample" ForeColor="Red" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPercent_One_Week_Delay_One_Week_In_Sample" ForeColor="Red" Text='<%# Eval("Percent_One_Week_Delay_One_Week_In_Sample")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="75px" />
                            <FooterTemplate>
                                <asp:Label ID="lblfoo_Percent_One_Week_Delay_One_Week_In_Sample" ForeColor="Red"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
      
    <br />
    <br />
    <table cellpadding="0" cellspacing="0" border="0" style="width: 1670px;margin: 0px 0px 5px !important; float:left;
;
        text-align: center;">
        <tr>
            <th>
                Department Specific Delay Report
            </th>
        </tr>
    </table>
    <br/>
    <asp:GridView runat="server" ID="grdDepartmentSpecificDelayReport" Width="1740px"
        ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="grdDepartmentSpecificDelayReport_RowDataBound"
        OnDataBound="grdDepartmentSpecificDelayReport_DataBound" ShowFooter="true" CssClass="DepartmentGrid"
        CellPadding="0" CellSpacing="0">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPdMerchant" Text='<%# Eval("FirstName")%>' runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="90px" />
                <FooterTemplate>
                    <asp:Label runat="server" ID="lblFoo_total"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblDepartmentName" Text='<%# Eval("DepartmentName")%>' runat="server"
                        ForeColor="Blue"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTotalPendingSampleSent" Style="font-weight: bold;" Text='<%# Eval("TotalPendingSampleSent").ToString()=="0" ? "" : Eval("TotalPendingSampleSent")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_TotalPendingSampleSent" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPendingSampleSent_WithOneweek" Text='<%# Eval("Delay_And_Upcomming_In_Aweek").ToString()=="0" ? "" : Eval("Delay_And_Upcomming_In_Aweek")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblfoo_TotalPendingSampleSent_WithOneweek" runat="server"></asp:Label>
                </FooterTemplate>
                <ItemStyle Width="70px" VerticalAlign="Top" />
            </asp:TemplateField>
          <%--  <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTotalPendingSampleSent" Style="font-weight: bold;" Text='<%# Eval("TotalPendingSampleSent").ToString()=="0" ? "" : Eval("TotalPendingSampleSent")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_TotalPendingSampleSent" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblETA_In_One_Week" Text='<%# Eval("ETA_In_One_Week").ToString()=="0" ? "" : Eval("ETA_In_One_Week")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_ETA_In_One_Week" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblOne_Week_Delay" Text='<%# Eval("One_Week_Delay").ToString()=="0" ? "" : Eval("One_Week_Delay")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_One_Week_Delay" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTwoWeekDlyInweek" Text='<%# Eval("TwoWeekDlyInweek").ToString()=="0" ? "" : Eval("TwoWeekDlyInweek")%>'
                        runat="server" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_TwoWeekDlyInweek" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblCompletedHandover" Text='<%# Eval("CompletedHandover").ToString()=="0" ? "" : Eval("CompletedHandover")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="70px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_CompletedHandover" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblHandOver_Avg_Leadtime" Text='<%# Eval("HandOver_Avg_Leadtime").ToString()=="0" ? "" : Eval("HandOver_Avg_Leadtime")%>'
                        runat="server" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_HandOver_Avg_Leadtime" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblHandOver_Completed_In_Two_Days" ForeColor="Green" Text='<%# Eval("HandOver_Completed_In_Two_Days")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_HandOver_Completed_In_Two_Days" ForeColor="Green" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblHandOver_Completed_Beyond_Two_Days" ForeColor="Red" Text='<%# Eval("HandOver_Completed_Beyond_Two_Days")%>'
                        runat="server" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_HandOver_Completed_Beyond_Two_Days" ForeColor="Red" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblCompletedPatternReady" Text='<%# Eval("CompletedPatternReady").ToString()=="0" ? "" : Eval("CompletedPatternReady")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_CompletedPatternReady" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatternReady_Avg_Leadtime" Text='<%# Eval("PatternReady_Avg_Leadtime").ToString()=="0" ? "" : Eval("PatternReady_Avg_Leadtime")%>'
                        runat="server" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_PatternReady_Avg_Leadtime" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatternReady_Completed_In_three_Days" ForeColor="Green" Text='<%# Eval("PatternReady_Completed_In_three_Days")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_PatternReady_Completed_In_three_Days" ForeColor="Green" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatternReady_Completed_Beyond_four_Days" ForeColor="Red" Text='<%# Eval("PatternReady_Completed_Beyond_four_Days")%>'
                        runat="server" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_PatternReady_Completed_Beyond_four_Days" ForeColor="Red" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblAverage_TimeLine_Givendays" Text='<%# Eval("Average_TimeLine_Givendays").ToString()=="0" ? "" : Eval("Average_TimeLine_Givendays")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Average_TimeLine_Givendays" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblAverage_TimeTaken_days" Text='<%# Eval("Average_TimeTaken_days")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Average_TimeTaken_days" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblAvg_style_created_all" Text='<%# Eval("Avg_style_created_all").ToString()=="0" ? "" : Eval("Avg_style_created_all")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Avg_style_created_all" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblAvg_style_created_With_sample" Text='<%# Eval("Avg_style_created_With_sample").ToString()=="0" ? "" : Eval("Avg_style_created_With_sample")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Avg_style_created_With_sample" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPercent_On_time_sample_sent" ForeColor="Green" Text='<%# Eval("Percent_On_time_sample_sent")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Percent_On_time_sample_sent" ForeColor="Green" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPercent_One_Week_Delay_In_Sample" ForeColor="Red" Text='<%# Eval("Percent_One_Week_Delay_In_Sample")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Percent_One_Week_Delay_In_Sample" ForeColor="Red" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPercent_One_Week_Delay_One_Week_In_Sample" ForeColor="Red" Text='<%# Eval("Percent_One_Week_Delay_One_Week_In_Sample")%>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" />
                <FooterTemplate>
                    <asp:Label ID="lblfoo_Percent_One_Week_Delay_One_Week_In_Sample" ForeColor="Red"
                        runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    </form>
</body>
</html>
