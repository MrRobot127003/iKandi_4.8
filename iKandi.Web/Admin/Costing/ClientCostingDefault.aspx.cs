using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class ClientCostingDefault : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataSet DsOHCheckValue = new DataSet();
        DataSet checkOhNull = new DataSet();
        AdminController adminControlInstance = new AdminController();
        Costing objCosting = new Costing();
        CostingController objCostingControler = new CostingController();
        public static int DdlselectedValue=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["search"])
            {
                DdlselectedValue = Convert.ToInt32(Request.QueryString["search"].ToString());
                BindControls(DdlselectedValue);
            }
            if (!IsPostBack)
            {
                //DdlselectedValue = 0;             
                BindControls(DdlselectedValue);
               // DataTable dtNew = adminControlInstance.GetOhPercentValue(DdlselectedValue);
                DsOHCheckValue = adminControlInstance.GetOhPercentValue(DdlselectedValue);
                hdnOhValue.Value = DsOHCheckValue.Tables[0].Rows[0][0].ToString();
                checkOhNull = adminControlInstance.GetOhValueNull(DdlselectedValue);
                hdnIsOhPercentChecked.Value = checkOhNull.Tables[0].Rows[0][0].ToString();
                }


            //DdlselectedValue = Convert.ToInt32(ddlClinetfilter.SelectedValue);
        }

        #region Private Method

        private void BindControls(int clintid=0)
        {
            ds = adminControlInstance.GetClientCostingDefaults(clintid);
            if (!IsPostBack)
            ViewState["currency"] = ds.Tables[1];
            ViewState["Achievement"] = ds.Tables[2];
            ViewState["WastageRange"] = ds.Tables[4];
            gvClientCostingDefaults.DataSource = ds.Tables[0];
            gvClientCostingDefaults.DataBind();

            ddlClinetfilter.DataSource = ds.Tables[3];
            ddlClinetfilter.DataTextField = "ClientName";
            ddlClinetfilter.DataValueField = "ClientId";
            ddlClinetfilter.DataBind();
            ddlClinetfilter.SelectedValue = clintid.ToString();
            DdlselectedValue = clintid;
           
        }

        private void BindCurrency(DropDownList ddlCurrency, int CurrencyId)
        {
            DataTable dtCurrency = (DataTable)ViewState["currency"];
            ddlCurrency.DataSource = dtCurrency;
            ddlCurrency.DataTextField = "CurrencySymbol";
            ddlCurrency.DataValueField = "Id";
            ddlCurrency.DataBind();
            if (CurrencyId != -1)
            {
                ddlCurrency.SelectedValue = CurrencyId.ToString();
            }
        }

        private void BindAchievement(DropDownList ddlAchievement, int AchievementId)
        {
            DataTable dtAchievement = (DataTable)ViewState["Achievement"];

            ddlAchievement.DataSource = dtAchievement;
            ddlAchievement.DataTextField = "Achivementlabels";
            ddlAchievement.DataValueField = "AchievementlabelsID";
            ddlAchievement.DataBind();
            if (AchievementId != -1)
            {
                ddlAchievement.SelectedValue = AchievementId.ToString();
            }
        }

        private void WastageRange(DropDownList ddlWastageRange, string WastageRangeId)
        {
            DataTable dtWastageRange = (DataTable)ViewState["WastageRange"];

            ddlWastageRange.DataSource = dtWastageRange;
            ddlWastageRange.DataTextField = "EXPECTEDQTY";
            ddlWastageRange.DataValueField = "ExpectedID";
            ddlWastageRange.DataBind();
            if (WastageRangeId != "")
            {
                ddlWastageRange.SelectedValue = WastageRangeId.ToString();
            }
        }
        #endregion

        protected void gvClientCostingDefaults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    for (int i = 2; i < e.Row.Cells.Count; i = i + 1)
                //    {
                //        e.Row.Cells[i].CssClass = "column_color text_align_left font_color_blue";
                //        HtmlInputCheckBox chkbox = new HtmlInputCheckBox();
                //        Label lblhead = new Label();
                //        chkbox.Attributes.Add("style", "width:15px !important;text-align:left!important");
                //        chkbox.Attributes.Add("title", "Click Here To Replicate");
                //        lblhead.Attributes.Add("style", "width:40px !important;text-align:right !important");
                //        chkbox.ID = "chkbox" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                //        chkbox.Name = "chkbox" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                //        chkbox.Attributes.Add("onClick", "change(this)");
                //        lblhead.Text = e.Row.Cells[i].Text.ToString();
                //        e.Row.Cells[i].Controls.Add(lblhead);
                //        e.Row.Cells[i].Controls.Add(chkbox);
                //lblhead.Text = e.Row.Cells[i].Text.ToString();

                //    }

                //}         
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlConvertTo = (DropDownList)e.Row.FindControl("ddlConvertTo");
                    HiddenField hdnConvertTo = (HiddenField)e.Row.FindControl("hdnConvertTo");
                    ddlConvertTo.Attributes.Add("class", "CONVERSION");
                    BindCurrency(ddlConvertTo, Convert.ToInt32(hdnConvertTo.Value));

                    DropDownList ddlACHIEVEMENT = (DropDownList)e.Row.FindControl("ddlACHIEVEMENT");
                    HiddenField hdnACHIEVEMENT = (HiddenField)e.Row.FindControl("hdnACHIEVEMENT");
                    ddlACHIEVEMENT.Attributes.Add("class", "ACHIEVE");
                    BindAchievement(ddlACHIEVEMENT, Convert.ToInt32(hdnACHIEVEMENT.Value));


                    DropDownList ddlWastageRange = (DropDownList)e.Row.FindControl("ddlWastageRange");
                    HiddenField hdnWastageRange = (HiddenField)e.Row.FindControl("hdnWastageRange");
                   // ddlACHIEVEMENT.Attributes.Add("class", "ACHIEVE");
                    WastageRange(ddlWastageRange, hdnWastageRange.Value);

                    //Added By Ashish on 22/10/2014
                    HiddenField hdnSizeSet1 = (HiddenField)e.Row.FindControl("hdnSizeSet1");
                    HiddenField hdnSizeSet2 = (HiddenField)e.Row.FindControl("hdnSizeSet2");
                    HiddenField hdnSizeSet3 = (HiddenField)e.Row.FindControl("hdnSizeSet3");
                    HiddenField hdnSizeSet4 = (HiddenField)e.Row.FindControl("hdnSizeSet4");
                    DropDownList ddlSizeSet1 = (DropDownList)e.Row.FindControl("ddlSizeSet1");
                    DropDownList ddlSizeSet2 = (DropDownList)e.Row.FindControl("ddlSizeSet2");
                    DropDownList ddlSizeSet3 = (DropDownList)e.Row.FindControl("ddlSizeSet3");
                    DropDownList ddlSizeSet4 = (DropDownList)e.Row.FindControl("ddlSizeSet4");

                    TextBox txtOverHeadValue = (TextBox)e.Row.FindControl("txtOverHeadValue");

                    if (txtOverHeadValue.Text == "0.00" || txtOverHeadValue.Text == "0.0" || txtOverHeadValue.Text == "0")
                    {
                        txtOverHeadValue.Text = "";
                    }
                    else
                    {
                        var roundText = Convert.ToDecimal(txtOverHeadValue.Text);
                       txtOverHeadValue.Text= Math.Round(roundText, 0).ToString();
                    }
                    if (hdnSizeSet1 != null)
                    {
                        ddlSizeSet1.SelectedValue = hdnSizeSet1.Value;
                    }
                    if (hdnSizeSet2 != null)
                    {
                        ddlSizeSet2.SelectedValue = hdnSizeSet2.Value;
                    }
                    if (hdnSizeSet3 != null)
                    {
                        ddlSizeSet3.SelectedValue = hdnSizeSet3.Value;
                    }
                    if (hdnSizeSet4 != null)
                    {  
                        ddlSizeSet4.SelectedValue = hdnSizeSet4.Value;
                    }
                    //abhishek 8/5/2016
                    HtmlInputCheckBox chkLAFFOBMode = (HtmlInputCheckBox)e.Row.FindControl("chkLAFFOBMode");
                    HtmlInputCheckBox chkLAHFOBMode = (HtmlInputCheckBox)e.Row.FindControl("chkLAHFOBMode");
                    HtmlInputCheckBox chkLSFFOBMode = (HtmlInputCheckBox)e.Row.FindControl("chkLSFFOBMode");
                    HtmlInputCheckBox chkLSHFOBMode = (HtmlInputCheckBox)e.Row.FindControl("chkLSHFOBMode");
                    HtmlInputCheckBox chkdDirectMode = (HtmlInputCheckBox)e.Row.FindControl("chkdDirectMode");                    
                    HtmlInputCheckBox chkIsOverheadChecked = (HtmlInputCheckBox)e.Row.FindControl("chkIsOverheadChecked");

                    //new code 06 feb 2020 starts
                    HtmlInputCheckBox chkMinCMTMode = (HtmlInputCheckBox)e.Row.FindControl("chkMinCMTMode");
                    //new code 06 feb 2020 end


                    //HtmlInputCheckBox chkLAFFOBMode = (HtmlInputCheckBox)e.Row.FindControl("chkLAFFOBMode");

                    chkLAFFOBMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'21','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString()+ "')");

                    chkLAHFOBMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'22','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");
                    chkLSFFOBMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'23','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");
                    chkLSHFOBMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'24','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");
                    chkdDirectMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'25','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");

                    chkIsOverheadChecked.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient_OverHead(this,'31','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");

                    //new code 06 feb 2020 starts
                    chkMinCMTMode.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient(this,'33','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");
                    //new code 06 feb 2020 end
                    

                    //END
                    //prabhaker 4-jul-17


                    TextBox FabPrice=(TextBox)e.Row.FindControl("txtFabAdjPrice");
                    if (FabPrice.Text == "")
                    {
                        FabPrice.Text = "5";
                    }
                    TextBox AccPrice = (TextBox)e.Row.FindControl("txtAccAdjPrice");
                    if (AccPrice.Text == "")
                    {
                        AccPrice.Text = "20";
                    }

                   
                    //END
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //ShowAlert(ex.Message.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int iSave = 0;
            for (int i = 0; i < gvClientCostingDefaults.Rows.Count; i++)
            {
                try
                {
                    objCosting.ClientID = Convert.ToInt32(((HiddenField)gvClientCostingDefaults.Rows[i].FindControl("hdnClientId")).Value);
                    objCosting.DepartmentID = Convert.ToInt32(((HiddenField)gvClientCostingDefaults.Rows[i].FindControl("hdnDeptId")).Value);
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtCommission")).Text != "")
                    {
                        objCosting.CommisionPercent = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtCommission")).Text);
                    }

                    objCosting.ConvertTo = Convert.ToInt32(((HiddenField)gvClientCostingDefaults.Rows[i].FindControl("hdnConvertTo")).Value);

                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtCOFFINBOX")).Text != "")
                    {
                        objCosting.CoffinBox = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtCOFFINBOX")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtHANGERLOOPS")).Text != "")
                    {
                        objCosting.HANGER_LOOPS = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtHANGERLOOPS")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtLbltags")).Text != "")
                    {
                        objCosting.LBL_TAGS = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtLbltags")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtOverHeadCost")).Text != "")
                    {
                        objCosting.OverHead = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtOverHeadCost")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtPROFITMARGIN")).Text != "")
                    {
                        objCosting.MarkupOnUnitCTC = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtPROFITMARGIN")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtTEST")).Text != "")
                    {
                        objCosting.TEST = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtTEST")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtHANGERS")).Text != "")
                    {
                        objCosting.Hangers = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtHANGERS")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtDESIGNCOMM")).Text != "")
                    {
                        objCosting.DesignCommission = Convert.ToDouble(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtDESIGNCOMM")).Text);
                    }
                    objCosting.Achivement = Convert.ToInt32(((HiddenField)gvClientCostingDefaults.Rows[i].FindControl("hdnACHIEVEMENT")).Value);

                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtEXPECTEDQTY")).Text != "")
                    {
                        objCosting.ExpectedQty = Convert.ToInt32(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtEXPECTEDQTY")).Text);
                    }
                    if (((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtFRTUptoport")).Text != "")
                    {
                        objCosting.frtUptoport = Convert.ToInt32(((TextBox)gvClientCostingDefaults.Rows[i].FindControl("txtFRTUptoport")).Text);
                    }

                    iSave = objCostingControler.SaveClientCostingDefault(objCosting.ClientID, objCosting.DepartmentID, objCosting.CommisionPercent, objCosting.ConvertTo,
                        objCosting.CoffinBox, objCosting.HANGER_LOOPS, objCosting.LBL_TAGS, objCosting.OverHead, objCosting.MarkupOnUnitCTC, objCosting.TEST, objCosting.Hangers,
                        objCosting.DesignCommission, objCosting.Achivement, objCosting.ExpectedQty, objCosting.frtUptoport);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    iSave = 0;
                }

            }
            if (iSave == 1)
            {
                ShowAlert("Saved successfully");
                BindControls();
            }
            else
            {
                ShowAlert("Data could not save successfully");
            }


        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void ddlClinetfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindControls(Convert.ToInt32(ddlClinetfilter.SelectedValue));
            DdlselectedValue = Convert.ToInt32(ddlClinetfilter.SelectedValue);
        }
       


    }
}
