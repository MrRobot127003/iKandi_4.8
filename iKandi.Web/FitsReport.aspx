<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitsReport.aspx.cs" Inherits="iKandi.Web.FitsReport" %>

<%@ Register Src="UserControls/Reports/Rpt_AM_PerformanceReports.ascx" TagName="Rpt_AM_PerformanceReports"
    TagPrefix="uc3" %>

<%@ Register Src="UserControls/Reports/frmPoUploadPendingBreakDown.ascx" TagName="frmPoUploadPendingBreakDown"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/Reports/frmonhold.ascx" TagName="frmonhold"
    TagPrefix="uc2" %>
    <%@ Register Src="UserControls/Reports/frm_pending_cost_confirmation.ascx" TagName="frm_pending_cost_confirmation"
    TagPrefix="uc5" %>
    <%@ Register Src="UserControls/Reports/Master_Monthly_Performance_Report.ascx" TagName="Rpt_Master_PerformanceReports"
    TagPrefix="uc4" %>

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
            padding: 2px 0px !important;
            font-family: arial, halvetica;
            text-transform: capitalize;
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
            padding: 0px 0px !important;
            text-align: center;
            /*color: Gray;*/
            border-color: #999999 !important;
        }
        td span
        {
            font-size: 9px !important;
        }
        td table tr td
        {
            padding: 0px 0px !important;
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
        ul li
        {
            color: Gray;
        }
        
        .footerback
        {
            background: #FFF0A5;
        }
        
        .footerback .Background-red
        {
            background: #FFF0A5 !important;
            text-align: center;
        }
        .footerback .Background-green
        {
            background: #FFF0A5 !important;
            text-align: center;
        }
        .footerback .Background-red span
        {
            color: gray !important;
            font-weight: bold;
        }
        .footerback td span
        {
            color: gray;
            font-weight: bold;
        }
       /*bharat 19-feb*/
      
       .frmPOUPload
        {
            background: #FFF0A5;
        }
        .frmPOUPload .Background-red
        {
            background: #FFF0A5 !important;
            text-align: center;
        }
        .frmPOUPload .Background-green
        {
            background: #FFF0A5 !important;
            text-align: center;
        }
       
       .frmPOUPload .Background-red span
        {
            color: #000 !important;
            font-weight: bold;
        }
        .backgrondcolrAvg{
         background-color:red;
         color:yellow;
         }
         
         .frmPOUPload .backgrondcolrAvg
        {
            background: #FFF0A5 !important;
            color: #000 !important;
        }
        /*end*/

        .inputfixed span
        {
            border: 0px;
            text-align: center;
            text-transform: capitalize;
            color: Gray;
            border-color: White;
        }
        .Background-red
        {
            background-color: Red;
            text-align: center;
        }
        .Background-red span
        {
            color: Yellow;
        }
        .Background-green
        {
            background-color: Green !important;
        }
        .gridpadding .header1 td
        {
            background: #405D99;
            font-weight: bold;
            color: #fff;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 2px 0px;
            border-color: #BFBFBF;
        }
        .gridpadding .header2 td
        {
            background: #405D99;
            font-weight: bold;
            color: #fff;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 2px 0px;
            border-color: #BFBFBF;
        }
        
        .gridpadding .header3 td
        {
            background: #405D99;
            font-weight: bold;
            color: #fff;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 2px 0px;
            border-color: #BFBFBF;
        }
         .gridpadding .header6 td
        {
            background: #405D99;
            font-weight: bold;
            color: #fff;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 2px 0px;
            border-color: #BFBFBF;
        }
        .colorgray
        {
            color: red !important;
        }
        .hid
        {
            display: none;
        }
        
        #frmPoUploadPendingBreakDown2_grdPoUploadPendingBreakDown
        {
            width: 1150px !important;
        }
        form
        {
            margin-left: 10px;
        }
        .YellowClass
        {
            color: Yellow !important;
        }
        .lastrowcolor
        {
            background: #FFF0A5;
            font-weight: bold !important;
        }
        .headerfontsize
        {
            font-size: 9px !important;
            font-family: arial, halvetica;
            padding: 2px !important;
            font-weight: normal !important;
        }
        .split-para
        {
            padding: 2px 0px !important;
        }
        .GreenClass
        {
            color:green;
        }
         .RedClass
        {
            color:red;
        }
        .backcolor-gray
        {
            background:#f9f9fa;
            color:Gray !important;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!---------------Add New splitted fits Report------------------->
    <%--<table cellpadding="0" cellspacing="0" border="0" style="width: 500px; margin: 10px 0px 0px;
        text-align: center;">
        <tr>
            <td style="background: #39589C; color: #e7e4fb; font-family: Calibri, sans-serif;
                font-size: 13px; margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px;
                text-align: center;">
                AM Performance
            </td>
        </tr>
    </table>--%>
    <asp:GridView ID="grdper" Visible="false" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
        runat="server" ShowFooter="false" ShowHeader="false" Width="500px" CellPadding="0"
        BorderWidth="1" CssClass="gridpadding table_paddng" OnRowDataBound="grdper_RowdataBound"
        CellSpacing="0">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>AM</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblusername" Text='<%# Eval("UserName")%>' runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" CssClass="split-para" />
            </asp:TemplateField>
            <%-- ----------------Start Merginng-------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_1" Text='<%# Eval("Sealing_Q1").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q1"), "",  "%") %>'
                        runat="server" ForeColor="gray"></asp:Label>
                    <asp:HiddenField ID="hdnlblSealing_1" Value='<%# Eval("Sealing_Q1").ToString()%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_2" Text='<%# Eval("Sealing_Q2").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q2"), "",  "%")+" "+(Eval("Avg_Sealing_Q2").ToString()=="0" ? "" :"("+string.Concat(Eval("Avg_Sealing_Q2"), "",  ")"))%>'
                        runat="server" ForeColor="gray"></asp:Label>
                    <asp:HiddenField ID="hdnlblSealing_2" Value='<%# Eval("Sealing_Q2").ToString()%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_3" Text='<%# Eval("Sealing_Q3").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q3"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_4" Text='<%# Eval("Sealing_Q4").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_1" Text='<%# (Eval("BIH_Q1").ToString()=="0" && Eval("Avg_BIH_Q1").ToString()=="0") ? "" : Eval("BIH_Q1").ToString()=="0" ? "(" + Eval("Avg_BIH_Q1") + ")" :string.Concat(Eval("BIH_Q1"), "",  "%")+" ("+Eval("Avg_BIH_Q1") + ")" %>'
                        runat="server" ForeColor="gray"></asp:Label>
                    <asp:HiddenField ID="hdnlblBIH_1" Value='<%# Eval("BIH_Q1").ToString()%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_2" Text='<%# (Eval("BIH_Q2").ToString()=="0" && Eval("Avg_BIH_Q2").ToString()=="0") ? "" : Eval("BIH_Q2").ToString()=="0" ? "(" + Eval("Avg_BIH_Q2") + ")" :string.Concat(Eval("BIH_Q2"), "",  "%")+" ("+Eval("Avg_BIH_Q2") + ")" %>'
                        runat="server" ForeColor="gray"></asp:Label>
                    <asp:HiddenField ID="hdnlblBIH_2" Value='<%# Eval("BIH_Q2").ToString()%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_3" Text='<%# Eval("BIH_Q3").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q3"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_4" Text='<%# Eval("BIH_Q4").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q1" Text='<%# Eval("StyleCodeShare_Q1").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q1"), "",  "%")%>'
                        runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q2" Text='<%# Eval("StyleCodeShare_Q2").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q2"), "",  "%")%>'
                        runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q3" Text='<%# Eval("StyleCodeShare_Q3").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q3"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q4" Text='<%# Eval("StyleCodeShare_Q4").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%-- -----------------------End------------------------%>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="60px" />
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" border="0" style="max-width: 1550px; margin: 10px 0px 0px;
        text-align: center;">
        <tr>
            <td style="background: #39589C; color: #e7e4fb; font-family: sans-serif; font-size: 11px;
                margin: 0px 0px 0px; padding: 3px !important; font-weight: 500; width: 1494px;
                max-width: 1550px; text-align: center;">
                AM Performance
            </td>
        </tr>
    </table>
   <br/>
    <uc3:Rpt_AM_PerformanceReports ID="Rpt_AM_PerformanceReports1" runat="server"></uc3:Rpt_AM_PerformanceReports>
  
     <br />
     <br />
     <uc5:frm_pending_cost_confirmation ID="frm_pending_cost_confirmation1" runat="server"></uc5:frm_pending_cost_confirmation>
     <br />
    <br/>
     <uc2:frmonhold ID="frmonhold" runat="server"></uc2:frmonhold>
    <br />
    <br />
    
    <uc1:frmPoUploadPendingBreakDown ID="frmPoUploadPendingBreakDown" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grdinproduction" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
        runat="server" ShowFooter="false" ShowHeader="false" Width="1150px" CellPadding="0"
        BorderWidth="1" CssClass="gridpadding" OnRowDataBound="grdinproduction_RowdataBound"
        CellSpacing="0">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>AM</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblusername" Text='<%# Eval("UserName")%>' runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" CssClass="split-para" />
            </asp:TemplateField>
            <%-- ----------------Start Merginng-------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTotalOrderQty" runat="server" ForeColor="black"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnOrderQty" Value='<%# Eval("OrderQuantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTotalStyleCount" Text='<%# Eval("StyleCode")%>' runat="server"
                        ForeColor="black"></asp:Label>
                    <asp:Label ID="lblStylePendingCount" Text='<%# Eval("StyleCount")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblStcRequestedStyleCode" Text='<%# Eval("StyleCode_STCRequestedDone")%>'
                        runat="server" ForeColor="black"></asp:Label>
                    <asp:Label ID="lblStcRequestedStyleNo" Text='<%# Eval("StyleCount_STCRequestedDone")%>'
                        runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSTCStyleCode" Text='<%# Eval("PendingStyle_Code_For_STC")%>' runat="server"
                        ForeColor="black"></asp:Label>
                    <asp:Label ID="lblSTCStyleNo" Text='<%# Eval("PendingStyleCount")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPsStyleCode" Text='<%# Eval("StyleCode_Patternsample")%>' runat="server"
                        ForeColor="black"></asp:Label>
                    <asp:Label ID="lblPsStyleNo" Text='<%# Eval("StyleCount_Patternsample")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblInProductionStyleCode" Text='<%# Eval("StyleCode_ProductionIn")%>'
                        runat="server" ForeColor="black"></asp:Label>
                    <asp:Label ID="lblInProductionStyleNo" Text='<%# Eval("StyleCount_ProductionIn")%>'
                        runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%---------------------second Portion Start--------------------------%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblhandtaskpending" Text='<%# Eval("HandOver_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblHandOver_taskdelay" Text='<%# Eval("HandOver_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" Text='<%# Eval("HandOver_avgLt")%>' runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_taskpending" Text='<%# Eval("Patter_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_taskdelay" Text='<%# Eval("Patter_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPatter_avgLt" Text='<%# Eval("Patter_avgLt")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_taskpending" Text='<%# Eval("Sample_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_taskdelay" Text='<%# Eval("Sample_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSample_avgLt" Text='<%# Eval("Sample_avgLt")%>' runat="server"
                        ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFits_taskpending" Text='<%# Eval("Fits_taskpending")%>' runat="server"
                        ForeColor="black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFits_taskdelay" Text='<%# Eval("Fits_taskdelay")%>' runat="server"
                        ForeColor="red"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFits_avgLt" Text='<%# Eval("Fits_avgLt")%>' runat="server" ForeColor="gray"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblPPSampleCount" Text='<%# Eval("PPSampleSent").ToString()=="0" ? "N/A" : Eval("PPSampleSent").ToString() %>'
                        runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--  <asp:TemplateField ControlStyle-CssClass="hid">
                <ItemTemplate>
           
                    <asp:Label ID="lblSealing_1" Text='<%# Eval("Sealing_Q1").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q1"), "",  "%")%>'
                        runat="server" ForeColor="gray"  Font-Bold="false"></asp:Label>
                        <asp:HiddenField ID="hdnlblSealing_1" Value='<%# Eval("Sealing_Q1").ToString()%>' runat="server" />
                   
                </ItemTemplate>
              
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_2" Text='<%# Eval("Sealing_Q2").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q2"), "",  "%")%>'
                        runat="server" ForeColor="gray"  Font-Bold="false"></asp:Label>
                        <asp:HiddenField ID="hdnlblSealing_2" Value='<%# Eval("Sealing_Q2").ToString()%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_3" Text='<%# Eval("Sealing_Q3").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q3"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSealing_4" Text='<%# Eval("Sealing_Q4").ToString()=="0" ? "" : string.Concat(Eval("Sealing_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_1" Text='<%# Eval("BIH_Q1").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q1"), "",  "%")%>'
                        runat="server" ForeColor="gray"  Font-Bold="false"></asp:Label>
                        <asp:HiddenField ID="hdnlblBIH_1" Value='<%# Eval("BIH_Q1").ToString()%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_2" Text='<%# Eval("BIH_Q2").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q2"), "",  "%")%>' 
                        runat="server" ForeColor="gray"  Font-Bold="false"></asp:Label>
                         <asp:HiddenField ID="hdnlblBIH_2" Value='<%# Eval("BIH_Q2").ToString()%>'  runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_3" Text='<%# Eval("BIH_Q3").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q3"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblBIH_4" Text='<%# Eval("BIH_Q4").ToString()=="0" ? "" : string.Concat(Eval("BIH_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q1" Text='<%# Eval("StyleCodeShare_Q1").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q1"), "",  "%")%>'
                        runat="server" ForeColor="gray" Font-Bold="false"></asp:Label>
                </ItemTemplate>
                 
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q2" Text='<%# Eval("StyleCodeShare_Q2").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q2"), "",  "%")%>'
                        runat="server" ForeColor="gray" Font-Bold="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q3" Text='<%# Eval("StyleCodeShare_Q3").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q3"), "",  "%")%>'
                        runat="server"  ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="StyleCodeShare_Q4" Text='<%# Eval("StyleCodeShare_Q4").ToString()=="0" ? "" : string.Concat(Eval("StyleCodeShare_Q4"), "",  "%")%>'
                        runat="server" ForeColor="black"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <%-- -----------------------End------------------------%>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="60px" />
    </asp:GridView>
    <br />
    <!----------------------End-of-code------------------------------>
 <%--   <table cellpadding="0" cellspacing="0" border="0" style="width: 1150px; margin: 0px 0px 0px;
        text-align: center;">--%>
      <table  border="0" cellspacing="10">
            <tr>
               <td>
                <uc4:Rpt_Master_PerformanceReports ID="Rpt_Master_PerformanceReports1" runat="server" />
               </td>
               <td style='vertical-align: top;'>
                 <div id="divscore" runat="server"></div>
               </td>
            </tr>
        </table>
        <%--<tr>
            <th style="background: #39589C; color: #e7e4fb; font-family: Calibri, sans-serif;
                font-size: 13px; margin: 0px 0px 0px; padding: 2px 0px !important; width: 1150px;
                max-width: 1150px; text-align: center;">
                Master Monthly Performance
            </th>
        </tr>--%>

  <%--  </table>--%>
   <%-- <asp:GridView ID="grdmasterper" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
        CssClass="gridpadding" runat="server" ShowFooter="false" Width="1150px" CellPadding="0"
        OnRowDataBound="grdmasterper_RowDataBound" BorderWidth="1" CellSpacing="0">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Day</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("id")%>' />
                    <asp:HiddenField ID="hdnStartdate" runat="server" Value='<%# Eval("StartDateWeek")%>' />
                    <asp:HiddenField ID="hdnEnddate" runat="server" Value='<%# Eval("EndDateWeek")%>' />
                    <asp:Label ID="lblWeekName" Text='<%# Eval("WeekName")%>' runat="server" ForeColor="Gray"></asp:Label>
                    <asp:Label ID="lblweekNameday" Text='<%# Eval("weekDayName")%>' runat="server" ForeColor="Gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Jai Narayan</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster1" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster1days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster1Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster1Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster1daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster1TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster1_ID" runat="server" Value='1' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Vashudev Kashyap</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster2" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster2days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster2Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster2Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster2daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster2TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster2_ID" runat="server" Value='2' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Roshan Lal</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster3" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster3days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster3Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster3Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster3daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster3TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster3_ID" runat="server" Value='3' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Satya Prakash</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster4" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster4days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster4Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster4Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster4daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster4TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster4_ID" runat="server" Value='4' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
         <%--   <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Rajender Singh</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster5" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster5days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster5Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster5Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster5daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster5TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster5_ID" runat="server" Value='5' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>--%>
         <%--   <asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Md.Muslim</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblmaster6" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster6days" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster6Total" runat="server" ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmaster6Remake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster6daysRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:Label ID="lblmaster6TotalRemake" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnmaster6_ID" runat="server" Value='7' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>--%>
            <%--<asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                            <asp:Label ID="lblmaster6" runat="server" ForeColor="black"></asp:Label>
                                            <asp:Label ID="lblmaster6days" runat="server" ForeColor="black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblmaster6Total" runat="server" ForeColor="black"></asp:Label>
                                            <asp:HiddenField ID="hdnmaster6_ID" runat="server" Value='99' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="151px" VerticalAlign="Top" />
                        </asp:TemplateField>--%>
            <%--<asp:TemplateField>
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="2" style="border-bottom: 1px solid #b7b4b4">
                                <b>Total</b>
                            </th>
                        </tr>
                        <tr>
                            <th style="border-right: 1px solid #b7b4b4; width: 50%">
                                Total
                            </th>
                            <th>
                                Remake
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-right: 1px solid #b7b4b4; width: 50%; height: 16px;">
                                <asp:Label ID="lblTotal" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblmasterTotaltillnow" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblTotaldays" runat="server" ForeColor="black"></asp:Label>
                                <asp:HiddenField ID="hdnTotal_ID" runat="server" Value='<%# Eval("id")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lblTotalRemake" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblmasterTotaltillnowRemake" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblTotaldaysRemake" runat="server" ForeColor="black"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    <b>BIPL Performance</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAvgPerformance" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblAvgPerformancedays" runat="server" ForeColor="black"></asp:Label>
                    <asp:HiddenField ID="hdnAvgPerformance_ID" runat="server" Value='<%# Eval("id")%>' />
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Tailor Hired</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbltailorCap" runat="server" ForeColor="Black"></asp:Label>--%>
                <%--</ItemTemplate>
                <ItemStyle Width="51px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Tailor Present</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbltailorPresent" runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="51px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Sample Sent</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbltailorSampleSent" runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="81px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    <b>Avg Performance </b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbltailorAvgPer" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="51px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Sample Made</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSampleMade" runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="51px" VerticalAlign="Top" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="30px" />
    </asp:GridView>--%>
    <%--  <table cellpadding="0" cellspacing="0" border="0" style="width:900px;margin: 10px auto;
           text-align: center;" align="center">
        <tr>
            <th>
        
        </th>
        </tr>
        </table>--%>
    <%--
    <asp:GridView ID="grdtopsummary" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
        runat="server" ShowFooter="false"  Width="900px" CellPadding="0" BorderWidth="1" HorizontalAlign="Center" OnRowDataBound="grdtopsummary_RowDataBound">
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>
            <b>Account Manager</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblusername" Text='<%# Eval("UserName")%>' runat="server" ForeColor="Gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField>
            <HeaderTemplate>
            <b>TOP Pending to Sent</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTopSent_taskpending" Text='<%# Eval("TopSent_taskpending")%>' runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
            <HeaderTemplate>
            <b>TOP Pending approval</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTopSent_avgLt" Text='<%# Eval("TopSent_avgLt")%>' runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
            <HeaderTemplate>
            <b>Seal (Pattern Sample Pending)
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSealStyle" Text='<%# Eval("SealStyle")%>' runat="server" ForeColor="Gray"></asp:Label>
                     <asp:Label ID="lblPatternSamplePending"  Text='<%# Eval("PatternSamplePending")%>' runat="server" ForeColor="Gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
            <HeaderTemplate>
            <b>Avg Top Approval Days</b><br /><b>1M (3M)</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDiffBetweenNTopSentFor1Month" Text='<%# Eval("Avg_Between_TopSent_and_Top_Approved_For1Monthes")%>' runat="server" ForeColor="Gray"></asp:Label>
                     <asp:Label ID="lblDiffBetweenNTopSentFor3Month"  Text='<%# Eval("Avg_Between_TopSent_and_Top_Approved_For3Monthes")%>' runat="server" ForeColor="Gray"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
            <HeaderTemplate>
            <b>How Many Week Before Exfactory</b> <b>We are sending TOP</b><br /><b>1M (3M)</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTopSent_ETA"  Text='<%# Eval("TopExfactoryLeadTimeDays")%>' runat="server"></asp:Label>
                    <asp:Label ID="lblTopExfactoryLeadTimeDays"  Text='<%# Eval("TopSent_ETA")%>' runat="server"></asp:Label>
                </ItemTemplate>

                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
              <asp:TemplateField>
            <HeaderTemplate>
            <b>TOP aprd but MDA pending count (Only For ASOS Order)</b>
            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTopApprovedMDACount" Text='<%# Eval("TopMDACount")%>' runat="server" ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="151px" VerticalAlign="Top" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
        <EmptyDataRowStyle Height="30px" />
    </asp:GridView>--%>
   
    </form>
</body>
</html>
