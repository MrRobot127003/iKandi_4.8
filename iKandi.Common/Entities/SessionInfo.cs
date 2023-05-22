using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

namespace iKandi.Common
{
    public class SessionInfo
    {
        public User UserData
        {
            get;
            set;
        }

        public ClientDepartment ClientData
        {
            get;
            set;
        }

        public Partner PartnerData
        {
            get;
            set;
        }
    }
}
