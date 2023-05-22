using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Text;
using System.IO;
using iKandi.BLL;

namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class PeekCapMultipleFileUpload : System.Web.UI.Page
    {
        public string OrderDetailsId { get; set; }
        //public string FileName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
         

            if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailsId"]))
            {
                OrderDetailsId = Request.QueryString["OrderDetailsId"].ToString();
            }
            else OrderDetailsId = "0";
            //if (!string.IsNullOrEmpty(Request.QueryString["FileName"]))
            //{
            //    hdnWholeFile.Value = Request.QueryString["FileName"].ToString();
            //}
            //else hdnWholeFile.Value = "";
            if (!Page.IsPostBack)
                BindFault();
        }

        protected void btnSvaeFile_Click(object sender, EventArgs e)
        {
            OrderController Objcontroller = new OrderController();
            string TotalFilePath = "";
            hdnindex.Value = OrderDetailsId;
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFilePath += hdnFilePath.Value + "$";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
                //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
                

                
            }
            //hdnWholeFile.Value = TotalFilePath;
            int re = Objcontroller.UploadFilePeekCap(Convert.ToInt32(OrderDetailsId), TotalFilePath);
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
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        private void BindFault()
        {
            try
            {
                OrderController objContoller = new OrderController();
                DataTable dtfile = new DataTable();
                dtfile = objContoller.GetPeekCapacityFile(Convert.ToInt32(OrderDetailsId));
                string StrFileName = dtfile.Rows[0]["PeekCapacityFile"].ToString();

               // string filename=
                DataTable dt = CreateTable();
                //hdnWholeFile.Value = "fffff4$tttttttttt$hfghfg";
                if (!string.IsNullOrEmpty(StrFileName))
                {
                    string[] File = StrFileName.Split('$');
                    for (int i = 0; i < File.Length; i++)
                        dt.Rows.Add(File[i]);

                    rptFile.DataSource = dt;
                    rptFile.DataBind();
                }
            }
            catch(Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
            return dt;
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

            //FileInfo TheFile = new FileInfo(MapPath(ConfigurationManager.AppSettings["UploadSiteURL"] + "/Cake/") + dt.Rows[rptItem.ItemIndex]["Pics"].ToString());
            //if (TheFile.Exists)
            //{
            //    File.Delete(MapPath(ConfigurationManager.AppSettings["UploadSiteURL"] + "/Cake/") + dt.Rows[rptItem.ItemIndex]["Pics"].ToString());
            //}
            //if (dt.Rows.Count > 0)
            //{
            rptFile.DataSource = dt;
            rptFile.DataBind();
            //}

        }
    }
}