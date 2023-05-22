using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;


namespace iKandi.Web.UserControls.Lists
{
    public partial class TargetAdminQA : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();
                AdminController controller = new AdminController();
                DataSet ds = new DataSet();
                ds = controller.GetTargetDateQA();
                ViewState["ddlData"] = ds.Tables[1];
                gv_trgadmin.DataSource = ds;
                gv_trgadmin.DataBind();
                GetGridItem();
                GetGridItem();
            }

        }

        private void BindDroDownInGrid(DropDownList ddl)
        {
            ddl.DataSource = (DataTable)ViewState["ddlData"];
            ddl.DataTextField = "name";
            ddl.DataValueField = "id";
            ddl.DataBind(); 
        }
        protected void gv_trgadmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {        
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(gv_trgadmin.Rows.Count==0)
                {
                    TextBox txtsimu = e.Row.FindControl("lblSimDate") as TextBox;
                    txtsimu.Text = DateTime.Now.Date.ToString("dd MMM yy (ddd)");
                }   
                HiddenField hdnStatusId = (HiddenField)e.Row.FindControl("hdnStatusId");
                HiddenField hdnval = (HiddenField)e.Row.FindControl("hdnval");
                DropDownList ddlfrom = e.Row.FindControl("ddlfrom") as DropDownList;
                DropDownList ddlmode = e.Row.FindControl("ddlmode") as DropDownList;
                TextBox txtday = e.Row.FindControl("txtdays") as TextBox;
                if (hdnStatusId.Value== "1")
                    ddlfrom.Visible = false;
                BindDroDownInGrid(ddlfrom);               
                if (Convert.ToInt16(hdnStatusId.Value) < 7)
                {
                    ddlfrom.Items.RemoveAt(30);
                    ddlfrom.Items.RemoveAt(29); ddlfrom.Items.RemoveAt(28); ddlfrom.Items.RemoveAt(27);
                }

                HiddenField hdnCalMode = e.Row.FindControl("hdnCalMode") as HiddenField;
                ddlmode.SelectedValue = hdnCalMode.Value;
                ddlfrom.SelectedValue = hdnval.Value;
           
            }

        }

        protected void save_Click(object sender, EventArgs e)
        {
           // iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();
            AdminController controller = new AdminController();
            AdminTargetdate admintrgdate = new AdminTargetdate();

            foreach (GridViewRow row in gv_trgadmin.Rows)
            {

                DropDownList ddlfrom = row.FindControl("ddlfrom") as DropDownList;
                DropDownList ddlmode = row.FindControl("ddlmode") as DropDownList;
                HiddenField hdnStatusId = row.FindControl("hdnStatusId") as HiddenField;
                TextBox txtDays = row.FindControl("txtdays") as TextBox;
                admintrgdate.fromdate = Convert.ToInt32(ddlfrom.SelectedValue);
                HiddenField hdnId = (HiddenField)row.FindControl("hdnId");
                admintrgdate.id = Convert.ToInt32(hdnId.Value);
                admintrgdate.calendermode = Convert.ToInt32(ddlmode.SelectedValue);
                if (txtDays.Text == "")
                {
                    txtDays.Text = "0";
                }
                admintrgdate.Days = Convert.ToInt32(txtDays.Text);

                controller.Updatetargetdatesforadmin(admintrgdate);

            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "ShowHideMessageBox(true, 'Saved Successfully.');", true);

        }

        protected void submitData(int type)
        {
           //  iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();
            AdminController controller = new AdminController();
            controller.UpdatetargetdatesforAll(type);//incase of all this will update the history
            
        }

        protected void update_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "ShowHideBar(1);", true);
            try
            {
                submitData(0);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "ShowHideMessageBox(true, 'Active Orders Update Successfully.');", true);
               
            }
            catch (Exception ex)
            {
                //NotificationController controller = new NotificationController();
                //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            finally
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "ShowHideBar(0);", true);
            }
        }
        protected void updateAll_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "ShowHideBar(0);", true);
            try
            {
                submitData(1);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "ShowHideMessageBox(true, 'Orders Update Successfully.');", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //NotificationController controller = new NotificationController();
                //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "$.hideprogress();", true);
            }
        }

        protected void ddlfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGridItem();
        }

        protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
        {   
            #region CommentedCode
            //DateTime CompareDate = new DateTime();
            //DropDownList ddl = (DropDownList)sender;
            //TextBox txtSimulation=(TextBox)ddl.Parent.FindControl("lbldays"); //Simulation
            //TextBox txtday = (TextBox)ddl.Parent.FindControl("txtdays");
            //DropDownList ddlmode1 = (DropDownList)ddl.Parent.FindControl("ddlmode");
            //DropDownList ddlfrom1 = (DropDownList)ddl.Parent.FindControl("ddlfrom");
            //DateTime NewDatetime=new DateTime();
            //int DayCount = 0;
            //DateTime MinDate = new DateTime();
            //DateTime MaxDate = new DateTime();

            //CompareDate = (DateTime)DateHelper.ParseDate(txtSimulation.Text);

            
            //if (Convert.ToInt32(ddlfrom1.SelectedValue) > 999)
            //{
            //    switch (Convert.ToInt32(ddlfrom1.SelectedValue))
            //    {
            //        case 1000: NewDatetime = DateTime.Now; break; //Order Date
            //        case 1001: NewDatetime = DateTime.Now.AddDays(107); break; // Dc Date
            //        case 1002: NewDatetime = DateTime.Now.AddDays(90); break; // Dc Date
            //        case 1003: NewDatetime = DateTime.Now.AddDays(50); break; //STC Unallocated
            //    }
            //}
            //else
            //{
            //    foreach (GridViewRow Gvr in gv_trgadmin.Rows)
            //    {
            //        Label StatusName = (Label)Gvr.FindControl("lblStatus");
            //        TextBox txtDate = (TextBox)Gvr.FindControl("lbldays");                    
            //        if (StatusName.Text.Trim() == ddlfrom1.SelectedItem.Text)
            //        {                        
            //            if (txtDate.Text != "")
            //                NewDatetime = (DateTime)DateHelper.ParseDate(txtDate.Text);
            //            else
            //                NewDatetime = DateTime.MinValue;

            //            break;
            //        }

            //    }
            //}
            //CompareDate = NewDatetime.AddDays(Convert.ToInt16(txtday.Text));
            //if (CompareDate > NewDatetime)
            //{
            //    MinDate = NewDatetime;
            //    MaxDate = CompareDate;
            //}
            //else if (CompareDate < NewDatetime)
            //{
            //    MinDate = CompareDate;
            //    MaxDate = NewDatetime;
            //}
            //while (MaxDate >= MinDate)
            //{
            //    if (Convert.ToInt16(ddlmode1.SelectedValue) == 3)
            //    {
            //        if (MinDate.DayOfWeek.ToString().Contains("Saturday") || MinDate.DayOfWeek.ToString().Contains("Sunday"))
            //        {
            //            DayCount++;
            //        }
            //    }
            //    else if (Convert.ToInt16(ddlmode1.SelectedValue) == 2)
            //    {
            //        if (MinDate.DayOfWeek.ToString().Contains("Sunday"))
            //        {
            //            DayCount++;
            //        }
            //    }
            //    MinDate = MinDate.AddDays(1);
            //}
            //if (CompareDate != MinDate)
            //{
            //    CompareDate = CompareDate.AddDays(DayCount);
            //    txtSimulation.Text = CompareDate.ToString("dd MMM yy (ddd)");
            //}
            //else txtSimulation.Text = "";
#endregion
            GetGridItem();
           
        }

        private void GetGridItem()
        {
            foreach (GridViewRow Gvr in gv_trgadmin.Rows)
            {
                TextBox txtTargetDate = (TextBox)Gvr.FindControl("lblSimDate");
                DropDownList ddlmode = (DropDownList)Gvr.FindControl("ddlmode");
                if (Gvr.RowIndex == 0)
                {
                   txtTargetDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                   ddlmode.SelectedValue="1";
                }
                else
                {
                    CalculateDate(Gvr);
                }
            }
        }
        private void CalculateDate(GridViewRow SelectedGvr)
        {
            DateTime CompareDate = new DateTime();
            TextBox txtSimulation = (TextBox)SelectedGvr.FindControl("lblSimDate"); //Simulation
            TextBox txtday = (TextBox)SelectedGvr.FindControl("txtdays");
            DropDownList ddlmode1 = (DropDownList)SelectedGvr.FindControl("ddlmode");
            DropDownList ddlfrom1 = (DropDownList)SelectedGvr.FindControl("ddlfrom");
            HiddenField hdnStatusId = (HiddenField)SelectedGvr.FindControl("hdnStatusId");
            DateTime NewDatetime = new DateTime();
            int DayCount = 0;
            DateTime MinDate = new DateTime();
            DateTime MaxDate = new DateTime();

            CompareDate = (DateTime)DateHelper.ParseDate(txtSimulation.Text);


            if (Convert.ToInt32(ddlfrom1.SelectedValue) > 999)
            {
                switch (Convert.ToInt32(ddlfrom1.SelectedValue))
                {
                    case 1000: NewDatetime = DateTime.Now; break; //Order Date
                    case 1001: NewDatetime = DateTime.Now.AddDays(107); break; // Dc Date
                    case 1002: NewDatetime = DateTime.Now.AddDays(90); break; // Dc Date
                    case 1003: NewDatetime = DateTime.Now.AddDays(60); break; //STC Unallocated
                }
            }
            else
            {
                foreach (GridViewRow Gvr in gv_trgadmin.Rows)
                {
                    Label StatusName = (Label)Gvr.FindControl("lblStatus");
                    TextBox txtDate = (TextBox)Gvr.FindControl("lblSimDate");
                    HiddenField hdnCurrentStatusId = (HiddenField)Gvr.FindControl("hdnStatusId");
                    if (hdnCurrentStatusId.Value == ddlfrom1.SelectedItem.Value)
                    {
                        if (txtDate.Text != "")
                            NewDatetime = (DateTime)DateHelper.ParseDate(txtDate.Text);
                        else
                            NewDatetime = DateTime.MinValue;

                        break;
                    }

                }
            }
            if (NewDatetime != DateTime.MinValue)
                CompareDate = NewDatetime.AddDays(Convert.ToInt16(txtday.Text));
            else
                CompareDate = NewDatetime;

            if (CompareDate > NewDatetime)
            {
                MinDate = NewDatetime;
                MaxDate = CompareDate;
            }
            else if (CompareDate < NewDatetime)
            {
                MinDate = CompareDate;
                MaxDate = NewDatetime;
            }
            if (CompareDate != NewDatetime)
            {
                while (MaxDate >= MinDate)
                {
                    if (Convert.ToInt16(ddlmode1.SelectedValue) == 3)
                    {
                        if (MinDate.DayOfWeek.ToString().Contains("Saturday") || MinDate.DayOfWeek.ToString().Contains("Sunday"))
                        {
                            DayCount++;
                        }
                    }
                    else if (Convert.ToInt16(ddlmode1.SelectedValue) == 2)
                    {
                        if (MinDate.DayOfWeek.ToString().Contains("Sunday"))
                        {
                            DayCount++;
                        }
                    }
                    else if (Convert.ToInt16(ddlmode1.SelectedValue) <= 1)
                    {
                        ddlmode1.SelectedValue = "1";
                    }
                    MinDate = MinDate.AddDays(1);
                }
            }

            if (CompareDate != MinDate)
            {
                CompareDate = CompareDate.AddDays(DayCount);
                txtSimulation.Text = CompareDate.ToString("dd MMM yy (ddd)");
            }
            else txtSimulation.Text = "";
        }

        protected void txtdays_TextChanged(object sender, EventArgs e)
        {
             GetGridItem();
        }
       
    }
}
