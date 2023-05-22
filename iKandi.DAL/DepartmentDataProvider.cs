using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class DepartmentDataProvider: BaseDataProvider
    {
        #region Ctor(s)

        public DepartmentDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<Department> GetDepartmentsByCompany(int CompanyID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_departments_get_department_by_company_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@CompanyId", SqlDbType.Int);
                param.Value = CompanyID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    Department dept = new Department();

                    dept.DepartmentID = Convert.ToInt32(reader["Id"]);
                    dept.Name = Convert.ToString(reader["Name"]);
                    dept.CompanyID = CompanyID;

                    departments.Add(dept);
                }

                cnx.Close();

                return departments;
            }
        }
        public List<Department> GetDepartmentsByCompany_new(int CompanyID)
        {
          // Create a connection object and data adapter
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create a SQL command object
            string cmdText = "sp_departments_get_department_by_company_id_new";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            // Set the command type to StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters
            SqlParameter param;
            param = new SqlParameter("@CompanyId", SqlDbType.Int);
            param.Value = CompanyID;
            param.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
              Department dept = new Department();

              dept.DepartmentID = Convert.ToInt32(reader["Id"]);
              dept.Name = Convert.ToString(reader["Name"]);
              dept.CompanyID = CompanyID;

              departments.Add(dept);
            }

            cnx.Close();

            return departments;
          }
        }
        public bool AddUserDepartment(int UserID, int DesignationID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_user_group_insert_user_group";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;               
                
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        public bool DeleteUserCDA(int UserID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_delete_cda_by_user_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        public bool DeleteUserDepartment(int UserID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_user_group_delete_user_group_by_user_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }


        public List<int> GetUserDepartments(int UserID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_user_group_get_user_groups_by_user_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<int> groups = new List<int>();
                     
                while (reader.Read())
                {
                    groups.Add(Convert.ToInt32(reader["DepartmentID"]));
                }

                cnx.Close();

                return groups;

            }
        }
        //abhishek on 8/2/2017
        public List<Department> GetSerialNumber(string StyleNumber)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "Usp_getOrderByStyleNumber";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    Department dept = new Department();

                    dept.OrderID = Convert.ToInt32(reader["OrderID"]);
                    dept.SerialNumber = Convert.ToString(reader["SerialNumber"]);
                    //dept.CompanyID = CompanyID;

                    departments.Add(dept);
                }

                cnx.Close();

                return departments;
            }
        }
        //abhishek on 5/6/2018
        public string ValidateFactoryWorkSpace(string FactoryWorkSpace)
        {        
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            string[] aa={};
            cnx.Open();           
            string cmdText = "usp_GetOB_Operation_Validate";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);        
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut; 
         
            SqlParameter param;
            param = new SqlParameter("@SectionName", SqlDbType.VarChar);
            param.Value = "VALIDATE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Q", SqlDbType.VarChar);
            param.Value = FactoryWorkSpace;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);                  
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string str = dt.Rows[0]["result"].ToString();
            cnx.Close();
            return str;
          }
        }
        public List<Department> GetPrintColorQty(int OrderID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "Usp_getOrderByStyleNumber";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    Department dept = new Department();

                    dept.OrderDetailsID = Convert.ToInt32(reader["OrderDetailsID"]);
                    dept.PrintColorQty = Convert.ToString(reader["PrintColorQty"]);
                    //dept.CompanyID = CompanyID;

                    departments.Add(dept);
                }

                cnx.Close();

                return departments;
            }
        }


        public DataTable GetSerialNumbercluster(string StyleNumber)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                

                // Create a SQL command object
                string cmdText = "Usp_getOrderByStyleNumber_for_bind";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);           

                DataTable dt = new DataTable();


                adapter.Fill(dt);
                cnx.Close();
                return dt;
            }
        }

        public DataTable GetPrintColorQtycluster(int OrderID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

               

                // Create a SQL command object
                string cmdText = "Usp_getOrderByStyleNumber_for_bind";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                adapter.Fill(dt);
                cnx.Close();
                return dt;

               

                
            }
        }
        public string Getfinishingsam(int OrderdetailsID = 0, int OrderID = 0, int UnitID = 0, string Flag = "")
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetClusterObSAM";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderdetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();


                adapter.Fill(dt);
                string str = dt.Rows[0]["result"].ToString();
                cnx.Close();
                return str;
            }
        }
        //public int getUsp_GetOderID(int flag, string serialNumber = "")
        //{

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        int result;
        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;
        //        cmdText = "Usp_GetOderID";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        param.Value = flag;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
        //        param.Value = serialNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        result = cmd.ExecuteNonQuery();
        //        return result;
        //    }
        //}
        //public string getUsp_GetOderID(int flag, string serialNumber = "")
        //{

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();

        //        string cmdText = "Usp_GetOderID";

        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlParameter param;
        //        param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        param.Value = flag;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
        //        param.Value = serialNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        DataTable dt = new DataTable();


        //        adapter.Fill(dt);
        //        string str = dt.Rows[0]["OrderID"].ToString();
        //        cnx.Close();
        //        return str;
        //    }
        //}
        public List<Department> getUsp_GetOderID(string flag, string serialNumber = "")
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "Usp_GetOderID";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                param.Value = serialNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    Department dept = new Department();

                    dept.OrderID = Convert.ToInt32(reader["OrderID"]);
                    //dept.PrintColorQty = Convert.ToString(reader["PrintColorQty"]);
                    //dept.CompanyID = CompanyID;

                    departments.Add(dept);
                }

                cnx.Close();

                return departments;
            }
        }
        public List<Department> getUsp_GetOderIDnew(string flag, string serialNumber = "")
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "Usp_GetOderID_get";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                param.Value = serialNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    Department dept = new Department();

                    dept.OrderID = Convert.ToInt32(reader["OrderID"]);
                    //dept.PrintColorQty = Convert.ToString(reader["PrintColorQty"]);
                    //dept.CompanyID = CompanyID;

                    departments.Add(dept);
                }

                cnx.Close();

                return departments;
            }
        }
        
    }
}
