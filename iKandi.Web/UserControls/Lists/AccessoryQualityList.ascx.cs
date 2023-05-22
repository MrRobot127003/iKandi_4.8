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


namespace iKandi.Web.UserControls.Lists
{


    public partial class AccessoryQualityList : BaseUserControl
    {

        List<AccessoryQuality> accessoryqualityobj = new List<AccessoryQuality>();

        # region field
        int TotalRowCount = 0;

        # endregion


        # region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {

            BindControls();

        }

        public void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string buyers = string.Empty;
                for (int i = 0; i < accessoryqualityobj[e.Row.RowIndex].Buyers.Count; i++)
                {

                    if (buyers == string.Empty)
                    {
                        buyers = accessoryqualityobj[e.Row.RowIndex].Buyers[i].Client.CompanyName;
                    }
                    else
                    {
                        buyers += ", " + accessoryqualityobj[e.Row.RowIndex].Buyers[i].Client.CompanyName;
                    }
                    //((Label)e.Row.FindControl("lblBuyerName")).Text = ((Label)e.Row.FindControl("lblBuyerName")).Text + accessoryqualityobj[e.Row.RowIndex].Buyers[i].Client.CompanyName + ",";

                }

                ((Label)e.Row.FindControl("lblBuyerName")).Text = buyers;
                ((Label)e.Row.FindControl("lblOriginName")).Text = ((Origin)accessoryqualityobj[e.Row.RowIndex].Origin).ToString();
                ((Label)e.Row.FindControl("lblBuyerName")).Text = buyers;

                          
                //Label lblAccRef = e.Row.FindControl("lblAccRef") as Label;
                //lblAccRef.Text = "ACC" + String.Format("{0:000000}", accessoryqualityobj[e.Row.RowIndex].AccRef);  

                string pics = string.Empty;
                for (int i = 0; i < accessoryqualityobj[e.Row.RowIndex].Pictures.Count; i++)
                {

                    if (pics == string.Empty)
                    {
                        if (!String.IsNullOrEmpty(accessoryqualityobj[e.Row.RowIndex].Pictures[i].ImageFile))
                            pics = accessoryqualityobj[e.Row.RowIndex].Pictures[i].ImageFile;
                    }
                    //else
                }

                //HyperLink hypSample1 = e.Row.FindControl("hypSample1") as HyperLink;
                //if (!String.IsNullOrEmpty(pics))
                //    hypSample1.NavigateUrl = "~/Uploads/Quality/" + pics.ToString();
                //else
                //    hypSample1.Visible = false;

                Image imgAccessoryQuality = e.Row.FindControl("imgAccessoryQuality") as Image;
                if (!String.IsNullOrEmpty(pics))
                    imgAccessoryQuality.ImageUrl = "~/Uploads/Quality/thumb-" + pics.ToString();
                else
                    imgAccessoryQuality.Visible = false;
                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
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

        //    accessoryqualityobj = this.AccessoryQualityControllerInstance.GetAccessoryQuality(GridView1.PageSize, Convert.ToInt32(e.CommandArgument), out TotalRowCount);
        //    GridView1.DataSource = accessoryqualityobj;
        //    GridView1.DataBind();

        //    ((LinkButton)sender).Enabled = false;
        //}

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;

            if (link == null) return;

            int accessoryQualityID = Convert.ToInt32(link.CommandArgument);

            this.AccessoryQualityControllerInstance.DeleteAccessoryQuality(accessoryQualityID);

            BindControls();
        }


        # endregion


        # region Methods


        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindParentCategories(ddlGroup, Convert.ToInt32(CategoryType.ACCESSORY_QUALITY));
            }

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
                 
            //System.Diagnostics.Debugger.Break();

            accessoryqualityobj = this.AccessoryQualityControllerInstance.GetAccessoryQuality(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, txtSearch.Text, Convert.ToInt32(ddlGroup.SelectedValue), Convert.ToInt32(hiddenSubGroupId.Value), Convert.ToString(txtPriceFrom.Text), Convert.ToString(txtPriceTo.Text), Convert.ToInt32(ddlReg.SelectedValue), Convert.ToInt32(ddlOrder1.SelectedValue), Convert.ToInt32(ddlOrder2.SelectedValue), Convert.ToInt32(ddlOrder3.SelectedValue));
            GridView1.DataSource = accessoryqualityobj;
            GridView1.DataBind();

          this.HyperLinkPager1.TotalRecords = TotalRowCount;
          //this.HyperLinkPager1.PageIndex = 1;
          int TotalPageCount=  this.HyperLinkPager1.CalculateTotalPages();
       
        }

        # endregion













    }
}