using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;



namespace iKandi.Web.Internal.Fabric
{

    
    public partial class FrmFabricWastageEntry : System.Web.UI.Page
    {
        int LoggedInUserDesignationID;
        AdminController objadmincontroller = new AdminController();
        DataTable dt1 = new DataTable();

        public static int FabricQualityID;
        public static string FabricDetails;
        public static int FabType;
        public static int CurrentStage;
        public static int PreviousStage;
        public static bool IsStyleSpecfic;
        public static int StyleID;
        public static string IsExecute;
        public static int stage1;
        public static int stage2;
        public static int stage3;
        public static int stage4;
        public static int OrderDetailsID;
        public static decimal cutwastage;
        public static int Unitid;
        FabricController fabobj = new FabricController();
        int Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
        int QuanitytSum = 0;
        decimal sh1fotersum = 0, g1fotersum = 0, sh2fotersum = 0, g2fotersum = 0, sh3fotersum = 0, g3fotersum = 0, sh4fotersum = 0, g4fotersum = 0, wastagefotersum = 0, totalrequiredfotersum = 0;
        int gtCount_1 = 0, gtCount_2 = 0, gtCount_3 = 0, gtCount_4 = 0;
        int stCount_1 = 0, stCount_2 = 0, stCount_3 = 0, stCount_4 = 0;
        int Shrntk1 = 0;
        int Wastg1 = 0;


