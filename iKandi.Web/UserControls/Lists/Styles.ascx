<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Styles.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.Styles" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<style>
    body
    {
        font-size: 11px;
        font-family: Arial !important;
    }
    .Black
    {
        color: Black;
    }
    .Blue
    {
        color: Blue;
    }
    .style-fabric1
    {
        width: 800px;
    }
    .style3
    {
        background: url('../../App_Themes/ikandi/images1/order_form_top.gif') repeat-x;
        height: 31px;
        width: 1406px;
    }
    .paging td
    {
        text-transform: capitalize;
        border: 0px solid #dedede;
        padding: 3px !important;
        font: bold 12px/14px Helvetica,Arial,Verdana,sans-serif;
        color: #3c3c3c;
        text-align: center;
    }
    .paging
    {
        text-transform: capitalize;
        border: 0px solid #dedede;
        padding: 3px;
        font: bold 12px/14px Helvetica,Arial,Verdana,sans-serif;
        color: #3c3c3c;
        text-align: center;
    }
    .grid_width
    {
        width: 1468px;
    }
    .hide-me
    {
        display: none;
    }
    .da_header_heading TH
    {
        padding: 8px 2px !important;
    }
    .font-10
    {
        font-size: 9px;
    }
    td
    {
        color: Gray;
        padding: 0px 0px !important;
    }
    table
    {
        font-family: verdana;
        border-color: gray;
        border-collapse: collapse;
    }
    th
    {
        background: #dddfe4;
        border: 1px solid #b7b4b4;
        font-weight: normal;
        color: #575759;
        font-family: arial,halvetica;
        font-size: 10px;
        padding: 5px 0px;
        text-transform: capitalize;
        text-align: center;
    }
    table td
    {
        text-align: center;
        border-color: #aaa;
        color: #3c3c3c;
        text-transform: capitalize;
    }
    a
    {
        text-decoration: none;
    }
    select
    {
        text-transform: capitalize;
    }
    .remarks_text
    {
        vertical-align: top;
        text-transform: capitalize;
    }
    #spinnL
    {
        position: fixed;
        left: 0px;
        top: 0px;
        width: 100%;
        height: 100%;
        z-index: 9999;
        background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        display: none;
    }
    .form_box .item_list th
    {
        background: #dddfe4 !important;
    }
    .form_box .item_list td
    {
        padding: 5px !important;
    }
    .repeater-table td
    {
        width: 75px;
        border: 0px;
        line-height: 18px;
    }
    .repeater-table td input
    {
        width: 90%;
    }
    .clearBoth
    {
        clear: both;
    }
    /*updated css by7 bharat 14-jan-19*/
    table td input[type="radio"]
    {
        position: relative;
        top: 3px !important;
    }
    /*modal popup css*/
    #ctl01_pnlRemarks
    {
        max-height: 200px !important;
        min-height: 100px !important;
        overflow-y: auto !important;
        padding: 5px;
    }
    .show_div_Remrks
    {
        padding: 5px;
    }
    #ctl01_btnSaveComment
    {
        margin-top: 5px !important;
    }
    .popup .content
    {
        overflow: auto !important;
    }
    #facebox img
    {
        margin-right: 5px;
    }
    .show_div_Remrks table u
    {
        text-decoration: none;
    }
    .show_div_Remrks table h3 u span
    {
        color: #f3ebeb;
    }
    #secure_banner_cor
    {
        padding-left:0!important;
        }
</style>
<script type="text/javascript">

    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
        $(".th").datepicker({ dateFormat: 'dd M yy' });
        $(".paging a").click(function () {

            //$("#spinnL").css("display", "block");
            // $("#spinnL").css("display", "block"); $("#spinnL")
        });
        //        $(".go,.paging a").click(function () {

        //            $("#spinnL").css("display", "block");
        //            // $("#spinnL").css("display", "block"); $("#spinnL")
        //        });

    });
   
