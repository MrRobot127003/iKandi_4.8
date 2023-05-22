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
    public partial class StitchQtyEntryPopUp : System.Web.UI.Page
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
        public string type
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
                bindQCManPowerChecker();
                bindQC();
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
            if (Request.QueryString["type"] != null)
            {
                type = Request.QueryString["type"];
                hdnType.Value = type;
            }
        }

        public void bindQCManPowerChecker()
        {

            DataSet dsChecker = oAdminController.GetQCManPowerChecker(OrderDetailID, UnitID, type);
            DataTable dtQCManPowerChecker = dsChecker.Tables[0];
            if (dtQCManPowerChecker.Rows.Count > 0)
            {
                if (type == "Stitch")
                {
                    lblHeader.Text = "Out House Stitch Entry";
                    lblTotalValueHdr.Text = "Cut Issue";
                    lblTotalValue.Text = "Stitch Qty (Total)";
                    lblCompleted.Text = "Stitch completed";

                    txtManPower.Text = dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString() == "0" ? "" : dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString();

                    lblFactoryName.Text = dtQCManPowerChecker.Rows[0]["FactoryName"].ToString() == "" ? "" : "(" + dtQCManPowerChecker.Rows[0]["FactoryName"].ToString() + ")";
                    hdnQcCheckerID.Value = dtQCManPowerChecker.Rows[0]["QcCheckerID"].ToString();
                    hdnChangeManpower.Value = dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString();
                    hdnChangeQC.Value = dtQCManPowerChecker.Rows[0]["OutHouseQC"].ToString();
                    lblTotalRemaining.Text = dtQCManPowerChecker.Rows[0]["CutIssueQty"].ToString() == "0" ? "" : Convert.ToInt32(dtQCManPowerChecker.Rows[0]["CutIssueQty"]).ToString();
                    txtQty.ToolTip = dtQCManPowerChecker.Rows[0]["TodayStitched"].ToString() == "0" ? "" : Convert.ToInt32(dtQCManPowerChecker.Rows[0]["TodayStitched"]).ToString();
                    SpnQty.InnerText = dtQCManPowerChecker.Rows[0]["TotalStitched"].ToString() == "0" ? "" : "(" + Convert.ToInt32(dtQCManPowerChecker.Rows[0]["TotalStitched"]).ToString() + ")";
                    hdnQty.Value = dtQCManPowerChecker.Rows[0]["TotalStitched"].ToString();
                    chkisCom.Checked = dtQCManPowerChecker.Rows[0]["IsStitched"].ToString() == "False" ? false : true;
                    chkisCom.Enabled = dtQCManPowerChecker.Rows[0]["IsStitched"].ToString() == "False" ? true : false;
                }
                else if (type == "Finish")
                {
                    lblHeader.Text = "Out House Finish Entry";
                    lblTotalValueHdr.Text = "Stitched Qty";
                    lblTotalValue.Text = "Finish Qty (Total)";
                    lblCompleted.Text = "Finish completed";

                    txtManPower.Text = dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString() == "0" ? "" : dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString();

                    lblFactoryName.Text = dtQCManPowerChecker.Rows[0]["FactoryName"].ToString() == "" ? "" : "(" + dtQCManPowerChecker.Rows[0]["FactoryName"].ToString() + ")";
                    hdnQcCheckerID.Value = dtQCManPowerChecker.Rows[0]["QcCheckerID"].ToString();
                    hdnChangeManpower.Value = dtQCManPowerChecker.Rows[0]["OutHouseManpower"].ToString();
                    hdnChangeQC.Value = dtQCManPowerChecker.Rows[0]["OutHouseQC"].ToString();
                    lblTotalRemaining.Text = dtQCManPowerChecker.Rows[0]["TotalStitchQty"].ToString() == "0" ? "" : Convert.ToInt32(dtQCManPowerChecker.Rows[0]["TotalStitchQty"]).ToString();
                    txtQty.ToolTip = dtQCManPowerChecker.Rows[0]["TodayFinish"].ToString() == "0" ? "" : Convert.ToInt32(dtQCManPowerChecker.Rows[0]["TodayFinish"]).ToString();
                    SpnQty.InnerText = dtQCManPowerChecker.Rows[0]["TotalFinished"].ToString() == "0" ? "" : "(" + Convert.ToInt32(dtQCManPowerChecker.Rows[0]["TotalFinished"]).ToString() + ")";
                    hdnQty.Value = dtQCManPowerChecker.Rows[0]["TotalFinished"].ToString();
                    chkisCom.Checked = dtQCManPowerChecker.Rows[0]["IsFinished"].ToString() == "False" ? false : true;
                    chkisCom.Enabled = dtQCManPowerChecker.Rows[0]["IsFinished"].ToString() == "False" ? true : false;
                }
                //if (chkisCom.Checked)
                //{
                //    txtQty.Attributes.Add("readonly", "readonly");
                //}               
            }
            if (dsChecker.Tables.Count > 1)
            {
                DataTable dtHistory = dsChecker.Tables[1];
                grdHistory.DataSource = dtHistory;
                grdHistory.DataBind();
            }
        }

        public void bindQC()
        {
            DataSet ds = new DataSet();
            ds = oAdminController.GetAllQC_And_Checker();
            DataTable dtQC = ds.Tables[0];
            if (dtQC.Rows.Count > 0)
            {
                ddlQC.DataSource = dtQC;
                ddlQC.DataTextField = "FactoryQC";
                ddlQC.DataValueField = "UserID";
                ddlQC.DataBind();
                ddlQC.Items.Insert(0, new ListItem("Select QC", "0"));
                if (hdnChangeQC.Value != "")
                {
                    ddlQC.SelectedValue = hdnChangeQC.Value;
                }
            }

            DataTable dtQcChecker = ds.Tables[1];
            if (dtQcChecker.Rows.Count > 0)
            {
                ddlChecker.DataSource = dtQcChecker;
                ddlChecker.DataTextField = "firstname";
                ddlChecker.DataValueField = "UserID";
                ddlChecker.DataBind();
                ddlChecker.Items.Insert(0, new ListItem("Select Checker", "0"));
                if (hdnQcCheckerID.Value != "")
                {
                    ddlChecker.SelectedValue = hdnQcCheckerID.Value;
                }
            }
            foreach (ListItem i in ddlChecker.Items)
            {
                String after = i.Text.Substring(0, 1).ToUpper() + i.Text.Substring(1).ToLower();
                i.Text = after;
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
            string[] sDate = strDateTime.Split('/');
            sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
            dtFinaldate = Convert.ToDateTime(sDateTime);
            return dtFinaldate;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // btnSubmit.Enabled=false;
            try
            {
                DateTime dtime = DateTime.Now;
                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                int inputQty = txtQty.Text.Trim() == "" ? 0 : Convert.ToInt32(txtQty.Text);
                int Manpower = (txtManPower.Text.Trim() == string.Empty ? 0 : (Convert.ToDouble(txtManPower.Text.Trim()) <= 0 ? 0 : Convert.ToInt32(txtManPower.Text)));
                int QCId = Convert.ToInt32(ddlQC.SelectedValue);

                int iupdateQCManPowerChecker = oAdminController.UpdateQCManPowerChecker(OrderDetailID, Manpower, QCId, Convert.ToInt32(ddlChecker.SelectedValue), UnitID, inputQty, (chkisCom.Checked == true ? 1 : 0), type);

                if (iupdateQCManPowerChecker > 0)
                {
                    ShowAlert("Record saved successfully!");
                    bindQCManPowerChecker();
                    bindQC();
                    txtQty.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "close", "self.parent.Shadowbox.close();", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                ShowAlert("Some Error occured during saving!");
                return;
            }
        }

        protected void grdHistory_DataBound(object sender, EventArgs e)
        {

            for (int i = grdHistory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdHistory.Rows[i];
                GridViewRow previousRow = grdHistory.Rows[i - 1];

                Label lblManPower = (Label)row.Cells[0].FindControl("lblManPower");
                Label lblManPower_Prev = (Label)previousRow.Cells[0].FindControl("lblManPower");

                if (lblManPower.Text == lblManPower_Prev.Text)
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


                Label lblQCName = (Label)row.Cells[2].FindControl("lblQCName");
                Label lblQCName_Prev = (Label)previousRow.Cells[2].FindControl("lblQCName");

                if (lblQCName.Text == lblQCName_Prev.Text)
                {
                    if (previousRow.Cells[2].RowSpan == 0)
                    {
                        if (row.Cells[2].RowSpan == 0)
                        {
                            previousRow.Cells[2].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
                        }
                        row.Cells[2].Visible = false;
                    }
                }

                Label lblQcChecker = (Label)row.Cells[3].FindControl("lblQcChecker");
                Label lblQcChecker_Prev = (Label)previousRow.Cells[3].FindControl("lblQcChecker");

                if (lblQcChecker.Text == lblQcChecker_Prev.Text)
                {
                    if (previousRow.Cells[3].RowSpan == 0)
                    {
                        if (row.Cells[3].RowSpan == 0)
                        {
                            previousRow.Cells[3].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
                        }
                        row.Cells[3].Visible = false;
                    }
                }

                Label lblDate = (Label)row.Cells[4].FindControl("lblDate");
                Label lblDate_Prev = (Label)previousRow.Cells[4].FindControl("lblDate");

                if (lblDate.Text == lblDate_Prev.Text)
                {
                    if (previousRow.Cells[4].RowSpan == 0)
                    {
                        if (row.Cells[4].RowSpan == 0)
                        {
                            previousRow.Cells[4].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
                        }
                        row.Cells[4].Visible = false;
                    }
                }
            }

        }

        protected void grdHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblQtyHdr = (Label)e.Row.FindControl("lblQtyHdr");
                if (type == "Stitch")
                {
                    lblQtyHdr.Text = "Stitch Qty";
                }
                else if (type == "Finish")
                {
                    lblQtyHdr.Text = "Finish Qty";
                }
            }
        }
    }
}