<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmActivityQALaxmanReport.aspx.cs"
    Inherits="iKandi.Web.FrmActivityQALaxmanReport" %>


<%--<%@ Register Src="UserControls/Lists/TopThreeFaultsSummery.ascx" TagName="TopThreeFaultsSummery"
    TagPrefix="uc1" %>--%>
<%--<%@ Register Src="UserControls/Reports/QcFualtSummaryReport.ascx" TagName="QcFualtSummaryReport"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/Reports/frmQcLineManSummeryReport.ascx" TagName="frmQcLineManSummeryReport"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/Reports/frmComplianceQAuditReport.ascx" TagName="frmComplianceQAuditReport"
    TagPrefix="uc4" %>--%>
<%@ Register Src="UserControls/Reports/MonthlyProductionDetails.ascx" TagName="MonthlyProductionDetails"
    TagPrefix="uc3" %>
    <%@ Register Src="UserControls/Reports/QuarterlyProductionDetails.ascx" TagName="QuarterlyProductionDetails"
    TagPrefix="uc4" %>
    <%@ Register Src="UserControls/Reports/IncentiveScorePolicyDetails.ascx" TagName="IncentiveScorePolicyDetails"
    TagPrefix="uc5" %>
     

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana;
        }
        table
        {
            font-family: arial,halvetica;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            color: #575759;
            font-weight: normal;
            font-size: 10px;
            padding: 0px 0px;
            font-family: arial,halvetica;
            border-color: #999999;
            text-align: center;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: gray !important;
        }
        td
        {
            border-color: gray !important;
        }
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        h2
        {
            font-size: 14px;
            font-weight: bold;
            padding: 0px;
            margin: 0px;
            text-align: center;
            font-weight: normal;
            font-family: arial,halvetica;
            background: #dddfe4 !important;
            color: #575759 !important;
        }
        .row-fir th
        {
            font-weight: normal;
            font-size: 10px;
        }
        table td table td
        {
            border-color: gray;
            border: 1px solid #999;
        }
        .blue1
        {
            color: #39589C;
        }
        .al-right
        {
            text-align: right;
        }
        .leftalign
        {
            text-align: left;
            vertical-align: top;
        }
        .f-12
        {
            font-size: 12px !important;
        }
        .f-12 table td
        {
            font-size: 12px !important;
        }
        td
        {
             font-size: 11px !important;;
            }
        .lst-day
        {
            text-align: left;
        }
        #gridshipemtNew tbody > tr:last-child > td
        {
            border-bottom: 0;
        }
        .hide-td
        {
            display: none;
        }
        h4
        {
            font-size: 14px;
            font-weight: bold;
            margin: 0 0 5px;
            padding: 6px;
            background: #39589C;
            text-align: center;
            color: #ffffff;
            font-weight: normal;
            font-family: arial,halvetica;
        }
        .hide-div-grid
        {
            display: none !important;
            height: 0px !important;
            overflow: hidden;
            max-height: 0px !important;
            mso-hide: all;
            line-height: 0px !important;
        }
        .hide-div-grid tr
        {
            display: none;
            mso-hide: all;
        }
        .datarepeat tr td
        {
            padding-bottom: 3px; /* border-bottom: 1px solid #ddd;*/
        }
        .datarepeat tr:last-child td
        {
            border-bottom: 0 !important;
        }
      .sum_col_d169
            {
                width:80px !important;
                
            }
          .Colwidth_d169
            {
                width:60px !important;
            }
           
           .frmlineqctable > td > table > th
           {
               border-right:1px solid #999 !important;
            }
            .frmlineqctable > td > table > td
           {
               border-left:1px solid #999 !important;
            } 
             th.hederborderright
              {
                  border-right:1px solid gray !important;
                }
                
    </style>
     <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script>
      $(document).ready(function () {
          $("#widthheadercol").css("width", "80px");
      });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <span> 
       Please click below links for detailed reports.
    </span>
    <br /><br />
    <span> 
         Compliance Audit Report : <asp:HyperLink ID="QAComplienceMailunitId_3_Process_1" runat="server" Target="_blank"> C-47 </asp:HyperLink>
    &nbsp;|&nbsp;<asp:HyperLink ID="QAComplienceMailunitId_11_Process_1" runat="server" Target="_blank"> C-45-46 </asp:HyperLink>
     <%--<asp:HyperLink ID="QAComplienceMailunitId_169_Process_1" runat="server" Target="_blank"> D-169 </asp:HyperLink>--%>
     <%-- &nbsp;|&nbsp;<asp:HyperLink ID="QAComplienceMailunitId_120_Process_1" runat="server" Target="_blank"> C-52 </asp:HyperLink>--%>
    &nbsp;|&nbsp;<asp:HyperLink ID="FrmComplianceAudit" runat="server" Target="_blank"> BIPL</asp:HyperLink> 
    </span>
    <br />
    <br />
    <span>  
       Quality Audit Report :  &nbsp;&nbsp;  &nbsp;&nbsp;  <asp:HyperLink ID="QAComplienceMailunitId_3_Process_2" runat="server" Target="_blank"> C-47 </asp:HyperLink>
    &nbsp;|&nbsp;<asp:HyperLink ID="QAComplienceMailunitId_11_Process_2" runat="server" Target="_blank"> C-45-46 </asp:HyperLink>
    <%--<asp:HyperLink ID="QAComplienceMailunitId_169_Process_2" runat="server" Target="_blank"> D-169</asp:HyperLink>--%>
    <%--&nbsp;|&nbsp;<asp:HyperLink ID="QAComplienceMailunitId_120_Process_2" runat="server" Target="_blank"> C-52</asp:HyperLink>--%>
    &nbsp;|&nbsp;<asp:HyperLink ID="FrmQualityAudit" runat="server" Target="_blank"> BIPL</asp:HyperLink> 
    </span>

    <br />
    <br />
     <span> 
       <%-- <asp:HyperLink ID="FactorySecifyQcFaultSummaryReport" runat="server" Target="_blank">Factory Specific QC Faults Summary Report</asp:HyperLink>--%>
      <asp:HyperLink ID="FrmQCPerformance_Report" runat="server" Target="_blank">QC Performance Report</asp:HyperLink>
    </span>
    <br />
    <br />
     <span>  
     <asp:HyperLink ID="LineManPerformanceReport" runat="server" Target="_blank">Line Man Performance Report</asp:HyperLink>
       <%-- &nbsp;|&nbsp;<asp:HyperLink ID="LineManAchievementPerformanceReport" runat="server" Target="_blank">Line Man Achievement Performance Report </asp:HyperLink>--%>
    </span>
    <br />
    <br />

  
    <table cellpadding="0" cellspacing="0" border="0" width="750px" style="background: #dddfe4;
        color: #575759; padding: 6px; font-family: arial,halvetica;">
        <tr>
            <td style="font-size: 14px; width: 550px">
                Production Performance
            </td>
            <td style="text-align: right; font-size: 14px; padding-right: 10px; width: 200px">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
      <uc3:MonthlyProductionDetails ID="MonthlyProductionDetails1" runat="server" />
      <br /><br />
    <uc5:IncentiveScorePolicyDetails ID="IncentiveScorePolicyDetails3" runat="server" />
    <br /><br />
    <uc4:QuarterlyProductionDetails ID="QuarterlyProductionDetails2" runat="server" />   
    
    
       
    <table cellpadding="0" cellspacing="0" border="0" width="1100px">
        <tr>
            <td>
              <%--  <uc2:QcFualtSummaryReport ID="QcFualtSummaryReport1" runat="server" />--%>
            </td>
        </tr>
    </table>
   
   <%-- <uc3:frmQcLineManSummeryReport ID="frmQcLineManSummeryReport1" runat="server" />--%>
   
   <%-- <uc4:frmComplianceQAuditReport ID="frmComplianceQAuditReport1" runat="server" />--%>
    <br />
    <table cellpadding="0" cellspacing="0" border="1" class="item_list_Report " style="width: 1100px;
        border-collapse: collapse;" id="monthlyHead" runat="server">
        <tr>
            <th colspan="19">
                <h2>
                    Monthly QA Activity Report
                </h2>
            </th>
        </tr>
        <tr>
            <th rowspan="2" style="width: 70px;">
                Week
            </th>
            <th colspan="6">
                C-47
            </th>
            <th colspan="6">
                C-45-46
            </th>
            <th colspan="6">
                Bipl
            </th>
        </tr>
        <tr>
            <th style="width: 50px;">
                RiskA
            </th>
            <th style="width: 50px;">
                Hoppm
            </th>
            <th style="width: 50px;">
                Top Sent
            </th>
            <th style="width: 50px;">
                Inline
            </th>
            <th style="width: 50px;">
                Online
            </th>
            <th style="width: 50px;">
                Final
            </th>
            <th style="width: 50px;">
                RiskA
            </th>
            <th style="width: 50px;">
                Hoppm
            </th>
            <th style="width: 50px;">
                Top Sent
            </th>
            <th style="width: 50px;">
                Inline
            </th>
            <th style="width: 50px;">
                Online
            </th>
            <th style="width: 50px;">
                Final
            </th>
            <th style="width: 50px;">
                RiskA
            </th>
            <th style="width: 50px;">
                Hoppm
            </th>
            <th style="width: 50px;">
                Top Sent
            </th>
            <th style="width: 50px;">
                Inline
            </th>
            <th style="width: 50px;">
                Online
            </th>
            <th style="width: 50px;">
                Final
            </th>
        </tr>
    </table>
    <asp:GridView ID="gridshipemtNew" AutoGenerateColumns="false" runat="server" OnRowDataBound="gridshipemtNew_RowDataBound"
        ShowHeader="false" Width="1100" CellPadding="0" ShowFooter="true" FooterStyle-Height="30px"
        CssClass="item_list_Report" Visible="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    &nbsp; &nbsp;
                    <asp:Label ID="lblWeekDayRange" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnweekMax" runat="server" Value='<%#Eval("maxvalue")%>' />
                    <asp:HiddenField ID="hdnweekMin" runat="server" Value='<%#Eval("minvalues")%>' />
                </ItemTemplate>
                <ItemStyle Width="70" ForeColor="Gray" BackColor="#f5f2f1" />
                <FooterTemplate>
                    <strong>Month total</strong>
                </FooterTemplate>
                <FooterStyle ForeColor="Gray" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <%--C47-------------------------------------------------------------------------------------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountrisk47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountriskfoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounthoppm47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounthoppmfoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounttopsent47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounttopsentfoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountInline47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountInlinefoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountOnline47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountOnlinefoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountFinal47" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountFinalfoter47" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <%--C45 46-------------------------------------------------------------------------------------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountrisk4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountriskfoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounthoppm4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounthoppmfoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounttopsent4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounttopsentfoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountInline4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountInlinefoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountOnline4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountOnlinefoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountFinal4546" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountFinalfoter4546" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <%--BIPL-------------------------------------------------------------------------------------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountriskBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountriskfoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounthoppmBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounthoppmfoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcounttopsentBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcounttopsentfoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountInlineBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountInlinefoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountOnlineBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountOnlinefoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblcountFinalBipl" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblcountFinalfoterBipl" Font-Bold="true" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle BackColor="#f5f2f1" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" style="width: 1100px; display: none;" border="0"
        class="month" runat="server" id="tbllastDay" bgcolor="#cccccc">
        <tr style="height: 30px;">
            <td style="width: 70px; color: Gray; border-right: 1px solid #aaa; border-left: 1px solid #aaa;">
                <strong>Last Day</strong>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblrisk47" Text='<%#Eval("Risk")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblhoppm47" Text='<%#Eval("Hoppm")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lbltopsent47" Text='<%#Eval("Topsent")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblInline47" Text='<%#Eval("Inline")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblonline47" Text='<%#Eval("Online")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblfinal47" Text='<%#Eval("Final")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <%--C45-C46--%>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblrisk4546" Text='<%#Eval("Risk")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblhoppm4546" Text='<%#Eval("Hoppm")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lbltopsent4546" Text='<%#Eval("Topsent")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblInline4546" Text='<%#Eval("Inline")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblonline4546" Text='<%#Eval("Online")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblfinal4546" Text='<%#Eval("Final")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <%--bipl--%>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblriskbipl" Text='<%#Eval("Risk")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblhoppmbipl" Text='<%#Eval("Hoppm")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lbltopsentbipl" Text='<%#Eval("Topsent")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblinlinebipl" Text='<%#Eval("Inline")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblonlinebipl" Text='<%#Eval("Online")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px; border-right: 1px solid #aaa;">
                <asp:Label ID="lblFinalbipl" Text='<%#Eval("Final")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width: 1100px;" border="1" class="month"
        runat="server" id="tbllastMonth" bgcolor="#cccccc">
        <tr style="height: 30px;">
            <td style="color: Gray; width: 70px;">
                <strong>Last Month</strong>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblrisklastmonth47" Text='<%#Eval("Risk")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthhoppm" Text='<%#Eval("Hoppm")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthtopsent" Text='<%#Eval("Topsent")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthinline" Text='<%#Eval("Inline")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthOnline" Text='<%#Eval("Online")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthFinal" Text='<%#Eval("Final")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <%--C45-C46--%>
            <td style="width: 50px;">
                <asp:Label ID="lbllastmonthRiskC45C46" Text='<%#Eval("Risk")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lbllastMonthHoppmC45C46" Text='<%#Eval("Hoppm")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastmonthTopsentC45C46" Text='<%#Eval("Topsent")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthinlineC45C46" Text='<%#Eval("Inline")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthOnlineC45C46" Text='<%#Eval("Online")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthFinalC45C46" Text='<%#Eval("Final")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <%--bipl--%>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthRiskbipl" Text='<%#Eval("Risk")%>' ForeColor="Gray" runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthHoppmbipl" Text='<%#Eval("Hoppm")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthTopsentbipl" Text='<%#Eval("Topsent")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthInlinebipl" Text='<%#Eval("Inline")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblOnlineLastMonthbipl" Text='<%#Eval("Online")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
            <td style="width: 50px;">
                <asp:Label ID="lblLastMonthFinalbipl" Text='<%#Eval("Final")%>' ForeColor="Gray"
                    runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <%-------------------------------New-Grid-Add-by--prabhaker-14-feb-17-------------------%>
    <%--<table width="1220px" cellpadding="0" cellspacing="0" border="1" class="item_list_Report">
    <tr>


        <th colspan="5">
       <h2> QA Faults Activity Report </h2> </th>                  
    </tr>
    <tr>
    <th width="50">Factory </th>
    <th width="70">Time Period </th>
    <th width="400">Top Checker (DHU) % (Qty. Pcs)</th>
     <th width="400">Top CQD Faults (Inspection) % (Qty. Pcs)</th>
    <th width="400">Top Reason (Ctsl) % (Qty. Pcs)</th>
    </tr>--%>
    <%--<tr>
