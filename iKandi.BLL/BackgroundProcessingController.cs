using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iKandi.Common;


namespace iKandi.BLL
{
    public class BackgroundProcessingController : BaseController
    {
        #region Public Method

        public void ExecuteProcess()
        {
            //ProcessEmails();
            if (Constants.ISNEWEMAILSCHEDULERACTIVE == "Y")
                ProcessEmails_ScheduleTemplate();
            else
                ProcessEmails();
            ProcessWorkflow();
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Process the emails
        ///  - Send Courier Emails daily
        ///  - Send Monday Company Report every Sunday
        ///  - etc.
        /// </summary>
        /// 
        //Edited by abhishek on 23/2/2016
        private void ProcessEmails()
        {

            //System.Diagnostics.Debugger.Break();
            System.Diagnostics.Trace.WriteLine("Processing of Back Ground processor started on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            try
            {
                 
                NotificationController controller = new NotificationController();
                DateTime dt6AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
                DateTime dt7AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
                DateTime dt8AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                DateTime dt9AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
                DateTime dt10AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
                DateTime dt11AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0);
                DateTime dt12PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
                DateTime dt13PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
                DateTime dt14PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
                DateTime dt15PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
                DateTime dt18PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);
                DateTime dt19PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);
                DateTime dt20PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
                DateTime dt21PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 0, 0);
                DateTime dt22PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
                //------------------------------------------------ Courier Dispatch List Email--------------------------------------
                //if (Convert.ToString(DateTime.Now.DayOfWeek) != "Sunday")
                //{
                //    if (DateTime.Now > dt14PM && DateTime.Now < dt15PM && Convert.ToString(DateTime.Now.DayOfWeek) != "Monday")
                //    {
                //        controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                //    }
                //    else
                //    {
                //        controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                //    }
                //}
                //-------------------------------------------------------------abhishek--------------------------//
                NotificationController objcontroller = new NotificationController();
                DataSet ds =objcontroller.GetDispatchEntryMailWeekName();
                DataTable dt=ds.Tables[0];
                int StartHH = Convert.ToInt32(dt.Rows[0]["Hours"].ToString());
                int MinMM = Convert.ToInt32(dt.Rows[0]["Min"].ToString());
                string DaysName = dt.Rows[0]["Days"].ToString();
                string[] values = DaysName.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                DateTime Extacttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, StartHH, MinMM, 0);
                /* if (DateTime.Now > dt14PM && DateTime.Now < dt15PM)
                 {
                     //if (Convert.ToString(DateTime.Now.DayOfWeek) != "Sunday")
                     //{
                     //    controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                     //}
                     //else if (Convert.ToString(DateTime.Now.DayOfWeek) == "Monday")
                     //{
                     //    controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                     //}

                     if (Convert.ToString(DateTime.Now.DayOfWeek) == "Monday")
                     {
                         controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                     }
                     //else if (Convert.ToString(DateTime.Now.DayOfWeek) == "Sunday")
                     //{
                     //    controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                     //}
                     else
                     {
                         controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                     }
                

                 }*/
                //if (DateTime.Now == Extacttime)
                //{
                //    foreach (string WeekName in values)
                //    {

                //        if (DateTime.Now.DayOfWeek.ToString() == "Monday")
                //        {
                //            controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                //        }
                //        else
                //        {
                //            controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                //        }
                        
                           
                        
                //    }

                //}
                // Send Courier Email
                if (DateTime.Now >= dt14PM && DateTime.Now < dt15PM)
                {
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                    {
                        controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                    }
                    else if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
                    {
                        controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                    }
                }
         //End by abhishek on 23/2/2016



                //---------------------------------------------------end------------------------------------------------------------
                //-------------------------------------------------Production Report Email-------------------------------------------
                //if (DateTime.Now > dt12PM && DateTime.Now < dt13PM)
                //{
                //    controller.SendProductionReportDaily();
                //    //if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //    //{
                //    //    controller.SendProductionReportWeekly();
                //    //}
                //}
                //------------------------------------------------ end---------------------------------------------------------------
                // end
                //if (DateTime.Now >= dt14PM && DateTime.Now < dt15PM)
                //{
                //    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //    {
                //        controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                //    }
                //    else if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
                //    {
                //        controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                //    }
                //}
                //------------------------------------QA Form Pending Email---------------------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendQAPendingToday();
                //}
                //-------------------------------------end--------------------------------------------------------------------------

