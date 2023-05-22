<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOutHouseReport.aspx.cs" Inherits="iKandi.Web.frmOutHouseReport" %>

<%@ Register Src="UserControls/Reports/frmOutHouse_AuditEntry_Report.ascx" TagName="frmOutHouse_AuditEntry_Report"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .item_list_Report th
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize;
            border: 1px solid #b7b4b4 !important;
            text-align: center;
            font-weight: normal;
            font-size: 12px;
            font-family: Calibri, sans-serif;
        }
        h2
        {
            background: #39589C;
            color: #e7e4fb;
            font-size: 12px;
            margin: 5px 0px;
            padding: 5px;
            width: 1150px;
            text-align: center;
        }
        
        .fontsizecolor
        {
            font-family: "Calibri" , sans-serif;
            font-size: 13px;
            border: 1px solid #999999;
        }
        .fontsizecolor2
        {
            font-family: "Calibri" , sans-serif;
            font-size: 13px;
            border: 1px solid #999999;
        }
        .itemborder
        {
            border: 1px solid gray;
            padding-left: 3px;
        }
        .fontsizecolor3
        {
            font-family: "Calibri" , sans-serif;
            font-size: 13px;
            border: 1px solid #999999;
        }
        form 
        {
            padding-left:5px;
            }
          
    </style>
</head>
<body>
 Hi,
