using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using iKandi.BLL.CmtAdmin;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class AttandanceOT_Popup : System.Web.UI.Page
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int WorkforceId
        {
            get;
            set;
        }
        public int FactoryWorkSpaceId
        {
            get;
            set;
        }
        public int OTType
        {
            get;
            set;
        }
        public int NormalCount
        {
            get;
            set;
        }
        public double OThours
        {
            get;
            set;
        }
        public string AttandenceDate
        {
            get;
            set;
        }

        CmtAdminController obj_CmtAdmin = new CmtAdminController();
        AdminController obj_AdminController = new AdminController();
        private double OTAdminHrs;
        private string OTName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetQueryString();
                GetDefaultHours();
                GetDesignationByFactory();
                
                lblOTtype.Text = OTName;
                txtOTDefault.Text = OTAdminHrs.ToString();
                txtTotalCount.Text = NormalCount.ToString();

                GetAttandanceOT();
            }
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["ProductionUnit"])
            {
                ProductionUnit = Convert.ToInt32(Request.QueryString["ProductionUnit"].ToString());
                hdnProductionUnit.Value = ProductionUnit.ToString();
            }
            if (null != Request.QueryString["WorkforceId"])
            {
                WorkforceId = Convert.ToInt32(Request.QueryString["WorkforceId"].ToString());
                hdnWorkforceId.Value = WorkforceId.ToString();
            }
            if (null != Request.QueryString["OTType"])
            {
                OTType = Convert.ToInt32(Request.QueryString["OTType"].ToString());
                hdnOTType.Value = OTType.ToString();
            }
            if (null != Request.QueryString["NormalCount"])
            {
                NormalCount = Convert.ToInt32(Request.QueryString["NormalCount"].ToString());
            }
            if (null != Request.QueryString["AttandenceDate"])
            {
                AttandenceDate = Request.QueryString["AttandenceDate"].ToString();
                hdnAttandenceDate.Value = AttandenceDate;
            }            
        }

        private void GetDesignationByFactory()
        {
            string FactoryDesignation = obj_AdminController.GetFactoryWorkerSpace(WorkforceId);
            lblDesignation.Text = FactoryDesignation;
        }

        private void GetDefaultHours()
        {

            DataTable dtAdminHours = obj_CmtAdmin.GetCmt();
            if (OTType == 2)
            {
                OTName = "OT1";
                OTAdminHrs = dtAdminHours.Rows[0]["OT1"] == DBNull.Value ? 0 : Convert.ToDouble(dtAdminHours.Rows[0]["OT1"]);
            }
            if (OTType == 3)
            {
                OTName = "OT2";
                OTAdminHrs = dtAdminHours.Rows[0]["OT2"] == DBNull.Value ? 0 : Convert.ToDouble(dtAdminHours.Rows[0]["OT2"]);
            }
            if (OTType == 4)
            {
                OTName = "OT3";
                OTAdminHrs = dtAdminHours.Rows[0]["OT3"] == DBNull.Value ? 0 : Convert.ToDouble(dtAdminHours.Rows[0]["OT3"]);
            }
            if (OTType == 5)
            {
                OTName = "OT4";
                OTAdminHrs = dtAdminHours.Rows[0]["OT4"] == DBNull.Value ? 0 : Convert.ToDouble(dtAdminHours.Rows[0]["OT4"]);
            }
        }
        private void GetAttandanceOT()
        {
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            FactoryWorkSpaceId = Convert.ToInt32(hdnWorkforceId.Value);           
            AttandenceDate = hdnAttandenceDate.Value;
            OTType = Convert.ToInt32(hdnOTType.Value);
            DataTable dtAttandanceOT = obj_AdminController.GetAttandanceOT_Split(ProductionUnit, FactoryWorkSpaceId, AttandenceDate, OTType);
            gvAttandanceOT.DataSource = dtAttandanceOT;
            gvAttandanceOT.DataBind();
        }

        protected void gvAttandanceOT_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ManCount = 0;
            double Hours = 0;
            if (e.CommandName == "Add_Empty")
            {
                TextBox txtEmptyManCount = (TextBox)gvAttandanceOT.Controls[0].Controls[0].FindControl("txtEmptyManCount");
                if (txtEmptyManCount.Text != "")
                {
                    ManCount = Convert.ToInt32(txtEmptyManCount.Text);
                }
                TextBox txtEmptyHours = (TextBox)gvAttandanceOT.Controls[0].Controls[0].FindControl("txtEmptyHours");
                {
                    Hours = Convert.ToDouble(txtEmptyHours.Text);
                }
                ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
                FactoryWorkSpaceId = Convert.ToInt32(hdnWorkforceId.Value);
                if (txtTotalCount.Text != "")
                {
                    NormalCount = Convert.ToInt32(txtTotalCount.Text);
                }
                AttandenceDate = hdnAttandenceDate.Value;
                OTType = Convert.ToInt32(hdnOTType.Value);


                int isave = obj_AdminController.InsertAttandanceOT_Split(-1, ProductionUnit, FactoryWorkSpaceId, NormalCount, AttandenceDate, OTType, ManCount, Hours, ApplicationHelper.LoggedInUser.UserData.UserID);
                GetAttandanceOT();
            }

            if (e.CommandName == "Add")
            {
                TextBox txtFooterManCount = (TextBox)gvAttandanceOT.FooterRow.FindControl("txtFooterManCount");
                if (txtFooterManCount.Text != "")
                {
                    ManCount = Convert.ToInt32(txtFooterManCount.Text);
                }
                TextBox txtFooterHours = (TextBox)gvAttandanceOT.FooterRow.FindControl("txtFooterHours");
                {
                    Hours = Convert.ToDouble(txtFooterHours.Text);
                }
                ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
                FactoryWorkSpaceId = Convert.ToInt32(hdnWorkforceId.Value);
                if (txtTotalCount.Text != "")
                {
                    NormalCount = Convert.ToInt32(txtTotalCount.Text);
                }
                AttandenceDate = hdnAttandenceDate.Value;
                OTType = Convert.ToInt32(hdnOTType.Value);


                int isave = obj_AdminController.InsertAttandanceOT_Split(-1, ProductionUnit, FactoryWorkSpaceId, NormalCount, AttandenceDate, OTType, ManCount, Hours, ApplicationHelper.LoggedInUser.UserData.UserID);
                GetAttandanceOT();
            }

            if (e.CommandName == "Remove")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                HiddenField hdnAttandanceOTId = (HiddenField)row.FindControl("hdnAttandanceOTId");
                int AttandanceId = -1;
                if (hdnAttandanceOTId != null)
                {
                    AttandanceId = Convert.ToInt32(hdnAttandanceOTId.Value);
                }
                int isave = obj_AdminController.DeleteAttandanceOT_Split(AttandanceId);
                GetAttandanceOT();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ManCount = 0;
            double Hours = 0;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            FactoryWorkSpaceId = Convert.ToInt32(hdnWorkforceId.Value);
            AttandenceDate = hdnAttandenceDate.Value;
            OTType = Convert.ToInt32(hdnOTType.Value);
            int iDeleteAll = obj_AdminController.DeleteAll_AttandanceOT_Split(ProductionUnit, FactoryWorkSpaceId, AttandenceDate, OTType);


            Control control = null;
            control = gvAttandanceOT.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtEmptyManCount") != null)
            {
                TextBox txtEmptyManCount = (TextBox)control.FindControl("txtEmptyManCount");
                TextBox txtEmptyHours = (TextBox)control.FindControl("txtEmptyHours");

                if ((txtEmptyManCount.Text != "") && (txtEmptyHours.Text != ""))
                {
                    if (txtEmptyManCount.Text != "")
                    {
                        ManCount = Convert.ToInt32(txtEmptyManCount.Text);
                    }

                    if (txtEmptyHours.Text != "")
                    {
                        Hours = Convert.ToDouble(txtEmptyHours.Text);
                    }
                    
                    if (txtTotalCount.Text != "")
                    {
                        NormalCount = Convert.ToInt32(txtTotalCount.Text);
                    }   

                    int isave = obj_AdminController.InsertAttandanceOT_Split(-1, ProductionUnit, FactoryWorkSpaceId, NormalCount, AttandenceDate, OTType, ManCount, Hours, ApplicationHelper.LoggedInUser.UserData.UserID);
                    GetAttandanceOT();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClosethisWindow();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Details');", true);
                    return;
                }
            }

            else
            {
                int AttandanceId = -1;
                for (int i = 0; i < gvAttandanceOT.Rows.Count; i++)
                {
                    TextBox txtManCount = (TextBox)gvAttandanceOT.Rows[i].FindControl("txtManCount");
                    TextBox txtHours = (TextBox)gvAttandanceOT.Rows[i].FindControl("txtHours");
                    HiddenField hdnAttandanceOTId = (HiddenField)gvAttandanceOT.Rows[i].FindControl("hdnAttandanceOTId");
                    if ((txtManCount.Text != "") && (txtHours.Text != ""))
                    {
                        if (txtManCount.Text != "")
                        {
                            ManCount = Convert.ToInt32(txtManCount.Text);
                        }
                        if (txtHours.Text != "")
                        {
                            Hours = Convert.ToDouble(txtHours.Text);
                        }
                        if (hdnAttandanceOTId != null)
                        {
                            AttandanceId = Convert.ToInt32(hdnAttandanceOTId.Value);
                        }                      
                        if (txtTotalCount.Text != "")
                        {
                            NormalCount = Convert.ToInt32(txtTotalCount.Text);
                        }                        
                        
                        int isave = obj_AdminController.InsertAttandanceOT_Split(AttandanceId, ProductionUnit, FactoryWorkSpaceId, NormalCount, AttandenceDate, OTType, ManCount, Hours, ApplicationHelper.LoggedInUser.UserData.UserID);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Details');", true);
                        return;
                    }

                }

                var footerRow = gvAttandanceOT.FooterRow;
                if (footerRow != null)
                {
                    int invalid = 0;
                    TextBox txtFooterManCount = (TextBox)gvAttandanceOT.FooterRow.FindControl("txtFooterManCount");
                    TextBox txtFooterHours = (TextBox)gvAttandanceOT.FooterRow.FindControl("txtFooterHours");
                    if ((txtFooterManCount.Text != "") && (txtFooterHours.Text != ""))
                    {
                        if (txtFooterManCount.Text != "")
                        {
                            ManCount = Convert.ToInt32(txtFooterManCount.Text);
                        }
                        if (txtFooterHours.Text != "")
                        {
                            Hours = Convert.ToDouble(txtFooterHours.Text);
                        }                        
                        if (txtTotalCount.Text != "")
                        {
                            NormalCount = Convert.ToInt32(txtTotalCount.Text);
                        }                     

                        int isave = obj_AdminController.InsertAttandanceOT_Split(-1, ProductionUnit, FactoryWorkSpaceId, NormalCount, AttandenceDate, OTType, ManCount, Hours, ApplicationHelper.LoggedInUser.UserData.UserID);
                    }
                    
                    if ((txtFooterManCount.Text != "") && (txtFooterHours.Text == ""))
                    {
                        invalid = 1;
                    }
                    if ((txtFooterManCount.Text == "") && (txtFooterHours.Text != ""))
                    {
                        invalid = 1;
                    }
                    if(invalid == 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Details');", true);
                        return;
                    }
                }

                GetAttandanceOT();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClosethisWindow();", true);
            }

        }
    }
}