<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iKandi.Web._Default"
    MasterPageFile="~/layout/Public.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">

    <script type="text/javascript">
    tb_pathToImage = "/App_Themes/ikandi/images/loading-thickbox.gif";

var mycarousel_itemList = [
    {url: "App_Themes/ikandi/images/img1_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img2_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img3_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img4_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img5_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img6_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img7_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img8_s.jpg", title: ""},
    {url: "App_Themes/ikandi/images/img9_s.jpg", title: ""}
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
    
   

  <div id="banner">
          	<div id="wrap">  
                <div class="jcarousel-scope"> 
                <ul class="jcarousel-list">
                <li><a href="App_Themes/ikandi/images/img1_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img1_s.jpg" width="284px" height="120"  /></a></li>
                <li><a href="App_Themes/ikandi/images/img2_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img2_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img3_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img3_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img4_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img4_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img5_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img5_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img6_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img6_s.jpg" width="284px" height="120" /></a></li>   
                <li><a href="App_Themes/ikandi/images/img7_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img7_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img8_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img8_s.jpg" width="284px" height="120" /></a></li>
                <li><a href="App_Themes/ikandi/images/img9_m.jpg" id="opacityit" class="thickbox"><img src="App_Themes/ikandi/images/img9_s.jpg" width="284px" height="120" /></a></li>   
                </ul>
                </div>
              </div>			
				<div id="presspic" onClick="window.location.href='presspictures.html'"></div>
	  	  </div>
     
</asp:Content>
