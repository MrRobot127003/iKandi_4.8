using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;


namespace iKandi.Web.Internal.Fabric
{

    public partial class AccessoryFileUpload : System.Web.UI.Page
    {
        public int AccMasterID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccMasterID"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccMasterID"]);
                }
                return -1;
            }
        }
        public int AccessoryQualityId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryQualityId"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryQualityId"]);
                }
                return -1;
            }
        }
        public int SupplierId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SupplierId"]))
                {
                    return Convert.ToInt32(Request.QueryString["SupplierId"]);
                }
                return -1;
            }
        }
        String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            if (AccessoryQualityId > 0)
            {
                DataTable dt = objAdminController.GetAccessFileUpload(AccMasterID, AccessoryQualityId);
                if (dt.Rows.Count > 0)
                {
                    string strTestReport = dt.Rows[0]["UploadBaseTestFile"].ToString();
                    if (strTestReport != "")
                    {
                        hlnkTestReport.NavigateUrl = ProductionFolderPath + strTestReport;
                        hlnkTestReport.Attributes.Add("style", "display:inline-block;"); 
                    }
                    string strUploadReport = dt.Rows[0]["UploadFile"].ToString();
                    if (strUploadReport != "")
                    {
                        hlnkUploadFile.NavigateUrl = ProductionFolderPath + strUploadReport;
                        hlnkUploadFile.Attributes.Add("style", "display:inline-block;");
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string TestReportFileName = "";
                string UploadFileName = "";
                string FileExtention = "";
                if (UploadTestReport.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(UploadTestReport.FileName);
                    TestReportFileName = "AccessQuality_TestReportFile_MasterID_" + AccMasterID.ToString() + "_SupplierID_" + SupplierId.ToString() + FileExtention;
                    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + TestReportFileName)))
                    {
                        System.IO.File.Delete(Constants.PHOTO_FOLDER_PATH + TestReportFileName);
                    }
                    UploadTestReport.SaveAs(Server.MapPath(ProductionFolderPath) + TestReportFileName);                   
                }
                if (UploadFile.HasFile)
                {                    
                    //UploadFileName = "AccessQuality_" + AccMasterID.ToString() + "_" + UploadFile.FileName.Trim();
                    FileExtention = System.IO.Path.GetExtension(UploadFile.FileName);
                    UploadFileName = "AccessQuality_UploadFile_MasterID_" + AccMasterID.ToString() + "_SupplierID_" + SupplierId.ToString() + FileExtention;

                    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + UploadFileName)))
                    {
                        System.IO.File.Delete(Constants.PHOTO_FOLDER_PATH + UploadFileName);
                    }
                    UploadFile.SaveAs(Server.MapPath(ProductionFolderPath) + UploadFileName);
                }
                if (AccessoryQualityId > 0)
                {
                    int iUpdate = objAdminController.UpdateAccSizeFile(AccessoryQualityId, TestReportFileName, UploadFileName);
                }
                else
                {
                    if (TestReportFileName != "")
                    {
                        Session["TestReportFileName"] = TestReportFileName;
                    }
                    if (UploadFileName != "")
                    {
                        Session["UploadFileName"] = UploadFileName;
                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "submit", "CallParentPage();", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }
    }
}