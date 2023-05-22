<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RiskAnalysis.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.RiskAnalysis" %>

<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(document).ready(function () {
        var hdnEnableFalse = $("#<%=hdnEnableFalse.ClientID%>").val();

        if (hdnEnableFalse == 1) {
            $(".iSlnkHide").addClass("iSEnable");
            (".txtReadonly").setAttribute("readonly", "true");
        }
        else {
//            removeClass("iSEnable iSEnable").addClass("ShowClass");
        }

    });

    function EnableDisableFields() {
        var hdnEnableFalse = $("#<%=hdnEnableFalse.ClientID%>").val();

        if (hdnEnableFalse == 1) {
            $(".iSlnkHide").addClass("iSEnable");
            (".txtReadonly").setAttribute("readonly", "true");
        }
        else {
//            removeClass("iSEnable iSEnable").addClass("ShowClass");
        }
    }

    function RiskAnalysis_CreateNew() {
       
        window.document.body.disabled = false;
        document.getElementById('<%=hdnRiskCreateNew.ClientID%>').value = "1";
        document.getElementById('<%=hdnRiskReUse.ClientID%>').value = "0";
        document.getElementById('<%=hdnRiskNewRef.ClientID%>').value = "0";
        $(".btnRisk").click();
    }


    function RiskAnalysis_NewRefrence(NewStyleID, NewStyleNumber) {
       
        window.document.body.disabled = false;
        document.getElementById('<%=hdnRiskNewRef.ClientID%>').value = "1";
        document.getElementById('<%=hdnRiskCreateNew.ClientID%>').value = "0";
        document.getElementById('<%=hdnRiskReUse.ClientID%>').value = "0";
        document.getElementById('<%=hdnRiskStyleId.ClientID%>').value = NewStyleID;
        document.getElementById('<%=hdnRiskStyleNumber.ClientID%>').value = NewStyleNumber;
        $(".btnRisk").click();

    }

    function RiskAnalysis_ReUse(ReUseStyleID, ReUseStyleNumber) {
       
        window.document.body.disabled = false;
        document.getElementById('<%=hdnRiskReUse.ClientID%>').value = "1";
        document.getElementById('<%=hdnRiskCreateNew.ClientID%>').value = "0";
        document.getElementById('<%=hdnRiskNewRef.ClientID%>').value = "0";
        document.getElementById('<%=hdnRiskStyleId.ClientID%>').value = ReUseStyleID;
        document.getElementById('<%=hdnRiskStyleNumber.ClientID%>').value = ReUseStyleNumber;
        $(".btnRisk").click();

    }

    function OpenPopupForRiskAnlalysis(StyleCodeVirsion) {
               
        var StyleId = -1;
        var StyleNumber = StyleCodeVirsion;
        var ClientId = '<%=this.strClientId %>';
        var DeptId = '<%=this.DepartmentId %>';

        var url = '../../Internal/OrderProcessing/RiskAnalysisPopupForNew.aspx?styleid=' + StyleId + '&stylenumber=' + StyleNumber + '&ClientID=' + ClientId + '&DeptId=' + DeptId + '';
        window.open(url, '_blank', 'height=500,width=700,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }


    function AddFactoryRepresentativeRisk() {
       
        var FactorycounterRisk = parseInt($('#<%= hdnFactoryCounterRisk.ClientID %>').val());
        if (jQuery.trim($('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val()) != '') {
            var objIds = '<%=hdnFactoryRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnFactoryRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnFactoryIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnFactoryIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnFactoryIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val('');
                            $("#hdnFactoryIdRisk").val('0');
                            $("#hdnFactoryNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnFactoryNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnFactoryNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnFactoryNameRisk").val();
                }
            }
            else {
                if ((strNames) == '') {
                    strIds = 0;
                    strNames = $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val();
                }
                else {
                    strIds = strIds + ',' + 0;
                    strNames = strNames + ',' + $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val();
                }
            }

            var FactoryRepresentativeId = $("#hdnFactoryIdRisk").val();
            var FactoryRepresentativeName = $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val();
            if ($("#" + objNames).val().indexOf($('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val()) == -1) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvFactoryRepresentativeRisk' + FactorycounterRisk);
                if (FactorycounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val() + ' <a onclick="DeleteFactoryRepresentativeRisk(' + FactorycounterRisk + ', ' + FactoryRepresentativeId + ', \'' + FactoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val() + ' <a onclick="DeleteFactoryRepresentativeRisk(' + FactorycounterRisk + ', ' + FactoryRepresentativeId + ', \'' + FactoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvFactoryRepresentativeValuesRisk.ClientID %>");

                $("#" + objIds).val(strIds);
                $("#" + objNames).val(strNames);

                $("#hdnFactoryIdRisk").val('0');
                $("#hdnFactoryNameRisk").val('');
            }
            else {
                alert("This Representative already exist")
            }
            $('#<%= txtFactoryRepresentitiveRisk.ClientID %>').val('');
            FactorycounterRisk++;

        }
        else {
            alert("Please enter Factory Representative.")
        }
    }


    function Checkvalidation(elem) {
        str = elem.value;
        if (str.match(/([\<])([^\>]{1,})*([\>])/i) == null) {
        }
        else {
            alert("HTML Tag Not Allowed");
            elem.value = elem.defaultValue;
            return false;
        }
    }

    function CheckRisk(seq, obj) {
       
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth(); //January is 0!
        var MMM = GetMonthName(mm);
        var yyyy = today.getFullYear();
        var TodayDate = dd + '-' + MMM + '-' + yyyy;
        if (seq == '1') {
            var lblChkAcMgrDate = '<%=lblChkAcMgrDate.ClientID %>';
            if (obj.checked) {
                $("#" + lblChkAcMgrDate).html(TodayDate);
                obj.checked == true;
            }
            else {
                $("#" + lblChkAcMgrDate).html('');
                obj.checked == false;
            }

        }

        if (seq == '3') {
            var lblChkQaMgrDate = '<%=lblChkQaMgrDate.ClientID %>';
            $("#" + lblChkQaMgrDate).html(TodayDate);
        }
        return false;
    }
    function GetMonthName(seq) {
        var Month;
        if (seq == 1) {
            Month = "Jan";
        }
        if (seq == 2) {
            Month = "Feb";
        }
        if (seq == 3) {
            Month = "Mar";
        }
        if (seq == 4) {
            Month = "Apr";
        }
        if (seq == 5) {
            Month = "May";
        }
        if (seq == 6) {
            Month = "Jun";
        }
        if (seq == 7) {
            Month = "Jul";
        }
        if (seq == 8) {
            Month = "Aug";
        }
        if (seq == 9) {
            Month = "Sep";
        }
        if (seq == 10) {
            Month = "Oct";
        }
        if (seq == 11) {
            Month = "Nov";
        }
        if (seq == 12) {
            Month = "Dec";
        }
        return Month;
    }


    function DisableSubmit() {
        
        var btn = '<%=btnSubmit.ClientID %>';
        document.getElementById(btn).disabled = true;
    }

    function AddRepresentative1(flag) {

        $(".FactoryRepresentitive", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Factory", { dataType: "xml", datakey: "string", max: 100 });
        $(".QaRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_QA", { dataType: "xml", datakey: "string", max: 100 });
        $(".MerchandiserRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Merchandiser", { dataType: "xml", datakey: "string", max: 100 });

        $(".IERepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_IE", { dataType: "xml", datakey: "string", max: 100 });
        $(".SamplingRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Sampling", { dataType: "xml", datakey: "string", max: 100 });
        $(".FabricRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Fabric", { dataType: "xml", datakey: "string", max: 100 });
        $(".AccessoryRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Accessory", { dataType: "xml", datakey: "string", max: 100 });
        $(".OutRepresentative", "#main_content").autocomplete("/Webservices/iKandiService.asmx/GetUserName_ByDptID_Out", { dataType: "xml", datakey: "string", max: 100 });

        if (flag == 1) {
            $(".FactoryRepresentitive", "#main_content").result(function () {
               
                var username = $(this).val();
                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                       
                        $("#hdnFactoryIdRisk").val(result.UserID);
                        $("#hdnFactoryNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);

                        $("#hdnFactoryIdRisk").val("0");
                        $("#hdnFactoryNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }

        if (flag == 2) {
            $(".QaRepresentative", "#main_content").result(function () {
               
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                       
                        $("#hdnQaIdRisk").val(result.UserID);
                        $("#hdnQaNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnQaIdRisk").val("");
                        $("#hdnQaNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }


        if (flag == 3) {
            $(".MerchandiserRepresentative", "#main_content").result(function () {
               
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                        
                        $("#hdnMerchandiserIdRisk").val(result.UserID);
                        $("#hdnMerchandiserNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnMerchandiserIdRisk").val("0");
                        $("#hdnMerchandiserNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
        if (flag == 4) {
            $(".IERepresentative", "#main_content").result(function () {
               
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                        
                        $("#hdnIEIdRisk").val(result.UserID);
                        $("#hdnIENameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnIEIdRisk").val("0");
                        $("#hdnIENameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
        if (flag == 5) {
            $(".SamplingRepresentative", "#main_content").result(function () {
                
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {

                        $("#hdnSamplingIdRisk").val(result.UserID);
                        $("#hdnSamplingNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnSamplingIdRisk").val("0");
                        $("#hdnSamplingNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
        if (flag == 6) {
            $(".FabricRepresentative", "#main_content").result(function () {
               
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
    
                        $("#hdnFabricIdRisk").val(result.UserID);
                        $("#hdnFabricNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnFabricIdRisk").val("0");
                        $("#hdnFabricNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
        if (flag == 6) {
            $(".AccessoryRepresentative", "#main_content").result(function () {
                
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {

                        $("#hdnAccessoryIdRisk").val(result.UserID);
                        $("#hdnAccessoryNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnAccessoryIdRisk").val("0");
                        $("#hdnAccessoryNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
        if (flag == 7) {
            $(".OutRepresentative", "#main_content").result(function () {
               
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {

                        $("#hdnOutIdRisk").val(result.UserID);
                        $("#hdnOutNameRisk").val(result.FullName);
                    }
                    else {
                       
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnOutIdRisk").val("0");
                        $("#hdnOutNameRisk").val("");
                    }

                }, onPageError, false, false);
            });
        }
    }

    var counterRisk = parseInt($('#<%= hdnCounterRisk.ClientID %>').val());
    function AddQaRepresentativeRisk() {
       
        if ($('#<%= txtQaRepresentativeRisk.ClientID %>').val() != "") {
            var objIds = '<%=hdnQaRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnQaRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnQaIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnQaIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnQaIdRisk").val();
                    IdsArr = strIds.split(',');
                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtQaRepresentativeRisk.ClientID %>').val('');
                            $("#hdnQaIdRisk").val('0');
                            $("#hdnQaNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnQaNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnQaNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnQaNameRisk").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var QaRepresentativeId = $("#hdnQaIdRisk").val();
            var QaRepresentativeName = $("#hdnQaNameRisk").val();

            if (parseInt(QaRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvQaRepresentativeRisk' + counterRisk);
                if (counterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtQaRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteQaRepresentativeRisk(' + counterRisk + ', ' + QaRepresentativeId + ', \'' + QaRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtQaRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteQaRepresentativeRisk(' + counterRisk + ', ' + QaRepresentativeId + ', \'' + QaRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvQaRepresentativeValuesRisk.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtQaRepresentativeRisk.ClientID %>').val('');
            counterRisk++;
            $("#hdnQaIdRisk").val('0');
            $("#hdnQaNameRisk").val('');
        }
        else {
            alert("Please enter QA Representative.")
        }
    }

    //added by Girish on 2023-04-05 :Start

    function deleteConfirmation(id, flag) { //no need to set display:none as postback will do the same

        var status = confirm('Are you sure you want to delete?')

        if (status) {

            if (id.includes("lnkDelete")) {

                $('[id$="abtnAdd"]').each(function () {

                    $(this).css('display', 'none');

                });
                $('[id$="addbutton"]').each(function () {

                    $(this).css('display', 'none');

                });
                $('[id$="lnkDelete"]').each(function () {

                    $(this).css('display', 'none');

                });

                var split = id.split("lnkDelete");

                if (flag === "Fabric") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "Accessories") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "Fitting") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "Making") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "ValueAddition") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "Washing") {
                    
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
                else if (flag === "Finishing_Packing") {
                   
                        $('#' + split[0].concat("spn_wait_ForDelete")).css('display', 'block');
                    
                }
            }
        }
        else {
            return false;
        }
    }

    function HideButtonForTimeBeing(id, flag) { //no need to set display:none as postback will do the same
        
        if (id.includes("abtnAdd")) {

            $('[id$="abtnAdd"]').each(function () {

                $(this).css('display', 'none');

            });
            $('[id$="addbutton"]').each(function () {

                $(this).css('display', 'none');

            });
            $('[id$="lnkDelete"]').each(function () {

                $(this).css('display', 'none');

            });   


            var split = id.split("abtnAdd");
            var split1 = id.split("_");

            if (flag === "Fabric") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskRemarks_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Accessories") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskAccessories_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Fitting") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdriskFiting_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Making") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskMaking_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "ValueAddition") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskImbroidery_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Washing") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskWashing_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Finishing_Packing") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskFinishing_" + split1[6] + "_txtRemarkFooter";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
        }
        else if (id.includes("addbutton")) {

            $('[id$="abtnAdd"]').each(function () {

                $(this).css('display', 'none');

            });
            $('[id$="addbutton"]').each(function () {

                $(this).css('display', 'none');

            });
            $('[id$="lnkDelete"]').each(function () {

                $(this).css('display', 'none');

            });

            var split = id.split("addbutton");

            var split1 = id.split("_");

            if (flag === "Fabric") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskRemarks_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Accessories") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskAccessories_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Fitting") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdriskFiting_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Making") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskMaking_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "ValueAddition") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskImbroidery_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Washing") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskWashing_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
            else if (flag === "Finishing_Packing") {

                var CurrentRemarkId = split1[0] + "_" + split1[1] + "_" + split1[2] + "_" + split1[3] + "_" + split1[4] + "_grdRiskFinishing_" + split1[6] + "_txtRemarksEmpty";

                if ($('#' + CurrentRemarkId).val() != "") {

                    $('#' + split[0].concat("spn_wait")).css('display', 'block');
                }
            }
        }
    }
    //added by Girish on 2023-04-05 :End

</script>

<style type="text/css">
    .item_list th
    {
        padding-left: 3px !important;
        padding-right: 0px !important;
    }
    .capitalize
    {
        text-transform: capitalize;
    }
    .iSEnable
    {
        display: none;
    }
    
    .ShowClass
    {
        display: block;
    }
    .item_list-value th
    {
        color: white !important;
        font-family: Verdana,Arial,sans-serif;
        font-size: 10px;
        background-color: #39589C;
        text-transform: capitalize !important;
        border: 1px solid #E6E6E6;
        text-align: center;
        padding: 8px 0px;
        font-weight: normal;
    }
    .item_list-value td
    {
        color: #666;
        font-size: 11px;
        font-family: Verdana;
        height: 15px;
    }
    
    .from-status label
    {
        border-bottom: 1px solid #ccc;
    }
    .submit-disable
    {
        background: gray none repeat scroll 0 0 !important;
        border: medium none !important;
        color: #fff;
        font-size: 14px;
        font-weight: bold;
        padding: 5px 9px;
    }
    .container-detail h3
    {
        float: none;
        background: none;
        text-align: left;
    }
    input[type="checkbox"]
    {
        margin: 0px;
        padding: 0px;
        position: relative;
        top: 0px;
    }
    .mar-top input[type="checkbox"]
    {
        position: relative;
        top: 3px;
        left: 4px;
    }
    .padding-10
    {
        padding: 3px 0px;
    }
    .AcceRiskTable td
    {
        border: 0px !important;
        border-bottom: 1px solid #dedbdb !important;
        border-right: 1px solid #e4e1e1 !important;
        padding: 0px 0px !important;
        height: 15px;
    }
    .AcceRiskTable tr:last-child() > td
    {
        border-bottom: 0px !important;
    }
    .AcceRiskTable td:nth-child(5)
    {
        border-right: 0px !important;
    }
    .item_list td.borderPdding
    {
        padding: 0px 0px !important;
    }
    .SimplePaRiskTable
    {
        border: 0px !important;
        border-collapse: collapse;
        width: 100%;
    }
    .SimplePaRiskTable td
    {
        border: 1px solid #dedbdb !important;
        border-left: 0px !important;
        border-collapse: collapse;
        font-size: 10px;
    }
    .txtCenter
    {
        text-align: center;
    }
    
    .padding-10 .da_submit_button
    {
        padding: 2px 9px !important;</style>

<div id="RiskAnalysis">    
    <div style="margin: 5px 0px; font-size: 16px; width: 100%;" class="fittingcontainer">
        Basic Information: <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)"
            onclick='showStylePhotoWithOutScroll(<%= hdnStyleId.Value %>,-1,-1)' style="color: #fff;">
            <asp:Label ID="lblRiskBasicInformation" runat="server" Text=""></asp:Label>
        </a>
    </div>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <div align="left">
                    <asp:HiddenField runat="server" ID="hdnF5" />
                    <asp:HiddenField runat="server" ID="_repostcheckcode" />
                    <asp:HiddenField ID="hdnRiskCreateNew" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnRiskReUse" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnRiskStyleId" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnRiskStyleNumber" Value="" runat="server" />
                    <asp:HiddenField ID="hdnRiskNewRef" Value="0" runat="server" />
                    <asp:Button ID="btnSubmitFromRiskPopUP" CssClass="btnRisk" Style="display: none;"
                        runat="server" Text="Button" OnClick="btnSubmitFromRiskPopUP_Click" />
                    <asp:HiddenField ID="hdnEnableFalse" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnStyleId" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnStyleNumber" runat="server" Value="0" />
                    <div id="dvGvRisk" runat="server" class="scroll-field">
                        <asp:GridView ID="gvRiskAnalysis" runat="server" AutoGenerateColumns="false" CssClass="fixed-header item_list"
                            OnRowDataBound="gvRiskAnalysis_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="<label>&nbsp;Serial No.</label>" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 60px !important; float: left;">
                                            <asp:Label ID="lblCalBIH" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;Style No.</label>" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 60px !important; float: left; height: 20px;">
                                            <asp:Label ID="lblSDate" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;Contract No.<br/>&nbsp;&nbsp;&nbsp;Quantity</label>"
                                    ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 90px !important; float: left; text-align: center;">
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label><br />
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px"></HeaderStyle>
                                    <ItemStyle Width="80px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fabric</label><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;<br/>Quality/Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Eta"
                                    HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 100%; height: 20px; font-weight: bold;">
                                            B.I.H:&nbsp;&nbsp;<asp:Label ID="lblBIH" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIH")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIH")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                        </div>
                                        <div style="width: 100%;">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr id="tbl1" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric1" runat="server">
                                                                    <asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric1")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdprint1" runat="server">
                                                                    <asp:Label ID="lblFabric1Percent" runat="server" Text='<%# Eval("FabricPercent1")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric1DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric1DetailsRef" runat="server" Text='<%# Eval("Fabric1Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate1" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate1" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl2" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" id="tdFabric2" runat="server">
                                                                    <asp:Label ID="lblFabric2" runat="server" Text='<%# Eval("Fabric2")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric2Percent" runat="server">
                                                                    <asp:Label ID="lblFabric2Percent" runat="server" Text='<%# Eval("FabricPercent2")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric2DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric2DetailsRef" runat="server" Text='<%# Eval("Fabric2Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate2" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate2" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl3" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric3" runat="server">
                                                                    <asp:Label ID="lblFabric3" runat="server" Text='<%# Eval("Fabric3")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric3Percent" runat="server">
                                                                    <asp:Label ID="lblFabric3Percent" runat="server" Text='<%# Eval("FabricPercent3")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric3DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric3DetailsRef" runat="server" Text='<%# Eval("Fabric3Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate3" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate3" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl4" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric4" runat="server">
                                                                    <asp:Label ID="lblFabric4" runat="server" Text='<%# Eval("Fabric4")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric4Percent" runat="server">
                                                                    <asp:Label ID="lblFabric4Percent" runat="server" Text='<%# Eval("FabricPercent4")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric4DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric4DetailsRef" runat="server" Text='<%# Eval("Fabric4Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate4" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate4" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl5" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric5" runat="server">
                                                                    <asp:Label ID="lblFabric5" runat="server" Text='<%# Eval("Fabric5")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric5Percent" runat="server">
                                                                    <asp:Label ID="lblFabric5Percent" runat="server" Text='<%# Eval("FabricPercent5")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric5DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric5DetailsRef" runat="server" Text='<%# Eval("Fabric5Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate5" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate5" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate5")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate5")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate5" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate5" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate5")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate5")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl6" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric6" runat="server">
                                                                    <asp:Label ID="lblFabric6" runat="server" Text='<%# Eval("Fabric6")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric6Percent" runat="server">
                                                                    <asp:Label ID="lblFabric6Percent" runat="server" Text='<%# Eval("FabricPercent6")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric6DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric6DetailsRef" runat="server" Text='<%# Eval("Fabric6Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate6" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate6" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate6")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate6")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate6" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate6" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate6")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate6")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200px"></HeaderStyle>
                                    <ItemStyle Width="200px" VerticalAlign="Top" CssClass="newcss2 marginpadding verttop">
                                    </ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accessories</label><br/><br/>Quality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In House &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recd &nbsp;&nbsp;Tot &nbsp;&nbsp; Act Dat/End ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding: 0px !important;">
                                                        <asp:Repeater ID="rptAccessoriesRisk" runat="server" OnItemDataBound="rptAccessoriesRisk_ItemDataBound">
                                                            <ItemTemplate>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="AcceRiskTable">
                                                                    <tr>
                                                                        <td align="left" style="text-align: left;">
                                                                            <div style="width: 105px; float: left;" id="divAccessoriesName" runat="server">
                                                                                <asp:Label ID="lblAccessories" Width="110" runat="server" Text='<%#Eval("AccessoriesName") %>'
                                                                                    Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <div style="width: 20px; float: left;" id="divpercentInHouse" runat="server">
                                                                                <asp:Label ID="lblPercentInHouse" runat="server" Text='<%#Eval("percentInHouse") %>'
                                                                                    Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="width: 60px; float: left;" id="divQuantityAvail" runat="server">
                                                                                <asp:Label ID="txtQuantityAvail" Width="40" Style="color: #000000; background-color: transparent;
                                                                                    font-size: 8px;" runat="server" Text='<%#Eval("QuantityAvail") %>'></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <%-- <td>
            <div style="width:35px; float:left;">
            <asp:Label ID="lblBIHETAAcc"  Width="60" style="font-size:8px; color:#807F80 !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM(ddd)") %>' ></asp:Label>
            </div>
            </td>--%>
                                                                        <td>
                                                                            <div style="width: 35px; float: left;" id="divRequired" runat="server">
                                                                                <asp:Label ID="txtRequired" Width="40" runat="server" Text='<%#Eval("Required") %>'
                                                                                    Style="font-size: 8px !important; background-color: transparent;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="width: 60px; float: left;" id="divAccesoriesETA" runat="server" class="Accessory">
                                                                                <asp:Label ID="lblAccessoriesETA" Width="60" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM (ddd)")%>'
                                                                                    runat="server" Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                                <asp:TextBox ID="txtAccessoryWorkingDetailID" CssClass="hide_me txtAccessoryWorkingDetailID"
                                                                                    runat="server" Text='<%#Bind("AccessoryWorkingDetailID") %>'></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnRemark" Value='<%#Eval("BIHETARemark") %>' runat="server" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200px"></HeaderStyle>
                                    <ItemStyle Width="200px" CssClass="newcss2 borderPdding marginpadding"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Technical</label><br/><br/>Deliverable&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 150px; vertical-align: text-top; font-weight: bold; height: 30px;">
                                            PCD:&nbsp;&nbsp;<asp:Label ID="lblPCD" runat="server" Text='<%# (Convert.ToDateTime(Eval("PCD")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PCD")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--Added By Ashish on 4/3/2015--%>
                                            &nbsp;&nbsp; Fits:&nbsp;&nbsp;<asp:Label ID="lblFitsDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsStatusETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FitsStatusETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--END--%>
                                        </div>
                                        <div style="width: 150px; vertical-align: text-top;">
                                            <table width="100%" cellpadding="0" cellspacing="0" class="SimplePaRiskTable">
                                                <tr>
                                                    <td style="text-align: left; width: 90px;" id="tdstc" runat="server">
                                                        Stc
                                                    </td>
                                                    <td id="tdLabel6" runat="server">
                                                        <asp:Label ID="Label6" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdPatternSample" runat="server">
                                                        Pattern Sample
                                                    </td>
                                                    <td id="tdPatternETA" runat="server">
                                                        <asp:Label ID="lblPatternETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdtop" runat="server">
                                                        TOP Sent
                                                    </td>
                                                    <td id="tdTOPETA" runat="server">
                                                        <asp:Label ID="lblTOPETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px"></HeaderStyle>
                                    <ItemStyle Width="150px" CssClass="newcss2 marginpadding"></ItemStyle>
                                </asp:TemplateField>
                                <%--abhishek hide production sec 13/1/2016--%>
                                <asp:TemplateField Visible="false" HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Production</label><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="vertical-align: top; width: 215px; font-weight: bold; height: 20px;">
                                            Ex Fac:&nbsp;&nbsp;<asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--<asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderID") %>'></asp:TextBox>--%>
                                            <asp:TextBox ID="txtStyleID" CssClass="hide_me" runat="server" Text='<%#Bind("StyleID") %>'></asp:TextBox>
                                        </div>
                                        <div style="vertical-align: top; width: 215px;">
                                            <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                <tr>
                                                    <td style="text-align: left; width: 65px;" id="tdCutReady" runat="server">
                                                        <asp:Label ID="lvlCutReady" runat="server" Text="Cut Ready"></asp:Label>
                                                    </td>
                                                    <td style="width: 30px;" id="tdCutPercentInhouse" runat="server">
                                                        <asp:Label ID="lblCutPercentInhouse" runat="server" Text='<%#Eval("CutPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td style="width: 60px;" id="tdCutreadyStartETA" runat="server">
                                                        <asp:Label ID="lblCutreadyStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 60px;" id="tdCutreadyENDETA" runat="server">
                                                        <asp:Label ID="lblCutreadyENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdStitched" runat="server">
                                                        <asp:Label ID="lblStitched" runat="server" Text="Stitched"></asp:Label>
                                                    </td>
                                                    <td id="tdStitchedPercentInhouse" runat="server">
                                                        <asp:Label ID="lblStitchedPercentInhouse" runat="server" Text='<%#Eval("StitchedPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdStichedStartETA" runat="server">
                                                        <asp:Label ID="lblStichedStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td id="tdStichedENDETA" runat="server">
                                                        <asp:Label ID="lblStichedENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="tdVA" runat="server" style="text-align: left;">
                                                        <asp:Label ID="lvlVA" runat="server" Text="V.A."></asp:Label>
                                                    </td>
                                                    <td id="tdVAPercentInhouse" runat="server">
                                                        <asp:Label ID="lblVAPercentInhouse" runat="server" Text='<%#Eval("VAPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdVAStartETA" runat="server">
                                                        <asp:Label ID="lblVAStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td id="tdVAENDETA" runat="server">
                                                        <asp:Label ID="lblVAENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdlPacked" runat="server">
                                                        <asp:Label ID="lblPacked" runat="server" Text="Packed"></asp:Label>
                                                    </td>
                                                    <td id="tdPackedPercentInhouse" runat="server">
                                                        <asp:Label ID="lblPackedPercentInhouse" runat="server" Text='<%#Eval("PackedPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdPackedETA" runat="server" colspan="2">
                                                        <asp:Label ID="lblPackedETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PackedETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PackedETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="215px"></HeaderStyle>
                                    <ItemStyle Width="215px" CssClass="newcss2 marginpadding"></ItemStyle>
                                </asp:TemplateField>
                                <%--end --%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Repeater ID="repStyleCodeVirsion" runat="server" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkn1" runat="server">
                                                <asp:Label ID="lbl" runat="server" Text='<%#Eval("StyleCodeVirsion")%>'></asp:Label>
                                            </asp:LinkButton>
                                            &nbsp;
                                            <asp:HiddenField ID="rephdnStyleid" runat="server" Value='<%#Eval("StyleidVirsion")%>' />
                                            <asp:HiddenField ID="rephdnStylCode" runat="server" Value='<%#Eval("StyleCodeVirsion")%>' />
                                            <asp:ImageButton ID="imgPlus" ImageUrl="../../App_Themes/ikandi/images/plus_icon.gif"
                                                OnClick="imgPlus_Click" runat="server" />
                                            <asp:ImageButton ID="imgMinus" ImageUrl="../../App_Themes/ikandi/images/minus_icon.gif"
                                                Style="display: none;" OnClick="imgMinus_Click" runat="server" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="ShowGridPopup" runat="server" style="overflow-y: scroll; width: 100%; height: 500px;"
                                        visible="false">
                                        <table width="95%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="container-detail">
                                                        <h3>
                                                            <asp:Label ID="lblFabric" runat="server" Text=""></asp:Label>
                                                        </h3>
                                                        <asp:GridView ID="GridRiskFabricRemark" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" ShowFooter="True" HeaderStyle-CssClass="pras" ShowHeader="false"
                                                            HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                            OnRowDataBound="GridRiskFabricRemark_RowDataBound" GridLines="None">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                        <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: left;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblAccessory" runat="server" Text=""></asp:Label>
                                                        </h3>
                                                        <asp:GridView ID="GridRiskAccessory" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskAccessory_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                        <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskAccessoryId") %>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remark">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("AccessoryRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_RiskAccessoryId" Value='<%# Eval("RiskAccessoryId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%" style="background-color: #e6e6e6;">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblFiting" runat="server" Text=""></asp:Label></h3>
                                                        <asp:GridView ID="GridRiskFittingRemark" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                                            HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskFittingRemark_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FittingRemark" HeaderStyle-Width="12%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("FittingRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_RiskFittingId" Value='<%# Eval("RiskFittingId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%" style="background-color: #e6e6e6;">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblMaking" runat="server" Text=""></asp:Label></h3>
                                                        <asp:GridView ID="GridRiskMakingRemark" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                                            HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskMakingRemark_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="MakingRemark" HeaderStyle-Width="12%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("MakingRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_RiskMakingId" Value='<%# Eval("RiskMakingId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblImbroidery" runat="server" Text=""></asp:Label></h3>
                                                        <asp:GridView ID="GridImbroidery" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridImbroidery_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="EmbroideryRemark" HeaderStyle-Width="12%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("ImbroideryRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_ImbroideryRemark" Value='<%# Eval("RiskImbroideryId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblRiskWashing" runat="server" Text=""></asp:Label></h3>
                                                        <asp:GridView ID="GridRiskWashing" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskWashing_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="WashingRemark" HeaderStyle-Width="12%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("WashingRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_WashingRemarkRemark" Value='<%# Eval("RiskWashingId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%" style="background-color: #e6e6e6;">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="container-detail">
                                                        <h3 style="padding: 0px; margin: 0px;">
                                                            <asp:Label ID="lblRiskFinishing" runat="server" Text=""></asp:Label></h3>
                                                        <asp:GridView ID="GridRiskFinishing" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskFinishing_RowDataBound"
                                                            GridLines="None" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                                    <ItemTemplate>
                                                                        <h3>
                                                                            <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                                        </h3>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FinishingRemark" HeaderStyle-Width="12%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                            Width="100%" runat="server" Text='<%#Eval("FinishingRemark")%>'></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdn_RiskFinishingIdRemark" Value='<%# Eval("RiskFinishingId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                                    <tr style="text-align: center;">
                                                                        <td width="29%" style="background-color: #e6e6e6;">
                                                                            <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                                Width="100%" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="width: 100%; padding: 0px;">
                    <%--    <asp:panel id="PnlRemarks" runat="server" defaultbutton="btnSubmit" xmlns:asp="#unknown">--%>
                    <asp:Panel ID="PnlRemarks" runat="server" DefaultButton="btnSubmit">
                        <div class="container-detail" style="margin-top: 10px">
                            <h3>
                                Fabric
                            </h3>
                            <asp:GridView ID="grdilimitationRemarks" runat="server" AutoGenerateColumns="False"
                                Width="100%" Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="grdRiskRemarks_PageIndexChanging"
                                GridLines="None" CssClass="fab-row">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <h3>
                                                <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'> </asp:Literal>
                                            </h3>
                                            <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                            <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                            <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        <FooterStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" VerticalAlign="top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarkEdit" ReadOnly="true" ForeColor="black" BorderStyle="None"
                                                CssClass="capitalize" TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="top" Width="1000px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:UpdatePanel ID="UpdatePannel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskRemarks" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" OnRowDeleting="grdRiskRemarks_RowDeleting"
                                        HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                        HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="grdRiskRemarks_PageIndexChanging"
                                        OnRowCommand="grdRiskRemarks_RowCommand" ShowHeader="false" OnRowDataBound="grdRiskRemarks_RowDataBound"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'> </asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="75px">
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                                                            OnClientClick="return deleteConfirmation(this.id,'Fabric')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>

                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Fabric')" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>
                                                            <img src="../../images/add-butt.png" />                                                            
                                                            </asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            CssClass="capitalize" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Fabric')" CssClass="iSlnkHide"
                                                            Text="Add"> <img  src="../../images/add-butt.png" /> </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <h3>
                                Accessories
                            </h3>
                            <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink1" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:GridView ID="grdacssessoryLimitationRemarks" runat="server" AutoGenerateColumns="False"
                                Width="100%" Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" GridLines="None"
                                CssClass="fab-row">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <h3>
                                                <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                            </h3>
                                            <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskAccessoryId") %>' />
                                            <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                            <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        <FooterStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" VerticalAlign="top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="1000px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarkEdit" ReadOnly="true" ForeColor="black" BorderStyle="None"
                                                CssClass="capitalize" TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                Width="1000px" runat="server" Text='<%#Eval("AccessoryRemark")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="top" Width="1000px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskAccessories" runat="server" AutoGenerateColumns="False"
                                        Width="100%" Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskAccessories_RowCommand"
                                        OnRowDataBound="grdRiskAccessories_RowDataBound" OnRowDeleting="grdRiskAccessories_RowDeleting"
                                        ShowHeader="false" OnSelectedIndexChanging="grdRiskAccessories_SelectedIndexChanging"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskAccessoryId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="1000px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("AccessoryRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkAccessories()"><img src="../../images/add-butt.png" /></asp:HyperLink>
                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                            OnClientClick="return deleteConfirmation(this.id,'Accessories')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Accessories')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            CssClass="capitalize" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Accessories')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <h3>
                                Fitting
                            </h3>
                            <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink2" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdriskFiting" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdriskFiting_RowCommand"
                                        OnRowDataBound="grdriskFiting_RowDataBound" OnRowDeleting="grdriskFiting_RowDeleting"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFittingId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("FittingRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <%-- <HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkFitting()"><img src="../../images/add-butt.png" /></asp:HyperLink>
                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <div style="text-align: center;" class="iSlnkHide">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                            OnClientClick="return deleteConfirmation(this.id,'Fitting')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Fitting')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Fitting')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <h3>
                                Making
                            </h3>
                            <%--<div class="add_butt"> <asp:HyperLink ID="HyperLink3" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskMaking" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskMaking_RowCommand"
                                        OnRowDataBound="grdRiskMaking_RowDataBound" OnRowDeleting="grdRiskMaking_RowDeleting"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskMakingId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("MakingRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="#65676d" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <div style="text-align: center;" class="iSlnkHide">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                                                            OnClientClick="return deleteConfirmation(this.id,'Making')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Making')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Making')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <%--abhishek--%>
                            <h3>
                                Value addition
                            </h3>
                            <%-- end--%>
                            <%--<div class="add_butt"> <asp:HyperLink ID="HyperLink4" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskImbroidery" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskImbroidery_RowCommand"
                                        OnRowDataBound="grdRiskImbroidery_RowDataBound" OnRowDeleting="grdRiskImbroidery_RowDeleting"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskImbroideryId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="1000px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("ImbroideryRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkImbroidery()"><img src="../../images/add-butt.png" /></asp:HyperLink>
                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <div style="text-align: center;" class="iSlnkHide">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                            OnClientClick="return deleteConfirmation(this.id,'ValueAddition')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'ValueAddition')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'ValueAddition')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <h3>
                                Washing
                            </h3>
                            <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink5" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskWashing" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskWashing_RowCommand"
                                        OnRowDataBound="grdRiskWashing_RowDataBound" OnRowDeleting="grdRiskWashing_RowDeleting"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal></h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskWashingId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("WashingRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkWashing()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <div style="text-align: center;" class="iSlnkHide">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                                                            OnClientClick="return deleteConfirmation(this.id,'Washing')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Washing')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Washing')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="container-detail">
                            <%-- updated by abhishek on 17/8/2015--%>
                            <h3>
                                Finishing/Packing
                            </h3>
                            <%-- end by abhishek on 17/8/2015--%>
                            <%--<div class="add_butt"> <asp:HyperLink ID="HyperLink6" runat="server" ><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRiskFinishing" runat="server" AutoGenerateColumns="False" Width="100%"
                                        Visible="false" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskFinishing_RowCommand"
                                        OnRowDataBound="grdRiskFinishing_RowDataBound" OnRowDeleting="grdRiskFinishing_RowDeleting"
                                        GridLines="None" CssClass="fab-row">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="25px">
                                                <ItemTemplate>
                                                    <h3>
                                                        <asp:Literal runat="server" ID="ltIndex" Text='<%# Eval("Indexs") %>'></asp:Literal>
                                                    </h3>
                                                    <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFinishingId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                <FooterStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" VerticalAlign="top" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                        runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <FooterStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                        TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                        Width="1000px" runat="server" Text='<%#Eval("FinishingRemark")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="top" Width="1000px" />
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                                </FooterTemplate>
                                                <FooterStyle Width="1000px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkFinishing()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <div style="text-align: center;" class="iSlnkHide">
                                                    <span runat="server" id="spn_wait_ForDelete" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Deleting Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                            OnClientClick="return deleteConfirmation(this.id,'Finishing_Packing')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" />
                                                <FooterTemplate>
                                                    <div style="text-align: center;">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Finishing_Packing')" CssClass="iSlnkHide"
                                                            Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </div>
                                                </FooterTemplate>
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                <tr style="text-align: center;">
                                                    <td width="95px">
                                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="1000px" align="left">
                                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                            onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                            MaxLength="1000" />
                                                    </td>
                                                    <td width="75px">
                                                    <span runat="server" id="spn_wait" style="display:none;color:#70B8E1;font-weight: bold;font-size: 18px">Adding Please Wait...</span> <%--added by Girish on 2023-04-05--%>
                                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                            OnClientClick="HideButtonForTimeBeing(this.id,'Finishing_Packing')" CssClass="iSlnkHide"
                                                            Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </asp:Panel>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <h3 style="font-weight: bold; font-size: 12px;">
                            <asp:CheckBox ID="chkvalueAddtion" AutoPostBack="true" runat="server" OnCheckedChanged="chkvalueAddtion_CheckedChanged" />
                            Value Addition <small style="font-size: 10px; font-weight: normal">(Select if there
                                is value addition on this style.)</small>
                        </h3>
                        <asp:Label ID="lblmgs" Visible="false" runat="server"></asp:Label>
                        <asp:GridView ID="GrdValueAddtion" runat="server" GridLines="Both" AutoGenerateColumns="False"
                            Width="100%" Visible="True" ShowFooter="false" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                            HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GrdValueAddtion_RowDataBound"
                            OnDataBound="GrdValueAddtion_DataBound" BackColor="White" CssClass="item_list-value"
                            OnPreRender="GrdValueAddtion_PreRender1">
                            <Columns>
                                <asp:TemplateField HeaderText="From Status" HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromst" runat="server" Text='<%#Eval("FromStatus")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Status" HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltost" runat="server" Text='<%#Eval("Tostatus")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Is VA Requried" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblster" runat="server" Text='<%#Eval("Tostatus")%>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="ISUSEVA" runat="server" Visible="False" AutoPostBack="true" OnCheckedChanged="ISUSEVA_OnCheckedChanged"
                                            Enabled="false" />
                                        <asp:HiddenField ID="hdnisvaReq" runat="server" Value='<%# Eval("isVaReq") %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VA Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValueAddtion" runat="server" Text='<%#Eval("ValueAddtionName")%>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="fromstid" Value='<%# Eval("FromStid") %>' />
                                        <asp:HiddenField runat="server" ID="hdntoid" Value='<%# Eval("toid") %>' />
                                        <asp:HiddenField runat="server" ID="hdnValid" Value='<%# Eval("Valid") %>' />
                                        <asp:HiddenField runat="server" ID="HdnIsVaExist" Value='<%# Eval("IsVaExist") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Is use" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ISUSE" runat="server" Enabled="false" AutoPostBack="true" OnCheckedChanged="ISUSE_CheckedChanged" />
                                        <asp:HiddenField ID="hdnisuse" runat="server" Value='<%# Eval("isVa") %>' />
                                        <asp:HiddenField ID="hdnCheckEntryIsDone" runat="server" Value='<%# Eval("isCheckEntryIsDone") %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtCenter" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 68%;" valign="bottom" align="right">
                <div class="container-detail" id="risks" style="margin-left: 10px; margin-bottom: 0px;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; text-align: left; padding: 5px 0px;">
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Factory Representatives
                                        </td>
                                        <td width="75%">
                                            <div id="dvFactoryRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtFactoryRepresentitiveRisk" CssClass="FactoryRepresentitive" onclick="AddRepresentative1(1)"
                                                                runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnFactoryIdRisk" name="hdnFactoryIdRisk" />
                                                            <input type="hidden" value='' id="hdnFactoryNameRisk" name="hdnFactoryNameRisk" />
                                                            <asp:HiddenField ID="hdnFactoryRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnFactoryRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnFactoryCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddFactory' visible="true" class="da_submit_button"
                                                                value="Add" onclick="AddFactoryRepresentativeRisk()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvFactoryRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            QA Representatives
                                        </td>
                                        <td width="75%">
                                            <div id="dvQaRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtQaRepresentativeRisk" CssClass="QaRepresentative" onclick="AddRepresentative1(2)"
                                                                runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnQaIdRisk" name="hdnQaIdRisk" />
                                                            <input type="hidden" value='' id="hdnQaNameRisk" name="hdnQaNameRisk" />
                                                            <asp:HiddenField ID="hdnQaRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnQaRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddQa' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddQaRepresentativeRisk()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvQaRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Merchandiser Representatives
                                        </td>
                                        <td width="75%">
                                            <div id="dvMerchandiserRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtMerchandiserRepresentativeRisk" CssClass="MerchandiserRepresentative"
                                                                onclick="AddRepresentative1(3)" runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnMerchandiserIdRisk" name="hdnMerchandiserIdRisk" />
                                                            <input type="hidden" value='' id="hdnMerchandiserNameRisk" name="hdnMerchandiserNameRisk" />
                                                            <asp:HiddenField ID="hdnMerchandiserRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnMerchandiserRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnMerchandiserCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddMerchandiser' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddMerchandiserRepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvMerchandiserRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            IE Representatives
                                        </td>
                                        <td width="75%">
                                            <div id="dvIERepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtIERepresentativeRisk" CssClass="IERepresentative" onclick="AddRepresentative1(4)"
                                                                runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnIEIdRisk" name="hdnIEIdRisk" />
                                                            <input type="hidden" value='' id="hdnIENameRisk" name="hdnIENameRisk" />
                                                            <asp:HiddenField ID="hdnIERepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnIERepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnIECounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddIE' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddIERepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvIERepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Sampling Representatives
                                        </td>
                                        <td width="75%">
                                            <div id="dvSamplingRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtSamplingRepresentativeRisk" CssClass="SamplingRepresentative"
                                                                onclick="AddRepresentative1(5)" runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnSamplingIdRisk" name="hdnSamplingIdRisk" />
                                                            <input type="hidden" value='' id="hdnSamplingNameRisk" name="hdnSamplingNameRisk" />
                                                            <asp:HiddenField ID="hdnSamplingRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnSamplingRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnSamplingCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddSampling' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddSamplingRepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvSamplingRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Fabric Store
                                        </td>
                                        <td width="75%">
                                            <div id="dvFabricRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtFabricRepresentativeRisk" CssClass="FabricRepresentative" onclick="AddRepresentative1(6)"
                                                                runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnFabricIdRisk" name="hdnFabricIdRisk" />
                                                            <input type="hidden" value='' id="hdnFabricNameRisk" name="hdnFabricNameRisk" />
                                                            <asp:HiddenField ID="hdnFabricRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnFabricRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnFabricCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddFabric' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddFabricRepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvFabricRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Accessory Store
                                        </td>
                                        <td width="75%">
                                            <div id="dvAccessoryRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtAccessoryRepresentativeRisk" CssClass="AccessoryRepresentative"
                                                                onclick="AddRepresentative1(7)" runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnAccessoryIdRisk" name="hdnAccessoryIdRisk" />
                                                            <input type="hidden" value='' id="hdnAccessoryNameRisk" name="hdnAccessoryNameRisk" />
                                                            <asp:HiddenField ID="hdnAccessoryRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnAccessoryRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnAccessoryCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddAccessory' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddAccessoryRepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvAccessoryRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="padding-10">
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #dedbdb;">
                                    <tr>
                                        <td width="25%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Out source
                                        </td>
                                        <td width="75%">
                                            <div id="dvOutRepresentativeRisk">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 15%">
                                                            <asp:TextBox ID="txtOutRepresentativeRisk" CssClass="OutRepresentative" onclick="AddRepresentative1(8)"
                                                                runat="server"></asp:TextBox>
                                                            <input type="hidden" value='0' id="hdnOutIdRisk" name="hdnOutIdRisk" />
                                                            <input type="hidden" value='' id="hdnOutNameRisk" name="hdnOutNameRisk" />
                                                            <asp:HiddenField ID="hdnOutRepresentativeIdRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnOutRepresentativeNameRisk" runat="server" />
                                                            <asp:HiddenField ID="hdnOutCounterRisk" runat="server" />
                                                        </td>
                                                        <td align="center" style="width: 15%">
                                                            <input type="button" runat="server" id='btnAddOut' visible="false" class="da_submit_button"
                                                                value="Add" onclick="AddOutRepresentative1()" />
                                                        </td>
                                                        <td align="left" style="width: 70%">
                                                            <div runat="server" id='dvOutRepresentativeValuesRisk'>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="border: 1px solid #dedbdb; width: 100%; padding: 5px;">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkAccountManager" CssClass="mar-top" Text="Signed Off by Fits/ Account Manager"
                                    Checked='<%#Eval("IsAccountMgr") %>' runat="server" TextAlign="Left" />
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkQAProd" CssClass="mar-top" Text=" Signed Off by Pre Production QA"
                                    Checked='<%#Eval("IsQAProd") %>' Visible="false" runat="server" TextAlign="Left" />
                            </td>
                            <td style="display: none" align="center">
                                <asp:CheckBox ID="chkMerchandisingMgr" runat="server" CssClass="mar-top" Width="300px"
                                    Text="Approved By DMM" TextAlign="Left" />
                            </td>
                            <td style="display: none">
                                <asp:CheckBox ID="chkFabricMgr" runat="server" CssClass="mar-top" Text="Approved by Fabric Mgr"
                                    TextAlign="Left" />
                            </td>
                            <td style="display: none">
                                <asp:CheckBox ID="chkAccessoryMgr" CssClass="mar-top" runat="server" Text="Approved by Accessory Mgr "
                                    TextAlign="Left" />
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #267cb2; width: 33%;">
                                <asp:Label ID="lblChkAcMgrDate" CssClass="RiskChkAcMgrDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="color: #267cb2; width: 33%;" align="center">
                                <asp:Label ID="lblChkQaMgrDate" CssClass="RiskChkQaMgrDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="color: #267cb2; width: 33%;" align="center">
                                <asp:Label ID="RiskChkMerchandisingMgrDate" CssClass="" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="color: #267cb2; display: none;">
                                <asp:Label ID="RiskChkFabricMgrDate" CssClass="" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="color: #267cb2; display: none;">
                                <asp:Label ID="RiskChkAccessoryMgrDate" Style="display: none" CssClass="" runat="server"
                                    Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="left">
                                <div style="width: auto; float: left; margin: 0px 5px;">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSubmit" CssClass="submit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSubmit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <%--<asp:Button runat="server" ID="btnPrint"  cssclass="print"  OnClientClick="javascript:window.print();"/>--%>
                                <div style="width: auto; float: left; margin: 0px 5px;">
                                    <input type="button" id="Button2" class="print da_submit_button" value="Print" onclick="return PrintRiskReportPDF();" />
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <%--end--%>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <%--abhishek 3/8/2015--%>
                <%--end--%>
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript">


    function PrintRiskReportPDF() {


        var NewRef = $('#<%= hdnRiskNewRef.ClientID %>').val();
        var ReUse = $('#<%= hdnRiskReUse.ClientID %>').val();
        var CreateNew = $('#<%= hdnRiskCreateNew.ClientID %>').val();
        var styleid = $('#<%= hdnStyleId.ClientID %>').val();
        var ReUseStyleId = $('#<%= hdnRiskStyleId.ClientID %>').val();
        var stylenumber = $('#<%= hdnStyleNumber.ClientID %>').val();
        var ClientId = '<%=this.strClientId %>';
        var DeptId = '<%=this.DepartmentId %>';
        var OrderId = '<%=this.OrderId %>';
                
        proxy.invoke("GenerateRiskReport", { stylenumber: stylenumber, styleid: styleid, strClientId: ClientId, DepartmentId: DeptId, OrderId: OrderId, CreateNew: CreateNew, NewRef: NewRef, ReUse: ReUse, ReUseStyleId: ReUseStyleId, RemarksType: '' }, function (result) {
            if ($.trim(result) == '')
                jQuery.facebox("Some error occured on the server, please try again later.");
            else {
                window.open("/uploads/temp/" + result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });

        return false;
    }
    //    addded by abhishek on 17/5/2017===================================//


    function DeleteQaRepresentativeRisk(counterRisk, QaRepresentativeId, QaRepresentativeName) {

        var QaRepresentativeIds = $("#<%=hdnQaRepresentativeIdRisk.ClientID%>").val();
        var QaRepresentativeNames = $("#<%=hdnQaRepresentativeNameRisk.ClientID%>").val();

        $("#dvQaRepresentativeRisk" + counterRisk).remove();
        $("#<%=hdnQaRepresentativeIdRisk.ClientID%>").val(QaRepresentativeIds.replace(QaRepresentativeId, ''));
        $("#<%=hdnQaRepresentativeNameRisk.ClientID%>").val(QaRepresentativeNames.replace(QaRepresentativeName, ''));

        QaRepresentativeIds = $("#<%=hdnQaRepresentativeIdRisk.ClientID%>").val();
        QaRepresentativeIds = (QaRepresentativeIds.replace(',,', ','));

        QaRepresentativeNames = $("#<%=hdnQaRepresentativeNameRisk.ClientID%>").val();
        QaRepresentativeNames = (QaRepresentativeNames.replace(',,', ','));

        $("#<%=hdnQaRepresentativeIdRisk.ClientID%>").val(QaRepresentativeIds);
        $("#<%=hdnQaRepresentativeNameRisk.ClientID%>").val(QaRepresentativeNames);

        var lastCharQaRepresentativeIds = QaRepresentativeIds.substr(QaRepresentativeIds.length - 1);
        var lastCharQaRepresentativeNames = QaRepresentativeNames.substr(QaRepresentativeNames.length - 1);

        if (lastCharQaRepresentativeIds === ",") {
            $("#<%=hdnQaRepresentativeIdRisk.ClientID%>").val(QaRepresentativeIds.substring(0, QaRepresentativeIds.length - 1))
        }

        if (lastCharQaRepresentativeNames === ",") {
            $("#<%=hdnQaRepresentativeNameRisk.ClientID%>").val(QaRepresentativeNames.substring(0, QaRepresentativeNames.length - 1))
        }
    }

    var FactorycounterRisk = parseInt($('#<%= hdnFactoryCounterRisk.ClientID %>').val());



    function DeleteFactoryRepresentativeRisk(FactorycounterRisk, FactoryRepresentativeId, FactoryRepresentativeName) {

        var FactoryRepresentativeIds = $("#<%=hdnFactoryRepresentativeIdRisk.ClientID%>").val();
        var FactoryRepresentativeNames = $("#<%=hdnFactoryRepresentativeNameRisk.ClientID%>").val();

        $("#dvFactoryRepresentativeRisk" + FactorycounterRisk).remove();
        $("#<%=hdnFactoryRepresentativeIdRisk.ClientID%>").val(FactoryRepresentativeIds.replace(FactoryRepresentativeId, ''));
        $("#<%=hdnFactoryRepresentativeNameRisk.ClientID%>").val(FactoryRepresentativeNames.replace(FactoryRepresentativeName, ''));

        FactoryRepresentativeIds = $("#<%=hdnFactoryRepresentativeIdRisk.ClientID%>").val();
        FactoryRepresentativeIds = (FactoryRepresentativeIds.replace(',,', ','));

        FactoryRepresentativeNames = $("#<%=hdnFactoryRepresentativeNameRisk.ClientID%>").val();
        FactoryRepresentativeNames = (FactoryRepresentativeNames.replace(',,', ','));

        $("#<%=hdnFactoryRepresentativeIdRisk.ClientID%>").val(FactoryRepresentativeIds);
        $("#<%=hdnFactoryRepresentativeNameRisk.ClientID%>").val(FactoryRepresentativeNames);

        var lastCharFactoryRepresentativeIds = FactoryRepresentativeIds.substr(FactoryRepresentativeIds.length - 1);
        var lastCharFactoryRepresentativeNames = FactoryRepresentativeNames.substr(FactoryRepresentativeNames.length - 1);

        if (lastCharFactoryRepresentativeIds === ",") {
            $("#<%=hdnFactoryRepresentativeIdRisk.ClientID%>").val(FactoryRepresentativeIds.substring(0, FactoryRepresentativeIds.length - 1))
        }

        if (lastCharFactoryRepresentativeNames === ",") {
            $("#<%=hdnFactoryRepresentativeNameRisk.ClientID%>").val(FactoryRepresentativeNames.substring(0, FactoryRepresentativeNames.length - 1))
        }
    }

    var MerchandisercounterRisk = parseInt($('#<%= hdnMerchandiserCounterRisk.ClientID %>').val());
    function AddMerchandiserRepresentative1() {
       
        if ($('#<%= txtMerchandiserRepresentativeRisk.ClientID %>').val() != "") {
            var objIds = '<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnMerchandiserIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnMerchandiserIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnMerchandiserIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtMerchandiserRepresentativeRisk.ClientID %>').val('');
                            $("#hdnMerchandiserIdRisk").val('0');
                            $("#hdnMerchandiserNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnMerchandiserNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnMerchandiserNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnMerchandiserNameRisk").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var MerchandiserRepresentativeId = $("#hdnMerchandiserIdRisk").val();
            var MerchandiserRepresentativeName = $("#hdnMerchandiserNameRisk").val();

            if (parseInt(MerchandiserRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvMerchandiserRepresentativeRisk' + MerchandisercounterRisk);
                if (MerchandisercounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtMerchandiserRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteMerchandiserRepresentativeRisk(' + MerchandisercounterRisk + ', ' + MerchandiserRepresentativeId + ', \'' + MerchandiserRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtMerchandiserRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteMerchandiserRepresentativeRisk(' + MerchandisercounterRisk + ', ' + MerchandiserRepresentativeId + ', \'' + MerchandiserRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvMerchandiserRepresentativeValuesRisk.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtMerchandiserRepresentativeRisk.ClientID %>').val('');
            MerchandisercounterRisk++;
            $("#hdnMerchandiserIdRisk").val('0');
            $("#hdnMerchandiserNameRisk").val('');
        }
        else {
            alert("Please enter Merchandiser Representative.")
        }
    }

    function DeleteMerchandiserRepresentativeRisk(MerchandisercounterRisk, MerchandiserRepresentativeId, MerchandiserRepresentativeName) {
       
        var MerchandiserRepresentativeIds = $("#<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>").val();
        var MerchandiserRepresentativeNames = $("#<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>").val();

        $("#dvMerchandiserRepresentativeRisk" + MerchandisercounterRisk).remove();
        $("#<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>").val(MerchandiserRepresentativeIds.replace(MerchandiserRepresentativeId, ''));
        $("#<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>").val(MerchandiserRepresentativeNames.replace(MerchandiserRepresentativeName, ''));

        MerchandiserRepresentativeIds = $("#<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>").val();
        MerchandiserRepresentativeIds = (MerchandiserRepresentativeIds.replace(',,', ','));

        MerchandiserRepresentativeNames = $("#<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>").val();
        MerchandiserRepresentativeNames = (MerchandiserRepresentativeNames.replace(',,', ','));

        $("#<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>").val(MerchandiserRepresentativeIds);
        $("#<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>").val(MerchandiserRepresentativeNames);

        var lastCharMerchandiserRepresentativeIds = MerchandiserRepresentativeIds.substr(MerchandiserRepresentativeIds.length - 1);
        var lastCharMerchandiserRepresentativeNames = MerchandiserRepresentativeNames.substr(MerchandiserRepresentativeNames.length - 1);

        if (lastCharMerchandiserRepresentativeIds === ",") {
            $("#<%=hdnMerchandiserRepresentativeIdRisk.ClientID%>").val(MerchandiserRepresentativeIds.substring(0, MerchandiserRepresentativeIds.length - 1))
        }

        if (lastCharMerchandiserRepresentativeNames === ",") {
            $("#<%=hdnMerchandiserRepresentativeNameRisk.ClientID%>").val(MerchandiserRepresentativeNames.substring(0, MerchandiserRepresentativeNames.length - 1))
        }
    }
    //==IE=========================================================================================//
    var IEcounterRisk = parseInt($('#<%= hdnIECounterRisk.ClientID %>').val());
    function AddIERepresentative1() {
       
        if ($('#<%= txtIERepresentativeRisk.ClientID %>').val() != "") {
            var objIds = '<%=hdnIERepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnIERepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnIEIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnIEIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnIEIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtIERepresentativeRisk.ClientID %>').val('');
                            $("#hdnIEIdRisk").val('0');
                            $("#hdnIENameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnIENameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnIENameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnIENameRisk").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var IERepresentativeId = $("#hdnIEIdRisk").val();
            var IERepresentativeName = $("#hdnIENameRisk").val();

            if (parseInt(IERepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvIERepresentativeRisk' + IEcounterRisk);
                if (MerchandisercounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtIERepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteIERepresentativeRisk(' + IEcounterRisk + ', ' + IERepresentativeId + ', \'' + IERepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtIERepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteIERepresentativeRisk(' + IEcounterRisk + ', ' + IERepresentativeId + ', \'' + IERepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvIERepresentativeValuesRisk.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtIERepresentativeRisk.ClientID %>').val('');
            IEcounterRisk++;
            $("#hdnIEIdRisk").val('0');
            $("#hdnIENameRisk").val('');
        }
        else {
            alert("Please enter IE Representative.")
        }
    }

    function DeleteIERepresentativeRisk(IEcounterRisk, IERepresentativeId, IERepresentativeName) {
       
        var IERepresentativeIds = $("#<%=hdnIERepresentativeIdRisk.ClientID%>").val();
        var IERepresentativeNames = $("#<%=hdnIERepresentativeNameRisk.ClientID%>").val();

        $("#dvIERepresentativeRisk" + IEcounterRisk).remove();
        $("#<%=hdnIERepresentativeIdRisk.ClientID%>").val(IERepresentativeIds.replace(IERepresentativeId, ''));
        $("#<%=hdnIERepresentativeNameRisk.ClientID%>").val(IERepresentativeNames.replace(IERepresentativeName, ''));

        IERepresentativeIds = $("#<%=hdnIERepresentativeIdRisk.ClientID%>").val();
        IERepresentativeIds = (IERepresentativeIds.replace(',,', ','));

        IERepresentativeNames = $("#<%=hdnIERepresentativeNameRisk.ClientID%>").val();
        IERepresentativeNames = (IERepresentativeNames.replace(',,', ','));

        $("#<%=hdnIERepresentativeIdRisk.ClientID%>").val(IERepresentativeIds);
        $("#<%=hdnIERepresentativeNameRisk.ClientID%>").val(IERepresentativeNames);

        var lastCharIERepresentativeIds = IERepresentativeIds.substr(IERepresentativeIds.length - 1);
        var lastCharIERepresentativeNames = IERepresentativeNames.substr(IERepresentativeNames.length - 1);

        if (lastCharIERepresentativeIds === ",") {
            $("#<%=hdnIERepresentativeIdRisk.ClientID%>").val(IERepresentativeIds.substring(0, IERepresentativeIds.length - 1))
        }

        if (lastCharIERepresentativeNames === ",") {
            $("#<%=hdnIERepresentativeNameRisk.ClientID%>").val(IERepresentativeNames.substring(0, IERepresentativeNames.length - 1))
        }
    }
    //==Sampling=========================================================================================//
    var SamplingcounterRisk = parseInt($('#<%= hdnSamplingCounterRisk.ClientID %>').val());
    function AddSamplingRepresentative1() {
                    
        if (jQuery.trim($('#<%= txtSamplingRepresentativeRisk.ClientID %>').val()) != '') {
            var objIds = '<%=hdnSamplingRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnSamplingRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnSamplingIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnSamplingIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnSamplingIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val('');
                            $("#hdnSamplingIdRisk").val('0');
                            $("#hdnSamplingNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnSamplingNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnSamplingNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnSamplingNameRisk").val();
                }
            }
            else {
                if ((strNames) == '') {
                    strIds = 0;
                    strNames = $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val();
                }
                else {
                    strIds = strIds + ',' + 0;
                    strNames = strNames + ',' + $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val();
                }
            }

            var SamplingRepresentativeId = $("#hdnSamplingIdRisk").val();
            var SamplingRepresentativeName = $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val();
            if ($("#" + objNames).val().indexOf($('#<%= txtSamplingRepresentativeRisk.ClientID %>').val()) == -1) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvSamplingRepresentativeRisk' + SamplingcounterRisk);
                if (SamplingcounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteSamplingRepresentativeRisk(' + SamplingcounterRisk + ', ' + SamplingRepresentativeId + ', \'' + SamplingRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteSamplingRepresentativeRisk(' + SamplingcounterRisk + ', ' + SamplingRepresentativeId + ', \'' + SamplingRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvSamplingRepresentativeValuesRisk.ClientID %>");

                $("#" + objIds).val(strIds);
                $("#" + objNames).val(strNames);

                $("#hdnSamplingIdRisk").val('0');
                $("#hdnSamplingNameRisk").val('');
            }
            else {
                alert("This Representative already exist")
            }
            $('#<%= txtSamplingRepresentativeRisk.ClientID %>').val('');
            SamplingcounterRisk++;

        }
        else {
            alert("Please enter Sampling Representative.")
        }
    }

    function DeleteSamplingRepresentativeRisk(SamplingcounterRisk, SamplingRepresentativeId, SamplingRepresentativeName) {
       
        var SamplingRepresentativeIds = $("#<%=hdnSamplingRepresentativeIdRisk.ClientID%>").val();
        var SamplingRepresentativeNames = $("#<%=hdnSamplingRepresentativeNameRisk.ClientID%>").val();

        $("#dvSamplingRepresentativeRisk" + SamplingcounterRisk).remove();
        $("#<%=hdnSamplingRepresentativeIdRisk.ClientID%>").val(SamplingRepresentativeIds.replace(SamplingRepresentativeId, ''));
        $("#<%=hdnSamplingRepresentativeNameRisk.ClientID%>").val(SamplingRepresentativeNames.replace(SamplingRepresentativeName, ''));

        SamplingRepresentativeIds = $("#<%=hdnSamplingRepresentativeIdRisk.ClientID%>").val();
        SamplingRepresentativeIds = (SamplingRepresentativeIds.replace(',,', ','));

        SamplingRepresentativeNames = $("#<%=hdnSamplingRepresentativeNameRisk.ClientID%>").val();
        SamplingRepresentativeNames = (SamplingRepresentativeNames.replace(',,', ','));

        $("#<%=hdnSamplingRepresentativeIdRisk.ClientID%>").val(SamplingRepresentativeIds);
        $("#<%=hdnSamplingRepresentativeNameRisk.ClientID%>").val(SamplingRepresentativeNames);

        var lastCharSamplingRepresentativeIds = SamplingRepresentativeIds.substr(SamplingRepresentativeIds.length - 1);
        var lastCharSamplingRepresentativeNames = SamplingRepresentativeNames.substr(SamplingRepresentativeNames.length - 1);

        if (lastCharSamplingRepresentativeIds === ",") {
            $("#<%=hdnSamplingRepresentativeIdRisk.ClientID%>").val(SamplingRepresentativeIds.substring(0, SamplingRepresentativeIds.length - 1))
        }

        if (lastCharSamplingRepresentativeNames === ",") {
            $("#<%=hdnSamplingRepresentativeNameRisk.ClientID%>").val(SamplingRepresentativeNames.substring(0, SamplingRepresentativeNames.length - 1))
        }
    }
    //==Fabric=========================================================================================//
    var FabriccounterRisk = parseInt($('#<%= hdnFabricCounterRisk.ClientID %>').val());
    function AddFabricRepresentative1() {
       
        if ($('#<%= txtFabricRepresentativeRisk.ClientID %>').val() != "") {
            var objIds = '<%=hdnFabricRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnFabricRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnFabricIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnFabricIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnFabricIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtFabricRepresentativeRisk.ClientID %>').val('');
                            $("#hdnFabricIdRisk").val('0');
                            $("#hdnFabricNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnFabricNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnFabricNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnFabricNameRisk").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var FabricRepresentativeId = $("#hdnFabricIdRisk").val();
            var FabricRepresentativeName = $("#hdnFabricNameRisk").val();

            if (parseInt(FabricRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvFabricRepresentativeRisk' + FabriccounterRisk);
                if (FabriccounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtFabricRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteFabricRepresentativeRisk(' + FabriccounterRisk + ', ' + FabricRepresentativeId + ', \'' + FabricRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtFabricRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteFabricRepresentativeRisk(' + FabriccounterRisk + ', ' + FabricRepresentativeId + ', \'' + FabricRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvFabricRepresentativeValuesRisk.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtFabricRepresentativeRisk.ClientID %>').val('');
            FabriccounterRisk++;
            $("#hdnFabricIdRisk").val('0');
            $("#hdnFabricNameRisk").val('');
        }
        else {
            alert("Please enter Fabric Representative.")
        }
    }

    function DeleteFabricRepresentativeRisk(FabriccounterRisk, FabricRepresentativeId, FabricRepresentativeName) {
       
        var FabricRepresentativeIds = $("#<%=hdnFabricRepresentativeIdRisk.ClientID%>").val();
        var FabricRepresentativeNames = $("#<%=hdnFabricRepresentativeNameRisk.ClientID%>").val();

        $("#dvFabricRepresentativeRisk" + FabriccounterRisk).remove();
        $("#<%=hdnFabricRepresentativeIdRisk.ClientID%>").val(FabricRepresentativeIds.replace(FabricRepresentativeId, ''));
        $("#<%=hdnFabricRepresentativeNameRisk.ClientID%>").val(FabricRepresentativeNames.replace(FabricRepresentativeName, ''));

        FabricRepresentativeIds = $("#<%=hdnFabricRepresentativeIdRisk.ClientID%>").val();
        FabricRepresentativeIds = (FabricRepresentativeIds.replace(',,', ','));

        FabricRepresentativeNames = $("#<%=hdnFabricRepresentativeNameRisk.ClientID%>").val();
        FabricRepresentativeNames = (FabricRepresentativeNames.replace(',,', ','));

        $("#<%=hdnFabricRepresentativeIdRisk.ClientID%>").val(FabricRepresentativeIds);
        $("#<%=hdnFabricRepresentativeNameRisk.ClientID%>").val(FabricRepresentativeNames);

        var lastCharFabricRepresentativeIds = FabricRepresentativeIds.substr(FabricRepresentativeIds.length - 1);
        var lastCharFabricRepresentativeNames = FabricRepresentativeNames.substr(FabricRepresentativeNames.length - 1);

        if (lastCharFabricRepresentativeIds === ",") {
            $("#<%=hdnFabricRepresentativeIdRisk.ClientID%>").val(FabricRepresentativeIds.substring(0, FabricRepresentativeIds.length - 1))
        }

        if (lastCharFabricRepresentativeNames === ",") {
            $("#<%=hdnFabricRepresentativeNameRisk.ClientID%>").val(FabricRepresentativeNames.substring(0, FabricRepresentativeNames.length - 1))
        }
    }
    //==Accessory=========================================================================================//
    var AccessorycounterRisk = parseInt($('#<%= hdnAccessoryCounterRisk.ClientID %>').val());
    function AddAccessoryRepresentative1() {
       
        if ($('#<%= txtAccessoryRepresentativeRisk.ClientID %>').val() != "") {
            var objIds = '<%=hdnAccessoryRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnAccessoryRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnAccessoryIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnAccessoryIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnAccessoryIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtAccessoryRepresentativeRisk.ClientID %>').val('');
                            $("#hdnAccessoryIdRisk").val('0');
                            $("#hdnAccessoryNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnAccessoryNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnAccessoryNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnAccessoryNameRisk").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var AccessoryRepresentativeId = $("#hdnAccessoryIdRisk").val();
            var AccessoryRepresentativeName = $("#hdnAccessoryNameRisk").val();

            if (parseInt(AccessoryRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvAccessoryRepresentativeRisk' + AccessorycounterRisk);
                if (AccessorycounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtAccessoryRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteAccessoryRepresentativeRisk(' + AccessorycounterRisk + ', ' + AccessoryRepresentativeId + ', \'' + AccessoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtAccessoryRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteAccessoryRepresentativeRisk(' + AccessorycounterRisk + ', ' + AccessoryRepresentativeId + ', \'' + AccessoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvAccessoryRepresentativeValuesRisk.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtAccessoryRepresentativeRisk.ClientID %>').val('');
            AccessorycounterRisk++;
            $("#hdnAccessoryIdRisk").val('0');
            $("#hdnAccessoryNameRisk").val('');
        }
        else {
            alert("Please enter Accessory Representative.")
        }
    }

    function DeleteAccessoryRepresentativeRisk(AccessorycounterRisk, AccessoryRepresentativeId, AccessoryRepresentativeName) {
       
        var AccessoryRepresentativeIds = $("#<%=hdnAccessoryRepresentativeIdRisk.ClientID%>").val();
        var AccessoryRepresentativeNames = $("#<%=hdnAccessoryRepresentativeNameRisk.ClientID%>").val();

        $("#dvAccessoryRepresentativeRisk" + AccessorycounterRisk).remove();
        $("#<%=hdnAccessoryRepresentativeIdRisk.ClientID%>").val(AccessoryRepresentativeIds.replace(AccessoryRepresentativeId, ''));
        $("#<%=hdnAccessoryRepresentativeNameRisk.ClientID%>").val(AccessoryRepresentativeNames.replace(AccessoryRepresentativeName, ''));

        AccessoryRepresentativeIds = $("#<%=hdnAccessoryRepresentativeIdRisk.ClientID%>").val();
        AccessoryRepresentativeIds = (AccessoryRepresentativeIds.replace(',,', ','));

        AccessoryRepresentativeNames = $("#<%=hdnAccessoryRepresentativeNameRisk.ClientID%>").val();
        AccessoryRepresentativeNames = (AccessoryRepresentativeNames.replace(',,', ','));

        $("#<%=hdnAccessoryRepresentativeIdRisk.ClientID%>").val(AccessoryRepresentativeIds);
        $("#<%=hdnAccessoryRepresentativeNameRisk.ClientID%>").val(AccessoryRepresentativeNames);

        var lastCharAccessoryRepresentativeIds = AccessoryRepresentativeIds.substr(AccessoryRepresentativeIds.length - 1);
        var lastCharAccessoryRepresentativeNames = AccessoryRepresentativeNames.substr(AccessoryRepresentativeNames.length - 1);

        if (lastCharAccessoryRepresentativeIds === ",") {
            $("#<%=hdnAccessoryRepresentativeIdRisk.ClientID%>").val(AccessoryRepresentativeIds.substring(0, AccessoryRepresentativeIds.length - 1))
        }

        if (lastCharAccessoryRepresentativeNames === ",") {
            $("#<%=hdnAccessoryRepresentativeNameRisk.ClientID%>").val(AccessoryRepresentativeNames.substring(0, AccessoryRepresentativeNames.length - 1))
        }
    }
    //==Out=========================================================================================//
    var OutcounterRisk = parseInt($('#<%= hdnOutCounterRisk.ClientID %>').val());
    function AddOutRepresentative1() {
       
        if (jQuery.trim($('#<%= txtOutRepresentativeRisk.ClientID %>').val()) != '') {
            var objIds = '<%=hdnOutRepresentativeIdRisk.ClientID%>';
            var objNames = '<%=hdnOutRepresentativeNameRisk.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnOutIdRisk").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnOutIdRisk").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnOutIdRisk").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtOutRepresentativeRisk.ClientID %>').val('');
                            $("#hdnOutIdRisk").val('0');
                            $("#hdnOutNameRisk").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnOutNameRisk").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnOutNameRisk").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnOutNameRisk").val();
                }
            }
            else {
                if ((strNames) == '') {
                    strIds = 0;
                    strNames = $('#<%= txtOutRepresentativeRisk.ClientID %>').val();
                }
                else {
                    strIds = strIds + ',' + 0;
                    strNames = strNames + ',' + $('#<%= txtOutRepresentativeRisk.ClientID %>').val();
                }
            }

            var OutRepresentativeId = $("#hdnOutIdRisk").val();
            var OutRepresentativeName = $('#<%= txtOutRepresentativeRisk.ClientID %>').val();
            if ($("#" + objNames).val().indexOf($('#<%= txtOutRepresentativeRisk.ClientID %>').val()) == -1) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvOutRepresentativeRisk' + OutcounterRisk);
                if (OutcounterRisk == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtOutRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteOutRepresentativeRisk(' + OutcounterRisk + ', ' + OutRepresentativeId + ', \'' + OutRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtOutRepresentativeRisk.ClientID %>').val() + ' <a onclick="DeleteOutRepresentativeRisk(' + OutcounterRisk + ', ' + OutRepresentativeId + ', \'' + OutRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvOutRepresentativeValuesRisk.ClientID %>");

                $("#" + objIds).val(strIds);
                $("#" + objNames).val(strNames);

                $("#hdnOutIdRisk").val('0');
                $("#hdnOutNameRisk").val('');
            }
            else {
                alert("This Representative already exist")
            }
            $('#<%= txtOutRepresentativeRisk.ClientID %>').val('');
            OutcounterRisk++;

        }
        else {
            alert("Please enter Out Representative.")
        }
    }

    function DeleteOutRepresentativeRisk(OutcounterRisk, OutRepresentativeId, OutRepresentativeName) {
       
        var OutRepresentativeIds = $("#<%=hdnOutRepresentativeIdRisk.ClientID%>").val();
        var OutRepresentativeNames = $("#<%=hdnOutRepresentativeNameRisk.ClientID%>").val();

        $("#dvOutRepresentativeRisk" + OutcounterRisk).remove();
        $("#<%=hdnOutRepresentativeIdRisk.ClientID%>").val(OutRepresentativeIds.replace(OutRepresentativeId, ''));
        $("#<%=hdnOutRepresentativeNameRisk.ClientID%>").val(OutRepresentativeNames.replace(OutRepresentativeName, ''));

        OutRepresentativeIds = $("#<%=hdnOutRepresentativeIdRisk.ClientID%>").val();
        OutRepresentativeIds = (OutRepresentativeIds.replace(',,', ','));

        OutRepresentativeNames = $("#<%=hdnOutRepresentativeNameRisk.ClientID%>").val();
        OutRepresentativeNames = (OutRepresentativeNames.replace(',,', ','));

        $("#<%=hdnOutRepresentativeIdRisk.ClientID%>").val(OutRepresentativeIds);
        $("#<%=hdnOutRepresentativeNameRisk.ClientID%>").val(OutRepresentativeNames);

        var lastCharOutRepresentativeIds = OutRepresentativeIds.substr(OutRepresentativeIds.length - 1);
        var lastCharOutRepresentativeNames = OutRepresentativeNames.substr(OutRepresentativeNames.length - 1);

        if (lastCharOutRepresentativeIds === ",") {
            $("#<%=hdnOutRepresentativeIdRisk.ClientID%>").val(OutRepresentativeIds.substring(0, OutRepresentativeIds.length - 1))
        }

        if (lastCharOutRepresentativeNames === ",") {
            $("#<%=hdnOutRepresentativeNameRisk.ClientID%>").val(OutRepresentativeNames.substring(0, OutRepresentativeNames.length - 1))
        }
    }
    //end abhishek code=======================================//
</script>
