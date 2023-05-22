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
using System.Globalization;
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;

using iKandi.BLL.Security;

namespace iKandi.Web.Admin
{
    public partial class FrmUpdateClientDepAssociation : System.Web.UI.Page
    {
       
        AdminController oAdminController = new AdminController();
        //MembershipControllerInstance ob = new MembershipControllerInstance();
        MembershipController objmem = new MembershipController();
        public int CompanyID
        {
            get;
            set;
        }
        public int UserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    return Convert.ToInt32(Request.QueryString["userid"]);
                }

                return -1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInactiveUser();
                //if (ChkDeactivate.Checked)
                //{
                //    grduser.Enabled = false;
                //    grduser.ToolTip = "Please uncheck checkbox for continuou deactivate user";
                //    grduser.Enabled = false;
                //    btnSubmit.Enabled = false;
                //}
                //else
                //{
                //    grduser.Enabled = true;
                //    grduser.ToolTip = "";
                //    grduser.Enabled = true;
                //    btnSubmit.Enabled = true;

                //}
                if (UserID != -1)
                {
                    User user = objmem.GetUser(UserID);
                    if (user.IsActive == 1)
                        ChkDeactivate.Checked = true;
                    else
                        ChkDeactivate.Checked = false;
                }
               
            }

           
        }
        protected void grduser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnClientID = (HiddenField)e.Row.FindControl("hdnClientID");
                DataSet ds = oAdminController.GetInactiveuser(Convert.ToInt32(hdnClientID.Value),this.UserID, 2);
                DataTable dt = ds.Tables[0];
                ListBox listDept = (ListBox)e.Row.FindControl("listDept");
                ListBox listuser = (ListBox)e.Row.FindControl("listuser");

                User user = objmem.GetUser(UserID);

                listDept.DataSource = dt;
                listDept.DataTextField = "DepartmentName";
                listDept.DataValueField = "DepartmentID";
                listDept.DataBind();
                if (user.IsActive == 1)
                {
                    ChkDeactivate.Checked = true;
                }
                else
                    ChkDeactivate.Checked = false;

                listDept.Enabled = false;

                DataSet dsdes = oAdminController.GetInactiveuser(Convert.ToInt32(hdnClientID.Value),this.UserID, 3);
                DataTable dtdes = dsdes.Tables[0];
                ListBox listdesignation = (ListBox)e.Row.FindControl("listdesignation");

                listdesignation.DataSource = dtdes;
                listdesignation.DataTextField = "Name";
                listdesignation.DataValueField = "DesignationID";
                listdesignation.DataBind();

                listdesignation.SelectedValue = user.DesignationID.ToString();

                string selectedItem = "";
                //if (Convert.ToInt32(listdesignation.SelectedValue) > 0)
                //{
                if (listdesignation.Items.Count > 0)
                {
                    for (int i = 0; i < listdesignation.Items.Count; i++)
                    {
                        if (listdesignation.Items[i].Selected)
                        {
                            selectedItem = selectedItem + listdesignation.Items[i].Value + ",";

                        }
                    }
                }

                DataSet dsuser = oAdminController.GetInactiveuser(Convert.ToInt32(hdnClientID.Value),this.UserID, 4, selectedItem);
                DataTable dtuser = dsuser.Tables[0];

                listuser.DataSource = dtuser;
                listuser.DataTextField = "UserName";
                listuser.DataValueField = "UserID";
                listuser.DataBind();
                //}


            }
        }

        protected void ChkDeactivate_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkDeactivate.Checked)
            //   // divuser.Visible = false;
            //    grduser.Attributes.Add("style", "display:none;");                             
            //else
            //    grduser.Attributes.Add("style", "display:display:block;");

        }

        protected void listdesignation_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListBox ddl = (ListBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            int rowIndex = row.RowIndex;
            ListBox listuser = (ListBox)row.FindControl("listuser");
            ListBox listdesignation = (ListBox)row.FindControl("listdesignation");
            int val = Convert.ToInt32(listdesignation.SelectedValue);
            string selectedItem = "";
            if (Convert.ToInt32(listdesignation.SelectedValue) > 0)
            {
                if (listdesignation.Items.Count > 0)
                {
                    for (int i = 0; i < listdesignation.Items.Count; i++)
                    {
                        if (listdesignation.Items[i].Selected)
                        {
                            selectedItem = selectedItem + listdesignation.Items[i].Value + ",";
                            //insert command
                        }
                    }
                }

                DataSet dsuser = oAdminController.GetInactiveuser(0, this.UserID, 4, selectedItem);
                DataTable dtuser = dsuser.Tables[0];

                listuser.DataSource = dtuser;
                listuser.DataTextField = "UserName";
                listuser.DataValueField = "UserID";
                listuser.DataBind();
            }

        }

        public DataTable UpdateClientUserAssociation()
        {
            int ClientID;
            String strdeptsID = "";
            string strdesID = "";
            string UserID = "";

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ClientID");
            dt.Columns.Add("DeptID");
            dt.Columns.Add("DesignationID");
            dt.Columns.Add("USerID");
            dt.Columns.Add("ClientName");

            foreach (GridViewRow row in grduser.Rows)
            {
                DataRow drrow = dt.NewRow();

                HiddenField hdnClientID = (HiddenField)row.FindControl("hdnClientID");
                ListBox listDept = (ListBox)row.FindControl("listDept");
                ListBox listdesignation = (ListBox)row.FindControl("listdesignation");
                ListBox listuser = (ListBox)row.FindControl("listuser");
                Label lblclientname = (Label)row.FindControl("lblClient");
                ClientID = Convert.ToInt32(hdnClientID.Value);

                if (listDept.Items.Count > 0)
                {
                    for (int i = 0; i < listDept.Items.Count; i++)
                    {
                        strdeptsID = strdeptsID + listDept.Items[i].Value + ",";
                    }
                }
                if (listdesignation.Items.Count > 0)
                {
                    for (int i = 0; i < listdesignation.Items.Count; i++)
                    {
                        if (listdesignation.Items[i].Selected)
                        {
                            strdesID = strdesID + listdesignation.Items[i].Value + ",";
                        }
                    }
                }
                if (listuser.Items.Count > 0)
                {
                    for (int i = 0; i < listuser.Items.Count; i++)
                    {
                        if (listuser.Items[i].Selected)
                        {
                            UserID = UserID + listuser.Items[i].Value + ",";
                        }
                    }
                }
                drrow["ClientID"] = ClientID;
                drrow["DeptID"] = strdeptsID;
                drrow["DesignationID"] = strdesID;
                drrow["USerID"] = UserID;
                drrow["ClientName"] = lblclientname.Text;
                dt.Rows.Add(drrow);
                strdeptsID = "";
                strdesID = "";
                UserID = "";

            }
            return dt;
        }
        //public void bindInactiveUser()
        //{

        //    DataSet ds = oAdminController.GetInactiveuser(this.UserID, 1);
        //    DataTable dt = ds.Tables[0];
        //    grduser.DataSource = dt;
        //    grduser.DataBind();

        //}
        public void saveClientDep()
        {
            int ClientID;
            String strdeptsID = "";
            string strdesID = "";
            string UserID = "";
            foreach (GridViewRow row in grduser.Rows)
            {
               

                HiddenField hdnClientID = (HiddenField)row.FindControl("hdnClientID");
                ListBox listDept = (ListBox)row.FindControl("listDept");
                ListBox listdesignation = (ListBox)row.FindControl("listdesignation");
                ListBox listuser = (ListBox)row.FindControl("listuser");
                Label lblclientname = (Label)row.FindControl("lblClient");
                ClientID = Convert.ToInt32(hdnClientID.Value);

                if (listDept.Items.Count > 0)
                {
                    for (int i = 0; i < listDept.Items.Count; i++)
                    {
                        strdeptsID = strdeptsID + listDept.Items[i].Value;
                        if (listdesignation.Items.Count > 0)
                        {
                            for (int x = 0; i < listdesignation.Items.Count; x++)
                            {
                                if (listdesignation.Items[x].Selected)
                                {
                                    strdesID = strdesID + listdesignation.Items[x].Value;

                                    for (int y = 0; y < listuser.Items.Count; y++)
                                    {
                                        if (listuser.Items[y].Selected)
                                        {
                                            UserID = UserID + listuser.Items[y].Value;


                                        }
                                    }

                                }
                            }
                        }

                    }
                }
                //if (listdesignation.Items.Count > 0)
                //{
                //    for (int i = 0; i < listdesignation.Items.Count; i++)
                //    {
                //        if (listdesignation.Items[i].Selected)
                //        {
                //            strdesID = strdesID + listdesignation.Items[i].Value + ",";
                //        }
                //    }
                //}
                if (listuser.Items.Count > 0)
                {
                    for (int i = 0; i < listuser.Items.Count; i++)
                    {
                        if (listuser.Items[i].Selected)
                        {
                            UserID = UserID + listuser.Items[i].Value + ",";
                        }
                    }
                }
               
            }
        }
        public bool VaildateUser(DataTable dt)
        {
            bool IsValid = true;
            DataTable dtvalidate = dt;
            foreach (DataRow row in dtvalidate.Rows)
            {
                if (row["USerID"].ToString() == "")
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + "Please select at least one user for client " + row["ClientName"].ToString() + "');", true);
                    IsValid = false;                   
                }                           
            }
            return IsValid;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            DataTable dtvalidate = UpdateClientUserAssociation();
            if (dtvalidate.Rows.Count == 0)
            {
                int checks = ChkDeactivate.Checked == true ? 1 : 0;
                int res = oAdminController.ActiveInactiveUser(this.UserID, checks, "");
                {                 
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
                }
            }
            else
            {
                bool resu = VaildateUser(dtvalidate);
                if (resu)
                {
                    if (ChkDeactivate.Checked==false)
                        SaveRecord(dtvalidate);
                    else
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + "please first uncheck is active checkbox " + "');", true);
                    }
                }
                    
                else
                    return;
            }

        }
       
        public void bindInactiveUser()
        {
            DataSet ds = this.oAdminController.GetInactiveuser(0,this.UserID, 1);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                grduser.DataSource = dt;
                grduser.DataBind();
            }
            
        }
       

        public void SaveRecord(DataTable dt)
        {
            int IsActive = 0;
            if (ChkDeactivate.Checked)           
                IsActive = 1;
            else
                IsActive = 0;          
            foreach (DataRow row in dt.Rows)
            {               
                string[] Deptstring = row["DeptID"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string[] Desigstring = row["DesignationID"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string[] Userstring = row["USerID"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Deptstring.Length; i++)               
                {
                    int ClientDepartmentID = Convert.ToInt32(Deptstring[i]);
                    for (int x = 0; x < Desigstring.Length; x++)
                    {
                        int DesignationID = Convert.ToInt32(Desigstring[x]);

                        for (int y = 0; y < Userstring.Length; y++)
                        {
                            int UserIDNew = Convert.ToInt32(Userstring[y]);

                            //delete first with old user id 

                            int IsDelete = oAdminController.UpsateClientDeptAssociation(ClientDepartmentID, DesignationID, this.UserID, "DELETE", IsActive);
                            int IsSave = oAdminController.UpsateClientDeptAssociation(ClientDepartmentID, DesignationID, UserIDNew, "UPDATE", IsActive);
                        }
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
            }
            
 
        }

        protected void ChkDeactivate_CheckedChanged1(object sender, EventArgs e)
        {
            if (ChkDeactivate.Checked)
            {
                grduser.Enabled = false;
                grduser.ToolTip = "Please uncheck checkbox for continuou deactivate user";
                grduser.Enabled = false;
               // btnSubmit.Enabled = false;
            }
            else
            {
                grduser.Enabled = true;
                grduser.ToolTip = "";
                grduser.Enabled = true;
                //btnSubmit.Enabled = true;
 
            }

        }

    }
}