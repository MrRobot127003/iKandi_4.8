using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Data.SqlClient;


namespace iKandi.DAL
{
    public class DesignationDataProvider: BaseDataProvider
    {
        #region Ctor(s)

        public DesignationDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public List<UserDesignation> GetDesignationsByDepartment(int DepartmentID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_designations_get_designation_by_department_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<UserDesignation> departments = new List<UserDesignation>();

                while (reader.Read())
                {
                    UserDesignation dept = new UserDesignation();

                    dept.DesignationID = Convert.ToInt32(reader["Id"]);
                    dept.Name = Convert.ToString(reader["Name"]);
                    dept.DepartmentID = DepartmentID;

                    departments.Add(dept);
                }
                
                cnx.Close();

                return departments;
            }

        }
        public List<UserDesignation> GetDesignationsByDepartment_new(int DepartmentID)
        {
          // Create a connection object and data adapter
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create a SQL command object
            string cmdText = "sp_designations_get_designation_by_department_id_new";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            // Set the command type to StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters
            SqlParameter param;
            param = new SqlParameter("@DepartmentId", SqlDbType.Int);
            param.Value = DepartmentID;
            param.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserDesignation> departments = new List<UserDesignation>();

            while (reader.Read())
            {
              UserDesignation dept = new UserDesignation();

              dept.DesignationID = Convert.ToInt32(reader["Id"]);
              dept.Name = Convert.ToString(reader["Name"]);
              dept.DepartmentID = DepartmentID;

              departments.Add(dept);
            }

            cnx.Close();

            return departments;
          }

        }
    }
}
