<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostingForm.ascx.cs"
    Inherits="iKandi.Web.CostingForm" %>
<%@ Register Src="../Reports/AllOrderOnStyleNew.ascx" TagName="AllOrderOnStyleNew"
    TagPrefix="uc1" %>
<style type="text/css">
    .bluebgcolor
    {
        background-color: #dddfe4;
        color: #575759 !important;
    }
    .lightbluebgcolor
    {
        color: #575759 !important;
        background-color: #dddfe4 !important;
        text-transform: capitalize !important;
        font-weight: normal !important;
        text-align: center !important;
        font-size: 12px !important;
    }
    .lightbg1
    {
        background-color: #f9f9fb;
    }
    .lightbg2
    {
        background-color: #eeeeee;
    }
    .darkbg1
    {
        background-color: #eeeeee;
    }
    .form_small_heading_pink1
    {
        text-align: left;
        background-color: #eeeeee;
    }
    .pras td
    {
        padding: 0px;
    }
    .span penny
    {
        font-size: 15 px;
    }
    
    .costing_form td
    {
        border-left: none;
    }
    .numeric-field-without-decimal-places, .numeric-field-with-surendra-decimal-places, .numeric-field-with-decimal-places, .numeric-field-with-two-decimal-places, .numeric-field-with-three-decimal-places, .do-not-allow-typing, .date-picker, select, .blue_center_text, .blue_center_text input
    {
        text-align: center;
        color: Blue;
    }
    .black_center_text
    {
        text-align: center;
        color: Black;
    }
    .red_center_text, .red_center_text input
    {
        text-align: center;
        color: Red;
        font-size: large;
    }
    .buying-house-id
    {
        display: none;
    }
    .costing-landed-costing-percent, .costing-landed-costing-inches
    {
        text-align: right;
        color: Blue;
        margin-right: 2px;
    }
    .costing-landed-costing-penny
    {
        font-size: 15px;
        text-align: left;
        color: Black;
    }
    .costing-landed-costing-penny_black
    {
        font-size: 15px;
        text-align: left;
        color: Black;
    }
    
    #tblLandedCosting td
    {
        text-align: center;
    }
    #tblFOBPricing td
    {
        text-align: center;
    }
    .changed_value
    {
        color: Red;
        text-align: center;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
    }
    select
    {
        font-size: 10px;
    }
    .costing-accessories-amount
    {
        width: 60px !important;
    }
    .status a
    {
        text-decoration: none;
    }
    .status a:hover
    {
        text-decoration: underline;
    }
    .td_no_padding
    {
        padding: 0px !important;
        margin-bottom: 0px !important;
    }
    .big_bold_heading
    {
        font-size: 13px;
        font-weight: bold;
    }
    .costing_row
    {
        height: 40px;
    }
    
    .style2
    {
        background-color: #F9DDF4;
        text-align: left;
    }
    .style3
    {
    }
    .style4
    {
        background-color: #f4f4f4;
        height: 57px;
    }
    .style5
    {
    }
    .style6
    {
    }
    .style7
    {
    }
    .style8
    {
        background-color: #eeeeee;
        text-align: left;
    }
    .style9
    {
        margin-left: 0px;
        margin-right: 0px;
        margin-top: 5px;
        margin-bottom: 0px;
    }
    .style12
    {
        height: 54px;
        background-color: #f4f4f4;
    }
    .style13
    {
        text-align: left;
        height: 57px;
        background-color: #eeeeee;
    }
    .style14
    {
        height: 57px;
    }
    .style16
    {
        height: 30px;
        background-color: #f4f4f4;
    }
    .style17
    {
        height: 30px;
    }
    .style18
    {
        height: 35px;
        background-color: #eeeeee;
    }
    .style19
    {
        background-color: #eeeeee;
        text-align: left;
        height: 54px;
    }
    .style20
    {
        font-size: 10px;
        display: none;
        width: 70px;
    }
    
    .style21
    {
        font-size: 10px;
        display: none;
    }
    
    
    
    .view-image img
    {
        width: 16px;
        vertical-align: middle;
    }
    .content
    {
        overflow-x: hidden !important;
        overflow-y: hidden !important;
    }
    .content .body
    {
        width: 700px;
        height: 500px;
    }
    .content #image_wrap
    {
        height: 450px !important;
    }
    #image_wrap img
    {
        height: 95% !important;
        width: 100%;
    }
    
    .validation_messagebox
    {
        top: 10%;
    }
    #facebox
    {
        top: 5% !important;
    }
    .item_list th
    {
        color: #98a9ca !important;
    }
    iframe
    {
        background: #ffffff;
    }
    #sb-wrapper
    {
        top: 60px !important;
    }
    .form_box
    {
        text-transform:unset;
     }  
     
    textarea {
        text-transform:unset;
     }
     
</style>
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/ui.draggable.js"></script>
<script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
<script type="text/javascript">
    window.onload = printButton;
    function printButton() {

        try {
            var tt = document.getElementById('<%=txtChargesValue6.ClientID%>');

            if (tt.value.replace(/\s+/g, '') == "")
                document.getElementById('<%=txtChargesValue6.ClientID%>').value = "0";
            // if (rr == "")
            // alert(rr);
            //  document.getElementById('lblprd11').innerHTML = "Splited QTY:";
            //        var ee = $("input.fab_prt1").val();
            //        var s1;
            //        var pos = ee.indexOf(' --- ');
            //        if (pos > 0) {
            //            var tt = new Array();
            //            tt = prt.split(' --- ');          
            //            s1 = tt[1];
            //        }
            //        else {
            //            s1 = ee;
            //            AddNewPrintRow(s1, 'obj');
            //        }
            //        document.getElementById('fab1hdn').value = s1;
            //        document.getElementById('fab2hdn').value = s1;
        } catch (e) { }
    }      