                //------------------------------------------------------------Live Order Email--------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendLiveOrdersOverallToday(DateTime.Today.AddDays(-1));
                //}
                //-------------------------------------------------------------end---------------------------------------------------
                //------------------------------------------------------------Only Ex-Factory Date Changed Email--------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendOnlyExFactoryChangedEmail(DateTime.Today.AddDays(-1));
                //}
                //-----------------------------------------------------------END----------------------------------------------------
                //-----------------------------------------------------------Ex-Factory Planned Email-------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendExFactoryPlannedToday(DateTime.Today.AddDays(-1));
                //}
                //-------------------------------------------------------------END-----------------------------------------------------

                //--------------------------------------------------------------Costed Styles Email------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendCostedStyles(DateTime.Today.AddDays(-1), true);
                //}
                //-------------------------------------------------------------END--------------------------------------------------------

                //----------------------------------------------------------------New Orders Email------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendNewOrdersOverallYesterday(DateTime.Today.AddDays(-1));
                //}
                // ---------------------------------------------------------------END-------------------------------------------------------

                //----------------------------------------------------------------Designs Creation Email------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendDailyDesignsCreationEmail(DateTime.Today.AddDays(-1), true);
                //}
                //----------------------------------------------------------------END---------------------------------------------------------

                //-------------------------------------------------------------Order Form Changes Email--------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.GetOrderFormChangedByDate(DateTime.Today.AddDays(-1));
                //}
                //--------------------------------------------------------------------END-------------------------------------------------

                //----------------------------------------------------------------FIT Comments Uploaded----------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendFITSCommentsUploaded(DateTime.Today.AddDays(-1), true);
                //}
                //--------------------------------------------------------------END------------------------------------------------------------


                //----------------------------------------------------------ORDER DELEVERED EMAIL----------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendOrderDeleveredEmail(DateTime.Today.AddDays(-1));
                //}
                //---------------------------------------------------------END-----------------------------------------------------------------

                //----------------------------------------------------------Live Pending Email-----------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendLivePendingEmail(DateTime.Today.AddDays(-1));
                //}
                //-----------------------------------------------------------------END------------------------------------------------------

                //--------------------------------------------------------------------FITS Comments/SAMPLE Pending Over A Week Email-------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    this.NotificationControllerInstance.SendSamplePendingOverAWeekEmail();
                //    this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail_WithPrice();
                //}
                //-------------------------------------------------------------------END-----------------------------------------------------------------------------------

                //------------------------------------------------------------------STYLE UPDATES AND PENDING TASKS------------------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendStyleUpdateAndPendingTest(DateTime.Today.AddDays(-1), true);
                //}
                //-----------------------------------------------------------------------END-----------------------------------------------------------------------------

                //------------------------------------------------------------------------Price Variation----------------------------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendPriceVariationList();
                //}
                //-----------------------------------------------------------------------END-----------------------------------------------------------------------------

                //------------------------------------------------------------------------Pending Buying Samples Email--------------------------------------------------------------------------------
                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    controller.SendPendingBuyingSamplesEmail();
                //}
                //------------------------------------------------------------------------END---------------------------------------------------------------------------------------------------------

                //------------------------------------------------------------------------Production And QA Update Email------------------------------------------------------------------------------------------------------------

                //if (DateTime.Now > dt9AM && DateTime.Now < dt10AM)
                //{
                //    this.NotificationControllerInstance.SendProductionAndQAUpdateEmail(DateTime.Today.AddDays(-1));

                //}

                //-------------------------------------------------------------------------END---------------------------------------------------------------------------------------------------------


                //SEND PENDING BUYING SAMPLES EMAIL EVERY MONDAY 9AM
                //if (DateTime.Now >= dt9AM && DateTime.Now < dt10AM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //{
                //    controller.SendPendingBuyingSamplesEmail();

                //}
                //if (DateTime.Now >= dt6AM && DateTime.Now < dt7AM)
                //{
                //    controller.GetChangedOrderIkand("IKANDI", DateTime.Now);
                //}

