<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricAccessoriesFormNew.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.FabricAccessoriesFormNew" %>
<link href="../../App_Themes/ikandi/AccessoriesOrder.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/jQuery.print.js"></script>
<script type="text/javascript">

    document.onkeydown = function (e) {
        if (e.ctrlKey && e.keyCode === 80) {
            return false;
        }
    };
    var isExpanded = false;
    var hdnPathClientId = '<%=hdnPath.ClientID %>';
    var hRemarksfabric = '<%=hdnRemarks.ClientID %>';
    var hRemarksMerchant = '<%=hiddenMerchant.ClientID %>';


    $(function () {

        //debugger; 
        $(".loadingimage").hide();
        var TotalCount = $("#<%=hdnTotalCount.ClientID %>", "#main_content").val();
        //debugger;
        $("input.inputNumber", "#main_content").change(function () {
            //debugger;
            var objRow = $(this).parent().parent();
            var element = objRow.find(".inputQuantity");
            element.text(FormatingTotalQuantity(Math.round(TotalCount * $(this).val())));
        });

        //             $(".inputNumber").each(function()
        //              {                                       
        //                   var objRow = $(this).parent().parent();            
        //                var element = objRow.find(".inputQuantity");                
        //                element.text(FormatingTotalQuantity(Math.round(TotalCount * $(this).val())));                
        //             });

        $("input.AccessoriesName", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestAccessoryTradeName", { dataType: "xml", datakey: "string", max: 100 });
        $("input.AccessoriesName", '#main_content').result(function () {
            var f = $(this).val().split('[');
            debugger
            var MatchingString = 'Thread'
            if (f[0].indexOf(MatchingString) != -1) {
                $(this).val(f[0]);
            }
            else {
                $(this).val('');
            };
        });
        //debugger;
        var contracts = $(".order-contract", "#main_content");
        var contractQty = $(".order-total-qty span", "#main_content");
        var fabric1Details = $(".fabric1-details", "#main_content");

        $(".order-contract-qty", "#main_content").each(function () {

            var strData = '';
            var objRow = $(this).parent().parent();
            var inputNumber = objRow.find(".inputNumber");
            //debugger;
            for (var i = 0; i < contracts.length; i++) {
                strData += "CN" + (i + 1) + fabric1Details[i].innerText + "(" + contractQty[i].innerText + "*" + inputNumber.val() + "=" + FormatingTotalQuantity(Math.round(parseFloat(inputNumber.val()) * parseFloat(contractQty[i].innerText.replace(/,/g, '')))) + ")";
                //alert(strData);
            }
            //debugger;
            $(this).html(strData);

        });
    });
    function CheckThreadName(srcElem) {
        var Id = srcElem.id;
        var StrId = Id.substr(67);
        var str = StrId.split("_");
        var ThreadName = srcElem.value;
        var MatchingString = 'thread';
        if (ThreadName.search(MatchingString) == -1) {
            $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_AccessoriesName" + "']").val('');
        }
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
    function fncPrint() {
        var isYes = confirm("Are you sure, you have saved all changes before taking Print?");
        if (isYes == true) {
            window.print();
            return false;
        }

    }
    function PrintPDF3() {


        //        PrintPDFQueryStringWithMerge('', '', '', '&btn=1');      
        //        var panel = document.getElementById("<%=pnlForm.ClientID %>");
        //        var printWindow = window.open('', '', 'height=500,width=900');
        //   
        //        printWindow.document.write(panel.innerHTML);
        //    
        //        printWindow.document.close();
        //        setTimeout(function () {
        //            printWindow.print();
        //        }, 500);
        //        return false;

        debugger;
        //        abhishek
        var panel = document.getElementById("<%=pnlForm.ClientID %>");
        //        var contents = panel.innerHTML;
        //        var frame1 = $('<iframe />');
        //        frame1[0].name = "frame1";
        //        frame1.css({ "position": "absolute", "top": "-1000000px" });
        //        $("body").append(frame1);
        //        var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
        //        frameDoc.document.open();
        //        //Create a new HTML document.
        //        frameDoc.document.write('<html><head><title></title>');
        //        frameDoc.document.write('</head><body>');
        //        //Append the external CSS file.
        //        frameDoc.document.write('<link href="style.css" rel="stylesheet" type="text/css" />');
        //        //Append the DIV contents.
        //        frameDoc.document.write(contents);
        //        frameDoc.document.write('</body></html>');
        //        frameDoc.document.close();
        //        setTimeout(function () {
        //            window.frames["frame1"].focus();
        //            window.frames["frame1"].print();
        //            frame1.remove();
        //        }, 500);


        $('#ctl00_cph_main_content_ucFabricAccessoriesFormNew_pnlForm').printThis({
            //            header: "<h1>Amazing header</h1>"
        });


    }

    function showRemarksFabricWorking(Id1, Id2, Remarks, Type, ApplicationModuleName, Permission, IsHold, styleId) {
        $(".divRemarks").show();

        if ((Permission == 1) && (IsHold == 0)) {
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

        //Added By Ashish on 16/10/2014 for Show Remarks of MO
        //debugger;
        if (ApplicationModuleName == "MANAGE_ORDER_FILE") {
            var MoRemark = Remarks.replace("!<@#", "'");
            var arrStr = MoRemark.split('$$');
            if (arrStr.length > 1) {
                for (var i = 0; i < arrStr.length; i++) {
                    if (i == 0) {
                        $(".label-remarks", "#divRemarks").html(arrStr[i]);
                    }
                    else {
                        $(".label-remarks", "#divRemarks").html($(".label-remarks", "#divRemarks").html() + "</br>" + arrStr[i]);
                    }
                }
            }
            else {
                $(".label-remarks", "#divRemarks").html(Remarks);
            }

        }
        else {
            $(".label-remarks", "#divRemarks").html(Remarks);
        }
        //END


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
        debugger;
        if (IsHold == "1" || IsHold == "2") {
            $("#hdnIsHold").val(IsHold);
        }
        else {
            $("#hdnIsHold").val('-1')
        }
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
        remarks = $.trim(remark)
        var oldRemarks = $(".label-remarks", "#divRemarks").html();
        var date = new Date();


        if (remarks != "") {
            proxy.invoke("UpdateRemarks", { Id1: id1, Id2: id2, Remarks: remarks, Type: type, ApplicationModuleName: applicationModuleName }, function () {

                $(".divRemarks").hide();

                jQuery.facebox("Remarks have been submitted successfully");
                $(".go").click();
            }, onPageError, false, false);
            debugger;
            if (isHold == "1") {
                changeStatusToOnHold(id1, remarks);
            }
            else if (isHold == "2") {
                changeStatusToPrevious(id1, remarks);
            }
        }
        else {
            $(".divRemarks").hide();
        }

    }

    function PrintPDFQueryStringWithMerge(Url, height, width, QS1) {
        //$.showprogress();

        $(".loadingimage").show();
        $(".print").hide();

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
                $(".print").show();
            }
            else {

                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();
                //                
            }
        });

        return false;
    }

    function shRemark() {
        debugger;
        showAccesoriesRemarks(0, 0, $("#" + hRemarksfabric).val(), 0, 0, 1, 0, 0);
    }
    function shMerchantRemark() {
        //debugger;
        showAccesoriesRemarks(0, 0, $("#" + hRemarksMerchant).val(), 0, 0, 1, 0, 0);
    }


    function CalculateContract(elem) {
        //debugger;
        var Id = elem.id;
        var StrId = Id.substr(67);
        var str = StrId.split("_");
        var strCn = str[1].substr(2);
        var val;
        if (elem.value == "") {
            val = 0
        }
        else {
            val = elem.value;
        }
        var Count = $("#<%=hdnCNCount.ClientID %>", "#main_content").val();

        var No = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Number" + "']").val();
        if (No == "") {
            No = 0;
        }
        var valP = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_" + str[1] + "']").val();
        if (valP == "") {
            valP = 0;
        }
        var valCN = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Cont" + strCn + "']").val();
        var CNFirst = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_hdyECN" + strCn + "']").val()
        var totalquantity = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_txtQuantity" + "']").val();

        var Fw = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_FlatW" + strCn + "']").val()
        if (Fw == "") {
            Fw = 0;
        }
        //debugger; 
        var Total = 0;
        var CNTotal = 0;
        var countNo = parseInt(Count) + 1;
        //debugger;
        //Total = parseFloat(CNFirst) * parseFloat(No) * (1 + (parseFloat(Fw)/100)+(parseFloat($("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_CP" + strCn + "']").val()) / 100))
        Total = parseFloat(CNFirst) * parseFloat(No) * (1 + (parseFloat(Fw) / 100) + (parseFloat(valP) / 100))
        var FinalTotal = Total;


        $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Cont" + strCn + "']").val(FinalTotal);

        for (var j = 1; j < countNo; j++) {

            CNTotal = (parseFloat(CNTotal) + (parseFloat($("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Cont" + j + "']").val())))

        }
        //debugger;
        $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_txtQuantity" + "']").val(CNTotal);
    }


    function CalculateNumber(elem) {
        //debugger;
        var Id = elem.id;
        var val;
        if (elem.value == "") {
            val = 0;
        }
        else {
            val = elem.value;
        }
        var StrId = Id.substr(67);
        var str = StrId.split("_");
        //var strCn = str[1].substr(2);
        var Count = $("#<%=hdnCNCount.ClientID %>", "#main_content").val();
        var countNo = parseInt(Count) + 1;

        var txtQuantity = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_hypqty" + "']");
        var No = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Number" + "']").val()
        if (No == "") {
            No = 0;
        }
        var Fw = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_txtFW" + "']").val();

        var TotalNo = 0;
        var FinalNo = 0;
        var CNFirst;
        var Total = 0;
        //debugger; 
        var CNTotal = 0;
        var Quantity = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_txtQuantity" + "']").val();
        //debugger; 
        for (var i = 1; i < countNo; i++) {

            var cp = $("#ctl00_cph_main_content_ucFabricAccessoriesFormNew_grdAccessories input[id*='ct" + str[0] + "_CP" + i + "']").val()
            if (cp == "") {
                cp = 0;
            }
            CNFirst = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_hdyECN" + i + "']").val()
            //debugger;
            Total = parseFloat(CNFirst) * parseFloat(No) * (1 + (parseFloat($("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_FlatW" + i + "']").val()) / 100) + (parseFloat(cp) / 100))
            var FinalTotal = Total;
            //debugger;

            parseFloat($("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Cont" + i + "']").val(FinalTotal));

            CNTotal = (parseFloat(CNTotal) + (parseFloat($("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_Cont" + i + "']").val())))

        }
        var totalqty = $("#<%= grdAccessories.ClientID %> input[id*='ct" + str[0] + "_txtQuantity" + "']");
        totalqty.val(parseFloat(CNTotal))
    }


    function isSpecialKey(evt) {
        //debugger;
        var k = (evt.which) ? evt.which : event.keyCode
        return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57))
        //        if ((charCode >= 65 && charCode <= 91) || (charCode >= 97 && charCode <= 123) || (charCode >= 48 || charCode <= 57))
        //            return true;

        //        return false;
    }

    $(window).load(function () {
        // debugger;
        var urls = window.location.href;
        var manipath = urls.split('&')[1];
        if (manipath === 'Print=Yes') {
            $('input[type="text"]').attr("disabled", true);
            $('input[type="file"]').attr("disabled", true);
            $('input[type="checkbox"]').attr("disabled", true);
        }
    });