</script>
<script type="text/javascript">
    //debugger;
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;

    var txtChargesValue;

    var txtAccessoriesQuantity;
    var txtAccessoriesRate;
    var txtAccessoriesAmount;

    var txtAmount;
    var txtWaste;
    var txtTotal;
    var txtTotalAvgWstg;
    var txtTotalABC;
    var txtAvarage;

    var finalCost;
    var finalcommision;
    var finalCostCTC;
    var finalTotal;

    var onUnitCtcInFc;
    var percentageProfit;

    var printHtml;
    var printIdsFilledAtLoad = false;

    var fobIKandi;
    var fobMargin;

    var modeDeliveryTime;
    var expectedDate;
    var deliveryDate;

    var zipDetails;

    var grandTotalAF;
    var grandTotalAH;
    var grandTotalSF;
    var grandTotalSH;

    var grandTotalFOB;
    var fobBoutiquePrice;

    var txtFabricType;
    var txtCostingFabric;
    var ddlCostingBuyer;
    var imgFab;
    var currChange;

    var txtFabric1Type;
    var CalculateOverhead;
    var ClineOverhead;
    var ClineMaxOverHead;
    var OverHeadPercent;
    var OverHeadPercentValue;
    var BuyerDDClientID = '<%=ddlBuyer.ClientID%>';
    var hdnuseridClientID = '<%=hdnuserid.ClientID %>';
    var txtWidthClientID1 = '<%=txtWidth1.ClientID%>';
    var txtWasteClientID1 = '<%=txtWaste1.ClientID%>';
    var txtFabricTypeClientID1 = '<%=txtFabricType1.ClientID%>';
    var txtRateClientID1 = '<%=txtRate1.ClientID%>';

    var txtWidthClientID2 = '<%=txtWidth2.ClientID%>';
    var txtWasteClientID2 = '<%=txtWaste2.ClientID%>';
    var txtFabricTypeClientID2 = '<%=txtFabricType2.ClientID%>';
    var txtRateClientID2 = '<%=txtRate2.ClientID%>';

    var txtWidthClientID3 = '<%=txtWidth3.ClientID%>';
    var txtWasteClientID3 = '<%=txtWaste3.ClientID%>';
    var txtFabricTypeClientID3 = '<%=txtFabricType3.ClientID%>';
    var txtRateClientID3 = '<%=txtRate3.ClientID%>';

    var txtWidthClientID4 = '<%=txtWidth4.ClientID%>';
    var txtWasteClientID4 = '<%=txtWaste4.ClientID%>';
    var txtFabricTypeClientID4 = '<%=txtFabricType4.ClientID%>';
    var txtRateClientID4 = '<%=txtRate4.ClientID%>';

    var hiddenStyleIdClientID = '<%=hiddenStyleId.ClientID%>';
    var hidFab1DetailsClientID = '<%=hidFab1Details.ClientID%>';
    var hidFab2DetailsClientID = '<%=hidFab2Details.ClientID%>';
    var hidFab3DetailsClientID = '<%=hidFab3Details.ClientID%>';
    var hidFab4DetailsClientID = '<%=hidFab4Details.ClientID%>';

    var txtFabricClientID1 = '<%=txtFabric1.ClientID%>';
    var txtFabricClientID2 = '<%=txtFabric2.ClientID%>';
    var txtFabricClientID3 = '<%=txtFabric3.ClientID%>';
    var txtFabricClientID4 = '<%=txtFabric4.ClientID%>';

    var BuyerDDClientID = '<%=ddlBuyer.ClientID%>';
    var DeptDDClientID = '<%=ddlDept.ClientID%>';
    var ParentDeptDDClientID = '<%=ddlParentDept.ClientID%>';
    var hdnDeptIdClientID = '<%=hdnDeptId.ClientID%>';
    var hdnParentDeptIdClientID = '<%=hdnParentDeptId.ClientID%>';
    var ddlChargeValue = $('#<%= ddlChargeValue.ClientID %>');
    var hdnConIds = '<%=hdnConIds.ClientID%>';
    var btnSave1 = $('#<%= btnSave.ClientID %>');


    var hiddenRadioModeClientID1 = '<%=hiddenRadioMode1.ClientID %>';
    var lblOriginClientID1 = '<%=lblOrigin1.ClientID %>';
    var hiddenRadioModeClientID2 = '<%=hiddenRadioMode2.ClientID %>';
    var lblOriginClientID2 = '<%=lblOrigin2.ClientID %>';
    var hiddenRadioModeClientID3 = '<%=hiddenRadioMode3.ClientID %>';
    var lblOriginClientID3 = '<%=lblOrigin3.ClientID %>';
    var hiddenRadioModeClientID4 = '<%=hiddenRadioMode4.ClientID %>';
    var lblOriginClientID4 = '<%=lblOrigin4.ClientID %>';
    var PageStyleId = '<%=this.StyleID %>';
    var radiomode1;
    var radiomode2;
    var radiomode3;
    var radiomode4;
    var exqty;
    var ddlCostingDept;
    var ddlCostingParentDept;
    var ddlExpectedQty = '<%=ddlExpectedQty.ClientID %>';




    //function a

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }


    function SAM() {
        //debugger;
        var txtSam = $('#<%= txtChargesValue11.ClientID %>').val();
        var txtOB = $('#<%= txtOB.ClientID %>').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        if (txtSam == '') {
            alert('SAM should not be blank !');
            return false;
        }
        if (txtOB == '') {
            alert('OB should not be blank !');
            return false;
        }
        if (DeptId == -1) {
            alert('Please Select Department !');
            $('select.costing-department').focus();
            return false;
        }

        if ($(".lay_file1").css('display') == 'block') {
            if ($(".lay_file1").val() == "") {
                if ($(".view_lay1").css('display') == 'none') {
                    alert('Please upload a file for fabric 1');
                    return false;
                }
            }
        }
        if ($(".lay_file2").css('display') == 'block') {
            if ($(".lay_file2").val() == "") {
                if ($(".view_lay2").css('display') == 'none') {
                    alert('Please upload a file for fabric 2');
                    return false;
                }
            }
        }
        if ($(".lay_file3").css('display') == 'block') {
            if ($(".lay_file3").val() == "") {
                if ($(".view_lay3").css('display') == 'none') {
                    alert('Please upload a file for fabric 3');
                    return false;
                }
            }
        }
        if ($(".lay_file4").css('display') == 'block') {
            if ($(".lay_file4").val() == "") {
                if ($(".view_lay4").css('display') == 'none') {
                    alert('Please upload a file for fabric 4');
                    return false;
                }
            }
        }

    }




    function SAM_NEW() {
        //debugger;
        var txtSam = $('#<%= txtChargesValue11.ClientID %>').val();
        if (txtSam == '') {
            alert('SAM should not be blank !');
            return false;
        }
        var savevalue = $('#<%= hdnSave.ClientID %>').val();
        if (savevalue == "1")
            return true;
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        //alert(DeptId);

        proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {
            //alert('result');
            // debugger;
            $('#<%= hdnSave.ClientID %>').val('1');
            var commission_New = result[0].CommisionPercent;
            var convertTo_New = result[0].ConvertTo;
            var Finish_New = result[0].Finish;
            var HANGER_LOOPS_New = result[0].HANGER_LOOPS;
            var LBL_TAGS_New = result[0].LBL_TAGS;
            var MarkupOnUnitCTC_New = result[0].MarkupOnUnitCTC;
            var TEST_New = result[0].TEST;
            var OverHead_New = result[0].OverHead;
            var Hangers_New = result[0].Hangers;
            var DesignCommission_New = result[0].DesignCommission;
            var FrtUptoPort_new = result[0].FrieghtUptoPort;
            var Achivement_New = result[0].Achivement;
            var ExpectedQty_New = result[0].ExpectedQty;
            var Costing_waste_New = result[0].Costing_waste;




            var commission = $('#<%= txtComm.ClientID %>').val();
            // var convertTo = $('#<%= ddlConvTo.ClientID %> option:selected').val();
            var convertTo = $('.converto').val();
            var Finish = $('#<%= txtChargesValue4.ClientID %>').val();
            var HANGER_LOOPS = $('#<%= txtAccessoriesRate7.ClientID %>').val();
            var LBL_TAGS = $('#<%= txtChargesValue3.ClientID %>').val();
            var MarkupOnUnitCTC = $('#<%= txtMarkupOnUnitCtc.ClientID %>').val();
            var TEST = $('#<%= txtChargesValue5.ClientID %>').val();
            var OverHead = $('#<%= txtOverHead.ClientID %>').val();
            var Hangers = $('#<%= txtChargesValue6.ClientID %>').val();
            var DesignCommission = $('#<%= txtDesingCommission.ClientID %>').val();
            var FrtUptoPort = $('#<%= txtFrtUptoPort.ClientID %>').val();
            var Achivement = $('#<%= hdnAch.ClientID %>').val();
            //            var ExpectedQty = $('#<%= txtExpectedQuant.ClientID %>').val();
            var ExpectedQty = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
            var CostingWastage = $('#<%= txtFrtUptoFinalDest.ClientID %>').val();

            var ShowMsg_diff = '';

            var LBL_TAGS_diff = '';
            if (parseFloat(LBL_TAGS) != parseFloat(LBL_TAGS_New)) {
                LBL_TAGS_diff = LBL_TAGS_New;
                ShowMsg_diff += 'Lbls,Tgs,Pcg & Ins. = ' + LBL_TAGS_diff + ', '
            }
            var CoffinBox_diff = '';
            if (parseFloat(Finish) != parseFloat(Finish_New)) {
                CoffinBox_diff = Finish_New;
                ShowMsg_diff += 'Coffin Box = ' + CoffinBox_diff + ', '
            }
            var TEST_diff = '';
            if (parseFloat(TEST) != parseFloat(TEST_New)) {
                TEST_diff = TEST_New;
                ShowMsg_diff += 'TEST = ' + TEST_diff + ', '
            }
            var HANGERS_diff = '';
            if (parseFloat(Hangers) != parseFloat(Hangers_New)) {
                HANGERS_diff = Hangers_New;
                ShowMsg_diff += 'Hangers = ' + HANGERS_diff + ', '
            }
            var HANGER_LOOPS_diff = '';
            if (parseFloat(HANGER_LOOPS) != parseFloat(HANGER_LOOPS_New)) {
                HANGER_LOOPS_diff = HANGER_LOOPS_New;
                ShowMsg_diff += 'Hanger Loops = ' + HANGER_LOOPS_diff + ', '
            }
            var OverHead_diff = '';
            if (parseFloat(OverHead) != parseFloat(OverHead_New)) {
                OverHead_diff = OverHead_New;
                ShowMsg_diff += 'OverHead = ' + OverHead_diff + ', '
            }
            var DesignCommission_diff = '';
            if (parseFloat(DesignCommission) != parseFloat(DesignCommission_New)) {
                DesignCommission_diff = DesignCommission_New;
                ShowMsg_diff += 'D.C = ' + DesignCommission_diff + ', '
            }
            var FrtUptoPort_diff = '';
            if (parseFloat(FrtUptoPort) != parseFloat(FrtUptoPort_new)) {
                FrtUptoPort_diff = FrtUptoPort_new;
                ShowMsg_diff += 'FrtUptoPort = ' + FrtUptoPort_diff + ', '
            }
            var Margin_diff = '';
            if (parseFloat(MarkupOnUnitCTC) != parseFloat(MarkupOnUnitCTC_New)) {
                Margin_diff = MarkupOnUnitCTC_New;
                ShowMsg_diff += 'Margin = ' + Margin_diff + ', '
            }

            var commission_diff = '';
            if (parseFloat(commission) != parseFloat(commission_New)) {
                commission_diff = commission_New;
                ShowMsg_diff += 'Commision = ' + commission_diff + ', '
            }
            var Achievement_diff = '';
            if (parseFloat(Achivement) != parseFloat(Achivement_New)) {
                Achievement_diff = Achivement_New;
                ShowMsg_diff += 'Achievement = ' + Achievement_diff + ', '
            }

            var Expected_diff = '';
            if (parseFloat(ExpectedQty) != parseFloat(ExpectedQty_New)) {
                Expected_diff = ExpectedQty_New;
                ShowMsg_diff += 'Expected Quantity = ' + Expected_diff + ', '
            }
            var CostingWastage_diff = '';
            if (parseFloat(CostingWastage) != parseFloat(Costing_waste_New)) {
                CostingWastage_diff = Costing_waste_New;
                ShowMsg_diff += 'Costing Waste = ' + CostingWastage_diff + ', '
            }


            if (ShowMsg_diff != '') {
                //debugger;
                ShowMsg_diff = (ShowMsg_diff.substring(0, ShowMsg_diff.length - 2));

                var r = confirm('Are you sure you want to go with these values?\n\n' + ShowMsg_diff);
                //ShowHideConfirmationBox(true, 'Are you sure want to delete?', 'Produciton Unit', DeleteProductionUnit, " + puid + "); return false;

                if (r == true) {
                    //debugger;                        
                    $('#<%= txtComm.ClientID %>').val(commission_New);
                    $('.converto').val(convertTo_New);
                    $('#<%= hdnConvertTo.ClientID %>').val(convertTo_New);
                    $('#<%= txtChargesValue4.ClientID %>').val(Finish_New);
                    $('#<%= txtAccessoriesRate7.ClientID %>').val(HANGER_LOOPS_New);
                    $('#<%= txtChargesValue3.ClientID %>').val(LBL_TAGS_New);
                    $('#<%= txtMarkupOnUnitCtc.ClientID %>').val(MarkupOnUnitCTC_New);
                    $('#<%= txtChargesValue5.ClientID %>').val(TEST_New);
                    $('#<%= txtOverHead.ClientID %>').val(OverHead_New);
                    $('#<%= txtChargesValue6.ClientID %>').val(Hangers_New);
                    $('#<%= txtDesingCommission.ClientID %>').val(DesignCommission_New);
                    $('#<%= txtFrtUptoPort.ClientID %>').val(FrtUptoPort_new);
                    $('#<%= hdnAch.ClientID %>').val(Achivement_New);
                    $('#<%= txtExpectedQuant.ClientID %>').val(ExpectedQty_New);
                    $('#<%= txtAccessoriesQuantity7.ClientID %>').val(1);
                    $('#<%= hdnClientCostingSave.ClientID %>').val(1);
                    $('#<%= txtFrtUptoFinalDest.ClientID %>').val(Costing_waste_New);
                    CalculateAccessoriesTotal(7);

                    $(".btnABC").click();
                    return true;

                } else {
                    //debugger;
                    $('#<%= hdnClientCostingSave.ClientID %>').val(0);
                    $(".btnABC").click();
                    return true;
                }
            }

            else {
                $('#<%= hdnClientCostingSave.ClientID %>').val(0);
                $(".btnABC").click();
                return true;
            }

        });

        // }, onPageError, false, false);

    }





    function ExportToExcel1() {
        $("#" + '<%=hfexcelval.ClientID%>').html("");
        $("#divhfexcelval").html("");
        //      var Clonedtable1 = getCloneTable("form_table_heading");
        //    Clonedtable1.appendTo("#divhfexcelval");
        var Clonedtable2 = getCloneTable('<%=tblCostingDetails.ClientID%>');
        Clonedtable2.appendTo("#divhfexcelval");
        var html = $("#divhfexcelval").html();
        html = html.replace(/</g, "~!");
        html = html.replace(/>/g, "!~");
        $("#" + '<%=hfexcelval.ClientID%>').val(html);
        $("#divhfexcelval").html("");
        return true;
    }
    function getCloneTable(tblid) {
        var Clonedtable = jQuery("#" + tblid).clone(true);
        Clonedtable.find('input:text').each(function () {
            $(this).replaceWith("<span>" + $(this).val() + "</span>");
        });
        Clonedtable.find('input:checkbox').each(function () {
            $(this).replaceWith("<span>|" + $(this).is(':checked') ? "Yes" : "No" + "</span>");
        });
        Clonedtable.find('input:radio').each(function () {
            $(this).replaceWith("<span>" + $(this).is(':checked') ? "|" + $(this).val() : "" + "</span>");
        });
        Clonedtable.find('input:hidden').each(function () {
            $(this).replaceWith("<span></span>");
        });
        Clonedtable.find("select").each(function () {
            $(this).replaceWith("<span>" + $(this).find('option:selected').text() + "</span>");
        });
        Clonedtable.find('a').each(function () {
            $(this).replaceWith("<span>" + $(this).html() + "</span>");
        });
        Clonedtable.find('textarea').each(function () {
            $(this).replaceWith("<span>" + $(this).val() + "</span>");
        });
        Clonedtable.find("table[id=imgSampleImageUrldemoTable]").replaceWith("<span></span>");
        Clonedtable.find("table[id=costing_print_table]").replaceWith("<span></span>");
        return Clonedtable; //imgSampleImageUrldemo
    }

    function ExportToExcel() {
        try {
            var row, cell, prow, pcell;
            var ptbl = document.createElement('table');
            var ptbo = document.createElement('tbody');
            ptbl.setAttribute("border", "1");
            prow = document.createElement('tr');
            pcell = document.createElement('td');

            var htbl = document.createElement('table');
            htbl.setAttribute("border", "1");
            var htbo = document.createElement('tbody');
            row = document.createElement('tr');
            cell = document.createElement('td');
            cell.appendChild(document.createTextNode("BOUTIQUE COSTING SHEET"));
            cell.setAttribute("align", "center");
            cell.style.fontSize = "20px";
            cell.style.color = "#E91677";
            cell.colSpan = 17;
            row.appendChild(cell);
            htbo.appendChild(row);
            htbl.appendChild(htbo);
            pcell.appendChild(htbl);
            prow.appendChild(pcell);
            ptbo.appendChild(prow);


            prow = document.createElement('tr');
            pcell = document.createElement('td');

            var rtbl = document.createElement('table');
            rtbl.setAttribute("border", "1");

            tbl = document.getElementById('form_table_heading');
            var rtbo = document.createElement('tbody');
            for (var i = 0; i < tbl.rows.length; i++) {
                row = document.createElement('tr');
                row.bgColor = tbl.rows[i].bgColor;
                for (var j = 0; j < tbl.rows[i].cells.length; j++) {
                    var ele = "";
                    if (tbl.rows[i].cells[j].currentStyle != undefined && tbl.rows[i].cells[j].currentStyle.display == 'none')
                        continue;
                    if (tbl.rows[i].cells[j].id == "tdDeleteStyleAndCostingSheet")
                        continue;
                    for (var ii = 0; ii < tbl.rows[i].cells[j].childNodes.length; ii++) {
                        ele += getallChildNodes(tbl.rows[i].cells[j].childNodes[ii]);
                    }
                    cell = document.createElement('td');
                    cell.rowSpan = tbl.rows[i].cells[j].rowSpan;
                    cell.colSpan = tbl.rows[i].cells[j].colSpan;
                    cell.bgColor = tbl.rows[i].cells[j].bgColor;
                    cell.appendChild(document.createTextNode(ele))
                    row.appendChild(cell);
                }
                rtbo.appendChild(row);
            }
            rtbl.appendChild(rtbo);
            pcell.appendChild(rtbl);
            prow.appendChild(pcell);
            ptbo.appendChild(prow);

            prow = document.createElement('tr');
            pcell = document.createElement('td');


            var strtbl = document.createElement('table');
            strtbl.setAttribute("border", "1");
            for (var i = 0; i < strtbl.rows.length; i++) {
                strtbl.deleteRow(i - 1);
            }
            tbl = document.getElementById('<%=tblCostingDetails.ClientID%>');
            var tbo = document.createElement('tbody');
            for (var i = 0; i < tbl.rows.length; i++) {
                row = document.createElement('tr');
                row.bgColor = tbl.rows[i].bgColor;
                if (i > 9) {
                    row.style.height = "30px";
                    row.style.verticalAlign = "middle";
                }
                for (var j = 0; j < tbl.rows[i].cells.length; j++) {
                    var ele = "";
                    if (tbl.rows[i].cells[j].currentStyle != undefined && tbl.rows[i].cells[j].currentStyle.display != undefined && tbl.rows[i].cells[j].currentStyle.display == 'none')
                        continue;
                    cell = document.createElement('td');
                    if (tbl.rows[i].cells[j].id == '<%=imgSampleImageUrldemo.ClientID%>') {
                        var img = document.getElementById('<%=imgSampleImageUrl1.ClientID%>');
                        var element = document.createElement("img");
                        element = cell.appendChild(element);
                        element.setAttribute("src", img.src);
                        element.setAttribute("height", 200);
                        //ele += "<img src='" + img.src + "' height='" + img.height + "' />";
                        cell.appendChild(element);
                        cell.style.textAlign = "center";
                        cell.style.verticalAlign = "middle";
                    }
                    if (tbl.rows[i].cells[j].id == '<%=imgPrintTd.ClientID%>') {
                        $('table.costing-print-table').find('img').each(function () {
                            //var img = document.getElementById('imgPrint');
                            if ($(this).attr("src").indexOf("preview.png") == -1) {
                                var element = document.createElement("img");
                                element = cell.appendChild(element);
                                element.setAttribute("src", $(this).attr("src"));
                                element.setAttribute("height", $(this).height());
                                element.setAttribute("width", $(this).width());
                                //ele += "<img src='" + img.src + "' height='" + img.height + "' />";
                                cell.appendChild(element);
                                cell.style.textAlign = "center";
                                cell.style.verticalAlign = "middle";
                            }
                        });
                    }
                    if (tbl.rows[i].cells[j].className.indexOf("center_text") >= 0)
                        cell.setAttribute("align", "center");
                    if (tbl.rows[i].cells[j].className.indexOf("big_bold") >= 0 && tbl.rows[i].cells[j].className.indexOf("center_text") >= 0)
                        cell.style.fontWeight = "bold";
                    for (var ii = 0; ii < tbl.rows[i].cells[j].childNodes.length; ii++) {
                        ele += getallChildNodes(tbl.rows[i].cells[j].childNodes[ii]);
                    }
                    cell.rowSpan = tbl.rows[i].cells[j].rowSpan;
                    cell.colSpan = tbl.rows[i].cells[j].colSpan;
                    cell.bgColor = tbl.rows[i].cells[j].bgColor;
                    cell.appendChild(document.createTextNode(ele))
                    row.appendChild(cell);
                }
                tbo.appendChild(row);
            }
            strtbl.appendChild(tbo);
            pcell.appendChild(strtbl);
            prow.appendChild(pcell);
            ptbo.appendChild(prow);
            ptbl.appendChild(ptbo);
            var html = ptbl.outerHTML;
            //
            html = html.replace(/</g, "~!");
            html = html.replace(/>/g, "!~");
            $("#" + '<%=hfexcelval.ClientID%>').val(html);
            return true;
        } catch (e) {
            alert(e);
        }
    }

    function getallChildNodes(element) {
        var ele = "";
        if ((element.style != undefined && element.style.display == 'none') || (element.currentStyle != undefined && element.currentStyle.display == 'none'))
            return ele;
        if (element.tagName != undefined && element.id != undefined && element.tagName.toLowerCase() == 'div' && element.id.indexOf("divRadioMode") != -1) {
            $("#" + element.id).find("input.radio_mode").each(function () {
                if ($(this).attr('checked') == true)
                    ele += $(this).attr('title');
            });
            return ele.toUpperCase();
        }
        if ((element.tagName != undefined) && (element.tagName.toLowerCase() == 'div' || element.tagName.toLowerCase() == 'span' || element.tagName.toLowerCase() == 'table' || element.tagName.toLowerCase() == 'tr' || element.tagName.toLowerCase() == 'td' || element.tagName.toLowerCase() == 'nobr')) {
            for (var i = 0; i < element.childNodes.length; i++) {
                if (element.childNodes[i] != undefined) {
                    var str = getallChildNodes(element.childNodes[i]);
                    ele += str;
                }
            }
            return ele.toUpperCase();
        }
        var flag = false;


        switch (element.type) {
            case 'text':
                ele += " " + element.value; flag = true;
                break;
            case 'select-one':
                //                if (element.id == '<%=ddlConvTo.ClientID%>') {
                //                    alert(element.options[element.selectedIndex].text);
                //                    alert($('#<%= ddlConvTo.ClientID %> option:selected').text());
                //                }
                var txt = element.options[element.selectedIndex].text;
                ele += " " + txt.indexOf("...") >= 0 ? "" : txt; flag = true;
                break;
            case 'radio':
                if (element.checked)
                    ele += " " + element.value; flag = true;
                break;
            case 'checkbox':
                if (element.checked)
                    ele += "|Yes ";
                else
                    ele += "|No";
                flag = true;
                break;
            case 'hidden':
                ele += ""; flag = true;
                break;
            case 'image':
                ele += "<img src='" + element.src + "'/>"; flag = true;
                break;
            default:
                if (element.nodeValue != null && element.nodeValue != undefined) {
                    ele += " " + element.nodeValue;
                    flag = true;
                }
                else if (element.innerText != null && element.innerText != undefined) {
                    ele += " " + element.innerText;
                    flag = true;
                }
        }
        if (!flag) {

        }
        return ele.toUpperCase();
    }

    $(function () {


        $('#<%= hdnSave.ClientID %>').val('0');
        $(".OnlyNumeric").keypress(function () {
            var o = $(this).val();
            if (o.length == 2)
                return false;

            var charCode = (window.event.which) ? window.event.which : window.event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        });
        //Yaten : Add proxy for print popup 3 May
        //For print popup 1 
        //      $('input.one', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100, "width": "400",         
        //            extraParams:
        //                 {
        //                     stno: function() {
        //                         return PageStyleId + '##' + document.getElementById('<%=txtFabric1.ClientID %>').value;
        //                     },
        //                     ClientID: function() {
        //                         $(this).flushCache();
        //                         return $("#" + BuyerDDClientID).val();
        //                     }
        //                 }
        //        });
        //        $('input.one', '#main_content').result(function() {

        //            $(this).parents("td").find(".hidden-details").val("PRD");
        //            $('input.fab1a').html("PRD");
        //            var printNo = 0;
        //            var display = $(this).val().split('--- ');
        //            var p = display[0].split('(');
        //            if (display[1] != undefined && display[1] != null) {
        //                printNo = display[1];
        //            }
        //            else {
        //                printNo = p[0];
        //            }
        //            //alert(printNo);
        //            $(this).val(p[0]);
        //            $('input.onehide').val(printNo);
        //            GetFabricQualityData($('input.fabric1').val(), "PRD", $(this).parents('tr').find('.radio_mode').val(), 1);
        //            checkPrint($(this), $('input.oneprev').val(), printNo);
        //            $('input.oneprev').val(printNo);
        //            var objCell = $(this).parents("td");
        //            printNew = printNo.split(' ');
        //            if (isNumeric(printNew[0])) {
        //                $(this).parents("td").find(".hidden-details").val("PRD");
        //                AddRemoveSymbol(objCell, printNo, "PRD: ", false, true);
        //            }
        //            $('.lblone').html("");
        //        });


        ///Print popup 2
        //        $('input.two', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100,
        //            extraParams:
        //                 {
        //                     stno: function() {
        //                         return PageStyleId + '##' + document.getElementById('<%=txtFabric2.ClientID %>').value;
        //                     },
        //                     ClientID: function() {
        //                         $(this).flushCache();
        //                         return $("#" + BuyerDDClientID).val();
        //                     }
        //                 }
        //        });
        //        $('input.two', '#main_content').result(function() {

        //            $(this).parents("td").find(".hidden-details").val("PRD");
        //            var printNo = 0;
        //            var display = $(this).val().split('--- ');
        //            var p = display[0].split('(');
        //            if (display[1] != null) {
        //                printNo = display[1];
        //            }
        //            else {
        //                printNo = p[0];
        //            }
        //            $(this).val(p[0]);
        //            $('input.twohide').val(printNo);
        //            GetFabricQualityData($('input.fabric2').val(), "PRD", $(this).parents('tr').find('.radio_mode').val(), 2);
        //            checkPrint($(this), $('input.twoprev').val(), printNo);

        //            $('input.twoprev').val(printNo);
        //            var objCell = $(this).parents("td");
        //            printNew = printNo.split(' ');
        //            if (isNumeric(printNew[0])) {
        //                $(this).parents("td").find(".hidden-details").val("PRD");
        //                AddRemoveSymbol(objCell, printNo, "PRD: ", false, true);
        //            }
        //            $('.lblTwo').html("");
        //        });

        //        //print popup 3
        //        $('input.three', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100,
        //            extraParams:
        //                 {
        //                     stno: function() {
        //                         return PageStyleId + '##' + document.getElementById('<%=txtFabric3.ClientID %>').value;
        //                     },
        //                     ClientID: function() {
        //                         $(this).flushCache();
        //                         return $("#" + BuyerDDClientID).val();
        //                     }
        //                 }
        //        });
        //        $('input.three', '#main_content').result(function() {

        // $(this).parents("td").find(".hidden-details").val("PRD");//yaten 6dec
        //        $(this).parents("td").find(".hidden-details").val("");
        //            var printNo = 0;
        //            var display = $(this).val().split('--- ');
        //            var p = display[0].split('(');
        //            if (display[1] != null) {
        //                printNo = display[1];
        //            }
        //            else {
        //                printNo = p[0];
        //            }
        //            $(this).val(p[0]);
        //            $('input.threehide').val(printNo);
        //            // GetFabricQualityData($('input.fabric3').val(), "PRD", $(this).parents('tr').find('.radio_mode').val(), 3);//yaten 6dec
        //            GetFabricQualityData($('input.fabric3').val(), "", $(this).parents('tr').find('.radio_mode').val(), 3);
        //            checkPrint($(this), printNo, printNo);
        //            $('input.threeprev').val(printNo);
        //            var objCell = $(this).parents("td");
        //            printNew = printNo.split(' ');
        //            if (isNumeric(printNew[0])) {
        //                // $(this).parents("td").find(".hidden-details").val("PRD");//yaten 6dec
        //                //  AddRemoveSymbol(objCell, printNo, "PRD: ", false, true); //yaten 6dec
        //                $(this).parents("td").find(".hidden-details").val("");
        //                AddRemoveSymbol(objCell, printNo, "", false, true);
        //            }
        //            $('.lblThree').html("");
        //        });








        //print popup 4
        //        $('input.fourth', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100,
        //            extraParams:
        //                 {
        //                     stno: function() {
        //                         return PageStyleId + '##' + document.getElementById('<%=txtFabric4.ClientID %>').value;
        //                     },
        //                     ClientID: function() {
        //                         $(this).flushCache();
        //                         return $("#" + BuyerDDClientID).val();
        //                     }
        //                 }
        //        });
        //        $('input.fourth', '#main_content').result(function() {

        //        // $(this).parents("td").find(".hidden-details").val("PRD");
        //        $(this).parents("td").find(".hidden-details").val("");
        //            var printNo = 0;
        //            var display = $(this).val().split('--- ');
        //            var p = display[0].split('(');
        //            if (display[1] != null) {
        //                printNo = display[1];
        //            }
        //            else {
        //                printNo = p[0];
        //            }
        //            $('input.fourthhide').val(printNo);
        //            $(this).val(p[0]);
        //            //GetFabricQualityData($('input.fabric4').val(), "PRD", $(this).parents('tr').find('.radio_mode').val(), 4);
        //            GetFabricQualityData($('input.fabric4').val(), "", $(this).parents('tr').find('.radio_mode').val(), 4);
        //            checkPrint($(this), printNo, printNo);
        //            $('input.fourthprev').val(printNo);
        //            var objCell = $(this).parents("td");
        //            printNew = printNo.split(' ');
        //            if (isNumeric(printNew[0])) {
        //                // $(this).parents("td").find(".hidden-details").val("PRD");
        //                $(this).parents("td").find(".hidden-details").val("");
        //                // AddRemoveSymbol(objCell, printNo, "PRD: ", false, true);//yaten 6dec
        //                AddRemoveSymbol(objCell, printNo, "", false, true);
        //            }
        //            $('.lblFourth').html("");
        //        });



        var txtMarkupOnUnitCtc = $('#<%= txtMarkupOnUnitCtc.ClientID %>');
        if (txtMarkupOnUnitCtc.val() != '')
            txtMarkupOnUnitCtc.val(parseFloat(txtMarkupOnUnitCtc.val()).toFixed(2));

        var txtComm = $('#<%= txtComm.ClientID %>');
        if (txtComm.val() != '')
            txtComm.val(parseFloat(txtComm.val()).toFixed(2));


        if ($('.costing_form').length == 0) {
            return;
        }

        SetDecimalPlacesForDecimalFields();
        $('input[type=text].numeric-field-with-one-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 1); });
        $('input[type=text].numeric-field-with-two-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 2); });
        $('input[type=text].numeric-field-with-three-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 3); });

        $('span.costing-sheet-height').text($(this).height());

        var classCollection = ['input[type=text].costing-landed-costing-percent', 'input[type=text].costing-landed-costing-penny', 'input[type=text].costing-landed-costing-inches', '.blue_center_text', 'select'];

        for (var i = 0; i < classCollection.length; i++) {
            $(classCollection[i]).parents('td').css('color', 'Black');
        }

        $('.black_center_text').css('color', 'Black');
        $('.red_center_text').css('color', 'Red');

        var changedValueTD = $('span.changed_value').parents('td');

        for (var i = 0; i < changedValueTD.length; i++) {
            for (var j = 0; j < $(changedValueTD[i]).children().length; j++) {
                if ($($(changedValueTD[i]).children()[j]).css('color').toLowerCase() == 'blue') {
                    $(changedValueTD[i]).css('text-align', 'center');
                    break;
                }
            }
        }
        //debugger;
        txtChargesValue = $('input[type=text].costing-charges-value');

        txtAccessoriesQuantity = $('.costing-accessories-quantity');
        txtAccessoriesRate = $('.costing-accessories-rate');
        txtAccessoriesAmount = $('input[type=text].costing-accessories-amount');

        txtAmount = $('input[type=text].costing-amount');
        txtWaste = $('input[type=text].costing-waste');
        txtTotal = $('input[type=text].costing-totalFabric');
        txtAvarage = $('input[type=text].costing-average');
        txtTotalAvgWstg = $('input[type=text].total-Avg-wst'); // $('.total-Avg-wst');

        txtTotalABC = $('input[type=text].costing-total-abc');
        //debugger;
        finalCost = $('.costing-final-cost');
        //debugger;
        finalCostCTC = $('input[type=text].costing-final-cost-ctc');
        finalTotal = $('input[type=text].costing-final-total');
        onUnitCtcInFc = $('input[type=text].costing-on-unit-ctc');
        finalcommision = $('input[type=text].costing-on-unit-commission');
        //        if (onUnitCtcInFc[2].value != '')
        //            onUnitCtcInFc[2].value = parseFloat(onUnitCtcInFc[2].value).toFixed(2);

        //        if (onUnitCtcInFc[3].value != '')
        //            onUnitCtcInFc[3].value = parseFloat(onUnitCtcInFc[3].value).toFixed(2);


        percentageProfit = $('input[type=text].costing-percentage-profit');

        exqty = $('.exqty');
        currChange = $('.currChange');
        printHtml = $('table.costing-print-table tbody tr').html();

        fobIKandi = $('input[type=text].costing-landed-costing-fob-ikandi');
        fobMargin = $('input[type=text].costing-landed-costing-fob-margin');

        modeDeliveryTime = $('input[type=text].costing-landed-costing-mode-delivery-time');
        expectedDate = $('input[type=text].costing-landed-costing-expected-date');
        deliveryDate = $('input[type=text].costing-landed-costing-delivery-date');

        zipDetails = $('.costing-accessories-zip');

        grandTotalAF = $('input[type=text].costing-landed-costing-grand-total1');
        grandTotalAH = $('input[type=text].costing-landed-costing-grand-total2');
        grandTotalSF = $('input[type=text].costing-landed-costing-grand-total3');
        grandTotalSH = $('input[type=text].costing-landed-costing-grand-total4');

        grandTotalFOB = $('input[type=text].costing-landed-costing-grand-total-fob');
        fobBoutiquePrice = $('input[type=text].costing-fob-boutique-price');

        txtFabricType = $('input[type=text].fabric-type');
        txtCostingFabric = $('input[type=text].costing-fabric');

        txtFabric1Type = $('input[type=text].fabric1-type');

        ddlCostingBuyer = $('select.costing-buyer');

        ddlCostingParentDept = $('select.costing-Parentdepartment');
        ddlCostingDept = $('select.costing-department');

        imgFab = $('.imgFab');

        radiomode1 = $('.radio_mode1');
        radiomode2 = $('.radio_mode2');
        radiomode3 = $('.radio_mode3');
        radiomode4 = $('.radio_mode4');

        if (txtCostingFabric.length > 0) {
            GetFabricQualityData($("#" + txtFabricClientID1).val(), $("#" + hidFab1DetailsClientID).val(), $("#" + hiddenRadioModeClientID1).val(), 1, true);
            GetFabricQualityData($("#" + txtFabricClientID2).val(), $("#" + hidFab2DetailsClientID).val(), $("#" + hiddenRadioModeClientID2).val(), 2, true);
            GetFabricQualityData($("#" + txtFabricClientID3).val(), $("#" + hidFab3DetailsClientID).val(), $("#" + hiddenRadioModeClientID3).val(), 3, true);
            GetFabricQualityData($("#" + txtFabricClientID4).val(), $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true);
        }
        //IsMultiple();

        if ($("#" + hiddenRadioModeClientID1).val() == "0") {
            if (radiomode1.length > 0)
                radiomode1[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID1).val() == "1") {
            if (radiomode1.length > 0)
                radiomode1[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID2).val() == "0") {
            if (radiomode2.length > 0)
                radiomode2[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID2).val() == "1") {
            if (radiomode2.length > 0)
                radiomode2[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID3).val() == "0") {
            if (radiomode3.length > 0)
                radiomode3[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID3).val() == "1") {
            if (radiomode3.length > 0)
                radiomode3[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID4).val() == "0") {
            if (radiomode4.length > 0)
                radiomode4[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID4).val() == "1") {
            if (radiomode4.length > 0)
                radiomode4[0].checked = true;
        }

        // var styleNumber = document.getElementById('<%=txtIkandiStyle.ClientID%>').value;


        $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100 });

        $("#" + BuyerDDClientID, '#main_content').change(function () {
            var clientId = $(this).val();
            if (clientId == '' || clientId == undefined || clientId == null) { clientId = '0'; }
            {
                debugger;
                populateParentDepartments($(this).val(), -1, -1, 'Parent');
                populateDepartments($(this).val(), -1, $('#<%= ddlParentDept.ClientID %> option:selected').val(), 'SubParent');
            }

            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

            //            BindExpectedQtyDdl();

            proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {

                if ($("#" + txtFabricClientID1).val() != '') {
                    //document.getElementById('<%=txtWaste1.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID2).val() != '') {
                    //document.getElementById('<%=txtWaste2.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID3).val() != '') {
                    // document.getElementById('<%=txtWaste3.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID4).val() != '') {
                    //document.getElementById('<%=txtWaste4.ClientID %>').value = result[0].CostingWaste;
                }
                //txtWaste.val(result[0].CostingWaste);

            });


        });

        $("#" + DeptDDClientID, '#main_content').change(function () {

            $("#" + hdnDeptIdClientID, "#main_content").val($("#" + DeptDDClientID, '#main_content').val());
            setDeptName();

            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

            //            BindExpectedQtyDdl();
            proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {

                if ($("#" + txtFabricClientID1).val() != '') {
                    //document.getElementById('<%=txtWaste1.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID2).val() != '') {
                    //document.getElementById('<%=txtWaste2.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID3).val() != '') {
                    // document.getElementById('<%=txtWaste3.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID4).val() != '') {
                    //document.getElementById('<%=txtWaste4.ClientID %>').value = result[0].CostingWaste;
                }
                //txtWaste.val(result[0].CostingWaste);

            });

        });

        if ($("#" + BuyerDDClientID, '#main_content').val() != '' && $("#" + BuyerDDClientID, '#main_content').val() != null && $("#" + BuyerDDClientID, '#main_content').val() > 0) {
            debugger;
            populateParentDepartments($("#" + BuyerDDClientID, '#main_content').val(), -1, -1, 'Parent');
            populateDepartments($("#" + BuyerDDClientID, '#main_content').val(), -1, $('#<%= ddlParentDept.ClientID %> option:selected').val(), 'SubParent');
        }
        if ($("#" + hdnParentDeptIdClientID, '#main_content').val() != '' && $("#" + hdnParentDeptIdClientID, '#main_content').val() != null && $("#" + hdnParentDeptIdClientID, '#main_content').val() > 0) {
            $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
        }
        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }

        $("input.fabric1", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/abc", { dataType: "xml", datakey: "string", max: 100, "width": "850px" });
        $("input.fabric1", '#main_content').result(function () {
            //debugger;
            var f = $(this).val().split('[');
            $(this).val(f[0].replace('<FONT COLOR="#595959">', ""));
            //debugger;
            //f[0].replace('<FONT COLOR="#595959">', "")
            GetFabricQualityData(f[0].replace('<FONT COLOR="#595959">', ""), $(".afab").val(), $("#" + hiddenRadioModeClientID1).val(), 1);
            if (f[1] == "Im]")
                $("#" + lblOriginClientID1).html("Imp");
            else if (f[1] == "In]")
                $("#" + lblOriginClientID1).html("Ind");
        });

        $("input.fabric2", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/abc", { dataType: "xml", datakey: "string", max: 100, "width": "850px" });
        $("input.fabric2", '#main_content').result(function () {
            var f = $(this).val().split('[');
            $(this).val(f[0].replace('<FONT COLOR="#595959">', ""));
            GetFabricQualityData(f[0].replace('<FONT COLOR="#595959">', ""), $(".b").val(), $("#" + hiddenRadioModeClientID2).val(), 2);
            if (f[1] == "Im]")
                $("#" + lblOriginClientID2).html("Imp");
            else if (f[1] == "In]")
                $("#" + lblOriginClientID2).html("Ind");

        });

        $("input.fabric3", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/abc", { dataType: "xml", datakey: "string", max: 100, "width": "850px" });
        $("input.fabric3", '#main_content').result(function () {

            var f = $(this).val().split('[');
            $(this).val(f[0].replace('<FONT COLOR="#595959">', ""));
            GetFabricQualityData(f[0].replace('<FONT COLOR="#595959">', ""), $(".c").val(), $("#" + hiddenRadioModeClientID3).val(), 3);
            if (f[1] == "Im]")
                $("#" + lblOriginClientID3).html("Imp");
            else if (f[1] == "In]")
                $("#" + lblOriginClientID3).html("Ind");
        });

        $("input.fabric4", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/abc", { dataType: "xml", datakey: "string", max: 100, "width": "850px" });
        $("input.fabric4", '#main_content').result(function () {
            var f = $(this).val().split('[');
            $(this).val(f[0].replace('<FONT COLOR="#595959">', ""));
            GetFabricQualityData(f[0].replace('<FONT COLOR="#595959">', ""), $(".d").val(), $("#" + hiddenRadioModeClientID4).val(), 4);
            if (f[1] == "Im]")
                $("#" + lblOriginClientID4).html("Imp");
            else if (f[1] == "In]")
                $("#" + lblOriginClientID4).html("Ind");
        });


        $("#" + txtFabricTypeClientID1).change(function () {
            // show3();

            var isPrint = 0;
            var objCell = $(this).parents('td');
            if ($(this).val().indexOf(' ') > -1) {

                var FabDet = $(this).val().split(' ');
                if ((FabDet.length == 2 && FabDet[1].length <= 2))
                    if (FabDet[0] != '' && FabDet[0] != null) {
                        if (isNumeric(FabDet[0])) {
                            objCell.find(".hidden-details").val(" ");
                            isPrint = 1;
                        }
                    }
            }
            else if (isNumeric($(this).val())) {
                objCell.find(".hidden-details").val(" ");
                isPrint = 1;
            }
            else {
                objCell.find(".hidden-details").val("COL");
            }


        });

        $("#" + txtFabricTypeClientID2).change(function () {

            var objCell = $(this).parents('td');
            if ($(this).val().indexOf(' ') > -1) {
                var FabDet = $(this).val().split(' ');
                if ((FabDet.length == 2 && FabDet[1].length <= 2))
                    if (FabDet[0] != '' && FabDet[0] != null) {
                        if (isNumeric(FabDet[0])) {
                            // objCell.find(".hidden-details").val("PRD"); //yeten
                            objCell.find(".hidden-details").val(" ");
                        }
                    }
            }
            else if (isNumeric($(this).val())) {
                //  objCell.find(".hidden-details").val("PRD");
                objCell.find(".hidden-details").val(" ");
            }
            else {
                objCell.find(".hidden-details").val("COL");
            }


        });

        $("#" + txtFabricTypeClientID3).change(function () {
            //   show3();
            var objCell = $(this).parents('td');
            if ($(this).val().indexOf(' ') > -1) {
                var FabDet = $(this).val().split(' ');
                if ((FabDet.length == 2 && FabDet[1].length <= 2))
                    if (FabDet[0] != '' && FabDet[0] != null) {
                        if (isNumeric(FabDet[0])) {
                            // objCell.find(".hidden-details").val("PRD");
                            objCell.find(".hidden-details").val(" ");
                        }
                    }
            }
            else if (isNumeric($(this).val())) {
                //objCell.find(".hidden-details").val("PRD");
                objCell.find(".hidden-details").val(" ");
            }
            else {
                objCell.find(".hidden-details").val("COL");
            }


        });

        $("#" + txtFabricTypeClientID4).change(function () {
            //  show3();
            var objCell = $(this).parents('td');
            if ($(this).val().indexOf(' ') > -1) {
                var FabDet = $(this).val().split(' ');
                if ((FabDet.length == 2 && FabDet[1].length <= 2))
                    if (FabDet[0] != '' && FabDet[0] != null) {
                        if (isNumeric(FabDet[0])) {
                            // objCell.find(".hidden-details").val("PRD"); //yaten 6dec
                            objCell.find(".hidden-details").val(" ");
                        }
                    }
            }
            else if (isNumeric($(this).val())) {
                //objCell.find(".hidden-details").val("PRD");//yaten 6dec
                objCell.find(".hidden-details").val(" ");
            }
            else {
                objCell.find(".hidden-details").val("COL");
            }


        });

        $(".costing-style-go").click(function () {
            var txtStyleNumber = $('input[type=text].costing-style');

            // Added check to resolve issue
            if (txtStyleNumber.val().length < 8) {
                return;
            }

            var sn = $.trim(txtStyleNumber.val());

            if (sn.split(' ').length == 3)
                sn = $.trim(sn.substring(0, sn.lastIndexOf(' ')));

            window.location = "CostingSheet.aspx?sn=" + sn + "&SingleVersion=0";

            return false;
        });

        $('.costing-style-number-view').blur(function () {
            GetCostingData();
        });

        var previousPrintNumber;

        txtFabricType.focus(function () {
            //previousPrintNumber = $(this).val();

            if ($(this).attr("class").indexOf('one') > -1) {
                previousPrintNumber = $('input.oneprev').val();
            }
            else if ($(this).attr("class").indexOf('two') > -1) {
                previousPrintNumber = $('input.twoprev').val();
            }
            else if ($(this).attr("class").indexOf('three') > -1) {
                previousPrintNumber = $('input.threeprev').val();
            }
            else if ($(this).attr("class").indexOf('fourth') > -1) {
                previousPrintNumber = $('input.fourthprev').val();
            }
        });

        txtFabricType.change(function () {
            if ($(this).val() == "") {
                if ($(this).attr("class").indexOf('one') > -1) {
                    $('input.onehide').val("");
                }
                else if ($(this).attr("class").indexOf('two') > -1) {
                    $('input.twohide').val("");
                }
                else if ($(this).attr("class").indexOf('three') > -1) {
                    $('input.threehide').val("");
                }
                else if ($(this).attr("class").indexOf('fourth') > -1) {
                    $('input.fourthhide').val("");
                }
            }
            if ($(this).attr("class").indexOf('one') > -1) {
                $('.lblone').html("");
            }
            else if ($(this).attr("class").indexOf('two') > -1) {

                // $('.lblTwo').html("");
                var ss = "PRD";
            }
            else if ($(this).attr("class").indexOf('three') > -1) {

                $('.lblThree').html("");
            }
            else if ($(this).attr("class").indexOf('fourth') > -1) {

                $('.lblFourth').html("");
            }
        });

        txtFabricType.blur(function () {

            // checkPrintNew($(this), previousPrintNumber);//yaten 5 dec
        });
        txtFabricType.focus(function () {

            // checkPrintNew($(this), previousPrintNumber);//yaten 5 dec
        });

        txtFabricType.keyup(function () {
            if ($(this).attr("class").indexOf('one') > -1) {
                $('.lblone').html("");
            }
            else if ($(this).attr("class").indexOf('two') > -1) {

                //  $('.lblTwo').html("");
                var ss = "PRD";
            }
            else if ($(this).attr("class").indexOf('three') > -1) {

                $('.lblThree').html("");
            }
            else if ($(this).attr("class").indexOf('fourth') > -1) {

                $('.lblFourth').html("");
            }
            //$(this).val("");
            checkPrintNew($(this), previousPrintNumber);
            if ($(this).val() == "") {
                txtFabricType.blur();
                var objCell = $(this).parents("td");
                // AddRemoveSymbol(objCell, '', "PRD: ", false, true);//yaten 6dec
                AddRemoveSymbol(objCell, '', "", false, true);
            }
        });

        //        txtFabricType.keyup(function(e) {
        //            var code = (e.keyCode ? e.keyCode : e.which);
        //            if (code == 8 || code == 46) {
        //                $(this).val("");
        //                txtFabricType.blur();
        //                var objCell = $(this).parents("td");
        //                AddRemoveSymbol(objCell, '', "PRD: ", false, true);
        //                
        //            }
        //        });


        ddlCostingBuyer.change(function () {
            debugger;
            populateParentDepartments($(this).val(), -1, -1, 'Parent');
            SetClientDiscount(0);
            //alert("clientId " + $(this).val());
            proxy.invoke("GetClientDiscountByClientId", { clientId: $(this).val() },
        function (discount) {
            SetClientDiscount(discount);
        });
        });

        ddlCostingParentDept.change(function () {
            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var ParentDeptId = $(this).val();
            populateDepartments(ClientId, -1, ParentDeptId, 'SubParent');
            $(this).val(ParentDeptId);
            $("#" + hdnParentDeptIdClientID, "#main_content").val(ParentDeptId);
        });

        ddlCostingDept.change(function () {
            debugger;
            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var xcd = $("#" + hdnParentDeptIdClientID, "#main_content").val();
            $('#<%= ddlParentDept.ClientID %> option:selected').val(xcd);
            var DeptId = $(this).val();

            proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {

                $('#<%= txtComm.ClientID %>').val(result[0].CommisionPercent);
                $('.converto').val(result[0].ConvertTo)
                debugger;
                $('#<%= hdnConvertTo.ClientID %>').val(result[0].ConvertTo);
                $('#<%= txtChargesValue4.ClientID %>').val(result[0].Finish);
                $('#<%= txtAccessoriesRate7.ClientID %>').val(result[0].HANGER_LOOPS);
                $('#<%= txtChargesValue3.ClientID %>').val(result[0].LBL_TAGS);
                $('#<%= txtMarkupOnUnitCtc.ClientID %>').val(result[0].MarkupOnUnitCTC);
                $('#<%= txtChargesValue5.ClientID %>').val(result[0].TEST);
                $('#<%= txtOverHead.ClientID %>').val(result[0].OverHead);
                $('#<%= txtChargesValue6.ClientID %>').val(result[0].Hangers);
                $('#<%= txtDesingCommission.ClientID %>').val(result[0].DesignCommission);
                $('#<%= txtFrtUptoPort.ClientID %>').val(result[0].FrieghtUptoPort);
                $('#<%= hdnAch.ClientID %>').val(result[0].Achivement);
                $('#<%= txtExpectedQuant.ClientID %>').val(result[0].ExpectedQty);
                $('#<%= txtAccessoriesQuantity7.ClientID %>').val(1);
                $('#<%= txtFrtUptoFinalDest.ClientID %>').val(result[0].CostingWaste);
                $('#<%= txtChargesName4.ClientID %>').val(result[0].ApplicableCoffinBox);

                BindExpectedQtyDdl();
                GetCMTValue();
                CalculateAccessoriesTotal(7);
                GetNewConversion();

            });
        });



        //end

        var zipDetail;
        var zipType;
        var zipRate;

        zipDetails.change(function (e) {
            if (zipDetails[0].value == -1) {
                zipDetails[1].value = -1;
                zipDetails[2].value = -1;
            }
            if (zipDetails[0].value != '-1' && zipDetails[1].value != '-1' && zipDetails[2].value != '-1') {
                zipDetail = zipDetails[0].value;
                zipType = zipDetails[1].value;
                zipRate = zipDetails[2].value;
                //alert("zipDetail " + zipDetail);
                //alert("zipType " + zipType);
                //alert("zipRate " + zipRate);
                proxy.invoke("GetZipRate", { zipDetail: zipDetails[0].value, zipType: zipDetails[1].value, zipSize: zipDetails[2].value },
            function (zipRate) {
                if (zipRate != null && zipRate != '0')
                    zipDetails[3].value = zipRate;
                else
                    zipDetails[3].value = '';

                CalculateAccessoriesTotal(4);
            },
            onPageError, false, false);
            }
            else {
                zipDetails[3].value = '';
                CalculateAccessoriesTotal(4); 4
            }
        });

        var isChargesValue3Changed = false;

        txtChargesValue.keyup(function (e) {
            if (this.id.match('txtChargesValue3'))
                isChargesValue3Changed = true;

            DoKeyUpOperation(this, e, 'charges');
        });

        $("select.costing-charges-labels-tags").change(function () {
            var txtChargesValue3 = $('#<%= txtChargesValue3.ClientID %>');

            if (!isChargesValue3Changed) {
                txtChargesValue3.val($(this).val());
                //alert('b');
                CalculateChargesTotal();
            }

        });

        txtAccessoriesQuantity.keyup(function (e) {
            DoKeyUpOperation(this, e, 'accessories');
        });

        txtAccessoriesRate.keyup(function (e) {
            DoKeyUpOperation(this, e, 'accessories');
        });

        $(".costing-average").keyup(function (e) {
            CalculateCostingAmount(this);
        });

        $(".costing-rate").keyup(function (e) {
            CalculateCostingAmount(this);
        });

        txtAmount.keyup(function (e) {
            DoKeyUpOperation(this, e, 'costing');
        });

        txtWaste.change(function (e) {
            DoKeyUpOperation(this, e, 'costing');
        });

        txtTotalABC.change(function (e) {
            var total = 0;

            for (var i = 0; i < txtTotalABC.length; i++) {
                if (isNaN(txtTotalABC[i].value))
                    txtTotalABC[i].value = 0;

                total = total + +txtTotalABC[i].value;
            }

            var txtTotal = $('#<%= txtTotalABC.ClientID %>');
            txtTotal.val((Math.round(total * 100) / 100).toFixed(2));
            txtTotal.change();
        });

        finalCost.change(function () {

            if (finalCost[1].value == "")
                finalCost[1].value = "0";
            if (finalCost[2].value == "")
                finalCost[2].value = "0";
            var txtInitCtcInInr = $('#<%= txtInitCtcInInr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var txtProfit = $('#<%= txtMarkupOnUnitCtc.ClientID %>');
            var Commission = parseFloat(txtDesingCommission.val());
            var Profit = parseFloat(txtProfit.val());

            //txtInitCtcInInr.val(((1 + finalCost[1].value / 100 + finalCost[2].value / 100) * finalCost[0].value).toFixed(2)); 
            //var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[1].value) + parseFloat(finalCost[2].value)) / (1 - (parseFloat(finalCost[3].value + parseFloat(Commission)) / 100));
            var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[2].value)) / (1 - ((parseFloat(finalCost[3].value / 100) + parseFloat(finalCost[1].value / 100) + (parseFloat(Commission) / 100) + (parseFloat(Profit) / 100))));
            txtInitCtcInInr.val((Math.round(txtInitCtcInInrTxt * 1000) / 1000).toFixed(2));
            //debugger;
            txtInitCtcInInr.change();
        });

        finalcommision.change(function () {
            //debugger;
            if (finalCost[1].value == "")
                finalCost[1].value = "0";
            if (finalCost[2].value == "")
                finalCost[2].value = "0";
            var txtInitCtcInInr = $('#<%= txtInitCtcInInr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var txtProfit = $('#<%= txtMarkupOnUnitCtc.ClientID %>');

            var Commission = parseFloat(txtDesingCommission.val());
            var Profit = parseFloat(txtProfit.val());
            //txtInitCtcInInr.val(((1 + finalCost[1].value / 100 + finalCost[2].value / 100) * finalCost[0].value).toFixed(2));
            var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[2].value)) / (1 - ((parseFloat(finalCost[3].value / 100) + parseFloat(finalCost[1].value / 100) + (parseFloat(Commission) / 100) + (parseFloat(Profit) / 100))));

            txtInitCtcInInr.val((Math.round(txtInitCtcInInrTxt * 1000) / 1000).toFixed(2));
            //debugger;
            txtInitCtcInInr.change();
        });


        finalCostCTC.change(function () {
            //debugger;
            var txtUnitCtcInForeignCurr = $('#<%= txtUnitCtcInForeignCurr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var Commission = parseFloat(txtDesingCommission.val());
            var unitCtcInFC = 0;

            if (finalCostCTC[1].value != 0)
                unitCtcInFC = (finalCostCTC[0].value / finalCostCTC[1].value);
            unitCtcInFC = (Math.round(unitCtcInFC * 1000) / 1000).toFixed(2);
            txtUnitCtcInForeignCurr.val(unitCtcInFC);
            txtUnitCtcInForeignCurr.change();
        });



        exqty.change(function () {

            //debugger;
            var hdnManualValue = $('#<%= hdnManualValue.ClientID %>');
            var ddlChargeValue = $('#<%= ddlChargeValue.ClientID %>');

            var txtChargesValue1 = $('#<%= txtChargesValue1.ClientID %>');
            var txtSam = $('#<%= txtChargesValue11.ClientID %>');
            txtSamInt = txtSam.val();
            var garmentType = exqty[0].innerHTML;
            var expectedqty = exqty[1].value;
            var ddlType = exqty[2].value;

            var pp = ddlChargeValue.val();



            //var pp2 = ddlExpectedQty.val();


            // alert(pp);

            //            if (parseInt(pp) == -1) {
            //                var o1 = hdnManualValue.val();
            //                alert(o1);

            //            }



            //debugger;
            if (parseInt(pp) > 0) {
                //debugger;
                proxy.invoke("GetPriceForGarmentTypeSAM", { PutSAM: parseInt(pp), ExpectedQty: parseInt(pp2) },
                                                            function (result) {
                                                                txtChargesValue1.val(result);
                                                                CalculateChargesTotal();
                                                            },
                                             onPageError, false, false);
            }
            else {
                //debugger;
                if (parseInt(pp) == -1) {
                    //var o1 = hdnManualValue.val();
                    txtChargesValue1.val(hdnManualValue.val());

                }
                else {
                    txtChargesValue1.val("0");
                    CalculateChargesTotal();
                }
            }

            //            var intRegex = /^\d+$/;
            //            if (intRegex.test(pp)) {
            //                if (txtSam.val() != "") {
            //                    proxy.invoke("GetPriceForGarmentTypeSAM", { PutSAM: parseInt(pp), ExpectedQty: expectedqty },
            //                                                            function (result) {
            //                                                                txtChargesValue1.val(result);
            //                                                                CalculateChargesTotal();
            //                                                            },
            //                                             onPageError, false, false);
            //                }
            //                else {
            //                    txtChargesValue1.val("0");
            //                    CalculateChargesTotal();
            //                }
            //            }

        });






        finalTotal.change(function () {
            // Main Block

            var txtTotal = $('#<%= txtTotal.ClientID %>');
            var txtTotalA = $('#<%= txtTotalA.ClientID %>');
            var txtTotalB = $('#<%= txtTotalB.ClientID %>');
            var txtTotalC = $('#<%= txtTotalC.ClientID %>');


            var txtTotalABC = $('#<%= txtTotalABC.ClientID %>');
            var txtFrtUptoFinalDest = $('#<%= txtFrtUptoFinalDest.ClientID %>');
            var txtFrtUptoPort = $('#<%= txtFrtUptoPort.ClientID %>');
            var txtOverHead = $('#<%= txtOverHead.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var txtMarkupOnUnitCtc = $('#<%= txtMarkupOnUnitCtc.ClientID %>');
            var txtComm = $('#<%= txtComm.ClientID %>');
            var txtConvRate = $('#<%= txtConvRate.ClientID %>');
            var txtPercentProfit = $('#<%= txtPercentageProfit.ClientID %>');
            var txtPriceAgreed = $('#<%= txtPriceAgreed.ClientID %>');
            var txtPriceQuoted = $('#<%= txtPriceQuoted.ClientID %>');
            var hdnOverheadZeroValue = '<%=hdnConIds.ClientID%>';
            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
            var ZeroOverhead;
            var c;


            var a = parseFloat(txtTotalA.val());
            var b = parseFloat(txtTotalB.val());
            var c = parseFloat(txtTotalC.val());
            var sum;
            sum = a + b + c;
            proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {
                CalculateOverhead = result[0].MinOverHead;
                ClineOverhead = result[0].OverHead;
                ClineMaxOverHead = result[0].MaxOverHead;
                OverHeadPercentValue = result[0].OHValue_ForPercent;
                OverHeadPercent = result[0].OHPercent;


                if (sum.toFixed(2) == txtTotalABC.val()) {
                    // Main Entry Condition Block
                    //                txtOverHead.val(15);
                    var PriceAgreed = 0;
                    if (txtPriceAgreed.val() == '') {
                        PriceAgreed = txtPriceQuoted.val();
                    }
                    else {
                        PriceAgreed = txtPriceAgreed.val();
                    }

                    debugger;
                    var txtTotalLeft = parseFloat(txtTotalABC.val()) + parseFloat(txtFrtUptoPort.val());
                    var txtTotalRight = 0;
                    if (OverHeadPercent == 1) {
                        txtTotalRight = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtMarkupOnUnitCtc.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100)
                    }
                    else {
                        txtTotalRight = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtMarkupOnUnitCtc.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100)

                    }


                    var txtTotalRightwith0percentOverhead = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtMarkupOnUnitCtc.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(0) / 100) - (parseFloat(10) / 100)
                    var txtTotalTxt = 0;

                    if (OverHeadPercent == 1) {
                        txtTotalTxt = (parseFloat(txtTotalLeft) / parseFloat(txtTotalRight)) / parseFloat(txtConvRate.val());
                    }
                    else {

                        // txtTotalTxt = ((parseFloat(txtTotalLeft) / parseFloat(txtTotalRight)) - parseFloat(OverHeadPercentValue));
                        txtTotalTxt = parseFloat(txtTotalLeft) / parseFloat(txtTotalRight);
                        txtTotalTxt = parseFloat(txtTotalTxt) + parseFloat(OverHeadPercentValue);
                        txtTotalTxt = parseFloat(txtTotalTxt) / parseFloat(txtConvRate.val());
                    }


                    var txtTotalTxtwith0percentOverhead = (parseFloat(txtTotalLeft) / parseFloat(txtTotalRightwith0percentOverhead)) / parseFloat(txtConvRate.val());


                    txtTotal.val((Math.round(txtTotalTxt * 100) / 100).toFixed(2));

                    var objCell = txtTotal.parents("td");

                    //----------------------------------------------------------------Edit By surendra-------------------------------------------------------

                    var txtTotalInLocalwith15percentoverhead = txtTotal.val() * parseFloat(txtConvRate.val());

                    var txtTotalInLocalwithzeropercentoverhead = (Math.round(txtTotalTxtwith0percentOverhead * 100) / 100).toFixed(2) * parseFloat(txtConvRate.val());
                    ZeroOverhead = txtTotalInLocalwithzeropercentoverhead;

                    var Fobdiffrence = txtTotalInLocalwith15percentoverhead - txtTotalInLocalwithzeropercentoverhead


                    //                debugger;
                    //                if (Fobdiffrence < CalculateOverhead) {
                    //                    // Second Block for differenc less than min overhead
                    //                    if (Fobdiffrence < CalculateOverhead) {
                    //                        var i = ClineOverhead;
                    //                        while (Fobdiffrence < CalculateOverhead) {
                    //                            //text += "The number is " + i;
                    //                            txtTotalRightwith0percentOverhead = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtMarkupOnUnitCtc.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(i) / 100) - (parseFloat(10) / 100)
                    //                            txtTotalTxtwith0percentOverhead = (parseFloat(txtTotalLeft) / parseFloat(txtTotalRightwith0percentOverhead)) / parseFloat(txtConvRate.val());
                    //                            txtTotalInLocalwithzeropercentoverhead = (Math.round(txtTotalTxtwith0percentOverhead * 100) / 100).toFixed(2) * parseFloat(txtConvRate.val());
                    //                            Fobdiffrence = txtTotalInLocalwithzeropercentoverhead - ZeroOverhead
                    //                            txtOverHead.val(i);
                    //                            i++;

                    //                        }
                    //                        var newOverhead = i
                    //                        txtTotal.val((Math.round(txtTotalTxtwith0percentOverhead * 100) / 100).toFixed(2));
                    //                        //                alert(txtTotal.val());
                    //                        AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                    //                    }
                    //                    if (PriceAgreed == '') {
                    //                        var percentageprofit = 0;
                    //                        txtPercentProfit.val(percentageprofit.toFixed(2) + '%');

                    //                    }
                    //                    else {
                    //                        var txtTotalLeft = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(newOverhead) / 100) - (parseFloat(10) / 100)
                    //                        var txtTotalRight = ((parseFloat(txtTotalABC.val()) + parseFloat(txtFrtUptoFinalDest.val()) + parseFloat(txtFrtUptoPort.val())) * 0.9) / (parseFloat(PriceAgreed) * parseFloat(txtConvRate.val()));
                    //                        var percentageprofit = (parseFloat(txtTotalLeft) - parseFloat(txtTotalRight)) * 100;
                    //                        txtPercentProfit.val(percentageprofit.toFixed(2) + '%');

                    //                    }

                    //                }

                    // Second Block for differenc less than min overhead End of Blaock
                    //                else if (Fobdiffrence > 90) {
                    //                    // Third Block for differenc > than max overhead 
                    //                   
                    //                    if (Fobdiffrence > ClineMaxOverHead) {
                    //                        var i = ClineOverhead;
                    //                        while (Fobdiffrence > ClineMaxOverHead) {
                    //                            //text += "The number is " + i;
                    //                            txtTotalRightwith0percentOverhead = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtMarkupOnUnitCtc.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(i) / 100) - (parseFloat(10) / 100)
                    //                            txtTotalTxtwith0percentOverhead = (parseFloat(txtTotalLeft) / parseFloat(txtTotalRightwith0percentOverhead)) / parseFloat(txtConvRate.val());
                    //                            txtTotalInLocalwithzeropercentoverhead = (Math.round(txtTotalTxtwith0percentOverhead * 100) / 100).toFixed(2) * parseFloat(txtConvRate.val());
                    //                            Fobdiffrence = txtTotalInLocalwithzeropercentoverhead - ZeroOverhead
                    //                            txtOverHead.val(i);
                    //                            i--;

                    //                        }
                    //                        var newOverhead = i
                    //                        txtTotal.val((Math.round(txtTotalTxtwith0percentOverhead * 100) / 100).toFixed(2));
                    //                        //                alert(txtTotal.val());
                    //                        AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                    //                    }
                    //                    if (PriceAgreed == '') {
                    //                        var percentageprofit = 0;
                    //                        txtPercentProfit.val(percentageprofit.toFixed(2) + '%');

                    //                    }
                    //                    else {
                    //                        var txtTotalLeft = 1 - (parseFloat(txtComm.val()) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(newOverhead) / 100) - (parseFloat(10) / 100)
                    //                        var txtTotalRight = ((parseFloat(txtTotalABC.val()) + parseFloat(txtFrtUptoFinalDest.val()) + parseFloat(txtFrtUptoPort.val())) * 0.9) / (parseFloat(PriceAgreed) * parseFloat(txtConvRate.val()));
                    //                        var percentageprofit = (parseFloat(txtTotalLeft) - parseFloat(txtTotalRight)) * 100;
                    //                        txtPercentProfit.val(percentageprofit.toFixed(2) + '%');

                    //                    }

                    //                }
                    // Third Block for differenc > than max overhead End of Blaock

                    //               // else {
                    // Else Second Block for differenc less than min overhead
                    //----------------------------------------------------------------end---------------------------------------------------------------------

                    AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);

                    //=1-F12-F7-F6-10%-((F5*0.9)/(F13*F9))

                    var Agreed = $('#<%= txtPriceAgreed.ClientID %>');
                    var ActualProfit = $('#<%= txtOnUnitCtcInFc.ClientID %>');
                    var Leftfactor;



                    if (Agreed.val() == '') {

                        //                        var percentageprofit = parseFloat(parseFloat(ActualProfit.val()) * 100 / parseFloat(txtPriceQuoted.val()));
                        var percentageprofit;
                        var Leftfactor;
                        if (OverHeadPercent == 1) {
                            Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(txtPriceQuoted.val()) * parseFloat(txtConvRate.val()))
                        }
                        else {
                            Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(txtPriceQuoted.val()) * parseFloat(txtConvRate.val()) - parseFloat(OverHeadPercentValue))
                        }

                        if (OverHeadPercent == 1) {
                            percentageprofit = -Leftfactor + 1 - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                        }
                        else {
                            percentageprofit = -Leftfactor + 1 - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                            //                            percentageprofit = percentageprofit + parseFloat(OverHeadPercentValue);
                        }

                        percentageprofit = percentageprofit * 100
                        if (txtPriceQuoted.val() == '') {
                            txtPercentProfit.val('');
                        }
                        else {
                            txtPercentProfit.val(percentageprofit.toFixed(2) + '%');
                        }


                    }
                    else {
                        var percentageprofit;
                        var Leftfactor;
                        if (OverHeadPercent == 1) {

                            Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(Agreed.val()) * parseFloat(txtConvRate.val()));
                        }
                        else {
                            Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(Agreed.val()) * parseFloat(txtConvRate.val()) - parseFloat(OverHeadPercentValue));
                        }
                        //                        var percentageprofit = parseFloat(parseFloat(ActualProfit.val()) * 100 / parseFloat(Agreed.val()));
                        if (OverHeadPercent == 1) {
                            percentageprofit = -Leftfactor + 1 - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                        }
                        else {
                            percentageprofit = -Leftfactor + 1 - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                            //                            percentageprofit = percentageprofit + parseFloat(OverHeadPercentValue);
                        }
                        percentageprofit = percentageprofit * 100
                        if (Agreed.val() == '') {
                            txtPercentProfit.val('');
                        }
                        else {
                            txtPercentProfit.val(percentageprofit.toFixed(2) + '%');
                        }
                        //txtPercentProfit.val(percentageprofit.toFixed(2) + '%');


                    }
                    //                }
                    // Else Second Block for differenc less than min overhead end of Block
                }
                // Main Entry Condition Block Ends here

            });




        });

        onUnitCtcInFc.change(function () {

            debugger;
            var unitCTCInFC;
            var txtOnUnitCtcInFc = $('#<%= txtOnUnitCtcInFc.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var txtLastOrderPrice = $('#<%= txtPriceAgreed.ClientID %>');
            var txtPriceQuoted = $('#<%= txtPriceQuoted.ClientID %>');
            var Commission = parseFloat(txtDesingCommission.val());
            var txtOverHead = $('#<%= txtOverHead.ClientID %>');
            var txtFrtUptoFinalDest = $('#<%= txtFrtUptoFinalDest.ClientID %>');
            var txtComm = $('#<%= txtComm.ClientID %>');
            var LastOrderPrice = parseFloat(txtLastOrderPrice.val());
            var PriceQuoted = parseFloat(txtPriceQuoted.val());
            var txtTotalABC = $('#<%= txtTotalABC.ClientID %>');
            var txtFrtUptoPort = $('#<%= txtFrtUptoPort.ClientID %>');
            var txtConvRate = $('#<%= txtConvRate.ClientID %>');
            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

            var txtTotalLeft = parseFloat(txtTotalABC.val()) + parseFloat(txtFrtUptoPort.val());

            proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {
                OverHeadPercentValue = result[0].OHValue_ForPercent;
                OverHeadPercent = result[0].OHPercent;



                var Leftfactor;
                var CalculateProfit;
                if (onUnitCtcInFc[3].value == '') {
                    if (OverHeadPercent == 1) {
                        Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(PriceQuoted) * parseFloat(txtConvRate.val()));
                    }
                    else {
                        Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(PriceQuoted) * parseFloat(txtConvRate.val()) - parseFloat(OverHeadPercentValue));
                    }
                    var percentageprofit;
                    if (OverHeadPercent == 1) {
                        percentageprofit = -Leftfactor + 1 - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                    }
                    else {
                        percentageprofit = -Leftfactor + 1 - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                    }

                    percentageprofit = percentageprofit * 100
                    //unitCTCInFC = (onUnitCtcInFc[2].value - onUnitCtcInFc[0].value);
                    unitCTCInFC = (PriceQuoted * percentageprofit);
                }
                else {
                    if (OverHeadPercent == 1) {
                        Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(LastOrderPrice) * parseFloat(txtConvRate.val()))
                    }
                    else {
                        Leftfactor = parseFloat(txtTotalLeft) / (parseFloat(LastOrderPrice) * parseFloat(txtConvRate.val()) - parseFloat(OverHeadPercentValue))
                    }
                    var percentageprofit;
                    if (OverHeadPercent == 1) {
                        percentageprofit = -Leftfactor + 1 - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                    }
                    else {
                        percentageprofit = -Leftfactor + 1 - (parseFloat(txtFrtUptoFinalDest.val()) / 100) - (parseFloat(txtComm.val()) / 100);
                    }

                    percentageprofit = percentageprofit * 100
                    //unitCTCInFC = (onUnitCtcInFc[3].value - onUnitCtcInFc[0].value);
                    unitCTCInFC = (LastOrderPrice * percentageprofit);
                }
                if (isNaN(PriceQuoted))
                    txtOnUnitCtcInFc.val('');
                else
                    txtOnUnitCtcInFc.val((Math.round(unitCTCInFC) / 100).toFixed(2));
                txtOnUnitCtcInFc.change();

                var objCell = txtOnUnitCtcInFc.parents("td");
                AddRemoveSymbol(objCell, txtOnUnitCtcInFc.val(), symbol, true, true);
            });
        });
        percentageProfit.change(function () {
            //debugger;
            //var txtPercentageProfit = $('#<%= txtPercentageProfit.ClientID %>');
            //            var txtProfit = $('#<%= txtMarkupOnUnitCtc.ClientID %>');

            //            if (txtProfit.val() != '') {
            //               // txtPercentageProfit.val(txtProfit.val());
            //                //                var profit = (percentageProfit[1].value / percentageProfit[0].value) * 100;
            //                //                profit = Math.round(profit).toFixed(2);
            //                //                txtPercentageProfit.val(profit);
            //            }
            //            else {
            //                txtPercentageProfit.val('0');
            //            }
            //            var objCell = txtPercentageProfit.parents("td");
            //            AddRemoveSymbol(objCell, txtPercentageProfit.val(), "%", true, false);
        });

        txtCostingFabric.blur(function () {
            var txtWaste = this.id.replace('txtFabric', 'txtWaste');
            txtWaste = $('#' + txtWaste)

            if ($(this).val() == '') {
                txtWaste.val(0);
            }
            else {

                if (txtWaste.val() == 0 || txtWaste.val() == '')
                    var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
                var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

                proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId }, function (result) {

                    //                    $('#<%= txtComm.ClientID %>').val(result[0].CommisionPercent);
                    txtWaste.val(result[0].CostingWaste);

                });

            }

            txtWaste.keyup();
        });

        $('.costing-price-quoted').change(function (e) {
            var txtFOBBoutique = $('#<%= txtFOBBoutique.ClientID %>');
            txtFOBBoutique.val($(this).val());

            var objCell = (txtFOBBoutique.parents('td'));
            AddRemoveSymbol(objCell, txtFOBBoutique.val(), symbol, true, true);

            var txtTargetFOBPrice = $('#<%= txtTargetFOBPrice.ClientID %>');

            //if(txtTargetFOBPrice.val() == '')
            //{
            txtTargetFOBPrice.val($(this).val());
            txtTargetFOBPrice.keyup();

            objCell = (txtTargetFOBPrice.parents('td'));
            AddRemoveSymbol(objCell, txtTargetFOBPrice.val(), symbol, true, true);
            //}

        });

        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
        var penny = $("input[type=text].costing-landed-costing-penny");

        for (var i = 0; i < penny.length; i++) {
            var objCell = ($(penny[i]).parents('td'));
            //            if(parseInt($(penny[i]).val()) == 8700)
            //            {alert($(penny[i]).val());
            //            
            //            }
            AddRemoveSymbol(objCell, penny[i].value, symbol, true, true);   //yaten 6 dec
        }

        var percent = $("input[type=text].costing-landed-costing-percent");

        for (var i = 0; i < percent.length; i++) {
            var objCell = ($(percent[i]).parents('td'));
            AddRemoveSymbol(objCell, percent[i].value, '%', true);
        }

        var inches = $("input[type=text].costing-landed-costing-inches");

        for (var i = 0; i < inches.length; i++) {
            var objCell = ($(inches[i]).parents('div.inches'));
            AddRemoveSymbol(objCell, inches[i].value, '"', true);
        }

        penny.keyup(function (e) {
            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = $(this).parents("td");
            AddRemoveSymbol(objCell, $(this).val(), symbol, false, true);
        });

        percent.keyup(function (e) {
            var objCell = $(this).parents("td");
            AddRemoveSymbol(objCell, $(this).val(), '%', false);
        });

        inches.keyup(function (e) {
            var objCell = $(this).parents("div.inches");
            AddRemoveSymbol(objCell, $(this).val(), '"', false);
        });

        $('#<%= txtTargetFOBPrice.ClientID %>').keyup(function (e) {
            CalculateFOBBoutiqueValue($(this).val());
        });

        fobMargin.keyup(function (e) {
            CalculateFOBBoutiqueValue($('#<%= txtTargetFOBPrice.ClientID %>').val());
        });

        modeDeliveryTime.keyup(function (e) {
            CalculateDeliveryDate();
        });

        expectedDate.change(function (e) {
            expectedDate.val($(this).val());
            CalculateDeliveryDate();
        });

        deliveryDate.change(function (e) {
            CalculateLeadTime($(this));
        });

        grandTotalAF.keyup(function (e) {
            var txtAFGrandTotal = $('#<%= txtAFGrandTotal.ClientID %>');
            txtAFGrandTotal.val(GetGrandTotal(grandTotalAF));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtAFGrandTotal.parents("td");
            AddRemoveSymbol(objCell, txtAFGrandTotal.val(), symbol, true, true);
        });

        grandTotalAH.keyup(function (e) {
            var txtAHGrandTotal = $('#<%= txtAHGrandTotal.ClientID %>');
            txtAHGrandTotal.val(GetGrandTotal(grandTotalAH));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtAHGrandTotal.parents("td");
            AddRemoveSymbol(objCell, txtAHGrandTotal.val(), symbol, true, true);
        });

        grandTotalSF.keyup(function (e) {
            var txtSFGrandTotal = $('#<%= txtSFGrandTotal.ClientID %>');
            txtSFGrandTotal.val(GetGrandTotal(grandTotalSF));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtSFGrandTotal.parents("td");
            AddRemoveSymbol(objCell, txtSFGrandTotal.val(), symbol, true, true);
        });

        grandTotalSH.keyup(function (e) {
            var txtSHGrandTotal = $('#<%= txtSHGrandTotal.ClientID %>');
            txtSHGrandTotal.val(GetGrandTotal(grandTotalSH));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtSHGrandTotal.parents("td");
            AddRemoveSymbol(objCell, txtSHGrandTotal.val(), symbol, true, true);
        });

        grandTotalFOB.keyup(function (e) {
            var total = 0;

            if (grandTotalFOB.length == 4) {
                total = +grandTotalFOB[0].value + +grandTotalFOB[1].value;
                total = total / (1 - (+grandTotalFOB[2].value / 100));
                total = total / (1 - (+grandTotalFOB[3].value / 100));
            }

            var txtFOBGrandTotal = $('#<%= txtFOBGrandTotal.ClientID %>');
            txtFOBGrandTotal.val((Math.round(total * 1000) / 1000).toFixed(2));
            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtFOBGrandTotal.parents("td");
            AddRemoveSymbol(objCell, txtFOBGrandTotal.val(), symbol, true, true);
        });
        //alert('o');
        CalculateChargesTotal();

        CalculateAccessoriesTotal(0);

        if ($('#<%= ddlAccessoriesPercent1.ClientID %>').val() != -1)
            CalculateAccessoriesTotal(9);

        if ($('#<%= ddlAccessoriesPercent2.ClientID %>').val() != -1)
            CalculateAccessoriesTotal(10);

        CalculateCostingTotal(0);

        txtFabricType.each(function () {
            if ($(this).val() != '')
                $(this).blur();
        });

        CalculateFOBBoutiqueValue($('#<%= txtTargetFOBPrice.ClientID %>').val());
        CalculateDeliveryDate();

        $('#<%= txtTargetFOBPrice.ClientID %>').keyup();
        $('.costing-price-quoted').change();

        if (zipDetails[0].value != '-1' && zipDetails[1].value != '-1' && zipDetails[2].value != '-1') {
            zipDetails.change();
        }

        $('#<%= ddlConvTo.ClientID %>').change(function () {
            //debugger;
            $('input[type=text].costing-landed-costing-penny').parents('td').find('span.penny').text($(this).find('option:selected').text());
            //            var oldValue = $('.costing-target-price').html();
            //            indexof = oldValue.indexOf(" ");
            //            oldValue = $(this).find('option:selected').text() + ' ' + oldValue.substr(indexof);
            //            $('.costing-target-price').html(oldValue);
            //alert($('.costing-target-price').html());
        });

        $('input[type=text].minimum-margin-restricted-18').change(function () {
            if ($(this).val() < 18)
                $(this).val($(this).attr('defaultValue'));
        });

        $('input[type=text].minimum-margin-restricted-22').change(function () {
            if ($(this).val() < 22)
                $(this).val($(this).attr('defaultValue'));
        });

        // Add to make the cell in yellow color   
        $("span.changed_value").each(function () {
            var parentTD = $(this).parents("td");
            //parentTD.css({ 'background-color': 'yellow !important' });
            parentTD.addClass("costing_highlight_yellow");
            //parentTD.find("input,label,div").css({ 'background-color': 'yellow !important' });
            parentTD.find("input,label,div").addClass("costing_highlight_yellow");
        });

        $("input[name='radioMode1']").click(function () {
            // ;
            var yt = $(".afab").val();
            var ss = $("#" + hidFab1DetailsClientID).val();
            if ($("input[name='radioMode1']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID1).val("0");
            }
            else if ($("input[name='radioMode1']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID1).val("1");
            }
            GetFabricQualityData($("#" + txtFabricClientID1).val(), $(".afab").val(), $("#" + hiddenRadioModeClientID1).val(), 1);
        });

        $("input[name='radioMode2']").click(function () {
            if ($("input[name='radioMode2']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID2).val("0");
            }
            else if ($("input[name='radioMode2']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID2).val("1");
            }
            GetFabricQualityData($("#" + txtFabricClientID2).val(), $(".b").val(), $("#" + hiddenRadioModeClientID2).val(), 2);
        });

        $("input[name='radioMode3']").click(function () {
            if ($("input[name='radioMode3']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID3).val("0");
            }
            else if ($("input[name='radioMode3']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID3).val("1");
            }
            GetFabricQualityData($("#" + txtFabricClientID3).val(), $(".c").val(), $("#" + hiddenRadioModeClientID3).val(), 3);
        });

        $("input[name='radioMode4']").click(function () {
            if ($("input[name='radioMode4']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID4).val("0");
            }
            else if ($("input[name='radioMode4']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID4).val("1");
            }
            GetFabricQualityData($("#" + txtFabricClientID4).val(), $(".d").val(), $("#" + hiddenRadioModeClientID4).val(), 4);
        });

        $("#<%=txtOverallComments.ClientID %>").click(function () {

            if ($.trim($("#<%=hdnComments.ClientID %>").html()) != '')
                $("#divCommentsHistory").show();
        });

        $("#<%=txtOverallComments.ClientID %>").blur(function () {

            $("#divCommentsHistory").hide();

        });
        //abhishek-------18 sep-------//
        //BindExpectedQtyDdl();

    });

    function setPreviousNumber(srcElem, previousPrintNumber) {
        if ($(srcElem).attr("class").indexOf('one') > -1) {
            $('input.oneprev').val(previousPrintNumber);
        }
        else if ($(srcElem).attr("class").indexOf('two') > -1) {
            $('input.twoprev').val(previousPrintNumber);
        }
        else if ($(srcElem).attr("class").indexOf('three') > -1) {
            $('input.threeprev').val(previousPrintNumber);
        }
        else if ($(srcElem).attr("class").indexOf('fourth') > -1) {
            $('input.fourthprev').val(previousPrintNumber);
        }
    }

    function checkPrintNew(srcElem, previousPrintNumber) {

        if ($(srcElem).val() == "") {
            var isRemove = true;
            txtFabricType.each(function () {
                if ($(this).attr("id") != $(srcElem).attr("id")) {
                    if ($(this).val() == previousPrintNumber && $(this).val() != '') {
                        isRemove = false;
                    }
                }
            });
            if (isRemove)
                RemovePrintRow(previousPrintNumber);
            if ($(srcElem).attr("class").indexOf('one') > -1) {
                $('input.onehide').val("");
            }
            else if ($(srcElem).attr("class").indexOf('two') > -1) {
                $('input.twohide').val("");
            }
            else if ($(srcElem).attr("class").indexOf('three') > -1) {
                $('input.threehide').val("");
            }
            else if ($(srcElem).attr("class").indexOf('fourth') > -1) {
                $('input.fourthhide').val("");
            }
            checkPrint($(srcElem), $(srcElem).val(), $(srcElem).val());
        }
        else {
            if ($(srcElem).attr("class").indexOf('one') > -1) {
                checkPrint($(srcElem), previousPrintNumber, $('input.onehide').val());
            }
            else if ($(srcElem).attr("class").indexOf('two') > -1) {
                checkPrint($(srcElem), previousPrintNumber, $('input.twohide').val());
            }
            else if ($(srcElem).attr("class").indexOf('three') > -1) {
                checkPrint($(srcElem), previousPrintNumber, $('input.threehide').val());
            }
            else if ($(srcElem).attr("class").indexOf('fourth') > -1) {
                checkPrint($(srcElem), previousPrintNumber, $('input.fourthhide').val());
            }
        }
    }

    function ddlConversionFunc() {
        currChange.change(function () {

            var txtConvRate = $('#<%= txtConvRate.ClientID %>');
            var ClientID = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var txtInitCtcInInr = parseInt(currChange[0].value);
            var ddlCurrency = currChange[1];
            var ddlCurr = parseInt(currChange[1].value);
            var priceQuoted = currChange[2];
            var priceAgreed = currChange[3];
            var conversion;
            var txtOnUnitCtcInFc = $('#<%= txtOnUnitCtcInFc.ClientID %>');
            var txtTotal = $('#<%= txtTotal.ClientID %>');
            $('#<%= hdnConvertTo.ClientID %>').val(ddlCurr);


            proxy.invoke("GetCurrencyConversion", { currencyID: ddlCurr },
            function (result) {
                // debugger;
                txtConvRate.val(result);
                txtConvRate.change();
                var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                var objCell = txtOnUnitCtcInFc.parents("td");
                AddRemoveSymbol(objCell, txtOnUnitCtcInFc.val(), symbol, true, true);
                objCell = txtTotal.parents("td");
                AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                if (ddlCurr == 1 && ClientID == 30) {
                    grandTotalAF.keyup(function (e) {
                        var txtAFGrandTotal = $('#<%= txtAFGrandTotal.ClientID %>');
                        txtAFGrandTotal.val(GetGrandTotal(grandTotalAF));

                        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                        var objCell = txtAFGrandTotal.parents("td");
                        AddRemoveSymbol(objCell, txtAFGrandTotal.val(), symbol, true, true);
                    });

                    grandTotalAH.keyup(function (e) {
                        var txtAHGrandTotal = $('#<%= txtAHGrandTotal.ClientID %>');
                        txtAHGrandTotal.val(GetGrandTotal(grandTotalAH));

                        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                        var objCell = txtAHGrandTotal.parents("td");
                        AddRemoveSymbol(objCell, txtAHGrandTotal.val(), symbol, true, true);
                    });

                    grandTotalSF.keyup(function (e) {
                        var txtSFGrandTotal = $('#<%= txtSFGrandTotal.ClientID %>');
                        txtSFGrandTotal.val(GetGrandTotal(grandTotalSF));

                        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                        var objCell = txtSFGrandTotal.parents("td");
                        AddRemoveSymbol(objCell, txtSFGrandTotal.val(), symbol, true, true);
                    });

                    grandTotalSH.keyup(function (e) {
                        var txtSHGrandTotal = $('#<%= txtSHGrandTotal.ClientID %>');
                        txtSHGrandTotal.val(GetGrandTotal(grandTotalSH));

                        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                        var objCell = txtSHGrandTotal.parents("td");
                        AddRemoveSymbol(objCell, txtSHGrandTotal.val(), symbol, true, true);
                    });
                    SetClientDiscountOnChangeCurrency(7.50);
                    $('#<%= txtFOBDiscount.ClientID %>').val(7.50);
                    if (grandTotalFOB.length == 4) {
                        total = +grandTotalFOB[0].value + +grandTotalFOB[1].value;
                        total = total / (1 - (+grandTotalFOB[2].value / 100));
                        total = total / (1 - (7.50 / 100));
                    }

                    var txtFOBGrandTotal = $('#<%= txtFOBGrandTotal.ClientID %>');
                    txtFOBGrandTotal.val((Math.round(total * 1000) / 1000).toFixed(2));
                    var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                    var objCell = txtFOBGrandTotal.parents("td");
                    AddRemoveSymbol(objCell, txtFOBGrandTotal.val(), symbol, true, true);
                }
                else {
                    //debugger;
                    proxy.invoke("GetClientDiscountByClientId", { clientId: ClientID },
                    function (discount) {
                        SetClientDiscountOnChangeCurrency(discount);
                    },
                    onPageError, false, false);
                }
            },
    onPageError, false, false);



            //txtChargesValue1.change();
        });

    }

    function GetNewConversion() {
        //debugger;
        var txtConvRate = $('#<%= txtConvRate.ClientID %>');
        var txtOnUnitCtcInFc = $('#<%= txtOnUnitCtcInFc.ClientID %>');
        var txtTotal = $('#<%= txtTotal.ClientID %>');
        var convertto = $('#<%= hdnConvertTo.ClientID %>').val();

        proxy.invoke("GetCurrencyConversion", { currencyID: convertto },
            function (result) {
                txtConvRate.val(result);
                txtConvRate.change();
                var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                var objCell = txtOnUnitCtcInFc.parents("td");
                AddRemoveSymbol(objCell, txtOnUnitCtcInFc.val(), symbol, true, true);
                objCell = txtTotal.parents("td");
                AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
            },
    onPageError, false, false);
    }


    function checkPrint(srcElement, previousPrintNumber, presentValue) {

        //alert($(srcElement).val());
        //alert($(srcElement).val() + " : " + previousPrintNumber + " : " + presentValue);
        if (presentValue == undefined || presentValue == null || presentValue == 0) {
            presentValue = $(srcElement).val();
        }
        presentValuePrint = presentValue.split(' ');
        var objCell = $(srcElement).parents('td');
        var temp = $(srcElement).val().split('##');
        // alert(temp);
        $(srcElement).val(temp[0]);
        if ($(srcElement).val().indexOf(' ') > -1) {
            var Fab1Det = presentValue.split(' ');
            if ((Fab1Det.length == 1 && isNumeric(Fab1Det[0])) || (Fab1Det.length == 2 && Fab1Det[1].length <= 2))
                if (Fab1Det[0] != '' && Fab1Det[0] != null) {
                    if (isNumeric(Fab1Det[0])) {
                        //AddRemoveSymbol(objCell, presentValue, 'PRD: ', true, true);
                        //  objCell.find(".hidden-details").val("PRD");//yaten 6dec
                        objCell.find(".hidden-details").val("");
                    }
                }
        }
        else if (isNumeric(presentValue)) {
            //AddRemoveSymbol(objCell, presentValue, 'PRD: ', true, true);
            //objCell.find(".hidden-details").val("PRD");//yaten 6dec
            objCell.find(".hidden-details").val("");
        }
        else if (presentValue.indexOf(' ') > -1 && isNumeric(presentValuePrint[0])) {
            // objCell.find(".hidden-details").val("PRD"); yaten 6dec
            objCell.find(".hidden-details").val("");
        }
        //            if ($(this).val() != '' && isNumeric($(this).val())) {
        //                AddRemoveSymbol(objCell, $(this).val(), 'PRD: ', true, true);
        //                objCell.find(".hidden-details").val("PRD");
        //                // GetFabricQualityData($(this).parents('tr').find('.costing-fabric').val(), "PRD", $(this).parents('tr').find('.radio_mode').val(), ($(this).parents('tr').get(0).rowIndex) - 1);
        //            }
        else if (presentValue != '' && !(isNumeric(presentValue))) {
            AddRemoveSymbol(objCell, presentValue, '', true, true);
            objCell.find(".hidden-details").val("COL");
            //  GetFabricQualityData($(this).parents('tr').find('.costing-fabric').val(), "COL", $(this).parents('tr').find('.radio_mode').val(), ($(this).parents('tr').get(0).rowIndex) - 1);
        }

        if (presentValue == '') {

            //AddRemoveSymbol(objCell, '', 'PRD: ', true, true);
        }


        if (previousPrintNumber != undefined && previousPrintNumber != '' && presentValue != previousPrintNumber) {
            var isRemove = true;

            txtFabricType.each(function () {
                if ($(this).attr("id") != $(srcElement).attr("id")) {
                    if ($(this).val() == previousPrintNumber && $(this).val() != '') {
                        isRemove = false;
                    }
                }
                if (presentValue == previousPrintNumber) {
                    isRemove = false;
                    return;
                }
            });
            var val = 0;

            // alert($(srcElement).attr("id"));
            //  if (isRemove)
            if (isRemove)
                RemovePrintRow(previousPrintNumber);

            if ($(srcElement).val() != '') {

                //AddNewPrintRow(presentValue, $(srcElement));// yaten 5dec
            }
        }
        else if ((previousPrintNumber == undefined || previousPrintNumber == '') && isNumeric(presentValuePrint[0])) {

            //   AddNewPrintRow(presentValue, $(srcElement));
            // setPreviousNumber($(srcElement), presentValue);
        }
    }



    function showAllOrdersOnStyle() {

        var StyleNumber = '<%= txtIkandiStyle.Text %>';
        //
        proxy.invoke("GetAllOrdersOnStyle", { StyleNumber: StyleNumber, OrderIDList: '', AllOrders: true },

    function (result) {
        result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
        jQuery.facebox(result);
    },
    onPageError, false, false);
    }

    function showAffectedOrdersOnPriceUpdate_New(styleNumber) {


        alert('Data save successfully !');

    }

    function showAffectedOrdersOnPriceUpdate(styleNumber, orderIDList) {

        proxy.invoke("GetAllOrdersOnStyle", { StyleNumber: styleNumber, OrderIDList: orderIDList, AllOrders: false },
        function (result) {
            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
            jQuery.facebox(result);
        },
        onPageError, false, false);
    }

    function showBIPLOrderPrice(StyleId) {

        proxy.invoke("GetBIPLOrderPriceDetails", { StyleId: StyleId },
        function (result) {
            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
            jQuery.facebox(result);
        },
        onPageError, false, false);
    }

    function NewPrintGet(PrintNumberNow) {


        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: PrintNumberNow },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(PrintNumberNow, 'obj');
                             }
                             if (result.CountConstruction == "N") {
                                 //  RemovePrintRow(s1);
                             }
                         }
                     });



    }
    function IsMultiple(styleId) {
        //debugger;
        var styleId = $('input[type=text].costing-style-id').val();
        proxy.invoke('GetStyleFabricsByStyleId', { styleId: styleId },
                    function (objStyleFabricCollection) {
                        ;
                        for (var k = 0; k < objStyleFabricCollection.length; k++) {
                            //debugger;
                            if (k < txtCostingFabric.length) {
                                $(txtCostingFabric[k]).val(objStyleFabricCollection[k].FabricName);
                                $(txtCostingFabric[k]).blur();
                                if (objStyleFabricCollection[k].IsPrintMultiple == 'Y') {
                                    $(imgFab[k]).attr("style", "display:block");
                                }
                                else $(imgFab[k]).attr("style", "display:none");

                                $(txtFabricType[k]).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                var s2 = objStyleFabricCollection[k].SpecialFabricDetails;

                                var s1;
                                if (k == 0) {
                                    //debugger;
                                    //$(".lay_file1").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        s1 = tt[1];
                                        document.getElementById('fab1hdn').value = s1;
                                        document.getElementById('fab2hdn').value = s1;
                                        var ee = NewPrintGet(s1);
                                        GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);
                                        $("#" + hidFab1DetailsClientID).val("#");
                                        $(".afab").val("#");
                                    }
                                    else {
                                        document.getElementById('fab1hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab2hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        var ww = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails);
                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: pno },
                                           function (result) {
                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd11').innerHTML = "PRD: ";
                                                       GetFabricQualityData($("#" + txtFabricClientID1).val(), "#", $("#" + hiddenRadioModeClientID1).val(), 1);
                                                       $("#" + hidFab1DetailsClientID).val("#");
                                                       $(".afab").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd11').innerHTML = "";
                                                       GetFabricQualityData($("#" + txtFabricClientID1).val(), "COL", $("#" + hiddenRadioModeClientID1).val(), 1);
                                                       $("#" + hidFab1DetailsClientID).val("COL");
                                                       $(".afab").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }

                                //end k==0
                                //                                if (k == 1) {
                                //                                    var pos = s2.indexOf(' --- ');
                                //                                    if (pos > 0) {
                                //                                        var tt = new Array();
                                //                                        tt = s2.split(' --- ');
                                //                                        //  newprt = tt.split('(');
                                //                                        s1 = tt[1];
                                //                                        document.getElementById('fab22hdn').value = s1;
                                //                                        document.getElementById('fab22hdn2').value = s1;

                                //                                        var qq = NewPrintGet(s1);

                                //                                    }
                                //                                    else {

                                //                                        document.getElementById('fab22hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                //                                        document.getElementById('fab22hdn2').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                //                                        //  $(".lbl1PRD").attr("style", "Display:None");
                                //                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails);

                                //                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                //                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: pno },
                                //                                           function(result) {

                                //                                               if (result == null || result == '')
                                //                                                   return;
                                //                                               else {
                                //                                                   if (result.CountConstruction == "Y") {
                                //                                                       document.getElementById('lblprd22').innerHTML = "PRD: ";
                                //                                                   }
                                //                                                   if (result.CountConstruction == "N") {
                                //                                                       document.getElementById('lblprd22').innerHTML = "";
                                //                                                   }
                                //                                               }
                                //                                           });
                                //                                    }

                                //                                }
                                //                                //end k==1
                                if (k == 1) {
                                    //debugger;
                                    //$(".lay_file2").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab22hdn').value = s1;
                                        document.getElementById('fab22hdn2').value = s1;

                                        var qq = NewPrintGet(s1);
                                        GetFabricQualityData($("#" + txtFabricClientID2).val(), "#", $("#" + hiddenRadioModeClientID2).val(), 2);
                                        $("#" + hidFab2DetailsClientID).val("#");
                                        $(".b").val("#");
                                    }
                                    else {

                                        document.getElementById('fab22hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab22hdn2').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails);

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd22').innerHTML = "PRD: ";
                                                       GetFabricQualityData($("#" + txtFabricClientID2).val(), "#", $("#" + hiddenRadioModeClientID2).val(), 2);
                                                       $("#" + hidFab2DetailsClientID).val("#");
                                                       $(".b").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       ;
                                                       document.getElementById('lblprd22').innerHTML = "";
                                                       GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                                       $("#" + hidFab2DetailsClientID).val("COL");
                                                       $(".b").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k==1

                                if (k == 2) {
                                    //debugger;
                                    //$(".lay_file3").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab33hdn').value = s1;
                                        document.getElementById('fab33hdn3').value = s1;
                                        var qq = NewPrintGet(s1);
                                        GetFabricQualityData($("#" + txtFabricClientID3).val(), "#", $("#" + hiddenRadioModeClientID3).val(), 3);
                                        $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                                    }
                                    else {

                                        document.getElementById('fab33hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab33hdn3').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails);

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd33').innerHTML = "PRD: ";
                                                       GetFabricQualityData($("#" + txtFabricClientID3).val(), "#", $("#" + hiddenRadioModeClientID3).val(), 3);
                                                       $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd33').innerHTML = "";
                                                       GetFabricQualityData($("#" + txtFabricClientID3).val(), "COL", $("#" + hiddenRadioModeClientID3).val(), 3);
                                                       $("#" + hidFab3DetailsClientID).val("COL"); $(".c").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k==2



                                if (k == 3) {
                                    //debugger;
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab44hdn').value = s1;
                                        document.getElementById('fab44hdn4').value = s1;

                                        var qq = NewPrintGet(s1);
                                        GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab44hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab44hdn4').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails);

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd44').innerHTML = "PRD: ";
                                                       GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd44').innerHTML = "";
                                                       GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab4DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }

                                //end k=3

                                if (objStyleFabricCollection[k].PrintID != null && objStyleFabricCollection[k].PrintID != '') {

                                    $(txtFabricType[k]).blur();
                                    if ($(txtFabricType[k]).attr("class").indexOf('one') > -1) {
                                        $('input.onehide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('two') > -1) {
                                        $('input.twohide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('three') > -1) {
                                        $('input.threehide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('fourth') > -1) {
                                        $('input.fourthhide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    var objCell = $(txtFabricType[k]).parents("td");
                                    // AddRemoveSymbol(objCell, objStyleFabricCollection[k].PrintNumber, "PRD: ", false, true);//yaten 6dec
                                    AddRemoveSymbol(objCell, objStyleFabricCollection[k].PrintNumber, "", false, true);
                                }
                                else {
                                    $(txtFabricType[k]).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                }




                                var j = k + 1;
                                //  GetFabricQualityData(objStyleFabricCollection[k].FabricName, $(txtFabricType[k]).val(), 1, j, false);
                                //  $(txtFabricType[k]).focus();
                            }
                        }
                    });
    }


    function GetCostingData() {
        //debugger;
        var SingleVersion = 0;
        var txtStyleNumber = $('.costing-style-number-view');
        var objRow = txtStyleNumber.parents("tr");

        // Added check to resolve issue
        if (txtStyleNumber.val().length < 8)
            return;

        if (txtStyleNumber.val() != objRow.find(".costing-style-number").val()) {
            var isGetMultiple;

            var collection = getQueryString();
            if (collection['cid'] == undefined)
                isGetMultiple = 1;
            else
                isGetMultiple = 0;

            var sn = $.trim(txtStyleNumber.val());

            //    sn = sn.substring(0,  sn.lastIndexOf(' '));
            //if(sn.split(' ').length == 3)

            //Get the Costing details from database
            proxy.invoke("GetCostingByStyleNumber", { styleNumber: sn, isGetMultiple: isGetMultiple, SingleVersion: SingleVersion },
        function (objCostingCollection) {
            debugger;
            var collection = getQueryString();

            if (objCostingCollection.length == 0 && (collection['cid'] == undefined || collection['cid'] > 0)) {
                ShowHideValidationBox(true, 'No Costing Sheet exists for you.', 'Costing Sheet');
                return;
            }

            if (objCostingCollection != null && objCostingCollection.length > 0
                && collection['sn'] == undefined && window.location.href.toLowerCase().search('tabcosting') == -1) {
                window.location = 'CostingSheet.aspx?sn=' + sn + "&SingleVersion=0";
                return;
            }

            if (objCostingCollection != null && objCostingCollection.length == 1) {
                var costing = objCostingCollection[0];

                objRow.find("select.costing-buyer").val((costing.ClientID == null || costing.ClientID == 'null') ? "" : costing.ClientID);
                objRow.find("select.costing-Parentdepartment").val((costing.ParentDepartmentID == null || costing.ParentDepartmentID == 'null') ? "" : costing.ParentDepartmentID);
                objRow.find("select.costing-department").val((costing.DepartmentID == null || costing.DepartmentID == 'null') ? "" : costing.DepartmentID);
                if (costing.ClientID != '' && costing.ClientID != null && costing.ClientID > 0) {
                    //populateDepartments(costing.ClientID);
                    populateParentDepartments(costing.ClientID, -1, -1, 'Parent');
                    populateDepartments(costing.ClientID, -1, costing.ParentDepartmentID, 'SubParent');
                }

                if (costing.DepartmentID != '' && costing.DepartmentID != null && costing.DepartmentID > 0) {
                    $("#" + hdnDeptIdClientID, "#main_content").val(costing.DepartmentID);
                    $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
                }
                if (costing.ParentDepartmentID != '' && costing.ParentDepartmentID != null && costing.ParentDepartmentID > 0) {
                    $("#" + hdnParentDeptIdClientID, "#main_content").val(costing.ParentDepartmentID);
                    $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
                }
                objRow.find(".costing-style-number").val((costing.StyleNumber == null || costing.StyleNumber == 'null') ? "" : costing.StyleNumber);
                objRow.find(".costing-style-id").val((costing.StyleID == null || costing.StyleID == 'null') ? "" : costing.StyleID);
                objRow.find(".buying-house-id").val((costing.IsIkandiClient == null || costing.IsIkandiClient == 'null') ? "0" : costing.IsIkandiClient);

                objRow.find(".costing-order-id").val((costing.OrderId == null || costing.OrderId == 'null') ? "" : costing.OrderId);
                objRow.find(".costing-current-status-id").val((costing.CurrentStatusID == null || costing.CurrentStatusID == 'null') ? "" : costing.CurrentStatusID);

                if (costing.OrderId == -1 && costing.CurrentStatusID != 6)
                    $('#tdDeleteStyleAndCostingSheet').show();
                else
                    $('#tdDeleteStyleAndCostingSheet').hide();

                if (costing.SampleImageURL1 != '' && costing.SampleImageURL1 != null) {

                    $('#<%= imgSampleImageUrl1.ClientID %>').attr('src', '/Uploads/Style/' + costing.SampleImageURL1);
                    //$('#<%= imgSampleImageUrl1.ClientID %>').width(250);
                    $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll_Costing(' + costing.StyleID + ',-1,-1)');
                }
                else {
                    $('#<%= imgSampleImageUrl1.ClientID %>').attr('src', '/App_Themes/ikandi/images/preview.png');
                    //$('#<%= imgSampleImageUrl1.ClientID %>').height(150);
                }

                $('#<%= anchorQuantity.ClientID %>').text(costing.AllQuantity);
                //alert("costing.TargetPriceCurrency " + costing.TargetPriceCurrency);


                proxy.invoke('GetCurrencySumbol', { enumCurrencyValue: costing.TargetPriceCurrency },
                function (currencySymbol) {

                    var ee = costing.TargetPriceCurrency;
                    $('.costing-target-price').html(currencySymbol + ' ' + costing.TargetPrice);
                    //alert($('.costing-target-price').html());
                });


                $('.costing-designer').html(costing.DesignerName);

                SetClientDiscount(costing.Discount);

                if (costing.StyleID != null && costing.StyleID != 'null') {
                    //debugger;
                    IsMultiple(costing.StyleID);
                }

                //                if (costing.StyleID != null && costing.StyleID != 'null') {
                //                    //alert("costing.StyleID " + costing.StyleID);GetCurrencySumbol
                //                    proxy.invoke('GetStyleFabricsByStyleId', { styleId: costing.StyleID },
                //                    function(objStyleFabricCollection) {
                //                        for (var k = 0; k < objStyleFabricCollection.length; k++) {
                //                            if (k < txtCostingFabric.length) {
                //                                $(txtCostingFabric[k]).val(objStyleFabricCollection[k].FabricName);
                //                                $(txtCostingFabric[k]).blur();
                //                                if (objStyleFabricCollection[k].IsPrintMultiple == 'Y') {
                //                                    $(imgFab[k]).attr("style", "display:block");
                //                                }
                //                                else $(imgFab[k]).attr("style", "display:none");

                //                                if (objStyleFabricCollection[k].PrintID != null && objStyleFabricCollection[k].PrintID != '') {
                //                                    $(txtFabricType[k]).val(objStyleFabricCollection[k].PrintNumber);
                //                                    $(txtFabricType[k]).blur();
                //                                }
                //                                else {
                //                                    $(txtFabricType[k]).val(objStyleFabricCollection[k].SpecialFabricDetails);
                //                                }




                //                                var j = k + 1;
                //                                GetFabricQualityData(objStyleFabricCollection[k].FabricName, $(txtFabricType[k]).val(), 1, j, false);
                //                            }
                //                        }
                //                    });
                //                }

                //Disable the agreed price textbox if Current Status ID < Sample Received

                if (costing.CurrentStatusID < 3) {
                    $('.costing-price-quoted').keydown(function () { return false; });
                }
                //alert("costing.CurrentStatusID " + costing.CurrentStatusID);
                proxy.invoke('GetStatusModeNameAndColor', { currentStatusId: costing.CurrentStatusID },
                function (statusModeAndColor) {

                    $('#anchorWorkFlowHistory')[0].onclick = function () { showWorkflowHistory2(costing.StyleID, -1, -1); }
                    $('#<%= lblStatus.ClientID %>').text(statusModeAndColor[0]);
                    $('#<%= tdStatus.ClientID %>').css('background-color', statusModeAndColor[1]);
                }, onPageError, false, false);

                $('.counter-complete').text(costing.CounterComplete ? 'Counter Complete' : 'Counter Pending');
                $('.counter-complete').css('background', costing.CounterComplete ? 'Green' : 'Red');

                txtStyleNumber.focus(function () { this.blur(); return false; });
            }
            else {
                var collection = window.parent.getQueryString();
                if (collection['sn'] == undefined) {
                    objRow.find("select.costing-buyer").val('');
                    objRow.find(".buying-house-id").val('0');
                    objRow.find(".costing-style-number").val('');
                    objRow.find(".costing-style-id").val('');
                    objRow.find(".costing-order-id").val('');
                    objRow.find(".costing-current-status-id").val('');
                }

                //txtStyleNumber.val('');
                //ShowHideValidationBox(true, 'Please enter a valid Style Number');
            }
        },
        onPageError, false, false);
        }
    }

    function showStylePhotoWithOutScroll_Costing(styleID, orderID, orderDetailID) {

        proxy.invoke("GetStylePhotosView", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
            // jQuery.ImageFaceBox(result);
            jQuery.facebox(result);
            //debugger;
            //$("#facebox").find(".content").css("max-height", "500px");
            //$("#facebox").find(".content").css("max-width", "700px");
        }, onPageError, false, false);
    }

    function SetClientDiscount(discount) {
        var txtDiscount = $('.costing-landed-costing-discount');
        txtDiscount.val(discount);

        var objCell = txtDiscount.parents("td");
        AddRemoveSymbol(objCell, discount, '%', true);

        txtDiscount.keyup();
    }
    function SetClientDiscountOnChangeCurrency(discount) {
        var txtDiscount = $('.costing-landed-costing-discount');
        var txtDirectDiscount = $('#<%= txtFOBDiscount.ClientID %>');


        txtDiscount.val(discount);
        txtDirectDiscount.val(discount);

        var objCell = txtDiscount.parents("td");
        var objDirectCell = txtDirectDiscount.parents("td");


        AddRemoveSymbol(objCell, discount, '%', true);
        AddRemoveSymbol(objDirectCell, discount, '%', true);

        txtDiscount.keyup();
    }

    function GetGrandTotal(sourceObject) {
        var total = 0;

        if (sourceObject.length == 8) {

            total = +sourceObject[0].value + +sourceObject[1].value;
            total = total * (1 + +sourceObject[2].value / 100);
            total = total + +sourceObject[3].value + +sourceObject[4].value + +sourceObject[5].value;
            total = total / (1 - (+sourceObject[6].value / 100));
            total = +total / (1 - (+sourceObject[7].value / 100));
        }

        return ((Math.round(total * 1000) / 1000).toFixed(2));
    }

    function AddRemoveSymbol(objCell, txtValue, symbol, isPageLoad, addInFront) {
        //debugger;
        if (txtValue == '' || txtValue == null) {
            objCell.find('span.penny').remove();
        }
        else if ((txtValue.length >= 1 || isPageLoad)) {
            objCell.find('span.penny').remove();

            if (objCell.find('.fabric-type').length == 0) {

                if (addInFront)
                    $('<span class="penny">' + symbol + '</span>').insertBefore($(objCell.find('input')[0]));
                else
                    $('<span class="penny">' + symbol + '</span>').insertAfter($(objCell.find('input')[0]));
            }
            else if (objCell.find('.fabric-type').length > 0) {

                if (addInFront)
                    $('<span class="penny">' + symbol + '</span>').insertBefore($(objCell.find('.fabric-type')));
                else
                    $('<span class="penny">' + symbol + '</span>').insertAfter($(objCell.find('input')[0]));
            }
        }
        if (objCell.find('.costing-totalFabric').length > 0) {

            objCell.find('span.penny').remove();
        }
    }

    function CalculateFOBBoutiqueValue(txtValue) {

        fobBoutiquePrice.val(txtValue);

        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        var objCell = fobBoutiquePrice.parents("td");
        AddRemoveSymbol(objCell, fobBoutiquePrice.val(), symbol, true, true);

        if (fobMargin.val() == 1 || isNaN(fobMargin.val()))
            fobIKandi.val(0);
        else
            fobIKandi.val((Math.round(txtValue / (1 - (fobMargin.val() / 100)) * 1000) / 1000).toFixed(2));

        objCell = fobIKandi.parents("td");
        AddRemoveSymbol(objCell, fobIKandi.val(), symbol, true, true);
    }

    function CalculateDeliveryDate() {
        for (var i = 0; i < deliveryDate.length; i++) {
            var dd = new Date(ParseDateToSimpleDate(expectedDate[i].value));
            dd = dd.add(modeDeliveryTime[i].value * 7).days();
            deliveryDate[i].value = ParseDateToDateWithDay(dd);
        }
    }

    function CalculateLeadTime(sender) {
        var txtLeadTime = sender.parents('tr').find('input[type=text].costing-landed-costing-mode-delivery-time');
        var txtExpectedDate = sender.parents('tr').find('input[type=text].costing-landed-costing-expected-date');

        var expectedDate = new Date(ParseDateToSimpleDate(txtExpectedDate.val()));
        var deliveryDate = new Date(ParseDateToSimpleDate(sender.val()));

        if (deliveryDate < expectedDate) {
            sender.val(txtExpectedDate.val());
            txtLeadTime.val(0);
            return;
        }

        var leadTime = Math.round((deliveryDate - expectedDate) / (1000 * 60 * 60 * 24 * 7));
        txtLeadTime.val(leadTime);
    }

    function DoKeyUpOperation(control, e, context) {
        var txtId;
        var seqNum = control.id.substr(control.id.length - 2);

        if (isNaN(seqNum)) {
            seqNum = control.id.substr(control.id.length - 1)
            txtId = control.id.substr(0, control.id.length - 1);
        }
        else {
            txtId = control.id.substr(0, control.id.length - 2);
        }

        if (e.keyCode == 38) {
            txtId = txtId + (seqNum - 1);
        }
        else if (e.keyCode == 40) {
            txtId = txtId + (+seqNum + 1);
        }
        else {
            switch (context) {
                case 'costing':
                    CalculateCostingTotal(seqNum);
                    break;

                case 'charges':
                    CalculateChargesTotal();
                    break;

                case 'accessories':
                    CalculateAccessoriesTotal(seqNum);
                    break;
            }
        }

        if (null != $('#' + txtId))
            $('#' + txtId).focus();
    }

    function CalculateCostingTotal(seqNum) {
        var total = 0;

        //var Quantity = document.getElementById('<%=txtExpectedQuant.ClientID%>').value;

        var Quantity = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
        //debugger;
        if (seqNum == 0) {
            var Average1 = document.getElementById('<%=txtAverage1.ClientID%>').value;
            var Waste1 = document.getElementById('<%=txtWaste1.ClientID%>').value;
            var Rate1 = document.getElementById('<%=txtRate1.ClientID%>').value;
            //debugger;
            if ((Average1 != '') && (Rate1 != '')) {

                var amount1 = (Average1 * Rate1).toFixed(2);
                $('#<%= txtAmount1.ClientID %>').val(amount1);

                //amount1 = (Math.round((amount1 * (1 + Waste1 / 100)) * 1000) / 1000).toFixed(2);
                txtTotal[0].value = amount1;

                var TotalAvgWstg = parseFloat(Quantity * Average1 * (Waste1 / 100)) + parseFloat(Quantity * Average1);
                txtTotalAvgWstg[0].value = Math.round(TotalAvgWstg);

            }

            var Average2 = document.getElementById('<%=txtAverage2.ClientID%>').value;
            var Waste2 = document.getElementById('<%=txtWaste2.ClientID%>').value;
            var Rate2 = document.getElementById('<%=txtRate2.ClientID%>').value;
            //debugger;
            if ((Average2 != '') && (Rate2 != '')) {

                var amount2 = (Average2 * Rate2).toFixed(2);
                $('#<%= txtAmount2.ClientID %>').val(amount2);

                //amount2 = (Math.round((amount2 * (1 + Waste2 / 100)) * 1000) / 1000).toFixed(2);
                txtTotal[1].value = amount2;

                var TotalAvgWstg = parseFloat(Quantity * Average2 * (Waste2 / 100)) + parseFloat(Quantity * Average2);
                txtTotalAvgWstg[1].value = Math.round(TotalAvgWstg);

            }

            var Average3 = document.getElementById('<%=txtAverage3.ClientID%>').value;
            var Waste3 = document.getElementById('<%=txtWaste3.ClientID%>').value;
            var Rate3 = document.getElementById('<%=txtRate3.ClientID%>').value;
            //debugger;
            if ((Average3 != '') && (Rate3 != '')) {

                var amount3 = (Average3 * Rate3).toFixed(2);
                $('#<%= txtAmount3.ClientID %>').val(amount3);

                //amount3 = (Math.round((amount3 * (1 + Waste3 / 100)) * 1000) / 1000).toFixed(2);
                txtTotal[2].value = amount3;

                var TotalAvgWstg = parseFloat(Quantity * Average3 * (Waste3 / 100)) + parseFloat(Quantity * Average3);
                txtTotalAvgWstg[2].value = Math.round(TotalAvgWstg);

            }

            var Average4 = document.getElementById('<%=txtAverage4.ClientID%>').value;
            var Waste4 = document.getElementById('<%=txtWaste4.ClientID%>').value;
            var Rate4 = document.getElementById('<%=txtRate4.ClientID%>').value;
            //debugger;
            if ((Average4 != '') && (Rate4 != '')) {

                var amount4 = (Average4 * Rate4).toFixed(2);
                $('#<%= txtAmount4.ClientID %>').val(amount4);

                // amount4 = (Math.round((amount4 * (1 + Waste4 / 100)) * 1000) / 1000).toFixed(2);
                txtTotal[3].value = amount4;

                var TotalAvgWstg = parseFloat(Quantity * Average4 * (Waste4 / 100)) + parseFloat(Quantity * Average4);
                txtTotalAvgWstg[3].value = Math.round(TotalAvgWstg);
            }
        }



        if (seqNum > 0) {
            seqNum--;

            if (isNaN(txtAvarage[seqNum].value))
                txtAvarage[seqNum].value = 0;

            if (isNaN(txtAmount[seqNum].value))
                txtAmount[seqNum].value = 0;

            var txtWasteValue = txtWaste[seqNum].value;
            txtWasteValue = 0;
            if (txtWasteValue == -1)
                txtTotal[seqNum].value = 0;
            else
                txtTotal[seqNum].value = (Math.round((txtAmount[seqNum].value * (1 + txtWasteValue / 100)) * 1000) / 1000).toFixed(2);
            var TotalAvgWstg = parseFloat(Quantity * txtAvarage[seqNum].value * (txtWasteValue / 100)) + parseFloat(Quantity * txtAvarage[seqNum].value);
            txtTotalAvgWstg[seqNum].value = Math.round(TotalAvgWstg);
        }

        for (var i = 0; i < txtTotal.length; i++) {
            total = total + +txtTotal[i].value;
        }

        var Average1 = document.getElementById('<%=txtAverage1.ClientID%>').value;
        var Waste1 = document.getElementById('<%=txtWaste1.ClientID%>').value;
        //debugger;
        if ((Average1 != '') && (Waste1 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average1 * (Waste1 / 100)) + parseFloat(Quantity * Average1);
            $('#<%= txtTotalAvgWstg1.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average2 = document.getElementById('<%=txtAverage2.ClientID%>').value;
        var Waste2 = document.getElementById('<%=txtWaste2.ClientID%>').value;
        //debugger;
        if ((Average2 != '') && (Waste2 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average2 * (Waste2 / 100)) + parseFloat(Quantity * Average2);
            $('#<%= txtTotalAvgWstg2.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average3 = document.getElementById('<%=txtAverage3.ClientID%>').value;
        var Waste3 = document.getElementById('<%=txtWaste3.ClientID%>').value;
        //debugger;
        if ((Average3 != '') && (Waste3 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average3 * (Waste3 / 100)) + parseFloat(Quantity * Average3);
            $('#<%= txtTotalAvgWstg3.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average4 = document.getElementById('<%=txtAverage4.ClientID%>').value;
        var Waste4 = document.getElementById('<%=txtWaste4.ClientID%>').value;
        //debugger;
        if ((Average4 != '') && (Waste4 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average4 * (Waste4 / 100)) + parseFloat(Quantity * Average4);
            $('#<%= txtTotalAvgWstg4.ClientID %>').val(Math.round(TotalAvgWstg));

        }
        var txtTotalA = $('#<%= txtTotalA.ClientID %>');
        txtTotalA.val((Math.round(total * 100) / 100).toFixed(2));
        txtTotalA.change();
    }


    function CalculateChargesTotal() {
        //debugger;
        var total = 0;

        for (var i = 0; i < txtChargesValue.length; i++) {
            if (isNaN(txtChargesValue[i].value))
                txtChargesValue[i].value = 0;
            total = total + +txtChargesValue[i].value;
        }

        var txtTotalB = $('#<%= txtTotalB.ClientID %>');
        txtTotalB.val(total);
        txtTotalB.change();
    }

    function CalculateAccessoriesTotal(seqNum) {
        var total = 0;
        var accessoriesPercent;
        var percent = 0;
        var amountSeqNum = 0;

        if (seqNum > 0) {
            seqNum--;

            if (isNaN(txtAccessoriesQuantity[seqNum].value))
                txtAccessoriesQuantity[seqNum].value = 0;

            if (isNaN(txtAccessoriesRate[seqNum].value))
                txtAccessoriesRate[seqNum].value = 0;

            if (seqNum == 8) {
                accessoriesPercent = $('#<%= ddlAccessoriesPercent1.ClientID %>');
                percent = accessoriesPercent.val() == -1 ? 0 : accessoriesPercent.val();
            }
            else if (seqNum == 9) {
                accessoriesPercent = $('#<%= ddlAccessoriesPercent2.ClientID %>');
                percent = accessoriesPercent.val() == -1 ? 0 : accessoriesPercent.val();
            }

            amountSeqNum = seqNum;

            if (percent == 0 && (seqNum == 8 || seqNum == 9)) {
                txtAccessoriesAmount[amountSeqNum].value = 0;
            }
            else if (seqNum != 3) {
                var accAmount = ((+txtAccessoriesQuantity[seqNum].value * +txtAccessoriesRate[seqNum].value) * (1 + percent / 100));
                accAmount = (Math.round(accAmount * 1000) / 1000).toFixed(2);
                txtAccessoriesAmount[amountSeqNum].value = accAmount;
            }
        }

        for (var i = 0; i < txtAccessoriesAmount.length; i++) {
            total = total + +txtAccessoriesAmount[i].value;
        }

        var txtTotalC = $('#<%= txtTotalC.ClientID %>');
        txtTotalC.val((Math.round(total * 1000) / 1000).toFixed(2));
        txtTotalC.change();
    }

    function onPageError(error) {

        alert(error.Message + ' -- ' + error.detail);
    }

    function AddNewPrintRow(printNumber, sender) {

        //  alert(printNumber);
        //  var ttt = printNumber.split(':');

        // var objCell = sender.parents("td"); //alert(printNumber);
        var isPrint = 0;

        if (printNumber.indexOf(' ') > -1) {
            var Fab1Det = printNumber.split(' ');
            if ((Fab1Det.length == 1 && isNumeric(Fab1Det[0])) || (Fab1Det.length == 2 && Fab1Det[1].length <= 2))
                if (Fab1Det[0] != '' && Fab1Det[0] != null) {
                    if (isNumeric(Fab1Det[0])) {
                        isPrint = 1;
                    }
                }
        }
        else
            if (isNumeric(printNumber)) {
                isPrint = 1;
            }
        var printNew = printNumber.replace(" ", "");
        if (isPrint == 1)
            proxy.invoke("GetPrintImageUrlByPrintNumber", { PrintNumber: printNumber },
        function (printImageUrl) {
            if (printImageUrl != null && printImageUrl != 'INVALID') {

                //AddRemoveSymbol(objCell, sender.val(), 'PRD: ', true, true);
                // AddRemoveSymbol(objCell, sender.val(), '', true, true);
                if ($('.prd-' + printNew).length > 0) return;

                var isReturn = false;

                $('.costing-print').each(function () {
                    if ($(this).val() == printNumber) {
                        isReturn = true;
                        return;
                    }
                });

                if (isReturn) return;

                //$('table.costing-print-table tbody tr').append(printHtml);
                $('table.costing-print-table tbody tr', '#divBIPL').append(printHtml);

                tb_init('a.thickbox, area.thickbox, input.thickbox');

                var newPrintTD = $('table.costing-print-table tbody tr', '#divBIPL').find('td:last');
                newPrintTD.attr('className', 'prd-' + printNew);
                newPrintTD.attr('class', 'prd-' + printNew);

                newPrintTD.find('.costing-print').val(printNumber);
                var root = location.protocol + '//' + location.host;
                newPrintTD.find('.thickbox').attr('href', root + '/Uploads/Print/' + printImageUrl);
                newPrintTD.find('.costing-print-image').attr('src', root + '/Uploads/Print/thumb-' + printImageUrl);

                newPrintTD.show();

            }
            else {

                //AddRemoveSymbol(objCell, '', 'PRD: ', true, true);
            }
        }, onPageError, false, false);
    }

    function RemovePrintRow(previousPrintNumber) {

        var printNew = previousPrintNumber.replace(" ", "");
        var txtPrintId = $('.prd-' + printNew + ' input.costing-print');
        if (txtPrintId.length == 1) {
            $('.prd-' + printNew).remove();
        }
        //       // var txtPrintId = $('.prd-' + printNew + ' input.costing-print');
        //      //  if (txtPrintId.length == 1 && txtPrintId.val() == previousPrintNumber) {
        //            $('.prd-' + printNew).remove();
        //      //  }
    }

    function EnableAgree() {
        $('#<%= btnAgree.ClientID %>').attr('disabled', false);
    }



    function CalculateCostingAmount(sender) {

        var average = $(sender).parents('tr').find('input.costing-average').val();
        var rate = $(sender).parents('tr').find('input.costing-rate').val();
        var amount = +average * +rate;

        var txtAmount = $(sender).parents('tr').find('input[type=text].costing-amount');
        txtAmount.val((Math.round(amount * 1000) / 1000).toFixed(2));
        txtAmount.keyup();
    }

    function SetDecimalPlacesForDecimalFields(sender, decimalPlaces) {

        var value = 0;
        if (sender == undefined) {
            $('input[type=text].numeric-field-with-two-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    $(this).val((Math.round(value * 1000) / 1000).toFixed(2));
                }
            });

            $('input[type=text].numeric-field-with-three-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    $(this).val((Math.round(value * 1000) / 1000).toFixed(2));
                }
            });
            $('input[type=text].numeric-field-with-one-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    $(this).val((Math.round(value * 1000) / 1000).toFixed(1));
                }
            });



        }
        else {
            if (sender.val() != '') {
                value = +sender.val();
                sender.val(value.toFixed(decimalPlaces));
                $('input[type=text].costing-landed-costing-penny').parents('td').find('span.penny').text($('#ctl00_cph_main_content_CostingForm1_ddlConvTo option:selected').text());
            }
        }
    }

    function DeleteStyleAndCostingSheet() {
        var styleId = $('input[type=text].costing-style-id').val();
        var collection = getQueryString();
        var costingId = collection['cid'];

        if (styleId != undefined && styleId != null && styleId != '' && styleId > 0 &&
        costingId != undefined && costingId != null && costingId != '') {
            //alert("styleId " + styleId);
            //alert("costingId " + costingId);
            proxy.invoke('DeleteStyleAndCostingSheet', { styleId: styleId, costingId: costingId },
        function (success) {
            if (success)
                ShowHideMessageBox(true, 'Style variation deleted successfully.', 'Costing Sheet - Delete Style Variation', RefreshParentPage);
            else
                ShowHideValidationBox(true, 'Some error occured in deleting Style Variation.', 'Costing Sheet - Delete Style Variation');
        });
        }
    }

    function RefreshParentPage() {
        window.parent.window.location = window.parent.window.location.href;
    }

    function populateParentDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        debugger;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, ParentDeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';

        if ($("#" + hdnParentDeptIdClientID, '#main_content').val() != '' && $("#" + hdnParentDeptIdClientID, '#main_content').val() != null && $("#" + hdnParentDeptIdClientID, '#main_content').val() > 0) {
            $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
        }
    }


    function populateDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        //
        debugger;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';

        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }
    }

    //    function populateDepartments(clientId, selectedDeptID) {
    //        //debugger;
    //        var UserID = parseInt($("#" + hdnuseridClientID).val());
    //        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID }, "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)
    //        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
    //            jscriptPageVariables.selectedDeptID = '';
    //        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
    //            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
    //        }

    //    }
    //abhishek-------18 sep-------//
    //    function BindExpectedQtyDdl() {
    //        debugger;
    //        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
    //        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val()
    //        var SelectedVal = -1;
    //        if (DeptId != "" && DeptId != "-1" && DeptId != "0") {
    //            proxy.invoke("GetExpWastageQty", { ClientId: ClientId, DeptId: DeptId }, 
    //            function (result) {
    //                SelectedVal = result[0].WastageID;
    //            });
    //            alert(SelectedVal);

    //            

    //        }
    //        bindDropdown(serviceUrl, ddlExpectedQty, "GetExpWastageQty", { ClientId: ClientId, DeptId: DeptId }, "WastageQty", "ExpectedID", false, SelectedVal, onPageError)
    //    }
    function BindExpectedQtyDdl() {

        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        debugger;
        if (ClientId == "")
            ClientId = -1;
        var SelectedVal = -1;
        if (DeptId != "" && DeptId != "-1") {
            proxy.invoke("GetExpWastageQty", { ClientId: ClientId, DeptId: DeptId },
                                                            function (result) {
                                                                SelectedVal = (result[0].WastageID);
                                                                bindDropdown(serviceUrl, ddlExpectedQty, "GetExpWastageQty", { ClientId: ClientId, DeptId: DeptId }, "WastageQty", "ExpectedID", false, SelectedVal, onPageError);
                                                            },
                                             onPageError, false, false);
            //alert(SelectedVal);

        }
        else {
            // alert(SelectedVal);
            $("#" + ddlExpectedQty, '#main_content').empty();
        }

    }
    function setDeptName() {
        //        selectedDept = $("#" + DeptDDClientID, "#main_content").val();
        //        $("#" + hdnDeptIdClientID, "#main_content").val(selectedDept);
        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }
        if ($("#" + hdnParentDeptIdClientID, '#main_content').val() != '' && $("#" + hdnParentDeptIdClientID, '#main_content').val() != null && $("#" + hdnParentDeptIdClientID, '#main_content').val() > 0) {
            $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
        }
    }

    function showEmbellishmentReport(Type) {
        var objPrice = '<%=txtChargesValue9.ClientID %>';
        var price = $("#" + objPrice).val()

        if (price == '') {
            price = 0;
        }

        window.open("../Reports/EmbellishmentReport.aspx?FromPrice=" + price + "&ToPrice=" + price + "&Type=" + Type, '_blank');
    }

    function GetFabricQualityData(tradeName, details, mode, index, isLoad) {
        debugger;
        //if (tradeName == "COTTON 1X1 RIB")

        if ($.trim(tradeName) == '')
            return;

        proxy.invoke("GetFabricQualityDetailsByTradeName", { TradeName: tradeName, Details: details, Mode: mode },
                     function (result) {
                         //debugger;
                         if (result == null || result == '')
                             return;

                         var objhlkQuality = $("#hlkQuality" + index);
                         //
                         var row = objhlkQuality.parents('tr')
                         var td = objhlkQuality.parents('td');
                         if (index == 1) {
                             $(".lay_file1").attr("style", "display:block");
                             fabric1(result.GSM, result.CountConstruction);
                         }
                         if (index == 2) {
                             $(".lay_file2").attr("style", "display:block");
                             fabric2(result.GSM, result.CountConstruction);
                         }
                         if (index == 3) {
                             $(".lay_file3").attr("style", "display:block");
                             fabric3(result.GSM, result.CountConstruction);
                         }
                         if (index == 4) {
                             $(".lay_file4").attr("style", "display:block");
                             fabric4(result.GSM, result.CountConstruction);
                         }
                         if (!isLoad) {
                             row.find('.costing-landed-costing-inches').val(result.Width);
                             //row.find('.costing-waste').val(result.Wastage);
                             row.find('.costing-rate').val(result.Price);

                             CalculateCostingAmount(objhlkQuality);
                         }



                         $("#hlkQuality" + index).removeClass("hide_me");
                         //$("#hlkQuality" + index).attr("href", "/Internal/Fabric/FabricQualityEdit.aspx?fabricqualityid=" + result.FabricQualityID);

                         $("#hlkQuality" + index).attr("href", "#" + result.FabricQualityID);

                         row.find('.radio_mode' + index).removeAttr('disabled');

                         if (result.Origin == 1) {
                             td.find('.hid_origin').html("Ind");
                             $('.div_show' + index, "#divBIPL").addClass("hide_me");
                         }
                         else if (result.Origin == 2) {
                             td.find('.hid_origin').html("Imp");
                             $('.div_show' + index, "#divBIPL").removeClass("hide_me");
                         }
                     });
    }

    function showHistory(prmThis, divID) {
        jQuery.facebox($("#" + divID).html());
    }


    function closeCostConfirmationPopup() {

        $("#divCostConfirmation").hide();

    }

    function openCostConfirmationPopup() {

        $("#divCostConfirmation").show();
        return false;
    }

    function launchFabricQualityPopup(prmThis) {
        //  debugger;
        // var fqID = prmThis.href.replace("#", "");

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

    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID) {

        if (StyleNumber.length == 3)
            StyleNumber = "00" + StyleNumber;
        if (StyleNumber.length == 4)
            StyleNumber = "0" + StyleNumber;
        if (StyleNumber.length == 2)
            StyleNumber = "000" + StyleNumber;
        if (StyleNumber.length == 1)
            StyleNumber = "0000" + StyleNumber;
        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function (result) {
            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function LaunchExistingOrdersByStyleVariation(CostingId, StyleNumber) {
        proxy.invoke("GetExistingOrdersByStyleVariations", { CostingID: CostingId, StyleNumber: StyleNumber }, function (result) {
            openQuickLayerFlexible(result);
        }, onPageError, false, false);
    }
    function fabric1(GSM1, Countcon) {
        if (Countcon != '') {

            var imgPrintClientID = '<%=txtCOUNTCON1.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none; ");
            document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>" + Countcon + " |  ";

        }
        else {
            var imgPrintClientID = '<%=txtCOUNTCON1.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:80px;");

            document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>";

        }
        if (GSM1 > 0) {
            var imgPrintClientID = '<%=txtGSML1.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");
            document.getElementById('<%=GSML.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>" + GSM1;
        }
        else {
            var imgPrintClientID = '<%=txtGSML1.ClientID %>';

            $("#" + imgPrintClientID).attr("style", "display:block;width:40px;");
            document.getElementById('<%=GSML.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>";
        }
        //
    }
    function fabric2(GSM1, Countcon) {

        //alert(' fabric2 GSM IS  :' + GSM1 + ' Count Is : ' + Countcon);
        //
        if (Countcon != '') {
            var imgPrintClientID = '<%=txtCOUNTCON2.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");
            document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>" + Countcon + " |  ";
        }
        else {
            var imgPrintClientID = '<%=txtCOUNTCON2.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:80px;");
            document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>";
        }
        if (GSM1 > 0) {
            var imgPrintClientID = '<%=txtGSML2.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");

            document.getElementById('<%=GSML2.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>" + GSM1;
        }
        else {
            var imgPrintClientID = '<%=txtGSML2.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:40px;");

            document.getElementById('<%=GSML2.ClientID%>').innerHTML = "<span style='color:blue'> &nbsp;GSM:</span>";
        }
        //
    }
    function fabric3(GSM1, Countcon) {

        //alert(' fabric3 GSM IS  :' + GSM1 + ' Count Is : ' + Countcon);
        //
        if (Countcon != '') {

            var imgPrintClientID = '<%=txtCOUNTCON3.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");

            document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>" + Countcon + " | ";
        }
        else {
            var imgPrintClientID = '<%=txtCOUNTCON3.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:80px;");

            document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>";
        }

        if (GSM1 > 0) {
            var imgPrintClientID = '<%=txtGSML3.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");

            document.getElementById('<%=GSML3.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>" + GSM1;
        }
        else {
            var imgPrintClientID = '<%=txtGSML3.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:40px;");
            document.getElementById('<%=GSML3.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>";
        }
        //
    }
    function fabric4(GSM1, Countcon) {

        //alert(' fabric4 GSM IS  :' + GSM1 + ' Count Is : ' + Countcon);
        //
        if (Countcon != '') {
            var imgPrintClientID = '<%=txtCOUNTCON4.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");
            document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>" + Countcon + " | ";
        }
        else {
            var imgPrintClientID = '<%=txtCOUNTCON4.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:80px;");
            document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = "<span style='color:blue'>CC:</span>";
        }
        if (GSM1 > 0) {
            var imgPrintClientID = '<%=txtGSML4.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:none;");
            document.getElementById('<%=GSML4.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>" + GSM1;
        }
        else {
            var imgPrintClientID = '<%=txtGSML4.ClientID %>';
            $("#" + imgPrintClientID).attr("style", "display:block;width:40px;");
            document.getElementById('<%=GSML4.ClientID%>').innerHTML = "<span style='color:blue'>&nbsp;GSM:</span>";
        }
        //
    }
    function GetSelectedOrderIDs() {

        var orderIDs = '';
        $("input:checked", "#divOrdersByStyleVariation").each(function (i) {
            if ($(this).is(':checked')) {
                var objRow = $(this).parents("tr");
                var orderID = objRow.find(".hdn-orderid").val();

                if (orderIDs == '')
                    orderIDs = orderID;
                else
                    orderIDs += "," + orderID;
            }
        });

        return orderIDs;
    }

    function UpdateOrderAgreedCostingID(CostingID) {


        var orderIDs = GetSelectedOrderIDs();

        proxy.invoke("UpdateOrderAgreedCosting", { OrderIDs: orderIDs, CostingID: CostingID }, function (result) {

            jQuery.facebox("Order(s) Updated Successfully!");

            RefreshParentPage();

        }, onPageError, false, false);
    }





    function test(obj) {

        var r = obj.id;
        var s1; var printNum;
        var yy = document.getElementById('fab1hdn').value;
        var ss = document.getElementById(r).value;
        var pos = ss.indexOf('(');
        if (ss.indexOf(' --- ') > 0) {
            var tt = new Array();
            tt = ss.split(' --- ');
            printNum = tt[1];
        }
        else if (ss.indexOf('(') > 0) {
            var tt = new Array();
            tt = ss.split('(');
            s1 = tt[0];
            printNum = s1;
        }
        else {
            printNum = ss;
        }
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: printNum },
                     function (result) {
                         // ;
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(printNum, 'obj');
                                 if (ss.indexOf(' --- ') == "-1")
                                     document.getElementById('lblprd11').innerHTML = "PRD: ";

                                 GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);
                                 $("#" + hidFab1DetailsClientID).val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(yy);
                                 document.getElementById('lblprd11').innerHTML = "";
                                 $("#" + hidFab1DetailsClientID).val("COL");
                                 $(".afab").val("COL");
                                 GetFabricQualityData($("#" + txtFabricClientID1).val(), "COL", $("#" + hiddenRadioModeClientID1).val(), 1);

                             }
                         }
                     });
        document.getElementById('fab1hdn').value = printNum;
        document.getElementById('fab2hdn').value = printNum;
    }
    function test2(obj) {
        var r22 = obj.id;
        var s122; var printNum;
        var yy22 = document.getElementById('fab22hdn').value;
        var ss22 = document.getElementById(r22).value;
        var pos22 = ss22.indexOf('(');
        if (ss22.indexOf(' --- ') > 0) {
            var tt22 = new Array();
            tt22 = ss22.split(' --- ');
            printNum22 = tt22[1];
        }
        else if (ss22.indexOf('(') > 0) {
            var tt22 = new Array();
            tt22 = ss22.split('(');
            s122 = tt22[0];
            printNum22 = s122;
        }
        else {
            printNum22 = ss22;
        }
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: printNum22 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(printNum22, 'obj');
                                 if (ss22.indexOf(' --- ') == "-1")
                                     document.getElementById('lblprd22').innerHTML = "PRD: ";
                                 GetFabricQualityData($("#" + txtFabricClientID2).val(), " ", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("#"); $(".b").val("#");
                             }
                             if (result.CountConstruction == "N") {

                                 $(".hidden-details").val("COL");
                                 ;
                                 RemovePrintRow(yy22);
                                 document.getElementById('lblprd22').innerHTML = "";
                                 if (printNum22.indexOf(' ') != "-1") {
                                     var temp2 = new Array();
                                     temp2 = printNum22.split(' ');
                                     GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 }

                                 GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("COL"); $(".b").val("COL");
                             }
                         }
                     });
        document.getElementById('fab22hdn').value = printNum22;
        document.getElementById('fab22hdn2').value = printNum22;
    }
    $(function () {
        //debugger;
        $('input.fab_prt2', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric2.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     }
                 }
        });
        $('input.fab_prt2', '#main_content').result(function () {
            chk2($(this).val());
        });
    });
    function chk2(prtf2) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('(');
            s1f2 = newprtf2[0];
        }
        document.getElementById('fab22hdn').value = s1f2;
        var r3f2 = document.getElementById('fab22hdn2').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {

                                 AddNewPrintRow(s1f2, 'obj');
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd22').innerHTML = "PRD: ";
                                 }
                                 else {
                                     ;
                                     document.getElementById('lblprd22').innerHTML = "";
                                 }
                                 if (s1f2.indexOf(' ') != "-1") {
                                     $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     GetFabricQualityData($("#" + txtFabricClientID2).val(), " ", $("#" + hiddenRadioModeClientID2).val(), 2);

                                 }
                                 else
                                     GetFabricQualityData($("#" + txtFabricClientID2).val(), " ", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("#"); $(".b").val("#");
                                 // { GetFabricQualityData(temp2[0], "COL", $("#" + hiddenRadioModeClientID2).val(), 2); }

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2); ; document.getElementById('lblprd22').innerHTML = "";
                                 GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("COL"); $(".b").val("COL");
                             }
                         }
                     });
        document.getElementById('fab22hdn2').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt2").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == undefined)
            return;
        if (eeff2 == "") {
            $("input.fab_prt2").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 2);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 2);
            }
            document.getElementById('fab22hdn').value = s1ff2;
            document.getElementById('fab22hdn2').value = s1ff2;
        }
    }
 );
    function NewPrintGetOnLoad(PrintNumberNow, rowno) {

        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrintOnLoad", { PrintNumber: PrintNumberNow },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(PrintNumberNow, 'obj');
                                 $("input.fab_prt" + rowno).val(result.TradeName);
                                 if (rowno == "2") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd22').innerHTML = "PRD: ";
                                 }

                                 if (rowno == "3") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd33').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "4") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd44').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "1")
                                     $(".afab").val("#");
                                 if (rowno == "2")
                                     $(".b").val("#");
                                 if (rowno == "3")
                                     $(".c").val("#");
                                 if (rowno == "4")
                                     $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 if (rowno == "3")
                                     document.getElementById('lblprd33').innerHTML = "";
                                 if (rowno == "4")
                                     document.getElementById('lblprd44').innerHTML = "";
                                 if (rowno == "1")
                                     $(".afab").val("COL");
                                 if (rowno == "2")
                                     $(".b").val("COL");
                                 if (rowno == "3")
                                     $(".c").val("COL");
                                 if (rowno == "4")
                                     $(".d").val("COL");
                             }
                         }
                     });
    }
    $(function () {
        
        $('input.fab_prt1', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric1.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     }
                 }
        });
        $('input.fab_prt1', '#main_content').result(function () {
            chk($(this).val());
        });
    });
    function chk(prt) {
        var temp = 0;
        var newprt = new Array();
        var s1;
        var pos = prt.indexOf(' --- ');
        if (pos > 0) {
            var tt = new Array();
            tt = prt.split(' --- ');

            s1 = tt[1];
        }
        else {
            newprt = prt.split('(');
            s1 = newprt[0];
            temp = temp + 1;

        }
        document.getElementById('fab1hdn').value = s1;
        var r3 = document.getElementById('fab2hdn').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: s1 },
                     function (result) {
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1, 'obj'); RemovePrintRow(r3);
                                 if (prt.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd11').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd11').innerHTML = "";


                                 if (s1.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1.split(' ');
                                     GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);

                                 }
                                 else
                                     GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);
                                 $("#" + hidFab1DetailsClientID).val("#"); $(".afab").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3);
                                 document.getElementById('lblprd11').innerHTML = "";
                                 GetFabricQualityData($("#" + txtFabricClientID1).val(), "COL", $("#" + hiddenRadioModeClientID1).val(), 1);
                                 $("#" + hidFab1DetailsClientID).val("COL"); $(".afab").val("COL");
                             }
                         }
                     });
        document.getElementById('fab2hdn').value = s1;
    }
    $(document).ready(function () {
        // ;
        var ee = $("input.fab_prt1").val();
        if (ee == undefined)
            return;
        if (ee == "") {
            $("input.fab_prt1").val("");
        }
        else {
            var s1;
            var pos = ee.indexOf(' --- ');
            if (pos > 0) {
                var tt = new Array();
                tt = ee.split(' --- ');
                s1 = tt[1];
                NewPrintGetOnLoad(s1, 1);
            }
            else {
                s1 = ee;
                NewPrintGetOnLoad(s1, 1);
            }

            document.getElementById('fab1hdn').value = s1;
            document.getElementById('fab2hdn').value = s1;
        }
    }
 );
    $(function () {
        $('input.fab_prt3', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric3.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     }
                 }
        });
        $('input.fab_prt3', '#main_content').result(function () {

            chk3($(this).val());
        });

    });

    function chk3(prtf2) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('(');
            s1f2 = newprtf2[0];
        }
        document.getElementById('fab33hdn').value = s1f2;
        var r3f2 = document.getElementById('fab33hdn3').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: s1f2 },
                     function (result) {
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {



                                 AddNewPrintRow(s1f2, 'obj');
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd33').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd33').innerHTML = "";
                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     GetFabricQualityData($("#" + txtFabricClientID3).val(), " ", $("#" + hiddenRadioModeClientID3).val(), 3);

                                 }
                                 else
                                     GetFabricQualityData($("#" + txtFabricClientID3).val(), " ", $("#" + hiddenRadioModeClientID3).val(), 3);
                                 $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2); document.getElementById('lblprd33').innerHTML = "";
                                 GetFabricQualityData($("#" + txtFabricClientID3).val(), "COL", $("#" + hiddenRadioModeClientID3).val(), 3);
                                 $("#" + hidFab3DetailsClientID).val("COL"); $(".c").val("COL");
                             }
                         }
                     });
        document.getElementById('fab33hdn3').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt3").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == undefined)
            return;
        if (eeff2 == "") {
            $("input.fab_prt3").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 3);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 3);
            }
            document.getElementById('fab33hdn').value = s1ff2;
            document.getElementById('fab33hdn3').value = s1ff2;
        }
    }
 );


    function test3(obj) {
        var r = obj.id;
        var s1; var printNum;
        var yy = document.getElementById('fab33hdn').value;
        var ss = document.getElementById(r).value;
        var pos = ss.indexOf('(');
        if (ss.indexOf(' --- ') > 0) {
            var tt = new Array();
            tt = ss.split(' --- ');
            printNum = tt[1];
        }
        else if (ss.indexOf('(') > 0) {
            var tt = new Array();
            tt = ss.split('(');
            s1 = tt[0];
            printNum = s1;
        }
        else {
            printNum = ss;
        }
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: printNum },
                     function (result) {
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(printNum, 'obj');
                                 if (ss.indexOf(' --- ') == "-1")
                                     document.getElementById('lblprd33').innerHTML = "PRD: ";

                                 GetFabricQualityData($("#" + txtFabricClientID3).val(), "#", $("#" + hiddenRadioModeClientID3).val(), 3)
                                 $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(yy);
                                 document.getElementById('lblprd33').innerHTML = "";
                                 GetFabricQualityData($("#" + txtFabricClientID3).val(), "COL", $("#" + hiddenRadioModeClientID3).val(), 3)
                                 $("#" + hidFab3DetailsClientID).val("COL"); $(".c").val("COL");
                             }
                         }
                     });

        document.getElementById('fab33hdn').value = printNum;
        document.getElementById('fab33hdn3').value = printNum;
    }
    $(function () {
        $('input.fab_prt4', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric4.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     }
                 }
        });
        $('input.fab_prt4', '#main_content').result(function () {

            chk4($(this).val());
        });
    });
    function chk4(prtf2) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('(');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab44hdn').value = s1f2;
        var r3f2 = document.getElementById('fab44hdn4').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, 'obj');
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd44').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd44').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     GetFabricQualityData($("#" + txtFabricClientID4).val(), " ", $("#" + hiddenRadioModeClientID4).val(), 4);

                                 }
                                 else
                                     GetFabricQualityData($("#" + txtFabricClientID4).val(), " ", $("#" + hiddenRadioModeClientID4).val(), 4);
                                 $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2); document.getElementById('lblprd44').innerHTML = "";
                                 GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                 $("#" + hidFab4DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab44hdn4').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt4").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "") {
            $("input.fab_prt4").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 4);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 4);
            }
            document.getElementById('fab44hdn').value = s1ff2;
            document.getElementById('fab44hdn4').value = s1ff2;
        }
    }
 );
    function test4(obj) {
        var r = obj.id;
        var s1; var printNum;
        var yy = document.getElementById('fab44hdn').value;
        var ss = document.getElementById(r).value;
        var pos = ss.indexOf('(');
        if (ss.indexOf(' --- ') > 0) {
            var tt = new Array();
            tt = ss.split(' --- ');
            printNum = tt[1];
        }
        else if (ss.indexOf('(') > 0) {
            var tt = new Array();
            tt = ss.split('(');
            s1 = tt[0];
            printNum = s1;
        }
        else {
            printNum = ss;
        }
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint", { PrintNumber: printNum },
                     function (result) {
                         ;
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(printNum, 'obj');
                                 if (ss.indexOf(' --- ') == "-1")
                                     document.getElementById('lblprd44').innerHTML = "PRD: ";
                                 GetFabricQualityData($("#" + txtFabricClientID4).val(), " ", $("#" + hiddenRadioModeClientID4).val(), 4);
                                 $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");
                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(yy);
                                 document.getElementById('lblprd44').innerHTML = "";
                                 $("#" + hidFab4DetailsClientID).val("COL"); $(".d").val("COL"); GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                             }
                         }
                     });

        document.getElementById('fab44hdn').value = printNum;
        document.getElementById('fab44hdn4').value = printNum;
    }



    $(document).ready(function () {
        $(".btniKandiUpdatePrice").click(function () {
            var s = "undefined,";
            var str1 = $("#" + hdnConIds).val();

            if (str1.indexOf(s) != -1) {
                $("#" + hdnConIds).val(str1.substring(10, str1.length));
            }
            return true;
        });
        $(".btnAllContract").click(function () {
            var s = "";
            $(".GridView1yaten").find("input:checkbox").each(function () {
                if ($(this).is(':checked')) {
                    s = s + (s == "" ? "" : ',') + $(this).closest("tr").find("[name$='hdnOrderId']").val();
                }
            });
            $("#" + hdnConIds).val(s);
            $("#AllContractDiv").dialog('close');
        });


        // start
        $(".hyPricing").click(function () {
            $("#AllContractDiv").show();
            $("#AllContractDiv").dialog({ width: 800, height: 400 });
            return false;
        });
        // End
        $("#divyaten").hide();
        $("#AllContractDiv").hide();
    });

    function MinProfitRollback() {
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        var Profit = document.getElementById('<%=txtMarkupOnUnitCtc.ClientID%>').value;


        proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId },
                                                            function (result) {
                                                                // debugger;
                                                                if (result[0].MinProfit > Profit) {
                                                                    $('#<%= txtMarkupOnUnitCtc.ClientID %>').val(result[0].MinProfit);
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }
                                                                else {
                                                                    $('#<%= txtMarkupOnUnitCtc.ClientID %>').val(Profit);
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }

                                                            },
                                             onPageError, false, false);

    }

    function GetCMTValue() {
        debugger;
        var styleId = $('input[type=text].costing-style-id').val();
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        //        var Quantity = document.getElementById('<%=txtExpectedQuant.ClientID%>').value;
        var Quantity = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
        $('#<%= hdnddlExpectedQty.ClientID %>').val($('#<%= ddlExpectedQty.ClientID %> option:selected').val());

        var SAM = document.getElementById('<%=txtChargesValue11.ClientID%>').value;
        var OB = document.getElementById('<%=txtOB.ClientID%>').value;
        var Achvement = document.getElementById('<%=hdnAch.ClientID%>').value;
        ApplyWastage();
        if (Quantity == '') {
            Quantity = 0;
        }
        if (SAM == '') {
            SAM = 0;
        }
        if (SAM == 'Manual') {
            SAM = 0;
        }
        if (SAM == 'NaN') {
            SAM = 0;
        }
        if (OB == '') {
            OB = 0;
        }
        if (Achvement == '') {
            Achvement = 0;
        }

        proxy.invoke("GetCMT_Value", { SAM: SAM, OB_WS: OB, Achivement: Achvement, ClientId: ClientId, DeptId: DeptId, StyleId: styleId, Quantity: Quantity },
                                                            function (result) {
                                                                cmtvalueRollback(result[0]);
                                                                //                                                                $('#<%= txtChargesValue1.ClientID %>').val(result[0]);
                                                                var OBVal = result[1];
                                                                var LineNo = parseInt(OBVal) / parseInt(OB);
                                                                $('#<%= hdnOBCount.ClientID %>').val(LineNo);
                                                                var TotalMade = result[2];
                                                                //                                                                if (TotalMade != '0') {
                                                                //                                                                    TotalMade = "The optimum quantity is : " + TotalMade + " units";
                                                                //                                                                    $('#<%= lblMsg.ClientID %>').text(TotalMade);
                                                                //                                                                }
                                                                //                                                                else {
                                                                //                                                                    $('#<%= lblMsg.ClientID %>').text('');
                                                                //                                                                }
                                                                CalculateChargesTotal();
                                                                CalculateCostingTotal(0);

                                                            },
                                             onPageError, false, false);

    }
    function ApplyWastage() {
        var ExpectedQty = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();

        proxy.invoke("GetWastage", { ExpectedQty: ExpectedQty },
                                                            function (result) {

                                                                $('#<%= txtFrtUptoFinalDest.ClientID %>').val(result[0].WastageQty);


                                                            },
                                             onPageError, false, false);
    }
    function cmtvalueRollback(CMT) {
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        //        var CMT = document.getElementById('<%=txtChargesValue1.ClientID%>').value;


        proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId },
                                                            function (result) {
                                                                // debugger;
                                                                if (result[0].MinCMT > CMT) {
                                                                    $('#<%= txtChargesValue1.ClientID %>').val(result[0].MinCMT);
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }
                                                                else {
                                                                    $('#<%= txtChargesValue1.ClientID %>').val(CMT);
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }

                                                            },
                                             onPageError, false, false);

    }
    function Rollbackcmt() {
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        var CMT = document.getElementById('<%=txtChargesValue1.ClientID%>').value;


        proxy.invoke("GetClientCostingBy", { ClientId: ClientId, DeptId: DeptId },
                                                            function (result) {
                                                                // debugger;
                                                                if (result[0].MinCMT > CMT) {
                                                                    $('#<%= txtChargesValue1.ClientID %>').val(result[0].MinCMT);
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }
                                                                //                                                                else {
                                                                //                                                                    $('#<%= txtChargesValue1.ClientID %>').val(CMT);
                                                                //                                                                }

                                                            },
                                             onPageError, false, false);

    }
    function SBClose() { }
    function OpenTechfiles(obj) {
        //debugger;
        var Styleid = '<%=this.StyleID %>';

        //var sURL = obj.href;
        var sURL = '../../Internal/OrderProcessing/TechPackUpload.aspx?Styleid=' + Styleid;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        // alert(sURL);
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }

    function OpenPairingCosting(obj) {
        //debugger;
        var Styleid = '<%=this.StyleID %>'; //<a href="~/UserControls/Lists/PairingCosting.ascx">~/UserControls/Lists/PairingCosting.ascx</a>

        //var sURL = obj.href;
        var sURL = '../../Internal/Sales/CostingPaired.aspx?Styleid=' + Styleid;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        // alert(sURL);
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 300, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;

    }
