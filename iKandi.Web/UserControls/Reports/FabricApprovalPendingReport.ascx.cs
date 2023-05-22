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

namespace iKandi.Web
{
    public partial class FabricApprovalPendingReport : BaseUserControl
    {
       DataSet dsPendingApproval = new DataSet();

       #region Properties

       public int ClientId
       {
           get
           {
               if (!string.IsNullOrEmpty(Request.QueryString["clientId"]))
               {
                   return Convert.ToInt32(Request.QueryString["clientId"]);
               }
               else
               {
                   return Convert.ToInt32(ddlClients.SelectedValue);
               }
           }
       }

       public int DepartmentId
       {
           get
           {
               if (!string.IsNullOrEmpty(Request.QueryString["deptId"]))
               {
                   return Convert.ToInt32(Request.QueryString["deptId"]);
               }
               else
               {
                   return Convert.ToInt32(hiddenDeptId.Value);
               }
           }
       }

       public int Stage
       {
           get
           {
               if (!string.IsNullOrEmpty(Request.QueryString["stage"]))
               {
                   return Convert.ToInt32(Request.QueryString["stage"]);
               }
               else
               {
                   return Convert.ToInt32(radioStage.SelectedValue);
               }
           }
       }
       #endregion

       #region Event Handlers

       protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;            

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;

            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(Convert.ToDateTime(dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["ExFactory"])));

            double dhlNumber = 0;
            int result;
            string FabricDetails = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["FabricDetails"].ToString();
            string ClientID = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["ClientId"].ToString();
            string FabricName = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["FabricName"].ToString();
            string OrderID = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["OrderID"].ToString();
            string StyleID = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["StyleID"].ToString();
            string DHLNumber = dsPendingApproval.Tables[0].Rows[e.Row.RowIndex]["DHLNumber"].ToString();


            //if (int.TryParse( FabricDetails, out prdNumber))
            //{
            //    FabricDetails = "PRD:" + FabricDetails;
            //}

            var FabDet = FabricDetails.Split(' ');
            if ((FabDet.Length == 1 && Int32.TryParse(FabDet[0], out result)) || (FabDet.Length == 2 && FabDet[1].Length <= 2))
                if (!string.IsNullOrEmpty(FabDet[0]))
                {
                    if (Int32.TryParse(FabDet[0], out result))
                    {
                        FabricDetails = "PRD:" + FabricDetails;
                        result = 0;
                    }
                }

            ((Label)e.Row.FindControl("lblFabricDetails")).Text = " " + FabricDetails;

            ((HyperLink)e.Row.FindControl("hlkApprovals")).NavigateUrl = (FabricDetails.ToString().IndexOf("PRD") > -1) ? "/Internal/Fabric/FabricApprovals.aspx?styleid=" + StyleID + "&clientid=" + ClientID + "&fabric=" + FabricName + "&orderid=" + "&fabricdetails=" + FabricDetails.ToString().Replace("PRD:", "") : "/Internal/Fabric/FabricApprovals.aspx?styleid=" + StyleID + "&clientid=" + ClientID + "&fabric=" + FabricName + "&orderid=" + OrderID + "&fabricdetails=" + FabricDetails;

            if (double.TryParse(DHLNumber, out dhlNumber))
            {
                if (DHLNumber.Length == 10)
                    ((HyperLink)e.Row.FindControl("hlkAwb")).NavigateUrl = string.Format(Constants.FABRIC_AWB_PATH, DHLNumber);   
            }
                      
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        #endregion

        private void BindControls()
        {
            hiddenClientId.Value = Convert.ToString(this.ClientId);
            hiddenStage.Value = Convert.ToString(this.Stage);

            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            dsPendingApproval = this.ReportControllerInstance.GetFabricPendingApproval(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, this.ClientId, this.DepartmentId, this.Stage);
            grdApprovals.DataSource = dsPendingApproval;
            grdApprovals.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

            PageHelper.RemoveJScriptVariable("selectedDeptID");
            PageHelper.AddJScriptVariable("selectedDeptID", Convert.ToInt32(hiddenDeptId.Value));

        }
    }
}