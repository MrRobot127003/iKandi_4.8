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

namespace iKandi.BLL
{
    public class QualityController : BaseController
    {
        #region Ctor(s)

        public QualityController()
        {
        }

        public QualityController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Methods
        //Add By Prabhaker 27/feb/18
        public DataSet GetReallocation_OutHouse_Emb(string Reallocation_OutHouse_Emb)
        {
            return this.QualityControlDataProviderInstance.GetReallocation_OutHouse_Emb(Reallocation_OutHouse_Emb);
        }
        public DataSet GetReallocation_OutHouse(string Reallocation_OutHouse)
        {
            return this.QualityControlDataProviderInstance.GetReallocation_OutHouse(Reallocation_OutHouse);
        }
        //End Of COde
        public string GetQAStatusMO(int orderDetailID, int styleID)
        {
            return this.QualityControlDataProviderInstance.GetQAStatusMO(orderDetailID, styleID);
        }
        public DataSet GetQAStatus(int orderDetailID, int styleID)
        {
            return this.QualityControlDataProviderInstance.GetQAStatus(orderDetailID, styleID);
        }

        public QualityControl GetQualityControlHistoryBAL(int orderDetailID)
        {
            return this.QualityControlDataProviderInstance.GetQualityControlHistoryDAL(orderDetailID);
        }

        public QualityControl GetQualityControlByIDHistoryBAL(int orderDetailID)
        {
            return this.QualityControlDataProviderInstance.GetQualityControlByIDHistoryDAL(orderDetailID);
        }

        public QualityControl GetQualityControl(int orderDetailID, string InspectionID, int QualityControlID)
        {
            return this.QualityControlDataProviderInstance.GetQualityControl(orderDetailID, InspectionID, QualityControlID);
        }

        public QualityControl GetQualityControlByID(int orderDetailID)
        {
            return this.QualityControlDataProviderInstance.GetQualityControlByID(orderDetailID);
        }

        public DataSet GetAuditChart(String AqlValue)
        {
            return this.QualityControlDataProviderInstance.GetAuditChart(AqlValue);
        }

        public DataSet GetEmailID(string owner)
        {
            return this.QualityControlDataProviderInstance.GetEmail(owner);
        }
        public DataSet GetQCUserComments(int styleid, string flag)
        {
            return this.QualityControlDataProviderInstance.GetQCUserComments(styleid, flag);
        }

        //Add By Prabhaker 07-feb-18
        public DataSet GetQCLineMan(int orderDetailID, int QualityControlID)
        {
            return this.QualityControlDataProviderInstance.GetQCLineMan(orderDetailID, QualityControlID);
        }

        //End Of Code
        public bool InsertQualityControl(QualityControl qualityControl)
        {
            bool success = this.QualityControlDataProviderInstance.InsertQuality(qualityControl);
            var totalParts = 0;
            var approvedParts = 0;

            try
            {
                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    totalParts = qualityControl.FaultsPP.Count;
                    foreach (QualityFaults qfpp in qualityControl.FaultsPP)
                    {
                        if (qfpp.ProductionPlanningID > 0)
                        {
                            //if (qfpp.Status == "1")
                            //{
                            approvedParts++;
                            iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(qualityControl.OrderDetail.OrderDetailID);
                            OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == qualityControl.OrderDetail.OrderDetailID; });


                            //WorkflowInstance instance;
                            // Update workflow
                            //if (!(qfpp.IsPartShipment))
                            //    instance = this.WorkflowControllerInstance.GetInstance(order.Style.StyleID, order.OrderID, orderDetail.OrderDetailID);
                            //else
                            //    instance = this.WorkflowControllerInstance.GetInstance(qfpp.ProductionPlanningID);

                            //Gajendra Workflow
                            if (qualityControl.ApprovedByQAManager == 1)
                            {
                                //WorkflowInstance instance1 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Approval_QA, this.LoggedInUser.UserData.UserID);//18-04-2016
                                WorkflowInstance instance2 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Shipping, this.LoggedInUser.UserData.UserID);//18-04-2016
                                int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);

                                // int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);
                                //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                                //foreach (WorkflowInstanceDetail task in tasks)
                                //{
                                //    if (task.StatusModeID == (int)StatusMode.APPROVEDTOEXFACTORY && task.ApplicationModule.ApplicationModuleID == (int)AppModule.QUALITY_CONTROL)
                                //    {
                                //        this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                                //        this.WorkflowControllerInstance.CreateTask(StatusMode.EXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);

                                //        //this.NotificationControllerInstance.SendQAStausEmail(qfpp.ProductionPlanningID, false);
                                //    }
                                //}
                            }
                            //if (qualityControl.ApprovedByClientHead == 1)
                            //{
                            //    WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_CLT_QA_Pending, this.LoggedInUser.UserData.UserID);
                            //    int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);

