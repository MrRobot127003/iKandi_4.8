using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class AddHalfStitchLinePlanning : System.Web.UI.Page
    {
        int UserId = 0, UnitId = 0, RowSpan = 1, iLineNo = 0;
        string UnitName = "", FloorNo = "", LineNo = "";
        int SeqFrameId = -1; bool IsParallel = false;
        AdminController oAdminController = new AdminController();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            UnitName = Convert.ToString(Request.QueryString["UnitName"]);
            FloorNo = Convert.ToString(Request.QueryString["FloorNo"]);
            LineNo = Convert.ToString(Request.QueryString["LineNo"]);

            if ((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120))
                iLineNo = Convert.ToInt32(LineNo);

            if (!IsPostBack)
            {
                lblFactory.Text = "'" + UnitName + "'";
                lblFloorNo.Text = "'" + FloorNo + "'";
                if (UnitName != LineNo)
                    lblLineNo.Text = "'" + LineNo + "'";


                FillSlot();
                FillLinePlanFrame();
                FillCopyFrom();

            }
            if ((UnitId != 3) && (UnitId != 11) && (UnitId != 96) && (UnitId != 120))
            {
                spanline.Visible = false;
            }
        }
        private void FillSlot()
        {
            ddlSlot.DataSource = oAdminController.GetSlot();
            ddlSlot.DataValueField = "SlotID";
            ddlSlot.DataTextField = "SlotName";
            ddlSlot.DataBind();
            ddlSlot.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void FillLinePlanFrame()
        {
            DataTable dtFrame;
            if ((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120))
            {
                dtFrame = oAdminController.GetLinePlanFrame(UnitId, iLineNo, 0);
            }
            else
            {
                dtFrame = oAdminController.GetLinePlanFrame_outhouse(UnitId, iLineNo, 0);
            }
            if (rbtnList.SelectedValue == "2")
                IsParallel = true;
            else
                IsParallel = false;

            if (dtFrame.Rows.Count > 0)
            {
                ddlFrame.DataSource = dtFrame;
                ddlFrame.DataValueField = "LinePlanFrameId";
                ddlFrame.DataTextField = "LinePlanFrame";
                ddlFrame.DataBind();

                SeqFrameId = Convert.ToInt32(ddlFrame.SelectedValue);
                DataTable dtDate = oAdminController.GetStartDate(UnitId, iLineNo, 0, SeqFrameId, IsParallel);
                if (dtDate.Rows.Count > 0)
                {
                    int StartSlot = 0;
                    DateTime dtStartDate = Convert.ToDateTime(dtDate.Rows[0]["StartDate"]);
                    StartSlot = Convert.ToInt32(dtDate.Rows[0]["StartSlot"].ToString());

                    if (dtStartDate > DateTime.Today)
                        txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                    else
                        txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                    if ((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120))
                    {
                        if (StartSlot != 0)
                        {
                            ddlSlot.SelectedValue = StartSlot.ToString();
                        }
                    }
                    else
                    {
                        ddlSlot.SelectedValue = StartSlot.ToString();
                    }
                    txtStartDate.Enabled = false;
                }
            }
            else
            {
                ddlFrame.Style.Add("display", "none");
                rbtnList.Enabled = false;
            }
        }

        private void FillCopyFrom()
        {
            DataTable dtFrame = oAdminController.GetHalfStitchDetails(UnitId);
            ddlCopyFrom.DataSource = dtFrame;
            ddlCopyFrom.DataValueField = "FrameUnitId";
            ddlCopyFrom.DataTextField = "LinePlanFrameId";
            ddlCopyFrom.DataBind();
            ddlCopyFrom.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void rbtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFrame.Items.Count > 0)
            {
                if (rbtnList.SelectedValue == "2")
                    IsParallel = true;
                else
                    IsParallel = false;

                SeqFrameId = Convert.ToInt32(ddlFrame.SelectedValue);
                DataTable dtFrame = oAdminController.GetStartDate(UnitId, iLineNo, 0, SeqFrameId, IsParallel);
                if (dtFrame.Rows.Count > 0)
                {
                    DateTime dtStartDate = Convert.ToDateTime(dtFrame.Rows[0]["StartDate"]);
                    int StartSlot = Convert.ToInt32(dtFrame.Rows[0]["StartSlot"]);

                    if (dtStartDate > DateTime.Today)
                        txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                    else
                        txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                    if (StartSlot != 0)
                    {
                        ddlSlot.SelectedValue = StartSlot.ToString();
                    }
                    txtStartDate.Enabled = false;
                }
            }
        }

        protected void ddlFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnList.SelectedValue == "2")
                IsParallel = true;
            else
                IsParallel = false;

            int ParallelFrameId = Convert.ToInt32(ddlFrame.SelectedValue);
            DataTable dtFrame = oAdminController.GetStartDate(UnitId, iLineNo, -1, ParallelFrameId, IsParallel);
            if (dtFrame.Rows.Count > 0)
            {
                DateTime dtStartDate = Convert.ToDateTime(dtFrame.Rows[0]["StartDate"]);
                int StartSlot = Convert.ToInt32(dtFrame.Rows[0]["StartSlot"]);
                txtStartDate.Enabled = true;
                ddlSlot.Enabled = true;
                if (dtStartDate > DateTime.Today)
                    txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                else
                    txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                if (StartSlot != 0)
                {
                    ddlSlot.SelectedValue = StartSlot.ToString();
                }
                txtStartDate.Enabled = false;
                ddlSlot.Enabled = false;
            }
            else
            {
                txtStartDate.Enabled = true;
                txtStartDate.Text = "";
                ddlSlot.SelectedValue = "0";
                txtStartDate.Enabled = false;
                ddlSlot.Enabled = false;
            }
        }

        protected void ddlCopyFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValidationMessage.Text = "";
            string[] strFrameUnitId = ddlCopyFrom.SelectedValue.Split('-');
            int FrameUnitId = Convert.ToInt32(strFrameUnitId[0]);

            if (FrameUnitId > 0)
            {
                if (oAdminController.CheckIsAvailableFrame(FrameUnitId))
                {

                    if (((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120)) && ((FrameUnitId == 3) || (FrameUnitId == 11) || (FrameUnitId == 96) || (FrameUnitId == 120)))
                    {
                        if (FrameUnitId != UnitId)
                        {
                            lblFullStitchFrame.Visible = true;
                            ddlFullStitchFrame.Visible = true;
                            ddlFullStitchFrame.Items.Insert(0, new ListItem("Frame No. " + ddlCopyFrom.SelectedItem.Text, "1"));
                            ddlFullStitchFrame.Items.Insert(1, new ListItem("Current Frame", "2"));
                        }
                    }
                    else if ((UnitId != 3) && (UnitId != 11) && (UnitId != 96) && (UnitId != 120) && ((FrameUnitId == 3) || (FrameUnitId == 11) || (FrameUnitId == 96) || (FrameUnitId == 120)))
                    {
                        lblReplica.Visible = true;
                        chkReplica.Visible = true;

                        DataTable dtOutHouse = oAdminController.GetOutHouseFactory(UnitId);
                        ddlOutHouseFactory.DataSource = dtOutHouse;
                        ddlOutHouseFactory.DataTextField = "FactoryName";
                        ddlOutHouseFactory.DataValueField = "UnitID";
                        ddlOutHouseFactory.DataBind();
                        ddlOutHouseFactory.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    //trSlot.Visible = true;
                    trSubmit.Visible = true;
                    int LineNoId = 0;

                    if ((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120))
                    {
                        LineNoId = Convert.ToInt32(LineNo.Replace("Line ", ""));
                    }
                    else
                    {
                        LineNoId = UnitId;
                    }
                }
                else
                {
                    lblValidationMessage.Text = "Selected Frame is not available because Sam of this Frame is achieved.";
                    //trSlot.Visible = false;
                    trSubmit.Visible = false;
                    lblSlot.Text = "";
                }
            }
            else
            {
                //trSlot.Visible = false;
                trSubmit.Visible = false;
                lblSlot.Text = "";
            }

        }

        protected void ddlSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValidationMessage.Text = "";
            if (Convert.ToInt32(ddlSlot.SelectedValue) > 0)
            {
                DataTable dtSlot = oAdminController.GetSlot();
                DataView dvSlot = new DataView(dtSlot);
                dvSlot.RowFilter = "SlotID = " + Convert.ToInt32(ddlSlot.SelectedValue);
                lblSlot.Text = "(" + dvSlot.ToTable().Rows[0]["Period"].ToString() + ")";
            }
            else
            {
                lblSlot.Text = "";
            }

        }

        protected void chkReplica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReplica.Checked)
                ddlOutHouseFactory.Visible = true;
            else
                ddlOutHouseFactory.Visible = false;
        }

        protected void ddlOutHouseFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strFrameUnitId = ddlCopyFrom.SelectedValue.Split('-');
            int FrameUnitId = Convert.ToInt32(strFrameUnitId[0]);

            if (FrameUnitId > 0)
            {
                int BaseLinePlanFrame = Convert.ToInt32(ddlCopyFrom.SelectedItem.Text);
                DataTable dtFrame = oAdminController.GetContractDetailsForReplica(BaseLinePlanFrame);
                if (dtFrame.Rows.Count > 0)
                {
                    gvReplica.Visible = true;
                    gvReplica.DataSource = dtFrame;
                    gvReplica.DataBind();
                }
            }
        }

        protected void gvReplica_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < gvReplica.Rows.Count; i++)
            {
                GridViewRow row = gvReplica.Rows[i];

                if (i > 0)
                {
                    GridViewRow previousRow = gvReplica.Rows[i - 1];

                    Label lblStyleNo = (Label)row.Cells[0].FindControl("lblStyleNo");
                    Label lblPreviousStyleNo = (Label)previousRow.Cells[0].FindControl("lblStyleNo");

                    if (lblStyleNo.Text == lblPreviousStyleNo.Text)
                    {
                        RowSpan = RowSpan + 1;

                        if (RowSpan > 2)
                        {
                            GridViewRow firstRow = gvReplica.Rows[i - (RowSpan - 1)];
                            firstRow.Cells[0].RowSpan = RowSpan;
                        }
                        else
                            previousRow.Cells[0].RowSpan = RowSpan;

                        row.Cells[0].Visible = false;

                    }
                    else
                    {
                        RowSpan = 1;
                    }

                }

            }
        }

        protected void gvReplica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = UnitName + "</br>Line Qty";
                e.Row.Cells[4].Text = ddlOutHouseFactory.SelectedItem.Text + "</br>Line Qty";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int LineNoId = 0, FloorNoId = 0, SlotId = 0, FullStitchFrame = 0, ReplicaUnitId = 0, FirstUnitID = 0;
            int FirstLineQty = 0, ReplicaLineQty = 0, FirstLinePlanFrameId = 0, ReplicaLinePlanFrameId = 0;

            bool IsReplica = false, IsReplicaWorking = false;
            DateTime StartDate;
            LinePlan objLinePlan = new LinePlan();
            try
            {
                btnSubmit.Visible = false;
                if (rbtnList.SelectedValue == "2")
                    objLinePlan.IsParallel = true;
                else
                    objLinePlan.IsParallel = false;

                if (ddlFrame.Items.Count > 0)
                    objLinePlan.SeqFrameId = Convert.ToInt32(ddlFrame.SelectedValue);

                if ((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120))
                {
                    LineNoId = Convert.ToInt32(LineNo.Replace("Line ", ""));
                }
                else
                {
                    LineNoId = 0;
                }
                FloorNoId = FloorNo == "First" ? 1 : FloorNo == "Second" ? 2 : FloorNo == "Third" ? 3 : 4;
                SlotId = Convert.ToInt32(ddlSlot.SelectedValue);
                objLinePlan.StartSlot = SlotId;

                string[] strFrameUnitId = ddlCopyFrom.SelectedValue.Split('-');
                int FrameUnitId = Convert.ToInt32(strFrameUnitId[0]);

                if (FrameUnitId == 0)
                {
                    lblValidationMessage.Text = "Please select a Frame.";
                    btnSubmit.Visible = true;
                    return;
                }

                if (txtStartDate.Text == "")
                {
                    lblValidationMessage.Text = "Start Date cannot be blank.";
                    btnSubmit.Visible = true;
                    return;
                }
                else
                {
                    StartDate = txtStartDate.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtStartDate.Text).Value;
                    objLinePlan.StartDate = StartDate;
                }

                if (SlotId == 0)
                {
                    lblValidationMessage.Text = "Please select a slot.";
                    btnSubmit.Visible = true;
                    return;
                }

                if (oAdminController.CheckIsAvailableSlot(UnitId, FloorNoId, LineNoId, StartDate, SlotId, FrameUnitId) == false)
                {
                    lblValidationMessage.Text = "You cannot scheduled this task at this time.";
                    btnSubmit.Visible = true;
                    return;
                }
                //int BaseUnitId = Convert.ToInt32(ddlCopyFrom.SelectedValue);
                if (((UnitId == 3) || (UnitId == 11) || (UnitId == 96) || (UnitId == 120)) && ((FrameUnitId == 3) || (FrameUnitId == 11) || (FrameUnitId == 96) || (FrameUnitId == 120)))
                {
                    if (FrameUnitId != UnitId)
                    {
                        if (ddlFullStitchFrame.Visible == true)
                        {
                            FullStitchFrame = Convert.ToInt32(ddlFullStitchFrame.SelectedValue);
                        }
                    }
                }
                else if ((UnitId != 3) && (UnitId != 11) && (UnitId != 96) && (UnitId != 120) && ((FrameUnitId == 3) || (FrameUnitId == 11) || (FrameUnitId == 96) || (FrameUnitId == 120)))
                {
                    IsReplica = chkReplica.Checked;
                    if ((IsReplica == true) && (ddlOutHouseFactory.SelectedValue == "0"))
                    {
                        lblValidationMessage.Text = "Please select replica Factory";
                        btnSubmit.Visible = true;
                        return;
                    }
                    else if ((IsReplica == true) && (ddlOutHouseFactory.SelectedValue != "0"))
                    {
                        FirstUnitID = UnitId;
                        ReplicaUnitId = Convert.ToInt32(ddlOutHouseFactory.SelectedValue);
                        int BaseLinePlanFrame = Convert.ToInt32(ddlCopyFrom.SelectedItem.Text);
                        IsReplicaWorking = true;

                        foreach (GridViewRow gvr in gvReplica.Rows)
                        {
                            HiddenField hdnStyleId = (HiddenField)gvr.FindControl("hdnStyleId");
                            HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnOrderId");
                            HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                            HiddenField hdnContractQty = (HiddenField)gvr.FindControl("hdnContractQty");
                            HiddenField hdnUnitQty = (HiddenField)gvr.FindControl("hdnUnitQty");
                            TextBox txtFirstLineQty = (TextBox)gvr.FindControl("txtFirstLineQty");
                            TextBox txtReplicaLineQty = (TextBox)gvr.FindControl("txtReplicaLineQty");

                            objLinePlan.StyleId = Convert.ToInt32(hdnStyleId.Value);
                            objLinePlan.OrderID = Convert.ToInt32(hdnOrderId.Value);
                            objLinePlan.OrderDetailID = Convert.ToInt32(hdnOrderDetailId.Value);
                            objLinePlan.ContractQty = Convert.ToInt32(hdnContractQty.Value);
                            objLinePlan.UnitQty = Convert.ToInt32(hdnUnitQty.Value);
                            FirstLineQty = txtFirstLineQty.Text == "" ? 0 : Convert.ToInt32(txtFirstLineQty.Text);
                            ReplicaLineQty = txtReplicaLineQty.Text == "" ? 0 : Convert.ToInt32(txtReplicaLineQty.Text);

                            int iSave = oAdminController.InsertReplicaLinePlanning(objLinePlan, BaseLinePlanFrame, FirstUnitID, ReplicaUnitId, FirstLineQty, ReplicaLineQty, UserId, ref FirstLinePlanFrameId, ref ReplicaLinePlanFrameId);

                        }

                        oAdminController.UpdateReplicaEndDate(FirstLinePlanFrameId, ReplicaLinePlanFrameId, FirstUnitID, ReplicaUnitId, objLinePlan.StyleId);
                    }

                }
                if (IsReplicaWorking == false)
                {
                    oAdminController.AddDuplicateHalfStitch_LinePlan(UnitId, FloorNoId, LineNoId, StartDate, SlotId, Convert.ToInt32(ddlCopyFrom.SelectedItem.Text), FullStitchFrame, objLinePlan.SeqFrameId, objLinePlan.IsParallel, UserId);
                }
            }
            catch (Exception ex)
            {
                lblValidationMessage.Text = ex.Message.ToString();
                btnSubmit.Visible = true;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "');", true);

        }




    }
}