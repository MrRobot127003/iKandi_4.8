<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StyleSpecificSupplierQuotation.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.StyleSpecificSupplierQuotation" %>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script src="../../CommonJquery/Js/form.js" type="text/javascript"></script>
<style type="text/css">
    .modal
    {
        /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }
    
    /* Modal Content */
    .modal-content
    {
        background-color: White;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
        height: 50%;
    }
    
    /* The Close Button */
    .close
    {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }
    
    .close:hover, .close:focus
    {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }
    .Popuphide
    {
        display: none;
    }
    .Popupshow
    {
        display: block !important;
    }
    .Usertable table th
    {
        position: inherit !important;
    }
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: arial !important;
    }
    
    
    .textLeft
    {
        text-align: left !important;
        padding-left: 2px;
    }
    .per
    {
        color: blue;
    }
    
    .gray
    {
        color: gray;
    }
    
    h2 .row-fir th
    {
        font-weight: bold;
        font-size: 11px;
    }
    
    /* table td table td
    {
        border-color: #ddd;
        height: 21px;
    }*/
    
    .SUPPLY-MANA td input
    {
        width: 35%;
    }
    
    .imageField
    {
        background-image: url(submit.jpg);
        height: 28px;
        width: 105px;
    }
    
    .pad
    {
        text-align: left;
        padding-left: 25px;
    }
    
    .ths
    {
        background: #3b5998;
        font-weight: normal;
        color: #fff;
        font-family: arial;
        font-size: 10px;
        padding: 5px 0px;
        text-align: center;
        text-transform: capitalize;
    }
    
    .backcolorstages
    {
        background: #fdfd96e0;
    }
    
    .Normaltextbox
    {
        border-color: White;
        width: 27% !important;
        border: 1px solid #999 !important;
        border-radius: 2px;
        height: 13px;
        color: Blue;
        font-size: 10px;
        text-align: center;
    }
    
    .float_left
    {
        float: left;
        padding-left: 3px;
    }
    
    .float_right
    {
        padding-right: 3px;
    }
    
    .color_black
    {
        color: #2f2d2d;
    }
    
    
    /* Change background on mouse-over */
    
    .navbar a:hover
    {
        background: #ddd;
        color: black;
    }
    
    .searchtxt
    {
        height: 17px;
        width: 27.8%;
        border-radius: 2px;
        padding-left: 2px;
    }
    
    /* Style the buttons inside the tab */
    
    .tab a
    {
        background-color: inherit;
        border: none;
        outline: none;
        cursor: pointer; /* padding: 14px 16px; */
        transition: 0.3s;
        font-size: 13px;
        border: 1px solid #999;
        width: 72px; /*display: inline-block;*/
        text-align: center;
        border-top-right-radius: 3px;
        border-top-left-radius: 3px;
        margin-right: 2px;
        font-family: arial !important;
        padding: 3px 2px;
        border-bottom: 0px;
        float: left;
    }
    
    table .HeaderClass2 td
    {
        position: sticky;
        background-color: #dddfe4;
        border: 1px solid #999;
        border-bottom: 0px;
        position: -webkit-sticky;
        position: sticky;
        font-size: 10px;
        text-align: center;
        font-weight: 500;
        height: 21px;
        color: #575759;
        top: 149px;
        font-family: arial;
        display: none;
    }
    table .HeaderClass3 td
    {
        position: sticky;
        background-color: #dddfe4;
        border: 1px solid #999;
        position: -webkit-sticky;
        position: sticky;
        font-size: 10px;
        text-align: center;
        font-weight: 500;
        height: 21px;
        color: #575759;
        top: 149px;
        font-family: arial;
        border-right: 0px;
    }
    table .HeaderClass3 td:last-child
    {
        border-right: 1px solid #999;
    }
    /* Change background color of buttons on hover */
    
    .tab a:hover
    {
        background-color: #ddd;
    }
    .ImgCenter
    {
        position: relative;
        left: 50%;
    }
    
    /* Create an active/current tablink class */
    
    .tab a.active
    {
        background-color: #ccc;
    }
    
    a
    {
        text-decoration: none;
    }
    /* Style the tab content */
    
    .tabcontent
    {
        display: none;
        padding: 6px 12px;
        border: 1px solid #ccc;
        border-top: none;
    }
    
    .activeback
    {
        background: green !important;
        color: #fff;
    }
    
    .navbar tab
    {
        border: 1px solid #fff;
    }
    
    .maincontentcontainer
    {
        width: 1100px;
        margin: 0px 0px 0px 14px;
    }
    
    .decoratedErrorField
    {
        width: 27% !important;
        border: 2px solid red !important;
    }
    
    .UsernameColor
    {
        font-weight: 600;
    }
    
    td.border_bottom_rowspan
    {
        border-bottom-color: #999 !important;
    }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 3px;
        background: #fff;
    }
    .PoNoUnit
    {
        width: 150px;
        padding: 0px 0px;
    }
    .ColWidthOne
    {
        min-width: 45px;
        max-width: 45px;
        padding: 0px 0px;
    }
    .ColWidthTwo
    {
        min-width: 55px;
        max-width: 55px;
        padding: 0px 0px;
    }
    .InputMargin
    {
        margin: 0px 2px;
    }
    .PoNoUnitStyle
    {
        width: 174px;
    }
    td.minUnitWidth
    {
        min-width: 60px !important;
    }
    @media screen and (max-width: 1366px)
    {
        .textright
        {
            width: 958px !important;
        }
    }
    
    
    .container
    {
        width: 200px;
        height: 200px;
        border: 1px solid #d4d4d4;
        background: #fff;
        border-radius: 3px;
        text-align: center;
        position: relative;
    }
    .container:hover .text
    {
        opacity: 0;
    }
    .container:hover .img
    {
        opacity: 1;
    }
    .text
    {
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
        text-align: center;
        left: 0;
        right: 0;
        opacity: 1;
        transition: opacity .3s linear;
    }
    .img
    {
        transition: opacity .3s linear;
        top: 0;
        bottom: 0;
        position: absolute;
        opacity: 0;
    }
    .border_last_bottom_color
    {
        border-bottom: #999 !important;
    }
    #preview
    {
        /* position: absolute;*/
        position: fixed;
        border: 3px solid #ccc;
        background: #333;
        padding: 5px;
        display: none;
        color: #fff;
        box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
    }
    .PurchaseOrder
    {
        width: 950px !important;
    }
    .lineheight
    {
        line-height: 16px;
    }
