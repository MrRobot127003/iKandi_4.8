<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderForm.ascx.cs" Inherits="iKandi.Web.OrderForm" %>
<style type="text/css">
    .selectedRow
    {
        cursor: pointer;
        width: 100%;
        border: solid 1px black;
    }
    
    .duplicate_show
    {
        display: block;
        background-color: yellow;
        font-size: 8px;
    }
    .duplicate
    {
        display: none;
        background-color: yellow;
    }
    .divSplit1
    {
        border: solid 10px #878787;
        background-color: #FFFFFF;
        padding: 20px;
        position: fixed;
        top: 20%;
        left: 20%;
        z-index: 9999999;
        display: none;
        height: 1500px;
    }
    .order_split_table
    {
        text-align: left;
        width: 500px;
    }
    .split_inner
    {
        text-align: left;
    }
    .style20
    {
        display: none;
    }
    .item_list1 TH
    {
        text-transform: capitalize !important;
    }
    
    .secure_center_contentWrapper
    {
        text-transform: capitalize !important;
    }
    .hasDatepicker
    {
        z-index: 10000000;
    }
    
    .form_box
    {
        text-transform: capitalize !important;
    }
    input[type="text"], textarea
    {
        text-transform: capitalize !important;
    }
    
    .form_table1
    {
        background: #ffffff;
    }
    .order_form_table span
    {
        color: #575759 !important;
    }
    .CalculatedColumns div span, .biplPrice span, .CalculatedColumns span, span.currency-sign
    {
        color: Blue !important;
    }
    .TextDecoration
    {
        text-decoration: line-through;
        font-size: 13px;
    }
</style>

