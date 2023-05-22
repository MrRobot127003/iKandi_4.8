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
  public partial class MoTestReportUpload : System.Web.UI.Page
  {
      public string index { get; set; }

      public static int OrderId
    {
      get;
      set;
    }
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
    string TechnicalfilePath = "";
    OrderController objOrderController = new OrderController();
    protected void Page_Load(object sender, EventArgs e)
    {
       
      BindQueryString();

      TechnicalfilePath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];

      if (!IsPostBack)
      {
          DataSet ds = new DataSet();


          ds = objOrderController.GetOrderContactDetailsByOrderID(OrderId, OrderDetailID);
          DataTable dtGetTestReportMo = ds.Tables[0];
        if (dtGetTestReportMo.Rows.Count > 0)
        {
          IsShipped = dtGetTestReportMo.Rows[0]["IsShiped"].ToString();
         
                   
        BindContractgrd();
        hdnWholeFile.Value = dtGetTestReportMo.Rows[0]["StyleTestReportsFinal"].ToString();
        BindFault();       
        }
      
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
      //else hdnWholeFile.Value = "";
      if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
      {
          hdnFlagIE.Value = Request.QueryString["Flag"].ToString();
      }
      else
          hdnFlagIE.Value = "";
      if (!string.IsNullOrEmpty(Request.QueryString["Flag2"]))
      {
          hdnFlagTestReport.Value = Request.QueryString["Flag2"].ToString();
      }
      else
          hdnFlagTestReport.Value = "";
      //if (!Page.IsPostBack)
      //{ BindFault(); }
      
    }
    public void BindContractgrd()
    {
       // user = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
       // if (OrderDetailID.ToString() != "" && StyleId.ToString() != "" && FabricName.ToString() != "")
        if(OrderId>0)
        {
          ds = objOrderController.GetOrderContactDetailsByOrderID(OrderId, OrderDetailID);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                //if (dt.Rows[0]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[0]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[1]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[1]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[2]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[2]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[3]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[3]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[4]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[4]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[4]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[4]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[5]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[5]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[6]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[6]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[7]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[7]["StyleTestReports"].ToString();
                //}
                //else if (dt.Rows[8]["StyleTestReports"].ToString() != "")
                //{
                //    hdnWholeFile.Value = dt.Rows[8]["StyleTestReports"].ToString();
                //}
                
                GrdCutAvg.DataSource = dt;
                GrdCutAvg.DataBind();
                Checkbox();
            }
            else
            {
                GrdCutAvg.DataSource = null;
                GrdCutAvg.DataBind();
            }

        }
        
    }
    private void BindQueryString()
    {
      try
      {
        if (Request.QueryString["OrderId"] != null)
        {
          OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
        }
        if (Request.QueryString["OrderDetailsId"] != null)
        {
          OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailsId"].ToString());
        }
        if (Request.QueryString["TestReports"] != null)
        {
          TestReportss = (Request.QueryString["TestReports"].ToString());
        }
        if (Request.QueryString["Fabricname"] != null)
        {
            FabricName = Request.QueryString["Fabricname"].ToString();
        }
        if (Request.QueryString["styleid"] != null)
        {
            StyleId = Convert.ToInt32(Request.QueryString["styleid"].ToString());
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
     

         //DataTable dtGetTestReportMo = objOrderController.GetTestReportMo(OrderDetailID);
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
        //if (hdnFlagIE.Value == "IE")
        //{
            //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPageIE();", true);
            Session["FileDoc"] = hdnWholeFile.Value;
            //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "CallBackParentPageIE();", true);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        //}
        //else
        //{
        //    //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
        //    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        //}

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
    public bool SaveDate()//abhishek 28/12/2016
    {
        bool IsSave = true;
        if (hdnFldresolutionTestreport.Value == "")
        {
            IsSave = false;
        }
        else
        {

            foreach (GridViewRow row in GrdCutAvg.Rows)
            {
                try
                {
                    CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                    HiddenField hdnOrderDetailsID = (HiddenField)row.FindControl("hdnOrderDetailsID");
                    RadioButtonList rdolistPass_fail = (RadioButtonList)row.FindControl("rdolistPass_fail");

                    if (Chkischeck != null && hdnOrderDetailsID != null)
                    {
                        if (Chkischeck.Checked && hdnOrderDetailsID.Value != "")
                        {
                            bool result;
                            result = objOrderController.UpdateTestReportFile(Convert.ToInt32(hdnOrderDetailsID.Value), hdnFldresolutionTestreport.Value, Convert.ToInt32(rdolistPass_fail.SelectedValue));
                            IsSave = result;

                            var pass_Fail = rdolistPass_fail.SelectedValue;
                            if (string.IsNullOrEmpty(pass_Fail))
                                pass_Fail = "2";

                            //int result = objOrderController.UploadTestReportMo(OrderDetailID, fileNameStyle1, fileNameStyle2, fileNameStyle3, pass_Fail);
                            if ((pass_Fail == "1" || pass_Fail == "3") && rdolistPass_fail.Enabled == true)
                            {
                                WorkflowController WorkflowControllerInstance = new WorkflowController();
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderId, Convert.ToInt32(hdnOrderDetailsID.Value), TaskMode.Test_Report, ApplicationHelper.LoggedInUser.UserData.UserID);
                                WorkflowControllerInstance = null;

                            }

                        }

                    }
                }

                catch (Exception ex)
                {
                    IsSave = false;
                    string script3 = "alert('" + ex.ToString() + "');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "UserSecurity", script3, true);
                }

            }

        }
        
        return IsSave;
    }

    protected void rptFile_ItemDataBound(object sender, RepeaterItemEventArgs e) 
    {
      ImageButton imgRow = (ImageButton)e.Item.FindControl("imgRow");
      if(imgRow!=null)
      {
        if (IsShipped == "1" || IsShipped == "True")
        {
          imgRow.Visible = false;
          btnupload.Visible = false;
          btnUpload1.Visible = false;
        }
        
      }
      
    }
    public void Checkbox()
    {
        int count = 0;

        CheckBox ChkBoxHeader = (CheckBox)GrdCutAvg.HeaderRow.FindControl("chkboxSelectAll");
        if (ChkBoxHeader != null)
        {


            foreach (GridViewRow row in GrdCutAvg.Rows)
            {
                CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                if (Chkischeck != null)
                {

                    if (Chkischeck.Checked == true)
                        count += 1;

                }
            }
            if (count > 0)
                ChkBoxHeader.Checked = true;
            else
                ChkBoxHeader.Checked = false;
        }

    }

    protected void Chkischeck_CheckedChanged(object sender, EventArgs e)
    {

        Checkbox();
    }
    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox ChkBoxHeader = (CheckBox)GrdCutAvg.HeaderRow.FindControl("chkboxSelectAll");

        if (ChkBoxHeader != null)
        {
            foreach (GridViewRow row in GrdCutAvg.Rows)
            {
                CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                if (Chkischeck != null)
                {
                    if (ChkBoxHeader.Checked == true)
                    {
                        if (Chkischeck.Enabled)
                        {
                            Chkischeck.Checked = true;
                        }

                    }
                    else
                    {
                        if (Chkischeck.Enabled)
                        {
                            Chkischeck.Checked = false;
                        }
                    }
                }
            }
        }

    }
    protected void GrdCutAvg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
            HiddenField hdnStylenotestReportPath = e.Row.FindControl("hdnStylenotestReportPath") as HiddenField;
            if (hdnStylenotestReportPath.Value != "")
            {
                hdnWholeFile.Value = hdnStylenotestReportPath.Value;
            }
            //HtmlGenericControl texts = (HtmlGenericControl)e.Row.FindControl("texts");
            if (hdnOrderDetailsID != null)
            {
                CheckBox Chkischeck = (CheckBox)e.Row.FindControl("Chkischeck");
                if (string.Equals(hdnOrderDetailsID.Value, OrderDetailID.ToString()))
                {
                    //e.Row.BackColor = System.Drawing.Color.Gray;


                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#DCDCDC");
                    Chkischeck.Checked = true;
                    Chkischeck.Enabled = false;

                    //HtmlAnchor BrowseFile1 = e.Row.FindControl("BrowseFile1") as HtmlAnchor;
                    //HtmlAnchor AnctestReport = e.Row.FindControl("AnctestReport") as HtmlAnchor;

                }
                else
                {

                    //HyperLink hyplnkBrowseFileIE = e.Row.FindControl("hyplnkBrowseFileIE") as HyperLink;
                    //HyperLink hyperlnkhas = e.Row.FindControl("hyperlnkhas") as HyperLink;

                    //hyperlnkhas.Attributes.Add("onclick", "javascript:UploadFile_IE(" + hdnStylenotestReportPath.Value + ")");
                    // hyplnkBrowseFileIE.Attributes.Add("onclick", "javascript:UploadFile_IE(" + hdnStylenotestReportPath.Value + ")");


                    if (hdnStylenotestReportPath != null)
                    {
                        if (hdnStylenotestReportPath.Value != "")
                        {
                            // AnctestReport.Attributes.Add("style", "display:block");
                            //BrowseFile1.Attributes.Add("style", "display:none");
                            //hyperlnkhas.Visible = true;
                            //hyplnkBrowseFileIE.Visible = false;
                            Chkischeck.Enabled = false;
                            // texts.InnerText = "View";

                        }
                        else
                        {
                            // AnctestReport.Attributes.Add("style", "display:none");
                            // BrowseFile1.Attributes.Add("style", "display:block");

                            // hyperlnkhas.Visible = false;
                            //hyplnkBrowseFileIE.Visible = true;
                            Chkischeck.Enabled = true;
                            //texts.InnerText = "Browse";
                        }

                    }
                }
                HiddenField hdntestcheck = e.Row.FindControl("hdntestcheck") as HiddenField;
                RadioButtonList rdolistPass_fail = e.Row.FindControl("rdolistPass_fail") as RadioButtonList;

                rdolistPass_fail.SelectedValue = hdntestcheck.Value;
                
            }
        }

    }

    //protected void btnSvaeFile_Click(object sender, EventArgs e)
    //{
    //    string TotalFilePath = "";
    //    hdnindex.Value = index;
    //    foreach (RepeaterItem rptItem in rptFile.Items)
    //    {
    //        HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
    //        TotalFilePath += hdnFilePath.Value + "$";
    //    }
    //    if (TotalFilePath.Length > 0)
    //    {
    //        TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
    //    }
    //    hdnWholeFile.Value = TotalFilePath;
    //    if (hdnFlagIE.Value == "IE")
    //    {
    //        //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPageIE();", true);
    //        Session["FileDoc"] = hdnWholeFile.Value;
    //        //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "CallBackParentPageIE();", true);
    //        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    //    }
    //    else
    //    {
    //        //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
    //        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    //    }
    //}
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
                filename = iKandi.Web.Components.FileHelper.SaveFile(Fldresolution.PostedFile.InputStream, Fldresolution.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
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
           // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }

    private void BindFault()
    {
        try
        {
            DataTable dt = CreateTable();
            //hdnWholeFile.Value = "fffff4$tttttttttt$hfghfg";
            if (!string.IsNullOrEmpty(hdnWholeFile.Value))
            {
                string[] File = hdnWholeFile.Value.Split('$');
                for (int i = 0; i < File.Length; i++)
                    dt.Rows.Add(File[i]);

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

    private DataTable CreateTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
        dt.Columns.Add(new DataColumn("IsShiped", typeof(bool)));
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

    protected void GrdCutAvg_RowCommand(object sender, GridViewCommandEventArgs e) 
    {
        if (e.CommandName == "VIEW")
        {
            LinkButton lnkView = (LinkButton)e.CommandSource;
            string dealId = lnkView.CommandArgument;
            //if(dealId!="")
            //{
                hdnWholeFile.Value=dealId;
                BindFault();
            //}
        }
    }

    //protected void btncancel_Click(object sender, EventArgs e)
    //{
    //    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

    //}
  }
}