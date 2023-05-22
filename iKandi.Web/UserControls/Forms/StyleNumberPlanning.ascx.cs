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


namespace iKandi.Web
{
    public partial class StyleNumberPlanning : System.Web.UI.UserControl
    {

        #region Properties

        public string StyleNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["stylenumber"]))
                {
                    return Request.QueryString["stylenumber"].ToString();
                }

                return string.Empty;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
            odsBasicInfo.SelectParameters.Add("Stylenumber", this.StyleNumber.ToString());
         

        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            StatusDetail sd = (e.Row.DataItem as StatusDetail);

            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(sd.ExFactory));

            e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(sd.Mode));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(sd.Mode));
        
            Label lblCutting = e.Row.FindControl("lblCutting") as Label;
            (lblCutting.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(sd.ParentOrder.CuttingDetail.PercentagePcsCut));

            Label lblUnit = e.Row.FindControl("lblUnit") as Label;
            (lblUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(sd.Unit.FactoryCode));

            Label lblPcsStitched = e.Row.FindControl("lblPcsStitched") as Label;
            (lblPcsStitched.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(sd.ParentOrder.StitchingDetail.PercentageOverallPcsStitched));


            Label lblPcsPacked = e.Row.FindControl("lblPcsPacked") as Label;
            (lblPcsPacked.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(sd.ParentOrder.StitchingDetail.PercentageOverallPcsPacked));

            HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            (hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(sd.ParentOrder.WorkflowInstanceDetail.StatusModeID));

        }


        private void BindControls()
        {
            //GridView1.Columns[12].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.STATUS_DESIGN_CONTRACT_DETAILS_BIPL_PRICE);
        }

    }
}