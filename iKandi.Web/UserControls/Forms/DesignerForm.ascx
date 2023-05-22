<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DesignerForm.ascx.cs"
    EnableViewState="true" Inherits="iKandi.Web.DesignerForm" %>
<style type="text/css">
    .tabs_tr
    {
        /*--min-height: 32px; --Set height of tabs--*/
        width: 100%;
    }
    html #tabs td.active, html #tabs td.active a:hover
    {
        /*--Makes sure that the active tab does not listen to the hover properties--*/
        background: #fff; /*--Makes the active tab look like it's connected with its content--*/
    }
    #tabs td a
    {
        text-decoration: none;
        color: Black; /* #e91677;*/
        display: block;
        font: normal 12px/24px arial;
        padding-left: 5px;
        padding-right: 5px;
        border: solid 1px #ccc; /*--Gives the bevel look with a 1px white border inside the list item--*/
        outline: none;
        height: 25px;
        margin: 1px;
        white-space: nowrap;
    }
    #tabs td a:hover
    {
        background: #F9DDF4;
    }
    .selectedTabs
    {
        background: #F9DDF4 !important;
        color: #282828 !important;
    }
    .tabs_td
    {
        display: inline-block;
    }
    .tabs_td .selectedTabs
    {
        text-decoration: none;
        color: Black;
        display: block;
        font-size: 12px;
        padding: 0 20px;
        border: solid 1px Black;
        outline: none;
    }
    .text-area
    {
        color: #000;
        text-transform: none;
    }
    .print
    {
    }
    .submit
    {
        border: solid 1px #0b61b1;
        color: #fff;
        text-decoration: none;
        text-align: center;
    }
    .submit:hover
    {
        color: #fff;
        text-decoration: none;
        text-align: center;
    }
    .tblFab
    {
        width: 100%;
        border: solid 1px #cccccc;
        vertical-align: top;
    }
    .tblFab1
    {
        width: 100%;
        border: solid 1px #cccccc;
        vertical-align: top;
    }
    .fabInner
    {
        width: 100%;
    }
    .tdSpace
    {
        width: 37%;
    }
    .input_in
    {
        border: solid 1px #c3c3c3;
        width: 96%;
        font: normal 11px/14px Arial, Helvetica, sans-serif;
        color: #1e23f1;
        text-align: left;
        padding: 2px;
    }
    .da_multiple_common
    {
        font: normal 11px/14px "Lucida Grande" , "Lucida Sans Unicode" ,Helvetica,Arial,Verdana,sans-serif;
        color: #000;
        text-align: left;
        text-transform: capitalize;
    }
    .print-box
    {
        background-color: #fff;
    }
    select
    {
        text-transform: capitalize;
    }
    /*#preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }*/
    iframe
    {
        background: #ffffff;
    }
    /* #sb-wrapper
    {
        top: 60px !important;
    }*/
    .commentbox
    {
        width: calc(100% - 900px);
    }
    
    /* The Modal (background) */
    .modal
    {
        display: none;
        position: fixed;
        z-index: 1;
        padding-top: 100px;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgb(0,0,0);
        background-color: rgba(0,0,0,0.4);
    }
    
    /* Modal Content */
    .modal-content
    {
        background-color: #fefefe;
        padding: 20px;
        border: 1px solid #888;
        width: auto;
        position:absolute;
        top:50%;
        left:50%;
        transform: translate(-50%, -50%);
       
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
    .submit
    {
        color: Yellow !important;
    }
    #ctl00_cph_main_content_DesignerForm1_grdAccsessory td
    {
        border-top: 0px !important;
        border-bottom: 0px !important;
        border-left: 0px !important;
        border-right: 0px !important;
    }
    input[type="text"]
    {
        padding-left: 1px;
    }
    /*updated css by bharat 4 jan 19*/
    .fabri_listtable td
    {
        text-align: center;
    }
    .fabri_listtable td:first-child
    {
        text-align: left;
        padding-left: 3px;
    }
    
    .fabricheader td
    {
        background: #4061ab;
        color: #f8f8f8;
        text-align: center;
        padding: 2px 0px;
    }
    .fabricheader td:first-child
    {
        border-left: 1px solid #999999;
    }
    .fabricheader td:last-child
    {
        border-right: 1px solid #999999;
    }
    .fabri_listtable td:nth-child(3)
    {
       width:100px;
    }
    .fabri_listtable td:first-child
    {
        border-left: 1px solid #999999;
    }
    .fabri_listtable td:last-child
    {
        border-right: 1px solid #999999;
    }
    .access_infotable th
    {
        border-bottom: 1px solid #999999;
        border-right: 1px solid #999999;
        text-align: center;
        padding: 2px;
        color: #4c4c4c!important;
        
    }
    .access_infotable th:first-child
    {
        border-left: 1px solid #999999;
    }
    .access_infotable td
    {
        border-bottom: 1px solid #999999;
        border-right: 1px solid #999999;
        text-align: center;
    }
    .access_infotable td:first-child
    {
        border-left: 1px solid #999999;
    }
    .modal-content
    {
        padding: 0px;
        border:5px solid #c7c3c3;
        border-radius: 5px;
    }
    
   /* #dvSizeRate
    {
        max-width: 400px !important;
    }*/
    input[type="radio"]
    {
        position: relative;
        top: 2px;
    }
    
    nobr
    {
        text-transform: capitalize !important;
    }
    input
    {
        text-transform: capitalize !important;
    }
    /*  .ac_over
    {
        background: #999 !important;
    }*/
    .ac_odd table td
    {
        border-color: #e1e1e1 !important;
    }
    .ac_even table td
    {
        border-color: #e1e1e1 !important;
    }
    table
    {
        border-color: #e1e1e1 !important;
    }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
        border-radius: 5px;
    }
    .show_me
    {
        text-transform: capitalize;
    }
    .Designbackgroundcolor td
    {
        background: red !important;
    }
    @media print
    {
        body
        {
            -webkit-print-color-adjust: exact;
        }
    }
    .input[type=file]
    {
        height:18px !important;
      }
      .text-content
      {
          text-transform: capitalize;
      }

    
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .ac_results li
    {
        margin: 0px;
        cursor: default;
        display: block;
        padding: 0px;
        font: menu;
        font-size: 11px;
        overflow: hidden;
        text-align: left;
        cursor: pointer;
    }
   .ac_results ul > li:first-child
    {
        pointer-events: none;
        color: White;
        position: sticky;
        width: 100%;
        margin: 1px 0px 0px;
        top:0; 
        background:#39589c;
    }
    .ac_results ul > li:first-child td
    {
        pointer-events: none;
        background: #4061ab;
        color: #f8f8f8 !important;
    }
     .ac_results ul li tr td:nth-child(3)
    {
        width:80px;
    }
    
    .ac_results ul:nth-child(2)
    {
        background: black;
    }
    .ac_results ul:nth-child(1)
    {
        text-align: center;
    }
    .ac_results
    {
        border-color: #999999;
        border: 1px solid #7a94bb;
    }
    input[type=text]:first-child.borderClass
    {
        border-color: Red;
        border-width: 1px;
        border-style: solid; /** OR USE INLINE border: 1px solid #C1E0FF; **/
    }
    a
    {
        text-decoration: none;
    }
    a:hover
    {
        text-decoration: underline;
    }
    .assce:hover
    {
        text-decoration: underline;
    }
    @media screen and (max-width: 1440px)
    {
        .print-box
        {
            width: 1340px;
            overflow: auto;
        }
    }
    input[type='checkbox']
    {
        position: relative;
        top: 3px;
    }
     .td-sub_headings {
    font: 500 11px/13px sans-serif;
    color: #212121;
    text-align: left;
    text-decoration: none;
    text-transform: none;
}
</style>
<asp:Panel runat="server" ID="pnlForm">
    <script src="../../js/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="../../CommonJquery/Js/jquery.lightbox-0.5.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        //            window.onload = function () {
        //                const myInput = document.getElementById('myInput');
        //                myInput.onpaste = function (e) {
        //                e.preventDefault();
        //                }
        //            }

    </script>
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var ddlDivisionName = '<%=ddlDivisionName.ClientID%>';
        var BuyerDDClientID = '<%=ddlBuyer.ClientID%>';
        var BuyerHdnClientID = '<%=hdnBuyer.ClientID%>';
        var hdnSeasonIDClientID = '<%=hdnSeason.ClientID%>';
        var BuyingHouseDDClientID = '<%=ddlBuyingHouse.ClientID%>';
        var ParentDeptDDClientID = '<%=ddlParentDept.ClientID%>';
        var hdnParentDeptNameClientID = '<%=hdnParentDeptName.ClientID%>';
        var DeptDDClientID = '<%=ddlDept.ClientID%>';
        var SeasonDDClientID = '<%=ddlSeason.ClientID%>';
        var AccMgrClientID = '<%=ddlAccMgr.ClientID %>';
        var tblBasicInfoClientID = "tblBasicInfo";
        var FabricTypeDDClientID = "ddlFabricType1";
        var spanPrintClientID = "spanPrint";
        var chkDefaultETAClientID = '<%=chkDefaultETA.ClientID %>';
        var txtStyle2ClientID = '<%=txtStyle2.ClientID %>';
        var txtStyleClientID = '<%=txtStyle.ClientID %>';
        var ddlStyle2ClientID = '<%=txtDesignerCode.ClientID %>';
        var txtStyle1ClientID = '<%=txtStyle1.ClientID %>';
        var btnSaveAsClientID = '<%= btnSaveAs.ClientID %>';
        var rdobtnClientID = '<%= rdobtn.ClientID %>';
        var upSketchClientID = '<%= upSketch.ClientID %>'
        var imgSketchClientID = '<%= imgSketch.ClientID %>'
        var txtStyleNoClientID = '<%=txtStyleNo.ClientID %>';
        var hdnStyleIDClientID = '<%=hdnStyleID.ClientID %>';
        var ddlSamplingClientID = '<%=ddlSampling.ClientID %>';
        var hdnDeptNameClientID = '<%=hdnDeptName.ClientID %>';
        var ddlDesignerCodeID = '<%=ddlDesignerCode.ClientID %>';
        var hdnuseridClientID = '<%=hdnuserid.ClientID %>';
        var hdnstylenumberClientID = '<%=hdnstylenumber.ClientID %>';
        var hdnPreviousETAClientID = '<%=hdnPreviousETA.ClientID %>';
        var txtETAClientID = '<%=txtETA.ClientID %>';
        var lbldddlexistancecheckClientID = '<%=hdndddlexistancecheck.ClientID %>';
        var jscriptPageVariables = null;
        var counter = 0;
        stylecodeNewMax = '<%=hdnstylecodeNew.ClientID %>';


        $(function () {
          
            var ii = $("#" + hdnstylenumberClientID).val();
            $("#" + chkDefaultETAClientID).click(function () {
                var checked = this.checked;
                if (checked == true) {
                    var currentDate = new Date();
                    currentDate.setDate(currentDate.getDate() + 21);
                    var m = (currentDate.getMonth() + 1);
                    if (m < 10)
                        m = "0" + m;
                    var newDate = m + '/' + currentDate.getDate() + '/' + currentDate.getFullYear();
                    var styleETA = $('.style-eta');
                    styleETA.attr('value', ParseDateToDateWithDay(new Date(newDate)));
                    styleETA.addClass("do-not-allow-typing");
                }
            });

            $('input.style-eta', '#main_content').change(function () {

                $("#" + chkDefaultETAClientID).attr({ checked: false })

            });

            $("#" + BuyerDDClientID, '#main_content').change(function () {
                
                var query = '';
                var args = new Object();
                var query = location.search.substring(1);
                var pairs = query.split("&");
                if (pairs[0] != "" && query != "") {
                    if (counter == 0 && $("#" + lbldddlexistancecheckClientID).val() == "1") {
                        $("#" + BuyerDDClientID, '#main_content')[0][$("#" + BuyerDDClientID, '#main_content').context.activeElement.length - 1].value = "";
                        $("#" + BuyerDDClientID, '#main_content')[0][$("#" + BuyerDDClientID, '#main_content').context.activeElement.length - 1].text = "";
                        $("#" + BuyerDDClientID, '#main_content').context.activeElement.length = $("#" + BuyerDDClientID, '#main_content').context.activeElement.length - 1;
                        counter++;
                    }
                }
                onCompanyChange();

            });

            $("#" + SeasonDDClientID, '#main_content').change(function () {
                var ddl = document.getElementById('<%=ddlSeason.ClientID%>').value;
                $("#" + hdnSeasonIDClientID).val($("#" + SeasonDDClientID).val());

            });

            $("#" + ddlDivisionName, '#main_content').change(function () {

                var selectedValue = $("#" + ddlDivisionName, '#main_content').val();
                if (selectedValue == '-1' || selectedValue == '0') return;
                populateBuyingHouse(selectedValue);
            });

            $("#" + BuyingHouseDDClientID, '#main_content').change(function () {

                var selectedValue = $("#" + BuyingHouseDDClientID, '#main_content').val();
                if (selectedValue == '-1' || selectedValue == '-1') return;
                populateClients(selectedValue);
            });

            $("#" + ParentDeptDDClientID, '#main_content').change(function () {

                var ClientId = $("#" + BuyerDDClientID, '#main_content').val();
                var ParentDeptId = $(this).val();
                if ($(this).val() != null && $(this).val() != '') {
                    populateDepartments(ClientId, -1, ParentDeptId, 'SubParent');
                }
                $(this).val(ParentDeptId);
                $("#" + hdnParentDeptNameClientID, "#main_content").val($("#" + ParentDeptDDClientID + " option:selected").text());

            });

            $("#" + DeptDDClientID, '#main_content').change(function () {

                setDeptName();
                if ($(this).val() != null && $(this).val() != '') {
                    populateAccMgr($(this).val());
                    populateSamplingMerch($(this).val());
                }

            });

            $("#" + ddlDesignerCodeID, '#main_content').change(function () {
                proxy.invoke("GetMaxStyleNumber", { Code: $(this).val() },
                        function (result) {
                            if (result == null || result == '')
                                return;

                            $("#" + txtStyle1ClientID).val(result);

                        });
            });

            $("#" + FabricTypeDDClientID, '#main_content').change(function () {

                //    
                onFabricChange(1);

            });

            //$("FORM").validate();

            if (jscriptPageVariables != null && jscriptPageVariables.styleFabrics != null && jscriptPageVariables.styleFabrics != '') {

                // attach the template
                $("#divBasicInfo", "#main_content").setTemplateElement("templateBasicInfo");

                $("#divBasicInfo", "#main_content").setParam('x', 1);

                // process the template
                $("#divBasicInfo", "#main_content").processTemplate(jscriptPageVariables.styleFabrics);

                var rowCount = $("#" + tblBasicInfoClientID + " tr").length;
                //   
                for (var i = 1; i <= rowCount; i++) {
                    onFabricChange(i);

                    $('#ddlFabricType' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange(rowindex);
                    });

                    //  $('#ddlFabricType1_' + i).attr("onchange", "(1," + i + ")");
                    $('#ddlFabricType1_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(1, rowindex);

                    });

                    //  $('#ddlFabricType2_' + i).attr("onchange", "onFabricChange1(2," + i + ")");
                    $('#ddlFabricType2_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(2, rowindex);

                    });

                    //  $('#ddlFabricType3_' + i).attr("onchange", "onFabricChange1(3," + i + ")");
                    $('#ddlFabricType3_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(3, rowindex);

                    });

                    //  $('#ddlFabricType4_' + i).attr("onchange", "onFabricChange1(4," + i + ")");
                    $('#ddlFabricType4_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(4, rowindex);

                    });
                    $('#ddlFabricType5_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(5, rowindex);

                    });
                    $('#ddlFabricType6_' + i, '#main_content').change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;

                        onFabricChange1(6, rowindex);

                    });
                }
            }

            $("input.style-number", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumberCode", { dataType: "xml", datakey: "string", max: 100 });


            $("input.a", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestStoryWeb", { dataType: "xml", datakey: "string", max: 100 });

            $("#" + txtStyleNoClientID).autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100 });

            $("input.ind-block", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestINDBlockNumber", { dataType: "xml", datakey: "string", max: 100 });


            setupControls();


            $('#lightbox-image-details-caption').hide();
            $('#lightbox-image-details-currentNumber').hide();

            $("a[rel=lightbox]").lightBox({

                imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

                imageBtnPrev: '/app_themes/ikandi/images/lightbox-btn-prev.gif',

                imageBtnNext: '/app_themes/ikandi/images/lightbox-btn-next.gif',

                imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

                imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif'

            });

            $("#" + txtStyle2ClientID).change(function () {
                 
                var obj = $(this)[0];
                var designerCode = "";
                var previousETA = $("#" + txtETAClientID, '#main_content').val();

                var today = new Date();
                var nextETA = new Date();
                nextETA.setDate(today.getDate() + 21);
                nextETA = nextETA.toString("dd MMM yy (ddd)");

                if ($("#" + ddlStyle2ClientID, '#main_content').val() == null)
                    designerCode = $("#" + ddlDesignerCodeID, '#main_content').val();
                else if ($("#" + ddlDesignerCodeID, '#main_content').val() == null)
                    designerCode = $("#" + ddlStyle2ClientID, '#main_content').val();

                if (obj.defaultValue != $(this).val()) {
                    var styleNumber = $("#" + txtStyleClientID, '#main_content').val() + " " + designerCode + $("#" + txtStyle1ClientID, '#main_content').val() + " " + $("#" + txtStyle2ClientID, '#main_content').val();

                    onStyleNumberChange(styleNumber);
                    $("#" + hdnPreviousETAClientID, '#main_content').val(previousETA);
                    $("#" + txtETAClientID, '#main_content').val(nextETA);
                }
                else if (obj.defaultValue == $(this).val()) {
                    $("#" + btnSaveAsClientID, '#main_content').hide();
                    $("#" + rdobtnClientID, '#main_content').find("input,span").attr("disabled", "disabled");
                    $("#" + txtETAClientID, '#main_content').val($("#" + hdnPreviousETAClientID, '#main_content').val());
                }

            });

            $("#" + txtStyle1ClientID).change(function () {
                 
                var obj = $(this)[0];
                var designerCode = "";

                if ($("#" + ddlStyle2ClientID, '#main_content').val() == null)
                    designerCode = $("#" + ddlDesignerCodeID, '#main_content').val();
                else if ($("#" + ddlDesignerCodeID, '#main_content').val() == null)
                    designerCode = $("#" + ddlStyle2ClientID, '#main_content').val();

                if (obj.defaultValue != $(this).val()) {
                    var styleNumber = $("#" + txtStyleClientID, '#main_content').val() + " " + designerCode + $("#" + txtStyle1ClientID, '#main_content').val() + " " + $("#" + txtStyle2ClientID, '#main_content').val();

                    onStyleNumberChange(styleNumber);
                }
                else if (obj.defaultValue == $(this).val()) {
                    $("#" + btnSaveAsClientID, '#main_content').hide();
                }
            });

            
            setMultiplePrint();
            PageLoad();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);
             

        });

        function InitializeRequest(sender, args) { }
        function EndRequest(sender, args) { PageLoad(); }

        function PageLoad() {
            //====================Accessory Parts===================
            // $('.do-not-allow-typing').attr("readonly", "readonly");
            $("input.ind-block", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestINDBlockNumber", { dataType: "xml", datakey: "string", max: 100 });
            $('input.items', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/GetAccessoryList_newtubularAutoComp_Design", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });
            $('input.items', '#main_content').result(function () {

                 
                $(this).removeClass("InvalidAcc");

                if ($(this).val().includes('Supplier Details')) {
                    $(this).val("");
                    return;
                }

                var mys = $(this).val().split('$');
                var mys2 = mys[1].split('**');

                $(this).val(mys2[0].trim());
                var Id = mys2[1].trim();
                var Unit = mys2[2].trim();
                Item = $(this);
                var td = $("td", Item.closest("tr"));
                //if ($("[id$=hdnFooterAccQualityId]", td) != null) {
                //    $("[id$=hdnFooterAccQualityId]", td).val(Id);
                //}
                //if ($("[id$=hdnAccQualityId]", td) != null) {
                //   $("[id$=hdnAccQualityId]", td).val(Id);
                //}
                if (Id == -5 || Id == -4 || Id == -3 || Id == -2 || Id == -1) {
                    alert("This accessories is not applicable please select another.")
                    $(this).val('');
                    CalculateAccessoriesTotal(Item);
                    $(Item).focus();
                }
                else {
                    //--------------------Funtion for Get Sixze Rate------------------
                    var url = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: "POST",
                        url: url + "/GetSize_Rate",
                        data: "{ search:'" + Id + "',ClientId:'" + 0 + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccessCall,
                        error: function (response) { alert(response.d); }
                    });
                }

                function OnSuccessCall(response) {
                  
                    var table = "<h3 style='background-color: #4061ab;color: #F8F8F8;border: 1px solid gray;padding:2px;margin:0;'>Size Rate</h3>";
                    table += "<table style='table-layout:auto;'  cellpaddig='0' cellspacing='0' border='0' class='access_infotable' width='100%'>";
                    if (response.d != '') {
                        table += "<tr>";
                        var parser = new DOMParser();
                        var xmlDoc = parser.parseFromString(response.d, "text/xml");
                        var xml = $(xmlDoc);
                        var Size = xml.find("Size");
                        var FinishRate = xml.find("FinishRate");
                        var CPP = xml.find("ConvertToPerPcs");
                        var AccessoryQualityId = xml.find("accessory_qualityID");
                        for (var i = 0; i < Size.length; i++) {
                            var Sz = Size[i].innerHTML;
                            if (i == 0) {
                                table += "<th style='background-color: #d8d1d1d4 !important;color: #716f6f !important;font-size: 13px !important;'> Size </th>";
                            }
                            table += "<th style='background-color: #d8d1d1d4 !important;'>" + Sz
                            table += "</th>";
                        }
                        table += "</tr><tr>";
                        for (var j = 0; j < FinishRate.length; j++) {
                            var SRate = FinishRate[j].innerHTML;
                            var Sze = Size[j].innerHTML;
                            var CP = CPP[j].innerHTML;
                            var AccessId = AccessoryQualityId[j].innerHTML;
                            if (j == 0) {
                                table += "<td style='color: #716f6f !important;font-size: 13px !important;'> Rate </td>"
                            }

                            table += "<td><span id='lblSizeRate' style='cursor:pointer;font-family: sans-serif;' class='SizeRate'>" + "₹&nbsp;" + SRate + "</span>"
                            table += "</td>";
                            table += "<td style='display:none;'><span id='lblSize' class='Size'> " + SRate + "</span>"
                            table += "</td>";
                            table += "<td style='display:none;'><span id='lblSize' class='Size'> " + Sze + "</span>"
                            table += "</td>";
                            table += "<td style='display:none;'><span id='lblCPP' class='CPP'> " + CP + "</span>"
                            table += "</td>";
                            table += "<td style='display:none;'><span id='lblCPP' class='CPP'> " + AccessId + "</span>"
                            table += "</td>";
                        }
                        table += "</tr>";
                    }
                    else {
                        table += "<tr align='center'><td><b><span id='lblDate' style='cursor:pointer;' class='NoRecord'>No Result For the Criteria</span></b></td></tr>";
                    }
                    table += "</table>";
                    $("#dvSizeRate").html(table);
                    $("#dvBaseSizeRate").css("display", "block");
                    $(".SizeRate").click(function () {
                         
                        var Rate = $(this).parent().next().find("span").html();
                        var size1 = $(this).parent().next().next().find("span").html();
                        var size = $.trim(size1);
                        var ConvertPerPeice = $(this).parent().next().next().next().find("span").html();
                        var AccessoryQualityId = $(this).parent().next().next().next().next().find("span").html();
                        var ExactRate = parseFloat(Rate) / parseFloat(ConvertPerPeice);
                        var td = $("td", Item.closest("tr"));
                        var valuetxt = $(Item).val();
                        valuetxt += " (" + size + ")"
                        $(Item).val(valuetxt);
                        if ($("[id$=hdnFooterSize]", td) != null) {
                            $("[id$=hdnFooterSize]", td).val(size);
                        }
                        if ($("[id$=hdnSize]", td) != null) {
                            $("[id$=hdnSize]", td).val(size);
                        }
                        if ($("[id$=hdnFooterRate]", td) != null) {
                            $("[id$=hdnFooterRate]", td).val(ExactRate);
                        }
                        if ($("[id$=hdnRate]", td) != null) {
                            $("[id$=hdnRate]", td).val(ExactRate);
                        }
                        if ($("[id$=hdnFooterAccQualityId]", td) != null) {
                            $("[id$=hdnFooterAccQualityId]", td).val(AccessoryQualityId);
                        }
                        if ($("[id$=hdnAccQualityId]", td) != null) {
                            $("[id$=hdnAccQualityId]", td).val(AccessoryQualityId);
                        }
                        $("#dvSizeRate").html("");
                        $("#dvBaseSizeRate").css("display", "none");
                        grdAccessoryOnchange(Item);
                    });

                    $(document).keydown(function (e) {
                        var code = e.keyCode || e.which;
                        if (code == 27) $("#dvBaseSizeRate").hide();
                    });

                    $(".NoRecord").click(function () {
                        // 
                        var td = $("td", Item.closest("tr"));
                        $(Item).val("");
                        if ($("[id$=hdnFooterSize]", td) != null) {
                            $("[id$=hdnFooterSize]", td).val("");
                        }
                        if ($("[id$=hdnSize]", td) != null) {
                            $("[id$=hdnSize]", td).val("");
                        }
                        if ($("[id$=hdnFooterRate]", td) != null) {
                            $("[id$=hdnFooterRate]", td).val("");
                        }
                        if ($("[id$=hdnRate]", td) != null) {
                            $("[id$=hdnRate]", td).val("");
                        }
                        if ($("[id$=hdnFooterAccQualityId]", td) != null) {
                            $("[id$=hdnFooterAccQualityId]", td).val("");
                        }
                        if ($("[id$=hdnAccQualityId]", td) != null) {
                            $("[id$=hdnAccQualityId]", td).val("");
                        }
                        $("#dvSizeRate").html("");
                        $("#dvBaseSizeRate").css("display", "none");
                    });
                }
            });

           
        }
        //end===========================================================

        function grdAccessoryOnchange(elm) {
            
            CheckAccessoryName(elm);
            var td = $("td", Item.closest("tr"));
            var CurrValue = $(elm).val();
            var currId = elm.id;
            if (currId == null) {
                currId = elm[0].id;
            }
            var fields = CurrValue.split('(');
            var AccsName = fields[0].trim();
            var AccesSize = fields[1];
     

            $("#<%= grdAccsessory.ClientID %> [id$=txtAccname]").each(function () {
                // 
                var txtAccname = $(this).find("[id$=txtAccname]");
         
                if (txtAccname.context.id != currId) {
                    if (txtAccname.context.value == CurrValue) {
                        if (AccsName != 'TBD') {
                            $(elm).addClass('borderClass');
                            alert("Entered accsessory name already in list.!");
                            $(elm).val("");
                            return false;
                        }
                    }
                    else {
                        $(this).removeClass('borderClass');
                        $(elm).removeClass('borderClass');
                    }
                }
            });


        }
        function CheckAccessoryName(srcElem) {
            // Sanjeev
//           alert(srcElem.value);
//           
//            var RegisterAccName = srcElem.value;
//            proxy.invoke("Get_RegisterAcc", { RegisterAccName: RegisterAccName }, function (result) {
//                if (result[0].Acc == '0') {                   
//                    $(srcElem).val("");
//                    return;
//                }
//            });
        }
        function checkFab(srcElem) {
            // 
            var rowCount1 = $(this).val(("#" + tblBasicInfoClientID + " tr"));
            //var ss = $(this).find("name").attr("id").val();
            var ControlId = srcElem.id;
            var ControlIdSplitE = ControlId.split('e');
            var ControlIdSplitEValue = ControlIdSplitE[1];
            var ControlIdValue = document.getElementById(ControlId).value;
            FabricQualityOnkeyup(ControlIdValue, ControlIdSplitEValue);
        }
        function FabricQualityOnkeyup(x, y) {
            var s = y;  //- 1;
            var details = "dyed";
            var mode = 1;
            proxy.invoke("GetFabricQualityDetailsByTradeName", { TradeName: x, Details: details, Mode: mode },
                     function (result) {
                         if (result == null || result == '') {
                             //srcTd.find('.div_show').addClass("hide_me");
                             if (s == 0)
                                 document.getElementById(0).innerHTML = "";
                             if (s > 0)
                                 document.getElementById(s).innerHTML = "";
                             return;
                         }
                         if (s == 0) {
                             //document.getElementById(0).innerHTML = "GSM:" + result.GSM + "";


                             if (result.GSM > 0 && result.CountConstruction != '') {
                                 document.getElementById(0).innerText = "CC:" + result.CountConstruction + "  " + "GSM:" + result.GSM + "";
                             }
                             else if (result.GSM > 0) {
                                 document.getElementById(0).innerText = "GSM:" + result.GSM + "";
                             }
                             else if (result.CountConstruction != '') {
                                 document.getElementById(0).innerText = "CC:" + result.CountConstruction + "";
                             }
                             else { document.getElementById(0).innerText = ""; }


                         }
                         if (s > 0)
                         // document.getElementById(s).innerHTML = "GSM:" + result.GSM + "";


                             if (result.GSM > 0 && result.CountConstruction != '') {
                                 document.getElementById(s).innerText = "CC:" + result.CountConstruction + "  " + "GSM:" + result.GSM + "";
                             }
                             else if (result.GSM > 0) {
                                 document.getElementById(s).innerText = "GSM:" + result.GSM + "";
                             }
                             else if (result.CountConstruction != '') {
                                 document.getElementById(s).innerText = "CC:" + result.CountConstruction + "";
                             }
                             else { document.getElementById(s).innerText = ""; }

                     });

        }

        function setMultiplePrint() {
         
            if ($("#txtFabricName1").val() == '') {
                $("#btnNewAddRow").attr("class", "hide_me");
                $("#btnAddRow").attr("class", "show ");
            }
            else {
                $("#btnNewAddRow").attr("class", "show");
                $("#btnAddRow").attr("class", "hide_me");
            }
            //            if ($("#" + hdnStyleIDClientID).val()==null || $("#" + hdnStyleIDClientID).val()==undefined || $("#" + hdnStyleIDClientID).val()==''))
            //            {
            //            $("#btnNewAddRow").attr("class", "hide_me");
            //                $("#btnAddRow").attr("class", "show");
            //
            if (document.getElementById('imgFabHideSpan1') != undefined) {
                document.getElementById('imgFabHideSpan1').style.visibility = "hidden";
            }
            var StyleId = $("#" + hdnStyleIDClientID).val();
            if (StyleId != -1) {
                proxy.invoke("GetStyleByStyleId_Multiple", { StyleID: StyleId },
            function (objStyleFabricCollection) {
                if (objStyleFabricCollection.length != 0) {
              
                    for (var k = 0; k < objStyleFabricCollection.length; k++) {
                        $("#btnNewAddRow").attr("class", "show RowCountTable");
                        $("#btnAddRow").attr("class", "hide_me RowCountTable");

                        var l = k + 1;
                        var objTable = "";

                        if (objStyleFabricCollection[k].FabricName == $("#txtFabricName1").val()) {
                            objTable = "tblFab1";
                        }
                        else if (objStyleFabricCollection[k].FabricName == $("#txtFabricName2").val()) {
                            objTable = "tblFab2";
                        }
                        else if (objStyleFabricCollection[k].FabricName == $("#txtFabricName3").val()) {
                            objTable = "tblFab3";
                        }
                        else if (objStyleFabricCollection[k].FabricName == $("#txtFabricName4").val()) {
                            objTable = "tblFab4";
                        }
                        else if (objStyleFabricCollection[k].FabricName == $("#txtFabricName5").val()) {
                            objTable = "tblFab5";
                        }
                        else if (objStyleFabricCollection[k].FabricName == $("#txtFabricName6").val()) {
                            objTable = "tblFab6";
                        }

                        if (objTable != "") {
                          
                            var rowCount = $("#" + objTable + " tr").length - 1;
                            var row = $("#" + objTable + " tr:last").clone(true).insertAfter($("#" + objTable + " tr:last"));
                            var newLastRow = $("#" + objTable + " tr:last");


                            var rowId = newLastRow.attr("id");
                            var mainRow = rowId.split("_");
                            var newRowIndex = mainRow[1];
                            mainRow[0] = mainRow[0] + '_' + mainRow[1] + '_';
                            if (mainRow[2] != undefined && mainRow[2] != null) {
                                rowCount = parseInt(mainRow[2]);
                            }
                            var newval = parseInt($("#hdntotal" + mainRow[1]).val()) + 1;
                            $("#hdntotal" + mainRow[1]).val(newval);
                            newLastRow.attr("id", mainRow[0] + (rowCount + 1));
                            newLastRow.attr("id")
                            newLastRow.find("input").val("");
                            newLastRow.find("input:first").focus();

                            newLastRow.find("input,select,textarea,span").val("").each(function () {

                                var name = $(this).attr("name");
                                var mainName = name.split("_");
                                name = mainName[0];
                                $(this).attr("name", name + '_' + (rowCount + 1));

                                var id = $(this).attr("id");

                                var mainId = id.split("_");
                                id = mainId[0];
                                $(this).attr("id", id + '_' + (rowCount + 1));
                            });

                            newLastRow.find("img").each(function () {

                                var id = $(this).attr("id");
                                var mainId = id.split("_");
                                id = mainId[0];
                                $(this).attr("id", id + '_' + (rowCount + 1));
                            });

                            newLastRow.show();
                            newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (rowCount + 1)).show();
                            newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (rowCount + 1)).attr("class", "");
                            $('#ddlFabricType' + newRowIndex + '_' + (rowCount + 1)).change(function () {

                                var objRow = $(this).parents("tr");
                                var rowindex = objRow.get(0).rowIndex;
                                onFabricChange1(newRowIndex, rowCount + 1);

                            });
                            $('#ddlFabricType' + newRowIndex + '_' + (rowCount + 1)).val(objStyleFabricCollection[k].FabType);
                            $('#txtRemarks' + newRowIndex + '_' + (rowCount + 1)).val(objStyleFabricCollection[k].Remarks);
                            if (objStyleFabricCollection[k].FabType == 1) {
                                $('#txtPrint' + newRowIndex + '_' + (rowCount + 1)).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                $('#spanPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "");
                                $('#spanOther' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                                $('#spanDgtlPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                            }
                            else if (objStyleFabricCollection[k].FabType == 2) {
                                $('#txtDgtlPrint' + newRowIndex + '_' + (rowCount + 1)).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                $('#spanPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                                $('#spanOther' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                                $('#spanDgtlPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "");
                            }
                            else {
                                $('#txtSpecialFabricDetails' + newRowIndex + '_' + (rowCount + 1)).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                $('#spanOther' + newRowIndex + '_' + (rowCount + 1)).attr("class", "");
                                $('#spanPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                                $('#spanDgtlPrint' + newRowIndex + '_' + (rowCount + 1)).attr("class", "hide_me");
                            }
                            $("#imgFabHideSpan1").attr("class", "hide_me");
                        }
                        setupControls();
                    }
                }

            });
            }

        }

        function setupControls() {
          
      
            $('input.style-fabric', '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredFabricTradeNames", { dataType: "xml", datakey: "string", max: 5000, "width": "750px" });


            $("input.style-fabric", '#main_content').result(function () {

                if ($(this).val().includes('FABRIC QUALITY')) {
                    $(this).val("");
                    return;
                }
                var Str = $(this).val();
                var mys = $(this).val().split('$');
                if (!mys[1]) {
                    //$(this).val("");
                    return;
                }
                var mys2 = mys[1].split('**');
                $(this).val(mys2[0].trim());
             
                var GSM = mys2[1];
                var CountConstruction = mys2[2];
                var CostWidth = mys2[3];
                var DyedRate = mys2[4];
                var PrintRate = mys2[5];
                var DigitalPrintRate = mys2[6];
                var Fabric_Quality_Supplier_Specific = mys2[5];

                var rowCount1 = $(this).val(("#" + tblBasicInfoClientID + " tr"));
                $(this).val(mys2[0].trim());
                var ss = rowCount1.attr("id");
                var a = ss.split('e');
                var s = a[1];
                //onFabricChangeNew(ff, af);

                if (s == 0) {
                    if (GSM > 0 && CountConstruction != '') {
                        document.getElementById(0).innerText = "CC:" + CountConstruction + "  " + "GSM:" + GSM + "";
                    }
                    else if (GSM > 0) {
                        document.getElementById(0).innerText = "GSM:" + GSM + "";
                    }
                    else if (CountConstruction != '') {
                        document.getElementById(0).innerText = "CC:" + CountConstruction + "";
                    }
                    else { document.getElementById(0).innerText = ""; }

                    //  
                    document.getElementById("hdnDyedRate0").value = DyedRate;
                    document.getElementById("hdnPrintRate0").value = PrintRate;
                    document.getElementById("hdnDigitalPrintRate0").value = DigitalPrintRate;
                    document.getElementById("hdnGSM0").value = GSM;
                    document.getElementById("hdnCC0").value = CountConstruction;
                    document.getElementById("hdnCostWidth0").value = CostWidth;
                    document.getElementById("hdnFabricQualityId0").value = Fabric_Quality_Supplier_Specific;

                }
                if (s > 0) {

                    if (GSM > 0 && CountConstruction != '') {
                        document.getElementById(s).innerText = "CC:" + CountConstruction + "  " + "GSM:" + GSM + "";
                    }
                    else if (GSM > 0) {
                        document.getElementById(s).innerText = "GSM:" + GSM + "";
                    }
                    else if (CountConstruction != '') {
                        document.getElementById(s).innerText = "CC:" + CountConstruction + "";
                    }
                    else { document.getElementById(s).innerText = ""; }

                    document.getElementById("hdnDyedRate" + s).value = DyedRate;
                    document.getElementById("hdnPrintRate" + s).value = PrintRate;
                    document.getElementById("hdnDigitalPrintRate" + s).value = DigitalPrintRate;
                    document.getElementById("hdnGSM" + s).value = GSM;
                    document.getElementById("hdnCC" + s).value = CountConstruction;
                    document.getElementById("hdnCostWidth" + s).value = CostWidth;
                    document.getElementById("hdnFabricQualityId" + s).value = Fabric_Quality_Supplier_Specific;
                }

            });

            function onFabricChangeNew(x, y) {
                var s = y;  //- 1;
                var details = "dyed";
                var mode = 1;
                proxy.invoke("GetFabricQualityDetailsByTradeName", { TradeName: x, Details: details, Mode: mode },
                     function (result) {
                         if (result == null || result == '') {
                             srcTd.find('.div_show').addClass("hide_me");
                             return;
                         }
                         if (s == 0) {
                             if (result.GSM > 0 && result.CountConstruction != '') {
                                 document.getElementById(0).innerText = "CC:" + result.CountConstruction + "  " + "GSM:" + result.GSM + "";
                             }
                             else if (result.GSM > 0) {
                                 document.getElementById(0).innerText = "GSM:" + result.GSM + "";
                             }
                             else if (result.CountConstruction != '') {
                                 document.getElementById(0).innerText = "CC:" + result.CountConstruction + "";
                             }
                             else { document.getElementById(0).innerText = ""; }


                             // document.getElementById('ex').innerHTML = "GSM:" + result.GSM + "";
                         }
                         if (s > 0) {
                             // document.getElementById(s).innerHTML = "GSM:" + result.GSM + "";



                             if (result.GSM > 0 && result.CountConstruction != '') {
                                 document.getElementById(s).innerText = "CC:" + result.CountConstruction + "  " + "GSM:" + result.GSM + "";
                             }
                             else if (result.GSM > 0) {
                                 document.getElementById(s).innerText = "GSM:" + result.GSM + "";
                             }
                             else if (result.CountConstruction != '') {
                                 document.getElementById(s).innerText = "CC:" + result.CountConstruction + "";
                             }
                             else { document.getElementById(s).innerText = ""; }
                         }
                     });

            }

            $("input.ScreenPrint", '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestPrintNumbers", { dataType: "xml", datakey: "string", max: 100,
                extraParams: {
                    ClientID: function () {
                
                        $(this).flushCache();
                        return $("#" + BuyerDDClientID).val();
                    },
                    PrintCategory: 1
                }
            });

            $("input.ScreenPrint", "#main_content").result(function () {
                // 
                var p = $(this).val().split('[');
                $(this).val(p[0]);

            });


            $("input.DigitalPrint", '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestPrintNumbers", { dataType: "xml", datakey: "string", max: 100,
                extraParams: {
                    ClientID: function () {
                        //  alert('function');
                        // 
                        $(this).flushCache();
                        return $("#" + BuyerDDClientID).val();
                    },
                    PrintCategory: 2
                }
            });

            $("input.DigitalPrint", "#main_content").result(function () {
                // 
                var p = $(this).val().split(('['));
                $(this).val(p[0]);

            });
            $("input.ColorSolid", '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestPrintNumbers", { dataType: "xml", datakey: "string", max: 100,
                extraParams: {
                    ClientID: function () {
                       
                        $(this).flushCache();
                        return $("#" + BuyerDDClientID).val();
                    },
                    PrintCategory: 3
                }
            });

            $("input.ColorSolid", "#main_content").result(function () {
                // 
                var p = $(this).val().split(('['));
                $(this).val(p[0]);

            });

        }

        function onFabricChange(i) {
        
            var selectedValue = $('#ddlFabricType' + i + '_' + 1, '#main_content').val();
            if (selectedValue == 0) {
                //$('#spanPrint' + i, '#main_content').show();
                $('#spanPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtPrint' + i + '_' + 1, '#main_content').hide;



                $('#spanAdd' + i + '_' + 1, '#main_content').show();
                $('#Img' + i + '_' + 1, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i, '#main_content').hide();
                $('#spanOther' + i + '_' + 1, '#main_content').attr("class", "show_me");
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').show();
                //                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').val("");

                $('#spanDgtlPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').hide();
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').val("");

            }
            else if (selectedValue == 1) {
                //$('#spanPrint' + i, '#main_content').show();
                $('#spanPrint' + i + '_' + 1, '#main_content').attr("class", "show_me");
                $('#txtPrint' + i + '_' + 1, '#main_content').show();



                $('#spanAdd' + i + '_' + 1, '#main_content').show();
                $('#Img' + i + '_' + 1, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i, '#main_content').hide();
                $('#spanOther' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').hide();
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').val("");

                $('#spanDgtlPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').hide();
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').val("");

            }
            else if (selectedValue == 2) {
                //$('#spanPrint' + i, '#main_content').show();
                $('#spanDgtlPrint' + i + '_' + 1, '#main_content').attr("class", "show_me");
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').show();



                $('#spanAdd' + i + '_' + 1, '#main_content').show();
                $('#Img' + i + '_' + 1, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i, '#main_content').hide();
                $('#spanOther' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').hide();
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').val("");

                $('#spanPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtPrint' + i + '_' + 1, '#main_content').hide();
                $('#txtPrint' + i + '_' + 1, '#main_content').val("");

            }
            else {
                //$('#spanPrint' + i, '#main_content').hide();
                $('#spanPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtPrint' + i + '_' + 1, '#main_content').hide();

                $('#txtPrint' + i + '_' + 1, '#main_content').val("");
                //$('#spanOther' + i, '#main_content').show();
                $('#spanOther' + i + '_' + 1, '#main_content').attr("class", "show_me");
                $('#txtSpecialFabricDetails' + i + '_' + 1, '#main_content').show();

                $('#spanDgtlPrint' + i + '_' + 1, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').hide();
                $('#txtDgtlPrint' + i + '_' + 1, '#main_content').val("");
            }
        }

        function onFabricChange1(i, j) {
    
            var selectedValue = $('#ddlFabricType' + i + '_' + j, '#main_content').val();

            if (selectedValue == -1) {
                $('#typee').text('');
                //$('#spanPrint' + i + '_' + j, '#main_content').show();
                $('#txtPrint' + i + '_' + j, '#main_content').hide();
                $('#txtPrint' + i + '_' + j, '#main_content').val("");
                $('#spanPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");

                $('#spanAdd' + i + '_' + j, '#main_content').show();
                $('#Img' + i + '_' + j, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i + '_' + j, '#main_content').hide();
                $('#spanOther' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').hide();
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').val("");

                $('#spanDgtlPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').hide();
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').val("");

            }
            else if (selectedValue == 1) {

                $('#typee').text("Type");
                //$('#spanPrint' + i + '_' + j, '#main_content').show();
                $('#txtPrint' + i + '_' + j, '#main_content').show();
                $('#spanPrint' + i + '_' + j, '#main_content').attr("class", "show_me");

                $('#spanAdd' + i + '_' + j, '#main_content').show();
                $('#Img' + i + '_' + j, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i + '_' + j, '#main_content').hide();
                $('#spanOther' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').hide();
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').val("");

                $('#spanDgtlPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').hide();
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').val("");

            }
            else if (selectedValue == 2) {
                $('#typee').text("Type");

                //$('#spanPrint' + i + '_' + j, '#main_content').show();
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').show();
                $('#spanDgtlPrint' + i + '_' + j, '#main_content').attr("class", "show_me");

                $('#spanPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtPrint' + i + '_' + j, '#main_content').hide();
                $('#txtPrint' + i + '_' + j, '#main_content').val("");

                $('#spanAdd' + i + '_' + j, '#main_content').show();
                $('#Img' + i + '_' + j, '#main_content').attr("style", "visibility:visible");
                //  attr("style", "display:block;color:Black;font-size:smaller;");

                //$('#spanOther' + i + '_' + j, '#main_content').hide();
                $('#spanOther' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').hide();
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').val("");

            }
            else {
                $('#typee').text("Type");

                //$('#spanPrint' + i + '_' + j, '#main_content').hide();
                $('#spanPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtPrint' + i + '_' + j, '#main_content').hide();

                $('#txtPrint' + i + '_' + j, '#main_content').val("");

                $('#spanDgtlPrint' + i + '_' + j, '#main_content').attr("class", "hide_me");
                $('#txtDgtlPrint' + i + '_' + j, '#main_content').hide();

                $('#txtDgtlPrint' + i + '_' + j, '#main_content').val("");

                $('#spanOther' + i + '_' + j, '#main_content').attr("class", "show_me");
                //$('#spanOther' + i + '_' + j, '#main_content').show();
                $('#txtSpecialFabricDetails' + i + '_' + j, '#main_content').show();
            }
        }

        function addRow(objRow) {
     
            var rowCount = $("#" + tblBasicInfoClientID + " tr").length - 1;

            var lastRow = $("#" + tblBasicInfoClientID + " tr:last");

            var row = $("#" + tblBasicInfoClientID + " tr:last").clone(true).insertAfter($("#" + tblBasicInfoClientID + " tr:last"));

            var newLastRow = $("#" + tblBasicInfoClientID + " tr:last");

            newLastRow.find("input").val("");
            newLastRow.find("input:first").focus();
            newLastRow.find("#txtStyleFabID" + rowCount).val("-1");
            newLastRow.find("#txtIsDeleted" + rowCount).val("0");



            newLastRow.find("#ex").html("");

            var id1 = newLastRow.find("label").attr("id");  //y             
            var ss11 = newLastRow.find("label").attr("id", rowCount);  //

            //   newLastRow.find("label").innerText = "";
            document.getElementById(rowCount).innerHTML = "";





            newLastRow.find("input,select,textarea,span").val("").each(function () {

                var name = $(this).attr("name");
                name = name.replace(/[0-9]*/g, '');
                $(this).attr("name", name + (rowCount + 1));

                var id = $(this).attr("id");
                id = id.replace(/[0-9]*/g, '');
                $(this).attr("id", id + (rowCount + 1));

            });
            for (var i = 1; i <= rowCount; i++) {

            }
            newLastRow.show();
            newLastRow.find("#btnDeleteRow").show();

            $('#ddlFabricType' + (rowCount + 1)).change(function () {

                var objRow = $(this).parents("tr");
                var rowindex = objRow.get(0).rowIndex;

                onFabricChange(rowindex);

            });

            setupControls();

        }

        function addRow_new(srcElem) {
    
            var objRow = $(srcElem).parents("tr");
            var objTable = $(objRow).parents("table").attr("id");

            var row = $("#" + objTable + " tr:last").clone(true).insertAfter($("#" + objTable + " tr:last"));
            var newLastRow = $("#" + objTable + " tr:last");
            var newLastRowId = newLastRow.attr("id").split('_');
            var IdNo = parseInt(newLastRowId[2]);
            var mainRow = newLastRowId[0] + '_' + newLastRowId[1] + '_';
            var newRowIndex = newLastRowId[1];

            var newval = parseInt($("#hdntotal" + newRowIndex).val()) + 1;
            $("#hdntotal" + newRowIndex).val(newval);
            newLastRow.attr("id", mainRow + (IdNo + 1));
            newLastRow.find("input").val("");
            newLastRow.find("input:first").focus();

            newLastRow.find("input,select,textarea,span").val("").each(function () {

                var id = $(this).attr("id");
                var name = "";
                var mainId = id.split("_");
                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                id = mainId[0] + newRowIndex;
                $(this).attr("id", id + '_' + (IdNo + 1));
                name = id + '_' + (IdNo + 1);
                $(this).attr("name", name);

            });

            newLastRow.find("img").each(function () {

                var id = $(this).attr("id");
                var mainId = id.split("_");
                id = mainId[0];
                $(this).attr("id", id + '_' + (IdNo + 1));
            });

            newLastRow.show();
            newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (IdNo + 1)).show();
            newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (IdNo + 1)).attr("class", "");
            $('#ddlFabricType' + newRowIndex + '_' + (IdNo + 1)).change(function () {

                var objRow = $(this).parents("tr");
                var rowindex = objRow.get(0).rowIndex;
                onFabricChange1(newRowIndex, IdNo + 1);

            });

            setupControls();

        }

        function createNewRow() {
     
            var newRowCountTemp = 0;
            for (var i = 1; i <= 6; i++) {

                if ($("#trFab" + i).attr("id") == undefined && newRowCountTemp == 0) {

                    newRowCountTemp = i;
                }
            }
            if (newRowCountTemp == 6) {
                $("#btnNewAddRow").attr("class", "hide_me");
                $("#divAddRow").hide();
            }
            if (newRowCountTemp == 0) {
                $("#btnNewAddRow").attr("class", "hide_me");
                $("#divAddRow").hide();
            }
            else {
                //  
                var feb = newRowCountTemp - 1;
                $("#btnNewAddRow").attr("class", "show");
                $("#btnNewAddRow").show();

                var oldlastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:last");

                var fabric = $(oldlastRow).find("[id$=txtFabricName" + feb + "]").val();
                if (fabric != "") {
                    var oldFirstRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab0").filter("tr:eq(" + 0 + ")");
                    oldFirstRow.find("input.style-fabric").attr("id", "txtFabricName0");
                    oldFirstRow.find("input.style-fabric").attr("name", "txtFabricName0");
                    var originalclass = oldFirstRow.attr("class");
                    oldFirstRow.attr("class", "tblFab1 RowCountTable");

                    var row = oldFirstRow.clone(true).insertAfter(oldlastRow);
                    var newLastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:last");
                    oldFirstRow.attr("class", originalclass);
                    newLastRow.attr("id", "trFab" + newRowCountTemp);
                    newLastRow.attr("name", "trFab" + newRowCountTemp);
                    newLastRow.attr("class", "tblFab1 RowCountTable");
                    newLastRow.find("input").val("");
                    newLastRow.find("input:first").focus();
                    var newRowId = newLastRow.attr("id");
                    newLastRow.find("#ex").html("");
                    var newRowIDTemp = newRowCountTemp;

                    var id1 = newLastRow.find("label").attr("id");  //y
                    var ss11 = newLastRow.find("label").attr("id", newRowIDTemp);  //

                    document.getElementById(newRowIDTemp).innerHTML = "";

                    var lastNam = "";
                    newLastRow.find("input,select,textarea,span").val("").each(function () {


                        var id = $(this).attr("id");

                        var name;
                        var mainId = id.split("_");
                        if (mainId.length == 1) {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id);
                            name = id;
                        }
                        else {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id + '_' + mainId[1]);
                            name = id + '_' + mainId[1];
                        }
                        $(this).attr("name", name);
                    });
                    newLastRow.find("img").each(function () {

                        var id = $(this).attr("id");
                        var mainId = id.split("_");

                        if (mainId.length == 1) {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id);
                        }
                        else {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id + '_' + mainId[1]);
                        }

                    });

                    newLastRow.find("table").each(function () {
                        var id = $(this).attr("id");
                        var mainId = id.split("_");
                        if (mainId.length == 1) {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id);
                        }
                        else {
                            mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                            id = mainId[0] + newRowIDTemp;
                            $(this).attr("id", id + '_' + mainId[1]);
                        }
                    });

                    newLastRow.find("tr").each(function () {
                        var id = $(this).attr("id");
                        if (id != null && id != undefined && id != "") {
                            var mainId = id.split("_");


                            if (mainId.length == 1) {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id);
                            }
                            else if (mainId.length == 2) {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id + '_' + mainId[1]);
                            }
                            else {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + "_" + newRowIDTemp;
                                $(this).attr("id", id + '_' + mainId[2]);
                            }
                        }
                    });

                    newLastRow.show();

                    //newLastRow.find("#imgFabHide" + newRowIDTemp).click(function() { deleteRow(newRowIDTemp); })
                    newLastRow.find("#imgFabHide" + newRowIDTemp).attr("click", "deleteRowNew(" + newRowIDTemp + ")");
                    newLastRow.find("#txtStyleFabID" + newRowIDTemp).val("-1");
                    newLastRow.find("#txtIsDeleted" + newRowIDTemp).val("0");
                    newLastRow.find("#hdntotal" + newRowIDTemp).val("1");
                    if (newRowIDTemp > 1) {
                        newLastRow.find("#imgFabHideSpan" + newRowIDTemp).show();
                        newLastRow.find("#imgFabHideSpan" + newRowIDTemp).attr("style", "visibility: visible;");
                    }
                    newLastRow.find("#btnDeleteRow" + newRowIDTemp + '_' + 1).hide();
                    newLastRow.find("#btnDeleteRow" + newRowIDTemp + '_' + 1).attr("class", "");
                    $('#ddlFabricType' + newRowIDTemp + '_' + 1).change(function () {

                        var objRow = $(this).parents("tr");
                        var rowindex = objRow.get(0).rowIndex;
                        onFabricChange1(newRowIDTemp, 1);
                    });

                    setupControls();
                }

            }
            if (1 == 2) {
                // 
                for (var i = 1; i <= 6; i++) {
                    if (i >= 4) {
                        //$("#btnNewAddRow").attr("class", "hide_me");
                        $("#divAddRow").hide();
                    }
                    newRowCount = i - 1;
                    var lastRowTemp = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:eq(" + newRowCount + ")");

                    if (lastRowTemp.attr("id") == undefined || lastRowTemp.attr("id") == null) {
                        if (newRowCountTemp > 0) {
                            newRowIDTemp = newRowCountTemp;
                            newRowCount = newRowIDTemp - 1;
                        }
                        else {
                            newRowIDTemp = i;
                            newRowCount = newRowIDTemp - 1;
                        }
                        var lastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:eq('#trFab" + newRowCount + "')");
                        var rowId = lastRow.attr("id");
                        var count = newRowCount - 1;

                        var oldlastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:eq(" + count + ")");

                        var oldFirstRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab0").filter("tr:eq(" + 0 + ")");
                        oldFirstRow.find("input.style-fabric").attr("id", "txtFabricName0");
                        oldFirstRow.find("input.style-fabric").attr("name", "txtFabricName0");
                        var originalclass = oldFirstRow.attr("class");
                        oldFirstRow.attr("class", "tblFab1");

                        if (newRowCountTemp == 0) {
                            var row = oldFirstRow.clone(true).insertAfter(oldlastRow);
                            var newLastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:last");
                        }
                        else {
                            var newLastRow = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").filter("tr:eq('#trFab" + newRowIDTemp + "')");
                        }
                        var rowCount = $("#" + tblBasicInfoClientID + " tr").filter("tr.tblFab1").length;
                        oldFirstRow.attr("class", originalclass);

                        newLastRow.attr("id", "trFab" + newRowIDTemp);
                        newLastRow.attr("name", "trFab" + newRowIDTemp);
                        newLastRow.attr("class", "tblFab1");
                        newLastRow.find("input").val("");
                        newLastRow.find("input:first").focus();
                        var newRowId = newLastRow.attr("id");

                        newLastRow.find("#ex").html("");

                        var id1 = newLastRow.find("label").attr("id");  //y
                        var ss11 = newLastRow.find("label").attr("id", newRowIDTemp);  //

                        document.getElementById(newRowIDTemp).innerHTML = "";

                        var lastNam = "";
                        newLastRow.find("input,select,textarea,span").val("").each(function () {

                            if ($(this).attr("name") == undefined) {
                                $(this).attr("name", $(this).attr("id"));
                            }
                            var name = $(this).attr("name");
                            var mainName = name.split("_");

                            if (mainName.length == 1) {
                                mainName[0] = mainName[0].replace(/[0-9]*/g, '');
                                name = mainName[0] + newRowIDTemp;
                                $(this).attr("name", name);
                            }
                            else {
                                mainName[0] = mainName[0].replace(/[0-9]*/g, '');
                                name = mainName[0] + newRowIDTemp;
                                $(this).attr("name", name + '_' + mainName[1]);
                            }

                            var id = $(this).attr("id");

                            var mainId = id.split("_");
                            if (mainId.length == 1) {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id);
                            }
                            else {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id + '_' + mainId[1]);
                            }
                        });

                        newLastRow.find("img").each(function () {

                            var id = $(this).attr("id");
                            var mainId = id.split("_");

                            if (mainId.length == 1) {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id);
                            }
                            else {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id + '_' + mainId[1]);
                            }

                        });

                        newLastRow.find("table").each(function () {

                            var id = $(this).attr("id");
                            var mainId = id.split("_");
                            if (mainId.length == 1) {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id);
                            }
                            else {
                                mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                id = mainId[0] + newRowIDTemp;
                                $(this).attr("id", id + '_' + mainId[1]);
                            }
                        });

                        newLastRow.find("tr").each(function () {
                            var id = $(this).attr("id");
                            if (id != null && id != undefined && id != "") {
                                var mainId = id.split("_");


                                if (mainId.length == 1) {
                                    mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                    id = mainId[0] + newRowIDTemp;
                                    $(this).attr("id", id);
                                }
                                else if (mainId.length == 2) {
                                    mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                    id = mainId[0] + newRowIDTemp;
                                    $(this).attr("id", id + '_' + mainId[1]);
                                }
                                else {
                                    mainId[0] = mainId[0].replace(/[0-9]*/g, '');
                                    id = mainId[0] + "_" + newRowIDTemp;
                                    $(this).attr("id", id + '_' + mainId[2]);
                                }
                            }
                        });

                        newLastRow.show();

                        newLastRow.find("#imgFabHide" + newRowIDTemp).click(function () { hideRow(newRowIDTemp); })
                        newLastRow.find("#txtStyleFabID" + newRowIDTemp).val("-1");
                        newLastRow.find("#txtIsDeleted" + newRowIDTemp).val("0");
                        newLastRow.find("#hdntotal" + newRowIDTemp).val("1");

                        newLastRow.find("#btnDeleteRow" + newRowIDTemp + '_' + 1).hide();
                        newLastRow.find("#btnDeleteRow" + newRowIDTemp + '_' + 1).attr("class", "");
                        $('#ddlFabricType' + newRowIDTemp + '_' + 1).change(function () {

                            var objRow = $(this).parents("tr");
                            var rowindex = objRow.get(0).rowIndex;
                            onFabricChange1(newRowIDTemp, 1);
                        });

                        setupControls();
                        break;
                    }
                }
            }
        }

        function setparentname() {
        }
        function setDeptName() {
            selectedDept = $("#" + DeptDDClientID + " option:selected").text();
            $("#" + hdnDeptNameClientID).val(selectedDept);
            populateAccMgr($("#" + DeptDDClientID + " option:selected").val());
            populateSamplingMerch($("#" + DeptDDClientID + " option:selected").val());
        }

        function setSeasonName() {

            selectedSeason = $("#" + SeasonDDClientID).val();
            $("#" + hdnSeasonIDClientID).val(selectedSeason);
            //$("#" + hdnSeasonIDClientID).val(selectedSeason);
        }

        function deleteRow(srcElem) {
            var objRow = $('#trFab' + srcElem); //  $(srcElem).parents("tr");
            $("#divAddRow").show(); // this code added by bharat 22-may  
            objRow.remove();
            $("#btnNewAddRow").attr("class", "show");
            $("#btnNewAddRow").show();
        }
        function deleteRowNew(srcElem) {
            var objRow = $('#trFab' + srcElem);
            objRow.remove();
            $("#btnNewAddRow").attr("class", "show");
            $("#btnNewAddRow").show();
        }
        function deleteRowFinal(srcElem) {
            var objRow1 = $(srcElem).parents("tr");
            var id = objRow1.attr("id");
            var objRow = $('#' + id);
            objRow.remove();
            $("#btnNewAddRow").attr("class", "show");
            $("#btnNewAddRow").show();
            $("#divAddRow").attr("class", "show");
            $("#divAddRow").show();
        }
        function deleteRow_new(srcElem) {
            var objRow = $(srcElem).parents("tr");
            var rowindex = objRow.get(0).rowIndex;
            var objTable = objRow.parents("table").attr("id");
            var row = $("#" + objTable).find("tr").filter("tr:eq(" + rowindex + ")");
            var mainRow = row.attr("id").split('_');
            var newval = parseInt($("#hdntotal" + mainRow[1]).val()) - 1;
            $("#hdntotal" + mainRow[1]).val(newval);
            row.remove();

        }

        //Changed by surendra2 on 24-10-2018.
        function populateParentDepartments(clientId, selectedDeptID, ParentDeptId, type) {
            var UserID = parseInt($("#" + hdnuseridClientID).val());
            bindDropdown(serviceUrl, ParentDeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, setparentname)
            if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
                jscriptPageVariables.selectedDeptID = '';
        }


        function populateDepartments(clientId, selectedDeptID, ParentDeptId, type) {
            var UserID = parseInt($("#" + hdnuseridClientID).val());
            bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, setDeptName)
            if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
                jscriptPageVariables.selectedDeptID = '';
        }

        function populateBuyingHouse(divisionID) {

            bindDropdown(serviceUrl, BuyingHouseDDClientID, "BindBuyingHouseProxy", { DivisionID: divisionID }, "BuyingHouseName", "BuyingHouseId", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, '')
            //$("#" + BuyerHdnClientID).val($("#" + BuyerDDClientID).val());
        }

        function populateClients(buyingHouseID) {

            bindDropdown(serviceUrl, BuyerDDClientID, "BindClientsDesignProxy", { BuyingHouseID: buyingHouseID }, "CompanyName", "ClientID", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, '')
            $("#" + BuyerHdnClientID).val($("#" + BuyerDDClientID).val());
        }

        function populateSeason(clientId) {
            //  
            // bindDropdownSeason(serviceUrl, SeasonDDClientID, "GetSeasonByClient", { ClientID: clientId }, "FinalSeason", "Id", "Isdefault", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, setSeasonName)

            var styleid = document.getElementById('<%=srvrHdnSeasonName.ClientID%>').value;
            if (styleid == "")
                styleid = "0";
            bindDropdownSeason(serviceUrl, SeasonDDClientID, "GetSeasonByClient", { ClientID: clientId, StyleID: styleid }, "SeasonName", "SeasonID", "IsDefault", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : '', onPageError, setSeasonName)
        }

        function populateAccMgr(departmentId) {

            if (departmentId != '' && departmentId != '-1')
                bindDropdown(serviceUrl, AccMgrClientID, "GetClientAccMgrByClientID", { DepartmentId: departmentId }, "FullName", "UserID", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedAccManagerID : '', onPageError, null)
            //            if (jscriptPageVariables != null && jscriptPageVariables.selectedAccManagerID != null && jscriptPageVariables.selectedAccManagerID != '')
            //                jscriptPageVariables.selectedAccManagerID = '';
        }

        function populateSamplingMerch(departmentId) {

            //accountManagerID = $("#" + AccMgrClientID).val();
            if (departmentId != '' && departmentId != '-1')
                bindDropdown(serviceUrl, ddlSamplingClientID, "GetSamplingMerchandiserByDeptID", { DepartmentId: departmentId }, "FullName", "UserID", false, '', onPageError)
        }

        function onCompanyChange() {
            // 
            var selectedValue = $("#" + BuyerDDClientID, '#main_content').val();
            if (selectedValue == '-1') return;
            window.returnValue = selectedValue;
            populateParentDepartments(selectedValue, -1, -1, 'Parent');
            populateSeason(selectedValue);
            //        try {
            //            
            //            var ddlseason = document.getElementById(SeasonDDClientID);
            //            if (ddlseason.options.length > 0)
            //                ddlseason.selectedIndex = 1;
            //        } catch (e) {
     
            //        }
            $("#" + BuyerHdnClientID, '#main_content').val(selectedValue);
        }
        function onPageError(error) {
            alert(error.Message + ' -- ' + error.detail);
        }

        function onStyleNumberChange(styleNumber) {
       
            proxy.invoke("GetStyleByNumber", { StyleNumber: styleNumber },
        function (result) {
            var styleid;

            if (result != null)
                styleid = result.StyleID;


            if (styleid != null && parseInt(styleid) > 0) {
                window.location = "/Internal/Design/DesignerEdit.aspx?styleid=" + styleid;
                return;
            }
            //// 
            if (($("#" + hdnStyleIDClientID, '#main_content').val()) == "-1") {
                $("#" + btnSaveAsClientID, '#main_content').hide();

            }
            else {
                $("#" + btnSaveAsClientID, '#main_content').show();
                $("#" + rdobtnClientID, '#main_content').find("input,span").removeAttr('disabled');
            }

        });

        }

        function SearchStyleNumber() {

            var styleNumber = $.trim($("#" + txtStyleNoClientID).val());
            var userID = parseInt($("#" + hdnuseridClientID).val());
            if (styleNumber == '' || styleNumber.length < 8) {
                jQuery.facebox('<b>Style Number is invalid!</b>');
                return;
            }
            proxy.invoke("GetStyleByNumber", { StyleNumber: styleNumber },
            //proxy.invoke("GetStyleByNumberUserSpacific", { StyleNumber: styleNumber, userid: userID },
        function (result) {

            var styleid;

            if (result != null)
                styleid = result.StyleID;

            if (styleid != null && parseInt(styleid) > 0)
                window.location = "/Internal/Design/DesignerEdit.aspx?styleid=" + styleid;
            //            else
            //                jQuery.facebox('<b>Permission is required.</b> <br/> <center>OR</center><b>Style Number is invalid!</b> ');

        });
        }

        function validateSamplingMerchant(source, arguments) {
            var objSamplingMerchant = '<%=ddlSampling.ClientID%>';
            var SamplingMerchant = $("#" + objSamplingMerchant).val();

            var value = false;
            if (SamplingMerchant > 0) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }


        }

        function IsFileUploaded(source, arguments) {
            //// 

            var objFile = $(source).parents("TD").find("input[type=file]");

            if (objFile.val().length == 0)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }
        function showRow(elem) {
            //
            // 
            var k;
            for (var i = 2; i <= 6; i++) {

                k = i - 1;
                var fabric = $("#trFab" + k).find("[id$=txtFabricName" + k + "]").val();
                var Remark = $("#txtRemarks" + k + "_" + 1).val();

                if (fabric != "") {
                    // this code added by bhrat 21-may
                    //                    if (fabric == "TBD") {
                    //                        if (Remark == '') {
                    //                            alert("Fabric TBD Remark Mandatory");
                    //                            break;
                    //                        }
                    //                        //end
                    //                    }
                    if (i == 6) {
                        $("#divAddRow").hide();

                    }
                    var row = $("#trFab" + i);
                    if (row.attr("class") == "show RowCountTable")
                    { }
                    else {
                        row.attr("class", "show RowCountTable");
                        $("#txtIsDeleted" + i).val("0");
                        break;
                    }
                }
            }
        }
        function hideRow(i) {
            // debugger
            var row = $("#trFab" + i);

            row.attr("class", "hide_me RowCountTable");
            var element = row.find("#txtIsDeleted" + i);
            element.val("1");
            $("#divAddRow").show();
            row.find("input.style-fabric,label,select,textarea,span").val("");
        }
        //Yaten : Check duplicate Fabric Name 20 Apr
        function CheckFabricName(srcElem) {
            // 
            //  var l;
            //  var s = 0;
            // var FabricArray = new Array();
            var FabType;
            var TempId = srcElem.id;
            //var thisId = TempId.split('')[5];
            var lengthrow = srcElem.length
            var thisId = TempId.slice(-1);
            var RegisterFabricName = srcElem.value.toLowerCase();

            var RowCount = $('.CountTableRow tr.RowCountTable').length;

           
            proxy.invoke("Get_RegisterFabric_Design", { RegisterFabricName: RegisterFabricName }, function (result) {
                if (result[0].Acc == '0') {
                    document.getElementById(TempId).value = "";
                    return;
                }
            });

            //  code Comment by bharat on 5-Oct-20 
            //            for (var i = 1; i <= 6; i++) {

            //                if (document.getElementById("txtFabricName" + i) != undefined) {
            //                    var s = s + 1;
            //                    l = FabricArray.length;
            //                    if (document.getElementById("txtFabricName" + i).value.replace(/^\s+|\s+$/g, '') == "")
            //                    { FabricArray[l] = i }
            //                    else
            //                        FabricArray[l] = document.getElementById("txtFabricName" + i).value.replace(/^\s+|\s+$/g, '');
            //                }

            //            }
            //  FabricArray.sort();
            //End
            // Add code added by bharat on 5-Oct-20 
            var ddlFabricTypeVal
            if (thisId == thisId) {
                ddlFabricTypeVal = $("#ddlFabricType" + thisId + "_1 option:selected").val();
                if (ddlFabricTypeVal == "0") {
                    FabType = $("#txtSpecialFabricDetails" + thisId + "_1").val().toLowerCase();
                }
                if (ddlFabricTypeVal == "1") {
                    FabType = $("#txtPrint" + thisId + "_1").val().toLowerCase();
                }
                if (ddlFabricTypeVal == "2") {
                    FabType = $("#txtDgtlPrint" + thisId + "_1").val().toLowerCase();
                }
            }
            for (var k = 1; k <= RowCount; k++) {
                if (thisId != k) {
                    var ddlFabricType = $("#ddlFabricType" + k + "_1 option:selected").val();
                    var txtFabricName = $("#txtFabricName" + k).val().toLowerCase();
                    if (txtFabricName.toUpperCase() == RegisterFabricName.toUpperCase()) {
                        var FabTypeval;
                        if (ddlFabricType == "0") {
                            FabTypeval = $("#txtSpecialFabricDetails" + k + "_1").val().toLowerCase();
                        }
                        if (ddlFabricType == "1") {
                            FabTypeval = $("#txtPrint" + k + "_1").val().toLowerCase();
                        }
                        if (ddlFabricType == "2") {
                            FabTypeval = $("#txtDgtlPrint" + k + "_1").val().toLowerCase();
                        }
                        if (typeof (FabType) != "undefined") {
                            if (FabType != "") {
                                if (FabTypeval == FabType) {
                                    if (ddlFabricType == ddlFabricTypeVal) {
                                        document.getElementById(TempId).value = "";
                                        document.getElementById(TempId).focus();
                                        alert('Duplicate Fabric Found. ');
                                        if (ddlFabricTypeVal == "0") {
                                            FabTypeval = $("#txtSpecialFabricDetails" + thisId + "_1").val('');
                                        }
                                        if (ddlFabricTypeVal == "1") {
                                            FabTypeval = $("#txtPrint" + thisId + "_1").val('');
                                        }
                                        if (ddlFabricTypeVal == "2") {
                                            FabTypeval = $("#txtDgtlPrint" + thisId + "_1").val('');
                                        }
                                    }
                                    break;

                                    //end
                                }
                            }
                        }
                    }
                }
            }
            //End
            // this code added by bharat on 10-june 
            // this code header not select in autopopulate
            $('.fabricheader').parent().addClass('FabricHeaferDisable');
            $('.FabricHeaferDisable').click(function () {
                return false;
            });
            //end

        }

        //create function for check file format by Surendra2 on 21-03-2018.
        function Validate() {
            //// 
            var _validFileExtensions = [".jpg", ".jpeg", ".png"];
            var arrInputs = $("#" + upSketchClientID, '#main_content').val();
            var img = $("#" + imgSketchClientID, '#main_content').attr('src');
            if (typeof img != 'undefined' && img != "") {
                return true;
            }
            var sFileName = arrInputs;
            var filename = sFileName.split("\\");
            if (sFileName.length > 0) {
                var blnValid = false;
                for (var j = 0; j < _validFileExtensions.length; j++) {
                    var sCurExtension = _validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert("Sorry, The file name '" + filename[filename.length - 1] + "' is invalid, allowed format are: JPEG and PNG only.");
                    return false;
                }
            }
            else {
                alert("Please Upload file for Style Sketch!");
                return false;
            }




            return true;
        }

        // Yaten : Check Blank Print Solid Validation 20 Apr
        function CheckBlankPrintSolid(srcEle) {
            //  
            //   var tt = document.getElementById(id).value;
            //var ddSales = $("#" + ddSales1ClientID);
            debugger;

            var txtstyle = $("#ctl00_cph_main_content_DesignerForm1_txtStyle").val();
            if (txtstyle == "") {
                alert("Please provide Style Initials");
                $("#ctl00_cph_main_content_DesignerForm1_txtStyle").focus();
                return false;
            
            }
            var t1 = Page_ClientValidate("Submit");
            var count = 0;

            if (!t1) {
                count = 1;
                alert("Please enter values for mandatory(*) field");
                return false;
            }

            if (!Validate()) {
                return false;
            }
              
            var l;
            var FabricSum = 0;
            var FabricArray = new Array();
            //var k;
            for (var i = 1; i <= 6; i++) {
                if ($("#trFab" + i).attr("class") != "hide_me") {
                    FabricSum = FabricSum + 1;
                    var CurrentTableId = "tblInner_" + i + "_1";
                    var RowId = $("#" + CurrentTableId + " tr:last").attr("id");

                    //this code added by bharat 31-may
                    //this code worked on edit case
                    var fabric = $("#trFab" + i).find("[id$=txtFabricName" + i + "]").val();
                    var faRemark = $("#txtRemarks" + i + "_" + 1).val();
                    if (fabric == "TBD") {
                        if (faRemark == "") {
                            alert("Fabric TBD Remark Mandatory");
                            return false;
                        }
                    }
                    //end

                    if (RowId != undefined) {
                        var totalRows = RowId.split("_");
                        for (var u = 1; u <= totalRows[2]; u++) {
                            if (document.getElementById("ddlFabricType" + i + "_" + u) != undefined) {
                                var type = document.getElementById("ddlFabricType" + i + "_" + u).value;
                                var fabric = "txtFabricName" + i;
                                if (document.getElementById(fabric) != undefined && document.getElementById(fabric).value != "" && type == -1) {
                                    alert('Please select Print/Solid details for given fabric');
                                    return false;
                                }

                                //this code added by bharat 21-may
                                if (document.getElementById(fabric).value == "TBD") {
                                    var txtRemarks = document.getElementById("txtRemarks" + i + "_" + u).value;

                                    if (txtRemarks == "") {
                                        alert("Fabric TBD Remark Mandatory");
                                        return false;
                                    }

                                }
                                //end
                                if (type == 1) {
                                    var printId = "txtPrint" + i + "_" + u;
                                    if (document.getElementById(printId) != undefined) {
                                        if (document.getElementById(printId).value == "") {
                                            alert('Blank Print found at Fabric :' + FabricSum);
                                            return false;
                                        }
                                    }
                                }
                                if (type == 0) {
                                    var SolidId = "txtSpecialFabricDetails" + i + "_" + u;
                                    if (document.getElementById(SolidId) != undefined) {
                                        if (document.getElementById(SolidId).value == "") {
                                            alert('Blank Solid found at Fabric :' + FabricSum);
                                            return false;
                                        }
                                    }
                                }

                                if (type == 2) {
                                    var DgtlPrintId = "txtDgtlPrint" + i + "_" + u;
                                    if (document.getElementById(DgtlPrintId) != undefined) {
                                        if (document.getElementById(DgtlPrintId).value == "") {
                                            alert('Blank Special found at Fabric :' + FabricSum);
                                            return false;
                                        }
                                    }
                                }

                            }
                        } //End for
                    }
                }
            }


             
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;
            var row;
            for (row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;
                var CurrName = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtAccname" + "']").val();
                var AccssRemack = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtRemarks" + "']").val();

                if (CurrName != "") {
                    var Afields = CurrName.split('(');
                    var AccsName = Afields[0].trim();
                    var AccesSize = Afields[1];
                }

                if (AccsName == "TBD") {
                    if (AccssRemack == "" || AccssRemack == null) {
                        alert("Accessory TBD Remark Mandatory");
                        return false;
                    }
                }
            }
             
            if (GridRow == 0) {
                var FoGridRow = parseInt(GridRow) + 3;
                if (FoGridRow < 10)
                    gvId = 'ctl0' + FoGridRow;
                else
                    gvId = 'ctl' + FoGridRow;

                var FAccssRemack = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtfoterRemarks" + "']").val();
                var foterAccname = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtfoterAccname" + "']").val();
                if (foterAccname != '') {
                    var Fofields = foterAccname.split('(');
                    var FoAccsName = Fofields[0].trim();
                    var FoAccesSize = Fofields[1];
                }

                if (FoAccsName == "TBD") {
                    if (FAccssRemack == "" || FAccssRemack == null) {
                        alert("Accessory TBD Remark Mandatory");
                        return false;
                    }
                }
            }
            if (GridRow >= 1) {
                var FoGridRow = parseInt(GridRow) + 2;
                if (FoGridRow < 10)
                    gvId = 'ctl0' + FoGridRow;
                else
                    gvId = 'ctl' + FoGridRow;

                var FAccssRemack = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtfoterRemarks" + "']").val();
                var foterAccname = $("#<%= grdAccsessory.ClientID %> input[id*='" + gvId + "_txtfoterAccname" + "']").val();
                if (foterAccname != '') {
                    var Fofields = foterAccname.split('(');
                    var FoAccsName = Fofields[0].trim();
                    var FoAccesSize = Fofields[1];
                }

                if (FoAccsName == "TBD") {
                    if (FAccssRemack == "" || FAccssRemack == null) {
                        alert("Accessory TBD Remark Mandatory");
                        return false;
                    }
                }
            }
            return true;
        }




        function GetSeasonName() {
        
            var temp = $("#" + SeasonDDClientID + " option:selected").text();
            // alert(temp);
            document.getElementById('hdnSeasonName').value = temp;
            var jasdf = document.getElementById('hdnSeasonName').value;

            //   alert(jasdf);
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
            }

            if (Page_IsValid) {
                // do something
                return true;
            }
            else {
                // do something else
                return false;
            }
        }


        //Yaten : Add function to Check Duplicate FabricDetails. 19 Apr
        function CheckDuplicateFabricDetails(srcElem) {
            
            var RegisterPrint = srcElem.value.toLowerCase();
            //            var CurrentTableId = $(srcElem).parents("table").attr("id");
            //            var TableId = CurrentTableId.split("_");
            //            var tblID = TableId[1];
            //            var rowCount = $("#" + CurrentTableId + " tr").length;
            //            var LastRowId = $("#" + CurrentTableId + " tr:last").attr("id");
            //            var LastNo = LastRowId.split("_");
            //            var ControlId = srcElem.id;
            //            var aa = ControlId.split("_");
            //            var PrintArray = new Array();
            //            var SolidArray = new Array();
            //            var SpecialArray = new Array();
            //            var temp = 0;

            var TempId = srcElem.id;
            var spiltid = TempId.split("_")[0]
            var thisId = spiltid.slice(-1);
            var RowCount = $('.CountTableRow tr.RowCountTable').length;
            var FabName;
            var ddlFabricTypeVal;
            if (thisId == thisId) {
                ddlFabricTypeVal = $("#ddlFabricType" + thisId + "_1 option:selected").val();
                if (ddlFabricTypeVal == "0") {
                    // proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
                    var valPrintNu = $("#txtSpecialFabricDetails" + thisId + "_1").val();
                
                    if (valPrintNu == 'PrintNumber') {
                            $("#txtSpecialFabricDetails" + thisId + "_1").val('');
                            return;
                        }
                   // });
                  //  FabType = $("#txtSpecialFabricDetails" + thisId + "_1").val().toLowerCase();
                }
                if (ddlFabricTypeVal == "1") {
                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
                        if (result[0].Acc == '0') {
                            $("#txtPrint" + thisId + "_1").val('');
                            return;
                        }
                    });

                }
                if (ddlFabricTypeVal == "2") {

                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
                        if (result[0].Acc == '0') {
                            $("#txtDgtlPrint" + thisId + "_1").val('');
                            return;
                        }
                    });
                }
                FabName = $("#txtFabricName" + thisId).val().toLowerCase();
            }

            for (var i = 1; i <= RowCount; i++) {
                if (thisId != i) {
                    var ddlFabricType = $("#ddlFabricType" + i + "_1 option:selected").val();
                    if (ddlFabricType == "0") {

                        RagisterFabPrint = $("#txtSpecialFabricDetails" + i + "_1").val().toLowerCase();
                    }
                    if (ddlFabricType == "1") {

                        RagisterFabPrint = $("#txtPrint" + i + "_1").val().toLowerCase();
                    }
                    if (ddlFabricType == "2") {
                        RagisterFabPrint = $("#txtDgtlPrint" + i + "_1").val().toLowerCase();
                    }

                    if (RegisterPrint != "") {
                        if (RegisterPrint == RagisterFabPrint) {
                            var txtFabricName = $("#txtFabricName" + i).val().toLowerCase();
                            if (txtFabricName == FabName) {
                                if (ddlFabricTypeVal == ddlFabricType) {
                                    alert('Duplicate Fabric Found. ');
                                    srcElem.value = '';
                                    $("#txtFabricName" + thisId).val('');
                                    $("#txtFabricName" + thisId).focus();
                                }
                            }
                        }
                    }
                }
            }
            ////            for (var i = 1; i <= LastNo[2]; i++) {
            ////                if (document.getElementById("ddlFabricType" + tblID + "_" + i) != undefined) {
            ////                    temp = temp + 1;
            ////                    var type = document.getElementById("ddlFabricType" + tblID + "_" + i).value;
            ////                    //  
            ////                    if (type == 1) {
            ////                        var Printlength = PrintArray.length;
            ////                        proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            ////                            if (result[0].Acc == '0') {
            ////                                document.getElementById("txtPrint" + tblID + "_1").value = "";
            ////                                return;
            ////                            }
            ////                        });
            ////                        if (document.getElementById("txtPrint" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '') == "") {
            ////                            PrintArray[Printlength] = i;
            ////                        }
            ////                        else {
            ////                            PrintArray[Printlength] = document.getElementById("txtPrint" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '');
            ////                        }
            ////                        PrintArray.sort();
            ////                        //
            ////                        for (var j = 1; j <= Printlength; j++) {
            ////                            var flag = false;
            ////                            var txt1 = $.trim(PrintArray[j - 1]);
            ////                            var txt2 = $.trim(PrintArray[j]);
            ////                            var num1 = "";
            ////                            var num2 = "";
            ////                            if (txt1.indexOf('-') > -1) {
            ////                                //
            ////                                num1 = $.trim(txt1.substring(txt1.indexOf('-') + 1, txt1.length));
            ////                                txt1 = $.trim(txt1.substring(0, txt1.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num1 = txt1;
            ////                            if (txt2.indexOf('-') > -1) {
            ////                                //
            ////                                num2 = $.trim(txt2.substring(txt2.indexOf('-') + 1, txt2.length));
            ////                                txt2 = $.trim(txt2.substring(0, txt2.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num2 = txt2;
            ////                            if (txt1 == txt2 || num1 == num2) {
            ////                                document.getElementById(ControlId).value = "";
            ////                                document.getElementById(ControlId).focus();
            ////                                alert('Duplicate Print : ' + PrintArray[j] + ' at Fabric: ' + temp);
            ////                                return;
            ////                            }
            ////                        }

            ////                    }
            ////                    if (type == 2) {
            ////                        var Printlength = PrintArray.length;
            ////                        proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            ////                            if (result[0].Acc == '0') {
            ////                                document.getElementById("txtDgtlPrint" + tblID + "_1").value = "";
            ////                                return;
            ////                            }
            ////                        });
            ////                        // 
            ////                        if (document.getElementById("txtDgtlPrint" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '') == "") {
            ////                            PrintArray[Printlength] = i;
            ////                        }
            ////                        else {
            ////                            PrintArray[Printlength] = document.getElementById("txtDgtlPrint" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '');
            ////                        }
            ////                        PrintArray.sort();
            ////                        //
            ////                        for (var j = 1; j <= Printlength; j++) {
            ////                            var flag = false;

            ////                            var txt1 = $.trim(PrintArray[j - 1]);
            ////                            var txt2 = $.trim(PrintArray[j]);
            ////                            var num1 = "";
            ////                            var num2 = "";
            ////                            if (txt1.indexOf('-') > -1) {
            ////                                //
            ////                                num1 = $.trim(txt1.substring(txt1.indexOf('-') + 1, txt1.length));
            ////                                txt1 = $.trim(txt1.substring(0, txt1.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num1 = txt1;
            ////                            if (txt2.indexOf('-') > -1) {
            ////                                //
            ////                                num2 = $.trim(txt2.substring(txt2.indexOf('-') + 1, txt2.length));
            ////                                txt2 = $.trim(txt2.substring(0, txt2.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num2 = txt2;
            ////                            if (txt1 == txt2 || num1 == num2) {
            ////                                document.getElementById(ControlId).value = "";
            ////                                document.getElementById(ControlId).focus();
            ////                                alert('Duplicate Print : ' + PrintArray[j] + ' at Fabric: ' + temp);
            ////                                return;
            ////                            }
            ////                        }

            ////                    }
            ////                    if (type == 0) {
            ////                        //  debugger
            ////                        // this code added by bharat 21-may
            ////                        var Solidlength = SolidArray.length;
            ////                        //                        proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            ////                        //                            if (result[0].Acc == '0') {
            ////                        //                                document.getElementById("txtSpecialFabricDetails" + tblID + "_1").value = "";
            ////                        //                                return;
            ////                        //                            }
            ////                        //                        });
            ////                        // 
            ////                        if (document.getElementById("txtSpecialFabricDetails" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '') == "") {
            ////                            SolidArray[Solidlength] = i;
            ////                        }
            ////                        else {
            ////                            SolidArray[Solidlength] = document.getElementById("txtSpecialFabricDetails" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '');
            ////                        }
            ////                        SolidArray.sort();

            ////                        for (var j = 1; j <= Solidlength; j++) {
            ////                            var flag = false;

            ////                            var txt1 = $.trim(SolidArray[j - 1]);
            ////                            var txt2 = $.trim(SolidArray[j]);
            ////                            var num1 = "";
            ////                            var num2 = "";
            ////                            if (txt1.indexOf('-') > -1) {
            ////                                //
            ////                                num1 = $.trim(txt1.substring(txt1.indexOf('-') + 1, txt1.length));
            ////                                txt1 = $.trim(txt1.substring(0, txt1.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num1 = txt1;
            ////                            if (txt2.indexOf('-') > -1) {
            ////                                //
            ////                                num2 = $.trim(txt2.substring(txt2.indexOf('-') + 1, txt2.length));
            ////                                txt2 = $.trim(txt2.substring(0, txt2.indexOf('-')));
            ////                            }
            ////                            else
            ////                                num2 = txt2;
            ////                            if (txt1 == txt2 || num1 == num2) {
            ////                                document.getElementById(ControlId).value = "";
            ////                                document.getElementById(ControlId).focus();
            ////                                alert('Duplicate Print : ' + SolidArray[j] + ' at Fabric: ' + temp);
            ////                                return;
            ////                            }
            ////                        }

            ////                        // this code commented by bharat 21-may
            ////                        ////                        var Solidlength = SolidArray.length;
            ////                        ////                        if (document.getElementById("txtSpecialFabricDetails" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '') == "") {
            ////                        ////                            SolidArray[Solidlength] = i;
            ////                        ////                        }
            ////                        ////                        else {
            ////                        ////                            SolidArray[Solidlength] = document.getElementById("txtSpecialFabricDetails" + tblID + "_" + i).value.replace(/^\s+|\s+$/g, '');
            ////                        ////                        }
            ////                        ////                        SolidArray.sort();
            ////                        ////                        for (var k = 1; k <= Solidlength; k++) {
            ////                        ////                            if (SolidArray[k - 1] == SolidArray[k]) {
            ////                        ////                                document.getElementById(ControlId).value = "";
            ////                        ////                                document.getElementById(ControlId).focus();
            ////                        ////                                alert('Duplicate Solid : ' + SolidArray[k] + ' at Fabric: ' + temp);
            ////                        ////                                return;
            ////                        ////                            }
            ////                        ////                        }
            ////                    }

            ////                }

            ////            }
        }
        //added abhishek 30/9/2016
        $(function () {

            $("input[type=text].NatureOfFaults").autocomplete("../../Webservices/iKandiService.asmx/SuggestAccsessoryTradeName", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });

            $("input[type=text].NatureOfFaults", "#main_content").result(function () {



                var StyleAccsessoryValue = $.trim($(this).val());

                if (StyleAccsessoryValue != '') {

                    var splitString = StyleAccsessoryValue.split('/');
               
                    var valueAtIndex1 = splitString[0];
         
                    if (valueAtIndex1) {

                        $(this).val(valueAtIndex1);

                    }

                }


            });
        });
        // Added by Yadvendra on 06/01/2020
        function OpenFileUpload() {
            // 
            var styleId = $("#" + hdnStyleIDClientID).val();
            sURL = 'UploadModelShoot.aspx?StyleId=' + styleId;
            //   window.open(sURL);
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 500, modal: true, animate: true, animateFade: true });
            return false;
        }
    </script>
    <!------------------------Add By Prabhaker 16 may 17------------->
    <script src="../../js/jquery-jtemplates.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var hiddenDesign = $('#' + ddlStyle2ClientID).val();
            // //// 
            var radioButtons = '#' + '<%=rdobuttonStyleSequence.ClientID%>';
      
            //var selectedVal = $(radioButtons).find(":checked").val();
  

            var hide3 = $('#' + txtStyle1ClientID).val();
     
            //            var hide4 = $('#' + ddlStyle2ClientID).val();
    
            if (hide3 == '') {
                if ($(radioButtons + '_1').is(':checked')) {
                    ////// 

                    $('#' + txtStyle1ClientID).val("");
                    $('#' + ddlStyle2ClientID).val("");
                    $('#' + ddlStyle2ClientID).attr("disabled", "disabled");
                    $('#' + txtStyle1ClientID).attr("Enabled", "Enabled");
                    //                    $('#' + ddlStyle2ClientID).val("");
                    //                    $('#' + ddlStyle2ClientID).attr("Enabled", "Enabled");    


                    $('#' + txtStyle1ClientID).removeAttr("disabled");
                    //                    $('#' + ddlStyle2ClientID).removeAttr("disabled");
                }
                else {

                    proxy.invoke("GetMaxStyleCode", {},
                                                            function (result) {
                                                          

                                                                $('#' + txtStyle1ClientID).val(result);
                                                                $('#' + stylecodeNewMax).val(result);



                                                            },
                                             onPageError, false, false);

                    //$('#' + txtStyle1ClientID).val(hide3);
                    //                    $('#' + ddlStyle2ClientID).val(hide4);

                    $('#' + txtStyle1ClientID).attr("disabled", "disabled");
                    //                    $('#' + ddlStyle2ClientID).attr("disabled", "disabled");
                }

            }
            $(radioButtons).change(function () {
                ////// 

                if ($(radioButtons + '_1').is(':checked')) {
                    ////// 

                    $('#' + txtStyle1ClientID).val("");
                    $('#' + txtStyle1ClientID).attr("Enabled", "Enabled");
                    $('#' + ddlStyle2ClientID).val("");
                    //                    $('#' + ddlStyle2ClientID).val("");
                    //                    $('#' + ddlStyle2ClientID).attr("Enabled", "Enabled");    


                    $('#' + txtStyle1ClientID).removeAttr("disabled");
                    //                    $('#' + ddlStyle2ClientID).removeAttr("disabled");
                }
                else {

                    proxy.invoke("GetMaxStyleCode", {},
                                                            function (result) {
                                                                $('#' + txtStyle1ClientID).val(result);
                                                                $('#' + stylecodeNewMax).val(result);


                                                            },
                                             onPageError, false, false);

                    $('#' + txtStyle1ClientID).val(hide3);
                    //                                        $('#' + ddlStyle2ClientID).val(hide4);
                    $('#' + ddlStyle2ClientID).val(hiddenDesign);
                    $('#' + txtStyle1ClientID).attr("disabled", "disabled");
                    //                    $('#' + ddlStyle2ClientID).attr("disabled", "disabled");
                }
            });
        });

        function OpenTechfiles(obj) {
            //// 
            var Styleid = '<%=this.StyleID %>';

            //var sURL = obj.href;
            var sURL = '../../Internal/OrderProcessing/TechPackUpload.aspx?Styleid=' + Styleid;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
       
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 250, width: 450, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

            return false;
        }
        function SBClose() { }

        function prints() {
            $("#secure_greyline").hide();
            window.print();
            $("#secure_greyline").show();
            return false;
        }
        // this code added by bharat 22-may  
        $(document).ready(function () {
            var rowCount = $('#tblBasicInfo tr').length;
         
            if (rowCount == 22) {
                $('#divAddRow').hide();
            }
        });
        function CheckDecision(elem) {
            // 
            var Idsn = elem.id;
            var pass = $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val();
            var fail = $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val();
            var checked = $("#grv_Accessories_Inspection_" + Idsn + "_txtChecked" + type).val();
            if (pass != "" && fail != "") {
                if ((parseInt(pass) + parseInt(fail)) > parseInt(checked)) {
                    alert("Pass + Fail Quantity cannot greater than Checked Quantity!");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtPass" + type).val("");
                    $("#grv_Accessories_Inspection_" + Idsn + "_txtFail" + type).val("");
                }
            }
        }
        function OpenUnRagiFabFun() {
            //   
            var sURL = '../../Internal/Fabric/UnRagisterFabricQuality.aspx';
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
     
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 630, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

            return false;
        }
        function OpenUnRagiAccessFun() {
            var sURL = '../../Internal/Accessory/UnRagisterAccessories.aspx';

            Shadowbox.init({ animate: true, animateFade: true, modal: true });

            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 280, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

            return false;
        }
