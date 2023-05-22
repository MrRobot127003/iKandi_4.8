<%@ Page Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true"
    CodeBehind="ReallocationQuantity.aspx.cs" Inherits="iKandi.Web.Internal.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <html xmlns="http://www.w3.org/TR/REC-html40">
    <head>
        <style>
    @import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,400;1,300&display=swap');
     #QuantityMovement  
     {   
        width: 100%;
      
        margin: 0 auto;
        padding: 10px;
        box-sizing: border-box;
  
        }
     #QuantityMovement table
     {
        padding: 10px 20px 20px;
        box-sizing: border-box;
        border-radius: 10px 10px 0px 0px;
        width:100%;
        
     }
    #QuantityMovement table,tr,td,th
     {
         border: 1px solid lightgray;
         border-collapse: collapse;
         padding: 6px 5px;
     }
    #QuantityMovement h2
    {
            text-align: center;
            margin: 0;
            padding: 7px;
            font-size: 21px;
            font-family: 'Poppins', sans-serif;
            letter-spacing: 0.3px;
            text-transform: capitalize;
            border-radius: 10px 10px 0px 0px;
            background-color: #39589c;
            color: #e7e6e6;
   }
   #QuantityMovement table tr td select,input
   {
            border-radius: 5px;
            border-color: lightgray;
            padding: 3px;
            background-color:White;
            box-shadow: inset -10px -10px 10px #ffffff70,inset 10px 10px 10px #aeaec020;
    }
     #QuantityMovement table tr td label
         {
           font-family: 'Poppins';
           margin-right: 10px;
           font-family: 'Poppins', sans-serif;
         }       
  #QuantityMovement table tr td .search_btn{
        background-color: #39589c;
        box-shadow: none;
        color: white;
        border: 0;
        padding: 6px 10px;
    }
    
.table_wrapper .search_btn{
        background-color: #39589c;
        box-shadow: none;
        color: white;
        border: 0;
        padding: 6px 10px;
        margin: 10px;
    }
 #QuantityMovement .search_btn{
        background-color: #39589c;
        box-shadow: none;
        color: white;
        border: 0;
        padding: 6px 10px;
        margin: 10px;
    }
    .table_wrapper{display:flex;}
    
  .table_wrapper div > span{
    padding: 10px;
    display: block;
    font-size: 18px;
    color: darkslategray;
    border: 1px solid gray;
    }
    .grdVisibility
    {
        display:none;
    }
    .grdVisibility2
    {
        display:block;
    }
    .auto-fabricname
    {
        width:172px;
    }
