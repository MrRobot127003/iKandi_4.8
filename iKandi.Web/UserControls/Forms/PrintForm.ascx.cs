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
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class PrintForm : BaseUserControl
    {
        #region Properties

        public int PrintID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["printid"]))
                {
                    return Convert.ToInt32(Request.QueryString["printid"]);
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
                txtPrintRefnumber.Attributes.Add("readonly", "readonly");
                if (PrintID > 0)
                {
                    txtPrintNumber2.Attributes.Add("readonly", "readonly");
                    btnCreateVersion.Style.Add("display", "");
                    btnSubmit.Text = "Update";
                }

                BindControls();

                bool PermissionsOnSubmit =  ApplyPermissionsOnSubmit(ApplicationHelper.LoggedInUser.UserData.DesignationID);

                if(PermissionsOnSubmit)
                    btnSubmit.Style.Add("display", "");

                bool PermissionOnTesting = ApplyPermissionOnTesting(ApplicationHelper.LoggedInUser.UserData.DesignationID);

                if (PermissionOnTesting)
                    btnTesing.Style.Add("display", "");
            }

        }

        private bool ApplyPermissionsOnSubmit(int DesignationId)
        {
            switch(DesignationId)
            {
                case 13:
                    return true;
                case 104:
                    return true;
                case 32:
                    return true;
                case 109:
                    return true;
                case 7:
                    return true;
                case 6:
                    return true;
                case 24:
                    return true;
                case 15:
                    return true;  
            }
            return false;
        }

        private bool ApplyPermissionOnTesting(int DesignationId)
        {
            if (DesignationId == 40)
                return true;
            else
                return false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SavePrint(this.PrintID);
        }

        protected void btnVersionSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SavePrint(-2);
        }


        protected void rptTab_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Print print = e.Item.DataItem as Print;

                if (print.PrintID == this.PrintID)
                {
                    ((HyperLink)e.Item.FindControl("hlkPrint")).CssClass = "selectedTabs";
                }
                else
                {
                    ((HyperLink)e.Item.FindControl("hlkPrint")).CssClass = string.Empty;
                }
            }
        }

        protected void grdHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            iKandi.Common.PrintHistory printHistory = (iKandi.Common.PrintHistory)e.Row.DataItem;

            Label lblTestingDate = e.Row.FindControl("lblTestingDate") as Label;
            HyperLink hypPDF = e.Row.FindControl("hypPDF") as HyperLink;
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            Label lblComments = e.Row.FindControl("lblComments") as Label;

            if (printHistory != null)
            {

                lblTestingDate.Text = (Convert.ToDateTime(printHistory.TestingDate) == DateTime.MinValue) ? string.Empty : printHistory.TestingDate.ToString("dd MMM yy (ddd)");
                lblStatus.Text = (Convert.ToInt32(printHistory.Status) <= 0) ? "Pending" : (Convert.ToInt32(printHistory.Status) == 1 ? "PASS" : "FAIL");
                lblComments.Text = !String.IsNullOrEmpty(printHistory.Comments) ? printHistory.Comments : string.Empty;
                if (!String.IsNullOrEmpty(printHistory.PDFPath))
                {
                    hypPDF.Text = (!String.IsNullOrEmpty(printHistory.PDFPath) ? "View" : String.Empty);
                    hypPDF.NavigateUrl = ResolveUrl("~/Uploads/print/" + printHistory.PDFPath);
                }
                else
                    hypPDF.Visible = false;
            }
        }

        protected void btnTesing_Click(object sender, EventArgs e)
        {
            SaveTesingData();
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            BindParClientDep(-1);
            binddep(-1);
            rptTab.DataSource = this.PrintControllerInstance.GetPrintVariations(PrintID);
            rptTab.DataBind();

            imgPhoto.Visible = false;
            DropdownHelper.BindAllPrintTypes(ddlPrintType as ListControl);
            DropdownHelper.BindAllClients(ddlClient as ListControl);            
            DropdownHelper.BindUsersByDesignationIDAndManagerID(ddlDesigner, (int)Designation.iKandi_Design_Manager, (int)Designation.iKandi_Design_Designers);
            DropdownHelper.BindCurrency(ddlCurrency as ListControl);
                      
            if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRINT_TESTING_SECTION))
            {
                pnlTesting.Visible = true;
                pnlHistory.Visible = true;
            }
            else if (iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRINT_TESTING_SECTION))
            {
                pnlTesting.Visible = false;
                pnlHistory.Visible = true;
            }
            else
            {
                pnlTesting.Visible = false;
                pnlHistory.Visible = false;
                tdTesting.Visible = false;
            }
            if (PrintID != -1)
            {
                PopulatePrintData();
            }
            else
            {
                int currency = (int)Currency.GBP;
                ddlCurrency.SelectedValue = currency.ToString();
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                txtPrintNumber.Text = this.PrintControllerInstance.GetNewPrintNumber().ToString();
                lblPrintDesc.Text = txtPrintNumber.Text;
                ListItem item = ddlDesigner.Items.FindByValue(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());

                if (item != null)
                    item.Selected = true;

                txtTestingDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            }            
        }

        private void SavePrint(int PrintID)
        {
            Print p = new Print();

            string fileID = hdnImagePath.Value;
            string fileID_develoed = hdndevelopedimage.Value;

            //p.PrintID = (PrintID == -2) ? -1 : PrintID;
            if (PrintID == -2)
            {
                p.PrintID = -1;
                p.PrintNumber = (txtPrintRefnumber.Text + " " + txtPrintVersion.Text).Trim();
                p.PrintRefNo = (txtPrintRefnumber.Text + " " + txtPrintVersion.Text).Trim() + " " + txtPrintRefNo.Text.Trim();
            }
            else
            {
                p.PrintID = PrintID;
                p.PrintNumber = (txtPrintNumber.Text + " " + txtPrintNumber2.Text).Trim();
                p.PrintRefNo = (txtPrintNumber.Text + " " + txtPrintNumber2.Text).Trim() + " " + txtPrintRefNo.Text.Trim();
            }

            p.Description = txtDesc.Text;

            if (filePhoto.HasFile)
                fileID = FileHelper.SaveFile(filePhoto.PostedFile.InputStream, filePhoto.FileName, Constants.PRINT_FOLDER_PATH, true, "PRD " + p.PrintNumber);

            if ((fileID == string.Empty) && (PrintID != -2))
            {
                ShowAlert("Please upload original photo");
                return;
            }

            if (fileID != string.Empty)
                p.ImageUrl = fileID;

            if (PrintID == -2 && !filePhoto.HasFile)
                p.ImageUrl = string.Empty;
           
          
            if (!string.IsNullOrEmpty(ddlClient.SelectedValue))
                p.ClientID = Convert.ToInt32(ddlClient.SelectedValue);

            if (!string.IsNullOrEmpty(ddlDesigner.SelectedValue))
                p.DesignerID = Convert.ToInt32(ddlDesigner.SelectedValue);

            p.PrintCompany = txtPrintCompany.Text;

            p.PrintCompanyReference = txtPrintCompanyReference.Text;

            if (PrintID > -2 && !string.IsNullOrEmpty(txtPrintCost.Text))
                p.PrintCost = Convert.ToDouble(txtPrintCost.Text);

            if (!string.IsNullOrEmpty(txtDate.Text))
                p.DatePurchased = DateHelper.ParseDate(txtDate.Text).Value;

            if (!string.IsNullOrEmpty(ddlCurrency.SelectedValue))
                p.PrintCostCurrency = (Currency)Convert.ToInt32(ddlCurrency.SelectedValue);

           

            if (uploaddevelopedimage.HasFile)
              fileID_develoed = FileHelper.SaveFile(uploaddevelopedimage.PostedFile.InputStream, uploaddevelopedimage.FileName, Constants.PRINT_FOLDER_PATH, true, "PRDDEV " + p.PrintNumber);

            if (fileID_develoed != string.Empty)
              p.DevelopedImageUrl = fileID_develoed;

            if (PrintID == -2 && !uploaddevelopedimage.HasFile)
              p.DevelopedImageUrl = string.Empty;


            if (!string.IsNullOrEmpty(txtFabricQuality.Text))
            {
                p.FabricQuality = txtFabricQuality.Text;
            }
            else { p.FabricQuality = ""; }


            if (Convert.ToInt32(ddlPrintType.SelectedValue) > 0)
                p.PrintTypeID = Convert.ToInt32(ddlPrintType.SelectedValue);

            p.PrintCategory = Convert.ToInt32(ddlPrintCategory.SelectedValue);

            int n;
            bool isNumeric = int.TryParse(ddlDeptNameSelect.SelectedValue, out n);
            if (isNumeric)
            {
              p.DeptID = Convert.ToInt32(ddlDeptNameSelect.SelectedValue);
            }
            else
            {
              p.DeptID = Convert.ToInt32(hdndeptid.Value);
            }
          //added by abhishek 
            int D;
            bool isNumericD = int.TryParse(ddlDepNameParent.SelectedValue, out D);
            if (isNumericD)
            {
              p.ParentDeptID = Convert.ToInt32(ddlDepNameParent.SelectedValue);
            }
            else
            {
              p.ParentDeptID = Convert.ToInt32(hdnsubdept.Value);            
            }
         
            this.PrintControllerInstance.Save(p);

            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }

        public void ShowAlert(string stringAlertMsg)
        {
          string myStringVariable = string.Empty;
          myStringVariable = stringAlertMsg;
          ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        private void PopulatePrintData()
        {          
            Print p = this.PrintControllerInstance.GetPrintById(PrintID);
            List<PrintHistory> printHistory = this.PrintControllerInstance.GetPrintTestingHistoryByPrintId(PrintID);
            grdHistory.DataSource = printHistory;
            grdHistory.DataBind();
            if (p.PrintNumber.IndexOf(" ") > -1)
            {
                var print = p.PrintNumber.Split(' ');
                if (print.Length > 0)
                {
                    if (!string.IsNullOrEmpty(print[0]))
                        txtPrintNumber.Text = print[0];
                    if (!string.IsNullOrEmpty(print[1]))
                        txtPrintNumber2.Text = print[1];
                }
            }
            else if (p.PrintNumber.IndexOf(" ") == -1)
                txtPrintNumber.Text = p.PrintNumber;

            hdnPrintID.Value = p.PrintID.ToString();
            string p1 = p.PrintNumber + " ";
            //txtPrintNumber.Text = p.PrintNumber;
            txtDesc.Text = p.Description;
            if (p.PrintRefNo.IndexOf(p.PrintNumber) > -1 && p.PrintRefNo!=p.PrintNumber)
            {
                txtPrintRefNo.Text = p.PrintRefNo.Trim().Substring(p1.Length);
            }
            else if (p.PrintRefNo == p.PrintNumber)
            {
                txtPrintRefNo.Text = "";
            }
            //if (p.PrintRefNo == p.PrintNumber || p.PrintRefNo == "" || p1.Length <= p.PrintRefNo.Length)
            else {
                txtPrintRefNo.Text = p.PrintRefNo.Trim();
            }
            //else if (p1.Length > p.PrintRefNo.Length)
            //{
            //    txtPrintRefNo.Text = p.PrintRefNo.Substring(p1.Length);
            //}
            ddlClient.SelectedValue = (Convert.ToInt32(p.ClientID)).ToString();
            ddlDesigner.SelectedValue = (Convert.ToInt32(p.DesignerID)).ToString();
            txtPrintCompany.Text = p.PrintCompany;
            txtPrintCompanyReference.Text = p.PrintCompanyReference;
            txtPrintCost.Text = p.PrintCost.ToString();
            ddlCurrency.SelectedValue = (Convert.ToInt32(p.PrintCostCurrency)).ToString();
            txtDate.Text = (p.DatePurchased).ToString("dd MMM yy (ddd)");
            txtFabricQuality.Text = p.FabricQuality.ToString();
            ddlPrintType.SelectedValue = (Convert.ToInt32(p.PrintTypeID)).ToString();
            ddlPrintCategory.SelectedValue = p.PrintCategory.ToString();
            
            if (!string.IsNullOrEmpty(p.ImageUrl))
            {
                imgPhoto.Visible = true;
                imgPhoto.ImageUrl = ResolveUrl("~/Uploads/print/thumb-" + p.ImageUrl);
                hdnImagePath.Value = p.ImageUrl;
            }
            if (!string.IsNullOrEmpty(p.DevelopedImageUrl))
            {
              imgdeveloped.Visible = true;
              imgdeveloped.ImageUrl = ResolveUrl("~/Uploads/print/thumb-" + p.DevelopedImageUrl);
              hdndevelopedimage.Value = p.DevelopedImageUrl;
            }

            txtTestingDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            if (printHistory != null && printHistory.Count > 0)
            {
                if (printHistory[printHistory.Count - 1].Status == 1)
                {
                    pnlTesting.Visible = false;
                }
                else
                {
                    ddlStatus.SelectedValue = "-1";
                    txtComments.Text = string.Empty;
                }
            }
            BindParClientDep(Convert.ToInt32(p.ClientID));
            //if (p.ParentDeptID == null || p.ParentDeptID <= 0)
            if (p.ParentDeptID <= 0)
            {
              ddlDepNameParent.SelectedValue = "0";
            }
            else
            { ddlDepNameParent.SelectedValue = p.ParentDeptID.ToString(); }

            binddep(Convert.ToInt32(p.ClientID));
            //if (p.DeptID == null || p.DeptID <= 0)
            if (p.DeptID <= 0)
            {
              ddlDeptNameSelect.SelectedValue = "0";
            }
            else
            { ddlDeptNameSelect.SelectedValue = p.DeptID.ToString(); }

            
            
        }

        private void SaveTesingData()
        {
            PrintHistory p = new PrintHistory();
            p.ParentPrint = new Print();

            string fileID = hdnFilePath.Value;

            p.ParentPrint.PrintID = this.PrintID;

            p.TestingDate = DateHelper.ParseDate(txtTestingDate.Text).Value;

            p.Status = Convert.ToInt32(ddlStatus.SelectedValue);

            if (!string.IsNullOrEmpty(txtComments.Text))
                p.Comments = txtComments.Text;

            if (filePDF.HasFile)
                fileID = FileHelper.SaveFile(filePDF.PostedFile.InputStream, filePDF.FileName, Constants.PRINT_FOLDER_PATH, true, (DateTime.Now).Date.ToString() + "-" + p.ParentPrint.PrintID);

            if (fileID != string.Empty)
                p.PDFPath = fileID;

            int printTestingId = this.PrintControllerInstance.InsertPrintTestingHistory(p);
            if (printTestingId > 0)
                BindControls();
        }

        public void BindParClientDep(int seelctedvalue)
        {
          List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDeptsParent(seelctedvalue, "Parent",-1);
          if (objSamplePattern.Count > 0)
          {
            ddlDepNameParent.DataSource = objSamplePattern;
            ddlDepNameParent.DataTextField = "DeptName";
            ddlDepNameParent.DataValueField = "ClientDeptid";
            ddlDepNameParent.DataBind();
          }
          ddlDepNameParent.Items.Insert(0, "Select");
        }

        public void binddep(int seelctedvalue)
        {
         // List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDepts_ByAutoAllocPattern(seelctedvalue);
         
          int ParentDepID = -1;
          if (ddlDepNameParent.SelectedValue != "Select" && ddlDepNameParent.SelectedValue != "")
          { ParentDepID = Convert.ToInt16(ddlDepNameParent.SelectedValue);
          List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDeptsParent(seelctedvalue, "SubParent", ParentDepID);
            if (objSamplePattern.Count > 0)
            {
              ddlDeptNameSelect.DataSource = objSamplePattern;
              ddlDeptNameSelect.DataTextField = "DeptName";
              ddlDeptNameSelect.DataValueField = "ClientDeptid";
              ddlDeptNameSelect.DataBind();

            }
          }                    
          ddlDeptNameSelect.Items.Insert(0, "Select");
         // DropdownHelper.FillDropDownDepartment(ddlDeptNameSelect, Convert.ToInt16(ddlClient.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID, false, true, true);
          
        }

        #endregion       

    }
}