</style>
<script src="../../CommonJquery/Js/form.js" type="text/javascript"></script>
<script src="../../CommonJquery/Js/jquery-1.9.0.min.js" type="text/javascript"></script>
<script type="text/javascript">

    function ShowImagePreview() {
        
        xOffset = 200;
        yOffset = 0;
        $(".preview").hover(function (e) {
            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.id + "' alt='Image preview' style='height:350px !important; width:320px !important;'/>" + c + "</p>");
            $("#preview").css("top", "30%").css("left", "27%").fadeIn("slow");
        },

        function () {
            this.title = this.t;
            $("#preview").remove();
        });

        $("td.preview .preview").mousemove(function (e) {
            $("#preview").css("top", "50%").css("left", "50%");
        });
    };


    function ClosePopupStylespc() {

        
        $("#<%=divmModelPopupForStyleSpecific.ClientID %>").removeClass('Popupshow');





    }
    function validateFloatKeyPress(el, evt) {
        
        var charCode = (evt.which) ? evt.which : event.keyCode;
        var number = el.value.split('.');
        if (number[0] == "") {
            el.value = "0" + el.value;
        }
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        //just one dot
        if (number.length > 1 && charCode == 46) {
            return false;
        }
        //get the carat position
        var caratPos = getSelectionStart(el);
        var dotPos = el.value.indexOf(".");
        if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
            return false;
        }
        return true;
    }

    //thanks: http://javascript.nwbox.com/cursor_position/
    function getSelectionStart(o) {
        if (o.createTextRange) {
            var r = document.selection.createRange().duplicate()
            r.moveEnd('character', o.value.length)
            if (r.text == '') return o.value.length
            return o.value.lastIndexOf(r.text)
        } else return o.selectionStart
    }
    $(document).ready(function () { $("input").attr("autocomplete", "off"); });
    var urls = "../../Webservices/iKandiService.asmx";
    //    $(document).on("input", ".numeric", function () {
    //        this.value = this.value.replace(/\D/g, '');
    //    });
    $(function () {

        //$(".tab1Embe").addClass('activeback');
        //$("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").show();

    });
    function isNumberKeyNumric(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode
        return !(charCode > 31 && (charCode < 48 || charCode > 57));
    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }





    function UpdatePendingOrderEmbellishmentVA(elem) {
        

        var Idsn = elem.id.split("_");
        Selectedval = elem.value;

        txtquotedval = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval").val();

        $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();

        txtdays = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays").val();



        fabricdetails = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();
        styleid = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnstyleid").val();
        VAID = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnSupplyTypeId").val();
        stage1 = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnstage1").val();
        stage2 = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnstage2").val();
        stage3 = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnstage3").val();
        stage4 = $("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_hdnstage4").val();

        var DeliveryType = $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr_" + Idsn[2] + "_DeliveryType").val();


        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');

                return;
            }
            else {
                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');

                return;
            }
            else {

                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdEmbeEmbr.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/UpdateQuatationEmbellishmentVA",
            data: "{ flag:'" + 'UPDATEQUOTE' + "', QualityID:'" + fabQtyID + "', VAID:'" + VAID + "',QuotedLandedRate:'" + txtquotedval + "', SuppliermasterID:'" + SupplierMasterID + "', fabricdetails:'" + fabricdetails + "', Styleid:'" + styleid + "', stage1:'" + stage1 + "', stage2:'" + stage2 + "',stage3:'" + stage3 + "', stage4:'" + stage4 + "', DeliveryType:'" + DeliveryType + "'}",

            dataType: 'JSON',
            success: OnSuccessCall,
            error: OnErrorCall
        });
        return false;
        function OnSuccessCall(response) {
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }


    }


    function RestrictSpaceSpecial(e) {
        var regex = new RegExp("[0123456789.]");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }

    function UpdatePendingOrderDayedVA(elem) {
        
        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        txtdays = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        fabricdetails = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();
        styleid = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnstyleid").val();
        stage1 = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnstage1").val();
        stage2 = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnstage2").val();
        stage3 = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnstage3").val();
        stage4 = $("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_hdnstage4").val();

        var DeliveryType = $("#StyleSpecificSupplierQuotation1_grddayedstyle_" + Idsn[2] + "_DeliveryType").val();

        VAID = -1;

        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {


            if (txtdays < 1) {
                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');

                return;
            }
            else {
                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');

                return;
            }
            else {

                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grddayedstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/UpdateQuatationDayedVA",
            data: "{ flag:'" + 'UPDATEQUOTE' + "', QualityID:'" + fabQtyID + "', VAID:'" + VAID + "',QuotedLandedRate:'" + txtquotedval + "',SuppliermasterID:'" + SupplierMasterID + "', fabricdetails:'" + fabricdetails + "', Styleid:'" + styleid + "', DeliveryType:'" + DeliveryType + "'}",
            dataType: 'JSON',
            success: OnSuccessCall,
            error: OnErrorCall
        });
        return false;

        function OnSuccessCall(response) {
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
    function UpdatePendingOrderPrintVA(elem) {
        

        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        txtdays = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        fabricdetails = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();
        styleid = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnstyleid").val();
        stage1 = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnstage1").val();
        stage2 = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnstage2").val();
        stage3 = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnstage3").val();
        stage4 = $("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_hdnstage4").val();

        var DeliveryType = $("#StyleSpecificSupplierQuotation1_grdprintstyle_" + Idsn[2] + "_DeliveryType").val();

        VAID = -1;

        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {
            if (txtdays < 1) {
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                return;
            }
            else {
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                return;
            }
            else {
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdprintstyle.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }


        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/UpdateQuatationPrintVA",
            data: "{ flag:'" + 'UPDATEQUOTE' + "', QualityID:'" + fabQtyID + "', VAID:'" + VAID + "',QuotedLandedRate:'" + txtquotedval + "', SuppliermasterID:'" + SupplierMasterID + "', fabricdetails:'" + fabricdetails + "',Styleid:'" + styleid + "', stage1:'" + stage1 + "', stage2:'" + stage2 + "',stage3:'" + stage3 + "', stage4:'" + stage4 + "', DeliveryType:'" + DeliveryType + "'}",
            dataType: 'JSON',
            success: OnSuccessCall,
            error: OnErrorCall
        });

        return false;

        function OnSuccessCall(response) {
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }

    $(document).ready(function () {


        
        ShowImagePreview();
        //code added by bharat on 13-May-20
        var FabmaxRow = 0;
        var FabrowSpan = 0;
        $('.FabGrdGriegeTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > FabmaxRow) {
                FabmaxRow = row;
                FabrowSpan = 0;
            }
            if ($(this).attr('rowspan') > FabrowSpan) FabrowSpan = $(this).attr('rowspan');
        });
        if (FabmaxRow == $('.FabGrdGriegeTable tr:last td').parent().parent().children().index($('.FabGrdGriegeTable tr:last td').parent()) - (FabrowSpan - 1)) {
            $('.FabGrdGriegeTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == FabmaxRow && $(this).attr('rowspan') == FabrowSpan) $(this).addClass('border_last_bottom_color');
            });
        }


        //stylyeSpeBorderHi();
        //End
    });
    function pageLoad() {
        $.ajaxSetup({ cache: false })
        ShowImagePreview();
        var _selectedtab = '<%=this.Currentatab %>';

        //alert(_selectedtab);
        if (_selectedtab == "") {
            $("#FabricQuotationForm1_grdgsm").show();
            $(".tab1greige").addClass('activeback');
            $(".tab1Dayed").removeClass('activeback');
        }
        else if (_selectedtab == "FabricStyle") {
            $("#StyleSpecificSupplierQuotation1_grdGriegeDyed").show();
            $(".tab1Dayed").addClass('activeback');
        }

    }
    $(document).ready(function () {
        $.ajaxSetup({ cache: false })
        $(".tab1").click(function () {
            $(this).addClass('activeback').siblings().removeClass('activeback');

        });
        
        var _selectedtab = '<%=this.Currentatab %>';

        //alert(_selectedtab);
        if (_selectedtab == "") {
            $("#FabricQuotationForm1_grdgsm").show();
            $(".tab1greige").addClass('activeback');
            $(".tab1Dayed").removeClass('activeback');
        }
        else if (_selectedtab == "FabricStyle") {
            $("#StyleSpecificSupplierQuotation1_grdGriegeDyed").show();
            $(".tab1Dayed").addClass('activeback');
        }



        var $this = $(this);
        if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
            event.preventDefault();
        }

        var text = $(this).val();
        if ((event.which == 46) && (text.indexOf('.') == -1)) {
            setTimeout(function () {
                if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                    $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                }
            }, 1);
        }

        if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
            event.preventDefault();
        }

        $('.number').bind("paste", function (e) {
            var text = e.originalEvent.clipboardData.getData('Text');
            if ($.isNumeric(text)) {
                if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                    e.preventDefault();
                    $(this).val(text.substring(0, text.indexOf('.') + 3));
                }
            }
            else {
                e.preventDefault();
            }
        });
    });

    //    function ShowHideSuppliergrd(type) {
    //        
    //        //        $("#FabricQuotationForm1_hdntabvalue").val(type)
    //        //        if (type == 'PRINT') {

    //        //            $(".tab1Print").addClass('activeback');
    //        //            $(".tab1Dayed").removeClass('activeback');
    //        //            $(".tab1greige").removeClass('activeback');
    //        //            $(".tab1finished").removeClass('activeback');
    //        //            $(".tab1Embe").removeClass('activeback');
    //        //            $(".tab1OtherVA").removeClass('activeback');
    //        //            $("#StyleSpecificSupplierQuotation1_grdprintstyle").show();
    //        //            $("#StyleSpecificSupplierQuotation1_grdnormalva").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grddayedstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdfinishing").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdgsm").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdstylebasedOtherVA").hide();
    //        //            stylyeSpeBorderHi();
    //        //        }
    //        //        else if (type == 'VA') {

    //        //            $(".tab1OtherVA").addClass('activeback');
    //        //            $(".tab1finished").removeClass('activeback');
    //        //            $(".tab1Print").removeClass('activeback');
    //        //            $(".tab1Dayed").removeClass('activeback');
    //        //            $(".tab1greige").removeClass('activeback');
    //        //            $(".tab1Embe").removeClass('activeback');

    //        //            $("#StyleSpecificSupplierQuotation1_grdstylebasedOtherVA").show();
    //        //            $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").hide();

    //        //            $("#StyleSpecificSupplierQuotation1_grdfinishing").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdgsm").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grddayedstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdprintstyle").hide();
    //        //            stylyeSpeBorderHi();
    //        //        }
    //        //        else if (type == 'GRIEGEDYED') {
    //        //            $("#StyleSpecificSupplierQuotation1_grddayedstyle").show();
    //        //            $(".tab1Dayed").addClass('activeback');

    //        //            $(".tab1OtherVA").removeClass('activeback');
    //        //            $(".tab1greige").removeClass('activeback');
    //        //            $(".tab1Print").removeClass('activeback');
    //        //            $(".tab1finished").removeClass('activeback');
    //        //            $(".tab1Embe").removeClass('activeback');

    //        //            $("#StyleSpecificSupplierQuotation1_grdstylebasedOtherVA").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdnormalva").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdfinishing").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdgsm").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdprintstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").hide();
    //        //            stylyeSpeBorderHi();
    //        //        }
    //        //        else if (type == 'Embe') {

    //        //            $(".tab1Embe").addClass('activeback');
    //        //            $(".tab1finished").removeClass('activeback');
    //        //            $(".tab1Print").removeClass('activeback');
    //        //            $(".tab1Dayed").removeClass('activeback');
    //        //            $(".tab1greige").removeClass('activeback');
    //        //            $(".tab1OtherVA").removeClass('activeback');

    //        //            $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").show();
    //        //            $("#StyleSpecificSupplierQuotation1_grdnormalva").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdfinishing").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdgsm").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdGriegeDyed").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grddayedstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdprintstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdstylebasedOtherVA").hide();
    //        //            stylyeSpeBorderHi();
    //        //        }

    //        //        else {
    //        //            $("#StyleSpecificSupplierQuotation1_grdgsm").show();
    //        //            $(".tab1greige").addClass('activeback');
    //        //            $(".tab1Dayed").removeClass('activeback');
    //        //            $(".tab1Print").removeClass('activeback');
    //        //            $(".tab1finished").removeClass('activeback');
    //        //            $(".tab1OtherVA").removeClass('activeback');
    //        //            $(".tab1Embe").removeClass('activeback');
    //        //            $("#StyleSpecificSupplierQuotation1_grdnormalva").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdfinishing").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdGriegeDyed").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdprintstyle").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdEmbeEmbr").hide();
    //        //            $("#StyleSpecificSupplierQuotation1_grdstylebasedOtherVA").hide();
    //        //            stylyeSpeBorderHi();
    //        //        }



    //    }


    function ShowpurchasedSupplierFormReraise(Fabtype, FabQualityID, SupplierMasterID, MasterPoID, elem, residualshink, cutwastage, gerigeshrinkage) {
        
        $.ajaxSetup({ cache: false })
        var urls = window.location.href;
        var sURL = '../../Internal/Fabric/FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + "SuPPLIERVIEW" + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&residual=" + residualshink + "&cutwastage=" + cutwastage + "&gerige=" + gerigeshrinkage;
        //window.open(sURL);     
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        $('#sb-wrapper').addClass("PurchaseOrder");
        return false;
    }
    function ShowpurchasedSupplierFormReraisenew(Fabtype, FabQualityID, SupplierMasterID, MasterPoID, elem, residualshink, cutwastage, gerigeshrinkage, CuurentStage, PreviousStage, IsStyleSpecific, StyleID, stage1, stage2, stage3, stage4, PO_Number) {
        

        $.ajaxSetup({ cache: false })
        //alert(elem.id)
        //        var urls = window.location.href;
        //        var sURL = '../../Internal/Fabric/FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + "SuPPLIERVIEW" + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&residual=" + residualshink + "&cutwastage=" + cutwastage + "&gerige=" + gerigeshrinkage + "&currentstage=" + CuurentStage + "&previousstage=" + PreviousStage + "&isStyleSpecific=" + IsStyleSpecific + "&styleid=" + StyleID + "&Stage1=" + stage1 + "&Stage2=" + stage2 + "&Stage3=" + stage3 + "&Stage4=" + stage4;
        // var sURL = "D:/tfs/iKandi.Web/Uploads/Fits/POFabric_viewBPL-2F8.HTML";
        var sURL = "../../Uploads/Fits/POFabric_view" + PO_Number + ".HTML?PO_number=" + PO_Number;
        // window.open(sURL); 

        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        $('#sb-wrapper').addClass("PurchaseOrder");

        return false;
    }
    function SBClose() { }
    function CallThisPage() {
        this.window.location.reload();
    }
    function ShowHideSupplierTabAfter(type) {

        //        alert("call from server");
        //        
        if (type == 'Fabric') {
            $("#dvFabricQuotation").show();
            $("#dvAccessoryQuotation").hide();
            $("#dvfabricstylequatation").hide();

            $(".tabFabricCls").addClass('Active');
            $(".tabAccessoryCls").removeClass('Active');
            $(".tabFabricStyleCls").removeClass('Active');
            $(".tab1Dayed").removeClass('activeback');

            $("#" + hdnSupplyTypeClientId).val(1);
        }
        else if (type == 'FabricStyle') {

            $("#StyleSpecificSupplierQuotation1_grddayedstyle").show();
            $(".tab1Dayed").addClass('activeback');

            $("#dvfabricstylequatation").show();
            $("#dvFabricQuotation").hide();
            $("#dvAccessoryQuotation").hide();
            $("#StyleSpecificSupplierQuotation1_grddayedstyle").show();
            $(".tabFabricStyleCls").addClass('Active');
            $(".tabFabricCls").removeClass('Active');
            $(".tabAccessoryCls").removeClass('Active');

            $("#" + hdnSupplyTypeClientId).val(2);
        }
        else if (type == 'Accessory') {
            $("#dvAccessoryQuotation").show();
            $("#dvFabricQuotation").hide();
            $("#dvfabricstylequatation").hide();

            $(".tabAccessoryCls").addClass('Active');
            $(".tabFabricCls").removeClass('Active');
            $(".tabFabricStyleCls").removeClass('Active');
            $("#" + hdnSupplyTypeClientId).val(3);
        }
    }

