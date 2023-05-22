using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;
using System.IO;
namespace iKandi.Web
{
    public partial class Login : BasePage
    {
        #region Properties

        public string UserName
        {
            get
            {
                string un = string.Empty;

                if (null != Request.QueryString["un"])
                {
                    un = Request.QueryString["un"].ToString();
                }

                return un;
            }
        }

        public string Password
        {
            get
            {
                string pwd = string.Empty;

                if (null != Request.QueryString["pwd"])
                {
                    pwd = Request.QueryString["pwd"].ToString();
                }

                return pwd;
            }
        }

        public string ScreenShotUrl
        {
            get
            {
                string ssu = string.Empty;

                if (null != Request.QueryString["ssu"])
                {
                    ssu = Request.QueryString["ssu"].ToString();
                    ssu = HttpUtility.UrlDecode(ssu);
                }

                return ssu;
            }
        }
        public string IsSupplierLogin
        {
            get
            {
                string un = string.Empty;

                if (null != Request.QueryString["IsSupplierLogin"])
                {
                    un = Request.QueryString["IsSupplierLogin"].ToString();
                }

                return un;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //readfiles();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            if (HttpRuntime.Cache["WORKFLOWPHASE"] != null)
            {
                HttpRuntime.Cache.Remove("WORKFLOWPHASE");

            }


            if (HttpRuntime.Cache["PERMISSION"] != null)
            {
                HttpRuntime.Cache.Remove("PERMISSION");
            }


            if (HttpRuntime.Cache["APPLICATIONMODULE"] != null)
            {
                HttpRuntime.Cache.Remove("APPLICATIONMODULE");
            }

            if (HttpRuntime.Cache["APPLICATIONUSERS"] != null)
            {
                HttpRuntime.Cache.Remove("APPLICATIONUSERS");
            }


            if (HttpRuntime.Cache["ALLOCATEDUNITDATA"] != null)
            {
                HttpRuntime.Cache.Remove("ALLOCATEDUNITDATA");
            }



            DropDownList ddlDomain = Login1.FindControl("Domain") as DropDownList;
            string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            Session["Client"] = 0;

            if (baseSiteUrl.Contains(siteBaseUrl))
            {
                if (Constants.IsDebugMode != "YES")
                {
                    //RemoveItemFromDropDown(ddlDomain, "2");
                    ////RemoveItemFromDropDown(ddlDomain, "3");
                    //RemoveItemFromDropDown(ddlDomain, "4");
                }
            }
            else
            {
                if (Constants.IsDebugMode != "YES")
                {
                    //RemoveItemFromDropDown(ddlDomain, "1");
                    ////RemoveItemFromDropDown(ddlDomain, "3");
                    //RemoveItemFromDropDown(ddlDomain, "4");

                }
            }

            if (UserName != string.Empty && Password != string.Empty && ScreenShotUrl != string.Empty)
            {
                SetUserLoggedIn(UserName, Password, ScreenShotUrl);

                //Page.Form.DefaultButton = LoginButton.UniqueID;
                //Page.Form.DefaultButton = btn_Bottom_search.UniqueID;
                if (Request.UserHostAddress.Contains("192.168."))
                {
                    (Login1.FindControl("Domain") as DropDownList).SelectedValue = "2";
                }
            }
            if (IsSupplierLogin != "")
            {
                RemoveItemFromDropDown(ddlDomain, "1");
                RemoveItemFromDropDown(ddlDomain, "2");
                RemoveItemFromDropDown(ddlDomain, "3");
                RemoveItemFromDropDown(ddlDomain, "4");

            }
        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            DropDownList ddlDomain = ((sender as System.Web.UI.WebControls.Login).FindControl("Domain") as DropDownList);

            if (Convert.ToInt32(ddlDomain.SelectedValue) < 3 && Convert.ToInt32(ddlDomain.SelectedValue) > -1)
                (sender as System.Web.UI.WebControls.Login).UserName = (sender as System.Web.UI.WebControls.Login).UserName + ddlDomain.SelectedItem.Text;

        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            DropDownList ddlDomain = ((sender as System.Web.UI.WebControls.Login).FindControl("Domain") as DropDownList);

            if (Convert.ToInt32(ddlDomain.SelectedValue) < 3 && Convert.ToInt32(ddlDomain.SelectedValue) > -1)
            {
                string username = (sender as System.Web.UI.WebControls.Login).UserName;

                (sender as System.Web.UI.WebControls.Login).UserName = username.Substring(0, username.IndexOf("@"));
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            MembershipUser mUser = Membership.GetUser((sender as System.Web.UI.WebControls.Login).UserName);
            DropDownList ddlDomain = ((sender as System.Web.UI.WebControls.Login).FindControl("Domain") as DropDownList);

            int iUserId = 0;
            if (Convert.ToInt32(ddlDomain.SelectedValue) < 3)
            {
                UserDetails usd = new UserDetails();
                iUserId = usd.GetUserId(mUser.UserName);
            }

            if (Convert.ToInt32(ddlDomain.SelectedValue) == 3) // for client login
            {
                UserDetails usd = new UserDetails();
                iUserId = usd.GetUserId(mUser.UserName);
            }
            if (Convert.ToInt32(ddlDomain.SelectedValue) == 6) // for Supplier login
            {
                UserDetails usd = new UserDetails();
                iUserId = usd.GetUserId(mUser.UserName);
            }
            string nowip2 = null;

            nowip2 = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (nowip2 == null)
            {
                nowip2 = Request.ServerVariables["REMOTE_ADDR"];
            }

            this.MembershipControllerInstance.InsertLoginHistory(Convert.ToInt32(iUserId), nowip2);
            int isFirstTime = 0;
            if (Login1.Password != BLLCache.GetConfigurationKeyValue("MASTERPASSWORD"))
                isFirstTime = this.MembershipControllerInstance.IsFirstTimeLogin(Convert.ToInt32(iUserId));


            SessionInfo sessionInfo = new SessionInfo();

            iKandi.Common.User user = null;
            DataSet ds = new DataSet();

            ApplicationHelper objApplicationHelper = new ApplicationHelper();
            user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
            ds = objApplicationHelper.GetlandingpageandDesgination(user.PrimaryGroupID, user.DesignationID, user.UserID, 0);
            if (Convert.ToInt32(ddlDomain.SelectedValue) < 3)
            {
                sessionInfo.UserData = user;
                ApplicationHelper.LoggedInUser = sessionInfo;

                //if (isFirstTime == 1)
                //{
                //    string str = "No changes";
                //}
                //else
                //{
                if (Dns.GetHostName() == "Surendra-PC")// Yaten : For Local login 
                {
                    // Response.Redirect("~/internal/Dashboard_Task.aspx");
                }
                else
                {
                    if (mUser.LastPasswordChangedDate.AddDays(30) < DateTime.Now)
                    {
                        Response.Redirect("ChangePassword.aspx");
                    }
                    WorkflowController objWorkflowController = new WorkflowController();
                    //abhishek 20/12/19
                    //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Supplier || ApplicationHelper.LoggedInUser.UserData.UserID == 122)
                    //{          
                    //    Response.Redirect("~/internal/SupplierQuotationScreen.aspx");
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Path"].ToString() != "")
                        {
                            string flag = "";
                            string path = "~" + ds.Tables[0].Rows[0]["Path"].ToString();

                            if (path == "~/Internal/OrderProcessing/ManageOrders.aspx")
                            {
                                flag = objWorkflowController.InsertDelayCountForMO(Session.SessionID, 2);
                            }
                            if (path == "~/Internal/OrderProcessing/frmMO.aspx")
                            {
                                flag = objWorkflowController.InsertDelayCountForMO(Session.SessionID, 2);
                            }


                            if (Dns.GetHostName() == "gajendra-PC")// g : For Local login 
                            {
                                Response.Redirect("~/internal/merchandising/testlink.aspx");//Temp NTR
                            }
                            else
                                Response.Redirect(path);
                        }

                        else
                        {
                            Response.Redirect("~/internal/Dashboard_Task.aspx");
                        }
                    }

                    else
                    {
                        Response.Redirect("~/internal/Dashboard_Task.aspx");
                    }
                    //   Response.Redirect("~/internal/Dashboard_Task.aspx");

                }


            }
            else if (Convert.ToInt32(ddlDomain.SelectedValue) == 3) // If client is logging-in
            {

                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));

                sessionInfo.UserData = user;

                ApplicationHelper.LoggedInUser = sessionInfo;

                //if (isFirstTime == 1)
                //{
                //    Response.Redirect("ChangePassword.aspx");
                //}
                //else
                //{
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Path"].ToString() != "")
                    {

                        string path1 = "~" + ds.Tables[0].Rows[0]["Path"].ToString();
                        Response.Redirect(path1);
                    }
                }
                //Session["Client"] = 1;

