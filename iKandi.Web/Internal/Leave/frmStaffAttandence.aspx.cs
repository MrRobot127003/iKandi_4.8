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
    public partial class frmStaffAttandence : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        DepartmentController objdept = new DepartmentController();
        MembershipController onjmem = new MembershipController(ApplicationHelper.LoggedInUser);
        string StaffName = "";
        public int Edit
        {
            get;
            set;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            //this.btnSubmit.Attributes.Add("onclick", "this.disabled=true;");
            //this.btnSubmit.UseSubmitBehavior = false;
            if (!Page.IsPostBack)
            {

                BindPrimeryGroupDept(2);
                txtattendencedate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                BindGrd();

            }


        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            DataTable dtCheckHoliday = objadmin.CheckHoliday(DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null));//check holiday
            if (dtCheckHoliday.Rows.Count > 0)
            {
                btnSubmit.Enabled = false;
                btnSubmit.Style.Add("background-color", "grey !important");
                grdattendence.EmptyDataText = "Holiday " + dtCheckHoliday.Rows[0]["EventsDescription"];
                grdattendence.DataSource = new string[] { };
                grdattendence.DataBind();

                ShowAlert("You cannot make entry on holiday");
            }
            else
            {
                btnSubmit.Enabled = true;
                btnSubmit.Style.Add("background-color", "#13a747 !important");
                BindGrd();
            }
        }
        public void BindGrd()
        {
            DataTable dt = new DataTable();
            dt = objadmin.GetStaffAttendence("ATTENDANCE", Convert.ToInt32(ddldeptname.SelectedValue), Convert.ToInt32(ddlDesignation.SelectedValue), Convert.ToInt32(ddluser.SelectedValue));
            grdattendence.DataSource = dt;
            grdattendence.DataBind();
            if (dt.Rows.Count <= 0)
            {
                btnSubmit.Enabled = false;
                btnSubmit.Style.Add("background-color", "grey !important");
            }
            else
            {

            }

            // MergeCells();
        }

        public void bindstaus(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt = objadmin.GetStaffAttendence("STATUS", 0, 0, 0);
            ddl.DataSource = dt;
            ddl.DataTextField = "Status";
            ddl.DataValueField = "AttandenceStaffID";
            ddl.DataBind();

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public string CheckWeekoff(string UserID)
        {
            string result = "";
            User user = onjmem.GetUser(Convert.ToInt32(UserID));
            string[] SelectedWkOff = user.WeekOff.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            DateTime checksunday = Convert.ToDateTime(DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null));
            DayOfWeek day = checksunday.DayOfWeek;
            foreach (string wk in SelectedWkOff)
            {
                //if (day.ToString().ToLower() == wk.ToLower() && day != null)
                 if (day.ToString().ToLower() == wk.ToLower())
                {
                    result = "WO";
                    break;
                }
            }
            return result;
        }
        public bool GetPlanedLeaveStatus(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck <= endDate;
        }
        protected void grdattendence_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdndepartmentid = (HiddenField)e.Row.FindControl("hdndepartmentid");
                HiddenField hdndesignationID = (HiddenField)e.Row.FindControl("hdndesignationID");
                HiddenField hdnUserID = (HiddenField)e.Row.FindControl("hdnUserID");
                DropDownList ddlstatus = (DropDownList)e.Row.FindControl("ddlstatus");
                bindstaus(ddlstatus);
                TextBox txtintime = (TextBox)e.Row.FindControl("txtintime");
                TextBox txtouttime = (TextBox)e.Row.FindControl("txtouttime");
                TextBox txtleavedaycount = (TextBox)e.Row.FindControl("txtleavedaycount");
                TextBox txtremarks = (TextBox)e.Row.FindControl("txtremarks");

                TextBox txtleavefrom = (TextBox)e.Row.FindControl("txtleavefrom");
                TextBox txtleaveto = (TextBox)e.Row.FindControl("txtleaveto");

                TextBox txtintime_mm = (TextBox)e.Row.FindControl("txtintime_mm");
                TextBox txtoutfrom_mm = (TextBox)e.Row.FindControl("txtoutfrom_mm");

                TextBox txtExtraouttime = (TextBox)e.Row.FindControl("txtExtraouttime");
                TextBox txtExtraoutfrom_mm = (TextBox)e.Row.FindControl("txtExtraoutfrom_mm");

                HiddenField hdnleavefrom = (HiddenField)e.Row.FindControl("hdnleavefrom");
                HiddenField hdnleaveto = (HiddenField)e.Row.FindControl("hdnleaveto");
                //txtintime.Attributes.Add("onkeypress", "return false;");
                //txtouttime.Attributes.Add("onkeypress", "return false;");

                if (CheckWeekoff(hdnUserID.Value) != "")
                {
                    ddlstatus.SelectedValue = "2";
                }
                DataTable dt = objadmin.GetStaffAttendenceDetailByDate(Convert.ToInt32(hdndepartmentid.Value), Convert.ToInt32(hdndesignationID.Value), Convert.ToInt32(hdnUserID.Value), DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null)).Tables[0];
                DataTable dtleave = objadmin.GetStaffAttendenceDetailByDateleave(Convert.ToInt32(hdndepartmentid.Value), Convert.ToInt32(hdndesignationID.Value), Convert.ToInt32(hdnUserID.Value), DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null));
                if (dtleave.Rows.Count > 0 && dtleave.Rows[0]["LeaveFrom"].ToString() != "" && dtleave.Rows[0]["LeaveTo"].ToString() != "")
                {
                    txtleavefrom.Text = dtleave.Rows[0]["LeaveFrom"].ToString() == "" ? "" : Convert.ToDateTime(dtleave.Rows[0]["LeaveFrom"]).ToString("dd/MM/yyyy");
                    hdnleavefrom.Value = dtleave.Rows[0]["LeaveFrom"].ToString() == "" ? "" : Convert.ToDateTime(dtleave.Rows[0]["LeaveFrom"]).ToString("dd/MM/yyyy");
                    txtleaveto.Text = dtleave.Rows[0]["LeaveTo"].ToString() == "" ? "" : Convert.ToDateTime(dtleave.Rows[0]["LeaveTo"]).ToString("dd/MM/yyyy");
                    hdnleaveto.Value = dtleave.Rows[0]["LeaveTo"].ToString() == "" ? "" : Convert.ToDateTime(dtleave.Rows[0]["LeaveTo"]).ToString("dd/MM/yyyy");
                    txtleavedaycount.Text = ((dtleave.Rows[0]["LeaveDays"].ToString() == "" || dtleave.Rows[0]["LeaveDays"].ToString() == "0") ? "" : dtleave.Rows[0]["LeaveDays"].ToString());
                    txtremarks.Text = dtleave.Rows[0]["HRRemarks"].ToString();
                    if (CheckWeekoff(hdnUserID.Value) == "WO")
                    {
                        if ((dtleave.Rows[0]["StatusID"].ToString() != "-1"))
                        {
                            ddlstatus.SelectedValue = dtleave.Rows[0]["StatusID"].ToString();
                        }
                        else
                        {
                            ddlstatus.SelectedValue = "2";
                            //txtleavefrom.Text = "";
                            //txtleaveto.Text = "";
                        }
                    }
                    else
                    {
                        ddlstatus.SelectedValue = dtleave.Rows[0]["StatusID"].ToString();
                        if (ddlstatus.SelectedValue == "-1")
                        {
                            if (GetPlanedLeaveStatus(DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null), Convert.ToDateTime(dtleave.Rows[0]["LeaveFrom"]), Convert.ToDateTime(dtleave.Rows[0]["LeaveTo"])) == true)
                            {
                                //ddlstatus.SelectedValue = "4";
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (CheckWeekoff(hdnUserID.Value) == "WO")
                        {
                            if ((dt.Rows[0]["StatusID"].ToString() != "-1"))
                            {
                                ddlstatus.SelectedValue = dt.Rows[0]["StatusID"].ToString();
                            }
                            else
                            {
                                ddlstatus.SelectedValue = "2";
                                //txtleavefrom.Text = "";
                                //txtleaveto.Text = "";
                            }
                        }
                        {
                            ddlstatus.SelectedValue = dt.Rows[0]["StatusID"].ToString();
                        }

                        /*if (dt.Rows[0]["LeaveFrom"].ToString() != "")
                        {
                          txtleavefrom.Text = Convert.ToDateTime(dt.Rows[0]["LeaveFrom"].ToString()).ToString("dd/MM/yyyy");
                          hdnleavefrom.Value = Convert.ToDateTime(dt.Rows[0]["LeaveFrom"].ToString()).ToString("dd/MM/yyyy");
                        }
                        if (dt.Rows[0]["LeaveTo"].ToString() != "")
                        {
                          txtleaveto.Text = Convert.ToDateTime(dt.Rows[0]["LeaveTo"].ToString()).ToString("dd/MM/yyyy");
                          hdnleaveto.Value = Convert.ToDateTime(dt.Rows[0]["LeaveTo"].ToString()).ToString("dd/MM/yyyy");
                        }*/
                        txtremarks.Text = dt.Rows[0]["HRRemarks"].ToString();
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["InTime"].ToString() != "")
                    {
                        string[] HHMM = dt.Rows[0]["InTime"].ToString().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (HHMM.ElementAtOrDefault(0) != null)
                        {
                            txtintime.Text = HHMM[0].ToString();
                        }
                        if (HHMM.ElementAtOrDefault(1) != null)
                        {
                            txtintime_mm.Text = HHMM[1].ToString();
                        }
                        string strislate = ValidateLateComing(dt.Rows[0]["InTime"].ToString(), Convert.ToInt32(hdndepartmentid.Value), Convert.ToInt32(hdnUserID.Value));
                        if (strislate == "RED")
                        {
                            txtintime.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0034");
                            txtintime_mm.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0034");
                        }
                    }
                    if (dt.Rows[0]["OutTime"].ToString() != "")
                    {
                        string[] HHMM_2 = dt.Rows[0]["OutTime"].ToString().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (HHMM_2.ElementAtOrDefault(0) != null)
                        {
                            txtouttime.Text = HHMM_2[0].ToString();
                        }
                        if (HHMM_2.ElementAtOrDefault(1) != null)
                        {
                            txtoutfrom_mm.Text = HHMM_2[1].ToString();
                        }
                    }
                    if (txtouttime.Text == "23" && txtoutfrom_mm.Text == "59")//extra time 
                    {
                        txtExtraouttime.Enabled = true;
                        txtExtraoutfrom_mm.Enabled = true;
                        if (dt.Rows[0]["ExtraOutTime"].ToString() != "")
                        {
                            string[] HHMM_2 = dt.Rows[0]["ExtraOutTime"].ToString().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                            if (HHMM_2.ElementAtOrDefault(0) != null)
                            {
                                txtExtraouttime.Text = HHMM_2[0].ToString();
                            }
                            if (HHMM_2.ElementAtOrDefault(1) != null)
                            {
                                txtExtraoutfrom_mm.Text = HHMM_2[1].ToString();
                            }
                        }
                    }
                }

                if (ddlstatus.SelectedValue == "1")
                {

                    txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                    txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");

                    txtintime_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                    txtoutfrom_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");

                }
                if (ddlstatus.SelectedValue == "2")
                {

                    txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                    txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");

                    txtintime_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                    txtoutfrom_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                    txtleavefrom.Enabled = false;
                    txtleaveto.Enabled = false;
                    txtleavedaycount.Enabled = false;
                }
                if (ddlstatus.SelectedValue == "3")
                {

                    txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD27D");
                    txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD27D");

                    txtintime_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD27D");
                    txtoutfrom_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD27D");


                }
                if (ddlstatus.SelectedValue == "4")
                {

                    txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("#2AFF7F");
                    txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("#2AFF7F");

                    txtintime_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#2AFF7F");
                    txtoutfrom_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#2AFF7F");

                }
                if (ddlstatus.SelectedValue == "5")
                {
                    txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("#00AAFF");
                    txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("#00AAFF");

                    txtintime_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#00AAFF");
                    txtoutfrom_mm.BackColor = System.Drawing.ColorTranslator.FromHtml("#00AAFF");
                }

                if (ddlstatus.SelectedValue == "-1" || ddlstatus.SelectedValue == "1" || ddlstatus.SelectedValue == "2")
                {
                    txtleavefrom.Enabled = false;
                    txtleaveto.Enabled = false;
                    txtleavedaycount.Enabled = false;

                    txtleavefrom.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                    txtleaveto.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                    txtleavedaycount.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");

                }
                Label lbldepartmentName = (Label)e.Row.FindControl("lbldepartmentName");
                HiddenField hdndeptcount = (HiddenField)e.Row.FindControl("hdndeptcount");
                string Count = "0";
                if (lbldepartmentName != null)
                {
                    if (StaffName != lbldepartmentName.Text)
                    {
                        StaffName = lbldepartmentName.Text;


                        Count = hdndeptcount.Value;


                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Cells[0].Attributes.Add("rowspan", Count);
                            if (Convert.ToInt32(Count) <= 3)
                            {
                                lbldepartmentName.CssClass.Remove(0);
                                lbldepartmentName.CssClass = "rotate2";


                            }
                        }
                    }
                    else
                    {
                        e.Row.Cells[0].Visible = false;
                    }

                }


            }
        }
        protected void txtleavefrom_TextChanged(object sender, EventArgs e)
        {
            TextBox txtleavefrom = (TextBox)sender;
            GridViewRow row1 = (GridViewRow)txtleavefrom.NamingContainer;
            TextBox txtdate = (TextBox)row1.FindControl("txtleavefrom");
            int ChkWeekCount = 1;
            
            DateTime selecteddate = Convert.ToDateTime(txtdate.Text);

            if (selecteddate.DayOfWeek.ToString() == "Sunday" || selecteddate.DayOfWeek.ToString() == "sunday")
            {
                ChkWeekCount = 2;
            }
            DateTime Currentdate = DateTime.Now;

            if (selecteddate.DayOfWeek.ToString() == "Sunday" || selecteddate.DayOfWeek.ToString() == "sunday")
            {
                ChkWeekCount = 2;
            }
            DateTime predate = selecteddate.AddDays(ChkWeekCount);
            //if(selecteddate.Date == DateTime.Now.Date&&predate.Date==DateTime.Now.AddDays(ChkWeekCount))
        }
        protected void grdattendence_DataBound(object sender, EventArgs e)
        {
            for (int i = grdattendence.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdattendence.Rows[i];
                GridViewRow previousRow = grdattendence.Rows[i - 1];

                //for (int j = 0; j < row.Cells.Count - 1; j++)
                // {
                Label lblStaffDept = (Label)row.Cells[0].FindControl("lbldepartmentName");
                Label lblPreviousStaffDept = (Label)previousRow.Cells[0].FindControl("lbldepartmentName");

                if (lblStaffDept.Text == lblPreviousStaffDept.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
                // }
            }
        }
        private void MergeCells()
        {
            int i = grdattendence.Rows.Count - 2;
            while (i >= 0)
            {
                GridViewRow curRow = grdattendence.Rows[i];
                GridViewRow preRow = grdattendence.Rows[i + 1];

                int j = 0;
                while (j < curRow.Cells.Count)
                {
                    if (curRow.Cells[j].Text == preRow.Cells[j].Text)
                    {
                        if (preRow.Cells[j].RowSpan < 2)
                        {
                            curRow.Cells[j].RowSpan = 2;
                            preRow.Cells[j].Visible = false;
                        }
                        else
                        {
                            curRow.Cells[j].RowSpan = preRow.Cells[j].RowSpan + 1;
                            preRow.Cells[j].Visible = false;
                        }
                    }
                    j++;
                }
                i--;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateAttandence();
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList status = (DropDownList)sender;
            GridViewRow row1 = (GridViewRow)status.NamingContainer;
            DropDownList ddlstatus = (DropDownList)row1.FindControl("ddlstatus");
            TextBox txtintime = (TextBox)row1.FindControl("txtintime");
            TextBox txtouttime = (TextBox)row1.FindControl("txtouttime");
            if (ddlstatus.SelectedValue == "1")//OD
            {
                txtintime.Text = "";
                txtouttime.Text = "";

                txtintime.BackColor = System.Drawing.ColorTranslator.FromHtml("");
                txtouttime.BackColor = System.Drawing.ColorTranslator.FromHtml("");

                txtintime.Attributes.Remove("class");
                txtouttime.Attributes.Remove("class");
            }
            if (ddlstatus.SelectedValue == "2")//WO
            {
                txtintime.Text = "";
                txtouttime.Text = "";

                txtintime.BackColor = System.Drawing.Color.Yellow;
                txtouttime.BackColor = System.Drawing.Color.Yellow;
                txtintime.Attributes.Remove("class");
                txtouttime.Attributes.Remove("class");
            }
            if (ddlstatus.SelectedValue == "3")//Unauthorised Absence
            {
                txtintime.Text = "";
                txtouttime.Text = "";

                txtintime.BackColor = System.Drawing.Color.Red;
                txtouttime.BackColor = System.Drawing.Color.Red;
                txtintime.Attributes.Remove("class");
                txtouttime.Attributes.Remove("class");
            }
            if (ddlstatus.SelectedValue == "4")//Planned Leave
            {
                txtintime.Text = "";
                txtouttime.Text = "";

                txtintime.BackColor = System.Drawing.Color.Blue;
                txtouttime.BackColor = System.Drawing.Color.Blue;
                txtintime.Attributes.Remove("class");
                txtouttime.Attributes.Remove("class");

            }
            if (ddlstatus.SelectedValue == "5")//Unplanned Leave
            {
                txtintime.Text = "";
                txtouttime.Text = "";

                txtintime.BackColor = System.Drawing.Color.Green;
                txtouttime.BackColor = System.Drawing.Color.Green;
                txtintime.Attributes.Remove("class");
                txtouttime.Attributes.Remove("class");
            }

        }
        public void UpdateAttandence()
        {
            foreach (GridViewRow gvr in grdattendence.Rows)
            {
                int DeptID;
                int DesignationID;
                int LoggedInUser;
                string Intime = "";
                string Outtime = "";
                int StatusiD;
                DateTime Leavefrom;
                DateTime Leaveto;
                decimal NoOfLeaveDay = 0;
                string Remarks = string.Empty;
                DateTime attendencedate = DateTime.ParseExact(txtattendencedate.Text.Trim().Trim(), "dd/MM/yyyy", null);

                HiddenField hdndepartmentid = (HiddenField)gvr.FindControl("hdndepartmentid");
                HiddenField hdndesignationID = (HiddenField)gvr.FindControl("hdndesignationID");
                HiddenField hdnUserID = (HiddenField)gvr.FindControl("hdnUserID");
                TextBox txtintime = (TextBox)gvr.FindControl("txtintime");
                TextBox txtouttime = (TextBox)gvr.FindControl("txtouttime");
                DropDownList ddlstatus = (DropDownList)gvr.FindControl("ddlstatus");
                TextBox txtleavefrom = (TextBox)gvr.FindControl("txtleavefrom");
                TextBox txtleaveto = (TextBox)gvr.FindControl("txtleaveto");
                TextBox txtleavedaycount = (TextBox)gvr.FindControl("txtleavedaycount");
                TextBox txtremarks = (TextBox)gvr.FindControl("txtremarks");

                TextBox txtintime_mm = (TextBox)gvr.FindControl("txtintime_mm");
                TextBox txtoutfrom_mm = (TextBox)gvr.FindControl("txtoutfrom_mm");

                TextBox txtExtraouttime = (TextBox)gvr.FindControl("txtExtraouttime");
                TextBox txtExtraoutfrom_mm = (TextBox)gvr.FindControl("txtExtraoutfrom_mm");

                DeptID = Convert.ToInt16(hdndepartmentid.Value);
                DesignationID = Convert.ToInt16(hdndesignationID.Value);
                LoggedInUser = ApplicationHelper.LoggedInUser.UserData.UserID;
                if (txtintime.Text.Trim() != "")
                {
                    if (txtintime.Text.Trim() == "")
                    {
                        txtintime_mm.Text = "00";
                    }
                }
                if (txtouttime.Text.Trim() != "")
                {
                    if (txtoutfrom_mm.Text.Trim() == "")
                    {
                        txtoutfrom_mm.Text = "00";
                    }
                }
                if (txtintime_mm.Text.Trim().Length == 1)
                    txtintime_mm.Text = "0" + txtintime_mm.Text.Trim();

                if (txtoutfrom_mm.Text.Trim().Length == 1)
                    txtoutfrom_mm.Text = "0" + txtoutfrom_mm.Text.Trim();

                Intime = txtintime.Text.Trim() + ":" + txtintime_mm.Text.Trim();
                Outtime = txtouttime.Text.Trim() + ":" + txtoutfrom_mm.Text.Trim();
                StatusiD = Convert.ToInt16(ddlstatus.SelectedValue);

                Intime = Intime == ":" ? "" : Intime;
                Outtime = Outtime == ":" ? "" : Outtime;

                if (txtleavefrom.Text.Trim() != "")
                {
                    Leavefrom = DateTime.ParseExact(txtleavefrom.Text.Trim(), "dd/MM/yyyy", null);

                }
                else
                {
                    Leavefrom = DateTime.MinValue;
                }
                if (txtleaveto.Text.Trim() != "")
                {
                    Leaveto = DateTime.ParseExact(txtleaveto.Text.Trim(), "dd/MM/yyyy", null);
                }
                else
                {
                    Leaveto = DateTime.MinValue;
                }
                if (txtleavedaycount.Text != "")
                {
                    NoOfLeaveDay = Convert.ToDecimal(txtleavedaycount.Text);
                }
                Remarks = txtremarks.Text;
                txtExtraouttime.Text = ((txtExtraouttime.Text == "" || (txtExtraouttime.Text == "0")) ? "00" : txtExtraouttime.Text);
                if (txtExtraouttime.Text.Trim() != "")
                {
                    txtExtraoutfrom_mm.Text = ((txtExtraoutfrom_mm.Text == "" || (txtExtraoutfrom_mm.Text == "0")) ? "00" : txtExtraoutfrom_mm.Text);
                    if (txtExtraoutfrom_mm.Text.Trim().Length == 1)
                        txtExtraoutfrom_mm.Text = "0" + txtExtraoutfrom_mm.Text;
                }
                string ExtraOuttime = txtExtraouttime.Text.Trim() + ":" + txtExtraoutfrom_mm.Text.Trim();
                ExtraOuttime = (ExtraOuttime == ":" ? "" : ExtraOuttime);
                ExtraOuttime = (ExtraOuttime == "00:00" ? "" : ExtraOuttime);
                int IUpdate = objadmin.UpdateStaffAttendence(DeptID, DesignationID, Convert.ToInt32(hdnUserID.Value), Intime, Outtime, StatusiD, Leavefrom, Leaveto, NoOfLeaveDay, Remarks, attendencedate, LoggedInUser, ExtraOuttime);

            }
            Response.Redirect(Request.RawUrl, true);
        }
        public string ValidateLateComing(string starttime, int DepartmentID, int UserID)
        {
            User user = onjmem.GetUser(Convert.ToInt32(UserID));
            double Bufferminuts = 20;
            string Result = string.Empty;
            if (DepartmentID != 34)//non IT
            {                
                string two = starttime;
                string H = starttime.Split(':')[0];
                string M = starttime.Split(':')[1];
                string stattH = "";
                string stattM = "";
                if (H.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattH = "0" + H;
                }
                else
                {
                    stattH = H;

                }
                if (M.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattM = "0" + M;
                }
                else
                {
                    stattM = M;
                }
                starttime = stattH.Trim() + ":" + stattM.Trim();
                string iString = "2005-05-05 " + starttime;
                DateTime InTime = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm", null);
                // string ostring = "2005-05-05 " + "09:50";

                string ostring = "2005-05-05 " + user.Intime.Substring(0, 5);
                DateTime officetime = DateTime.ParseExact(ostring, "yyyy-MM-dd HH:mm", null);
                if (InTime > officetime.AddMinutes(Bufferminuts))
                {
                    Result = "RED";
                }
            }
            if (DepartmentID == 34)//for IT
            {
                string two = starttime;
                string H = starttime.Split(':')[0];
                string M = starttime.Split(':')[1];
                string stattH = "";
                string stattM = "";
                if (H.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattH = "0" + H;
                }
                else
                {
                    stattH = H;

                }
                if (M.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattM = "0" + M;
                }
                else
                {
                    stattM = M;
                }
                starttime = stattH.Trim() + ":" + stattM.Trim();
                string iString = "2005-05-05 " + starttime;
                DateTime InTime = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm", null);
                string ostring = "2005-05-05 " + user.Intime.Substring(0, 5);
                DateTime officetime = DateTime.ParseExact(ostring, "yyyy-MM-dd HH:mm", null);
                if (InTime > officetime.AddMinutes(Bufferminuts))
                {
                    Result = "RED";
                }
            }
            return Result;
        }
        public void BindPrimeryGroupDept(int CompanyID)
        {
            ddldeptname.Items.Clear();
            List<Department> obj = objdept.GetDepartmentsByCompany_new(2);
            ddldeptname.DataSource = obj;
            ddldeptname.DataTextField = "Name";
            ddldeptname.DataValueField = "DepartmentID";
            ddldeptname.DataBind();
            ddldeptname.Items.Insert(0, new ListItem("ALL", "-1"));
            ddlDesignation.Items.Insert(0, new ListItem("ALL", "-1"));
            ddluser.Items.Insert(0, new ListItem("ALL", "-1"));
        }
        public void BindDesignation(int DepartmentID)
        {
            ddlDesignation.Items.Clear();
            DesignationController objdepcontroller = new DesignationController();
            List<UserDesignation> obj = objdepcontroller.GetDesignationsByDepartment_new(DepartmentID);
            ddlDesignation.DataSource = obj;
            ddlDesignation.DataTextField = "Name";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("ALL", "-1"));
        }
        protected void ddldeptname_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDesignation(Convert.ToInt32(ddldeptname.SelectedValue));
            ddluser.Items.Clear();
            ddluser.Items.Insert(0, new ListItem("ALL", "-1"));
        }
        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddluser.Items.Clear();
            UserController controller = new UserController(ApplicationHelper.LoggedInUser);
            List<User> users = controller.GetUsersByDesignation_new(Convert.ToInt32(ddlDesignation.SelectedValue));

            foreach (User user in users)
            {
                ddluser.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
            }
            ddluser.Items.Insert(0, new ListItem("ALL", "-1"));

        }
    }
}