        string Unitname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                //BindDropDownlist();
                getquerystring();
                Bindgrd();
                //if (IsExecute == "YES" || IsExecute == "FABRICVIEW")
                //{ UpdateWastage(null); }
            }
        }
     
        public void getquerystring()
        {
            if (Request.QueryString["FabricQualityID"] != null)
            {
                FabricQualityID = Convert.ToInt32(Request.QueryString["FabricQualityID"].ToString());
            }
            else
            {
                FabricQualityID = -1;
            }
            if (Request.QueryString["FabricDetails"] != null)
            {
                FabricDetails = Request.QueryString["FabricDetails"].ToString();
            }
            else
            {
                FabricDetails = "";
            }
            if (Request.QueryString["FabType"] != null)
            {
                FabType = Convert.ToInt32(Request.QueryString["FabType"].ToString());
            }
            else
            {
                FabType = 1;
            }
            if (Request.QueryString["CurrentStage"] != null)
            {
                CurrentStage = Convert.ToInt32(Request.QueryString["CurrentStage"].ToString());
            }
            else
            {
                CurrentStage = 1;
            }
            if (Request.QueryString["PreviousStage"] != null)
            {
                PreviousStage = Convert.ToInt32(Request.QueryString["PreviousStage"].ToString());
            }
            else
            {
                PreviousStage = 1;
            }
            if (Request.QueryString["IsStyleSpecfic"] != null)
            {
                IsStyleSpecfic = Convert.ToBoolean(Request.QueryString["IsStyleSpecfic"].ToString() == "0" ? false : true);
            }
            else
            {
                IsStyleSpecfic = false;
            }
            if (Request.QueryString["StyleID"] != null)
            {
                StyleID = Convert.ToInt32(Request.QueryString["StyleID"].ToString());
            }
            else
            {
                StyleID = 1;
            }
            if (Request.QueryString["IsExecute"] != null)
            {
                IsExecute = Request.QueryString["IsExecute"].ToString();
            }
            else
            {
                IsExecute = "";
            }
            if (Request.QueryString["stage1"] != null)
            {
                stage1 = Convert.ToInt32(Request.QueryString["stage1"].ToString());
            }
            else
            {
                stage1 = -1;
            }

            if (Request.QueryString["stage2"] != null)
            {
                stage2 = Convert.ToInt32(Request.QueryString["stage2"].ToString());
            }
            else
            {
                stage2 = -1;
            }
            if (Request.QueryString["stage3"] != null)
            {
                stage3 = Convert.ToInt32(Request.QueryString["stage3"].ToString());
            }
            else
            {
                stage3 = -1;
            }
            if (Request.QueryString["stage4"] != null)
            {
                stage4 = Convert.ToInt32(Request.QueryString["stage4"].ToString());
            }
            else
            {
                stage4 = -1;
            }
            if (Request.QueryString["OrderDetailsID"] != null)
            {
                OrderDetailsID = Convert.ToInt32(Request.QueryString["OrderDetailsID"].ToString());
            }
            else
            {
                OrderDetailsID = -1;
            }
            if (Request.QueryString["cutwastage"] != null)
            {
                cutwastage = Convert.ToDecimal(Request.QueryString["cutwastage"].ToString());
            }
            else
            {
                cutwastage = -1;
            }
        }

        public string RetFabdetails(string FabricDetails)
        {
            if (FabType == 1 || (FabType == 29 && CurrentStage == 1))
            {
                return "";
            }
            else
            {
                return FabricDetails;
            }
        }

        public void Bindgrd()
        {
            DataTable dt = null;
            if (Enum.GetName(typeof(FabricProcessTypes), FabType) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embroidery")
            {
                dt = fabobj.GetFabricPrintWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabType), "GET", FabricQualityID, RetFabdetails(FabricDetails), CurrentStage, PreviousStage, IsStyleSpecfic, StyleID, stage1, stage2, stage3, stage4);
            }
            else
            {
                dt = fabobj.GetFabricWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabType), "GET", FabricQualityID, RetFabdetails(FabricDetails));
            }
            if (dt.Rows.Count > 0)
            {
                lblFabricQuality.Text = dt.Rows[0]["TradeName"].ToString();
                lblSugCutwastage.Text = dt.Rows[0]["SuggestedWastage"].ToString() == string.Empty ? "0" : dt.Rows[0]["SuggestedWastage"].ToString();
                lblFabricQuality.Text = dt.Rows[0]["TradeName"].ToString();
                lblgsm.Text = dt.Rows[0]["gsm"].ToString();
                lblcountconstraction.Text = dt.Rows[0]["CountConstruction"].ToString();
                lblwidth.Text = dt.Rows[0]["cutwidth"].ToString() + "&quot";
                if (FabType != 1 && !(FabType == 29 && CurrentStage == 1))
                {
                    lblcolor.Text = dt.Rows[0]["FabricDetails"].ToString();
                }
                grdwastage.DataSource = dt;
                grdwastage.DataBind();
                MergeRows(grdwastage);
                Calculatefoter();
                btnSubmit.Visible = true;
            }
            else
            {
                grdwastage.DataSource = dt;
                grdwastage.DataBind();
            }
        }

        protected void grdwastage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region foooter
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblquantity_footer_UnitName = (Label)e.Row.FindControl("lblquantity_footer_UnitName");
                Label lblStage1_Shrinkage_footer_UnitName = (Label)e.Row.FindControl("lblStage1_Shrinkage_footer_UnitName");
                Label lblStage1_Wastage_footer_UnitName = (Label)e.Row.FindControl("lblStage1_Wastage_footer_UnitName");
                Label lblStage2_Shrinkage_footer_UnitName = (Label)e.Row.FindControl("lblStage2_Shrinkage_footer_UnitName");
                Label lblStage2_Wastage_footer_UnitName = (Label)e.Row.FindControl("lblStage2_Wastage_footer_UnitName");
                Label lblshrinkage3_footer_UnitName = (Label)e.Row.FindControl("lblshrinkage3_footer_UnitName");
                Label lblwastage3_footer_UnitName = (Label)e.Row.FindControl("lblwastage3_footer_UnitName");
                Label lblshrinkage4_footer_UnitName = (Label)e.Row.FindControl("lblshrinkage4_footer_UnitName");
                Label lblwastage4_footer_UnitName = (Label)e.Row.FindControl("lblwastage4_footer_UnitName");
                Label lblcutwastage_footer_UnitName = (Label)e.Row.FindControl("lblcutwastage_footer_UnitName");
                Label lblrequiredqty_footer_UnitName = (Label)e.Row.FindControl("lblrequiredqty_footer_UnitName");

                lblquantity_footer_UnitName.Text = Unitname;
                lblStage1_Shrinkage_footer_UnitName.Text = Unitname;
                lblStage1_Wastage_footer_UnitName.Text = Unitname;
                lblStage2_Shrinkage_footer_UnitName.Text = Unitname;
                lblStage2_Wastage_footer_UnitName.Text = Unitname;
                lblshrinkage3_footer_UnitName.Text = Unitname;
                lblwastage3_footer_UnitName.Text = Unitname;
                lblshrinkage4_footer_UnitName.Text = Unitname;
                lblwastage4_footer_UnitName.Text = Unitname;
                lblcutwastage_footer_UnitName.Text = Unitname;
                lblrequiredqty_footer_UnitName.Text = Unitname;
            }
            #endregion footer

            #region DataRow
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int OrderDetaild = Convert.ToInt32(((HiddenField)e.Row.FindControl("hdnorderdetailsID")).Value);
                //RajeevS
                // int cutWastage = GetDetailForCutWastage(OrderDetaild);
                decimal shk1 = 0, shk2 = 0, shk3 = 0, shk4 = 0, wastage1 = 0, wastage2 = 0, wastage3 = 0, wastage4 = 0;
                decimal w1 = 0, w2 = 0, w3 = 0, w4 = 0;

                decimal S1 = 0;
                decimal s1re = 0;
                decimal s2re = 0;
                decimal s3re = 0;
                decimal s4re = 0;
                decimal TotalwithCutWastage = 0;
                decimal TotalRequired = 0;
                string Formulae, ReverseFormula = "";

                Unitid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "units").ToString());
                //rajeevs
                HtmlGenericControl spn_Rev = (HtmlGenericControl)e.Row.FindControl("spn_Rev");
                ReverseFormula = spn_Rev.InnerText;
                //HtmlGenericControl spn_Stage1Tooltip = (HtmlGenericControl)e.Row.FindControl("spn_Stage1Tooltip");                
                //rajeevS

                HtmlGenericControl span_UnitName = (HtmlGenericControl)e.Row.FindControl("span_UnitName");
                Unitname = span_UnitName.InnerText;

                Label lblstageName1 = (Label)e.Row.FindControl("lblstageName1");
                Label lblstageName2 = (Label)e.Row.FindControl("lblstageName2");
                Label lblstageName3 = (Label)e.Row.FindControl("lblstageName3");
                Label lblstageName4 = (Label)e.Row.FindControl("lblstageName4");

                TextBox txtshrinkage1 = (TextBox)e.Row.FindControl("txtshrinkage1");
                TextBox txtshrinkage2 = (TextBox)e.Row.FindControl("txtshrinkage2");
                TextBox txtshrinkage3 = (TextBox)e.Row.FindControl("txtshrinkage3");
                TextBox txtshrinkage4 = (TextBox)e.Row.FindControl("txtshrinkage4");

                TextBox txtwastage1 = (TextBox)e.Row.FindControl("txtwastage1");
                TextBox txtwastage2 = (TextBox)e.Row.FindControl("txtwastage2");
                TextBox txtwastage3 = (TextBox)e.Row.FindControl("txtwastage3");
                TextBox txtwastage4 = (TextBox)e.Row.FindControl("txtwastage4");

                Label lblshrinkage1 = (Label)e.Row.FindControl("lblshrinkage1");
                Label lblshrinkage2 = (Label)e.Row.FindControl("lblshrinkage2");
                Label lblshrinkage3 = (Label)e.Row.FindControl("lblshrinkage3");
                Label lblshrinkage4 = (Label)e.Row.FindControl("lblshrinkage4");


                Label lblwastage1 = (Label)e.Row.FindControl("lblwastage1");
                Label lblwastage2 = (Label)e.Row.FindControl("lblwastage2");
                Label lblwastage3 = (Label)e.Row.FindControl("lblwastage3");
                Label lblwastage4 = (Label)e.Row.FindControl("lblwastage4");

                Label lblwastage1_mtrunit = (Label)e.Row.FindControl("lblwastage1_mtrunit");

                Label lblcutwastage_percentsign = (Label)e.Row.FindControl("lblcutwastage_percentsign");
                Label lblcutwastage_unit = (Label)e.Row.FindControl("lblcutwastage_unit");

                Label lblvaluecutwastage = (Label)e.Row.FindControl("lblvaluecutwastage");
                //rajeevS
                HiddenField hdnCutwastage = (HiddenField)e.Row.FindControl("hdnCutwastge");

                TextBox lblcutwastage = (TextBox)e.Row.FindControl("lblcutwastage");
                LoggedInUserDesignationID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID;
                DataTable dt7 = fabobj.GetFabricCutWastagePermission(LoggedInUserDesignationID);
                if (dt7.Rows.Count >0)
                {
                    if ((LoggedInUserDesignationID == Convert.ToInt32(dt7.Rows[0]["Designationid"])) && (Convert.ToBoolean(dt7.Rows[0]["Permission"])))
                    {
                        lblcutwastage.ReadOnly = false;
                    }
                    else
                    {
                        lblcutwastage.ReadOnly = true;
                    }
                }
                else
                {
                    lblcutwastage.ReadOnly = true;
                }
                if (lblcutwastage.Text == "")
                {
                    lblcutwastage.Text = "0";
                }
                cutwastage = Convert.ToDecimal(lblcutwastage.Text);
                //rajeevS
                // lblcutwastage.Text = cutwastage.ToString() == "0" ? "" : cutwastage.ToString();

                lblcutwastage_percentsign.Text = cutwastage.ToString() == "0" ? "" : "<span style='color:gray;'>%</span>";
                if (lblcutwastage_unit != null)
                    lblcutwastage_unit.Text = cutwastage.ToString() == "0" ? "" : lblcutwastage_unit.Text;


                Label lblunitname = (Label)e.Row.FindControl("lblunitname");


                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                lblunitname.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "units").ToString()));



                Label lblquantity = (Label)e.Row.FindControl("lblquantity");
                HiddenField hdnavg = (HiddenField)e.Row.FindControl("hdnavg");
                HiddenField hdnrequiredqtywithoutround = (HiddenField)e.Row.FindControl("hdnrequiredqtywithoutround");
                HiddenField hdnfourpointpassqty = (HiddenField)e.Row.FindControl("hdnfourpointpassqty");

                hdnfourpointpassqty.Value = hdnfourpointpassqty.Value == "" ? "0" : hdnfourpointpassqty.Value;
                decimal qtyavg = Math.Round(Convert.ToDecimal(lblquantity.Text) * Convert.ToDecimal(hdnavg.Value == "" ? "0" : hdnavg.Value), 0);
                lblquantity.Text = qtyavg.ToString("N0");


                //added below patch on 2023-12-01 : Start
                if (lblstageName1.Text.ToLower() != "select".ToLower() && lblstageName2.Text.ToLower() == "select".ToLower() && IsOnlyStage1.Value.ToLower() != "No".ToLower())
                    IsOnlyStage1.Value = "Yes";  // Handling Width on aspx page based on this Value

                if (lblstageName1.Text.ToLower() != "select".ToLower() && lblstageName2.Text.ToLower() != "select".ToLower())
                    IsOnlyStage1.Value = "No"; // Handling Width on aspx page based on this Value

                if (lblstageName2.Text.ToLower() != "select".ToLower() && lblstageName3.Text.ToLower() == "select".ToLower() && isUptoStage2.Value.ToLower() != "No".ToLower())
                    isUptoStage2.Value = "Yes"; // Handling Width on aspx page based on this Value

                if (lblstageName2.Text.ToLower() != "select".ToLower() && lblstageName3.Text.ToLower() != "select".ToLower())
                    isUptoStage2.Value = "No"; // Handling Width on aspx page based on this Value

                if (lblstageName3.Text.ToLower() != "select".ToLower() && lblstageName4.Text.ToLower() == "select".ToLower() && isUptoStage3.Value.ToLower() != "No".ToLower())
                    isUptoStage3.Value = "Yes"; // Handling Width on aspx page based on this Value

                if (lblstageName3.Text.ToLower() != "select".ToLower() && lblstageName4.Text.ToLower() != "select".ToLower())
                    isUptoStage3.Value = "No";  // Handling Below Condition

                if (isUptoStage3.Value == "Yes")
                    stCount_3 = stCount_3 + 1;  // case where selected stage in one contract is  G-> D and in another contract is G-> D -> P , Handled here because of merging in Fabric View All Page                

                if (lblstageName2.Text.ToLower() != "select" && (lblstageName2.Text.ToLower() == "Dyed".ToLower() || lblstageName2.Text.ToLower() == "Printed".ToLower()))
                    stCount_2 = stCount_2 + 1;  //Handing the case in which Stage2 not showing  becuase residual shrinkage was missing in fabric master

                if (lblstageName3.Text.ToLower() != "select" && (lblstageName3.Text.ToLower() == "Dyed".ToLower() || lblstageName3.Text.ToLower() == "Printed".ToLower()))
                    stCount_3 = stCount_3 + 1; //Handing the case in which Stage3 not showing  becuase residual shrinkage was missing in fabric master

                if (lblstageName1.Text.ToLower() == "RFD".ToLower() || lblstageName1.Text.ToLower() == "Finished".ToLower())
                    stCount_1 = stCount_1 + 1; //Handing the case in which Stage1 not showing  becuase residual shrinkage was missing in fabric master                              

                //patch End

                if (lblstageName1.Text.ToLower() == "select")
                {
                    lblstageName1.Text = "";
                    txtshrinkage1.Enabled = false;
                    txtwastage1.Enabled = false;

                    txtshrinkage1.ToolTip = "";
                    txtwastage1.ToolTip = "";

                    gtCount_1 = gtCount_1 + 1;
                    stCount_1 = stCount_1 + 1;

                }

                if (FabType == 1)
                {
                    if (txtwastage1.Text == "")
                    {
                        txtwastage1.Text = DataBinder.Eval(e.Row.DataItem, "FabricGriegeMasterValue").ToString();

                    }
                    txtwastage1.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage1").ToString();
                    //spn_Stage1Tooltip.InnerHtml = "";//  DataBinder.Eval(e.Row.DataItem, "ToolTipStage1").ToString();

                    if (txtshrinkage2.Text == "")
                    {
                        txtshrinkage2.Text = DataBinder.Eval(e.Row.DataItem, "Stage2_Shrinkage").ToString();
                    }
                    txtshrinkage2.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage2").ToString();


                    if (txtshrinkage3.Text == "")
                    {
                        txtshrinkage3.Text = DataBinder.Eval(e.Row.DataItem, "Stage3_Shrinkage").ToString();
                    }
                    txtshrinkage3.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage3").ToString();

                    if (txtshrinkage4.Text == "")
                    {
                        txtshrinkage4.Text = DataBinder.Eval(e.Row.DataItem, "Stage4_Shrinkage").ToString();
                    }
                    txtshrinkage4.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage4").ToString();

                    if (lblcutwastage.Text == "")
                    {
                        lblcutwastage.Text = DataBinder.Eval(e.Row.DataItem, "lblcutwastage").ToString();
                    }
                    lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();


                    txtwastage2.Enabled = false;
                    txtwastage3.Enabled = false;
                    txtwastage4.Enabled = false;

                    txtwastage2.ToolTip = "";
                    txtwastage3.ToolTip = "";
                    txtwastage4.ToolTip = "";
                    lblshrinkage1.Text = "";

                    HtmlGenericControl span_wastage2_percent = (HtmlGenericControl)e.Row.FindControl("span_wastage2_percent");
                    HtmlGenericControl span_wastage2_UnitName = (HtmlGenericControl)e.Row.FindControl("span_wastage2_UnitName");

                    if (lblstageName2.Text.ToLower() == "Dyed".ToLower() || lblstageName2.Text.ToLower() == "Printed".ToLower() || lblstageName2.Text.ToLower() == "Finished".ToLower() || lblstageName2.Text.ToLower() == "RFD".ToLower())
                    {
                        txtshrinkage2.Enabled = true;
                        txtwastage2.Enabled = false;
                        txtwastage2.Text = "";
                        txtwastage2.ToolTip = "";
                        lblwastage2.Text = "";

                        span_wastage2_percent.InnerText = "";
                        //if(span_wastage2_UnitName.InnerText != null)
                        //span_wastage2_UnitName.InnerText = "";

                    }
                    else
                    {
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = true;

                        txtshrinkage2.Text = "";
                        txtshrinkage2.ToolTip = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWASTAGE", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage2").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage2.Text == "")
                            {
                                txtwastage2.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }
                            txtwastage2.ToolTip = dt.Rows[0]["VAWASTAGE"].ToString();
                        }
                        lblshrinkage2.Text = "";

                    }
                    HtmlGenericControl span_wastage3_percent = (HtmlGenericControl)e.Row.FindControl("span_wastage3_percent");
                    HtmlGenericControl span_wastage3_UnitName = (HtmlGenericControl)e.Row.FindControl("span_wastage3_UnitName");

                    if (lblstageName3.Text.ToLower() == "Dyed".ToLower() || lblstageName3.Text.ToLower() == "Printed".ToLower() || lblstageName3.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage3.Enabled = true;
                        txtwastage3.Enabled = false;
                        txtwastage3.Text = "";
                        txtwastage3.ToolTip = "";
                        lblwastage3.Text = "";

                        span_wastage3_percent.InnerText = "";
                        //span_wastage3_UnitName.InnerText = "";

                    }
                    else
                    {
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = true;
                        txtshrinkage3.Text = "";
                        lblshrinkage3.Text = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage3").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage3.Text == "")
                            {
                                txtwastage3.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }
                            txtwastage3.ToolTip = dt.Rows[0]["VAWASTAGE"].ToString();
                        }

                    }

                    HtmlGenericControl span_wastage4_percent = (HtmlGenericControl)e.Row.FindControl("span_wastage4_percent");
                    HtmlGenericControl span_wastage4_UnitName = (HtmlGenericControl)e.Row.FindControl("span_wastage4_UnitName");

                    if (lblstageName4.Text.ToLower() == "Dyed".ToLower() || lblstageName4.Text.ToLower() == "Printed".ToLower() || lblstageName4.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage4.Enabled = true;
                        txtwastage4.Enabled = false;
                        txtwastage4.Text = "";
                        lblwastage4.Text = "";
                        txtwastage4.ToolTip = "";

                        span_wastage4_percent.InnerText = "";
                        //span_wastage4_UnitName.InnerText = "";
                    }
                    else
                    {
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = true;
                        txtshrinkage4.Text = "";
                        lblshrinkage4.Text = "";
                        txtshrinkage4.ToolTip = "";

                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage4").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage4.Text == "")
                            {
                                txtwastage4.Text = dt.Rows[0]["VAWastage"].ToString();
                            }
                            txtwastage4.ToolTip = dt.Rows[0]["VAWastage"].ToString();
                        }
                    }
                    txtshrinkage1.Enabled = false;
                    txtshrinkage1.Text = "";
                    txtshrinkage1.ToolTip = "";
                    lblshrinkage1.Text = "";

                    HtmlGenericControl span_shrinkage2_percent = (HtmlGenericControl)e.Row.FindControl("span_shrinkage2_percent");
                    HtmlGenericControl span_shrinkage2_UnitName = (HtmlGenericControl)e.Row.FindControl("span_shrinkage2_UnitName");

                    if (lblstageName2.Text.ToLower() == "select")
                    {
                        lblstageName2.Text = "";
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = false;

                        txtshrinkage2.ToolTip = "";
                        txtwastage2.ToolTip = "";

                        e.Row.Cells[6].Attributes.Add("style", "background-color: ");
                        txtshrinkage2.Text = "";
                        txtwastage2.Text = "";

                        lblshrinkage2.Text = "";
                        lblwastage2.Text = "";

                        span_shrinkage2_percent.InnerText = "";
                        //span_shrinkage2_UnitName.InnerText = "";
                    }

                    HtmlGenericControl span_shrinkage3_percent = (HtmlGenericControl)e.Row.FindControl("span_shrinkage3_percent");
                    HtmlGenericControl span_shrinkage3_UnitName = (HtmlGenericControl)e.Row.FindControl("span_shrinkage3_UnitName");

                    if (lblstageName3.Text.ToLower() == "select")
                    {
                        lblstageName3.Text = "";
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = false;

                        txtshrinkage3.ToolTip = "";
                        txtwastage3.ToolTip = "";

                        e.Row.Cells[9].Attributes.Add("style", "background-color:;");

                        txtshrinkage3.Text = "";
                        txtwastage3.Text = "";

                        lblshrinkage3.Text = "";
                        lblwastage3.Text = "";

                        span_shrinkage3_percent.InnerText = "";
                        //span_shrinkage3_UnitName.InnerText = "";
                    }

                    HtmlGenericControl span_shrinkage4_percent = (HtmlGenericControl)e.Row.FindControl("span_shrinkage4_percent");
                    HtmlGenericControl span_shrinkage4_UnitName = (HtmlGenericControl)e.Row.FindControl("span_shrinkage4_UnitName");

                    if (lblstageName4.Text.ToLower() == "select")
                    {
                        lblstageName4.Text = "";
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = false;

                        txtshrinkage4.ToolTip = "";
                        txtwastage4.ToolTip = "";


                        e.Row.Cells[10].Attributes.Add("style", "background-color:;");
                        txtshrinkage4.Text = "";
                        txtwastage4.Text = "";

                        lblshrinkage4.Text = "";
                        lblwastage4.Text = "";

                        span_shrinkage4_percent.InnerText = "";
                        //span_shrinkage4_UnitName.InnerText = "";
                    }
                }
                else if (FabType == 10)
                {
                    if (txtshrinkage1.Text == "")
                    {
                        txtshrinkage1.Text = DataBinder.Eval(e.Row.DataItem, "Stage1_Shrinkage").ToString();
                        lblcutwastage_percentsign.Text = cutwastage.ToString() == "0" ? "" : "<span style='color:gray;'>%</span>";
                    }
                    txtshrinkage1.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage1").ToString();
                    lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();

                    txtwastage2.Enabled = false;
                    txtwastage3.Enabled = false;
                    txtwastage4.Enabled = false;
                    lblwastage2.Text = "";

                    if (lblstageName2.Text.ToLower() == "Dyed".ToLower() || lblstageName2.Text.ToLower() == "Printed".ToLower() || lblstageName2.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage2.Enabled = true;
                        txtwastage2.Enabled = false;
                        txtwastage2.ToolTip = "";
                        txtwastage2.Text = "";
                        lblwastage2.Text = "";
                    }
                    else
                    {
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = true;
                        txtshrinkage2.Text = "";
                        lblshrinkage2.Text = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWASTAGE", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage2").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage2.Text == "")
                            {
                                txtwastage2.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }
                            txtwastage2.ToolTip = dt.Rows[0]["VAWASTAGE"].ToString();
                        }
                    }
                    if (lblstageName3.Text.ToLower() == "Dyed".ToLower() || lblstageName3.Text.ToLower() == "Printed".ToLower() || lblstageName3.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage3.Enabled = true;
                        txtwastage3.Enabled = false;
                        txtwastage3.Text = "";

                        txtwastage3.ToolTip = "";
                        lblwastage3.Text = "";
                    }
                    else
                    {
                        txtshrinkage3.ToolTip = "";
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = true;
                        txtshrinkage3.Text = "";
                        lblshrinkage3.Text = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage3").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage3.Text == "")
                            {
                                txtwastage3.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }
                            txtwastage3.ToolTip = dt.Rows[0]["VAWASTAGE"].ToString();
                        }
                    }

                    if (lblstageName4.Text.ToLower() == "Dyed".ToLower() || lblstageName4.Text.ToLower() == "Printed".ToLower() || lblstageName4.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage4.Enabled = true;
                        txtwastage4.Enabled = false;
                        txtwastage4.Text = "";
                        txtwastage4.ToolTip = "";
                        lblwastage4.Text = "";
                    }
                    else
                    {
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = true;
                        txtshrinkage4.Text = "";
                        lblshrinkage4.Text = "";
                        txtshrinkage4.ToolTip = "";

                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage4").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage4.Text == "")
                            {
                                txtwastage4.Text = dt.Rows[0]["VAWastage"].ToString();
                            }
                            txtwastage4.ToolTip = dt.Rows[0]["VAWastage"].ToString();
                        }
                    }
                    txtwastage1.ToolTip = "";
                    txtwastage1.Enabled = false;
                    txtwastage1.Text = "";
                    lblwastage1.Text = "";


                    if (lblstageName2.Text.ToLower() == "select")
                    {
                        lblstageName2.Text = "";
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = false;

                        txtshrinkage2.ToolTip = "";
                        txtwastage2.ToolTip = "";


                        e.Row.Cells[6].Attributes.Add("style", "background-color:;");
                        txtshrinkage2.Text = "";
                        txtwastage2.Text = "";

                        lblshrinkage2.Text = "";
                        lblwastage2.Text = "";
                    }

                    if (lblstageName3.Text.ToLower() == "select")
                    {
                        lblstageName3.Text = "";
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = false;

                        txtshrinkage3.ToolTip = "";
                        txtwastage3.ToolTip = "";


                        e.Row.Cells[9].Attributes.Add("style", "background-color: ;");

                        txtshrinkage3.Text = "";
                        txtwastage3.Text = "";

                        lblshrinkage3.Text = "";
                        lblwastage3.Text = "";
                    }
                    if (lblstageName4.Text.ToLower() == "select")
                    {
                        lblstageName4.Text = "";
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = false;
                        e.Row.Cells[12].Attributes.Add("style", "background-color: ;");
                        txtshrinkage4.Text = "";
                        txtwastage4.Text = "";

                        txtshrinkage4.ToolTip = "";
                        txtwastage4.ToolTip = "";

                        lblshrinkage4.ToolTip = "";
                        lblwastage4.ToolTip = "";
                    }

                }
                else if (Enum.GetName(typeof(FabricProcessTypes), FabType) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embroidery")
                {
                    txtwastage2.Enabled = false;
                    txtwastage3.Enabled = false;
                    txtwastage4.Enabled = false;
                    txtshrinkage1.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage1").ToString();
                    lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();
                    if (lblstageName1.Text.ToLower() == "Griege".ToLower())
                    {
                        if (txtwastage1.Text == "")
                        {
                            txtwastage1.Text = DataBinder.Eval(e.Row.DataItem, "FabricGriegeMasterValue").ToString();
                        }
                        txtwastage1.Enabled = true;
                        txtshrinkage1.Enabled = false;
                        txtshrinkage1.Text = "";
                        lblshrinkage1.Text = "";
                        txtshrinkage1.ToolTip = "";
                    }
                    else if (lblstageName1.Text.ToLower() == "RFD".ToLower() || lblstageName1.Text.ToLower() == "Finished".ToLower())
                    {
                        txtwastage1.ToolTip = "";
                        txtwastage1.Enabled = false;
                        txtwastage1.Text = "";
                        lblwastage1.Text = "";

                        if (txtshrinkage1.Text == "")
                        {
                            txtshrinkage1.Text = DataBinder.Eval(e.Row.DataItem, "Stage1_Shrinkage").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "Stage1_Shrinkage").ToString();
                        }
                    }

                    if (lblstageName2.Text.ToLower() == "Dyed".ToLower() || lblstageName2.Text.ToLower() == "Printed".ToLower() || lblstageName2.Text.ToLower() == "Finished".ToLower() || lblstageName2.Text.ToLower() == "RFD".ToLower())
                    {
                        txtshrinkage2.Enabled = true;
                        txtwastage2.Enabled = false;
                        txtwastage2.ToolTip = "";
                        txtwastage2.Text = "";
                        lblwastage2.Text = "";
                        txtshrinkage2.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage2").ToString();
                        lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();


                    }
                    else
                    {
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = true;
                        txtshrinkage2.Text = "";
                        lblshrinkage2.Text = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWASTAGE", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage2").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage2.Text == "")
                            {
                                txtwastage2.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }

                            txtwastage2.ToolTip = dt.Rows[0]["VAWASTAGE"].ToString();
                        }
                    }
                    if (lblstageName3.Text.ToLower() == "Dyed".ToLower() || lblstageName3.Text.ToLower() == "Printed".ToLower() || lblstageName3.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage3.Enabled = true;
                        txtwastage3.Enabled = false;

                        lblwastage3.Text = "";
                        txtwastage3.ToolTip = "";
                        txtshrinkage3.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage3").ToString();
                        lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();

                    }
                    else
                    {
                        txtshrinkage3.ToolTip = "";
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = true;
                        txtshrinkage3.Text = "";
                        lblshrinkage3.Text = "";
                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage3").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage3.Text == "")
                            {
                                txtwastage3.Text = dt.Rows[0]["VAWASTAGE"].ToString();
                            }
                            txtwastage3.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage3").ToString(); //dt.Rows[0]["VAWASTAGE"].ToString();
                        }
                    }
                    if (lblstageName4.Text.ToLower() == "Dyed".ToLower() || lblstageName4.Text.ToLower() == "Printed".ToLower() || lblstageName4.Text.ToLower() == "Finished".ToLower())
                    {
                        txtshrinkage4.Enabled = true;
                        txtwastage4.Enabled = false;
                        txtwastage4.Text = "";
                        lblwastage4.Text = "";
                        txtwastage4.ToolTip = "";
                        txtshrinkage4.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage4").ToString();
                        lblcutwastage.ToolTip = DataBinder.Eval(e.Row.DataItem, "ToolTipStage5").ToString();
                    }
                    else
                    {
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = true;
                        txtshrinkage4.Text = "";
                        lblshrinkage4.Text = "";
                        txtshrinkage4.ToolTip = "";

                        DataTable dt = fabobj.GetFabricVAWastage(Enum.GetName(typeof(FabricProcessTypes), FabType), "VAWastage", Convert.ToInt32(lblquantity.Text.Replace(",", "")), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage4").ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            if (txtwastage4.Text == "")
                            {
                                txtwastage4.Text = dt.Rows[0]["VAWastage"].ToString();
                            }
                            txtwastage4.ToolTip = dt.Rows[0]["VAWastage"].ToString();
                        }
                    }



                    if (lblstageName2.Text.ToLower() == "select")
                    {
                        lblstageName2.Text = "";
                        txtshrinkage2.Enabled = false;
                        txtwastage2.Enabled = false;

                        txtshrinkage2.ToolTip = "";
                        txtwastage2.ToolTip = "";


                        e.Row.Cells[6].Attributes.Add("style", "background-color: ;");
                        txtshrinkage2.Text = "";
                        txtwastage2.Text = "";

                        lblshrinkage2.Text = "";
                        lblwastage2.Text = "";
                    }

                    if (lblstageName3.Text.ToLower() == "select")
                    {
                        lblstageName3.Text = "";
                        txtshrinkage3.Enabled = false;
                        txtwastage3.Enabled = false;

                        txtshrinkage3.ToolTip = "";
                        txtwastage3.ToolTip = "";


                        e.Row.Cells[9].Attributes.Add("style", "background-color: ;");

                        txtshrinkage3.Text = "";
                        txtwastage3.Text = "";

                        lblshrinkage3.Text = "";
                        lblwastage3.Text = "";
                    }
                    if (lblstageName4.Text.ToLower() == "select")
                    {
                        lblstageName4.Text = "";
                        txtshrinkage4.Enabled = false;
                        txtwastage4.Enabled = false;
                        e.Row.Cells[12].Attributes.Add("style", "background-color: ;");
                        txtshrinkage4.Text = "";
                        txtwastage4.Text = "";

                        txtshrinkage4.ToolTip = "";
                        txtwastage4.ToolTip = "";

                        lblshrinkage4.Text = "";
                        lblwastage4.Text = "";
                    }

                    // End of Handling the stage numbers and stage types and Required quantity updates

                }


                if (txtwastage1.Text == "" && lblstageName1.Text.ToLower() != "RFD".ToLower())
                    txtwastage1.Text = DataBinder.Eval(e.Row.DataItem, "FabricGriegeMasterValue").ToString();



                if (txtwastage1.Text != "" && txtwastage1.Text != "0")
                {
                    gtCount_1 = gtCount_1 + 1;
                }
                if (txtshrinkage1.Text != "" && txtshrinkage1.Text != "0")
                {
                    stCount_1 = stCount_1 + 1;
                }

                if (txtwastage2.Text != "" && txtwastage2.Text != "0")
                {
                    gtCount_2 = gtCount_2 + 1;
                }
                if (txtshrinkage2.Text != "" && txtshrinkage2.Text != "0")
                {
                    stCount_2 = stCount_2 + 1;
                }

                if (txtwastage3.Text != "" && txtwastage3.Text != "0")
                {
                    gtCount_3 = gtCount_3 + 1;
                }
                if (txtshrinkage3.Text != "" && txtshrinkage3.Text != "0")
                {
                    stCount_3 = stCount_3 + 1;
                }

                if (txtwastage4.Text != "" && txtwastage4.Text != "0")
                {
                    gtCount_4 = gtCount_4 + 1;
                }
                if (txtshrinkage4.Text != "" && txtshrinkage4.Text != "0")
                {
                    stCount_4 = stCount_4 + 1;
                }

                shk1 = (txtshrinkage1.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage1.Text));
                Shrntk1 = Convert.ToInt32(shk1);
                shk2 = (txtshrinkage2.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage2.Text));
                shk3 = (txtshrinkage3.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage3.Text));
                shk4 = (txtshrinkage4.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage4.Text));

                wastage1 = (txtwastage1.Text == "" ? 0 : Convert.ToDecimal(txtwastage1.Text));
                Wastg1 = Convert.ToInt16(wastage1);
                wastage2 = (txtwastage2.Text == "" ? 0 : Convert.ToDecimal(txtwastage2.Text));
                wastage3 = (txtwastage3.Text == "" ? 0 : Convert.ToDecimal(txtwastage3.Text));
                wastage4 = (txtwastage4.Text == "" ? 0 : Convert.ToDecimal(txtwastage4.Text));
                if (shk1 > 0)
                {
                    w1 = shk1;
                }
                else if (wastage1 > 0)
                {
                    w1 = wastage1;
                }
                if (shk2 > 0)
                {
                    w2 = shk2;
                }
                else if (wastage2 > 0)
                {
                    w2 = wastage2;
                }
                if (shk3 > 0)
                {
                    w3 = shk3;
                }
                else if (wastage3 > 0)
                {
                    w3 = wastage3;
                }
                if (shk4 > 0)
                {
                    w4 = shk4;
                }
                else if (wastage4 > 0)
                {
                    w4 = wastage4;
                }


                //decimal S2 = 0, S3 = 0, S4 = 0;

                //S1 = (Convert.ToDecimal(lblquantity.Text.Replace(",", "")));
                //  S1 = Math.Round(Convert.ToDecimal((Convert.ToDecimal(lblquantity.Text.Replace(",", "")) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w1))-(Convert.ToDecimal(lblquantity.Text.Replace(",", ""))),1);


                S1 = (Convert.ToDecimal(lblquantity.Text.Replace(",", "")) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w1);
                S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w2);
                S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w3);
                S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w4);

                Decimal RequiredCon = Convert.ToDecimal(lblquantity.Text.Replace(",", ""));

                s1re = Convert.ToDecimal((Convert.ToDecimal(lblquantity.Text.Replace(",", "")) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w1)) - (RequiredCon);
                s2re = Convert.ToDecimal((Convert.ToDecimal(s1re + RequiredCon) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w2)) - (s1re + RequiredCon);
                s3re = Convert.ToDecimal((Convert.ToDecimal(s2re + s1re + RequiredCon) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w3)) - (s2re + s1re + RequiredCon);
                s4re = Convert.ToDecimal((Convert.ToDecimal(s3re + s2re + s1re + RequiredCon) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w4)) - (s3re + s2re + s1re + RequiredCon);
                TotalwithCutWastage = Convert.ToDecimal((Convert.ToDecimal(s3re + s2re + s1re + s4re + RequiredCon) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - cutwastage)) - (s4re + s3re + s2re + s1re + RequiredCon);

                TotalRequired = Math.Round(s1re + s2re + s3re + s4re + TotalwithCutWastage + RequiredCon, 0);
                //Formulae = "(((((" + Convert.ToString(RequiredCon) + "/(1-" + Convert.ToString(w1) + "%))/(1-" + Convert.ToString(w2) + "%))/(1-" + Convert.ToString(w3) + "%))/(1-" + Convert.ToString(w4) + "%))/(1-" + Convert.ToString(cutwastage) + "))";
                //if (Enum.GetName(typeof(FabricProcessTypes), FabType) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabType) == "Embroidery")
                //{
                //    dt = fabobj.GetFabricPrintWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabType), "GET", FabricQualityID, RetFabdetails(FabricDetails), CurrentStage, PreviousStage, IsStyleSpecfic, StyleID, stage1, stage2, stage3, stage4);
                //}

                //if (CurrentStage)
                if (w4 > 0)
                {
                    Formulae = "(((((" + Convert.ToString(RequiredCon) + "/(1-" + Convert.ToString(w1) + "%))/(1-" + Convert.ToString(w2) + "%))/(1-" + Convert.ToString(w3) + "%))/(1-" + Convert.ToString(w4) + "%))/(1-" + Convert.ToString(cutwastage) + "%))";
                    //RajeevS
                    decimal ValueForW1 = (TotalRequired * w1 / 100);
                    decimal ValueForW2 = (TotalRequired - ValueForW1) * (w2 / 100);
                    decimal ValueForW3 = (TotalRequired - (ValueForW1 + ValueForW2)) * (w3 / 100);
                    decimal ValueForW4 = (TotalRequired - (ValueForW1 + ValueForW2 + ValueForW3)) * (w4 / 100);
                    decimal ValueForCutWastage = (TotalRequired - (ValueForW1 + ValueForW2)) * (cutwastage / 100);
                    ReverseFormula = "(((" + " " + "<span style='color:#000000'><b>" +
                        Convert.ToString(Math.Round(TotalRequired, 0)) + "</b></span>" + "-" + Convert.ToString(w1) + "% " +
                        " [" + Math.Round(ValueForW1, 0) + "] )-" + Convert.ToString(w2) + "% " +
                        " [" + Math.Round(ValueForW2, 0) + "] )-" + Convert.ToString(w3) + "% " +
                        " [" + Math.Round(ValueForW3, 0) + "] )-" + Convert.ToString(w4) + "% " +
                        " [" + Math.Round(ValueForW4, 0) + "] )-" + Convert.ToString(cutwastage) + "% " +
                        " [" + Math.Round(ValueForCutWastage, 0) + "] )=" +
                        "<span style='color:#0808ffc4'><b>" + +RequiredCon + "</b><span>";
                    //RajeevS 
                }
                else if (w3 > 0)
                {
                    Formulae = "((((" + Convert.ToString(RequiredCon) + "/(1-" + Convert.ToString(w1) + "%))/(1-" + Convert.ToString(w2) + "%))/(1-" + Convert.ToString(w3) + "%))/(1-" + Convert.ToString(cutwastage) + "%))";
                    //RajeevS 28022023
                    decimal ValueForW1 = (TotalRequired * w1 / 100);
                    decimal ValueForW2 = (TotalRequired - ValueForW1) * (w2 / 100);
                    decimal ValueForW3 = (TotalRequired - (ValueForW1 + ValueForW2)) * (w3 / 100);
                    decimal ValueForCutWastage = (TotalRequired - (ValueForW1 + ValueForW2)) * (cutwastage / 100);
                    ReverseFormula = "(((" + " " + "<span style='color:#000000'><b>" + Convert.ToString(Math.Round(TotalRequired, 0))
                        + "</b></span>" + "-" + Convert.ToString(w1) + "% " +
                        " [" + Math.Round(ValueForW1, 0) + "] )-" + Convert.ToString(w2) + "% " +
                        " [" + Math.Round(ValueForW2, 0) + "] )-" + Convert.ToString(w3) + "%" +
                        " [" + Math.Round(ValueForW3, 0) + "] )-" + Convert.ToString(cutwastage) + "%" +
                        " [" + Math.Round(ValueForCutWastage, 0) + "] )=" + "<span style='color:#0000FF'><b>" + +RequiredCon + "</b><span>";
                    //RajeevS 
                }
                else if (w2 > 0)
                {
                    Formulae = "(((" + Convert.ToString(RequiredCon) + "/(1-" + Convert.ToString(w1) + "%))/(1-" + Convert.ToString(w2) + "%))/(1-" + Convert.ToString(cutwastage) + "%))";
                    //RajeevS 28022023
                    decimal ValueForW1 = (TotalRequired * w1 / 100);
                    decimal ValueForW2 = (TotalRequired - ValueForW1) * (w2 / 100);
                    decimal ValueForCutWastage = (TotalRequired - (ValueForW1 + ValueForW2)) * (cutwastage / 100);
                    ReverseFormula = "(((" + " " + "<span style='color:#000000'><b>" + Convert.ToString(Math.Round(TotalRequired, 0))
                        + "</b></span>" + "-" + Convert.ToString(w1) + "% " +
                        " [" + Math.Round(ValueForW1, 0) + "] )-" + Convert.ToString(w2) + "%" +
                        " [" + Math.Round(ValueForW2, 0) + "] )-" + Convert.ToString(cutwastage) + "%" +
                        " [" + Math.Round(ValueForCutWastage, 0) + "] )=" + "<span style='color:#0000FF'><b>" + +RequiredCon + "</b><span>";
                    //RajeevS 
                }
                else
                {
                    Formulae = "((" + Convert.ToString(RequiredCon) + "/(1-" + Convert.ToString(w1) + "%))/(1-" + Convert.ToString(cutwastage) + "%))";
                    //RajeevS 28022023
                    decimal ValueForW1 = (TotalRequired * w1 / 100);
                    decimal ValueForCutWastage = (TotalRequired - (ValueForW1)) * (cutwastage / 100);
                    ReverseFormula = "(((" + " " + "<span style='color:#000000'><b>" + Convert.ToString(Math.Round(TotalRequired, 0))
                        + "</b></span>" + "-" + Convert.ToString(w1) + "% " +
                        " [" + Math.Round(ValueForW1, 0) + "] )-" + Convert.ToString(cutwastage) + "% " +
                        " [" + Math.Round(ValueForCutWastage, 0) + "] )=" + "<span style='color:#0000FF'><b>" + +RequiredCon + "</b><span>";
                    //RajeevS 
                }


                // Handle the stage numbers and stage types and Required quantity updates
                //int CurrentStageNumber = 0;
                if (CurrentStage == 1)
                {
                    //TotalRequired = TotalRequired;
                }
                else if (CurrentStage == 2)
                {
                    // second stage type
                    // previous stage type
                    if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                        {
                            TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))), 0);
                            Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)";
                        }
                    }
                    else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "Finished")
                        {
                            TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))), 0);
                            Formulae = Formulae + "*(1-" + Convert.ToString(w2) + "%)";
                        }
                    }
                }
                else if (CurrentStage == 3)
                {
                    if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Dyed")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                            {
                                TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))), 0);
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)";
                            }
                        }
                        if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                        {
                            TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))), 0);
                            Formulae = Formulae + "*(1-" + Convert.ToString(w2) + "%)";
                        }
                        else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                            {
                                TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))), 0);
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)";
                            }
                        }
                    }
                    else if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embroidery")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                            {
                                TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100))), 0);
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w3) + "%)";
                            }
                        }
                        else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                            {
                                TotalRequired = Math.Round(TotalRequired * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100))), 0);
                                Formulae = Formulae + "*(1-" + Convert.ToString(w2) + "%)" + "*(1-" + Convert.ToString(w3) + "%)";
                            }
                        }
                    }
                }
                else if (CurrentStage == 4)
                {
                    if (Enum.GetName(typeof(FabricProcessTypes), stage4) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage4) == "Dyed")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Dyed")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)";
                                }
                            }
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100)));
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)";
                            }
                            else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)";
                                }
                            }
                        }
                        else if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embroidery")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w3) + "%)";
                                }
                            }
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100)))
                                    //* (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))) 
                                    * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100)));
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" // + "*(1-" + Convert.ToString(w2) + "%)" 
                                    + "*(1-" + Convert.ToString(w3) + "%)";
                            }
                            else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100)))
                                        * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100)))
                                        * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)" + "*(1-" + Convert.ToString(w3) + "%)";
                                }
                            }
                        }
                    }
                    else if (Enum.GetName(typeof(FabricProcessTypes), stage4) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage4) == "Embroidery")
                    {
                        if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Dyed")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                                }
                            }
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                                Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                            }
                            else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w2) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                                }
                            }
                        }
                        else if (Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage3) == "Embroidery")
                        {
                            if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w3) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                                }
                            }
                            //if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "RFD")
                            //{
                            //    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w1) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                            //    Formulae = Formulae + "*(1-" + Convert.ToString(w1) + "%)" + "*(1-" + Convert.ToString(w3) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                            //}
                            else if (Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), stage2) == "Embroidery")
                            {
                                if (Enum.GetName(typeof(FabricProcessTypes), stage1) == "Griege" || Enum.GetName(typeof(FabricProcessTypes), stage1) == "RFD")
                                {
                                    TotalRequired = TotalRequired * (1 - (Convert.ToDecimal(w2) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w3) / Convert.ToDecimal(100))) * (1 - (Convert.ToDecimal(w4) / Convert.ToDecimal(100)));
                                    Formulae = Formulae + "*(1-" + Convert.ToString(w2) + "%)" + "*(1-" + Convert.ToString(w3) + "%)" + "*(1-" + Convert.ToString(w4) + "%)";
                                }
                            }
                        }
                    }
                }
                if (TotalwithCutWastage > 0)
                {
                    lblvaluecutwastage.Text = Math.Round(TotalwithCutWastage, 0).ToString();
                }
                if (TotalwithCutWastage >= 0)
                {
                    lblrequiredqty.Text = Math.Round(TotalRequired, 0).ToString("N0");
                    if (Convert.ToInt32(hdnfourpointpassqty.Value) > 0)
                    {
                        //decimal diff = Convert.ToDecimal(hdnfourpointpassqty.Value) - TotalRequired;
                        decimal diff = TotalRequired - Convert.ToDecimal(hdnfourpointpassqty.Value);
                        if (diff >= 2 || diff <= -2)
                        {
                            //lblrequiredqty.ToolTip = Formulae + " " + "<span style='color:#bbb2b2'>" + "=" + Math.Round(TotalRequired, 2).ToString("0.####") + "</span>" + "</br>" + " Cut Wastage Difference " + Math.Round(Convert.ToDecimal(hdnfourpointpassqty.Value), 2).ToString("0.####") + " - " + Math.Round(TotalRequired, 2).ToString("0.####") + "<span style='color:#FFFF00'>" + "=" + Math.Round(diff, 2).ToString("0.####") + "</span>";

                            lblrequiredqty.ToolTip = Formulae + " " + "<span style='color:#000'>" + "=" + Math.Round(TotalRequired, 2).ToString("0.####") + "</span>"
                                + "</br>" + " Cut Wastage Difference " + Math.Round(Convert.ToDecimal(TotalRequired), 2).ToString("0.####") + " - "
                                + Math.Round(Convert.ToDecimal(hdnfourpointpassqty.Value), 0).ToString("0.####") + "<span style='color:#FFFF00'>" + "=" + Math.Round(diff, 0).ToString("0.####") + "</span>";

                            //RajeevS tooltip reverse formula                         
                            spn_Rev.InnerHtml = "Reverse Calculation:" + ReverseFormula;
                            //RajeevS
                        }
                        else
                        {
                            lblrequiredqty.ToolTip = Formulae + " " + "<span style='color:#000'>" + "=" + Math.Round(TotalRequired, 2).ToString("0.####") + "</span>";
                            spn_Rev.InnerHtml = "Reverse Calculation:" + ReverseFormula;
                        }
                    }
                    else
                    {
                        lblrequiredqty.ToolTip = Formulae + " " + "<span style='color:#000'>" + "=" + Math.Round(TotalRequired, 2).ToString("0.####") + "</span>";
                        spn_Rev.InnerHtml = "Reverse Calculation:" + "</br> " + ReverseFormula;
                    }
                    lblrequiredqty.Attributes.Add("class", "tooltip");
                    hdnrequiredqtywithoutround.Value = TotalRequired.ToString();
                }
                if (txtshrinkage1.Text != "" && txtshrinkage1.Text != "0")
                {
                    if (s1re > 0)
                        lblshrinkage1.Text = Math.Round(s1re, 0).ToString("N0");
                }
                if (txtwastage1.Text != "" && txtwastage1.Text != "0")
                {
                    if (s1re > 0)
                        lblwastage1.Text = Math.Round(s1re, 0).ToString("N0");
                }

                if (txtshrinkage2.Text != "" && (txtshrinkage2.Text != "0"))
                {
                    if (s2re > 0)
                        lblshrinkage2.Text = Math.Round(s2re, 0).ToString("N0");
                }
                if (txtwastage2.Text != "" && txtwastage2.Text != "0")
                {
                    if (s2re > 0)
                        lblwastage2.Text = Math.Round(s2re, 0).ToString("N0");
                }
                if (txtshrinkage3.Text != "" && txtshrinkage3.Text != "0")
                {
                    if (s3re > 0)
                        lblshrinkage3.Text = Math.Round(s3re, 0).ToString("N0");
                }
                if (txtwastage3.Text != "" && txtwastage3.Text != "0")
                {
                    if (s3re > 0)
                        lblwastage3.Text = Math.Round(s3re, 0).ToString("N0");
                }

                if (txtshrinkage4.Text != "" && txtshrinkage4.Text != "0")
                {
                    if (s4re > 0)
                        lblshrinkage4.Text = Math.Round(s4re, 0).ToString("N0");
                }
                if (txtwastage4.Text != "" && txtwastage4.Text != "0")
                {
                    if (s4re > 0)
                        lblwastage4.Text = Math.Round(s4re, 0).ToString("N0");
                }
                //lblshrinkage2.Text = Math.Round(s2re, 0).ToString() ;
                //lblwastage2.Text = Math.Round(s2re, 0).ToString() ;

                //lblshrinkage3.Text = Math.Round(s3re, 0).ToString() ;
                //lblwastage3.Text = Math.Round(s3re, 0).ToString() ;

                //lblshrinkage4.Text = Math.Round(s4re, 0).ToString() ;
                //lblwastage4.Text = Math.Round(s4re, 0).ToString() ;
                string str_r = "Residual Shrinkage not available";
                string str_g = "Greige Shrinkage not available";
                if (txtshrinkage1.Text != "" && txtshrinkage1.Text != "0")
                {
                    if (Convert.ToDecimal(txtshrinkage1.Text) <= 0)
                    {
                        txtshrinkage1.Text = "";
                        txtshrinkage1.ToolTip = str_r;

                    }
                }
                if (txtwastage1.Text != "" && txtwastage1.Text != "0")
                {
                    if (Convert.ToDecimal(txtwastage1.Text) <= 0)
                    {
                        txtwastage1.Text = "";
                        txtwastage1.ToolTip = str_g;


                    }
                }
                if (txtshrinkage2.Text != "" && txtshrinkage2.Text != "0")
                {
                    if (Convert.ToDecimal(txtshrinkage2.Text) <= 0)
                    {
                        txtshrinkage2.Text = "";
                        txtshrinkage2.ToolTip = str_r;

                    }
                }
                if (txtwastage2.Text != "" && txtwastage2.Text != "0")
                {
                    if (Convert.ToDecimal(txtwastage2.Text) <= 0)
                    {
                        txtwastage2.Text = "";
                        e.Row.Cells[6].ToolTip = str_g;
                        e.Row.Cells[6].Attributes.Add("class", "tooltip");
                    }
                }
                if (txtshrinkage3.Text != "" && txtshrinkage3.Text != "0")
                {
                    if (Convert.ToDecimal(txtshrinkage3.Text) <= 0)
                    {
                        txtshrinkage3.Text = "";
                        txtshrinkage3.ToolTip = str_r;

                    }
                }
                if (txtwastage3.Text != "" && txtwastage3.Text != "0")
                {
                    if (Convert.ToDecimal(txtwastage3.Text) <= 0)
                    {
                        txtwastage3.Text = "";
                        txtwastage3.ToolTip = str_g;

                    }
                }
                if (txtshrinkage4.Text != "" && txtshrinkage4.Text != "0")
                {
                    if (Convert.ToDecimal(txtshrinkage4.Text) <= 0)
                    {
                        txtshrinkage4.Text = "";
                        txtshrinkage4.ToolTip = str_r;

                    }
                }
                if (txtwastage4.Text != "" && txtwastage4.Text != "0")
                {
                    if (Convert.ToDecimal(txtwastage4.Text) <= 0)
                    {
                        txtwastage4.Text = "";
                        txtwastage4.ToolTip = str_g;

                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {


                //Label lblfoterquantitytotal = (Label)e.Row.FindControl("lblfoterquantitytotal");
                //Label lblfoterunit = (Label)e.Row.FindControl("lblfoterunit");
                //Label lblfotertotalshrinkage1 = (Label)e.Row.FindControl("lblfotertotalshrinkage1");
                //Label lblfotertotalshrinkage2 = (Label)e.Row.FindControl("lblfotertotalshrinkage2");
                //Label lblfotertotalshrinkage3 = (Label)e.Row.FindControl("lblfotertotalshrinkage3");
                //Label lblfotertotalshrinkage4 = (Label)e.Row.FindControl("lblfotertotalshrinkage4");

                //Label lblfotertotalwastage1 = (Label)e.Row.FindControl("lblfotertotalwastage1");
                //Label lblfotertotalwastage2 = (Label)e.Row.FindControl("lblfotertotalwastage2");
                //Label lblfotertotalwastage3 = (Label)e.Row.FindControl("lblfotertotalwastage3");
                //Label lblfotertotalwastage4 = (Label)e.Row.FindControl("lblfotertotalwastage4");

                //lblfoterquantitytotal.Text = QuanitytSum.ToString("N0");
                //lblfoterunit.Text = Enum.GetName(typeof(FabricUnit), Unitid);

                //lblfotertotalshrinkage1.Text = sh1fotersum ;
                //lblfotertotalshrinkage2.Text = sh2fotersum ;
                //lblfotertotalshrinkage3.Text = sh3fotersum ;
                //lblfotertotalshrinkage4.Text = sh4fotersum ;

                //lblfotertotalwastage1.Text = sh1fotersum ;
                //lblfotertotalwastage2.Text = sh2fotersum ;
                //lblfotertotalwastage3.Text = sh3fotersum ;
                //lblfotertotalwastage4.Text = sh4fotersum ;


            }
            #endregion DataRow

        }
        //RajeevS
        protected string GetDetailForCutWastage(int OrderDetaild)
        {

            return "";

        }

        //Below Code added By Girish on 2022-01-13 to Check All textBox Control and if it's value is "0" replace it with "" :Start
        protected void grdwastage_DataBound(object sender, EventArgs e)
        {
            GridView grid = (GridView)sender;

            foreach (GridViewRow row in grid.Rows)
            {
                foreach (Control ctrl in row.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox txt = (TextBox)ctrl;
                        if (txt.Text == "0")
                        {
                            txt.Text = "";
                        }
                    }
                    else if (ctrl.Controls.Count > 0) // check if the control has child controls
                    {
                        FindTextBoxes(ctrl); // call the function recursively
                    }
                }
            }
        }

        private void FindTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    if (txt.Text == "0")
                    {
                        txt.Text = "";
                    }
                }
                else if (ctrl.Controls.Count > 0)
                {
                    FindTextBoxes(ctrl);
                }
            }
        }
        //End


        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                Label lblstageName1 = (Label)row.FindControl("lblstageName1");
                Label lblstageName1new = (Label)previousRow.FindControl("lblstageName1");

                //Label lblstageName2 = (Label)row.FindControl("lblstageName2");
                //Label lblstageName2new = (Label)previousRow.FindControl("lblstageName2");

                //Label lblstageName3 = (Label)row.FindControl("lblstageName3");
                //Label lblstageName3new = (Label)previousRow.FindControl("lblstageName3");

                //Label lblstageName2 = (Label)row.FindControl("lblstageName2");
                //Label lblstageName2new = (Label)previousRow.FindControl("lblstageName2");


                if (lblstageName1.Text == lblstageName1new.Text)
                {
                    row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                    previousRow.Cells[4].Visible = false;
                }
            }
        }

        public void UpdateWastage(object sender)
        {
            int IsDelete = fabobj.UpdateFabricWastageShrinkageDetails("DELETE", "UPDATE", FabricQualityID, FabricDetails, -1, FabType, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1);
            foreach (GridViewRow row in grdwastage.Rows)
            {
                try
                {
                    decimal shk1 = 0, shk2 = 0, shk3 = 0, shk4 = 0, wastage1 = 0, wastage2 = 0, wastage3 = 0, wastage4 = 0;
                    decimal w1 = 0, w2 = 0, w3 = 0, w4 = 0;
                    decimal cutwastageInd = 0;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField hdnorderdetailsID = (HiddenField)row.FindControl("hdnorderdetailsID");
                        HiddenField hdnFabricQualiltyID = (HiddenField)row.FindControl("hdnFabricQualiltyID");
                        HiddenField hdnFabricdetails = (HiddenField)row.FindControl("hdnFabricdetails");
                        HiddenField hdnavg = (HiddenField)row.FindControl("hdnavg");
                        HiddenField hdnCutwastage = (HiddenField)row.FindControl("hdnCutwastge");

                        if (hdnorderdetailsID.Value != "")
                        {
                            TextBox txtshrinkage1 = (TextBox)row.FindControl("txtshrinkage1");
                            TextBox txtwastage1 = (TextBox)row.FindControl("txtwastage1");
                            TextBox txtshrinkage2 = (TextBox)row.FindControl("txtshrinkage2");
                            TextBox txtwastage2 = (TextBox)row.FindControl("txtwastage2");
                            TextBox txtshrinkage3 = (TextBox)row.FindControl("txtshrinkage3");
                            TextBox txtwastage3 = (TextBox)row.FindControl("txtwastage3");
                            TextBox txtshrinkage4 = (TextBox)row.FindControl("txtshrinkage4");
                            TextBox txtwastage4 = (TextBox)row.FindControl("txtwastage4");
                            //rajeevS
                            TextBox lblcutwastage = (TextBox)row.FindControl("lblcutwastage");
                            //rajeevS
                            if (lblcutwastage.Text == "")
                            {
                                lblcutwastage.Text = "0";
                            }
                            DataTable dt8 = fabobj.GetMaximumCutwastage();
                            string maxcut = dt8.Rows[0]["MaximumCutWastage"].ToString();
                            if (Convert.ToDecimal(lblcutwastage.Text) > Convert.ToDecimal(dt8.Rows[0]["MaximumCutWastage"]))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cut wastage cannot exceed " + maxcut + "%')", true);
                                lblcutwastage.Text = hdnCutwastage.Value;
                                return;
                            }
                            Label lblquantity = (Label)row.FindControl("lblquantity");

                            shk1 = (txtshrinkage1.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage1.Text));
                            shk2 = (txtshrinkage2.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage2.Text));
                            shk3 = (txtshrinkage3.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage3.Text));
                            shk4 = (txtshrinkage4.Text == "" ? 0 : Convert.ToDecimal(txtshrinkage4.Text));

                            wastage1 = (txtwastage1.Text == "" ? 0 : Convert.ToDecimal(txtwastage1.Text));
                            wastage2 = (txtwastage2.Text == "" ? 0 : Convert.ToDecimal(txtwastage2.Text));
                            wastage3 = (txtwastage3.Text == "" ? 0 : Convert.ToDecimal(txtwastage3.Text));
                            wastage4 = (txtwastage4.Text == "" ? 0 : Convert.ToDecimal(txtwastage4.Text));
                            if (shk1 > 0)
                            {
                                w1 = shk1;
                            }
                            else if (wastage1 > 0)
                            {
                                w1 = wastage1;
                            }
                            if (shk2 > 0)
                            {
                                w2 = shk2;
                            }
                            else if (wastage2 > 0)
                            {
                                w2 = wastage2;
                            }
                            if (shk3 > 0)
                            {
                                w3 = shk3;
                            }
                            else if (wastage3 > 0)
                            {
                                w3 = wastage3;
                            }
                            if (shk4 > 0)
                            {
                                w4 = shk4;
                            }
                            else if (wastage4 > 0)
                            {
                                w4 = wastage4;
                            }
                            decimal S1 = 0;
                            //decimal S2 = 0, S3 = 0, S4 = 0;

                            //S1 = (Convert.ToDecimal(lblquantity.Text.Replace(",", "")));
                            S1 = (Convert.ToDecimal(lblquantity.Text.Replace(",", "")) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w1);
                            S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w2);
                            S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w3);
                            S1 = (Convert.ToDecimal(S1) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w4);

                            Decimal RequiredConInd = Convert.ToDecimal(lblquantity.Text.Replace(",", ""));
                            if (string.IsNullOrEmpty(lblcutwastage.Text.ToString()))
                            {
                                cutwastageInd = cutwastage.ToString() == "" ? 0 : Convert.ToDecimal(cutwastage.ToString());
                            }
                            else
                            {
                                cutwastageInd = lblcutwastage.Text.ToString() == "" ? 0 : Convert.ToDecimal(lblcutwastage.Text.ToString());
                            }
                            //decimal cutwastageInd = lblcutwastage.Text.ToString() == "0" ? 0 : Convert.ToDecimal(lblcutwastage.Text.ToString()); //cutwastage.ToString() == "0" ? 0 : Convert.ToDecimal(cutwastage.ToString());
                            decimal s1reInd = 0;
                            decimal s2reInd = 0;
                            decimal s3reInd = 0;
                            decimal s4reInd = 0;
                            s1reInd = Convert.ToDecimal((RequiredConInd * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w1)) - (RequiredConInd);
                            s2reInd = Convert.ToDecimal((Convert.ToDecimal(s1reInd + RequiredConInd) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w2)) - (s1reInd + RequiredConInd);
                            s3reInd = Convert.ToDecimal((Convert.ToDecimal(s2reInd + s1reInd + RequiredConInd) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w3)) - (s2reInd + s1reInd + RequiredConInd);
                            s4reInd = Convert.ToDecimal((Convert.ToDecimal(s3reInd + s2reInd + s1reInd + RequiredConInd) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - w4)) - (s3reInd + s2reInd + s1reInd + RequiredConInd);

                            decimal withCutWastageInd = Convert.ToDecimal((Convert.ToDecimal(s1reInd + s2reInd + s3reInd + s4reInd + Convert.ToDecimal(lblquantity.Text.Replace(",", ""))) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - cutwastageInd)) - (s4reInd + s3reInd + s2reInd + s1reInd + Convert.ToDecimal(lblquantity.Text.Replace(",", "")));

                            decimal TotalwithCutWastageInd = s1reInd + s2reInd + s3reInd + s4reInd + withCutWastageInd + RequiredConInd;
                            //if (chkSugCutwastage.Checked)
                            //{
                            //    int IsSave = fabobj.UpdateFabricWastageShrinkageDetails("UPDATE", "UPDATE", Convert.ToInt32(hdnFabricQualiltyID.Value), FabricDetails, Convert.ToInt32(hdnorderdetailsID.Value), FabType, 0, wastage1, shk1, wastage2, shk2, wastage3, shk3, wastage4, shk4, Convert.ToDecimal(Math.Round(S1, 2)), cutwastageInd, TotalwithCutWastageInd, Convert.ToDecimal(hdnavg.Value), Convert.ToDecimal(lblSugCutwastage.Text));
                            //}
                            //else
                            //{
                            int IsSave = fabobj.UpdateFabricWastageShrinkageDetails("UPDATE", "UPDATE", Convert.ToInt32(hdnFabricQualiltyID.Value), FabricDetails, Convert.ToInt32(hdnorderdetailsID.Value), FabType, 0, wastage1, shk1, wastage2, shk2, wastage3, shk3, wastage4, shk4, Convert.ToDecimal(Math.Round(S1, 2)), cutwastageInd, TotalwithCutWastageInd, Convert.ToDecimal(hdnavg.Value), Convert.ToDecimal(lblcutwastage.Text));
                            //}

                        }

                    }
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //objTrans.Rollback();  
                    //ShowAlert(ex.Message);
                }
            }
            if (IsExecute == "YES")
            {
                QualityController Qcobj = new QualityController();
                //bool result = Qcobj.AutoAllocate_Fabric_From_Stock(OrderDetailsID, FabricQualityID, FabricDetails, FabType, stage2, stage3, stage4,Convert.ToBoolean(chkfi);
            }
            //Response.Write("<script> window.parent.Shadowbox.close();</script>");
            if (IsExecute == "YES")
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CloseCurrentTab();", true);
            }
            else if (IsExecute == "FABRICVIEW" && sender != null)
            {
                Button btnSender = (Button)sender;
                if (btnSender == btnSubmit)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
                }

            }
            else
            {
                // Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
            }

            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "callparentpage();", true);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            UpdateWastage(sender);
        }

        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

        public static Decimal ExtractDecimalFromString(string str)
        {
            string newstr = str;
            if (str != "")
            {
                newstr = str.Replace(",", "");
            }


            Regex digits = new Regex(@"(\d+(\.\d+)?)|(\.\d+)");
            Match mx = digits.Match(newstr);
            //Console.WriteLine("Input {0} - Digits {1} {2}", str, mx.Success, mx.Groups);

            return mx.Success ? Convert.ToDecimal(mx.Groups[1].Value) : 0;
        }

        public void Calculatefoter()
        {
            foreach (GridViewRow row in grdwastage.Rows)
            {
                #region Header
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnorderdetailsID = (HiddenField)row.FindControl("hdnorderdetailsID");
                    HiddenField hdnFabricQualiltyID = (HiddenField)row.FindControl("hdnFabricQualiltyID");
                    HiddenField hdnFabricdetails = (HiddenField)row.FindControl("hdnFabricdetails");

                    if (hdnorderdetailsID.Value != "")
                    {
                        TextBox txtshrinkage1 = (TextBox)row.FindControl("txtshrinkage1");
                        TextBox txtwastage1 = (TextBox)row.FindControl("txtwastage1");

                        TextBox txtshrinkage2 = (TextBox)row.FindControl("txtshrinkage2");
                        TextBox txtwastage2 = (TextBox)row.FindControl("txtwastage2");

                        TextBox txtshrinkage3 = (TextBox)row.FindControl("txtshrinkage3");
                        TextBox txtwastage3 = (TextBox)row.FindControl("txtwastage3");

                        TextBox txtshrinkage4 = (TextBox)row.FindControl("txtshrinkage4");
                        TextBox txtwastage4 = (TextBox)row.FindControl("txtwastage4");

                        Label lblquantity = (Label)row.FindControl("lblquantity");

                        Label lblshrinkage1 = (Label)row.FindControl("lblshrinkage1");
                        Label lblshrinkage2 = (Label)row.FindControl("lblshrinkage2");
                        Label lblshrinkage3 = (Label)row.FindControl("lblshrinkage3");
                        Label lblshrinkage4 = (Label)row.FindControl("lblshrinkage4");

                        TextBox lblcutwastage = (TextBox)row.FindControl("lblcutwastage");
                        //RajeevS 20022023
                        //DropDownList ddlcutwastage = (DropDownList)row.FindControl("ddlcutwastage");
                        //RajeevS20022023
                        Label lblwastage1 = (Label)row.FindControl("lblwastage1");
                        Label lblwastage2 = (Label)row.FindControl("lblwastage2");
                        Label lblwastage3 = (Label)row.FindControl("lblwastage3");
                        Label lblwastage4 = (Label)row.FindControl("lblwastage4");

                        Label lblrequiredqty = (Label)row.FindControl("lblrequiredqty");
                        Label lblvaluecutwastage = (Label)row.FindControl("lblvaluecutwastage");
                        HiddenField hdnrequiredqtywithoutround = (HiddenField)row.FindControl("hdnrequiredqtywithoutround");

                        QuanitytSum = QuanitytSum + Convert.ToInt32(lblquantity.Text.Replace(",", ""));
                        wastagefotersum = wastagefotersum + Convert.ToDecimal(ExtractDecimalFromString(lblvaluecutwastage.Text));
                        lblrequiredqty.Text = lblrequiredqty.Text == "" ? "0" : lblrequiredqty.Text;
                        //totalrequiredfotersum = totalrequiredfotersum + Convert.ToDecimal(lblrequiredqty.Text.Replace(",", ""));
                        totalrequiredfotersum = totalrequiredfotersum + Convert.ToDecimal(hdnrequiredqtywithoutround.Value.Replace(",", ""));

                        if (lblshrinkage1.Text != "")
                            sh1fotersum = sh1fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblshrinkage1.Text));

                        if (lblshrinkage2.Text != "")
                            sh2fotersum = sh2fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblshrinkage2.Text));

                        if (lblshrinkage3.Text != "")
                            sh3fotersum = sh3fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblshrinkage3.Text));

                        if (lblshrinkage4.Text != "")
                            sh4fotersum = sh4fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblshrinkage4.Text));


                        if (lblwastage1.Text != "")
                            g1fotersum = g1fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblwastage1.Text));

                        if (lblwastage2.Text != "")
                            g2fotersum = g2fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblwastage2.Text));

                        if (lblwastage3.Text != "")
                            g3fotersum = g3fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblwastage3.Text));

                        if (lblwastage4.Text != "")
                            g4fotersum = g4fotersum + Convert.ToDecimal(ExtractDecimalFromString(lblwastage4.Text));


                    }
                }
                #endregion Header
            }
            Label lblfoterquantitytotal = grdwastage.FooterRow.FindControl("lblfoterquantitytotal") as Label;
            //Label lblfoterunit = grdwastage.FooterRow.FindControl("lblfoterunit") as Label;

            Label lblfotertotalshrinkage1 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkage1") as Label;
            Label lblfotertotalshrinkage2 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkage2") as Label;
            Label lblfotertotalshrinkage3 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkage3") as Label;
            Label lblfotertotalshrinkage4 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkage4") as Label;

            Label lblfotertotalwastage1 = grdwastage.FooterRow.FindControl("lblfotertotalwastage1") as Label;
            Label lblfotertotalwastage2 = grdwastage.FooterRow.FindControl("lblfotertotalwastage2") as Label;
            Label lblfotertotalwastage3 = grdwastage.FooterRow.FindControl("lblfotertotalwastage3") as Label;
            Label lblfotertotalwastage4 = grdwastage.FooterRow.FindControl("lblfotertotalwastage4") as Label;


            Label lblfotertotalshrinkagevalue1 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkagevalue1") as Label;
            Label lblfotertotalshrinkagevalue2 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkagevalue2") as Label;
            Label lblfotertotalshrinkagevalue3 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkagevalue3") as Label;
            Label lblfotertotalshrinkagevalue4 = grdwastage.FooterRow.FindControl("lblfotertotalshrinkagevalue4") as Label;

            Label lblfotertotalwastagevalue1 = grdwastage.FooterRow.FindControl("lblfotertotalwastagevalue1") as Label;
            Label lblfotertotalwastagevalue2 = grdwastage.FooterRow.FindControl("lblfotertotalwastagevalue2") as Label;
            Label lblfotertotalwastagevalue3 = grdwastage.FooterRow.FindControl("lblfotertotalwastagevalue3") as Label;
            Label lblfotertotalwastagevalue4 = grdwastage.FooterRow.FindControl("lblfotertotalwastagevalue4") as Label;

            Label lblfotertotalcutwastage = grdwastage.FooterRow.FindControl("lblfotertotalcutwastage") as Label;
            Label lblfotertotalrequiredqty = grdwastage.FooterRow.FindControl("lblfotertotalrequiredqty") as Label;



            Label lblfotertotalcutwastagevalue = grdwastage.FooterRow.FindControl("lblfotertotalcutwastagevalue") as Label;
            Label lblcutwastage_footer_UnitName = grdwastage.FooterRow.FindControl("lblcutwastage_footer_UnitName") as Label;


            if (sh1fotersum > 0)
            {
                lblfotertotalshrinkage1.Text = Math.Round(sh1fotersum, 0).ToString("N0");
            }

            if (sh2fotersum > 0)
            {
                lblfotertotalshrinkage2.Text = Math.Round(sh2fotersum, 0).ToString("N0");
            }
            if (sh3fotersum > 0)
            {
                lblfotertotalshrinkage3.Text = Math.Round(sh3fotersum, 0).ToString("N0");
            }

            if (sh4fotersum > 0)
            {
                lblfotertotalshrinkage4.Text = Math.Round(sh4fotersum, 0).ToString("N0");
            }

            if (g1fotersum > 0)
            {
                lblfotertotalwastage1.Text = Math.Round(g1fotersum, 0).ToString("N0");
            }

            if (g2fotersum > 0)
            {
                lblfotertotalwastage2.Text = Math.Round(g2fotersum, 0).ToString("N0");
            }
            if (g3fotersum > 0)
            {
                lblfotertotalwastage3.Text = Math.Round(g3fotersum, 0).ToString("N0");
            }
            if (g4fotersum > 0)
            {
                lblfotertotalwastage4.Text = Math.Round(g4fotersum, 0).ToString("N0");
            }
            lblfoterquantitytotal.Text = QuanitytSum.ToString("N0");

            //lblfoterunit.Text = Enum.GetName(typeof(FabricUnit), Unitid);
            if (wastagefotersum > 0)
            {
                lblfotertotalcutwastage.Text = Math.Round(wastagefotersum, 0).ToString() + "";

            }
            else
            {
                lblcutwastage_footer_UnitName.Text = "";
            }

            if (totalrequiredfotersum > 0)
            {
                lblfotertotalrequiredqty.Text = Math.Round(totalrequiredfotersum, 2).ToString("N0");
            }
            decimal sh1 = 0;
            decimal gh1 = 0;

            decimal sh2 = 0;
            decimal gh2 = 0;

            decimal sh3 = 0;
            decimal gh3 = 0;

            decimal sh4 = 0;
            decimal gh4 = 0;

            decimal cutsh = 0;

            sh1 = (sh1fotersum * 100) / Convert.ToDecimal(QuanitytSum);
            gh1 = (g1fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum);


            sh2 = (sh2fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum);
            gh2 = (g2fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum);

            sh3 = (sh3fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum);
            gh3 = (g3fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum);

            sh4 = (sh4fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum);
            gh4 = (g4fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum + sh4fotersum);

            cutsh = (wastagefotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum + sh4fotersum + g4fotersum);

            //sh1 = ((sh1fotersum + g1fotersum) * 100) / Convert.ToDecimal(QuanitytSum);
            ////gh1 = (g1fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum);


            //sh2 = ((sh2fotersum + g2fotersum) * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum);
            ////gh2 = (g2fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum);

            //sh3 = ((sh3fotersum + g3fotersum) * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum);
            ////gh3 = (g3fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum);

            //sh4 = ((sh4fotersum + g4fotersum) * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum);
            ////gh4 = (g4fotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum + sh4fotersum);

            //cutsh = (wastagefotersum * 100) / (Convert.ToDecimal(QuanitytSum) + sh1fotersum + g1fotersum + sh2fotersum + g2fotersum + sh3fotersum + g3fotersum + sh4fotersum + g4fotersum);

            Label lblStage1_Shrinkage_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblStage1_Shrinkage_footer_UnitName");
            Label lblStage1_Shrinkage_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblStage1_Shrinkage_footer_Percent");
            if (sh1 > 0) lblfotertotalshrinkagevalue1.Text = Math.Round(sh1, 1).ToString("0.####");
            else { lblStage1_Shrinkage_footer_UnitName.Text = ""; lblStage1_Shrinkage_footer_Percent.Text = ""; }

            Label lblStage1_Wastage_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblStage1_Wastage_footer_UnitName");
            Label lblStage1_Wastage_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblStage1_Wastage_footer_Percent");
            if (gh1 > 0) lblfotertotalwastagevalue1.Text = Math.Round(gh1, 1).ToString("0.####");
            else { lblStage1_Wastage_footer_UnitName.Text = ""; lblStage1_Wastage_footer_Percent.Text = ""; }


            Label lblStage2_Shrinkage_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblStage2_Shrinkage_footer_UnitName");
            Label lblStage2_Shrinkage_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblStage2_Shrinkage_footer_Percent");
            if (sh2 > 0) lblfotertotalshrinkagevalue2.Text = Math.Round(sh2, 1).ToString("0.####");
            else { lblStage2_Shrinkage_footer_UnitName.Text = ""; lblStage2_Shrinkage_footer_Percent.Text = ""; }

            Label lblStage2_Wastage_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblStage2_Wastage_footer_UnitName");
            Label lblStage2_Wastage_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblStage2_Wastage_footer_Percent");
            if (gh2 > 0) lblfotertotalwastagevalue2.Text = Math.Round(gh2, 1).ToString("0.####");
            else { lblStage2_Wastage_footer_UnitName.Text = ""; lblStage2_Wastage_footer_Percent.Text = ""; }

            Label lblshrinkage3_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblshrinkage3_footer_UnitName");
            Label lblshrinkage3_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblshrinkage3_footer_Percent");
            if (sh3 > 0) lblfotertotalshrinkagevalue3.Text = Math.Round(sh3, 1).ToString("0.####");
            else { lblshrinkage3_footer_UnitName.Text = ""; lblshrinkage3_footer_Percent.Text = ""; }

            Label lblwastage3_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblwastage3_footer_UnitName");
            Label lblwastage3_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblwastage3_footer_Percent");
            if (gh3 > 0) lblfotertotalwastagevalue3.Text = Math.Round(gh3, 1).ToString("0.####");
            else { lblwastage3_footer_UnitName.Text = ""; lblwastage3_footer_Percent.Text = ""; }

            Label lblshrinkage4_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblshrinkage4_footer_UnitName");
            Label lblshrinkage4_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblshrinkage4_footer_Percent");
            if (sh4 > 0) lblfotertotalshrinkagevalue4.Text = Math.Round(sh4, 1).ToString("0.####");
            else { lblshrinkage4_footer_UnitName.Text = ""; lblshrinkage4_footer_Percent.Text = ""; }

            Label lblwastage4_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblwastage4_footer_UnitName");
            Label lblwastage4_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblwastage4_footer_Percent");
            if (gh4 > 0) lblfotertotalwastagevalue4.Text = Math.Round(gh4, 1).ToString("0.####");
            else { lblwastage4_footer_UnitName.Text = ""; lblwastage4_footer_Percent.Text = ""; }

            //Label lblcutwastage_footer_UnitName = (Label)grdwastage.FooterRow.FindControl("lblcutwastage_footer_UnitName");
            Label lblcutwastage_footer_Percent = (Label)grdwastage.FooterRow.FindControl("lblcutwastage_footer_Percent");

            if (cutsh > 0) lblfotertotalcutwastagevalue.Text = Math.Round(cutsh, 1).ToString("0.####");
            else { lblcutwastage_footer_UnitName.Text = ""; lblcutwastage_footer_Percent.Text = ""; }

            if (stCount_1 <= 0)
            {
                grdwastage.Columns[5].Visible = false;
            }
            try
            {
                //s1========================
                if (gtCount_1 <= 0)
                {
                    grdwastage.Columns[6].Visible = false;
                }
                if (stCount_2 <= 0)
                {
                    grdwastage.Columns[8].Visible = false;
                }


                //s2========================

                if (gtCount_2 <= 0)
                {
                    grdwastage.Columns[9].Visible = false;
                }
                if (stCount_2 <= 0)
                {
                    grdwastage.Columns[8].Visible = false;
                }
                if (gtCount_2 <= 0 && stCount_2 <= 0)
                {

                    grdwastage.Columns[7].Visible = false;

                }
                //s3========================

                if (stCount_3 <= 0)
                {
                    grdwastage.Columns[11].Visible = false;
                }
                if (gtCount_3 <= 0)
                {
                    grdwastage.Columns[12].Visible = false;
                }
                if (gtCount_3 <= 0 && stCount_3 <= 0)
                {
                    grdwastage.Columns[10].Visible = true;
                }

                //s4========================
                if (stCount_4 <= 0)
                {
                    grdwastage.Columns[14].Visible = false;
                }
                if (gtCount_4 <= 0)
                {
                    grdwastage.Columns[15].Visible = false;
                }
                if (gtCount_4 <= 0 && stCount_4 <= 0)
                {
                    grdwastage.Columns[13].Visible = false;
                }
            }
            catch (Exception ec)
            {


            }
            int toprowcol = 18;
            int stagecol_1 = 3, stagecol_2 = 3, stagecol_3 = 3, stagecol_4 = 3;

            int Rstagecol_1 = 1, Rstagecol_2 = 1, Rstagecol_3 = 1, Rstagecol_4 = 1;
            int Wstagecol_1 = 1, Wstagecol_2 = 1, Wstagecol_3 = 1, Wstagecol_4 = 1;

            int Rstagecol_1_W = 95, Rstagecol_2_W = 50, Rstagecol_3_W = 50, Rstagecol_4_W = 50;
            int Wstagecol_1_W = 95, Wstagecol_2_W = 50, Wstagecol_3_W = 50, Wstagecol_4_W = 50;

            int grdWidth = 145 + 80 + 80;
            //s1=========================================
            if (stCount_1 > 0 || gtCount_1 > 0)
            {

                grdWidth = grdWidth + 130;
            }
            if (stCount_1 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_1 = stagecol_1 - 1;
                Rstagecol_1 = Rstagecol_1 - 1;
                Rstagecol_1_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            if (gtCount_1 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_1 = stagecol_1 - 1;
                Wstagecol_1 = Wstagecol_1 - 1;
                Wstagecol_1_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }

            //s2=========================================
            if (stCount_2 > 0 || gtCount_2 > 0)
            {

                grdWidth = grdWidth + 130;
            }
            if (stCount_2 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_2 = stagecol_2 - 1;
                Rstagecol_2 = Rstagecol_2 - 1;
                Rstagecol_2_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            if (gtCount_2 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_2 = stagecol_2 - 1;
                Wstagecol_2 = Wstagecol_2 - 1;
                Wstagecol_2_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            //s3=========================================
            if (stCount_3 > 0 || gtCount_3 > 0)
            {

                grdWidth = grdWidth + 130;
            }
            if (stCount_3 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_3 = stagecol_3 - 1;
                Rstagecol_3 = Rstagecol_3 - 1;
                Rstagecol_3_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            if (gtCount_3 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_3 = stagecol_3 - 1;
                Wstagecol_3 = Wstagecol_3 - 1;
                Wstagecol_3_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            //s4=========================================
            if (stCount_4 > 0 || gtCount_4 > 0)
            {

                grdWidth = grdWidth + 130;
            }
            if (stCount_4 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_4 = stagecol_4 - 1;
                Rstagecol_4 = Rstagecol_4 - 1;
                Rstagecol_4_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            if (gtCount_4 <= 0)
            {
                toprowcol = toprowcol - 1;
                stagecol_4 = stagecol_4 - 1;
                Wstagecol_4 = Wstagecol_4 - 1;
                Wstagecol_4_W = 0;
            }
            else
            {
                grdWidth = grdWidth + 80;
            }
            hdndynamicwidht.Value = grdWidth.ToString();
            grdwastage.Attributes.Add("style", "width:" + grdWidth + "px" + "");

            StringBuilder bheader = new StringBuilder();
            bheader.Append("<table class='WastagePupopTable' border='0' colspan='0' cellpadding='0' style='width:" + grdWidth + "px" + "'>");


            bheader.Append("<tr>");
            bheader.Append("<th colspan='" + toprowcol + "' class='HeaderClass1' style='text-align: left;padding-left: 20%;box-sizing: border-box;'>Required Fabric Summary</th>");
            bheader.Append("</tr>");

            bheader.Append("<tr>");

            string CountAndConstructionText = "";
            CountAndConstructionText = (lblcountconstraction.Text == "" ? "" : (FabType == 1 ? "Griege C&C :" : "C&C :"));

            string lblgsmtext = "";
            lblgsmtext = (lblgsm.Text == "" ? "" : "GSM :");

            string widthtext = "";
            widthtext = (lblwidth.Text == "" ? "" : "Width :");

            string ColorText = "";
            ColorText = (lblcolor.Text == "" ? "" : "Color :");

            bheader.Append("<th colspan='" + toprowcol + "' style='text-align:left;padding-left:5px;' ><table style='width:100%;'><tr><td class='widthfirststagecss' style=''><span style='margin-right:4px;color:gray;'>Fabric Quality:</span><span class='ColorPrintFabQuality' style=''>" + lblFabricQuality.Text + "</span></td><td style=''><span style='margin-right:4px;color:gray;'>" + lblgsmtext + "</span><span style='color:black;'> " + lblgsm.Text + "</span></td><td style='text-align:center;'><span style='margin-right:4px;color:gray;'>" + CountAndConstructionText + "</span><span style='color:black;text-align:left;'> " + lblcountconstraction.Text + "</span>  </td><td style='text-align:center;'><span style='margin-right:4px;color:gray;'>" + widthtext + "</span><span style='color:black;'>" + lblwidth.Text + "</span></td><td style='text-align:center;'><span style='margin-right:4px;color:gray;'>" + ColorText + "</span><span style='color:black;text-align:left;'>" + lblcolor.Text + "</span></td><tr></table></th>");
            bheader.Append("</tr>");
            bheader.Append("<tr>");
            bheader.Append("<th rowspan='2' class='CutQtyWidth_Name'> Serial No. </th><th rowspan='2' class='CutQtyWidth_Name border-right_0'> Contract Qty</th><th rowspan='2' class='CutQtyWidth_Name2 border-right_0'><span style='position: relative;top: 5px;margin-right: 10px;font-size: 13px;'>*</span> Average = </th><th rowspan='2' class='CutQtyWidth_Name1'> Total Qty. </th>");
            bheader.Append("<th colspan='" + stagecol_1 + "'> Stage1</th>");
            if (Rstagecol_2 > 0 || Wstagecol_2 > 0)
            {
                bheader.Append("<th colspan='" + stagecol_2 + "'> Stage2</th>");
            }
            if (Rstagecol_3 > 0 || Wstagecol_3 > 0)
            {
                bheader.Append("<th colspan='" + stagecol_3 + "'> Stage3</th>");
            }
            if (Rstagecol_4 > 0 || Wstagecol_4 > 0)
            {
                bheader.Append("<th colspan='" + stagecol_4 + "'> Stage4</th>");
            }
            bheader.Append("<th rowspan='2' class='HeaderWastWidth_40'> Cut <br>Wastage</th>");
            bheader.Append("<th rowspan='2' class='HeaderQtyWidth_40'> Total Required Qty. </th>");
            bheader.Append("</tr>");
            bheader.Append("<tr>");
            bheader.Append("<th class='Width_Name'> Name</th>");
            if (Rstagecol_1 > 0)
            {
                bheader.Append("<th class='WastShrnkWidth_Name'>Residual<br> Shrinkage</th>");
            }
            if (Wstagecol_1 > 0)
            {
                bheader.Append("<th class='WastShrnkWidth_Name'>Greige<br> Shrinkage</th>");
            }
            if (Rstagecol_2 > 0 || Wstagecol_2 > 0)
            {
                bheader.Append("<th class='Width_Name'> Name</th>");

                if (Rstagecol_2 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Residual<br> Shrinkage</th>");
                }
                if (Wstagecol_2 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Wastage</th>");
                }
            }
            if (Rstagecol_3 > 0 || Wstagecol_3 > 0)
            {
                bheader.Append("<th class='Width_Name'> Name</th>");

                if (Rstagecol_3 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Residual<br> Shrinkage</th>");
                }
                if (Wstagecol_3 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Wastage</th>");
                }
            }
            if (Rstagecol_4 > 0 || Wstagecol_4 > 0)
            {
                bheader.Append("<th class='Width_Name'> Name</th>");

                if (Rstagecol_4 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Residual<br> Shrinkage</th>");
                }
                if (Wstagecol_4 > 0)
                {
                    bheader.Append("<th class='WastShrnkWidth_Name'>Wastage</th>");
                }
            }
            bheader.Append("</tr>");




            bheader.Append("</table>");

            divh.InnerHtml = bheader.ToString();
        }
    }
}