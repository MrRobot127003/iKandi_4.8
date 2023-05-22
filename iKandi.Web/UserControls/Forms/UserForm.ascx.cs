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
using System.Globalization;
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web
{
  public partial class UserForm : BaseUserControl
  {

    #region Properties
    AdminController objadmin = new AdminController();
    public int CompanyID
    {
      get;
      set;
    }
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
        BindMMddl();
        BindListBox(this.UserID);
        BindControls();
        if (this.UserID == -1)
        {
          hylp.Visible = false;
        }
        else
        {
          hylp.Visible = true;
        }
        //bindCompanyddl();

      }
    }
    public void BindListBox(int UserID)
    {

      if (UserID != -1)
      {
        User user = this.MembershipControllerInstance.GetUser(UserID);
        if (user.DesignerCode.IndexOf(",") != -1)
        {
          string[] ss = user.DesignerCode.Split(',');
          List<int> list = new List<int>();
          for (int i = 0; i <= 99; i++)
            list.Add(i);
          for (int x = 0; x <= ss.Length - 1; x++)
          {
            list.Remove(Convert.ToInt32(ss[x]));
            list.Insert(x, Convert.ToInt32(ss[x]));
          }
          ddlDesignerCode.DataSource = list;
          ddlDesignerCode.DataBind();
          for (int x = 0; x <= ss.Length - 1; x++)
          {
            ddlDesignerCode.SelectedValue = ss[x];
          }
        }
        else
        {
          List<int> list = new List<int>();
          for (int i = 0; i <= 99; i++)
          {
            list.Add(i);
          }
          ddlDesignerCode.DataSource = list;
          ddlDesignerCode.DataBind();
        }

      }

      if (this.UserID == -1)
      {
        List<int> list = new List<int>();
        for (int i = 0; i <= 99; i++)
        {
          list.Add(i);
        }
        ddlDesignerCode.DataSource = list;
        ddlDesignerCode.DataBind();
      }
    }


    protected void Submit_Click(object sender, EventArgs e)
    {
      //if (!Page.IsValid)
      //   return;

      SaveUser();
      //bindCompanyddl();

    }

    protected void Validate_Email(object source, ServerValidateEventArgs args)
    {
      MembershipUserCollection users = Membership.FindUsersByName(txtEmail.Text);

      if (users.Count > 0)
      {
        args.IsValid = false;
        return;
      }

      users = Membership.FindUsersByEmail(txtEmail.Text);

      if (users.Count > 0)
        args.IsValid = false;
    }

    #endregion

    #region Private Methods
    UserController objuser = new UserController();
    private void BindControls()
    {
      //  ddlDesignerCode.Attributes.Add("style", "display:none");

      imgPhoto.Visible = false;
      imgSignature.Visible = false;

      if (this.UserID != -1)
      {

        User user = this.MembershipControllerInstance.GetUser(this.UserID);

        //BindPrimeryGroupDept(user.CompanyID);
        //BindDesignation(user.PrimaryGroupID);
        //BindManager(user.DesignationID);

        ddlCompany.SelectedValue = user.CompanyID.ToString();
        txtFirstName.Text = user.FirstName;
        txtLastName.Text = user.LastName;
        txtEmail.Text = txtConfirmEmail.Text = user.Email.Substring(0, user.Email.IndexOf("@"));
        chkGlobal.Checked = user.iGlobalAcc == 1 ? true : false;
        if (user.Phone.IndexOf("-") > -1)
        {
          string[] phoneParts = user.Phone.Split(new char[] { '-' });

          if (phoneParts.Length > 2)
          {
            txtPhoneCountry.Text = phoneParts[0];
            txtPhoneArea.Text = phoneParts[1];
            txtPhone.Text = phoneParts[2];
          }
        }
        //DepartmentController objdepcontroller = new DepartmentController();
        //List<Department> obj = objdepcontroller.GetDepartmentsByCompany(user.CompanyID);
        //ddlPrimaryGroup.DataSource = obj;
        //ddlPrimaryGroup.DataTextField = "Name";
        //ddlPrimaryGroup.DataValueField = "id";
        ddlPrimaryGroup.SelectedValue = user.PrimaryGroupID.ToString();
        txtCardno.Text = user.EmpCardNo == 0 ? "" : user.EmpCardNo.ToString();
        ddlDesignation.SelectedValue = user.DesignationID.ToString();
        ddlManagers.SelectedValue = user.ManagerID.ToString();
        hfprevManagerId.Value = user.ManagerID.ToString();
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
        chkisstaff.Checked = (user.IsStaff == 1 ? true : false);
        txtordersqe.Text = user.OrderSeq.ToString() == "0" ? "" : user.OrderSeq.ToString();

        if (!string.IsNullOrEmpty(user.PhotoPath))
        {
          imgPhoto.Visible = true;
          imgPhoto.ImageUrl = ResolveUrl("~/Uploads/photo/" + user.PhotoPath);
        }

        if (!string.IsNullOrEmpty(user.SignPath))
        {
            imgSignature.Visible = true;
            imgSignature.ImageUrl = ResolveUrl("~/Uploads/photo/" + user.SignPath);
        }

        // TODO: Disable some validators

        PageHelper.AddJScriptVariable("selectedPrimayGroupID", user.PrimaryGroupID);
        PageHelper.AddJScriptVariable("selectedDesignationID", user.DesignationID);
        PageHelper.AddJScriptVariable("selectedManagerID", user.ManagerID);

        string designerCode = user.DesignerCode;

        if (!string.IsNullOrEmpty(designerCode))
        {
          string[] designerCodes = designerCode.Split(new char[] { ',' });

          foreach (string code in designerCodes)
          {
            ListItem item = ddlDesignerCode.Items.FindByValue(code);

            if (item != null)
              item.Selected = true;
          }
        }
        string wkoff = user.WeekOff;
        if (!string.IsNullOrEmpty(wkoff))
        {
          string[] wk = wkoff.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

          foreach (string code in wk)
          {
            ListItem item = chkhoilday.Items.FindByText(code);
            if (item != null)
              item.Selected = true;
          }
        }
        string Intime = "";
        if (user.PrimaryGroupID == 34)
        {
          if (user.Intime == "")
          {
            Intime = "09:20";
          }
          else
          {
            Intime = user.Intime;
          }
        }
        else
        {
          if (user.Intime == "")
          {
            Intime = "09:50";
          }
          else
          {
            Intime = user.Intime;
          }
        }


        ddlhh.SelectedValue = Intime.Split(':')[0];
        ddlmm.SelectedValue = Intime.Split(':')[1];
        string additionalGrp = string.Empty;

        if (user.AdditionalGroups != null)
        {
          for (int i = 0; i < user.AdditionalGroups.Count; i++)
          {
            if (additionalGrp == string.Empty)
              additionalGrp = user.AdditionalGroups[i].ToString();
            else
              additionalGrp += "," + user.AdditionalGroups[i].ToString();
          }
        }

        PageHelper.AddJScriptVariable("selectedAdditionalGroupID", "'" + additionalGrp + "'");
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){onCompanyChange()});", true);
        //if (user.IsActive == 1)
        //{
        //    ChkDeactivate.Checked = true;

        //    grduser.Attributes.Add("style", "display:none;");
        //}
        //else
        //{
        //    ChkDeactivate.Checked = false;
        //    grduser.Attributes.Add("style", "display:display:block;");
        //}
        UserController objuserss = new UserController();
        DataTable dt = objuserss.GetUserSque(user.PrimaryGroupID);
        grdattendence.DataSource = dt;
        grdattendence.DataBind();


      }
      //bindInactiveUser();
    }
    //public void bindInactiveUser()
    //{

    //    DataSet ds = this.MembershipControllerInstance.GetInactiveuser(this.UserID, 1);
    //    DataTable dt = ds.Tables[0];
    //    grduser.DataSource = dt;
    //    grduser.DataBind();

    //}
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
      BindControls();
    }

    private void SaveUser()
    {


      string fileID = string.Empty;
      string fileID1 = string.Empty;

      // Save the file
      if (filePhoto.HasFile)
        fileID = FileHelper.SaveFile(filePhoto.PostedFile.InputStream, filePhoto.FileName, Constants.PHOTO_FOLDER_PATH, false, string.Empty);

      if (fileSig.HasFile)
          fileID1 = FileHelper.SaveFile(fileSig.PostedFile.InputStream, fileSig.FileName, Constants.PHOTO_FOLDER_PATH, false, string.Empty);

      User user = null;

      if (this.UserID == -1)
        user = new User();
      else
        user = this.MembershipControllerInstance.GetUser(this.UserID);
      user.error_msg = "sucess";
      user.UserID = this.UserID;
      user.Address = txtAddress.Text;
      user.IsStaff = (chkisstaff.Checked == true ? 1 : 0);
      if (!string.IsNullOrEmpty(txtAnniversary.Text))
      {
        user.Anniversary = DateHelper.ParseDate(txtAnniversary.Text).Value;
      }
      else
      {
        user.Anniversary = Convert.ToDateTime("1/1/1900");
      }

      if (!string.IsNullOrEmpty(txtBirthday.Text))
      {
        user.BirthDay = DateHelper.ParseDate(txtBirthday.Text).Value;
      }
      else
      {
        user.BirthDay = Convert.ToDateTime("1/1/1900");
      }
      user.EmpCardNo = (txtCardno.Text == "" ? 0 : Convert.ToInt32(txtCardno.Text));
      user.Company = (iKandi.Common.Company)Convert.ToInt32(ddlCompany.SelectedValue);
      user.DesignationID = Convert.ToInt32(Request.Params[ddlDesignation.UniqueID]);
      user.DesignerCode = string.Empty;

      if (user.DesignationID == (int)Designation.iKandi_Design_Designers || user.DesignationID == (int)Designation.iKandi_Design_Manager)
        user.DesignerCode = Convert.ToString(Request.Params[ddlDesignerCode.UniqueID]);

      //  user.Email = txtEmail.Text + ((Convert.ToInt32(ddlCompany.SelectedValue) == (int)Company.iKandi) ? Constants.IKANDI_EMAIL : Constants.BOUTIQUE_EMAIL);
      //abhishek chnaged here 
      if (ddlCompany.SelectedValue == "1")
      {
        //user.Email = txtEmail.Text + Constants.BOUTIQUE_EMAIL;
        user.Email = txtEmail.Text + Constants.IKANDI_EMAIL;
      }
      if (ddlCompany.SelectedValue == "2")
      {
        //user.Email = txtEmail.Text + Constants.XNY_EMAIL;
        user.Email = txtEmail.Text + Constants.BOUTIQUE_EMAIL;

      }

      //if (ddlCompany.SelectedValue == "3")
      //{

      //}
      //end
      user.FirstName = txtFirstName.Text;
      user.LastName = txtLastName.Text;
      user.iGlobalAcc = chkGlobal.Checked ? 1 : 0;
      user.ManagerID = -1;
      if (!string.IsNullOrEmpty(Request.Params[ddlManagers.UniqueID]))
        user.ManagerID = Convert.ToInt32(Request.Params[ddlManagers.UniqueID]);
      user.PrevManagerID = Convert.ToInt32(hfprevManagerId.Value);
      user.Mobile = txtMobile.Text;
      user.Phone = string.Format("{0}-{1}-{2}", txtPhoneCountry.Text, txtPhoneArea.Text, txtPhone.Text);
      user.HomePhone = string.Format("{0}-{1}-{2}", txtPersonalPhone.Text, txtPersonalPhoneArea.Text, txtPersonalPhone.Text);
      user.PersonalEmail = txtPersonalEmail.Text;
      user.Intime = ddlhh.SelectedValue + ":" + ddlmm.SelectedValue;
      user.OrderSeq = Convert.ToInt32(txtordersqe.Text);

      if (fileID != string.Empty)
        user.PhotoPath = fileID;
      if (fileID1 != string.Empty)
          user.SignPath = fileID1;

      user.PrimaryGroupID = Convert.ToInt32(Request.Params[ddlPrimaryGroup.UniqueID]);

      user.AdditionalGroups = new System.Collections.Generic.List<int>();

      string addtionalGroups = Request.Params[ddlAdditionalGroups.UniqueID];

      if (!string.IsNullOrEmpty(addtionalGroups))
      {
        string[] addnlGrps = addtionalGroups.Split(new char[] { ',' });

        // Addtional roles
        foreach (string grpId in addnlGrps)
        {
          user.AdditionalGroups.Add(Convert.ToInt32(grpId));
        }
      }
      user.WeekOff = "";
      foreach (ListItem li in chkhoilday.Items)
      {
        if (li.Selected == true)
        {
          user.WeekOff += li + ",";
        }
      }
      //DataTable dtvalidate = UpdateClientUserAssociation();

      //user.IsActive = ChkDeactivate.Checked == true ? 1 : 0;//abhishek
      //if (user.IsActive == 1)
      //{
      //    foreach (DataRow row in dtvalidate.Rows)
      //    {
      //        if (row["ImagePath"].ToString() == "")
      //        {
      //            Page page = HttpContext.Current.Handler as Page;
      //            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + user.error_msg + "');", true);
      //            return;
      //        }
      //    }

      //}
      this.MembershipControllerInstance.SaveUser(user);
      if (user.error_msg != "sucess")
      {
        //string script = string.Empty;
        //script = "ShowHideMessageBox(true," + user.error_msg + ",'userform' );";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + user.error_msg + "');", true);
        return;
      }
      else
      {
        pnlForm.Visible = false;
        pnlMessage.Visible = true;

        ApplicationHelper.ClearUsersCache();
      }

      CompanyID = user.CompanyID;
    }
    public void bindCompanyddl()
    {
      DataTable dt = objuser.GetCompanyName();
      ddlCompany.DataSource = dt;
      ddlCompany.DataTextField = "DivisionName";
      ddlCompany.DataValueField = "ManageDivisionID";
      ddlCompany.DataBind();
    }
    #endregion

    //protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void ddlPrimaryGroup_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void ddlManagers_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    public void BindPrimeryGroupDept(int CompanyID)
    {
      DepartmentController objdepcontroller = new DepartmentController();
      List<Department> obj = objdepcontroller.GetDepartmentsByCompany(CompanyID);
      ddlPrimaryGroup.DataSource = obj;
      ddlPrimaryGroup.DataTextField = "Name";
      ddlPrimaryGroup.DataValueField = "id";
    }
    public void BindDesignation(int DepartmentID)
    {
      DesignationController objdepcontroller = new DesignationController();
      List<UserDesignation> obj = objdepcontroller.GetDesignationsByDepartment(DepartmentID);
      ddlDesignation.DataSource = obj;
      ddlDesignation.DataTextField = "Name";
      ddlDesignation.DataValueField = "id";
    }
    public void BindManager(int DesignationID)
    {
      UserController objdepcontroller = new UserController();
      List<User> obj = objdepcontroller.GetManagers(DesignationID);
      ddlManagers.DataSource = obj;
      ddlManagers.DataTextField = "Name";
      ddlManagers.DataValueField = "id";
    }



    //protected void grduser_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        DataSet ds = this.MembershipControllerInstance.GetInactiveuser(this.UserID,2);
    //        DataTable dt = ds.Tables[0];
    //        ListBox listDept = (ListBox)e.Row.FindControl("listDept");
    //        ListBox listuser = (ListBox)e.Row.FindControl("listuser");

    //       User user = this.MembershipControllerInstance.GetUser(UserID);

    //        listDept.DataSource = dt;
    //        listDept.DataTextField = "DepartmentName";
    //        listDept.DataValueField = "DepartmentID";
    //        listDept.DataBind();

    //        listDept.Enabled = false;

    //        DataSet dsdes = this.MembershipControllerInstance.GetInactiveuser(this.UserID, 3);
    //        DataTable dtdes = dsdes.Tables[0];
    //        ListBox listdesignation = (ListBox)e.Row.FindControl("listdesignation");

    //        listdesignation.DataSource = dtdes;
    //        listdesignation.DataTextField = "Name";
    //        listdesignation.DataValueField = "DesignationID";
    //        listdesignation.DataBind();

    //        listdesignation.SelectedValue = user.DesignationID.ToString();

    //        string selectedItem = "";
    //        //if (Convert.ToInt32(listdesignation.SelectedValue) > 0)
    //        //{
    //            if (listdesignation.Items.Count > 0)
    //            {
    //                for (int i = 0; i < listdesignation.Items.Count; i++)
    //                {
    //                    if (listdesignation.Items[i].Selected)
    //                    {
    //                        selectedItem = selectedItem + listdesignation.Items[i].Value + ",";

    //                    }
    //                }
    //            }

    //            DataSet dsuser = this.MembershipControllerInstance.GetInactiveuser(this.UserID, 4, selectedItem);
    //            DataTable dtuser = dsuser.Tables[0];

    //            listuser.DataSource = dtuser;
    //            listuser.DataTextField = "UserName";
    //            listuser.DataValueField = "UserID";
    //            listuser.DataBind();
    //        //}


    //    }
    //}

    //protected void ChkDeactivate_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkDeactivate.Checked)
    //       // divuser.Visible = false;
    //        grduser.Attributes.Add("style", "display:none;");                             
    //    else
    //        grduser.Attributes.Add("style", "display:display:block;");

    //}

    //protected void listdesignation_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    ListBox ddl = (ListBox)sender;
    //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
    //    int rowIndex = row.RowIndex;
    //    ListBox listuser = (ListBox)row.FindControl("listuser");
    //    ListBox listdesignation = (ListBox)row.FindControl("listdesignation");
    //    int val = Convert.ToInt32(listdesignation.SelectedValue);
    //    string selectedItem="";
    //    if (Convert.ToInt32(listdesignation.SelectedValue) > 0)
    //    {
    //        if (listdesignation.Items.Count > 0)
    //        {
    //            for (int i = 0; i < listdesignation.Items.Count; i++)
    //            {
    //                if (listdesignation.Items[i].Selected)
    //                {
    //                     selectedItem =selectedItem+ listdesignation.Items[i].Value+",";
    //                    //insert command
    //                }
    //            }
    //        }

    //        DataSet dsuser = this.MembershipControllerInstance.GetInactiveuser(this.UserID, 4, selectedItem);
    //        DataTable dtuser = dsuser.Tables[0];

    //        listuser.DataSource = dtuser;
    //        listuser.DataTextField = "UserName";
    //        listuser.DataValueField = "UserID";
    //        listuser.DataBind();
    //    }

    //}

    //public DataTable UpdateClientUserAssociation()
    //{
    //    int ClientID;
    //    String strdeptsID = "";
    //    string strdesID="";
    //    string UserID = "";

    //       DataTable dt = new DataTable(); 
    //       dt.Clear();
    //       dt.Columns.Add("ClientID");
    //       dt.Columns.Add("DeptID");
    //       dt.Columns.Add("DesignationID");
    //       dt.Columns.Add("USerID");


    //    foreach (GridViewRow row in grduser.Rows)
    //    {
    //        DataRow drrow = dt.NewRow();

    //        HiddenField hdnClientID = (HiddenField)row.FindControl("hdnClientID");
    //        ListBox listDept = (ListBox)row.FindControl("listDept");
    //        ListBox listdesignation = (ListBox)row.FindControl("listdesignation");
    //        ListBox listuser = (ListBox)row.FindControl("listuser");
    //        ClientID = Convert.ToInt32(hdnClientID.Value);

    //         if (listDept.Items.Count > 0)
    //         {
    //              for(int i = 0; i < listDept.Items.Count; i++)
    //              {                            
    //                 strdeptsID = strdeptsID + listDept.Items[i].Value + ",";                                                           
    //              }
    //         }
    //        if (listdesignation.Items.Count > 0)
    //         {
    //              for(int i = 0; i < listdesignation.Items.Count; i++)
    //              {
    //                  if (listdesignation.Items[i].Selected)
    //                  {
    //                      strdesID = strdesID + listdesignation.Items[i].Value + ",";
    //                  }                             
    //              }
    //         }
    //        if (listuser.Items.Count > 0)
    //        {
    //            for (int i = 0; i < listuser.Items.Count; i++)
    //            {
    //                if (listuser.Items[i].Selected)
    //                {
    //                    UserID = UserID + listuser.Items[i].Value + ",";
    //                }
    //            }
    //        }
    //        drrow["ClientID"] = ClientID;
    //        drrow["DeptID"] =  strdeptsID;
    //        drrow["DesignationID"] =  strdesID;
    //        drrow["USerID"] = UserID;

    //        dt.Rows.Add(drrow);
    //    }
    //    return dt;
    //}

    public void BindMMddl()
    {
      var source = new Dictionary<string, string>();
      for (int i = 0; i < 60; i++)
      {
        string strmm = "";
        if (i.ToString().Length == 1)
        {
          if (i.GetType() == typeof(int))
          {
            strmm = "0" + i;
          }
        }
        else
        {
          strmm = i.ToString();
        }
        source.Add(strmm, strmm);
      }
      ddlmm.DataSource = source;
      ddlmm.DataTextField = "Key";
      ddlmm.DataValueField = "Value";
      ddlmm.DataBind();
      ddlmm.SelectedValue = "00";
    }

  }
}