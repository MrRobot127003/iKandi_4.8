using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;
using iKandi.BLL;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricQuality_New : System.Web.UI.Page
    {
        FabricQualityController FabricQualityControllerInstance = new FabricQualityController();
        public bool bCount_Construction = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            BindControls();
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Onload", "load();", true);
        }
        private void BindControls()
        {
            if (!IsPostBack)
            {
                BindCategory(ddlCategory);
                BindUnit(null, DDlUnit);
                BIndGrid();
            }
            else
            {
                if (ViewState["FQMID"] != null)
                {
                    BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));
                }
            }
            if (ViewState["FQMID"] != null)
            {
                bCount_Construction = FabricQualityControllerInstance.GetIS_CANDC_VALUE(Convert.ToInt32(ViewState["FQMID"].ToString()));
            }

        }

        #region Bind DropdownList
        private void BindCategory(DropDownList ddlcategory)
        {
            DataTable dt = FabricQualityControllerInstance.GetCetegory().Tables[0];
            ddlcategory.DataSource = dt;
            ddlcategory.DataTextField = "Name";
            ddlcategory.DataValueField = "Id";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, new ListItem("All", "-1"));
        }

        private void BindUnit(DataTable dt, DropDownList ddlunit)
        {
            if (dt == null)
            {
                dt = FabricQualityControllerInstance.GetUnit().Tables[0];
            }
            ddlunit.DataSource = dt;
            ddlunit.DataTextField = "UnitName";
            ddlunit.DataValueField = "GroupUnitID";
            ddlunit.DataBind();
            ddlunit.Items.Insert(0, new ListItem("ALL", "-1"));
        }

        //private void BindUnit(DropDownList ddlunit)
        //{
        //    DataTable dt = FabricQualityControllerInstance.GetUnit().Tables[0];
        //    ddlunit.DataSource = dt;
        //    ddlunit.DataTextField = "UnitName";
        //    ddlunit.DataValueField = "GroupUnitID";
        //    ddlunit.DataBind();
        //    ddlunit.Items.Insert(0, new ListItem("All", "-1"));
        //}
        #endregion

        #region Bind Grid
        private void BIndGrid()
        {
            string SearchItem = "%" + txtSearch.Text.Trim() + "%";
            string CategoryID = ddlCategory.SelectedValue;
            string TradeName = "%" + txtTrade.Text.Trim() + "%";
            string UnitID = DDlUnit.SelectedValue;

            DataTable dt = FabricQualityControllerInstance.GetFabricsQualityMaster(SearchItem, CategoryID, TradeName, UnitID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gdvFQMaster.DataSource = dt;
                gdvFQMaster.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gdvFQMaster.DataSource = dt;
                gdvFQMaster.DataBind();
                int TotalColumn = gdvFQMaster.Rows[0].Cells.Count;

                gdvFQMaster.Rows[0].Cells[0].Text = "";
                gdvFQMaster.Rows[0].Cells[0].CssClass = "border_left_color RightNone";
                gdvFQMaster.Rows[0].Cells[1].Text = "";
                gdvFQMaster.Rows[0].Cells[1].Attributes.Add("class", "LeftRightNone");
                gdvFQMaster.Rows[0].Cells[2].Text = "<img src='../../images/sorry.png' alt='No record found' style='width:100px' >";//"No Record Found";
                gdvFQMaster.Rows[0].Cells[2].Attributes.Add("class", "LeftRightNone");
                gdvFQMaster.Rows[0].Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gdvFQMaster.Rows[0].Cells[3].Text = "";
                gdvFQMaster.Rows[0].Cells[3].Attributes.Add("class", "LeftRightNone");
                gdvFQMaster.Rows[0].Cells[4].Text = "";
                gdvFQMaster.Rows[0].Cells[4].Attributes.Add("class", "LeftRightNone");
                gdvFQMaster.Rows[0].Cells[5].Text = "";
                gdvFQMaster.Rows[0].Cells[5].Attributes.Add("class", "LeftRightNone");
                gdvFQMaster.Rows[0].Cells[6].Text = "";
                gdvFQMaster.Rows[0].Cells[6].CssClass = "imgWidth LeftRightNone";
                gdvFQMaster.Rows[0].Cells[7].Text = "";
                gdvFQMaster.Rows[0].Cells[7].CssClass = "border_right_color LeftNone";
                // gdvFQMaster.Rows[0].Cells[7].Attributes.Add("class", "LeftNone");
            }
            DropDownList ddlFooterGroup = (DropDownList)gdvFQMaster.FooterRow.FindControl("ddlFooterGroup");
            BindCategory(ddlFooterGroup);
        }
        private void BIndGreigeGrid()
        
        {

            int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
            DataTable dt = FabricQualityControllerInstance.GetGreigeDetails(FabricMaster_ID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                divGreige.Visible = true;
                grdGreigetoFinish.DataSource = dt;
                grdGreigetoFinish.DataBind();
            }
            else
            {
                divGreige.Visible = true;
                dt.Rows.Add(dt.NewRow());
                grdGreigetoFinish.DataSource = dt;
                grdGreigetoFinish.DataBind();
                int TotalColumn = grdGreigetoFinish.Rows[0].Cells.Count;
                
                grdGreigetoFinish.Rows[0].Visible = false;

                grdGreigetoFinish.Rows[0].Cells[0].Text = "";
                grdGreigetoFinish.Rows[0].Cells[1].Text = "";
                grdGreigetoFinish.Rows[0].Cells[2].Text = "";
                grdGreigetoFinish.Rows[0].Cells[3].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                grdGreigetoFinish.Rows[0].Cells[3].HorizontalAlign = HorizontalAlign.Center;
                grdGreigetoFinish.Rows[0].Cells[4].Text = "";
                grdGreigetoFinish.Rows[0].Cells[5].Text = "";
                grdGreigetoFinish.Rows[0].Cells[6].Text = "";
            }
        }
        private void BIndFinishGrid()
        {
            int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
            DataTable dt = FabricQualityControllerInstance.GetFinishDetails(FabricMaster_ID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                divFinish.Visible = true;
                grdFinish.DataSource = dt;
                grdFinish.DataBind();
            }
            else
            {
                divFinish.Visible = true;
                dt.Rows.Add(dt.NewRow());
                grdFinish.DataSource = dt;
                grdFinish.DataBind();
                int TotalColumn = grdFinish.Rows[0].Cells.Count;

                grdFinish.Rows[0].Cells[0].Text = "";
                grdFinish.Rows[0].Cells[1].Text = "";
                grdFinish.Rows[0].Cells[2].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                grdFinish.Rows[0].Cells[2].HorizontalAlign = HorizontalAlign.Center;
                grdFinish.Rows[0].Cells[3].Text = "";
                grdFinish.Rows[0].Cells[4].Text = "";
                grdFinish.Rows[0].Cells[5].Text = "";
            }
        }
        protected void BindFabricQualityHeader(int FabricMaster_ID)
        {
            double Greige_Sh = 0;
            double Res_Sh = 0;
            double DyedRate = 0;
            double PrintRate = 0;
            double DigitalRate = 0;
            DataTable dt3 = FabricQualityControllerInstance.GetCetegoryByID(FabricMaster_ID).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                //Greige_Sh = Convert.ToDouble(dt3.Rows[0]["Greige_Sh"].ToString());
                Greige_Sh = dt3.Rows[0]["Dyeing_Greige_Sh"] == DBNull.Value ? -1 : Convert.ToDouble(dt3.Rows[0]["Dyeing_Greige_Sh"].ToString());
                Res_Sh = dt3.Rows[0]["Res_Sh"] == DBNull.Value ? -1 : Convert.ToDouble(dt3.Rows[0]["Res_Sh"].ToString());
                //Res_Sh = Convert.ToDouble(dt3.Rows[0]["Res_Sh"]).ToString() == "" ? 0 : Convert.ToDouble(dt3.Rows[0]["Res_Sh"].ToString());
            }

            DataTable dt4 = FabricQualityControllerInstance.Get_GriegeRate_Value(FabricMaster_ID.ToString()).Tables[0];
            if (dt4.Rows.Count > 0)
            {
                DyedRate = Convert.ToDouble(dt4.Rows[0]["DyedRate"].ToString());
                PrintRate = Convert.ToDouble(dt4.Rows[0]["PrintRate"].ToString());
                DigitalRate = Convert.ToDouble(dt4.Rows[0]["DigitalRate"].ToString());
            }
            tablefirst.Visible = true;
            DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
            if (grdFQDetails.Columns.Count > 0)
            {
                grdFQDetails.Columns.Clear();
            }

            DataTable dtGreige = ds.Tables[0];
            DataTable dtFinish = ds.Tables[1];
            DataTable dtFQMaster = ds.Tables[2];
            string group = dtFQMaster.Rows[0]["GroupName"].ToString();
            string quality = dtFQMaster.Rows[0]["TradeName"].ToString();
            int Greige = dtGreige.Rows.Count;
            int Finish = dtFinish.Rows.Count;
            if (Greige == 0 && Finish == 0)
            {
                tablefirst.Width = "50%";
                thGreigeFinish.Width = "300px";
                thFinish.Width = "140px";
                FQHeader1.InnerHtml = "";
                grdFQDetails.DataSource = null;
                grdFQDetails.DataBind();
                return;
            }
            int COUNT = 1;
            int length = 259 + 60 + (240 * (Greige)) + 70;
            string str = "";
            str = "<table cellpadding='0' cellspacing='0' border='1' style='border-color: #8080805c;width:" + length + "px;'><tr><th style='width:128px;'><input type='text' readonly='readonly' value='" + group.Replace("'", "&#39;") + "' title='" + group.Replace("'", "&#39;") + "' style='width:90%;border-color: transparent;background: transparent;text-align: center;' /></th><th style='width:129px;'><input type='text' readonly='readonly' value='" + quality.Replace("'", "&#39;") + "' title='" + quality.Replace("'", "&#39;") + "' style='width:90%;border-color: transparent;background: transparent;text-align: center;' /></th>";
            str = str + "<th style='min-width:59px;' rowspan='3'>MOQ</th>";
            if (Greige > 0)
            {
                for (int i = 0; i < Greige; i++)
                {
                    str = str + "<th style='' colspan='4'> Gsm&nbsp;<strong><span style='color:blue !important;'>" + dtGreige.Rows[i]["GSM"].ToString() + "</span></strong>&nbsp;Cut. Width&nbsp;<strong><span style='color:blue !important;'>" + dtGreige.Rows[i]["CutWidth"].ToString() + "</span></strong>&nbsp;Cost. Width&nbsp;<strong><span style='color:blue !important;'>" + dtGreige.Rows[i]["CostWidth"].ToString() + "</span></strong>&nbsp;C&C&nbsp;<strong><span style='color:blue !important;'>" + dtGreige.Rows[i]["CountConstruction"].ToString() + "</span></strong>&nbsp;Griege Width&nbsp;<strong><span style='color:blue !important;'>" + dtGreige.Rows[i]["GriegeWidth"].ToString() + "</span></strong></th>";
                }
            }

            str = str + "<th style='width:70px;' rowspan='3'>Action</th></tr>";
            str = str + "<tr><th style='min-width:255px;' rowspan='2' colspan='2'>Supplier</th>";
            if (Greige > 0)
            {
                for (int i = 0; i < Greige; i++)
                {
                    str = str + "<th style='width:60px;'>Greige</th><th style='width:60px;'>Dyed</th><th style='width:60px;'>Screen Print</th><th style='width:60px;'>Digital Print</th>";
                }
            }
            str = str + "</tr><tr>";
            if (Greige > 0)
            {
                for (int i = 0; i < Greige; i++)
                {
                    double GreigeRate = Convert.ToDouble(dtGreige.Rows[i]["GreigeRate"].ToString());
                    double GreigeFinalRate = Convert.ToDouble(GreigeRate) + Convert.ToDouble(GreigeRate * Greige_Sh / 100);
                    double calc2 = (GreigeFinalRate + Convert.ToDouble(DyedRate)) * Convert.ToDouble(1 + (Convert.ToDouble(Res_Sh) / 100));
                    double calc3 = (GreigeFinalRate + Convert.ToDouble(PrintRate)) * Convert.ToDouble(1 + (Convert.ToDouble(Res_Sh) / 100));
                    double calc4 = (GreigeFinalRate + Convert.ToDouble(DigitalRate)) * Convert.ToDouble(1 + (Convert.ToDouble(Res_Sh) / 100));
                    string Calc2 = calc2 == 0 ? "" : Math.Round(calc2).ToString();
                    string Calc3 = calc3 == 0 ? "" : Math.Round(calc3).ToString();
                    string Calc4 = calc4 == 0 ? "" : Math.Round(calc4).ToString();
                    string greigeRate = GreigeRate == 0 ? "" : Math.Round(GreigeRate).ToString();
                    string DyedR="";
                    if (Calc2 != "") {
                        DyedR = "&#x20b9; " + Calc2;
                    }
                    string greigR = "";
                    if (greigeRate != "")
                    {
                        greigR = "&#x20b9; " + greigeRate;
                    }

                    string PrintR = "";
                    if (Calc3 != "")
                    {
                        PrintR = "&#x20b9; " + Calc3;
                    }
                    string DigitalR = "";
                    if (Calc4 != "")
                    {
                        DigitalR = "&#x20b9; " + Calc4;
                    }
                    ViewState["GreigeRate" + i] = GreigeRate;
                    ViewState["GreigeFinalRate" + i] = GreigeFinalRate;
                    ViewState["DyedRate" + i] = Math.Round(calc2);
                    ViewState["PrintRate" + i] = Math.Round(calc3);
                    ViewState["DigitalPrintRate" + i] = Math.Round(calc4);
                    str = str + "<th style='width:60px;color:green;'> " + greigR + "</th><th style='width:60px;color:green;'>" + DyedR + "</th><th style='width:60px;color:green;'> " + PrintR + "</th><th style='width:60px;color:green;'> " + DigitalR + "</th>";
                }
            }
            str = str + "</tr></table>";
            FQHeader1.InnerHtml = str;
            if (Greige == 0)
            {
                thGreigeFinish.Width = "50px";
            }
            else
            {
                thGreigeFinish.Width = (241 * Greige).ToString() + "px";
            }

            TemplateField Supplier = new TemplateField();
            Supplier.HeaderText = "Supplier";
            Supplier.ShowHeader = false;
            Supplier.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblSupplier", "lblSupplier");
            Supplier.EditItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "ddlSupplier", "ddlSupplier");
            Supplier.FooterTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "ddlFooterSupplier", "ddlFooterSupplier");
            grdFQDetails.Columns.Insert(0, Supplier);
            Supplier.HeaderStyle.CssClass = "FirstChild";
            Supplier.HeaderStyle.Width = 262;
            Supplier.HeaderStyle.CssClass = "minwidthsup";
            Supplier.ItemStyle.CssClass = "minwidthsup";
            Supplier.FooterStyle.CssClass = "minwidthsup";

            TemplateField GMoq = new TemplateField();
            GMoq.HeaderText = "MOQ";
            GMoq.ShowHeader = false;
            GMoq.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblGMoq", "lblGMoq");
            GMoq.EditItemTemplate = new iKandi.Common.GridViewTemplate("text", "txtGMoq", "txtGMoq");
            GMoq.FooterTemplate = new iKandi.Common.GridViewTemplate("text", "txtFooterGMoq", "txtFooterGMoq");
            GMoq.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GMoq.HeaderStyle.Font.Bold = false;
            grdFQDetails.Columns.Insert(1, GMoq);
            GMoq.HeaderStyle.CssClass = "moqwidth";
            GMoq.ItemStyle.CssClass = "moqwidth";
            GMoq.FooterStyle.CssClass = "moqwidth";

            if (Greige > 0)
            {
                for (int i = 0; i < Greige; i++)
                {

                    TemplateField Grate = new TemplateField();
                    Grate.HeaderText = "G. Rate.";
                    Grate.ShowHeader = false;
                    Grate.ItemTemplate = new iKandi.Common.GridViewTemplate("itemCheckboxhdn", "lblGrate" + i, "lblGrate" + i);
                    Grate.EditItemTemplate = new iKandi.Common.GridViewTemplate("itemCheckboxhdn", "chkGrate" + i, "chkGrate" + i);
                    Grate.FooterTemplate = new iKandi.Common.GridViewTemplate("itemCheckboxhdn", "chkFooterGrate" + i, "chkFooterGrate" + i);
                    Grate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    Grate.HeaderStyle.Font.Bold = false;
                    grdFQDetails.Columns.Insert(COUNT + 1, Grate);
                    Grate.HeaderStyle.CssClass = "moqwidth";
                    Grate.ItemStyle.CssClass = "moqwidth";
                    Grate.FooterStyle.CssClass = "moqwidth";

                    TemplateField GDyedRate = new TemplateField();
                    GDyedRate.HeaderText = "Dyed Rate";
                    GDyedRate.ShowHeader = false;
                    GDyedRate.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "lblGDyedRate" + i, "lblGDyedRate" + i);
                    GDyedRate.EditItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkGDyedRate" + i, "chkGDyedRate" + i);
                    GDyedRate.FooterTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkFooterGDyedRate" + i, "chkFooterGDyedRate" + i);
                    GDyedRate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    GDyedRate.HeaderStyle.Font.Bold = false;
                    grdFQDetails.Columns.Insert(COUNT + 2, GDyedRate);
                    GDyedRate.HeaderStyle.CssClass = "moqwidth";
                    GDyedRate.ItemStyle.CssClass = "moqwidth";
                    GDyedRate.FooterStyle.CssClass = "moqwidth";

                    TemplateField GPrintrate = new TemplateField();
                    GPrintrate.HeaderText = "Print Rate";
                    GPrintrate.ShowHeader = false;
                    GPrintrate.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "lblGPrintrate" + i, "lblGPrintrate" + i);
                    GPrintrate.EditItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkGPrintrate" + i, "chkGPrintrate" + i);
                    GPrintrate.FooterTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkFooterGPrintrate" + i, "chkFooterGPrintrate" + i);
                    GPrintrate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    GPrintrate.HeaderStyle.Font.Bold = false;
                    grdFQDetails.Columns.Insert(COUNT + 3, GPrintrate);
                    GPrintrate.HeaderStyle.CssClass = "moqwidth";
                    GPrintrate.ItemStyle.CssClass = "moqwidth";
                    GPrintrate.FooterStyle.CssClass = "moqwidth";

                    TemplateField GDigitalPrint = new TemplateField();
                    GDigitalPrint.HeaderText = "Digital Print Rate";
                    GDigitalPrint.ShowHeader = false;
                    GDigitalPrint.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "lblGDigitalPrint" + i, "lblGDigitalPrint" + i);
                    GDigitalPrint.EditItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkGDigitalPrint" + i, "chkGDigitalPrint" + i);
                    GDigitalPrint.FooterTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkFooterGDigitalPrint" + i, "chkFooterGDigitalPrint" + i);
                    GDigitalPrint.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    GDigitalPrint.HeaderStyle.Font.Bold = false;
                    grdFQDetails.Columns.Insert(COUNT + 4, GDigitalPrint);
                    GDigitalPrint.HeaderStyle.CssClass = "moqwidth";
                    GDigitalPrint.ItemStyle.CssClass = "moqwidth";
                    GDigitalPrint.FooterStyle.CssClass = "moqwidth";

                    COUNT = COUNT + 4;
                }
            }

            TemplateField Action = new TemplateField();
            Action.ShowHeader = false;
            Action.ItemTemplate = new iKandi.Common.GridViewTemplate("itemimgbutton", "imgEdit", "imgEdit");
            Action.EditItemTemplate = new iKandi.Common.GridViewTemplate("itemimgbutton", "imgUpdate", "imgUpdate");
            Action.FooterTemplate = new iKandi.Common.GridViewTemplate("imgbtn", "imgAddMore", "imgAddMore");
            Action.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            Action.HeaderStyle.Font.Bold = false;
            Action.HeaderStyle.CssClass = "tablegrid";
            grdFQDetails.Columns.Insert(COUNT + 1, Action);
            Action.HeaderStyle.Width = 70;
            Action.ItemStyle.Width = 71;
            Action.FooterStyle.Width = 71;

            DataTable dt = FabricQualityControllerInstance.GetFQDetails(FabricMaster_ID).Tables[0];

            if (dt.Rows.Count > 0)
            {

                grdFQDetails.Width = length;
                grdFQDetails.DataSource = dt;
                grdFQDetails.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                grdFQDetails.Width = length;
                grdFQDetails.DataSource = dt;
                grdFQDetails.DataBind();
                grdFQDetails.Rows[0].Cells.Clear();
            }
            tablefirst.Width = (length).ToString() + "px";
        }
        #endregion

        #region Fabric Quality Master Grid Event
        protected void gdvFQMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FabricQuality FQM = new FabricQuality();
            if (e.CommandName.Equals("Insert"))
            {
                gdvFQMaster.EditIndex = -1;
                DropDownList ddlFooterGroup = (DropDownList)gdvFQMaster.FooterRow.FindControl("ddlFooterGroup");
                HiddenField hdnUnitIdFooter = (HiddenField)gdvFQMaster.FooterRow.FindControl("hdnUnitIdFooter");
                TextBox txtFooterTradeName = (TextBox)gdvFQMaster.FooterRow.FindControl("txtFooterTradeName");
                TextBox txtFooterDyeingGreigeSh = (TextBox)gdvFQMaster.FooterRow.FindControl("txtFooterDyeingGreigeSh");
                TextBox txtFooterPrintingGreigeSh = (TextBox)gdvFQMaster.FooterRow.FindControl("txtFooterPrintingGreigeSh");
                TextBox txtFooterResSh = (TextBox)gdvFQMaster.FooterRow.FindControl("txtFooterResSh");
                FQM.FQMasterID = "0";
                FQM.CategoryId = Convert.ToInt32(ddlFooterGroup.SelectedValue);
                FQM.TradeName = txtFooterTradeName.Text.Trim();
                FQM.StockUnit = Convert.ToInt32(hdnUnitIdFooter.Value);
                FQM.Dyeing_Greige_Sh = txtFooterDyeingGreigeSh.Text == "" ? 0 : Convert.ToInt32(txtFooterDyeingGreigeSh.Text.Trim());
                FQM.Printing_Greige_Sh = txtFooterPrintingGreigeSh.Text == "" ? 0 : Convert.ToInt32(txtFooterPrintingGreigeSh.Text.Trim());
                FQM.Res_Sh = txtFooterResSh.Text == "" ? 0 : Convert.ToInt32(txtFooterResSh.Text.Trim());

                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.FabricQualityControllerInstance.FabricQualityMaster_InstUpdt(FQM, UserId) > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                    BIndGrid();
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                    else
                        script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                }
            }
            if (e.CommandName == "Select")
            {
                gdvFQMaster.EditIndex = -1;
                BIndGrid();

                GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowindex = rowSelect.RowIndex;

                Label lblUnit1 = (Label)gdvFQMaster.Rows[rowindex].FindControl("lblUnit");
                lblUnit1.Font.Bold = true;
                lblUnit1.Attributes.Add("style", "font-size:13px");
                string FQMID = gdvFQMaster.DataKeys[rowindex]["FabricMaster_ID"].ToString();
                ViewState["FQMID"] = FQMID;

                grdFQDetails.EditIndex = -1;
                grdFQDetails.DataSource = null;
                grdFQDetails.DataBind();

                grdGreigetoFinish.EditIndex = -1;
                divGreige.Visible = false;
                grdGreigetoFinish.DataSource = null;
                grdGreigetoFinish.DataBind();

                grdFinish.EditIndex = -1;
                divFinish.Visible = false;
                grdFinish.DataSource = null;
                grdFinish.DataBind();

                BindFabricQualityHeader(Convert.ToInt32(FQMID));
            }
        }

        protected void gdvFQMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvFQMaster.EditIndex = -1;
            gdvFQMaster.SelectedIndex = -1;
            gdvFQMaster.PageIndex = e.NewPageIndex;
            BIndGrid();

            tablefirst.Visible = false;
            FQHeader1.InnerHtml = "";
            ViewState["FQMID"] = null;
            grdFQDetails.DataSource = null;
            grdFQDetails.DataBind();
        }

        protected void gdvFQMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvFQMaster.EditIndex = e.NewEditIndex;
            BIndGrid();
            TextBox txtTradeName = (TextBox)gdvFQMaster.Rows[e.NewEditIndex].FindControl("txtTradeName");
            DropDownList ddlGroup = (DropDownList)gdvFQMaster.Rows[e.NewEditIndex].FindControl("ddlGroup");
            Label lblUnitEdit = (Label)gdvFQMaster.Rows[e.NewEditIndex].FindControl("lblUnitEdit");
            HiddenField hdnUnitIdEdit = (HiddenField)gdvFQMaster.Rows[e.NewEditIndex].FindControl("hdnUnitIdEdit");
            var FabricMaster_ID = gdvFQMaster.DataKeys[e.NewEditIndex]["FabricMaster_ID"].ToString();
            DataTable dt = this.FabricQualityControllerInstance.FabricQualityMastEdt(FabricMaster_ID.ToString());
            if (dt.Rows.Count > 0)
            {
                BindCategory(ddlGroup);
                ddlGroup.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                txtTradeName.Text = dt.Rows[0]["TradeName"].ToString();
                hdnUnitIdEdit.Value = dt.Rows[0]["Unit"].ToString();
                lblUnitEdit.Text = dt.Rows[0]["UnitName"].ToString();
            }
            gdvFQMaster.SelectedIndex = -1;
            tablefirst.Visible = false;
            FQHeader1.InnerHtml = "";
            ViewState["FQMID"] = null;
            grdFQDetails.DataSource = null;
            grdFQDetails.DataBind();
        }

        protected void gdvFQMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvFQMaster.EditIndex = -1;
            BIndGrid();
        }

        protected void gdvFQMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (!Page.IsValid)
                return;
            FabricQuality FQM = new FabricQuality();
            var FabricMaster_ID = gdvFQMaster.DataKeys[e.RowIndex]["FabricMaster_ID"].ToString();
            TextBox txtTradeName = (TextBox)gdvFQMaster.Rows[e.RowIndex].FindControl("txtTradeName");
            DropDownList ddlGroup = (DropDownList)gdvFQMaster.Rows[e.RowIndex].FindControl("ddlGroup");
            TextBox txtDyeingGreigeSh = (TextBox)gdvFQMaster.Rows[e.RowIndex].FindControl("txtDyeingGreigeSh");
            TextBox txtPrintingGreigeSh = (TextBox)gdvFQMaster.Rows[e.RowIndex].FindControl("txtPrintingGreigeSh");
            TextBox txtResSh = (TextBox)gdvFQMaster.Rows[e.RowIndex].FindControl("txtResSh");
            HiddenField hdnUnitIdEdit = (HiddenField)gdvFQMaster.Rows[e.RowIndex].FindControl("hdnUnitIdEdit");

            FQM.FQMasterID = FabricMaster_ID;
            FQM.CategoryId = Convert.ToInt32(ddlGroup.SelectedValue);
            FQM.TradeName = txtTradeName.Text.Trim();
            FQM.StockUnit = Convert.ToInt32(hdnUnitIdEdit.Value);
            FQM.Dyeing_Greige_Sh = txtDyeingGreigeSh.Text == "" ? 0 : Convert.ToInt32(txtDyeingGreigeSh.Text.Trim());
            FQM.Printing_Greige_Sh = txtPrintingGreigeSh.Text == "" ? 0 : Convert.ToInt32(txtPrintingGreigeSh.Text.Trim());
            FQM.Res_Sh = txtResSh.Text == "" ? 0 : Convert.ToInt32(txtResSh.Text.Trim());

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.FabricQualityMaster_InstUpdt(FQM, UserId) > 0)
                {
                    gdvFQMaster.EditIndex = -1;
                    BIndGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                else
                    script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
            }
        }
        #endregion

        #region DropDownList Event
        //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = this.FabricQualityControllerInstance.UnitMastEdt(ddlCategory.SelectedValue.ToString());
        //    BindUnit(dt, DDlUnit);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    BindUnit(DDlUnit);
        //    //    DDlUnit.SelectedValue = dt.Rows[0]["Unit"].ToString();
        //    //}
        //}
        //protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //    DropDownList ddlGroup = (DropDownList)gvr.FindControl("ddlGroup");
        //    DropDownList ddlUnit = (DropDownList)gvr.FindControl("ddlUnit");
        //    DataTable dt = this.FabricQualityControllerInstance.UnitMastEdt(ddlGroup.SelectedValue.ToString());
        //    BindUnit(dt, ddlUnit);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    BindUnit(ddlUnit);
        //    //    ddlUnit.SelectedValue = dt.Rows[0]["Unit"].ToString();
        //    //}
        //}
        protected void ddlFooterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList ddlFooterGroup = (DropDownList)gvr.FindControl("ddlFooterGroup");
            //DropDownList ddlFooterUnit = (DropDownList)gvr.FindControl("ddlFooterUnit");
            Label lblUnitFooter = (Label)gvr.FindControl("lblUnitFooter");
            HiddenField hdnUnitIdFooter = (HiddenField)gvr.FindControl("hdnUnitIdFooter");
            if (ddlFooterGroup.SelectedValue != "-1")
            {
                DataTable dt = this.FabricQualityControllerInstance.UnitMastEdt(ddlFooterGroup.SelectedValue.ToString());
                lblUnitFooter.Text = dt.Rows[0]["UnitName"].ToString();
                hdnUnitIdFooter.Value = dt.Rows[0]["GroupUnitID"].ToString();
            }
            else
            {
                lblUnitFooter.Text = "";
                hdnUnitIdFooter.Value = "-1";
            }

            //BindUnit(dt,ddlFooterUnit);
            //if (dt.Rows.Count > 0)
            //{
            //    BindUnit(ddlFooterUnit);
            //    //ddlFooterUnit.SelectedValue = dt.Rows[0]["Unit"].ToString();
            //}
        }
        #endregion

        #region Greige To Finish Grid Event
        protected void grdGreigetoFinish_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Fabric_Quality_DetailsID = grdGreigetoFinish.DataKeys[e.RowIndex]["Fabric_Quality_DetailsID"].ToString();
            //var script_success = "ShowHideMessageBox(true, '" + "Information delete successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.GreigetoFinish_Delete(Convert.ToInt32(Fabric_Quality_DetailsID)) > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndGreigeGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void grdGreigetoFinish_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdGreigetoFinish.EditIndex = e.NewEditIndex;
            BIndGreigeGrid();

        }

        protected void grdGreigetoFinish_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (!Page.IsValid)
                return;
            var Fabric_Quality_DetailsID = grdGreigetoFinish.DataKeys[e.RowIndex]["Fabric_Quality_DetailsID"].ToString();
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            int FabricMaster_Id = Convert.ToInt32(ViewState["FQMID"].ToString());
            TextBox txtGRate = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtGRate");
            TextBox txtCutWidth = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtCutWidth");
            TextBox txtCosWidth = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtCosWidth");
            TextBox txtGriegeWidth = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtGriegeWidth");
            TextBox txtGSM = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtGSM");
            TextBox txtCC = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtCC");
            TextBox txtGreigeCC = (TextBox)grdGreigetoFinish.Rows[e.RowIndex].FindControl("txtgreigeCC");
            HiddenField hdnOptionNo = (HiddenField)grdGreigetoFinish.Rows[e.RowIndex].FindControl("hdnOptionNo");

            //added by raghvinder on 21-09-2020 start
            HiddenField hdnCandCFooter = (HiddenField)grdGreigetoFinish.Rows[e.RowIndex].FindControl("hdnCandCFooter");
            RequiredFieldValidator rfvCC = (RequiredFieldValidator)grdGreigetoFinish.Rows[e.RowIndex].FindControl("rfvCC");
            rfvCC.Enabled = bCount_Construction;
            //added by shubhendu 16-02-2022
            RequiredFieldValidator rfvGreigeCC = (RequiredFieldValidator)grdGreigetoFinish.Rows[e.RowIndex].FindControl("rfvGreigeCC");
            rfvGreigeCC.Enabled = bCount_Construction;
            //added by raghvinder on 21-09-2020 end

            int OptionNo = hdnOptionNo.Value == "" ? 0 : Convert.ToInt32(hdnOptionNo.Value);

            //var script_success = "ShowHideMessageBox(true, '" + "Information update successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.GreigetoFinish_InstUpdt(Convert.ToInt32(Fabric_Quality_DetailsID), FabricMaster_Id, Convert.ToDouble(txtGRate.Text.Trim()), Convert.ToDouble(txtCutWidth.Text.Trim()), Convert.ToDouble(txtCosWidth.Text.Trim()), txtGSM.Text.Trim(), txtCC.Text.Trim(), OptionNo, CreatedBy, Convert.ToDouble(txtGriegeWidth.Text.Trim()), txtGreigeCC.Text.Trim()) > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    grdGreigetoFinish.EditIndex = -1;
                    BIndGreigeGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                else
                    script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
            }
        }

        protected void grdGreigetoFinish_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdGreigetoFinish.EditIndex = -1;
            BIndGreigeGrid();
        }

        protected void grdGreigetoFinish_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                grdGreigetoFinish.EditIndex = -1;
                var Fabric_Quality_DetailsID = 0;
                int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
                int FabricMaster_Id = Convert.ToInt32(ViewState["FQMID"].ToString());
                TextBox txtGRate = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterGRate");
                TextBox txtCutWidth = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterCutWidth");
                TextBox txtCosWidth = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterCostWidth");
                TextBox txtGriegeWidth = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterGriegeWidth");
                TextBox txtGSM = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterGSM");
                TextBox txtCC = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterCC");
                TextBox txtFooterGreigeCC = (TextBox)grdGreigetoFinish.FooterRow.FindControl("txtFooterGreigeCC");
                txtGRate.Text = "0";
                int OptionNo = 0;
                var script_success = "ShowHideMessageBox(true, '" + "Saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.FabricQualityControllerInstance.GreigetoFinish_InstUpdt(Convert.ToInt32(Fabric_Quality_DetailsID), FabricMaster_Id, Convert.ToDouble(txtGRate.Text.Trim()), Convert.ToDouble(txtCutWidth.Text.Trim()), Convert.ToDouble(txtCosWidth.Text.Trim()), txtGSM.Text.Trim(), txtCC.Text.Trim(), OptionNo, CreatedBy, Convert.ToDouble(txtGriegeWidth.Text.Trim()), txtFooterGreigeCC.Text.Trim()) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                        BIndGreigeGrid();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        //script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                        script_fail2 = "ShowHideValidationBox(true, 'Record already exists.', 'Costing Sheet');";

                    else
                        script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                    return;
                }
            }
        }
        #endregion

        #region Finish Grid Event
        protected void grdFinish_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Fabric_Quality_DetailsID = grdFinish.DataKeys[e.RowIndex]["Fabric_Quality_DetailsID"].ToString();
            var script_success = "ShowHideMessageBox(true, '" + "Delete successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.GreigetoFinish_Delete(Convert.ToInt32(Fabric_Quality_DetailsID)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndFinishGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void grdFinish_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdFinish.EditIndex = e.NewEditIndex;
            BIndFinishGrid();
        }

        protected void grdFinish_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (!Page.IsValid)
                return;
            var Fabric_Quality_DetailsID = grdFinish.DataKeys[e.RowIndex]["Fabric_Quality_DetailsID"].ToString();
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            int FabricMaster_Id = Convert.ToInt32(ViewState["FQMID"].ToString());
            TextBox txtCutWidth = (TextBox)grdFinish.Rows[e.RowIndex].FindControl("txtCutWidth");
            TextBox txtCosWidth = (TextBox)grdFinish.Rows[e.RowIndex].FindControl("txtCosWidth");
            TextBox txtGSM = (TextBox)grdFinish.Rows[e.RowIndex].FindControl("txtGSM");
            TextBox txtCC = (TextBox)grdFinish.Rows[e.RowIndex].FindControl("txtCC");
            TextBox txtGreigeCC = (TextBox)grdFinish.Rows[e.RowIndex].FindControl("txtgreigeCC");

            var script_success = "ShowHideMessageBox(true, '" + "Update successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.Finish_InstUpdt(Convert.ToInt32(Fabric_Quality_DetailsID), FabricMaster_Id, 0, Convert.ToDouble(txtCutWidth.Text.Trim()), Convert.ToDouble(txtCosWidth.Text.Trim()), txtGSM.Text.Trim(), txtCC.Text.Trim(), CreatedBy) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    grdFinish.EditIndex = -1;
                    BIndFinishGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                else
                    script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
            }
        }

        protected void grdFinish_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdFinish.EditIndex = -1;
            BIndFinishGrid();
        }

        protected void grdFinish_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                grdFinish.EditIndex = -1;
                var Fabric_Quality_DetailsID = 0;
                int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
                int FabricMaster_Id = Convert.ToInt32(ViewState["FQMID"].ToString());
                TextBox txtCutWidth = (TextBox)grdFinish.FooterRow.FindControl("txtFooterCutWidth");
                TextBox txtCosWidth = (TextBox)grdFinish.FooterRow.FindControl("txtFooterCostWidth");
                TextBox txtGSM = (TextBox)grdFinish.FooterRow.FindControl("txtFooterGSM");
                TextBox txtCC = (TextBox)grdFinish.FooterRow.FindControl("txtFooterCC");

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.FabricQualityControllerInstance.Finish_InstUpdt(Convert.ToInt32(Fabric_Quality_DetailsID), FabricMaster_Id, 0, Convert.ToDouble(txtCutWidth.Text.Trim()), Convert.ToDouble(txtCosWidth.Text.Trim()), txtGSM.Text.Trim(), txtCC.Text.Trim(), CreatedBy) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                        BIndFinishGrid();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                    else
                        script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                }
            }
        }
        #endregion

        #region Control Event
        protected void lkbGo_Click(object sender, EventArgs e)
        {
            gdvFQMaster.SelectedIndex = -1;
            gdvFQMaster.EditIndex = -1;
            tablefirst.Visible = false;
            FQHeader1.InnerHtml = "";
            ViewState["FQMID"] = null;
            BIndGrid();
            grdFQDetails.DataSource = null;
            grdFQDetails.DataBind();

            divGreige.Visible = false;
            grdGreigetoFinish.DataSource = null;
            grdGreigetoFinish.DataBind();

            divFinish.Visible = false;
            grdFinish.DataSource = null;
            grdFinish.DataBind();
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));

            divFinish.Visible = false;
            grdFinish.DataSource = null;
            grdFinish.DataBind();

            divGreige.Visible = false;
            grdGreigetoFinish.DataSource = null;
            grdGreigetoFinish.DataBind();
        }
        protected void btnreturnF_Click(object sender, EventArgs e)
        {
            BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));

            divFinish.Visible = false;
            grdFinish.DataSource = null;
            grdFinish.DataBind();

            divGreige.Visible = false;
            grdGreigetoFinish.DataSource = null;
            grdGreigetoFinish.DataBind();
        }
        protected void ImgGreige_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["FQMID"] == null)
            {
                var script_success = "ShowHideMessageBox(true, '" + "Please select any row from first Grid." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                return;
            }
            BIndGreigeGrid();
            divFinish.Visible = false;
            grdFinish.DataSource = null;
            grdFinish.DataBind();
            hdnGreigeFinish.Value = "1";
            hdnFinish.Value = "0";
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showpopup", "showpopup('" + divGreige.ID + "')", true);
        }
        protected void ImgFinish_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["FQMID"] == null)
            {
                var script_success = "ShowHideMessageBox(true, '" + "Please select any row from first Grid." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                return;
            }
            BIndFinishGrid();
            divGreige.Visible = false;
            grdGreigetoFinish.DataSource = null;
            grdGreigetoFinish.DataBind();
            hdnGreigeFinish.Value = "0";
            hdnFinish.Value = "1";
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showpopup", "showpopup('" + divFinish.ID + "')", true);

        }
        #endregion

        #region Fabric Quality Details Grid Event
        protected void grdFQDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;

                int supplier = Convert.ToInt32(rowView["supplier_master_Id"].ToString());
                int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
                DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
                DataTable dtGreige = ds.Tables[0];
                DataTable dtFinish = ds.Tables[1];
                int Greige = dtGreige.Rows.Count;
                int Finish = dtFinish.Rows.Count;

                DataTable dt = FabricQualityControllerInstance.GetBindSupplier(FabricMaster_ID).Tables[0];
                DropDownList ddlSupplier = e.Row.FindControl("ddlSupplier") as DropDownList;
                ddlSupplier.ID = "ddlSupplier";
                ddlSupplier.DataSource = dt;
                ddlSupplier.DataTextField = "SupplierName";
                ddlSupplier.DataValueField = "supplier_master_Id";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("Select", "-1"));
                ddlSupplier.SelectedValue = supplier.ToString();
                ddlSupplier.Attributes.Add("onchange", "SupplierOnchange(this,'Row','" + Greige + "');");

                TextBox txtGMoq = e.Row.FindControl("txtGMoq") as TextBox;
                txtGMoq.Text = "";
                txtGMoq.MaxLength = 7;
                txtGMoq.Attributes.Add("onkeypress", "return isNumberKey(event)");

                if (Greige > 0)
                {
                    for (int i = 0; i < Greige; i++)
                    {
                        int Id = Convert.ToInt32(dtGreige.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        DataTable dtdetail = FabricQualityControllerInstance.GetFQ_Details_By_Fabric_Quality_DetailsID(Id, supplier).Tables[0];
                        if (dtdetail.Rows.Count > 0)
                        {
                            txtGMoq.Text = dtdetail.Rows[0]["MinimumOrderQuantity"].ToString() == "0" ? "" : dtdetail.Rows[0]["MinimumOrderQuantity"].ToString();

                            CheckBox chkGrate = e.Row.FindControl("chkGrate" + i + "1") as CheckBox;
                            chkGrate.ID = "chkGrate" + i;
                            chkGrate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Greige"].ToString());
                            chkGrate.Enabled = Convert.ToBoolean(dtdetail.Rows[0]["Greiges"].ToString());

                            if (Convert.ToBoolean(dtdetail.Rows[0]["Greiges"].ToString()) == false)
                            chkGrate.ToolTip = "this supplier not deal with Greige";

                            HiddenField hdnFabric_Quality_Supplier_Specific = e.Row.FindControl("chkGrate" + i + "2") as HiddenField;
                            hdnFabric_Quality_Supplier_Specific.ID = "hdnFabric_Quality_Supplier_Specific_Greige" + i;
                            hdnFabric_Quality_Supplier_Specific.Value = dtdetail.Rows[0]["Fabric_Quality_Supplier_Specific"].ToString();

                            CheckBox chkGDyedRate = e.Row.FindControl("chkGDyedRate" + i) as CheckBox;
                            chkGDyedRate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Dyed"].ToString());

                            chkGDyedRate.Enabled = Convert.ToBoolean(dtdetail.Rows[0]["Dyeds"].ToString());

                            if (Convert.ToBoolean(dtdetail.Rows[0]["Dyeds"].ToString())==false)
                            chkGDyedRate.ToolTip = "this supplier not deal with Dyed";

                            CheckBox chkGPrintrate = e.Row.FindControl("chkGPrintrate" + i) as CheckBox;
                            chkGPrintrate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Print"].ToString());
                            chkGPrintrate.Enabled = Convert.ToBoolean(dtdetail.Rows[0]["Prints"].ToString());

                            if (Convert.ToBoolean(dtdetail.Rows[0]["Prints"].ToString()) == false)
                            chkGPrintrate.ToolTip = "this supplier not deal with Print";

                            CheckBox chkGDigitalPrint = e.Row.FindControl("chkGDigitalPrint" + i) as CheckBox;
                            chkGDigitalPrint.Checked = Convert.ToBoolean(dtdetail.Rows[0]["DigitalPrint"].ToString());
                            chkGDigitalPrint.Enabled = Convert.ToBoolean(dtdetail.Rows[0]["DigitalPrints"].ToString());

                            if (Convert.ToBoolean(dtdetail.Rows[0]["DigitalPrints"].ToString()) == false)
                            chkGDigitalPrint.ToolTip = "this supplier not deal with DigitalPrint";
                        }
                        else
                        {
                            CheckBox chkGrate = e.Row.FindControl("chkGrate" + i + "1") as CheckBox;
                            chkGrate.ID = "chkGrate" + i;
                            chkGrate.Checked = Convert.ToBoolean("False");

                            HiddenField hdnFabric_Quality_Supplier_Specific = e.Row.FindControl("chkGrate" + i + "2") as HiddenField;
                            hdnFabric_Quality_Supplier_Specific.ID = "hdnFabric_Quality_Supplier_Specific_Greige" + i;
                            hdnFabric_Quality_Supplier_Specific.Value = "0";

                            CheckBox chkGDyedRate = e.Row.FindControl("chkGDyedRate" + i) as CheckBox;
                            chkGDyedRate.Checked = Convert.ToBoolean("False");

                            CheckBox chkGPrintrate = e.Row.FindControl("chkGPrintrate" + i) as CheckBox;
                            chkGPrintrate.Checked = Convert.ToBoolean("False");

                            CheckBox chkGDigitalPrint = e.Row.FindControl("chkGDigitalPrint" + i) as CheckBox;
                            chkGDigitalPrint.Checked = Convert.ToBoolean("False");
                        }
                    }
                }

                ImageButton imgUpdate = e.Row.FindControl("imgUpdate1") as ImageButton;
                imgUpdate.ID = "imgUpdate";
                imgUpdate.ImageUrl = "../../images/save.png";
                imgUpdate.ToolTip = "Update";
                imgUpdate.CommandName = "Update";
                imgUpdate.OnClientClick = "return validate(this);";
                imgUpdate.Width = 18;
                imgUpdate.Height = 17;

                ImageButton imgCancel = e.Row.FindControl("imgUpdate2") as ImageButton;
                imgCancel.ID = "imgCancel";
                imgCancel.ImageUrl = "../../images/Cancel1.jpg";
                imgCancel.ToolTip = "Cancel";
                imgCancel.CommandName = "Cancel";
                imgCancel.Width = 24;
                imgCancel.Height = 24;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                int supplier = 0;
                if (rowView["supplier_master_Id"].ToString() != "")
                {
                    supplier = Convert.ToInt32(rowView["supplier_master_Id"].ToString());
                }
                int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
                DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
                DataTable dtGreige = ds.Tables[0];
                DataTable dtFinish = ds.Tables[1];
                DataTable dtischeck = ds.Tables[3];
                int Greige = dtGreige.Rows.Count;
                int Finish = dtFinish.Rows.Count;

                Label lblSupplier = e.Row.FindControl("lblSupplier") as Label;
                if (lblSupplier == null)
                {
                    goto outer;
                }
                lblSupplier.Text = "";

                Label lblGMoq = e.Row.FindControl("lblGMoq") as Label;
                lblGMoq.Text = "";

                if (Greige > 0)
                {
                    for (int i = 0; i < Greige; i++)
                    {
                        int Id = Convert.ToInt32(dtGreige.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        DataTable dtdetail = FabricQualityControllerInstance.GetFQ_Details_By_Fabric_Quality_DetailsID(Id, supplier).Tables[0];
                        if (dtdetail.Rows.Count > 0)
                        {
                            lblSupplier.Text = dtdetail.Rows[0]["SupplierName"].ToString();
                            lblGMoq.Text = dtdetail.Rows[0]["MinimumOrderQuantity"].ToString() == "0" ? "" : dtdetail.Rows[0]["MinimumOrderQuantity"].ToString();

                            CheckBox lblGrate = e.Row.FindControl("lblGrate" + i + "1") as CheckBox;
                            lblGrate.ID = "lblGrate" + i;
                            lblGrate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Greige"].ToString());
                            lblGrate.Enabled = false;

                            HiddenField hdnFabric_Quality_Supplier_Specific_Greige = e.Row.FindControl("lblGrate" + i + "2") as HiddenField;
                            hdnFabric_Quality_Supplier_Specific_Greige.ID = "lblhdnFabric_Quality_Supplier_Specific_Greige" + i;
                            hdnFabric_Quality_Supplier_Specific_Greige.Value = dtdetail.Rows[0]["Fabric_Quality_Supplier_Specific"].ToString();

                            CheckBox lblGDyedRate = e.Row.FindControl("lblGDyedRate" + i) as CheckBox;
                            lblGDyedRate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Dyed"].ToString());
                            lblGDyedRate.Enabled = false;

                            CheckBox lblGPrintrate = e.Row.FindControl("lblGPrintrate" + i) as CheckBox;
                            lblGPrintrate.Checked = Convert.ToBoolean(dtdetail.Rows[0]["Print"].ToString());
                            lblGPrintrate.Enabled = false;

                            CheckBox lblGDigitalPrint = e.Row.FindControl("lblGDigitalPrint" + i) as CheckBox;
                            lblGDigitalPrint.Checked = Convert.ToBoolean(dtdetail.Rows[0]["DigitalPrint"].ToString());
                            lblGDigitalPrint.Enabled = false;
                        }
                        else
                        {
                            CheckBox lblGrate = e.Row.FindControl("lblGrate" + i + "1") as CheckBox;
                            lblGrate.ID = "lblGrate" + i;
                            lblGrate.Checked = Convert.ToBoolean("False");
                            lblGrate.Enabled = false;

                            HiddenField hdnFabric_Quality_Supplier_Specific_Greige = e.Row.FindControl("lblGrate" + i + "2") as HiddenField;
                            hdnFabric_Quality_Supplier_Specific_Greige.ID = "lblhdnFabric_Quality_Supplier_Specific_Greige" + i;
                            hdnFabric_Quality_Supplier_Specific_Greige.Value = "0";

                            CheckBox lblGDyedRate = e.Row.FindControl("lblGDyedRate" + i) as CheckBox;
                            lblGDyedRate.Checked = Convert.ToBoolean("False");
                            lblGDyedRate.Enabled = false;

                            CheckBox lblGPrintrate = e.Row.FindControl("lblGPrintrate" + i) as CheckBox;
                            lblGPrintrate.Checked = Convert.ToBoolean("False");
                            lblGPrintrate.Enabled = false;

                            CheckBox lblGDigitalPrint = e.Row.FindControl("lblGDigitalPrint" + i) as CheckBox;
                            lblGDigitalPrint.Checked = Convert.ToBoolean("False");
                            lblGDigitalPrint.Enabled = false;
                        }
                    }
                }

                ImageButton imgEdit = e.Row.FindControl("imgEdit1") as ImageButton;
                imgEdit.ID = "imgEdit";
                imgEdit.ImageUrl = "../../images/edit2.png";
                imgEdit.ToolTip = "Edit";
                imgEdit.CommandName = "Edit";
                imgEdit.Width = 17;
                imgEdit.Height = 17;

                if (dtischeck.Rows.Count <= 0)
                {
                    ImageButton imgDelete = e.Row.FindControl("imgEdit2") as ImageButton;
                    imgDelete.ID = "imgDelete";
                    imgDelete.ImageUrl = "../../images/delete-icon.png";
                    imgDelete.ToolTip = "Delete";
                    imgDelete.CommandName = "Delete";
                    imgDelete.OnClientClick = "return confirm('Are you sure you want to delete this record?');";
                    imgDelete.Width = 17;
                    imgDelete.Height = 17;
                }
                else
                {
                    ImageButton imgDelete = e.Row.FindControl("imgEdit2") as ImageButton;
                    imgDelete.ID = "imgDelete";
                    imgDelete.ImageUrl = "../../images/delete-icon.png";
                    imgDelete.ToolTip = "Delete";
                    imgDelete.CommandName = "Delete";
                    imgDelete.Enabled = false;
                    imgDelete.ToolTip = "Can't delete this record, already using in costing";
                    imgDelete.OnClientClick = "return confirm('Are you sure you want to delete this record?');";
                    imgDelete.Width = 17;
                    imgDelete.Height = 17;
                }

            outer: ;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
                DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
                DataTable dtGreige = ds.Tables[0];
                DataTable dtFinish = ds.Tables[1];
                int Greige = dtGreige.Rows.Count;
                int Finish = dtFinish.Rows.Count;


                DataTable dt = FabricQualityControllerInstance.GetBindSupplier(FabricMaster_ID).Tables[0];
                DropDownList ddlFooterSupplier = e.Row.FindControl("ddlFooterSupplier") as DropDownList;
                ddlFooterSupplier.ID = "ddlFooterSupplier";
                ddlFooterSupplier.DataSource = dt;
                ddlFooterSupplier.DataTextField = "SupplierName";
                ddlFooterSupplier.DataValueField = "supplier_master_Id";
                ddlFooterSupplier.DataBind();
                ddlFooterSupplier.Items.Insert(0, new ListItem("Select", "-1"));

                ddlFooterSupplier.Attributes.Add("style", "height:23px;width:99%;");

                ddlFooterSupplier.Attributes.Add("onchange", "SupplierOnchange(this,'Footer','" + Greige + "');");

                TextBox txtFooterGMoq = e.Row.FindControl("txtFooterGMoq") as TextBox;
                txtFooterGMoq.MaxLength = 7;
                txtFooterGMoq.Attributes.Add("onkeypress", "return isNumberKey(event)");

                if (Greige > 0)
                {
                    for (int i = 0; i < Greige; i++)
                    {
                        CheckBox chkFooterGrate = e.Row.FindControl("chkFooterGrate" + i + "1") as CheckBox;
                        chkFooterGrate.ID = "chkFooterGrate" + i;
                        chkFooterGrate.CssClass = "chkDisable";

                        HiddenField hdnFabric_Quality_DetailsID = e.Row.FindControl("chkFooterGrate" + i + "2") as HiddenField;
                        hdnFabric_Quality_DetailsID.ID = "hdnFabric_Quality_DetailsID_Greige" + i;
                        hdnFabric_Quality_DetailsID.Value = dtGreige.Rows[i]["Fabric_Quality_DetailsID"].ToString();

                        CheckBox chkFooterGDyedRate = e.Row.FindControl("chkFooterGDyedRate" + i) as CheckBox;

                        chkFooterGDyedRate.CssClass = "chkDisable";

                        CheckBox chkFooterGPrintrate = e.Row.FindControl("chkFooterGPrintrate" + i) as CheckBox;
                        chkFooterGPrintrate.CssClass = "chkDisable";

                        CheckBox chkFooterGDigitalPrint = e.Row.FindControl("chkFooterGDigitalPrint" + i) as CheckBox;
                        chkFooterGDigitalPrint.CssClass = "chkDisable";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "CheckBoxDisable();", true);

                    }
                }

                ImageButton imgAddMore = e.Row.FindControl("imgAddMore") as ImageButton;
                imgAddMore.ID = "imgAddMore";
                imgAddMore.ImageUrl = "../../images/add-butt.png";
                imgAddMore.ToolTip = "Add More";
                imgAddMore.CommandName = "Insert";
                imgAddMore.OnClientClick = "return validate(this);";
                imgAddMore.Width = 17;
                imgAddMore.Height = 17;
            }

        }

        protected void grdFQDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                grdFQDetails.EditIndex = -1;
                var Fabric_Quality_Supplier_Specific = 0;
                int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
                int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
                DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
                DataTable dtGreige = ds.Tables[0];
                DataTable dtFinish = ds.Tables[1];
                int Greige = dtGreige.Rows.Count;
                int Finish = dtFinish.Rows.Count;
                DropDownList ddlFooterSupplier = (DropDownList)grdFQDetails.FooterRow.FindControl("ddlFooterSupplier");
                TextBox txtFooterGMoq = (TextBox)grdFQDetails.FooterRow.FindControl("txtFooterGMoq");

                if (Greige > 0)
                {
                    for (int i = 0; i < Greige; i++)
                    {
                        CheckBox chkFooterGrate = (CheckBox)grdFQDetails.FooterRow.FindControl("chkFooterGrate" + i);
                        HiddenField hdnFabric_Quality_DetailsID_Greige = (HiddenField)grdFQDetails.FooterRow.FindControl("hdnFabric_Quality_DetailsID_Greige" + i);
                        CheckBox chkFooterGDyedRate = (CheckBox)grdFQDetails.FooterRow.FindControl("chkFooterGDyedRate" + i);
                        CheckBox chkFooterGPrintrate = (CheckBox)grdFQDetails.FooterRow.FindControl("chkFooterGPrintrate" + i);
                        CheckBox chkFooterGDigitalPrint = (CheckBox)grdFQDetails.FooterRow.FindControl("chkFooterGDigitalPrint" + i);
                        double GreigeRate = Convert.ToDouble(ViewState["GreigeRate" + i].ToString());
                        double GreigeFinalRate = Convert.ToDouble(ViewState["GreigeFinalRate" + i].ToString());
                        int DyedRate = Convert.ToInt32(ViewState["DyedRate" + i].ToString());
                        int PrintRate = Convert.ToInt32(ViewState["PrintRate" + i].ToString());
                        int DigitalPrintRate = Convert.ToInt32(ViewState["DigitalPrintRate" + i].ToString());
                        double MOQ = txtFooterGMoq.Text.Trim() == "" ? 0 : Convert.ToDouble(txtFooterGMoq.Text.Trim());

                        var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                        var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                        try
                        {
                            if (this.FabricQualityControllerInstance.FQ_Details_Greige_InstUpdate(Convert.ToInt32(Fabric_Quality_Supplier_Specific), Convert.ToInt32(hdnFabric_Quality_DetailsID_Greige.Value.ToString()),
                                Convert.ToInt32(ddlFooterSupplier.SelectedValue.ToString()), Convert.ToBoolean(chkFooterGrate.Checked.ToString()),
                                Convert.ToBoolean(chkFooterGDyedRate.Checked.ToString()), Convert.ToBoolean(chkFooterGPrintrate.Checked.ToString()), Convert.ToBoolean(chkFooterGDigitalPrint.Checked.ToString()),
                                MOQ, CreatedBy, GreigeRate, GreigeFinalRate, DyedRate, PrintRate, DigitalPrintRate) > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                            }
                            else
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                        }
                        catch (Exception ex)
                        {
                            var script_fail2 = "";
                            string er = ex.Message.Substring(0, ex.Message.Length - 3);
                            if (er == "Record already exists.")
                                script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                            else
                                script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                        }
                    }
                }

                BindFabricQualityHeader(FabricMaster_ID);
            }
        }

        protected void grdFQDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int count = 0;
            int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
            DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
            DataTable dtGreige = ds.Tables[0];
            DataTable dtFinish = ds.Tables[1];
            int Greige = dtGreige.Rows.Count;
            int Finish = dtFinish.Rows.Count;

            if (Greige > 0)
            {
                string Id = "";
                for (int i = 0; i < Greige; i++)
                {
                    HiddenField hdnFabric_Quality_Supplier_Specific_Greige = (HiddenField)grdFQDetails.Rows[e.RowIndex].FindControl("lblhdnFabric_Quality_Supplier_Specific_Greige" + i);
                    Id += hdnFabric_Quality_Supplier_Specific_Greige.Value.ToString() + ",";
                }

                Id = Id.Substring(0, Id.Length - 1);
                var script_success = "ShowHideMessageBox(true, '" + "Information delete successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.FabricQualityControllerInstance.FQ_Details_Delete(Id) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                    else
                        script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                    count++;
                }
            }
            if (count == 0)
            {
                BindFabricQualityHeader(FabricMaster_ID);
            }
        }

        protected void grdFQDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdFQDetails.EditIndex = -1;
            BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));
        }

        protected void grdFQDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdFQDetails.EditIndex = e.NewEditIndex;
            BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));

        }

        protected void grdFQDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int count = 0;
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            int FabricMaster_ID = Convert.ToInt32(ViewState["FQMID"].ToString());
            DataSet ds = FabricQualityControllerInstance.GetFQHeader(FabricMaster_ID);
            DataTable dtGreige = ds.Tables[0];
            DataTable dtFinish = ds.Tables[1];
            int Greige = dtGreige.Rows.Count;
            int Finish = dtFinish.Rows.Count;
            DropDownList ddlSupplier = (DropDownList)grdFQDetails.Rows[e.RowIndex].FindControl("ddlSupplier");
            TextBox txtGMoq = (TextBox)grdFQDetails.Rows[e.RowIndex].FindControl("txtGMoq");

            if (Greige > 0)
            {
                for (int i = 0; i < Greige; i++)
                {
                    CheckBox chkGrate = (CheckBox)grdFQDetails.Rows[e.RowIndex].FindControl("chkGrate" + i);
                    HiddenField hdnFabric_Quality_Supplier_Specific_Greige = (HiddenField)grdFQDetails.Rows[e.RowIndex].FindControl("hdnFabric_Quality_Supplier_Specific_Greige" + i);
                    CheckBox chkGDyedRate = (CheckBox)grdFQDetails.Rows[e.RowIndex].FindControl("chkGDyedRate" + i);
                    CheckBox chkGPrintrate = (CheckBox)grdFQDetails.Rows[e.RowIndex].FindControl("chkGPrintrate" + i);
                    CheckBox chkGDigitalPrint = (CheckBox)grdFQDetails.Rows[e.RowIndex].FindControl("chkGDigitalPrint" + i);
                    double GreigeRate = Convert.ToDouble(ViewState["GreigeRate" + i].ToString());
                    double GreigeFinalRate = Convert.ToDouble(ViewState["GreigeFinalRate" + i].ToString());
                    int DyedRate = Convert.ToInt32(ViewState["DyedRate" + i].ToString());
                    int PrintRate = Convert.ToInt32(ViewState["PrintRate" + i].ToString());
                    int DigitalPrintRate = Convert.ToInt32(ViewState["DigitalPrintRate" + i].ToString());
                    double MOQ = txtGMoq.Text.Trim() == "" ? 0 : Convert.ToDouble(txtGMoq.Text.Trim());

                    var script_success = "ShowHideMessageBox(true, '" + "Information update successfully." + "');";
                    var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                    try
                    {
                        if (this.FabricQualityControllerInstance.FQ_Details_Greige_InstUpdate(Convert.ToInt32(hdnFabric_Quality_Supplier_Specific_Greige.Value.ToString()), Convert.ToInt32(dtGreige.Rows[i]["Fabric_Quality_DetailsID"].ToString()),
                                Convert.ToInt32(ddlSupplier.SelectedValue.ToString()), Convert.ToBoolean(chkGrate.Checked.ToString()),
                                Convert.ToBoolean(chkGDyedRate.Checked.ToString()), Convert.ToBoolean(chkGPrintrate.Checked.ToString()), Convert.ToBoolean(chkGDigitalPrint.Checked.ToString()),
                                MOQ, CreatedBy, GreigeRate, GreigeFinalRate, DyedRate, PrintRate, DigitalPrintRate) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                            count++;
                        }
                    }
                    catch (Exception ex)
                    {
                        var script_fail2 = "";
                        string er = ex.Message.Substring(0, ex.Message.Length - 3);
                        if (er == "Record already exists.")
                            script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                        else
                            script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                grdFQDetails.EditIndex = -1;
                BindFabricQualityHeader(FabricMaster_ID);
            }
        }

        #endregion

        //string CandC = "";
        protected void grdGreigetoFinish_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCandCFooter = (HiddenField)e.Row.FindControl("hdnCandCFooter");
                //RequiredFieldValidator rfvCC = (RequiredFieldValidator)e.Row.FindControl("rfvCC");
                //rfvCC.Enabled = bCount_Construction;
                //CandC = hdnCandCFooter.Value;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                TextBox txtFooterCC = (TextBox)e.Row.FindControl("txtFooterCC");
                RequiredFieldValidator rfvFooterCC = (RequiredFieldValidator)e.Row.FindControl("rfvFooterCC");
                rfvFooterCC.Enabled = bCount_Construction;

                //if (CandC.ToString() == "True")
                //{
                //    rfvFooterCC.Enabled = true;
                //};
                //else
                //{
                //    rfvFooterCC.Enabled = bCount_Construction;
                //}
            }
        }
    }
}