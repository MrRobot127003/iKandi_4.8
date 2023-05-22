using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;



namespace iKandi.BLL
{
    public class CourierController : BaseController
    {
        #region

        public CourierController()
        {
        }

        public CourierController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public Couriers GetAllCourier()
        {
            return this.CourierDataProviderInstance.GetAllCourier();
        }

        public Couriers GetAllCourierByDate(DateTime SentOn, string SearchKeyword, int Type)
        {
            return this.CourierDataProviderInstance.GetAllCourierByDate(SentOn, SearchKeyword, Type);
        }
        public bool GenerateDailyCourierReport(string PDFPath, DateTime SentOn, int BHtYPE)//, int BHtYPE)
        {
            //Couriers couriers = this.CourierDataProviderInstance.GetAllCourierByDate(SentOn, string.Empty, 2);//, BHtYPE);
            //updated by abhishek on 7/7/2015 for genrate pdf on bases of buyingHouse
            Couriers couriers = this.CourierDataProviderInstance.GetAllCourierByDate_2(SentOn, string.Empty, 2, BHtYPE);
            //end

            if (couriers.Count == 0)
                return false;

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(PDFPath, "COURIERS", HeaderColor);

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("ATTN", ContentAlignment.Horizontal, 330));
            gen.Columns.Add(new PDFHeader("Reference Number", ContentAlignment.Horizontal, 350));
            gen.Columns.Add(new PDFHeader("Buyer", ContentAlignment.Horizontal, 280));
            gen.Columns.Add(new PDFHeader("Department", ContentAlignment.Horizontal, 320));
            gen.Columns.Add(new PDFHeader("Item", ContentAlignment.Horizontal, 220));
            gen.Columns.Add(new PDFHeader("Qty", ContentAlignment.Horizontal, 200));
            gen.Columns.Add(new PDFHeader("Fabric", ContentAlignment.Horizontal, 300));
            gen.Columns.Add(new PDFHeader("Purpose", ContentAlignment.Horizontal, 550));
            gen.Columns.Add(new PDFHeader("Courier AWB Number", ContentAlignment.Horizontal, 300));
            gen.Columns.Add(new PDFHeader("Courier Company", ContentAlignment.Horizontal, 250));
            gen.Columns.Add(new PDFHeader("From", ContentAlignment.Horizontal, 320));

            gen.Rows = new List<List<PDFCell>>();

            foreach (Courier courier in couriers)
            {
                List<PDFCell> row = new List<PDFCell>();

                PDFCell cell = new PDFCell(courier.ContactName);
                row.Add(cell);

                cell = new PDFCell(courier.StyleNumber);
                row.Add(cell);

                cell = new PDFCell(courier.ClientName);
                row.Add(cell);

                cell = new PDFCell(courier.Department);
                row.Add(cell);

                cell = new PDFCell(courier.Item);
                row.Add(cell);

                cell = new PDFCell(courier.Quantity);
                row.Add(cell);

                cell = new PDFCell(courier.Fabric);
                row.Add(cell);

                cell = new PDFCell(courier.Purpose);
                row.Add(cell);

                cell = new PDFCell(courier.CourierNumber);
                row.Add(cell);

                cell = new PDFCell(courier.CourierCompany);
                row.Add(cell);

                cell = new PDFCell(courier.SentByUserName);
                row.Add(cell);

                gen.Rows.Add(row);
            }
            if (gen.Rows.Count > 0)
            {

                return gen.GeneratePDF();
            }
            else
            {
                return false;
            }
        }

        public int InsertCourier(Courier CourierDetail)
        {
            int courrierID = this.CourierDataProviderInstance.InsertCourier(CourierDetail);

            /*
            if (courrierID > 0) // update fitstrack to update courier details fits_track table
            {
                if (CourierDetail.Purpose != null && CourierDetail.Purpose.Contains("fits"))
                {
                    this.FITsDataProviderInstance.UpdateFitsTarck(CourierDetail.StyleNumber, CourierDetail.Department, CourierDetail.CourierSentOn);
                }
            }
            
            */

            try
            {

                //if (CourierDetail.StyleNumber.Trim().Length < 8)
                //    return courrierID;

               
                //TODO: Identify if StyleNumber is a valid style number and not any other reference number
                Style style = this.StyleDataProviderInstance.GetStyleByStyleNumber(CourierDetail.StyleNumber.Trim());

                if (style.StyleID != 0 && style.StyleID != -1)
                {

                    try
                    {
                        //Gajendra Workflow
                        
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(style.StyleID, TaskMode.SAMPLE_SENT, this.LoggedInUser.UserData.UserID);
                        if (CourierDetail.SampleSent == true)
                            this.WorkflowControllerInstance.UpdateWorkflow_SampleSent_Closed_CourierSent(style.StyleID, TaskMode.SAMPLE_SENT, this.LoggedInUser.UserData.UserID);
                            
                        //if (style.StyleID > 0)
                        //{
                        //    // Update workflow
                        //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(style.StyleID, -1, -1);

                        //    if (instance != null && instance.WorkflowInstanceID > 0)
                        //    {
                        //        List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                        //        if (tasks.Count > 0 && tasks[0].StatusModeID == (int)StatusMode.SAMPLESENT
                        //            && tasks[0].ApplicationModule.ApplicationModuleID == (int)AppModule.DISPATCH_ENTRY_FILE)
                        //        {
                        //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);

                        //            if (!string.IsNullOrEmpty(style.SampleImageURL1))
                        //            {
                        //                WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
                        //                newTask.ActionDate = DateTime.Today;
                        //                newTask.AssignedTo = new User();
                        //                newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
                        //                newTask.ETA = style.ETA.AddDays(3);
                        //                newTask.ActionID = 3;
                        //                newTask.StatusModeID = (int)StatusMode.SAMPLERECEIVED;
                        //                newTask.WorkflowInstance = new WorkflowInstance();
                        //                newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
                        //                this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);

                        //                instance.CurrentStatus.StatusModeID = (int) StatusMode.SAMPLERECEIVED;
                        //                this.WorkflowControllerInstance.UpdateWorkflowInstance(instance);

                        //                this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDBIPL, instance.WorkflowInstanceID, style.ETA.AddDays(5));
                        //            }
                        //            else
                        //            {
                        //                this.WorkflowControllerInstance.CreateTask(StatusMode.SAMPLERECEIVED, instance.WorkflowInstanceID, style.ETA.AddDays(3));
                        //            }

                        //        }
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                    }

                    //if (CourierDetail.Purpose.Trim().ToLower() == "1st sample")
                    //{
                    //    style.CourierSentOn = CourierDetail.CourierSentOn;
                    //    this.StyleDataProviderInstance.UpdateStyle(style);
                    //}
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return courrierID;
        }

        public void UpdateCourier(Courier CourierDetail)
        {
            this.CourierDataProviderInstance.UpdateCourier(CourierDetail);
        }
        //Added By Abhishek
        public bool GetAttchemrntEmilBuyingHouseBAL(string PDFPath, DateTime SentOn, int bcheck)
        {
            DataTable dt = new DataTable();
            bool Bcheck;

            dt = CourierDataProviderInstance.GetAttchemrntEmilBuyingHouseDAL(SentOn, string.Empty, 2, bcheck);
            bool exists = dt.Select().ToList().Exists(row => row["BuyingHouseID"].ToString().ToUpper() == "1");
            if (exists == true)
            {
                Bcheck = true;

            }
            else
            {
                Bcheck = false;
            }
            return Bcheck;


        }
        //END
    }
}
