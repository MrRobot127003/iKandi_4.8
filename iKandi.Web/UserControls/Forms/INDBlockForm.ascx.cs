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
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web
{
    public partial class INDBlockForm : BaseUserControl
    {
        #region Properties

        public int INDBlockID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["blockid"]))
                {
                    return Convert.ToInt32(Request.QueryString["blockid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveBlock();

        }

        #endregion

        #region Private Method

        private void BindControls()
        {

            imgPhoto.Visible = false;

            DropdownHelper.BindAllClients(ddlClient as ListControl);
            //DropdownHelper.BindUsersByDesignation(ddlDesigner as ListControl, (Convert.ToInt32(Designation.iKandi_Design_Designers)));
            DropdownHelper.BindUsersByDesignationIDAndManagerID(ddlDesigner, (int)Designation.iKandi_Design_Manager, (int)Designation.iKandi_Design_Designers);
            DropdownHelper.BindCurrency(ddlCurrency as ListControl);

            if (INDBlockID != -1)
            {
                PopulateBlockData();
            }
            else
            {
                int currency = (int)Currency.GBP;
                ddlCurrency.SelectedValue = currency.ToString();
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                txtBlockNumber.Text = "IND " + this.INDBlockControllerInstance.GetNewBlockNumber().ToString().Trim();

                ListItem item = ddlDesigner.Items.FindByValue(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());

                if (item != null)
                    item.Selected = true;

            }
        }

        private void SaveBlock()
        {


            iKandi.Common.INDBlock block = new iKandi.Common.INDBlock();

            string fileID = hdnImagePath.Value;

            block.BlockID = this.INDBlockID;

            block.BlockNumber = txtBlockNumber.Text;

            block.Description = txtDesc.Text;

            if (!string.IsNullOrEmpty(ddlClient.SelectedValue))
                block.ClientID = Convert.ToInt32(ddlClient.SelectedValue);

            if (!string.IsNullOrEmpty(ddlDesigner.SelectedValue))
                block.DesignerID = Convert.ToInt32(ddlDesigner.SelectedValue);

            block.Brand = txtBrand.Text;

            block.Reference = txtReference.Text;

            if (!string.IsNullOrEmpty(txtBlockCost.Text))
                block.BlockCost = Convert.ToDouble(txtBlockCost.Text);

            if (!string.IsNullOrEmpty(txtDate.Text))
                block.DatePurchased = DateHelper.ParseDate(txtDate.Text).Value;

            if (!string.IsNullOrEmpty(ddlCurrency.SelectedValue))
                block.BlockCostCurrency = (Currency)Convert.ToInt32(ddlCurrency.SelectedValue);

            if (filePhoto.HasFile)
                fileID = FileHelper.SaveFile(filePhoto.PostedFile.InputStream, filePhoto.FileName, Constants.IND_BLOCK_FOLDER_PATH, true, block.BlockNumber);

            if (fileID != string.Empty)
                block.ImageUrl = fileID;

            fileID = hdnAdditionalImagePath1.Value;

            if (fileAdditionaPhoto1.HasFile)
                fileID = FileHelper.SaveFile(fileAdditionaPhoto1.PostedFile.InputStream, filePhoto.FileName, Constants.IND_BLOCK_FOLDER_PATH, true, block.BlockNumber + " A");

            if (fileID != string.Empty)
            {
                block.AdditionalImageUrl1 = fileID;
            }
            else
            {
                block.AdditionalImageUrl1 = "";
            }

            fileID = hdnAdditionalImagePath2.Value;

            if (fileAdditionaPhoto2.HasFile)
                fileID = FileHelper.SaveFile(fileAdditionaPhoto2.PostedFile.InputStream, filePhoto.FileName, Constants.IND_BLOCK_FOLDER_PATH, true, block.BlockNumber + " B");

            if (fileID != string.Empty)
            {
                block.AdditionalImageUrl2 = fileID;
            }
            else
            {
                block.AdditionalImageUrl2 = "";
            }

            this.INDBlockControllerInstance.Save(block);

            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }


        private void PopulateBlockData()
        {
            iKandi.Common.INDBlock block = this.INDBlockControllerInstance.GetBlockById(INDBlockID);

            txtBlockNumber.Text = block.BlockNumber;
            txtDesc.Text = block.Description;
            ddlClient.SelectedValue = (Convert.ToInt32(block.ClientID)).ToString();
            ddlDesigner.SelectedValue = (Convert.ToInt32(block.DesignerID)).ToString();
            txtBrand.Text = block.Brand;
            txtReference.Text = block.Reference;
            txtBlockCost.Text = block.BlockCost.ToString();
            ddlCurrency.SelectedValue = (Convert.ToInt32(block.BlockCostCurrency)).ToString();
            txtDate.Text = (block.DatePurchased).ToString("dd MMM yy (ddd)");

            if (!string.IsNullOrEmpty(block.ImageUrl))
            {
                imgPhoto.Visible = true;
                imgPhoto.ImageUrl = ResolveUrl("~/Uploads/INDBlock/thumb-" + block.ImageUrl);
                hdnImagePath.Value = block.ImageUrl;
            }

            if (!string.IsNullOrEmpty(block.AdditionalImageUrl1))
            {
                imgAdditionalImage1.Visible = true;
                imgAdditionalImage1.ImageUrl = ResolveUrl("~/Uploads/INDBlock/thumb-" + block.AdditionalImageUrl1);
                hdnAdditionalImagePath1.Value = block.AdditionalImageUrl1;
            }

            if (!string.IsNullOrEmpty(block.AdditionalImageUrl2))
            {
                imgAdditionalImage2.Visible = true;
                imgAdditionalImage2.ImageUrl = ResolveUrl("~/Uploads/INDBlock/thumb-" + block.AdditionalImageUrl2);
                hdnAdditionalImagePath2.Value = block.AdditionalImageUrl2;
            }
        }

        #endregion

    }
}