<link href="../../App_Themes/ikandi/ikandi.css" rel="stylesheet" type="text/css" />
<%--<link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />--%>
<%--<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>
<%--
<link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>
<script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
<script src="../../CommonJquery/Js/jquery.autocomplete.js" type="text/javascript"></script>--%>
<script type="text/javascript">

    //
    //debugger;
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';

    var CheckFistTime = '<%=bChechFirstPage%>'

    var proxy = new ServiceProxy(serviceUrl);

    var BuyerDDClientID = '<%=ddlClient.ClientID%>';

    var ParentDeptDDClientID = '<%=ddlParentDept.ClientID%>';

    var DeptDDClientID = '<%=ddlDepartment.ClientID%>';

    var txtIkandiSerialClientID = '<%=txtIkandiSerial.ClientID%>';

    var txtDescriptionClientID = '<%=txtDescription.ClientID%>';

    var txtStyleNumberClientID = '<%=txtStyleNumber.ClientID%>';

    var hiddenUrlClientID = '<%=hiddenUrl.ClientID %>';

    var hdnParentStyleNumberClientId = '<%=hdnParentStyleNumber.ClientID %>';

    var txtTotalQtyClientID = '<%=txtTotalQty.ClientID %>';

    var lblAccMgrClientID = '<%=lblAccntMgr.ClientID %>';

    var tableOrderDetailVar = "tableOrderDetail";

    var ddlModeClientID = "ddlMode";

    var txtDelInstructionClientID = '<%=txtDelInstruction.ClientID %>';

    var txtDeliverToClientID = '<%=txtDeliverTo.ClientID %>';

    var hdnAddressClientID = '<%=hdnAddress.ClientID %>';
    var hdnuseridClientID = '<%=hdnuserid.ClientID %>';
    var txtBIPLPriceClientID = '<%=txtBIPLPrice.ClientID %>';

    var hdnCostingIdClientID = '<%=hdnCostingId.ClientID %>';

    var txtOrderDateClientID = '<%=txtOrderDate.ClientID %>';

    var hdnOrderIdClientID = '<%=hdnOrderId.ClientID %>';

    var hdnOrderTypeClientID = '<%=hdnOrderType.ClientID %>';

    var hdnStyleIDClientID = '<%=hdnStyleID.ClientID %>';

    var imgPrintClientID = '<%=imgPrint.ClientID %>';

    var imagePrintClientID = '<%=imagePrint.ClientID %>';

    var imgStyleClientID = '<%=imgStyle.ClientID %>';

    var hdnClientID = '<%=hdnClientID.ClientID %>';

    var hdnOriginalClientID = '<%=hdnOriginalClientID.ClientID %>';

    var hdnOriginalDeptIDClientID = '<%=hdnOriginalDeptID.ClientID %>';

    var hdnDeptID = '<%=hdnDeptID.ClientID %>';

    var hdnNewClientID = '<%=hdnNewClientID.ClientID %>';

    var hdnNewDeptID = '<%=hdnNewDeptID.ClientID %>';

    var hdnhdnOrderSequenceClientID = '<%=hdnOrderSequence.ClientID %>';

    var pnlFormClientID = '<%=pnlForm.ClientID %>';

    var pnlForm1ClientID = '<%=pnlForm1.ClientID %>';

    var btnsentProposalClientID = '<%=btnsentProposal.ClientID %>';

    var btnsaveClientID = '<%=btnSave.ClientID %>';

    var hdnSelectedClientClientID = '<%=hdnSelectedClient.ClientID %>';

    var hdnSelectedParentDeptClientID = '<%=hdnSelectedParentDept.ClientID %>';

    var hdnSelectedDeptClientID = '<%=hdnSelectedDept.ClientID %>';

    var hdnExpectedDateClientID = '<%=hdnExpectedDate.ClientID %>';

    var txtEmailcontentClientID = '<%=txtEmailcontent.ClientID %>';

    var hdnAttachmentsClientID = '<%=hdnAttachments.ClientID %>';

    var hdnRowCountClientID = '<%=hdnRowCount.ClientID %>';

    var hdnIsSize = '<%=hdnIsSize.ClientID%>';

    var hdnPathClientId = '<%=hdnPath.ClientID %>';


    var hdnIsNewOrderId = '<%=hdnIsNewOrderId.ClientID %>';
    var BuyingHouseID = '<%=hdnBuyingHouse.ClientID %>';

    var isExpanded = false;

    var lblBiplPriceCommentsClientID = '<%=lblBiplPriceComments.ClientID %>';

    var objDDLTypeOfPacking = '<%= ddlTypeOfPacking.ClientID %>';

    var jscriptPageVariables = null;

    var selectedClient = '';

    var selectedParentDept = '';

    var selectedDept = '';

    var txtFabric;

    var color = '';

    var debugCount = 0;

    var context = $("#main_content");

    var txtStyleNumber1ClientID = '<%=txtStyleNumber1.ClientID%>';
    var txtStyleNumber2ClientId = '<%=txtStyleNumber2.ClientID%>';
    var hdnRepeatWithChangesClientID = '<%=hdnRepeatWithChanges.ClientID %>';
    var hdnParentStyleIDClientID = '<%=hdnParentStyleID.ClientID %>';
    var hdnRepeatOrderClientID = '<%=hdnRepeatOrder.ClientID %>';

    var ddlordrType = '<%=ddlordrType.ClientID%>';
    var lblbiplprice = '<%=lblbiplprice.ClientID%>';
    var txtkusakprice = '<%=txtkusakprice.ClientID%>';
    var hdnkasukaprice = '<%=hdnkasukaprice.ClientID%>';


    function GetOrderDetail() {
        //debugger;
        if ($("#" + hdnOrderIdClientID).val() > -1) {
            var OrderId = $("#" + hdnOrderIdClientID).val();

            proxy.invoke("GetOrderDetailByIdOrderForm", { orderId: OrderId },

                        function (result) {
                            //debugger;
                            var resultLenth = result.length;

                            for (var i = 0; i < result.length; i++) {
                                //alert(result[i].odBIPLPrice);
                                var BIPLPrice = parseFloat(result[i].odBIPLPrice).toFixed(2);
                                var OldBIPLPrice = parseFloat(result[i].odOldBIPLPrice).toFixed(2);
                                var IsShiped = result[i].IsShiped;

                                var j = i + 1;
                                $("#txtodBIPLPrice" + j, "#main_content").val(BIPLPrice);

                                if (BIPLPrice != OldBIPLPrice) {
                                    document.getElementById('lbltxtodBIPLPrice' + j).innerText = OldBIPLPrice;

                                    document.getElementById('lblOldBiplPriceSign' + j).style.display = "";

                                    $("#hdnOdBIPLPrice" + j, "#main_content").val(OldBIPLPrice);
                                    $("#txtodBIPLPrice" + j, "#main_content").attr("readonly", true);
                                }
                                if (IsShiped == true) {
                                    $("#txtodBIPLPrice" + j, "#main_content").attr("readonly", true);
                                    $("#txtIkandiPrice" + j, "#main_content").attr("readonly", true);
                                }

                            }

                        });

        }
    }

    $(function () {


        context = $("#main_content");

        ValidateForm();

        var biplaggtext = context.find("#" + lblBiplPriceCommentsClientID).html();

        if (biplaggtext == '' || biplaggtext == null) {

        }

        else if ($.trim(biplaggtext.toUpperCase()) == ("BIPL Agreement Pending.").toUpperCase()) {

            ($('.biplPrice', '#main_content').css('backgroundColor', '#FFCC00'));

        }

        else if ($.trim(biplaggtext.toUpperCase()) == (" Price Agreed.").toUpperCase()) {

            ($('.biplPrice', '#main_content').css('backgroundColor', '#98CB00'));

        }

        //onStyleChange();

        GetOrderDetail();

        // Method For Client change start

        context.find("#" + BuyerDDClientID).change(function () {            // 

            var clientId = $(this).val();
            //alert('Department 1');
            populateParentDepartments($(this).val(), -1, -1, 'Parent');

            setClientName();

            if (!(this).options[(this).selectedIndex].defaultSelected) {
                proxy.invoke("GetNewSerialNumber", { clientId: clientId },
                function (SerialNumber) {                // 
                    context.find("#" + txtIkandiSerialClientID).val(SerialNumber);
                });

            }

            else {
                context.find("#" + txtIkandiSerialClientID).val(document.getElementById(txtIkandiSerialClientID).defaultValue);
            }
            proxy.invoke("GetAddressByClientId", { ClientId: clientId },

                        function (result) {

                            context.find("#" + hdnAddressClientID).val(result);

                        });

        });
        // Method For Client change end


        context.find("#" + ParentDeptDDClientID).change(function () {

            var clientId = $("#" + BuyerDDClientID, "#main_content").val();

            var ParentDeptId = $(this).val();
            populateDepartments(clientId, -1, ParentDeptId, 'SubParent');

            setParentDeptName();
        });

        $("#" + ddlordrType, '#main_content').change(function () {
            // debugger;
            selectedDept = $("#" + ddlordrType).find("option:selected").text();
            //else 
            //// End of Commented By Ravi dated on 21st june 2017
            if (selectedDept == 'Kasuka') {
                document.getElementById(lblbiplprice).innerHTML = "Kasuka price";
                document.getElementById(txtkusakprice).style.display = "none";
            }
            else {
                document.getElementById(txtkusakprice).style.display = "none";
                document.getElementById(lblbiplprice).innerHTML = "Bipl Price";
            }
        });

        // On department Change start

        $("#" + DeptDDClientID, '#main_content').change(function () {

            selectedDept = $("#" + DeptDDClientID).find("option:selected").text();
            setDeptName();
            BindSizeSetOption();
        });
        // On department Change end

        // Script for each  contract start

        if (jscriptPageVariables != null && jscriptPageVariables.orderDetail != null && jscriptPageVariables.orderDetail != '') {

            var divOrderBreakDown = context.find("#divOrderBreakDown");

            divOrderBreakDown.setTemplateElement("templateBreakDown");

            divOrderBreakDown.setParam('x', 1);

            divOrderBreakDown.processTemplate(jscriptPageVariables.orderDetail);

            // context.find(".size-table").draggable();

            var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");

            var rowCount = tbRows.length - 2;

            context.find("#" + hdnRowCountClientID).val(rowCount);

            var qty = 0;

            var currentDate = new Date();

            var dateToday = currentDate.getDate() + '/' + (currentDate.getMonth() + 1) + '/' + currentDate.getFullYear();

            var txtTotalQtyClientIDObj = context.find("#" + txtTotalQtyClientID);

            txtTotalQtyClientIDObj.val(FormatingTotalQuantity(txtTotalQtyClientIDObj.val()));

            fab = tbRows.find('.fabric-type');
            len = fab.length;

            for (var i = 0; i < len; i++) {

                var objCell = $(fab[i]).parents('td');

                GetFabricQualityData(objCell, $(fab[i]).val(), "PRD", 1, i);

            }

            for (var i = 1; i <= rowCount; i++) {

                var currRow = $(tbRows.get(i + 1));

                var qty1 = 0;

                var singlesTotal = 0;

                var isFilled = 0;

                var qty = currRow.find("#txtQty" + i).val();

                currRow.find("#txtQuantityCalculated" + i).val();

                currRow.find("#subtable" + i).hide();

                for (var j = 1; j <= 15; j++) {

                    var qtyVal = currRow.find("#txtQuantity" + j + i).val();

                    if (qtyVal.length > 0) {
                        qty1 = parseInt(qty1) + parseInt(qtyVal);
                    }
                    var singlesVal = currRow.find("#txtSingles" + j + i).val();

                    if (singlesVal.length > 0) {
                        singlesTotal = parseInt(singlesTotal) + parseInt(singlesVal);
                    }
                    if (qtyVal.length > 0) {
                        isFilled = 1;
                    }
                    if ($("#" + hdnOrderIdClientID).val() > -1) {

                        if (currRow.find("#txtSize" + j + i).val().length <= 0) {

                            //manisha 18th may 2011 removed 0 for all

                            currRow.find("#txtSingles" + j + i).val("");

                            currRow.find("#txtRatio" + j + i).val("");

                            currRow.find("#txtQuantity" + j + i).val("");

                            currRow.find("#txtRatioPack" + j + i).val("");

                            //

                        }

                    }

                }

                currRow.find("#lblSinglesTotal" + i).val(singlesTotal);



                if (singlesTotal > 0) {

                    showDiff(i, singlesTotal);
                }
                if (isFilled > 0) {
                    currRow.find("#linkCreate" + i).html("EDIT");
                }

                //
                //Added By Ashish on 28/10/2014
                //                if (context.find("#" + hdnIsNewOrderId).val() == -1) {
                //                    //FillNewSizeOption(1);
                //                }
                else {

                    currRow.find("#txtSize1" + i).val("4");

                    currRow.find("#txtSize2" + i).val("6");

                    currRow.find("#txtSize3" + i).val("8");

                    currRow.find("#txtSize4" + i).val("10");

                    currRow.find("#txtSize5" + i).val("12");

                    currRow.find("#txtSize6" + i).val("14");

                    currRow.find("#txtSize7" + i).val("16");

                    currRow.find("#txtSize8" + i).val("18");

                    currRow.find("#txtSize9" + i).val("20");

                    currRow.find("#txtSize10" + i).val("22");

                    currRow.find("#txtSize11" + i).val("24");

                    currRow.find("#txtSize12" + i).val("26");

                    currRow.find("#txtSize13" + i).val("28");

                    currRow.find("#txtSize14" + i).val("30");

                    currRow.find("#txtSize15" + i).val("32");

                }

                currRow.find("#subtable" + i).hide();

                if (context.find("#" + hdnOrderIdClientID).val() == '-1') {

                    currRow.find("#txtExFactory" + i).val("");

                    currRow.find("#txtDC" + i).val("");

                    currRow.find("#split" + i).hide();

                    context.find("#" + btnsentProposalClientID).hide();

                    context.find("#btnPrint").hide();

                    context.find("td.fabric-2").hide();

                    context.find("td.fabric-3").hide();

                    context.find("td.fabric-4").hide();

                    currRow.find("#hdnMode" + i).attr("class", "required");

                }

                else {

                    var file1 = currRow.find("#hdnfilea" + i).val();

                    var file2 = currRow.find("#hdnfileb" + i).val();

                    var file3 = currRow.find("#hdnfilec" + i).val();

                    var file4 = currRow.find("#hdnfiled" + i).val();

                    if (file1 != "" && file1 != "null") {

                        currRow.find("#txtfilea" + i).show().attr("href", "/Uploads/Order/" + file1);
                    }
                    else {
                        currRow.find("#txtfilea" + i).hide();
                    }

                    if (file2 != "" && file2 != "null") {
                        currRow.find("#txtfileb" + i).show().attr("href", "/Uploads/Order/" + file2);
                    }
                    else {
                        currRow.find("#txtfileb" + i).hide();
                    }
                    if (file3 != "" && file3 != "null") {
                        currRow.find("#txtfilec" + i).show().attr("href", "/Uploads/Order/" + file3);
                    }
                    else {
                        currRow.find("#txtfilec" + i).hide();
                    }
                    if (file4 != "" && file4 != "null") {
                        currRow.find("#txtfiled" + i).show().attr("href", "/Uploads/Order/" + file4);
                    }
                    else {
                        currRow.find("#txtfiled" + i).hide();
                    }

                }

                formatiKandiPrice(i);

                // Gajendra if (parseInt(currRow.find("#txtStatusModeSequence" + i).val()) > 14) {

                if (parseInt(currRow.find("#txtStatusModeSequence" + i).val()) > 48) { //temp need to manage with DB

                    currRow.find("#txtQty" + i).attr("class", "do-not-allow-typing");
                }
                // To Handel the visibility of split button
                //Gajendra      if (parseInt(currRow.find("#txtStatusModeSequence" + i).val()) > 17) {
                if (parseInt(currRow.find("#txtStatusModeSequence" + i).val()) > 52) { //temp need to manage with DB

                    currRow.find("#split" + i).hide();
                }
            }

            if (context.find("#" + hdnhdnOrderSequenceClientID).val() >= 11) {

                context.find(".delete-row").each(function () {
                    $(this).hide();
                });
                context.find(".add-more-new").each(function () {
                    $(this).hide();
                });
            }

            if (context.find('#txtOrderDetailID1').val() == -1) {
                //Added By Ashish on 28/10/2014
                if (context.find("#" + hdnIsNewOrderId).val() == -1) {
                }
                else {
                    context.find("#txtSize11").val("4");

                    context.find("#txtSize21").val("6");

                    context.find("#txtSize31").val("8");

                    context.find("#txtSize41").val("10");

                    context.find("#txtSize51").val("12");

                    context.find("#txtSize61").val("14");

                    context.find("#txtSize71").val("16");

                    context.find("#txtSize81").val("18");

                    context.find("#txtSize91").val("20");

                    context.find("#txtSize101").val("22");

                    context.find("#txtSize111").val("24");

                    context.find("#txtSize121").val("26");

                    context.find("#txtSize131").val("28");

                    context.find("#txtSize141").val("30");

                    context.find("#txtSize151").val("32");
                }
            }
        }
        // Script for each  contract End

        context.find("input.style-number").autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumber", { dataType: "xml", datakey: "string", max: 100 });

        context.find("#" + txtStyleNumberClientID).result(function () {
            //  debugger;

            onStyleChange();
            ///  debugger;
            //BindSizeSetOptionEdit();
        });

        context.find("#" + txtIkandiSerialClientID).change(function () {
            onSerialChange();
        });

        context.find("#" + txtOrderDateClientID).change(function () {

            var rowCount = context.find("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").length - 2;

            for (var i = 1; i <= rowCount; i++) {
                calculateExWeeks(i);
            }

        });

        $(".dc").change(function () {
            onDCChange(this);

        });

        context.find("input.fabric-type", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredTradeNamesForOrder", { dataType: "xml", datakey: "string", max: 100, "width": "850px" })

        //context.find("input.fabric-type").autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredTradeNames", { dataType: "xml", datakey: "string", max: 100 });

        context.find("input.fabric-type").result(function () {

            var f = $(this).val().split('[');

            $(this).val(f[0].replace('<FONT COLOR="#595959">', ""));

            var objCell = $(this).parents('td');

            GetFabricQualityData(objCell, f[0].replace('<FONT COLOR="#595959">', ""), "PRD", 1, objCell.parents('tr').get(0).rowIndex - 1);

        });

        context.find("input.fabric-type", '#main_content').blur(function () {

            var objCell = $(this).parents('td');

            var s1 = $(this).val();

            var ss = objCell.find("label").attr("id");

            if (s1 == '') {

                document.getElementById(ss).innerText = "";

                objCell.find('.div_origin').addClass("hide_me");

                objCell.find('.div_show').addClass("hide_me");

            }

            var s2 = objCell.find('.print-number').val();

            var s3 = objCell.parents('tr').get(0).rowIndex - 1;

            GetFabricQualityData(objCell, $(this).val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);



        });



        context.find("input.fabric-type").blur(function () {



            var objCell = $(this).parents('td');

            GetFabricQualityData(objCell, $(this).val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);



        });





        context.find("input.print-number").result(function () {



            var p = $(this).val(); //.split('(');

            //$(this).val("PRD:" + p[0]);

            $(this).val("PRD:" + p);



        });



        //

        if ($("#" + hdnOrderTypeClientID).val() == "0") {

            var count = context.find("input.duplicateCount").length;

            for (var i = 0; i < count; i++) {

                //   debugger;

                var txt = $(context.find("input.duplicateCount")[i]);

                if (txt.attr("class") == "duplicate" && (txt.val() == "" || txt.val() == "0" || txt.val() == "0.0")) {

                }

                else {
                    //    debugger;
                    txt.attr("class", "duplicate_show duplicateCount");

                }

            }

            //



            var count1 = context.find("label.duplicateCount").length;

            for (var i = 0; i < count1; i++) {



                var txt = $(context.find("label.duplicateCount")[i]);

                if (txt.attr("class") == "duplicate duplicateCount") {

                    if (txt.html() == "-1" || txt.html() == "0.0") {

                    }

                    else {
                        //   debugger;
                        txt.attr("class", "duplicate_show duplicateCount");

                        if (txt.attr("id").indexOf('lbltxtExFactory') > -1 || txt.attr("id").indexOf('lbltxtDC') > -1) {

                            var test = txt.html();

                            if (test.indexOf("01 Jan 01 (Mon)") > -1) {

                                txt.attr("class", "duplicate duplicateCount");

                            }

                        }





                        var val = txt.html();

                        if (val == '')

                            val = "Blank";

                        txt.html("was: " + val);

                    }

                }

            }

        }



        context.find("input.description").autocomplete("/Webservices/iKandiService.asmx/SuggestDescription", { dataType: "xml", datakey: "string", max: 100 });



        BindControls();



        createReminderTable();

        //hidshowdiv();

        //  var s1 = $("#" + txtStyleNumberClientID, "#main_content").val();





        $("input.print-number", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrintsStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "300px",

            extraParams: {

                stno: function () {

                    return $("#" + txtStyleNumberClientID, "#main_content").val();

                },

                ClientID: function () {

                    $(this).flushCache();

                    return $("#" + BuyerDDClientID).val();

                }
            }

        });

    });

    function formatiKandiPrice(i) {

        var ikandiObj = context.find("#txtIkandiPrice" + i);

        var ikandiPrice = ikandiObj.val();

        var result = parseFloat(ikandiPrice).toFixed(2);

        ikandiObj.val(result);

    }



    function showChangedFields() {



        $("#divRemark").show();



    }



    function closeRemarks() {



        $(".text-remarks").val("");

        $(".divRemark").hide();



    }



    function SendEmail() {

    }



    function sendEmailOnEdit() {

    }
    //abhishek
    function ValidateOrderPrice(elem) {
        //debugger;
        //val(parseFloat(result.Costing.AgreedPrice).toFixed(2))
        var vals = parseFloat($(elem).val()).toFixed(2);
        // var twoPlacedFloat = parseFloat(yourString).toFixed(2)
        var OrderPrice = parseFloat((vals));
        var biplbice = parseFloat($("#" + txtBIPLPriceClientID, "#main_content").val()).toFixed(2);
        //$("#" + txtBIPLPriceClientID, "#main_content").val(parseFloat(result.Costing.AgreedPrice).toFixed(2));
        if (OrderPrice != '' && biplbice != '') {

            if (OrderPrice > biplbice) {



                alert("Kasuka though bipl price cannot be greater then bipl price " + OrderPrice);

                $(elem).val(biplbice);
                return false;




            }
            else {
                return true;
            }
        }
    }
    function OnddlOrdertypechnage() {
        //debugger;


        $("#" + txtkusakprice, "#main_content").val($("#" + txtBIPLPriceClientID, "#main_content").val());


        //        selectedDept = $("#" + ddlordrType).find("option:selected").text();
        //        if (selectedDept == 'Kasuka though BIPL') {

        //            document.getElementById(lblbiplprice).innerHTML = "Bipl Price";
        //            document.getElementById(txtkusakprice).style.display = "";
        //            
        //        }
        //        else if (selectedDept == 'Kasuka through IKANDI') {
        //            document.getElementById(lblbiplprice).innerHTML = "Kasuka through IKANDI";
        //            document.getElementById(txtkusakprice).style.display = "none";
        //        }
        //        else {
        //            document.getElementById(txtkusakprice).style.display = "none";
        //            document.getElementById(lblbiplprice).innerHTML = "Bipl Price";
        //        }

    }
    function calculateExFactoryDate(i, days, doNotChangeExFacIfSmall, IsPc_change) {

        //debugger;
        //alert(days);

        var DCDate = $("#txtDC" + i, "#main_content").val();

        var ExFacDate;

        if (DCDate.length > 0) {


            var dc_dat = new Date(ParseDateToSimpleDate(DCDate));


            var ExFacDate = dc_dat;
            ExFacDate = ExFacDate.add(-1 * parseInt(days)).days();

            var DCDate_new = new Date(ParseDateToSimpleDate(DCDate));

            if (ExFacDate >= DCDate_new) {
                //var DChdn = $("#hdnDC" + i, "#main_content").val();
                //$("#txtDC" + i, "#main_content").val(DChdn);
                //alert('ExFactory can not be Greater than DC date');
                //return;
                if (!confirm('ExFactory is Greater than DC date, Do you wish to continue!')) {
                    return false;
                }

            }

            var PCD_Date = new Date(ParseDateToSimpleDate($("#hdnPCD" + i, "#main_content").val()));
            //            debugger;
            //            if (ExFacDate <= PCD_Date) {
            //                var DChdn = $("#hdnDC" + i, "#main_content").val();
            //                $("#txtDC" + i, "#main_content").val(DChdn);
            //                alert('ExFactory can not be less than or equal to PCD date');
            //                return;
            //            }
            var orderDate = $("#" + txtOrderDateClientID, "#main_content").val();
            var order_date = new Date(ParseDateToSimpleDate(orderDate));
            var PCDyear = PCD_Date.getFullYear();
            if (PCDyear != '2001') {
                var Less_PCDdate = PCD_Date.add(-10).days();

                //                if (order_date > Less_PCDdate) {
                //                    var DChdn = $("#hdnDC" + i, "#main_content").val();
                //                    $("#txtDC" + i, "#main_content").val(DChdn);
                //                    alert('BIH date can not be less than order date');
                //                    return;
                //                }
            }
            if (order_date >= ExFacDate) {
                var DChdn = $("#hdnDC" + i, "#main_content").val();
                $("#txtDC" + i, "#main_content").val(DChdn);
                alert('ExFactory date can not be less than order date');
                return;
            }

            if (!doNotChangeExFacIfSmall || (doNotChangeExFacIfSmall && ExFacDate > new Date(ParseDateToSimpleDate($("#hdnExFactory" + i, "#main_content").val())))) {

                ExFacDate = ParseDateToDateWithDay(ExFacDate);
                $("#txtExFactory" + i, "#main_content").val(ExFacDate);
                $("#hdnPCdate" + i, "#main_content").val(IsPc_change);

            }

            else {

                //                ExFacDate = $("#txtExFactory" + i, "#main_content").val($("#hdnExFactory" + i, "#main_content").val());

                //                ExFacDate = ParseDateToDateWithDay(ExFacDate);

                ExFacDate = ParseDateToDateWithDay(ExFacDate);
                $("#txtExFactory" + i, "#main_content").val(ExFacDate);
                $("#hdnPCdate" + i, "#main_content").val(IsPc_change);


            }

        }

    }

    function calculateExWeeks(i) {
        //debugger;
        var msPERDAY = 1000 * 60 * 60 * 24 * 7;
        var dateEx = $("#txtExFactory" + i, "#main_content").val();
        var orderDate = $("#" + txtOrderDateClientID, "#main_content").val();
        var DCDate = $("#txtDC" + i, "#main_content").val();

        if (DCDate.length > 0) {

            var or_dat = new Date(ParseDateToSimpleDate(orderDate));

            var ex_date = new Date(ParseDateToSimpleDate(dateEx));

            var dc_dat = new Date(ParseDateToSimpleDate(DCDate));

            dcdate = dc_dat.getTime();

            ordate = or_dat.getTime();

            exdate = ex_date.getTime();

            var diffex = new Date();

            diffex.setTime(Math.abs(exdate - ordate));

            timediffex = diffex.getTime();

            weeksEx = Math.round(timediffex / msPERDAY);
            $("#txtWeeksToEx" + i, "#main_content").val(weeksEx);

            var diffdc = new Date();

            diffdc.setTime(Math.abs(dcdate - ordate));

            timediffdc = diffdc.getTime();

            weeksDc = Math.round(timediffdc / msPERDAY);

            $("#txtWeeksToDC" + i, "#main_content").val(weeksDc);
        }
    }



    function onPageLoad() {

        var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();

        var orderid = $("#" + hdnOrderIdClientID).val();

        proxy.invoke("GetInfoByStyleNumber", { StyleNumber: styleNumber },

        function (result) {

            var styleid = result.Style.StyleID;

            $("#" + hdnStyleIDClientID, "#main_content").val(styleid);

            $("#" + hdnAddressClientID, "#main_content").val(result.Style.client.Address);

            $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll(' + $("#" + hdnStyleIDClientID, "#main_content").val() + ',' + orderid + ',-1)');



            $("#" + hdnClientID, "#main_content").val($("#" + BuyerDDClientID, "#main_content").val());

            $("#" + hdnOriginalClientID, "#main_content").val($("#" + BuyerDDClientID, "#main_content").val());

            setClientName();
            setParentDeptName();
            setDeptName();
            //
            BindSizeSetOptionForRows();
            BindSizeSetOption();

            populateAccMgr($("#" + DeptDDClientID, "#main_content").val(), '');

            if ($("#txtFabric111", "#main_content").val() != "" || $("#txtFabric121", "#main_content").val() != "") {

                var objCell = $("#txtFabric111", "#main_content").parents('td');

                GetFabricQualityData(objCell, $("#txtFabric111", "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

            }



            if ($("#txtFabric211", "#main_content").val() != "" || $("#txtFabric221", "#main_content").val() != "") {

                $("td.fabric-2", "#main_content").show();

                var objCell = $("#txtFabric211", "#main_content").parents('td');

                GetFabricQualityData(objCell, $("#txtFabric211", "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

            }

            else {
                $("td.fabric-2", "#main_content").hide();
            }

            if ($("#txtFabric311", "#main_content").val() != "" || $("#txtFabric321", "#main_content").val() != "") {

                $("td.fabric-3", "#main_content").show();

                var objCell = $("#txtFabric311", "#main_content").parents('td');

                GetFabricQualityData(objCell, $("#txtFabric311", "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

            }

            else {
                $("td.fabric-3", "#main_content").hide();
            }
            if ($("#txtFabric411", "#main_content").val() != "" || $("#txtFabric421", "#main_content").val() != "") {
                $("td.fabric-4", "#main_content").show();

                var objCell = $("#txtFabric411", "#main_content").parents('td');

                GetFabricQualityData(objCell, $("#txtFabric411", "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

            }

            else {
                $("td.fabric-4", "#main_content").hide();
            }
        });
    }

    function setClientName() {

        selectedClient = $("#" + BuyerDDClientID, "#main_content").find("option:selected").text();

        $("#" + hdnSelectedClientClientID, "#main_content").val(selectedClient);
    }

    function setParentDeptName() {
        selectedParentDept = $("#" + ParentDeptDDClientID, "#main_content").find("option:selected").text();
        $("#" + hdnSelectedParentDeptClientID, "#main_content").val(selectedParentDept);        
    }

    function setDeptName() {
        selectedDept = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
        $("#" + hdnSelectedDeptClientID, "#main_content").val(selectedDept);
        populateAccMgr($("#" + DeptDDClientID).find("option:selected").val());
    }

    function onStyleChange() {
        debugger;

        var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();

        $(".CheckOrder").attr("style", "display:none");
        $("#" + hdnRepeatWithChangesClientID, "#main_content").val(0);

        proxy.invoke("GetInfoByStyleNumber", { StyleNumber: styleNumber },

        function (result) {
            //debugger;
            var styleid = result.Style.StyleID;
            //debugger;
            var orderid = $("#" + hdnOrderIdClientID).val();
            if (orderid == -1) {
                proxy.invoke("IsRepeatedStyle", { StyleId: styleid },

                        function (result) {
                            //debugger;

                            var IsRepeatedOrder = result;
                            if (IsRepeatedOrder != '0') {
                                $("#" + hdnRepeatOrderClientID, "#main_content").val(1);
                                $(".CheckOrder").attr("style", "display:block");

                            }

                        });
            }
            //debugger;
            var currencySign = result.Costing.CurrencySign;

            $(".currency-sign").text(currencySign);

            $("#" + hdnStyleIDClientID, "#main_content").val(styleid);

            $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll(' + $("#" + hdnStyleIDClientID, "#main_content").val() + ',-1,-1)');


            if (result.Style.SampleImageURL1 != "") {

                $("#" + imgPrintClientID, "#main_content").attr("src", "/Uploads/Style/thumb-" + result.Style.SampleImageURL1);

                $("#" + imgPrintClientID, "#main_content").show();
            }

            else if (result.Style.SampleImageURL1 == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {

                $("#" + imgPrintClientID, "#main_content").attr("src", "");

                $("#" + imgPrintClientID, "#main_content").attr("style", "display:none;");

                $("#" + imgPrintClientID, "#main_content").attr("class", "hide_me");
            }

            if (result.Style.SampleImageURL2 != "") {

                $("#" + imgStyleClientID, "#main_content").attr("src", "/Uploads/style/thumb-" + result.Style.SampleImageURL2);

                $("#" + imgStyleClientID, "#main_content").show();
            }

            else if (result.Style.SampleImageURL2 == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {

                $("#" + imgStyleClientID, "#main_content").attr("src", "");

                $("#" + imgStyleClientID, "#main_content").attr("style", "display:none;");

                $("#" + imgStyleClientID, "#main_content").attr("class", "hide_me");

            }

            var temp = result;

            if (result.Print.ImageUrl != "") {

                $("#" + imagePrintClientID, "#main_content").attr("src", "/Uploads/Print/" + result.Style.SampleImageURL1);

                $("#" + imagePrintClientID, "#main_content").show();
            }

            else if (result.Print.ImageUrl == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {

                $("#" + imagePrintClientID, "#main_content").attr("src", "");

                $("#" + imagePrintClientID, "#main_content").attr("style", "display:none;");

                $("#" + imagePrintClientID, "#main_content").attr("class", "hide_me");

            }

            var table = document.getElementById("tableOrderDetail");
            var rowCount = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").length - 2;
            for (var i = 1; i <= rowCount; i++) {
                if ($("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {

                    $("#" + hdnCostingIdClientID, "#main_content").val(result.Costing.CostingID);

                    if ((result.OrderDetail.Fabric1 != null && result.OrderDetail.Fabric1 != "") || (result.OrderDetail.Fabric1Details != null && result.OrderDetail.Fabric1Details != "")) {

                        $("#txtFabric11" + i, "#main_content").val(result.OrderDetail.Fabric1)

                        if (result.OrderDetail.Fabric1Details != null) {

                            $("#txtFabric12" + i, "#main_content").val(result.OrderDetail.Fabric1Desc)
                        }

                        var objCell = $("#txtFabric11" + i, "#main_content").parents('td');

                        GetFabricQualityData(objCell, $("#txtFabric11" + i, "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

                    }

                    var dropdownmode = $('#ddlMode' + i, "#main_content")[0];
                    onModeChange(dropdownmode);

                    if ((result.OrderDetail.Fabric2 != null && result.OrderDetail.Fabric2 != "") || (result.OrderDetail.Fabric2Details != null && result.OrderDetail.Fabric2Details != "")) {

                        $("td.fabric-2", "#main_content").show();
                        $("#txtFabric21" + i, "#main_content").val(result.OrderDetail.Fabric2)

                        if (result.OrderDetail.Fabric2Details != null) {
                            $("#txtFabric22" + i, "#main_content").val(result.OrderDetail.Fabric2Desc)
                        }

                        var objCell = $("#txtFabric21" + i, "#main_content").parents('td');

                        GetFabricQualityData(objCell, $("#txtFabric21" + i, "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

                    }

                    if ((result.OrderDetail.Fabric3 != null && result.OrderDetail.Fabric3 != "") || (result.OrderDetail.Fabric3Details != null && result.OrderDetail.Fabric3Details != "")) {

                        $("td.fabric-3", "#main_content").show();

                        $("#txtFabric31" + i, "#main_content").val(result.OrderDetail.Fabric3)

                        if (result.OrderDetail.Fabric3Details != null) {

                            $("#txtFabric32" + i, "#main_content").val(result.OrderDetail.Fabric3Desc)
                        }

                        var objCell = $("#txtFabric31" + i, "#main_content").parents('td');

                        GetFabricQualityData(objCell, $("#txtFabric31" + i, "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

                    }



                    if ((result.OrderDetail.Fabric4 != null && result.OrderDetail.Fabric4 != "") || (result.OrderDetail.Fabric4Details != null && result.OrderDetail.Fabric4Details != "")) {

                        $("td.fabric-4", "#main_content").show();

                        $("#txtFabric41" + i, "#main_content").val(result.OrderDetail.Fabric4)

                        if (result.OrderDetail.Fabric4Details != null) {
                            $("#txtFabric42" + i, "#main_content").val(result.OrderDetail.Fabric4Desc)

                        }

                        var objCell = $("#txtFabric41" + i, "#main_content").parents('td');

                        GetFabricQualityData(objCell, $("#txtFabric41" + i, "#main_content").val(), objCell.find('.print-number').val(), 1, objCell.parents('tr').get(0).rowIndex - 1);

                    }
                    $("#" + txtBIPLPriceClientID, "#main_content").val(parseFloat(result.Costing.AgreedPrice).toFixed(2));
                    $("#txtodBIPLPrice" + i, "#main_content").val(parseFloat(result.Costing.AgreedPrice).toFixed(2))


                    $("#" + BuyerDDClientID, "#main_content").val(result.Costing.ClientID);
                    if (result.Costing.DepartmentID > 0) {
                        if (orderid == -1) {
                            //alert('Department 2');
                            populateParentDepartments(result.Costing.ClientID, result.Costing.ParentDepartmentID, result.Costing.ParentDepartmentID, 'Parent');
                            populateDepartments(result.Costing.ClientID, result.Costing.DepartmentID, result.Costing.ParentDepartmentID, 'SubParent');
                        }
                        else {
                            //alert('Department 3');
                            populateParentDepartments(result.Costing.ClientID, result.Costing.ParentDepartmentID, result.Costing.ParentDepartmentID, 'Parent');
                            populateDepartments(result.Costing.ClientID, result.Costing.DepartmentID, result.Costing.ParentDepartmentID, 'SubParent');
                        }

                        $("#" + DeptDDClientID, "#main_content").val(result.Costing.DepartmentID);
                        //
                        BindSizeSetOption();
                    }
                    else {
                        //alert('Department 4');
                        populateParentDepartments(result.Costing.ClientID, result.Costing.ParentDepartmentID, result.Costing.ParentDepartmentID, 'Parent');
                        populateDepartments(result.Costing.ClientID, result.Costing.DepartmentID, result.Costing.ParentDepartmentID, 'SubParent');
                        //
                        BindSizeSetOption();
                    }
                    //
                    $("#" + hdnClientID, "#main_content").val(result.Costing.ClientID);
                    //
                    setClientName();
                    OnddlOrdertypechnage();

                    if ($("#" + hdnOrderIdClientID, "#main_content").val() == -1) {

                        if (result.Costing.ClientID > 0) {

                            proxy.invoke("GetNewSerialNumber", { clientId: result.Costing.ClientID },

                        function (SerialNumber) {
                            $("#" + txtIkandiSerialClientID, "#main_content").val(SerialNumber);
                            //debugger;
                            // if (SerialNumber != "") {

                            proxy.invoke("GetNewDescription", { styleid: styleid },

                                function (result) {
                                    //debugger;
                                    if (result != null) {
                                        // debugger;
                                        if (result.length > 0) {

                                            $("#" + txtDescriptionClientID, "#main_content").val(result);
                                        }
                                    }

                                });

                        });

                        }

                    }

                }

                else if ($("#" + txtStyleNumberClientID, "#main_content").val() == document.getElementById(txtStyleNumberClientID).defaultValue) {



                    $("#" + txtIkandiSerialClientID, "#main_content").val(document.getElementById(txtIkandiSerialClientID).defaultValue);

                    $("#" + BuyerDDClientID, "#main_content").val($("#" + hdnOriginalClientID, "#main_content").val());

                    $("#" + hdnClientID, "#main_content").val($("#" + BuyerDDClientID, "#main_content").val());


                    if (orderid == -1) {
                        //alert('Department 5');
                        populateDepartments($("#" + BuyerDDClientID, "#main_content").val(), $("#" + hdnOriginalDeptIDClientID, "#main_content").val(), -1, '');
                    }

                    $("#" + DeptDDClientID).val($("#" + hdnOriginalDeptIDClientID, "#main_content").val());

                    BindSizeSetOption();

                    var dropdownmode = $('#ddlMode' + i, "#main_content")[0];
                    onModeChange(dropdownmode);

                    setClientName();

                    $("#txtFabric11" + i, "#main_content").val(document.getElementById("txtFabric11" + i).defaultValue);

                    $("#txtFabric12" + i, "#main_content").val(document.getElementById("txtFabric12" + i).defaultValue);

                    $("#txtFabric21" + i, "#main_content").val(document.getElementById("txtFabric21" + i).defaultValue);

                    $("#txtFabric22" + i, "#main_content").val(document.getElementById("txtFabric22" + i).defaultValue);


                    $("#txtFabric11" + i, "#main_content").val(document.getElementById("txtFabric11" + i).defaultValue);

                    $("#txtFabric12" + i, "#main_content").val(document.getElementById("txtFabric12" + i).defaultValue);

                    $("#txtFabric21" + i, "#main_content").val(document.getElementById("txtFabric21" + i).defaultValue);

                    $("#txtFabric22" + i, "#main_content").val(document.getElementById("txtFabric22" + i).defaultValue);

                    if ($("#txtFabric21" + i, "#main_content").val() == "" && $("#txtFabric22" + i, "#main_content").val() == "") {
                        $("td.fabric-2", "#main_content").hide();
                    }

                    $("#txtFabric31" + i, "#main_content").val(document.getElementById("txtFabric31" + i).defaultValue);

                    $("#txtFabric32" + i, "#main_content").val(document.getElementById("txtFabric32" + i).defaultValue);

                    if ($("#txtFabric31" + i, "#main_content").val() == "" && $("#txtFabric32" + i, "#main_content").val() == "") {

                        $("td.fabric-3", "#main_content").hide();
                    }

                    $("#txtFabric41" + i, "#main_content").val(document.getElementById("txtFabric41" + i).defaultValue);

                    $("#txtFabric42" + i, "#main_content").val(document.getElementById("txtFabric42" + i).defaultValue);

                    if ($("#txtFabric41" + i, "#main_content").val() == "" && $("#txtFabric42" + i, "#main_content").val() == "") {

                        $("td.fabric-4", "#main_content").hide();
                    }
                }
            }

        }, null, false, false);

        var s2 = $("#" + txtStyleNumberClientID, "#main_content").val();
        //s2 = 

        //alert("mani1-" + s2);

        $("input.print-number", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrintsStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "300px",

            extraParams: {

                stno: function () {
                    // return s2;
                    return $("#" + txtStyleNumberClientID, "#main_content").val();
                },

                ClientID: function () {

                    $(this).flushCache();

                    return $("#" + BuyerDDClientID).val();
                }
            }

        });

    }

    var OldSelectedValue;
    function GetCurrentValue(e) {
        OldSelectedValue = e.options[e.selectedIndex].value;
    }
    function onModeChange(srcElem) {
        debugger;
        //  alert('onModeChange');
        //       
        var CheckBuyingHouse = $("#" + BuyingHouseID, "#main_content").val();
        var objRow = $(srcElem).parents("tr");

        var i = objRow.get(0).rowIndex - 1;

        var OrderDetailId = $('#txtOrderDetailID' + i, "#main_content").val();

        if (OldSelectedValue == "37" || OldSelectedValue == "38") {
            alert('Please Take help from management to change in this mode from MO.');
            $(srcElem).val(OldSelectedValue);
            return false;
        }

        if ($(srcElem).val() == -1) {
            $("#hdnMode" + i).val("");
        }

        if ($(srcElem).val() != -1) {
            // var ddl = $('#ddlMode' + i, "#main_content");
            //
            var selectedValue = $('#ddlMode' + i, "#main_content").val();

            var selectedText = $('#ddlMode' + i, "#main_content").find("option:selected").text();
            if (selectedText == 'L-A/F(SH-FOB)' || selectedText == 'L-S/F(SH-FOB)') {
                alert('Please Take help from management to change in this mode from MO.');
                $(srcElem).val(OldSelectedValue);
                return false;
            }
            if (i == 1) {
                proxy.invoke("GetOrderPackingType", { modeValue: $('#ddlMode' + 1, "#main_content").val() },
                        function (result) {

                            $('#' + objDDLTypeOfPacking).val(result);
                        });
            }
            var oo = selectedText;
            if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1) {
                //   alert(oo);
            }
            if (selectedText.indexOf('A/F') > -1) {
                strmode = "AF";
            }
            else if (selectedText.indexOf('A/H') > -1) {
                strmode = "AH";
            }
            else if (selectedText.indexOf('S/F') > -1) {
                strmode = "SF";
            }
            else if (selectedText.indexOf('S/H') > -1) {
                strmode = "SH";
            }
            else if (selectedText.indexOf('S/BH') > -1) {
                strmode = "SH";
            }
            else if (selectedText.indexOf('A/BH') > -1) {
                strmode = "AH";
            }
            var rowCount = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").length - 2;

            var costingId = $("#" + hdnCostingIdClientID).val();
            if (selectedText.indexOf('/H') > -1) {

                $("#" + txtDelInstructionClientID, "#main_content").val("Hanging");
            }
            else if (selectedText.indexOf('/BH') > -1) {

                $("#" + txtDelInstructionClientID, "#main_content").val("Hanging");
            }

            else {
                $("#" + txtDelInstructionClientID, "#main_content").val("Flat");
            }
            if (selectedText.indexOf("D") > -1) {

                $("#" + txtDeliverToClientID).val($("#" + hdnAddressClientID).val());
                strmode = "FOB";
            }
            else {
                $("#" + txtDeliverToClientID, "#main_content").val("iKandi");
            }
            var tempVar = '';

            if (selectedText.indexOf('FACT') > -1) {

                // tempVar = "yes";

                strmode = "Fact";

            }

            ///////////// first
            //
            $("#hdnMode" + i, "#main_content").val(strmode);
            //
            //   

            if ($("#" + hdnOrderIdClientID).val() == -1) {



                //    alert('First' + '-----' + strmode);


                if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1 && CheckBuyingHouse == '1') {

                    if (CheckFistTime == 'False' && CheckBuyingHouse == '1') {
                        if (confirm('Do you wish to update price.')) {

                            proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: selectedText },

                    function (result) {

                        //    alert('1 : ' + 'mode= ' + strmode + '  costing Id ' + costingId + 'BIPL Value' + +parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        $("#txtIkandiPrice" + i, "#main_content").val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                    });

                        }

                    }
                    else {

                        proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: selectedText },

                    function (result) {

                        //    alert('1 : ' + 'mode= ' + strmode + '  costing Id ' + costingId + 'BIPL Value' + +parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        $("#txtIkandiPrice" + i, "#main_content").val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                    });
                    }

                }

                else {

                    proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: selectedText },

                    function (result) {

                        //    alert('1 : ' + 'mode= ' + strmode + '  costing Id ' + costingId + 'BIPL Value' + +parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        $("#txtIkandiPrice" + i, "#main_content").val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                    });

                }



            }

            ///////////// first end 



            //Start second

            else if ($("#" + hdnOrderIdClientID).val() > 0) {

                //  alert('Second' + '-----' + strmode);

                //  if ($("#txtIkandiPrice" + i, "#main_content").val() == '' || parseInt($("#txtIkandiPrice" + i, "#main_content").val()) == 0) {



                if (selectedText.indexOf('L') > -1 && (selectedText.indexOf('(FOB)') > -1 || selectedText.indexOf('FOB') == 9) && CheckBuyingHouse == '1') {


                    if (confirm('Do you wish to update price.')) {

                        proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: selectedText },

                        function (result) {



                            //   alert('2 : ' + parseFloat(result.Costing.iKandiPrice).toFixed(2));



                            $("#txtIkandiPrice" + i, "#main_content").val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        });

                    }

                    //end
                }

                else {

                    if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(CIF)') > -1) {

                        var tempvar = 100;

                    }

                    else {

                        proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: selectedText },

                        function (result) {



                            //   alert('2 : ' + parseFloat(result.Costing.iKandiPrice).toFixed(2));



                            $("#txtIkandiPrice" + i, "#main_content").val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        });

                    }



                }


            }

            //End second


            if ($("#" + hdnOrderIdClientID).val() == -1) {



                CalculateDeliveryDate(strmode, i, selectedValue);

            }



            if ($("#" + hdnOrderIdClientID).val() > -1) {

                //

                proxy.invoke("GetModeDays", { modeValue: selectedValue },

                        function (result) {

                            //debugger;

                            // ADD BY RAVI
                            //                            if (($("#" + hdnOrderIdClientID).val() > -1) && (OrderDetailId > -1)) {
                            ////                                if (confirm('Do you want to change PC Date also.')) {
                            ////                                    calculateExFactoryDate(i, result, true, 1);
                            ////                                }
                            ////                                else {
                            ////                                    calculateExFactoryDate(i, result, true, 0);
                            ////                                }
                            //                            }
                            //                            else {
                            //                                calculateExFactoryDate(i, result, true, 0);
                            //                            }
                            // END
                            calculateExFactoryDate(i, result, true, 0);
                            calculateExWeeks(i);

                        });

            }

        }

    }

    function SetMode(s) {
        //
        var srcElem = s;
        var objRow = $(srcElem).parents("tr");

        var i = s //objRow.get(0).rowIndex - 1;







        if ($(srcElem).val() == -1) {



            $("#hdnMode" + i).val("");



        }



        if ($(srcElem).val() != -1) {


            var selectedValue = $('#ddlMode' + i, "#main_content").val();

            var selectedText = $('#ddlMode' + i, "#main_content").find("option:selected").text();

            var oo = selectedText;







            if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1) {



                //   alert(oo);



            }







            if (selectedText.indexOf('A/F') > -1) {



                strmode = "AF";



            }

            else if (selectedText.indexOf('A/H') > -1) {



                strmode = "AH";



            }

            else if (selectedText.indexOf('S/F') > -1) {



                strmode = "SF";



            }







            else if (selectedText.indexOf('S/H') > -1) {



                strmode = "SH";



            }

            else if (selectedText.indexOf('S/BH') > -1) {



                strmode = "SH";



            }









            else if (selectedText.indexOf('A/BH') > -1) {



                strmode = "AH";



            }



            var rowCount = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").length - 2;

            var costingId = $("#" + hdnCostingIdClientID).val();

            debugger;

            if (selectedText.indexOf('/H') > -1) {



                $("#" + txtDelInstructionClientID, "#main_content").val("Hanging");



            }

            else if (selectedText.indexOf('/BH') > -1) {



                $("#" + txtDelInstructionClientID, "#main_content").val("Hanging");

            }

            else {



                $("#" + txtDelInstructionClientID, "#main_content").val("Flat");



            }



            if (selectedText.indexOf("D") > -1) {

                $("#" + txtDeliverToClientID).val($("#" + hdnAddressClientID).val());



                // if (tempVar!="yes")

                strmode = "FOB";



            }



            else {



                $("#" + txtDeliverToClientID, "#main_content").val("iKandi");



            }





            var tempVar = '';

            if (selectedText.indexOf('FACT') > -1) {

                // tempVar = "yes";

                strmode = "Fact";



            }
            // 
            $("#hdnMode" + i, "#main_content").val(strmode);
        }
    }


    function onDCChange(srcElem) {

        //debugger;

        var objRow = $(srcElem).parents("tr");

        var i = objRow.get(0).rowIndex - 1;

        var selectedValue = $('#ddlMode' + i, "#main_content").val();

        var statusModeID = $('#txtStatusModeID' + i, "#main_content").val();

        var OrderDetailId = $('#txtOrderDetailID' + i, "#main_content").val();

        proxy.invoke("GetModeDays", { modeValue: selectedValue },

            function (result) {
                //debugger;
                //calculateExFactoryDate(i, result, ((statusModeID == 26 || statusModeID <= 12) ? false : true));
                // ADD BY RAVI
                //                if (($("#" + hdnOrderIdClientID).val() > -1) && (OrderDetailId > -1)) {
                //                    if (confirm('Do you want to change PC Date also.')) {
                //                        calculateExFactoryDate(i, result, ((statusModeID == 26 || statusModeID <= 12) ? false : true), 1);
                //                    }
                //                    else {
                //                        calculateExFactoryDate(i, result, ((statusModeID == 26 || statusModeID <= 12) ? false : true), 0);
                //                    }
                //                }
                //                else {
                //                    calculateExFactoryDate(i, result, ((statusModeID == 26 || statusModeID <= 12) ? false : true), 0);
                //                }
                // END
                calculateExFactoryDate(i, result, ((statusModeID == 26 || statusModeID <= 12) ? false : true), 0);
                calculateExWeeks(i);

            });

    }



    function onSerialChange() {

        // 

        var orderid = $("#" + hdnOrderIdClientID).val();

        var serialnumber = $("#" + txtIkandiSerialClientID).val();

        var defaultSerialnumber = document.getElementById(txtIkandiSerialClientID).defaultValue;

        var type = 0;



        if (orderid == -1) {

            type = 1

        }

        else {

            type = 2;

        }



        proxy.invoke("CheckExistingSerialNumber", { OrderID: orderid, SerialNumber: serialnumber, Type: type },

            function (result) {

                if (result == 1) {

                    alert("SerialNumber already exists!! Please choose different Serial Number");

                    $("#" + txtIkandiSerialClientID).val(defaultSerialnumber);

                }

            });



    }



    function CalculateDeliveryDate(strmode, i, selectedValue) {
        //
        //debugger;
        var mode = selectedValue;
        var OrderDetailId = $("#txtOrderDetailID" + i).val();
        proxy.invoke("GetDefaultLeadTime", { mode: mode },

         function (LeadTime) {
             //debugger;
             var dd = new Date(ParseDateToSimpleDate($("#" + hdnExpectedDateClientID).val()));

             dd = dd.add(parseInt(LeadTime) * 7).days();

             $("#txtDC" + i).val(ParseDateToDateWithDay(dd));
             $("#hdnDC" + i, "#main_content").val(ParseDateToDateWithDay(dd));

             proxy.invoke("GetModeDays", { modeValue: selectedValue },

                    function (result) {
                        //debugger

                        // ADD BY RAVI
                        //                        if ($("#" + hdnOrderIdClientID).val() > -1) {
                        ////                            if (confirm('Do you want to change PC Date also.')) {
                        ////                                calculateExFactoryDate(i, result, true, 1);
                        ////                            }
                        ////                            else {
                        ////                                calculateExFactoryDate(i, result, true, 0);
                        ////                            }
                        //                        }
                        //                        else {
                        //                            calculateExFactoryDate(i, result, true, 0);
                        //                        }
                        // END
                        calculateExFactoryDate(i, result, true, 0);
                        calculateExWeeks(i);

                    });

         });

    }

    function populateParentDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        //
        //debugger;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, ParentDeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", false, ParentDeptId, onPageError, setParentDeptName)

//        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
//            jscriptPageVariables.selectedDeptID = '';
    }


    function populateDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        //
        //debugger;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", false, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';
    }



    function populateAccMgr(departmentId) {



        proxy.invoke("GetClientAccMgrByClientID", { DepartmentId: departmentId },

            function (result) {

                var accMgr = "";

                for (var i = 0; i < result.length; i++) {



                    if (i == 0)

                        accMgr = result[i].FullName;

                    if (i > 0)

                        accMgr = accMgr + ", " + result[i].FullName;

                }

                $("#" + lblAccMgrClientID, "#main_content").text(accMgr);

            });



    }



    function checkSplitValues() {
        //debugger;
        var count = $("#tblsplit").find("#hdnrowindex").val();

        var value = $("#ordersplit").find("#splitValue").val();

        var qty = $("#txtQty" + count).val();

        var newQty = 0;



        for (var i = 1; i <= value; i++) {

            if ($("#tblsplit").find("#splitValu" + i).val() != "") {

                newQty = parseInt(newQty) + parseInt($("#tblsplit").find("#splitValu" + i).val());
                if ($("#splitValu" + i).val() == 0 || $("#splitValu" + i).val() == "" || $("#splitValu" + i).val() < "1") {
                    alert("Please Fill Split quantity is Grater than Zero")
                    return false;
                }
            }
            else {
                if ($("#splitValu" + i).val() == "") {
                    alert("Please Fill Split quantity is Grater than Zero")
                    return false;
                }
            }

        }



        if (qty == 0 || isNaN(qty)) {

            alert("Some Error Occurs While split quantities");

            return false;

        }

        else if (newQty == 0) {

            alert("Please fill split quantities");

            return false;

        }

        else if (newQty > qty) {
            alert(newQty, qty)
            alert("Split quantities cannot be more than " + qty);

            return false;

        }

        else if (newQty < qty) {

            alert("Split quantities cannot be less than " + qty);

            return false;

        }

        else {

            return true;

        }

    }



    function addsplitTableRow(srcElem) {

        // manisha

        //


        var objRow = $(srcElem).parents("tr");

        var rowindex = $(objRow).find("#hdnrowindex").val();

        var value = $(objRow).find("#splitValue").val();

        var count = rowindex - 1;

        //yaten

        var count = $("#tblsplit").find("#hdnrowindex").val();

        var qty = $("#txtQty" + count).val();

        if (document.getElementById('ex') != null || document.getElementById('ex') != undefined) {

            document.getElementById('ex').innerHTML = "Total QTY :" + qty.toString();

        }

        //end

        for (var i = 1; i <= value; i++) {



            var row = $("#tblsplit tr").filter("tr:last").clone(true).insertAfter($("#tblsplit tr").filter("tr:last"));

            var newLastRow = $("#tblsplit tr").filter("tr:last");

            newLastRow.find("input:first").focus();

            newLastRow.find("input:first").attr("class", "split-values");

            newLastRow.find("#btnOk").hide();

            newLastRow.find("#newLable").html("Split" + i);

            //   newLastRow.find("#ext").hide();

            newLastRow.find("#ex").hide();

            var id = newLastRow.find("input").attr("id");

            var id1 = newLastRow.find("label").attr("id");

            var j = i - 1;

            newLastRow.find("input").attr("id", id.substring(0, id.length - j.toString().length) + i);

            newLastRow.find("label").attr("id", id1.substring(0, id1.length - j.toString().length) + i);

            newLastRow.find("input").val("");



            newLastRow.show();

            newLastRow.find("input").attr("keydown", "test2(this);");



        }



        $(objRow).find("#splitValue").attr("disabled", "true");

        $(objRow).find("#btnOk").attr("disabled", "true");

        $("#ordersplit").find("#submit").removeAttr("disabled");

        $("#" + pnlForm1ClientID).attr("class", "divSplit");

    }



    function test2(elemt) {

        var text = elemt.id.toString();

        var exid = elemt.id.toString().replace("splitValu", "e");

        //        var leb = document.getElementById(exid);



        test1(text, exid);



    }







    function test1(txtID, lableId) {

        var count = $("#tblsplit").find("#hdnrowindex").val();

        var value = $("#ordersplit").find("#splitValue").val();

        var temp = value;

        var qty = $("#txtQty" + count).val();

        var newQty = 0;

        var c = 0;

        var sum = 0;

        $("#tblsplit").find("lableId").visible = "false";



        for (var i = 1; i <= value; i++) {



            if ($("#tblsplit").find("#splitValu" + i).val() != "") {

                newQty = parseInt(newQty) + parseInt($("#tblsplit").find("#splitValu" + i).val());

                var ss = qty - newQty.toString();





                c = 1;

            }

        }

        for (var a = 1; a <= value; a++) {

            if ($("#tblsplit").find("#splitValu" + a).val() == "")

            { sum = sum + 1; }



        }

        if (sum == temp) {

            document.getElementById('ext').innerHTML = "Splited QTY: 0";

        }

        for (var k = 1; k <= value; k++)

        { $("#tblsplit").find("#e" + k).hide(); document.getElementById('ext').visible = "false"; }

        for (var j = 1; j <= value; j++) {

            if (ss >= 0) {

                $("#tblsplit").find("#e" + j).html("Remaining QTY :" + ss);

                var d = qty - ss;

                if (c == 1)

                    document.getElementById('ext').visible = "true";

                if (c == 0)

                    document.getElementById('ext').innerHTML = "";

                if (ss >= 0)

                    document.getElementById('ext').innerHTML = "Splited QTY:" + d;



                var ff = $("#tblsplit").find("#e" + j).attr("id");

                if (lableId == ff) {

                    $("#tblsplit").find("#e" + j).show();

                }

            }

        }



        if (newQty == 0) {

            return false;



        }

        else if (newQty > qty) {

            document.getElementById('ext').innerHTML = "More Than Total QTY";

            alert("Split quantities cannot be more than " + qty);

            return false;



        }

        else {



            return true;

        }













    }





    function test(txtID, lableId) {

        //yatendra



        var count = $("#tblsplit").find("#hdnrowindex").val();

        var value = $("#ordersplit").find("#splitValue").val();

        var temp = value;

        var qty = $("#txtQty" + count).val();

        var newQty = 0;

        var c = 0;

        var sum = 0;

        $("#tblsplit").find("lableId").visible = "false";



        for (var i = 1; i <= value; i++) {



            if ($("#tblsplit").find("#splitValu" + i).val() != "") {

                newQty = parseInt(newQty) + parseInt($("#tblsplit").find("#splitValu" + i).val());

                var ss = qty - newQty.toString();

                c = 1;

            }

        }

        for (var a = 1; a <= value; a++) {

            if ($("#tblsplit").find("#splitValu" + a).val() == "")

            { sum = sum + 1; }



        }

        if (sum == temp)

            document.getElementById('ext').innerHTML = "Splited QTY: 0";

        for (var k = 1; k <= value; k++)

        { $("#tblsplit").find("#e" + k).hide(); document.getElementById('ext').visible = "false"; }

        for (var j = 1; j <= value; j++) {

            if (ss >= 0) {

                $("#tblsplit").find("#e" + j).html("Remaining QTY :" + ss);

                var d = qty - ss;

                if (c == 1)

                    document.getElementById('ext').visible = "true";

                if (c == 0)

                    document.getElementById('ext').innerHTML = "";

                if (ss >= 0)

                    document.getElementById('ext').innerHTML = "Splited QTY:" + d;



                var ff = $("#tblsplit").find("#e" + j).attr("id");

                if (lableId == ff) {

                    $("#tblsplit").find("#e" + j).show();

                }

            }

        }



        if (newQty == 0) {

            return false;



        }

        else if (newQty > qty) {

            document.getElementById('ext').innerHTML = "More Than Total QTY";

            alert("Split quantities cannot be more than " + qty);

            return false;



        }

        else {



            return true;

        }



    }

    //added by abhishek on 14/8/2015--------------------------------------//
    var getSelectedValue;
    function getComboA(sel) {

        getSelectedValue = sel.value;
    }

    function addRowFromsplitTable() {
        //debugger;
        var count = $("#tblsplit").find("#hdnrowindex").val();

        var orderSplitSplittedValue = $('#ordersplit #splitValu1').val();

        $("#txtQty" + count).val(orderSplitSplittedValue);

        $("#txtIsSplit" + count).val("0");

        $("#txtIsSplitted" + count).val("1");

        $("#txtIsQuantityInc" + count).val("1");
        //$("#hdnSortType" + count).val(document.getElementById('ddlSortType').value);
        $("#hdnSortType" + count).val(getSelectedValue);





        //  var sorType = document.getElementById('ddlSortType').value;
        var sorType = getSelectedValue;
        //-----------end by Abhishek-------------------------------------------------//
        var objOrderTable = null;

        objOrderTable = $("#" + tableOrderDetailVar);

        objOrderTable.find("tr").filter(":not(.size-table tr)").each(function () {

            var row = $(this);

            row.find("input.hdnSort").each(function () {

                $(this).val(sorType);

            });

        });



        var newcount = parseInt(count) + 1;
        //var newcount = parseInt(count);

        updateSizeTableValues(objOrderTable.find("tr").filter(":not(.size-table tr)").filter("tr:eq(" + newcount + ")"), count, orderSplitSplittedValue);

        var value = $("#ordersplit").find("#splitValue").val();

        window.onunload = null;

        for (var i = 2; i <= value; i++) {
            //
            if (i == 10)

                var newLastRow = objOrderTable.find("tr").filter("tr:last");

            var rowCount = objOrderTable.find("tr").filter(":not(.size-table tr)").length - 2;

            var newRowCount = parseInt(rowCount) + 1;

            objOrderTable.find("tr").filter(":not(.size-table tr)").filter("tr:eq(" + newcount + ")").clone(true).insertAfter($("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").filter("tr:last"));

            var newLastRow = objOrderTable.find("tr").filter(":not(.size-table tr)").filter("tr:last");


            // Changed to Generate Proper Control Updated By Sanjeev on dated 11 Aug 2021
            //var rowCountValue = newcount.toString().length;
            var rowCountValue = parseInt(count).toString().length;
            // End of Code
           

            newLastRow.find("input:first").focus();



            newLastRow.find("input,select,a,table").each(function () {
                //
                var objThis = null;

                objThis = $(this);

                var name = objThis.attr("name");



                objThis.attr("name", name.substring(0, name.length - rowCountValue) + (rowCount + 1));

                var id = objThis.attr("id");

                objThis.attr("id", id.substring(0, id.length - rowCountValue) + (rowCount + 1));

                window.onunload = null;

            });

            //7/11/2014
            newLastRow.find("form,div,a,table").each(function () {

                var objThis = null;

                objThis = $(this);

                // Ashish on 18/11/2014

                var name = objThis.attr("id");



                objThis.attr("name", name.substring(0, name.length - rowCountValue) + (rowCount + 1));

                var id = objThis.attr("id");

                objThis.attr("id", id.substring(0, id.length - rowCountValue) + (rowCount + 1));

                window.onunload = null;

            });








            newLastRow.find("input.order-detail-size-id").each(function () {

                $(this).val("-1");

                window.onunload = null;

            });



            // mani

            newLastRow.find("#txtOrderDetailID" + (rowCount + 1)).val("-1");

            newLastRow.find("#hdnParentOrderDetailID" + (rowCount + 1)).val($("#txtOrderDetailID" + (count)).val());

            newLastRow.find("#imgLine").val($("#txtOrderDetailID" + (count)).val());

            newLastRow.find("#txtIsDeleted" + (rowCount + 1)).val("0");

            newLastRow.find("#subtable" + (rowCount + 1)).hide();

            newLastRow.find("#txtIsSplit" + (rowCount + 1)).val("1");

            newLastRow.find("#txtIsSplitted" + (rowCount + 1)).val("0");

            newLastRow.find("#txtIsQuantityInc" + (rowCount + 1)).val("0");

            //

            newLastRow.find("#hdnSortType" + (rowCount + 1)).val(sorType);

            newLastRow.find("#txtQty" + (rowCount + 1)).val($("#ordersplit" + " #splitValu" + i).val());

            newLastRow.find("#txtDC" + (rowCount + 1)).attr("class", " th date_style table_element_style required");

            // newLastRow.find("#ddlMode" + (rowCount + 1)).val($("#ddlMode1").val());

            var value1 = newLastRow.find("#hdnManualNo" + (rowCount + 1)).val();

            newLastRow.find("#hdnManualNo" + (rowCount + 1)).val(value1 + "." + rowCount);

            newLastRow.find("#btnDeleteRow").show();

            newLastRow.find(".splitClass").hide();

            newLastRow.find(".splitClass").attr("class", "splitClass hide_me");

            //split{$P.x}



            window.onunload = null;



            updateSizeTableValues(newLastRow, newRowCount, $("#ordersplit" + " #splitValu" + i).val());





            var s3 = $("#" + txtStyleNumberClientID, "#main_content").val();

            //s3 =

            //alert("man3-" + s3);



            $("input.fabric-type", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricType", { dataType: "xml", datakey: "string", max: 100 });

            $("input.print-number", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrintsStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "300px",

                extraParams: {

                    stno: function () {

                        $(this).flushCache();

                        // return s3;

                        return $("#" + txtStyleNumberClientID, "#main_content").val();



                    },

                    ClientID: function () {

                        $(this).flushCache();

                        return $("#" + BuyerDDClientID).val();

                    }

                }

            });





            $("input.th", "#main_content").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });



            newLastRow.show();







        }


        //
        updateQuantity();

        $("#ordersplit").hide();



        //  calnceledSplitTable();

        closeSplitTable();

    }





    function splitOrder(srcElem) {



        var objRow = $(srcElem).parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        $("#tblsplit").find("#hdnrowindex").val(rowindex);

        $("#tblsplit").find("#hdnquantity").val(objRow.find("#txtQty" + rowindex).val());

        $("#tblsplitdtl").find("#lblLinenoSplit").html(objRow.find("#txtLineItemNumber" + rowindex).val());

        $("#tblsplitdtl").find("#lblContractNoSplit").html(objRow.find("#txtContractNumber" + rowindex).val());

        $("#ordersplit").find("#submit").attr("disabled", "true");

        $("#ordersplit").show();

        $("#" + pnlForm1ClientID).show();

        $("#" + pnlForm1ClientID).attr("class", "divSplit1");

    }



    function calnceledSplitTable() {

        // 

        $("#tblsplit tr:gt(0)").remove();

        $("#tblsplit").find("#hdnquantity").val("0");

        $("#tblsplit").find("#splitValue").val("0");

        $("#tblsplit").find("#splitValue").attr("disabled", false);

        $("#ordersplit").find("#submit").attr("disabled", true);

        $("#ordersplit").find("#btnOk").attr("disabled", false);

        $("#ordersplit").hide();

        $("#" + pnlForm1ClientID).hide();

        $("#" + pnlForm1ClientID).attr("class", "divSplit");

    }



    function addRow(objRow) {

        //
        //

        debugger;

        var rowCount = $("#" + tableOrderDetailVar + " tr", "#main_content").filter(":not(.size-table tr)").length - 2;

        var row = $("#" + tableOrderDetailVar + " tr", "#main_content").filter(":not(.size-table tr)").filter("tr:last").clone(true).insertAfter($("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").filter("tr:last"));

        var newLastRow = $("#" + tableOrderDetailVar + " tr", "#main_content").filter(":not(.size-table tr)").filter("tr:last");

        var rowCountlength = rowCount.toString().length;



        newLastRow.find("input:first").focus();



        newLastRow.find("input,select,a,table").each(function () {

            var objThis = null;

            objThis = $(this);

            //var objClass = objThis.attr("class");

            var name = objThis.attr("name");

            var substrval = name.substring(name.length - rowCountlength, name.length)

            if (name.indexOf("_") > -1) {

                var nam1 = name.split("_");

                objThis.attr("name", nam1[0] + "_" + (rowCount + 1));

            }

            else {

                var j = rowCount;

                if (substrval == rowCount) {

                    objThis.attr("name", name.substring(0, name.length - rowCountlength) + (rowCount + 1));

                }

                else {

                    objThis.attr("name", name.substring(0, name.length - 1) + (rowCount + 1));

                }



            }

            var newName = objThis.attr("name");

            var id = objThis.attr("id");



            objThis.attr("id", id.substring(0, id.length - rowCountlength) + (rowCount + 1));



        });



        newLastRow.find("label").each(function () {

            //yaten

            var id = $(this).attr("id");

            $(this).attr("id", id.substring(0, id.length - 1) + (rowCount + 1));



        });



        newLastRow.find(".redBtn").each(function () {

            var objThis = null;

            objThis = $(this);

            var name = objThis.attr("id");

            objThis.attr("style", "display:none");

        });

        newLastRow.find(".blueBtn").each(function () {

            var objThis = null;

            objThis = $(this);

            var name = objThis.attr("id");

            objThis.attr("style", "display:block");

        });

        // 7/11/2014
        newLastRow.find("div").each(function () {

            //yaten

            var id = $(this).attr("id");

            $(this).attr("id", id.substring(0, id.length - 1) + (rowCount + 1));



        });



        newLastRow.find("#hdnSizeTotalQty" + (rowCount + 1)).val("0");



        newLastRow.find("input.order-detail-size-id").each(function () {

            var objThis = null;

            objThis = $(this);

            objThis.val("-1");

        });





        newLastRow.find(".size-singles,.size-ratio,.size-ratiopack,.singles-total,.size-quantity").each(function () {

            var objThis = null;

            objThis = $(this);

            //manisha 2011 removed 0

            objThis.val("");



        });

        // 

        newLastRow.find("#lblSinglesTotal" + (rowCount + 1)).val("0");

        newLastRow.find("#txtOrderDetailID" + (rowCount + 1)).val("-1");

        newLastRow.find("#txtIsDeleted" + (rowCount + 1)).val("0");

        newLastRow.find("#linkCreate" + (rowCount + 1)).html("CREATE");

        newLastRow.find("#subtable" + (rowCount + 1)).hide();

        newLastRow.find("#txtDC" + (rowCount + 1)).attr("class", "th  table_element_style DC")

        newLastRow.find("#ddlMode" + (rowCount + 1)).val($("#ddlMode1").val());

        var value = newLastRow.find("#hdnManualNo" + (rowCount + 1)).val();

        newLastRow.find("#hdnManualNo" + (rowCount + 1)).val("N" + "." + rowCount);

        newLastRow.find("#btnDeleteRow").show();











        //  newLastRow.find("#ddlMode" + (rowCount + 1)).val($("#ddlMode1").val()).remove('option[text="D(F"]');

        // ).remove('option[text="select one"]')
        //
        //    var yaten = newLastRow.find("#ddlMode" + (rowCount + 1)).val($("#ddlMode1").val());



        $("input.fabric-type", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredTradeNames", { dataType: "xml", datakey: "string", max: 100, "width": "850px" })



        var s4 = $("#" + txtStyleNumberClientID, "#main_content").val();

        //s4 =

        //alert("mani4-" + s4);



        $("input.print-number", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrintsStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "300px",

            extraParams: {

                stno: function () {

                    $(this).flushCache();

                    // return s4;

                    return $("#" + txtStyleNumberClientID, "#main_content").val();



                },

                ClientID: function () {

                    $(this).flushCache();

                    return $("#" + BuyerDDClientID).val();

                }

            }

        });



        $("input.print-number", "#main_content").result(function () {

            var p = $(this).val(); //.split('(');

            //$(this).val("PRD:" + p[0]);

            $(this).val("PRD:" + p);



        });



        $("input.th", "#main_content").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

        newLastRow.show();

        updateQuantity();
        //
        //FillNewSizeOption(1);
        //hidshowdiv();
        //BindSizeSetOptionEdit();

        $("#" + hdnRowCountClientID).val(rowCount + 1);



    }



    function closeSplitTable() {

        //yaten

        document.getElementById('ext').innerHTML = "Splited QTY: 0";

        document.getElementById('ex').innerHTML = "";

        $("#tblsplit tr:gt(0)").remove();

        $("#tblsplit").find("#hdnquantity").val("0");

        $("#tblsplit").find("#splitValue").val("0");

        $("#tblsplit").find("#splitValue").attr("disabled", false);

        $("#ordersplit").find("#submit").attr("disabled", true);

        $("#ordersplit").find("#btnOk").attr("disabled", false);

        $("#ordersplit").hide();

        $("#" + pnlForm1ClientID).hide();

        $("#" + pnlForm1ClientID).attr("class", "divSplit");

    }





    function deleteRow(srcElem) {

        //

        var objRow = $(srcElem).parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        var element = objRow.find("#txtIsDeleted" + rowindex);

        if (rowindex == 1) {

            alert("Sorry you can not delete first row");



        }

        else {

            element.val("1");

            objRow.hide();

            //objRow.remove();

            $("#" + hdnRowCountClientID).val(rowindex - 1);

        }

    }





    function updateQuantity() {

        //debugger;
        var rowCount = $("#" + tableOrderDetailVar + " tr", "#main_content").filter(":not(.size-table tr)").length - 2;

        var qty = 0;

        for (var i = 1; i <= rowCount; i++) {


            var txtQty = $("#txtQty" + i, "#main_content").val();

            if (txtQty.toString().length > 0) {

                qty = parseInt(qty) + parseInt(txtQty);

            }

        }

        $("#" + txtTotalQtyClientID, "#main_content").val(FormatingTotalQuantity(qty));

    }



    function onPageError(error) {
        //
        alert(error.Message + ' -- ' + error.detail);

        // $('#' + '<%= btnSubmit.ClientID %>').show();



    }



    function checkQuantity(srcElem) {

        //

        var objRow = $(srcElem).parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;



        if (srcElem.value != srcElem.defaultValue) {



            objRow.find("#txtIsQuantityInc" + rowindex).val("1");

            updateSizeTableValues(objRow, rowindex, srcElem.value);



        }

    }





    function calculateTotalQuantity(srcElem) {



        var objRow = $(srcElem).parents("tr").parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        var qty = 0;



        objRow.find("input.size-quantity").each(function () {



            if ($(this).val() > 0) {



                qty = parseInt(qty) + parseInt($(this).val());



            }



        });

    }



    function updateTotalQuantity(objRow, rowindex) {
        //


        var qty = 0;

        objRow.find("input.size-quantity").each(function () {



            if ($(this).val() > 0) {



                qty = parseInt(qty) + parseInt($(this).val());



            }



        });

        //manisha 18th may 2011 removed 0

        objRow.find("#txtQuantityCalculated" + rowindex).val("");

        objRow.find("#txtQuantityCalculated" + rowindex).val(qty);



    }





    function calculateTotalSingles(srcElem) {

        // 

        var objRow = $(srcElem).parents("tr").parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        var objCell = $(srcElem).parents("td");

        var cellindex = objCell.get(0).cellIndex;

        var qty = 0;



        objRow.find("input.size-singles").each(function () {



            if ($(this).val() > 0) {



                qty = parseInt(qty) + parseInt($(this).val());



            }



        });

        //

        objRow.find("#lblSinglesTotal" + rowindex).val(qty);

        showDiff(rowindex, qty);

        //

        objRow.find("#txtQuantity" + cellindex + rowindex).val(objRow.find("#txtSingles" + cellindex + rowindex).val());

        calculateRatio(srcElem);



    }



    function showDiff(rowindex, qty) {



        var diff = parseInt($("#txtOriginalQuantityCalculated" + rowindex, "#main_content").val()) - qty;

        $("#lblRatioPack" + rowindex).val(diff);



    }



    function calculateRatio(srcElem) {
        //


        var objRow = $(srcElem).parents("tr").parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        var sum = 0;



        objRow.find("input.size-ratio").each(function () {

            //

            if (parseInt($(this).val()) > 0) {



                sum = parseInt(sum) + parseInt($(this).val());

            }



        });



        for (var i = 1; i <= 15; i++) {
            //


            if (objRow.find("#txtRatio" + i + rowindex).val() > 0) {

                //

                var qty = objRow.find("#lblRatioPack" + rowindex).val();

                var ratio = Math.round((qty / sum) * (objRow.find("#txtRatio" + i + rowindex).val()));

                objRow.find("#txtRatioPack" + i + rowindex).val(ratio);



                if (objRow.find("#txtSize" + i + rowindex).val().length > 0 && objRow.find("#txtSingles" + i + rowindex).val().length == 0) {

                    //manisha 18th may 2011 removed 0

                    objRow.find("#txtSingles" + i + rowindex).val("");



                }

                var txtSingle = objRow.find("#txtSingles" + i + rowindex).val();

                var txtRatio = objRow.find("#txtRatioPack" + i + rowindex).val();

                if (txtSingle == "") {



                    txtSingle = "0";

                }

                if (txtRatio == "") {



                    txtRatio = "0";

                }

                objRow.find("#txtQuantity" + i + rowindex).val(parseInt(txtSingle) + parseInt(txtRatio));



            }

            else {

                //manisha 18th may 2011 removed 0

                objRow.find("#txtRatioPack" + i + rowindex).val("");

            }

        }

        //

        updateTotalQuantity(objRow, rowindex);

    }



    function showSizeTable(srcElem) {

        //
        //

        var htmlName = srcElem.innerHTML;

        srcElem.innerHTML = "EDIT";

        var objRow = $(srcElem).parents("td");

        var objTable = objRow.children("table");

        var element = objRow.find("table");

        var left = (window.screen.width - 700) / 2;

        var top = (window.screen.height - 300) / 2;

        element.css("position", "absolute");

        element.css("background-color", "#eaeaea");

        element.css("border-color", "#cccccc");

        element.css("left", left);

        element.css("top", top);

        element.show();

        var objRow1 = $(srcElem).parents("tr");

        var rowindex = objRow1.get(0).rowIndex - 1;

        var qty = $("#txtQty" + rowindex, "#main_content").val();

        objRow1.find("#txtQuantityCalculated" + rowindex).val(qty);

        objRow1.find("#txtOriginalQuantityCalculated" + rowindex).val(qty);

        objRow1.find("#lblRatioPack" + rowindex).val(parseInt(qty) - parseInt(objRow1.find("#lblSinglesTotal" + rowindex).val()));
        //
        // Added By Ashish on 28/10/2014
        var optionval = objRow.find("#Option_" + rowindex).val()
        if (optionval == 1) {

            //FillNewSizeOption(optionval)
            objRow.find("#Option" + 1 + rowindex).attr('checked', 'checked');
        }
        if (optionval == 2) {
            // FillNewSizeOption(optionval)
            objRow.find("#Option" + 2 + rowindex).attr('checked', 'checked');
        }
        if (optionval == 3) {
            //FillNewSizeOption(optionval)
            objRow.find("#Option" + 3 + rowindex).attr('checked', 'checked');
        }
        if (optionval == 4) {
            // FillNewSizeOption(optionval)
            objRow.find("#Option" + 4 + rowindex).attr('checked', 'checked');
        }
        //END


        BindSizeSetOptionEdit(optionval, rowindex, htmlName);

    }



    function hideSizeTable(srcElem) {

        //

        var objRow = $(srcElem).parents("td");

        var rowindex = objRow.get(0).rowIndex - 1;

        var element = objRow.find("table");

        var objRow2 = $(srcElem).parents("tr").parents("tr");

        var rowindex2 = objRow2.get(0).rowIndex - 1;

        var objRow1 = $(srcElem).parents("tr");

        var qty = objRow1.find("#txtQuantityCalculated" + rowindex2).val();

        if (qty > 0) {



            objRow2.find("#hdnSizeTotalQty" + rowindex2).val(qty);



        }



        element.hide();



        updateQuantity();

    }



    function getDetail(srcElem, rowcount) {
        //
        //manisha
        alert('a');
        var objRow = $(srcElem).parents("tr");

        var txtdesc = objRow.find("textarea").val();

        var task = objRow.find("#newLable1").attr("title");

        var inpdate = objRow.find("input").val();

        var orderDet = objRow.find("input").attr("title");

        var rowInd = objRow.get(0).rowIndex;

        var orderID = $("#" + hdnOrderIdClientID).val();

        if ((rowcount != undefined) && (rowcount == rowInd)) {

            var btnId = $(srcElem).attr("id");

            var btnTitle = $(srcElem).attr("title");

            proxy.invoke("SaveReminderDetails", { orderDetailId: btnTitle, OrderId: orderID, taskId: task, desc: txtdesc, date: inpdate },

            function (result) {

                //sum(result);

                if (result != null) {

                    $(srcElem).attr("disabled", true);

                }

            });

            return;

        }

    }



    function createReminderTable() {

        //   //manisha
        //


        var order = $("#" + hdnOrderIdClientID).val();

        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");

        var rowCount = tbRows.length - 2;



        var val = [rowCount];

        var valOrder = [rowCount];



        var no = 0;

        for (var i = 1; i <= rowCount; i++) {

            val[i] = $("#tableOrderDetail tr").find("#aLine-" + i).attr("title");

            valOrder[i] = $("#tableOrderDetail tr").find("#aLine-" + i).attr("id");

        }

        proxy.invoke("FetchReminderDetails", { orderId: order },

            function (objStyleFabricCollection) {

                if (objStyleFabricCollection != null) {



                    for (var k = 0; k < objStyleFabricCollection.length; k++) {

                        $("#noReminder").attr("style", "display:none;");

                        var l = k + 1;

                        var rowNo = "";

                        var taskShort = "";

                        var iTitle = "";

                        var row = $("#tblNewGrid tr").filter("tr:last").clone(true).insertAfter($("#tblNewGrid tr").filter("tr:last"));

                        var newLastRow = $("#tblNewGrid tr").filter("tr:last");



                        for (var i = 1; i <= rowCount; i++) {

                            if (objStyleFabricCollection[k].OrderDetailID == val[i]) {

                                l = i;

                                if (ParseDateToDateWithDay(objStyleFabricCollection[k].ClosedDate) == null || ParseDateToDateWithDay(objStyleFabricCollection[k].ClosedDate) == "01 Jan 39 (Sun)") {

                                    $("#tableOrderDetail tr").find("#a" + objStyleFabricCollection[k].TaskShort + '-' + l).attr("style", "display:none");

                                    $("#tableOrderDetail tr").find("#a1" + objStyleFabricCollection[k].TaskShort + '-' + l).attr("style", "display:block");

                                }

                                else {

                                    $("#tableOrderDetail tr").find("#a" + objStyleFabricCollection[k].TaskShort + '-' + l).attr("style", "display:block");

                                    $("#tableOrderDetail tr").find("#a1" + objStyleFabricCollection[k].TaskShort + '-' + l).attr("style", "display:none");

                                }

                                rowNo = objStyleFabricCollection[k].TaskName + "( Row-" + l + ")";

                                iTitle = objStyleFabricCollection[k].OrderDetailID;

                                taskShort = objStyleFabricCollection[k].TaskShort + '-' + l;

                            }

                            else if (objStyleFabricCollection[k].OrderDetailID == 0) {

                                if (ParseDateToDateWithDay(objStyleFabricCollection[k].ClosedDate) == null || ParseDateToDateWithDay(objStyleFabricCollection[k].ClosedDate) == "01 Jan 39 (Sun)") {

                                    $("#a" + objStyleFabricCollection[k].TaskShort).attr("style", "display:none");

                                    $("#a1" + objStyleFabricCollection[k].TaskShort).attr("style", "display:block");

                                }

                                else {

                                    $("#a" + objStyleFabricCollection[k].TaskShort).attr("style", "display:block");

                                    $("#a1" + objStyleFabricCollection[k].TaskShort).attr("style", "display:none");

                                }

                                rowNo = objStyleFabricCollection[k].TaskName;

                                iTitle = objStyleFabricCollection[k].OrderID; //when orderdetailId=0

                                taskShort = objStyleFabricCollection[k].TaskShort;

                            }

                        }

                        newLastRow.attr("id", "tr" + taskShort);



                        newLastRow.find("#newLable1").attr("title", objStyleFabricCollection[k].TaskID);

                        newLastRow.find("#newLable1").html(rowNo);



                        newLastRow.find("textarea").html(objStyleFabricCollection[k].TaskDescription);

                        newLastRow.find("textarea").attr("id", "txtDescra" + taskShort);

                        newLastRow.find("textarea").attr("Width", "100px");

                        newLastRow.find("textarea").attr("readonly", true);



                        newLastRow.find("input:hidden").attr("id", "hdnTypea" + taskShort);

                        newLastRow.find("input:hidden").val("00");



                        newLastRow.find("input:text").attr("id", "txt-a" + taskShort);

                        newLastRow.find("input.date_style").val(ParseDateToDateWithDay(objStyleFabricCollection[k].TaskDueDate));

                        newLastRow.find("input.th").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });



                        newLastRow.find("input:text").attr("title", iTitle);



                        var test3 = newLastRow.find("#txt-a" + taskShort).attr("id");



                        newLastRow.find("button").attr("id", "btn-" + taskShort);

                        newLastRow.find("button").attr("title", iTitle);

                        $("#btn-" + taskShort).click(function () {

                            getDetail(this, l);

                        });

                        newLastRow.show();

                    }

                }

            });

    }





    function checkReminderRows() {



        var tbRows = $("#tblNewGrid tr");

        var rowCount1 = tbRows.length - 1;

        if (rowCount1 <= 0) {

            $("#tdNewGrid").attr("style", "display:none;");

            $("#noReminder").attr("style", "display:block;");

        }

        else {

            $("#tdNewGrid").attr("style", "display:block;");

            $("#noReminder").attr("style", "display:none;");
        }
    }

    function saveDetail(srcElem) {
        //alert('abc');
        //debugger;
        selectedDept = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
        if (selectedDept == 'Select..') {
            alert('Please select department');
            $("#" + DeptDDClientID, "#main_content").focus();
            return false;
        }

        var linkTitle = $(srcElem).attr("id");

        var tbRows = $("#tblNewGrid tr");

        var rowCount = tbRows.length - 1;

        var concatStr = '<table>';

        for (var i = 1; i <= rowCount; i++) {
            //
            var iChck = 1;

            var objRow = $("#tblNewGrid tr").filter("tr:eq(" + i + ")");

            var rowID = objRow.attr("id");

            var txtdesc = objRow.find("textarea").val();

            var task = objRow.find("#newLable1").attr("title");

            var type = objRow.find("input:hidden").val();

            var inpdate = objRow.find("input:text").val();  //objRow.find("input:text").val();

            var uniqueid = objRow.find("input:text").attr("title");

            var orderDet1 = uniqueid.split('.');

            var orderDet = orderDet1[0];

            if (txtdesc == "" || inpdate == "") {

                alert('Please enter complete info before saving a reminder');

                return false;

            }

            var orderID = $("#" + hdnOrderIdClientID).val();

            if (orderDet == orderID) {

                orderDet = "0";

            }

            if (orderDet == "-1" || orderDet == "N") {
                orderDet = "0";
            }
            concatStr = concatStr + "<taskdescription>" + txtdesc + "</taskdescription><taskid>" + task + "</taskid><tasktype>" + type + "</tasktype><taskinputdate>" + inpdate + "</taskinputdate><orderdetailid>" + orderDet + "</orderdetailid><uniqueid>" + uniqueid + "</uniqueid><orderid>" + orderID + "</orderid>";


        }

        concatStr = concatStr + "</table>";

        if (iChck != undefined && iChck == 1) {

            proxy.invoke("SaveReminderDetails", { ixml: concatStr },

            function (result) {

                if (result != null) {



                }

            });

        }

        return ValidateQuantities();
    }



    function saveDetail1(srcElem) {

        var linkTitle = $(srcElem).attr("id");

        var tbRows = $("#tblNewGrid tr");

        var rowCount = tbRows.length - 1;

        var concatStr = '<table>';

        for (var i = 1; i <= rowCount; i++) {

            var iChck = 1;

            var objRow = $("#tblNewGrid tr").filter("tr:eq(" + i + ")");

            var rowID = objRow.attr("id");

            var txtdesc = objRow.find("textarea").val();

            var task = objRow.find("#newLable1").attr("title");

            var type = objRow.find("input:hidden").val();

            var inpdate = objRow.find("input:text").val();  //objRow.find("input:text").val();

            var uniqueid = objRow.find("input:text").attr("title");

            var orderDet1 = uniqueid.split('.');

            var orderDet = orderDet1[0];



            if (txtdesc == "" || inpdate == "") {

                alert('Please enter complete info before saving a reminder');

                return false;

            }

            var orderID = $("#" + hdnOrderIdClientID).val();

            if (orderDet == orderID) {

                orderDet = "0";

            }

            if (orderDet == "-1" || orderDet == "N") {

                orderDet = "0";

            }

            //            if (i == 1) {

            //                concatStr = txtdesc + "!@" + task + "!@" + type + "!@" + inpdate + "!@" + orderDet + "!@" + orderID;

            //            } else {



            concatStr = concatStr + "<taskdescription>" + txtdesc + "</taskdescription><taskid>" + task + "</taskid><tasktype>" + type + "</tasktype><taskinputdate>" + inpdate + "</taskinputdate><orderdetailid>" + orderDet + "</orderdetailid><uniqueid>" + uniqueid + "</uniqueid><orderid>" + orderID + "</orderid>";

            //}

        }



        concatStr = concatStr + "</table>";

        if (iChck != undefined && iChck == 1) {

            proxy.invoke("SaveReminderDetails", { ixml: concatStr },

            function (result) {

                if (result != null) {



                }

            });

            alert('Reminder(s) saved successfully');

            //createReminderTable();

            return true;

        }

        else {

            alert('No reminder to save');

            return false;

        }

    }



    function sum(sender) {

        alert(sender);

    }



    function GetIdAdd(srcElem) {
        //
        //manisha

        //

        //var scrollVal=$(srcElem).scrollTop();

        var linkId = $(srcElem).attr("id");

        var first = linkId.split('-');

        var first1 = first[0].split('a');

        var name = 'a' + '1' + first1[1] + '-' + first[1];

        var objRow = $(srcElem).parents("tr");

        var value = objRow.find("#hdnManualNo" + (first[1])).val();

        var objadd = $(objRow).find("#" + name);

        objadd.attr("style", "Display:Block");

        objadd.attr("title", value);

        $(srcElem).attr("style", "Display:None");



        var rest;

        var txtBox = $("#txt-" + 'a' + first1[1] + '-' + first[1]).attr("id");

        var txtBox1 = $("#txtDescra" + first1[1] + '-' + first[1]).attr("id");

        if (txtBox == undefined && txtBox1 == undefined) {

            var linkTitle = value; //$(srcElem).attr("title");

            var tbRows = $("#tblNewGrid tr");

            var rowCount = tbRows.length - 1;

            var row = $("#tblNewGrid tr").filter("tr:last").clone(true).insertAfter($("#tblNewGrid tr").filter("tr:last"));

            var newLastRow = $("#tblNewGrid tr").filter("tr:last");

            newLastRow.attr("style", "Display:block");

            newLastRow.attr("id", "tr" + linkId + (rowCount + 1));

            newLastRow.find("input:first").focus();

            proxy.invoke("GetReminderDetails", { task: first1[1], type: 1 },

            function (result) {

                if (result != null) {

                    rest = result.split('-');

                    newLastRow.find("#newLable1").attr("title", rest[0]);

                    newLastRow.find("#newLable1").html(rest[1] + "(Row-" + first[1] + ")");

                }

            });

            newLastRow.find("textarea").html("");

            newLastRow.find("textarea").attr("Width", "100px");

            newLastRow.find("textarea").attr("id", "txtDescr" + linkId);

            newLastRow.find("input:hidden").attr("id", "hdnType" + linkId);

            newLastRow.find("input:hidden").val("MO");



            newLastRow.find("input:text").attr("id", "txt-" + linkId);

            newLastRow.find("input:text").attr("readonly", false);

            newLastRow.find("input:text").attr("class", "th date_style");

            var test = newLastRow.find("input.th").attr("id");

            newLastRow.find("input.th").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

            newLastRow.find("input:text").attr("title", linkTitle);



            newLastRow.find("button").attr("id", "btn-" + first1[1] + '-' + first[1]);

            newLastRow.find("button").attr("title", linkTitle);

            $("#btn-" + first1[1] + '-' + first[1]).click(function () {

                getDetail(this, rowCount + 1);

            });

            newLastRow.show();

        }

        $("#tblNewGrid").find("#txtDescr" + linkId).attr("readonly", false);

        $("#tblNewGrid").find("#hdnType" + linkId).val("MO");

        $("#tblNewGrid").find("#txt-" + linkId).val("");

        $("#tblNewGrid").find("#txt-" + linkId).attr("readonly", false);

        $("#tblNewGrid").find("#btn-" + first1[1] + '-' + first[1]).attr("disabled", false);

        $("#tblNewGrid").find("#txt-" + linkId).attr("class", "th date_style");

        $("#tblNewGrid").find("#txt-" + linkId).datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

        checkReminderRows();

        $("#tblNewGrid").find("#txtDescr" + linkId).focus();

        //$("#tblNewGrid").find("#txt-" + linkId).scrollTop(scrollVal);

    }



    function GetIdDel(srcElem) {
        //
        //

        var order = $("#" + hdnOrderIdClientID).val();

        var linkId = $(srcElem).attr("id");

        var first = linkId.split('-');

        var first1 = first[0].split('1');

        var name = first1[0] + first1[1] + '-' + first[1];

        var linkTitle = $(srcElem).attr("title");

        var objRow = $(srcElem).parents("tr");

        var objadd = $(objRow).find("#" + name);

        var objRow1 = $("#tblNewGrid").find("#btn-" + first1[1] + '-' + first[1]).parents("tr");

        var btn = $("#tblNewGrid").find("#txtDescr" + name);

        var newRow = $(btn).parents("tr");

        var trid = $(objRow1).attr("id");

        var task = objRow1.find("#newLable1").attr("title");

        var btnTitle = $("#tblNewGrid").find("#btn-" + first1[1] + '-' + first[1]).attr("title");

        var value = objRow.find("#hdnManualNo" + (first[1])).val();

        objadd.attr("style", "Display:Block");

        objadd.attr("title", value);

        $(srcElem).attr("style", "Display:None");

        if ($("#tblNewGrid").find("#hdnType" + name).val() == "MO") {

            $("#" + trid).remove();

        }

        else {
            //
            proxy.invoke("UpdateReminderDetails", { orderDetailId: btnTitle, orderId: order, taskId: task },

            function (result) {

                if (result != null) {

                    $("#tblNewGrid").find("#txtDescr" + name).attr("readonly", true);

                    $("#tblNewGrid").find("#txt-" + name).attr("readonly", true);

                    $("#tblNewGrid").find("#btn-" + first1[1] + '-' + first[1]).attr("disabled", true);

                    $("#tblNewGrid").find("#txt-" + name).attr("class", "do-not-allow-typing date_style");

                }

            });

        }

        checkReminderRows();

        objadd.focus();

    }

    ///////////////////////////

    function GetIdAddNew(srcElem) {
        //
        //manisha

        //

        var linkId = $(srcElem).attr("id");

        var first = linkId.split('a');

        var name = 'a' + '1' + first[1];

        var objRow = $(srcElem).parents("tr");

        var value = $("#" + hdnOrderIdClientID).val();

        var objadd = $(objRow).find("#" + name);

        objadd.attr("style", "Display:Block");

        objadd.attr("title", value);

        $(srcElem).attr("style", "Display:None");

        var rest;



        var txtBox1 = $("#txtDescra" + first[1]).attr("id");

        var txtBox = $("#txt-" + 'a' + first[1]).attr("id");

        if (txtBox == undefined && txtBox1 == undefined) {

            var linkTitle = value; //$(srcElem).attr("title");

            var tbRows = $("#tblNewGrid tr");

            var rowCount = tbRows.length - 1;

            var row = $("#tblNewGrid tr").filter("tr:last").clone(true).insertAfter($("#tblNewGrid tr").filter("tr:last"));

            var newLastRow = $("#tblNewGrid tr").filter("tr:last");

            newLastRow.attr("style", "Display:block");

            newLastRow.attr("id", "tr" + linkId);

            newLastRow.find("input:first").focus();

            proxy.invoke("GetReminderDetails", { task: first[1], type: 1 },

            function (result) {

                if (result != null) {

                    rest = result.split('-');

                    newLastRow.find("#newLable1").attr("title", rest[0]);

                    newLastRow.find("#newLable1").html(rest[1]);

                }

            });

            newLastRow.find("textarea").html("");

            newLastRow.find("textarea").attr("Width", "100px");

            newLastRow.find("textarea").attr("id", "txtDescr" + linkId);

            newLastRow.find("input:hidden").attr("id", "hdnType" + linkId);

            newLastRow.find("input:hidden").val("MD");



            newLastRow.find("input:text").attr("id", "txt-" + linkId);

            newLastRow.find("input:text").val("");

            newLastRow.find("input:text").attr("class", "th date_style");

            newLastRow.find("input.th").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

            newLastRow.find("input:text").attr("title", linkTitle);





            newLastRow.find("button").attr("id", "btn-" + first[1]);

            newLastRow.find("button").attr("title", linkTitle);

            $("#btn-" + first[1]).click(function () {

                getDetail(this, rowCount + 1);

            });

            newLastRow.show();

        }

        $("#tblNewGrid").find("#txtDescr" + linkId).attr("readonly", false);

        $("#tblNewGrid").find("#hdnType" + linkId).val("MD");

        $("#tblNewGrid").find("#txt-" + linkId).attr("readonly", false);

        $("#tblNewGrid").find("#btn-" + first[1]).attr("disabled", false);

        $("#tblNewGrid").find("#txt-" + linkId).attr("class", "th date_style");

        $("#tblNewGrid").find("#txt-" + linkId).datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

        checkReminderRows();

        $("#tblNewGrid").find("#txtDescr" + linkId).focus();

    }



    function GetIdDelNew(srcElem) {
        //
        //

        var order = $("#" + hdnOrderIdClientID).val();

        var linkId = $(srcElem).attr("id");

        var first1 = linkId.split('1');

        var name = first1[0] + first1[1];

        var linkTitle = $(srcElem).attr("title");

        var objRow = $(srcElem).parents("tr");

        var objadd = $(objRow).find("#" + name);

        var objRow1 = $("#tblNewGrid").find("#btn-" + first1[1]).parents("tr");

        var btn = $("#tblNewGrid").find("#txtDescr" + name);

        var newRow = $(btn).parents("tr");

        var trid = $(objRow1).attr("id");

        var task = objRow1.find("#newLable1").attr("title");

        var btnTitle = $("#tblNewGrid").find("#btn-" + first1[1]).attr("title");

        var value = $("#" + hdnOrderIdClientID).val();

        objadd.attr("style", "Display:Block");

        objadd.attr("title", value);

        $(srcElem).attr("style", "Display:None");

        if ($("#tblNewGrid").find("#hdnType" + name).val() == "MD") {

            $("#" + trid).remove();

        }

        else {
            //
            proxy.invoke("UpdateReminderDetails", { orderDetailId: btnTitle, orderId: order, taskId: task },

            function (result) {

                if (result != null) {

                    $("#tblNewGrid").find("#txtDescr" + name).attr("readonly", true);

                    $("#tblNewGrid").find("#txt-" + name).attr("readonly", true);

                    $("#tblNewGrid").find("#btn-" + first1[1]).attr("disabled", true);

                    $("#tblNewGrid").find("#txt-" + name).attr("class", "do-not-allow-typing date_style");

                }

            });

        }

        checkReminderRows();

        objadd.focus();

    }



    ////////////////////////////



    function validateSendProposal() {
        //
        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");

        var rowCount = tbRows.length - 2;

        var isSave = 0;

        var isFilled = 0;

        var objRow = tbRows.find("table");



        for (var i = 1; i <= rowCount; i++) {



            var qtyObj = tbRows.find("#txtQty" + i);

            var totalQty = qtyObj.val();

            var defaultTotalQty = qtyObj.defaultValue;

            var qtyFromSizes = 0;

            var selectedValue = $('#ddlMode' + i, "#main_content").val();

            var selectedText = $('#ddlMode' + i, "#main_content").find("option:selected").text();



            if (selectedText.indexOf('Select') > -1 || selectedValue == 0 || selectedValue == "0") {

                alert('Please enter a valid Mode');

                return false;

            }



            qtyFromSizes = objRow.find("#txtQuantityCalculated" + i).val();



            if (parseInt(totalQty) > 0 && parseInt(qtyFromSizes) > 0 && (parseInt(totalQty) != parseInt(qtyFromSizes)))
                isSave++;
        }



        if (isSave > 0) {

            if (parseInt(totalQty) != parseInt(qtyFromSizes)) {                //

                jQuery.facebox("Order breakdown Quantity & respective sizes quantity do not match. Please fill appropriate quantities!");
                return false;
            }
        }

        else {
            return true;
        }
    }


    function ValidateQuantities() {
         //debugger;
        //alert('validate');

        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");

        var rowCount = tbRows.length - 2;
        var isSave = 0;
        var isFilled = 0;
        var objRow = tbRows.find("table");
        //alert(rowCount);

        var currentMode;

        var selectedValue1 = $('#ddlMode1', "#main_content").find("option:selected").text();

        if (selectedValue1.indexOf('L-') > -1) {
            currentMode = "L";
        }

        if (selectedValue1.indexOf('D(FACT)') > -1) {
            currentMode = "D(FACT)";
        }

        if (selectedValue1.indexOf('D(PORT)') > -1) {
            currentMode = "D(PORT)";
        }

        if (selectedValue1.indexOf('D(PORT-F)') > -1) {
            currentMode = "D(PORT-F)";
        }

        for (var i = 1; i <= rowCount; i++) {
            //
            var qtyObj = tbRows.find("#txtQty" + i);

            var totalQty = qtyObj.val();

            var defaultTotalQty = qtyObj.defaultValue;

            var qtyFromSizes = 0;
            var selectedValue = $('#ddlMode' + i, "#main_content").val();

            var selectedText = $('#ddlMode' + i, "#main_content").find("option:selected").text();

            if (selectedText.indexOf(currentMode) == -1) {
                alert('Select Same Mode');
                return false;
            }

            if (selectedText.indexOf('Select') > -1 || selectedValue == 0 || selectedValue == "0") {
                alert('Please enter a valid Mode');
                return false;
            }

            var BIPLPrice = $("#txtodBIPLPrice" + i, "#main_content").val();

            if ((BIPLPrice == '') || (BIPLPrice == '0')) {
                alert('Please enter BIPL Price');
                $("#txtodBIPLPrice" + i, "#main_content").focus();
                return false;
            }

            qtyFromSizes = objRow.find("#txtQuantityCalculated" + i).val();
            if (parseInt(totalQty) > 0 && parseInt(qtyFromSizes) > 0 && (parseInt(totalQty) != parseInt(qtyFromSizes)))

                isSave++;
        }

   
        if (isSave > 0) {
            if (parseInt(totalQty) != parseInt(qtyFromSizes)) {              
                jQuery.facebox("Order breakdown Quantity & respective sizes quantity do not match. Please fill appropriate quantities!");
                return false;
            }
        }

        else {
            return true;
        }
    }

    function addFabric(i) {

        var rowCount = $("#" + tableOrderDetailVar + " tr", "#main_content").filter(":not(.size-table tr)").length - 2;

        $("td.fabric-" + i, "#main_content").each(function () {

            $("td.fabric-" + i, "#main_content").show();

        });

        for (var k = 1; k <= rowCount; k++) {

            var fab1 = document.getElementById('lbFabric11' + k).innerText;

            var fab2 = document.getElementById('lbFabric21' + k).innerText;

            var fab3 = document.getElementById('lbFabric31' + k).innerText;

            var fab4 = document.getElementById('lbFabric41' + k).innerText;

            var temp1 = "lbFabric" + i + 1 + k;

            var temp2 = "lbFabric" + i + 1 + k;

            var temp3 = "lbFabric" + i + 1 + k;

            var temp4 = "lbFabric" + i + 1 + k;

            if (i == 2)

                document.getElementById(temp2).innerText = fab1;

            if (i == 3)

                document.getElementById(temp3).innerText = fab2;

            if (i == 4)

                document.getElementById(temp4).innerText = fab3;
        }

        for (var j = 1; j <= rowCount; j++) {

            if ($("#txtOrderDetailID" + j, "#main_content").val() <= 0) {
                $("#txtFabric" + i + 3 + j, "#main_content").val($("#txtFabric13" + j, "#main_content").val()); //

                $("#txtFabric" + i + 2 + j, "#main_content").val($("#txtFabric12" + j, "#main_content").val());

                $("#txtFabric" + i + 1 + j, "#main_content").val($("#txtFabric11" + j, "#main_content").val());
            }
        }
        if (i == 3) {
            document.getElementById('Img6').style.visibility = "hidden";
        }

        if (i == 4) {
            document.getElementById('Img5').style.visibility = "hidden";
        }
    }



    function deleteFabric(i) {

        // //yatendra

        if (i == 4) {

            document.getElementById('Img5').style.visibility = "visible";

        }

        if (i == 3) {

            document.getElementById('Img6').style.visibility = "visible";

        }

        $("td.fabric-" + i, "#main_content").each(function () {

            $("td.fabric-" + i, "#main_content").hide();



        });

    }



    function DateDeserialize(dateStr) {
        var str = eval('new' + dateStr.replace(/\//g, ' '));
        var dateStr = (str.getMonth() + 1) + '/' + str.getDate() + '/' + str.getFullYear();
        return dateStr;
    }



    function clearDefault(el, defValue) {
        if (el.value.toLowerCase() == defValue.toLowerCase())
            el.value = ""
    }



    function showHide(prmThis) {



        if (isExpanded == false) {



            $("#divHistory").show();

            isExpanded = true;

            $(prmThis).html("Collapse");



        }

        else {



            $("#divHistory").hide();

            isExpanded = false;

            $(prmThis).html("View History");



        }

    }







    // added by yaten

    function PrintPDFOrder(Url, height, width) {

        //$.showprogress();

        //doNotPressAgain

        // $(".loadingimage").show();

        $(".doNotPressAgain").hide();



        var url;

        var ht = parseInt($(document).height()) - 130;

        var wd = parseInt($(document).width()) - 100;



        if (height != '' && height != null) {

            ht = height;

        }

        if (width != '' && width != null) {

            wd = width;

        }



        if (Url == '' || Url == null) {

            url = window.location.pathname;

        }

        else {

            url = Url;

        }



        if (url.indexOf('/') != 0)

            url = '/' + url;

        //   

        //alert(wd + " - " + ht);

        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {



            if ($.trim(result) == '') {

                //$.hideprogress();

                jQuery.facebox("Some error occured on the server, please try again later.");

            }

            else {

                window.open(result);

                // $(".loadingimage").hide();

                $(".print").show();



            }

        });



        return false;

    }







    function GetExfactoryQuantityReport() {



        proxy.invoke("GetExfactoryQuantityReport", {}, function (result) {

            result = '<div class="divReportPopup"><div style="padding:15px;border:0px">' + result + "</div></div>";

            jQuery.facebox(result);

        }, onPageError, false, false);

    }



    function updateSizeTableValues(objRow, rowindex, new_quan) {

        //

        var old_quan = $("#txtQuantityCalculated" + rowindex, "#main_content").val();



        if (old_quan > 0) {



            $("#txtQuantityCalculated" + rowindex, "#main_content").val(new_quan);

            var qty = 0;



            objRow.find("input.size-singles").each(function () {

                var old_val = 0;

                var new_val = 0;

                var objThis = null;

                objThis = $(this);

                old_val = objThis.val();



                if (old_val.toString().length > 0) {
                    //
                    new_val = Math.floor((parseFloat(old_val) * parseFloat(new_quan)) / parseFloat(old_quan));

                    objThis.val(new_val);
                    //objThis.val(old_val);

                    qty = parseInt(qty) + parseInt(new_val);

                }

                window.onunload = null;

            });



            objRow.find("#lblSinglesTotal" + rowindex).val(qty);



            showDiff(rowindex, qty);



            var sum = 0;



            objRow.find("input.size-ratio").each(function () {

                var value = $(this).val();

                if (value > 0) {

                    sum = parseInt(sum) + parseInt(value);

                }

            });



            objRow.find("input.size-singles").each(function (i) {
                //
                //debugger;
                var j = i + 1;

                if ($(this).val().length > 0) {
                    //if (objRow.find("#txtSize" + j + rowindex).val() > 0
                    //Added By Ashish on 26/11/2014
                    if (objRow.find("#txtSize" + j + rowindex).val() > 0 || objRow.find("#txtSize" + j + rowindex).val() != null || objRow.find("#txtSize" + j + rowindex).val() != 'undefined') {

                        var qty1 = objRow.find(".size-ratiopack").val();

                        var ratio = 0;

                        //debugger;

                        if (objRow.find("#txtRatio" + j + rowindex).val() > 0) {
                            //ratio = Math.floor((qty1 / sum) * (objRow.find("#txtRatio" + j + rowindex).val()));
                            //objRow.find("#txtRatioPack" + j + rowindex).val(ratio);
                            //
                            //var countvalue = $("#ordersplit").find("#splitValue").val()
                            //
                            var r = new_quan - qty;
                            ratio = Math.round((r / sum) * (objRow.find("#txtRatio" + j + rowindex).val()))
                            objRow.find("#txtRatioPack" + j + rowindex).val(ratio);

                        }
                        //
                        objRow.find("#txtQuantity" + j + rowindex).val(parseInt(objRow.find("#txtSingles" + j + rowindex).val()) + parseInt(ratio));

                    }

                }
                //Ashish 
                else {

                    if (objRow.find("#txtRatio" + j + rowindex).val() > 0) {
                        //debugger;
                        //var qty2 =$(".size-ratiopack1").val();
                        var single;
                        var qty2 = new_quan;
                        ratio = Math.floor((qty2 / sum) * (objRow.find("#txtRatio" + j + rowindex).val()));
                        objRow.find("#txtRatioPack" + j + rowindex).val(ratio);
                        if (objRow.find("#txtSingles" + j + rowindex).val() == "") {
                            single = 0;
                            objRow.find("#txtQuantity" + j + rowindex).val(parseInt(single) + parseInt(ratio));
                        }
                        else {
                            objRow.find("#txtQuantity" + j + rowindex).val(parseInt(objRow.find("#txtSingles" + j + rowindex).val()) + parseInt(ratio));
                        }


                        // //objRow.find("#txtQuantity" + j + rowindex).val(parseInt(single) + parseInt(ratio));
                    }

                }
                //

            });

        }

    }





    function UpdateValuesIfDeleted(srcElem) {



        var objRow = $(srcElem).parents("tr").parents("tr");

        var rowindex = objRow.get(0).rowIndex - 1;

        var objCell = $(srcElem).parents("td");

        var cellindex = objCell.get(0).cellIndex;



        if ($(srcElem).val().length <= 0) {



            var qty = parseInt(objRow.find("#lblSinglesTotal" + rowindex).val()) - parseInt($("#txtSingles" + cellindex + rowindex).val());

            objRow.find("#txtSingles" + cellindex + rowindex).attr("disabled", true);

            //manisha 18th may 2011 removed 0

            objRow.find("#txtSingles" + cellindex + rowindex).val("");

            objRow.find("#txtRatio" + cellindex + rowindex).attr("disabled", true);

            //manisha 18th may 2011 removed 0

            objRow.find("#txtRatio" + cellindex + rowindex).val("");

            objRow.find("#txtQuantity" + cellindex + rowindex).attr("disabled", true);

            //manisha 18th may 2011 removed 0

            objRow.find("#txtQuantity" + cellindex + rowindex).val("");

            objRow.find("#txtRatioPack" + cellindex + rowindex).attr("disabled", true);

            //manisha 18th may 2011 removed 0

            objRow.find("#txtRatioPack" + cellindex + rowindex).val("");

            objRow.find("#lblSinglesTotal" + rowindex).val(qty);

            showDiff(rowindex, qty);



            var sum = 0;

            objRow.find("input.size-ratio").each(function (i) {



                if ($(this).val() > 0 && i != (parseInt(cellindex) - 1)) {



                    sum = parseInt(sum) + parseInt($(this).val());



                }

            });



            for (var i = 1; i <= 15; i++) {



                if (objRow.find("#txtRatio" + i + rowindex).val() > 0 && i != cellindex) {



                    var qty = objRow.find("#lblRatioPack" + rowindex).val();

                    var ratio = Math.round((qty / sum) * (objRow.find("#txtRatio" + i + rowindex).val()));

                    objRow.find("#txtRatioPack" + i + rowindex).val(ratio);



                    if (objRow.find("#txtSize" + i + rowindex).val().length > 0 && objRow.find("#txtSingles" + i + rowindex).val().length == 0) {



                        //manisha 18th may 2011 removed 0

                        objRow.find("#txtSingles" + i + rowindex).val("");



                    }

                    var txtSingle = objRow.find("#txtSingles" + i + rowindex).val();

                    var txtRatio = objRow.find("#txtRatioPack" + i + rowindex).val();

                    if (txtSingle == "") {



                        txtSingle = "0";

                    }

                    if (txtRatio == "") {



                        txtRatio = "0";

                    }

                    objRow.find("#txtQuantity" + i + rowindex).val(parseInt(txtSingle) + parseInt(txtRatio));

                }

            }



            updateTotalQuantity(objRow, rowindex);



        }

        else {



            if ($(srcElem).val().length > 0) {



                objRow.find("#txtSingles" + cellindex + rowindex).removeAttr("disabled");

                objRow.find("#txtRatio" + cellindex + rowindex).removeAttr("disabled");

                objRow.find("#txtQuantity" + cellindex + rowindex).removeAttr("disabled");

                objRow.find("#txtRatioPack" + cellindex + rowindex).removeAttr("disabled");



            }

        }

    }



    function GetFabricQualityData(srcTd, tradeName, details, mode, index) {
        //


        if ($.trim(tradeName) == '')

            return;

        var f = tradeName.split('[');

        // var f = $(this).val();

        // $(this).val(f[0]);

        var s = f[0];

        var ss = srcTd.find("label").attr("id");

        document.getElementById(ss).innerText = "";

        proxy.invoke("GetFabricQualityDetailsByTradeName", { TradeName: s, Details: details, Mode: mode },

                     function (result) {



                         if (result == null || result == '') {



                             srcTd.find('.div_show').addClass("hide_me");

                             return;

                         }

                         var ss = srcTd.find("label").attr("id");

                         srcTd.find("label").attr("style", "font-size:10");

                         if (result.GSM > 0 && result.CountConstruction != '') {

                             //, result.CountConstruction)

                             document.getElementById(ss).innerHTML = "<span style='color:blue'>CC:</span>" + result.CountConstruction + "  " + " | <span style='color:blue'>GSM:</span>" + result.GSM + "";

                         }

                         else if (result.GSM > 0) {

                             document.getElementById(ss).innerHTML = "<span style='color:blue'>GSM:</span>" + result.GSM + "";

                         }

                         else if (result.CountConstruction != '') {

                             document.getElementById(ss).innerHTML = "<span style='color:blue'>CC:</span>" + result.CountConstruction + "";

                         }

                         else { document.getElementById(ss).innerHTML = ""; }





                         srcTd.find('.div_show').removeClass("hide_me");

                         srcTd.find('.hlkQuality').attr("href", "#" + result.FabricQualityID);



                         if (result.Origin == 1) {



                             srcTd.find('.origin').html("Ind");

                             srcTd.find('.div_origin').addClass("hide_me");



                         }

                         else if (result.Origin == 2) {



                             srcTd.find('.origin').html("Imp");

                             srcTd.find('.div_origin').removeClass("hide_me");



                         }

                     });

    }



    function launchFabricQualityPopup(prmThis) {

        // debugger;

        var url = prmThis.href;

        var index = url.indexOf("#");

        var fqID = -1;

        if (index > -1)

            fqID = url.substring(index + 1);

        else

            fqID = url;



        showFabricQuality(fqID, prmThis);

        return false;



    }

    // 

    function validateQty(ctrl) {

        var objRow = ctrl.value;
        var crtlId = ctrl.id.substr(6)
        var totalQty = $.trim(objRow)

        if (totalQty == "" || totalQty < "1") {
            // totalQty == "0" || 
            var message = 'Quantity Is Required';
            ShowHideValidationBox(true, message);
            //ctrl.value = ctrl.defaultValue;
            $("#txtQty" + crtlId).focus();

            return false;

        }
        else {
            return true;
        }
    }


    //

    //Added By Ashish on 28/10/2014

    function FillSizeByOption(srcElem) {
        //
        var Option = $(srcElem).val();
        //
        proxy.invoke("GetSizeSetById", { Option: Option },
            function (objStyleFabricCollection) {
                //
                if (objStyleFabricCollection != null) {
                    //
                    if (objStyleFabricCollection.length > 0)
                    //

                        var sizes = objStyleFabricCollection[0].Sizes.split(',');
                    SetSizeToControls(srcElem, 1, sizes);
                }
            });
    }

    function SetSizeToControls(srcElem, id, sizes) {
        //

        var objRow = $(srcElem).parents("tr").parents("tr");
        var rowindex = objRow.get(0).rowIndex - 1;
        var objCell = $(srcElem).parents("td");
        var cellindex = objCell.get(0).cellIndex;
        objRow.find("input.size-ratio").each(function (i) {
            if ($(this).val() > 0 && i != (parseInt(cellindex) - 1)) {
                sum = parseInt(sum) + parseInt($(this).val());
            }

        });

        for (var i = 1; i <= 15; i++) {
            objRow.find("#txtSize" + i + rowindex).val(sizes[i - 1])
        }
        //
        var hdnOptio = $(srcElem).val();
        objRow.find("#Option_" + rowindex).val(hdnOptio);


    }

    function FillNewSizeOption(Option, No, flag) {
        //

        proxy.invoke("GetSizeSetById", { Option: Option },
            function (objStyleFabricCollection) {
                if (objStyleFabricCollection != null) {
                    //
                    if (objStyleFabricCollection.length > 0)

                        var sizes = objStyleFabricCollection[0].Sizes.split(',');
                    SetSize(Option, sizes, No, flag);
                }
            });
    }


    function SetSize(srcElem, sizes, No, flag) {
        //
        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");
        var rowCount = tbRows.length - 2;
        for (var i = 1; i <= 15; i++) {

            context.find("#txtSize" + i + No).val(sizes[i - 1])
        }

        if (flag != 'undefined') {
            var hdnOptio = $(srcElem).val();
            context.find("#Option_" + No).val(flag);
            context.find("#Option" + No + flag).attr('checked', 'checked');
        }


    }


    //Added By Ashish on 6/11/2014 for Bind Dynamic Size Option
    function BindSizeSetOptionEdit(opVal, rindex, flagHtmlName) {
        //debugger;
        var clientId = $("#" + BuyerDDClientID, "#main_content").val();
        var DeptId = $("#" + DeptDDClientID, "#main_content").val();
        //
        var orderid = $("#" + hdnOrderIdClientID).val();
        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");
        var rowCount = tbRows.length - 2;


        if (clientId != -1) {
            proxy.invoke("GetSizeSetOption", { clientId: clientId, DeptId: DeptId },
            function (result) {
                //debugger;
                if (result != null) {

                    if (result.length > 0)
                        if (orderid == "-1") {
                            for (var j = 0; j < rowCount; j++) {
                                $('#OptionDiv' + (j + 1)).empty();
                                for (var i = 0; i < result.length; i++) {
                                    //debugger;
                                    $('#OptionDiv' + (j + 1)).append('<label Id=lable_' + result[i].SizeOption + '><input type="radio" title=' + result[i].Size + ' value=' + result[i].SizeOption + '  onclick="javascript:return FillSizeByOption(this);" Id="Option' + (j + 1) + result[i].SizeOption + '" name="editList" />Option' + result[i].SizeOption + '</label>');
                                    if (i == 0) {
                                        //
                                        FillNewSizeOption(result[i].SizeOption, (j + 1), result[i].SizeOption);
                                    }
                                    else {
                                        //
                                        FillNewSizeOption(1, (j + 1), "");
                                    }
                                }
                            }
                        }
                        else {
                            for (var j = 0; j < rowCount; j++) {
                                $('#OptionDiv' + (rindex)).empty();
                                for (var i = 0; i < result.length; i++) {
                                    //debugger;
                                    $('#OptionDiv' + (rindex)).append('<label Id=lable_' + result[i].SizeOption + '><input type="radio" title=' + result[i].Size + ' value=' + result[i].SizeOption + '  onclick="javascript:return FillSizeByOption(this);" Id="Option' + rindex + result[i].SizeOption + '" name="editList" />Option' + result[i].SizeOption + '</label>');

                                    if (flagHtmlName == 'EDIT') {
                                        //debugger;
                                        var optionval = context.find("#Option_" + rindex).val();
                                        //var option = context.find("#Option" + rindex + optionval);
                                        optionval = parseInt(optionval);
                                        context.find("#Option_" + rindex).val(optionval);
                                        $("#Option" + rindex + optionval).attr('checked', 'checked');
                                    }
                                    else {
                                        if (i == 0) {
                                            //debugger;
                                            var option = context.find("#Option_" + rindex).val();
                                            context.find("#Option_" + rindex).val(option);
                                            var hdnIsSize = $("#" + '<%=hdnIsSize.ClientID%>').val()
                                            //$("#Option" + rindex + optionval).attr('checked', 'checked'); 
                                            context.find("#Option" + rindex + result[i].SizeOption).attr('checked', 'checked');
                                            if (hdnIsSize == "1") {
                                                FillNewSizeOption(option, rindex, option);
                                            }
                                            else {
                                                FillNewSizeOption(result[i].SizeOption, rindex, option);
                                            }
                                        }
                                        //                                    else {
                                        //                                    }
                                    }

                                }
                            }
                        }
                }
            });

        }
    }

    function BindSizeSetOptionForRows() {
        // 
        var clientId = $("#" + BuyerDDClientID, "#main_content").val();
        var DeptId = $("#" + DeptDDClientID, "#main_content").val();
        //
        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");
        var rowCount = tbRows.length - 2;

        proxy.invoke("GetSizeSetOption", { clientId: clientId, DeptId: DeptId },
            function (result) {
                //debugger
                if (result != null) {
                    //
                    if (result.length > 0)
                        for (var j = 0; j < rowCount; j++) {
                            //debugger
                            $('#OptionDiv' + (j + 1)).empty();
                            for (var i = 0; i < result.length; i++) {
                                $('#OptionDiv' + (j + 1)).append('<label Id=lable_' + result[i].SizeOption + '><input type="radio" title=' + result[i].Size + ' value=' + result[i].SizeOption + '  onclick="javascript:return FillSizeByOption(this);" Id="Option' + result[i].SizeOption + (i + 1) + '" name="editList" />Option' + result[i].SizeOption + '</label>');

                            }
                        }
                }
            });

    }

    //        //Added By Ashish on 6/11/2014 for Bind Dynamic Size Option
    function BindSizeSetOption() {
        //
        var clientId = $("#" + BuyerDDClientID, "#main_content").val();
        var DeptId = $("#" + DeptDDClientID, "#main_content").val();
        //

        var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");
        var rowCount = tbRows.length - 2;
        var orderid = $("#" + hdnOrderIdClientID).val();

        if (orderid == '-1') {
            if (clientId != -1) {
                proxy.invoke("GetSizeSetOption", { clientId: clientId, DeptId: DeptId },
            function (result) {

                if (result != null) {
                    //
                    if (result.length > 0)
                        for (var j = 0; j < rowCount; j++) {
                            $('#OptionDiv' + (j + 1)).empty();
                            for (var i = 0; i < result.length; i++) {

                                $('#OptionDiv' + (j + 1)).append('<label Id=lable_' + result[i].SizeOption + '><input type="radio" title=' + result[i].Size + ' value=' + result[i].SizeOption + '  onclick="javascript:return FillSizeByOption(this);" Id="Option' + result[i].SizeOption + (i + 1) + '" name="editList" />Option' + result[i].SizeOption + '</label>');
                                if (i == 0) {
                                    //
                                    FillNewSizeOption(result[i].SizeOption, (j + 1), result[i].SizeOption);
                                }
                                else {
                                    // FillNewSizeOption(1, "");
                                }
                            }
                        }
                }
            });


            }
        }

    }


    //        function hidshowdiv() {
    //            //
    //            var tbRows = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)");
    //            var rowCount = tbRows.length - 2;
    //            for (var i = 0; i < rowCount; i++) {
    //                //
    //                var OrderDetailsID = context.find("#txtOrderDetailID" + (i + 1)).val();
    //                if (OrderDetailsID != "-1") {
    //                    proxy.invoke("CheckIsSizeByOrderDetailId", { OrderDetailsID: OrderDetailsID },
    //            function (objStyleFabricCollection) {
    //                if (objStyleFabricCollection != null) {
    //                    context.find("#showhide" + rowCount).hide();
    //                    context.find("#" + hdnIsNewOrderId).val("-1")
    //                }
    //                else {
    //                    context.find("#showhide" + rowCount).show();
    //                    context.find("#Option_" + 1).val(1);
    //                    context.find("#" + hdnIsNewOrderId).val("1")
    //                }
    //            });
    //                }
    //                else {
    //                    FillNewSizeOption(1);
    //                }

    //            }
    //        }

    //END

    function ShowAddStyleNumberBox(chk) {
        //debugger;
        if (chk.checked) {
            var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
            var BaseStyleNumber = getStylefromDesc(styleNumber);
            $("#" + txtStyleNumber1ClientID, "#main_content").val(BaseStyleNumber);

            $('.style_number_box').show();
        }
        else {
            $("#" + txtStyleNumberClientID, "#main_content").val('');
            onStyleChange();
        }
    }

    function HideAddStyleNumberBox() {
        //debugger;
        $('.style_number_box').hide();
        var checkbox = $('#chkRepeatOrder');
        checkbox.attr('checked', false);
        $("#" + hdnRepeatWithChangesClientID, "#main_content").val(0);
    }



    //    $('.cancelPopup').click(function () {
    //        debugger;
    //        HideAddStyleNumberBox();
    //        txtStyleNumber2.val('');
    //    });

    function getStylefromDesc(styleNumber) {

        var sn = $.trim(styleNumber);
        if (styleNumber.indexOf('$') > -1) {
            if (styleNumber != '' && sn.split('$').length == 1 && sn.indexOf('$') > -1) {

                sn = sn.replace('!', '');

                if (sn.indexOf(' ') > -1)
                    sn = sn.substring(0, sn.lastIndexOf(' '));

                return sn;
            }
            else if (styleNumber != '' && sn.split('$').length == 2) {
                var sn = $.trim(styleNumber);
                sn = sn.replace('!', '');

                if (sn.indexOf(' ') > -1)
                    sn = sn.substring(0, sn.lastIndexOf(' '));

                sn = sn.replace('$', ' ');

                return sn;

            }
        }
        else {
            if (sn.split(' ').length == 3)
                sn = sn.substring(0, sn.lastIndexOf(' '));
            return sn;
        }
    }

    function VinCheck(e) {
        var keynum;
        var keychar;
        var charcheck;
        if (window.event)
            keynum = e.keyCode;
        else if (e.which)
            keynum = e.which;
        keychar = String.fromCharCode(keynum);
        charcheck = /[a-zA-Z0-9]/;
        return charcheck.test(keychar);

    }

    //    $('.save-style-number').click(function () {
    function SaveNewStyleNumber() {
        //debugger;

        var styleNumber = $("#" + txtStyleNumber1ClientID, "#main_content").val() + ' ' + $("#" + txtStyleNumber2ClientId, "#main_content").val();

        proxy.invoke('GetStyleByNumber', { StyleNumber: styleNumber },
            function (objStyle) {
                //debugger;
                if (null != objStyle && objStyle.StyleID != -1) {
                    //debugger;
                    ShowHideValidationBox(true, 'Style Number already exists.', 'Costing Sheet - Add Style Number');
                    //HideAddStyleNumberBox();
                }
                else {
                    //debugger;

                    $("#" + hdnParentStyleNumberClientId, "#main_content").val($("#" + txtStyleNumberClientID, "#main_content").val());

                    $("#" + txtStyleNumberClientID, "#main_content").val(styleNumber);

                    var ParentStyleId = $("#" + hdnStyleIDClientID, "#main_content").val();
                    $("#" + hdnParentStyleIDClientID, "#main_content").val(ParentStyleId);


                    $("#" + hdnRepeatWithChangesClientID, "#main_content").val(1);
                    $('.style_number_box').hide();

                }
            });
    }

</script>
<%--<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>

<script type="text/javascript">

    $(function () {

        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
        // $("#txtDC1").datepicker({ dateFormat: 'dd M y (D)' });

        //          $(".th1").datepicker({ dateFormat: 'dd/mm/yy' });
        //          $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });


    });








  
</script>
<asp:Panel runat="server" ID="pnlForm">
    <asp:Panel runat="server" ID="pnlForm1" ScrollBars="Vertical" Width="550px" Height="400px"
        CssClass="divSplit">
        <div id="ordersplit" class="hide_me do-not-include">
            <div class="form_box" style="height: auto; min-height: 395px;">
                <div class="form_heading">
                    Order Split
                </div>
                <br />
                <table class="order_split_table" id="tblsplitdtl" width="450px" style="margin-left: 15px">
                    <tr>
                        <td align="left">
                            <span style="font-weight: bold">Line Number:</span><label id="lblLinenoSplit"></label>
                            &nbsp;|&nbsp; <span style="font-weight: bold">Contract Number:</span><label id="lblContractNoSplit"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table class="order_split_table" style="border: solid 1px; margin-left: 15px" id="tblsplit"
                    width="450px">
                    <tbody>
                        <tr>
                            <th width="25%" id="newLable">
                                No. Of Splits
                                <asp:Label ID="lbl" runat="server"></asp:Label>
                            </th>
                            <td width="25%">
                                <input type="text" id="splitValue" onkeyup="test2(this)" value="0" />
                            </td>
                            <td width="35%">
                                <label id="ex">
                                </label>
                            </td>
                            <td width="30%" rowspan="10" align="center" style="vertical-align: top">
                                <input type="hidden" value="-1" id="hdnrowindex" />
                                <input type="hidden" value="-1" id="hdnquantity" />
                                <input type="button" id="btnOk" onclick="addsplitTableRow( this)" value="Ok" class="ok da_submit_button" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <div style="margin-left: 15px;">
                    <label id="ext" visible="false">
                    </label>
                </div>
                <div style="margin-left: 15px;">
                    &nbsp;
                </div>
                <table width="450px" style="margin-left: 15px;">
                    <tr>
                        <td style="width: 20%">
                            <span style="font-weight: bold">Quantity:</span>
                        </td>
                        <td>
                            <%--added by abhishek on 14/8/2015--------------------------------------//--%>
                            <select id="ddlsortType" onchange="getComboA(this)">
                                <option value="asc" selected="selected">Ascending</option>
                                <option value="desc">Descending</option>
                                <%--   ---------------------------------end----------------------------------------------%>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <input type="button" id="submit" value="Submit" class="submit" onclick="if(checkSplitValues()) {addRowFromsplitTable();}" />
                        </td>
                        <td align="left">
                            <input type="button" id="cancel" class="cancel da_submit_button" value="Cancel" onclick="closeSplitTable()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <div class="print-box">
        <asp:HiddenField ID="hdnIsNewOrderId" runat="server" />
        <asp:HiddenField ID="hdnIsSize" runat="server" />
        <div id="include">
            <div class="form_box">
                <div class="form_heading">
                    <strong>Factory Order Form</strong>
                </div>
                <table class="order_form_table item_list1" id="mainTable">
                    <tbody>
                        <tr>
                            <td colspan="5" style="text-align: center">
                                <a id="hypGetEXFactoryReport" runat="server" href="javascript:void(0)" onclick="GetExfactoryQuantityReport(); return false;">
                                    View ExFactory Quantity Report</a>
                            </td>
                        </tr>
                        <tr>
                            <th width="12%" style="text-align: left;">
                                Order Date
                            </th>
                            <td width="35%" style="text-align: left;" colspan="3">
                                <asp:HiddenField ID="hdnOrderId" runat="server" />
                                <asp:HiddenField ID="hdnBuyingHouse" runat="server" />
                                <asp:HiddenField ID="hdnStyleID" runat="server" />
                                <asp:HiddenField ID="hdnParentStyleID" runat="server" />
                                <asp:HiddenField ID="hdnClientID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnOrderType" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnOriginalClientID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnOriginalDeptID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnDeptID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnNewClientID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnNewDeptID" runat="server" Value="-1" />
                                <asp:HiddenField ID="hdnSelectedClient" runat="server" Value="" />
                                <asp:HiddenField ID="hdnSelectedParentDept" runat="server" Value="" />
                                <asp:HiddenField ID="hdnSelectedDept" runat="server" Value="" />
                                <asp:HiddenField ID="hdnExpectedDate" runat="server" Value="" />
                                <asp:HiddenField ID="hdnOrderSequence" runat="server" Value="0" />
                                <asp:HiddenField ID="hdnRowCount" runat="server" Value="0" />
                                <asp:HyperLink ID="hiddenUrl" runat="server" rel="facebox" NavigateUrl="~/Internal/Design/DesignerEditPopup.aspx"></asp:HyperLink>
                                <asp:TextBox runat="server" ID="txtOrderDate" Style="text-align: left; font-size: 13px;"
                                    Width="250px" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ORDER_DATE)? "th date_style":" date_style do-not-allow-typing" %>'></asp:TextBox>
                            </td>
                            <td width="22%" rowspan="8" align="center" valign="top">
                                <a class="sample-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                  <asp:Image runat="server" style="max-width:150px;width:auto" ID="imgPrint" CssClass="hide_me" />
                                </a>
                            </td>
                            <td width="22%" rowspan="8" align="center" valign="top">
                                <a class="sample-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                    <asp:Image runat="server" ID="imgStyle" style="max-width:150px;width:auto" CssClass="hide_me" />
                                </a>
                            </td>
                            <td width="22%" rowspan="8" align="center" valign="top">
                                <div id="divPrintImages" runat="server" style="width: 100px;">
                                    <a class="print-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                        <asp:Image runat="server" ID="imagePrint" style="max-width:150px;width:auto" CssClass="hide_me" />
                                    </a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Style Number*
                            </th>
                            <td style="text-align: left; font-size: 15px;" colspan="2">
                                <a href="#" id="aStyl" onclick="GetIdAddNew(this)">
                                    <img id="img13" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>
                                <a href="#" id="a1Styl" style="display: none;" onclick="GetIdDelNew(this)">
                                    <img id="img14" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a><strong>
                                        <asp:TextBox runat="server" ID="txtStyleNumber" Style="text-align: left; font-size: 17px;
                                            font-weight: bold;" Width="165px" validate="required:true" ToolTip="Style Number Is Required"
                                            CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_STYLE_NUMBER)? "required style-number":"style-number do-not-allow-typing" %>'></asp:TextBox></strong>
                                <asp:HiddenField ID="hdnParentStyleNumber" runat="server" />
                                <asp:HiddenField ID="hdnOldStyleId" runat="server" />
                                <asp:HiddenField ID="hdnOldStyleNumber" runat="server" />
                                <label id="lbltxtStyleNumber" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                            <td align="left">
                                <div class="style20 CheckOrder">
                                    Repeat with changes &nbsp;&nbsp;
                                    <input id="chkRepeatOrder" onclick="ShowAddStyleNumberBox(this)" type="checkbox" />
                                    <asp:HiddenField ID="hdnRepeatOrder" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnRepeatWithChanges" Value="0" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Buyer*
                            </th>
                            <td style="text-align: left; font-size: 13px;" colspan="3">
                                <asp:DropDownList ID="ddlClient" runat="server" Width="100%" Style="text-align: left;
                                    font-size: 13px;" 
                                    CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BUYER)? "order-client required":"order-client disable-dropdown" %>'>
                                    <asp:ListItem Value="-1">Select..</asp:ListItem>
                                </asp:DropDownList>
                                <div class="form_error">
                                    <asp:RequiredFieldValidator ID="rfv_ddlClient" InitialValue="-1" ValidationGroup="orderValidation"
                                        runat="server" Display="Dynamic" ControlToValidate="ddlClient" CssClass="rfv"
                                        ErrorMessage="Buyer is required"></asp:RequiredFieldValidator>
                                </div>
                                <label id="lblddlClient" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Parent Department*
                            </th>
                            <td style="text-align: left; font-size: 13px;" colspan="3">
                                <asp:DropDownList ID="ddlParentDept" runat="server" Width="100%" Style="text-align: left;
                                    font-size: 13px;">
                                    <asp:ListItem Value="-1">Select..</asp:ListItem>
                                </asp:DropDownList>
                                <div class="form_error">
                                    <asp:RequiredFieldValidator ID="rfv_ddlParentDept" InitialValue="-1" ValidationGroup="orderValidation"
                                        runat="server" Display="Dynamic" ControlToValidate="ddlParentDept" CssClass="rfv"
                                        ErrorMessage="Parent Department is required"></asp:RequiredFieldValidator>
                                </div>
                                <label id="lblddlParentDept" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Department
                            </th>
                            <td style="text-align: left; font-size: 13px;" colspan="3">
                                <asp:DropDownList ID="ddlDepartment" ToolTip="Department Is Required" runat="server"
                                    Width="100%" Style="text-align: left; font-size: 13px;" readonly="true" CssClass="required">
                                    <asp:ListItem Value="-1">Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnuserid" runat="server" Value="0" />
                                <label id="lblddlDepartment" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Serial No.*
                            </th>
                            <td style="text-align: left; font-size: 15px;" colspan="3">
                                <asp:TextBox runat="server" ID="txtIkandiSerial" validate="required:true" ToolTip="Serial No. Is Required"
                                    MaxLength="10" Width="250px" Style="text-align: left; font-size: 17px; font-weight: bold;"
                                    CssClass="required serial-number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Description
                            </th>
                            <td style="text-align: left; font-size: 13px;" colspan="3">
                                <asp:TextBox runat="server" ID="txtDescription" Width="250px" Style="text-align: left;
                                    font-size: 13px;" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DESCRIPTION)? "description":"do-not-allow-typing" %>'></asp:TextBox>
                                <label id="lbltxtDescription" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Total Qty
                            </th>
                            <td style="text-align: left; font-size: 15px;" class="CalculatedColumns">
                                <asp:TextBox BorderWidth="0px" runat="server" ID="txtTotalQty" validate="required:true"
                                    ToolTip="Quantity Is Required" Style="text-align: left; font-size: 17px; font-weight: bold;"
                                    Width="100px" CssClass="required numeric-field-without-decimal-places do-not-allow-typing total-qty CalculatedColumns"></asp:TextBox>
                                <label id="lbltxtTotalQty" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                            <th width="100px">
                                Order Type
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlordrType">
                                    <asp:ListItem Text="BIPL" Value="1" Selected="True">                            
                                    </asp:ListItem>                                   
                                    <asp:ListItem Text="Kasuka" Value="3">                            
                                    </asp:ListItem>
                                    <asp:ListItem Text="Value Added Style" Value="4">                            
                                    </asp:ListItem>
                                    <asp:ListItem Text="Gratitude exports" Value="5">                            
                                    </asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnkasukaprice" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Delivery Instruction
                            </th>
                            <td style="text-align: left; font-size: 13px;" class="CalculatedColumns" colspan="2">
                                <a href="#" id="aDele" onclick="GetIdAddNew(this)">
                                    <img id="img11" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a><a
                                        href="#" id="a1Dele" style="display: none;" onclick="GetIdDelNew(this)">
                                        <img id="img12" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>
                                <asp:TextBox BorderWidth="0px" runat="server" ID="txtDelInstruction" Style="text-align: left;
                                    font-size: 13px;" Width="100px" CssClass="do-not-allow-typing CalculatedColumns"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList Width="100px" runat="server" ID="ddlTypeOfPacking">
                                </asp:DropDownList>
                                <label id="lblddlTypeOfPacking" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th style="text-align: left;">
                                <%-- BIPL Price--%>
                                <asp:Label ID="lblbiplprice" runat="server" Text="BIPL Price"></asp:Label>
                            </th>
                            <td style="text-align: left; font-size: 15px; border-right: 0px !important;" colspan="2">
                                <a href="#" id="aBIPL" onclick="GetIdAddNew(this)">
                                    <img id="img15" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>
                                <a href="#" id="a1BIPL" style="display: none;" onclick="GetIdDelNew(this)">
                                    <img id="img16" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>
                                <asp:Label ID="lblBiplPriceSign" CssClass="currency-sign" runat="server"></asp:Label>
                                <asp:TextBox runat="server" ID="txtBIPLPrice" Width="80px" Style="text-align: left;
                                    font-size: 17px; font-weight: bold;" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE)? "numeric-field-with-two-decimal-places":"numeric-field-with-two-decimal-places do-not-allow-typing " %> '></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtDirectOrderiKandiPrice" Width="80px" Style="text-align: left;
                                    font-size: 15px; font-weight: bold;" Visible="false"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hdnCostingId" />
                                <label id="lbltxtBIPLPrice" class="duplicate duplicateCount" runat="server">
                                </label>
                            </td>
                            <td class="biplPrice" style="border-left: 0px !important; text-align: left;">
                                <%--  <asp:HyperLink ID="hypBiplPrice" runat="server" Target="costing form">

                                    <asp:Label ID="lblBiplPriceComments" runat="server" Style="font-size: 10px;"></asp:Label>

                                </asp:HyperLink>
                                <asp:TextBox runat="server" onchange="javascript:return ValidateOrderPrice(this);" ToolTip="Kasuka Price"   ID="txtkusakprice"  Width="41px" style="float:right;text-align: left; border:1px solid #39589c;font-size: 10px; font-weight: bold;display:none;" 
                                CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <th style="text-align: left;">
                                Account Manager
                            </th>
                            <td style="text-align: left" class="CalculatedColumns" colspan="2">
                                <asp:Label ID="lblAccntMgr" runat="server" Style="text-align: left; font-size: 16px;"
                                    CssClass="do-not-allow-typing CalculatedColumns"></asp:Label>
                            </td>
                            <td class="biplPrice" style="border-left: 0px !important; text-align: left;">
                                <asp:HyperLink ID="hypBiplPrice" runat="server" Target="costing form">
                                    <asp:Label ID="lblBiplPriceComments" runat="server" Style="font-size: 10px;"></asp:Label>
                                </asp:HyperLink>
                                <asp:TextBox runat="server" onchange="javascript:return ValidateOrderPrice(this);"
                                    ToolTip="Kasuka Price" ID="txtkusakprice" Width="41px" Style="float: right; text-align: left;
                                    border: 1px solid #39589c; font-size: 10px; font-weight: bold; display: none;"
                                    CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                            </td>
                            <th>
                                Front
                            </th>
                            <th>
                                Back
                            </th>
                            <th>
                                Print
                            </th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="form_box">
                <div id="divOrderBreakDown">
                </div>
                <div align="right" class="add-more-new">
                    <img src="../../App_Themes/ikandi/images/plus.gif" id="btnAddRow" class="add-row"
                        onclick="addRow(this)" />
                    Add More &nbsp;
                </div>
                <br />
                <br />
            </div>
            <div id="divRemark" class="divRemark">
                <div class="form_box  item_list1">
                    <div class="form_heading">
                        <strong>Proposal Form</strong>
                    </div>
                    <br />
                    <table width="750px" cellpadding="6px">
                        <tr>
                            <th style="vertical-align: top; text-align: center; width: 200px">
                                <strong>COMMENTS</strong> :
                            </th>
                            <td>
                                <asp:TextBox ID="txtRem" CssClass="txtRem" Rows="5" runat="server" TextMode="MultiLine"
                                    Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <input type="button" id="Button1" class="submit" onclick="SendEmail()" />
                        <input type="button" class="close do-not-disable" onclick="closeRemarks()" />
                    </div>
                </div>
            </div>
            <div class="form_box">
                <table width="100%" class="order_form_table item_list1" id="tblComments">
                    <tbody>
                        <tr>
                            <th style="text-align: center" colspan="1" class="">
                                <span><strong>Comments</strong></span>
                            </th>
                            <th style="text-align: center" colspan="1" class="">
                                <span><strong>Reminders</strong></span>
                            </th>
                        </tr>
                        <tr>
                            <td style="text-align: center; width: 50%;">
                                <textarea runat="server" id="txtComments1" style="text-align: center; font-size: 15px;"
                                    validate="required:false" width="100%" cols="180" rows="3" class='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_COMMENTS)? "numeric-field-with-two-decimal-places" : "do-not-allow-typing " %> '></textarea>
                            </td>
                            <td id="tdNewGrid" style="vertical-align: top;">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="100%" id="Table1" border="0">
                                                <tr>
                                                    <th style="width: 30%;">
                                                        Task Name
                                                    </th>
                                                    <th style="width: 55%;">
                                                        Reminder Description
                                                    </th>
                                                    <th style="width: 15%;">
                                                        Due Date
                                                    </th>
                                                </tr>
                                                <tr id="noReminder">
                                                    <td colspan="3">
                                                        <label id="lblMsg">
                                                            No Reminders to Show</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblNewGrid" border="0">
                                                <tr style="display: none;">
                                                    <td style="width: 30%">
                                                        <label id="newLable1">
                                                        </label>
                                                        <label id="txtLabel">
                                                        </label>
                                                        <input type="hidden" id="hdnType" name="hdnType" />
                                                    </td>
                                                    <td style="width: 55%">
                                                        <textarea id="txtDescr" cols="5" rows="1"></textarea>
                                                    </td>
                                                    <td style="width: 15%">
                                                        <input id="inputDate" type="text" class="th date_style" />
                                                    </td>
                                                    <td style="width: 0%; display: none;">
                                                        <button id="button" onclick="getDetail(this)">
                                                            Add</button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--   <button id="btn1Save" onclick="return saveDetail(this)">

                                                Save Reminder</button>--%>
                                            <asp:Button ID="btnSave" runat="server" CssClass="saveOrderRem" OnClick="btnSave_Click"
                                                OnClientClick="return saveDetail1(this);" ValidationGroup="orderValidation" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left; width: 100%;" class="CalculatedColumns">
                                <div style="height: 50px ! important; overflow: auto; width: 100% ! important; background-color: #eaf2dd">
                                    <asp:Label ID="lblikandiCommentsHistory" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th width="15%">
                                <strong>Deliver To*:</strong>
                            </th>
                            <td width="85%">
                                <asp:TextBox runat="server" ID="txtDeliverTo" Width="100%" CssClass="do-not-allow-typing"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hdnAddress" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!------------------add-by-prabhaker-------------->
            <div style="width: 80%; text-align: right; padding: 5px; display: none;">
                <asp:Label ID="lblCQD" runat="server" Text=""></asp:Label>
            </div>
            <!--------------------end-of-prabhaker------------------>
            <table width="100%" class="sign-table item_list1">
                <tbody>
                    <tr>
                        <td style="text-align: left; width: 700px;">
                            <b>Account Manager</b> (<span style="color: gray; text-transform: capitalize;"> I have
                                verified all material and CMT as per cost sheet before presenting to management
                                for approval. </span>)
                        </td>
                        <td align="center">
                            <asp:CheckBox runat="server" ID="checkBoxMerchandisingMgr" Checked="false" />
                        </td>
                        <td>
                            <b>Management</b>
                        </td>
                        <td align="center">
                            <asp:CheckBox runat="server" ID="checkBoxSalesMgrBIPL" Checked="false" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <asp:Label ID="lblBaseStyle" runat="server" Text=""></asp:Label>
        <a href="javascript:void(0)" onclick="showHide( this)">View History</a><br />
        <br />
        <div id="divHistory" style="height: 300px ! important; overflow: auto" class="hide_me">
            <div class="form_box">
                <div class="form_heading">
                    History</div>
                <br />
                <div>
                    <table width="100%" cellpadding="6px">
                        <tr>
                            <td style="width: 100%;">
                                <asp:Label ID="lblHistory" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <textarea id="templateBreakDown" style="display: none;" class="do-not-include">

 

    <table border="1px black solid" id="tableOrderDetail" class="form_table1" width="100%">

        

            <tr>

                <td colspan="15" align="left !important">

                    <strong>Order Breakdown</strong>

                </td>

            </tr>

           <tr>

                <td class="headings" style="width:5%">

                    Line/Item Number

                </td>

                <td  class="headings" style="width:5%">

                    Contract Number

                </td>

               

                <%-- <td  class="headings" style="width:9%;display:none;"  >

                    Buyer Contract

                </td>--%>

                <td class ="fabric-1 headings" style="width:220px !important;">
                    Fabric1
                     <img src="../../App_Themes/ikandi/images/plus1.gif" id="Img2"
                                       onclick="addFabric(2)" />                                      

                </td>

                <td class ="fabric-2 headings" style="width:220px !important;">

                   Fabric2

                    <img src="../../App_Themes/ikandi/images/plus1.gif" id="Img1" 

                                       onclick="addFabric(3)" />

                    <img src="../../App_Themes/ikandi/images/minus1.gif" id="Img6" 

                                       onclick="deleteFabric(2)" />

                                       

                </td>

                <td class ="fabric-3 headings" style="width:220px !important;">

                    Fabric3

                     <img src="../../App_Themes/ikandi/images/plus1.gif" id="Img3" 

                                       onclick="addFabric(4)" />

                     <img src="../../App_Themes/ikandi/images/minus1.gif" id="Img5" 

                                       onclick="deleteFabric(3)" />          

                </td>

                <td class ="fabric-4  headings" style="width:220px !important;">

                    Fabric4

                     <img src="../../App_Themes/ikandi/images/minus1.gif" id="Img4" 

                                       onclick="deleteFabric(4)" />

                </td>

                <td  class="headings" style="width:5%">

                    Qty

                </td>

                <td  class="headings" style="width:5%">

                    Mode

                </td>

                 <td   style="width:5%" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE)? "headings":"headings hide_me" %>'>

                    BIPL Price 

                </td>

                <td   style="width:5%" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE)? "headings":"headings hide_me" %>'>

                    IKandi Price 

                </td>

                <td  class="headings" style="width : 10%">

                    Ex Factory

                </td>

                <td  class="headings  " style="width:4%">

                    Weeks to Ex

                </td>

                <td  class="headings" style="width : 10%">

                    DC

                </td>

                <td  class="headings "  style="width:4%">

                    Weeks to DC

                </td>

                <td  class="headings to-remove" style="width:3%">

                    Sizes

                </td>

                 <td  class="headings to-remove" style="width:1%">

                   

                </td>

            

            </tr>

            {#foreach $T.table as record}

            <tr id="tr{$P.x}" style="height:60px !important;">

                <td style="vertical-align:top; width:100px;"> 

                    <input type="hidden"  id="txtOrderDetailID{$P.x}" name="txtOrderDetailID{$P.x}" value="{$T.record.OrderDetailID}" />

                    <input type="hidden"  id="txtStatusModeID{$P.x}" name="txtStatusModeID{$P.x}" value="{$T.record.StatusModeID}" />

                    <input type="hidden"  id="txtStatusModeSequence{$P.x}" name="txtStatusModeSequence{$P.x}" value="{$T.record.StatusModeSequence}" />

                    <input type="hidden" value="0" id="txtIsDeleted{$P.x}" name="txtIsDeleted{$P.x}" />

                    <input type="hidden" value="asc" id="hdnSortType{$P.x}" class="hdnSort" name="hdnSortType{$P.x}" />

                    <input type="hidden" value="0" id="txtIsQuantityInc{$P.x}" name="txtIsQuantityInc{$P.x}" />

                    <input type="hidden" value="0" id="txtIsSplit{$P.x}" name="txtIsSplit{$P.x}" />

                    <input type="hidden" value="0" id="txtIsSplitted{$P.x}" name="txtIsSplitted{$P.x}" />

                    <input type="hidden" value="0" id="hdnParentOrderDetailID{$P.x}" name="hdnParentOrderDetailID{$P.x}" />

                    <input type="text" value="{$T.record.OrderDetailID}" style="display:none;" id="hdnManualNo{$P.x}" name="hdnManualNo{$P.x}" />

                <a href="#" id="aLine-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgLine-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Line-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Line-{$P.x}" border="0" src="../../Images/icon1.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <input type="text" name="txtLineItemNumber{$P.x}" id="txtLineItemNumber{$P.x}" value="{$T.record.LineItemNumber}" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_LINE_ITEM_NUMBER)? "table_element_style":"table_element_style do-not-allow-typing" %>' style="width :80px;" />

                 <label id="lbltxtLineItemNumber{$P.x}" class="duplicate duplicateCount">{$T.record.LineItemNumber_d}</label>

                </td>

                <td style="vertical-align:top; width:100px;">

 

                <a href="#" id="aCont-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgContr-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Cont-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="imgContr1-{$P.x}" border="0" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' src="../../Images/icon1.png" /></a>

                <input  type="text" name="txtContractNumber{$P.x}" id="txtContractNumber{$P.x}" value="{$T.record.ContractNumber}" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_NUMBER)? "table_element_style":"table_element_style do-not-allow-typing" %>' style="width :80px;" />

                <label id="lbltxtContractNumber{$P.x}" class="duplicate duplicateCount">{$T.record.ContractNumber_d}</label>

               </td>


                <td class ="fabric-1">

                  <div style="padding:0px !important;margin:0px !important; width:220px !important; ">

