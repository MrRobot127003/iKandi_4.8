using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class StyleWiseLinePlannging : System.Web.UI.Page
    {
        int UserId = 0;
        int UnitId = 0, StyleId = 0, IsHalfStitch = 0, LinePlanFrameId = 0, CombinedFrameId = 0, LineNo = 0;
        string UnitName = "", FloorNo = "", StyleCode = "", StyleNumber = "";
        bool bContinue = true;
        DateTime StartDate = DateTime.Now;
        int RowSpan = 1;
        int SeqFrameId = -1; bool IsParallel = false;
        Boolean Inhouse = false; 
        #region OutHouseVariable
        string LineNoOutHouse = "";
        #endregion
        AdminController AdminController = new AdminController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            UnitName = Convert.ToString(Request.QueryString["UnitName"]);
            FloorNo = Convert.ToString(Request.QueryString["FloorNo"]);           
            LinePlanFrameId = Convert.ToInt32(Request.QueryString["LinePlanFrameId"]);

            if (!string.IsNullOrEmpty(Convert.ToString(UnitId)))
            {
                Inhouse = AdminController.getProdctionIDInhouse(Convert.ToString(UnitId));
            }

            //if (UnitId == 3 || UnitId == 11)
            if(Inhouse == true)
            {
              if (Request.QueryString["LineNo"] != null)
              {
                LineNo = Convert.ToInt32(Request.QueryString["LineNo"]);
              }
            }
            else
            {
              if (Request.QueryString["LineNo"] != null)
              {
                LineNoOutHouse = Request.QueryString["LineNo"].ToString();
              }
            }
            if (Request.QueryString["StyleCode"] != null)
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if (Request.QueryString["IsHalfStitch"] != null)
            {
                IsHalfStitch = Convert.ToInt32(Request.QueryString["IsHalfStitch"]);
            }
            if (Request.QueryString["StyleId"] != null)
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            }
            if (Request.QueryString["StyleNumber"] != null)
            {
                StyleNumber = Request.QueryString["StyleNumber"].ToString();
            }

            hdnUnitId.Value = UnitId.ToString();
            //if (UnitId == 3 || UnitId == 11)
            if (Inhouse == true)
            {
              hdnLineNo.Value = LineNo.ToString();

            }
            else
            {
              hdnLineNo.Value = LineNoOutHouse;
            }
            ViewState["RowCount"] = null;

            txtStartDate.Attributes.Add("ReadOnly", "ReadOnly");

            if (!IsPostBack)
            {             

                lblFactory.Text =  UnitName;
                //if (UnitId == 3 || UnitId == 11)
                if (Inhouse == true)
                {
                  lblLineNo.Text = LineNo.ToString();
                  
                }
                else
                {
                  lblLineNo.Text = LineNoOutHouse.ToString();
                  linetextspan.Visible = false;
                  lblLineNo.Visible = false;
                }
                FillLinePlanFrame();

                if (StyleCode != "")
                {                   
                    txtStyleCode.Text = StyleCode;
                    txtStyleCode.Enabled = false;
                    btnSubmit.Style.Add("display", "");
                    gvNextChangeOverStyleDetail.Visible = true;
                    tdMessage.Visible = true;
                    lblFrame.Text = "Frame No. ";
                    lblFrameNo.Text = LinePlanFrameId.ToString();
                    
                    if (IsHalfStitch == 1)
                    {
                        if (StyleNumber != "")
                        {
                            ChkHalfStitch.Checked = true;
                            ChkHalfStitch.Enabled = false;                                                  
                            BindData(StyleCode, StyleId);
                        }
                    }
                    else
                    {
                        GetSamOB(StyleCode, -1);
                        BindData(StyleCode, -1);
                    }                
                }
                else
                {
                    FillStyleCode(UnitId, LineNo);
                }
            }
            SetPermissionSubbtn();
        }
        //abhishek
        public void SetPermissionSubbtn()
        {
          if ((ApplicationHelper.LoggedInUser.UserData.UserID == 6) ||
            (ApplicationHelper.LoggedInUser.UserData.UserID == 42 ||
            ApplicationHelper.LoggedInUser.UserData.UserID == 646 || ApplicationHelper.LoggedInUser.UserData.UserID == 488 ||
            ApplicationHelper.LoggedInUser.UserData.UserID == 655 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 46 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 158
            || ApplicationHelper.LoggedInUser.UserData.UserID == 1019))
          {
            btnSubmit.Visible = true;
          }
          else          
          {
            btnSubmit.Visible = false;
          }
          //GetSamOB(StyleCode, -1);
        }
        private void FillLinePlanFrame()
        {
          DataTable dtFrame;
          //if (UnitId == 3 || UnitId == 11)
          if (Inhouse == true)
          {
            dtFrame = AdminController.GetLinePlanFrame(UnitId, LineNo, LinePlanFrameId);
          }
          else
          {
            dtFrame = AdminController.GetLinePlanFrame_outhouse(UnitId, LineNo, LinePlanFrameId);//abhishek
          }
            if (dtFrame.Rows.Count > 0)
            {
                ddlFrame.DataSource = dtFrame;
                ddlFrame.DataValueField = "LinePlanFrameId";
                ddlFrame.DataTextField = "LinePlanFrame";
                ddlFrame.DataBind();
                //if (dtFrame.Rows.Count > 1)
                //{
                //    ddlFrame.Items.Insert(0, new ListItem("Select", "0"));
                //}

                if (rbtnList.SelectedValue == "2")
                    IsParallel = true;
                else
                    IsParallel = false;
                if (ddlFrame.SelectedValue == "0")
                {
                    txtStartDate.Enabled = false;
                    ddlStartSlot.Enabled = false;
                }
                else
                {
                    txtStartDate.Enabled = true;
                    ddlStartSlot.Enabled = true;
                }


                SeqFrameId = Convert.ToInt32(ddlFrame.SelectedValue);
                DataTable dtDate = AdminController.GetStartDate(UnitId, LineNo, LinePlanFrameId, SeqFrameId, IsParallel);
                if (dtDate.Rows.Count > 0)
                { int StartSlot=0;
                    DateTime dtStartDate = Convert.ToDateTime(dtDate.Rows[0]["StartDate"]);                  
                      StartSlot  = Convert.ToInt32(dtDate.Rows[0]["StartSlot"].ToString());
                
                    if (dtStartDate > DateTime.Today)
                        txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                    else
                        txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                    //if (UnitId == 3 || UnitId == 11)
                    if (Inhouse == true)
                    {
                      if (StartSlot != 0)
                      {
                        ddlStartSlot.SelectedValue = StartSlot.ToString();
                      }
                    }
                    else
                    {
                        ddlStartSlot.SelectedValue = StartSlot.ToString();
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

        private void FillStyleCode(int UnitId, int LineNumber)
        {
          string StylePrefix = txtSearch.Text;

          Session["UnitID"] = UnitId;
          Session["LineNumber"] = LineNumber;
          Session["status"] = Convert.ToString(Request.QueryString["status"]);
          Session["StylePrefix"] = StylePrefix;

            
            ddlStyleCode.DataSource = AdminController.GetStyleCodeDetails(UnitId, LineNumber, Convert.ToString(Request.QueryString["status"]), StylePrefix);
            ddlStyleCode.DataValueField = "StyleCode";
            ddlStyleCode.DataTextField = "StyleCode";
            ddlStyleCode.DataBind();
            ddlStyleCode.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        private string GetExistLinePlanFrame(string StyleCodeStr)
        {
            string FrameIdLength = AdminController.GetExistLinePlanFrame(UnitId, LineNo, StyleCodeStr);
            return FrameIdLength;
        }

        private void GetSamOB(string StyleCodeStr, int StyleId)
        {
            DataSet ds = AdminController.Get_SAM_OB_ByStyleCode(StyleCodeStr, StyleId, UnitId);
            DataTable dtSAM = ds.Tables[0];
            DataTable dtOB = ds.Tables[1];
            if (dtSAM.Rows.Count > 0)
            {
                if (StyleId != -1) 
                {
                    hdnStyleId.Value = StyleId.ToString();
                    lblStitchSam.Text = dtSAM.Rows[0]["Sam"].ToString();
                    lblStitchSam.Visible = true;
                    ddlStitchSAM.Visible = false;
                }
                else
                {
                    ddlStitchSAM.DataSource = dtSAM;
                    ddlStitchSAM.DataTextField = "Sam";
                    ddlStitchSAM.DataValueField = "StyleId";
                    ddlStitchSAM.DataBind();
                    if(dtSAM.Rows.Count > 1)
                        ddlStitchSAM.Items.Insert(0, new ListItem("Select", "0"));

                    ddlStitchSAM.Visible = true;
                    lblStitchSam.Visible = false;
                }
            }
            if (dtOB.Rows.Count > 0)
            {
                if (StyleId != -1)
                {
                    lblStitchOB.Text = dtSAM.Rows[0]["OB"].ToString();
                    lblStitchOB.Visible = true;
                    ddlStitchOB.Visible = false;
                    lblOr.Visible = false;
                    txtStitchOB.Visible = false;
                }
                else
                {
                    ddlStitchOB.DataSource = dtOB;
                    ddlStitchOB.DataTextField = "OB";
                    ddlStitchOB.DataValueField = "OB";
                    ddlStitchOB.DataBind();
                    if (dtOB.Rows.Count != 1)
                    {
                        ddlStitchOB.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else
                    {
                        bContinue = false;
                        ddlStitchOB.Visible = false;
                        lblws_OB.Visible = false;
                        lblSingleOB.Text = "Plan OB " + dtOB.Rows[0]["OB"].ToString();
                        lblSingleOB.Visible = true;
                    }
                  
                    lblOr.Visible = true;
                    txtStitchOB.Visible = true;
                    lblStitchOB.Visible = false;
                }
            }           
        }

        private void BindData(string StyleCodeStr, int StyleId)
        {
            int HalfStitchCount = 0;
            DataTable dt = AdminController.GetStyleDetail_LinePlan(UnitId, LineNo, StyleCodeStr, LinePlanFrameId, StyleId);
            DataTable dtGrid = AdminController.GetContractStyleDetail_Grid(UnitId, LineNo, StyleCodeStr, StyleId, LinePlanFrameId, IsHalfStitch);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SeqFrameId"].ToString() != "")
                {
                    ddlFrame.SelectedValue = dt.Rows[0]["SeqFrameId"].ToString();
                    rbtnList.SelectedValue = Convert.ToInt16(dt.Rows[0]["IsParallel"]) == 0 ? "1" : "2";

                    txtStartDate.Enabled = false;
                    ddlStartSlot.Enabled = false;
                }
                else
                {
                    if (LinePlanFrameId != 0)
                    {
                        ddlFrame.Style.Add("display", "none");
                        rbtnList.Enabled = false;
                    }
                    else
                    {
                        ddlFrame.SelectedValue = "0";
                        rbtnList.SelectedValue = Convert.ToInt16(dt.Rows[0]["IsParallel"]) == 0 ? "1" : "2";
                    }
                    txtStartDate.Enabled = false;
                    ddlStartSlot.Enabled = false;
                }
                int FrameStyleId = Convert.ToInt32(dt.Rows[0]["FrameStyleId"]);
                double Sam = Convert.ToDouble(dt.Rows[0]["Sam"]);
                if (Sam != 0)
                {
                    if (StyleId != -1)
                    {
                        hdnStyleId.Value = StyleId.ToString();
                        lblStitchSam.Text = Sam.ToString();
                        lblStitchSam.Visible = true;
                        ddlStitchSAM.Visible = false;
                    }
                    else
                    {
                        if (ddlStitchSAM.Items.FindByValue(FrameStyleId.ToString()) != null)
                            ddlStitchSAM.SelectedValue = FrameStyleId.ToString();
                        else
                            ddlStitchSAM.Enabled = true;

                        ddlStitchSAM.Visible = true;
                        lblStitchSam.Visible = false;
                    }
                }
                int OB = Convert.ToInt32(dt.Rows[0]["OB"]);
                int NewOB = Convert.ToInt32(dt.Rows[0]["NewOB"]);

                if (StyleId != -1)
                {
                    lblStitchOB.Text = OB.ToString() == "0" ? NewOB.ToString() : OB.ToString();
                    lblStitchOB.Visible = true;
                    lblws_OB.Visible = true;
                    ddlStitchOB.Visible = false;
                    lblOr.Visible = false;
                    txtStitchOB.Visible = false;
                }
                else
                {                    
                    if (OB != 0)
                    {
                        if (ddlStitchOB.Items.FindByValue(OB.ToString()) != null)
                            ddlStitchOB.SelectedValue = OB.ToString();
                        else
                            ddlStitchOB.Enabled = true;
                    }                    
                    if (NewOB != 0)
                    {
                        txtStitchOB.Text = NewOB.ToString();
                    }
                    lblStitchOB.Visible = false;
                    if (bContinue == false)
                    {
                        ddlStitchOB.Visible = false;
                        lblws_OB.Visible = false;
                    }
                    else
                    {
                        ddlStitchOB.Visible = true;
                        lblws_OB.Visible = true;
                    }
                    lblOr.Visible = true;
                    txtStitchOB.Visible = true;
                }


                if (dt.Rows[0]["StartDate"].ToString() != "")
                {
                    DateTime dtStartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                    txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                }
                
                int StartSlot = Convert.ToInt32(dt.Rows[0]["StartSlot"]);
                if (StartSlot != 0)
                {
                    ddlStartSlot.SelectedValue = StartSlot.ToString();                    
                }
                lblStartSlot.Text = dt.Rows[0]["StartSlotTime"].ToString();

                if (dt.Rows[0]["EndDate"].ToString() != "")
                {
                    DateTime dtEndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                    txtEndDate.Text = dtEndDate.ToString("dd MMM yy (ddd)");
                }
                
                int EndSlot = Convert.ToInt32(dt.Rows[0]["EndSlot"]);
                if (EndSlot != 0)
                {
                    txtEndSlot.Text = EndSlot.ToString();                    
                }
                lblEndSlotTime.Text = dt.Rows[0]["EndSlotTime"].ToString();
                int IsStitching = Convert.ToInt32(dt.Rows[0]["IsStitching"]);

                if (IsStitching == 1)
                {
                    txtStartDate.Enabled = false;
                    ddlStartSlot.Enabled = false;
                    rbtnList.Enabled = false;
                    ddlFrame.Enabled = false;
                    chkFrameComplete.Visible = true;
                }

                HalfStitchCount = dt.Rows[0]["HalfStitchCount"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["HalfStitchCount"]) : 0;
             }
            //else if (dtGrid.Rows.Count > 0)
            //{
            //    DateTime dtStartDate = dtGrid.Rows[0]["PrevStartDate"] != DBNull.Value ? Convert.ToDateTime(dtGrid.Rows[0]["PrevStartDate"]) : DateTime.Now;
            //    txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");

            //    int LastSlot = Convert.ToInt32(dtGrid.Rows[0]["LastSlot"]);
            //    if (LastSlot != 0)
            //    {
            //        ddlStartSlot.SelectedValue = LastSlot.ToString();
            //    }
            //}

            
            if (dtGrid.Rows.Count > 0)
            {
                gvNextChangeOverStyleDetail.DataSource = dtGrid;
                gvNextChangeOverStyleDetail.DataBind();
                if (gvNextChangeOverStyleDetail.Rows.Count > 0)
                {                    
                    btnSubmit.Style.Add("display", "");
                }
            }
            else                
                btnSubmit.Style.Add("display", "none");

            if (HalfStitchCount > 1)
            { 
                //btnSubmit.Style.Add("display", "none");
                txtStartDate.Enabled = false;
                ddlStartSlot.Enabled = false;
                gvNextChangeOverStyleDetail.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Disable", "DisablePage()", true);

            }
        }

        protected void ddlStyleCode_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (ChkHalfStitch.Checked)
            {
                if (ddlStyleCode.SelectedValue != "0")
                {                   
                    StyleCode = ddlStyleCode.SelectedValue;                    
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();                    
                    btnSubmit.Style.Add("display", "none");
                }
                else
                {
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();                    
                    btnSubmit.Style.Add("display", "none");
                }
            }
            else
            {
                if (ddlStyleCode.SelectedValue != "0")
                {     
                    StyleCode = ddlStyleCode.SelectedValue;
                    txtSearch.Text = "";
                    GetSamOB(StyleCode, -1);
                    BindData(StyleCode, -1);                
                    btnSubmit.Style.Add("display", "");
                }

                else
                {
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();
                    btnSubmit.Style.Add("display", "none");                    
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Style.Add("display", "none");
            int iDelete = 0, LinePlanFrameIdOutput = 0;
            LinePlan objLinePlan = new LinePlan();

            objLinePlan.UnitId = UnitId;
            objLinePlan.LineNo = LineNo;
            objLinePlan.LinePlanFrameId = LinePlanFrameId;
            objLinePlan.CombinedFrameId = CombinedFrameId;
         
            objLinePlan.IsHalfStitched = ChkHalfStitch.Checked;
            

            if (chkFrameComplete.Checked)
            {
                try
                {
                    int FrameComplete = AdminController.CompleteLinePlanFrame(UnitId, LineNo, LinePlanFrameId);
                    if (FrameComplete > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "&Enabled=false');", true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            else
            {

                if (rbtnList.SelectedValue == "2")
                    objLinePlan.IsParallel = true;
                else
                    objLinePlan.IsParallel = false;

                if (ddlFrame.Items.Count > 0)
                    objLinePlan.SeqFrameId = Convert.ToInt32(ddlFrame.SelectedValue);


                if (txtStyleCode.Text != "")
                {
                    objLinePlan.StyleCode = txtStyleCode.Text;
                    if (ChkHalfStitch.Checked)
                    {
                        objLinePlan.SamStyleId = hdnStyleId != null ? Convert.ToInt32(hdnStyleId.Value) : 0;
                        objLinePlan.Sam = lblStitchSam.Text == "" ? 0 : Math.Round(Convert.ToDouble(lblStitchSam.Text), 2);  
                        objLinePlan.OB = lblStitchOB.Text == "" ? 0 : Convert.ToInt32(lblStitchOB.Text);
                    }
                    else
                    {
                        string SamText = ddlStitchSAM.SelectedItem.Text;
                        string[] SamSplit = SamText.Split('(');
                        objLinePlan.Sam = Math.Round(Convert.ToDouble(SamSplit[0].ToString().Trim()), 2);  

                        objLinePlan.SamStyleId = Convert.ToInt32(ddlStitchSAM.SelectedValue);
                        if (ddlStitchOB.Visible == true)
                        {
                            if (ddlStitchOB.SelectedValue != "0")
                                objLinePlan.OB = Convert.ToInt32(ddlStitchOB.SelectedValue);
                            else
                            {
                                if (txtStitchOB.Text != "")
                                    objLinePlan.NewOB = Convert.ToInt32(txtStitchOB.Text);
                            }
                        }
                        else
                        {
                            if (txtStitchOB.Text != "")
                            {
                                objLinePlan.NewOB = Convert.ToInt32(txtStitchOB.Text);
                            }
                            else
                            {
                                lblSingleOB.Text = lblSingleOB.Text.Replace("Plan OB", "");
                                lblSingleOB.Text = lblSingleOB.Text.Trim();
                                objLinePlan.OB = Convert.ToInt32(lblSingleOB.Text);
                            }
                        }
                    }
                    objLinePlan.StartDate = txtStartDate.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtStartDate.Text).Value;
                    objLinePlan.StartSlot = Convert.ToInt32(ddlStartSlot.SelectedValue);
                    objLinePlan.TotalQty = Convert.ToInt32(hdnTotalQty.Value);

                    if (LinePlanFrameId != 0)
                    {
                        iDelete = AdminController.DeleteLinePlanning(objLinePlan.UnitId, objLinePlan.LineNo, objLinePlan.StyleCode, objLinePlan.LinePlanFrameId);
                    }

                    foreach (GridViewRow gvr in gvNextChangeOverStyleDetail.Rows)
                    {
                        CheckBox chk = (CheckBox)gvr.FindControl("chk");
                        if (chk.Checked)
                        {
                            HiddenField hdnStyleId = (HiddenField)gvr.FindControl("hdnStyleId");
                            HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnOrderId");
                            HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                            HiddenField hdnContractQty = (HiddenField)gvr.FindControl("hdnContractQty");
                            HiddenField hdnUnitQty = (HiddenField)gvr.FindControl("hdnUnitQty");
                            TextBox txtLineQty = (TextBox)gvr.FindControl("txtLineQty");

                            objLinePlan.StyleId = Convert.ToInt32(hdnStyleId.Value);
                            objLinePlan.OrderID = Convert.ToInt32(hdnOrderId.Value);
                            objLinePlan.OrderDetailID = Convert.ToInt32(hdnOrderDetailId.Value);
                            objLinePlan.ContractQty = Convert.ToInt32(hdnContractQty.Value);
                            objLinePlan.UnitQty = Convert.ToInt32(hdnUnitQty.Value);
                            objLinePlan.LineQty = txtLineQty.Text == "" ? 0 : Convert.ToInt32(txtLineQty.Text);

                            int iSave = AdminController.InsertUpdateLinePlanning(objLinePlan, UserId, ref LinePlanFrameIdOutput);

                            if (LinePlanFrameIdOutput > 0)
                                objLinePlan.LinePlanFrameId = LinePlanFrameIdOutput;
                        }
                    }
                    if (!ChkHalfStitch.Checked)
                    {
                        if (ddlStitchSAM.SelectedValue != "0")
                        {
                            for (int i = 1; i < ddlStitchSAM.Items.Count; i++)
                            {
                                try
                                {
                                    objLinePlan.StyleId = Convert.ToInt32(ddlStitchSAM.Items[i].Value);

                                    string SamText = ddlStitchSAM.Items[i].Text;
                                    string[] SamSplit = SamText.Split('(');
                                    objLinePlan.Sam = Math.Round(Convert.ToDouble(SamSplit[0].ToString().Trim()), 2);

                                    if (objLinePlan.StyleId == Convert.ToInt32(ddlStitchSAM.SelectedValue))
                                        objLinePlan.IsActive = true;
                                    else
                                        objLinePlan.IsActive = false;

                                    int iSaveSam = AdminController.Insert_SAMLinePlan(objLinePlan.LinePlanFrameId, objLinePlan.StyleId, objLinePlan.Sam, objLinePlan.IsActive);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                                }
                            }
                        }
                    }
                    if (objLinePlan.TotalQty > 0)
                    {
                        try
                        {
                            int SavePlan = AdminController.Create_PlanDate_ByLinePlanFrameID(objLinePlan.LinePlanFrameId);

                            int CreateEndDate = AdminController.Update_Start_EndDate_ByLinePlanFrameId(objLinePlan.LinePlanFrameId, objLinePlan.StyleCode, objLinePlan.UnitId, objLinePlan.LineNo, objLinePlan.TotalQty);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        }
                        if (Convert.ToInt32(Request.QueryString["ProductionUnit"]) > 0 && Convert.ToString(Request.QueryString["Enabled"]) == "false")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "&Enabled=false');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "');", true);
                        }
                    }
                    else
                        btnSubmit.Style.Add("display", "none");
                }
            }
        }

        protected void gvNextChangeOverStyleDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkHeaderId = (CheckBox)e.Row.FindControl("chkHeaderId");

                if (LinePlanFrameId == 0)
                    chkHeaderId.Checked = true;
                else
                    chkHeaderId.Enabled = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnLinePlanId = (HiddenField)e.Row.FindControl("hdnLinePlanId");
                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                CheckBox chk = (CheckBox)e.Row.FindControl("chk");
                TextBox txtLineQty = (TextBox)e.Row.FindControl("txtLineQty");
                HiddenField hdnIsStitching = (HiddenField)e.Row.FindControl("hdnIsStitching");
                Label lblStitchQty = (Label)e.Row.FindControl("lblStitchQty");
                Label lblQtyPlan = (Label)e.Row.FindControl("lblQtyPlan");
                Label lblContractQty = (Label)e.Row.FindControl("lblContractQty");
                Label lblUnitQty = (Label)e.Row.FindControl("lblUnitQty");

                Decimal ContractQty = DataBinder.Eval(e.Row.DataItem, "ContractQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ContractQty"));
                Decimal UnitQty = DataBinder.Eval(e.Row.DataItem, "UnitQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitQty"));
                int QtyPlan = DataBinder.Eval(e.Row.DataItem, "RemainLineQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RemainLineQty"));
                Decimal StitchedQty = DataBinder.Eval(e.Row.DataItem, "StichedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StichedQty"));
                bool IsHold = DataBinder.Eval(e.Row.DataItem, "ContractStatus") == DBNull.Value ? false : Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "ContractStatus"));
                //updated By Prabhaker 03-Jan-18
                if (ContractQty != 0 && ContractQty >= 1000)
                {
                    Decimal ContractQtyNew = Math.Round(ContractQty / 1000, 1);
                    if (ContractQtyNew < 100)
                    {
                        lblContractQty.Text = ContractQtyNew.ToString() + " k";
                        lblContractQty.ToolTip = "Contract Qty:- " + ContractQty;
                    }
                    else
                    {
                        ContractQtyNew = Math.Round(ContractQtyNew, 0);
                        lblContractQty.Text = ContractQtyNew.ToString() + " k";
                        lblContractQty.ToolTip = "Contract Qty:- " + ContractQty;
                    }
                }
                else
                {
                    lblContractQty.Text = ContractQty == 0 ? "" : ContractQty.ToString("#,##0");
                    lblContractQty.ToolTip = "Contract Qty:- " + ContractQty;
                }

                if (UnitQty != 0 && UnitQty > 1000)
                {
                    Decimal UnitQtyNew = Math.Round(UnitQty / 1000, 1);
                    if (UnitQtyNew < 100)
                    {
                        lblUnitQty.Text = UnitQtyNew.ToString() + " k";
                        lblUnitQty.ToolTip = "Unit Qty:- " + UnitQty;
                    }
                    else
                    {
                        UnitQtyNew = Math.Round(UnitQtyNew, 0);
                        lblUnitQty.Text = UnitQtyNew.ToString() + " k";
                        lblUnitQty.ToolTip = "Unit Qty:- " + UnitQty;
                    }
                }
                else
                {
                    lblUnitQty.Text = UnitQty == 0 ? "" : UnitQty.ToString("#,##0");
                    lblUnitQty.ToolTip = "Unit Qty:- " + UnitQty;
                }
                if (StitchedQty != 0 && StitchedQty > 1000)
                {
                    Decimal StitchedQtyNew = Math.Round(StitchedQty / 1000, 1);
                    if (StitchedQtyNew < 100)
                    {
                        lblStitchQty.Text = StitchedQtyNew.ToString() + " k";
                        lblStitchQty.ToolTip = "Stitched Qty:- " + StitchedQty;
                    }
                    else
                    {
                        StitchedQtyNew = Math.Round(StitchedQtyNew, 0);
                        lblStitchQty.Text = StitchedQtyNew.ToString() + " k";
                        lblStitchQty.ToolTip = "Stitched Qty:- " + StitchedQty;
                    }
                }
                else
                {
                    lblStitchQty.Text = StitchedQty == 0 ? "" : StitchedQty.ToString("#,##0");
                    lblStitchQty.ToolTip = "Stitched Qty:- " + StitchedQty;
                }
                //-----------End Of Code------------------//
               // lblStitchQty.Text = StitchedQty == 0 ? "" : StitchedQty.ToString("#,##0");

                if (LinePlanFrameId == 0)
                {
                    
                    txtLineQty.Text = QtyPlan == 0 ? "" : QtyPlan.ToString();
                    lblQtyPlan.Text = "";
                    if(QtyPlan > 0)
                        chk.Checked = true;
                }
                else
                {
                    lblQtyPlan.Text = QtyPlan == 0 ? "" : QtyPlan.ToString("#,##0");
                }

                if (hdnLinePlanId.Value != "0")
                {
                    if(txtLineQty.Text != "")
                        chk.Checked = true;
                }
              
                if (txtLineQty.Text == "0")
                    txtLineQty.Text = "";
                
                if (hdnIsStitching.Value == "1")               
                    chk.Enabled = false;

                //----------Edit by surendra on 21 Jan 2019,for hold contract,check box should not enabled..
                if (IsHold && txtLineQty.Text=="")
                {
                    //chk.Checked = false;
                    chk.Enabled = false;
                    chk.ToolTip = "This contract is on hold";
                }
              //if(Request.QueryString["status"]!=null)
              //{
              //  if (Request.QueryString["status"].ToString() == "add")
              //  {
              //    if (IsHold)
              //    {
              //      chk.Checked = false;
              //      chk.Enabled = false;
              //      chk.ToolTip = "This contract is on hold";
              //    }
              //  }
              //}
               
            }
        }
        
        protected void gvNextChangeOverStyleDetail_DataBound(object sender, EventArgs e)
        {
            
            for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
            {               
                GridViewRow row = gvNextChangeOverStyleDetail.Rows[i]; 
                HiddenField hdnLinePlanId = (HiddenField)row.FindControl("hdnLinePlanId");
                HiddenField hdnRemainLineQty = (HiddenField)row.FindControl("hdnRemainLineQty");                
                if (i > 0)
                {      
                    GridViewRow previousRow = gvNextChangeOverStyleDetail.Rows[i - 1];                        

                    Label lblStyleNo = (Label)row.Cells[0].FindControl("lblStyleNo");
                    Label lblPreviousStyleNo = (Label)previousRow.Cells[0].FindControl("lblStyleNo");

                    if (lblStyleNo.Text == lblPreviousStyleNo.Text)
                    {
                        RowSpan = RowSpan + 1;

                        if (RowSpan > 2)
                        {
                            GridViewRow firstRow = gvNextChangeOverStyleDetail.Rows[i - (RowSpan - 1)];
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
               
        protected void ChkHalfStitch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkHalfStitch.Checked == true)
            {
                if (txtStyleCode.Text != "")
                {                    
                    StyleCode = txtStyleCode.Text;
                    ddlStitchSAM.Items.Clear();
                    ddlStitchSAM.Items.Insert(0, new ListItem("Select", "0"));

                    ddlStitchOB.Items.Clear();
                    ddlStitchOB.Items.Insert(0, new ListItem("Select", "0"));

                    txtStartDate.Text = "";
                    ddlStartSlot.SelectedIndex = 0;

                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();                    
                    btnSubmit.Style.Add("display", "none");
                }
                else
                {
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();                    
                    btnSubmit.Style.Add("display", "none");
                }
            }
            else
            {
                txtStyleCode.Text = "";               

                ddlStitchSAM.Items.Clear();
                ddlStitchSAM.Items.Insert(0, new ListItem("Select", "0"));

                ddlStitchOB.Items.Clear();
                ddlStitchOB.Items.Insert(0, new ListItem("Select", "0"));

                txtStartDate.Text = "";
                ddlStartSlot.SelectedIndex = 0;

                txtSearch.Text = "";
                gvNextChangeOverStyleDetail.DataSource = null;
                gvNextChangeOverStyleDetail.DataBind();                
                btnSubmit.Style.Add("display", "none");
            }
        }

        protected void btnStyleCode_Click(object sender, EventArgs e)
        {                       
            btnSubmit.Style.Add("display", "none");
            string FrameIdLength = "";
            dvExsitFrame.Style.Add("display", "none");
            if (ChkHalfStitch.Checked)
            {
                if (txtStyleCode.Text != "")
                {
                    StyleCode = txtStyleCode.Text;
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();
                    btnSubmit.Style.Add("display", "none");
                }
                else
                {
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();
                    btnSubmit.Style.Add("display", "none");
                }
            }
            else
            {
                if (txtStyleCode.Text != "")
                {
                    StyleCode = txtStyleCode.Text;
                    txtSearch.Text = "";
                    FrameIdLength = GetExistLinePlanFrame(StyleCode);
                    if (FrameIdLength != "")
                    {
                        dvExsitFrame.Style.Add("display", "");
                        lblMsgExistFrame.Text = "Frame no. <span style='font-weight:bold;'>" + FrameIdLength + "</span> already exist with same style code, Line & Unit, you can edit the frame <span style='font-weight:bold;'>(" + FrameIdLength + ")</span> and include remaining contract";
                    }
                    GetSamOB(StyleCode, -1);
                    BindData(StyleCode, -1);
                    btnSubmit.Style.Add("display", "");
                }

                else
                {
                    txtSearch.Text = "";
                    gvNextChangeOverStyleDetail.DataSource = null;
                    gvNextChangeOverStyleDetail.DataBind();
                    btnSubmit.Style.Add("display", "none");
                }
            }
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
                DataTable dtFrame = AdminController.GetStartDate(UnitId, LineNo, LinePlanFrameId, SeqFrameId, IsParallel);
                if (dtFrame.Rows.Count > 0)
                {
                    DateTime dtStartDate = Convert.ToDateTime(dtFrame.Rows[0]["StartDate"]);
                    int StartSlot = Convert.ToInt32(dtFrame.Rows[0]["StartSlot"]);

                    if(dtStartDate > DateTime.Today)
                        txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                    else
                        txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");  
                    
                    if (StartSlot != 0)
                    {
                        ddlStartSlot.SelectedValue = StartSlot.ToString();                        
                    }
                    txtStartDate.Enabled = false;
                }
            }          
        }

        protected void ddlFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlFrame.SelectedValue != "0")
            //{
            if (rbtnList.SelectedValue == "2")
                IsParallel = true;
            else
                IsParallel = false;

            int ParallelFrameId = Convert.ToInt32(ddlFrame.SelectedValue);
            DataTable dtFrame = AdminController.GetStartDate(UnitId, LineNo, -1, ParallelFrameId, IsParallel);
            if (dtFrame.Rows.Count > 0)
            {
                DateTime dtStartDate = Convert.ToDateTime(dtFrame.Rows[0]["StartDate"]);
                int StartSlot = Convert.ToInt32(dtFrame.Rows[0]["StartSlot"]);
                txtStartDate.Enabled = true;
                ddlStartSlot.Enabled = true;
                if (dtStartDate > DateTime.Today)
                    txtStartDate.Text = dtStartDate.ToString("dd MMM yy (ddd)");
                else
                    txtStartDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                if (StartSlot != 0)
                {
                    ddlStartSlot.SelectedValue = StartSlot.ToString();
                }
                txtStartDate.Enabled = false;
                ddlStartSlot.Enabled = false;
            }
            else
            {
                txtStartDate.Enabled = true;
                ddlStartSlot.Enabled = true;
                txtStartDate.Text = "";
                ddlStartSlot.SelectedValue = "0";
                txtStartDate.Enabled = false;
                ddlStartSlot.Enabled = false;
            }
        }

        protected void chkFrameComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFrameComplete.Checked)
                gvNextChangeOverStyleDetail.Enabled = false;
            else
                gvNextChangeOverStyleDetail.Enabled = true;
        }
      
        
    }
}