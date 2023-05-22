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
    public partial class AQ : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // test
            BindControls();
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }
        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.ACCESSORY_QUALITY));
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
            string AccsessoryType = ddlAcctype.SelectedValue;

            DataTable dt = this.AccessoryQualityControllerInstance.GetAccessoryQualityMaster(SearchItem, GroupID, SubGroupID, TradeName, UnitID, Origin, AccsessoryType).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gdvAQMaster.DataSource = dt;
                gdvAQMaster.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gdvAQMaster.DataSource = dt;
                gdvAQMaster.DataBind();
                int TotalColumn = gdvAQMaster.Rows[0].Cells.Count;
                gdvAQMaster.Rows[0].Cells.Clear();
                gdvAQMaster.Rows[0].Cells.Add(new TableCell());
                gdvAQMaster.Rows[0].Cells[0].ColumnSpan = TotalColumn;
                gdvAQMaster.Rows[0].Cells[0].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                gdvAQMaster.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            DropDownList ddlFooterGroup = (DropDownList)gdvAQMaster.FooterRow.FindControl("ddlFooterGroup");
            DropdownHelper.BindParentCategories(ddlFooterGroup, Convert.ToInt32(CategoryType.ACCESSORY_QUALITY));
        }

        private void BIndDetailsGrid(string AQMID, int rowindex)
        {
            List<AccessoryQuality> objAccessoryQuality = new List<AccessoryQuality>();
            objAccessoryQuality = this.AccessoryQualityControllerInstance.GetAccessoryQualityDetails(AQMID, 0);
            if (objAccessoryQuality.Count > 0)
            {
                gdvAQDetails.DataSource = objAccessoryQuality;
                gdvAQDetails.DataBind();
                txtApprovedOn.Text = objAccessoryQuality[0].ApprovedOn.ToString("dd MMM yy (ddd) ");
            }
            else
            {
                DataTable dt = ToDataTable(objAccessoryQuality);
                dt.Rows.Add(dt.NewRow());
                gdvAQDetails.DataSource = dt;
                gdvAQDetails.DataBind();
                int TotalColumn = gdvAQDetails.Rows[0].Cells.Count;
                gdvAQDetails.Rows[0].Cells.Clear();
                gdvAQDetails.Rows[0].Cells.Add(new TableCell());
                gdvAQDetails.Rows[0].Cells[0].ColumnSpan = TotalColumn;
                gdvAQDetails.Rows[0].Cells[0].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
                gdvAQDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                txtApprovedOn.Text = DateTime.Now.ToString("dd MMM yy (ddd) ");
            }

            DropDownList ddlSupplierNameF = (DropDownList)gdvAQDetails.FooterRow.FindControl("ddlSupplierNameF");
            BindDDLSuplier(ddlSupplierNameF);
            Label lblIdentificationF = (Label)gdvAQDetails.FooterRow.FindControl("lblIdentificationF");
            HiddenField hdnfGroupID = (HiddenField)gdvAQMaster.Rows[rowindex].FindControl("hdnfGroupID");
            HiddenField hdnfSubGroup = (HiddenField)gdvAQMaster.Rows[rowindex].FindControl("hdnfSubGroup");
            lblIdentificationF.Text = this.CommonControllerInstance.GetIdentification(Convert.ToInt32(hdnfGroupID.Value), Convert.ToInt32(hdnfSubGroup.Value), 2);
        }

        protected void gdvAQMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AccessoryQuality AQM = new AccessoryQuality();
            if (e.CommandName.Equals("Insert"))
            {

                DropDownList ddlFooterGroup = (DropDownList)gdvAQMaster.FooterRow.FindControl("ddlFooterGroup");
                HiddenField hiddenSubGroupFooterId = (HiddenField)gdvAQMaster.FooterRow.FindControl("hiddenSubGroupFooterId");
                DropDownList ddlFooterUnit = (DropDownList)gdvAQMaster.FooterRow.FindControl("ddlFooterUnit");
                TextBox txtFooterTradeName = (TextBox)gdvAQMaster.FooterRow.FindControl("txtFooterTradeName");
                AQM.AQMasterID = "0";
                AQM.CategoryId = Convert.ToInt32(ddlFooterGroup.SelectedValue);
                AQM.SubCategoryId = Convert.ToInt32(hiddenSubGroupFooterId.Value);
                AQM.TradeName = txtFooterTradeName.Text.Trim();
                AQM.StockUnit = Convert.ToInt32(ddlFooterUnit.SelectedValue);

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                try
                {
                    if (this.AccessoryQualityControllerInstance.AccessoryQualityMaster_InsUpdt(AQM) > 0)
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
                //string AccessoryMaster_ID = gdvAQMaster.DataKeys[rowindex]["AccessoryMaster_ID"].ToString();
                string AQMID = gdvAQMaster.DataKeys[rowindex]["AccessoryMaster_ID"].ToString();
                ViewState["rowindex"] = rowindex;
                ViewState["AQMID"] = AQMID;
                BIndDetailsGrid(AQMID, rowindex);
            }
        }

        protected void gdvAQMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAQMaster.PageIndex = e.NewPageIndex;
            BIndGrid();
        }

        protected void lkbGo_Click(object sender, EventArgs e)
        {
            BIndGrid();
            gdvAQDetails.DataSource = null;
            gdvAQDetails.DataBind();
            DropdownHelper.BindSubCategories(ddlSubGroup, Convert.ToInt32(ddlGroup.SelectedValue));
            ddlSubGroup.SelectedValue = hiddenSubGroupId.Value;
        }

        protected void gdvAQMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvAQMaster.EditIndex = e.NewEditIndex;
            BIndGrid();
            TextBox txtTradeName = (TextBox)gdvAQMaster.Rows[e.NewEditIndex].FindControl("txtTradeName");
            DropDownList ddlGroup = (DropDownList)gdvAQMaster.Rows[e.NewEditIndex].FindControl("ddlGroup");
            DropDownList ddlSubGroup = (DropDownList)gdvAQMaster.Rows[e.NewEditIndex].FindControl("ddlSubGroup");
            DropDownList ddlUnit = (DropDownList)gdvAQMaster.Rows[e.NewEditIndex].FindControl("ddlUnit");

            var AccessoryMaster_ID = gdvAQMaster.DataKeys[e.NewEditIndex]["AccessoryMaster_ID"].ToString();
            DataTable dt = this.AccessoryQualityControllerInstance.AccessoryQualityMasterEdit(AccessoryMaster_ID.ToString());
            if (dt.Rows.Count > 0)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.ACCESSORY_QUALITY));
                ddlGroup.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                txtTradeName.Text = dt.Rows[0]["TradeName"].ToString();
                ddlUnit.SelectedValue = dt.Rows[0]["Unit"].ToString();

                DropdownHelper.BindSubCategories(ddlSubGroup, Convert.ToInt32(ddlGroup.SelectedValue));
                ddlSubGroup.SelectedValue = dt.Rows[0]["SubCategoryId"].ToString();

            }
        }

        protected void gdvAQMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvAQMaster.EditIndex = -1;
            BIndGrid();
        }

        protected void gdvAQMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (!Page.IsValid)
                return;
            AccessoryQuality AQM = new AccessoryQuality();
            var AccessoryMaster_ID = gdvAQMaster.DataKeys[e.RowIndex]["AccessoryMaster_ID"].ToString();
            TextBox txtTradeName = (TextBox)gdvAQMaster.Rows[e.RowIndex].FindControl("txtTradeName");
            DropDownList ddlGroup = (DropDownList)gdvAQMaster.Rows[e.RowIndex].FindControl("ddlGroup");
            DropDownList ddlSubGroup = (DropDownList)gdvAQMaster.Rows[e.RowIndex].FindControl("ddlSubGroup");
            DropDownList ddlUnit = (DropDownList)gdvAQMaster.Rows[e.RowIndex].FindControl("ddlUnit");
            var hiddenSubGroupIdGrid = (HiddenField)gdvAQMaster.Rows[e.RowIndex].FindControl("hiddenSubGroupIdGrid");

            AQM.AQMasterID = AccessoryMaster_ID;
            AQM.CategoryId = Convert.ToInt32(ddlGroup.SelectedValue);
            if (Convert.ToInt32(ddlSubGroup.SelectedValue) > 0)
                AQM.SubCategoryId = Convert.ToInt32(ddlSubGroup.SelectedValue);
            else
                AQM.SubCategoryId = Convert.ToInt32(hiddenSubGroupIdGrid.Value);
            AQM.TradeName = txtTradeName.Text.Trim();
            AQM.StockUnit = Convert.ToInt32(ddlUnit.SelectedValue);

            var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
            try
            {
                if (this.AccessoryQualityControllerInstance.AccessoryQualityMaster_InsUpdt(AQM) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    gdvAQMaster.EditIndex = -1;
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


        #region Accessory Details

        protected void gdvAQDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string AQMID = ViewState["AQMID"].ToString();
            gdvAQDetails.PageIndex = e.NewPageIndex;
            BIndDetailsGrid(AQMID, rowindex);
        }

        protected void gdvAQDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string AQMID = ViewState["AQMID"].ToString();
            gdvAQDetails.EditIndex = -1;
            BIndDetailsGrid(AQMID, rowindex);
        }

        protected void gdvAQDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AccessoryQuality aq = new AccessoryQuality();
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string AQMID = ViewState["AQMID"].ToString();
            string fileID = String.Empty;

            if (e.CommandName.Equals("Insert"))
            {
                if (!Page.IsValid)
                    return;

                Label lblIdentificationF = (Label)gdvAQDetails.FooterRow.FindControl("lblIdentificationF");
                DropDownList ddlSupplierNameF = (DropDownList)gdvAQDetails.FooterRow.FindControl("ddlSupplierNameF");
                DropDownList ddlOriginF = (DropDownList)gdvAQDetails.FooterRow.FindControl("ddlOriginF");
                TextBox txtSupplierReferenceF = (TextBox)gdvAQDetails.FooterRow.FindControl("txtSupplierReferenceF");
                TextBox txtLeadTimeF = (TextBox)gdvAQDetails.FooterRow.FindControl("txtLeadTimeF");
                HiddenField hdnUpdateBaseFilePathF = (HiddenField)gdvAQDetails.FooterRow.FindControl("hdnUpdateBaseFilePathF");
                FileUpload fileBaseTestF = (FileUpload)gdvAQDetails.FooterRow.FindControl("fileBaseTestF");
                TextBox txtTestConductedOnF = (TextBox)gdvAQDetails.FooterRow.FindControl("txtTestConductedOnF");
                TextBox txtMOQF = (TextBox)gdvAQDetails.FooterRow.FindControl("txtMOQF");
                TextBox txtPriceF = (TextBox)gdvAQDetails.FooterRow.FindControl("txtPriceF");
                HtmlInputHidden hdnFldFilePathF = (HtmlInputHidden)gdvAQDetails.FooterRow.FindControl("hdnFldFilePathF");

                aq.AQMasterID = AQMID;
                aq.AccessoryQualityID = 0;
                aq.SupplierReference = txtSupplierReferenceF.Text;

                if (!string.IsNullOrEmpty(ddlOriginF.SelectedValue))
                    aq.Origin = Convert.ToInt32(ddlOriginF.SelectedValue);

                if (fileBaseTestF.HasFile)
                    fileID = FileHelper.SaveFile(fileBaseTestF.PostedFile.InputStream, fileBaseTestF.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

                if (fileID != string.Empty)
                    aq.UploadBaseTestFile = fileID;

                if (!string.IsNullOrEmpty(txtTestConductedOnF.Text))
                {
                    aq.TestConductedOn = DateHelper.ParseDate(txtTestConductedOnF.Text).Value;
                }

                if (!string.IsNullOrEmpty(txtMOQF.Text))
                {
                    aq.MinimumOrderQuality = Convert.ToDouble(txtMOQF.Text);
                }
                if (!string.IsNullOrEmpty(txtLeadTimeF.Text))
                {
                    aq.LeadTime = Convert.ToInt32(txtLeadTimeF.Text);
                }
                aq.Identification = lblIdentificationF.Text;
                aq.SupplierId = Convert.ToInt32(ddlSupplierNameF.SelectedValue);

                aq.FilePath = hdnFldFilePathF.Value;
                if (!string.IsNullOrEmpty(txtApprovedOn.Text))
                {
                    aq.ApprovedOn = DateHelper.ParseDate(txtApprovedOn.Text).Value;
                }

                if (!String.IsNullOrEmpty(txtPriceF.Text))
                    aq.Price = Convert.ToDouble(txtPriceF.Text);

                RadioButton rdoAccsessorytypeReg = (RadioButton)gdvAQDetails.FooterRow.FindControl("rdoAccsessorytypeReg");

                aq.AccTypeReg_UnReg = rdoAccsessorytypeReg.Checked == true ? "1" : "0";

                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

                if (this.AccessoryQualityControllerInstance.AccessoryQualityDetail_InsUpdt(aq) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndDetailsGrid(AQMID, rowindex);
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
                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";
                int AccessoryQualityID = Convert.ToInt32(gdvAQDetails.DataKeys[index].Values[1].ToString());
                if (this.AccessoryQualityControllerInstance.DeleteAccessoryQualityDetails(AQMID, AccessoryQualityID) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    BIndDetailsGrid(AQMID, rowindex);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
        }

        protected void gdvAQDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            List<AccessoryQuality> objAccessoryQuality = new List<AccessoryQuality>();
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string AQMID = ViewState["AQMID"].ToString();

            gdvAQDetails.EditIndex = e.NewEditIndex;
            BIndDetailsGrid(AQMID, rowindex);

            DropDownList ddlSupplierName = (DropDownList)gdvAQDetails.Rows[e.NewEditIndex].FindControl("ddlSupplierName");
            DropDownList ddlOrigin = (DropDownList)gdvAQDetails.Rows[e.NewEditIndex].FindControl("ddlOrigin");
            TextBox txtTestConductedOn = (TextBox)gdvAQDetails.Rows[e.NewEditIndex].FindControl("txtTestConductedOn");
            RadioButton rdoeditAccsessorytypeReg = (RadioButton)gdvAQDetails.Rows[e.NewEditIndex].FindControl("rdoeditAccsessorytypeReg");
            RadioButton rdoeditAccsessorytypeUnReg = (RadioButton)gdvAQDetails.Rows[e.NewEditIndex].FindControl("rdoeditAccsessorytypeUnReg");

            var AccessoryQualityID = Convert.ToInt32(gdvAQDetails.DataKeys[e.NewEditIndex]["AccessoryQualityID"]);
            objAccessoryQuality = this.AccessoryQualityControllerInstance.GetAccessoryQualityDetails(AQMID, AccessoryQualityID);

            if (objAccessoryQuality.Count > 0)
            {
                BindDDLSuplier(ddlSupplierName);
                ddlSupplierName.SelectedValue = objAccessoryQuality[0].SupplierId.ToString();
                ddlOrigin.SelectedValue = objAccessoryQuality[0].Origin.ToString();

                if (objAccessoryQuality[0].TestConductedOn != DateTime.MinValue)
                    txtTestConductedOn.Text = (objAccessoryQuality[0].TestConductedOn).ToString("dd MMM yy (ddd) ");
                else
                    txtTestConductedOn.Text = String.Empty;

                if (objAccessoryQuality[0].AccTypeReg_UnReg == "Registered Acc")
                    rdoeditAccsessorytypeReg.Checked = true;
                else
                    rdoeditAccsessorytypeUnReg.Checked = true;
            }
        }

        protected void gdvAQDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "loadPopupBox();", true);
            if (!Page.IsValid)
                return;
            AccessoryQuality aq = new AccessoryQuality();
            string fileID = String.Empty;
            int rowindex = Convert.ToInt32(ViewState["rowindex"]);
            string AQMID = ViewState["AQMID"].ToString();

            Label lblIdentification = (Label)gdvAQDetails.Rows[e.RowIndex].FindControl("lblIdentification");
            DropDownList ddlSupplierName = (DropDownList)gdvAQDetails.Rows[e.RowIndex].FindControl("ddlSupplierName");
            DropDownList ddlOrigin = (DropDownList)gdvAQDetails.Rows[e.RowIndex].FindControl("ddlOrigin");
            TextBox txtSupplierReference = (TextBox)gdvAQDetails.Rows[e.RowIndex].FindControl("txtSupplierReference");
            TextBox txtLeadTime = (TextBox)gdvAQDetails.Rows[e.RowIndex].FindControl("txtLeadTime");
            HiddenField hdnUpdateBaseFilePath = (HiddenField)gdvAQDetails.Rows[e.RowIndex].FindControl("hdnUpdateBaseFilePath");
            FileUpload fileBaseTest = (FileUpload)gdvAQDetails.Rows[e.RowIndex].FindControl("fileBaseTest");
            TextBox txtTestConductedOn = (TextBox)gdvAQDetails.Rows[e.RowIndex].FindControl("txtTestConductedOn");
            TextBox txtMOQ = (TextBox)gdvAQDetails.Rows[e.RowIndex].FindControl("txtMOQ");
            TextBox txtPrice = (TextBox)gdvAQDetails.Rows[e.RowIndex].FindControl("txtPrice");
            HtmlInputHidden hdnFldFilePath = (HtmlInputHidden)gdvAQDetails.Rows[e.RowIndex].FindControl("hdnFldFilePath");

            aq.AQMasterID = AQMID;
            aq.AccessoryQualityID = Convert.ToInt32(gdvAQDetails.DataKeys[e.RowIndex]["AccessoryQualityID"]);
            aq.SupplierReference = txtSupplierReference.Text;

            if (!string.IsNullOrEmpty(ddlOrigin.SelectedValue))
                aq.Origin = Convert.ToInt32(ddlOrigin.SelectedValue);


            if (fileBaseTest.HasFile)
                fileID = FileHelper.SaveFile(fileBaseTest.PostedFile.InputStream, fileBaseTest.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

            if (fileID != string.Empty)
                aq.UploadBaseTestFile = fileID;
            else
            {
                aq.UploadBaseTestFile = hdnUpdateBaseFilePath.Value;
            }

            if (!string.IsNullOrEmpty(txtTestConductedOn.Text))
            {
                aq.TestConductedOn = DateHelper.ParseDate(txtTestConductedOn.Text).Value;
            }

            if (!string.IsNullOrEmpty(txtMOQ.Text))
            {
                aq.MinimumOrderQuality = Convert.ToDouble(txtMOQ.Text);
            }
            if (!string.IsNullOrEmpty(txtLeadTime.Text))
            {
                aq.LeadTime = Convert.ToInt32(txtLeadTime.Text);
            }
            aq.Identification = lblIdentification.Text;
            aq.SupplierId = Convert.ToInt32(ddlSupplierName.SelectedValue);

            aq.FilePath = hdnFldFilePath.Value;
            if (!string.IsNullOrEmpty(txtApprovedOn.Text))
            {
                aq.ApprovedOn = DateHelper.ParseDate(txtApprovedOn.Text).Value;
            }

            if (!String.IsNullOrEmpty(txtPrice.Text))
                aq.Price = Convert.ToDouble(txtPrice.Text);

            RadioButton rdoeditAccsessorytypeReg = (RadioButton)gdvAQDetails.Rows[e.RowIndex].FindControl("rdoeditAccsessorytypeReg");


            aq.AccTypeReg_UnReg = rdoeditAccsessorytypeReg.Checked == true ? "1" : "0";

            var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

            if (this.AccessoryQualityControllerInstance.AccessoryQualityDetail_InsUpdt(aq) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                gdvAQDetails.EditIndex = -1;
                BIndDetailsGrid(AQMID, rowindex);
                BIndGrid();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
        }

        protected void gdvAQDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        #endregion

        public static DataTable ToDataTable<AccessoryQuality>(List<AccessoryQuality> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(AccessoryQuality));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            return table;
        }
        public void BindDDLSuplier(DropDownList ddlSuplier)
        {
            ddlSuplier.DataSource = this.FabricQualityControllerInstance.GetSuplier(Convert.ToInt32(ViewState["AQMID"].ToString()),2);
            ddlSuplier.DataTextField = "Name";
            ddlSuplier.DataValueField = "SupplierId";
            ddlSuplier.DataBind();
        }


    }
}