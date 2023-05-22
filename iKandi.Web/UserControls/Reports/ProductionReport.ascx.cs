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
using iKandi.Common;
using iKandi.BLL;
using System.IO;

namespace iKandi.Web
{
    public partial class ProductionReport : BaseUserControl
    {

        #region Properties

        public int UserID
        {
            get
            {
                int userID = 0;

                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 35)
                    userID = ApplicationHelper.LoggedInUser.UserData.ManagerID;
                else
                    userID = ApplicationHelper.LoggedInUser.UserData.UserID;

                return userID;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            BindControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode));

            Label lblEx = e.Row.FindControl("lblEx") as Label;
            (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode));

            HiddenField hdnStatus = e.Row.FindControl("hdnStatus") as HiddenField;
            (hdnStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID));

            Label lblSealDate = e.Row.FindControl("lblSealDate") as Label;
            (lblSealDate.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(od.SealETA, od.ParentOrder.Fits.SealDate));

            HiddenField hdnUnit = e.Row.FindControl("hdnUnit") as HiddenField;
            (hdnUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(od.Unit.FactoryCode));

            HiddenField hdnTopActual = e.Row.FindControl("hdnTopActual") as HiddenField;
            (hdnTopActual.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.ParentOrder.InlinePPMOrderContract.TopSentActual));

            Label lblPacked = e.Row.FindControl("lblPacked") as Label;
            (lblPacked.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(od.ParentOrder.StitchingDetail.PercentageOverallPcsPacked));
            
            Label lblPcsCutPercent = e.Row.FindControl("lblPcsCutPercent") as Label;
            (lblPcsCutPercent.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(od.ParentOrder.CuttingHistory.PercentagePcsCut));

            Label lblPcsStitchedPercent = e.Row.FindControl("lblPcsStitchedPercent") as Label;
            (lblPcsStitchedPercent.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(od.ParentOrder.StitchingDetail.PercentageOverallPcsStitched));
            
            string AccessoryHistory = od.AccessoryHistory;
            if (AccessoryHistory != null)
            {
                if (AccessoryHistory.IndexOf("<br/><br/>") > -1)
                {
                    string[] delim = { "<br/><br/>" };
                    string[] AccessoryHistoryarray = AccessoryHistory.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < AccessoryHistoryarray.Length; i++)
                    {
                        Label lbl = new Label();
                        lbl.Text = AccessoryHistoryarray[i] + "<br/>";
                        lbl.Attributes.Add("class", "accessary_column_style");
                        if (i % 2 == 0)
                        {
                            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                        }
                        Label lblAccessary = e.Row.FindControl("lblAccessary") as Label;
                        lblAccessary.Controls.Add(lbl);                        
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }


        protected void BindControls()
        {
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();         

            if (!IsPostBack)
            {
                DropdownHelper.BindUnitByUserId(ddlUnit as ListControl, this.UserID);
                DropdownHelper.BindClients(ddlClients as ListControl);
            }

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtfrom.Text))
                fromDate = DateHelper.ParseDate(txtfrom.Text).Value;

            if (!string.IsNullOrEmpty(txtTo.Text))
                toDate = DateHelper.ParseDate(txtTo.Text).Value;

            GridView1.DataSource = this.ReportControllerInstance.GetProductionReportInfo(txtsearch.Text, fromDate, toDate, Convert.ToInt32(ddlClients.SelectedValue), this.UserID,  Convert.ToInt32(ddlUnit.SelectedValue));
            GridView1.DataBind();


        }

        protected void btnPdf_click(object sender, EventArgs e)
        {
            ReportController controller = new ReportController();

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtfrom.Text))
                fromDate = DateHelper.ParseDate(txtfrom.Text).Value;

            if (!string.IsNullOrEmpty(txtTo.Text))
                toDate = DateHelper.ParseDate(txtTo.Text).Value;

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Production Report -" + DateTime.Today.ToString("dd MMM yyy hh-mm-ss") + ".pdf");

            //bool success = controller.GenerateDailyProductionReport(pdfFilePath, txtsearch.Text, fromDate, toDate, Convert.ToInt32(ddlClients.SelectedValue), this.UserID, Convert.ToInt32(ddlUnit.SelectedValue));

            this.RenderFile(pdfFilePath, "Production-Report.PDF", Constants.CONTENT_TYPE_PDF);
        }
    }
}