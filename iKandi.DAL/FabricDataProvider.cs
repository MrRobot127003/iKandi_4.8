using System;
using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using System.Data.SqlClient;
using iKandi.Common.Entities;
using System.Reflection;


namespace iKandi.DAL
{
    public class FabricDataProvider : BaseDataProvider
    {
        #region Ctor(s)
        public FabricDataProvider()
        {

        }

        public FabricDataProvider(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        #endregion

        //Grade Admin Block

        #region GetGradeAdmin
        public List<GradeAdmin> GetGradeAdmin(int tableId, int id)
        {
            List<GradeAdmin> lst = new List<GradeAdmin>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetGradeAdmin";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Table", SqlDbType.Int);
                param.Value = tableId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                DataTable FabricQualityTable = dsFabricQuality.Tables[0];

                foreach (DataRow rows in FabricQualityTable.Rows)
                {
                    GradeAdmin fpc = new GradeAdmin();
                    fpc.Id = rows["Grade_Admin_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Grade_Admin_Id"]);
                    fpc.Grade = rows["Grade"] == DBNull.Value ? "" : Convert.ToString(rows["Grade"]);
                    fpc.MinPerc = rows["MinPerc"] == DBNull.Value ? 0 : Convert.ToInt32(rows["MinPerc"]);
                    fpc.MaxPerc = rows["MaxPerc"] == DBNull.Value ? "" : Convert.ToString(rows["MaxPerc"]);
                    fpc.DR = rows["DR"] == DBNull.Value ? 0 : Convert.ToInt32(rows["DR"]);
                    fpc.Percentage = rows["Percentage"] == DBNull.Value ? "" : Convert.ToString(rows["Percentage"]);
                    lst.Add(fpc);
                }
                return lst;
            }
        }
        #endregion

        #region Insert_UpdateGradeAdmin
        public int Insert_UpdateGradeAdmin(GradeAdmin gradeAdmin)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_Insert_UpdateGradeAdmin";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Grade", SqlDbType.VarChar);
                param.Value = gradeAdmin.Grade;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@MinPerc", SqlDbType.Int);
                param.Value = gradeAdmin.MinPerc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@MaxPerc", SqlDbType.VarChar);
                param.Value = gradeAdmin.MaxPerc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@U", SqlDbType.Int);
                param.Value = gradeAdmin.IU;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = gradeAdmin.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TableId", SqlDbType.Int);
                param.Value = gradeAdmin.DR;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int status = 0;
                SqlParameter outparam = new SqlParameter("@Status", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam);
                cmd.ExecuteNonQuery();
                if (outparam.Value != DBNull.Value)
                    status = Convert.ToInt32(outparam.Value);
                return status;
            }
        }
        #endregion

        #region DeleteGradeAdmin
        public void DeleteGradeAdmin(int id, int tableId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_DeleteGradeAdmin";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TableId", SqlDbType.Int);
                param.Value = tableId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        //FA For Cutting Block

        #region GetFAForCutting
        public List<FACutting> GetFAForCutting(int id)
        {
            List<FACutting> lst = new List<FACutting>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetFACutting";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                DataTable FabricQualityTable = dsFabricQuality.Tables[0];

                foreach (DataRow rows in FabricQualityTable.Rows)
                {
                    FACutting fpc = new FACutting();
                    fpc.Id = rows["FACutting_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FACutting_Id"]);
                    fpc.UnitFrom = rows["UnitFrom"] == DBNull.Value ? 0 : Convert.ToInt32(rows["UnitFrom"]);
                    fpc.UnitTo = rows["UnitTo"] == DBNull.Value ? 0 : Convert.ToInt32(rows["UnitTo"]);
                    fpc.Perc = rows["Perc"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Perc"]);
                    fpc.Units = rows["Units"] == DBNull.Value ? "" : Convert.ToString(rows["Units"]);
                    lst.Add(fpc);
                }
                return lst;
            }
        }
        #endregion

        #region Insert_UpdateFACutting
        public int Insert_UpdateFACutting(FACutting faCutting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_Insert_UpdateFACutting";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UnitFrom", SqlDbType.Int);
                param.Value = faCutting.UnitFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@UnitTo", SqlDbType.Int);
                param.Value = faCutting.UnitTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Perc", SqlDbType.VarChar);
                param.Value = faCutting.Perc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@U", SqlDbType.Int);
                param.Value = faCutting.IU;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = faCutting.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int status = 0;
                SqlParameter outparam = new SqlParameter("@Status", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam);
                cmd.ExecuteNonQuery();
                if (outparam.Value != DBNull.Value)
                    status = Convert.ToInt32(outparam.Value);
                return status;
            }
        }
        #endregion

        #region DeleteFACutting
        public void DeleteFACutting(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_DeleteFACutting";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        //PoType

        #region GetPo_Type
        public List<Po_Type> GetPo_Type(int id, int requiredAdmin)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetPoType";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@sRequiredInAdmin", SqlDbType.Int);
                param.Value = requiredAdmin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetPosFromTable(dsFabricQuality.Tables[0]);
            }
        }

        public List<Po_Type> GetPosFromTable(DataTable dt)
        {
            List<Po_Type> lst = new List<Po_Type>();
            foreach (DataRow rows in dt.Rows)
            {
                Po_Type fpc = new Po_Type();
                fpc.Id = rows["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PoId"]);
                fpc.PoType = rows["PoType"] == DBNull.Value ? "" : Convert.ToString(rows["PoType"]);
                fpc.Description = rows["Discription"] == DBNull.Value ? "" : Convert.ToString(rows["Discription"]);
                lst.Add(fpc);
            }
            return lst;
        }
        #endregion

        //Process
        #region GetProcess
        public List<ProcessAdmin> GetProcess(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetProcess";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetProcessFromTable(dsFabricQuality.Tables[0]);
            }
        }

        public List<ProcessAdmin> GetProcessFromTable(DataTable dt)
        {
            List<ProcessAdmin> lst = new List<ProcessAdmin>();
            foreach (DataRow rows in dt.Rows)
            {
                ProcessAdmin fpc = new ProcessAdmin();
                fpc.Id = rows["processid"] == DBNull.Value ? 0 : Convert.ToInt32(rows["processid"]);
                fpc.ProcessName = rows["processname"] == DBNull.Value ? "" : Convert.ToString(rows["processname"]);
                lst.Add(fpc);
            }
            return lst;
        }

        #endregion

        //Group

        #region GetGroups
        public List<FabricGroupAdmin> GetGroups()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_get_all_group";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetGroupsFromTable(dsFabricQuality.Tables[0]);
            }
        }

        public List<FabricGroupAdmin> GetGroupsFromTable(DataTable dt)
        {
            List<FabricGroupAdmin> lst = new List<FabricGroupAdmin>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin fpc = new FabricGroupAdmin();
                fpc.Id = rows["Id"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Id"]);
                fpc.FabricGroupName = rows["Name"] == DBNull.Value ? "" : Convert.ToString(rows["Name"]);
                lst.Add(fpc);
            }
            return lst;
        }

        public List<PaymentAdmin> GetPaymentDaysFromTable(DataTable dt)
        {
            List<PaymentAdmin> lst = new List<PaymentAdmin>();
            foreach (DataRow rows in dt.Rows)
            {
                PaymentAdmin fpc = new PaymentAdmin();
                fpc.Id = rows["Id"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Id"]);
                fpc.DayName = rows["DayName"] == DBNull.Value ? "" : Convert.ToString(rows["DayName"]);
                fpc.Day = rows["Days"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Days"]);
                lst.Add(fpc);
            }
            return lst;
        }

        public List<GradeAdmin> GetGradesFromTable(DataTable dt)
        {
            List<GradeAdmin> lst = new List<GradeAdmin>();
            foreach (DataRow rows in dt.Rows)
            {
                GradeAdmin fpc = new GradeAdmin();
                fpc.Grade = rows["Grade"] == DBNull.Value ? "" : Convert.ToString(rows["Grade"]);
                lst.Add(fpc);
            }
            return lst;
        }
        #endregion

        #region GetAllDrGrades
        public List<GradeAdmin> GetAllDrGrades()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetAllDrGrades";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                List<GradeAdmin> gas = new List<GradeAdmin>();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GradeAdmin ga = new GradeAdmin();
                    ga.Grade = Convert.ToString(reader["Grade"]);
                }
                return gas;
            }
        }
        #endregion

        #region GetTempTaskAll
        public DataSet GetTempTaskAll()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Sp_GetFNATaskAll";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }

        }

        public DataSet GetFnATaskAllByTaskIDDAL(int TaskId, int MainTaskID, string TaskName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Sp_GetFNATaskAllByTaskId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@TaskId", SqlDbType.Int);
                param.Value = TaskId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@MainTaskID", SqlDbType.Int);
                param.Value = MainTaskID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TaskName", SqlDbType.VarChar);
                param.Value = TaskName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        #endregion

        #region GetGarmentType
        public DataTable GetGarmentType()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_Get_Garment_type";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric.Tables[0];
            }
        }
        #endregion

        //below added by Girish on 2023-04-28
        public List<string> GetSuggestions(string q, string limit, string timestamp, int DropDownType, int POStatus,string Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetSuggestion_ForManageFabricPO";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);              
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = new SqlParameter("@EnteredTxt", SqlDbType.VarChar);
                param.Value = q;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DropDownType", SqlDbType.Int);
                param.Value = DropDownType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POStatus", SqlDbType.Int);
                param.Value = POStatus;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["Result"]));
                }
                return result;
            }
        }


        #region GeFabricNameByName
        public List<string> GeFabricNameByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetFabricNameByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["Fabric"]));
                }
                return result;
            }
        }
        #endregion
        //26042023-RajeevS
        #region GetPONumber
        public List<string> SuggestFabricSupplier(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetFabricSupplier";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["SupplierName"]));
                }
                return result;
            }
        }
        #endregion
        #region GetPONumber
        public List<string> GetPONumber(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetPONumber";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@PONumber", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["PONumber"]));
                }
                return result;
            }
        }
        #endregion
        #region GetPONumber
        public List<string> GetColorPrint(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetColorPrint";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ColorPrint"]));
                }
                return result;
            }
        }
        #endregion
        //26042023-RajeevS

        #region GetStockUnitByTradeName
        public int GetStockUnitByTradeName(string tradeName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetStockUnitByTradeName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = tradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter oparam;
                oparam = new SqlParameter("@oUnit", SqlDbType.Int);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(oparam.Value);
            }
        }
        #endregion

        #region GetTaskInfo
        public User_Task GetFnaTaskInfo(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetFnaTaskInfo";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                    return null;
                reader.Read();
                User_Task ut = new User_Task();
                ut.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                ut.IsDone = reader["IsDone"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsDone"]);
                ut.Url = reader["Url"] == DBNull.Value ? "" : Convert.ToString(reader["Url"]);
                ut.Param = reader["Param"] == DBNull.Value ? "" : Convert.ToString(reader["Param"]);
                ut.PoId = reader["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoId"]);
                ut.PoTypeId = reader["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoTypeId"]);
                ut.IsReProcessing = reader["IsReProcessing"] == DBNull.Value ? "" : Convert.ToString(reader["IsReProcessing"]);
                ut.SupplierId = reader["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SupplierId"]);
                ut.SupRtnSource = reader["SupRtnSource"] == DBNull.Value ? "" : Convert.ToString(reader["SupRtnSource"]);
                ut.TaskId = reader["TaskId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TaskId"]);
                ut.SrvId = reader["SrvId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SrvId"]);
                ut.FpId = reader["FpId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FpId"]);
                ut.ChallanId = reader["ChallanId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ChallanId"]);
                ut.Desc = reader["Desc"] == DBNull.Value ? "" : Convert.ToString(reader["Desc"]);
                ut.BulkInHouse = reader["BulkInHouse"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BulkInHouse"]);
                return ut;
            }
        }
        #endregion

        #region Quantity ReAllocation  for fabric And Accessory
        //by shubhe
        public List<string> GeFabricNameByName1(string FabricName)
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    const string cmdText = "sp_GetFabricNameByNameDetails";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                    //iProcess
                    SqlParameter param;
                    param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                    param.Value = FabricName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["FabricDetails"]));
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return result;

        }

        public DataSet BindFromQuantityReallocation(int FabricQualityID, string colorprint, int stage1, int stage2, int stage3, int stage4, int supplyType, string Flag, string type)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    const string cmdText = "USP_QuantityReallocationFabric_Accessory";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                    //iProcess
                    SqlParameter param;
                    param = new SqlParameter("@fabricQualityId", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = colorprint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@supplyType", SqlDbType.Int);
                    param.Value = supplyType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage1", SqlDbType.Int);
                    param.Value = stage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage2", SqlDbType.Int);
                    param.Value = stage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage3", SqlDbType.Int);
                    param.Value = stage3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage4", SqlDbType.Int);
                    param.Value = stage4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter dA = new SqlDataAdapter(cmd);
                    dA.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet BindFromQuantityReallocationAcc(string TradeName, string AccSize, string colorprint, int stage1, int stage2, int stage3, int stage4, int supplyType, string Flag, string type)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    const string cmdText = "USP_QuantityReallocationFabric_Accessory";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                    //iProcess
                    SqlParameter param;
                    param = new SqlParameter("@TradeNameAcc", SqlDbType.VarChar);
                    param.Value = TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = AccSize;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@supplyType", SqlDbType.Int);
                    param.Value = supplyType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage1", SqlDbType.Int);
                    param.Value = stage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage2", SqlDbType.Int);
                    param.Value = stage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage3", SqlDbType.Int);
                    param.Value = stage3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage4", SqlDbType.Int);
                    param.Value = stage4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = colorprint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter dA = new SqlDataAdapter(cmd);
                    dA.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public List<string> SuggestColorPrintName(string ColorPrint, int Qualityid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> result = new List<string>();
                try
                {
                    cnx.Open();
                    const string cmdText = "Usp_GetColorPrintBy_QualityId_Auto";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                    //iProcess
                    SqlParameter param;
                    param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                    param.Value = ColorPrint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quality_id", SqlDbType.Int);
                    param.Value = Qualityid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["FabricDetails"]));
                    }
                }
                catch (Exception ex)
                {

                }
                return result;
            }
        }
        public DataSet GetStageForAccFabric(string Flag)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "USP_GETStageForReallocaton";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 20

                    };
                    SqlParameter Param;
                    Param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    Param.Direction = ParameterDirection.Input;
                    Param.Value = Flag;
                    cmd.Parameters.Add(Param);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                }
            }
            catch (Exception ex)
            {

            }
            return ds;

        }

        public int QuantityReallocationFabric_Accessory_FinalSattlement(int FromOrderdetailid, int ToOrderDetailsId, int FabricQualityId, string FrmFabricDetails, string ToFabricDetails, int SupplyType, int StageNumber, int PassQtyToMove, int RequiredQty, int Userid, string Flag, int AccessoryMasterId, string AccessorySize)
        {
            int OutPut = 0;
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string cmdText = "USP_QuantityReallocationFabric_Accessory_FinalSattlement";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    SqlParameter param;
                    param = new SqlParameter("@FromOrderdetailid", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FromOrderdetailid;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToOrderdetailid", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ToOrderDetailsId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityId", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FabricQualityId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrmFabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FrmFabricDetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToFabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ToFabricDetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplyType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SupplyType;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StageNumber", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = StageNumber;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@PassQtyToMove", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = PassQtyToMove;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RequiredQty", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = RequiredQty;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Flag;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = AccessoryMasterId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessorySize", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = AccessorySize;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Userid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Userid;
                    cmd.Parameters.Add(param);
                    cnx.Open();
                    OutPut = cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                ///Server.Transfer("~/Internal/CustomErrorPage.aspx");
                ///
                throw ex;

            }
            return OutPut;

        }
        #endregion

        public DataSet GetFabricOrderPrint(int orderid, int flag, int seqid = 0, int orderdeatilID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();

                string cmdText = "Usp_GetFabOderPrintDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Seq", SqlDbType.Int);
                param.Value = seqid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDeatilID", SqlDbType.Int);
                param.Value = orderdeatilID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                //DataTable ds = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                cnx.Close();
                return ds;
            }
        }
        //added by abhishek on 11.1.2018
        public void UpdateFabricPrintMarchantComments(int orderDetailID, string MarchantComents)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabOderPrintDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDeatilID", SqlDbType.Int);
                param.Value = orderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MerchantNates", SqlDbType.VarChar);
                param.Value = MarchantComents;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
        }
        //added by abhishek on 15.1.2019
        public DataTable GetFabricCutOrderAvg(int orderid, int flag, int OrderDetailID, int FabQualityID, string FabDetails, int fabcount = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();

                string cmdText = "Usp_GetFabricCutOrderAvg_Details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@FabQualityID", SqlDbType.Int);
                //param.Value = FabQualityID;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@FabDetails", SqlDbType.VarChar);
                //param.Value = FabDetails;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@FabCount", SqlDbType.Int);
                param.Value = fabcount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }
        }
        public DataSet GetFabricAvg(int OrderDetailID, int flag, int fabcount = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                //DataTable dt = new DataTable();
                DataSet dt = new DataSet();
                cnx.Open();

                string cmdText = "Usp_GetFabricCutOrderAvg_Details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabCount", SqlDbType.Int);
                param.Value = fabcount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }
        }

        //added by raghvinder on 10-11-2020 start
        public int FabricApproved_History(string Type, int OrderID, int CheckValue, int CreatedBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricCutOrderAvg_Details";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Orderid", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckValue", SqlDbType.Int);
                    param.Value = CheckValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return count;
            }
        }

        //added by raghvinder on 10-11-2020 end

        public int UpdateFabricCutprint(int OrderDetailsID, int CostingID, decimal CutAvg, string CutAvgfile, decimal OrderAvg, string CostingAvgFile, int FabCount, decimal OrderWidthValue, decimal CostWidthValue, decimal CutWidthValue, int CheckBoxAM, int CutAVgunit, string TextHistory)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabricCutOrderAvg_Details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutAvg", SqlDbType.Float);
                param.Value = CutAvg;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutAvgfile", SqlDbType.VarChar);
                if (CutAvgfile == "")
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = CutAvgfile;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderAvg", SqlDbType.Float);
                param.Value = OrderAvg;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostingAvgFile", SqlDbType.VarChar);
                if (CostingAvgFile == "")
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = CostingAvgFile;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabCount", SqlDbType.Int);
                param.Value = FabCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderWidth", SqlDbType.Float);
                param.Value = OrderWidthValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostWidth", SqlDbType.Float);
                param.Value = CostWidthValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWidth", SqlDbType.Float);
                param.Value = CutWidthValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CheckBoxAM", SqlDbType.Int);
                param.Value = CheckBoxAM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = CutAVgunit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TextHistory", SqlDbType.NVarChar);
                param.Value = TextHistory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        //end
        public DataTable getpendingFabSummary(string flag, string FabricName, string ColorPrint, int OrderID, string fabricqualityname)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_PendingOrderSummary";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = FabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchbyFabricName", SqlDbType.VarChar);
                param.Value = fabricqualityname.Equals(string.Empty) ? (object)DBNull.Value : fabricqualityname;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Searchbystylenumber", SqlDbType.VarChar);
                //param.Value = stylenumber.Equals(string.Empty) ? (object)DBNull.Value : stylenumber; 
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric.Tables[0];
            }
        }
        public DataTable getpendingFabsStageValidation(string flag, int FabricQualityID, string FabricDetails, int stage1, int stage2, int stage3, int stage4)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_PendingOrderSummary";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fabricMasterID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage1", SqlDbType.Int);
                param.Value = stage1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage2", SqlDbType.Int);
                param.Value = stage2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage3", SqlDbType.Int);
                param.Value = stage3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage4", SqlDbType.Int);
                param.Value = stage4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric.Tables[0];
            }
        }
        public DataTable CheckStageUpadteValidation(string flag, string ColorPrint, int FabQtyID, int stageval)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_PendingOrderSummary";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stageval", SqlDbType.Int);
                param.Value = stageval;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@fabricMasterID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric.Tables[0];
            }
        }
        public DataTable CheckStageUpadteValidationSRVLock(string flag, string ColorPrint, int FabQtyID, int orderdetailsID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_PendingOrderSummary";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = orderdetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@fabricMasterID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric.Tables[0];
            }
        }
        public DataSet GetGriegeFabDetails(string flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetFabricCutWithGsm";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                //SqlParameter outParam;
                //outParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                //outParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetGriegeFabDetailsUserID(string flag, int UserID, string fabricdetails, string searchtxt, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetFabricCutWithGsm";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetSupplierPoDetails(string flag, int FabQtyID, int fabType, string FabricDetails, int SupplierMasterID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetFabricCutWithGsm";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@fabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fabType", SqlDbType.Int);
                param.Value = fabType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Supplier_master_ID", SqlDbType.Int);
                param.Value = SupplierMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GETStyleSerialnumberONSupplierQuoatation(int FabQualityID, string FabricDetails, int supplyType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "SP_GetSerialNumberBy_Qualityid_On_Supplier";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                //SqlParameter outParam;
                //outParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                //outParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@Fabric_QualityID", SqlDbType.Int);
                param.Value = FabQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                //SqlParameter param;
                param = new SqlParameter("@Fabric_Details", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                //SqlParameter param;
                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = supplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);





                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetGSTByPoNumber(string flag, int supplierpoid, int debitnotid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "USP_Get_FabricDebitNote";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = supplierpoid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = debitnotid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetSupplierPoDetails1(string flag, int FabQtyID, int fabType, string FabricDetails, int SupplierMasterID, int styleid, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetFabricCutWithGsm";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@fabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fabType", SqlDbType.Int);
                param.Value = fabType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Supplier_master_ID", SqlDbType.Int);
                param.Value = SupplierMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage1", SqlDbType.Int);
                param.Value = stage1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage2", SqlDbType.Int);
                param.Value = stage2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage3", SqlDbType.Int);
                param.Value = stage3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage4", SqlDbType.Int);
                param.Value = stage4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetfabricViewdetails(string flag, string flagoption, int FabQualityID = 0, int SupplierCount = 0, string fabricDeatils = "", string searchtxt = "", int SupplierPO = 0, int CurrentStage = 0, int PreviousStage = 0, bool IsStylespecific = false, int StyleID = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricDeatils;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierCount", SqlDbType.Int);
                param.Value = SupplierCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage1 > 0)
                    param.Value = stage1;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage2 > 0)
                    param.Value = stage2;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage3 > 0)
                    param.Value = stage3;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage4 > 0)
                    param.Value = stage4;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (CurrentStage > 0)
                    param.Value = CurrentStage;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (PreviousStage > 0)
                    param.Value = PreviousStage;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = IsStylespecific;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable Podetailsprint(string flag, string ponumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                param.Value = ponumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public bool updateGreigeValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float Isresidualshrnkpplyongerige)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GreigedShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (GreigedShrinkage > 0)
                        param.Value = GreigedShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSrnkApplyOngerige", SqlDbType.Float);
                    param.Value = Isresidualshrnkpplyongerige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdareResidualShrinkage(string Flag, string FlagOption, float residualshrinkage, int FabricQualityID, string FabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GreigedShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (residualshrinkage > 0)
                        param.Value = residualshrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = 122;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Value = FabricDetails;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool updatePendingGreigeOrders(FabricGroupAdmin.FabricDetails Fabdet)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Fabdet.Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = Fabdet.FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GreigedShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.GreigedShrinkage > 0)
                        param.Value = Fabdet.GreigedShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.QtyToOrder > 0)
                        param.Value = Fabdet.QtyToOrder;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.UserID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PendingQtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    //if (Fabdet.PendingQtyToOrder > 0)
                    param.Value = Fabdet.PendingQtyToOrder;
                    //else
                    //    param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.FabricQualityID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@GreigedResidualShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.GreigedResidualShrinkage > 0)
                        param.Value = Fabdet.GreigedResidualShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Value = Fabdet.ColorPrint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSrnkApplyOngerige", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.IsGerigeShrinkage;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool updatePendingGreigeOrdersProxy(string flag, string FlagOption, int QtyToOrder, int PendingQtyToOrder, int FabricQualityID, string FabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@QtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (QtyToOrder > 0)
                        param.Value = QtyToOrder;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@PendingQtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (PendingQtyToOrder > 0)
                        param.Value = PendingQtyToOrder;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FabricQualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Value = FabricDetails;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public DataSet GetFabricpurchasedSupplier(string flag, string flagoption, int FabQualityID = 0, int FabricMasterID = 0, string potype = "", int SuppliermasterID = 0, int MasterPoID = 0, string FabricDetails = "", int CurrentStageNumber = 0, int PreviousstageNumber = 0, int styleid = 0, bool IsStyleSpecific = false, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int converttounit = 0, float conversionvalue = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Base_Get_Fabric_PO_Raise_Details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricMasterID", SqlDbType.Int);
                param.Value = FabricMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Potype", SqlDbType.VarChar);
                param.Value = potype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                param.Value = SuppliermasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MasterPoID", SqlDbType.Int);
                param.Value = MasterPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@colorprintdetail", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStageNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousstageNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Int);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage1", SqlDbType.Int);
                param.Value = stage1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage2", SqlDbType.Int);
                param.Value = stage2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage3", SqlDbType.Int);
                param.Value = stage3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage4", SqlDbType.Int);
                param.Value = stage4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ConvertToUnit", SqlDbType.Int);
                param.Value = converttounit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ConversionValue", SqlDbType.Int);
                param.Value = conversionvalue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public bool UpdateFabricPurchasedDetails(string Flag, string FlagOption, int FabricQualityID, int SuppliermasterID, string Po_Number, DateTime Podate, int UserID, int ReceviedQty, float rate, DateTime ENDETA, int garmentunits,
            int sendqty, string colorprintdetail, int IsAuthSign, int IsPartySign, int IsJuniorSign, float gerige, float residual, int Currentstage, int previousstage, bool isstylespecific, int styleid, int stage1, int stage2, int stage3, int stage4, int Converttounit, float conversionvalue, string History, float cutwastage, int RateType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_Base_Get_Fabric_PO_Raise_Details";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Value = SuppliermasterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                    param.Value = Po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@colorprintdetail", SqlDbType.VarChar);
                    param.Value = colorprintdetail;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@Podate", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    if (Podate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Podate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceviedQty", SqlDbType.Int);
                    param.Value = ReceviedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendQty", SqlDbType.Int);
                    param.Value = sendqty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAuthSign", SqlDbType.Int);
                    param.Value = IsAuthSign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPartySign", SqlDbType.Int);
                    param.Value = IsPartySign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsJuniorSign", SqlDbType.Int);
                    param.Value = IsJuniorSign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@rate", SqlDbType.Float);
                    param.Value = rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@cutwastage", SqlDbType.Float);
                    param.Value = cutwastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Units", SqlDbType.Int);
                    param.Value = garmentunits;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@gerige", SqlDbType.Float);
                    param.Value = gerige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@residual", SqlDbType.Float);
                    param.Value = residual;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ENDETA", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    if (Podate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = ENDETA;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                    param.Value = Currentstage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                    param.Value = previousstage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                    param.Value = isstylespecific;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage1", SqlDbType.Int);
                    param.Value = stage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage2", SqlDbType.Int);
                    param.Value = stage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage3", SqlDbType.Int);
                    param.Value = stage3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage4", SqlDbType.Int);
                    param.Value = stage4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConvertToUnit", SqlDbType.Int);
                    param.Value = Converttounit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@RateType", SqlDbType.Int);
                    param.Value = RateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConversionValue", SqlDbType.Float);
                    if (conversionvalue <= 0)
                    {
                        param.Value = 1;
                    }
                    else
                    {
                        param.Value = conversionvalue;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@History", SqlDbType.NVarChar);
                    if (History == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = History;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateCutwastage(string Flag, string Po_Number, decimal cutwastage)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                    param.Value = Po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cutwastage", SqlDbType.Float);
                    param.Value = cutwastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }


        public bool UpdateComment_ON_PO(string Po_Number, string CommentRemarks)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "UpdateCommentRemarks";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar);
                    param.Value = Po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CommentRemarks", SqlDbType.VarChar);
                    param.Value = @CommentRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        //aaaaaa
        public DataSet PopulateRemarks(string Po_Number)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {

                    cnx.Open();

                    string cmdText = "GetRemarksForPO";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar);
                    param.Value = Po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    da.Fill(ds);

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return ds;
        }

        public bool UpdateFabricPurchasedETA(string Flag, string FlagOption, DateTime ETAdate, int UserID, int FromQty, int ToQty, int MasterPoID, string Po_Number, int IsAuthSign, int IsPartySign, int IsJuniorSign)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_Base_Get_Fabric_PO_Raise_Details";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Podate", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    if (ETAdate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = ETAdate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAuthSign", SqlDbType.Int);
                    param.Value = IsAuthSign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPartySign", SqlDbType.Int);
                    param.Value = IsPartySign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsJuniorSign", SqlDbType.Int);
                    param.Value = IsJuniorSign;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ETAFromQty", SqlDbType.Int);
                    param.Value = FromQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ETAToQty", SqlDbType.Int);
                    param.Value = ToQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MasterPoID", SqlDbType.Int);
                    param.Value = MasterPoID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                    param.Value = Po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConvertToUnit", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConversionValue", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public DataSet GetRaisedPOWorkingDetails(string flag, string flagoption, int SupplierPO_Id = 0, string Searchtxt = "", int status = -1, int orderdetailID = 0,int DropDownType = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetRaisedPOWorkingDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.Int);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderdetailID", SqlDbType.Int);
                param.Value = orderdetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DropDownType", SqlDbType.Int);
                param.Value = DropDownType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        public DataSet GetPOStatus(string flag, int SupplierPO_Id, int SrvID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetRaisedPOWorkingDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvID", SqlDbType.Int);
                param.Value = SrvID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        // Created By Shubhendu 
        public DataSet GetRaisedPOWorkingDetailsIndex(string flag, string flagoption, int PageNumber, int PageSize, int SupplierPO_Id = 0, string Searchtxt = "", int status = -1, int orderdetailID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetRaisedPOWorkingDetailsIndex";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.Int);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderdetailID", SqlDbType.Int);
                param.Value = orderdetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageNumber", SqlDbType.Int);
                param.Value = PageNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = PageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetFabFourPointCheckInsepection(string flag, int SrvID = 0, int SupplierPO_Id = 0, int FourPointCheck_Id = 0, int userid = 0)
        {
            DataSet dsFabric = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    const string cmdText = "Usp_GetFabFourPointCheckInsepection";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvID", SqlDbType.Int);
                    param.Value = SrvID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                    param.Value = SupplierPO_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FourPointCheck_Id", SqlDbType.Int);
                    param.Value = FourPointCheck_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@userid", SqlDbType.Int);
                    param.Value = userid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsFabric);

                }

            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

            }

            return dsFabric;

        }
        public DataSet FourPointCheckLabFile(int type, int SrvID, string FileName, char Action)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdtext = "USP_FourPointCheckLabFiles";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@type", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FileName", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = FileName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = SrvID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Action", SqlDbType.Char);
                param.Direction = ParameterDirection.Input;
                param.Value = Action;
                cmd.Parameters.Add(param);

                DataSet DsLabFiles = new DataSet();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DsLabFiles);

                return DsLabFiles;

            }
        }

        public DataSet FourPointCheckLabFileForAccessory(int type, int SrvID, string FileName, char Action)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdtext = "USP_FourPointCheckLabFilesForAccessory";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@type", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FileName", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = FileName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = SrvID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Action", SqlDbType.Char);
                param.Direction = ParameterDirection.Input;
                param.Value = Action;
                cmd.Parameters.Add(param);

                DataSet DsLabFiles = new DataSet();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DsLabFiles);

                return DsLabFiles;

            }



        }
        public DataTable LabManagerChecked(int SRV_Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdtext = "Usp_GetFabFourPointCheckInsepection";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SRV_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "LabChecked";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.ExecuteNonQuery();
                cnx.Close();
                return dt;
            }

        }
        //new code 05-02-2021 start
        public DataTable GetFabFourPointCheckUpdateBasic(FabricInspectSystem fabricInspectSystem)
        {

            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabFourPointCheckInsepection";
                    SqlParameter param;

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "3";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = fabricInspectSystem.SupplierPO_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvId", SqlDbType.Int);
                    param.Value = fabricInspectSystem.SRV_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerName", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.CheckerName1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerName2", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.CheckerName2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerName3", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.CheckerName3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FourPointCheckDate", SqlDbType.DateTime);
                    param.Value = fabricInspectSystem.InspectionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@TotalQty", SqlDbType.Int);
                    //param.Value = fabricInspectSystem.TotalQty;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllocatedUnit", SqlDbType.Int);
                    param.Value = fabricInspectSystem.UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClaimedQty", SqlDbType.Int);
                    param.Value = fabricInspectSystem.ClaimedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedQty", SqlDbType.Int);
                    param.Value = fabricInspectSystem.RecievedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedQty", SqlDbType.Int);
                    param.Value = fabricInspectSystem.CheckedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (fabricInspectSystem.PassQty > 0)
                    {
                        param = new SqlParameter("@PassQty", SqlDbType.Int);
                        param.Value = fabricInspectSystem.PassQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (fabricInspectSystem.HoldQty > 0)
                    {
                        param = new SqlParameter("@HoldQty", SqlDbType.Int);
                        param.Value = fabricInspectSystem.HoldQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (fabricInspectSystem.FailQty > 0)
                    {
                        param = new SqlParameter("@FailQty", SqlDbType.Int);
                        param.Value = fabricInspectSystem.FailQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = fabricInspectSystem.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsFabricQA", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.IsFabricQA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsFabricGM", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.IsFabricGM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //new parameters start

                    //param = new SqlParameter("@ClaimedQty", SqlDbType.Int);
                    //param.Value = fabricInspectSystem.ClaimedQty;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalLabSpecimanCount", SqlDbType.Int);
                    param.Value = fabricInspectSystem.InternalLabSpeciman;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabSpecimanCount", SqlDbType.Int);
                    param.Value = fabricInspectSystem.ExternalLabSpeciman;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalSentToLab", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.InternalSentToLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalSentToLab", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.ExternalSentToLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalReceivedInLab", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.InternalReceivedInLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalReceivedInLab", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.ExternalReceivedInLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalSentToLabDate", SqlDbType.DateTime);
                    if ((fabricInspectSystem.InternalSentToLabDate == DateTime.MinValue) || (fabricInspectSystem.InternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.InternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.InternalSentToLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalSentToLabDate", SqlDbType.DateTime);

                    if ((fabricInspectSystem.ExternalSentToLabDate == DateTime.MinValue) || (fabricInspectSystem.ExternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.ExternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.ExternalSentToLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalReceivedInLabDate", SqlDbType.DateTime);
                    if ((fabricInspectSystem.InternalReceivedInLabDate == DateTime.MinValue) || (fabricInspectSystem.InternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.InternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.InternalReceivedInLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalReceivedInLabDate", SqlDbType.DateTime);
                    if ((fabricInspectSystem.ExternalReceivedInLabDate == DateTime.MinValue) || (fabricInspectSystem.ExternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.ExternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.ExternalReceivedInLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalLabReport", SqlDbType.VarChar);
                    if (fabricInspectSystem.InternalLabReport == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.InternalLabReport;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //param.Value = fabricInspectSystem.InternalLabReport;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabReport", SqlDbType.VarChar);
                    if (fabricInspectSystem.ExternalLabReport == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.ExternalLabReport;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //param.Value = fabricInspectSystem.ExternalLabReport;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDecision", SqlDbType.Int);
                    param.Value = fabricInspectSystem.FinalDecision;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDecisionDate", SqlDbType.DateTime);
                    if ((fabricInspectSystem.FinalDecisionDate == DateTime.MinValue) || (fabricInspectSystem.FinalDecisionDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.FinalDecisionDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.FinalDecisionDate;
                    }
                    //param.Value = fabricInspectSystem.FinalDecisionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectExtraQty", SqlDbType.Int);
                    param.Value = fabricInspectSystem.TotalExternalQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailRaiseDebit", SqlDbType.Int);
                    param.Value = fabricInspectSystem.FailedRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailStock", SqlDbType.Int);
                    param.Value = fabricInspectSystem.FailedStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailGoodStock", SqlDbType.Int);
                    param.Value = fabricInspectSystem.FailedGoodStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailParticular", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.FailedParticular;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectRaiseDebit", SqlDbType.Int);
                    param.Value = fabricInspectSystem.InspectRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectUsableDebit", SqlDbType.Int);
                    param.Value = fabricInspectSystem.InspectUsableStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectParticular", SqlDbType.VarChar);
                    param.Value = fabricInspectSystem.InspectParticular;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsLabManager", SqlDbType.Bit);
                    param.Value = fabricInspectSystem.IsLabManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isCommercialPass", SqlDbType.Int);
                    param.Value = fabricInspectSystem.IsCommercialPass;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@internallabDecision", SqlDbType.Int);
                    param.Value = fabricInspectSystem.LabdecisionInternal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabDecision", SqlDbType.Int);
                    param.Value = fabricInspectSystem.LabDecisionExternal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@LabManagerApprovedDate", SqlDbType.DateTime);
                    if ((fabricInspectSystem.LabManagerApprovedDate == DateTime.MinValue) || (fabricInspectSystem.LabManagerApprovedDate == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.LabManagerApprovedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.LabManagerApprovedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQAUpdatedOn", SqlDbType.DateTime);
                    if ((fabricInspectSystem.FabricQAUpdatedOn == DateTime.MinValue) || (fabricInspectSystem.FabricQAUpdatedOn == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.FabricQAUpdatedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.FabricQAUpdatedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricGMUpdatedOn", SqlDbType.DateTime);
                    if ((fabricInspectSystem.FabricGMUpdatedOn == DateTime.MinValue) || (fabricInspectSystem.FabricGMUpdatedOn == Convert.ToDateTime("1753-01-01")) || (fabricInspectSystem.FabricGMUpdatedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.FabricGMUpdatedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricQABy", SqlDbType.Int);
                    if (fabricInspectSystem.FabricQABy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.FabricQABy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricGMBy", SqlDbType.Int);
                    if (fabricInspectSystem.FabricGMBy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.FabricGMBy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LabManagerBy", SqlDbType.Int);
                    if (fabricInspectSystem.LabManagerBy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricInspectSystem.LabManagerBy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //new parameters end

                    SqlParameter outParam;
                    outParam = new SqlParameter("@FourPointCheckID", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter outParam1;
                    outParam1 = new SqlParameter("@Excess_Stock_Qty", SqlDbType.Int);
                    outParam1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam1);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    //cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }


                return dt;

            }

        }

        //new code 05-02-2021 end


        //public DataTable GetFabFourPointCheckUpdateBasic(int SupplierPoID, int SrvID, DateTime FourPointCheckDate, int AllocatedUnit, decimal ReceivedQty, decimal CheckedQty, decimal PassQty, decimal HoldQty, decimal FailQty, int CreatedBy, string Commentes, string CheckerName, int IsFabricQA, int IsCuttingQA, int IsFabricGM, int orderid, int OrderDetailID)
        //public DataTable GetFabFourPointCheckUpdateBasic(int SupplierPoID, int SrvID, DateTime FourPointCheckDate, int AllocatedUnit, decimal ReceivedQty, decimal CheckedQty,
        //            decimal PassQty, decimal HoldQty, decimal FailQty, int CreatedBy, int orderid, int OrderDetailID, string Commentes, int LabInternalSpecimanCount, bool InternalSentToLab,
        //            DateTime InternalSentToLabDate, bool InternalReceivedInLab, DateTime InternalReceivedInLabDate, string InternalLabReport, int LabExternalSpecimanCount, bool ExternalSentToLab,
        //            DateTime ExternalSentToLabDate, bool ExternalReceivedInLab, DateTime ExternalReceivedInLabDate, string ExternalLabReport, bool FinalDecision, decimal RaiseDebit, decimal FailStock,
        //            decimal GoodStock, string FailedParticular, decimal InspectRaiseDebit, decimal InspectUsableDebit, string InspectParticular, string CheckerName1, string CheckerName2,
        //            string CheckerName3, bool IsLabManager, bool IsFabricQA, bool IsFabricGM)


        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();
        //        const string cmdText = "Usp_GetFabFourPointCheckInsepection";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlParameter param;
        //        param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        param.Value = "3";
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@SrvID", SqlDbType.Int);
        //        param.Value = SrvID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
        //        param.Value = SupplierPoID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FourPointCheckDate", SqlDbType.DateTime);
        //        param.Value = FourPointCheckDate;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@AllocatedUnit", SqlDbType.Int);
        //        param.Value = AllocatedUnit;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ReceivedQty", SqlDbType.Float);
        //        param.Value = ReceivedQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        param = new SqlParameter("@CheckedQty", SqlDbType.Float);
        //        param.Value = CheckedQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);



        //        param = new SqlParameter("@PassQty", SqlDbType.Float);
        //        param.Value = PassQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);



        //        param = new SqlParameter("@HoldQty", SqlDbType.Float);
        //        param.Value = HoldQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);



        //        param = new SqlParameter("@FailQty", SqlDbType.Float);
        //        param.Value = FailQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //        param.Value = CreatedBy;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);               


        //        //param = new SqlParameter("@IsFabricQA", SqlDbType.Int);
        //        //if (IsFabricQA == -1)
        //        //    param.Value = DBNull.Value;
        //        //else
        //        //    param.Value = IsFabricQA;
        //        //param.Direction = ParameterDirection.Input;
        //        //cmd.Parameters.Add(param);


        //        //param = new SqlParameter("@IsCuttingQA", SqlDbType.Int);
        //        //if (IsCuttingQA == -1)
        //        //    param.Value = DBNull.Value;
        //        //else
        //        //    param.Value = IsCuttingQA;
        //        //param.Direction = ParameterDirection.Input;
        //        //cmd.Parameters.Add(param);


        //        //param = new SqlParameter("@IsFabricGM", SqlDbType.Int);
        //        //if (IsFabricGM == -1)
        //        //    param.Value = DBNull.Value;
        //        //else
        //        //    param.Value = IsFabricGM;

        //        //param.Direction = ParameterDirection.Input;
        //        //cmd.Parameters.Add(param);

        //        param = new SqlParameter("@orderid", SqlDbType.Int);
        //        param.Value = orderid;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
        //        param.Value = OrderDetailID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Commentes", SqlDbType.VarChar);
        //        param.Value = Commentes;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InternalLabSpecimanCount", SqlDbType.Int);
        //        param.Value = LabInternalSpecimanCount;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InternalSentToLab", SqlDbType.Bit);
        //        param.Value = InternalSentToLab;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);                

        //        param = new SqlParameter("@InternalSentToLabDate", SqlDbType.DateTime);
        //        if ((InternalSentToLabDate == DateTime.MinValue) || (InternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (InternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
        //        {
        //            param.Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            param.Value = InternalSentToLabDate;
        //        }

        //        param = new SqlParameter("@InternalLabReport", SqlDbType.VarChar);
        //        param.Value = InternalLabReport;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ExternalLabSpecimanCount", SqlDbType.Int);
        //        param.Value = LabExternalSpecimanCount;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ExternalSentToLab", SqlDbType.Bit);
        //        param.Value = ExternalSentToLab;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ExternalSentToLabDate", SqlDbType.DateTime);
        //        if ((ExternalSentToLabDate == DateTime.MinValue) || (ExternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (ExternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
        //        {
        //            param.Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            param.Value = ExternalSentToLabDate;
        //        }

        //        param = new SqlParameter("@ExternalLabReport", SqlDbType.VarChar);
        //        param.Value = ExternalLabReport;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FinalDecision", SqlDbType.Bit);
        //        param.Value = FinalDecision;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InspectRaiseDebit", SqlDbType.Decimal);
        //        param.Value = InspectRaiseDebit;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InspectUsableDebit", SqlDbType.Decimal);
        //        param.Value = InspectUsableDebit;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InspectParticular", SqlDbType.VarChar);
        //        param.Value = InspectParticular;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FailRaiseDebit", SqlDbType.Decimal);
        //        param.Value = RaiseDebit;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FailStock", SqlDbType.Decimal);
        //        param.Value = FailStock;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FailGoodStock", SqlDbType.Decimal);
        //        param.Value = GoodStock;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FailParticular", SqlDbType.VarChar);
        //        param.Value = FailedParticular;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ExternalReceivedInLab", SqlDbType.Bit);
        //        param.Value = ExternalReceivedInLab;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ExternalReceivedInLabDate", SqlDbType.DateTime);
        //        if ((ExternalReceivedInLabDate == DateTime.MinValue) || (ExternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (ExternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
        //        {
        //            param.Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            param.Value = ExternalReceivedInLabDate;
        //        }


        //        param = new SqlParameter("@InternalReceivedInLab", SqlDbType.Bit);
        //        param.Value = InternalReceivedInLab;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@InternalReceivedInLabDate", SqlDbType.DateTime);
        //        if ((InternalReceivedInLabDate == DateTime.MinValue) || (InternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (InternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
        //        {
        //            param.Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            param.Value = InternalReceivedInLabDate;
        //        }

        //        param = new SqlParameter("@CheckerName", SqlDbType.VarChar);
        //        param.Value = CheckerName1;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@CheckerName2", SqlDbType.VarChar);
        //        param.Value = CheckerName2;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        param = new SqlParameter("@CheckerName3", SqlDbType.VarChar);
        //        param.Value = CheckerName3;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@IsLabManager", SqlDbType.Bit);
        //        param.Value = IsLabManager;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@IsFabricQA", SqlDbType.Bit);
        //        param.Value = IsFabricQA;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@IsFabricGM", SqlDbType.Bit);
        //        param.Value = IsFabricGM;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);  

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);
        //        return dt;
        //    }
        //}
        public DataTable GetFabFourPointCheckUpdateDelete(int FourPointCheck_Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabFourPointCheckInsepection";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "4";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FourPointCheck_Id", SqlDbType.Int);
                param.Value = FourPointCheck_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        //new code 05-02-2021 start
        public DataTable GetFabFourPointCheckUpdateDetails(FabricInspect fabricInspect)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetFabFourPointCheckInsepection";
                SqlParameter param;
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "5";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@RollNumber", SqlDbType.Int);
                param.Value = fabricInspect.BoxNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FourPointCheck_Id", SqlDbType.Int);
                param.Value = fabricInspect.Inspection_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = fabricInspect.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeitLotNumber", SqlDbType.Int);
                param.Value = fabricInspect.DieLot;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClaimedLength", SqlDbType.Float);
                param.Value = fabricInspect.ClaimedLength;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualLength", SqlDbType.Float);
                param.Value = fabricInspect.ActLength;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CheckedQty1", SqlDbType.Float);
                param.Value = fabricInspect.CheckedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PassQty1", SqlDbType.Float);
                param.Value = fabricInspect.PassQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HoldQty1", SqlDbType.Float);
                param.Value = fabricInspect.HoldQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FailQty1", SqlDbType.Float);
                param.Value = fabricInspect.FailQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Width_S", SqlDbType.Float);
                param.Value = fabricInspect.Width_S;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Width_M", SqlDbType.Float);
                param.Value = fabricInspect.Width_M;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Width_E", SqlDbType.Float);
                param.Value = fabricInspect.Width_E;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Weaving_1", SqlDbType.Float);
                param.Value = fabricInspect.Weaving_1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Weaving_2", SqlDbType.Float);
                param.Value = fabricInspect.Weaving_2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Weaving_3", SqlDbType.Float);
                param.Value = fabricInspect.Weaving_3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Weaving_4", SqlDbType.Float);
                param.Value = fabricInspect.Weaving_4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Patta", SqlDbType.Float);
                param.Value = fabricInspect.Patta;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Hole", SqlDbType.Float);
                param.Value = fabricInspect.Hole;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printedDefectes_1", SqlDbType.Float);
                param.Value = fabricInspect.PrintedDefectes_1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printedDefectes_2", SqlDbType.Float);
                param.Value = fabricInspect.PrintedDefectes_2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printedDefectes_3", SqlDbType.Float);
                param.Value = fabricInspect.PrintedDefectes_3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printedDefectes_4", SqlDbType.Float);
                param.Value = fabricInspect.PrintedDefectes_4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WeaPointsPerSquirdYards", SqlDbType.Float);
                param.Value = fabricInspect.WeaPointsPerSquirdYards;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Float);
                param.Value = fabricInspect.Decision;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                string Parameter = "";
                foreach (SqlParameter par in cmd.Parameters)
                {
                    Parameter += par.ParameterName.ToString() + " ='" + par.Value + "' , ";
                }

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;

            }
        }
        //new code 05-02-2021 end

        //public DataTable GetFabFourPointCheckUpdateDetails(int FourPointCheck_Id, int RollNumber, int DeitLotNumber, decimal ClaimedLength, decimal ActualLength,decimal CheckedQty, decimal HoldQty, decimal FailQty, decimal Width_S, decimal Width_M, decimal Width_E, decimal Weaving_1, decimal Weaving_2, decimal Weaving_3, decimal Weaving_4, decimal Patta, decimal Hole, decimal PrintedDefectes_1, decimal PrintedDefectes_2, decimal PrintedDefectes_3, decimal PrintedDefectes_4, decimal WeaPointsPerSquirdYards, int Status)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();
        //        const string cmdText = "Usp_GetFabFourPointCheckInsepection";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlParameter param;
        //        param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        param.Value = "5";
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@RollNumber", SqlDbType.Int);
        //        param.Value = RollNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FourPointCheck_Id", SqlDbType.Int);
        //        param.Value = FourPointCheck_Id;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //        param.Value = LoggedInUser.UserData.UserID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@DeitLotNumber", SqlDbType.Int);
        //        param.Value = DeitLotNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        //new code start
        //        param = new SqlParameter("@ClaimedLength", SqlDbType.Float);
        //        param.Value = ClaimedLength;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);
        //        //new code end

        //        param = new SqlParameter("@ActualLength", SqlDbType.Float);
        //        param.Value = ActualLength;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        //new code start 02-02-2021
        //        param = new SqlParameter("@CheckedQty1", SqlDbType.Float);
        //        param.Value = CheckedQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@PassQty1", SqlDbType.Float);
        //        param.Value = PassQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@HoldQty1", SqlDbType.Float);
        //        param.Value = HoldQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FailQty1", SqlDbType.Float);
        //        param.Value = FailQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);
        //        //new code end 02-02-2021

        //        param = new SqlParameter("@Width_S", SqlDbType.Float);
        //        param.Value = Width_S;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Width_M", SqlDbType.Float);
        //        param.Value = Width_M;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Width_E", SqlDbType.Float);
        //        param.Value = Width_E;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Weaving_1", SqlDbType.Float);
        //        param.Value = Weaving_1;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Weaving_2", SqlDbType.Float);
        //        param.Value = Weaving_2;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Weaving_3", SqlDbType.Float);
        //        param.Value = Weaving_3;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Weaving_4", SqlDbType.Float);
        //        param.Value = Weaving_4;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Patta", SqlDbType.Float);
        //        param.Value = Patta;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Hole", SqlDbType.Float);
        //        param.Value = Hole;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@printedDefectes_1", SqlDbType.Float);
        //        param.Value = PrintedDefectes_1;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@printedDefectes_2", SqlDbType.Float);
        //        param.Value = PrintedDefectes_2;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@printedDefectes_3", SqlDbType.Float);
        //        param.Value = PrintedDefectes_3;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@printedDefectes_4", SqlDbType.Float);
        //        param.Value = PrintedDefectes_4;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@WeaPointsPerSquirdYards ", SqlDbType.Float);
        //        param.Value = WeaPointsPerSquirdYards;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Status ", SqlDbType.Int);
        //        param.Value = Status;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);
        //        return dt;
        //    }
        //}
        public DataSet GetSupplierChallanDetails(string Flag, int SupplierPoID = 0, string ChallanType = "", int ChallanID = 0, string IsNewChallan = "", int Debitnoteid = 0, string ChallanNumber = "")
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChallanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                param.Value = SupplierPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanType", SqlDbType.VarChar);
                param.Value = ChallanType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsNewChallan", SqlDbType.VarChar);
                param.Value = IsNewChallan;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteID", SqlDbType.Int);
                param.Value = Debitnoteid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }


        public bool Update_Foc_Challan(string Flag, string IsNewChallan, string ChallanNumber, int SupplierPoID, DateTime ChallanDate, string ChallanDescription, int SendChallanQty, Decimal FocExtraPercentt
                                           , Decimal Rate, int IsReceived, int IsAuthorized, DateTime ReceivedDate, DateTime AuthorizedDate, int LoggedInUserID, int FocId, int ReturnedChallanQty, string FOCProcessId, string HSNCode)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsNewChallan", SqlDbType.VarChar);
                param.Value = IsNewChallan;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                param.Value = SupplierPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDate", SqlDbType.DateTime);
                param.Value = ChallanDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDescription", SqlDbType.VarChar);
                param.Value = ChallanDescription;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SendChallanQty", SqlDbType.Int);
                param.Value = SendChallanQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FocExtraPercentt", SqlDbType.Decimal);
                param.Value = FocExtraPercentt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal);
                param.Value = Rate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsReceived", SqlDbType.Int);
                param.Value = IsReceived;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAuthorized", SqlDbType.Int);
                param.Value = IsAuthorized;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReceivedDate", SqlDbType.DateTime);
                if (ReceivedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ReceivedDate;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AuthorizedDate", SqlDbType.DateTime);
                if (AuthorizedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = AuthorizedDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LoggedInUserID", SqlDbType.Int);
                param.Value = LoggedInUserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FocId", SqlDbType.Int);
                param.Value = FocId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReturnedChallanQty", SqlDbType.Int);
                param.Value = ReturnedChallanQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FOCProcessId", SqlDbType.VarChar);
                param.Value = FOCProcessId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HSNCode", SqlDbType.VarChar);
                param.Value = HSNCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                return true;

            }
        }

        public bool Update_ExtraStockIssue_Challan(string Flag, string IsNewChallan, int SupplierPOId, string ChallanNumber, DateTime ChallanDate, string ChallanDescription, int SendChallanQty,
                                            int IsReceived, int IsAuthorized, DateTime ReceivedDate, DateTime AuthorizedDate, int LoggedInUserID, string StyleNumber, string SerialNumber, int InternalUnit,
                                            int ThanCount, string ColorPrint, int OrderDetailId, int ChallanId, int ReturnedChallanQty, int FabricQualityId, string FOCProcessId, string GSTNo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsNewChallan", SqlDbType.VarChar);
                param.Value = IsNewChallan;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPOId", SqlDbType.Int);
                param.Value = SupplierPOId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDate", SqlDbType.DateTime);
                param.Value = ChallanDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDescription", SqlDbType.VarChar);
                param.Value = ChallanDescription;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SendChallanQty", SqlDbType.Int);
                param.Value = SendChallanQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsReceived", SqlDbType.Int);
                param.Value = IsReceived;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAuthorized", SqlDbType.Int);
                param.Value = IsAuthorized;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReceivedDate", SqlDbType.DateTime);
                if (ReceivedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ReceivedDate;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AuthorizedDate", SqlDbType.DateTime);
                if (AuthorizedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = AuthorizedDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LoggedInUserID", SqlDbType.Int);
                param.Value = LoggedInUserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyerSrNumber", SqlDbType.VarChar);
                param.Value = SerialNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = InternalUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThanCount", SqlDbType.Int);
                param.Value = ThanCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printdetails", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReturnedChallanQty", SqlDbType.Int);
                param.Value = ReturnedChallanQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FOCProcessId", SqlDbType.VarChar);
                param.Value = FOCProcessId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InternalChallanGSTNo", SqlDbType.VarChar);
                param.Value = GSTNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                return true;

            }
        }

        public DataSet Create_Challan_From_StockQty(string Flag, string IsNewChallan, int OrderDetailID, int FabricQualityId, string FabricDetails, string ChallanType, int ChallanId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChallanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsNewChallan", SqlDbType.VarChar);
                param.Value = IsNewChallan;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printdetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanType", SqlDbType.VarChar);
                param.Value = ChallanType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                return dsFabric;

            }

        }

        public DataSet UpdateSupplierChallanDetails(
            string Flag
          , int SupplierPoID
          , string ChallanNumber
          , DateTime ChallanDate
          , string StyleNumber
          , string BuyerSrNumber
          , int UnitID
          , string ChallanDescription
          , int ThanCount
          , int ThanUnit
          , decimal TotalMeters
          , int IsReceived
          , DateTime ReceivedDate
          , int IsAuthorized
          , DateTime AuthorizedDate
          , int ReturnedChallanQty
          , int LoggedinUserID
          , int ChallanID
          , int ChallanType
          , int IsSendChallanNumber
          , int SendChallanQty
          , int debitnoteid
          , int Orderdetailid
          , int FabricQualityID
          , string printdetails
          , decimal GST
          , decimal Rate
          , string HSNCode
          , string GSTNo

                                      )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = Orderdetailid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                param.Value = SupplierPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsChallanTypeInternal", SqlDbType.Int);
                param.Value = ChallanType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsSendChallanNumber", SqlDbType.Int);
                param.Value = IsSendChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDate", SqlDbType.DateTime);
                if (ChallanDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ChallanDate;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                if (StyleNumber == "")
                    param.Value = DBNull.Value;
                else
                    param.Value = StyleNumber;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyerSrNumber", SqlDbType.VarChar);
                if (StyleNumber == "")
                    param.Value = DBNull.Value;
                else
                    param.Value = BuyerSrNumber;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                if (UnitID <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanDescription", SqlDbType.VarChar);
                param.Value = ChallanDescription;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ThanCount", SqlDbType.Int);
                if (ThanCount <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = ThanCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThanUnit", SqlDbType.Int);
                if (ThanUnit <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = ThanUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@TotalMeters", SqlDbType.Float);
                if (TotalMeters <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = TotalMeters;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@IsReceived", SqlDbType.Int);
                param.Value = IsReceived;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReceivedDate", SqlDbType.DateTime);
                if (ReceivedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ReceivedDate;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAuthorized", SqlDbType.Int);
                if (IsAuthorized <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = IsAuthorized;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@AuthorizedDate", SqlDbType.DateTime);
                if (AuthorizedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = AuthorizedDate;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SendChallanQty", SqlDbType.Int);
                if (SendChallanQty <= 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = SendChallanQty;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LoggedinUserID", SqlDbType.Int);
                param.Value = LoggedinUserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteID", SqlDbType.Int);
                param.Value = debitnoteid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printdetails", SqlDbType.VarChar);
                param.Value = printdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Gst", SqlDbType.Decimal);
                param.Value = GST;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReturnedChallanQty", SqlDbType.Int);
                param.Value = ReturnedChallanQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal);
                param.Value = Rate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HSNCode", SqlDbType.VarChar);
                param.Value = HSNCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GSTNo", SqlDbType.VarChar);
                param.Value = GSTNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetSelectedProcessForPdf(string Flag, int ChallanID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = @ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataSet deletechallan(string Flag, int ChallanID, int ProcessID = 0, int SrNumber = 0, int Meter = 0, int CM = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = @ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrNumber", SqlDbType.Int);
                param.Value = SrNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Meter", SqlDbType.Int);
                param.Value = Meter;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CM", SqlDbType.Int);
                param.Value = CM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }



        public int updateChallanProcess(string Flag, int ChallanID, int ProcessID, string SupplierName, string SamplingGstNo, string SamplingSupplierAddress)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = @ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = SupplierName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SamplingGstNo", SqlDbType.VarChar);
                param.Value = SamplingGstNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SamplingSupplierAddress", SqlDbType.VarChar);
                param.Value = SamplingSupplierAddress;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
        }

        public bool deletechallanbool(string Flag, int ChallanID, int ProcessID = 0, int SrNumber = 0, int Meter = 0, int CM = 0, string ChallanNumber = "")
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = @ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrNumber", SqlDbType.Int);
                param.Value = SrNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Meter", SqlDbType.Int);
                param.Value = Meter;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CM", SqlDbType.Int);
                param.Value = CM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return true;
            }
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricDayedDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Dyed";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;


                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetBasicdetailsDayed(dsFabricQuality.Tables[0]);
            }
        }

        public List<FabricGroupAdmin.FabricDetailsDayed> GetBasicdetailsDayed(DataTable dt)
        {
            List<FabricGroupAdmin.FabricDetailsDayed> lst = new List<FabricGroupAdmin.FabricDetailsDayed>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricDetailsDayed fpc = new FabricGroupAdmin.FabricDetailsDayed();

                fpc.FabricQualityID = rows["Fabric_QualityID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Fabric_QualityID"]);
                fpc.FabricName = rows["TradeName"] == DBNull.Value ? "" : Convert.ToString(rows["TradeName"]);
                fpc.CountConstruction = rows["CountConstruction"] == DBNull.Value ? "" : Convert.ToString(rows["CountConstruction"]);
                fpc.GSM = rows["GSM"] == DBNull.Value ? "" : Convert.ToString(rows["GSM"]);
                fpc.FabricColor = rows["FabricDetails"] == DBNull.Value ? "" : Convert.ToString(rows["FabricDetails"]);
                fpc.GreigedShrinkage = rows["GerigeShrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(rows["GerigeShrinkage"]);
                fpc.ResidualShrinkage = rows["Residual_Sh"] == DBNull.Value ? 0 : Convert.ToDouble(rows["Residual_Sh"]);
                fpc.BalanceInHouse = rows["BalanceHouseQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["BalanceHouseQty"]);
                fpc.width = rows["width"] == DBNull.Value ? 0 : Convert.ToInt32(rows["width"]);
                fpc.QtyToOrder = rows["QtyToOrder"] == DBNull.Value ? 0 : Convert.ToInt32(rows["QtyToOrder"]);
                fpc.PirorStageQty = rows["PeriorStageQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PeriorStageQty"]);
                fpc.TotalSendQtyByFabID = rows["TotalSendQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["TotalSendQty"]);
                fpc.CurrentStage = rows["CuurentStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["CuurentStage"]);
                fpc.PeriviousStage = rows["PreviousStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PreviousStage"]);
                fpc.IsStyleSpecific = rows["IsStyleSpecific"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsStyleSpecific"]);
                fpc.StyleID = rows["Styleid"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Styleid"]);
                fpc.PreviousStageName = rows["PreviousStageName"] == DBNull.Value ? "" : Convert.ToString(rows["PreviousStageName"]);
                fpc.adjustmentqty = rows["adjustmentqty"] == DBNull.Value ? "" : Convert.ToString(rows["adjustmentqty"]);
                fpc.IsStyleSpecificCaption = Convert.ToBoolean(rows["IsStyleSpecific"]) == true ? "Style Specific" : "";
                fpc.stage1 = rows["Stge1"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge1"]);
                fpc.stage2 = rows["Stge2"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge2"]);
                fpc.stage3 = rows["Stge3"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge3"]);
                fpc.stage4 = rows["Stge4"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge4"]);
                fpc.UnitName = rows["UnitName"] == DBNull.Value ? "" : Convert.ToString(rows["UnitName"]);        //ADDED BY RAGHVINDER ON 28-09-2020
                // fpc.RequiredQty = rows["RequiredQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["RequiredQty"]);
                fpc.Previousadjustmentqty = rows["Previousadjustmentqty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Previousadjustmentqty"]);


                lst.Add(fpc);
            }
            return lst;
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricDayedDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int Styleid = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Dyed";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "STYLE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Styleid;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetFabricStyleDetails(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricStyleDetails(DataTable dt)
        {
            List<FabricGroupAdmin.FabricContractDetails> lst = new List<FabricGroupAdmin.FabricContractDetails>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricContractDetails fpc = new FabricGroupAdmin.FabricContractDetails();

                fpc.FabricQualityID = rows["FabricQualityID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FabricQualityID"]);
                fpc.StyleID = rows["StyleID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["StyleID"]);
                fpc.StyleNumber = rows["StyleNumber"] == DBNull.Value ? "" : Convert.ToString(rows["StyleNumber"]);
                fpc.SerialNumber = rows["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(rows["SerialNumber"]);
                fpc.FabricQty = rows["FabricQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FabricQty"]);
                fpc.FinalFabricQtyToOrder = rows["FinalFabricQtyToOrder"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FinalFabricQtyToOrder"]);
                fpc.CuttingWastage = rows["CuttingWastage"] == DBNull.Value ? 0 : Convert.ToDecimal(rows["CuttingWastage"]);
                fpc.RequiredQty = rows["RequiredQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["RequiredQty"]);
                lst.Add(fpc);
            }
            return lst;
        }
        public bool updateDayedValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float ResidualShrinkage)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GreigedShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (GreigedShrinkage > 0)
                        param.Value = GreigedShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (ResidualShrinkage > 0)
                        param.Value = ResidualShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool updatePendingDayedOrders(FabricGroupAdmin.FabricDetails Fabdet)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Fabdet.Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = Fabdet.FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Value = Fabdet.ColorPrint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkage", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.ResidualShrinkage > 0)
                        param.Value = Fabdet.ResidualShrinkage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.QtyToOrder > 0)
                        param.Value = Fabdet.QtyToOrder;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.UserID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PendingQtyToOrder", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    //if (Fabdet.PendingQtyToOrder > 0)
                    param.Value = Fabdet.PendingQtyToOrder;
                    //else
                    //    param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.FabricQualityID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@BlanceQty", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.BalanceQty > 0)
                        param.Value = Fabdet.BalanceQty;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendQty", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.SendQty > 0)
                        param.Value = Fabdet.SendQty;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.stage1 > 0)
                        param.Value = Fabdet.stage1;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.stage2 > 0)
                        param.Value = Fabdet.stage2;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.stage3 > 0)
                        param.Value = Fabdet.stage3;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.stage4 > 0)
                        param.Value = Fabdet.stage4;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.Currentstage > 0)
                        param.Value = Fabdet.Currentstage;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.periviousstgae > 0)
                        param.Value = Fabdet.periviousstgae;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleida", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (Fabdet.StyleID > 0)
                        param.Value = Fabdet.StyleID;
                    else
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsStyleSpecific", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabdet.IsStyleSpecific;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }

        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricPrintDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "PRINT";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage2;


                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage3;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetBasicdetailsPrint(dsFabricQuality.Tables[0]);
            }
        }

        public List<FabricGroupAdmin.FabricDetailsDayed> GetBasicdetailsPrint(DataTable dt)
        {
            List<FabricGroupAdmin.FabricDetailsDayed> lst = new List<FabricGroupAdmin.FabricDetailsDayed>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricDetailsDayed fpc = new FabricGroupAdmin.FabricDetailsDayed();

                fpc.FabricQualityID = rows["Fabric_QualityID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Fabric_QualityID"]);
                fpc.FabricName = rows["TradeName"] == DBNull.Value ? "" : Convert.ToString(rows["TradeName"]);
                fpc.UnitName = rows["UnitName"] == DBNull.Value ? "" : Convert.ToString(rows["UnitName"]);
                fpc.CountConstruction = rows["CountConstruction"] == DBNull.Value ? "" : Convert.ToString(rows["CountConstruction"]);
                fpc.GSM = rows["GSM"] == DBNull.Value ? "" : Convert.ToString(rows["GSM"]);
                fpc.FabricColor = rows["FabricDetails"] == DBNull.Value ? "" : Convert.ToString(rows["FabricDetails"]);
                fpc.GreigedShrinkage = rows["GerigeShrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(rows["GerigeShrinkage"]);
                fpc.ResidualShrinkage = rows["Residual_Sh"] == DBNull.Value ? 0 : Convert.ToDouble(rows["Residual_Sh"]);
                fpc.BalanceInHouse = rows["BalanceHouseQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["BalanceHouseQty"]);
                fpc.width = rows["width"] == DBNull.Value ? 0 : Convert.ToInt32(rows["width"]);
                fpc.QtyToOrder = rows["QtyToOrder"] == DBNull.Value ? 0 : Convert.ToInt32(rows["QtyToOrder"]);
                fpc.PirorStageQty = rows["PeriorStageQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PeriorStageQty"]);
                fpc.TotalSendQtyByFabID = rows["TotalSendQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["TotalSendQty"]);
                fpc.CurrentStage = rows["CuurentStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["CuurentStage"]);
                fpc.PeriviousStage = rows["PreviousStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PreviousStage"]);
                fpc.IsStyleSpecific = rows["IsStyleSpecific"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsStyleSpecific"]);
                fpc.StyleID = rows["Styleid"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Styleid"]);
                fpc.PreviousStageName = rows["PreviousStageName"] == DBNull.Value ? "" : Convert.ToString(rows["PreviousStageName"]);
                fpc.adjustmentqty = rows["adjustmentqty"] == DBNull.Value ? "" : Convert.ToString(rows["adjustmentqty"]);
                fpc.IsStyleSpecificCaption = Convert.ToBoolean(rows["IsStyleSpecific"]) == true ? "Style Specific" : "";
                fpc.stage1 = rows["Stge1"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge1"]);
                fpc.stage2 = rows["Stge2"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge2"]);
                fpc.stage3 = rows["Stge3"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge3"]);
                fpc.stage4 = rows["Stge4"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge4"]);
                fpc.Previousadjustmentqty = rows["Previousadjustmentqty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Previousadjustmentqty"]);
                lst.Add(fpc);
            }
            return lst;
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricRFDDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "RFD";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage2;


                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage3;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetBasicdetailsVA(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricEmbellishmentDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Embellishment";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage2;


                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage3;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetBasicdetailsVA(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricEmbroideryDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Embroidery";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage2;


                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                param.Value = stage3;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetBasicdetailsVA(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetBasicdetailsVA(DataTable dt)
        {
            List<FabricGroupAdmin.FabricDetailsDayed> lst = new List<FabricGroupAdmin.FabricDetailsDayed>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricDetailsDayed fpc = new FabricGroupAdmin.FabricDetailsDayed();

                fpc.FabricQualityID = rows["Fabric_QualityID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Fabric_QualityID"]);
                fpc.FabricName = rows["TradeName"] == DBNull.Value ? "" : Convert.ToString(rows["TradeName"]);
                fpc.CountConstruction = rows["CountConstruction"] == DBNull.Value ? "" : Convert.ToString(rows["CountConstruction"]);
                fpc.GSM = rows["GSM"] == DBNull.Value ? "" : Convert.ToString(rows["GSM"]);
                fpc.FabricColor = rows["FabricDetails"] == DBNull.Value ? "" : Convert.ToString(rows["FabricDetails"]);
                fpc.GreigedShrinkage = rows["GerigeShrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(rows["GerigeShrinkage"]);
                fpc.ResidualShrinkage = rows["Residual_Sh"] == DBNull.Value ? 0 : Convert.ToDouble(rows["Residual_Sh"]);
                fpc.BalanceInHouse = rows["BalanceHouseQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["BalanceHouseQty"]);
                fpc.width = rows["width"] == DBNull.Value ? 0 : Convert.ToInt32(rows["width"]);
                fpc.QtyToOrder = rows["QtyToOrder"] == DBNull.Value ? 0 : Convert.ToInt32(rows["QtyToOrder"]);
                fpc.PirorStageQty = rows["PeriorStageQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PeriorStageQty"]);
                fpc.TotalSendQtyByFabID = rows["TotalSendQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["TotalSendQty"]);
                fpc.CurrentStage = rows["CuurentStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["CuurentStage"]);
                fpc.PeriviousStage = rows["PreviousStage"] == DBNull.Value ? 0 : Convert.ToInt32(rows["PreviousStage"]);
                fpc.IsStyleSpecific = rows["IsStyleSpecific"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsStyleSpecific"]);
                fpc.StyleID = rows["Styleid"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Styleid"]);
                fpc.PreviousStageName = rows["PreviousStageName"] == DBNull.Value ? "" : Convert.ToString(rows["PreviousStageName"]);
                fpc.adjustmentqty = rows["adjustmentqty"] == DBNull.Value ? "" : Convert.ToString(rows["adjustmentqty"]);
                fpc.IsStyleSpecificCaption = Convert.ToBoolean(rows["IsStyleSpecific"]) == true ? "Style Specific" : "";
                fpc.stage1 = rows["Stge1"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge1"]);
                fpc.stage2 = rows["Stge2"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge2"]);
                fpc.stage3 = rows["Stge3"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge3"]);
                fpc.stage4 = rows["Stge4"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Stge4"]);
                fpc.UnitName = rows["UnitName"] == DBNull.Value ? "" : Convert.ToString(rows["UnitName"]);        //ADDED BY RAGHVINDER ON 28-09-2020
                //fpc.RequiredQty = rows["RequiredQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["RequiredQty"]);
                fpc.Previousadjustmentqty = rows["Previousadjustmentqty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Previousadjustmentqty"]);

                lst.Add(fpc);
            }
            return lst;
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricPrintDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "PRINT";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "STYLE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetFabricStyleDetailsPrint(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricRFDDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "RFD";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "STYLE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetFabricStyleDetailsPrint(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricEmbellishmentDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Embellishment";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "STYLE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetFabricStyleDetailsPrint(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricEmbroideryDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Embroidery";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = "STYLE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = stage4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return GetFabricStyleDetailsPrint(dsFabricQuality.Tables[0]);
            }
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricStyleDetailsPrint(DataTable dt)
        {
            List<FabricGroupAdmin.FabricContractDetails> lst = new List<FabricGroupAdmin.FabricContractDetails>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricContractDetails fpc = new FabricGroupAdmin.FabricContractDetails();

                fpc.FabricQualityID = rows["FabricQualityID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FabricQualityID"]);
                fpc.StyleID = rows["StyleID"] == DBNull.Value ? 0 : Convert.ToInt32(rows["StyleID"]);
                fpc.StyleNumber = rows["StyleNumber"] == DBNull.Value ? "" : Convert.ToString(rows["StyleNumber"]);
                fpc.SerialNumber = rows["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(rows["SerialNumber"]);
                fpc.FabricQty = rows["FabricQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FabricQty"]);
                fpc.FinalFabricQtyToOrder = rows["FinalFabricQtyToOrder"] == DBNull.Value ? 0 : Convert.ToInt32(rows["FinalFabricQtyToOrder"]);
                fpc.CuttingWastage = rows["CuttingWastage"] == DBNull.Value ? 0 : Convert.ToDecimal(rows["CuttingWastage"]);
                fpc.RequiredQty = rows["RequiredQty"] == DBNull.Value ? 0 : Convert.ToInt32(rows["RequiredQty"]);
                lst.Add(fpc);
            }
            return lst;
        }
        public DataSet GetFabricIssueDetails(string Flag, int OrderDetailID, int FabQtyID, int Quality_ID, int OrderId, string search = "", string fabricdeatils = "", bool IsRequestPending = false, bool IsIssueRequest = false, bool IsCompleteIssu = false, bool IsSettlementDone = false)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricIssueDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Search", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdeatils;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@orderid", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quality_ID", SqlDbType.Int);
                param.Value = Quality_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsRequestPending", SqlDbType.Bit);
                param.Value = IsRequestPending;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsIssueRequest", SqlDbType.Bit);
                param.Value = IsIssueRequest;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsIssueComplete", SqlDbType.Bit);
                param.Value = IsCompleteIssu;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsSettlementDone", SqlDbType.Bit);
                param.Value = IsSettlementDone;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetFabricIssueDetails_report(string Flag, int OrderDetailID, int FabQtyID, int Quality_ID, int orderDetailID, string search = "", string fabricdeatils = "", bool IsRequestPending = false, bool IsIssueRequest = false, bool IsCompleteIssu = false, int selectall = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricIssueDetails_Report";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Search", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricdeatils;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@orderDetail_ID", SqlDbType.Int);
                param.Value = orderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quality_ID", SqlDbType.Int);
                param.Value = Quality_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsRequestPending", SqlDbType.Bit);
                param.Value = IsRequestPending;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsIssueRequest", SqlDbType.Bit);
                param.Value = IsIssueRequest;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsIssueComplete", SqlDbType.Bit);
                param.Value = IsCompleteIssu;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Selectall", SqlDbType.Bit);
                param.Value = selectall;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetFabricIssueDetails_Report(string Flag, int selectall, string searcht)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricIssueDetails_Report";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Selectall", SqlDbType.Int);
                param.Value = selectall;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Search", SqlDbType.VarChar);
                if (searcht.Trim() == "")
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = searcht;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        public DataSet GetPriorStage(int Quality_ID, int orderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "USP_Get_Cuuting_Issue_Screen_Check_Prior_Stage_Qty";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;


                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = orderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Quality_ID", SqlDbType.Int);
                param.Value = Quality_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPriorStage = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPriorStage);
                return dsPriorStage;
            }
        }
        public int UpdateFabricWastage(int CuttingRequest_IssueSheet_Id, decimal wastage, string flag, int OrderDetailID, int FabQtyID)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabricIssueDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CuttingRequest_IssueSheet_Id", SqlDbType.Int);
                param.Value = CuttingRequest_IssueSheet_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWastage", SqlDbType.Float);
                param.Value = wastage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public int UpdateFabricRaise(int IsCheck, string flag, int OrderDetailID, int FabQtyID, string FabricDetails, int Unitid, int UserID)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabricIssueDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsCheck", SqlDbType.Int);
                param.Value = IsCheck;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = Unitid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public int UpdateStockQty(string flag, int FabQtyID, string FabricDetails, int StockQty, int orderdetailid, int debitqty, string particulartext, int ResiShrinkQty, int ExtraWastageQty)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabricIssueDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StockQty", SqlDbType.Int);
                param.Value = StockQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ResiShrinkQty", SqlDbType.Int);
                param.Value = ResiShrinkQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExtraWastageQty", SqlDbType.Int);
                param.Value = ExtraWastageQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = orderdetailid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@debitqty", SqlDbType.Int);
                param.Value = debitqty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@particulartext", SqlDbType.VarChar);
                param.Value = particulartext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public DataSet GetInternalChallanDetails(string Flag, int SupplierPoID = 0, string ChallanType = "", int ChallanID = 0, string IsNewChallan = "", int OrderDetailsID = 0, int FabricQualityID = 0, string fabricdetails = "", string particular = "")
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetSupplierChanllanDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                param.Value = SupplierPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanType", SqlDbType.VarChar);
                param.Value = ChallanType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsNewChallan", SqlDbType.VarChar);
                param.Value = IsNewChallan;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanID", SqlDbType.Int);
                param.Value = ChallanID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@printdetails", SqlDbType.VarChar);
                param.Value = fabricdetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@particulartext", SqlDbType.VarChar);
                //param.Value = particular;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);



                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        //Added by abishek on 6.2.2018
        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> GetFabricHistory(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetFabricIssueDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                return GetFabricHi(dsFabricQuality.Tables[1], dsFabricQuality.Tables[2]);

            }
        }

        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> ListChallan(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetFabricIssueDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQtyID", SqlDbType.Int);
                param.Value = FabQtyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                return CreateList(dsFabricQuality.Tables[0]);

            }
        }

        public List<FabricGroupAdmin.FabricDetailsHistory> CreateList(DataTable dt)
        {
            List<FabricGroupAdmin.FabricDetailsHistory> lst = new List<FabricGroupAdmin.FabricDetailsHistory>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricDetailsHistory objhist = new FabricGroupAdmin.FabricDetailsHistory();

                objhist.ChallanID = rows["Challan_Id"] == DBNull.Value ? "" : Convert.ToString(rows["Challan_Id"].ToString());

                objhist.OrderDetailsID = rows["OrderDetailID"] == DBNull.Value ? "" : Convert.ToString(rows["OrderDetailID"].ToString());

                objhist.FabricQualityID = rows["Fabric_QualityID"] == DBNull.Value ? "" : Convert.ToString(rows["Fabric_QualityID"].ToString());

                objhist.FabricDetails = rows["FabricDetails"] == DBNull.Value ? "" : Convert.ToString(rows["FabricDetails"].ToString());

                objhist.ChallanNumber = rows["ChallanNumber"] == DBNull.Value ? "" : Convert.ToString(rows["ChallanNumber"].ToString());

                objhist.IssueQty = rows["IssueQty"] == DBNull.Value ? "" : Convert.ToString(Convert.ToInt32(rows["IssueQty"]).ToString("N0"));

                objhist.ReturnedChallanQty = rows["ReturnedChallanQty"] == DBNull.Value ? "" : Convert.ToString(rows["ReturnedChallanQty"].ToString());

                objhist.IssueDate = rows["IssueDate"] == DBNull.Value ? "" : rows["IssueDate"].ToString();

                lst.Add(objhist);
            }
            return lst;
        }


        public List<FabricGroupAdmin.FabricDetailsHistory> GetFabricHi(DataTable dt, DataTable dt2)
        {
            List<FabricGroupAdmin.FabricDetailsHistory> lst = new List<FabricGroupAdmin.FabricDetailsHistory>();
            foreach (DataRow rows in dt.Rows)
            {
                FabricGroupAdmin.FabricDetailsHistory objhist = new FabricGroupAdmin.FabricDetailsHistory();
                objhist.OrderDetailsID = rows["OrderDetailID"] == DBNull.Value ? "" : Convert.ToString(rows["OrderDetailID"].ToString());
                objhist.FabricQualityID = rows["Fabric_QualityID"] == DBNull.Value ? "" : Convert.ToString(rows["Fabric_QualityID"].ToString());
                objhist.ChallanNumber = rows["ChallanNumber"] == DBNull.Value ? "" : Convert.ToString(rows["ChallanNumber"].ToString());
                objhist.IssueQty = rows["TotalMeters"] == DBNull.Value ? "" : Convert.ToString(Convert.ToInt32(rows["TotalMeters"]).ToString("N0"));
                objhist.IssueDate = rows["ChallanDate"] == DBNull.Value ? "" : rows["ChallanDate"].ToString();
                objhist.ChallanID = rows["Challan_Id"] == DBNull.Value ? "" : Convert.ToString(rows["Challan_Id"].ToString());
                objhist.ReturnedChallanQty = rows["ReturnedChallanQty"] == DBNull.Value ? "" : Convert.ToString(rows["ReturnedChallanQty"].ToString());
                objhist.FabricDetails = dt2.Rows[0]["FabricDetails"].ToString();
                lst.Add(objhist);
            }
            return lst;
        }


        //added by raghvinder on 25-09-2020 start
        public DataTable GetUnit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetUnitName";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        //added by raghvinder on 25-09-2020 end

        public DataTable GetUnitName()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricPounitName";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable Getfabricliability(string flag, string FlagOption, string PoNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = FlagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = PoNumber;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public int UpdateFabricLibilityQty(string flag, string FlagOption, string PoNumber, int UserID, int LibilityQty, int OrderDetailID)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetFabricOrderSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = FlagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = PoNumber;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = UserID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LibilityQty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = LibilityQty;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public DataSet GetFabricWastage(string flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Barrier_Wastage";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetFabricWastageDetails(string flag, int fabricqtyid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Barrier_Wastage";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.VarChar);
                param.Value = fabricqtyid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        public int UpdateFabricWastageDetails(string flag, int fabricqtyid, int fabricBarrierWastage, int From_Qty, int To_Qty, int Solid_Barrier, int Print_Barrier, int Dyed_Barrier, int Finished_Barrier, int VA_Barrier)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_Barrier_Wastage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = fabricqtyid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricBarrierWastage", SqlDbType.Int);
                param.Value = fabricBarrierWastage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@From_Qty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = From_Qty;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@To_Qty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = To_Qty;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Solid_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Solid_Barrier;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Print_Barrier;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Dyed_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Dyed_Barrier;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Finished_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Finished_Barrier;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VA_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = VA_Barrier;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public int DeleteWastage(string flag, int fabricqtyid, int FabricBarrierWastage)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_Barrier_Wastage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.VarChar);
                param.Value = fabricqtyid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricBarrierWastage", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = FabricBarrierWastage;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }
        public int Save_Fabric_Bill(int SRV_Id, string PartyChallanNumber, bool IsChecked, int SupplierPoId, int PartyBillId, string PartyBillNumber, System.DateTime PartyBillDate, int Amount, int UserId)
        {
            int iSave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_Save_FabricSrv_Bill";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId; ;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                param.Value = PartyBillId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillNumber", SqlDbType.VarChar);
                param.Value = PartyBillNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillDate", SqlDbType.DateTime);
                param.Value = PartyBillDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount", SqlDbType.Int);
                param.Value = Amount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SRV_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                iSave = cmd.ExecuteNonQuery();
            }
            return iSave;
        }
        public DataSet GetFabricDebitNoteList(int SupplierPoId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "USP_Get_FabricDebitNote";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_LIST";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        //added by abhishek on 11/9/2019
        public List<Fabric_Srv_Bill> GetAccessory_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_Fabric_Srv_Bill";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitnoteID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Fabric_Srv_Bill> Fabric_Srv_BillCollection = new List<Fabric_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fabric_Srv_Bill objFabric_Srv_Bill = new Fabric_Srv_Bill();

                        objFabric_Srv_Bill.PartyBillNumber = (reader["PartyBillNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNumber"]);
                        objFabric_Srv_Bill.BillDetails = (reader["BillDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillDetails"]);
                        //objFabric_Srv_Bill.srvdebitamount = (reader["SRV_Qty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SRV_Qty"]);
                        //objFabric_Srv_Bill.SupplierID = (reader["SupplierID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SupplierID"]);
                        Fabric_Srv_BillCollection.Add(objFabric_Srv_Bill);
                    }
                }

                return Fabric_Srv_BillCollection;
            }
        }
        public FabricDebitNoteCls Get_FabricDebitNote(int SupplierPoId, int DebitNoteId, string PartyBillNumber, int srv_id)
        {
            FabricDebitNoteCls objFabricDebitNote = new FabricDebitNoteCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_FabricDebitNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_HEADER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objFabricDebitNote.DebitNoteId = (reader["DebitNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DebitNote_Id"]);
                        objFabricDebitNote.DebitNoteNumber = (reader["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DebitNoteNumber"]);
                        objFabricDebitNote.GSTNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);//new line
                        objFabricDebitNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objFabricDebitNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objFabricDebitNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objFabricDebitNote.PoDate = (reader["PoDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PoDate"]);
                        objFabricDebitNote.ReturnChallanNumber = (reader["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReturnChallanNumber"]);
                        objFabricDebitNote.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objFabricDebitNote.DebitNoteDate = (reader["DebitNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DebitNoteDate"]);
                        objFabricDebitNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);
                        objFabricDebitNote.IGST = (reader["IGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["IGST"]);
                        objFabricDebitNote.CGST = (reader["CGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["CGST"]);
                        objFabricDebitNote.SGST = (reader["SGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SGST"]);
                        objFabricDebitNote.QtyCheckedDate = (reader["CheckbyDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CheckbyDate"]);
                        objFabricDebitNote.QtyCheckedBy = (reader["Checkby"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Checkby"]);
                        objFabricDebitNote.ConversionValue = (reader["ConversionValue"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["ConversionValue"]);
                        objFabricDebitNote.FourPointFailQty = (reader["FailQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FailQty"]);
                        objFabricDebitNote.ConvertToUnit = (reader["ConvertToUnit"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ConvertToUnit"]);
                        objFabricDebitNote.defualtunit = (reader["defualtunit"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["defualtunit"]);
                        objFabricDebitNote.QualityName = reader["TradeName"] == DBNull.Value ? "" : reader["TradeName"].ToString();
                        objFabricDebitNote.QualityDetails = reader["FabricDetails"] == DBNull.Value ? "" : reader["FabricDetails"].ToString();
                        objFabricDebitNote.GSTNo = reader["GSTNo"] == DBNull.Value ? "" : reader["GSTNo"].ToString();
                        objFabricDebitNote.Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString();
                        objFabricDebitNote.PartyBillNumber = reader["PartyBillNumber"] == DBNull.Value ? string.Empty : reader["PartyBillNumber"].ToString();
                    }
                }

                if (objFabricDebitNote.PartyBillNumber != string.Empty) PartyBillNumber = objFabricDebitNote.PartyBillNumber;

                reader.Dispose();
                objFabricDebitNote.FabricDebitNoteParticularsList = FabricDebitNoteParticulars(SupplierPoId, DebitNoteId, PartyBillNumber, srv_id, cnx);

                return objFabricDebitNote;
            }
        }
        private List<FabricDebitNoteParticulars> FabricDebitNoteParticulars(int SupplierPoId, int DebitNoteId, string PartyBillNumber, int srv_id, SqlConnection cnx)
        {

            string cmdText = "USP_Get_FabricDebitNote";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
            param.Value = SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillNumber", SqlDbType.VarChar);
            param.Value = PartyBillNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Srv_id", SqlDbType.Int);
            param.Value = srv_id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "DEBITNOTE_PARTICULAR";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataReader reader1;

            reader1 = cmd.ExecuteReader();

            List<FabricDebitNoteParticulars> DebitNoteParticularsCollection = new List<FabricDebitNoteParticulars>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                    objDebitNoteParticulars.DebitNoteId = (reader1["DebitNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["DebitNote_Id"]);
                    objDebitNoteParticulars.DebitNoteParticularId = (reader1["DebitNote_Particulers_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["DebitNote_Particulers_Id"]);
                    objDebitNoteParticulars.ParticularName = (reader1["Particulers"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["Particulers"]);
                    objDebitNoteParticulars.DebitQuantity = (reader1["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Quantity"]);
                    objDebitNoteParticulars.DebitRate = (reader1["Rate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader1["Rate"]);
                    objDebitNoteParticulars.IsExtraQty = (reader1["IsExtraQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["IsExtraQty"]);
                    objDebitNoteParticulars.Fab_DebitNote_SRVID = (reader1["Fabric_PO_DebitNote_SRVID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Fabric_PO_DebitNote_SRVID"]);
                    objDebitNoteParticulars.SRVID = (reader1["Srv_id"] == DBNull.Value) ? " " : reader1["Srv_id"].ToString();
                    objDebitNoteParticulars.PartyBillNumber = (reader1["PartyBillNumber"] == DBNull.Value) ? " " : reader1["PartyBillNumber"].ToString();



                    DebitNoteParticularsCollection.Add(objDebitNoteParticulars);
                }
            }

            return DebitNoteParticularsCollection;
        }
        public int Update_Accessory_DebitNotePartyCulars(FabricDebitNoteParticulars objDebitNoteParticulars, int UserId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Fabric_DebitNotePartyCulars";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteParticularId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulars", SqlDbType.VarChar);
                    param.Value = objDebitNoteParticulars.ParticularName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = objDebitNoteParticulars.DebitRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();


                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }
        public int Save_Accessory_DebitNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Fabric_DebitNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.DebitNoteDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.DebitNoteDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.PartyBillNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnChallanNo", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.ReturnChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.ChallanDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.IGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.CGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.SGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalAmount", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.TotalAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnDebitNoteId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    param = new SqlParameter("@Checkby", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.QtyCheckedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckbyDate", SqlDbType.DateTime);
                    if (objAccessoryDebitNote.QtyCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objAccessoryDebitNote.QtyCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        objAccessoryDebitNote.DebitNoteId = Convert.ToInt32(outParam.Value);
                    else
                        objAccessoryDebitNote.DebitNoteId = -1;

                    foreach (FabricDebitNoteParticulars objDebitNoteParticulars in objAccessoryDebitNote.FabricDebitNoteParticularsList)
                    {
                        Save_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, objAccessoryDebitNote.DebitNoteId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }
        private int Save_Accessory_DebitNotePartyCulars(FabricDebitNoteParticulars objDebitNoteParticulars, int DebitNoteId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Fabric_DebitNoteList";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.DebitNoteParticularId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Particulars", SqlDbType.VarChar);
            param.Value = objDebitNoteParticulars.ParticularName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.DebitQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objDebitNoteParticulars.DebitRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "SAVE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsExtraQty", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.IsExtraQty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric_PO_DebitNote_SRVID", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.Fab_DebitNote_SRVID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }
        public DataSet GetFabricCreditNoteList(int SupplierPoId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "USP_Get_FabricCreditNote";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_LIST";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public List<Fabric_Srv_Bill> GetFabric_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID) //for debit note list
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_Fabric_Credit_Srv_Bill";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitnoteID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Fabric_Srv_Bill> Fabric_Srv_BillCollection = new List<Fabric_Srv_Bill>();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fabric_Srv_Bill objFabric_Srv_Bill = new Fabric_Srv_Bill();

                        objFabric_Srv_Bill.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objFabric_Srv_Bill.BillDetails = (reader["BillDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillDetails"]);

                        objFabric_Srv_Bill.isPartyBillOlderThan3Months = (reader["isPartyBillOlderThan3Months"] == DBNull.Value) ? false : Convert.ToBoolean(reader["isPartyBillOlderThan3Months"]);

                        Fabric_Srv_BillCollection.Add(objFabric_Srv_Bill);
                    }
                }

                return Fabric_Srv_BillCollection;
            }
        }

        public List<Fabric_Srv_Bill> GetFabric_Srv_Bill_DropDownList_Creditnote(int SupplierPoId, int DebitnoteID) //for credit note list
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_Fabric_Credit_Srv_Bill_CreditNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitnoteID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Fabric_Srv_Bill> Fabric_Srv_BillCollection = new List<Fabric_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fabric_Srv_Bill objFabric_Srv_Bill = new Fabric_Srv_Bill();

                        objFabric_Srv_Bill.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objFabric_Srv_Bill.BillDetails = (reader["BillDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillDetails"]);

                        Fabric_Srv_BillCollection.Add(objFabric_Srv_Bill);
                    }
                }

                return Fabric_Srv_BillCollection;
            }
        }
        public List<Fabric_Srv_Bill> Get_Credit_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID, string flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_Fabric_Srv_Credit_Bill";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = DebitnoteID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Fabric_Srv_Bill> Fabric_Srv_BillCollection = new List<Fabric_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fabric_Srv_Bill objFabric_Srv_Bill = new Fabric_Srv_Bill();

                        objFabric_Srv_Bill.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objFabric_Srv_Bill.BillDetails = (reader["BillDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillDetails"]);

                        Fabric_Srv_BillCollection.Add(objFabric_Srv_Bill);
                    }
                }

                return Fabric_Srv_BillCollection;
            }
        }
        public FabricDebitNoteCls Get_FabCreditNote(int SupplierPoId, int DebitNoteId)
        {
            FabricDebitNoteCls objAccessoryDebitNote = new FabricDebitNoteCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_FabricCreditNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_HEADER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryDebitNote.DebitNoteId = (reader["CreditNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CreditNote_Id"]);
                        objAccessoryDebitNote.Debptid = (reader["debptid"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["debptid"]);
                        objAccessoryDebitNote.DebitNoteNumber = (reader["CreditNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreditNoteNumber"]);
                        objAccessoryDebitNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessoryDebitNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryDebitNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryDebitNote.PoDate = (reader["PoDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PoDate"]);
                        objAccessoryDebitNote.ReturnChallanNumber = (reader["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReturnChallanNumber"]);
                        objAccessoryDebitNote.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objAccessoryDebitNote.DebitNoteDate = (reader["CreditNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreditNoteDate"]);
                        objAccessoryDebitNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);
                        objAccessoryDebitNote.IGST = (reader["IGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["IGST"]);
                        objAccessoryDebitNote.CGST = (reader["CGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["CGST"]);
                        objAccessoryDebitNote.SGST = (reader["SGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SGST"]);
                        objAccessoryDebitNote.QtyCheckedDate = (reader["CheckbyDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CheckbyDate"]);
                        objAccessoryDebitNote.QtyCheckedBy = (reader["Checkby"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Checkby"]);
                        objAccessoryDebitNote.GSTNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);//new line
                        objAccessoryDebitNote.Address = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);



                    }
                }
                reader.Dispose();
                objAccessoryDebitNote.FabricDebitNoteParticularsList = FabricDebitNoteParticularss(SupplierPoId, DebitNoteId, cnx);

                return objAccessoryDebitNote;
            }
        }
        private List<FabricDebitNoteParticulars> FabricDebitNoteParticularss(int SupplierPoId, int DebitNoteId, SqlConnection cnx)
        {

            string cmdText = "USP_Get_FabricCreditNote";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
            param.Value = SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "DEBITNOTE_PARTICULAR";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataReader reader1;

            reader1 = cmd.ExecuteReader();

            List<FabricDebitNoteParticulars> DebitNoteParticularsCollection = new List<FabricDebitNoteParticulars>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                    objDebitNoteParticulars.DebitNoteId = (reader1["CreditNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["CreditNote_Id"]);
                    objDebitNoteParticulars.DebitNoteParticularId = (reader1["CreditNote_Particulers_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["CreditNote_Particulers_Id"]);
                    objDebitNoteParticulars.ParticularName = (reader1["Particulers"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["Particulers"]);
                    objDebitNoteParticulars.DebitQuantity = (reader1["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Quantity"]);
                    objDebitNoteParticulars.DebitRate = (reader1["Rate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader1["Rate"]);

                    DebitNoteParticularsCollection.Add(objDebitNoteParticulars);
                }
            }

            return DebitNoteParticularsCollection;
        }
        public int Update_Fabric_credit_DebitNotePartyCulars(FabricDebitNoteParticulars objDebitNoteParticulars, int UserId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Fabric_CreditNotePartyCulars";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteParticularId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulars", SqlDbType.VarChar);
                    param.Value = objDebitNoteParticulars.ParticularName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();


                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }
        public int Save_Fabric_credit_DebitNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Fabric_CreditNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.DebitNoteDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.DebitNoteDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.PartyBillId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnChallanNo", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.ReturnChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.ChallanDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IGST", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.IGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CGST", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.CGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SGST", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.SGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalAmount", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.TotalAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnDebitNoteId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        objAccessoryDebitNote.DebitNoteId = Convert.ToInt32(outParam.Value);
                    else
                        objAccessoryDebitNote.DebitNoteId = -1;

                    foreach (FabricDebitNoteParticulars objDebitNoteParticulars in objAccessoryDebitNote.FabricDebitNoteParticularsList)
                    {
                        Save_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, objAccessoryDebitNote.DebitNoteId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }
        public int Save_fabric_CreditNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Fabric_CreditNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.DebitNoteDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.DebitNoteDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillId", SqlDbType.Int);

                    param.Value = objAccessoryDebitNote.PartyBillId;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnChallanNo", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.ReturnChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.ChallanDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.IGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.CGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.SGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalAmount", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.TotalAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebptID", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.Debptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnDebitNoteId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    param = new SqlParameter("@Checkby", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.QtyCheckedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckbyDate", SqlDbType.DateTime);
                    if (objAccessoryDebitNote.QtyCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objAccessoryDebitNote.QtyCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        objAccessoryDebitNote.DebitNoteId = Convert.ToInt32(outParam.Value);
                    else
                        objAccessoryDebitNote.DebitNoteId = -1;

                    foreach (FabricDebitNoteParticulars objDebitNoteParticulars in objAccessoryDebitNote.FabricDebitNoteParticularsList)
                    {
                        Save_Fabric_CreditNotePartyCulars(objDebitNoteParticulars, objAccessoryDebitNote.DebitNoteId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }
        private int Save_Fabric_CreditNotePartyCulars(FabricDebitNoteParticulars objDebitNoteParticulars, int DebitNoteId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Fabric_CreditNotePartyCulars";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.DebitNoteParticularId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Particulars", SqlDbType.VarChar);
            param.Value = objDebitNoteParticulars.ParticularName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.DebitQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objDebitNoteParticulars.DebitRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "SAVE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }
        public DataSet Getbills(int SupplierPoId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();

                string cmdText = "Usp_Getbills";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                //DataTable ds = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                cnx.Close();
                return ds;
            }
        }
        public DataTable GetEventOccurence()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "DDL";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetEventOccurenceDetails(int MeetingSchedule_Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingSchedule_Id", SqlDbType.Int);
                param.Value = MeetingSchedule_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable SaveBiplMeetingInfo(int MeetingSchedule_Id, int MeetingCategory_Id, string MeetingName, int TimeZone, int Month, int Day, string Time, int IsManual, int Manual_TimeZone, int Manual_Month, int Manual_Day, string Manual_Time, string Participate, string Description, int Years, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "INSERT";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingSchedule_Id", SqlDbType.Int);
                param.Value = MeetingSchedule_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingCategory_Id", SqlDbType.Int);
                param.Value = MeetingCategory_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingName", SqlDbType.VarChar);
                param.Value = MeetingName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TimeZone", SqlDbType.Int);
                if (TimeZone == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = TimeZone;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                if (Month == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Month;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Day", SqlDbType.Int);
                if (Day == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Day;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Time", SqlDbType.VarChar);
                if (Time == "")
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Time;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsManual", SqlDbType.Int);
                param.Value = IsManual;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Manual_TimeZone", SqlDbType.Int);
                if (Manual_TimeZone == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Manual_TimeZone;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Manual_Month", SqlDbType.Int);
                if (Manual_Month == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Manual_Month;
                }


                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Manual_Time", SqlDbType.VarChar);
                if (Manual_Time == "")
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Manual_Time;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Manual_Day", SqlDbType.VarChar);
                if (Manual_Day == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Manual_Day;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Participate", SqlDbType.VarChar);
                param.Value = Participate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = Description;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Years", SqlDbType.Int);
                if (Years == 0)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Years;
                }
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable MeetingNameDuplicateCheck(string flag, int MeetingSchedule_Id, string MeetingName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingSchedule_Id", SqlDbType.Int);
                param.Value = MeetingSchedule_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingName", SqlDbType.VarChar);
                param.Value = MeetingName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable MeetingDaily(string flag, int MeetingScheduleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingSchedule_Id", SqlDbType.VarChar);
                param.Value = MeetingScheduleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable MAILUPDATE(string flag, int MeetingSchedule_Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MeetingSchedule_Id", SqlDbType.Int);
                param.Value = MeetingSchedule_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable MeetingHolidayCheck(string flag, DateTime emaildate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMeetingEventDeatils";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EmailDay", SqlDbType.DateTime);
                param.Value = emaildate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public bool IsCheckPermissionCuttingIssue(int OrderDetailID, int Fabric_QualityID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_CheckPermissionCuttingIssue";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExfactoryPermission = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric_QualityID", SqlDbType.Int);
                    param.Value = Fabric_QualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExfactoryPermission);
                    int a = Convert.ToInt32(dsCheckExfactoryPermission.Tables[0].Rows[0]["Permission"]);
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

        public int SaveGSAdmin(int GSM, float KgToMeter, int MtrToGrams, string Flag, int UserId)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GSAdmin";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GSM", SqlDbType.Int);
                param.Value = GSM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@KgToMeter", SqlDbType.Float);
                param.Direction = ParameterDirection.Input;
                param.Value = KgToMeter;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MtrToGrams", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = MtrToGrams;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = MtrToGrams;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }

        public DataSet GetGSAdmin()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GSAdmin";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "GetGSAdmin";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }

        }
        public int DeleteGSAdmin(int ConvertGSMkgMtrId)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GSAdmin";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Delete";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ConvertGSMkgMtrId", SqlDbType.Int);
                param.Value = ConvertGSMkgMtrId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();
            }
            return Isave;
        }
        public DataSet GetVaSupplierQoutationEmbellishment(string flag, int UserID, string search, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationDayed(string flag, int UserID, string search, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotationDayed";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        public DataSet GetVaSupplierQoutationPrint(string flag, int UserID, string search, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotationPrint";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStyleBasedVA(string flag, int UserID, string search)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierQuataionOtherStyleVA";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetails(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetailsStyleVA(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierQuataionOtherStyleVA";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetailsPrint(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetailsdayed(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotationDayed";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetailsstyle(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierQuataionOtherStyleVA";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplier(string flag, int vaID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@VAID", SqlDbType.Int);
                param.Value = vaID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetOtherVaSupplierQoutation(string flag, int UserID, string search, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierQuataionOtherVA";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataSet GetVaSupplierQoutationStageDetailsNoneStyleVA(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetVaSupplierQuotation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VAtypes", SqlDbType.VarChar);
                param.Value = VAtypes;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetFabricWastageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetWastageDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQuality", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetFabricPrintWastageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails, int CurrentStage, int PreviousStage, bool IsStyleSpecfic, int styleid, int stage1, int stage2, int stage3, int stage4)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetWastageDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQuality", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStage", SqlDbType.Int);
                param.Value = CurrentStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Bit);
                param.Value = IsStyleSpecfic;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrviousStage", SqlDbType.Int);
                param.Value = PreviousStage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage1", SqlDbType.Int);
                param.Value = stage1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage2", SqlDbType.Int);
                param.Value = stage2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage3", SqlDbType.Int);
                param.Value = stage3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage4", SqlDbType.Int);
                param.Value = stage4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public int UpdateFabricWastageShrinkageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails, int OrderDetailID, int FabType, int VAID,
            decimal Stage1_Wastage, decimal Stage1_Shrinkage, decimal Stage2_Wastage, decimal Stage2_Shrinkage,
            decimal Stage3_Wastage, decimal Stage3_Shrinkage, decimal Stage4_Wastage, decimal Stage4_Shrinkage,
            decimal FabQty, decimal CutWastage, decimal TotalwithCutWastage, decimal hdnavg, decimal CutWastagee)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_GetWastageDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQuality", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabType", SqlDbType.Int);
                param.Value = FabType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@VAID", SqlDbType.Int);
                param.Value = VAID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ContractQty", SqlDbType.Decimal);
                param.Value = FabQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage1_Wastage", SqlDbType.Float);
                if (Stage1_Wastage > 0)
                    param.Value = Stage1_Wastage;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage1_Shrinkage", SqlDbType.Float);

                if (Stage1_Shrinkage > 0)
                    param.Value = Stage1_Shrinkage;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2_Wastage", SqlDbType.Float);
                if (Stage2_Wastage > 0)
                    param.Value = Stage2_Wastage;
                else
                    param.Value = DBNull.Value;


                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2_Shrinkage", SqlDbType.Float);
                if (Stage2_Shrinkage > 0)
                    param.Value = Stage2_Shrinkage;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3_Wastage", SqlDbType.Float);
                if (Stage3_Wastage > 0)
                    param.Value = Stage3_Wastage;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3_Shrinkage", SqlDbType.Float);
                if (Stage3_Shrinkage > 0)
                    param.Value = Stage3_Shrinkage;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4_Wastage", SqlDbType.Float);

                if (Stage4_Wastage > 0)
                    param.Value = Stage4_Wastage;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4_Shrinkage", SqlDbType.Float);
                if (Stage4_Shrinkage > 0)
                    param.Value = Stage4_Shrinkage;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWastage", SqlDbType.Float);
                param.Value = CutWastage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TotalwithCutWastage", SqlDbType.Float);
                param.Value = TotalwithCutWastage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@hdnavg", SqlDbType.Float);
                param.Value = hdnavg;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWastagee", SqlDbType.Float);
                param.Value = CutWastagee;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();
            }
            return Isave;
        }
        public DataTable GetFabricVAWastage(string flag, string flagOption, int Qty, int VAID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetWastageDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ContractQty", SqlDbType.Int);
                param.Value = Qty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
                param.Value = VAID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        //02052023
        public DataTable GetFabricCutWastagePermission(int LoggedInUserDesignationID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricCutWastagePermission";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@LoggedInUserDesignationID", SqlDbType.Int);
                param.Value = LoggedInUserDesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);               


                DataTable dsFabric = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetMaximumCutwastage()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetMAximumCutWastage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dsCutWastage = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsCutWastage);
                return dsCutWastage;
            }
        }
        public DataSet GetFabricpurchasedSupplierRFD(string flag, string flagoption, int FabQualityID = 0, int FabricMasterID = 0, string potype = "", int SuppliermasterID = 0, int MasterPoID = 0, string FabricDetails = "", int CurrentStageNumber = 0, int PreviousstageNumber = 0, int styleid = 0, bool IsStyleSpecific = false, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplierDetails_RFD";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricMasterID", SqlDbType.Int);
                param.Value = FabricMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Potype", SqlDbType.VarChar);
                param.Value = potype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                param.Value = SuppliermasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MasterPoID", SqlDbType.Int);
                param.Value = MasterPoID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@colorprintdetail", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Value = CurrentStageNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Value = PreviousstageNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Int);
                param.Value = IsStyleSpecific;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage1", SqlDbType.Int);
                param.Value = stage1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage2", SqlDbType.Int);
                param.Value = stage2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage3", SqlDbType.Int);
                param.Value = stage3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@stage4", SqlDbType.Int);
                param.Value = stage4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }
        public DataTable GetFabFourPointexcessqty(int SupplierPO_Id, int InspectionID, int Flag, int StockQty)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Fabric_Stock_Qty_Update_ToRaise_DebitNote";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InspectionID", SqlDbType.Int);
                param.Value = InspectionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StockQty", SqlDbType.Int);
                param.Value = StockQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        //add code by bharat on 9-Sep-20

        public List<Un_RagisterFabric> GetUnRagisterFabQual()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                SqlParameter param;
                cmdText = "Usp_UnRagisterFabrQuality";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Get";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                List<Un_RagisterFabric> UnRagisterFabCollection = new List<Un_RagisterFabric>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Un_RagisterFabric objUnRagisterFab = new Un_RagisterFabric();

                        objUnRagisterFab.TradeName = (reader["TradeName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TradeName"]);
                        objUnRagisterFab.Gsm = (reader["GSM"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSM"]);
                        objUnRagisterFab.CountConstruction = (reader["CountConstruction"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountConstruction"]);
                        objUnRagisterFab.CostWidth = (reader["CostWidth"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["CostWidth"]);
                        objUnRagisterFab.FinishRate = (reader["FinishedRate"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["FinishedRate"]);

                        UnRagisterFabCollection.Add(objUnRagisterFab);
                    }
                }

                return UnRagisterFabCollection;
            }

        }
        //new added on 12 Jan 2021 start
        public DataTable Getbipladdress(string Name)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                DataTable dtAddress = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetBiplAddress";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAddress);

                //DataTable dtOrderContracts = dsInlineTopSection.Tables[0];               

                return dtAddress;
            }

        }
        //new added on 12 Jan 2021 end
        public int SaveUnRagisterFabQualityData(Un_RagisterFabric objUnRagFabCo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "Usp_UnRagisterFabrQuality";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "Costing";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = objUnRagFabCo.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                    param.Value = objUnRagFabCo.CountConstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSM", SqlDbType.VarChar);
                    param.Value = objUnRagFabCo.Gsm;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostWidth", SqlDbType.Decimal);
                    param.Value = objUnRagFabCo.CostWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishRate", SqlDbType.Decimal);
                    param.Value = objUnRagFabCo.FinishRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }


                return count;
            }
        }

        // Added By Sanjeev  
        public static DataTable DataTableToList<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public DataSet GetfabricViewdetailsNew(string flag, string flagoption, int FabQualityID = 0, int SupplierCount = 0, string fabricDeatils = "", string searchtxt = "", int SupplierPO = 0, int CurrentStage = 0, int PreviousStage = 0, bool IsStylespecific = false, int StyleID = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int SortBy = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_GetFabricOrderSupplierNew";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                param.Value = flagoption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricDeatils;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierCount", SqlDbType.Int);
                param.Value = SupplierCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO", SqlDbType.Int);
                param.Value = SupplierPO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchtxt", SqlDbType.VarChar);
                param.Value = searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Stage1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage1 > 0)
                    param.Value = stage1;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage2 > 0)
                    param.Value = stage2;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage3 > 0)
                    param.Value = stage3;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (stage4 > 0)
                    param.Value = stage4;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CurrenStage", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (CurrentStage > 0)
                    param.Value = CurrentStage;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreviousStage", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (PreviousStage > 0)
                    param.Value = PreviousStage;
                else
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleida", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@IsStyleSpecific", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = IsStylespecific;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SortBy", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = SortBy;
                cmd.Parameters.Add(param);



                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                return dsFabric;
            }
        }

        public bool FabricOrderAllUpdateToProc(string Flag, string FlagOption, List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets)
        {

            DataTable FabricOrderAllUpdate = DataTableToList<FabricGroupAdmin.FabricOrderAllUpdate>(Fabdets);

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetFabricOrderSupplierNew";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                    param.Value = FlagOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricOrderAllUpdate", SqlDbType.Structured);
                    param.TypeName = "dbo.FabricOrderAllUpdate";
                    param.Value = FabricOrderAllUpdate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }


        public string[] GetDetailsForMail(string po_number, string flag)
        {
            string TradeName = "", SupplierName = "", ReceivedQty = "", Rate = "", ETA = "", Order_text = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "usp_Get_Details_For_POMail";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@po_number", SqlDbType.VarChar);
                param.Value = po_number;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TradeName = (reader["TradeName"] == DBNull.Value) ? "" : Convert.ToString(reader["TradeName"]);
                        SupplierName = (reader["SupplierName"] == DBNull.Value) ? "" : Convert.ToString(reader["SupplierName"]);
                        ReceivedQty = (reader["ReceivedQty"] == DBNull.Value) ? "0" : Convert.ToString(reader["ReceivedQty"]);
                        Rate = (reader["Rate"] == DBNull.Value) ? "0" : Convert.ToString(reader["Rate"]);
                        ETA = (reader["ETA"] == DBNull.Value) ? "0" : Convert.ToString(reader["ETA"]);
                        Order_text = (reader["Order_text"] == DBNull.Value) ? "" : Convert.ToString(reader["Order_text"]);

                    }
                }

                cnx.Close();
            }

            return new string[] { TradeName.ToString(), SupplierName.ToString(), ReceivedQty.ToString(), Rate.ToString(), ETA.ToString(), Order_text.ToString() };
        }

        public string[] GetReturnedChallanQty(string Flag, string ChallanNumber)
        {
            string ReturnedChallanQty = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "Usp_GetFabricIssueDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        ReturnedChallanQty = (reader["ReturnedChallanQty"] == DBNull.Value) ? "0" : Convert.ToString(reader["ReturnedChallanQty"]);

                    }
                }

                cnx.Close();
            }

            return new string[] { ReturnedChallanQty.ToString() };
        }

        public string CheckIfChallanNumberExist(string ChallanNumber, int ReturnQty)
        {
            string Result = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "Usp_CheckIfChallanNumberExist";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReturnQty", SqlDbType.Int);
                param.Value = ReturnQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Result = (reader["Result"] == DBNull.Value) ? "" : Convert.ToString(reader["Result"]);
                    }
                }

                cnx.Close();
            }

            return Result;
        }



        // End
    }

}





