<%@  Language="C#" AutoEventWireup="true" CodeBehind="FabricSupplierQuotation.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.FabricSupplierQuotation" %>
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
    #FabricQuotationForm1_grdGriege_ctl02_lblPreviousStage:not(:first-child)
    {
        display: none;
    }
    /* Modal Content */
    .modal-content
    {
        background-color: White;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
        height: auto;
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
    .hide
    {
        display: none;
    }
    
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: arial !important;
    }
    
    .Acceptbutton
    {
        background: #408fd7;
        border: solid 1px #045198;
        cursor: pointer;
        padding: 2px;
        font: bold 12px/12px Verdana, Helvetica, sans-serif;
        color: #fff;
        text-decoration: none;
        text-align: center;
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
        float: right;
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
    
    .clear
    {
        clear: both;
    }
    
    .searchtxt
    {
        height: 17px;
        width: 27.8%;
        border-radius: 2px;
        padding-left: 2px;
    }
    
    
    .grdStyleg
    {
        border: 0px !important;
    }
    .border_right_0
    {
        border: 0px;
    }
    .txtLeft
    {
        text-align: left;
    }
    .txtRight
    {
        text-align: right;
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
        height: 25px;
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
    
    @media screen and (max-width: 1366px)
    {
        .textright
        {
            width: 958px !important;
        }
    }
    
    .border_bottom_color
    {
        border-bottom-color: #999 !important;
        border-bottom: 1px solid #999 !important;
    }
    
    td.EmptyRowStyle
    {
        color: Red !important;
        font-size: 0px !important;
        border: 0px;
        border-bottom: 1px solid #999;
    }
    
    td.EmptyRowStyleFirst
    {
        border: 0px;
        border-left: 1px solid #999;
        border-bottom: 1px solid #999;
    }
    
    td.EmptyRowStyleLast
    {
        border: 0px;
        border-right: 1px solid #999;
        border-bottom: 1px solid #999;
    }
    
    .PurchaseOrder
    {
        width: 950px !important;
    }
    .Popuphide
    {
        display: none;
    }
    .Popupshow
    {
        display: block !important;
    }
</style>
<script type="text/javascript">
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
    function getSelectionStart(o) {
        if (o.createTextRange) {
            var r = document.selection.createRange().duplicate()
            r.moveEnd('character', o.value.length)
            if (r.text == '') return o.value.length
            return o.value.lastIndexOf(r.text)
        } else return o.selectionStart
    }

    var urls = "../../Webservices/iKandiService.asmx";


    function isNumberKeyNumric(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode
        return !(charCode > 31 && (charCode < 48 || charCode > 57));
    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

    function RestrictSpaceSpecial(e) {
        var regex = new RegExp("[0123456789.]");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    function UpdatePendingOrder(elem) {
        var Idsn = elem.id.split("_");
        Selectedval = elem.value;

        $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        SupplierMasterID = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        FabMasterID = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnfabmasterid").val();
        orderdetailid = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnorderdetailid").val();
        txtdays = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval").val();



        fabQtyID = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        FabricPending_Orders_Id = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnSupplierGreigedOrderId").val();
        fabricdetails = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();

        var DeliveryType = $("#FabricQuotationForm1_grdGriege_" + Idsn[2] + "_DeliveryType").val();

        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).focus();

                return;
            }
            else {
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).focus();
                return;
            }
            else {

                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }

        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/updatePendingGreigeOrdersSupplier",
            data: "{ flag:'" + '2' + "', Fabric_MasterID:'" + FabMasterID + "', QuotedLandedRate:'" + txtquotedval + "',Supplier_master_ID:'" + SupplierMasterID + "', SupplierGreigedOrder_Id:'" + FabricPending_Orders_Id + "', fabQtyID:'" + fabQtyID + "', fabricdetails:'" + fabricdetails + "', DeliveryType:'" + DeliveryType + "'}",
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

    function UpdatePendingOrderFinshing(elem) {

        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        FabMasterID = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnfabmasterid").val();
        orderdetailid = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnorderdetailid").val();
        txtdays = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        FabricPending_Orders_Id = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnSupplierGreigedOrderId").val();
        fabricdetails = $("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();
        var DeliveryType = $("#FabricQuotationForm1_grdfinishing_" + Idsn[2] + "_DeliveryType").val();
        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).focus();
                return;
            }
            else {
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).focus();
                return;
            }
            else {

                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdfinishing.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }

        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/updatePendingGreigeOrdersSupplier",
            data: "{ flag:'" + '4' + "', Fabric_MasterID:'" + FabMasterID + "', QuotedLandedRate:'" + txtquotedval + "',Supplier_master_ID:'" + SupplierMasterID + "', SupplierGreigedOrder_Id:'" + FabricPending_Orders_Id + "', fabQtyID:'" + fabQtyID + "', fabricdetails:'" + fabricdetails + "', DeliveryType:'" + DeliveryType + "'}",
            dataType: 'JSON',
            success: OnSuccessCall,
            error: OnErrorCall
        });
        return false;



        function OnSuccessCall(response) {
            //                    __doPostBack('', '');
            //alert("Saved Sucessfully");
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }


    }

    function UpdatePendingOrderDayed(elem) {


        // FabricQuotationForm1_grdDyed_ctl04_txtquotedval
        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        FabMasterID = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_hdnfabmasterid").val();

        txtdays = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        FabricPending_Orders_Id = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_hdnSupplierGreigedOrderId").val();
        fabricdetails = $("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();

        var DeliveryType = $("#FabricQuotationForm1_grdDyed_" + Idsn[2] + "_DeliveryType").val();

        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).focus();
                return;
            }
            else {
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).focus();
                return;
            }
            else {

                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdDyed.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }

        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/updatePendingGreigeOrdersSupplier",
            data: "{ flag:'" + '6' + "', Fabric_MasterID:'" + FabMasterID + "', QuotedLandedRate:'" + txtquotedval + "',Supplier_master_ID:'" + SupplierMasterID + "', SupplierGreigedOrder_Id:'" + FabricPending_Orders_Id + "', fabQtyID:'" + fabQtyID + "', fabricdetails:'" + fabricdetails + "', DeliveryType:'" + DeliveryType + "'}",
            dataType: 'JSON',
            success: OnSuccessCall,
            error: OnErrorCall
        });
        return false;



        function OnSuccessCall(response) {
            //                   
            //alert("Saved Sucessfully");
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }


    }

    function UpdatePendingOrderPrint(elem) {

        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();
        FabMasterID = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnfabmasterid").val();
        orderdetailid = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnorderdetailid").val();
        txtdays = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        FabricPending_Orders_Id = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnSupplierGreigedOrderId").val();
        fabricdetails = $("#<%= grdprint.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();

        var DeliveryType = $("#FabricQuotationForm1_grdprint_" + Idsn[2] + "_DeliveryType").val();
        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).focus();
                return;
            }
            else {
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).focus('class', 'decoratedErrorField');
                return;
            }
            else {

                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdprint.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }

        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/updatePendingGreigeOrdersSupplier",
            data: "{ flag:'" + '8' + "', Fabric_MasterID:'" + FabMasterID + "', QuotedLandedRate:'" + txtquotedval + "',Supplier_master_ID:'" + SupplierMasterID + "', SupplierGreigedOrder_Id:'" + FabricPending_Orders_Id + "', fabQtyID:'" + fabQtyID + "', fabricdetails:'" + fabricdetails + "', DeliveryType:'" + DeliveryType + "'}",

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

    function Openmodelpopup() {


        $("#<%=dvMymodelPopup.ClientID %>").show();
        return false;
    }

    function ClosePopup() {

        $("#<%=dvMymodelPopup.ClientID %>").removeClass('Popupshow');
        $("#<%=dvMymodelPopup.ClientID %>").hide();


    }
    //    $(window).click(function (event) {
    //        if (event.target != $("#<%=dvMymodelPopup.ClientID %>")) {
    //            $("#<%=dvMymodelPopup.ClientID %>").hide();
    //        }
    //    });
    function UpdatePendingOrderotherVA(elem) {
        debugger;

        //  alert("check");
        var Idsn = elem.id.split("_");
        Selectedval = elem.value;
        $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays").focus();
        fabQtyID = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnfabricQuality").val();
        SupplierMasterID = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnSupplierMasterID").val();

        txtdays = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays").val();
        txtquotedval = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
        fabricdetails = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnfabricdetails").val();
        styleid = -1;
        VAID = 29;

        stage1 = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnstage1").val();
        stage2 = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnstage2").val();
        stage3 = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnstage3").val();
        stage4 = $("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_hdnstage4").val();

        if (stage1 == null || stage1 =="") {
            stage1 = "-1";
        }
        if (stage2 == null || stage2 == "") {
            stage2= "-1";
        }
        if (stage3 == null || stage3 == "") {
            stage3 = "-1";
        }
        if (stage4 == null || stage4 == "") {
            stage4 = "-1";
        }
        var DeliveryType = $("#FabricQuotationForm1_grdRfd_" + Idsn[2] + "_DeliveryType").val();

        if (txtdays == "") {
            txtdays = 0;
        }
        if (txtquotedval == "") {
            txtquotedval = 0;
        }
        if (txtdays < 1 || txtquotedval <= 0) {

            //alert("You must have to fill both filed value quoteed rate & time")
            if (txtdays < 1) {
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'decoratedErrorField');
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).focus();
                return;
            }
            else {
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            }
            if (txtquotedval <= 0) {
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'decoratedErrorField');
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).focus();
                return;
            }
            else {

                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
                $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
            }
        }
        else {
            $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).removeAttr('class', 'decoratedErrorField');
            $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtdays")).attr('class', 'Normaltextbox');
            $($("#<%= grdRfd.ClientID %>_" + Idsn[2] + "_txtquotedval")).attr('class', 'Normaltextbox');
        }
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: urls + "/UpdateQuatationotherVA",
            data: "{ flag:'" + 'UPDATEQUOTE' + "', QualityID:'" + fabQtyID + "', VAID:'" + VAID + "',QuotedLandedRate:'" + txtquotedval + "', SuppliermasterID:'" + SupplierMasterID + "', fabricdetails:'" + fabricdetails + "',Styleid:'" + styleid + "', stage1:'" + stage1 + "', stage2:'" + stage2 + "',stage3:'" + stage3 + "', stage4:'" + stage4 + "' , DeliveryType:'" + DeliveryType + "'}",

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
        $("input").attr("autocomplete", "off");

        //        $("#FabricQuotationForm1_grdGriege").show();
        //        $(".tab1greige").addClass('activeback');
        //        $(".tab1Dayed").removeClass('activeback');
        //        $(".tab1Print").removeClass('activeback');
        //        $(".tab1finished").removeClass('activeback');
        //        $("#FabricQuotationForm1_grdfinishing").hide();
        //        $("#FabricQuotationForm1_grdDyed").hide();
        //        $("#FabricQuotationForm1_grdprint").hide();

        $.ajaxSetup({ cache: false })
        //        $(".tab1").click(function () {
        //            $(this).addClass('activeback').siblings().removeClass('activeback');
        //        });

        // added by shubhendu
        $("#FabricQuotationForm1_btnSearch").click(function () {
            $("#FabricQuotationForm1_grdRfd_ctl04_txtquotedval").addClass("number");
            $("#FabricQuotationForm1_grdRfd_ctl05_txtquotedval").addClass("number");
        });

        $("#<%=dvMymodelPopup.ClientID %>").hide();

        //        $("#FabricQuotationForm1_grdGriege").show();
        //        $(".tab1greige").addClass('activeback');
        //        $(".tab1Dayed").removeClass('activeback');
        //        $(".tab1Print").removeClass('activeback');
        //        $(".tab1finished").removeClass('activeback');
        //        $("#FabricQuotationForm1_grdfinishing").hide();
        //        $("#FabricQuotationForm1_grdDyed").hide();
        //        $("#FabricQuotationForm1_grdprint").hide();

        $('.number').keypress(function (event) {
            var $this = $(this);
            if ((event.which != 46 || $this.val().indexOf('.') != -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8))) {
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
            if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (event.which != 0 && event.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) {
                event.preventDefault();
            }
        });

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


    function MargeDuplicateVals() {

        var gvDrv = document.getElementById("<%=grdGriege.ClientID %>");
        var gvnextDrv = document.getElementById("<%=grdGriege.ClientID %>");
        for (i = (gvDrv.rows.length - 2); i >= 0; i--) {
            var cell = gvDrv.rows[i].cells;
            var cellnext = gvnextDrv.rows[i + 1].cells;

            var HTML = cell[2].innerHTML.trim().replace(/<\/?[^>]+(>|$)/g, "");
            var HTMLnext = cellnext[2].innerHTML.trim().replace(/<\/?[^>]+(>|$)/g, "");

            if (HTML == HTMLnext) {


                //if (cellnext[2].rowSpan < 2) {
                cell[2].rowSpan = 2;
                // gvnextDrv.rows[i + 1].deleteCell(2);
                gvDrv.rows[i + 1].deleteCell(2);
                // }
                //                    else {
                //                        cell[2].rowSpan = cellnext[2].rowSpan + 1;
                //                    }
            }

        }
    }

    function CallThisPage() {
        this.window.location.reload();
    }

