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
using System.Collections.Generic;
using iKandi.Web.Components;


namespace iKandi.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FITsGarmentTesting : BaseUserControl
    {
        #region Fields

        Boolean HideLink = false;

        #endregion

        #region Properties

        private int StyleNumber
        {
            get
            {
                if (null != Request.QueryString["StyleNumber"])
                {
                    int styleNumber;

                    if (int.TryParse(Request.QueryString["StyleNumber"].ToString(), out styleNumber))
                        return styleNumber;
                }

                return -1;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl();
            }
        }

        protected void btnSaveAll_Click(object sender, EventArgs e)
        {

            List<GarmentTesting> objGarmentTesting = this.GarmentTestingControllerInstance.GetGarmentTesting(StyleNumber);

            foreach (GridViewRow grdRow in gridGarmentTesting.Rows)
            {
                if (((DropDownList)grdRow.FindControl("ddlStatus")).SelectedValue == "1" && ((DropDownList)grdRow.FindControl("ddlStatus")).Enabled)
                {
                    if (((TextBox)grdRow.FindControl("txtGarmentTestReport")).Text == String.Empty)
                    objGarmentTesting[grdRow.RowIndex].ReportCompletionDate = DateTime.Now;
                }
                else if (((TextBox)grdRow.FindControl("txtGarmentTestReport")).Text != String.Empty)
                    objGarmentTesting[grdRow.RowIndex].ReportCompletionDate = DateHelper.ParseDate(((TextBox)grdRow.FindControl("txtGarmentTestReport")).Text).Value;

                if (((TextBox)grdRow.FindControl("txtTestingCompletionTarget")).Text != String.Empty)
                {                 
                    objGarmentTesting[grdRow.RowIndex].TestingCompletionDate = DateHelper.ParseDate(((TextBox)grdRow.FindControl("txtTestingCompletionTarget")).Text).Value;
                }


                objGarmentTesting[grdRow.RowIndex].GarmentTestingUploadedReport = GarmentTestingUploadedReport(grdRow.RowIndex + 1, ((Repeater)grdRow.FindControl("rptLinkAttachment")).Items);
                objGarmentTesting[grdRow.RowIndex].BulkTestingUploadedReport = BulkTestingUploadedReport(grdRow.RowIndex + 1, ((Repeater)grdRow.FindControl("rptBulkTestLinkAttachment")).Items);

                objGarmentTesting[grdRow.RowIndex].Status = ((DropDownList)grdRow.FindControl("ddlStatus")).SelectedValue  == "0" ? false :true ;

                if (objGarmentTesting[grdRow.RowIndex].Id == 0)
                {
                    objGarmentTesting[grdRow.RowIndex] = this.GarmentTestingControllerInstance.CreateGarmentTesting(objGarmentTesting[grdRow.RowIndex]);
                }
                else
                {
                    objGarmentTesting[grdRow.RowIndex] = this.GarmentTestingControllerInstance.UpdateGarmentTesting(objGarmentTesting[grdRow.RowIndex]);
                }

                gridGarmentTesting.DataSource = objGarmentTesting;
                gridGarmentTesting.DataBind();
            }            
            
        }

        protected void gridGarmentTesting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Repeater)e.Row.FindControl("rptLinkAttachment")).DataSource = ((GarmentTesting)e.Row.DataItem).GarmentTestingUploadedReport;
                ((Repeater)e.Row.FindControl("rptLinkAttachment")).DataBind();
                ((Repeater)e.Row.FindControl("rptBulkTestLinkAttachment")).DataSource = ((GarmentTesting)e.Row.DataItem).BulkTestingUploadedReport;
                ((Repeater)e.Row.FindControl("rptBulkTestLinkAttachment")).DataBind();
                ((DropDownList)e.Row.FindControl("ddlStatus")).SelectedValue = ((GarmentTesting)e.Row.DataItem).Status == true ? "1" : "0";
                ((DropDownList)e.Row.FindControl("ddlStatus")).Enabled = !((GarmentTesting)e.Row.DataItem).Status;
                //((FileUpload)e.Row.FindControl("fileUploadGarmentTest")).Enabled = !((GarmentTesting)e.Row.DataItem).Status;
                //((FileUpload)e.Row.FindControl("fileUploadBulkTest")).Enabled = !((GarmentTesting)e.Row.DataItem).Status;
                HideLink = ((GarmentTesting)e.Row.DataItem).Status;

                HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
                (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(((GarmentTesting)e.Row.DataItem).OrderDetail.ExFactory));

                TextBox txtGarmentTestReport = e.Row.FindControl("txtGarmentTestReport") as TextBox;
                (txtGarmentTestReport.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((GarmentTesting)e.Row.DataItem).TestingCompletionDate, ((GarmentTesting)e.Row.DataItem).ReportCompletionDate));
                txtGarmentTestReport.BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((GarmentTesting)e.Row.DataItem).TestingCompletionDate, ((GarmentTesting)e.Row.DataItem).ReportCompletionDate));

                HiddenField hdnEx = e.Row.FindControl("hdnEx") as HiddenField;
                (hdnEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(((GarmentTesting)e.Row.DataItem).OrderDetail.ExFactory, ((GarmentTesting)e.Row.DataItem).OrderDetail.DC, ((GarmentTesting)e.Row.DataItem).OrderDetail.Mode));
            }
        }

        protected void rptLinkAttachment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lblAttachment")).Text = (e.Item.ItemIndex + 1).ToString();
                ((LinkButton)e.Item.FindControl("lnkBtnAttachment")).Enabled = !HideLink;
            }
        }

        protected void rptLinkAttachment_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            List<GarmentTestingUploadedReport> objGarmentTestingUploadedReport = new List<GarmentTestingUploadedReport>();
            Repeater objRepeater = ((Repeater)sender);
            int i = 0;
            foreach (RepeaterItem rptItem in objRepeater.Items)
            {
                if (e.Item.ItemIndex != rptItem.ItemIndex)
                {
                    objGarmentTestingUploadedReport.Add(new GarmentTestingUploadedReport());
                    objGarmentTestingUploadedReport[i].Id = Convert.ToInt32(((LinkButton)rptItem.FindControl("lnkBtnAttachment")).CommandArgument);
                    objGarmentTestingUploadedReport[i].UploadedReportFilePath = ((LinkButton)rptItem.FindControl("lnkBtnAttachment")).CommandName;
                    i++;
                }
            }

            objRepeater.DataSource = objGarmentTestingUploadedReport;
            objRepeater.DataBind();
            
        }

        protected void rptBulkTestLinkAttachment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lblBulkTestAttachment")).Text = (e.Item.ItemIndex + 1).ToString();
                ((LinkButton)e.Item.FindControl("lnkBulkTestBtnAttachment")).Enabled = !HideLink;
            }
        }

        protected void rptBulkTestLinkAttachment_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            List<GarmentTestingUploadedReport> objGarmentTestingUploadedReport = new List<GarmentTestingUploadedReport>();
            Repeater objRepeater = ((Repeater)sender);
            int i = 0;
            foreach (RepeaterItem rptItem in objRepeater.Items)
            {
                if (e.Item.ItemIndex != rptItem.ItemIndex)
                {
                    objGarmentTestingUploadedReport.Add(new GarmentTestingUploadedReport());
                    objGarmentTestingUploadedReport[i].Id = Convert.ToInt32(((LinkButton)rptItem.FindControl("lnkBulkTestBtnAttachment")).CommandArgument);
                    objGarmentTestingUploadedReport[i].UploadedReportFilePath = ((LinkButton)rptItem.FindControl("lnkBulkTestBtnAttachment")).CommandName;
                    i++;
                }
            }

            objRepeater.DataSource = objGarmentTestingUploadedReport;
            objRepeater.DataBind();

        }
        
        #endregion

        #region Mehods

        private void BindControl()
        {
            List<GarmentTesting> objGarmentTesting = this.GarmentTestingControllerInstance.GetGarmentTesting(StyleNumber);

            gridGarmentTesting.DataSource = objGarmentTesting;
            gridGarmentTesting.DataBind();
        }

        private string GetFileExtension(string FileName)
        {
            char saperator = '.';
            string[] temp = FileName.Split(saperator);            
            return "." + temp[temp.Length-1].ToString();
        }

        private List<GarmentTestingUploadedReport> GarmentTestingUploadedReport(int rowIndex, RepeaterItemCollection rptGarmentTestingUploadedReportCollection)
        {
            
            List<GarmentTestingUploadedReport> objGarmentTestingUploadedReportCollection = new List<GarmentTestingUploadedReport>();

            foreach (RepeaterItem rptItem in rptGarmentTestingUploadedReportCollection)
            {
                GarmentTestingUploadedReport objGarmentTestingUploadedReport = new GarmentTestingUploadedReport();
                objGarmentTestingUploadedReport.Id = Convert.ToInt32(((LinkButton)rptItem.FindControl("lnkBtnAttachment")).CommandArgument);
                objGarmentTestingUploadedReport.UploadedReportFilePath = ((LinkButton)rptItem.FindControl("lnkBtnAttachment")).CommandName;
                objGarmentTestingUploadedReportCollection.Add(objGarmentTestingUploadedReport);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFile file = Request.Files[key];

                if (file.ContentLength > 0)
                {
                    if (key.Contains((rowIndex*2) + "rid") && key.Contains("fileUploadGarmentTest"))
                    {
                        GarmentTestingUploadedReport objGarmentTestingUploadedReport = new GarmentTestingUploadedReport();
                        objGarmentTestingUploadedReport.UploadedReportFilePath = FileHelper.SaveFile(file.InputStream, file.FileName, Constants.GARMENT_TESTING_FOLDER_PATH, false, string.Empty);
                        objGarmentTestingUploadedReportCollection.Add(objGarmentTestingUploadedReport);
                    }
                }
            }

            return objGarmentTestingUploadedReportCollection;
        }

        private List<BulkTestingUploadedReport> BulkTestingUploadedReport(int rowIndex, RepeaterItemCollection rptBulkTestingUploadedReportCollection)
        {
            List<BulkTestingUploadedReport> objBulkTestingUploadedReportCollection = new List<BulkTestingUploadedReport>();

            foreach (RepeaterItem rptItem in rptBulkTestingUploadedReportCollection)
            {
                BulkTestingUploadedReport objBulkTestingUploadedReport = new BulkTestingUploadedReport();
                objBulkTestingUploadedReport.Id = Convert.ToInt32(((LinkButton)rptItem.FindControl("lnkBulkTestBtnAttachment")).CommandArgument);
                objBulkTestingUploadedReport.UploadedReportFilePath = ((LinkButton)rptItem.FindControl("lnkBulkTestBtnAttachment")).CommandName;
                objBulkTestingUploadedReportCollection.Add(objBulkTestingUploadedReport);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFile file = Request.Files[key];

                if (file.ContentLength > 0)
                {
                    if (key.Contains(((rowIndex*2)-1) + "rid") && key.Contains("fileUploadBulkTest"))
                    {
                        BulkTestingUploadedReport objBulkTestingUploadedReport = new BulkTestingUploadedReport();
                        objBulkTestingUploadedReport.UploadedReportFilePath = FileHelper.SaveFile(file.InputStream, file.FileName, Constants.GARMENT_TESTING_FOLDER_PATH, false, string.Empty);
                        objBulkTestingUploadedReportCollection.Add(objBulkTestingUploadedReport);
                    }
                }
            }

            return objBulkTestingUploadedReportCollection;
        }

        #endregion
    }
}