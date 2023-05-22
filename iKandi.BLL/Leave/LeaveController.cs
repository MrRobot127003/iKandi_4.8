using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class LeaveController : BaseController
    {
        #region

        public LeaveController()
        {
        }

        public LeaveController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public long ApplyForLeave(Leave leave)
        {
            return this.LeaveDataProviderInstance.ApplyForLeave(leave.Employee.UserID, Convert.ToInt32( leave.Type.LeaveTypeID), leave.FromDate, leave.ToDate, leave.FromSession,
                leave.ToSession, leave.NetLeaves, (int)leave.Status, leave.AppliedTo.UserID, leave.Reason, leave.ContactDetails, leave.CC);
        }

        int searchLeavesCount = 0;

        public List<Leave> GetSearchLeaves(
            int pageSize,
            int startRecord,
            int month,
            int year,
            int leaveType,
            int leaveStatus,
            int employeeID)
        {
            return this.LeaveDataProviderInstance.SearchLeaves(pageSize, startRecord, out searchLeavesCount, month, year, leaveType, leaveStatus, employeeID);
        }

        public int GetSearchLeavesCount(int pageSize,
            int startRecord,
            int month,
            int year,
            int leaveType,
            int leaveStatus,
            int employeeID)
        {
            return searchLeavesCount;
        }

        int searchLeavesByUserManagerRoleCount = 0;

        public List<Leave> GetSearchLeavesByUserManagerRole(
            int pageSize,
            int startRecord,
            int month,
            int year,
            int leaveType,
            int leaveStatus,
            string employeeName,
            int userId)
        {
            return this.LeaveDataProviderInstance.SearchLeavesByUserManagerRole(pageSize, startRecord, out searchLeavesByUserManagerRoleCount,
                month, year, leaveType, leaveStatus, employeeName, userId);
        }

        public List<Leave> GetLeavesRelatedToMe(int userId)
        {
            return this.LeaveDataProviderInstance.GetLeavesRelatedToMe(userId);
        }

        public int GetSearchLeavesByUserManagerRoleCount(int pageSize,
            int startRecord,
            int month,
            int year,
            int leaveType,
            int leaveStatus,
            string employeeName,
            int userId)
        {
            return searchLeavesByUserManagerRoleCount;
        }



        public int GrantLeave(long leaveID)
        {
            return this.LeaveDataProviderInstance.GrantLeave(leaveID);
        }

        public int RejectLeave(long leaveID)
        {
            return this.LeaveDataProviderInstance.RejectLeave(leaveID);
        }

        public int CancelLeave(long leaveID)
        {
            return this.LeaveDataProviderInstance.CancelLeave(leaveID);
        }

        public Leave GetLeave(long leaveID)
        {
            return this.LeaveDataProviderInstance.GetLeave(leaveID);
        }

        public DataSet GetHolidays(int month, int year)
        {
            return this.LeaveDataProviderInstance.GetHolidays(month, year);
        }

        public DataSet GetHolidays(Company UserCompany, int day, int month, int year)
        {
            return this.LeaveDataProviderInstance.GetHolidays(UserCompany, day, month, year);
        }

        public List<Holiday> GetAllHolidays()
        {
            return this.LeaveDataProviderInstance.GetAllHolidays();
        }

        public int InsertHoliday(Holiday holiday)
        {
            return this.LeaveDataProviderInstance.InsertHoliday(
                holiday);
        }

        public int UpdateHoliday(Holiday holiday)
        {
            return this.LeaveDataProviderInstance.UpdateHoliday(
                holiday);
        }

        public int DeleteHoliday(Holiday holiday)
        {
            return this.LeaveDataProviderInstance.DeleteHoliday(holiday.Id);
        }


        public double GetBalanceLeaves(int employeeID, int leaveType)
        {
            return this.LeaveDataProviderInstance.GetBalanceLeaves(employeeID, leaveType);
        }

        public int GetInsertedHolidays(int day, int month, int year, string title, string description, int company_Id)
        {
            return this.LeaveDataProviderInstance.GetInsertedHolidays(day, month, year, title, description, company_Id);
        }

        public List<User> GetManagers(int departmentId, int topManagementId)
        {
            return this.LeaveDataProviderInstance.GetManagers(departmentId, topManagementId);
        }

        public List<LeaveType> GetAllLeaveTypes()
        {
            return this.LeaveDataProviderInstance.GetAllLeaveTypes();
        }

        public int InsertLeaveType(LeaveType leaveType)
        {
            return this.LeaveDataProviderInstance.InsertLeaveType(leaveType);
        }

        public int UpdateLeaveType(LeaveType leaveType)
        {
            return this.LeaveDataProviderInstance.UpdateLeaveType(leaveType);
        }

        public int DeleteLeaveType(LeaveType leaveType)
        {
            return this.LeaveDataProviderInstance.DeleteLeaveType(leaveType.LeaveTypeID);
        }

        public List<Holiday> GetComingHolidays(int Month)
        {
            return this.LeaveDataProviderInstance.GetComingHolidays(Month);
        }

        public List<Leave> GetAllGrantedLeaves(int Month)
        {
            return this.LeaveDataProviderInstance.GetAllGrantedLeaves(Month);
        }
       
    }

}