                // Send Courier Email


                // Send Production Report
                //if (DateTime.Now >= dt12PM && DateTime.Now < dt13PM)
                //{
                //    controller.SendProductionReportDaily();
                //    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //    {
                //        controller.SendProductionReportWeekly();
                //    }
                //}

                // Send Monday Company Report email every Monday
                //if (DateTime.Now >= dt11AM && DateTime.Now < dt12PM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //{
                //    controller.SendMondayCompanyReports(true);
                //}

                //// Send Monday Company Resolution Filled Email  every Tuesday 12 pm
                //if (DateTime.Now >= dt12PM && DateTime.Now < dt13PM && DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                //{
                //    controller.SendMondayCompanyResolutionFilledEmail();
                //}

                //if (DateTime.Now >= dt12PM && DateTime.Now < dt13PM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //{
                //    controller.GetSampleDalayedOrToBeDispatchEmail();
                //}

                //if (DateTime.Now >= dt8AM && DateTime.Now < dt9AM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //{

                //}


                //// Send Packing Overall Today,  Send Inline Cut Overall Today, Send StcUnAllocated Overall Today for styles , Send PPMeeting Pending Today, Send QA Form Pending Email,  Send Top Requested Email, Send Live OrderEmail, Send Ex-Factory changed today, EX FACTORY PLANNED email, Approved To ExFactory email
                //if (DateTime.Now >= dt18PM && DateTime.Now < dt19PM)
                //{
                //   // controller.SendPackingOverallToday(DateTime.Today.AddDays(0));
                //    //controller.SendInlineCutOverallToday(DateTime.Today.AddDays(0));
                //    //controller.SendStcUnAllocatedOverallToday(DateTime.Today.AddDays(0));
                //    //controller.SendPPMeetingPendingToday(DateTime.Today.AddDays(0));
                //    //controller.SendInlineCutPendingTodayEmail(DateTime.Today.AddDays(0));
                //   // controller.SendQAPendingToday();
                //    // controller.SendDailyTopRequested(DateTime.Today.AddDays(0));
                //    //controller.SendLiveOrdersOverallToday(DateTime.Today.AddDays(0));
                //    //controller.SendOnlyExFactoryChangedEmail(DateTime.Today.AddDays(0));
                //    //controller.SendExFactoryPlannedToday(DateTime.Today.AddDays(0));
                //    //controller.SendApprovedToExFactoryToday(DateTime.Today.AddDays(0));
                //    //controller.SendLivePendingEmail(DateTime.Today.AddDays(0));
                //    controller.SendStyleUpdateAndPendingTest(DateTime.Today.AddDays(0), true);
                //    controller.GetChangedOrderIkand("BIPL", DateTime.Now);
                //}


                //if (DateTime.Now >= dt19PM && DateTime.Now < dt20PM)
                //{
                //    //controller.SendAllocationSummary(DateTime.Today, true);
                //    //controller.SendCostedStyles(DateTime.Today, true);
                //    //controller.SendPPMeetingFormForStyleCutToday(DateTime.Today.AddDays(0));

                //    int currentMonth = DateTime.Today.Month;
                //    DateTime date = DateTime.MinValue;
                //    DateTime todayDate = DateTime.Today;
                //    if (currentMonth < 12)
                //    {
                //        date = new DateTime(DateTime.Today.Year, (currentMonth + 1), 1, 0, 0, 0);
                //        date = date.AddDays(-1);
                //    }
                //    else
                //    {
                //        date = new DateTime(DateTime.Today.Year, currentMonth, 31, 0, 0, 0);
                //    }

                //    long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, date, todayDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));

                //    if (days == 0)
                //    {
                //        // for Monthly email
                //        controller.SendMonthlyShipmentStatement(DateTime.Today.AddMonths(-1).AddDays(1), DateTime.Today);
                //    }

                //    if (days == 0 && (currentMonth % 3 == 0))
                //    {
                //        // for Monthly email
                //        controller.SendQuarterlyShipmentStatement(DateTime.Today.AddMonths(-3).AddDays(1), DateTime.Today);
                //    }

