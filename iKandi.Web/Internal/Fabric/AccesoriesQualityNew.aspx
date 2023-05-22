<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccesoriesQualityNew.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.AccesoriesQualityNew" MasterPageFile="~/layout/Secure.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <%-- <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>--%>
    <link href="../../js/wickedpicker.min.css" rel="stylesheet" type="text/css" />
    <%--<script src="../../js/wickedpicker.min.js" type="text/javascript"></script>--%>
    <%--<script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <%-- <script type="text/javascript" src="../../js/form.js"></script>--%>
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana !important;
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
            font-weight: normal;
            color: #575759;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border-color: #999;
        }
        table td
        {
            font-size: 11px;
            text-align: center;
            border-color: #dbd8d8;
            text-transform: capitalize;
            color: gray;
            padding: 2px 0px;
        }
        .AddClass_Table th
        {
            background: #dddfe4;
        }
        .item_list1 td, .item_list1 th
        {
            padding: 5px 0px !important;
        }
        .item_list1 td
        {
            border-color: #dbd8d8;
        }
        
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        h2
        {
            width: 845px;
        }
        h3
        {
            font-size: 11px;
            font-weight: bold;
            padding: 5px;
            background: #39589C;
            color: #fff;
            width: 150px;
            text-align: center;
            margin: 0px;
            border-radius: 5px 5px 0px 0px;
            text-transform: capitalize;
            letter-spacing: 1px;
        }
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        
        table td table td
        {
            border-color: #dbd8d8;
        }
        
        
        .SUPPLY-MANA td input
        {
            width: 35%;
        }
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        .submit
        {
            cursor: pointer;
            border-radius: 2px;
        }
        .process
        {
            padding: 0px;
            margin: 0px;
        }
        .process li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li input
        {
            width: 10%;
        }
        .supply_type
        {
            padding: 0px;
            margin: 0px;
        }
        .supply_type li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li:last-child
        {
            border-bottom: 0px;
        }
        /*input[type="text"], select
        {
            width: 95% !important;
            color: gray !important;
            text-transform: capitalize !important;
            background-color: White;
        }*/
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }
        .ths
        {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }
        .grds
        {
            margin-left: 20px;
        }
        
        .show, .hide
        {
            cursor: pointer;
        }
        a.UpdateBtn
        {
            background: url(../../images/update-new.png) no-repeat left top;
            padding-left: 25px;
            padding-top: 4px;
        }
        .CancelButton img
        {
            width: 24px;
        }
        
        a.DeleteBtn
        {
            background: url(../../images/delete-icon.png) no-repeat left top;
            padding-left: 25px;
            padding-top: 3px;
        }
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 0px;
            border: 1px solid #888;
            width: 550px;
            margin-top: 12%;
            border: 5px solid #999;
            border-radius: 5px;
        }
        
        .UpdateModal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 0px;
            border: 1px solid #888;
            width: 320px;
            margin-top: 12%;
            border: 5px solid #999;
            border-radius: 5px;
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
        .inputborder
        {
            border: 1px solid #cccccc !important;
        }
        .inputborder tr:nth-last-child(1) > td .Browse
        {
            color: Blue;
            cursor: pointer;
        }
        a
        {
            text-decoration: none;
        }
        a:hover
        {
            text-decoration: none;
        }
        .go
        {
            cursor: pointer;
            border-radius: 2px;
            padding: 2px 5px;
        }
        .go:hover
        {
            padding: 2px 5px;
        }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 5px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #b8b4b4 !important;
            border: 1px solid #b8b4b4 !important;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb:hover
        {
            background: #999 !important;
            border: 1px solid #999 !important;
            border-radius: 10px;
        }
        .validation_messagebox
        {
            border-color: #999 !important;
        }
        .Browse.ColorBlue
        {
            color: Blue;
            cursor: pointer;
        }
        /*  table tr:nth-last-child(1) > td
        {
            border-bottom-color: #dbd8d8 !important;
        }*/
        table.footer tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        table.bottom_boder
        {
            border-top: 0px !important;
        }
        
        .item_list1.bottom_boder1 th
        {
            border: 1px solid #999 !important;
        }
        table.bottom_boder tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        table.bottom_boder tr td:first-child
        {
            border-left-color: #999 !important;
        }
        table.bottom_boder tr td:last-child
        {
            border-right-color: #999 !important;
        }
        .bottomRowVali TD input[type=text].ValidationBorder, .bottomRowVali TD select.ValidationBorder
        {
            border: 1px solid #FF0000 !important;
        }
        TD input[type=text].ValidationBorder
        {
            border: 1px solid #FF0000 !important;
        }
        
        .bottomRowVali TD input[type=text]
        {
            text-align: center;
        }
        .bottomRowVali
        {
            border: 0px;
        }
        td[colspan="9"]
        {
            border-left-color: #999;
            border-right-color: #999;
            border-bottom-color: #999;
            border: 0px;
            padding: 2px 0px !important;
        }
        td[colspan="8"] span
        {
            color: Blue;
            cursor: default;
            padding-right: 3px;
        }
        td[colspan="8"] a
        {
            color: gray;
            padding-right: 3px;
        }
        #sb-wrapper
        {
            border: 5px solid #999;
            background: #fff;
            border-radius: 5px;
        }
        #sb-title
        {
            display: none;
        }
        .inputSizecenter td input[type="text"]
        {
            text-align: center;
        }
        .borderBottom td
        {
            border-bottom: 1px solid #999 !important;
        }
        .modalNew
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        .modal-content
        {
            width: 800px;
            margin: auto;
            background: #fff;
            border: 5px solid #999;
            border-radius: 5px;
            min-height: 300px;
            max-height: 320px;
            overflow: auto;
        }
        .HistoryHeader
        {
            background: #39589c;
            color: #fff;
            text-align: center;
            font-size: 14px;
        }
        #HistoryDescription
        {
            padding: 7px !important;
        }
        table.bottom_boder tr:first-child > td
        {
            border-top: 0px;
        }
        table#ctl00_cph_main_content_grdsize
        {
            border: 0px !important;
        }
        table#ctl00_cph_main_content_grdsize tr:first-child > td
        {
            border-top: 0px !important;
        }
        .EmptyRowBorder td
        {
            border: 0px;
        }
        .borderRed
        {
            border-color: Red !important;
        }
        .AccessoryPopup1
        {
            text-align: left;
            padding-left: 5px;
            width: 120px;
        }
        
        .AccessoryPopup2
        {
            text-align: left;
            padding-left: 5px;
            width: 200px;
        }
        
        .DisableCheckBox
        {
            cursor: not-allowed;
            pointer-events: none;
            color: #c0c0c0; /*background-color: #ffffff;*/
        }
        .lnkCursor
        {
            cursor: pointer;
        }
        .item_list1 TD input[type=text]
        {
            width: 90% !important;
        }
    </style>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        var hdnUnitClientId = '<%=hdnUnitId.ClientID%>';
        var lblUnitClientId = '<%=lblUnit.ClientID%>';
        var txt_Acc_Wastage = '<%=txtWastage.ClientID%>';

        var chkIsDefaultClientId = '<%=chkIsDefault.ClientID%>';
        var ddlGroupClientId = '<%=ddlGroup.ClientID%>';
        var txtQualityClientId = '<%=txtQuality.ClientID%>';
        var hdnUserIdClientId = '<%=hdnUserId.ClientID%>';
        var btnAddAccessoryClientId = '<%=btnAddAccessory.ClientID%>';

        function isNumberKeyWithDecimal(evt, obj) {
            /// debugger;     
            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function isNumberKeyandCheckZero(evt, elem) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function validateAndHighlight() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid) {
                        ctrl.classList.add("ValidationBorder");
                    }
                    else {
                        ctrl.classList.remove("ValidationBorder");
                    }
                }
            }
        }

        function chkSelection(list, oldvalue) {
            //debugger;
            var SizeCount = $("#ctl00_cph_main_content_hdnSizeCount").val();
            var SiplitIds = list.id.split("_");
            var rowid = SiplitIds[5];
            var IsValid = 1;

            var suplytype = "";
            var currListValue = list.value; //Remember selection of current list.
            var arrSelect = new Array(); //Array to hold all select lists
            arrSelect = document.getElementsByClassName('SuppCheck'); //Get lists by tag name so as have no problems of different grouping etc.
            var chkCtr = 0;
            for (var i = 0; i < arrSelect.length; i++) {
                if ($('#' + arrSelect.item(i).id).val() == currListValue) {
                    chkCtr = chkCtr + 1;
                }
            }
            if (chkCtr > 1) {
                alert('Duplicate supplier name not allowed!');
                if (oldvalue == "-1") {
                    list.value = "0";
                    currListValue = oldvalue;

                }
                else {
                    list.value = oldvalue;
                    currListValue = oldvalue;
                    //return;
                }
            }


            proxy.invoke("GetSupplierSelectedType", { Supplierid: currListValue },
                        function (result) {
                            //debugger;
                            //   suplytype = result;
                            //  alert(result);
                            var str = result;
                            if (IsValid == 0) {
                                str = 0;
                            }
                            else {
                                str = result;
                            }
                            //alert(str);

                            if (parseInt(SizeCount) > 0) {
                                for (var x = 0; x < parseInt(SizeCount); x++) {
                                    document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkGrigete_" + x).checked = false;
                                    document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkchckProcess_" + x).checked = false;
                                    document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkFinalPrice_" + x).checked = false;
                                }
                            }

                            var str_array = str.split(',');
                            if (str != 0) {
                                for (var i = 0; i < str_array.length; i++) {
                                    // Trim the excess whitespace.
                                    str_array[i] = str_array[i].replace(/^\s*/, "").replace(/\s*$/, "");
                                    // Add additional code here, such as:
                                    //alert(str_array[i]);
                                    // debugger;
                                    if (str_array[i] == 4) {

                                        if (parseInt(SizeCount) > 0) {
                                            for (var G = 0; G < parseInt(SizeCount); G++) {
                                                //$("#ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkGrigete_" + G).attr('checked', 'checked');
                                                document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkGrigete_" + G).checked = true;
                                            }
                                        }
                                    }
                                    if (str_array[i] == 5) {

                                        if (parseInt(SizeCount) > 0) {
                                            for (var P = 0; P < parseInt(SizeCount); P++) {
                                                //$("#ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkchckProcess_" + P).attr('checked', 'checked');
                                                document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkchckProcess_" + P).checked = true;
                                            }
                                        }
                                    }
                                    if (str_array[i] == 7) {

                                        if (parseInt(SizeCount) > 0) {
                                            for (var F = 0; F < parseInt(SizeCount); F++) {
                                                document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkFinalPrice_" + F).checked = true;

                                            }
                                        }

                                    }

                                }
                            }
                            else {
                                if (parseInt(SizeCount) > 0) {
                                    for (var x = 0; x < parseInt(SizeCount); x++) {
                                        document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkGrigete_" + x).checked = false;
                                    }
                                }
                                if (parseInt(SizeCount) > 0) {
                                    for (var y = 0; y < parseInt(SizeCount); y++) {
                                        document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkchckProcess_" + y).checked = false;
                                    }
                                }
                                if (parseInt(SizeCount) > 0) {
                                    for (var z = 0; z < parseInt(SizeCount); z++) {
                                        document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_chkFinalPrice_" + z).checked = false;
                                    }
                                }
                            }
                        });

        }
        function chkSelectionddd(list, oldvalue) {
            //debugger;
            var currListValue = list.value; //Remember selection of current list.
            var arrSelect = new Array(); //Array to hold all select lists
            arrSelect = document.getElementsByClassName('SuppCheck'); //Get lists by tag name so as have no problems of different grouping etc.
            var chkCtr = 0;
            for (var i = 0; i < arrSelect.length; i++) {

                if (document.getElementById(arrSelect.item(i).id).value == currListValue) {
                    chkCtr = chkCtr + 1;
                }
            }
            if (chkCtr > 1) {
                alert('Duplicate supplier name not allowed!');
                if (oldvalue == "-1") {
                    list.value = "0"
                }
                else {
                    list.value = oldvalue;
                }
            }
        }
        function preventInput(evnt) {
            //Checked In IE9,Chrome,FireFox
            if (evnt.which != 9) evnt.preventDefault();
        }
        $(function () {
            $('input').keypress(function (e) {
                if (this.value.length == 0 && e.which == 48) {
                    return false;
                }
            });
            $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });

            $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^\d].+/, ""));
                if ((event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            $("input[type='text']").each(function () {
                $(this).attr('autocomplete', 'off');
            })

            //$('#txt_userid').attr('autocomplete', 'off');  
        });
        function pageLoad() {
            $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });

            $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^\d].+/, ""));
                if ((event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });
            $("input[type='text']").each(function () {
                $(this).attr('autocomplete', 'off');
            })

        }
        function ShowSizeDiv() {
            //debugger;
            $("#ctl00_cph_main_content_divFinish").css("display", "block");

            $("#" + "ctl00_cph_main_content_txtsizeAdd").val("");
            $("#" + "ctl00_cph_main_content_txtgreigeAdd").val("");
            $("#" + "ctl00_cph_main_content_txtprocessAdd").val("");
            $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
            $("#" + "ctl00_cph_main_content_lblshry").val("");
            $("#" + "ctl00_cph_main_content_lblwast").val("");

            if ($(".gvRow").length == 0) {

                var hdnIsdefaultval = document.getElementById("ctl00_cph_main_content_hdnIsdefault").value;
                if (hdnIsdefaultval == "True") {
                    $("#" + "ctl00_cph_main_content_txtsizeAdd").val("Default");
                }
            }
        }
        function CalculatePricePrice(elem) {
            //debugger;
            //  $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val();
            var SizeCount = $("#ctl00_cph_main_content_hdnSizeCount").val();
            var Shrinkage = 0;
            var valprice = 0;
            var Wastage = 0;

            var SiplitIds = elem.id.split("_");
            var rowid = SiplitIds[5];
            var idtxtpriceSeq = SiplitIds[3];
            var Wastageval = $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Wastage").html();
            if (Wastageval == "0" || Wastageval == "") {
                Wastage = 0;
            }
            else {
                Wastage = parseFloat(Wastageval);
            }
            var ddltype = $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Type").val();
            if (ddltype == "0" || ddltype == "Finished") {
                $("#" + "ctl00_cph_main_content_grdsizedynamic" + rowid + "_Shrinkage").val("");
                Shrinkage = 0;
                //                document.getElementById("grdsizedynamic_" + rowid + "_Shrinkage").disabled = true;
                document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").setAttribute('readonly', 'readonly');
                document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").style.backgroundColor = '#cccccc';
                $("#ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").closest("td").css("background-color", "#cccccc");
            }
            else {
                if ($("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").val() != "") {
                    Shrinkage = parseFloat($("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").val());
                }

                if (ddltype == "GreigeToFinished") {
                    //debugger;
                    $("#ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").closest("td").css("background", "#ffffff");
                    document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").removeAttribute("style");
                    document.getElementById("ctl00_cph_main_content_grdsizedynamic_" + rowid + "_Shrinkage").removeAttribute('readonly');
                }
            }
            if (parseInt(SizeCount) > 0) {
                for (var i = 0; i <= parseInt(SizeCount); i++) {
                    var Finalprice = 0;
                    var txtprice = $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_textBoxprice_" + i).val();
                    if (txtprice == "") {
                        txtprice = parseFloat(txtprice);
                    }
                    var shrinkPer = ((((parseFloat(txtprice) * parseFloat(Shrinkage)) / parseFloat(100))) + parseFloat(txtprice));
                    var Totalwastageper = (parseFloat(txtprice) + ((parseFloat(shrinkPer) * parseFloat(Wastage)) / parseFloat(100)));
                    var FinalPrice = Math.round(Totalwastageper);
                    if (FinalPrice > 0) {
                        $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_textBoxFinalprice_" + i).val(FinalPrice);
                    }
                    else {
                        $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_textBoxFinalprice_" + i).val("");
                    }
                }
            }
            //alert(valprice);
        }
        function showpopup(id) {
            $("#ctl00_cph_main_content_divFinish").css("display", "block"); ;
        }
        function HidePopUp() {
            $("#ctl00_cph_main_content_divFinish").css("display", "none"); ;
            return false;
        }

        function checkZero(evnt) {
            //   debugger;
            var Id = evnt.id;
            var SiplitIds = evnt.id.split("_");
            var rowid = SiplitIds[5];
            var x = evnt.value;
            if (x == "" || x == "0") {
                document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value = "";
                document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").value = "";
            }
        }
        function checkZerofoter(evnt) {
            var x = document.getElementById("ctl00_cph_main_content_txtgreigeAdd").value;
            if (x == "" || x == "0") {
                document.getElementById("ctl00_cph_main_content_txtprocessAdd").value = "";
                document.getElementById("ctl00_cph_main_content_txtfinishAdd").value = "";
            }
        }
        function CalculateGriegeFinhish(elem, row) {
            //debugger;
            var Wastge = 0;
            var shrikkage = 0;
            var GreigePrice = 0;
            var ProcessPrice = 0;
            var finishPricre = 0;

            Wastge = $("#" + "ctl00_cph_main_content_hdnwastage").val();
            shrikkage = $("#" + "ctl00_cph_main_content_hdnshrinkage").val();

            if (Wastge == "") {
                Wastge = 0;
            }
            if (shrikkage == "") {
                shrikkage = 0;
            }
            if (row == "Item") {

                var Id = elem.id;
                var SiplitIds = elem.id.split("_");
                var rowid = SiplitIds[5];

                document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").removeAttribute('disabled');
                var GreigePrice = 0;
                var ProcessPrice = 0;
                GreigePrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditgreige").val();
                ProcessPrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val();
                finishPricre = document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value;
                if (GreigePrice == "") {
                    GreigePrice = 0;
                }
                if (ProcessPrice == "") {
                    ProcessPrice = 0;
                }
                GreigePrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditgreige").val();
                ProcessPrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val();
                if (GreigePrice == "") {
                    GreigePrice = 0;
                }
                if (ProcessPrice == "") {
                    ProcessPrice = 0;
                }
                if (finishPricre == "") {
                    finishPricre = 0;
                }
                if (GreigePrice == 0) {
                    GreigePrice = 0;
                    ProcessPrice = 0;
                    //finishPricre = 0;
                    //$("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val("");
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").setAttribute('readonly', 'readonly');
                }
                if (GreigePrice == 0 && ProcessPrice == 0) {
                    //                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val("");
                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val("");

                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").removeAttribute('readonly');
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").setAttribute('readonly', 'readonly');
                }
                if (GreigePrice != 0) {
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").removeAttribute('readonly');
                }
                else if (finishPricre != 0) {
                    shrinkPer = (parseFloat(finishPricre) * parseFloat(Wastge)) / parseFloat(100);
                    FinalPrice = parseFloat(finishPricre) + parseFloat(Math.round(shrinkPer));
                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val(FinalPrice);
                    return;
                }
                else {
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").setAttribute('readonly', 'readonly');
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").setAttribute('readonly', 'readonly');
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").value = "";
                    if ($("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").attr("readonly") == true) {

                    }
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value = "";
                }
                if (GreigePrice == 0 && ProcessPrice == 0) {
                    GreigePrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditgreige").val();
                    ProcessPrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val();
                    finishPricre = document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value;

                    if (GreigePrice == "") {
                        GreigePrice = 0;
                    }
                    if (ProcessPrice == "") {
                        ProcessPrice = 0;
                    }
                    if (finishPricre == "") {
                        finishPricre = 0;
                    }

                    shrinkPer = (parseFloat(finishPricre) * parseFloat(Wastge)) / parseFloat(100);
                    FinalPrice = parseFloat(finishPricre) + parseFloat(Math.round(shrinkPer));
                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val(FinalPrice);
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").removeAttribute('readonly');
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value = "";
                }
                else {
                    GreigePrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditgreige").val();
                    ProcessPrice = $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val();
                    finishPricre = document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").value;

                    if (GreigePrice == "") {
                        GreigePrice = 0;
                    }
                    if (ProcessPrice == "") {
                        ProcessPrice = 0;
                    }
                    if (finishPricre == "") {
                        finishPricre = 0;
                    }
                    var shrinkPer = (parseFloat(GreigePrice) + parseFloat(ProcessPrice)) * (1 + (parseFloat(shrikkage) / parseFloat(100)));
                    var Totalwastageper = (parseFloat(shrinkPer)) * (1 + (parseFloat(Wastge) / parseFloat(100)));
                    // var FinalPrice = Math.round(Totalwastageper);
                    var FinalPrice = Totalwastageper.toFixed(2);
                }
                if ($("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditgreige").val() == "") {

                }
                if (FinalPrice > 0) {

                    if (GreigePrice != 0) {
                        $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val(FinalPrice);
                        document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").setAttribute('readonly', 'readonly');
                    }
                    else if (GreigePrice == 0) {
                        $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val(FinalPrice);
                        document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").removeAttribute('readonly');
                    }
                }
                else {
                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val("");
                    $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").val("");
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditProcess").setAttribute('readonly', 'readonly');
                    document.getElementById("ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").removeAttribute('readonly');
                }

            }
            else {
                if (row == 'Foter') {
                    document.getElementById("ctl00_cph_main_content_txtfinishAdd").setAttribute('readonly', 'readonly');
                    var hdnIsdefaultval = document.getElementById("ctl00_cph_main_content_hdnIsdefault").value;

                    if (hdnIsdefaultval == "True") {
                        if ($('#ctl00_cph_main_content_ddlISdefaultFooter option:selected').text() == "Select") {
                            alert("First Select Default Size ");
                            $("#" + "ctl00_cph_main_content_txtgreigeAdd").val("");
                            $("#" + "ctl00_cph_main_content_txtprocessAdd").val("");
                            $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
                            document.getElementById("ctl00_cph_main_content_txtfinishAdd").removeAttribute('readonly');
                            return false;
                        }
                    }
                    else {
                        if ($("#" + "ctl00_cph_main_content_txtsizeAdd").val() == "") {
                            alert("First add size name!");
                            $("#" + "ctl00_cph_main_content_txtgreigeAdd").val("");
                            $("#" + "ctl00_cph_main_content_txtprocessAdd").val("");
                            $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
                            document.getElementById("ctl00_cph_main_content_txtfinishAdd").removeAttribute('readonly');
                            return false;
                        }
                    }
                    var Id = elem.id;
                    var SiplitIds = elem.id.split("_");
                    var rowid = SiplitIds[4];
                    document.getElementById("ctl00_cph_main_content_txtgreigeAdd").removeAttribute('readonly');
                    var GreigePrice = 0;
                    var ProcessPrice = 0;
                    GreigePrice = $("#" + "ctl00_cph_main_content_txtgreigeAdd").val();
                    ProcessPrice = $("#" + "ctl00_cph_main_content_txtprocessAdd").val();
                    finishPricre = $("#" + "ctl00_cph_main_content_txtfinishAdd").val();

                    if (GreigePrice == "") {
                        GreigePrice = 0;
                    }
                    if (ProcessPrice == "") {
                        ProcessPrice = 0;
                    }
                    if (finishPricre == "") {
                        finishPricre = 0;
                    }
                    GreigePrice = $("#" + "ctl00_cph_main_content_txtgreigeAdd").val();
                    ProcessPrice = $("#" + "ctl00_cph_main_content_txtprocessAdd").val();
                    if (GreigePrice == 0) {
                        GreigePrice = 0;
                        ProcessPrice = 0;
                        finishPricre = 0;
                    }
                    if (GreigePrice == "") {
                        GreigePrice = 0;
                    }
                    if (ProcessPrice == "") {
                        ProcessPrice = 0;
                    }

                    if (GreigePrice == 0 && ProcessPrice == 0) {
                        //                        $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
                        $("#" + "ctl00_cph_main_content_txtprocessAdd").val("");
                        document.getElementById("ctl00_cph_main_content_txtfinishAdd").removeAttribute('readonly');
                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").setAttribute('readonly', 'readonly');
                    }
                    if (GreigePrice != 0) {

                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").removeAttribute('disabled');
                    }
                    else {
                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").setAttribute('readonly', 'readonly');

                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").setAttribute('readonly', 'readonly');
                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").value = "";

                    }

                    var shrinkPe = 0;
                    var Totalwastageper = 0;
                    var FinalPrice = 0;
                    if (GreigePrice == 0 && ProcessPrice == 0) {
                        GreigePrice = 0;
                        ProcessPrice = 0;
                        finishPricre = 0;

                        GreigePrice = $("#" + "ctl00_cph_main_content_txtgreigeAdd").val();
                        ProcessPrice = $("#" + "ctl00_cph_main_content_txtprocessAdd").val();
                        finishPricre = $("#" + "ctl00_cph_main_content_txtfinishAdd").val();
                        if (GreigePrice == "") {
                            GreigePrice = 0;
                        }
                        if (ProcessPrice == "") {
                            ProcessPrice = 0;
                        }
                        if (finishPricre == "") {
                            finishPricre = 0;
                        }
                        shrinkPer = (parseFloat(finishPricre) * parseFloat(Wastge)) / parseFloat(100)
                        //FinalPrice = parseFloat(finishPricre) + parseFloat(Math.round(shrinkPer));
                        FinalPrice = parseFloat(finishPricre) + parseFloat(shrinkPer);
                        FinalPrice = FinalPrice.toFixed(2);
                        $("#" + "ctl00_cph_main_content_txtfinishAdd").val(FinalPrice);
                    }
                    else {

                        GreigePrice = $("#" + "ctl00_cph_main_content_txtgreigeAdd").val();
                        ProcessPrice = $("#" + "ctl00_cph_main_content_txtprocessAdd").val();
                        finishPricre = $("#" + "ctl00_cph_main_content_txtfinishAdd").val();

                        if (GreigePrice == "") {
                            GreigePrice = 0;
                        }
                        if (ProcessPrice == "") {
                            ProcessPrice = 0;
                        }
                        if (finishPricre == "") {
                            finishPricre = 0;
                        }
                        if (shrikkage == "") {
                            shrikkage = 0;
                        }

                        shrinkPer = (parseFloat(GreigePrice) + parseFloat(ProcessPrice)) * (1 + (parseFloat(shrikkage) / parseFloat(100)));
                        Totalwastageper = (parseFloat(shrinkPer)) * (1 + (parseFloat(Wastge) / parseFloat(100)));
                        // FinalPrice = Math.round(Totalwastageper);
                        FinalPrice = Totalwastageper.toFixed(2);
                    }

                    if (FinalPrice > 0) {
                        if (GreigePrice != 0) {
                            $("#" + "ctl00_cph_main_content_txtfinishAdd").val(FinalPrice);
                            document.getElementById("ctl00_cph_main_content_txtfinishAdd").removeAttribute('readonly');
                            document.getElementById("ctl00_cph_main_content_txtprocessAdd").removeAttribute('readonly');
                        }
                    }
                    else {
                        $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
                        $("#" + "ctl00_cph_main_content_txtfinishAdd").val("");
                        document.getElementById("ctl00_cph_main_content_txtfinishAdd").removeAttribute('readonly');

                        $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txteditFinish").val("");
                        $("#" + "ctl00_cph_main_content_grdsize_" + rowid + "_txtprocessAdd").val("");
                        document.getElementById("ctl00_cph_main_content_txtprocessAdd").setAttribute('readonly', 'readonly');
                    }
                }
            }
        }

        function UnHighlight(txt) {
            txt.style.backgroundColor = "";
        }


        function chkSelectionsss(list) {
            //debugger;
            var currListValue = list.value; //Remember selection of current list.
            var arrSelect = new Array(); //Array to hold all select lists
            arrSelect = document.getElementsByClassName('sss'); //Get lists by tag name so as have no problems of different grouping etc.
            var chkCtr = 0;
            if (currListValue.trim() != "") {
                for (var i = 0; i < arrSelect.length; i++) {

                    if (document.getElementById(arrSelect.item(i).id).innerText.trim().toLowerCase() == currListValue.trim().toLowerCase()) {
                        chkCtr = chkCtr + 1;
                    }
                }
                if (chkCtr > 0) {
                    alert('Duplicate size name not allowed!');
                    list.value = list.defaultValue;
                }
            }
        }
        function ValidateQualityName(elem, rowtype) {
            //debugger;
            if (rowtype == 'ROW') {
                var Id = elem.id;
                var SiplitIds = elem.id.split("_");
                var rowid = SiplitIds[5];
                if ($("#ctl00_cph_main_content_GrdCatgoryAdd_" + rowid + "_txtcatagory").val() == '') {
                    alert("Enter quality name");
                    return false;
                }
            }
            if (rowtype == 'FOOTER') {
                if ($('#ctl00_cph_main_content_ddlgrouptypeAdd').val() == '0') {
                    alert("Select group name");
                    return false;
                }
                if ($("#ctl00_cph_main_content_txtQtyAdd").val() == '') {
                    alert("Enter quality name");
                    return false;
                }
            }
            if (rowtype == 'Empty') {
                if ($('#ctl00_cph_main_content_GrdCatgoryAdd_ctl01_ddlEmptyGroup').val() == '-1') {
                    //alert("Select group name!");
                    $("#ctl00_cph_main_content_GrdCatgoryAdd_ctl01_ddlEmptyGroup").addClass("borderRed");
                    return false;
                }
                if ($("#ctl00_cph_main_content_GrdCatgoryAdd_ctl01_txtcatagory_Empty").val() == '') {
                    $("#ctl00_cph_main_content_GrdCatgoryAdd_ctl01_txtcatagory_Empty").addClass("borderRed");
                    return false;
                }
            }
        }
        function showhideFileupload(AccMasterID, AccessoryQualityId, elem) {
            //debugger;
            //            alert(AccMasterID);
            //            alert(AccessoryQualityId);
            var Id = elem.id;
            var rowid = elem.id.split("_")[5];

            var SupplierId = $("#" + "ctl00_cph_main_content_grdsizedynamic_" + rowid + "_SupplierName").val();
            if (SupplierId == '0') {
                alert('Please Select Supplier');
                return false;
            }

            //debugger;
            var sURL = 'AccessoryFileUpload.aspx?AccMasterID=' + AccMasterID + '&AccessoryQualityId=' + AccessoryQualityId + '&SupplierId=' + SupplierId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 150, width: 370, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }


        function SBClose() { }

        function ShowHistory() {
            //debugger;    
            var FieldName = "";
            var type = 3;

            proxy.invoke("GetAdminHistory", { typeflag: type, FieldName: FieldName },
            function (result) {
                //debugger;
                var History = result;
                var vDesc = '';
                for (var i = 0; i < History.length; i++) {
                    //debugger;
                    vDesc = vDesc + '<li>' + History[i] + '</li>';
                }
                $("#HistoryDescription").html(vDesc);
                $("#dvHistory").css("display", "block");

            });
        }
        function SpiltContactClose() {
            $("#dvHistory").hide();
        }

        function validateDropdown() {
            // alert();
            var hdnIsdefaultval = document.getElementById("ctl00_cph_main_content_hdnIsdefault").value;

            if ($("#" + "ctl00_cph_main_content_txtsizeAdd").val() == "") {
                alert("Please fill Size Name.");
                return false;
            }
        }

        function CheckIsDefault(obj) {
            //debugger;
            if ($(obj).is(':checked')) {
                $("#ctl00_cph_main_content_trClient").show();
                $("#ctl00_cph_main_content_trParentDept").show();
                $("#ctl00_cph_main_content_trDept").show();
            }
            else {
                $("#ctl00_cph_main_content_trClient").hide();
                $("#ctl00_cph_main_content_trParentDept").hide();
                $("#ctl00_cph_main_content_trDept").hide();
            }
        }

        function AddAccessory(obj, flag) {
            //debugger;
            $('#<%= chkIsDefault.ClientID %>').attr("checked", false);
            $('#ctl00_cph_main_content_hdnAccessoryMasterId').val('-1');
            $('#ctl00_cph_main_content_ddlGroup').val(-1);
            $('#ctl00_cph_main_content_txtQuality').val('');
            $('#ctl00_cph_main_content_ddlClient').val('-1');
            $('#ctl00_cph_main_content_ddlParentDept').val('-1');
            $('#ctl00_cph_main_content_ddlDept').val('-1');
            $('#ctl00_cph_main_content_txtWastage').val('');
            $('#ctl00_cph_main_content_txtShrinkage').val('');
            $('#ctl00_cph_main_content_lblUnit').text('');
            $('#ctl00_cph_main_content_hdnUnitId').val('-1');

            $("#dvCreateGroup").css("display", "block");
            if (flag == 'Insert') {
                $('#ctl00_cph_main_content_lblAccessoryHdr').text('Add Accessory');
                $('#ctl00_cph_main_content_btnAddAccessory').val('Add');
            }
            else if (flag == 'Edit') {

                var gvId = obj.id.split("_")[5];

                $('#ctl00_cph_main_content_lblAccessoryHdr').text('Edit Accessory');
                $('#ctl00_cph_main_content_btnAddAccessory').val('Update');

                var CategoryId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnCategoryId" + "']").val();
                var AccessoryMasterId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnAccIDitem" + "']").val();
                var UnitId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnUnitId" + "']").val();

                var AccQName = $("#<%= GrdCatgoryAdd.ClientID %> span[id*='" + gvId + "_lblAccQName" + "']").text();
                var Wastage = $("#<%= GrdCatgoryAdd.ClientID %> span[id*='" + gvId + "_lblwastage" + "']").text();
                var Shrinkage = $("#<%= GrdCatgoryAdd.ClientID %> span[id*='" + gvId + "_lblShrinkage" + "']").text();
                var UnitName = $("#<%= GrdCatgoryAdd.ClientID %> span[id*='" + gvId + "_lblunit" + "']").text();

                $('#ctl00_cph_main_content_hdnAccessoryMasterId').val(AccessoryMasterId);

                $('#ctl00_cph_main_content_ddlGroup').val(CategoryId);
                if (Wastage != '') {
                    Wastage = Wastage.substring(0, Wastage.trim().length - 1);
                    $('#ctl00_cph_main_content_txtWastage').val(Wastage);
                }
                if (Shrinkage != '') {
                    Shrinkage = Shrinkage.substring(0, Shrinkage.trim().length - 1);
                    $('#ctl00_cph_main_content_txtShrinkage').val(Shrinkage);
                }
                if (UnitName != '') {
                    $('#ctl00_cph_main_content_lblUnit').text(UnitName);
                }
                $('#ctl00_cph_main_content_hdnUnitId').val(UnitId);

                var CheckIsDefault = $("#" + "ctl00_cph_main_content_GrdCatgoryAdd_" + gvId + "_chkIsdefaultRow");
                if (CheckIsDefault.is(':checked')) {
                    $("#ctl00_cph_main_content_trClient").show();
                    $("#ctl00_cph_main_content_trParentDept").show();
                    $("#ctl00_cph_main_content_trDept").show();

                    $('#<%= chkIsDefault.ClientID %>').attr("checked", "checked");

                    var ClientId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnClientId" + "']").val();
                    var ParentDeptId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnParentDeptId" + "']").val();
                    var DeptId = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnDeptId" + "']").val();
                    var DefaultTrade = $("#<%= GrdCatgoryAdd.ClientID %> input[id*='" + gvId + "_hdnDefaultTrade" + "']").val();

                    $('#ctl00_cph_main_content_txtQuality').val(DefaultTrade);

                    if (ClientId != '-1') {
                        $('#ctl00_cph_main_content_ddlClient').val(ClientId);
                        populateParentDepartments(ClientId, -1, -1, 'Parent');
                    }
                    if (ParentDeptId != '-1') {
                        $('#ctl00_cph_main_content_ddlParentDept').val(ParentDeptId);
                        populateDepartments(ClientId, -1, ParentDeptId, 'SubParent');
                    }
                    if (DeptId != '-1') {
                        $('#ctl00_cph_main_content_ddlDept').val(DeptId);
                    }

                }
                else {
                    $("#ctl00_cph_main_content_trClient").hide();
                    $("#ctl00_cph_main_content_trParentDept").hide();
                    $("#ctl00_cph_main_content_trDept").hide();

                    $('#ctl00_cph_main_content_txtQuality').val(AccQName);
                }
            }
            return false;
        }

        function CloseGroup() {
            $("#dvCreateGroup").css("display", "none");
            location.reload();
            return false;
        }

        function GroupUnitChange(obj) {

            var GroupUnitId = $(obj).val();
            if (GroupUnitId != '-1') {
                proxy.invoke("UnitMastEdt", { ID: GroupUnitId },
                    function (result) {
                        if (result.length > 0) {
                            $("#" + lblUnitClientId).text(result[0].GarmentUnitName);
                            $("#" + hdnUnitClientId).val(result[0].GarmentUnit);
                            $("#" + txt_Acc_Wastage).val(result[0].Acc_Wastage);
                        }
                    });
            }
        }

        function ClientChange(obj) {
            //debugger;            
            var ClientId = $(obj).val();
            if (ClientId != '-1') {
                populateParentDepartments(ClientId, -1, -1, 'Parent');
                var ParentDepartmentId = -1;
                populateDepartments(ClientId, -1, ParentDepartmentId, 'SubParent');
            }
        }

        function ParentDeptChange(obj) {
            //debugger;            
            var ParentDepartmentId = $(obj).val();

            var ClientId = $('#ctl00_cph_main_content_ddlClient option:selected').val();

            if (ClientId != '-1') {
                populateDepartments(ClientId, -1, ParentDepartmentId, 'SubParent');
            }
        }

        function populateParentDepartments(clientId, selectedDeptID, ParentDepartmentId, type) {
            //debugger;
            var UserID = parseInt($("#" + "ctl00_cph_main_content_hdnUserId").val());
            var ddlParentDepartment = 'ctl00_cph_main_content_ddlParentDept';

            bindDropdown(serviceUrl, ddlParentDepartment, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDepartmentId, type: type }, "Name", "DeptID", true, '', onPageError)

        }

        function populateDepartments(clientId, selectedDeptID, ParentDepartmentId, type) {
            //debugger;
            var UserID = parseInt($("#" + "ctl00_cph_main_content_hdnUserId").val());
            var ddlDepartment = 'ctl00_cph_main_content_ddlDept';

            bindDropdown(serviceUrl, ddlDepartment, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDepartmentId, type: type }, "Name", "DeptID", true, '', onPageError)
        }

        function AddUpdateAccessory() {
            //debugger;           
            var AccessoryMasterId = -1
            var ClientId = -1;
            var ParentDeptId = -1;
            var DeptId = -1;
            var AccQuality = '';
            var DefaultAcc = '';
            var IsDefault = false;

            AccessoryMasterId = $('#ctl00_cph_main_content_hdnAccessoryMasterId').val();

            var GroupId = $('#ctl00_cph_main_content_ddlGroup option:selected').val();
            if (GroupId == '-1') {
                alert('Please Select Group');
                $('#ctl00_cph_main_content_ddlGroup').focus();
                return false;
            }

            AccQuality = $('#ctl00_cph_main_content_txtQuality').val();
            if (AccQuality == '') {
                alert('Please Add Quality');
                $('#ctl00_cph_main_content_txtQuality').focus();
                return false;
            }

            var Wastg = $('#ctl00_cph_main_content_txtWastage').val();
            if (Wastg == '') {
                Wastg = 0;
            }
            var Shrnkg = $('#ctl00_cph_main_content_txtShrinkage').val();
            if (Shrnkg == '') {
                Shrnkg = 0;
            }
            var GarmentUnitId = $("#" + hdnUnitClientId).val();

            if ($('#<%= chkIsDefault.ClientID %>').is(':checked')) {
                IsDefault = true;
                ClientId = $('#ctl00_cph_main_content_ddlClient option:selected').val();
                ParentDeptId = $('#ctl00_cph_main_content_ddlParentDept option:selected').val();
                DeptId = $('#ctl00_cph_main_content_ddlDept option:selected').val();

                if (ClientId != '-1') {
                    var ClientName = $('#ctl00_cph_main_content_ddlClient option:selected').text();
                    ClientName = ClientName.split('(')[0].trim();

                    AccQuality = AccQuality + '-' + ClientName;
                    //AccQuality = AccQuality + ' ' + ClientName;
                }
                if (ParentDeptId != '-1') {
                    AccQuality = AccQuality + '-' + $('#ctl00_cph_main_content_ddlParentDept option:selected').text();
                    //AccQuality = AccQuality + '(' + $('#ctl00_cph_main_content_ddlParentDept option:selected').text().substring(0,2) ;
                }
                if (DeptId != '-1') {
                    AccQuality = AccQuality + '-' + $('#ctl00_cph_main_content_ddlDept option:selected').text();
                }
                DefaultAcc = $('#ctl00_cph_main_content_txtQuality').val();
            }

            proxy.invoke("UpdateAccQuality", { isDefalt: IsDefault, CatGroupID: GroupId, AccessoryMasterId: AccessoryMasterId, AccQuality: AccQuality, ClientId: ClientId, ParentDeptId: ParentDeptId, DeptId: DeptId, DefaultTradeName: DefaultAcc, Wastage: Wastg, Shrinkage: Shrnkg, GarmentUnit: GarmentUnitId },
            function (result) {
                //debugger;
                if (result.length > 0) {
                    //debugger;
                    if (result != '') {
                        alert(result);
                    }
                }
            });
            //debugger;
            $("#dvCreateGroup").css("display", "none");
            location.reload();
            return false;
        }
        //End
    </script>
    <asp:HiddenField ID="hdnSizeCount" runat="server" Value="0" />
    <asp:HiddenField ID="hdnwastage" runat="server" Value="0" />
    <asp:HiddenField ID="hdnshrinkage" runat="server" Value="0" />
    <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
    <div style="width: 800px; margin: 0 auto">
        <h2 style="margin-left: 20px; width: 809px; border: 1px solid gray">
            Accessories Quality Admin <span style="float: right; color: White; font-size: 10px;
                padding-right: 5px; line-height: 21px; cursor: pointer">
                <asp:HyperLink ID="hlnkHistory" Text="Show History" onclick="ShowHistory()" runat="server"></asp:HyperLink></span>
        </h2>
        <table cellspacing="0" style="margin-left: 20px; margin-bottom: 2px; border-color: #f2f2f2;
            width: 810px" cellpadding="0" width="810px" border="1" align="center" runat="server"
            id="Table2">
            <tr>
                <th style="width: 60px;">
                    IsDefault
                </th>
                <td>
                    <asp:DropDownList ID="ddlIsDefault" Width="95%" runat="server">
                        <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Default" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Exclude Default" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>                 
                <th style="width: 60px;">
                    Group
                </th>
                <td>
                    <asp:DropDownList ID="ddlgroupSrach" Width="95%" runat="server">
                    </asp:DropDownList>
                </td>
                <th style="width: 60px;">
                    Quality
                </th>
                <td>
                    <asp:TextBox ID="txtQualitySearch" Width="95%" runat="server"></asp:TextBox>
                </td>
                <th style="width: 60px;">
                    Unit
                </th>
                <td>
                    <asp:DropDownList ID="ddlunitsearch" Width="95%" runat="server">
                        <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;">
                    <asp:Button ID="btnGoProcess" runat="server" OnClick="btn_Go" CssClass="go" Text="Go" />
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 800px; margin: 0 auto" class="addClass">
        <asp:GridView ID="GrdCatgoryAdd" runat="server" AutoGenerateColumns="False" CssClass="grds bottomRowVali"
            ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found!" Width="810px"
            OnRowDeleting="GrdCatgoryAdd_RowDeleting" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
            OnRowDataBound="GrdCatgoryAdd_RowDataBound" OnRowCommand="GrdCatgoryAdd_RowCommand"
            rules="all" HeaderStyle-CssClass="ths" PageSize="20" AllowPaging="True" OnPageIndexChanging="GrdCatgoryAdd_PageIndexChanging">
            <FooterStyle CssClass="borderBottom" />
            <EmptyDataRowStyle CssClass="EmptyRowBorder" />
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="border_left_color" />
                    <FooterStyle CssClass="border_left_color" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is Default">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsdefaultRow" CssClass="DisableCheckBox" runat="server" Checked='<%# Eval("IsDefault")%>' />
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HSN Code">
                <ItemTemplate>
                 <asp:Label ID="lblhsncode" Text='<%# Eval("HSNCode")%>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Group">
                    <ItemTemplate>
                        <asp:Label ID="lblcatagory" Text='<%# Eval("Name")%>' runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnCategoryId" Value='<%# Eval("CategoryID")%>' runat="server" />
                        <asp:HiddenField ID="hdnAccIDitem" Value='<%# Eval("AccessoryMaster_Id")%>' runat="server" />
                        <asp:HiddenField ID="hdnClientId" Value='<%# Eval("ClientId")%>' runat="server" />
                        <asp:HiddenField ID="hdnParentDeptId" Value='<%# Eval("ParentDepartmentId")%>' runat="server" />
                        <asp:HiddenField ID="hdnDeptId" Value='<%# Eval("DepartmentId")%>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quality">
                    <ItemTemplate>
                        <div id="dvAccName" runat="server">
                            <asp:Label ID="lblAccQName" Text='<%# Eval("TradeName")%>' runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnDefaultTrade" Value='<%# Eval("DefaultTradeName")%>' runat="server" />
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="300px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wastg">
                    <ItemTemplate>
                        <asp:Label ID="lblwastage" Text='<%# Eval("Wastage")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shrnkg">
                    <ItemTemplate>
                        <asp:Label ID="lblShrinkage" Text='<%# Eval("Shrinkage")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit">
                    <ItemTemplate>
                        <asp:Label ID="lblunit" Text='<%# Eval("UnitName")%>' runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("Unit")%>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" width="50px">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:LinkButton ID="btnedit" runat="server" OnClientClick="javascript:return AddAccessory(this, 'Edit')"
                                        ToolTip="Edit" Text="Edit">
                                    <img src="../../images/edit2.png" /></asp:LinkButton>
                                </td>
                                <td style="text-align: right;">
                                    <asp:LinkButton ToolTip="Delete" ID="lnkDelete" runat="server" CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?')"> 
                                        <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                    <FooterTemplate>
                        <img id="imgAdd" src="../../images/add-butt.png" alt="Add Items" title="Add more"
                            onclick="AddAccessory(this, 'Insert')" border="0" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnselect" runat="server" Style="cursor: pointer" CommandName="Select"
                            Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="70px" CssClass="border_right_color" />
                    <FooterStyle CssClass="border_right_color" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="AddClass_Table" cellspacing="0" style="width: 100%; border-collapse: collapse;">
                    <tbody>
                        <tr class="ths" align="center" style="font-family: Arial;">
                            <th align="center" scope="col">
                                S.No.
                            </th>
                            <th scope="col" style="width: 80px;">
                                Is Default
                            </th>
                            <th scope="col" style="width: 150px;">
                                Group
                            </th>
                            <th scope="col">
                                Quality
                            </th>
                            <th scope="col">
                                wastage
                            </th>
                            <th scope="col">
                                Shrinkage
                            </th>
                            <th scope="col" style="width: 60px;">
                                Unit
                            </th>
                            <th scope="col" style="width: 60px;">
                                Action
                            </th>
                            <th scope="col" style="width: 60px;">
                                Select
                            </th>
                        </tr>
                        <tr>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999; border-left: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999;">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                                <asp:LinkButton runat="server" ID="Submit">
                                        <img src="../../images/add-butt.png" /></asp:LinkButton>
                            </td>
                            <td style="border-right: 1px solid #9999; border-bottom: 1px solid #999">
                                &nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
    </div>
    <div style="max-width: 1500px; overflow: auto; text-align: center; margin: 0 auto;">
        <div id="divsizeheader" runat="server" style="">
            &nbsp;</div>
        <asp:GridView ID="grdsizedynamic" OnRowCancelingEdit="grdsizedynamic_RowCancelingEdit"
            runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
            OnRowDataBound="grdsizedynamic_RowDataBound" ShowHeader="false" OnRowDeleting="grdsizedynamic_RowDeleting"
            RowStyle-ForeColor="#7E7E7E" CssClass="item_list1 inputborder bottom_boder" OnRowCommand="grdsizedynamic_RowCommand"
            Style="margin-left: 20px; margin: 0 auto;" OnRowEditing="grdsizedynamic_RowEditing">
        </asp:GridView>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="do-not-include submit"
            OnClick="btnSubmit_Click" Style="margin: 5px 20px 2px;" />
        <div id="divFinish" runat="server" class="modal">
            <div class="modal-content">
                <table cellspacing="0" style="border: none; height: 20px;" cellpadding="0" width="100%"
                    align="center" runat="server" id="Table4">
                    <tr>
                        <th colspan="6" style="background: #39589C; color: White; padding: 5px;">
                            <table width="100%">
                                <tr>
                                    <td align="center" style="width: 80%;">
                                        <asp:Label ID="Label1" ForeColor="White" runat="server" Text="Add Size"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 10%; font-size: x-small;">
                                        <asp:Label ID="lblshry" ForeColor="White" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="right" style="width: 10%; font-size: x-small;">
                                        <asp:Label ID="lblWast" ForeColor="White" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </th>
                    </tr>
                    <tr>
                        <th style="padding: 2px 0px; width: 30px;">
                            S.no
                        </th>
                        <th style="padding: 2px 0px; width: 100px;">
                            Sizes
                        </th>
                        <th style="padding: 2px 0px; width: 100px;">
                            Greige
                        </th>
                        <th style="padding: 2px 0px; width: 100px;">
                            Process
                        </th>
                        <th style="padding: 2px 0px; width: 100px;">
                            Finish
                        </th>
                        <th style="padding: 2px 0px; width: 70px;">
                            Action
                        </th>
                    </tr>
                </table>
                <asp:GridView ID="grdsize" runat="server" AutoGenerateColumns="False" ShowHeader="false"
                    Width="100%" OnRowDeleting="grdsize_RowDeleting" HeaderStyle-Font-Names="Arial"
                    HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdsize_RowDataBound" OnRowCancelingEdit="grdsize_RowCancelingEdit"
                    OnRowEditing="grdsize_RowEditing" OnRowCommand="grdsize_RowCommand" OnRowUpdating="grdsize_RowUpdating"
                    BorderWidth="1" rules="all" HeaderStyle-CssClass="ths" CssClass="inputSizecenter">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <RowStyle CssClass="gvRow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                <asp:HiddenField ID="hdnOptionNo" Value='<%#Container.DataItemIndex+1 %>' runat="server" />
                                <asp:HiddenField ID="hdnaccessory_quality_SizeIDs" Value='<%# Eval("accessory_quality_SizeID")%>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="border_left_color" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="Sizelable" CssClass="sss" runat="server" Text='<%# Eval("Size")%>'></asp:Label>
                                <asp:HiddenField ID="hdnSize" Value='<%# Eval("Size")%>' runat="server" />
                                <asp:HiddenField ID="hdnClientId" Value='<%# Eval("ClientId")%>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtsize" onchange="chkSelectionsss(this)" MaxLength="20" runat="server"
                                    Text='<%# Eval("Size")%>'></asp:TextBox>
                                <asp:HiddenField ID="hdnClientId" Value='<%# Eval("ClientId")%>' runat="server" />
                                <asp:HiddenField ID="hdnSizes" Value='<%# Eval("Size")%>' runat="server" />
                                <asp:HiddenField ID="hdnaccessory_quality_SizeID" Value='<%# Eval("accessory_quality_SizeID")%>'
                                    runat="server" />
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblgreige" Text='<%# Eval("GreigeRate")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txteditgreige" Text='<%# Eval("GreigeRate")%>' onkeyup="return checkZero(this);"
                                    onkeypress="return isNumberKeyandCheckZero(event,this);" autocomplete="off" CssClass="allownumericwithoutdecimal"
                                    onchange="CalculateGriegeFinhish(this,'Item')" MaxLength="4" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblprocess" Text='<%# Eval("ProcessRate")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txteditProcess" Text='<%# Eval("ProcessRate")%>' onkeypress="return isNumberKey(event);"
                                    CssClass="allownumericwithoutdecimal" onchange="CalculateGriegeFinhish(this,'Item')"
                                    autocomplete="off" Enabled="false" MaxLength="4" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblFinish" Text='<%# Eval("FinishRate")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txteditFinish" Text='<%# Eval("FinishRate")%>' onkeypress="return isNumberKey(event);"
                                    onchange="CalculateGriegeFinhish(this,'Item')" autocomplete="off" MaxLength="4"
                                    runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"><img src="../../images/edit2.png" /></asp:LinkButton>
                                <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/delete-icon.png" /> </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="70px" CssClass="border_right_color" />
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"><img src="../../images/Save.png" Style="width: 18px;" /></asp:LinkButton>
                                <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"
                                    Width="50px"><img src="../../App_Themes/ikandi/images/cancel1.png" width="25px" /> </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table cellspacing="0" class="inputSizecenter" style="border: none; border-collapse: collapse"
                    cellpadding="0" width="100%" border="1" align="center" runat="server" id="Table3">
                    <tr>
                        <td style="padding: 0px; width: 30px; border-top: none; border-left-color: #999 !important;
                            border-bottom-color: #999 !important;" class="border_left_color">
                            &nbsp;
                            <asp:HiddenField ID="hdnIsdefault" runat="server" />
                        </td>
                        <td style="border-top: none; width: 100px; border-bottom-color: #999 !important;">
                            <asp:TextBox ID="txtsizeAdd" CssClass="sss" onchange="chkSelectionsss(this)" MaxLength="20"
                                autocomplete="off" Style="text-transform: none;" runat="server"></asp:TextBox>
                        </td>
                        <td style="border-top: none; width: 100px; border-bottom-color: #999 !important;">
                            <asp:TextBox ID="txtgreigeAdd" MaxLength="5" onkeyup="return checkZerofoter(this);"
                                CssClass="allownumericwithoutdecimal" autocomplete="off" onchange="CalculateGriegeFinhish(this,'Foter')"
                                onkeypress="return isNumberKey(event);" Style="text-transform: none;" runat="server"></asp:TextBox>
                        </td>
                        <td style="border-top: none; width: 100px; border-bottom-color: #999 !important;">
                            <asp:TextBox ID="txtprocessAdd" MaxLength="5" autocomplete="off" onchange="CalculateGriegeFinhish(this,'Foter')"
                                CssClass="allownumericwithoutdecimal" Enabled="false" Style="text-transform: none;"
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="border-top: none; width: 100px; border-bottom-color: #999 !important;">
                            <asp:TextBox ID="txtfinishAdd" MaxLength="5" autocomplete="off" onchange="CalculateGriegeFinhish(this,'Foter')"
                                CssClass="allownumericwithoutdecimal" onkeypress="return isNumberKey(event);"
                                Style="text-transform: none;" runat="server"></asp:TextBox>
                        </td>
                        <td style="border-top: none; width: 70px; border-bottom-color: #999 !important; border-right-color: #999 !important;"
                            class="border_right_color">
                            <asp:LinkButton runat="server" ValidationGroup="S" OnClientClick="javascript:return validateDropdown();"
                                ID="lnkAddSize" OnClick="lnkAddSize_Click">
                         <img src="../../images/add-butt.png" /></asp:LinkButton>
                            <%--  ValidationGroup="S"--%>
                        </td>
                    </tr>
                </table>
                <br />
                <div style="width: 10%; vertical-align: top; border: 0px solid #000000; padding-left: 5px;
                    padding-bottom: 5px" align="left">
                    <asp:Button ID="btnreturnF" runat="server" Text="Return" CssClass="submit" ToolTip="Return to Details"
                        OnClientClick="javascript:return HidePopUp();" />
                </div>
            </div>
        </div>
        <br />
    </div>
    <div id="dvCreateGroup" class="modalNew">
        <div class="UpdateModal-content">
            <div class="HistoryHeader">
                <asp:Label ID="lblAccessoryHdr" runat="server" Text=""></asp:Label>
                <span style="float: right; padding: 0px 3px; cursor: pointer;" onclick="CloseGroup();">
                    X</span>
            </div>
            <div id="dvDetails">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: left;">
                            <asp:CheckBox ID="chkIsDefault" onclick="CheckIsDefault(this)" Text="Is Default"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="AccessoryPopup1">
                            Group:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:DropDownList ID="ddlGroup" onchange="GroupUnitChange(this)" Style="width: 160px;
                                color: Gray;" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="AccessoryPopup1">
                            Quality:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:TextBox ID="txtQuality" Style="width: 155px; color: Gray;" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnAccessoryMasterId" Value="-1" runat="server" />
                        </td>
                    </tr>
                    <tr id="trClient" style="display: none;" runat="server">
                        <td class="AccessoryPopup1">
                            Client:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:DropDownList ID="ddlClient" onchange="ClientChange(this)" Style="width: 160px;
                                color: Gray;" runat="server">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trParentDept" style="display: none;" runat="server">
                        <td class="AccessoryPopup1">
                            Parent Department:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:DropDownList ID="ddlParentDept" onchange="ParentDeptChange(this)" Style="width: 160px;
                                color: Gray;" runat="server">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trDept" style="display: none;" runat="server">
                        <td class="AccessoryPopup1">
                            Department:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:DropDownList ID="ddlDept" Style="width: 160px; color: Gray;" runat="server">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="AccessoryPopup1">
                            Wastage %:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:TextBox ID="txtWastage" onkeypress="return isNumberKey(event);" Style="width: 60px;
                                color: Gray;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="AccessoryPopup1">
                            Shrinkage %:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:TextBox ID="txtShrinkage" onkeypress="return isNumberKey(event);" Style="width: 60px;
                                color: Gray;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="AccessoryPopup1">
                            Unit:
                        </td>
                        <td class="AccessoryPopup2">
                            <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnUnitId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px 0px 5px 0px;" colspan="2">
                            <asp:Button ID="btnAddAccessory" runat="server" Text="" CssClass="submit" OnClientClick="javascript:return AddUpdateAccessory();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>
    <div id="dvHistory" class="modalNew">
        <div class="modal-content">
            <div class="HistoryHeader">
                <span id="Historytitle">History</span> <span style="float: right; padding: 0px 3px;
                    cursor: pointer;" onclick="SpiltContactClose();">X</span>
            </div>
            <div id="HistoryDescription">
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Content>