</script>
<asp:HiddenField ID="hdntabvalue" runat="server" />
<div style="width: 100%; position: sticky; top: 119px; display: flex; align-items: center;
    padding: 4px 7px 4px; z-index: 1; background-color: #f9f8f8;">
    <div class="tab" style="width: 60%;">
        <asp:LinkButton ID="LnkDYEDStyle" runat="server" CssClass="tab1Dayed" CommandArgument="DYEDStyle"
            OnClick="LinkSupplyTab_Click"> Dyed</asp:LinkButton>
        <asp:LinkButton ID="LnkPRINTStyle" runat="server" CssClass="tab1Print" CommandArgument="PRINTStyle"
            OnClick="LinkSupplyTab_Click"> Print</asp:LinkButton>
        <asp:LinkButton ID="LnkEmbeEmbr" runat="server" CssClass="tab1EmbeEmbr" CommandArgument="EmbeEmbr"
            OnClick="LinkSupplyTab_Click"> Embe/Embr</asp:LinkButton>
    </div>
    <div style="width: 40%; text-align: right;">
        <asp:DropDownList ID="DdlSearchType" runat="server" Style="height: 21px;">
            <asp:ListItem Value="1" Text="Fabric Quality"></asp:ListItem>
            <asp:ListItem Value="2" Text="Color Print"></asp:ListItem>
            <asp:ListItem Value="3" Text="Supplier"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtsearchkeyswords" class="search_1 searchtxt" placeholder="Search Fabric Quality/Color Print/Supplier"
            runat="server" Style="text-transform: unset; width: 50%"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" placeholder="Quality/ supplier name" CssClass="go do-not-disable"
            Text="Search" OnClick="btnSearch_Click" Style="padding: 3px 7px; border-radius: 2px;" />
    </div>
