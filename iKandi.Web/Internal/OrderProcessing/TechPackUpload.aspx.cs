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

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class TechPackUpload : System.Web.UI.Page
    {
        public string index { get; set; }

        public static int OrderId
        {
            get;
            set;
        }



        public int Styleid
        {
            get
            {
                if (Request.QueryString["Styleid"] == null || Request.QueryString["Styleid"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["Styleid"]);
            }
        }

        public String UploadFileName
        {
            get;
            set;
        }
        string TechnicalfilePath = "";

        OrderController objOrderController = new OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            //BindQueryString();

            TechnicalfilePath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
            if (hdnStylenotestReportPath.Value != "")
            {
                hdnWholeFile.Value = hdnStylenotestReportPath.Value;
            }

            if (!IsPostBack)
            {
               

            }
            if (!string.IsNullOrEmpty(Request.QueryString["index"]))
            {
                index = Request.QueryString["index"].ToString();
            }
            else index = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["FileName"]) && Request.QueryString["FileName"].ToString() != "undefined")
            {
                hdnWholeFile.Value = Request.QueryString["FileName"].ToString();
            }
       
           
           
            if (!Page.IsPostBack)
                BindFault();
      
        }
     
        private void BindQueryString()
        {
            try
            {
                if (Request.QueryString["OrderId"] != null)
                {
                    OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
                }
               
              
               
                if (Request.QueryString["UploadFileName"] != null)
                {
                    UploadFileName = Request.QueryString["UploadFileName"].ToString();
                    hdnFldresolutionTestreport.Value = UploadFileName;
                }


                //img.Visible = true;
                //img.ImageUrl = TechnicalfilePath + TestReportss;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            string TotalFilePath = "";
            hdnindex.Value = index;
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFilePath += hdnFilePath.Value + "$";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            }
            hdnWholeFile.Value = TotalFilePath;
            
            Session["FileDoc"] = hdnWholeFile.Value;
         
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
          
            if (Session["FileDoc"] != null)
            {
                UploadFileName = Session["FileDoc"].ToString();
                hdnFldresolutionTestreport.Value = UploadFileName;
            }

            if (SaveDate())
            {
                ShowAlert("File uploaded successfully!");
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "setTimeout(function(){ window.parent.Shadowbox.close();}, 100);", true);
            }
            else
            {
                ShowAlert("Select at least one file");
            }

         

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
      
       
        protected void a_Click(object sender, EventArgs e)
        {
            BindFault();
        }

        protected void btnUpload1_Click(object sender, EventArgs e)
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
                 //Add By Prabhaker on 22-Aug-2018//
                    string time = DateTime.Now.ToString("dd MMM yyy hh-mm-ss");
                    string Fullfilename = Path.GetFileName(Fldresolution.FileName);
                    string[] ext = Fullfilename.Split('.');
                    filename = ext[0] +"_"+ time + "." + ext[1];
                    var path = Path.Combine(Constants.STYLE_FOLDER_PATH, filename);
                    Fldresolution.SaveAs(path);
                //End of Code


                    //filename = iKandi.Web.Components.FileHelper.SaveFile(Fldresolution.PostedFile.InputStream, Fldresolution.FileName, Constants.STYLE_FOLDER_PATH, false, string.Empty);
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rptFile.DataSource = dt;
                rptFile.DataBind();
            }
            catch { }

            //===============================================sec
            string TotalFilePath = "";
            hdnindex.Value = index;
            foreach (RepeaterItem rptItem in rptFile.Items)
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
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            }
        }
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
            return dt;
        }
        private void BindFault()
        {
            try
            {
                DataTable dt = CreateTable_ForTechPacs(Styleid);
                if (dt.Rows.Count > 0)
                {
                    //HtmlGenericControl hideDIv = (HtmlGenericControl)rptFile.FindControl("hideImg");
                    //foreach (RepeaterItem rptItem in rptFile.Items)
                    //{
                    //    HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                    //    if (hdnFilePath.Value == "")

                    //        hideDIv.Visible = false;
                    //}    
                    //foreach (DataRow row in CreateTable_ForTechPacs(CostingID).Rows)
                    //{
                    //    object value = row["FilePath"];
                    //    if (value == DBNull.Value)
                    //    {
                    //        hideDIv.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        hideDIv.Visible = true;
                    //    }
                    //}
                    rptFile.DataSource = dt;
                    rptFile.DataBind();
                    
                }
                else
                {
                    rptFile.DataSource = null;
                    rptFile.DataBind();
                }
            }
            catch
            {

            }
        }

        private DataTable CreateTable_ForTechPacs(int Styleid)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objOrderController.Get_TechPacs(Styleid);
            return ds.Tables[0];
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
      //Add By Prabhaker on 22-Aug-2018//
        protected void outerFunction(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HiddenField hdnFilePath = e.Item.FindControl("hdnFilePath") as HiddenField;
               HyperLink imgfile=e.Item.FindControl("imgfile") as HyperLink;
               string pdffile = hdnFilePath.Value;
               string[] checkpdf = pdffile.Split('.');
               if (checkpdf[1] == "pdf")
               {
                   imgfile.ImageUrl = "../../images/pdf.png";
                   imgfile.CssClass = "pdf";
               }
            }
        }

    //End Of Code
        public bool SaveDate()//abhishek 28/12/2016
        {
          int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
          
            bool IsSave = true;
            if (hdnFldresolutionTestreport.Value == "")
            {
                IsSave = false;
            }
             //bool result;

             DataTable dt = CreateTable();
           
             if (!string.IsNullOrEmpty(hdnFldresolutionTestreport.Value))
             {
                 objOrderController.deletetechPacsFile(Styleid);
                 string[] File = hdnFldresolutionTestreport.Value.Split('$');
                 if (File.Length > 1)
                 {
                   objOrderController.UpdateTechFile("", Styleid, 0, UserId, "DELETE");
                 }
                 for (int i = 0; i < File.Length; i++)
                 {
                     dt.Rows.Add(File[i]);
                     objOrderController.UpdateTechFile(File[i], Styleid, i, UserId,"UPDATE");
                 }

                 rptFile.DataSource = dt;
                 rptFile.DataBind();
             }
             else
             {
                 rptFile.DataSource = null;
                 rptFile.DataBind();
             }

             //result = objOrderController.UpdateTechFile(hdnFldresolutionTestreport.Value, CostingID);
             //    IsSave = result;       
            
             return IsSave;
            }

           
      
    }
}