<nobr>

                      <a href="#" id="aFbrb-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgFaba-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                    <a href="#" id="a1Fbrb-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Faba-{$P.x}" border="0" src="../../Images/icon1.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                       <input type="text" name="txtFabrica{$P.x}" maxlength="145" id="txtFabric11{$P.x}"  value="{$T.record.Fabric1}"   onfocus="clearDefault(this, 'Fabric')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC1)? "fabric-type table_element_style":"table_element_style do-not-allow-typing" %>' style="width:215px;" />

</nobr>

                       <div style="float:left;width:170px !important;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px; text-align:center; font-size:smaller;  ">

                            <label  style="align:center" name="lbFabric11{$P.x}" class="fabric-type" id="lbFabric11{$P.x}">{$T.record.CCGSM1}</label>                       

                       </div>

                       

                       <div style="float:right;width:60px !important;vertical-align:top;height:20px; padding-right:0px; padding-top:0px; text-align:center; " >

                           <nobr>

                               <span {#if $T.record.Fabric1Origin == '1' || $T.record.Fabric1Origin == '2'} class="div_show" {#else} class="div_show hide_me"{#/if}>

                                  <label name="lblOrigin{$P.x}" id="lblOrigin{$P.x}" class="origin">{#if $T.record.Fabric1Origin == '1'} Ind {#elseif $T.record.Fabric1Origin == '2'} Imp {#else} {#/if}</label>&nbsp;

                                    <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" onclick="return launchFabricQualityPopup(this)" id="hlkQuality1" class="hlkQuality" >

                                        <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg" border="0" /></a>

                               </span>

                           </nobr>

                        </div>

                  </div>

                   <div style="clear:both;"></div>                  

                   <div class="CalculatedColumns" style="vertical-align:bottom; padding-bottom:0px !important;height:20px !important;">

                       <div style="float:left;width:186px;vertical-align:bottom;height:20px !important; padding-bottom:0px; padding-left:0px;" class="CalculatedColumns">

                      &nbsp;IA:<input type=checkbox name="chkIA11{$P.x}" value="1"  {#if $T.record.IAFabric1 == 'True' || $T.record.IAFabric1 == '1'} checked disabled {#/if}  class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC1_DETAILS)? "":"disable-checkbox" %>'  />    

                      <input style="width:120px !important" type="text" name="txtFabric12{$P.x}"  id="txtFabric12{$P.x}"  maxlength=145  value="{$T.record.Fabric1Desc}" onfocus="clearDefault(this, 'Color / PRD')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC1_DETAILS)? "print-number table_element_style CalculatedColumns":"print-number table_element_style do-not-allow-typing CalculatedColumns" %>' />

                       

                       <input type=checkbox name="hdnChkIA11{$P.x}" class="hide_me" value="1"  {#if $T.record.IAFabric1 == 'True' || $T.record.IAFabric1 == '1'} checked {#/if} />

                       </div>

                       <div style="float:right;width:60px;vertical-align:bottom;height:20px !important; padding-right:0px; padding-bottom:0px;" class="CalculatedColumns ">

                         <nobr>

                             <span {#if $T.record.Fabric1Origin == '2'} class="div_show div_origin" {#else} class="div_show hide_me div_origin"{#/if}>

                                <input type="radio" name="radioMode1{$P.x}" id="radioMode1{$P.x}" value="1" class="radio_mode" {#if $T.record.IsAirFabric1 == 'True' || $T.record.IsAirFabric1 == '1'} checked {#/if} />A

                                <input type="radio" name="radioMode1{$P.x}" id="radioMode1{$P.x}" value="0" class="radio_mode" {#if $T.record.IsAirFabric1 == 'False' || $T.record.IsAirFabric1 == '0'} checked {#/if}/>S

                             </span>

                             

                         </nobr>

                       </div>

                   </div>                      

                   <div style="clear:both;"></div>

                   <label id="lbltxtFabric11{$P.x}" class="duplicate duplicateCount" >{$T.record.Fabric1_d}</label>

                   <label id="lbltxtFabric12{$P.x}" class="duplicate duplicateCount" >{$T.record.Fabric1Details_d}</label>

                   <label id="lblchkIA11" class="duplicate duplicateCount1" >{$T.record.IAFabric1Text_d}</label>

                </td>

              <td class ="fabric-2">

               <div style="padding:0px !important;margin:0px !important; width:220px !important;">

               <div style="float:left;width:245px;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px;  ">

                      <a href="#" id="aFbrc-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgFabb-{$P.x}" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Fbrc-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Fabb-{$P.x}" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                       <input type="text" name="txtFabricb{$P.x}" maxlength=145 id="txtFabric21{$P.x}"  value="{$T.record.Fabric2}"  onfocus="clearDefault(this, 'Fabric')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC2)? "fabric-type table_element_style":"fabric-type table_element_style do-not-allow-typing" %>' style="width:215px;" />

                    </div>

                    <div style="float:left;width:190px !important;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px; text-align:center;  font-size:smaller; ">

                            <label name="lbFabric21{$P.x}" class="fabric-type" id="lbFabric21{$P.x}">{$T.record.CCGSM2}</label>                       

                       </div>

                       

                       <div style="float:right;width:60px;vertical-align:top;height:20px; padding-right:0px; padding-top:0px; text-align:center;" >

                           <nobr>

                               <span {#if $T.record.Fabric2Origin == '1' || $T.record.Fabric2Origin == '2'} class="div_show" {#else} class="div_show hide_me"{#/if}>

                              <label name="lblOrigin{$P.x}" id="Label1" class="origin">{#if $T.record.Fabric2Origin == '1'} Ind {#elseif $T.record.Fabric2Origin == '2'} Imp {#else} {#/if}</label>&nbsp;

                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="A1" onclick="return launchFabricQualityPopup(this)" class="hlkQuality" >

                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg" border="0" /></a>

                                    </span>

                        </nobr> 

                        </div>

                  </div>

                   <div style="clear:both;"></div>                        

                   <div class="CalculatedColumns" style="vertical-align:bottom; padding-bottom:0px !important;height:20px !important;">

                       <div style="float:left;width:186px;vertical-align:bottom;height:20px !important; padding-bottom:0px; padding-left:0px;" class="CalculatedColumns">

                        &nbsp;IA:<input type=checkbox name="chkIA21{$P.x}" value="1"  {#if $T.record.IAFabric2 == 'True' || $T.record.IAFabric2 == '1'} checked disabled {#/if} class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC2_DETAILS)? "":"disable-checkbox" %>' />    

                        <input style="width:120px !important" type="text" name="txtFabric22{$P.x}" id="txtFabric22{$P.x}" maxlength=145 value="{$T.record.Fabric2Desc}"  onfocus="clearDefault(this, 'Color / PRD')"  class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC2_DETAILS)? "print-number table_element_style CalculatedColumns":"print-number table_element_style do-not-allow-typing CalculatedColumns" %>'/>

                      

                      <input type=checkbox name="hdnChkIA21{$P.x}" class="hide_me" value="1"  {#if $T.record.IAFabric2 == 'True' || $T.record.IAFabric2 == '1'} checked {#/if} />

                      

                      </div>

                       <div style="float:right;width:60px;vertical-align:bottom;height:20px !important; padding-right:0px; padding-bottom:0px;" class="CalculatedColumns ">

                         <nobr>

                              <span {#if $T.record.Fabric2Origin == '2'} class="div_show div_origin" {#else} class="div_show hide_me div_origin"{#/if}>

                                <input type="radio" name="radioMode2{$P.x}" id="radioMode2{$P.x}" value="1" class="radio_mode" {#if $T.record.IsAirFabric2 == 'True' || $T.record.IsAirFabric2 == '1'} checked {#/if}/>A

                                <input type="radio" name="radioMode2{$P.x}" id="radioMode2{$P.x}" value="0" class="radio_mode" {#if $T.record.IsAirFabric2 == 'False' || $T.record.IsAirFabric2 == '0'} checked {#/if} />S

                        </span>

                        </nobr>

                       </div>

                   </div>  

                   <div style="clear:both;"></div>

                    <label id="lbltxtFabric21{$P.x}" class="duplicate duplicateCount">{$T.record.Fabric2_d}</label>

                    <label id="lbltxtFabric22{$P.x}" class="duplicate duplicateCount" >{$T.record.Fabric2Details_d}</label>

                    <label id="lblchkIA21" class="duplicate duplicateCount1" >{$T.record.IAFabric2Text_d}</label>

                </td>

                <td class ="fabric-3">

                <div style="padding:0px !important;margin:0px !important; width:220px !important;">

                    <div style="float:left;width:245px;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px;  ">

                         <a href="#" id="aFbrd-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="img7" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Fbrd-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img8" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                       <input type="text" name="txtFabricc{$P.x}" maxlength=145 id="txtFabric31{$P.x}"  value="{$T.record.Fabric3}"  onfocus="clearDefault(this, 'Fabric')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC3)? "fabric-type table_element_style":"fabric-type table_element_style do-not-allow-typing" %>' style="width:215px;" />

                         <%--<input type="text" name="txtFabric21{$P.x}" maxlength=30 id="Text1"  value="{$T.record.Fabric2}"  onfocus="clearDefault(this, 'Fabric')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC2)? "fabric-type table_element_style":"fabric-type table_element_style do-not-allow-typing" %>'  />--%>

                    </div>

                     <div style="float:left;width:170px !important;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px; text-align:center;  font-size:smaller; ">

                            <label name="lbFabric31{$P.x}" class="fabric-type" id="lbFabric31{$P.x}">{$T.record.CCGSM3}</label>                       

                       </div>

                       

                       <div style="float:right;width:60px;vertical-align:top;height:20px; padding-right:0px; padding-top:0px; text-align:center; " >

                           <nobr>

                               <span {#if $T.record.Fabric3Origin == '1' || $T.record.Fabric3Origin == '2'} class="div_show" {#else} class="div_show hide_me"{#/if}>

                              <label name="lblOrigin{$P.x}" id="Label2" class="origin">{#if $T.record.Fabric3Origin == '1'} Ind {#elseif $T.record.Fabric3Origin == '2'} Imp {#else} {#/if}</label>&nbsp;

                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="A2" onclick="return launchFabricQualityPopup(this)" class="hlkQuality" >

                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg" border="0" /></a>

                                    </span>

                        </nobr>

                        </div>

                  </div>

                     <div style="clear:both;"></div>                      

                   <div class="CalculatedColumns" style="vertical-align:bottom; padding-bottom:0px !important;height:20px !important;">

                       <div style="float:left;width:186px;vertical-align:bottom;height:20px !important; padding-bottom:0px; padding-left:0px;" class="CalculatedColumns">

                        &nbsp;IA:<input type=checkbox name="chkIA31{$P.x}" value="1" {#if $T.record.IAFabric3 == 'True' || $T.record.IAFabric3 == '1'} checked disabled {#/if} class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC3_DETAILS)? "":"disable-checkbox" %>' />   

                        <input  style="width:120px !important"  name="txtFabric32{$P.x}" id="txtFabric32{$P.x}"  maxlength=145 value="{$T.record.Fabric3Desc}"  onfocus="clearDefault(this, 'Color / PRD')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC3_DETAILS)? "print-number table_element_style CalculatedColumns":"print-number table_element_style do-not-allow-typing CalculatedColumns" %>' />

                       

                       <input type=checkbox name="hdnChkIA31{$P.x}" class="hide_me" value="1"  {#if $T.record.IAFabric3 == 'True' || $T.record.IAFabric3 == '1'} checked {#/if} />

                        </div>

                       <div style="float:right;width:60px;vertical-align:bottom;height:20px !important; padding-right:0px; padding-bottom:0px;" class="CalculatedColumns ">

                         <nobr>

                              <span {#if $T.record.Fabric3Origin == '2'} class="div_show div_origin" {#else} class="div_show hide_me div_origin"{#/if}>

                                <input type="radio" name="radioMode3{$P.x}" id="radioMode3{$P.x}" value="1" class="radio_mode" {#if $T.record.IsAirFabric3 == 'True' || $T.record.IsAirFabric3 == '1'} checked {#/if}/>A

                                <input type="radio" name="radioMode3{$P.x}" id="radioMode3{$P.x}" value="0" class="radio_mode" {#if $T.record.IsAirFabric3 == 'False' || $T.record.IsAirFabric3 == '0'} checked {#/if} />S

                                </span>

                         </nobr> 

                      </div>

                   </div>

                   <div style="clear:both;"></div>

                    <label id="lbltxtFabric31{$P.x}" class="duplicate duplicateCount">{$T.record.Fabric3_d}</label>

                    <label id="lbltxtFabric32{$P.x}" class="duplicate duplicateCount" >{$T.record.Fabric3Details_d}</label>

                    <label id="lblchkIA31" class="duplicate duplicateCount1" >{$T.record.IAFabric3Text_d}</label>

                </td>

                <td class ="fabric-4">

                   <div style="padding:0px !important;margin:0px !important; width:220px !important;">

                   <div style="float:left;width:245px;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px;  ">

                           <a href="#" id="aFbre-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn">

                   <img id="img9" border="0" src="../../Images/icon.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                   <a href="#" id="a1Fbre-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn">

                   <img id="img10" border="0" src="../../Images/icon1.png" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                       <input type="text" name="txtFabricd{$P.x}" maxlength=145 id="txtFabric41{$P.x}"  value="{$T.record.Fabric4}"  onfocus="clearDefault(this, 'Fabric')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC4)? "fabric-type table_element_style":"fabric-type table_element_style do-not-allow-typing" %>' style="width:215px;" />

                      </div>

                        <div style="float:left;width:170px !important;vertical-align:top;height:20px;  padding-left:0px; padding-top:0px; text-align:center;  font-size:smaller; ">

                            <label name="lbFabric41{$P.x}" class="fabric-type" id="lbFabric41{$P.x}">{$T.record.CCGSM4}</label>                       

                       </div>

                       

                       <div style="float:right;width:60px;vertical-align:top;height:20px; padding-right:0px; padding-top:0px;"  text-align:center;>

                           <nobr>

                               <span {#if $T.record.Fabric4Origin == '1' || $T.record.Fabric4Origin == '2'} class="div_show" {#else} class="div_show hide_me"{#/if}>

                              <label name="lblOrigin{$P.x}" id="Label3" class="origin">{#if $T.record.Fabric4Origin == '1'} Ind {#elseif $T.record.Fabric4Origin == '2'} Imp {#else} {#/if}</label>&nbsp;

                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="A3" onclick="return launchFabricQualityPopup(this)" class="hlkQuality" >

                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg" border="0" /></a>

                                    </span>

 

                        </nobr>

                        </div>

                  </div>

                    <div style="clear:both;"></div>                       

                   <div class="CalculatedColumns" style="vertical-align:bottom; padding-bottom:0px !important;height:20px !important;">

                       <div style="float:left;width:186px;vertical-align:bottom;height:20px !important; padding-bottom:0px; padding-left:0px;" class="CalculatedColumns">

                       &nbsp;IA:<input type=checkbox name="chkIA41{$P.x}" value="1" {#if $T.record.IAFabric4 == 'True' || $T.record.IAFabric4 == '1'} checked disabled {#/if} class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC4_DETAILS)? "":"disable-checkbox" %>' /> 

                       <input  style="width:120px !important"  type="text" name="txtFabric42{$P.x}" id="txtFabric42{$P.x}" maxlength=20 value="{$T.record.Fabric4Desc}"  onfocus="clearDefault(this, 'Color / PRD')" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC4_DETAILS)? "print-number table_element_style CalculatedColumns":"print-number table_element_style do-not-allow-typing CalculatedColumns" %>' />

                       

                       <input type=checkbox name="hdnChkIA41{$P.x}" class="hide_me" value="1"  {#if $T.record.IAFabric4 == 'True' || $T.record.IAFabric4 == '1'} checked {#/if} />

                       </div>

                       <div style="float:right;width:60px;vertical-align:bottom;height:20px !important; padding-right:0px; padding-bottom:0px;" class="CalculatedColumns ">

                         <nobr>

                              <span {#if $T.record.Fabric4Origin == '2'} class="div_show div_origin" {#else} class="div_show hide_me div_origin"{#/if}>

                                <input type="radio" name="radioMode4{$P.x}" id="radioMode4{$P.x}" value="1" class="radio_mode" {#if $T.record.IsAirFabric4 == 'True' || $T.record.IsAirFabric4 == '1'} checked {#/if}/>A

                                <input type="radio" name="radioMode4{$P.x}" id="radioMode4{$P.x}" value="0" class="radio_mode" {#if $T.record.IsAirFabric4 == 'False' || $T.record.IsAirFabric4 == '0'} checked {#/if} />S

                                </span> 

                         </nobr>

                      </div>

                   </div>

                   <div style="clear:both;"></div>

                   <label id="lbltxtFabric41{$P.x}" class="duplicate duplicateCount">{$T.record.Fabric4_d}</label>

                   <label id="lbltxtFabric42{$P.x}" class="duplicate duplicateCount" >{$T.record.Fabric4Details_d}</label>

                   <label id="lblchkIA41" class="duplicate duplicateCount1" >{$T.record.IAFabric4Text_d}</label>

 

                </td>

                 <td style="vertical-align:top;width:90px;">

                <a href="#" id="aQnty-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgQnty-{$P.x}" border="0" src="../../images/icon.jpg" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Qnty-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Qnty-{$P.x}" border="0" src="../../images/minus_icon1.jpg" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <input type="text" class="table_element_style numeric-field-without-decimal-places required" onblur="validateQty(this);" title="Quantity is Required"  validate="required:true" name="txtQty{$P.x}" id="txtQty{$P.x}" value="{$T.record.Quantity} " onchange="(updateQuantity(),checkQuantity( this))"  style="text-align:left; font-size:13px; font-weight:bold; width:60px;" />

                <input type="hidden" value="0" id="hdnSizeTotalQty{$P.x}" name="hdnSizeTotalQty{$P.x}" />

                <label id="lbltxtQty{$P.x}" class="duplicate duplicateCount">{$T.record.Quantity_d}</label>

                </td>

                <td class="table_element_style" style="vertical-align:top;width:160px;">

 

                    <input class="table_element_style"  title="Mode Is Required" type="hidden" name="hdnMode{$P.x}" id="hdnMode{$P.x}" value="" validate="required:true"   />

                    <a href="#" id="aMode-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgMode-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                    <a href="#" id="a1Mode-{$P.x}" title="{$T.record.OrderDetailID}" style= "display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Mode-{$P.x}" border="0" src="../../Images/icon1.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                    <select  id="ddlMode{$P.x}" size="1" name="ddlMode{$P.x}" onfocus="GetCurrentValue(this);" onchange="javascript:return onModeChange(this)" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_MODE)? "":"disable-dropdown" %>' style="width:130px;"><option value="-1">Select..</option>
                        
                         <asp:Repeater runat="server" ID="ddlDeliveryMode">

                            <ItemTemplate>

                                <option value='<%# Eval("Id")  %>' {#if $T.record.Mode == '<%# Eval("Id")  %>' } selected {#/if} ><%# Eval("Code")%></option>

                                           </ItemTemplate> 

                                 </asp:Repeater>

                    </select>

                    <label id="lblddlMode{$P.x}" class="duplicate duplicateCount">{$T.record.ModeName_d}</label>

                    <label id="lblddlModeCode{$P.x}" class="duplicate duplicateCount" style="Display:none;"><%# Eval("Mode_d")%></label>

               </td>

                <td class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE)? " value_style":" value_style hide_me" %>' >
                 
                 <div style="text-align:center"><label class="currency-sign" style="display:none;" id="lblOldBiplPriceSign{$P.x}">{$T.record.ParentOrder.Costing.CurrencySign}</label> 
                 <label class="TextDecoration" id="lbltxtodBIPLPrice{$P.x}"></label> 
                  <input type="hidden" value="" id="hdnOdBIPLPrice{$P.x}" name="hdnOdBIPLPrice{$P.x}" /> </div>    
              
                    <span  style="font-size:13px; font-weight:bold" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE)? " ":"  hide_me" %>'>
                     <label style="font-size:13px; font-weight:bold" class="currency-sign" id="lblodBIPLPriceSign">{$T.record.ParentOrder.Costing.CurrencySign}</label>
                    </span><input  style="width:40px; text-align:left; font-size:13px; font-weight:bold" type="text" maxlength="5" name="txtodBIPLPrice{$P.x}" id="txtodBIPLPrice{$P.x}"   class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE)? "numeric-field-with-two-decimal-places":"do-not-allow-typing " %>'/>
                    
                </td>

                <td class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE)? " value_style":" value_style hide_me" %>' >

                    <span  style="font-size:13px; font-weight:bold" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE)? " ":"  hide_me" %>'>

                     <label style="font-size:13px; font-weight:bold" class="currency-sign" id="lblIkandiPriceSign{$P.x}">{$T.record.ParentOrder.Costing.CurrencySign}</label>

                    </span><input  style="width:40px; text-align:left ; font-size:13px; font-weight:bold" type="text" name="txtIkandiPrice{$P.x}" id="txtIkandiPrice{$P.x}" value="{$T.record.iKandiPrice}" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE)? "":"do-not-allow-typing " %>'/>

                 <label id="lbltxtIkandiPrice{$P.x}" class="hide_me">{$T.record.iKandiPrice_d}</label>

                </td>

                <td style=" width : 120px ! important;background-color:{$T.record.ExFactoryColor}">

                    <input type="text" name="txtExFactory{$P.x}" id="txtExFactory{$P.x}" validate="required:true" title="ExFactory is Required"  class="required do-not-allow-typing date_style table_element_style" value="{$T.record.ExFactoryInString}" style=" width : 120px ! important ;text-align:left; font-size:13px; font-weight:bold;background-color:{$T.record.ExFactoryColor} " />

                     <input type="hidden" name="hdnExFactory{$P.x}" id="hdnExFactory{$P.x}" class="date_style table_element_style" value="{$T.record.ExFactoryInString}" />

                      <input type="hidden" name="hdnBulk{$P.x}" id="hdnBulk{$P.x}" class="date_style table_element_style" value="{$T.record.BulkTargetInString}" />

                      <input type="hidden" name="hdnLabDipTarget{$P.x}" id="Hidden1" class="date_style table_element_style" value="{$T.record.LabDipTargetInString}" />
                      <input id="hdnPCdate{$P.x}" name="hdnPCdate{$P.x}" value="0" type="hidden" />    
                      <input type="hidden" name="hdnPCD{$P.x}" id="hdnPCD{$P.x}" class="date_style table_element_style" value="{$T.record.PCDInString}" />                 
                      

                 <label id="lbltxtExFactory{$P.x}" class="duplicate duplicateCount">{$T.record.ExFactoryInString_d}</label>                  

                </td>

                <td class="CalculatedColumns" style="vertical-align:top;">

                    <input type="text" name="txtWeeksToEx{$P.x}" id="txtWeeksToEx{$P.x}" value="{$T.record.WeekToEx}" class="do-not-allow-typing table_element_style CalculatedColumns" />

                    <label id="lbltxtWeeksToEx{$P.x}" class="duplicate duplicateCount">{$T.record.WeekToEx_d}</label>

                </td>

                <td style="vertical-align:top;width:150px;">

                <a href="#" id="aDCdt-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgDCdt-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1DCdt-{$P.x}" title="{$T.record.OrderDetailID}" style="display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1DCdt-{$P.x}" border="0" src="../../Images/icon1.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <input style="font-size:13px;font-weight:bold; width : 120px ! important;" type="text" name="txtDC{$P.x}" id="txtDC{$P.x}"  value="{$T.record.DCInString}"  validate="required:true" title="DC is Required"  class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DC_DATE)? "th dc table_element_style required":"do-not-allow-typing date_style dc table_element_style required" %>'  /> 

                <label id="lbltxtDC{$P.x}" class="duplicate duplicateCount">{$T.record.DCInString_d}</label>
                <input type="hidden" name="hdnDC{$P.x}" id="hdnDC{$P.x}" class="date_style table_element_style" value="{$T.record.DCInString}" />   

                </td>

                <td class="CalculatedColumns" style="vertical-align:top;">

                    <input  type="text" name="txtWeeksToDC{$P.x}" id="txtWeeksToDC{$P.x}" value="{$T.record.WeeksToDC}" class="do-not-allow-typing table_element_style table_element_style CalculatedColumns" />

               <label id="lbltxtWeeksToDC{$P.x}" class="duplicate duplicateCount">{$T.record.WeeksToDC_d}</label>

                </td>

                <td class ="to-remove" style="vertical-align:top;">

                <a href="#" id="aSize-{$P.x}" title="{$T.record.OrderDetailID}" onclick="GetIdAdd(this)" class="blueBtn"><img id="imgSize-{$P.x}" border="0" src="../../Images/icon.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

                <a href="#" id="a1Size-{$P.x}" title="{$T.record.OrderDetailID}" style="display:none;" onclick="GetIdDel(this)" class="redBtn"><img id="img1Size-{$P.x}" border="0" src="../../Images/icon1.png" style="vertical-align:top;" class='<%= iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_REMINDERS)? "hide_me":"hide_me" %>' /></a>

               <br />
                                                                                                                                                   
                <a href="#" name="linkCreate{$P.x}" id="linkCreate{$P.x}" onclick="showSizeTable( this)" class="{$T.record.StatusModeID} > 7 ? "" : hide_me" >CREATE</a>

                <br />

                <br />

                  <table  id="subtable{$P.x}" name="subtable{$P.x}" class="size-table sub_table" cellpadding="5px" >

                 <tr><td colspan="21"><div class="form_heading">SIZE BREAKDOWN</div><br /></td></tr>

                   <tr>

                    <td colspan="21" style="text-align:left">

                     Line Number :<label id="Label4">{$T.record.LineItemNumber}</label>

                     &nbsp;|&nbsp;

                     Contract Number :<label id="Label5">{$T.record.ContractNumber}</label>
                     <br />
                    <%-- Added By Ashish on 28/10/2014--%>
                   <%-- <div id="showhide" name="showhide>--%>
                    <%--<div id="showhide{$P.x}" name="showhide{$P.x}" class="showhide{$P.x}" type="div">
                     <div class="clearBoth"></div>
                    <input type="radio" title="2,4,6,8,10,12,14,16,18,20,22,24"  name="editList" id="Option1{$P.x}" value="1" onclick="FillSizeByOption(this)">Option1
                    <input type="radio"  name="editList" id="Option2{$P.x}" value="2" onclick="FillSizeByOption(this)">Option2
                    <input type="radio"  name="editList" id="Option3{$P.x}" value="3" onclick="FillSizeByOption(this)">Option3
                    <input type="radio"  name="editList" id="Option4{$P.x}" value="4" onclick="FillSizeByOption(this)">Option4
                    <div class="clearBoth"></div>
                    </div>--%>

                    <div id="OptionDiv{$P.x}" name="OptionDiv{$P.x}" type="OptionDiv">
                    
                    </div>

                    <input  type="hidden" name="Option_{$P.x}" id="Option_{$P.x}" value="{$T.record.SizeOption}" />

                    <input  type="hidden" name="OptionSize_{$P.x}" id="OptionSize_{$P.x}" value="{$T.record.SizeOption}" />


                   <%-- END--%>

                    </td>

                   </tr>

                    <tr class = "hide_me">

                           <td colspan="3"></td>

                                  <td>

                                         <input  class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID1_{$P.x}" id="txtOrderDetailSizeID1{$P.x}" /> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID2_{$P.x}" id="txtOrderDetailSizeID2{$P.x}" maxlength="12" size="4" /> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID3_{$P.x}" id="txtOrderDetailSizeID3{$P.x}" maxlength="12" size="4" /> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID4_{$P.x}" id="txtOrderDetailSizeID4{$P.x}" maxlength="12" size="4" /> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID5_{$P.x}" id="txtOrderDetailSizeID5{$P.x}" maxlength="12" size="4" /> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID6_{$P.x}" id="txtOrderDetailSizeID6{$P.x}"  maxlength="12" size="4"/> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID7_{$P.x}" id="txtOrderDetailSizeID7{$P.x}"  maxlength="12" size="4"/> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID8_{$P.x}" id="txtOrderDetailSizeID8{$P.x}"  maxlength="12" size="4"/> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID9_{$P.x}" id="txtOrderDetailSizeID9{$P.x}"  maxlength="12" size="4"/> </td>

                                  <td>

                                        <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID10_{$P.x}" id="txtOrderDetailSizeID10{$P.x}"  maxlength="12" size="4"/> </td>

                                  <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID11_{$P.x}" id="txtOrderDetailSizeID11{$P.x}"  maxlength="12" size="4"/> </td>

                                   <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID12_{$P.x}" id="txtOrderDetailSizeID12{$P.x}" maxlength="12" size="4"/> </td>

                                   <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID13_{$P.x}" id="txtOrderDetailSizeID13{$P.x}"  maxlength="12" size="4"/> </td>

                                   <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID14_{$P.x}" id="txtOrderDetailSizeID14{$P.x}" /> </td>

                                   <td>

                                         <input class="order-detail-size-id" type="hidden" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].OrderDetailSizeID}" {#/if} name="txtOrderDetailSizeID15_{$P.x}" id="txtOrderDetailSizeID15{$P.x}" /> </td>

                                  <td colspan="3" width="20px">

                                        

                                  </td>

                                 

                            </tr>

                           <tr>

                           <th colspan="3" style="width:100px !important" >Size </th>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input  type="text" class="column_color do-not-allow-typing"  onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].Size}" {#/if} name="txtSize1_{$P.x}" id="txtSize1{$P.x}" maxlength="10" size="4"  />

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].Size}" {#/if} name="txtSize2_{$P.x}" id="txtSize2{$P.x}" maxlength="10" size="4" />

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing"  onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].Size}" {#/if} name="txtSize3_{$P.x}" id="txtSize3{$P.x}" maxlength="10" size="4" />

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].Size}" {#/if} name="txtSize4_{$P.x}" id="txtSize4{$P.x}" maxlength="10" size="4" />

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].Size}" {#/if} name="txtSize5_{$P.x}" id="txtSize5{$P.x}" maxlength="10" size="4" />

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].Size}" {#/if} name="txtSize6_{$P.x}" id="txtSize6{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].Size}" {#/if} name="txtSize7_{$P.x}" id="txtSize7{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].Size}" {#/if} name="txtSize8_{$P.x}" id="txtSize8{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].Size}" {#/if} name="txtSize9_{$P.x}" id="txtSize9{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                        <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].Size}" {#/if} name="txtSize10_{$P.x}" id="txtSize10{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                  <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].Size}" {#/if} name="txtSize11_{$P.x}" id="txtSize11{$P.x}"  maxlength="10" size="4"/>

                                  </td>

                                   <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].Size}" {#/if} name="txtSize12_{$P.x}" id="txtSize12{$P.x}" maxlength="10" size="4"/>

                                  </td>

                                   <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].Size}" {#/if} name="txtSize13_{$P.x}" id="txtSize13{$P.x}"  maxlength="10" size="4"/>

                                         

                                  </td>

                                   <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].Size}" {#/if} name="txtSize14_{$P.x}" id="txtSize14{$P.x}" /> 

                                  </td>

                                   <td class="edit-drag column_color" style="width : 40px ! important;">

                                         <input type="text" class="column_color do-not-allow-typing" onchange="UpdateValuesIfDeleted( this)" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].Size}" {#/if} name="txtSize15_{$P.x}" id="txtSize15{$P.x}" /> 

                                  </td>

                                


                                  <td colspan="3" style="width:40px! important" class="column_color ">

                                        <Label class="column_color" ID="lblCalculated{$P.x}" Width="100%">Total</Label>

                                  </td>

                                 

                            </tr>

                            <tr>

                           <th colspan="3" style="width : 100px ! important;">Singles</th>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input   class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" type="text" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].SinglesString}" {#/if} name="txtSingles1_{$P.x}" id="txtSingles1{$P.x}" maxlength="6" size="4"  />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].SinglesString}" {#/if} name="txtSingles2_{$P.x}" id="txtSingles2{$P.x}" maxlength="6" size="4" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].SinglesString}" {#/if} name="txtSingles3_{$P.x}" id="txtSingles3{$P.x}" maxlength="6" size="4" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].SinglesString}" {#/if} name="txtSingles4_{$P.x}" id="txtSingles4{$P.x}" maxlength="6" size="4" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].SinglesString}" {#/if} name="txtSingles5_{$P.x}" id="txtSingles5{$P.x}" maxlength="6" size="4" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].SinglesString}" {#/if} name="txtSingles6_{$P.x}" id="txtSingles6{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].SinglesString}" {#/if} name="txtSingles7_{$P.x}" id="txtSingles7{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].SinglesString}" {#/if} name="txtSingles8_{$P.x}" id="txtSingles8{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].SinglesString}" {#/if} name="txtSingles9_{$P.x}" id="txtSingles9{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].SinglesString}" {#/if} name="txtSingles10_{$P.x}" id="txtSingles10{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].SinglesString}" {#/if} name="txtSingles11_{$P.x}" id="txtSingles11{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                   <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].SinglesString}" {#/if} name="txtSingles12_{$P.x}" id="txtSingles12{$P.x}" maxlength="6" size="4"/>

                                  </td>

                                   <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].SinglesString}" {#/if} name="txtSingles13_{$P.x}" id="txtSingles13{$P.x}"  maxlength="6" size="4"/>

                                         

                                  </td>

                                   <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].SinglesString}" {#/if} name="txtSingles14_{$P.x}" id="txtSingles14{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                   <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SINGLES)? "size-singles numeric-field-without-decimal-places":"size-singles do-not-allow-typing" %>' onchange="calculateTotalSingles( this)" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].SinglesString}" {#/if} name="txtSingles15_{$P.x}" id="txtSingles15{$P.x}"  maxlength="6" size="4"/>

                                  </td>

                                  <td colspan="3" style="width : 40px ! important;" >

                                        <input class="singles-total do-not-allow-typing" type="text" ID="lblSinglesTotal{$P.x}" name="lblSinglesTotal{$P.x}" Width="100%" />

                                  </td>

                                 

                            </tr>

                            

                            <tr><th colspan="3" style="width : 100px ! important;" >Ratio Pack</th>

                            <td class="edit-drag" style="width : 40px ! important;">

                                         <input  class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].RatioPackString}" {#/if} name="txtRatioPack1_{$P.x}" id="txtRatioPack1{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].RatioPackString}" {#/if} name="txtRatioPack2_{$P.x}" id="txtRatioPack2{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].RatioPackString}" {#/if} name="txtRatioPack3_{$P.x}" id="txtRatioPack3{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].RatioPackString}" {#/if} name="txtRatioPack4_{$P.x}" id="txtRatioPack4{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].RatioPackString}" {#/if} name="txtRatioPack5_{$P.x}" id="txtRatioPack5{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].RatioPackString}" {#/if} name="txtRatioPack6_{$P.x}" id="txtRatioPack6{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].RatioPackString}" {#/if} name="txtRatioPack7_{$P.x}" id="txtRatioPack7{$P.x}" />

                                  </td> 

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].RatioPackString}" {#/if} name="txtRatioPack8_{$P.x}" id="txtRatioPack8{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].RatioPackString}" {#/if} name="txtRatioPack9_{$P.x}" id="txtRatioPack9{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].RatioPackString}" {#/if} name="txtRatioPack10_{$P.x}" id="txtRatioPack10{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].RatioPackString}" {#/if} name="txtRatioPack11_{$P.x}" id="txtRatioPack11{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].RatioPackString}" {#/if} name="txtRatioPack12_{$P.x}" id="txtRatioPack12{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].RatioPackString}" {#/if} name="txtRatioPack13_{$P.x}" id="txtRatioPack13{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].RatioPackString}" {#/if} name="txtRatioPack14_{$P.x}" id="txtRatioPack14{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack do-not-allow-typing":"size-ratiopack do-not-allow-typing" %>' type="text" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].RatioPackString}" {#/if} name="txtRatioPack15_{$P.x}" id="txtRatioPack15{$P.x}" />

                                  </td>

                                  <td colspan="3" style="width : 40px ! important;">

                                        <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO_PACK)? "size-ratiopack size-ratiopack1 do-not-allow-typing":"size-ratiopack size-ratiopack1 do-not-allow-typing" %>' type="text" id="lblRatioPack{$P.x}" name="lblRatioPack{$P.x}" Width="100%"/>

                                  </td>

                                 </tr>

                        

                          <tr><th colspan="3" style="width : 100px ! important;" >Ratio</th>

                            <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>'  onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].RatioString}" {#/if} name="txtRatio1_{$P.x}" id="txtRatio1{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].RatioString}" {#/if} name="txtRatio2_{$P.x}" id="txtRatio2{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].RatioString}" {#/if} name="txtRatio3_{$P.x}" id="txtRatio3{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].RatioString}" {#/if} name="txtRatio4_{$P.x}" id="txtRatio4{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].RatioString}" {#/if} name="txtRatio5_{$P.x}" id="txtRatio5{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].RatioString}" {#/if} name="txtRatio6_{$P.x}" id="txtRatio6{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].RatioString}" {#/if} name="txtRatio7_{$P.x}" id="txtRatio7{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].RatioString}" {#/if} name="txtRatio8_{$P.x}" id="txtRatio8{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].RatioString}" {#/if} name="txtRatio9_{$P.x}" id="txtRatio9{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].RatioString}" {#/if} name="txtRatio10_{$P.x}" id="txtRatio10{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].RatioString}" {#/if} name="txtRatio11_{$P.x}" id="txtRatio11{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].RatioString}" {#/if} name="txtRatio12_{$P.x}" id="txtRatio12{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].RatioString}" {#/if} name="txtRatio13_{$P.x}" id="txtRatio13{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].RatioString}" {#/if} name="txtRatio14_{$P.x}" id="txtRatio14{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "size-ratio numeric-field-without-decimal-places":"size-ratio do-not-allow-typing" %>' onchange="calculateRatio( this)" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].RatioString}" {#/if} name="txtRatio15_{$P.x}" id="txtRatio15{$P.x}" />

                                  </td>

                                  <td colspan="3" style="width : 40px ! important;">

                                     <input type="text" ID="lblRatio{$P.x}" name="lblRatio{$P.x}" Width="100%" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_RATIO)? "":" do-not-allow-typing" %>'/>

                                       <%-- <input type="text" name="txtQuantityCalculated{$P.x}" id="txtQuantityCalculated{$P.x}" />--%>

                                  </td>

                                 </tr>

                            <tr>

                            <th colspan="3" style="width : 100px ! important;" >Quantity</th>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                         <input type="text" class="size-quantity" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 0 } value="{$T.record.OrderSizes[0].QuantityString}" {#/if} name="txtQuantity1_{$P.x}" id="txtQuantity1{$P.x}"  />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 1 } value="{$T.record.OrderSizes[1].QuantityString}" {#/if} name="txtQuantity2_{$P.x}" id="txtQuantity2{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 2 } value="{$T.record.OrderSizes[2].QuantityString}" {#/if} name="txtQuantity3_{$P.x}" id="txtQuantity3{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 3 } value="{$T.record.OrderSizes[3].QuantityString}" {#/if} name="txtQuantity4_{$P.x}" id="txtQuantity4{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 4 } value="{$T.record.OrderSizes[4].QuantityString}" {#/if} name="txtQuantity5_{$P.x}" id="txtQuantity5{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                       <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 5 } value="{$T.record.OrderSizes[5].QuantityString}" {#/if} name="txtQuantity6_{$P.x}" id="txtQuantity6{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 6 } value="{$T.record.OrderSizes[6].QuantityString}" {#/if} name="txtQuantity7_{$P.x}" id="txtQuantity7{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 7 } value="{$T.record.OrderSizes[7].QuantityString}" {#/if} name="txtQuantity8_{$P.x}" id="txtQuantity8{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 8 } value="{$T.record.OrderSizes[8].QuantityString}" {#/if} name="txtQuantity9_{$P.x}" id="txtQuantity9{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 9 } value="{$T.record.OrderSizes[9].QuantityString}" {#/if} name="txtQuantity10_{$P.x}" id="txtQuantity10{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 10 } value="{$T.record.OrderSizes[10].QuantityString}" {#/if} name="txtQuantity11_{$P.x}" id="txtQuantity11{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 11 } value="{$T.record.OrderSizes[11].QuantityString}" {#/if} name="txtQuantity12_{$P.x}" id="txtQuantity12{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 12 } value="{$T.record.OrderSizes[12].QuantityString}" {#/if} name="txtQuantity13_{$P.x}" id="txtQuantity13{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 13 } value="{$T.record.OrderSizes[13].QuantityString}" {#/if} name="txtQuantity14_{$P.x}" id="txtQuantity14{$P.x}" />

                                  </td>

                                  <td class="edit-drag" style="width : 40px ! important;">

                                        <input type="text" class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "size-quantity do-not-allow-typing":"size-quantity do-not-allow-typing" %>' onchange="calculateTotalQuantity( this)" {#if $T.record.OrderSizes.length > 14 } value="{$T.record.OrderSizes[14].QuantityString}" {#/if} name="txtQuantity15_{$P.x}" id="txtQuantity15{$P.x}" />

                                  </td>

                                  <td colspan="3" style="width : 40px ! important;" >

                                                                     <input class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QUANTITY)? "do-not-allow-typing":"do-not-allow-typing" %>' type="text" name="txtQuantityCalculated{$P.x}" id="txtQuantityCalculated{$P.x}"  value="{$T.record.Quantity}" />

                                        <input type="hidden" id="txtOriginalQuantityCalculated{$P.x}"  value="{$T.record.QuantityString}" />

                                  </td>

                                  

                            </tr>

                            

                                  <tr>

                                  <td colspan="4" class="hide_me"></td>

                                  <td colspan="21" style="text-align : right !important" ><a href="#" name="linkClose{$P.x}" id="linkClose{$P.x}" onclick="hideSizeTable( this)">CLOSE</a></td></tr>

                                     

                                          

                    </table>

                </td>

                <td class="to-remove">

                    <%--<a href="javascript:void(0)" id="split{$P.x}" onclick="splitOrder( this)">Split</a>--%>

                    <img title="CLICK TO VIEW ORDER SPLIT POPUP" src="/App_Themes/ikandi/images/split.jpg" id="split{$P.x}" onclick="splitOrder(this)" {#if $T.record.IsPartShipment == false || $T.record.IsPartShipment == 0} class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SPLIT)? "splitClass":"splitClass" %>' {#else} class="splitClass" {#/if} />                

                    <img src="../../App_Themes/ikandi/images/minus.gif" id="btnDeleteRow" class="delete-row"

                                       onclick="deleteRow(this)" />

                  

               </td>

            </tr>

          {#param name=x value=$P.x+1}

                     {#/for}  

    </table>

    </textarea>
    </div>
    <%-- <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;

        width: 5%;" 

        runat="server" />--%>
    <asp:Label ID="lblText" runat="server" Text="This Order is Pending for Agreement"
        Visible="false"></asp:Label>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
        CssClass="do-not-include submit" OnClientClick="return saveDetail(this);" ValidationGroup="orderValidation" />
    <input type="button" id="btnPrint" class="print do-not-include doNotPressAgain da_submit_button"
        value="Print" onclick="javascript:window.print();" />
    <asp:HiddenField runat="server" ID="hdnPath" Value="" />
 
    <asp:Button ID="btnsentProposal" runat="server" OnClick="btnsentProposal_Click" OnClientClick="return validateSendProposal(); "
        ValidationGroup="orderValidation" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SEND_PROPOSAL)? "sentProposal":"hide_me" %>' />
  
    <asp:TextBox CssClass="hide_me" TextMode="MultiLine" Rows="20" Columns="20" runat="server"
        ID="txtEmailcontent"></asp:TextBox>

    <asp:Button ID="btnAgree" runat="server" Visible="false" Text="Agree " OnClientClick="return validateSendProposal();"
        OnClick="btnAgree_Click" CssClass="do-not-include da_submit_button" ValidationGroup="orderValidation" />

    <asp:Button ID="btnDisagree" runat="server" Visible="false" Text="Disagree" OnClick="btnDisagree_Click"
        CssClass="do-not-include da_submit_button" ValidationGroup="orderValidation" />

    <asp:HiddenField ID="hdnAttachments" runat="server" />
    <div class="style_number_box">
        <table width="100%" cellpadding="6px">
            <tr>
                <td>
                    Style Number:
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox runat="server" CssClass="do-not-allow-typing" ID="txtStyleNumber1" Width="100px"></asp:TextBox>
                    -
                    <asp:TextBox runat="server" ID="txtStyleNumber2" Width="60px" MaxLength="2" onKeyPress="return VinCheck(event);"
                        onpaste="return false;">
                    </asp:TextBox>
                    <asp:HiddenField ID="hdnActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <input type="button" class="save da_submit_button" value="Save" onclick="SaveNewStyleNumber();" />
                    <input type="button" class="cancel da_submit_button" value="Cancel" onclick="HideAddStyleNumberBox();" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false" CssClass="do-not-include">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Order have been saved into the system successfully!
        </div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage1" Visible="false" CssClass="do-not-include">
    <div class="form_box" style="display: none;">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Mail has been sent successfully!
        </div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage2" Visible="false" CssClass="do-not-include">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            This order has not been saved because the style Number Is already Exist or Some
            error occurs while saving data.
        </div>
    </div>
</asp:Panel>
