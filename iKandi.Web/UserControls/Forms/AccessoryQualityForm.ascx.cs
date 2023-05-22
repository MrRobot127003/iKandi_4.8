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
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;



namespace iKandi.Web.UserControls.Forms
{
    public partial class AccessoryQualityForm : BaseUserControl
    {
        #region Properties

        public int AccessoryQualityID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["accessoryqualityid"]))
                {
                    return Convert.ToInt32(Request.QueryString["accessoryqualityid"]);
                }

                return -1;
            }

        }

        #endregion

        # region field

        iKandi.Common.AccessoryQuality objAccessoryQuality;


        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtApprovalDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindControls();
            }

        }


        private void BindControls()
        {
            //System.Diagnostics.Debugger.Break();
            //txtAccRef.Text = this.AccessoryQualityControllerInstance.GetNewAccRef().ToString();

            DropdownHelper.BindClients(lstClients);
            DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.ACCESSORY_QUALITY));

            if (AccessoryQualityID != -1)
            {
                objAccessoryQuality = this.AccessoryQualityControllerInstance.GetAccessoryQualityById(AccessoryQualityID);
                txtSupplierName.Text = objAccessoryQuality.SupplierName;
                //txtCategoryName.Text = objAccessoryQuality.Category;
                //txtAccRef.Text = objAccessoryQuality.FullAccRef;
                txtComposition.Text = objAccessoryQuality.Composition;
                txtorigin.SelectedValue = (Convert.ToInt32(objAccessoryQuality.Origin).ToString());
                //txtRemarks.Text = objAccessoryQuality.Remarks;
                txtWastage.Text = objAccessoryQuality.Wastage.ToString();
                txtLeadTimeInDays.Text = objAccessoryQuality.LeadTime.ToString();
                txtTestDate.Text = (objAccessoryQuality.TestConductedOn).ToString("dd MMM yy (ddd)");
                txtMOQ.Text = objAccessoryQuality.MinimumOrderQuality.ToString();
                hiddenSubGroupId.Value = objAccessoryQuality.SubCategoryId.ToString();
                txtIdentification.Text = objAccessoryQuality.Identification;
                txtTradeName.Text = objAccessoryQuality.TradeName;
                if (Convert.ToInt32(objAccessoryQuality.CategoryId) > 0)
                    ddlGroup.SelectedValue = objAccessoryQuality.CategoryId.ToString();
                if (Convert.ToInt32(objAccessoryQuality.SubCategoryId) > 0)
                    ddlSubGroup.SelectedValue = objAccessoryQuality.SubCategoryId.ToString();
                txtSupplierReference.Text = objAccessoryQuality.SupplierReference.ToString();
                txtPrice.Text = objAccessoryQuality.Price.ToString();
                chkBiplRegistered.Checked = objAccessoryQuality.IsBiplRegistered;

                if (!string.IsNullOrEmpty(objAccessoryQuality.UploadBaseTestFile))
                {
                    fileBaseTest.Visible = true;
                    basetestfile.HRef = ResolveUrl("~/Uploads/Quality/" + objAccessoryQuality.UploadBaseTestFile);
                    hdnUpdateBaseFilePath.Value = objAccessoryQuality.UploadBaseTestFile;
                    basetestfile.Visible = true;
                }
                try
                {
                    foreach (AccessoryQualityBuyer aqb in objAccessoryQuality.Buyers)
                    {
                        lstClients.Items.FindByValue(aqb.Client.ClientID.ToString()).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    ShowAlert("there is no buyer associate with you in this form");
                }

                if (objAccessoryQuality != null && objAccessoryQuality.Pictures != null)
                {
                    rptUploadPicture.DataSource = objAccessoryQuality.Pictures;
                    rptUploadPicture.DataBind();
                }
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string photoid = string.Empty;
            string fileID = string.Empty;

            //string StrAccRef = txtAccRef.Text;
            //int StrNewAccRef = Convert.ToInt32(StrAccRef.Replace("DES", ""));

            AccessoryQuality accessoryquality = new AccessoryQuality();
            accessoryquality.AccessoryQualityID = this.AccessoryQualityID;
            accessoryquality.SupplierName = txtSupplierName.Text;
            //accessoryquality.Category = txtCategoryName.Text;
            accessoryquality.Composition = txtComposition.Text;
            //accessoryquality.AccRef = StrNewAccRef.ToString();
            //accessoryquality.Remarks = txtRemarks.Text;

            if (!string.IsNullOrEmpty(txtWastage.Text))
            {
                accessoryquality.Wastage = Convert.ToInt32(txtWastage.Text);
            }

            if (!string.IsNullOrEmpty(txtLeadTimeInDays.Text))
            {
                accessoryquality.LeadTime = Convert.ToInt32(txtLeadTimeInDays.Text);
            }

            if (!string.IsNullOrEmpty(txtorigin.SelectedValue))
            {
                accessoryquality.Origin = Convert.ToInt32(txtorigin.SelectedValue);
            }

            if (!string.IsNullOrEmpty(txtTestDate.Text))
            {
                //accessoryquality.TestConductedOn = Convert.ToDateTime(txtTestDate.Text);
                accessoryquality.TestConductedOn = DateHelper.ParseDate(txtTestDate.Text).Value ;
            }
            else
            {
                accessoryquality.TestConductedOn = DateHelper.ParseDate("").Value ;
            }

            if (!string.IsNullOrEmpty(txtMOQ.Text))
            {
                accessoryquality.MinimumOrderQuality = Convert.ToDouble(txtMOQ.Text);
            }

            if (fileBaseTest.HasFile)
                fileID = FileHelper.SaveFile(fileBaseTest.PostedFile.InputStream, fileBaseTest.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);

            if (fileID != string.Empty)
                accessoryquality.UploadBaseTestFile = fileID;
            else
                accessoryquality.UploadBaseTestFile = hdnUpdateBaseFilePath.Value;

            if (!String.IsNullOrEmpty(txtTradeName.Text))
                accessoryquality.TradeName = txtTradeName.Text;

            if (Convert.ToInt32(ddlGroup.SelectedValue) != -1)
                accessoryquality.CategoryId = Convert.ToInt32(ddlGroup.SelectedValue);

            accessoryquality.SubCategoryId = Convert.ToInt32(hiddenSubGroupId.Value);

            if (!String.IsNullOrEmpty(txtIdentification.Text))
                accessoryquality.Identification = txtIdentification.Text;

            if (!String.IsNullOrEmpty(txtSupplierReference.Text))
                accessoryquality.SupplierReference = txtSupplierReference.Text;

            if (!String.IsNullOrEmpty(txtPrice.Text))
                accessoryquality.Price = Convert.ToDouble(txtPrice.Text);

            accessoryquality.IsBiplRegistered = chkBiplRegistered.Checked;

            accessoryquality = this.AccessoryQualityControllerInstance.save(accessoryquality);


            int id = accessoryquality.AccessoryQualityID;

            if (id <= 0)
            {
                pnlAccessoryForm.Visible = false;
                pnlError.Visible = true;
            }
            else
            {
                pnlAccessoryForm.Visible = false;
                pnlMessage.Visible = true;
                // Delete all buyer for that Id
                this.AccessoryQualityControllerInstance.DeleteAccessoryQualityBuyer(id);

                accessoryquality.Buyers = new System.Collections.Generic.List<AccessoryQualityBuyer>();
                accessoryquality.Pictures = new List<AccessoryQualityPicture>();

                foreach (ListItem item in lstClients.Items)
                {
                    if (!item.Selected) continue;
                    AccessoryQualityBuyer aqb = new AccessoryQualityBuyer();
                    aqb.Client = new Client();
                    aqb.AccessoryQuality = new AccessoryQuality();
                    aqb.AccessoryQuality.AccessoryQualityID = id;
                    aqb.Client.ClientID = Convert.ToInt32(item.Value);
                    this.AccessoryQualityControllerInstance.InsertAccessoryQualityBuyer(aqb);
                }

                objAccessoryQuality = new AccessoryQuality();
                objAccessoryQuality.Pictures = new List<AccessoryQualityPicture>();

                for (int i = 1; i < Request.Files.Count; i++)
                {
                    AccessoryQualityPicture AQPicture = new AccessoryQualityPicture();
                    if (Request.Files != null && Request.Files[i].InputStream != null && Request.Files[i].InputStream.Length > 0)
                    {
                        //string extension = ".jpg";
                        //string[] splittedImageName = Request.Files[i].FileName.Split('.');

                        //if (splittedImageName.Length == 2)
                        //    extension = "." + splittedImageName[1];

                        //string imgName = "~/Uploads/Quality/" + Guid.NewGuid() + extension;
                        //Request.Files[i].SaveAs(Server.MapPath(imgName));
                        string filepath = ("~/Uploads/Quality/" + AQPicture.ImageFile);
                        string imageName = FileHelper.SaveFile(Request.Files[i].InputStream, Request.Files[i].FileName, Constants.QUALITY_FOLDER_PATH, true, string.Empty);
                        if (imageName != string.Empty)
                            AQPicture.ImageFile = imageName;
                        AQPicture.AccessoryQuality = new AccessoryQuality();
                        AQPicture.AccessoryQuality.AccessoryQualityID = id;
                        this.AccessoryQualityControllerInstance.InsertAccessoryQualityPicture(AQPicture);
                    }
                    objAccessoryQuality.Pictures.Add(AQPicture);
                }
            }
        }


        protected void btnImageDelete_Click(object sender, EventArgs e)
        {
            int imageid = Convert.ToInt32(((Button)sender).CommandArgument);
            this.AccessoryQualityControllerInstance.DeleteAccessoryQualityPicture(imageid);
            BindControls();
        }

        #endregion

    }


}
















