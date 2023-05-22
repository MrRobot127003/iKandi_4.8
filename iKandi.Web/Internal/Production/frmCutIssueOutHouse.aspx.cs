using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
namespace iKandi.Web.Internal.Production
{
  public partial class frmCutIssueOutHouse : System.Web.UI.Page
  {
    AdminController oAdminController = new AdminController();
    OrderController od = new OrderController();
    public static int OrderID
    {
      get;
      set;
    }
    public static int OrderDetailID
    {
      get;
      set;
    }
    public static int UnitID
    {
      get;
      set;
    }
    static int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
    iKandi.BLL.OrderController OrderControllerInstance = new BLL.OrderController();
    protected void Page_Load(object sender, EventArgs e)
    {
      GetQueryString();
      if (!IsPostBack)
      {
        GetQueryString();
        bindgrd();    
      }
    }
    public void bindgrd()
    {

      DataTable dt = oAdminController.GetCutIssueDetail(OrderDetailID, UnitID);
      if (dt.Rows.Count > 0)
      {
          lblFactoryName.Text = dt.Rows[0]["sendUnit"].ToString() == "" ? "" : "(" + dt.Rows[0]["sendUnit"].ToString() + ")";
        grdFabricInhouse.DataSource = dt;
        grdFabricInhouse.DataBind();

        if (grdFabricInhouse.Rows.Count > 0)
          grdFabricInhouse.Rows[grdFabricInhouse.Rows.Count - 1].Font.Bold = true;
      }
    }
    public void GetQueryString()
    {

      if (Request.QueryString["OrderID"] != null)
      {
        OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
      }
      if (Request.QueryString["OrderDetailID"] != null)
      {
        OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
      }
      if (Request.QueryString["UnitID"] != null)
      {
        UnitID = Convert.ToInt32(Request.QueryString["UnitID"]);
      }

    }
    public void ShowAlert(string stringAlertMsg)
    {
      string myStringVariable = string.Empty;
      myStringVariable = stringAlertMsg;
      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }
    private DateTime ConvertToDateTime(string strDateTime)
    {
      DateTime dtFinaldate; string sDateTime;
      //try { dtFinaldate = Convert.ToDateTime(strDateTime); }
      //catch (Exception e)
      //{
      string[] sDate = strDateTime.Split('/');
      sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
      dtFinaldate = Convert.ToDateTime(sDateTime);
      // }
      return dtFinaldate;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

      if (string.IsNullOrEmpty(txtdate.Text))
      {
        ShowAlert("Date cannot be empty !");
        return;
      }

      if (string.IsNullOrEmpty(txtdate.Text))
      {
        ShowAlert("Date cannot be empty !");
        return;
      }
      if (string.IsNullOrEmpty(txtCutIssueQty.Text))
      {
        ShowAlert("Qty cannot be empty !");
        return;
      }
      if (!string.IsNullOrEmpty(txtCutIssueQty.Text))
      {
        if (Convert.ToInt32(txtCutIssueQty.Text.Trim()) <= 0)
        {
          ShowAlert("Qty cannot be 0 !");
          return;
        }
      }
      if (string.IsNullOrEmpty(txtChallNo.Text))
      {
        ShowAlert("Challan no. cannot be empty !");
        return;
      }
      if (string.IsNullOrEmpty(txtdate.Text))
      {
        ShowAlert("Date cannot be empty !");
        return;
      }
      if (string.IsNullOrEmpty(txtCutIssueQty.Text))
      {
        ShowAlert("Qty cannot be empty !");
        return;
      }
      if (!string.IsNullOrEmpty(txtCutIssueQty.Text))
      {
        if (Convert.ToInt32(txtCutIssueQty.Text.Trim()) <= 0)
        {
          ShowAlert("Qty cannot be 0 !");
          return;
        }
      }
      if (string.IsNullOrEmpty(txtChallNo.Text))
      {
        ShowAlert("Challan no. cannot be empty !");
        return;
      }

      DateTime dtime = DateTime.Now;
      if (txtdate != null && txtdate.Text != "")
      {
        try
        {
          string[] dd = txtdate.Text.Split('-');
          string stringdate = dd[0] + "/" + dd[1] + "/" + dd[2];
          DateTime date = ConvertToDateTime(stringdate);
          dtime = date;
        }
        catch (Exception ex)
        {
          ShowAlert(ex.ToString());

        }
      }
      int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      int iupdate = oAdminController.UpdateCutissue(OrderDetailID, Convert.ToInt32(txtCutIssueQty.Text.Trim()), txtChallNo.Text.Trim(), UnitID, dtime, UserId);
      if (iupdate > 0)
      {
        ShowAlert("Record save successfully. ");
        bindgrd();
        Reset();
      }
    }
    public void Reset()
    {
      txtChallNo.Text = "";
      txtCutIssueQty.Text = "";
      txtdate.Text = "";
    }
  }
}