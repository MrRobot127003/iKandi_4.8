// Set thickbox loading image
tb_pathToImage = "/Images/ikandi/images/loading-thickbox.gif";

var mycarousel_itemList = [
    { url: "Images/ikandi/images/img1_s.jpg", title: "" },
    { url: "Images/ikandi/images/img2_s.jpg", title: "" },
    { url: "Images/ikandi/images/img3_s.jpg", title: "" },
    { url: "Images/ikandi/images/img4_s.jpg", title: "" },
    { url: "Images/ikandi/images/img5_s.jpg", title: "" },
    { url: "Images/ikandi/images/img6_s.jpg", title: "" },
    { url: "Images/ikandi/images/img7_s.jpg", title: "" },
    { url: "Images/ikandi/images/img8_s.jpg", title: "" },
    { url: "Images/ikandi/images/img9_s.jpg", title: "" }
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
  //  jQuery(".jcarousel-list").jcarousel();
});