                            //}
                            if (qualityControl.ApprovedByFactoryHead == 1)
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Fact_QA_Pending, this.LoggedInUser.UserData.UserID);
                                //int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);18-04-2016
                            }

                        }
                        else if (qfpp.Status == "2")
                        {
                            this.NotificationControllerInstance.SendQAStausEmail(qfpp.ProductionPlanningID, true);
                        }
                        //}
                    }

                    //if (approvedParts == totalParts)
                    //{
                    //    Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(qualityControl.OrderDetail.OrderDetailID);
                    //    OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == qualityControl.OrderDetail.OrderDetailID; });

                    //    // Update workflow
                    //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, qualityControl.OrderDetail.OrderDetailID);
                    //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //    foreach (WorkflowInstanceDetail task in tasks)
                    //    {
                    //        if (task.StatusModeID == (int)StatusMode.APPROVEDTOEXFACTORY && task.ApplicationModule.ApplicationModuleID == (int)AppModule.QUALITY_CONTROL)
                    //        {
                    //            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                    //            this.WorkflowControllerInstance.CreateTask(StatusMode.EXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(qualityControl.OrderDetail.OrderDetailID);
                    //    OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == qualityControl.OrderDetail.OrderDetailID; });

                    //    // Update workflow
                    //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, qualityControl.OrderDetail.OrderDetailID);
                    //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    //    foreach (WorkflowInstanceDetail task in tasks)
                    //    {
                    //        if (task.StatusModeID == (int)StatusMode.APPROVEDTOEXFACTORY && task.ApplicationModule.ApplicationModuleID == (int)AppModule.QUALITY_CONTROL)
                    //        {
                    //            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                    //            this.WorkflowControllerInstance.CreateTask(StatusMode.PARTEXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }


            return success;
        }

        public bool UpdateQualityControl(QualityControl qualityControl)
        {
            bool success = this.QualityControlDataProviderInstance.UpdateQuality(qualityControl);

            try
            {
                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    foreach (QualityFaults qfpp in qualityControl.FaultsPP)
                    {
                        if (qfpp.ProductionPlanningID > 0)
                        {
                            if (qfpp.Status == "1")
                            {
                                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(qualityControl.OrderDetail.OrderDetailID);
                                OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == qualityControl.OrderDetail.OrderDetailID; });


                                //WorkflowInstance instance;
                                //if (!(qfpp.IsPartShipment))
                                //    instance = this.WorkflowControllerInstance.GetInstance(order.Style.StyleID, order.OrderID, orderDetail.OrderDetailID);
                                //else
                                //    instance = this.WorkflowControllerInstance.GetInstance(qfpp.ProductionPlanningID);

                                //Update workflow

                                //Gajendra Workflow
                                if (qualityControl.ApprovedByQAManager == 1)
                                {
                                    //WorkflowInstance instance1 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Approval_QA, this.LoggedInUser.UserData.UserID);//18-04-2016
                                    WorkflowInstance instance2 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Shipping, this.LoggedInUser.UserData.UserID);//18-04-2016
                                    int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);

                                    //int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(orderDetail.ParentOrder.Style.StyleID, orderDetail.OrderID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);
                                    //List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                                    //foreach (WorkflowInstanceDetail task in tasks)
                                    //{
                                    //    if (task.StatusModeID == (int)StatusMode.APPROVEDTOEXFACTORY && task.ApplicationModule.ApplicationModuleID == (int)AppModule.QUALITY_CONTROL)
                                    //    {
                                    //        this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                    //        this.WorkflowControllerInstance.CreateTask(StatusMode.EXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);

                                    //        //this.NotificationControllerInstance.SendQAStausEmail(qfpp.ProductionPlanningID, false);
                                    //    }
                                    //}
                                }
                                //if (qualityControl.ApprovedByClientHead == 1)
                                //{
                                //    WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_CLT_QA_Pending, this.LoggedInUser.UserData.UserID);
                                //    int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);
                                //}
                                if (qualityControl.ApprovedByFactoryHead == 1)
                                {
                                    WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_To_EX_Fact_QA_Pending, this.LoggedInUser.UserData.UserID);
                                    //int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);18-04-2016
                                }
                            }
                            else if (qfpp.Status == "2")
                            {
                                this.NotificationControllerInstance.SendQAStausEmail(qfpp.ProductionPlanningID, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }


            return success;
        }


        //public List<QualityFaultsCategory> GetQualityFaultCategories()
        //{
        //    return this.QualityControlDataProviderInstance.GetQualityFaultCategories();
        //}


        public DataTable GetQualityFaultSubCategories()
        {
            return this.QualityControlDataProviderInstance.GetQualityFaultSubCategories();
        }


        public DataTable GetQualityControlSatatusFailData(int ProductionPlanningID)
        {
            return this.QualityControlDataProviderInstance.GetQualityControlSatatusFailData(ProductionPlanningID);
        }

        public DataTable GetAllAqlStanderdBAL(int ClientID)
        {
            DataTable dt = this.QualityControlDataProviderInstance.GetAllAqlStanderdDAL(ClientID);
            return dt;
        }


        public DataTable GetAllAqlExistingStanderdBAL(double AQLType, double DoubleNewAQL)
        {
            DataTable dt = this.QualityControlDataProviderInstance.GetAllAqlExistingStanderdDAL(AQLType, DoubleNewAQL);
            return dt;
        }
        public void InserNewAQLBAL(string XMLDataAQL)
        {
            this.QualityControlDataProviderInstance.InserNewAQLDAL(XMLDataAQL);
        }


        public void InsertFinalAuditAndQualityAssuranceBAL(string[] stringonlineData, int proID, string stringXML, int intQualitycontrolID, double AQLType, string FaultRepoting)
        {
            this.QualityControlDataProviderInstance.InsertFinalAuditAndQualityAssuranceDAL(stringonlineData, proID, stringXML, intQualitycontrolID, AQLType, FaultRepoting);
        }
        public DataSet GET_FinalAuditAndQualityAssuranceBAL(int intOrderDetailId)
        {
            DataSet ds = this.QualityControlDataProviderInstance.GET_FinalAuditAndQualityAssuranceDAL(intOrderDetailId);
            return ds;
        }


        public string GetPriviousAQLBAL(int intOrderDetailId)
        {
            return this.QualityControlDataProviderInstance.GetPriviousAQLDAL(intOrderDetailId);
        }

        public string SaveQAStatusDetails(string ixml, int orderDetailID, int styleID, int userID)
        {
            return this.QualityControlDataProviderInstance.SaveQAStatusDetails(ixml, orderDetailID, styleID, userID);
        }
        #endregion
        //abhishek on 11/5/2016
        public int InserNewAQLMidInLineDAL(int SampleSize, int MajorDefectsPass, int MajorDefectsFail, int MinorDefectsPass, int MinorDefectsFail, string AQLtype)
        {
            return this.QualityControlDataProviderInstance.InserNewAQLMidInLineDAL(SampleSize, MajorDefectsPass, MajorDefectsFail, MinorDefectsPass, MinorDefectsFail, AQLtype);
        }
        public DataTable GetAllAqlExistingStanderdMINLINEDAL(string AQLType)
        {
            DataTable dt = this.QualityControlDataProviderInstance.GetAllAqlExistingStanderdMINLINEDAL(AQLType);
            return dt;
        }
        //edn 

        //======================================================New==================================================================
        public DataSet GetQualityControlBYContract(string OrderId, string OrderDetailID, string InspectionID, string InspectionIDMO)
        {
            DataSet DS = this.QualityControlDataProviderInstance.GetQualityControlBYContract(OrderId, OrderDetailID, InspectionID, InspectionIDMO);
            return DS;
        }

        public DataTable GetQcUploadFile(int orderDetailID, string QualityControlID)
        {
            DataTable DS = this.QualityControlDataProviderInstance.GetQcUploadFile(orderDetailID, QualityControlID);
            return DS;
        }

        //Add By Prabhaker 08/aug/18
        public DataTable GetQcLinemannew(int orderDetailID, string QualityControlID)
        {
            DataTable DS = this.QualityControlDataProviderInstance.GetQcLinemannew(orderDetailID, QualityControlID);
            return DS;
        }
        //End Of Code

        public List<QualityContract> GetContractBYOrder(string OrderId, string InspectionID)
        {
            return QualityControlDataProviderInstance.GetContractBYOrder(OrderId, InspectionID);
        }
        public QualityControl GetQualityControlBYQuality(int orderDetailID, string QualityControlID, string InspectionType)
        {
            return this.QualityControlDataProviderInstance.GetQualityControlBYQuality(orderDetailID, QualityControlID, InspectionType);
        }
        public DataSet GetFault_Subcategory()
        {
            DataSet ds = this.QualityControlDataProviderInstance.GetFault_Subcategory();
            return ds;
        }

        public bool InsertQualityControlNew(QualityControl qualityControl)
        {
            bool success = this.QualityControlDataProviderInstance.InsertQualityNew(qualityControl);
            //=======================================================Task Movements==============================================================================================================
            if (success)
            {
                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    //WorkflowInstance instance;
                    QualityFaults qfpp = qualityControl.FaultsPP[0];

                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 1) //For Inline Task && qualityControl.ApprovedByBuyingHouse == 1
                    {
                        this.QualityControlDataProviderInstance.CloseQCInline_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qfpp.Status);

                        DataTable QCDT = this.QualityControlDataProviderInstance.Get_AllQCInline_Task(qualityControl.OrderDetail.OrderID.ToString(), qualityControl.OrderDetail.OrderDetailID.ToString()).Tables[0];
                        for (int i = 0; i < QCDT.Rows.Count; i++)
                        {
                            this.QualityControlDataProviderInstance.CloseQCInline_Task(QCDT.Rows[i]["OrderDetailID"].ToString(), qfpp.Status);
                        }
                    }

                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 3 && qfpp.Status == "1") //For Final Task && qualityControl.OrderDetail.PercentageOverallPcsPacked >= 80 && qualityControl.ApprovedByBuyingHouse_Factory == 1 && qualityControl.ApprovedByBuyingHouse_IC == 1
                    {
                        WorkflowInstance instance3 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(qualityControl.OrderDetail.OrderID, qualityControl.OrderDetail.OrderDetailID, TaskMode.Final_Inspection, this.LoggedInUser.UserData.UserID);
                        int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(qualityControl.OrderDetail.OrderID, qualityControl.OrderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);
                        this.QualityControlDataProviderInstance.CloseQC_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qualityControl.InspectionID.ToString());
                    }

                    if ((qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 2 && qfpp.Status == "1") || (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 4 && qfpp.Status == "1")) //For Mid and Online Task && qualityControl.ApprovedByBuyingHouse == 1
                    {
                        this.QualityControlDataProviderInstance.Create_CloseQC_Mid_Online_Inspection_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qualityControl.InspectionID.ToString());
                    }
                }

            }
            return success;

        }
        public bool UpdateQualityControlNew(QualityControl qualityControl)
        {
            bool success = this.QualityControlDataProviderInstance.UpdateQualityNew(qualityControl);
            //=======================================================Task Movements==============================================================================================================
            if (success)
            {
                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    //WorkflowInstance instance;
                    QualityFaults qfpp = qualityControl.FaultsPP[0];

                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 1) //For Inline Task && qualityControl.ApprovedByBuyingHouse == 1
                    {

                        this.QualityControlDataProviderInstance.CloseQCInline_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qfpp.Status);

                        DataTable QCDT = this.QualityControlDataProviderInstance.Get_AllQCInline_Task(qualityControl.OrderDetail.OrderID.ToString(), qualityControl.OrderDetail.OrderDetailID.ToString()).Tables[0];
                        for (int i = 0; i < QCDT.Rows.Count; i++)
                        {
                            this.QualityControlDataProviderInstance.CloseQCInline_Task(QCDT.Rows[i]["OrderDetailID"].ToString(), qfpp.Status);

                        }
                    }

                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 3 && qfpp.Status == "1") //For Final Task && qualityControl.OrderDetail.PercentageOverallPcsPacked >= 80 && qualityControl.ApprovedByBuyingHouse_Factory == 1 && qualityControl.ApprovedByBuyingHouse_IC == 1
                    {

                        WorkflowInstance instance3 = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(qualityControl.OrderDetail.OrderID, qualityControl.OrderDetail.OrderDetailID, TaskMode.Final_Inspection, this.LoggedInUser.UserData.UserID);
                        int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(qualityControl.OrderDetail.OrderID, qualityControl.OrderDetail.OrderDetailID, TaskMode.Approved_toEx, this.LoggedInUser.UserData.UserID);
                        this.QualityControlDataProviderInstance.CloseQC_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qualityControl.InspectionID.ToString());
                    }

                    if ((qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 2 && qfpp.Status == "1") || (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 4 && qfpp.Status == "1")) //For Mid and Online Task && qualityControl.ApprovedByBuyingHouse == 1
                    {
                        this.QualityControlDataProviderInstance.Create_CloseQC_Mid_Online_Inspection_Task(qualityControl.OrderDetail.OrderDetailID.ToString(), qualityControl.InspectionID.ToString());
                    }

                }
            }
            return success;
        }
        public int UpdateQualityControlBH(QualityControl qualityControl)
        {
            return this.QualityControlDataProviderInstance.UpdateQualityControlBH(qualityControl);
        }
        public string CreateQualityProxy(string OrderDetailID, string InspectionID, string None, string RefOrderDetailID)
        {
            return QualityControlDataProviderInstance.CreateQualityProxy(OrderDetailID, InspectionID, None, RefOrderDetailID);
        }

        // Added By Ravi kumar for auto complete Nature of faults
        public string GetNatureOfFaults_Value(string NatureOfFaults)
        {
            return QualityControlDataProviderInstance.GetNatureOfFaults_Value(NatureOfFaults);
        }

        public DataSet Get_AllQC_CotractsByOrder(int OrderID, int OrderDetailId, string InspectionID)
        {
            return this.QualityControlDataProviderInstance.Get_AllQC_CotractsByOrder(OrderID, OrderDetailId, InspectionID);
        }
        public DataSet Get_AllQC_CotractsByOrder_Rescan(int OrderID, int OrderDetailId, string InspectionID, int QualityControlId)
        {
            return this.QualityControlDataProviderInstance.Get_AllQC_CotractsByOrder_Rescan(OrderID, OrderDetailId, InspectionID, QualityControlId);
        }

        public string CreateQCContractsProxy(string OrderDetailID, string InspectionID, bool IsTaskDone, string RefOrderDetailID, int InLineFromPopUp, int Status, int QualityControlId)
        {
            return QualityControlDataProviderInstance.CreateQCContractsProxy(OrderDetailID, InspectionID, IsTaskDone, RefOrderDetailID, InLineFromPopUp, Status, QualityControlId);
        }


        //Add By Prabhaker on 31-aug-18
        public string CreateQCContractsProxy_Rescan(string OrderDetailID, string RescanDate, int QualityControlId, bool IsTaskDone)
        {
            return QualityControlDataProviderInstance.CreateQCContractsProxy_Rescan(OrderDetailID, RescanDate, QualityControlId, IsTaskDone);
        }

        public string VAlidateSerialNumber(string SerialNumber)
        {
            return QualityControlDataProviderInstance.VAlidateSerialNumber(SerialNumber);
        }
        public QualityControl GetQcFualtSummary()
        {
            return this.QualityControlDataProviderInstance.GetQcFualtSummary();
        }
        public DataSet GetQcFualtPer(int UnitID, string Flag, string FaultTypeID)
        {
            DataSet ds = this.QualityControlDataProviderInstance.GetQcFualtPer(UnitID, Flag, FaultTypeID);
            return ds;
        }

        public int DeleteQc_Lineman(int OrderDetailId, int QualityControlId)
        {
            return this.QualityControlDataProviderInstance.DeleteQc_Lineman(OrderDetailId, QualityControlId);
        }
        //Added by abishek on 6.2.2018
        public List<iKandi.Common.QCFormSupport> UpdateSupportIssue(string Flag, int OrderdetailID, string createdon, int QAtype)
        {
            return this.QualityControlDataProviderInstance.UpdateSupportIssue(Flag, OrderdetailID, createdon, QAtype);
        }
        public bool UpdateQCSheetStatus(string flag, int QCID)
        {
            return this.QualityControlDataProviderInstance.UpdateQCSheetStatus(flag, QCID);
        }

        public bool PendingOrderSummaryUpdate(string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin, int Stagevalt, int FabricPending_Orders_Id, Boolean finlized)
        {
            return this.QualityControlDataProviderInstance.PendingOrderSummaryUpdate(flag, StagesCount, OrderDetailID, fabricMasterID, ColorPrin, Stagevalt, FabricPending_Orders_Id, finlized);
        }
        public bool PendingOrderSummaryUpdateOnStagechange(string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin,
             int NewSelectionStageNo1, int NewSelectionStageNo2, int NewSelectionStageNo3, int NewSelectionStageNo4, int OldSelectionStageNo1, int OldSelectionStageNo2, int OldSelectionStageNo3, int OldSelectionStageNo4, int FabricPending_Orders_Id, Boolean finlized)
        {
            return this.QualityControlDataProviderInstance.PendingOrderSummaryUpdateOnStagechange(flag, StagesCount, OrderDetailID, fabricMasterID, ColorPrin, NewSelectionStageNo1, NewSelectionStageNo2, NewSelectionStageNo3, NewSelectionStageNo4, OldSelectionStageNo1, OldSelectionStageNo2, OldSelectionStageNo3, OldSelectionStageNo4, FabricPending_Orders_Id, finlized);

        }
        //--------------Edit by surendra on Lock down crona virus spread time for Auto stock Allocated.................
        public bool AutoAllocate_Fabric_From_Stock(int OrderDetailID, int fabricMasterID, string ColorPrin, int Stage1, int Stage2, int Stage3, int Stage4,bool Checked)
        {
            return this.QualityControlDataProviderInstance.AutoAllocate_Fabric_From_Stock(OrderDetailID, fabricMasterID, ColorPrin, Stage1, Stage2, Stage3, Stage4, Checked);
        }
        //---------------End by surendra on Lock down crona virus spread time for Auto stock Allocated.................
        public bool updatePendingGreigeOrdersSupplier(string flag, int Fabric_MasterID, float QuotedLandedRate,  int Supplier_master_ID, int SupplierGreigedOrder_Id, int fabQtyID, string fabricdetails,int DeliveryType)
        {
            return this.QualityControlDataProviderInstance.updatePendingGreigeOrdersSupplier(flag, Fabric_MasterID, QuotedLandedRate,  Supplier_master_ID, SupplierGreigedOrder_Id, fabQtyID, fabricdetails,DeliveryType);
        }
      
        public bool UpdateQuatationEmbellishmentVA(string flag, int QualityID, int VAID, float QuotedLandedRate,  int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return this.QualityControlDataProviderInstance.UpdateQuatationEmbellishmentVA(flag, QualityID, VAID, QuotedLandedRate,  SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        public bool UpdateQuatationotherVA(string flag, int QualityID, int VAID, float QuotedLandedRate,  int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return this.QualityControlDataProviderInstance.UpdateQuatationotherVA(flag, QualityID, VAID, QuotedLandedRate, SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        public bool UpdateQuatationDayedVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid,int DeliveryType)
        {
            return this.QualityControlDataProviderInstance.UpdateQuatationDayedVA(flag, QualityID, VAID, QuotedLandedRate,SuppliermasterID, fabricdetails, Styleid,DeliveryType);
        }
        public bool UpdateQuatationPrintVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return this.QualityControlDataProviderInstance.UpdateQuatationPrintVA(flag, QualityID, VAID, QuotedLandedRate, SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        public bool UpdateQuatationStyleBasedVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int LeadTimes, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4)
        {
            return this.QualityControlDataProviderInstance.UpdateQuatationStyleBasedVA(flag, QualityID, VAID, QuotedLandedRate, LeadTimes, SuppliermasterID, fabricdetails, Styleid,  stage1,  stage2,  stage3,  stage4);
        }
    }
}
