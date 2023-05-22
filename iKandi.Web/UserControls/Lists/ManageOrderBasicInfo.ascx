<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageOrderBasicInfo.ascx.cs"
    Inherits="iKandi.Web.ManageOrderBasicInfo" %>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<style type="text/css">
    input[type='checkbox']:checked
    {
        opacity: 0.3;
    }
    
    body
    {
        text-transform: capitalize !important;
        font-family: arial,sans-serif;
    }
    .MOProdSecBlue
    {
        color: Blue !important;
    }
    .MOProdSecGray
    {
        background-color: transparent !important;
        color: #807F80 !important;
    }
    .newcss
    {
        text-transform: capitalize !important;
        width: 400px !important;
    }
    
    .newcss2
    {
        background-color: #f9f9fa !important;
        text-transform: capitalize !important;
        line-height: 20px;
        font-size: 9px;
        padding: 0px !important;
    }
    .newcss3
    {
        background-color: #f9f9fa !important;
        text-transform: capitalize !important;
        line-height: 20px;
        font-size: 9px;
        padding-bottom: 25px !important;
        border-bottom: 2px solid #ccc;
    }
    
    .newtext
    {
        color: #807F80;
        font-size: 9px;
    }
    
    .newtext2
    {
        color: #0000ee !important;
        font-size: 9px;
    }
    
    .newtext3
    {
        color: #0000ee;
        font-size: 9px;
        font-weight: bold;
        text-transform: uppercase !important;
    }
    
    .newtext14
    {
        color: #0000ee;
        font-size: 9px;
        font-weight: bold;
        text-transform: capitalize !important;
    }
    
    .newtext4
    {
        font-size: 9px;
        color: #807F80 !important;
    }
    
    .newtext5
    {
        font-size: 9px;
        color: #000000 !important;
    }
    
    .newtext6
    {
        font-size: 9px;
        color: #0000ee !important;
    }
    
    .newtext7
    {
        font-size: 9px;
        color: #000000 !important;
    }
    
    .newtext8
    {
        font-size: 9px;
        color: #807f80 !important;
    }
    
    .newtext9
    {
        font-size: 9px;
        color: #0000ee !important;
    }
    
    .newtext10
    {
        font-size: 9px;
        color: #000000 !important;
    }
    
    .newtext11
    {
        color: #fe1010;
        font-size: 9px;
        font-weight: bold;
    }
    
    .newtext12
    {
        color: #0000ee;
        font-size: 9px;
    }
    
    .newtext13
    {
        width: 190px !important;
    }
    
    label
    {
        font-size: 12px !important;
        color: #ffffff !important;
    }
    
    td
    {
        border: 1px solid #e6e6e6 !important;
        border-bottom: 2px solid #e6e6e6 !important;
    }
    
    
    
    .item_list2
    {
        border-collapse: collapse;
        border: 2px solid #e6e6e6;
        margin-right: 0px;
    }
    
    .item_list2 TD
    {
        padding: 0px !important;
        background-color: #f9f9fa;
        border: 1px solid #e6e6e6;
        text-align: left;
        vertical-align: top;
        font-family: arial;
    }
    
    .item_list2 TH
    {
        color: #98a9ca;
        font-size: 8px;
        width: 100%;
        line-height: 15px;
        vertical-align: top;
        background-color: #39589c !important;
        text-transform: capitalize;
        border: 1px solid #e6e6e6;
        text-align: left;
        padding: 4px;
        font-weight: normal;
    }
    
    .item_list2 TD input[type=text], .item_list1 TD textarea
    {
        color: #0000ff;
        border: 0;
        width: 100%;
        text-align: center;
        vertical-align: middle;
    }
    
    .item_list2 TD select
    {
        color: #0000ff;
    }
    
    .inner_item_list2 TD input[type=text], .item_list2 TD textarea
    {
        border: 0;
        width: 100%;
    }
    
    .item_list2 a
    {
        text-decoration: none;
        text-transform: capitalize !important;
    }
    
    .item_list2 a:hover
    {
        text-decoration: none;
        text-transform: capitalize !important;
    }
    
    span
    {
        text-transform: capitalize !important;
    }
    
    
    
    .withborder1
    {
        width: 57%;
        text-align: left !important;
        color: #807f80;
        border-bottom: none !important;
        border-right: 1px solid #e6e6e6 !important;
        border-left: 1px solid #e6e6e6 !important;
        border-top: 1px solid #e6e6e6 !important;
    }
    
    .noborder1
    {
        width: 57%;
        text-align: left !important;
        border: none !important;
    }
    
    .withborder2
    {
        width: 18%;
        border: 1px solid #e6e6e6 !important;
        text-align: center !important;
        border-bottom: none !important;
        border-left: none !important;
    }
    
    .noborder2
    {
        width: 18%;
        text-align: center !important;
        border: none !important;
    }
    
    .withborder3
    {
        border: 1px solid #e6e6e6 !important;
        text-align: left !important;
        border-bottom: none !important;
        border-left: none !important;
    }
    
    .noborder3
    {
        text-align: center;
        border: none !important;
    }
    
    
    
    .printborder
    {
        border: 1px solid #e6e6e6 !important;
        border-top: none !important;
        border-left: none !important;
        text-align: center !important;
    }
    
    .noprintborder
    {
        text-align: center;
        border: none !important;
    }
    
    .printborder1
    {
        border: 1px solid #e6e6e6 !important;
        border-top: none !important;
        border-left: 1 !important;
        text-align: left !important;
    }
    
    .noprintborder1
    {
        text-align: left !important;
        border: none !important;
    }
    
    .overlay
    {
        display: block;
    }
    
    .FabricCls
    {
        color: #0000ee !important;
        font-size: 9px;
    }
    
    .FabricCls1
    {
        font-size: 9px;
    }
    
    .shipmentdate
    {
        color: #ffffff !important;
    }
    
    .summaryColor1
    {
        color: #807f80 !important;
    }
    
    .summaryColor2
    {
        color: #ff3300 !important;
    }
    
    .summaryColor3
    {
        color: #006600 !important;
    }
    
    .orangecolor
    {
        background-color: #fd9903 !important;
    }
    .yellowcolor
    {
        background-color: #FDFD96 !important;
    }
    .Garycolor
    {
        background-color: #d7e4bc !important;
    }
    .Garybackcolor
    {
        background-color: #F9F9FA !important;
    }
    
    .AccessRow tr td
    {
        background-color: #d7e4bc;
    }
    
    .lblcolor
    {
        color: #0000ee !important;
    }
    .AccessRow tr
    {
        background-color: #d7e4bc;
    }
    
    .hidelabel
    {
        display: none;
    }
    
    .aligntext
    {
        text-align: left;
    }
    
    .lblDateAlign
    {
        text-align: center;
    }
    
    hr
    {
        border: 1;
        height: 1px;
    }
    .line-format
    {
        font-size: 8px !important;
        background: none;
        margin-top: 2px;
        text-align: left !important;
        color: #807F80 !important;
    }
    .line-format2
    {
        font-size: 8px !important;
        background: none !important;
        margin-top: 2px;
        text-align: left !important;
        color: Blue !important;
    }
    
    
    
    /*-------------------------add by Prabhaker-5-nov------------------------*/
    
    .floatingHeader
    {
        position: fixed;
        top: 0px;
        visibility: hidden;
        margin: auto;
        z-index: 100;
        backface-visibility: hidden;
        width: 1645px !important;
        left: 27px;
    }
    .persist-header
    {
        table-layout: fixed;
    }
    
    /*------------------------------------------------End-css-5-nov---------------------*/
    /*-------------Add by abhishek- 22/2/2016-------------*/
    .photoshot input[type='checkbox']:checked
    {
        opacity: 1 !important;
    }
    .mo-reallocation-img img
    {
        height: 20px;
        width: 20px;
    }
    /*-------------end by abhishek- 22/2/2016-------------*/
    .production-sec
    {
        table-layout: fixed;
    }
    
    .production-sec td
    {
        padding: 0px !important;
    }
    
    .production-sec td input[type="text"], .item_list1 TD textarea
    {
        width: 92%;
    }
    
    iframe
    {
        background: #fff !important;
    }
    .cfn3 h2
    {
        font-family: Arial;
        font-size: 18px;
    }
    .table td
    {
        text-align: center;
    }
    select
    {
        color: Gray;
    }
    
    .disable_a_href
    {
        pointer-events: none;
    }
    .form_box TD
    {
        vertical-align: top !important;
    }
    .yellow-back td
    {
        background: #FDFD96 !important;
    }
    .yellow-back td input
    {
        background: #FDFD96 !important;
    }
    .checkbox-margin input
    {
        margin: 0px;
        vertical-align: middle;
    }
    .Classnone
    {
        display: none;
    }
    
    input[type="checkbox"]
    {
        border: 5px solid red !important;
    }
    
    .bordercolorcheckbox input[type='checkbox']:checked
    {
        opacity: 1 !important;
    }
</style>
<style type="text/css">
    .style-remove-border td
    {
        border: 0px !important;
    }
    /*updated css by bharat 21-jan-19*/
    #facebox table div.content
    {
        overflow: auto !important;
    }
    #SizePopUp1_GridView1 th
    {
        color: rgb(152, 169, 202) !important;
        width: 60px;
    }
    #facebox .form_box .form_heading
    {
        text-transform: capitalize !important;
        color:#fff !important;
    }
    /*Add css 1-mar*/
    #sb-wrapper-inner
    {
        max-height: 459px !important;
        border: 8px solid rgba(181, 177, 177, 0.77);
        min-height: 400px !important;
        padding: 0px !important;
        overflow: auto !important;
        border-radius: 4px;
    }
     #facebox .form_box .form_heading
    {
        color:#fff !important;
        text-transform: capitalize !important;
    }
    
    #ctl01_grdWorkflowHistory th
    {
        color:#98a9ca !important;
    }
    .view_left .middle {
     background:#ffff !important;
    padding: 0px 1px 10px 0px !important;
    width: 234px !important;
    margin-left: 55px;
    box-shadow: 7px 2px 12px 1px;
    }
    .form_heading {
        background-color: #39589c;
        color: #fff !important;
        margin-left: -1px;
    }
  .style-remove-border td {
    border: 0px !important;
    padding: 7px 20px 0px;
   }
  .topHeader{
      position: relative;
      top: -7px;
 }
 .topHeader a{
     color:#fff;
     text-decoration:none;
     }
    .style-remove-border td a {
         text-decoration: none;
      }
      .style-remove-border td a:hover {
         text-decoration: underline;
      }
.view_left .arrow {
    left: 44px;
    position: absolute;
    top: 38px;
}


</style>
<script type="text/javascript" src="../../js/facebox.js"></script>
<script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
<%-- <script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>--%>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript">

    $(function () {

        $(".th").datepicker({ dateFormat: 'dd M (D)' });


    });

</script>
<script type="text/javascript">
    var elamget = "";

    var BaseOrderDetailId;
    var ShippedRowId;
    var chkthis;


    var hdnPagesizeClientID = '<%=hdnPagesize.ClientID %>';

    var hdnPageIndexClientID = '<%=hdnPageIndex.ClientID %>';

    $(function () {

        $(".loadingimage").hide();

        $('span.number-with-commas', '#main_content').FormatNumberWithCommas();

        $("#hdnpageindex").val($("#" + hdnPageIndexClientID).val());

        $("#hdnpagesize").val($("#" + hdnPagesizeClientID).val());


        $('#lightbox-image-details-caption').hide();

        $('#lightbox-image-details-currentNumber').hide();

        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif',

            showTitle: false

        });
        //abhishek 6 aug
//        $('*[id*=ddlModeChange]').each(function () {
//            
//            if ($(this).attr('value') == "37" || $(this).attr('value') == "38") {
//                
//                var SplitId = $(this).attr('id').split('_')[6];              
//                $("#ctl00_cph_main_content_mb_GridView1_" + SplitId + "_txtWeight").attr("disabled", "disabled");
//            }

