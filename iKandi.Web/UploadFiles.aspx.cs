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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
  public partial class UploadFiles : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
                 

      }
    }
    String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            //string UploadFileName = "";
            //if (UploadReport.HasFile)
            //{
            //    UploadFileName = UploadReport.FileName;
            //    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + UploadFileName)))
            //    {
            //        System.IO.File.Delete(Constants.PHOTO_FOLDER_PATH + UploadFileName);
            //    }
            //    UploadReport.SaveAs(Server.MapPath(ProductionFolderPath) + UploadFileName);
            //    if(type == 1)
            //        Session["UploadTestReport"] = UploadFileName;
            //    else if(type == 2)
            //        Session["UploadFile"] = UploadFileName;
            //}           
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "submit", "CallParentPage();", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        }

    }
  }
}