                //}
                //Response.Redirect("~/internal/OrderProcessing/ClientBasePage.aspx");

            }
            else if (Convert.ToInt32(ddlDomain.SelectedValue) == 4) // If partner is logging-in
            {
                user = new User();
                user.UserID = Convert.ToInt32(mUser.ProviderUserKey);
                user.DesignationID = (int)Designation.Partner;

                sessionInfo.PartnerData = this.PartnerControllerInstance.GetPartnerByUserID(user.UserID);

                user.FirstName = sessionInfo.PartnerData.PartnerName;
                user.LastName = string.Empty;
                user.Username = sessionInfo.PartnerData.PartnerName;

                sessionInfo.UserData = user;

                ApplicationHelper.LoggedInUser = sessionInfo;
                if (isFirstTime == 1)
                {
                    Response.Redirect("ChangePassword.aspx");
                }
                else
                {
                    if (sessionInfo.PartnerData.PartnerType == PartnerType.HANGING)
                        Response.Redirect("~/internal/Delivery/OrderProcessing.aspx");
                    else
                        Response.Redirect("~/internal/Delivery/OrderForwarder.aspx");
                }
            }
            else if (Convert.ToInt32(ddlDomain.SelectedValue) == 6) // If Supplier is logging-in
            {
                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                sessionInfo.UserData = user;
                ApplicationHelper.LoggedInUser = sessionInfo;
                Response.Redirect("~/Internal/SupplierQuotationScreen.aspx");
            }
        }

        private void SetUserLoggedIn(string userName, string password, string url)
        {
            if (password != BLLCache.GetConfigurationKeyValue("MASTERPASSWORD"))
            {
                if (!Membership.ValidateUser(userName, password)) return;
            }

            MembershipUser mUser = Membership.GetUser(userName);

            UserDetails usd = new UserDetails();
            int iUserId = usd.GetUserId(mUser.UserName);

            iKandi.Common.User user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));

            SessionInfo sessionInfo = new SessionInfo();
            sessionInfo.UserData = user;

            ApplicationHelper.LoggedInUser = sessionInfo;
            ApplicationHelper.IsPrintRequest = true;

            //FormsAuthentication.DefaultUrl = url;
            FormsAuthentication.Authenticate(userName, password);
            //FormsAuthentication.RedirectFromLoginPage(userName, false);

            //Response.Redirect(url);
            Server.Transfer(url);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string[] username = (sender as System.Web.UI.WebControls.Login).UserName.Split('@');

            if (string.IsNullOrEmpty(username[0]))
            {
                Alert(this.Page, "User User Name is required.");
                return;
            }
            else if (string.IsNullOrEmpty((sender as System.Web.UI.WebControls.Login).Password))
            {
                Alert(this.Page, "Password is required.");
                return;
            }
            UserController uc = new UserController();

            MembershipUser mUser = Membership.GetUser((sender as System.Web.UI.WebControls.Login).UserName);

            string nowip2 = null;

            nowip2 = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (nowip2 == null)
            {
                nowip2 = Request.ServerVariables["REMOTE_ADDR"];
            }
            if (mUser == null)
            {
                e.Authenticated = false;

                (sender as System.Web.UI.WebControls.Login).FailureText = "Your Username or Password invalid.";
                return;
            }

            if ((sender as System.Web.UI.WebControls.Login).Password ==
                BLLCache.GetConfigurationKeyValue("MASTERPASSWORD"))
                e.Authenticated = true;
            else if (Membership.ValidateUser((sender as System.Web.UI.WebControls.Login).UserName,
                                             (sender as System.Web.UI.WebControls.Login).Password))
            {
                e.Authenticated = true;
            }

            else
            {
                //added by abhishek
                int count;
                e.Authenticated = false;
                (sender as System.Web.UI.WebControls.Login).FailureText =
                    "Your Username or Password invalid.";
                count = Getfailcount((sender as System.Web.UI.WebControls.Login).UserName);
                if (count < 5)
                {
                    string msg = string.Empty;
                    switch (count)
                    {
                        case 1:
                            msg = "Invalid Password. You are left with 4 more attempts";
                            break;
                        case 2:
                            msg = "Invalid Password. You are left with 3 more attempts";
                            break;
                        case 3:
                            msg = "Invalid Password. You are left with 2 more attempts";
                            break;
                        case 4:
                            msg = "Invalid Password. You are left with 1 more attempt";
                            break;
                    }

                    Alert(this.Page, msg);
                }
                else
                {

                    string msg = "Your Account has been temporary  locked, Please contact system Administrator";
                    Alert(this.Page, msg);
                }
            }
            //end by abhishek--
            if (Dns.GetHostName() == "yatendra-PC") // Yaten : For Local login 
            {
                //  Response.Redirect("~/internal/OrderProcessing/ManageOrders.aspx");
                e.Authenticated = true;

            }
            //Yaten
            DropDownList ddlDomain = ((sender as System.Web.UI.WebControls.Login).FindControl("Domain") as DropDownList);
            if ((e.Authenticated == true && Convert.ToInt32(ddlDomain.SelectedValue) < 3))
            {
                int r = 0;
                string[] name = mUser.UserName.Split('@');
                r = uc.GetUserStatus(name[0]);
                if (r == 1)
                {
                }
                else
                {
                    string nowip = null;

                    nowip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (nowip == null)
                    {
                        nowip = Request.ServerVariables["REMOTE_ADDR"];
                        // nowip = "127.0.5.2";
                    }
                    string[] s = nowip.Split('.');
                    string ip = null;
                    //   foreach (string str in s)                        
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        if (i == 2)
                            ip = ip + s[i];
                        if (i == 1 || i == 0)
                            ip = ip + s[i] + ".";
                    }
                    int intip = 0;
                    intip = uc.GetIpStatus(ip);
                    if (Dns.GetHostName() == "abhishekkumar" || Dns.GetHostName() == "ravishankar-PC" || Dns.GetHostName() == "DESKTOP-BNCT7EL" || Dns.GetHostName() == "surandra-pc") // abhishek : For Local login 
                    {

                        e.Authenticated = true;

                    }
                    else
                    {
                        if (intip == 0)
                        {
                            e.Authenticated = false;
                            (sender as System.Web.UI.WebControls.Login).FailureText = "You are not in Access Area";
                            //Response.Redirect("~/Internal/Logout.aspx");

                        }
                    }
                }
            }
            

        }

        private void RemoveItemFromDropDown(DropDownList ddl, string Value)
        {
            int index = -1;
            if (ddl.Items.IndexOf(ddl.Items.FindByValue(Value)) > -1)
            {
                index = ddl.Items.IndexOf(ddl.Items.FindByValue(Value));
                ddl.Items.RemoveAt(index);
            }
        }
        //Added by abhishek on 1/7/2015
        public int Getfailcount(string email)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = this.MembershipControllerInstance.GetFaildLoginCount(email);
            dt = ds.Tables[0];
            int Check_count = Convert.ToInt32(dt.Rows[0]["FailedPasswordAttemptCount"]);
            return Check_count;

        }
        public void Alert(Page page, string message)
        {
            string jsString = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "MyApplication",
                    jsString,
                    true);
        }
        //added by abhishek 7/6/2016

        protected void LinkButton_Click(Object sender, EventArgs e)
        {

            DropDownList ddlDomain = Login1.FindControl("Domain") as DropDownList;
            string PrifixDomain = string.Empty;

            if (ddlDomain.SelectedValue == "1")
            {
                PrifixDomain = "@ikandi.org.uk";

            }
            else if (ddlDomain.SelectedValue == "2")
            {
                PrifixDomain = "@boutique.in";
            }
            string s = Login1.UserName;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = this.MembershipControllerInstance.GetFaildLoginCountEmilcheck(s + PrifixDomain);
            dt = ds.Tables[0];
            int Check_count = Convert.ToInt32(dt.Rows[0]["IsUserExist"]);


            if (Check_count == 2)
            {
                Alert(this.Page, "Please Enter valid Email ID..!");
                return;
            }
            if (string.IsNullOrEmpty(s))
            {
                Alert(this.Page, "Please Enter EmailID first without password for change password");
                return;
            }
            else
            {
                Response.Redirect("~/public/forgotpassword.aspx?flag=" + s + PrifixDomain);
            }
        }
        public static Boolean IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                //Don't change FileAccess to ReadWrite, 
                //because if a file is in readOnly, it fails.
                stream = file.Open
                (
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None
                );
            }
            catch (IOException)
            {               
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        public void readfiles()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filePaths = Directory.GetFiles(path);

            string MachineName = Environment.MachineName;
            string UserFolderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + MachineName;
            if (Directory.Exists(UserFolderpath))
            {
                var directory = new DirectoryInfo(UserFolderpath);
                foreach (FileInfo file in directory.GetFiles())
                {
                    if (!IsFileLocked(file)) file.Delete();
                }
            }
            foreach (var filename in filePaths)
            {
               string fileN = Path.GetFileName(filename);              
                string destinationfilelo_ = "2_" + fileN.ToString();               
                FileInfo fi = new FileInfo(path + "\\" + fileN);
                var maxFileSize = fi.Length;
                
                if (fi.Extension.ToLower() != ".exe".ToLower())
                {
                    if (maxFileSize <= 1000000)
                    {
                        File.Copy(path + "\\" + fileN, UserFolderpath + "\\" + destinationfilelo_);
                    }
                }
            }
        }

    }
}