<td style="text-align:center">
C-47
</td>
  <td style="color:gray;" colspan="4">
  
      <asp:GridView ID="grdtopFaultDetails" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
          runat="server" ShowFooter="false" OnRowDataBound="grdtopFaultDetails_RowDataBound"
          ShowHeader="false" Width="100%" CellPadding="0" FooterStyle-Height="30px" BorderWidth="1">
          <Columns>--%>
    <%------------------------------------C-47-----------------------------------------------------%>
    <%--<asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="lblmonthlast" Text='<%# Eval("Last")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:Label ID="lblname" Text='<%# Eval("Month")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:HiddenField ID="hdnduration" runat="server" Value='<%# Eval("Duration")%>' />
                  </ItemTemplate>
                  <ItemStyle Width="70px" />
              </asp:TemplateField>

                <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%" >
                          <asp:Repeater runat="server" ID="rptdhuC47">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                         &nbsp; <asp:Label ID="lblRowSeqC47" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC47" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lbldhuC47Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lbldhuC47Qty" runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%-- <td style="padding-right: 5px; vertical-align: top; width:20%">
                                          
                                      </td>--%>
    <%--</tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>

              <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datarepeat">
                          <asp:Repeater runat="server" ID="rptinceptionC47">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                         &nbsp; <asp:Label ID="lblRowSeqC47" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC47" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                           <asp:Label ID="lblinceptionC47Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblinceptionC47Qty"  Text='<%#Eval("Occurrence")%>' runat="server" ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                         
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                              
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptCtslC47">
                              <ItemTemplate>
                                  <tr>
                                     <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                         &nbsp;<asp:Label ID="lblRowSeqC47" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                        
                                          <asp:Label ID="lblFaultNameC47" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                           <asp:Label ID="lblctslC47Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblctslC47Qty" Text='<%#Eval("Occurrence")%>' runat="server" ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%-- <td style="padding-right: 5px; vertical-align: top; width:20%">
                                         
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>--%>
    <%------------------------------------C-45 46-----------------------------------------------------%>
    <%-- <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptinceptionC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lblinceptionC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblinceptionC45c46Qty" Text='<%#Eval("Occurrence")%>'  runat="server" ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>
                                    
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top"  />
              </asp:TemplateField>--%>
    <%-- <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptCtslC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lblctslC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblctslC45c46Qty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>
                                  
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top"  />
              </asp:TemplateField>--%>
    <%--  <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptdhuC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lbldhuC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lbldhuC45c46Qty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>
                                    
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top"  />
              </asp:TemplateField>--%>
    <%------------------------------------Bipl-----------------------------------------------------%>
    <%--<asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptinceptionBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label> ;
                                           <asp:Label ID="lblinceptionBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                         <span style="color:Gray">(<asp:Label ID="lblinceptionBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                 
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top" />
              </asp:TemplateField>--%>
    <%--<asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptCtslBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label> 
                                             <asp:Label ID="lblctslBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblctslBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>
                                
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top"  />
              </asp:TemplateField>--%>
    <%--<asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptdhuBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 5px; vertical-align: top">
                                          <asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>
                                      </td>
                                      <td style="text-align: justify; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>  
                                          <asp:Label ID="lbldhuBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lbldhuBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>
                                  
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="160px" VerticalAlign="Top" />
              </asp:TemplateField>--%>
    <%-- </Columns>
          <EmptyDataTemplate>
              <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
          <EmptyDataRowStyle Height="30px" />
      </asp:GridView>
    --%>
    <%--</td>
