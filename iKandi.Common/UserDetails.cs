using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.Common
{
    public class UserDetails 
    {
        public int GetUserId(string UserName)
        {
            int UserId =0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
               

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_GetUserIdByUserName";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = UserName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserId = (reader["UserID"] == null) ? -1 : Convert.ToInt32(reader["UserID"]);
                    
                }
                cnx.Close();
            }

            return UserId;
        }

        public int GetClientUserId(string UserName)
        {
            int UserId = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_GetClientUserId_ByUserName";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = UserName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserId = (reader["UserID"] == null) ? -1 : Convert.ToInt32(reader["UserID"]);

                }
                cnx.Close();
            }

            return UserId;
        }
    }
}
