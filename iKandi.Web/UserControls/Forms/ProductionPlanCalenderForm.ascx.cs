using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace iKandi.Web.UserControls.Forms
{
    public partial class ProductionPlanCalenderForm : System.Web.UI.UserControl
    {
        AdminController objAdminController = new AdminController();
        DataTable dtworkingHrs = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                //filterMonth();
                filterYear();
               
                BindGrd(DateTime.Today.Month, DateTime.Today.Year);
               
            }
         
        }
        public void BindGrd(int month, int year)
        {
            AdminController objadmin = new AdminController();
            grdproductionCalender.DataSource = objadmin.GetProductionCalenderDetails(month, year);
            grdproductionCalender.DataBind();
            dtworkingHrs = objAdminController.GetworkingHrs(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));
            if (dtworkingHrs.Rows.Count > 0)
                txtWorkingDays.Text = dtworkingHrs.Rows[0]["WorkingHrs"].ToString();
            else
                txtWorkingDays.Text = "";


        }
        public void filterMonth()
        {
            if (ddlyear.SelectedValue.ToString() == DateTime.Today.Year.ToString())
            {
                //for (int i = 1; i < DateTime.Today.Month; i++)
                //{
                //    // ddlMonth.Items.RemoveAt(i);
                //    // ddlMonth.Items.Remove(ddlMonth.Items[i]);
                //    ddlMonth.Items.Remove(ddlMonth.Items.FindByValue(i.ToString()));
                //}
                ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
            }
            //else if (Convert.ToInt32(ddlyear.SelectedValue) > DateTime.Today.Year)
            //{
            //    // do nothing
            //    //for (int i = 1; i < DateTime.Today.Month; i++)
            //    //{
            //    //    // ddlMonth.Items.RemoveAt(i);
            //    //    // ddlMonth.Items.Remove(ddlMonth.Items[i]);
            //    //    ddlMonth.Items.Add(ddlMonth.Items.FindByValue(i.ToString()));
            //    //}
            //}
            else
            {
                ddlMonth.SelectedValue = "1";
                //for (int i = 1; i < DateTime.Today.Month; i++)
                //{
                //    // ddlMonth.Items.RemoveAt(i);
                //    // ddlMonth.Items.Remove(ddlMonth.Items[i]);
                //    ddlMonth.Items.Remove(ddlMonth.Items.FindByValue(i.ToString()));
                //}
            }
        }

        public void filterYear()
        {
            //for (int i = 2016; i < DateTime.Today.Year; i++)
            //{
            //    // ddlMonth.Items.RemoveAt(i);
            //    // ddlMonth.Items.Remove(ddlMonth.Items[i]);
            //    ddlyear.Items.Remove(ddlMonth.Items.FindByValue(i.ToString()));
            //}
            ddlyear.SelectedValue = DateTime.Today.Year.ToString();
            filterMonth();

        }
        public int GetMonthNumber()
        {int a=0;
            string month = ddlMonth.SelectedItem.Text;
            if (month == "January")
                a = 1;
            if (month == "February")
                a = 2;
            if (month == "March")
                a = 3;
            if (month == "April")
                a = 4;
            if (month == "May")
                a = 5;
            if (month == "June")
                a = 6;

            if (month == "July")
                a = 7;
            if (month == "August")
                a = 8;
            if (month == "September")
                a = 9;
            if (month == "October")
                a = 10;
            if (month == "November")
                a = 11;
            if (month == "December")
                a = 12;
            return a;

        }
        protected void grdproductionCalender_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.Header)
            {




            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //HyperLink hylnkMonday = (HyperLink)e.Row.FindControl("hylnkMonday");
                LinkButton lnkpopupMonday = (LinkButton)e.Row.FindControl("lnkpopupMonday") as LinkButton;
                Label lblworkinghoursMonday = (Label)e.Row.FindControl("lblworkinghoursMonday");
                Label lbleventMonday = (Label)e.Row.FindControl("lbleventMonday");
                HiddenField hdnIdMonday = (HiddenField)e.Row.FindControl("hdnIdMonday");
                DataTable dt=new DataTable();

                int popupMondayDay = lnkpopupMonday.Text==""?0:Convert.ToInt32(lnkpopupMonday.Text);
                dt = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdMonday.Value), popupMondayDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                if (lnkpopupMonday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopupMonday.Text));

                    if (results == true)
                    {
                        lnkpopupMonday.Enabled = false;
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {

                        e.Row.Cells[1].CssClass = "leave_back_holy";
                        lblworkinghoursMonday.Visible = true;
                        lbleventMonday.Visible = true;
                        lblworkinghoursMonday.Text = dt.Rows[0]["woringHours"].ToString()=="0"?"Full day":dt.Rows[0]["woringHours"].ToString()+" "+"hrs";
                        lbleventMonday.Text = dt.Rows[0]["EventsDescription"].ToString();

                        lnkpopupMonday.Attributes.Add("style", "float:left");

                    }
                }
               

                //--------------------------monday

                //HyperLink hylnktuesday = (HyperLink)e.Row.FindControl("hylnktuesday");
                LinkButton lnkpopuptuesday = (LinkButton)e.Row.FindControl("lnkpopuptuesday") as LinkButton;
                Label lblworkinghourstuesday = (Label)e.Row.FindControl("lblworkinghourstuesday");
                Label lbleventtuesday = (Label)e.Row.FindControl("lbleventtuesday");
                HiddenField hdnIdtuesday = (HiddenField)e.Row.FindControl("hdnIdtuesday");


                DataTable dttuesday = new DataTable();
                int popuptuesday = lnkpopuptuesday.Text == "" ? 0 : Convert.ToInt32(lnkpopuptuesday.Text);
                dttuesday = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdtuesday.Value), popuptuesday, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                if (lnkpopuptuesday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopuptuesday.Text));

                    if (results == true)
                    {
                        lnkpopuptuesday.Enabled = false;
                    }
                }

                if (dttuesday.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dttuesday.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {

                        e.Row.Cells[2].CssClass = "leave_back_holy";
                        lblworkinghourstuesday.Visible = true;
                        lbleventtuesday.Visible = true;

                        lblworkinghourstuesday.Text = dttuesday.Rows[0]["woringHours"].ToString() == "0" ? "Full day" : dttuesday.Rows[0]["woringHours"].ToString() + " " + "hrs";
                        lbleventtuesday.Text = dttuesday.Rows[0]["EventsDescription"].ToString();
                        lnkpopuptuesday.Attributes.Add("style", "float:left");
                    }
                }
                //--------------------------tuesday


                LinkButton lnkpopupwednesday = (LinkButton)e.Row.FindControl("lnkpopupwednesday") as LinkButton;
                Label lblworkinghourkwednesdays = (Label)e.Row.FindControl("lblworkinghourkwednesdays");
                Label lbleventkwednesday = (Label)e.Row.FindControl("lbleventkwednesday");
                HiddenField hdnIdkwednesday = (HiddenField)e.Row.FindControl("hdnIdkwednesday");


                DataTable dtwednesday = new DataTable();
                int popupwednesday = lnkpopupwednesday.Text == "" ? 0 : Convert.ToInt32(lnkpopupwednesday.Text);
                dtwednesday = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdkwednesday.Value), popupwednesday, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                if (lnkpopupwednesday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopupwednesday.Text));

                    if (results == true)
                    {
                        lnkpopupwednesday.Enabled = false;
                    }
                }

                if (dtwednesday.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dtwednesday.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {
                        e.Row.Cells[3].CssClass = "leave_back_holy";
                        
                        lblworkinghourkwednesdays.Visible = true;
                        lbleventkwednesday.Visible = true;

                        lblworkinghourkwednesdays.Text = dtwednesday.Rows[0]["woringHours"].ToString() == "0" ? "Full day" : dtwednesday.Rows[0]["woringHours"].ToString() + " " + "hrs";
                        lbleventkwednesday.Text = dtwednesday.Rows[0]["EventsDescription"].ToString();

                        lnkpopupwednesday.Attributes.Add("style", "float:left");

                    }
                }
                //--------------------------wednesday



                LinkButton lnkpopupthursday = (LinkButton)e.Row.FindControl("lnkpopupthursday") as LinkButton;
                Label lblworkinghoursthursday = (Label)e.Row.FindControl("lblworkinghoursthursday");
                Label lbleventthursday = (Label)e.Row.FindControl("lbleventthursday");
                HiddenField hdnIdthursday = (HiddenField)e.Row.FindControl("hdnIdthursday");

                DataTable dtthursday = new DataTable();
                int popupthursday = lnkpopupthursday.Text == "" ? 0 : Convert.ToInt32(lnkpopupthursday.Text);
                dtthursday = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdthursday.Value), popupthursday, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                if (lnkpopupthursday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopupthursday.Text));

                    if (results == true)
                    {
                        lnkpopupthursday.Enabled = false;
                    }
                }

                if (dtthursday.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dtthursday.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {

                        e.Row.Cells[4].CssClass = "leave_back_holy";
                        lblworkinghoursthursday.Visible = true;
                        lbleventthursday.Visible = true;

                        lblworkinghoursthursday.Text = dtthursday.Rows[0]["woringHours"].ToString() == "0" ? "Full day" : dtthursday.Rows[0]["woringHours"].ToString() + " " + "hrs";
                        lbleventthursday.Text = dtthursday.Rows[0]["EventsDescription"].ToString();
                        lnkpopupthursday.Attributes.Add("style", "float:left");

                    }
                }
                //--------------------------thursday


                LinkButton lnkpopupfriday = (LinkButton)e.Row.FindControl("lnkpopupfriday") as LinkButton;
                Label lblworkinghoursfriday = (Label)e.Row.FindControl("lblworkinghoursfriday");
                Label lbleventfriday = (Label)e.Row.FindControl("lbleventfriday");
                HiddenField hdnIdfriday = (HiddenField)e.Row.FindControl("hdnIdfriday");


                DataTable dtfriday = new DataTable();
                int popupfriday = lnkpopupfriday.Text == "" ? 0 : Convert.ToInt32(lnkpopupfriday.Text);
                dtfriday = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdfriday.Value), popupfriday, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));


                if (lnkpopupfriday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopupfriday.Text));

                    if (results == true)
                    {
                        lnkpopupfriday.Enabled = false;
                    }
                }

                if (dtfriday.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dtfriday.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {

                        e.Row.Cells[5].CssClass = "leave_back_holy";
                        lblworkinghoursfriday.Visible = true;
                        lbleventfriday.Visible = true;

                        lblworkinghoursfriday.Text = dtfriday.Rows[0]["woringHours"].ToString() == "0" ? "Full day" : dtfriday.Rows[0]["woringHours"].ToString() + " " + "hrs";
                        lbleventfriday.Text = dtfriday.Rows[0]["EventsDescription"].ToString();
                        lnkpopupfriday.Attributes.Add("style", "float:left");

                    }
                }
                //--------------------------friday


                LinkButton lnkpopupseturday = (LinkButton)e.Row.FindControl("lnkpopupseturday") as LinkButton;
                Label lblworkinghoursseturday = (Label)e.Row.FindControl("lblworkinghoursseturday");
                Label lbleventseturday = (Label)e.Row.FindControl("lbleventseturday");
                HiddenField hdnIdseturday = (HiddenField)e.Row.FindControl("hdnIdseturday");


                DataTable dtseturday = new DataTable();
                int popupseturday = lnkpopupseturday.Text == "" ? 0 : Convert.ToInt32(lnkpopupseturday.Text);
                dtseturday = objAdminController.GetHolidayDetails(Convert.ToInt32(hdnIdfriday.Value), popupseturday, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                if (lnkpopupseturday.Text != "")
                {
                    bool results = this.disbaleYesteradaylink(ParseMyFormatDateTime2(lnkpopupseturday.Text));

                    if (results == true)
                    {
                        lnkpopupseturday.Enabled = false;
                    }
                }

                if (dtseturday.Rows.Count > 0)
                {
                    bool IsEvent = Convert.ToBoolean(dtseturday.Rows[0]["IsEvents"].ToString());
                    if (IsEvent == true)
                    {

                        e.Row.Cells[6].CssClass = "leave_back_holy";
                        lblworkinghoursseturday.Visible = true;
                        lbleventseturday.Visible = true;

                        lblworkinghoursseturday.Text = dtseturday.Rows[0]["woringHours"].ToString() == "0" ? "Full day" : dtseturday.Rows[0]["woringHours"].ToString() + " " + "hrs";
                        lbleventseturday.Text = dtseturday.Rows[0]["EventsDescription"].ToString();
                        lnkpopupseturday.Attributes.Add("style", "float:left");
                    }
                }
                //--------------------------seturday

            }

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrd(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));
            DivSetevent.Visible = false;
        }
        public string ParseMyFormatDateTime(string s)
        {
            string dates = string.Empty;
            string monthpart = string.Empty;
            monthpart = Convert.ToInt32(ddlMonth.SelectedValue) < 10 ? "0" + ddlMonth.SelectedValue : ddlMonth.SelectedValue;
            dates = Convert.ToInt32(s) < 10 ? "0" + s : s;            
            string date = monthpart + "/" + dates + "/" + ddlyear.SelectedValue;           
            string[] formats = {"dd/MM/yyyy", "dd-MMM-yyyy", "yyyy-MM-dd", 
                   "dd-MM-yyyy", "M/d/yyyy", "dd MMM yyyy"};
            string converted = DateHelper.ParseDate(date).Value.ToString("dd MMM yy (ddd)");
                //DateTime.ParseExact(DateHelper.ParseDate(date).Value.ToString(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None).ToString("dd MMM yy (ddd)");
            return converted;
        }
        public DateTime ParseMyFormatDateTime2(string s)
        {
            string dates = string.Empty;
            string monthpart = string.Empty;
            monthpart = Convert.ToInt32(ddlMonth.SelectedValue) < 10 ? "0" + ddlMonth.SelectedValue : ddlMonth.SelectedValue;
            dates = Convert.ToInt32(s) < 10 ? "0" + s : s;
            string date = monthpart + "/" + dates + "/" + ddlyear.SelectedValue;
            string[] formats = {"dd/MM/yyyy", "dd-MMM-yyyy", "yyyy-MM-dd", 
                   "dd-MM-yyyy", "M/d/yyyy", "dd MMM yyyy"};
            DateTime converted = DateHelper.ParseDate(date).Value;
            //DateTime.ParseExact(DateHelper.ParseDate(date).Value.ToString(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None).ToString("dd MMM yy (ddd)");
            return converted;
        }
        public bool disbaleYesteradaylink(DateTime dates)
        {
             bool result = false;
            //DateTime now = DateTime.Now;

            var dateAndTime = DateTime.Now;

            var now = dateAndTime.Date;


            var Tocompare = dates.Date;

            if (dates < now)
            {
                result= true;
            }
            return result;
 
        }
        protected void grdproductionCalender_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AdminController objadmin = new AdminController();
            DivSetevent.Visible = true;

            chkenableEvent.Checked = false;
            txtworkinghours.Text = "";
            txtdiscription.Text = "";
          

            
            //if (e.CommandName == "OpenPopUpMonday")
            //{


            //    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
             
            //   // HiddenField myTextBox = row.FindControl("MyTextBoxId") as HiddenField;

            //   // HyperLink hylnkMonday = row.FindControl.FindControl("hylnkMonday") as HiddenField;
            //    LinkButton lnkpopupMonday = row.FindControl("lnkpopupMonday") as LinkButton;
            //    Label lblworkinghoursMonday = row.FindControl("lblworkinghoursMonday") as Label;
            //    Label lbleventMonday = row.FindControl("lbleventMonday") as Label;
            //    HiddenField hdnIdMonday = row.FindControl("hdnIdMonday") as HiddenField;

            //}
            if (e.CommandName == "OpenPopUpMonday")
            {


                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopupMonday = row.FindControl("lnkpopupMonday") as LinkButton;
                Label lblworkinghoursMonday = row.FindControl("lblworkinghoursMonday") as Label;
                Label lbleventMonday = row.FindControl("lbleventMonday") as Label;
                HiddenField hdnIdMonday = row.FindControl("hdnIdMonday") as HiddenField;
                HiddenField hdnIseventMonday = row.FindControl("hdnIseventMonday") as HiddenField;

                DataTable dt = new DataTable();
                int popupMondayDay = lnkpopupMonday.Text == "" ? 0 : Convert.ToInt32(lnkpopupMonday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdnIdMonday.Value), popupMondayDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));

                hdncalederid.Value = hdnIdMonday.Value;
                hdndayno.Value = lnkpopupMonday.Text;
                lbldate.Text = this.ParseMyFormatDateTime(lnkpopupMonday.Text);

                bool ischeck = false;
                if (dt.Rows.Count > 0)
                {
                    lbleventMonday.Text = dt.Rows[0]["EventsDescription"].ToString();
                     ischeck = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }
                if (!string.IsNullOrEmpty(lbleventMonday.Text))
                {
                    

                //if (dt.Rows.Count > 0)
                //{
                    chkenableEvent.Checked = ischeck;
               // }
              

                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventMonday.Text;
                    //txtworkinghours.Text = lblworkinghoursMonday.Text == "Full day" ? "" : lblworkinghoursMonday.Text.Split(' ')[0]; ;

                    //if (lblworkinghoursMonday.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }

                    else
                    {
                        txtworkinghours.Text = lblworkinghoursMonday.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }
                   
                    //hdncalederid.Value = hdnIdMonday.Value;
                    //hdndayno.Value = lnkpopupMonday.Text;                   
                }

                else
                {
                    chkenableEvent.Checked = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                   // btnsubmit.Enabled = false;
                   // btnclose.Enabled = false;


                }
                
            }
            if (e.CommandName == "OpenPopUptuesday")
            {


                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopuptuesday = row.FindControl("lnkpopuptuesday") as LinkButton;
                Label lblworkinghourstuesday = row.FindControl("lblworkinghourstuesday") as Label;
                Label lbleventtuesday = row.FindControl("lbleventtuesday") as Label;
                HiddenField hdnIdtuesday = row.FindControl("hdnIdtuesday") as HiddenField;
               
                hdncalederid.Value = hdnIdtuesday.Value;
                hdndayno.Value = lnkpopuptuesday.Text;
                lbldate.Text = this.ParseMyFormatDateTime(lnkpopuptuesday.Text);

                DataTable dt = new DataTable();
                int popuptusDay = lnkpopuptuesday.Text == "" ? 0 : Convert.ToInt32(lnkpopuptuesday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdnIdtuesday.Value), popuptusDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));
              //  lbleventtuesday.Text = dt.Rows[0]["EventsDescription"].ToString();

                bool ischeck = false;
                if (dt.Rows.Count > 0)
                {
                    lbleventtuesday.Text = dt.Rows[0]["EventsDescription"].ToString();
                    ischeck = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }
                if (!string.IsNullOrEmpty(lbleventtuesday.Text))
                {
                    //chkenableEvent.Enabled = true;

                    

                    //if (dt.Rows.Count > 0)
                    //{
                        chkenableEvent.Checked = ischeck;
                   // }


                    HiddenField hdnIseventtuesday = row.FindControl("hdnIseventtuesday") as HiddenField;
                    //chkenableEvent.Checked = Convert.ToBoolean(hdnIseventtuesday.Value);
                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventtuesday.Text;
                    //txtworkinghours.Text = lblworkinghourstuesday.Text == "Full day" ? "" : lblworkinghourstuesday.Text.Split(' ')[0]; ;

                    //if (lblworkinghourstuesday.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }
                    else
                    {
                        txtworkinghours.Text = lblworkinghourstuesday.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }
                    

                }
                else
                {
                    chkenableEvent.Checked = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                    //btnsubmit.Enabled = false;
                    // btnclose.Enabled = false;


                }

            }
           
            if (e.CommandName == "OpenPopUpwednesday")
            {
               
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopupwednesday = row.FindControl("lnkpopupwednesday") as LinkButton;
                Label lblworkinghourkwednesdays = row.FindControl("lblworkinghourkwednesdays") as Label;
                Label lbleventkwednesday = row.FindControl("lbleventkwednesday") as Label;
                HiddenField hdnIdkwednesday = row.FindControl("hdnIdkwednesday") as HiddenField;
                hdncalederid.Value = hdnIdkwednesday.Value;
                hdndayno.Value = lnkpopupwednesday.Text;
                lbldate.Text = this.ParseMyFormatDateTime(lnkpopupwednesday.Text);

                DataTable dt = new DataTable();
                int popupWedDay = lnkpopupwednesday.Text == "" ? 0 : Convert.ToInt32(lnkpopupwednesday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdncalederid.Value), popupWedDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));
                //lbleventkwednesday.Text = dt.Rows[0]["EventsDescription"].ToString();

                bool ischeck = false;
                if (dt.Rows.Count > 0)
                {
                    lbleventkwednesday.Text = dt.Rows[0]["EventsDescription"].ToString();
                    ischeck = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }

                if (!string.IsNullOrEmpty(lbleventkwednesday.Text))
                {
                //    chkenableEvent.Enabled = true;
                  

                    //if (dt.Rows.Count > 0)
                    //{
                    chkenableEvent.Checked = ischeck;
                    //}

                    HiddenField hdnIseventwednes = row.FindControl("hdnIseventwednes") as HiddenField;
                    //chkenableEvent.Checked = Convert.ToBoolean(hdnIseventwednes.Value);
                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventkwednesday.Text;
                    txtworkinghours.Text = lblworkinghourkwednesdays.Text == "Full day" ? "" : lblworkinghourkwednesdays.Text.Split(' ')[0]; ;


                    //if (lblworkinghourkwednesdays.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }

                    else
                    {
                        txtworkinghours.Text = lblworkinghourkwednesdays.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }                                 

                }
                else
                {
                    chkenableEvent.Checked = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                    //btnsubmit.Enabled = false;
                    // btnclose.Enabled = false;

                }
            }
            if (e.CommandName == "OpenPopUpthursday")
            {
                

                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopupthursday = row.FindControl("lnkpopupthursday") as LinkButton;
                Label lblworkinghoursthursday = row.FindControl("lblworkinghoursthursday") as Label;
                Label lbleventthursday = row.FindControl("lbleventthursday") as Label;
                HiddenField hdnIdthursday = row.FindControl("hdnIdthursday") as HiddenField;
                hdncalederid.Value = hdnIdthursday.Value;
                hdndayno.Value = lnkpopupthursday.Text;
                lbldate.Text = this.ParseMyFormatDateTime(lnkpopupthursday.Text);

                DataTable dt = new DataTable();
                int popupthusDay = lnkpopupthursday.Text == "" ? 0 : Convert.ToInt32(lnkpopupthursday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdncalederid.Value), popupthusDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));
                bool isCheck = false;
                 if (dt.Rows.Count > 0)
                {
                    lbleventthursday.Text = dt.Rows[0]["EventsDescription"].ToString();
                    isCheck=Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }
                
               
                if (!string.IsNullOrEmpty(lbleventthursday.Text))
                {
                //    chkenableEvent.Enabled = true;

                  
                    //if (dt.Rows.Count > 0)
                    //{
                        chkenableEvent.Checked = isCheck;
                    //}

                    HiddenField hdnIseventthursday = row.FindControl("hdnIseventthursday") as HiddenField;
                    //chkenableEvent.Checked = Convert.ToBoolean(hdnIseventthursday.Value);
                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventthursday.Text;
                  //  txtworkinghours.Text = lblworkinghoursthursday.Text == "Full day" ? "" : lblworkinghoursthursday.Text.Split(' ')[0]; ;

                    //if (lblworkinghoursthursday.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }
                    else
                    {
                        txtworkinghours.Text = lblworkinghoursthursday.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }                   

                }
                else
                {
                    chkenableEvent.Checked = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                    //btnsubmit.Enabled = false;
                   // btnclose.Enabled = false;

                }

            }
            if (e.CommandName == "OpenPopUpfriday")
            {

                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopupfriday = row.FindControl("lnkpopupfriday") as LinkButton;
                Label lblworkinghoursfriday = row.FindControl("lblworkinghoursfriday") as Label;
                Label lbleventfriday = row.FindControl("lbleventfriday") as Label;
                HiddenField hdnIdfriday = row.FindControl("hdnIdfriday") as HiddenField;
                hdncalederid.Value = hdnIdfriday.Value;
                hdndayno.Value = lnkpopupfriday.Text;

                lbldate.Text = this.ParseMyFormatDateTime(lnkpopupfriday.Text);

                DataTable dt = new DataTable();
                int popupthusDay = lnkpopupfriday.Text == "" ? 0 : Convert.ToInt32(lnkpopupfriday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdncalederid.Value), popupthusDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));
                //lbleventfriday.Text = dt.Rows[0]["EventsDescription"].ToString();

                bool ischeck = false;
                if (dt.Rows.Count > 0)
                {
                    lbleventfriday.Text = dt.Rows[0]["EventsDescription"].ToString();
                    ischeck = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }

                if (!string.IsNullOrEmpty(lbleventfriday.Text))
                {
                //    chkenableEvent.Enabled = true;
                  
                    //if (dt.Rows.Count > 0)
                    //{
                        chkenableEvent.Checked = ischeck;
                   // }

                    HiddenField hdnIseventfriday = row.FindControl("hdnIseventfriday") as HiddenField;
                   
                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventfriday.Text;
                    //if (lblworkinghoursfriday.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }
                    else
                    {
                        txtworkinghours.Text = lblworkinghoursfriday.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }
                    //txtworkinghours.Text = lblworkinghoursfriday.Text == "Full day" ? "" :
                    
                }
                else
                {
                    chkenableEvent.Checked = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                    //btnsubmit.Enabled = false;
                    //btnclose.Enabled = false;

                }

            }
            if (e.CommandName == "OpenPopUpseturday")
            {


                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                LinkButton lnkpopupseturday = row.FindControl("lnkpopupseturday") as LinkButton;
                Label lblworkinghoursseturday = row.FindControl("lblworkinghoursseturday") as Label;
                Label lbleventseturday = row.FindControl("lbleventseturday") as Label;
                HiddenField hdnIdseturday = row.FindControl("hdnIdseturday") as HiddenField;
                hdncalederid.Value = hdnIdseturday.Value;
                hdndayno.Value = lnkpopupseturday.Text;
                lbldate.Text = this.ParseMyFormatDateTime(lnkpopupseturday.Text);

                DataTable dt = new DataTable();
                int popupthusDay = lnkpopupseturday.Text == "" ? 0 : Convert.ToInt32(lnkpopupseturday.Text);
                dt = objadmin.GetHolidayDetails(Convert.ToInt32(hdncalederid.Value), popupthusDay, GetMonthNumber(), Convert.ToInt32(ddlyear.SelectedValue));
                //lbleventseturday.Text = dt.Rows[0]["EventsDescription"].ToString();

                bool ischeck = false;
                if (dt.Rows.Count > 0)
                {
                    lbleventseturday.Text = dt.Rows[0]["EventsDescription"].ToString();
                    ischeck = Convert.ToBoolean(dt.Rows[0]["IsEvents"].ToString());
                }

                if (!string.IsNullOrEmpty(lbleventseturday.Text))
                {
                //    chkenableEvent.Enabled = true;

                   

                    //if (dt.Rows.Count > 0)
                    //{
                    chkenableEvent.Checked = ischeck;
                    //}


                    HiddenField hdnIseventsat = row.FindControl("hdnIseventsat") as HiddenField;
                    ///chkenableEvent.Checked = Convert.ToBoolean(hdnIseventsat.Value);
                    txtworkinghours.Enabled = true;
                    txtdiscription.Enabled = true;
                    btnsubmit.Enabled = true;
                    btnclose.Enabled = true;

                    txtdiscription.Text = lbleventseturday.Text;
                    //txtworkinghours.Text = lblworkinghoursseturday.Text == "Full day" ? "" : lblworkinghoursseturday.Text.Split(' ')[0]; ;

                    //if (lblworkinghoursseturday.Text == "Full day")
                    //{
                    //    txtworkinghours.Text = "";

                    //}
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["woringhours"].ToString() == "0" || dt.Rows[0]["woringhours"].ToString() == "00")
                        {
                            txtworkinghours.Text = dt.Rows[0]["woringhours"].ToString();

                        }
                    }
                    else
                    {
                        txtworkinghours.Text = lblworkinghoursseturday.Text.Split(' ')[0];
                        txtdiscription.Text = "";
                        txtworkinghours.Text = "";
                    }


                }
                else
                {
                    //chkenableEvent.Enabled = false;
                    txtdiscription.Text = "";
                    txtworkinghours.Text = "";

                    //txtworkinghours.Enabled = false;
                    //txtdiscription.Enabled = false;
                    //btnsubmit.Enabled = false;
                    //btnclose.Enabled = false;

                }

            }
        }
       // public void BindEventDicriptionPopup()
        //protected void chkenableEvent_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkenableEvent.Checked == true)
        //    {

        //        //txtworkinghours.Enabled = true;
        //        //txtdiscription.Enabled = true;
        //        //btnsubmit.Enabled = true;
        //        //btnclose.Enabled = true;
        //        //if (Page.PreviousPage != null)
        //        //{
                    
        //        //    TextBox txtworkinghours1 = (TextBox)Page.PreviousPage.FindControl("txtworkinghours");
        //        //    TextBox txtdiscription1 = (TextBox)Page.PreviousPage.FindControl("txtdiscription");
        //        //    HiddenField  hdncalederid1 = (HiddenField)Page.PreviousPage.FindControl("hdncalederid");
        //        //    HiddenField hdndayno1 = (HiddenField)Page.PreviousPage.FindControl("hdndayno");
        //        //    txtworkinghours.Text = txtworkinghours1.Text;
        //        //    txtdiscription.Text = txtdiscription1.Text;
        //        //    hdncalederid1.Value = hdncalederid1.Value;
        //        //    hdndayno.Value = hdndayno1.Value;
        //        //}
        //    }
        //    else
        //    {
        //        //txtdiscription.Text = "";
        //        //txtworkinghours.Text = "";

        //        //txtworkinghours.Enabled = false;
        //        //txtdiscription.Enabled = false;
        //        //btnsubmit.Enabled = false;
        //       // btnclose.Enabled = false;
        //    }
            

        //}

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string workinghours = "0";
            string eventdiscriptiontext = string.Empty;
            bool Isvent = false;
            int DayNo;
            int CalenderID;
            int MonthNo;
            int year;
            //Regex reg = new Regex(@"^([0-1]?[0-9]):([0-5]?[0-9])?$");
           // Response.Write(reg.IsMatch(txtName.Text));

            // Static method:
            //if (!Regex.IsMatch(txtworkinghours.Text, @"^ *(1[0-9]|[0-2])$"))
            //{
            //    ShowAlert("Enter valid working hours times.!");
            //    return;
            //}

            //if (chkenableEvent.Checked == true)
            //{

            if (!string.IsNullOrEmpty(txtworkinghours.Text))
            {
                int Hours;
                bool isNumeric = int.TryParse(txtworkinghours.Text, out Hours);
                if (isNumeric == false)
                {
                    ShowAlert("Enter valid working hours");
                    return;
                }
                else
                {
                    if (Hours > 12)
                    {
                        ShowAlert("Enter working hours betweens 0 to 12");
                        return;
                    }
                    else
                    {
                        switch (Hours)
                        {

                            case 0:
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                            case 10:
                                break;
                            case 11:
                                break;
                            case 12:
                                break;                           
                            default:
                               ShowAlert("Enter valid time from 1 to 12");
                            return;   
                        }

                    }
                        //if (Hours == 0||Hours == 1 || Hours == 2 || Hours == 3 || Hours == 4 || Hours == 5 || Hours == 6 || Hours == 7 || Hours == 8 || Hours == 9 || Hours == 10 || Hours == 11 || Hours == 12)
                        //{
 
                        //}
                        //else
                        //{
                        //    ShowAlert("Enter valid time from 1 to 12");
                        //    return; 
                        //}                   
                    
                }
            }

                if (txtdiscription.Text == "")
                {
                    ShowAlert("Eneter event discription..");
                    return;
                }
                Isvent = chkenableEvent.Checked == true ? true : false; ;
                CalenderID = Convert.ToInt32(hdncalederid.Value);
                DayNo = Convert.ToInt32(hdndayno.Value);
                MonthNo = Convert.ToInt32(ddlMonth.SelectedValue);
                year = Convert.ToInt32(ddlyear.SelectedValue);

                bool result = txtdiscription.Text.Any(x => !char.IsLetter(x));
                int count = Regex.Matches(txtdiscription.Text, @"[a-zA-Z]").Count;
                if (count ==0 )
                {
                    ShowAlert("Please enter correct discription");
                    return;
                }

                //if (result == true)
                //{
                //    ShowAlert("Please enter correct discription");
                //    return;
                //}
                eventdiscriptiontext = txtdiscription.Text.Trim();
                workinghours = txtworkinghours.Text == "" ? "0" : txtworkinghours.Text;
                //float asd = (float)Convert.ToDouble("41.00027357629127");        
                int Result = objAdminController.UpdateInsertProdPlan_Calender(CalenderID, MonthNo, year, DayNo, Isvent, workinghours, eventdiscriptiontext);
                if (Result > 0)
                {
                    ShowAlert("Event updated successfully");
                    DivSetevent.Visible = false;
                    BindGrd(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));

                }

            //}
            //else
            //{
            //    ShowAlert("please check Enable Event first");
 
            //}
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            DivSetevent.Visible = false;

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        
        protected void txtWorkingDays_Onchanged(object sender, EventArgs e)
        {
            //int Month = Convert.ToInt32(ddlMonth.SelectedValue);
            //int Year = Convert.ToInt32(ddlyear.SelectedValue);
            //double workingHrs = Convert.ToDouble(txtWorkingDays.Text);
            //int Result = objAdminController.UpdateWorkingHrs(Month, Year, workingHrs);
            //if (Result > 0)
            //{
            //    ShowAlert("Event updated successfully");
            //    DivSetevent.Visible = false;
            //    BindGrd(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));

            //}

        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMonth();
            BindGrd(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));
            DivSetevent.Visible = false;
        }

        protected void btnWorkingDays_Click(object sender, EventArgs e)
        {
            double workingHrs=0;
           
            int Month = Convert.ToInt32(ddlMonth.SelectedValue);
            int Year = Convert.ToInt32(ddlyear.SelectedValue);
            if (txtWorkingDays.Text != string.Empty)
            {
                 workingHrs = Convert.ToDouble(txtWorkingDays.Text);
            }
            int Result = objAdminController.UpdateWorkingHrs(Month, Year, workingHrs);
            if (Result > 0)
            {
                ShowAlert("Event updated successfully");
                DivSetevent.Visible = false;
                BindGrd(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlyear.SelectedValue));

            }
        }
    }
    
}