</tr>

<tr>
<td style="text-align:center">
C-45-46
</td>
<td colspan="4">

<asp:GridView ID="grdtopFaultDetails46" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
          runat="server" ShowFooter="false" OnRowDataBound="grdtopFaultDetails46_RowDataBound"
          ShowHeader="false" Width="100%" CellPadding="0" FooterStyle-Height="30px" BorderWidth="1">
          <Columns>--%>
    <%------------------------------------C-47-----------------------------------------------------%>
    <%--    <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="lblmonthlast" Text='<%# Eval("Last")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:Label ID="lblname" Text='<%# Eval("Month")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:HiddenField ID="hdnduration" runat="server" Value='<%# Eval("Duration")%>' />
                  </ItemTemplate>
                  <ItemStyle Width="70px" />
              </asp:TemplateField>--%>
    <%------------------------------------C-45 46-----------------------------------------------------%>
    <%--<asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptdhuC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px; width:15px; text-align:left; vertical-align: top">
                                     &nbsp; <asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left;text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lbldhuC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lbldhuC45c46Qty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--<td style="padding-right: 5px; vertical-align: top; width:20%">
                                          
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptinceptionC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                     &nbsp; <asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lblinceptionC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblinceptionC45c46Qty" Text='<%#Eval("Occurrence")%>'  runat="server" ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                          
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptCtslC45c46">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                      &nbsp;<asp:Label ID="lblRowSeqC45c46" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameC45c46" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                          <asp:Label ID="lblctslC45c46Per" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblctslC45c46Qty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                          
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>
            
             
            
          </Columns>
          <EmptyDataTemplate>
              <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
          <EmptyDataRowStyle Height="30px" />
      </asp:GridView>
      </td>
