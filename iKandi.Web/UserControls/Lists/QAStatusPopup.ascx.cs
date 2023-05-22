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
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class QAStatusPopup : BaseUserControl
    {
       
        public int OrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orderdetailid"]))
                {
                    return Convert.ToInt32(Request.QueryString["orderdetailid"]);
                }

                return -1;
            }
            //get;
            //set;
        }
        public int StyleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["styleID"]))
                {
                    return Convert.ToInt32(Request.QueryString["styleID"]);
                }

                return 0;
            }
            //get;
            //set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.QA_STATUS_MO))
            {
                btnSubmit.CssClass = "submit";
            }
            else btnSubmit.CssClass = "hide_me";
            if (!IsPostBack)
            {
                hdnPageStatus.Value = "0";
                grdQAStatus.DataSource = this.QualityControllerInstance.GetQAStatus(OrderDetailID, StyleID);
                grdQAStatus.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool flag1 = true;
            Session["Flag"] = flag1;
            string statusString = string.Empty;
            foreach (GridViewRow row in grdQAStatus.Rows)
            {
                if (((TextBox)row.FindControl("txtActual")).Text != "" && ((TextBox)row.FindControl("txtActual")).ReadOnly==false)
                {
                    if (statusString == string.Empty)
                    {
                        statusString = "<root><table>";
                    }
                    statusString += "<StatusID>" + ((HiddenField)row.FindControl("hdnStatusID")).Value + "</StatusID>";

                    string strTD = ((Label)row.FindControl("lblTarget")).Text.Trim();
                    string[] strTargetDate = strTD.Split('(');
                    statusString += "<TargetDate>" + strTargetDate[0] + "</TargetDate>";
                    //statusString += "<TargetDate>" + ((Label)row.FindControl("lblTarget")).Text + "</TargetDate>";

                    string strAD = ((TextBox)row.FindControl("txtActual")).Text.Trim();
                    string[] strActualDate = strAD.Split('('); 
                    //statusString += "<ActualDate>" + ((TextBox)row.FindControl("txtActual")).Text.Trim() + "</ActualDate>";
                    statusString += "<ActualDate>" + strActualDate[0] + "</ActualDate>";
                }
            }
            if (statusString != string.Empty)
            {
                string script = string.Empty;
                statusString += "</table></root>";
               
                string str = this.QualityControllerInstance.SaveQAStatusDetails(statusString, OrderDetailID, StyleID, ApplicationHelper.LoggedInUser.UserData.UserID);             
                Session["Parameter"] = null;
                if (str == "1")
                {
                    script = "alert('Data Saved Successfully');";                   
                    hdnPageStatus.Value = "1";
                    bool flag = true;
                    Session["Flag"] = flag;
                }
                else
                {
                    script = "alert('An error occurred while saving the Data');";
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

            }
            else
            {
                string script = string.Empty;
                hdnPageStatus.Value = "1";
                if (Session["Parameter"] != null)
                {
                    Session["Parameter"] = null;
                    script = "alert('Data Saved Successfully');";
                    bool flag = true;
                    Session["Flag"] = flag;
                    //script = "alert('All dates have already been saved sucessfully!!');window.close();if (window.opener && !window.opener.closed) {window.opener.location.reload();} ";
                }
                else script = "alert('No data to save!!');";
                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
               
                

            }
        }

        protected void grdQAStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].HorizontalAlign= HorizontalAlign.Left;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtActual = (TextBox)e.Row.FindControl("txtActual");
                Image imgStatus = (Image)e.Row.FindControl("imgStatus");
                //
                HiddenField hdnActualDate = (HiddenField)e.Row.FindControl("hdnActualDate");

                DateTime date =Convert.ToDateTime(hdnActualDate.Value);
                string strdate = date.ToString("dd/MM/yyyy");

                if (hdnActualDate != null)
                {
                    if (strdate == "01/01/1900")
                    {
                        txtActual.Text = "";
                        txtActual.CssClass = "date-picker bold_text date_style";
                    }
                }


                if (txtActual.Text == "")
                {
                    txtActual.CssClass = "date-picker bold_text date_style";
                }
                if (e.Row.RowIndex != 0)
                {
                    TextBox txtActualPrev = (TextBox)grdQAStatus.Rows[(e.Row.RowIndex - 1)].FindControl("txtActual");
                    Image imgStatusPrev = (Image)grdQAStatus.Rows[(e.Row.RowIndex - 1)].FindControl("imgStatus");
                    if (txtActualPrev.Text == "")
                    {
                        txtActual.ReadOnly = true;
                        imgStatus.Visible = false;
                        txtActual.CssClass = "";
                    }
                    else
                    {
                        txtActualPrev.ReadOnly = true;
                        imgStatusPrev.Visible = false;
                        txtActualPrev.CssClass = "";
                    }
                }
            }
            else return;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Parameter"] = null;
            hdnPageStatus.Value = "1";
            bool flag = true;
            Session["Flag"] = flag;
            //string script = "window.close();if (window.opener && !window.opener.closed) {window.opener.location.reload();} ";
           // string script = "window.close();";
           // ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);  
        }

        protected void Button1_Disposed(object sender, EventArgs e)
        {
            
        }

    }
}