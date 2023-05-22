<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DispatchEntryList.ascx.cs"
    Inherits="iKandi.Web.DispatchEntryList" %>
<style>
    #tblCouriers input[type=text], textarea
    {
        border: 1px solid #cccccc;
        text-transform: Capitalize;
        font-size: 11px;
        height: 15px;
        font-family: Verdana, Sans-Serif , Aparajita;
        color: #666;
    }
    #facebox .content
    {
        overflow: auto !important;
    }
    #facebox .body
    {
        padding: 0px;
    }
    .form_heading
    {
        color: #fff !important;
    }
    .item_list TD input[type=text]
    {
        width: 98%;
        margin: 1px 0px;
    }
    input[type='radio']
    {
        position: relative;
        top: 3px;
    }
    .portlet_content, .middle_portlet_content
    {
        padding: 2px 4px;
    }
    .submit
    {
        font-size: 12px;
        margin-left: 4px;
    }
    .submit:hover
    {
        font-size: 12px;
        margin-left: 4px;
    }
    .close
    {
        margin-right: 5px;
    }
    .item_list TD input[type=text]
    {
        width: 93%;
        margin: 1px 0px;
    }
</style>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(function () {

        var currentDate = new Date();
        //$("#courierSentOn").val((currentDate.getMonth()+1) + '/' + currentDate.getDate() + '/' + currentDate.getFullYear());
        $("#courierSentOn", "#main_content").val(ParseDateToDateWithDay(currentDate));
        $("input.search-style-number", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestCourierStyleNumber", { dataType: "xml", datakey: "string", max: 100 });

        loadGrid();

        $("#refresh", "#main_content").click(function () {
            loadGrid();
        });

        $("#go", "#main_content").click(function () {

            loadGrid();
        });

        $("#pendingCourierStyle", "#main_content").click(function () {

            ShowPendingStylePopUp();
        });

    });

    function ShowPendingStylePopUp() {

        proxy.invoke("GetPendingStylesView", {}, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);

    }
    function pageLoad() {
        setupControls();
    }
    function setupControls() {

        BindControls();
        //  $("input.courier-contact","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierContact", { dataType: "xml", datakey: "string", max: 100 });
        $("input.courier-fabric", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestCourierFabric", { dataType: "xml", datakey: "string", max: 100 });
        //  $("input.courier-buyer","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierBuyer", { dataType: "xml", datakey: "string", max: 100 });
        //   $("input.courier-department","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierBuyerDepartment", { dataType: "xml", datakey: "string", max: 100 });
        //  $("input.courier-stylenumber","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierStyleNumber", { dataType: "xml", datakey: "string", max: 100 });
        //  $("input.courier-item","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierItem", { dataType: "xml", datakey: "string", max: 100 });
        // $("input.courier-purpose","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierPurpose", { dataType: "xml", datakey: "string", max: 100 });
        //   $("input.courier-company","#main_content").autocomplete( "/Webservices/iKandiService.asmx/SuggestCourierCompany", { dataType: "xml", datakey: "string", max: 100 });

        $(".courier-stylenumber", "#main_content").blur(function () {
            var objRow = $(this).parents("tr");

            //Get the Style details from database

            proxy.invoke("GetStyleByNumber", { StyleNumber: $(this).val() },
         function (style) {
             if (style != null) {
                 objRow.find(".courier-buyer").val((style.ClientName == null || style.ClientName == 'null') ? "" : style.ClientName);
                 objRow.find(".courier-department").val((style.ClientDepartment == null || style.ClientDepartment == 'null') ? "" : style.ClientDepartment);
             }
         },
         onPageError, false, false);
        }

    )
    }

    function loadGrid() {
        debugger;
        var radioValue = $("input[name='radioStatus']:checked", "#main_content").val();
        proxy.invoke("GetAllCourier", { courierDate: ParseDateToSimpleDate($("#courierSentOn").val()).toString('M/d/yy'), searchKeyword: $("#searchKeyword").val(), type: radioValue },
    function (result) {
        // attach the template
        $("#grdPanel", "#main_content").setTemplateElement("templateCourier");
        $("#grdPanel", "#main_content").setParam('x', 1);

        // process the template
        $("#grdPanel", "#main_content").processTemplate(result);


        setupControls();

        $("#tblCouriers tr:last", "#main_content").find("input,textarea,select").val("");
    },

    onPageError, false, false);

    }


    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }

    function submitForm() {


        var queryString = $('#courierPanel', '#main_content').serializeNoViewState();

        $.post('DispatchEntry.aspx?callback=savecourier&senton=' + $("#courierSentOn", "#main_content").val(), queryString, function (message) {
            //TODO After save check if there is any error then display 

            jQuery.facebox('Data has been saved successfully!');

            // Refresh the grid with latest data.
            // TODO: Optimize this to update only to new entries
            loadGrid();
        });

        return false;
    }

    function addRow() {
        debugger;
        var rowCount = $("#tblCouriers tr", "#main_content").length - 1; // -1 to avoid the table header row

        var lastRow = $("#tblCouriers tr:last", "#main_content");

        var row = $("#tblCouriers tr:last", "#main_content").clone(true).insertAfter($("#tblCouriers tr:last", "#main_content"));

        var newLastRow = $("#tblCouriers tr:last", "#main_content");

        newLastRow.find("input,select,textarea").val("").each(function () {

            var name1 = $(this).attr("name").split('_');
            if (name1.length == 1) {
                var name = $(this).attr("name");
                name = name.replace(/[0-9]*/g, '');
                $(this).attr("name", name + (rowCount + 1));
            }
            else {
                var name = name1[0]; //$(this).attr("name");
                name = name + '_'; //name.replace(/[0-9]*/g, '');
                $(this).attr("name", name + (parseInt(name1[1]) + 1));
            }

            var id1 = $(this).attr("id").split('_');
            if (id1.length == 1) {
                var id = $(this).attr("id");
                id = id.replace(/[0-9]*/g, '');
                $(this).attr("id", id + (rowCount + 1));
            }
            else {
                var id = id1[0]; //$(this).attr("name");
                id = id + '_'; //name.replace(/[0-9]*/g, '');
                $(this).attr("id", id + (parseInt(id1[1]) + 1));
            }

        });

        //newLastRow.find("input:first").focus();   

        setupControls();
    }

    function deleteRow(srcElem) {
        var objRow = $(srcElem).parents("tr");
        objRow.hide();

        objRow.find("#courierID" + (objRow.get(0).rowIndex)).val("0"); // -1 for new, 0 for delete and rest +ve to update the record
    }

    function AddCourierEntries() {
        //        alert('AddCourierEntries');
        debugger;
        var styleIDs = '';
        $(".checkboxpending input:checked", "#divPendingTask").each(function (i) {
            if ($(this).is(':checked')) {
                var objRow = $(this).parents("tr");
                var styleID = objRow.find("#hdnStyleID").val();

                if (styleIDs == '')
                    styleIDs = styleID;
                else
                    styleIDs += "," + styleID;
            }
        });

        if (styleIDs.length == 0) return;

        //Get the StyleIDs from database

        proxy.invoke("GetStylesByIDs", { StyleIDs: styleIDs }, function (results) {
            // alert(result + 'a');
            debugger;
            for (var i = 0; i < results.length; i++) {
                var objRow = $("#tblCouriers tr:last", "#main_content");

                if (objRow.find(".courier-id").val() == -1) {
                    addRow();
                    objRow = $("#tblCouriers tr:last", "#main_content");
                }

                objRow.find(".courier-contact").val(results[i].DesignerName);
                objRow.find(".courier-stylenumber").val(results[i].StyleNumber);
                objRow.find(".courier-buyer").val(results[i].Buyer);
                objRow.find(".courier-department").val(results[i].DepartmentName);
                objRow.find(".courier-qty").val(1);
                objRow.find(".courier-fabric").val(results[i].Fabric);
                if (results[i].Fab11 != '')
                    objRow.find(".courier-fabric1").val(results[i].Fab11 + ' ' + results[i].CCGSM11);
                else
                    objRow.find(".courier-fabric1").val("");
                if (results[i].Fab21 != '')
                    objRow.find(".courier-fabric2").val(results[i].Fab21 + ' ' + results[i].CCGSM21);
                else
                    objRow.find(".courier-fabric2").val("");

                if (results[i].Fab31 != '')
                    objRow.find(".courier-fabric3").val(results[i].Fab31 + ' ' + results[i].CCGSM31);
                else
                    objRow.find(".courier-fabric3").val("");
                if (results[i].Fab41 != '')
                    objRow.find(".courier-fabric4").val(results[i].Fab41 + ' ' + results[i].CCGSM41);
                else
                    objRow.find(".courier-fabric4").val("");

                if (results[i].Fab51 != '')
                    objRow.find(".courier-fabric5").val(results[i].Fab51 + ' ' + results[i].CCGSM51);
                else
                    objRow.find(".courier-fabric5").val("");

                if (results[i].Fab61 != '')
                    objRow.find(".courier-fabric6").val(results[i].Fab61 + ' ' + results[i].CCGSM561);
                else
                    objRow.find(".courier-fabric6").val("");

                if (objRow.find(".courier-fabric1").val() != "") {
                    objRow.find(".courier-fabric1").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric1").attr("style", "display:block");

                if (objRow.find(".courier-fabric2").val() != "") {
                    objRow.find(".courier-fabric2").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric2").attr("style", "display:none");

                if (objRow.find(".courier-fabric3").val() != "") {
                    objRow.find(".courier-fabric3").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric3").attr("style", "display:none");

                if (objRow.find(".courier-fabric4").val() != "") {
                    objRow.find(".courier-fabric4").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric4").attr("style", "display:none");

                if (objRow.find(".courier-fabric5").val() != "") {
                    objRow.find(".courier-fabric5").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric5").attr("style", "display:none");

                if (objRow.find(".courier-fabric6").val() != "") {
                    objRow.find(".courier-fabric6").attr("style", "display:block");
                }
                else
                    objRow.find(".courier-fabric6").attr("style", "display:none");



                objRow.find(".courier-purpose").val("1st Sample");
                objRow.find(".courier-from").val(results[i].SamplingMerchandisingManagerID);
                // objRow.find(".courier-purpose").attr("class", "do-not-allow-typing")
                addRow();
            }
        },
          onPageError, false, false);

        jQuery(document).trigger('close.facebox')

        return false;
    }
    function ContactName(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierContact", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

        });
    }
    function StyleNumber(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

        });
    }

    function ClientName(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierBuyer", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

        });
    }

    function Department(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierBuyerDepartment", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

        });
    }


    function Items(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierItem", { dataType: "xml", datakey: "string", max: 100 });

        });
    }

    function courierCompany(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierCompany", { dataType: "xml", datakey: "string", max: 100 });

        });
    }


    function CourierPurpose(obj) {

        $(function () {
            var ss = obj.id;
            if (ss == '')
                return;
            $('#' + ss, '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestCourierPurpose", { dataType: "xml", datakey: "string", max: 100 });

        });
    }

</script>
<script type="text/javascript">

    $(function () {

        //  $(".th").datepicker({ dateFormat: 'M/d/yy' });
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
    });

</script>
<style type="text/css">
    .item_list td
    {
        border-left: solid 1px #dedbdb;
        border-bottom: solid 1px #dedbdb;
    }
    .print-box
    {
        background: #fff;
    }
    .da_fieldset_filters
    {
        border-color: #ece3e3;
    }
    .item_list th
    {
        border-color: #999 !important;
    }
    tr.da_table_tr_bg td
    {
        border-bottom: 0px;
    }
    .item_list td:first-child
    {
        border-left-color: #999 !important;
    }
     .item_list td:last-child
    {
        border-right-color: #999 !important;
    }
     .item_list tr:last-child > td
    {
        border-bottom-color: #999 !important;
    }
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<div class="print-box">
    <h2 style="background: #39589c; margin: 0px; padding: 2px 10px; font-weight: 500;
        color: #fff; text-transform: capitalize;">
        Courier Detail</h2>
    <div class="form_box">
        <div id="courierPanel">
            <fieldset class="da_fieldset_filters" style="margin-left: 5px;">
                <legend style="border-color: #999">Filters </legend>
                <table width="55%" id="filter" border="0" cellspacing="2" cellpadding="3">
                    <tr>
                        <td width="12%">
                            <input type="radio" name="radioStatus" value="1" class="radio_status" />Search
                        </td>
                        <td width="10%">
                            <input type="radio" name="radioStatus" value="2" checked="checked" class="radio_status" />Date
                        </td>
                        <td width="9%">
                            Search:
                        </td>
                        <td width="30%">
                            <input id="searchKeyword" class="do-not-disable search-style-number input_in">
                        </td>
                        <td width="9%" align="right">
                            Date:
                        </td>
                        <td width="20%">
                            <input id="courierSentOn" class="th do-not-disable input_in">
                        </td>
                        <td width="13%" align="right">
                            <input type="button" id="go" value="Search" class="do-not-disable go da_go_button" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div id="result" align="right" style="margin-top: 5px; margin-left: 0px; width: 250px;
                position: relative; left: -22px">
                <span class="da_edit_delete_link"><a href="#" id="refresh">Refresh</a> </span>
                <%--<a href="#" onclick="addRow()">Add </a>--%>&nbsp; <span class="da_edit_delete_link">
                    <a href="#" class="da_edit_delete_link" id="pendingCourierStyle">View Pending Courier
                        Styles</a></span>
            </div>
            <div id="grdPanel">
            </div>
        </div>
    </div>
</div>
<div>
    <input type="button" class="add da_submit_button" value="Add" onclick="addRow();" />
    <input type="button" class="save da_submit_button" value="Save" onclick="submitForm();return false;" />
    <input type="hidden" id="TxtBoxId" />
    <%--   <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />--%>
</div>
<!-- Template content -->
<textarea id="templateCourier" class="hide_me"> 
	 
		<table cellspacing="0" cellpadding="0" border="0" style="border:none;margin-top:5px;"   width="100%" class="item_list" id="tblCouriers">
		
		    <tr class="da_header_heading">
			    <th scope="col" style="width:100px;border-left:0px">ATTN</th><th scope="col" style="width:110px;">Reference No.</th><th scope="col">Buyer</th><th scope="col">Department</th><th scope="col">Item</th><th scope="col" style="width:40px">Qty</th><th scope="col" style="width:350px">Fabric</th><th scope="col">Purpose</th><th scope="col">Courier AWB No.</th><th scope="col">Courier Company</th><th scope="col" style="width:60px">From</th><th style="width: 98px;">Courier Sent Date</th><th style="width: 98px;border-right:0px;">IsSample Sent</th>
		    </tr>
		
			{#foreach $T as record}
            <tr class="da_table_tr_bg">
			<td style="border-left:0px">
			    <input type="hidden" value="{$T.record.CourierID}" class="courier-id" id="courierID{$P.x}" name="courierID{$P.x}" value="-1" />
                <input type="text"  value="{$T.record.ContactName}"  onkeyup="ContactName(this)" onclick="ContactName(this)" onchange="ContactName(this)" name="contactName{$P.x}" id="contactName{$P.x}" {#if $T.record.CourierID > 0 } class="do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-contact " {#/if}/>
            </td><td>
                <input type="text" value="{$T.record.StyleNumber}" onkeyup="StyleNumber(this)" onclick="StyleNumber(this)" onchange="StyleNumber(this)" name="styleNumber{$P.x}" id="styleNumber{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-stylenumber" {#/if}/>
            </td><td>
                <input type="text" value="{$T.record.ClientName}" onkeyup="ClientName(this)" onclick="ClientName(this)" onchange="ClientName(this)" name="clientName{$P.x}" id="clientName{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-buyer " {#/if} />
            </td><td style="width:138px;">
                <input type="text" value="{$T.record.Department}" onkeyup="Department(this)" onclick="Department(this)" onchange="Department(this)" name="clientDepartment{$P.x}" id="clientDepartment{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-department" {#/if} />
            </td><td>
                <input type="text" value="{$T.record.Item}" onkeyup="Items(this)" onclick="ClientName(this)" onchange="ClientName(this)" name="item{$P.x}" id="item{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-item" {#/if} />
            </td><td>
                <input type="text" style="width:84%" value="{$T.record.Quantity}" name="quantity{$P.x}" id="quantity{$P.x}" {#if $T.record.CourierID > 0 } class="do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="numeric_text numeric-field-without-decimal-places courier-qty " {#/if}/>
            </td><td>
              <div>
              <input type="text" value="{$T.record.Fabric}" style="display:none;" name="fabric{$P.x}" id="fabric{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric " {#/if}/>
              </div>
              <div>
              <input type="text"  value="{$T.record.Fab1} {$T.record.CCGSM1}"  {#if $T.record.Fab1=='' } style="display:none" {#/if} name="fabrica{$P.x}" id="fabrica{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric1 " {#/if}/>                      
              </div>
              <%--<div>
              <input type="text" value="{$T.record.CCGSM1}"  readonly="true" {#if $T.record.CCGSM1=='' } style="display:none" {#/if}
               style="font-size:smaller;color:Black;"  name="co1{$P.x}" id="co1{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="CCGSM1" {#/if}/>
              </div>--%>
              <div>
              <input type="text"  value="{$T.record.Fab2} {$T.record.CCGSM2}"  {#if $T.record.Fab2=='' } style="display:none" {#/if} name="fabricb{$P.x}" id="fabricb{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric2 " {#/if}/>
              </div>
              <%--<div>
              <input type="text" value="{$T.record.CCGSM2}"  readonly="true" {#if $T.record.CCGSM2=='' } style="display:none" {#/if} style="font-size:smaller;color:Black;"  name="co2{$P.x}" id="co2{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="CCGSM2" {#/if}/>
              </div>--%>
              <div>
              <input type="text" value="{$T.record.Fab3} {$T.record.CCGSM3}" {#if $T.record.Fab3=='' } style="display:none" {#/if} name="fabricc{$P.x}" id="fabricc{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric3 " {#/if}/>
              </div>
              <%--<div>
              <input type="text" value="{$T.record.CCGSM3}"  readonly="true" {#if $T.record.CCGSM3=='' } style="display:none" {#/if} style="font-size:smaller;color:Black;"  name="co3{$P.x}" id="co3{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="CCGSM3" {#/if}/>
              </div>--%>
              <div>
              <input type="text"  value="{$T.record.Fab4} {$T.record.CCGSM4}" {#if $T.record.Fab4=='' } style="display:none" {#/if} name="fabricd{$P.x}" id="fabricd{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric4 " {#/if}/>
              </div>
               <div>
              <input type="text"  value="{$T.record.Fab5} {$T.record.CCGSM5}" {#if $T.record.Fab5=='' } style="display:none" {#/if} name="fabrice{$P.x}" id="fabrice{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric5 " {#/if}/>
              </div>
               <div>
              <input type="text"  value="{$T.record.Fab6} {$T.record.CCGSM6}" {#if $T.record.Fab6=='' } style="display:none" {#/if} name="fabricf{$P.x}" id="fabricf{$P.x}" maxlength=1000 {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if}  {#if $T.record.CourierID == '-1' } class="courier-fabric6 " {#/if}/>
              </div>
              <%--<div>
              <input type="text" value="{$T.record.CCGSM4}"  readonly="true" {#if $T.record.CCGSM4=='' } style="display:none" {#/if} style="font-size:smaller;color:Black;"  name="co4{$P.x}" id="co3{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="CCGSM4" {#/if}/>
              </div>--%>
             
            </td><td>
                <input type="text" value="{$T.record.Purpose}" onkeyup="CourierPurpose(this)" onclick="CourierPurpose(this)" onchange="CourierPurpose(this)"  name="purpose{$P.x}" id="purpose{$P.x}" {#if $T.record.CourierID > 0 } class="do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-purpose " {#/if}/>
            </td><td>
                <input type="text" value="{$T.record.CourierNumber}" name="courierNumber{$P.x}" id="courierNumber{$P.x}" {#if $T.record.CourierID > 0 } class="do-not-allow-typing" {#/if}/>
                
                
                
            </td><td>
                <input type="text" value="{$T.record.CourierCompany}" onkeyup="courierCompany(this)" onclick="courierCompany(this)" onchange="courierCompany(this)"  name="courierCompany{$P.x}" id="courierCompany{$P.x}" {#if $T.record.CourierID > 0 } class=" do-not-allow-typing" {#/if} {#if $T.record.CourierID == '-1' } class="courier-company" {#/if}/>
            </td>
          
            
            <td style="width:120px">
                   <select id="sentByUserID{$P.x}" {#if $T.record.CourierID > 0 } class="disable-dropdown" {#/if} {#if $T.record.CourierID == '-1' } class="courier-from " {#/if} name="sentByUserID{$P.x}" >
                      <option value="-1">Select ...</option>
                      <asp:Repeater runat=server ID="ddlUsers"  >
			       	    <ItemTemplate>
			       	        <option value='<%# Eval("UserID")  %>' {#if $T.record.SentByUserID == '<%# Eval("UserID")  %>' } selected {#/if} ><%# Eval("FullName") %></option>
			       	    </ItemTemplate> 
			       	  </asp:Repeater>
			       </select>                
            </td>
            <td>
                <input type="text" {#if $T.record.CourierSentOnString == 'NULL' } value = ''{#/if} {#if $T.record.CourierSentOnString != 'NULL' }  value="{$T.record.CourierSentOnString}" {#/if}   id="Text1"  class=" do-not-allow-typing" />
            </td>
            <td>
           
               <input type="checkbox"   value="{$T.record.SampleSent}" name="SampleSent{$P.x}" {#if $T.record.SampleSent == 'True' || $T.record.SampleSent == '1'} checked {#/if}/>
            </td>
		</tr>
              {#param name=x value=$P.x+1}
			{#/for}
		</table>
	</textarea>