                //    if (days == 0 && currentMonth == 3)
                //    {
                //        // for Yearly email
                //        controller.SendYearlyShipmentStatement(DateTime.Today.AddYears(-1).AddDays(1), DateTime.Today);
                //    }
                //}

                //// Send New Orders Overall Yesterday, Send Order Delevered Email yesterday
                //if (DateTime.Now >= dt8AM && DateTime.Now < dt9AM)
                //{
                //    //controller.SendNewOrdersOverallYesterday(DateTime.Today.AddDays(-1));
                //    //controller.SendDailyDesignsCreationEmail(DateTime.Today.AddDays(-1), true);
                //    //controller.SendFITSCommentsUploaded(DateTime.Today.AddDays(-1), true);
                //    //controller.SendOrderDeleveredEmail(DateTime.Today.AddDays(-1));
                //    //controller.SendResolutionPendingStatusMeetingFile();
                //}

                ////Price Variation Email
                ////if (DateTime.Now >= dt9AM && DateTime.Now < dt10AM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                ////{
                ////    controller.SendPriceVariationList();
                ////}

                //if (DateTime.Now >= dt21PM && DateTime.Now < dt22PM && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                //{
                //    //controller.SendBulkOrGarmetTestPendingEmail();                               
                //}

                //// Edit Order, Send Exfactory Overall Today, Send Status Meeting Resolution Filled on that date, Send Part OF ExFactory Overall Email
                //if (DateTime.Now >= dt21PM && DateTime.Now < dt22PM)
                //{
                //    controller.SendStatusMeetingResolutionFilledToday(DateTime.Today.AddDays(0));
                //    //controller.SendExfactoryOverallToday(DateTime.Today.AddDays(0));
                //    controller.SendPartOFExFactoryOverallToday(DateTime.Today.AddDays(0));
                //    //controller.GetOrderFormChangedByDate(DateTime.Today.AddDays(0));
                //    this.NotificationControllerInstance.SendEmailForEditAccessoryOrder();
                //    this.NotificationControllerInstance.SendFabricOrderFormChangesEmail();
                //    //this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail();
                //}

                ////if (DateTime.Now >= dt8AM && DateTime.Now < dt9AM)
                ////{
                ////    this.NotificationControllerInstance.SendSamplePendingOverAWeekEmail();
                ////}
                ////if (DateTime.Now >= dt20PM && DateTime.Now < dt21PM)
                ////{
                ////    this.NotificationControllerInstance.SendProductionAndQAUpdateEmail(DateTime.Today.AddDays(0));
                ////    this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail_WithPrice();
                ////}

