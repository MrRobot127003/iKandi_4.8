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


namespace iKandi.Web
{
    public partial class FabricQualityForm : BaseUserControl
    {
        PermissionController objPermissionController = new PermissionController();
        #region Properties

        public int FabricQualityID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["fabricqualityid"]))
                {
                    return Convert.ToInt32(Request.QueryString["fabricqualityid"]);


                }

                return -1;
            }
        }

        #endregion

        # region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
                UserPermission();
            }
        }

        private void UserPermission()
        {
            DataTable dtsubmitButton = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 231).Tables[0];

            if (dtsubmitButton.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtsubmitButton.Rows[0]["PermisionWrite"]) == true)
                {
                    btnSubmit.Enabled = true;      
                }
                else
                {
                    btnSubmit.Enabled = false;                   
                }
            }
        }

        private void BindControls()
        {
            hdnQID.Value = Request.QueryString["fabricqualityid"];
            txtApprovalDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            //txtFabricDesignNumber.Text = this.FabricQualityControllerInstance.GetNewCountConstruction().ToString();
            //DropdownHelper.BindClients(lstClients);
            DropdownHelper.BindClientsForFabric(lstClients);
            DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.FABRIC_QUALITY));

            if (FabricQualityID != -1)
            {
                FabricQuality fq = this.FabricQualityControllerInstance.GetFabricQualityByID(FabricQualityID);
                txtSupplierReference.Text = fq.SupplierReference;
                txtTradeName.Text = fq.TradeName.Trim();
                hdnfabqualityname.Value = fq.TradeName.Trim();
                //txtFabricDesignNumber.Text = fq.DesignFullNo;
                txtCount.Text = fq.CountConstruction;
                ddlOrigin.SelectedValue = (Convert.ToInt32(fq.Origin).ToString());
                txtComposition.Text = fq.Composition;
                txtGSM.Text = fq.GSM.ToString();
                txtFabric.Text = fq.Fabric;
                //txtRemarks.Text = fq.Remarks;
                
                if (fq.TestConductedOn != DateTime.MinValue)
                    txtTestDate.Text = (fq.TestConductedOn).ToString("dd MMM yy (ddd) ");
                else
                    txtTestDate.Text = String.Empty;

                txtMOQ.Text = fq.MinimumOrderQuantity.ToString();
                txtLeadTimeGreige.Text = fq.LeadTimeForGreige.ToString();
                txtLeadTimeDying.Text = fq.LeadTimeForDyed.ToString();
                txtLeadTimePrinting.Text = fq.LeadTimeForPrinted.ToString();

                txtAirGreigePrice.Text = fq.PriceForGreigeByAir.ToString();
                hdnAirGreigePrice.Value = fq.PriceForGreigeByAir.ToString();
                txtSeaGreigePrice.Text = fq.PriceForGreigeBySea.ToString();
                hdnSeaGreigePrice.Value = fq.PriceForGreigeBySea.ToString();
                txtAirDyingPrice.Text = fq.PriceForDyedByAir.ToString();
                hdnAirDyingPrice.Value = fq.PriceForDyedByAir.ToString();
                txtSeaDyingPrice.Text = fq.PriceForDyedBySea.ToString();
                hdnSeaDyingPrice.Value = fq.PriceForDyedBySea.ToString();
                txtAirPrintingPrice.Text = fq.PriceForPrintedByAir.ToString();
                hdnAirPrintingPrice.Value = fq.PriceForPrintedByAir.ToString();
                txtSeaPrintingPrice.Text = fq.PriceForPrintedBySea.ToString();
                hdnSeaPrintingPrice.Value = fq.PriceForPrintedBySea.ToString();

                txtSupplierName.Text = fq.SupplierName.ToString();
                txtWidthInch.Text = fq.Width.ToString();
                //added by abhishek on 1/7/2015
                hdnWidthInch.Value = fq.Width.ToString();
                //End
                txtWidthCm.Text = (fq.Width * 2.54m).ToString();

                if (Convert.ToInt32(fq.CategoryId) > 0)
                    ddlGroup.SelectedValue = fq.CategoryId.ToString();

                hiddenSubGroupId.Value = fq.SubCategoryId.ToString();

                if (Convert.ToInt32(fq.SubCategoryId) > 0)
                    ddlSubGroup.SelectedValue = fq.SubCategoryId.ToString();

                txtIdentification.Text = fq.Identification;
                txtWastage.Text = fq.Wastage.ToString();

                txtGreigeIndian.Text = fq.PriceGreigeIndian.ToString();
                hdnGreigeIndian.Value = fq.PriceGreigeIndian.ToString();
                txtDyedIndian.Text = fq.PriceDyedIndian.ToString();
                hdnDyedIndian.Value = fq.PriceDyedIndian.ToString();
                txtPrintedIndian.Text = fq.PricePrintedIndian.ToString();
                hdnPrintedIndian.Value = fq.PricePrintedIndian.ToString();
                chkBiplRegistered.Checked = fq.IsBiplRegistered;
                lblCommentHistory.Text = fq.Comments.ToString().Replace("\r\n", "<br/>");

                if (Convert.ToInt32(fq.Origin) == 1)
                {
                    txtGreigeIndian.Enabled = true;
                    txtDyedIndian.Enabled = true;
                    txtPrintedIndian.Enabled = true;
                    txtAirGreigePrice.Enabled = false;
                    txtSeaGreigePrice.Enabled = false;
                    txtAirDyingPrice.Enabled = false;
                    txtSeaDyingPrice.Enabled = false;
                    txtAirPrintingPrice.Enabled = false;
                    txtSeaPrintingPrice.Enabled = false;
                }
                else if (Convert.ToInt32(fq.Origin) == 2)
                {
                    txtGreigeIndian.Enabled = false;
                    txtDyedIndian.Enabled = false;
                    txtPrintedIndian.Enabled = false;
                    txtAirGreigePrice.Enabled = true;
                    txtSeaGreigePrice.Enabled = true;
                    txtAirDyingPrice.Enabled = true;
                    txtSeaDyingPrice.Enabled = true;
                    txtAirPrintingPrice.Enabled = true;
                    txtSeaPrintingPrice.Enabled = true;
                }

                foreach (FabricQualityBuyer fqb in fq.Buyers)
                {
                    if (lstClients.Items.FindByValue(fqb.Client.ClientID.ToString()) != null)
                        lstClients.Items.FindByValue(fqb.Client.ClientID.ToString()).Selected = true;

                }

                if (!string.IsNullOrEmpty(fq.UpdateBaseTestFile))
                {

                    fileBaseTest.Visible = true;
                    basetestfile.HRef = ResolveUrl("~/Uploads/Quality/" + fq.UpdateBaseTestFile);
                    hdnUpdateBaseFilePath.Value = fq.UpdateBaseTestFile;
                    basetestfile.Visible = true;
                }

                if (fq != null && fq.Pictures != null && fq.Pictures.Count > 0)
                {
                    rptUploadPicture.DataSource = fq.Pictures;
                    rptUploadPicture.DataBind();

                }

                txtQty.Text = Convert.ToString(fq.MinStockQuality);
                ddlQtyType.SelectedValue = Convert.ToString(fq.StockUnit);




            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            FabricQuality fq = new FabricQuality();
            string fileID = String.Empty;
            //Added by Abhishek on 1/7/2015
            if (hdnWidthInch.Value == "")
                hdnWidthInch.Value = "0";

            fq.oldWidthInchValue = Convert.ToDecimal(hdnWidthInch.Value);

            //fq.oldWidthInchValue = Convert.ToDecimal(hdnWidthInch.Value);

            if (!string.IsNullOrEmpty(txtWidthInch.Text))
            {
                fq.NewWidthInchValue = Convert.ToDecimal(txtWidthInch.Text);
            }
            //END
            fq.FabricQualityID = this.FabricQualityID;
            fq.SupplierReference = txtSupplierReference.Text;
            fq.TradeName = txtTradeName.Text.Trim();
            fq.CountConstruction = txtCount.Text;

            if (!string.IsNullOrEmpty(ddlOrigin.SelectedValue))
                fq.Origin = Convert.ToInt32(ddlOrigin.SelectedValue);

            if (!string.IsNullOrEmpty(txtComposition.Text))
                fq.Composition = txtComposition.Text;
            else
                fq.Composition = string.Empty;

            if (!string.IsNullOrEmpty(txtGSM.Text))
            {
                fq.GSM = Convert.ToDouble(txtGSM.Text);
            }

            fq.Fabric = txtFabric.Text;

            if (!string.IsNullOrEmpty(txtWidthInch.Text))
            {
                fq.Width = Convert.ToDecimal(txtWidthInch.Text);
            }

            if (fileBaseTest.HasFile)
                fileID = FileHelper.SaveFile(fileBaseTest.PostedFile.InputStream, fileBaseTest.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

            if (fileID != string.Empty)
                fq.UpdateBaseTestFile = fileID;
            else
            {
                fq.UpdateBaseTestFile = hdnUpdateBaseFilePath.Value;
            }

            if (!string.IsNullOrEmpty(txtTestDate.Text))
            {
                fq.TestConductedOn = DateHelper.ParseDate(txtTestDate.Text).Value;
            }

            if (!string.IsNullOrEmpty(txtMOQ.Text))
            {
                fq.MinimumOrderQuantity = Convert.ToDouble(txtMOQ.Text);
            }

            if (!string.IsNullOrEmpty(txtLeadTimeGreige.Text))
            {
                fq.LeadTimeForGreige = Convert.ToInt32(txtLeadTimeGreige.Text);
            }

            if (!string.IsNullOrEmpty(txtLeadTimeDying.Text))
            {
                fq.LeadTimeForDyed = Convert.ToInt32(txtLeadTimeDying.Text);
            }

            if (!string.IsNullOrEmpty(txtLeadTimePrinting.Text))
            {
                fq.LeadTimeForPrinted = Convert.ToInt32(txtLeadTimePrinting.Text);
            }

            if (!string.IsNullOrEmpty(txtAirGreigePrice.Text))
            {
                fq.PriceForGreigeByAir = Convert.ToDouble(txtAirGreigePrice.Text);
            }

            if (!string.IsNullOrEmpty(txtSeaGreigePrice.Text))
            {
                fq.PriceForGreigeBySea = Convert.ToDouble(txtSeaGreigePrice.Text);
            }

            if (!string.IsNullOrEmpty(txtAirDyingPrice.Text))
            {
                fq.PriceForDyedByAir = Convert.ToDouble(txtAirDyingPrice.Text);
            }

            if (!string.IsNullOrEmpty(txtSeaDyingPrice.Text))
            {
                fq.PriceForDyedBySea = Convert.ToDouble(txtSeaDyingPrice.Text);
            }

            if (!string.IsNullOrEmpty(txtAirPrintingPrice.Text))
            {
                fq.PriceForPrintedByAir = Convert.ToDouble(txtAirPrintingPrice.Text);
            }

            if (!string.IsNullOrEmpty(txtSeaPrintingPrice.Text))
            {
                fq.PriceForPrintedBySea = Convert.ToDouble(txtSeaPrintingPrice.Text);
            }

            if (!string.IsNullOrEmpty(txtSupplierName.Text))
            {
                fq.SupplierName = txtSupplierName.Text;
            }

            fq.IsBiplRegistered = chkBiplRegistered.Checked;

            if (!string.IsNullOrEmpty(txtIdentification.Text))
            {
                fq.Identification = txtIdentification.Text;
            }

            if (Convert.ToInt32(ddlGroup.SelectedValue) != -1)
            {
                fq.CategoryId = Convert.ToInt32(ddlGroup.SelectedValue);
            }

            if (Convert.ToInt32(hiddenSubGroupId.Value) != -1)
            {
                fq.SubCategoryId = Convert.ToInt32(hiddenSubGroupId.Value);
            }

            if (!String.IsNullOrEmpty(txtGreigeIndian.Text))
                fq.PriceGreigeIndian = Convert.ToDouble(txtGreigeIndian.Text);

            if (!String.IsNullOrEmpty(txtDyedIndian.Text))
                fq.PriceDyedIndian = Convert.ToDouble(txtDyedIndian.Text);

            if (!String.IsNullOrEmpty(txtPrintedIndian.Text))
                fq.PricePrintedIndian = Convert.ToDouble(txtPrintedIndian.Text);

            if (!String.IsNullOrEmpty(txtWastage.Text))
                fq.Wastage = Convert.ToDecimal(txtWastage.Text);

            if (String.IsNullOrEmpty(txtComments.Text))
                fq.Comments = txtComments.Text;
            else
                fq.Comments = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName + " (" + DateTime.Today.ToString("dd MMM") + ")" + " " + " : " + txtComments.Text;

            if (chkIsCommentsDeleted.Checked)
                fq.IsCommentHistoryDeleted = true;
            else
                fq.IsCommentHistoryDeleted = false;


            fq.StockUnit = Convert.ToInt32(ddlQtyType.SelectedValue);
            if (txtQty.Text.Trim() != "")
            {
                fq.MinStockQuality = Convert.ToInt32(txtQty.Text.Trim());
            }
            else
                fq.MinStockQuality = null;

            if (hdnAirGreigePrice.Value=="")
                hdnAirGreigePrice.Value="0";
            fq.oldAirGreigePrice = Convert.ToDouble(hdnAirGreigePrice.Value);
            if (hdnAirDyingPrice.Value == "")
                hdnAirDyingPrice.Value = "0";
            fq.oldAirDyingPrice = Convert.ToDouble(hdnAirDyingPrice.Value);
            if (hdnAirPrintingPrice.Value == "")
                hdnAirPrintingPrice.Value = "0";
            fq.oldAirPrintingPrice = Convert.ToDouble(hdnAirPrintingPrice.Value);
            if (hdnSeaGreigePrice.Value == "")
                hdnSeaGreigePrice.Value = "0";
            fq.oldSeaGreigePrice = Convert.ToDouble(hdnSeaGreigePrice.Value);
            if (hdnSeaDyingPrice.Value == "")
                hdnSeaDyingPrice.Value = "0";
            fq.oldSeaDyingPrice = Convert.ToDouble(hdnSeaDyingPrice.Value);
            if (hdnSeaPrintingPrice.Value == "")
                hdnSeaPrintingPrice.Value = "0";
            fq.oldSeaPrintingPrice = Convert.ToDouble(hdnSeaPrintingPrice.Value);
            if (hdnGreigeIndian.Value == "")
                hdnGreigeIndian.Value = "0";
            //
            fq.oldGreigeIndian = Convert.ToDouble(hdnGreigeIndian.Value);
            if (hdnDyedIndian.Value == "")
                hdnDyedIndian.Value = "0";
            fq.oldDyedIndian = Convert.ToDouble(hdnDyedIndian.Value);
            if (hdnPrintedIndian.Value == "")
                hdnPrintedIndian.Value = "0";
            fq.oldPrintedIndian = Convert.ToDouble(hdnPrintedIndian.Value);
            //

            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName.ToUpper() + '(' + DateTime.Today.ToString("dd MMM yy (ddd)") + ')';

            fq = this.FabricQualityControllerInstance.Save(fq, userName);

            int id = fq.FabricQualityID;

            if (id == -1)
            {
                pnlFabricForm.Visible = false;
                pnlError.Visible = true;
            }

            if (id > 0)
            {
                pnlFabricForm.Visible = false;
                pnlMessage.Visible = true;

                // Delete all buyer for that Id
                this.FabricQualityControllerInstance.DeleteFabricQualityBuyer(id);

                fq.Buyers = new System.Collections.Generic.List<FabricQualityBuyer>();

                foreach (ListItem item in lstClients.Items)
                {

                    if (!item.Selected) continue;

                    FabricQualityBuyer fqb = new FabricQualityBuyer();
                    fqb.Client = new Client();
                    fqb.FabricQuality = new FabricQuality();
                    fqb.FabricQuality.FabricQualityID = id;
                    fqb.Client.ClientID = Convert.ToInt32(item.Value);
                    //int ClientId = fqb.Client.ClientID;
                    this.FabricQualityControllerInstance.InsertFabricQualityBuyer(fqb);
                }


                fq = new FabricQuality();
                fq.Pictures = new List<iKandi.Common.FabricQualityPicture>();

                if (Request.Files != null && Request.Files.Count > 0)
                {
                    for (int i = 1; i < Request.Files.Count; i++)
                    {
                        FabricQualityPicture FQPicture = new FabricQualityPicture();
                        if (Request.Files != null && Request.Files[i].InputStream != null && Request.Files[i].InputStream.Length > 0)
                        {
                            string filepath = ("~/Uploads/Quality/" + FQPicture.ImageFile);
                            string imageName = FileHelper.SaveFile(Request.Files[i].InputStream, Request.Files[i].FileName, Constants.QUALITY_FOLDER_PATH, true, string.Empty);
                            if (imageName != string.Empty)
                                FQPicture.ImageFile = imageName;
                            FQPicture.FabricQuality = new FabricQuality();
                            FQPicture.FabricQuality.FabricQualityID = id;
                            this.FabricQualityControllerInstance.InsertFabricQualityPicture(FQPicture);
                        }
                        fq.Pictures.Add(FQPicture);
                    }
                }
            }
        }

        protected void btnImageDelete_Click(object sender, EventArgs e)
        {
            // System.Diagnostics.Debugger.Break();
            int imageid = Convert.ToInt32(((Button)sender).CommandArgument);
            this.FabricQualityControllerInstance.DeleteFabricQualityPicture(imageid);
            //BindControls();
        }
        #endregion

    }
}