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
using System.Collections.Generic;
using iKandi.Web.Components;
using System.IO;
using System.Globalization;

namespace iKandi.Web.Internal.Leave
{
    public partial class StaffAttandenceFutureLeavePopup : System.Web.UI.Page
    {
        public static int UserID_ 
        {
            get;
            set;
        }
        public string fromleave
        {
            get;
            set;
        }
        public string toleave
        {
            get;
            set;
        }
        static int DeptID;
        static int DesignationID;
        static int LoggedInUser;
        static iKandi.Common.User Userdetails;
        AdminController objadmin = new AdminController();
        DepartmentController objdept = new DepartmentController();
        MembershipController onjmem = new MembershipController(ApplicationHelper.LoggedInUser);
        UserController controller = new UserController();
        List<User>  UsersAll = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getquerystring();
                UsersAll = controller.GetAllUsers();
                bindstaus();
                txttodaydate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                txtattendencedate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                
            }
        }
        public void getquerystring()
        {
            if (Request.QueryString["UserID"] != null)
            {
                UserID_ = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            }
            else
            {
                UserID_ = -1;
            }
            if (Request.QueryString["fromleave"] != null)
            {
                fromleave = Request.QueryString["fromleave"].ToString();
            }
            if (Request.QueryString["toleave"] != null)
            {
                toleave = Request.QueryString["toleave"].ToString();
            }
        }
        public void bindstaus()
        {
            DataTable dt = new DataTable();
            dt = objadmin.GetStaffAttendence("STATUS", 0, 0, 0);
            ddlstatus.DataSource = dt;
            ddlstatus.DataTextField = "Status";
            ddlstatus.DataValueField = "AttandenceStaffID";
            ddlstatus.DataBind();

            iKandi.Common.User Userdetails = UsersAll.Find(x => x.UserID == UserID_);
            //foreach (User a in UsersAll)
            //{
                //if (a.UserID == UserID_)
                //{
                    lblempname.Text = Userdetails.FirstName + " " + Userdetails.LastName;
                    lbldeptname.Text = Userdetails.PrimaryGroupName;
                    lbldesignationname.Text = Userdetails.DesignationName;
                    
               // }
            //}
            if (!string.IsNullOrEmpty(fromleave) && !string.IsNullOrEmpty(toleave))
            {
                txtfrom_current.Text = DateTime.ParseExact(fromleave, "dd/MM/yyyy", null).ToString("dd MMM yy (ddd)");
                txtto_current.Text = DateTime.ParseExact(toleave, "dd/MM/yyyy", null).ToString("dd MMM yy (ddd)");
            }
            else
            {
                txtfrom_current.Enabled = false;
                txtto_current.Enabled = false;
            }
            DeptID = Userdetails.PrimaryGroupID;
            DesignationID = Userdetails.DesignationID;
            LoggedInUser = ApplicationHelper.LoggedInUser.UserData.UserID;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateAttandence();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>CallbackMain();</script>", false);
        }
        protected void btncall_Click(object sender, EventArgs e)
        {

            DateTime fd = DateTime.ParseExact(txtfrom_future.Text.Trim(), "dd MMM yy (ddd)", null);
            DataTable dt = new DataTable();
            if (txtfrom_future.Text.Trim() != "")
            {
                dt = objadmin.CheckPlanleaveStaffAttendence("LEAVECHECK", DeptID, DesignationID, UserID_, fd);
                if (dt.Rows[0]["Result"].ToString() == "EXIST")
                {
                    ShowAlert("Select leave date already taken");
                    txtfrom_future.Text = "";
                    txtto_future.Text = "";
                }
            }
            if (txtto_future.Text.Trim() != "")
            {
                DateTime td = DateTime.ParseExact(txtto_future.Text.Trim(), "dd MMM yy (ddd)", null);
                DataTable dts = new DataTable();
                dts = objadmin.CheckPlanleaveStaffAttendence("LEAVECHECK", DeptID, DesignationID, UserID_, td);
                if (dts.Rows[0]["Result"].ToString() == "EXIST")
                {
                    ShowAlert("Select leave date already taken");
                    txtfrom_future.Text = "";
                    txtto_future.Text = "";
                }
            }
        }
        public void UpdateAttandence()
        {
            try
            {
                txtattendencedate.Text = Request.Form[txtattendencedate.UniqueID];
                txtfrom_future.Text = Request.Form[txtfrom_future.UniqueID];
                txtto_future.Text = Request.Form[txtto_future.UniqueID];

                
                string Intime = "";
                string Outtime = "";
                int StatusiD;
                DateTime Leavefrom;
                DateTime Leaveto;
                decimal NoOfLeaveDay = 0;
                string Remarks = string.Empty;

                DateTime attendencedate = DateTime.ParseExact(txtfrom_future.Text.Trim().Trim(), "dd MMM yy (ddd)", null);
            


                StatusiD = Convert.ToInt16(ddlstatus.SelectedValue);
                Leavefrom = DateTime.ParseExact(txtfrom_future.Text.Trim(), "dd MMM yy (ddd)", null);
                Leaveto = DateTime.ParseExact(txtto_future.Text.Trim(), "dd MMM yy (ddd)", null);
                NoOfLeaveDay = Math.Abs((Leavefrom.Date - Leaveto.Date).Days);

                Remarks = txtremarks_future.Text.Trim();
                string ExtraOuttime = "";
                int IUpdate = objadmin.UpdateStaffAttendence(DeptID, DesignationID, UserID_, Intime, Outtime, StatusiD, Leavefrom, Leaveto, NoOfLeaveDay, Remarks, attendencedate, LoggedInUser, ExtraOuttime);
            }
            catch (Exception ec)
            {
                ShowAlert(ec.Message);
            }


        }
        protected void txtfrom_future_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void txtto_future_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}