using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class UserTaskDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public UserTaskDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public int InsertUserTask(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_user_tasks_insert";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@D", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@ETA", SqlDbType.DateTime);
                    if ((Task.ETA == DateTime.MinValue) || (Task.ETA == Convert.ToDateTime("1753-01-01")) || (Task.ETA == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Task.ETA;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    if (Task.Style == null || Task.Style.StyleID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.Style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    if (Task.Order == null || Task.Order.OrderID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.Order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    if (Task.OrderDetail == null || Task.OrderDetail.OrderDetailID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField1", SqlDbType.Int);
                    param.Value = Task.IntField1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField2", SqlDbType.Int);
                    param.Value = Task.IntField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField3", SqlDbType.Int);
                    param.Value = Task.IntField3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField1", SqlDbType.VarChar);
                    param.Value = Task.TextField1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField2", SqlDbType.VarChar);
                    param.Value = Task.TextField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AssignedToDesignation", SqlDbType.Int);
                    param.Value = Task.AssignedToDesigntation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = Task.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                    if ((Task.CreatedOn == DateTime.MinValue) || (Task.CreatedOn == Convert.ToDateTime("1753-01-01")) || (Task.CreatedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Task.CreatedOn;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = (int)Task.Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);                  


                    param = new SqlParameter("@_estBihDate", SqlDbType.DateTime);
                    if ((Task._estBihDate == DateTime.MinValue) || (Task._estBihDate == Convert.ToDateTime("1753-01-01")) || (Task._estBihDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Task._estBihDate;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@_BulkTarge", SqlDbType.DateTime);
                    if ((Task._BulkTarget == DateTime.MinValue) || (Task._BulkTarget == Convert.ToDateTime("1753-01-01")) || (Task._BulkTarget == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Task._BulkTarget;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    int taskID = Convert.ToInt32(outParam.Value);

                    transaction.Commit();

                    return taskID;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }

            return -1;
        }



        public void UpdateUserTask(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_user_tasks_update_by_Id";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@D", SqlDbType.Int);
                    param.Value = Task.ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ActionedBy", SqlDbType.Int);
                    param.Value = Task.ActionedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                    param.Value = Task.ActionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public void UpdateCostingUserTask(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_user_tasks_update_costing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = Task.Style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionedBy", SqlDbType.Int);
                    param.Value = Task.ActionedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                    if ((Task.ActionDate == DateTime.MinValue) || (Task.ActionDate == Convert.ToDateTime("1753-01-01")) || (Task.ActionDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Task.ActionDate;
                    }                    
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AssignedToDesignation", SqlDbType.Int);
                    param.Value = Task.AssignedToDesigntation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField3", SqlDbType.Int);
                    param.Value = Task.IntField3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField2", SqlDbType.VarChar);
                    param.Value = Task.TextField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public int InsertUserTaskShipment(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_shipment_user_tasks_insert";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@D", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@ETA", SqlDbType.DateTime);
                    param.Value = Task.ETA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    if (Task.Style == null || Task.Style.StyleID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.Style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    if (Task.Order == null || Task.Order.OrderID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.Order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    if (Task.OrderDetail == null || Task.OrderDetail.OrderDetailID == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Task.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField1", SqlDbType.Int);
                    param.Value = Task.IntField1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField2", SqlDbType.Int);
                    param.Value = Task.IntField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField3", SqlDbType.Int);
                    param.Value = Task.IntField3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField1", SqlDbType.VarChar);
                    param.Value = Task.TextField1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField2", SqlDbType.VarChar);
                    param.Value = Task.TextField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AssignedToDesignation", SqlDbType.Int);
                    param.Value = Task.AssignedToDesigntation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = Task.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                    param.Value = Task.CreatedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = (int)Task.Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    int taskID = Convert.ToInt32(outParam.Value);

                    transaction.Commit();

                    return taskID;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }

            return -1;
        }

        public void UpdateUserTaskShipment(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_shipment_user_tasks_update";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = Task.Style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = Task.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ActionedBy", SqlDbType.Int);
                    param.Value = Task.ActionedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                    param.Value = Task.ActionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public void UpdateUserTaskForCostingAction(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_user_tasks_update_by_Id_for_costing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@D", SqlDbType.Int);
                    param.Value = Task.ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ActionedBy", SqlDbType.Int);
                    param.Value = Task.ActionedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
                    param.Value = Task.ActionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ntField3", SqlDbType.Int);
                    param.Value = Task.IntField3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TextField2", SqlDbType.VarChar);
                    param.Value = Task.TextField2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public void UpdateUserTaskETA(UserTask Task)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_user_tasks_update_eta_by_Id";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@D", SqlDbType.Int);
                    param.Value = Task.ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ETA", SqlDbType.DateTime);
                    param.Value = Task.ETA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public List<UserTask> GetAllOtherTasks(int taskModeId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_user_By_TaskModeId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                List<UserTask> tasks = new List<UserTask>();

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskModeId", SqlDbType.Int);
                param.Value = taskModeId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserTask task = new UserTask();

                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.Type = (reader["Type"] == DBNull.Value) ? (UserTaskType)(-1) : (UserTaskType)Convert.ToInt32(reader["Type"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    task.Style.Buyer = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                    task.Style.Status = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                    task.Style.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CurrentStatusID"]);
                    task.Style.StyleCode = (reader["StyleNumber"] == DBNull.Value) ? "-1" : Constants.ExtractStyleCode((reader["StyleNumber"]).ToString());
                    //task.Style.sCodeVersion = (reader["StyleCodeVersion"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCodeVersion"]);
                    
                    task.Style.CourierSentOn = DateTime.MinValue;
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.OrderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                    
                    task.Fit = new Fits();
                    task.Fit.StyleCode = task.Style.StyleCode;

                    if (task.OrderDetail.OrderDetailID > -1 && reader["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(reader["CommentsSentFor"].ToString()))
                    {
                        bool isSTCApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);

                        if (isSTCApproved)
                        {
                            task.OrderDetail.FitStatus = "STC Approved On " + ((reader["SealDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["SealDate"]).ToString("dd MMM yy (ddd)"));
                        }
                        else
                        {
                            DateTime AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                            string plannedFor = ((reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]));

                            if (plannedFor.IndexOf("STC") > -1)
                                task.OrderDetail.FitStatus = plannedFor + " Requested on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else if (AckDate == DateTime.MinValue)
                                task.OrderDetail.FitStatus = ((reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"])) + " Comment Received on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else
                                task.OrderDetail.FitStatus = plannedFor + " Sent on " + ((reader["AckDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["AckDate"]).ToString("dd MMM yy (ddd)"));
                        }
                    }

                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                    task.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                    task.Order.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["ClientID"]);
                    // Add By Ravi kumar on 28/07/2015 create task for OB and Risk
                    task.Order.DeptID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["DepartmentID"]);
                    task.OrderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);
                    task.IntField1 = (reader["IntField1"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["IntField1"]);
                    tasks.Add(task);
                }

                cnx.Close();

                return tasks;
            }
        }

        public List<UserTask> GetAllUserTasks(int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_user";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                List<UserTask> tasks = new List<UserTask>();

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserTask task = new UserTask();

                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.Type = (reader["Type"] == DBNull.Value) ? (UserTaskType)(-1) : (UserTaskType)Convert.ToInt32(reader["Type"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    task.Style.Buyer = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                    task.Style.Status = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                    task.Style.StatusModeID = (reader["CurrentStatusID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CurrentStatusID"]);
                    task.Style.StyleCode = (reader["StyleNumber"] == DBNull.Value) ? "-1" : Constants.ExtractStyleCode((reader["StyleNumber"]).ToString());
                    task.Style.CourierSentOn = DateTime.MinValue;
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.OrderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                    task.Fit = new Fits();
                    task.Fit.StyleCode = task.Style.StyleCode;

                    if (task.OrderDetail.OrderDetailID > -1 && reader["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(reader["CommentsSentFor"].ToString()))
                    {
                        bool isSTCApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);

                        if (isSTCApproved)
                        {
                            task.OrderDetail.FitStatus = "STC Approved On " + ((reader["SealDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["SealDate"]).ToString("dd MMM yy (ddd)"));
                        }
                        else
                        {
                            DateTime AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                            string plannedFor = ((reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]));

                            if (plannedFor.IndexOf("STC") > -1)
                                task.OrderDetail.FitStatus = plannedFor + " Requested on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else if (AckDate == DateTime.MinValue)
                                task.OrderDetail.FitStatus = ((reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"])) + " Comment Received on " + ((reader["FitRequestedOn"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["FitRequestedOn"]).ToString("dd MMM yy (ddd)"));
                            else
                                task.OrderDetail.FitStatus = plannedFor + " Sent on " + ((reader["AckDate"] == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(reader["AckDate"]).ToString("dd MMM yy (ddd)"));
                        }
                    }

                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                    task.Order.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                    task.Order.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["ClientID"]);
                    task.OrderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["Quantity"]);
                    task.IntField1 = (reader["IntField1"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["IntField1"]);
                    tasks.Add(task);
                }

                cnx.Close();

                return tasks;
            }
        }

        public DataTable GetAllUserReminderTasks(int iUserID)
        {//manisha 1 march 2011
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Sp_User_Task_Get_Reminder_Tasks";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                List<UserTask> tasks = new List<UserTask>();
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsUser = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsUser);

                DataTable dt = dsUser.Tables[0];
                
                cnx.Close();

                return dt;
            }
        }


        public UserTask GetUserTasksByStyleID(int StyleID, UserTaskType Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_style_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = (int)Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                UserTask task = new UserTask();

                if (reader.Read())
                {
                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.TextField2 = (reader["TextField2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TextField2"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                    task.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    task.CreatedByUsername = (reader["CreatedByUsername"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreatedByUsername"]);
                }

                cnx.Close();

                return task;
            }
        }

        public UserTask GetUserCompletedTasksByStyleID(int StyleID, UserTaskType Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_completed_task_by_style_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = (int)Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                UserTask task = new UserTask();

                if (reader.Read())
                {
                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.IntField3 = (reader["IntField3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IntField3"]);
                    task.TextField2 = (reader["TextField2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TextField2"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                    task.ActionDate = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                    task.ActionedByUsername = (reader["ActionedByUsername"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ActionedByUsername"]);
                }

                cnx.Close();

                return task;
            }
        }

        public UserTask GetUserTasksByOrderID(int OrderID, UserTaskType Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_order_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = (int)Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                UserTask task = new UserTask();

                if (reader.Read())
                {
                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                }

                cnx.Close();

                return task;
            }
        }


        public UserTask GetUserTasksByOrderDetailID(int OrderDetailID, UserTaskType Type, int DesignationID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_order_detail_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = (int)Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                UserTask task = new UserTask();

                if (reader.Read())
                {
                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                }

                cnx.Close();

                return task;
            }
        }


        public UserTask GetUserTasksByLiabilityID(int LiabilityID, UserTaskType Type, int DesignationID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_liability_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@LiabilityID", SqlDbType.Int);
                param.Value = LiabilityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = (int)Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                UserTask task = new UserTask();

                if (reader.Read())
                {
                    task.ID = Convert.ToInt32(reader["ID"]);
                    task.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    task.Style = new Style();
                    task.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                    task.OrderDetail = new OrderDetail();
                    task.OrderDetail.OrderDetailID = (reader["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderDetailID"]);
                    task.Order = new Order();
                    task.Order.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["OrderID"]);
                    task.IntField1 = (reader["IntField1"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["IntField1"]);
                }
                cnx.Close();
                return task;
            }
        }

        public ListUserTask GetUserTasksCount()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
               

               // string cmdText = "sp_get_tasks_count";
                //For scheduler proc below is without scheduler proc
                // Gajendra Task List 13-01-2016
               // string cmdText = "sp_get_tasks_count_user";
                string cmdText = "GetTask_Count_ByUser"; 
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
             
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                ListUserTask lut=new ListUserTask();
                UserTaskCount utc;
                while (reader.Read())
                {
                    utc=new UserTaskCount();
                    utc.Task_Count = (reader["Task_Count"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Count"]);
                    utc.Task_Name = (reader["Task_Name"] == DBNull.Value) ? "" : Convert.ToString(reader["Task_Name"]).Replace("Sample Sent", "Sample to be Sent");
                    utc.TaskId = (reader["Task_Mode_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Mode_Id"]);
                    utc.Description = (reader["Description"] == DBNull.Value) ? "" : Convert.ToString(reader["Description"]);
                    lut.Add(utc);
                }
                reader.Close();
                cnx.Close();
               // utc = GetReminderTasksCount();
               // if(utc!=null && utc.Task_Count>0 && utc.TaskId>0)
               //     lut.Add(utc);
               // ListUserTask lut1 = GetOtherTasksCount();
               // if (lut1.Count > 0)
               //     lut.AddRange(lut1);
               //lut1 = GetStatusMeetingTasksCount();
               // if (lut1.Count > 0)
               //    lut.AddRange(lut1);   
                return GetUniqueUserTasks(lut);
            }
        }

        public ListUserTask GetUniqueUserTasks(ListUserTask lut)
        {
            ListUserTask tlut=new ListUserTask();
            UserTaskCount utc;
            var taskmodeids = (from r in lut select r.TaskId).Distinct().ToList();
            foreach (var i in taskmodeids)
            {
                utc = new UserTaskCount();
                utc.TaskId = i;
                var taskname = (from r in lut where r.TaskId == i select r.Task_Name).ToList()[0];
                utc.Task_Name = taskname;
                var description = (from r in lut where r.TaskId == i select r.Description).ToList()[0];
                utc.Description = description;
                var count = (from r in lut where r.TaskId == i select r.Task_Count).Sum();
                utc.Task_Count = count;
                tlut.Add(utc);
            }
            return tlut;
        }

        public ListUserTask GetStatusMeetingTasksCount()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

               // string cmdText = "sp_workflow_get_resolution_tasks_Count";
                //For scheduler proc below is without scheduler proc
                string cmdText = "sp_workflow_get_resolution_tasks_Count_User";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //Edit by surendra on 10 jan 2013
              
                //end
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                UserTaskCount utc = null;
                ListUserTask tlut = new ListUserTask();
                while (reader.Read())
                {
                    utc = new UserTaskCount();
                    utc.Task_Count = (reader["Task_Count"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Count"]);
                    utc.Task_Name = (reader["Task_Name"] == DBNull.Value) ? "" : Convert.ToString(reader["Task_Name"]);
                    utc.TaskId = (reader["Task_Mode_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Mode_Id"]);
                    utc.Description = (reader["Description"] == DBNull.Value) ? "" : Convert.ToString(reader["Description"]);
                    tlut.Add(utc);
                }
                reader.Close();
                cnx.Close();
                return tlut;
            }
        }

        public UserTaskCount GetReminderTasksCount()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Sp_User_Task_Get_Reminder_Tasks_Count";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                UserTaskCount utc = null;
                if (reader.Read())
                {
                    utc = new UserTaskCount();
                    utc.Task_Count = (reader["Task_Count"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Count"]);
                    utc.Task_Name = (reader["Task_Name"] == DBNull.Value) ? "" : Convert.ToString(reader["Task_Name"]);
                    utc.TaskId = (reader["Task_Mode_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Mode_Id"]);
                    utc.Description = (reader["Description"] == DBNull.Value) ? "" : Convert.ToString(reader["Description"]);
                }
                reader.Close();
                cnx.Close();
                return utc;
            }
        }

        public ListUserTask GetOtherTasksCount()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_user_tasks_get_task_by_user_count";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                ListUserTask lut=new ListUserTask();
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    UserTaskCount utc = new UserTaskCount();
                    utc.Task_Count = (reader["Task_Count"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Count"]);
                    utc.Task_Name = (reader["Task_Name"] == DBNull.Value) ? "" : Convert.ToString(reader["Task_Name"]);
                    utc.TaskId = (reader["Task_Mode_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Task_Mode_Id"]);
                    utc.Description = (reader["Description"] == DBNull.Value) ? "" : Convert.ToString(reader["Description"]);
                    lut.Add(utc);
                }
                reader.Close();
                cnx.Close();
                return lut;
            }
        }

        public ListTeamTask GetTeamTasksCount()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "sp_get_team_tasks_count";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
              
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsUser = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsUser);

                    if (dsUser.Tables.Count < 1)
                        return null;

                    DataTable dt = dsUser.Tables[0];

                    ListTeamTask listTeamTask = new ListTeamTask();

                    var departments =
                        (dt.AsEnumerable().Select(names => names.Field<string>("DepartmentName"))).Distinct();

                    foreach (var department in departments)
                    {
                        TeamTaskCount teamTaskCount = new TeamTaskCount();
                        teamTaskCount.Dept_Name = department;
                        string department1 = department;
                        long totCount =
                            (dt.AsEnumerable().Where(a => Convert.ToString(a["DepartmentName"]) == department1).Select(
                                names => names.Field<Int64>("Task_Count"))).ToList().Sum(dr => dr);
                        teamTaskCount.Task_Count = (int) totCount;
                        var tasks =
                            (dt.AsEnumerable().Where(a => Convert.ToString(a["DepartmentName"]) == department1).Select(
                                names => names));
                        ListUserTask lut = new ListUserTask();
                        foreach (var dataRow in tasks)
                        {
                            UserTaskCount utc = new UserTaskCount();
                            utc.Task_Designation = dataRow["Designation_Name"] == DBNull.Value
                                                       ? ""
                                                       : Convert.ToString(dataRow["Designation_Name"]);
                            utc.Task_Name = dataRow["Task_Name"] == DBNull.Value
                                                ? ""
                                                : Convert.ToString(dataRow["Task_Name"]);
                            utc.Task_Count = dataRow["Task_Count"] == DBNull.Value
                                                 ? 0
                                                 : Convert.ToInt32(dataRow["Task_Count"]);
                            utc.TaskId = dataRow["Task_Mode_Id"] == DBNull.Value
                                             ? 0
                                             : Convert.ToInt32(dataRow["Task_Mode_Id"]);
                            utc.Description = dataRow["Description"] == DBNull.Value
                                             ? ""
                                             : Convert.ToString(dataRow["Description"]);
                            lut.Add(utc);
                        }
                        teamTaskCount.ListUtc = lut;
                        listTeamTask.Add(teamTaskCount);
                    }

                    cnx.Close();

                    return listTeamTask;
                }
            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return null;
            }
        }

        // Add By Ravi kumar on 10-1-15 for Production Task

        public DataTable GetAllProductionTask(int iUserID, int TaskModeId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_get_Production_task_by_user_TaskModeId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                List<UserTask> tasks = new List<UserTask>();
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskModeId", SqlDbType.Int);
                param.Value = TaskModeId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsUser = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsUser);

                DataTable dt = dsUser.Tables[0];

                cnx.Close();

                return dt;
            }
        }
    }
}
