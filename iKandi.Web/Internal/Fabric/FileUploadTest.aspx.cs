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


namespace iKandi.Web.Internal.Fabric
{
    public partial class FileUploadTest : System.Web.UI.Page
    {
        public string index { get; set; }

        public static int OrderId { get; set;}
        public static int OrderDetailID
        {
            get;
            set;
        }
        public string TestReportss
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public String FabricName
        {
            get;
            set;
        }
        public String UploadFileName
        {
            get;
            set;
        }
        public static String IsShipped
        {
            get;
            set;
        }
        public int Type
        {
            get;
            set;
        }
        public int SrvID
        {
            get;
            set;
        }
        public int UserId
        {

            get;
            set;
        }

        string TechnicalfilePath = "";
        string Flag = "";
        OrderController objOrderController = new OrderController();
        FabricController objFabricController = new FabricController();
        DataTable dtFiles = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            dtFiles.Columns.Add("InternalLabReports");
                
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            if (Request.QueryString["Flag"] != null)
            {
                Flag = Request.QueryString["Flag"].ToString();


            }

            if (Request.QueryString["Type"] != null)
            {
                Type = Convert.ToInt16(Request.QueryString["Type"].ToString());

            }
            if (Request.QueryString["SrvNO"] != null)
            {
                SrvID = Convert.ToInt16(Request.QueryString["SrvNO"].ToString());


            }
            if (Request.UrlReferrer != null)
            {
                string previousPageName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (previousPageName == "FabricInspectionFourPointCheck.aspx")
                {
                    Flag = "1";
                }

            }
            if (Request.UrlReferrer != null)
            {
                string previousPageName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (previousPageName == "AccessAccessoriesFourPointCheckInspection.aspx")
                {

                      Flag ="2" ;

                  


                }


            }



            if (!IsPostBack)
            {
                DataSet DS = new DataSet();
                if (Flag == "1")
                {
                    DS = objFabricController.FourPointCheckLabFile(Type, SrvID, "", 'S');
                    DataTable dtLabcheck = DS.Tables[1];
                    if (dtLabcheck.Rows.Count > 0)
                    {

                        bool LabManagerCheck = Convert.ToBoolean( dtLabcheck.Rows[0]["LabManagerCheck"]);
                        if (LabManagerCheck)
                        {

                            //btnSvaeFile.Enabled = false;
                            //btnUpload1.Enabled = false;

                        }
                        else
                        {

                            btnSvaeFile.Enabled = true;
                            btnUpload1.Enabled = true;
                        }
                    }
                    
                }
                if (Flag == "2")
                {
                    DS = objFabricController.FourPointCheckLabFileForAccessory(Type, SrvID, "", 'S');
                }
                dtFiles = DS.Tables[0];
                if (dtFiles != null)
                {
              
                    
                        hdnWholeFile.Value = dtFiles.Rows[0]["InternalLabReports"].ToString();
                    
                   
                }
                BindDefault();
            }
        }
        protected void btnUpload1_Click(object sender, EventArgs e)
        {


            var filename = "";
            try
            {
             //   DataTable dt = new DataTable();
                dtFiles.Clear();
                //dt.Columns.Add("FileName");

                foreach (RepeaterItem rptItem in rptFile1.Items)
                {
                    HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                    DataRow dr = dtFiles.NewRow();
                    if (hdnFilePath != null)
                    {
                        dr["InternalLabReports"] = hdnFilePath.Value;
                        dtFiles.Rows.Add(dr);
                    }
                }
                if (FileUploadSave.HasFile)
                {
                    filename = iKandi.Web.Components.FileHelper.SaveFile(FileUploadSave.PostedFile.InputStream, FileUploadSave.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

                    DataRow dr1 = dtFiles.NewRow();
                    dr1["InternalLabReports"] = filename;
                    dtFiles.Rows.Add(dr1);
                }
                rptFile1.DataSource = dtFiles;
                rptFile1.DataBind();
            }
            catch { }

            //===============================================sec
            string TotalFilePath = "";
            hdnindex.Value = index;
            foreach (RepeaterItem rptItem in rptFile1.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFilePath += hdnFilePath.Value + "$";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            }
            hdnWholeFile.Value = TotalFilePath;
            if (hdnFlagIE.Value == "IE")
            {
                //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPageIE();", true);
                Session["FileDoc"] = hdnWholeFile.Value;
                //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "CallBackParentPageIE();", true);
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            }
            else
            {
                //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
                // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            }
        }
        private void BindDefault()
        {
            try
            {
                dtFiles.Clear();
                //hdnWholeFile.Value = "fffff4$tttttttttt$hfghfg";
                if (!string.IsNullOrEmpty(hdnWholeFile.Value))
                {
                    string[] File = hdnWholeFile.Value.Split('$');
                    for (int i = 0; i < File.Length; i++)
                        dtFiles.Rows.Add(File[i]);

                    rptFile1.DataSource = dtFiles;
                    rptFile1.DataBind();
                }
                else
                {
                    rptFile1.DataSource = null;
                    rptFile1.DataBind();
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        protected void btnSvaeFile_Click(object sender, EventArgs e)
        {
            string TotalFileName = "";
            int count=1;
            foreach (RepeaterItem rptItem in rptFile1.Items)
            {
                
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFileName+=  hdnFilePath.Value + "$";
                if (rptFile1.Items.Count==count)
                {
                     TotalFileName= TotalFileName.Substring(0, TotalFileName.Length - 1);

                }
                hdnWholeFile.Value = TotalFileName;
               
                SaveFourPointCheckLabFile(Type, SrvID, hdnWholeFile.Value,'U');
                count+=1;

            }
            var InternalLabReportFileName = "";
            Page.RegisterStartupScript("as", "<script language='javascript'>self.parent.Shadowbox.close();</script>");
            if (FileUploadSave.HasFile)
            {
                string Exten = System.IO.Path.GetExtension(FileUploadSave.FileName);
                string ActualfileName = "Internal_Lab_Report_" + FileUploadSave.FileName;
                string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                InternalLabReportFileName = FileHelper.SaveFile(FileUploadSave.PostedFile.InputStream, FileUploadSave.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
                // fabricInspectSystem.InternalLabReport = InternalLabReportFileName;

            }
        }

        protected void imgRow_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
        
            dtFiles.Clear();
            foreach (RepeaterItem rptItem2 in rptFile1.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem2.FindControl("hdnFilePath");
                DataRow dr = dtFiles.NewRow();
                dr["InternalLabReports"] = hdnFilePath.Value;
                dtFiles.Rows.Add(dr);
            }
            dtFiles.Rows[rptItem.ItemIndex].Delete();

            //FileInfo TheFile = new FileInfo(MapPath(ConfigurationManager.AppSettings["UploadSiteURL"] + "/Cake/") + dt.Rows[rptItem.ItemIndex]["Pics"].ToString());
            //if (TheFile.Exists)
            //{
            //    File.Delete(MapPath(ConfigurationManager.AppSettings["UploadSiteURL"] + "/Cake/") + dt.Rows[rptItem.ItemIndex]["Pics"].ToString());
            //}
            //if (dt.Rows.Count > 0)
            //{
            rptFile1.DataSource = dtFiles;
            rptFile1.DataBind();
            //}

        }
        public void SaveFourPointCheckLabFile(int type, int SrvID, string FileName,char Action)
        {
            if (Flag == "1")
            {
                 objFabricController.FourPointCheckLabFile(type, SrvID, FileName, Action);
            }
            else if (Flag == "2")
            {
                objFabricController.FourPointCheckLabFileForAccessory(type, SrvID, FileName, Action);
            }
        }
    }

}


