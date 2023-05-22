using System;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;

namespace iKandi.Web
{
    public partial class FabricAccessoriesWorkSheet : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int iUserId = 0;
            string Flag = string.Empty;
            string v = Request.QueryString["Emailid"];
            if (v != null && v!="")
            {
                Flag = v;

                if (ApplicationHelper.LoggedInUser.UserData != null)

                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();


                SessionInfo sessionInfo = new SessionInfo();

                iKandi.Common.User user = null;

                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                ApplicationHelper objApplicationHelper = new ApplicationHelper();
                DataSet ds = objApplicationHelper.GetNotifactionRemarks(user.DesignationID, Convert.ToInt32(Flag), "Form",iUserId);
            }

         
        }
    }
}