</script>
<asp:HiddenField ID="hdntabvalue" runat="server" />
<div style="width: 100%; position: sticky; top: 119px; display: flex; align-items: center;
    padding: 4px 7px 4px; z-index: 1; background-color: #f9f8f8;">
    <div class="tab" style="width: 60%;">
        <asp:LinkButton ID="LnkGRIEGE" runat="server" CssClass="activeback tab1greige" CommandArgument="GREIGE"
            OnClick="LinkSupplyTab_Click"> Greige</asp:LinkButton>
        <asp:LinkButton ID="LnkDYED" runat="server" CssClass="tab1Dayed" CommandArgument="DYED"
            OnClick="LinkSupplyTab_Click"> Dyed</asp:LinkButton>
        <asp:LinkButton ID="LnkPRINT" runat="server" CssClass="tab1Print" CommandArgument="PRINT"
            OnClick="LinkSupplyTab_Click"> Print</asp:LinkButton>
        <asp:LinkButton ID="LnkFINISHED" runat="server" CssClass="tab1finished" CommandArgument="FINISHED"
            OnClick="LinkSupplyTab_Click"> Finished</asp:LinkButton>
        <asp:LinkButton ID="LnkRFD" runat="server" CssClass="tab1OtherRFD" CommandArgument="RFD"
            OnClick="LinkSupplyTab_Click"> RFD</asp:LinkButton>
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
            Text="Search" OnClick="btnSearch_Click" Style="padding: 3px 7px; border-radius: 2px;
            margin-bottom: 2px;" />
    </div>
