using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{

    public class TaskContoller : BaseController
    {
        #region Ctor(s)
        public TaskContoller()
        {
        }

        public TaskContoller(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }
        #endregion
        /// <summary>
        /// yaten : Get data for Department
        /// </summary>
        /// <param name="stringTableName"></param>
        /// <param name="stringColNames"></param>
        /// <param name="strWhereCol"></param>
        /// <param name="strWhereCondition"></param>
        /// <param name="strOperator"></param>
        /// <returns></returns>
        public DataSet GetALLDeptForTaskMappingBAL(string stringTableName, string stringColNames, string strWhereCol, string strWhereCondition, string strOperator)
        {
            return this.TaskMappingProviderInstance.GetALLDeptForTaskMappingDAL(stringTableName, stringColNames, strWhereCol, strWhereCondition, strOperator);

        }
        public DataSet GetALLDeptForTaskMappingBAL()
        {
            return this.TaskMappingProviderInstance.GetALLDeptDAL();

        }

        /// <summary>
        /// yaten : Task Mapping data Department wise
        /// </summary>
        /// <param name="intDeprtId"></param>
        /// <returns></returns>
        public DataSet GetTaskMappingBAL(int intDeprtId)
        {
            return this.TaskMappingProviderInstance.GetTaskMappingBAL(intDeprtId);
        }

        /// <summary>
        /// yaten: Get Line Mgrs By Desg. Id
        /// </summary>
        /// <param name="intDeprtId"></param>
        /// <returns></returns>
        public DataSet GetLineMgrMappingBAL(int intDesgId)
        {

            return this.TaskMappingProviderInstance.GetLineMgrMappingDAL(intDesgId);

        }

        /// <summary>
        /// yaten : Update Mgr Level
        /// </summary>
        /// <param name="intDesgId"></param>
        /// <returns></returns>
        public void UpdateMgrBAL(int intTaskId, int intDesgId, int MgrId, int MgeLevel, int IsAssociate, int TaskWiseDesgId, int DeptId, string Str_TaskName, string Str_Purpose, int int_OldDEsignationID)
        {

            this.TaskMappingProviderInstance.UpdateMgrDAL(intTaskId, intDesgId, MgrId, MgeLevel, IsAssociate, TaskWiseDesgId, DeptId, Str_TaskName, Str_Purpose, int_OldDEsignationID);

        }



    }
}


