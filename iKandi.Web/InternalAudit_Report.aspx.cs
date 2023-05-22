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
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using Pechkin;
using System.Text.RegularExpressions;
using System.Net;

namespace iKandi.Web
{
    public partial class InternalAudit_Report : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        IList<AuditCategory> auditCategories = new List<AuditCategory>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UnitId;
                DataSet ds = objadmin.GetAllUnit();
                ddlUnit.DataSource = ds;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "Id";
                ddlUnit.DataBind();

                DataSet ds1 = objadmin.GetAllMonthYear();

                ddlMonth.DataSource = ds1.Tables[0];
                ddlMonth.DataTextField = "MnthName";
                ddlMonth.DataValueField = "monthNumber";
                ddlMonth.DataBind();

                ddlYear.DataSource = ds1.Tables[1];
                ddlYear.DataTextField = "YearName";
                ddlYear.DataValueField = "YearName";
                ddlYear.DataBind();

                    ddlMonth.SelectedValue = DateTime.Now.AddMonths(-1).Month.ToString();
                    ddlYear.SelectedValue = DateTime.Now.AddMonths(-1).Year.ToString();

                if (Request.QueryString["UnitId"] == null || Request.QueryString["UnitId"] == "")
                {
                    ddlUnit.SelectedValue = "11";
                }
                else
                {
                    UnitId = Request.QueryString["UnitId"];
                    ddlUnit.SelectedValue = UnitId;
                    spanDDL.Visible = false;
                }
                BindGrid();

            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void BindGrid()
        {
            lblUnitName.Text = ddlUnit.SelectedItem.Text;
            auditCategories = objadmin.GetAllAuditCategories(0);
            rpt.DataSource = auditCategories;
            rpt.DataBind();
        }
        protected void rpt_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            DataTable dt = new DataTable();
            HiddenField hdnCategoryId = (HiddenField)e.Item.FindControl("hdnCategoryId");

            GridView gv = (GridView)e.Item.FindControl("grv");
            dt = objadmin.GetAllMonthlyAudit(Convert.ToInt32(hdnCategoryId.Value), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));
            HtmlGenericControl auditCategories = (HtmlGenericControl)e.Item.FindControl("auditCatgName");
            if (dt.Rows.Count == 0)
            {
                auditCategories.Visible = false;
            }
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
            }


        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrevMonthStatus = (Label)e.Row.FindControl("lblPrevMonthStatus");
                Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
                Label capDuration = (Label)e.Row.FindControl("capDuration");
                Label lblCAP = (Label)e.Row.FindControl("lblCAP");
                Label lblObservation = (Label)e.Row.FindControl("lblObservation");
                RadioButton rbtFail = (RadioButton)e.Row.FindControl("rbtFail");
                RadioButton rbtPass = (RadioButton)e.Row.FindControl("rbtPass");
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");
                HiddenField hdnQusId = (HiddenField)e.Row.FindControl("hdnQusId");
                Repeater rptFileLink = (Repeater)e.Row.FindControl("rptFileLink");
                HtmlGenericControl CapHide = e.Row.FindControl("CapHide") as HtmlGenericControl;
                HtmlGenericControl ObservaHide = e.Row.FindControl("ObservaHide") as HtmlGenericControl;

                if (lblCAP.Text != "")
                {
                    CapHide.InnerText = "CAP";
                }
                if (lblObservation.Text != "")
                {
                    ObservaHide.InnerText = "Observation";
                }
                lblDepartment.Text = "(" + lblDepartment.Text + ")";

                if (lblPrevMonthStatus.Text != "")
                    lblPrevMonthStatus.Text = lblPrevMonthStatus.Text == "True" ? "Pass" : "Fail";
                else
                    lblPrevMonthStatus.Text = "";

                if (rbtFail.Text == "False")
                {
                    rbtFail.Text = "Fail";
                    rbtFail.Checked = true;
                }
                if (rbtPass.Text == "True")
                {
                    rbtPass.Text = "Pass";
                    rbtPass.Checked = true;
                }
                rbtFail.Text = "Fail";
                rbtPass.Text = "Pass";
                rbtFail.Enabled = false;
                rbtPass.Enabled = false;

                if (capDuration.Text != "")
                    capDuration.Text = Convert.ToDateTime(capDuration.Text).ToString("dd MMM yy");
                if (lblPrevMonthStatus.Text == "Pass")
                    lblPrevMonthStatus.ForeColor = System.Drawing.Color.Green;
                else if (lblPrevMonthStatus.Text == "Fail")
                    lblPrevMonthStatus.ForeColor = System.Drawing.Color.Red;

                // Link File
                DataTable dtfile = new DataTable();
                if (hdnId.Value != string.Empty)
                    dtfile = objadmin.GetFileDetailsByInternalMonthlyAudId_New(Convert.ToInt32(hdnQusId.Value), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue)); //modified 31-05-2021
                    //dtfile = objadmin.GetFileDetailsByInternalMonthlyAudId(Convert.ToInt32(hdnQusId.Value), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue)); //modified 31-05-2021
                string StrFileName = string.Empty;
                if (dtfile.Rows.Count != 0)
                    StrFileName = dtfile.Rows[0]["ImagePath"].ToString();

                DataTable dt = CreateTable();

                if (!string.IsNullOrEmpty(StrFileName))
                {
                    string[] File = StrFileName.Split('$');
                    for (int i = 0; i < File.Length; i++)
                        dt.Rows.Add(File[i]);

                    rptFileLink.DataSource = dt;
                    rptFileLink.DataBind();
                }
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ImagePath", typeof(string)));
            return dt;
        }
    }
}