using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class EntityBaseDataProvider : BaseDataProvider
    {
        #region Ctor(s)
        public EntityBaseDataProvider()
        {
        }

        public EntityBaseDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Method
        protected void InsertDocCheckerDetail(List<string> Checkers, int Id, string DocCheckType, SqlConnection cnx, SqlTransaction transaction)
        {
            string checkers = Checkers.Count < 1
                                                  ? ""
                                                  : string.Join(",", (from p in Checkers select p).ToArray());
            string cmdText = "sp_Insert_Update_doc_checker_details";

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@SrvId", SqlDbType.Int);
            param.Value = Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Checkers", SqlDbType.VarChar);
            param.Value = checkers;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DocCheckType", SqlDbType.VarChar);
            param.Value = DocCheckType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        protected void InsertDocCheckerDetail(List<string> Checkers, int Id, string DocCheckType, SqlConnection cnx)
        {
            InsertDocCheckerDetail(Checkers, Id, DocCheckType, cnx, null);
        }
        #endregion

        protected string GetString(object obj)
        {
            return obj == DBNull.Value ? "" : Convert.ToString(obj);
        }

        protected int GetInt(object obj)
        {
            return obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
        }

        protected double GetDouble(object obj)
        {
            return obj == DBNull.Value ? 0 : Convert.ToDouble(obj);
        }
    }
}
