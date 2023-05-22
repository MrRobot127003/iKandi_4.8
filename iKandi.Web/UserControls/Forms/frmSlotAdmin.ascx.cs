using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Text;
namespace iKandi.Web.UserControls.Forms
{
    public partial class frmSlotAdmin : BaseUserControl
    {
        AdminController objadmin = new AdminController();
        public string UserId
        {
            get;
            set;
        }
         
       

        
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            if (!Page.IsPostBack)
            {

                BindGrd();
                //bindDropDownList();

            }
            //ViewState["counttime_tick"] = 1;
        }
        private void BindGrd()
        {


            DataTable dt = new DataTable();

           
            dt = objadmin.GetslotadminDetails();

            
            grdslot.DataSource = dt;
            grdslot.DataBind();




        }


       
        
        
        protected void grdslot_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Insert")
            {
                DataSet ds = new DataSet();
                Table tblGrdviewApplet = (Table)grdslot.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                TextBox txtslotnameFooter = grdslot.FooterRow.FindControl("txtslotnameFooter") as TextBox;
                //TextBox txtstarttimeFooter = grdslot.FooterRow.FindControl("txtstarttimeFooter") as TextBox;
                //TextBox txtendFooter = grdslot.FooterRow.FindControl("txtendFooter") as TextBox;

                DropDownList ddltypesofslotFooter = grdslot.FooterRow.FindControl("ddltypesofslotFooter") as DropDownList;
                DropDownList ddlstatHH_foter = grdslot.FooterRow.FindControl("ddlstatHH_foter") as DropDownList;
                DropDownList ddlStatMin_foter = grdslot.FooterRow.FindControl("ddlStatMin_foter") as DropDownList;

                DropDownList ddlendHH_foter = grdslot.FooterRow.FindControl("ddlendHH_foter") as DropDownList;
                DropDownList ddlendMin_foter = grdslot.FooterRow.FindControl("ddlendMin_foter") as DropDownList;


                string starthh = string.Empty;
                string statmm = ddlStatMin_foter.SelectedValue;

                string endhh = string.Empty;
                string endmm = ddlendMin_foter.SelectedValue;


                if (txtslotnameFooter.Text == "")
                {

                    txtslotnameFooter.Focus();
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Enter slot name','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                if (ddltypesofslotFooter.SelectedValue == "-1")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Please select type of slot','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
            
               

                if(ddlstatHH_foter.SelectedValue=="-1")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select start hours','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                    
                }
                else
                {
                    starthh=ddlstatHH_foter.SelectedValue;
                }

                if(ddlendHH_foter.SelectedValue=="-1")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select End hours','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                    
                }
                else
                {
                    endhh = ddlendHH_foter.SelectedValue;
                }



               bool isValidattimeUser= Validatetimes(starthh + ":" + statmm, endhh + ":" + endmm);

               if (isValidattimeUser == false)
               {
                   string script = string.Empty;
                   script = "ShowHideMessageBox(true, 'star time and end time could not be greater then 24','Slot admin');";
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                   return;
 
               }
               


                DateTime start_time = new DateTime(2010, 05, 12, Convert.ToInt32(starthh), Convert.ToInt32(statmm), 00);
                DateTime end_time = new DateTime(2010, 05, 12, Convert.ToInt32(endhh), Convert.ToInt32(endmm), 00);
                double timeidff=0;
                timeidff=(end_time.Subtract(start_time).TotalMinutes);

