<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCForm.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.QCForm" %>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;
    var lblQtyChecked;
    var lblSize;
    var divCount = 0;
    var ddlProcessingInstructionsClientID = '<%=ddlProcessingInstructions.ClientID %>';

    $(function () {
        // added by yaten
        $(".loadingimage").hide();
        var d1 = new Date();
        //$("FORM").validate();
        debugger;
        var divFaults = $("#divFaults", "#main_content");
        if (jscriptPageVariables != null && jscriptPageVariables.faults != null && jscriptPageVariables.faults != '') {
            divFaults.setTemplateElement("templateFault");
            divFaults.setParam('x', 1);
            divFaults.processTemplate(jscriptPageVariables.faults);
        }


        if (jscriptPageVariables != null && jscriptPageVariables.qualityFault != null && jscriptPageVariables.qualityFault != '') {
            if (jscriptPageVariables.qualityFault.table != null) {
                divCount = jscriptPageVariables.qualityFault.table.length;
                for (var i = 0; i < jscriptPageVariables.qualityFault.table.length; i++) {
                    var divFaults = $("#divFaults" + (parseInt(i) + 1).toString(), "#main_content");
                    if (jscriptPageVariables.qualityFault.table[i] != null && jscriptPageVariables.qualityFault.table[i].length > 0) {
                        divFaults.setTemplateElement("templateFault1");
                        divFaults.setParam('x', 1);
                        divFaults.setParam('y', i + 1);
                        divFaults.processTemplate(jscriptPageVariables.qualityFault.table[i]);
                    }
                }
            }
        }

        for (var j = 1; j <= divCount; j++) {

            var tableFaults1Rows = $("#tableFaults1 tr", "#divFaults" + j);
            var rowCount = tableFaults1Rows.length - 1;

            for (var i = 1; i <= rowCount; i++) {

                onDesc1Change(i, j);
            }
            onOccurrenceChange(rowCount, "#divFaults" + j);

            calcQtyChecked(j);

            getStatus("#divPart" + j, j, true);
        }

        var rowCountR = $("#tableFaults tr", "#main_content").length - 1;

        for (var i = 1; i <= rowCountR; i++) {
            $('#faultDesc' + i, "#main_content").change(function () {
                var objRow = $(this).parents("tr");
                var rowindex = objRow.get(0).rowIndex;
                onDescChange(rowindex);
            });
            onDescChange(i);
        }

        $("#" + ddlProcessingInstructionsClientID).change(function () {
            var index = this.selectedIndex;
            if ((this.options[index].value) == 4) {
                $('#<%=txtOtherProcessingInstruction.ClientID %>', '#main_content').removeAttr('disabled');
            }
            else {
                $('#<%=txtOtherProcessingInstruction.ClientID %>', '#main_content').attr('disabled', 'disabled');
            }
        });
    });

    function OnFaultChange(src) {
        /// 
        objDivId = $(src).parents("div").attr("id");
        rowCount = $("#tableFaults1 tr", "#" + objDivId).length - 1;
        var objRow = $(src).parents("tr");
        var rowindex = objRow.get(0).rowIndex;




        var count = 0;
        if (objDivId != null && objDivId != '') {
            count = objDivId.split('s');
            if (parseInt(count[1]) > 0 && parseInt(count[1]) <= divCount)
                onDesc1Change(rowindex, count[1]);
            onOccurrenceChange(rowCount, "#" + objDivId);
        }
    }

    function OnFaultCountChange(src) {
        //   //yaten
        objDivId = $(src).parents("div").attr("id");
        rowCount = $("#tableFaults1 tr", "#" + objDivId).length - 1;
        onOccurrenceChange(rowCount, "#" + objDivId);
    }

    function getStatus(parentDivId, index, isLoad) {
        //  
        var objCriticalActual;
        var objMajorActual;
        var objMinorActual;
        var criticalAllowed = 0;
        var majorAllowed = 0;
        var minorAllowed = 0;
        var lblStatus;

        if (parentDivId != null && parentDivId != '' && parentDivId != undefined) {
            majorAllowed = $('#lblMajorAllowed', parentDivId).val();
            criticalAllowed = $('#lblCriticalAllowed', parentDivId).val();
            minorAllowed = $('#lblMinorAllowed', parentDivId).val();

            objMajorActual = $('#lblMajorActual', parentDivId);
            objCriticalActual = $('#lblCriticalActual', parentDivId);
            objMinorActual = $('#lblMinorActual', parentDivId);

            lblStatus = $('#lblStatus', parentDivId);
            var objHdnStatus = $('#hiddenStatus' + index);
            //var objhdnRadioStatus = $('#hdnRadioStatus' + index);
            var objhdnRadioStatus = $('.hidden_status' + index);

            if (isLoad) {
                if (objHdnStatus.val() != undefined && objHdnStatus.val() != null && objHdnStatus.val() != '') {
                    (lblStatus.val(objHdnStatus.val()));

                    var radio_status = $('.radio_status' + index);
                    if (objHdnStatus.val() == "PASS") {
                        objhdnRadioStatus.val("1");
                        if (radio_status.length > 0)
                            radio_status[0].checked = true;
                        ($('.status' + index, "#main_content").css('backgroundColor', '#01cc01'));
                    }
                    else if (objHdnStatus.val() == "FAIL") {
                        objhdnRadioStatus.val("2");
                        if (radio_status.length > 0)
                            radio_status[1].checked = true;
                        ($('.status' + index, "#main_content").css('backgroundColor', '#FF0000'));
                    }
                    else {
                        objhdnRadioStatus.val("");
                        (lblStatus.val(""));
                        radio_status[0].checked = false;
                        radio_status[1].checked = false;
                        ($('.status' + index, "#main_content").css('backgroundColor', 'ffffff'));
                    }

                }
            }
            else {

                if (((parseInt(objMajorActual.val())) == 0) &&
                ((parseInt(objMinorActual.val())) == 0) &&
                ((parseInt(objCriticalActual.val())) == 0)
              ) {
                    var radio_status = $('.radio_status' + index);

                    (lblStatus.val(""));
                    radio_status[0].checked = false;
                    radio_status[1].checked = false;
                    ($('.status' + index, "#main_content").css('backgroundColor', 'ffffff'));
                }
                else {
                    var radio_status = $('.radio_status' + index);
                    radio_status[0].checked = false;
                    radio_status[1].checked = false;
                    if (isNaN(parseInt(objMajorActual.val())))
                        (objMajorActual.val(0));
                    if (isNaN(parseInt(objMinorActual.val())))
                        (objMinorActual.val(0));
                    if (isNaN(parseInt(objCriticalActual.val())))
                        (objCriticalActual.val(0));

                    if (isNaN(parseInt(majorAllowed)))
                        majorAllowed = 0;
                    if (isNaN(parseInt(minorAllowed)))
                        minorAllowed = 0;
                    if (isNaN(parseInt(criticalAllowed)))
                        criticalAllowed = 0;


                    if ((parseInt(majorAllowed) >= parseInt(objMajorActual.val())) &&
	                (parseInt(minorAllowed) >= parseInt(objMinorActual.val())) &&
	                (parseInt(criticalAllowed) >= parseInt(objCriticalActual.val()))
                  ) {

                        (lblStatus.val("PASS"));
                        objhdnRadioStatus.val("1");
                        ($('.status' + index, "#main_content").css('backgroundColor', '#01cc01'));
                    }
                    else if ((parseInt(majorAllowed) < parseInt(objMajorActual.val())) ||
	                (parseInt(minorAllowed) < parseInt(objMinorActual.val())) ||
	                (parseInt(criticalAllowed) < parseInt(objCriticalActual.val()))
                  ) {

                        (lblStatus.val("FAIL"));
                        objhdnRadioStatus.val("2");
                        ($('.status' + index, "#main_content").css('backgroundColor', '#FF0000'));
                    }
                    else {
                        (lblStatus.val(""));
                        objhdnRadioStatus.val("");
                        radio_status[0].checked = false;
                        radio_status[1].checked = false;
                        ($('.status' + index, "#main_content").css('backgroundColor', 'ffffff'));
                    }
                }
            }
        }
    }
    function test() {

        // var objhdnRadioStatus = $('.hidden_status' + index);
        // 
        // for (var i = 0; i < lblSize.length; i++) {



        // var ss=lblQtyChecked[i].innerHTML;


        //  }
        return true;
    }
    function calcQtyChecked(index) {

        //var lblSize = $('.calc_size', "#divPart" + index);
        lblSize = $('.calc_size', "#divPart" + index);
        var lblQty = $('.calc_qty', "#divPart" + index);
        //var lblQtyChecked = $('.calc_qty_checked', "#divPart" + index);
        lblQtyChecked = $('.calc_qty_checked', "#divPart" + index);
        var totalQty = $("#divPart" + index).find('input.shipping-qty' + index);
        var samplesChecked = $("#divPart" + index).find('input.samples-chkd' + index);
        var sampleQty = $("#divPart" + index).find('input.sample-qty' + index);
        for (var i = 0; i < lblSize.length; i++) {
            if (isNaN(parseInt(samplesChecked.val())))
                samplesChecked.val(0);

            if (parseInt(samplesChecked.val()) > 0)
                lblQtyChecked[i].innerHTML = Math.round((lblQty[i].innerHTML) * ((parseInt(samplesChecked.val())) / (parseInt(totalQty.val()))));

            if (parseInt(samplesChecked.val()) <= 0)
                if (!isNaN(sampleQty.val()) && parseInt(sampleQty.val()) > 0)
                    lblQtyChecked[i].innerHTML = Math.round((lblQty[i].innerHTML) * ((parseInt(sampleQty.val())) / (parseInt(totalQty.val()))));
        }
    }

    function onDesc1Change(i, j) {
        // 
        var spanClassificationObj = $("#spanClassification" + i + "_" + j, "#divFaults" + j);
        var selectedValue = $("#faultDescReport" + i + "_" + j, "#divFaults" + j).val();
        if (selectedValue == "-1") {
            (spanClassificationObj.html(""));
        }
        else {
            //            var ss = selectedValue.split("-");
            //            var s = ss[1].split("_");
            var s = selectedValue.split("-");
            if (s[1] == "1") {
                (spanClassificationObj.html("Critical"));
                spanClassificationObj.parents("td").css('backgroundColor', '#ff3300');
            }
            else if (s[1] == "2") {
                (spanClassificationObj.html("Major"));
                spanClassificationObj.parents("td").css('backgroundColor', '#fd9903');
            }
            else if (s[1] == "3") {
                (spanClassificationObj.html("Minor"));
                spanClassificationObj.parents("td").css('backgroundColor', '#FFFF00');
            }
        }
    }

    function onDescChange(i) {
        //  
        var selectedValue = $("#faultDesc" + i, "#main_content").val();
        var lblClassificationsObj = $("#lblClassifications" + i, "#main_content");

        if (selectedValue == "-1") {
            (lblClassificationsObj.html(""));
        }
        else {
            var s = selectedValue.split("-");

            if (s[1] == "1") {
                (lblClassificationsObj.html("Critical"));
                lblClassificationsObj.parents("td").css('backgroundColor', '#ff3300');
            }
            else if (s[1] == "2") {
                (lblClassificationsObj.html("Major"));
                lblClassificationsObj.parents("td").css('backgroundColor', '#fd9903');
            }
            else if (s[1] == "3") {
                (lblClassificationsObj.html("Minor"));
                lblClassificationsObj.parents("td").css('backgroundColor', '#FFFF00');
            }
        }
    }

    function onOccurrenceChange(rowcount, divId) {
        //      //yaten
        var criticalFault = 0;
        var majorFault = 0;
        var minorFault = 0;
        var objCriticalActual;
        var objMajorActual;
        var objMinorActual;
        var criticalAllowed = 0;
        var majorAllowed = 0;
        var minorAllowed = 0;
        var count;
        var parentDivId;
        if (divId != null && divId != '') {
            count = divId.split('s');
            if (parseInt(count[1]) > 0 && parseInt(count[1]) <= divCount) {
                parentDivId = "#divPart" + count[1];

                majorAllowed = $('#lblMajorAllowed', parentDivId).val();
                criticalAllowed = $('#lblCriticalAllowed', parentDivId).val();
                minorAllowed = $('#lblMinorAllowed', parentDivId).val();

                objMajorActual = $('#lblMajorActual', parentDivId);
                objCriticalActual = $('#lblCriticalActual', parentDivId);
                objMinorActual = $('#lblMinorActual', parentDivId);

                (objCriticalActual.val(0));
                (objMajorActual.val(0));
                (objMinorActual.val(0));

                for (var j = 1; j <= rowcount; j++) {
                    var spanClassificationObj = $("#spanClassification" + j.toString() + "_" + count[1], divId);
                    var txtOccurrenceObj = $('#txtOccurrence' + j.toString() + "_" + count[1], divId);

                    if (spanClassificationObj.html() == "Critical") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        criticalFault = parseInt(criticalFault) + parseInt(txtOccurrenceObj.val());
                        (objCriticalActual.val(criticalFault));
                    }
                    else if (spanClassificationObj.html() == "Major") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        majorFault = parseInt(majorFault) + parseInt(txtOccurrenceObj.val());
                        (objMajorActual.val(majorFault));
                    }
                    else if (spanClassificationObj.html() == "Minor") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        minorFault = parseInt(minorFault) + parseInt(txtOccurrenceObj.val());
                        (objMinorActual.val(minorFault));
                    }
                }

                if (isNaN(parseInt(objMajorActual.val())))
                    (objMajorActual.val(0));
                if (isNaN(parseInt(objMinorActual.val())))
                    (objMinorActual.val(0));
                if (isNaN(parseInt(objCriticalActual.val())))
                    (objCriticalActual.val(0));

                if (parentDivId != null && parentDivId != undefined && parentDivId != '') {
                    getStatus(parentDivId, count[1], false);
                }
            }
        }
    }
    function ShowPopUpAQLWise(aqltype) {

        proxy.invoke("ShowPopUpAQLWise", { AQLType: aqltype },
                     function (result) {
                         if (result == null || result == '') {
                             return;
                         }
                         else {
                             // 
                             jQuery.facebox(result);
                         }
                     });

    }

    function showPopup(srcElement) {
        //
        objRow = $(srcElement).parents("tr");
        // var aql = objRow.find('.aql-value').html();
        var aql = objRow.find('.aql-value').val();
        ShowPopUpAQLWise(aql);
        // if (aql = '2.5') {
        //     jQuery.facebox($("#audit-table2").html());
        //  }
        //  else if (aql = '1.5') {
        //     jQuery.facebox($("#audit-table1").html());
        //  }
    }

    function addRow() {
        // 
        var rowCount = $("#tableFaults tr", "#main_content").length - 1;
        var lastRow = $("#tableFaults tr:last", "#main_content");
        var row = $("#tableFaults tr:last", "#main_content").clone(true).insertAfter($("#tableFaults tr:last", "#main_content"));
        var newLastRow = $("#tableFaults tr:last", "#main_content");

        newLastRow.find("input,select,textarea,label,hidden").val("").each(function () {
            var name = $(this).attr("name");
            name = name.replace(/[0-9]*/g, '');
            $(this).attr("name", name + (rowCount + 1));

            var id = $(this).attr("id");
            id = id.replace(/[0-9]*/g, '');
            $(this).attr("id", id + (rowCount + 1));

        });
        var element = newLastRow.find("#txtIsDeleted" + (rowCount + 1));

        element.val("0");
        newLastRow.show();
    }

    function addRow1(index) {
        //  
        var rowCount = $("#tableFaults1 tr", "#divFaults" + index).length - 1;
        var lastRow = $("#tableFaults1 tr:last", "#divFaults" + index);
        var row = $("#tableFaults1 tr:last", "#divFaults" + index).clone(true).insertAfter($("#tableFaults1 tr:last", "#divFaults" + index));
        var newLastRow = $("#tableFaults1 tr:last", "#divFaults" + index);
        newLastRow.find("input,select,textarea,label,hidden").val("").each(function () {
            var name = $(this).attr("name");
            name = name.replace(/[0-9]*/g, '').replace('_', '');
            $(this).attr("name", name + (rowCount + 1) + "_" + index.toString());

            var id = $(this).attr("id");
            id = id.replace(/[0-9]*/g, '').replace('_', '');
            $(this).attr("id", id + (rowCount + 1) + "_" + index.toString());

        });
        var element = newLastRow.find("#txtIsDeletedR" + (rowCount + 1) + "_" + index.toString());

        element.val("0");
        newLastRow.show();
    }

    function deleteRow(srcElem) {
        //  //yaten
        var objRow = $(srcElem).parents("tr");
        var rowindex = objRow.get(0).rowIndex;
        var element = objRow.find("#txtIsDeleted" + rowindex);
        var Objid = "hdnRowStatus" + rowindex;
        document.getElementById(Objid).value = "0";
        element.val("1");
        objRow.hide();
    }

    function deleteRowR(srcElem, index) {
        //   //yaten
        var objRow = $(srcElem).parents("tr");
        var rowindex = objRow.get(0).rowIndex;
        var Objid = "hdnRowStatusOcc" + rowindex + "_" + index;
        document.getElementById(Objid).value = "0";
        var element = objRow.find("#txtIsDeletedR" + rowindex + "_" + index);
        element.val("1");
        objRow.hide();

        var rowCount = $("#tableFaults1 tr", "#divFaults" + index).length - 1;
        var DivID = "#divFaults1";

        onOccurrenceChange(rowCount);
        // onOccurrenceChangeDelete(rowCount, DivID);
        var FaultNatureID = "spanClassification" + rowindex + "_" + index;
        var FaultNature = document.getElementById(FaultNatureID).innerHTML;
        if (FaultNature == "Minor") {
            var id = "txtOccurrence" + rowindex + "_" + index;
            var tt = document.getElementById('lblMinorActual').value;
            var deletevalue = document.getElementById(id).value;
            tt = tt - deletevalue;
            document.getElementById('lblMinorActual').value = tt;
            document.getElementById(id).value = 0;
        }
        if (FaultNature == "Critical") {
            var id = "txtOccurrence" + rowindex + "_" + index;
            var tt = document.getElementById('lblCriticalActual').value;
            var deletevalue = document.getElementById(id).value;
            tt = tt - deletevalue;
            document.getElementById('lblCriticalActual').value = tt;
            document.getElementById(id).value = 0;
        }
        if (FaultNature == "Major") {
            var id = "txtOccurrence" + rowindex + "_" + index;
            var tt = document.getElementById('lblMajorActual').value;
            var deletevalue = document.getElementById(id).value;
            tt = tt - deletevalue;
            document.getElementById('lblMajorActual').value = tt;
            document.getElementById(id).value = 0;
        }



        //        var id="txtOccurrence" + rowindex + "_" +index;
        //        var tt = document.getElementById('lblMinorActual').value;
        //        var deletevalue = document.getElementById(id).value;
        //        tt=tt-deletevalue;
        //        document.getElementById('lblMinorActual').value = tt;
        //        document.getElementById(id).value = 0;
    }






    function onOccurrenceChangeDelete(rowcount, divId) {
        //      //yaten


        var tt = document.getElementById('lblMinorActual').value;

        var ss = parseInt(minorFault);
        var criticalFault = 0;
        var majorFault = 0;
        var minorFault = 0;
        var objCriticalActual;
        var objMajorActual;
        var objMinorActual;
        var criticalAllowed = 0;
        var majorAllowed = 0;
        var minorAllowed = 0;
        var count;
        var parentDivId;
        if (divId != null && divId != '') {
            count = divId.split('s');
            if (parseInt(count[1]) > 0 && parseInt(count[1]) <= divCount) {
                parentDivId = "#divPart" + count[1];

                majorAllowed = $('#lblMajorAllowed', parentDivId).val();
                criticalAllowed = $('#lblCriticalAllowed', parentDivId).val();
                minorAllowed = $('#lblMinorAllowed', parentDivId).val();

                objMajorActual = $('#lblMajorActual', parentDivId);
                objCriticalActual = $('#lblCriticalActual', parentDivId);
                objMinorActual = $('#lblMinorActual', parentDivId);

                (objCriticalActual.val(0));
                (objMajorActual.val(0));
                (objMinorActual.val(0));

                for (var j = 1; j <= rowcount; j++) {
                    var spanClassificationObj = $("#spanClassification" + j.toString() + "_" + count[1], divId);
                    var txtOccurrenceObj = $('#txtOccurrence' + j.toString() + "_" + count[1], divId);

                    if (spanClassificationObj.html() == "Critical") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        criticalFault = parseInt(criticalFault) + parseInt(txtOccurrenceObj.val());
                        (objCriticalActual.val(criticalFault));
                    }
                    else if (spanClassificationObj.html() == "Major") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        majorFault = parseInt(majorFault) + parseInt(txtOccurrenceObj.val());
                        (objMajorActual.val(majorFault));
                    }
                    else if (spanClassificationObj.html() == "Minor") {
                        if (isNaN(parseInt(txtOccurrenceObj.val())))
                            txtOccurrenceObj.val(0);

                        minorFault = parseInt(minorFault) + parseInt(txtOccurrenceObj.val());
                        (objMinorActual.val(minorFault));
                    }
                }

                if (isNaN(parseInt(objMajorActual.val())))
                    (objMajorActual.val(0));
                if (isNaN(parseInt(objMinorActual.val())))
                    (objMinorActual.val(0));
                if (isNaN(parseInt(objCriticalActual.val())))
                    (objCriticalActual.val(0));

                if (parentDivId != null && parentDivId != undefined && parentDivId != '') {
                    getStatus(parentDivId, count[1], false);
                }
            }
        }
    }
    function ExpandCollapsePart(sender, isExpand, index) {
        //  
        if (isExpand) {
            if ($(sender) == undefined) {
                $('.expand-part' + index).hide();
                $('.collapse-part' + index).show();

                $(sender).parents('tr').parents('table').parents('div').parents('div').find('.expand-collapse' + index).show();
            }
            else {
                $(sender).parents('tr').parents('table').parents('div').parents('div').find('.expand-collapse' + index).show();

                $(sender).parents('tr').find('.expand-part' + index).show();
                $(sender).parents('tr').find('.collapse-part' + index).show();
                $(sender).hide();
            }
        }
        else {
            if ($(sender) == undefined) {
                $('.expand-part' + index).show();
                $('.collapse-part' + index).hide();

                $(sender).parents('tr').parents('table').parents('div').parents('div').find('.expand-collapse' + index).hide();
            }
            else {
                $(sender).parents('tr').parents('table').parents('div').parents('div').find('.expand-collapse' + index).hide();

                $(sender).parents('tr').find('.expand-part' + index).show();
                $(sender).parents('tr').find('.collapse-part' + index).show();
                $(sender).hide();
            }
        }
    }

    function ChangeStatus(src) {
        //
        var objDivId = $(src).parents("td").parents("tr").parents("table").parents("div").parents("div").attr("id");


        var count = objDivId.split('t');
        if (count[1] != null && count[1] != undefined && parseInt(count[1]) > 0) {
            lblStatus = $('#lblStatus', "#" + objDivId);
            var objHdnStatus = $(src).parents("td").find('.hidden_status' + count[1]);

            if ($(src).val() == '1') {
                objHdnStatus.val("1");
                (lblStatus.val("PASS"));
                ($('.status' + count[1], "#main_content").css('backgroundColor', '#01cc01'));
            }
            else if ($(src).val() == '2') {
                objHdnStatus.val("2");
                (lblStatus.val("FAIL"));
                ($('.status' + count[1], "#main_content").css('backgroundColor', '#FF0000'));
            }
            else {
                objHdnStatus.val("0");
                (lblStatus.val(""));
                ($('.status' + count[1], "#main_content").css('backgroundColor', 'ffffff'));
            }
        }
    }


    function ShowFitsPopup(orderdetailid) {
        var screenX = parseInt(screen.width) - 100;
        window.open("/Internal/Merchandising/QualityControlHistory.aspx?orderDetailID=" + orderdetailid, "QualityControlHistory", "left=50,top=0,status=1,scrollbars=1, width=" + screenX + ",height=600");
    }

    // added by yaten
    function PrintPDFQualityControl(Url, height, width) {
        $(".loadingimage").show();
        $(".print").hide();

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
        //   debugger;
        //alert(wd + " - " + ht);
        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {

            if ($.trim(result) == '') {
                //$.hideprogress();
                jQuery.facebox("Some error occured on the server, please try again later.");
            }
            else {
                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });

        return false;
    }
 