                System.Diagnostics.Trace.WriteLine("Processing of Back Ground processor Ends on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Trace.WriteLine("Exception Occurs in  Back Ground processor  on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }



        }

        private void ProcessEmails_ScheduleTemplate()
        {
            string tmFrom = DateTime.Now.AddMinutes(-60).ToString("HH:mm") + ":00";
            string tmto = DateTime.Now.ToString("HH:mm") + ":00";
            List<EmailSchedule> emailSchedules =
                   this.AdminDataProviderInstance.Get_All_Email_Schedule_Tempalte_Data(tmFrom, tmto);
            foreach (var emailSchedule in emailSchedules)
            {
                ProcessEmails_Schedule(emailSchedule);
            }
        }

        private void ProcessEmails_Schedule(EmailSchedule es)
        {

            //System.Diagnostics.Debugger.Break();
            System.Diagnostics.Trace.WriteLine("Processing of Back Ground processor started on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            try
            {
                NotificationController controller = new NotificationController();

                //SEND PENDING BUYING SAMPLES EMAIL EVERY MONDAY 9AM

               

                if (es.TemplateType == EmailTemplateType.ORDERCHANGEREQUESTIKANDI)
                {
                    controller.GetChangedOrderIkand("IKANDI", DateTime.Now);
                }

                // Send Courier Email
                if (es.TemplateType == EmailTemplateType.COURIERDISPATCHLIST)
                {
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                    {
                        controller.SendCourierDispatchList(DateTime.Today.AddDays(-2));
                    }
                    else if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
                    {
                        controller.SendCourierDispatchList(DateTime.Today.AddDays(-1));
                    }
                }

                // Send Production Report
                if (es.TemplateType == EmailTemplateType.PRODUCTIONREPORT)
                {
                    controller.SendProductionReportDaily();
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                    {
                        controller.SendProductionReportWeekly();
                    }
                }

                // Send Monday Company Report email every Monday
                if (es.TemplateType == EmailTemplateType.MONDAYCOMPANYREPORTS && DateTime.Today.DayOfWeek == DayOfWeek.Friday)
                {
                    controller.SendMondayCompanyReports(true);
                }

                // Send Monday Company Resolution Filled Email  every Tuesday 12 pm
                if (es.TemplateType == EmailTemplateType.MONDAYCOMPANYFILECOMPLETED && DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                {
                    //controller.SendMondayCompanyResolutionFilledEmail();
                }

                if (es.TemplateType == EmailTemplateType.SamplesDelayedOrToBeDispatchedThisWeek && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                {
                    controller.GetSampleDalayedOrToBeDispatchEmail();
                }

                // Send Packing Overall Today,  Send Inline Cut Overall Today, Send StcUnAllocated Overall Today for styles , Send PPMeeting Pending Today, Send QA Form Pending Email,  Send Top Requested Email, Send Live OrderEmail, Send Ex-Factory changed today, EX FACTORY PLANNED email, Approved To ExFactory email
                


                if (es.TemplateType == EmailTemplateType.STYLESCOSTEDTODAY)
                {
                    controller.SendCostedStyles(DateTime.Today, true);

                    int currentMonth = DateTime.Today.Month;
                    DateTime date = DateTime.MinValue;
                    DateTime todayDate = DateTime.Today;
                    if (currentMonth < 12)
                    {
                        date = new DateTime(DateTime.Today.Year, (currentMonth + 1), 1, 0, 0, 0);
                        date = date.AddDays(-1);
                    }
                    else
                    {
                        date = new DateTime(DateTime.Today.Year, currentMonth, 31, 0, 0, 0);
                    }

                    long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, date, todayDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));

                    if (days == 0)
                    {
                        // for Monthly email
                        controller.SendMonthlyShipmentStatement(DateTime.Today.AddMonths(-1).AddDays(1), DateTime.Today);
                    }

                    if (days == 0 && (currentMonth % 3 == 0))
                    {
                        // for Monthly email
                        controller.SendQuarterlyShipmentStatement(DateTime.Today.AddMonths(-3).AddDays(1), DateTime.Today);
                    }

                    if (days == 0 && currentMonth == 3)
                    {
                        // for Yearly email
                        controller.SendYearlyShipmentStatement(DateTime.Today.AddYears(-1).AddDays(1), DateTime.Today);
                    }
                }

                // Send New Orders Overall Yesterday, Send Order Delevered Email yesterday
                //if (es.TemplateType == EmailTemplateType.NEWORDERS || es.TemplateType == EmailTemplateType.DESIGNCREATION
                //    || es.TemplateType == EmailTemplateType.COMMENTSUPLOADED || es.TemplateType == EmailTemplateType.ORDERDELEVERED)
                //{
                //    //controller.SendNewOrdersOverallYesterday(DateTime.Today.AddDays(-1));
                //    //controller.SendDailyDesignsCreationEmail(DateTime.Today.AddDays(-1), true);
                //    //controller.SendFITSCommentsUploaded(DateTime.Today.AddDays(-1), true);
                //    //controller.SendOrderDeleveredEmail(DateTime.Today.AddDays(-1));
                //}

                //Price Variation Email
                if (es.TemplateType == EmailTemplateType.PRICEVARIATION && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                {
                    controller.SendPriceVariationList();
                }

                if (es.TemplateType == EmailTemplateType.BULKORGARMENTTESTSPENDING && DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                {
                    //controller.SendBulkOrGarmetTestPendingEmail();                               
                }

                // Edit Order, Send Exfactory Overall Today, Send Status Meeting Resolution Filled on that date, Send Part OF ExFactory Overall Email
                if (es.TemplateType == EmailTemplateType.STATUSMEETINGRESOLUTION || es.TemplateType==EmailTemplateType.PARTEXFACTORYTODAY
                    || es.TemplateType == EmailTemplateType.EDITFABRICORDER || es.TemplateType==EmailTemplateType.EDITACCESSORYORDER)
                {
                 
                    //controller.SendExfactoryOverallToday(DateTime.Today.AddDays(0));
                    //controller.SendPartOFExFactoryOverallToday(DateTime.Today.AddDays(0));
              
                  
                   
                    //this.NotificationControllerInstance.SendFITSPendingOverAWeekEmail();
                }

                if (es.TemplateType == EmailTemplateType.SAMPLEPENDINGEMAIL)
                {
                    this.NotificationControllerInstance.SendSamplePendingOverAWeekEmail();
                }
              

                System.Diagnostics.Trace.WriteLine("Processing of Back Ground processor Ends on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Trace.WriteLine("Exception Occurs in  Back Ground processor  on  ----" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }



        }
        /// <summary>
        /// Moves the workflow to UnderClerance stage on Landing ETA Date
        /// </summary>
        private void ProcessWorkflow()
        {
            try
            {
                //System.Diagnostics.Debugger.Break();


                DataTable dtShipmentIds = this.DeliveryDataProviderInstance.GetShipmentIdsForTodaysLandingETA();

                foreach (DataRow drShipmentId in dtShipmentIds.Rows)
                {
                    int shipmentId = (drShipmentId["ShipmentId"] == DBNull.Value) ? -1 : Convert.ToInt32(drShipmentId["ShipmentId"]);

                    DataTable dt = this.DeliveryDataProviderInstance.GetShipmentPlanningOrders(shipmentId);

                    foreach (DataRow row in dt.Rows)
                    {
                        int orderDetailID = Convert.ToInt32(row["OrderDetailID"]);
                        int productionPlanningID = Convert.ToInt32(row["ProductionPlanningID"]);
                       // Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(orderDetailID);
                        iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId_Forprocessworkflow(orderDetailID);
                        OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == orderDetailID; });
                        WorkflowInstance instance;

                        // Update workflow
                        if (Convert.ToInt32(row["IsPartShipment"]) == 1)
                            instance = this.WorkflowControllerInstance.GetInstance(productionPlanningID);
                        else
                            instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);

                        List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                        DeliveryBooking db = this.DeliveryDataProviderInstance.GetBookingByOrderID(productionPlanningID);

                        if (db == null)
                        {
                            db = new DeliveryBooking();
                            db.BookingID = -1;
                            db.OrderDetailID = orderDetailID;
                            db.ProductionPlanningID = productionPlanningID;
                            db.SentToProcessingHouseOn = DateTime.MinValue;
                            db.BookingRequestedOn = DateTime.MinValue;
                            db.ExpectedDC = DateTime.MinValue;
                        }
                        else
                            db.ProductionPlanningID = productionPlanningID;


                        foreach (WorkflowInstanceDetail task in tasks)
                        {
                            if (task.StatusModeID == (int)(TaskMode.UNDER_CLEARENCE_HANGING) || task.StatusModeID == (int)TaskMode.UNDER_CLEARANCE_FLAT || task.StatusModeID == (int)TaskMode.UNDER_CLEARENCE)
                            {
                                this.WorkflowControllerInstance.CompleteTask(task, Constants.ADMIN_USER_ID);

                                string modeName = iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(row["Mode"]));
                                bool isFlat = iKandi.BLL.CommonHelper.IsFlatDelivery(Convert.ToInt32(row["Mode"]));

                                if (modeName.ToUpper().IndexOf("D") > -1)
                                {
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.DC);
                                    this.WorkflowControllerInstance.CompleteTask(task, Constants.ADMIN_USER_ID);
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instance.WorkflowInstanceID, orderDetail.DC.AddDays(3));
                                }
                                else if (!isFlat)
                                {
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.Consolidated,instance.WorkflowInstanceID, (!isFlat) ? orderDetail.DC.AddDays(-8) : orderDetail.DC.AddDays(-4));
                                    this.DeliveryDataProviderInstance.UpdateBookingOrder(db);
                                }
                                else
                                {
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.DC);
                                    this.DeliveryDataProviderInstance.UpdateBookingOrder(db);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion


    }
}
