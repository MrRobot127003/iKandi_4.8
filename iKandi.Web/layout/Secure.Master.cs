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
using iKandi.Common;
namespace iKandi.Web
{
    public partial class Secure : System.Web.UI.MasterPage
    {
        #region Proerties

        private string Message
        {
            get
            {
                return Request["message"];
            }
        }

        private string ErrorMessage
        {
            get
            {
                return Request["errorMessage"];
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(iKandi.Web.Components.ApplicationHelper.LoggedInUser==null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData==null)
                Response.Redirect("~/public/Login.aspx");

            //try
            //{
            //    if (Session["LoggedUserId"] != null)
            //    {
            //        Response.Redirect("~/public/ChangePassword.aspx");
            //        return;
            //    }
            //}
            //catch (Exception d)
            //{

            //}
            string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            if (baseSiteUrl.Contains(siteBaseUrl))
            {
                Page.Title = "IKANDI FASHION";
            }
            else
            {
                Page.Title = "Boutique International Pvt. Ltd.";

            }
            int portNumber = Request.Url.Port;

            if (portNumber != 80)
            {
                lblPort.Text = "Test";
            }
            else
            {
                lblPort.Text = string.Empty;
            }

            string script = string.Empty;

            if (null != ErrorMessage)
            {
                script = "ShowHideValidationBox(true, '" + ErrorMessage + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
            else if (null != Message)
            {
                script = "ShowHideMessageBox(true, '" + Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }

            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_Logistict_Accountant)
            {
                divBiplInvoicesList.Visible = true;
            }
            else
            {
                divBiplInvoicesList.Visible = false;
            }

            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.iKandi_FinanceLogistics_Accountant)
            {
                divIkandiInvoicesFile.Visible = true;
            }
            else
            {
                divIkandiInvoicesFile.Visible = false;
            }
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_TopManagement_Manager || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_HR_Manager || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_HR_Assistant || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_Logistics_Manager || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation ==
                iKandi.Common.Designation.BIPL_Sales_Manager)
            {
                divBudget.Visible = true;
            }
            else
            {
                divBudget.Visible = false;
            }



            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null)
            {
                TopNavigation.Visible = false;
                divDashboard.Visible = false;
            }
            else
            {
                TopNavigation.Visible = true;
                divDashboard.Visible = true;
            }

            if (!IsPostBack)
            {
                //lblUser.Text = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FullName + " " + "Logged in at " + " " + iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.LastLoginDate.ToString("hh:mm tt");
                lblUser.Text = "Welcome " + iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
                //divIkandiSalesViewFile.DataBind();
                //divPlusIkandiSalesViewFile.DataBind();
              //  divManageOrderFile.DataBind();
                //divBudget.DataBind();
                //divPlusManageOrderFile.DataBind();
                //anchorIkandiSalesViewFile.DataBind();
                //AnchorManageOrderFile.DataBind();
                //divCosting.DataBind();
                //divOrderForm.DataBind();
                //divBiplInvoicesList.DataBind();
                //divIkandiInvoicesFile.DataBind();
            }
            PermissionToAccessPage();
        }
        //added by abhishek on 3/6/2016==================//
        public void PermissionToAccessPage(int departmentID=0, int ApplicationModulaID=0)
        {
            try
            {
                AdminController controller = new AdminController();
                DataTable dt = new DataTable();
                dt = controller.PermissionToAccessPage(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, this.Page.Request.FilePath);
                if (dt.Rows.Count > 0)
                {
                    bool IsValidUser = Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString());
                    string fileName = System.IO.Path.GetFileName(this.Page.Request.FilePath);
                    if (IsValidUser == false)
                    {
                        Response.Redirect("~/PermissionMsgPage.aspx?Mgs=" + fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }
    }
}