//        function MaxNumberFun(ele) {
//             
//            var val = ele.value.length;
//            var stlLen = "";
//            if (val == 2) {
//                var stylecode1 = $("#ctl00_cph_main_content_DesignerForm1_txtStyle1").val();
//                stlLen = stylecode1.length;
//            }
//            else {
//                var stylecode = $("#ctl00_cph_main_content_DesignerForm1_txtStyle").val();
//                stlLen = stylecode.length;
//           }
//            var totalLen = val + stlLen;
//            if (totalLen < 8) {
//                alert('style number does not less than 8 characters !');
//                var stylecode1 = $("#ctl00_cph_main_content_DesignerForm1_txtStyle1").val('');
//                return false;
//            }

//      }
    </script>
    <%--<script src="../../js/jquery-ui.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <!------------------------end of code------------------------------>
    <%--<a href="javascript:void(0)" onclick="return PrintPDF();">Print</a>--%>
    <asp:Panel runat="server" ID="pnlDesignerForm" CssClass="print-box">
        <h2 style="background: #39589c; margin: 0px; padding: 5px 10px; font-weight: bold;
            color: #fff; text-transform: capitalize; border-radius: 5px 5px 0px 0px;">
            <div style="float: left; width: 53%; text-align: left;">
                <span class="da_h1">Design Form</span> <span class="da_required_field">(<span class="da_astrx_mand">*</span>Please
                    fill all required fields)</span>
                       <asp:CheckBox ID="CbVisibleInMarketing" runat="server" Style='text-transform: capitalize;font-size:12px;font-weight:300'
                                    Text="Visible In Marketing" />
            </div>
            <div style="float: right;">
                <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0" style="margin: 0px;">
                    <tr>
                      <td>
                       <span onclick="OpenUnRagiFabFun()" style="cursor: pointer; margin-right: 5px;position: relative;top:2px;"><img src="../../images/urf.png" title="UnRegister Fabric" /></span> 
                       <span onclick="OpenUnRagiAccessFun()" style="cursor: pointer; margin-right: 7px;position: relative;top:2px;"><img src="../../images/ura.png" title="UnRegister Accessories" /></span>
                      </td>
                        <td class="da_h1" style="font-size: 12px; padding: 0px 2px;">
                            Style Number:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtStyleNo" Style="font-size: 12px;" CssClass="do-not-disable"
                                Width="210px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearchStyleNo" Text="Search" runat="server" Style="padding: 4px 2px;border-radius: 0px 4px 4px 0px;"
                                class="da_go_button go do-not-disable" OnClientClick="SearchStyleNumber();return false;" />
                        </td>
                        <asp:HiddenField ID="hdnStyleID" runat="server" Value="-1" />
                        <asp:HiddenField ID="hdnuserid" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnstylenumber" runat="server" Value="0" />
                        <asp:HiddenField ID="hdndddlexistancecheck" runat="server" Value="0" />
                    </tr>
                </table>
            </div>
            <div style="clear: both;">
            </div>
            <h2>
            </h2>
            <div id="tabs" class="ResetDiv">
                <table cellpadding="0" cellspacing="0">
                    <tr class="tabs_tr">
                        <asp:Repeater ID="rptTab" runat="server" OnItemDataBound="rptTab_ItemDataBound">
                            <ItemTemplate>
                                <td class="tabs_td">
                                    <asp:HyperLink ID="hlkDesign" runat="server" NavigateUrl='<%# "/Internal/Design/DesignerEdit.aspx?styleid="+Eval("StyleID") %>'
                                        Target="_self" Text='<%# Eval("StyleNumber")%>'></asp:HyperLink>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
            </div>
            <div class="form_box ">
                <table cellspacing="0" width="100%">
                    <tr>
                        <td class="da_v-line-design-form">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                width="100%">
                                <caption class="caption_headings">
                                    Basic Details</caption>
                                <%-- Added by Yadvendra on 06/01/2019--%>
                                <asp:HyperLink ID="LinkUploadModelShoot" Visible="false" onclick='return OpenFileUpload(this);'
                                    Style="cursor: pointer; color: blue; font-size: 9px; padding-left: 9px; text-transform: capitalize;"
                                    runat="server">Upload Model Shoot</asp:HyperLink>
                             <%--   <asp:CheckBox ID="CbVisibleInMarketing" runat="server" Style='text-transform: capitalize;'
                                    Text="Visible In Marketing" />--%>
                                <div>
                                    <caption style="float: right; text-align: right; position: relative; top: -43px">
                                       <%-- <span onclick="OpenUnRagiFabFun()" style="color: Blue; text-transform: capitalize;
                                            cursor: pointer; margin-right: 15px;">UnRegister Fabric Entry</span> <span onclick="OpenUnRagiAccessFun()"
                                                style="color: Blue; text-transform: capitalize; cursor: pointer; margin-right: 7px;">
                                                UnRegister Accessories Entry</span>--%>
                                    </caption>
                                </div>
                                <%--End Added by Yadvendra on 06/01/2019--%>
                                <tr>
                                    <td width="85%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="6" style="margin: 0px;"
                                            width="100%">
                                            <tr class="td-sub_headings">
                                                <td valign="bottom" rowspan="2" style="min-width:214px;">
                                                    <asp:RadioButtonList runat="server" ID="rdobuttonStyleSequence">
                                                        <asp:ListItem Text="Use Default Style Sequence" Value="1" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text=" Use Open Style Sequence" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td valign="bottom" width="10%">
                                                    Division Name<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom" width="10%">
                                                    Buying House<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td class="style1" valign="bottom" width="10%">
                                                    Buyer<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom" width="10%">
                                                    Parent Department<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom" width="10%">
                                                    Department<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom" width="6%">
                                                    Season
                                                </td>
                                                <td valign="bottom" width="6%">
                                                    Story
                                                    <asp:Image ID="ImgRemarks" runat="server" BorderWidth="0" ImageUrl="~/App_Themes/ikandi/images/remark.gif"
                                                        Visible="false" />
                                                </td>
                                                <td valign="bottom" width="7%">
                                                    Meeting
                                                </td>
                                                <td valign="bottom" width="18%">
                                                    Style Number<span class="da_astrx_mand">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlDivisionName" runat="server" Width="90%">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlDivisionName"
                                                            Display="Dynamic" ErrorMessage="Please select Division" InitialValue="0" ValidationGroup="Submit">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlBuyingHouse" runat="server" CssClass="" OnSelectedIndexChanged="ddlBuyingHouse_SelectedIndexChanged"
                                                        Style="width: 90%">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBuyingHouse"
                                                            Display="Dynamic" EnableClientScript="true" ErrorMessage="Select Buying House"
                                                            Font-Size="8" InitialValue="-1" ValidationGroup="Submit" Width="100"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlBuyer" runat="server" Style="width: 90%;">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnBuyer" runat="server" Value="0" />
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_ddlBuyer" runat="server" ControlToValidate="ddlBuyer"
                                                            Display="Dynamic" EnableClientScript="true" ErrorMessage="Select client" Font-Size="8"
                                                            InitialValue="-1" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlParentDept" runat="server" CssClass="" Style="width: 90%;">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnParentDeptName" runat="server" />
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_ddlParentDept" runat="server" ControlToValidate="ddlParentDept"
                                                            Display="Dynamic" EnableClientScript="true" ErrorMessage="Select Parent Dept"
                                                            Font-Size="8" InitialValue="-1" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="" Style="width: 90%;">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnDeptName" runat="server" />
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_ddlDept" runat="server" ControlToValidate="ddlDept"
                                                            Display="Dynamic" EnableClientScript="true" ErrorMessage="Select Dept" Font-Size="8"
                                                            InitialValue="-1" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlSeason" runat="server" CssClass="ddlTest" Style="width: 90px;">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnSeason" runat="server" Value="0" />
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox ID="txtStory" runat="server" CssClass="a" Width="90px"></asp:TextBox>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox ID="txtMeeting" runat="server" CssClass="th style-meeting date_style"
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                                <td class="inner_tbl_td" style="padding-right: 0px;">
                                                    <asp:TextBox ID="txtStyle" runat="server"  CssClass="style-number" MaxLength="2" Width="22"></asp:TextBox>
                                                    -
                                                    <asp:TextBox ID="txtDesignerCode" CssClass="do-not-allow-typing" runat="server" MaxLength="2"
                                                        Width="22"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlDesignerCode" runat="server" Visible="false" Width="38">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtStyle1" onkeypress="var key = event.keyCode || event.charCode; return ((key  >= 48 && key  <= 57) || (key >= 65 && key <= 90) || (key >= 97 && key <= 122) || key == 8);"
                                                        runat="server" minlength="5" MaxLength="10" Width="70" Font-Size="11px" Enabled="false"></asp:TextBox>
                                                    -
                                                    <asp:TextBox ID="txtStyle2" runat="server" MaxLength="2" Width="20"></asp:TextBox>
                                                    <br />
                               <%--                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStyle1"
                                                        Display="Dynamic" EnableClientScript="true" ErrorMessage="Min 4 characters are required"
                                                        Font-Size="8" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStyle1"
                                                        Display="Dynamic" EnableClientScript="true" ErrorMessage="Min 5 characters are required"
                                                        Font-Size="8" ValidationExpression=".{5}.*" ValidationGroup="Submit" />--%>
                                                    <asp:HiddenField ID="hdnstylecodeNew" runat="server" Value="0" />

                                                        <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="Min 5 characters are required"
                                                     OnServerValidate="CustomValidator_ServerValidate"
                                                       Display="Dynamic" EnableClientScript="true" Font-Size="8" ValidationExpression=".{5}.*" ValidationGroup="Submit"></asp:CustomValidator>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                width="99%">
                                <caption class="caption_headings">
                                    Fabric Info
                                </caption>
                                <tr>
                                    <td>
                                        <div>
                                            <div id="divBasicInfo">
                                                <table id="tblBasicInfo" cellspacing="5" class="CountTableRow" width="100%">
                                                    <tr class="td-sub_headings">
                                                        <td colspan="4">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="height: 13px; width: 100%">
                                                                <tr>
                                                                    <td width="45%">
                                                                        Fabric
                                                                    </td>
                                                                    <td width="35%">
                                                                        <span id ="typee"></span>
                                                                    </td>
                                                                    <td width="20%">
                                                                        Remark
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab1" class="RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab1" class="tblFab1">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px;" valign="top">
                                                                        <input id="txtStyleFabID1" name="txtStyleFabID1" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted1" name="txtIsDeleted1" type="hidden" value="0" />
                                                                        <input id="hdntotal1" name="hdntotal1" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate1" name="hdnDyedRate1" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate1" name="hdnPrintRate1" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate1" name="hdnDigitalPrintRate1" value="0" type="hidden" />
                                                                        <input id="hdnGSM1" name="hdnGSM1" value="0" type="hidden" />
                                                                        <input id="hdnCC1" name="hdnCC1" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth1" name="hdnCostWidth1" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId1" name="hdnFabricQualityId1" value="0" type="hidden" />
                                                                        <input id="txtFabricName1" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName1" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="1" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%" valign="top">
                                                                        <table id="tblInner_1_1" class="fabInner">
                                                                            <tr id="trInner_1_1">
                                                                                <td valign="top">
                                                                                    <select id="ddlFabricType1_1" name="ddlFabricType1_1" onchange="onFabricChange1(1,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint1_1" class="hide_me" name="spanPrint1_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint1_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint"
                                                                                            name="txtPrint1_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint1_1" class="hide_me" name="spanDgtlPrint1_1">
                                                                                        <nobr>
                                                                                          Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint1_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint"
                                                                                            name="txtDgtlPrint1_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther1_1" class="hide_me" name="spanOther1_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails1_1" class="ColorSolid" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails1_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanAdd1_1" name="spanAdd1_1"></span>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <input id="txtRemarks1_1" maxlength="190" name="txtRemarks1_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <img id="btnAddRow1_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow1_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab2" class="hide_me RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab2" class="tblFab">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px; width: 30%;" valign="top">
                                                                        <input id="txtStyleFabID2" name="txtStyleFabID2" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted2" name="txtIsDeleted2" type="hidden" value="0" />
                                                                        <input id="hdntotal2" name="hdntotal2" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate2" name="hdnDyedRate2" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate2" name="hdnPrintRate2" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate2" name="hdnDigitalPrintRate2" value="0" type="hidden" />
                                                                        <input id="hdnGSM2" name="hdnGSM2" value="0" type="hidden" />
                                                                        <input id="hdnCC2" name="hdnCC2" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth2" name="hdnCostWidth2" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId2" name="hdnFabricQualityId2" value="0" type="hidden" />
                                                                        <input id="txtFabricName2" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName2" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="2" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%;">
                                                                        <table id="tblInner_2_1" class="fabInner">
                                                                            <tr id="trInner_2_1">
                                                                                <td>
                                                                                    <select id="ddlFabricType2_1" name="ddlFabricType2_1" onchange="onFabricChange1(2,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint2_1" class="hide_me" name="spanPrint2_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint2_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint"
                                                                                            name="txtPrint2_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint2_1" class="hide_me" name="spanDgtlPrint2_1">
                                                                                        <nobr>
                                                                                          Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint2_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint"
                                                                                            name="txtDgtlPrint2_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther2_1" class="hide_me" name="spanOther2_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails2_1" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails2_1" class="ColorSolid" style="width: 300px"
                                                                                            onpaste="return false;" type="text" />
                                                                                    </span><span id="spanAdd2_1" name="spanAdd2_1"></span>
                                                                                </td>
                                                                                <td>
                                                                                    <input id="txtRemarks2_1" maxlength="190" name="txtRemarks2_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td>
                                                                                    <img id="btnAddRow2_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow2_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="da_remove_btn_dafo">
                                                                <img id="imgFabHide2" onclick="hideRow(2)" style="cursor: pointer" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                Remove</span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab3" class="hide_me RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab3" class="tblFab1">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px; width: 30%" valign="top">
                                                                        <input id="txtStyleFabID3" name="txtStyleFabID3" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted3" name="txtIsDeleted3" type="hidden" value="0" />
                                                                        <input id="hdntotal3" name="hdntotal3" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate3" name="hdnDyedRate3" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate3" name="hdnPrintRate3" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate3" name="hdnDigitalPrintRate3" value="0" type="hidden" />
                                                                        <input id="hdnGSM3" name="hdnGSM3" value="0" type="hidden" />
                                                                        <input id="hdnCC3" name="hdnCC3" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth3" name="hdnCostWidth3" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId3" name="hdnFabricQualityId3" value="0" type="hidden" />
                                                                        <input id="txtFabricName3" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName3" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="3" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%;">
                                                                        <table id="tblInner_3_1" class="fabInner">
                                                                            <tr id="tblInner_3_1">
                                                                                <td>
                                                                                    <select id="ddlFabricType3_1" name="ddlFabricType3_1" onchange="onFabricChange1(3,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint3_1" class="hide_me" name="spanPrint3_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint3_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint "
                                                                                            name="txtPrint3_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint3_1" class="hide_me" name="spanDgtlPrint3_1">
                                                                                        <nobr>
                                                                                          Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint3_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint "
                                                                                            name="txtDgtlPrint3_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther3_1" class="hide_me" name="spanOther3_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid :&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails3_1" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails3_1" class="ColorSolid" style="width: 300px"
                                                                                            onpaste="return false;" type="text" />
                                                                                    </span><span id="spanAdd3_1" name="spanAdd3_1"></span>
                                                                                </td>
                                                                                <td>
                                                                                    <input id="txtRemarks3_1" maxlength="190" name="txtRemarks3_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td>
                                                                                    <img id="btnAddRow3_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow3_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="da_remove_btn_dafo">
                                                                <img id="imgFabHide3" onclick="hideRow(3)" style="cursor: pointer" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                Remove</span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab4" class="hide_me RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab4" class="tblFab">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px; width: 30%" valign="top">
                                                                        <input id="txtStyleFabID4" name="txtStyleFabID4" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted4" name="txtIsDeleted4" type="hidden" value="0" />
                                                                        <input id="hdntotal4" name="hdntotal4" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate4" name="hdnDyedRate4" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate4" name="hdnPrintRate4" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate4" name="hdnDigitalPrintRate4" value="0" type="hidden" />
                                                                        <input id="hdnGSM4" name="hdnGSM4" value="0" type="hidden" />
                                                                        <input id="hdnCC4" name="hdnCC4" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth4" name="hdnCostWidth4" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId4" name="hdnFabricQualityId4" value="0" type="hidden" />
                                                                        <input id="txtFabricName4" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName4" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="4" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%;">
                                                                        <table id="tblInner_4_1" class="fabInner">
                                                                            <tr id="trInner_4_1">
                                                                                <td>
                                                                                    <select id="ddlFabricType4_1" name="ddlFabricType4_1" onchange="onFabricChange1(4,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint4_1" class="hide_me" name="spanPrint4_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint4_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint"
                                                                                            name="txtPrint4_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint4_1" class="hide_me" name="spanDgtlPrint4_1">
                                                                                        <nobr>
                                                                                         Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint4_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint"
                                                                                            name="txtDgtlPrint4_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther4_1" class="hide_me" name="spanOther4_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails4_1" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails4_1" class="ColorSolid" style="width: 300px"
                                                                                            onpaste="return false;" type="text" />
                                                                                    </span><span id="spanAdd4_1" name="spanAdd4_1"></span>
                                                                                </td>
                                                                                <td>
                                                                                    <input id="txtRemarks4_1" maxlength="190" name="txtRemarks4_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td>
                                                                                    <img id="btnAddRow4_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow4_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="da_remove_btn_dafo">
                                                                <img id="imgFabHide4" onclick="hideRow(4)" style="cursor: pointer" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                Remove</span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab5" class="hide_me RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab5" class="tblFab">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px; width: 30%" valign="top">
                                                                        <input id="txtStyleFabID5" name="txtStyleFabID5" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted5" name="txtIsDeleted5" type="hidden" value="0" />
                                                                        <input id="hdntotal5" name="hdntotal5" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate5" name="hdnDyedRate5" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate5" name="hdnPrintRate5" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate5" name="hdnDigitalPrintRate5" value="0" type="hidden" />
                                                                        <input id="hdnGSM5" name="hdnGSM5" value="0" type="hidden" />
                                                                        <input id="hdnCC5" name="hdnCC5" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth5" name="hdnCostWidth5" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId5" name="hdnFabricQualityId5" value="0" type="hidden" />
                                                                        <input id="txtFabricName5" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName5" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="5" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%;">
                                                                        <table id="tblInner_5_1" class="fabInner">
                                                                            <tr id="trInner_5_1">
                                                                                <td>
                                                                                    <select id="ddlFabricType5_1" name="ddlFabricType5_1" onchange="onFabricChange1(5,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint5_1" class="hide_me" name="spanPrint5_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint5_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint"
                                                                                            name="txtPrint5_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint5_1" class="hide_me" name="spanDgtlPrint5_1">
                                                                                        <nobr>
                                                                                         Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint5_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint"
                                                                                            name="txtDgtlPrint5_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther5_1" class="hide_me" name="spanOther5_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails5_1" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails5_1" class="ColorSolid" style="width: 300px"
                                                                                            onpaste="return false;" type="text" />
                                                                                    </span><span id="spanAdd5_1" name="spanAdd5_1"></span>
                                                                                </td>
                                                                                <td>
                                                                                    <input id="txtRemarks5_1" maxlength="190" name="txtRemarks5_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td>
                                                                                    <img id="btnAddRow5_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow5_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="da_remove_btn_dafo">
                                                                <img id="imgFabHide5" onclick="hideRow(5)" style="cursor: pointer" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                Remove</span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFab6" class="hide_me RowCountTable">
                                                        <td colspan="3">
                                                            <table id="tblFab6" class="tblFab">
                                                                <tr>
                                                                    <td style="vertical-align: top; padding-top: 4px; width: 30%" valign="top">
                                                                        <input id="txtStyleFabID6" name="txtStyleFabID6" type="hidden" value="-1" />
                                                                        <input id="txtIsDeleted6" name="txtIsDeleted6" type="hidden" value="0" />
                                                                        <input id="hdntotal6" name="hdntotal6" type="hidden" value="1" />
                                                                        <input id="hdnDyedRate6" name="hdnDyedRate6" value="0" type="hidden" />
                                                                        <input id="hdnPrintRate6" name="hdnPrintRate6" value="0" type="hidden" />
                                                                        <input id="hdnDigitalPrintRate6" name="hdnDigitalPrintRate6" value="0" type="hidden" />
                                                                        <input id="hdnGSM6" name="hdnGSM4" value="0" type="hidden" />
                                                                        <input id="hdnCC6" name="hdnCC6" value="0" type="hidden" />
                                                                        <input id="hdnCostWidth6" name="hdnCostWidth6" value="0" type="hidden" />
                                                                        <input id="hdnFabricQualityId6" name="hdnFabricQualityId6" value="0" type="hidden" />
                                                                        <input id="txtFabricName6" onblur="CheckFabricName(this)" class="style-fabric" maxlength="300"
                                                                            name="txtFabricName6" onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                                        <br />
                                                                        <label id="6" style="font-size: smaller">
                                                                        </label>
                                                                    </td>
                                                                    <td colspan="4" style="width: 70%;">
                                                                        <table id="tblInner_6_1" class="fabInner">
                                                                            <tr id="trInner_6_1">
                                                                                <td>
                                                                                    <select id="ddlFabricType6_1" name="ddlFabricType6_1" onchange="onFabricChange1(6,1)"
                                                                                        size="1">
                                                                                        <option value="-1">Select..</option>
                                                                                        <option value="0">Dyed</option>
                                                                                        <option value="1">Screen Print</option>
                                                                                        <option value="2">Digital Print</option>
                                                                                    </select>
                                                                                </td>
                                                                                <td style="width: 60%;" valign="top">
                                                                                    <span id="spanPrint6_1" class="hide_me" name="spanPrint6_1">
                                                                                        <nobr>
                                                                                         Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtPrint6_1" onblur="CheckDuplicateFabricDetails(this)" class="ScreenPrint"
                                                                                            name="txtPrint6_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanDgtlPrint6_1" class="hide_me" name="spanDgtlPrint6_1">
                                                                                        <nobr>
                                                                                         Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtDgtlPrint6_1" onblur="CheckDuplicateFabricDetails(this)" class="DigitalPrint"
                                                                                            name="txtDgtlPrint6_1" style="width: 300px" type="text" />
                                                                                    </span><span id="spanOther6_1" class="hide_me" name="spanOther6_1">
                                                                                        <nobr>
                                                                                          Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                                        <input id="txtSpecialFabricDetails6_1" onblur="CheckDuplicateFabricDetails(this)"
                                                                                            maxlength="190" name="txtSpecialFabricDetails6_1" class="ColorSolid" style="width: 300px"
                                                                                            onpaste="return false;" type="text" />
                                                                                    </span><span id="spanAdd6_1" name="spanAdd6_1"></span>
                                                                                </td>
                                                                                <td>
                                                                                    <input id="txtRemarks6_1" maxlength="190" name="txtRemarks6_1" style="width: 300px"
                                                                                        type="text" />
                                                                                </td>
                                                                                <td>
                                                                                    <img id="btnAddRow6_1" class="hide_me" title="Add More" onclick="addRow_new(this)"
                                                                                        src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                                                    <img id="btnDeleteRow6_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="da_remove_btn_dafo">
                                                                <img id="imgFabHide6" onclick="hideRow(6)" style="cursor: pointer" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                                Remove</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divAddRow" align="right" style="width: 99.8%;">
                                                <span class="da_remove_btn_dafo">
                                                    <img src="../../App_Themes/ikandi/images/plus_icon.gif" style="cursor: pointer" class="hide_me"
                                                        id="btnNewAddRow" onclick="createNewRow()" />
                                                    <img src="../../App_Themes/ikandi/images/plus_icon.gif" style="cursor: pointer" class="show"
                                                        id="btnAddRow" onclick="showRow(this)" />
                                                    Add More &nbsp;</span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--Accsessory sec--%>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                width="99%">
                                <caption class="caption_headings">
                                    Accessory Info
                                </caption>
                                <tr>
                                    <td>
                                        <div>
                                            <div id="div1">
                                                <table id="Table1" cellspacing="5" width="100%">
                                                    <tr class="td-sub_headings">
                                                        <td colspan="4">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="height: 13px; width: 100%">
                                                                <tr>
                                                                    <td width="70%">
                                                                        Accessory
                                                                    </td>
                                                                    <td width="30%">
                                                                        Remark
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1">
                                                        <td colspan="3">
                                                            <table id="Table2" class="tblFab1">
                                                                <tr>
                                                                    <td colspan="4" style="width: 70%" valign="top">
                                                                        <table id="Table3" class="fabInner" cellpadding="0" cellspacing="0">
                                                                            <tr id="tr2">
                                                                                <td valign="top">
                                                                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                                    </asp:ScriptManager>
                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <div id="dvBaseSizeRate" class="modal">
                                                                                                <div id="dvSizeRate" class="modal-content">
                                                                                                </div>
                                                                                            </div>
                                                                                            <asp:GridView ID="grdAccsessory" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                ShowFooter="True" OnRowDeleting="grdAccsessory_RowDeleting" HeaderStyle-Font-Names="Arial"
                                                                                                HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdAccsessory_RowCommand"
                                                                                                OnRowDataBound="grdAccsessory_RowDataBound" GridLines="None" BorderWidth="0"
                                                                                                rules="all" HeaderStyle-CssClass="border2" ShowHeader="false">
                                                                                                <RowStyle CssClass="gvRow" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Accsessory">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtAccname" Style="width: 98%;" CssClass="items" ToolTip="fill accsessory name "
                                                                                                                onchange="return grdAccessoryOnchange(this);" Text='<%#Eval("AccesoriesName")%>'
                                                                                                                runat="server"></asp:TextBox>
                                                                                                            <asp:HiddenField ID="hdnSize" runat="server" Value='<%#Eval("SIZE")%>' />
                                                                                                            <asp:HiddenField ID="hdnAccQualityId" runat="server" Value='<%#Eval("AccesoriesQualityID")%>' />
                                                                                                            <asp:HiddenField ID="hdnRate" runat="server" Value='<%#Eval("Rate")%>' />
                                                                                                            <asp:HiddenField ID="hdnAccessoryid" runat="server" Value='<%#Eval("Id")%>' />
                                                                                                            <asp:HiddenField ID="hdnAutoincretment" Value='<%# ((GridViewRow)Container).RowIndex + 1%>'
                                                                                                                runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="45%" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:TextBox ID="txtfoterAccname" Style="width: 98%;" CssClass="items" onblur="CheckAccessoryName(this)"
                                                                                                                ToolTip="fill accsessory name items" runat="server"></asp:TextBox>
                                                                                                            <asp:HiddenField ID="hdnAutoincretmentfoter" Value='<%# ((GridViewRow)Container).RowIndex + 1%>'
                                                                                                                runat="server" />
                                                                                                            <asp:HiddenField ID="hdnFooterSize" runat="server" Value='<%#Eval("SIZE")%>' />
                                                                                                            <asp:HiddenField ID="hdnFooterAccQualityId" runat="server" Value='<%#Eval("AccesoriesQualityID")%>' />
                                                                                                            <asp:HiddenField ID="hdnFooterRate" runat="server" Value='<%#Eval("Rate")%>' />
                                                                                                        </FooterTemplate>
                                                                                                        <FooterStyle Width="45%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtRemarks" MaxLength="100" Style="width: 98%;" ToolTip="Accsessory remarks"
                                                                                                                Text='<%#Eval("Remarks")%>' runat="server"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="45%" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:TextBox ID="txtfoterRemarks" Style="width: 98%;" ToolTip="Remarks" runat="server"></asp:TextBox>
                                                                                                        </FooterTemplate>
                                                                                                        <FooterStyle Width="45%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="">
                                                                                                        <ItemTemplate>
                                                                                                            <div style="text-align: left;" class="iSlnkHide">
                                                                                                                <asp:LinkButton ForeColor="black" ID="lnkDelete" runat="server" CommandName="Delete"
                                                                                                                    ToolTip="" OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../App_Themes/ikandi/images/minus_icon.gif" />  </asp:LinkButton>
                                                                                                                <span>Remove </
                                                                                                            </div>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="10%" VerticalAlign="top" />
                                                                                                        <FooterTemplate>
                                                                                                            <div style="text-align: left;" class="iSlnkHide">
                                                                                                                <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                                                                                    ToolTip="" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../App_Themes/ikandi/images/plus_icon.gif" /></asp:LinkButton>
                                                                                                                <span>Add More </span>
                                                                                                            </div>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                                <tr>
                                    <td valign="top" style="width: 900px;">
                                        <table border="0" cellpadding="0" cellspacing="0" class="tbl_bordr" style="height: 100%;
                                            vertical-align: top" width="99%">
                                            <caption class="caption_headings">
                                                Upload Style File
                                            </caption>
                                            <tr>
                                                <td style="height: 100%;">
                                                    <table align="center" border="0" cellpadding="0" cellspacing="6" style="margin: 0px;"
                                                        width="100%">
                                                        <tr class="td-sub_headings">
                                                            <td valign="bottom" style="width: 225px">
                                                                Upload Style Sketch<span class="da_astrx_mand">*</span>
                                                            </td>
                                                            <td style="text-align: left; width: 70px;" rowspan="2">
                                                                <asp:HyperLink ID="HyperLinkimgSketch" runat="server" Visible="false">
                                                                    <asp:Image ID="imgSketch" runat="server" Style="max-height: 70px;" />
                                                                </asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypSample1" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="SampleImage1" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypSample2" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="SampleImage2" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypSample3" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="SampleImage3" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypEmbleshment" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="imgEmblessment" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypMocks" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="imgMocks" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td rowspan="2" style="width: 25px">
                                                                <asp:HyperLink ID="hypCad" runat="server" rel="lightbox" Visible="false">
                                                                    <asp:Image ID="imgCad" runat="server" CssClass="lightbox" Width="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg"
                                                                        align="right" /></asp:HyperLink>
                                                            </td>
                                                            <td valign="bottom" style="width: 225px">
                                                                Upload Style Document
                                                            </td>
                                                            <%-- <td valign="bottom" width="20%">
                                                                Upload Style tech pack
                                                            </td>--%>
                                                            <!------------new-code-by-prabhaker------->
                                                            <%-- <td valign="bottom" width="20%">
                                                                Upload Style tech pack2
                                                            </td>
                                                            <td valign="bottom" width="20%">
                                                                Upload Style tech pack3
                                                            </td>--%>
                                                            <!------------End of Prabhaker Code----------->
                                                            <td rowspan="2" style="width: 60px">
                                                                <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenTechfiles(this);'
                                                                    style="cursor: pointer; float: right; width: auto;">
                                                                    <asp:Label ID="lbltechFile" runat="server" ToolTip="T Pack file" Style="color: Gray;"
                                                                        Text="T-Pack"></asp:Label></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="inner_tbl_td">
                                                                <asp:FileUpload ID="upSketch" runat="server" Width="170" />
                                                                <asp:CustomValidator ID="rfvupSketch" runat="server" ClientValidationFunction="IsFileUploaded"
                                                                    ControlToValidate="upSketch" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                                                    ErrorMessage="Upload sketch is required" ValidationGroup="Submit"> </asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="rfvupSketch1" runat="server" ControlToValidate="upSketch"
                                                                    ErrorMessage="Upload sketch is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="inner_tbl_td">
                                                                <asp:FileUpload ID="upDoc" runat="server" Width="170" />
                                                                <asp:LinkButton ID="lnkDoc" runat="server" Visible="false">View</asp:LinkButton>
                                                                <asp:HyperLink ID="hlkViewMe" runat="server" Target="_blank" Text="View File" Visible="false"></asp:HyperLink>
                                                                <asp:CustomValidator ID="rfvupDoc" runat="server" ClientValidationFunction="IsFileUploaded"
                                                                    ControlToValidate="upDoc" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                                                    ErrorMessage="Document Upload is required" ValidationGroup="Submit"> </asp:CustomValidator>
                                                            </td>
                                                            <td class="inner_tbl_td" style="display: none;">
                                                                <asp:FileUpload ID="filetackpack" runat="server" Width="170" />
                                                                <asp:LinkButton ID="lnktackpack" runat="server" Visible="false">View</asp:LinkButton>
                                                                <asp:HyperLink ID="hlkviewtackpack" runat="server" Target="_blank" Text="View File"
                                                                    Visible="false"></asp:HyperLink>
                                                                <asp:CustomValidator ID="ctvtackpack" runat="server" ClientValidationFunction="IsFileUploaded"
                                                                    ControlToValidate="filetackpack" Display="Dynamic" EnableClientScript="true"
                                                                    Enabled="true" ErrorMessage="tack pack Document Upload is required" ValidationGroup="Submit"> </asp:CustomValidator>
                                                            </td>
                                                            <td class="inner_tbl_td" style="display: none;">
                                                                <asp:FileUpload ID="filetackpack1" runat="server" Width="170" />
                                                                <asp:LinkButton ID="lnktackpack1" runat="server" Visible="false">View</asp:LinkButton>
                                                                <asp:HyperLink ID="hlkviewtackpack1" class="preview" runat="server" Target="_blank"
                                                                    Text="View File" Visible="false">
                                                               <%-- <asp:Image runat="server" ID="Imgtechfile1"  Height="20px" Width="20px" />--%>
                                                                
                                                                </asp:HyperLink>
                                                                <asp:CustomValidator ID="ctvtackpack1" runat="server" ClientValidationFunction="IsFileUploaded"
                                                                    ControlToValidate="filetackpack1" Display="Dynamic" EnableClientScript="true"
                                                                    Enabled="true" ErrorMessage="tack pack Document Upload is required" ValidationGroup="Submit"> </asp:CustomValidator>
                                                            </td>
                                                            <td class="inner_tbl_td" style="display: none;">
                                                                <asp:FileUpload ID="filetackpack2" runat="server" Width="170" />
                                                                <asp:LinkButton ID="lnktackpack2" runat="server" Visible="false"></asp:LinkButton>
                                                                <asp:HyperLink ID="hlkviewtackpack2" class="preview" runat="server" Target="_blank"
                                                                    Text="View File" Visible="false">
                                                               <%-- <asp:Image runat="server" ID="Imgtechfile2"  Height="20px" Width="20px" />--%>
                                                                
                                                                </asp:HyperLink>
                                                                <asp:CustomValidator ID="ctvtackpack2" runat="server" ClientValidationFunction="IsFileUploaded"
                                                                    ControlToValidate="filetackpack2" Display="Dynamic" EnableClientScript="true"
                                                                    Enabled="true" ErrorMessage="tack pack Document Upload is required" ValidationGroup="Submit"> </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" class="commentbox">
                                        <table align="right" border="0" cellpadding="0" cellspacing="0" class="tbl_bordr"
                                            style="height: 100%; vertical-align: top" width="99%">
                                            <caption class="caption_headings">
                                                Comments
                                            </caption>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtComments" runat="server" CssClass="da_comment_text_area text-area"
                                                        Rows="5" TextMode="MultiLine" Width="98.2%" Height="72px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px;"
                                width="99%">
                                <tr>
                                    <td width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" class="tbl_bordr" width="100%">
                                                    <caption class="caption_headings">
                                                        Block References</caption>
                                                    <tr>
                                                        <td>
                                                            <table align="center" border="0" cellpadding="0" cellspacing="6" style="margin: 0px;"
                                                                width="100%">
                                                                <tr>
                                                                    <td class="inner_tbl_td">
                                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    Block:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtRefBlock1" runat="server" CssClass="ref-block" MaxLength="43"
                                                                                        Width="100%"></asp:TextBox>
                                                                                </td>
                                                                                <td width="18%">
                                                                                    <asp:FileUpload ID="UploadRef1" runat="server" CssClass="" />
                                                                                    <asp:HiddenField ID="HiddenRefId1" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Image ID="RefUrl1" runat="server" Height="20" Visible="false" Width="20" />
                                                                                    <asp:HyperLink ID="hyp1" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="ImgRef1" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    IND:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtIndBlock1" AutoPostBack="True" OnTextChanged="txtIndBlock1_TextChanged"
                                                                                        runat="server" CssClass="ind-block" MaxLength="43" Width="100%"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hiddenInd1Id" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HyperLink ID="hypInd1" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="imgInd1" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td width="26%">
                                                                                    <span class="da_add_more_dafo" style="display: none;"><a href="#">
                                                                                        <img src="../../App_Themes/ikandi/images/plus_icon.gif" border="0" title="Add more" />
                                                                                        Add more</a></span>
                                                                                    <asp:CheckBox ID="chkRefBlock1" runat="server" Text="Delete" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="inner_tbl_td">
                                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    Block:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtRefBlock2" runat="server" CssClass="ref-block " MaxLength="43"
                                                                                        Width="100%"></asp:TextBox>
                                                                                </td>
                                                                                <td width="18%">
                                                                                    <asp:FileUpload ID="UploadRef2" runat="server" />
                                                                                    <asp:HiddenField ID="HiddenRefId2" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Image ID="RefUrl2" runat="server" Height="20" Visible="false" Width="20" />
                                                                                    <asp:HyperLink ID="hyp2" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="ImgRef2" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    IND:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtIndBlock2" AutoPostBack="True" OnTextChanged="txtIndBlock2_TextChanged"
                                                                                        runat="server" CssClass="ind-block" MaxLength="43" Width="100%"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hiddenInd2Id" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HyperLink ID="hypInd2" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="imgInd2" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td width="26%">
                                                                                    <span class="da_add_more_dafo" style="display: none;"><a href="#">
                                                                                        <img src="../../App_Themes/ikandi/images/plus_icon.gif" border="0" title="Add more" />
                                                                                        Add more</a> </span>
                                                                                    <asp:CheckBox ID="chkRefBlock2" runat="server" Text="Delete" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="inner_tbl_td">
                                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    Block:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtRefBlock3" runat="server" CssClass="ref-block " MaxLength="43"
                                                                                        Width="100%"></asp:TextBox>
                                                                                </td>
                                                                                <td width="18%">
                                                                                    <asp:FileUpload ID="UploadRef3" runat="server" />
                                                                                    <asp:HiddenField ID="HiddenRefId3" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Image ID="RefUrl3" runat="server" Height="20" Visible="false" Width="20" />
                                                                                    <asp:HyperLink ID="hyp3" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="ImgRef3" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td class="td-sub_headings" width="3%">
                                                                                    IND:
                                                                                </td>
                                                                                <td align="left" width="24%">
                                                                                    <asp:TextBox ID="txtIndBlock3" AutoPostBack="True" OnTextChanged="txtIndBlock3_TextChanged"
                                                                                        runat="server" CssClass="ind-block" MaxLength="43" Width="100%"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hiddenInd3Id" runat="server" Value="-1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HyperLink ID="hypInd3" runat="server" CssClass="thickbox">
                                                                                        <asp:Image ID="imgInd3" runat="server" Width="20px" Height="20px" border="0 " align="right"
                                                                                            Visible="false" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" /></asp:HyperLink>
                                                                                </td>
                                                                                <td width="26%">
                                                                                    <span class="da_add_more_dafo" style="display: none;"><a href="#">
                                                                                        <img src="../../App_Themes/ikandi/images/plus_icon.gif" border="0" title="Add more" />
                                                                                        Add more</a></span>
                                                                                    <asp:CheckBox ID="chkRefBlock3" runat="server" Text="Delete" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px;"
                                width="99%">
                                <tr>
                                    <td width="50%">
                                        <table border="0" cellpadding="0" cellspacing="0" class="tbl_bordr" width="100%">
                                            <caption class="caption_headings">
                                                Planning &amp; Assignments</caption>
                                            <tr>
                                                <td>
                                                    <table align="center" border="0" cellpadding="0" cellspacing="6" style="margin: 0px;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="inner_tbl_td">
                                                                <table align="center" border="0" cellpadding="0" cellspacing="6" style="margin: 0px;"
                                                                    width="100%">
                                                                    <tr class="td-sub_headings">
                                                                        <td valign="bottom" width="12%">
                                                                            ETA
                                                                        </td>
                                                                        <td valign="bottom" width="29%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td valign="bottom" width="13%">
                                                                            Target Price
                                                                        </td>
                                                                        <td valign="bottom" width="23%">
                                                                            Sampling Merchandiser
                                                                        </td>
                                                                        <td valign="bottom" width="23%">
                                                                            Account Manager
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="inner_tbl_td">
                                                                            <asp:HiddenField ID="hdnPreviousETA" runat="server" />
                                                                            <asp:TextBox ID="txtETA" runat="server" CssClass="th style-eta date_style"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td scope="row" width="5%">
                                                                                        <asp:CheckBox ID="chkDefaultETA" runat="server" Checked="true" />
                                                                                    </td>
                                                                                    <td class="da_multiple_common" width="95%">
                                                                                        Please Choose If You Want The System to Default ETA
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td class="da_multiple_grey" valign="top">
                                                                                        (21 Days From Today)
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="inner_tbl_td">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="34%">
                                                                                        <asp:DropDownList ID="ddlCurrency" runat="server" Width="40px">
                                                                                            <asp:ListItem Text="Select.." Value="-1"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td width="66%">
                                                                                        <asp:TextBox ID="txtTarget" runat="server" CssClass="numeric-field-with-two-decimal-places"
                                                                                            MaxLength="10" Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="inner_tbl_td">
                                                                            <asp:DropDownList ID="ddlSampling" runat="server" Width="227">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateSamplingMerchant"
                                                                                ControlToValidate="ddlSampling" Display="Dynamic" Enabled="true" ErrorMessage="Please select Sampling Merchant"
                                                                                ValidationGroup="Submit"> </asp:CustomValidator>
                                                                        </td>
                                                                        <td class="inner_tbl_td">
                                                                            <asp:DropDownList ID="ddlAccMgr" runat="server" Width="227">
                                                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <table align="right" border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td align="left" class="da_created_by">
                        Created by:
                    </td>
                    <td class="da_created_by_name">
                        <asp:Label ID="lblDesignerName" runat="server"></asp:Label>
                        <span class="da_created_by">on</span>
                        <asp:Label ID="lblDateTime" runat="server" CssClass="date_style"></asp:Label>
                    </td>
                    <td class="da_created_by_name">
                        &nbsp;
                    </td>
                </tr>
                <tr id="trUpdatedBy" runat="server">
                    <td align="left" class="da_created_by">
                        Updated by:
                    </td>
                    <td class="da_created_by_name">
                        <asp:Label ID="lblUpdatedBy" runat="server"></asp:Label>
                        <span class="da_created_by">on</span>
                        <asp:Label ID="lblDateUpdated" runat="server" CssClass="date_style"></asp:Label>
                    </td>
                    <td class="da_created_by_name">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <!--created by end-->
    </asp:Panel>
    <%--<div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" OnClientClick="return CheckBlankPrintSolid(this);" OnClick="Submit_Click" />
        <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />
        <asp:Button runat="server" ID="btnSaveAs" CssClass="saveAs hide_me" OnClientClick="return CheckBlankPrintSolid(this);"  OnClick="SaveAs_Click" />
    </div>--%>
    <table border="0" cellspacing="4" cellpadding="4">
        <tr>
            <td>
                <asp:HiddenField ID="srvrHdnSeasonName" runat="server" />
                <input type="hidden" id="hdnSeasonName" name="hdnSeasonName" />
                <asp:Button runat="server" ID="btnSubmit" CssClass="da_submit_button submit" ValidationGroup="Submit"
                    CausesValidation="true" Text="Submit" OnClientClick="return CheckBlankPrintSolid(this);"
                    OnClick="Submit_Click" />
            </td>
            <td>
                <%--<input type="button" id="btnPrint" class="da_submit_button print" value="Print" onclick="return PrintPDF();" />--%>
                <input type="button" id="btnPrint" class="da_submit_button print" onclick="return prints()"
                    value="Print" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnSaveAs" CssClass="saveAs da_submit_button hide_me"
                    Text="Save As" OnClientClick="return CheckBlankPrintSolid(this);" OnClick="SaveAs_Click" />
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rdobtn" RepeatDirection="Horizontal" RepeatColumns="4"
                    Font-Bold="true">
                    <asp:ListItem Value="1" title="Digital Upload task created" Text="Direct Costing">  </asp:ListItem>
                    <asp:ListItem Value="2" title="Pattern cycle will execute" Text="Pattern based costing">  </asp:ListItem>
                    <asp:ListItem Value="3" title="Sampling cycle will execute" Text="Sample based costing"
                        Selected="True">  </asp:ListItem>
                    <%--<asp:ListItem Value="4" Text="Costing With Tech Pack">   </asp:ListItem>--%>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <div id="divBasicInfo1">
        <textarea id="templateBasicInfo" class="hide_me do-not-include">