<br/>
<br/>
Please find the attached (Daily Out-House Style and VA) report.
<br/>
   <br/>                                        
    <form id="form1" runat="server">
    <div id="divhtml" runat="server">
        <span>Please click here to access
            <asp:HyperLink ID="QAComplienceMailOut_House" runat="server" Target="_blank">Compliance Audit Report For OutHouse </asp:HyperLink>
        </span>
        <br />
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="max-width: 581px">
            <!--<h2 style="background: #39589C; font-family: Calibri, sans-serif; color: #e7e4fb; font-size: 13px; margin: 5px 0px 0px;
            padding: 5px; width: 572px; max-width:572px; text-align: center;">
            Pending Report for / Value Added Style Code</h2>
            <br />-->
             <tr>   
                <td style="background: #39589C; color: #e7e4fb; font-family: Calibri, sans-serif;
                    font-size: 13px; margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px;
                    text-align: center;">
                    Costed Outhouse / VA Style Code Details
                </td>
              </tr>
        </table>
        <asp:GridView ID="grdva" OnRowDataBound="grdva_RowDataBound" AutoGenerateColumns="false"
            runat="server" ShowHeader="false" Width="581px" CellPadding="0" CellSpacing="0"
            ShowFooter="false" CssClass="item_list_Report" BorderColor="gray">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFabricatorName" runat="server" ForeColor="black" Text='<%# Eval("TotalOHStyleCode")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblTotal_Machines" runat="server" ForeColor="black" Text='<%# Eval("DoneOHStyleCode")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine_Total" runat="server" ForeColor="black" Text='<%# Eval("PendingOHStyleCode")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine_45Days" runat="server" ForeColor="black" Text='<%# Eval("PendingOHStyleCodeWithin45days")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine_beyond_45days" runat="server" ForeColor="black"
                            Text='<%# Eval("PendingOHStyleCodeBeyond")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <%--  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine_CurrentMonth" runat="server" ForeColor="black" Text='<%# Eval("TotalValueAddedStyle")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>--%>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblStyleCosted" runat="server" ForeColor="black" Text='<%# Eval("TotalValueAddedStyle")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblStyleCosted_CurrentMonth" runat="server" ForeColor="black" Text='<%# Eval("DoneValueAddedStyleCode")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Psc_PerDayOutPut_Total" runat="server" ForeColor="black"
                            Text='<%# Eval("PendingValueAddedStyleCode")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Psc_PerDayOutPut_45Days" runat="server" ForeColor="black"
                            Text='<%# Eval("PendingValueAddedStyleCodein45Days")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Psc_PerDayOutPut_beyond_45days" runat="server" ForeColor="black"
                            Text='<%# Eval("PendingValueAddedStyleCodeBeyond")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
       <img id="Month_PM_Img_Chart" runat="server" style="max-width: 400px;"><br />
       <img id="Month_Delay_Img_Chart" runat="server" style="max-width: 400px;">&nbsp; 
        <table border="0" cellpadding="0" cellspacing="0" style="max-width: 700px">
         <tr>
         
            <td style="background: #39589C; color: #E7E4FB; font-size: 13px; font-family: Calibri, sans-serif;
                margin: 0px 0px; padding: 5px; width: 700px; max-width: 700px; text-align: center;">
                Fabricator in Production</td>
            </tr>
        </table>
        <asp:GridView ID="grdOuthouseSummary" AutoGenerateColumns="false" runat="server"
            ShowHeader="false" Width="700px" CellPadding="0" CellSpacing="0" OnRowDataBound="grdOuthouseSummary_RowDataBound"
            ShowFooter="false" CssClass="item_list_Report" BorderColor="gray">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFabricatorName" runat="server" ForeColor="black" Text='<%# Eval("FabricatoryName")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="180px" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblTotal_Machines" runat="server" ForeColor="black" Text='<%# Eval("Total_Machines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstquarter_Machines" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FirstQuarter_Average_Machine"))== "0" ? "" : Eval("FirstQuarter_Average_Machine")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondquarter_Machines" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("SecondQuarter_Average_Machine"))== "0" ? "" : Eval("SecondQuarter_Average_Machine")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdquarter_Machines" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("ThirdQuarter_Average_Machine"))== "0" ? "" : Eval("ThirdQuarter_Average_Machine")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourtquarter_Machines" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FourthQuarter_Average_Machine"))== "0" ? "" : Eval("FourthQuarter_Average_Machine")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Machines" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_Average_Machine"))== "0" ? "" : Eval("CurrentMonth_Average_Machine")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_StyleCosted" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FirstQuarter_StyleCosted"))== "0" ? "" : Eval("FirstQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_StyleCosted" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("SecondQuarter_StyleCosted"))== "0" ? "" : Eval("SecondQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_StyleCosted" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("ThirdQuarter_StyleCosted"))== "0" ? "" : Eval("ThirdQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_StyleCosted" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FourthQuarter_StyleCosted"))== "0" ? "" : Eval("FourthQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_StyleCosted" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_StyleCosted"))== "0" ? "" : Eval("CurrentMonth_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_Average_Pcs_PerDayOutPut" runat="server" ForeColor="black"
                            Text='<%# Convert.ToString(Eval("FirstQuarter_Average_Pcs_PerDayOutPut"))== "0" ? "" : Eval("FirstQuarter_Average_Pcs_PerDayOutPut")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_Average_Pcs_PerDayOutPut" runat="server" ForeColor="black"
                            Text='<%# Convert.ToString(Eval("SecondQuarter_Average_Pcs_PerDayOutPut"))== "0" ? "" : Eval("SecondQuarter_Average_Pcs_PerDayOutPut")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_Average_Pcs_PerDayOutPut" runat="server" ForeColor="black"
                            Text='<%# Convert.ToString(Eval("ThirdQuarter_Average_Pcs_PerDayOutPut"))== "0" ? "" : Eval("ThirdQuarter_Average_Pcs_PerDayOutPut")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_Average_Pcs_PerDayOutPut" runat="server" ForeColor="black"
                            Text='<%# Convert.ToString(Eval("FourthQuarter_Average_Pcs_PerDayOutPut"))== "0" ? "" : Eval("FourthQuarter_Average_Pcs_PerDayOutPut")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Average_Pcs_PerDayOutPut" runat="server" ForeColor="black"
                            Text='<%# Convert.ToString(Eval("CurrentMonth_Average_Pcs_PerDayOutPut"))== "0" ? "" : Eval("CurrentMonth_Average_Pcs_PerDayOutPut")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FirstQuarter_Rate"))== "0" ? "" : Eval("FirstQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("SecondQuarter_Rate"))== "0" ? "" : Eval("SecondQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("ThirdQuarter_Rate"))== "0" ? "" : Eval("ThirdQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FourthQuarter_Rate"))== "0" ? "" : Eval("FourthQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_Rate"))== "0" ? "" : Eval("CurrentMonth_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_Production" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FirstQuarter_Production"))== "0" ? "" : Eval("FirstQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_Production" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("SecondQuarter_Production"))== "0" ? "" : Eval("SecondQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_Production" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("ThirdQuarter_Production"))== "0" ? "" : Eval("ThirdQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_Production" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FourthQuarter_Production"))== "0" ? "" : Eval("FourthQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Production" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_Production"))== "0" ? "" : Eval("CurrentMonth_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_AvgDelay" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FirstQuarter_AvgDelay"))== "0" ? "" : Eval("FirstQuarter_AvgDelay")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_AvgDelay" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("SecondQuarter_AvgDelay"))== "0" ? "" : Eval("SecondQuarter_AvgDelay")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_AvgDelay" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("ThirdQuarter_AvgDelay"))== "0" ? "" : Eval("ThirdQuarter_AvgDelay")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_AvgDelay" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("FourthQuarter_AvgDelay"))== "0" ? "" : Eval("FourthQuarter_AvgDelay")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_AvgDelay" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_AvgDelay"))== "0" ? "" : Eval("CurrentMonth_AvgDelay")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
       
     <%--   <table border="0" cellpadding="0" cellspacing="0" style="max-width: 700px;">
        <tr>
            <td style="background: #39589C; color: #e7e4fb; font-family: Calibri, sans-serif;
                font-size: 13px; margin: 0px 0px; padding: 5px; width: 700px; max-width: 700px;
                text-align: center;">
                Fabricator with Initial Rate</td>
        </tr>
        </table>--%>
        <%--<asp:GridView ID="grdfabavgwithoutstitch" AutoGenerateColumns="false" runat="server"
            ShowHeader="false" Width="700px" CellPadding="0" CellSpacing="0" OnRowDataBound="grdfabavgwithoutstitch_RowDataBound"
            ShowFooter="false" CssClass="item_list_Report" BorderColor="gray">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFabricatorName" runat="server" ForeColor="#808080" Text='<%# Eval("Fabricator_Name")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblTotal_Machines" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("Total_Machines"))== "0" ? "" : Eval("Total_Machines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_StyleCosted" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FirstQuarter_StyleCosted"))== "0" ? "" : Eval("FirstQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_StyleCosted" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("SecondQuarter_StyleCosted"))== "0" ? "" : Eval("SecondQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_StyleCosted" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("ThirdQuarter_StyleCosted"))== "0" ? "" : Eval("ThirdQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_StyleCosted" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FourthQuarter_StyleCosted"))== "0" ? "" : Eval("FourthQuarter_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_StyleCosted" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("CurrentMonth_StyleCosted"))== "0" ? "" : Eval("CurrentMonth_StyleCosted")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_Rate" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FirstQuarter_Rate"))== "0" ? "" : Eval("FirstQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_Rate" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("SecondQuarter_Rate"))== "0" ? "" : Eval("SecondQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_Rate" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("ThirdQuarter_Rate"))== "0" ? "" : Eval("ThirdQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_Rate" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FourthQuarter_Rate"))== "0" ? "" : Eval("FourthQuarter_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Rate" runat="server" ForeColor="black" Text='<%# Convert.ToString(Eval("CurrentMonth_Rate"))== "0" ? "" : Eval("CurrentMonth_Rate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstQuarter_Production" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FirstQuarter_Production"))== "0" ? "" : Eval("FirstQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblSecondQuarter_Production" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("SecondQuarter_Production"))== "0" ? "" : Eval("SecondQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblThirdQuarter_Production" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("ThirdQuarter_Production"))== "0" ? "" : Eval("ThirdQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray"/>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblFourthQuarter_Production" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("FourthQuarter_Production"))== "0" ? "" : Eval("FourthQuarter_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="itemborder">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentMonth_Production" runat="server" ForeColor="#808080" Text='<%# Convert.ToString(Eval("CurrentMonth_Production"))== "0" ? "" : Eval("CurrentMonth_Production")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px" BorderColor="gray" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
       <%-- <br />--%>
        <br />
        <%-- <h2 style="background: #39589C; color: #e7e4fb; font-size: 12px; margin: 5px 0px;
            padding: 5px; width: 1150px; text-align: center;">
            Fabricator with Initial Rate</h2>
        <asp:GridView ID="grdnew" AutoGenerateColumns="false" runat="server" ShowHeader="false"
            Width="1150px" CellPadding="0" CellSpacing="0" OnRowDataBound="grdnew_RowDataBound"
            ShowFooter="false" CssClass="item_list_Report">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblFabricatorName" runat="server" ForeColor="gray" Text='<%# Eval("Fabricator_Name")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTotal_Machines" runat="server" ForeColor="gray" Text='<%# Eval("Total_Machines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine" runat="server" ForeColor="gray" Text='<%# Eval("Avrage_Machine_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Machine_CurrentMonth" runat="server" ForeColor="gray" Text='<%# Eval("StyleCosted_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblStyleCosted" runat="server" ForeColor="gray" Text='<%# Eval("StyleCosted_CurrentMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblStyleCosted_CurrentMonth" runat="server" ForeColor="gray" Text='<%# Eval("RATE_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Psc_PerDayOutPut" runat="server" ForeColor="gray" Text='<%# Eval("Avrage_Psc_PerDayOutPut_PreviousMonts")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAvrage_Psc_PerDayOutPut_CurrentMonth" runat="server" ForeColor="black"
                            Text='<%# Eval("Avrage_Psc_PerDayOutPut_CurrentMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblIntialMultiplier" runat="server" ForeColor="gray" Text='<%# Eval("RATE_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblIntialMultiplier_CurrentMonth" runat="server" ForeColor="gray"
                            Text='<%# Eval("RATE_CurrentMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblProductionMultiplier" runat="server" ForeColor="gray" Text='<%# Eval("PRODUCTION_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblProductionMultiplier_CurrentMonth" runat="server" ForeColor="gray"
                            Text='<%# Eval("PRODUCTION_CurrentMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAvgDelay" runat="server" ForeColor="gray" Text='<%# Eval("AVGDELAY_PreviousMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAvgDelay_CurrentMonth" runat="server" ForeColor="gray" Text='<%# Eval("AVGDELAY_CurrentMonth")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="10px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
        <uc1:frmOutHouse_AuditEntry_Report ID="frmOutHouse_AuditEntry_Report1" runat="server" />
    </div>
    <font color="#548dd4"> Thanks & Best Regards </font> 
<br/>                                                                                                                                                   
BIPL Admin
    </form>
</body>
</html>
