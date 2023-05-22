using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class CostingContollerNew : BaseController
    {
        #region

        public CostingContollerNew()
        {
        }

        public CostingContollerNew(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Updation Read Methods

        public void OpenCosing(int styleid, int IsCostingOpen, int Userid)
        {
            CostingDataProviderInstanceNew.OpenCosing(styleid, IsCostingOpen, Userid);
        }
        //int costingId = this.CostingDataProviderInstanceNew.InsertCosting_New(objCosting, Role);

        public int InsertCosting_New(Costing objCosting, int Role, string Type)
        {
            int costingId = this.CostingDataProviderInstanceNew.InsertCosting_New(objCosting, Role);



            // Update By Ravi kumar for new work flow on 22/1/2016
            try
            {

                if (objCosting.IsIkandiClient == 1)
                {
                    if (Type == "BIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                        if (objCosting.PriceQuoted > 0)
                        {
                            this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);
                        }
                    }
                    else if (Type == "OpenCostingBIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 2);
                    }
                    else if (Type == "CloseCostingBIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.COSTED_IKANDI, this.LoggedInUser.UserData.UserID, 2);
                    }
                    else if (Type == "IKANDI")
                    {
                        if (Role == 1)
                        {
                            if (objCosting.PriceQuoted > 0)
                            {
                                this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);
                            }
                            if (objCosting.isDiffernt == false)
                            {
                                this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.COSTED_IKANDI, this.LoggedInUser.UserData.UserID, 2);
                            }
                            else
                            {
                                this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 2);
                            }
                        }
                    }
                    //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                    //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //if (tasks.Count > 0)
                    //{
                    //    if (tasks[0].StatusModeID == (int)TaskMode.COSTING_BIPL)
                    //    {
                    //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //        tasks[0] = this.WorkflowControllerInstance.CreateTask(TaskMode.PRICE_QUOTED_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //        if (objCosting.PriceQuoted > 0)
                    //        {
                    //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //            this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //        }
                    //    }
                    //    else if (tasks[0].StatusModeID == (int)TaskMode.PRICE_QUOTED_BIPL && objCosting.PriceQuoted > 0)
                    //    {
                    //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //        this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //    }
                    //    else if (tasks[0].StatusModeID == (int)TaskMode.COSTED_IKANDI)
                    //    {
                    //        this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);
                    //        this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //        this.WorkflowControllerInstance.CreateTask(TaskMode.BIPL_AGREEMENT_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //    }
                    //}
                    //else if (Role==1 && objCosting.ParentCostingID >0)
                    //{
                    //    tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);
                    //    if (tasks.Count == 0)
                    //        this.WorkflowControllerInstance.CreateTask(TaskMode.BIPL_AGREEMENT_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //}
                }
                else
                {
                    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                    if (objCosting.PriceQuoted > 0)
                    {
                        //this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID);
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);
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

        public bool UpdateCosting_New(Costing objCosting, int Role, string Type)
        {
            bool success = this.CostingDataProviderInstanceNew.UpdateCosting_New(objCosting, Role);

            bool removeAgreement = this.CostingDataProviderInstanceNew.Remove_Costing_Agreement_from_IKandi_User_When_NoChange_Exists(objCosting.StyleID, this.LoggedInUser.UserData.UserID);

            try
            {
                // Update By Ravi kumar for new work flow on 22/1/2016


                if (objCosting.IsIkandiClient == 1)
                {
                    if (Type == "BIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                        if (objCosting.PriceQuoted > 0)
                        {
                            this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);
                        }
                    }
                    else if (Type == "OpenCostingBIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 2);
                    }
                    else if (Type == "CloseCostingBIPL")
                    {
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 2);
                    }
                    else if (Type == "IKANDI")
                    {
                        if (Role == 1)
                        {
                            if (objCosting.PriceQuoted > 0)
                            {
                                this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);
                            }
                            int Count = this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 3);
                            //if (objCosting.isDiffernt == false && Count != 2)
                            //{
                            //  //this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.COSTED_IKANDI, this.LoggedInUser.UserData.UserID, 2);
                            //}
                            //else
                            //{
                            //  //this.WorkflowControllerInstance.UpdateWorkflowInstanceOpen_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 2);
                            //}
                        }
                    }
                    //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(objCosting.StyleID, -1, -1);
                    //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //    if (tasks.Count > 0)
                    //    {
                    //        if (tasks[0].StatusModeID == (int)TaskMode.COSTED_IKANDI )
                    //        {
                    //            // TODO: Check the tasks collection to verify
                    //            // Complete the costing by iKandi 
                    //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //            this.StyleControllerInstance.CostingEnquiryUpdateStyle("", objCosting.StyleID, 2);

                    //        }
                    //        else if (tasks[0].StatusModeID == (int)TaskMode.COSTING_BIPL )
                    //        {
                    //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //            tasks[0] = this.WorkflowControllerInstance.CreateTask(TaskMode.PRICE_QUOTED_BIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //            if (objCosting.PriceQuoted > 0)
                    //            {
                    //                this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //                this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //            }
                    //        }
                    //        else if (tasks[0].StatusModeID == (int)TaskMode.PRICE_QUOTED_BIPL && objCosting.PriceQuoted > 0)
                    //        {
                    //            this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);
                    //            this.WorkflowControllerInstance.CreateTask(TaskMode.COSTED_IKANDI, instance.WorkflowInstanceID, DateTime.Today.AddDays(1));
                    //        }
                    //}
                }
                else
                {
                    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.COSTING_BIPL, this.LoggedInUser.UserData.UserID);
                    if (objCosting.PriceQuoted > 0)
                    {
                        //this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID);
                        this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(objCosting.StyleID, TaskMode.PRICE_QUOTED_BIPL, this.LoggedInUser.UserData.UserID, 1);

                    }
                }

                #region Old Workflow
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
                #endregion
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace); 
            }

            return success;
        }

        public DataTable GetBIPLOrderPriceDetails_New(int StyleId)
        {
            return this.CostingDataProviderInstanceNew.GetBIPLOrderPriceDetails_New(StyleId);
        }

        public CostingCollection GetCosting_New(int costingId)
        {
            return this.CostingDataProviderInstanceNew.GetCosting_New(costingId);
        }
        // edit by surendra technical module
        public bool bCheckOB_New(int styleid)
        {
            return CostingDataProviderInstanceNew.bCheckOB_New(styleid);
        }
        // end

        public DataTable GetCurrencyBAL_New()
        {
            return this.CostingDataProviderInstanceNew.GetCurrencyDAL_New();
        }
        public DataTable GetYello_Remarks(int StyleId, int ChildCostingID, string Type)
        {
            return this.CostingDataProviderInstanceNew.GetYello_Remarks(StyleId, ChildCostingID, Type);
        }

        public CostingCollection GetCostingByStyleNumber_New(string styleNumber, byte isGetMultiple, int SingleVersion)
        {
            return this.CostingDataProviderInstanceNew.GetCostingByStyleNumber_New(styleNumber, isGetMultiple, SingleVersion);
        }


        public int UpdateFabQuality_New(string[] tradeName, string[] count, double[] gsm)
        {
            return this.CostingDataProviderInstanceNew.UpdateFabQuality_New(tradeName, count, gsm);
        }


        public int GetParentCostingID_New(int ChildCostingID)
        {
            int cID = this.CostingDataProviderInstanceNew.GetParentCostingID_New(ChildCostingID);

            return (cID == -1) ? ChildCostingID : cID;
        }
        // edit by surendra support issue
        public int GetClientID_New(int ChildCostingID)
        {
            int ClientID = this.CostingDataProviderInstanceNew.GetClientID_New(ChildCostingID);

            return ClientID;
        }
        public int GetDeptID_New(int ChildCostingID)
        {
            int DeptID = this.CostingDataProviderInstanceNew.GetDeptID_New(ChildCostingID);
            return DeptID;
            // return (cID == -1) ? ChildCostingID : cID;
        }
        // END 

        #endregion

        #region Misc Methods

        public bool AgreeForIKandiCostingData_New(int costingId, int parentCostingId, int parentStyleId, Costing objCosting)
        {
            bool success = this.CostingDataProviderInstanceNew.AgreeForIKandiCostingData_New(costingId, parentCostingId, objCosting);

            try
            {
                // Add By Surendra2 for new work flow on 13/12/2018
                this.WorkflowControllerInstance.UpdateWorkflowInstanceClosing_PreOrder(parentStyleId, TaskMode.BIPL_AGREEMENT_BIPL, this.LoggedInUser.UserData.UserID, 2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }

            return success;
        }

        public bool DisagreeForIKandiCostingData_New(int costingId, int parentCostingId, int parentStyleId, Costing objCosting)
        {
            bool success = this.CostingDataProviderInstanceNew.DisagreeForIKandiCostingData_New(costingId, parentCostingId, objCosting);

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

        // create by surendra2 on 17-12-2018.
        public double Get_LP_New(int StyleId)
        {
            return this.CostingDataProviderInstanceNew.Get_LP_New(StyleId);
        }

        public int CheckIfIKandiData_New(int costingId)
        {
            return this.CostingDataProviderInstanceNew.CheckIfIKandiData_New(costingId);
        }

        public List<string> GetAllZipDetails_New()
        {
            return this.CostingDataProviderInstanceNew.GetAllZipDetails_New();
        }

        public DataTable GetCostedStyles_New(DateTime CostingDate)
        {
            return this.CostingDataProviderInstanceNew.GetCostedStyles_New(CostingDate);
        }

        public bool DeleteStyleAndCostingSheet_New(int styleId, int costingId)
        {
            return this.CostingDataProviderInstanceNew.DeleteStyleAndCostingSheet_New(styleId, costingId);
        }
        public bool bCheck_Update_Price_Visibilty_New(int costingId)
        {
            return this.CostingDataProviderInstanceNew.bCheck_Update_Price_Visibilty_New(costingId);
        }

        public string UpdateBIPLPriceOnOrders_New(int CostingID)
        {
            return this.CostingDataProviderInstanceNew.UpdateBIPLPriceOnOrders_New(CostingID);
        }

        public string UpdateiKandiPriceOnOrders_New(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstanceNew.UpdateiKandiPriceOnOrders_New(CostingID, isAF, isAH, isSF, isSH, isFOB);
        }

        #endregion

        #region ExpectedQuantity on Costing Sheet
        //manisha 13th may 2011
        public string GetPriceForGarmentType_New(string GarmentType, int ExpectedQty, string DdlType)
        {
            return this.CostingDataProviderInstanceNew.GetPriceForGarmentType_New(GarmentType, ExpectedQty, DdlType);
        }

        /// <summary>
        /// Added by yaten on 8 May
        /// </summary>
        /// <param name="GarmentType"></param>
        /// <param name="ExpectedQty"></param>
        /// <param name="DdlType"></param>
        /// <returns></returns>
        public string GetPriceForGarmentTypeSAM_New(int PutSAM, int ExpectedQty)
        {
            return this.CostingDataProviderInstanceNew.GetPriceForGarmentTypeSAM_New(PutSAM, ExpectedQty);
        }

        public string CostingExpectedQtyBAL_New(int Qty)
        {
            return this.CostingDataProviderInstanceNew.CostingExpectedQtyDAL_New(Qty);
        }


        public DataTable GetGarmentTypeOption_New(string makingType)
        {
            DataTable dtSplit = this.CostingDataProviderInstanceNew.GetGarmentTypeOption_New(makingType);
            return dtSplit;
        }
        public string GetGarmentNameOption_New(string garmentType)
        {
            string garmentName = this.CostingDataProviderInstanceNew.GetGarmentNameOption_New(garmentType);
            return garmentName;
        }

        public DataSet GetExpectedQtyRangewiseBAL_New()
        {
            return this.CostingDataProviderInstanceNew.GetExpectedQtyRangewiseDAL_New();

        }


        public string GetDefaultExpectedQty_New()
        {
            return this.CostingDataProviderInstanceNew.GetDefaultExpectedQty_New();
        }
        public int GetCurrencyConversion_New(int currencyID)
        {
            return this.CostingDataProviderInstanceNew.GetCurrencyConversion_New(currencyID);
        }


        public string GetCurrencySymbolBAL_New(string currencyID)
        {
            return this.CostingDataProviderInstanceNew.GetCurrencySymbolDAL_New(currencyID);
        }

        public string UpdateiKandiPriceOnOrders_Old_New(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstanceNew.UpdateiKandiPriceOnOrders_Old_New(CostingID, isAF, isAH, isSF, isSH, isFOB);
        }
        public string UpdateiKandiPriceOnOrders_New(string OrderIds, int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            return this.CostingDataProviderInstanceNew.UpdateiKandiPriceOnOrders_New(OrderIds, CostingID, isAF, isAH, isSF, isSH, isFOB);
        }
        #endregion
        // end


        public DataTable GetChargeValue_New()
        {
            return this.CostingDataProviderInstanceNew.GetChargeValueDAL_New();
        }

        public string[] GetCMT_Value_New(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity)
        {
            return this.CostingDataProviderInstanceNew.GetCMT_Value_New(SAM, OB_WS, Achivement, ClientId, DeptId, StyleId, Quantity, 2);
        }

        //public string[] GetClient_Costing_ByClient(int ClientId, int DeptId)
        //{
        //    return this.CostingDataProviderInstanceNew.GetClient_Costing_ByClient(ClientId, DeptId);
        //}

        public int SaveClientCostingDefault_New(int ClientID, int DeptId, double commission, int Conversion, double coffinbox, double Hangerloops, double lblTags, double OverHeadcost, double ProfitMargin, double Test, double Hangers, double DesignCommision, int Achievement, double ExpectedQuantity, double frtUptoport)
        {
            return this.CostingDataProviderInstanceNew.SaveClientCostingDefault_New(ClientID, DeptId, commission, Conversion, coffinbox, Hangerloops, lblTags, OverHeadcost, ProfitMargin, Test, Hangers, DesignCommision, Achievement, ExpectedQuantity, frtUptoport, 1);
        }

        public string UpdateClientCostingValues_ByClient_New(int ClientId, int DeptId, int HeaderNo, double Values)
        {
            return this.CostingDataProviderInstanceNew.UpdateClientCostingValues_ByClient_New(ClientId, DeptId, HeaderNo, Values);
        }

        public string UpdateExpectedByClient_New(int ClientID, int DeptId, int HeaderNo, double ExpectedQuantity)
        {
            return this.CostingDataProviderInstanceNew.UpdateClientCostingValues_ByClient_New(ClientID, DeptId, HeaderNo, ExpectedQuantity);
        }
        //Add By Prabhaker
        public string UpdateClientCostingMode_ByClient_New(int ClientId, int DeptId, string HeaderName, int Values)
        {
            return this.CostingDataProviderInstanceNew.UpdateClientCostingMode_ByClient_New(ClientId, DeptId, HeaderName, Values);
        }
        //End Of Code


        public DataSet Get_LP_Details_New(int StyleId)
        {
            return this.CostingDataProviderInstanceNew.Get_LP_Details_New(StyleId);
        }

        public List<Costing> GetClientCostingBy_New(int ClientId, int DeptId, string StyleNumber,int ExpectedQty)
        {
            return this.CostingDataProviderInstanceNew.GetClientCostingBy_New(ClientId, DeptId, StyleNumber, ExpectedQty);
        }
        public DataSet GetRegisterFabric_Details(string TradeName)
        {
            return this.CostingDataProviderInstanceNew.GetRegisterFabric_Details(TradeName);
        }
        public DataSet GetRegisterAccessory_Details(string TradeName)
        {
            return this.CostingDataProviderInstanceNew.GetRegisterAccessory_Details(TradeName);
        }
        public DataSet GetRegisterProcess_Details(string TradeName)
        {
            return this.CostingDataProviderInstanceNew.GetRegisterProcess_Details(TradeName);
        }
        public DataSet GetRegisterPrint_Details(string TradeName)
        {
            return this.CostingDataProviderInstanceNew.GetRegisterPrint_Details(TradeName);
        }
        public DataTable GetClientDeptName(int id, string flag)
        {
            return this.CostingDataProviderInstanceNew.GetClientDeptName(id, flag);
        }

        public DataSet GetBiplHistory_Details(string CostingId, string type)
        {
            return this.CostingDataProviderInstanceNew.GetBiplHistory_Details_New(CostingId, type);
        }
        public DataSet GetIkandiHistory_Details(string CostingId, string type)
        {
            return this.CostingDataProviderInstanceNew.GetIkandiHistory_Details_New(CostingId, type);
        }
        public int Check_UpdateBiplPrice_ShowHide_New(int CostingID)
        {
            return this.CostingDataProviderInstanceNew.Check_UpdateBiplPrice_ShowHide_New(CostingID);
        }

        public DataTable Get_OrderDetailBy_StyleId_New(int StyleId)
        {
            return this.CostingDataProviderInstanceNew.Get_OrderDetailBy_StyleId_New(StyleId);
        }

        public int UpdateBIPLPrice_New(int OrderId, float AgreedPrice)
        {
            return this.CostingDataProviderInstanceNew.UpdateBIPLPrice_New(OrderId, AgreedPrice);
        }

        #region Gajendra Costing

        public FabricCosting GetRateBySupplier_New(int FabType, string Trade, string Suplier)
        {
            return this.CostingDataProviderInstanceNew.GetRateBySupplier_New(FabType, Trade, Suplier);
        }

        public DataTable GetCostingDefaultBy_Client_Dept_New(int ClientId, int DeptId, int StyleID)
        {
            return this.CostingDataProviderInstanceNew.GetCostingDefaultBy_Client_Dept_New(ClientId, DeptId, StyleID);
        }
        public List<Accessories> GetCostingUnitQtyBy_Client_Dept_New(int ClientId, int DeptId)
        {
            return this.CostingDataProviderInstanceNew.GetCostingUnitQtyBy_Client_Dept_New(ClientId, DeptId);
        }
        public Accessories GetAccessoryQualityDataByTradeName_New(string TradeName, string Suplier)
        {
            return this.CostingDataProviderInstanceNew.GetAccessoryQualityDataByTradeName_New(TradeName, Suplier);
        }

        public Processes GetProcessDataByProcessName_New(string Name, string ExpectedQty)
        {
            return this.CostingDataProviderInstanceNew.GetProcessDataByProcessName_New(Name, ExpectedQty);
        }

        //public ProcessesWCF GetProcessDataByProcessNameWCF_New(string Name, string ExpectedQty)
        //{
        //    return this.CostingDataProviderInstanceNew.GetProcessDataByProcessNameWCF_New(Name, ExpectedQty);
        //}
        #endregion

        //abhishek 
        public List<Costing> GetCostingVariance(int id)
        {
            return this.CostingDataProviderInstanceNew.GetCostingVariance(id);
        }
        public DataTable GetCostingVariance_new(int id)
        {
            return this.CostingDataProviderInstanceNew.GetCostingVariance_new(id);
        }
        //Add By Prabhaker 16-jul-18
        public DataSet GetModeCost(int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.GetModeCost(CreatedBy, flag);
        }

        public int InsertModeCost(decimal ModeCost, int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.InsertModeCost(ModeCost, CreatedBy, flag);
        }


        public int UpdateModeCost(int id, decimal ModeCost, int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.UpdateModeCost(id, ModeCost, CreatedBy, flag);
        }

        public DataSet GetProcessCost(int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.GetProcessCost(CreatedBy, flag);
        }

        public int InsertProcessCost(decimal ModeCost, int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.InsertProcessCost(ModeCost, CreatedBy, flag);
        }


        public int UpdateProcessCost(int id, decimal ModeCost, int CreatedBy, int flag)
        {
            return CostingDataProviderInstanceNew.UpdateProcessCost(id, ModeCost, CreatedBy, flag);
        }
        public List<Costing> GetIsCheckOrderConfirmed(string StyleNumber)
        {
            return this.CostingDataProviderInstanceNew.GetIsCheckOrderConfirmed(StyleNumber);
        }
        //End Of Code   

        public List<ValueAddition> GetValueAdditionDDL(int ValueAdditionId)
        {
            return this.CostingDataProviderInstanceNew.GetValueAdditionDDL(ValueAdditionId);
        }
        public ValueAddition Get_Wastage_Rate_For_Costing(int StyleId, int SequenceNo, int ValueAdditionId, int WastageId, int type)
        {
            return this.CostingDataProviderInstanceNew.Get_Wastage_Rate_For_Costing(StyleId, SequenceNo, ValueAdditionId, WastageId, type);
        }
        public bool bCheck_CMT_ReadOnly(int ClientID, int DepartmentID, int ParentDeptID)
        {
            return this.CostingDataProviderInstanceNew.bCheck_CMT_ReadOnly(ClientID, DepartmentID, ParentDeptID);
        }
        //added by raghvinder on 09-12-2020 start

        public bool IsCostingOldHistoryValid(int CostingId)
        {
            return CostingDataProviderInstanceNew.IsCostingOldHistoryValid(CostingId);
        }

        public List<OrderOldHistoryComments> Get_Costing_Old_History(int CostingId)
        {
            return CostingDataProviderInstanceNew.Get_Costing_Old_History(CostingId);
        }
        //added by raghvinder on 09-12-2020 end

        public List<Accessories> GetAccessoryBy_Client_Dept_Change(int ClientId, int DeptId, int CostingId)
        {
            return CostingDataProviderInstanceNew.GetAccessoryBy_Client_Dept_Change(ClientId, DeptId, CostingId);
        }

    }
}
