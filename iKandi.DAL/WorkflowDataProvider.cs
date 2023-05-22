using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class WorkflowDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public WorkflowDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public int UpdateWorkflowInstancePostOrder(WorkflowInstance WFInstance)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PostOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = WFInstance.AssignedTo.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Actiondate", SqlDbType.DateTime);
                //param.Value = WFInstance.AssignedTo.Actiondate;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdatePostOrder_ForApprovedToEx_And_Exfactoried(WorkflowInstance WFInstance)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_Update_ForApprovedToEx_And_Exfactoried";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = WFInstance.AssignedTo.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int CreateTaskFor_Consolidated(WorkflowInstance WFInstance)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "CreateTask_For_Consolidated";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = WFInstance.AssignedTo.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public int UpdateWorkflowInstancePostOrder_WithOutInstance(int orderid, int OrderDetailID, int StatusModeID, int UserID)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PostOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }


        public DataSet GetNotifactionRemarks(int DesignationID, int taskid, string types, int iUserid)
        {


            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet ds = new DataSet();
                string cmdText = "sp_GetNotifactionRemarksByEmailid";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@emailid", SqlDbType.Int);
                param.Value = taskid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = types;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = iUserid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                adapter.Fill(ds, "Table");
                return ds;
            }
        }


        public DataSet GetTaskCompletebyTask(int taskid)
        {


            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet ds = new DataSet();
                string cmdText = "GetTaskCompletetionById";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@taskid", SqlDbType.Int);
                param.Value = taskid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                adapter.Fill(ds, "Table");
                return ds;
            }
        }




        public int UpdateWorkflowInstancePostOrder_Style_Order_Basis(int StyleId, int OrderId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PostOrder_Style_Order_Basis";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdateWorkflowInstancePostOrder_Only_For_Cutting(int OrderDetailID, int OrderId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PostOrder_Contract_Specific";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdatePreOrderToPostOrder_ForSampling(int StyleId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdatePreOrderToPostOrder_ForSampling";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                Result = cmd.ExecuteNonQuery();
                cnx.Close();
                Auto_Sample_Pattern_Allocation(StyleId);

                return Result;
            }
        }

        public int Auto_Sample_Pattern_Allocation(int StyleId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_Auto_Sample_Pattern_Allocation";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public int DeleteUnnessaryFits_UploadComentesTask(int StyleId, int StatusId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_DeleteFits_UploadCommentes_AfterSTCApproved";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusID", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@StatusId", SqlDbType.Int);
                //param.Value = StatusId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                //param.Value = UserId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public int SplitOrder_FromOrderID(int OrderID)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_splitOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdateWorkflowInstancePreOrder_ForCreateOB(int StyleId, int OrderId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowInstancePreOrder_ForCreateOB";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int CreateTaskForCutAvg(int OrderId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "usp_CreateTask_ForCutAvg";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;



                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public bool GetMrMathurCheckBox(int StyleId)
        {
            bool bcheck = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_checkMrMathur_CheckBox";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["MrMathurCheckBox"].ToString() == "0")
                        {
                            bcheck = false;
                        }
                        else
                        {
                            bcheck = true;
                        }

                    }
                }

                cnx.Close();

                return bcheck;
            }

        }
        public bool CheckOrderExistAndSamplingStatus(int StyleId)
        {
            bool bcheck = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_CheckOrderExistAndSamplingStatus";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Convert.ToString(reader["CheckOrderExistAndSamplingStatus"]) == "0")
                        {
                            bcheck = false;
                        }
                        else
                        {
                            bcheck = true;
                        }

                    }
                }

                cnx.Close();

                return bcheck;
            }

        }
        //Ceate by Surendra2 on 11-12-2018
        public int UpdateWorkflowInstanceClosing_PreOrder(int StyleId, int StatusId, int UserId, int Type)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText;
                cmdText = "Usp_UpdateWorkFlowTask_ForClose_Preorder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        //Ceate by Surendra2 on 11-12-2018
        public int UpdateWorkflowInstanceOpen_PreOrder(int StyleId, int StatusId, int UserId, int Type)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText;
                cmdText = "Usp_UpdateWorkFlowTask_ForOpen_Preorder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                Result = cmd.ExecuteNonQuery();

                int OutValue = Convert.ToInt32(outParam.Value == DBNull.Value ? "0" : outParam.Value);
                if (OutValue > 0)
                {
                    Result = OutValue;
                }

                cnx.Close();

                return Result;
            }
        }
        //Gajendra Workflow
        public int UpdateWorkflowInstancePreOrder(int StyleId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText;
                if (StatusId == 8)
                    cmdText = "Update_Order_AgreementTask";
                else
                    cmdText = "Usp_UpdateWorkflowTask_PreOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdateWorkflow_PatternReady(int StyleId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowFor_PatternReady";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdateWorkflow_SampleSent_Closed_CourierSent(int StyleId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowFor_SampleSent_If_CouriersentDone";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int UpdateWorkflowInstanceFisModule_SpecialCases(int StyleId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PreOrder_ForFitsStatus";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public int Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(int OrderId, int OrderDetailId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }
        public int Update_PreOrder_Fits_Cycle(int StyleId, string status, string Requested, string PDDecesion, int UserID)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdatePreOrder_Fits_Cycle";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.VarChar);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Requested", SqlDbType.VarChar);
                param.Value = Requested;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PDDecesion", SqlDbType.VarChar);
                param.Value = PDDecesion;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public string GetDesignationName(int UserId)
        {
            string Result = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GetDesignationName";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = Convert.ToString(cmd.ExecuteScalar());
                cnx.Close();

                return Result;
            }
        }

        public WorkflowInstance InsertWorkflowInstance(WorkflowInstance WFInstance)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_workflow_instance_insert";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //edit by surendra
                //cmd.CommandTimeout = 6000;
                //end
                SqlParameter outParam;
                outParam = new SqlParameter("@oWorkflowInstanceID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                if (WFInstance.Style.StyleID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.Style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                if (WFInstance.Order.OrderID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                if (WFInstance.OrderDetailID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStatusID", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                if (WFInstance.ProductionPlanningID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                WFInstance.WorkflowInstanceID = Convert.ToInt32(outParam.Value);
                cnx.Close();

                return WFInstance;
            }
        }

        public void UpdateWorkflowInstance(WorkflowInstance WFInstance)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_update";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                //param = new SqlParameter("@d", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = WFInstance.WorkflowInstanceID;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = WFInstance.Style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                //if (WFInstance.Order.OrderID == -1)
                //    param.Value = DBNull.Value;
                //else
                param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                //if (WFInstance.OrderDetailID == -1)
                //    param.Value = DBNull.Value;
                //else
                param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStatusID", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int i = cmd.ExecuteNonQuery();



                cnx.Close();
            }
        }


        public DataSet GetGlobalandlanding(int department, int DesignationID, int UserId, int FromLogin)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet ds = new DataSet();
                string cmdText = "dbo.GetGlobalandlandingpage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@department", SqlDbType.Int);
                param.Value = department;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FrmLogin", SqlDbType.Int);
                param.Value = FromLogin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                adapter.Fill(ds, "Table");
                return ds;
            }
        }

        public DataTable GetDelayTaskDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public DataTable Get_LeadTime_DelayTaskDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_LeadTime_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }


        public DataTable GetClients_DelayTaskDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public DataTable GetClients_LeadTime_DelayTaskDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_LeadTime_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }

        public DataTable GetClients_DelayTaskCount(int ClientId, int StatusModeId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusModeId", SqlDbType.Int);
                    param.Value = StatusModeId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public DataTable GetClients_LeadTime_DelayTaskCount(int ClientId, int StatusModeId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_LeadTime_GetDelayTaskDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusModeId", SqlDbType.Int);
                    param.Value = StatusModeId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }

        public void UpdateWorkflowInstanceByID(WorkflowInstance WFInstance)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_update_by_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //cmd.CommandTimeout = 6000;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WFInstance.WorkflowInstanceID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = WFInstance.Style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WFID", SqlDbType.VarChar);
                param.Value = WFInstance.WorkflowInstanceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                if (WFInstance.Order.OrderID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.VarChar);
                if (WFInstance.OrderDetailID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStatusID", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



                cnx.Close();
            }
        }
        public bool IscheckInlinetask(int mode, int statusMode)
        {
            bool bcheck = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_checkinlinecut_status";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@ModeID", SqlDbType.Int);
                param.Value = mode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@WorkFlowInstanceID", SqlDbType.Int);
                param.Value = statusMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["assignedto"] == DBNull.Value)
                        {
                            bcheck = false;
                        }
                        else
                        {
                            bcheck = true;
                        }

                    }
                }

                cnx.Close();

                return bcheck;
            }

        }
        public bool IsCheckCreateOBInPre_Order(int styleid)
        {
            bool bcheck = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "IsCheckCreateOBInPre_Order";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["ExistOrder"] == DBNull.Value)
                        {
                            bcheck = false;
                        }
                        else
                        {
                            bcheck = true;
                        }

                    }
                }

                cnx.Close();

                return bcheck;
            }

        }
        public WorkflowInstanceDetail InsertWorkflowInstanceDetail(WorkflowInstanceDetail WFInstanceDetail)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_workflow_instance_detail_insert";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@oWorkflowInstanceDetailID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@WorkflowInstanceID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WFInstanceDetail.WorkflowInstance.WorkflowInstanceID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeID", SqlDbType.Int);
                param.Value = WFInstanceDetail.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionID", SqlDbType.Int);
                param.Value = WFInstanceDetail.ActionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ActionDate", SqlDbType.DateTime);

                if ((WFInstanceDetail.ActionDate == DateTime.MinValue) || (WFInstanceDetail.ActionDate == Convert.ToDateTime("1753-01-01")) || (WFInstanceDetail.ActionDate == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstanceDetail.ActionDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);

                if (WFInstanceDetail.AssignedTo == null || WFInstanceDetail.AssignedTo.UserID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = WFInstanceDetail.AssignedTo.UserID;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ETA", SqlDbType.DateTime);

                if ((WFInstanceDetail.ETA == DateTime.MinValue) || (WFInstanceDetail.ETA == Convert.ToDateTime("1753-01-01")) || (WFInstanceDetail.ETA == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = WFInstanceDetail.ETA;
                }

                // param.Value = WFInstanceDetail.ETA;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                WFInstanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(outParam.Value);
                return WFInstanceDetail;
            }
        }

        public WorkflowInstance GetInstance(int StyleID, int OrderID, int OrderDetailID, int ProductionPlanningID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_get";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                if (StyleID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                if (OrderID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.VarChar);
                if (OrderDetailID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.VarChar);
                if (ProductionPlanningID == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                WorkflowInstance instance = new WorkflowInstance();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        instance.WorkflowInstanceID = Convert.ToInt32(reader["Id"]);
                        instance.Style = new Style();
                        instance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instance.Style.IsIkandiClient = (reader["IsIkandiClient"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["IsIkandiClient"]);
                        instance.Order = new Order();
                        instance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instance.Order.OrderBreakdown = new List<OrderDetail>();
                        OrderDetail od = new OrderDetail();
                        instance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                        instance.Order.OrderBreakdown.Add(od);
                        instance.CurrentStatus = new WorkflowInstanceDetail();
                        instance.CurrentStatus.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);
                        instance.ProductionPlanningID = (reader["ProductionPlanningID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ProductionPlanningID"]);
                    }
                }

                cnx.Close();

                return instance;
            }
        }

        public iKandi.Common.WorkflowInstance GetInstanceByID(int InstanceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_get_by_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = InstanceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                WorkflowInstance instance = new WorkflowInstance();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        instance.WorkflowInstanceID = Convert.ToInt32(reader["Id"]);
                        instance.Style = new Style();
                        instance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instance.Order = new Order();
                        instance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instance.Order.OrderBreakdown = new List<OrderDetail>();
                        OrderDetail od = new OrderDetail();
                        instance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                        instance.Order.OrderBreakdown.Add(od);
                        instance.CurrentStatus = new WorkflowInstanceDetail();
                        instance.CurrentStatus.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);
                    }
                }

                cnx.Close();

                return instance;
            }
        }

        public WorkflowInstance GetInstanceHistory(int InstanceID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_workflow_instance_get_history";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@WorkflowInstanceID", SqlDbType.VarChar);
                param.Value = InstanceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsWorkflow = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsWorkflow);

                WorkflowInstance instance = ConvertDataSetToWorkflowInstance(dsWorkflow);

                cnx.Close();

                return instance;
            }
        }

        private WorkflowInstance ConvertDataSetToWorkflowInstance(DataSet dsWorkflow)
        {
            DataTable wfTable = dsWorkflow.Tables[0];

            DataRowCollection rows = wfTable.Rows;

            WorkflowInstance instance = new WorkflowInstance();

            if (rows.Count > 0)
            {
                instance.WorkflowInstanceID = Convert.ToInt32(rows[0]["Id"]);
                instance.Style = new Style();
                instance.Style.StyleID = Convert.ToInt32(rows[0]["StyleID"]);
                //instance.Style.IsIkandiClient = Convert.ToInt32(rows[0]["IsIkandiClient"]);
                instance.Order = new Order();
                instance.Order.OrderID = (rows[0]["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["OrderID"]);
                instance.Order.OrderBreakdown = new List<OrderDetail>();
                OrderDetail od = new OrderDetail();
                instance.OrderDetailID = od.OrderDetailID = (rows[0]["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["OrderDetailID"]);
                instance.Order.OrderBreakdown.Add(od);
                instance.CurrentStatus = new WorkflowInstanceDetail();
                instance.CurrentStatus.StatusModeID = Convert.ToInt32(rows[0]["CurrentStatusID"]);
                //instance.CurrentStatus.StatusModeSequence = Convert.ToInt32(rows[0]["Sequence"]);
            }

            DataTable wfDetailTable = dsWorkflow.Tables[1];

            instance.WorkflowInstanceHistory = new List<WorkflowInstanceDetail>();

            foreach (DataRow row in wfDetailTable.Rows)
            {
                WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

                //instanceDetail.AssignedTo = new User();
                //instanceDetail.AssignedTo.FirstName = (row["FirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FirstName"]);
                //instanceDetail.AssignedTo.LastName = (row["LastName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["LastName"]);
                instanceDetail.ActionDate = (row["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ActionDate"]);
                instanceDetail.ETA = (row["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ETA"]);
                instanceDetail.StatusModeID = Convert.ToInt32(row["StatusModeID"]);
                //instanceDetail.ModeName = row["Statusname1"].ToString();
                //instanceDetail.ModeName = instanceDetail.ModeName.Replace("(01 Jan 00),Mon","");
                //instanceDetail.StatusModeSequence = Convert.ToInt32(row["Sequence"]);
                instanceDetail.WorkflowInstance = instance;
                //instanceDetail.Permission_Sequence = Convert.ToDouble(row["Permission_Sequence"]);

                instance.WorkflowInstanceHistory.Add(instanceDetail);
            }

            return instance;
        }

        public List<iKandi.Common.WorkflowInstanceDetail> GetInstanceHistory(int StyleID, int OrderID)
        {
            throw new NotImplementedException();
        }
        public List<iKandi.Common.WorkflowInstanceDetail> GetWorkflowIDs(int styleID)
        {
            List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_workflow_tasks_by_style_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@styleID", SqlDbType.Int);
                param.Value = styleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();
                        instanceDetail.AssignedTo = new User();
                        instanceDetail.AssignedTo.UserID = (reader["AssignedTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AssignedTo"]);
                        instanceDetail.ActionDate = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                        instanceDetail.ActionID = (reader["ActionID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ActionID"]);
                        instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                        instanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                        instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["ID"]);
                        instanceDetail.WorkflowInstance = new WorkflowInstance();
                        instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                        instanceDetails.Add(instanceDetail);
                    }
                }
            }
            return instanceDetails;
        }

        public void CompleteWorkflowInstanceTask(WorkflowInstanceDetail WFInstanceDetail)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_detail_complete_task";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                // edit by surendra
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // end
                SqlParameter param;
                param = new SqlParameter("@WorkflowInstanceDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WFInstanceDetail.WorkflowInstanceDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                param.Value = WFInstanceDetail.ActionDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = WFInstanceDetail.AssignedTo.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionID", SqlDbType.Int);
                param.Value = WFInstanceDetail.ActionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



            }
        }

        public void CompleteVeriFyCostingTask(int UserID, int Styleid)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_CompleteVeriFyCostingTask";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                // edit by surendra
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // end
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = Styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();



            }
        }
        public void OnlyAllocationUpdateTask(WorkflowInstanceDetail WFInstanceDetail, int IsStc)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_OnlyAllocationUpdateTask";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                // edit by surendra
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // end
                SqlParameter param;
                param = new SqlParameter("@WorkflowInstanceDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WFInstanceDetail.WorkflowInstanceDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStc", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = IsStc;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



            }
        }

        public void UpdateWorkFlowInstanceDetails(WorkflowInstanceDetail WFInstanceDetail)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflowdetailsUpdate";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                // edit by surendra
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // end
                SqlParameter param;
                param = new SqlParameter("@WorkflowInstanceDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WFInstanceDetail.WorkflowInstanceDetailID;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                //param.Value = WFInstanceDetail.ActionDate;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@UserID", SqlDbType.Int);
                //param.Value = WFInstanceDetail.AssignedTo.UserID;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@ActionID", SqlDbType.Int);
                //param.Value = WFInstanceDetail.ActionID;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



            }
        }

        public void ChangeWorkflowTaskMode(int WorkflowInstanceDetailID, int StatusModeID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_detail_change_mode";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                //edit by surendra
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //end
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = WorkflowInstanceDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeID", SqlDbType.Int);
                param.Value = StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public List<WorkflowInstanceDetail> GetUserTasks(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "GetTask_Detail_ByUser_Courier"; //Gajendra Workflow

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = this.UserTaskDal(reader);

                cnx.Close();
                return instanceDetails; 
            }
        }

        public DateTime GetNextTargetDate(int StatusId, OrderDetail OrderBreakDown)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet ds = new DataSet();
                string cmdText = "";
                if ((StatusId == 10) || (StatusId == 12) || (StatusId == 13) || (StatusId == 28) || (StatusId == 29))
                {
                    cmdText = "sp_get_next_eta_by_PCDate";
                }
                else
                {
                    cmdText = "sp_get_next_eta";
                }
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderBreakDown.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModeName", SqlDbType.VarChar);
                param.Value = OrderBreakDown.ModeName == null ? "" : OrderBreakDown.ModeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds, "Table");
                if (ds.Tables[0].Rows[0]["ETADate"].ToString() != "")
                {
                    return Convert.ToDateTime(ds.Tables[0].Rows[0]["ETADate"]);
                }
                else
                {
                    return Convert.ToDateTime("1/1/1900");
                }
            }
        }

        public DateTime GetNextTargetDateByWfId(int StatusId, int WfId, string modeName = "")
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet ds = new DataSet();
                string cmdText = "sp_get_next_eta_by_WfId";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@WfId", SqlDbType.Int);
                param.Value = WfId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModeName", SqlDbType.VarChar);
                param.Value = modeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds, "Table");
                return Convert.ToDateTime(ds.Tables[0].Rows[0]["ETADate"]);
            }
        }

        //public int GetNextTargetDays(int StatusId, OrderDetail OrderBreakDown)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        int orderDetailID = 0;
        //        string str = string.Empty;
        //        DataSet ds = new DataSet();
        //        string cmdText = "sp_get_next_eta";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlParameter param;
        //        param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
        //        if (OrderBreakDown != null)
        //        {
        //            orderDetailID = OrderBreakDown.OrderDetailID;
        //        }
        //        param.Value = orderDetailID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@StatusId", SqlDbType.Int);
        //        param.Value = StatusId;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        if (OrderBreakDown != null && OrderBreakDown.ModeName != null)
        //        {
        //            str = OrderBreakDown.ModeName;
        //        }
        //        param = new SqlParameter("@ModeName", SqlDbType.VarChar);
        //        param.Value = str;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        adapter.Fill(ds, "Table");
        //        return Convert.ToInt16(ds.Tables[0].Rows[0]["DaysDiff"]);
        //    }
        //}

        public List<WorkflowInstanceDetail> GetUserTasks(int UserID, int WFInstanceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_user_tasks_by_instance_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                //Edit by surendra on 10 jan 2013
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //end
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WFInstanceID", SqlDbType.Int);
                param.Value = WFInstanceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

                        instanceDetail.AssignedTo = new User();
                        instanceDetail.AssignedTo.UserID = (reader["AssignedTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AssignedTo"]);
                        instanceDetail.ActionDate = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                        instanceDetail.ActionID = (reader["StatusModeActionID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeActionID"]);
                        instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                        instanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                        instanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                        instanceDetail.SubPhase = (reader["SubPhase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SubPhase"]);
                        instanceDetail.Phase = (reader["Phase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Phase"]);
                        instanceDetail.Task = (reader["Task"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Task"]);
                        instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["WorkflowInstanceDetailID"]);

                        instanceDetail.WorkflowInstance = new WorkflowInstance();
                        instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                        instanceDetail.WorkflowInstance.Style = new Style();
                        instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instanceDetail.WorkflowInstance.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        instanceDetail.WorkflowInstance.Order = new Order();
                        instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instanceDetail.WorkflowInstance.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        instanceDetail.WorkflowInstance.Order.OrderBreakdown = new List<OrderDetail>();

                        instanceDetail.ApplicationModule = new ApplicationModule();
                        instanceDetail.ApplicationModule.Path = (reader["Path"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Path"]);
                        instanceDetail.ApplicationModule.ApplicationModuleName = (reader["ApplicationModuleName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ApplicationModuleName"]);
                        instanceDetail.ApplicationModule.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);

                        OrderDetail od = new OrderDetail();
                        instanceDetail.WorkflowInstance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                        od.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        od.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);

                        instanceDetail.WorkflowInstance.Order.OrderBreakdown.Add(od);

                        instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                        instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);

                        instanceDetails.Add(instanceDetail);
                    }
                }

                cnx.Close();

                return instanceDetails;
            }
        }

        public List<WorkflowInstanceDetail> GetUserStatusMeetingTasks(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_status_meeting_get_owner_tasks";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();
                        instanceDetail.ETA = DateTime.MinValue;
                        instanceDetail.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);
                        instanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                        instanceDetail.SubPhase = (reader["SubPhase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SubPhase"]);
                        instanceDetail.Phase = (reader["Phase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Phase"]);
                        instanceDetail.Task = string.Empty;
                        instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["WorkflowInstanceDetailID"]);

                        instanceDetail.WorkflowInstance = new WorkflowInstance();
                        instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                        instanceDetail.WorkflowInstance.Style = new Style();
                        instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instanceDetail.WorkflowInstance.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        instanceDetail.WorkflowInstance.Style.Buyer = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                        instanceDetail.WorkflowInstance.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        instanceDetail.WorkflowInstance.Style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());

                        instanceDetail.WorkflowInstance.Order = new Order();
                        instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instanceDetail.WorkflowInstance.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        instanceDetail.WorkflowInstance.Order.OrderBreakdown = new List<OrderDetail>();

                        instanceDetail.ApplicationModule = new ApplicationModule();
                        instanceDetail.ApplicationModule.Path = (reader["Path"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Path"]);
                        instanceDetail.ApplicationModule.ApplicationModuleName = (reader["ApplicationModuleName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ApplicationModuleName"]);
                        instanceDetail.ApplicationModule.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);

                        OrderDetail od = new OrderDetail();
                        instanceDetail.WorkflowInstance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                        od.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        od.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        od.Quantity = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);

                        if (od.OrderDetailID > -1 && reader["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(reader["CommentsSentFor"].ToString()))
                        {
                            bool isSTCApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);

                            if (isSTCApproved)
                            {
                                od.FitStatus = "STC Approved On " + ((reader["SealDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["SealDate"]).ToString("dd MMM yy (ddd)"));
                            }
                            else
                            {
                                DateTime AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                                string plannedFor = ((reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]));

                                if (plannedFor.IndexOf("STC") > -1)
                                    od.FitStatus = plannedFor + " Requested on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                                else if (AckDate == DateTime.MinValue)
                                    od.FitStatus = ((reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"])) + " Comment Received on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                                else
                                    od.FitStatus = plannedFor + " Sent on " + ((reader["AckDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["AckDate"]).ToString("dd MMM yy (ddd)"));
                            }
                        }

                        instanceDetail.WorkflowInstance.Order.OrderBreakdown.Add(od);

                        instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                        instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);
                        instanceDetails.Add(instanceDetail);
                    }
                }

                cnx.Close();
                return instanceDetails;
            }
        }

        public List<WorkflowInstanceDetail> GetCurrentPendingTasks(int SyleID, int OrderID, int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_current_pending_tasks";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SyleID", SqlDbType.Int);
                param.Value = SyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.VarChar);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

                        instanceDetail.AssignedTo = new User();
                        instanceDetail.AssignedTo.UserID = (reader["AssignedTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AssignedTo"]);
                        instanceDetail.ActionDate = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                        instanceDetail.ActionID = (reader["ActionID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ActionID"]);
                        instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                        instanceDetail.StatusModeID = Convert.ToInt32(reader["StatusModeID"]);
                        instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["WorkflowInstanceDetailID"]);
                        instanceDetail.AssignedToDesignation = (Designation)Convert.ToInt32(reader["DesignationID"]);

                        instanceDetail.WorkflowInstance = new WorkflowInstance();
                        instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                        instanceDetail.WorkflowInstance.Style = new Style();
                        instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instanceDetail.WorkflowInstance.Order = new Order();
                        instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                        instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                        // Add By Ravi kumar for current status on 12/9/2015
                        instanceDetail.WorkflowInstance.CurrentStatus.CurrentStatusID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);

                        instanceDetails.Add(instanceDetail);
                    }
                }

                cnx.Close();

                return instanceDetails;
            }
        }

        public List<WorkflowInstanceDetail> GetCurrentPendingTasks(int WFInstanceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_current_pending_tasks_by_instance_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@WFInstanceID", SqlDbType.Int);
                param.Value = WFInstanceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

                        instanceDetail.AssignedTo = new User();
                        instanceDetail.AssignedTo.UserID = (reader["AssignedTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AssignedTo"]);
                        instanceDetail.ActionID = (reader["StatusModeActionID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeActionID"]);
                        instanceDetail.ActionDate = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                        instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                        instanceDetail.StatusModeID = Convert.ToInt32(reader["StatusModeID"]);
                        instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["WorkflowInstanceDetailID"]);
                        instanceDetail.AssignedToDesignation = (Designation)Convert.ToInt32(reader["DesignationID"]);

                        instanceDetail.WorkflowInstance = new WorkflowInstance();
                        instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                        instanceDetail.WorkflowInstance.Style = new Style();
                        instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                        instanceDetail.WorkflowInstance.Order = new Order();
                        instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                        instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                        // Add By Ravi kumar for current status on 12/9/2015
                        instanceDetail.WorkflowInstance.CurrentStatus.CurrentStatusID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);

                        instanceDetail.ApplicationModule = new ApplicationModule();
                        instanceDetail.ApplicationModule.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);


                        instanceDetails.Add(instanceDetail);
                    }
                }

                cnx.Close();

                return instanceDetails;
            }
        }

        public bool ChangeStatusToOnHold(int OrderDetailID, string Remarks)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_change_status";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStatusId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Convert.ToInt32(TaskMode.ONHOLD);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Convert.ToInt32(WorkflowStatusActionID.OnHold);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Remarks;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        public bool ChangeStatusToPrevious(int OrderDetailID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_change_status_to_previous";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        public bool UpdateWorkflowInstanceDetailByOrderDetailID(int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_instance_detail_update_by_order_detail_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        public List<WorkflowInstanceDetail> GetWorkflowresolutionTasks(int UserID)   //  change in this method by dewasish
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_resolution_tasks";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

                instanceDetails = WorkflowtaskDal(reader);

                cnx.Close();

                return instanceDetails;
            }
        }


        public List<WorkflowInstanceDetail> UserTaskDal(SqlDataReader reader)
        {
            List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();
                    instanceDetail.AssignedTo = new User();

                    instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    instanceDetail.ExFactory = (reader["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ExFactory"]);
                    instanceDetail.OrderExfactory = (reader["ExFactory"] == DBNull.Value) ? "" : Convert.ToDateTime(reader["ExFactory"]).ToString("dd MMM (ddd)");
                    instanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                    instanceDetail.StatusMode = (reader["status_modename"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["status_modename"]);
                    instanceDetail.FactorySpecification = (reader["FactoryClassification"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FactoryClassification"]);
                    instanceDetail.UnitId = (reader["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UnitID"]);
                    instanceDetail.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                    if (instanceDetail.StatusModeID == 9444 || instanceDetail.StatusModeID==9445 || instanceDetail.StatusModeID==9446)//Added by shubhendu 04/07/2022 For smae functionality for 9444,9445,9446
                    {
                        instanceDetail.AgreeRate = (reader["AgreeRate"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AgreeRate"]);
                        instanceDetail.Supplier =instanceDetail.StatusModeID==9444? (reader["Supplier"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Supplier"]):instanceDetail.DepartmentName;
                        instanceDetail.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        instanceDetail.PO_Number = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);

                    }
                    //instanceDetail.PO_Number = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);


                    var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                    bool taskAvailable = columns.Any(s => s == "Task") ? true : false;
                    if (taskAvailable)
                    {
                        instanceDetail.Task = (reader["Task"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Task"]);
                    }

                    instanceDetail.BIPLPrice = (reader["BIPLPrice"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLPrice"]);
                    //instanceDetail.OrderDate = (reader["OrderDate"] == DBNull.Value) ? "" : Convert.ToDateTime(reader["OrderDate"]).ToString("dd MMM (ddd)");
                    instanceDetail.OrderDate = (reader["OrderDate"] == DBNull.Value) ? "" : Convert.ToDateTime(reader["OrderDate"]).ToString("dd MMM (ddd h tt)");
                    //abhishek on 17/8/2016
                    instanceDetail.ClinetCurrency = (reader["ClientCurrecy"] == DBNull.Value) ? "" : Convert.ToString(reader["ClientCurrecy"]);
                    // Added By surendra for Costing open narration
                    //commented by Shubhendu 25/12/2021
                    //instanceDetail.User_Narration = (reader["User_Narration"] == DBNull.Value) ? "" : Convert.ToString(reader["User_Narration"]);
                    // commented on 5 oct by RSB with discussion to ravik
                    //commented by Shubhendu 25/12/2021
                    //instanceDetail.CreateFabricTask = (reader["CreateFabricTask"] == DBNull.Value) ? "" : Convert.ToString(reader["CreateFabricTask"]);
                    //End of commented on 5 oct by RSB with discussion to ravik
                    if (instanceDetail.StatusModeID == 8004 || instanceDetail.StatusModeID == 8885)
                    {
                        instanceDetail.Fabric_QualityID = (reader["Fabric_QualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Fabric_QualityID"]);
                    }
                    //---------------------------------end

                    instanceDetail.LineitemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                    instanceDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);

                    instanceDetail.ConversionRate = (reader["ConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ConversionRate"]);
                    double Quantity = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);

                    double biplprice = instanceDetail.BIPLPrice == "" ? 0 : Convert.ToDouble(instanceDetail.BIPLPrice);

                    double BoutiqueP = ((biplprice * instanceDetail.ConversionRate * Quantity) / 100000);

                    instanceDetail.BoutiqueBussiness = Math.Round((BoutiqueP), 2, MidpointRounding.AwayFromZero);

                    instanceDetail.ValueInR = (reader["INR"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["INR"]);
                    //end abhishek

                    instanceDetail.WorkflowInstance = new WorkflowInstance();
                    instanceDetail.WorkflowInstance.Style = new Style();
                    instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                    instanceDetail.WorkflowInstance.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    instanceDetail.WorkflowInstance.Style.StyleNumberDesc = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    instanceDetail.WorkflowInstance.Style.Buyer = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                    instanceDetail.WorkflowInstance.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                    instanceDetail.WorkflowInstance.Style.ClientID = (reader["ClientID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ClientID"]);
                    instanceDetail.WorkflowInstance.Style.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DepartmentID"]);
                    instanceDetail.WorkflowInstance.Style.SamplingMerchandisingManagerName = (reader["SamplingMerchandisingManagerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingMerchandisingManagerName"]); //Mukhiya 29-03-2016

                    instanceDetail.WorkflowInstance.Order = new Order();
                    instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                    instanceDetail.WorkflowInstance.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                    instanceDetail.WorkflowInstance.Fit = new Fits();
                    instanceDetail.WorkflowInstance.Fit.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);

                    instanceDetail.WorkflowInstance.Order.OrderBreakdown = new List<OrderDetail>();
                    instanceDetail.ApplicationModule = new ApplicationModule();
                    instanceDetail.ApplicationModule.Path = (reader["RequestUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["RequestUrl"]);
                    instanceDetail.ApplicationModule.ApplicationModuleName = (reader["FormName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FormName"]);
                    // instanceDetail.ApplicationModule.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);
                    OrderDetail od = new OrderDetail();
                    instanceDetail.WorkflowInstance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);

                    od.Quantity = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);
                    instanceDetail.WorkflowInstance.Order.TotalQuantity = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);
                    instanceDetail.IsIkandiClient = (reader["IsIkandiClient"] == DBNull.Value) ? "0" : Convert.ToString(reader["IsIkandiClient"]);

                    instanceDetail.WorkflowInstance.Order.OrderBreakdown.Add(od);
                    instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                    instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);
                
                    if (ColumnExists(reader, "FinalText"))
                        instanceDetail.WorkflowInstance.CurrentStatus.FinalText = (reader["FinalText"] == DBNull.Value) ? "" : reader["FinalText"].ToString();

                    instanceDetails.Add(instanceDetail);

                }
            }
            return instanceDetails;
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        public bool CheckOrder_OrderDetail_From_Style(int styleid, int StatusId, int Userid, string status)
        {
            bool bcheck = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_CheckOrder_OrderDetail_From_Style";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.VarChar);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //if (reader["MrMathurCheckBox"] == "0")
                        //{
                        //    bcheck = false;
                        //}
                        //else
                        //{
                        //    bcheck = true;
                        //}

                        this.UpdateWorkflowInstancePostOrder_WithOutInstance(Convert.ToInt32(reader["OrderID"]), Convert.ToInt32(reader["OrderDetailID"]), StatusId, Userid);
                    }
                }

                cnx.Close();

                return bcheck;
            }

        }
        public List<WorkflowInstanceDetail> GetUserTaskDAL(int UserID, int TaskId, int MyTask)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "";
                if (TaskId != 9999)
                {
                    if (TaskId == 8 || TaskId == 9000)
                        cmdText = "Usp_Get_BIPL_Agreement_Task_For_Anu";
                    else if (TaskId == 66666 || TaskId == 55555)
                        cmdText = "GetTask_Detail_Complaince";
                    else if (TaskId == 8888 || TaskId == 8881 || TaskId == 8882 || TaskId == 8883)
                        cmdText = "Usp_Get_PatternReadyTask_For_Pre_PostOrder";
                    else if (TaskId == 7 || TaskId == 12003)
                        cmdText = "Usp_Get_Open_Costing_Task";
                    else if (TaskId == 9997)
                        cmdText = "Usp_Get_PL_Not_Equal_to_PQ";
                    else if (TaskId == 8884)
                        cmdText = "Usp_Get_CuttingIssue_To_Planning_Department";
                    else if (TaskId == 8886)
                        cmdText = "Usp_Get_AccIssue_To_Planning_Department";
                    else if (TaskId == 8885 || TaskId == 10000 || TaskId == 10001)
                        cmdText = "Usp_Get_CuttingIssue_To_Fabric_Department";
                    else if (TaskId == 7001)
                        cmdText = "Usp_Get_AccIssue_To_Fabric_Department";
                    else if (TaskId == 8887)
                        cmdText = "Usp_Get_Debit_Note_Task";
                    else if (TaskId == 7887)
                        cmdText = "Usp_Get_Acc_Debit_Note_Task";
                    else if (TaskId == 8891)
                        cmdText = "Usp_Get_Credit_Note_Task";
                    else if (TaskId == 7791)
                        cmdText = "Usp_Get_Acc_Credit_Note_Task";
                    else if (TaskId == 8898)
                        cmdText = "Usp_Get_PO_Cancel_With_Laibility";
                    else if (TaskId == 9111)
                        cmdText = "Usp_Get_ACC_PO_Cancel_With_Laibility";
                    else if (TaskId == 9888)
                        cmdText = "Usp_BIPL_Global_Daily_IE_Entry";
                    else if (TaskId == 6697)
                        cmdText = "USP_GET_Value_Added_Style";
                    else if (TaskId == 9876)
                        cmdText = "Usp_Get_OpenCosting";
                    else if (TaskId == 9444 || TaskId == 9445 || TaskId == 9446 || TaskId == 9447)
                        cmdText = "USP_GET_Value_Added_PO";
                    else if (TaskId == 6661 || TaskId == 6662 || TaskId == 6663 || TaskId == 6664 || TaskId == 6665)
                        cmdText = "Usp_Get_InspectionTask";
                    else if (TaskId == 6700 || TaskId == 6701 || TaskId == 6702 || TaskId == 6703 || TaskId == 6704)
                        cmdText = "Usp_Get_Fabric_InspectionTask";
                    //else if (TaskId == 12003)
                    //    cmdText = "Usp_Get_Open_OrderForm_Task";
                    else
                        cmdText = "GetTask_Detail_ByUser";

                }
                else
                {

                    cmdText = "GetTask_Detail_TailorLoad";

                }
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                if ((TaskId != 8887 && TaskId != 8891 && TaskId != 8898 && TaskId != 9111 && TaskId != 7887))
                {
                    SqlParameter param;
                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.Int);
                    param.Value = TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }


                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkflowInstanceDetail> instanceDetails = this.UserTaskDal(reader);


                cnx.Close();

                return instanceDetails;
            }
        }


        public List<WorkflowInstanceDetail> WorkflowtaskDal(SqlDataReader reader)
        {
            List<WorkflowInstanceDetail> instanceDetails = new List<WorkflowInstanceDetail>();


            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

                    instanceDetail.ETA = DateTime.MinValue; // (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    instanceDetail.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    instanceDetail.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);
                    instanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                    instanceDetail.SubPhase = (reader["SubPhase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SubPhase"]);
                    instanceDetail.Phase = (reader["Phase"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Phase"]);
                    instanceDetail.Task = string.Empty;  //(reader["Task"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Task"]);
                    instanceDetail.WorkflowInstanceDetailID = Convert.ToInt32(reader["WorkflowInstanceDetailID"]);

                    instanceDetail.UserTaskType = (reader["UserTaskType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UserTaskType"]); // Dewasish 

                    instanceDetail.WorkflowInstance = new WorkflowInstance();
                    instanceDetail.WorkflowInstance.WorkflowInstanceID = Convert.ToInt32(reader["WorkflowInstanceID"]);
                    instanceDetail.WorkflowInstance.Style = new Style();
                    instanceDetail.WorkflowInstance.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StyleID"]);
                    instanceDetail.WorkflowInstance.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    instanceDetail.WorkflowInstance.Style.Buyer = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                    instanceDetail.WorkflowInstance.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                    instanceDetail.WorkflowInstance.Style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());
                    instanceDetail.WorkflowInstance.Style.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]); //(reader["StyleNumber"] == DBNull.Value) ? "-1" : Convert.ToString((reader["StyleNumber"]).ToString().Substring(3, (reader["StyleNumber"]).ToString().Length));
                    instanceDetail.WorkflowInstance.Style.CourierSentOn = DateTime.MinValue;

                    instanceDetail.WorkflowInstance.Order = new Order();
                    instanceDetail.WorkflowInstance.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                    instanceDetail.WorkflowInstance.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

                    instanceDetail.WorkflowInstance.Fit = new Fits();
                    instanceDetail.WorkflowInstance.Fit.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);
                    instanceDetail.WorkflowInstance.Fit.StyleCodeVersion = (reader["StyleCodeVersion"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCodeVersion"]);

                    instanceDetail.WorkflowInstance.Order.OrderBreakdown = new List<OrderDetail>();

                    instanceDetail.ApplicationModule = new ApplicationModule();
                    instanceDetail.ApplicationModule.Path = (reader["Path"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Path"]);
                    instanceDetail.ApplicationModule.ApplicationModuleName = (reader["ApplicationModuleName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ApplicationModuleName"]);
                    instanceDetail.ApplicationModule.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);

                    OrderDetail od = new OrderDetail();
                    instanceDetail.WorkflowInstance.OrderDetailID = od.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                    od.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                    od.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                    od.Quantity = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);

                    if (od.OrderDetailID > -1 && reader["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(reader["CommentsSentFor"].ToString()))
                    {
                        bool isSTCApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);

                        if (isSTCApproved)
                        {
                            od.FitStatus = "STC Approved On " + ((reader["SealDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["SealDate"]).ToString("dd MMM yy (ddd)"));
                        }
                        else
                        {
                            DateTime AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                            string plannedFor = ((reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]));

                            if (plannedFor.IndexOf("STC") > -1)
                                od.FitStatus = plannedFor + " Requested on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else if (AckDate == DateTime.MinValue)
                                od.FitStatus = ((reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"])) + " Comment Received on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else
                                od.FitStatus = plannedFor + " Sent on " + ((reader["AckDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["AckDate"]).ToString("dd MMM yy (ddd)"));
                        }
                    }

                    instanceDetail.WorkflowInstance.Order.OrderBreakdown.Add(od);

                    instanceDetail.WorkflowInstance.CurrentStatus = new WorkflowInstanceDetail();
                    instanceDetail.WorkflowInstance.CurrentStatus.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CurrentStatusID"]);

                    instanceDetails.Add(instanceDetail);
                }
            }
            return instanceDetails;
        }

        public List<WorkflowInstanceDetail> GetWorkflowresolutionTasksByTaskId(int UserID, int TaskModeId)   //  change in this method by dewasish
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_workflow_get_resolution_tasks_By_TaskModeId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskModeId", SqlDbType.Int);
                param.Value = TaskModeId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkflowInstanceDetail> instanceDetails = null;
                instanceDetails = WorkflowtaskDal(reader);
                cnx.Close();
                return instanceDetails;
            }
        }
        // Add By Ravi kumar on 24/12/2014 fro Acknowledgment
        public bool Update_userTaskFor_Acknowledgment(int Type, int StyleId, int OrderId, DateTime ActionDate, int ActionBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "usp_Update_userTaskFor_Acknowledgment";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                param.Value = ActionDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionBy", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ActionBy;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }
        // End By Ravi kumar on 24/12/2014 fro Acknowledgment

        // update By Ravi kumar on 12/08/2015 create task for OB and Risk
        public bool CreateTask_For_OB_Risk(string Type, int StyleId, int OrderId, int Userid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_CreateTask_For_OB_Risk";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Userid;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
        }
        // update by uday 1/11/2016
        public bool InsertDelayForMO(string SessionId, int StatusId, int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "NotficationDelay_Ins";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = 1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = SessionId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StatusId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = UserID;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }
        public string InsertDelayCountForMO(string SessionId, int Check)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string Result = "";
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Insert_MOCount";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;



                param = new SqlParameter("@SessionId", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = SessionId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Check", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Check;
                cmd.Parameters.Add(param);

                Result = Convert.ToString(cmd.ExecuteScalar());

                cnx.Close();

                return Result;
            }
        }

        public string GetDelayOrderDetailIds(string SessionId)
        {
            string Result = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "NotficationDelay_Ins";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = 2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = SessionId;
                cmd.Parameters.Add(param);

                Result = Convert.ToString(cmd.ExecuteScalar());

                cnx.Close();

                return Result;
            }
        }





        // update by Ravi kumar for OB and Risk task ON 12/8/2015
        public bool Update_userTaskFor_OB_Risk(string Flag, int Type, int StyleId, int OrderId, DateTime ActionDate, int ActionBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "usp_Update_userTaskFor_OB_Risk";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Flag;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                param.Value = ActionDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionBy", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ActionBy;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }
        // update by Ravi kumar for OB and Risk task ON 31/7/2015
        public string IsOBRiskDone(int StyleId, int OrderId, string Flag)
        {
            string OBRisk = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "usp_IsOBRiskDone";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Styelid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();

                cnx.Close();

                if (result != null)
                {
                    OBRisk = result.ToString();
                }

                return OBRisk;
            }

        }

        public int IsFinalOBDone(int StyleId, int StatusId, string Flag)
        {
            int IsFinalOB = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "usp_FinalOBDone";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Styelid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();

                cnx.Close();

                if (result != null)
                {
                    IsFinalOB = Convert.ToInt32(result);
                }

                return IsFinalOB;
            }

        }

        public int WorkflowTask_OB_Risk(int StyleId, int OrderId, string Flag)
        {
            //string OBRisk = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "usp_WorkflowTask_OB_Risk";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int i = cmd.ExecuteNonQuery();

                cnx.Close();


                return i;
            }

        }
        // End By Ravi kumar on 28/07/2015 create task for OB and Risk

        // Create by Ravi kumar on 12/09/2015 for Current status.
        public int Workflow_get_current_Status(int StyleId, int OrderId, int OrderDetailId)
        {
            int CurrentStatus = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_workflow_get_current_Status";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();

                cnx.Close();

                if (result != null)
                {
                    CurrentStatus = Convert.ToInt32(result);
                }
                cnx.Close();


                return CurrentStatus;
            }

        }
        // Create by Ravi kumar on 10/03/2016 for Inline cut.
        public int UpdateInlineCut_PostOrder(WorkflowInstance WFInstance)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateInlineCut_PostOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = WFInstance.Order.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = WFInstance.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusId", SqlDbType.Int);
                param.Value = WFInstance.CurrentStatus.StatusModeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                param.Value = WFInstance.AssignedTo.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        // Add By Ravi kumar for close Acknowledge Costing
        public int Close_AcknowledgeTask(int StyleId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "Usp_Close_AcknowledgeTask";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;


                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusId", SqlDbType.Int);
                    param.Value = StatusId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Result = cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();

                }
            }

            return Result;

        }

        // Add By Ravi kumar for close Acknowledge Fabric
        public int Close_AcknowledgeFabric(int OrderId, int StatusId, int UserId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "Usp_Close_AcknowledgeFabric";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;


                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusId", SqlDbType.Int);
                    param.Value = StatusId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AssignedTo", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Result = cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();

                }
            }

            return Result;

        }
        //added by abhishek on 14/7/2017
        public DataTable GetClients_DelayTaskCount_TopApprovalPending(int ClientId, int StatusModeId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_GetFitsReport_TopSummary_WithDealyPercent";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    //param = new SqlParameter("@inType", SqlDbType.Int);
                    //param.Value = 3;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ClientId", SqlDbType.Int);
                    //param.Value = ClientId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StatusModeId", SqlDbType.Int);
                    //param.Value = StatusModeId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "TOPSUMMARY";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserIDS", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public bool bCheck_AllCondition_CreateFabric(int OrderDetailID, int OrderID, string Accesories_Check)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "USP_GetCheckCreateFabric";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExistFabric = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Check_Task", SqlDbType.VarChar);
                    param.Value = Accesories_Check;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExistFabric);
                    int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["CheckCreateFabric"]);
                    if (a == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //END
    }
}
