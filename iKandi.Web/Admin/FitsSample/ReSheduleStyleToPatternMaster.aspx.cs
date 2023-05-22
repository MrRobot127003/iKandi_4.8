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

namespace iKandi.Web.Internal.Design
{
    public partial class SampleAllocToPatternMaster : BasePage
    {
        FITsController fitsobj = new FITsController(ApplicationHelper.LoggedInUser);
        int Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
        string StyleNumber = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["StyleNumber"])
            {
                StyleNumber = Request.QueryString["StyleNumber"].ToString();
            }
            if (!IsPostBack)
            {
                BindMaster();
                BindClient();
                BindStatus();
                GetReschedule_StyleToPattern();
            }
        }

        private void BindMaster()
        {
            List<SamplePattern> objSamplePattern = FITsControllerInstance.CADMaster();
            if (objSamplePattern.Count > 0)
            {
                ddlMasterNameSelect.DataSource = objSamplePattern;
                ddlMasterNameSelect.DataTextField = "MasterName";
                ddlMasterNameSelect.DataValueField = "CADMasterRoleID";
                ddlMasterNameSelect.DataBind();
                ddlMasterNameSelect.Items.Insert(0, "Select");

                //ddlDeptParent.Items.Insert(0, "Select");
                //ddlDeptNameSelect.Items.Insert(0, "Select");
                
               
            }
        }

        private void BindClient()
        {
            try
            {
                List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_Client_ByAutoAllocPattern();
                if (objSamplePattern.Count > 0)
                {
                    ddlClientNameSelect.DataSource = objSamplePattern;
                    ddlClientNameSelect.DataTextField = "ClientName";
                    ddlClientNameSelect.DataValueField = "ClientId";
                    ddlClientNameSelect.DataBind();
                    ddlClientNameSelect.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void BindStatus()
        {
            try
            {
                List<SamplePattern> objSamplePattern = FITsControllerInstance.GetAutoAllocation_Status();
                if (objSamplePattern.Count > 0)
                {
                    ddlTypeNameSelect.DataSource = objSamplePattern;
                    ddlTypeNameSelect.DataTextField = "Status";
                    ddlTypeNameSelect.DataValueField = "Status";
                    ddlTypeNameSelect.DataBind();
                    ddlTypeNameSelect.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void GetReschedule_StyleToPattern()
        {
            SamplePattern objSample = new SamplePattern();
            objSample.StyleNumber = txtsearch.Value == "" ? StyleNumber : txtsearch.Value;
            objSample.FromDate = txtfrom.Value != "" ? DateTime.ParseExact(txtfrom.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            objSample.ToDate = txtTo.Value != "" ? DateTime.ParseExact(txtTo.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            objSample.CrossBarrier = Convert.ToBoolean(chkCrossBarrier.Checked);
            objSample.CADMasterRoleID = ddlMasterNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlMasterNameSelect.SelectedValue);
            objSample.ClientId = ddlClientNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlClientNameSelect.SelectedValue);
            objSample.ClientDeptid = ddlDeptNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlDeptNameSelect.SelectedValue);
            objSample.ClientParentDeptid = ddlDeptParent.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlDeptParent.SelectedValue);
            objSample.Status = ddlTypeNameSelect.SelectedValue == "Select" ? "" : ddlTypeNameSelect.SelectedValue;

            gvSampleAllocPatterMaster.DataSource = null;
            gvSampleAllocPatterMaster.DataBind();
            List<SamplePattern> objSamplePattern = FITsControllerInstance.GetReschedule_StyleToPattern(objSample, Userid); //objFits.GetReschedule_StyleToPattern(Userid);
            if (objSamplePattern.Count > 0)
            {
                gvSampleAllocPatterMaster.DataSource = objSamplePattern;
                gvSampleAllocPatterMaster.DataBind();

                gvSampleAllocPatterMaster.Columns[6].Visible = false;
            }
            else
            {
                gvSampleAllocPatterMaster.DataSource = null;
                gvSampleAllocPatterMaster.DataBind();
                btnTopSubmit.Visible = false;
            }
        }

        protected void gvSampleAllocPatterMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgbtnTop = e.Row.FindControl("ImgbtnTop") as ImageButton;
                ImageButton ImgbtnBottom = e.Row.FindControl("ImgbtnBottom") as ImageButton;
                int MasterSequence = DataBinder.Eval(e.Row.DataItem, "MasterSequence") == null ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MasterSequence"));
                if (MasterSequence == 0)
                {
                    ImgbtnTop.Visible = false;
                    ImgbtnBottom.Visible = true;
                }
                if (MasterSequence == 1)
                {
                    ImgbtnTop.Visible = true;
                    ImgbtnBottom.Visible = false;
                }
                if (MasterSequence == -1)
                {
                    ImgbtnTop.Visible = true;
                    ImgbtnBottom.Visible = true;
                }

                DropDownList ddlMaster = (DropDownList)e.Row.FindControl("ddlMaster");
                HiddenField hdnCadMasterId = (HiddenField)e.Row.FindControl("hdnCadMasterID");
                List<SamplePattern> objSamplePattern = FITsControllerInstance.CADMaster();
                if (objSamplePattern.Count > 0)
                {
                    ddlMaster.DataSource = objSamplePattern;
                    ddlMaster.DataTextField = "MasterName";
                    ddlMaster.DataValueField = "CADMasterRoleID";
                    ddlMaster.DataBind();

                    if (hdnCadMasterId.Value != "")
                    {
                        ddlMaster.SelectedValue = hdnCadMasterId.Value;
                    }
                }

                Label lblCreation_FitsDate = (Label)e.Row.FindControl("lblCreation_FitsDate");
                DateTime CreationDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreatedOn"));
                DateTime FitsCommentDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsCommentDate"));
                if (CreationDate != DateTime.MinValue)
                {
                    if (FitsCommentDate != DateTime.MinValue)
                        lblCreation_FitsDate.Text = "(" + FitsCommentDate.ToString("dd MMM yy (ddd)") + ")";
                    else
                        lblCreation_FitsDate.Text = "(" + CreationDate.ToString("dd MMM yy (ddd)") + ")";
                }

                Label lblAM = (Label)e.Row.FindControl("lblAM");
                lblAM.Text = DataBinder.Eval(e.Row.DataItem, "AcountMgrName") == DBNull.Value ? "" : DataBinder.Eval(e.Row.DataItem, "AcountMgrName").ToString();

                Label lblPDM = (Label)e.Row.FindControl("lblPDM");
                lblPDM.Text = DataBinder.Eval(e.Row.DataItem, "PD_MarchentName") == DBNull.Value ? "" : DataBinder.Eval(e.Row.DataItem, "PD_MarchentName").ToString();

                Label lblSTCTargetDate = (Label)e.Row.FindControl("lblSTCTargetDate");
                lblSTCTargetDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")).ToString("dd MMM yy (ddd)");

                TextBox txtAllocationDate = (TextBox)e.Row.FindControl("txtAllocationDate");
                txtAllocationDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "AllocationDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "AllocationDate")).ToString("dd MMM yy (ddd)");

                Label lblHandOverEta = (Label)e.Row.FindControl("lblHandOverEta");
                lblHandOverEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")).ToString("dd MMM yy (ddd)");

                Label lblPatternETA = (Label)e.Row.FindControl("lblPatternETA");
                lblPatternETA.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")).ToString("dd MMM yy (ddd)");

                Label lblSampleSentEta = (Label)e.Row.FindControl("lblSampleSentEta");
                lblSampleSentEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")).ToString("dd MMM yy (ddd)");

                Label lblSequence = (Label)e.Row.FindControl("lblSequence");
                lblSequence.Text = DataBinder.Eval(e.Row.DataItem, "SequenceID").ToString();

                int BarrierDays = DataBinder.Eval(e.Row.DataItem, "BarrierDays") == null ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BarrierDays"));

                DateTime BarrierDate = DateTime.Now.AddDays(-BarrierDays);
                if (txtAllocationDate.Text != "")
                {
                    if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "AllocationDate")) < Convert.ToDateTime(BarrierDate))
                    {
                        e.Row.CssClass = "Barrier";
                    }
                }

                if (chkCrossBarrier.Checked)
                    e.Row.CssClass = "Barrier";

            }
        }

        protected void gvSampleAllocPatterMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSampleAllocPatterMaster.PageIndex = e.NewPageIndex;
            GetReschedule_StyleToPattern();
        }

        protected void gvSampleAllocPatterMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SamplePattern objSamplePattern = new SamplePattern();
            if (e.CommandName == "Up")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                HiddenField hdnCadMasterID = (HiddenField)gvSampleAllocPatterMaster.Rows[id].FindControl("hdnCadMasterID");
                HiddenField hdnStyleId = (HiddenField)gvSampleAllocPatterMaster.Rows[id].FindControl("hdnStyleId");
                Label lblSequence = (Label)gvSampleAllocPatterMaster.Rows[id].FindControl("lblSequence");

                objSamplePattern.CADMasterRoleID = Convert.ToInt32(hdnCadMasterID.Value);
                objSamplePattern.Styleid = Convert.ToInt32(hdnStyleId.Value);
                objSamplePattern.SequenceId = Convert.ToInt32(lblSequence.Text);

                int UpId = id - 1;
                HiddenField hdnPrevStyleId = (HiddenField)gvSampleAllocPatterMaster.Rows[UpId].FindControl("hdnStyleId");
                Label lblPrevSequence = (Label)gvSampleAllocPatterMaster.Rows[UpId].FindControl("lblSequence");

                objSamplePattern.PrevStyleId = Convert.ToInt32(hdnPrevStyleId.Value);
                objSamplePattern.PrevSequenceId = Convert.ToInt32(lblPrevSequence.Text);

                bool iUpdate = FITsControllerInstance.Update_Reschedule_StyleToPattern(objSamplePattern, Userid, "ChangeSequenceUP");
                if (iUpdate == true)
                    GetReschedule_StyleToPattern();
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "alert('There is some problem to change Sequence');", true);



            }
            if (e.CommandName == "Down")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                HiddenField hdnCadMasterID = (HiddenField)gvSampleAllocPatterMaster.Rows[id].FindControl("hdnCadMasterID");
                HiddenField hdnStyleId = (HiddenField)gvSampleAllocPatterMaster.Rows[id].FindControl("hdnStyleId");
                Label lblSequence = (Label)gvSampleAllocPatterMaster.Rows[id].FindControl("lblSequence");

                objSamplePattern.CADMasterRoleID = Convert.ToInt32(hdnCadMasterID.Value);
                objSamplePattern.Styleid = Convert.ToInt32(hdnStyleId.Value);
                objSamplePattern.SequenceId = Convert.ToInt32(lblSequence.Text);

                int UpId = id + 1;
                HiddenField hdnNextStyleId = (HiddenField)gvSampleAllocPatterMaster.Rows[UpId].FindControl("hdnStyleId");
                Label lblNextSequence = (Label)gvSampleAllocPatterMaster.Rows[UpId].FindControl("lblSequence");

                objSamplePattern.NextStyleId = Convert.ToInt32(hdnNextStyleId.Value);
                objSamplePattern.NextSequenceId = Convert.ToInt32(lblNextSequence.Text);

                bool iUpdate = FITsControllerInstance.Update_Reschedule_StyleToPattern(objSamplePattern, Userid, "ChangeSequenceDown");
                if (iUpdate == true)
                    GetReschedule_StyleToPattern();
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "alert('There is some problem to change Sequence');", true);
            }
        }

        protected void ddlMaster_SelectedIndexChanged(Object sender, EventArgs e)
        {
            SamplePattern objSamplePattern = new SamplePattern();
            DropDownList ddlMaster = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMaster.NamingContainer;

            objSamplePattern.CADMasterRoleID = Convert.ToInt32(((DropDownList)sender).SelectedValue);

            HiddenField hdnCadMasterID = (HiddenField)row.FindControl("hdnCadMasterID");
            objSamplePattern.PrevCadMasterId = Convert.ToInt32(hdnCadMasterID.Value);

            HiddenField hdnStyleId = (HiddenField)row.FindControl("hdnStyleId");
            objSamplePattern.Styleid = Convert.ToInt32(hdnStyleId.Value);

            TextBox txtAllocationDate = (TextBox)row.FindControl("txtAllocationDate");
            if (txtAllocationDate.Text != "")
                objSamplePattern.AllocationDate = DateTime.ParseExact(txtAllocationDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);


            bool iUpdate = FITsControllerInstance.Update_Reschedule_StyleToPattern(objSamplePattern, Userid, "ChangeMaster");
            if (iUpdate == true)
                GetReschedule_StyleToPattern();
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "alert('There is some problem to update Master');", true);

        }

        protected void btnTopSubmit_Click(object sender, EventArgs e)
        {
            bool iUpdate = false;
            SamplePattern objSamplePattern = new SamplePattern();
            foreach (GridViewRow gvr in gvSampleAllocPatterMaster.Rows)
            {
                HiddenField hdnCadMasterID = (HiddenField)gvr.FindControl("hdnCadMasterID");
                HiddenField hdnStyleId = (HiddenField)gvr.FindControl("hdnStyleId");
                TextBox txtAllocationDate = (TextBox)gvr.FindControl("txtAllocationDate");

                objSamplePattern.CADMasterRoleID = Convert.ToInt32(hdnCadMasterID.Value);
                objSamplePattern.Styleid = Convert.ToInt32(hdnStyleId.Value);
                if (txtAllocationDate.Text != "")
                    objSamplePattern.AllocationDate = DateTime.ParseExact(txtAllocationDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);


                iUpdate = FITsControllerInstance.Update_Reschedule_StyleToPattern(objSamplePattern, Userid, "ChangeAllocationDate");
            }
            if (iUpdate == true)
                GetReschedule_StyleToPattern();
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "alert('There is some problem during save the data');", true);
        }
        protected void ddlClientNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
          int ClientID = 0;
          if (ddlClientNameSelect.SelectedValue == "Select" || ddlClientNameSelect.SelectedValue == "") 
          ClientID = -1;
          else
          ClientID = Convert.ToInt16(ddlClientNameSelect.SelectedValue);

          List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDeptsParent(ClientID, "Parent", -1);
          if (objSamplePattern.Count > 0)
          {
            ddlDeptParent.Items.Clear();
            ddlDeptParent.DataSource = objSamplePattern;
            ddlDeptParent.DataTextField = "DeptName";
            ddlDeptParent.DataValueField = "ClientDeptid";
            ddlDeptParent.DataBind();
            ddlDeptParent.Items.Insert(0, "Select");
          }
          else
          {
            ddlDeptParent.Items.Clear();
            ddlDeptParent.Items.Insert(0, "Select");

            ddlDeptNameSelect.Items.Clear();
            ddlDeptNameSelect.Items.Insert(0, "Select");
          }

        }
        protected void ddlDeptParent_SelectedIndexChanged(object sender, EventArgs e) 
        {
            int ClientID = 0;
            int ParentSelectedVal = 0;
            if (ddlClientNameSelect.SelectedValue == "Select" || ddlClientNameSelect.SelectedValue == "") 
            ClientID = -1;
            else
            ClientID = Convert.ToInt16(ddlClientNameSelect.SelectedValue);

            if (ddlDeptParent.SelectedValue == "Select" || ddlDeptParent.SelectedValue == "") 
            ParentSelectedVal = -1;
            else
            ParentSelectedVal = Convert.ToInt16(ddlDeptParent.SelectedValue);

            List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDeptsParent(ClientID, "SubParent", ParentSelectedVal);
            if (objSamplePattern.Count > 0)
            {
              ddlDeptNameSelect.Items.Clear();
              ddlDeptNameSelect.DataSource = objSamplePattern;
              ddlDeptNameSelect.DataTextField = "DeptName";
              ddlDeptNameSelect.DataValueField = "ClientDeptid";
              ddlDeptNameSelect.DataBind();
              ddlDeptNameSelect.Items.Insert(0, "Select");
            }
            else
            {
              ddlDeptNameSelect.Items.Clear();
              ddlDeptNameSelect.Items.Insert(0, "Select");
             
            }

        }
        //protected void ddlClientNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ClientController objClientController = new ClientController();
        //    if (ddlClientNameSelect.SelectedValue != "0")
        //    {
        //        List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDepts_ByAutoAllocPattern(Convert.ToInt32(ddlClientNameSelect.SelectedValue));
        //        //foreach (ClientDepartment cdept in objClientDepartment)
        //        //{
        //        //    ddlDeptNameSelect.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
        //        //}
        //        if (objSamplePattern.Count > 0)
        //        {
        //            ddlDeptNameSelect.DataSource = objSamplePattern;
        //            ddlDeptNameSelect.DataTextField = "DeptName";
        //            ddlDeptNameSelect.DataValueField = "ClientDeptid";
        //            ddlDeptNameSelect.DataBind();
        //            ddlDeptNameSelect.Items.Insert(0, "Select");
        //        }
        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetReschedule_StyleToPattern();
        }



    }
}