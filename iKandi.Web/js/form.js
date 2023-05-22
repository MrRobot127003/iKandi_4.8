
var isShiftPressed = false;
var serviceUrl = '/Webservices/iKandiService.asmx/';
var proxy = new ServiceProxy(serviceUrl);
//
var disableFields = false;

$(function () {
    BindControls();
    BindFormatNumberWithCommasWithControls();
});

function BindControls() {
  
    $('.do-not-disable', '#main_content').removeAttr("diasbled");

    //$('table.fixed-header', '#main_content').fixedtableheader();
        
   

    $('input.do-not-allow-typing, textarea.do-not-allow-typing').keydown(function () { return false; });
    $(':button.validate-form', '#main_content').click(function () { ValidateForm(); });

    $('input.numeric-field-without-decimal-places').keyup(function (e) {
        CancelShiftOperation(e);
    });

    $('input.numeric-field-with-decimal-places', '#main_content').keyup(function (e) {
        CancelShiftOperation(e);
    });


    $('input.numeric-field-without-decimal-places').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), false);
    });
    //Kuldeep added for Accepting -ve value in Modes

    $('input.numeric-field-without-decimal-places-negative').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericNegative(e.keyCode, $(this), false);
    });


    $('input.numeric-field-with-decimal-places', '#main_content').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), true);
    });

    $('input.numeric-field-with-two-decimal-places', '#main_content').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), true, 2);
    });

    $('input.numeric-field-with-three-decimal-places', '#main_content').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), true, 3);
    });
    $('input.numeric-field-with-surendra-decimal-places', '#main_content').keydown(function (e) {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), true, 4);
    });
    $('input.water-mark', '#main_content').blur(function (e) {
        if ($(this).val() == '')
            $(this).val($(this).attr('defaultValue'));
    });


    $('input.water-mark', '#main_content').focus(function (e) {
        if ($(this).val() == $(this).attr('defaultValue') && $(this).val().toLowerCase() == 'comments')
            $(this).val('');
    });

    $('.disable-link', '#main_content').each(function () {
        $(this).attr("disabled", "true");
    });



    $('select.disable-dropdown', '#main_content').each(function () {
        setDDReadOnly($(this));
    });


    $('.disable-checkbox, .disable-checkbox:checkbox', '#main_content').each(function () {
        $(this).mousedown(function () { return false; });
    });


    if (disableFields)
        DisableAllFields();


    //var secondsDifference = diff/1000;
    //alert(str);
}


function setDDReadOnly(dd) {
    var DDSelector = $(dd);
    var saveValue = $(DDSelector).val();
    var saveText = DDSelector[0].options[DDSelector[0].selectedIndex].text;
    $(DDSelector).empty();
    $('<option>').attr('value', saveValue).text(saveText).appendTo(DDSelector);
    $(DDSelector).val(saveValue).attr('readOnly', true);
}

function BindFormatNumberWithCommasWithControls() {
    $.fn.FormatNumberWithCommas = function () {
        return this.each(function () {
            $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, '$1,'));
        });
    }

    $.fn.RemoveCommasFromNumber = function () {
        return this.each(function () {
            if ($(this).text().search(',') > -1) {
                $(this).text($(this).text().replace(/,/g, ''));
            }
        });
    }
}

function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate()
        r.moveEnd('character', o.value.length)
        if (r.text == '') return o.value.length
        return o.value.lastIndexOf(r.text)
    } else return o.selectionStart
}


function CancelShiftOperation(eventArgument) {
    eventArgument = eventArgument || window.event;

    if (eventArgument.keyCode == 16)
        isShiftPressed = false;
}

function ValidateNumericFields(keyCode, sender, isDecimalPlaceAllowed, numberOfDecimalPlaces) {
    if (keyCode == 16) {
        isShiftPressed = true;
        return false;
    }

    if (isShiftPressed)
        return false;

    var previousValue = sender.val();
    var caretPosition = getSelectionStart(sender.get(0));

    var ignore = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 190 && previousValue.indexOf('.') == -1 && isDecimalPlaceAllowed)
        || keyCode == 8 || keyCode == 9 || keyCode == 17 || keyCode == 18 || keyCode == 27
        || keyCode == 46 || (keyCode >= 37 && keyCode <= 40) || (keyCode >= 112 && keyCode <= 123)
        || (keyCode >= 96 && keyCode <= 105));

    if (!ignore)
        return false;

    if (previousValue.indexOf('.') > -1 && previousValue.substring(0, caretPosition).indexOf('.') > -1
        && typeof numberOfDecimalPlaces == 'number' && (keyCode >= 48 && keyCode <= 57)) {
        if (previousValue.substring(previousValue.indexOf('.') + 1).length == numberOfDecimalPlaces)
            return false;
    }

    return true;
}


function ValidateNumericNegative(keyCode, sender, isDecimalPlaceAllowed, numberOfDecimalPlaces) {
    if (keyCode == 16) {
        isShiftPressed = true;
        return false;
    }

    if (isShiftPressed)
        return false;

    var previousValue = sender.val();
    var caretPosition = getSelectionStart(sender.get(0));

    var ignore = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 190 && previousValue.indexOf('.') == -1 && isDecimalPlaceAllowed)
        || keyCode == 8 || keyCode == 9 || keyCode == 17 || keyCode == 18 || keyCode == 27
        || keyCode == 46 || (keyCode >= 37 && keyCode <= 40) || (keyCode >= 112 && keyCode <= 123)
        || (keyCode >= 96 && keyCode <= 105) || (keyCode == 189 && previousValue.indexOf('-') == -1) || (keyCode == 109 && previousValue.indexOf('-') == -1));

    if (!ignore)
        return false;

    if (previousValue.indexOf('.') > -1 && previousValue.substring(0, caretPosition).indexOf('.') > -1
        && typeof numberOfDecimalPlaces == 'number' && (keyCode >= 48 && keyCode <= 57)) {
        if (previousValue.substring(previousValue.indexOf('.') + 1).length == numberOfDecimalPlaces)
            return false;
    }

    return true;
}

function ValidateForm() {
    $("FORM").validate(
    {
        invalidHandler: function (form, validator) {
            if (validator.numberOfInvalids() > 0) {
                var message = '<ul>';

                for (var i = 0; i < validator.errorList.length; i++) {
                    message = message + '<li>' + validator.errorList[i].message + '</li>';
                }

                message = message + '</ul>';

                ShowHideValidationBox(true, message);
            }
            else {
                ShowHideValidationBox(false);
            }
        }
    });
}

var globalOKFunction;
var globalOKData;
var isCancel;

function ShowHideValidationBox(isShow, message, headerText, okFunction, okData) {
    if (isShow) {
        globalOKFunction = okFunction;
        globalOKData = okData;
    }

    ShowMessage(isShow, message, headerText, 'validation');
}

function ShowHideMessageBox(isShow, message, headerText, okFunction, okData) {
    if (isShow) {
        globalOKFunction = okFunction;
        globalOKData = okData;
    }

    ShowMessage(isShow, message, headerText, 'message');
}

