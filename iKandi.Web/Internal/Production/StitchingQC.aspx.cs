using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Production
{
    public partial class StitchingQC : System.Web.UI.Page
    {
        int SlotId = -1, OrderDetailId = -1, LinePlanningId = -1, ClusterId = -1, UnitID = -1;
        string LineNo;
        string SerialNo = "";
        string SlotDate;

        ProductionController objProductionController = new ProductionController();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                BindAllQC();
                GetAllQCData();
            }
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["SlotId"])
            {
                SlotId = Convert.ToInt32(Request.QueryString["SlotId"]);
            }
            if (null != Request.QueryString["LineNo"])
            {
                LineNo = Request.QueryString["LineNo"];
            }
            if (null != Request.QueryString["SerialNo"])
            {
                SerialNo = Request.QueryString["SerialNo"].ToString();
                lblSerialNo.Text = SerialNo;
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            if (null != Request.QueryString["LinePlanningId"])
            {
                LinePlanningId = Convert.ToInt32(Request.QueryString["LinePlanningId"]);
            }
            if (null != Request.QueryString["SlotDate"])
            {
                SlotDate = Request.QueryString["SlotDate"].ToString();
            }

            if (null != Request.QueryString["UnitID"])
            {
                UnitID = Convert.ToInt32(Request.QueryString["UnitID"]);
            }
            if (null != Request.QueryString["ClusterId"])
            {
                ClusterId = Convert.ToInt32(Request.QueryString["ClusterId"]);
                if (ClusterId > 0)
                {
                    lblLineNo.Text = LineNo.ToString();
                }
                else
                {
                    lblLineNo.Text = "Line " + LineNo.ToString();
                }
            }

        }

        private void GetAllQCData()
        {
            if (ViewState["dtQCFault"] != null)
            {
                DataTable dtQCFault = (DataTable)ViewState["dtQCFault"];
                grdQC.DataSource = null;
                grdQC.DataSource = dtQCFault;
                grdQC.DataBind();
            }
            else
            {
                StitchQC objStitchQC = new StitchQC();
                objStitchQC.OrderDetailId = OrderDetailId;
                objStitchQC.LinePlanningId = LinePlanningId;
                objStitchQC.SlotId = SlotId;
                objStitchQC.ClusterId = ClusterId;

                DataSet dsQC = objProductionController.GetStitching_QC(objStitchQC, SlotDate, UnitID);
                if (dsQC.Tables.Count > 0)
                {
                    DataTable dtStitchQC = dsQC.Tables[0];
                    if (dtStitchQC.Rows.Count > 0)
                    {
                        rbtnFMFI.SelectedValue = dtStitchQC.Rows[0]["FM_FI"] == DBNull.Value ? "1" : dtStitchQC.Rows[0]["FM_FI"].ToString();
                        rbtnPassFail.SelectedValue = dtStitchQC.Rows[0]["FM_FI_Decision"] == DBNull.Value ? "1" : dtStitchQC.Rows[0]["FM_FI_Decision"].ToString();
                        ddlQC.SelectedValue = dtStitchQC.Rows[0]["QCId"] == DBNull.Value ? "1" : dtStitchQC.Rows[0]["QCId"].ToString();
                        pcsChecked.Text = dtStitchQC.Rows[0]["PcsChecked"] == DBNull.Value ? "5" : dtStitchQC.Rows[0]["PcsChecked"].ToString();
                        pcsFailed.Text = dtStitchQC.Rows[0]["PcsFailed"] == DBNull.Value ? "0" : dtStitchQC.Rows[0]["PcsFailed"].ToString();
                    }
                }

                if (dsQC.Tables.Count > 1)
                {
                    DataTable dtQCFault = dsQC.Tables[1];

                    grdQC.DataSource = dtQCFault;
                    grdQC.DataBind();
                    ViewState["dtQCFault"] = dtQCFault;
                }
                else
                {
                    grdQC.DataSource = null;
                    grdQC.DataBind();
                }
            }
        }

        private void BindAllQC()
        {
            DataTable dtQC = objProductionController.GetAllFactory_QC();
            ddlQC.DataSource = dtQC;
            ddlQC.DataTextField = "FactoryQC";
            ddlQC.DataValueField = "UserId";
            ddlQC.DataBind();
            ddlQC.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void grdQC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtFaultCount = (TextBox)e.Row.FindControl("txtFaultCount");
                txtFaultCount.Text = DataBinder.Eval(e.Row.DataItem, "FaultCount").ToString();
            }
        }

        protected void grdQC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblGrdviewApplet = (Table)grdQC.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                TextBox txtFaults_Empty = (TextBox)rows.FindControl("txtFaults_Empty");
                TextBox txtFaultCount_Empty = (TextBox)rows.FindControl("txtFaultCount_Empty");


                string Faults = txtFaults_Empty.Text;
                int FaultCount = Convert.ToInt32(txtFaultCount_Empty.Text);

                DataTable dtQCFault = new DataTable();
                dtQCFault.Columns.Add("QCSlotWiseId", typeof(System.Int32));
                dtQCFault.Columns.Add("QCSlotWiseFaultsId", typeof(System.Int32));
                dtQCFault.Columns.Add("FaultCode", typeof(System.String));
                dtQCFault.Columns.Add("FaultCount", typeof(System.Int32));


                DataRow dr = dtQCFault.NewRow();
                dr["QCSlotWiseId"] = 0;
                dr["QCSlotWiseFaultsId"] = 0;
                dr["FaultCode"] = Faults;
                dr["FaultCount"] = FaultCount;

                dtQCFault.Rows.Add(dr);
                ViewState["dtQCFault"] = dtQCFault;
                GetAllQCData();

            }

            if (e.CommandName == "AddFooter")
            {
                TextBox txtFaults_Footer = (TextBox)grdQC.FooterRow.FindControl("txtFaults_Footer");
                TextBox txtFaultCount_Footer = (TextBox)grdQC.FooterRow.FindControl("txtFaultCount_Footer");

                string Faults = txtFaults_Footer.Text;
                int FaultCount = Convert.ToInt32(txtFaultCount_Footer.Text);

                if (ViewState["dtQCFault"] != null)
                {
                    DataTable dtQCFooter = (DataTable)ViewState["dtQCFault"];

                    for (int irow = 0; irow < dtQCFooter.Rows.Count; irow++)
                    {
                        HiddenField hdnQCFaultsId = (HiddenField)grdQC.Rows[irow].FindControl("hdnQCFaultsId");
                        dtQCFooter.Rows[irow]["QCSlotWiseFaultsId"] = hdnQCFaultsId.Value;

                        TextBox txtFaults = (TextBox)grdQC.Rows[irow].FindControl("txtFaults");
                        if (txtFaults.Text != "")
                        {
                            dtQCFooter.Rows[irow]["FaultCode"] = txtFaults.Text;
                        }
                        TextBox txtFaultCount = (TextBox)grdQC.Rows[irow].FindControl("txtFaultCount");
                        dtQCFooter.Rows[irow]["FaultCount"] = txtFaultCount.Text;
                        dtQCFooter.AcceptChanges();
                    }


                    DataRow dr = dtQCFooter.NewRow();
                    dr["QCSlotWiseId"] = 0;
                    dr["QCSlotWiseFaultsId"] = 0;
                    dr["FaultCode"] = Faults;
                    dr["FaultCount"] = FaultCount;

                    dtQCFooter.Rows.Add(dr);
                    ViewState["dtQCFault"] = dtQCFooter;
                    GetAllQCData();
                }
            }

        }

        //protected void grdQC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = grdQC.Rows[e.RowIndex];
        //    TextBox txtFaults = (TextBox)row.FindControl("txtFaults");
        //    DropDownList ddlFaultCount = (DropDownList)row.FindControl("ddlFaultCount");
        //    HiddenField hdnQCId = (HiddenField)row.FindControl("hdnQCId");
        //    HiddenField hdnQCFaultsId = (HiddenField)row.FindControl("hdnQCFaultsId");

        //    StitchQC objStitchQC = new StitchQC();
        //    objStitchQC.SlotId = SlotId;
        //    objStitchQC.QCId = Convert.ToInt32(hdnQCId.Value);
        //    objStitchQC.QCSlotWiseFaultsId = Convert.ToInt32(hdnQCFaultsId.Value);

        //    if ((txtFaults.Text != "") && (Convert.ToInt32(ddlFaultCount.SelectedValue) != 0))
        //    {
        //        string Faults = txtFaults.Text;
        //        int FaultCount = Convert.ToInt32(ddlFaultCount.SelectedValue);

        //        if (ViewState["dtQCFault"] != null)
        //        {
        //            DataTable dtQCFault = (DataTable)ViewState["dtQCFault"];
        //            if (dtQCFault.Rows.Count > 0)
        //            {
        //                for (int i = dtQCFault.Rows.Count - 1; i >= 0; i--)
        //                {
        //                    DataRow dr = dtQCFault.Rows[i];
        //                    if (dr["FaultCode"].ToString().Trim() == Faults.Trim())
        //                    {
        //                        dr.Delete();
        //                        int iDelete = objProductionController.Delete_QC_Faults(objStitchQC);
        //                        dtQCFault.AcceptChanges();
        //                    }
        //                }
        //            }

        //            ViewState["dtQCFault"] = dtQCFault;
        //            GetAllQCData();
        //        }
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int iSave = 0;
            int idel = 0;
            StitchQC objStitchQC = new StitchQC();
            if (grdQC.Rows.Count > 0)
            {
                if (ViewState["dtQCFault"] != null)
                {
                    DataTable dtQCFault = (DataTable)ViewState["dtQCFault"];
                    foreach (GridViewRow gvr in grdQC.Rows)
                    {
                        CheckBox chkDelete = (CheckBox)gvr.FindControl("chkDelete");
                        if (chkDelete.Checked)
                        {
                            idel = 1;
                            TextBox txtFaults = (TextBox)gvr.FindControl("txtFaults");
                            TextBox txtFaultCount = (TextBox)gvr.FindControl("txtFaultCount");
                            HiddenField hdnQCId = (HiddenField)gvr.FindControl("hdnQCId");
                            HiddenField hdnQCFaultsId = (HiddenField)gvr.FindControl("hdnQCFaultsId");

                            objStitchQC.SlotId = SlotId;
                            objStitchQC.QCId = Convert.ToInt32(hdnQCId.Value);
                            objStitchQC.QCSlotWiseFaultsId = Convert.ToInt32(hdnQCFaultsId.Value);

                            string Faults = txtFaults.Text;
                            int FaultCount = Convert.ToInt32(txtFaultCount.Text);

                            if (dtQCFault.Rows.Count > 0)
                            {
                                for (int i = dtQCFault.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow dr = dtQCFault.Rows[i];
                                    if (dr["FaultCode"].ToString().Trim() == Faults.Trim())
                                    {
                                        dr.Delete();
                                        int iDelete = objProductionController.Delete_QC_Faults(objStitchQC);
                                        dtQCFault.AcceptChanges();
                                    }
                                }
                            }

                        }
                    }
                    if (idel > 0)
                    {
                        ViewState["dtQCFault"] = dtQCFault;
                        GetAllQCData();
                    }
                }
            }

            if (grdQC.Rows.Count > 0)
            {
                objStitchQC.PcsChecked = Convert.ToInt32(pcsChecked.Text);
                objStitchQC.PcsFailed = Convert.ToInt32(pcsFailed.Text);
                objStitchQC.FMFI = Convert.ToInt32(rbtnFMFI.SelectedValue);
                objStitchQC.FMFI_Decision = Convert.ToInt32(rbtnPassFail.SelectedValue);
                objStitchQC.QCId = Convert.ToInt32(ddlQC.SelectedValue);
                objStitchQC.SlotId = SlotId;
                objStitchQC.OrderDetailId = OrderDetailId;
                objStitchQC.LinePlanningId = LinePlanningId;
                objStitchQC.ClusterId = ClusterId;
                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                int QCOutput = 0;

                iSave = objProductionController.SaveStitching_QC(objStitchQC, SlotDate, UserId, UnitID, out QCOutput);

                foreach (GridViewRow gvr in grdQC.Rows)
                {
                    TextBox txtFaults = (TextBox)gvr.FindControl("txtFaults");
                    TextBox txtFaultCount = (TextBox)gvr.FindControl("txtFaultCount");
                    HiddenField hdnQCFaultsId = (HiddenField)gvr.FindControl("hdnQCFaultsId");

                    if (txtFaults.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:jQuery.facebox('Please fill Faults');", true);
                        return;
                    }
                    if (txtFaultCount.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:jQuery.facebox('Please select fault count');", true);
                        return;
                    }

                    objStitchQC.FaultCode = txtFaults.Text;
                    objStitchQC.QCSlotWiseFaultsId = hdnQCFaultsId.Value != "" ? Convert.ToInt32(hdnQCFaultsId.Value) : 0;
                    objStitchQC.FaultCount = Convert.ToInt32(txtFaultCount.Text);


                    if (QCOutput > 0)
                    {
                        iSave = objProductionController.SaveStitching_QC_Faults(objStitchQC, SlotDate, UserId, QCOutput, 0, UnitID);
                    }
                }

                Control FooterRow = null;
                if (grdQC.FooterRow != null)
                {
                    FooterRow = grdQC.FooterRow;

                    TextBox txtFaults_Footer = (TextBox)grdQC.FooterRow.FindControl("txtFaults_Footer");
                    TextBox txtFaultCount_Footer = (TextBox)grdQC.FooterRow.FindControl("txtFaultCount_Footer");


                    if (txtFaults_Footer.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                        return;
                    }
                    if (txtFaultCount_Footer.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                        return;
                    }

                    objStitchQC.FaultCode = txtFaults_Footer.Text;
                    objStitchQC.FaultCount = Convert.ToInt32(txtFaultCount_Footer.Text);
                    objStitchQC.QCSlotWiseFaultsId = 0;

                    if (QCOutput > 0)
                    {
                        iSave = objProductionController.SaveStitching_QC_Faults(objStitchQC, SlotDate, UserId, QCOutput, 0, UnitID);
                    }
                }

                if (iSave > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                }
            }
            else
            {
                int iblanck = 0;

                objStitchQC.PcsChecked = Convert.ToInt32(pcsChecked.Text);
                objStitchQC.PcsFailed = Convert.ToInt32(pcsFailed.Text);
                objStitchQC.FMFI = Convert.ToInt32(rbtnFMFI.SelectedValue);
                objStitchQC.FMFI_Decision = Convert.ToInt32(rbtnPassFail.SelectedValue);
                objStitchQC.QCId = Convert.ToInt32(ddlQC.SelectedValue);
                objStitchQC.SlotId = SlotId;
                objStitchQC.OrderDetailId = OrderDetailId;
                objStitchQC.LinePlanningId = LinePlanningId;
                objStitchQC.ClusterId = ClusterId;
                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                int QCOutput = 0;

                TextBox txtFaults_Empty = (TextBox)grdQC.Controls[0].Controls[0].FindControl("txtFaults_Empty");
                TextBox txtFaultCount_Empty = (TextBox)grdQC.Controls[0].Controls[0].FindControl("txtFaultCount_Empty");

                if (txtFaults_Empty.Text == "")
                    iblanck = 1;
                if (txtFaultCount_Empty.Text == "0")
                    iblanck = 1;

                if ((iblanck == 1) && (objStitchQC.FMFI_Decision == 1))
                {
                    iSave = objProductionController.SaveStitching_QC(objStitchQC, SlotDate, UserId, UnitID, out QCOutput);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                    return;
                }

                if (txtFaults_Empty.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:jQuery.facebox('Please fill Faults');", true);
                    return;
                }
                if (txtFaultCount_Empty.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:jQuery.facebox('Please select fault count');", true);
                    return;
                }

                iSave = objProductionController.SaveStitching_QC(objStitchQC, SlotDate, UserId, UnitID, out QCOutput);

                objStitchQC.FaultCode = txtFaults_Empty.Text;
                objStitchQC.FaultCount = Convert.ToInt32(txtFaultCount_Empty.Text);
                objStitchQC.QCSlotWiseFaultsId = 0;

                if (QCOutput > 0)
                {
                    iSave = objProductionController.SaveStitching_QC_Faults(objStitchQC, SlotDate, UserId, QCOutput, 0, UnitID);
                }

                if (iSave > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                }

            }
        }


        protected void btnDeleteCurrentSlotDetail_Click(object sender, EventArgs e)
        {
            int iSave = 0;
            StitchQC objStitchQC = new StitchQC();
            objStitchQC.SlotId = SlotId;
            objStitchQC.OrderDetailId = OrderDetailId;
            objStitchQC.LinePlanningId = LinePlanningId;
            objStitchQC.ClusterId = ClusterId;
            objStitchQC.FaultCode = "Delete";
            objStitchQC.FaultCount = 5;
            objStitchQC.QCId = 0;
            objStitchQC.QCSlotWiseFaultsId = 0;
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            iSave = objProductionController.SaveStitching_QC_Faults(objStitchQC, SlotDate, UserId, 0, 1, UnitID);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:DeleteSuccessfully();", true);
        }

    }
}