using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using iKandi.Common.Entities;

namespace iKandi.DAL
{
    public class NotificationDataProvider : BaseDataProvider
    {
        //Gajendra Email Notification
        #region Ctor(s)

        public NotificationDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public void NotificationEmailHistory_Ins(NotificationEmailHistory NEH)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "NotificationEmailHistory_Ins";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = NEH.Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EmailID", SqlDbType.Int);
                param.Value = NEH.EmailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = (string.IsNullOrEmpty(NEH.OrderID)) ? "0" : NEH.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = NEH.OrderDetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                param.Value = NEH.Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OldBIPL", SqlDbType.Float);
                param.Value = NEH.OldBIPL;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = (string.IsNullOrEmpty(NEH.CostingID)) ? "0" : NEH.CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                param.Value = (string.IsNullOrEmpty(NEH.InspectionID.ToString())) ? "0" : NEH.InspectionID.ToString();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@EXFactoryDate", SqlDbType.DateTime);
                //param.Value = NEH.EXFactoryDate;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@ContractNo", SqlDbType.VarChar);
                //param.Value = NEH.ContractNo;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@LineItemNumber", SqlDbType.VarChar);
                //param.Value = NEH.LineItemNumber;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);               

                //param = new SqlParameter("@ManageDivisionID", SqlDbType.Int);
                //param.Value = NEH.ManageDivisionID;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }

        }
        //added by abhishek on 23/2/2016
        public DataSet GetDispatchEntryMailWeekName(int BuyingID = -1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();

                string cmdText = "Usp_GetCourier_Emails_daily";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BuyingID", SqlDbType.Int);
                param.Value = BuyingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);



                cnx.Close();
                return dt;
            }

        }
        //end by abhishek on 23/2/2016

        //added by raghvinder on 25-08-2020 starts
        public DataTable GetCourierDispatchListDate(DateTime CourierDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();
                
                string cmdText = "[dbo].[usp_Courier_Dispatch_List_Date]";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime2);
                param.Value = CourierDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }

        }

        public DataTable CourierDispatchListExists(DateTime CourierDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();

                string cmdText = "[dbo].[sp_CourierDispatchListExists]";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime2);
                param.Value = CourierDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }

        }
        //added by raghvinder on 25-08-2020 ended

        public DataSet GetpRODUCTMAIL(string reportname)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();

                string cmdText = "[dbo].[sp_GetReoprtEmail]";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@reportname", SqlDbType.VarChar);
                param.Value = reportname;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }

        }
        public DataSet GetSupplierNameMail(string SupplierName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();

                string cmdText = "sp_GetSupplierMail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = SupplierName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }

        }

        public string GetEmailSupplierByName(string Name)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))//For get
            {
                cnx.Open();
                string Email = "";
                string cmdText = "usp_GetEmailbySupplierName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object userNameObj = cmd.ExecuteScalar();
                Email = userNameObj != null ? userNameObj.ToString() : "";

                cnx.Close();
                return Email;
            }

        }
    }

}