function ShowHideConfirmationBox(isShow, message, headerText, okFunction, okData) {
    if (isShow) {
        globalOKFunction = okFunction;
        globalOKData = okData;
    }

    ShowMessage(isShow, message, headerText, 'confirmation');
}

function ShowMessage(isShow, message, headerText, messageType) {
    if (isShow) {
        $('.validation_messagebox_background').height(GetDocumentHeight());
        $('.validation_messagebox_background').width(GetDocumentWidth());

        switch (messageType) {
            case 'validation':
                headerText = (headerText == '' || null == headerText) ? 'The following errors occurred:' : headerText;
                $('.validation_messagebox').css('border-color', 'red');
                $('.validation_messagebox img.image-message').attr('src', '/Images/ikandi/images/images/error.gif');
                break;
            case 'message':
                headerText = (headerText == '' || null == headerText) ? 'Information:' : headerText;
                $('.validation_messagebox').css('border-color', 'blue');
                $('.validation_messagebox img.image-message').attr('src', '/Images/ikandi/images/info.png');
                break;
            case 'confirmation':
                headerText = (headerText == '' || null == headerText) ? 'Confirmation:' : headerText;
                $('.validation_messagebox').css('border-color', 'blue');
                $('.validation_messagebox img.image-message').attr('src', '/Images/ikandi/images/info.png');
                break;
        }

        if (messageType == 'confirmation') {
            $('.validation_messagebox div.message-button-box').css('display', 'none');
            $('.validation_messagebox div.confirmation-button-box').css('display', 'block');
        }
        else {
            $('.validation_messagebox div.message-button-box').css('display', 'block');
            $('.validation_messagebox div.confirmation-button-box').css('display', 'none');
        }

        $('.validation_messagebox span.header-text').html(headerText);
        $('.validation_messagebox div.validation-message').html(message);

        $('.validation_messagebox_background').show();
        $('.validation_messagebox').show();
    }
    else {
        ExecuteOKMessageMethod();

        $('.validation_messagebox_background').hide();
        $('.validation_messagebox').hide();

        $('.validation_messagebox').css('border-color', 'white');
        $('.validation_messagebox img.image-message').attr('src', '');
    }
}

function ExecuteOKMessageMethod() {
    if (globalOKFunction != undefined && !isCancel) {
        globalOKFunction(globalOKData);

        globalOKFunction = undefined;
        globalOKData = undefined;
    }
}

function DoForcePostBack() {
    __doPostBack('', '');
}

function GetDocumentHeight() {
    return Math.max(
        Math.max(document.body.scrollHeight, document.documentElement.scrollHeight),
        Math.max(document.body.offsetHeight, document.documentElement.offsetHeight),
        Math.max(document.body.clientHeight, document.documentElement.clientHeight));

}

function GetDocumentWidth() {
    return Math.max(
        Math.max(document.body.scrollWidth, document.documentElement.scrollWidth),
        Math.max(document.body.offsetWidth, document.documentElement.offsetWidth),
        Math.max(document.body.clientWidth, document.documentElement.clientWidth));

}

window.location.querystring = (function () {
    var collection = {};
    var qs = window.location.search;

    if (!qs) {
        return { toString: function () { return ""; } };
    }

    qs = decodeURI(qs.substring(1));

    var pairs = qs.split("&");

    for (var i = 0; i < pairs.length; i++) {
        if (!pairs[i]) {
            continue;
        }

        var seperatorPosition = pairs[i].indexOf("=");

        if (seperatorPosition == -1) {
            collection[pairs[i]] = "";
        }
        else {
            collection[pairs[i].substring(0, seperatorPosition)] = pairs[i].substr(seperatorPosition + 1);
        }
    }

    collection.toString = function () {
        return "?" + qs;
    };

    return collection;
})();

function getQueryString(qs) {
    var collection = {};

    if (qs == '' || qs == null)
        qs = window.location.search;

    if (!qs) {
        return null;
    }

    qs = decodeURI(qs.substring(1));

    var pairs = qs.split("&");

    for (var i = 0; i < pairs.length; i++) {
        if (!pairs[i]) {
            continue;
        }

        var seperatorPosition = pairs[i].indexOf("=");

        if (seperatorPosition == -1) {
            collection[pairs[i]] = "";
        }
        else {
            collection[pairs[i].substring(0, seperatorPosition)] = pairs[i].substr(seperatorPosition + 1);
        }
    }

    return collection;
}

function bindDropdown(proxyUrl, dropdownID, method, params, textMember, valueMember, addBlankOption, selectedValue, onPageError, onBind) {
    var proxy = new ServiceProxy(proxyUrl);
    proxy.invoke(method, params,
         function (items) {
             var dropdownBox = (dropdownID.indexOf(".") == 0) ? $(dropdownID) : $("#" + dropdownID);
             dropdownBox.empty();
             if (addBlankOption)
                 dropdownBox.append($("<option></option>").val("-1").html("Select ..."));
             $.each(items, function () {
                
                 dropdownBox.append($("<option></option>").val(this[valueMember]).html(this[textMember]));
             });

             if (selectedValue != null && selectedValue != '') {
                 if ((selectedValue + "").indexOf(",") == -1) {

                     dropdownBox.val(selectedValue);
                 }
                 else {
                     values = selectedValue.split(",");
                     dropdownBox.val(values);

                 }
             }

//             if (onBind != null)
//                 onBind();

         },
         onPageError, false, true);
}


function bindDropdownSeason(proxyUrl, dropdownID, method, params, textMember, valueMember, extraValue, addBlankOption, selectedValue, onPageError, onBind) {

    
    var proxy = new ServiceProxy(proxyUrl);
    proxy.invoke(method, params,
         function (items) {
             //  debugger;
             var dropdownBox = (dropdownID.indexOf(".") == 0) ? $(dropdownID) : $("#" + dropdownID);
             dropdownBox.empty();
             if (addBlankOption)
                 dropdownBox.append($("<option></option>").val("-1").html("Select ..."));
             $.each(items, function () {
                 dropdownBox.append($("<option></option>").val(this[valueMember]).html(this[textMember]));
                 if (this[extraValue] == 1 || this[extraValue] == "1") {
                     dropdownBox.val(this[valueMember]);
                 }
             });


//             if (onBind != null)
//                 onBind();

         },
         onPageError, false, true);
}

