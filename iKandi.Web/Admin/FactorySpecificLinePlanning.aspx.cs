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

namespace iKandi.Web.Admin
{
    public partial class FactorySpecificLinePlanning : System.Web.UI.Page
    {
        AdminController oAdminController = new AdminController();
        StringBuilder htmlTable = new StringBuilder();

        int UserId = 0;
        int UnitId = 0;
        bool DoTaskClose = false;
        public bool CheckAllUnit = false;

         Boolean Inhouse = false;         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            UnitId = Convert.ToInt32(Request.QueryString["ProductionUnit"]);
            if (!IsPostBack)
            {
                FillFactory();
                //ddlFactory.SelectedValue = UnitId > 0 ? UnitId.ToString() : "-1";
                if (UnitId > 0)
                {
                  ddlFactory.SelectedValue = UnitId.ToString();
                }
                else
                {
                  ddlFactory.SelectedValue = "-1"; 
                }

                ddlFactory.Enabled = UnitId > 0 && Convert.ToString(Request.QueryString["Enabled"]) == "false" ? false : true;

                UnitId = UnitId > 0 ? UnitId : 0;

                FillFactorySpecificLinePlanning();
            }
        }

        private void FillFactory()
        {
            ddlFactory.DataSource = oAdminController.GetFactorynames(UnitId, "");
            ddlFactory.DataValueField = "id";
            ddlFactory.DataTextField = "Name";
            ddlFactory.DataBind();

        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitId = Convert.ToInt32(ddlFactory.SelectedValue);
            //UnitId = UnitId > 0 ? UnitId : 0;
            UnitId = UnitId > 0 ? UnitId : Convert.ToInt32(ddlFactory.SelectedValue.ToString() == "-1" ? "0" : ddlFactory.SelectedValue.ToString());
            FillFactorySpecificLinePlanning();

        }

        private void FillFactorySpecificLinePlanning()
        {
            DataTable dtFactorySpecificLinePlanning = oAdminController.GetFactorySpecificLinePlanningDetails(UnitId);
            if (dtFactorySpecificLinePlanning.Rows.Count > 0)
            {
                gvFactorySpecificLinePlanning.DataSource = dtFactorySpecificLinePlanning;
                gvFactorySpecificLinePlanning.DataBind();
                lblMessage.Text = "";

                if (DoTaskClose == false)
                {
                    oAdminController.CloseTask(UnitId, UserId);
                }
            }
            else
            {
                gvFactorySpecificLinePlanning.DataSource = null;
                gvFactorySpecificLinePlanning.DataBind();
                lblMessage.Text = "Records are not Found!!";
            }
        }

