using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Forms
{
    public partial class EmailSchedulerForm : BaseUserControl
    {
        private DataSet dsEmailSchedule;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindControls();
        }

        private void BindControls()
        {
            dsEmailSchedule = this.AdminControllerInstance.GetAllEmailSchedule();
            iKandi.Common.EmailTemplate el = new Common.EmailTemplate();
            List<iKandi.Common.EmailTemplate> elst = this.AdminControllerInstance.GetAllEmailTemplates();
            gvEmail.DataSource = elst;
            gvEmail.DataBind();
        }

        protected void gvEmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
                return;
            iKandi.Common.EmailTemplate el = e.Row.DataItem as iKandi.Common.EmailTemplate;
            string days = "";
            string time = "";
            if (el!=null && dsEmailSchedule != null && dsEmailSchedule.Tables.Count > 0 && dsEmailSchedule.Tables[0].Rows.Count > 0)
            {
                DataRow[] drs = dsEmailSchedule.Tables[0].Select("EmailId = " + el.EmailTemplateID);
                if(drs.Length>0)
                {
                    foreach (DataRow dr in drs)
                    {
                        if (!string.IsNullOrEmpty(days.Trim()))
                            days += ",";
                        days += dr["Days"].ToString();
                        time = dr["ETime"].ToString();
                    }
                }
            }
            if(!string.IsNullOrEmpty(days))
            {
                DropDownList ddlPlan = e.Row.FindControl("ddlPlan") as DropDownList;
                if(ddlPlan!=null)
                {
                    if (days == "0")
                        ddlPlan.SelectedIndex = 0;
                    else
                        ddlPlan.SelectedIndex = 1;
                }
            }
            DropDownList ddlTime = e.Row.FindControl("ddlTime") as DropDownList;
            if (ddlTime != null)
            {
                DateTime dt = new DateTime();
                ddlTime.Items.Clear();
                for (int i = 0; i < 48; i++)
                {
                    if ("12:00 am" == dt.ToString("hh:mm tt").ToLower())
                    {
                        ListItem lst = new ListItem("--Select--", dt.ToString("hh:mm tt"));
                        if (time == dt.ToString("HH:mm:ss"))
                        lst.Selected = true;
                        ddlTime.Items.Add(lst);
                    }
                    else
                    {
                        ListItem lst = new ListItem(dt.ToString("hh:mm tt"), dt.ToString("hh:mm tt"));
                        if (time == dt.ToString("HH:mm:ss"))
                            lst.Selected = true;
                        ddlTime.Items.Add(lst);
                    }
                    dt = dt.AddMinutes(30);
                }
                    
            }
            CheckBoxList cblWeek = e.Row.FindControl("cblWeek") as CheckBoxList;
            if (cblWeek != null)
            {
                string[] wName = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                for (int i = 0; i < 7; i++)
                {
                    ListItem lst = new ListItem(wName[i], (i + 1).ToString());
                    if (days.IndexOf((i + 1).ToString())!=-1)
                        lst.Selected = true;
                    cblWeek.Items.Add(lst);
                }
            }
        }

        protected void btnSubmit_Click(object seder,EventArgs e)
        {
            foreach (GridViewRow gvr in gvEmail.Rows)
            {
                int emailId = Convert.ToInt32(((HiddenField)gvr.FindControl("hfId")).Value);
                string time = ((DropDownList)gvr.FindControl("ddlTime")).Text;
                string plan = ((DropDownList)gvr.FindControl("ddlPlan")).Text.ToUpper();
                string days = "";
                if (plan == "DAILY")
                    days = "0";
                else
                {
                    CheckBoxList cbl = (CheckBoxList) gvr.FindControl("cblWeek");
                    foreach (ListItem lst in cbl.Items)
                    {
                        if (lst.Selected)
                        {
                            if (!string.IsNullOrEmpty(days.Trim()))
                                days += ",";
                            days += lst.Value;
                        }
                    }
                }
                if (string.IsNullOrEmpty(days.Trim()))
                    days = "0";
                this.AdminControllerInstance.Insert_Email_Schedule_Data(emailId, days, time);
            }
        }
    }
}