//        });

    });



    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';

    var proxy = new ServiceProxy(serviceUrl);



    function hideLinks(srcElem) {

        var objRow = $(srcElem).parents("tr");

        $("#links").hide();

    }



    function showFabricPopup(StyleID, OrderDetailID, OrderID, ClientID, Fabric1, Fabric2, Fabric3, Fabric4, Fabric1Details, Fabric2Details, Fabric3Details, Fabric4Details) {

        proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID: StyleID, OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function (result) {

            result = '<div class="">' + result + "</div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

    }

    function showStichingPopup(elem) {



        if (elem.pathname == "void('True')") {

            var Ids = elem.id;

            var CId = Ids.substr(38);

            var SplitId = CId.split('_');

            var ctrlId = parseInt(CId) + parseInt(1);

            var OrderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();

            var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallStitched" + "']").val();

            var CutQuantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val();

            window.open("../OrderProcessing/ManageOrderStitchingEdit.aspx?orderdetailid=" + OrderDetailID + "&quantity=" + CutQuantity.replace(/,(?=[^,]*$)/, ''), '_blank', 'height=500,width=1000,status=yes,resizable=yes,menubar=no, scrollbars=yes,toolbar=no,location=no,directories=no');

        }

        else {

            alert('You do not have permission');

            return false;

        }

    }


    function showReallocationPopup(elem) {

        var Ids = elem.id;

        var patternSampleDate = elem.value;

        var CId = Ids.split("_")[6].substr(3);

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();


        var url = '../Merchandising/ReAllocationForm.aspx?styleId=' + styleid;
        window.open(url, '_blank', 'height=1000,width=1000,status=yes,toolbar=no,menubar=yes,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');



    }
    function UpdateWeight(elem, flag) {



        var Ids = elem.id;

        var Changevalue = elem.value;

        Changevalue = $.trim(Changevalue);

        var CId = Ids.split("_")[6].substr(3);

        var Flag = "Weight";

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        if (Changevalue != "") {

            proxy.invoke("UpdateWeight", { styleid: styleid, Changevalue: Changevalue, Flag: Flag }, function (result) {

                jQuery.facebox(result);

                jQuery.facebox('Data has been Update successfully!');

            }, onPageError, false, false);

        }

    }


    //Added By Ashish on 4/3/2014

    function showSizePopup(OrderDetailID, flag) {

        if (flag == 'True') {

            //var url = 'frmSizePopUp.aspx?OrderDetailID=' + OrderDetailID;
            //window.open(url, '_blank', 'height=400,width=400,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');


            $.get('frmSizePopUp.aspx?OrderDetailID=' + OrderDetailID, function (html) {
                $.facebox(html);
            });
            return false;

            //            proxy.invoke("GetSizesPopup", { OrderDetailID: OrderDetailID }, function (result) {

            //                result = '<div class="divReportAllOrdersPopup">' + result + "</div>";

            //                jQuery.facebox(result);



            //            }, onPageError, false, false);

        }

        else {

            alert('You do not have permission');

        }

    }

    //END



    function GetManageOrderiKandiQuantityByDept(DepartmentID) {

        proxy.invoke("GetManageOrderiKandiQuantityByDept", { DepartmentID: DepartmentID }, function (result) {

            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

    }



    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID, StyleId, StyleNo, FitsStyle, StrClientId) {



        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID, StyleId: StyleId, StyleNo: StyleNo, FitsStyle: FitsStyle, StrClientId: StrClientId }, function (result) {

            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

    }

    //    function GetManageOrderiKandiQuantityByMode(Mode) {

    //        proxy.invoke("GetManageOrderiKandiQuantityByMode", { Mode: Mode }, function (result) {

    //            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";

    //            jQuery.facebox(result);

    //        }, onPageError, false, false);

    //    }

    //Added By Ashish on 4/3/2014

    function GetManageOrderiKandiQtyByMode(m, f) {



        if (f == 'True') {

            GetManageOrderiKandiQuantityByMode(m)

        }

        else {

            alert('You do not have permission');

        }



    }



    function GetManageOrderiKandiQuantityByMode(Mode) {



        //if (flag != true) {

        proxy.invoke("GetManageOrderiKandiQuantityByMode", { Mode: Mode }, function (result) {

            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

        //}

    }






    //END



    function showStatusMeeting(OrderDetailID) {

        proxy.invoke("showStatusMeeting", { OrderDetailID: OrderDetailID }, function (result) {

            result = '<div class="">' + result + "</div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

    }



    // Show MO Shipping PopUp

    function showMoShippingInfo(rowNo, styleId, remark, stylenumber) {



        var exFactoryDate = $("#exfactory" + rowNo).val();

        proxy.invoke("GetMoShippingInfo", { styleId: styleId, remark: remark, exfactorydate: exFactoryDate, stylenumber: stylenumber }, function (result) {

            // jQuery.facebox(result);

            $(".divRemarksMo").html(result);

            $(".divRemarksMo").show();

            $('input.date-picker', '#main_content').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd m y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });

        }, onPageError, false, false);

    }



    function showAccessoryPopup(orderdetailId, accessoryname, quantity) {



        proxy.invoke("ShowManageOrderAccessoryPopup", { OrderDetailID: orderdetailId, AccessoryName: accessoryname, Quantity: quantity }, function (result) {

            jQuery.facebox(result);

        }, onPageError, false, false);

    }

    function showSamPopUp(orderid, statusID, styleid) {

        window.open("ManageOrderSAMPopUp.aspx?OrderID=" + orderid + "&Styleid=" + styleid + "&StatusID=" + statusID, "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=no,resizable=0,width=500,height=305");

        return false;

    }

    //Add By Prabhaker 09-April-18

    function showModePopUp(elem) {
        //debugger;
        Mode = elem.value;
        var Ids = elem.id;
        var CId = Ids.substr(39);
        var SplitId = CId.split('_');


        var w = 600;
        var h = 265;
        var left = Number((screen.width / 2) - (w / 2));
        var tops = Number((screen.height / 2) - (h / 2));

        hdnModeId = $("#<%= GridView1.ClientID %>_ctl" + SplitId[0] + "_hdnModeId").val();
        orderDetailsID = $("#<%= GridView1.ClientID %>_ctl" + SplitId[0] + "_hdnOrderDetailsID").val();
        hdnModeName = $("#<%= GridView1.ClientID %>_ctl" + SplitId[0] + "_hdnModeName").val();

        window.open("frmProfitOnMode.aspx?Mode=" + Mode + "&OrderDetailId=" + orderDetailsID + "&PreviousMode=" + hdnModeName + "&PreviousId=" + hdnModeId, "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=yes,resizable=0,width=990,height=405, top=" + tops + ", left=" + left);

        return false;

    }
    function ShowCuttinglistprint(elem, orderDetailsID, Mode, PreviousMode, OrderID) {
        debugger;
        var Ids = elem.id;
        var SplitId = Ids.split('_')[6];
        var w = 600;
        var h = 265;
        var left = Number((screen.width / 2) - (w / 2));
        var tops = Number((screen.height / 2) - (h / 2));
        var sURL = '../../Internal/OrderProcessing/FrmCuttingSheetPrint.aspx?Mode=' + Mode + "&OrderDetailId=" + orderDetailsID + "&PreviousMode=" + PreviousMode + "&PreviousId=" + Mode;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;


    }

    //End of Code Prabhaker 09-April-18

    //------------------------------------------------------- Edit By surendra on 10-Feb-2013-----------------------------------------------------------

    function UpdateMDAForMO(elem) {
        var orderDetailsID;
        var Ids = elem.id;

        var mda = elem.value;



        var tr = $("#<%=GridView1.ClientID%> tr");

        var CId = Ids.substr(3);

        var ctrlId = parseInt(CId) + parseInt(1);
        if (ctrlId < 10) {
            orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_hdnOrderDetailsID" + "']").val();
        }
        else {
            orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + ctrlId + "_hdnOrderDetailsID" + "']").val();
        }





        $(".loadingimage").show();

        proxy.invoke("UpdateMDA", { OrderDetailsID: orderDetailsID, MDA: mda }, function (result) {

            $(".loadingimage").hide();

            // jQuery.facebox(result);

            jQuery.facebox('MDA has been saved successfully!');

        }, onPageError, false, false);



    }
    function fncSave(elem) {

        var orderDetailsID;
        var Ids = elem.id;
        var CId = Ids.substr(38);
        var SplitId = CId.split('_');

        orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();

    }



    function UpdateAccDetails(Id1, Id2, value, per) {


        var accessoryWorkingDetailID = $("#<%= GridView1.ClientID %>_ctl" + Id1 + "_repAccess_ctl" + Id2 + "_hdnAccWorkingDetailsID").val();



        var quantity = value;

        var Inhouse = per;
        var orderId = $("#<%= GridView1.ClientID %> input[id*='ctl" + Id1 + "_hdnOrderId" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + Id1 + "_hdnOrderDetailsID" + "']").val();


        //debugger;


        $(".loadingimage").show();

        // proxy.invoke("UpdateExFactory", { OrderDetailsID: orderDetailsID, ExFactory: exFactory }, function (result) {

        proxy.invoke("InsertInHouseHistory", { OrderId: orderId, OrderDetailID: orderDetailsID, AccessoryWorkingDetailID: accessoryWorkingDetailID, Quantity: quantity, PercentInHouse: Inhouse }, function (result) {

            $(".loadingimage").hide();

            jQuery.facebox(result);

            jQuery.facebox('Data has been saved successfully!');

        }, onPageError, false, false);



    }

    function UpdateAccsessoryAppDate(elem) {
        //        debugger;
        //        alert("sd");



        var Ids = elem.id;
        var val = elem.value;

        var val_ = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);

        if (val != "") {

            //var AccsessoryWorkingID = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccWorkingDetailsIDs").val();
            var AccsessoryWorkingID = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccWorkingDetailsID").val();


            var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailsID" + "']").val();

            proxy.invoke("UpdateAccAppDate", { WorkingAccID: AccsessoryWorkingID, Date: val, OrderDetailsID: orderDetailsID }, function (result) {

                jQuery.facebox('Accsessory order on date has been saved successfully!');

            }, onPageError, false, false);




        }
    }
    function CalculationonAcc(elem) {
        // debugger;
        var Ids = elem.id;
        var val = elem.value;

        var val_ = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);

        if (val != 0 || val != "") {
            //            var txtRequired = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_txtRequired").val();
            var txtRequired = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnRequiredActual").val();
            //txtRequired = txtRequired.replace(/,(?=[^,]*$)/, '')
            txtRequired = txtRequired.replace(/,/g, "");
            // debugger;
            var percent = Math.round((parseInt(val) / (parseInt(txtRequired))) * 100);
            var pervalue = percent + "%";

            $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_lblParcentInHouse").html(pervalue);
            val = elem.value.replace(/,(?=[^,]*$)/, '');
            //debugger;

            UpdateAccDetails(cId, cIds, val, percent)

            $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnQuantityAvailActual").val(val);
        }
        else {

            alert("Please Input Correct Values");

        }

    }



    function UpdateCutAvg(elem, countFabric, FabricAvg, StyleId, FabricName, txtavg, styleNumber) {




        var Ids = elem.id;
        elamget = elem;

        var cutavg = elem.value;

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');
        var OrderAverage = "";
        var UnitCaption = "";
        var Unit = "";
        var Print = "";
        var tr = $("#<%=GridView1.ClientID%> tr");
        if (FabricAvg != '') {

            // if (parseFloat(cutavg) > parseFloat(FabricAvg)) {

            //alert('This cut average can not be greater than order average ' + FabricAvg + '');
            //debugger;
            if (countFabric == '1') {


                //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFabric1STCAverage" + "']").val(FabricAvg);
                // OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric1OrderAverage" + "']").val();
                OrderAverage = FabricAvg;
                Print = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFabric1Details" + "']").html();
                var quantity = tr.find("input[name$=hdnQuantity]").val();

                var orderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
                Unit = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnUnitCaption1" + "']").val();

                var url = 'CutAvg.aspx?id=1' + '&ordavg=' + OrderAverage + '&styleid=' + StyleId + '&Fabricname=' + FabricName + '&print=' + Print + '&quantity=' + quantity + '&orderDetailID=' + orderDetailID + '&unitid=' + Unit + '&fabricavg=' + FabricAvg + '&cutavg=' + txtavg + '&styleNumber=' + styleNumber;
                window.open(url, '_blank', 'height=300,width=750,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=500%,screeny=300%, addressbar=no, directories=no, titlebar=no');

            }

            if (countFabric == '2') {

                //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFabric2STCAverage" + "']").val(FabricAvg);
                OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric2OrderAverage" + "']").val();
                Print = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFabric2Details" + "']").html();
                var quantity = tr.find("input[name$=hdnQuantity]").val();

                var orderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
                Unit = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnUnitCaption1" + "']").val();
                var url = 'CutAvg.aspx?id=2' + '&ordavg=' + OrderAverage + '&styleid=' + StyleId + '&Fabricname=' + FabricName + '&print=' + Print + '&quantity=' + quantity + '&orderDetailID=' + orderDetailID + '&unitid=' + Unit + '&fabricavg=' + FabricAvg + '&cutavg=' + txtavg + '&styleNumber=' + styleNumber;
                window.open(url, '_blank', 'height=300,width=750,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=500%,screeny=300%, addressbar=no, directories=no, titlebar=no');

            }

            if (countFabric == '3') {

                //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFabric3STCAverage" + "']").val(FabricAvg);
                OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric3OrderAverage" + "']").val();
                Print = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFabric3Details" + "']").html();
                var quantity = tr.find("input[name$=hdnQuantity]").val();

                var orderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
                Unit = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnUnitCaption1" + "']").val();
                var url = 'CutAvg.aspx?id=3' + '&ordavg=' + OrderAverage + '&styleid=' + StyleId + '&Fabricname=' + FabricName + '&print=' + Print + '&quantity=' + quantity + '&orderDetailID=' + orderDetailID + '&unitid=' + Unit + '&fabricavg=' + FabricAvg + '&cutavg=' + txtavg + '&styleNumber=' + styleNumber;
                window.open(url, '_blank', 'height=300,width=750,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=500%,screeny=300%, addressbar=no, directories=no, titlebar=no');

            }

            if (countFabric == '4') {

                //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFabric4STCAverage" + "']").val(FabricAvg);
                OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric4OrderAverage" + "']").val();
                Print = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFabric4Details" + "']").html();

                var quantity = tr.find("input[name$=hdnQuantity]").val();

                var orderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
                Unit = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnUnitCaption1" + "']").val();
                var url = 'CutAvg.aspx?id=4' + '&ordavg=' + OrderAverage + '&styleid=' + StyleId + '&Fabricname=' + FabricName + '&print=' + Print + '&quantity=' + quantity + '&orderDetailID=' + orderDetailID + '&unitid=' + Unit + '&fabricavg=' + FabricAvg + '&cutavg=' + txtavg + '&styleNumber=' + styleNumber;
                window.open(url, '_blank', 'height=300,width=750,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=500%,screeny=300%, addressbar=no, directories=no, titlebar=no');

            }

            // return false;
            //}
            //debugger;
            var tr = $("#<%=GridView1.ClientID%> tr");
            var quantity = tr.find("input[name$=hdnQuantity]").val();
            Unit = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnUnitCaption1" + "']").val();

            if (Unit == 1) {
                UnitCaption = "Kg";
            }
            else {
                UnitCaption = "mtrs";
            }
            //debugger;
            var Roundval = cutavg - OrderAverage; // Math.round(parseFloat(cutavg) - parseFloat(OrderAverage), 2)  lblFabric1Details
            //            var val = RoundUp(Roundval, 2)
            //            if (parseFloat(cutavg) > parseFloat(FabricAvg)) {
            //                //var Summary = "Var:" + val + "(S/Fall:" + parseInt((cutavg - OrderAverage) * quantity) + UnitCaption
            //                var Summary = "S/Fall:" + ' ' + parseInt((cutavg - OrderAverage) * quantity) + UnitCaption
            //                alert('Fabric was ordered @ ' + FabricAvg + ' ' + 'against cut avg ' + ' ' + cutavg + ' ' + 'This will create shortfall of' + ' ' + Summary + ' ' + '.\n Please contact Fabric GM/Director to resolve');
            //            }

            //            if (parseFloat(cutavg) < parseFloat(FabricAvg)) {
            //                //var Summary = "Var:" + val + "(Excess:" + parseInt((OrderAverage - cutavg) * quantity) + UnitCaption
            //                var Summary = "Excess:" + ' ' + parseInt((OrderAverage - cutavg) * quantity) + UnitCaption
            //                alert('Fabric was ordered @ ' + FabricAvg + ' ' + 'against cut avg ' + ' ' + cutavg + ' ' + 'This will create excess of' + ' ' + Summary + ' ' + '.\n Please contact Fabric GM/Director to resolve');
            //            }
        }


        var orderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();

        //var r = confirm("Do You Want To process on Cut Avg" + " " + cutavg);
        // var r = confirm("Do You Want To process Cut Avg for All Contract Or only for This Contract.");



    }


    function openShipedPopu(OrderDetailsID, OrderID, Qty) {


        window.open("MOShippedPopup.aspx?OrderDetailID=" + OrderDetailsID + "&OrderId=" + OrderID + "&Qty=" + Qty + "&Flag=" + "linkopen", "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=no,resizable=0,width=1000,height=400");
        return false;


    }


    function CheckShipped(elem) {
        //debugger;
        chkthis = elem;
        ShippedRowId = elem.id;
        var Ids = elem.id;
        var IsShiped;
        var ShippedDate = "";
        var CId = Ids.substr(38);
        var SplitId = CId.split('_');
        //        if (elem.checked) {
        //            IsShiped = 1;
        //        }
        //        else {
        //            IsShiped = 0;
        //        }
        //debugger;
        var va = elem.value;
        BaseOrderDetailId = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
        var OrderId = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderId" + "']").val();

        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

        //Gajendra 24-12-2015 ShippedDate = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtISShippedDate" + "']").val();
        //if (elem.checked) {
        //Gajendra 24-12-2015
        //            if (ShippedDate == "") {
        //                alert('select ship date before checking this box');
        //                elem.checked = false;
        //                return false;
        //            }
        //            else {

        window.open("MOShippedPopup.aspx?OrderDetailID=" + BaseOrderDetailId + "&OrderId=" + OrderId + "&Qty=" + Quantity, "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=no,resizable=0,width=1000,height=400");
        return false;
        //}
        //}
        //Updated by Gajendra 24-11-2015
        //        if (IsShiped == 0) {
        //            //debugger;
        //            var txtStitchQty = 0;
        //            ShippedDate = ""
        //            proxy.invoke("UpdateIsShiped", { OrderDetailsID: BaseOrderDetailId, IsShiped: IsShiped, ShippedDate: ShippedDate, ShippedQty: txtStitchQty }, function (result) {
        //                alert("Ship Removed successfully");
        //                //debugger;
        //                //Gajendra 24-12-2015 $("#ctl00_cph_main_content_mb_GridView1 input[id*='ct" + SplitId[0] + "_txtISShippedDate" + "']").val("");
        //                $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblShipped" + "']").html('Waiting to be shipped');
        //                $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblShippedCaption" + "']")[0].innerHTML = "";

        //            });
        //        }
    }
    function WriteShipmentCaption() {
        // debugger;
        var ShortExtra = "";
        var OrderDetailId = BaseOrderDetailId;
        var Ids = ShippedRowId;
        var CId = Ids.substr(38);
        var SplitId = CId.split('_');
        //Gajendra 24-12-2015
        // ShippedDate = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtISShippedDate" + "']").val();
        //var NewshipDate = //ShippedDate.split('(');
        //NewshipDate = NewshipDate[0];


        proxy.invoke("GetShippedQty", { OrderDetailsID: OrderDetailId }, function (result) {
            // debugger;
            var Quantity = result[0];
            var ShippedQty = result[1];
            var CutQty = result[2];
            var NewshipDate = result[3];
            if (parseInt(Quantity) > parseInt(ShippedQty)) {
                ShortExtra = "short";
            }
            else {
                ShortExtra = "extra";
            }
            // debugger;
            var ShortShipped = parseInt(Quantity) - parseInt(ShippedQty);
            var ctpl = parseInt(CutQty) - parseInt(ShippedQty);
            var ShortShippedPercent = (parseInt(ShortShipped) * 100) / parseInt(Quantity);
            var ctplpercenatge = (parseInt(ctpl) * 100) / parseInt(CutQty);
            ShortShippedPercent = ShortShippedPercent.toFixed(2);
            ctplpercenatge = ctplpercenatge.toFixed(2);
            var ShippedCaption = "";
            if (ctplpercenatge == "0.00") {
                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + ") On " + NewshipDate;
            }
            else {
                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL  ( " + ctplpercenatge + "%) On " + NewshipDate;
            }
            $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblShippedCaption" + "']").html(ShippedCaption);
            //Gajendra 24-12-2015  $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtISShippedDate" + "']").val("");
            $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblShipped" + "']")[0].innerHTML = "";
            chkthis.checked = true;

        }, onPageError, false, false);
    }

    //    function float_exponent(number) {
    //        exponent = 1;
    //        while (number < 1.0) {
    //            exponent += 1
    //            number *= 10
    //        }
    //        return exponent;
    //    }
    //    function format_float(number, extra_precision) {
    //        precision = float_exponent(number) + (extra_precision || 0)
    //        return number.toFixed(precision).split(/\.?0+$/)[0]
    //    }


    function RoundUp(value, places) {
        var multiplier = Math.pow(10, places);

        return (Math.round(value * multiplier) / multiplier);
    }
    function showEtaRemarks(OrderDetailId, Flag1) {
        //debugger;
        //Added By Ashish on 12/1/2014
        var url = 'MOETARemarks.aspx?Flag1=' + Flag1 + '&OrderDetailId=' + OrderDetailId;
        window.open(url, '_blank', 'height=600,width=800,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
    }
    //Added By abhishek on 21/6/2017
    function showEtaFitspopup(OrderDetailId) {


        //        var url = '../../Admin/FitsSample/FitsEtaPopup.aspx?OrderDetailId=' + OrderDetailId;
        ////var url = '../../Admin/FitsSample/FitsEtaPopupForMo.aspx?OrderDetailId=' + OrderDetailId;
        //        window.open(url, '_blank', 'height=300,width=400,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');

        var sURL = '../../Admin/FitsSample/FitsEtaPopup.aspx?OrderDetailId=' + OrderDetailId;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 350, width: 450, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    }

    // Update By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change

    function UpdateExFactoryForMO(elem) {

        var Ids = elem.id;

        var exFactory = elem.value;
        var orderDetailsID;
        var IsShipped;


        var CId = Ids.substr(9);

        var ctrlId = parseInt(CId) + parseInt(1);
        if (ctrlId > 9) {
            orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + ctrlId + "_hdnOrderDetailsID" + "']").val();
            IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;
        }
        else {
            orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_hdnOrderDetailsID" + "']").val();
            IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl0" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;
        }

        //        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_hdnOrderDetailsID" + "']").val();

        //var IsShipped = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_chkshipped" + "']");
        //        var IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl0" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;

        var Username = '<%=this.Username %>';
        if (IsShipped == 0) {

            $(".loadingimage").show();

            proxy.invoke("UpdateExFactory", { OrderDetailsID: orderDetailsID, ExFactory: exFactory, usrename: Username }, function (result) {

                $(".loadingimage").hide();

                //jQuery.facebox(result);

                jQuery.facebox('ExFactory has been saved successfully!');

            }, onPageError, false, false);

        }
        else {
            alert('Order is shipped can not change exfactory dates');
        }

    }






    function UpdateExFactoryForDC(elem) {
        //  debugger;
        var Ids = elem.id;
        // alert(Ids);
        var DC = elem.value;
        var orderDetailsID;
        var IsShipped;


        var CId = Ids.split("_")[6].substr(3);

        var ctrlId = parseInt(CId) + parseInt(1);
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();
        IsShipped = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_chkshipped" + "']").is(":checked") ? 1 : 0;

        //alert(ctrlId);
        //        if (ctrlId > 9) {
        ////            orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + ctrlId + "_hdnOrderDetailsID" + "']").val();
        //            IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;
        //        }
        //        else {
        //            //orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_hdnOrderDetailsID" + "']").val();
        //            IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl0" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;
        //        }

        //        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_hdnOrderDetailsID" + "']").val();

        //var IsShipped = $("#<%= GridView1.ClientID %> input[id*='ctl0" + ctrlId + "_chkshipped" + "']");
        //        var IsShipped = $("#ctl00_cph_main_content_mb_GridView1_ctl0" + ctrlId + "_chkshipped").is(":checked") ? 1 : 0;

        var Username = '<%=this.Username %>';
        if (IsShipped == 0) {

            $(".loadingimage").show();

            proxy.invoke("UpdateDC", { OrderDetailsID: orderDetailsID, DC: DC, usrename: Username }, function (result) {

                $(".loadingimage").hide();

                //jQuery.facebox(result);

                jQuery.facebox('DC has been saved successfully!');

            }, onPageError, false, false);

        }
        else {
            alert('Order is shipped can not change DC dates');
        }

    }
    // End By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change



    function UpdateAccesoriesApprovedDateForMO(elem) {



        var Ids = elem.id;

        var approvedDate = elem.value;



        var ctl = Ids.substr(36);

        var ct = ctl.split("_")[0].substr(3);

        var cAcc = ctl.split("_")[2].substr(3);

        // var cId = Ids.split("_")[6].substr(3);

        var tr = $("#<%=GridView1.ClientID%> tr");

        //var orderDetailsID = tr.find("input[name$=hdnOrderDetailsID]").val();

        //var accessoryWorkingDetailID = tr.find("input[name$=hdnAccWorkingDetailsID]").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + ct + "_hdnOrderDetailsID" + "']").val();

        var accessoryWorkingDetailID = $("#<%= GridView1.ClientID %> input[id*='ctl" + cAcc + "_hdnAccWorkingDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdateAccesoriesApprovedDate", { AccessoryWorkingDetailID: accessoryWorkingDetailID, OrderDetailsID: orderDetailsID, ApprovedDate: approvedDate }, function (result) {

            $(".loadingimage").hide();

            // jQuery.facebox(result);

            jQuery.facebox('Approved Date of Accessories has been saved successfully!');

        }, onPageError, false, false);



    }

    function UpdatePatternSampleDateForMO(elem, txtname) {

        debugger;

        var Ids = elem.id;

        var patternSampleDate = elem.value;

        var CId = Ids.split("_")[6].substr(3);

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        var orderid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();


        $(".loadingimage").show();

        proxy.invoke("UpdatePatternSampleDate", { OrderID: orderid, StyleId: styleid, PatternSampleDate: patternSampleDate, field: txtname, OrderDetailID: orderDetailsID }, function (result) {

            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();
            if (txtname == 'RPODUCTIONPLANINGETA')

            { jQuery.facebox('Production planing ETA Date has been saved successfully!'); }

            else if (txtname == 'stc')

            { jQuery.facebox('STC Requested Data has been saved successfully!'); }

            else {

                jQuery.facebox('Pattern Sample Data has been saved successfully!');

            }

        }, onPageError, false, false);



    }

    function UpdateShipmentOfferDateForMO(elem) {



        var Ids = elem.id;

        var shipmentdate = elem.value;

        var userID = $("#<%=hdnUserID.ClientID%>").val();

        var CId = Ids.split("_")[6].substr(3);

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdateShipmentOfferDate", { OrderDetailsID: orderDetailsID, Shipmentdate: shipmentdate, UserID: userID }, function (result) {

            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();

            jQuery.facebox('ShipmentOfferDate has been saved successfully!');

        }, onPageError, false, false);



    }



    //edited by abhishek on 25/12/2015
    //edited by abhishek on 21/1/2016
    function UpdateIC_Check(elem) {

        var Ids = elem.id;
        var cuttingSheetDate = elem.value;
        var CId = Ids.split("_")[6].substr(3);
        var IsCheked = 0;

        if (elem.checked) {
            IsCheked = 1;
        }
        else {
            IsCheked = 0;
        }

        var orderid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdateIC_Check", { OrderID: orderid, orderDetails_ID: orderDetailsID, Ischeck: IsCheked }, function (result) {

            $(".loadingimage").hide();

            jQuery.facebox('IC check saved successfully!');

        }, onPageError, false, false);



    }

    function update_OutHouse(elem) {

        var Ids = elem.id;
        var OutHouse = elem.value;
        var CId = Ids.split("_")[6].substr(3);
        var IsCheked = 0;
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("update_OutHouse", { orderDetails_ID: orderDetailsID, OutHouse: OutHouse }, function (result) {

            $(".loadingimage").hide();

            jQuery.facebox('Done!');

        }, onPageError, false, false);

    }
    function ChangeMode(elem) {
        //debugger;       
        var Modeval = elem.value;
        var Ids = elem.id;
        var CId = Ids.split("_")[6].substr(3);
        var hdnPlanforDate = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnPlanforDate" + "']");
        var txtPlannedForDate = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_txtPlannedForDate" + "']");
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        if (Modeval == "1") {
            txtPlannedForDate.css('pointer-events', 'none');
            txtPlannedForDate.val(hdnPlanforDate.val());
        }
        else {
            txtPlannedForDate.removeAttr('style');
            txtPlannedForDate.css('width', '75px');
        }

        if (txtPlannedForDate.val() != '') {
            var PlanDate = txtPlannedForDate.val();

            proxy.invoke("Update_PlanDate", { OrderDetailId: orderDetailsID, PlanType: Modeval, PlanDate: PlanDate }, function (result) {

                jQuery.facebox('Plan date has been saved successfully!');

            }, onPageError, false, false);
        }
    }
    function ChangePlanDate(elem) {
        //debugger;
        var PlanDate = elem.value;
        var Ids = elem.id;
        var CId = Ids.split("_")[6].substr(3);
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        if (PlanDate != '') {
            proxy.invoke("Update_PlanDate", { OrderDetailId: orderDetailsID, PlanType: 2, PlanDate: PlanDate }, function (result) {

                jQuery.facebox('Plan date has been saved successfully!');

            }, onPageError, false, false);
        }

    }



    function UpdateCuttingSheetDateForMO(elem, txtname) {
        //debugger;
        var Ids = elem.id;

        var cuttingSheetDate = elem.value;

        var CId = Ids.split("_")[6].substr(3);

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        var orderid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdateCuttingSheetDate", { OrderID: orderid, StyleId: styleid, CuttingSheetDate: cuttingSheetDate, orderDetails_ID: orderDetailsID, field: txtname }, function (result) {

            $(".loadingimage").hide();

            // jQuery.facebox(result);

            //  DoForcePostBack();

            if (txtname == 'Cutting')

            { jQuery.facebox('Cutting Sheet Received Data has been saved successfully!'); }

            else if (txtname == 'Production') {

                jQuery.facebox('Production Data has been saved successfully!');

            }

            else if (txtname == 'CuttingETA') {

                jQuery.facebox('Cutting ETA Data has been saved successfully!');

            }
            else if (txtname == 'HPPPMETA') {

                jQuery.facebox('HPPPM ETA Data has been saved successfully!');

            }

            else if (txtname == 'ProductionETA') {

                jQuery.facebox('Production ETA Data has been saved successfully!');

            }
            else if (txtname == 'TESTREPORTS') {

                jQuery.facebox('Test Report ETA Data has been saved successfully!');

            }
            else if (txtname == 'CDChartETA') {

                jQuery.facebox('CD chart ETA Data has been saved successfully!');

            }
            else if (txtname == 'CDChartActual') {

                jQuery.facebox('CD chart Actual ETA Data has been saved successfully!');

            }
            else if (txtname == 'ICCHECK') {

                jQuery.facebox('IC check saved successfully!');

            }
            else if (txtname == 'StrikeOff1') {

                jQuery.facebox('Strike of for first fabric saved successfully!');

            }
            else if (txtname == 'StrikeOff2') {

                jQuery.facebox('Strike of for Second fabric saved successfully!');

            }
            else if (txtname == 'StrikeOff3') {

                jQuery.facebox('Strike of for Third fabric saved successfully!');

            }
            else if (txtname == 'StrikeOff4') {

                jQuery.facebox('Strike of for Fourth fabric saved successfully!');

            }
            else if (txtname == 'HandOver') {

                jQuery.facebox('HandOver saved successfully!');

            }
            else if (txtname == 'PatternReady') {

                jQuery.facebox('PatternReady saved successfully!');

            }
            else if (txtname == 'SampleSent') {

                jQuery.facebox('SampleSent saved successfully!');

            }
            else if (txtname == 'FitsUploadCommentes') {

                jQuery.facebox('FitsUploadCommentes saved successfully!');

            }
            else if (txtname == 'PPSampleSentETA') {

                jQuery.facebox('PP Sample Sent ETA saved successfully!');

            }


            //jQuery.facebox('Cutting Sheet Received Data has been saved successfully!');

        }, onPageError, false, false);



    }
    //end by abhishek 21/1/2016
    //end by abhishek 25/12/2015



    function UpdateProductionFileDateForMO(elem) {

        var Ids = elem.id;

        var productionFileDate = elem.value;

        var CId = Ids.split("_")[6].substr(3);

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        var orderid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdateProductionFileDate", { OrderID: orderid, StyleId: styleid, ProductionFileDate: productionFileDate, orderDetails_ID: orderDetailsID }, function (result) {

            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();

            jQuery.facebox('Production File Data has been saved successfully!');

        }, onPageError, false, false);



    }



    function showFabricPopupPercent(StyleID, OrderDetailID, TotalQuantity, OrderID, FabricNo, ClientID, Fabric, FabricDetails) {

        proxy.invoke("ShowManageOrderFabricPopup", { StyleID: StyleID, OrderDetailID: OrderDetailID, TotalQuantity: TotalQuantity, OrderID: OrderID, FabricNo: FabricNo, ClientID: ClientID, Fabric: Fabric, FabricDetails: FabricDetails }, function (result) {

            jQuery.facebox(result);

        }, onPageError, false, false);

    }

    function UpdatePCSCutStitcheMO(ct, cutPercent, cutBallence, cutPiecesPercent, cutpiecesBallance, cutday, bCutIssued) {

        //debugger;

        //        var Ids = elem.id;

        //        var overallCut = elem.value;

        var pcsCut = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallCut" + "']").val();

        var pcsIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lblOAllCutIssued" + "']").val();

        var tr = $("#<%=GridView1.ClientID%> tr");

        var quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentCut = $("#<%= GridView1.ClientID %> input[id*='lblBalancePercentCut']");

        var BalanceCut = $("#<%= GridView1.ClientID %> input[id*='lblBalanceCut']");



        var orderid = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderId" + "']").val();

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStyleID" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();

        var cuttingSheetId = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnCuttingsheetID" + "']").val();

        var cuttingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnCuttingDetailID" + "']").val();



        $(".loadingimage").show();

        proxy.invoke("UpdatePCSCutStitche", { StyleId: styleid, OrderID: orderid, Quantity: quantity, OrderDetailsID: orderDetailsID, CuttingSheetId: cuttingSheetId, CuttingDetailID: cuttingDetailID, PcsCut: pcsCut, CutPercent: cutPercent, CutBallence: cutBallence, Today: cutday, BCutIssued: bCutIssued }, function (result) {



            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();

            jQuery.facebox('Cut  Data has been saved successfully!');

        }, onPageError, false, false);

        $(".loadingimage").hide();





    }



    function UpdateCutIssued(ct, allcut, cutPiecesPercent, cutpiecesBallance, cutday, balanceStitched) {



        //        var Ids = elem.id;

        //        var overallCut = elem.value;

        var pcsCut = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallCut" + "']").val();

        var pcsIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lblOAllCutIssued" + "']").val();

        var tr = $("#<%=GridView1.ClientID%> tr");

        var quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentCut = $("#<%= GridView1.ClientID %> input[id*='lblBalancePercentCut']");

        var BalanceCut = $("#<%= GridView1.ClientID %> input[id*='lblBalanceCut']");



        var orderid = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderId" + "']").val();

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStyleID" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();

        var cuttingSheetId = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnCuttingsheetID" + "']").val();

        var cuttingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnCuttingDetailID" + "']").val();









        $(".loadingimage").show();

        proxy.invoke("UpdateCutIssued", { StyleId: styleid, OrderID: orderid, Quantity: quantity, OrderDetailsID: orderDetailsID, CuttingSheetId: cuttingSheetId, CuttingDetailID: cuttingDetailID, PcsIssued: allcut, CutPiecesPercent: cutPiecesPercent, CutpiecesBallance: cutpiecesBallance, TodayPcsIssued: cutday, BalanceStitched: balanceStitched }, function (result) {





            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();

            jQuery.facebox('Cut Issue Data has been saved successfully!');

        }, onPageError, false, false);

        $(".loadingimage").hide();





    }

    function UpdateOnlyPacking(ct, packingpercent, packingBalance, allPacked) {
        //debugger;


        var pcspacked = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallPacked" + "']").val();
        pcspacked = pcspacked.replace(/,/g, "")
        var EmbIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lblOallStitchedIssued" + "']").val();
        EmbIssued = EmbIssued.replace(/,/g, "")
        var tr = $("#<%=GridView1.ClientID%> tr");

        var quantity = tr.find("input[name$=hdnQuantity]").val();

        var stitchingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStitchingDetailID" + "']").val();

        var overallPcsPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOverallPcsPacked" + "']").val();
        overallPcsPacked = overallPcsPacked.replace(/,/g, "")
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();



        if (parseInt(pcspacked) > parseInt(EmbIssued)) {

            alert('Packing can not greater then Stitching Issued');

            return false;

        }

        else {

            $(".loadingimage").show();

            proxy.invoke("UpdateOnlyPacking", { OrderDetailsID: orderDetailsID, Pcspacked: pcspacked, Packingpercent: packingpercent, PackingBalance: packingBalance, TodayPacked: allPacked }, function (result) {

                $(".loadingimage").hide();

                //jQuery.facebox(result);

                // DoForcePostBack();

                jQuery.facebox('Packing Data has been saved successfully!');

            }, onPageError, false, false);

            $(".loadingimage").hide();

        }







    }

    function UpdateOnlyEmbPcs(ct, embPicesPercent, embPicesBalance, allPacked) {

        //debugger;

        //        var Ids = elem.id;

        //        var overallCut = elem.value;

        var embpieces = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallEmb" + "']").val();
        embpieces = embpieces.replace(/,(?=[^,]*$)/, '')
        var pcsIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallEmb" + "']").val();
        pcsIssued = pcsIssued.replace(/,/g, "")
        var StitchIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lblOallStitchedIssued" + "']").val();
        StitchIssued = StitchIssued.replace(/,(?=[^,]*$)/, '')


        var stitchingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStitchingDetailID" + "']").val();

        // var pcsPackedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnPcsPackedToday" + "']").val();

        var overallPcsPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnoverallEmb" + "']").val();

        overallPcsPacked = overallPcsPacked.replace(/,/g, "")
        // var overallPcsStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOverallPcsStitched" + "']").val();

        //  var totalPcsStitchedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnTotalPcsStitchedToday" + "']").val();

        //  var expectedFinishDate = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnExpectedFinishDate" + "']").val();

        //  var isStitchingComplete = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnIsStitchingComplete" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();





        $(".loadingimage").show();

        proxy.invoke("UpdateOnlyEmbPices", { OrderDetailsID: orderDetailsID, Embpieces: embpieces, EmbPicesPercent: embPicesPercent, EmbPicesBalance: embPicesBalance, TodayEMB: allPacked }, function (result) {

            $(".loadingimage").hide();

            //jQuery.facebox(result);

            // DoForcePostBack();

            jQuery.facebox('EMB Pices Data has been saved successfully!');

        }, onPageError, false, false);

        $(".loadingimage").hide();







    }

    function IssueEmbRoidery(ct, embIssuedPercent, embIssuedBalance, allPacked) {





        //        var Ids = elem.id;

        //        var overallCut = elem.value;

        var embissued = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lblOAllEmbIssued" + "']").val();

        var emb = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_lbloverallEmb" + "']").val();

        var stitchingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStitchingDetailID" + "']").val();

        // var pcsPackedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnPcsPackedToday" + "']").val();

        var overallPcsPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnoverallEmpIssued" + "']").val();

        // var overallPcsStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOverallPcsStitched" + "']").val();

        //  var totalPcsStitchedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnTotalPcsStitchedToday" + "']").val();

        //  var expectedFinishDate = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnExpectedFinishDate" + "']").val();

        //  var isStitchingComplete = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnIsStitchingComplete" + "']").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();

        if (parseInt(embissued) > parseInt(emb)) {

            alert('EMB Issued can not greater then EMB')

            return false;

        }

        else {

            $(".loadingimage").show();

            proxy.invoke("UpdateOnlyEmbIssues", { OrderDetailsID: orderDetailsID, Embissued: embissued, EmbIssuedPercent: embIssuedPercent, EmbIssuedBalance: embIssuedBalance, AllPacked: allPacked }, function (result) {

                $(".loadingimage").hide();

                //jQuery.facebox(result);

                // DoForcePostBack();

                jQuery.facebox('EMB Issues Data has been saved successfully!');

            }, onPageError, false, false);

            $(".loadingimage").hide();

        }









    }

    function UpdatePCSStitchPackedEmbMO(ct) {



        //        var Ids = elem.id;

        //        var overallCut = elem.value;

        var tr = $("#<%=GridView1.ClientID%> tr");



        //        var isStitchingComplete = tr.find("input[name$=hdnIsStitchingComplete]").val();

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOrderDetailsID" + "']").val();

        var quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnQuantity" + "']").val();

        var stitchingDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnStitchingDetailID" + "']").val();

        var pcsPackedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnPcsPackedToday" + "']").val();

        var overallPcsPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOverallPcsPacked" + "']").val();

        var overallPcsStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnOverallPcsStitched" + "']").val();

        var totalPcsStitchedToday = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnTotalPcsStitchedToday" + "']").val();

        var expectedFinishDate = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnExpectedFinishDate" + "']").val();

        var isStitchingComplete = $("#<%= GridView1.ClientID %> input[id*='ct" + ct + "_hdnIsStitchingComplete" + "']").val();

        $(".loadingimage").show();


        proxy.invoke("UpdatePCSStitchPackedEmb", { OrderDetailsID: orderDetailsID, StitchingDetailID: stitchingDetailID, PcsSent: 10, PcsReceived: 12, PcsPackedToday: pcsPackedToday, OverallPcsPacked: overallPcsPacked, OverallPcsStitched: overallPcsStitched, Quantity: quantity, TotalPcsStitchedToday: totalPcsStitchedToday, ExpectedFinishDate: expectedFinishDate, IsStitchingComplete: isStitchingComplete }, function (result) {

            $(".loadingimage").hide();
            jQuery.facebox('Packed and Emb Data has been saved successfully!');

        }, onPageError, false, false);



    }

    function UpdatePCSStitch(elem, stitchPicesPercent, stitchPicesBalance, stitchtoday, totalstitch, balanceStitchedIssued) {

        var Ids = elem.id;

        var pcsstitch = totalstitch;

        var allStich = stitchtoday;

        var tr = $("#<%=GridView1.ClientID%> tr");

        var CId = Ids.split("_")[6].substr(3);

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        var TotalCutIssue = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_lblOAllCutIssued" + "']").val();
        $(".loadingimage").show();
        

        proxy.invoke("UpdatePCSStitch", { OrderDetailsID: orderDetailsID, PcsStitch: pcsstitch, StitchPicesPercent: stitchPicesPercent, StitchPicesBalance: stitchPicesBalance, StitchToday: allStich }, function (result) {

            $(".loadingimage").hide();
            jQuery.facebox('Stich data saved successfully!');

        }, onPageError, false, false);

    }

    function UpdatePlanedDate(elem) {
        var Ids = elem.id;

        var planneddate = elem.value;

        var CId = Ids.split("_")[6].substr(3);

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();

        $(".loadingimage").show();

        proxy.invoke("UpdatePlanneddate", { OrderDetailsID: orderDetailsID, Planneddate: planneddate }, function (result) {

            $(".loadingimage").hide();          

            jQuery.facebox('PlannedDate has been saved successfully!');

        }, onPageError, false, false);

    }
    
    //---------------------------------------------------------------End--------------------------------------------------------------------------------

    function shRemark(val) {
        showAccesoriesRemarks(0, 0, val, 0, 0, 1, 0, 0);
    }

    function showMoSanjeevInfo(exFactoryDate, styleId, OrderDetailId, stylenumber) {
        //debugger;       
        var x = screen.width / 2 - 700 / 2;
        var y = screen.height / 2 - 450 / 2;

        var url = '../../Internal/OrderProcessing/MoSanjeevRemark.aspx?styleId=' + styleId + '&OrderDetailId=' + OrderDetailId + '&exfactorydate=' + exFactoryDate + '&stylenumber=' + stylenumber + '';
        window.open(url, '_blank', 'height=550,width=920,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,  resizable=yes, left=' + x + ', top=10, addressbar=no, directories=no, titlebar=no');
        return false;

    }


    function FabricRemark(id, FabRemark) {

        showAccesoriesRemarks(id, 0, FabRemark, 0, 0, 0, 1, 0);
    }

    //Added By Ashish

    function ProductionRemark(prodRemark) {
        showAccesoriesRemarks(0, 0, prodRemark, 0, 0, 1, 0, 0);
    }

    function showMoShippingInfo(exFactoryDate, styleId, remark, stylenumber) {

        proxy.invoke("GetMoShippingInfo", { styleId: styleId, remark: remark, exfactorydate: exFactoryDate, stylenumber: stylenumber }, function (result) {          

            $(".divRemarksMo").html(result);

            $(".divRemarksMo").show();

            $('input.date-picker', '#main_content').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });

        }, onPageError, false, false);

    }   
    jQuery.noConflict();

    $('#input.date-picker', '#main_content').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });


    function showParcentPopup(a1, a2, a3, a4, a5, a6, a7) {
        showFabricPopup(a1, a2, a3, a4, a5, a6, a7, '', '', '', '', '');
    }   


    function GetOverAllCut(elem) {
        //debugger;

        var Ids = elem.id;

        var Cutday = elem.value;
        Cutday = Cutday.replace(/,/g, "")
        if (Cutday == '')

            Cutday = '0';

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var ctrl = SplitId[0];
        var tr = $("#<%=GridView1.ClientID%> tr");
        var IsstcApproved = tr.find("input[name$=hdnStcApproved]").val();
        var FlagCheck = "2";

        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + ctrl + "_hdnOrderDetailsID" + "']").val();

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ct" + ctrl + "_hdnStyleID" + "']").val();
        //alert(styleid);
        if (parseInt(Cutday) >= 20) {
            proxy.invoke("GetCut_Avg", { OrderDetailsID: orderDetailsID, CheckInlinecut: FlagCheck },

        function (result) {
            var Icount = parseInt(result);
            if (parseInt(Cutday) >= 20) {
                if (Icount == 0 || IsstcApproved == 'false') {
                    alert('Sorry,You can not enter bulk cutting(20 pieces)+till cut avg,HO PPM,STC,Pattern sample and cutting sheet dates are not completed')
                    return false;
                }
                else {
                    //debugger;
                    //alert('cut value');
                    proxy.invoke("IsOBRiskDone", { StyleId: styleid, Flag: 'CUTTING' }, function (result) {
                        //debugger;
                        var FinalOB = result;
                        if (FinalOB != '') {
                            alert('Can not enter cut value due to ' + FinalOB + ' task not done');
                            elem.value = '';
                            return false;
                        }
                        else {

                            var r = confirm("Do You Want To process on Cut" + " " + Cutday);

                            if (r == true) {
                              
                                var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

                                var hdnoverallCut = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallCut" + "']");

                                var allCut = parseInt(hdnoverallCut.val().replace(/,(?=[^,]*$)/, '')) + parseInt(Cutday)


                                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallCut" + "']").val(allCut);

                                var lblOAllCutIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val();
                                lblOAllCutIssued = lblOAllCutIssued.replace(/,/g, "")
                                if (lblOAllCutIssued == '')

                                    lblOAllCutIssued = '0';

                                var Calculation = parseInt(allCut) * 100 / parseInt(Quantity);

                                var CutPercent = parseInt(Calculation);

                                var CutBallence = parseInt(Quantity) - parseInt(allCut);

                                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentCut" + "']").val('(' + parseInt(Calculation) + '%)');

                                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceCut" + "']").val(parseInt(Quantity) - parseInt(allCut));
                                
                                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBCutIssued" + "']").val(parseInt(allCut) - parseInt(lblOAllCutIssued));

                                var BalanceCutIssued = parseInt(allCut) - parseInt(lblOAllCutIssued)

                                var ctrl = SplitId[0];

                                UpdatePCSCutStitcheMO(ctrl, CutPercent, CutBallence, 0, 0, Cutday, BalanceCutIssued);

                            }

                        }

                    }, onPageError, false, false);

                }

            }


        });
        }
        else {
            // alert(OrderDetailsID);
            FlagCheck = "1";
            proxy.invoke("GetCut_Avg", { OrderDetailsID: orderDetailsID, CheckInlinecut: FlagCheck },

        function (result) {
            var Icount = parseInt(result);
            if (parseInt(Cutday) <= 20) {
                if (IsstcApproved == 'false') {
                    alert('Inline cut not input untill Cut avg & HOPPM & STC actual date & Pattern sample date not input')
                    return false;
                }
                else {

                    var tr = $("#<%=GridView1.ClientID%> tr");

                    var r = confirm("Do You Want To process on Cut" + " " + Cutday);

                    if (r == true) {
                     
                        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

                        var hdnoverallCut = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallCut" + "']");
                        
                        var allCut = parseInt(hdnoverallCut.val().replace(/,/g, "")) + parseInt(Cutday)

                        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallCut" + "']").val(allCut);

                        var lblOAllCutIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val();
                        lblOAllCutIssued = lblOAllCutIssued.replace(/,/g, "")
                        if (lblOAllCutIssued == '')

                            lblOAllCutIssued = '0';

                        var Calculation = parseInt(allCut) * 100 / parseInt(Quantity);

                        var CutPercent = parseInt(Calculation);

                        var CutBallence = parseInt(Quantity) - parseInt(allCut);

                        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentCut" + "']").val('(' + parseInt(Calculation) + '%)');

                        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceCut" + "']").val(parseInt(Quantity) - parseInt(allCut));
                        
                        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBCutIssued" + "']").val(parseInt(allCut) - parseInt(lblOAllCutIssued));

                        var BalanceCutIssued = parseInt(allCut) - parseInt(lblOAllCutIssued)

                        var ctrl = SplitId[0];

                        UpdatePCSCutStitcheMO(ctrl, CutPercent, CutBallence, 0, 0, Cutday, BalanceCutIssued);
                    }
                }

            }

        });
        }
    }


    function GetOverAllCutIssued(elem) {
        var Ids = elem.id;

        var CutIssuedday = elem.value;
        CutIssuedday = CutIssuedday.replace(/,/g, "")
        if (CutIssuedday == '')

            CutIssuedday = '0';

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");
        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

        var PercentIssuedBal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBPercentCutIssued" + "']");

        var OverAllCut = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallCut" + "']").val();
        OverAllCut = OverAllCut.replace(/,/g, "")
        var lblOAllCutIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val();
        lblOAllCutIssued = lblOAllCutIssued.replace(/,/g, "")
        var lbloverallStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallStitched" + "']").val();
        lbloverallStitched = lbloverallStitched.replace(/,/g, "")

        var hdnoverallCutIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallCutIssued" + "']");

        var allcut = parseInt(hdnoverallCutIssued.val().replace(/,/g, "")) + parseInt(CutIssuedday);

        if (parseInt(allcut) > parseInt(OverAllCut)) {

            alert('Pcs cut always greater then Pcs Issued');
            return false
        }

        else {

            var c = confirm("Do You Want To process on Cut" + " " + CutIssuedday);

            if (c == true) {

                var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

                var CutPiecesPercent = parseInt(Calculation);

                var ballanceCutPieces = parseInt(OverAllCut) - parseInt(allcut);

                // overallCutIssued.val(allcut);

                PercentIssuedBal.val('(' + parseInt(Calculation) + '%)');

                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val(allcut);

                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBCutIssued" + "']").val(parseInt(OverAllCut) - parseInt(allcut));

                var BalanceStitched = parseInt(allcut) - parseInt(lbloverallStitched)

                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceStitched" + "']").val(parseInt(allcut) - parseInt(lbloverallStitched));
                
                var ctrl = SplitId[0];

                UpdateCutIssued(ctrl, allcut, CutPiecesPercent, ballanceCutPieces, CutIssuedday, BalanceStitched);

            }

        }

    }



    function GetOverAllStitched(elem) {

        var Ids = elem.id;

        var StitchedDay = elem.value;
        StitchedDay = StitchedDay.replace(/,/g, "")
        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");

        var Quantity = tr.find("input[name$=hdnQuantity]").val();



        var BalancePercentStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentStitched" + "']");

        var BalanceStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceStitched" + "']");

        var overallStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallStitched" + "']");

        var hdnoverallStitched = $("#<%= GridView1.ClientID %> input[id*='hdnoverallStitched']");

        var allcut = parseInt(hdnoverallStitched.val().replace(/,/g, "")) + parseInt(StitchedDay);

        overallStitched.val(allcut);

        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

        BalancePercentStitched.val('(' + parseInt(Calculation) + '%)');

        BalanceStitched.val(parseInt(Quantity) - parseInt(allcut));

    }



    function GetOverAllStitchedIssued(elem) {

        var Ids = elem.id;

        var StitchedIssuedDay = elem.value;
        StitchedIssuedDay = StitchedIssuedDay.replace(/,/g, "")
        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");

        var Quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBPercentStitchedIssued" + "']");

        var BalanceStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBStitchedIssued" + "']");

        var overallStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOallStitchedIssued" + "']");

        var hdnoverallStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='hdnoverallStitchedIssued']");

        var allcut = parseInt(hdnoverallStitchedIssued.val().replace(/,/g, "")) + parseInt(StitchedIssuedDay);

        overallStitchedIssued.val(allcut);
      
        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

        BalancePercentStitchedIssued.val('(' + parseInt(Calculation) + '%)');

        BalanceStitchedIssued.val(parseInt(Quantity) - parseInt(allcut));

    }



    function GetOverAllStitched(elem) {

        var Ids = elem.id;

        var EmbDay = elem.value;
        EmbDay = EmbDay.replace(/,/g, "")
        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");

        var Quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentEnb = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentEnb" + "']");

        var BalanceEmb = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceEmb" + "']");

        var overallEmb = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallEmb" + "']");


        var hdnoverallEmb = $("#<%= GridView1.ClientID %> input[id*='hdnoverallEmb']");
 
        var allcut = parseInt(hdnoverallEmb.val().replace(/,/g, "")) + parseInt(EmbDay);

        overallEmb.val(allcut);

        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

        BalancePercentEnb.val('(' + parseInt(Calculation) + '%)');

        BalanceEmb.val(parseInt(Quantity) - parseInt(allcut));

        var ctrl = SplitId[0];

        UpdatePCSStitchPackedEmbMO(ctrl);

    }



    function GetOverAllEmbIssued(elem) {

        var Ids = elem.id;

        var AllEmbIssuedDay = elem.value;
        AllEmbIssuedDay = AllEmbIssuedDay.replace(/,/g, "")

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");

        var Quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentEnbIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBPercentEnbIssued" + "']");

        var BalanceEmbIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBEmbIssued" + "']");

        var overallEmbIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllEmbIssued" + "']");

        var hdnoverallEmpIssued = $("#<%= GridView1.ClientID %> input[id*='hdnoverallEmpIssued']");

        var allcut = parseInt(hdnoverallEmpIssued.val().replace(/,/g, "")) + parseInt(AllEmbIssuedDay);

        overallEmbIssued.val(allcut);

        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

        BalancePercentEnbIssued.val('(' + parseInt(Calculation) + '%)');

        BalanceEmbIssued.val(parseInt(Quantity) - parseInt(allcut));

        var ctrl = SplitId[0];

        UpdatePCSStitchPackedEmbMO(ctrl);

    }



    function ShipmentPermission(flag) {
        if (flag == "False") {

            alert("You do not have permission");

            return false;
        }
    }

    function GetOverAllPacked(elem) {
        //debugger;

        var Ids = elem.id;

        var AllPacked = elem.value;
        AllPacked = AllPacked.replace(/,/g, "")

        if (AllPacked == '')

            AllPacked = '0';

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");      

        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

        var BalancePercentPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentPacked" + "']");

        var BalancePacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePacked" + "']");

        var lbloverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallPacked" + "']");

        var OverallEmbIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllEmbIssued" + "']").val();
        OverallEmbIssued = OverallEmbIssued.replace(/,/g, "");     

        var hdnoverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallPacked" + "']");

        var lblOallStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOallStitchedIssued" + "']").val();
        lblOallStitchedIssued = lblOallStitchedIssued.replace(/,/g, "")

        if (hdnoverallPacked.val() == "") {
            hdnoverallPacked = 0;
        }
        else {
            hdnoverallPacked = hdnoverallPacked.val();
        }

        hdnoverallPacked = hdnoverallPacked.replace(/,/g, "")

        var cutall = parseInt(hdnoverallPacked) + parseInt(AllPacked);

        if (parseInt(cutall) > parseInt(lblOallStitchedIssued)) {

            alert('Packing can not greater Emb/stich Issued');

            return false;

        }

        else {

            var c = confirm("Do You Want To process on Packing" + " " + AllPacked);

            if (c == true) {



                var allcut = parseInt(hdnoverallPacked) + parseInt(AllPacked);

                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallPacked" + "']").val(allcut);

                var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

                BalancePercentPacked.val('(' + parseInt(Calculation) + '%)');

                BalancePacked.val(parseInt(lblOallStitchedIssued) - parseInt(allcut));

                var Packingpercent = parseInt(Calculation);

                var PackingBalance = parseInt(OverallEmbIssued) - parseInt(allcut);

                var ctrl = SplitId[0];

                UpdateOnlyPacking(ctrl, Packingpercent, PackingBalance, AllPacked);

            }

        }

    }

    function GetEmbRoidery(elem) {
        // debugger;

        var Ids = elem.id;

        var AllPack = elem.value;
        var AllPacked = AllPack.replace(/,/g, "")

        if (AllPacked == '')

            AllPacked = '0';

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');



        var tr = $("#<%=GridView1.ClientID%> tr");

        // var Quantity = tr.find("input[name$=hdnQuantity]").val();

        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

        var BalancePercentPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentEnb" + "']");

        var BalancePacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceEmb" + "']");

        var lbloverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallEmb" + "']");

        var overallStitchIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOallStitchedIssued" + "']").val();
        overallStitchIssued = overallStitchIssued.replace(/,/g, "")

        var hdnoverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallEmb" + "']");

        if (hdnoverallPacked.val() == "") {
            hdnoverallPacked = 0;
        }
        else {
            hdnoverallPacked = hdnoverallPacked.val().replace(/,/g, "")
        }
        var allcut = parseInt(hdnoverallPacked) + parseInt(AllPacked);

        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallEmb" + "']").val(allcut);
        
        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

        var EmbPicesPercent = parseInt(Calculation);

        var EmbPicesBalance = parseInt(overallStitchIssued) - parseInt(allcut);
        
        BalancePercentPacked.val('(' + parseInt(Calculation) + '%)');

        BalancePacked.val(parseInt(overallStitchIssued) - parseInt(allcut));
        
        var ctrl = SplitId[0];

        UpdateOnlyEmbPcs(ctrl, EmbPicesPercent, EmbPicesBalance, AllPacked);
    }


    function GetIssueEmbRoidery(elem) {
        var Ids = elem.id;

        var AllPacked = elem.value;
        AllPacked = AllPacked.replace(/,/g, "")
        if (AllPacked == '')

            AllPacked = '0';

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');
        var tr = $("#<%=GridView1.ClientID%> tr");

        var Quantity = tr.find("input[name$=hdnQuantity]").val();

        var BalancePercentPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBPercentEnbIssued" + "']");

        var BalancePacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBEmbIssued" + "']");

        var lbloverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllEmbIssued" + "']");

        var overallEmb = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallEmb" + "']").val();
        overallEmb = overallEmb.replace(/,/g, "")

        var hdnoverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallEmpIssued" + "']");

        var allcut = parseInt(hdnoverallPacked.val().replace(/,/g, "")) + parseInt(AllPacked);

        $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllEmbIssued" + "']").val(allcut);

        var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);
        
        BalancePercentPacked.val('(' + parseInt(Calculation) + '%)');

        BalancePacked.val(parseInt(overallEmb) - parseInt(allcut));

        var EmbIssuedPercent = parseInt(Calculation);

        var EmbIssuedBalance = parseInt(overallEmb) - parseInt(allcut);

        var ctrl = SplitId[0];

        IssueEmbRoidery(ctrl, EmbIssuedPercent, EmbIssuedBalance, AllPacked);

    }

    function GetOnlyStich(elem) {
        //debugger;
        var Ids = elem.id;

        var AllStich = elem.value;
        AllStich = AllStich.replace(/,/g, "")
        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var tr = $("#<%=GridView1.ClientID%> tr");      

        var Quantity = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantity" + "']").val();

        var BalancePercentPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalancePercentStitched" + "']");

        var BalancePacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBalanceStitched" + "']");

        var lbloverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallStitched" + "']");

        var overallCutIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOAllCutIssued" + "']").val();
        overallCutIssued = overallCutIssued.replace(/,/g, "")      

        var hdnoverallPacked = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnoverallStitched" + "']");

        var lbloverallStitched = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lbloverallStitched" + "']").val();
        lbloverallStitched = lbloverallStitched.replace(/,/g, "")


        var lblOallStitchedIssued = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblOallStitchedIssued" + "']").val();
        lblOallStitchedIssued = lblOallStitchedIssued.replace(/,/g, "")
        var cutall = parseInt(hdnoverallPacked.val()) + parseInt(AllStich);

        if (parseInt(cutall) > parseInt(overallCutIssued)) {

            alert('Cut Issued Always greater then Stich')

            return false;
        }
        else {

            var c = confirm("Do You Want To process on Stich" + " " + AllStich);

            if (c == true) {

                var BalanceStitchedIssued = parseInt(cutall) - parseInt(lblOallStitchedIssued)

                $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblBStitchedIssued" + "']").val(parseInt(cutall) - parseInt(lblOallStitchedIssued));

                var allcut = parseInt(hdnoverallPacked.val().replace(/,/g, "")) + parseInt(AllStich);

                lbloverallPacked.val(allcut);

                var Calculation = parseInt(allcut) * 100 / parseInt(Quantity);

                var StitchPicesPercent = parseInt(Calculation);

                var StitchPicesBalance = parseInt(overallCutIssued) - parseInt(allcut);

                BalancePercentPacked.val('(' + parseInt(Calculation) + '%)');

                BalancePacked.val(parseInt(overallCutIssued) - parseInt(allcut));


                UpdatePCSStitch(elem, StitchPicesPercent, StitchPicesBalance, AllStich, allcut, BalanceStitchedIssued);

            }

        }

    }



    function QAStatus(OdId, Sid, flag) {

        if (flag == "True") {
            window.open("/Internal/OrderProcessing/QAStatus.aspx?orderdetailid=" + OdId + "&styleid=" + Sid);

            //window.open("/Internal/OrderProcessing/QAStatus.aspx?orderdetailid="+OdId+"&styleid="+ Sid+",FeedbackWindow","width=800,height=400,scrollbars=yes,resizable=yes,location=center,screen.height/ 1,screen.width/1,status=yes");

        }

        else {

            alert("You do not have permission");
            return false;
        }

    }
    //added by abhishek on 21/9/2016
    function Set_defualtFinalFabricOrderActualValue(elem, FabricType) {

        var Ids = elem.id;
        var FabricLength = elem.value;
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        if (FabricType == "1") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric1_k" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl1" + "']").val(valuess);

        }
        if (FabricType == "2") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric2_k" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl2" + "']").val(valuess);
        }
        if (FabricType == "3") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric3_k" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl3" + "']").val(valuess);
        }
        if (FabricType == "4") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric4_k" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl4" + "']").val(valuess);
        }
    }
    //added by abhishek on 7/11/2016
    function SetFinalFabricOrderActualValue(elem, FabricType) {
        var Ids = elem.id;
        var FabricLength = elem.value;
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        if (FabricType == "1") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl1" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl1" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "2") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl2" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl2" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "3") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl3" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl3" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "4") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl4" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl4" + "']").val(FabricOrderActualValue);
        }
    }

    function Set_defualtOrderInhouseActualValue(elem, FabricType) {
        //debugger;

        var Ids = elem.id;
        var FabricLength = elem.value;
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        var valuess = '';
        if (FabricType == "1") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab1incheckedvalk" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab1" + "']").val(valuess);

        }
        if (FabricType == "2") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab2incheckedvalk" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab2" + "']").val(valuess);
        }
        if (FabricType == "3") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedvalk" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab3" + "']").val(valuess);
        }
        if (FabricType == "4") {
            var valuess = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedvalk" + "']").val();
            valuess = valuess == '0k' ? '' : valuess;
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab4" + "']").val(valuess);
        }
    }
    function SetInHouseOrderActualValue(elem, FabricType) {
        //debugger;

        var Ids = elem.id;
        var FabricLength = elem.value;
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        if (FabricType == "1") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab1incheckedval" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab1" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "2") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab2incheckedval" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab2" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "3") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab3incheckedval" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab3" + "']").val(FabricOrderActualValue);
        }
        if (FabricType == "4") {
            var FabricOrderActualValue = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedval" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab4" + "']").val(FabricOrderActualValue);
        }
    }


    //accsessory-----------
    function Set_defualtFinalAccsessoryOrderActualValue(elem) {

        var Ids = elem.id;
        var val = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);
        //debugger; 

        var Kvalue = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnQuantityAvailk").val();
        Kvalue = Kvalue == '0k' ? '' : Kvalue;
        $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_txtQuantityAvail").val(Kvalue);

    }
    function SetFinalAccsessoryOrderActualValue(elem) {
        // debugger;
        var Ids = elem.id;
        var val = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);

        var Kvalue = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnQuantityAvailActual").val();
        $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_txtQuantityAvail").val(Kvalue);


    }


    function SetFinalAccsessoryOrderActualValue(elem) {
        // debugger;
        var Ids = elem.id;
        var val = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);

        var Kvalue = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnQuantityAvailActual").val();
        $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_txtQuantityAvail").val(Kvalue);


    }
    //end by 
    function ManageOrderFabricInHouseHistory_checked(elem, FabricType) {
        debugger;
        var Ids = elem.id;

        var InhouseQtys = elem.value;
        InhouseQtys = InhouseQtys.replace(/,(?=[^,]*$)/, '')
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        var datetime = $("#<%= hdnDate.ClientID%>").val();
        var FabricName = "";
        var lblPercent = "";
        var Total = "";

        var orderId = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderId" + "']").val();
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
        var FabricLength = "";

        var finalval = "";
        var TotalReqVal = 0;
        //debugger;
        if (FabricType == "1") {
            FabricName = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_fabric1name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent1" + "']");
            Total = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric1" + "']").val();
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab1incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric1" + "']").val();
            //           $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab1incheckedval" + "']").val(InhouseQtys);
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric_ToolTip" + "']").val();

        }

        if (FabricType == "2") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric2name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent2" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric2" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric2" + "']").val();
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab2incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl2" + "']").val(FabricLength);
            //           $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab2incheckedval" + "']").val(InhouseQtys);
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina2Fabric_ToolTip" + "']").val();

        }

        if (FabricType == "3") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric3name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent3" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric3" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric3" + "']").val();
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab3incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl3" + "']").val(FabricLength);
            //            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab3incheckedval" + "']").val(InhouseQtys);
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina3Fabric_ToolTip" + "']").val();
        }

        if (FabricType == "4") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric4name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent4" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric4" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric4" + "']").val();
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //$("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl4" + "']").val(FabricLength);
            //            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedval" + "']").val(InhouseQtys);
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina4Fabric_ToolTip" + "']").val();
        }

        var c = confirm("Do You Want To process on Fabric Checked inhouse" + " " + InhouseQtys);

        if (c == true) {
            if (finalval != "0") {
                //var percent = Math.round((parseInt(FabricLength) / (parseInt(finalval.replace(/,(?=[^,]*$)/, '')))) * 100);
                //                lblPercent.html("(" + percent + '%' + ")");
                $(".loadingimage").show();
                proxy.invoke("InsertManageOrderFabricInHouseHistory_inHouseChecked", { OrderId: orderId, OrderDetailID: orderDetailsID, FabricType: FabricType, FabricName: FabricName, date: datetime, PercentInHouse: 100, InhouseQnty: InhouseQtys }, function (result) {
                    $(".loadingimage").hide();

                    jQuery.facebox('Inhouse has been saved successfully!');

                }, onPageError, false, false);

            }

            else {
                alert("Fabric Total Must Be Greater Than Zero !");
                elem.value = elem.defaultValue;
                return false;
            }
        }
        else {
            elem.value = elem.defaultValue;
        }


    }

    function ManageOrderFabricInHouseHistory(elem, FabricType) {
        // debugger;
        var Ids = elem.id;
        var FabricLength = elem.value;
        FabricLength = FabricLength.replace(/,(?=[^,]*$)/, '')
        var CId = Ids.substr(38);
        var sID = Ids.split("_")[6].substr(3);
        var SplitId = CId.split('_');
        var datetime = $("#<%= hdnDate.ClientID%>").val();
        var FabricName = "";
        var lblPercent = "";
        var Total = "";
        var InhouseQtys = "";
        var orderId = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderId" + "']").val();
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();
        var FabricLength = "";
        var OrderAverage = 0;
        var StcAverage = 0;
        var percent = 0;
        var RequiredQty = 0;
        var quantity = 0;
        var finalval = "";
        var TotalReqVal = 0;
        var quantity = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblQuantity" + "']")[0].innerText;
        quantity = quantity.replace(/,(?=[^,]*$)/, '')
        if (FabricType == "1") {
            //            debugger;
            FabricName = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_fabric1name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent1" + "']");
            Total = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalOrderFabric1" + "']").val();
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl1" + "']").val().replace(/,(?=[^,]*$)/, '');
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric1" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl1" + "']").val(FabricLength);
            OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric1OrderAverage" + "']").val();
            StcAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric1stcAverage" + "']").val();

            //            InhouseQtys = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab1" + "']").val().replace(/,(?=[^,]*$)/, '');
            //            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab1incheckedval" + "']").val(InhouseQtys);
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina1Fabric_ToolTip" + "']").val();

            RequiredQty = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFinalOrderFabric1" + "']").val();
        }

        if (FabricType == "2") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric2name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent2" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric2" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric2" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl2" + "']").val(FabricLength);
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl2" + "']").val().replace(/,(?=[^,]*$)/, '');
            OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric2OrderAverage" + "']").val();
            StcAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric2stcAverage" + "']").val();
            //            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab2incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //            InhouseQtys = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab2" + "']").val();
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina2Fabric_ToolTip" + "']").val();
            RequiredQty = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFinalOrderFabric2" + "']").val();
        }

        if (FabricType == "3") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric3name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent3" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric3" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric3" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl3" + "']").val(FabricLength);
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl3" + "']").val().replace(/,(?=[^,]*$)/, '');
            OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric3OrderAverage" + "']").val();
            StcAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric3stcAverage" + "']").val();
            //            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab3incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //            InhouseQtys = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab3" + "']").val();

            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina3Fabric_ToolTip" + "']").val();
            RequiredQty = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFinalOrderFabric3" + "']").val();
        }

        if (FabricType == "4") {
            FabricName = $("#ctl00_cph_main_content_mb_GridView1 span[id*='ct" + SplitId[0] + "_fabric4name" + "']")[0].innerText;
            lblPercent = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblPercent4" + "']");
            Total = $("#<%= GridView1.ClientID %> span[id*='ct" + SplitId[0] + "_lblFinalOrderFabric4" + "']").html();
            finalval = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFinalFabric4" + "']").val();
            $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnQuantityAvl4" + "']").val(FabricLength);
            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblQuantityAvl4" + "']").val().replace(/,(?=[^,]*$)/, '');
            OrderAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric4OrderAverage" + "']").val();
            StcAverage = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFabric4stcAverage" + "']").val();
            //            FabricLength = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFab4incheckedval" + "']").val().replace(/,(?=[^,]*$)/, '');
            //            InhouseQtys = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_txtinhouseqntyfab4" + "']").val();
            TotalReqVal = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnFina4Fabric_ToolTip" + "']").val();
            RequiredQty = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_lblFinalOrderFabric4" + "']").val();
        }


        if (finalval != '0')
            OpenFabricInHouseEntryPopUp(orderDetailsID, FabricType, TotalReqVal);
    }
    function OpenFabricInHouseEntryPopUp(orderDetailID, FabricType, TotalReqVal) {

        var sURL = '../../Internal/Fabric/frmFabricInHouseEntry.aspx?orderDetailID=' + orderDetailID + '&FabricType=' + FabricType + '&RequiredQty=' + TotalReqVal
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 800, width: 1000, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    }
    //abhishek 31/7/2015
    function showOrderForm(OrderID) {

        var url = '/Internal/Sales/Order.aspx?orderid=' + OrderID;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,height=1600,width=1800,scrollbars=yes,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END
    //abhishek 31/7/2015
    function showFabricWorkingSheet(OrderID) {
        var url = '/Internal/Fabric/FabricWorkingSheet.aspx?orderid=' + OrderID;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,height=1600,width=1800,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END
    //abhishek 31/7/2015
    function showAccessoriesWorkSheet(OrderID) {
        var url = '/Internal/Fabric/FabricAccessoriesWorkSheet.aspx?orderid=' + OrderID;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,height=1600,width=1800,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END
    //abhishek 31/7/2015
    function showCuttingSheet(OrderID) {
        var url = '/Internal/Fabric/CuttingSheet.aspx?orderid=' + OrderID;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,height=1600,width=1800,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END
    //END
    //'<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>','Yes'
    //abhishek 31/7/2015
    function showQualityControl(orderDetailID, StyleID, stylenumber, FitsStyle, ClientID, DeptId, showHOPPMFORM) {
        var url = '/Internal/Merchandising/QualityControl.aspx?orderDetailID=' + orderDetailID + '&StyleID=' + StyleID + '&stylenumber=' + stylenumber + '&FitsStyle' + FitsStyle + '&ClientID=' + ClientID + '&DeptId=' + DeptId + '&showHOPPMFORM=' + showHOPPMFORM;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,height=1600,width=1800,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END

    function showOBSheet(StyleID, stylenumber, FitsStyle, ClientID, DeptId, OrderID, ShowOBForm) {
        var url = '/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=' + StyleID + '&stylenumber=' + stylenumber + '&FitsStyle=' + stylenumber + '&ClientID=' + ClientID + '&DeptId=' + DeptId + '&OrderID=' + OrderID + '&ShowOBForm=' + ShowOBForm;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,,height=1600,width=1800,scrollbars=yes,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //abhishek 31/7/2015
    function showRiskForm(StyleID, stylenumber, FitsStyle, ClientID, DeptId, showRiskFORM) {
        // alert('tert')
        var url = '/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=' + StyleID + '&stylenumber=' + stylenumber + '&FitsStyle=' + FitsStyle + '&ClientID=' + ClientID + '&DeptId=' + DeptId + '&showRiskFORM=' + showRiskFORM;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,height=1600,width=1800,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //end
    //abhishek 31/7/2015
    function showHoppmForm(StyleID, stylenumber, FitsStyle, ClientID, DeptId, showHOPPMFORM) {
        var url = '/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=' + StyleID + '&stylenumber=' + stylenumber + '&FitsStyle=' + FitsStyle + '&ClientID=' + ClientID + '&DeptId=' + DeptId + '&showHOPPMFORM=' + showHOPPMFORM;
        window.open(url, '_blank', 'status=yes,toolbar=no,menubar=no,location=yes,scrollbars=Yes,height=1600,width=1800,resizable=Yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }
    //END

    var htmlstylecode;
    function showLinksPopup_ManageOrder(OrderID, ClientID, prmThis, OrderDetailID, styleid, stylenumber, FitsStyle, StyleCode, DeptId, File, File2, File3) {

        $("span#first-tab").each(function () {

            if (File != '') {
                //  var filePath1 = "http://www.boutique.in/Uploads/Order/" + File;
                $(this).children("#ctl00_cph_main_content_mb_POView1").show();
                filePath1 = "http://www.boutique.in/Uploads/Order/" + File;
                $(this).children("#ctl00_cph_main_content_mb_POView1").attr("href", filePath1);

                // $("#ctl00_cph_main_content_mb_POView1").attr("href", filePath1);
                $("#ctl00_cph_main_content_mb_POView1").attr("target", "_blank");
            }
            else {
                $(this).children("#ctl00_cph_main_content_mb_POView1").hide();
            }

        });
        $("span#second-tab").each(function () {
            if (File2 != '') {
                $(this).children("#ctl00_cph_main_content_mb_POView2").show();
                //  var filePath2 = "http://www.boutique.in/Uploads/Order/" + File2;
                filePath2 = "http://www.boutique.in/Uploads/Order/" + File2;

                $(this).children("#ctl00_cph_main_content_mb_POView2").attr("href", filePath2);
                $("#ctl00_cph_main_content_mb_POView2").attr("target", "_blank");
            }
            else {
                $(this).children("#ctl00_cph_main_content_mb_POView2").hide();
            }
        });
        $("span#Third-tab").each(function () {
            if (File3 != '') {
                $(this).children("#ctl00_cph_main_content_mb_POView3").show();
                //  var filePath2 = "http://www.boutique.in/Uploads/Order/" + File2;
                filePath3 = "http://www.boutique.in/Uploads/Order/" + File3;

                $(this).children("#ctl00_cph_main_content_mb_POView3").attr("href", filePath3);
                $("#ctl00_cph_main_content_mb_POView3").attr("target", "_blank");
            }
            else {
                $(this).children("#ctl00_cph_main_content_mb_POView3").hide();
            }
        });
     
        $("a.hyp", "#main_content").each(function () {
            var link = $(this).attr("href");
            if (link.indexOf('?') > -1) {
                link = link.replace(link.substring(link.indexOf('?'), link.length), '')
            }
            if (link == "/Internal/Merchandising/QualityControl.aspx") {
                var str = "?orderDetailID=" + OrderDetailID;
            }
            else if (link == "/Internal/Production/InlinePPMEdit.aspx") {
                var str = "?styleid=" + styleid + "&stylenumber=" + stylenumber;
            }
            //abhishek on 31/7/2015
            //            else if (link == "/Internal/OrderProcessing/OrderProcessFlow.aspx") {
            //                var str = "?styleid=" + styleid + "&stylenumber=" + stylenumber + "&FitsStyle=" + FitsStyle + "&StyleCode=" + StyleCode + "&ClientID=" + ClientID + "&DeptId=" + DeptId;
            //            }
            // Change by Ravi kumar for orderid in risk analysis
            else if (link == "/Internal/OrderProcessing/OrderProcessFlow.aspx") {
                var str = "?styleid=" + styleid + "&stylenumber=" + stylenumber + "&FitsStyle=" + FitsStyle + "&StyleCode=" + StyleCode + "&ClientID=" + ClientID + "&DeptId=" + DeptId + "&OrderId=" + OrderID + "&showRiskFORM=" + "Yes";
            }
            else if (link == "/Internal/OrderProcessing/PoFileUploads.aspx" || link == "../../Internal/OrderProcessing/PoFileUploads.aspx") {
                var str = "?OrderId=" + OrderID;
            }
            //abhishek

            else if (link == "../../Admin/StyleCodeDetails.aspx" || link == "Admin/StyleCodeDetails.aspx") {
                //debugger;
                var str = "?styleid=" + styleid + "&stylenumber=" + stylenumber + "&FitsStyle=" + FitsStyle + "&StyleCode=" + StyleCode + "&ClientID=" + ClientID + "&DeptId=" + DeptId + "&OrderId=" + OrderID + "&showRiskFORM=" + "Yes";
                $.get('../../Admin/StyleCodeDetails.aspx?StyleCode=' + StyleCode, function (html) {
                    // $.facebox(html);
                    htmlstylecode = html;
                });

            }

            //end
            else if (link == "/Internal/OrderProcessing/ProcessOB.aspx") {

                var str = "?styleid=" + styleid + "&stylenumber=" + stylenumber + "&ClientID=" + ClientID + "&DeptId=" + DeptId;
            }
            else {
                var str = "?orderid=" + OrderID;
            }
            $(this).attr("href", link + str)

        });

        var result = document.getElementById("links").innerHTML.replace("#CLIENTID#", ClientID);
        //jQuery.facebox(result);


        openQuickLayer(result, prmThis);

        //        if (link == "../../Admin/StyleCodeDetails.aspx" || link == "Admin/StyleCodeDetails.aspx") {
        //            $.get('../../Admin/StyleCodeDetails.aspx?StyleCode=' + StyleCode, function (html) {
        //                $.facebox(html);
        //            });
        //        }



        $(".uploadsubmit").click(function () {
            //                alert($('#<%= hdnUploadPOid.ClientID %>').val());
            $('#<%= hdnUploadPOid.ClientID %>').val(OrderDetailID);
            //                alert($('#<%= hdnUploadPOid.ClientID %>').val());

            $(".btnback").click();

        });


    }



    function UpdateLineNo(elem, flag) {



        var Ids = elem.id;

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var Changevalue = elem.value;

        Changevalue = $.trim(Changevalue);

        var Flag = "LineNo";

        var OrderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();

        if (Changevalue != "") {

            proxy.invoke("UpdateLineNo", { OrderDetailID: OrderDetailID, Changevalue: Changevalue, Flag: Flag }, function (result) {

                jQuery.facebox(result);

                jQuery.facebox('Data has been Update successfully!');

            }, onPageError, false, false);

        }

    }

    function UpdateContractNo(elem, flag) {
        var Ids = elem.id;

        var CId = Ids.substr(38);

        var SplitId = CId.split('_');

        var Changevalue = elem.value;

        Changevalue = $.trim(Changevalue);

        var Flag = "ContractNumber";

        var OrderDetailID = $("#<%= GridView1.ClientID %> input[id*='ct" + SplitId[0] + "_hdnOrderDetailsID" + "']").val();

        if (Changevalue != "") {

            proxy.invoke("UpdateLineNo", { OrderDetailID: OrderDetailID, Changevalue: Changevalue, Flag: Flag }, function (result) {

                jQuery.facebox(result);

                jQuery.facebox('Data has been Update successfully!');

            }, onPageError, false, false);

        }

    }


    function numbersonly(elem) {
        //debugger;

        var value = elem.value;
        if (value != "") {
            if (value == undefined) {
                var regs = /^\d*[0-9](\d*[0-9])?$/;
                if (value != "") {
                    if (regs.exec(elem)) {
                        return true;
                    }
                    else {
                        //
                        alert('Enter Only Numeric Value')
                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
            else {
                //var regs = /^\d*[0-9](\.\d*[0-9])?$/;
                var regs = /^(-)?\d+(\d\d)?$/;
                if (value != "") {
                    if (regs.exec(value)) {
                        return true;
                    }
                    else {
                        alert('Enter Only Numeric Value')
                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
        }
        else {
            return true;

        }

    }


    function UpdateDescription(elem, flag) {



        var Ids = elem.id;

        var Changevalue = elem.value;

        Changevalue = $.trim(Changevalue);

        var CId = Ids.split("_")[6].substr(3);

        var Flag = "Description";

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        if (Changevalue != "") {

            proxy.invoke("UpdateDescription", { styleid: styleid, Changevalue: Changevalue, Flag: Flag }, function (result) {

                jQuery.facebox(result);

                jQuery.facebox('Data has been Update successfully!');

            }, onPageError, false, false);

        }

    }



    function showEtaPopup_stitch(Flag1, Flag2, StyleId, Val1, Val2, SDate, EDate, SerialNumber, days, Inhousepercent, OrderDetailId, IsWrite, ColumnId) {

        //debugger;
        //Added By Ashish on 12/1/2014

        if (IsWrite != 'False') {
            if (SDate != "" && EDate != "" && Inhousepercent >= 100) {
                alert("NO ENTRY REQUIRED AS ETA ALREADY FILLED")
                return false;
            }
            else {

                var url = 'MOEtaPopup.aspx?Flag1=' + Flag1 + '&Flag2=' + Flag2 + '&StyleId=' + StyleId + '&Val1=' + Val1 + '&Val2=' + Val2 + '&SDate=' + SDate + '&EDate=' + EDate + '&SerialNumber=' + SerialNumber + '&OrderDetailId=' + OrderDetailId + '&ColumnId=' + ColumnId + '&Days=' + days;
                window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');

            }
        }
        else {
            alert('You have not write permission')
        }
        //END
    }



    //added for permission by sushil on date 30/3/2015

    //updated by abhishek on 18/12/2015
    function showEtaPopupFABRIC(elm, Flag1, Flag2, StyleId, Val1, Val2, SDate, EDate, SerialNumber, Inhousepercent, OrderDetailId, IsWrite, ColumnId) {

        if (IsWrite != 'False') {            
            var url = 'MOEtaPopup.aspx?Flag1=' + Flag1 + '&Flag2=' + Flag2 + '&StyleId=' + StyleId + '&Val1=' + Val1 + '&Val2=' + Val2 + '&SDate=' + SDate + '&EDate=' + EDate + '&SerialNumber=' + SerialNumber + '&OrderDetailId=' + OrderDetailId + '&ColumnId=' + ColumnId + '&Inhousepercent=' + Inhousepercent;
            window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        }
        else {
            alert('You have not write permission')
        }
    }

    //end by abhishek on 18/12/2015


//    function showEtaPopup(Flag1, Flag2, StyleId, Val1, Val2, SDate, EDate, SerialNumber, Inhousepercent, OrderDetailId, IsWrite, ColumnId) {

//        if (IsWrite != 'False') {
//            if (SDate != "" && EDate != "" && Inhousepercent >= 100) {
//                alert("NO ENTRY REQUIRED AS ETA ALREADY FILLED")
//                return false;
//            }
//            else {
//                var url = 'MOEtaPopup.aspx?Flag1=' + Flag1 + '&Flag2=' + Flag2 + '&StyleId=' + StyleId + '&Val1=' + Val1 + '&Val2=' + Val2 + '&SDate=' + SDate + '&EDate=' + EDate + '&SerialNumber=' + SerialNumber + '&OrderDetailId=' + OrderDetailId + '&ColumnId=' + ColumnId;
//                window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
//            }
//        }
//        else {
//            alert('You have not write permission')
//        }
//    }

    // edit by surendra on 2-jne-2015
    function UpdateLineCount(elem, StyleIdforLine, OrderDetaildidforline, NewRemarks) {

        if (numbersonly(elem) == true) {
            var lValue = elem.value;
            var Remarks = NewRemarks.replace('@@', lValue)

            $(".loadingimage").show();
            proxy.invoke("UpdatePlanningLine", { OrderDetaildidforline: OrderDetaildidforline, lValue: lValue, StyleIdforLine: StyleIdforLine, Remarks: Remarks }, function (result) {
                $(".loadingimage").hide();
                jQuery.facebox('Line input has been saved successfully!');
            }, onPageError, false, false);
        }
    }
    // end

    function showEtaPopupAcceess(Flag1, elem, ColumnId) {
        //debugger;
        var Ids = elem.id;
        var val = elem.value;
        var cId = Ids.split("_")[6].substr(3);
        var cIds = Ids.split("_")[8].substr(3);
        // debugger;
        var OrderDetailId = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailsID" + "']").val();
        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "_hdnStyleID" + "']").val();
        // add by sushil on date 20/3/2015
        // var Val1 = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccessories").val();
        var acessVal1 = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccessories").val();
        var altVal1 = acessVal1.replace('&', 'and');
        var Val2 = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "_hdnSerialNumber" + "']").val();
        var SDate = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccesETA").val();
        //Added By Ashish on 12/1/2014
        //debugger;
        var Inhouse = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_lblParcentInHouse").html()

        var SerialNumber = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "_hdnStyleNo" + "']").val();
        var accworkingID = $("#<%= GridView1.ClientID %>_ctl" + cId + "_repAccess_ctl" + cIds + "_hdnAccWorkingDetailsID").val();
        var InhousePercent = Inhouse.split('%')
        var EDate = "";

        // debugger;
        //added by abhishek on 18/12/2015
        var remark = "";    
        var Val1 = acessVal1.replace(/&/g, 'and').replace(/#/g, 'hx');
        var AccesoryInhouse = Inhouse.split('%')[0] == '' ? 0 : Inhouse.split('%')[0];
        //end by abhishek on 10/2/2016

        var url = 'MOEtaPopup.aspx?Flag1=' + Flag1 + '&Flag2=' + "" + '&StyleId=' + styleid + '&AccID=' + accworkingID + '&Val1=' + Val1 + '&Val2=' + Val2 + '&SDate=' + SDate + '&EDate=' + EDate + '&SerialNumber=' + SerialNumber + '&OrderDetailId=' + OrderDetailId + '&ColumnId=' + ColumnId + '&AccesoryInhouse=' + AccesoryInhouse;
        window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        //end by abhishek on 118/12/2015
        //END
    }

    $("#upload").change(function () {
        alert('changed!');
    });

    function filechange(elem) {
        alert('changed!');

        var Ids = elem.id;

        var Fname = elem.value;

        var data = new FormData();

        data.append("UploadedImage", Fname);

        // var fname = elem.get(0).files

        var CId = Ids.split("_")[6].substr(3);

        var styleid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnStyleID" + "']").val();

        var orderid = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();
       
        $.ajax({
            url: '../Handler1.ashx',

            type: "POST",

            data: { firstName: 'stack', lastName: 'overflow' },

            success: function (response) {
                alert(response.d);
            },

            error: function (data, status, e) {

                alert(e);
            }
        });

    }
    function ajaxFileUpload(elem) {
        $.elem

   (

       {

           url: 'Handler1.ashx',

           secureuri: false,

           fileElementId: 'fileToUpload',

           dataType: 'json',

           data: { name: 'logan', id: 'id' },

           success: function (data, status) {

               if (typeof (data.error) != 'undefined') {

                   if (data.error != '') {

                       alert(data.error);

                   } else {

                       alert(data.msg);

                   }

               }

           },

           error: function (data, status, e) {

               alert(e);

           }

       }

   )

        return false;
    } 

</script>
<script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript">
   
    function OpenFinishigslotEntry(totalEntrysum,id) {
        //debugger;
        var fabid = id
        var Ids = elamget.id;
        var cId = Ids.split("_")[6].substr(2);
        Ids.split("_")[7].substr(0)

        if (fabid == 1) {
            //$("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "lblFabric1STCAverage" + "']").val(parseInt(totalEntrysum));
            $("#<%= GridView1.ClientID %> input[id*='_ct" + cId + "_lblFabric1STCAverage" + "']").val((totalEntrysum));
        }

        if (fabid == 2) {
            //$("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "lblFabric1STCAverage" + "']").val(parseInt(totalEntrysum));
            $("#<%= GridView1.ClientID %> input[id*='_ct" + cId + "_lblFabric2STCAverage" + "']").val((totalEntrysum));
        }

        if (fabid == 3) {
            //$("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "lblFabric1STCAverage" + "']").val(parseInt(totalEntrysum));
            $("#<%= GridView1.ClientID %> input[id*='_ct" + cId + "_lblFabric3STCAverage" + "']").val((totalEntrysum));
        }
        if (fabid == 4) {
            //$("#<%= GridView1.ClientID %> input[id*='ctl" + cId + "lblFabric1STCAverage" + "']").val(parseInt(totalEntrysum));
            $("#<%= GridView1.ClientID %> input[id*='_ct" + cId + "_lblFabric4STCAverage" + "']").val((totalEntrysum));
        }
      
     }   
        
      

         <%--added by abhishek 25/12/2015--%>
  function UploadTestReport(OrderId,OrderDetailsId,TestReports) {
       
       var url = 'MoTestReportUpload.aspx?OrderId=' + OrderId + '&OrderDetailsId=' + OrderDetailsId + '&TestReports=' + TestReports;
                window.open(url, '_blank', 'height=300,width=600,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=500%,screeny=300%, addressbar=no, directories=no, titlebar=no');
      
     }   

        <%--added by Prabhaker 09/02/2018--%> 

   function UploadQcDocs(obj) {
  // debugger;
      var sURL =  obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 1200, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      return false;
    }
       
       function cutissue(OrderID,OrderDetailID,UnitID) {
   //debugger;
    
     var sURL = '../../Internal/Production/frmCutIssueOutHouse.aspx?OrderID='+OrderID+'&OrderDetailID='+OrderDetailID+'&UnitID='+UnitID;
     // alert(sURL);
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 550, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      return false;
    } 

     function Stitch_Finish_QtyUpdate(OrderID, OrderDetailID, UnitID, type) { 
     //debugger;
     var sURL = '../../Internal/Production/StitchQtyEntryPopUp.aspx?OrderID='+OrderID+'&OrderDetailID='+OrderDetailID+'&UnitID='+UnitID + '&type=' + type +'';
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 200, width: 650, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      return false;
    } 
    

     function OpenTestReport(obj) {
      var sURL =  obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      return false;
    }

 function OpenPOfileUpload(obj) {
 
     $("#quickviewLayer").hide();
      var sURL =  obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 460, width: 950, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
     
      return false;
    }

 <%--end by abhishek on 25/12/2015--%>

  <%--added by abhishek 19/1/2016--%>
  
  function UpdatePhotoShot(elem,OrderDetailsID) {
        //debugger;
        var IscheckedShot;
        OrderDetailsID_= OrderDetailsID;           
        var Ids = elem.id;
        var PhotoShotDate = elem.value;
        var CId = Ids.split("_")[6].substr(3);
        ControlName=Ids.split("_")[7];        
        var IsChecked = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_chkPhotoshot" + "']").is(":checked");
        var txtdateShot = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_TxtPhotoshot" + "']").val();
        var orderId = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderId" + "']").val();
        var OrderDetailsID_new = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderdetailsids" + "']").val();
        if(IsChecked)
        {  IscheckedShot=1;}
        else
        { IscheckedShot=0;}
        if(ControlName=='chkPhotoshot')
        {          
               if(IscheckedShot==0)
               {
                   txtdateShot='';
                   proxy.invoke("UpdatePhotoShot", { Photoshotdate: txtdateShot, IsPicShot: IscheckedShot, orderId: orderId, orderDetails_ID: OrderDetailsID_new }, function (result) {
                   if(result)
                   {
                   //debugger;
                   alert('update successfully!');
                   }
       
                   }, onPageError, false, false);
                   $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_TxtPhotoshot" + "']").val('');
               }
               else if(IscheckedShot==1)
               {
                     if(txtdateShot!='')
                     {
                       proxy.invoke("UpdatePhotoShot", { Photoshotdate: txtdateShot, IsPicShot: IscheckedShot, orderId: orderId, orderDetails_ID: OrderDetailsID_new }, function (result) {
                       if(result)
                       {
                       //debugger; 
                       alert('update successfully!');   }
       
                       }, onPageError, false, false);
                     }
                     else
                     {
                        alert('Please select Photo shot date first!');
                        return;
                     }
               }                       
           
       }
       else if(ControlName=='TxtPhotoshot')
        {
            if(IscheckedShot==0)
            {              
               alert('Please select checkbox first of photo shot date!.');
               return;            
           }
           else
           {
           proxy.invoke("UpdatePhotoShot", { Photoshotdate: txtdateShot, IsPicShot: IscheckedShot, orderId: orderId, orderDetails_ID: OrderDetailsID_new }, function (result) {
               if(result)
               {
               alert('update successfully!');
               }
       
                }, onPageError, false, false);
               }          
       }
       
     }
   

</script>
<!------------------------Add-by Prabhaker--------------------------->
<script type="text/javascript">

    function UpdateTableHeaders() {
        $(".persist-area").each(function () {
            var el = $(this),
               offset = el.offset(),
               scrollTop = $(window).scrollTop(),
               floatingHeader = $(".floatingHeader", this)
            if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                floatingHeader.css({
                    "visibility": "visible"

                });
            } else {
                floatingHeader.css({
                    "visibility": "hidden"
                });
            };
        });
    }

    // DOM Ready

    $(function () {
        var clonedHeaderRow;
        $(".persist-area").each(function () {
            clonedHeaderRow = $(".persist-header", this);
            clonedHeaderRow
             .before(clonedHeaderRow.clone())
             .css("width", clonedHeaderRow.width())
             .addClass("floatingHeader");
        });
        $(window)
        .scroll(UpdateTableHeaders)
        .trigger("scroll");
    });

    function UpdateProductionDetail(elem, Type) {
        //debugger;
        var Value = elem.value;
        if (Value != '') {
            var Ids = elem.id;
            var cId1 = Ids.split("_")[6].substr(3);
            var cId2 = Ids.split("_")[8].substr(3);

            var OrderDetailId = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnProOrderDetailId").val();
            var UnitId = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnUnitId").val();

            var CutTotal = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnCutTotal").val();
            var CutReadyTotal = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnCutReadyTotal").val();
            var StitchTotal = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnStitchTotal").val();
            var FinishTotal = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnFinishTotal").val();
            var StitchQty_OutHouse = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnStitchQty_OutHouse").val();
            var FinishQty_OutHouse = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnFinishQty_OutHouse").val();
            var Finishing_InHouse = $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_hdnFinishing_InHouse").val();

            var hdnCutReadyTotal = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId1 + "_hdnCutReadyTotalAll" + "']").val();
            if (hdnCutReadyTotal == '')
                hdnCutReadyTotal = 0;

            var hdnStitchTotal = $("#<%= GridView1.ClientID %> input[id*='ctl" + cId1 + "_hdnStitchTotalAll" + "']").val();
            if (hdnStitchTotal == '')
                hdnStitchTotal = 0;

            if (Type == 'CutReady') {
                CutReadyTotal = parseInt(Value) + parseInt(CutReadyTotal);
                if (parseInt(CutReadyTotal) > parseInt(CutTotal)) {
                    alert('Cut Rdy can not be greater than Cut Qty');
                    $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_txtCutReadyToday").val('');
                    return false;
                }
            }

            if (Type == 'Stitching') {
                StitchTotal = parseInt(Value) + parseInt(StitchTotal);
                if (parseInt(StitchTotal) > parseInt(hdnCutReadyTotal)) {
                    alert('Stitch qty can not be greater than Cut Rdy');
                    $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_txtStitchToday").val('');
                    return false;
                }
            }

            if (Type == 'Finishing') {
                if (parseInt(StitchQty_OutHouse) > 0) {
                    if (Finishing_InHouse == 1) {
                        FinishQty_OutHouse = parseInt(Value) + parseInt(FinishQty_OutHouse);
                        if (parseInt(FinishQty_OutHouse) > parseInt(StitchQty_OutHouse)) {
                            alert('Finish qty can not be greater than Stitch out house Qty');
                            $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_txtFinishToday").val('');
                            return false;
                        }
                    }
                    else {
                        FinishTotal = parseInt(Value) + parseInt(FinishTotal);
                        if (parseInt(FinishTotal) > parseInt(hdnStitchTotal)) {
                            alert('Finish qty can not be greater than Stitch Qty');
                            $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_txtFinishToday").val('');
                            return false;
                        }
                    }
                }
                else {
                    FinishTotal = parseInt(Value) + parseInt(FinishTotal);
                    if (parseInt(FinishTotal) > parseInt(hdnStitchTotal)) {
                        alert('Finish qty can not be greater than Stitch Qty');
                        $("#<%= GridView1.ClientID %>_ctl" + cId1 + "_repProduction_ctl" + cId2 + "_txtFinishToday").val('');
                        return false;
                    }
                }
            }

            proxy.invoke("Update_cutting_Stitching_Finishing_ByOrderDetailId", { OrderDetailId: OrderDetailId, Type: Type, UnitId: UnitId, Value: Value }, function (result) {

                if (result > 0) {
                    //debugger;
                    alert('successful');
                }
                else {
                    //debugger;
                    alert('Unsuccess');
                }

            }, onPageError, false, false);
        }

    }


    function ShowSizeHistory(OrderId, OrderDetailId, Type, StyleNumber, IsShipped, UnitID, IsOldShipped) {
        //debugger;
        if (Type == 'Stitching') {
            if (IsShipped == 1) {
                if (IsOldShipped == 1) {
                    var url = '../../Admin/PackingList.aspx?OrderDetailId=' + OrderDetailId + '&UnitId=' + UnitID;
                    Shadowbox.init({ animate: true, animateFade: true, modal: true });
                    Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                }
                else {
                    var url = '../Production/frmSizeSet_History.aspx?orderid=' + OrderId + '&OrderDetailId=' + OrderDetailId + '&Type=' + Type + '&StyleNumber=' + StyleNumber + '&UnitId=' + UnitID;
                    Shadowbox.init({ animate: true, animateFade: true, modal: true });
                    Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                }
            }
            else {
                proxy.invoke("CheckSizeSet_ByOrderDetailId", { OrderDetailId: OrderDetailId }, function (result) {
                    var iExist = result;
                    if (iExist == 1) {
                        //debugger;
                        var url = '../Production/frmSizeSet_History.aspx?orderid=' + OrderId + '&OrderDetailId=' + OrderDetailId + '&Type=' + Type + '&StyleNumber=' + StyleNumber + '&UnitId=' + UnitID;
                        Shadowbox.init({ animate: true, animateFade: true, modal: true });
                        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                    }
                    else {
                        //debugger;
                        var url = '../Production/MoStitchingHistory.aspx?OrderDetailId=' + OrderDetailId + '&Type=' + 2;
                        Shadowbox.init({ animate: true, animateFade: true, modal: true });
                        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                    }

                }, onPageError, false, false);

            }
        }
        else {
            if (Type == 'ValueAdded') {
                var url = '../../Admin/ValueAdditionHistory.aspx?OrderDetailId=' + OrderDetailId + '&UnitId=' + UnitID;
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 650, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            }
            if (Type != 'ValueAdded') {
                if (IsShipped == 1) {
                    if (IsOldShipped == 1) {
                        var url = '../../Admin/PackingList.aspx?OrderDetailId=' + OrderDetailId + '&UnitId=' + UnitID;
                        Shadowbox.init({ animate: true, animateFade: true, modal: true });
                        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                    }
                    else {
                        var url = '../Production/frmSizeSet_History.aspx?orderid=' + OrderId + '&OrderDetailId=' + OrderDetailId + '&Type=' + Type + '&StyleNumber=' + StyleNumber + '&UnitId=' + UnitID;
                        Shadowbox.init({ animate: true, animateFade: true, modal: true });
                        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                    }
                }
                else {
                    var url = '../Production/frmSizeSet_History.aspx?orderid=' + OrderId + '&OrderDetailId=' + OrderDetailId + '&Type=' + Type + '&StyleNumber=' + StyleNumber + '&UnitId=' + UnitID;
                    Shadowbox.init({ animate: true, animateFade: true, modal: true });
                    Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                }
            }

        }
        return false;
    }

    function ShowSizeSetEntry(OrderDetailId, Type, StyleNumber, UnitID) {
        //debugger;
        if (Type == 'ValueAdded') {
            var url = '../../Admin/ValueAddition.aspx?OrderDetailId=' + OrderDetailId + '&UnitId=' + UnitID;
            //window.open(url,'Gaj');
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 380, width: 650, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        }
        else {
            var url = '../Production/frmSizeSetEntry_ByMO.aspx?OrderDetailId=' + OrderDetailId + '&Type=' + Type + '&StyleNumber=' + StyleNumber + '&UnitId=' + UnitID;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            //window.open(url,'gaj');            
        }
        return false;
    }
    //Gajendra 12-04-2016
    function ShowFabricApproval(ClientID, OrderID, OrderDetailIds, FabricName, FabricDetails, Type) {
        var url = '../Fabric/FabricApproval_PopUp.aspx?ClientID=' + ClientID + '&OrderID=' + OrderID + '&OrderDetailID=' + OrderDetailIds + '&FabricName=' + FabricName + '&FabricDetails=' + FabricDetails + '&Type=' + Type;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 490, width: 500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    }

    //Gajendra 09-05-2016
    function SHOW_PRODUCTION_DETAIL(OrderDetailId, SerialNumber, StyleNumber, Quantity) {
        var url = '../Production/ProductionDetails.aspx?OrderDetailId=' + OrderDetailId + '&SerialNumber=' + SerialNumber + '&StyleNumber=' + StyleNumber + '&Quantity=' + Quantity;
        //Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 800, width: 1400, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    }

    //      //Ravi 14-07-2016
    function SHOW_PRODUCTION_MATRIX(OrderDetailId, StyleCode, IsWrite) {
        if (IsWrite != 'False') {
            var url = '../Production/ProductionPlanningMatrix.aspx?OrderDetailId=' + OrderDetailId + '&StyleCode=' + StyleCode;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 500, width: 1257, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        }
        else {
            alert('You have not write permission')
        }
    }

    function SBClose() { }

    function ShowSamplingFitsHistory(StyleId,PPStatus,OrderDetailID) {
        //debugger;       
        if (StyleId != -1) {
            proxy.invoke("GetSamplingHistory", { StyleId: StyleId, MoOpen: 1, Mode: 2, PPStatus: PPStatus, OrderDetailID: OrderDetailID },
            function (result) {
                jQuery.facebox(result);

            }, null, false, false);
        }
        return false;
    }
          
</script>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
<script type="text/javascript">


    function FileUpload(OrderDetailsId) {



        var url = '../../Admin/ProductionAdmin/PeekCapMultipleFileUpload.aspx?OrderDetailsId=' + OrderDetailsId;


        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 300, width: 550, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //return false;
    }
    function ShowPackingList(Flag, OrderID, OrderDetailID) {
        //debugger;
        var url = '../../Internal/Delivery/frmMainDeliveryScreen.aspx?Flag=' + Flag + '&OrderID=' + OrderID + '&OrderDetailID=' + OrderDetailID;
        //        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 700, width: 1100, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //        async: true;
        var win = window.open(url, '_blank');
        win.focus();
    }
    function ShowInvoiceListNew(Flag, OrderID, OrderDetailID, ShipmentNo) {
        //debugger;

        var urlinovice = '../../Internal/Delivery/frmMainDeliveryScreen.aspx?Flag=' + Flag + '&OrderID=' + OrderID + '&OrderDetailID=' + OrderDetailID + '&ShipmentNoQuery=' + ShipmentNo;

        //        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //        Shadowbox.open({ content: urlinovice, type: "iframe", player: "iframe", title: "", height: 700, width: 1100, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //        async: true;
        var win = window.open(urlinovice, '_blank');
        win.focus();
    }
    function ShowInvoicePayment(Flag, OrderID, OrderDetailID, BankRefNoQuery, ShipmentNo) {
        //debugger;
        //var url = '../../Internal/Delivery/frmMainDeliveryScreen.aspx?Flag=' + Flag + '&OrderID=' + OrderID + '&OrderDetailID=' + OrderDetailID + '&BankRefNoQuery=' + BankRefNoQuery + '&ShipmentNoQuery=' + ShipmentNo;
        var url = '../../Internal/Delivery/frmMainDeliveryScreen.aspx?Flag=INVOICEPAYMENT';
        //        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 700, width: 1100, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //        async: true;
        var win = window.open(url, '_blank');
        win.focus();
    }
    function UpdateContractholdStatus(elem) {
        //        debugger;
        var Ids = elem.id;
        var OutHouse = elem.value;
        var userID = $("#<%=hdnUserID.ClientID%>").val();
        var CId = Ids.split("_")[6].substr(3);
        var orderDetailsID = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_hdnOrderDetailsID" + "']").val();
        var IsOnHold = $("#<%= GridView1.ClientID %> input[id*='ctl" + CId + "_chkonhold" + "']").is(":checked") ? 1 : 0;
        proxy.invoke("Updatecontractholdstatus", { orderDetails_ID: orderDetailsID, IsChecked: IsOnHold, userID: userID }, function (result) {
            //            jQuery.facebox('Done!');

        }, onPageError, false, false);
    }
    //updated code by bharat 18-jan-19
    jQuery(document).ready(function () {
        //alert();
        jQuery('.floatingHeader ').find('th:eq(0)').removeAttr('style').addClass('thwidntopfixed0');
        jQuery('.floatingHeader ').find('th:eq(1)').removeAttr('style').addClass('thwidntopfixed1');
        jQuery('.floatingHeader ').find('th:nth-last-child(3)').removeAttr('style').addClass('thwidntopfixed2');
        //        jQuery('.floatingHeader ').find('th:nth-last-child(2)').removeAttr('style').addClass('thwidntopfixed2');
        jQuery('.floatingHeader ').find('th:nth-last-child(2)').removeAttr('style').addClass('thwidntopfixed4');

    })
  
</script>
<!---------------------Prabhaker -16-jun-17------->
<!-------------------End-16-jun-17------------------->
<style type="text/css">
    /*updated css by bharat 23-jan-19*/
    
  
    .onholdbgorenge1td td
    {
        background: #ffcb82 !important;
    }
    .onholdbgorenge1td input[type="text"]
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge1td div
    {
        background: #ffcb82 !important;
    }
    
    .onholdbgorenge2td div
    {
        background: #ffcb82;
    }
    .onholdbgorenge2td td
    {
        background: #ffcb82 !important;
    }
    .onholdbgorenge2td td span
    {
        background: #ffcb82 !important;
    }
    .onholdbgorenge2td td input[type="text"]
    {
        background: #ffcb82 !important;
    }
    .onholdbgorenge2td
    {
        background: #ffcb82 !important;
    }
    
    .onholdbgorenge2td div:not(:first-child)
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge2td div td div
    {
        background-color: #ffcb82 !important;
    }
    
    .onholdbgorenge3td div:not(:first-child)
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge3td div td
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge3td div input
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge3td div span
    {
        background-color: transparent !important;
    }
    
    
    .onholdbgorenge3td div td span input
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge3td div select
    {
        background-color: #ffcb82 !important;
    }
    .onholdbgorenge3td div td
    {
        border-color: #f7c27f !important;
    }
    .onholdbgorenge3td div
    {
        border-color: #f7c27f !important;
    }
    .onholdbgorenge2td div div td
    {
        border-color: #f7c27f !important;
    }
    .onholdbgorenge2td td
    {
        border-color: #f7c27f !important;
    }
    .onholdbgorenge2td td div
    {
        border-color: #f7c27f !important;
    } 
    
    /*end*/
    .production-sec td
    {
        height: 15px;
        font-size: 8px;
        vertical-align: middle;
        text-align: center !important;
    }
    /*updated code by bharat 18-jan-19 */
    .floatingHeader
    {
        left: 23px !important;
    }
    .thwidntopfixed0
    {
        width: 195px !important;
    }
    .thwidntopfixed1
    {
        width: 374px !important;
    }
    .thwidntopfixed2
    {
        width: 388px !important;
    }
    .thwidntopfixed4
    {
        width: 262px !important;
    }
    /*end*/
    .head-table td
    {
        background: none !important;
        padding: 0px !important;
        border: 0px !important;
        color: #98a9ca;
    }
    .head-table th
    {
        border: 0px !important;
        text-align: center !important;
    }
    .persist-area
    {
        position: relative;
    }
    .redcrossline
    {
        text-decoration: line-through;
        -moz-text-decoration-color: red;
        text-decoration-color: red;
    }
    .item_list2 TD.newcss2
    {
        background-color: #f9f9fa !important;
        text-transform: capitalize !important;
        line-height: 20px;
        font-size: 9px;
        padding: 0px !important;
    }
    .item_list2 TD
    {
        padding: 0px !important;
        background-color: #f9f9fa;
        border: 1px solid #e6e6e6;
        text-align: left;
        vertical-align: top;
    }
</style>
<div class="form_box" style="border: none !important;">
    <asp:HiddenField ID="hdnfld_SearchText" runat="server" />
    <asp:HiddenField ID="hdnfld_Years" runat="server" />
    <asp:HiddenField ID="hdnfld_FromDate" runat="server" />
    <asp:HiddenField ID="hdnfld_ToDate" runat="server" />
    <asp:HiddenField ID="hdnfld_ClientId" runat="server" />
    <asp:HiddenField ID="hdnfld_AM" runat="server" />
    <asp:HiddenField ID="hdnfld_DateType" runat="server" />
    <asp:HiddenField ID="hdnfld_StatusMode" runat="server" />
    <asp:HiddenField ID="hdnfld_StatusModeSequence" runat="server" />
    <asp:HiddenField ID="hdnfld_OrderBy1" runat="server" />
    <asp:HiddenField ID="hdnfld_OrderBy2" runat="server" />
    <asp:HiddenField ID="hdnfld_OrderBy3" runat="server" />
    <asp:HiddenField ID="hdnfld_OrderBy4" runat="server" />
    <asp:HiddenField ID="hdnfld_strUserID" runat="server" />
    <asp:HiddenField ID="hdnfld_BuyingHouseId" runat="server" />
    <asp:HiddenField ID="hdnfld_UnitId" runat="server" />
    <asp:HiddenField ID="hdnfld_OutHouseId" runat="server" />
    <asp:HiddenField ID="hdnfld_desigId" runat="server" />
    <asp:HiddenField ID="hdnfld_DeptId" runat="server" />
    <asp:HiddenField ID="hdnfld_ParrentDeptId" runat="server" />
    <asp:HiddenField ID="hdnfld_SalesView" runat="server" />
    <asp:HiddenField ID="hdnfld_ClientDeptId" runat="server" />
    <asp:HiddenField ID="hdnfld_OrderType" runat="server" />
    <asp:HiddenField ID="hdnPagesize" runat="server" />
    <asp:HiddenField ID="hdnUserID" runat="server" />
    <asp:HiddenField ID="hdnPageIndex" runat="server" />
    <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
    <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
    <asp:HiddenField ID="hdnQuantity" runat="server" />
    <asp:HiddenField ID="hdnDate" runat="server" />
    <asp:HiddenField ID="hdnfld_DelayStatusId" runat="server" />
    <asp:HiddenField ID="hdnIsUnShipped" Value="" runat="server" />
    <asp:GridView CssClass="item_list2 persist-area" ID="GridView1" Width="1645px" runat="server"
        AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true"
        PageSize="10">
        <Columns>
            <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Basic Info</label>"
                HeaderStyle-CssClass="newtext13" ItemStyle-CssClass="newcss2 newtext13" HeaderStyle-Width="186px"
                ItemStyle-Width="186px" ItemStyle-VerticalAlign="top" HeaderStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div style="width: 100% !important; text-align: center;">
                        <input type="hidden" id="Hidden1" name="contractNumber<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Eval("ContractNumber") != null) ? Eval("ContractNumber").ToString() : ( (Eval("LineItemNumber") != null) ? Eval("LineItemNumber")  : "" ) %>' />
                        <input type="hidden" id="orderDetailID<%# Container.DataItemIndex + 1 %>" name="orderDetailID<%# Container.DataItemIndex + 1 %>"
                            value='<%# Eval("OrderDetailID") %>' />
                        <input type="hidden" id="OrderID<%# Container.DataItemIndex + 1 %>" name="OrderID<%# Container.DataItemIndex + 1 %>"
                            value='<%# Eval("OrderID") %>' />
                        <input type="hidden" id="ClientID<%# Container.DataItemIndex + 1 %>" name="ClientID<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>' />
                        <input type="hidden" id="hdnOrderDate<%# Container.DataItemIndex + 1 %>" name="hdnOrderDate<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == Convert.ToDateTime("1/1/1900"))? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM") %>' />
                        <input type="hidden" id="hdnExFactory<%# Container.DataItemIndex + 1 %>" name="hdnExFactory<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM")%>' />
                        <div style="width: 186px !important; height: 30px;">
                            <div style="width: 29%; text-align: left; float: left;">
                                <span style="text-align: center; font-size: 8px;">
                                    <asp:Label ID="lblOrdDate" ToolTip="Order Date" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                        Visible='<%# Eval("bOrderDateRead") %>' runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == Convert.ToDateTime("1/1/1900"))? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM (ddd)") %>'></asp:Label></span>
                            </div>
                            <div style="width: 30%; text-align: right; float: left;">
                                <asp:Label ID="lblIsRepeatOrder" Font-Size="8px" ToolTip="R means repeat order" runat="server"
                                    ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label>
                            </div>
                            <div style="width: 40%; text-align: right; float: right;">
                                <span class="newtext"><a id="hypSerial" runat="server" style="font-size: 11px;" class="hide_me clsSerialnumber">
                                    <%--Added By Ashish on 28/7/2015--%>
                                    <%--<span><a href="javascript:void(0)"  onclick="showLinksPopup_ManageOrder('<%# Eval("OrderID") %>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>',  this, '<%# Eval("OrderDetailID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString()%>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>')" title="Serial Number" style='height: 80px; width: 19px ! important; font-size:11px; <%# "color :" + Eval("LinktypeForeColor").ToString() %>'><%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></a></span></a>--%>
                                    <span><a target="_blank" href='/Internal/Sales/Order.aspx?orderid=<%# Eval("OrderID")%>'
                                        title="Order Form" style='height: 80px; width: 19px ! important; font-size: 11px;
                                        <%# "color :" + Eval("LinktypeForeColor").ToString() %>'>
                                        <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></a></span></a>
                                    <%--END--%>
                                    <asp:Label ID="lblSerial" runat="server" ToolTip="Serial Number" ForeColor="#0000ee"
                                        Visible="false" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'></asp:Label>
                                    <asp:HiddenField ID="hdnSerialNumber" runat="server" Value='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'>
                                    </asp:HiddenField>
                                </span>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                        <!--Order date and Serial number-->
                        <div style="width: 100% !important; height: 60px;">
                            <span style="text-align: center;"><a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)"
                                onclick='showStylePhotoWithOutScroll(<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString()+",-1,"+Eval("OrderDetailID").ToString() %>)'>
                                <img style="height: 60px !important; width: 60px !important;" title="CLICK TO VIEW ENLARGED IMAGE"
                                    border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("ParentOrder") as iKandi.Common.Order).Style.SampleImageURL1.ToString()) %>' /></a>
                            </span>
                        </div>
                        <!--Image-->
                        <%-- updated by abhishek 3/8/2015--%>
                        <div style="width: 100% !important; height: 20px;">
                            <%--<span class="newtext2" style="text-align:center;" id="spnStyleNumber" runat="server">

                            <a title="Risk Analysis Form"  onclick="showRiskForm('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>','Yes')" style='font-size:11px; font-weight:bold; <%# "color :" + Eval("stylenumberColor").ToString() %>'><%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%></a>

                            <input type="hidden" id="hdnOrderID"  value='<%# Eval("OrderID") %>' />

                         </span>
                          <%--Added By Ashish on 5/2/2015
                        <asp:HiddenField ID="hdnStyleNo" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>' />
                      
                         <asp:Label ID="lblStyleNumber"   ToolTip="Style Number" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("stylenumberColor")) %>' style="font-weight:bold;" Visible="false" Text='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>'></asp:Label>--%>
                            <span class="newtext2" style="text-align: center;" id="spnStyleNumber" runat="server">
                                <%--<a href="javascript:void(0)" onclick="showLinksPopup_ManageOrder('<%# Eval("OrderID") %>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>',  this, '<%# Eval("OrderDetailID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString()%>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>')"  style='font-size:11px;font-weight:bold; <%# "color :" + Eval("BlackToForeColor").ToString() %>'><%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%></a>--%>
                                <a href="javascript:void(0)" onclick="showLinksPopup_ManageOrder('<%# Eval("OrderID") %>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>',  this, '<%# Eval("OrderDetailID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString()%>', '<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode.ToString()%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>','<%# Eval("File") %>','<%# Eval("File2") %>','<%# Eval("File3") %>')"
                                    style='font-size: 11px; font-weight: bold; <%# "color :" + Eval("stylenumberColor").ToString() %>'>
                                    <%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%></a>
                                <input type="hidden" id="hdnOrderID" value='<%# Eval("OrderID") %>' />
                            </span>
                            <asp:HiddenField ID="hdnStyleNo" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>' />
                            <%--<asp:Label ID="lblStyleNumber" ToolTip="Style Number" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>' style="font-weight:bold;" Visible="false" Text='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>'></asp:Label>--%>
                            <asp:Label ID="lblStyleNumber" ToolTip="Style Number" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("stylenumberColor")) %>'
                                Style="font-weight: bold;" Visible="false" Text='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>'></asp:Label>
                        </div>
                        <%--END--%>
                        <div style="width: 100% !important; height: 12px; text-align: center;">
                            <%--<asp:Label ID="lblDiscription" style="font-size:8px !important; color:#807F80 !important;  text-align:center;" Visible='<%#Eval("bBusinessDescriptionRead") %>' Enabled='<%#Eval("bBusinessDescriptionwrite") %>' runat="server" Text='<%# Eval("Description") %>'></asp:Label>--%>
                            <asp:TextBox ID="lblDiscription" MaxLength="50" onchange="javascript:return UpdateDescription(this);"
                                Style="font-size: 8px !important; color: #807F80 !important; text-transform: capitalize;
                                background-color: #f9f9fa; text-align: center;" Visible='<%#Eval("bBusinessDescriptionRead") %>'
                                Enabled='<%#Eval("bBusinessDescriptionwrite") %>' runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                        </div>
                        <!--Description-->
                        <div style="width: 100% !important; vertical-align: top; background-color: #f9f9fa;">
                            <span id="spnDepartment" style="text-align: center;" class="newtext4" runat="server"
                                visible='<%# Eval("bDepartmentRead") %>'><a href="javascript:void(0)" title="CLICK TO GO DEPARTMENT WISE B/D ORDERS"
                                    style='font-size: 8px !important; font-weight: bold; <%# "color :" + Eval("BlackToForeColor").ToString() %>'
                                    onclick="GetManageOrderiKandiQuantityByDept('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>')">
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%></a></span>
                            <asp:Label ID="lblDepartment" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                Style="font-size: 8px;" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%>'></asp:Label>
                        </div>
                        <div style="width: 100%; height: 21px; text-align: center;">
                            <div style="width: 45%; float: left; text-align: center; padding-top: 5px; background-color: #f9f9fa;">
                                <%--<asp:Label ID="lbLine" ToolTip="Line No." style="font-size:8px; color:#807F80 !important;" Visible='<%#Eval("bLineNo") %>' Enabled='<%#Eval("bLinewrite") %>' runat="server" Text='<%# Eval("LineItemNumber")%>'></asp:Label>--%>
                                <asp:TextBox ID="lbLine" ToolTip="Line No." MaxLength="15" Width="100%" onchange="javascript:return UpdateLineNo(this);"
                                    Style="font-size: 8px; background-color: #f9f9fa;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                    Visible='<%#Eval("bLineNo") %>' Enabled='<%#Eval("bLinewrite") %>' runat="server"
                                    Text='<%# Eval("LineItemNumber")%>'></asp:TextBox>
                            </div>
                            <div style="width: 10px; float: left; background-color: #f9f9fa;">
                                |</div>
                            <div style="width: 45%; float: left; text-align: left; padding-top: 5px; background-color: #f9f9fa;">
                                <%--<asp:Label ID="lblContract" ToolTip="Contract No" style="font-size:8px; color:#807F80 !important;" Visible='<%#Eval("bContractNo") %>' Enabled='<%#Eval("bContractwrite") %>' runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label>--%>
                                <asp:TextBox ID="lblContract" ToolTip="Contract No" MaxLength="15" Width="100%" onchange="javascript:return UpdateContractNo(this);"
                                    Style="font-size: 8px; background-color: transparent !important;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                    Visible='<%#Eval("bContractNo") %>' Enabled='<%#Eval("bContractwrite") %>' runat="server"
                                    Text='<%# Eval("ContractNumber")%>'></asp:TextBox>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                        <!--Department and Line number and Contract number-->
                        <%--  <div style="width:250px !important; float:left; height:30px; text-align:center;">

                    <span id="spnDepartment" style="text-align:center;" class="newtext4" runat="server" visible='<%# Eval("bDepartmentRead") %>'><a href="javascript:void(0)" title="CLICK TO GO DEPARTMENT WISE B/D ORDERS" style="color:#000000;font-size:8px !important;" onclick="GetManageOrderiKandiQuantityByDept('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID%>')">

                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%></a></span>

                       <asp:Label ID="lblDepartment" runat="server" style="color:#000000; font-size:8px;" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%>'></asp:Label>

                    <span style="color:#e6e6e6;">|</span>

                    </div>--%>
                        <div style="width: 100% !important; height: 20px; text-align: center; display: inline-block;">
                            <%--<asp:Label ID="lbldressPrice" Text='<%# Eval("DressPrice")%>' runat="server"></asp:Label>--%>
                            <asp:Label ID="lbldressPrice" Style="font-size: 10px; color: #807F80; font-size: 9px !important;"
                                Text='<%# Eval("DressPrice")%>' runat="server"></asp:Label>
                            <span><span id="spnBiplPrice" runat="server"><a title="CLICK TO SEE COSTING FORM"
                                style='font-size: 9px !important; <%# "color :" + Eval("LinktypeForeColor").ToString() %>'
                                target="CostingForm" href="../Sales/CostingSheet.aspx?sn=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>&SingleVersion=1">
                                <%# iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Convert.ToInt32((Eval("ParentOrder") as iKandi.Common.Order).Costing.ConvertTo))%><%#
                            (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Company == iKandi.Common.Company.Boutique)? Convert.ToDouble((Eval("ParentOrder") as iKandi.Common.Order).BiplPrice).ToString("N2") : Convert.ToDouble(Eval("iKandiPrice")).ToString("N2") %>
                            </a></span>|</span>
                            <asp:Label ID="lblBiplPrice" runat="server" ForeColor="#0000ee" Visible="false" Text='<%#
                            (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Company == iKandi.Common.Company.Boutique
                                    && iKandi.BLL.CommonHelper.IsFOBDelivery(Convert.ToInt32(Eval("Mode")))
                              )? (Eval("IsFact").ToString() == "Fact" ? Convert.ToDouble((Eval("ParentOrder") as iKandi.Common.Order).BiplPrice).ToString("N2") : Convert.ToDouble(Eval("iKandiPrice")).ToString("N2")) :
                                                      Convert.ToDouble((Eval("ParentOrder") as iKandi.Common.Order).BiplPrice).ToString("N2") %>'></asp:Label>
                            <asp:Label ID="lblPriceSymbol" Style="color: #807F80; font-size: 9px !important;"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblikandiGross" ToolTip="BIPL Revenue" Style="color: #807F80; font-size: 9px !important;"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblActualProfitMargin" Text='<%# Eval("ActualProfitMargin")%>' Style="font-size: 9px !important;
                                color: #807F80;" runat="server"></asp:Label>
                            <div style="clear: both;">
                            </div>
                        </div>
                        <div style="width: 100% !important; height: 20px; text-align: center;">
                            <asp:Label ID="lblIkandiPriceTag" Style="font-size: 9px !important;" runat="server"></asp:Label>&nbsp;<asp:Label
                                ID="lblIkandiDiscount" ToolTip="Ikandi Gross Price" Style="font-size: 9px !important;
                                color: #807F80 !important;" runat="server"></asp:Label>
                            <%--<asp:Label ID="lblSeprator" runat="server" Text="|"></asp:Label>--%>
                            <asp:Label ID="lblMargin" ToolTip="Ikandi Profit Margin" runat="server" Style="font-size: 8px !important;
                                color: #807F80 !important;"></asp:Label>
                            <span style="display: none;">
                                <asp:Label ID="lblBusinessTag" Style="font-size: 8px !important; color: #807F80 !important;"
                                    runat="server"></asp:Label>&nbsp;<asp:Label ID="lblBusiness" ToolTip="Ikandi Business"
                                        Style="font-size: 8px !important; color: #807F80 !important;" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div style="width: 100% !important; height: 20px; text-align: center;">
                            <asp:Label ID="lblWeight" Style="font-size: 9px !important;" Text="" runat="server"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtWeight" MaxLength="4" onchange="javascript:return UpdateWeight(this);"
                                Width="20px" Style="font-size: 8px !important; background-color: #f9f9fa; text-align: right;"
                                Visible='<%#Eval("bCostingWeight") %>' Enabled='<%#Eval("bCostingWeight_Permission") %>'
                                onkeypress="javascript:return isNumber(event);" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Costing.Weight %>'></asp:TextBox>&nbsp;
                            <asp:Label ID="lblUnitCostingWeight" Style="font-size: 9px !important; color: Gray;
                                text-transform: lowercase !important" Text="GMS" Visible='<%#Eval("bCostingWeight") %>'
                                runat="server"></asp:Label>
                            <%--Updated By Prabhaker on 15/3/2018--%>
                        </div>
                    </div>
                    </div>
                    <div style="width: 100%; padding-top: 5px; padding-left: 5px; display: none;">
                        <div style="width: 240px; float: left;">
                            <div style="float: left; text-align: center; width: 80px;">
                                <asp:Label ID="lblplannedex" ToolTip="Pre ExFactory" Style="font-size: 8px !important;
                                    color: #807F80 !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("PlannedEx")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PlannedEx"))).ToString("dd MMM") +")"%>'
                                    Visible='<%# Eval("bShipmentOfferDateRead") %>' Enabled='<%# Eval("bShipmentOfferDatewrite") %>'></asp:Label>
                                <asp:HiddenField runat="server" ID="lblEx" Value='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                            </div>
                        </div>
                    </div>
                    <!--Pre ExFactory-->
                    <div style="font-size: 9px; color: #000000; text-align: center; width: 186px; display: none;">
                        <%--Updated By Ashish on 28/3/2015--%>
                        <asp:Label ID="lblpopending" Visible='<%#Eval("bBasicInfoRemarkRead") %>' Text='<%# Eval("Pricevariation") %>'
                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("PricevariationColor")) %>'
                            Style="font-size: 8px !important;" runat="server"></asp:Label>
                        <%--END--%>
                        <asp:Label ID="lbladd" Text="  " Style="font-size: 8px !important; color: #807F80 !important;"
                            runat="server"></asp:Label>
                    </div>
                    <div runat="server" id="divAgreement" style="font-size: 9px; width: 186px; padding-top: 5px;
                        text-align: center;">
                        <asp:Label ID="lblPendingAgrement" Text='BIPL Agreement pending' Style="font-size: 8px !important;
                            font-weight: bold;" runat="server"></asp:Label>
                    </div>
                    <div style="height: 16px;">
                        <div style="font-size: 9px; color: rgb(128, 127, 128) !important; <%# "display :" + Eval("IsTestReportvisible").ToString() %>;
                            padding-top: 5px;" class="photoshot">
                            Photoshot:<asp:CheckBox ID="chkPhotoshot" Checked='<%#Eval("PhotoShoot") %>' Enabled='<%# ((bool)Eval("PhotoShoot"))==true? false : true %>'
                                runat="server" Style="vertical-align: middle;" onclick="javascript:return UpdatePhotoShot(this,'');" />
                            <asp:TextBox ID="TxtPhotoshot" Width="80px" class="th" Enabled='<%# ((bool)Eval("PhotoShoot"))==true? false : true %>'
                                Style="font-size: 8px !important; text-transform: capitalize !important; padding: 3px;
                                border: 1px solid #ccc;" runat="server" Text='<%# (Convert.ToDateTime(Eval("IsPhotoShoot")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("IsPhotoShoot")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("IsPhotoShoot")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("IsPhotoShoot")) == Convert.ToDateTime("01-01-1900")||Convert.ToDateTime(Eval("IsPhotoShoot")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("IsPhotoShoot")).ToString("dd MMM (ddd)")  : Convert.ToDateTime(Eval("IsPhotoShoot")).ToString("dd MMM (ddd)") %>'
                                onchange="javascript:return UpdatePhotoShot(this,'');"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnOrderdetailsids" runat="server" Value='<%# Eval("OrderDetailID")%>' />
                    <%--end by abhishek on 15/3/2016--%>
                    <div style="font-size: 9px; color: #0000ee; width: 186px; line-height: 13px; padding-top: 5px;
                        min-height: 25px; margin-top: 55px;">
                        <asp:Label ID="lbldelaytaskname" ToolTip="Basic Section Delay Task" runat="server"
                            Text='<%# Eval("DelayTask")%>'></asp:Label>
                    </div>
                    <div style="font-size: 9px; color: #0000ee; width: 186px; padding-top: 5px; display: none;">
                        <%--Updated By Ashish on 28/3/2015--%>
                        <asp:Label ID="lblCQDA" Text='<%# Eval("CQDA") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CQDForeColor")) %>'
                            Style="font-size: 8px !important;" runat="server"></asp:Label>
                        <%--END--%>
                    </div>
                    <div style="font-size: 9px; color: #0000ee; width: 100%;">
                        <!--padding-top updated by prashant -->
                        <table width="100%" cellpadding="0" cellspacing="0" border="0" style='<%# "border:none !important; fore-color :" + Eval("ExFactoryColor").ToString() %>'>
                            <tr>
                                <td valign="top" align="left" style='<%# "border:none !important; width:100%;  text-align:left; fore-color :" + Eval("ExFactoryColor").ToString() %>'>
                                    <asp:Label ID="lblshippingRemarks" Style="font-size: 8px !important; text-transform: capitalize !important;
                                        color: #807F80 !important;" runat="server"></asp:Label>
                                </td>
                                <td valign="bottom" style='<%# "border:none !important;  text-align:right; fore-color :" + Eval("ExFactoryColor").ToString() %>'>
                                    <a id="lnkShipping" runat="server" style="cursor: pointer;">
                                        <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" /></a>
                                    <asp:HiddenField ID="hdnShipping" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!--Comments-->
                </ItemTemplate>
                <HeaderStyle Width="186px"></HeaderStyle>
                <ItemStyle Width="186px" CssClass="newcss2"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField FooterStyle-Width="365px" ItemStyle-HorizontalAlign="Center"  >
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="head-table" style="z-index:1">
                        <tr>
                            <th colspan="5">
                                <label>
                                    Fabric
                                </label>
                            </th>
                        </tr>
                        <tr>
                            <td width="150px" align="center" rowspan="2">
                                Quality/Description
                            </td>
                            <td width="91px" align="center" style="text-align: center">
                                Avg/wd Inch
                            </td>
                            <td align="center" style="text-align: center; width: 50px;">
                                inhouse
                            </td>
                            <td align="center" style="text-align: center; width: 53px;">
                                Issued
                            </td>
                            <td style="text-align: center; width: 53px;">
                                Required
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="width: 66px; float: left;">
                                    &nbsp;
                                </div>
                                <div style="width: 50px; float: left; text-align: center">
                                    I ETA
                                </div>
                                <div style="width: 53px; float: left; text-align: center">
                                    B.St. ETA
                                </div>
                                <div style="width: 53px; float: left; text-align: right;">
                                    A Dt / E. ETA
                                </div>
                                <div style="clear: both">
                                </div>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style='text-align: center; padding-top: 5px; padding-bottom: 5px; width: 100%;
                        <%# "background-color :" + Eval("BIHBackColor").ToString() %>'>
                        <a href='/Internal/Fabric/FabricWorkingSheet.aspx?orderid=<%# Eval("OrderID")%>&OrderDetailID=<%# Eval("OrderDetailID") %>'
                            target="_blank" title="Fabric Order Form">
                            <asp:Label ID="LabelBIHname" Style="font-size: 11px; font-family: Arial;" runat="server"
                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BIHForColor")) %>'
                                Visible='<%# Eval("FBIHDateRead") %>' Text="B.I.H : "></asp:Label>
                            <asp:Label ID="lblBulkInhouseTgt" Style="font-size: 11px; font-weight: bold;" runat="server"
                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BIHForColor")) %>'
                                Text='<%# (Convert.ToDateTime(Eval("BulkTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("BulkTarget")).ToString("dd MMM yy (ddd)")%>'
                                Visible='<%# Eval("FBIHDateRead")%>'></asp:Label>&nbsp<span style="font-size: 8px;"></span></a>
                        <%--<input type="hidden" name="hdnBulk<%# Container.DataItemIndex + 1 %>" value='<%# (Convert.ToDateTime(Eval("BulkTargetDept")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("BulkTargetDept")).ToString("dd MMM yy (ddd)") %>' />--%>
                    </div>
                    <div style="text-align: center; width: 100%; min-height: 252px;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr id="trFirstFabric" visible="false" runat="server">
                                <td align="left" id="td1f1" runat="server" height="15px" style="border-bottom: none !important;
                                    border-right: none !important; width: 155px;">
                                    <div style='border-bottom: none !important; border-right: none !important; <%# "background-color :" + Eval("Fabric1NameBackColor").ToString() %>'>
                                        <span runat="server" id="fabric1name" style="text-align: left; font-weight: bold;
                                            font-size: 8px; cursor: pointer; color: Blue" title="Fabric Approval">
                                            <%# Eval("Fabric1")%>
                                        </span>
                                        <asp:Label ID="lblFab1" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Fabric1NameForColor")) %>'
                                            CssClass="FabricCls1" Text='<%# Eval("Fabric1")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnFab1" runat="server" Value='<%# Eval("Fabric1")%>' />
                                    </div>
                                </td>
                                <td align="center" width="10%" id="td2f1" runat="server" visible="false" style="border-bottom: none !important;
                                    border-right: none !important;">
                                    <asp:Label ID="lblFabric1OrderAverage" runat="server" Style="font-size: 8px !important;
                                        color: #807F80 !important;" Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'
                                        Text='<%# Eval("Fabric1OrderAverage")%>'></asp:Label>
                                </td>
                                <td align="center" id="td2p1" runat="server" style="border-bottom: none !important;
                                    color: #807F80 !important; text-align: center; width: 45px; padding-top: 2px !important;">
                                    <asp:Label ID="lblFabric1STCAverage" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                        ReadOnly="true" Text='<%# Eval("Fabric1STCAverage")%>' Visible='<%# Eval("FOrdRead")%>'
                                        Enabled='<%# Eval("FOrdWrite")%>'></asp:Label>
                                    <asp:Label ID="lblCutwidth1" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Fabric1OrderAverage")%>' />
                                    <asp:HiddenField ID="hdnOrderQty" runat="server" Value='<%# Eval("Quantity")%>' />
                                    <asp:HiddenField ID="hdnFabric1stcAverage" runat="server" Value='<%# Eval("Fabric1STCAverage")%>' />
                                    <asp:HiddenField ID="hdnUnitCaption1" runat="server" Value='<%# Eval("UnitOfAverage1")%>' />
                                </td>
                                <td align="center" id="td3f1" runat="server" style="border-bottom: none !important;
                                    width: 30px; border-right: none !important; border-left: none !important; text-align: center;
                                    padding-top: 2px !important;">
                                    <a id="lnkPercent1" runat="server">
                                        <asp:Label ID="lblPercent1" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            Style="font-size: 8px; text-align: center;" runat="server" Visible='<%# Eval("FPerInhouseRead")%>'
                                            Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>'></asp:Label>
                                    </a>
                                </td>
                                <td align="center" id="td4f1" runat="server" style="border-bottom: none !important;
                                    border-right: 1px solid #E6E6E6; padding-top: 4px; border-left: 1px solid #E6E6E6;
                                    width: 32px;">
                                    <div style='width: 100%; height: 15px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor1").ToString()%>'>
                                        <%--<asp:TextBox ID="lblQuantityAvl1" runat="server" ToolTip='<%# Eval("QuantityAvl1")%>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>' onchange="javascript:return 
                                        (this,1);" onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,1)" onclick="SetFinalFabricOrderActualValue(this,1)"  CssClass="numeric-field-without-decimal-places" style="text-align:center; width: 30px; font-size:8px !important;  background:transparent!important;"  Text='<%# Eval("FinalOrderFabric1_k")%>' Visible='<%# Eval("FRecdRead")%>'  Enabled='<%# Eval("FRecdWrite")%>' ></asp:TextBox>--%>
                                        <asp:TextBox ID="lblQuantityAvl1" runat="server" ToolTip='<%# Eval("QuantityAvl1")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,1);" CssClass="numeric-field-without-decimal-places"
                                            Style="text-align: center; width: 30px; font-size: 8px !important; background: transparent!important;"
                                            Text='<%# Eval("FinalOrderFabric1_k")%>' Visible='<%# Eval("FRecdRead")%>' ReadOnly="true"
                                            Enabled='<%# Eval("FRecdWrite")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdnQuantityAvl1" runat="server" Value='<%# Eval("QuantityAvl1")%>' />
                                        <asp:HiddenField ID="hdnFinalOrderFabric1_k" runat="server" Value='<%# Eval("FinalOrderFabric1_k")%>' />
                                    </div>
                                </td>
                                <td align="center" id="tdfab1Fbricinhouse" runat="server" style="border-bottom: none !important;
                                    border-right: 1px solid #E6E6E6; width: 70px; padding-top: 4px; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; height: 15px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor1").ToString()%>'>
                                        <%-- <asp:TextBox ID="txtinhouseqntyfab1" ToolTip='<%# Eval("fab1CheckInHouse")%>' runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,1);"
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; width: 30px;
                                            font-size: 8px !important; background: transparent!important;" Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab1InHouseChecked_k")%>'
                                            onblur="javascript:Set_defualtOrderInhouseActualValue(this,1)" onclick="SetInHouseOrderActualValue(this,1)" ></asp:TextBox>--%>
                                        <asp:TextBox ID="txtinhouseqntyfab1" ReadOnly="true" ToolTip='<%# Eval("fab1CheckInHouse")%>'
                                            runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,1);"
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; width: 24px;
                                            font-size: 8px !important; background: transparent!important;" Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab1InHouseChecked_k")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,1);"></asp:TextBox>
                                        <asp:Label ID="lblfabinHouseAvg" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                        <asp:HiddenField ID="hdnFab1incheckedval" runat="server" Value='<%# Eval("fab1CheckInHouse")%>' />
                                        <asp:HiddenField ID="hdnFab1incheckedvalk" runat="server" Value='<%# Eval("Fab1InHouseChecked_k")%>' />
                                    </div>
                                </td>
                                <td align="center" title='<%# Eval("Fabric1Required_ToolTip")%>' id="td5f1" runat="server"
                                    style="width: 30px; border-bottom: none !important; border-left: none !important;">
                                    <div style="padding-top: 2px; text-align: center;">
                                        <asp:Label ID="lblFinalOrderFabric1" ToolTip='<%# Eval("Fabric1Required_ToolTip")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            runat="server" Style="font-size: 8px !important;" Visible='<%# Eval("FFabTotalRead")%>'
                                            Enabled='<%# Eval("FFabTotalWrite")%>' Text='<%# Eval("FinalOrderFabric1")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnFinalOrderFabric1" runat="server" Value='<%# Eval("FinalOrderFabric1")%>' />
                                        <asp:HiddenField ID="hdnFinalFabric1" runat="server" Value='<%# Eval("FinalOrderFabric1")%>' />
                                        <asp:HiddenField ID="hdnFinalFabric_ToolTip" runat="server" Value='<%# Eval("Fabric1Required_ToolTip")%>' />
                                    </div>
                                </td>
                            </tr>
                            <tr id="trfirstprint" visible="false" runat="server">
                                <td id="td1p1" runat="server" align="left" height="15px" style="width: 155px; border-right: none !important;
                                    border-bottom: 1px solid #e6e6e6;">
                                    <asp:Label ID="lblFabric1Details" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BulkApproval1ForColor")) %>'
                                        Style="font-size: 8px; font-weight: bold; color: #000" Text='<%# Eval("Fabric1Details")%>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblfabricApprovalColor1" Font-Size="8px" Font-Bold="true" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TractStatus1ForColor")) %>'
                                        CssClass='<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus.ToString().Trim() == "" ) ? "hide_me": "" %>'
                                        Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus%>'></asp:Label>
                                </td>
                                <td colspan="5" align="left" id="td3p1" runat="server" style="margin: 0px !important;
                                    padding: 0px !important; border-top: 1px solid #e6e6e6; border-right: 1px solid #e6e6e6;
                                    border-bottom: 1px solid #e6e6e6; font-size: 8px; text-transform: capitalize;
                                    line-height: 10px; background-color: #F9F9FA;" width="184px">
                                    <div style="border-right: 1px solid #E6E6E6; width: 47px; float: left; height: 21px;
                                        padding-top: 5px;">
                                        <%--Added By Ashish on 24/3/2015--%>
                                        <asp:TextBox ID="lblSummary1" runat="server" Visible='<%#Eval("FFabSummaryRead") %>'
                                            Enabled='<%#Eval("FFabSummaryWrite") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SummryColor")) %>'
                                            Style="text-transform: capitalize; font-size: 8px; background-color: transparent;"
                                            CssClass="do-not-allow-typing" Width="45" Text='<%# Eval("TotalSummary1")%>'></asp:TextBox>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA1BackColor").ToString()%>'>
                                        <asp:TextBox ID="txtStrikeof1" Width="50px" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfBackColor1"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfForeColor1"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'StrikeOff1');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("StrikeOff1ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff1ETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("StrikeOff1ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff1ETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("StrikeOff1ETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("StrikeOff1ETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA1BackColor").ToString()%>'>
                                        <%--<a onclick="javascript:return showEtaPopupFABRIC('FABSTR','Fabric','Fab1','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric1")).Replace(@"""","")%>','<%# Eval("Fabric1Details")%>','<%# (Convert.ToDateTime(Eval("fabric1ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric1ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric1ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric1ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabStartETAWrite")%>',60);"
                                            href="#">--%>
                                        <asp:TextBox ID="txtFab1StartEta" Enabled="false" ReadOnly="true" Visible='<%# Eval("FFabStartETARead")%>'
                                            CssClass="do-not-allow-typing" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StartETA1ForColor")) %>'
                                            runat="server" Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" Width="52px" Text='<%# (Convert.ToDateTime(Eval("fabric1ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric1ETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        <%-- </a>--%>
                                    </div>
                                    <div style='width: 54px; height: 21px; padding-top: 5px; float: left; text-align: center;
                                        <%# "background-color :" + Eval("ENDETA1BackColor").ToString() %>'>
                                        <%--  <a onclick="javascript:return showEtaPopupFABRIC('','Fabric','Fab1','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric1")).Replace(@"""","")%>','<%# Eval("Fabric1Details")%>','<%# (Convert.ToDateTime(Eval("fabric1ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric1ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric1ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric1ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabEndETAWrite")%>',60);"
                                            href="#">--%>
                                        <asp:TextBox ID="txtFab1EndEta" ReadOnly="true" Enabled="false" CssClass="do-not-allow-typing"
                                            Visible='<%# Eval("FFabEndETARead")%>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("ENDETA1ForColor")) %>'
                                            runat="server" Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" Width="52px" Text='<%# (Convert.ToDateTime(Eval("Fabric1ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric1ENDETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        <%-- </a>--%>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                </td>
                            </tr>
                            <tr id="trsecFabric" visible="false" runat="server">
                                <td align="left" id="td4f2" runat="server" style="border-top: none !important;
                                    border-bottom: none !important; border-right: none !important;">
                                    <div style='border-bottom: none !important; border-right: none !important; <%# "background-color :" + Eval("Fabric2NameBackColor").ToString() %>'>
                                        <span runat="server" id="fabric2name" style="text-align: left; font-size: 8px; font-weight: bold;
                                            cursor: pointer; color: Blue;" title="Fabric Approval">
                                            <%# Eval("Fabric2")%></span>
                                        <asp:Label ID="lblFab2" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Fabric2NameForColor")) %>'
                                            Text='<%# Eval("Fabric2")%>' CssClass="FabricCls1"></asp:Label>
                                        <asp:HiddenField ID="hdnFab2" runat="server" Value='<%# Eval("Fabric2")%>' />
                                    </div>
                                </td>
                                <td id="td5f2" runat="server" visible="false" style="border-bottom: none !important;
                                    border-top: none !important; border-right: none !important;">
                                    <asp:Label ID="lblFabric2OrderAverage" runat="server" Style="font-size: 8px !important;
                                        color: #807F80 !important;" Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'
                                        Text='<%# Eval("Fabric2OrderAverage")%>'></asp:Label>
                                </td>
                                <td id="td2p2" runat="server" style="border-bottom: none !important; border-top: none !important;
                                    color: #807F80 !important; padding-top: 2px !important; text-align: center;">
                                    <asp:Label ID="lblFabric2STCAverage" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ReadOnly="true" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>'
                                        Text='<%# Eval("Fabric2STCAverage")%>' Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'></asp:Label>
                                    <asp:Label ID="lblCutwidth2" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>'
                                        Visible="false"></asp:Label>
                                    <%--Added By Ashish on 1/1/2015--%>
                                    <asp:HiddenField ID="hdnFabric2OrderAverage" runat="server" Value='<%# Eval("Fabric2OrderAverage")%>' />
                                    <asp:HiddenField ID="hdnFabric2stcAverage" runat="server" Value='<%# Eval("Fabric2STCAverage")%>' />
                                    <asp:HiddenField ID="hdnAverage1" runat="server" />
                                </td>
                                <%-- <td width="20px">
                              <asp:HyperLink ID="viewolay2" ToolTip="VIEW CAD File" runat="server" style="display:none;"   Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>

                             </td>--%>
                                <td id="td6f2" runat="server" style="border-bottom: none !important; border-top: none !important;
                                    border-right: none !important; border-left: none !important; text-align: center;
                                    padding-top: 2px !important;">
                                    <a id="lnkPercent2" runat="server">
                                        <asp:Label ID="lblPercent2" runat="server" Style="font-size: 8px;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>'
                                            Visible='<%# Eval("FPerInhouseRead")%>' Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>'></asp:Label></a>
                                </td>
                                <td id="td7f2" runat="server" style="border-bottom: none !important; border-top: none !important;
                                    padding-top: 4px; border-right: 1px solid #E6E6E6; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; height: 15px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor2").ToString()%>'>
                                        <%--<asp:TextBox ID="lblQuantityAvl2" ToolTip='<%# Eval("QuantityAvl2")%>' onchange="javascript:return ManageOrderFabricInHouseHistory(this,2);" ReadOnly="true" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>' onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,2)" onclick="SetFinalFabricOrderActualValue(this,2)" CssClass="numeric-field-without-decimal-places" style="font-size:8px !important; background:transparent" runat="server"   Text='<%# Eval("FinalOrderFabric2_k")%>' Visible='<%# Eval("FRecdRead")%>'  Enabled='<%# Eval("FRecdWrite")%>' ></asp:TextBox>--%>
                                        <asp:TextBox ID="lblQuantityAvl2" ToolTip='<%# Eval("QuantityAvl2")%>' onclick="javascript:return ManageOrderFabricInHouseHistory(this,2);"
                                            ReadOnly="true" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>'
                                            onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,2)" CssClass="numeric-field-without-decimal-places"
                                            Style="font-size: 8px !important; background: transparent" runat="server" Text='<%# Eval("FinalOrderFabric2_k")%>'
                                            Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdnQuantityAvl2" runat="server" Value='<%# Eval("QuantityAvl2")%>' />
                                        <asp:HiddenField ID="hdnFinalOrderFabric2_k" runat="server" Value='<%# Eval("FinalOrderFabric2_k")%>' />
                                    </div>
                                </td>
                                <td align="center" id="tdfab2Fbricinhouse" runat="server" style="border-bottom: none !important;
                                    border-right: 1px solid #E6E6E6; padding-top: 4px; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; min-height: 10px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor2").ToString()%>'>
                                        <%--<asp:TextBox ID="txtinhouseqntyfab2" ToolTip='<%# Eval("fab2CheckInHouse")%>' runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                           onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,2);" CssClass="numeric-field-without-decimal-places"
                                           Style="text-align: center; width: 30px; font-size: 8px !important; background: transparent!important;"
                                           Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab2InHouseChecked_k")%>'
                                            onblur="javascript:Set_defualtOrderInhouseActualValue(this,2)" onclick="SetInHouseOrderActualValue(this,2)"  ></asp:TextBox>--%>
                                        <asp:TextBox ID="txtinhouseqntyfab2" ReadOnly="true" ToolTip='<%# Eval("fab2CheckInHouse")%>'
                                            runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,2);"
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; width: 24px;
                                            font-size: 8px !important; background: transparent!important;" Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab2InHouseChecked_k")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,2);"></asp:TextBox>
                                        <asp:Label ID="lblfabinHouseAvg2" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                        <asp:HiddenField ID="hdnFab2incheckedval" runat="server" Value='<%# Eval("fab2CheckInHouse")%>' />
                                        <asp:HiddenField ID="hdnFab2incheckedvalk" runat="server" Value='<%# Eval("Fab2InHouseChecked_k")%>' />
                                    </div>
                                </td>
                                <td id="td8f2" title='<%# Eval("Fabric2Required_ToolTip")%>' runat="server" style="border-bottom: none !important;
                                    border-top: none !important; border-left: none !important;">
                                    <div style="padding-top: 2px; text-align: center;">
                                        <asp:Label ID="lblFinalOrderFabric2" ToolTip='<%# Eval("Fabric2Required_ToolTip")%>'
                                            runat="server" Style="font-size: 8px !important;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent2ForColor")) %>'
                                            Visible='<%# Eval("FFabTotalRead")%>' Enabled='<%# Eval("FFabTotalWrite")%>'
                                            Text='<%# Eval("FinalOrderFabric2")%>'></asp:Label></div>
                                    <asp:HiddenField ID="hdnFinalFabric2" runat="server" Value='<%# Eval("FinalOrderFabric2")%>' />
                                    <asp:HiddenField ID="hdnFina2Fabric_ToolTip" runat="server" Value='<%# Eval("Fabric2Required_ToolTip")%>' />
                                </td>
                            </tr>
                            <tr id="trsecPrint" visible="false" runat="server">
                                <td id="td1p2" runat="server" align="left" height="21px" style="border-right: none !important;
                                    border-bottom: 1px solid #e6e6e6; width: 155px;">
                                    <asp:Label ID="lblFabric2Details" Style="font-size: 8px; font-weight: bold; color: #000;"
                                        runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BulkApproval2ForColor")) %>'
                                        Text='<%# Eval("Fabric2Details")%>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblfabricApprovalColor2" Font-Size="8px" Font-Bold="true" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TractStatus2ForColor")) %>'
                                        CssClass='<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus.ToString().Trim() == "" ) ? "hide_me": "" %>'
                                        Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus%>'></asp:Label>
                                </td>
                                <td colspan="5" id="td3p2" runat="server" align="left" style="margin: 0px !important;
                                    padding: 0px !important; text-transform: capitalize; border-top: 1px solid #e6e6e6;
                                    border-left: 1px solid #e6e6e6; border-right: 1px solid #e6e6e6; border-bottom: 1px solid #e6e6e6;
                                    font-size: 8px; background-color: transparent;">
                                    <div style="border-right: 1px solid #E6E6E6; width: 47px; float: left; height: 21px;
                                        padding-top: 5px;">
                                        <%--Added By Ashish on 24/3/2015--%>
                                        <asp:TextBox ID="lblSummary2" Width="45" Visible='<%#Eval("FFabSummaryRead") %>'
                                            Enabled='<%#Eval("FFabSummaryWrite") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SummryColor")) %>'
                                            CssClass="do-not-allow-typing" Style="text-transform: capitalize; font-size: 8px;
                                            background-color: transparent;" runat="server" Text='<%# Eval("TotalSummary2")%>'></asp:TextBox>
                                    </div>
                                    <%--Added By Ashish on 12/1/2014--%>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA2BackColor").ToString() %>'>
                                        <%-- <span id="divFab2" runat="server">--%>
                                        <asp:TextBox ID="txtStrikeof2" Width="50px" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfBackColor2"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfForeColor2"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'StrikeOff2');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("StrikeOff2ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff2ETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("StrikeOff2ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff2ETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("StrikeOff2ETA")).ToString("dd MMM (ddd)")  : Convert.ToDateTime(Eval("StrikeOff2ETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA2BackColor").ToString() %>'>
                                        <%-- <a onclick="javascript:return showEtaPopupFABRIC('FABSTR','Fabric','Fab2','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric2")).Replace(@"""","")%>','<%# Eval("Fabric2Details")%>','<%# (Convert.ToDateTime(Eval("fabric2ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric2ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric2ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric2ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabStartETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab2StartEta" Enabled="false" Visible='<%# Eval("FFabStartETARead")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StartETA2ForColor")) %>'
                                            CssClass="do-not-allow-typing" Style="text-align: center; font-size: 8px !important;
                                            text-transform: capitalize !important; background-color: transparent;" runat="server"
                                            Width="52px" Text='<%# (Convert.ToDateTime(Eval("fabric2ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric2ETA")).ToString("dd MMM")%>'></asp:TextBox></a>
                                        <%--END--%>
                                    </div>
                                    <div style='width: 54px; height: 21px; padding-top: 5px; float: left; text-align: center;
                                        <%# "background-color :" + Eval("ENDETA2BackColor").ToString() %>'>
                                        <%--<a onclick="javascript:return showEtaPopupFABRIC('','Fabric','Fab2','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric2")).Replace(@"""","")%>','<%# Eval("Fabric2Details")%>','<%# (Convert.ToDateTime(Eval("fabric2ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric2ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric2ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric2ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabEndETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab2EndEta" Enabled="false" CssClass="do-not-allow-typing" Visible='<%# Eval("FFabEndETARead")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("ENDETA2ForColor")) %>'
                                            Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Width="52px" Text='<%# (Convert.ToDateTime(Eval("Fabric2ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric2ENDETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        <%--   </a>--%>
                                    </div>
                                    <%--  </span>--%>
                                </td>
                                <%-- <td  id="t7p2" visible="false" runat="server" align="right" style="border-top:none !important; border-right:1px solid #e6e6e6 !important; border-bottom:1px solid #e6e6e6 !important;">&nbsp;</td>--%>
                            </tr>
                            <tr id="trthirdFabric" visible="false" runat="server">
                                <td id="td7f3" runat="server" align="left" height="15px" style="border-right: none !important;
                                    border-top: none !important; border-bottom: 1px solid #e6e6e6;">
                                    <div style='border-bottom: none !important; border-right: none !important; <%# "background-color :" + Eval("Fabric3NameBackColor").ToString() %>'>
                                        <span runat="server" id="fabric3name" style="text-align: left; font-size: 8px; cursor: pointer;
                                            color: Blue; font-weight: bold;" title="Fabric Approval">
                                            <%# Eval("Fabric3")%></span>
                                        <%-- <a title="CLICK TO VIEW APPROVALS FORM" target="FabricApprovals" style="font-size:8px; <%# "color :" + Eval("Fabric3NameForColor").ToString() %>"

                            href='<%#(Eval("Fabric3Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Print").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")         +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                            +"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>

                            </a>--%>
                                        <asp:Label ID="lblFab3" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Fabric3NameForColor")) %>'
                                            Text='<%# Eval("Fabric3")%>' CssClass="FabricCls1"></asp:Label>
                                        <asp:HiddenField ID="hdnFab3" runat="server" Value='<%# Eval("Fabric3")%>' />
                                    </div>
                                </td>
                                <td id="td8f3" runat="server" visible="false" align="center" style="border-bottom: none !important;
                                    border-top: none !important; border-right: none !important;">
                                    <asp:Label ID="lblFabric3OrderAverage" Style="font-size: 8px !important; cursor: pointer;
                                        color: #807F80 !important;" runat="server" Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'
                                        Text='<%# Eval("Fabric3OrderAverage")%>'></asp:Label>
                                </td>
                                <td id="td2p3" runat="server" align="center" style="border-right: none !important;
                                    color: #807F80 !important; border-bottom: none !important; border-top: none !important;
                                    color: #807F80 !important; border-left: 1px solid #e6e6e6; padding-top: 2px !important;
                                    text-align: center;">
                                    <asp:Label ID="lblFabric3STCAverage" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ReadOnly="true" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                        Text='<%# Eval("Fabric3STCAverage")%>' Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'></asp:Label>
                                    <asp:Label ID="lblCutwidth3" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                        Visible="false"></asp:Label>
                                    <%--Added By Ashish on 1/1/2015--%>
                                    <asp:HiddenField ID="hdnFabric3OrderAverage" runat="server" Value='<%# Eval("Fabric3OrderAverage")%>' />
                                    <asp:HiddenField ID="hdnFabric3stcAverage" runat="server" Value='<%# Eval("Fabric3STCAverage")%>' />
                                    <%--END--%>
                                </td>
                                <%--     <td width="20px">
                              <asp:HyperLink ID="viewolay3" ToolTip="VIEW CAD File" runat="server"  style="display:none;"  Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>

                             </td>--%>
                                <td id="td9f3" runat="server" align="center" style="border-bottom: none !important;
                                    border-right: none !important; border-left: none !important; border-top: none !important;
                                    text-align: center; padding-top: 2px !important;">
                                    <a id="lnkPercent3" runat="server">
                                        <asp:Label ID="lblPercent3" Style="font-size: 8px;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                            runat="server" Visible='<%# Eval("FPerInhouseRead")%>' Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>'></asp:Label></a>
                                </td>
                                <td id="td10f3" runat="server" align="center" style="border-bottom: none !important;
                                    border-top: none !important; border-left: 1px solid #E6E6E6; border-right: 1px solid #E6E6E6;
                                    color: #807F80 !important;">
                                    <div style='width: 100%; height: 15px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor3").ToString()%>'>
                                        <%--<asp:TextBox ID="lblQuantityAvl3" ReadOnly="true" ToolTip='<%# Eval("QuantityAvl3")%>' onchange="javascript:return ManageOrderFabricInHouseHistory(this,3);"
                                     ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                     onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,3)" onclick="SetFinalFabricOrderActualValue(this,3)"
                                     CssClass="numeric-field-without-decimal-places" Style="font-size: 8px !important;
                                     padding-top: 4px; background: transparent" runat="server" Text='<%# Eval("FinalOrderFabric3_k")%>'
                                     Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>' ></asp:TextBox>--%>
                                        <asp:TextBox ID="lblQuantityAvl3" ReadOnly="true" ToolTip='<%# Eval("QuantityAvl3")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,3);" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                            onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,3)" CssClass="numeric-field-without-decimal-places"
                                            Style="font-size: 8px !important; background: transparent" runat="server" Text='<%# Eval("FinalOrderFabric3_k")%>'
                                            Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdnQuantityAvl3" runat="server" Value='<%# Eval("QuantityAvl3")%>' />
                                        <asp:HiddenField ID="hdnFinalOrderFabric3_k" runat="server" Value='<%# Eval("FinalOrderFabric3_k")%>' />
                                    </div>
                                </td>
                                <td align="center" id="tdfab3Fbricinhouse" runat="server" style="border-bottom: none !important;
                                    border-right: 1px solid #E6E6E6; padding-top: 4px; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; min-height: 10px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor3").ToString()%>'>
                                        <%--<asp:TextBox ID="txtinhouseqntyfab3" ToolTip='<%# Eval("fab3CheckInHouse")%>' runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                           onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,3);" CssClass="numeric-field-without-decimal-places"
                                           Style="text-align: center; width: 30px; font-size: 8px !important; background: transparent!important;"
                                           Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab3InHouseChecked_k")%>' onblur="javascript:Set_defualtOrderInhouseActualValue(this,3)" onclick="SetInHouseOrderActualValue(this,3)" ></asp:TextBox>--%>
                                        <asp:TextBox ID="txtinhouseqntyfab3" ReadOnly="true" ToolTip='<%# Eval("fab3CheckInHouse")%>'
                                            runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; width: 24px;
                                            font-size: 8px !important; background: transparent!important;" Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab3InHouseChecked_k")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,3);"></asp:TextBox>
                                        <asp:Label ID="lblfabinHouseAvg3" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                        <asp:HiddenField ID="hdnFab3incheckedval" runat="server" Value='<%# Eval("fab3CheckInHouse")%>' />
                                        <asp:HiddenField ID="hdnFab3incheckedvalk" runat="server" Value='<%# Eval("Fab3InHouseChecked_k")%>' />
                                    </div>
                                </td>
                                <td id="td11f3" title='<%# Eval("Fabric3Required_ToolTip")%>' runat="server" align="center"
                                    style="border-bottom: none !important; border-top: none !important; border-left: none !important;">
                                    <div style="padding-top: 2px; text-align: center;">
                                        <asp:Label ID="lblFinalOrderFabric3" ToolTip='<%# Eval("Fabric3Required_ToolTip")%>'
                                            Style="font-size: 8px !important;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent3ForColor")) %>'
                                            Visible='<%# Eval("FFabTotalRead")%>' Enabled='<%# Eval("FFabTotalWrite")%>'
                                            Text='<%# Eval("FinalOrderFabric3")%>'></asp:Label></div>
                                    <asp:HiddenField ID="hdnFinalFabric3" runat="server" Value='<%# Eval("FinalOrderFabric3")%>' />
                                    <asp:HiddenField ID="hdnFina3Fabric_ToolTip" runat="server" Value='<%# Eval("Fabric3Required_ToolTip")%>' />
                                </td>
                            </tr>
                            <tr id="trthirdprint" visible="false" runat="server">
                                <td id="td1p3" runat="server" align="left" height="15px" style="border-left: 1px solid #e6e6e6;
                                    border-bottom: 1px solid #e6e6e6; border-top: none !important; border-right: none !important;
                                    width: 155px;">
                                    <asp:Label ID="lblFabric3Details" Style="font-size: 8px; font-weight: bold;" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BulkApproval3ForColor")) %>'
                                        Text='<%# Eval("Fabric3Details")%>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblfabricApprovalColor3" Font-Size="8px" Font-Bold="true" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TractStatus3ForColor")) %>'
                                        CssClass='<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus.ToString().Trim() == "" ) ? "hide_me": "" %>'
                                        Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus%>'></asp:Label>
                                </td>
                                <td colspan="5" id="td3p3" runat="server" align="left" style="margin: 0px !important;
                                    padding: 0px !important; text-transform: capitalize; border-top: 1px solid #e6e6e6;
                                    border-left: 1px solid #e6e6e6; border-bottom: 1px solid #e6e6e6; border-right: 1px solid #e6e6e6;
                                    font-size: 8px; background-color: transparent;">
                                    <div style="border-right: 1px solid #E6E6E6; width: 47px; float: left; height: 21px;
                                        padding-top: 5px;">
                                        <%--Added By Ashish on 24/3/2015--%>
                                        <asp:TextBox ID="lblSummary3" Visible='<%#Eval("FFabSummaryRead") %>' Enabled='<%#Eval("FFabSummaryWrite") %>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SummryColor")) %>'
                                            CssClass="do-not-allow-typing" Style="text-transform: capitalize; font-size: 8px;
                                            background-color: transparent;" Width="45" runat="server" Text='<%# Eval("TotalSummary3")%>'></asp:TextBox>
                                    </div>
                                    <%--<asp:Label ID="lblPercent3" runat="server" Text='<%# Eval("Percent3")%>'></asp:Label></td>--%>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA3BackColor").ToString() %>'>
                                        <%--  <span id="divFab3" runat="server">--%>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <%-- //added by sushil on date 30/3/2015--%>
                                        <asp:TextBox ID="txtStrikeof3" Width="50px" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfBackColor3"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfForeColor3"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'StrikeOff3');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("StrikeOff3ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff3ETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("StrikeOff3ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff3ETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("StrikeOff3ETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("StrikeOff3ETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA3BackColor").ToString() %>'>
                                        <%--<a onclick="javascript:return showEtaPopupFABRIC('FABSTR','Fabric','Fab3','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric3")).Replace(@"""","")%>','<%# Eval("Fabric3Details")%>','<%# (Convert.ToDateTime(Eval("fabric3ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric3ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric3ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric3ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabStartETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab3StartEta" Enabled="false" CssClass="do-not-allow-typing"
                                            Visible='<%# Eval("FFabStartETARead")%>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StartETA3ForColor")) %>'
                                            Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Width="52px" Text='<%# (Convert.ToDateTime(Eval("fabric3ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric3ETA")).ToString("dd MMM (ddd)")%>'></asp:TextBox></a>
                                        <%--END--%>
                                    </div>
                                    <div style='width: 54px; height: 15px; padding-top: 5px; float: left; text-align: center;
                                        <%# "background-color :" + Eval("ENDETA3BackColor").ToString() %>'>
                                        <%-- <a onclick="javascript:return showEtaPopupFABRIC('','Fabric','Fab3','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric3")).Replace(@"""","")%>','<%# Eval("Fabric3Details")%>','<%# (Convert.ToDateTime(Eval("fabric3ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric3ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric3ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric3ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabEndETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab3EndEta" Enabled="false" CssClass="do-not-allow-typing" Visible='<%# Eval("FFabEndETARead")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("ENDETA3ForColor")) %>'
                                            Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Width="52px" Text='<%# (Convert.ToDateTime(Eval("Fabric3ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric3ENDETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        <%-- </a>--%>
                                    </div>
                                    <%--   </span>--%>
                                </td>
                                <%-- <td  id="td7p3" visible="false" runat="server" align="right" style="border-top:none !important;  border-left:1px solid #e6e6e6 !important; border-bottom:1px solid #e6e6e6 !important;">&nbsp;</td>--%>
                            </tr>
                            <tr id="trfourFabric" visible="false" runat="server">
                                <td id="td10f4" runat="server" height="15px" style="border-bottom: #e6e6e6 1px solid;
                                    border-right-style: none !important; border-top-style: none !important;">
                                    <div style='border-bottom: none !important; border-right: none !important; <%# "background-color :" + Eval("Fabric4NameBackColor").ToString() %>'>
                                        <span runat="server" id="fabric4name" style="text-align: left; font-size: 8px; cursor: pointer;
                                            color: Blue; font-weight: bold;" title="Fabric Approval">
                                            <%# Eval("Fabric4")%></span>
                                        <%-- <a target="FabricApprovals" style=" <%# "color :" + Eval("Fabric4NameForColor").ToString() %>" href='<%#(Eval("Fabric4Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Print").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))              +"&CCGSM11="+Server.UrlEncode(Eval("CCGSM4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))                +"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>

                                </a>--%>
                                        <asp:Label ID="lblFab4" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Fabric4NameForColor")) %>'
                                            Text='<%# Eval("Fabric4")%>' CssClass="FabricCls1"></asp:Label>
                                        <asp:HiddenField ID="hdnFab4" runat="server" Value='<%# Eval("Fabric4")%>' />
                                    </div>
                                </td>
                                <td id="td11f4" runat="server" visible="false" align="center" style="border-top: none !important;
                                    border-right: none !important; border-bottom: none !important;">
                                    <asp:Label ID="lblFabric4OrderAverage" Style="font-size: 8px !important; cursor: pointer;
                                        color: #807F80 !important;" runat="server" Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'
                                        Text='<%# Eval("Fabric4OrderAverage")%>'></asp:Label>
                                </td>
                                <td id="td2p4" runat="server" align="center" style="border-bottom-style: none !important;
                                    border-left: #e6e6e6 1px solid; border-top-style: none !important; color: #807f80 !important;
                                    padding-top: 2px !important; text-align: center;">
                                    <asp:Label ID="lblFabric4STCAverage" runat="server" Style="font-size: 8px; cursor: pointer;
                                        background-color: transparent; font-weight: bold;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                        ReadOnly="true" Visible='<%# Eval("FOrdRead")%>' Enabled='<%# Eval("FOrdWrite")%>'
                                        Text='<%# Eval("Fabric4STCAverage")%>'></asp:Label>
                                    <asp:Label ID="lblCutwidth4" Style="font-size: 8px; cursor: pointer; background-color: transparent;
                                        font-weight: bold;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                        Visible="false"></asp:Label>
                                    <%--Added By Ashish on 1/1/2015--%>
                                    <asp:HiddenField ID="hdnFabric4OrderAverage" runat="server" Value='<%# Eval("Fabric4OrderAverage")%>' />
                                    <asp:HiddenField ID="hdnFabric4stcAverage" runat="server" Value='<%# Eval("Fabric4STCAverage")%>' />
                                    <%--END--%>
                                </td>
                                <%--  <td width="20px">
                              <asp:HyperLink ID="viewolay4" ToolTip="VIEW CAD File" runat="server" style="display:none;" Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>

                             </td> --%>
                                <td id="td12f4" runat="server" align="center" style="border-bottom: none !important;
                                    border-top: none !important; border-right: none !important; border-left: none !important;
                                    text-align: center; padding-top: 2px !important;">
                                    <a id="lnkPercent4" runat="server">
                                        <asp:Label ID="lblPercent4" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                            Style="font-size: 8px;" Visible='<%# Eval("FPerInhouseRead")%>' Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>'></asp:Label></a>
                                </td>
                                <td id="td13f4" runat="server" align="center" style="border-bottom: none !important;
                                    border-top: none !important; border-right: 1px solid #E6E6E6; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; height: 15px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor4").ToString()%>'>
                                        <%--<asp:TextBox ID="lblQuantityAvl4" ReadOnly="true" ToolTip='<%# Eval("QuantityAvl4")%>' onchange="javascript:return ManageOrderFabricInHouseHistory(this,4);"
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                            onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,4)" onclick="SetFinalFabricOrderActualValue(this,4)"
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; font-size: 8px !important;
                                            padding-top: 4px; background: transparent" runat="server" Text='<%# Eval("FinalOrderFabric4_k")%>'
                                            Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdnQuantityAvl4" runat="server" Value='<%# Eval("QuantityAvl4")%>' />--%>
                                        <asp:TextBox ID="lblQuantityAvl4" ReadOnly="true" ToolTip='<%# Eval("QuantityAvl4")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,4);" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                            onblur="javascript:Set_defualtFinalFabricOrderActualValue(this,4)" CssClass="numeric-field-without-decimal-places"
                                            Style="text-align: center; font-size: 8px !important; padding-top: 4px; background: transparent"
                                            runat="server" Text='<%# Eval("FinalOrderFabric4_k")%>' Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdnQuantityAvl4" runat="server" Value='<%# Eval("QuantityAvl4")%>' />
                                        <asp:HiddenField ID="hdnFinalOrderFabric4_k" runat="server" Value='<%# Eval("FinalOrderFabric4_k")%>' />
                                    </div>
                                </td>
                                <td align="center" id="tdfab4Fbricinhouse" runat="server" style="border-bottom: none !important;
                                    border-right: 1px solid #E6E6E6; padding-top: 4px; border-left: 1px solid #E6E6E6;">
                                    <div style='width: 100%; min-height: 10px; float: left; text-align: center; <%# "background-color :" + Eval("FabricAvgColor4").ToString()%>'>
                                        <%--<asp:TextBox ID="txtinhouseqntyfab4" ToolTip='<%# Eval("fab4CheckInHouse")%>' runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            onchange="javascript:return ManageOrderFabricInHouseHistory_checked(this,4);" CssClass="numeric-field-without-decimal-places"
                                            Style="text-align: center; width: 30px; font-size: 8px !important; background: transparent!important;"
                                            Visible='<%# Eval("FRecdRead")%>' Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab4InHouseChecked_k")%>' onblur="javascript:Set_defualtOrderInhouseActualValue(this,4)" onclick="SetInHouseOrderActualValue(this,4)" ></asp:TextBox>--%>
                                        <asp:TextBox ID="txtinhouseqntyfab4" ReadOnly="true" ToolTip='<%# Eval("fab4CheckInHouse")%>'
                                            runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent1ForColor")) %>'
                                            CssClass="numeric-field-without-decimal-places" Style="text-align: center; width: 24px;
                                            font-size: 8px !important; background: transparent!important;" Visible='<%# Eval("FRecdRead")%>'
                                            Enabled='<%# Eval("FRecdWrite")%>' Text='<%# Eval("Fab4InHouseChecked_k")%>'
                                            onclick="javascript:return ManageOrderFabricInHouseHistory(this,4);"></asp:TextBox>
                                        <asp:Label ID="lblfabinHouseAvg4" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                        <asp:HiddenField ID="hdnFab4incheckedval" runat="server" Value='<%# Eval("fab4CheckInHouse")%>' />
                                        <asp:HiddenField ID="hdnFab4incheckedvalk" runat="server" Value='<%# Eval("Fab4InHouseChecked_k")%>' />
                                    </div>
                                </td>
                                <td id="td14f4" title='<%# Eval("Fabric4Required_ToolTip")%>' runat="server" align="center"
                                    style="border-bottom: none !important; border-top: none !important; border-left: none !important;">
                                    <div style="padding-top: 2px; text-align: center;">
                                        <asp:Label ID="lblFinalOrderFabric4" ToolTip='<%# Eval("Fabric4Required_ToolTip")%>'
                                            Style="font-size: 8px !important;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("Percent4ForColor")) %>'
                                            Visible='<%# Eval("FFabTotalRead")%>' Enabled='<%# Eval("FFabTotalWrite")%>'
                                            Text='<%# Eval("FinalOrderFabric4")%>'></asp:Label></div>
                                    <asp:HiddenField ID="hdnFinalFabric4" runat="server" Value='<%# Eval("FinalOrderFabric4")%>' />
                                    <asp:HiddenField ID="hdnFina4Fabric_ToolTip" runat="server" Value='<%# Eval("Fabric4Required_ToolTip")%>' />
                                </td>
                            </tr>
                            <tr id="trfourprint" runat="server" visible="false">
                                <td id="td1p4" runat="server" align="left" height="21px" style="border-top: none !important;
                                    border-right: none !important;">
                                    <asp:Label ID="lblFabric4Details" Style="font-size: 8px; font-weight: bold;" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BulkApproval4ForColor")) %>'
                                        Text='<%# Eval("Fabric4Details")%>'></asp:Label>
                                    <%-- <label style="font-size:8px; color:Black;" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabricApprovalColor" %>">

                                (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus%>)</label>--%>
                                    <br />
                                    <asp:Label ID="lblfabricApprovalColor4" Font-Size="8px" Font-Bold="true" runat="server"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TractStatus4ForColor")) %>'
                                        CssClass='<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus.ToString().Trim() == "" ) ? "hide_me": "" %>'
                                        Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus%>'></asp:Label>
                                </td>
                                <td colspan="5" id="td3p4" runat="server" align="left" style="margin: 0px !important;
                                    padding: 0px !important; text-transform: capitalize; border-top: 1px solid #e6e6e6;
                                    border-right: 1px solid #e6e6e6; font-size: 8px; background-color: transparent;">
                                    <div style="border-right: 1px solid #E6E6E6; width: 47px; float: left; height: 21px;
                                        padding-top: 5px;">
                                        <%--Added By Ashish on 24/3/2015--%>
                                        <asp:TextBox ID="lblSummary4" Visible='<%#Eval("FFabSummaryRead") %>' Enabled='<%#Eval("FFabSummaryWrite") %>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SummryColor")) %>'
                                            CssClass="do-not-allow-typing" Style="text-transform: capitalize; font-size: 8px;
                                            background-color: transparent;" Width="45" runat="server" Text='<%# Eval("TotalSummary4")%>'></asp:TextBox>
                                        <%--END--%>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA4BackColor").ToString() %>'>
                                        <%--<span id="divFab4" runat="server">--%>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <%-- //added by sushil on date 30/3/2015--%>
                                        <asp:TextBox ID="txtStrikeof4" Width="50px" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfBackColor4"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StrikeOfForeColor4"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'StrikeOff4');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("StrikeOff4ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff4ETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("StrikeOff4ETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("StrikeOff4ETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("StrikeOff4ETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("StrikeOff4ETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </div>
                                    <div style='border-right: 1px solid #E6E6E6; width: 53px; height: 21px; padding-top: 5px;
                                        float: left; text-align: center; <%# "background-color :" + Eval("StartETA4BackColor").ToString() %>'>
                                        <%--  <a onclick="javascript:return showEtaPopupFABRIC('FABSTR','Fabric','Fab4','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric4")).Replace(@"""","")%>','<%# Eval("Fabric4Details")%>','<%# (Convert.ToDateTime(Eval("fabric4ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric4ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric4ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric4ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabStartETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab4StartEta" Enabled="false" CssClass="do-not-allow-typing"
                                            Visible='<%# Eval("FFabStartETARead")%>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("StartETA4ForColor")) %>'
                                            Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Width="52px" Text='<%# (Convert.ToDateTime(Eval("fabric4ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric4ETA")).ToString("dd MMM (ddd)")%>'></asp:TextBox></a>
                                        <%--END--%>
                                    </div>
                                    <div style='width: 54px; height: 21px; padding-top: 5px; float: left; text-align: center;
                                        <%# "background-color :" + Eval("ENDETA4BackColor").ToString() %>'>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <%--<a onclick="javascript:return showEtaPopupFABRIC('','Fabric','Fab4','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# ((string)Eval("Fabric4")).Replace(@"""","")%>','<%# Eval("Fabric4Details")%>','<%# (Convert.ToDateTime(Eval("fabric4ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric4ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric4ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric4ENDETA")).ToString("dd MMM yy (ddd)")%>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>','<%#Eval("OrderDetailID") %>','<%# Eval("FFabEndETAWrite")%>',60);"
                                        href="#">--%>
                                        <asp:TextBox ID="lblFab4EndEta" Enabled="false" CssClass="do-not-allow-typing" Visible='<%# Eval("FFabEndETARead")%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("ENDETA4ForColor")) %>'
                                            Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Width="52px" Text='<%# (Convert.ToDateTime(Eval("Fabric4ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric4ENDETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        <%--END--%>
                                        </a>
                                        <%-- //end by sushil on date 30/3/2015--%>
                                    </div>
                                    <%-- </span>--%>
                                    <%--  <span id="Spanfab4pending" runat="server">
                             <div style="border-right:1px solid #E6E6E6; width:34%; height: 15px; padding-top: 5px; float:left; text-align: center;">
                             <a onclick="javascript:return showEtaPopup('Fabric','Fab4','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','<%# Eval("Fabric4")%>','<%# Eval("Fabric4Details")%>','<%# (Convert.ToDateTime(Eval("fabric4ETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("fabric4ETA")).ToString("dd MMM yy (ddd)")%>','<%# (Convert.ToDateTime(Eval("Fabric4ENDETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("Fabric4ENDETA")).ToString("dd MMM yy (ddd)")%>','<%# (Eval("FabricRemarks").ToString().IndexOf("$$") > -1) ? Eval("FabricRemarks").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("FabricRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") %>','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>',60);"  href="#">
                              <asp:TextBox ID="lblfab4pending" CssClass="do-not-allow-typing" runat="server" style="font-size:8px !important; color:red !important;" Width="60" Text='<%# Eval("fab4pending") %>' ></asp:TextBox>
                             </a>
                             <%--END
                             </div>
                             </span>--%>
                                </td>
                                <%-- <td id="td7p4" visible="false" runat="server" align="right" style="border-top:none !important;">&nbsp;</td>--%>
                                <%--<asp:Label ID="lblPercent4" runat="server" Text='<%# Eval("Percent3")%>'></asp:Label></td>--%>
                            </tr>
                        </table>
                    </div>
                    <%--added by abhishek on 6/4/2016 future task for fabric section--%>
                    <div style="font-size: 9px; color: #0000ee; width: 100%; padding-top: 5px; min-height: 26px;
                        text-align: left;">
                        <asp:Label ID="lbldfabricelaytaskname" runat="server" ToolTip="Fabric Section Delay Task"
                            Text='<%# Eval("FabricDelayTask")%>'></asp:Label>
                    </div>
                    <%--end by abhishek--%>
                    <div style="text-align: left; vertical-align: bottom; bottom: 0px; border: none !important;
                        width: 100%;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3" style="border: none !important;">
                                    <div style="width: 100%;">
                                        <div style="padding-right: 5px; display: none; text-align: left; float: left;">
                                            <asp:Label ID="lblFabUserName" Style="font-size: 8px !important; color: #606060 !important;"
                                                runat="server"></asp:Label></div>
                                        <div style="width: 58%; display: none; text-align: left; float: left;">
                                            <asp:Label ID="lblFabRemark" Style="font-size: 8px !important; text-transform: capitalize !important;
                                                color: #807F80 !important;" runat="server"> </asp:Label></div>
                                        <div style="text-align: right; float: right; display: none;" id="spanFabTracking"
                                            runat="server">
                                            <%--commented by abhishek on 25/12/2015--%>
                                            <img title="CLICK TO SEE FABRIC POPUP" src="/App_Themes/ikandi/images/view_icon.png" />
                                            <%--end by abhishek--%>
                                            <%--border="0" onclick="showFabricPopup('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderDetailID") %>','<%# Eval("OrderID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric1Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4Print").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>')" />--%>
                                            <asp:HiddenField ID="hdnFabRemarks" runat="server" />
                                        </div>
                                        <div style="text-align: right; float: right; display: none;">
                                            <a id="lnkFabpopup" runat="server">
                                                <img src="../../App_Themes/ikandi/images/zoom_icon.gif" /></a></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
                <HeaderStyle Width="365px"></HeaderStyle>
                <ItemStyle Width="365px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-VerticalAlign="Middle">
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="head-table">
                        <tr>
                            <th colspan="6">
                                <label>
                                    Accessories
                                </label>
                            </th>
                        </tr>
                        <tr>
                            <td width="110px" align="center">
                                Quality
                            </td>
                            <td width="25px" align="center">
                                In House
                            </td>
                            <td width="60px" align="center">
                                Order. on
                            </td>
                            <td width="30px" align="center">
                                Recd
                            </td>
                            <td width="30px" align="center">
                                Total
                            </td>
                            <td width="60px" align="center">
                                Act Dat/End ETA
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="text-align: center; width: 380px;">
                        <div>
                            <div id="dvBIHAccessories" runat="server" style="text-align: center; padding-top: 5px;
                                padding-bottom: 5px; width: 100%;">
                                <a href='/Internal/Fabric/FabricAccessoriesWorkSheet.aspx?orderid=<%# Eval("OrderID")%>'
                                    target="_blank" title="Accessory Order Form">
                                    <%-- abhishek 4/8/2015--%>
                                    <asp:Label ID="LabelAccBIHname" Style="font-size: 11px;" runat="server" ToolTip="Accessory Order Form"
                                        Visible='<%# Eval("FBIHDateRead") %>' Text="B.I.H : "></asp:Label>
                                    <%--end--%>
                                    <%--Added by abhishek on 8/1/2015--%>
                                    <asp:Label ID="lblACCBulkInhouseTgt" Style="font-size: 11px; font-weight: bold; font-family: Arial;"
                                        runat="server" Text='<%# (Convert.ToDateTime(Eval("BulkAccsesoryTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("BulkAccsesoryTarget")).ToString("dd MMM yy (ddd)")%>'
                                        Visible='<%# Eval("FBIHDateRead")%>'></asp:Label>&nbsp<span style="font-size: 8px;"></span></a>
                                <%--End by abhishek on 8/1/2015--%>
                            </div>
                        </div>
                        <div style="overflow: auto; min-height: 252px; width: 380px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: none;">
                                <tr>
                                    <td style="width: 100%; border: none !important;" colspan="3">
                                        <asp:Repeater ID="repAccess" runat="server" OnItemDataBound="repAccess_ItemDataBound">
                                            <ItemTemplate>
                                                <div id="dvAccessories" runat="server">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: none !important;
                                                        font-size: 10px; border-collapse: collapse;">
                                                        <tr id="tr_lblParcentInHouse">
                                                            <td style='border: 1px solid #e6e6e6; text-align: left; letter-spacing: -.3px; background-color: transparent;
                                                                <%# "background-color :" + Eval("AccessNameBackColor").ToString() %>'>
                                                                <div style="width: 110px; text-align: left; line-height: 15px;">
                                                                    <asp:Label ID="lblAccessories" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessNameForColor")) %>'
                                                                        runat="server" Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                    <asp:HiddenField ID="hdnAccessories" runat="server" />
                                                                </div>
                                                            </td>
                                                            <td style='border: 1px solid #e6e6e6; border-left: none !important; text-align: center;
                                                                background-color: transparent; <%# "background-color :" + Eval("AccessPercentInhouseBackColor").ToString() %>'>
                                                                <div style="width: 25px; text-align: center; line-height: 15px;">
                                                                    <asp:Label ID="lblParcentInHouse" Style="font-size: 8px;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessPercentInhouseForColor")) %>'
                                                                        runat="server" Text='<%#Eval("percentInHouse") %>'></asp:Label></div>
                                                            </td>
                                                            <td style="border: 1px solid #e6e6e6; border-left: none !important; background-color: transparent;
                                                                text-align: center;">
                                                                <div style="width: 60px; text-align: center; line-height: 15px;">
                                                                    <asp:TextBox ID="txtDateAcc" onchange="javascript:UpdateAccsessoryAppDate(this);"
                                                                        Style="font-size: 8px;" class="th do-not-allow-typing" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessCaptionForColor")) %>'
                                                                        runat="server" Text='<%# (Convert.ToDateTime(Eval("UpdatedOn")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("UpdatedOn")).ToString("dd MMM") %>'></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td style="border: 1px solid #e6e6e6; border-left: none !important; font-size: 8px !important;
                                                                background-color: transparent;" title='<%# Eval("QuantityAvail")%>'>
                                                                <div style="width: 30px; text-align: center; line-height: 15px; padding-top: 2px;">
                                                                    <asp:TextBox ID="txtQuantityAvail" onchange="javascript:return CalculationonAcc(this);"
                                                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessCaptionForColor")) %>'
                                                                        Style="background-color: transparent; font-size: 8px;" runat="server" Text='<%#Eval("QnAvail_k") %>'
                                                                        onblur="javascript:Set_defualtFinalAccsessoryOrderActualValue(this)" onclick="SetFinalAccsessoryOrderActualValue(this)"
                                                                        MaxLength="10">
                                                    
                                                                    </asp:TextBox>
                                                                    <asp:HiddenField ID="hdnQuantityAvailk" runat="server" Value='<%#Eval("QnAvail_k") %>' />
                                                                    <asp:HiddenField ID="hdnQuantityAvailActual" runat="server" Value='<%#Eval("QuantityAvail") %>' />
                                                                    <asp:Label ID="lblAccessPopup" runat="server" ForeColor="Gray" Visible="false" Text="Accessories Popup"></asp:Label>
                                                                    <asp:HiddenField ID="hdnApprovalDate" runat="server" Value='<%# (Convert.ToDateTime(Eval("ApprovalDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("ApprovalDate")).ToString("dd MMM") %>' />
                                                                    <asp:HiddenField ID="hdnAccWorkingDetailsID" runat="server" Value='<%#Eval("AccessoryWorkingDetailID") %>' />
                                                                    <asp:HiddenField ID="hdnPercentInHouse" runat="server" Value='<%#Eval("PercentInHouse") %>' />
                                                                </div>
                                                            </td>
                                                            <td style="border: 1px solid #e6e6e6; background-color: transparent;" id="id1">
                                                                <div style="width: 30px; text-align: center; line-height: 15px; padding-top: 2px;">
                                                                    <asp:TextBox ID="txtRequired" runat="server" Text='<%#Eval("Required") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessCaptionForColor")) %>'
                                                                        CssClass="do-not-allow-typing" Style="font-size: 8px !important; background-color: transparent;"></asp:TextBox>
                                                                    <asp:HiddenField ID="hdnRequiredActual" runat="server" Value='<%#Eval("Required") %>' />
                                                                </div>
                                                            </td>
                                                            <%--updated By Ravi on 11/2/2015 for define width in td id="tdAccessEta" runat="server" --%>
                                                            <td style='border: 1px solid #e6e6e6; background-color: transparent; font-size: 8px !important;
                                                                color: #0000EE !important; text-align: center; <%# "background-color :" + Eval("AccessETABackColor").ToString() %>'>
                                                                <div style="width: 60px; text-align: center; line-height: 15px; padding-top: 2px;">
                                                                    <asp:HiddenField ID="hdnAccesoriesEta" runat="server" Value='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM yy")%>' />
                                                                    <asp:HiddenField ID="hdnAccesETA" runat="server" Value='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM yy")%>' />
                                                                    <asp:TextBox ID="lblAccess4StartEta" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("AccessETAForColor")) %>'
                                                                        Style="text-align: center; font-size: 8px !important; text-transform: capitalize !important;
                                                                        background-color: transparent;" CssClass="do-not-allow-typing" runat="server"
                                                                        Width="60" onclick="javascript:return showEtaPopupAcceess('Access',this,61);"
                                                                        Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM")%>'></asp:TextBox>
                                                                   <%-- <asp:TextBox ID="lbletapending" CssClass="do-not-allow-typing" Style="font-size: 8px !important;
                                                                        display: none; background-color: transparent;" runat="server" Width="50" onclick="javascript:return showEtaPopupAcceess('Access',this,61);"
                                                                        Text='<%# Eval("ETAPending")%>'></asp:TextBox>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="font-size: 9px; color: #0000ee; width: 100%; text-align: left; padding-top: 5px;
                            min-height: 26px;">
                            <asp:Label ID="lblAccessoriesDelaytask" ToolTip="Accessories Section Delay Task"
                                runat="server" Text='<%# Eval("AccessoriesDelayTask")%>'></asp:Label>
                        </div>
                        <div style="width: 100%;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: none;
                                font-size: 10px;">
                                <tr>
                                    <td style="width: 33%; border: none !important; display: none">
                                        <asp:Label ID="lblRName" Style="font-size: 8px !important; color: #807F80 !important;"
                                            runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 77%; text-align: left; border: none !important; display: none">
                                        <asp:Label ID="lblAccessoriesRemark" Style="font-size: 8px !important; color: #807F80 !important;
                                            text-transform: capitalize !important;" runat="server"> </asp:Label>
                                    </td>
                                    <td style="width: 7%; border: none !important; text-align: right">
                                        <%--<asp:ImageButton ID="imgbtnAccRemark" runat="server" ToolTip="CLICK TO SEE REMARKS POPUP" ImageUrl="../../Images/magnify.png" OnClientClick="javascript:return shRemark(this);" CausesValidation="False" />--%>
                                        <%-- commented by abhishek on 25/12/2015--%>
                                        <a id="lnkAccesspopup" runat="server">
                                            <img alt="Shipping Remarks" title="CLICK TO SEE REMARKS POPUP" src="../../App_Themes/ikandi/images/zoom_icon.gif"
                                                style="cursor: pointer;" border="0" /></a>
                                        <%-- //end by abhishek --%>
                                        <asp:HiddenField ID="hdnAccRemarks" runat="server" />
                                        <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                        <asp:HiddenField ID="hdnStyle" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>' />
                                        <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%#Eval("OrderID") %>' />
                                        <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>' />
                                    </td>
                                </tr>
                            </table>
                        </div>
                </ItemTemplate>
                <%--Added By Ashish on 12/1/2014 for define width HeaderStyle--%>
                <HeaderStyle Width="380px"></HeaderStyle>
                <ItemStyle Width="380px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="newcss2">
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="head-table">
                        <tr>
                            <th colspan="3">
                                <label>
                                    Technical
                                </label>
                            </th>
                        </tr>
                        <tr>
                            <td width="37%" align="center">
                                Deliverable
                            </td>
                            <td width="33%" align="center">
                                Target
                                <br />
                                Actual
                            </td>
                            <td width="30%" align="center">
                                ETA
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style='width: 100%; float: left; text-align: center; line-height: 25px; <%# "background-color :" + Eval("PCDBackColor").ToString() %>'>
                        <%--href='/Internal/Fabric/CuttingSheet.aspx?orderid=<%# Eval("OrderID")%>'--%>
                        <div style="cursor: pointer;" onclick="ShowCuttinglistprint(this,'<%#(Eval("OrderDetailID"))%>','<%#(Eval("Mode"))%>','<%#(Eval("Mode"))%>')">
                            <%--<a href="javascript:void(0)" onclick="ShowCuttinglistprint(this,'<%#(Eval("OrderDetailID"))%>','<%#(Eval("Mode"))%>','<%#(Eval("Mode"))%>')" target="_blank"
                            title="Cutting Order Form">--%>
                            <asp:Label ID="Labelpcdname" Style="font-size: 11px; cursor: pointer;" runat="server"
                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("PCDForeColor")) %>'
                                Visible='<%# Eval("FitsPCDRead") %>' Text="PCD : "></asp:Label>
                            <asp:Label ID="lblpcd" Style="font-size: 11px; font-weight: bold; font-family: Arial;
                                cursor: pointer;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("PCDForeColor")) %>'
                                Visible='<%# Eval("FitsPCDRead") %>' Text='<%# (Convert.ToDateTime(Eval("PCDDate")) == Convert.ToDateTime("1/1/1900") || Convert.ToDateTime(Eval("PCDDate")) == Convert.ToDateTime("01/01/0001")) ? "" : (Convert.ToDateTime(Eval("PCDDate"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                            <%-- </a>--%>
                        </div>
                        <asp:HiddenField runat="server" ID="hdnModeIdcutting" Value='<%# Eval("Mode")%>' />
                    </div>
                    <div style="width: 100%; float: left; height: 20px;">
                        <%-- Abhishek--%>
                        <div class="newtext7" style="width: 52%; float: left; text-align: left;">
                            <span style="font-size: 8px !important; color: #666 !important; text-transform: !important;">
                                <asp:Label ID="Labelsamcap" ToolTip="Costing SAM" runat="server" Text='<%#Eval("Samcap") %>'
                                    Visible='<%# Eval("FitsCostingSAMRead") %>' Enabled='<%# Eval("FitsCostingSAMWrite") %>'></asp:Label></span>
                            <a href="javascript:void(0)" onclick="showOBSheet('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>','<%#(Eval("OrderID"))%>','Yes')">
                                <asp:Label ID="Label15" ToolTip="OB Sheet" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SamOBValColor")) %>'
                                    Style="font-size: 8px !important; font-weight: bold;" Text='<%#Eval("Samval") %>'
                                    Visible='<%# Eval("FitsCostingSAMRead") %>' Enabled='<%# Eval("FitsCostingSAMWrite") %>'></asp:Label>
                            </a><span style="font-size: 8px !important; color: #666 !important; text-transform: Uppercase !important;">
                                &nbsp;
                                <asp:Label ID="Label11" runat="server" Text="OB:" Visible='<%# Eval("FitsOBRead") %>'
                                    Enabled='<%# Eval("FitsOBWrite") %>'></asp:Label>
                            </span>
                            <asp:Label ID="lblOB" ToolTip="OB (Planned OB/Actual OB)" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SamOBValColor")) %>'
                                Style="font-size: 8px !important; font-weight: bold;" Text='<%#Eval("OBval") %>'
                                Visible='<%# Eval("FitsOBRead") %>' Enabled='<%# Eval("FitsOBWrite") %>'></asp:Label>
                        </div>
                        <div class="newtext7" style="width: 48%; float: left; text-align: right;">
                            <asp:Label ID="lblst" runat="server" Text="St:" Style="color: gray; font-size: 8px"></asp:Label>
                            <%--<asp:Label ID="lblstdate" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' runat="server" Text='<%# (Convert.ToDateTime(Eval("LinePlannigStartDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("LinePlannigStartDate")).ToString("dd MMM (ddd)")%>'> </asp:Label>--%>
                            <asp:Label ID="lblstdate" ForeColor="gray" Font-Size="8px" runat="server" Text='<%# Eval("LinePlannigStartDate") %>'> </asp:Label>
                            <asp:TextBox ID="txtProPlaningETA" onchange="javascript:return UpdatePatternSampleDateForMO(this,'RPODUCTIONPLANINGETA');"
                                Style="font-size: 8px !important background-color: #F9F9FA !important; width: 65px;
                                border: 1px solid grey; text-transform: capitalize !important;" runat="server"
                                CssClass="th do-not-allow-typing" Text='<%# (Convert.ToDateTime(Eval("ProductionPlanningETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("ProductionPlanningETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("ProductionPlanningETA")).ToString("dd MMM yy (ddd)") %>'></asp:TextBox>
                            <%--<asp:label id="pkcap" Text="Pke.%" runat="server" style="font-size:8px !important; color:#666 !important; text-transform:!important;"></asp:label>
                    <a id="lnkPeekCapacity" runat="server" style="cursor:pointer"> <asp:Label ID="LblPeekCapacity"  style="font-size:8px !important; font-weight:bold;"  ToolTip="Peek capacity" runat="server" Text='<%# Eval("PeekCapacity") %>'></asp:Label>   </a>--%>
                            <%-- <img alt="peek capacity document" title="Upload peek capacity document"   src="../../App_Themes/ikandi/images/zoom_icon.gif" style="cursor:pointer; "  border="0" />--%>
                            <%--END--%>
                        </div>
                        <%--Added By Ashish on 24/3/2015--%>
                        <%-- <div id="divLKM" runat="server" class="newtext7" style="width:19%; float:left; text-align:center;"><asp:Label ID="Label16" ToolTip="LK mins" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' style="font-size:8px !important; font-weight:bold;" Text='<%#Eval("Avalmin") %>' Visible='<%# Eval("FitsLKMRead") %>' Enabled='<%# Eval("FitsLKMWrite") %>'></asp:Label> <span style="font-size:8px !important; color:#807F80 !important; text-transform:lowercase !important;"><asp:Label ID="Label9" runat="server" Text="LKM" Visible='<%# Eval("FitsLKMRead") %>' Enabled='<%# Eval("FitsLKMWrite") %>'></asp:Label></span></div>--%>
                        <%--
                    <div id="divLines" runat="server" class="newtext7" style="width:13%; float:left; text-align:center;"><asp:Label ID="lblLines" ToolTip="Line(s)" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' style="font-size:8px !important; font-weight:bold;" Text='<%#Eval("LinesNo") %>' Visible='<%# Eval("FitsLineRead") %>' Enabled='<%# Eval("FitsLineWrite") %>'></asp:Label> <span style="font-size:8px !important; color:#807F80 !important; text-transform:lowercase !important;"><asp:Label ID="Label1" runat="server" Text="Line" Visible='<%# Eval("FitsLineRead") %>' Enabled='<%# Eval("FitsLineWrite") %>'></asp:Label></span></div>

                    <div id="divDays" runat="server" class="newtext7" style="width:13%; float:left; text-align:right;"><asp:Label ID="lblDays" ToolTip="Days" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' style="font-size:8px !important; font-weight:bold;" Text='<%#Eval("Days") %>' Visible='<%# Eval("FitsDaysRead") %>' Enabled='<%# Eval("FitsDaysWrite") %>'></asp:Label> <span style="font-size:7px !important; color:#807F80 !important; text-transform:lowercase !important;"><asp:Label ID="lblDaysCaption" runat="server" Text="Days" Visible='<%# Eval("FitsDaysRead") %>' Enabled='<%# Eval("FitsDaysWrite") %>'></asp:Label></span></div>--%>
                        <%--END--%>
                        <%-- end--%>
                    </div>
                    <div style='text-align: center; width: 100%; float: left; line-height: 13px; <%# "background-color :" + Eval("FitsPandingColor").ToString() %>'>
                        <asp:Label ID="lblFitsStatus" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColorforfitspending")) %>'
                            Style="text-transform: capitalize !important; font-size: 8px !important; font-weight: bold;
                            letter-spacing: -0.5px; cursor: pointer;" runat="server" Visible='<%# Eval("FitsStatusRead")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFitsETA" runat="server" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsPandingColor"))%>'
                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColorforfitspending")) %>'
                            Visible='<%# Eval("FitsETADateRead")%>' Enabled='<%# Eval("FitsETADateWrite")%>'
                            CssClass="do-not-allow-typing" Style="width: 50px; font-size: 8px; display: none;
                            text-transform: capitalize; border: 1px solid #d6d7d8; background: none; color: #000;"
                            Text='<%# (Convert.ToDateTime(Eval("FitsETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FitsETA")).ToString("dd MMM")%>'></asp:TextBox>
                    </div>
                    <div style="text-align: center; width: 100%; font-size: 8px; line-height: 10px; overflow: auto;
                        min-height: 215px;">
                        <table width="100%" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                            <tr id="apprShow" runat="server">
                                <td id="tdHandover" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <asp:Label ID="lblHandover" runat="server" Text="HandOver"></asp:Label>
                                    &nbsp;<asp:Label ID="lblCADMaster" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblHandOverTargetDate" ToolTip="Hand Over TargetDate" CssClass="date_style  do-not-allow-typing"
                                                Style="font-size: 8px; font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("HandOverTargetDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("HandOverTargetDate"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txHandoverActual" Enabled='<%# Eval("FitsProdActualDateWrite")%>'
                                            Style="width: 98%; height: 10px; font-size: 8px !important; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("HandOverActualDate")) == Convert.ToDateTime("1/1/0001")||Convert.ToDateTime(Eval("HandOverActualDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HandOverActualDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("HandOverETABackColor").ToString() %>'>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:TextBox ID="txtHanoverETA" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("HandOverETABackColor"))%>'
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("HandOverETAForeColor"))%>'
                                        onchange="javascript:return UpdateCuttingSheetDateForMO(this,'HandOver');" Width="70"
                                        Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                        Text='<%# (Convert.ToDateTime(Eval("HandOverETADate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("HandOverETADate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("HandOverETADate")).ToString("dd MMM") %>'></asp:TextBox>
                                    <%--END--%>
                                </td>
                            </tr>
                            <tr id="apprShow1" runat="server">
                                <td id="tdPatternReady" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <asp:Label ID="lblPatternReady" runat="server" Text="Pattern Ready"></asp:Label>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblPatternReadyTargetDate" ToolTip="Pattern Ready TargetDate" CssClass="date_style  do-not-allow-typing"
                                                Style="font-size: 8px; font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternReadyTargetDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("PatternReadyTargetDate"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtPatternReadyActualDate" Enabled='<%# Eval("FitsProdActualDateWrite")%>'
                                            Style="width: 98%; height: 10px; font-size: 8px !important; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("PatternReadyActualDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("PatternReadyActualDate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("PatternReadyActualDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("PatternReadyETABackColor").ToString() %>'>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:TextBox ID="txtPatternReadyETADate" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'PatternReady');"
                                        BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("PatternReadyETABackColor"))%>'
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("PatternReadyETAForeColor"))%>'
                                        Width="70" Style="font-size: 8px !important; text-transform: capitalize !important;"
                                        runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternReadyETADate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("PatternReadyETADate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("PatternReadyETADate")).ToString("dd MMM") %>'></asp:TextBox>
                                    <%--END--%>
                                </td>
                            </tr>
                            <tr id="apprShow2" runat="server">
                                <td id="tdSampleSent" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:Label ID="lblSamplesent" runat="server" Text="Sample Sent"></asp:Label>
                                </td>
                                <%--END--%>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <%-- edited by abhishek on 8/1/2015--%>
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblSamplesentTargetDate" ToolTip="Sample Sent TargetDate" CssClass="date_style  do-not-allow-typing"
                                                Style="font-size: 8px; font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("SampleSentTargetDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("SampleSentTargetDate"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--end by abhishek 8/1/2015--%>
                                        </div>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="txtSampleSentActualDate" Enabled='<%# Eval("FitsProdActualDateWrite")%>'
                                            Style="width: 98%; height: 10px; font-size: 8px !important; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("SampleSentActualDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("SampleSentActualDate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("SampleSentActualDate")).ToString("dd MMM") %>'></asp:TextBox>
                                        <%--END--%>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("SampleSentETABackColor").ToString() %>'>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:TextBox ID="txtSampleSentETA" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SampleSentETABackColor"))%>'
                                        onchange="javascript:return UpdateCuttingSheetDateForMO(this,'SampleSent');"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SampleSentETAForeColor"))%>'
                                        Width="70" Style="font-size: 8px !important; text-transform: capitalize !important;"
                                        runat="server" Text='<%# (Convert.ToDateTime(Eval("SampleSentETADate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("SampleSentETADate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("SampleSentETADate ")).ToString("dd MMM") %>'></asp:TextBox>
                                    <%--END--%>
                                </td>
                            </tr>
                            <tr id="apprShow3" runat="server">
                                <td id="tdFitsCommentesUplaod" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:Label ID="lblFitsCommentesUplaod" runat="server" Text="Fits Cmnt. Upload"></asp:Label>
                                </td>
                                <%--END--%>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <%-- edited by abhishek on 8/1/2015--%>
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblFitsCommentesUplaodTargetDate" ToolTip="Fits Commentes Upload TargetDate"
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsCommentesTargetDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FitsCommentesTargetDate"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--end by abhishek 8/1/2015--%>
                                        </div>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="txtFitsCommentesUplaodActualDate" Enabled='<%# Eval("FitsProdActualDateWrite")%>'
                                            Style="width: 98%; height: 10px; font-size: 8px !important; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("FitsCommentesActualDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("FitsCommentesActualDate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("FitsCommentesActualDate")).ToString("dd MMM") %>'></asp:TextBox>
                                        <%--END--%>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsCommentesETABackColor").ToString() %>'>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:TextBox ID="txtFitsCommentesUplaodETADate" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCommentesETABackColor"))%>'
                                        onchange="javascript:return UpdateCuttingSheetDateForMO(this,'FitsUploadCommentes');"
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCommentesETAForeColor"))%>'
                                        Width="70" Style="font-size: 8px !important; text-transform: capitalize !important;"
                                        runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsCommentesETADate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("FitsCommentesETADate")) == Convert.ToDateTime("1/1/0001")) ? "" : Convert.ToDateTime(Eval("FitsCommentesETADate ")).ToString("dd MMM") %>'></asp:TextBox>
                                    <%--END--%>
                                </td>
                            </tr>
                         
                            <tr>
                                <%--Added By Ashish on 12/1/2014 for define width in td--%><%-- color:#807F80 !important;--%>
                                <td id="tdSTC" runat="server" width="37%" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <asp:Label ID="lblSTCName" runat="server" Text="STC" Visible='<%# Eval("FitsStcRead")%>'></asp:Label>
                                </td>
                                <td width="33%" style="color: Black; text-align: center; padding: 0px !important;
                                    margin: 0px !important;">
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <%--Edited by abhishek on 8/1/2015--%>
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblstctgt" ToolTip="Stc Target Date" Visible='<%# Eval("FitsStcTargetDateRead")%>'
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("STCtargetsDate")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("STCtargetsDate"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--End by abhishek on 8/1/2015--%>
                                        </div>
                                        <div style="height: 10px;">
                                            <asp:Label ID="txtrequested" Visible='<%# Eval("FitsStcActualDateRead")%>' Enabled='<%# Eval("FitsStcActualDateWrite")%>'
                                                Style="width: 98%; font-size: 8px !important;" Text='<%#(Eval("ParentOrder") as iKandi.Common.Order).Fits.SealDate.ToString("dd MMM (ddd)") == "01 Jan (Mon)"? "" :(Eval("ParentOrder") as iKandi.Common.Order).Fits.SealDate.ToString("dd MMM")%>'
                                                runat="server"></asp:Label>
                                            <%--END--%>
                                        </div>
                                </td>
                                <td width="30%" style='text-align: center; <%# "background-color :" + Eval("FitsSTCETABackColor").ToString() %>'>
                                    <div>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="lblSTCETA" runat="server" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsSTCETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsSTCETAForColor"))%>'
                                            Visible='<%# Eval("FitsSTCETARead")%>' CssClass="do-not-allow-typing" Style="width: 83px;
                                            font-size: 8px; text-transform: capitalize;" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.SealDate.ToString("dd MMM (ddd)") == "01 Jan (Mon)" ? (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM") : (Eval("ParentOrder") as iKandi.Common.Order).FitsTrack.fitRequestedOn.ToString("dd MMM")%>'></asp:TextBox>
                                        <%--END--%>
                                    </div>
                                    <span id="spanstcpending" style="display: none;" runat="server"><a id="lnksrtcpending"
                                        onclick="javascript:return showEtaPopup('STCRequest','FitsETA','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','','','<%# (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM")%>','','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','','<%#Eval("OrderDetailID") %>',62);">
                                        <asp:TextBox ID="lblstcpending" Visible='<%# Eval("FitsSTCETARead")%>' Enabled='<%# Eval("FitsSTCETAWrite")%>'
                                            CssClass="do-not-allow-typing" Style="font-size: 8px !important; color: red !important;
                                            background-color: transparent;" runat="server" Width="70" Text='<%# Eval("STCpending")%>'></asp:TextBox></a>
                                    </span>
                                </td>
                            </tr>
                            <tr id="apprHide" runat="server">
                                <td id="tdPatternSample" runat="server" style="color: #807F80 !important; text-align: left;
                                    letter-spacing: -0.2px; line-height: 21px;">
                                    <asp:Label ID="lblPatternSampleName" runat="server" Text="Pattern Sample" Visible='<%# Eval("FitsPatternRead")%>'></asp:Label>
                                </td>
                                <td style="color: Black; text-align: center; width: 33%; padding: 0px !important;
                                    margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <%--Edited by abhishek on 8/1/2015--%>
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblpatterntar" Visible='<%# Eval("FitsPatternTargetDateRead")%>' ToolTip="Pattern Sample Target Date"
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleTarget")) == Convert.ToDateTime("01-01-0001")) ? "" : (Convert.ToDateTime(Eval("PatternSampleTarget"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--End by abhishek on 8/1/2015--%>
                                        </div>
                                        <asp:TextBox class="Pattern" ID="lblPatternSampleDate" Visible='<%# Eval("FitsPatternActualDateRead")%>'
                                            Enabled='<%# Eval("FitsPatternActualDateWrite")%>' onchange="javascript:return UpdatePatternSampleDateForMO(this,'Pattern');"
                                            Style="width: 98%; font-size: 8px !important; height: 10px; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="th do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("PatternSampleDate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("PatternSampleDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDate")).ToString("dd MMM") %>'></asp:TextBox>
                                        <%--END--%>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsPatternETABackColor").ToString() %>'>
                                    <div>
                                        <asp:TextBox ID="PATTERNETA" runat="server" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsPatternETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsPatternETAForColor"))%>'
                                            Visible='<%# Eval("FitsPatternETARead")%>' Style="font-size: 8px; text-transform: capitalize;"
                                            CssClass="do-not-allow-typing" Width="83" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM")%>'></asp:TextBox>
                                    </div>
                                    <span id="spanPatternpending" style="display: none;" runat="server">
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <a onclick="javascript:return showEtaPopup('PatternETA','FitsETA','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','','','<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM")%>','','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','','<%#Eval("OrderDetailID") %>',63);">
                                            <asp:TextBox ID="lblpatternpending" CssClass="do-not-allow-typing" Style="font-size: 8px !important;
                                                color: red !important; background-color: transparent;" runat="server" Width="70"
                                                Text='<%# Eval("Patternpending")%>'></asp:TextBox>
                                            <%--END--%>
                                        </a></span>
                                </td>
                            </tr>
                            <tr id="apprHide1" runat="server">
                                <%--Added By abhishek on 11/2/2016--%>
                                <td id="tdCuttingSheet" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <asp:Label ID="lblCuttingSheet" runat="server" Text="Cutting Sheet" Visible='<%# Eval("FitsCuttingkRead")%>'></asp:Label>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblcuttingtar" Visible='<%# Eval("FitsCuttingTargetDateRead")%>' ToolTip="Cutting Target Date"
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("CuttingTarget")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("CuttingTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("CuttingTarget"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <asp:TextBox ID="lblCuttingSheetDate" Visible='<%# Eval("FitsCuttingActualDateRead")%>'
                                            Enabled='<%# Eval("FitsCuttingActualDateWrite")%>' onchange="javascript:return UpdateCuttingSheetDateForMO(this,'Cutting');"
                                            Style="width: 98%; font-size: 8px !important; background-color: #F9F9FA; text-transform: capitalize !important;
                                            height: 10px;" runat="server" CssClass="th do-not-allow-typing" Text='<%# (Convert.ToDateTime(Eval("CuttingReceivedDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("CuttingReceivedDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CuttingReceivedDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsCuttingETABackColor").ToString() %>'>
                                    <asp:TextBox ID="TextBox1" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCuttingETABackColor"))%>'
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCuttingETAForColor"))%>'
                                        Width="96%" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CuttingETA');"
                                        Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                        Text='<%# (Convert.ToDateTime(Eval("CuttingReceivedDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("CuttingReceivedDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CuttingReceivedDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    <asp:Label ID="lblcutpending" Visible='<%# Eval("FitsCuttingETARead")%>' Enabled='<%# Eval("FitsCuttingETAWrite")%>'
                                        onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CuttingETA');"
                                        Style="font-size: 8px !important; display: none; color: red !important;" runat="server"
                                        Width="70" Text='<%# Eval("Cuttingpending")%>'></asp:Label>
                                </td>
                            </tr>
                            <%-- END 11/2/2016 --%>
                            <tr id="apprHide2" runat="server">
                                <td id="tdProdFile" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:Label ID="lblProdFile" runat="server" Text="Prod File" Visible='<%# Eval("FitsProdFileRead")%>'></asp:Label>
                                </td>
                                <%--END--%>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <%-- edited by abhishek on 8/1/2015--%>
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblprodtar" Visible='<%# Eval("FitsProdTargetDateRead")%>' ToolTip="Prod File Target Date"
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("ProductionFileTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ProductionFileTarget"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--end by abhishek 8/1/2015--%>
                                        </div>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="lblProductionFileDate" Visible='<%# Eval("FitsProdActualDateRead")%>'
                                            Enabled='<%# Eval("FitsProdActualDateWrite")%>' onchange="javascript:return UpdateCuttingSheetDateForMO(this,'Production');"
                                            Style="width: 98%; height: 10px; font-size: 8px !important; background-color: #F9F9FA;
                                            text-transform: capitalize !important;" runat="server" CssClass="th do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("ProductionFileDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("ProductionFileDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ProductionFileDate")).ToString("dd MMM") %>'></asp:TextBox>
                                        <%--END--%>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsProdETABackColor").ToString() %>'>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <asp:TextBox ID="TextBox2" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsProdETABackColor"))%>'
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsProdETAForColor"))%>'
                                        Width="96%" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'ProductionETA');"
                                        Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                        Text='<%# (Convert.ToDateTime(Eval("ProductionFileDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("ProductionFileDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ProductionFileDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    <%--END--%>
                                    <asp:Label ID="lblprodfilepending" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'ProductionETA');"
                                        Style="font-size: 8px !important; color: red !important; display: none;" runat="server"
                                        Width="70" Text='<%# Eval("prodfilepending")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr id="apprHide3" runat="server">
                                <td id="tdHoPPM" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <a title="HOPPM Form" target="_blank" href='/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>&FitsStyle=<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>&ClientID=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>&DeptId=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>&OrderID=<%# (Eval("OrderID"))%>&showHOPPMFORM=Yes'>
                                        <asp:Label ID="lblHOPPM" runat="server" ToolTip="HOPPM Form" Text="HO PPM" Visible='<%# Eval("FitsHOPPMRead")%>'></asp:Label>
                                    </a>
                                </td>
                                <%--END--%>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <%--Edited by abhishek on 8/1/2015--%>
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblHOPPMTarget" Visible='<%# Eval("FitsHOPPMTargetDateRead")%>' ToolTip="HO PPM Target Date"
                                                CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("HOPPMTargetETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("HOPPMTargetETA"))).ToString("dd MMM")%>'></asp:Label>
                                            <%--End by abhishek on 8/1/2015--%>
                                        </div>
                                        <asp:Label ID="lblHOPPMActual" Visible='<%# Eval("FitsHOPPMActualDateRead")%>' Enabled='<%# Eval("FitsHOPPMActualDateWrite")%>'
                                            ToolTip="HO PPM Actual Date" Style="width: 98%; height: 10px; font-size: 8px !important;
                                            background-color: #F9F9FA; text-transform: capitalize !important;" Text='<%# (Convert.ToDateTime(Eval("HOPPMActionactualDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("HOPPMActionactualDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HOPPMActionactualDate")).ToString("dd MMM") %>'
                                            runat="server"></asp:Label>
                                    </span>
                                </td>
                                <%--Added By Ashish on 12/1/2014 for span ETA--%>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsHOPPMETABackColor").ToString() %>'>
                                    <span id="spanSTCAPPETA" runat="server">
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="txtETAHOPPM" Width="96%" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsHOPPMETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsHOPPMETAForColor"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'HPPPMETA');" Style="font-size: 8px !important;
                                            text-transform: capitalize !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HOPPMETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("HOPPMETA")).ToString("dd MMM") %>'></asp:TextBox>
                                        <%--END--%>
                                    </span>
                                </td>
                            </tr>
                            <tr id="apprHide4" runat="server">
                                <td id="tdTopSent" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <%-- <a target="_blank" href='/Internal/Merchandising/QualityControl.aspx?orderDetailID=<%# Eval("OrderDetailID") %>&styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>&FitsStyle=<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>&ClientID=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>&DeptId=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>&showHOPPMFORM=Yes'>--%>
                                    <asp:Label ID="lblTopSent" runat="server" ToolTip="Assurance Form" Text="TOP Sent"
                                        Visible='<%# Eval("FitsTOPSentRead")%>'>

                                    </asp:Label>
                                    <%--  </a>--%>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <%-- <a title="CLICK TO SEE INLINE FORM" target="InlinePPMForm" href="/Internal/Production/InlinePPMEdit.aspx?styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode %>">--%>
                                    <%--Added By Ashish on 23/3/2015--%>
                                    <%--Edited by abhishek on 8/1/2015--%>
                                    <%--<asp:Label ID="Label10" Visible='<%# Eval("FitsTopSentTargetDateRead")%>' ToolTip="Top Sent Target Date"
                            Style="font-size: 8px !important; font-weight: bold;" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget) == Convert.ToDateTime("01/01/0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget.ToString("dd MMM (ddd)")%>'
                            runat="server"></asp:Label>--%>
                                    <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                        <asp:Label ID="Label10" Visible='<%# Eval("FitsTopSentTargetDateRead")%>' ToolTip="Top Sent Target Date"
                                            Style="font-size: 8px !important; font-weight: bold;" Text='<%# (Convert.ToDateTime(Eval("TOPTargetETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("TOPTargetETA"))).ToString("dd MMM")%>'
                                            runat="server"></asp:Label>
                                        <%--end by abhishek on 8/1/2015--%>
                                    </div>
                                    <div style="height: 10px;">
                                        <asp:Label ID="lblTopSendTarget" Visible='<%# Eval("FitsTopSentMActualDateRead")%>'
                                            Enabled='<%# Eval("FitsTopSentMActualDateWrite")%>' Style="width: 98%; height: 10px;
                                            font-size: 8px !important;" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == Convert.ToDateTime("01-01-0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM")%>'
                                            runat="server"></asp:Label>
                                    </div>
                                    <%--END--%>
                                    <%-- </a>--%>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("FitsTOPSentETABackColor").ToString() %>'>
                                    <div>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <asp:TextBox ID="lblTOPETA" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsTOPSentETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsTOPSentETAForColor"))%>'
                                            Visible='<%# Eval("FitsTOPSentETARead")%>' runat="server" Style="width: 83px;
                                            font-size: 8px; text-transform: capitalize;" CssClass="do-not-allow-typing" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == Convert.ToDateTime("01-01-0001")) ? (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM") : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM")%>'></asp:TextBox>
                                        <%--END--%>
                                    </div>
                                    <span visible="false" id="spantoppending" runat="server">
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <a onclick="javascript:return showEtaPopup('TOPETA','FitsETA','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','','','<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM")%>','','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','','<%#Eval("OrderDetailID") %>',64);">
                                            <asp:TextBox ID="lbltoppending" CssClass="do-not-allow-typing" Style="font-size: 8px !important;
                                                color: red !important; background-color: transparent;" runat="server" Width="70"
                                                Text='<%# Eval("TOPpending")%>'></asp:TextBox>
                                            <%--END--%>
                                        </a></span>
                                </td>
                            </tr>
                            <%--added by abhishek on 11/2/2016--%>
                            <tr id="apprHide5" runat="server">
                                <td id="tdTestReport" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px; padding: 0px !important;">
                                    <%--<asp:HyperLink ID="hlnktestupload" runat="server" Style="cursor: pointer;" Target="_blank" Text="">
                           
                           </asp:HyperLink>--%>
                                    <a rel="shadowbox;" href="MoTestReportUpload.aspx?OrderId=<%# Eval("OrderID")%>&OrderDetailsId=<%# Eval("OrderDetailID")%>"
                                        onclick='return OpenTestReport(this);' style="cursor: pointer;">
                                        <asp:Label ID="lbltextreport" runat="server" ToolTip="Test Report files" Style="color: Gray;"
                                            Text="" Visible='<%# Eval("FitsHOPPMRead")%>'></asp:Label></a>
                                    <%--<asp:HyperLink ID="hlnViewUpload" runat="server" Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif" Target="_blank"></asp:HyperLink>--%>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lbltestReportTagrgetsDates" Visible='<%# Eval("FitsHOPPMTargetDateRead")%>'
                                                ToolTip="Test Report Target Date" CssClass="date_style  do-not-allow-typing"
                                                Style="font-size: 8px; font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("01-01-0001")) ? "" : (Convert.ToDateTime(Eval("TestReportTargetETA"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <div style="height: 10px;">
                                            <asp:Label ID="lblTestReportActualDate" Visible='<%# Eval("FitsHOPPMActualDateRead")%>'
                                                Enabled='<%# Eval("TestReportWrite")%>' ToolTip="Test Report Actual Date" Style="width: 98%;
                                                font-size: 8px !important; background-color: #F9F9FA; text-transform: capitalize !important;
                                                height: 10px;" Text='<%# (Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("1/1/1900")) ? (Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("TestReportsDateActual")).ToString("dd MMM")  : Convert.ToDateTime(Eval("TestReportsDateActual")).ToString("dd MMM") %>'
                                                runat="server"></asp:Label>
                                        </div>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("TestReportsBackColor").ToString() %>'>
                                    <span id="span1" runat="server">
                                        <asp:TextBox ID="TxtETATestReport" Width="96%" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TestReportsBackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TestReportsForColor"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'TESTREPORTS');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("TestReportsDateETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("TestReportsDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                            </tr>
                            <%-- end by abhishek on 11/2/2016--%>
                            <%--added by abhishek on 11/2/2016--%>
                            <tr style='<%# "display :" + Eval("IsCdchartVisible").ToString() %>'>
                                <td id="tdcdchat" runat="server" style="color: #807F80 !important; text-align: left;
                                    line-height: 21px;">
                                    <asp:Label ID="lblcdchat" runat="server" ToolTip="CD chart" Text="Cd chart" Visible='<%# Eval("FitsHOPPMRead")%>'></asp:Label>
                                </td>
                                <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                    <span class="newtext2" style="text-align: center;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lblcdcharttargetdate" Visible='<%# Eval("FitsHOPPMTargetDateRead")%>'
                                                ToolTip="CD chart Target Date" CssClass="date_style  do-not-allow-typing" Style="font-size: 8px;
                                                font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("CdchartTargetDateETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("CdchartTargetDateETA"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <asp:TextBox ID="TxtactualDate" Visible='<%# Eval("FitsHOPPMActualDateRead")%>' Enabled='<%# Eval("CDCharWrite")%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CDChartActual');"
                                            Style="width: 98%; font-size: 8px !important; background-color: #F9F9FA !important;
                                            text-transform: capitalize !important; height: 10px;" runat="server" CssClass="th do-not-allow-typing"
                                            Text='<%# (Convert.ToDateTime(Eval("CdchartActualDateETA")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("CdchartActualDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CdchartActualDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                                <td style='color: #00E; text-align: center; <%# "background-color :" + Eval("CDChartBackColor").ToString() %>'>
                                    <span id="span2" runat="server">
                                        <asp:TextBox ID="txtcdchartETA" Width="70" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CDChartBackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CDChartForColor"))%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CDChartETA');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important;" runat="server"
                                            Text='<%# (Convert.ToDateTime(Eval("CdchartDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("CdchartDateETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("CdchartDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("CdchartDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CdchartDateETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("CdchartDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                    </span>
                                </td>
                            </tr>
                            <%--end by abhishek on 11/2/2016--%>
                        </table>
                    </div>
                    <div style="font-size: 9px; color: #0000ee; width: 100%; min-height: 30px; line-height: 13px;
                        text-align: left;">
                        <asp:Label ID="lbltechnicaldealytask" ToolTip="Technical Section Delay Task" runat="server"
                            Text='<%# Eval("TechnicalDelayTask")%>'></asp:Label>
                    </div>
                    <div style="width: 100%; float: left; text-align: center; line-height: 55px; height: 55px;
                        display: none;">
                        <a title="click to see QA Status popup" id="lnkQaStatus" class="lnkQaStatus" href="#"
                            style="font-size: 9px;" onclick="QAStatus('<%# Eval("OrderDetailID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("FitsQAStatusWrite") %>')">
                            <asp:Label ID="lblQAStatus" runat="server" Style="font-size: 8px !important; color: #807F80 !important;
                                padding-left: 4px;" Text='Please select QA Status-Code' Enabled='<%# Eval("FitsQAStatusWrite")%>'></asp:Label></a>
                    </div>
                    <div style="width: 100%; text-align: center; height: 20px; float: left; display: none;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" style="border: none !important; text-align: center;">
                                    &nbsp;<span style="text-align: center; font-size: 8px;"><asp:Label ID="lblFitsDate"
                                        Style="color: #807F80 !important; font-size: 8px;" runat="server" Visible='<%# Eval("FitsStcRead")%>'
                                        Enabled='<%# Eval("FitsStcWrite")%>'></asp:Label>
                                    </span>
                            </tr>
                        </table>
                    </div>
                    <div style="padding-top: 5px; width: 100%; text-align: center; color: #0000ee; height: 30px;
                        float: left; display: none;">
                        <%--<asp:Label ID="Label3" style="color:#0000ee; font-size:9px;" runat="server" Text='Fit 2 Sent' Visible='<%# Eval("FitsTgtPlannedDateRead")%>'  Enabled='<%# Eval("FitsTgtPlannedDateWrite")%>'></asp:Label>--%>
                        <asp:Label ID="lblPlannedDate" ForeColor="#0000ee" Style="font-size: 9px;" runat="server"
                            Visible="false" Text='Fit 2 Sent 10 Sep 13 (Tue)'></asp:Label>
                        &nbsp;&nbsp;</span>
                        <%--<span>

                     <asp:Label ID="Label5" runat="server" style="color:#0000ee; font-size:9px;" Text='10 Sep 13 (Tue)' Visible='<%# Eval("FitsTgtPlannedDateRead")%>'  Enabled='<%# Eval("FitsTgtPlannedDateWrite")%>'></asp:Label>--%>
                    </div>
                    <div style="text-align: center">
                        <asp:Label ID="lblDate" runat="server" Style="color: #807f80;" CssClass="lblDateAlign"></asp:Label>
                    </div>
                    <div style="text-align: center">
                        <asp:Label ID="lblBHPlannedDate" runat="server" CssClass="lblDateAlign"></asp:Label>
                    </div>
                    <div style="text-align: center; width: 100%; float: left; display: none;">
                        <div style="width: 50%; float: left;">
                            <asp:Label ID="Label13" Style="color: #807F80 !important; font-size: 8px;" runat="server"
                                Text='Planned Date:' Visible='<%# Eval("FitsPlannedDateRead")%>' Enabled='<%# Eval("FitsPlannedDateWrite")%>'></asp:Label></div>
                        <div style="width: 50%; padding-top: 2px; float: left;">
                            <asp:TextBox ID="txtPlannedDate" CssClass="date-picker" onchange="javascript:return UpdatePlanedDate(this);"
                                Style="color: #807F80 !important; background-color: #f9f9fa !important; font-size: 8px;
                                text-transform: capitalize !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("PlanningDate")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("PlanningDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("PlanningDate")).ToString("dd MMM")%>'
                                Visible='<%# Eval("FitsPlannedDateRead")%>' Enabled='<%# Eval("FitsPlannedDateWrite")%>'></asp:TextBox></div>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblInline" runat="server" Visible="false" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget) == Convert.ToDateTime("01/01/0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget.ToString("dd MMM")%>'></asp:Label>
                    </div>
                    <div style="text-align: left; width: 100%; height: 15px; display: none;">
                        <div style="width: 50%; float: left; text-align: right;">
                            <span class="newtext7">
                                <asp:Label ID="Label8" runat="server" Style="font-size: 10px;" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopActualApproval) == Convert.ToDateTime("01/01/0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopActualApproval.ToString("dd MMM")%>'></asp:Label></span>
                        </div>
                    </div>
                    <div style="width: 100%; display: none;">
                        <div style="width: 100%; height: 15px;">
                            <div style="width: 100%; float: left; height: 60px; display: none;">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" class="newtext" style="border: none !important; text-align: left;">
                                            <div style="width: 100%; float: left;">
                                                <div class="newtext" style="width: 50%; float: left;">
                                                    <asp:Label ID="Label21" runat="server" Style="font-size: 8px !important; color: #807F80 !important;"
                                                        Text='Pattern Sample'></asp:Label></div>
                                                <div class="newtext12" style="width: 50%; float: left; text-align: right; text-transform: capitalize !important;
                                                    padding-top: 3px;">
                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;">
                                                <div class="newtext" style="width: 50%; float: left;">
                                                    <asp:Label ID="Label17" runat="server" Style="font-size: 8px !important; color: #807F80 !important;"
                                                        Text='Cutting Sheet Recvd'></asp:Label></div>
                                                <div class="newtext12" style="width: 50%; float: left; text-align: right; text-transform: capitalize !important;
                                                    padding-top: 3px;">
                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;">
                                                <div class="newtext" style="width: 50%; float: left;">
                                                    <asp:Label ID="Label19" runat="server" Style="font-size: 8px !important; color: #807F80 !important;"
                                                        Text='Production File'></asp:Label></div>
                                                <div class="newtext12" style="width: 50%; float: left; text-align: right; text-transform: capitalize !important;
                                                    padding-top: 3px;">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%--added by abhishek on 25/12/2015--%>
                    <div style="width: 100%; float: left;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <%--<tr>
                            <td style="color: Black;">
                                Test Report Upload
                                
                                <asp:HyperLink ID="hlnktestupload" runat="server" style="cursor:pointer;"  ImageUrl="../../App_Themes/ikandi/images/zoom_icon.gif" Target="_blank"></asp:HyperLink>
                                <asp:HyperLink ID="hlnViewUpload"  runat="server" style="cursor:pointer;"  ImageUrl="../../App_Themes/ikandi/images/view_icon.png" Target="_blank"></asp:HyperLink>
                                <asp:HiddenField ID="hdntestuploadId" runat="server" Value="" />
                            </td>
                            
                            
                        </tr>--%>
                            <tr>
                                <td style="width: 90%; display: none; border: none !important; text-align: left;"
                                    align="left">
                                    <asp:Label ID="lblFitsName" Style="font-size: 8px !important; color: #807F80 !important;"
                                        runat="server"></asp:Label><asp:Label ID="lblFitsRemark" Style="font-size: 8px !important;
                                            color: #807F80 !important; text-transform: capitalize !important;" runat="server"></asp:Label>
                                </td>
                                <td style="width: 5%; border: none !important; text-align: right;">
                                    <a id="lnkFitsPopUpETAfil" runat="server" style="cursor: pointer;">
                                        <img src="../../images/task-eta-icon.png" style="width: 30px" /></a> <a id="lnkFitsPopUp"
                                            runat="server" style="cursor: pointer;">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" /></a>
                                    <asp:HiddenField ID="hdnFitsRemarks" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--<div style="width:100%; margin-top:20px; float:left;">

                    <table width="100%" cellpadding="0" cellspacing="0">
                        
                        <tr>

                    <td style="width:90%; display:none;border:none !important; text-align:left;" align="left"><asp:Label ID="Label23" style="font-size:8px !important; color:#807F80 !important;" runat="server"></asp:Label><asp:Label ID="Label24" style="font-size:8px !important; color:#807F80 !important; text-transform:capitalize !important;" runat="server"></asp:Label></td>

                    

                    <td style="width:5%; border:none !important;  text-align:right; ">

                    <a id="A1" runat="server" style="cursor:pointer;"><img src="../../App_Themes/ikandi/images/zoom_icon1.gif" /></a>

                      <asp:HiddenField ID="HiddenField2" runat="server" />

                    </td>
                   
                    </tr>
                        

                    </table>

                    </div>--%>
                    <%--end by abhishek on 25/12/2015--%>
                </ItemTemplate>
                <ItemStyle Width="257px" />
                <HeaderStyle Width="257px"></HeaderStyle>
                <ItemStyle CssClass="newcss2"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="405px">
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="head-table">
                        <tr>
                            <th colspan="9" align="center">
                                <label>
                                    Production
                                </label>
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="width: 100%;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="15px" style='width: 110px; border: none !important; height: 24px; letter-spacing: -1px;
                                    text-align: left; padding: 0px !important; <%# "background-color :" + Eval("ExFactoryColor").ToString() %>'>
                                    <asp:HiddenField ID="hdnEcFactoryColor" runat="server" Value='<%# Eval("ExFactoryColor") %>' />
                                    <span id="exFactory" runat="server"><span style="font-size: 11px;">Ex Fac:
                                        <input type="text" onchange="javascript:return UpdateExFactoryForMO(this);" style="text-align: left;
                                            background-color: transparent; text-transform: capitalize; font-size: 11px !important;
                                            letter-spacing: -1px; width: 70px; font-weight: bold; vertical-align: inherit;
                                            <%# "color :" + Eval("ExFactoryForeColor").ToString() %>;" class='<%#iKandi.Web.Components.PermissionHelper.IsExfactoryWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_EXFACTORY)? "th do-not-allow-typing":"date-picker bold_text do-not-allow-typing" %>'
                                            id="exfactory<%# Container.DataItemIndex + 1 %>" name="exfactory<%# Container.DataItemIndex + 1 %>"
                                            value='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'
                                            title="Exfactory" />
                                    </span></span><span style="float: left; font-size: 11px !important; text-align: left;
                                        width: 100%;" id="divexFactory" runat="server">Ex Fac:
                                        <asp:Label ID="lblexFactory" ToolTip="Exfactory" runat="server" Style="text-align: left;
                                            background-color: transparent; text-transform: capitalize; color: black; font-size: 11px !important;
                                            width: 70px; letter-spacing: -1px; font-family: Arial;" Font-Bold="true" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                                    </span>
                                </td>
                                <td align="right" style='border: none !important; padding: 0px !important; padding-right: 2px !important;
                                    margin: 0px !important; text-align: right; <%# "background-color :" + Eval("ExFactoryColor").ToString() %>'>
                                    <a title='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'
                                        href="javascript:void(0)" onclick="GetManageOrderiKandiQtyByMode('<%# Eval("Mode")%>','<%# Eval("bModewrite") %>')"
                                        style="display: none;">
                                        <asp:Label runat="server" ID="lblMode" Style="font-size: 8px !important;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("ExFactoryForeColor")) %>'
                                            Text=' <%# Eval("ModeName")%>' Visible='<%# Eval("bModeRead") %>'></asp:Label></a>
                                    <!----------Add By prabhaker on 30 mar 18---------------->
                                    <asp:DropDownList runat="server" ID="ddlModeChange" Style="width: 90px; border: 1px solid"
                                        onchange="javascript:showModePopUp(this)">
                                    </asp:DropDownList>
                                    <asp:Label class="StyleCode" ID="lblsty" Style="display: none" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode.ToString() %>'> </asp:Label>
                                    <asp:HiddenField runat="server" ID="hdnModeId" Value='<%# Eval("Mode")%>' />
                                    <asp:HiddenField runat="server" ID="hdnModeName" Value='<%# Eval("ModeName")%>' />
                                    <asp:HiddenField runat="server" ID="hdnddlForecolor" Value='<%# Eval("ExFactoryForeColor") %>' />
                                    <asp:HiddenField runat="server" ID="hdnddlBackcolor" Value='<%# Eval("ExFactoryColor")%>' />
                                    <%-- <asp:HiddenField runat="server" ID="hdnddlVisible" Value='<%# Eval("bModeRead")%>' />--%>
                                    <!---------------End of Code------------------>
                                </td>
                                <td align="right" style="border: none !important; text-align: right; padding: 0px !important;
                                    background-color: #f9f9fa;">
                                    <asp:Label ID="lblDC" runat="server" Text="DC:" Visible='<%# Eval("bDCDateRead") %>'
                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label>
                                    <asp:TextBox ID="txtDC" CssClass='<%#iKandi.Web.Components.PermissionHelper.IsExfactoryWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_EXFACTORY)? "th do-not-allow-typing":"date-picker bold_text do-not-allow-typing" %>'
                                        Visible='<%# Eval("bDCDateRead") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                        onchange="javascript:return UpdateExFactoryForDC(this);" Style="font-size: 8px !important;
                                        font-weight: bold; width: 70px; text-transform: capitalize !important;" runat="server"
                                        Text='<%# (Convert.ToDateTime(Eval("DC")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM (ddd)")%>'></asp:TextBox>
                                    <%-- <asp:Label ID="lblDC" runat="server" Text="DC:" Visible='<%# Eval("bDCDateRead") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>' ></asp:Label>&nbsp;
                                    --%>
                                    <asp:Label ID="Label2" ToolTip="Dc Date" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                        Style="font-size: 8px !important; display: none;" runat="server" Text='<%# (Convert.ToDateTime(Eval("DC")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM (ddd)")%>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; background-color: #f9f9fa !important;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" style="border: none !important; text-align: left; background-color: #f9f9fa !important;
                                    display: none;">
                                    <asp:Label ID="lblOffer" runat="server" Text="Offer:" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                        Visible='<%#Eval("FitsPlannedDateRead") %>' Enabled='<%#Eval("FitsPlannedDateWrite") %>'></asp:Label>&nbsp;
                                    <span id="Div1" runat="server" class="shipmentdate" style="padding-top: 15px;">
                                        <asp:Label ID="txtShipmentOfferDate" ToolTip="Ex Factory Planned Date" Visible='<%#Eval("FitsPlannedDateRead") %>'
                                            Enabled='<%#Eval("FitsPlannedDateWrite") %>' size="100" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                            Style="text-align: right; width: 85px; font-size: 8px !important; text-transform: capitalize !important;
                                            background-color: transparent;" runat="server" Text='<%# (Convert.ToDateTime(Eval("PlannedEx")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("PlannedEx")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("PlannedEx")).ToString("dd MMM") %>'></asp:Label>
                                    </span>
                                </td>
                                <td style="border: none !important; text-align: left; background-color: #f9f9fa !important;
                                    font-size: 9px;" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 0PX !important;">
                                        <tr>
                                            <td style="border: 0PX !important; width: 15%; text-align: center;">
                                                <a href="javascript:void(0)" style='text-transform: capitalize !important; font-size: 9px !important;
                                                    <%# "color :" + Eval("LinktypeForeColor").ToString() %>' title="Production Matrix"
                                                    onclick="SHOW_PRODUCTION_MATRIX('<%# Eval("OrderDetailID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode.ToString() %>','<%# Eval("ProductionPlanWrite")%>')">
                                                    Plan </a>
                                            </td>
                                            <td style="border: 0PX !important; width: 25%; text-align: center;">
                                                <a href="javascript:void(0)" id="anchoeDetail_Rescan" style="text-transform: capitalize !important;
                                                    font-size: 9px !important;" title="CLICK TO SEE PRODUCTION DETAIL" runat="server">
                                                    <asp:Label runat="server" ID="lblanchoeDetail_Rescan" Text="Detail" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>'> Detail</asp:Label>
                                                </a>
                                            </td>
                                            <td style="border: 0PX !important; text-align: center; width: 15%;">
                                                <a id="hypstatusmode" runat="server" class="hide_me"></a><a href="javascript:void(0)"
                                                    style='text-transform: capitalize !important; font-size: 9px !important; <%# "color :" + Eval("LinktypeForeColor").ToString() %>'
                                                    title="CLICK TO SEE WORKFLOW HISTORY" onclick="showWorkflowHistory2('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderID") %>','<%# Eval("OrderDetailID") %>')">
                                                    History</a>
                                            </td>
                                            <%--  //Ravi 14-04-2016--%>
                                            <%--  //Gajendra 09-05-2016--%>
                                            <td style="border: 0PX !important; width: 65px; display: none;">
                                                <asp:Label ID="lblStatusMode" runat="server" Style="text-transform: capitalize !important;
                                                    font-size: 11px;" ForeColor="#0000ee" Visible="false" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).WorkflowInstanceDetail.StatusMode %>'></asp:Label>
                                            </td>
                                            <td style="border: 0PX !important; font-size: 9px; width: 30%; text-align: center;">
                                                <%--Abhishek 22/2/2016--%>
                                                <%--<a id="lnkreallocation" runat="server" href='../../Internal/Merchandising/ReAllocationForm.aspx?OrderDetailId=<%# Eval("OrderDetailID") %>&styleId=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>'  target="_blank">  <img src="../../images/reallocation.png" title="reallocation" height="20px" width="20px" style="vertical-align:middle; float:right;" /> </a>--%>
                                                <asp:HyperLink ID="lnkreallocation" ToolTip="Reallocation" Enabled="false" runat="server"
                                                    Target="_blank" Style='<%# "color :" + Eval("LinktypeForeColor").ToString() %>'
                                                    Text="Reallocation" CssClass="mo-reallocation-img"></asp:HyperLink>
                                                <%--end abhishek 22/2/2016--%>
                                                <%--ImageUrl="../../images/reallocation.png"--%>
                                            </td>
                                            <td align="right" style="border: 0PX !important; font-size: 9px; width: 20%; text-align: center;">
                                                <a href="javascript:void(0)" runat="server" id="lnkopenShipedPopoup" title="Open shiped qnty popup"
                                                    visible='<%#Eval("IsShipedRead") %>' enabled='<%#Eval("IsShipedWrite") %>'>Penalty
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: none !important; text-align: left; background-color: #f9f9fa;
                                    width: 20%;">
                                    <span style="width: 60px !important"><a href="javascript:void(0)" class="" title="CLICK TO VIEW ORDER SIZE"
                                        onclick="showSizePopup('<%# Eval("OrderDetailID") %>','<%# Eval("bQuantitywrite") %>')">
                                        <asp:Label ID="lblQuantity" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>'
                                            Style="font-weight: bold; font-size: 10px;" Visible='<%# Eval("bQuantityRead") %>'
                                            Text='<%# Eval("Quantity")%>' CssClass="number-with-commas mainQty"></asp:Label>
                                    </a>
                                        <asp:Label ID="lblpcs" runat="server" Text="Pcs." Visible='<%# Eval("bQuantityRead") %>'
                                            Enabled='<%# Eval("bQuantitywrite") %>'></asp:Label></span>
                                </td>
                                <td colspan="2" style="border: none !important; text-align: center; background-color: #f9f9fa;
                                    color: Gray;">
                                    <%--<asp:Label ID="lblExpectedDC" style="display:none;" runat="server" Text="" ForeColor="Gray"></asp:Label>--%>
                                    <asp:Label ID="lblPlanedForDate" runat="server" Style="text-transform: capitalize !important;
                                        font-size: 10px; display: none;" ForeColor="Gray" Visible="false" Text=""></asp:Label>
                                    <asp:TextBox runat="server" ID="txtPlannedForDate" onchange="javascript:ChangePlanDate(this);"
                                        Visible="false" Width="70px" Style="display: none;" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnPlanforDate" runat="server" />
                                    &nbsp;
                                    <asp:DropDownList Style="display: none;" ID="ddlMode" Visible="false" onchange="javascript:ChangeMode(this);"
                                        Width="75px" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>'>
                                        <asp:ListItem Text="Auto" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Manual" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlUnPlanned" Style="display: none;" Visible="false" Width="80px"
                                        runat="server">
                                        <asp:ListItem Text="Stitch Pending" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Unplanned" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Label ID="lblOutHouse" Visible="false" runat="server" Text="Alloc." ForeColor="black"></asp:Label>
                                    <asp:DropDownList ID="ddlOuthouse" onchange="javascript:update_OutHouse(this);" Style="float: right;
                                        position: relative; top: 3px;" Visible="false" Width="55px" runat="server">
                                        <asp:ListItem Text="N.D." Value="1"></asp:ListItem>
                                        <asp:ListItem Text="I.H." Value="2"></asp:ListItem>
                                        <asp:ListItem Text="O.H." Value="3"></asp:ListItem>
                                        <asp:ListItem Text="I.H. & O.H." Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblholdstatus" ForeColor="Black" Font-Size="10px" Style="float: right;
                                        position: relative; top: -2px;" Text="OnHold" runat="server">
                                        <asp:CheckBox ID="chkonhold" Style="position: relative; top: 3px; color: Red" CssClass="bordercolorcheckbox"
                                            Checked='<%# Eval("ContractStatus") %>' Enabled='<%#Eval("IsContractHoldWrite") %>'
                                            runat="server" ToolTip="Select current status for onhold or unhold" onclick="javascript:UpdateContractholdStatus(this);" />
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="border: none !important; text-align: left; height: 150px;
                                    background-color: #f9f9fa;">
                                    <asp:HiddenField ID="hdnQuantity" runat="server" Value='<%# Eval("Quantity")%>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdnCutReadyTotalAll" runat="server" Value=""></asp:HiddenField>
                                    <asp:HiddenField ID="hdnStitchTotalAll" runat="server" Value=""></asp:HiddenField>
                                    <asp:HiddenField ID="hdnStcApproved" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Fits.IsStcApproved%>'>
                                    </asp:HiddenField>
                                    <%--Added Production new grid by Ravi kumar--%>
                                    <asp:Repeater ID="repProduction" runat="server" OnItemDataBound="repProduction_ItemDataBound">
                                        <HeaderTemplate>
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="production-sec">
                                                <tr>
                                                    <td width="35px">
                                                        &nbsp;
                                                    </td>
                                                    <td width="30px" id="tdCutallo" runat="server" style="color: Gray">
                                                        Alloc
                                                    </td>
                                                    <td width="35px" style="color: Gray">
                                                        Cut
                                                    </td>
                                                    <td width="35px" style="color: Gray">
                                                        Cut Rdy
                                                    </td>
                                                    <td width="35px" style="color: Gray;" id="tdheadercutissue" visible="false" runat="server">
                                                        Cut Issue
                                                    </td>
                                                    <td width="30px" style="color: Gray" id="tdStitchedallco" runat="server">
                                                        Alloc
                                                    </td>
                                                    <td width="35px" style="color: Gray">
                                                        Stitched
                                                    </td>
                                                    <td width="30px" style="color: Gray" id="tdSFinshingallco" runat="server">
                                                        Alloca
                                                    </td>
                                                    <td id="tdva" runat="server" width="35px" class="VA-Hide" style="color: gray">
                                                        VA
                                                    </td>
                                                    <td width="35px" style="color: Gray">
                                                        Fin/pkd
                                                    </td>
                                                    <td id="tdRescan" runat="server" width="35px" style="color: Gray; line-height: 10px;">
                                                        Rscan Comp
                                                        <div style="border-top: 1px solid #e3dbdb;">
                                                            Pendg Rscan
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div id="dvProduction" runat="server">
                                                <table cellpadding="0" cellspacing="0" width="100%" align="center" style="font-size: 10px"
                                                    bgcolor="#fff;" border="0" class="production-sec">
                                                    <tr>
                                                        <td id="tdFacotryName" runat="server" rowspan="2" width="35px">
                                                            <asp:HiddenField ID="hdnIsvaComplete" Value='<%#Eval("IsVAComplete") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnProOrderId" Value='<%#Eval("OrderID") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnProOrderDetailId" Value='<%#Eval("OrderDetailID") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnUnitId" Value='<%#Eval("UnitId") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnfactorycount" Value='<%#Eval("IsSingleProduction") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnStitchQty_OutHouse" Value='<%#Eval("StitchQty_OutHouse") %>'
                                                                runat="server" />
                                                            <asp:HiddenField ID="hdnFinishQty_OutHouse" Value='<%#Eval("FinishQty_OutHouse") %>'
                                                                runat="server" />
                                                            <asp:HiddenField ID="hdnFinishing_InHouse" Value='<%#Eval("Finishing_InHouse") %>'
                                                                runat="server" />
                                                            <asp:Label ID="lblFactoryName" Style="color: Gray" runat="server" Text='<%# Eval("FactoryName") %>'
                                                                ToolTip='<%#Eval("FactoryCodes") %>'>
                                                            </asp:Label><br />
                                                            <asp:Label ID="lbllineno" runat="server" Style="color: Gray"></asp:Label>
                                                        </td>
                                                        <td rowspan="2" width="30px" id="tditemCutalloc" runat="server" style="font-size: 10px">
                                                            <asp:Label ID="lblCutAllocate" Style="color: Gray" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="35px" style="font-size: 10px">
                                                            <asp:TextBox ID="txtCutToday" onblur="javascript:return UpdateProductionDetail(this, 'Cutting')"
                                                                CssClass="numeric-field-without-decimal-places" MaxLength="5" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td width="35px" style="font-size: 10px">
                                                            <asp:TextBox ID="txtCutReadyToday" onblur="javascript:return UpdateProductionDetail(this, 'CutReady')"
                                                                CssClass="numeric-field-without-decimal-places" MaxLength="5" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td visible="false" width="35px" id="tdcutissue" runat="server" style="font-size: 10px;"
                                                            title='<%# Convert.ToInt32(Eval("CutIssueQtyTooltip")).ToString("N0")%>'>
                                                            <asp:Label runat="server" Text='<%#Eval("CutIssueQty") %>' Visible="false" ID="lblcutissue"></asp:Label>
                                                            <asp:TextBox ID="txtcutissue" Text='<%#Eval("CutIssueQty") %>' ReadOnly="true" onclick='<%# "cutissue(" + Eval("OrderID") +","+ Eval("OrderDetailID")+ ","+ Eval("UnitId")+ ");"%>'
                                                                MaxLength="0" runat="server"></asp:TextBox>
                                                            <%--  </a>--%>
                                                        </td>
                                                        <td rowspan="2" width="30px" id="tditemStitchingalloc" runat="server" style="font-size: 10px">
                                                            <asp:Label ID="lblStitchingAllocate" Style="color: Gray" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="35px" style="font-size: 10px">
                                                            <asp:TextBox ID="txtStitchToday" ReadOnly="true" CssClass="numeric-field-without-decimal-places"
                                                                MaxLength="5" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td rowspan="2" width="30px" id="tditemFinishAllocate" runat="server" style="font-size: 10px">
                                                            <asp:Label ID="lblFinishAllocate" Style="color: Gray" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="35px" class="VA-Hide" runat="server" id="tdvatoday" style="font-size: 10px">
                                                            <asp:TextBox ID="txtVAToday" CssClass="numeric-field-without-decimal-places" MaxLength="3"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                        <td width="35px" style="font-size: 10px">
                                                            <asp:TextBox ID="txtFinishToday" Font-Size="8px" ReadOnly="true"
                                                                CssClass="numeric-field-without-decimal-places" MaxLength="5" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td width="35px" runat="server" id="tdrescanvalue1">
                                                            <asp:Label ID="lblRescanValue1" runat="server" Style="color: Gray; font-size: 10px !important"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px">
                                                            <asp:Label ID="txtCutTotal" Font-Size="10px" CssClass="do-not-allow-typing" MaxLength="3"
                                                                runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnCutTotal" Value="0" runat="server" />
                                                        </td>
                                                        <td style="font-size: 10px">
                                                            <asp:Label ID="txtCutReadyTotal" Font-Size="10px" CssClass="do-not-allow-typing"
                                                                MaxLength="3" runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnCutReadyTotal" Value="0" runat="server" />
                                                        </td>
                                                        <td style="font-size: 10px" id="tdcutissuetotal" visible="false" runat="server">
                                                            <asp:TextBox ID="txtcutissuetotal" Style="color: Black;" Font-Size="10px" CssClass="do-not-allow-typing"
                                                                MaxLength="3" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="hdncutissuetotal" Value="0" runat="server" />
                                                        </td>
                                                        <td style="font-size: 10px">
                                                            <asp:Label ID="txtStitchTotal" Font-Size="10px" CssClass="do-not-allow-typing" MaxLength="3"
                                                                runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnStitchTotal" Value="0" runat="server" />
                                                        </td>
                                                        <td class="VA-Hide" runat="server" id="tdvaVATotal" style="font-size: 10px">
                                                            <asp:Label ID="txtVATotal" Font-Size="10px" CssClass="do-not-allow-typing" MaxLength="3"
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="font-size: 10px">
                                                            <asp:Label ID="txtFinishTotal" Font-Size="10px" CssClass="do-not-allow-typing" MaxLength="3"
                                                                runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnFinishTotal" Value="0" runat="server" />
                                                        </td>
                                                        <td width="35px" runat="server" id="tdrescanValue2">
                                                            <asp:Label ID="lblrescanValue2" runat="server" Style="color: Red; font-weight: 600;
                                                                font-size: 10px !important;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%" align="center" style="font-size: 10px"
                                                bgcolor="#fff;" border="0" class="production-sec">
                                                <tr>
                                                    <%--<asp:HiddenField ID="hdnIsShipped" Value='<%#Eval("IsShipped") %>' runat="server" />--%>
                                                    <%--abhishek 2/3/2016--%>
                                                    <td rowspan="2" width="35px">
                                                        <asp:Label ID="lblFactoryName_Footer" Style="color: gray;" Font-Size="10px" runat="server"
                                                            Font-Bold="true" Text="Total"></asp:Label>
                                                    </td>
                                                    <td rowspan="2" width="30px" id="tdcutalloca_foter" runat="server" style="font-size: 10px">
                                                        <asp:Label ID="lblCutAllocate_Footer" Style="color: black" runat="server" Font-Bold="false"
                                                            Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2" style="font-size: 10px">
                                                        <div runat="server" id="DivCuttotal" style="border-bottom: 2px solid #e6e6e6; height: 20px;
                                                            width: 100%;">
                                                            <asp:Label ID="lblCutTotal_Footer" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblCutTotal_Percent" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2" style="font-size: 10px">
                                                        <div runat="server" id="DivCutReadyTotal" style="border-bottom: 2px solid #e6e6e6;
                                                            height: 20px; width: 100%;">
                                                            <asp:Label ID="lblCutReadyTotal_Footer" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblCutReadyTotal_Percent" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" style="font-size: 10px" runat="server" visible="false" id="tdcutissuefotertotal">
                                                        <div runat="server" id="DivCutIssuetotal" style="border-bottom: 2px solid #e6e6e6;
                                                            height: 20px; width: 100%;">
                                                            <asp:Label ID="lblCutIssueFooter" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblCutIssuetotal_percent" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="30px" id="tdStitchingAllocate_foter" style="font-size: 10px" runat="server">
                                                        <asp:Label ID="lblStitchingAllocate_Footer" Font-Bold="false" Style="" runat="server"
                                                            Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2" style="font-size: 10px">
                                                        <div runat="server" id="DivStitchTotal" style="border-bottom: 2px solid #e6e6e6;
                                                            height: 20px; width: 100%; background: #FDFD96;">
                                                            <asp:Label ID="lblStitchTotal_Footer" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblStitchTotal_Percent" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <%--<asp:HiddenField ID="hdnIsSingleProduction" Value='<%#Eval("IsSingleProduction") %>' runat="server" />--%>
                                                    <td rowspan="2" width="30px" id="tdFinishAllocate_foter" runat="server" style="font-size: 10px">
                                                        <asp:Label ID="lblFinishAllocate_Footer" Font-Bold="false" Style="color: black" runat="server"
                                                            Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2" runat="server" id="tdVATotalfoter" class="VA-Hide" style="font-size: 10px">
                                                        <div runat="server" id="DivVATotal" style="border-bottom: 2px solid #e6e6e6; height: 20px;
                                                            width: 100%;">
                                                            <asp:Label runat="server" ID="lblVATotal_Footer" Font-Bold="true" Style="font-size: 10px !important;"
                                                                ForeColor="" Text="" Visible="true"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblVATotal_Percent" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2">
                                                        <div runat="server" id="DivFinishTotal" style="border-bottom: 2px solid #e6e6e6;
                                                            height: 20px; width: 100%;">
                                                            <asp:Label ID="lblFinishTotal_Footer" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblFinishTotal_Percent" runat="server" Text="" Style="font-size: 10px !important;"></asp:Label>
                                                    </td>
                                                    <td width="35px" rowspan="2" runat="server" id="tdrescanFooter">
                                                        <div runat="server" id="DivRescanFooter" style="border-bottom: 2px solid #e6e6e6;
                                                            height: 20px; width: 100%;">
                                                            <asp:Label runat="server" ID="lblOverallRecanFooter" Font-Bold="true" Style="font-size: 10px !important;"
                                                                ForeColor="" Text="" Visible="true"></asp:Label>
                                                        </div>
                                                        <asp:Label ID="lblPendingRescanFooter" runat="server" Text="" Style="color: Red;
                                                            font-weight: 600; font-size: 10px !important;"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--Added QC Form Link by Gajendra 01-06-2016--%>
                    <div style='text-align: left;'>
                        <div style="float: left; width: 50%;">
                            <asp:HyperLink ID="hlnkQaPrevStatus" ToolTip="" runat="server" Target="_blank" Style="text-transform: capitalize !important;
                                font-size: 9px !important; padding: 2px !important; color: Gray;" Text='<%# Eval("QualityControl_Prev_Status")%>'
                                CssClass=""></asp:HyperLink>
                            <a href='/Internal/Merchandising/QC.aspx?OrderId=<%# Eval("OrderID")%>&OrderDetailID=<%# Eval("OrderDetailID") %>&InspectionIDMO=<%# Eval("InspectionID") %>'
                                style='text-transform: capitalize !important; font-size: 9px !important; padding: 2px !important;
                                <%# "color :" + Eval("LinktypeForeColor").ToString() %>' target="_blank" title="Quality Assurance Form">
                                <asp:Label ID="lblInspection" Visible="false" runat="server" Text='<%# Eval("QCNarration")%>'></asp:Label>
                            </a>
                        </div>
                        <div id="dvQCFileUpload" runat="server" style="float: right; width: 50%; text-align: right;">
                            <a rel="shadowbox;" href="../Delivery/frmQcUploadDocs.aspx?OrderId=<%# Eval("OrderID")%>&OrderDetailsId=<%# Eval("OrderDetailID")%>"
                                onclick='return UploadQcDocs(this);' style="cursor: pointer;">
                                <asp:Label runat="server" ID="lblQAReportFile"></asp:Label>
                            </a>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <%--Ended by Gajendra 01-06-2016--%>
                    <%--added by abhishek 8/8/2016--%>
                    <div style="width: 100%; height: 15px;">
                        <div style="width: 35%; height: 15px; float: left;" id="maindivmda" runat="server">
                            <asp:HiddenField ID="hdnmda" runat="server" Value='<%# Eval("MDANumber") %>' />
                            <div style="width: 60%; height: 15px; float: left; text-align: left;" id="spnmdano"
                                title="MDA" runat="server">
                                <input id="mda<%# Container.DataItemIndex + 1 %>" onblur="javascript:return UpdateMDAForMO(this);"
                                    size="14px" style='font-size: 8px !important; text-align: left; border: 1px solid #d6d7d8;
                                    color: #000; width: 82%; <%# "color :" + Eval("BlackToForeColor").ToString() %>'
                                    name="mda<%# Container.DataItemIndex + 1 %>" value="<%# Eval("MDANumber") %>"
                                    class='<%#((Eval("ParentOrder") as iKandi.Common.Order).Style.client.IsMDARequired == 0 ) ? "hide_me":"" %>' />&nbsp;&nbsp;
                            </div>
                            <div style="width: 40%; line-height: 15px; height: 15px; float: left; text-align: left;"
                                id="Div2" title="MDA" runat="server">
                                <asp:Label ID="bllmda" ToolTip="mda" Font-Size="8px" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                    runat="server" Text='<%# Eval("MDANumber") %>'></asp:Label>
                            </div>
                            <div style="clear: both">
                            </div>
                            <br />
                            <%--abhishek set visibility:collapse boz now there is no use of lblErrorShipment--%>
                            <asp:Label ID="lblErrorShipment" Style="color: black; visibility: collapse; font-size: 8px;
                                background-color: transparent;" runat="server"></asp:Label>
                        </div>
                        <!-----------------changes-22-dec----------->
                        <div id="divFooter" visible="false" runat="server" style="width: 48%; line-height: 24px;
                            height: 24px; float: right; text-align: right; margin-right: 10px;">
                            <span>
                                <%--<div class="newtext7" style="width:22%; float:left; text-align:center;"><asp:Label ID="LabelFooter16" ToolTip="LK mins" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' style="font-size:8px !important; font-weight:bold;" Text='<%#Eval("Avalmin") %>'></asp:Label> <span style="font-size:8px !important; color:#807F80 !important; text-transform:lowercase !important;"><asp:Label ID="LabelFooter9" runat="server" Text="LKM"></asp:Label></span></div>--%>
                                <div class="newtext7" style="float: left; text-align: center;">
                                    <%--<asp:Label ID="lblFooterLines" ToolTip="Line(s)" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' style="font-size:8px !important; font-weight:bold;" Text='<%#Eval("LineCount") %>'></asp:Label> --%>
                                    <span style="font-size: 8px !important; color: #807F80 !important; text-transform: lowercase !important;">
                                        <%--<asp:Label ID="LabelFooter1" runat="server" Text="Line"></asp:Label>--%>
                                    </span>
                                </div>
                            </span>
                            <%--<asp:Label ID="lblst" runat="server" Text="From" style="color:gray"></asp:Label> <asp:Label ID="lblstdate" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' runat="server" Text='<%# (Convert.ToDateTime(Eval("LinePlannigStartDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("LinePlannigStartDate")).ToString("dd MMM yy")%>'> </asp:Label>  <span>
                         <asp:Label ID="lblEnd" runat="server" Text="to" style="color:gray"></asp:Label> </span> <asp:Label ID="lblenddate" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("LinktypeForeColor")) %>' runat="server" Text='<%# (Convert.ToDateTime(Eval("LinePlanningEndDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("LinePlanningEndDate")).ToString("dd MMM yy")%>'> </asp:Label>--%>
                        </div>
                        <!---------------end------------------------------>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div style="width: 100%; vertical-align: top;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr style="display: none;">
                                <td colspan="3" style="border: none !important;">
                                    <asp:Label ID="lblCMTAct" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblCMTActRead") %>'></asp:Label>
                                    <asp:Label ID="lblCMTTgt" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblCMTTgtRead") %>' />
                                    <asp:Label ID="lblCosted" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblCostedRead") %>' />
                                    <asp:Label ID="lblProfitLoss" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblProfitLossRead") %>' />
                                    <asp:Label ID="lblActualEff" Style="color: Gray" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="lblTargetEff" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblTargetEffRead") %>' />
                                    <asp:Label ID="lblBE" Style="color: Gray" runat="server" Text="" Visible='<%#Eval("PlblBERead") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="border: none !important; padding: 0px !important;">
                                    <div style="width: 100%">
                                        <div style="float: left; width: 68%;">
                                            <asp:Label ID="lblShipped" Style="font-size: 8px !important; color: #807F80 !important;"
                                                Visible='<%#Eval("IsShipedRead") %>' Width="120px" Enabled='<%#Eval("IsShipedWrite") %>'
                                                runat="server" Text="" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label>
                                        </div>
                                        <%--//Gajendra 24-12-2015  <div style="float:left; width:31%; height:15px;"> 
                      <asp:TextBox ID="txtISShippedDate" runat="server" Width="80px" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>' style="background-color:#F9F9FA; font-size:8px; text-transform:capitalize; background:none; border:1px solid #d6d7d8; color:#000;  margin-right:5px;" CssClass="date-picker" Text='<%# (Convert.ToDateTime(Eval("IsShipedDate")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("IsShipedDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("IsShipedDate")).ToString("dd m y") %>' Visible='<%#Eval("IsShipedRead") %>' Enabled='<%#Eval("IsShipedWrite") %>'></asp:TextBox>
               
                     </div>--%>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: none !important;">
                                    <table cellpadding="0" cellspacing="0" style="border: none !important; vertical-align: top;">
                                        <tr>
                                            <td style="border: none !important; text-align: left; height: 15px; vertical-align: top;">
                                                <asp:CheckBox ID="chkshipped" Font-Size="8px" onclick="javascript:return CheckShipped(this);"
                                                    Checked='<%#Eval("IsShiped") %>' Visible='<%#Eval("IsShipedRead") %>' Enabled='<%#Eval("IsShipedWrite") %>'
                                                    runat="server" />
                                            </td>
                                            <td style="text-align: left; border: none !important; height: 20px; padding-bottom: 5px;
                                                vertical-align: top;">
                                                <asp:Label ID="lblShippedCaption" Width="270px" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'
                                                    Style="background-color: #F9F9FA; font-size: 7px; text-transform: capitalize;"
                                                    Text="" Visible='<%#Eval("IsShipedRead") %>' Enabled='<%#Eval("IsShipedWrite") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnProductionRemark" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="border: none !important;">
                                                <asp:HyperLink ID="viewolay1" Visible="false" ToolTip="VIEW Packing List" runat="server"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                <asp:HyperLink ID="hypPackingName" runat="server" Visible="false" Style="border: 1px solid gray;
                                                    padding: 5px;">
                                                    <asp:Label ID="lblPackingName" Visible="false" runat="server" Font-Size="9px"></asp:Label></asp:HyperLink>
                                                &nbsp; &nbsp;
                                                <asp:HyperLink ID="hypShipmentNo" Visible="false" runat="server" Style="border: 1px solid gray;
                                                    padding: 5px;">
                                                    <asp:Label ID="lblConsolidated" ToolTip="Shipment No." runat="server" Font-Size="9px"
                                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label></asp:HyperLink>
                                                <asp:HyperLink ID="viewInvoice" Visible="false" ToolTip="VIEW Invoice List" runat="server"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                <asp:HyperLink ID="hypInvoice" Visible="false" runat="server" Style="border: 1px solid gray;
                                                    padding: 5px;">
                                                    <asp:Label ID="lblInvoice" ToolTip="Invoice No." runat="server" Font-Size="9px" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label></asp:HyperLink>
                                                <asp:HyperLink ID="hypBankRefNo" Visible="false" runat="server" Style="border: 1px solid gray;
                                                    padding: 5px;">
                                                    <asp:Label ID="lblBankRefNo" runat="server" ToolTip="Bank Reference No." Font-Size="9px"
                                                        ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblPendingPayment" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label>
                                                <asp:Label ID="lblPaymentDueDate" Visible="false" ToolTip="Payment Due Date" runat="server"
                                                    Text='<%# (Convert.ToDateTime(Eval("PaymentDueDate")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("PaymentDueDate"))).ToString("dd MMM")%>'
                                                    Font-Size="9px" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("BlackToForeColor")) %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <%--End Added By Ravi on 5/4/2015--%>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnStitchingDetailID" runat="server" Value='<%#Eval("StitchingDetailID") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnPcsPackedToday" runat="server" Value='<%#Eval("PcsPackedToday") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnOverallPcsPacked" runat="server" Value='<%#Eval("OverallPcsPacked") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnOverallPcsStitched" runat="server" Value='<%#Eval("OverallPcsStitched") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnTotalPcsStitchedToday" runat="server" Value='<%#Eval("TotalPcsStitchedToday") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnExpectedFinishDate" runat="server" Value='<%#Eval("ExpectedFinishDate") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnIsStitchingComplete" runat="server" Value='<%#Eval("IsStitchingComplete") %>'>
                        </asp:HiddenField>
                    </div>
                    <div style="font-size: 9px; color: #0000ee; width: 100%; padding-top: 5px; text-align: left;">
                        <asp:Label ID="lblproductiondealytask" ToolTip="Production Section Delay Task" runat="server"
                            Text='<%# Eval("ProductionDelayTask")%>'></asp:Label>
                    </div>
                    <div style="float: right; width: 30px; text-align: right; margin-top: 10px; display: none;">
                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px;">
                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                    </div>
                </ItemTemplate>
                <HeaderStyle Width="370px"></HeaderStyle>
                <ItemStyle Width="370px"></ItemStyle>
                <ItemStyle CssClass="newcss2"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                Visible="false">
                <ItemTemplate>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                <ItemStyle CssClass="vertical_text"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="persist-header" />
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <%--Gajendra Paging--%>
    <%--   <br />--%>
    <%--        <asp:Repeater ID="rptPager" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>--%>
    <asp:DataList CellPadding="5" RepeatDirection="Horizontal" runat="server" ID="dlPager"
        OnItemCommand="dlPager_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton Enabled='<%#Eval("Enabled") %>' runat="server" ID="lnkPageNo" Text='<%#Eval("Text") %>'
                CommandArgument='<%#Eval("Value") %>' CommandName="PageNo"></asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
    <%--     <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;

        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"

        runat="server" />--%>
    <asp:ObjectDataSource ID="odsBasicInfo" runat="server" SelectMethod="GetOrdersBasicInfo"
        TypeName="iKandi.BLL.OrderController"></asp:ObjectDataSource>
    <div id="links" class="hide_me">
        <div class="form_heading">
            Links</div>
        <%--  <a href="/Internal/Sales/OrderLimitations.aspx" class="hyp" target="_blank">Order Limitations
            Form</a><br />--%>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="style-remove-border">
            <tr>
                <td colspan="3">
                    <a href="/Internal/OrderProcessing/OrderProcessFlow.aspx" class="hyp" target="_blank">
                        Risk Analysis</a>
                </td>
            </tr>
            <tr style="display: none;">
                <td colspan="3">
                    <a href="javascript:void();" onclick="Call()">Style Details</a>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <a href="../../Internal/OrderProcessing/PoFileUploads.aspx" class="hyp" rel="shadowbox;"
                        onclick='return OpenPOfileUpload(this);'>PO Upload</a>&nbsp; &nbsp; <span id="first-tab">
                            <asp:HyperLink ID="POView1" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                                ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink></span>
                    &nbsp; &nbsp; <span id="second-tab">
                        <asp:HyperLink ID="POView2" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                            ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink></span>
                            &nbsp; &nbsp; <span id="Third-tab">
                        <asp:HyperLink ID="POView3" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                            ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink></span>
                </td>
            </tr>
            <tr style="display: none">
                <td rowspan="2">
                    PO Upload
                </td>
                <td>
                    <asp:FileUpload ID="POUpload1" Width="90px" runat="server" />
                </td>
                <td width="20px">
                    <%-- <asp:HyperLink ID="HyperLink1" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                        ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink>--%>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    <asp:FileUpload ID="POUpload2" Width="90px" runat="server" />
                </td>
                <td>
                    <%-- <asp:HyperLink ID="POView2" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                        ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink>--%>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    <asp:FileUpload ID="POUpload3" Width="90px" runat="server" />
                </td>
                <td>
                    <%-- <asp:HyperLink ID="POView2" ToolTip="VIEW PO Upload" runat="server" Target="_blank"
                        ImageUrl="~/App_Themes/ikandi/images/viewIcon.gif" Text=""></asp:HyperLink>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <input id="htmlbtnUpload" style="display: none;" class="uploadsubmit submit" type="button"
                        value="Submit" />
                    <asp:Button ID="btnback" runat="server" CssClass="btnback button-sumit submit" Style="display: none;"
                        Text="Submit" OnClick="btnback_Click" />
                    <asp:HiddenField ID="hdnUploadPOid" Value="" runat="server" />
                </td>
            </tr>
        </table>
        <a href="../../Admin/StyleCodeDetails.aspx" class="hyp stylecode" style="display: none;">
            Style Details</a>
    </div>
</div>
<div style="clear: both">
</div>
<script type="text/javascript">

    function Call() {
        htmlstylecode == $('.stylecode').html();
        //alert(htmlstylecode);      
        $.facebox(htmlstylecode);

    }

</script>