</div>
<div class="maincontentcontainer">
    <asp:GridView ID="grddayedstyle" CssClass="grdgsmcom FabStyleSpeDyTable" Visible="false"
        Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" EmptyDataText="No Record Found!" Width="1335px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths"
        OnRowDataBound="grddayedstyle_RowDataBound" ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountPri" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="140px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="lnkOpenPopupdyd" runat="server" Text='<%# Eval("TradeName") %>'
                                    OnClick="lnkOpenPopup_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemStyle Width="60px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnGSM" Value='<%# Eval("GSM") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="width">
                <ItemStyle Width="80px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center'>
                                <asp:Label ID="lblwidth" ForeColor="black" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count Construction">
                <ItemStyle Width="70px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemStyle Width="90px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value='<%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: Blue;'>
                                        <%# Eval("SerialNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnSerialNumber" Value=' <%# Eval("SerialNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cut meterage required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" Style="margin: 0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="60px" CssClass="RowCountLPri BottomCol" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="residual shr">
                <ItemStyle Width="40px" CssClass="FabFirstCol2" HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" CssClass="color_black" runat="server" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyleCurrentStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblcurrentStage" Text='<%# Eval("CuurentStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdncurrentStage" Value='<%# Eval("CuurentStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Previous Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStylePreviousStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 20%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblPreviousStage" Text='<%# Eval("PreviousStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnPreviousStage" Value='<%# Eval("PreviousStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("Supplier_MasterID")%>' />
                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                    <asp:HiddenField ID="hdnstyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                    <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                    <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                    <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderDayedVA(this)" 
                        onkeypress="RestrictSpaceSpecial();" CssClass="number Normaltextbox numeric-field-with-decimal-places"
                        runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'></asp:TextBox>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderDayedVA(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("QuotedDate") %>
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grdprintstyle" CssClass="grdgsmcom FabStyleSpeTablePrint" Visible="false"
        Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" EmptyDataText="No Record Found!" Width="1335px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths"
        OnRowDataBound="grdprintstyle_RowDataBound" ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountPri" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="140px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="lnkOpenPopupdyd" runat="server" Text='<%# Eval("TradeName") %>'
                                    OnClick="lnkOpenPopup_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemStyle Width="50px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnGSM" Value='<%# Eval("GSM") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="width">
                <ItemStyle Width="80px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center'>
                                <asp:Label ID="lblwidth" ForeColor="black" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count Construction">
                <ItemStyle Width="70px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemStyle Width="90px" CssClass="textLeft FabFirstLeftbor FabFirstCol1" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value='<%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: Blue;'>
                                        <%# Eval("SerialNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnSerialNumber" Value=' <%# Eval("SerialNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cut meterage required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" Style="margin: 0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="60px" CssClass="RowCountLPri" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual shr">
                <ItemStyle Width="40px" CssClass="FabFirstColP" HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" CssClass="color_black" runat="server" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyleCurrentStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblcurrentStage" Text='<%# Eval("CuurentStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdncurrentStage" Value='<%# Eval("CuurentStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Previous Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStylePreviousStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 20%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblPreviousStage" Text='<%# Eval("PreviousStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnPreviousStage" Value='<%# Eval("PreviousStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("Supplier_MasterID")%>' />
                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                    <asp:HiddenField ID="hdnstyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName")%>'></asp:Label>
                    <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                    <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                    <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                    <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderPrintVA(this)" onkeypress="RestrictSpaceSpecial();"
                        CssClass="number Normaltextbox numeric-field-with-decimal-places" runat="server"
                        pattern="^\d*(\.\d{0,2})?$" BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'></asp:TextBox>
                    <%-- <asp:TextBox ID="txtdays" onchange="UpdatePendingOrderPrintVA(this)" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" CssClass="Normaltextbox" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderPrintVA(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted Date">
                <ItemTemplate>
                    <%# Eval("QuotedDate") %>
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grdEmbeEmbr" CssClass="grdgsmcom FabStyleSpeEmTable" Visible="false"
        Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" EmptyDataText="No Record Found!" Width="1335px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths"
        OnRowDataBound="grdEmbeEmbr_RowDataBound" ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountPri" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="lnkOpenPopupdyd" runat="server" Text='<%# Eval("TradeName") %>'
                                    OnClick="lnkOpenPopup_Click"></asp:LinkButton>
                            </td>
                        </tr>

                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
                <ItemStyle Width="180px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="(GSM)">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 60px; text-align: center;
                                color: Black;'>
                                <asp:Label ID="lblgsm" runat="server" Text='<%# Eval("GSM") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnGSM" Value='<%# Eval("GSM") %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Width">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 60px; text-align: center;'>
                                <asp:Label ID="lblwidth" runat="server" ForeColor="black" CssClass="color_black"
                                    Text='<%# Eval("width").ToString()+"&quot" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count Construction">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: center;
                                color: Black;'>
                                <asp:Label ID="lblCC" runat="server" CssClass="color_black" ForeColor="Black" Text='<%# Eval("CC").ToString()+"&quot" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 25%; text-align: left;'>
                                <asp:Label ID="lblcolor" runat="server" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="130px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value='<%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='width: 50%; border-top: none; border-right: none; padding-right: 20px;
                                        text-align: left; color: Blue;'>
                                        <%# Eval("SerialNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnSerialNumber" Value=' <%# Eval("SerialNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cut meterage required <br> (VA Wastage)">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" Style="margin: 0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                    <asp:Label ID="lblVAWastage" CssClass="color_black lineheight" Text='<%# Convert.ToString(Eval("VAWastage")) == "0" ? "" : "("+Convert.ToString(Eval("VAWastage")) +" %)" %>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnVAWastage" Value='<%# Convert.ToString(Eval("VAWastage")) == "0" ? "" : "("+Convert.ToString(Eval("VAWastage")) +" %)" %>' />
                </ItemTemplate>
                <ItemStyle Width="100px" CssClass="RowCountLPri FabFirstClEm3" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual shr">
                <ItemStyle Width="40px" CssClass="FabFirstClEm2" HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" runat="server" CssClass="color_black" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VA Name Stage Wastage">
                <ItemTemplate>
                    <asp:Label ID="lblvaname" Text='<%# Eval("VAName")%>' CssClass="color_black" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" CssClass="RowCountLPri" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyleCurrentStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblcurrentStage" Text='<%# Eval("CuurentStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdncurrentStage" Value='<%# Eval("CuurentStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Previous Stage">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStylePreviousStage">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none; width: 20%; text-align: center;
                                        padding-top: 10px;'>
                                        <asp:Label ID="lblPreviousStage" Text='<%# Eval("PreviousStage")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnPreviousStage" Value='<%# Eval("PreviousStage")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("Supplier_MasterID")%>' />
                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                    <asp:HiddenField ID="hdnSupplyTypeId" runat="server" Value='<%# Eval("SupplyTypeId")%>' />
                    <asp:HiddenField ID="hdnstyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                    <asp:HiddenField ID="hdnPreviousStage" runat="server" Value='<%# Eval("PreviousStage")%>' />
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                    <asp:HiddenField ID="hdnCurrentStage" runat="server" Value='<%# Eval("CuurentStage") %>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%#  Eval("SupplierName")%>'></asp:Label>
                    <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                    <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                    <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                    <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderEmbellishmentVA(this)" onkeypress="RestrictSpaceSpecial();"
                        CssClass="number Normaltextbox numeric-field-with-decimal-places" runat="server"
                        pattern="^\d*(\.\d{0,2})?$" BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'></asp:TextBox>
                    <%-- <asp:TextBox ID="txtdays" onchange="UpdatePendingOrderEmbellishmentVA(this)" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server" BorderColor="White" CssClass="Normaltextbox" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderEmbellishmentVA(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("QuotedDate") %>
                </ItemTemplate>
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<table style='width: 100%' ><tr> <td style='width: 20%' >PO No.</td>  <td style='width: 20%' >Quantity</td>  <td style='width: 20%' >Rate</td>  <td style='width: 20%' >(Date)</td>  <td style='width: 20%' >Action</td> </tr>  </table> "
                Visible="false">
                <ItemTemplate>
                    <%-- <asp:GridView ID="grdsupplierpo" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                        Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                        BorderWidth="0" rules="all" CssClass="innertablePo" OnRowDataBound="grdsupplierpo_RowDataBound"
                        HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a href="javascript:void(0)" onclick="ShowpurchasedSupplierFormReraisenew('<%# Eval("SupplyTypeId").ToString() == "31" ? "Embroidery" : "Embellishment" %>','<%# Eval("Fabric_QualityID") %>', '<%# Eval("SupplierID") %>', '<%# Eval("MasterPO_Id") %>', '<%# Eval("PrintName")  %>', '<%# Eval("Residual") %>', '<%# Eval("CuttingWastage") %>', '<%# Eval("GreigedShrinkage") %>', '<%# Eval("CurrentStage") %>', '<%# Eval("PreviousStage") %>', '1' , '<%# Eval("StyleID") %>' , '<%# Eval("Stage1") %>', '<%# Eval("Stage2") %>', '<%# Eval("Stage3") %>', '<%# Eval("Stage4") %>','<%# Eval("PO_Number").ToString() %>')"
                                        title="po Number">
                                        <%# Eval("PO_Number").ToString() %></a>
                                               <asp:HiddenField ID="hdnstatus" runat="server" Value='<%# Eval("PoStatus")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" CssClass="minUnitWidth" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a id="aponumber" runat="server">
                                        <asp:Label ID="lblpoqty" Text='<%# (Eval("ReceivedQty") == DBNull.Value  || (Eval("ReceivedQty").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("ReceivedQty"))).ToString("N0")) %>'
                                            CssClass="color_black" runat="server"></asp:Label>
                                    </a>
                                           <%# Eval("UnitsName").ToString()%>
                              
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <span style='color: green; font-size: 11px; margin-right: 2px'>₹</span><span style='color: #000'>
                                        <%# Eval("Rate")%></span>
                                </ItemTemplate>
                                <ItemStyle CssClass="ColWidthOne" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")"%>
                                                                 </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                        OnClientClick="ConfirmStyleSpecificSupplier()" CssClass="Acceptbutton" />
                                    <asp:HiddenField ID="hdnPO_Number" runat="server" Value='<%# Eval("PO_Number")%>' />
                                    <asp:HiddenField ID="hdnMasterPO_Id" runat="server" Value='<%# Eval("MasterPO_Id")%>' />
                                    <asp:HiddenField ID="hdnQueryString" runat="server" Value='<%# (Eval("SupplyTypeId").ToString() == "31" ? "Fabtype=Embroidery" : "Fabtype=Embellishment") + "&styleid="+ Eval("StyleID") + "&Potype=RERAISE&currentstage="+Eval("CurrentStage")+"&previousstage="+Eval("PreviousStage")+"&IsStyleSpecific="+Eval("IsStyleSpecific")+"&Stage1="+Eval("Stage1")+"&Stage2="+Eval("Stage2")+"&Stage3="+Eval("Stage3")+"&Stage4="+Eval("Stage4")+"&colorprintdetail="+Eval("PrintName")+"&SupplierMasterID="+ Eval("SupplierID") +"&MasterPO_Id="+ Eval("MasterPO_Id") +"&FabricQualityID="+ Eval("Fabric_QualityID") +"&PoNumberPrint="+Eval("PO_Number") %>' />
                                    <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                </ItemTemplate>
                <ItemStyle CssClass="PoNoUnitStyle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="clear: both">
    </div>
