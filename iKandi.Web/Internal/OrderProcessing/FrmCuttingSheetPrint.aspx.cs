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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using System.Text;
namespace iKandi.Web.Internal.OrderProcessing
{
  public partial class FrmCuttingSheetPrint : System.Web.UI.Page
  {
    public string StyleCode
    {
      get;
      set;
    }

    public int Mode
    {
      get;
      set;
    }
    public int OrderDetailId
    {
      get;
      set;
    }

    public string PreviousMode
    {
      get;
      set;
    }

    public int PreviousId
    {
      get;
      set;
    }
    public decimal SumOfPenalty
    {
      get;
      set;
    }
    public decimal SumQty
    {
      get;
      set;
    }
    public int OrderID
    {
      get;
      set;
    }
    
    int result = 0;
    string Original_Mode;
    OrderController objOrderController = new OrderController();
    StyleController ProfitStylecontroller = new StyleController(); 

    protected void Page_Load(object sender, EventArgs e)
    {
      GetQueryString();
      if (!IsPostBack)
      {
        bindProfitOnMode();
        if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) == 46)
           rdgroup.Enabled = false;
        else
            rdgroup.Enabled = true;
        //lblHeaderModeText.Text = "Changing Mode From " + PreviousMode + " To " + Original_Mode;


        if (Mode == 37)
        {
          //Air Share
          HdnAirMode.Value = "1";
        }
        if (Mode == 38)
        {
          //Sea Share
          HdnAirMode.Value = "2";
        }
        objOrderController.DeleteSession(System.Web.HttpContext.Current.Session.SessionID);
      }
     
      
    }

    protected void GetQueryString()
    {

      if (null != Request.QueryString["PreviousMode"])
      {
        PreviousMode = Request.QueryString["PreviousMode"];
      }
      if (null != Request.QueryString["OrderID"])
      {
        OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
      }

      if (null != Request.QueryString["PreviousId"])
      {
        PreviousId = Convert.ToInt32(Request.QueryString["PreviousId"]);
      }
      if (null != Request.QueryString["OrderDetailId"])
      {
        OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
        Session["OrderDetailId_CuttingSheet"] = OrderDetailId;
      }
      if (null != Request.QueryString["Mode"])
      {
        Mode = Convert.ToInt32(Request.QueryString["Mode"]);
      }



    }
    public int getval(DataTable dt, string colname)
    {
      int result = 0;
      foreach (DataRow dr in dt.Rows)
      {
        result = result + Convert.ToInt32(dr[colname].ToString().Replace(",", ""));

      }
      return result;
    }
    public void bindProfitOnMode()
    {
      DataSet GetProfitOnMode = ProfitStylecontroller.GetProfitOn_Mode_Mo(OrderDetailId, Mode,"Hold");
      DataTable DtGetProfitOnMode = new DataTable();

      DtGetProfitOnMode = GetProfitOnMode.Tables[0];
      DataRow row = DtGetProfitOnMode.NewRow();

      //row["SerialNumber"] = "Total";


      row["Quantity"] = Convert.ToInt32(getval(DtGetProfitOnMode, "Quantity")).ToString("N0");
      DtGetProfitOnMode.Rows.Add(row);

      Original_Mode = GetProfitOnMode.Tables[1].Rows[0]["CODE"].ToString(); ;
      grdProfitOnMode.DataSource = DtGetProfitOnMode;
      grdProfitOnMode.DataBind();

      int height =15+ (15 * (DtGetProfitOnMode.Rows.Count));
      HtmlControl contentPanel1 = (HtmlControl)this.FindControl("sb-player");
      if (contentPanel1 != null)
      {
        contentPanel1.Attributes.Add("height", height.ToString() + "!important");
 
      }      
    
      GridViewRow lastrow = grdProfitOnMode.Rows[grdProfitOnMode.Rows.Count - 1];
      Label lblPenaltyQty = (Label)lastrow.FindControl("lblPenaltyQty");
      CheckBox chkFinalised = (CheckBox)lastrow.FindControl("chkFinalised");
      TextBox txtBiplShare = (TextBox)lastrow.FindControl("txtBiplShare");
      Label lblQty = (Label)lastrow.FindControl("lblQty");
      if (Convert.ToString(SumOfPenalty) != "0")
      {
        lblPenaltyQty.Text = "₹ " + Convert.ToInt32(SumOfPenalty).ToString("N0"); //updated code by bharat 15-jan-19

      }
      //updated code by bharat 15-jan-19
      if (Convert.ToDecimal(SumOfPenalty) < 0)
      {
        lblPenaltyQty.Attributes.Add("style", "font-size:11px !important;font-weight:bold !important;color:green");
      }
      else
      {
        lblPenaltyQty.Attributes.Add("style", "font-size:11px !important;font-weight:bold !important;color:red");
      }
      //end
      // updated code by bharat 11-jan-19
      lastrow.Cells[0].Attributes.Add("colspan", "6");
      lastrow.Cells[0].Text = "Total";
      lastrow.Cells[0].Attributes.Add("class", "rowspantd2");
      lastrow.Cells[1].Attributes.Add("class", "rowspantd2");
      lastrow.Cells[2].Attributes.Add("class", "rowspantd2");
      lastrow.Cells[3].Attributes.Add("class", "rowspantd2");
      lastrow.Cells[4].Attributes.Add("class", "rowspantd2");
      lastrow.Cells[5].Attributes.Add("class", "rowspantd2");

      //lastrow.Cells[1].ColumnSpan = 4;
      lastrow.Cells[1].Visible = false;
      lastrow.Cells[2].Visible = false;
      lastrow.Cells[3].Visible = false;
      lastrow.Cells[4].Visible = false;
      lastrow.Cells[5].Visible = false;
      //lastrow.Cells[8].Text = "";

      chkFinalised.Visible = false;
      txtBiplShare.Visible = false;
      lblQty.Attributes.Add("style", "font-size:11px !important;font-weight:bold !important;");
      lastrow.Cells[0].Attributes.Add("style", "color:gray !important;font-weight:bold !important;font-size:11px !important;text-align:right;padding-right:5px;");
      //  lblPenaltyQty.Attributes.Add("style", "font-size:11px !important;font-weight:bold !important;color:red");
      //end    
      ScriptManager.RegisterStartupScript(this, this.GetType(), "TEST123", "javascript:resizeframe('" + height + "');", true);
      //string jsFunc = "resizeframe(" + height + ")";
      //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunc, true);
    }
    protected void RadioButton_CheckedChanged(object sender, System.EventArgs e)
    {
      setCheckbox();
      if (grdProfitOnMode.Rows.Count > 0)
      {
        GridViewRow lastrow = grdProfitOnMode.Rows[grdProfitOnMode.Rows.Count - 1];
        lastrow.Cells[0].Text = "Total";
      }
    }
    protected void grdProfitOnMode_RowDataBound(object sender, GridViewRowEventArgs e)
    {

      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblweight = (Label)e.Row.FindControl("lblweight");
        CheckBox chkFinalised = (CheckBox)e.Row.FindControl("chkFinalised");
        TextBox txtBiplShare = (TextBox)e.Row.FindControl("txtBiplShare");
        HiddenField hdnFinalised = (HiddenField)e.Row.FindControl("hdnFinalised");
        GridView grdifabric = (GridView)e.Row.FindControl("grdifabric");
        TextBox lblPenalty = (TextBox)e.Row.FindControl("lblPenalty");
        HiddenField hdnorderdetailid = (HiddenField)e.Row.FindControl("hdnorderdetailid");
        if (hdnFinalised.Value != "")
          chkFinalised.Checked = Convert.ToBoolean(hdnFinalised.Value);
        int weight = 0;
        if (lblweight.Text.Trim() != "")
        {
          weight = Convert.ToInt32(lblweight.Text);
        }

        Label lblPenaltyQty = (Label)e.Row.FindControl("lblPenaltyQty");
        Label lblQty = (Label)e.Row.FindControl("lblQty");
       
        if (DataBinder.Eval(e.Row.DataItem, "IsCheckBoxSelect").ToString() == "1")
        {
                    e.Row.Attributes["Class"] = "MySelectBackground";
                    chkFinalised.Checked = true;
        }
        else
        {
            if (DataBinder.Eval(e.Row.DataItem, "isselected").ToString() == "1")
            {

                e.Row.Attributes["Class"] = "MyPanelBackground";
            }
        }
if (Convert.ToInt32( ApplicationHelper.LoggedInUser.UserData.DesignationID) == 46)
        chkFinalised.Enabled = false;
else
        chkFinalised.Enabled = true;

        

        if (Mode != 37 && Mode != 38)
        {
          //if (txtBiplShare.Text == "0")
          //{
          txtBiplShare.Text = "";
          lblPenalty.Text = "";
          //}
          txtBiplShare.Enabled = false;
          //chkFinalised.Enabled = true;

        }
        else
        {
          if (txtBiplShare.Text == "0")
          {
            txtBiplShare.Text = "50";
          }
          if (weight == 0)
          {
            //chkFinalised.Enabled = false;
            txtBiplShare.Enabled = false;
          }

        }
        if ((!string.IsNullOrEmpty(lblPenalty.Text.Trim())) && (Convert.ToInt32(lblPenalty.Text) > 0))
        {
          //if (Convert.ToInt32(lblPenalty.Text) > 0)
          //{
          lblPenaltyQty.Text = Math.Round(Convert.ToDecimal(lblPenalty.Text) * Convert.ToDecimal(lblQty.Text), 0, MidpointRounding.AwayFromZero).ToString("#,##");
          SumOfPenalty = SumOfPenalty + Math.Round(Convert.ToDecimal(lblPenaltyQty.Text), 0, MidpointRounding.AwayFromZero);
          SumQty = SumQty + Convert.ToInt32(lblQty.Text.Replace(",", "").Trim());
          //}

        }
        else
        {
          lblPenaltyQty.Text = "";
        }

       
        if (hdnorderdetailid.Value != "")
        {
          //List<MOOrderDetails> objOrderDetail = Session["objOrderDetail"] as List<MOOrderDetails>;
          //List<MOOrderDetails> objOrderDetails = objOrderDetail.FindAll(delegate(MOOrderDetails a) { return ((a.OrderDetailID == Convert.ToInt32(hdnorderdetailid.Value))); });
          DataTable dt = ProfitStylecontroller.Getmodedetail(Convert.ToInt32(hdnorderdetailid.Value));
          if (dt.Rows.Count > 0)
          {
            grdifabric.DataSource = dt;
            grdifabric.DataBind();
          }
        }
        //updated code by bharat 15-jan-2018
        if (!string.IsNullOrEmpty(lblPenalty.Text))
        {
          if (Convert.ToDecimal(lblPenalty.Text) < 0)
          {
            lblPenalty.ForeColor = System.Drawing.Color.Green;
          }
          else
          {
            lblPenalty.ForeColor = System.Drawing.Color.Red;
          }
        }
        lblPenalty.Text = (lblPenalty.Text == "" ? "" : "₹ " + lblPenalty.Text);

        if (!string.IsNullOrEmpty(lblPenaltyQty.Text))
        {
          if (Convert.ToDecimal(lblPenaltyQty.Text) < 0)
          {
            lblPenaltyQty.ForeColor = System.Drawing.Color.Green;
          }
          else
          {
            lblPenaltyQty.ForeColor = System.Drawing.Color.Red;
          }
        }
        lblPenaltyQty.Text = (lblPenaltyQty.Text == "" ? "" : "₹ " + lblPenaltyQty.Text);
      }
      //End
    }
    public void setCheckbox()
    {

      if (rdgroup.Checked == true)
      {
        foreach (GridViewRow rowsfirst in grdProfitOnMode.Rows)
        {
          Label lblExFactory = (Label)rowsfirst.FindControl("lblExFactory");
          CheckBox Chkisfinalise = (CheckBox)rowsfirst.FindControl("chkFinalised");
          if (Chkisfinalise.Checked)
          {
            foreach (GridViewRow rows in grdProfitOnMode.Rows)
            {
              Label lblExFactory2 = (Label)rows.FindControl("lblExFactory");
              CheckBox Chkisfinalise2 = (CheckBox)rows.FindControl("chkFinalised");
              if (lblExFactory.Text == lblExFactory2.Text)
              {
                Chkisfinalise2.Checked = true;
              }
              else
              {
                Chkisfinalise2.Checked = false;
              }
            }
          }
          else
          {
            foreach (GridViewRow rows in grdProfitOnMode.Rows)
            {
              Label lblExFactory2 = (Label)rows.FindControl("lblExFactory");
              CheckBox Chkisfinalise2 = (CheckBox)rows.FindControl("chkFinalised");
              if (lblExFactory.Text == lblExFactory2.Text)
              {
                Chkisfinalise2.Checked = false;
              }
            }
          }
        }
      }
      else
      {
        if (rdgroup.Checked == false)
        {
        
        }
      }
    }
    protected void CheckBox1_Click(object sender, EventArgs e)
    {
      var chkBox = (CheckBox)sender;
      var selectedRow = chkBox.Parent.Parent;
      GridViewRow row = ((GridViewRow)selectedRow);
      Label lblExFactory = (Label)row.FindControl("lblExFactory");
      CheckBox Chkisfinalise = (CheckBox)row.FindControl("chkFinalised");

     
      if (Chkisfinalise.Checked == true)
      {
        if (rdgroup.Checked == true)
        {
          foreach (GridViewRow rows in grdProfitOnMode.Rows)
          {
            Label lblExFactory2 = (Label)rows.FindControl("lblExFactory");
            CheckBox Chkisfinalise2 = (CheckBox)rows.FindControl("chkFinalised");
            if (lblExFactory.Text == lblExFactory2.Text)
            {
              Chkisfinalise2.Checked = true;
            }
          }
        }

      }
      else
      {
        if (rdgroup.Checked == true)
        {
          foreach (GridViewRow rows in grdProfitOnMode.Rows)
          {
            Label lblExFactory2 = (Label)rows.FindControl("lblExFactory");
            CheckBox Chkisfinalise2 = (CheckBox)rows.FindControl("chkFinalised");
            if (lblExFactory.Text == lblExFactory2.Text)
            {
              Chkisfinalise2.Checked = false;
            }
          }
        }
      }
      if (grdProfitOnMode.Rows.Count > 0)
      {
        GridViewRow lastrow = grdProfitOnMode.Rows[grdProfitOnMode.Rows.Count - 1];
        lastrow.Cells[0].Text = "Total";
      }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      bool finalisePenalty;   
      int IsSave = 0;
      result = ProfitStylecontroller.DeleteSessionID(System.Web.HttpContext.Current.Session.SessionID);
      foreach (GridViewRow row in grdProfitOnMode.Rows)
      {
        try
        {
          HiddenField hdnorderdetailid = (HiddenField)row.FindControl("hdnorderdetailid");
          CheckBox Chkisfinalise = (CheckBox)row.FindControl("chkFinalised");
          TextBox txtBiplShare = (TextBox)row.FindControl("txtBiplShare");
          TextBox lblPenalty = (TextBox)row.FindControl("lblPenalty");
          OrderDetailId = Convert.ToInt32(hdnorderdetailid.Value);
          if (Chkisfinalise.Checked == true)
            finalisePenalty = true;
          else
            finalisePenalty = false;       
          if (finalisePenalty == true)
          {           
            result = ProfitStylecontroller.UpdateCuttingSheetSelection(OrderDetailId,System.Web.HttpContext.Current.Session.SessionID);
            result = 1;
          }
          int Result_Checkbox = ProfitStylecontroller.UpdateCuttingSheet_CheckBox(OrderDetailId, ApplicationHelper.LoggedInUser.UserData.UserID, Chkisfinalise.Checked);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        }
      }
      IsSave = result;
     
      if (IsSave == 1)
      {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "closeProfitOnMo();", true);
        //bindProfitOnMode();
      }
      //if (IsSave == 1)
      //{
      //  Response.Redirect("../Fabric/CuttingSheet.aspx",true);
      //}
    }
  }
}