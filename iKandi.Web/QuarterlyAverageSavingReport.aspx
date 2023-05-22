<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuarterlyAverageSavingReport.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.QuarterlyAverageSavingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .AddClass_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
            width: 300px;
        }
        .AddClass_Table th
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: gray;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            height: 18px;
        }
        .txtCenter
        {
            text-align: center;
        }
        .ColorGreen
        {
            color: green !important;
        }
        .ColorRed
        {
            color: red !important;
        }
        .txtcolorBlue
        {
            color: blue !important;
        }
        .AddClass_Table td input[type="text"]
        {
            width: 98%;
            height: 12px;
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            margin: 1px 0px;
            text-transform: capitalize;
        }
        td[colspan='4']
        {
            border-bottom-color: #999;
        }
        .ColorGray
        {
            color: gray !important;
        }
        .btnbutton
        {
            background: #3286d8;
            color: #fff;
            border: 1px solid #3286d8;
            padding: 2px 9px;
            border-radius: 3px;
            font-size: 11px;
            line-height: 13px;
            margin-left: 7px;
        }
        
        .txtRightPadding
        {
            text-align: right !important;
            padding-right: 1% !important;
        }
        .txtRightPadding1
        {
            text-align: right !important;
            padding-right: 1% !important;
        }
        p
        {
            width: 12px !important;
        }
        .AddClass_Table th .innerTableAvg th
        {
            border: 0px !important;
            padding: 0px 3px;
        }
        .txtRight
        {
            text-align: right !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="updateFinancialSaving" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdFinancialSavingReport" runat="server" AutoGenerateColumns="false"
                HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px"
                ShowHeader="false" CssClass="AddClass_Table" ShowFooter="false" OnRowCreated="grdFinancialSavingReport_RowCreated"
                OnRowDataBound="grdFinancialSavingReport_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblMonth" Text='<%#Eval("Exfactory") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblCostOrderRev" Text='<%#Eval("Cost_Order_Rev") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" CssClass="txtRight" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblCostOrderWeighted" Text='<%#Eval("Cost_Order_Weighted") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="txtRight" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblOrderCutRev" Text='<%#Eval("Order_Cut_Rev") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" CssClass="txtRight" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblOrderCutWeighted" Text='<%#Eval("Order_Cut_Weighted") %>' runat="server"></asp:Label>
                            <asp:HiddenField ID="lblQuantity" runat="server" Value='<%#Eval("Quantity")%>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="txtRight" Width="50px" />
                    </asp:TemplateField>                    
                </Columns>
                <EmptyDataTemplate>
                    <label style="color: Red">
                        NO RECORD FOUND</label></EmptyDataTemplate>
            </asp:GridView>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table class="AddClass_Table" style="display:none;" runat="server" id="diffSummaryReport">
        <thead>
            <tr>
                <th colspan="4">
                    Difference Summary Report
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    Difference in Cost to Order
                </th>
                <th colspan="2">
                    Difference in Order to Cut
                </th>
            </tr>
            <tr>
                <th>
                    Total Revenue
                </th>
                <th>
                    Weighted %
                </th>
                <th>
                    Total Revenue
                </th>
                <th>
                    Weighted %
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
  
    <table class="AddClass_Table" runat="server" id="avgDeviationReport">
        <thead>
            <tr>
                <th colspan="4">
                    Average Deviation Report
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    Cost to Order %
                </th>
                <th colspan="2">
                    Order to Cut %
                </th>
            </tr>
            <tr>
                <th>
                    Between 0 to 1
                </th>
                <th>
                    Beyond
                </th>
                <th>
                    Between 0 to 1
                </th>
                <th>
                    Beyond
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <br />
    <br />
    <%-- <table class="AddClass_Table" runat="server" id="monthlyFinancialSavingReport">
        <thead>
            <tr>
                <th colspan="5">
                    Monthly Financial Saving Report (2020-2021)
                </th>
            </tr>
            <tr>
                <th rowspan="2">
                    Month
                </th>
                <th colspan="2">
                    Cost to Order
                </th>
                <th colspan="2">
                    Order to Cut
                </th>
            </tr>
            <tr>
                <th>
                    Revenue
                </th>
                <th>
                    Weighted %
                </th>
                <th>
                    Revenue
                </th>
                <th>
                    Weighted %
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>--%>
    <%--<table class="AddClass_Table" runat="server" id="avrDeviation">
        <thead>
            <tr>
                <th colspan="3">
                    Average Deviation (Cut Avg. - Order Avg.) (<asp:Label ID="lblFinancialYr1" runat="server"></asp:Label>)
                </th>
            </tr>
            <tr>
                <th>
                </th>
                <th>
                    <table cellspacing="0" cellpadding="0" border="0" class="innerTableAvg" style="border: 0px;">
                        <tr>
                            <th>
                                <img src="http://192.168.0.4:81/pic/minus.png" />
                            </th>
                            <th rowspan="2" style="border-right: 1px solid #9999">
                                <span style="position: relative; top: -2px; left: 4px;"><span style="color: black">0.05
                                    Mtr.</span></span>
                            </th>
                            <th>
                                <img src="http://192.168.0.4:81/pic/minus.png" />
                            </th>
                            <th rowspan="2">
                                <span style="position: relative; top: -2px; left: 4px;"><span style="color: black">0.01
                                    Kg</span></span>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <img src="http://192.168.0.4:81/pic/plus-w.png" style="width: 12px; position: relative;
                                    top: 0px;" />
                            </th>
                            <th>
                                <img src="http://192.168.0.4:81/pic/plus-w.png" style="width: 12px; position: relative;
                                    top: 0px;" />
                            </th>
                        </tr>
                    </table>
                </th>
                <th>
                    Beyond
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <br />
    <br />
    <table class="AddClass_Table" runat="server" id="monthlySavingReport" style="width: 350px;">
        <thead>
            <tr>
                <th colspan="7">
                    Monthly Financial Savings Report (<asp:Label ID="lblFinancialYr2" runat="server"></asp:Label>)
                </th>
            </tr>
            <tr>
                <th rowspan="3">
                    Months
                </th>
                <th colspan="3">
                    Order Avg. - Cost Avg.
                </th>
                <th colspan="3">
                    Cut Avg. - Order Avg.
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    Qty. Saved
                </th>
                <th rowspan="2" style="color: green">
                    Revenue
                </th>
                <th colspan="2">
                    Qty. Saved
                </th>
                <th rowspan="2" style="color: green">
                    Revenue
                </th>
            </tr>
            <tr>
                <th style="color: black">
                    Mtr.
                </th>
                <th style="color: black">
                    Kg
                </th>
                <th style="color: black">
                    Mtr.
                </th>
                <th style="color: black">
                    Kg
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>--%>
    <table style="width: 50%; margin-bottom: 15px;">
        <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="Fabric_Average_Saving_C47" width="640" style="max-width: 640px;
                    display: block;" />
            </td>
              <td style="text-align: left; width: 33%;padding-right:20px;">
                <img runat="server" id="Fabric_Average_Saving_C45_46" width="640" style="max-width: 640px;
                    display: block;" />
            </td>
        </tr>
       
        <tr>
            <td style="text-align: left; width: 33%;padding-right:20px;">
                <img runat="server" id="Fabric_Average_Saving_D_169" width="640" style="max-width: 640px;
                    display: block;" />
            </td>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="biplOrdertoCutSavingImg" width="640" style="max-width: 640px;
                    display: block;" />
            </td>
        </tr>
       
    </table>
    </form>
</body>
</html>