<table cellspacing="5" width="98%" id="tblBasicInfo" class="CountTableRow">
 
            <tr>
                <td class="tdSpace">
                    Fabric:
                    </td>
                <td style="text-align:left;" >
                    Type:
                     </td>
               
                <td style="text-align:center;">
                    Remarks
                     </td>
                <td>
                     </td>
            </tr>
             <tr id="trFab0" class="tblFab0 hide_me RowCountTable">
                                <td colspan="3">
                                    <table id="tblFab0" class="tblFab1">
                                        <tr>
                                            <td valign="top" style="vertical-align:top;">
                                                <input id="txtStyleFabID0" name="txtStyleFabID0" type="hidden" value="-1" />
                                                <input id="txtIsDeleted0" name="txtIsDeleted0" type="hidden" value="0" />
                                                <input id="hdntotal0" name="hdntotal0" type="hidden" value="1" />
                                                <input id="hdnDyedRate0" name="hdnDyedRate0" value="0" type="hidden" />
                                                <input id="hdnPrintRate0" name="hdnPrintRate0" value="0" type="hidden" />                                                        
                                                <input id="hdnDigitalPrintRate0" name="hdnDigitalPrintRate0" value="0" type="hidden" />
                                                <input id="hdnGSM0" name="hdnGSM0" value="0" type="hidden" />
                                                <input id="hdnCC0" name="hdnCC0" value="0" type="hidden" />
                                                <input id="hdnCostWidth0" name="hdnCostWidth0" value="0" type="hidden" />
                                                <input id="hdnFabricQualityId0" name="hdnFabricQualityId0" value="0" type="hidden" />
                                                <input id="txtFabricName0" onblur="CheckFabricName(this)"  class="style-fabric" maxlength="300" name="txtFabricName0"
                                                  onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                <br />
                                                <label id="0" style="font-size: smaller">
                                                </label>
                                            </td>
                                            <td colspan="4" style="width:70%;">
                                                <table id="tblInner_0_1" class="fabInner">
                                                    <tr id="trInner_0_1">
                                                        <td>                                                        
                                                            <select id="ddlFabricType0_1" name="ddlFabricType0_1" size="1"><option value="-1">Select..</option><option value="0">Dyed</option><option value="1">Print</option><option value="2">Digital Print</option>
                                                            </select>
                                                        </td>
                                                        <td valign="top" style="width:60%;">
                                                            <span id="spanPrint0_1" class="hide_me" name="spanPrint0_1"><nobr>Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                <input id="txtPrint0_1" class="ScreenPrint" onblur="CheckDuplicateFabricDetails(this)" name="txtPrint0_1" style="width: 300px"
                                                                    type="text" /></span> 
                                                                    <span id="spanDgtlPrint0_1" class="hide_me" name="spanDgtlPrint0_1"><nobr>Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                <input id="txtDgtlPrint0_1" class="DigitalPrint" onblur="CheckDuplicateFabricDetails(this)" name="txtDgtlPrint0_1" style="width: 300px"
                                                                    type="text" /></span>
                                                                    
                                                                    <span id="spanOther0_1" class="hide_me" name="spanOther0_1"><nobr>Dyed/Solid:&nbsp;&nbsp;&nbsp;</nobr>
                                                                        <input id="txtSpecialFabricDetails0_1" maxlength="190" onblur="CheckDuplicateFabricDetails(this)" name="txtSpecialFabricDetails0_1" onpaste="return false;"
                                                                            style="width: 300px" class="ColorSolid" type="text" /></span> <span id="spanAdd0_1" name="spanAdd0_1">
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <input id="txtRemarks0_1" maxlength="190" name="txtRemarks0_1" style="width: 300px"
                                                                type="text" />
                                                        </td>
                                                        <td>
                                                            <img id="btnAddRow0_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                            <img id="btnDeleteRow0_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            <td>
                                    <img id="imgFabHide0" onclick="deleteRowFinal(this)"  src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                    Remove</td></tr>
          {#foreach $T.table as record} 
            <%--<tr>
                <td>
                <input type="hidden" value="{$T.record.Id}" id="txtStyleFabID{$P.x}" name="txtStyleFabID{$P.x}" />
                <input type="text" style="width:300px" onkeyup="checkFab(this)" onblur="checkFab(this)" class="style-fabric" name="txtFabricName{$P.x}" id="txtFabricName{$P.x}" value="{$T.record.FabricName}" maxlength="30" /><br />
                <label id="{$P.x-1}">{$T.record.CCGSM}</label>
               <input type="hidden"  name="txtIsDeleted{$P.x}" id="txtIsDeleted{$P.x}" />
                </td>
               <td>
                    <select id="ddlFabricType1_{$P.x}" size="1" name="ddlFabricType1_{$P.x}" ><option value="-1"{#if $T.record.FabricType == '-1' } selected {#/if}>Select..</option><option value="1"{#if $T.record.FabricType == '1' } selected {#/if}>Print</option><option value="2"{#if $T.record.FabricType == '2' } selected {#/if}>Solid</option><option value="3"{#if $T.record.FabricType == '3' } selected {#/if}>Special</option>
                    </select>
                </td>
                <td valign="top">
               <span id="spanPrint1_{$P.x}" name="spanPrint1_{$P.x}" class="hide_me"> PRINT ID : <input type="text" style="width:300px"  name="txtPrint1_{$P.x}" id="txtPrint1_{$P.x}"  value="{$T.record.PrintNumber}" class="print-number " maxlength="10"/></span>                   
                 
                   <span id ="spanOther1_{$P.x}" name="spanOther1_{$P.x}" class="hide_me"> Spcl/Solid : <input type="text" style="width:300px"  name="txtSpecialFabricDetails1_{$P.x}" id="txtSpecialFabricDetails1_{$P.x}" value="{$T.record.SpecialFabricDetails}" maxlength="20" /></span>
                </td>
                <td>
                     <input type="text"  name="txtRemarks1_{$P.x}" id="txtRemarks1_{$P.x}" style="width:300px"  value="{$T.record.Remarks}" maxlength="190"/>
                </td>
                 <td>
                    <img src="../../App_Themes/ikandi/images/minus_icon.gif" id="btnDeleteRow"  onclick="deleteRow( this)" />
                </td>
              
            </tr>--%>
            <tr id="trFab{$P.x}" class="tblFab1 RowCountTable">
            <td colspan="3">
               <table id="tblFab{$P.x}" class="tblFab1">
                                        <tr>
                                            <td valign="top" style="vertical-align:top;">
                                                <input id="txtStyleFabID{$P.x}" name="txtStyleFabID{$P.x}" type="hidden" value="-1" />
                                                <input id="txtIsDeleted{$P.x}" name="txtIsDeleted{$P.x}" type="hidden" value="0" />
                                                <input id="hdntotal{$P.x}" name="hdntotal{$P.x}" type="hidden" value="1" />
                                                <input id="hdnDyedRate{$P.x}" name="hdnDyedRate{$P.x}" value="{$T.record.DyedRate}" type="hidden" />
                                                <input id="hdnPrintRate{$P.x}" name="hdnPrintRate{$P.x}" value="{$T.record.PrintRate}" type="hidden" />                                                        
                                                <input id="hdnDigitalPrintRate{$P.x}" name="hdnDigitalPrintRate{$P.x}" value="{$T.record.DigitalPrintRate}" type="hidden" />
                                                <input id="hdnGSM{$P.x}" name="hdnGSM{$P.x}" value="{$T.record.GSM}" type="hidden" />
                                                <input id="hdnCC{$P.x}" name="hdnCC{$P.x}" value="{$T.record.CountConstruct}" type="hidden" />
                                                <input id="hdnCostWidth{$P.x}" name="hdnCostWidth{$P.x}" value="{$T.record.CostWidth}" type="hidden" />
                                                <input id="hdnFabricQualityId{$P.x}" name="hdnFabricQualityId{$P.x}" value="{$T.record.FabricQualityId}" type="hidden" />
                                                <input id="txtFabricName{$P.x}" onblur="CheckFabricName(this)"  class="style-fabric" maxlength="300" name="txtFabricName{$P.x}"
                                                   value="{$T.record.FabricName}"  onkeyup="checkFab(this)" style="width: 300px" type="text" />
                                                <br />
                                                <label id="{$P.x}" style="font-size: smaller">{$T.record.CCGSM}
                                                </label>
                                            </td>
                                            <td colspan="4" style="width:70%;">
                                                <table id="tblInner_{$P.x}_1" class="fabInner">
                                                    <tr id="trInner_{$P.x}_1">
                                                        <td>                                                       
                                                            <select id="ddlFabricType{$P.x}_1" name="ddlFabricType{$P.x}_1" size="1" onchange="onFabricChange1({$P.x},1)"><option value="-1"{#if $T.record.FabricType == '-1' } selected {#/if}>Select..</option><option value="0"{#if $T.record.FabricType == '0' } selected {#/if}>Dyed</option><option value="1"{#if $T.record.FabricType == '1' } selected {#/if}>Screen Print</option><option value="2"{#if $T.record.FabricType == '2' } selected {#/if}>Digital Print</option>
                                                            </select>
                                                        </td>
                                                        <td valign="top" style="width:60%;">
                                                            <span id="spanPrint{$P.x}_1" {#if $T.record.FabTypeDetails == 'DIGITAL PRINT' } class="hide_me" {#/if} {#if $T.record.FabTypeDetails == 'DYED' } class="hide_me" {#/if} name="spanPrint{$P.x}_1"><nobr>Screen Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                <input id="txtPrint{$P.x}_1" class="ScreenPrint" onblur="CheckDuplicateFabricDetails(this)" name="txtPrint{$P.x}_1" style="width: 300px"
                                                                    value="{$T.record.FabricDesc}" type="text" /></span> 
                                                            <span id="spanDgtlPrint{$P.x}_1" {#if $T.record.FabTypeDetails == 'PRINT' } class="hide_me" {#/if} {#if $T.record.FabTypeDetails == 'DYED' } class="hide_me" {#/if} name="spanDgtlPrint{$P.x}_1"><nobr>Digital Print Number:&nbsp;&nbsp;&nbsp;</nobr>
                                                                <input id="txtDgtlPrint{$P.x}_1" class="DigitalPrint" onblur="CheckDuplicateFabricDetails(this)" name="txtDgtlPrint{$P.x}_1" style="width: 300px"
                                                                    value="{$T.record.FabricDesc}" type="text" /></span> 
                                                            <span id="spanOther{$P.x}_1" {#if $T.record.PrintNumber != '' } class="hide_me" {#/if}  name="spanOther{$P.x}_1">Dyed/Solid:&nbsp;&nbsp;&nbsp;
                                                                        <input id="txtSpecialFabricDetails{$P.x}_1" class="ColorSolid" maxlength="190" onblur="CheckDuplicateFabricDetails(this)" name="txtSpecialFabricDetails{$P.x}_1"
                                                                           value="{$T.record.FabricDesc}" style="width: 300px" type="text" /></span> 
                                                            <span id="spanAdd{$P.x}_1" name="spanAdd{$P.x}_1">
                                                                       <img id="Img{$P.x}" class="hide_me" src="../../App_Themes/ikandi/images/plus_icon.gif" style="visibility: hidden" /></span>
                                                        </td>
                                                        <td>
                                                            <input id="txtRemarks{$P.x}_1" maxlength="190" name="txtRemarks{$P.x}_1" style="width: 300px"
                                                               value="{$T.record.Remarks}"  type="text" />
                                                        </td>
                                                        <td>
                                                            <img id="btnAddRow{$P.x}_1" class="hide_me" onclick="addRow_new(this)" src="../../App_Themes/ikandi/images/plus_icon.gif" />
                                                            <img id="btnDeleteRow{$P.x}_1" class="hide_me" onclick="deleteRow_new(this)" src="../../App_Themes/ikandi/images/minus_icon.gif" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr></table></td> 
            <td>
                <span id="imgFabHideSpan{$P.x}"><img id="imgFabHide{$P.x}" onclick="deleteRow({$P.x})" src="../../App_Themes/ikandi/images/minus_icon.gif" />Remove</span>
                </td></tr>
            {#param name=x value=$P.x+1}
			{#/for}
        </table>
</textarea>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <%--  <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>--%>
            <td width="1205">
             <h2 style="width: 100%;background: #39589c;text-align:center;position: relative;font-size:15px; margin: 0px 0px;padding: 2px 0px">
                   Confirmation
            </h2>
                
            </td>
          <%--  <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>--%>
        </tr>
    </table>
    <div class="form_box">
        <div class="text-content" style="text-transform: capitalize;">
            Design have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/Design/DesignListing.aspx" runat="server">Click here</a>
            to Design List.</div>
    </div>
</asp:Panel>
