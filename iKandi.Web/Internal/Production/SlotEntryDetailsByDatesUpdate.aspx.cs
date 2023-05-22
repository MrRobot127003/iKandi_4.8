using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using iKandi.Common;
using iKandi.Web.Components;
using System.Data;


namespace iKandi.Web.Internal.Production
{
  public partial class SlotEntryDetailsByDatesUpdate : System.Web.UI.Page
  {
    public int UnitId
    {
        get;
        set;
    }
    public int LinePlanningID
    {
      get;
      set;
    }
    public DateTime SlotCreateDate
    {
      get;
      set;
    }
    public int OrderDetailsID
    {
      get;
      set;
    }
    public int ClusterId
    {
        get;
        set;
    }
    public int ProductionType
    {
        get;
        set;
    }

    ProductionController objProductionController = new ProductionController();

    protected void Page_Load(object sender, EventArgs e)
    {
      GetQueryString();
      if (!Page.IsPostBack)
      {
          BindData();
      }

    }
    public void GetQueryString()
    {
        if (Request.QueryString["UnitId"] != null)
        {
            UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        }
        if (Request.QueryString["LinePlanningID"] != null)
        {
        LinePlanningID = Convert.ToInt32(Request.QueryString["LinePlanningID"]);
        }
        if (Request.QueryString["SlotCreateDate"] != null)
        {
        SlotCreateDate = Convert.ToDateTime(Request.QueryString["SlotCreateDate"]);
        }
        if (Request.QueryString["OrderDetailsID"] != null)
        {
        OrderDetailsID = Convert.ToInt32(Request.QueryString["OrderDetailsID"]);
        }
        if (Request.QueryString["ClusterId"] != null)
        {
            ClusterId = Convert.ToInt32(Request.QueryString["ClusterId"]);
        }
        else
        {
            ClusterId = 0;
        }          
    }
    public void BindData()
    {
      lblFactory.Text = UnitId == 3 ? "C 47" : "C 45-46";       

      DataSet ds = objProductionController.GetSlotEntryDetailsBylineID(UnitId, SlotCreateDate, LinePlanningID, OrderDetailsID, ClusterId);
      DataTable dt = ds.Tables[0];
      if (ClusterId <= 0)
      {
          if (dt.Rows.Count > 0)
          {
              lblHeader.Text = "Hourly Entry";
              lblLineHeader.Text = "Line No";
              lblDate.Text = SlotCreateDate.ToString("dd-MMM");
              lblLineNo.Text = "Line " + dt.Rows[0]["LineNo"].ToString();
              lblserial.Text = dt.Rows[0]["SerialNumber"].ToString();
              lblColor.Text = dt.Rows[0]["FabricDetail"].ToString();
              lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
              lblExFactory.Text = dt.Rows[0]["ExFactory"].ToString();

              lblSlot1Stitch.Text = dt.Rows[0]["Slot1Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot1Stitch"].ToString();
              lblSlot2Stitch.Text = dt.Rows[0]["Slot2Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot2Stitch"].ToString();
              lblSlot3Stitch.Text = dt.Rows[0]["Slot3Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot3Stitch"].ToString();
              lblSlot4Stitch.Text = dt.Rows[0]["Slot4Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot4Stitch"].ToString();
              lblSlot5Stitch.Text = dt.Rows[0]["Slot5Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot5Stitch"].ToString();
              lblSlot6Stitch.Text = dt.Rows[0]["Slot6Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot6Stitch"].ToString();
              lblSlot7Stitch.Text = dt.Rows[0]["Slot7Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot7Stitch"].ToString();
              lblSlot8Stitch.Text = dt.Rows[0]["Slot8Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot8Stitch"].ToString();
              lblSlot9Stitch.Text = dt.Rows[0]["Slot9Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot9Stitch"].ToString();
              lblSlot10Stitch.Text = dt.Rows[0]["Slot10Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot10Stitch"].ToString();
              lblSlot11Stitch.Text = dt.Rows[0]["Slot11Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot11Stitch"].ToString();
              lblSlot12Stitch.Text = dt.Rows[0]["Slot12Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot12Stitch"].ToString();


              lblSlot1Finish.Text = dt.Rows[0]["Slot1Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot1Finish"].ToString();
              lblSlot2Finish.Text = dt.Rows[0]["Slot2Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot2Finish"].ToString();
              lblSlot3Finish.Text = dt.Rows[0]["Slot3Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot3Finish"].ToString();
              lblSlot4Finish.Text = dt.Rows[0]["Slot4Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot4Finish"].ToString();
              lblSlot5Finish.Text = dt.Rows[0]["Slot5Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot5Finish"].ToString();
              lblSlot6Finish.Text = dt.Rows[0]["Slot6Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot6Finish"].ToString();
              lblSlot7Finish.Text = dt.Rows[0]["Slot7Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot7Finish"].ToString();
              lblSlot8Finish.Text = dt.Rows[0]["Slot8Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot8Finish"].ToString();
              lblSlot9Finish.Text = dt.Rows[0]["Slot9Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot9Finish"].ToString();
              lblSlot10Finish.Text = dt.Rows[0]["Slot10Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot10Finish"].ToString();
              lblSlot11Finish.Text = dt.Rows[0]["Slot11Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot11Finish"].ToString();
              lblSlot12Finish.Text = dt.Rows[0]["Slot12Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot12Finish"].ToString();


              txtSlot1Stitch.Text = dt.Rows[0]["Slot1Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot1Stitch"].ToString();
              txtSlot2Stitch.Text = dt.Rows[0]["Slot2Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot2Stitch"].ToString();
              txtSlot3Stitch.Text = dt.Rows[0]["Slot3Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot3Stitch"].ToString();
              txtSlot4Stitch.Text = dt.Rows[0]["Slot4Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot4Stitch"].ToString();
              txtSlot5Stitch.Text = dt.Rows[0]["Slot5Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot5Stitch"].ToString();
              txtSlot6Stitch.Text = dt.Rows[0]["Slot6Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot6Stitch"].ToString();
              txtSlot7Stitch.Text = dt.Rows[0]["Slot7Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot7Stitch"].ToString();
              txtSlot8Stitch.Text = dt.Rows[0]["Slot8Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot8Stitch"].ToString();
              txtSlot9Stitch.Text = dt.Rows[0]["Slot9Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot9Stitch"].ToString();
              txtSlot10Stitch.Text = dt.Rows[0]["Slot10Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot10Stitch"].ToString();
              txtSlot11Stitch.Text = dt.Rows[0]["Slot11Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot11Stitch"].ToString();
              txtSlot12Stitch.Text = dt.Rows[0]["Slot12Stitch"].ToString() == "0" ? "" : dt.Rows[0]["Slot12Stitch"].ToString();

              txtSlot1Stitch.Enabled = txtSlot1Stitch.Text == "" ? false : true;
              txtSlot2Stitch.Enabled = txtSlot2Stitch.Text == "" ? false : true;
              txtSlot3Stitch.Enabled = txtSlot3Stitch.Text == "" ? false : true;
              txtSlot4Stitch.Enabled = txtSlot4Stitch.Text == "" ? false : true;
              txtSlot5Stitch.Enabled = txtSlot5Stitch.Text == "" ? false : true;
              txtSlot6Stitch.Enabled = txtSlot6Stitch.Text == "" ? false : true;
              txtSlot7Stitch.Enabled = txtSlot7Stitch.Text == "" ? false : true;
              txtSlot8Stitch.Enabled = txtSlot8Stitch.Text == "" ? false : true;
              txtSlot9Stitch.Enabled = txtSlot9Stitch.Text == "" ? false : true;
              txtSlot10Stitch.Enabled = txtSlot10Stitch.Text == "" ? false : true;
              txtSlot11Stitch.Enabled = txtSlot11Stitch.Text == "" ? false : true;
              txtSlot12Stitch.Enabled = txtSlot12Stitch.Text == "" ? false : true;

              chkSlot1check.Enabled = txtSlot1Stitch.Text == "" ? false : true;
              chkSlot2check.Enabled = txtSlot2Stitch.Text == "" ? false : true;
              chkSlot3check.Enabled = txtSlot3Stitch.Text == "" ? false : true;
              chkSlot4check.Enabled = txtSlot4Stitch.Text == "" ? false : true;
              chkSlot5check.Enabled = txtSlot5Stitch.Text == "" ? false : true;
              chkSlot6check.Enabled = txtSlot6Stitch.Text == "" ? false : true;
              chkSlot7check.Enabled = txtSlot7Stitch.Text == "" ? false : true;
              chkSlot8check.Enabled = txtSlot8Stitch.Text == "" ? false : true;
              chkSlot9check.Enabled = txtSlot9Stitch.Text == "" ? false : true;
              chkSlot10check.Enabled = txtSlot10Stitch.Text == "" ? false : true;
              chkSlot11check.Enabled = txtSlot11Stitch.Text == "" ? false : true;
              chkSlot12check.Enabled = txtSlot12Stitch.Text == "" ? false : true;


              txtSlot1Finish.Text = dt.Rows[0]["Slot1Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot1Finish"].ToString();
              txtSlot2Finish.Text = dt.Rows[0]["Slot2Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot2Finish"].ToString();
              txtSlot3Finish.Text = dt.Rows[0]["Slot3Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot3Finish"].ToString();
              txtSlot4Finish.Text = dt.Rows[0]["Slot4Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot4Finish"].ToString();
              txtSlot5Finish.Text = dt.Rows[0]["Slot5Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot5Finish"].ToString();
              txtSlot6Finish.Text = dt.Rows[0]["Slot6Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot6Finish"].ToString();
              txtSlot7Finish.Text = dt.Rows[0]["Slot7Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot7Finish"].ToString();
              txtSlot8Finish.Text = dt.Rows[0]["Slot8Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot8Finish"].ToString();
              txtSlot9Finish.Text = dt.Rows[0]["Slot9Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot9Finish"].ToString();
              txtSlot10Finish.Text = dt.Rows[0]["Slot10Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot10Finish"].ToString();
              txtSlot11Finish.Text = dt.Rows[0]["Slot11Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot11Finish"].ToString();
              txtSlot12Finish.Text = dt.Rows[0]["Slot12Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot12Finish"].ToString();

              txtSlot1Finish.Enabled = txtSlot1Finish.Text == "" ? false : true;
              txtSlot2Finish.Enabled = txtSlot2Finish.Text == "" ? false : true;
              txtSlot3Finish.Enabled = txtSlot3Finish.Text == "" ? false : true;
              txtSlot4Finish.Enabled = txtSlot4Finish.Text == "" ? false : true;
              txtSlot5Finish.Enabled = txtSlot5Finish.Text == "" ? false : true;
              txtSlot6Finish.Enabled = txtSlot6Finish.Text == "" ? false : true;
              txtSlot7Finish.Enabled = txtSlot7Finish.Text == "" ? false : true;
              txtSlot8Finish.Enabled = txtSlot8Finish.Text == "" ? false : true;
              txtSlot9Finish.Enabled = txtSlot9Finish.Text == "" ? false : true;
              txtSlot10Finish.Enabled = txtSlot10Finish.Text == "" ? false : true;
              txtSlot11Finish.Enabled = txtSlot11Finish.Text == "" ? false : true;
              txtSlot12Finish.Enabled = txtSlot12Finish.Text == "" ? false : true;

          }
      }
      else
      {
          lblHeader.Text = "Cluster Entry";
          lblLineHeader.Text = "Cluster Name";
          lblDate.Text = SlotCreateDate.ToString("dd-MMM");
          lblLineNo.Text = dt.Rows[0]["LineNo"].ToString();
          lblserial.Text = dt.Rows[0]["SerialNumber"].ToString();
          lblColor.Text = dt.Rows[0]["FabricDetail"].ToString();
          lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
          lblExFactory.Text = dt.Rows[0]["ExFactory"].ToString();

          txtSlot1Finish.Text = dt.Rows[0]["Slot1Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot1Finish"].ToString();
          txtSlot2Finish.Text = dt.Rows[0]["Slot2Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot2Finish"].ToString();
          txtSlot3Finish.Text = dt.Rows[0]["Slot3Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot3Finish"].ToString();
          txtSlot4Finish.Text = dt.Rows[0]["Slot4Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot4Finish"].ToString();
          txtSlot5Finish.Text = dt.Rows[0]["Slot5Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot5Finish"].ToString();
          txtSlot6Finish.Text = dt.Rows[0]["Slot6Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot6Finish"].ToString();
          txtSlot7Finish.Text = dt.Rows[0]["Slot7Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot7Finish"].ToString();
          txtSlot8Finish.Text = dt.Rows[0]["Slot8Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot8Finish"].ToString();
          txtSlot9Finish.Text = dt.Rows[0]["Slot9Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot9Finish"].ToString();
          txtSlot10Finish.Text = dt.Rows[0]["Slot10Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot10Finish"].ToString();
          txtSlot11Finish.Text = dt.Rows[0]["Slot11Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot11Finish"].ToString();
          txtSlot12Finish.Text = dt.Rows[0]["Slot12Finish"].ToString() == "0" ? "" : dt.Rows[0]["Slot12Finish"].ToString();

          txtSlot1Finish.Enabled = txtSlot1Finish.Text == "" ? false : true;
          txtSlot2Finish.Enabled = txtSlot2Finish.Text == "" ? false : true;
          txtSlot3Finish.Enabled = txtSlot3Finish.Text == "" ? false : true;
          txtSlot4Finish.Enabled = txtSlot4Finish.Text == "" ? false : true;
          txtSlot5Finish.Enabled = txtSlot5Finish.Text == "" ? false : true;
          txtSlot6Finish.Enabled = txtSlot6Finish.Text == "" ? false : true;
          txtSlot7Finish.Enabled = txtSlot7Finish.Text == "" ? false : true;
          txtSlot8Finish.Enabled = txtSlot8Finish.Text == "" ? false : true;
          txtSlot9Finish.Enabled = txtSlot9Finish.Text == "" ? false : true;
          txtSlot10Finish.Enabled = txtSlot10Finish.Text == "" ? false : true;
          txtSlot11Finish.Enabled = txtSlot11Finish.Text == "" ? false : true;
          txtSlot12Finish.Enabled = txtSlot12Finish.Text == "" ? false : true;
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        StitchingDetail objStitchingDetail = new StitchingDetail();
        objStitchingDetail.LinePlanningID = LinePlanningID;
        objStitchingDetail.OrderDetailID = OrderDetailsID;
        objStitchingDetail.ProductionUnitId = UnitId;
        objStitchingDetail.ClusterID = ClusterId;
        objStitchingDetail.SlotCreateDate = SlotCreateDate;

        objStitchingDetail.Slot1Stitch = txtSlot1Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot1Stitch.Text);
        objStitchingDetail.Slot2Stitch = txtSlot2Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot2Stitch.Text);
        objStitchingDetail.Slot3Stitch = txtSlot3Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot3Stitch.Text);
        objStitchingDetail.Slot4Stitch = txtSlot4Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot4Stitch.Text);
        objStitchingDetail.Slot5Stitch = txtSlot5Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot5Stitch.Text);
        objStitchingDetail.Slot6Stitch = txtSlot6Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot6Stitch.Text);
        objStitchingDetail.Slot7Stitch = txtSlot7Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot7Stitch.Text);
        objStitchingDetail.Slot8Stitch = txtSlot8Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot8Stitch.Text);
        objStitchingDetail.Slot9Stitch = txtSlot9Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot9Stitch.Text);
        objStitchingDetail.Slot10Stitch = txtSlot10Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot10Stitch.Text);
        objStitchingDetail.Slot11Stitch = txtSlot11Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot11Stitch.Text);
        objStitchingDetail.Slot12Stitch = txtSlot12Stitch.Text == "" ? -1 : Convert.ToInt32(txtSlot12Stitch.Text);

        objStitchingDetail.Slot1Finish = txtSlot1Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot1Finish.Text);
        objStitchingDetail.Slot2Finish = txtSlot2Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot2Finish.Text);
        objStitchingDetail.Slot3Finish = txtSlot3Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot3Finish.Text);
        objStitchingDetail.Slot4Finish = txtSlot4Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot4Finish.Text);
        objStitchingDetail.Slot5Finish = txtSlot5Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot5Finish.Text);
        objStitchingDetail.Slot6Finish = txtSlot6Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot6Finish.Text);
        objStitchingDetail.Slot7Finish = txtSlot7Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot7Finish.Text);
        objStitchingDetail.Slot8Finish = txtSlot8Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot8Finish.Text);
        objStitchingDetail.Slot9Finish = txtSlot9Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot9Finish.Text);
        objStitchingDetail.Slot10Finish = txtSlot10Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot10Finish.Text);
        objStitchingDetail.Slot11Finish = txtSlot11Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot11Finish.Text);
        objStitchingDetail.Slot12Finish = txtSlot12Finish.Text == "" ? -1 : Convert.ToInt32(txtSlot12Finish.Text);

        objStitchingDetail.Slot1ZeroProductivity = chkSlot1check.Checked;
        objStitchingDetail.Slot2ZeroProductivity = chkSlot2check.Checked;
        objStitchingDetail.Slot3ZeroProductivity = chkSlot3check.Checked;
        objStitchingDetail.Slot4ZeroProductivity = chkSlot4check.Checked;
        objStitchingDetail.Slot5ZeroProductivity = chkSlot5check.Checked;
        objStitchingDetail.Slot6ZeroProductivity = chkSlot6check.Checked;
        objStitchingDetail.Slot7ZeroProductivity = chkSlot7check.Checked;
        objStitchingDetail.Slot8ZeroProductivity = chkSlot8check.Checked;
        objStitchingDetail.Slot9ZeroProductivity = chkSlot9check.Checked;
        objStitchingDetail.Slot10ZeroProductivity = chkSlot10check.Checked;
        objStitchingDetail.Slot11ZeroProductivity = chkSlot11check.Checked;
        objStitchingDetail.Slot12ZeroProductivity = chkSlot12check.Checked;

        int UserId = ApplicationHelper.LoggedInUser.UserData.UserID; 

        int iSave = objProductionController.UpdateSlotWiseEntryDetailsByDate(objStitchingDetail, UserId);
        if (iSave > 0)
        {
            ShowAlert("Record saved successfully.");
            BindData();
        }
        
    }

    public void ShowAlert(string stringAlertMsg)
    {
        string myStringVariable = string.Empty;
        myStringVariable = stringAlertMsg;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }
    
   
  }
}