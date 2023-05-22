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
  public partial class frmProfitOnMode : System.Web.UI.Page
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
    int result = 0;
    string Original_Mode;
    StyleController ProfitStylecontroller = new StyleController();

    protected void Page_Load(object sender, EventArgs e)
    {
      GetQueryString();
      if (!IsPostBack)
      {
        bindProfitOnMode();
        lblHeaderModeText.Text = "Changing Mode From " + PreviousMode + " To " + Original_Mode;


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

      }
    }

    protected void GetQueryString()
    {

      if (null != Request.QueryString["PreviousMode"])
      {
        PreviousMode = Request.QueryString["PreviousMode"];
      }

      if (null != Request.QueryString["PreviousId"])
      {
        PreviousId = Convert.ToInt32(Request.QueryString["PreviousId"]);
      }
      if (null != Request.QueryString["OrderDetailId"])
      {
        OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
        Session["OrderDetailId_Reallocation"] = OrderDetailId;
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
      DataSet GetProfitOnMode = ProfitStylecontroller.GetProfitOn_Mode_Mo(OrderDetailId, Mode, "NoHold");
      DataTable DtGetProfitOnMode = new DataTable();

      DtGetProfitOnMode = GetProfitOnMode.Tables[0];
      DataRow row = DtGetProfitOnMode.NewRow();

      //row["SerialNumber"] = "Total";


      row["Quantity"] = Convert.ToInt32(getval(DtGetProfitOnMode, "Quantity")).ToString("N0");
      DtGetProfitOnMode.Rows.Add(row);

      Original_Mode = GetProfitOnMode.Tables[1].Rows[0]["CODE"].ToString(); ;
      grdProfitOnMode.DataSource = DtGetProfitOnMode;
      grdProfitOnMode.DataBind();

      GridViewRow lastrow = grdProfitOnMode.Rows[grdProfitOnMode.Rows.Count - 1];
      Label lblPenaltyQty = (Label)lastrow.FindControl("lblPenaltyQty");
      CheckBox chkFinalised = (CheckBox)lastrow.FindControl("chkFinalised");
      TextBox txtBiplShare = (TextBox)lastrow.FindControl("txtBiplShare");
      Label lblQty = (Label)lastrow.FindControl("lblQty");
      //if (Convert.ToString(SumOfPenalty) != "0")
      //{
      //  lblPenaltyQty.Text = "₹ " + Convert.ToInt32(SumOfPenalty).ToString("N0"); //updated code by bharat 15-jan-19

      //}
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
      lastrow.Cells[0].Attributes.Add("style", "color:gray !important;font-weight:bold !important;font-size:11px !important");
      //  lblPenaltyQty.Attributes.Add("style", "font-size:11px !important;font-weight:bold !important;color:red");
      //end 

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

        if (hdnFinalised.Value != "")
          chkFinalised.Checked = Convert.ToBoolean(hdnFinalised.Value);
        int weight = 0;
        if (lblweight.Text.Trim() != "")
        {
          weight = Convert.ToInt32(lblweight.Text);
        }

        Label lblPenaltyQty = (Label)e.Row.FindControl("lblPenaltyQty");
        Label lblQty = (Label)e.Row.FindControl("lblQty");



        if (Mode != 37 && Mode != 38 && Mode != 35)
        {
          //if (txtBiplShare.Text == "0")
          //{
          txtBiplShare.Text = "";
          lblPenalty.Text = "";
          //}
          txtBiplShare.Enabled = false;
          chkFinalised.Enabled = true;

        }
        else
        {
          if (txtBiplShare.Text == "0")
          {
            txtBiplShare.Text = "50";
          }
          if (weight == 0)
          {
            chkFinalised.Enabled = false;
            txtBiplShare.Enabled = false;
          }

        }
        if (!string.IsNullOrEmpty(lblPenalty.Text.Trim()))
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

        HiddenField hdnorderdetailid = (HiddenField)e.Row.FindControl("hdnorderdetailid");
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
      foreach (GridViewRow rowsfirst in grdProfitOnMode.Rows)//reset all checkbox then countinue
      {
        CheckBox Chkisfinalise = (CheckBox)rowsfirst.FindControl("chkFinalised");
        Chkisfinalise.Checked = false;
      }
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
          //foreach (GridViewRow rowsfirst in grdProfitOnMode.Rows)
          //{
          //  Label lblExFactory = (Label)rowsfirst.FindControl("lblExFactory");
          //  CheckBox Chkisfinalise = (CheckBox)rowsfirst.FindControl("chkFinalised");
          //  foreach (GridViewRow rows in grdProfitOnMode.Rows)
          //  {
          //    Label lblExFactory2 = (Label)rows.FindControl("lblExFactory");
          //    CheckBox Chkisfinalise2 = (CheckBox)rows.FindControl("chkFinalised");
          //    if (lblExFactory.Text == lblExFactory2.Text)
          //    {
          //      Chkisfinalise2.Checked = false;
          //    }
          //  }
          //}
        }
      }
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
      //get();
    }
    public void GetSelectedPenaltySum()
    {
      decimal penaltysum = 0;
      if (Mode == 37 || Mode == 38)
      {
        foreach (GridViewRow rows in grdProfitOnMode.Rows)
        {
          
            Label lblPenaltyQty = (Label)rows.FindControl("lblPenaltyQty");
            CheckBox Chkisfinalise = (CheckBox)rows.FindControl("chkFinalised");
            if (Chkisfinalise.Checked == true)
            {
              if (lblPenaltyQty.Text != "")
              {
                decimal getval = Convert.ToDecimal(lblPenaltyQty.Text.Replace("₹", "").Trim());
                penaltysum = penaltysum + Math.Abs(getval);
              }

            }
          } 
      }
      GridViewRow lastrow2 = grdProfitOnMode.Rows[grdProfitOnMode.Rows.Count - 1];
      if (Mode == 37)
      {
        if (penaltysum > 0)
        {
          lastrow2.Cells[8].Text = "₹ " + Convert.ToDecimal(penaltysum).ToString("N0");
          lastrow2.Cells[8].ForeColor = System.Drawing.Color.Red;
          lastrow2.Cells[8].Font.Bold = true;
          lastrow2.Cells[8].Font.Size = 11;
          lastrow2.Cells[8].Attributes.Add("style", "font-size:11px !important;");

        }
        else
        {
          lastrow2.Cells[8].Text = "";
        }
      }
      else if (Mode == 38)
      {
        if (Math.Abs(penaltysum) > 0)
        {
          lastrow2.Cells[8].Text = "₹ -" + Convert.ToDecimal(penaltysum).ToString("N0");
          lastrow2.Cells[8].ForeColor = System.Drawing.Color.Green;
          lastrow2.Cells[8].Font.Bold = true;
          lastrow2.Cells[8].Font.Size = 11;
          lastrow2.Cells[8].Attributes.Add("style", "font-size:11px !important;");
        }
        else
        {
          lastrow2.Cells[8].Text = "";
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
      Label lblPenaltyQty = (Label)row.FindControl("lblPenaltyQty");

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
      GetSelectedPenaltySum();

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      bool finalisePenalty;
      int BiplShare = 0;
      int IsSave = 0;
      int Orderdiscount;

      foreach (GridViewRow row in grdProfitOnMode.Rows)
      {
        try
        {
          HiddenField Id = (HiddenField)row.FindControl("Id");
          CheckBox Chkisfinalise = (CheckBox)row.FindControl("chkFinalised");
          TextBox txtBiplShare = (TextBox)row.FindControl("txtBiplShare");
          TextBox lblPenalty = (TextBox)row.FindControl("lblPenalty");

          if (lblPenalty.Text == "")
          {
            lblPenalty.Text = "0";
          }
          Orderdiscount = Convert.ToInt32(lblPenalty.Text.Replace("₹", ""));

          OrderDetailId = Convert.ToInt32(Id.Value);
          if (Chkisfinalise.Checked == true)
            finalisePenalty = true;
          else
            finalisePenalty = false;
          if (txtBiplShare.Text != "")
          {
            BiplShare = Convert.ToInt32(txtBiplShare.Text);
          }
          if (finalisePenalty == true)
          {
            result = ProfitStylecontroller.UpdateProfitOn_Mode_Mo(OrderDetailId, finalisePenalty, BiplShare, Mode, Orderdiscount, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName);
            result = 1;
          }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        }

      }
      // return IsSave;
      IsSave = result;
      if (IsSave == 1)
      {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Page save successfully');", true);
        bindProfitOnMode();
      }
    }

  }
}