</style>
        <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
        <script type="text/javascript">
            var fabric_Quality_id;
            var Qualityid = 0;
            var AllocatedToMoveValue = 0;
            var Subtractvalue = 0;
            var AddValueTo = 0;
            var orderDetailsId = 0;
            var TotalValFrom = 0;
            var TotalValTO = 0;

            $(document).ready(function () {

                var Qualityid = "";
                var hdnQuality_Id = '<%=hdnFabric_Qualityid.ClientID %>';
                var HiddenField1Type = "<%=HiddenField1Type.ClientID %>";
                var val = -1;
                if ($("#" + HiddenField1Type).val() == "1") {
                    $("#<%=ddlAccessoryStage1.ClientID %>").hide();
                    $("#<%=ddlAccessoryStage2.ClientID %>").hide();
                    $("#<%=ddlstagetype1.ClientID %>").attr("disabled", "");
                    $("#<%=ddlstagetype2.ClientID %>").attr("disabled", "");
                    $("#<%=ddlstagetype3.ClientID %>").attr("disabled", "");
                    $("#<%=ddlstage4.ClientID %>").attr("disabled", "");
                    $("#<%=ddlFabricType.ClientID %>").attr("disabled", "");
                    $("#<%=txtAccessory.ClientID %>").hide();
                    $("#<%=txtAccessoryColor.ClientID %>").hide();
                    $("#<%=txtColorPrint.ClientID %>").attr("disabled", "");
                    $("#<%=txtFabric.ClientID %>").attr("disabled", "");
                    $("#<%=ddlAccessoryType.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlAccessoryType.ClientID %>").hide();
                }
                else if ($("#" + HiddenField1Type).val() == "2") {
                    $("#<%=txtAccessory.ClientID %>").show();
                    $("#<%=txtAccessoryColor.ClientID %>").show();
                    $("#<%=ddlAccessoryStage1.ClientID %>").show();
                    $("#<%=ddlAccessoryStage2.ClientID %>").show();
                    $("#<%=ddlAccessoryType.ClientID %>").show();
                    $("#<%=ddlstagetype1.ClientID %>").hide();
                    $("#<%=ddlstagetype2.ClientID %>").hide();
                    $("#<%=ddlstagetype3.ClientID %>").hide();
                    $("#<%=ddlFabricType.ClientID %>").hide();
                    $("#<%=txtFabric.ClientID %>").hide();
                    $("#<%=ddlstage4.ClientID %>").hide();
                    $("#<%=txtColorPrint.ClientID %>").hide();
                }
                else {
                    $("#<%=ddlstagetype1.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlstagetype2.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlstagetype3.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlstage4.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlFabricType.ClientID %>").attr("disabled", "disabled");
                    $("#<%=txtAccessoryColor.ClientID %>").hide();
                    $("#<%=txtAccessory.ClientID %>").hide();
                    $("#<%=ddlAccessoryType.ClientID %>").hide();
                    $("#<%=ddlAccessoryStage1.ClientID %>").hide();
                    $("#<%=ddlAccessoryStage2.ClientID %>").hide();
                    $("#<%=txtColorPrint.ClientID %>").attr("disabled", "disabled");
                    $("#<%=txtFabric.ClientID %>").attr("disabled", "disabled");
                }

                $('.dropone').change(function () {

                    val = $(this).val();

                    if (val == "1") {

                        $("#" + HiddenField1Type).val("");
                        $("#" + HiddenField1Type).val(1);

                        $("#<%=td_stage3.ClientID %>").show();
                        $("#<%=td_stage4.ClientID %>").show();

                        $("#<%=txtFabric.ClientID %>").val("");
                        $("#<%=txtColorPrint.ClientID %>").val("");

                        $("#<%=txtFabric.ClientID %>").show();
                        $("#<%=txtAccessory.ClientID %>").hide();
                        $("#<%=txtAccessoryColor.ClientID %>").hide();
                        $("#<%=txtColorPrint.ClientID %>").show();
                        $("#<%=txtColorPrint.ClientID %>").attr("disabled", "disabled");
                        $("#<%=txtFabric.ClientID %>").attr("disabled", "");
                        $("#<%=ddlAccessoryStage1.ClientID %>").hide();
                        $("#<%=ddlAccessoryStage2.ClientID %>").hide();
                        $("#<%=ddlstagetype1.ClientID %>").show();
                        $("#<%=ddlstagetype2.ClientID %>").show();
                        $("#<%=ddlstagetype3.ClientID %>").show();
                        $("#<%=ddlstagetype1.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstagetype2.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstagetype3.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstage4.ClientID %>").attr("disabled", "");
                        $("#<%=ddlFabricType.ClientID %>").attr("disabled", "");
                        $("#<%=ddlAccessoryType.ClientID %>").hide();
                        $("#<%=ddlstage4.ClientID %>").show();
                        $("#<%=ddlFabricType.ClientID %>").show();
                        $("#<%=grdfromAccessory.ClientID %>").hide();
                        $("#<%=grdToAccessory.ClientID %>").hide();
                        $("#<%=grdto.ClientID %>").show();
                        $("#<%=grdFrom.ClientID %>").show();

                        $("#ctl00_cph_main_content_spanSize").html('');

                        $("#<%=ddlType.ClientID %> option:eq(0)").attr('disabled', 'disabled');

                    }
                    else if (val == "2") {

                        $("#" + HiddenField1Type).val("");
                        $("#" + HiddenField1Type).val(2);

                        $("#<%=td_stage3.ClientID %>").hide();
                        $("#<%=td_stage4.ClientID %>").hide();



                        $("#<%=grdfromAccessory.ClientID %>").hide();
                        $("#<%=grdToAccessory.ClientID %>").hide();

                        $("#<%=txtFabric.ClientID %>").hide();
                        $("#<%=txtAccessory.ClientID %>").show();

                        $("#<%=txtColorPrint.ClientID %>").hide();
                        $("#<%=txtAccessoryColor.ClientID %>").show();
                        $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "disabled");

                        $("#<%=ddlstagetype1.ClientID %>").hide();
                        $("#<%=ddlstagetype2.ClientID %>").hide();
                        $("#<%=ddlstagetype3.ClientID %>").hide();

                        $("#<%=ddlAccessoryStage1.ClientID %>").show();
                        $("#<%=ddlAccessoryStage1.ClientID %>").val(-1);
                        $("#<%=ddlAccessoryStage1.ClientID %>").attr("disabled", "disabled");

                        $("#<%=ddlAccessoryStage2.ClientID %>").show();
                        $("#<%=ddlAccessoryStage2.ClientID %>").val(-1);
                        $("#<%=ddlAccessoryStage2.ClientID %>").attr("disabled", "disabled");

                        $("#<%=ddlFabricType.ClientID %>").hide();
                        $("#<%=ddlAccessoryType.ClientID %>").show();
                        $("#<%=ddlAccessoryType.ClientID %>").val(-1);
                        $("#<%=txtAccessory.ClientID %>").val("");
                        $("#<%=txtAccessoryColor.ClientID %>").val("");

                        $("#<%=ddlstage4.ClientID %>").hide();

                        $("#ctl00_cph_main_content_spanSize").html('');
                        $("#<%=ddlType.ClientID %> option:eq(0)").attr('disabled', 'disabled');

                        $("#<%=txtAccessory.ClientID %>").css("border", "1px solid #cccccc  ");
                        $("#<%=txtAccessoryColor.ClientID %>").css("border", "1px solid #cccccc  ");


                    }
                    else {
                        $("#<%=txtFabric.ClientID %>").attr("disabled", "disabled");
                        $("#<%=txtColorPrint.ClientID %>").attr("disabled", "disabled");
                    }
                });

                $("input[type=text].auto-fabricname").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricNameByName1", { dataType: "xml", datakey: "string", max: 100, "width": "710px" });

                $("input[type=text].auto-fabricname").result(function () {
                    mys = $(this).val().split('$');
                    if (mys[1] == undefined) {
                        $(this).val('');
                        return false;
                    }
                    mys2 = mys[1].split('**');
                    $(this).val(mys2[0]);
                    fabric_Quality_id = mys2[1];
                    $("#" + hdnQuality_Id).val(fabric_Quality_id);
                    $("#<%=txtColorPrint.ClientID %>").attr("disabled", "");
                    $("#<%=txtColorPrint.ClientID %>").val("");

                });

                $("input[type=text].auto-Accessory-Name").autocomplete("/Webservices/iKandiService.asmx/SuggestAccessoryByName", { dataType: "xml", datakey: "string", max: 100, "width": "710px",
                    extraParams: { flag: "Accessory", TradeName: "" }
                });

                $("input[type=text].auto-Accessory-Name").result(function () {
                    var acc = $(this).val().split('$');
                    if (acc[1] != "" && acc[1] !== undefined) {
                        $(this).val(acc[1]);

                        if ($("#<%=ddlAccessoryType.ClientID %>").val() == "1") {
                            $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "disabled");
                        }
                        $("#<%=hdnAccessory.ClientID %>").val(acc[1]);
                        $("#<%=txtAccessoryColor.ClientID %>").val("");
                        $("#<%=HdnAccSize.ClientID %>").val(acc[2]);

                        if ($("#<%=HdnAccSize.ClientID %>").val != "") {
                            $("#<%=spanSize.ClientID %>").html("Size :" + $("#<%=HdnAccSize.ClientID %>").val());
                        }

                        if ($("#<%=txtAccessory.ClientID %>").val() != "") {
                            $("#<%=txtAccessory.ClientID %>").css("border", "1px solid #cccccc  ");
                        }
                    }
                    else {
                        $(this).val('');
                        $("#<%=spanSize.ClientID %>").html('');
                        return false;
                    }
                });

                $("input[type=text].auto-color-Acc").autocomplete("/Webservices/iKandiService.asmx/SuggestAccessoryByName", { dataType: "xml", datakey: "string", max: 100, "width": "200px",
                    extraParams: { flag: "Color_Print",
                        TradeName: function () {
                            return $("#<%=hdnAccessory.ClientID %>").val();
                        }
                    }
                });

                $(".auto-color-Acc").result(function () {
                    var acc = $(this).val().split('**');
                    if (acc[1] != "") {
                        $(this).val(acc[1]);
                        if ($("#<%=txtAccessory.ClientID %>").val() != "") {
                            $("#<%=txtAccessoryColor.ClientID %>").css("border", "1px solid #cccccc");
                        }
                    }
                });

                $("input[type=text].auto-color").autocomplete1("/Webservices/iKandiService.asmx/SuggestColorPrintName", { dataType: "xml", datakey: "string", max: 100, "width": "710px", extraParams:
                                                    {
                                                        Qualityid: function () {

                                                            return $("#" + hdnQuality_Id).val();
                                                        }
                                                    }, onerr: function () {

                                                        alert("some error have occured ");
                                                    }
                });

                $("input[type=text].auto-color").result(function () {
                    var col = $(this).val().split('**');
                    $(this).val(col[1]);
                });

                var hdnIsReadOnly = $("#<%=hdnIsReadOnly.ClientID %>").val();
                if (hdnIsReadOnly = "1") {

                    $("#<%=Btnsubmit.ClientID %>").attr("disabled", "disabled");
                }
                else {

                    $("#<%=Btnsubmit.ClientID %>").attr("disabled", "");
                }
            });

            function OnchangeValidation(flag) {

                if (flag == "Fabric") {
                    var selectedVal = $("#<%=ddlFabricType.ClientID %> option:selected").val();
                    var selectedValText = $("#<%=ddlFabricType.ClientID %> option:selected").text();
                    if (selectedVal == "1" || selectedValText == "RFDStage1" || selectedVal == "-1" || selectedVal == "10") {

                        if (selectedVal != "10") {
                            $("#<%=txtColorPrint.ClientID %>").val("");
                            $("#<%=txtColorPrint.ClientID %>").attr("disabled", "disabled");
                        }
                        else {
                            $("#<%=txtColorPrint.ClientID %>").attr("disabled", "");
                        }
                        $("#<%=ddlstagetype2.ClientID %>").attr("disabled", "disabled");
                        $("#<%=ddlstagetype3.ClientID %>").attr("disabled", "disabled");
                        $("#<%=ddlstage4.ClientID %>").attr("disabled", "disabled");
                    }
                    else {
                        $("#<%=txtColorPrint.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstagetype2.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstagetype3.ClientID %>").attr("disabled", "");
                        $("#<%=ddlstage4.ClientID %>").attr("disabled", "");
                    }

                }
                else if (flag == "Accessory") {

                    selectedVal = $("#<%=ddlAccessoryType.ClientID %> option:selected").val();
                    switch (selectedVal) {
                        case "1":
                            $("#<%=ddlAccessoryStage1.ClientID %>").val(1);
                            $("#<%=ddlAccessoryStage1.ClientID %>").attr("disabled", "disabled");

                            $("#<%=ddlAccessoryStage2.ClientID %>").val(-1);
                            $("#<%=ddlAccessoryStage2.ClientID %>").attr("disabled", "disabled");

                            $("#<%=txtAccessoryColor.ClientID %>").val("");
                            $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "disabled");

                            $("#<%=ddlAccessoryType.ClientID %>").css("border", "1px solid #cccccc");
                            break;
                        case "3":
                            $("#<%=ddlAccessoryStage1.ClientID %>").val(1);
                            $("#<%=ddlAccessoryStage1.ClientID %>").attr("disabled", "disabled");

                            $("#<%=ddlAccessoryStage2.ClientID %>").val(3);
                            $("#<%=ddlAccessoryStage2.ClientID %>").attr("disabled", "disabled");

                            $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "");
                            $("#<%=ddlAccessoryType.ClientID %>").css("border", "1px solid #cccccc");

                            break;
                        case "2":
                            $("#<%=ddlAccessoryStage1.ClientID %>").val(2);
                            $("#<%=ddlAccessoryStage1.ClientID %>").attr("disabled", "disabled");

                            $("#<%=ddlAccessoryStage2.ClientID %>").val(-1);
                            $("#<%=ddlAccessoryStage2.ClientID %>").attr("disabled", "disabled");

                            $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "");
                            $("#<%=ddlAccessoryType.ClientID %>").css("border", "1px solid #cccccc");

                            break;
                        case "-1":
                            $("#<%=txtAccessoryColor.ClientID %>").attr("disabled", "disabled");
                    }
                }
            }

            function ValidateQuantity(obj, flag) {

                if (flag == "Fabric") {
                    var subtractValue = $(obj).val();
                    var lblAvailable = $(obj).closest("tr").find('span[id*="lblAvailable"]').text();
                    var hdnoldSubValue = $(obj).closest("tr").find('input[id*="hdnAvailableOld"]').val();
                    var hdnavailableValueOld = $(obj).closest("tr").find('input[id*="hdnavailableValueOld"]').val();
                    hdnavailableValueOld = hdnavailableValueOld.indexOf(',') > -1 ? hdnavailableValueOld.replace(',', '') : hdnavailableValueOld;

                    if (parseInt(subtractValue) > parseInt(hdnavailableValueOld)) {
                        alert("Subtract Qty " + subtractValue + " can't be greater than Allocated Pass Qty " + hdnavailableValueOld);

                        if (hdnoldSubValue != "0") {
                            $(obj).val(hdnoldSubValue);
                        }
                        else {
                            $(obj).val("0");
                        }
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                        Subtractvalue = 0;
                        $(obj).closest("tr").find('span[id*="lblAvailable"]').text(hdnavailableValueOld);
                        return false;
                    }
                    else {
                        $(obj).css('border-color', '');
                        lblAvailable = parseInt(hdnavailableValueOld) - parseInt(subtractValue == "" ? "0" : subtractValue);
                        $(obj).closest("tr").find('span[id*="lblAvailable"]').text(lblAvailable);
                    }
                }

                else if (flag == "Accessory") {
                    var subtractValue = $(obj).val();

                    var lblAvailable = $(obj).closest("tr").find('span[id*="lblAvailable"]').text();
                    var hdnavailableValueOld = $(obj).closest("tr").find('input[id*="hdnavailableValueOld"]').val();

                    if (parseFloat(subtractValue) > parseFloat(hdnavailableValueOld)) {
                        alert("Subtract Qty " + subtractValue + " can't be greater than Allocated Pass Qty " + hdnavailableValueOld);

                        if ($("#" + hdnavailableValueOld).val() != "0") {
                            $(obj).val($("#" + hdnavailableValueOld).val());
                        }
                        else {
                            $(obj).val("0");
                        }
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                        Subtractvalue = 0;
                        return false;
                    }
                    else {
                        $(obj).css('border-color', '');
                        lblAvailable = parseFloat(hdnavailableValueOld) - parseFloat(subtractValue == "" ? "0" : subtractValue);
                        $(obj).closest("tr").find('span[id*="lblAvailable"]').text(lblAvailable);
                    }
                }
            }
            function Addvalidation(obj, flag) {

                if (flag == "Fabric") {
                    var addvalue = $(obj).val();
                    var lblRequireQty = $(obj).closest("tr").find('span[id*="lblRequireQty"]').text();
                    var hdnoldRequiredQuantity = $(obj).closest("tr").find('input[id*="hdnoldRequiredQuantity"]').val();
                    hdnoldRequiredQuantity = hdnoldRequiredQuantity.indexOf(',') > -1 ? hdnoldRequiredQuantity.replace(",", "") : hdnoldRequiredQuantity;

                    if ($(obj).closest("tr").find('input[id*="hdnOrderDetailsid"]').val() == orderDetailsId) {
                        alert("Cant't move to same contract!");
                        $('#' + obj.id).val('');
                        $('#' + obj.id).attr("disabled", "disabled");
                        return false;
                    }

                    else if (parseInt(addvalue) > parseInt(hdnoldRequiredQuantity)) {
                        alert("Add Qty " + addvalue + " can't be greater than Required Pass Qty " + hdnoldRequiredQuantity);
                        $(obj).val("0");
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                    }
                    else {
                        $(obj).css('border-color', '');
                        lblRequireQty = parseInt(hdnoldRequiredQuantity) - parseInt(addvalue == "" ? "0" : addvalue);
                        $(obj).closest("tr").find('span[id*="lblRequireQty"]').text(lblRequireQty);
                        var hdnEditedReqQty = $(obj).closest("tr").find('input[id*="hdnEditedReqQty"]').val(lblRequireQty);
                    }
                    AddValueTo = parseInt(AddValueTo) + parseInt($(obj).closest("tr").find('input:text[id$="txtAdd"]').val());


                    $("#<%=hdnAddValueTo.ClientID %>").val(AddValueTo);
                    var TotalAddQty = $("#<%=hdnAddValueTo.ClientID %>").val();
                    var TotalSubQty = $("#<%=hdnTotalSubtractQty.ClientID %>").val();
                    if (parseInt(TotalAddQty) > parseInt(TotalSubQty)) {
                        alert("Total Add Qty " + TotalAddQty + " can't be greater than Total Subtract Qty " + TotalSubQty);
                        $(obj).val("0");
                        AddValueTo = 0;
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                        $(obj).closest("tr").find('span[id*="lblRequireQty"]').text(hdnoldRequiredQuantity);

                        return false;
                    }
                    else {
                        $(obj).css('border-color', '');
                    }

                    AddValueTo = 0;
                }

                else if (flag == "Accessory") {

                    var addvalue = $(obj).val();
                    var lblRequireQty = $(obj).closest("tr").find('span[id*="lblRequireQty"]').text();
                    var hdnoldRequiredQuantity = $(obj).closest("tr").find('input[id*="hdnoldRequiredQuantity"]').val();

                    if ($(obj).closest("tr").find('input[id*="hdnOrderDetailsid"]').val() == orderDetailsId) {
                        alert("Cant't move to same contract!");
                        $('#' + obj.id).val('');
                        $('#' + obj.id).attr("disabled", "disabled");
                        return false;
                    }
                    else if (parseFloat(addvalue) > parseFloat(hdnoldRequiredQuantity)) {
                        alert("Add Qty " + addvalue + " can't be greater than Required Pass Qty " + lblRequireQty);
                        $(obj).val("0");
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                        return false;
                    }
                    else {
                        $(obj).css('border-color', '');
                        lblRequireQty = parseFloat(hdnoldRequiredQuantity) - parseFloat(addvalue == "" ? "0" : addvalue);
                        $(obj).closest("tr").find('span[id*="lblRequireQty"]').text(lblRequireQty);
                        var hdnEditedReqQty = $(obj).closest("tr").find('input[id*="hdnEditedReqQty"]').val(lblRequireQty);
                    }

                    $("#<%=grdToAccessory.ClientID%> tr:has(td)").each(function (index, td) {
                        AddValueTo = parseFloat(AddValueTo) + parseFloat($(td).find('input:text[id$="txtAdd"]').val());
                        $("#<%=hdnAddValueTo.ClientID %>").val(AddValueTo);
                    });

                    var TotalAddQty = $("#<%=hdnAddValueTo.ClientID %>").val();
                    TotalAddQty == "" ? "0" : TotalAddQty;
                    var TotalSubQty = $("#<%=hdnTotalSubtractQty.ClientID %>").val();
                    if (TotalSubQty == "") {
                        TotalSubQty = "0";
                    }
                    if (parseFloat(TotalAddQty) > parseFloat(TotalSubQty)) {
                        alert("Total Add Qty " + TotalAddQty + " can't be greater than Total Subtract Qty " + TotalSubQty);
                        $(obj).val("0");
                        AddValueTo = 0;
                        $(obj).focus();
                        $(obj).css('border-color', 'red');
                        return false;
                    }
                    else {
                        $(obj).css('border-color', '');
                    }
                    AddValueTo = 0;
                }
            }
            function changeSubtractQty(obj, flag) {
                var temp = 0;

                if (flag == "Fabric") {
                    var subtractValue = $(obj).val();
                    if (subtractValue == "" || subtractValue == "0") {
                        $(obj).val('');

                        $("#<%=grdFrom.ClientID%> tr:has(td)").each(function () {
                            $(this).find('input:text[id$="txtSubtract"]').attr("disabled", "");
                        });

                        $("#<%=grdto.ClientID%> tr:has(td)").each(function () {
                            $(this).find('input:text[id$="txtAdd"]').attr("disabled", "disabled");
                            $(this).find('input:text[id$="txtAdd"]').val("");
                        });
                    }
                    else {

                        $("#<%=grdFrom.ClientID%> tr:has(td)").each(function () {
                            Subtractvalue = parseInt(Subtractvalue) + parseInt($(this).find('input:text[id$="txtSubtract"]').val());
                            $("#<%=hdnTotalSubtractQty.ClientID %>").val(Subtractvalue);

                            if ($(this).find('input:text[id$="txtSubtract"]').val() > 0) {
                                temp = 1;
                                orderDetailsId = $(this).find('input[id*="hdnOrderDetailsid"]').val();
                            }
                            if (temp == 1 && $(this).find('input:text[id$="txtSubtract"]').val() <= 0) {
                                $(this).find('input:text[id$="txtSubtract"]').attr("disabled", "disabled");
                            }

                            $("#<%=grdto.ClientID%> tr:has(td)").each(function () {
                                $(this).find('input:text[id$="txtAdd"]').attr("disabled", "");
                            });
                        });
                        Subtractvalue = 0;
                    }
                }

                else if (flag == "Accessory") {
                    var subtractValue = $(obj).val();

                    if (subtractValue == "" || subtractValue == "0") {
                        $(obj).val('');

                        $("#<%=grdfromAccessory.ClientID%> tr:has(td)").each(function () {
                            $(this).find('input:text[id$="txtSubtract"]').attr("disabled", "");
                        });

                        $("#<%=grdToAccessory.ClientID%> tr:has(td)").each(function () {
                            $(this).find('input:text[id$="txtAdd"]').attr("disabled", "disabled");
                            $(this).find('input:text[id$="txtAdd"]').val("");
                        });
                    }
                    else {
                        $("#<%=grdfromAccessory.ClientID%> tr:has(td)").each(function () {
                            Subtractvalue = parseFloat(Subtractvalue) + parseFloat($(this).find('input:text[id$="txtSubtract"]').val());
                            $("#<%=hdnTotalSubtractQty.ClientID %>").val(Subtractvalue);
                            if ($(this).find('input:text[id$="txtSubtract"]').val() > 0) {
                                temp = 1;
                                orderDetailsId = $(this).find('input[id*="hdnOrderDetailsid"]').val();
                            }
                            if (temp == 1 && $(this).find('input:text[id$="txtSubtract"]').val() <= 0) {
                                $(this).find('input:text[id$="txtSubtract"]').attr("disabled", "disabled");
                            }

                            $("#<%=grdToAccessory.ClientID%> tr:has(td)").each(function () {
                                $(this).find('input:text[id$="txtAdd"]').attr("disabled", "");
                            });
                        });
                        Subtractvalue = 0;
                    }
                }
            }
            function ValidationSubmit(flag) {

                var count = 0;

                if (flag == "Fabric") {
                    $("#<%=grdFrom.ClientID%> tr:has(td)").each(function (index, td) {
                        var y = $(td).find('input:text[id$="txtSubtract"]').val();
                        if ($(td).find('input:text[id$="txtSubtract"]').val() > 0) {
                            TotalValFrom = parseInt($(td).find('input:text[id$="txtSubtract"]').val());
                            count = count + 1;
                        }
                    });

                    $("#<%=grdto.ClientID%> tr:has(td)").each(function (index, td) {
                        var x = $(td).find('input:text[id$="txtAdd"]').val();
                        if ($(td).find('input:text[id$="txtAdd"]').val() > 0) {
                            TotalValTO = TotalValTO + parseInt($(td).find('input:text[id$="txtAdd"]').val());
                        }
                    });

                    if (TotalValFrom == TotalValTO) {
                        TotalValFrom = 0;
                        TotalValTO = 0;
                        return true;
                    }
                    else {
                        alert("Adjust All Left Side Qty to Right Side !");
                        TotalValFrom = 0;
                        TotalValTO = 0;
                        return false;
                    }
                    if (count > 0) {
                        return true;
                    }
                    else {
                        alert("Please Add Some value To Move !");
                        return false;
                    }
                }
                else if (flag == "Accessory") {

                    $("#<%=grdfromAccessory.ClientID%> tr:has(td)").each(function (index, td) {
                        var y = $(td).find('input:text[id$="txtSubtract"]').val();
                        if ($(td).find('input:text[id$="txtSubtract"]').val() > 0) {
                            TotalValFrom = parseInt($(td).find('input:text[id$="txtSubtract"]').val());
                            count = count + 1;
                        }
                    });

                    $("#<%=grdToAccessory.ClientID%> tr:has(td)").each(function (index, td) {
                        var x = $(td).find('input:text[id$="txtAdd"]').val();
                        if ($(td).find('input:text[id$="txtAdd"]').val() > 0) {
                            TotalValTO = TotalValTO + parseInt($(td).find('input:text[id$="txtAdd"]').val());
                        }
                    });

                    if (TotalValFrom == TotalValTO) {
                        TotalValFrom = 0;
                        TotalValTO = 0;
                        return true;
                    }
                    else {
                        alert("Adjust All Left Side Qty to Right Side !");
                        TotalValFrom = 0;
                        TotalValTO = 0;
                        return false;
                    }
                    if (count > 0) {
                        return true;
                    }
                    else {
                        alert("Please Add Some value To Move !");
                        return false;
                    }
                }
            }
            function Validation() {

                ddltype = $("#<%=ddlType.ClientID %> option:selected").val();

                ddlSupplyTypeFab = $("#<%=ddlFabricType.ClientID %> option:selected").text();

                ddlstagetype1 = $("#<%=ddlstagetype1.ClientID %> option:selected").text();

                ddSupplyTypeAcc = $("#<%=ddlAccessoryType.ClientID %> option:selected").text();

                if (ddltype == "1") {

                    if ($("#<%=txtFabric.ClientID %>").val() == "") {
                        alert("Please Select Fabric Quality.");
                        return false;
                    }

                    else if ((ddlSupplyTypeFab != "GREIGE" && (ddlSupplyTypeFab == "RFDStage1" && ddlstagetype1 != "RFDStage1") && $("#<%=txtColorPrint.ClientID %>").val() == "")) {
                        alert("Please provide color Print");
                        return false;
                    }
                }

                else if (ddltype == "2") {

                    if ($("#<%=txtAccessory.ClientID %>").val() == "") {
                        alert("Please Select Accessory Quality.");
                        $("#<%=txtAccessory.ClientID %>").css("border", "1px solid red");
                        return false;
                    }

                    else if (ddSupplyTypeAcc == "SELECT") {
                        alert("Please Select Stage Type.");
                        $("#<%=ddlAccessoryType.ClientID %>").css("border", "1px solid red");
                        return false;

                    }

                    else if (ddSupplyTypeAcc != "Greige" && $("#<%=txtAccessoryColor.ClientID %>").val() == "") {
                        alert("Please Provide ColorPrint.");
                        $("#<%=txtAccessoryColor.ClientID %>").css("border", "1px solid red");
                        return false;
                    }
                }
            }

            function checkAccessory(txt) {
                if (txt.value == "")
                    $("#<%=spanSize.ClientID %>").html("");

            }

            function checkAvailableQty(obj) {
                var id = obj.id.split("txtSubtract");
                if ($('#' + id[0].concat("lblAvailable")).html() == "") {
                    return false;
                }
            }

            function SuccessMsg(msg) {
                alert(msg);
            }

            function FailedMsg(msg) {
                alert(msg);
            }

        </script>
    </head>
    <body>
        <div id="QuantityMovement">
            <h2>
                Quantity movement from One contract to another</h2>
            <table>
                <tr>
                    <td>
                        <label>
                            Type
                        </label>
                        <asp:DropDownList ID="ddlType" runat="server" class="dropone">
                            <asp:ListItem Text="Please Select Type" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Fabric" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Accessory" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Quality Name</label>
                        <asp:TextBox ID="txtFabric" runat="server" class="auto-fabricname"></asp:TextBox>
                        <asp:TextBox ID="txtAccessory" runat="server" class="auto-Accessory-Name" EnableViewState="true"
                            onchange="checkAccessory(this)"></asp:TextBox>
                        <span id="spanSize" runat="server"></span>
                    </td>
                    <td colspan="3">
                        <label>
                            ColorPrint</label>
                        <asp:TextBox ID="txtColorPrint" runat="server" class="auto-color" EnableViewState="true"></asp:TextBox>
                        <asp:TextBox ID="txtAccessoryColor" runat="server" class="auto-color-Acc" EnableViewState="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label>
                            Select Type</label>
                        <asp:DropDownList ID="ddlFabricType" runat="server" onchange="javascript:OnchangeValidation('Fabric')">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAccessoryType" onchange="javascript:OnchangeValidation('Accessory')"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        ColorPrint is Necessary if Selected Stage is Different From Griege/RFD.
                    </td>
                </tr>
                <tr>
                    <td runat="server" id="td_stage1">
                        <label>
                            Stage 1</label>
                        <asp:DropDownList ID="ddlstagetype1" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAccessoryStage1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td runat="server" id="td_stage2">
                        <label>
                            Stage 2</label>
                        <asp:DropDownList ID="ddlstagetype2" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAccessoryStage2" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td runat="server" id="td_stage3">
                        <label>
                            Stage 3</label>
                        <asp:DropDownList ID="ddlstagetype3" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td runat="server" id="td_stage4">
                        <label>
                            Stage 4</label>
                        <asp:DropDownList ID="ddlstage4" runat="server">
                        </asp:DropDownList>
                        &nbsp;
                    </td>
                    <td>
                        Movement Must Be Between the Same Stages.
                    </td>
                </tr>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpQuantityReallcation" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnSearch" CssClass="search_btn" runat="server" Text="Search" OnClick="btnSearch_Click"
                        OnClientClick=" return Validation();" />
                    <div class="table_wrapper">
                        <div style="width: 50%">
                            <span>From
                                <asp:TextBox ID="txtsearchContractFrom" runat="server" placeHolder="Search By serial Number"
                                    Style="width: 174px;"></asp:TextBox>
                                <asp:Button ID="searchContractFrom" runat="server" Text="Search" CssClass="search_btn"
                                    OnClick="searchContractFrom_Click" />
                            </span>
                            <asp:GridView ID="grdfromAccessory" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="SerialNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNumber" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnOrderDetailsid" runat="server" Value='<%# Eval("OrderDetailID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContractNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exfactory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExfactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allocated PassQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAllocated" runat="server" Text='<%# Convert.ToDecimal(Eval("AllocatedQty")).ToString("#,#.##") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty. Available To move">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvailable" runat="server" Text='<%# Convert.ToDecimal(Eval("ActualAvailabletomove")== DBNull.Value ? 0 : Eval("ActualAvailabletomove")).ToString("#,#.##") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnavailableValueOld" runat="server" Value='<%# Eval("ActualAvailabletomove")== DBNull.Value ? 0 : Eval("ActualAvailabletomove") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subtract">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblSubtract" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="txtSubtract" runat="server" Text='' onKeyPress="return checkAvailableQty(this)"
                                                onchange="ValidateQuantity(this,'Accessory');changeSubtractQty(this,'Accessory');"
                                                Style="width: 100px;"></asp:TextBox>
                                            <asp:HiddenField ID="hdnAvailableOld" runat="server" Value="" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grdFrom" runat="server" AutoGenerateColumns="false" Width="100%"
                                OnSelectedIndexChanged="grdFrom_SelectedIndexChanged" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="SerialNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNumber" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnOrderDetailsid" runat="server" Value='<%# Eval("OrderDetailID") %>' />
                                            <asp:HiddenField ID="hdnFabricDetailsfrm" runat="server" Value='<%# Eval("FabricDetails") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContractNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exfactory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExfactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allocated PassQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAllocated" runat="server" Text='<%# Convert.ToDecimal(Eval("AllocatedQty")).ToString("#,#.##") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty. Available To move">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvailable" runat="server" Text='<%# Convert.ToDecimal(Eval("ActualAvailabletomove")==DBNull.Value ? 0 : Eval("ActualAvailabletomove")).ToString("#,#.##") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnavailableValueOld" runat="server" Value='<%# Eval("ActualAvailabletomove")== DBNull.Value ? 0 :Eval("ActualAvailabletomove")  %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subtract">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSubtract" runat="server" Text='' onchange="ValidateQuantity(this,'Fabric');changeSubtractQty(this,'Fabric');"
                                                Style="width: 100px;"></asp:TextBox>
                                            <asp:HiddenField ID="hdnAvailableOld" runat="server" Value="" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="Btnsubmit" CssClass="search_btn" runat="server" Text="Submit" OnClientClick="return ValidationSubmit('Fabric')"
                                OnClick="Btnsubmit_Click" Visible="false" />
                            <asp:Button ID="BtnsubmitAcc" CssClass="search_btn" runat="server" Text="Submit"
                                OnClientClick="return ValidationSubmit('Accessory')" OnClick="BtnsubmitAcc_Click"
                                Visible="false" />
                        </div>
                        <div style="width: 50%">
                            <span>To
                                <asp:TextBox ID="txtsearchContractTo" runat="server" placeHolder="Search By serial Number"
                                    Style="width: 174px;"></asp:TextBox>
                                <asp:Button ID="searchContractTo" runat="server" Text="Search" CssClass="search_btn"
                                    OnClick="searchContractTo_Click" />
                            </span>
                            <asp:GridView ID="grdToAccessory" runat="server" AutoGenerateColumns="false" Width="100%"
                                EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="SerialNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNumber" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnOrderDetailsid" runat="server" Value='<%# Eval("OrderDetailID") %>' />
                                            <asp:HiddenField ID="hdnFabricDetailsTo" runat="server" Value='<%# Eval("FabricDetails") %>' />
                                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id") %>' />
                                            <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("Size") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContractNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exfactory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExfactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actual Required Qty.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequireQty" runat="server" Text='<%# Convert.ToDecimal(Eval("RequiredQuantity")).ToString("#,#.##") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnoldRequiredQuantity" runat="server" Value='<%# Eval("RequiredQuantity") %>' />
                                            <asp:HiddenField ID="hdnEditedReqQty" runat="server" Value="-1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allocated PassQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAllocated" runat="server" Text='<%# Convert.ToDecimal(Eval("AllocatedQty")).ToString("#,#.##") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                                    <asp:TemplateField HeaderText="Qty. Needed">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccessoryQtyNeeded" runat="server" Text='<%# (Convert.ToDecimal(Eval("RequiredQuantity")) - Convert.ToDecimal(Eval("AllocatedQty"))).ToString("#,#.##") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Add">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAdd" runat="server" Text='' onchange="Addvalidation(this,'Accessory');"
                                                Style="width: 100px" Enabled="false"></asp:TextBox>
                                            <asp:HiddenField ID="hdnAvailableOld" runat="server" Value="0" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grdto" runat="server" AutoGenerateColumns="false" Width="100%"
                                EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="SerialNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNumber" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnOrderDetailsid" runat="server" Value='<%# Eval("OrderDetailID") %>' />
                                            <asp:HiddenField ID="hdnFabricDetailsTo" runat="server" Value='<%# Eval("FabricDetails") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContractNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" Style="color: Blue; font-weight: bold;" runat="server"
                                                Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exfactory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExfactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actual Required Qty.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequireQty" runat="server" Text='<%# Convert.ToInt32(Eval("RequiredQuantity")).ToString("N0") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnoldRequiredQuantity" runat="server" Value='<%# Convert.ToInt32(Eval("RequiredQuantity")).ToString("N0") %>' />
                                            <asp:HiddenField ID="hdnEditedReqQty" runat="server" Value="-1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allocated PassQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAllocated" runat="server" Text='<%# Convert.ToInt32(Eval("AllocatedQty")).ToString("N0") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Qty. Needed">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfabricQtyNeeded" runat="server" Text='<%# (Convert.ToDecimal(Eval("RequiredQuantity")) - Convert.ToDecimal(Eval("AllocatedQty"))).ToString("#,#.##") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Add">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAdd" runat="server" Text='' onchange="Addvalidation(this,'Fabric');"
                                                Style="width: 100px" Enabled="false"></asp:TextBox>
                                            <asp:HiddenField ID="hdnAvailableOld" runat="server" Value="0" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hdnFabric_Qualityid" runat="server" />
            <asp:HiddenField ID="hdnAccessory" runat="server" />
            <asp:HiddenField ID="HiddenField1Type" runat="server" Value="0" />
            <asp:HiddenField ID="HdnAccSize" runat="server" Value="" />
            <asp:HiddenField ID="hdnTotalSubtractQty" runat="server" Value="0" />
            <asp:HiddenField ID="hdnTotalAllocatedQty" runat="server" />
            <asp:HiddenField ID="hdnAddValueTo" runat="server" Value="0" />
            <asp:HiddenField ID="hdnIsReadOnly" runat="server" Value="-1" />
            <asp:HiddenField ID="hdnUserId" runat="server" Value="-1" />
        </div>       
    </body>
    </html>
</asp:Content>
