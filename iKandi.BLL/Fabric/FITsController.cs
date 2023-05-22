using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace iKandi.BLL
{
    public class FITsController : BaseController
    {
      private int Userid;

        public FITsController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        public FITsController(int Userid)
        {
          // TODO: Complete member initialization
          this.Userid = Userid;
        }

        public Fits GetFITsBasicInfo(string styleNumber, int departmentId)
        {
            return this.FITsDataProviderInstance.GetFITsBasicInfo(styleNumber, departmentId);
        }

        public Fits CreateFITs(Fits fits, Boolean IsIkandiUser)
        {
            return this.FITsDataProviderInstance.CreateFits(fits, IsIkandiUser);
        }
        public DataTable GetAllClient(string sStyleCodeVersion)
        {
            return this.FITsDataProviderInstance.GetAllClient(sStyleCodeVersion);
        }
        public DataTable GetAllDepartment(string sStyleCodeVersion, int iClientId)
        {
            return this.FITsDataProviderInstance.GetAllDepartment(sStyleCodeVersion, iClientId);
        }
        public DataTable GetStyleDetails(string sStyleCodeVersion)
        {
            return this.FITsDataProviderInstance.GetStyleDetails(sStyleCodeVersion);
        }
        public bool bCheckPreOrder(string sStyleCodeVersion)
        {
            return this.FITsDataProviderInstance.bCheckPreOrder(sStyleCodeVersion);
        }

        public Fits CreateNewFits(Fits fits)
        {
            return this.FITsDataProviderInstance.CreateNewFits(fits);
        }

        public Fits FitsFitsTrackOperations(Fits fits)
        {
            return this.FITsDataProviderInstance.FitsFitsTrackOperations(fits);
        }



        public Fits UpdateFITs(Fits fits, bool isIkandiUser)
        {
          Fits objFits = this.FITsDataProviderInstance.UpdateFits(fits, isIkandiUser);

          if (fits.IsStcApproved)
          {
            try
            {
              // TODO: Heaving call, avoid it
              List<OrderDetail> orderDetailCollection = this.OrderDataProviderInstance.GetOrder(fits.StyleCodeVersion, fits.Department.DeptID);

              if (orderDetailCollection.Count > 0)
              {
                foreach (OrderDetail orderDetail in orderDetailCollection)
                {
                    int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, TaskMode.Sealed_To_Cut, this.LoggedInUser.UserData.UserID);
                  //int iCutAvg = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, TaskMode.Sealed_To_Cut, this.LoggedInUser.UserData.UserID);

                  //// Edit by Nikhil
                    // Update workflow
                    //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, orderDetail.OrderDetailID);
                    //// code comment by sushil
                    //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //foreach (WorkflowInstanceDetail task in tasks)
                    //{
                    //  if (task.StatusModeID == (int)StatusMode.STCUNALLOCATED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.SEALING_FORM)
                    //  {
                    //    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                    //    if (this.WorkflowControllerInstance.IscheckInlinetask((int)StatusMode.ALLOCATED, instance.WorkflowInstanceID) == true)
                    //      this.WorkflowControllerInstance.OnlyAllocationUpdateTask(task, 1);
                    //    this.WorkflowControllerInstance.CreateTask(StatusMode.INLINECUT, instance.WorkflowInstanceID, orderDetail.STCUnallocated.AddDays(3));
                    //    // end
                    //  }

                    //}
                  ////
                }
              }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
          }

          return objFits;
        }

        public DataSet GetFITsCommentsUploaded(DateTime CommentUploadedDate,int bcheck)
        {
            return this.FITsDataProviderInstance.GetFITsCommentsUploaded(CommentUploadedDate, bcheck);
        }

        public Fits GetFitsByStyleCodeVersion(string StyleCodeVersion)
        {
            return this.FITsDataProviderInstance.GetFitsByStyleCodeVersion(StyleCodeVersion);
        }

        public bool GetIsValidateStyleCodeByStyleNumber(string StyleNumber)
        {
            return this.FITsDataProviderInstance.GetIsValidateStyleCodeByStyleNumber(StyleNumber);
        }

        public List<Fits> GetFitsDropdownRelatedInformation(string StyleCodeVersion, int DepartmentId)
        {
            return this.FITsDataProviderInstance.GetFitsDropdownRelatedInformation(StyleCodeVersion, DepartmentId);
        }

        //public bool UpdateSampleTrackingDate(Fits objFits)
        //{
        //    return this.FITsDataProviderInstance.UpdateSampleTrackingDate(objFits);
        //}

        //public Fits CreateFitsBeforeOrder(Fits fits)
        //{
        //    return this.FITsDataProviderInstance.CreateFitsBeforeOrder(fits);
        //}

        public Fits GetFITsBasicInfo_ForOrderProcess(string styleNumber, int departmentId, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, int Save)
        {
            return this.FITsDataProviderInstance.GetFITsBasicInfo_ForOrderProcess(styleNumber, departmentId, StyleId, CreateNew, NewRef, ReUse, ReUseStyleId, Save);
        }

        public DataSet GetFitsCodeVirsion(string styleNumber, int CreateNew)
        {
            return this.FITsDataProviderInstance.GetFitsCodeVirsion(styleNumber, CreateNew);
        }

        public Fits CreateFitsForOrderProcess(Fits fits, Boolean IsIkandiUser, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            Fits objFits = this.FITsDataProviderInstance.CreateFitsForOrderProcess(fits, IsIkandiUser, StyleId, CreateNew, NewRef, ReUse, ReUseStyleId);
            if (objFits.SpecsUploadDate != Convert.ToDateTime("1/1/0001"))
            {
                int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(StyleId, 0, TaskMode.Buying_Sample, this.LoggedInUser.UserData.UserID);
            }
            bool iSaveReUse = this.FITsDataProviderInstance.ReUse_Fits_fits_track(StyleId, ReUse);
            return objFits;
        }
        public Fits UpdateFits_ForOrderProcess(Fits fits, bool isIkandiUser, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, int UserId)
        {

          bool iCreateReUse = this.FITsDataProviderInstance.ReUse_Fits_FitsTrackInsert(fits, StyleId, ReUseStyleId, ReUse, NewRef, UserId);

          Fits objFits = this.FITsDataProviderInstance.UpdateFits_ForOrderProcess(fits, isIkandiUser, StyleId, CreateNew, NewRef, ReUse, ReUseStyleId);
          if (objFits.SpecsUploadDate != Convert.ToDateTime("1/1/0001"))
          {
              int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(StyleId, 0, TaskMode.Buying_Sample, this.LoggedInUser.UserData.UserID);
          }
          if (NewRef == 1)
          {
            bool iNewRef = this.FITsDataProviderInstance.NewRef_FitsTrackUpdate(fits, StyleId, ReUseStyleId, ReUse, NewRef);
          }

          bool iSaveReUse = this.FITsDataProviderInstance.ReUse_Fits_fits_track(StyleId, ReUse);


          if (fits.IsStcApproved)
          {
            try
            {
              // TODO: Heaving call, avoid it
              List<OrderDetail> orderDetailCollection = this.OrderDataProviderInstance.GetOrder(fits.StyleCodeVersion, fits.Department.DeptID);

              if (orderDetailCollection.Count > 0)
              {
                foreach (OrderDetail orderDetail in orderDetailCollection)
                {
                    int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, TaskMode.Sealed_To_Cut, this.LoggedInUser.UserData.UserID);
                  int CutAvg = this.WorkflowControllerInstance.CreateTaskForCutAvg(orderDetail.OrderID);
                  //// Edit by Nikhil
                    // Update workflow
                    //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, orderDetail.OrderDetailID);
                    //// code comment by sushil
                    //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //foreach (WorkflowInstanceDetail task in tasks)
                    //{
                    //    if (task.StatusModeID == (int)StatusMode.STCUNALLOCATED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.SEALING_FORM)
                    //    {
                    //        this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                    //        if (this.WorkflowControllerInstance.IscheckInlinetask((int)StatusMode.ALLOCATED, instance.WorkflowInstanceID) == true)
                    //            this.WorkflowControllerInstance.OnlyAllocationUpdateTask(task, 1);
                    //        this.WorkflowControllerInstance.CreateTask(StatusMode.INLINECUT, instance.WorkflowInstanceID, orderDetail.STCUnallocated.AddDays(3));
                    //        // end
                    //    }

                    //}
                  ////
                }
              }

              // Add By Ravi kumar on 28/07/2015 create task for final OB 
              //bool iCreateTaskForOB = WorkflowControllerInstance.CreateTask_For_OB_Risk("Fits", StyleId, -1, LoggedInUser.UserData.UserID);
            }
            catch (Exception ex)
            {
              this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
          }
          return objFits;
        }

        // ADD by Ravi kumar For ReUse Fits on 22/5/2015
        public bool ReUse_Fits_fits_track(int StyleId, int IsReUse)
        {
            return this.FITsDataProviderInstance.ReUse_Fits_fits_track(StyleId, IsReUse);
        }
        public int Update_Fits_Track_InPreOrder(int StyleId, int UserId)
        {
            return this.FITsDataProviderInstance.Update_Fits_Track_InPreOrder(StyleId, UserId);
        }

        // Add By Ravi kumar For Reschedule Pattern on 20-Apr-2017
        public List<SamplePattern> GetReschedule_StyleToPattern(SamplePattern objSamplePattern, int UserId)
        {
            return this.FITsDataProviderInstance.GetReschedule_StyleToPattern(objSamplePattern, UserId);
        }
        public List<SamplePattern> CADMaster()
        {
            return this.FITsDataProviderInstance.CADMaster();
        }
        public bool Update_Reschedule_StyleToPattern(SamplePattern objSamplePattern, int UserId, string Type)
        {
            return this.FITsDataProviderInstance.Update_Reschedule_StyleToPattern(objSamplePattern, UserId, Type);
        }

        public List<SamplePattern> GetAutoAllocation_Status()
        {
            return this.FITsDataProviderInstance.GetAutoAllocation_Status();
        }

        public List<SamplePattern> Get_Client_ByAutoAllocPattern()
        {
            return this.FITsDataProviderInstance.Get_Client_ByAutoAllocPattern();
        }
        public List<SamplePattern> Get_ClientDepts_ByAutoAllocPattern(int ClientId)
        {
            return this.FITsDataProviderInstance.Get_ClientDepts_ByAutoAllocPattern(ClientId);
        }

        public List<SamplePattern> GetSamplingFitsCycleFlow(SamplePattern objSamplePattern, int UserId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            return this.FITsDataProviderInstance.GetSamplingFitsCycleFlow(objSamplePattern, UserId, CreateNew, NewRef, ReUse, ReUseStyleId);
        }
        public List<SamplePattern> GetSamplingFitsCycleFlow_PreOrder(SamplePattern objSamplePattern, int UserId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            return this.FITsDataProviderInstance.GetSamplingFitsCycleFlow_PreOrder(objSamplePattern, UserId, CreateNew, NewRef, ReUse, ReUseStyleId);
        }
        // Edit by surendra for Fits flow for pre order
        public bool BcheckIsGrading(int styleid)
        {
            return this.FITsDataProviderInstance.BcheckIsGrading(styleid);
        }
        public bool checkTechPacksOrDesign(int styleid)
        {
            return this.FITsDataProviderInstance.checkTechPacksOrDesign(styleid);
        }

        // end
        public List<SamplePattern> GetAllCQD()
        {
            return this.FITsDataProviderInstance.GetAllCQD();
        }

        public string SaveSamplingFitsCycleFlow(SamplePattern objSamplePattern, int UserId, bool IsBiplUser, bool IsIkandiUser, int ReUse, int ReUseStyleId)
        {
            return this.FITsDataProviderInstance.SaveSamplingFitsCycleFlow(objSamplePattern, UserId, IsBiplUser, IsIkandiUser, ReUse, ReUseStyleId);
        }
        public string SaveSamplingFitsCycleFlow_PreOrder(SamplePattern objSamplePattern, int UserId, bool IsBiplUser, bool IsIkandiUser, int ReUse, int ReUseStyleId)
        {
            return this.FITsDataProviderInstance.SaveSamplingFitsCycleFlow_PreOrder(objSamplePattern, UserId, IsBiplUser, IsIkandiUser, ReUse, ReUseStyleId);
        }
        public List<SamplePattern> GetSamplingFitsCycleHistory(int StyleId, int Mode)
        {
            return this.FITsDataProviderInstance.GetSamplingFitsCycleHistory(StyleId, Mode);
        }
        public List<SamplePattern> GetSamplingFitsCycleHistory_ForPreOrder(int StyleId)
        {
            return this.FITsDataProviderInstance.GetSamplingFitsCycleHistory_ForPreOrder(StyleId);
        }
        public bool ReUseSamplingFitsCycleFlow(int StyleId, int ReUse, int UserId, string status)
        {
            return this.FITsDataProviderInstance.ReUseSamplingFitsCycleFlow(StyleId, ReUse, UserId, status);
        }
      //Addded by abhishek on 11/9/2018 
        public DataSet GetSamplingFitsCycle(int Styleid)
        {
          return this.FITsDataProviderInstance.GetSamplingFitsCycle(Styleid);
        }
        public DataSet GetReqSample(int Styleid)
        {
          return this.FITsDataProviderInstance.GetReqSample(Styleid);
        }
        public int InsertSamplingFitsCycle(int Styleid, String RequestSample, int ID, string Status)
        {
          return this.FITsDataProviderInstance.InsertSamplingFitsCycle(Styleid, RequestSample, ID, Status);
        }
        public DataSet GetProDuctionFitsCycle(int Styleid)
        {
          return this.FITsDataProviderInstance.GetProDuctionFitsCycle(Styleid);
        }
        public int InsertProductionFitsCycle(int Styleid, String RequestSample, int ID, string Status)
        {
          return this.FITsDataProviderInstance.InsertProductionFitsCycle(Styleid, RequestSample, ID, Status);
        }
        public DataSet GetSamplingFitsCycleForHistory(int Styleid)
        {
          return this.FITsDataProviderInstance.GetSamplingFitsCycleForHistory(Styleid);
        }
        public bool bCheck_ProductionRequestIntiate(int Styleid,bool IsproductionSample)
        {
            return FITsDataProviderInstance.bCheck_ProductionRequestIntiate(Styleid, IsproductionSample);
        }
        public List<SamplePattern> Get_ClientDeptsParent(int ClientId, string type, int ParentDeptID)
        {
          return this.FITsDataProviderInstance.Get_ClientDeptsParent(ClientId, type, ParentDeptID);
        }
        public bool IsShowPre_Order_Sampling(int StyleID)
        {
            return this.FITsDataProviderInstance.IsShowPre_Order_Sampling(StyleID);
        }
      //END abhishek 
    }
}