</script>
<script type="text/javascript">
    //debugger;
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
        $("span.courier-received", "#main_content").click(function () {


            var objRow = $(this).parents("tr");
            var chkbox = $(this).find("input");

            if (chkbox.is(':checked')) {
                var styleID = objRow.find(".hidden-styleId").val();
                var currentDate = new Date();

                //Get the Style details from database
                proxy.invoke("UpdateStylesCourierReceivedOnById", { StyleID: styleID },
                function () {
                    objRow.find(".courier-received-on").text(ParseDateToDateWithDay(currentDate));

                },
          onPageError, false, false);
            }
        });

        $("#refresh", "#main_content").click(function () {

        });

        // Apply links
        $("td.style-fabric", "#main_content").each(function () {

            var data = $(this).html();

            if (data == null || data == '') {
                return;
            }
            else { 
                var dataArr = data.split(",");
                var html = '';
                for (i = 0; i < dataArr.length; i++) {
                    var fabriArr = dataArr[i].split(":");

                    if (fabriArr.length > 1 && fabriArr[1].indexOf("PRD") > -1)
                        html += "<div>" + fabriArr[0] + ": " + "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "')\" >" + fabriArr[1] + "</a></div>";
                    else
                        html += dataArr[i];
                }

                $(this).html(html);
            }

        });
        $("td.style-fabric3", "#main_content").each(function () {
            debugger;
            var temp = $(this).html();
            var datatmp = temp.split("****");
            var StyleId = datatmp[0];

            if (datatmp[1] == undefined)
                return;

            var data = datatmp[1];
            var fabriArr1;
            var dataArr = data.split(",");
            var html = '';
            for (i = 0; i < dataArr.length; i++) {
                var SplitWith = dataArr[i].split("!!!!");
                dataArr[i] = SplitWith[1];
                var fabriArr = dataArr[i].split("##");
                if (fabriArr.length > 1 && fabriArr[1].indexOf("PRD") > -1) {
                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        if (fabriArr[1].indexOf("CC") > -1 || fabriArr[1].indexOf("GSM") > -1) {
                            fabriArr1[1] = "<span class='Black'>" + fabriArr1[1] + "</span>";
                        }
                        if (SplitWith[0] == 'Y') {
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >Multiple</a>" + fabriArr1[1] + "</div>";
                        }
                        else {
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a>" + fabriArr1[1] + "</div>";
                        }
                    }
                    else {
                        if (SplitWith[0] == 'Y')
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >Multiple</a></div>";
                        else
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr[1] + "</a></div>";
                    }
                }
                else if (fabriArr.length > 1) {

                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        if (SplitWith[0] == 'Y') {
                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >: Multiple</a><span class='Black'>" + fabriArr1[1] + "</span>";
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + fabriArr1[0] + "</span></div>";
                        }
                        else {
                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a><span class='Black'>" + fabriArr1[1] + "</span>";
                            html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + fabriArr1[0] + "</span></div>";
                        }
                    }
                    else {
                        html += "<div style='border-bottom: 1px solid black;'><span class='Blue'>" + fabriArr[0] + "</span></div>";
                    }
                }
                else
                    html += dataArr[i];
            }
            $(this).html(html);
        });

        //create by surendra on 15-03-2018 for fabric.
        $("td.style-hypFabric", "#main_content").each(function () {
            // debugger;
            var temp = $(this).html();
            temp = $.trim(temp);
            var datatmp = temp.split("****");
            var StyleId = datatmp[0];

            if (datatmp[1] == undefined)
                return;

            var data = datatmp[1];
            var fabriArr1;
            var dataArr = data.split(",");
            var html = '';
            for (i = 0; i < dataArr.length; i++) {
                var SplitWith = dataArr[i].split("!!!!");
                dataArr[i] = SplitWith[1];
                var fabriArr = dataArr[i].split("##");
                if (fabriArr.length > 1 && fabriArr[1].indexOf("PRD") > -1) {
                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        if (fabriArr[1].indexOf("CC") > -1 || fabriArr[1].indexOf("GSM") > -1) {
                            fabriArr1[1] = "<span class='Black'>" + fabriArr1[1] + "</span>";
                        }
                        if (SplitWith[0] == 'Y') {
                            //                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >Multiple</a>" + fabriArr1[1] + "</div>";
                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >Multiple</a></div>";
                        }
                        else {
                            //                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a>" + fabriArr1[1] + "</div>";
                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a></div>";
                        }
                    }
                    else {
                        if (SplitWith[0] == 'Y')
                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >Multiple</a></div>";
                        else
                            html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr[1] + "</a></div>";

                    }
                }
                else if (fabriArr.length > 1) {

                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        if (SplitWith[0] == 'Y') {
                            //                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >: Multiple</a><span class='Black'>" + fabriArr1[1] + "</span>";
                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >: Multiple</a>";
                            html += "<div><span class='Blue'>" + fabriArr[0] + fabriArr1[0] + "</span></div>";
                        }
                        else {
                            //                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a><span class='Black'>" + fabriArr1[1] + "</span>";
                            fabriArr1[0] = "<a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('0','" + StyleId + '##' + fabriArr[0] + "')\" >" + fabriArr1[0] + "</a>";
                            html += "<div><span class='Blue'>" + fabriArr[0] + fabriArr1[0] + "</span></div>";
                        }
                    }
                    else {
                        html += "<div><span class='Blue'>" + fabriArr[0] + "</span></div>";
                    }
                }
                else
                    html += dataArr[i];
            }
            $(this).html(html);
        });
        $("td.style-fabric1", "#main_content").each(function () {
            var data = $(this).html();
            if (data == null || data == '')
                return;
            var fabriArr1;



            var dataArr = data.split(",");
            var html = '';
            for (i = 0; i < dataArr.length; i++) {
                var fabriArr = dataArr[i].split("##");

                if (fabriArr.length > 1 && fabriArr[1].indexOf("PRD") > -1) {
                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        //                        if (fabriArr[1].indexOf("CC") > -1 || fabriArr[1].indexOf("GSM") > -1) {
                        //                            fabriArr1[1] = "<span class='Black'>" + fabriArr1[1] + "</span>";
                        //                        }
                        //                        html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "')\" >" + fabriArr1[0] + "</a>" + fabriArr1[1] + "</div>";
                        html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr1[0].replace("PRD", "")) + "')\" >" + fabriArr1[0] + "</a></div>";
                    }
                    else {
                        html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><a  href='javascript:void(0)'  onclick=\"showFabricHistoryByPrintNumber('" + $.trim(fabriArr[1].replace("PRD", "")) + "')\" >" + fabriArr[1] + "</a></div>";
                    }
                }
                else if (fabriArr.length > 1) {
                    if (fabriArr[1].indexOf("@#") > -1) {
                        fabriArr1 = fabriArr[1].split('@#');
                        //                        if (fabriArr[1].indexOf("CC") > -1 || fabriArr[1].indexOf("GSM") > -1) {
                        //                            fabriArr1[0] = fabriArr1[0] + "<br/><span class='Black'>" + fabriArr1[1] + "</span>";
                        //                        }
                        html += "<div><span class='Blue'>" + fabriArr[0] + fabriArr1[0] + "</span></div>";
                    }
                    else {
                        html += "<div><span class='Blue'>" + fabriArr[0] + "</span></div>";
                    }
                }
                else
                    html += dataArr[i];
            }

            $(this).html(html);

        });
        //debugger;
        $("#spinnL").fadeOut("slow");
    });


    function removetext(obj) {
        var CID = obj;
        if (CID == 'txtfrom') {
            $('#<%= txtFRqd.ClientID %>').val('');
        }
        if (CID == 'txtTo') {
            $('#<%= txtTRqd.ClientID %>').val('');
        }

    }

    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }
    function UpdateFabricDetails(elem, selectedval) {
        var ctId = elem.id.split('_')[8].substr(2);
        var rptid = elem.id.split('_')[6].substr(2);
        var id = $("#ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_hdnid").val();
        proxy.invoke("UpdateStylesFabricDetails", { ID: id, dates: $(elem).val(), status: 0, flag: selectedval },
                        function (result) {
                            alert('Data saved sucessfully.');
                        });
    }
    function UpdateBuyerStyleNumber(elem) {
        var cValue = elem.value;
        var Ids = elem.id;
        var StyleId = $("#" + Ids).closest("tr").find(".hidden-styleId").val();
        proxy.invoke("UpdateBuyerStyleNumber", { cValue: cValue, StyleId: StyleId },
                    function (result) {
                        alert('Data saved sucessfully.');
                    });
    }
    function UpdateSelectExport(elem) {
        debugger;
        //                    var isYes = confirm("Do you want to Select all check box");
        var Ids = elem.id;
        var StyleId = $("#" + Ids).closest("tr").find(".hidden-styleId").val();
        var IsCheked = 0;
        if (elem.checked) {
            IsCheked = 1;
        }
        else {
            IsCheked = 0;
        }
        //                    if (isYes == true) {
        //                        proxy.invoke("UpdateSelectExports", { IsCheked: IsCheked, StyleId: StyleId, AllSelect : 1 },
        //                         function (result) {
        //                             alert('Data saved sucessfully.');
        //                         });
        //                    }
        //                     else {
        proxy.invoke("UpdateSelectExports", { IsCheked: IsCheked, StyleId: StyleId, AllSelect: 0 },
                         function (result) {
                             //                             alert('Data saved sucessfully.');
                         });
        //                    }



    }
    var status = '';
    function UpdateETAwithStatus(elem, selectedval) {
        //debugger;

        var ctId = elem.id.split('_')[8].substr(2);
        var rptid = elem.id.split('_')[6].substr(2);
        var id = $("#ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_hdnid").val();
        proxy.invoke("UpdateStylesFabricStatus", { ID: id, Etadate: $(elem).val() },
                        function (result) {
                            status = result;
                            alert('Data saved sucessfully.');
                            var dd = document.getElementById("ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_ddlstatus");
                            for (var i = 0; i < dd.options.length; i++) {
                                if (dd.options[i].text == status) {
                                    dd.options[i].selected = "true";
                                    break;
                                }
                            }
                        });
        // alert(status);


    }
    var Actual = '';
    function UpdateStylesFabricStatusActual(elem, selectedval) {
        //debugger;

        //alert($(elem).val());        
        var ctId = elem.id.split('_')[8].substr(2);
        var rptid = elem.id.split('_')[6].substr(2);
        var id = $("#ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_hdnid").val();
        var Userid = $("#ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_hdnUserID").val();
        proxy.invoke("UpdateStylesFabricStatusActual", { ID: id, Etadate: $(elem).val(), UserId: Userid },
                        function (result) {

                            Actual = result;
                            // alert(Actual);
                            document.getElementById("ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_txtactual").value = Actual;
                            alert('Data saved sucessfully.');
                            elem.disabled = true;
                        });
        //                        $("#ctl00_cph_main_content_Styles1_GridView2_ct" + rptid + "_rptbuyer_ct" + ctId + "_txtactual").innerHTML = Actual;


    }
    //                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {

    //                        BindParentDepDdl();
    //                        BindSubDepDdl();

    //                    });
    //                    function pageLoad() {
    //                      
    //                    }
    function BindParentDepDdl() {
        debugger;
        var LoggedInID = '<%=this.UserID %>';
        var ClientId = $("#ctl00_cph_main_content_Styles1_ddlClients").val();
        var FitMarchantID = $("#ctl00_cph_main_content_Styles1_ddlMerchandiser").val();
        //                            if (FitMarchantID == "All") {
        //                                FitMarchantID = -1;
        //                            }
        //                            if (ClientId == "All") {
        //                                ClientId = -1;
        //                            }

        //        bindDropdown(serviceUrl, "ctl00_cph_main_content_Styles1_ddlDepts", "BindDeptListAgainstCliets", { UserID: LoggedInID, ClientID: ClientId, FitMerchantID: FitMarchantID }, "CompanyName", "ClientID", false, '', onPageError);
        //        BindSubDepDdl();
        //                            var url = "../Webservices/iKandiService.asmx";
        //                            $.ajax({
        //                                type: "POST",
        //                                contentType: "application/json; charset=utf-8",
        //                                url: url + "/BindDeptListAgainstCliets",
        //                                data: "{UserID:'" + parseInt(LoggedInID) + "', ClientID:'" + parseInt(ClientId) + "', FitMerchantID:'" + parseInt(FitMarchantID) + "'}",
        //                                dataType: "json",
        //                                success: function (Result) {
        //                                    Result = Result.d;
        //                                    $.each(Result, function (key, value) {
        //                                        $("#ctl00_cph_main_content_Styles1_ddlDepts").append($("<option></option>").val(value.ClientID).html(value.ClientID));
        //                                    });
        //                                },
        //                                error: function (Result) {
        //                                    alert("Error");
        //                                }
        //                            });

    }
    //    function BindSubDepDdl() {
    //        var LoggedInID = '<%=this.UserID %>';
    //        var ClientId = $("#ctl00_cph_main_content_Styles1_ddlClients").val();
    //        var FitMarchantID = $("#ctl00_cph_main_content_Styles1_ddlMerchandiser").val();
    //        var ParentDeptID = $("#ctl00_cph_main_content_Styles1_ddlDepts").val();
    //        bindDropdown(serviceUrl, "ctl00_cph_main_content_Styles1_ddlChildDept", "BindDeptListAgainstParentDept", { UserId: LoggedInID, ClientId: ClientId, FitMerchantID: FitMarchantID, ParentDeptID: ParentDeptID }, "CompanyName", "ClientID", false, '', onPageError);
    //    }

                   
                    
    
