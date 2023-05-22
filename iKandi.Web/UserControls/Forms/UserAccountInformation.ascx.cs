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
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class UserAccountInformation : BaseUserControl
    {
        #region Properties

        public User User
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                    

                int userID = -1;

                if (Request.Params["userid"] != null && Request.Params["userid"] != "")
                {
                    userID = Convert.ToInt32(Request.Params["userid"]);
                }
                else if (this.UserID > 0)
                {
                    userID = this.UserID;
                }

                if (userID == -1 && ApplicationHelper.LoggedInUser != null && ApplicationHelper.LoggedInUser.UserData != null)
                {
                    this.User = ApplicationHelper.LoggedInUser.UserData;
                }
                else
                {
                    this.User = this.UserControllerInstance.GetUserByID(userID);
                }

                this.UserID = this.User.UserID;


                BindControls();
            }
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            if (this.User == null) return;

            DataTable dtUserDetails = UserControllerInstance.GetUserDetails(this.User.UserID);
            if (dtUserDetails.Rows.Count > 0)
            {
              this.lblName.Text = dtUserDetails.Rows[0]["UserName"].ToString();
              this.lblDesignation.Text = dtUserDetails.Rows[0]["DesignationName"].ToString();
            }
            //this.lblDesignation.Text = Constants.GetDesignationName((int)this.User.DesignationID);
            //this.lblName.Text = this.User.FullName;
            this.lblAddress.Text = FixUp(this.User.Address);
            this.lnkEmail.Text ="Email: " + this.User.Email;
            this.lnkEmail.NavigateUrl = "mailto:" + this.User.Email;
            this.lblPhone.Text ="Tel: " + this.User.Phone;

            if (!string.IsNullOrEmpty(this.User.PhotoPath))
            {
                this.imgPhoto.ImageUrl = ResolveUrl("~/uploads/photo/" + this.User.PhotoPath);
                this.imgPhoto.Visible = true;
            }

            if (ApplicationHelper.LoggedInUser != null && ApplicationHelper.LoggedInUser.UserData != null && ApplicationHelper.LoggedInUser.UserData.UserID == this.User.UserID)
            {
                this.lnkEditProfile.Visible = true;
                this.lnkEditProfile.NavigateUrl = "~/internal/users/myprofile.aspx?userid=" + this.User.UserID.ToString();
                //hlkChangePassword.Visible = true;
            }
            else
            {
                this.lnkEditProfile.Visible = false;
                //hlkChangePassword.Visible = false ;
            }

        }

        #endregion
    }
}