using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using System.IO;
using System.Web.Services;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Admin.Categories
{
    public partial class InternalCatMultipleFileUpload : System.Web.UI.Page
    {
        public static string Id
        {
            get;
            set;
        }
        public static string UnitId
        {
            get;
            set;
        }

        AdminController adminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null && Request.QueryString["Id"].ToString() != "")
            {
                Id = Request.QueryString["Id"].ToString();
             
            }
            else Id = "0";
            if (Request.QueryString["UnitId"] != null && Request.QueryString["UnitId"].ToString() != "")
            {
                
                UnitId = Request.QueryString["UnitId"].ToString();
            }
            else UnitId = "0";
            if (!Page.IsPostBack)
                BindFault();
        }

        private void BindFault()
        {
            try
            {
                DataTable dtfile = new DataTable();
                dtfile = adminController.GetFileDetailsByInternalMonthlyAudId(Convert.ToInt32(Id),Convert.ToInt32(UnitId));
                if (dtfile.Rows.Count > 0)
                {
                    string StrFileName = dtfile.Rows[0]["ImagePath"].ToString();
                    DataTable dt = CreateTable();

                    if (!string.IsNullOrEmpty(StrFileName))
                    {
                        string[] File = StrFileName.Split('$');
                        for (int i = 0; i < File.Length; i++)
                            dt.Rows.Add(File[i]);

                        rptFile.DataSource = dt;
                        rptFile.DataBind();
                    }
                }


            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ImagePath", typeof(string)));
            return dt;
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnSvaeFile_Click(object sender, EventArgs e)
        {
            string TotalFilePath = "";
            hdnindex.Value = Id;
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFilePath += hdnFilePath.Value + "$";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            }

            int re = adminController.UploadFileInternalAudit(Convert.ToInt32(Id), TotalFilePath,Convert.ToInt32(UnitId));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var filename = "";
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rptFile.Items)
                {
                    HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePath.Value;
                    dt.Rows.Add(dr);
                }
                if (Fldresolution.HasFile)
                {
                    filename = iKandi.Web.Components.FileHelper.SaveFile(Fldresolution.PostedFile.InputStream, Fldresolution.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rptFile.DataSource = dt;
                rptFile.DataBind();
            }
            catch { }
        }

        protected void imgRow_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem1.FindControl("hdnFilePath");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();
            rptFile.DataSource = dt;
            rptFile.DataBind();
        }
    }
}