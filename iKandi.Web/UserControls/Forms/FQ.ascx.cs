using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Web.Components;
using iKandi.BLL;
using iKandi.Common;
using System.Collections.Generic;
using System.ComponentModel;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FQ : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }
        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.FABRIC_QUALITY));
                BIndGrid();
            }
        }

        private void BIndGrid()
        {
            string SearchItem = "%" + txtSearch.Text.Trim() + "%";
            string GroupID = ddlGroup.SelectedValue;
            string SubGroupID = hiddenSubGroupId.Value;
            string TradeName = "%" + txtTrade.Text.Trim() + "%";
            string UnitID = DDlUnit.SelectedValue;
            string Origin = DDlOrigin.SelectedValue;
            string FabricType = ddlfabrictype.SelectedValue;
            DataTable dt = this.FabricQualityControllerInstance.GetFabricsQualityMaster(SearchItem, GroupID, SubGroupID, TradeName, UnitID, Origin, FabricType).Tables[0];
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
                gdvFQMaster.Rows[0].Cells.Clear();
                gdvFQMaster.Rows[0].Cells.Add(new TableCell());
                gdvFQMaster.Rows[0].Cells[0].ColumnSpan = TotalColumn;
                gdvFQMaster.Rows[0].Cells[0].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                gdvFQMaster.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            DropDownList ddlFooterGroup = (DropDownList)gdvFQMaster.FooterRow.FindControl("ddlFooterGroup");
            DropdownHelper.BindParentCategories(ddlFooterGroup, Convert.ToInt32(CategoryType.FABRIC_QUALITY));
        }

        private void BIndDetailsGrid(string FQMID, int rowindex)
        {
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            objFabricQuality = this.FabricQualityControllerInstance.GetFabricQualityDetails(FQMID, 0);
            if (objFabricQuality.Count > 0)
            {
                gdvFQDetails.DataSource = objFabricQuality;
                gdvFQDetails.DataBind();
                txtApprovedOn.Text = objFabricQuality[0].ApprovedOn.ToString("dd MMM yy (ddd) ");
            }
            else
            {
                DataTable dt = ToDataTable(objFabricQuality);
                dt.Rows.Add(dt.NewRow());
                gdvFQDetails.DataSource = dt;
                gdvFQDetails.DataBind();
                int TotalColumn = gdvFQDetails.Rows[0].Cells.Count;
                gdvFQDetails.Rows[0].Cells.Clear();
                gdvFQDetails.Rows[0].Cells.Add(new TableCell());
                gdvFQDetails.Rows[0].Cells[0].ColumnSpan = TotalColumn;
                gdvFQDetails.Rows[0].Cells[0].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                gdvFQDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                txtApprovedOn.Text = DateTime.Now.ToString("dd MMM yy (ddd) ");
            }

            DropDownList ddlSupplierNameF = (DropDownList)gdvFQDetails.FooterRow.FindControl("ddlSupplierNameF");
            BindDDLSuplier(ddlSupplierNameF);
            Label lblIdentificationF = (Label)gdvFQDetails.FooterRow.FindControl("lblIdentificationF");
            HiddenField hdnfGroupID = (HiddenField)gdvFQMaster.Rows[rowindex].FindControl("hdnfGroupID");
            HiddenField hdnfSubGroup = (HiddenField)gdvFQMaster.Rows[rowindex].FindControl("hdnfSubGroup");
            lblIdentificationF.Text = this.CommonControllerInstance.GetIdentification(Convert.ToInt32(hdnfGroupID.Value), Convert.ToInt32(hdnfSubGroup.Value), 1);           
        }

        protected void gdvFQMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FabricQuality FQM = new FabricQuality();
            if (e.CommandName.Equals("Insert"))
            {

                DropDownList ddlFooterGroup = (DropDownList)gdvFQMaster.FooterRow.FindControl("ddlFooterGroup");
                HiddenField hiddenSubGroupFooterId = (HiddenField)gdvFQMaster.FooterRow.FindControl("hiddenSubGroupFooterId");
                DropDownList ddlFooterUnit = (DropDownList)gdvFQMaster.FooterRow.FindControl("ddlFooterUnit");
                TextBox txtFooterTradeName = (TextBox)gdvFQMaster.FooterRow.FindControl("txtFooterTradeName");
                RadioButton rdofooterfabrictypeReg = (RadioButton)gdvFQMaster.FooterRow.FindControl("rdofooterfabrictypeReg");
                FQM.FQMasterID = "0";
                FQM.CategoryId = Convert.ToInt32(ddlFooterGroup.SelectedValue);
                FQM.SubCategoryId = Convert.ToInt32(hiddenSubGroupFooterId.Value);
                FQM.TradeName = txtFooterTradeName.Text.Trim();
                FQM.StockUnit = Convert.ToInt32(ddlFooterUnit.SelectedValue);
                //FQM.FabricTypeReg_UnReg = rdofooterfabrictypeReg.Checked == true ? "1" : "0";

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.FabricQualityControllerInstance.FabricsQualityMaster_InsUpdt(FQM) > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
                    BIndGrid();
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message;
                    if (er == "Record already exists.")
                        script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                    else
                        script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
                }
            }
            if (e.CommandName == "Select")
            {
                GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowindex = rowSelect.RowIndex;
                //string FabricMaster_ID = gdvFQMaster.DataKeys[rowindex]["FabricMaster_ID"].ToString();
                string FQMID = gdvFQMaster.DataKeys[rowindex]["FabricMaster_ID"].ToString();
                ViewState["rowindex"] = rowindex;
                ViewState["FQMID"] = FQMID;

                BIndDetailsGrid(FQMID, rowindex);
            }
        }

        protected void gdvFQMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvFQMaster.PageIndex = e.NewPageIndex;
            BIndGrid();
        }

        protected void lkbGo_Click(object sender, EventArgs e)
        {
            BIndGrid();
            gdvFQDetails.DataSource = null;
            gdvFQDetails.DataBind();
            DropdownHelper.BindSubCategories(ddlSubGroup, Convert.ToInt32(ddlGroup.SelectedValue));
            ddlSubGroup.SelectedValue = hiddenSubGroupId.Value;
        }

        protected void gdvFQMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvFQMaster.EditIndex = e.NewEditIndex;
            BIndGrid();
            TextBox txtTradeName = (TextBox)gdvFQMaster.Rows[e.NewEditIndex].FindControl("txtTradeName");
            DropDownList ddlGroup = (DropDownList)gdvFQMaster.Rows[e.NewEditIndex].FindControl("ddlGroup");
            DropDownList ddlSubGroup = (DropDownList)gdvFQMaster.Rows[e.NewEditIndex].FindControl("ddlSubGroup");
            DropDownList ddlUnit = (DropDownList)gdvFQMaster.Rows[e.NewEditIndex].FindControl("ddlUnit");

            var FabricMaster_ID = gdvFQMaster.DataKeys[e.NewEditIndex]["FabricMaster_ID"].ToString();
            DataTable dt = this.FabricQualityControllerInstance.FabricsQualityMasterEdit(FabricMaster_ID.ToString());
            if (dt.Rows.Count > 0)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.FABRIC_QUALITY));
                ddlGroup.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                txtTradeName.Text = dt.Rows[0]["TradeName"].ToString();
                ddlUnit.SelectedValue = dt.Rows[0]["Unit"].ToString();

                DropdownHelper.BindSubCategories(ddlSubGroup, Convert.ToInt32(ddlGroup.SelectedValue));
                ddlSubGroup.SelectedValue = dt.Rows[0]["SubCategoryId"].ToString();

            }
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
            DropDownList ddlSubGroup = (DropDownList)gdvFQMaster.Rows[e.RowIndex].FindControl("ddlSubGroup");
            DropDownList ddlUnit = (DropDownList)gdvFQMaster.Rows[e.RowIndex].FindControl("ddlUnit");
            var hiddenSubGroupIdGrid = (HiddenField)gdvFQMaster.Rows[e.RowIndex].FindControl("hiddenSubGroupIdGrid");

            FQM.FQMasterID = FabricMaster_ID;
            FQM.CategoryId = Convert.ToInt32(ddlGroup.SelectedValue);
            if (Convert.ToInt32(ddlSubGroup.SelectedValue) > 0)
                FQM.SubCategoryId = Convert.ToInt32(ddlSubGroup.SelectedValue);
            else
                FQM.SubCategoryId = Convert.ToInt32(hiddenSubGroupIdGrid.Value);
            FQM.TradeName = txtTradeName.Text.Trim();
            FQM.StockUnit = Convert.ToInt32(ddlUnit.SelectedValue);

            var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.FabricQualityControllerInstance.FabricsQualityMaster_InsUpdt(FQM) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    gdvFQMaster.EditIndex = -1;
                    BIndGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message;
                if (er == "Record already exists.")
                    script_fail2 = "ShowHideValidationBox(true, '" + "Record already exists." + "');";
                else
                    script_fail2 = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail2, true);
            }
        }

        #region Fabric Details

        protected void gdvFQDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();
            gdvFQDetails.PageIndex = e.NewPageIndex;
            BIndDetailsGrid(FQMID, rowindex);
        }

        protected void gdvFQDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();
            gdvFQDetails.EditIndex = -1;
            BIndDetailsGrid(FQMID, rowindex);
        }

        protected void gdvFQDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FabricQuality fq = new FabricQuality();
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();
            string fileID = String.Empty;

            if (e.CommandName.Equals("Insert"))
            {
                if (!Page.IsValid)
                    return;

                Label lblIdentificationF = (Label)gdvFQDetails.FooterRow.FindControl("lblIdentificationF");
                DropDownList ddlSupplierNameF = (DropDownList)gdvFQDetails.FooterRow.FindControl("ddlSupplierNameF");
                DropDownList ddlOriginF = (DropDownList)gdvFQDetails.FooterRow.FindControl("ddlOriginF");
                TextBox txtSupplierReferenceF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtSupplierReferenceF");
                TextBox txtQtyF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtQtyF");
                TextBox txtCountF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtCountF");
                TextBox txtCompositionF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtCompositionF");
                TextBox txtFabricF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtFabricF");
                HiddenField hdnUpdateBaseFilePathF = (HiddenField)gdvFQDetails.FooterRow.FindControl("hdnUpdateBaseFilePathF");
                FileUpload fileBaseTestF = (FileUpload)gdvFQDetails.FooterRow.FindControl("fileBaseTestF");
                TextBox txtTestConductedOnF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtTestConductedOnF");
                TextBox txtMOQPrintF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtMOQPrintF");
                TextBox txtMOQF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtMOQF");
                HtmlInputHidden hdnFldFilePathF = (HtmlInputHidden)gdvFQDetails.FooterRow.FindControl("hdnFldFilePathF");
                HtmlInputHidden hdnFldRemarksF = (HtmlInputHidden)gdvFQDetails.FooterRow.FindControl("hdnFldRemarksF");

                #region Air
                TextBox txtPriceForGreigeByAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForGreigeByAirF");
                TextBox txtGSMGreigeAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMGreigeAirF");
                TextBox txtWidthGreigeAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthGreigeAirF");
                TextBox txtResidualShrinkageGreigeAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageGreigeAirF");

                TextBox txtPriceForDyedByAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForDyedByAirF");
                TextBox txtGSMDyedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDyedAirF");
                TextBox txtWidthDyedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDyedAirF");
                TextBox txtResidualShrinkageDyedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDyedAirF");

                TextBox txtPriceForPrintedByAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForPrintedByAirF");
                TextBox txtGSMPrintedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMPrintedAirF");
                TextBox txtWidthPrintedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthPrintedAirF");
                TextBox txtResidualShrinkagePrintedAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkagePrintedAirF");

                TextBox txtPriceForDigitalByAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForDigitalByAirF");
                TextBox txtGSMDigitalAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDigitalAirF");
                TextBox txtWidthDigitalAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDigitalAirF");
                TextBox txtResidualShrinkageDigitalAirF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDigitalAirF");

                #endregion

                #region Sea
                TextBox txtPriceForGreigeBySeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForGreigeBySeaF");
                TextBox txtGSMGreigeSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMGreigeSeaF");
                TextBox txtWidthGreigeSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthGreigeSeaF");
                TextBox txtResidualShrinkageGreigeSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageGreigeSeaF");

                TextBox txtPriceForDyedBySeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForDyedBySeaF");
                TextBox txtGSMDyedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDyedSeaF");
                TextBox txtWidthDyedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDyedSeaF");
                TextBox txtResidualShrinkageDyedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDyedSeaF");

                TextBox txtPriceForPrintedBySeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForPrintedBySeaF");
                TextBox txtGSMPrintedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMPrintedSeaF");
                TextBox txtWidthPrintedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthPrintedSeaF");
                TextBox txtResidualShrinkagePrintedSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkagePrintedSeaF");

                TextBox txtPriceForDigitalBySeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForDigitalBySeaF");
                TextBox txtGSMDigitalSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDigitalSeaF");
                TextBox txtWidthDigitalSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDigitalSeaF");
                TextBox txtResidualShrinkageDigitalSeaF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDigitalSeaF");

                #endregion

                #region Indian
                TextBox txtPriceGreigeIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceGreigeIndianF");
                TextBox txtGSMGreigeIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMGreigeIndianF");
                TextBox txtWidthGreigeIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthGreigeIndianF");
                TextBox txtResidualShrinkageGreigeIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageGreigeIndianF");

                TextBox txtPriceDyedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceDyedIndianF");
                TextBox txtGSMDyedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDyedIndianF");
                TextBox txtWidthDyedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDyedIndianF");
                TextBox txtResidualShrinkageDyedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDyedIndianF");

                TextBox txtPricePrintedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPricePrintedIndianF");
                TextBox txtGSMPrintedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMPrintedIndianF");
                TextBox txtWidthPrintedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthPrintedIndianF");
                TextBox txtResidualShrinkagePrintedIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkagePrintedIndianF");

                TextBox txtPriceForDigitalByIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtPriceForDigitalByIndianF");
                TextBox txtGSMDigitalIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtGSMDigitalIndianF");
                TextBox txtWidthDigitalIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtWidthDigitalIndianF");
                TextBox txtResidualShrinkageDigitalIndianF = (TextBox)gdvFQDetails.FooterRow.FindControl("txtResidualShrinkageDigitalIndianF");

                #endregion

                fq.FQMasterID = FQMID;
                fq.FabricQualityID = 0;                
                fq.SupplierReference = txtSupplierReferenceF.Text;
                fq.CountConstruction = txtCountF.Text;
                if (!string.IsNullOrEmpty(ddlOriginF.SelectedValue))
                    fq.Origin = Convert.ToInt32(ddlOriginF.SelectedValue);
                if (!string.IsNullOrEmpty(txtCompositionF.Text))
                    fq.Composition = txtCompositionF.Text;
                else
                    fq.Composition = string.Empty;

                if (fileBaseTestF.HasFile)
                    fileID = FileHelper.SaveFile(fileBaseTestF.PostedFile.InputStream, fileBaseTestF.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

                if (fileID != string.Empty)
                    fq.UpdateBaseTestFile = fileID;

                if (!string.IsNullOrEmpty(txtTestConductedOnF.Text))
                {
                    fq.TestConductedOn = DateHelper.ParseDate(txtTestConductedOnF.Text).Value;
                }

                if (!string.IsNullOrEmpty(txtMOQF.Text))
                {
                    fq.MinimumOrderQuantity = Convert.ToDouble(txtMOQF.Text);
                }
                fq.Fabric = txtFabricF.Text;
                fq.Identification = lblIdentificationF.Text;
                fq.SupplierId = Convert.ToInt32(ddlSupplierNameF.SelectedValue);

                //if (String.IsNullOrEmpty(hdnFldRemarksF.Value))
                fq.Comments = hdnFldRemarksF.Value;
                //else
                //    fq.Comments = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName + " (" + DateTime.Today.ToString("dd MMM") + ")" + " " + " : " + hdnFldRemarksF.Value;
                if (!string.IsNullOrEmpty(txtQtyF.Text.Trim()))
                {
                    fq.MinStockQuality = Convert.ToInt32(txtQtyF.Text.Trim());
                }
                else
                    fq.MinStockQuality = null;

                if (!string.IsNullOrEmpty(txtMOQPrintF.Text))
                {
                    fq.MOQPrint = Convert.ToDouble(txtMOQPrintF.Text);
                }

                if (!string.IsNullOrEmpty(txtQtyF.Text))
                {
                    fq.MinStockQuality = Convert.ToInt32(txtQtyF.Text);
                }
                fq.FilePath = hdnFldFilePathF.Value;
                if (!string.IsNullOrEmpty(txtTestConductedOnF.Text))
                {
                    fq.ApprovedOn = DateHelper.ParseDate(txtApprovedOn.Text).Value;
                }

                #region Air
                if (!string.IsNullOrEmpty(txtPriceForGreigeByAirF.Text))                
                    fq.PriceForGreigeByAir = Convert.ToDouble(txtPriceForGreigeByAirF.Text);
                             
                if (!string.IsNullOrEmpty(txtGSMGreigeAirF.Text))               
                    fq.GSMGreigeAir = Convert.ToDouble(txtGSMGreigeAirF.Text);
                
                if (!string.IsNullOrEmpty(txtWidthGreigeAirF.Text))              
                    fq.WidthGreigeAir = Convert.ToDecimal(txtWidthGreigeAirF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeAirF.Text))
                    fq.ResidualShrinkageGreigeAir = Convert.ToDouble(txtResidualShrinkageGreigeAirF.Text);

                if (!string.IsNullOrEmpty(txtPriceForDyedByAirF.Text))
                    fq.PriceForDyedByAir = Convert.ToDouble(txtPriceForDyedByAirF.Text);

                if (!string.IsNullOrEmpty(txtGSMDyedAirF.Text))
                    fq.GSMDyedAir = Convert.ToDouble(txtGSMDyedAirF.Text);

                if (!string.IsNullOrEmpty(txtWidthDyedAirF.Text))
                    fq.WidthDyedAir = Convert.ToDecimal(txtWidthDyedAirF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDyedAirF.Text))
                    fq.ResidualShrinkageDyedAir = Convert.ToDouble(txtResidualShrinkageDyedAirF.Text);

                if (!string.IsNullOrEmpty(txtPriceForPrintedByAirF.Text))
                    fq.PriceForPrintedByAir = Convert.ToDouble(txtPriceForPrintedByAirF.Text);

                if (!string.IsNullOrEmpty(txtGSMPrintedAirF.Text))
                    fq.GSMPrintedAir = Convert.ToDouble(txtGSMPrintedAirF.Text);

                if (!string.IsNullOrEmpty(txtWidthPrintedAirF.Text))
                    fq.WidthPrintedAir = Convert.ToDecimal(txtWidthPrintedAirF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedAirF.Text))
                    fq.ResidualShrinkagePrintedAir = Convert.ToDouble(txtResidualShrinkagePrintedAirF.Text);

                if (!string.IsNullOrEmpty(txtPriceForDigitalByAirF.Text))
                    fq.PriceForDigitalByAir = Convert.ToDouble(txtPriceForDigitalByAirF.Text);

                if (!string.IsNullOrEmpty(txtGSMDigitalAirF.Text))
                    fq.GSMDigitalAir = Convert.ToDouble(txtGSMDigitalAirF.Text);

                if (!string.IsNullOrEmpty(txtWidthDigitalAirF.Text))
                    fq.WidthDigitalAir = Convert.ToDecimal(txtWidthDigitalAirF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalAirF.Text))
                    fq.ResidualShrinkageDigitalAir = Convert.ToDouble(txtResidualShrinkageDigitalAirF.Text);

                #endregion 

                #region Sea
                if (!string.IsNullOrEmpty(txtPriceForGreigeBySeaF.Text))
                    fq.PriceForGreigeBySea = Convert.ToDouble(txtPriceForGreigeBySeaF.Text);

                if (!string.IsNullOrEmpty(txtGSMGreigeSeaF.Text))
                    fq.GSMGreigeSea = Convert.ToDouble(txtGSMGreigeSeaF.Text);

                if (!string.IsNullOrEmpty(txtWidthGreigeSeaF.Text))
                    fq.WidthGreigeSea = Convert.ToDecimal(txtWidthGreigeSeaF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeSeaF.Text))
                    fq.ResidualShrinkageGreigeSea = Convert.ToDouble(txtResidualShrinkageGreigeSeaF.Text);

                if (!string.IsNullOrEmpty(txtPriceForDyedBySeaF.Text))
                    fq.PriceForDyedBySea = Convert.ToDouble(txtPriceForDyedBySeaF.Text);

                if (!string.IsNullOrEmpty(txtGSMDyedSeaF.Text))
                    fq.GSMDyedSea = Convert.ToDouble(txtGSMDyedSeaF.Text);

                if (!string.IsNullOrEmpty(txtWidthDyedSeaF.Text))
                    fq.WidthDyedSea = Convert.ToDecimal(txtWidthDyedSeaF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDyedSeaF.Text))
                    fq.ResidualShrinkageDyedSea = Convert.ToDouble(txtResidualShrinkageDyedSeaF.Text);

                if (!string.IsNullOrEmpty(txtPriceForPrintedBySeaF.Text))
                    fq.PriceForPrintedBySea = Convert.ToDouble(txtPriceForPrintedBySeaF.Text);

                if (!string.IsNullOrEmpty(txtGSMPrintedSeaF.Text))
                    fq.GSMPrintedSea = Convert.ToDouble(txtGSMPrintedSeaF.Text);

                if (!string.IsNullOrEmpty(txtWidthPrintedSeaF.Text))
                    fq.WidthPrintedSea = Convert.ToDecimal(txtWidthPrintedSeaF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedSeaF.Text))
                    fq.ResidualShrinkagePrintedSea = Convert.ToDouble(txtResidualShrinkagePrintedSeaF.Text);

                if (!string.IsNullOrEmpty(txtPriceForDigitalBySeaF.Text))
                    fq.PriceForDigitalBySea = Convert.ToDouble(txtPriceForDigitalBySeaF.Text);

                if (!string.IsNullOrEmpty(txtGSMDigitalSeaF.Text))
                    fq.GSMDigitalSea = Convert.ToDouble(txtGSMDigitalSeaF.Text);

                if (!string.IsNullOrEmpty(txtWidthDigitalSeaF.Text))
                    fq.WidthDigitalSea = Convert.ToDecimal(txtWidthDigitalSeaF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalSeaF.Text))
                    fq.ResidualShrinkageDigitalSea = Convert.ToDouble(txtResidualShrinkageDigitalSeaF.Text);

                #endregion 

                #region Indian
                if (!string.IsNullOrEmpty(txtPriceGreigeIndianF.Text))
                    fq.PriceGreigeIndian = Convert.ToDouble(txtPriceGreigeIndianF.Text);

                if (!string.IsNullOrEmpty(txtGSMGreigeIndianF.Text))
                    fq.GSMGreigeIndian = Convert.ToDouble(txtGSMGreigeIndianF.Text);

                if (!string.IsNullOrEmpty(txtWidthGreigeIndianF.Text))
                    fq.WidthGreigeIndian = Convert.ToDecimal(txtWidthGreigeIndianF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeIndianF.Text))
                    fq.ResidualShrinkageGreigeIndian = Convert.ToDouble(txtResidualShrinkageGreigeIndianF.Text);

                if (!string.IsNullOrEmpty(txtPriceDyedIndianF.Text))
                    fq.PriceDyedIndian = Convert.ToDouble(txtPriceDyedIndianF.Text);

                if (!string.IsNullOrEmpty(txtGSMDyedIndianF.Text))
                    fq.GSMDyedIndian = Convert.ToDouble(txtGSMDyedIndianF.Text);

                if (!string.IsNullOrEmpty(txtWidthDyedIndianF.Text))
                    fq.WidthDyedIndian = Convert.ToDecimal(txtWidthDyedIndianF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDyedIndianF.Text))
                    fq.ResidualShrinkageDyedIndian = Convert.ToDouble(txtResidualShrinkageDyedIndianF.Text);

                if (!string.IsNullOrEmpty(txtPricePrintedIndianF.Text))
                    fq.PricePrintedIndian = Convert.ToDouble(txtPricePrintedIndianF.Text);

                if (!string.IsNullOrEmpty(txtGSMPrintedIndianF.Text))
                    fq.GSMPrintedIndian = Convert.ToDouble(txtGSMPrintedIndianF.Text);

                if (!string.IsNullOrEmpty(txtWidthPrintedIndianF.Text))
                    fq.WidthPrintedIndian = Convert.ToDecimal(txtWidthPrintedIndianF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedIndianF.Text))
                    fq.ResidualShrinkagePrintedIndian = Convert.ToDouble(txtResidualShrinkagePrintedIndianF.Text);

                if (!string.IsNullOrEmpty(txtPriceForDigitalByIndianF.Text))
                    fq.PriceForDigitalByIndian = Convert.ToDouble(txtPriceForDigitalByIndianF.Text);

                if (!string.IsNullOrEmpty(txtGSMDigitalIndianF.Text))
                    fq.GSMDigitalIndian = Convert.ToDouble(txtGSMDigitalIndianF.Text);

                if (!string.IsNullOrEmpty(txtWidthDigitalIndianF.Text))
                    fq.WidthDigitalIndian = Convert.ToDecimal(txtWidthDigitalIndianF.Text);

                if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalIndianF.Text))
                    fq.ResidualShrinkageDigitalIndian = Convert.ToDouble(txtResidualShrinkageDigitalIndianF.Text);

                #endregion 

                //if (!string.IsNullOrEmpty(txtPriceForDyedByAirF.Text))
                //{
                //    fq.PriceForDyedByAir = Convert.ToDouble(txtPriceForDyedByAirF.Text);
                //}

                //if (!string.IsNullOrEmpty(txtPriceForPrintedByAirF.Text))
                //{
                //    fq.PriceForPrintedByAir = Convert.ToDouble(txtPriceForPrintedByAirF.Text);
                //}

                //if (!string.IsNullOrEmpty(txtPriceForGreigeBySeaF.Text))
                //{
                //    fq.PriceForGreigeBySea = Convert.ToDouble(txtPriceForGreigeBySeaF.Text);
                //}

                //if (!string.IsNullOrEmpty(txtPriceForDyedBySeaF.Text))
                //{
                //    fq.PriceForDyedBySea = Convert.ToDouble(txtPriceForDyedBySeaF.Text);
                //}

                

                //if (!string.IsNullOrEmpty(txtPriceForPrintedBySeaF.Text))
                //{
                //    fq.PriceForPrintedBySea = Convert.ToDouble(txtPriceForPrintedBySeaF.Text);
                //}
                            
                //if (!String.IsNullOrEmpty(txtPriceGreigeIndianF.Text))
                //    fq.PriceGreigeIndian = Convert.ToDouble(txtPriceGreigeIndianF.Text);

                //if (!String.IsNullOrEmpty(txtPriceDyedIndianF.Text))
                //    fq.PriceDyedIndian = Convert.ToDouble(txtPriceDyedIndianF.Text);

                //if (!String.IsNullOrEmpty(txtPricePrintedIndianF.Text))
                //    fq.PricePrintedIndian = Convert.ToDouble(txtPricePrintedIndianF.Text);
                
                RadioButton rdofooterfabrictypeReg = (RadioButton)gdvFQDetails.FooterRow.FindControl("rdofooterfabrictypeReg");
                fq.FabricTypeReg_UnReg = rdofooterfabrictypeReg.Checked == true ? "1" : "0";

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

                if (this.FabricQualityControllerInstance.FabricQualityDetail_InsUpdt(fq) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndDetailsGrid(FQMID, rowindex);
                    BIndGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);               
            }

            if (e.CommandName.Equals("Delete"))
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int index = row.RowIndex;
                var script_success = "ShowHideMessageBox(true, '" + "Record deleted successfully." + "');";
                //var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "this trade name currently running you cannot delete." + "');";
                int FabricQualityID = Convert.ToInt32(gdvFQDetails.DataKeys[index].Values[1].ToString());
                if (this.FabricQualityControllerInstance.DeleteFabricQualityDetails(FQMID, FabricQualityID) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndDetailsGrid(FQMID, rowindex);
                    BIndGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }          
        }

        protected void gdvFQDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();

            gdvFQDetails.EditIndex = e.NewEditIndex;
            BIndDetailsGrid(FQMID, rowindex);

            DropDownList ddlSupplierName = (DropDownList)gdvFQDetails.Rows[e.NewEditIndex].FindControl("ddlSupplierName");
            DropDownList ddlOrigin = (DropDownList)gdvFQDetails.Rows[e.NewEditIndex].FindControl("ddlOrigin");
            TextBox txtTestConductedOn = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtTestConductedOn");

            TextBox txtPriceForGreigeByAir = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForGreigeByAir");
            TextBox txtPriceForDyedByAir = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForDyedByAir");
            TextBox txtPriceForPrintedByAir = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForPrintedByAir");
            TextBox txtPriceForGreigeBySea = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForGreigeBySea");
            TextBox txtPriceForDyedBySea = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForDyedBySea");
            TextBox txtPriceForPrintedBySea = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceForPrintedBySea");
            TextBox txtPriceGreigeIndian = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceGreigeIndian");
            TextBox txtPriceDyedIndian = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPriceDyedIndian");
            TextBox txtPricePrintedIndian = (TextBox)gdvFQDetails.Rows[e.NewEditIndex].FindControl("txtPricePrintedIndian");
            HiddenField hiddenSupplier = (HiddenField)gdvFQDetails.Rows[e.NewEditIndex].FindControl("hiddenSupplier");
            HiddenField hiddenOrigin = (HiddenField)gdvFQDetails.Rows[e.NewEditIndex].FindControl("hiddenOrigin");

            RadioButton rdoeditfabrictypeReg = (RadioButton)gdvFQDetails.Rows[e.NewEditIndex].FindControl("rdoeditfabrictypeReg");
            RadioButton rdoeditfabrictypeUnReg = (RadioButton)gdvFQDetails.Rows[e.NewEditIndex].FindControl("rdoeditfabrictypeUnReg");
            //fq.FabricTypeReg_UnReg = rdoeditfabrictypeReg.Checked == true ? "1" : "0";

            var FabricQualityID = Convert.ToInt32(gdvFQDetails.DataKeys[e.NewEditIndex]["FabricQualityID"]);
            objFabricQuality = this.FabricQualityControllerInstance.GetFabricQualityDetails(FQMID, FabricQualityID);

            if (objFabricQuality.Count > 0)
            {
                BindDDLSuplier(ddlSupplierName);
                ddlSupplierName.SelectedValue = objFabricQuality[0].SupplierId.ToString();
                ddlOrigin.SelectedValue = objFabricQuality[0].Origin.ToString();
                hiddenSupplier.Value = objFabricQuality[0].SupplierId.ToString();
                hiddenOrigin.Value = objFabricQuality[0].Origin.ToString();
               

                if (objFabricQuality[0].TestConductedOn != DateTime.MinValue)
                    txtTestConductedOn.Text = (objFabricQuality[0].TestConductedOn).ToString("dd MMM yy (ddd) ");
                else
                    txtTestConductedOn.Text = String.Empty;

                if (objFabricQuality[0].FabricTypeReg_UnReg.ToString() == "Registered Fab")
                    rdoeditfabrictypeReg.Checked = true;
                else
                    rdoeditfabrictypeUnReg.Checked = true;


                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "EnableDisable_GDPD(" + hiddenOrigin.Value + ", " + hiddenSupplier.Value + ")", true);
            }
        }

        protected void gdvFQDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "loadPopupBox();", true);
            if (!Page.IsValid)
                return;
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "EditValidate()", true);

            FabricQuality fq = new FabricQuality();
            string fileID = String.Empty;
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();



            Label lblIdentification = (Label)gdvFQDetails.Rows[e.RowIndex].FindControl("lblIdentification");



            


            DropDownList ddlSupplierName = (DropDownList)gdvFQDetails.Rows[e.RowIndex].FindControl("ddlSupplierName");
            DropDownList ddlOrigin = (DropDownList)gdvFQDetails.Rows[e.RowIndex].FindControl("ddlOrigin");
            TextBox txtSupplierReference = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtSupplierReference");
            TextBox txtQty = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtQty");
            TextBox txtCount = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtCount");
            TextBox txtComposition = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtComposition");
            TextBox txtFabric = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtFabric");
            HiddenField hdnUpdateBaseFilePath = (HiddenField)gdvFQDetails.Rows[e.RowIndex].FindControl("hdnUpdateBaseFilePath");
            FileUpload fileBaseTest = (FileUpload)gdvFQDetails.Rows[e.RowIndex].FindControl("fileBaseTest");
            TextBox txtTestConductedOn = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtTestConductedOn");
            TextBox txtMOQPrint = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtMOQPrint");
            TextBox txtMOQ = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtMOQ");
            HtmlInputHidden hdnFldFilePath = (HtmlInputHidden)gdvFQDetails.Rows[e.RowIndex].FindControl("hdnFldFilePath");
            HtmlInputHidden hdnFldRemarks = (HtmlInputHidden)gdvFQDetails.Rows[e.RowIndex].FindControl("hdnFldRemarks");

            #region Air
            TextBox txtPriceForGreigeByAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForGreigeByAir");
            TextBox txtGSMGreigeAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMGreigeAir");
            TextBox txtWidthGreigeAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthGreigeAir");
            TextBox txtResidualShrinkageGreigeAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageGreigeAir");

            TextBox txtPriceForDyedByAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForDyedByAir");
            TextBox txtGSMDyedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDyedAir");
            TextBox txtWidthDyedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDyedAir");
            TextBox txtResidualShrinkageDyedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDyedAir");

            TextBox txtPriceForPrintedByAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForPrintedByAir");
            TextBox txtGSMPrintedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMPrintedAir");
            TextBox txtWidthPrintedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthPrintedAir");
            TextBox txtResidualShrinkagePrintedAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkagePrintedAir");

            TextBox txtPriceForDigitalByAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForDigitalByAir");
            TextBox txtGSMDigitalAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDigitalAir");
            TextBox txtWidthDigitalAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDigitalAir");
            TextBox txtResidualShrinkageDigitalAir = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDigitalAir");

            #endregion

            #region Sea
            TextBox txtPriceForGreigeBySea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForGreigeBySea");
            TextBox txtGSMGreigeSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMGreigeSea");
            TextBox txtWidthGreigeSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthGreigeSea");
            TextBox txtResidualShrinkageGreigeSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageGreigeSea");

            TextBox txtPriceForDyedBySea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForDyedBySea");
            TextBox txtGSMDyedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDyedSea");
            TextBox txtWidthDyedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDyedSea");
            TextBox txtResidualShrinkageDyedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDyedSea");

            TextBox txtPriceForPrintedBySea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForPrintedBySea");
            TextBox txtGSMPrintedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMPrintedSea");
            TextBox txtWidthPrintedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthPrintedSea");
            TextBox txtResidualShrinkagePrintedSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkagePrintedSea");

            TextBox txtPriceForDigitalBySea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForDigitalBySea");
            TextBox txtGSMDigitalSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDigitalSea");
            TextBox txtWidthDigitalSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDigitalSea");
            TextBox txtResidualShrinkageDigitalSea = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDigitalSea");

            #endregion

            #region Indian
            TextBox txtPriceGreigeIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceGreigeIndian");
            TextBox txtGSMGreigeIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMGreigeIndian");
            TextBox txtWidthGreigeIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthGreigeIndian");
            TextBox txtResidualShrinkageGreigeIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageGreigeIndian");

            TextBox txtPriceDyedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceDyedIndian");
            TextBox txtGSMDyedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDyedIndian");
            TextBox txtWidthDyedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDyedIndian");
            TextBox txtResidualShrinkageDyedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDyedIndian");

            TextBox txtPricePrintedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPricePrintedIndian");
            TextBox txtGSMPrintedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMPrintedIndian");
            TextBox txtWidthPrintedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthPrintedIndian");
            TextBox txtResidualShrinkagePrintedIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkagePrintedIndian");

            TextBox txtPriceForDigitalByIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtPriceForDigitalByIndian");
            TextBox txtGSMDigitalIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtGSMDigitalIndian");
            TextBox txtWidthDigitalIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtWidthDigitalIndian");
            TextBox txtResidualShrinkageDigitalIndian = (TextBox)gdvFQDetails.Rows[e.RowIndex].FindControl("txtResidualShrinkageDigitalIndian");

            #endregion

            fq.FQMasterID = FQMID;
            fq.FabricQualityID = Convert.ToInt32(gdvFQDetails.DataKeys[e.RowIndex]["FabricQualityID"]);
            fq.SupplierReference = txtSupplierReference.Text;
            fq.CountConstruction = txtCount.Text;


            if (!string.IsNullOrEmpty(ddlOrigin.SelectedValue))
                fq.Origin = Convert.ToInt32(ddlOrigin.SelectedValue);
            if (!string.IsNullOrEmpty(txtComposition.Text))
                fq.Composition = txtComposition.Text;
            else
                fq.Composition = string.Empty;

            if (fileBaseTest.HasFile)
                fileID = FileHelper.SaveFile(fileBaseTest.PostedFile.InputStream, fileBaseTest.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

            if (fileID != string.Empty)
                fq.UpdateBaseTestFile = fileID;
            else
            {
                fq.UpdateBaseTestFile = hdnUpdateBaseFilePath.Value;
            }

            if (!string.IsNullOrEmpty(txtTestConductedOn.Text))
            {
                fq.TestConductedOn = DateHelper.ParseDate(txtTestConductedOn.Text).Value;
            }

            if (!string.IsNullOrEmpty(txtMOQ.Text))
            {
                fq.MinimumOrderQuantity = Convert.ToDouble(txtMOQ.Text);
            }
            fq.Fabric = txtFabric.Text;
            fq.Identification = lblIdentification.Text;
            fq.SupplierId = Convert.ToInt32(ddlSupplierName.SelectedValue);

            //if (String.IsNullOrEmpty(hdnFldRemarksF.Value))
            fq.Comments = hdnFldRemarks.Value;
            //else
            //    fq.Comments = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName + " (" + DateTime.Today.ToString("dd MMM") + ")" + " " + " : " + hdnFldRemarksF.Value;
            if (!string.IsNullOrEmpty(txtQty.Text.Trim()))
            {
                fq.MinStockQuality = Convert.ToInt32(txtQty.Text.Trim());
            }
            else
                fq.MinStockQuality = null;

            if (!string.IsNullOrEmpty(txtMOQPrint.Text))
            {
                fq.MOQPrint = Convert.ToDouble(txtMOQPrint.Text);
            }

            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                fq.MinStockQuality = Convert.ToInt32(txtQty.Text);
            }
            fq.FilePath = hdnFldFilePath.Value;
            if (!string.IsNullOrEmpty(txtTestConductedOn.Text))
            {
                fq.ApprovedOn = DateHelper.ParseDate(txtApprovedOn.Text).Value;
            }

            #region Air
            if (!string.IsNullOrEmpty(txtPriceForGreigeByAir.Text))
                fq.PriceForGreigeByAir = Convert.ToDouble(txtPriceForGreigeByAir.Text);

            if (!string.IsNullOrEmpty(txtGSMGreigeAir.Text))
                fq.GSMGreigeAir = Convert.ToDouble(txtGSMGreigeAir.Text);

            if (!string.IsNullOrEmpty(txtWidthGreigeAir.Text))
                fq.WidthGreigeAir = Convert.ToDecimal(txtWidthGreigeAir.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeAir.Text))
                fq.ResidualShrinkageGreigeAir = Convert.ToDouble(txtResidualShrinkageGreigeAir.Text);

            if (!string.IsNullOrEmpty(txtPriceForDyedByAir.Text))
                fq.PriceForDyedByAir = Convert.ToDouble(txtPriceForDyedByAir.Text);

            if (!string.IsNullOrEmpty(txtGSMDyedAir.Text))
                fq.GSMDyedAir = Convert.ToDouble(txtGSMDyedAir.Text);

            if (!string.IsNullOrEmpty(txtWidthDyedAir.Text))
                fq.WidthDyedAir = Convert.ToDecimal(txtWidthDyedAir.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDyedAir.Text))
                fq.ResidualShrinkageDyedAir = Convert.ToDouble(txtResidualShrinkageDyedAir.Text);

            if (!string.IsNullOrEmpty(txtPriceForPrintedByAir.Text))
                fq.PriceForPrintedByAir = Convert.ToDouble(txtPriceForPrintedByAir.Text);

            if (!string.IsNullOrEmpty(txtGSMPrintedAir.Text))
                fq.GSMPrintedAir = Convert.ToDouble(txtGSMPrintedAir.Text);

            if (!string.IsNullOrEmpty(txtWidthPrintedAir.Text))
                fq.WidthPrintedAir = Convert.ToDecimal(txtWidthPrintedAir.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedAir.Text))
                fq.ResidualShrinkagePrintedAir = Convert.ToDouble(txtResidualShrinkagePrintedAir.Text);

            if (!string.IsNullOrEmpty(txtPriceForDigitalByAir.Text))
                fq.PriceForDigitalByAir = Convert.ToDouble(txtPriceForDigitalByAir.Text);

            if (!string.IsNullOrEmpty(txtGSMDigitalAir.Text))
                fq.GSMDigitalAir = Convert.ToDouble(txtGSMDigitalAir.Text);

            if (!string.IsNullOrEmpty(txtWidthDigitalAir.Text))
                fq.WidthDigitalAir = Convert.ToDecimal(txtWidthDigitalAir.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalAir.Text))
                fq.ResidualShrinkageDigitalAir = Convert.ToDouble(txtResidualShrinkageDigitalAir.Text);

            #endregion

            #region Sea
            if (!string.IsNullOrEmpty(txtPriceForGreigeBySea.Text))
                fq.PriceForGreigeBySea = Convert.ToDouble(txtPriceForGreigeBySea.Text);

            if (!string.IsNullOrEmpty(txtGSMGreigeSea.Text))
                fq.GSMGreigeSea = Convert.ToDouble(txtGSMGreigeSea.Text);

            if (!string.IsNullOrEmpty(txtWidthGreigeSea.Text))
                fq.WidthGreigeSea = Convert.ToDecimal(txtWidthGreigeSea.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeSea.Text))
                fq.ResidualShrinkageGreigeSea = Convert.ToDouble(txtResidualShrinkageGreigeSea.Text);

            if (!string.IsNullOrEmpty(txtPriceForDyedBySea.Text))
                fq.PriceForDyedBySea = Convert.ToDouble(txtPriceForDyedBySea.Text);

            if (!string.IsNullOrEmpty(txtGSMDyedSea.Text))
                fq.GSMDyedSea = Convert.ToDouble(txtGSMDyedSea.Text);

            if (!string.IsNullOrEmpty(txtWidthDyedSea.Text))
                fq.WidthDyedSea = Convert.ToDecimal(txtWidthDyedSea.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDyedSea.Text))
                fq.ResidualShrinkageDyedSea = Convert.ToDouble(txtResidualShrinkageDyedSea.Text);

            if (!string.IsNullOrEmpty(txtPriceForPrintedBySea.Text))
                fq.PriceForPrintedBySea = Convert.ToDouble(txtPriceForPrintedBySea.Text);

            if (!string.IsNullOrEmpty(txtGSMPrintedSea.Text))
                fq.GSMPrintedSea = Convert.ToDouble(txtGSMPrintedSea.Text);

            if (!string.IsNullOrEmpty(txtWidthPrintedSea.Text))
                fq.WidthPrintedSea = Convert.ToDecimal(txtWidthPrintedSea.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedSea.Text))
                fq.ResidualShrinkagePrintedSea = Convert.ToDouble(txtResidualShrinkagePrintedSea.Text);

            if (!string.IsNullOrEmpty(txtPriceForDigitalBySea.Text))
                fq.PriceForDigitalBySea = Convert.ToDouble(txtPriceForDigitalBySea.Text);

            if (!string.IsNullOrEmpty(txtGSMDigitalSea.Text))
                fq.GSMDigitalSea = Convert.ToDouble(txtGSMDigitalSea.Text);

            if (!string.IsNullOrEmpty(txtWidthDigitalSea.Text))
                fq.WidthDigitalSea = Convert.ToDecimal(txtWidthDigitalSea.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalSea.Text))
                fq.ResidualShrinkageDigitalSea = Convert.ToDouble(txtResidualShrinkageDigitalSea.Text);

            #endregion

            #region Indian
            if (!string.IsNullOrEmpty(txtPriceGreigeIndian.Text))
                fq.PriceGreigeIndian = Convert.ToDouble(txtPriceGreigeIndian.Text);

            if (!string.IsNullOrEmpty(txtGSMGreigeIndian.Text))
                fq.GSMGreigeIndian = Convert.ToDouble(txtGSMGreigeIndian.Text);

            if (!string.IsNullOrEmpty(txtWidthGreigeIndian.Text))
                fq.WidthGreigeIndian = Convert.ToDecimal(txtWidthGreigeIndian.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageGreigeIndian.Text))
                fq.ResidualShrinkageGreigeIndian = Convert.ToDouble(txtResidualShrinkageGreigeIndian.Text);

            if (!string.IsNullOrEmpty(txtPriceDyedIndian.Text))
                fq.PriceDyedIndian = Convert.ToDouble(txtPriceDyedIndian.Text);

            if (!string.IsNullOrEmpty(txtGSMDyedIndian.Text))
                fq.GSMDyedIndian = Convert.ToDouble(txtGSMDyedIndian.Text);

            if (!string.IsNullOrEmpty(txtWidthDyedIndian.Text))
                fq.WidthDyedIndian = Convert.ToDecimal(txtWidthDyedIndian.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDyedIndian.Text))
                fq.ResidualShrinkageDyedIndian = Convert.ToDouble(txtResidualShrinkageDyedIndian.Text);

            if (!string.IsNullOrEmpty(txtPricePrintedIndian.Text))
                fq.PricePrintedIndian = Convert.ToDouble(txtPricePrintedIndian.Text);

            if (!string.IsNullOrEmpty(txtGSMPrintedIndian.Text))
                fq.GSMPrintedIndian = Convert.ToDouble(txtGSMPrintedIndian.Text);

            if (!string.IsNullOrEmpty(txtWidthPrintedIndian.Text))
                fq.WidthPrintedIndian = Convert.ToDecimal(txtWidthPrintedIndian.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkagePrintedIndian.Text))
                fq.ResidualShrinkagePrintedIndian = Convert.ToDouble(txtResidualShrinkagePrintedIndian.Text);

            if (!string.IsNullOrEmpty(txtPriceForDigitalByIndian.Text))
                fq.PriceForDigitalByIndian = Convert.ToDouble(txtPriceForDigitalByIndian.Text);

            if (!string.IsNullOrEmpty(txtGSMDigitalIndian.Text))
                fq.GSMDigitalIndian = Convert.ToDouble(txtGSMDigitalIndian.Text);

            if (!string.IsNullOrEmpty(txtWidthDigitalIndian.Text))
                fq.WidthDigitalIndian = Convert.ToDecimal(txtWidthDigitalIndian.Text);

            if (!string.IsNullOrEmpty(txtResidualShrinkageDigitalIndian.Text))
                fq.ResidualShrinkageDigitalIndian = Convert.ToDouble(txtResidualShrinkageDigitalIndian.Text);

            #endregion 
            
            RadioButton rdoeditfabrictypeReg = (RadioButton)gdvFQDetails.Rows[e.RowIndex].FindControl("rdoeditfabrictypeReg");
            fq.FabricTypeReg_UnReg = rdoeditfabrictypeReg.Checked == true ? "1" : "0";
            var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

            if (this.FabricQualityControllerInstance.FabricQualityDetail_InsUpdt(fq) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                gdvFQDetails.EditIndex = -1;
                BIndDetailsGrid(FQMID, rowindex);
                BIndGrid();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);           
        }

        #endregion

        public static DataTable ToDataTable<FabricQuality>(List<FabricQuality> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(FabricQuality));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            return table;
        }
        public void BindDDLSuplier(DropDownList ddlSuplier)
        {
            ddlSuplier.DataSource = this.FabricQualityControllerInstance.GetSuplier(Convert.ToInt32(ViewState["FQMID"].ToString()),1);
            ddlSuplier.DataTextField = "Name";
            ddlSuplier.DataValueField = "SupplierId";
            ddlSuplier.DataBind();
        }

        protected void gdvFQDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void gdvFQDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string fileID = String.Empty;
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string FQMID = ViewState["FQMID"].ToString();
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   

                    //Finding textbox
                     Label lblIdentification = (Label)e.Row.FindControl("lblIdentification");
                    //--air-------------------------------------------------------------------------------//
                     Label lblPriceForGreigeByAir = (Label)e.Row.FindControl("lblPriceForGreigeByAir");
                     Label lblPriceForDyedByAir = (Label)e.Row.FindControl("lblPriceForDyedByAir");
                     Label lblPriceForPrintedByAir = (Label)e.Row.FindControl("lblPriceForPrintedByAir");
                     Label lblPriceForDigitalByAir = (Label)e.Row.FindControl("lblPriceForDigitalByAir");


                     //TextBox txtPriceForGreigeByAir = (TextBox)e.Row.FindControl("txtPriceForGreigeByAir");
                     //TextBox txtPriceForDyedByAir = (TextBox)e.Row.FindControl("txtPriceForDyedByAir");
                     //TextBox txtPriceForPrintedByAir = (TextBox)e.Row.FindControl("txtPriceForPrintedByAir");
                     //TextBox txtPriceForDigitalByAir = (TextBox)e.Row.FindControl("txtPriceForDigitalByAir");

                     //--sea-------------------------------------------------------------------------------//
                     Label lblPriceForGreigeBySea = (Label)e.Row.FindControl("lblPriceForGreigeBySea");
                     Label lblPriceForDyedBySea = (Label)e.Row.FindControl("lblPriceForDyedBySea");
                     Label lblPriceForPrintedBySea = (Label)e.Row.FindControl("lblPriceForPrintedBySea");
                     Label lblPriceForDigitalBySea = (Label)e.Row.FindControl("lblPriceForDigitalBySea");


                     //TextBox txtPriceForGreigeBySea = (TextBox)e.Row.FindControl("txtPriceForGreigeBySea");
                     //TextBox txtPriceForDyedBySea = (TextBox)e.Row.FindControl("txtPriceForDyedBySea");
                     //TextBox txtPriceForPrintedBySea = (TextBox)e.Row.FindControl("txtPriceForPrintedBySea");
                     //TextBox txtPriceForDigitalBySea = (TextBox)e.Row.FindControl("txtPriceForDigitalBySea");

                     //--sea-------------------------------------------------------------------------------//
                     Label lblPriceForGreigeByIndian = (Label)e.Row.FindControl("lblPriceForGreigeByIndian");
                     Label lblPriceDyedIndian = (Label)e.Row.FindControl("lblPriceDyedIndian");
                     Label lblPricePrintedIndian = (Label)e.Row.FindControl("lblPricePrintedIndian");
                     Label lblPriceForDigitalByIndian = (Label)e.Row.FindControl("lblPriceForDigitalByIndian");


                     //TextBox txtPriceGreigeIndian = (TextBox)e.Row.FindControl("txtPriceGreigeIndian");
                     //TextBox txtPriceDyedIndian = (TextBox)e.Row.FindControl("txtPriceDyedIndian");
                     //TextBox txtPricePrintedIndian = (TextBox)e.Row.FindControl("txtPricePrintedIndian");
                     //TextBox txtPriceForDigitalByIndian = (TextBox)e.Row.FindControl("txtPriceForDigitalByIndian");


                     objFabricQuality = this.FabricQualityControllerInstance.GetFabricQualityDetails_history(FQMID, 0, lblIdentification.Text);
                     lblPriceForGreigeByAir.ToolTip = objFabricQuality[0].PriceForGreigeByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByAir_old.ToString();
                     lblPriceForDyedByAir.ToolTip = objFabricQuality[0].PriceForDyedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByAir_old.ToString();
                     lblPriceForPrintedByAir.ToolTip = objFabricQuality[0].PriceForPrintedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByAir_old.ToString();
                     lblPriceForDigitalByAir.ToolTip = objFabricQuality[0].PriceForDigitalByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByAir_old.ToString();

                      //txtPriceForGreigeByAir.ToolTip = objFabricQuality[0].PriceForGreigeByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByAir_old.ToString();
                      //txtPriceForDyedByAir.ToolTip = objFabricQuality[0].PriceForDyedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByAir_old.ToString();
                      //txtPriceForPrintedByAir.ToolTip = objFabricQuality[0].PriceForPrintedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByAir_old.ToString();
                      //txtPriceForDigitalByAir.ToolTip = objFabricQuality[0].PriceForDigitalByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByAir_old.ToString();

                    //sea----
                      lblPriceForGreigeBySea.ToolTip = objFabricQuality[0].PriceForGreigeBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeBySea_old.ToString();
                      lblPriceForDyedBySea.ToolTip = objFabricQuality[0].PriceForDyedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedBySea_old.ToString();
                      lblPriceForPrintedBySea.ToolTip = objFabricQuality[0].PriceForPrintedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedBySea_old.ToString();
                      lblPriceForDigitalBySea.ToolTip = objFabricQuality[0].PriceForDigitalBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalBySea_old.ToString();

                      //txtPriceForGreigeBySea.ToolTip = objFabricQuality[0].PriceForGreigeBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeBySea_old.ToString();
                      //txtPriceForDyedBySea.ToolTip = objFabricQuality[0].PriceForDyedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedBySea_old.ToString();
                      //txtPriceForPrintedBySea.ToolTip = objFabricQuality[0].PriceForPrintedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedBySea_old.ToString();
                      //txtPriceForDigitalBySea.ToolTip = objFabricQuality[0].PriceForDigitalBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalBySea_old.ToString();

                    //indian--
                      lblPriceForGreigeByIndian.ToolTip = objFabricQuality[0].PriceForGreigeByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByIndian_old.ToString();

                      lblPriceDyedIndian.ToolTip = objFabricQuality[0].PriceForDyedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByIndian_old.ToString();
                      lblPricePrintedIndian.ToolTip = objFabricQuality[0].PriceForPrintedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByIndian_old.ToString();

                      lblPriceForDigitalByIndian.ToolTip = objFabricQuality[0].PriceForDigitalByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByIndian_old.ToString();


                      //txtPriceGreigeIndian.ToolTip = objFabricQuality[0].PriceForGreigeByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByIndian_old.ToString();
                      //txtPriceDyedIndian.ToolTip = objFabricQuality[0].PriceForDyedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByIndian_old.ToString();
                      //txtPricePrintedIndian.ToolTip = objFabricQuality[0].PriceForPrintedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByIndian_old.ToString();
                      //txtPriceForDigitalByIndian.ToolTip = objFabricQuality[0].PriceForDigitalByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByIndian_old.ToString();

                      if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                      {
                          Label lblIdentifications = (Label)e.Row.FindControl("lblIdentifications");
                          TextBox txtPriceForGreigeByAir = (TextBox)e.Row.FindControl("txtPriceForGreigeByAir");
                          TextBox txtPriceForDyedByAir = (TextBox)e.Row.FindControl("txtPriceForDyedByAir");
                          TextBox txtPriceForPrintedByAir = (TextBox)e.Row.FindControl("txtPriceForPrintedByAir");
                          TextBox txtPriceForDigitalByAir = (TextBox)e.Row.FindControl("txtPriceForDigitalByAir");

                          TextBox txtPriceForGreigeBySea = (TextBox)e.Row.FindControl("txtPriceForGreigeBySea");
                          TextBox txtPriceForDyedBySea = (TextBox)e.Row.FindControl("txtPriceForDyedBySea");
                          TextBox txtPriceForPrintedBySea = (TextBox)e.Row.FindControl("txtPriceForPrintedBySea");
                          TextBox txtPriceForDigitalBySea = (TextBox)e.Row.FindControl("txtPriceForDigitalBySea");

                          TextBox txtPriceGreigeIndian = (TextBox)e.Row.FindControl("txtPriceGreigeIndian");
                          TextBox txtPriceDyedIndian = (TextBox)e.Row.FindControl("txtPriceDyedIndian");
                          TextBox txtPricePrintedIndian = (TextBox)e.Row.FindControl("txtPricePrintedIndian");
                          TextBox txtPriceForDigitalByIndian = (TextBox)e.Row.FindControl("txtPriceForDigitalByIndian");

                          objFabricQuality = this.FabricQualityControllerInstance.GetFabricQualityDetails_history(FQMID, 0, lblIdentifications.Text);


                          txtPriceForGreigeByAir.ToolTip = objFabricQuality[0].PriceForGreigeByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByAir_old.ToString();
                          txtPriceForDyedByAir.ToolTip = objFabricQuality[0].PriceForDyedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByAir_old.ToString();
                          txtPriceForPrintedByAir.ToolTip = objFabricQuality[0].PriceForPrintedByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByAir_old.ToString();
                          txtPriceForDigitalByAir.ToolTip = objFabricQuality[0].PriceForDigitalByAir_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByAir_old.ToString();

                          //sea----


                          txtPriceForGreigeBySea.ToolTip = objFabricQuality[0].PriceForGreigeBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeBySea_old.ToString();
                          txtPriceForDyedBySea.ToolTip = objFabricQuality[0].PriceForDyedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedBySea_old.ToString();
                          txtPriceForPrintedBySea.ToolTip = objFabricQuality[0].PriceForPrintedBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedBySea_old.ToString();
                          txtPriceForDigitalBySea.ToolTip = objFabricQuality[0].PriceForDigitalBySea_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalBySea_old.ToString();

                          //indian--



                          txtPriceGreigeIndian.ToolTip = objFabricQuality[0].PriceForGreigeByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForGreigeByIndian_old.ToString();
                          txtPriceDyedIndian.ToolTip = objFabricQuality[0].PriceForDyedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDyedByIndian_old.ToString();
                          txtPricePrintedIndian.ToolTip = objFabricQuality[0].PriceForPrintedByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForPrintedByIndian_old.ToString();
                          txtPriceForDigitalByIndian.ToolTip = objFabricQuality[0].PriceForDigitalByIndian_old == 0 ? "" : "Old Rate " + objFabricQuality[0].PriceForDigitalByIndian_old.ToString();



                      }
                    
                }
                

            }
            catch
            {

            }
        }
    }
}