</tr>


<tr>
<td style="text-align:center">
Bipl
</td>
<td colspan="4">
<asp:GridView ID="grdtopFaultDetailsbipl" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
          runat="server" ShowFooter="false" OnRowDataBound="grdtopFaultDetailsbipl_RowDataBound"
          ShowHeader="false" Width="100%" CellPadding="0" FooterStyle-Height="30px" BorderWidth="1">
          <Columns>--%>
    <%------------------------------------C-47-----------------------------------------------------%>
    <%--  <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Label ID="lblmonthlast" Text='<%# Eval("Last")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:Label ID="lblname" Text='<%# Eval("Month")%>' runat="server" ForeColor="Gray"></asp:Label>
                      <asp:HiddenField ID="hdnduration" runat="server" Value='<%# Eval("Duration")%>' />
                  </ItemTemplate>
                  <ItemStyle Width="70px" />
              </asp:TemplateField>
             
              
                <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptdhuBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; vertical-align: top; width:15px;">
                                     &nbsp; <asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align:left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>  
                                          <asp:Label ID="lbldhuBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lbldhuBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                          
                                      </td>--%>
    <%--</tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top" />
              </asp:TemplateField>
               <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptinceptionBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                     &nbsp; <asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label> ;
                                           <asp:Label ID="lblinceptionBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                         <span style="color:Gray">(<asp:Label ID="lblinceptionBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--   <td style="padding-right: 5px; vertical-align: top; width:20%">
                                         
                                      </td>--%>
    <%-- </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top" />
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" border="0" class="datarepeat" width="100%">
                          <asp:Repeater runat="server" ID="rptCtslBipl">
                              <ItemTemplate>
                                  <tr>
                                      <td style="padding-right: 2px;text-align: left; width:15px; vertical-align: top">
                                      &nbsp;<asp:Label ID="lblRowSeqBipl" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                      </td>
                                      <td style="text-align: left; padding-right: 2px;">
                                          <asp:Label ID="lblFaultNameBipl" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label> 
                                             <asp:Label ID="lblctslBiplPer" Text='<%#Eval("FaultPerCentage")%>' runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                          <span style="color:Gray">(<asp:Label ID="lblctslBiplQty"  runat="server" Text='<%#Eval("Occurrence")%>' ForeColor="gray"></asp:Label> Pcs)</span>
                                      </td>--%>
    <%--    <td style="padding-right: 5px; vertical-align: top; width:20%">
                                       
                                      </td>--%>
    <%--  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </table>
                  </ItemTemplate>
                  <ItemStyle Width="400px" VerticalAlign="Top"  />
              </asp:TemplateField>
            
            
          </Columns>
          <EmptyDataTemplate>
              <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
          <EmptyDataRowStyle Height="30px" />
      </asp:GridView>
