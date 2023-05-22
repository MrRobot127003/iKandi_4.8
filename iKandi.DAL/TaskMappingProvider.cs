using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.DAL
{
    public class TaskMappingProvider : BaseDataProvider
    {


        #region Ctor(s)
        public TaskMappingProvider()
        {
        }

        public TaskMappingProvider(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        #endregion



        /// <summary>
        /// yaten : For Getting ALL Data from any Table
        /// </summary>
        /// <param name="stringTableName"></param>
        /// <param name="stringColNames"></param>
        /// <param name="strWhereCol"></param>
        /// <param name="strWhereCondition"></param>
        /// <returns></returns>
        public DataSet GetALLDeptForTaskMappingDAL(string stringTableName, string stringColNames, string strWhereCol, string strWhereCondition, string strOperator)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //
                SqlCommand cmd;
                string cmdText;
                cmdText = "Get_Data_From_Given_Table";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                //tableName VARCHAR(45),ColName VARCHAR(1000),IsClouse VARCHAR(100),IsClouseValue
                param = new SqlParameter("tableName", SqlDbType.VarChar);
                param.Value = stringTableName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("ColName", SqlDbType.VarChar);
                param.Value = stringColNames;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sClouse", SqlDbType.VarChar);
                param.Value = strWhereCol;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sClouseValue", SqlDbType.VarChar);
                param.Value = strWhereCondition;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Operator", SqlDbType.VarChar);
                param.Value = strOperator;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }
        }



        public DataSet GetALLDeptDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //
                SqlCommand cmd;
                string cmdText;
                cmdText = "Get_All_Dept";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }
        }









        public DataSet GetTaskMappingBAL(int intDeprtId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "GetTaskByDept";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = intDeprtId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);





                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }
        }


        public DataSet GetLineMgrMappingDAL(int intDesgId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "GetLineMgrsByDesgDynamic";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DesId", SqlDbType.Int);
                param.Value = intDesgId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);





                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                try
                {
                    adapter.Fill(ds);
                }
                catch
                {
                    GetLineMgrMappingDAL(intDesgId);
                }
                cnx.Close();
                return ds;
            }
        }






        public DataSet UpdateMgrDAL(int intTaskId, int intDesgId, int MgrId, int MgeLevel, int IsAssociate, int TaskWiseDesgId, int DeptId, string Str_TaskName, string Str_Purpose, int int_OldDEsignationID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "UpdateManegerLevels";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TaskId", SqlDbType.Int);
                param.Value = intTaskId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesId", SqlDbType.Int);
                param.Value = intDesgId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MgrId", SqlDbType.Int);
                param.Value = MgrId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MgrLevel", SqlDbType.Int);
                param.Value = MgeLevel;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sAssociate", SqlDbType.Int);
                param.Value = IsAssociate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskWiseDesgId", SqlDbType.Int);
                param.Value = TaskWiseDesgId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskName", SqlDbType.VarChar);
                param.Value = Str_TaskName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Purpose", SqlDbType.VarChar);
                param.Value = Str_Purpose;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OldDEsignationID", SqlDbType.Int);
                param.Value = int_OldDEsignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }
        }







    }
}


