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
    public partial class MyProfile : BaseUserControl
    {
        #region Properties

        public int UserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    return Convert.ToInt32(Request.QueryString["userid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //if (!Page.IsValid)
            //   return;

            SaveUser();
        }


        #endregion

        #region Private Methods

        private void BindControls()
        {

            imgPhoto.Visible = false;

            if (this.UserID != -1)
            {

                User user = this.MembershipControllerInstance.GetUserProfile(this.UserID);

                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtAddress.Text = user.Address;
                txtPersonalEmail.Text = user.PersonalEmail;

                if (user.HomePhone.IndexOf("-") > -1)
                {
                    string[] phoneParts = user.HomePhone.Split(new char[] { '-' });

                    if (phoneParts.Length > 2)
                    {
                        txtPersonalPhoneCountry.Text = phoneParts[0];
                        txtPersonalPhoneArea.Text = phoneParts[1];
                        txtPersonalPhone.Text = phoneParts[2];
                    }
                }

                txtMobile.Text = user.Mobile;
                txtBirthday.Text = user.BirthDay.ToString("dd MMM yy (ddd)");
                txtAnniversary.Text = user.Anniversary.ToString("dd MMM yy (ddd)");

                if (!string.IsNullOrEmpty(user.PhotoPath))
                {
                    imgPhoto.Visible = true;
                    imgPhoto.ImageUrl = ResolveUrl("~/Uploads/photo/" + user.PhotoPath);
                }
            }
        }

        private void SaveUser()
        {

            User user = this.MembershipControllerInstance.GetUserProfile(this.UserID);

            string fileID = string.Empty;

            // Save the file
            if (filePhoto.HasFile)
                fileID = FileHelper.SaveFile(filePhoto.PostedFile.InputStream, filePhoto.FileName, Constants.PHOTO_FOLDER_PATH, false, string.Empty);

            user.UserID = this.UserID;
            user.Address = txtAddress.Text;

            if (!string.IsNullOrEmpty(txtAnniversary.Text))
                user.Anniversary = DateHelper.ParseDate(txtAnniversary.Text).Value;

            if (!string.IsNullOrEmpty(txtBirthday.Text))
                user.BirthDay = DateHelper.ParseDate(txtBirthday.Text).Value;

            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Mobile = txtMobile.Text;
            user.HomePhone = string.Format("{0}-{1}-{2}", txtPersonalPhoneCountry.Text, txtPersonalPhoneArea.Text, txtPersonalPhone.Text);
            user.PersonalEmail = txtPersonalEmail.Text;

            if (fileID != string.Empty)
                user.PhotoPath = fileID;

            this.MembershipControllerInstance.UpdateUserProfile(user);

            //ApplicationHelper.LoggedInUser.UserData = user;
            ApplicationHelper.LoggedInUser.UserData.FirstName = user.FirstName;
            ApplicationHelper.LoggedInUser.UserData.LastName = user.LastName;
            ApplicationHelper.LoggedInUser.UserData.Address = user.Address;
            ApplicationHelper.LoggedInUser.UserData.HomePhone = user.HomePhone;
            ApplicationHelper.LoggedInUser.UserData.Mobile = user.Mobile;
            ApplicationHelper.LoggedInUser.UserData.PersonalEmail = user.PersonalEmail;


            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }

        #endregion
    }
}