</div>
<div class="maincontentcontainer">
    <asp:GridView ID="grdGriege" CssClass="grdGriegecom FabGrdGriegeTable" Visible="false"
        Style="width: 100%; min-width: 1200px;" ShowHeader="true" runat="server" AutoGenerateColumns="False"
        EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
        BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountGriege" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="250px" CssClass="textLeft FabFirstLeftbor FabFirstFCol" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="btnlnkpopup" runat="server" OnClick="showPO" Text='<%# Eval("TradeName")%>'>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black!important;'>
                                <asp:Label ID="lblwidth" ForeColor="" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Greige Count Construction">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString() %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td runat="server" id="tdstylenumber" style='border-top: none; border-right: none;text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hdnStyleNumber" runat="server" Value='<%# Eval("StyleNumber")%>' />
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
                                    <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
                                        <%# Eval("SerialNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hdnSerialNumber" runat="server" Value='<%# Eval("SerialNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cut meterage required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" style="margin-right:0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="90px" CssClass="RowCountLGri" />
            </asp:TemplateField>
            <%--   <asp:TemplateField Visible="false" HeaderText="Greige Shrinkage %">
                <ItemTemplate>
                    <asp:Label ID="lblGreige_Sh" CssClass="color_black" Text='<%# Convert.ToString(Eval("GreigeSh")) == "0" ? "" : Convert.ToString(Eval("GreigeSh"))%>'
                        runat="server" ToolTip='<%# Convert.ToString(Eval("GreigeSh")) == "0" ? "" : Convert.ToString(Eval("GreigeSh"))%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnGreigeSh" Value='<%# Convert.ToString(Eval("GreigeSh")) == "0" ? "" : Convert.ToString(Eval("GreigeSh"))%>' />
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Current Stage">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblcurrentStage" runat="server" Text="1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Previous Stage">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 20%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblPreviousStage" runat="server" Text="N/A"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("Supplier_MasterID")%>' />
                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                    <asp:HiddenField ID="hdnSupplierGreigedOrderId" runat="server" Value='<%# Eval("SupplierLatestOrderId")%>' />
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value="" />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrder(this)"
                        onkeypress="RestrictSpaceSpecial();" CssClass=" Normaltextbox" runat="server"
                        BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'
                        Style="font-weight: 600;"></asp:TextBox>
                    <%--<asp:TextBox ID="txtdays" CssClass="Normaltextbox" onchange="UpdatePendingOrder(this)"
                        onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrder(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("QuotedDate") %>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grdfinishing" CssClass="grdgsmcom FabGrdFinishTable" Visible="false"
        Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths"
        ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCount" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="230px" CssClass="textLeft FabFirstLeftbor FabFirstFCol" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="btnlnkpopup" runat="server" OnClick="showPO" Text='<%# Eval("TradeName")%>'>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblwidth" ForeColor="" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left;
                                padding-top: 10px;'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td runat="server" id="tdstylenumber" style='border-top: none; border-right: none;text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value=' <%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
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
            <asp:TemplateField HeaderText="Cut Meterage<br>Required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" style="margin-right:0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="RowCountLast" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual Shrinkage">
                <ItemTemplate>
                    <asp:Label ID="lblGreige_Sh" CssClass="color_black" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'
                        runat="server"></asp:Label>


                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
                <ItemStyle Width="50px" />
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
                                        <asp:Label ID="lblPreviousStage" Text='<%# Convert.ToInt32(Eval("PreviousStage")) <1  ? "N/A" : Eval("PreviousStage").ToString()   %>'
                                            runat="server"></asp:Label>
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
                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                    <asp:HiddenField ID="hdnSupplierGreigedOrderId" runat="server" Value='<%# Eval("SupplierLatestOrderId")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName")%>'></asp:Label>
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">&#x20b9;</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderFinshing(this)"
                        onkeypress="RestrictSpaceSpecial();" CssClass="number Normaltextbox" runat="server"
                        BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'
                        Style="font-weight: 600;"></asp:TextBox>
                    <%--<asp:TextBox ID="txtdays" onchange="UpdatePendingOrderFinshing(this)" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" CssClass="Normaltextbox" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderFinshing(this)"
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
    <asp:GridView ID="grdDyed" CssClass="grdgsmcom FabGrdDyedTable" Visible="false" Style="width: 100%;
        min-width: 1200px;" runat="server" AutoGenerateColumns="False" ShowHeader="true"
        EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
        BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" ShowHeaderWhenEmpty="true">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountDy" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="230px" CssClass="textLeft FabFirstLeftbor FabFirstFCol" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="btnlnkpopup" runat="server" OnClick="showPO" Text='<%# Eval("TradeName")%>'>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblwidth" ForeColor="" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left;
                                padding-top: 10px;'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td runat="server" id="tdstylenumber" style='border-top: none; border-right: none;text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value=' <%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
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
            <asp:TemplateField HeaderText="Cut Meterage<br> Required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" style="margin-right:0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="RowCountLast" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual Shrinkage">
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" CssClass="color_black" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
                <ItemStyle Width="50px" />
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
                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                    <asp:HiddenField ID="hdnSupplierGreigedOrderId" runat="server" Value='<%# Eval("SupplierLatestOrderId")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="215px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderDayed(this)"
                        onkeypress="RestrictSpaceSpecial();" CssClass="number Normaltextbox numeric-field-without-decimal-places"
                        runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'
                        Style="font-weight: 600;"></asp:TextBox>
                    <%--  <asp:TextBox ID="txtdays" onchange="UpdatePendingOrderDayed(this)" CssClass="Normaltextbox "
                        onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderDayed(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="125px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("quoteddate") %>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grdprint" CssClass="grdgsmcom FabGrdProccessTable FabGrdVATablePri"
        Visible="false" Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" EmptyDataText="No Record Found!" Width="750px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths"
        ShowHeaderWhenEmpty="true">
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
                <ItemStyle Width="250px" CssClass="textLeft FabFirstLeftbor FabFirstFCol" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="btnlnkpopup" runat="server" OnClick="showPO" Text='<%# Eval("TradeName")%>'>
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblwidth" ForeColor="" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count ">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left;
                                padding-top: 10px;'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td runat="server" id="tdstylenumber" style='border-top: none; border-right: none;text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value=' <%# Eval("StyleNumber")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
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
            <asp:TemplateField HeaderText="Cut Meterage<br> Required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" style="margin-right:0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="RowCountLast" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual Shrinkage">
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" CssClass="color_black" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
                <ItemStyle Width="50px" />
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
                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                    <asp:HiddenField ID="hdnSupplierGreigedOrderId" runat="server" Value='<%# Eval("SupplierLatestOrderId")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName")%>'></asp:Label>
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="215px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderPrint(this)"
                        onkeypress="RestrictSpaceSpecial();" CssClass="number Normaltextbox numeric-field-without-decimal-places"
                        runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'
                        Style="font-weight: 600;"></asp:TextBox>
                    <%--  <asp:TextBox ID="txtdays" onchange="UpdatePendingOrderPrint(this)" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" CssClass="Normaltextbox" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>
                    Days--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderPrint(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="125px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("quoteddate") %>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grdRfd" CssClass="grdgsmcom FabGrdVATable" Visible="false" Style="width: 100%;
        min-width: 1200px;" runat="server" AutoGenerateColumns="False" ShowHeader="true"
        EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
        BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <RowStyle CssClass="RowCountRFD" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <EmptyDataTemplate>
            <br />
            <br />
            <br />
            <img src="../../images/sorry.png" alt="No record found">
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemStyle Width="250px" CssClass="textLeft FabFirstLeftbor FabFirstFCol" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left; font-weight: 600;'>
                                <asp:LinkButton ID="btnlnkpopup" runat="server" OnClick="showPO" Text='<%# Eval("TradeName")%>'>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTradeName" Value=' <%# Eval("TradeName")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GSM">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px; color: Black;'>
                                <asp:Label ID="lblgsm" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
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
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblwidth" ForeColor="" CssClass="color_black" Text='<%# Eval("width").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnwidth" Value='<%# Eval("width").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Count Construction ">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: center;
                                padding-top: 10px;'>
                                <asp:Label ID="lblCC" CssClass="color_black" ForeColor="black" Text='<%# Eval("CC").ToString()+"&quot" %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnCC" Value='<%# Eval("CC").ToString()+"&quot" %>' />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color/Print">
                <ItemTemplate>
                    <table style='width: 100%;' border="0">
                        <tr>
                            <td style='border-top: none; border-right: none; width: 30%; text-align: left;
                                padding-top: 10px;'>
                                <asp:Label ID="lblcolor" Font-Bold="true" CssClass="color_black" Text='<%# Eval("FabricDetails")%>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnFabricDetail" Value='<%# Eval("FabricDetails")%>' />
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number">
                <ItemTemplate>
                    <asp:Repeater ID="RptStyle" runat="server">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td id="tdstylenumber" runat="server" style='border-top: none; border-right: none;text-align: left; color: Black;'>
                                        <%# Eval("StyleNumber")%>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hdnStyleNumber" Value=' <%# Eval("StyleNumber")%>' />
                             <asp:HiddenField ID="hdnstage1" runat="server" Value=' <%# Eval("Stage1")%>  ' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value=' <%# Eval("Stage2")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial Number">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="RptStyle1">
                        <ItemTemplate>
                            <table style='width: 100%;' border="0">
                                <tr>
                                    <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
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
            <asp:TemplateField HeaderText="Cut Meterage<br>Required">
                <ItemTemplate>
                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                        runat="server" style="margin-right:0;"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnQuantityToOrder" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                    <asp:Label ID="lblunits" CssClass="color_black" Font-Bold="true" ForeColor="gray"
                        Text='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnUnits" Value='<%# Convert.ToString(Eval("Units")) == "0" ? "" : Convert.ToString(Eval("Units"))%>' />
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="RowCountLast" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Residual Shrinkage">
                <ItemTemplate>
                    <asp:Label ID="lblresidual_Sh" CssClass="color_black" Text='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh") + " %")%>'
                        runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnResSh" Value='<%# Convert.ToString(Eval("ResSh")) == "0" ? "" : Convert.ToString(Eval("ResSh"))%>' />
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VA (Stages)">
                <ItemTemplate>
                    <asp:Label ID="lblvaname" Text='<%# Eval("VAName")%>' CssClass="color_black" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" CssClass="RowCountLPri" />
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
                                        <asp:Label ID="lblPreviousStage" Text='<%# Convert.ToInt32(Eval("PreviousStage")) < 1  ? "N/A" : Eval("PreviousStage").ToString() %>' runat="server"></asp:Label>
                                        
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
                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                    <asp:HiddenField ID="hdnSupplierGreigedOrderId" runat="server" Value='<%# Eval("SupplierLatestOrderId")%>' />
                    <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName")%>'></asp:Label>
                    <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />

                   
                     <asp:HiddenField ID="hdnstage3" runat="server" Value='' />
                     <asp:HiddenField ID="hdnstage4" runat="server" Value='' />

                </ItemTemplate>
                <ItemStyle Width="215px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                <ItemTemplate>
                    <span style="color: green; font-size: 11px">₹</span>
                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="UpdatePendingOrderotherVA(this)"
                        onkeypress="RestrictSpaceSpecial();" CssClass="number Normaltextbox" runat="server"
                        BorderColor="White" Text='<%# Convert.ToString(Eval("SupplierQuotedRate")) == "0" ? "" : Convert.ToString(Eval("SupplierQuotedRate"))%>'
                        Style="font-weight: 600;"></asp:TextBox>
                    <%-- <asp:TextBox ID="txtdays" onchange="UpdatePendingOrderotherVA(this)" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                        runat="server" BorderColor="White" CssClass="Normaltextbox" Text='<%# Convert.ToString(Eval("LeadDays")) == "0" ? "" : Convert.ToString(Eval("LeadDays"))%>'></asp:TextBox>--%>
                    <asp:DropDownList ID="DeliveryType" runat="server" onchange="UpdatePendingOrderotherVA(this)"
                        SelectedValue='<%# Eval("DeliveryType")%>'>
                        <asp:ListItem Value='0'>Select</asp:ListItem>
                        <asp:ListItem Value='1'>Landed</asp:ListItem>
                        <asp:ListItem Value='2'>Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="130px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted date">
                <ItemTemplate>
                    <%# Eval("quoteddate") %>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="clear: both">
    </div>
</div>
<style>
    .Usertable th
    {
        position: inherit !important;
    }
</style>
<div id="dvMymodelPopup" class="Popuphide modal" runat="server">
    <div class="modal-content" style="width: 60%; height: auto;">
        <span id="closespan" class="close" onclick="ClosePopup();">&times;</span>
        <div class="modal-body">
            <asp:GridView ID="GrdAllPo" runat="server" AutoGenerateColumns="false" Width="100%"
                OnRowDataBound="GrdAllPo_RowDataBound" CssClass="Usertable" HeaderStyle-VerticalAlign="Top"
                EmptyDataText="No Record Found">
                <Columns>
                    <asp:TemplateField HeaderText="PoNumber">
                        <ItemTemplate>
                            <a href="javascript:void(0)" onclick="ShowpurchasedSupplierFormReraisenew('<%# Eval("Flag") %>','<%# Eval("Fabric_QualityID") %>', '<%# Eval("SupplierID") %>', '<%# Eval("MasterPO_Id") %>', '', '<%# Eval("Residual") %>', '<%# Eval("CuttingWastage") %>', '<%# Eval("GreigedShrinkage") %>', '<%# Eval("CurrentStage") %>', '<%# Eval("PreviousStage") %>', '<%# Eval("IsStyleSpecific") %>',-1,'<%# Eval("stage1") %>','<%# Eval("stage2") %>','<%# Eval("stage3") %>',<%# Eval("stage4") %>,'<%# Eval("PO_Number").ToString() %>')"
                                title="po Number">
                                <%# Eval("PO_Number").ToString() %></a>
                            <asp:HiddenField ID="hdnstatus" runat="server" Value='<%# Eval("PoStatus")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UnitsName">
                        <ItemTemplate>
                            <asp:Label ID="lblpoqty" Text='<%# (Eval("ReceivedQty") == DBNull.Value  || (Eval("ReceivedQty").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("ReceivedQty"))).ToString("N0")) %>'
                                CssClass="color_black" runat="server" Style="font-weight: 600;"></asp:Label>
                            <%# Eval("UnitsName").ToString() %>'
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SupplierName">
                        <ItemTemplate>
                            <%# Eval("SupplierName")%></span>
                        </ItemTemplate>
                        <ItemStyle CssClass="ColWidthOne" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                            <span style='color: green; font-size: 11px; margin-right: 2px'>₹</span> <span style='color: #000;
                                font-weight: 600;'>
                                <%# Eval("Rate")%></span>
                        </ItemTemplate>
                        <ItemStyle CssClass="ColWidthOne" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PODate">
                        <ItemTemplate>
                            <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                OnClientClick="ConfirmFabricQuotation()" CssClass="Acceptbutton" />
                            <asp:HiddenField ID="hdnPO_Number" runat="server" Value='<%# Eval("PO_Number")%>' />
                            <%--  <asp:HiddenField ID="hdnSupplyTYpe" runat="server" Value='<%# Eval("supplytype") %>' />--%>
                            <asp:HiddenField ID="hdnMasterPO_Id" runat="server" Value='<%# Eval("MasterPO_Id")%>' />
                            <asp:HiddenField ID="hdnQueryString" runat="server" Value='<%# "Fabtype="+Eval("Flag")+"&Potype=RERAISE&currentstage="+Eval("CurrentStage")+"&previousstage="+Eval("PreviousStage")+"&IsStyleSpecific="+Eval("IsStyleSpecific")+"&Stage1="+Eval("Stage1")+"&Stage2="+Eval("Stage2")+"&Stage3="+Eval("Stage3")+"&Stage4="+Eval("Stage4")+"&colorprintdetail="+Eval("PrintName")+"&SupplierMasterID="+ Eval("SupplierID") +"&MasterPO_Id="+ Eval("MasterPO_Id") +"&FabricQualityID="+ Eval("Fabric_QualityID") +"&PoNumberPrint="+Eval("PO_Number") %>' />
                            <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                            <asp:HiddenField ID="hdnCurrentStage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnPreviousStage" runat="server" Value='<%#Eval("PreviousStage") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
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

    function ConfirmFabricQuotation() {
        if (confirm("Please confirm, you have reviewed PO!")) {
            document.getElementById("FabricQuotationForm1_confirm_value").value = "Yes";
        } else {
            document.getElementById("FabricQuotationForm1_confirm_value").value = "No";
        }
    }



 
</script>
