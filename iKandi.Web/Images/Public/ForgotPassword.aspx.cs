using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class Forgot_Password : BasePage
    {
        User user = new User();
        public string UserName;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["flag"]))
            {
                if (!IsPostBack)
                {
                    UserName = Request.QueryString["flag"];
                    pwd_recovery.UserName = UserName;
                    this.MembershipControllerInstance.ResetLoginfailCount(UserName);
                }
            }
            
            
                 

        }

        protected void pwd_recovery_SendingMail(object sender, MailMessageEventArgs e)
        {
            MembershipUser mUser = Membership.GetUser((sender as PasswordRecovery).UserName);
            UserDetails usd = new UserDetails();
            user.UserID = usd.GetUserId(mUser.UserName);
            user = this.MembershipControllerInstance.GetUserProfile(user.UserID);
            
            string fullName = "User";

            if (user != null)
                fullName = user.FullName;
            
            //abhishek on 6/6/2016
            //this.NotificationControllerInstance.SendForgotPasswordEmail(fullName, mUser.GetPassword(), mUser.Email);
            this.NotificationControllerInstance.SendForgotPasswordEmail(fullName, user.Password, mUser.Email);
            //this.MembershipControllerInstance.ResetLoginfailCount((sender as PasswordRecovery).UserName);//for reset fail login count
            
            e.Cancel = true;
        }

      
       

      
        
    }
}
