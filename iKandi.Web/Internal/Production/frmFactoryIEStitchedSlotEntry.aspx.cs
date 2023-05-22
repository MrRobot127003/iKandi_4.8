using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Production
{
    public partial class frmFactoryIEStitchedSlotEntry : System.Web.UI.Page
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }
        public int PassValue = 0;
        public int AltValue = 0;
        public int OBValue = 0;
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                GetQueryString();
                GetFactoryName();
                GetAllStitchedSlot();               
                GetSlot_LinePlanning();
                //GetDeprtmentLoss();
            }            
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["ProductionUnit"])
            {
                ProductionUnit = Convert.ToInt32(Request.QueryString["ProductionUnit"].ToString());
                hdnProductionUnit.Value = ProductionUnit.ToString();                
            }
            if (null != Request.QueryString["SlotId"])
            {
                SlotId = Convert.ToInt32(Request.QueryString["SlotId"].ToString());
                hdnSlotId.Value = SlotId.ToString();
            }
            if (null != Request.QueryString["LineNo"])
            {
                LineNo = Convert.ToInt32(Request.QueryString["LineNo"].ToString());
            }
            if (null != Request.QueryString["StartDate"])
            {
                StartDate = Request.QueryString["StartDate"].ToString();
                hdnStartDate.Value = StartDate;
            }
        }

        private void GetFactoryName()
        {
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            string FactoryName = objProductionController.GetFactoryName(ProductionUnit);
            lblFactory.Text = "Factory " + FactoryName.ToString();
        }

        private void GetAllStitchedSlot()
        {
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            StartDate = hdnStartDate.Value;
            DataSet dsSlot = objProductionController.GetAllStitchingFactoryIESlot(ProductionUnit, StartDate);
            if (dsSlot.Tables[0].Rows.Count > 0)
            {
                ddlSlot.DataSource = dsSlot.Tables[0];
                ddlSlot.DataTextField = "Date_Slot";
                ddlSlot.DataValueField = "SlotID";
                ddlSlot.DataBind();
                ddlSlot.Items.Insert(0, new ListItem("Select", "-1"));
                ddlSlot.SelectedValue = dsSlot.Tables[0].Rows[0]["SlotID"].ToString();
            }
        }

        protected void ddlSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSlot.SelectedIndex != 0)
            {
                if (ddlSlot.SelectedValue != hdnSlotId.Value)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('firsts off all must work on earlier slot');", true);

                    Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('firsts off all, must work on earlier slot');", true);
                    ddlSlot.SelectedValue = hdnSlotId.Value;
                    return;
                }
                else
                {
                    GetSlot_LinePlanning();
                }
            }
        }

        private void GetSlot_LinePlanning()
        {
            if (ddlSlot.SelectedIndex != 0)
            {
                hdnSlotId.Value = ddlSlot.SelectedValue;
            }
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            StartDate = hdnStartDate.Value;
            LineNo = 0;
            if (ddlSlot.SelectedValue != "-1")
            {
                DataSet dsSlot;
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                dsSlot = objProductionController.GetSlot_LinePlanning(StartDate, LineNo, SlotId, ProductionUnit, "Stitching_FactoryIE", UserId);

                DataTable dtSlot = dsSlot.Tables[0];
                DataTable dtDepartment = dsSlot.Tables[1];
                DataTable dtDepartmentValue = dsSlot.Tables[2];

                if (dtDepartment.Rows.Count < 1)
                {
                    dtDepartment = objProductionController.GetDepartmentLoss("Stitching");
                }
                ViewState["dtDepartment"] = dtDepartment;


                if (dtDepartment.Rows.Count > 0)
                {
                    int ival = 1;
                    for (int i = 0; i < dtDepartment.Rows.Count; i++)
                    {
                        dtSlot.Columns.Add(new DataColumn("Dept" + ival, typeof(string)));
                        dtSlot.Columns.Add(new DataColumn("hdnDept" + ival, typeof(string)));
                        dtSlot.AcceptChanges();
                        ival = ival + 1;
                    }
                }
                if (dtDepartmentValue.Rows.Count > 0)
                {
                    int rowcount = dtSlot.Rows.Count;

                    int ival = 1;
                    for (int j = 0; j < dtDepartment.Rows.Count; j++)
                    {
                        string sDept = dtDepartment.Rows[j]["DepartmentName"].ToString();
                        int iCount = 0;
                        for (int i = 0; i < dtDepartmentValue.Rows.Count; i++)
                        {
                            string DeptName = dtDepartmentValue.Rows[i]["DepartmentName"].ToString();
                            if (iCount < rowcount)
                            {
                                if (sDept == DeptName)
                                {
                                    dtSlot.Rows[iCount]["Dept" + ival] = dtDepartmentValue.Rows[i]["LossDepartmentValue"].ToString() == "0" ? "" : dtDepartmentValue.Rows[i]["LossDepartmentValue"].ToString();
                                    dtSlot.Rows[iCount]["hdnDept" + ival] = dtDepartmentValue.Rows[i]["LossDepartmentID"];
                                    iCount = iCount + 1;
                                }
                            }
                        }

                        ival = ival + 1;
                    }
                }

                ViewState["dtSlot"] = dtSlot;
                ViewState["dtDepartment"] = dtDepartment;
                GetDeprtmentLoss();
            }
            else
            {
                btnSubmit.Visible = false;
            }

        }

        private void GetDeprtmentLoss()
        {
            DataTable dtDept;
            dtDept = (DataTable)ViewState["dtDepartment"];
            
            hdnDeptCount.Value = dtDept.Rows.Count.ToString();
            int Width = 60;
            if (dtDept.Rows.Count > 0)
            {
                string tablestring = "";
                Width = Width * dtDept.Rows.Count;

                tablestring = tablestring + "<table width='100%' cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse; table-layout:fixed;'>";
                tablestring = tablestring + "<thead><tr><th align='center' colspan='" + dtDept.Rows.Count + "' width='" + Width + "px' >Loss % share Dept wise</th></tr><tr>";
                int ival = 1;
                for (int i = 0; i < dtDept.Rows.Count; i++)
                {
                    tablestring = tablestring + "<th style='width:90px; height:45px;'  align='center'>" + dtDept.Rows[i]["DepartmentName"] + " (%)" + " <input type='hidden' class='hdnDepartmentIdcls" + ival + "' name='hdnDeartmentId" + ival + "' value='" + dtDept.Rows[i]["LossDepartmentID"] + "' /></th>";                    
                    TemplateField tfDept = new TemplateField();
                    tfDept.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Dept" + ival, "Dept" + ival);
                    tfDept.ItemStyle.CssClass = "Deptstyle";
                    tfDept.ItemStyle.HorizontalAlign = HorizontalAlign.Center;                    
                    gvFactoryIE_StitchedSlot.Columns.Add(tfDept);

                    TemplateField tfDeptHidden = new TemplateField();                    
                    tfDeptHidden.ItemTemplate = new iKandi.Common.GridViewTemplate("hidden", "hdnDept" + ival, "hdnDept" + ival);                    
                    tfDeptHidden.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfDeptHidden.ItemStyle.CssClass = "hiddenfield";
                    gvFactoryIE_StitchedSlot.Columns.Add(tfDeptHidden);
                    tfDept.FooterStyle.CssClass = "hiddenfield";

                    ival = ival + 1;
                }
                tablestring = tablestring + "</tr></thead></table>";
                dvDept.InnerHtml = tablestring;

                DataTable dtSlotNew = (DataTable)ViewState["dtSlot"];
                gvFactoryIE_StitchedSlot.DataSource = dtSlotNew;
                gvFactoryIE_StitchedSlot.DataBind();
            }
            else
            {
                DataTable dtSlotNew = (DataTable)ViewState["dtSlot"];
                gvFactoryIE_StitchedSlot.DataSource = dtSlotNew;
                gvFactoryIE_StitchedSlot.DataBind();
            }
        }
               

        protected void gvFactoryIE_StitchedSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtDept = (DataTable)ViewState["dtDepartment"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {         
                
                if (dtDept.Rows.Count > 0)
                {
                    int ival = 1;
                    for (int i = 0; i < dtDept.Rows.Count; i++)
                    {
                        TextBox txtDept = e.Row.FindControl("Dept" + ival) as TextBox;
                        txtDept.Text = (e.Row.DataItem as DataRowView).Row["Dept" + ival].ToString();
                        txtDept.Width = 30;
                        txtDept.MaxLength = 2;
                        txtDept.Attributes.Add("onkeypress", "return isNumberKey(event)");
                        txtDept.Attributes.Add("onchange", "return ValidateDeptValue(this)");

                        HtmlInputHidden hdnDept = e.Row.FindControl("hdnDept" + ival) as HtmlInputHidden;
                        hdnDept.Value = (e.Row.DataItem as DataRowView).Row["hdnDept" + ival].ToString();
                        ival = ival + 1;
                    }
                }
                TextBox txtSlotPass = (TextBox)e.Row.FindControl("txtSlotPass");
                if (txtSlotPass.Text != "")
                {
                    PassValue = PassValue + Convert.ToInt32(txtSlotPass.Text);
                }
                TextBox txtSlotAlt = (TextBox)e.Row.FindControl("txtSlotAlt");
                if (txtSlotAlt.Text != "")
                {
                    AltValue = AltValue + Convert.ToInt32(txtSlotAlt.Text);
                }
                TextBox txlActualOB = (TextBox)e.Row.FindControl("txlActualOB");
                if (txlActualOB.Text != "")
                {
                    OBValue = OBValue + Convert.ToInt32(txlActualOB.Text);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSlotPassFooter = (Label)e.Row.FindControl("lblSlotPassFooter");
                lblSlotPassFooter.Text = PassValue.ToString() == "0" ? "" : PassValue.ToString();

                Label lblSlotAltFooter = (Label)e.Row.FindControl("lblSlotAltFooter");
                lblSlotAltFooter.Text = AltValue.ToString() == "0" ? "" : AltValue.ToString();

                Label lblActualOBFooter = (Label)e.Row.FindControl("lblActualOBFooter");
                lblActualOBFooter.Text = OBValue.ToString() == "0" ? "" : OBValue.ToString();

                //if (dtDept.Rows.Count > 0)
                //{
                //    int ival = 1;
                //    for (int i = 0; i < dtDept.Rows.Count; i++)
                //    {

                //        HtmlInputHidden hdnDept = e.Row.FindControl(dtDept.Rows[i]["LossDepartmentID"].ToString()) as HtmlInputHidden;
                //        hdnDept.Value = (e.Row.DataItem as DataRowView).Row[dtDept.Rows[i]["LossDepartmentID"].ToString()].ToString();
                //        ival = ival + 1;
                //    }
                //}
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString(), false);
        }

            
        
    }
}