                if (timeidff == 30 || timeidff == 60)
                {
                    if (start_time > end_time)
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Start-time must be smaller then End-time','Slot admin');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }

                }
                else if (timeidff == 0)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Start-time and End time could not  be same','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                    
                }
                else if (timeidff != 30 || timeidff != 60)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Start-time and End time diffrence should be 30 min or 1hr','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
                else
                {
                    if (start_time > end_time)
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Start-time must be smaller then End-time','Slot admin');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }
                    else
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Slot time cannot exceed 1 hr or 30 mintue','Slot admin');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }
                }






                string result = string.Empty;
                int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                if (txtslotnameFooter.Text != "" && ddltypesofslotFooter.SelectedValue != "-1" && ddlstatHH_foter.SelectedValue != "-1" && ddlStatMin_foter.SelectedValue != "-1" && ddlendHH_foter.SelectedValue != "-1")
                {
                    result = objadmin.insertslotdetails(txtslotnameFooter.Text, Convert.ToInt32(ddltypesofslotFooter.SelectedValue), starthh, statmm, endhh, endmm);
                }

                

                if (result.ToUpper() == "STARTTIMEEXITS")
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Selected stat time already exist ','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);
                    BindGrd();
                }
                else if (result.ToUpper() == "ENDTIMEEXITS")
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Selected end time already exist ','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);
                    BindGrd();
                }
                else if (result.ToUpper() == "INSERTED")
                {

                    txtslotnameFooter.Text = "";
                    ddltypesofslotFooter.SelectedValue = "-1";
                    ddlstatHH_foter.SelectedValue = "-1";
                    ddlStatMin_foter.SelectedValue = "00";
                    ddlendHH_foter.SelectedValue = "-1";
                    ddlendMin_foter.SelectedValue = "00";
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Record add successfully','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);

                    BindGrd();
                }
                else if (result.ToUpper() == "SLOTEXIST")
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Slot name already exist','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);
                    
                   // BindGrd();
                }

                else  
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Record not add please check again','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);

                    BindGrd();
                }
               

            }

            if (e.CommandName == "addnew")
            {
                DataSet ds = new DataSet();
                Table tblGrdviewApplet = (Table)grdslot.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                //TextBox txtemptyname = (TextBox)rows.FindControl("txtNameEmpty") as TextBox;

                DropDownList ddltypesofslotEmpty_addnew = (DropDownList)rows.FindControl("ddltypesofslotEmpty_addnew") as DropDownList;

                TextBox txtslotnameempty_addnew = (TextBox)rows.FindControl("txtslotnameempty_addnew") as TextBox;

                //TextBox txtstarttimeempty_addnew = (TextBox)rows.FindControl("txtstarttimeempty_addnew") as TextBox;
                //TextBox txtendtime_addnew = (TextBox)rows.FindControl("txtendtime_addnew") as TextBox;

                DropDownList ddlstatHH_empty = (DropDownList)rows.FindControl("ddlstatHH_empty") as DropDownList;
                DropDownList ddlStatMin_empty = (DropDownList)rows.FindControl("ddlStatMin_empty") as DropDownList;
                DropDownList ddlendtimehh_empty = (DropDownList)rows.FindControl("ddlendtimehh_empty") as DropDownList;
                DropDownList ddlendtimemMm_empty = (DropDownList)rows.FindControl("ddlendtimemMm_empty") as DropDownList;

                string StartHH = string.Empty;
                string StartMM = string.Empty;
                string EndHH = string.Empty;
                string EndMM = string.Empty;

               
                StartMM = ddlStatMin_empty.SelectedValue;
             
                EndMM = ddlendtimemMm_empty.SelectedValue;


                if (txtslotnameempty_addnew.Text == "")
                {

                    txtslotnameempty_addnew.Focus();
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Enter slot name','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                if (ddltypesofslotEmpty_addnew.SelectedValue == "-1")
                {

                    txtslotnameempty_addnew.Focus();
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select Slot type','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                if (ddlstatHH_empty.SelectedValue == "-1")
                {

                    txtslotnameempty_addnew.Focus();
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select Start hours','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                else
                {
                    StartHH = ddlstatHH_empty.SelectedValue;
 
                }

                if (ddlendtimehh_empty.SelectedValue == "-1")
                {

                    txtslotnameempty_addnew.Focus();
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select End hours','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                else
                {
                    EndHH = ddlendtimehh_empty.SelectedValue;
                }
                DateTime start_time = new DateTime(2010, 05, 12, Convert.ToInt32(StartHH), Convert.ToInt32(StartMM), 00);
                DateTime end_time = new DateTime(2010, 05, 12, Convert.ToInt32(EndHH), Convert.ToInt32(EndMM), 00);
                double timeidff = 0;
                timeidff = (end_time.Subtract(start_time).TotalMinutes);

                if (timeidff == 30 || timeidff == 60)
                {
                    if (start_time > end_time)
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Start-time must be smaller then End-time','Slot admin');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }

                }
                else if (timeidff == 0)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Start-time and End time could not  be same','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                else
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Slot time cannot exceed 1 hr or 30 mintue','Slot admin');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
              
             

                //int Output;

                //ValidateUserDate(txtstarttimeempty_addnew.Text, txtendtime_addnew.Text, txtstarttimeempty_addnew, txtendtime_addnew, out Output);

                //if (Output > 0)
                //{
                //    return;
                //}

                int slottype = Convert.ToInt32(ddltypesofslotEmpty_addnew.SelectedValue);
                
                String reuslt = objadmin.insertslotdetails(txtslotnameempty_addnew.Text, slottype, StartHH, StartMM, EndHH, EndMM);

                BindGrd();
            }



           

        }
        protected void grdslot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                DropDownList ddltypesofslot = (DropDownList)e.Row.FindControl("ddltypesofslot") as DropDownList;

                HiddenField hdnDesignationItem = (HiddenField)e.Row.FindControl("hdnDesignationItem") as HiddenField;

                ddltypesofslot.SelectedValue = hdnDesignationItem.Value;
                
                HiddenField hdnstarthousrs = (HiddenField)e.Row.FindControl("hdnstarthousrs") as HiddenField;
                HiddenField hdnstartMin = (HiddenField)e.Row.FindControl("hdnstartMin") as HiddenField;

                HiddenField hdnendhh = (HiddenField)e.Row.FindControl("hdnendhh") as HiddenField;
                HiddenField hdnendmin = (HiddenField)e.Row.FindControl("hdnendmin") as HiddenField;

                DropDownList ddlstatHH = (DropDownList)e.Row.FindControl("ddlstatHH") as DropDownList;
                DropDownList ddlStatMin = (DropDownList)e.Row.FindControl("ddlStatMin") as DropDownList;

                DropDownList dllendtimehh = (DropDownList)e.Row.FindControl("dllendtimehh") as DropDownList;
                DropDownList ddlendmin = (DropDownList)e.Row.FindControl("ddlendmin") as DropDownList;

                if (!string.IsNullOrEmpty(hdnstarthousrs.Value))
                {
                    ddlstatHH.SelectedValue = hdnstarthousrs.Value;
                }
                if (!string.IsNullOrEmpty(hdnstartMin.Value))
                {
                    ddlStatMin.SelectedValue = hdnstartMin.Value;
                }
                if (!string.IsNullOrEmpty(hdnendhh.Value))
                {
                    dllendtimehh.SelectedValue = hdnendhh.Value;
                }
                if (!string.IsNullOrEmpty(hdnendmin.Value))
                {
                    ddlendmin.SelectedValue = hdnendmin.Value;
                }


            }


        }
        public void Alert(Page page, string message)
        {
            string jsString = "ShowHideMessageBox('" + message + "');";
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "MyApplication",
                    jsString,
                    true);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            BindGrd();
        }
        public bool Validatetimes(string start, string endtime)
        {
            bool retval = true;
            
            string[] stat = start.Split(':');
            string[] end = endtime.Split(':');

            int stathh = Convert.ToInt32(stat[0]);
            int statmm = Convert.ToInt32(stat[1]);


            int endhh = Convert.ToInt32(end[0]);
            int endmm = Convert.ToInt32(end[1]);

            if (stathh == 24 || endhh == 24)
            {
                if (statmm != 00 || endmm != 00)
                {
                    retval = false;
                }
            }
            else
            {
                retval = true;
            }

            return retval;
           
        }

        //added for exmple Background process--------------------------------------------------------------------------------------------31//6/2015
        
        //protected void Timer1_Tick(object sender, EventArgs e)
        //{

        //    getTimmer();
        //}
        //public static int counttime
        //{
        //    get;
        //    set;
        //}
        //public void getTimmer()
        //{
        //    counttime = counttime + 1;

        //    ViewState["counttime_tick"] = (int)ViewState["counttime_tick"] + counttime;

        //    timelbl.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();




        //    //TextWriter tw = File.CreateText(@"D:\output.txt");
        //    StringBuilder sb = new StringBuilder();

        //    Random random = new Random();
        //    int count = random.Next(10000);

        //    sb.AppendLine(ViewState["counttime_tick"].ToString() + ": " + "time is updated by abhishek on " + DateTime.Now.ToLongTimeString());
        //    sb.AppendLine(Environment.NewLine);
        //    sb.Append("________________________________________________________________");
        //    //tw.WriteLine(sb.ToString());






        //    try
        //    {


        //        StreamWriter sw = new StreamWriter(@"D:\output.txt", true);
        //        sw.WriteLine(sb.ToString());

        //        sw.Close();
        //    }
        //    catch (Exception p)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}
        //end ----------------------------------------------------------------------------------31/6/2015
    }
}