// Show workflow history
function showWorkflowHistory(instanceId) {
    proxy.invoke("GetWorkflowHistoryView", { InstanceID: instanceId }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}

// Show workflow history  
function showWorkflowHistory2(styleID, orderID, orderDetailID) {
    proxy.invoke("GetWorkflowHistoryView2", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}
var docctrl;
function GetMyTask(taskid, ctrl) {
   
    if (docctrl != null)
        docctrl.style.backgroundColor = "#FFFFFF"
    ctrl.style.backgroundColor = "#CCFFFF"
    docctrl = ctrl;
    $(".loadingimage").show();
    proxy.invoke("GetTaskByIdByDept", { TaskId: taskid, MyTask: 1 }, function (result) {
        $("#CentralDiv").html(result);
        $(".loadingimage").hide();
    }, onPageError, false, false);
}


//task notification
function GetMyTaskNotificaton(taskid, ctrl) {

    if (docctrl != null)
        docctrl.style.backgroundColor = "#FFFFFF"
    ctrl.style.backgroundColor = "#CCFFFF"
    docctrl = ctrl;
    $(".loadingimage").show();
    proxy.invoke("GetTaskByIdByDept", { TaskId: taskid, MyTask: 3 }, function (result) {
        $("#CentralDiv1").html(result);
        $(".loadingimage").hide();
    }, onPageError, false, false);
}

//Task Competion
function GetMyTaskComplete(taskid, ctrl) {

    if (docctrl != null)
        docctrl.style.backgroundColor = "#FFFFFF"
    ctrl.style.backgroundColor = "#CCFFFF"
    docctrl = ctrl;
    $(".loadingimage").show();
    proxy.invoke("GetTaskByIdByDept", { TaskId: taskid, MyTask: 4 }, function (result) {
        $("#CentralDiv2").html(result);
        $(".loadingimage").hide();
    }, onPageError, false, false);
}

function GetTeamTask(taskid, ctrl) {
    if (docctrl != null)
        docctrl.style.backgroundColor = "#FFFFFF"
    ctrl.style.backgroundColor = "#CCFFFF"
    docctrl = ctrl;
    $(".loadingimage").show();
    proxy.invoke("GetTaskByIdByDept", { TaskId: taskid, MyTask: 0 }, function (result) {
        $("#CentralDiv").html(result);
        $(".loadingimage").hide();
    }, onPageError, false, false);
}

function GetTeamTaskCount() {
    $(".teamtaskloadingimage").show();
    proxy.invoke("GetTeamTasks", {}, function (result) {
        $(".AllTeamTask").html(result);
        var val = $("#" + hfTeamTask).val();
        if (val != "0") {
            $(".TeamTaskcount").html($("#" + hfTeamTask).val());
            //$("#" + TotalTaskCount).html(parseInt($("#" + hfTeamTask).val()) + parseInt($("#" + MyTaskCount).html()));
            $("#" + TotalTaskCount).html(parseInt($("#" + hfTeamTask).val()) + parseInt($("#" + MyTaskCount).html()));
        }
        else {
            $("#teamtask").hide();
            $(".AllTeamTask").hide();
        }
        $(".teamtaskloadingimage").hide();
    }, onPageError, false, false);
}

//function GetMyTaskCount() {
//    $(".mytaskloadingimage").show();
//    proxy.invoke("GetMyTasks", {}, function (result) {
//        $(".AllMyTask").html(result);
//        $(".MyTaskCount").html($("#" + hfMyTask).val());
//        $("#" + TotalTaskCount).html(parseInt($("#" + MyTaskCount).html()));
//        $(".mytaskloadingimage").hide();
//    }, onPageError, false, false);
//}

function GetMOQAStatus(styleID, orderDetailID) {
    proxy.invoke("GetMOQAStatus", { StyleID: styleID, OrderDetailID: orderDetailID }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}
// Show shipment Offer Date  
function showShipmentOfferDate() {
    proxy.invoke("GetShipmentOfferDate", {}, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}

// Show Fabric Quality Popup
function showFabricQuality(fabricQualityID, elem) {
  
    proxy.invoke("GetFabricQualityView", { FabricQualityID: fabricQualityID }, function (result) {

        openQuickLayer(result, elem);

    }, onPageError, false, false);
}

// Show Fabric Quality Popup
function showAccessoryQuality(accQualityID, elem) {
    proxy.invoke("GetAccessoryQualityView", { AccessoryQualityID: accQualityID }, function (result) {

        openQuickLayer(result, elem);

    }, onPageError, false, false);
}

// Show Fabric Quality Popup
function showAccessoryInfo(accID, elem) {
    proxy.invoke("GetAccessoryInfoView", { AccessoryWorkingDetailID: accID }, function (result) {

        openQuickLayer(result, elem);

    }, onPageError, false, false);
}

function openQuickLayer(htmlContent, elem) {

    var x = getX(elem);
    var y = getY(elem);

    $("#quickviewLayer").find("#quickviewContent").html(htmlContent);
    $("#quickviewLayer").show();
    $("#quickviewLayer").css({ top: y - 40, left: x + 14 });
}


// client view

//function showClientDetails(ClientID,elem)
//{
// proxy.invoke("GetClientView", { ClientID: ClientID }, function(result) {

//        openQuickLayer(result, elem);

//    }, onPageError, false, false);
//}

function openQuickLayerFlexible(htmlContent) {

    var layer = $("#flexibleQuickviewLayer");
    layer.find("#flexibleQuickviewContent").html(htmlContent);
    layer.show();
    layer.css({ top: (screen.height - layer.height()) / 2, left: (screen.width - layer.width()) / 2 });
}

function closeFlexibleQuickLayer() {
    $("#flexibleQuickviewLayer").hide();
}

function closeQuickLayer() {
    $("#quickviewLayer").hide();
}

function showLinksPopup(OrderID, ClientID, prmThis) {
    var str = "?orderid=" + OrderID;
    $("a.hyp", "#main_content").each(function () {
        var link = $(this).attr("href");
        if (link.indexOf('?') > -1) {
            link = link.replace(link.substring(link.indexOf('?'), link.length), '')
        }
        $(this).attr("href", link + str)
    });

    var result = document.getElementById("links").innerHTML.replace("#CLIENTID#", ClientID);

    //jQuery.facebox(result);

    openQuickLayer(result, prmThis);

}


function showStitchingLinksPopup(OrderID, OrderDetailID, prmThis) {
    var str = "?orderid=" + OrderID;
    $("a.hyp", "#stitching_links").each(function () {
        var link = $(this).attr("href");

        if (link.indexOf('?') > -1 && link.indexOf('orderDetailID') == -1) {
            link = link.replace(link.substring(link.indexOf('?'), link.length), '')
        }

        if (link.indexOf('orderDetailID') == -1)
            $(this).attr("href", link + str);
    });

    var result = document.getElementById("stitching_links").innerHTML.replace("#ORDERDETAILID#", OrderDetailID);

    //jQuery.facebox(result);

    openQuickLayer(result, prmThis);

}


// Show Style Photo
function showStylePhoto(styleID, orderID, orderDetailID) {
    alert("111");
    proxy.invoke("GetStylePhotosView", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
        jQuery.facebox(result);

    }, onPageError, false, false);
}

//Yaten : New Facebox for StylePhote
function showStylePhotoWithOutScroll(styleID, orderID, orderDetailID) {

   
    proxy.invoke("GetStylePhotosView", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
        // jQuery.ImageFaceBox(result);
       
        jQuery.facebox(result);
        //debugger;
        $("#facebox").find(".content").css("max-height", "");
        
    }, onPageError, false, false);
}


function showRemarks2(Remarks) {

    //  debugger;
    $(".form_heading").html("Stories");
    $(".tempClass").html("Stories :");
    $(".divRemarks").show();
    $(".permission-text-remarks").hide();
    $("#btnSubmit").hide();
    $(".label-remarks", "#divRemarks").html("");
    if ($(".label-remarks", "#divRemarks")[0] != undefined) {
        $(".label-remarks", "#divRemarks")[0].innerHTML = "";
    }
    $(".label-remarks", "#divRemarks").html(Remarks);
}
function showRemarks3(Remarks) {

    var temp = Remarks;

    var intIndexOfMatch = temp.indexOf("$");
    while (intIndexOfMatch != -1) {
        temp = temp.replace("$", "'")
        intIndexOfMatch = temp.indexOf("$");
    }

    Remarks = temp;





    // Remarks = "Jatinder (19 Oct) first</br><span style=$color:blue;$><A href=$../../Uploads/RemarksFile/RadhaKrishn_&_gopies.jpg$ target=$_new$ >RadhaKrishn_&_gopies.jpg</A></span></br>Anne (21 Oct) sec</br><span style=$color:blue;$><A href=$../../Uploads/RemarksFile/Chrysanthemum.jpg$ target=$_new$ >Chrysanthemum.jpg</A></span>";
    // Remarks = Remarks.replace(/\$*/g, "'");
    //  Remarks = Remarks.replace("'", ""); 
    $(".form_heading").html("Remarks");
    $(".tempClass").html("Remarks :");
    $(".divRemarks").show();
    $(".permission-text-remarks").hide();
    $("#btnSubmit").hide();
    $(".label-remarks", "#divRemarks").html("");
    if ($(".label-remarks", "#divRemarks")[0] != undefined) {
        $(".label-remarks", "#divRemarks")[0].innerHTML = "";
    }
    $(".label-remarks", "#divRemarks").html(Remarks);
}
// for remarks
function showRemarks(Id1, Id2, Remarks, Type, ApplicationModuleName, Permission, IsHold) {
    //

    $(".divRemarks").show();

    if (Permission == 0) {
        $(".permission-text-remarks").hide();
        $("#btnSubmit").hide();
    }
    else {
        $(".permission-text-remarks").show();
        $("#btnSubmit").show();

    }

    // $(".divRemarks").show();
    $(".label-remarks", "#divRemarks").html("");
    if ($(".label-remarks", "#divRemarks")[0] != undefined) {
        $(".label-remarks", "#divRemarks")[0].innerHTML = "";
    }
    $(".label-remarks", "#divRemarks").html(Remarks);
    if (Type == 'MERCHANT_REMARKS' && ApplicationModuleName == 'LIABILITY') {
        $(".liabilityRaise").attr("style", "display:block");
    }
    else {
        $(".liabilityRaise").attr("style", "display:none");
    }

    $("#hdnId").val(Id1);
    $("#hdnId2").val(Id2);
    $("#hdntype").val(Type);
    $("#hdnApplicationModuleName").val(ApplicationModuleName);
    if (IsHold == "1" || IsHold == "2") {
        $("#hdnIsHold").val(IsHold);
    }
}

function closeMoRemarks() {
    $(".divRemarksMo").html("");
    $(".divRemarksMo").hide();
}

// Show MO Shipping PopUp
function showMoShippingInfo(styleId, remark) {
    proxy.invoke("GetMoShippingInfo", { styleId: styleId, remark: remark }, function (result) {
        $(".divRemarksMo").html(result);
        $(".divRemarksMo").show();
    }, onPageError, false, false);
}

function UpdateMoShippingRem(ids, rem, exfactory) {
    proxy.invoke("UpdateRemarksShipping", { Remarks: rem, Ids: ids, ExFactoryDate: exfactory }, function () {
        jQuery.facebox("Remarks have been submitted successfully");
        $(".divRemarksMo").html("");
        $(".divRemarksMo").hide();
        jQuery(document).trigger('close.facebox');
        $(".go").click();
    }, onPageError, false, false);
}


// for remarks
function showRemarks(Id1, Id2, Remarks, Type, ApplicationModuleName, Permission, IsHold, styleId) {

    $(".divRemarks").show();

    if (Permission == 0) {
        $(".permission-text-remarks").hide();
        $("#btnSubmit").hide();
    }
    else {
        $(".permission-text-remarks").show();
        $("#btnSubmit").show();
    }

    // $(".divRemarks").show();
    $(".label-remarks", "#divRemarks").html("");
    if ($(".label-remarks", "#divRemarks")[0] != undefined) {
        $(".label-remarks", "#divRemarks")[0].innerHTML = "";
    }
    $(".label-remarks", "#divRemarks").html(Remarks);
    if (Type == 'MERCHANT_REMARKS' && ApplicationModuleName == 'LIABILITY') {
        $(".liabilityRaise").attr("style", "display:block");
    }
    else {
        $(".liabilityRaise").attr("style", "display:none");
    }

    $("#hdnId").val(Id1);
    $("#hdnId2").val(Id2);
    $("#hdntype").val(Type);
    $("#hdnApplicationModuleName").val(ApplicationModuleName);
    if (IsHold == "1" || IsHold == "2") {
        $("#hdnIsHold").val(IsHold);
    }
}

function closeRemarks() {
    $(".text-remarks", "#divRemarks").val("");
    $(".divRemarks").hide();
}


function saveRemarks() {

    var id1 = $("#hdnId").val();
    var id2 = $("#hdnId2").val();
    var type = $("#hdntype").val();
    var isHold = $("#hdnIsHold").val();
    var applicationModuleName = $("#hdnApplicationModuleName").val();
    var remarks;
    var remark = $(".text-remarks", "#divRemarks").val();
    var lia1 = $(".lia1", "#divRemarks");
    var lia2 = $(".lia2", "#divRemarks");
    var liability = 0;
    if (lia1.attr("checked") == true)
        liability = parseInt(lia1.val());
    else if (lia2.attr("checked") == true) {
        liability = parseInt(lia2.val());
    }
    else {
        if (type == 'MERCHANT_REMARKS') {
            alert("Please select one of the two options");
            return;
        }
    }

    if (remark.indexOf("'") > -1) {
        while (remark.indexOf("'") > -1) {
            remark = remark.replace(/'/g, '');
        }
    }
    if (remark.indexOf('"') > -1) {
        while (remark.indexOf('"') > -1) {
            remark = remark.replace(/"/g, '');
        }
    }
    remarks = remark;

    var oldRemarks = $(".label-remarks", "#divRemarks").html();
    var date = new Date();

    if (type == 'MERCHANT_REMARKS' && applicationModuleName == 'LIABILITY') {
        proxy.invoke("InsertLiabilityMerchantRemarks", { OrderDetailID: id2, Remarks: remarks, Option: liability }, function () {
            $("#txtremarks").val("");
            jQuery.facebox("Remarks have been submitted successfully");
            $(".divRemarks").hide();
            jQuery(document).trigger('close.facebox');
            $(".go").click();
        }, onPageError, false, false);
    }
    else {

        // proxy.invoke("UpdateRemarks", { Id1: id1, Id2: id2, Remarks: remarks, Type: type, ApplicationModuleName: applicationModuleName }, function() {
        proxy.invoke("UpdateRemarks", { Id1: id1, Id2: id2, Remarks: remarks, Type: type, ApplicationModuleName: applicationModuleName }, function () {
            $(".label-remarks").html(oldRemarks + "<br/>" + ParseDateToDateWithDay(date) + ":" + remarks);
            $("#txtremarks").val("");

            if (remarks != "") {
                if (applicationModuleName == "SAMPLING_STATUS_FILE" && type == "SamplingStatusRemarks") {
                    $(".submit").click();
                }
                else if (applicationModuleName == "MANAGE_ORDER_FILE" && type == "SanjeevRemarks") {
                    $(".submit").click();
                }
                else if (applicationModuleName == "MANAGE_ORDER_FILE" && type == "MerchantNotes") {
                    $(".submit").click();
                }
                else {
                    $(".go").click();
                }
            }
            jQuery.facebox("Remarks have been submitted successfully");
            $(".divRemarks").hide();
            jQuery(document).trigger('close.facebox');
            $(".go").click();

        }, onPageError, false, false);
        if (isHold == "1")
            changeStatusToOnHold(id1, remarks);
        else if (isHold == "2")
            changeStatusToPrevious(id1, remarks);
    }


}
function getCurrentTime() {
    var time = new Date();
    return time;
}

function showFabricHistoryByPrintNumber(styleNumber) {

    proxy.invoke("GetPrintFabricHistoryView", { PrintNumber: styleNumber }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);

}


////Kuldeep
//function showFabricHistoryByPrintStyleId(styleNumber, StyleId) {
//    proxy.invoke("GetPrintFabricHistoryStyleId", { PrintNumber: styleNumber }, function (result) {
//        jQuery.facebox(result);
//    }, onPageError, false, false);

//}

////Kuldeep
//function showFabricHistoryByPrintNumber(styleNumber, StyleId) {

//    proxy.invoke("GetPrintFabricHistoryStyleId", { PrintNumber: styleNumber, parameter2: StyleId }, function (result) {
//        jQuery.facebox(result);
//    }, onPageError, false, false);
//}




function onPageError(error) {
    alert(error.Message + ' -- ' + error.detail);
}

/************ popup window functions ****/
function ShowPopupWindow(url, windowName, clientCallBackFunction, width, height) {
    //We call showModalDialog which will return true is the popup needs to indicate that the host window needs to refresh
    //If it returns true, we will call the clientCallbackFunction (If it was passed in as a parameter)

    try {
        //add background element
        var popupBackground = $('<div></div>').attr('id', 'popupBackground');
        popupBackground.addClass('popupBackground').prependTo('body');
        popupBackground.height(GetDocumentHeight());
        popupBackground.width(GetDocumentWidth());

        var returnVal = window.showModalDialog(url, windowName, "dialogHeight:" + height + "px; dialogWidth:" + width + "px; help:no; scroll:yes; toolbar:no; titlebar:no; center:yes; resizable:yes; status:no");
        //remove background element
        $('#popupBackground').remove();


        //if return value was true and callback function
        if (returnVal != undefined && clientCallBackFunction != null && clientCallBackFunction != '')
            window[clientCallBackFunction](returnVal);
        if (windowName = "ShipmentOffer") {
            window[clientCallBackFunction](true);
        }
        else
            return returnVal;
    }
    catch (err) {
        return false;
    }
}

/*****************Redirection Method*************/
function RedirectToUrl(url) {
    window.location = url;
}

/* Get the X location of object */
function getX(el) {
    var x = 0;

    while (el != null) {
        x += el.offsetLeft;
        el = el.offsetParent;
    }
    return x;
}

/* Get the Y location of object */
function getY(el) {
    var y = 0;

    while (el != null) {
        y += el.offsetTop;
        el = el.offsetParent;
    }
    return y;
}

function isNumeric(data) {
    return parseFloat(data) == data;
}

function PadDigits(n, totalDigits) {
    n = n.toString();
    var pd = '';
    if (totalDigits > n.length) {
        for (i = 0; i < (totalDigits - n.length); i++) {
            pd += '0';
        }
    }
    return pd + n.toString();
}


/*********************Method to Check if Values on Page Changed*************************/
function CheckIfValuesChanged(containderControl) {
    var textBoxCollection = containderControl.find('input[type=text]:not(.do-not-allow-typing)');
    var dropDownCollection = containderControl.find('select');
    var checkBoxCollection = containderControl.find('input[type=checkbox]');
    var radioButtonCollection = containderControl.find('input[type=radio]');

    for (var i = 0; i < textBoxCollection.length; i++) {
        if (isNumeric(textBoxCollection[i].value)) {
            if (parseFloat(textBoxCollection[i].value) != parseFloat(textBoxCollection[i].defaultValue))
                return true;
        }
        else if (textBoxCollection[i].value != textBoxCollection[i].defaultValue) {
            return true;
        }
    }

    for (var i = 0; i < dropDownCollection.length; i++) {
        if (!dropDownCollection[i].options[dropDownCollection[i].selectedIndex].defaultSelected) {
            //alert("dd -" +dropDownCollection[i].options[dropDownCollection[i].selectedIndex].defaultSelected)
            return true;
        }
    }

    for (var i = 0; i < checkBoxCollection.length; i++) {
        if (checkBoxCollection[i].checked != checkBoxCollection[i].defaultChecked) {
            //alert("checkBoxCollection -" +checkBoxCollection[i].value);
            return true;
        }
    }

    for (var i = 0; i < radioButtonCollection.length; i++) {
        if (radioButtonCollection[i].checked != radioButtonCollection[i].defaultChecked) {
            // alert("radioButtonCollection -" +radioButtonCollection[i].value);
            return true;
        }
    }

    return false;
}

/***** To make the height same of two or more elements like div *****/
function equalHeight(group) {
    try {
        tallest = 0;
        group.each(function () {
            thisHeight = $(this).height();
            if (thisHeight > tallest) {
                tallest = thisHeight;
            }
        });
        group.height(tallest);
    }
    catch (e) { }
}

/************* Use method to show ineger value in comma seprated format***/
function FormatingTotalQuantity(varTotalQuantity) {
    var newFormatTotalQuantity = '';
    for (i = 1; i <= varTotalQuantity.toString().length; i++) {
        if (i > 3 && i % 3 == 1) {
            newFormatTotalQuantity = varTotalQuantity.toString().substr(varTotalQuantity.toString().length - i, 1) + ',' + newFormatTotalQuantity;
        }
        else {
            newFormatTotalQuantity = varTotalQuantity.toString().substr(varTotalQuantity.toString().length - i, 1) + newFormatTotalQuantity;
        }
    }
    return newFormatTotalQuantity;
}

/************Date Formating Methods*******************/

function ParseDateToSimpleDate(dateObject) {

    var index = dateObject.indexOf('(');
    if (index > -1) {
        dateObject = $.trim(dateObject.substring(0, index));
    }

    dateObject = Date.parseExact(dateObject, ['d MMM yy', 'M/d/yyyy', 'M/d/yy']);

    return dateObject;
}

function ParseDateToDateWithDay(dateObject) {

    dateObject = dateObject.toString('dd MMM yy (ddd)');
    return dateObject;
}



function DisableAllFields(containerID) {
    disableFields = true;

    /*
    $('#'+containerID).find("input,textarea,select").each(function(){
      
    //var className = $(this).attr("class");      
    //if(className.indexOf("do-not-allow-typing") < 0)
      
    $(this).attr("disabled", "true");
     
    }); 
    
    $('.do-not-disable').attr("disabled", "false");    
    $('.do-not-disable').removeAttr("disabled");
    
    */

    // hide the button too
    $(".save", '#main_content').hide();
    $(".submit", '#main_content').hide();
    $(".add", '#main_content').hide();
    //$(".print",'#main_content').hide();
    $(".agree", '#main_content').hide();
    $(".disagree", '#main_content').hide();
    $(".summary", '#main_content').hide();
    $(".add-more", '#main_content').hide();
    $(".clear", '#main_content').hide();
    $(".request_cost_confirmation", '#main_content').hide();
    $(".cost_confirmed", '#main_content').hide();
    $(".update_order_price", '#main_content').hide();
}

function PrintPDF(Url, height, width) {
    //$.showprogress();
    
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
            //$.hideprogress();
            window.open(result);
        }
    });

    return false;
}

function PrintPDFQueryString(Url, height, width, QS1) {
    //$.showprogress();
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

    if (QS1 != '' && QS1 != null) {
        if (window.location.querystring.toString() == '') {
            url = url + QS1.toString().replace("&", "?");
        }
        else {
            url = url + window.location.querystring.toString() + QS1.toString();
        }
    }

    if (url.indexOf('/') != 0)
        url = '/' + url;



    //alert(wd + " - " + ht);
    proxy.invoke("GeneratePDF", { Url: url, Width: wd, Height: ht }, function (result) {

        if ($.trim(result) == '') {
            //$.hideprogress();
            jQuery.facebox("Some error occured on the server, please try again later.");
        }
        else {
            //$.hideprogress();
            window.open(result);
        }
    });

    return false;
}

function PrintPDFQueryStringWithMerge(Url, height, width, QS1) {
    //$.showprogress();
  
    var url;
    var ht = 1700;
    var wd = 1150;
    //    var ht = parseInt($(document).height()) - 200;
    //    var wd = parseInt($(document).width()) - 100;

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

    if (QS1 != '' && QS1 != null) {
        if (window.location.querystring.toString() == '') {
            url = url + QS1.toString().replace("&", "?");
        }
        else {
            url = url + window.location.querystring.toString() + QS1.toString();
        }
    }

    if (url.indexOf('/') != 0)
        url = '/' + url;



    //alert(wd + " - " + ht);
    proxy.invoke("GenerateMergePDF", { Url: url, Width: wd, Height: ht }, function (result) {
        
        if ($.trim(result) == '') {
            //$.hideprogress();
            jQuery.facebox("Some error occured on the server, please try again later.");
        }
        else {
            //$.hideprogress();
            window.open(result);
        }
    });

    return false;
}

function CleanHtml(sourceHtml) {

    var elementForPrint;
    var elementForPrintText;
    var defaultValue;
    var allMainTableSelectTags = $(sourceHtml).find('.order_form_table select').filter(function (e) { return ($(this).css('display') != 'none'); });
    var allBreakdownSelectTags = $(sourceHtml).find('#tableOrderDetail select').filter(function (e) { return ($(this).css('display') != 'none'); });

    var allMainTableInputTextTags = $(sourceHtml).find('.order_form_table input[type=text]');
    var allBreakdownInputTextTags = $(sourceHtml).find('#tableOrderDetail input[type=text]');

    var allTextAreaTags = $(sourceHtml).find('textarea').filter(function (e) { return ($(this).css('display') != 'none'); });
    var allInputButonTags = $(sourceHtml).find('input[type=button]').filter(function (e) { return ($(this).css('display') != 'none'); });
    var allInputSubmitTags = $(sourceHtml).find('input[type=submit]').filter(function (e) { return ($(this).css('display') != 'none'); });
    var allHiddenfields = $(sourceHtml).find('input[type=hidden]');
    var allImages = $(sourceHtml).find('img').filter(":not(.order_form_table img)");
    var ShowImages = $(sourceHtml).find('.order_form_table img');
    var allHtmlFile = $(sourceHtml).find('input[type=file]').filter(function (e) { return ($(this).css('display') != 'none'); });
    var allHyperLink = $(sourceHtml).find('#tableOrderDetail a.to-remove');
    var allRequiredFieldValidator = $(sourceHtml).find('span.rfv');
    var allBreakdownTd = $(sourceHtml).find('#tableOrderDetail td.headings');
    var allBreakdownTdToRemove = $(sourceHtml).find('#tableOrderDetail td.to-remove');
    var allMainTableTd = $(sourceHtml).find('.order_form_table td');
    var RemarksTextArea = $(sourceHtml).find('textarea.txtRem');
    var allSpan = $(sourceHtml).find('span').filter(":not(.rfv)");
    $(sourceHtml).find('.add-more').remove();


    allMainTableSelectTags.each(function () {
        var selectedIndex = $(this).attr('selectedIndex');
        var selectedText = (selectedIndex == 0) ? '' : ($('option', $(this))[selectedIndex].text);
        var selectedDropdownID = $(this).attr('id');
        var selectedValue = $("#" + selectedDropdownID + " option:selected").text();
        if ($(this).attr('class') == 'changed-dropdown') {
            $(this).parents("td").css('background-color', '#ffff9c');
            $(this).parents("td").css('text-align', 'center');
            elementForPrint = '<div style="text-align: left; background-color: #ffff9c; text-transform: uppercase; color : ' + $(this).css('color') + '">' + selectedValue + " (was " + selectedText + " )" + '</div>';
            $(this).replaceWith(elementForPrint);

        }
        else {
            elementForPrint = '<div style="text-align: left; text-transform: uppercase; color : ' + $(this).css('color') + '">' + selectedValue + '</div>';
            $(this).replaceWith(elementForPrint);

        }
    });

    allBreakdownSelectTags.each(function () {
        var selectedIndex = $(this).attr('selectedIndex');
        var selectedText = (selectedIndex == 0) ? '' : ($('option', $(this))[selectedIndex].text);
        var selectedDropdownID = $(this).attr('id');
        var selectedValue = $("#" + selectedDropdownID + " option:selected").text();
        if ($(this).attr('class') == 'changed-dropdown') {
            $(this).parents("td").css('background-color', '#ffff9c');
            $(this).parents("td").css('text-align', 'center');
            elementForPrint = '<div style="text-align: center; background-color: #ffff9c; text-transform: uppercase; color : ' + $(this).css('color') + '">' + selectedValue + " (was " + selectedText + " )" + '</div>';
            $(this).replaceWith(elementForPrint);

        }
        else {
            elementForPrint = '<div style="text-align: center; text-transform: uppercase; color : ' + $(this).css('color') + '">' + selectedValue + '</div>';
            $(this).replaceWith(elementForPrint);

        }
    });

    allMainTableInputTextTags.css('border', 'none');

    allMainTableInputTextTags.each(function () {
        if ($(this).val().indexOf(",") > -1) {
            $(this).val($(this).val().replace(",", ""));
        }

        var selectedText = $(this).val();

        if (isNumeric((this).value)) {
            parseFloat((this).defaultValue)
            if (parseFloat((this).value) != parseFloat((this).defaultValue)) {
                $(this).parents("td").css('background-color', '#ffff9c');
                $(this).parents("td").css('text-align', 'center');

                defaultValue = (this).defaultValue;
                elementForPrintText = '<div style="text-align: left; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + " (was " + defaultValue + " )" + '</div>';
                $(this).replaceWith(elementForPrintText);

            }

            else {
                elementForPrintText = '<div style="text-align: left; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + '</div>';
                $(this).replaceWith(elementForPrintText);
            }

        }
        else if ((this).value == (this).defaultValue) {
            elementForPrintText = '<div style="text-align: left; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + '</div>';
            $(this).replaceWith(elementForPrintText);

        }
        else if ((this).value != (this).defaultValue) {
            $(this).parents("td").css('background-color', '#ffff9c');
            $(this).parents("td").css('text-align', 'center');
            defaultValue = (this).defaultValue;
            elementForPrintText = '<div style="text-align: left; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + " (was " + defaultValue + " )" + '</div>';
            $(this).replaceWith(elementForPrintText);


        }

    });

    allBreakdownInputTextTags.css('border', 'none');

    allBreakdownInputTextTags.each(function () {
        if ($(this).val().indexOf(",") > -1) {
            $(this).val($(this).val().replace(",", ""));
        }

        var selectedText = $(this).val();

        if (isNumeric((this).value)) {
            parseFloat((this).defaultValue)
            if (parseFloat((this).value) != parseFloat((this).defaultValue)) {
                $(this).parents("td").css('background-color', '#ffff9c');
                $(this).parents("td").css('text-align', 'center');

                defaultValue = (this).defaultValue;
                elementForPrintText = '<div style="text-align: center; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + " (was " + defaultValue + " )" + '</div>';
                $(this).replaceWith(elementForPrintText);

            }

            else {
                elementForPrintText = '<div style="text-align: center; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + '</div>';
                $(this).replaceWith(elementForPrintText);
            }

        }
        else if ((this).value == (this).defaultValue) {
            elementForPrintText = '<div style="text-align: center; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + '</div>';
            $(this).replaceWith(elementForPrintText);

        }
        else if ((this).value != (this).defaultValue) {
            $(this).parents("td").css('background-color', '#ffff9c');
            $(this).parents("td").css('text-align', 'center');
            defaultValue = (this).defaultValue;
            elementForPrintText = '<div style="text-align: center; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + " (was " + defaultValue + " )" + '</div>';
            $(this).replaceWith(elementForPrintText);


        }

    });

    allSpan.each(function () {
        var selectedText = $(this).html();
        elementForPrintText = '<div style="text-align: left; text-transform: uppercase; color: ' + '#0000ff' + '">' + selectedText + '</div>';
        $(this).replaceWith(elementForPrintText);
    });


    RemarksTextArea.each(function () {
        var selectedText = $(this).val();
        elementForPrintText = '<div class="' + $(this).attr('className') + '" style="width: ' + '50px' + '; text-align: left; text-transform: uppercase; color: text-transform: uppercase' + '#0000ff' + '">' + selectedText + '</div>';
        $(this).replaceWith(elementForPrintText);
    });

    allBreakdownTd.each(function () {
        $(this).css('background-color', '#F9DDF4');
        $(this).css('border', '1px solid black');
        $(this).css('color', 'black');
        $(this).css('padding', '10px');
        $(this).css('text-align', 'center');
        $(this).css('text-transform', 'uppercase');
    });

    allMainTableTd.each(function () {

        //$(this).css('border','1px solid black');
        $(this).css('color', 'black');
        $(this).css('padding', '10px');
        $(this).css('text-align', 'left');
        $(this).css('text-transform', 'uppercase');

    });

    ShowImages.each(function () {
        var src = $(this).attr("src");
        if (src == '') {
            $(this).remove();
        }
        var baseUrl = "http://" + window.location.hostname + ":" + window.location.port;
        src = baseUrl + src;
        $(this).attr("src", src);

    });

    allTextAreaTags.css('border', 'none');
    allInputButonTags.remove();
    allInputSubmitTags.remove();
    allImages.remove();
    allHtmlFile.remove();
    allHyperLink.remove();
    allRequiredFieldValidator.remove();
    //allHiddenfields.remove();
    allBreakdownTdToRemove.remove();

    return sourceHtml.html();
}


function changeStatusToOnHold(orderDetailId, remarks) {


    //    var hold = confirm("ARE YOU SURE, YOU WANT TO PLACE THIS ORDER ON HOLD?");

    //    if (hold) {
    proxy.invoke("ChangeStatusToOnHold", { orderDetailId: orderDetailId, remarks: remarks }, function (result) {
        if (result == true) {
            jQuery.facebox("Order placed on hold.");
            location.reload();
        }
        else {
            jQuery.facebox("Some error occured on the server, please try again later.");
        }
    });
    //    }
    return false;
}



function GetUrlWithDummyQueryString1(location) {
    var curDate = new Date()

    if (location.indexOf('?') == -1) {
        return location + '?t=' + curDate.getTime();
    }
    else {
        if (location.indexOf('?t=') > -1) {
            return location + 't=' + curDate.getTime();
        }
        else if (location.indexOf('&t=') == -1) {

        }
        else {
            location = location.href.replace(location.search, '');
            return location + 't=' + curDate.getTime();
        }
    }
}

function GetUrlWithDummyQueryString(actualUrl, queryString, value) {
    if (queryString == undefined || queryString == null || queryString == '')
        queryString = 't';

    if (value == undefined || value == null || value == '') {
        var curDate = new Date();
        value = curDate.getTime();
    }

    var urlRegex = new RegExp("([?|&])" + queryString + "=.*?(&|$)", "i");

    if (actualUrl.match(urlRegex)) {
        return actualUrl.replace(urlRegex, '$1' + queryString + "=" + value + '$2');
    }
    else {
        if (actualUrl.indexOf('?') == -1)
            return actualUrl + '?' + queryString + "=" + value;
        else
            return actualUrl + '&' + queryString + "=" + value;
    }
}


// show fabric dates popup

function showFabricPopup(StyleID, OrderDetailID, OrderID, ClientID, Fabric1, Fabric2, Fabric3, Fabric4, Fabric1Details, Fabric2Details, Fabric3Details, Fabric4Details) {
    if (Fabric1.indexOf("&&") > -1) {
        while (Fabric1.indexOf("&&") > -1) {
            Fabric1 = Fabric1.replace("&&", '"');
        }
    }
    if (Fabric2.indexOf("&&") > -1) {
        while (Fabric2.indexOf("&&") > -1) {
            Fabric2 = Fabric2.replace("&&", '"');
        }
    }
    if (Fabric3.indexOf("&&") > -1) {
        while (Fabric3.indexOf("&&") > -1) {
            Fabric3 = Fabric3.replace("&&", '"');
        }
    }
    if (Fabric4.indexOf("&&") > -1) {
        while (Fabric4.indexOf("&&") > -1) {
            Fabric4 = Fabric4.replace("&&", '"');
        }
    }
    proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID: StyleID, OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}


function changeStatusToPrevious(orderDetailId, remarks) {
    //    var unHold = confirm("ARE YOU SURE, YOU WANT TO UNHOLD THIS ORDER?");

    //    if (unHold) {
    proxy.invoke("ChangeStatusToPrevious", { orderDetailId: orderDetailId, remarks: remarks }, function (result) {
        if (result == true) {
            jQuery.facebox("Order unholded.");
            location.reload();
        }
        else {
            jQuery.facebox("Some error occured on the server, please try again later.");
        }
    });
    //    }
    return false;
}


function showFabricAccessoryPhoto(Id, Type) {
    proxy.invoke("GetFabricAccessoryPhotosView", { ID: Id, Type: Type }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}


function showMOCutStitchPackHistoryPopup(OrderDetailID, Type) {

    proxy.invoke("ShowMOCutStitchPackHistoryPopup", { OrderDetailId: OrderDetailID, Type: Type }, function (result) {
        jQuery.facebox(result);
    }, onPageError, false, false);
}


function showClientDetailsPopup(ClientID) {

    proxy.invoke("ShowClientDetailsPopup", { ClientId: ClientID }, function (result) {
        //openQuickLayerFlexible(result);
        jQuery.facebox(result);
    }, onPageError, false, false);
}

function addItemsToCheckBoxListControl(textValue, valueValue, ctrlClientID, isChecked) {

    var tableRef = document.getElementById(ctrlClientID);


    var tableRow = tableRef.insertRow();
    var tableCell = tableRow.insertCell();

    var checkBoxRef = document.createElement('input');
    var labelRef = document.createElement('label');

    checkBoxRef.type = 'checkbox';
    labelRef.innerHTML = textValue;
    checkBoxRef.value = valueValue;
    checkBoxRef.mainValue = valueValue;
    checkBoxRef.checked = checkBoxRef.defaultChecked = isChecked;

    checkBoxRef.name = "cbListDepartmentID";

    tableCell.appendChild(checkBoxRef);
    tableCell.appendChild(labelRef);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function alpha(e) {
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8);
}

function validateEmail(email) {
    var emailPattern = /^[a-zA-Z0-9.-_]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,4}$/;

    return emailPattern.test(email);
}

jQuery.expr[':'].regex = function (elem, index, match) {
    var matchParams = match[3].split(','),
        validLabels = /^(data|css):/,
        attr = {
            method: matchParams[0].match(validLabels) ?
                        matchParams[0].split(':')[0] : 'attr',
            property: matchParams.shift().replace(validLabels, '')
        },
        regexFlags = 'ig',
        regex = new RegExp(matchParams.join('').replace(/^\s+|\s+$/g, ''), regexFlags);
    return regex.test(jQuery(elem)[attr.method](attr.property));
}

function floatValidation(e, control) {
    try {
        if (e.keyCode == 46) {
            var patt1 = new RegExp("\\.");
            var ch = patt1.exec(control.value);
            if (ch == ".") {
                e.keyCode = 0;
            }
        }
        else if ((e.keyCode >= 48 && e.keyCode <= 57) || e.keyCode == 8)//Numbers or BackSpace
        {
            if (control.value.indexOf('.') != -1)//. Exisist in TextBox 
            {
                var pointIndex = control.value.indexOf('.');
                var beforePoint = control.value.substring(0, pointIndex);
                var afterPoint = control.value.substring(pointIndex + 1);
                var iCaretPos = 0;
                if (document.selection) {
                    if (control.type == 'text') // textbox
                    {
                        var selectionRange = document.selection.createRange();
                        selectionRange.moveStart('character', -control.value.length);
                        iCaretPos = selectionRange.text.length;
                    }
                }
                if (iCaretPos > pointIndex && afterPoint.length >= 2) {
                    e.keyCode = 0;
                }
                else if (iCaretPos <= pointIndex && beforePoint.length >= 7) {
                    e.keyCode = 0;
                }
            }
            else//. Not Exisist in TextBox
            {
                if (control.value.length >= 7) {
                    e.keyCode = 0;
                }
            }
        }
        else {
            e.keyCode = 0;
        }
    } catch (e) { }
}

function setCaretPosition(ctrl, pos) {
    try {
        if (ctrl.setSelectionRange) {
            ctrl.focus();
            ctrl.setSelectionRange(pos, pos);
        }
        else if (ctrl.createTextRange) {
            var range = ctrl.createTextRange();
            range.collapse(true);
            range.moveEnd('character', pos);
            range.moveStart('character', pos);
            range.select();
        }
    } catch (e) { }
}

function validate() {
    var point_pressed = event.srcElement.value.indexOf('.') ? true : false;
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9 && !point_pressed)) {

    }
    else event.keyCode = 0; //Block the key code.
}

