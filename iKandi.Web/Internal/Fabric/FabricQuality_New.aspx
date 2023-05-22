<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricQuality_New.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FabricQuality_New" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript" src="../../js/facebox.js"></script>
    <script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <style type="text/css">
        .tablegrid
        {
            border-top: thin solid #dddfe4;
        }
        
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana;
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
            padding: 5px 0px 5px 0px;
            text-transform: capitalize;
            text-align: center;
        }
        td
        {
              height: 25px;
         }
        th span
        {
            color: #575759 !important;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #e0d9d9;
            text-transform: capitalize;
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
            width: 70%;
        }
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #e0d9d9;
        }
        input, select
        {
            width: 86%;
            padding: 0px;
        }
        div select option
        {
            padding: 4px 0px;
            width: 86%;
        }
        div input
        {
            width: 95%;
            color: blue;
            padding: 4px 0px;
        }
        .style_number_box_background
        {
            opacity: 0.9;
            background: grey;
            width: 2400px;
        }
        .style_number_box
        {
            padding: 0px !important;
            width: 550px !important;
            border: none;
        }
        .style_number_box table
        {
            border: 1px solid gray;
            padding-bottom: 5px;
        }
        .style_number_box div
        {
            background-color: #39589c;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-transform: capitalize;
            width: 100%;
            padding: 5px 0px;
        }
        .style_number_box
        {
            top: 50px !important;
            left: 50% !important;
            position: absolute !important;
        }
        .hover_row td
        {
            background-color: #A1DCF2;
        }
        .inner-table
        {
            border-color: #f2f2f2;
            text-align: left;
        }
        .inner-table td
        {
            text-align: left;
            padding: 0px 0px 0px 3px;
        }
        .foo-input, foo-select
        {
            font-size: 9px;
            height: 13px;
        }
        .inner-table td input
        {
            padding: 0px;
        }
        
        .inner-table select, .inner-table select option
        {
            padding: 0px;
            width: 97%;
            font-size: 9px;
            height: 16px;
        }
        select
        {
             height: 23px;
         }
        .disable, .disableF
        {
            background-image: url('../../images/n_a.png');
            height: 16px;
            width: 20px;
            background-repeat: no-repeat;
            opacity: 0.35;
            border: 1px solid gray !important;
        }
        #Img1
        {
            height: 10px;
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
            padding: 0px 1px 1px;
            border: 5px solid #888;
            width: 750px;
            margin-top: 12%;
            border-radius:5px;
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
            border-radius:2px;
            
        }
        input[type="text"], select
        {
            color: Gray !important;
        }
        .item_list TD .ValidationBorder, .item_list TD input[type=text].ValidationBorder, .item_list TD textarea.ValidationBorder
        {
            border: 1px solid #FF0000 !important;
        }
        .minwidthsup
        {
           min-width:255px;
            
           }
           .moqwidth
           {
               min-width:57px;
            }
            .item_list TD input[type=text]{
                width: 96%;
                height: 12px;
                font-size: 11px;
            }
           @-moz-document url-prefix() {
            .ShowDiv table
               {
                border-color:#847c7c66 !important;
               }
               .ShowDiv table th{
                 border-color:#999; 
               }
               .toptablegroup 
               {
                    border-color:#999 !important;
                }
                   .toptablegroup th
               {
                    border-color:#999 !important;
                }
            }
           table.bottomtable tr:nth-last-child(1) > td
            {
                border-bottom-color: #999 !important;
            }
              ::-webkit-scrollbar-thumb {
                background: #b8b4b4  !important;
                border: 1px solid #b8b4b4  !important;
                border-radius: 10px;
            }
              ::-webkit-scrollbar-thumb:hover {
                background: #999 !important;
                border: 1px solid #999 !important;
                border-radius: 10px;
            }
            
             td[colspan="8"] {
              border-left-color: #999;
               border-right-color: #999;
                border-bottom-color: #999;
                border:0px;
                padding: 2px 0px !important;
            }
              td[colspan="8"] span
              {
                  color:Blue;
                cursor: default;
              }
               td[colspan="8"] a
              {
                  color:gray
              }
            
            #ctl00_cph_main_content_gdvFQMaster
            {
                 border-left:0px;
                 border-right:0px;
                 border-bottom:0px;
             }
            .border_top_color
            {
                border-top-color: #999 !important;;
                
              }
              .grouptable input
              {
                  height:12px;
                }
        .validation_messagebox  td[rowspan="4"]
         {
            width: 70px;
           padding-left: 5px;
          }
          .grouptable.bottomtable
          {
              border-right-color:#999!important;
               border-left-color:#999!important;
           }
            .grouptable.bottomtable td:first-child
          {
              
               border-left-color:#999!important;
           }
          .grouptable.bottomtable td:last-child
          {
              
               border-right-color:#999!important;
           }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 5px;
        }
       .item_list a:hover {
        text-decoration: none !important;
    }
     .borderBottom td
        {
            border-bottom:1px solid #999;
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
            overflow:auto;
             
        }
        .HistoryHeader
        {
            background:#39589c;
            color:#fff;
            text-align: center;
            font-size: 14px;
            position:fixed;
            width:792px;
        }
        #HistoryDescription
        {
             padding: 7px !important;
             margin-top:17px;
         }
         img.imgWidth2
         {
             width:19px !important;
             height:19px !important;
          }
            img.imgWidth
         {
             width:18px !important;
            
          }
          .LeftRightNone
          {
              border-left:0px !important;
                border-right:0px !important
           }
            .LeftNone
          {
              border-left:0px !important;
           }
           .RightNone {
              border-right:0px !important;
           }
    </style>
    <script type="text/javascript">
        function validateAndHighlight() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid) {
                        ctrl.classList.add("ValidationBorder");
                        //ctrl.style.border = '1px solid #FF0000';
                        //ctrl.style.backgroundColor = '#fce697';
                    }
                    else {
                        ctrl.classList.remove("ValidationBorder");
                        //ctrl.style.border = '';
                        //ctrl.style.backgroundColor = '';
                    }
                }
            }
        }

        function chechZero(evt) {
            var val = parseInt(evt.value);
            if (val == 0) {
                ShowHideValidationBox(true, "Zero is not valid.");
                evt.value = "";
                evt.focus();
                return false;
            }
            else {
                return true;
            }
        }
        //Create a Function for int Value Surendra2 on 27-08-2018.
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        //Create a Function for Flaot Value Surendra2 on 07-05-2018.
        function isNumberKeyfloat(evt, val) {
            //debugger;
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var len = val.value.length;
                var index = val.value.indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }

            }
            return true;
        }

        function showpopup(id) {
            $("#ctl00_cph_main_content_" + id).css("display", "block"); ;
        }

        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function CheckBoxDisable() {
            $(".chkDisable input[type='checkbox']").attr("disabled", true);
        }
        function EndRequestHandler() {

            var GreigeFinish = $("#ctl00_cph_main_content_hdnGreigeFinish").val();
            var Finish = $("#ctl00_cph_main_content_hdnFinish").val();
            if (GreigeFinish == "1") {
                $("#ctl00_cph_main_content_divGreige").css("display", "block");
                $("#ctl00_cph_main_content_divFinish").css("display", "none");
            }
            else {
                $("#ctl00_cph_main_content_divGreige").css("display", "none");
            }
            if (Finish == "1") {
                $("#ctl00_cph_main_content_divFinish").css("display", "block");
                $("#ctl00_cph_main_content_divGreige").css("display", "none");
            }
            else {
                $("#ctl00_cph_main_content_divFinish").css("display", "none");
            }
            return false;
        }

        $(document).ready(function () {

            $("#ctl00_cph_main_content_hdnGreigeFinish").val("0");
            $("#ctl00_cph_main_content_hdnFinish").val("0");

        });

        function validate(ctrl) {
            var count = 0;
            var dropdowns = new Array();
            var grdRow = ctrl.parentNode.parentNode;
            var grdControl = grdRow.getElementsByTagName("input");
            dropdowns = grdRow.getElementsByTagName('select');

            // LOOP THROUGH DROPDOWN CONTROL IN THE GRIDVIEW.
            for (var i = 0; i < dropdowns.length; i++) {
                if (dropdowns.item(i).value == '-1') {
                    dropdowns.item(i).style.borderColor = '#FF0000';
                    count++;
                    break;
                }
                else {
                    dropdowns.item(i).style.borderColor = '';
                    dropdowns.item(i).style.backgroundColor = '';
                }
            }

            if (count > 0) {
                return false;
            }
        }

        var TypeName;
        var GreigeRow;
        var control;

        function SupplierOnchange(ctrl, type, Greige) {
            var grdRow = ctrl.parentNode.parentNode;
            var grdControl = grdRow.getElementsByTagName("input");

            // LOOP THROUGH EACH INPUT CONTROL IN THE GRIDVIEW.
            for (var i = 0; i < grdControl.length; i++) {
                if (grdControl[i].type === 'checkbox') {
                    grdControl[i].checked = false;
                }
            }

            control = ctrl;
            TypeName = type;
            GreigeRow = Greige;
            var Id = ctrl.value;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetFQHeaderforSupplier",
                data: "{ ID:'" + Id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCallSupplier,
                error: OnErrorCallSupplier
            });

        }
        function OnSuccessCallSupplier(response) {
            //debugger;
            var grdRow = control.parentNode.parentNode;
            var grdControl = grdRow.getElementsByTagName("input");
            for (var o = 0; o < response.d.length; o++) {
                var value = response.d[o];
                if (TypeName == "Row") {
                    for (var j = 0; j < GreigeRow; j++) {

                        for (var i = 0; i < grdControl.length; i++) {
                            if (grdControl[i].type === 'checkbox') {
                                var id = grdControl[i].id;
                                var controlid = id.split("_");
                                var name = controlid[controlid.length - 1];
                                if (name == "chkGrate" + j && value == "Griege") {
                                    grdControl[i].checked = true;
                                }
                                if (name == "chkGDyedRate" + j && value == "Dyed") {
                                    grdControl[i].checked = true;
                                }
                                if (name == "chkGPrintrate" + j && value == "Printed") {
                                    grdControl[i].checked = true;
                                }
                                if (name == "chkGDigitalPrint" + j && value == "Digital Printed") {
                                    grdControl[i].checked = true;
                                }
                            }
                        }
                    }
                }
                if (TypeName == "Footer") {
                    //debugger;
                    for (var j = 0; j < GreigeRow; j++) {

                        for (var i = 0; i < grdControl.length; i++) {
                            if (grdControl[i].type === 'checkbox') {
                                var id = grdControl[i].id;

                                var controlid = id.split("_");
                                var name = controlid[controlid.length - 1];
                                if (name == "chkFooterGrate" + j && value == "Griege") {
                                    grdControl[i].checked = true;
                                    $("#" + id).removeAttr("disabled");
                                }
                                if (name == "chkFooterGDyedRate" + j && value == "Dyed") {
                                    grdControl[i].checked = true;
                                    $("#" + id).removeAttr("disabled");
                                }
                                if (name == "chkFooterGPrintrate" + j && value == "Printed") {
                                    grdControl[i].checked = true;
                                    $("#" + id).removeAttr("disabled");
                                }
                                if (name == "chkFooterGDigitalPrint" + j && value == "Digital Printed") {
                                    grdControl[i].checked = true;
                                    $("#" + id).removeAttr("disabled");
                                }
                            }
                        }
                    }
                }
            }

        }
        function OnErrorCallSupplier(response) {
            alert(response.status + " " + response.statusText);
        }

        function GetFinishVlaue(ctrl) {


            var thisval = $(ctrl).val();
            var txtval1 = $(ctrl).parent().next().find("input[type=text]").val();
            var txtval2 = $(ctrl).parent().next().next().find("input[type=text]").val();
            var txtval3 = $(ctrl).parent().next().next().next().find("input[type=text]").val();
            var calc1 = parseFloat(txtval1) + parseFloat(txtval1 * thisval / 100);
            var calc2 = parseFloat(txtval2) + parseFloat(txtval2 * thisval / 100);
            var calc3 = parseFloat(txtval3) + parseFloat(txtval3 * thisval / 100);
            $(ctrl).parent().next().find('span').text(Math.round(calc1.toFixed(2)));
            $(ctrl).parent().next().find("input[type=hidden]").val(Math.round(calc1.toFixed(2)));

            $(ctrl).parent().next().next().find('span').text(Math.round(calc2.toFixed(2)));
            $(ctrl).parent().next().next().find("input[type=hidden]").val(Math.round(calc2.toFixed(2)));

            $(ctrl).parent().next().next().next().find('span').text(Math.round(calc3.toFixed(2)));
            $(ctrl).parent().next().next().next().find("input[type=hidden]").val(Math.round(calc3.toFixed(2)));

        }
        function GetFinishVlaue1(ctrl, name, Id) {

            var txtval = $(ctrl).parent().prev().find("input[type=text]").val();
            if (txtval == "") {
                $(ctrl).parent().prev().find("input[type=text]").css("borderColor", '#FF0000');
                $(ctrl).parent().prev().find("input[type=text]").focus();
                return false;
            }
            else {
                $(ctrl).parent().prev().find("input[type=text]").css("borderColor", '');
                $(ctrl).parent().prev().find("input[type=text]").css("backgroundColor", '');
                var thisval = $(ctrl).val();
                var calc = parseFloat(thisval) + parseFloat(thisval * txtval / 100);
                $(ctrl).parent().find('span').text(Math.round(calc.toFixed(2)));
                $(ctrl).parent().find("input[type=hidden]").val(Math.round(calc.toFixed(2)));
            }
        }
        function GetFinishVlaue2(ctrl, name, Id) {

            var txtval = $(ctrl).parent().prev().prev().find("input[type=text]").val();
            if (txtval == "") {
                $(ctrl).parent().prev().prev().find("input[type=text]").css("borderColor", '#FF0000');
                $(ctrl).parent().prev().prev().find("input[type=text]").focus();
                return false;
            }
            else {
                $(ctrl).parent().prev().prev().find("input[type=text]").css("borderColor", '');
                $(ctrl).parent().prev().prev().find("input[type=text]").css("backgroundColor", '');
                var thisval = $(ctrl).val();
                var calc = parseFloat(thisval) + parseFloat(thisval * txtval / 100);
                $(ctrl).parent().find('span').text(Math.round(calc.toFixed(2)));
                $(ctrl).parent().find("input[type=hidden]").val(Math.round(calc.toFixed(2)));
            }
        }
        function GetFinishVlaue3(ctrl, name, Id) {

            var txtval = $(ctrl).parent().prev().prev().prev().find("input[type=text]").val();
            if (txtval == "") {
                $(ctrl).parent().prev().prev().prev().find("input[type=text]").css("borderColor", '#FF0000');
                $(ctrl).parent().prev().prev().prev().find("input[type=text]").focus();
                return false;
            }
            else {
                $(ctrl).parent().prev().prev().prev().find("input[type=text]").css("borderColor", '');
                $(ctrl).parent().prev().prev().prev().find("input[type=text]").css("backgroundColor", '');
                var thisval = $(ctrl).val();
                var calc = parseFloat(thisval) + parseFloat(thisval * txtval / 100);
                $(ctrl).parent().find('span').text(Math.round(calc.toFixed(2)));
                $(ctrl).parent().find("input[type=hidden]").val(Math.round(calc.toFixed(2)));
            }
        }

        function GetGreigeValue1(ctrl, Id) {

            control = ctrl;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/Get_Greige_Value",
                data: "{ ID:'" + Id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall1,
                error: OnErrorCall1
            });
        }
        function OnSuccessCall1(response) {

            var dyedrate = response.d[0];
            var printrate = response.d[1];
            var digitalPrint = response.d[2];
            var txtPrv1val = $(control).parent().next().find("input[type=text]").val();
            var txtPrv2val = $(control).val();
            var thisval = $(control).parent().next().next().find("input[type=text]").val();
            if (txtPrv1val == 0 && txtPrv2val == 0 && thisval == 0) {
                $(control).parent().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().next().next().find("input[type=text]").val(0);
            }
            else {
                var calc1 = parseFloat(thisval) + parseFloat(thisval * txtPrv2val / 100);
                var calc2 = (calc1 + parseFloat(dyedrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc3 = (calc1 + parseFloat(printrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc4 = (calc1 + parseFloat(digitalPrint)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                $(control).parent().next().next().next().find("input[type=text]").val(Math.round(calc1.toFixed(2)));
                $(control).parent().next().next().next().next().find("input[type=text]").val(Math.round(calc2.toFixed(2)));
                $(control).parent().next().next().next().next().next().find("input[type=text]").val(Math.round(calc3.toFixed(2)));
                $(control).parent().next().next().next().next().next().next().find("input[type=text]").val(Math.round(calc4.toFixed(2)));
            }
        }
        function OnErrorCall1(response) {
            alert(response.status + " " + response.statusText);
        }
        function GetGreigeValue2(ctrl, Id) {

            control = ctrl;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/Get_Greige_Value",
                data: "{ ID:'" + Id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall2,
                error: OnErrorCall2
            });
        }
        function OnSuccessCall2(response) {

            var dyedrate = response.d[0];
            var printrate = response.d[1];
            var digitalPrint = response.d[2];
            var txtPrv1val = $(control).val();
            var txtPrv2val = $(control).parent().prev().find("input[type=text]").val();
            var thisval = $(control).parent().next().find("input[type=text]").val();
            if (txtPrv1val == 0 && txtPrv2val == 0 && thisval == 0) {
                $(control).parent().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().next().find("input[type=text]").val(0);
            }
            else {
                var calc1 = parseFloat(thisval) + parseFloat(thisval * txtPrv2val / 100);
                var calc2 = (calc1 + parseFloat(dyedrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc3 = (calc1 + parseFloat(printrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc4 = (calc1 + parseFloat(digitalPrint)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                $(control).parent().next().next().find("input[type=text]").val(Math.round(calc1.toFixed(2)));
                $(control).parent().next().next().next().find("input[type=text]").val(Math.round(calc2.toFixed(2)));
                $(control).parent().next().next().next().next().find("input[type=text]").val(Math.round(calc3.toFixed(2)));
                $(control).parent().next().next().next().next().next().find("input[type=text]").val(Math.round(calc4.toFixed(2)));
            }
        }
        function OnErrorCall2(response) {
            alert(response.status + " " + response.statusText);
        }
        function GetGreigeValue3(ctrl, Id) {

            control = ctrl;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/Get_Greige_Value",
                data: "{ ID:'" + Id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall3,
                error: OnErrorCall3
            });
        }
        function OnSuccessCall3(response) {
            //debugger;
            var dyedrate = response.d[0];
            var printrate = response.d[1];
            var digitalPrint = response.d[2];
            var txtPrv1val = $(control).parent().prev().find("input[type=text]").val();
            var txtPrv2val = $(control).parent().prev().prev().find("input[type=text]").val();
            var thisval = $(control).val();
            if (txtPrv1val == 0 && txtPrv2val == 0 && thisval == 0) {
                $(control).parent().next().find("input[type=text]").val(0);
                $(control).parent().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().find("input[type=text]").val(0);
                $(control).parent().next().next().next().next().find("input[type=text]").val(0);
            }
            else {
                var calc1 = parseFloat(thisval) + parseFloat(thisval * txtPrv2val / 100);
                var calc2 = (calc1 + parseFloat(dyedrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc3 = (calc1 + parseFloat(printrate)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                var calc4 = (calc1 + parseFloat(digitalPrint)) * parseFloat(1 + (parseFloat(txtPrv1val) / 100));
                $(control).parent().next().find("input[type=text]").val(Math.round(calc1.toFixed(2)));
                $(control).parent().next().next().find("input[type=text]").val(Math.round(calc2.toFixed(2)));
                $(control).parent().next().next().next().find("input[type=text]").val(Math.round(calc3.toFixed(2)));
                $(control).parent().next().next().next().next().find("input[type=text]").val(Math.round(calc4.toFixed(2)));
            }
        }
        function OnErrorCall3(response) {
            alert(response.status + " " + response.statusText);
        }

        function CostWidth(ctrl) {
            var difference = 1;
            if (!chechZero(ctrl)) {
                return false;
            }
            else {
                var thisVal = $(ctrl).val();
                if (thisVal == "") {
                    $(ctrl).parent().next().find("input[type=text]").val("");
                }
                else {
                    var thisval = Math.round((parseFloat(thisVal) - difference).toFixed(2));
                    if (thisval == 0) {
                        $(ctrl).parent().next().find("input[type=text]").val(Math.round((parseFloat(thisVal) - difference).toFixed(2)));
                        ShowHideValidationBox(true, "Zero is not valid.");
                        $(ctrl).parent().next().find("input[type=text]").val("");
                        $(ctrl).parent().next().find("input[type=text]").focus();
                    }
                    else {
                        $(ctrl).parent().next().find("input[type=text]").val(Math.round((parseFloat(thisVal) - difference).toFixed(2)));
                    }
                }
            }
        }
        function ReadOnly() {
            $('.readonlytxt').attr('readonly', true);
        }

        function ShowHistory() {
            //debugger;    
            var FieldName = "";
            var type = 2;

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
    </script>
    <div style="width: 100%">
        <div style="width: 80%; margin: 0 auto">
            <h2 style="border: 1px solid gray; width: 99.9%; position: relative; clear: both">
                Fabric Quality Admin <span style="float: right; color: White; font-size: 10px; padding-right: 5px; line-height: 21px; cursor: pointer; position: absolute; right: 0">
                    <asp:HyperLink ID="hlnkHistory" Text="Show History" onclick="ShowHistory()" runat="server"></asp:HyperLink></span>
                <%--added by raghvinder on 15-09-2020 start--%>
                <%--Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' --%>
                <%--<asp:HiddenField ID="hdnCandCFooter" runat="server" Value='<%# Eval("Is_CANDC") %>'  />--%>
                <%--added by raghvinder on 15-09-2020 end--%>
            </h2>
        </div>
        <asp:ScriptManager ID="scriptmgr" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="pnlUpdate" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="width: 80%; margin: 0 auto">
                    <table cellspacing="0" cellpadding="0" border="1" style="width: 100%; border-color: #9999995e" class="item_list">
                        <thead>
                            <tr>
                                <th width="40">
                                    Search
                                </th>
                                <th width="135" style="background: #fff">
                                    <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" Style="text-align: left; width: 95%; height: 15px; padding-left: 5px;"></asp:TextBox>
                                </th>                             
                                <th width="40">
                                    Group
                                </th>
                                <th width="120" style="background: #fff">
                                    <asp:DropDownList ID="ddlCategory" runat="server" Style="height: 24px;">
                                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                <th width="40">
                                    Quality
                                </th>
                                <th width="120" style="background: #fff">
                                    <asp:TextBox ID="txtTrade" runat="server" CssClass="fabricquality-tradename" Style="height: 15px;"></asp:TextBox>
                                </th>
                                <th width="30">
                                    Unit
                                </th>
                                <th width="60" style="background: #fff">
                                    <asp:DropDownList ID="DDlUnit" runat="server" Style="height: 24px;">
                                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                <td width="35">
                                    <asp:LinkButton ID="lkbGo" runat="server" CausesValidation="false" OnClick="lkbGo_Click" CssClass="submit" Style="text-decoration: none;">                                  
                                     Go
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </thead>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 2px;">
        </div>
        <asp:UpdatePanel ID="pnlUpdt1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="width: 80%; margin: 0 auto">
                    <asp:GridView ID="gdvFQMaster" runat="server" DataKeyNames="FabricMaster_ID" Width="100%" EmptyDataText="No Record Found!" ShowFooter="True" OnRowCommand="gdvFQMaster_RowCommand" OnPageIndexChanging="gdvFQMaster_PageIndexChanging" AutoGenerateColumns="false" OnRowEditing="gdvFQMaster_RowEditing" OnRowCancelingEdit="gdvFQMaster_RowCancelingEdit" OnRowUpdating="gdvFQMaster_RowUpdating" AllowPaging="true" PageSize="10" CssClass="item_list bottomRow">
                        <SelectedRowStyle CssClass="hover_row" />
                        <FooterStyle CssClass="borderBottom" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="border_top_color border_left_color" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle CssClass="border_left_color" />
                                <FooterStyle CssClass="border_left_color" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="HSN Code" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblHSNCode" runat="server" Text='<%# Eval("HSNCode") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Group" HeaderStyle-Width="20%">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlGroup" Enabled="false" runat="server" CssClass="GroupDDGrid">
                                        <asp:ListItem Selected="True" Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlFooterGroup" runat="server" CssClass="GroupDDFooter" AutoPostBack="True" OnSelectedIndexChanged="ddlFooterGroup_SelectedIndexChanged" Style="height: 22px">
                                        <asp:ListItem Selected="True" Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlFooterGroup" runat="server" ErrorMessage="" ValidationGroup="F" CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlFooterGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnfGroupID" runat="server" Value='<%# Eval("CategoryId") %>' />
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quality" HeaderStyle-Width="25%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTradeName" runat="server" Text='<%# Eval("TradeName") %>' MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTradeName" runat="server" ErrorMessage="" ControlToValidate="txtTradeName" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterTradeName" runat="Server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFooterTradeName" runat="server" ErrorMessage="" ControlToValidate="txtFooterTradeName" ValidationGroup="F" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTradeName" runat="server" Text='<%# Eval("TradeName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Dyeing Greige Sh." HeaderStyle-Width="5%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDyeingGreigeSh" runat="server" Text='<%# Eval("Dyeing_Greige_Sh") %>' MaxLength="4" onkeypress="return isNumberKey(event);" onchange="chechZero(this);"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvGreigeSh" runat="server" ErrorMessage="" ControlToValidate="txtGreigeSh"
                                    CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterDyeingGreigeSh" runat="Server" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="chechZero(this);"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="rfvFooterGreigeSh" runat="server" ErrorMessage=""
                                    ControlToValidate="txtFooterGreigeSh" ValidationGroup="F" CssClass="errorMsg"
                                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDyeingGreigeSh" runat="server" Text='<%# Eval("Dyeing_Greige_Sh") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Printing Greige Sh." HeaderStyle-Width="5%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPrintingGreigeSh" runat="server" Text='<%# Eval("Printing_Greige_Sh") %>' MaxLength="4" onkeypress="return isNumberKey(event);" onchange="chechZero(this);"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvGreigeSh" runat="server" ErrorMessage="" ControlToValidate="txtGreigeSh"
                                    CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterPrintingGreigeSh" runat="Server" MaxLength="4" onkeypress="return isNumberKey(event);" onchange="chechZero(this);"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="rfvFooterGreigeSh" runat="server" ErrorMessage=""
                                    ControlToValidate="txtFooterGreigeSh" ValidationGroup="F" CssClass="errorMsg"
                                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrintingGreigeSh" runat="server" Text='<%# Eval("Printing_Greige_Sh") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Res. Sh." HeaderStyle-Width="5%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtResSh" runat="server" Text='<%# Eval("Res_Sh") %>' MaxLength="4" onchange="chechZero(this);" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfvResSh" runat="server" ErrorMessage="" ControlToValidate="txtResSh"
                                    CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterResSh" runat="Server" MaxLength="4" onchange="chechZero(this);" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="rfvFooterResSh" runat="server" ErrorMessage="" ControlToValidate="txtFooterResSh"
                                    ValidationGroup="F" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblResSh" runat="server" Text='<%# Eval("Res_Sh") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="10%">
                                <EditItemTemplate>
                                    <asp:Label ID="lblUnitEdit" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnUnitIdEdit" Value="-1" runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblUnitFooter" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnUnitIdFooter" Value="-1" runat="server" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:TemplateField>
                            <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;' HeaderText="Action" ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/Cancel1.jpg" width="24px" Class="imgWidth2" height="24px"; title="Cancel" alt="Cancel" /&gt;' UpdateText='&lt;img src="../../images/Save.png" class="imgWidth" title="Update" width="18px" alt="Update" /&gt;' CausesValidation="true">
                                <ItemStyle HorizontalAlign="Center" CssClass="imgWidth" Width="10%" />
                                <HeaderStyle CssClass="border_top_color" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkSelect" runat="server" CausesValidation="False" CommandName="Select" Text="Select">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert" ValidationGroup="F">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                                    </asp:LinkButton>
                                </FooterTemplate>
                                <FooterStyle CssClass="border_right_color" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="border_right_color" />
                                <HeaderStyle CssClass="border_top_color border_right_color" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div style="height: 10px;">
                    </div>
                </div>
                <div style="width: 1060px; overflow: auto; margin: 0 auto">
                    <table cellspacing="0" cellpadding="0" id="tablefirst" border="1" runat="server" class="toptablegroup" visible="false" style="border-color: #9999995e; border-bottom: 0px;">
                        <thead>
                            <tr>
                                <th style="min-width: 127px; border-bottom: 0px;">
                                    Group
                                </th>
                                <th style="min-width: 129px; border-bottom: 0px;">
                                    Quality
                                </th>
                                <th style="min-width: 59px; border-bottom: 0px;">
                                </th>
                                <th id="thGreigeFinish" runat="server" style="border-bottom: 0px; position: relative">
                                    Options &nbsp;
                                    <asp:ImageButton ImageUrl="../../App_Themes/ikandi/images/plus.gif" ID="ImgGreige" Style="width: 10px; height: 10px; position: absolute; margin-top: -3px;" runat="server" OnClick="ImgGreige_Click" />
                                    <asp:HiddenField ID="hdnGreigeFinish" runat="server" Value="0" />
                                </th>
                                <th id="thFinish" runat="server" visible="false" style="border-bottom: 0px;">
                                    Finish&nbsp;
                                    <asp:ImageButton ImageUrl="../../App_Themes/ikandi/images/plus.gif" ID="ImgFinish" runat="server" OnClick="ImgFinish_Click" Style="width: 10px; height: 10px; position: absolute; margin-top: -3px;" />
                                    <asp:HiddenField ID="hdnFinish" runat="server" Value="0" />
                                </th>
                                <th style="width: 69px; border-bottom: 0px;">
                                </th>
                            </tr>
                        </thead>
                    </table>
                    <div runat="server" id="FQHeader1" class="ShowDiv">
                    </div>
                    <asp:GridView ID="grdFQDetails" runat="server" AutoGenerateColumns="false" ShowFooter="True" DataKeyNames="supplier_master_Id" OnRowDataBound="grdFQDetails_RowDataBound" ShowHeader="false" OnRowCancelingEdit="grdFQDetails_RowCancelingEdit" OnRowCommand="grdFQDetails_RowCommand" OnRowDeleting="grdFQDetails_RowDeleting" OnRowEditing="grdFQDetails_RowEditing" OnRowUpdating="grdFQDetails_RowUpdating" BorderColor="#8c8c8c0a" CssClass="grouptable bottomtable">
                    </asp:GridView>
                    <div style="height: 10px;">
                    </div>
                    <div id="divGreige" runat="server" class="modal">
                        <div class="modal-content">
                            <asp:GridView ID="grdGreigetoFinish" runat="server" AutoGenerateColumns="false" ShowFooter="True" Width="100%" DataKeyNames="Fabric_Quality_DetailsID" OnRowCancelingEdit="grdGreigetoFinish_RowCancelingEdit" OnRowDeleting="grdGreigetoFinish_RowDeleting" OnRowEditing="grdGreigetoFinish_RowEditing" OnRowUpdating="grdGreigetoFinish_RowUpdating" OnRowCommand="grdGreigetoFinish_RowCommand" CssClass="item_list" OnRowDataBound="grdGreigetoFinish_RowDataBound">
                                <FooterStyle CssClass="borderBottom" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="hdnOptionNo" Value='<%#Container.DataItemIndex+1 %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="border_left_color" />
                                        <FooterStyle CssClass="border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cut. Width" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCutWidth" runat="server" Text='<%# Eval("CutWidth") %>' MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)" onchange="return CostWidth(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCutWidth" runat="server" ErrorMessage="" ControlToValidate="txtCutWidth" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCutWidth" runat="Server" MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)" onchange="return CostWidth(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterCutWidth" runat="server" ErrorMessage="" ControlToValidate="txtFooterCutWidth" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCutWidth" runat="server" Text='<%# Eval("CutWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost. Width" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCosWidth" runat="server" Text='<%# Eval("CostWidth") %>' CssClass="readonlytxt" onkeypress="javascript:return ReadOnly()" MaxLength="6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCostWidth" runat="server" ErrorMessage="" ControlToValidate="txtCosWidth" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCostWidth" CssClass="readonlytxt" runat="Server" onkeypress="javascript:return ReadOnly()" MaxLength="6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterCostWidth" runat="server" ErrorMessage="" ControlToValidate="txtFooterCostWidth" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostWidth" runat="server" Text='<%# Eval("CostWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Griege Width" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGriegeWidth" runat="server" Text='<%# Eval("GriegeWidth") %>' CssClass="readonlytxt" onkeypress="return isNumberKeyfloat(event, this)" MaxLength="6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvGriegeWidth" runat="server" ErrorMessage="" ControlToValidate="txtGriegeWidth" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterGriegeWidth" CssClass="readonlytxt" runat="Server" onkeypress="return isNumberKeyfloat(event, this)" MaxLength="6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterGriegeWidth" runat="server" ErrorMessage="" ControlToValidate="txtFooterGriegeWidth" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGriegeWidth" runat="server" Text='<%# Eval("GriegeWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GSM" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGSM" runat="server" Text='<%# Eval("GSM") %>' MaxLength="6" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvGSM" runat="server" ErrorMessage="" ControlToValidate="txtGSM" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterGSM" runat="Server" MaxLength="6" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterGSM" runat="server" ErrorMessage="" ControlToValidate="txtFooterGSM" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGSM" runat="server" Text='<%# Eval("GSM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C&C" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCC" runat="server" Text='<%# Eval("CountConstruction") %>' MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCC" runat="server" ErrorMessage="" ControlToValidate="txtCC" CssClass="errorMsg" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                                            <%--Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' --%>
                                            <asp:HiddenField ID="hdnCandCFooter" runat="server" Value='<%# Eval("Is_CANDC") %>' />
                                            <%--added by raghvinder on 15-09-2020 end--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCC" runat="Server" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterCC" runat="server" ErrorMessage="" ControlToValidate="txtFooterCC" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCC" runat="server" Text='<%# Eval("CountConstruction") %>'></asp:Label>
                                            <%--added by raghvinder on 15-09-2020 start--%>
                                            <%--Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' --%>
                                            <asp:HiddenField ID="hdnCandCFooter" runat="server" Value='<%# Eval("Is_CANDC") %>' />
                                            <%--added by raghvinder on 15-09-2020 end--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greige C&C" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgreigeCC" runat="server" Text='<%# Eval("GreigeCountConstruction") %>' MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvGreigeCC" runat="server" ErrorMessage="" ControlToValidate="txtgreigeCC" CssClass="errorMsg" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                                            <%--Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' --%>
                                            <%--<asp:HiddenField ID="hdnCandCFooter" runat="server" Value='<%# Eval("Is_CANDC") %>' />--%>
                                            <%--added by raghvinder on 15-09-2020 end--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterGreigeCC" runat="Server" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvGreigeFooterCC" runat="server" ErrorMessage="" ControlToValidate="txtFooterGreigeCC" ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreigeCC" runat="server" Text='<%# Eval("GreigeCountConstruction") %>'></asp:Label>
                                            <%--added by raghvinder on 15-09-2020 start--%>
                                            <%--Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' --%>
                                            <%--<asp:HiddenField ID="hdnCandCFooter" runat="server" Value='<%# Eval("Is_CANDC") %>' />--%>
                                            <%--added by raghvinder on 15-09-2020 end--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="G. Rate" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGRate" runat="server" Text='<%# Eval("GreigeRate") %>' MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)" onchange="chechZero(this);"></asp:TextBox>
                                            <%--    <asp:RequiredFieldValidator ID="rfvGRate" runat="server" ErrorMessage="" ControlToValidate="txtGRate"
                                                CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterGRate" runat="Server" MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)" onchange="chechZero(this);"></asp:TextBox>
                                            <%-- <asp:RequiredFieldValidator ID="rfvFooterGRate" runat="server" ErrorMessage="" ControlToValidate="txtFooterGRate"
                                                ValidationGroup="FG" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGRate" runat="server" Text='<%# Eval("GreigeRate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" border="0" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lkDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                    <img src="../../images/delete-icon.png" alt="Delete" title="Delete" border="0" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lkUpdate" runat="server" CausesValidation="true" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" width="18px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                    <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" width="24px" height="24px"; />
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert" ValidationGroup="FG">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="border_right_color" />
                                        <FooterStyle CssClass="border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div style="width: 10%; vertical-align: top; border: 0px solid #000000; margin-top: 5px" align="left">
                                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="submit" ToolTip="Return to Details" OnClick="btnReturn_Click" Style="cursor: pointer;" />
                            </div>
                        </div>
                    </div>
                    <div id="divFinish" runat="server" class="modal" visible="false">
                        <div class="modal-content">
                            <asp:GridView ID="grdFinish" runat="server" AutoGenerateColumns="false" ShowFooter="True" Width="100%" DataKeyNames="Fabric_Quality_DetailsID" OnRowCancelingEdit="grdFinish_RowCancelingEdit" OnRowDeleting="grdFinish_RowDeleting" OnRowEditing="grdFinish_RowEditing" OnRowUpdating="grdFinish_RowUpdating" OnRowCommand="grdFinish_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="border_right_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cut. Width" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCutWidth" runat="server" Text='<%# Eval("CutWidth") %>' MaxLength="6" onchange="return CostWidth(this);" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCutWidth" runat="server" ErrorMessage="" ControlToValidate="txtCutWidth" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCutWidth" runat="Server" MaxLength="6" onchange="return CostWidth(this);" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterCutWidth" runat="server" ErrorMessage="" ControlToValidate="txtFooterCutWidth" ValidationGroup="FF" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCutWidth" runat="server" Text='<%# Eval("CutWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost. Width" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCosWidth" runat="server" Text='<%# Eval("CostWidth") %>' MaxLength="6" onchange="chechZero(this);" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCostWidth" runat="server" ErrorMessage="" ControlToValidate="txtCosWidth" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCostWidth" runat="Server" MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)" onchange="chechZero(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterCostWidth" runat="server" ErrorMessage="" ControlToValidate="txtFooterCostWidth" ValidationGroup="FF" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostWidth" runat="server" Text='<%# Eval("CostWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GSM" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGSM" runat="server" Text='<%# Eval("GSM") %>' MaxLength="6" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvGSM" runat="server" ErrorMessage="" ControlToValidate="txtGSM" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterGSM" runat="Server" MaxLength="6" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFooterGSM" runat="server" ErrorMessage="" ControlToValidate="txtFooterGSM" ValidationGroup="FF" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGSM" runat="server" Text='<%# Eval("GSM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C&C" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCC" runat="server" Text='<%# Eval("CountConstruction") %>' MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCC" runat="server" ErrorMessage="" ControlToValidate="txtCC" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterCC" runat="Server" MaxLength="50"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvFooterCC" runat="server" ErrorMessage="" ControlToValidate="txtFooterCC"
                                                ValidationGroup="FF" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCC" runat="server" Text='<%# Eval("CountConstruction") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" border="0" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lkDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                    <img src="../../images/del-butt.png" alt="Delete" title="Delete" border="0" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lkUpdate" runat="server" CausesValidation="true" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" width="18px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                    <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" width="24px" height="24px"; />
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert" ValidationGroup="FF">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div style="width: 10%; vertical-align: top; border: 0px solid #000000;" align="left">
                                <asp:Button ID="btnreturnF" runat="server" Text="Return" CssClass="submit" ToolTip="Return to Details" OnClick="btnreturnF_Click" Style="cursor: pointer" />
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lkbGo" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="dvHistory" class="modalNew">
        <div class="modal-content">
            <div class="HistoryHeader">
                <span id="Historytitle">History</span> <span style="float: right; padding: 0px 3px; cursor: pointer;" onclick="SpiltContactClose();">X</span>
            </div>
            <div id="HistoryDescription">
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Content>