</script>
<style type="text/css">
    :disabled
   {
       background:#fff !important;
   }
    table
    {
        border-color: #999 !important;
    }
    .fafn2 th
    {
        background-image: url(../../images/accTot_bg.jpg);
        background-repeat: repeat-x;
        height: 46px;
        color: #ffffff;
        text-align: center;
        font-size: 14px;
        font-weight: normal;
    }
    .fafn2 td
    {
        height: 40px;
        color: #0000ff;
        text-align: center;
        font-size: 18px;
        height: 46px;
        width: 5.5%;
    }
    .divwid
    {
        color: black;
        font-size: 12px;
        text-align: left;
        padding-left: 2px;
    }
    .fafn_footer
    {
        background:#39589c !IMPORTANT;
        
        height: 46px;
        width: 258px;
        color: #ffffff !important;
        text-align: center;
        font-size: 14px !imporant;
    }
    .fafn_footer td
    {
        background-image: url(../../images/accTot_bg.jpg);
        background-repeat: repeat-x;
        height: 46px;
        width: 258px;
        color: #ffffff !important;
        text-align: center;
        font-size: 14px !imporant;
    }
    .paddingzero
    {
        padding: 0px;
    }
    .accorforwidflo2
    {
        background:#3a5795;
        color:#fff;
        height:35px;
    }
    .accorforwidflo3
    {
        text-align:center;
           padding-top: 0px !important;
    }
    .accorforform_heading
    {
        background:#39589c;
        width:100% !important;
        padding:10px;
        height:10px !important;
        font-weight:bold;
        vertical-align:middle;
        text-transform:uppercase;
    }
    .item_list TD input[type="text"], .item_list TD select {
    border: 0px solid #bdb5b5 !important;
    color: Gray;
    font-size: 10px;
    width: 98%;
    height: 15px !important;
    
}
 .item_list td.accorforstyle14 input[type="text"] {
    border: 0px !important;
}
input[type="file"] 
{
    width: 66px !important;;
    height: 15px;
    font-size: 10px;
    padding: 0
    }
