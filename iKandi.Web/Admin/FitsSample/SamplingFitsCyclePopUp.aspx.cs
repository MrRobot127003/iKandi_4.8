using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using System.Web.Services;
using System.Text;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;


namespace iKandi.Web.Admin.FitsSample
{
  public partial class WebForm1 : System.Web.UI.Page
  {
    int Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
    FITsController FITsControllerInstance = new FITsController(ApplicationHelper.LoggedInUser);
    DataSet dsResample = null;
    DataTable dtResample = null;
    public static int StyleId
    {
      get;
      set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        GetQueryString();
        dsResample = FITsControllerInstance.GetReqSample(StyleId);
        dtResample = dsResample.Tables[0];
        lblStyleNo.Text = dsResample.Tables[1].Rows[0]["StyleNumber"].ToString();
        Session["dtsess"] = dtResample;
        BindSamplingFitsCycle();

       
          if (Session["issave"] != null)
          {
            if (Session["issave"].ToString() == "YES")
            {
              ShowAlert("Record updated successfully.");
            }
            Session["issave"] = null;
          }
       
          
      }
    }
    public void GetQueryString()
    {
      if (null != Request.QueryString["StyleId"])
      {
        StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);

      }
    }
    public void BindSamplingFitsCycle()
    {
      DataSet ds = FITsControllerInstance.GetSamplingFitsCycle(StyleId);
      DataTable dt = ds.Tables[0];
      DataTable dtStcApproved = ds.Tables[1];

      DataSet ds_pro = FITsControllerInstance.GetProDuctionFitsCycle(StyleId);
      DataTable dt_pro = ds_pro.Tables[0];
     

      if (dtStcApproved.Rows.Count > 0)
      {
        if (dtStcApproved.Rows[0]["StcApproved"].ToString() == "0")
        {
          divpattern.Visible = false;
        }
      }

      grdsamplebefore.DataSource = dt;
      grdsamplebefore.DataBind();

      grdProdSetCycle.DataSource = ds_pro;
      grdProdSetCycle.DataBind();
      RemoveItemAlreadyTaken();

      if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant)
      {
        proddiv.Visible = false;
        grdProdSetCycle.Enabled = false;

      }
      else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_PPC_Exec)
      {
        divheaderpattern.Visible = false;
        grdsamplebefore.Enabled = false;

        proddiv.Visible = true;
        grdProdSetCycle.Enabled = true;
      }
      else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_CAD_Manager)
      {
          //---------In case of Gulbas if sample request not initate for production then always Pattern grid hide..
          if (this.FITsControllerInstance.bCheck_ProductionRequestIntiate(StyleId,false) == false)
          {
              divheaderpattern.Visible = false;
              grdsamplebefore.Enabled = false;
          }
          else
          {
              divheaderpattern.Visible = true;
              grdsamplebefore.Enabled = true;
          }
       
//---------In case of Gulbas if producction not initate for production then always production grid hide..
        if (this.FITsControllerInstance.bCheck_ProductionRequestIntiate(StyleId,true) == false)
        {
            proddiv.Visible = false;
            grdProdSetCycle.Enabled = false;
        }
        else
        {
            proddiv.Visible = true;
            grdProdSetCycle.Enabled = true;
        }
       
      }

    }
    public void BinddllRequest(DropDownList ddl,string values)
    {
      if (Session["dtsess"] != null)
      {
        DataTable dts = (DataTable)Session["dtsess"];
        ddl.DataSource = dts;
        ddl.DataValueField = "Value";
        ddl.DataTextField = "Texts";
        ddl.DataBind();
        ddl.SelectedValue = values;
        for (int i = dts.Rows.Count - 1; i >= 0; i--)
        {
          DataRow dr = dts.Rows[i];
          if (dr["Value"].ToString() == values)
          {
            dr.Delete();
          }
        }
        dts.AcceptChanges();
      }
    }
    
    protected void grdsamplebefore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DropDownList ddlrequestsample = (DropDownList)e.Row.FindControl("ddlrequestsample");
        CheckBox ChkPatternReady = (CheckBox)e.Row.FindControl("ChkPatternReady");
        CheckBox ChkSampleSent = (CheckBox)e.Row.FindControl("ChkSampleSent");        
        BinddllRequest(ddlrequestsample, Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReqSample")));      
        ddlrequestsample.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReqSample"));
        //Remove = Remove+ddlrequestsample.SelectedValue + ",";
        //string[] savePathCollection = Remove.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //foreach (string str in savePathCollection)
        //{
        //  ddlrequestsample.Items.Remove(str);
        //}

        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsPatternReady")) != "0" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsPatternReady")) != "")
        {
          ChkPatternReady.Checked = true;
        }
        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsSampleSent")) != "0" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsSampleSent")) != "")
        {
          ChkSampleSent.Checked = true;
        }
        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant)
        {
          ddlrequestsample.Enabled = true;
          if (ChkPatternReady.Checked == true)
          {
            if (ddlrequestsample.SelectedValue != "Select")
            {
              ChkSampleSent.Enabled = true;
            }
          }
        }
        else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_CAD_Manager)
        {
          ddlrequestsample.Enabled = false;
          ChkSampleSent.Enabled = false;
          if (ddlrequestsample.SelectedValue != "Select")
          {
            ChkPatternReady.Enabled = true;
          }
        }
        if (ChkPatternReady.Checked == true)
        {
          if (ddlrequestsample.SelectedValue != "Select")
          {
            ddlrequestsample.Enabled = false;
            ChkPatternReady.Enabled = false;
          }
        }
        if (ddlrequestsample.SelectedValue != "Select" && ChkPatternReady.Checked == true && ChkSampleSent.Checked == true)
        {
          ddlrequestsample.Enabled = false;
          ChkPatternReady.Enabled = false;
          ChkSampleSent.Enabled = false;
        }
      }
    }
    int flagSave = 0;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      SaveRecord();
      if (flagSave == 0)
      {
       // BindSamplingFitsCycle();
      }
    }
    public void SaveRecord()
    {
      if (StyleId == 0)
      {
        StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
      }
      // SqlTransaction objTrans = null;
      if (grdsamplebefore.Enabled == true)
      {
        foreach (GridViewRow row in grdsamplebefore.Rows)
        {
          try
          {

            DropDownList ddlrequestsample = (DropDownList)row.FindControl("ddlrequestsample");
            CheckBox ChkPatternReady = (CheckBox)row.FindControl("ChkPatternReady");
            CheckBox ChkSampleSent = (CheckBox)row.FindControl("ChkSampleSent");
            HiddenField hdnID = (HiddenField)row.FindControl("hdnID");

            #region Sample Request by PD
            if (ddlrequestsample.Enabled == true && ChkPatternReady.Enabled == false && ChkSampleSent.Enabled == false)
            {
              if (ddlrequestsample.SelectedValue == "Select")
              {
                flagSave = 1;
                ShowAlert("Please select sample request first!");
                return;
              }
              else
              {
                int result = FITsControllerInstance.InsertSamplingFitsCycle(StyleId, ddlrequestsample.SelectedValue, Convert.ToInt32(hdnID.Value), "REQSAMPLE");
                Response.Redirect(Request.RawUrl, false);
                Session["issave"] = "YES";
                //ShowAlert("Record updated successfully");
              }
              // objTrans.Commit(); 
            }
            #endregion
            #region Pattern ready by BIPL cad manager
            if (ddlrequestsample.Enabled == false && ChkPatternReady.Enabled == true && ChkSampleSent.Enabled == false && ChkPatternReady.Checked == true)
            {
              if (ChkPatternReady.Checked == false)
              {
                flagSave = 1;
               // ShowAlert("Please select pattern ready first");
                return;
              }
              else
              {
                int result = FITsControllerInstance.InsertSamplingFitsCycle(StyleId, ddlrequestsample.SelectedValue, Convert.ToInt32(hdnID.Value), "PATTERNREADY");
                Response.Redirect(Request.RawUrl, false);
                Session["issave"] = "YES";
                //ShowAlert("Record updated successfully");
              }
            }
            #endregion
            #region Sample sent by PD
            if (ddlrequestsample.Enabled == false && ChkPatternReady.Enabled == false && ChkSampleSent.Enabled == true && ChkSampleSent.Checked==true)
            {
              if (ChkSampleSent.Checked==false)
              {
                flagSave = 1;
                ShowAlert("Please select sample sent first!");
                return;
              }
              else
              {
                int result = FITsControllerInstance.InsertSamplingFitsCycle(StyleId, ddlrequestsample.SelectedValue, Convert.ToInt32(hdnID.Value), "SAMPLESENT");
                Response.Redirect(Request.RawUrl, false);
                Session["issave"] = "YES";
               // ShowAlert("Record updated successfully");
              }
            }
            #endregion

          }
          catch (Exception ex)
          {
            //objTrans.Rollback();  
            ShowAlert(ex.Message);
          }
        }
      }
      if (grdProdSetCycle.Enabled == true)
      {
        foreach (GridViewRow row in grdProdSetCycle.Rows)
        {
          try
          {
            DropDownList ddlrequestProduction = (DropDownList)row.FindControl("ddlrequestProduction");
            CheckBox ChkPatternReady = (CheckBox)row.FindControl("ChkPatternReady");
            HiddenField hdnID = (HiddenField)row.FindControl("hdnID");
            #region Sample Request by PD
            if (ddlrequestProduction.Enabled == true && ChkPatternReady.Enabled == false)
            {
              if (ddlrequestProduction.SelectedValue == "Select")
              {
                flagSave = 1;
                ShowAlert("Please select production sample request first!");
                return;
              }
              else
              {
                int result = FITsControllerInstance.InsertProductionFitsCycle(StyleId, ddlrequestProduction.SelectedValue, Convert.ToInt32(hdnID.Value), "REQSPRODUCTIONAMPLE");
                Response.Redirect(Request.RawUrl, false);
                Session["issave"] = "YES";
                //ShowAlert("Record updated successfully");
              }
              // objTrans.Commit(); 
            }
            #endregion
            #region Pattern ready by BIPL cad manager
            if (ddlrequestProduction.Enabled == false && ChkPatternReady.Enabled == true)
            {
              if (ChkPatternReady.Checked == true)
              {
                if (ddlrequestProduction.SelectedValue == "Select")
                {
                  flagSave = 1;
                  ShowAlert("Please select production sample request first!");
                
                  return;
                }
              }
            }
            if (ddlrequestProduction.Enabled == false && ChkPatternReady.Enabled == true && ChkPatternReady.Checked == true)
            {
              if (ChkPatternReady.Checked == false)
              {
                flagSave = 1;
                ShowAlert("Please select pattern ready first!");
              
                return;
              }
              else
              {
                int result = FITsControllerInstance.InsertProductionFitsCycle(StyleId, ddlrequestProduction.SelectedValue, Convert.ToInt32(hdnID.Value), "PATTERNREADY");
                Response.Redirect(Request.RawUrl, false);
                Session["issave"] = "YES";
                //ShowAlert("Record updated successfully");
              }
            }
            #endregion
          }
          catch (Exception ex)
          {
            //objTrans.Rollback();  
            ShowAlert(ex.Message);
          }
        }
      }
    }
    public void ShowAlert(string stringAlertMsg)
    {
      string myStringVariable = string.Empty;
      myStringVariable = stringAlertMsg;
      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }
    protected void ddlrequestsample_SelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList ddlrequestsamples = (DropDownList)sender;
      GridViewRow row = (GridViewRow)ddlrequestsamples.NamingContainer;
      DropDownList ddlrequestsample_selected = (DropDownList)row.FindControl("ddlrequestsample");
      HiddenField hdnrequestsample = (HiddenField)row.FindControl("hdnrequestsample");
      int count = 0;
      foreach (GridViewRow rows in grdsamplebefore.Rows)
      {
        DropDownList ddlrequestsample = (DropDownList)rows.FindControl("ddlrequestsample");
        if (ddlrequestsample_selected.SelectedValue == ddlrequestsample.SelectedValue)
        {
          count = count + 1;
        }
      }
      if (count > 1)
      {
        ShowAlert("Selected Request Sample already taken");
        ddlrequestsample_selected.SelectedValue = hdnrequestsample.Value;
      }
    }
    List<string> myCollectionRemove = new List<string>();
    protected void grdProdSetCycle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DropDownList ddlrequestProduction = (DropDownList)e.Row.FindControl("ddlrequestProduction");
        CheckBox ChkPatternReady = (CheckBox)e.Row.FindControl("ChkPatternReady");

        ddlrequestProduction.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReqSample"));      
        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsPatternReady")) != "0" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsPatternReady")) != "")
        {
          ChkPatternReady.Checked = true;
        }
        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_PPC_Exec)
        {
          ddlrequestProduction.Enabled = true;
          ChkPatternReady.Enabled = false;
        }
        else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_CAD_Manager)
        {
          ddlrequestProduction.Enabled = false;
          if (ddlrequestProduction.SelectedValue == "Select" && ddlrequestProduction.Enabled == false)
          {
            ChkPatternReady.Enabled = false;
          }
          else
          {
            ChkPatternReady.Enabled = true;
          }
        }
        if (ChkPatternReady.Checked == true)
        {
          if (ddlrequestProduction.SelectedValue != "Select")
          {
            ddlrequestProduction.Enabled = false;
            ChkPatternReady.Enabled = false;
          }
        }
        if (ddlrequestProduction.SelectedValue != "Select" && ChkPatternReady.Checked == true)
        {
          ddlrequestProduction.Enabled = false;
          ChkPatternReady.Enabled = false;

        }
        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_CAD_Manager)
        {
          if (e.Row.RowIndex == (grdProdSetCycle.Rows.Count))
          {
            //last row
            if (ddlrequestProduction.SelectedValue == "Select")
            {
              e.Row.Visible = false;
            }
          }
        }
        if (ddlrequestProduction.SelectedValue != "Select")
        {
          if (ddlrequestProduction.Enabled == false && ChkPatternReady.Enabled == false)
          {
            myCollectionRemove.Add(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReqSample")));
          }
        }
      }
    }
    protected void ddlrequestProduction_SelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList ddlrequestProductions = (DropDownList)sender;
      GridViewRow row = (GridViewRow)ddlrequestProductions.NamingContainer;
      DropDownList ddlrequestProduction_selected = (DropDownList)row.FindControl("ddlrequestProduction");
      HiddenField hdnrequestsample = (HiddenField)row.FindControl("hdnrequestsample");
      int count = 0;
      foreach (GridViewRow rows in grdProdSetCycle.Rows)
      {
        DropDownList ddlrequestProduction = (DropDownList)rows.FindControl("ddlrequestProduction");
        if (ddlrequestProduction_selected.SelectedValue == ddlrequestProduction.SelectedValue)
        {
          count = count + 1;
        }
      }
      if (count > 1)
      {
        ShowAlert("Selected request production already taken!");
        ddlrequestProduction_selected.SelectedValue = hdnrequestsample.Value;
      }
    }
    public void RemoveItemFromddl()
    {
      foreach (GridViewRow row in grdsamplebefore.Rows)
      {
        DropDownList ddlrequestsample = (DropDownList)row.FindControl("ddlrequestsample");
        
      }
    }
    public void RemoveItemAlreadyTaken()
    {
      foreach (GridViewRow row in grdProdSetCycle.Rows)
      {
        DropDownList ddlrequestProduction = (DropDownList)row.FindControl("ddlrequestProduction");
        foreach (string str in myCollectionRemove)
        {
          if (ddlrequestProduction.Enabled != false)
          {
            if (ddlrequestProduction.Items.FindByText(str.ToString()) != null)
            {
              ddlrequestProduction.Items.Remove(str);
            }
          }
 
        }
      }
    }
    public void BindDll(DropDownList ddl)
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("Value", typeof(string));
      dt.Columns.Add("SelectedText", typeof(string));

     

      DataRow dr = dt.NewRow();
      dr["Value"] = "Select";
      dr["SelectedText"] = "Select";
      dt.Rows.Add(dr);

      dr = dt.NewRow();
      dr["Value"] = "Ref. sample 1";
      dr["SelectedText"] = "Ref. sample 1";
      dt.Rows.Add(dr);
      
      dr = dt.NewRow();
      dr["Value"] = "Ref. sample 2";
      dr["SelectedText"] = "Ref. sample 2";
      dt.Rows.Add(dr);

      dr = dt.NewRow();
      dr["Value"] = "Ref. sample 3";
      dr["SelectedText"] = "Ref. sample 3";
      dt.Rows.Add(dr);

      dr = dt.NewRow();
      dr["Value"] = "Ref. sample 4";
      dr["SelectedText"] = "Ref. sample 4";
      dt.Rows.Add(dr);


      dr = dt.NewRow();
      dr["Value"] = "Ref. sample 5";
      dr["SelectedText"] = "Ref. sample 5";
      dt.Rows.Add(dr);

      ddl.DataSource = dt;
      ddl.DataValueField = "Value";
      ddl.DataTextField = "SelectedText";
      ddl.DataBind();

      ddl.SelectedValue = "Select";
     

    }
    
  }
}