</td>

</tr>
</table>

    --%>
    <%--<br />--%>
    <%----------------------------------end-of-add-grid--------------------------------%>
    <h2 style="display: none;">
        Last Day Work Done By QA
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </h2>
    <asp:GridView ID="grdqadone" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
        runat="server" ShowFooter="true" OnRowDataBound="grdqadone_RowDataBound" ShowHeader="true"
        Width="100%" CellPadding="0" CssClass="item_list_Report" FooterStyle-Height="30px"
        Style="display: none;">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Factory
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFactoryName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="48px" />
                <FooterTemplate>
                    <strong>&nbsp; &nbsp; </strong>
                </FooterTemplate>
                <FooterStyle CssClass="al-right" Font-Size="12px" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Serial No<br />
                    Style No<br />
                    Contract No<br />
                    Line No
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px; font-weight: bold;">
                                <asp:Label ID="lblserialNo" Style="font-size: 12px;" runat="server" Text='<%#Eval("SerialNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblstyleNo" runat="server" Text='<%#Eval("StyleNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblContactNo" ForeColor="Gray" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 12px;">
                                <asp:Label ID="lblLineitemNo" ForeColor="Gray" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="96" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Total Contract Qty.
                    <br />
                    Total Cut Qty.<br />
                    Total Stitch<br />
                    Total Finished Qty.
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; color: Gray; height: 12px;">
                                <asp:Label ID="lbltotalcontractqty" Style="color: Gray;" runat="server" Text='<%#Eval("ContractQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lbltotalcutqty" Style="color: Black;" runat="server" Text='<%#Eval("cutQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lbltotalstich" Style="color: Gray;" runat="server" Text='<%#Eval("stichQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 12px;">
                                <asp:Label ID="lblTotalFinishedQty" runat="server" Style="color: Gray;" Text='<%#Eval("TotalFinsishedQty")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="67" VerticalAlign="Top" />
                <%-- <FooterTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; color: Gray; height: 12px; font-weight: bold;">
                            <strong id="spanICTotalContract" visible="false" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; color: Gray; height: 12px;">
                            <strong id="spanICTotalCut" visible="false" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; color: Gray; height: 12px;">
                            <strong id="spanICstichTotal" visible="false" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong id="spanicfinsidhtotal" visible="false" runat="server"></strong>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>--%>
                <FooterStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Last Day Work Done By QA
                </HeaderTemplate>
                <%--<HeaderTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: bottom;">
                    <tr>
                        <td style="height: 48px; color: #98a9ca; border-bottom: 1px solid #98a9ca" colspan="4">
                            CTSL Detail
                        </td>
                    </tr>
                    <tr>
                        <td width="75%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                            Fualt Name
                        </td>
                        <td width="10%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                            Qty
                        </td>
                        <td width="10%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                            Value
                        </td>
                        <td width="15%" style="text-align: center; color: #98a9ca;">
                            CTSL%
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>--%>
                <ItemTemplate>
                    <div>
                        <asp:HiddenField ID="OrderDeatilID" Value='<%#Eval("orderDeatislID")%>' runat="server" />
                    </div>
                    <div style="text-align: left;">
                        <asp:Label ID="lblhoppmstatus" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: left;">
                        <asp:Label ID="lblriskstatus" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: left;">
                        <asp:Label ID="lbltopsent" runat="server"></asp:Label>
                    </div>
                    <div>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblQainLine" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" id="tblinline">
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr style="border-bottom: 1px solid #ddd;">
                                            <td style="background: #b1afaf;">
                                                Fault name
                                            </td>
                                            <td style="background: #b1afaf;">
                                                Qty.
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rptfualtldetails_inline">
                                            <ItemTemplate>
                                                <tr style="border-bottom: 1px solid #ddd;">
                                                    <td width="75%" style="text-align: left; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctsldetaild" Text='<%#Eval("Fualtname")%>' runat="server"></asp:Label>
                                                    </td>
                                                    <td width="10%" style="text-align: center; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctslqnty" Text='<%#Eval("Occurrence")%>' ForeColor="black" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td style="text-align: left; padding-right: 5px; color: Gray;">
                                                <b>Inspected Qty. </b>
                                                <asp:Label ID="lblInspected_inline" Font-Bold="true" ForeColor="black" runat="server"></asp:Label>
                                                <div style="float: right; font-weight: bold;">
                                                    Total
                                                </div>
                                            </td>
                                            <td>
                                                <b>
                                                    <asp:Label ID="lblqty_inline" runat="server"></asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    </div>
                    <div>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblQaOnline" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr runat="server" id="tblOnline">
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr style="border-bottom: 1px solid #ddd;">
                                            <td style="background: #b1afaf;">
                                                Fault name
                                            </td>
                                            <td style="background: #b1afaf;">
                                                Qty.
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rptfualtldetails_Online">
                                            <ItemTemplate>
                                                <tr style="border-bottom: 1px solid #ddd;">
                                                    <td width="75%" style="text-align: left; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctsldetaild" Text='<%#Eval("Fualtname")%>' runat="server"></asp:Label>
                                                    </td>
                                                    <td width="10%" style="text-align: center; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctslqnty" Text='<%#Eval("Occurrence")%>' ForeColor="black" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td style="text-align: left; padding-right: 5px; color: Gray;">
                                                <b>Inspected Qty. </b>
                                                <asp:Label ID="lblInspected_Online" Font-Bold="true" ForeColor="black" runat="server"></asp:Label>
                                                <div style="float: right; font-weight: bold;">
                                                    Total
                                                </div>
                                            </td>
                                            <td>
                                                <b>
                                                    <asp:Label ID="lblqty_Online" runat="server"></asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblQaFinish" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr runat="server" id="tblFinish_finish">
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr style="border-bottom: 1px solid #ddd;">
                                            <td style="background: #b1afaf;">
                                                Fault name
                                            </td>
                                            <td style="background: #b1afaf;">
                                                Qty.
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rptfualtldetails_Finish">
                                            <ItemTemplate>
                                                <tr style="border-bottom: 1px solid #ddd;">
                                                    <td width="75%" style="text-align: left; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctsldetaild" Text='<%#Eval("Fualtname")%>' runat="server"></asp:Label>
                                                    </td>
                                                    <td width="10%" style="text-align: center; border-right: 1px solid #ddd;">
                                                        <asp:Label ID="lblctslqnty" Text='<%#Eval("Occurrence")%>' ForeColor="black" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td style="text-align: left; padding-right: 5px; color: Gray;">
                                                <b>Inspected Qty. </b>
                                                <asp:Label ID="lblInspected_Finish" Font-Bold="true" ForeColor="black" runat="server"></asp:Label>
                                                <div style="float: right; font-weight: bold;">
                                                    Total
                                                </div>
                                            </td>
                                            <td>
                                                <b>
                                                    <asp:Label ID="lblqty_finish" runat="server"></asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="190" VerticalAlign="Top" CssClass="lst-day" />
                <FooterTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                <%--<strong id="Spstatusrisk" runat="server"></strong>--%>
                                Risk Done :
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Spstatusriskcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                Hoppm Done :
                                <%--<strong id="Spstatushoppm" runat="server"></strong>--%>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Spstatushoppmcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                Top :
                                <%--<strong id="Spstatushoppmtop" runat="server"></strong>--%>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Spstatushoppmtopcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                Inline Done :
                                <%--<strong id="Spstatushoppminline" runat="server"></strong>--%>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Spstatushoppminlinecount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                Online Done :
                                <%--<strong id="Spstatushoppmonline" runat="server"></strong>--%>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="SpstatushoppmonlineCount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; color: Gray;" width="30%">
                                Final Done :
                                <%--<strong id="Spstatushoppmfinal" runat="server"></strong>--%>
                            </td>
                            <%--<td>
            
             <asp:Label ID="Spstatushoppmfinalcount" runat="server"></asp:Label>
            </td>--%>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle CssClass="al-right f-12" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    QA Remarks
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblqaRemakrs" runat="server" Text='<%#Eval("QaRemarks")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="91" CssClass="leftalign" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Ex fact
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblexfactdate" runat="server" Style="color: gray; font-weight: bold;"
                        Text='<%#Eval("ExfactDate")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="67" ForeColor="Gray" />
                <FooterTemplate>
                    <%--<strong id="Strong8" runat="server"></strong>--%>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="30px" />
    </asp:GridView>
    <h2 style="display: none;">
        QA Activity Pending Report
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </h2>
    <asp:GridView ID="grdhoppminspection" AutoGenerateColumns="false" runat="server"
        ShowFooter="true" OnRowDataBound="grdhoppminspection_RowDataBound" ShowHeader="true"
        Width="100%" CellPadding="0" FooterStyle-Height="30px" Style="display: none;"
        CssClass="item_list_Report">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Factory
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFactoryName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="48px" />
                <FooterTemplate>
                    <strong>&nbsp; &nbsp; </strong>
                </FooterTemplate>
                <FooterStyle CssClass="al-right" Font-Size="12px" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Serial No<br />
                    Style No<br />
                    Contract No<br />
                    Line No
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px; font-weight: bold;">
                                <asp:Label ID="lblserialNo" Style="font-size: 12px;" runat="server" Text='<%#Eval("SerialNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblstyleNo" runat="server" Text='<%#Eval("StyleNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblContactNo" ForeColor="Gray" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLineitemNo" ForeColor="Gray" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="96" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Total Contract Qty.
                    <br />
                    Total Cut Qty.<br />
                    Total Stitch<br />
                    Total Finished Qty.
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lbltotalcontractqty" Style="color: Gray;" runat="server" Text='<%#Eval("ContractQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lbltotalcutqty" Style="color: Black; font-weight: bold;" runat="server"
                                    Text='<%#Eval("cutQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lbltotalstich" Style="color: Gray; font-weight: bold;" runat="server"
                                    Text='<%#Eval("stichQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTotalFinishedQty" runat="server" Style="color: Gray;" Text='<%#Eval("TotalFinsishedQty")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="67" VerticalAlign="Top" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; color: Gray; height: 12px; font-weight: bold;">
                                <strong id="spanICTotalContract" visible="false" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; color: black; height: 12px;">
                                <strong id="spanICTotalCut" visible="false" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; color: black; height: 12px;">
                                <strong id="spanICstichTotal" visible="false" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong id="spanicfinsidhtotal" visible="false" runat="server"></strong>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle VerticalAlign="Top" CssClass="f-12" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Price
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnCurrenyTag" runat="server" Value='<%#Eval("ConvertTo")%>' />
                    <asp:Label ID="lblPrice" runat="server" ForeColor="Gray" Text='<%#Eval("Price")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="37" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Order Value (Lacs)
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOrderValueValue" ForeColor="Gray" runat="server" Text='<%#Eval("OrderValue")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="69" />
                <FooterTemplate>
                    <strong id="spOrderValueIctotal" runat="server"></strong>
                </FooterTemplate>
                <FooterStyle CssClass="f-12" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Pending QA Activity
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <asp:HiddenField ID="hdnOrderdetailID" runat="server" Value='<%#Eval("orderDeatislID")%>' />
                        <asp:Label ID="lblrisk" Style="padding: 11px" Font-Size="11px" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblhoppmstatus" Style="padding: 11px" Font-Size="11px" runat="server"></asp:Label><br />
                    </div>
                    <asp:Label ID="lbltop" Style="padding: 11px" Font-Size="11px" runat="server"></asp:Label>
                    <div>
                        <div>
                            <asp:Label ID="lblInceptionInline" Style="padding: 11px" Font-Size="11px" runat="server"></asp:Label>
                            <div>
                                <asp:Label ID="lblInceptionOnline" Style="padding: 11px" Font-Size="11px" runat="server"></asp:Label>
                                <div>
                                    <asp:Label ID="lblFinish" Visible="false" Style="padding: 11px" Font-Size="11px"
                                        runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="97" CssClass="leftalign" ForeColor="Gray" />
                <FooterTemplate>
                    <table>
                        <tr>
                            <td style="float: right; color: Gray;">
                                <%--<strong id="Spstatusrisk" runat="server"></strong>--%>
                                Risk pending :
                            </td>
                            <td>
                                <asp:Label ID="Spstatusriskcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: right; color: Gray;">
                                Hoppm pending :
                                <%--<strong id="Spstatushoppm" runat="server"></strong>--%>
                            </td>
                            <td>
                                <asp:Label ID="Spstatushoppmcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: right; color: Gray;">
                                Top sent :
                                <%--<strong id="Spstatushoppmtop" runat="server"></strong>--%>
                            </td>
                            <td>
                                <asp:Label ID="Spstatushoppmtopcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: right; color: Gray;">
                                Inline due :
                                <%--<strong id="Spstatushoppminline" runat="server"></strong>--%>
                            </td>
                            <td>
                                <asp:Label ID="Spstatushoppminlinecount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td style="float: right; color: Gray;">
                                Online due :
                                <%--<strong id="Spstatushoppmonline" runat="server"></strong>--%>
                            </td>
                            <td>
                                <asp:Label ID="SpstatushoppmonlineCount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: right; color: Gray;">
                                Online due :
                                <%--<strong id="Spstatushoppmfinal" runat="server"></strong>--%>
                            </td>
                            <td>
                                <asp:Label ID="Spstatushoppmfinalcount" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    inception Detail
                </HeaderTemplate>
                <ItemTemplate>
                </ItemTemplate>
                <ItemStyle Width="91" CssClass="leftalign" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Ex fact
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblexfactdate" Style="color: gray; font-weight: bold;" runat="server"
                        Text='<%#Eval("ExfactDate")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="67" />
                <FooterTemplate>
                    <%--<strong id="Strong8" runat="server"></strong>--%>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
      <%--  <tr>
            <td colspan="3">
                 <uc1:TopThreeFaultsSummery ID="TopThreeFaultsSummery2" runat="server" />
            </td>
        </tr>--%>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
         <tr>
          <td style="text-align: left; width: 33%">
               <img runat="server" id="BIPLCQDFaultsPackedMonthly" width="750" style="max-width: 750px; display: block;" />

            </td>
            <td style="text-align: left; width: 33%">
               
            </td>
            <td style="text-align: left; width: 33%">
             
            </td>
          </tr>
         <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLHRAuditMonthly" width="750" style="max-width: 750px; display: block;" />
            </td>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLQualityAuditMonthly" width="750" style="max-width:750px; display: block;" />
            </td>
          </tr>
    </table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
           <tr>
            <td style="text-align: left;
                width: 25%">
                <img runat="server" id="BIPL_CuttingRate" width="525" style="max-width: 525px; display: block;" />
            </td>
            <td style="text-align: left; width: 25%">
                <img runat="server" id="BIPL_FinishedRate" width="525" style="max-width: 525px; display: block;" />
            </td>
            <td style="text-align: left; width: 25%">
             <img runat="server" id="BIPLMonthlyAchievement" width="525" style="max-width: 525px; display: block;" />
            </td>
             <td style="text-align: left; width: 25%">
                <img runat="server" id="BIPLMonthlyFinishRate" width="525" style="max-width: 525px; display: block;" />
            </td>
          </tr>
    </table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyCQDPASS" width="750" style="max-width: 750px; display: block;" />
            </td>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyRescan" width="750" style="max-width: 750px; display: block;" />
            </td>
            <td style="text-align: left; display:none; width: 33%" >
                <img runat="server" id="BIPLMonthlyEff" width="420" style="max-width: 750px; display: block;" />
            </td>
          </tr>
     </table>
     <table cellpadding="0" cellspacing="0" border="0" width="100%">       
           <!--<tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="c47" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="c45" width="420" style="max-width: 500px; display: block;" />
            </td>
              <td style="text-align: left; width: 33%">
                <img runat="server" id="d169" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left; width: 34%">
                <img runat="server" id="bipl" width="420" style="max-width: 500px; display: block;" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>-->
     <tr>
            <td style="text-align: left; display:none; width: 33%">
                <img runat="server" id="Compliance_c47" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left;display:none; width: 33%">
                <img runat="server" id="Compliance_c45" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left;display:none; width: 34%">
                <img runat="server" id="Compliance_bipl" width="420" style="max-width: 500px; display: block;" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
       <!-- <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="QA_c47" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="QA_c45" width="420" style="max-width: 500px; display: block;" />
            </td>
              <td style="text-align: left; width: 33%">
                <img runat="server" id="QA_d169" width="420" style="max-width: 500px; display: block;" />
            </td>
            <td style="text-align: left; width: 34%">
                <img runat="server" id="QA_bipl" width="420" style="max-width: 500px; display: block;" />
            </td>
        </tr>-->
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left;" colspan="3">
                <ul style="color: Gray;">
                    <li>BIPL Monthly CQD Faults Packed
                        <ul>
                            <li>Based on Final Inspection Total Faults Occurred and Actual Sample checked taken</li>
                            <li>Now calculating as (Total Faults occurred/ Actual Sample checked) *100</li>
                            <li>The above calculation done for all months in current and previous Financial years</li>
                        </ul>
                    </li>
                   <li>BIPL Compliance Audit – In this report to HR Audit on Compliances for BIPL monthly comparison between two financial years is shown</li>
                   <li>BIPL Quality Audit – In this Chart too again we are showing CQD Audit comparison Chart for two financial years month wise.</li>
                   <br />
                   <br />
                   <li>Based on the entry done by IE Team we are showing the followings:
                      <ul>
                         <li>BIPL Cut Rate Monthly comparison chart for 2 financial years month wise</li>
                         <li>BIPL Stitching Efficiency comparison chart for 2 financial years month wise</li>
                         <li>BIPL Finish Rate comparison chart for 2 financial years month wise</li>
                      </ul>
                   </li>
                        <br />
                        <br />
                
                    <li>BIPL CQD Pass – In this chart we take the following approach (Total Pass Inspections/ Total Inspection done) * 100
                        <br />
                        <br />
                    </li>
                    <li>BIPL Rescan → (Total Marked Rescan / Total Packed Pcs) *100 
                     <br />
                        <br /> 
                    </li>
                    <li>QC Performance Report QC. Here there are 4 sections for calculation
                    <ul>
                      <li>Now in QC Performance report for Rescan using Upper Limit as 20. If Rescan is above or equals to 20 then the weighted performance value will be 0.</li>
                      <li>Similarly, for CQD Fault count upper limit is 15 now. If CQD Fault count is above or equal to 15 then the weighted performance value will be 0.</li>
                      <li>If total Quantity checked is 0 then overall performance would be 0. Now target checked quantity for quarter is 20,000</li>
                      <li>Rescan weight is 70, Total CQD Faults weight is 20 now. There is no weight added for quantity checked. </li>
                      <li>Formulae for Rescan is (Weight – (Weights/Upper Limit) * Actual Rescan) * (Total Checked quantity/((20,000 * Days till date in current quarter)/90))</li>
                      <li>Formulae for CQD Fault Count is (Weight – (Weights/Upper Limit) * Actual CQD Fault Count)</li>
                      <li>Formulae for CQD Inspection is (Actual Checked/ Target) *(Weight/100)*100</li>
                    </ul>
                        <br />
                        <br />
                    </li>
                   
                </ul>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
