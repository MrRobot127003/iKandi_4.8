<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StylePhotos.ascx.cs"
    Inherits="iKandi.Web.StylePhotos" %>
<!-- wrapper element for the large image -->
<div id="image_wrap" align=center  style="height:440px;max-width: 761px;">
    <img src="/app_themes/ikandi/images/trans_pixel.gif"   align=center  style="height:100%;width: 99%;max-width: 100%;max-height: 100%;" />
</div>
<br />
<!-- "previous page" action -->
<a class="prevPage browse left"></a>
<!-- root element for scrollable -->
<div class="scrollable">
    <!-- root element for the items -->
    <div class="items">
        <asp:Repeater runat="server" ID="rptImages">
            <ItemTemplate>
                <img alt='<%# Eval("Name") %>' src='<%# Eval("ImagePath") %>' title='<%# Eval("Name") %>' /> 
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!-- "next page" action -->
<a class="nextPage browse right"></a>
<br clear="all" />
<!-- javascript coding -->

<script>
// execute your scripts when the DOM is ready. this is a good habit
$(function() {

	// initialize scrollable
	$("div.scrollable").scrollable();

});
</script>

<script>
$(function() {

$(".items img").click(function() {

	// calclulate large image's URL based on the thumbnail URL (flickr specific)
	var url = $(this).attr("src").replace("thumb-", "");

	// get handle to element that wraps the image and make it semitransparent
	var wrap = $("#image_wrap").fadeTo("medium", 0.5);

	// the large image from flickr
	var img = new Image();

	// call this function after it's loaded
	img.onload = function() {

		// make wrapper fully visible
		wrap.fadeTo("fast", 1);

		// change the image
		wrap.find("img").attr("src", url);

	};

	// begin loading the image from flickr
	img.src = url;

// when page loads simulate a "click" on the first image
}).filter(":first").click();
});
</script>

