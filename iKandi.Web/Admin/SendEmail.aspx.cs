using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;



namespace iKandi.Web
{
    public partial class SendEmailPanel : BasePage  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                iKandi.Web.Components.DropdownHelper.BindCurrentNextYears(ddlYearsforYearlyShipment as ListControl);
                ddlYearsforYearlyShipment.SelectedValue = DateTime.Today.Year.ToString();
                iKandi.Web.Components.DropdownHelper.BindYears(ddlYearForQuaterShipment as ListControl);
                ddlYearForQuaterShipment.SelectedValue = DateTime.Today.Year.ToString();
                int month = DateTime.Today.Month;
                if (month >= 1 && month <= 3)
                {
                    ddlQuaterForQuaterShipment.SelectedValue = "1";
                }
                else if (month >= 4 && month <= 6)
                {
                    ddlQuaterForQuaterShipment.SelectedValue = "4";
                }
                else if (month >= 7 && month <= 9)
                {
                    ddlQuaterForQuaterShipment.SelectedValue = "7";
                }
                else
                {
                    ddlQuaterForQuaterShipment.SelectedValue = "10";
                }
                
                iKandi.Web.Components.DropdownHelper.BindYears(ddlYearForMonthShipmentEmail as ListControl);
                ddlYearForMonthShipmentEmail.SelectedValue = DateTime.Today.Year.ToString();
                iKandi.Web.Components.DropdownHelper.BindMonths(ddlMonthForMonthShipmentEmail as ListControl);
                ddlMonthForMonthShipmentEmail.SelectedValue = DateTime.Today.Month.ToString();
            }
            
        }

        protected void btnCourierDispatchListEmail_Click(object sender, EventArgs e)
        {
            
            //DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtCourierDispatchListEmail.Text).Value;
            DateTime date = DateTime.ParseExact(txtCourierDispatchListEmail.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            this.NotificationControllerInstance.SendCourierDispatchList(date);
        }

        protected void btnProductionReportEmail_Click(object sender, EventArgs e)
        {
            this.NotificationControllerInstance.SendProductionReportDaily();
            this.NotificationControllerInstance.SendProductionReportWeekly();
            //this.NotificationControllerInstance.SendProductionReport();
        }

        protected void btnMondayCompanyReportEmail_Click(object sender, EventArgs e)
        {

            this.NotificationControllerInstance.SendMondayCompanyReports(true);
        }

        protected void btnSendMondayCompanyResolutionFilledEmail_Click(object sender, EventArgs e)
        {

            //this.NotificationControllerInstance.SendMondayCompanyResolutionFilledEmail();
        }

        //protected void btnOverallPackingEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOverallPackingEmail.Text).Value;
        //    //this.NotificationControllerInstance.SendPackingOverallToday(date);
        //}

        //protected void btnOverallInlineCutEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOverallInlineCutEmail.Text).Value;
        //    this.NotificationControllerInstance.SendInlineCutOverallToday(date);
        //}

        //protected void btnOverallStyleEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOverallStyleEmail.Text).Value;
        //    this.NotificationControllerInstance.SendStcUnAllocatedOverallToday(date);
        //}

        //protected void btnPPMeetingsPendingEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtPPMeetingsPendingEmail.Text).Value;
        //    this.NotificationControllerInstance.SendPPMeetingPendingToday(date);
        //}

        protected void btnQAFormPendingEmail_Click(object sender, EventArgs e)
        {
            this.NotificationControllerInstance.SendQAPendingToday();
        }

        //protected void btnTopRequestedEmail_Click(object sender, EventArgs e)
        //{
        //    this.NotificationControllerInstance.SendDailyTopRequested(DateTime.Today);
        //}

        protected void btnOverallLiveOrderEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOverallLiveOrderEmail.Text).Value;
            //this.NotificationControllerInstance.SendLiveOrdersOverallToday(date);
        }

        protected void btnExFactoryDateChangedEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtExFactoryDateChangedEmail.Text).Value;
         //  this.NotificationControllerInstance.SendOnlyExFactoryChangedEmail(date);
        }

        protected void btnOverallExFactoryPlannedEmail_Click(object sender, EventArgs e)
        {
           
        }

        //protected void btnOverallApprovedToExFactoryEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOverallApprovedToExFactoryEmail.Text).Value;
        //    this.NotificationControllerInstance.SendApprovedToExFactoryToday(date);
        //}

        //protected void btntxtAllocationSummaryEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtAllocationSummaryEmail.Text).Value;
        //    //this.NotificationControllerInstance.SendAllocationSummary(date, true);
        //    this.NotificationControllerInstance.SendStyleUpdateAndPendingTest(date, true);
        //}

        protected void btnCostedStylesEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtCostedStylesEmail.Text).Value;
            this.NotificationControllerInstance.SendCostedStyles(date, true);
        }

        protected void btnNewOrdersEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtNewOrdersEmail.Text).Value;
            this.NotificationControllerInstance.SendNewOrdersOverallYesterday(date);
        }

        protected void btnDesignsCreationEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtDesignsCreationEmail.Text).Value;
            this.NotificationControllerInstance.SendDailyDesignsCreationEmail(date, true);
        }

        protected void btnStatusMeetingResolutionFilledEmail_Click(object sender, EventArgs e)
        {
          
        }

        //protected void btnExFactoryOverallEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtExFactoryOverallEmail.Text).Value;
        //    this.NotificationControllerInstance.SendExfactoryOverallToday(date);
        //}

        protected void btnPartOfExFactoryEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtPartOfExFactoryEmail.Text).Value;
           // this.NotificationControllerInstance.SendPartOFExFactoryOverallToday(date);
        }

        protected void btnCommentsUploaded_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtCommentsUploaded.Text).Value;
            this.NotificationControllerInstance.SendFITSCommentsUploaded(date, true);
        }

        protected void btnOrderDeleveredEmail_Click(object sender, EventArgs e)
        {
             string  a = DateTime.Now.ToString("HH:mm:ss tt");
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOrderDeleveredEmail.Text).Value;
            this.NotificationControllerInstance.SendOrderDeleveredEmail(date);
        }

        

        protected void btnOrderFormChangesEmail_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtOrderFormChangesEmail.Text).Value;
            this.NotificationControllerInstance.GetOrderFormChangedByDate(date);
           
            //string client = string.Empty;
            //// string html = "";

            ////this.OrderControllerInstance.
            ////OrderController orderController = OrderController();
            //List<iKandi.Common.Order> order = this.OrderControllerInstance.GetOrderByCurrentDate(date);
            //if (order.Count == 0)
            //{
            //    System.Diagnostics.Trace.WriteLine("There is no record for Order form changes Email of the date " + DateTime.Today.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            //    return;
            //}
            //else if (order.Count > 0)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<TABLE cellpadding=5 border=1>");
            //    sb.Append("<TR>");
            //    sb.Append("<TH>SERIAL NUMBER</TH>");
            //    sb.Append("<TH>CHANGES</TH>");
            //    sb.Append("</TR>");
                
            //    foreach (iKandi.Common.Order ord in order)
            //    {
            //        if (client != "")
            //        {
            //            client = client + "," + ord.ClientID.ToString();
            //        }
            //        else
            //        {
            //            client = ord.ClientID.ToString();
            //        }

            //        string history = "";
            //        history = ord.History;

            //        if (ord.History.IndexOf(date.ToString("dd MMM yy (ddd)")) > -1)
            //        {
            //            history = ord.History.Substring(ord.History.IndexOf(date.ToString("dd MMM yy (ddd)")));
            //            string orderHistory = history.ToUpper() + "<BR/>";
            //            history = string.Empty;
            //            string[] delim = { "<BR/>" };
            //            string[] stringArray = orderHistory.Split(delim, StringSplitOptions.None);

            //            if (stringArray.Length > 0)
            //            {
            //                for (int i = 0; i < stringArray.Length; i++)
            //                {
            //                    if (stringArray[i].Trim() != string.Empty)
            //                    {
            //                        if (stringArray[i].Trim().ToUpper().IndexOf("FACTORY CHANGED ON MO") > -1 || stringArray[i].Trim().ToUpper().IndexOf("EX-FACTORY CHANGED ON ORDER FORM") > -1)
            //                        {
            //                            history = history + "";
            //                        }
            //                        else if (stringArray[i].Trim().ToUpper().IndexOf("EXFACTORY CHANGED") > -1 && stringArray[i].Trim().ToUpper().IndexOf("FROM MO") == -1)
            //                        {
            //                            history = history + "";
            //                        }
            //                        else
            //                        {
            //                            history = history + stringArray[i].Trim().ToUpper() + "<br/>";
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            history = string.Empty;
            //        }

            //        if (history == string.Empty)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            sb.Append("<TR>");
            //            sb.Append("<TD>" + ord.SerialNumber.ToUpper() + "</TD>");

            //            sb.Append("<TD style='text-align : left;'>" + history.ToUpper() + "</TD>");
            //            sb.Append("</TR>");
            //        }

            //    }
            //    sb.Append("</TABLE>");

            //    if (sb.ToString().ToUpper().IndexOf("<TD>") > -1)
            //    {
            //        System.Diagnostics.Trace.WriteLine("Order form changes Email process starts of the date " + date.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            //        this.NotificationControllerInstance.SendEmailForEditOrder(sb.ToString(), "", new List<String>(), 0, true, 1, client);
            //    }
            //    else
            //    {
            //        System.Diagnostics.Trace.WriteLine("There is no record for Order form changes Email of the date " + DateTime.Today.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            //    }
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine("There is no record for Order form changes Email of the date " + DateTime.Today.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            //}
        }



        protected void btnLivePendingEmail_Click(object sender, EventArgs e)
        {
            //iKandi.BLL.BackgroundProcessingController bl = new iKandi.BLL.BackgroundProcessingController();
            //bl.ExecuteProcess();
           
        }

        protected void btnMonthlyShipmentEmaill_Click(object sender, EventArgs e)
        {
            DateTime lastDate = DateTime.MinValue;
            if (ddlMonthForMonthShipmentEmail.SelectedValue != "12")
            {
                lastDate = new DateTime(Convert.ToInt32(ddlYearForMonthShipmentEmail.SelectedValue), (Convert.ToInt32(ddlMonthForMonthShipmentEmail.SelectedValue) + 1), 1, 0, 0, 0);
                lastDate = lastDate.AddDays(-1);
            }
            else
            {
                lastDate = new DateTime((Convert.ToInt32(ddlYearForMonthShipmentEmail.SelectedValue) + 1), 1, 1, 0, 0, 0);
                lastDate = lastDate.AddDays(-1);
            }
            DateTime fromDate = new DateTime(Convert.ToInt32(ddlYearForMonthShipmentEmail.SelectedValue), Convert.ToInt32(ddlMonthForMonthShipmentEmail.SelectedValue), 01, 0, 0, 0);

            DateTime toDate = new DateTime(Convert.ToInt32(ddlYearForMonthShipmentEmail.SelectedValue), Convert.ToInt32(ddlMonthForMonthShipmentEmail.SelectedValue), lastDate.Day, 0, 0, 0);
            this.NotificationControllerInstance.SendMonthlyShipmentStatement(fromDate, toDate);
        }

        protected void btnQuaterlyShipmentEmail_Click(object sender, EventArgs e)
        {
            DateTime lastDate = DateTime.MinValue;
            DateTime fromDate = new DateTime(Convert.ToInt32(ddlYearForQuaterShipment.SelectedValue), Convert.ToInt32(ddlQuaterForQuaterShipment.SelectedValue), 01, 0, 0, 0);
            if (ddlQuaterForQuaterShipment.SelectedValue != "10")
            {
                 lastDate = new DateTime(Convert.ToInt32(ddlYearForQuaterShipment.SelectedValue), (Convert.ToInt32(ddlQuaterForQuaterShipment.SelectedValue) + 3), 1, 0, 0, 0);
                lastDate = lastDate.AddDays(-1);
            }
            else
            {
                 lastDate = new DateTime((Convert.ToInt32(ddlYearForQuaterShipment.SelectedValue) + 1),1, 1, 0, 0, 0);
                lastDate = lastDate.AddDays(-1);
            }
                DateTime toDate = new DateTime(Convert.ToInt32(ddlYearForQuaterShipment.SelectedValue), (Convert.ToInt32(ddlQuaterForQuaterShipment.SelectedValue) + 2), lastDate.Day, 0, 0, 0);
            this.NotificationControllerInstance.SendQuarterlyShipmentStatement(fromDate, toDate);
        }

        protected void btnYearlyShipmentEmail_Click(object sender, EventArgs e)
        {
            
            //ddlYearsforYearlyShipment.SelectedValue = DateTime.Today.Year.ToString();
            DateTime fromDate = new DateTime(Convert.ToInt32(ddlYearsforYearlyShipment.SelectedValue), 04, 01, 0, 0, 0);

            DateTime toDate = new DateTime((Convert.ToInt32(ddlYearsforYearlyShipment.SelectedValue) + 1), 03, 31, 0, 0, 0);
            this.NotificationControllerInstance.SendYearlyShipmentStatement(fromDate, toDate);
        }

        //protected void btnInlineNotCutEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtInlineNotCutEmail.Text).Value;
        //    this.NotificationControllerInstance.SendInlineCutPendingTodayEmail(date);
        //}

        //protected void btnPPMeetingFormsForStylesCutTodayEmail_Click(object sender, EventArgs e)
        //{
        //    DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtPPMeetingFormsForStylesCutTodayEmail.Text).Value;
        //    this.NotificationControllerInstance.SendPPMeetingFormForStyleCutToday(date);
        //}

        protected void btnFITSCommentsPendingOverAWeekEmail_Click(object sender, EventArgs e)
        {
            this.NotificationControllerInstance.SendSamplePendingOverAWeekEmail();
            this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail_WithPrice();
            //this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail();
        }

        protected void btnOrderAgrBIPL_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtBIPLReportDate.Text).Value;
            this.NotificationControllerInstance.GetChangedOrderIkand("BIPL", date);
        }

        protected void btnOrderAgrChangeIkandi_Click(object sender, EventArgs e)
        {
            DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtIkandReportDate.Text).Value;
            this.NotificationControllerInstance.GetChangedOrderIkand("IKANDI", date);
        }

        protected void btnResolutionPending_Click(object sender, EventArgs e)
        {

            //this.NotificationControllerInstance.SendResolutionPendingStatusMeetingFile();
        }


        protected void StyleUpdatesAndPendingTasksl_Click(object sender, EventArgs e)
        {
            
        }

        protected void PriceVariation_Click(object sender, EventArgs e)
        {
           // DateTime date = iKandi.Web.Components.DateHelper.ParseDate(txtStyleUpdatesAndPendingTasks.Text).Value;
            this.NotificationControllerInstance.SendPriceVariationList();
        }

        protected void btnPendingBuyingSamplesEmail_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnProductionAndQAUpdateEmail_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnSampledDalayed_Click(object sender, EventArgs e)
        {
            this.NotificationControllerInstance.GetSampleDalayedOrToBeDispatchEmail();
        }

        protected void BulkOrGarmentPending_Click(object sender, EventArgs e)
        {
            this.NotificationControllerInstance.SendBulkOrGarmetTestPendingEmail();
        }
        //added by abhishek abhishek ========================================//
        protected void btndailyreport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmailReport.aspx?Flag=" + "Direct" + "&MailType=" + "Daily report");
        }

        protected void btnhrsreport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mailhourlyreport.aspx?Flag=" + "Direct" + "&MailType=" + "Hourly report");
        }
        protected void btnPlentyReport_Click(object sender, EventArgs e) 
        {
            Response.Redirect("~/SendMailDirectPentlyReport.aspx?Flag=" + "Direct" + "&MailType=" + "Plenty report");
        }
        protected void btnfactoryperformence_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SendMailDirectFacotryPerformance.aspx?Flag=" + "Direct" + "&MailType=" + "Facotry Performance");
        }
        //end by abhishek

        
       
    }
}
