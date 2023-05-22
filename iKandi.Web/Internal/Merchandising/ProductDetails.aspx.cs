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

namespace iKandi.Web.Internal.Merchandising
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        public int ProductNameFro
        {
            get;
            set;
        }
        public int ProductCurrency
        {
            get;
            set;
        }
        //public string ProStyleNoFo
        //{
        //    get;
        //    set;
        //}
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CommonString"] != null)
            {
                ProductNameFro = Convert.ToInt32(Request.QueryString["CommonString"]);
            }
            if (Request.QueryString["CurrencyString"] != null)
            {
                ProductCurrency = Convert.ToInt32(Request.QueryString["CurrencyString"]);
            }
            if (!Page.IsPostBack)
            {
                bindproductdetails();
            }
           

            //ProductName.InnerText = str2;
            //ProStyleNo.InnerText = str1;
        }
        protected void bindproductdetails()
        {
            //Start Left section
            Client_Department objDesinsDes = objProductionController.GetProductDetails(ProductNameFro, ProductCurrency);

            ProductName.InnerText = objDesinsDes.GarmentDepartmentName;
            ProStyleNo.InnerText = objDesinsDes.GarmentStyleNo;
            string abc = objDesinsDes.GarmentStyleNo;
            StringBuilder ProductDetailsSB = new StringBuilder();
            string shortDes = objDesinsDes.DepartmentShortDes;

            //added by raghvinder on 05-03-2020 start
            string MarketingPrice = objDesinsDes.MarketingPrice;
            //added by raghvinder on 05-03-2020 end

            string LongDes = objDesinsDes.DepartmentlongDes;
            string FabricName = objDesinsDes.DesigFabricName;
            string DepName = objDesinsDes.GarmentDepartmentName;
           // string MainImg = "http://ikandi.org.uk:82/uploads/style/" + objDesinsDes.DesignsImg;
            string MainImg = "http://localhost:3220/uploads/style/" + objDesinsDes.DesignsImg;
             string countlike=objDesinsDes.MarkingCount;
            //string SideImg1 = "http://ikandi.org.uk:82/uploads/style/" + objDesinsDes.ProDuctImg1;
            //string SideImg2 = "http://ikandi.org.uk:82/uploads/style/" + objDesinsDes.ProDuctImg2;
            //string SideImg3 = "http://ikandi.org.uk:82/uploads/style/" + objDesinsDes.ProDuctImg3;
            //string SideImg4 = "http://ikandi.org.uk:82/uploads/style/" + objDesinsDes.ProDuctImg4;
             string SideImg1 = "http://localhost:3220/uploads/style/" + objDesinsDes.ProDuctImg1;
             string SideImg2 = "http://localhost:3220/uploads/style/" + objDesinsDes.ProDuctImg2;
             string SideImg3 = "http://localhost:3220/uploads/style/" + objDesinsDes.ProDuctImg3;
             string SideImg4 = "http://localhost:3220/uploads/style/" + objDesinsDes.ProDuctImg4;
            string Compo= objDesinsDes.MarkingCompositon;
            string compositon="";
            if(Compo.Length>0){
                   compositon="(<span style='font-size:14px;'>" +Compo+ "</span>)";
            }
            else{
                compositon="";
            }
            string DepartName = "";
            if (DepName.Length > 0)
            {
                DepartName = " (<span style='font-size:14px;font-weight:500'>" + DepName + "</span>)";
            }
            else {
                DepartName = "";
            }

            ProductDetailsSB.Append("<div class='col-md-7'>");
            ProductDetailsSB.Append("<div class='row'>");
            ProductDetailsSB.Append("<div class='col-md-2'>");
            ProductDetailsSB.Append("<div class='SideImage'>");
            ProductDetailsSB.Append("<span class='active' data-target='#myCarousel' data-slide-to='0'><img src='" + MainImg + "' /></span>");
            if (SideImg2.Length > 38)
            {
                ProductDetailsSB.Append("<span data-target='#myCarousel' data-slide-to='1'><img src='" + SideImg2 + "' /></span>");
            }
            if (SideImg3.Length > 38)
            {
                ProductDetailsSB.Append("<span data-target='#myCarousel' data-slide-to='2'><img src='" + SideImg3 + "' /></span>");
            }
            if (SideImg4.Length > 38)
            {
                ProductDetailsSB.Append("<span data-target='#myCarousel' data-slide-to='3'><img src='" + SideImg4 + "' /></span>");
            }
               
            ProductDetailsSB.Append("</div>");
            ProductDetailsSB.Append("</div>");
            //Start Slider Image
            ProductDetailsSB.Append("<div class='col-md-10'>");
            ProductDetailsSB.Append("<div class='MainImage'>");
            ProductDetailsSB.Append("<div id='myCarousel' class='carousel slide' data-ride='carousel' data-interval='false'>");
            ProductDetailsSB.Append("<div class='carousel-inner'>");
            ProductDetailsSB.Append("<div class='item active'><img src='" + MainImg + "' /></div>");
           // ProductDetailsSB.Append("<div class='item'><img src='" + SideImg2 + "' /></div>");
            if (SideImg2.Length > 38)
            {
                ProductDetailsSB.Append("<div class='item'><img src='" + SideImg2 + "' /></div>");
            }
            if (SideImg3.Length > 38)
            {
                ProductDetailsSB.Append("<div class='item'><img src='" + SideImg3 + "' /></div>");
            }
           
            if (SideImg4.Length > 38)
            {
                ProductDetailsSB.Append("<div class='item'><img src='" + SideImg4 + "' /></div>");
            }
            
            ProductDetailsSB.Append("</div>");

            ProductDetailsSB.Append("<a class='left carousel-control' href='#myCarousel' data-slide='prev'><i class='fa fa-chevron-left' aria-hidden='true'></i></a>");
            ProductDetailsSB.Append("<a class='right carousel-control' href='#myCarousel' data-slide='next'><i class='fa fa-chevron-right' aria-hidden='true'></i></a>");
          
            ProductDetailsSB.Append("</div>");
            ProductDetailsSB.Append("</div>");
            ProductDetailsSB.Append("</div>");
            //End Slider Image
            ProductDetailsSB.Append("</div>");
            ProductDetailsSB.Append("</div>");
            //end Left section
            //Start Right section
            ProductDetailsSB.Append("<div class='col-md-5'>");
            ProductDetailsSB.Append("<div class='productDescription'>");
            ProductDetailsSB.Append("<div class='col-md-12 ProductCategory'>" + objDesinsDes.ProTitle + "" + DepartName + "</div>");
            ProductDetailsSB.Append("<div class='ProductCategory col-md-12' style='Font-weight:400;!important'>" + FabricName + " " + compositon + "</div></br></br>");
            ProductDetailsSB.Append("<div class='col-md-12'><p>" + shortDes + " </p></div></br></br>");
            ProductDetailsSB.Append("<div class='col-md-2'><span class='btnInquiry' id='" + abc + "' onclick='EmailModal(this)'>Enquiry</span></div>");
            if (countlike.Length>0)
            {
            ProductDetailsSB.Append("<div class='social col-md-2'> <i class='fa fa-heart-o' onclick='FontAwesomeFun(this)' id='" + ProductNameFro + "' LikeCount='" + ProductNameFro + "'></i><div class='txtColorBack' id='DivLikeCuont'>" + objDesinsDes.MarkingCount + "</div></div>");
            }
            else{
                 ProductDetailsSB.Append("<div class='social col-md-2'> <i class='fa fa-heart-o' onclick='FontAwesomeFun(this)' id='" + ProductNameFro + "' LikeCount='" + ProductNameFro + "'></i></div>");
           
            }
            //added by raghvinder on 05-03-2020 start           
            ProductDetailsSB.Append("<div class='col-md-12'>" + MarketingPrice + " </div></br></br>");
            //added by raghvinder on 05-03-2020 end

            ProductDetailsSB.Append("<div class='col-md-12'><p>" + objDesinsDes.MarkingTag+ "</p></div>");
            ProductDetailsSB.Append("<div class='col-md-12'><p>" + objDesinsDes.MarkingCollect + "</p></div>");
            ProductDetailsSB.Append("<div class='col-md-12'><p>" + LongDes + "</p></div>");
          //  ProductDetailsSB.Append("<p>" + FabricDec + "</p>");
            ProductDetailsSB.Append("</div>");
            ProductDetailsSB.Append("</div>");
            //end Right section

            ProductDetail.InnerHtml = ProductDetailsSB.ToString();
        }
    }
}