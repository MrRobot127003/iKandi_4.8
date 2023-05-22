using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class CostingController : BaseController
    {
        #region

        public CostingController()
        {
        }

        public CostingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Updation Read Methods

        public int InsertCosting(Costing objCosting, int Role)
        {
            int costingId = this.CostingDataProviderInstance.InsertCosting(objCosting, Role);



            // Update By Ravi kumar for new work flow on 22/1/2016
            try
            {

                if (objCosting.IsIkandiClient == 1)
                {
                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                    if (tasks.Count > 0)
                    {
                        if (tasks[0].StatusModeID == (int)TaskMode.COSTING_BIPL)
                        {
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            tasks[0] = this.WorkflowControllerInstance.CreateTask(TaskMode.PRICE_QUOTED_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                            if (objCosting.PriceQuoted > 0)
                            {
                                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                                this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                            }
                        }
                        else if (tasks[0].StatusModeID == (int)TaskMode.PRICE_QUOTED_BIPL && objCosting.PriceQuoted > 0)
                        {
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                        }
                        else if (tasks[0].StatusModeID == (int)TaskMode.COSTED_IKANDI)
                        {
                            this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            this.WorkflowControllerInstance.CreateTask(TaskMode.BIPL_AGREEMENT_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                        }
                    }
                    else if (Role==1 && objCosting.ParentCostingID >0)
                    {
                        tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);
                        if (tasks.Count == 0)
                            this.WorkflowControllerInstance.CreateTask(TaskMode.BIPL_AGREEMENT_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    }
                }
                else
                {
                    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                    if (objCosting.PriceQuoted > 0)
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID);

                    }
                }

                #region commented
                // Update workflow
                //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                //if (objCosting.IsIkandiClient == 1)
                //{
                //    if (tasks.Count > 0)
                //    { 
                //        if (tasks[0].StatusModeID == (int)StatusMode.COSTEDBIPL)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            tasks[0]=this.WorkflowControllerInstance.CreateTask(StatusMode.PRICEQUOTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //            if(objCosting.PriceQuoted > 0)
                //            {
                //                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //                this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDIKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //            }
                //        }
                //        else if (tasks[0].StatusModeID == (int)StatusMode.PRICEQUOTEDBIPL && objCosting.PriceQuoted > 0)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDIKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //        }
                //        else if (tasks[0].StatusModeID == (int)StatusMode.COSTEDIKANDI)
                //        {
                //            this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            this.WorkflowControllerInstance.CreateTask(StatusMode.PENDINGBIPLAGREEMENT, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //        }
                //    }
                //    else if (Role == 1 && objCosting.ParentCostingID > 0)
                //    {
                //        tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                //        if (tasks.Count == 0)
                //            this.WorkflowControllerInstance.CreateTask(StatusMode.PENDINGBIPLAGREEMENT, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //    }
                //}
                //else
                //{
                //    if (tasks.Count > 0)
                //    {
                //        //this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        if (tasks[0].StatusModeID == (int)StatusMode.COSTEDBIPL)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            tasks[0] = this.WorkflowControllerInstance.CreateTask(StatusMode.PRICEQUOTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //            if (objCosting.PriceQuoted > 0)
                //            {
                //                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            }
                //        }
                //        else if (tasks[0].StatusModeID == (int)StatusMode.PRICEQUOTEDBIPL && objCosting.PriceQuoted > 0)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        }
                //    }
                //}
             #endregion
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            
            return costingId;
        }

        public bool UpdateCosting(Costing objCosting, int Role)
        {
            bool success = this.CostingDataProviderInstance.UpdateCosting(objCosting, Role);        

            try
            {
                // Update By Ravi kumar for new work flow on 22/1/2016

                if (objCosting.VerifyCosting==1)
                    this.WorkflowControllerInstance.CompleTaskVerifyCosting(this.LoggedInUser.UserData.UserID, objCosting.StyleID);
                if (objCosting.IsIkandiClient == 1)
                {
                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);
                    //this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);

                    //if (objCosting.PriceQuoted > 0)
                    //{
                    //    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID);

                    //    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTED_IKANDI, this.LoggedInUser.UserData.UserID);
                    //    this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);
                    //}
                    if (tasks.Count > 0)
                    {
                        if (tasks[0].StatusModeID == (int)TaskMode.COSTED_IKANDI )
                        {
                            // TODO: Check the tasks collection to verify
                            // Complete the costing by iKandi 
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);

                        }
                        else if (tasks[0].StatusModeID == (int)TaskMode.COSTING_BIPL )
                        {
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            tasks[0] = this.WorkflowControllerInstance.CreateTask(TaskMode.PRICE_QUOTED_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                            if (objCosting.PriceQuoted > 0)
                            {
                                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                                this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                            }
                        }
                        else if (tasks[0].StatusModeID == (int)TaskMode.PRICE_QUOTED_BIPL && objCosting.PriceQuoted > 0)
                        {
                            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                            this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                        }
                }
                }
                else
                {
                    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                    if (objCosting.PriceQuoted > 0)
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID);

                    }
                }

                //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                //if (objCosting.IsIkandiClient == 1 && tasks.Count > 0)
                //{
                //    if (tasks[0].StatusModeID == (int)StatusMode.COSTEDIKANDI)
                //    {
                //        // TODO: Check the tasks collection to verify
                //        // Complete the costing by iKandi 
                //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);

                //    }
                //    else if (tasks[0].StatusModeID == (int)StatusMode.COSTEDBIPL)
                //    {
                //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        tasks[0] = this.WorkflowControllerInstance.CreateTask(StatusMode.PRICEQUOTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //        if (objCosting.PriceQuoted > 0)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDIKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //        }
                //    }
                //    else if (tasks[0].StatusModeID == (int)StatusMode.PRICEQUOTEDBIPL && objCosting.PriceQuoted > 0)
                //    {
                //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDIKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //    }
                //}
                //else
                //{
                //    if (tasks.Count > 0)
                //    {
                //        //this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //        if (tasks[0].StatusModeID == (int)StatusMode.COSTEDBIPL)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            tasks[0] = this.WorkflowControllerInstance.CreateTask(StatusMode.PRICEQUOTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                //            if (objCosting.PriceQuoted > 0)
                //            {
                //                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //            }
                //        }
                //        else if (tasks[0].StatusModeID == (int)StatusMode.PRICEQUOTEDBIPL && objCosting.PriceQuoted > 0)
                //        {
                //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
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

            return success;
        }

        public DataTable GetBIPLOrderPriceDetails(int StyleId)
        {
          return this.CostingDataProviderInstance.GetBIPLOrderPriceDetails(StyleId);
        }
        public DataTable GetIkandiOrderPriceDetails(int StyleId)
        {
            return this.CostingDataProviderInstance.GetIkandiOrderPriceDetails(StyleId);
        }

        public CostingCollection GetCosting(int costingId,int UserID)
        {
            return this.CostingDataProviderInstance.GetCosting(costingId,UserID);
        }
        // edit by surendra technical module
        public bool bCheckOB(int styleid)
        {
            return CostingDataProviderInstance.bCheckOB(styleid);
        }
        // end

        public DataTable GetCurrencyBAL()
        {
            return this.CostingDataProviderInstance.GetCurrencyDAL();
        }

        public CostingCollection GetCostingByStyleNumber(string styleNumber, byte isGetMultiple, int SingleVersion)
        {
            return this.CostingDataProviderInstance.GetCostingByStyleNumber(styleNumber, isGetMultiple, SingleVersion);
        }


        public int UpdateFabQuality(string[] tradeName, string[] count, double[] gsm)
        {
            return this.CostingDataProviderInstance.UpdateFabQuality(tradeName, count, gsm);
        }


        public int GetParentCostingID(int ChildCostingID)
        {
            int cID = this.CostingDataProviderInstance.GetParentCostingID(ChildCostingID);

            return (cID == -1) ? ChildCostingID : cID;
        }
        // edit by surendra support issue
        public int GetClientID(int ChildCostingID)
        {
            int ClientID = this.CostingDataProviderInstance.GetClientID(ChildCostingID);

            return ClientID;
        }
        public int GetDeptID(int ChildCostingID)
        {
            int DeptID = this.CostingDataProviderInstance.GetDeptID(ChildCostingID);
            return DeptID;
            // return (cID == -1) ? ChildCostingID : cID;
        }
        // END 

        #endregion

        #region Misc Methods
        public string UpdateClientCostingValues_ByClient_ApplicableCoffinBox(int ClientId, int DeptId, int HeaderNo, string Values)
        {
            return this.CostingDataProviderInstance.UpdateClientCostingValues_ByClient_ApplicableCoffinBox(ClientId, DeptId, HeaderNo, Values);
        }
        public bool AgreeForIKandiCostingData(int costingId, int parentCostingId, int parentStyleId)
        {
            bool success = this.CostingDataProviderInstance.AgreeForIKandiCostingData(costingId, parentCostingId);

            try
            {
                // System.Diagnostics.Debugger.Break();

                // Update workflow
                //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(parentStyleId, -1, -1);
                //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                //if (tasks.Count > 0 && tasks[0].StatusModeID == (int)StatusMode.PENDINGBIPLAGREEMENT)
                //{
                //    // TODO: Check the tasks collection to verify
                //    // Complete the costing by iKandi 
                //    this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                //}

                // Add By Ravi kumar for new work flow on 22/1/2016
                this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(parentStyleId, TaskMode.BIPL_AGREEMENT_BIPL, this.LoggedInUser.UserData.UserID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }

            return success;
        }

        public bool DisagreeForIKandiCostingData(int costingId, int parentCostingId, int parentStyleId)
        {
            bool success = this.CostingDataProviderInstance.DisagreeForIKandiCostingData(costingId, parentCostingId);

            try
            {
                // System.Diagnostics.Debugger.Break();

                // Update workflow
                WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(parentStyleId, -1, -1);
                List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                if (tasks.Count > 0 && tasks[0].StatusModeID == (int)TaskMode.BIPL_AGREEMENT_BIPL)
                {
                    // TODO: Check the tasks collection to verify
                    // Complete the costing by iKandi 
                    this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);

                    // TODO: Hardcoded the day
                    this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));

                }
                // Add By Ravi kumar for new work flow
               // this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(parentStyleId, TaskMode.BIPL_AGREEMENT_BIPL, this.LoggedInUser.UserData.UserID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }

            return success;
        }

        public int CheckIfIKandiData(int costingId)
        {
            return this.CostingDataProviderInstance.CheckIfIKandiData(costingId);
        }

        public List<string> GetAllZipDetails()
        {
            return this.CostingDataProviderInstance.GetAllZipDetails();
        }

        public DataTable GetCostedStyles(DateTime CostingDate)
        {
            return this.CostingDataProviderInstance.GetCostedStyles(CostingDate);
        }

        public bool DeleteStyleAndCostingSheet(int styleId, int costingId)
        {
            return this.CostingDataProviderInstance.DeleteStyleAndCostingSheet(styleId, costingId);
        }
        public bool bCheck_Update_Price_Visibilty(int costingId)
        {
            return this.CostingDataProviderInstance.bCheck_Update_Price_Visibilty(costingId);
        }
        public string UpdateBIPLPriceOnOrders(int CostingID)
        {
            return this.CostingDataProviderInstance.UpdateBIPLPriceOnOrders(CostingID);
        }
        public string GetPairedCosting(int CostingID)
        {
            return this.CostingDataProviderInstance.GetPairedCosting(CostingID);
        }

        public string UpdateiKandiPriceOnOrders(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstance.UpdateiKandiPriceOnOrders(CostingID, isAF, isAH, isSF, isSH, isFOB);
        }

        #endregion

        #region ExpectedQuantity on Costing Sheet
        //manisha 13th may 2011
        public string GetPriceForGarmentType(string GarmentType, int ExpectedQty, string DdlType)
        {
            return this.CostingDataProviderInstance.GetPriceForGarmentType(GarmentType, ExpectedQty, DdlType);
        }

        /// <summary>
        /// Added by yaten on 8 May
        /// </summary>
        /// <param name="GarmentType"></param>
        /// <param name="ExpectedQty"></param>
        /// <param name="DdlType"></param>
        /// <returns></returns>
        public string GetPriceForGarmentTypeSAM(int PutSAM, int ExpectedQty)
        {
            return this.CostingDataProviderInstance.GetPriceForGarmentTypeSAM(PutSAM, ExpectedQty);
        }

        public string CostingExpectedQtyBAL(int Qty)
        {
            return this.CostingDataProviderInstance.CostingExpectedQtyDAL(Qty);
        }


        public DataTable GetGarmentTypeOption(string makingType)
        {
            DataTable dtSplit = this.CostingDataProviderInstance.GetGarmentTypeOption(makingType);
            return dtSplit;
        }
        public string GetGarmentNameOption(string garmentType)
        {
            string garmentName = this.CostingDataProviderInstance.GetGarmentNameOption(garmentType);
            return garmentName;
        }

        public DataSet GetExpectedQtyRangewiseBAL()
        {
         return this.CostingDataProviderInstance.GetExpectedQtyRangewiseDAL();
            
        }


        public string GetDefaultExpectedQty()
        {
            return this.CostingDataProviderInstance.GetDefaultExpectedQty();
        }
        public int GetCurrencyConversion(int currencyID, string StyleNumber)
        {
            return this.CostingDataProviderInstance.GetCurrencyConversion(currencyID, StyleNumber);
        }


        public string GetCurrencySymbolBAL(string currencyID)
        {
            return this.CostingDataProviderInstance.GetCurrencySymbolDAL(currencyID);
        }

        public string UpdateiKandiPriceOnOrders_Old(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstance.UpdateiKandiPriceOnOrders_Old(CostingID, isAF, isAH, isSF, isSH, isFOB);
        }
        public string UpdateiKandiPriceOnOrders(string OrderIds, int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstance.UpdateiKandiPriceOnOrders(OrderIds, CostingID, isAF, isAH, isSF, isSH, isFOB);
        }
        #endregion
        // end

        
        public DataTable GetChargeValue()
        {
            return this.CostingDataProviderInstance.GetChargeValueDAL();
        }

        public string [] GetCMT_Value(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity)
        {
            return this.CostingDataProviderInstance.GetCMT_Value(SAM, OB_WS, Achivement, ClientId, DeptId, StyleId, Quantity, this.LoggedInUser.UserData.UserID);
        }

        //public string[] GetClient_Costing_ByClient(int ClientId, int DeptId)
        //{
        //    return this.CostingDataProviderInstance.GetClient_Costing_ByClient(ClientId, DeptId);
        //}

        public int SaveClientCostingDefault(int ClientID, int DeptId, double commission, int Conversion, double coffinbox, double Hangerloops, double lblTags, double OverHeadcost, double ProfitMargin, double Test, double Hangers, double DesignCommision, int Achievement, double ExpectedQuantity, double frtUptoport)
        {
            return this.CostingDataProviderInstance.SaveClientCostingDefault(ClientID, DeptId, commission, Conversion, coffinbox, Hangerloops, lblTags, OverHeadcost, ProfitMargin, Test, Hangers, DesignCommision, Achievement, ExpectedQuantity,frtUptoport, 1 );
        }

        public string UpdateClientCostingValues_ByClient(int ClientId, int DeptId, int HeaderNo, double Values)
        {
            return this.CostingDataProviderInstance.UpdateClientCostingValues_ByClient( ClientId,  DeptId,  HeaderNo,  Values);
        }

        public string UpdateExpectedByClient(int ClientID, int DeptId, int HeaderNo, double ExpectedQuantity)
        {
            return this.CostingDataProviderInstance.UpdateClientCostingValues_ByClient(ClientID, DeptId, HeaderNo, ExpectedQuantity);
        }

        public List<Costing> GetClientCostingBy(int ClientId, int DeptId)
        {
            return this.CostingDataProviderInstance.GetClientCostingBy(ClientId, DeptId);
        }
        public List<Costing> GetWastage(int ExpectedQty)
        {
            return this.CostingDataProviderInstance.GetWastage(ExpectedQty);
        }

        public int Check_UpdateBiplPrice_ShowHide(int CostingID)
        {
            return this.CostingDataProviderInstance.Check_UpdateBiplPrice_ShowHide(CostingID);
        }

        public DataTable Get_OrderDetailBy_StyleId(int StyleId)
        {
            return this.CostingDataProviderInstance.Get_OrderDetailBy_StyleId(StyleId);
        }

        public int UpdateBIPLPrice(int OrderId, float AgreedPrice)
        {
          return this.CostingDataProviderInstance.UpdateBIPLPrice(OrderId, AgreedPrice);
        }
        public int UpdateIkandiPrice(int OrderId, float AgreedPrice)
        {
            return this.CostingDataProviderInstance.UpdateIkandiPrice(OrderId, AgreedPrice);
        }
        public int UpdateFabric_Color_Print(int OrderId)
        {
            return this.CostingDataProviderInstance.UpdateFabric_Color_Print(OrderId);
        }
        
        public List<Costing> GetExpWastageQty(int ClientId, int DeptId)
        {
            return this.CostingDataProviderInstance.GetExpWastageQty(ClientId, DeptId);
        }
        public List<Costing> GetStyleNumber_From_Order(string MOid)
        {
            return this.CostingDataProviderInstance.GetStyleNumber_From_Order(MOid);
        }
        //add code by bhrarat on 1-27-2020
        public string SaveLikeCountProduct(int ProStyleId, int ProCount)
        {
            return this.CostingDataProviderInstance.SaveLikeCountProduct(ProStyleId, ProCount);
        }
        //add code by bhrarat on 1-27-2020
        public string CheckCancelPO(int OrderDetailId)
        {
            return this.CostingDataProviderInstance.CheckCancelPO(OrderDetailId);
        }
        public string SaveLikeCountProductDetails(int ProDetailStyleId, int ProCountDetail)
        {
            return this.CostingDataProviderInstance.SaveLikeCountProductDetails(ProDetailStyleId, ProCountDetail);
        }

        
    }
}
