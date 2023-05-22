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
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;


namespace iKandi.Web
{
    public partial class FITsMainForm : BaseUserControl
    {
        int Userid = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sStyleCode = "";
            DataTable dt = new DataTable();            
            if (Request.QueryString["StyleCodeVersion"] != null)
            {
                sStyleCode = Request.QueryString["StyleCodeVersion"].ToString();
                dt = this.FITsControllerInstance.GetAllClient(sStyleCode);
                if (dt.Rows.Count > 1)
                {
                    txtStyleNo.Text = sStyleCode;
                    bindclient(sStyleCode);
                }
                else
                {
                    txtStyleNo.Text = sStyleCode;
                    bindclient(sStyleCode);
                    dt = this.FITsControllerInstance.GetAllDepartment(sStyleCode, Convert.ToInt32(ddlClients.SelectedValue));
                    if (dt.Rows.Count > 1)
                    {
                        txtStyleNo.Text = sStyleCode;
                        bindDepartment(sStyleCode, Convert.ToInt32(ddlClients.SelectedValue));
                    }
                    else
                    {
                        string sCode = "";
                        int iStyleId = 0;
                        int iClientId = 0;
                        int iDepartmentId = 0;
                        dt = this.FITsControllerInstance.GetStyleDetails(sStyleCode);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                iStyleId = Convert.ToInt32(dr["Id"]);
                                sCode = dr["StyleCode"].ToString();
                                iClientId = Convert.ToInt32(dr["ClientId"]);
                                iDepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                            }
                        }
                        if (chkFitCycle.Checked == true)
                        {
                            this.FITsControllerInstance.Update_Fits_Track_InPreOrder(iStyleId, Userid);
                        }
                        //Response.Redirect("/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=" + iStyleId + "&stylenumber=" + sStyleCode + "&FitsStyle=&StyleCode=" + sStyleCode + "&ClientID=" + iClientId + "&DeptId=" + iDepartmentId + "&showFITSFORM=Yes");
                        Response.Redirect("/Admin/FitsSample/SamplingFitsCycleFlow.aspx?StyleId=" + iStyleId + "");
                        ///Admin/FitsSample/SamplingFitsCycleFlow.aspx?StyleId=31596
                    }
                }
            }
        }

        public void bindclient(string sStyleCodeVersion)
        {
            DataTable dt = this.FITsControllerInstance.GetAllClient(sStyleCodeVersion);
            ddlClients.DataSource = dt;
            ddlClients.DataTextField = "CompanyName";
            ddlClients.DataValueField = "ClientId";
            ddlClients.DataBind();
            ddlClients.Items.Insert(0, new ListItem("Select", "0"));
            if (dt.Rows.Count == 1)
            {
                ddlClients.SelectedValue = dt.Rows[0]["ClientId"].ToString();
                bindDepartment(sStyleCodeVersion, Convert.ToInt32(ddlClients.SelectedValue));
            }
        }

        public void bindDepartment(string sStyleCodeVersion, int iClientId)
        {
            DataTable dt = this.FITsControllerInstance.GetAllDepartment(sStyleCodeVersion, iClientId);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select", "0"));
            if (dt.Rows.Count == 1)
            {
                ddlDepartment.SelectedValue = dt.Rows[0]["Id"].ToString();
            }
        }

        protected void btnSearch_Click(Object sender, EventArgs e)
        {
            string sStyleCodeVersion = "";
            string sStyleCode = "";
            int iStyleId = 0;
            int iClientId = 0;
            int iDepartmentId = 0;

            sStyleCodeVersion = txtStyleNo.Text;
            iClientId = Convert.ToInt32(ddlClients.SelectedValue);
            iDepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
            if (sStyleCodeVersion == "")
            {
                lblMessage.Text = "Please provide a style number.";
                return;
            }
            else
            {
                DataTable dt = this.FITsControllerInstance.GetStyleDetails(sStyleCodeVersion);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        iStyleId = Convert.ToInt32(dr["Id"]);
                        sStyleCode = dr["StyleCode"].ToString();
                    }
                }
            }

            if (iClientId <= 0)
            {
                lblMessage.Text = "Please select a Client";
                return;
            }
            else if (iDepartmentId <= 0)
            {
                lblMessage.Text = "Please select a Department";
                return;
            }
            else
            {
                if (chkFitCycle.Checked == true)
                {                   
                    this.FITsControllerInstance.Update_Fits_Track_InPreOrder(iStyleId, Userid);
                }
               // Response.Redirect("/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=" + iStyleId + "&stylenumber=" + sStyleCodeVersion + "&FitsStyle=&StyleCode=" + sStyleCodeVersion + "&ClientID=" + iClientId + "&DeptId=" + iDepartmentId + "&showFITSFORM=Yes");
                Response.Redirect("/Admin/FitsSample/SamplingFitsCycleFlow.aspx?StyleId=" + iStyleId + "");
            }
        }

        protected void btnGo_Click(Object sender, EventArgs e)
        {
            string sStyleCodeVersion = "";
            sStyleCodeVersion = txtStyleNo.Text;
            if (sStyleCodeVersion == "")
            {
                lblMessage.Text = "Please provide a style number.";
            }
            else
            {
                if (FITsControllerInstance.bCheckPreOrder(sStyleCodeVersion)==true)
                   chkFitCycle.Visible = true;
                else
                   chkFitCycle.Visible = false;
                lblMessage.Text = "";
                bindclient(sStyleCodeVersion);
            }
        }

        protected void ddlClients_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string sStyleCodeVersion = "";
            int iClientId = 0;
            sStyleCodeVersion = txtStyleNo.Text;
            iClientId = Convert.ToInt32(ddlClients.SelectedValue);
            bindDepartment(sStyleCodeVersion, iClientId);
            lblMessage.Text = "";
        }
    }
}