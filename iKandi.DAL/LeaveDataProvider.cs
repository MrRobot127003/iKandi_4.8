using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class LeaveDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public LeaveDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<Leave> SearchLeaves(
            int pageSize,
            int startRecord,
            out int totalRecords,
            int month,
            int year,
            int leaveType,
            int leaveStatus,
            int employeeID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_leaves_search_leaves";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveType", SqlDbType.Int);
                param.Value = leaveType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveStatus", SqlDbType.Int);
                param.Value = leaveStatus;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EmployeeId", SqlDbType.Int);
                param.Value = employeeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Leave> leaves = new List<Leave>();

                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt64(reader["Id"]);

                    leave.Employee = new User();
                    leave.Employee.FirstName = Convert.ToString(reader["EmployeeName"]);
                    leave.Employee.UserID = Convert.ToInt32(reader["EmployeeID"]);
                    leave.Type = new LeaveType();
                    leave.Type.LeaveTypeID = Convert.ToInt32(reader["LeaveTypeID"]);
                    leave.Type.Name = Convert.ToString(reader["LeaveTypeName"]);
                    leave.FromDate = Convert.ToDateTime(reader["From"]);
                    leave.ToDate = Convert.ToDateTime(reader["To"]);
                    leave.Status = (LeaveStatus)Convert.ToInt32(reader["Status"]);
                    leave.AppliedTo = new User();
                    leave.AppliedTo.FirstName = Convert.ToString(reader["AppliedToName"]);
                    leave.AppliedTo.UserID = Convert.ToInt32(reader["AppliedTo"]);
                    leave.Reason = Convert.ToString(reader["Reason"]);
                    leave.ContactDetails = Convert.ToString(reader["ContactDetails"]);
                    leave.FromSession = Convert.ToInt32(reader["FromSession"]);
                    leave.ToSession = Convert.ToInt32(reader["ToSession"]);
                    leave.CC = Convert.ToString(reader["InformedPersonnel"]);
                    leave.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                    leave.ActionDate = Convert.ToDateTime(reader["ActionDate"]);
                    leaves.Add(leave);
                }
                reader.Close();
                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return leaves;
            }
        }



        public List<Leave> SearchLeavesByUserManagerRole(
          int pageSize,
          int startRecord,
          out int totalRecords,
          int month,
          int year,
          int leaveType,
          int leaveStatus,
          string employeeName,
          int userId)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_leaves_search_by_user_mgr_role";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveType", SqlDbType.Int);
                param.Value = leaveType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveStatus", SqlDbType.Int);
                param.Value = leaveStatus;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 256);
                param.Value = employeeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = userId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);






                SqlDataReader reader = cmd.ExecuteReader();

                List<Leave> leaves = new List<Leave>();

                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt64(reader["Id"]);
                    leave.Employee = new User();
                    leave.Employee.FirstName = Convert.ToString(reader["EmployeeName"]);
                    leave.Employee.UserID = Convert.ToInt32(reader["EmployeeID"]);
                    leave.Type = new LeaveType();
                    leave.Type.LeaveTypeID = Convert.ToInt32(reader["LeaveTypeID"]);
                    leave.Type.Name = Convert.ToString(reader["LeaveTypeName"]);
                    leave.FromDate = Convert.ToDateTime(reader["From"]);
                    leave.ToDate = Convert.ToDateTime(reader["To"]);
                    leave.Status = (LeaveStatus)Convert.ToInt32(reader["Status"]);
                    leave.AppliedTo = new User();
                    leave.AppliedTo.FirstName = Convert.ToString(reader["AppliedToName"]);
                    leave.AppliedTo.UserID = Convert.ToInt32(reader["AppliedTo"]);
                    leave.Reason = Convert.ToString(reader["Reason"]);
                    leave.ContactDetails = Convert.ToString(reader["ContactDetails"]);
                    leave.FromSession = Convert.ToInt32(reader["FromSession"]);
                    leave.ToSession = Convert.ToInt32(reader["ToSession"]);
                    leave.CC = Convert.ToString(reader["InformedPersonnel"]);
                    leave.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                    leave.ActionDate = Convert.ToDateTime(reader["ActionDate"]);
                    leave.NetLeaves = (reader["NetLeaves"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["NetLeaves"]);
                    leave.TotalAllowed = (reader["Holidays"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Holidays"]);
                    leave.HolidaysLeft = (double)leave.TotalAllowed - ((reader["TotalLeave"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalLeave"]));

                    leaves.Add(leave);
                }
                reader.Close();
                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return leaves;
            }
        }

        public List<Leave> GetLeavesRelatedToMe(int userId)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_leaves_related_to_me";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = userId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Leave> leaves = new List<Leave>();

                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt64(reader["Id"]);
                    leave.Employee = new User();
                    leave.Employee.FirstName = Convert.ToString(reader["EmployeeName"]);
                    leave.Employee.UserID = Convert.ToInt32(reader["EmployeeID"]);
                    leave.Type = new LeaveType();
                    leave.Type.LeaveTypeID = Convert.ToInt32(reader["LeaveTypeID"]);
                    leave.Type.Name = Convert.ToString(reader["LeaveTypeName"]);
                    leave.FromDate = Convert.ToDateTime(reader["From"]);
                    leave.ToDate = Convert.ToDateTime(reader["To"]);
                    leave.Status = (LeaveStatus)Convert.ToInt32(reader["Status"]);
                    leave.AppliedTo = new User();
                    leave.AppliedTo.FirstName = Convert.ToString(reader["AppliedToName"]);
                    leave.AppliedTo.UserID = Convert.ToInt32(reader["AppliedTo"]);
                    leave.Reason = Convert.ToString(reader["Reason"]);
                    leave.ContactDetails = Convert.ToString(reader["ContactDetails"]);
                    leave.FromSession = Convert.ToInt32(reader["FromSession"]);
                    leave.ToSession = Convert.ToInt32(reader["ToSession"]);
                    leave.CC = Convert.ToString(reader["InformedPersonnel"]);
                    leave.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                    leave.ActionDate = Convert.ToDateTime(reader["ActionDate"]);
                    leaves.Add(leave);
                }
                reader.Close();
                cnx.Close();

                return leaves;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="leaveType"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="fromSession"></param>
        /// <param name="toSession"></param>
        /// <param name="status"></param>
        /// <param name="appliedTo"></param>
        /// <param name="reason"></param>
        /// <param name="contactDetails"></param>
        /// <param name="cc"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public long ApplyForLeave(
            long userID,
            int leaveType,
            DateTime from,
            DateTime to,
            int fromSession,
            int toSession,
            double reqLeaves,
            int status,
            long appliedTo,
            string reason,
            string contactDetails,
            string cc)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_leaves_apply_leave";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@EmployeeID", SqlDbType.Int);
                param.Value = userID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveType", SqlDbType.Int);
                param.Value = leaveType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@From", SqlDbType.Date);
                param.Value = from.Date;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@To", SqlDbType.Date);
                param.Value = to.Date;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromSession", SqlDbType.Int);
                param.Value = fromSession;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToSession", SqlDbType.Int);
                param.Value = toSession;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AppliedTo", SqlDbType.Int);
                param.Value = appliedTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Reason", SqlDbType.VarChar);
                param.Value = reason;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ContactDetails", SqlDbType.VarChar);
                param.Value = contactDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReqLeaves", SqlDbType.Float);
                param.Value = reqLeaves;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nformedPersonnel", SqlDbType.VarChar);
                param.Value = cc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@LeaveID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteScalar();

                cnx.Close();

                return Convert.ToInt64(outParam.Value);
            }
        }

        public int GrantLeave(
           long leaveID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_leaves_grant_leave";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@LeaveID", SqlDbType.Int);
                param.Value = leaveID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int count = cmd.ExecuteNonQuery();
                cnx.Close();
                return count;
            }
        }

        public int RejectLeave(
          long leaveID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_leaves_reject_leave";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@LeaveID", SqlDbType.Int);
                param.Value = leaveID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int count = cmd.ExecuteNonQuery();
                cnx.Close();
                return count;
            }
        }

        public int CancelLeave(
          long leaveID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_leaves_cancel_leave";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@LeaveID", SqlDbType.Int);
                param.Value = leaveID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int count = cmd.ExecuteNonQuery();
                cnx.Close();
                return count;
            }
        }

        public Leave GetLeave(long leaveID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_leaves_get_leave_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@LeaveID", SqlDbType.Int);
                param.Value = leaveID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Leave> leaves = new List<Leave>();

                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt64(reader["Id"]);
                    leave.Employee = new User();
                    leave.Employee.FirstName = Convert.ToString(reader["EmployeeName"]);
                    leave.Employee.UserID = Convert.ToInt32(reader["EmployeeID"]);
                    leave.Type = new LeaveType();
                    leave.Type.LeaveTypeID = Convert.ToInt32(reader["LeaveTypeID"]);
                    leave.Type.Name = Convert.ToString(reader["LeaveTypeName"]);
                    leave.FromDate = Convert.ToDateTime(reader["From"]);
                    leave.ToDate = Convert.ToDateTime(reader["To"]);
                    leave.Status = (LeaveStatus)Convert.ToInt32(reader["Status"]);
                    leave.AppliedTo = new User();
                    leave.AppliedTo.FirstName = Convert.ToString(reader["AppliedToName"]);
                    leave.AppliedTo.UserID = Convert.ToInt32(reader["AppliedTo"]);
                    leave.Reason = Convert.ToString(reader["Reason"]);
                    leave.ContactDetails = Convert.ToString(reader["ContactDetails"]);
                    leave.FromSession = Convert.ToInt32(reader["FromSession"]);
                    leave.ToSession = Convert.ToInt32(reader["ToSession"]);
                    leave.CC = Convert.ToString(reader["InformedPersonnel"]);
                    leave.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                    leave.ActionDate = Convert.ToDateTime(reader["ActionDate"]);
                    leave.NetLeaves = Convert.ToDouble(reader["NetLeaves"]);
                    leaves.Add(leave);
                }
                reader.Close();
                cnx.Close();

                if (leaves.Count == 1)
                {
                    return leaves[0];
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public System.Data.DataSet GetHolidays(
           int month,
           int year
           )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_get_holidays_by_month_year";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = year;
                cmd.Parameters.Add(param);

                DataSet dsHolidays = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsHolidays);

                cnx.Close();

                return dsHolidays;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public System.Data.DataSet GetHolidays(Company UserCompany,
            int day,
            int month,
            int year)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_get_holidays_by_day_month_year";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Company", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = (int)UserCompany;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Day", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = day;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = year;
                cmd.Parameters.Add(param);

                DataSet dsHolidays = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsHolidays);

                cnx.Close();

                return dsHolidays;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Holiday> GetAllHolidays()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_get_all_holidays";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader reader = cmd.ExecuteReader();

                List<Holiday> holidays = new List<Holiday>();

                while (reader.Read())
                {
                    Holiday holiday = new Holiday();
                    holiday.Id = Convert.ToInt64(reader["id"]);
                    holiday.Date = Convert.ToDateTime(reader["date"]);
                    holiday.TillDate = (reader["tilldate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["tilldate"]);
                    holiday.Title = Convert.ToString(reader["title"]);
                    holiday.Description = Convert.ToString(reader["description"]);
                    holiday.Company = Convert.ToInt32(reader["company_id"]);
                    holiday.HolidayTypeID = Convert.ToInt32(reader["type"]);
                    holidays.Add(holiday);
                }
                reader.Close();
                cnx.Close();

                return holidays;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveType"></param>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public double GetBalanceLeaves(
            int employeeID,
            int leaveType
           )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_balance_leaves";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@EmployeeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = employeeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LeaveType", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveType;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@BalanceLeaves", SqlDbType.Float);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return Convert.ToDouble(outParam.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="company_Id"></param>
        /// <returns></returns>
        public int GetInsertedHolidays(
           int day,
           int month,
           int year,
           string title,
           string description,
           int company_Id
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_insert_holiday";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Day", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = day;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = year;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Title", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = description;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Company_ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = company_Id;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public int InsertHoliday(Holiday holiday
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_insert_holiday";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Date", SqlDbType.Date);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TillDate", SqlDbType.Date);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.TillDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Title", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Description;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CompanyID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Company;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HolidayTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.HolidayTypeID;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="companyId"></param>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        public int UpdateHoliday(
           Holiday holiday
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_update_holiday";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Date", SqlDbType.Date);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TillDate", SqlDbType.Date);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.TillDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Title", SqlDbType.VarChar, 60);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Description;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CompanyID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Company;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HolidayTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.HolidayTypeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HolidayID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holiday.Id;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        public int DeleteHoliday(
            long holidayId
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leaves_delete_holiday";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@HolidayID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = holidayId;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        public List<User> GetManagers(int departmentId, int topManagementId)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_leaves_get_managers";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = departmentId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TopMgmtDeptId", SqlDbType.Int);
                param.Value = topManagementId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> users = new List<User>();

                while (reader.Read())
                {
                    User user = new User();

                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FirstName = Convert.ToString(reader["FirstName"]);
                    user.LastName = Convert.ToString(reader["LastName"]);

                    users.Add(user);
                }
                return users;
            }
        }


        public List<LeaveType> GetAllLeaveTypes()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leave_master_get_all_leave_types";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader reader = cmd.ExecuteReader();

                List<LeaveType> leaveTypes = new List<LeaveType>();

                while (reader.Read())
                {
                    LeaveType leaveType = new LeaveType();
                    leaveType.LeaveTypeID = (reader["Type"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Type"]);
                    leaveType.MaxAllowed = (reader["MaxAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["MaxAllowed"]);
                    leaveType.Name = (reader["Name"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Name"]);
                    leaveType.CompanyType = (reader["Company"] == DBNull.Value) ? Company.Boutique : (Company)Convert.ToInt32(reader["Company"]);
                    leaveTypes.Add(leaveType);
                }

                reader.Close();
                cnx.Close();

                return leaveTypes;
            }
        }

        public int InsertLeaveType(LeaveType leaveMaster)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leave_master_insert_leave_type";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@MaxAllowed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveMaster.MaxAllowed;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveMaster.Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Company", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = (int)leaveMaster.CompanyType;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        public int UpdateLeaveType(LeaveType leaveMaster)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leave_master_update_leave_type";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveMaster.LeaveTypeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MaxAllowed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveMaster.MaxAllowed;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = leaveMaster.Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Company", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = (int)leaveMaster.CompanyType;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();
                return count;

            }
        }

        public int DeleteLeaveType(long LeaveTypeID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_leave_master_delete_leave_type";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = LeaveTypeID;
                cmd.Parameters.Add(param);

                int count = cmd.ExecuteNonQuery();

                cnx.Close();

                return count;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Holiday> GetComingHolidays(int Month)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_holiday_master_get_coming_holidays";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Month;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Holiday> holidays = new List<Holiday>();

                while (reader.Read())
                {
                    Holiday holiday = new Holiday();
                    holiday.Id = Convert.ToInt64(reader["id"]);
                    holiday.Date = Convert.ToDateTime(reader["date"]);
                    holiday.TillDate = (reader["tilldate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["tilldate"]);
                    holiday.Title = Convert.ToString(reader["title"]);
                    holiday.Description = Convert.ToString(reader["description"]);
                    holiday.Company = Convert.ToInt32(reader["company_id"]);
                    holiday.HolidayTypeID = Convert.ToInt32(reader["type"]);
                    holidays.Add(holiday);
                }
                reader.Close();
                cnx.Close();

                return holidays;
            }
        }

        public List<Leave> GetAllGrantedLeaves(int Month)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_leaves_get_granted_leaves";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = Month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Leave> leaves = new List<Leave>();

                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt64(reader["Id"]);
                    leave.Employee = new User();
                    leave.Employee.FirstName = Convert.ToString(reader["EmployeeName"]);
                    leave.FromDate = Convert.ToDateTime(reader["From"]);
                    leave.ToDate = Convert.ToDateTime(reader["To"]);
                    leaves.Add(leave);
                }
                reader.Close();
                cnx.Close();

                return leaves;
            }
        }


    }

}