.minWidth
   {
       min-width:250px !important;
       max-width:250px;
       }
   

</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<body>
    <div id="outer" style="width: 100%; overflow-x: hidden;">
        <asp:Panel runat="server" ID="pnlForm">
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
            <div class="accorforbody accorforwidflo">
                <div class="accorforwidflo">
                    <div class="accorforwidflo2">
                        <div class="accorforstyle1 accorforwidflo3" runat="server" id="trprint11">
                            Accessories Order Form
                            <asp:HiddenField ID="hdnTotalCount" runat="server" Value="0" />
                        </div>
                        <div class="accorforwidflo4" style="float: right;">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left" class="accorforstyle2" style="padding: 0px 5px; font-size: 15px"
                                                                height="20px">
                                                                Bulk In House Target
                                                            </td>
                                                            <td align="right" class="accorforstyle2 accorforwidflo18" style="background: #fff;
                                                                color: #000; font-size: 15px">
                                                                <asp:Label ID="lblBulkEta" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="left" class="accorforstyle3" style="padding: 5px;" height="20px">
                                                                (Department B.I.H Target)
                                                            </td>
                                                            <td align="right" class="accorforstyle3 accorforwidflo18" style="background:#fff;">
                                                                (20 Mar 13 (Wed))
                                                            </td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 35px">
                                                        <tr>
                                                            <td class="accorforstyle2" style="padding: 0xp 5px; font-size: 15px">
                                                                Bulk Approval Target
                                                            </td>
                                                            <td class="accorforstyle2" style="padding: 0px 5px; background: #fff; color: #000;
                                                                text-align: right; font-size: 15px">
                                                                <asp:Label ID="lblAccessoryBulkETA" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="accorforwidflo5" style="width: 99.3% !important; padding: 3.5px;">
                        <div class="accorforwidflo6" style="height: 450px;">
                            <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid #999;">
                                <tr>
                                    <td valign="top" class="accorforwidflo7">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" height="40px" valign="top" class="accorforstyle4" style="padding-top: 25px;">
                                                    Basic Info
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="50px" valign="top" class="accorforstyle4" style="padding-top: 15px;
                                                    border-top: 1px solid #ffffff;">
                                                    Style Info
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="25%" style="border-right: 1px solid #999;" class="accorforstyle4" align="center">
                                        fabric
                                    </td>
                                    <td valign="top" rowspan="2">
                                        <%--<div style="overflow-y: scroll; height:400px;">
                        <asp:Repeater ID="rptFabricOrderSize" runat="server" OnItemDataBound="rptFabricOrderSizeItemDataBound">
                                                        <HeaderTemplate>
                                                         
                                                            <table width="100%" class="accorforaccessories_table" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td rowspan="2" align="center" class="accorforfabric_heading2" style="width: 10%; font-size:12px;"><br /><br /><br />
                                                                        Size
                                                                    </td>
                                                                    <td colspan="4" align="center" class="accorforfabric_heading2 accorforstyle4" valign="middle" style="width:70%; height:50px;">
                                                                       Contract Wise Qty
                                                                    </td>
                                                                    <td rowspan="2" align="center" class="accorforfabric_heading2 " valign="middle" style="width: 10%; font-size:12px;"><br /><br /><br />
                                                                        Tot Qty
                                                                    </td>
                                                                  
                                                                </tr>
                                                                <tr>
                                                                    <td class="internalTable" colspan="4">
                                                                        <asp:Repeater ID="rptFabricOrderDetail" runat="server">
                                                                            <HeaderTemplate>
                                                                                <table width="100%" class="accorforaccessories_table" cellpadding="0" cellspacing="0" border="0" style="line-height: 25px;">
                                                                                    <tr>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>

                                                                                <td class="accorforfabric_heading2  order-contract" width='<%= CellWidth %>'
                                                                                    align="center" valign="top" style="height:50px; font-size:11px;">
                                                                                    (<%# "CN" + (Container.ItemIndex  + 1).ToString() %>)<label id="lblDetails" style="font-size:smaller; font:6px;" class="fabric1-details">(<%# Eval("Fabric1Details")%>)</label><br />
                                                                                    <%# Eval("ContractNumber")%><br />
                                                                                    <div>
                                                                                        <%# (!string.IsNullOrEmpty(Eval("LineItemNumber") as String ))? "/ "+Eval("LineItemNumber").ToString() : string.Empty %></div>
                                                                                    <asp:Label ID="lblQuantity" runat="server" CssClass="hide_me"   Text='<%# "("+ Eval("Fabric1Details").ToString()+")"%>'></asp:Label>
                                                                                </td>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                </tr> </table>
                                                                            </FooterTemplate>
                                                                        </asp:Repeater>
                                                                    </td>
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                       
                                                            <tr>
                                                            
                                                                <td class="accorforfabric_heading1" valign="top" style="font-size:12px; border:1px solid #e6e6e6; color:#000000; height:25px;">
                                                                    <asp:Label  ID="lblSize" runat="server" Text='<%# Eval("Size") %>'></asp:Label>
                                                                </td>
                                                                <td colspan="4" class="internalTable accorforstyle9" style="border:1px solid #e6e6e6;">
                                                               
                                                                    <asp:Repeater ID="rptFabricOrderDetail" runat="server" OnItemDataBound="rptFabricOrderDetailItemDataBound">
                                                                        <HeaderTemplate>
                                                                            <table width="100%" class="accorforaccessories_table accorforstyle9" cellpadding="0" cellspacing="0" style="color:#000000 !important; height:20px;"">
                                                                                <tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <td width='<%= CellWidth %>' align="center" class="accorforfabric_heading3" style="width:25%;">
                                                                                <asp:Label  ID="lblQuantity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            </tr> </table>
                                                                        </FooterTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                                <td class="accorforfabric_heading3" style="font-size:small; border:1px solid #e6e6e6; border-right:none;">
                                                                    <asp:Label  ID="lblTotalQuantity" runat="server"></asp:Label>
                                                                </td>
                                                              
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <tr id="Tr1" runat="server" visible="true">
                                                                <td style="font-size:small;">
                                                                    Total QTY
                                                                </td>
                                                                <td colspan="4" class="internalTable" style="font-size:smaller;">
                                                             
                                                                    <asp:Repeater ID="rptFabricOrderDetail" runat="server" OnItemDataBound="rptFabricOrderDetailItemDataBoundFooter">
                                                                        <HeaderTemplate>
                                                                       
                                                                            <table width="100%" class="accorforaccessories_table" cellpadding="0" cellspacing="0" border="0"
                                                                                style="height: 42px;">
                                                                                <tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <td width='<%= CellWidth %>' class="accorforfabric_heading1 order-total-qty">
                                                                                <asp:Label CssClass="font_color_blue" ID="lblQuantity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            </tr> </table>
                                                                        </FooterTemplate>
                                                                    </asp:Repeater>
                                                                
                                                                </td>
                                                                <td class="accorforfabric_heading1" style="font-size:small;">
                                                                    <asp:Label ID="lblTotalQuantity" CssClass="font_color_blue" runat="server"></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            <tr style="visibility:hidden;">
                                                                
                                                             
                                                                <td colspan="4" class="internalTable">
                                                                    <asp:Repeater ID="rptFabricOrderDetailExtra" runat="server" OnItemDataBound="rptFabricOrderDetailItemDataBoundFooterExtra" Visible="false">
                                                                        <HeaderTemplate>
                                                                            <table width="100%" style="height: 90px;" class="accorforaccessories_table" cellpadding="0"
                                                                                cellspacing="0" border="1">
                                                                                <tr style="line-height: 30px;">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <td width='<%= CellWidth %>' class="order-total-qty" style="font-size:small; width:25%;">
                                                                                <asp:Label CssClass="font_color_blue" ID="lblQuantity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>

                                                                            </tr> </table>
                                                                        </FooterTemplate>
                                                                  </asp:Repeater>
                                                                </td>
                                                                <td style="padding-top: 12px;" class="accorforfabric_heading1">
                                                                    <asp:Label CssClass="font_color_blue" ID="lblTotalQuantityExtra1" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-top: 12px;" class="accorforfabric_heading1">
                                                                    <asp:Label CssClass="font_color_blue" ID="lblTotalQuantityExtra2" Font-Bold="true" 
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                           
                                                            </table>
                                                           
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                   </div>--%>
                                        <div style="overflow-y: auto; max-height: 400px;">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption1" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption1_RowDataBound" CssClass="item_list">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract number" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-Width="28.5%">
                                                                    <ItemTemplate>
                                                                        <div class="divwid">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)
                                                                            <asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnOdId1" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal1" runat="server" Style="font-size: 14px;" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize1" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblMaxSize1" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize2" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize2" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblMaxSize2" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize3" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize3" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize3" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize4" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize4" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize4" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize5" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize5" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize5" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize6" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize6" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize6" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize7" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize7" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize7" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize8" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize8" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize8" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize9" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize9" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize9" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize10" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize10" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize10" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize11" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize11" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize11" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize12" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndSize12" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxSize12" runat="server" ></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMinsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="paddingzero">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 10PX 0PX !important; background: #39589c; color: #ffffff;">
                                                                            <asp:Label ID="lblMinTotal1" Style="color: #ffffff;" runat="server"></asp:Label>
                                                                            <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblMaxTotal1" runat="server"></asp:Label></td>