function check_float(e, field) {
    try {
        if (!(((e.keyCode >= 48) && (e.keyCode <= 57)) || (e.keyCode == 46))) {
            e.keyCode = 0;
        }
        if (e.keyCode == 46) {
            var patt1 = new RegExp("\\.");
            var ch = patt1.exec(field);
            if (ch == ".") {
                e.keyCode = 0;
            }
        }
    } catch (e) { }
}


// tooltip codes

this.tooltipdb1 = function () {
    /* CONFIG */
    xOffset = 10;
    yOffset = 20;
    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result		
    /* END CONFIG */
    $("a.tooltipdb1").hover(function (e) {
        this.t = this.title;
        this.title = "";
        $("body").append("<p id='tooltipdb1'>" + tooltioSplit(this.t) + "</p>");
        $("#tooltipdb1")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
    },
	function () {
	    this.title = this.t;
	    $("#tooltipdb1").remove();
	});
    $("a.tooltipdb1").mousemove(function (e) {
        $("#tooltipdb1")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
};



// starting the script on page load
$(document).ready(function () {
    tooltipdb1();
});

function tooltioSplit(t) {
    //debugger;
    var str = "";
    if (t.length > 70) {
        var ss = t.split(" ");
        var incr = 1;
        for (var i = 0; i < ss.length; i++) {
            if (str.length > (incr * 70)) {
                str += "<br/>";
                incr++;
            }
            str += ss[i] + " ";
        }
    } else
        str = t;
    return str;
}
// end tooltip codes

var DateDiff = {

    inDays: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();

        return parseInt((t2 - t1) / (24 * 3600 * 1000));
    },

    inWeeks: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();

        return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
    },

    inMonths: function (d1, d2) {
        var d1Y = d1.getFullYear();
        var d2Y = d2.getFullYear();
        var d1M = d1.getMonth();
        var d2M = d2.getMonth();

        return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
    },

    inYears: function (d1, d2) {
        return d2.getFullYear() - d1.getFullYear();
    }
}
