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

namespace iKandi.Web.UserControls.Reports
{
    public partial class CriticalPathReportAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
               BindgrdCriticalpath(-1);

               binddnClient();
            }
        }
        public void binddnClient()
        {
            try
            {
               // ddnClient.Items.Add(new ListItem("Select", "0"));
                DataTable dtbClient = new DataTable();
                CommonController objCommonController = new CommonController();
                dtbClient = objCommonController.GetClientNamesAndIds();               
                ddnClient.DataSource = dtbClient;       
                ddnClient.DataTextField = "CmpName";               
                ddnClient.DataValueField = "Id";         
                ddnClient.DataBind();
                
                    

                ddnClient.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        public void BindgrdCriticalpath(int intClientId) 
        {
            DataTable dt;
            CommonController objCommonController = new CommonController();
            dt = objCommonController.GetCriticalAdminStatus(intClientId, 1);
            ViewState["TempTable"] = dt;
            //objCommonController.GetCriticalAdminStatus
             grdBind(dt);
        }
        public void grdBind(DataTable dt)
        {
            grdCriticalPath.DataSource = dt;
            grdCriticalPath.DataBind();
        }
        public void chkid_CheckChange(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["TempTable"];
            CheckBox chkStatus = (CheckBox)sender;
            if (chkStatus.Checked == false)
            {
                GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
                int intRowIndex = row.DataItemIndex;
                dt.Rows[intRowIndex]["Ischecked"] = chkStatus.Checked;
                if (Convert.ToString(dt.Rows[intRowIndex]["fieldheading"]) != "")
                {
                    for (int i = intRowIndex + 1; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["fieldheading"].ToString() != "")
                            break;
                        if (dt.Rows[i]["fieldheading"].ToString() == "")
                        {
                            dt.Rows[i]["Ischecked"] = false;
                        }

                    }
                }
                string stringheadid = Convert.ToString(dt.Rows[intRowIndex]["headid"]);
                int s = 0;
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    if (Convert.ToString(dt.Rows[x]["headid"]) == stringheadid)
                        s = s + 1;
                }
                int c = 0;
                for (int y = 0; y <= dt.Rows.Count - 1; y++)
                {
                    if (Convert.ToBoolean(dt.Rows[y]["Ischecked"]) == false && Convert.ToString(dt.Rows[y]["headid"]) == stringheadid)
                        c = c + 1;
                }
                if (c == s - 1)
                {
                    for (int z = 0; z <= dt.Rows.Count - 1; z++)
                    {
                        if(Convert.ToString(dt.Rows[z]["fieldheading"])!="" && Convert.ToString(dt.Rows[z]["headid"])==stringheadid)
                            dt.Rows[z]["Ischecked"] = false;
                    }
                }
                ViewState["TempTable"] = dt;
                grdBind(dt);
            }
            if (chkStatus.Checked == true)
            {
                GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
                int intRowIndex = row.DataItemIndex;
                dt.Rows[intRowIndex]["Ischecked"] = chkStatus.Checked;
                if (dt.Rows[intRowIndex]["fieldheading"].ToString() == "")
                {
                    if (chkStatus.Checked == true)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (Convert.ToString(dt.Rows[row.DataItemIndex]["headid"]) == Convert.ToString(dt.Rows[i]["headid"]) && Convert.ToString(dt.Rows[i]["fieldheading"])!="")
                            {
                                dt.Rows[i]["Ischecked"] = chkStatus.Checked;                                
                                break;
                            }

                        }
                    }
                }
                if (Convert.ToString(dt.Rows[intRowIndex]["fieldheading"]) != "")
                {
                    for (int i = intRowIndex + 1; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["fieldheading"].ToString() != "")
                            break;
                        if (dt.Rows[i]["fieldheading"].ToString() == "")
                        {
                            dt.Rows[i]["Ischecked"] = chkStatus.Checked;                           
                        }

                    }
                }
             
                ViewState["TempTable"] = dt;
                grdBind(dt);
            }    
        }

        protected void grdCriticalPath_RowDataBound(object sender, GridViewRowEventArgs e)
       {        
         }

        protected void btn_go_Click(object sender, EventArgs e)
        {
            
            string st = Convert.ToString(ddnClient.Text);
            if (Convert.ToString(ddnClient.Text) == "Select")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'No Client Selected');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
            else {
                int intid = Convert.ToInt32(ddnClient.SelectedValue);
                BindgrdCriticalpath(intid);
            }
          
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            if (Convert.ToString(ddnClient.Text) == "Select")
            {
                script = "ShowHideMessageBox(true, 'No Client Selected');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                return;
            }

            int intid = Convert.ToInt32(ddnClient.SelectedValue);
            string stringQuery = "<table>";
            DataTable dt = (DataTable)ViewState["TempTable"];
            for (int i = 0; i <= dt.Rows.Count-1; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["Ischecked"]) == true && Convert.ToString(dt.Rows[i]["Id"])!="0")
                {
                    int y=Convert.ToInt32(dt.Rows[i]["Id"]);
                    stringQuery += "<ClientId>" + intid + "</ClientId><Id>" + y + "</Id>";
                }
            }
            stringQuery += "</table>";
            CommonController objCommonController = new CommonController();
            objCommonController.UpdateReportPermissions(stringQuery, intid);

            script = "ShowHideMessageBox(true, 'Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
           
            
        }

        protected void ddnClient_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ddnClient.Items.Remove("Select");
        }                 
    }
}