</tr>--%>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:GridView ID="grdCuttinOption2" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttinOption2_RowDataBound" CssClass="item_list1">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="28.5%">
                                                                    <ItemTemplate>
                                                                        (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                        <asp:HiddenField ID="hdnOdId2" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal2" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize1" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize1" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize2" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size2" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize2" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize3" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size3" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize3" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize4" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size4" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize4" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize5" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size5" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize5" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize6" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size6" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize6" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize7" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size7" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize7" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize8" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size8" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize8" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize9" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size9" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize9" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize10" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size10" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize10" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize11" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size11" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize11" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize12" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP2Size12" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP2MaxSize12" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="paddingzero">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP2MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblOP2MaxTotal1" runat="server"></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:GridView ID="grdCuttingOption3" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            CssClass="fafn2" Width="100%" OnRowDataBound="grdCuttingOption3_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="28.5%">
                                                                    <ItemTemplate>
                                                                        <div class="divwid">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId3" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal3" runat="server" Style="font-size: 14px;" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize1" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize1" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize2" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size2" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize2" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize3" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size3" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize3" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize4" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size4" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize4" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize5" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size5" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize5" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize6" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size6" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize6" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize7" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size7" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize7" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize8" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size8" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize8" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize9" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size9" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize9" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize10" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size10" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize10" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize11" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size11" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize11" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize12" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP3Size12" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP3MaxSize12" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="paddingzero">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important; background-image: url(../../images/accTot_bg.jpg);
                                                                            background-repeat: repeat-x; height: 49px; color: #ffffff;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP3MinTotal1" Style="color: #ffffff;" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:GridView ID="grdCuttingOption4" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            class="fafn2" Width="100%" OnRowDataBound="grdCuttingOption4_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="28.5%">
                                                                    <ItemTemplate>
                                                                        <div class="divwid">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId4" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal4" runat="server" Style="font-size: 14px;" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize1" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize1" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize2" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size2" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize2" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize3" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size3" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize3" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize4" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size4" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize4" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize5" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size5" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize5" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize6" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size6" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize6" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize7" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size7" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize7" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize8" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size8" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize8" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize9" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size9" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize9" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize10" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size10" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize10" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize11" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size11" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize11" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize12" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hndOP4Size12" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;">
<asp:Label ID="lblOP4MaxSize12" runat="server" ></asp:Label>
</td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-CssClass="paddingzero">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important; background-image: url(../../images/accTot_bg.jpg);
                                                                            background-repeat: repeat-x; height: 49px; color: #ffffff;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP4MinTotal1" Style="color: #ffffff;" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
<td style="border-top:1px solid #000000;"><asp:Label ID="lblOP4MaxTotal1" runat="server"></asp:Label></td>
</tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption5" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption5_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId5" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal5" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP5MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption6" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption6_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId6" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal6" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP6MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption7" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption7_RowDataBound" CssClass="item_list">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                        <asp:HiddenField ID="hdnOdId7" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="190px" />
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal7" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP7Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="paddingzero">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 10PX 0PX !important; background: #39589c; color: #ffffff;">
                                                                            <asp:Label ID="lblOP7MinTotal1" runat="server"></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption8" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption8_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId8" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal8" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP8MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption9" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                            Width="100%" OnRowDataBound="grdCuttingOption9_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId9" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal9" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP9MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption10" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption10_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId10" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal10" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP10MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption11" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption11_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId11" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal11" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP11MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption12" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption12_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId12" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal12" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP12MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption13" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption13_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId13" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal13" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP13MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption14" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption14_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId14" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal14" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP14MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption15" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption15_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId15" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal15" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP15MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption16" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption16_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId16" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal16" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP16MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity16" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption17" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption17_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId17" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal17" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP17MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity17" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption18" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption18_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contract Number">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId18" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal18" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="1">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP18MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity18" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCuttingOption19" runat="server" AutoGenerateColumns="false"
                                                            ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption19_RowDataBound"
                                                            CssClass="item_list">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="width: 150px;">
                                                                            (<asp:Label ID="lblCTRCT" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            (<asp:Label ID="lblPrint" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                                                                            <asp:HiddenField ID="hdnOdId19" runat="server" Value='<%#Eval("OrderDetailId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblContractSizeTotal19" runat="server" Text="Total"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="2">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize2" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize2" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="3">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize3" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize3" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="4">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize4" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize4" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="5">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize5" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize5" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="6">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize6" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize6" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="7">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize7" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize7" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="8">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize8" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize8" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <FooterStyle CssClass="fafn_footer" />
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="9">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize9" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize9" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="10">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize10" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize10" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="11">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize11" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize11" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="12">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize12" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize12" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="13">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize13" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize13" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="14">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize14" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize14" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="15">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19Minsize15" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSize15" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <div style="padding: 0 !important;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblOP19MinTotal1" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalQuantity19" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="20%" class="accorforwidflo18">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" class="accorforstyle3" height="20px">
                                                    <asp:Label ID="lblCreationDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="accorforstyle7" height="20px">
                                                    <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="accorforstyle7" height="20px">
                                                    <asp:Label ID="lblStyleNumber" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="accorforstyle8" height="20px" style="border-bottom: 1px solid #e6e6e6;">
                                                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="imgRow">
                                                <td align="center" class="accorforstyle3" style="padding-top: 10px; padding-bottom: 10px;">
                                                    <asp:Image runat="server" ID="imgStyle" Style="height: 100px; cursor: hand" />
                                                    <asp:Image runat="server" ID="imgPrint" Visible="false" Style="max-width: 135px;
                                                        max-height: 100px;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="accorforstyle8" height="20px">
                                                    <asp:Label ID="lblDesc" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="accorforstyle3" height="20px">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left" width="95%" class="accorforstyle12" style="padding-top: 20px;">
                                                                <asp:Label ID="lblMName" runat="server">
                                                                </asp:Label>
                                                                &nbsp;
                                                                <asp:Label ID="lblmerchantNotes" CssClass="accorforstyle8" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="right" style="padding-left: 5px; padding-top: 20px;">
                                                                <img alt="Shipping Remarks" title="CLICK TO SEE REMARKS POPUP" src="../../Images/magnify.png"
                                                                    border="0" onclick="javascript:return shMerchantRemark();" />
                                                                <input type="hidden" id="hiddenMerchant" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" width="25%" class="accorforwidflo18" runat="server" id="trprint12">
                                        <div align="right">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="accorforstyle3" width="63%" height="30px" align="left">
                                                        <asp:Label ID="lblFabric1" runat="server" Font-Size="Smaller" Width="108%"></asp:Label>
                                                    </td>
                                                    <td class="accorforstyle3" align="left">
                                                        <asp:Label ID="lblFab1Date" runat="server"></asp:Label><asp:Label ID="lblFab1Prcent"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="accorforstyle3" height="30px" align="left">
                                                        <asp:Label ID="lblFabric2" runat="server" Width="100%"></asp:Label>
                                                    </td>
                                                    <td class="accorforstyle3" align="left">
                                                        <asp:Label ID="lblFab2Date" runat="server"></asp:Label><asp:Label ID="lblFab2Prcent"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="accorforstyle3" height="30px" align="left">
                                                        <asp:Label ID="lblFabric3" runat="server" Width="100%"></asp:Label>
                                                    </td>
                                                    <td class="accorforstyle3" align="left">
                                                        <asp:Label ID="lblFab3Date" runat="server"></asp:Label><asp:Label ID="lblFab3Prcent"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="accorforstyle3" height="30px" align="left">
                                                        <asp:Label ID="lblFabric4" runat="server" Width="100%"></asp:Label>
                                                    </td>
                                                    <td class="accorforstyle3" align="left">
                                                        <asp:Label ID="lblFab4Date" runat="server"></asp:Label><asp:Label ID="lblFab4Prcent"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="padding-top: 70px;">
                                            <table width="100%" cellpadding="0" cellspacing="0" style="vertical-align: bottom;">
                                                <tr>
                                                    <td align="left" width="90%" class="accorforstyle12" style="padding-left: 5px; padding-top: 50px;">
                                                        <asp:Label ID="lblRName" runat="server">
                                                        </asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="lblFabricBulkRemark" CssClass="accorforstyle8" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-left: 5px; padding-top: 50px;">
                                                        <img alt="Shipping Remarks" title="CLICK TO SEE REMARKS POPUP" src="../../Images/magnify.png"
                                                            border="0" onclick="javascript:return shRemark();" />
                                                        <input type="hidden" id="hdnRemarks" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 100%;">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" style="width: 100%;" class="internalTable">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr style="display: none;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trprint21" runat="server" class="">
                                                <td class="internalTable1">
                                                    <div style="height: auto; max-width: 1100px; overflow-x: auto;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <asp:GridView ID="grdAccessories" runat="server" BorderColor="Black" CssClass=" item_list"
                                                                AutoGenerateColumns="false" Width="100%" OnRowDataBound="grdAccessories_RowDataBound"
                                                                OnRowCommand="grdAccessories_RowCommand" ShowFooter="True">
                                                            </asp:GridView>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px; width: 100%;" align="right">
                                                    <%--<asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="../../Images/add.png" OnClick="imgBtnAdd_Click" />--%>
                                                    <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="../../Images/add.png" OnClick="imgBtnAdd_Click" />
                                                    <asp:HiddenField ID="hdnCNCount" runat="server" />
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trprint3" class="">
                                                <td>
                                                    <br />
                                                    <table width="100%" class="accorforaccessories_table item_list1" cellpadding="0"
                                                        cellspacing="0">
                                                        <tr>
                                                            <th class="accorforwidflo11 accorforstyle6" align="center" style="width: 20% !important;
                                                                height: 49px; border-right: none !important;">
                                                                Contract Number
                                                            </th>
                                                            <th class="accorforwidflo11 remarks_text remarks_text2 accorforstyle6" style="width: 70% !important;
                                                                font-size: 12px !important; padding-left: 15px; height: 49px; border-right: 1px solid #999999;
                                                                text-transform: capitalize !important;">
                                                                &nbsp;&nbsp;&nbsp; Remarks
                                                            </th>
                                                        </tr>
                                                        <asp:Repeater ID="repeaterOrderBreakdown" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="accorforstyle3" style="border: 1px solid #999999; text-align: center;
                                                                        border-right: none !important;">
                                                                        (<%# "CN" + (Container.ItemIndex  + 1).ToString() %>)
                                                                        <%# Eval("ContractNumber")%>
                                                                    </td>
                                                                    <%--abhishek 6/8/2015--%>
                                                                    <td height="40" class="remarks_text remarks_text2 accorforstyle10" style="border: 1px solid #999999;
                                                                        font-size: 12px !important; text-transform: capitalize;">
                                                                        <br />
                                                                        <%--<%#(Eval("AccessoriesRemarks").ToString().IndexOf("$$") > -1) ? (Eval("AccessoriesRemarks").ToString().IndexOf("$$") > -1) ? Eval("AccessoriesRemarks").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("AccessoriesRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("AccessoriesRemarks").ToString()%>--%>
                                                                        <%#(Eval("AccessoriesRemarks").ToString().IndexOf("$$") > -1) ? (Eval("AccessoriesRemarks").ToString().IndexOf("$$") > -1) ? Eval("AccessoriesRemarks").ToString().Replace("$$", ",") : Eval("AccessoriesRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("AccessoriesRemarks").ToString()%>
                                                                        <br />
                                                                        <br />
                                                                        &nbsp;&nbsp;
                                                                        <img alt="Remarks" title="CLICK TO SEE REMARKS HISTORY" src="/App_Themes/ikandi/images/remark.gif"
                                                                            border="0" onclick="showRemarksFabricWorking('<%# Eval("OrderDetailID") %>',<%# Eval("OrderDetailID") %>,'<%# (Eval("AccessoriesRemarks").ToString().IndexOf("$$") > -1) ? Eval("AccessoriesRemarks").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  : Eval("AccessoriesRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS','MANAGE_ORDER_FILE','<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS)? 1 : 0 %>')" />
                                                                    </td>
                                                                    <%--end--%>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <div style="width: 100%;">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 100%;" valign="middle">
                                            <div style="width: 100%; float: left; padding-bottom: 15px;">
                                                <div style="width: 48.5%; float: left; border: 1px solid #999999; height: 25px; color: #000000 !important;
                                                    padding: 5px; padding-top: 15px; text-transform: capitalize !important;">
                                                    <asp:CheckBox ID="chkBoxAccountManager" runat="server" Text="Account Manager" TextAlign="Left"
                                                        CssClass="checkbox style9" />
                                                </div>
                                                <div style="width: 48.5%; float: left; border: 1px solid #999999; border-left: none;
                                                    color: #000000 !important; height: 30px; padding-left: 10px; padding-top: 15px;">
                                                    <asp:CheckBox ID="chkBoxAccessoryManager" Text="Accessory Manager" TextAlign="Left"
                                                        CssClass="checkbox style9" runat="server" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 100%;">
                                <a href="javascript:void(0)" style="font-size: 12px; color: #0088cc; text-decoration: underline;"
                                    onclick="showHide( this)">View History</a>
                            </div>
                            <div style="width: 100%; float: left; margin-top: 15px;">
                                <div class="form_buttom">
                                    <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
                                        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
                                        runat="server" />
                                    <asp:Button runat="server" ID="btnSubmit" Visible="false" Text="Submit" CssClass="submit"
                                        OnClick="btnSubmit_Click" />
                                    <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_click" CssClass="go hide_me" />
                                    <asp:HiddenField runat="server" ID="hdnPath" Value="" />
                                    <asp:HiddenField runat="server" ID="hRemarksMerchant" Value="" />
                                    <asp:Button runat="server" ID="btnPrint" Visible="false" Text="Print" CssClass="submit"
                                        OnClientClick="javascript:fncPrint();" />
                                    &nbsp;&nbsp;&nbsp;
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div id="divHistory" style="height: 300px ! important; overflow: auto;" class="hide_me">
                            <div style="border: 1px solid #999999;">
                                <div class="accorforform_heading">
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
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            .
        </asp:Panel>
        <asp:HiddenField ID="hdnAccesoriedID" runat="server" />
        <asp:Panel runat="server" ID="pnlMessage" Visible="false">
            <div class="form_box">
                <div class="accorforform_heading">
                    Confirmation
                </div>
                <div class="text-content">
                    Fabric Accessories details have been saved into the system successfully!
                    <br />
                    <a id="A1" runat="server">Print here</a></div>
            </div>
        </asp:Panel>
    </div>
</body>
