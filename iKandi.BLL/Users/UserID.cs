using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;


namespace iKandi.BLL.Users
{
    class UserID : BaseController
    {
        public int InsertUserTask(UserTask Task)
        {
            return this.UserTaskDataProviderInstance.InsertUserTask(Task);
        }
    }
}
