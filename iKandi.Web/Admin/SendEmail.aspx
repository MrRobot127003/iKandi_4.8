<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="iKandi.Web.SendEmailPanel"
    MasterPageFile="~/layout/Secure.Master" %>


<asp:Content ID="content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <link href="../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .item_list th
    {
        text-align:left;
        padding:0px 20px !important; 
    }
    .item_list td
    {
        text-align:left;
        padding:0px 20px !important;
    }
    
    
    </style>
    <link href="../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../js/Calender_new.js" type="text/javascript"></script>
<script src="../js/Calender_new2.js" type="text/javascript"></script>
 <script type="text/javascript">

     $(function () {
         $(".th").datepicker({ dateFormat: 'dd M y (D)' });
     });
  
  </script> 
 <h2 class="header-text-back">  Send Email</h2>
       
        <table width="100%"  cellpadding="6" cellspacing="0" border="0" class="da_table_border item_list">
            <tr class="da_header_heading">
                <th width="65%">Email Name</th>
                <th width="20%">INPUT</th>
                <th width="8%">Send</th>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">Courier Dispatch List Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtCourierDispatchListEmail" CssClass="th"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnCourierDispatchListEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnCourierDispatchListEmail_Click" />
                </td> 
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Production Report Email
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="TextBox1" CssClass="invoice_input" CssClass="date-picker date_style"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnProductionReportEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnProductionReportEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Monday Company Report Email
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="TextBox1" CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnMondayCompanyReportEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnMondayCompanyReportEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Monday Company Report Resolution Filled Email
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="TextBox1"  CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnSendMondayCompanyResolutionFilledEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnSendMondayCompanyResolutionFilledEmail_Click" />
                </td>
            </tr>
            <%--<tr>
                <td align="left">
                    Packing Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallPackingEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallPackingEmail" runat="server" CssClass="sentEmail" OnClick="btnOverallPackingEmail_Click" />
                </td>
            </tr>--%>
           <%-- <tr>
                <td align="left">
                    Inline Cut Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallInlineCutEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallInlineCutEmail" runat="server" CssClass="sentEmail" OnClick="btnOverallInlineCutEmail_Click" />
                </td>
            </tr>--%>
            <%--<tr>
                <td align="left">
                    Stc Style (Stc Unallocated) Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallStyleEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallStyleEmail" runat="server" CssClass="sentEmail" OnClick="btnOverallStyleEmail_Click" />
                </td>
            </tr>--%>
            <%--<tr>
                <td align="left">
                    PP Meetings Pending Email 
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPPMeetingsPendingEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnPPMeetingsPendingEmail" runat="server" CssClass="sentEmail" OnClick="btnPPMeetingsPendingEmail_Click" />
                </td>
            </tr>--%>
            <tr class="da_table_tr_bg">
                <td align="left">
                    QA Form Pending Email
                </td>
                <td align="left">
                    <%-- <asp:TextBox runat="server" ID="TextBox1" 
                      CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnQAFormPendingEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnQAFormPendingEmail_Click" />
                </td>
            </tr>
            <%--<tr>
                <td align="left">
                    Top Requested Email
                </td>
                <td align="left">
                   
                </td>
                <td align="left">
                    <asp:Button ID="btnTopRequestedEmail" runat="server" CssClass="sentEmail" OnClick="btnTopRequestedEmail_Click" />
                </td>
            </tr>--%>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Live Order Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallLiveOrderEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallLiveOrderEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnOverallLiveOrderEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Only Ex-Factory Date Changed Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtExFactoryDateChangedEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnExFactoryDateChangedEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnExFactoryDateChangedEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Ex-Factory Planned Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallExFactoryPlannedEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallExFactoryPlannedEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnOverallExFactoryPlannedEmail_Click" />
                </td>
            </tr>
            <%--<tr>
                <td align="left">
                    Approved to Ex-Factory Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOverallApprovedToExFactoryEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOverallApprovedToExFactoryEmail" runat="server" CssClass="sentEmail"
                        OnClick="btnOverallApprovedToExFactoryEmail_Click" />
                </td>
            </tr>--%>
            <%--<tr>
                <td align="left">
                    Allocation Summary Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAllocationSummaryEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btntxtAllocationSummaryEmail" runat="server" CssClass="sentEmail"
                        OnClick="btntxtAllocationSummaryEmail_Click" />
                </td>
            </tr>--%>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Costed Styles Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtCostedStylesEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnCostedStylesEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnCostedStylesEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    New Orders Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtNewOrdersEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnNewOrdersEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnNewOrdersEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Designs Creation Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDesignsCreationEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnDesignsCreationEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnDesignsCreationEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Status Meeting Resolution Filled Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtStatusMeetingResolutionFilledEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnStatusMeetingResolutionFilledEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnStatusMeetingResolutionFilledEmail_Click" />
                </td>
            </tr>
          <%--  <tr>
                <td align="left">
                    Ex-Factory Overall Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtExFactoryOverallEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnExFactoryOverallEmail" runat="server" CssClass="sentEmail" OnClick="btnExFactoryOverallEmail_Click" />
                </td>
            </tr>--%>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Part Of Ex-Factory Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPartOfExFactoryEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnPartOfExFactoryEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnPartOfExFactoryEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Order Form Changes Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOrderFormChangesEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOrderFormChangesEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnOrderFormChangesEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                     FIT Comments Uploaded
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtCommentsUploaded" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="Button1" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnCommentsUploaded_Click" />
                </td>
            </tr>
             <tr class="da_table_tr_bg2">
                <td align="left">
                     ORDER DELEVERED EMAIL
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOrderDeleveredEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOrderDeleveredEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnOrderDeleveredEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Live Pending Email
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="TextBox1" CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnLivePendingEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnLivePendingEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Monthly Shipment Statement Email
                </td>
                <td align="left"> 
                 <asp:DropDownList Width="65%"  ID="ddlMonthForMonthShipmentEmail" runat="server" CssClass="do-not-disable input_in">
                      </asp:DropDownList>  
              <asp:DropDownList Width="30%"  ID="ddlYearForMonthShipmentEmail" runat="server" CssClass="do-not-disable input_in">
                      </asp:DropDownList>  
                </td>
                <td align="left">
                    <asp:Button ID="btnMonthlyShipmentEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnMonthlyShipmentEmaill_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Quaterly Shipment Statement Email
                </td>
                <td align="left"> 
                 <asp:DropDownList Width="65%"  ID="ddlQuaterForQuaterShipment" runat="server" CssClass="do-not-disable input_in">
                    <asp:ListItem Text="1st Quater (Apr-Jun)" Value="4"></asp:ListItem>
                    <asp:ListItem Text="2nd Quater (Jul-Sept)" Value="7"></asp:ListItem>
                    <asp:ListItem Text="3ed Quater (Oct-Dec)" Value="10"></asp:ListItem>
                     <asp:ListItem Text="4th Quater (Jan-mar)" Value="1"></asp:ListItem>
                      </asp:DropDownList>  
                <asp:DropDownList Width="30%"  ID="ddlYearForQuaterShipment" runat="server" CssClass="do-not-disable input_in">
                      </asp:DropDownList>  
                </td>
                <td align="left">
                    <asp:Button ID="btnQuaterlyShipmentEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnQuaterlyShipmentEmail_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Yearly Shipment Statement Email
                </td>
                <td align="left"> 
                     <asp:DropDownList Width="95%"  ID="ddlYearsforYearlyShipment" runat="server" CssClass="do-not-disable input_in">
                      </asp:DropDownList>  
                </td>
                <td align="left">
                    <asp:Button ID="btnYearlyShipmentEmail" runat="server" Text="Send Email" CssClass="da_save_button"
                        OnClick="btnYearlyShipmentEmail_Click" />
                </td>
            </tr>
           <%-- <tr>
                <td align="left">
                    Inline Cut Pending Email 
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtInlineNotCutEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnInlineNotCutEmail" runat="server" CssClass="sentEmail" OnClick="btnInlineNotCutEmail_Click" />
                </td>
            </tr>--%>
           <%--  <tr>
                <td align="left">
                    PP Meeting Forms for Styles Cut Today Email 
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPPMeetingFormsForStylesCutTodayEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnPPMeetingFormsForStylesCutTodayEmail" runat="server" CssClass="sentEmail" OnClick="btnPPMeetingFormsForStylesCutTodayEmail_Click" />
                </td>
            </tr>--%>
             <tr class="da_table_tr_bg">
                <td align="left">
                    FITS Comments/SAMPLE Pending Over a Week Email 
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="txtFITSCommentsPendingOverAWeekEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnFITSCommentsPendingOverAWeekEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnFITSCommentsPendingOverAWeekEmail_Click" />
                </td>
            </tr>  
             <tr class="da_table_tr_bg2">
                <td align="left">
                    STYLE UPDATES AND PENDING TASKS
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtStyleUpdatesAndPendingTasks" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnStyleUpdatesAndPendingTasks" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="StyleUpdatesAndPendingTasksl_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg">
                <td align="left">
                    Price Variation
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="txtFITSCommentsPendingOverAWeekEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnPriceVariation" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="PriceVariation_Click" />
                </td>
            </tr>  
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Pending Buying Samples Email 
                </td>
                <td align="left">
                    <%--<asp:TextBox runat="server" ID="txtFITSCommentsPendingOverAWeekEmail" CssClass="date-picker date_style invoice_input"></asp:TextBox>--%>
                </td>
                <td align="left">
                    <asp:Button ID="btnPendingBuyingSamples" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnPendingBuyingSamplesEmail_Click" />
                </td>
            </tr>   
            <tr class="da_table_tr_bg">
                <td align="left">
                    Production and QA Update Email
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtProductionAndQAUpdateEmail" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnProductionAndQAUpdateEmail" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnProductionAndQAUpdateEmail_Click" />
                </td>
            </tr>          
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Samples delayed or to be dispatched this week
                </td>
                <td align="left">
                    
                </td>
                <td align="left">
                    <asp:Button ID="btnSampledDalayed" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnSampledDalayed_Click" />
                </td>
            </tr> 
             <tr class="da_table_tr_bg">
                <td align="left">
                    Bulk/Garment Pending Email
                </td>
                <td align="left">
                    
                </td>
                <td align="left">
                    <asp:Button ID="btnBulkOrGarmentPending" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="BulkOrGarmentPending_Click" />
                </td>
            </tr>      
             <tr class="da_table_tr_bg2">
                <td align="left">
                    Order Agreement Change IKANDI
                </td>
               <td align="left">
                    <asp:TextBox runat="server" ID="txtIkandReportDate" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOrderAgrChangeIkandi" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnOrderAgrChangeIkandi_Click" />
                </td>
            </tr>   
            <tr class="da_table_tr_bg">
                <td align="left">
                    Order Agreement BIPL
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtBIPLReportDate" CssClass="th date_style invoice_input input_in"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnOrderAgrBIPL" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnOrderAgrBIPL_Click" />
                </td>
            </tr>      
            
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Status File Resolution Pending 
                </td>
                <td align="left">
                    
                </td>
                <td align="left">
                    <asp:Button ID="btnResolutionPending" runat="server" Text="Send Email" CssClass="da_save_button" OnClick="btnResolutionPending_Click" />
                </td>
            </tr>
            <%--abhishek 17/3/2016--%>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Daily reports
                </td>
                <td align="left">
                </td>
                <td align="left">
                    <asp:Button ID="btndailyreport" runat="server" Text="Send Email" 
                        CssClass="da_save_button" onclick="btndailyreport_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                    Hrs reports
                </td>
                <td align="left">
                </td>
                <td align="left">
                    <asp:Button ID="btnhrsreport" runat="server" Text="Send Email" 
                        CssClass="da_save_button" onclick="btnhrsreport_Click" />
                </td>
            </tr>
            <tr class="da_table_tr_bg2">
                <td align="left">
                     Plenty Report
                </td>
                <td align="left">
                </td>
                <td align="left">
                    <asp:Button ID="btnPlentyReport" runat="server" Text="Send Email" 
                        CssClass="da_save_button" onclick="btnPlentyReport_Click" />
                </td>
            </tr>
             <tr class="da_table_tr_bg2">
                <td align="left">
                     Facotry Performance Report
                </td>
                <td align="left">
                </td>
                <td align="left">
                    <asp:Button ID="btnfactoryperformence" runat="server" Text="Send Email" 
                        CssClass="da_save_button" onclick="btnfactoryperformence_Click" />
                </td>
            </tr>
        </table>
 
</asp:Content>
