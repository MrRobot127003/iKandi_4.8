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
using iKandi.BLL;
using iKandi.BLL.Security;
using iKandi.Common;


namespace iKandi.Web.UserControls.Security
{
    public partial class UserManagement : BaseUserControl
    {
        #region members

        int roleIndex;
        public string userName;

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.Name != string.Empty && Context.User.IsInRole(Role.Admin.ToString()))
                {
                    this.GridViewMemberUser.Columns[this.GridViewMemberUser.Columns.Count - 1].Visible = true;
                }

            }

            LabelMessage.Text = string.Empty;

        }


        //public string GetUrl(string uname)
        //{

        //    return ResolveUrl("~/Admin/CrossWord/ViewResults.aspx?uId=" + Membership.GetUser(uname).ProviderUserKey);
        //}

        protected void GridViewMemberUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewMemberUser.PageIndex = e.NewPageIndex;
            this.GridViewMemberUser.DataBind();
        }

        protected void GridViewMemberUser_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        //Add the user in selected role
        protected void GridViewMemberUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CheckBoxList roleList = this.GridViewMemberUser.Rows[e.RowIndex].FindControl("roleList") as CheckBoxList;
            Label userNameLable = this.GridViewMemberUser.Rows[e.RowIndex].FindControl("UserName") as Label;

            if (roleList == null) return;

            string userName = userNameLable.Text;

            foreach (ListItem item in roleList.Items)
            {
                bool isUserInRole = RoleDataObject.IsUserInRole(userName, item.Text);

                if (item.Selected && !isUserInRole)
                {
                    RoleDataObject.AddUserInRole(userName, item.Text);
                }
                else if (isUserInRole && !item.Selected)
                {
                    RoleDataObject.RemoveUserFromRole(userName, item.Text);
                }
            }
        }

        //Show the role of a user
        protected void GridViewMemberUser_RowEditing(object sender, GridViewEditEventArgs e)
        {

            roleIndex = e.NewEditIndex;

            this.userName = (this.GridViewMemberUser.Rows[e.NewEditIndex].Cells[0].Controls[1] as Label).Text;

        }

        protected void roleList_DataBound(object sender, EventArgs e)
        {
          //  this.userName = (this.GridViewMemberUser.Rows[e.NewEditIndex].Cells[0].Controls[1] as Label).Text;
            MembershipUser objMembershipUser = Membership.GetUser();
           // MembershipUser mUser = Membership.GetUser((sender as System.Web.UI.WebControls.Login).UserName);

            string[] roles = RoleDataObject.GetAllUserRoles(objMembershipUser.UserName);

            string role = string.Join(", ", roles).Replace(" ", string.Empty);

            CheckBoxList roleList = sender as CheckBoxList;

            foreach (ListItem item in roleList.Items)
            {
                if ((("," + role + ",").IndexOf("," + item.Text + ",")) != -1)
                    item.Selected = true;
            }
        }

        protected void GridViewMemberUser_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            LabelMessage.Text = string.Format(" User [{0}] has been deleted successfully.", e.Values[0].ToString());
        }

        protected void GridViewMemberUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MembershipUserWrapper mu = MembershipUserODS.GetMember(e.Values[0].ToString());

            if (mu == null)
                return;

            MembershipUserODS.Delete(mu.UserName);
        }

        /// <summary>
        /// Validate that user does not exists with same email address
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            Label userNameLable = this.GridViewMemberUser.Rows[this.GridViewMemberUser.EditIndex].FindControl("UserName") as Label;
            TextBox emailLable = this.GridViewMemberUser.Rows[this.GridViewMemberUser.EditIndex].FindControl("Email") as TextBox;

            MembershipUserCollection mUserCollection = Membership.FindUsersByEmail(emailLable.Text);

            foreach (MembershipUser user in mUserCollection)
            {
                if (user.UserName.ToLower() != userNameLable.Text.ToLower())
                {
                    args.IsValid = false;
                    return;
                }
            }
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public  Methods
        //public string GetIndustryName(string industryValue)
        //{
        //    string indusryName = string.Empty;

        //    if (industryValue != null && industryValue != "0" && industryValue != "-1")
        //    {
        //        indusryName = XmlDataSource.GetXmlDocument().SelectSingleNode("//Area[@Value=" + industryValue + "]").Attributes["Name"].Value.ToString();
        //    }

        //    return indusryName;
        //}

        public string GetAllUserRoles(string userName)
        {
            string[] roles = RoleDataObject.GetAllUserRoles(userName);

            return string.Join(", ", roles);
        }

        #endregion

    }
}