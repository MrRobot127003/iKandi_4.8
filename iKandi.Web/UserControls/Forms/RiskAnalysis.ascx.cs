using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.Web.Components;


namespace iKandi.Web.UserControls.Forms
{

    public partial class RiskAnalysis : BaseUserControl
    {
        public int CreateNew
        {
            get;
            set;
        }
        public int ReUse
        {
            get;
            set;
        }
        public int ReUseStyleId
        {
            get;
            set;
        }
        public string ReUseStyleNumber
        {
            get;
            set;
        }
        public int NewRefrence
        {
            get;
            set;
        }
        public int DatabaseReuse
        {
            get;
            set;
        }
        int sl = 0;

        iKandi.BLL.OrderController obj_OrderController = new BLL.OrderController();
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        iKandi.BLL.WorkflowController obj_WorkFlowController = new BLL.WorkflowController();

        public int styleid
        {
            get;
            set;
        }
        public string stylenumber
        {
            get;
            set;
        }
        public int strClientId
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        #region "Event Use For F5 Functionality"
        protected void Page_PreRender(object sender, EventArgs e)
        {

            ViewState["Time"] = Session["Time"];
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                if (null != Request.QueryString["showFITSFORM"])
                {
                    return;
                }
                if (null != Request.QueryString["showOBFORM"])
                {
                    return;
                }
                if (null != Request.QueryString["showHOPPMFORM"])
                {
                    return;
                }

                ShowGridPopup.Visible = false;
                //CheckRiskAnalysis();
                BindControl(0, 0, 0, -1, "");
                BindRemarkGrd(0, 0, 0, -1, "");
                BindAccessoriesGrd(0, 0, 0, -1, "");
                BindFitingGrd(0, 0, 0, -1, "");
                BindMakingGrd(0, 0, 0, -1, "");
                BindImbroideryGrd(0, 0, 0, -1, "");
                BindWashingGrd(0, 0, 0, -1, "");
                BindFinishingGrd(0, 0, 0, -1, "");
                BindValueAddtion(0, 0, 0, -1, "");
                Session["Time"] = DateTime.Now.ToString();
                hdnStyleId.Value = styleid.ToString();
                hdnStyleNumber.Value = stylenumber;
                SetRiskPermission(0);
                Uncheckbox();
            }



        }
        public void Uncheckbox()
        {
            if (chkvalueAddtion.Checked)
            {
                GrdValueAddtion.Enabled = true;
                DataSet dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, 0, ReUse, ReUseStyleId, "valaddtion");
                int ValueAddedQty = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["ValueAddQty"].ToString());
                int FreeJe = Convert.ToInt32(dsgrd.Tables[2].Rows[0]["FreeJeCheckBox"].ToString());

            }
            else
            {
                foreach (GridViewRow row in GrdValueAddtion.Rows)
                {
                    CheckBox ISUSE = (CheckBox)row.FindControl("ISUSE");
                    CheckBox ISUSEVA = (CheckBox)row.FindControl("ISUSEVA");
                    ISUSEVA.Checked = false;
                    ISUSE.Checked = false;
                }
            }

        }

        private void BindValueAddtion(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {

            DataSet dsgrd = new DataSet();

            string RemarksType = "valaddtion";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                GrdValueAddtion.DataSource = dsgrd.Tables[0];
                GrdValueAddtion.DataBind();
                ViewState["ValueAddtion"] = dsgrd.Tables[0];
                int taskid = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["CurrentStatusID"].ToString());
                //if (taskid > 40)
                //{
                //    GrdValueAddtion.Enabled = false;
                //    chkvalueAddtion.Enabled = false;
                //}

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                GrdValueAddtion.DataSource = dsgrd.Tables[0];
                GrdValueAddtion.DataBind();
                ViewState["ValueAddtion"] = dsgrd.Tables[0];
                int taskid = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["CurrentStatusID"].ToString());
                //if (taskid > 40)
                //{
                //    GrdValueAddtion.Enabled = false;
                //    chkvalueAddtion.Enabled = false;
                //}
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                GrdValueAddtion.DataSource = dsgrd.Tables[0];
                GrdValueAddtion.DataBind();
                ViewState["ValueAddtion"] = dsgrd.Tables[0];
                GrdValueAddtion.Enabled = false;
                chkvalueAddtion.Enabled = false;
            }
            else
            {
                if (ViewState["ValueAddtion"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    GrdValueAddtion.DataSource = dsgrd.Tables[0];
                    GrdValueAddtion.DataBind();
                    ViewState["ValueAddtion"] = dsgrd.Tables[0];
                    int taskid = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["CurrentStatusID"].ToString());
                    int ValueAddedQty = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["ValueAddQty"].ToString());
                    int FreeJe = Convert.ToInt32(dsgrd.Tables[2].Rows[0]["FreeJeCheckBox"].ToString());
                    //if (taskid > 40)
                    //{
                    //    GrdValueAddtion.Enabled = false;
                    //    chkvalueAddtion.Enabled = false;
                    //}
                    //if (ValueAddedQty > 0)
                    //{
                    //    GrdValueAddtion.Enabled = false;
                    //    //chkvalueAddtion.Enabled = false;
                    //}
                    //if (FreeJe == 0)
                    //    chkvalueAddtion.Enabled = true;
                    //else
                    //    chkvalueAddtion.Enabled = false;
                }
                else
                {
                    if (chkvalueAddtion.Checked == true)
                    {
                        dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                        GrdValueAddtion.DataSource = dsgrd.Tables[0];
                        GrdValueAddtion.DataBind();
                        ViewState["ValueAddtion"] = dsgrd.Tables[0];
                        int taskid = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["CurrentStatusID"].ToString());
                        //if (taskid > 40)
                        //{
                        //    GrdValueAddtion.Enabled = false;
                        //    chkvalueAddtion.Enabled = false;
                        //}
                        int ValueAddedQty = Convert.ToInt32(dsgrd.Tables[1].Rows[0]["ValueAddQty"].ToString());
                        int FreeJe = Convert.ToInt32(dsgrd.Tables[2].Rows[0]["FreeJeCheckBox"].ToString());

                        //if (ValueAddedQty > 0)
                        //{
                        //    GrdValueAddtion.Enabled = false;
                        //    // chkvalueAddtion.Enabled = false;
                        //}
                        //if (FreeJe == 0)
                        //    chkvalueAddtion.Enabled = true;
                        //else
                        //    chkvalueAddtion.Enabled = false;

                    }
                    else
                    {
                        DataTable dtnew = (DataTable)(ViewState["ValueAddtion"]);
                        dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                        GrdValueAddtion.DataSource = dsgrd.Tables[0];
                        GrdValueAddtion.DataBind();
                        //ViewState["ValueAddtion"] = dtnew;
                        ViewState["ValueAddtion"] = dsgrd.Tables[0];
                    }
                }
            }








        }

        protected void SetRiskPermission(int ReUse)
        {
            DataTable dtPermission = new DataTable();

            int DeptId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
            int DesigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            dtPermission = obj_OrderController.GetOBPermission(DeptId, DesigId, 208);

            if (dtPermission.Rows.Count > 0)
            {
                for (int ipermission = 0; ipermission < dtPermission.Rows.Count; ipermission++)
                {
                    int ColumnId = Convert.ToInt32(dtPermission.Rows[ipermission]["Technicalsectionid"]);
                    int SectionId = Convert.ToInt32(dtPermission.Rows[ipermission]["TechnicalFormsID"]);

                    string searchId = "Technicalsectionid =" + ColumnId;
                    DataRow[] dRow = dtPermission.Select(searchId);


                    if (ColumnId == 176)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskRemarks.Enabled = false;
                            if (grdRiskRemarks.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskRemarks.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskRemarks.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskRemarks.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskRemarks.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskRemarks.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskRemarks.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }

                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskRemarks.Visible = true;
                                grdilimitationRemarks.Visible = true;

                                grdRiskRemarks.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskRemarks.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskRemarks.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 177)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskAccessories.Enabled = false;
                            if (grdRiskAccessories.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskAccessories.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskAccessories.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskAccessories.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskAccessories.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskAccessories.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskAccessories.Visible = true;
                                grdacssessoryLimitationRemarks.Visible = true;

                                grdRiskAccessories.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskAccessories.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 178)
                    {
                        if (ReUse == 1)
                        {
                            grdriskFiting.Enabled = false;
                            if (grdriskFiting.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdriskFiting.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdriskFiting.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdriskFiting.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdriskFiting.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdriskFiting.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdriskFiting.Visible = true;
                                grdriskFiting.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdriskFiting.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 179)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskMaking.Enabled = false;
                            if (grdRiskMaking.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskMaking.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskMaking.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskMaking.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskMaking.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskMaking.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskMaking.Visible = true;
                                grdRiskMaking.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskMaking.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 180)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskImbroidery.Enabled = false;
                            if (grdRiskImbroidery.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskImbroidery.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskImbroidery.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskImbroidery.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskImbroidery.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskImbroidery.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskImbroidery.Visible = true;
                                grdRiskImbroidery.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskImbroidery.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 181)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskWashing.Enabled = false;
                            if (grdRiskWashing.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskWashing.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskWashing.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskWashing.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskWashing.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskWashing.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskWashing.Visible = true;
                                grdRiskWashing.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskWashing.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }
                    if (ColumnId == 182)
                    {
                        if (ReUse == 1)
                        {
                            grdRiskFinishing.Enabled = false;
                            if (grdRiskFinishing.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskFinishing.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = false;
                                }
                                TextBox txtRemarkFooter = (TextBox)grdRiskWashing.FooterRow.FindControl("txtRemarkFooter");
                                LinkButton abtnAdd = (LinkButton)grdRiskWashing.FooterRow.FindControl("abtnAdd");
                                txtRemarkFooter.Enabled = false;
                                abtnAdd.Visible = false;
                            }
                            else
                            {
                                TextBox txtRemarksEmpty = grdRiskFinishing.Controls[0].Controls[0].FindControl("txtRemarksEmpty") as TextBox;
                                LinkButton addbutton = grdRiskFinishing.Controls[0].Controls[0].FindControl("addbutton") as LinkButton;
                                txtRemarksEmpty.Enabled = false;
                                addbutton.Visible = false;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dRow)
                            {
                                grdRiskFinishing.Visible = true;
                                grdRiskFinishing.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                                {
                                    LinkButton LinkButton = (LinkButton)grdRiskFinishing.Rows[i].FindControl("lnkDelete");
                                    if (LinkButton != null)
                                        LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                                    LinkButton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                                }
                            }
                        }
                    }

                    if (ColumnId == 183)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkAccountManager.Visible = true;
                            chkAccountManager.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    if (ColumnId == 185)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkQAProd.Visible = true;
                            chkQAProd.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 186)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 187)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            repStyleCodeVirsion.Visible = true;
                            repStyleCodeVirsion.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    //abhishek ==permission
                    if (ColumnId == 218)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddFactory.Visible = true;
                            btnAddFactory.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 219)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddSampling.Visible = true;
                            btnAddSampling.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 220)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddIE.Visible = true;
                            btnAddIE.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 221)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddFabric.Visible = true;
                            btnAddFabric.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 222)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddAccessory.Visible = true;
                            btnAddAccessory.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 223)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddOut.Visible = true;
                            btnAddOut.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 224)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddMerchandiser.Visible = true;
                            btnAddMerchandiser.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 225)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddQa.Visible = true;
                            btnAddQa.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                    if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                    {

                        if (NewRefrence == 1)
                        {
                            chkAccountManager.Enabled = true;

                            chkQAProd.Enabled = true;
                            chkMerchandisingMgr.Enabled = true;
                        }
                        else
                        {
                            chkAccountManager.Enabled = false;
                            chkQAProd.Enabled = false;
                            chkMerchandisingMgr.Enabled = false;
                        }
                    }

                    if (NewRefrence == 1)
                    {
                        chkAccountManager.Enabled = true;

                        chkQAProd.Enabled = true;
                        chkMerchandisingMgr.Enabled = true;
                        FinalRiskDone(1);
                    }
                    if (ReUse == 1)
                    {
                        chkAccountManager.Enabled = false;

                        chkQAProd.Enabled = false;
                        chkMerchandisingMgr.Enabled = false;
                        FinalRiskDone(1);
                    }

                    if ((DatabaseReuse == 1) && (CreateNew == 0) && (NewRefrence == 0))
                    {
                        chkAccountManager.Enabled = false;

                        chkQAProd.Enabled = false;
                        chkMerchandisingMgr.Enabled = false;
                    }

                }
            }
            else
            {
                grdRiskRemarks.Visible = false;
                grdilimitationRemarks.Visible = false;
                grdRiskAccessories.Visible = false;
                grdacssessoryLimitationRemarks.Visible = false;
                grdriskFiting.Visible = false;
                grdRiskMaking.Visible = false;
                grdRiskImbroidery.Visible = false;
                grdRiskWashing.Visible = false;
                grdRiskFinishing.Visible = false;
                repStyleCodeVirsion.Visible = false;
                chkAccountManager.Visible = false;

                chkQAProd.Visible = false;
            }
            if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
            {
                btnAddFactory.Visible = false; ;
                btnAddSampling.Visible = false;
                btnAddIE.Visible = false;
                btnAddFabric.Visible = false;
                btnAddAccessory.Visible = false;
                btnAddOut.Visible = false;
                btnAddMerchandiser.Visible = false;
                btnAddQa.Visible = false;

            }
        }

        public class GridDecorator
        {
            public static void MergeRows(GridView gridView)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Text == previousRow.Cells[i].Text)
                        {
                            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[i].RowSpan + 1;
                            previousRow.Cells[i].Visible = false;
                        }
                    }
                }
            }
        }


        private void FinalRiskDone(int Flag)
        {
            if (Flag == 1)
            {
                grdRiskRemarks.Enabled = true;
                grdRiskAccessories.Enabled = true;
                grdriskFiting.Enabled = true;
                grdRiskMaking.Enabled = true;
                grdRiskImbroidery.Enabled = true;
                grdRiskWashing.Enabled = true;
                grdRiskFinishing.Enabled = true;
                hdnEnableFalse.Value = "0";
            }
            else
            {
                grdRiskRemarks.Enabled = false;
                grdRiskAccessories.Enabled = false;
                grdriskFiting.Enabled = false;
                grdRiskMaking.Enabled = false;
                grdRiskImbroidery.Enabled = false;
                grdRiskWashing.Enabled = false;
                grdRiskFinishing.Enabled = false;
                hdnEnableFalse.Value = "1";




            }
        }

        private void CancelUnexpectedRePost()
        {
            string clientCode = _repostcheckcode.Value;

            //Get Server Code from session (Or Empty if null)
            string serverCode = Session["_repostcheckcode"] as string ?? "";

            if (!IsPostBack && clientCode.Equals(serverCode))
            {

                Session["PostID"] = "1001";
                ViewState["PostID"] = Session["PostID"].ToString();

                ShowGridPopup.Visible = false;
                //CheckRiskAnalysis();
                BindControl(0, 0, 0, -1, "");
                BindRemarkGrd(0, 0, 0, -1, "");
                BindAccessoriesGrd(0, 0, 0, -1, "");
                BindFitingGrd(0, 0, 0, -1, "");
                BindMakingGrd(0, 0, 0, -1, "");
                BindImbroideryGrd(0, 0, 0, -1, "");
                BindWashingGrd(0, 0, 0, -1, "");
                BindFinishingGrd(0, 0, 0, -1, "");

                //Session["Time"] = DateTime.Now.ToString();
                //Codes are equals - The action was initiated by the user
                //Save new code (Can use simple counter instead Guid)
                string code = Guid.NewGuid().ToString();
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;



            }

        }

        public bool IsValidPost()
        {
            bool istrueorfalse = false;

            if (ViewState["PostID"] != null)
            {
                if (ViewState["PostID"].ToString() == Session["PostID"].ToString())
                {
                    Session["PostID"] =
                    (Convert.ToInt16(Session["PostID"]) + 1).ToString();

                    ViewState["PostID"] = Session["PostID"].ToString();
                    istrueorfalse = true;

                }
                else
                {
                    ViewState["PostID"] = Session["PostID"].ToString();

                    istrueorfalse = false;
                }
                if (Session["id"] != null)
                {
                    istrueorfalse = false;
                }
            }
            return istrueorfalse;
        }

        private void CheckRiskAnalysis()
        {
            //HiddenField hdnShowForm = (HiddenField)this.Parent.FindControl("hdnShowForm");

            //List<OrderFlow> lstStyle = obj_ProcessController.CheckOrderProcess(styleid,strClientId,DepartmentId, 1);
            //if (lstStyle.Count > 0)
            //{               

            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "CheckOrderProcess('" + styleid + "','" + 1 + "')", true);

            //}
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                strClientId = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DepartmentId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["OrderId"])
            {
                OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
            }

        }

        private void BindControl(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataTable dtPermission = new DataTable();
            List<OrderDetail> OdList = new List<OrderDetail>();
            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            //Label lblBasicInformation = (Label)this.Parent.FindControl("lblBasicInformation");
            DataSet dsStyle = obj_ProcessController.GetStyleNumberClientDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 1);
            if (dsStyle.Tables[0].Rows.Count > 0)
            {
                string StyleDetail = "";
                for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                {
                    StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                }

                lblRiskBasicInformation.Text = StyleDetail.TrimEnd(',');
            }
            OdList = obj_OrderController.GetMoInfo(styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, 1);
            if (OdList.Count >= 3)
            {
                dvGvRisk.Attributes.Add("style", "height:500px; overflow-x: hidden; overflow-y: auto;");
            }
            else
            {
                dvGvRisk.Attributes.Add("style", "height:300px; overflow-x: hidden; overflow-y: auto;");
            }

            if (OdList.Count > 0)
            {
                gvRiskAnalysis.DataSource = OdList;
                gvRiskAnalysis.DataBind();
            }

            DataSet dsRiskAnalysis = obj_ProcessController.GetRiskAnalysis(stylenumber, styleid, strClientId, DepartmentId, OrderId, CreateNew, NewRef, ReUse, ReUseStyleId);

            //added by abhishek on 17/5/2017================================================================//
            hdnMerchandiserCounterRisk.Value = "0";
            hdnFactoryCounterRisk.Value = "0";
            hdnCounterRisk.Value = "0";
            hdnIECounterRisk.Value = "0";
            hdnSamplingCounterRisk.Value = "0";
            hdnFabricCounterRisk.Value = "0";
            hdnAccessoryCounterRisk.Value = "0";
            hdnOutCounterRisk.Value = "0";

            if (dsRiskAnalysis.Tables[0].Rows.Count > 0)
            {
                hdnQaRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["QaRepresentativeIds"].ToString();

                dvQaRepresentativeValuesRisk.InnerHtml = "";
                string strId = dsRiskAnalysis.Tables[0].Rows[0]["QaRepresentativeIds"].ToString();
                string[] strIdArray = strId.Split(',');
                string strValue = dsRiskAnalysis.Tables[0].Rows[0]["QaRepresentativeNames"].ToString();
                string[] strValueArray = strValue.Split(',');
                //hdnCounterRisk.Value = "0";
                if (strValueArray.Length > 0 && strValueArray[0] != "")
                {
                    for (int iQaRepresentativeId = 1; iQaRepresentativeId <= strValueArray.Length; iQaRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iQaRepresentativeId == 1)
                            {
                                dvQaRepresentativeValuesRisk.InnerHtml = "<span id=\"dvQaRepresentativeRisk" + iQaRepresentativeId + "\"><span>" + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentativeRisk(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvQaRepresentativeValuesRisk.InnerHtml += "<span id=\"dvQaRepresentativeRisk" + iQaRepresentativeId + "\"><span>," + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentativeRisk(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                        }
                        else
                        {
                            if (iQaRepresentativeId == 1)
                            {
                                dvQaRepresentativeValuesRisk.InnerHtml = "<span id=\"dvQaRepresentativeRisk" + iQaRepresentativeId + "\"><span>" + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentativeRisk_none(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvQaRepresentativeValuesRisk.InnerHtml += "<span id=\"dvQaRepresentativeRisk" + iQaRepresentativeId + "\"><span>," + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentativeRisk_none(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        hdnCounterRisk.Value = iQaRepresentativeId.ToString();
                    }


                }

                hdnQaRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["QaRepresentativeNames"].ToString();

                hdnFactoryRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["FactoryRepresentativeIds"].ToString();

                dvFactoryRepresentativeValuesRisk.InnerHtml = "";
                string strFactoryId = dsRiskAnalysis.Tables[0].Rows[0]["FactoryRepresentativeIds"].ToString();
                string[] strFactoryIdArray = strFactoryId.Split(',');
                string strFactoryValue = dsRiskAnalysis.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString();
                string[] strFactoryValueArray = strFactoryValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // hdnFactoryCounterRisk.Value = "0";
                try
                {
                    if (strFactoryValueArray.Length > 0 && strFactoryValueArray[0] != "")
                    {
                        for (int iFactoryRepresentativeId = 1; iFactoryRepresentativeId <= strFactoryValueArray.Length; iFactoryRepresentativeId++)
                        {
                            if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                            {
                                if (iFactoryRepresentativeId == 1)
                                {
                                    dvFactoryRepresentativeValuesRisk.InnerHtml = "<span id=\"dvFactoryRepresentativeRisk" + iFactoryRepresentativeId + "\"><span>" + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentativeRisk(" + iFactoryRepresentativeId + ", " + strFactoryIdArray[iFactoryRepresentativeId - 1] + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                                }
                                else
                                {
                                    dvFactoryRepresentativeValuesRisk.InnerHtml += "<span id=\"dvFactoryRepresentativeRisk" + iFactoryRepresentativeId + "\"><span>," + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentativeRisk(" + iFactoryRepresentativeId + ", " + strFactoryIdArray[iFactoryRepresentativeId - 1] + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                                }

                            }
                            else
                            {
                                if (iFactoryRepresentativeId == 1)
                                {
                                    dvFactoryRepresentativeValuesRisk.InnerHtml = "<span id=\"dvFactoryRepresentativeRisk" + iFactoryRepresentativeId + "\"><span>" + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentativeRisk_none(" + iFactoryRepresentativeId + ", " + strFactoryIdArray[iFactoryRepresentativeId - 1] + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                                }
                                else
                                {
                                    dvFactoryRepresentativeValuesRisk.InnerHtml += "<span id=\"dvFactoryRepresentativeRisk" + iFactoryRepresentativeId + "\"><span>," + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentativeRisk_none(" + iFactoryRepresentativeId + ", " + strFactoryIdArray[iFactoryRepresentativeId - 1] + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                                }
                            }
                            hdnFactoryCounterRisk.Value = iFactoryRepresentativeId.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {


                }

                hdnFactoryRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString();

                //
                hdnMerchandiserRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["MerchandiserRepresentativeIds"].ToString();

                dvMerchandiserRepresentativeValuesRisk.InnerHtml = "";
                string strMerchandiserId = dsRiskAnalysis.Tables[0].Rows[0]["MerchandiserRepresentativeIds"].ToString();
                string[] strMerchandiserIdArray = strMerchandiserId.Split(',');
                string strMerchandiserValue = dsRiskAnalysis.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString();
                string[] strMerchandiserValueArray = strMerchandiserValue.Split(',');
                //hdnMerchandiserCounterRisk.Value = "0";
                if (strMerchandiserValueArray.Length > 0 && strMerchandiserValueArray[0] != "")
                {
                    for (int iMerchandiserRepresentativeId = 1; iMerchandiserRepresentativeId <= strMerchandiserValueArray.Length; iMerchandiserRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iMerchandiserRepresentativeId == 1)
                            {
                                dvMerchandiserRepresentativeValuesRisk.InnerHtml = "<span id=\"dvMerchandiserRepresentativeRisk" + iMerchandiserRepresentativeId + "\"><span>" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentativeRisk(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvMerchandiserRepresentativeValuesRisk.InnerHtml += "<span id=\"dvMerchandiserRepresentativeRisk" + iMerchandiserRepresentativeId + "\"><span>," + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentativeRisk(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }


                        }
                        else
                        {
                            if (iMerchandiserRepresentativeId == 1)
                            {
                                dvMerchandiserRepresentativeValuesRisk.InnerHtml = "<span id=\"dvMerchandiserRepresentativeRisk" + iMerchandiserRepresentativeId + "\"><span>" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentativeRisk_none(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvMerchandiserRepresentativeValuesRisk.InnerHtml += "<span id=\"dvMerchandiserRepresentativeRisk" + iMerchandiserRepresentativeId + "\"><span>," + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentativeRisk_none(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                        }
                        hdnMerchandiserCounterRisk.Value = iMerchandiserRepresentativeId.ToString();
                    }
                }

                hdnMerchandiserRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString();

                //==IE
                hdnIERepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["IERepresentativesIds"].ToString();

                dvIERepresentativeValuesRisk.InnerHtml = "";
                string strIEId = dsRiskAnalysis.Tables[0].Rows[0]["IERepresentativesIds"].ToString();
                string[] strIEIdArray = strIEId.Split(',');
                string strIEValue = dsRiskAnalysis.Tables[0].Rows[0]["IERepresentativesName"].ToString();
                string[] strIEValueArray = strIEValue.Split(',');
                // hdnIECounterRisk.Value = "0";
                if (strIEValueArray.Length > 0 && strIEValueArray[0] != "")
                {
                    for (int iIERepresentativeId = 1; iIERepresentativeId <= strIEValueArray.Length; iIERepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iIERepresentativeId == 1)
                            {
                                dvIERepresentativeValuesRisk.InnerHtml = "<span id=\"dvIERepresentativeRisk" + iIERepresentativeId + "\"><span>" + strIEValueArray[iIERepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteIERepresentativeRisk(" + iIERepresentativeId + ", " + strIEIdArray[iIERepresentativeId - 1] + ", '" + strIEValueArray[iIERepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvIERepresentativeValuesRisk.InnerHtml += "<span id=\"dvIERepresentativeRisk" + iIERepresentativeId + "\"><span>," + strIEValueArray[iIERepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteIERepresentativeRisk(" + iIERepresentativeId + ", " + strIEIdArray[iIERepresentativeId - 1] + ", '" + strIEValueArray[iIERepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                        }
                        else
                        {
                            if (iIERepresentativeId == 1)
                            {
                                dvIERepresentativeValuesRisk.InnerHtml = "<span id=\"dvIERepresentativeRisk" + iIERepresentativeId + "\"><span>" + strIEValueArray[iIERepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteIERepresentativeRisk_none(" + iIERepresentativeId + ", " + strIEIdArray[iIERepresentativeId - 1] + ", '" + strIEValueArray[iIERepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvIERepresentativeValuesRisk.InnerHtml += "<span id=\"dvIERepresentativeRisk" + iIERepresentativeId + "\"><span>," + strIEValueArray[iIERepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteIERepresentativeRisk_none(" + iIERepresentativeId + ", " + strIEIdArray[iIERepresentativeId - 1] + ", '" + strIEValueArray[iIERepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        hdnIECounterRisk.Value = iIERepresentativeId.ToString();
                    }
                }

                hdnIERepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["IERepresentativesName"].ToString();
                //sampling==

                hdnSamplingRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["SamplingRepresentativesIds"].ToString();

                dvSamplingRepresentativeValuesRisk.InnerHtml = "";
                string strSamplingId = dsRiskAnalysis.Tables[0].Rows[0]["SamplingRepresentativesIds"].ToString();
                string[] strSamplingIdArray = strSamplingId.Split(',');
                string strSamplingValue = dsRiskAnalysis.Tables[0].Rows[0]["SamplingRepresentativesName"].ToString();
                string[] strSamplingValueArray = strSamplingValue.Split(',');
                // hdnSamplingCounterRisk.Value = "0";
                if (strSamplingValueArray.Length > 0 && strSamplingValueArray[0] != "")
                {
                    for (int iSamplingRepresentativeId = 1; iSamplingRepresentativeId <= strSamplingValueArray.Length; iSamplingRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iSamplingRepresentativeId == 1)
                            {
                                dvSamplingRepresentativeValuesRisk.InnerHtml = "<span id=\"dvSamplingRepresentativeRisk" + iSamplingRepresentativeId + "\"><span>" + strSamplingValueArray[iSamplingRepresentativeId - 1] + " <a class=\"remove_fSamplingld\" onclick=\"DeleteSamplingRepresentativeRisk(" + iSamplingRepresentativeId + ", " + strSamplingIdArray[iSamplingRepresentativeId - 1] + ", '" + strSamplingValueArray[iSamplingRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvSamplingRepresentativeValuesRisk.InnerHtml += "<span id=\"dvSamplingRepresentativeRisk" + iSamplingRepresentativeId + "\"><span>," + strSamplingValueArray[iSamplingRepresentativeId - 1] + " <a class=\"remove_fSamplingld\" onclick=\"DeleteSamplingRepresentativeRisk(" + iSamplingRepresentativeId + ", " + strSamplingIdArray[iSamplingRepresentativeId - 1] + ", '" + strSamplingValueArray[iSamplingRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        else
                        {
                            if (iSamplingRepresentativeId == 1)
                            {
                                dvSamplingRepresentativeValuesRisk.InnerHtml = "<span id=\"dvSamplingRepresentativeRisk" + iSamplingRepresentativeId + "\"><span>" + strSamplingValueArray[iSamplingRepresentativeId - 1] + " <a class=\"remove_fSamplingld\" onclick=\"DeleteSamplingRepresentativeRisk_none(" + iSamplingRepresentativeId + ", " + strSamplingIdArray[iSamplingRepresentativeId - 1] + ", '" + strSamplingValueArray[iSamplingRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvSamplingRepresentativeValuesRisk.InnerHtml += "<span id=\"dvSamplingRepresentativeRisk" + iSamplingRepresentativeId + "\"><span>," + strSamplingValueArray[iSamplingRepresentativeId - 1] + " <a class=\"remove_fSamplingld\" onclick=\"DeleteSamplingRepresentativeRisk_none(" + iSamplingRepresentativeId + ", " + strSamplingIdArray[iSamplingRepresentativeId - 1] + ", '" + strSamplingValueArray[iSamplingRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                        }
                        hdnSamplingCounterRisk.Value = iSamplingRepresentativeId.ToString();
                    }
                }

                hdnSamplingRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["SamplingRepresentativesName"].ToString();
                //Fabric==
                hdnFabricRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["FabricStoreRepresentativesIds"].ToString();

                dvFabricRepresentativeValuesRisk.InnerHtml = "";
                string strFabricId = dsRiskAnalysis.Tables[0].Rows[0]["FabricStoreRepresentativesIds"].ToString();
                string[] strFabricIdArray = strFabricId.Split(',');
                string strFabricValue = dsRiskAnalysis.Tables[0].Rows[0]["FabricStoreRepresentativesName"].ToString();
                string[] strFabricValueArray = strFabricValue.Split(',');
                //hdnFabricCounterRisk.Value = "0";
                if (strFabricValueArray.Length > 0 && strFabricValueArray[0] != "")
                {
                    for (int iFabricRepresentativeId = 1; iFabricRepresentativeId <= strFabricValueArray.Length; iFabricRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iFabricRepresentativeId == 1)
                            {
                                dvFabricRepresentativeValuesRisk.InnerHtml = "<span id=\"dvFabricRepresentativeRisk" + iFabricRepresentativeId + "\"><span>" + strFabricValueArray[iFabricRepresentativeId - 1] + " <a class=\"remove_fFabricld\" onclick=\"DeleteFabricRepresentativeRisk(" + iFabricRepresentativeId + ", " + strFabricIdArray[iFabricRepresentativeId - 1] + ", '" + strFabricValueArray[iFabricRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvFabricRepresentativeValuesRisk.InnerHtml += "<span id=\"dvFabricRepresentativeRisk" + iFabricRepresentativeId + "\"><span>," + strFabricValueArray[iFabricRepresentativeId - 1] + " <a class=\"remove_fFabricld\" onclick=\"DeleteFabricRepresentativeRisk(" + iFabricRepresentativeId + ", " + strFabricIdArray[iFabricRepresentativeId - 1] + ", '" + strFabricValueArray[iFabricRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        else
                        {

                            if (iFabricRepresentativeId == 1)
                            {
                                dvFabricRepresentativeValuesRisk.InnerHtml = "<span id=\"dvFabricRepresentativeRisk" + iFabricRepresentativeId + "\"><span>" + strFabricValueArray[iFabricRepresentativeId - 1] + " <a class=\"remove_fFabricld\" onclick=\"DeleteFabricRepresentativeRisk_none(" + iFabricRepresentativeId + ", " + strFabricIdArray[iFabricRepresentativeId - 1] + ", '" + strFabricValueArray[iFabricRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvFabricRepresentativeValuesRisk.InnerHtml += "<span id=\"dvFabricRepresentativeRisk" + iFabricRepresentativeId + "\"><span>," + strFabricValueArray[iFabricRepresentativeId - 1] + " <a class=\"remove_fFabricld\" onclick=\"DeleteFabricRepresentativeRisk_none(" + iFabricRepresentativeId + ", " + strFabricIdArray[iFabricRepresentativeId - 1] + ", '" + strFabricValueArray[iFabricRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }



                        }
                        hdnFabricCounterRisk.Value = iFabricRepresentativeId.ToString();
                    }
                }

                hdnFabricRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["FabricStoreRepresentativesName"].ToString();

                //Accessory==
                hdnAccessoryRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["AccessoriesStoreRepresentativesIds"].ToString();

                dvAccessoryRepresentativeValuesRisk.InnerHtml = "";
                string strAccessoryId = dsRiskAnalysis.Tables[0].Rows[0]["AccessoriesStoreRepresentativesIds"].ToString();
                string[] strAccessoryIdArray = strAccessoryId.Split(',');
                string strAccessoryValue = dsRiskAnalysis.Tables[0].Rows[0]["AccessoriesStoreRepresentativesName"].ToString();
                string[] strAccessoryValueArray = strAccessoryValue.Split(',');
                // hdnAccessoryCounterRisk.Value = "0";
                if (strAccessoryValueArray.Length > 0 && strAccessoryValueArray[0] != "")
                {
                    for (int iAccessoryRepresentativeId = 1; iAccessoryRepresentativeId <= strAccessoryValueArray.Length; iAccessoryRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iAccessoryRepresentativeId == 1)
                            {
                                dvAccessoryRepresentativeValuesRisk.InnerHtml = "<span id=\"dvAccessoryRepresentativeRisk" + iAccessoryRepresentativeId + "\"><span>" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + " <a class=\"remove_fAccessoryld\" onclick=\"DeleteAccessoryRepresentativeRisk(" + iAccessoryRepresentativeId + ", " + strAccessoryIdArray[iAccessoryRepresentativeId - 1] + ", '" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvAccessoryRepresentativeValuesRisk.InnerHtml += "<span id=\"dvAccessoryRepresentativeRisk" + iAccessoryRepresentativeId + "\"><span>," + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + " <a class=\"remove_fAccessoryld\" onclick=\"DeleteAccessoryRepresentativeRisk(" + iAccessoryRepresentativeId + ", " + strAccessoryIdArray[iAccessoryRepresentativeId - 1] + ", '" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        else
                        {
                            if (iAccessoryRepresentativeId == 1)
                            {
                                dvAccessoryRepresentativeValuesRisk.InnerHtml = "<span id=\"dvAccessoryRepresentativeRisk" + iAccessoryRepresentativeId + "\"><span>" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + " <a class=\"remove_fAccessoryld\" onclick=\"DeleteAccessoryRepresentativeRisk_none(" + iAccessoryRepresentativeId + ", " + strAccessoryIdArray[iAccessoryRepresentativeId - 1] + ", '" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvAccessoryRepresentativeValuesRisk.InnerHtml += "<span id=\"dvAccessoryRepresentativeRisk" + iAccessoryRepresentativeId + "\"><span>," + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + " <a class=\"remove_fAccessoryld\" onclick=\"DeleteAccessoryRepresentativeRisk_none(" + iAccessoryRepresentativeId + ", " + strAccessoryIdArray[iAccessoryRepresentativeId - 1] + ", '" + strAccessoryValueArray[iAccessoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        hdnAccessoryCounterRisk.Value = iAccessoryRepresentativeId.ToString();
                    }
                }

                hdnAccessoryRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["AccessoriesStoreRepresentativesName"].ToString();

                //Out==
                hdnOutRepresentativeIdRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["OutSourceRepresentativesIds"].ToString();

                dvOutRepresentativeValuesRisk.InnerHtml = "";
                string strOutId = dsRiskAnalysis.Tables[0].Rows[0]["OutSourceRepresentativesIds"].ToString();
                string[] strOutIdArray = strOutId.Split(',');
                string strOutValue = dsRiskAnalysis.Tables[0].Rows[0]["OutSourceRepresentativesName"].ToString();
                string[] strOutValueArray = strOutValue.Split(',');
                // hdnOutCounterRisk.Value = "0";
                if (strOutValueArray.Length > 0 && strOutValueArray[0] != "")
                {
                    for (int iOutRepresentativeId = 1; iOutRepresentativeId <= strOutValueArray.Length; iOutRepresentativeId++)
                    {
                        if (Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]) != true && Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]) != true)
                        {
                            if (iOutRepresentativeId == 1)
                            {
                                dvOutRepresentativeValuesRisk.InnerHtml = "<span id=\"dvOutRepresentativeRisk" + iOutRepresentativeId + "\"><span>" + strOutValueArray[iOutRepresentativeId - 1] + " <a class=\"remove_fOutld\" onclick=\"DeleteOutRepresentativeRisk(" + iOutRepresentativeId + ", " + strOutIdArray[iOutRepresentativeId - 1] + ", '" + strOutValueArray[iOutRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvOutRepresentativeValuesRisk.InnerHtml += "<span id=\"dvOutRepresentativeRisk" + iOutRepresentativeId + "\"><span>," + strOutValueArray[iOutRepresentativeId - 1] + " <a class=\"remove_fOutld\" onclick=\"DeleteOutRepresentativeRisk(" + iOutRepresentativeId + ", " + strOutIdArray[iOutRepresentativeId - 1] + ", '" + strOutValueArray[iOutRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }

                        }
                        else
                        {
                            if (iOutRepresentativeId == 1)
                            {
                                dvOutRepresentativeValuesRisk.InnerHtml = "<span id=\"dvOutRepresentativeRisk" + iOutRepresentativeId + "\"><span>" + strOutValueArray[iOutRepresentativeId - 1] + " <a class=\"remove_fOutld\" onclick=\"DeleteOutRepresentativeRisk_none(" + iOutRepresentativeId + ", " + strOutIdArray[iOutRepresentativeId - 1] + ", '" + strOutValueArray[iOutRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                            else
                            {
                                dvOutRepresentativeValuesRisk.InnerHtml += "<span id=\"dvOutRepresentativeRisk" + iOutRepresentativeId + "\"><span>," + strOutValueArray[iOutRepresentativeId - 1] + " <a class=\"remove_fOutld\" onclick=\"DeleteOutRepresentativeRisk_none(" + iOutRepresentativeId + ", " + strOutIdArray[iOutRepresentativeId - 1] + ", '" + strOutValueArray[iOutRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                            }
                        }
                        hdnOutCounterRisk.Value = iOutRepresentativeId.ToString();
                    }
                }

                hdnOutRepresentativeNameRisk.Value = dsRiskAnalysis.Tables[0].Rows[0]["OutSourceRepresentativesName"].ToString();
            }
            //end====abhishek=========================================================//

            //if(dsRiskAnalysis.Tables[2]!=null)
            //ViewState["currentStatus"] = dsRiskAnalysis.Tables[2].Rows[0]["CurrentSt"];

            chkAccountManager.Checked = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]);

            chkQAProd.Checked = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]);
            chkMerchandisingMgr.Checked = true;
            bool isva = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsVA"]);
            if (isva)
            {
                chkvalueAddtion.Checked = true;
                //GrdValueAddtion.Visible = true;
            }
            else
            {
                chkvalueAddtion.Checked = false;
                // GrdValueAddtion.Visible = false;
            }
            DatabaseReuse = dsRiskAnalysis.Tables[0].Rows[0]["IsReuse"] == DBNull.Value ? 0 : Convert.ToInt32(dsRiskAnalysis.Tables[0].Rows[0]["IsReuse"]);
            if (chkAccountManager.Checked)
            {
                lblChkAcMgrDate.Text = dsRiskAnalysis.Tables[0].Rows[0]["AccountMgrApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["AccountMgrApprovedOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblChkAcMgrDate.Text = "";
            }


            if (chkQAProd.Checked)
            {
                lblChkQaMgrDate.Text = dsRiskAnalysis.Tables[0].Rows[0]["QAProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["QAProdApprovedOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblChkQaMgrDate.Text = "";
            }
            //if (chkMerchandisingMgr.Checked)
            //{
            //    RiskChkMerchandisingMgrDate.Text = dsRiskAnalysis.Tables[0].Rows[0]["MerchandisingMgrApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["MerchandisingMgrApprovedOn"]).ToString("dd-MMM-yyyy");
            //}
            //else
            //{
            //    RiskChkMerchandisingMgrDate.Text = "";
            //}
            //END


            if (ReUse == 1)
            {

                chkAccountManager.Enabled = false;

                chkQAProd.Enabled = false;
                chkMerchandisingMgr.Enabled = false;
            }
            if ((DatabaseReuse == 1) && (CreateNew == 0) && (NewRef == 0))
            {
                chkAccountManager.Enabled = false;

                chkQAProd.Enabled = false;
                chkMerchandisingMgr.Enabled = false;
            }
            ShowGridPopup.Visible = false;
            if (dsRiskAnalysis.Tables[1].Rows.Count > 0)
            {
                repStyleCodeVirsion.DataSource = dsRiskAnalysis.Tables[1];
                repStyleCodeVirsion.DataBind();
            }
            else
            {
                repStyleCodeVirsion.DataSource = null;
                repStyleCodeVirsion.DataBind();
            }

            if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
            {
                if (NewRef == 1)
                {
                    chkAccountManager.Enabled = true;

                    chkQAProd.Enabled = true;
                    chkMerchandisingMgr.Enabled = true;
                    FinalRiskDone(1);
                }
                else
                {
                    chkAccountManager.Enabled = false;

                    chkQAProd.Enabled = false;
                    chkMerchandisingMgr.Enabled = false;
                    FinalRiskDone(2);

                }

                btnAddFactory.Visible = false; ;
                btnAddSampling.Visible = false;
                btnAddIE.Visible = false;
                btnAddFabric.Visible = false;
                btnAddAccessory.Visible = false;
                btnAddOut.Visible = false;
                btnAddMerchandiser.Visible = false;
                btnAddQa.Visible = false;


            }

            if (NewRef == 1)
            {
                chkAccountManager.Enabled = true;

                chkQAProd.Enabled = true;
                chkMerchandisingMgr.Enabled = true;
                FinalRiskDone(1);
            }
        }

        protected void rptAccessoriesRisk_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string OrderDetailsID = (DataBinder.Eval(e.Item.DataItem, "OrderDetailsID").ToString());
                string AccessoriesName = (DataBinder.Eval(e.Item.DataItem, "AccessoriesName").ToString());

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CreateNew = Convert.ToInt32(hdnRiskCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
            ReUse = Convert.ToInt32(hdnRiskReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnRiskStyleId.Value);
            ReUseStyleNumber = hdnRiskStyleNumber.Value;





            if (ViewState["PopUpClick"] != null)
            {
                if (ViewState["PopUpClick"].ToString() == "1")
                {
                    SaveRiskAnalysis(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    ViewState["PopUpClick"] = "0";
                }
                else
                {
                    SaveRiskAnalysis(0, 0, 0, -1);
                }
            }
            else
            {
                SaveRiskAnalysis(0, 0, 0, -1);
            }


        }

        private void SaveRiskAnalysis(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            if (chkAccountManager.Checked)
            {
                objRisk.IsAccountMgr = true;
            }

            if (chkQAProd.Checked)
            {
                objRisk.IsQAProd = true;
            }
            objRisk.IsMerchandisingMgr = true;
            //if (chkMerchandisingMgr.Checked)
            //{
            //    objRisk.IsMerchandisingMgr = true;
            //}
            if (chkvalueAddtion.Checked)
            {
                objRisk.ISVaRequried = true;
            }
            if (chkvalueAddtion.Checked == false)
            {
                objRisk.ISVaRequried = false;
            }


            //added by abhishek on 17/5/2017
            if (hdnQaRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnQaRepresentativeIdRisk.Value = hdnQaRepresentativeIdRisk.Value.Substring(1, hdnQaRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnQaRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnQaRepresentativeNameRisk.Value = hdnQaRepresentativeNameRisk.Value.Substring(1, hdnQaRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.QaRepresentativeIds = hdnQaRepresentativeIdRisk.Value;
            objRisk.QaRepresentativeNames = hdnQaRepresentativeNameRisk.Value;

            if (hdnFactoryRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnFactoryRepresentativeIdRisk.Value = hdnFactoryRepresentativeIdRisk.Value.Substring(1, hdnFactoryRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnFactoryRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnFactoryRepresentativeNameRisk.Value = hdnFactoryRepresentativeNameRisk.Value.Substring(1, hdnFactoryRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.FactoryRepresentativeIds = hdnFactoryRepresentativeIdRisk.Value;
            objRisk.FactoryRepresentativeNames = hdnFactoryRepresentativeNameRisk.Value;

            if (hdnMerchandiserRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnMerchandiserRepresentativeIdRisk.Value = hdnMerchandiserRepresentativeIdRisk.Value.Substring(1, hdnMerchandiserRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnMerchandiserRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnMerchandiserRepresentativeNameRisk.Value = hdnMerchandiserRepresentativeNameRisk.Value.Substring(1, hdnMerchandiserRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.MerchandiserId = hdnMerchandiserRepresentativeIdRisk.Value;
            objRisk.MerchandiserName = hdnMerchandiserRepresentativeNameRisk.Value;


            if (hdnIERepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnIERepresentativeIdRisk.Value = hdnIERepresentativeIdRisk.Value.Substring(1, hdnIERepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnIERepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnIERepresentativeNameRisk.Value = hdnIERepresentativeNameRisk.Value.Substring(1, hdnIERepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.IERepresentativesId = hdnIERepresentativeIdRisk.Value;
            objRisk.IERepresentativesName = hdnIERepresentativeNameRisk.Value;

            if (hdnSamplingRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnSamplingRepresentativeIdRisk.Value = hdnSamplingRepresentativeIdRisk.Value.Substring(1, hdnSamplingRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnSamplingRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnSamplingRepresentativeNameRisk.Value = hdnSamplingRepresentativeNameRisk.Value.Substring(1, hdnSamplingRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.SamplingRepresentativesId = hdnSamplingRepresentativeIdRisk.Value;
            objRisk.SamplingRepresentativesName = hdnSamplingRepresentativeNameRisk.Value;


            if (hdnFabricRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnFabricRepresentativeIdRisk.Value = hdnFabricRepresentativeIdRisk.Value.Substring(1, hdnFabricRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnFabricRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnFabricRepresentativeNameRisk.Value = hdnFabricRepresentativeNameRisk.Value.Substring(1, hdnFabricRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.FabricRepresentativesId = hdnFabricRepresentativeIdRisk.Value;
            objRisk.FabricRepresentativesName = hdnFabricRepresentativeNameRisk.Value;


            if (hdnAccessoryRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnAccessoryRepresentativeIdRisk.Value = hdnAccessoryRepresentativeIdRisk.Value.Substring(1, hdnAccessoryRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnAccessoryRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnAccessoryRepresentativeNameRisk.Value = hdnAccessoryRepresentativeNameRisk.Value.Substring(1, hdnAccessoryRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.AccessoryRepresentativesId = hdnAccessoryRepresentativeIdRisk.Value;
            objRisk.AccessoryRepresentativesName = hdnAccessoryRepresentativeNameRisk.Value;


            if (hdnOutRepresentativeIdRisk.Value.StartsWith(","))
            {
                hdnOutRepresentativeIdRisk.Value = hdnOutRepresentativeIdRisk.Value.Substring(1, hdnOutRepresentativeIdRisk.Value.Length - 1);
            }
            if (hdnOutRepresentativeNameRisk.Value.StartsWith(","))
            {
                hdnOutRepresentativeNameRisk.Value = hdnOutRepresentativeNameRisk.Value.Substring(1, hdnOutRepresentativeNameRisk.Value.Length - 1);
            }
            objRisk.OutRepresentativesId = hdnOutRepresentativeIdRisk.Value;
            objRisk.OutRepresentativesName = hdnOutRepresentativeNameRisk.Value;



            //end
            int isave = obj_ProcessController.SaveRiskAnalysis(stylenumber, styleid, strClientId, DepartmentId, OrderId, CreateNew, ReUse, ReUseStyleId, objRisk.IsAccountMgr, false, objRisk.IsQAProd, objRisk.IsMerchandisingMgr, objRisk.ISVaRequried, objRisk.QaRepresentativeIds, objRisk.QaRepresentativeNames, objRisk.FactoryRepresentativeIds, objRisk.FactoryRepresentativeNames, objRisk.MerchandiserId, objRisk.MerchandiserName,
                objRisk.IERepresentativesId, objRisk.IERepresentativesName, objRisk.SamplingRepresentativesId, objRisk.SamplingRepresentativesName, objRisk.FabricRepresentativesId,
                objRisk.FabricRepresentativesName, objRisk.AccessoryRepresentativesId, objRisk.AccessoryRepresentativesName, objRisk.OutRepresentativesId, objRisk.OutRepresentativesName
                );

            if (isave == 1)
            {
                //now all comments will be save on button click without submit the page
                #region "Abhishek"
                SaveRemarks(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveAccessoryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveFitingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveMakingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveImbroideryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveWashingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                SaveFinishingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                #endregion
                //if (chkvalueAddtion.Checked)
                SaveValueAddtion(CreateNew, NewRefrence, ReUse, ReUseStyleId);

                // Add By Ravi kumar on 28/07/2015 create task for Risk
                int iWorkClose;
                //int DesigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
                //if (DesigId == 14)
                //{
                if ((chkAccountManager.Checked) && (chkQAProd.Checked))
                {
                    //// Edit By Nikhil
                    //iWorkClose = obj_WorkFlowController.Update_userTaskFor_OB_Risk("Risk", 16, styleid, OrderId, DateTime.Now, ApplicationHelper.LoggedInUser.UserData.UserID);
                    //string OBRiskDone = "";
                    //OBRiskDone = WorkflowControllerInstance.IsOBRiskDone(styleid, OrderId, "LIMITATION");
                    //if (OBRiskDone == "")
                    //{
                    //  int WorkflowDone = WorkflowControllerInstance.WorkflowTask_OB_Risk(styleid, OrderId, "RISK");
                    //}
                    ////
                    iWorkClose = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, OrderId, TaskMode.Risk, ApplicationHelper.LoggedInUser.UserData.UserID);
                    iWorkClose = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, OrderId, TaskMode.LIVE, ApplicationHelper.LoggedInUser.UserData.UserID);
                }
                //}
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Data Saved Successfully.');", true);
                // End By Ravi kumar on 28/07/2015 create task for Risk

                BindControl(0, 0, 0, -1, "");
                BindRemarkGrd(0, 0, 0, -1, "");
                BindAccessoriesGrd(0, 0, 0, -1, "");
                BindFitingGrd(0, 0, 0, -1, "");
                BindMakingGrd(0, 0, 0, -1, "");
                BindImbroideryGrd(0, 0, 0, -1, "");
                BindWashingGrd(0, 0, 0, -1, "");
                BindFinishingGrd(0, 0, 0, -1, "");
                BindValueAddtion(0, 0, 0, -1, "");
                SetRiskPermission(ReUse);
                btnSubmit.Enabled = true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Page could not saved');", true);
                btnSubmit.Enabled = true;
            }
        }

        private void SaveValueAddtion(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {

            try
            {
                RiskAnalysisOB objRisk = new RiskAnalysisOB();
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                int RiskFabricId = 0;
                int StyleSequence = 0;
                string RemarksType = "ValueAddtion";

                foreach (GridViewRow gvr in GrdValueAddtion.Rows)
                {
                    int Fromid = 0, tostid = 0, vaddid = 0;
                    Boolean ISUSEVA = false, ISUSE = false;
                    HiddenField FromStid = (HiddenField)gvr.FindControl("FromStid");
                    HiddenField toid = (HiddenField)gvr.FindControl("hdntoid");
                    HiddenField Valid = (HiddenField)gvr.FindControl("hdnValid");

                    CheckBox ISUSEVAd = (CheckBox)gvr.FindControl("ISUSEVA");
                    CheckBox ISUSEd = (CheckBox)gvr.FindControl("ISUSE");

                    Fromid = Convert.ToInt32(FromStid.Value);
                    tostid = Convert.ToInt32(toid.Value);
                    vaddid = Convert.ToInt32(Valid.Value);
                    //HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnorderid");
                    //HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnorderdetail");

                    if (ISUSEd.Checked)
                        ISUSE = true;
                    else
                        ISUSE = false;

                    if (ISUSEVAd.Checked)
                        ISUSEVA = true;
                    else
                        ISUSEVA = false;

                    if (null != Request.QueryString["OrderId"])
                    {
                        OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
                    }

                    int iSaveComment = obj_ProcessController.InsertUpdateValueAddtion(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, "", RiskFabricId, StyleSequence, RemarksType, UserId, Fromid, tostid, vaddid, ISUSE, ISUSEVA, OrderId);
                    if (iSaveComment > 0)
                    {
                        //lblmsg.Text = "Finshing Update SucessFully!";
                        //lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                }
                // }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void repStyleCodeVirsion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                string StyleidNew = ((HiddenField)e.Item.FindControl("rephdnStyleid")).Value;
                string StyleCodeNew = ((HiddenField)e.Item.FindControl("rephdnStylCode")).Value;
                StyleCodeNew = "" + StyleCodeNew + "";

            }
        }

        protected void btnSubmitFromRiskPopUP_Click(object sender, EventArgs e)
        {
            CreateNew = Convert.ToInt32(hdnRiskCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
            ReUse = Convert.ToInt32(hdnRiskReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnRiskStyleId.Value);
            ReUseStyleNumber = hdnRiskStyleNumber.Value;

            BindControl(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindValueAddtion(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            //BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            SetRiskPermission(ReUse);
            ViewState["PopUpClick"] = "1";
        }

        protected void gvRiskAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);
            Label lblFabric1 = e.Row.FindControl("lblFabric1") as Label;
            Label lblFabric2 = e.Row.FindControl("lblFabric2") as Label;
            Label lblFabric3 = e.Row.FindControl("lblFabric3") as Label;
            Label lblFabric4 = e.Row.FindControl("lblFabric4") as Label;
            Label lblFabric5 = e.Row.FindControl("lblFabric5") as Label;
            Label lblFabric6 = e.Row.FindControl("lblFabric6") as Label;

            Label Fabric1Percent = e.Row.FindControl("lblFabric1Percent") as Label;
            Label Fabric2Percent = e.Row.FindControl("lblFabric2Percent") as Label;
            Label Fabric3Percent = e.Row.FindControl("lblFabric3Percent") as Label;
            Label Fabric4Percent = e.Row.FindControl("lblFabric4Percent") as Label;
            Label Fabric5Percent = e.Row.FindControl("lblFabric5Percent") as Label;
            Label Fabric6Percent = e.Row.FindControl("lblFabric6Percent") as Label;

            Label lblFabric1DetailsRef = e.Row.FindControl("lblFabric1DetailsRef") as Label;
            Label lblFabric2DetailsRef = e.Row.FindControl("lblFabric2DetailsRef") as Label;
            Label lblFabric3DetailsRef = e.Row.FindControl("lblFabric3DetailsRef") as Label;
            Label lblFabric4DetailsRef = e.Row.FindControl("lblFabric4DetailsRef") as Label;
            Label lblFabric5DetailsRef = e.Row.FindControl("lblFabric5DetailsRef") as Label;
            Label lblFabric6DetailsRef = e.Row.FindControl("lblFabric6DetailsRef") as Label;

            Label lblFabricStartETAdate1 = e.Row.FindControl("lblFabricStartETAdate1") as Label;
            Label lblFabricEndETAdate1 = e.Row.FindControl("lblFabricEndETAdate1") as Label;
            Label lblFabricStartETAdate2 = e.Row.FindControl("lblFabricStartETAdate2") as Label;
            Label lblFabricEndETAdate2 = e.Row.FindControl("lblFabricEndETAdate2") as Label;
            Label lblFabricStartETAdate3 = e.Row.FindControl("lblFabricStartETAdate3") as Label;
            Label lblFabricEndETAdate3 = e.Row.FindControl("lblFabricEndETAdate3") as Label;
            Label lblFabricStartETAdate4 = e.Row.FindControl("lblFabricStartETAdate4") as Label;
            Label lblFabricEndETAdate4 = e.Row.FindControl("lblFabricEndETAdate4") as Label;
            Label lblFabricStartETAdate5 = e.Row.FindControl("lblFabricStartETAdate5") as Label;
            Label lblFabricEndETAdate5 = e.Row.FindControl("lblFabricEndETAdate5") as Label;
            Label lblFabricStartETAdate6 = e.Row.FindControl("lblFabricStartETAdate6") as Label;
            Label lblFabricEndETAdate6 = e.Row.FindControl("lblFabricEndETAdate6") as Label;


            HtmlTableRow tbl1 = (HtmlTableRow)e.Row.FindControl("tbl1");
            HtmlTableRow tbl2 = (HtmlTableRow)e.Row.FindControl("tbl2");
            HtmlTableRow tbl3 = (HtmlTableRow)e.Row.FindControl("tbl3");
            HtmlTableRow tbl4 = (HtmlTableRow)e.Row.FindControl("tbl4");
            HtmlTableRow tbl5 = (HtmlTableRow)e.Row.FindControl("tbl5");
            HtmlTableRow tbl6 = (HtmlTableRow)e.Row.FindControl("tbl6");

            Label lvlCutReady = e.Row.FindControl("lvlCutReady") as Label;
            Label lblCutPercentInhouse = e.Row.FindControl("lblCutPercentInhouse") as Label;
            Label lblStitched = e.Row.FindControl("lblStitched") as Label;
            Label lblStitchedPercentInhouse = e.Row.FindControl("lblStitchedPercentInhouse") as Label;
            Label lvlVA = e.Row.FindControl("lvlVA") as Label;
            Label lblVAPercentInhouse = e.Row.FindControl("lblVAPercentInhouse") as Label;
            Label lblPacked = e.Row.FindControl("lblPacked") as Label;
            Label lblPackedPercentInhouse = e.Row.FindControl("lblPackedPercentInhouse") as Label;

            Label lblCutreadyENDETA = e.Row.FindControl("lblCutreadyENDETA") as Label;
            Label lblCutreadyStartETA = e.Row.FindControl("lblCutreadyStartETA") as Label;
            Label lblStichedStartETA = e.Row.FindControl("lblStichedStartETA") as Label;
            Label lblStichedENDETA = e.Row.FindControl("lblStichedENDETA") as Label;
            Label lblVAStartETA = e.Row.FindControl("lblVAStartETA") as Label;
            Label lblVAENDETA = e.Row.FindControl("lblVAENDETA") as Label;
            Label lblPackedETA = e.Row.FindControl("lblPackedETA") as Label;
            HtmlTableCell tdFabric1 = e.Row.FindControl("tdFabric1") as HtmlTableCell;
            HtmlTableCell tdprint1 = e.Row.FindControl("tdprint1") as HtmlTableCell;
            HtmlTableCell tdFabric1DetailsRef = e.Row.FindControl("tdFabric1DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate1 = e.Row.FindControl("tdFabricStartETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate1 = e.Row.FindControl("tdFabricEndETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabric2 = e.Row.FindControl("tdFabric2") as HtmlTableCell;
            HtmlTableCell tdFabric2Percent = e.Row.FindControl("tdFabric2Percent") as HtmlTableCell;
            HtmlTableCell tdFabric2DetailsRef = e.Row.FindControl("tdFabric2DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate2 = e.Row.FindControl("tdFabricStartETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate2 = e.Row.FindControl("tdFabricEndETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabric3 = e.Row.FindControl("tdFabric3") as HtmlTableCell;
            HtmlTableCell tdFabric3Percent = e.Row.FindControl("tdFabric3Percent") as HtmlTableCell;
            HtmlTableCell tdFabric3DetailsRef = e.Row.FindControl("tdFabric3DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate3 = e.Row.FindControl("tdFabricStartETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate3 = e.Row.FindControl("tdFabricEndETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabric4Percent = e.Row.FindControl("tdFabric4Percent") as HtmlTableCell;
            HtmlTableCell tdFabric4DetailsRef = e.Row.FindControl("tdFabric4DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate4 = e.Row.FindControl("tdFabricStartETAdate4") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate4 = e.Row.FindControl("tdFabricEndETAdate4") as HtmlTableCell;
            // --------------------------------------------
            HtmlTableCell tdCutReady = e.Row.FindControl("tdCutReady") as HtmlTableCell;
            HtmlTableCell tdCutPercentInhouse = e.Row.FindControl("tdCutPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdCutreadyStartETA = e.Row.FindControl("tdCutreadyStartETA") as HtmlTableCell;
            HtmlTableCell tdCutreadyENDETA = e.Row.FindControl("tdCutreadyENDETA") as HtmlTableCell;
            HtmlTableCell tdStitched = e.Row.FindControl("tdStitched") as HtmlTableCell;
            HtmlTableCell tdStitchedPercentInhouse = e.Row.FindControl("tdStitchedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdStichedStartETA = e.Row.FindControl("tdStichedStartETA") as HtmlTableCell;
            HtmlTableCell tdStichedENDETA = e.Row.FindControl("tdStichedENDETA") as HtmlTableCell;
            HtmlTableCell tdVA = e.Row.FindControl("tdVA") as HtmlTableCell;
            HtmlTableCell tdVAPercentInhouse = e.Row.FindControl("tdVAPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdVAStartETA = e.Row.FindControl("tdVAStartETA") as HtmlTableCell;
            HtmlTableCell tdVAENDETA = e.Row.FindControl("tdVAENDETA") as HtmlTableCell;
            HtmlTableCell tdlPacked = e.Row.FindControl("tdlPacked") as HtmlTableCell;
            HtmlTableCell tdPackedPercentInhouse = e.Row.FindControl("tdPackedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdPackedETA = e.Row.FindControl("tdPackedETA") as HtmlTableCell;
            //---------------------
            HtmlTableCell tdstc = e.Row.FindControl("tdstc") as HtmlTableCell;
            HtmlTableCell tdLabel6 = e.Row.FindControl("tdLabel6") as HtmlTableCell;
            HtmlTableCell tdPatternSample = e.Row.FindControl("tdPatternSample") as HtmlTableCell;
            HtmlTableCell tdPatternETA = e.Row.FindControl("tdPatternETA") as HtmlTableCell;
            HtmlTableCell tdtop = e.Row.FindControl("tdtop") as HtmlTableCell;
            HtmlTableCell tdTOPETA = e.Row.FindControl("tdTOPETA") as HtmlTableCell;



            CheckBox CheckCB = e.Row.FindControl("cb") as CheckBox;




            if (lblFabric1 != null)
            {
                if (lblFabric1.Text != "")
                {
                    tbl1.Visible = true;
                    // if (Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    if (lblFabricStartETAdate1.Text != "" && lblFabricEndETAdate1.Text != "" && Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    {
                        lblFabric1.ForeColor = Color.Gray;
                        Fabric1Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate1.ForeColor = Color.Gray;
                        lblFabricEndETAdate1.ForeColor = Color.Gray;
                        lblFabric1DetailsRef.ForeColor = Color.Gray;

                    }


                    // td3f1.Style.Add(" background-color", "#FF0000");

                }
            }
            if (lblFabric2 != null)
            {
                if (lblFabric2.Text != "")
                {
                    tbl2.Visible = true;
                    // if (Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    if (lblFabricStartETAdate2.Text != "" && lblFabricEndETAdate2.Text != "" && Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    {
                        lblFabric2.ForeColor = Color.Gray;
                        Fabric2Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate2.ForeColor = Color.Gray;
                        lblFabricEndETAdate2.ForeColor = Color.Gray;
                        lblFabric2DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric3 != null)
            {
                if (lblFabric3.Text != "")
                {
                    tbl3.Visible = true;
                    //if (Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    if (lblFabricStartETAdate3.Text != "" && lblFabricEndETAdate3.Text != "" && Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate3.ForeColor = Color.Gray;
                        lblFabricEndETAdate3.ForeColor = Color.Gray;
                        lblFabric3DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric4 != null)
            {
                if (lblFabric4.Text != "")
                {
                    tbl4.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate4.Text != "" && lblFabricEndETAdate4.Text != "" && Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate4.ForeColor = Color.Gray;
                        lblFabricEndETAdate4.ForeColor = Color.Gray;
                        lblFabric4DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }
            if (lblFabric5 != null)
            {
                if (lblFabric5.Text != "")
                {
                    tbl5.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate5.Text != "" && lblFabricEndETAdate5.Text != "" && Convert.ToInt32(Fabric5Percent.Text) >= 100)
                    {
                        lblFabric5.ForeColor = Color.Gray;
                        Fabric5Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate5.ForeColor = Color.Gray;
                        lblFabricEndETAdate5.ForeColor = Color.Gray;
                        lblFabric5DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }
            if (lblFabric6 != null)
            {
                if (lblFabric6.Text != "")
                {
                    tbl6.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate6.Text != "" && lblFabricEndETAdate6.Text != "" && Convert.ToInt32(Fabric6Percent.Text) >= 100)
                    {
                        lblFabric6.ForeColor = Color.Gray;
                        Fabric6Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate6.ForeColor = Color.Gray;
                        lblFabricEndETAdate6.ForeColor = Color.Gray;
                        lblFabric6DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }


            if (lblCutPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                if (lblCutreadyStartETA.Text != "" && lblCutreadyENDETA.Text != "" && Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                {
                    lblCutPercentInhouse.ForeColor = Color.Gray;
                    lvlCutReady.ForeColor = Color.Gray;
                    lblCutreadyENDETA.ForeColor = Color.Gray;
                    lblCutreadyStartETA.ForeColor = Color.Gray;

                }
            }



            if (lblStitchedPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                if (lblStichedStartETA.Text != "" && lblStichedENDETA.Text != "" && Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                {
                    lblStitchedPercentInhouse.ForeColor = Color.Gray;
                    lblStitched.ForeColor = Color.Gray;
                    lblStichedStartETA.ForeColor = Color.Gray;
                    lblStichedENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblVAPercentInhouse != null)
            {
                // if (Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                if (lblVAStartETA.Text != "" && lblVAENDETA.Text != "" && Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                {
                    lblVAPercentInhouse.ForeColor = Color.Gray;
                    lvlVA.ForeColor = Color.Gray;
                    lblVAStartETA.ForeColor = Color.Gray;
                    lblVAENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblPackedPercentInhouse != null)
            {
                //  if (Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100 )
                if (lblPackedETA.Text != "" && Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100)
                {
                    lblPackedPercentInhouse.ForeColor = Color.Gray;
                    lblPacked.ForeColor = Color.Gray;
                    lblPackedETA.ForeColor = Color.Gray;

                }
            }

            Repeater rptAccessoriesRisk = e.Row.FindControl("rptAccessoriesRisk") as Repeater;
            if (od.AccessoriesETA != null)
            {
                if (od.AccessoriesETA.Count > 0)
                {
                    rptAccessoriesRisk.DataSource = od.AccessoriesETA;
                    rptAccessoriesRisk.DataBind();
                }
            }



        }


        //Added By Ashish for remarks
        //Fabric
        protected void BindRemarkGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            DataSet dsgrdLimitation = new DataSet();

            string RemarksType = "Fabric";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);

                grdRiskRemarks.DataSource = dsgrd.Tables[0];
                grdRiskRemarks.DataBind();

                ViewState["datatable"] = dsgrd.Tables[0];
                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdilimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdilimitationRemarks.DataBind();
                }
                else
                {
                    grdilimitationRemarks.Visible = false;
                }


            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRemarks.DataSource = dsgrd.Tables[0];
                grdRiskRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdilimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdilimitationRemarks.DataBind();
                }
                else
                {
                    grdilimitationRemarks.Visible = false;
                }
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRemarks.DataSource = dsgrd.Tables[0];
                grdRiskRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];


                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdilimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdilimitationRemarks.DataBind();
                }
                else
                {
                    grdilimitationRemarks.Visible = false;
                }
            }
            else
            {
                if (ViewState["datatable"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskRemarks.DataSource = dsgrd.Tables[0];
                    grdRiskRemarks.DataBind();
                    ViewState["datatable"] = dsgrd.Tables[0];

                    dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                    {
                        grdilimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                        grdilimitationRemarks.DataBind();
                    }
                    else
                    {
                        grdilimitationRemarks.Visible = false;
                    }
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["datatable"]);
                    grdRiskRemarks.DataSource = dtnew;
                    grdRiskRemarks.DataBind();
                    ViewState["datatable"] = dtnew;
                    dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                    {
                        grdilimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                        grdilimitationRemarks.DataBind();
                    }
                    else
                    {
                        grdilimitationRemarks.Visible = false;
                    }
                }
            }


            PnlRemarks.Enabled = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
        }
        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("RiskFabricId", typeof(string));
            table.Columns.Add("FabricRemark", typeof(string));
            table.Columns.Add("dataTableId", typeof(string));

            return table;
        }
        protected void grdRiskRemarks_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskRemarks.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskRemarks.FooterRow.FindControl("abtnAdd") as LinkButton;
                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveRemarks(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdRiskRemarks.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskRemarks.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["datatable"] = dtnew;
                    }
                }
                BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskRemarks.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");
                string Remark = txtRemarksEmpty.Text.Trim();

                DataTable dtnew = new DataTable();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveRemarks(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["datatable"] != null)
                    {

                        dtnew = (DataTable)(ViewState["datatable"]);
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);

                        ViewState["datatable"] = dtnew;
                    }
                }
                BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                       
        }
        //updated by abhishek 30/6/2016
        protected void grdRiskRemarks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                // ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                TextBox txtRemarksEmpty = (TextBox)e.Row.FindControl("txtRemarksEmpty");
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");


                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                // lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");

                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }

            }
        }
        protected void grdRiskRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskRemarks.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskFabricId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Fabric";
            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdRiskRemarks.EditIndex = -1;
            grdRiskRemarks.DataSource = dtnew;
            grdRiskRemarks.DataBind();
            //BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);

        }
        protected void grdRiskRemarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void SaveRemarks(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Fabric";

            Control control = null;
            control = grdRiskRemarks.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdRiskRemarks.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskRemarks.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskFabricId = (HiddenField)grdRiskRemarks.Rows[i].FindControl("hdnRiskFabricId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskRemarks.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    if (hdnRiskFabricId != null)
                    {
                        if (hdnRiskFabricId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskFabricId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }
                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }


                var footerRow = grdRiskRemarks.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }

            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["datatable"] = null;

        }

        //Accessories
        protected void BindAccessoriesGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            DataSet dsgrdLimitation = new DataSet();
            string RemarksType = "Accesories";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdacssessoryLimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdacssessoryLimitationRemarks.DataBind();
                }
                else
                {
                    grdacssessoryLimitationRemarks.Visible = false;
                }

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdacssessoryLimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdacssessoryLimitationRemarks.DataBind();
                }
                else
                {
                    grdacssessoryLimitationRemarks.Visible = false;
                }
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

                dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                {
                    grdacssessoryLimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                    grdacssessoryLimitationRemarks.DataBind();
                }
                else
                {
                    grdacssessoryLimitationRemarks.Visible = false;
                }
            }
            else
            {
                if (ViewState["AccessoriesData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskAccessories.DataSource = dsgrd.Tables[0];
                    grdRiskAccessories.DataBind();
                    ViewState["AccessoriesData"] = dsgrd.Tables[0];


                    dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                    {
                        grdacssessoryLimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                        grdacssessoryLimitationRemarks.DataBind();
                    }
                    else
                    {
                        grdacssessoryLimitationRemarks.Visible = false;
                    }
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["AccessoriesData"]);
                    grdRiskAccessories.DataSource = dtnew;
                    grdRiskAccessories.DataBind();
                    ViewState["AccessoriesData"] = dtnew;


                    dsgrdLimitation = obj_ProcessController.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                    {
                        grdacssessoryLimitationRemarks.DataSource = dsgrdLimitation.Tables[0];
                        grdacssessoryLimitationRemarks.DataBind();
                    }
                    else
                    {
                        grdacssessoryLimitationRemarks.Visible = false;
                    }
                }
            }

        }
        protected void grdRiskAccessories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskAccessories.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskAccessories.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {

                    SaveAccessoryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);

                    if (ViewState["AccessoriesData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["AccessoriesData"]);
                        for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["AccessoryRemark"] = ((TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["AccessoriesData"] = dtnew;
                    }
                    //if (ViewState["AccessoriesData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["AccessoriesData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, txtRemarkFooter.Text.Trim(), sl + 1);
                    //    ViewState["AccessoriesData"] = dtnew;
                    //}
                }
                BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskAccessories.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveAccessoryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["AccessoriesData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["AccessoriesData"]);
                        for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["AccessoryRemark"] = ((TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["AccessoriesData"] = dtnew;
                    }
                    //if (ViewState["AccessoriesData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["AccessoriesData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, txtRemarksEmpty.Text.Trim(), sl + 1);
                    //    ViewState["AccessoriesData"] = dtnew;
                    //}
                }
                BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdRiskAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                // ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                TextBox txtRemarksEmpty = (TextBox)e.Row.FindControl("txtRemarksEmpty");
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");


                //if (ReUse == 1)
                //{
                //    lnkDelete.Visible = false;
                //}
                // lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");

                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }

            }
        }
        protected void grdRiskAccessories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskAccessories.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Accesories";

            if (ViewState["AccessoriesData"] != null)
            {
                dtnew = (DataTable)(ViewState["AccessoriesData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskAccessoryId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["AccessoriesData"] = dtnew;
            }


            grdRiskAccessories.EditIndex = -1;
            grdRiskAccessories.DataSource = dtnew;
            grdRiskAccessories.DataBind();
            //BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void grdRiskAccessories_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void SaveAccessoryRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Accesories";

            Control control = null;
            control = grdRiskAccessories.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskAccessories.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskAccessories.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }

                var footerRow = grdRiskAccessories.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }


            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["AccessoriesData"] = null;

        }

        //Fiting
        protected void BindFitingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Fitting";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["FitingData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdriskFiting.DataSource = dsgrd.Tables[0];
                    grdriskFiting.DataBind();
                    ViewState["FitingData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["FitingData"]);
                    grdriskFiting.DataSource = dtnew;
                    grdriskFiting.DataBind();
                    ViewState["FitingData"] = dtnew;
                }
            }

        }
        protected void grdriskFiting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdriskFiting.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdriskFiting.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveFitingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["FitingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FitingData"]);
                        for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FittingRemark"] = ((TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FitingData"] = dtnew;
                    }

                }
                BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdriskFiting.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveFitingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["FitingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FitingData"]);
                        for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FittingRemark"] = ((TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FitingData"] = dtnew;
                    }
                    //if (ViewState["FitingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["FitingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["FitingData"] = dtnew;
                    //}
                }
                BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdriskFiting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdriskFiting.PageIndex * grdriskFiting.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);

                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");

                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }

            }
        }
        protected void grdriskFiting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdriskFiting.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Fitting";
            if (ViewState["FitingData"] != null)
            {
                dtnew = (DataTable)(ViewState["FitingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFittingId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["FitingData"] = dtnew;
            }


            grdriskFiting.EditIndex = -1;
            grdriskFiting.DataSource = dtnew;
            grdriskFiting.DataBind();
            //BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveFitingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Fitting";

            Control control = null;
            control = grdriskFiting.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdriskFiting.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdriskFiting.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
                var footerRow = grdriskFiting.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["FitingData"] = null;
        }

        //Making
        protected void BindMakingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Making";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["MakingData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskMaking.DataSource = dsgrd.Tables[0];
                    grdRiskMaking.DataBind();
                    ViewState["MakingData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["MakingData"]);
                    grdRiskMaking.DataSource = dtnew;
                    grdRiskMaking.DataBind();
                    ViewState["MakingData"] = dtnew;
                }
            }

        }
        protected void grdRiskMaking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskMaking.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskMaking.FooterRow.FindControl("abtnAdd") as LinkButton;
                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();

                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveMakingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["MakingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["MakingData"]);
                        for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["MakingRemark"] = ((TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["MakingData"] = dtnew;
                    }

                }
                BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskMaking.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveMakingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["MakingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["MakingData"]);
                        for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["MakingRemark"] = ((TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["MakingData"] = dtnew;
                    }
                }
                BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdRiskMaking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskMaking.PageIndex * grdRiskMaking.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }
            }
        }
        protected void grdRiskMaking_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskMaking.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Making";
            if (ViewState["MakingData"] != null)
            {
                dtnew = (DataTable)(ViewState["MakingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskMakingId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["MakingData"] = dtnew;
            }
            grdRiskMaking.EditIndex = -1;
            grdRiskMaking.DataSource = dtnew;
            grdRiskMaking.DataBind();
            //BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveMakingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Making";

            Control control = null;
            control = grdRiskMaking.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskMaking.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskMaking.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
                var footerRow = grdRiskMaking.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["MakingData"] = null;
        }
        //Imbroidery
        protected void BindImbroideryGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Imbroidery";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["ImbroideryData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                    grdRiskImbroidery.DataBind();
                    ViewState["ImbroideryData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["ImbroideryData"]);
                    grdRiskImbroidery.DataSource = dtnew;
                    grdRiskImbroidery.DataBind();
                    ViewState["ImbroideryData"] = dtnew;
                }
            }

        }
        protected void grdRiskImbroidery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskImbroidery.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskImbroidery.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveImbroideryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["ImbroideryData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["ImbroideryData"]);
                        for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["ImbroideryRemark"] = ((TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["ImbroideryData"] = dtnew;
                    }
                    //if (ViewState["ImbroideryData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["ImbroideryData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["ImbroideryData"] = dtnew;
                    //}
                }
                BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskImbroidery.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveImbroideryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["ImbroideryData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["ImbroideryData"]);
                        for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["ImbroideryRemark"] = ((TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["ImbroideryData"] = dtnew;
                    }
                }
                BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdRiskImbroidery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                // ltIndex.Text = ((grdRiskImbroidery.PageIndex * grdRiskImbroidery.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }

                }


            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");

                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }
            }
        }
        protected void grdRiskImbroidery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskImbroidery.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Imbroidery";
            if (ViewState["ImbroideryData"] != null)
            {
                dtnew = (DataTable)(ViewState["ImbroideryData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskImbroideryId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["ImbroideryData"] = dtnew;
            }


            grdRiskImbroidery.EditIndex = -1;
            grdRiskImbroidery.DataSource = dtnew;
            grdRiskImbroidery.DataBind();
            //BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveImbroideryRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;

            string RemarksType = "Imbroidery";
            Control control = null;
            control = grdRiskImbroidery.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskImbroidery.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskImbroidery.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdRiskImbroidery.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }

            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["ImbroideryData"] = null;
        }
        //Washing
        protected void BindWashingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Washing";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["WashingData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskWashing.DataSource = dsgrd.Tables[0];
                    grdRiskWashing.DataBind();
                    ViewState["WashingData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["WashingData"]);
                    grdRiskWashing.DataSource = dtnew;
                    grdRiskWashing.DataBind();
                    ViewState["WashingData"] = dtnew;
                }
            }

        }
        protected void grdRiskWashing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskWashing.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskWashing.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveWashingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["WashingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["WashingData"]);
                        for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["WashingRemark"] = ((TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["WashingData"] = dtnew;
                    }
                    //if (ViewState["WashingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["WashingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["WashingData"] = dtnew;
                    //}
                }
                BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskWashing.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveWashingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["WashingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["WashingData"]);
                        for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["WashingRemark"] = ((TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["WashingData"] = dtnew;
                    }
                }
                BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdRiskWashing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                // ltIndex.Text = ((grdRiskWashing.PageIndex * grdRiskWashing.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");

                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }
            }
        }
        protected void grdRiskWashing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskWashing.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Washing";
            if (ViewState["WashingData"] != null)
            {
                dtnew = (DataTable)(ViewState["WashingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskWashingId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["WashingData"] = dtnew;
            }
            grdRiskWashing.EditIndex = -1;
            grdRiskWashing.DataSource = dtnew;
            grdRiskWashing.DataBind();
            //BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveWashingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Washing";

            Control control = null;
            control = grdRiskWashing.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskWashing.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskWashing.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {

                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdRiskWashing.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["WashingData"] = null;

        }
        //Finishing
        protected void BindFinishingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Finishing";
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["FinishingData"] == null)
                {
                    dsgrd = obj_ProcessController.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdRiskFinishing.DataSource = dsgrd.Tables[0];
                    grdRiskFinishing.DataBind();
                    ViewState["FinishingData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["FinishingData"]);
                    grdRiskFinishing.DataSource = dtnew;
                    grdRiskFinishing.DataBind();
                    ViewState["FinishingData"] = dtnew;
                }
            }

        }
        protected void grdRiskFinishing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskFinishing.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskFinishing.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveFinishingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FinishingRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                    //if (ViewState["FinishingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["FinishingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["FinishingData"] = dtnew;
                    //}
                }
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskFinishing.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    SaveFinishingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FinishingRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                }
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            btnSubmit_Click(sender, e);
                 
        }
        protected void grdRiskFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskFinishing.PageIndex * grdRiskFinishing.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                lnkDelete.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                addbutton.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                abtnAdd.Visible = obj_ProcessController.CheckIsRiskDone(OrderId) ? false : true;
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }
            }
        }
        protected void grdRiskFinishing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskFinishing.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Finishing";
            if (ViewState["FinishingData"] != null)
            {
                dtnew = (DataTable)(ViewState["FinishingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFinishingId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["FinishingData"] = dtnew;
            }
            grdRiskFinishing.EditIndex = -1;
            grdRiskFinishing.DataSource = dtnew;
            grdRiskFinishing.DataBind();
            // BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }

        /* Added by uday */


        protected void grdValueEdtiion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskFinishing.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskFinishing.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FinishingRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                    //if (ViewState["FinishingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["FinishingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["FinishingData"] = dtnew;
                    //}
                }
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskFinishing.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FinishingRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, sl + 1, "", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                }
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
                 
        }
        protected void grdValueEdtiion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskFinishing.PageIndex * grdRiskFinishing.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (ReUse == 1)
                {
                    abtnAdd.Visible = false;
                }
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                NewRefrence = Convert.ToInt32(hdnRiskNewRef.Value);
                if (chkAccountManager.Checked == true && chkQAProd.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                    }

                }
            }
        }
        protected void grdValueEdtiion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskFinishing.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Finishing";
            if (ViewState["FinishingData"] != null)
            {
                dtnew = (DataTable)(ViewState["FinishingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFinishingId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteRiskRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["FinishingData"] = dtnew;
            }


            grdRiskFinishing.EditIndex = -1;
            grdRiskFinishing.DataSource = dtnew;
            grdRiskFinishing.DataBind();
            //BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }

        protected void SaveFinishingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Finishing";

            Control control = null;
            control = grdRiskFinishing.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskFinishing.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskFinishing.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }

                    if (Remark != null)
                    {
                        if (Remark != "")
                        {

                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdRiskFinishing.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_ProcessController.InsertUpdateRiskRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["FinishingData"] = null;

        }

        protected void GridRiskFabricRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridRiskAccessory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridRiskFittingRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridRiskMakingRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridImbroidery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }
        protected void GridRiskWashing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }
        protected void GridRiskFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdRiskRemarks.PageIndex * grdRiskRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }


        protected void btnShowGrid_Click(object sender, EventArgs e)
        {
            string StyleidNew = ((HiddenField)repStyleCodeVirsion.Items[repStyleCodeVirsion.Items.Count - 1].FindControl("rephdnStyleid")).Value;
            string StyleCodeNew = ((HiddenField)repStyleCodeVirsion.Items[repStyleCodeVirsion.Items.Count - 1].FindControl("rephdnStylCode")).Value;
            ((HiddenField)repStyleCodeVirsion.Items[repStyleCodeVirsion.Items.Count - 1].FindControl("hdnShowData")).Value = "1";

            if (StyleidNew != null)
            {
                //ShowGridPopup.Attributes.Add("style", "display:block");

                DataSet dsNewStyle = obj_ProcessController.GetRiskAllRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));
                //GridRiskFabricRemark.DataSource=dsNewStyle.Tables.
                DataTable dt0 = dsNewStyle.Tables[0];
                DataTable dt1 = dsNewStyle.Tables[1];
                DataTable dt2 = dsNewStyle.Tables[2];
                DataTable dt3 = dsNewStyle.Tables[3];
                DataTable dt4 = dsNewStyle.Tables[4];
                DataTable dt5 = dsNewStyle.Tables[5];
                DataTable dt6 = dsNewStyle.Tables[6];
                if (dt0 != null)
                {
                    GridRiskFabricRemark.DataSource = dt0;
                    GridRiskFabricRemark.DataBind();
                    lblFabric.Text = "Fabric";
                }
                if (dt1 != null)
                {
                    GridRiskAccessory.DataSource = dt1;
                    GridRiskAccessory.DataBind();
                    lblAccessory.Text = "Accessories";
                }
                if (dt2 != null)
                {
                    GridRiskFittingRemark.DataSource = dt2;
                    GridRiskFittingRemark.DataBind();
                    lblFiting.Text = "Fitting";
                }
                if (dt3 != null)
                {
                    GridRiskMakingRemark.DataSource = dt3;
                    GridRiskMakingRemark.DataBind();
                    lblMaking.Text = "Making";
                }

                if (dt4 != null)
                {
                    GridImbroidery.DataSource = dt4;
                    GridImbroidery.DataBind();
                    //abhsiehk
                    //lblImbroidery.Text = "Embroidery";
                    lblImbroidery.Text = "Value addition";
                    //end
                }

                if (dt5 != null)
                {
                    GridRiskWashing.DataSource = dt5;
                    GridRiskWashing.DataBind();
                    lblRiskWashing.Text = "Washing";
                }

                if (dt6 != null)
                {
                    GridRiskFinishing.DataSource = dt6;
                    GridRiskFinishing.DataBind();

                    //updated by abhishek on 17/8/2015
                    lblRiskFinishing.Text = "Finishing/Packing";
                    //end by abhishek on 17/8/2015-
                }

            }
        }

        protected void imgPlus_Click(object sender, EventArgs e)
        {
            DataSet dsNewStyle = new DataSet();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            dt0 = null;
            dt1 = null;
            dt2 = null;
            dt3 = null;
            dt4 = null;
            dt5 = null;
            dt6 = null;
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repStyleCodeVirsion.Items)
            {
                ImageButton imgPlus = item.FindControl("imgPlus") as ImageButton;
                imgPlus.Attributes.Add("style", "display:inline");

                ImageButton imgMinus = item.FindControl("imgMinus") as ImageButton;
                imgMinus.Attributes.Add("style", "display:none");
            }
            ImageButton imgbtnPlus = (ImageButton)sender;
            RepeaterItem ritem = (RepeaterItem)imgbtnPlus.NamingContainer;

            ImageButton imgPlusthis = ritem.FindControl("imgPlus") as ImageButton;
            imgPlusthis.Attributes.Add("style", "display:none");

            ImageButton imgMinusthis = ritem.FindControl("imgMinus") as ImageButton;
            imgMinusthis.Attributes.Add("style", "display:inline");

            string StyleidNew = ((HiddenField)ritem.FindControl("rephdnStyleid")).Value;
            string StyleCodeNew = ((HiddenField)ritem.FindControl("rephdnStylCode")).Value;

            ShowGridPopup.Visible = true;

            if (StyleidNew != null)
            {

                dsNewStyle = obj_ProcessController.GetRiskAllRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));

                dt0 = dsNewStyle.Tables[0];
                dt1 = dsNewStyle.Tables[1];
                dt2 = dsNewStyle.Tables[2];
                dt3 = dsNewStyle.Tables[3];
                dt4 = dsNewStyle.Tables[4];
                dt5 = dsNewStyle.Tables[5];
                dt6 = dsNewStyle.Tables[6];
                if (dt0 != null)
                {
                    GridRiskFabricRemark.DataSource = dt0;
                    GridRiskFabricRemark.DataBind();
                    lblFabric.Text = "Fabric";

                }
                if (dt1 != null)
                {
                    GridRiskAccessory.DataSource = dt1;
                    GridRiskAccessory.DataBind();
                    lblAccessory.Text = "Accessories";

                }
                if (dt2 != null)
                {
                    GridRiskFittingRemark.DataSource = dt2;
                    GridRiskFittingRemark.DataBind();
                    lblFiting.Text = "Fitting";

                }
                if (dt3 != null)
                {
                    GridRiskMakingRemark.DataSource = dt3;
                    GridRiskMakingRemark.DataBind();
                    lblMaking.Text = "Making";

                }
                if (dt4 != null)
                {
                    GridImbroidery.DataSource = dt4;
                    GridImbroidery.DataBind();

                    //abhsiehk
                    //lblImbroidery.Text = "Embroidery";
                    lblImbroidery.Text = "Value addition";
                    //end

                }

                if (dt5 != null)
                {
                    GridRiskWashing.DataSource = dt5;
                    GridRiskWashing.DataBind();
                    lblRiskWashing.Text = "Washing";

                }

                if (dt6 != null)
                {
                    GridRiskFinishing.DataSource = dt6;
                    GridRiskFinishing.DataBind();
                    lblRiskFinishing.Text = "Finishing";

                }


            }
        }

        protected void imgMinus_Click(object sender, EventArgs e)
        {
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repStyleCodeVirsion.Items)
            {
                ImageButton imgPlus = item.FindControl("imgPlus") as ImageButton;
                imgPlus.Attributes.Add("style", "display:inline");

                ImageButton imgMinus = item.FindControl("imgMinus") as ImageButton;
                imgMinus.Attributes.Add("style", "display:none");
            }
            ImageButton imgbtnPlus = (ImageButton)sender;
            RepeaterItem ritem = (RepeaterItem)imgbtnPlus.NamingContainer;

            ImageButton imgPlusthis = ritem.FindControl("imgPlus") as ImageButton;
            imgPlusthis.Attributes.Add("style", "display:inline");

            ImageButton imgMinusthis = ritem.FindControl("imgMinus") as ImageButton;
            imgMinusthis.Attributes.Add("style", "display:none");
        }

        //protected void repStyleCodeVirsion_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    DataSet dsNewStyle = new DataSet();
        //    DataTable dt0 = new DataTable();
        //    DataTable dt1 = new DataTable();
        //    DataTable dt2 = new DataTable();
        //    DataTable dt3 = new DataTable();
        //    DataTable dt4 = new DataTable();
        //    DataTable dt5 = new DataTable();
        //    DataTable dt6 = new DataTable();
        //    dt0 = null;
        //    dt1 = null;
        //    dt2 = null;
        //    dt3 = null;
        //    dt4 = null;
        //    dt5 = null;
        //    dt6 = null;
        //    ShowGridPopup.Visible = false;

        //    if (e.CommandName == "Show")
        //    {
        //        string StyleidNew = ((HiddenField)e.Item.FindControl("rephdnStyleid")).Value;
        //        string StyleCodeNew = ((HiddenField)e.Item.FindControl("rephdnStylCode")).Value;
        //        ((ImageButton)e.Item.FindControl("imgMinus")).Attributes.Add("style", "display:inline");
        //        ((ImageButton)e.Item.FindControl("imgPlus")).Attributes.Add("style", "display:none");
        //        //ShowGridPopup.Attributes.Add("style", "display:inline");
        //        ShowGridPopup.Visible = true;

        //        if (StyleidNew != null)
        //        {

        //            dsNewStyle = obj_ProcessController.GetRiskAllRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));

        //            dt0 = dsNewStyle.Tables[0];
        //            dt1 = dsNewStyle.Tables[1];
        //            dt2 = dsNewStyle.Tables[2];
        //            dt3 = dsNewStyle.Tables[3];
        //            dt4 = dsNewStyle.Tables[4];
        //            dt5 = dsNewStyle.Tables[5];
        //            dt6 = dsNewStyle.Tables[6];
        //            if (dt0 != null)
        //            {
        //                GridRiskFabricRemark.DataSource = dt0;
        //                GridRiskFabricRemark.DataBind();
        //                lblFabric.Text = "Fabric";

        //            }
        //            if (dt1 != null)
        //            {
        //                GridRiskAccessory.DataSource = dt1;
        //                GridRiskAccessory.DataBind();
        //                lblAccessory.Text = "Accessories";

        //            }
        //            if (dt2 != null)
        //            {
        //                GridRiskFittingRemark.DataSource = dt2;
        //                GridRiskFittingRemark.DataBind();
        //                lblFiting.Text = "Fitting";

        //            }
        //            if (dt3 != null)
        //            {
        //                GridRiskMakingRemark.DataSource = dt3;
        //                GridRiskMakingRemark.DataBind();
        //                lblMaking.Text = "Making";

        //            }
        //            if (dt4 != null)
        //            {
        //                GridImbroidery.DataSource = dt4;
        //                GridImbroidery.DataBind();
        //                lblImbroidery.Text = "Embroidery";

        //            }

        //            if (dt5 != null)
        //            {
        //                GridRiskWashing.DataSource = dt5;
        //                GridRiskWashing.DataBind();
        //                lblRiskWashing.Text = "Washing";

        //            }

        //            if (dt6 != null)
        //            {
        //                GridRiskFinishing.DataSource = dt6;
        //                GridRiskFinishing.DataBind();
        //                lblRiskFinishing.Text = "Finishing";

        //            }


        //        }
        //    }
        //    if (e.CommandName == "Hide")
        //    {
        //        ((ImageButton)e.Item.FindControl("imgPlus")).Attributes.Add("style", "display:inline");
        //        ((ImageButton)e.Item.FindControl("imgMinus")).Attributes.Add("style", "display:none");
        //        //ShowGridPopup.Attributes.Add("style", "display:none");
        //        ShowGridPopup.Visible = false;
        //    }
        //}

        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion

        protected void GrdValueAddtion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int status = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblster = (Label)e.Row.FindControl("lblster");
                HiddenField hdnisvaReq = (HiddenField)e.Row.FindControl("hdnisvaReq");
                HiddenField FromStid = (HiddenField)e.Row.FindControl("FromStid");
                HiddenField hdnisuse = (HiddenField)e.Row.FindControl("hdnisuse");
                CheckBox chkChekedSt = (CheckBox)e.Row.FindControl("ISUSEVA");
                CheckBox ISUSE = (CheckBox)e.Row.FindControl("ISUSE");
                HiddenField isCheckEntryIsDone = (HiddenField)e.Row.FindControl("hdnCheckEntryIsDone");
                HiddenField HdnIsVaExist = (HiddenField)e.Row.FindControl("HdnIsVaExist");

                if ((ViewState["currentStatus"] != null) && (ViewState["currentStatus"].ToString() != ""))
                {
                    status = Convert.ToInt32(ViewState["currentStatus"].ToString());
                }
                if (lblster.Text != "")
                {
                    chkChekedSt.Visible = true;
                    ViewState["isue"] = "False";
                }

                if (hdnisvaReq.Value == "True")
                {
                    ViewState["isue"] = "True";
                    chkChekedSt.Checked = true;
                    //ISUSE.Enabled = true;
                    //added by uday 2-1-2016
                    //if ((status == 9) || (status == 10) || (status == 11) || (status == 12))
                    if ((status == (int)(TaskMode.LIVE)) || (status == (int)(TaskMode.Sealed_To_Cut)) || (status == (int)(TaskMode.ALLOCATED)) || (status == (int)(TaskMode.INLINE_CUT)))
                    {
                        chkChekedSt.Enabled = false;
                        //chkvalueAddtion.Enabled = false;
                    }



                }


                else
                {
                    //if (ViewState["isue"] != null)
                    //{
                    //  if (ViewState["isue"].ToString() == "True")
                    //  {
                    //    ISUSE.Enabled = true;
                    //  }
                    //}

                    chkChekedSt.Checked = false;

                }
                if (hdnisuse.Value == "True")
                {
                    ISUSE.Checked = true;
                    //added by uday 2-1-2016
                    //if ((status == 9) || (status == 10) || (status == 11) || (status == 12))
                    //if ((status == (int)(TaskMode.LIVE)) || (status == (int)(TaskMode.Sealed_To_Cut)) || (status == (int)(TaskMode.ALLOCATED)) || (status == (int)(TaskMode.INLINE_CUT)))
                    //{
                    //    ISUSE.Enabled = false;
                    //   // chkvalueAddtion.Enabled = false;
                    //}

                }
                //added by uday 2-1-2016
                if (status > (int)(TaskMode.INLINE_CUT))
                {
                    //ISUSE.Enabled = false;
                    ISUSE.ForeColor = System.Drawing.Color.Gray;
                    chkChekedSt.Enabled = false;
                    chkChekedSt.ForeColor = System.Drawing.Color.Gray;
                    // chkvalueAddtion.Enabled = false;
                }

                //----------Updated On 19-sep-18---------
                if (chkvalueAddtion.Checked == true)
                {
                    chkChekedSt.Enabled = true;
                    if (chkChekedSt.Checked)
                    {
                        ISUSE.Enabled = true;
                    }
                }
                if (ViewState["Inline_Cut"] != null)
                {
                    if (ViewState["Inline_Cut"].ToString() == "29")
                    {
                        if (FromStid.Value.ToString() == "29")
                        {
                            ISUSE.Enabled = true;
                        }
                    }
                }
                if (ViewState["Cut_Stit"] != null)
                {
                    if (ViewState["Cut_Stit"].ToString() == "37")
                    {
                        if (FromStid.Value.ToString() == "37")
                        {
                            ISUSE.Enabled = true;
                        }
                    }
                }
                if (ViewState["Stit_Fin"] != null)
                {
                    if (ViewState["Stit_Fin"].ToString() == "39")
                    {
                        if (FromStid.Value.ToString() == "39")
                        {
                            ISUSE.Enabled = true;
                        }
                    }
                }

                if (HdnIsVaExist.Value == "True")
                {
                    ISUSE.Enabled = false;
                }
                //---------End Of COde--------------


                //if (ViewState["stname"] != null)
                //{ 
                //    string str=ViewState["stname"].ToString();
                //    if (str == FromStid.Value)
                //    {
                //        if (ViewState["ischeck"] != null)
                //        {
                //            if (ViewState["ischeck"].ToString() == "True")
                //            {
                //                chkChekedSt.Checked = true;
                //                ISUSE.Enabled = true;
                //            }
                //            else
                //            {
                //                chkChekedSt.Checked = false;
                //                ISUSE.Enabled = false;
                //            }
                //        }

                //    }

                //}


                //if (ViewState["inlineCutting"] != null)
                //{
                //    string str = ViewState["inlineCutting"].ToString();
                //    if (str == FromStid.Value)
                //    {
                //        if (ViewState["ischeckinlineCut"] != null)
                //        {
                //            if (ViewState["ischeckinlineCut"].ToString() == "True")
                //            {
                //                chkChekedSt.Checked = true;
                //                ISUSE.Enabled = true;
                //            }
                //            else
                //            {
                //                chkChekedSt.Checked = false;
                //                ISUSE.Enabled = false;
                //                ISUSE.Checked = false;
                //                ISUSE.ForeColor = System.Drawing.Color.Gray;
                //            }
                //        }

                //    }

                //}


                //if (ViewState["Cutting"] != null)
                //{
                //    string str = ViewState["Cutting"].ToString();
                //    if (str == FromStid.Value)
                //    {
                //        if (ViewState["ischeckCut"] != null)
                //        {
                //            if (ViewState["ischeckCut"].ToString() == "True")
                //            {
                //                chkChekedSt.Checked = true;
                //                ISUSE.Enabled = true;
                //                if (ISUSE.Checked)
                //                {
                //                    ISUSE.Checked = true;
                //                }

                //            }
                //            else
                //            {
                //                chkChekedSt.Checked = false;
                //                ISUSE.Enabled = false;
                //                ISUSE.Checked = false;
                //                ISUSE.ForeColor = System.Drawing.Color.Gray;
                //            }
                //        }

                //    }

                //}



                //---------------Updated On 19-sep-18-----//

                //if (Convert.ToString(isCheckEntryIsDone.Value) == "0")
                //    ISUSE.Enabled = true;
                //else
                //    ISUSE.Enabled = false;

                //---------------End On 19-sep-18-----//







                //if (ViewState["Stiching"] != null)
                //{
                //    string str = ViewState["Stiching"].ToString();
                //    if (str == FromStid.Value)
                //    {
                //        if (ViewState["ischeckStch"] != null)
                //        {
                //            if (ViewState["ischeckStch"].ToString() == "True")
                //            {
                //                chkChekedSt.Checked = true;
                //                ISUSE.Enabled = true;
                //            }
                //            else
                //            {
                //                chkChekedSt.Checked = false;
                //                ISUSE.Enabled = false;
                //                ISUSE.Checked = false;
                //                ISUSE.ForeColor = System.Drawing.Color.Gray;
                //            }
                //        }

                //    }

                //}


            }
        }


        protected void ISUSEVA_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox tb1 = ((CheckBox)(sender));
            //Added by uday 1-2-2016
            int frm1 = (int)(TaskMode.INLINE_CUT), frm2 = (int)(TaskMode.Cutting), frm3 = (int)(TaskMode.Stitching);

            // int Attandence=0;
            GridViewRow rp1 = (GridViewRow)tb1.NamingContainer;
            int index = rp1.RowIndex;
            HiddenField FromStid = (HiddenField)rp1.FindControl("FromStid");
            HiddenField toid = (HiddenField)rp1.FindControl("toid");
            CheckBox ISUSEVA = (CheckBox)rp1.FindControl("ISUSEVA");
            CheckBox ISUSE = (CheckBox)rp1.FindControl("ISUSE");
            Label lblster = (Label)rp1.FindControl("lblster");
            HiddenField ValueAddtionid = (HiddenField)rp1.FindControl("hdnValid");
            // int rowIndex = 0;
            DataTable dtCurrentTable = (DataTable)ViewState["ValueAddtion"];

            if (FromStid.Value == frm1.ToString())
            {
                ViewState["inlineCutting"] = frm1;
            }

            if (FromStid.Value == frm2.ToString())
            {
                ViewState["Cutting"] = frm2;
            }
            if (FromStid.Value == frm3.ToString())
            {
                ViewState["Stiching"] = frm3;
            }

            ViewState["stname"] = FromStid.Value;



            if (ISUSEVA.Checked)
            {

                if (FromStid.Value == frm3.ToString())
                {
                    ViewState["ischeckStch"] = "True";
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        // for (int i = 1; i <= dt.Rows.Count; i++)
                        //  {
                        ViewState["Stit_Fin"] = "39";
                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm3.ToString())
                            {
                                // CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                                dtCurrentTable.Rows[j]["isVa"] = "False";
                                // CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                                dtCurrentTable.Rows[j]["isVaReq"] = "true";
                            }
                            else
                            {

                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }
                            }
                        }

                        // }


                    }
                    GrdValueAddtion.DataSource = dtCurrentTable;
                    GrdValueAddtion.DataBind();


                    // BindValueAddtion(0, 0, 0, -1, "");
                    //ViewState["ischeckCut"] = "False";
                    //ViewState["ischeckinlineCut"] = "False";


                }

                if (FromStid.Value == frm2.ToString())
                {
                    ViewState["ischeckCut"] = "True";

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        // for (int i = 1; i <= dt.Rows.Count; i++)
                        // {
                        ViewState["Cut_Stit"] = "37";
                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm2.ToString())
                            {


                                dtCurrentTable.Rows[j]["isVa"] = "False";

                                dtCurrentTable.Rows[j]["isVaReq"] = "true";
                            }
                            else
                            {

                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }
                            }
                        }
                        // }



                    }
                    GrdValueAddtion.DataSource = dtCurrentTable;
                    GrdValueAddtion.DataBind();
                    //  BindValueAddtion(0, 0, 0, -1, "");
                    //ViewState["ischeckStch"] = "False";
                    //ViewState["ischeckinlineCut"] = "False";
                }

                if (FromStid.Value == frm1.ToString())
                {
                    ViewState["ischeckinlineCut"] = "True";
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        //for (int i = 1; i <= dt.Rows.Count; i++)
                        //{
                        ViewState["Inline_Cut"] = "29";                        

                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm1.ToString())
                            {
                                dtCurrentTable.Rows[j]["isVa"] = "False";

                                dtCurrentTable.Rows[j]["isVaReq"] = "true";
                            }
                            else
                            {

                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }
                            }

                        }

                    }
                    GrdValueAddtion.DataSource = dtCurrentTable;
                    GrdValueAddtion.DataBind();

                }

                //ViewState["ischeck"] = "True";
                //BindValueAddtion(0, 0, 0, -1, "");
                hdnEnableFalse.Value = "1";
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "EnableDisableFields();", true);

            }
            else
            {
                if (FromStid.Value == frm3.ToString())
                {
                    ViewState["ischeckStch"] = "False";
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        //for (int i = 1; i <= dt.Rows.Count; i++)
                        //{
                        ViewState["Stit_Fin"] = null;
                        int x = index;
                        int unchksf = 0;
                        for (int Sf = 0; Sf < dt.Rows.Count; Sf++)
                        {
                            CheckBox ISUSEChk = (CheckBox)GrdValueAddtion.Rows[x].Cells[4].FindControl("ISUSE");
                            CheckBox ISUSEVAChk = (CheckBox)GrdValueAddtion.Rows[Sf].Cells[2].FindControl("ISUSEVA");
                            if (ISUSEChk.Checked == true)
                            {
                                unchksf = unchksf + 1;
                            }
                            x++;
                        }
                        if (unchksf > 0)
                        {
                            ShowAlert("Please Unselect Is Use First!");
                            ISUSEVA.Checked = true;
                            return;
                        }
                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm3.ToString())
                            {
                                dtCurrentTable.Rows[j]["isVa"] = "False";
                                dtCurrentTable.Rows[j]["isVaReq"] = "False";
                            }
                            else
                            {
                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }
                            }
                        }
                        // }
                        GrdValueAddtion.DataSource = dtCurrentTable;
                        GrdValueAddtion.DataBind();
                    }
                }
                if (FromStid.Value == frm2.ToString())
                {
                    ViewState["ischeckCut"] = "False";
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        //for (int i = 1; i <= dt.Rows.Count; i++)
                        //{
                        ViewState["Cut_Stit"] = null;
                        int x = index;
                        int unchkCs = 0;
                        for (int Cs = 0; Cs < dt.Rows.Count; Cs++)
                        {
                            CheckBox ISUSEChk = (CheckBox)GrdValueAddtion.Rows[x].Cells[4].FindControl("ISUSE");
                           
                            if (ISUSEChk.Checked == true)
                            {
                                unchkCs = unchkCs + 1;
                            }
                            x++;
                        }
                        if (unchkCs > 0)
                        {
                            ShowAlert("Please Unselect Is Use First!");
                            ISUSEVA.Checked = true;
                            return;
                        }
                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm2.ToString())
                            {


                                dtCurrentTable.Rows[j]["isVa"] = "False";

                                dtCurrentTable.Rows[j]["isVaReq"] = "False";
                            }
                            else
                            {

                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }

                            }
                        }


                        // }
                        GrdValueAddtion.DataSource = dtCurrentTable;
                        GrdValueAddtion.DataBind();
                    }
                }

                if (FromStid.Value == frm1.ToString())
                {
                    ViewState["ischeckinlineCut"] = "False";
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        string expression = "FromStid=" + FromStid.Value;
                        string sortOrder = "ValueAddtionName  ASC";
                        DataRow[] foundRows;
                        foundRows = dtCurrentTable.Select(expression, sortOrder);
                        DataTable dt = foundRows.CopyToDataTable();
                        //for (int i = 1; i <= dt.Rows.Count; i++)
                        //{
                        ViewState["Inline_Cut"] = null;
                        int x = index;
                        int unchkIc = 0;
                        for (int Ic = 0; Ic < dt.Rows.Count; Ic++)
                        {
                            CheckBox ISUSEChk = (CheckBox)GrdValueAddtion.Rows[x].Cells[4].FindControl("ISUSE");
                            CheckBox ISUSEVACkhk = (CheckBox)GrdValueAddtion.Rows[Ic].Cells[2].FindControl("ISUSEVA");
                            if (ISUSEChk.Checked == true)
                            {
                                unchkIc = unchkIc + 1;
                            }
                            x++;
                        }

                        if (unchkIc > 0)
                        {
                            ShowAlert("Please Unselect Is Use First!");
                            ISUSEVA.Checked = true;
                            return;
                        }
                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {

                            CheckBox ISUSEVA1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSEVA");
                            CheckBox ISUSE1 = (CheckBox)GrdValueAddtion.Rows[j].Cells[1].FindControl("ISUSE");
                            if (dtCurrentTable.Rows[j]["FromStid"].ToString() == frm1.ToString())
                            {
                                dtCurrentTable.Rows[j]["isVa"] = "False";

                                dtCurrentTable.Rows[j]["isVaReq"] = "False";

                            }
                            else
                            {

                                if (ISUSE1.Checked)
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "True";
                                }
                                else
                                {
                                    dtCurrentTable.Rows[j]["isVa"] = "false";
                                }
                            }
                        }
                    }


                    // }
                    GrdValueAddtion.DataSource = dtCurrentTable;
                    GrdValueAddtion.DataBind();
                }







            }
            ValidateSubmit();

        }











        protected void GrdValueAddtion_DataBound(object sender, EventArgs e)
        {
            //for (int i = GrdValueAddtion.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = GrdValueAddtion.Rows[i];
            //    GridViewRow previousRow = GrdValueAddtion.Rows[i - 1];

            //    for (int j = 0; j < row.Cells.Count - 1; j++)
            //    {
            //        Label lblStaffDept = (Label)row.Cells[j].FindControl("lblFromst");
            //        Label lblPreviousStaffDept = (Label)previousRow.Cells[j].FindControl("lblFromst");

            //        if (lblStaffDept.Text == lblPreviousStaffDept.Text)
            //        {
            //            if (previousRow.Cells[j].RowSpan == 0)
            //            {
            //                if (row.Cells[j].RowSpan == 0)
            //                {
            //                    previousRow.Cells[j].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
            //                }
            //                row.Cells[j].Visible = false;
            //            }
            //        }
            //    }
            //}


            for (int i = GrdValueAddtion.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GrdValueAddtion.Rows[i];
                GridViewRow previousRow = GrdValueAddtion.Rows[i - 1];

                HiddenField hdnfromstid = (HiddenField)row.Cells[2].FindControl("fromstid");
                HiddenField hdnPreviousfromstid = (HiddenField)previousRow.Cells[2].FindControl("fromstid");

                if (hdnfromstid.Value == hdnPreviousfromstid.Value)
                {
                    if (previousRow.Cells[2].RowSpan == 0 && previousRow.Cells[1].RowSpan == 0 && previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[2].RowSpan == 0 && row.Cells[1].RowSpan == 0 && row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[2].RowSpan += 2;
                            previousRow.Cells[1].RowSpan += 2;
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
                            previousRow.Cells[1].RowSpan = row.Cells[2].RowSpan + 1;
                            previousRow.Cells[0].RowSpan = row.Cells[2].RowSpan + 1;
                        }
                        row.Cells[2].Visible = false;
                        row.Cells[1].Visible = false;
                        row.Cells[0].Visible = false;
                    }
                }

            }

        }

        protected void chkvalueAddtion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvalueAddtion.Checked)
            {
                GrdValueAddtion.Enabled = true;
                foreach (GridViewRow row in GrdValueAddtion.Rows)
                {
                    CheckBox ISUSEVA = (CheckBox)row.FindControl("ISUSEVA");
                    ISUSEVA.Enabled = true;
                }
            }
            else
            {
                int ISUSEVAChk = 0;
                foreach (GridViewRow row in GrdValueAddtion.Rows)
                {
                    CheckBox ISUSEVA = (CheckBox)row.FindControl("ISUSEVA");
                   // ISUSEVA.Checked = false;
                    if (ISUSEVA.Checked == true)
                    {
                        ISUSEVAChk = ISUSEVAChk + 1;
                    }
                }
                if (ISUSEVAChk > 0)
                {
                    ShowAlert("Please Unselect Is Va Required First!");
                    chkvalueAddtion.Checked = true;
                   
                }
                else
                {
                    GrdValueAddtion.Enabled = true;
                    foreach (GridViewRow row in GrdValueAddtion.Rows)
                    {
                        CheckBox ISUSEVA = (CheckBox)row.FindControl("ISUSEVA");
                        CheckBox ISUSE = (CheckBox)row.FindControl("ISUSE");
                        ISUSEVA.Enabled = false;
                        ISUSE.Enabled = false;
                    }
                }
            }
            ValidateSubmit();
        }

        protected void GrdValueAddtion_PreRender1(object sender, EventArgs e)
        {

            //  GridDecorator.MergeRows(GrdValueAddtion);
        }

        public void ValidateSubmit()
        {
            foreach (GridViewRow row in GrdValueAddtion.Rows)
            {
                CheckBox ISUSE = (CheckBox)row.FindControl("ISUSE");

                //if (ISUSE.Enabled == true)
                //{
                if (chkvalueAddtion.Checked == false)
                {
                    btnSubmit.Enabled = true;
                    lblmgs.Visible = false;
                    btnSubmit.CssClass = "submit";
                    break;
                }
                else if (chkvalueAddtion.Checked == true && ISUSE.Checked == true)
                {
                    btnSubmit.Enabled = true;
                    lblmgs.Visible = false;
                    btnSubmit.CssClass = "submit";
                    break;
                }

                else
                {
                    lblmgs.Visible = false;
                    lblmgs.Text = "You must select at least one value addition name";
                    lblmgs.ForeColor = Color.Red;
                    btnSubmit.Enabled = false;
                    btnSubmit.CssClass = "submit-disable";
                    //btnSubmit.Attributes["disabled"] = "disabled";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "  <script>DisableSubmit();</script>");
                }
                //}
            }

        }
        protected void ISUSE_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            int index = row.RowIndex;
            CheckBox cb1 = (CheckBox)GrdValueAddtion.Rows[index].FindControl("chkview");
            ValidateSubmit();
            //here you can find your control and get value(Id).
        }

    }
}