</script>
<div id="spinnL">
</div>
<div class="print-box" >
    <div class="form_heading" style="min-width: 1340px;width:100%; padding: 5px 0px; box-sizing:border-box; text-align: center;
        float: left; margin-bottom: 10px; border: 1px solid gray; color: #e7e4fb !important">
        Design List</div>
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true" AsyncPostBackTimeout="30000">
    </asp:ScriptManager>
    <%--new code 15-10-2020 start--%>
    <asp:UpdateProgress runat="server" ID="update" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%--new code 15-10-2020 end--%>
    <asp:UpdatePanel ID="Updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;min-width:1400px;margin-left: 5px;">
                <tr>
                    <td>
                        <div align="left" style="margin-bottom: 10px">
                            <span>PD Merchant:</span>
                            <asp:DropDownList runat="server" Style="max-width: 140px;" ID="ddlMerchandiser" OnSelectedIndexChanged="ddlPDMerchantNameSelect_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <span>Season:</span>
                            <asp:DropDownList runat="server" Style="max-width: 140px;" ID="ddlSeason">
                            </asp:DropDownList>
                            <span>Client:</span>
                            <asp:DropDownList runat="server" ID="ddlClients" OnSelectedIndexChanged="ddlClientNameSelect_SelectedIndexChanged"
                                AutoPostBack="true" CssClass="do-not-disable" Style="max-width: 140px; min-width: 120px;">
                                <asp:ListItem Value="-1" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                            <span>Pare.Dept:</span>
                            <asp:DropDownList runat="server" ID="ddlDepts" OnSelectedIndexChanged="ddlDepts_SelectedIndexChanged"
                                AutoPostBack="true" CssClass="do-not-disable" Style="max-width: 140px; min-width: 120px;">
                                <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <span>Sub.Dept:</span>
                            <asp:DropDownList runat="server" ID="ddlChildDept" CssClass="do-not-disable" Style="max-width: 140px;
                                min-width: 120px;">
                            </asp:DropDownList>
                            <span>Status</span>
                            <asp:DropDownList runat="server" ID="ddlfromStatus" CssClass="do-not-disable" Style="max-width: 140px;
                                min-width: 120px;">
                                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Style Created</asp:ListItem>
                                <asp:ListItem Value="33.1">Handover</asp:ListItem>
                                <asp:ListItem Value="33.2">Pattern Ready</asp:ListItem>
                                <asp:ListItem Value="33.3">Sample Sent</asp:ListItem>
                                <asp:ListItem Value="3">Courier Sent</asp:ListItem>
                                <asp:ListItem Value="4">Digital Upload</asp:ListItem>
                                <asp:ListItem Value="5">Costing Bipl</asp:ListItem>
                                <asp:ListItem Value="6">Price Quoted Bipl</asp:ListItem>
                                <asp:ListItem Value="7">Costed Ikandi</asp:ListItem>
                                <asp:ListItem Value="8">BIPL Agreement</asp:ListItem>
                                <asp:ListItem Value="9">Ikandi Agreement</asp:ListItem>
                            </asp:DropDownList>
                            <span>Upto</span>
                            <asp:DropDownList runat="server" ID="ddlUptostatus" CssClass="do-not-disable" Style="max-width: 140px;
                                min-width: 120px;">
                                <asp:ListItem Selected="True" Value="33.3">Sample Sent</asp:ListItem>
                                <asp:ListItem Value="1">Style Created</asp:ListItem>
                                <asp:ListItem Value="33.1">Handover</asp:ListItem>
                                <asp:ListItem Value="33.2">Pattern Ready</asp:ListItem>
                                <asp:ListItem Value="3">Courier Sent</asp:ListItem>
                                <asp:ListItem Value="4">Digital Upload</asp:ListItem>
                                <asp:ListItem Value="5">Costing Bipl</asp:ListItem>
                                <asp:ListItem Value="6">Price Quoted Bipl</asp:ListItem>
                                <asp:ListItem Value="7">Costed Ikandi</asp:ListItem>
                                <asp:ListItem Value="8">BIPL Agreement</asp:ListItem>
                                <asp:ListItem Value="9">Ikandi Agreement</asp:ListItem>
                            </asp:DropDownList>
                            <span>Delay</span>
                            <asp:DropDownList runat="server" ID="ddldelay" CssClass="do-not-disable" Style="max-width: 140px;
                                min-width: 120px;">
                                <asp:ListItem Value="99" Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="1">Upcoming target in 1 Week and Delayed</asp:ListItem>
                                <asp:ListItem Value="0">Delayed</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div align="left" style="margin-bottom: 10px">
                            <span>Criteria:</span>
                            <asp:DropDownList runat="server" ID="DdlCriteria" CssClass="do-not-disable" Style="max-width: 80px;
                                min-width: 120px;">
                                <asp:ListItem Value="1" Selected="True">Created Date</asp:ListItem>
                                <asp:ListItem Value="2">ETA</asp:ListItem>
                            </asp:DropDownList>
                            <span>From:</span>
                            <asp:TextBox ID="txtFRqd" runat="server" CssClass="date-picker th" Width="85px" Enabled="false" readonly="true"></asp:TextBox>
                            <input type="image" id="imgfrom" src="../../App_Themes/ikandi/images1/delete1.png"
                                title="clear from Date" onclick="removetext('txtfrom');return false" />
                            <span>To:</span>
                            <asp:TextBox ID="txtTRqd" runat="server" CssClass="date-picker th" Width="85px" Enabled="false" readonly="true"></asp:TextBox>
                            <input type="image" id="imgto" src="../../App_Themes/ikandi/images1/delete1.png"
                                title="clear to Date" onclick="removetext('txtTo');return false" />
                            <span>Search:</span>
                            <asp:TextBox runat="server" ID="txtSearchText" Style="width: 90px;" CssClass="do-not-disable"></asp:TextBox>&nbsp;
                            <span>Sort By</span>
                            <asp:DropDownList runat="server" ID="ddlFilter1" Width="90px">
                                <asp:ListItem Value="2" Selected="True" Text="Style Created Date"></asp:ListItem>
                                <%--<asp:ListItem Value="1" Text="PD Merchant"></asp:ListItem>--%>
                                <asp:ListItem Value="1" Text="Task ETA"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Client"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Department"></asp:ListItem>
                                <asp:ListItem Value="5" Text="PD Merchant"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList runat="server" ID="ddlFilter2" Width="90px">
                                <asp:ListItem Value="5" Text="PD Merchant"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Task ETA"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Client"></asp:ListItem>
                                <asp:ListItem Selected="True" Value="4" Text="Department"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Style Created Date"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList runat="server" ID="ddlFilter3" Width="90px">
                                <asp:ListItem Selected="True" Value="3" Text="Client"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Task ETA"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Style Created Date"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Department"></asp:ListItem>
                                <asp:ListItem Value="5" Text="PD Merchant"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList runat="server" ID="ddlFilter4" Width="90px">
                                <asp:ListItem Value="4" Text="Department"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Client"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Task ETA"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Style Created Date"></asp:ListItem>
                                <asp:ListItem Selected="True" Value="5" Text="PD Merchant"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:RadioButtonList ID="rdosortingorder" RepeatDirection="Horizontal" runat="server"
                                Style="display: inline;">
                                <asp:ListItem Value="1" Selected="True">Desc</asp:ListItem>
                                <asp:ListItem Value="0">Asc</asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp; &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="da_go_button go"
                                OnClick="btnSearch_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnPagesize" runat="server" />
            <asp:HiddenField ID="hdnPageIndex" runat="server" />
            <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
            <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
            <br />
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound"
                PagerStyle-CssClass="paging" Width="100%" style="min-width:1400px;">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="110px">
                        <HeaderTemplate>
                            Style No.<br />
                            Style Created On
                            <br></br>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="1" cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 30px; vertical-align: middle;">
                                        <asp:HiddenField ID="hdnFitsSample" runat="server" Value='<%# Eval("FitsType") %>' />
                                        <asp:Label ID="lblStyleNo" runat="server" CssClass="Black" Font-Bold="true" SortExpression="StyleNumber"
                                            Text='<%# Eval("StyleNumber") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 43px; vertical-align: middle">
                                        <asp:Label ID="lblCreatedOnDate" runat="server" CssClass="font-10" SortExpression="IssuedOn"
                                            Text='<%# Convert.ToDateTime(Eval("IssuedOn")) == Convert.ToDateTime("1/1/1900") ? "" :  (Convert.ToDateTime(Eval("IssuedOn"))).ToString("dd MMM yy") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>
                            Client
                            <br />
                            Par.Department<br />
                            (Department)
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="1" cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 30px; vertical-align: middle">
                                        <asp:Label ID="lblClient" runat="server" SortExpression="Buyer" Text='<%# Eval("Buyer") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 43px; vertical-align: middle">
                                        <asp:Label ID="lblDept" runat="server" CssClass="font-10" ForeColor="Gray" SortExpression="DepartmentName"
                                            Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>
                            PD Merchandiser
                            <br />
                            Acc. Manager
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="1" cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 30px; vertical-align: middle">
                                        <asp:Label ID="lblSamplingMerchandiser" runat="server" SortExpression="SamplingMerchandisingManagerName"
                                            Text='<%# Eval("SamplingMerchandisingManagerName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 43px; vertical-align: middle">
                                        <asp:Label ID="lblAccountName" runat="server" CssClass="font-10" ForeColor="Gray"
                                            SortExpression="AccountManagerName" Text='<%# Eval("AccountManagerName") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="" HeaderText="Client Name" SortExpression="Buyer"
                ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="80px" />
            <asp:BoundField DataField="" HeaderText="Department Name" SortExpression=""
                ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="100px" />--%>
                    <%--  <asp:BoundField DataField="" HeaderText="Account Manager" SortExpression="AccountManagerName"
                ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="100px" />
            <asp:BoundField DataField="" HeaderText="Sampling Merchandiser"
                SortExpression="SamplingMerchandisingManagerName" ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="100px" />--%>
                    <%--<asp:BoundField  HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <HeaderStyle Width="100px"></HeaderStyle>
                <ItemStyle Width="100px" CssClass="da_table_tr_bg"></ItemStyle>
            </asp:BoundField>--%>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Sketch" SortExpression="SketchURL">
                        <ItemTemplate>
                            <a border="0" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%#Eval("StyleID") %>,-1,-1)'
                                title="CLICK TO VIEW ENLARGED IMAGE">
                                <img height="50px" width="50px" border="0" align="center" src='<%# ResolveUrl("~/Uploads/Style/thumb-" + Eval("SketchURL").ToString()) %>'
                                    visible='<%# (Eval("SketchURL") == null || string.IsNullOrEmpty(Eval("SketchURL").ToString()) ) ? false: true %>' />
                            </a>
                            <asp:HyperLink ID="hlkViewMe" runat="server" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + Eval("DocURL"))%>'
                                Target="_blank" Text="View File" Visible='<%# (Eval("DocURL") == null || string.IsNullOrEmpty(Eval("DocURL").ToString()) ) ? false: true %>'></asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="hide-me" HeaderStyle-Width="50px" HeaderText="Season"
                        ItemStyle-CssClass="da_table_tr_bg hide-me">
                        <ItemTemplate>
                            <asp:Label ID="lblSeasonName" runat="server" Text='<%#Eval("SeasonName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="hide-me" HeaderStyle-Width="130px" HeaderText="Story"
                        ItemStyle-CssClass="da_table_tr_bg hide-me">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblStory" runat="server" Text='<%#Eval("LastStory") %>'></asp:Label>
                            </div>
                            <img alt="Story" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                                border="0" style="display: none;" visible="false" onclick="showRemarks2('<%# Eval("Story") %>')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="hide-me" HeaderStyle-Width="100px" HeaderText="Meeting"
                        ItemStyle-CssClass="da_table_tr_bg hide-me">
                        <ItemTemplate>
                            <asp:Label ID="lblMeetingDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("StyleMeeting")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("StyleMeeting")) ).ToString("dd MMM yy (ddd)" ) %>'
                                Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderStyle-Width="440px" HeaderText="Fabric">
                            <ItemTemplate>
                                <asp:Label ID="lblfabic" runat="server" Text='<%# Eval("Fabric") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="style-fabric3 remarks_text remarks_text2" />
                        </asp:TemplateField>--%>
                    <asp:BoundField DataField="Fabric" HeaderStyle-Width="200px" HeaderText="Fabric"
                        Visible="false" ItemStyle-CssClass="style-fabric3 remarks_text remarks_text2"
                        SortExpression="">
                        <ItemStyle CssClass="style-fabric3 remarks_text remarks_text2" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-Width="440px" HeaderText="">
                        <HeaderTemplate>
                            <table border="1" cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                <tr>
                                    <th style="border: 0px" width="75px">
                                        Rcvd. Buyer
                                    </th>
                                    <th style="border: 0px" width="75px">
                                        Issued On
                                    </th>
                                    <th style="border: 0px" width="75px">
                                        ETA
                                    </th>
                                    <th style="border: 0px" width="75px">
                                        Actual
                                    </th>
                                    <th style="border: 0px" width="75px">
                                        Status
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%" class="repeater-table">
                                <asp:Repeater ID="rptbuyer" runat="server" OnItemDataBound="rptbuyer_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="5" class="style-hypFabric" style="text-align: left !important;">
                                                <%# Eval("Fabric_Name") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="font-10" width="75px">
                                                <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("id") %>' />
                                                <asp:TextBox ID="txtrecbuyer" ReadOnly="true" CssClass="date-picker th" onchange="javascript:return UpdateFabricDetails(this,'RCVBUYER')"
                                                    Text='<%# (Convert.ToDateTime(Eval("RCVDBUYER")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("RCVDBUYER")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("RCVDBUYER")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("RCVDBUYER")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("RCVDBUYER")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("RCVDBUYER")).ToString("dd MMM") : Convert.ToDateTime(Eval("RCVDBUYER")).ToString("dd MMM yyyy")%>'
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="font-10" width="75px">
                                                <asp:TextBox ID="txtissueon" ReadOnly="true" CssClass="date-picker th" onchange="javascript:return UpdateFabricDetails(this,'ISSUE')"
                                                    Text='<%# (Convert.ToDateTime(Eval("ISSUEDON")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("ISSUEDON")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("ISSUEDON")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("ISSUEDON")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("ISSUEDON")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ISSUEDON")).ToString("dd MMM") : Convert.ToDateTime(Eval("ISSUEDON")).ToString("dd MMM yyyy")%>'
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="font-10" width="75px">
                                                <asp:TextBox ID="txtETA" ReadOnly="true" CssClass="date-picker th" onchange="javascript:return UpdateETAwithStatus(this,'ETA')"
                                                    Text='<%# (Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ETA")).ToString("dd MMM") : Convert.ToDateTime(Eval("ETA")).ToString("dd MMM yyyy")%>'
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="font-10" width="75px">
                                                <asp:TextBox ID="txtactual" ReadOnly="true" Style="color: Blue" onchange="javascript:return UpdateFabricDetails(this,'ACTUAL')"
                                                    Text='<%# (Convert.ToDateTime(Eval("Actual")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("Actual")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("Actual")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("Actual")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("Actual")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("Actual")).ToString("dd MMM") : Convert.ToDateTime(Eval("Actual")).ToString("dd MMM yyyy")%>'
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td style="border: 0px" width="75px">
                                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                                <asp:DropDownList ID="ddlstatus" onchange="javascript:return UpdateStylesFabricStatusActual(this,'STATUS')"
                                                    SelectedValue='<%# Eval("STATUS") %>' runat="server">
                                                    <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                    <asp:ListItem Title="unselectable" disabled="disabled" Value="1">On Time</asp:ListItem>
                                                    <asp:ListItem Value="2">In House</asp:ListItem>
                                                    <asp:ListItem Title="unselectable" disabled="disabled" Value="3">Delayed</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="260px">
                        <HeaderTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <th style="border: 0px" width="150px">
                                        Status
                                    </th>
                                    <th style="border: 0px" width="55">
                                        ETA
                                    </th>
                                    <th style="border: 0px" width="55">
                                        Act
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="HdnMasterName" runat="server" Value='<%#Eval("CadMasterName") %>' />
                            <table cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%" style="border: 0!important;">
                                <tr id="trHandover" runat="server">
                                    <td class="font-10" width="150px">
                                        Handover
                                        <asp:Label ID="lblCadMasterName" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="55px">
                                        <strong class="Black">
                                            <asp:Label ID="lblHandOverEta" runat="server" Text='<%# (Convert.ToDateTime(Eval("HandOverEta")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("HandOverEta")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("HandOverEta")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("HandOverEta")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("HandOverEta")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HandOverEta")).ToString("dd MMM") : Convert.ToDateTime(Eval("HandOverEta")).ToString("dd MMM")%>'></asp:Label>
                                        </strong>
                                    </td>
                                    <td width="55px">
                                        <asp:Label ID="lblHandOverAct" runat="server" Text='<%# (Convert.ToDateTime(Eval("HandOverAct")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("HandOverAct")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("HandOverAct")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("HandOverAct")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("HandOverAct")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HandOverAct")).ToString("dd MMM") : Convert.ToDateTime(Eval("HandOverAct")).ToString("dd MMM")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trPatternReady" runat="server">
                                    <td class="font-10" width="150px">
                                        Pattern Ready
                                    </td>
                                    <td width="55px">
                                        <strong class="Black">
                                            <asp:Label ID="lblPatternReadyEta" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternReadyEta")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("PatternReadyEta")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("PatternReadyEta")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("PatternReadyEta")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("PatternReadyEta")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("PatternReadyEta")).ToString("dd MMM") : Convert.ToDateTime(Eval("PatternReadyEta")).ToString("dd MMM")%>'></asp:Label>
                                        </strong>
                                    </td>
                                    <td width="55px">
                                        <asp:Label ID="lblPatternReadyAct" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternReadyAct")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("PatternReadyAct")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("PatternReadyAct")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("PatternReadyAct")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("PatternReadyAct")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("PatternReadyAct")).ToString("dd MMM") : Convert.ToDateTime(Eval("PatternReadyAct")).ToString("dd MMM")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trSampleSent" runat="server">
                                    <td class="font-10" width="150px">
                                        Sample Sent
                                    </td>
                                    <td width="55px">
                                        <strong class="Black">
                                            <asp:Label ID="lblSampleSentEta" runat="server" Text='<%# (Convert.ToDateTime(Eval("SampleSentEta")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("SampleSentEta")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("SampleSentEta")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("SampleSentEta")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("SampleSentEta")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("SampleSentEta")).ToString("dd MMM") : Convert.ToDateTime(Eval("SampleSentEta")).ToString("dd MMM")%>'></asp:Label>
                                        </strong>
                                    </td>
                                    <td width="55px">
                                        <asp:Label ID="lblSampleSentAct" runat="server" Text='<%# (Convert.ToDateTime(Eval("SampleSentAct")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("SampleSentAct")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("SampleSentAct")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("SampleSentAct")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("SampleSentAct")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("SampleSentAct")).ToString("dd MMM") : Convert.ToDateTime(Eval("SampleSentAct")).ToString("dd MMM")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trCostingBipl" runat="server">
                                    <td class="font-10" width="150px">
                                        Costing Bipl
                                    </td>
                                    <td width="55px">
                                        <strong class="Black">
                                            <asp:Label ID="lblCostingBiplEta" runat="server" Text='<%# (Convert.ToDateTime(Eval("CostingBiplEta")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("CostingBiplEta")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("CostingBiplEta")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("CostingBiplEta")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("CostingBiplEta")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CostingBiplEta")).ToString("dd MMM") : Convert.ToDateTime(Eval("CostingBiplEta")).ToString("dd MMM")%>'></asp:Label>
                                        </strong>
                                    </td>
                                    <td width="55px">
                                        <asp:Label ID="lblCostingBiplAct" runat="server" Text='<%# (Convert.ToDateTime(Eval("CostingBiplAct")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("CostingBiplAct")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("CostingBiplAct")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("CostingBiplAct")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("CostingBiplAct")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CostingBiplAct")).ToString("dd MMM") : Convert.ToDateTime(Eval("CostingBiplAct")).ToString("dd MMM")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trPriceQuotedBipl" runat="server">
                                    <td class="font-10" width="150px">
                                        Price Quoted Bipl
                                    </td>
                                    <td width="55px">
                                        <strong class="Black">
                                            <asp:Label ID="lblPriceQuotedBiplEta" runat="server" Text='<%# (Convert.ToDateTime(Eval("PriceQuotedBiplEta")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("PriceQuotedBiplEta")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("PriceQuotedBiplEta")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("PriceQuotedBiplEta")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("PriceQuotedBiplEta")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("PriceQuotedBiplEta")).ToString("dd MMM") : Convert.ToDateTime(Eval("PriceQuotedBiplEta")).ToString("dd MMM")%>'></asp:Label>
                                        </strong>
                                    </td>
                                    <td width="55px">
                                        <asp:Label ID="lblPriceQuotedBiplAct" runat="server" Text='<%# (Convert.ToDateTime(Eval("PriceQuotedBiplAct")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("PriceQuotedBiplAct")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("PriceQuotedBiplAct")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("PriceQuotedBiplAct")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("PriceQuotedBiplAct")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("PriceQuotedBiplAct")).ToString("dd MMM") : Convert.ToDateTime(Eval("PriceQuotedBiplAct")).ToString("dd MMM")%>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>
                            Required By<br>Priority<br>Edit &nbsp; &nbsp; Delete </br>
                            </br>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="1" cellpadding="0" cellspacing="0" frame="void" rules="all" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 25px; vertical-align: middle">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" CssClass="Black" SortExpression="ETA" Text='<%# (Convert.ToDateTime(Eval("ETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime( Eval("ETA")) ).ToString("dd MMM yy" ) %>'
                                                Width="100px"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="tdPriority" runat="server" style="width: 100%; height: 25px; vertical-align: middle;">
                                        <asp:Label ID="lblPriority" runat="server" ForeColor="black" Text='<%#Eval("Priority") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 22px; vertical-align: middle" id="tdEdit_Delete"
                                        runat="server" visible="false">
                                        <%--<asp:HyperLink NavigateUrl= runat="server" ID="hyperEdit">  </asp:HyperLink>--%>
                                        <a href='/internal/Design/DesignerEdit.aspx?styleid=<%# Eval("StyleID") %>'>
                                            <img src="../../images/edit2.png" alt="Edit" />
                                        </a>&nbsp; &nbsp;
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("StyleID") %>'
                                            CommandName="Delete" OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure, you want to delete this style?')"
                                            Visible='<%# Convert.ToDateTime(Eval("CourierReceivedOn")) == DateTime.MinValue && Convert.ToInt32(Eval("StatusModeID")) <  (int)iKandi.Common.TaskMode.SAMPLE_SENT %>'>
                                            <img src="../../images/delete-icon.png" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="hide-me" HeaderText="EXP. DISPATCH" ItemStyle-CssClass="da_table_tr_bg hide-me"
                        ItemStyle-Width="100px" SortExpression="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblMerchandiserDispatchDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("MerchandiserDispatchDate")) == DateTime.MinValue) ? (Convert.ToDateTime( Eval("ETA")) ).ToString("dd MMM yy (ddd)" ) : (Convert.ToDateTime( Eval("MerchandiserDispatchDate")) ).ToString("dd MMM yy (ddd)" ) %>'
                                Width="100px"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="da_table_tr_bg" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="400px" HeaderText="Current Update" ItemStyle-CssClass="vertical_top remarks_text"
                        ItemStyle-Width="400px" ShowHeader="false" Visible="false">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="vertical_top" style="border-collapse: collapse;
                                vertical-align: top !important;" width="400px">
                                <tr>
                                    <td class="remarks_text remarks_text2" style="width: 60% !important;">
                                        Fabric Sampling Program Issued :
                                    </td>
                                    <td style="width: 10% !important;">
                                        <asp:CheckBox ID="chkFabricSamplingProgramIssued" runat="server" Enabled="false"
                                            Width="90%" />
                                    </td>
                                    <td style="width: 30% !important;">
                                        <asp:Label ID="lblFabricSamplingProgramIssue" runat="server" CssClass="date_style"
                                            Width="90%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="remarks_text remarks_text2" style="width: 60% !important;">
                                        Issued for Pattern Making :
                                    </td>
                                    <td style="width: 10% !important;">
                                        <asp:CheckBox ID="chkIssuedForPatternMaking" runat="server" Enabled="false" Width="90%" />
                                    </td>
                                    <td style="width: 30% !important;">
                                        <asp:Label ID="lblIssuedForPatternMaking" runat="server" CssClass="date_style" Width="90%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="remarks_text remarks_text2" style="width: 60% !important;">
                                        Fabric issued for Cutting :
                                    </td>
                                    <td style="width: 10% !important;">
                                        <asp:CheckBox ID="chkFabricIssuedForCutting" runat="server" Enabled="false" Width="90%" />
                                    </td>
                                    <td style="width: 30% !important;">
                                        <asp:Label ID="lblFabricIssuedForCutting" runat="server" CssClass="date_style" Width="90%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="remarks_text remarks_text2" style="width: 60% !important;">
                                        On Machine/Finishing/Ready for dispatch :
                                    </td>
                                    <td style="width: 10% !important;">
                                        <asp:CheckBox ID="chkOnMachineOrFinishingOrReadyForDispatch" runat="server" Enabled="false"
                                            Width="90%" />
                                    </td>
                                    <td style="width: 30% !important;">
                                        <asp:Label ID="lblOnMachineOrFinishingOrReadyForDispatch" runat="server" CssClass="date_style"
                                            Width="90%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle CssClass="hide-me" Width="400px" />
                        <ItemStyle CssClass="vertical_top remarks_text hide-me" Width="400px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Remarks" ItemStyle-CssClass="remarks_text remarks_text2"
                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Style="text-align: left !important" Text='<%# Eval("SamplingStatusRemarks").ToString().Replace("$$","<br>") %>'
                                Width="100px"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="hide-me" Width="100px" />
                        <ItemStyle CssClass="remarks_text remarks_text2 hide-me" HorizontalAlign="Left" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Courier Received On" ItemStyle-CssClass="date_style"
                        ItemStyle-Width="100px" SortExpression="CourierReceivedOn" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCourierReceivedOn" runat="server" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DESIGN_LIST_SAMPLE_RECEIVED_COURIER_RECEIVED_ON)? "courier-received-on  date_style":" courier-received-on  date_style do-not-allow-typing" %>'
                                Text='<%#  (Convert.ToDateTime(Eval("CourierReceivedOn")) == DateTime.MinValue)? "" :  Eval("CourierReceivedOn", "{0:dd MM yyy (ddd)}") %>'
                                Width="100px"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="hide-me" Width="100px" />
                        <ItemStyle CssClass="da_table_tr_bg hide-me" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Courier Received" Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DESIGN_LIST_SAMPLING_FILE_COURIER_RECEIVED)? "courier-received":"courier-received disable-checkbox" %>'
                                Visible='<%# Convert.ToDateTime(Eval("CourierReceivedOn")) == DateTime.MinValue && Convert.ToInt32(Eval("StatusModeID")) >= (int)iKandi.Common.TaskMode.SAMPLE_SENT  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="hide-me" />
                        <HeaderStyle CssClass="hide-me" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Priority" ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="50px">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Status" ItemStyle-CssClass="da_edit_delete_link">
                        <ItemTemplate>
                            <a id="hypstatusmode" runat="server" class="hide_me"></a><a href="javascript:void(0)"
                                onclick='showWorkflowHistory2(<%# Eval("StyleID") %>,-1,-1)' title="CLICK TO SEE WORKFLOW HISTORY">
                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--  <asp:HyperLinkField HeaderText="Edit" ItemStyle-VerticalAlign="Middle" DataNavigateUrlFields="StyleID"
                DataNavigateUrlFormatString="~/internal/Design/DesignerEdit.aspx?styleid={0}"
                Text="Edit" ItemStyle-CssClass="da_edit_delete_link" HeaderStyle-Width="30px">
                <ItemStyle VerticalAlign="Middle"></ItemStyle>
            </asp:HyperLinkField>--%>
                    <%--   <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="da_edit_delete_link" HeaderStyle-Width="40px">
                <ItemTemplate>
                   
                </ItemTemplate>
            </asp:TemplateField>--%>
                    <%-- <asp:HyperLinkField HeaderText="View History" ItemStyle-VerticalAlign="Middle" DataNavigateUrlFields="StyleID"
                DataNavigateUrlFormatString="../../Admin/FitsSample/SamplingFitsCycleHistory.aspx?styleid={0}"
                Text="&lt;img src='../../images/icon.jpg'" ControlStyle-CssClass="showpopup" ItemStyle-CssClass="da_edit_delete_link" HeaderStyle-Width="30px">
                <ItemStyle VerticalAlign="Middle"></ItemStyle>
                
            </asp:HyperLinkField>--%>
                    <asp:TemplateField HeaderStyle-Width="30px" HeaderText="View History" ItemStyle-CssClass="da_edit_delete_link">
                        <ItemTemplate>
                            <input type="hidden" class="hidden-styleId" value='<%#Eval("StyleID") %>' />
                            <asp:ImageButton ID="ImgbtnHistory" runat="server" Height="12px" ImageUrl="~/images/icon.jpg"
                                OnClientClick="javascript:return ShowSamplingFitsHistory(this)" Width="12px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Remarks" ItemStyle-CssClass="da_edit_delete_link">
                        <ItemTemplate>
                            <input type="hidden" class="hdn_styleId" value='<%#Eval("StyleID") %>' />
                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                            <br />
                            <asp:ImageButton ID="ImgbtnRemarks" runat="server" Height="12px" ImageUrl="~/images/comment.png"
                                Style="float: right; padding: 1px 5px; cursor: pointer;" OnClientClick="javascript:return showCommentPopup(this)"
                                Width="12px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="130px" HeaderText="BuyerStyleNumber" ItemStyle-CssClass="da_edit_delete_link">
                        <ItemTemplate>
                            <%--<input type="hidden" class="hdn_Buyer_styleId" value='<%#Eval("StyleID") %>' />--%>
                            <asp:TextBox ID="txtBuyerStyleNumber" runat="server" MaxLength="20" onchange="javascript:return UpdateBuyerStyleNumber(this)"
                                Text='<%# Eval("BuyerStyleNumber") %>'></asp:TextBox>
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="ChkFor<br>Export" ItemStyle-CssClass="da_edit_delete_link">
                        <ItemTemplate>
                            <%-- <input type="hidden" class="hdn_Check_styleId" value='<%#Eval("StyleID") %>' />--%>
                            <asp:CheckBox ID="chkSelected" onclick="javascript:return UpdateSelectExport(this)"
                                runat="server" Checked='<%# Eval("IsSelected") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <label>
                        No records Found</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <%--<table width="1968" border="0" cellspacing="0" cellpadding="0" style="display: none;">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td class="da_table_heading_bg">
                <span class="da_h1">Samples Received
                    <td width="13" class="da_table_heading_bg_right">
                        &nbsp;
                    </td>
        </tr>
    </table>--%>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="da_header_heading"
        Width="1968" OnRowDataBound="GridView1_RowDataBound" RowStyle-CssClass="grid_row"
        AlternatingRowStyle-CssClass="grid_row" Visible="false">
        <RowStyle CssClass="grid_row"></RowStyle>
        <Columns>
            <asp:BoundField DataField="IssuedOn" HeaderText="Uploaded On" SortExpression="IssuedOn"
                HeaderStyle-Width="100px" ItemStyle-Width="100px" DataFormatString='{0:dd MMM yy (ddd)}'>
                <HeaderStyle Width="100px"></HeaderStyle>
                <ItemStyle Width="100px" CssClass="da_table_tr_bg"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Buyer" HeaderText="Client Name" SortExpression="Buyer"
                ItemStyle-CssClass="da_table_tr_bg" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName"
                ItemStyle-CssClass="da_table_tr_bg" />
            <asp:BoundField DataField="AccountManagerName" HeaderText="Account Manager" SortExpression="AccountManagerName"
                ItemStyle-CssClass="da_table_tr_bg" />
            <asp:BoundField DataField="SamplingMerchandisingManagerName" HeaderText="Sampling Merchandiser"
                SortExpression="SamplingMerchandisingManagerName" ItemStyle-CssClass="da_table_tr_bg" />
            <asp:BoundField DataField="StyleNumber" ItemStyle-CssClass="da_table_tr_bg" HeaderText="Style Number"
                SortExpression="StyleNumber" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <HeaderStyle Width="100px"></HeaderStyle>
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Sketch" SortExpression="SketchURL">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("StyleID") %>' Visible="false"></asp:Label>
                    <a border="0" title="CLICK TO VIEW ENLARGED IMAGE" href='javascript:void(0)' onclick='showStylePhotoWithOutScroll(<%#Eval("StyleID") %>,-1,-1)'>
                        <img height="75px" border="0" align="center" src='<%# ResolveUrl("~/Uploads/Style/thumb-" + Eval("SketchURL").ToString()) %>'
                            visible='<%# (Eval("SketchURL") == null || string.IsNullOrEmpty(Eval("SketchURL").ToString()) ) ? false: true %>' />
                    </a>
                    <asp:HyperLink ID="hlkViewMe" runat="server" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + Eval("DocURL"))%>'
                        Visible='<%# (Eval("DocURL") == null || string.IsNullOrEmpty(Eval("DocURL").ToString()) ) ? false: true %>'
                        Target="_blank" Text="View File"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Season" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSeasonName" Text='<%#Eval("SeasonName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Story" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <div>
                        <asp:Label runat="server" ID="lblStory" Text='<%#Eval("LastStory") %>'></asp:Label>
                    </div>
                    <img alt="Story" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" visible="false" style="display: none;" onclick="showRemarks2('<%# Eval("Story") %>')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Meeting" ItemStyle-CssClass="da_table_tr_bg">
                <ItemTemplate>
                    <asp:Label ID="lblMeetingDate" Width="100px" Text='<%# (Convert.ToDateTime(Eval("StyleMeeting")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("StyleMeeting")) ).ToString("dd MMM yy (ddd)" ) %>'
                        runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Fabric" ItemStyle-CssClass="style-fabric3 remarks_text remarks_text2"
                HeaderText="Fabric" SortExpression="" HeaderStyle-Width="350px" ItemStyle-Width="350px">
                <HeaderStyle Width="350px" Wrap="False"></HeaderStyle>
                <ItemStyle CssClass="style-fabric3 remarks_text remarks_text2" Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Req by" SortExpression="ETA" ItemStyle-CssClass="da_table_tr_bg"
                HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label ID="Label1" Width="100px" Text='<%# (Convert.ToDateTime(Eval("ETA")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("ETA")) ).ToString("dd MMM yy (ddd)" ) %>'
                        runat="server"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px"></HeaderStyle>
                <ItemStyle CssClass="da_table_tr_bg" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Update" HeaderStyle-Width="400px" ItemStyle-Width="400px"
                ItemStyle-CssClass="vertical_top remarks_text">
                <ItemTemplate>
                    <table width="400px" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
                        vertical-align: top !important;" class="vertical_top">
                        <tr>
                            <td style="width: 60% !important;" class="remarks_text remarks_text2">
                                Fabric Sampling Program Issued :
                            </td>
                            <td style="width: 10% !important;">
                                <asp:CheckBox ID="chkFabricSamplingProgramIssued" Enabled="false" Width="90%" runat="server" />
                            </td>
                            <td style="width: 30% !important;">
                                <asp:Label ID="lblFabricSamplingProgramIssue" runat="server" Width="90%" CssClass="da_table_tr_bg"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60% !important;" class="remarks_text remarks_text2">
                                Issued for Pattern Making :
                            </td>
                            <td style="width: 10% !important;">
                                <asp:CheckBox ID="chkIssuedForPatternMaking" Width="90%" runat="server" Enabled="false" />
                            </td>
                            <td style="width: 30% !important;">
                                <asp:Label ID="lblIssuedForPatternMaking" runat="server" Width="90%" CssClass="da_table_tr_bg"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60% !important;" class="remarks_text remarks_text2">
                                Fabric issued for Cutting :
                            </td>
                            <td style="width: 10% !important;">
                                <asp:CheckBox ID="chkFabricIssuedForCutting" Width="90%" runat="server" Enabled="false" />
                            </td>
                            <td style="width: 30% !important;">
                                <asp:Label ID="lblFabricIssuedForCutting" runat="server" Width="90%" CssClass="da_table_tr_bg"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60% !important;" class="remarks_text remarks_text2">
                                On Machine/Finishing/Ready for dispatch :
                            </td>
                            <td style="width: 10% !important;">
                                <asp:CheckBox ID="chkOnMachineOrFinishingOrReadyForDispatch" Width="90%" runat="server"
                                    Enabled="false" />
                            </td>
                            <td style="width: 30% !important;">
                                <asp:Label ID="lblOnMachineOrFinishingOrReadyForDispatch" runat="server" Width="90%"
                                    CssClass="da_table_tr_bg"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Width="400px"></HeaderStyle>
                <ItemStyle CssClass="vertical_top remarks_text" Width="400px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Courier Received On" SortExpression="CourierReceivedOn"
                ItemStyle-CssClass="da_table_tr_bg" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <ItemTemplate>
                    <input type="hidden" class="hidden-styleId" value='<%# Eval("StyleID") %>' />
                    <asp:Label ID="lblCourierReceived" Width="100px" runat="server" Text='<%#  (Convert.ToDateTime(Eval("CourierReceivedOn")) == DateTime.MinValue)? "" : (Convert.ToDateTime(Eval("CourierReceivedOn"))).ToString("dd MMM yy (ddd)")  %>'
                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DESIGN_LIST_SAMPLE_RECEIVED_COURIER_RECEIVED_ON)? "vertical_header_input date_style":"date_style vertical_header_input do-not-allow-typing" %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px"></HeaderStyle>
                <ItemStyle CssClass="da_table_tr_bg" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Edit" ItemStyle-CssClass="da_edit_delete_link" ItemStyle-VerticalAlign="Middle"
                DataNavigateUrlFields="StyleID" DataNavigateUrlFormatString="~/internal/Design/DesignerEdit.aspx?styleid={0}"
                Text="Edit">
                <ItemStyle VerticalAlign="Middle"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
        <AlternatingRowStyle CssClass="grid_row"></AlternatingRowStyle>
    </asp:GridView>--%>
    <div style="margin-top: 5px; text-align: center; display: none;" class="paging">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10" CssClass="paging"></cc1:HyperLinkPager>
    </div>
    <asp:Button ID="Button1" Style="float: left;" Text="Export to excel" OnClick="btntoExcel_Click"
        runat="server" />
    <script type="text/javascript">


        function showCommentPopup(obj) {
            debugger;
            var Ids = obj.id;
            var StyleId = $("#" + Ids).closest("tr").find(".hidden-styleId").val();

            proxy.invoke("Style_Remarks", { StyleId: StyleId },
            function (result) {
                jQuery.facebox(result);

            }, null, false, false);
            return false;
        }


        function ShowSamplingFitsHistory(obj) {
            // debugger;
            //var objRow = $(this).parents("tr");
            //var styleID = objRow.find(".hidden-styleId").val();

            var Ids = obj.id;

            var cId = "#" + Ids;
            var StyleId = $(cId).closest("tr").find(".hidden-styleId").val();
            // alert(StyleId);

            proxy.invoke("GetSamplingHistory_PreOrder", { StyleId: StyleId },
            function (result) {
                jQuery.facebox(result);

            }, null, false, false);
            return false;
        }

    </script>
</div>
