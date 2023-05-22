using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace iKandi.DAL
{
    public class BaseDataProvider
    {
        #region Properties

        public SessionInfo LoggedInUser
        {
            get;
            set;
        }

        #endregion

        #region Ctor(s)

        public BaseDataProvider()
        {
        }

        public BaseDataProvider(SessionInfo LoggedInUser)
        {
            this.LoggedInUser = LoggedInUser;

            if (this.LoggedInUser == null || this.LoggedInUser.UserData == null)
            {
                // TODO: For testing, remove it after testing
                this.LoggedInUser = new SessionInfo();
                this.LoggedInUser.UserData = new User();
                this.LoggedInUser.UserData.UserID = 1;
            }
        }

        #endregion


        #region Methods

        public SqlCommand SqlCommand(String cmdText, SqlConnection cnx, QueryType qryType)
        {
            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            
            //Check if procedure is for insert or update
            if (qryType == QueryType.Insert)
            {
                SqlParameter param1 = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;               
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
                
                param1 = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
            }
            else if (qryType == QueryType.Update)
            {
                SqlParameter param1 = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
            }

            return cmd;
        }

        public SqlCommand SqlCommand(String cmdText, SqlConnection cnx, SqlTransaction sqlTran, QueryType qryType)
        {
            SqlCommand cmd = new SqlCommand(cmdText, cnx, sqlTran);
            
            //Check if procedure is for insert or update
            if (qryType == QueryType.Insert)
            {
                SqlParameter param1 = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);

            }
            else if (qryType == QueryType.Update)
            {
                SqlParameter param1 = new SqlParameter("UpdatedBy", SqlDbType.Int);
                param1.Value = this.LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
            }

            return cmd;
        }

        public int GetInt(object obj)
        {
            if (obj == DBNull.Value)
                return 0;
            return Convert.ToInt32(obj);
        }

        public double GetDouble(object obj)
        {
            if (obj == DBNull.Value)
                return 0;
            return Convert.ToDouble(obj);
        }

        public string GetString(object obj)
        {
            if (obj == DBNull.Value)
                return "";
            return Convert.ToString(obj);
        }
        #endregion
    }

}