</script>
<script type="text/javascript">
    function isNumberKey(evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 45 || charCode > 57)) {
            return false;
        }
        return true;
    }
</script>
<div>
    <table width="100%">
        <tr>
            <td align="center" colspan="4">
                <asp:HiddenField Value="" runat="server" ID="hdnConIds" />
                <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<table width="100%" class="form_table style-table" bordercolor="#000000" border="1">
    <tr>
        <td class="form_small_heading_pink" style="width: 10%">
            Style:
        </td>
        <td class="blue_center_text" style="width: 20%">
            <asp:TextBox runat="server" ID="txtStyleNumberSearch" CssClass="costing-style required do-not-disable"
                title="Please enter Style Number" Style="width: 160px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnGo" runat="server" CssClass="go costing-style-go validate-form do-not-disable" />
        </td>
    </tr>
</table>
<div class="costing_form hide_me1" runat="server" id="BIPLCosting">
    <div class="print-box">
        <div id="divBIPL">
            <div class="form_box">
                <div class="form_heading">
                    <asp:Label ID="lblHeadingCostingSheet" runat="server" Text="BOUTIQUE COSTING SHEET"></asp:Label>
                    <asp:Label ID="lblLastUpdatedDate" runat="server" Style="position: relative; left: 27%;
                        color: Black; font-size: 12px; vertical-align: top"></asp:Label>
                    <asp:HyperLink runat="server" ID="hypOrdersByVariations" Style="position: relative;
                        left: 30%; color: Black; font-size: 12px; vertical-align: top" Visible="false"
                        Text="Select Orders"></asp:HyperLink>
                </div>
                <table width="100%" class="form_table" bordercolor="#000000" border="1" id="form_table_heading">
                    <tbody>
                        <tr>
                            <td width="4%" style="font-size: smaller;" class="form_small_heading_pink bluebgcolor">
                                Style
                            </td>
                            <td align="left" class="blue_center_text bluebgcolor">
                                <input id="hdnFabchk" class="afab" value="COL" type="hidden" />
                                <input id="hdnFabchk2" class="b" value="COL" type="hidden" />
                                <input id="hdnFabchk3" class="c" value="COL" type="hidden" />
                                <input id="hdnFabchk4" class="d" value="COL" type="hidden" />
                                <asp:TextBox runat="server" ID="txtIkandiStyle" ReadOnly="true" Style="font-size: smaller;
                                    width: 100px; height: 15px; color: white;" CssClass="costing-style-number-view bluebgcolor"></asp:TextBox>
                                <asp:Label ID="hdnBuyingHouse" CssClass="buying-house-id" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="left" width="8%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Garment Type
                            </td>
                            <td align="left" width="4%" class="bluebgcolor">
                                <asp:Label ID="lblGarmetType" CssClass="exqty" Style="font-size: smaller;" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="4%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Buyer
                            </td>
                            <td align="left" width="6%" class="bluebgcolor">
                                <asp:DropDownList ID="ddlBuyer" runat="server" Style="font-size: smaller;" CssClass="costing-buyer"
                                    Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td align="left" width="4%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Parent Dept
                            </td>
                            <td align="left" style="width: 5%;" class="bluebgcolor">
                                <div>
                                    <asp:DropDownList runat="server" ID="ddlParentDept" Style="font-size: smaller;" CssClass="costing-Parentdepartment"
                                        Width="100px">
                                        <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:HiddenField runat="server" ID="hdnParentDeptId" Value="0" />
                            </td>
                            <td align="left" width="4%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Dept
                            </td>
                            <td align="left" style="width: 5%;" class="bluebgcolor">
                                <div>
                                    <asp:DropDownList runat="server" ID="ddlDept" Style="font-size: smaller;" CssClass="costing-department"
                                        Width="100px">
                                        <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:HiddenField runat="server" ID="hdnDeptId" Value="0" />
                                <asp:HiddenField ID="hdnuserid" runat="server" Value="0" />
                            </td>
                            <td width="5%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                <asp:Label runat="server" ID="hypBooked" Text="Booked" ForeColor="Blue" Style="cursor: pointer;"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdStyleCOdeValue" />
                            </td>
                            <td width="5%" style="text-align: center;" class="bluebgcolor">
                                <asp:TextBox runat="server" ID="txtQuantity" Style="font-size: smaller; width: 70px;
                                    height: 15px; display: none;" CssClass="numeric-field-without-decimal-places"
                                    Text=""></asp:TextBox>
                                <a id="anchorQuantity" runat="server" href="javascript:void(0)" visible="false" onclick="showAllOrdersOnStyle()"
                                    style="text-decoration: none; color: Blue; font-size: 14px; font-size: smaller;">
                                </a>
                            </td>
                            <td width="8%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Expected Quantity
                            </td>
                            <td width="4%" class="bluebgcolor">
                                <asp:HiddenField runat="server" ID="hdnManualValue" />
                                <asp:TextBox ID="txtExpectedQuant" onchange="javascript:return GetCMTValue();" CssClass="numeric-field-without-decimal-places"
                                    runat="server" Style="font-size: 11px !important; color: #000000 !important;
                                    font-weight: bold; width: 70px; height: 15px; display: none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlExpectedQty" onchange="javascript:return GetCMTValue();"
                                    CssClass="exqty" runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hdnddlExpectedQty" />
                            </td>
                            <td width="6%" style="font-size: smaller;" class="bluebgcolor">
                                BestSeller<asp:CheckBox ID="chkIsBestSeller" runat="server" Style="font-size: smaller;" />
                            </td>
                            <td width="6%" class="form_small_heading_pink bluebgcolor" style="font-size: smaller;">
                                Weight(Gms)
                            </td>
                            <td width="4%" class="bluebgcolor">
                                <asp:TextBox runat="server" ID="txtWeight" Style="font-size: smaller; width: 50px;
                                    height: 15px;" CssClass="numeric-field-without-decimal-places" title="Please enter Weight"></asp:TextBox>
                                <div id="hiddenValues" style="display: none">
                                    <asp:TextBox ID="txtStyleNumber" runat="server" CssClass="costing-style-number" Style="font-size: smaller;"></asp:TextBox>
                                    <asp:TextBox ID="txtStyleId" runat="server" CssClass="costing-style-id" Style="font-size: smaller;"></asp:TextBox>
                                    <asp:TextBox ID="txtOrderId" runat="server" CssClass="costing-order-id" Style="font-size: smaller;"></asp:TextBox>
                                    <asp:TextBox ID="txtCurrentStatusID" runat="server" CssClass="costing-current-status-id"
                                        Style="font-size: smaller;"></asp:TextBox>
                                </div>
                            </td>
                            <td id="tdCounterComplete" runat="server" width="7%" style="font-size: smaller;"
                                class="counter-complete">
                            </td>
                            <td width="0%" visible="false" style="display: none">
                            </td>
                            <td runat="server" id="tdStatus" style="width: 7%;" class="status">
                                <asp:HiddenField ID="hiddenStyleId" Value="-1" runat="server" />
                                <a id="anchorWorkFlowHistory" href="javascript:void(0)" title="CLICK TO VIEW TRACKING POPUP"
                                    onclick="showWorkflowHistory2(<%= hiddenStyleId.Value %>, -1, -1)" style="font-size: smaller;
                                    color: black;">
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </a>
                            </td>
                            <td style="width: 4%; background-color: #dddfe4;" id="tdDeleteStyleAndCostingSheet"
                                class='<%= txtOrderId.Text == "-1" ? "form_small_heading_pink" : "hide_me" %>'>
                                <a href="javascript:DeleteStyleAndCostingSheet()" title="Delete Style Variation"
                                    style="text-decoration: none; font-size: smaller; color: #575759 !important;"
                                    onclick="return confirm('Are you sure to Delete this Style?');">Del</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblCostingDetails" runat="server" width="100%" cellspacing="0" class="form_table"
                    bordercolor="#000000" border="1">
                    <tbody>
                        <tr class="form_small_heading_pink">
                            <td colspan="7" class="lightbluebgcolor">
                                Fabric
                            </td>
                            <td colspan="2" class="lightbluebgcolor">
                                Production
                            </td>
                            <td colspan="5" class="lightbluebgcolor">
                                Accessories
                            </td>
                            <td colspan="2" class="lightbluebgcolor">
                                Financials
                            </td>
                        </tr>
                        <tr>
                            <td class="style17 lightbg1">
                                TYPE
                            </td>
                            <td class="style17 lightbg1" colspan="2">
                                DETAILS
                            </td>
                            <td class="style17 lightbg1" align="center">
                                WIDTH
                            </td>
                            <td class="style17 lightbg1" style="width: 70px;" align="center">
                                AVG-LPlan.
                            </td>
                            <td class="style17 lightbg1" align="center">
                                RATE
                            </td>
                            <td class="hide_me style17 lightbg1" align="center">
                                AMT.
                            </td>
                            <td class="style17 hide_me lightbg1" style="padding-left: 9px; width: 50px; padding-right: 4px"
                                align="center">
                                WST.
                            </td>
                            <td class="style17 lightbg1" align="center">
                                TOTAL / Meterage
                            </td>
                            <td class="style17 lightbg1" colspan="2" align="center">
                                CUT MAKE THREAD
                                <br />
                                OB file
                                <asp:FileUpload ID="uploadob" runat="server" Style="font-size: 10px; width: 70px" />
                                <asp:HyperLink ID="hypviewObfile" Visible="false" Style="cursor: pointer;" runat="server"
                                    ToolTip="View OB file" CssClass="view-image" Target="_blank" ImageUrl="~/images/view-icon.png"
                                    Text=""></asp:HyperLink>
                            </td>
                            <td class="style17 lightbg1" colspan="2">
                                ITEM
                            </td>
                            <td class="style17 lightbg1" align="center">
                                QTY
                            </td>
                            <td class="style17 lightbg1" align="center">
                                RATE
                            </td>
                            <td class="style17 lightbg1" align="center">
                                AMT.
                            </td>
                            <td class="style16 lightbg1">
                                A+B+C
                            </td>
                            <td class="style17 lightbg1">
                                Rs.
                                <asp:TextBox runat="server" ID="txtTotalABC" Width="40px" BorderStyle="None" CssClass="costing-final-cost do-not-allow-typing lightbg1"
                                    Style="color: Black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblTotalABC" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlPrintType1" class="lightbg1" BorderStyle="None">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lblPrintType1" runat="server"></asp:Label></div>
                            </td>
                            <td style="text-align: left;" class="style18">
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtFabric1" MaxLength="60" runat="server" Width="220px" BorderStyle="None"
                                            CssClass="costing-fabric fabric1 blue-text darkbg1" Style="text-align: left;"></asp:TextBox>
                                        <asp:Label ID="lblFabric1" runat="server"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="  "></asp:Label>
                                    </div>
                                    <div style="float: left;">
                                        <nobr>
                                    <div style="float:left;">
                                     <asp:Label ID="COUNTCON" runat="server" Font-Size="Smaller"></asp:Label>
                                     </div><div style="float:left;"><asp:TextBox ID="txtCOUNTCON1" CssClass="style18" MaxLength="100" style="display:none" runat="server"  BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                     </div><div style="float:left;"><asp:Label ID="GSML" runat="server" Font-Size="Smaller"></asp:Label>
                                     </div><div style="float:left;"><asp:TextBox ID="txtGSML1" MaxLength="30" style="display:none;" CssClass="lightbg2" runat="server" Width="40px" BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                     </div></nobr>
                                    </div>
                                </div>
                            </td>
                            <td class="lightbg1" width="60">
                                <nobr>
                                <asp:Label ID="lblOrigin1" runat="server" CssClass="hid_origin"></asp:Label>&nbsp; <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="hlkQuality1"
                                    class="hide_me" style="text-align: right;margin-right:2px" onclick="return launchFabricQualityPopup(this)">
                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg"
                                        height="10px" width="10px" border="0" style="text-align: right;margin-right:2px" /></a></nobr>
                            </td>
                            <td rowspan="2" class="lightbg1" style="text-align: center;">
                                <div class="inches">
                                    <asp:TextBox runat="server" ID="txtWidth1" Width="30px" Font-Size="14px" BorderStyle="None"
                                        Style="text-align: center; color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches lightbg1"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblWidth1" runat="server"></asp:Label>
                            </td>
                            <td rowspan="2" class="td_no_padding" style="text-align: center;" bgcolor="#f9f9fb">
                                <asp:TextBox runat="server" ID="txtAverage1" Width="65px" Font-Size="Large" BorderStyle="None"
                                    Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1"></asp:TextBox><br />
                                <asp:Label ID="lblAverage1" runat="server" Font-Size="12px"></asp:Label>
                                <asp:FileUpload ID="LayFile1" CssClass="lay_file1 style20" runat="server" />
                                <table width="100%" cellpadding="0" cellspacing="0" style="text-align: left; line-height: 5px;">
                                    <tr>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:Label ID="lblcst1" runat="server" Text="CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                        </td>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:HyperLink ID="viewolay1" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay1"
                                                Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:Label ID="lblmarker1" runat="server" Text="Ord CAD" Style="display: none;"> </asp:Label>
                                        </td>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:HyperLink ID="ViewStc1" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1"
                                                Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:Label ID="lblcad1" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                        </td>
                                        <td style="font-size: 8px; margin: 0px; padding: 1px">
                                            <asp:HyperLink ID="ViewCad1" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1"
                                                Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                                <%--   /*Ended by uday*/    --%>
                            </td>
                            <td rowspan="2" class="lightbg1" align="center">
                                <asp:TextBox runat="server" ID="txtRate1" Font-Size="Large" Width="40px" BorderStyle="None"
                                    ForeColor='black' CssClass="numeric-field-without-decimal-places costing-rate lightbg1"></asp:TextBox><br />
                                <asp:Label ID="lblRate1" runat="server" Font-Size="12px"></asp:Label>
                            </td>
                            <td class="hide_me lightbg1" rowspan="2" align="center">
                                <asp:TextBox runat="server" ID="txtAmount1" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAmount1" runat="server"></asp:Label></div>
                            </td>
                            <td style="padding-left: 2px" rowspan="2" class="lightbg1 hide_me" align="center">
                                <asp:TextBox ID="txtWaste1" runat="server" Width="30px" Font-Size="13px" BorderStyle="None"
                                    Style="color: black; pointer-events: none;" CssClass="costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1"
                                    MaxLength="2"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblWaste1" Style="color: black;" runat="server"></asp:Label></div>
                            </td>
                            <td align="center" rowspan="2" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtTotal1" Width="55px" BorderStyle="None" Font-Size="14px"
                                    Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblTotal1" runat="server"></asp:Label></div>
                                <div style="padding-top: 4px;">
                                    <asp:TextBox ID="txtTotalAvgWstg1" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                        CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                        display: none; text-align: center;"></asp:TextBox>
                                </div>
                            </td>
                            <td class="lightbg2">
                                <table width="100%" border="0">
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="hlinkSAM" ToolTip="VIEW OB SHEET" Visible="true" runat="server"
                                                CssClass="" Target="_blank" Text="SAM" Font-Bold="true" Font-Size="10PX"></asp:HyperLink>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChargesValue11" onchange="javascript:return GetCMTValue();" runat="server"
                                                MaxLength="4" onkeypress="return isNumberKey(event)" class="numeric-field-with-one-decimal-places darkbg1"
                                                RegularExpression="^[0-9.\-]+$" Text="" Width="25px" Font-Bold="true" Height="15px"
                                                Style="border: 1px solid #c3c3c3; background: #fefefe; margin-bottom: 5px; border-radius: 3px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold;">
                                            OB W/S
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtOB" runat="server" MaxLength="3" class="numeric-field-without-decimal-places darkbg1"
                                                Text="" Width="25px" Height="15px" Style="font-weight: bold; border: 1px solid #c3c3c3;
                                                color: #000; background: #fefefe; border-radius: 3px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <%-- abhishek--%>
                                <%-- end --%>
                            </td>
                            <td class="style14 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue1" onblur="javascript:return Rollbackcmt();" Width="62px"
                                    Height="15px" ForeColor="black" BorderStyle="None" Style="text-align: center;
                                    font-size: 13px; font-weight: bold;"></asp:TextBox>
                                <asp:HiddenField ID="hdnAch" runat="server" />
                                <div>
                                    <asp:Label ID="lblChargesValue1" runat="server" Font-Size="12px"></asp:Label></div>
                                <asp:HiddenField ID="hdnOBCount" Value="0" runat="server" />
                            </td>
                            <td id="Td1" width="10%" class="style19" bgcolor="#F9DDF4" runat="server" visible="false">
                                <asp:TextBox runat="server" ID="txtChargesName1" Font-Size="12px" Text="SAM" Width="70%"
                                    BorderStyle="None" CssClass="form_small_heading_pink"></asp:TextBox>
                                <asp:DropDownList ID="ddlChargeValue" CssClass="exqty" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMaking" Height="5px" Visible="false" CssClass="exqty making costing-charges-value"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hdnMaking" Value="0" />
                                <div>
                                    <asp:Label ID="lblChargesName1" Font-Size="12px" runat="server"></asp:Label></div>
                            </td>
                            <td id="Td2" width="5%" class="style12" bgcolor="#f9f9fb" runat="server" visible="false">
                                <%--<asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places background_silver_style"
                                    ID="txtChargesValue1" Width="100%" Font-Size="Large" ForeColor="black" BorderStyle="None"></asp:TextBox>--%>
                                <div>
                                    <%-- <asp:Label ID="lblChargesValue1" runat="server" Font-Size="12px"></asp:Label>--%>
                                </div>
                            </td>
                            <td colspan="2" class="style19">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem1" Text="INT. LINING" Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem1" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity1" Width="100%" BorderStyle="None"></asp:TextBox><div>
                                        <asp:Label ID="lblAccessoriesQuantity1" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate1" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate1" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount1" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount1" runat="server"></asp:Label></div>
                            </td>
                            <td class="style18">
                                Wastage
                            </td>
                            <td style="text-align: center;" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtFrtUptoFinalDest" Style="color: black;" Width="45px"
                                    BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-final-cost do-not-allow-typing lightbg1"></asp:TextBox>
                                %
                                <div>
                                    <asp:Label ID="LblWastage" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style18">
                                <div style="vertical-align: bottom; float: left; text-align: left;" class="td_no_padding">
                                    <asp:Label ID="lbl1" CssClass="lblone" runat="server" Text=""></asp:Label>
                                    <label id="lblprd11" class="a">
                                    </label>
                                    <input id="txtFabricType1" style="text-align: left; width: 160px;" runat="server"
                                        class="one fabric1-type fabric-type blue_center_text fab_prt1 style18" onkeyup="test(this)"
                                        type="text" />
                                    <input id="fab1hdn" value="yaten" type="hidden" />
                                    <input id="fab2hdn" value="yaten" type="hidden" />
                                    <asp:TextBox ID="hdn1" runat="server" Style="display: none;" BorderStyle="None" Width="135px"
                                        CssClass="onehide"></asp:TextBox>
                                    <asp:TextBox ID="hdn1Prev" runat="server" Style="display: none;" BorderStyle="None"
                                        Width="150px" CssClass="oneprev"></asp:TextBox>
                                    <br />
                                    <nobr>
                                     <div style="float:left;"><asp:Label ID="lblFabricType1" runat="server" CssClass=""></asp:Label>
                                     
                                    <input type="hidden" id="hidFab1Details" class="hidden-details" value="COL" runat="server" />
                                 </div></nobr>
                                </div>
                            </td>
                            <td width="60" class="lightbg1" style="text-align: center;">
                                <div style="" class=" div_show hide_me div_show1" id="divRadioMode1">
                                    <nobr>
                                        <input type="radio" name="radioMode1" value="1" class="radio_mode1 radio_mode"  checked="checked"
                                            style="font-size: 8px; width: 12px; height: 12px" title="A" />A
                                        <input type="radio" name="radioMode1" value="0" class="radio_mode1 radio_mode"  style="font-size: 8px;
                                            width: 12px; height: 12px" title="S"/>S
                                    </nobr>
                                    <asp:HiddenField runat="server" ID="hiddenRadioMode1" Value="1" />
                                </div>
                                <nobr>
                                <img id="imgFab1a" style="display:none;" class="imgFab" src="../../Images/multipleIcon.png" alt="Multiple Prints / solids are associated with this style" title="Multiple Prints / solids are associated with this style" />
                                <asp:Image ID="imgFab1" Visible="false" ImageUrl="~/Images/multipleIcon.png" runat="server" AlternateText="Multiple Prints / solids are associated with this style" ToolTip="Multiple Prints / solids are associated with this style" />
                                </nobr>
                            </td>
                            <td class="style13">
                                <asp:TextBox runat="server" ID="txtChargesName2" Text="Recutting" Width="100%"
                                    CssClass="form_small_heading_pink1" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName2" runat="server"></asp:Label></div>
                            </td>
                            <td class="style14 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue2" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue2" runat="server"></asp:Label></div>
                            </td>
                            <td colspan="2" class="style13 lightbg1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem2" CssClass="form_small_heading_pink1"
                                    Text="ELASTIC" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem2" runat="server"></asp:Label></div>
                            </td>
                            <td class="style14 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity2" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity2" runat="server"></asp:Label></div>
                            </td>
                            <td class="style14 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate2" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate2" runat="server"></asp:Label></div>
                            </td>
                            <td class="style14 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount2" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount2" runat="server"></asp:Label></div>
                            </td>
                            <td class="style14">
                                <%--FRT UPTO PORT (+)
                                Freight & Platform (+)--%>
                                Customs, Doc & Platform
                            </td>
                            <td align="center" class="style14 lightbg1">
                                <asp:TextBox runat="server" ID="txtFrtUptoPort" Width="60px" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-final-cost lightbg1 do-not-allow-typing"
                                    Style="color: Black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblFrtUptoPort" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlPrintType2" class="lightbg1" BorderStyle="None">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lblPrintType2" runat="server"></asp:Label></div>
                            </td>
                            <td style="text-align: left" class="style18">
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtFabric2" MaxLength="60" runat="server" Width="220px" BorderStyle="None"
                                            CssClass="costing-fabric fabric2 blue-text darkbg1" Style="text-align: left"></asp:TextBox>
                                        <asp:Label ID="lblFabric2" runat="server"></asp:Label>
                                    </div>
                                    <div style="float: left;">
                                        <nobr>
                                    <div style="float:left;">
                                        <asp:Label ID="COUNTCON2" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtCOUNTCON2" CssClass="style18" MaxLength="3" Style="display: none" runat="server"
                                            Width="40px" BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                        </div><div style="float:left;"><asp:Label ID="GSML2" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtGSML2" MaxLength="30" Style="display: none;" runat="server" Width="40px" CssClass="lightbg2"
                                            BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                    </div></nobr>
                                    </div>
                            </td>
                            <td class="lightbg1">
                                <nobr>
                                <asp:Label ID="lblOrigin2" runat="server" CssClass="hid_origin"></asp:Label>&nbsp;
                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="hlkQuality2"
                                    class="hide_me" style="text-align: right;margin-right:2px" onclick="return launchFabricQualityPopup(this)">
                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg"
                                        height="10px" width="10px" border="0" style="text-align: right;margin-right:2px"/></a>
                                </nobr>
                            </td>
                            <td rowspan="2" style="text-align: center" class="lightbg1" align="center">
                                <div class="inches">
                                    <asp:TextBox runat="server" ID="txtWidth2" Width="30px" Font-Size="14px" Style="text-align: center;
                                        color: Black;" BorderStyle="None" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches lightbg1"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblWidth2" runat="server"></asp:Label>
                            </td>
                            <td rowspan="2" class="td_no_padding" style="text-align: center" bgcolor="#f9f9fb">
                                <asp:TextBox runat="server" ID="txtAverage2" Font-Size="Large" Style="text-align: center"
                                    ForeColor='blue' Width="65px" BorderStyle="None" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAverage2" runat="server" Font-Size="12px"></asp:Label>
                                    <asp:FileUpload ID="LayFile2" CssClass="lay_file2 style20" runat="server" />
                                    <table width="100%" cellpadding="0" cellspacing="0" style="text-align: left; line-height: 5px;">
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcst2" runat="server" Text="CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="viewolay2" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay2"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblmarker2" runat="server" Text="Ord CAD" Style="display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewStc2" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcad2" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewCad2" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--   /*Ended by uday*/ --%>
                                </div>
                            </td>
                            <td rowspan="2" class="lightbg1" align="center">
                                <asp:TextBox runat="server" ID="txtRate2" Font-Size="Large" Width="40px" BorderStyle="None"
                                    ForeColor='black' CssClass="numeric-field-without-decimal-places costing-rate lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblRate2" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td class="hide_me lightbg1" rowspan="2" align="center">
                                <asp:TextBox runat="server" ID="txtAmount2" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAmount2" runat="server"></asp:Label></div>
                            </td>
                            <td style="padding-left: 2px" rowspan="2" class="lightbg1 hide_me" align="center">
                                <asp:TextBox ID="txtWaste2" runat="server" Width="30px" Font-Size="13px" BorderStyle="None"
                                    MaxLength="2" Style="color: black; pointer-events: none;" CssClass="costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblWaste2" Style="color: black;" runat="server"></asp:Label></div>
                            </td>
                            <td align="center" rowspan="2" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtTotal2" Width="55px" Font-Size="14px" BorderStyle="None"
                                    CssClass="costing-totalFabric do-not-allow-typing lightbg1" Style="color: Black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblTotal2" runat="server"></asp:Label></div>
                                <div style="padding-top: 4px;">
                                    <asp:TextBox ID="txtTotalAvgWstg2" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                        CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                        display: none; text-align: center;"></asp:TextBox></div>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ID="txtChargesName3" ReadOnly="true" Text="Lbls,Tgs,Pcg & Ins."
                                    Width="100%" BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName3" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" ID="txtChargesValue3" ReadOnly="true" Font-Size="15px"
                                    font-weight="bold" ForeColor="black" Width="100%" BorderStyle="None" CssClass="lightbg1 costing-charges-value numeric-field-without-decimal-places "></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue3" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td colspan="2" class="lightbg2">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem3" Text="BUTTONS" Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem3" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity3" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity3" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate3" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate3" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount3" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount3" runat="server"></asp:Label></div>
                            </td>
                            <td id="tdOverHead" runat="server">
                                Overhead
                                <!--FINC. COST (+)-->
                            </td>
                            <td style="text-align: center;" class="lightbg1" id="tdOverHeadValue" runat="server">
                                <asp:TextBox ID="txtOverHead" Style="color: black;" runat="server" Width="45px" BorderStyle="None"
                                    CssClass="numeric-field-with-two-decimal-places costing-final-cost do-not-allow-typing lightbg1 "></asp:TextBox>
                                <asp:TextBox ID="TextBox31" Style="display: none" runat="server"></asp:TextBox>
                                %
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style18">
                                <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                    <asp:Label ID="lbl2" Visible="false" CssClass="lblTwo" runat="server" Text=""></asp:Label>
                                    <label id="lblprd22" class="a">
                                    </label>
                                    <input id="txtFabricType2" style="text-align: left; width: 160px;" runat="server"
                                        class="two fabric-type blue_center_text darkbg1 fab_prt2" onkeyup="test2(this)"
                                        type="text" />
                                    <input id="fab22hdn" value="yaten" type="hidden" />
                                    <input id="fab22hdn2" value="yaten" type="hidden" />
                                    <asp:TextBox ID="hdn2" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                        CssClass="twohide"></asp:TextBox>
                                    <asp:TextBox ID="hdn2Prev" runat="server" BorderStyle="None" Style="display: none;"
                                        Width="150px" CssClass="twoprev"></asp:TextBox>
                                    <br />
                                    <nobr><asp:Label ID="lblFabricType2" runat="server" CssClass=""></asp:Label>
                                    <input type="hidden" id="hidFab2Details" class="hidden-details" value="COL" runat="server" />
                                 </nobr>
                                </div>
                            </td>
                            <td style="text-align: center;" bgcolor="#f9f9fb">
                                <div class=" div_show hide_me div_show2" id="divRadioMode2">
                                    <nobr>
                                <input type="radio" name="radioMode2" value="1" class="radio_mode2 radio_mode" title="A"  checked="checked" style="font-size:8px;width:12px;height:12px"/>A
                                <input type="radio" name="radioMode2" value="0" class="radio_mode2 radio_mode" title="S"  style="font-size:8px;width:12px;height:12px"/>S
                                </nobr>
                                    <asp:HiddenField runat="server" ID="hiddenRadioMode2" Value="1" />
                                </div>
                                <nobr>
                                     <img id="imgFab2a" class="imgFab" style="display:none;" src="../../Images/multipleIcon.png" alt="Multiple Prints / solids are associated with this style" title="Multiple Prints / solids are associated with this style" />
                                 <asp:Image ID="imgFab2" Visible="false" ImageUrl="~/Images/multipleIcon.png" runat="server" AlternateText="Multiple Prints / solids are associated with this style" ToolTip="Multiple Prints / solids are associated with this style" />
                                 </nobr>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ReadOnly="true" CssClass="form_small_heading_pink1" ID="txtChargesName4"
                                    Text="Coffin Box" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName4" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue4" Style="color: Black;" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue4" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1" colspan="2">
                                <asp:DropDownList runat="server" ID="ddlAccessoriesItem4" Width="100%" BorderStyle="None"
                                    CssClass="form_small_heading_pink1 costing-accessories-zip" ForeColor="Black">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblAccessoriesItem4" runat="server"></asp:Label>
                            </td>
                            <td class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlAccessoriesQuantity4" Width="60px" BorderStyle="None"
                                    CssClass=" costing-accessories-quantity costing-accessories-zip lightbg1" ForeColor="Black">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Closed" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Open" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity4" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlAccessoriesRate4" BorderStyle="None" CssClass=" costing-accessories-rate costing-accessories-zip lightbg1"
                                    ForeColor="Black">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate4" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" ID="txtAccessoriesAmount4" Width="100%" BorderStyle="None"
                                    ForeColor="Black" CssClass="costing-accessories-amount  costing-accessories-zip numeric-field-with-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount4" runat="server"></asp:Label></div>
                            </td>
                            <td id="tdDC" runat="server">
                                <%--DBK Counter--%>
                                <!--DIRECT COST (+)-->
                            </td>
                            <td style="text-align: center;" class="lightbg1" id="tdDCValue" runat="server">
                                <asp:TextBox ID="txtDesingCommission" Style="color: black; display: none;" runat="server"
                                    Text="6.5" Width="45px" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-on-unit-commission cost do-not-allow-typing lightbg1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlPrintType3" class="lightbg1" BorderStyle="None">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="lblPrintType3" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style18">
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtFabric3" MaxLength="60" runat="server" Width="220px" BorderStyle="None"
                                            CssClass="costing-fabric fabric3 blue-text darkbg1" Style="text-align: left"></asp:TextBox>
                                        <asp:Label ID="lblFabric3" runat="server"></asp:Label>
                                    </div>
                                    <div style="float: left;">
                                        <nobr>
                                    <div style="float:left;">
                                        <asp:Label ID="COUNTCON3" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtCOUNTCON3" CssClass="style18" MaxLength="30" Style="display: none" runat="server"
                                            Width="220px" BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                        </div><div style="float:left;"><asp:Label ID="GSML3" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtGSML3" MaxLength="30" Style="display: none;" CssClass="lightbg2" runat="server" Width="220px"
                                            BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                    </div>
                                    </nobr>
                                    </div>
                            </td>
                            <td class="lightbg1">
                                <nobr>
                                <asp:Label ID="lblOrigin3" runat="server" CssClass="hid_origin"></asp:Label>&nbsp;
                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="hlkQuality3"
                                    class="hide_me" style="text-align: right;margin-right:2px" onclick="return launchFabricQualityPopup(this)">
                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg"
                                        height="10px" width="10px" border="0" style="text-align: right;margin-right:2px"/></a>
                                </nobr>
                            </td>
                            <td rowspan="2" style="text-align: center" class="lightbg1" align="center">
                                <div class="inches">
                                    <asp:TextBox runat="server" ID="txtWidth3" Font-Size="14px" Style="text-align: center;
                                        color: Black;" Width="30px" BorderStyle="None" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches lightbg1"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblWidth3" runat="server"></asp:Label>
                            </td>
                            <td rowspan="2" align="center" class="td_no_padding" style='text-align: center' bgcolor="#f9f9fb">
                                <asp:TextBox runat="server" ID="txtAverage3" Font-Size="Large" Width="65px" BorderStyle="None"
                                    ForeColor='blue' Style='text-align: center' CssClass="numeric-field-with-three-decimal-places costing-average lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAverage3" runat="server" Font-Size="12px"></asp:Label>
                                    <asp:FileUpload ID="LayFile3" CssClass="lay_file3 style20" runat="server" />
                                    <table width="100%" cellpadding="0" cellspacing="0" style="text-align: left; line-height: 5px;">
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcst3" runat="server" Text="CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="viewolay3" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay3"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblmarker3" runat="server" Text="Ord CAD" Style="display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewStc3" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcad3" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewCad3" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--    /*Ended by uday*/ --%>
                                </div>
                            </td>
                            <td rowspan="2" class="lightbg1" align="center">
                                <asp:TextBox runat="server" ID="txtRate3" Font-Size="Large" Width="40px" BorderStyle="None"
                                    ForeColor="black" CssClass="numeric-field-without-decimal-places costing-rate lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblRate3" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td class="hide_me lightbg1" rowspan="2">
                                <asp:TextBox runat="server" ID="txtAmount3" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAmount3" runat="server"></asp:Label></div>
                            </td>
                            <td style="padding-left: 2px" rowspan="2" class="lightbg1 hide_me" align="center">
                                <asp:TextBox ID="txtWaste3" runat="server" Width="30px" Style="color: black; pointer-events: none;"
                                    Font-Size="13px" BorderStyle="None" CssClass="costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1"
                                    MaxLength="2"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblWaste3" Style="color: black;" runat="server"></asp:Label></div>
                            </td>
                            <td align="center" rowspan="2" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtTotal3" Width="55px" Font-Size="14px" BorderStyle="None"
                                    CssClass="costing-totalFabric do-not-allow-typing lightbg1" Style="color: Black;"></asp:TextBox><br />
                                <asp:Label ID="lblTotal3" runat="server"></asp:Label>
                                <div style="padding-top: 4px;">
                                    <asp:TextBox ID="txtTotalAvgWstg3" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                        CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                        display: none; text-align: center;"></asp:TextBox></div>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ReadOnly="true" CssClass="form_small_heading_pink1" ID="txtChargesName5"
                                    Text="TEST" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName5" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue5" Style="color: Black;" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue5" runat="server"></asp:Label></div>
                            </td>
                            <td colspan="2" class="form_small_heading_pink1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem5" CssClass="form_small_heading_pink1"
                                    Text="RIBBON" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem5" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity5" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity5" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate5" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate5" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount5" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount5" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <%-- INR Values--%>
                            </td>
                            <td class="lightbg1">
                                <%--  Rs.--%>
                                <asp:TextBox runat="server" ID="txtInitCtcInInr" Width="41px" BorderStyle="None"
                                    class="costing-final-cost-ctc do-not-allow-typing currChange lightbg1" Style="color: Black;
                                    display: none;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style18">
                                <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                    <asp:Label ID="lbl3" CssClass="lblThree" Visible="false" runat="server" Text=""></asp:Label>
                                    <label id="lblprd33" class="a">
                                    </label>
                                    <input id="txtFabricType3" style="text-align: left; width: 160px;" runat="server"
                                        class="two fabric-type blue_center_text darkbg1 fab_prt3" onkeyup="test3(this)"
                                        type="text" />
                                    <input id="fab33hdn" value="yaten" type="hidden" />
                                    <input id="fab33hdn3" value="yaten" type="hidden" />
                                    <asp:TextBox ID="hdn3" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                        CssClass="threehide"></asp:TextBox>
                                    <asp:TextBox ID="hdn3Prev" runat="server" BorderStyle="None" Style="display: none;"
                                        Width="150px" CssClass="threeprev"></asp:TextBox>
                                    <br />
                                    <nobr><asp:Label ID="lblFabricType3" runat="server" CssClass=""></asp:Label>
                                    <input type="hidden" id="hidFab3Details" class="hidden-details" value="COL" runat="server" />
                                </nobr>
                                </div>
                            </td>
                            <td class="style7 lightbg1" style="text-align: center;">
                                <div class=" div_show hide_me div_show3" id="divRadioMode3">
                                    <nobr>
                                <input type="radio" name="radioMode3" value="1" class="radio_mode3 radio_mode" title="A"  checked="checked" style="font-size:8px;width:12px;height:12px" />A
                                <input type="radio" name="radioMode3" value="0" class="radio_mode3 radio_mode"  title="S" style="font-size:8px;width:12px;height:12px"/>S
                                </nobr>
                                    <asp:HiddenField runat="server" ID="hiddenRadioMode3" Value="1" />
                                </div>
                                <nobr>
                                    <img id="imgFab3a" class="imgFab" style="display:none;" src="../../Images/multipleIcon.png" alt="Multiple Prints / solids are associated with this style" title="Multiple Prints / solids are associated with this style" />
                                <asp:Image ID="imgFab3" Visible="false" ImageUrl="~/Images/multipleIcon.png" runat="server" AlternateText="Multiple Prints / solids are associated with this style" ToolTip="Multiple Prints / solids are associated with this style" />
                                 </nobr>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" CssClass="form_small_heading_pink1" ID="txtChargesName6"
                                    ReadOnly="true" Text="HANGERS" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName6" runat="server"></asp:Label></div>
                            </td>
                            <td class="style7 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue6" Style="color: Black;" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue6" runat="server"></asp:Label></div>
                            </td>
                            <td colspan="2" class="style8">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem6" CssClass="form_small_heading_pink1"
                                    Text="LACE" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem6" runat="server"></asp:Label></div>
                            </td>
                            <td class="style7 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity6" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity6" runat="server"></asp:Label></div>
                            </td>
                            <td class="style7 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate6" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate6" runat="server"></asp:Label></div>
                            </td>
                            <td class="style7 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount6" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount6" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                Currency
                            </td>
                            <td align="center" class="style7 lightbg1">
                                <asp:DropDownList ID="ddlConvTo" runat="server" Width="40px" onchange="ddlConversionFunc()"
                                    CssClass="currChange converto lightbg1" Style="color: black;" BorderStyle="None">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnConvertTo" Value="-1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="lightbg1">
                                <asp:DropDownList runat="server" ID="ddlPrintType4" class="lightbg1" BorderStyle="None">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lblPrintType4" runat="server"></asp:Label></div>
                            </td>
                            <td style="text-align: left" class="style18">
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtFabric4" MaxLength="60" runat="server" Width="220px" BorderStyle="None"
                                            CssClass="costing-fabric fabric4 blue-text darkbg1" Style="text-align: left"></asp:TextBox>
                                        <asp:Label ID="lblFabric4" runat="server"></asp:Label></div>
                                    <div style="float: left;">
                                        <nobr>
                                    <div style="float:left;">
                                        <asp:Label ID="COUNTCON4" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtCOUNTCON4" CssClass="style18" MaxLength="30" Style="display: none" runat="server"
                                            Width="220px" BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                        </div><div style="float:left;"><asp:Label ID="GSML4" runat="server" Font-Size="Smaller"></asp:Label>
                                        </div><div style="float:left;"><asp:TextBox ID="txtGSML4" MaxLength="30" Style="display: none;" CssClass="lightbg2" runat="server" Width="220px"
                                            BorderStyle="Dotted" Font-Size="Smaller"></asp:TextBox>
                                    </div></nobr>
                                    </div>
                                </div>
                            </td>
                            <td class="lightbg1">
                                <nobr>
                                <asp:Label ID="lblOrigin4" runat="server" CssClass="hid_origin"></asp:Label>&nbsp;
                                <a title="CLICK TO VIEW FABRIC QUALITY FORM" target="FabricQualityForm" id="hlkQuality4"
                                    class="hide_me" style="text-align: right;margin-right:2px" onclick="return launchFabricQualityPopup(this)">
                                    <img title="CLICK TO GO TO FABRIC QUALITY FORM" src="/App_Themes/ikandi/images/info.jpg"
                                        height="10px" width="10px" border="0" style="text-align: right;margin-right:2px"/></a>
                                </nobr>
                            </td>
                            <td rowspan="2" style="text-align: left" class="lightbg1" align="center">
                                <div class="inches">
                                    <asp:TextBox runat="server" ID="txtWidth4" Style="text-align: center; color: Black;"
                                        Font-Size="14px" Width="30px" BorderStyle="None" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches lightbg1"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblWidth4" runat="server"></asp:Label>
                            </td>
                            <td rowspan="2" class="td_no_padding" style='text-align: center' bgcolor="#f9f9fb">
                                <asp:TextBox runat="server" ID="txtAverage4" Font-Size="Large" Width="65px" BorderStyle="None"
                                    ForeColor="blue" Style='text-align: center' CssClass="numeric-field-with-three-decimal-places costing-average lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAverage4" runat="server" Font-Size="12px"></asp:Label>
                                    <asp:FileUpload ID="LayFile4" CssClass="lay_file4 style20" runat="server" />
                                    <table width="100%" cellpadding="0" cellspacing="0" style="text-align: left; line-height: 5px;">
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcst4" runat="server" Text="CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="viewolay4" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay4"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblmarker4" runat="server" Text="Odr File" Style="display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewStc4" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:Label ID="lblcad4" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"> </asp:Label>
                                            </td>
                                            <td style="font-size: 8px; margin: 0px; padding: 1px">
                                                <asp:HyperLink ID="ViewCad4" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1"
                                                    Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- /*Ended by uday*/ --%>
                                </div>
                            </td>
                            <td rowspan="2" class="lightbg1" align="center">
                                <asp:TextBox runat="server" ID="txtRate4" Font-Size="Large" Width="40px" BorderStyle="None"
                                    ForeColor="black" CssClass="numeric-field-without-decimal-places costing-rate lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblRate4" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td class="hide_me lightbg1" rowspan="2">
                                <asp:TextBox runat="server" ID="txtAmount4" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAmount4" runat="server"></asp:Label></div>
                            </td>
                            <td style="padding-left: 2px" rowspan="2" class="lightbg1 hide_me" align="center">
                                <asp:TextBox ID="txtWaste4" runat="server" Width="30px" Font-Size="13px" BorderStyle="None"
                                    Style="color: black; pointer-events: none;" CssClass="costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1"
                                    MaxLength="2"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblWaste4" Style="color: black;" runat="server"></asp:Label></div>
                            </td>
                            <td align="center" rowspan="2" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtTotal4" Width="55px" Font-Size="14px" BorderStyle="None"
                                    CssClass="costing-totalFabric do-not-allow-typing lightbg1" Style="color: Black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblTotal4" runat="server"></asp:Label></div>
                                <div style="padding-top: 4px;">
                                    <asp:TextBox ID="txtTotalAvgWstg4" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                        CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                        display: none; text-align: center;"></asp:TextBox></div>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ID="txtChargesName7" CssClass="form_small_heading_pink1"
                                    Text="CRINKLE" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName7" runat="server"></asp:Label></div>
                            </td>
                            <td class="style1 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue7" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue7" runat="server"></asp:Label></div>
                            </td>
                            <td colspan="2" class="form_small_heading_pink1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem7" ReadOnly="true" CssClass="form_small_heading_pink1"
                                    Text="HANGER LOOPS" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem7" runat="server"></asp:Label></div>
                            </td>
                            <td class="style1 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity7" Style="color: black;" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity7" runat="server"></asp:Label></div>
                            </td>
                            <td class="style1 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate7" Style="color: black;" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate7" runat="server"></asp:Label></div>
                            </td>
                            <td class="style1 lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount7" Width="100%" BorderStyle="None" Style="color: Black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount7" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg2">
                                CONV RATE
                            </td>
                            <td class="style1 lightbg1">
                                <asp:TextBox runat="server" ID="txtConvRate" Width="60px" BorderStyle="None" ForeColor="black"
                                    CssClass="costing-final-cost-ctc numeric-field-with-two-decimal-places lightbg1"
                                    Font-Size="Large"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblConvRate" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style18">
                                <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                    <asp:Label ID="lbl4" CssClass="lblFourth" Visible="false" runat="server" Text=""></asp:Label>
                                    <label id="lblprd44" class="a">
                                    </label>
                                    <input id="txtFabricType4" style="text-align: left; width: 160px;" runat="server"
                                        class="two fabric-type blue_center_text darkbg1 fab_prt4" onkeyup="test4(this)"
                                        type="text" />
                                    <input id="fab44hdn" value="yaten" type="hidden" />
                                    <input id="fab44hdn4" value="yaten" type="hidden" />
                                    <%--<input type="hidden" class="fourthhide" />
                                        <input type="hidden" class="fourthprev" />--%>
                                    <asp:TextBox ID="hdn4" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                        CssClass="fourthhide"></asp:TextBox>
                                    <asp:TextBox ID="hdn4Prev" runat="server" BorderStyle="None" Style="display: none;"
                                        Width="150px" CssClass="fourthprev"></asp:TextBox>
                                    <br />
                                    <nobr><asp:Label ID="lblFabricType4" runat="server" CssClass=""></asp:Label>
                                    <input type="hidden" id="hidFab4Details" class="hidden-details" value="COL" runat="server" />
                                 </nobr>
                                </div>
                            </td>
                            <td style="text-align: center;" bgcolor="#f9f9fb">
                                <div class=" div_show hide_me div_show4" id="divRadioMode4">
                                    <nobr>
                                <input type="radio" name="radioMode4" value="1" class="radio_mode4 radio_mode" title="A"   checked="checked" style="font-size:8px;width:12px;height:12px" />A
                                <input type="radio" name="radioMode4" value="0" class="radio_mode4 radio_mode" title="S"   style="font-size:8px;width:12px;height:12px" />S
                                </nobr>
                                    <asp:HiddenField runat="server" ID="hiddenRadioMode4" Value="1" />
                                </div>
                                <nobr>
                                   <img id="imgFab4a" class="imgFab" style="display:none;" src="../../Images/multipleIcon.png" alt="Multiple Prints / solids are associated with this style" title="Multiple Prints / solids are associated with this style" /> 
                                 <asp:Image ID="imgFab4" Visible="false" ImageUrl="~/Images/multipleIcon.png" runat="server" AlternateText="Multiple Prints / solids are associated with this style" ToolTip="Multiple Prints / solids are associated with this style" />
                                 </nobr>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ID="txtChargesName8" Text="PLACEMENT PRINT" Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox><br />
                                <asp:Label ID="lblChargesName8" runat="server"></asp:Label>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                    ID="txtChargesValue8" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesValue8" runat="server"></asp:Label></div>
                            </td>
                            <td colspan="2" class="form_small_heading_pink1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem8" CssClass="form_small_heading_pink1"
                                    Text="SHL. ADJTR." Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem8" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-quantity numeric-field-with-three-decimal-places lightbg1"
                                    ID="txtAccessoriesQuantity8" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity8" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate8" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate8" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount8" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount8" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <%--  F.C. Value--%>
                            </td>
                            <td align="center" class="lightbg1">
                                <asp:TextBox runat="server" ID="txtUnitCtcInForeignCurr" Width="60px" BorderStyle="None"
                                    CssClass="costing-final-total costing-on-unit-ctc do-not-allow-typing lightbg1"
                                    Style="color: Black; display: none;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" rowspan="7" align="center" class="td_no_padding" id="imgSampleImageUrldemo"
                                style="width: 400px;">
                                <table style="height: 315px; width: 100%;" cellpadding="0px" cellspacing="0px" id="imgSampleImageUrldemoTable">
                                    <tr>
                                        <td align="center" valign="top">
                                            <a class="sample-image">
                                                <img id="imgSampleImageUrl1" runat="server" src="../../App_Themes/ikandi/images/preview.png"
                                                    style="height: 315px; max-width: 90%; border: none" />
                                            </a>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td align="right">
                                            <asp:Label ID="lbltech" runat="server" Visible="false" Text="Tech Packs"></asp:Label>
                                            <asp:HyperLink ID="lnktackpack" ToolTip="VIEW TECH FILE" Visible="false" runat="server"
                                                Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""><span>Tech file</span> </asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="3" rowspan="2" align="center" style="vertical-align: top" class="td_no_padding lightbg1"
                                id="imgPrintTd">
                                <table class="costing-print-table" id="costing_print_table">
                                    <tr>
                                        <td style="padding: 2px 0px 0px 0px">
                                            <div>
                                                <a title="Click to view enlarged image" class="thickbox" href="/App_Themes/ikandi/images/preview.png">
                                                    <img id="imgPrint" src="../../App_Themes/ikandi/images/preview.png" style="height: 50px;
                                                        border: none" class="costing-print-image" /></a>
                                            </div>
                                            <div>
                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId" runat="server"
                                                    CssClass="costing-print do-not-allow-typing lightbg1" BorderStyle="None" Width="40px"
                                                    Style="text-align: left"></asp:TextBox>
                                                </span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ID="txtChargesName9" Font-Size="12px" Text="HAND EMB."
                                    Width="100%" BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName9" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <nobr>
                                <asp:TextBox runat="server" ID="txtChargesValue9" Width="73%"  Font-Size="12px" BorderStyle="None"
                                    CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                                    <img alt='' title="CLICK TO GO TO HAND EMBELLISHMENT REPORT" src="/App_Themes/ikandi/images/form.png"
                                    height="10px" width="10px" border="0" onclick="showEmbellishmentReport(3)" />
                                  </nobr>
                                <div>
                                    <asp:Label ID="lblChargesValue9" runat="server" Font-Size="12px"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem9" Text="EMB. MATRL." Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem9" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <asp:DropDownList runat="server" ID="ddlAccessoriesPercent1" Width="60px" BorderStyle="None"
                                    CssClass="form_small_heading_pink1" onchange="CalculateAccessoriesTotal(9);"
                                    ForeColor="Black">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="A + 2%" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="B + 10%" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="C + 20%" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="D + 30%" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="E + 35%" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="F + 50%" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="G + 60%" Value="60"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" ID="txtAccessoriesQuantity9" Width="100%" BorderStyle="None"
                                    CssClass=" costing-accessories-quantity numeric-field-with-surendra-decimal-places lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity9" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate9" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate9" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing"
                                    ID="txtAccessoriesAmount9" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount9" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <div class="style9">
                                    Profit</div>
                            </td>
                            <td class="form_small_heading_green td_no_padding" style="font-size: large" align="center"
                                bgcolor="#99CC00">
                                <asp:TextBox runat="server" onkeypress="Javascript:return isNumberKey(event);" onchange="javascript:return MinProfitRollback();"
                                    ID="txtMarkupOnUnitCtc" Width="50px" BorderStyle="None" CssClass="form_small_heading_green costing-final-total costing-landed-costing-percent"
                                    Style="text-align: right; font-size: 14px; color: black;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblMarkupOnUnitCtc" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lightbg2">
                                <asp:TextBox runat="server" ID="txtChargesName10" Text="MACHINE EMB." Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblChargesName10" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <nobr>
                                <asp:TextBox runat="server" ID="txtChargesValue10" Width="73%" BorderStyle="None"
                                    CssClass=" costing-charges-value numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                                  <img alt='' title="CLICK TO GO TO MACHINE EMBELLISHMENT REPORT" src="/App_Themes/ikandi/images/form.png"
                                    height="10px" width="10px" border="0" onclick="showEmbellishmentReport(6)" />
                                    </nobr>
                                <asp:Label ID="lblChargesValue10" runat="server"></asp:Label>
                            </td>
                            <td class="form_small_heading_pink1">
                                <asp:TextBox runat="server" ID="txtAccessoriesItem10" Text="EMB. MATRL." Width="100%"
                                    BorderStyle="None" CssClass="form_small_heading_pink1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesItem10" runat="server"></asp:Label></div>
                            </td>
                            <td class="form_small_heading_pink1">
                                <asp:DropDownList runat="server" ID="ddlAccessoriesPercent2" Width="60px" BorderStyle="None"
                                    CssClass="form_small_heading_pink1" onchange="CalculateAccessoriesTotal(10);"
                                    ForeColor="Black">
                                    <asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="A + 2%" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="B + 10%" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="C + 20%" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="D + 30%" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="E + 35%" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="F + 50%" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="G + 60%" Value="60"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" ID="txtAccessoriesQuantity10" Width="100%" BorderStyle="None"
                                    CssClass=" costing-accessories-quantity numeric-field-with-surendra-decimal-places lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesQuantity10" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-rate numeric-field-with-two-decimal-places lightbg1"
                                    ID="txtAccessoriesRate10" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesRate10" runat="server"></asp:Label></div>
                            </td>
                            <td class="lightbg1">
                                <asp:TextBox runat="server" CssClass="costing-accessories-amount do-not-allow-typing lightbg1"
                                    ID="txtAccessoriesAmount10" Width="100%" BorderStyle="None"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblAccessoriesAmount10" runat="server"></asp:Label></div>
                            </td>
                            <td>
                                Commission
                            </td>
                            <td class="lightbg1" align="center">
                                <asp:TextBox runat="server" ID="txtComm" Style="color: black;" Width="45px" BorderStyle="None"
                                    CssClass="costing-final-total costing-on-unit-ctc numeric-field-with-decimal-places costing-landed-costing-percent lightbg1"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblComm" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr class="costing_row">
                            <td colspan="3" class="black_center_text td_no_padding lightbg1">
                                <div>
                                    <span style="font-size: 15px">TOTAL (A) = Rs.</span>
                                    <asp:TextBox runat="server" ID="txtTotalA" Width="30%" Font-Size="16px" BorderStyle="None"
                                        CssClass="text_align_left  costing-total-abc do-not-allow-typing lightbg1" Style="color: Black !Important;"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblTotalA" runat="server"></asp:Label>
                            </td>
                            <td class="black_center_text td_no_padding" colspan="2" bgcolor="#f9f9fb">
                                <div>
                                    <span style="font-size: 15px">TOTAL (B) = Rs.</span>
                                    <asp:TextBox runat="server" ID="txtTotalB" Width="30%" Font-Size="16px" BorderStyle="None"
                                        CssClass="text_align_left  costing-total-abc do-not-allow-typing lightbg1" Style="color: Black !Important;"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblTotalB" runat="server"></asp:Label>
                            </td>
                            <td class="black_center_text td_no_padding" colspan="5" bgcolor="#f9f9fb">
                                <div>
                                    <span style="font-size: 15px">TOTAL (C) = Rs.</span>
                                    <asp:TextBox runat="server" ID="txtTotalC" Width="30%" Font-Size="16px" BorderStyle="None"
                                        CssClass="text_align_left  costing-total-abc do-not-allow-typing lightbg1" Style="color: Black !Important;"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblTotalC" runat="server"></asp:Label>
                            </td>
                            <td class="form_small_heading_pink1 big_bold_heading">
                                TOTAL
                            </td>
                            <td class="td_no_padding lightbg1" style="font-size: large; color: #000000;" align="center">
                                <asp:TextBox runat="server" ID="txtTotal" Width="70%" BorderStyle="None" CssClass="do-not-allow-typing lightbg1"
                                    Font-Size="Large" Style="text-align: left; color: #000000;"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr class="costing_row">
                            <td colspan="10" class="lightbg1 big_bold_heading" style="text-align: center">
                                OVERALL COMMENTS <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenTechfiles(this);'
                                    style="cursor: pointer; float: right; width: auto;">
                                    <asp:Label ID="lbltechFile" runat="server" ToolTip="T Pack file" Style="color: Gray;"
                                        Text="T-Pack"></asp:Label></a>
                                <div style="font-size: 8px; font-weight: normal; text-align: center; vertical-align: bottom">
                                    This cost is only valid for core styles versions on sizes 4-18. For larger sizes
                                    the prices will be higher.</div>
                                <%-- 
                          <asp:HiddenField runat="server" ID="hdnCostingId" />--%>
                                <%-- <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenTechfiles(this);' style="cursor:pointer;"><asp:Label ID="lbltechFile" runat="server" ToolTip="T pech file" style="color:Gray;" Text="t-pack"></asp:Label></a>--%>
                            </td>
                            <td class="lightbg2">
                                PRICE QUOTED
                            </td>
                            <td class="form_small_heading_yellow red_center_text td_no_padding" align="center"
                                bgcolor="#FFFFAA">
                                <asp:TextBox ID="txtPriceQuoted" runat="server" BorderStyle="None" Width="70%" Style="text-align: left"
                                    CssClass='<%# (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.COSTING_PRICE_QUOTED))
                                    ? "form_small_heading_yellow costing-price-quoted red_center_text costing-landed-costing-penny costing-on-unit-ctc numeric-field-with-two-decimal-places currChange" : "form_small_heading_yellow costing-price-quoted red_center_text costing-landed-costing-penny costing-on-unit-ctc numeric-field-with-two-decimal-places do-not-allow-typing currChange" %>'></asp:TextBox>
                                <div>
                                    <asp:HiddenField ID="hdnPriceQuoted" Value="0" runat="server" />
                                    <asp:Label ID="lblPriceQuoted" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr class="costing_row">
                            <td colspan="10" rowspan="2" class="lightbg1">
                                <div style="height: 40px ! important; overflow: auto; width: 100% ! important;" class="lightbg1">
                                    <asp:Label ID="lblOverallCommentsHistory" Style="font-size: 10px; font-weight: bold;
                                        font-family: Verdana;" runat="server"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="txtOverallComments" TextMode="MultiLine" Rows="3"
                                    Width="99%" BorderStyle="None" CssClass="form_small_heading_yellow" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td class="lightbg2">
                                LAST ORDER PRICE
                            </td>
                            <td class="form_small_heading_green td_no_padding" style="font-size: large; text-align: center"
                                align="center" bgcolor="#99CC00">
                                <asp:TextBox runat="server" ID="txtPriceAgreed" Width="85%" BorderStyle="None" CssClass="form_small_heading_green costing-on-unit-ctc costing-percentage-profit do-not-allow-typing costing-landed-costing-penny numeric-field-with-two-decimal-places currChange"
                                    Style="font-size: large; text-align: left; color: Black !important;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="costing_row">
                            <td class="lightbg2">
                                <div class="style9">
                                    Actual Profit</div>
                            </td>
                            <td class="background_orange_style td_no_padding" style="font-size: large; text-align: center"
                                align="center">
                                <asp:TextBox runat="server" ID="txtOnUnitCtcInFc" Width="60px" BorderStyle="None"
                                    CssClass="background_orange_style costing-percentage-profit do-not-allow-typing costing-landed-costing-penny_black"
                                    Style="font-size: large; color: Black !important; height: 20px; padding: 0;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="costing_row">
                            <td align="center" class="form_small_heading_pink1" colspan="2">
                                DESIGNED BY
                            </td>
                            <td colspan="2" align="center" class="costing-designer lightbg1" id="tdDesigner"
                                runat="server">
                            </td>
                            <td align="center" class="form_small_heading_pink1" colspan="1">
                                TARGET PRICE
                            </td>
                            <td colspan="2" align="center" class="costing-target-price numeric-field-with-two-decimal-places lightbg1"
                                id="tdTargetPrice" runat="server" style="font-size: 14px; color: Black !important;">
                            </td>
                            <td colspan="3" class="blue_center_text" bgcolor="#f9f9fb">
                                <asp:Label runat="server" Style="cursor: pointer" ID="lblFitsStatus"></asp:Label>
                                <asp:TextBox runat="server" ID="txtComments" Width="100%" BorderStyle="None" Text="Comments"
                                    CssClass="water-mark hide_me" Style="text-align: left"></asp:TextBox>
                            </td>
                            <td class="lightbg2">
                                PRECENTAGE PROFIT
                            </td>
                            <td class="form_small_heading_green td_no_padding" style="font-size: large; text-align: center"
                                align="center" bgcolor="#99CC00">
                                <asp:TextBox runat="server" ID="txtPercentageProfit" Width="50px" BorderStyle="None"
                                    CssClass="form_small_heading_green do-not-allow-typing costing-landed-costing-percent"
                                    Style="font-size: large; color: Black !important;"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table border="0" width="100%" class="form_table">
                    <tbody>
                        <tr>
                            <td width="100%" valign="top">
                                <asp:HiddenField ID="hdnSave" Value="0" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnClientCostingSave" Value="0" runat="server"></asp:HiddenField>
                                <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:return SAM();"
                                    Text="Save" OnClick="btnSave_Click" CssClass="save do-not-print da_submit_button" />
                                &nbsp;
                                <asp:Button ID="btnUpdatePrice" Visible="false" runat="server" Text="Update Order Price"
                                    OnClientClick="return confirm('Are you sure to update the price on orders?')"
                                    OnClick="btnBIPLUpdatePrice_Click" CssClass="update_order_price do-not-print da_submit_button" />
                                &nbsp;
                                <asp:Button runat="server" ID="btnBIPLHistory" CssClass="history do-not-print da_submit_button"
                                    Text="History" OnClientClick="showHistory( this, 'divBIPLHistory'); return false;" />
                                &nbsp;
                                <asp:Button runat="server" ID="btnExportToExcel" CssClass="exporttoexcel da_submit_button"
                                    Text="Export To Excel" OnClick="btnExportToExcel_Click" OnClientClick="JavaScript:return ExportToExcel()"
                                    Visible="true" />
                                &nbsp;
                                <asp:Button runat="server" ID="btnBIPLPrint" class="print do-not-print da_submit_button"
                                    Text="Print" OnClientClick="window.print(); return false;" />
                                &nbsp;
                                <asp:Button ID="btnCostConfirmation" Visible="false" runat="server" Text="Request Cost Confirmation"
                                    OnClientClick="return confirm('Are you sure you want to send request to confirm the price?')"
                                    OnClick="btnCostConfirmation_Click" CssClass="request_cost_confirmation do-not-print da_submit_button" />
                                &nbsp;
                                <asp:Button ID="btnAcknowledgment" Style="display: none;" runat="server" Text="Acknowledgement Confirm"
                                    CssClass="ucknowledgment_confirmation do-not-print da_submit_button" OnClick="btnAcknowledgment_Click" />
                                <asp:Label runat="server" ID="lblCostConfirmationRequestText" Visible="false "></asp:Label>
                                <asp:RadioButton ID="radioBtnAgree" runat="server" onclick="EnableAgree();" Text="I have understood that the price has been agreed upon by both BIPL and iKandi" />
                                <asp:Button ID="btnAgree" runat="server" OnClick="btnAgree_Click" CssClass="agree da_submit_button"
                                    Text="Agree" Enabled="false" />
                                <asp:Button ID="btnDisagree" runat="server" OnClick="btnDisagree_Click" CssClass="disagree da_submit_button"
                                    Text="Disagree" />
                                <!------------new-changes-16-may-17------------>
                                <asp:CheckBox runat="server" Visible="false" ID="chkverifiedCosting" Text="Verified Costing"
                                    Font-Bold="true" />
                                <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenPairingCosting(this);'
                                    style="cursor: pointer; width: auto; text-decoration: none;">
                                    <asp:Label ID="lblPairedCosting" Style="text-transform: capitalize" runat="server"
                                        Font-Bold="true"></asp:Label>
                                </a>
                                <!---------------------------end-of-new------------------->
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <br />
        <div id="divIKandi" runat="server" class="form_box">
            <div class="form_heading">
                IKANDI COSTING SHEET</div>
            <table bordercolor="#000000" border="1" width="100%" cellspacing="0px" class="form_table">
                <tbody>
                    <tr>
                        <td width="10%" class="form_small_heading_pink1">
                            Boutique Price:
                        </td>
                        <td width="15%" class="blue_center_text lightbg1">
                            <asp:TextBox ID="txtFOBBoutique" runat="server" Width="50%" Style="text-align: left;
                                margin-left: 3px" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td width="20%" class="form_small_heading_pink1">
                            Target Boutique Price:
                        </td>
                        <td width="15%" class="blue_center_text lightbg1">
                            <asp:TextBox ID="txtTargetFOBPrice" runat="server" Width="50%" Style="text-align: left;
                                margin-left: 3px" CssClass="lightbg1 costing-landed-costing-grand-total1 costing-landed-costing-grand-total2 costing-landed-costing-grand-total3 costing-landed-costing-grand-total4 costing-landed-costing-grand-total-fob numeric-field-with-two-decimal-places costing-landed-costing-penny"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table bordercolor="#000000" border="1" width="100%" cellspacing="0px" class="form_table"
                id="tblLandedCosting">
                <tbody>
                    <tr>
                        <td colspan="17">
                            <strong class="form_small_heading_design">Landed Costing</strong>
                        </td>
                    </tr>
                    <tr class="blackBg ">
                        <th class="lightbluebgcolor">
                            Mode
                        </th>
                        <th class="lightbluebgcolor">
                            BIPL Price
                        </th>
                        <th class="lightbluebgcolor">
                            iKandi Price
                        </th>
                        <th class="lightbluebgcolor">
                            Mode Cost
                        </th>
                        <th class="lightbluebgcolor">
                            Duty
                        </th>
                        <th class="lightbluebgcolor">
                            Handling
                        </th>
                        <th class="lightbluebgcolor">
                            Delivery
                        </th>
                        <th class="lightbluebgcolor">
                            Process
                        </th>
                        <th class="lightbluebgcolor">
                            Margin
                        </th>
                        <th class="lightbluebgcolor">
                            Disc.
                        </th>
                        <th class="lightbluebgcolor">
                            Calc. Total
                        </th>
                        <th class="lightbluebgcolor">
                            Quoted
                        </th>
                        <th class="lightbluebgcolor">
                            Agreed
                        </th>
                        <th class="lightbluebgcolor">
                            Lead Time
                        </th>
                        <th class="lightbluebgcolor">
                            Exp. Book Date
                        </th>
                        <th class="lightbluebgcolor">
                            Calc. Del. Date
                        </th>
                        <th class="lightbluebgcolor">
                        </th>
                    </tr>
                    <tr>
                        <td class="lightbluebgcolor">
                            <nobr> L-A/F (FOB)</nobr>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFFobBoutique" Width="50%" BorderStyle="None"
                                Style="color: Black;" CssClass="costing-landed-costing-penny costing-fob-boutique-price do-not-allow-typing lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFFobIkandi" Width="50%" BorderStyle="None" Style="color: Black;"
                                CssClass="costing-landed-costing-penny costing-landed-costing-fob-ikandi numeric-field-with-two-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFModeCost" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFDuty" Width="50%" BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total1 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFHandling" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFDelivery" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFProcessing" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFMargin" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total1 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFDiscount" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total1 costing-landed-costing-discount lightbg1"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_pink">
                            <asp:TextBox runat="server" ID="txtAFGrandTotal" Width="50%" BorderStyle="None" CssClass="form_small_heading_pink do-not-allow-typing costing-landed-costing-penny"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_yellow ikandi_price">
                            <asp:TextBox runat="server" ID="txtAFQuotedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_green ikandi_price">
                            <asp:TextBox runat="server" ID="txtAFAgreedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFModeDelivery" Width="100%" BorderStyle="None"
                                CssClass="costing-landed-costing-mode-delivery-time numeric-field-without-decimal-places date_style lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFExpectedBookingDate" CssClass="date-picker costing-landed-costing-expected-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAFCalculatedDeliveryDate" CssClass="date-picker costing-landed-costing-delivery-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:CheckBox runat="server" ID="ckhAF" TextAlign="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lightbluebgcolor">
                            <nobr>L-A/H (FOB)</nobr>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHFobBoutique" Width="50%" BorderStyle="None"
                                Style="color: Black;" CssClass="costing-fob-boutique-price do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHFobIkandi" Width="50%" Style="color: Black;"
                                BorderStyle="None" CssClass="costing-landed-costing-fob-ikandi numeric-field-with-two-decimal-places do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHModeCost" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total2 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHDuty" Width="50%" BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total2 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHHandling" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total2 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHDelivery" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total2 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHProcessing" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total2 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHMargin" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total2 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHDiscount" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total2 costing-landed-costing-discount lightbg1"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_pink">
                            <asp:TextBox runat="server" ID="txtAHGrandTotal" Width="50%" BorderStyle="None" CssClass="form_small_heading_pink do-not-allow-typing costing-landed-costing-penny "></asp:TextBox>
                        </td>
                        <td class="form_small_heading_yellow ikandi_price">
                            <asp:TextBox runat="server" ID="txtAHQuotedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_green ikandi_price">
                            <asp:TextBox runat="server" ID="txtAHAgreedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHModeDelivery" Width="100%" BorderStyle="None"
                                CssClass="costing-landed-costing-mode-delivery-time numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHExpectedBookingDate" CssClass="date-picker costing-landed-costing-expected-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtAHCalculatedDeliveryDate" CssClass="date-picker costing-landed-costing-delivery-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:CheckBox runat="server" ID="chkAH" TextAlign="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lightbluebgcolor">
                            <nobr> L-S/F (FOB)</nobr>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFFobBoutique" Width="50%" BorderStyle="None"
                                Style="color: Black;" CssClass="costing-fob-boutique-price do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFFobIkandi" Style="color: Black;" Width="50%"
                                BorderStyle="None" CssClass="costing-landed-costing-fob-ikandi numeric-field-with-two-decimal-places do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFModeCost" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total3 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFDuty" Width="50%" BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total3 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFHandling" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total3 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFDelivery" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total3 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFProcessing" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total3 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFMargin" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total3 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFDiscount" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total3 costing-landed-costing-discount lightbg1"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_pink">
                            <asp:TextBox runat="server" ID="txtSFGrandTotal" Width="50%" BorderStyle="None" CssClass="form_small_heading_pink do-not-allow-typing costing-landed-costing-penny"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_yellow ikandi_price">
                            <asp:TextBox runat="server" ID="txtSFQuotedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_green ikandi_price">
                            <asp:TextBox runat="server" ID="txtSFAgreedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFModeDelivery" Width="100%" BorderStyle="None"
                                CssClass="costing-landed-costing-mode-delivery-time numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFExpectedBookingDate" CssClass="date-picker costing-landed-costing-expected-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSFCalculatedDeliveryDate" CssClass="date-picker costing-landed-costing-delivery-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:CheckBox runat="server" ID="ckhSF" TextAlign="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lightbluebgcolor">
                            <nobr>L-S/H (FOB)</nobr>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHFobBoutique" Width="50%" BorderStyle="None"
                                Style="color: Black;" CssClass="costing-fob-boutique-price do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHFobIkandi" Width="50%" BorderStyle="None" Style="color: Black;"
                                CssClass="costing-landed-costing-fob-ikandi numeric-field-with-two-decimal-places do-not-allow-typing costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHModeCost" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total4 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHDuty" Width="50%" BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total4 lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHHandling" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total4 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHDelivery" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total4 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHProcessing" Width="50%" BorderStyle="None" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total4 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHMargin" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total4"
                                lightbg1></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHDiscount" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total4 costing-landed-costing-discount lightbg1"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_pink">
                            <asp:TextBox runat="server" ID="txtSHGrandTotal" Width="50%" BorderStyle="None" CssClass="form_small_heading_pink do-not-allow-typing costing-landed-costing-penny"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_yellow ikandi_price">
                            <asp:TextBox runat="server" ID="txtSHQuotedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_green ikandi_price">
                            <asp:TextBox runat="server" ID="txtSHAgreedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHModeDelivery" Width="100%" BorderStyle="None"
                                CssClass="costing-landed-costing-mode-delivery-time numeric-field-without-decimal-places lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHExpectedBookingDate" CssClass="date-picker costing-landed-costing-expected-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtSHCalculatedDeliveryDate" CssClass="date-picker costing-landed-costing-delivery-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:CheckBox runat="server" ID="ckhSH" TextAlign="Left" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table bordercolor="#000000" border="1" class="form_table" width="100%" cellspacing="0px"
                id="tblFOBPricing">
                <tbody>
                    <tr>
                        <td colspan="10">
                            <strong class="form_small_heading_design">DIRECT COSTING</strong>
                        </td>
                    </tr>
                    <tr>
                        <th class="lightbluebgcolor">
                            BIPL Price
                        </th>
                        <th class="lightbluebgcolor">
                            Haulage Charges
                        </th>
                        <th class="lightbluebgcolor">
                            IKandi Margin
                        </th>
                        <th class="lightbluebgcolor">
                            Disc.
                        </th>
                        <th class="lightbluebgcolor">
                            Calc. Total
                        </th>
                        <th class="lightbluebgcolor">
                            Quoted
                        </th>
                        <th class="lightbluebgcolor">
                            Agreed
                        </th>
                        <th class="lightbluebgcolor">
                            Lead Time
                        </th>
                        <th class="lightbluebgcolor">
                            Exp. Book Date
                        </th>
                        <th class="lightbluebgcolor">
                            Cal. Del. Date
                        </th>
                        <th class="lightbluebgcolor">
                        </th>
                    </tr>
                    <tr>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBDelhi" Style="color: Black;" Width="50%" BorderStyle="None"
                                CssClass="costing-fob-boutique-price do-not-allow-typing  costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtHaulageCharges" Width="50%" BorderStyle="None"
                                CssClass="costing-landed-costing-grand-total-fob numeric-field-with-two-decimal-places costing-landed-costing-penny lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBIkandiMargin" Width="50%" BordeStyle="None"
                                CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total-fob lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBDiscount" Width="50%" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total-fob lightbg1"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_pink" bgcolor="#F9DDF4">
                            <asp:TextBox runat="server" ID="txtFOBGrandTotal" Width="50%" BorderStyle="None"
                                CssClass="form_small_heading_pink do-not-allow-typing costing-landed-costing-penny"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_yellow ikandi_price" bgcolor="#FFFFAA">
                            <asp:TextBox runat="server" ID="txtFOBQuotedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny span.penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="form_small_heading_green ikandi_price" bgcolor="#99CC00">
                            <asp:TextBox runat="server" ID="txtFOBAgreedPrice" Width="80%" BorderStyle="None"
                                CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny span.penny ikandi_price"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBModeDelivery" Text="11" Width="100%" BorderStyle="None"
                                CssClass="costing-landed-costing-mode-delivery-time numeric-field-without-decimal-places date_style lightbg1"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBBookingDate" CssClass="date-picker costing-landed-costing-expected-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:TextBox runat="server" ID="txtFOBDeliveryDate" CssClass="date-picker costing-landed-costing-delivery-date date_style lightbg1"
                                Width="110px" BorderStyle="None"></asp:TextBox>
                        </td>
                        <td class="lightbg1">
                            <asp:CheckBox runat="server" ID="ckhFOB" TextAlign="Left" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table border="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnSaveIkandi" runat="server" OnClick="btnSaveIkandi_Click" Text="Save"
                                CssClass="da_submit_button save do-not-print" ValidationTarget="costing_form" />
                            <%--OnClientClick="CheckIfBIPLValuesChanged()"--%>
                            &nbsp;
                            <asp:Button Text="PRICING MO" Visible="false" ID="hyPricing" CssClass="da_submit_button hyPricing"
                                runat="server" />
                            &nbsp;
                            <asp:Button ID="btnCostConfirmed" Text="Cost Confirmed" runat="server" OnClientClick="return openCostConfirmationPopup()"
                                CssClass="da_submit_button cost_confirmed do-not-print" />
                            &nbsp;
                            <asp:Button ID="btniKandiUpdatePrice" runat="server" OnClick="btniKandiUpdatePriceUpdatePrice_Click"
                                Text="Update Order Price" CssClass="da_submit_button update_order_price do-not-print btniKandiUpdatePrice" />
                            &nbsp;
                            <asp:Button runat="server" ID="btniKandiHistory" CssClass="da_submit_button history"
                                Text="History" OnClientClick="showHistory( this, 'diviKandiHistory'); return false;" />
                            &nbsp;
                            <input type="button" id="btnPrint" class="da_submit_button print do-not-print do-not-disabled"
                                value="Print" onclick="return PrintPDF();" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div id="diviKandiHistory" class="hide_me">
        <div style="height: 300px !important; width: 500px; overflow: auto; border: 1px solid black;
            padding: 0px; margin-bottom: 15px;">
            <div class="form_heading">
                History</div>
            <br />
            <div>
                <table width="100%" cellpadding="6px">
                    <tr>
                        <td style="width: 100%;">
                            <asp:Label ID="lbliKandiHistory" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divBIPLHistory" class="hide_me">
        <div style="height: 300px !important; width: 500px; overflow: auto; border: 1px solid black;
            padding: 0px; margin-bottom: 15px;">
            <div class="form_heading">
                History</div>
            <br />
            <div>
                <table width="100%" cellpadding="6px">
                    <tr>
                        <td style="width: 100%;">
                            <asp:Label ID="lblBIPLHistory" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divCommentsHistory" class="divCommentsHistory">
        <div class="form_box" style="height: 190px !important; width: 582px; overflow: auto">
            <div class="form_heading">
                Overall Comments History</div>
            <br />
            <div>
                <div runat="server" id="hdnComments">
                </div>
            </div>
        </div>
    </div>
    <div id="divCostConfirmation" class="divCostConfirmation">
        <div class="form_box">
            <div class="form_heading">
                Cost Confirmation</div>
            <br />
            <table width="90%" style="height: 180px ! important; overflow: auto;" cellpadding="6px">
                <tr>
                    <td style="width: 30%; vertical-align: top;">
                        Action
                    </td>
                    <td style="width: 70%; vertical-align: top">
                        <asp:RadioButton runat="server" ID="rdAccept" Text="Accept" Checked="true" GroupName="CostConfirmation" />
                        <asp:RadioButton ID="rdDecline" GroupName="CostConfirmation" runat="server" Text="Decline" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        Comments :
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox Width="100%" Rows="5" TextMode="MultiLine" runat="server" ID="txtCostConfirmationComments"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div align="center">
                <asp:Button runat="server" Text="Submit" ID="btnCostConfirmationPopup" class="submit"
                    OnClick="btnCostConfirmed_Click" />
                <input type="button" class="da_submit_button close do-not-disable" value="Close"
                    onclick="closeCostConfirmationPopup()" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfexcelval" Visible="true" runat="server" />
    <div id="divhfexcelval" visible="false" />
    <%--<asp:HiddenField ID="hiddenIsBIPLValuesChanged" runat="server" />--%>
    <asp:Literal ID="lit" runat="server" />
    <table id="temptable" border="1" visible="false">
    </table>
    <asp:Label ID="hiddenCostingSheetHeight" runat="server" CssClass="costing-sheet-height hide_me" />
</div>
<div id="PendingCostingMsg" runat="server" visible="false">
    <br />
    <br />
    BIPL Costing is pending for this style.
</div>
<script type="text/javascript">
    $("#<%=hypBooked.ClientID%>").click(function () {
        var stylecode = $("#<%=hdStyleCOdeValue.ClientID%>").val();
        var url = '../Production/ProductionPlanningMatrix.aspx?OrderDetailId=-1' + '&StyleCode=' + stylecode;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 500, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    });
</script>
<%--<div id="AllContractDiv" style="width:1000px; height:500px;">


      <uc1:AllOrderOnStyleNew ID="AllOrderOnStyleNew1" runat="server" />

        <asp:Button ID="btnAllContract" CssClass="btnAllContract" runat="server" Text="Save" 
            />
     
</div>--%>
