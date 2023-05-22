using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iKandi.Common;
using iKandi.BLL.Production;
using System.Data;
using System.Collections;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class frmGarmentProductList : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        string SearchVal = "";
        string PaDepartmentId = "";
        string FabricChkVal = "";
        
        string maxCharectL = "";
        string Garmenttext = "";
        
        string MarTag = "";
        string MarComPo = "";
        string MarColl = "";
        string MarMoq = "";
        decimal minCostval;
        decimal maxCostval;
        string sectVal = "";
        int SenSeclVal;
        ArrayList myCheckBoxes = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            binddata();
            if (!Page.IsPostBack)
            {
                DepartmentBind();
                DeparmentCurrencyFun();
                BindCurrencyDropDown();
            }


            //List<Client_Department> objLikeCount = objProductionController.GetLikeCount();

            //foreach (Client_Department LikeCont in objLikeCount)
            //{
            //    ProduCountLike = LikeCont.ProLikeCount.ToString();
            //}
        }


        protected void DepartmentBind()
        {

            DataSet ds = objProductionController.GetDepartmentName();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbListDepartment.DataSource = ds.Tables[0];
                cbListDepartment.DataTextField = "DepartmentName";
                cbListDepartment.DataValueField = "ID";
                cbListDepartment.DataBind();
            }
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                chkTagsName.DataSource = ds.Tables[1];
                chkTagsName.DataTextField = "TypeOfTage";
                chkTagsName.DataValueField = "TagsID";
                chkTagsName.DataBind();
            }
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                chkComposition.DataSource = ds.Tables[2];
                chkComposition.DataTextField = "Composition";
                //chkComposition.DataValueField = "ID";
                chkComposition.DataBind();
            }
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                cbFabricList.DataSource = ds.Tables[3];
                cbFabricList.DataTextField = "FabricName";
                cbFabricList.DataBind();
            }
            for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            {
                chkCollection.DataSource = ds.Tables[4];
                chkCollection.DataTextField = "Collection";
                chkCollection.DataValueField = "CollectionID";
                chkCollection.DataBind();
            }
            for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            {
                chkMoq.DataSource = ds.Tables[5];
                chkMoq.DataTextField = "MOQ";
                chkMoq.DataValueField = "Wastage_Id";
                chkMoq.DataBind();
            }
           
        }
        protected void DeparmentCurrencyFun() {
            DataSet ds = objProductionController.GetDepartmentCurrency(SenSeclVal);
          

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtrate = ds.Tables[0];
                    String str = dtrate.Rows[0]["MaxRate"].ToString();
                    string[] maxval = str.Split(' ');
                    string maxval1 = maxval[0];
                    string maxval2 = maxval[1];

                    String minstr = dtrate.Rows[0]["MinRate"].ToString();
                    string[] minval = minstr.Split(' ');
                    string minval1 = minval[0];
                    string minval2 = minval[1];

                    hdnCurrency.Value = minval1;

                    if (hdnMinValone.Value == "")
                    {
                        hdnMinVal.Value = minval2;
                    }
                    if (hdnMinValone.Value != "")
                    {
                        if (Convert.ToDecimal(hdnMinValone.Value) > Convert.ToDecimal(hdnMinVal.Value))
                        {
                            hdnMinValone.Value = hdnMinValone.Value;
                        }
                    }
                    if (hdnMaxVal.Value == "")
                    {
                        hdnMaxOneVal.Value = maxval2;
                        hdnMaxVal.Value = maxval2;
                    }
                    if (hdnMaxVal.Value != "")
                    {
                        if (Convert.ToDecimal(hdnMaxOneVal.Value) > Convert.ToDecimal(hdnMaxVal.Value))
                        {
                            hdnMaxVal.Value = hdnMaxVal.Value;
                            // hdnMinValone.Value = "";

                        }
                    }
                    if (hdnMinValone.Value != "")
                    {
                        if (Convert.ToDecimal(hdnMinValone.Value) == Convert.ToDecimal(hdnMinVal.Value))
                        {
                            lblMinMaxSelctedPrice.Text = maxval1 + " " + hdnMinVal.Value + " - " + maxval1 + " " + hdnMaxOneVal.Value;
                        }
                    }
                    else
                    {
                        lblMinMaxSelctedPrice.Text = maxval1 + " " + hdnMinVal.Value + " - " + maxval1 + " " + hdnMaxOneVal.Value;
                    }


                }
            
        }
        protected void BindCurrencyDropDown()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objProductionController.BindCurrencyDropDownList();
            if (dt.Rows.Count > 0)
            {
                ddlCurrencyConvert.DataSource = dt;
                ddlCurrencyConvert.DataTextField = "VALUE";
                ddlCurrencyConvert.DataValueField = "ID";
                ddlCurrencyConvert.DataBind();
            }
        }
        protected void binddata()
        {

            foreach (ListItem aListItem in cbListDepartment.Items)
            {

                if (aListItem.Selected)
                {
                    if (PaDepartmentId == string.Empty)
                    {
                        PaDepartmentId = aListItem.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + aListItem.Text + "</span>";
                    }
                    else
                    {
                        PaDepartmentId += "," + aListItem.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + aListItem.Text + "</span>";
                    }

                   // DeparmentCurrencyFun();
                }
            }
            foreach (ListItem item in cbFabricList.Items)
            {
                if (item.Selected)
                {
                    if (FabricChkVal == string.Empty)
                    {
                        FabricChkVal = item.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + item.Text + "</span>";
                    }
                    else
                    {
                        FabricChkVal += "," + item.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + item.Text + "</span>";
                    }
                }

            }
            foreach (ListItem item in chkTagsName.Items)
            {
                if (item.Selected)
                {
                    if (MarTag == string.Empty)
                    {
                        MarTag = item.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + item.Text + "</span>";
                    }
                    else
                    {
                        MarTag += "," + item.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + item.Text + "</span>";
                    }
                }

            }
            foreach (ListItem item in chkComposition.Items)
            {
                if (item.Selected)
                {
                    if (MarComPo == string.Empty)
                    {
                        MarComPo = item.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + item.Text + "</span>";
                    }
                    else
                    {
                        MarComPo += "," + item.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + item.Text + "</span>";
                    }
                }

            }
            foreach (ListItem item in chkCollection.Items)
            {
                if (item.Selected)
                {
                    if (MarColl == string.Empty)
                    {
                        MarColl = item.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + item.Text + "</span>";
                    }
                    else
                    {
                        MarColl += "," + item.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + item.Text + "</span>";
                    }
                }

            }
            foreach (ListItem item in chkMoq.Items)
            {
                if (item.Selected)
                {
                    if (MarMoq == string.Empty)
                    {
                        MarMoq = item.Value;
                        Garmenttext += "<span class='GarmentFabric'> " + item.Text + "</span>";
                    }
                    else
                    {
                        MarMoq += "," + item.Value;
                        Garmenttext += " <span class='GarmentFabric'>" + item.Text + "</span>";
                    }
                }

            }
            GarmentTextShow.InnerHtml = Garmenttext;

            sectVal = ddlCurrencyConvert.SelectedValue;
            if (sectVal != "")
            {
                SenSeclVal = Convert.ToInt32(ddlCurrencyConvert.SelectedValue);
            }
            else
            {
                SenSeclVal = 3;
            }
            if (hdnMaxVal.Value != "")
            {
                if (SenSeclVal == 3)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value);
                }
                if (SenSeclVal == 1)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value) * Convert.ToDecimal(73.53);
                }
                if (SenSeclVal == 2)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value) * Convert.ToDecimal(94.21);
                }
                if (SenSeclVal == 4)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value) * Convert.ToDecimal(81.98);
                }
                if (SenSeclVal == 5)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value) * Convert.ToDecimal(7.77);
                }
                if (SenSeclVal == 6)
                {
                    maxCostval = Convert.ToDecimal(hdnMaxVal.Value) * Convert.ToDecimal(73.48);
                }
            }
            else {
                maxCostval = 0;
            }

            if (hdnMinValone.Value != "")
            {
                if (SenSeclVal == 3)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value);
                }
                if (SenSeclVal == 1)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value) * Convert.ToDecimal(73.53);
                }
                if (SenSeclVal == 2)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value) * Convert.ToDecimal(94.21);
                }
                if (SenSeclVal == 4)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value) * Convert.ToDecimal(81.98);
                }
                if (SenSeclVal == 5)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value) * Convert.ToDecimal(7.77);
                }
                if (SenSeclVal == 6)
                {
                    minCostval = Convert.ToDecimal(hdnMinValone.Value) * Convert.ToDecimal(73.48);
                }
            }
            else
            {
                minCostval = 0;
            }

            List<Client_Department> objDesinsDes = objProductionController.GetDesinsPatterns(SearchVal, PaDepartmentId, FabricChkVal, MarTag, MarComPo, MarColl, MarMoq, minCostval, maxCostval, SenSeclVal);
            StringBuilder ProductListSB = new StringBuilder();

            foreach (Client_Department strclient in objDesinsDes)
            {

               //string ImgPath = "http://ikandi.org.uk:82/uploads/style/" + strclient.DesignsImg;
                string ImgPath = "http://localhost:3220/uploads/style/" + strclient.DesignsImg;
                maxCharectL = strclient.FabShortDescription;
                string str = strclient.MarketingPrice;
                // string[] s1 = str.Split(' ');
                // if()
                string countmore = strclient.MarkingCount;
                ProductListSB.Append("<div class='ProductPagination'>");
                ProductListSB.Append("<div class='col-md-3 ProductListImages'>");
                ProductListSB.Append("<div class='Productcard'>");
                ProductListSB.Append("<div class='Productcardimage'>");
                ProductListSB.Append("<img src='" + ImgPath + "' onclick='currentFunPath(this)' id='" + strclient.FabricStyleId + "_" + SenSeclVal + "' />");
                ProductListSB.Append("</div>");
                ProductListSB.Append("<div class='col-md-9' style='padding-left: 4px;'>");
                ProductListSB.Append("<div class='col-md-12 p-l-0 ProducTitle'>" + strclient.ProTitle + "</div>");
                if (maxCharectL.Length > 27)
                {
                    ProductListSB.Append("<div class='col-md-12 p-l-0' style='padding-left:0px !important' data-title ='" + strclient.FabShortDescription + "'><p class='maxwidthLength' style='margin-bottom: 2px;'>" + strclient.FabShortDescription + "</p></div>");
                }
                else
                {
                    ProductListSB.Append("<div class='col-md-12 p-l-0' style='padding-left:0px !important'><p style='margin-bottom: 2px;'>" + strclient.FabShortDescription + "</p></div>");
                }
                ProductListSB.Append("</div>");
                ProductListSB.Append("<div class='col-md-3'>");
                if (countmore.Length > 0)
                {
                    ProductListSB.Append("<div class='col-md-12 ProductLike' style='padding-left: 4px;'><i class='fa fa-heart-o' aria-hidden='true' onclick='FontAwesomeFun(this)' id='" + strclient.FabricStyleId + "' LikeCount='" + strclient.FabricStyleId + "' ></i><div class='txtColorBack' id='DivLikeCuont'>" + strclient.MarkingCount + "</div></div>");
                }
                else
                {
                    ProductListSB.Append("<div class='col-md-12 ProductLike' style='padding-left: 4px;'><i class='fa fa-heart-o' aria-hidden='true' onclick='FontAwesomeFun(this)' id='" + strclient.FabricStyleId + "' LikeCount='" + strclient.FabricStyleId + "' ></i></div>");

                }
                ProductListSB.Append("</div>");
                if (strclient.MarketingPrice == "N/A")
                {
                    ProductListSB.Append("<div class='col-md-12' style='padding-left: 4px;'><div class='PriceEnquiry'  onclick='PriceEnquiryFun(this)' id='" + strclient.FabricStyleId + "'>" + strclient.MarketingPrice + "<span class='PriceEnquiryHover'>Click here for Costing Enquiries </span></div></div>");
                }
                else
                {
                    ProductListSB.Append("<div class='col-md-12' style='padding-left: 4px;'>" + strclient.MarketingPrice + "</div>");
                }
                ProductListSB.Append("</div>");
                ProductListSB.Append("</div>");
                ProductListSB.Append("</div>");
            }
            ProductList.InnerHtml = ProductListSB.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text != "")
            {
                SearchVal = txtSearchProduct.Text;
            }
            else
            {
                SearchVal = "";
            }
            if (hdnMinValone.Value != "")
            {
                if (Convert.ToDecimal(hdnMinValone.Value) < Convert.ToDecimal(hdnMinVal.Value))
                {
                    hdnMinValone.Value = "";
                }
                if (hdnMinValone.Value != "")
                {
                    if (Convert.ToDecimal(hdnMinValone.Value) == Convert.ToDecimal(hdnMinVal.Value))
                    {
                        if (Convert.ToDecimal(hdnMaxOneVal.Value) >= Convert.ToDecimal(hdnMaxVal.Value))
                        {
                            hdnMinValone.Value = "";
                        }
                    }
                }
               

            }
            //DeparmentCurrencyFun();
            binddata();
            ScriptManager.RegisterStartupScript(Page, GetType(), "callback", "callback();", true);

        }

        protected void SelectCurrencyCha(object sender, EventArgs e)
        {
            sectVal = ddlCurrencyConvert.SelectedValue;
            hdnMaxVal.Value = "";
            hdnMinValone.Value = "";
            if (sectVal != "")
            {
                SenSeclVal = Convert.ToInt32(ddlCurrencyConvert.SelectedValue);
            }
            else
            {
                SenSeclVal = 3;
            }
            DeparmentCurrencyFun();
            binddata();
          // DepartmentBind();

           // ScriptManager.RegisterStartupScript(Page, GetType(), "costRangfun", "costRangfun();", true);
        }

    }
}