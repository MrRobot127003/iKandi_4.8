<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Press.aspx.cs" Inherits="iKandi.Web.press" MasterPageFile="~/layout/Public.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
   <script type="text/javascript">
// Set thickbox loading image
tb_pathToImage = "images/loading-thickbox.gif";
</script>
<script type="text/javascript">
// Ride the carousel...
jQuery(document).ready(function() {
    jQuery(".jcarousel-list").jcarousel();
});
</script>


    <%--<script type="text/javascript">
    
    
    tb_pathToImage = "App_Themes/ikandi/images/loading-thickbox.gif";

var mycarousel_itemList = [
    {url: "../App_Themes/ikandi/images/o02_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/o01_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n01_m.jpg", title: ""},
    
    {url: "../App_Themes/ikandi/images/n01_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n02_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n02_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n03_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n03_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp03_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp03_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp05_m", title: ""},
    {url: "../App_Themes/ikandi/images/pp05_s", title: ""},
    {url: "../App_Themes/ikandi/images/pp06_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp06_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp07_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp07_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p01_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p01_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p02_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p02_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p03_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p03_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p04_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p04_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p05_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p05_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p06_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p06_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/o02_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/o02_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n04_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n04_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n05_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n05_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n06_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/n06_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp01_m", title: ""},
    {url: "../App_Themes/ikandi/images/pp01_s", title: ""},
    {url: "../App_Themes/ikandi/images/pp02_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp02_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp08_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp08_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp09_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/pp09_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p07_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p07_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p09_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p09_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p10_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p10_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p11_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p11_s.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p12_m.jpg", title: ""},
    {url: "../App_Themes/ikandi/images/p12_s.jpg", title: ""}
    
    
];

function mycarousel_itemLoadCallback(carousel, state)
{
    for (var i = carousel.first; i <= carousel.last; i++) {
        if (carousel.has(i)) {
            continue;
        }

        if (i > mycarousel_itemList.length) {
            break;
        }

        // Create an object from HTML
        var item = jQuery(mycarousel_getItemHTML(mycarousel_itemList[i-1])).get(0);

        // Apply thickbox
        tb_init(item);
        carousel.add(i, item);
    }
};
/**
 * Item html creation helper.
 */
function mycarousel_getItemHTML(item)
{
    var url_m = item.url.replace(/_s.jpg/g, '_m.jpg');
    return '<a href="' + url_m + '" title="' + item.title + '" class="opacityit"><img  src="' + item.url + '" width="284" height="120" border="0" alt="' + item.title + '" /></a>';
};

jQuery(document).ready(function() {
    jQuery(".jcarousel-list").jcarousel();
});

    </script>
    --%>
  
    					<div id="banner_cor">
						<div id="holder3"></div>
						<div id="lnk_title">press pictures</div>                
						<div id="wrappresspic">  
								<div class="jcarousel-scope"> 
								<ul class="jcarousel-list">
									<li><a href="../App_Themes/ikandi/images/o02_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/o01_s.jpg" width="180px" /></a></li>								
									<li><a href="../App_Themes/ikandi/images/n01_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n01_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/n02_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n02_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/n03_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n03_s.jpg" width="180px" /></a></li>								
									<li><a href="../App_Themes/ikandi/images/pp03_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp03_s.jpg" width="180px" /></a></li>

									<li><a href="../App_Themes/ikandi/images/pp04_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp04_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/pp05_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp05_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/pp06_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp06_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/pp07_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp07_s.jpg" width="180px" /></a></li>									
									<li><a href="../App_Themes/ikandi/images/p01_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p01_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p02_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p02_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p03_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p03_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p04_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p04_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p05_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p05_s.jpg" width="180px" /></a></li>

									<li><a href="../App_Themes/ikandi/images/p06_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p06_s.jpg" width="180px" /></a></li>   
								</ul>
								<ul class="jcarousel-list">
									<li><a href="../App_Themes/ikandi/images/o02_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/o02_s.jpg" width="180px" /></a></li>								
									<li><a href="../App_Themes/ikandi/images/n04_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n04_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/n05_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n05_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/n06_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/n06_s.jpg" width="180px" /></a></li>								
									<li><a href="../App_Themes/ikandi/images/pp01_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp01_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/pp02_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp02_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/pp08_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp08_s.jpg" width="180px" /></a></li>

									<li><a href="../App_Themes/ikandi/images/pp09_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/pp09_s.jpg" width="180px" /></a></li>								
									<li><a href="../App_Themes/ikandi/images/p07_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p07_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p08_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p08_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p09_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p09_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p10_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p10_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p11_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p11_s.jpg" width="180px" /></a></li>
									<li><a href="../App_Themes/ikandi/images/p12_m.jpg" id="opacityit" class="thickbox"><img src="../App_Themes/ikandi/images/p12_s.jpg" width="180px" /></a></li>							
								</ul>
								</div>
						</div>

						<div id="presspage">
						  <h6>Picture Gallery</h6><br />Images published in the press
					  </div>
				</div>

</asp:Content>