</div>
<div id="divmModelPopupForStyleSpecific" class="modal Popuphide" runat="server">
    <div class="modal-content">
        <span class="close" id="closebutton" onclick="ClosePopupStylespc();return false;">&times;</span>
        <asp:GridView ID="grdsupplierpo" ShowHeader="true" runat="server" AutoGenerateColumns="False"
            Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
            BorderWidth="0" rules="all" CssClass="innertablePo Usertable" OnRowDataBound="grdsupplierpo_RowDataBound"
            HeaderStyle-CssClass="ths" EmptyDataText="No Record Found">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
                <asp:TemplateField HeaderText="PoNumber">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="ShowpurchasedSupplierFormReraisenew(<%# Eval("Flag") %>,'<%# Eval("Fabric_QualityID") %>', '<%# Eval("SupplierID") %>', '<%# Eval("MasterPO_Id") %>', '<%# Eval("PrintName")  %>', '<%# Eval("Residual") %>', '<%# Eval("CuttingWastage") %>', '<%# Eval("GreigedShrinkage") %>', '<%# Eval("CurrentStage") %>', '<%# Eval("PreviousStage") %>', '<%# Eval("IsStyleSpecific") %>', '<%# Eval("StyleID") %>' , '<%# Eval("Stage1") %>', '<%# Eval("Stage2") %>', '<%# Eval("Stage3") %>', '<%# Eval("Stage4") %>','<%# Eval("PO_Number").ToString() %>')"
                            title="po Number">
                            <%# Eval("PO_Number").ToString() %></a>
                        <asp:HiddenField ID="hdnstatus" runat="server" Value='<%# Eval("PoStatus")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SupplierName">
                    <ItemTemplate>
                        <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                        <asp:HiddenField ID="hdnSupplierName" runat="server" Value='<%# Eval("SupplierName")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitsName">
                    <ItemStyle HorizontalAlign="Center" CssClass="minUnitWidth" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <a id="aponumber" runat="server">
                            <asp:Label ID="lblpoqty" Text='<%# (Eval("ReceivedQty") == DBNull.Value  || (Eval("ReceivedQty").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("ReceivedQty"))).ToString("N0")) %>'
                                CssClass="color_black" runat="server"></asp:Label>
                        </a>
                        <%# Eval("UnitsName").ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <span style='color: green; font-size: 11px; margin-right: 2px'>₹</span> <span style='color: #000'>
                            <%# Eval("Rate")%></span>
                    </ItemTemplate>
                    <ItemStyle CssClass="ColWidthOne" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PoDate">
                    <ItemTemplate>
                        <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                            OnClientClick="ConfirmStyleSpecificSupplier()" CssClass="Acceptbutton" />
                        <asp:HiddenField ID="hdnPO_Number" runat="server" Value='<%# Eval("PO_Number")%>' />
                        <asp:HiddenField ID="hdnMasterPO_Id" runat="server" Value='<%# Eval("MasterPO_Id")%>' />
                        <asp:HiddenField ID="hdnQueryString" runat="server" Value='<%# Eval("Flag").ToString()=="31"?"Fabtype=Embroidery":"Fabtype=Embellishment"+"&Potype=RERAISE&currentstage="+Eval("CurrentStage")+"&previousstage="+Eval("PreviousStage")+ "&styleid="+ Eval("StyleID") + "&IsStyleSpecific="+Eval("IsStyleSpecific")+"&Stage1="+Eval("Stage1")+"&Stage2="+Eval("Stage2")+"&Stage3="+Eval("Stage3")+"&Stage4="+Eval("Stage4")+"&colorprintdetail="+Eval("PrintName")+"&SupplierMasterID="+ Eval("SupplierID") +"&MasterPO_Id="+ Eval("MasterPO_Id") +"&FabricQualityID="+ Eval("Fabric_QualityID") +"&PoNumberPrint="+Eval("PO_Number") %>' />
                        <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
<div id="secure_footer" style="text-align: center; text-align: center; padding: 10px 0;
    background-color: #39589c; color: #bfbfbf; width: 100%; position: fixed; left: 0;
    bottom: 0;">
    <script>        document.write((new Date()).getFullYear())</script>
    © Boutique International Pvt. Ltd. All Rights Reserved.
</div>
<asp:HiddenField ID="confirm_value" runat="server" Value="No" />
<script type="text/javascript">

    function ConfirmStyleSpecificSupplier() {
        
        if (confirm("Please confirm, you have reviewed PO!")) {
            document.getElementById("StyleSpecificSupplierQuotation1_confirm_value").value = "Yes";
        } else {
            document.getElementById("StyleSpecificSupplierQuotation1_confirm_value").value = "No";
        }
    }

</script>