        protected void gvFactorySpecificLinePlanning_DataBound(object sender, EventArgs e)
        {
            for (int i = gvFactorySpecificLinePlanning.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvFactorySpecificLinePlanning.Rows[i];
                GridViewRow previousRow = gvFactorySpecificLinePlanning.Rows[i - 1];

                Label lblFactory = (Label)row.FindControl("lblFactory");
                Label lblPreviousFactory = (Label)previousRow.FindControl("lblFactory");

                if (lblFactory.Text == lblPreviousFactory.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }

                Label lblFloor = (Label)row.FindControl("lblFloor");
                Label lblPreviousFloor = (Label)previousRow.FindControl("lblFloor");

                if (lblFloor.Text == lblPreviousFloor.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                        }
                        row.Cells[1].Visible = false;
                    }
                }
            }
        }

        protected void gvFactorySpecificLinePlanning_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell Cell = new TableCell();
                Cell.Text = "Line Description";
                Cell.HorizontalAlign = HorizontalAlign.Center;
                Cell.CssClass = "header-class";
                //Cell.Font.Bold = true;
                // Cell.ColumnSpan = 3;
                // Cell.Font.Size = 12;
                gvrow.Cells.Add(Cell);

                //Cell = new TableCell();
                //Cell.Text = "Designation";
                //Cell.ColumnSpan = 1;
                //Cell.RowSpan = 2;
                //Cell.HorizontalAlign = HorizontalAlign.Center;
                //Cell.Font.Bold = true;
                //Cell.Font.Size = 12;
                //gvrow.Cells.Add(Cell);

                Cell = new TableCell();
                Cell.HorizontalAlign = HorizontalAlign.Left;
                Cell.CssClass = "header-class";
                Cell.Text = "<table border='0' cellpadding='0' cellspacing='0' style='width:650px; text-align: left;'>";
                Cell.Text += "<tr><td align='left' style='padding-left:225px;'>Contract Style Detail</td></tr></table>";
                //Cell.ColumnSpan = 1;
                // Cell.RowSpan = 2;
                // Cell.Font.Bold = true;
                // Cell.Font.Size = 12;
                gvrow.Cells.Add(Cell);

                gvFactorySpecificLinePlanning.Controls[0].Controls.AddAt(0, gvrow);
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
        }

        //DateTime EndDate = DateTime.Now;
        protected void gvFactorySpecificLinePlanning_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String FactoryID = DataBinder.Eval(e.Row.DataItem, "UnitID").ToString();
                Label lblFactory = (Label)e.Row.FindControl("lblFactory");
                Label lblLine = (Label)e.Row.FindControl("lblLine");
                HtmlGenericControl dman = (HtmlGenericControl)e.Row.FindControl("dman");
                if (!string.IsNullOrEmpty(FactoryID))
                {
                    Inhouse = oAdminController.getProdctionIDInhouse(FactoryID);
                }

                //if (FactoryID == "3" || FactoryID == "11")//abhishek
                if(Inhouse == true)
                {
                  lblLine.Text = "Line " + DataBinder.Eval(e.Row.DataItem, "[LineNo]").ToString();

                  GridView gvDesignation = (GridView)e.Row.FindControl("gvDesignation");

                  
                  
                  gvDesignation.SelectedIndexChanged += new EventHandler(ddlDesignation_SelectedIndexChanged);
                  PlaceHolder DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder");

                  DataTable dtDesignation = oAdminController.GetDesignationDetails(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[LineNo]")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID")));
                  gvDesignation.DataSource = dtDesignation;
                  gvDesignation.DataBind();

                  DataTable dt = oAdminController.GetContractStyleDetail(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[LineNo]")));
                  //dt.Rows.Clear();
                  if (dt.Rows.Count > 0)
                  {
                    htmlTable.Append("<table border='1' cellpadding='0' cellspacing='0' align='left' style='border-collapse: collapse;'>");
                    htmlTable.Append("<tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                      DataTable dtSamOBDiff = oAdminController.GetSamOBDiff(dt.Rows[i]["StyleCode"].ToString(), Convert.ToInt32(dt.Rows[i]["StyleId"]), Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]), Convert.ToInt16(dt.Rows[i]["IsHalfStich"]));
                      string FrameType = dt.Rows[i]["IsParallel"].ToString() == "True" ? "Par Fr." : "Seq Fr.";
                      string FrameTypeToolTip = "";
                      if (FrameType == "Par Fr.")
                        FrameTypeToolTip = dt.Rows[i]["SeqFrameId"].ToString() == "" ? "" : "Parallel Frame No. " + dt.Rows[i]["SeqFrameId"].ToString();

                      if (FrameType == "Seq Fr.")
                        FrameTypeToolTip = dt.Rows[i]["SeqFrameId"].ToString() == "" ? "" : "Sequence Frame No. " + dt.Rows[i]["SeqFrameId"].ToString();

                      htmlTable.Append("<td valign='top'>");
                      htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' style='width:545px'>");
                      htmlTable.Append("<tr>");
                      htmlTable.Append("<td align='left' valign='top' style='padding-top:7px; padding-bottom:10px;padding-left:5px; width:225px; color:#7E7E7E; font-size:10px; font-weight:bold; text-transform: none; font-family: Lucida Sans Unicode;'>");
                      if (Convert.ToInt16(dt.Rows[i]["IsStitching"]) == 0)
                      {
                          if ((ApplicationHelper.LoggedInUser.UserData.DesignationID == 46) || (ApplicationHelper.LoggedInUser.UserData.DesignationID == 19) || (ApplicationHelper.LoggedInUser.UserData.DesignationID == 158))
                            htmlTable.Append("<img onclick='return DeleteFrame(" + dt.Rows[i]["LinePlanFrameId"].ToString() + ");' src='../images/delete-icon.png' title='Delete Frame' style='height:14px'/>&nbsp;<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a style='color:#118af9;text-decoration:none;' title='Edit Frame' rel='shadowbox' width='1000' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;'>S. C.&nbsp;</span><span style='color:#000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                        else
                            htmlTable.Append("<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a style='color:#118af9; text-decoration:none;' rel='shadowbox' width='1000' title='Edit Frame' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;' title='Style Code'>S.C.</span><span style='color:#000000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                      }
                      else
                      {
                          htmlTable.Append("<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a rel='shadowbox' title='Edit Frame' width='1000' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);' style='color:#118af9;text-decoration:none;'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;' title='Style Code'>S. C.&nbsp;</span><span style='color:#000000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                      }
                      // htmlTable.Append("&nbsp;&nbsp;&nbsp;<a rel='shadowbox' width='800' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'><img src='../images/edit.png' height='15px' alt='' /></a>");

                      htmlTable.Append("</td>");
                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; font-size:10px; text-transform: none; font-family: Lucida Sans Unicode;'>");
                      //===========SAM Value========================
                      if (Convert.ToDecimal(dt.Rows[i]["Sam"]) > 0)
                      {
                        if (Convert.ToInt16(dtSamOBDiff.Rows[0]["IsSamDiff"]) == 1)
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>SAM:</span><span style='color:#FF0000;'>" + Math.Round(Convert.ToDouble(dt.Rows[i]["Sam"]), 1).ToString() + "</span>");
                        }
                        else
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>SAM:</span><span style='color:#405D99;'>" + Math.Round(Convert.ToDouble(dt.Rows[i]["Sam"]), 1).ToString() + "</span>");
                        }
                      }
                      htmlTable.Append("</td>");
                      //=========OB=============
                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:45px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (Convert.ToInt32(dt.Rows[i]["NewOB"]) > 0)
                        htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#405D99;'>" + dt.Rows[i]["NewOB"].ToString() + "</span>");
                      else
                      {
                        if (Convert.ToInt16(dtSamOBDiff.Rows[0]["IsObDiff"]) == 1)
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#FF0000;'>" + dt.Rows[i]["OB"].ToString() + "</span>");
                        }
                        else
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#405D99;'>" + dt.Rows[i]["OB"].ToString() + "</span>");
                        }
                      }

                      htmlTable.Append("</td>");
                      //  lblSTCTargetDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")).ToString("dd MMM (ddd)");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:85px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (dt.Rows[i]["StartDate"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;' title='Start Date'>St:</span><span style='color:#405D99;'>" + Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("dd MMM (ddd)") + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode; display:none;'>");
                      if (dt.Rows[i]["StartSlot"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;'>Slot:&nbsp;</span><span style='color:#405D99;'>" + dt.Rows[i]["StartSlot"].ToString() + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:90px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (dt.Rows[i]["EndDate"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;' title='End Date'>End:</span><span style='color:#405D99;'>" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("dd MMM (ddd)") + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode; display:none;'>");
                      if (dt.Rows[i]["EndSlot"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;'>Slot:&nbsp;</span><span style='color:#405D99;'>" + dt.Rows[i]["EndSlot"].ToString() + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:40px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");

                      if (Convert.ToBoolean(dt.Rows[i]["IsHalfStich"]) == true)
                      {
                        htmlTable.Append("<a rel='shadowbox;width=680;height=700;' href='/Admin/UpdateHalfStitch.aspx?StyleId=" + Convert.ToInt32(dt.Rows[i]["StyleId"]) + "&LinePlanFrameId=" + Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]) + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenHalfStitchShadowbox(this);'><input id='chkHalfStitch' type='checkbox' checked='checked' style='padding:0px; margin:0px; vertical-align:bottom;' /></a><span style='color:#7E7E7E;' title='Half Stitch'>H St.</span>");
                      }
                      else
                      {
                        if (Convert.ToInt32(dt.Rows[i]["StyleCount"]) == 1 && Convert.ToInt32(dt.Rows[i]["IsStitching"]) == 0)
                        {
                          htmlTable.Append("<a rel='shadowbox;width=680;height=700;' href='/Admin/UpdateHalfStitch.aspx?StyleId=" + Convert.ToInt32(dt.Rows[i]["StyleId"]) + "&LinePlanFrameId=" + Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]) + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenHalfStitchShadowbox(this);'><input id='chkHalfStitch' type='checkbox' style='padding:0px; margin:0px; vertical-align:bottom;' /></a><span style='color:#7E7E7E;' title='Half Stitch'>H St.</span>");
                        }
                      }

                      htmlTable.Append("</td>");

                      htmlTable.Append("</tr>");

                      htmlTable.Append("<tr>");
                      htmlTable.Append("<td colspan='6' align='left' valign='top' style='padding-left:5px; padding-right:5px; padding-bottom:2px'>");
                      htmlTable.Append("<div style='float:right;' class='show-hide'><img src='../images/plus-w.png'  style='width: 12px;' class='Show-block' /><img src='../images/minus.png' class='hide-block' style='display:none;width: 15px;' /></div><table border='1' cellpadding='0' cellspacing='0'  align='left' style='border-collapse: collapse;table-layout:fixed; width:511px;'>");
                      htmlTable.Append("<tr>");
                      // htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:107px'>Style No.</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Serial No.</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Contract No.</td>");
                      htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:127px' class='border-bottom' title='Contract No.'>Cntr No.</td>");
                      htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:87px' class='border-bottom' title='Ex Factory Date'>Ex</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:83px' title='Contract Quantity'>Cntr Qty</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:67px; display:none;'>Unit Qty</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:68px'>Line Qty</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:80px' title='Stitched Quantity'>St. Qty</td>");
                      //  htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:82px'>% Stitched</td>");
                      htmlTable.Append("</tr><tr>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px' class='border-bottom'>Style No.</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Cntr No.</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:83px' class='border-bottom' title='Line Quantity'>Line Qty</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:80px' class='border-bottom' title='Stitched Percent'>%</td>");

                      htmlTable.Append("</tr></table><div class='table-wrap' style='display:none;'><table border='1' cellpadding='0' cellspacing='0'  align='left' style='border-collapse: collapse; table-layout:fixed; width:511px;'>");

                      // Comment by Ravi kumar on 3-8-17           
                      DataTable dtGrid = oAdminController.GetContractStyleDetail_LinePlan(Convert.ToInt32(dt.Rows[i]["UnitID"]), Convert.ToInt32(dt.Rows[i]["LineNo"]), dt.Rows[i]["StyleCode"].ToString(), Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]));

                      Decimal TotalContractQty = 0, TotalUnitQty = 0, TotalLineQty = 0, TotalStichedQty = 0;

                      for (int j = 0; j < dtGrid.Rows.Count; j++)
                      {
                        htmlTable.Append("<tr>");
                        string ContractNo = dtGrid.Rows[j]["ContractNumber"].ToString();
                        // char[] MyChar = { '/', '-', ','};
                        //string NewContractNo = ContractNo.Trim(new Char[] { '/', '-'});
                        string NewContractNo = ContractNo.Replace('/', ' ').Replace('-', ' ');
                        // htmlTable.Append("<td rowspan='2' style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:107px'>" + dtGrid.Rows[j]["StyleNumber"].ToString() + "</td>");
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:103px'><img src='/uploads/style/thumb-" + dtGrid.Rows[j]["StyleImgPath"].ToString() + "' style='height:20px; width:20px; float:left' /><span style=' font-weight:bold; color:black;'>" + dtGrid.Rows[j]["SerialNumber"].ToString() + "</span></td>");
                        htmlTable.Append("<td rowspan='2' style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:127px'>" + NewContractNo + "</td>");
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:87px' rowspan='2'><span style='color:black; font-weight:bold;'>" + Convert.ToDateTime(dtGrid.Rows[j]["ExFactory"]).ToString("dd MMM (ddd)") + "</span></td>");



                        string strUnitQty = dtGrid.Rows[j]["UnitQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["UnitQty"]).ToString("#,##0");




                        string strContractQty = dtGrid.Rows[j]["ContractQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["ContractQty"]).ToString("#,##0");

                        if (strContractQty != "" && Convert.ToDecimal(strContractQty) > 999)
                        {
                          string strContractQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["ContractQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strContractQtyNew) < 100)
                          {
                            strContractQtyNew = Math.Round(Convert.ToDecimal(strContractQtyNew), 1).ToString();
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQtyNew + " k</span></td>");
                          }
                          else
                          {
                            strContractQtyNew = Math.Round(Convert.ToDecimal(strContractQtyNew), 0).ToString();
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQtyNew + " k</span></td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQty + "</span></td>");
                        }


                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:80px; display:none;'>" + strUnitQty + "</td>");

                        string strStitchQty = dtGrid.Rows[j]["StichedQty"].ToString() == "0" ? "" : Convert.ToInt32(dtGrid.Rows[j]["StichedQty"]).ToString("#,##0");
                        if (strStitchQty != "" && Convert.ToDecimal(strStitchQty) > 999)
                        {
                          string strStitchQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strStitchQtyNew) < 100)
                          {
                            strStitchQtyNew = Math.Round(Convert.ToDecimal(strStitchQtyNew), 1).ToString();
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQtyNew + "k</span></td>");
                          }
                          else
                          {
                            strStitchQtyNew = Math.Round(Convert.ToDecimal(strStitchQtyNew), 0).ToString();
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQtyNew + "k</span></td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQty + "</span></td>");
                        }





                        htmlTable.Append("</tr><tr>");

                        string strStitchPercent = "";
                        if (Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]) > 0)
                        {
                          strStitchPercent = Convert.ToInt32(((Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / Convert.ToDecimal(dtGrid.Rows[j]["LineQty"])) * 100)) == 0 ? "" : Convert.ToInt32(((Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / Convert.ToDecimal(dtGrid.Rows[j]["LineQty"])) * 100)).ToString() + "%";
                        }

                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:83px'>" + dtGrid.Rows[j]["StyleNumber"].ToString() + "</td>");
                        // htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:103px'>" + dtGrid.Rows[j]["ContractNumber"].ToString() + "</td>");


                        string strLineQty = dtGrid.Rows[j]["LineQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["LineQty"]).ToString("#,##0");
                        if (strLineQty != "" && Convert.ToDecimal(strLineQty) > 999)
                        {
                          string strLineQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strLineQtyNew) < 100)
                          {
                            strLineQtyNew = Math.Round(Convert.ToDecimal(strLineQtyNew), 1).ToString();
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQtyNew + "k</td>");
                          }
                          else
                          {
                            strLineQtyNew = Math.Round(Convert.ToDecimal(strLineQtyNew), 0).ToString();
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQtyNew + "k</td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQty + "</td>");
                        }


                        htmlTable.Append("<td style=' text-align:center; width:80px'><span style='color:blue; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchPercent + "</span></td>");
                        htmlTable.Append("</tr>");
                        TotalContractQty = TotalContractQty + Convert.ToDecimal(dtGrid.Rows[j]["ContractQty"]);
                        TotalUnitQty = TotalUnitQty + Convert.ToDecimal(dtGrid.Rows[j]["UnitQty"]);
                        TotalLineQty = TotalLineQty + Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]);
                        TotalStichedQty = TotalStichedQty + Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]);
                      }
                      string strTotalStitchedQty = TotalStichedQty == 0 ? "" : TotalStichedQty.ToString("#,##0");
                      htmlTable.Append(" </table></div> <table border='1' cellpadding='0' cellspacing='0' align='left' style='border-collapse: collapse; table-layout:fixed; width:511px;' class='border-top1'><tr>");
                      htmlTable.Append("<td colspan='2' rowspan='2' style='width:231px;text-align:center'><span style='color:#7e7e7e; font-size: 11px; text-transform: none; font-weight:bold; font-faimly:Lucida Sans Unicode;'>Total</span></td>");
                      htmlTable.Append("<td style='width:87px' rowspan='2'></td>");
                      //htmlTable.Append("<td style='width:127px'></td>");
                      if (TotalContractQty != 0)
                      {
                        if (TotalContractQty > 999)
                        {
                          Decimal TotalContractQtyNew = Math.Round(TotalContractQty / 1000, 1);
                          if (TotalContractQtyNew < 100)
                          {
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQtyNew.ToString() + "k</span></td>");
                          }
                          else
                          {
                            TotalContractQtyNew = Math.Round(TotalContractQtyNew, 0);
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQtyNew.ToString() + "k</span></td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQty.ToString("#,##0") + "</span></td>");
                        }
                      }
                      else
                      {
                        htmlTable.Append("<td style=' font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px'> &nbsp; </td>");
                      }

                      // htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:103px'>" + TotalContractQty.ToString("#,##0") + "</td>");

                      htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:67px; display:none;'>" + TotalUnitQty.ToString("#,##0") + "</td>");

                      if (TotalStichedQty != 0)
                      {
                        if (TotalStichedQty > 999)
                        {
                          Decimal TotalStichedQtyNew = Math.Round(TotalStichedQty / 1000, 1);
                          if (TotalStichedQtyNew < 100)
                          {
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQtyNew.ToString() + " k</span></td>");
                          }
                          else
                          {
                            TotalStichedQtyNew = Math.Round(TotalStichedQtyNew, 0);
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQtyNew.ToString() + " k</td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQty.ToString("#,##0") + "</td>");
                        }

                      }
                      else
                      {
                        htmlTable.Append("<td style='font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:80px'> &nbsp; </td>");
                      }

                      htmlTable.Append("</tr><tr>");

                      if (TotalLineQty != 0)
                      {
                        if (TotalLineQty > 999)
                        {
                          Decimal TotalLineQtyNew = Math.Round(TotalLineQty / 1000, 1);
                          if (TotalLineQtyNew < 100)
                          {

                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQtyNew.ToString() + "k</td>");
                          }
                          else
                          {
                            TotalLineQtyNew = Math.Round(TotalLineQtyNew, 0);
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQtyNew.ToString() + "k</td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQty.ToString("#,##0") + "</td>");
                        }
                      }
                      else
                      {
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px'>&nbsp;</td>");
                      }


                      if (TotalUnitQty > 0)
                      {
                        string strTotalStitchedPer = "";
                        if (Convert.ToDecimal(TotalLineQty) > 0)
                        {
                          strTotalStitchedPer = Convert.ToInt32(((Convert.ToDecimal(TotalStichedQty) / Convert.ToDecimal(TotalLineQty)) * 100)) == 0 ? "" : Convert.ToInt32(((Convert.ToDecimal(TotalStichedQty) / Convert.ToDecimal(TotalLineQty)) * 100)).ToString() + "%";
                        }
                        htmlTable.Append("<td style='text-align:center; width:80px'><span style='color:blue; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + strTotalStitchedPer + "</span></td>");
                      }
                      else
                      {
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:80px'></td>");
                      }
                      htmlTable.Append("</tr>");
                      htmlTable.Append("</table>");
                      htmlTable.Append("</td>");
                      htmlTable.Append("</tr>");

                      //  htmlTable.Append("<tr>");
                      // htmlTable.Append("<td colspan='4' align='left' style='padding-top:10px; padding-bottom:1px;padding-left:5px; width:520px; color:#405D99; font-size:11px; font-weight:bold; text-transform: none; font-family: Lucida Sans Unicode;'>");

                      //  htmlTable.Append("</td>");
                      //  htmlTable.Append("</tr>");


                      htmlTable.Append("</table>");
                      htmlTable.Append("</td>");

                      if (Convert.ToBoolean(dt.Rows[i]["IsLineVacant"]) == true)
                      {
                        e.Row.BackColor = System.Drawing.Color.FromName("#FdFBBE");
                        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                        e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                      }
                    }
                    htmlTable.Append("</tr>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    htmlTable.Length = 0;
                  }
                  else
                  {
                    e.Row.BackColor = System.Drawing.Color.FromName("#FdFBBE");
                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                    e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                  }   
                  
                }
                else
                {
                    // OUT HOUSE WORK STARTED

                  dman.Visible = false;
                  lblLine.Text = "" + DataBinder.Eval(e.Row.DataItem, "[LineNo]").ToString();
                  lblFactory.Text = "Out House";
                 
                  lblLine.Style.Add("float", "left");
                  lblLine.Style.Add("font-size", "9px");
                  GridView gvDesignation = (GridView)e.Row.FindControl("gvDesignation");

                  gvDesignation.SelectedIndexChanged += new EventHandler(ddlDesignation_SelectedIndexChanged);
                  PlaceHolder DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder");

                                  
                  DataTable dt = oAdminController.GetContractStyleDetail_outshoue(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID")));

                  //DataView dv = dt.DefaultView;
                  //dv.Sort = "SeqFrameId asc";
                  //dt = dv.ToTable();
                
                  if (dt.Rows.Count > 0)
                  {
                    htmlTable.Append("<table border='1' cellpadding='0' cellspacing='0' align='left' style='border-collapse: collapse;'>");
                    htmlTable.Append("<tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                      DataTable dtSamOBDiff = oAdminController.GetSamOBDiff(dt.Rows[i]["StyleCode"].ToString(), Convert.ToInt32(dt.Rows[i]["StyleId"]), Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]), Convert.ToInt16(dt.Rows[i]["IsHalfStich"]));
                      string FrameType = dt.Rows[i]["IsParallel"].ToString() == "True" ? "Par Fr." : "Seq Fr.";
                      string FrameTypeToolTip = "";
                      if (FrameType == "Par Fr.")
                        FrameTypeToolTip = dt.Rows[i]["SeqFrameId"].ToString() == "" ? "" : "Parallel Frame No. " + dt.Rows[i]["SeqFrameId"].ToString();

                      if (FrameType == "Seq Fr.")
                        FrameTypeToolTip = dt.Rows[i]["SeqFrameId"].ToString() == "" ? "" : "Sequence Frame No. " + dt.Rows[i]["SeqFrameId"].ToString();

                      htmlTable.Append("<td valign='top'>");
                      htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' width='545px'>");
                      htmlTable.Append("<tr>");
                      htmlTable.Append("<td align='left' valign='top' style='padding-top:7px; padding-bottom:10px;padding-left:5px; width:225px; color:#7E7E7E; font-size:10px; font-weight:bold; text-transform: none; font-family: Lucida Sans Unicode;'>");
                      if (Convert.ToInt16(dt.Rows[i]["IsStitching"]) == 0)
                      {
                        if ((ApplicationHelper.LoggedInUser.UserData.DesignationID == 46) || (ApplicationHelper.LoggedInUser.UserData.DesignationID == 19))
                            htmlTable.Append("<img onclick='return DeleteFrame(" + dt.Rows[i]["LinePlanFrameId"].ToString() + ");' src='../images/delete-icon.png' title='Delete Frame' style='height:14px;'/>&nbsp;<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a style='color:#118af9;text-decoration:none;' title='Edit Frame' rel='shadowbox' width='1000' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;'>S. C.&nbsp;</span><span style='color:#000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                        else
                            htmlTable.Append("<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a style='color:#118af9; text-decoration:none;' rel='shadowbox' width='1000' title='Edit Frame' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;' title='Style Code'>S.C.</span><span style='color:#000000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                      }
                      else
                      {
                          htmlTable.Append("<span title='" + FrameTypeToolTip + "' style='font-weight:bold;'>" + FrameType + "</span><span style='color:#118af9; text-transform:uppercase;'><a rel='shadowbox' title='Edit Frame' width='1000' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);' style='color:#118af9;text-decoration:none;'>" + dt.Rows[i]["LinePlanFrameId"].ToString() + "</a></span> &nbsp;&nbsp;<a href='#' class='preview' title='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "'><img src='/uploads/style/thumb-" + dt.Rows[i]["StyleImgPathTop"].ToString() + "' style='height:20px; width:20px;' /></a><span style='font-weight:bold;' title='Style Code'>S. C.&nbsp;</span><span style='color:#000000; text-transform:uppercase;'>" + dt.Rows[i]["StyleCode"].ToString() + "</span>");
                      }
                      // htmlTable.Append("&nbsp;&nbsp;&nbsp;<a rel='shadowbox' width='800' height='400' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + dt.Rows[i]["UnitID"].ToString() + "&UnitName=" + dt.Rows[i]["Name"].ToString() + "&FloorNo=" + dt.Rows[i]["FloorNo"].ToString() + "&LineNo=" + dt.Rows[i]["LineNO"].ToString() + "&StyleCode=" + dt.Rows[i]["StyleCode"].ToString() + "&StyleId=" + dt.Rows[i]["StyleId"].ToString() + "&StyleNumber=" + dt.Rows[i]["StyleNumber"].ToString() + "&LinePlanFrameId=" + dt.Rows[i]["LinePlanFrameId"].ToString() + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&IsHalfStitch=" + Convert.ToInt32(dt.Rows[i]["IsHalfStich"]) + "' onclick='return OpenShadowbox(this);'><img src='../images/edit.png' height='15px' alt='' /></a>");

                      htmlTable.Append("</td>");
                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; font-size:10px; text-transform: none; font-family: Lucida Sans Unicode;'>");
                      //===========SAM Value========================
                      if (Convert.ToDecimal(dt.Rows[i]["Sam"]) > 0)
                      {
                        if (Convert.ToInt16(dtSamOBDiff.Rows[0]["IsSamDiff"]) == 1)
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>SAM:</span><span style='color:#FF0000;'>" + Math.Round(Convert.ToDouble(dt.Rows[i]["Sam"]), 1).ToString() + "</span>");
                        }
                        else
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>SAM:</span><span style='color:#405D99;'>" + Math.Round(Convert.ToDouble(dt.Rows[i]["Sam"]), 1).ToString() + "</span>");
                        }
                      }
                      htmlTable.Append("</td>");
                      //=========OB=============
                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:45px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (Convert.ToInt32(dt.Rows[i]["NewOB"]) > 0)
                        htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#405D99;'>" + dt.Rows[i]["NewOB"].ToString() + "</span>");
                      else
                      {
                        if (Convert.ToInt16(dtSamOBDiff.Rows[0]["IsObDiff"]) == 1)
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#FF0000;'>" + dt.Rows[i]["OB"].ToString() + "</span>");
                        }
                        else
                        {
                          htmlTable.Append("<span style='font-weight:bold;'>OB:</span><span style='color:#405D99;'>" + dt.Rows[i]["OB"].ToString() + "</span>");
                        }
                      }

                      htmlTable.Append("</td>");
                      //  lblSTCTargetDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")).ToString("dd MMM (ddd)");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:85px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (dt.Rows[i]["StartDate"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;' title='Start Date'>St:</span><span style='color:#405D99;'>" + Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("dd MMM (ddd)") + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode; display:none;'>");
                      if (dt.Rows[i]["StartSlot"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;'>Slot:&nbsp;</span><span style='color:#405D99;'>" + dt.Rows[i]["StartSlot"].ToString() + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:90px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");
                      if (dt.Rows[i]["EndDate"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;' title='End Date'>End:</span><span style='color:#405D99;'>" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("dd MMM (ddd)") + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:60px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode; display:none;'>");
                      if (dt.Rows[i]["EndSlot"].ToString() != "")
                        htmlTable.Append("<span style='font-weight:bold;'>Slot:&nbsp;</span><span style='color:#405D99;'>" + dt.Rows[i]["EndSlot"].ToString() + "</span>");
                      htmlTable.Append("</td>");

                      htmlTable.Append("<td align='left' style='padding-top:7px; padding-bottom:10px; width:40px; color:#7E7E7E; font-weight:bold; text-transform: none; font-size:10px; font-family: Lucida Sans Unicode;'>");

                      if (Convert.ToBoolean(dt.Rows[i]["IsHalfStich"]) == true)
                      {
                        htmlTable.Append("<a rel='shadowbox;width=680;height=700;' href='/Admin/UpdateHalfStitch.aspx?StyleId=" + Convert.ToInt32(dt.Rows[i]["StyleId"]) + "&LinePlanFrameId=" + Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]) + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenHalfStitchShadowbox(this);'><input id='chkHalfStitch' type='checkbox' checked='checked' style='padding:0px; margin:0px; vertical-align:bottom;' /></a><span style='color:#7E7E7E;' title='Half Stitch'>H St.</span>");
                      }
                      else
                      {
                        if (Convert.ToInt32(dt.Rows[i]["StyleCount"]) == 1 && Convert.ToInt32(dt.Rows[i]["IsStitching"]) == 0)
                        {
                          htmlTable.Append("<a rel='shadowbox;width=680;height=700;' href='/Admin/UpdateHalfStitch.aspx?StyleId=" + Convert.ToInt32(dt.Rows[i]["StyleId"]) + "&LinePlanFrameId=" + Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]) + "&CombinedFrameId=" + Convert.ToInt32(dt.Rows[i]["CombinedFrameId"]) + "&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenHalfStitchShadowbox(this);'><input id='chkHalfStitch' type='checkbox' style='padding:0px; margin:0px; vertical-align:bottom;' /></a><span style='color:#7E7E7E;' title='Half Stitch'>H St.</span>");
                        }
                      }

                      htmlTable.Append("</td>");

                      htmlTable.Append("</tr>");

                      htmlTable.Append("<tr>");
                      htmlTable.Append("<td colspan='6' align='left' valign='top' style='padding-left:5px; padding-right:5px;padding-bottom:2px'>");
                      htmlTable.Append("<div style='float:right;' class='show-hide'><img src='../images/plus-w.png' style='width: 12px;' class='Show-block' /><img src='../images/minus.png' class='hide-block' style='display:none;width: 15px;' /></div><table border='1' cellpadding='0' cellspacing='0'  align='left' style='border-collapse: collapse;table-layout:fixed; width:511px;'>");
                      htmlTable.Append("<tr>");
                      // htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:107px'>Style No.</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Serial No.</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Contract No.</td>");
                      htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:127px' class='border-bottom' title='Contract No.'>Cntr No.</td>");
                      htmlTable.Append("<td align='center' rowspan='2' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:87px' class='border-bottom' title='Ex Factory Date'>Ex</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:83px' title='Contract Quantity'>Cntr Qty</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:67px; display:none;'>Unit Qty</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:68px'>Line Qty</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:80px' title='Stitched Quantity'>St. Qty</td>");
                      //  htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:82px'>% Stitched</td>");
                      htmlTable.Append("</tr><tr>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px' class='border-bottom'>Style No.</td>");
                      // htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:103px'>Cntr No.</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:83px' class='border-bottom' title='Line Quantity'>Line Qty</td>");
                      htmlTable.Append("<td align='center' style='background-color:#F0F3F2; color:#405D99; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; width:80px' class='border-bottom' title='Stitched Percent'>%</td>");

                      htmlTable.Append("</tr></table><div class='table-wrap' style='display:none;'><table border='1' cellpadding='0' cellspacing='0'  align='left' style='border-collapse: collapse; table-layout:fixed; width:511px;'>");

                      // Comment by Ravi kumar on 3-8-17 
                      DataTable dtGrid = null;
                      Inhouse = false;
                      if (!string.IsNullOrEmpty(FactoryID))
                      {
                          Inhouse = oAdminController.getProdctionIDInhouse(Convert.ToString(UnitId));
                      }
                      //if (UnitId == 3 || UnitId == 11)
                      if(Inhouse == true)
                      {
                         dtGrid = oAdminController.GetContractStyleDetail_LinePlan(Convert.ToInt32(dt.Rows[i]["UnitID"]), Convert.ToInt32(dt.Rows[i]["LineNo"]), dt.Rows[i]["StyleCode"].ToString(), Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]));
                      }
                      else
                      {
                        dtGrid = oAdminController.GetContractStyleDetail_LinePlan_out(Convert.ToInt32(dt.Rows[i]["UnitID"]), 0, dt.Rows[i]["StyleCode"].ToString(), Convert.ToInt32(dt.Rows[i]["LinePlanFrameId"]));
                      }
                      Decimal TotalContractQty = 0, TotalUnitQty = 0, TotalLineQty = 0, TotalStichedQty = 0;

                      for (int j = 0; j < dtGrid.Rows.Count; j++)
                      {
                        htmlTable.Append("<tr>");
                        string ContractNo = dtGrid.Rows[j]["ContractNumber"].ToString();
                        // char[] MyChar = { '/', '-', ','};
                        //string NewContractNo = ContractNo.Trim(new Char[] { '/', '-'});
                        string NewContractNo = ContractNo.Replace('/', ' ').Replace('-', ' ');
                        // htmlTable.Append("<td rowspan='2' style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:107px'>" + dtGrid.Rows[j]["StyleNumber"].ToString() + "</td>");
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:103px'><img src='/uploads/style/thumb-" + dtGrid.Rows[j]["StyleImgPath"].ToString() + "' style='height:20px; width:20px; float:left' /><span style=' font-weight:bold; color:black;'>" + dtGrid.Rows[j]["SerialNumber"].ToString() + "</span></td>");
                        htmlTable.Append("<td rowspan='2' style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:127px'>" + NewContractNo + "</td>");
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:87px' rowspan='2'><span style='color:black;font-weight:bold;'>" + Convert.ToDateTime(dtGrid.Rows[j]["ExFactory"]).ToString("dd MMM (ddd)") + "</span></td>");



                        string strUnitQty = dtGrid.Rows[j]["UnitQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["UnitQty"]).ToString("#,##0");                                                   

                        string strContractQty = dtGrid.Rows[j]["ContractQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["ContractQty"]).ToString("#,##0");

                        if (strContractQty != "" && Convert.ToDecimal(strContractQty) > 999)
                        {
                          string strContractQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["ContractQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strContractQtyNew) < 100)
                          {
                            strContractQtyNew = Math.Round(Convert.ToDecimal(strContractQtyNew), 1).ToString();
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQtyNew + " k</span></td>");
                          }
                          else
                          {
                            strContractQtyNew = Math.Round(Convert.ToDecimal(strContractQtyNew), 0).ToString();
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQtyNew + " k</span></td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='text-align:center; width:83px' title='Contract qty:- " + strContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strContractQty + "</span></td>");
                        }


                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:80px; display:none;'>" + strUnitQty + "</td>");

                        string strStitchQty = dtGrid.Rows[j]["StichedQty"].ToString() == "0" ? "" : Convert.ToInt32(dtGrid.Rows[j]["StichedQty"]).ToString("#,##0");
                        if (strStitchQty != "" && Convert.ToDecimal(strStitchQty) > 999)
                        {
                          string strStitchQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strStitchQtyNew) < 100)
                          {
                            strStitchQtyNew = Math.Round(Convert.ToDecimal(strStitchQtyNew), 1).ToString();
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQtyNew + "k</span></td>");
                          }
                          else
                          {
                            strStitchQtyNew = Math.Round(Convert.ToDecimal(strStitchQtyNew), 0).ToString();
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQtyNew + "k</span></td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='text-align:center; width:80px' title='Stitch qty:- " + strStitchQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchQty + "</span></td>");
                        }





                        htmlTable.Append("</tr><tr>");

                        string strStitchPercent = "";
                        if (Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]) > 0)
                        {
                          strStitchPercent = Convert.ToInt32(((Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / Convert.ToDecimal(dtGrid.Rows[j]["LineQty"])) * 100)) == 0 ? "" : Convert.ToInt32(((Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]) / Convert.ToDecimal(dtGrid.Rows[j]["LineQty"])) * 100)).ToString() + "%";
                        }

                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform:uppercase; font-faimly:Lucida Sans Unicode; text-align:center; width:83px'>" + dtGrid.Rows[j]["StyleNumber"].ToString() + "</td>");
                        // htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:103px'>" + dtGrid.Rows[j]["ContractNumber"].ToString() + "</td>");


                        string strLineQty = dtGrid.Rows[j]["LineQty"].ToString() == "" ? "" : Convert.ToInt32(dtGrid.Rows[j]["LineQty"]).ToString("#,##0");
                        if (strLineQty != "" && Convert.ToDecimal(strLineQty) > 999)
                        {
                          string strLineQtyNew = (Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]) / 1000).ToString();
                          if (Convert.ToDecimal(strLineQtyNew) < 100)
                          {
                            strLineQtyNew = Math.Round(Convert.ToDecimal(strLineQtyNew), 1).ToString();
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQtyNew + "k</td>");
                          }
                          else
                          {
                            strLineQtyNew = Math.Round(Convert.ToDecimal(strLineQtyNew), 0).ToString();
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQtyNew + "k</td>");
                          }
                        }
                        else
                        {

                          htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode; text-align:center; width:83px' title='Line qty:- " + strLineQty + "'>" + strLineQty + "</td>");
                        }


                        htmlTable.Append("<td style=' text-align:center; width:80px'><span style='color:blue; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;'>" + strStitchPercent + "</span></td>");
                        htmlTable.Append("</tr>");
                        TotalContractQty = TotalContractQty + Convert.ToDecimal(dtGrid.Rows[j]["ContractQty"]);
                        TotalUnitQty = TotalUnitQty + Convert.ToDecimal(dtGrid.Rows[j]["UnitQty"]);
                        TotalLineQty = TotalLineQty + Convert.ToDecimal(dtGrid.Rows[j]["LineQty"]);
                        TotalStichedQty = TotalStichedQty + Convert.ToDecimal(dtGrid.Rows[j]["StichedQty"]);
                      }
                      string strTotalStitchedQty = TotalStichedQty == 0 ? "" : TotalStichedQty.ToString("#,##0");
                      htmlTable.Append(" </table></div> <table border='1' cellpadding='0' cellspacing='0' align='left' style='border-collapse: collapse; table-layout:fixed; width:511px;' class='border-top1'><tr>");
                      htmlTable.Append("<td colspan='2' rowspan='2' style='width:231px;text-align:center'><span style='color:#7e7e7e; font-size: 11px; text-transform: none; font-weight:bold; font-faimly:Lucida Sans Unicode;'>Total</span></td>");
                      htmlTable.Append("<td style='width:87px' rowspan='2'></td>");
                      //htmlTable.Append("<td style='width:127px'></td>");
                      if (TotalContractQty != 0)
                      {
                        if (TotalContractQty > 999)
                        {
                          Decimal TotalContractQtyNew = Math.Round(TotalContractQty / 1000, 1);
                          if (TotalContractQtyNew < 100)
                          {
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQtyNew.ToString() + "k</span></td>");
                          }
                          else
                          {
                            TotalContractQtyNew = Math.Round(TotalContractQtyNew, 0);
                            htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQtyNew.ToString() + "k</span></td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='text-align:center; width:83px' title='Total Contract Qty:- " + TotalContractQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + TotalContractQty.ToString("#,##0") + "</span></td>");
                        }
                      }
                      else
                      {
                        htmlTable.Append("<td style=' font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px'> &nbsp; </td>");
                      }

                      // htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:103px'>" + TotalContractQty.ToString("#,##0") + "</td>");

                      htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:67px; display:none;'>" + TotalUnitQty.ToString("#,##0") + "</td>");

                      if (TotalStichedQty != 0)
                      {
                        if (TotalStichedQty > 999)
                        {
                          Decimal TotalStichedQtyNew = Math.Round(TotalStichedQty / 1000, 1);
                          if (TotalStichedQtyNew < 100)
                          {
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQtyNew.ToString() + " k</span></td>");
                          }
                          else
                          {
                            TotalStichedQtyNew = Math.Round(TotalStichedQtyNew, 0);
                            htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQtyNew.ToString() + " k</td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='text-align:center; width:80px' title='Total Stitched Qty:- " + TotalStichedQty + "'><span style='color:#000000; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; '>" + TotalStichedQty.ToString("#,##0") + "</td>");
                        }

                      }
                      else
                      {
                        htmlTable.Append("<td style='font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:80px'> &nbsp; </td>");
                      }

                      htmlTable.Append("</tr><tr>");

                      if (TotalLineQty != 0)
                      {
                        if (TotalLineQty > 999)
                        {
                          Decimal TotalLineQtyNew = Math.Round(TotalLineQty / 1000, 1);
                          if (TotalLineQtyNew < 100)
                          {

                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQtyNew.ToString() + "k</td>");
                          }
                          else
                          {
                            TotalLineQtyNew = Math.Round(TotalLineQtyNew, 0);
                            htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQtyNew.ToString() + "k</td>");
                          }
                        }
                        else
                        {
                          htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px' title='Total Line Qty:- " + TotalLineQty + "'>" + TotalLineQty.ToString("#,##0") + "</td>");
                        }
                      }
                      else
                      {
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:83px'>&nbsp;</td>");
                      }


                      if (TotalUnitQty > 0)
                      {
                        string strTotalStitchedPer = "";
                        if (Convert.ToDecimal(TotalLineQty) > 0)
                        {
                          strTotalStitchedPer = Convert.ToInt32(((Convert.ToDecimal(TotalStichedQty) / Convert.ToDecimal(TotalLineQty)) * 100)) == 0 ? "" : Convert.ToInt32(((Convert.ToDecimal(TotalStichedQty) / Convert.ToDecimal(TotalLineQty)) * 100)).ToString() + "%";
                        }
                        htmlTable.Append("<td style='text-align:center; width:80px'><span style='color:blue; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold;'>" + strTotalStitchedPer + "</span></td>");
                      }
                      else
                      {
                        htmlTable.Append("<td style='color:#7E7E7E; font-size: 11px; text-transform: none; font-faimly:Lucida Sans Unicode;font-weight:bold; text-align:center; width:80px'></td>");
                      }
                      htmlTable.Append("</tr>");
                      htmlTable.Append("</table>");
                      htmlTable.Append("</td>");
                      htmlTable.Append("</tr>");

                      //  htmlTable.Append("<tr>");
                      // htmlTable.Append("<td colspan='4' align='left' style='padding-top:10px; padding-bottom:1px;padding-left:5px; width:520px; color:#405D99; font-size:11px; font-weight:bold; text-transform: none; font-family: Lucida Sans Unicode;'>");

                      //  htmlTable.Append("</td>");
                      //  htmlTable.Append("</tr>");


                      htmlTable.Append("</table>");
                      htmlTable.Append("</td>");

                      if (Convert.ToBoolean(dt.Rows[i]["IsLineVacant"]) == true)
                      {
                        e.Row.BackColor = System.Drawing.Color.FromName("#FdFBBE");
                        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                        e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                      }
                    }
                    htmlTable.Append("</tr>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    htmlTable.Length = 0;
                  }
                  else
                  {
                    e.Row.BackColor = System.Drawing.Color.FromName("#FdFBBE");
                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                    e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                  }
                }
                
                if (e.Row.BackColor == System.Drawing.Color.FromName("#FdFBBE"))
                {
                    DoTaskClose = true;
                }
            }
        }

        protected void gvDesignation_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
                DropDownList ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineDesignationID")) > 0)
                {
                    UserController UserControllerInstance = new UserController();
                    //DataTable dt = oAdminController.GetDesignationNameDetails(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineDesignationID")));
                    DataTable dt = UserControllerInstance.GetUsersByDesignationDataTable(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineDesignationID")));
                    ddlDesignation.Visible = true;
                    ddlDesignation.DataSource = dt;
                    ddlDesignation.DataTextField = "FLName";
                    ddlDesignation.DataValueField = "UserID";
                    ddlDesignation.DataBind();

                    ddlDesignation.SelectedValue = DataBinder.Eval(e.Row.DataItem, "DesignationNameId").ToString();
                    ddlDesignation.Enabled = dt.Rows.Count > 1 ? true : false;
                }
                else
                {
                    ddlDesignation.Visible = false;
                }
            }
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {          

            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            GridViewRow parentRow = ddl.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
            int rowIndex = row.RowIndex;
            int parentRowIndex = parentRow.RowIndex;

            HiddenField hdnFactoryId = (HiddenField)gvFactorySpecificLinePlanning.Rows[parentRowIndex].FindControl("hdnFactoryId");
            Label lblFloor = (Label)gvFactorySpecificLinePlanning.Rows[parentRowIndex].FindControl("lblFloor");
            Label lblLine = (Label)gvFactorySpecificLinePlanning.Rows[parentRowIndex].FindControl("lblLine");
            GridView gvDesignation = (GridView)gvFactorySpecificLinePlanning.Rows[parentRowIndex].FindControl("gvDesignation");

            HiddenField hdnLineDesignationId = (HiddenField)gvDesignation.Rows[rowIndex].FindControl("hdnLineDesignationId");
            DropDownList ddlDesignation = (DropDownList)gvDesignation.Rows[rowIndex].FindControl("ddlDesignation");

            int FloorId = lblFloor.Text == "First" ? 1 : lblFloor.Text == "Second" ? 2 : lblFloor.Text == "Third" ? 3 : 4;
            oAdminController.UpdateLineDesignation(Convert.ToInt32(hdnFactoryId.Value), FloorId, Convert.ToInt32(lblLine.Text.Replace("Line ", "")), Convert.ToInt32(hdnLineDesignationId.Value), Convert.ToInt32(ddlDesignation.SelectedValue), UserId);
            FillFactorySpecificLinePlanning();
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Designation updated successfully.');", true);
        }
    }
}