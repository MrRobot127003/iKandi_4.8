using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class PermissionDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public PermissionDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Permission method

        /// <summary>
        /// insert permission....
        /// </summary>
        /// <returns></returns>
        public int InsertPermission(Permission objPermission)
        {
            int PermissionId = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_permission_insert";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                SqlParameter paramOut;

                paramOut = new SqlParameter("@oId", SqlDbType.Int);
                paramOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOut);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.UserID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.UserID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.DesignationID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.DesignationID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Read", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objPermission.Read;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Write", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objPermission.Write;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.ApplicationModuleID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.ApplicationModuleID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleColumnID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.ApplicationModuleColumnID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.ApplicationModuleColumnID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.DepartmentID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.DepartmentID;
                }
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                PermissionId = Convert.ToInt32(paramOut.Value);
                cnx.Close();
            }
            return PermissionId;
        }
        public DataTable GetDesignationByDepartId(int DepartMentId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_DesignationByDeptId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DepartId", SqlDbType.Int);
                param.Value = DepartMentId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }

        public DataTable GetSectionList()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_Section";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }
        public DataTable GetColumnBySectionId(int SectionID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_ColumnSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SectionID", SqlDbType.Int);
                param.Value = SectionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }
        public DataTable GetSectionIdBySection(string Section)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_SectionIdByName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Section", SqlDbType.VarChar);
                param.Value = Section;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet ds = new DataSet();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //adapter.Fill(ds);




                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;


            }

        }
        public DataTable GetColumnIdByColumn(string Column)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_ColumnIdByName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Column", SqlDbType.VarChar);
                param.Value = Column;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }
        public void InsertMOpermissionSet(List<MOPermissionForm> MOPermissionList, int DesigID)
        {
            if (MOPermissionList == null || MOPermissionList.Count < 1)
                return;
            string tbl = "<table>";
            foreach (var per in MOPermissionList)
            {
                tbl += "<DepartmentID>" + per.DepartmentId + "</DepartmentID>";
                tbl += "<DesignationID>" + per.DesignationId + "</DesignationID>";
                tbl += "<SectionID>" + per.SectionId + "</SectionID>";
                tbl += "<CoulmeID>" + per.ColumnId + "</CoulmeID>";
                tbl += "<PermisionRead>" + per.Read + "</PermisionRead>";
                tbl += "<PermisionWrite>" + per.Write + "</PermisionWrite>";

            }
            tbl += "</table>";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_InsertUpdateMoSectionCoulmeMapping";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                SqlParameter param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Value = tbl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Cnt", SqlDbType.VarChar);
                param.Value = MOPermissionList.Count;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.VarChar);
                param.Value = DesigID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }

        }
        public int InsertMOpermission(MOPermissionForm MOPermissionList)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                try
                {
                    cnx.Open();
                    const string cmdText = "sp_InsertMoSectionCoulmeMapping";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                    SqlParameter param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = MOPermissionList.DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesignationId", SqlDbType.Int);
                    param.Value = MOPermissionList.DesignationId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SectionId", SqlDbType.Int);
                    param.Value = MOPermissionList.SectionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColumnId", SqlDbType.Int);
                    param.Value = MOPermissionList.ColumnId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Read", SqlDbType.Bit);
                    param.Value = MOPermissionList.Read;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Write", SqlDbType.Bit);
                    param.Value = MOPermissionList.Write;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReadWrite", SqlDbType.Bit);
                    param.Value = MOPermissionList.AllReadWritePermission;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Comment by Ravi kumar on 23/2/2015 

                    //param = new SqlParameter("@Sorting", SqlDbType.VarChar);
                    //param.Value = MOPermissionList.Sorting;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@OrderBy1", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy1;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@OrderBy2", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy2;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@OrderBy3", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy3;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@OrderBy4", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy4;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@OrderBy5", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy5;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@OrderBy6", SqlDbType.Int);
                    //param.Value = MOPermissionList.OrderBy6;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    // End Comment by Ravi kumar on 23/2/2015 

                    param = new SqlParameter("@SalesView", SqlDbType.Bit);
                    param.Value = MOPermissionList.SalesView;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    id = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
                return id;
            }
        }
        public List<MOPermissionForm> GetMoPermissionList(int DesigId, int DeptId)
        {
            List<MOPermissionForm> PermissionList = new List<MOPermissionForm>();
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;
                    cmdText = "sp_GetMoPermissionList";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        MOPermissionForm MoPermission = new MOPermissionForm();
                        MoPermission.MoSectionCoulmeMappingID = dRow["MoSectionCoulmeMappingID"] == DBNull.Value ? 0 : Convert.ToInt32(dRow["MoSectionCoulmeMappingID"]);
                        MoPermission.DepartmentId = dRow["DepartmentID"] == DBNull.Value ? 0 : Convert.ToInt32(dRow["DepartmentID"]);
                        MoPermission.DepartmentName = dRow["DepartmentName"] == DBNull.Value ? "" : Convert.ToString(dRow["DepartmentName"]);
                        MoPermission.DesignationId = dRow["DesignationID"] == DBNull.Value ? 0 : Convert.ToInt32(dRow["DesignationID"]);
                        MoPermission.DesignationName = dRow["DesignationName"] == DBNull.Value ? "" : Convert.ToString(dRow["DesignationName"]);
                        MoPermission.Section = dRow["SectionID"] == DBNull.Value ? "" : Convert.ToString(dRow["SectionID"]);
                        MoPermission.SectionName = dRow["Section"] == DBNull.Value ? "" : Convert.ToString(dRow["Section"]);
                        MoPermission.Column = dRow["CoulmeID"] == DBNull.Value ? "" : Convert.ToString(dRow["CoulmeID"]);
                        MoPermission.ColumnName = dRow["ColumnName"] == DBNull.Value ? "" : Convert.ToString(dRow["ColumnName"]);

                        MoPermission.Read = dRow["PermisionRead"] == DBNull.Value ? false : Convert.ToBoolean(dRow["PermisionRead"]);
                        MoPermission.Write = dRow["PermisionWrite"] == DBNull.Value ? false : Convert.ToBoolean(dRow["PermisionWrite"]);
                        MoPermission.AllReadWritePermission = dRow["PermissionReadWrite"] == DBNull.Value ? false : Convert.ToBoolean(dRow["PermissionReadWrite"]);
                        //MoPermission.Sorting = dRow["Sorting"] == DBNull.Value ? "" : Convert.ToString(dRow["Sorting"]);
                        MoPermission.SalesView = dRow["SalesView"] == DBNull.Value ? false : Convert.ToBoolean(dRow["SalesView"]);
                        //MoPermission.OrderBy1 = dRow["OrderBy1"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy1"]);
                        //MoPermission.OrderBy2 = dRow["OrderBy2"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy2"]);
                        //MoPermission.OrderBy3 = dRow["OrderBy3"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy3"]);
                        //MoPermission.OrderBy4 = dRow["OrderBy4"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy4"]);
                        //MoPermission.OrderBy5 = dRow["OrderBy5"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy5"]);
                        //MoPermission.OrderBy6 = dRow["OrderBy6"] == DBNull.Value ? -1 : Convert.ToInt32(dRow["OrderBy6"]);

                        PermissionList.Add(MoPermission);
                    }

                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return PermissionList;
        }
        public DataTable getPermission()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_Permission";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }
        public void DeleteMoPermission(int DesignationId, int DepartmentId)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    const string cmdText = "sp_DeleteMoPermission";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                    SqlParameter param = new SqlParameter("@DesignationId", SqlDbType.Int);
                    param.Value = DesignationId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        /// <summary>
        /// Update permission....
        /// </summary>
        /// <returns></returns>

        public int UpdatePermission(Permission objPermission)
        {
            int PermissionId;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText;

                cmdText = "sp_permission_update";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.UserID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.UserID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.DesignationID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.DesignationID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Read", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objPermission.Read;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Write", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objPermission.Write;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.ApplicationModuleID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.ApplicationModuleID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleColumnID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.ApplicationModuleColumnID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.ApplicationModuleColumnID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                if (objPermission.DepartmentID == -1)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = objPermission.DepartmentID;
                }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objPermission.PermissionId;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                PermissionId = objPermission.PermissionId;
                cnx.Close();
            }
            return PermissionId;
        }

        public List<Permission> GetPermissionByUser(int UserID)
        {
            Permission permission = new Permission();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_permission_by_userid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Permission> permissions = new List<Permission>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;

            }

        }

        public List<Permission> GetPermissionByDesignation(int DesignationID)
        {
            Permission permission = new Permission();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_permission_by_designationid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Permission> permissions = new List<Permission>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }
                cnx.Close();

                return permissions;
            }
        }


        public List<Permission> GetPermissionByDepartment(int DepartmentID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_permission_by_departmentid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Permission> permissions = new List<Permission>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }

        }

        public List<Permission> GetColumnPermissionByUser(int UserID, int ApplicationModuleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_column_permission_by_user";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ApplicationModuleID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Permission> permissions = new List<Permission>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }

        }

        public List<Permission> GetColumnPermissionByDesignation(int DesignationID, int ApplicationModuleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_colunm_permission_by_designation";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ApplicationModuleID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Permission> permissions = new List<Permission>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }

        }

        public List<Permission> GetColumnPermissionByDepartment(int DepartmentID, int ApplicationModuleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_column_permission_by_department";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ApplicationModuleID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Permission> permissions = new List<Permission>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }


        }
        public DataTable GetDepartmentList()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_All_Department";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }
        public List<Permission> GetPermissions()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_permission_get_permissions";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<Permission> permissions = new List<Permission>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }

        }

        #endregion

        #region Private Methods

        private Permission ConvertToPermission(SqlDataReader reader)
        {
            Permission permission = new Permission();

            if (ColumnExist(reader, "ID"))
            {
                permission.PermissionId = (reader["ID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ID"]);
            }

            if (ColumnExist(reader, "UserID"))
            {
                permission.UserID = (reader["UserID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UserID"]);
            }

            if (ColumnExist(reader, "DepartmentID"))
            {
                permission.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DepartmentID"]);
            }

            if (ColumnExist(reader, "DesignationID"))
            {
                permission.DesignationID = (reader["DesignationID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DesignationID"]);
            }

            if (ColumnExist(reader, "Read"))
            {
                permission.Read = (reader["Read"] == DBNull.Value) ? false : Convert.ToBoolean(reader["Read"]);
            }
            if (ColumnExist(reader, "Write"))
            {
                permission.Write = (reader["Write"] == DBNull.Value) ? false : Convert.ToBoolean(reader["Write"]);
            }
            if (ColumnExist(reader, "ApplicationModuleID"))
            {
                permission.ApplicationModuleID = (reader["ApplicationModuleID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleID"]);
            }
            if (ColumnExist(reader, "Type"))
            {
                permission.PageType = (reader["Type"] == DBNull.Value) ? (PageType)(-1) : (PageType)Convert.ToInt32(reader["Type"]);
            }
            if (ColumnExist(reader, "ApplicationModuleColumnID"))
            {
                permission.ApplicationModuleColumnID = (reader["ApplicationModuleColumnID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ApplicationModuleColumnID"]);
            }
            if (ColumnExist(reader, "ApplicationModuleColumnName"))
            {
                permission.ApplicationModuleColumnName = (reader["ApplicationModuleColumnName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ApplicationModuleColumnName"]);
            }
            if (ColumnExist(reader, "ApplicationModuleName"))
            {
                permission.ApplicationModuleName = (reader["ApplicationModuleName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ApplicationModuleName"]);
            }

            if (ColumnExist(reader, "PhaseName"))
            {
                permission.PhaseName = Convert.ToString(reader["PhaseName"]);
            }

            if (ColumnExist(reader, "SubPhaseName"))
            {
                permission.SubPhaseName = (reader["SubPhaseName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SubPhaseName"]);
            }

            if (ColumnExist(reader, "PermissionType"))
            {
                permission.PermissionType = (reader["PermissionType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PermissionType"]);
            }

            return permission;
        }

        private bool ColumnExist(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
        //Added By Abhishek on 16/4/2015
        public DataTable GetOBSection()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetTechnicalSection";//ProcName about to change
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;

            }
        }
        public int SavePermissionByIds_OB(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_InsertUpdateOBPermission";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sectionid", SqlDbType.Int);
                    param.Value = SectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FormesID", SqlDbType.Int);
                    param.Value = FormsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionRead", SqlDbType.Int);
                    param.Value = PermissionRead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionWrite", SqlDbType.Int);
                    param.Value = PermissionWrite;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();


                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }
        public DataSet GetAllPermissionListById_OB(int DeptId, int DesigId, int sectionid, int columnId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetAllPermissionList_OB";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesigId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sectionid", SqlDbType.Int);
                param.Value = sectionid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@columnId", SqlDbType.Int);
                param.Value = columnId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }

        }
        //Added By Ashish on 3/3/2015
        public DataTable GetMoSection()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }

        }

        //Gajendra Permission 
        #region New Permission 

        public DataSet GetNewMoSection(int DeptId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "GetNewMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }

        }

        public DataSet GetNewTechnicalSection(int DeptId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "GetNewTechnicalSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }

        }
        public DataSet GetUserPermission(int DeptId, int DesignationID, int MainFormID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetUserPermission";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MainFormId", SqlDbType.Int);
                param.Value = MainFormID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }
        }

        public DataSet GetSOPPermission(int DeptId, int DesignationID, int ColumId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_SOP_Permission";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColumId", SqlDbType.Int);
                param.Value = ColumId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }
        }
        //ADDED BY RAGHVINDER ON 29-01-2021 START
        public DataSet GetAccessoryFourPointCheckPermission(int DeptId, int DesignationID, int ColumId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "uspAccessoryInspectionPermission";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColumId", SqlDbType.Int);
                param.Value = ColumId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }
        }
        //ADDED BY RAGHVINDER ON 29-01-2021 END

        //added by raghvinder on 08-09-2020 starts
        public DataSet GetMMRPermission(int DeptId, int DesignationID, int ApplicationModuleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_MMR_permission";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApplicationModuleID", SqlDbType.Int);
                param.Value = ApplicationModuleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }
        }
        public DataSet GetLoginActivate(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_Check_MMR_Activate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }
        }
        //added by raghvinder on 08-09-2020 ends
        public DataSet GetNewAllPermissionList_OB(int DeptId, int DesigId, int sectionid, int columnId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "GetNewAllPermissionList_OB";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesigId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sectionid", SqlDbType.Int);
                param.Value = sectionid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@columnId", SqlDbType.Int);
                param.Value = columnId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }

        }

        public int SaveOBPermissionNew(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "SaveOBPermissionNew";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sectionid", SqlDbType.Int);
                    param.Value = SectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FormesID", SqlDbType.Int);
                    param.Value = FormsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionRead", SqlDbType.Int);
                    param.Value = PermissionRead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionWrite", SqlDbType.Int);
                    param.Value = PermissionWrite;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }

        public List<Permission> GetPermissionsNew()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetPermissionsNew";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<Permission> permissions = new List<Permission>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permissions.Add(ConvertToPermission(reader));
                    }
                }

                cnx.Close();

                return permissions;
            }

        }
        #endregion
        public DataTable GetMoDesignation(int DeptId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[1];
                cnx.Close();
                return dt1;
            }

        }

        public int GetMoDeptcount(int DeptId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                int Count = 0;
                cmdText = "Usp_GetMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[2];
                Count = dt.Rows.Count;
                cnx.Close();
                return Count;
            }

        }


        public int GetMoSectionId(int DeptId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                int Count = 0;
                cmdText = "Usp_GetMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                Count = dt1.Rows.Count;
                cnx.Close();
                return Count;
            }

        }


        public DataTable GetAllPermissionList()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetAllPermissionList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return dt1;
            }

        }


        public DataSet GetAllPermissionListById(int DeptId, int DesigId, int sectionid, int columnId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetAllPermissionList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesigId", SqlDbType.Int);
                param.Value = DesigId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sectionid", SqlDbType.Int);
                param.Value = sectionid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@columnId", SqlDbType.Int);
                param.Value = columnId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];

                cnx.Close();
                return ds;
            }

        }



        public int SavePermissionByIds(int DeptId, int DesigId, int SectionId, int ColumnId, bool PermissionRead, bool PermissionWrite)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_InsertUpdateMoPermission";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sectionid", SqlDbType.Int);
                    param.Value = SectionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@columnId", SqlDbType.Int);
                    param.Value = ColumnId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionRead", SqlDbType.Int);
                    param.Value = PermissionRead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionWrite", SqlDbType.Int);
                    param.Value = PermissionWrite;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();


                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }


        public int SaveAllPermissionByIds(int DeptId, int DesigId, bool PermissionRead, bool PermissionWrite)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_InsertUpdateAllMoPermission";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@sectionid", SqlDbType.Int);
                    //param.Value = SectionId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@columnId", SqlDbType.Int);
                    //param.Value = ColumnId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionRead", SqlDbType.Int);
                    param.Value = PermissionRead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermissionWrite", SqlDbType.Int);
                    param.Value = PermissionWrite;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();


                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }

        // update By Ravi kumar on 29/10/16 from M.O filter Permission
        public int SaveMO_OrderByFilter(int DeptId, int DesigId, int OrderBy, int Flag)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_SaveMO_OrderByFilter";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DesigId", SqlDbType.Int);
                    param.Value = DesigId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderBy", SqlDbType.Int);
                    param.Value = OrderBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();


                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }


        public DataTable GetFilterPermissionById(int DeptId, int DesigId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetMoFilterPermissionById";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Value = DesigId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable ds = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                cnx.Close();
                return ds;
            }

        }

        public DataTable GetMoDesignationgrd1(int DeptId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_GetMoSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[3];
                cnx.Close();
                return dt1;
            }

        }

        public string GetStatusByOrderId(int OrderId)
        {
            string Result = "";
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_GetStatus";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    object result = cmd.ExecuteScalar();

                    Result = Convert.ToString(result);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }


        public int IsOrderConfirm(int OrderId)
        {
            int Result = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_IsOrderConfirm";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    object result = cmd.ExecuteScalar();

                    Result = Convert.ToInt32(result);
                    cnx.Close();


                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Result;
        }
    }
}
