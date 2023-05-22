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

using iKandi.Common;


namespace iKandi.Web
{
    public partial class FITsTopsSection : BaseUserControl
    {

        #region Properties

        private string StyleNumber
        {
            get
            {
                if (null != Request.QueryString["StyleCodeVersion"])
                {
                    string styleNumber;

                    styleNumber = Constants.ExtractStyleCode(Request.QueryString["StyleCodeVersion"].Trim());
                    return styleNumber;
                }

                return "-1";
            }
        }

        private int deptID;
        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
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

        protected void grdBasicInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnSerialNumber = e.Row.FindControl("hdnSerialNumber") as HiddenField;
                (hdnSerialNumber.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(((OrderDetail)e.Row.DataItem).ExFactory));

                HiddenField hdnTopSendActual = e.Row.FindControl("hdnTopSendActual") as HiddenField;
                (hdnTopSendActual.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentActual, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
            }
        }

        #endregion

        #region Private Methods

        private void BindControls()
        {
            InlinePPM inlinePPM = this.InlinePPMControllerInstance.GetInlinePPM(this.StyleNumber, this.DeptID);

            // bind repeater with inline ppm data
            grdBasicInfo.DataSource = inlinePPM.OrderContracts;
            grdBasicInfo.DataBind();
        }
        #endregion
    }
}