</script>
<style type="text/css">

.close
{
        background-image: url(../../App_Themes/ikandi/images/close.jpg) !important;
        width:86px !important;
}
</style>

<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="form_box">
            <div class="form_heading">
                QUALITY ASSURANCE FORM
                <asp:HiddenField ID="hiddenQualityControlID" runat="server" />
            </div>
            <div class="form_small_heading" align="center" style="vertical-align: middle !important">
                <strong>BASIC INFORMATION</strong>
            </div>
            <table width="100%" class="item_list" bordercolor="#000000" border="1">
                <tbody>
                    <tr>
                        <th>
                            CLIENT
                        </th>
                        <th>
                            SERIAL NO.
                        </th>
                        <th>
                            STYLE NUMBER
                        </th>
                        <th>
                            LINE/ITEM NUMBER
                        </th>
                        <th>
                            CONTRACT NUMBER
                        </th>
                        <th>
                            DESCRIPTION
                        </th>
                        <th>
                            MAIN FABRIC/COLOUR
                        </th>
                        <td colspan="2" rowspan="4">
                            <asp:Image runat="server" ID="imgPrint" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblClient" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblIkandiSerial" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblStyleNumber" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblLineItemNumber" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblContractNumber" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblColour" runat="server"  ForeColor="Blue"></asp:Label><br />
                             <asp:Label ID="lblccgsm" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            QTY
                        </th>
                        <th>
                            EX FACTORY
                        </th>
                        <th>
                            STITCHING%
                        </th>
                        <th>
                            FINISHING%
                        </th>
                        <th>
                            UNIT
                        </th>
                        <th>
                            FACTORY MGR
                        </th>
                        <th>
                            STATUS
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblTotalQty" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblExFactory" runat="server" CssClass="date_style"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblStitch" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblPack" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblUnit" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFactoryMgr" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="lblStatus" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div class="form_box">
            <div class="form_heading" align="center" style="vertical-align: middle !important;
                font-size: 15px !important">
                INLINE
            </div>
            <asp:HiddenField ID="hiddenStyleId" runat="server" />
            <asp:HiddenField ID="hiddenStyleNumber" runat="server" />

            <asp:HiddenField ID="hdnStyleId" runat="server" />
            <asp:HiddenField ID="hdnstylenumber" runat="server" />
            <asp:HiddenField ID="hdnClientID" runat="server" />
            <asp:HiddenField ID="hdnDeptId" runat="server" />
            <asp:HiddenField ID="hdnshowHOPPM" runat="server" />
            <%--abhishek-- 3/8/2015%>
            <%--<a id="A1" target="inlineppm" href="/Internal\Production\InlinePPMEdit.aspx?styleid=<%= hiddenStyleId.Value %>&stylenumber=<%= hiddenStyleNumber.Value %>">--%>
            <a id="A1" target="inlineppm" href="/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=<%= hiddenStyleId.Value %>&stylenumber=<%= hdnstylenumber.Value %>&FitsStyle=<%= hdnstylenumber.Value %>&ClientID=<%= hdnClientID.Value %>&DeptId=<%= hdnDeptId.Value %>&showHOPPMFORM=Yes">
               <%-- Click here</a> to Inline Form.--%>
               Click here</a> to  HOPPM FORM.
              <%-- end--%>
               
            <table width="100%" class="item_list" bordercolor="#000000" border="1">
                <tr>
                    <th colspan="1">
                        DATE HELD
                    </th>
                    <th colspan="8">
                        PPM REMARKS
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblDateHeld" runat="server" CssClass="date_style"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblPpmRemarks" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <div class="form_heading" align="center" style="vertical-align: middle !important;
                font-size: 15px !important">
                ONLINE
            </div>
            <div id="divFaults">
            </div>
            <div align="right">
                <img src="../../App_Themes/ikandi/images/plus.gif" id="btnAddRow" onclick="addRow( this)" />
                Add More &nbsp;
            </div>
        </div>
        <asp:Repeater runat="server" ID="repeaterFaultsReporting" 
            OnItemDataBound="repeaterFaultsReporting_ItemDataBound" 
            onitemcommand="repeaterFaultsReporting_ItemCommand">
            <ItemTemplate>
                <div id="divPart<%# Container.ItemIndex + 1 %>">
                    <div class="form_box">
                        <div class="form_heading" align="center" style="vertical-align: middle !important;
                            font-size: 15px !important">
                            <div>
                            <asp:Label ID="lblFinalAudit" runat="server"></asp:Label>
                            </div>
                             &nbsp;</label><asp:Label ID="Label2" runat="server" Font-Bold="true"
                                Font-Size="16px"> ( Quantity: <%# Eval("ShippingQty")%> )</asp:Label>
                            <asp:HiddenField ID="hdnQCPartStatusId" Value='<%# Eval("Id")%>' runat="server" />
                            <asp:HiddenField ID="hdnIsPartShipment" Value='<%# Eval("IsPartShipment")%>' runat="server" />
                        </div>
                        <table class="form_table">
                            <tr>
                                <td style="text-align: left">
                                    <img src="../../App_Themes/ikandi/images/plus.gif" class="expand-part<%# Container.ItemIndex  + 1 %>"
                                        style="cursor: hand; display: none" title="Expand" onclick="ExpandCollapsePart(this,true,<%# Container.ItemIndex  + 1 %>);" />
                                    <img src="../../App_Themes/ikandi/images/minus.gif" class="collapse-part<%# Container.ItemIndex  + 1 %>"
                                        style="cursor: hand" title="Collapse" onclick="ExpandCollapsePart(this,false,<%# Container.ItemIndex  + 1 %>);" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" class="item_list expand-collapse<%# Container.ItemIndex  + 1 %>"
                            bordercolor="#000000" border="1">
                            <tr>
                                <th>
                                    DATE CONDUCTED
                                </th>
                                <th>
                                    QTY
                                </th>
                                <th>
                                    AQL SAMPLE QTY
                                </th>
                                <th>
                                    ACTUAL SAMPLES CHECKED
                                </th>
                                <th colspan="3">
                                    QA
                                </th>
                            </tr>
                            <tr>
                                <td align="center">
                                    <input runat="server" type="text" id="txtDateConducted" name='<%# "txtDateConducted" + Container.ItemIndex + 1 %>'
                                        class='<%# "date-picker date_style" %>' value='<%# Eval("DateConducted")%>' />
                                </td>
                                <td align="center">
                                    <input runat="server" type="text" id="lblQtyFinal" value='<%# Eval("ShippingQty")%>'
                                        class='<%# "do-not-allow-typing" + " shipping-qty" + (Container.ItemIndex + 1).ToString() %>' />
                                </td>
                                <td align="center">
                                    <input runat="server" type="text" id="lblSampleQty" value='<%# Eval("SampleQuantity")%>'
                                        class='<%# "do-not-allow-typing" + " sample-qty" + (Container.ItemIndex + 1).ToString() %>' />
                                </td>
                                <td align="center">
                                    <input runat="server" type="text" id="txtActualSamplesChecked" name='<%# "txtActualSamplesChecked" + Container.ItemIndex + 1 %>'
                                        class='<%# "numeric-field-without-decimal-places" + " samples-chkd" + (Container.ItemIndex + 1).ToString() %>'
                                        onchange='<%# "calcQtyChecked(" + (Container.ItemIndex + 1).ToString() + ")" %>'
                                        value='<%# Eval("ActualSamplesChecked")%>' />
                                </td>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lblQA" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="form_box expand-collapse<%# Container.ItemIndex  + 1 %> divSizes<%# Container.ItemIndex  + 1 %>">
                        <div class="form_heading" align="center" style="vertical-align: middle !important;
                            font-size: 15px !important">
                            QUALITY ASSURANCE TO PERFORM SIZE MATRIX
                        </div>
                        
                        
                        <table width="100%" class="item_list" bordercolor="#000000" border="1">
                            <tbody>
                                <tr>
                                    <th>
                                        Sizes
                                    </th>
                                    <asp:Repeater ID="repeaterSizes" runat="server" OnItemDataBound="repeaterSizesItemDataBound">
                                        <ItemTemplate>
                                            <th>
                                                <div>
                                                    <label id="lblSize" class=' blue-text calc_size'>
                                                        <%# Eval("Size")%></label>
                                                </div>
                                            </th>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </tr>
                                <tr>
                                    <th>
                                        Total Qty in Stock
                                    </th>
                                    <asp:Repeater ID="repeaterQtyStock" runat="server" OnItemDataBound="repeaterQtyItemDataBound">
                                        <ItemTemplate>
                                            <th>
                                                <label id="lblQty" class='calc_qty blue-text'>
                                                    <%# Eval("Quantity")%></label>
                                            </th>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </tr>
                                <tr>
                                    <th>
                                        Quantity Checked
                                    </th>
                                    <asp:Repeater ID="repeaterQtyChecked" runat="server" OnItemDataBound="repeaterQtyCheckedItemDataBound">
                                        <ItemTemplate>
                                            <th>
                                                <label id="lblQtyChecked" class="calc_qty_checked blue-text">
                                                </label>
                                            </th>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="form_box expand-collapse<%# Container.ItemIndex  + 1 %>">
                        <div class="form_heading" align="center" style="vertical-align: middle !important;
                            font-size: 15px !important">
                            FAULTS REPORTING
                        </div>
                        <asp:HiddenField runat="server" ID="hdnProdPlanID" Value='<%# Eval("ProductionPlanningID")%>' />
                        <div id="divFaults<%# Container.ItemIndex + 1 %>">
                        </div>
                        <div align="right">
                            <img src="../../App_Themes/ikandi/images/plus.gif" id="Img1" onclick="addRow1(<%# Container.ItemIndex + 1 %>)" />
                            Add More &nbsp;
                        </div>
                        <table width="100%" class="item_list" bordercolor="#000000" border="1">
                            <tr>
                                <th colspan="2" rowspan="1">
                                    FAULTS SUMMARY
                                </th>
                                
                              
                                <th>
                                    MAJOR ALLOWED
                                </th>
                                <th>
                                    MAJOR ACTUAL
                                </th>
                                <th>
                                    MINOR ALLOWED
                                </th>
                                <th>
                                    MINOR ACTUAL
                                </th>
                                <th>
                                    CRITICAL ALLOWED
                                </th>
                                <th>
                                    CRITICAL ACTUAL
                                </th>
                                <th colspan="2">
                                    STATUS
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    AQL
                                    <input type="text" id="lblAql" value='<%# Eval("AqlValue")%>' style="background-color: #F9DDF4;
                                        border-color: #F9DDF4;" class="aql-value do-not-allow-typing" />
                                     <asp:Label ID="lblLastAQL" Text="" runat="server"></asp:Label>    
                                </th>
                               
                                <th>
                                    <img src="../../App_Themes/ikandi/images/table.gif" id="Img3" align="center" onclick="showPopup(this);return false;" />
                                </th>
                                
                                <td>
                                    <input type="text" id="lblMajorAllowed" value='<%# Eval("MajorDefectsAllowed")%>'
                                        class="do-not-allow-typing" />
                                </td>
                                <td>
                                    <input type="text" id="lblMajorActual" class="do-not-allow-typing" />
                                </td>
                                <td>
                                    <input type="text" id="lblMinorAllowed" value='<%# Eval("MinorDefectsAllowed")%>'
                                        class="do-not-allow-typing" />
                                </td>
                                <td>
                                    <input type="text" id="lblMinorActual" class="do-not-allow-typing" />
                                    
                                </td>
                                <td>
                                    <input type="text" id="lblCriticalAllowed>" value='0' class="do-not-allow-typing" />
                                </td>
                                <td>
                                    <input type="text" id="lblCriticalActual" class="do-not-allow-typing" />
                                </td>
                                <td class="status<%# Container.ItemIndex + 1 %>">
                                    <input type="text" style="width: 40px" id="lblStatus" value='<%# Eval("Status")%>'
                                        class="do-not-allow-typing status<%# Container.ItemIndex + 1 %>" />
                                    <input type="hidden" id="hiddenStatus<%# Container.ItemIndex + 1 %>" value='<%# Eval("Status")%>' />
                                </td>
                                <td>
                                    <input type="radio" onclick="ChangeStatus(this)" name="radioStatus<%# Container.ItemIndex + 1 %>"
                                        value="1"  {#if '<%# Eval("Status")%>'=='PASS'} checked="checked" {#else} checked="checked"  {#/if} class="radio_status<%# Container.ItemIndex + 1%> "  />Pass
                                    <br />
                                    <input type="radio" onclick="ChangeStatus(this)" name="radioStatus<%# Container.ItemIndex + 1 %>"
                                        value="2" {#if '<%# Eval("Status")%>'=='FAIL'} checked="checked" {#else} checked="checked"  {#/if} class="radio_status<%# Container.ItemIndex + 1 %>" />Fail
                                    <asp:HiddenField ID="hdnStatus" runat="server" Value="0" />
                                    <input type="text" runat="server" id="hdnRadioStatus" name='hdnRadioStatus<%# (Container.ItemIndex + 1).ToString() %>'
                                        class='<%# "do-not-allow-typing hide_me"+ " hidden_status"  + (Container.ItemIndex + 1).ToString() %>' />
                                </td>
                            </tr>
                        </table>
                        
                        
                        
                    </div>
                    <div class="form_box expand-collapse<%# Container.ItemIndex  + 1 %>">
                        <table width="100%" class="item_list" bordercolor="#000000" border="1">
                            <tbody>
                                <tr>
                                    <th colspan="10">
                                        CHECK FROM PRODUCTION FILE SUBMITTED BY THE MERCHANDISING DEPARTMENT AND CONFIRM
                                        BELOW CORRECTNESS
                                    </th>
                                </tr>
                                <tr>
                                    <th colspan="10">
                                        ITEM TO CHECK
                                    </th>
                                </tr>
                                <tr>
                                    <td width="10%">
                                        ITEM
                                    </td>
                                    <td width="10%">
                                        Main Label
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Size Label
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Washcare
                                        <asp:HiddenField ID="HiddenField3" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Price Ticket
                                        <asp:HiddenField ID="HiddenField4" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Polybag Sticker
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Carton Quality/ Dimensions and No Excess Packaging
                                        <asp:HiddenField ID="HiddenField6" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Carton Stickers
                                        <asp:HiddenField ID="HiddenField7" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Polybag Quality and Dimensions
                                        <asp:HiddenField ID="HiddenField8" runat="server" />
                                    </td>
                                    <td width="10%">
                                        Hangers
                                        <asp:HiddenField ID="HiddenField9" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Missing
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Not Required
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality2" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Present
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers3" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10">
                                        MAKE SURE ALL THE BARCODES AND NUMBERS ON ANY OF THE ITEMS CROSS TALLY. SHIPMENT
                                        CANNOT LEAVE IF ANY OF THE SIDE ITEMS ARE FAULTY. IF ANY ITEMS ARE NON APPLICABLE
                                        DELETE THEM.
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="form_box">
            <table width="100%" class="item_list" bordercolor="#000000" border="1">
                <tbody>
                    <tr>
                        <th colspan="2" align="center">
                            Processing Instructions
                        </th>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:DropDownList ID="ddlProcessingInstructions" runat="server">
                                <asp:ListItem Value="-1" Text="Select.." Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Unpacked and Hang" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Steam Tunnel" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Hand Press" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Other" Selected="False"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="50%">
                            <div>
                                <asp:TextBox ID="txtOtherProcessingInstruction" runat="server"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list" bordercolor="#000000" border="1">
                <tbody>
                    <tr>
                        <th colspan="9" align="center">
                            OVERALL COMMENTS*
                            <asp:HiddenField ID="hdnOrderDetailID" runat="server" Value="0" />
                        </th>
                    </tr>
                    <tr class='<%= (hdnOrderDetailID.Value == "0" )? "hide_me" : "" %>'>
                        <td colspan="9" align="center">
                            <asp:HiddenField ID="hdnComment" runat="server" Value="" />
                            <asp:Label ID="lblLastComment" runat="server"></asp:Label>
                            <br />
                            <img class='<%= (hdnOrderDetailID.Value == "0" )? "hide_me" : "" %>' id="imgRemark"
                                alt="Comment" title="CLICK TO SEE COMMENT HISTORY" src="/App_Themes/ikandi/images/remark.gif"
                                border="0" onclick="showRemarks(0,0,'<%= (hdnComment.Value.ToString().IndexOf("$$") > -1) ? hdnComment.Value.ToString().Replace("$$", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : hdnComment.Value.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") %>','','',0)" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="100px"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list" bordercolor="#000000" border="1">
                <tbody>
                    <tr>
                        <th>
                            Shipping Officer <%--<asp:Label id="lblQAManager" runat="server" ></asp:Label>--%>
                        </th>
                        <td>
                            <asp:CheckBox ID="chkQAManager" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblDate" runat="server" CssClass="date_style"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <th>
                           Client Head <%--<asp:Label id="lblClientHead" runat="server" ></asp:Label>--%>
                        </th>
                        <td>
                            <asp:CheckBox ID="chkClientHead" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblClientHeadDate" runat="server" CssClass="date_style"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            CQD <%-- Factory Head <asp:Label id="lblFactoryHead" runat="server" ></asp:Label>--%>
                        </th>
                        <td>
                            <asp:CheckBox ID="chkFactoryHead" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblFactoryHeadDate" runat="server" CssClass="date_style"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="submit" OnClientClick="javascript: return test();" />
    <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" CssClass="go hide_me" />

    <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" meta:resourcekey="LoadImgResource1" />
    <input type="button" id="btnPrint" class="print" onclick="return PrintPDFQualityControl();" />
    &nbsp;<button id="btn"  runat="server" value="History" class="history" style="height:24"></button>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Quality Assurance information have been saved into the system successfully!
            <br />
            <a id="A2" href="~/Internal/OrderProcessing/ManageOrders.aspx" runat="server">Click
                here</a> to Manage Orders.
        </div>
    </div>
</asp:Panel>
<textarea id="templateFault" class="hide_me">
<table border="1px black solid" id="tableFaults" class="item_list">
    <tr>
                <th colspan="4">
                    NATURE OF FAULT
                </th>
                <th>
                    CLASSIFICATION
                </th>
                <th>
                    OWNER
                </th>
                <th colspan="3">
                    RESOLUTION
                </th>
            </tr>
            {#foreach $T.table as record}
            <tr>
                <td colspan="4">
                    <input type="hidden" id="hiddenID{$P.x}" name="hiddenID{$P.x}" value="{$T.record.Id}"  />
                    <input type="hidden" value="0" id="txtIsDeleted{$P.x}" name="txtIsDeleted{$P.x}" />
                    <input type="hidden" id="hdnRowStatus{$P.x}" name="hdnRowStatus{$P.x}"  value="1" />
                    <select id="faultDesc{$P.x}" name="faultDesc{$P.x}" >
                      
                    <option value="-1">Select ...</option>
                     <asp:Repeater runat="server" ID="repeaterCategory2" OnItemDataBound="repeaterCategory2ItemDataBound" >
			       	    <ItemTemplate>
                                <optgroup label='<%# Eval("FaultCategoryType")%>' >
                                    <asp:Repeater runat="server" ID="repeaterSubCategory2" OnItemDataBound="repeaterSubCategory2ItemDataBound" >
			       	                   <ItemTemplate>
                                       <optgroup label='<%# Eval("FaultSubCategoryType")%>' >
                                         
                                          <asp:Repeater runat=server ID="ddlFaults"  >
			       	                            <ItemTemplate>
			       	                                <option value='<%# Eval("FaultId").ToString() %>-<%# Eval("FaultType").ToString() %>' {#if $T.record.FaultValue == '<%# Eval("FaultId").ToString() %>-<%# Eval("FaultType").ToString() %>' } selected {#/if}>  <%# Eval("Fault") %></option>
			       	                            </ItemTemplate> 
			       	                          </asp:Repeater>
			       	                      </optgroup>
			       	                       </ItemTemplate>
			       	                  </asp:Repeater>
			       	              </optgroup>
			       	  </ItemTemplate>
			       	  </asp:Repeater>
			       </select>                
                   
                </td>
                <td id="Classification{$P.x}" name="Classification{$P.x}">
                    <label name="lblClassifications{$P.x}" id="lblClassifications{$P.x}" {#if $T.record.FaultType = 1 } value="Critical" {#/if}{#if $T.record.FaultType = 2 } value="Major" {#/if}{#if $T.record.FaultType = 3 } value="Minor" {#/if}></label>
                    
                </td>
                <td>
                   <select id="owner{$P.x}" name="owner{$P.x}" >
                      <option value="-1">Select ...</option>
                      <asp:Repeater runat=server ID="repeaterOwner"  >
			       	    <ItemTemplate>
			       	        <option value='<%# Eval("UserID")  %>' {#if $T.record.Owner == '<%# Eval("UserID")  %>' } selected {#/if} ><%# Eval("FullName")%></option>
			       	    </ItemTemplate> 
			       	  </asp:Repeater>
			       </select>                
                </td>
                <td>
                      <img class='<%= (hiddenQualityControlID.Value == "0" )? "hide_me" : "" %>' id="img4" alt="Comment" title="CLICK TO SEE COMMENT HISTORY" src="/App_Themes/ikandi/images/remark.gif" border="0" onclick="showRemarks(0,'{$T.record.Id}','{$T.record.Resolution}','Resolution','QUALITY_CONTROL','{$T.record.Permission}')" />
                      <br />
                      <input type="text" name="txtResolutionR{$P.x}" id="txtResolutionR{$P.x}" value="{$T.record.LastResolution}" class="do-not-allow-typing" disabled="disabled" />
                    <img src="../../App_Themes/ikandi/images/minus.gif" id="btnDeleteRow" align="right" alt="" onclick="deleteRow( this)" />
 
                </td>
            </tr>
             {#param name=x value=$P.x+1}
		     {#/for}
		</table>
	</textarea>
<textarea id="templateFault1" class="hide_me">
<table border="1px black solid" id="tableFaults1" class="item_list">
    <tr>
                <th colspan="4">
                    NATURE OF FAULT
                    <input type="hidden" id="hdnHeader" value="-1" />
                </th>
                <th>
                    CLASSIFICATION
                </th>
                <th>
                    OCCURRENCE
                </th>
                <th>
                    OWNER
                </th>
                <th colspan="3">
                    RESOLUTION
                </th>
            </tr>
            {#foreach $T as record}
            <tr>
                <td colspan="4">
                    <input type="hidden" id="hiddenIDReport{$P.x}_{$P.y}" name="hiddenIDReport{$P.x}_{$P.y}" value="{$T.record.Id}"  />
                   
                    <input type="hidden" value="0" id="txtIsDeletedR{$P.x}_{$P.y}" name="txtIsDeletedR{$P.x}_{$P.y}"  />
                    <select id="faultDescReport{$P.x}_{$P.y}" name="faultDescReport{$P.x}_{$P.y}"  onchange="OnFaultChange(this)">
                     <option value="-1">Select ...</option>
                    <asp:Repeater runat="server" ID="repeaterCategory" OnItemDataBound="repeaterCategoryItemDataBound" >
			       	    <ItemTemplate>
                                <optgroup label='<%# Eval("FaultCategoryType")%>' >
                                    <asp:Repeater runat="server" ID="repeaterSubCategory" OnItemDataBound="repeaterSubCategoryItemDataBound" >
			       	                   <ItemTemplate>
                                       <optgroup label='<%# Eval("FaultSubCategoryType")%>' >
                                         
                                          <asp:Repeater runat="server" ID="ddlFaults2"  >
			       	                        <ItemTemplate>
			       	                            <option value='<%# Eval("FaultId").ToString() %>-<%# Eval("FaultType").ToString() %>'  {#if $T.record.FaultValue == '<%# Eval("FaultValue").ToString()%>' } selected {#/if}> <%# Eval("Fault") %></option>
			       	                        </ItemTemplate> 
			       	                      </asp:Repeater>
			       	                      </optgroup>
			       	                       </ItemTemplate>
			       	                  </asp:Repeater>
			       	              </optgroup>
			       	  </ItemTemplate>
			       	  </asp:Repeater>
			       	   
			       </select>                
                   
                </td>
                <td id="ClassificationR{$P.x}"  name="ClassificationR{$P.x}">
                    <label  name="spanClassification{$P.x}_{$P.y}" id="spanClassification{$P.x}_{$P.y}" {#if $T.record.FaultType = 3 } value="Minor" {#/if}{#if $T.record.FaultType = 1 } value="Critical" {#/if}{#if $T.record.FaultType = 2 } value="Major" {#/if}></label>
                </td>
                <td>
                    <input type="text" name="txtOccurrence{$P.x}_{$P.y}" id="txtOccurrence{$P.x}_{$P.y}" value="{$T.record.Occurrence}" class="numeric-field-without-decimal-places" onchange="OnFaultCountChange(this)" />
                     <input type="hidden" id="hdnRowStatusOcc{$P.x}_{$P.y}" name="hdnRowStatusOcc{$P.x}_{$P.y}"  value="1" />
                </td>
                <td>
                   <select id="ownerR{$P.x}_{$P.y}" name="ownerR{$P.x}_{$P.y}" >
                      <option value="-1">Select ...</option>
                      <asp:Repeater runat=server ID="ddlOwner"  >
			       	    <ItemTemplate>
			       	        <option value='<%# Eval("UserID")  %>' {#if $T.record.Owner == '<%# Eval("UserID")  %>' } selected {#/if} ><%# Eval("FullName")%></option>
			       	    </ItemTemplate> 
			       	  </asp:Repeater>
			       </select>                
                </td>
                <td>
                   <img class='<%= (hiddenQualityControlID.Value == "0" )? "hide_me" : "" %>' id="img5" alt="Comment" title="CLICK TO SEE COMMENT HISTORY" src="/App_Themes/ikandi/images/remark.gif" border="0" onclick="showRemarks(0,'{$T.record.Id}','{$T.record.Resolution}','Resolution','QUALITY_CONTROL','{$T.record.Permission}')" />
                    <br />
                    <input type="text" name="txtResolution{$P.x}" id="txtResolution{$P.x}" value="{$T.record.LastResolution}" class="do-not-allow-typing" disabled="disabled" />
                    <img src="../../App_Themes/ikandi/images/minus.gif" id="Img2" align=right onclick="deleteRowR( this, {$P.y})" />
                </td>
            </tr>
             {#param name=x value=$P.x+1}
		     {#/for}
		</table>
	</textarea>
<div class="hide_me" id="audit-table1">
    <table width="100%" class="item_list" border="1px solid black">
        <tr>
            <%--<th align="center">
                NUMBER OF CARTONS IN SHIPMENT
            </th>
            <th align="center">
                TOTAL CARTONS TO BE OPENED
            </th>--%>
            <th align="center" rowspan="2">
                AQL
            </th>
            <th colspan="3" align="center">
                SIZE CHART
            </th>
            <th colspan="2" align="center">
                MAJOR DEFECTS
            </th>
            <th colspan="2" align="center">
                MINOR DEFECTS
            </th>
        </tr>
        <tr>
            <%-- <th>
            </th>
            <th>
            </th>--%>
            <th colspan="2" align="center">
                SHIPMENT SIZE
            </th>
            <th align="center">
                AQL SAMPLE SIZE
            </th>
            <th align="center">
                PASS
            </th>
            <th align="center">
                FAIL
            </th>
            <th align="center">
                PASS
            </th>
            <th align="center">
                FAIL
            </th>
        </tr>
        <asp:Repeater ID="repeaterAuditChart1" runat="server">
            <ItemTemplate>
                <tr>
                    <%--<td align="center">
                        <%# System.Text.ASCIIEncoding.ASCII.GetString((byte[]) Eval("Cartons")) %>
                    </td>
                    <td align="center">
                        <%# Eval("TotalCartonsToBeOpened")%>
                    </td>--%>
                    <td align="center">
                        <%# Eval("AQLType")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSizeFrom")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSizeTo")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSize")%>
                    </td>
                    <td align="center">
                        <%# Eval("MajorDefectsPass")%>
                    </td>
                    <td align="center">
                        <%# Eval("MajorDefectsFail")%>
                    </td>
                    <td align="center">
                        <%# Eval("MinorDefectsPass")%>
                    </td>
                    <td align="center">
                        <%# Eval("MinorDefectsFail")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
<div class="hide_me" id="audit-table2">
    <table width="100%" class="item_list" border="1px solid black">
        <tr>
            <%--<th align="center">
                NUMBER OF CARTONS IN SHIPMENT
            </th>
            <th align="center">
                TOTAL CARTONS TO BE OPENED
            </th>--%>
            <th align="center" rowspan="2">
                AQL
            </th>
            <th colspan="3" align="center">
                SIZE CHART
            </th>
            <th colspan="2" align="center">
                MAJOR DEFECTS
            </th>
            <th colspan="2" align="center">
                MINOR DEFECTS
            </th>
        </tr>
        <tr>
            <%-- <th>
            </th>
            <th>
            </th>--%>
            <th colspan="2" align="center">
                SHIPMENT SIZE
            </th>
            <th align="center">
                AQL SAMPLE SIZE
            </th>
            <th align="center">
                PASS
            </th>
            <th align="center">
                FAIL
            </th>
            <th align="center">
                PASS
            </th>
            <th align="center">
                FAIL
            </th>
        </tr>
        <asp:Repeater ID="repeaterAuditChart2" runat="server">
            <ItemTemplate>
                <tr>
                    <%--<td align="center">
                        <%# System.Text.ASCIIEncoding.ASCII.GetString((byte[]) Eval("Cartons")) %>
                    </td>
                    <td align="center">
                        <%# Eval("TotalCartonsToBeOpened")%>
                    </td>--%>
                    <td align="center">
                        <%# Eval("AQLType")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSizeFrom")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSizeTo")%>
                    </td>
                    <td align="center">
                        <%# Eval("SampleSize")%>
                    </td>
                    <td align="center">
                        <%# Eval("MajorDefectsPass")%>
                    </td>
                    <td align="center">
                        <%# Eval("MajorDefectsFail")%>
                    </td>
                    <td align="center">
                        <%# Eval("MinorDefectsPass")%>
                    </td>
                    <td align="center">
                        <%# Eval("MinorDefectsFail")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>