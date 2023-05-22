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
using System.IO;

namespace iKandi.Web.UserControls.Lists
{
    public partial class FabricQualityList : BaseUserControl
    {
        List<FabricQuality> objFabricQuality = new List<FabricQuality>();

        # region field

        int TotalRowCount = 0;

        # endregion

        #region GetGridpageindex


        public string PageIndex
        {
            get;
            set;
        }
        //END
        #endregion
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            BindControls();
        }

        public void grdFabricQuality_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string buyers = string.Empty;

                for (int j = 0; j < objFabricQuality[e.Row.RowIndex].Buyers.Count; j++)
                {

                    if (buyers == string.Empty)
                    {
                        buyers = objFabricQuality[e.Row.RowIndex].Buyers[j].Client.CompanyName;
                    }
                    else
                    {
                        buyers += ", " + objFabricQuality[e.Row.RowIndex].Buyers[j].Client.CompanyName;
                    }
                }

                //((Label)e.Row.FindControl("lblBuyerName")).Text = buyers;
                ((Label)e.Row.FindControl("lblOrigin")).Text = ((Origin)objFabricQuality[e.Row.RowIndex].Origin).ToString();


                string pics = string.Empty;
                for (int i = 0; i < objFabricQuality[e.Row.RowIndex].Pictures.Count; i++)
                {

                    if (pics == string.Empty)
                    {
                        if (!String.IsNullOrEmpty(objFabricQuality[e.Row.RowIndex].Pictures[i].ImageFile))
                            pics = objFabricQuality[e.Row.RowIndex].Pictures[i].ImageFile;
                    }
                    //else
                }

                //HyperLink hypSample1 = e.Row.FindControl("hypSample1") as HyperLink;
                //if (!String.IsNullOrEmpty(pics))
                //    hypSample1.NavigateUrl = "~/Uploads/Quality/thumb-" + pics.ToString();
                //else
                //    hypSample1.Visible = false;

                Image imgFabricQuality = e.Row.FindControl("imgFabricQuality") as Image;
                if (!String.IsNullOrEmpty(pics))
                    imgFabricQuality.ImageUrl = "~/Uploads/Quality/thumb-" + pics.ToString();
                else
                    imgFabricQuality.Visible = false;

                if (Convert.ToInt32(objFabricQuality[e.Row.RowIndex].Origin) == 1)
                {
                    //((Label)e.Row.FindControl("lblOrigin")).Text = "INDIAN";
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("Table1")).Visible = true;
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("tblPriceList")).Visible = false;
                }
                else if (Convert.ToInt32(objFabricQuality[e.Row.RowIndex].Origin) == 2)
                {
                    //((Label)e.Row.FindControl("lblOrigin")).Text = "IMPORTED";
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("Table1")).Visible = false;
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("tblPriceList")).Visible = true;
                }
                else
                {
                    //((Label)e.Row.FindControl("lblOrigin")).Text = "";
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("Table1")).Visible = false;
                    ((System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("tblPriceList")).Visible = false;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hdnDDGroup.Value = ddlGroup.SelectedValue.ToString();
            hdnDDGroup.Value = ddlReg.SelectedValue.ToString();
            BindControls();
        }


        //public void RptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        ((LinkButton)e.Item.FindControl("linkbtnPaging")).Text = (e.Item.ItemIndex + 1).ToString();
        //        ((LinkButton)e.Item.FindControl("linkbtnPaging")).CommandArgument = (e.Item.ItemIndex + 1).ToString();
        //    }

        //}

        //public void linkbtnPaging_Oncommand(object sender, CommandEventArgs e)
        //{
        //    objFabricQuality = this.FabricQualityControllerInstance.GetFabricQuality(grdFabricQuality.PageSize, Convert.ToInt32(e.CommandArgument), out TotalRowCount);
        //    grdFabricQuality.DataSource = objFabricQuality;
        //    grdFabricQuality.DataBind();



        //}

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;

            if (link == null) return;

            int fabricQualityID = Convert.ToInt32(link.CommandArgument);

            this.FabricQualityControllerInstance.DeleteFabricQuality(fabricQualityID);

            BindControls();
        }

        #endregion

        # region Methods

        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.FABRIC_QUALITY));
            }
            ////DropdownHelper.BindClients(ddlClients as ListControl);
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {

                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
                //added by abhishek on 6/7/2015
                PageIndex = Request.QueryString["PageIndex"];
                //end

            }

            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            hdnDDGroup.Value = ddlGroup.SelectedValue.ToString();
            hdnDDIsReg.Value = ddlReg.SelectedValue.ToString();
            objFabricQuality = this.FabricQualityControllerInstance.GetFabricQuality(HyperLinkPager1.PageSize = 9, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, txtSearch.Text, Convert.ToInt32(ddlGroup.SelectedValue), Convert.ToInt32(hiddenSubGroupId.Value), Convert.ToString(txtGsmFrom.Text), Convert.ToString(txtGsmTo.Text), Convert.ToString(txtWidthFrom.Text), Convert.ToString(txtWidthTo.Text), Convert.ToString(txtPriceFrom.Text), Convert.ToString(txtPriceTo.Text), Convert.ToInt32(ddlReg.SelectedValue), Convert.ToInt32(ddlOrder1.SelectedValue), Convert.ToInt32(ddlOrder2.SelectedValue), Convert.ToInt32(ddlOrder3.SelectedValue), Convert.ToInt32(ddlOrder4.SelectedValue));
            grdFabricQuality.DataSource = objFabricQuality;
            grdFabricQuality.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

        }

        # endregion

        protected void grdFabricQuality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnTest_Click(object sender, EventArgs e)
        //{
        //    //CourierController controller = new CourierController();
        //    ReportController controller = new ReportController();

        //    if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //        Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);


        //    DateTime fromDate = DateTime.MinValue;
        //    DateTime toDate = DateTime.MinValue;

        //    if (!string.IsNullOrEmpty(txtfrom.Text))
        //        fromDate = DateHelper.ParseDate(txtfrom.Text).Value;
        //    if (!string.IsNullOrEmpty(txtTo.Text))
        //        toDate = DateHelper.ParseDate(txtTo.Text).Value;


        //    //DateTime ExDate = DateHelper.ParseDate(txtDate.Text).Value;

        //    string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Production List -" + fromDate.ToString("dd MMM yyy") + ".pdf");

        //    //controller.GenerateDailyCourierReport(pdfFilePath, CourrierDate);
        //    int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

        //    controller.GenerateDailyProductionReport(pdfFilePath, txtsearch.Text, fromDate, toDate, Convert.ToInt32(ddlClients.SelectedValue), UserId);

        //protected void btnTest_Click(object sender, EventArgs e)
        //{
        //    CourierController controller = new CourierController();
        //    //ReportController controller = new ReportController();

        //    if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //        Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);




        //    DateTime CourrierDate = DateHelper.ParseDate(txtfrom.Text).Value;

        //    string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List -" + CourrierDate.ToString("dd MMM yyy") + ".pdf");

        //    controller.GenerateDailyCourierReport(pdfFilePath, CourrierDate);
        //    //int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

        //    //controller.GenerateDailyProductionReport(pdfFilePath, txtsearch.Text, fromDate, toDate, Convert.ToInt32(ddlClients.SelectedValue), UserId);
        //}


        //}




    }
}




