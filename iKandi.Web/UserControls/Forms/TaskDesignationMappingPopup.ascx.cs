using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Forms
{
    public partial class TaskDesignationMappingPopup : BaseUserControl
    {
        public string TaskName
        {
            get;
            set;
        }
        public int MainTaskId
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.TaskName = Request.QueryString["task"].ToString();
            this.MainTaskId = Convert.ToInt32(Request.QueryString["taskid"]);
            if (!IsPostBack)
            {
                BindControl();
            }
        }

        private void BindControl()
        {
            DataTable dt=new DataTable();
            this.TaskName = Request.QueryString["task"].ToString();
            this.MainTaskId = Convert.ToInt32(Request.QueryString["taskid"]);
            lblShow.Text = this.TaskName;
            dt=this.AdminControllerInstance.GetDesignation(this.MainTaskId, 0);
            chkList.DataSource = dt;
            chkList.DataValueField = "DesignationId";
            chkList.DataTextField = "Designation";
            chkList.DataBind();

            dt.DefaultView.RowFilter = "IsSelected='Y'";
            DataView dv = dt.DefaultView;
            for (int i = 0; i <= dv.Count-1; i++)
            {
                for (int j = 0; j <= chkList.Items.Count - 1; j++)
                {
                    if (chkList.Items[j].Value.ToString() == dv[i]["DesignationId"].ToString())
                    {
                        chkList.Items[j].Selected = true;
                        break;
                    }
                }
            }
        }

        protected void chkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IndexId = 0;
            IndexId = Convert.ToInt32(Convert.ToString(this.Request["__EVENTTARGET"]).Replace("TaskDesignationMappingPopup1$chkList$", ""));
            if (chkList.Items[IndexId].Selected == true)
            {
                DataTable dt=new DataTable();
                dt = this.AdminControllerInstance.GetDesignation(this.MainTaskId, Convert.ToInt32(chkList.Items[IndexId].Value));
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= chkList.Items.Count - 1; j++)
                    {
                        if (dt.Rows[i][0].ToString() == chkList.Items[j].Value.ToString())
                        {
                            chkList.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool IsCheckedItemFound = false;
            for (int j = 0; j <= chkList.Items.Count - 1; j++)
            {
                if (chkList.Items[j].Selected == true)
                {
                    IsCheckedItemFound = true;
                    break;
                }
            }
            if (IsCheckedItemFound == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('No Designation Selected');", true);
                return;
            }

            this.AdminControllerInstance.DeleteTaskDesignationMapping(this.MainTaskId);

            for (int j = 0; j <= chkList.Items.Count - 1; j++)
            {
                if (chkList.Items[j].Selected == true)
                {
                    this.AdminControllerInstance.SaveTaskDesignationMapping(this.MainTaskId, Convert.ToInt32(chkList.Items[j].Value), "");
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Saved Successfully');window.opener.history.go(0);window.close();", true);
            
        }
        
    }
}