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
    public partial class UpdateHalfStitch : System.Web.UI.Page
    {
        int StyleId = 0, LinePlanFrameId = 0, CombinedFrameId = 0;
        OrderController odl = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            bool Bcontinue = false;
            StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            LinePlanFrameId = Convert.ToInt32(Request.QueryString["LinePlanFrameId"]);
            CombinedFrameId = Convert.ToInt32(Request.QueryString["CombinedFrameId"]);

            if (!IsPostBack)
            {
                
                FillStitchingManpowerDetail(StyleId, LinePlanFrameId, CombinedFrameId);
            }
            Bcontinue = odl.IsCheckLinePlanStichStart(LinePlanFrameId);
            if (Bcontinue == true)
                btnSubmit.Visible = false;
            else
                btnSubmit.Visible = true;


            SetPermissionSubbtn();
        }
        //abhishek
        public void SetPermissionSubbtn()
        {
          if ((ApplicationHelper.LoggedInUser.UserData.UserID == 6) ||
            (ApplicationHelper.LoggedInUser.UserData.UserID == 42 ||
            ApplicationHelper.LoggedInUser.UserData.UserID == 646 || ApplicationHelper.LoggedInUser.UserData.UserID == 488 ||
            ApplicationHelper.LoggedInUser.UserData.UserID == 655 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 46
            ))
          {
            btnSubmit.Visible = true;
          }
          else
          {
            btnSubmit.Visible = false;
          }
        }
        private void FillStitchingManpowerDetail(int StyleId, int LinePlanFrameId, int CombinedFrameId)
        {
            AdminController oAdminController = new AdminController();
            DataSet ds = oAdminController.GetStitchingManpowerDetail(StyleId, LinePlanFrameId, CombinedFrameId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvStitchingManpowerDetail.DataSource = ds.Tables[0];
                gvStitchingManpowerDetail.DataBind();

                //if (ds.Tables.Count > 1)
                //{
                //    gvFinishingManpowerDetail.DataSource = ds.Tables[1];
                //    gvFinishingManpowerDetail.DataBind();
                //}

                lblMessage.Visible = false;
                btnSubmit.Visible = true;
                txtHSNickName.Visible = true;
                txtOperationName.Visible = true;

            }
            else
            {
                lblMessage.Visible = true;
                btnSubmit.Visible = false;
                txtHSNickName.Visible = false;
                txtOperationName.Visible = false;
                tdFinish1.Visible = false;
                tdFinish2.Visible = false;
            }
            DataTable dt = oAdminController.GetOperationName(LinePlanFrameId, CombinedFrameId);
            if (dt.Rows.Count > 0)
            {
                txtOperationName.Text = dt.Rows[0]["OperationName"].ToString();
                chkFinishing.Checked = dt.Rows[0]["IsFinishing"].ToString() == "" ? false : Convert.ToBoolean(dt.Rows[0]["IsFinishing"]);
                //chkFinishing.Enabled = dt.Rows[0]["FinishEnable"].ToString() == "1" ? false : true;
            }

            oAdminController = null;
        }

        protected void gvStitchingManpowerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOperationID = (HiddenField)e.Row.FindControl("hdnOperationID");
                HiddenField hdnCompletelyCheckedStitched = (HiddenField)e.Row.FindControl("hdnCompletelyCheckedStitched");
                HiddenField hdnFactoryWorkForce = (HiddenField)e.Row.FindControl("hdnFactoryWorkForce");
                HiddenField hdnWorkerType = (HiddenField)e.Row.FindControl("hdnWorkerType");
                Label lblStitchingManpower = (Label)e.Row.FindControl("lblStitchingManpower");
                CheckBox chkCheckedStitched = (CheckBox)e.Row.FindControl("chkCheckedStitched");
                Label lblSrNo = (Label)e.Row.FindControl("lblSrNo");
                if (hdnOperationID.Value == "0")
                {
                    lblSrNo.Text = hdnFactoryWorkForce.Value;
                    e.Row.Cells[0].ColumnSpan = 6;
                    e.Row.Cells[0].CssClass = "RowMerge";
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    
                }
                else
                {

                    lblStitchingManpower.Text = hdnFactoryWorkForce.Value + " <b>(" + hdnWorkerType.Value + ")</b>";
                    chkCheckedStitched.Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)["IsCheckedStitched"]);

                    chkCheckedStitched.Enabled = hdnCompletelyCheckedStitched.Value == "1"  ? false : true;

                    //if (chkCheckedStitched.Checked)
                    //{
                    //    chkCheckedStitched.Enabled = true;
                    //}
                }
            }
        }

        protected void gvFinishingManpowerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCompletelyCheckedFinished = (HiddenField)e.Row.FindControl("hdnCompletelyCheckedFinished");
                HiddenField hdnFactoryWorkForce = (HiddenField)e.Row.FindControl("hdnFactoryWorkForce");
                HiddenField hdnWorkerType = (HiddenField)e.Row.FindControl("hdnWorkerType");
                Label lblFinishingManpower = (Label)e.Row.FindControl("lblFinishingManpower");
                CheckBox chkCheckedFinished = (CheckBox)e.Row.FindControl("chkCheckedFinished");

                lblFinishingManpower.Text = hdnFactoryWorkForce.Value + " <b>(" + hdnWorkerType.Value + ")</b>";
                chkCheckedFinished.Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)["IsCheckedFinished"]);

                chkCheckedFinished.Enabled = Convert.ToBoolean(hdnCompletelyCheckedFinished.Value) ? false : true;

                if (chkCheckedFinished.Checked)
                {
                    chkCheckedFinished.Enabled = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double StitchSAM = 0, MachineCost = 0;
            int OperationId = 0, FinalOB = 0;
            string OperationType = "";

            AdminController oAdminController = new AdminController();

            for (int i = 0; i < gvStitchingManpowerDetail.Rows.Count; i++)
            {
                HiddenField hdnFactoryWorkForce = (HiddenField)gvStitchingManpowerDetail.Rows[i].FindControl("hdnFactoryWorkForce");
                HiddenField hdnWorkerType = (HiddenField)gvStitchingManpowerDetail.Rows[i].FindControl("hdnWorkerType");
                CheckBox chkCheckedStitched = (CheckBox)gvStitchingManpowerDetail.Rows[i].FindControl("chkCheckedStitched");
                HiddenField hdnOperationID = (HiddenField)gvStitchingManpowerDetail.Rows[i].FindControl("hdnOperationID");
                HiddenField hdnOperationType = (HiddenField)gvStitchingManpowerDetail.Rows[i].FindControl("hdnOperationType");
                Label lblMachineSAM = (Label)gvStitchingManpowerDetail.Rows[i].FindControl("lblMachineSAM");
                Label lblMachineCost = (Label)gvStitchingManpowerDetail.Rows[i].FindControl("lblMachineCost");
                Label lblNos = (Label)gvStitchingManpowerDetail.Rows[i].FindControl("lblNos");
                if (hdnOperationID != null)
                {
                    if (Convert.ToInt32(hdnOperationID.Value) > 0)
                    {
                        OperationId = Convert.ToInt32(hdnOperationID.Value);
                        StitchSAM = lblMachineSAM.Text == "" ? 0 : Convert.ToDouble(lblMachineSAM.Text);
                        MachineCost = lblMachineCost.Text == "" ? 0 : Convert.ToDouble(lblMachineCost.Text);
                        FinalOB = lblNos.Text == "" ? 0 : Convert.ToInt32(lblNos.Text);
                        OperationType = hdnOperationType.Value.ToString();
                        oAdminController.UpdateHalfStitching(StyleId, LinePlanFrameId, hdnFactoryWorkForce.Value, hdnWorkerType.Value, chkCheckedStitched.Checked, OperationId, StitchSAM, MachineCost, FinalOB, CombinedFrameId, OperationType);
                    }
                }
            }
            //oAdminController.UpdateHalfStitchingOperation(LinePlanFrameId, txtOperationName.Text);
            oAdminController.UpdateLinePlanStitchingSam(StyleId, LinePlanFrameId, chkFinishing.Checked, txtOperationName.Text);

            //}     

            oAdminController = null;
            if (Convert.ToInt32(Request.QueryString["ProductionUnit"]) > 0 && Convert.ToString(Request.QueryString["Enabled"]) == "false")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "&Enabled=false');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "');", true);
            }
        }
    }
}