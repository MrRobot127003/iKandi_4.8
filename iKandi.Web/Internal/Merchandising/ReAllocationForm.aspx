<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReAllocationForm.aspx.cs"
    Inherits="iKandi.Web.Internal.Merchandising.ReAllocationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/numberformat.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad() {
            $(".number").blur(function () {
                // //debugger;
                var vals = $(this).val();
                if (vals == 0) {
                    $(this).val('');
                } else {
                    $(this).val(vals);
                }
            });

            $('.number').keypress(function (event) {
                // var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }


                if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });
        }
        $(function () {

            $(".number").blur(function () {
                // //debugger;
                var vals = $(this).val();
                if (vals == 0) {
                    $(this).val('');
                } else {
                    $(this).val(vals);
                }
            });

            $('.number').keypress(function (event) {
                // var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }



                if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

            $('.number').bind("paste", function (e) {
                var text = e.originalEvent.clipboardData.getData('Text');
                if ($.isNumeric(text)) {
                    if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                        e.preventDefault();
                        $(this).val(text.substring(0, text.indexOf('.') + 3));
                    }
                }
                else {
                    e.preventDefault();
                }
            });


        });
        // Code Added by bharat on 15-01-20
        function CrearteValueAPo(hdnRiskSupplierIDVal, hdnVAId) {

           // alert(hdnRiskSupplierIDVal);
           // debugger;
            var sURL = "../Production/POValueaddition.aspx?RiskVASupplierId=" + hdnRiskSupplierIDVal + "&hdnVAId=" + hdnVAId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 650, width: 860, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
           // $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function ViewValueAPo(hdnRiskSupplierIDVal, hdnVAId) {
            debugger;
            // alert(hdnRiskSupplierIDVal);
            // debugger;
            var sURL = "../Production/POValueaddition.aspx?RiskVASupplierId=" + hdnRiskSupplierIDVal + "&hdnVAId=" + hdnVAId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 650, width: 860, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            // $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }

        function CrearteOutHousePo(OrderDetailLocaType) {

            // alert(OrderDetailLocaType);
            // debugger;
            var sURL = "../Production/POStitch.aspx?" + OrderDetailLocaType;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 650, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            // $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function ViewOutHousePo(OrderDetailLocaType) {
            debugger;
           // alert(OrderDetailLocaType);
            // debugger;
            var sURL = "../Production/POStitch.aspx?" + OrderDetailLocaType;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 650, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            // $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        
    </script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript">
        function OpenShadowbox(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function OpenStitchingShadowbox(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function checkQuantity(evnt) {
            ////debugger;
            var id = evnt.id;
            var Quantity = $("#" + id).closest("table").closest("tr").find("td:eq(17)").text();
            Quantity = Quantity.replace(',', '')
            var alloc = parseFloat(evnt.value.trim());
            var qty = parseFloat(Quantity.trim());
            if (alloc > qty) {
                alert("Allocation quantity value not greater from quantity value.");
                evnt.value = "";
                evnt.focus();
            }
        }
        function chechZero(evt) {
            var val = parseFloat(evt.value);
            if (val == 0) {
                alert("Zero is not valid.");
                evt.value = "";
                evt.focus();
            }
        }
        function isNumberKey(evt, obj) {

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

        function SBClose() { }

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

        function CheckOtherIsCheckedByGVID(rb) {
            var isChecked = rb.checked;
            var row = rb.parentNode.parentNode;

            var currentRdbID = rb.id;
            parent = document.getElementById("#grdStitchva");
            var items = parent.getElementsByTagName('input');

            for (i = 0; i < items.length; i++) {
                if (items[i].id != currentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                    }
                }
            }
        }

        //added by raghvinder on 03-09-2020 start
        function SHOW_Reallocation_History() {
            //debugger;
            var StyleId = 0
            StyleId = $("#hdnStyleId").val();
            var url = '../../Internal/Merchandising/Reallocation_History.aspx?StyleId=' + StyleId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 700, width: 1200, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        }
        function SBClose() { }
        //added by raghvinder on 03-09-2020 end

        function SupplierCheck(elem, type) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[1].substr(3);
            if ($(elem).is(':checked')) {
                if (type == 'Cut') {
                    var CutRate = $("#grdStitchva input[id*='ctl" + cId + "_txtCuttingRate" + "']").val();
                    //                alert(CutRate);
                    if (CutRate == '') {
                        elem.checked = false;
                    }
                }
                if (type == 'Stitch') {
                    var Rate = $("#grdStitchva input[id*='ctl" + cId + "_txtStitchRateVa" + "']").val();
                    if (Rate == '') {
                        elem.checked = false;
                    }
                }
                if (type == 'Finish') {
                    var FinishedRate = $("#grdStitchva input[id*='ctl" + cId + "_txtFinishRate" + "']").val();
                    if (FinishedRate == '') {
                        elem.checked = false;
                    }
                }
            }
        }

        function SupplierVACheck(elem) {
            // //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[2].substr(3);
            var txtId = Ids.replace("chkFinalize", "txtInitial_Agreed_Rate");
            if ($(elem).is(':checked')) {
                var Rate = $("#" + txtId).val();
                if (Rate == '') {
                    elem.checked = false;
                }
            }
        }


        function CheckContact(elem) {
            ////debugger;
            var GridView = elem.parentNode.parentNode.parentNode;
            var items = GridView.getElementsByTagName("input");

            if ($(elem).is(':checked')) {
                for (i = 0; i < items.length; i++) {
                    if (items[i].type == "checkbox") {
                        items[i].checked = true;
                    }
                }
            }
            else {
                for (i = 0; i < items.length; i++) {
                    if (items[i].type == "checkbox") {
                        items[i].checked = false;
                    }
                }
            }
        }

        //abhishek 
        $("[id*=CheckHeadercontact]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
        $("[id*=cbcontact]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=CheckHeadercontact]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=cbcontact]", grid).length == $("[id*=cbcontact]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });

    </script>
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(".th").datepicker({ dateFormat: 'dd M y (D)'

            });
        });


          
    </script>
    <style type="text/css">
        
        .bgheading
        {
            background-color: #dddfe4 !important;
            color: #575759;
            height: 20px;
            font-size: 12px;
        }
        .isdisplay
        {
            display: none;
        }
        .item_list th table th
        {
            border: none !important;
            border-right: 1px solid #b7b4b4 !important;
        }
        .item_list th
        {
            padding:4px;
           
        }
        .item_list td
        {
            padding: 0px !important;
            font-size: 11px;
        }
        a.disable
        {
            pointer-events: none;
            cursor: default;
            background-color: #E3E3E3;
        }
        a.enable
        {
            cursor: text;
            background-color: #FFFFFF;
        }
        .item_list td.radio-button table td
        {
            border: 0px;
        }
        #grdStitchva tr td
        {
            height:21px;
        }
        input[type="text"]
        {
            background:#fff;
        }
        .child-grid td
        {
            border-right:1px solid #ccc !important;
            height:21px;
        }
        input[type="checkbox"] ,input[type=text]
        {
            margin: 2px 0px;
            padding:0px;
}
/*upadted css by bharat 7-jan-19*/
    imput[type="text"]
    {
        width:92% !important;
      }
      select
      {
          width:96% !important;
       }
    .item_list TD {
        height: 18px;
    }
    
.spinnL {
    border: 10px solid #f3f3f3; /* Light grey */
    border-top: 10px solid #3498db; /* Blue */
    border-radius: 50%;
    width: 40px;
    height: 40px;
    animation: spin 0.9s linear infinite;
     position: fixed;
            left: 50%;
            top: 50%;
            display:none;
            
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}
 .overlay
 {
     
 }
 
    .overlay { 
   position: fixed;    
   top: 0; left: 0; top: 0; bottom: 0;
   background:  rgba(40,40,40, .75);
   width:100%;
   height:100%;
}
    </style>
    <style>
        /* Style the tab */
        .tab
        {
            width: 98.3%;
            margin-left: 10px;
             border: 0px solid white;
        }
        
        /* Style the buttons inside the tab */
        .tab button
        {
            background-color: #405D99;
             cursor: pointer;
            color: #FFFFFF;
            border-radius: 10px 10px 0px 0px;
            border: 1px solid white;
            padding: 7px 10px;
        }
         
         .tab:focus{
            outline: none;
        }
        
        /* Change background color of buttons on hover */
        .tab button:hover
        {
            background-color: #ddd;
        }
         .tab button:focus{
            outline: none;
        }
        /* Create an active/current tablink class */
        .tab button.active
        {
            background-color: #13a747 !important;
            border: none;
        }
        
        /* Style the tab content */
        .tabcontent
        {
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
        #spinnL
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            opacity: 0.8;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        
      /* updated css by bharat 25-dec-18 */ 
      
         .textcolorblue
        {
            color:#0000ee;
        }
        #grdcontact tr td:first-child
        {
           color:#0000ee;
         }
            #grdcontact tr td:nth-last-child(2)
        {
           color:#0000ee;
         }
         #grdStitchva  tr td:first-child  + td input
        {
           color:#0000ee !important;
         }
         #grdcontact tr td:first-child  + td 
        {
           color:#000 !important;
         }
         #gvReAllocation td
         {
             padding:0px !important;
          }
         #grdStitchva input[type=text]
        {
          width:98%;
          font-size:11px;
         }
        #gvReAllocation input[type="radio"]
         {
            position: relative;
            top: 3px;
          }
          #gvVA_Details td
          {
              padding:0px 0px !important;
           }
           #grdVA_Quantity_Allocation td
          {
              padding:1px 0px !important;
               border-color:#757373999;
           }
           .ReAllheader1 td{
            color: #575759 !important;
            font-size: 11px;
            background-color: #dddfe4;
            text-transform: capitalize !important;
            border: 1px solid #b7b4b4;
            text-align: center;
            padding: 4px;
            font-weight: normal;
           }
           #grdStitchva td:first-child
           {
               display:none;
            }
             #grdStitchva tr:first-child
           {
               display:none;
            }
            .widthrate
            {
                width:60px;
             }
              .widthFinLise
            {
                width:40px;
             }
             .item_list td {
                border-color:#757373999;
            }
            #sb-body-inner
            {
                background:#fff;
             } 
             .item_list a.positonTop 
             {
                 cursor:pointer;
                 position:relative;
                 top:-3px;
              }
               .item_list a[Disabled='Disabled'].positonTop  
             {
                 cursor:auto;
                 position:relative;
                 top:-3px;
                 color:Gray !important;
              }
                .item_list a[Disabled='Disabled'].positonTop:hover  
             {
                    text-decoration: none;
              }
              #sb-wrapper-inner
              {
                  border:5px solid #999;
                  border-radius:5px;
               }
               .backgroundRed td
               {
                   background: #fdfd96;
                }
                 .backgroundRed td input
               {
                   background:#fdfd96;
                }
                h3 {
                font-size: 11px;
                font-weight: normal;
                padding: 5px;
                background: #39589C;
                color: #fff;
                text-align: center;
                margin: 0px;
                text-transform: capitalize;
                width: 97.5%;
                margin-left: 15px !important;
            }
            .ui-widget-content
        {
            background:#fff !important;
            border:0px !important
        }
      .submit
      {
          cursor:pointer;
          border-radius:2px;
       }
       .item_list td:first-child
       {
           border-left-color:#999 !important;
        }
        .item_list td:last-child
       {
           border-right-color:#999 !important;
        }
        .item_list tr:last-child > td
       {
           border-bottom-color:#999 !important;
        }
    </style>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <%--    <script src="https://code.jquery.com/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        var availableName;
        function setvalue() {
            SpinnShow();
        }
        function SpinnShow() {
            ////debugger;
            $("#spinnL").css("display", "block");
            $('body').scrollTop($('body')[0].scrollHeight);
        }
        $(window).load(function () { $("#spinnL").fadeOut("slow"); });
        $(function () {
            FabricQualityOnkeyup("", "");

        });
        var ControlId;
        function checkFab(srcElem) {
            //debugger;

            ControlId = srcElem.id;
            var ControlIdValue = document.getElementById(ControlId).value;
            FabricQualityOnkeyup(ControlIdValue, ControlId);
        }
        function FabricQualityOnkeyup(x, y) {
            var s = y;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/Get_Vender_NameForReallocation",
                data: "{ VenderName:'" + x + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
        }

        function OnSuccessCall(response) {
            //debugger;
            availableName = response.d
            CommaFormatted();
            $("#grdStitchva_ctl02_txtSupplierNameVa,#grdStitchva_ctl03_txtSupplierNameVa,#grdStitchva_ctl04_txtSupplierNameVa,#grdStitchva_ctl05_txtSupplierNameVa,#grdStitchva_ctl06_txtSupplierNameVa, input.autoComplete").autocomplete({
                source: availableName
            });
        }
        function CommaFormatted() {
            $(".numericFormat").each(function (index) {
                ////debugger;
                var x = $(this).text();
                if (x != "") {
                    $(this).text(number_format(x, 0, '.', ','));
                }

            });

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
        function validNumeric(evnt) {
            // //debugger;
            return false;
        }
        function openCity(evt, Firstid, Secondid) {
            if (Firstid == "stitch") {
                document.getElementById("hdnDisplay").value = "0";
                document.getElementById(Firstid).style.display = "block";
                document.getElementById(Secondid).style.display = "none";
            }
            else {
                document.getElementById("hdnDisplay").value = "1";
                document.getElementById(Firstid).style.display = "block";
                document.getElementById(Secondid).style.display = "none";
            }
            var tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            evt.currentTarget.className += " active";
            return false;
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            var firstid = document.getElementById("hdnDisplay");
            var btnStitchRell = document.getElementById("btnStitchRell");
            var btnVARell = document.getElementById("btnVARell");
            if (firstid.value == "1") {
                document.getElementById("va").style.display = 'block';
                document.getElementById("stitch").style.display = 'none';
                btnVARell.className += " active";
            }
            else {
                document.getElementById("stitch").style.display = 'block';
                document.getElementById("va").style.display = 'none';
                btnStitchRell.className += " active";
            }

            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            FabricQualityOnkeyup("", "");
            $('#spinnL').css('display', 'none');
            return false;
        }

        $(document).ready(function () {
            document.getElementById("stitch").style.display = "block";
            document.getElementById("btnStitchRell").className += " active";
            document.getElementById("va").style.display = "none";
            document.getElementById("hdnDisplay").value = "0";
            var specialKeys = new Array();
            specialKeys.push(8); //Backspace
            $(function () {
                $(".numeric").bind("keypress", function (e) {
                    var keyCode = e.which ? e.which : e.keyCode
                    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                    return ret;
                });

            });

            $(".numeric").live("keypress keyup", function () {
                if ($(this).val() == '0') {
                    $(this).val('');
                }
            });
        });

      

    </script>
   
    <!------------------------Add-by Prabhaker--------------------------->
  
  
</head>
<body onload="load();">
    <form id="form1" runat="server">
    <%-- <div id="pageLoad" runat="server">Arvind</div>
            <div id="spinnL" class="spinnL" runat="server">Ramesh</div>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upTargetAdmin" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table width="98.3%" cellpadding="0" border="0" cellspacing="0" style="text-transform: capitalize;
                font-family: Arial; margin-left: 10px;" align="center">
                <tr>
                    <td>
                     <span style="position: relative;top: 24px; padding-left: 10px; color: #fff;">Style No.:
                        <asp:Label ID="lblStyleNumber" runat="server" />
                        <asp:HiddenField ID="hdnDisplay" runat="server" Value="0" />
                       </span>  
                         
                    </td>
                   
                </tr>
                 <tr>
                  
                    <td align="center" style="height: 32px; background-color: #405D99; color: #FFFFFF;
                        font-size: 20px; font-family: Arial; text-transform: none;">
                       Style Re-Allocation
                    </td>
                    <td align="center" style="width: 10%; color:#141823; padding-right: 10px; font-size:12px; 
                        height: 32px; background-color: #405D99; color: #FFFFFF;
                        font-size: 20px; font-family: Arial; text-transform: none;">
                <span style="margin:0px; padding:0px; font-family:verdana; font-weight:normal;cursor:pointer;font-size:11px; color:White;float:right; cursor:pointer;">
                <a onclick="return SHOW_Reallocation_History();" id="Reallocation_History" >Reallocation History</a>
                 </span>  
                   <asp:HiddenField ID="hdnStyleId" runat="server" Value="0" />              
            </td>
                </tr>
                <tr>
                    <td style="height: 5px;" colspan="1">
                      
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                    </td>
                </tr>
            </table>
            <div class="tab">
                <button class="tablinks" onclick="return openCity(event, 'stitch', 'va')" id="btnStitchRell" runat="server">
                    Stitch Reallocation</button>
                <button class="tablinks" style="position:relative;left:-5px;" onclick="return openCity(event, 'va' , 'stitch')" id="btnVARell"
                    runat="server">
                    VA Reallocation</button>
            </div>
            <div style="padding: 5px; margin-bottom: 10px; width: 97%; float: left; margin-left: 11px;
                border: 1px solid #999999;" id="stitch" runat="server" class="tabcontent">
                <h3 style="text-align: center;margin-bottom: 5px;background: #39589C;color: #f5f5f5;padding: 5px 0px;font-weight: normal; margin: 4px 5px !important; width:99.5%;font-weight: normal;">
                    Stitch Reallocation & OH Rate Finalization</h3>
                <div style="width: 100%; margin-left: .3%;">
                    <asp:Panel ID="pln" runat="server" Style="width: 45%; float: left; margin-right: 1%;">
                        <div style="width: 100%; float: left;">
                            <asp:GridView ID="grdStitchva" runat="server" AutoGenerateColumns="false" Width="100%"
                                CssClass="item_list" RowStyle-ForeColor="#787878" OnRowDataBound="grdStitchva_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                           <HeaderTemplate> 
                                            <tr class ="header1">  
                                                <th rowspan="2">S.No.</th>
                                                <th rowspan="2">Supplier Name</th>
                                                <th colspan="2">Cutting</th>
                                                <th colspan="2">Stitch</th>
                                                <th colspan="2">Finished</th>
                                            </tr>
                                            <tr class="header2">
                                              <th class="widthrate">Rate</th>
                                              <th class="widthFinLise">Fina lise</th>
                                              <th class="widthrate">Rate</th>
                                              <th class="widthFinLise" style="width:100px;">Fina lise</th>
                                              <th class="widthrate">Rate</td>
                                              <th class="widthFinLise">Fina lise</th>
                                            </tr>
                                           </HeaderTemplate>  
                                        <ItemTemplate>
                                           <td style="border-left-color:#999 !important;"><asp:Label ID="lblsequence" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label></td> 
                                           <td> 
                                               <asp:TextBox ID="txtSupplierNameVa" MaxLength="40" runat="server" Text='<%# Bind("SupplierName") %>'></asp:TextBox>
                                                <asp:HiddenField ID="hdnSerialNo" runat="server" Value='<%# Container.DataItemIndex + 1 %>' />
                                                <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value="0" />
                                                <asp:HiddenField ID="IsVaFineLineCheck" runat="server" Value='<%#Bind("IsVaFineLineCheck") %>' />
                                                 <asp:HiddenField ID="IsVaFinelCut" runat="server" Value='<%#Bind("IsVaFinelCut") %>' />
                                                  <asp:HiddenField ID="IsVaFinelFinished" runat="server" Value='<%#Bind("IsVaFinelFinished") %>' />
                                            </td>
                                           <td>
                                              <asp:TextBox ID="txtCuttingRate"  class="number" MaxLength="5" runat="server" Text='<%# Bind("CutRate") %>'></asp:TextBox> 
                                           </td>
                                           <td>
                                              <asp:CheckBox ID="chkCuttingFinalise" onclick="SupplierCheck(this, 'Cut')" CssClass="chkClass" runat="server" />
                                           </td>
                                           <td>
                                             <asp:TextBox ID="txtStitchRateVa" class="number" MaxLength="5" Text='<%# Bind("StitchRate") %>'
                                                runat="server" onBlur="check(this.value)"></asp:TextBox>
                                           </td>
                                           <td>
                                            <asp:CheckBox ID="chkSupplier" onclick="SupplierCheck(this, 'Stitch')" CssClass="chkClass"
                                                runat="server" />
                                                 <%-- <asp:LinkButton ID="LinkOutHousePO" runat="server" Visible="false"></asp:LinkButton>--%>
                                                  <a id="LinkOutHousePO" runat="server" Visible="false"></a>
                                           </td>
                                           <td>
                                             <asp:TextBox ID="txtFinishRate"  class="number" MaxLength="5" Text='<%# Bind("FinishedRate") %>' runat="server"></asp:TextBox> 
                                           </td>
                                           <td>
                                            <asp:CheckBox ID="chkFinishFinalise" onclick="SupplierCheck(this,'Finish')" CssClass="chkClass" runat="server" />
                                           </td>
                                        </ItemTemplate>
                                        <ItemStyle Width="30" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Supplier Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSupplierNameVa" MaxLength="40" runat="server" Text='<%# Bind("SupplierName") %>'></asp:TextBox>
                                            <asp:HiddenField ID="hdnSerialNo" runat="server" Value='<%# Container.DataItemIndex + 1 %>' />
                                            <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value="0" />
                                            <asp:HiddenField ID="IsVaFineLineCheck" runat="server" Value='<%#Bind("IsVaFineLineCheck") %>' />
                                             <asp:HiddenField ID="IsVaFinelCut" runat="server" Value='<%#Bind("IsVaFinelCut") %>' />
                                              <asp:HiddenField ID="IsVaFinelFinished" runat="server" Value='<%#Bind("IsVaFinelFinished") %>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                   <%-- Cutting --%>
                                   <%--<%-- <asp:TemplateField HeaderText="Cutting Rate">
                                      
                                         <ItemTemplate>
                                            <asp:TextBox ID="txtCuttingRate"  class="number" MaxLength="5" runat="server" Text='<%# Bind("CutRate") %>'></asp:TextBox> 
                                         </ItemTemplate>
                                           <ItemStyle Width="60" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Cutting Finalise">
                                         <ItemTemplate>
                                            <asp:CheckBox ID="chkCuttingFinalise" CssClass="chkClass" runat="server" />
                                         </ItemTemplate>
                                           <ItemStyle Width="30" />
                                    </asp:TemplateField>
                                    <%--End--%>
                                  <%--  <asp:TemplateField HeaderText="Stitch Rate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtStitchRateVa" class="number" MaxLength="5" Text='<%# Bind("StitchRate") %>'
                                                runat="server" onBlur="check(this.value)"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="40" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Fina <span style="text-transform: lowercase;">Lise</span>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSupplier" onclick="SupplierCheck(this)" CssClass="chkClass"
                                                runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30" />
                                    </asp:TemplateField>--%>

                                     <%-- Finisged --%>
                                  <%--  <asp:TemplateField HeaderText="Finished Rate">
                                         <ItemTemplate>
                                            <asp:TextBox ID="txtFinishRate"  class="number" MaxLength="5" Text='<%# Bind("FinishedRate") %>' runat="server"></asp:TextBox> 
                                         </ItemTemplate>
                                           <ItemStyle Width="60" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Finalise">
                                         <ItemTemplate>
                                            <asp:CheckBox ID="chkFinishFinalise" CssClass="chkClass" runat="server" />
                                         </ItemTemplate>
                                           <ItemStyle Width="30" />
                                    </asp:TemplateField>--%>
                                    <%--End--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </asp:Panel>
                    <div id="widthdiv" style="float: left; width: 30%;overflow:auto;  max-height: 250px;" runat="server">
                        <asp:GridView ID="grdcontact" runat="server" AutoGenerateColumns="false" Width="100%"
                            HeaderStyle-Height="35px" CssClass="item_list headertopfixed" RowStyle-ForeColor="#787878" OnRowDataBound="grdcontact_RowDataBound">
                            <Columns>

                                <asp:BoundField DataField="SerialNumber" HeaderText="Serial No." ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="80" />
                                <asp:BoundField DataField="ContractNumber" HeaderText="Contract No." ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="80" />
                                <asp:BoundField DataField="Fabric1Details" HeaderText="Print/Color" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="90" />
                                <asp:TemplateField HeaderText="Qty." HeaderStyle-Width="70">
                                    <ItemTemplate>
                                        <asp:Label ID="lblqty" runat="server" CssClass="numericFormat" Text='<%# Eval("Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20">
                                    <HeaderTemplate>
                                        <%--<asp:CheckBox ID="CheckHeadercontact" onclick="CheckContact(this)" runat="server" OnCheckedChanged="CheckHeadercontact_CheckedChanged" />--%>
                                        <asp:CheckBox ID="CheckHeadercontact" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Bind("OrderDatailsID") %>' />
                                        <asp:CheckBox ID="cbcontact" runat="server" />
                                        <asp:HiddenField ID="hdnIsVaCheck" runat="server" Value='<%#Bind("IsVacheck") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <div style="width: 99.5%; vertical-align: top; border: 0px solid #000000; margin: 10px 0px;
                    margin-left: .3%" align="left">
                    <asp:Button ID="btnSubmitVa_Click" runat="server" Text="Submit" CssClass="submit"
                        OnClick="btnSubmitVaSection_Click" OnClientClick="setvalue();" />
                </div>
                <div style="width: 99.5%; vertical-align: top; border: 0px solid #787878; text-transform: none;
                    font-family: Arial; font-size: 12px; margin: 10px auto;">
                    <asp:HiddenField ID="hdnIsHeader" runat="server" />
                    <asp:HiddenField ID="hfexFactoryDate" runat="server" />
                    <asp:GridView ID="gvReAllocation" runat="server" AutoGenerateColumns="false" Width="100%"
                        OnRowDataBound="gvReAllocation_rowdatabound" OnRowCommand="gvReAllocation_RowCommand"
                        HeaderStyle-Height="35px" CssClass="item_list" RowStyle-ForeColor="#787878">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="60px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Serial No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Line
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style=" color:#0000ee;">
                                                <%#Eval("SerialNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblline" runat="server" Text='<%#Eval("LineItemNumber") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnOrderDetailsId" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="130px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Contract No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Print/Color
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="color:#000">
                                                <%#Eval("ContractNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Fabric1Detail")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="120px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Ex-Factory
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Mode
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="font-weight:600; color:#000">
                                                <%# Eval("ExFactoryInString")%>
                                                 <asp:HiddenField ID="hdnOrderDate" runat="server" Value='<%#Eval("OrderDate") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("ModeName")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DC Date" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                Visible="false">
                                <ItemTemplate>
                                    <%# Eval("DCInString")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckHeader" AutoPostBack="true" runat="server" OnCheckedChanged="CheckHeader_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hf" runat="server" Value='<%#Bind("OrderId") %>' />
                                    <asp:CheckBox ID="cb" runat="server" OnCheckedChanged="cb_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Partial/Full" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="radio-button">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rbtnPartialFull" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rbtnPartialFull_SelectedIndexChanged" Font-Size="12px"
                                        ForeColor="#787878">
                                        <asp:ListItem Text="Partial" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Full" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="70px" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <a id="txtQuantity" runat="server" rel="shadowbox;width=600;height=300;" onclick="return OpenShadowbox(this)"
                                        style="text-decoration: none; cursor: text;">
                                        <div style="width: 95%;" class="numericFormat">
                                            <%# Eval("Quantity")%></div>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="640px" HeaderStyle-Width="640px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:GridView ID="gvChildReallocation" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="false" OnRowDataBound="gvChildReallocation_RowDataBound" Width="100%"
                                        OnRowDeleting="gvChildReallocation_RowDeleting" HeaderStyle-Font-Names="Arial"
                                        HeaderStyle-Font-Size="12px" RowStyle-Font-Names="Arial" RowStyle-Font-Size="12px"
                                        RowStyle-ForeColor="#787878" BorderWidth="0" CssClass="child-grid">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFactory" runat="server" Width="95%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtStichingunallocated" runat="server" Width="95%" Height="95%" style="border: 0px !important;"
                                                        Text='<%# (Convert.ToString(Eval("UnAllocatedQty")) ==  "0") ? "" :string.Format("{0:#,#0}", Eval("UnAllocatedQty")) %>'
                                                        Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtCutting" runat="server" Width="95%" Height="90%" Text='<%# string.Format("{0:#,#0}",Eval("Cutting"))%>'
                                                                    Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnDoneCuttingQty" runat="server" Value='<%# Eval("DoneCutting")%>' />
                                                                <a id="txtCutting1" runat="server" rel="shadowbox;width=700;height=300;" onclick="return OpenStitchingShadowbox(this)"
                                                                    visible="false" style="text-decoration: none;">
                                                                    <div align="center" style="width: 100%; height: 100%; background-color: #9DF2C7;line-height:18px;" class="numericFormat">
                                                                        <%# Eval("Cutting")%></div>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtTdyCutReady" Text='<%# (Convert.ToString(Eval("TotalCutting")) ==  "0") ? "" : string.Format("{0:#,#0}",Eval("TotalCutting")) %>'
                                                                    Width="90%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="65px">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtTdyCutIssueOutHouse" MaxLength="5" class="number"
                                                                    Text='<%# (Convert.ToString(Eval("TodayCutIssueOutHouse")) ==  "0") ? "" : string.Format("{0:#,#0}",Eval("TodayCutIssueOutHouse")) %>'
                                                                    Width="90%" Style="pointer-events: none;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblTotalCutting" Text='<%#  (Convert.ToString(Eval("TodayCutReadyOutHouse"))=="0")? "" :string.Format("{0:#,#0}", Eval("TodayCutReadyOutHouse")) %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtStitching" runat="server" Width="95%" Height="60%" Text='<%#string.Format("{0:#,#0}", Eval("Stitching"))%>'
                                                        Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)" onchange="chechZero(this);"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnUnAlloctedQty" runat="server" Value='<%# Eval("UnAllocatedQty")%>' />
                                                    <asp:HiddenField ID="StitchingValueOriginal" runat="server" Value='<%# Eval("Stitching")%>' />
                                                    <a id="txtStitching1" runat="server" rel="shadowbox;width=700;height=300;" onclick="return OpenStitchingShadowbox(this)"
                                                        visible="false" style="text-decoration: none;">
                                                        <div align="center" style="width: 100%; height: 100%; background-color: #9DF2C7;line-height: 40px;" class="numericFormat">
                                                            <%# Eval("Stitching")%></div>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFinishing" runat="server" Text='<%# string.Format("{0:#,#0}",Eval("Finishing"))%>' Width="90%"
                                                        Height="60%" Enabled="false" MaxLength="7" onkeypress="return isNumberKey(event)"
                                                        onchange="chechZero(this);"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnDoneFinishingQty" runat="server" Value='<%# Eval("DoneFinishing")%>' />
                                                    <a id="txtFinishing1" runat="server" rel="shadowbox;width=700;height=300;" onclick="return OpenStitchingShadowbox(this)"
                                                        visible="false" style="text-decoration: none;">
                                                        <div align="center" style="width: 100%; height: 100%; background-color: #9DF2C7;" class="numericFormat">
                                                            <%# Eval("Finishing")%></div>
                                                    </a>
                                                    <asp:HiddenField ID="hdnReAllocation" runat="server" Value='<%# Eval("ReallocationID")%>' />
                                                    <asp:HiddenField ID="hdnlineQty" runat="server" Value='<%# Eval("LineQty")%>' />
                                                    <asp:HiddenField ID="hdnorderdetail" runat="server" Value='<%# Eval("OrderDetailID")%>' />
                                                    <asp:HiddenField ID="hdnunitid" runat="server" Value='<%# Eval("UnitID")%>' />
                                                    <asp:HiddenField ID="hdnStitching" runat="server" Value='<%# Eval("DoneStitching")%>' />

                                                    <%--added on 10-09-2020 start--%>
                                                    <%--<asp:HiddenField ID="hdnDeletionStatus" runat="server" Value="0" />--%>
                                                <%--added on 10-09-2020 end--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- ----------------Add By Prabhaker 24-Nov-17-------------------%>
                                            <asp:TemplateField ItemStyle-Width="90px" Visible="false">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("StartDate", "{0:dd MMM yy (ddd)}")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("EndDate", "{0:dd MMM yy (ddd)}")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblStitchedQty" CssClass="numericFormat" Text='<%# string.Format("{0:#,#0}",Eval("StitchedQty"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblPerDayOutPut" CssClass="numericFormat" Text='<%# string.Format("{0:#,#0}",Eval("PerDayOutPut"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCommitted_EndDate" runat="server" CssClass="date-picker th" Height="95%"
                                                        onkeydown="return validNumeric(event);" onkeypress="return validNumeric(event);"
                                                        onkeyup="return validNumeric(event);" Text='<%# Convert.ToDateTime(Eval("Committed_EndDate")) == Convert.ToDateTime("1/1/1900") ? "" : Convert.ToDateTime(Eval("Committed_EndDate")).ToString("dd MMM yy (ddd)")%>'
                                                        Width="95%" style="border:0px !important"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsOHStitchComplete" runat="server" />
                                                    <asp:HiddenField runat="server" ID="hdnIsOHStitchComplete" Value='<%# Eval("OHStitchComplete") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-Width="20px" DeleteImageUrl="../../images/del-butt.png" />                                                
                                                
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" CssClass="IsEnable" CommandName="AddNew"
                                        OnClientClick="return confirm('Are you sure you want to add this row?');" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                        ImageUrl="~/images/add-butt.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
               
                 
                    <div style="width: 99%;margin-top:10px; vertical-align: top; border: 0px solid #000000;" align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submit" OnClick="btnSubmit_Click"
                            OnClientClick="setvalue();" />
                    </div>
                    <br />
                    <asp:GridView ID="grdReallCommitedEndDate" runat="server" AutoGenerateColumns="false"
                        Width="1000px" HeaderStyle-Height="35px" OnRowDataBound="grdReallCommitedEndDate_rowdatabound" CssClass="item_list" RowStyle-ForeColor="#787878">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="155px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Serial No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Style No.
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td>
                                                <%#Eval("SerialNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("StyleNumber")%>

                                                <asp:HiddenField ID="hdnOrderDetailsId" runat="server" Value='<%#Eval("OrderDatailsID") %>' />
                                                <asp:HiddenField ID="hdnReallocationID" runat="server" Value='<%#Eval("ReallocationID") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="130px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Contract No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Print/Color
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td>
                                                <%#Eval("ContractNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Fabric1Details")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="120px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Ex-Factory
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Mode
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td>
                                                <%# Eval("ExFactory")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Code")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="70px" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <div style="width: 95%;" class="numericFormat">
                                        <%# Eval("Quantity")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Name" ItemStyle-Width="70px" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                        <%# Eval("Name")%></div>
                                        
                                </ItemTemplate>
                                <ItemStyle Width="310px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Committed End Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCommitted_EndDate" autocomplete="off" runat="server" style="color:#808080;height:20px;" CssClass="date-picker th" onkeydown="return validNumeric(event);"
                                        onkeypress="return validNumeric(event);" onkeyup="return validNumeric(event);"
                                        Text='<%# Convert.ToDateTime(Eval("Committed_EndDate")) == Convert.ToDateTime("1/1/1900") ? "" : Convert.ToDateTime(Eval("Committed_EndDate")).ToString("dd MMM yy (ddd)")%>'
                                        Width="76%"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="204px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                 
                    <div style="width: 99%; vertical-align: top; border: 0px solid #000000;" align="left">
                        <asp:Button ID="btnCommiteddatesave" runat="server" Visible="false" Text="Submit" CssClass="submit" OnClick="btnCommiteddatesave_Click"
                            OnClientClick="setvalue();" />
                    </div>
                    
                </div>
            </div>

            <div style="padding: 5px; margin-bottom: 10px; width: 97%; float: left; margin-left: 11px;
                border: 1px solid #999999" id="va" class="tabcontent">
                <h3 style="text-align: center;margin-bottom: 5px;background: #39589C;color: #f5f5f5;padding: 5px 0px;font-weight: normal; margin: 4px 5px !important; width:99.5%;font-weight: normal;">
                    VA Reallocation & VA Rate Finalization</h3>
                <div style="padding: 5px; margin-bottom: 10px; width: 99.5%; float: left; margin-left: 0px;">
                    <asp:GridView ID="gvVA_Details" runat="server" AutoGenerateColumns="false" Width="100%"
                        HeaderStyle-Height="35px" CssClass="item_list" RowStyle-ForeColor="#787878" OnRowDataBound="gvVA_Details_RowDataBound"
                        OnRowCommand="gvVA_Details_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Style No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblStyleNumber" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%#Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial_No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNumber" runat="server" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrom_Status" runat="server" Text='<%#Eval("From_Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblTo_Status" runat="server" Text='<%#Eval("To_Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VA Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblVAName" runat="server" Text='<%#Eval("ValueAdditionName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnVA_ID" runat="server" Value='<%# Eval("ValueAdditionID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Intial Agreement Rate" HeaderStyle-Width="75px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblIntialAgreementRate" runat="server" MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)"
                                        onchange="chechZero(this);" Width="92%" Height="75%" Text='<%# (Convert.ToString(Eval("IntialAgreementRate")) ==  "0") ? "" : Eval("IntialAgreementRate") %>'></asp:TextBox>
                                         <asp:HiddenField ID="hdnCheckAdminRate" runat="server" Value='<%# Eval("AdminRate") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="291px" HeaderStyle-Width="391px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <table cellpadding='0' cellspacing='0' width='100%' style='height: 100%;'>
                                        <tr>
                                            <th style='width: 100%; border-bottom: 1px solid #c2b9b9 !important;border-right: 0px !important;' colspan="4"
                                                height='100%'>
                                                VA Rate Finalize
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style='width: 161px;' colspan="1" height='100%'>
                                                Vender Name
                                            </th>
                                            <th style='width: 59px;' colspan="1" height='100%'>
                                                Supplier Rate
                                            </th>
                                            <th style='width: 76px;' colspan="1" height='100%'>
                                                Finalize
                                            </th>
                                            <th style='width: 21px;border-right: 0px !important;' colspan="1" height='100%'>
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:GridView ID="gvChildVA_Details" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                        Width="100%" HeaderStyle-Font-Names="Arial" OnRowDataBound="gvChildVA_Details_RowDataBound"
                                        OnRowDeleting="gvChildVA_Details_RowDeleting" HeaderStyle-Font-Size="12px" RowStyle-Font-Names="Arial"
                                        RowStyle-Font-Size="12px" RowStyle-ForeColor="#787878" BorderWidth="0" CssClass="child-grid">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="162px">
                                                <ItemTemplate>
                                                    <%--<asp:DropDownList ID="ddlSupplier" runat="server" Width="100%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                                    </asp:DropDownList>--%>
                                                    <asp:TextBox ID="txtSupplier" runat="server" OnTextChanged="txtSupplier_TextChanged"
                                                        Width="94%" Text='<%# Eval("SupplierName")%>' CssClass="autoComplete"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtInitial_Agreed_Rate" runat="server" Width="92%" Height="75%"
                                                        Text='<%# Eval("Rate")%>' MaxLength="6" onkeypress="return isNumberKeyfloat(event, this)"
                                                        onchange="chechZero(this);"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkFinalize" onclick="SupplierVACheck(this)" CssClass="chkClass"
                                                        runat="server" Width="20px" />
                                                          <a id="lnkPO" runat="server" visible="false"></a>
                                                       <%-- <asp:LinkButton ID="lnkPO" runat="server" Visible="false"></asp:LinkButton>--%>
                                                    <asp:HiddenField ID="hdnFianlize" runat="server" Value='<%# Eval("Finalize") %>' />
                                                    <asp:HiddenField ID="hdnRiskSupplierID" runat="server" Value='<%# Eval("RiskSupplierID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-Width="20px" DeleteImageUrl="../../images/del-butt.png" />
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="img_btnAdd" runat="server" CssClass="IsEnable" CommandName="AddNew"
                                        OnClientClick="return confirm('Are you sure you want to add this row?');" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                        ImageUrl="~/images/add-butt.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                   
                    <div style="width: 99%; vertical-align: top;margin-top:10px; border: 0px solid #000000;" align="left">
                        <asp:Button ID="btnVA_Details" runat="server" Text="Submit" CssClass="submit" OnClick="btnVA_Details_Click"
                            OnClientClick="setvalue();" />
                    </div>
                </div>
                <div style="padding: 5px; margin-bottom: 10px; width: 99.5%; float: left; margin-left: 0px;">
                    <asp:Label ID="lblMsg" runat="server" Text="Please ensure that you have registered the vender with whom rate finalized."
                        ForeColor="Red" Style="text-align: center;padding-bottom: 9px;display: inline-block;"></asp:Label>
                    <asp:GridView ID="grdVA_Quantity_Allocation" runat="server" AutoGenerateColumns="false"
                        Width="100%" HeaderStyle-Height="35px" CssClass="item_list" RowStyle-ForeColor="#787878"
                        OnRowCommand="grdVA_Quantity_Allocation_RowCommand" OnRowDataBound="grdVA_Quantity_Allocation_RowDataBound">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="60px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Serial No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Line
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="color:Blue;font-size:600">
                                                <%#Eval("SerialNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblline" runat="server" Text='<%#Eval("LineItemNumber") %>'></asp:Label>
                                                <asp:HiddenField ID="HiddenField_OrderDetailID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                                <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%#Eval("Styleid") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="130px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Contract No.
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Print/Color
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="color:#000">
                                                <%#Eval("ContractNumber")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Fabric1Detail")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="120px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                Ex-Factory
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                Mode
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td style="color:#000;font-weight:600">
                                                <%# Eval("ExFactoryInString")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("ModeName")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="120px">
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                From Status
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                To Status
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                        <tr>
                                            <td>
                                                <%# Eval("From_Status")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("To_Status")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VA Name" ItemStyle-Width="90px">
                                <ItemTemplate>
                                    <%#Eval("VA_Name")%>
                                    <asp:HiddenField ID="hdnVAId" runat="server" Value='<%# Eval("ValueAdditionID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckHeaderQA" AutoPostBack="true" runat="server" OnCheckedChanged="CheckHeaderQA_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hf" runat="server" Value='<%#Bind("OrderId") %>' />
                                    <asp:CheckBox ID="cbQA" runat="server" OnCheckedChanged="cbQA_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Partial/Full" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="radio-button">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rbtnPartialFullQA" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rbtnPartialFullQA_SelectedIndexChanged" Font-Size="12px"
                                        ForeColor="#787878">
                                        <asp:ListItem Text="Partial" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Full" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="70px" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <div style="width: 95%;">
                                        <asp:Label ID="lblqty" runat="server" ForeColor="blue" Text='<%# string.Format("{0:#,#0}",Eval("Quantity"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="290px" HeaderStyle-Width="290px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <table cellpadding='0' cellspacing='0' width='100%' style='height: 100%;'>
                                        <tr>
                                            <th style='width: 55px;' height='100%' rowspan='2'>
                                                Allocated Quantity
                                            </th>
                                            <th style='width: 139px;' height='100%' rowspan='2'>
                                                Vender
                                            </th>
                                            <th style='width: 65px; border-bottom: 1px solid #c2b9b9 !important;' height='100%'>
                                                Start Date
                                            </th>
                                            <th style='width: 23px;' height='100%' rowspan='2'>
                                                Perday Output
                                            </th>
                                            <th style='width: 84px;' height='100%' rowspan='2'>
                                                Committed End Date
                                            </th>
                                            <th style='width: 18px;' colspan="1" height='100%'>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style='width: 78px;' height='100%'>
                                                End Date
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:GridView ID="grdChildVA_Quantity_Allocation" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="false" Width="100%" HeaderStyle-Font-Names="Arial" OnRowDataBound="grdChildVA_Quantity_Allocation_RowDataBound"
                                        OnRowDeleting="grdChildVA_Quantity_Allocation_RowDeleting" HeaderStyle-Font-Size="12px"
                                        RowStyle-Font-Names="Arial" RowStyle-Font-Size="12px" RowStyle-ForeColor="#787878"
                                        BorderWidth="0" CssClass="child-grid">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Allocated Quantity" ItemStyle-Width="64px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAllocationQuantity1" runat="server" Width="92%" Text='<%# Eval("AllocationQty1") == "0" ? "" : string.Format("{0:#,#0}",Eval("AllocationQty1")) %>'
                                                        MaxLength="6" onkeypress="return isNumberKey(event)" onchange="checkQuantity(this);chechZero(this);">
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtAllocationQuantity2" runat="server" Visible="false" Width="100%"
                                                        Text='<%# Eval("AllocationQty2") == "0" ? "" : string.Format("{0:#,#0}",Eval("AllocationQty2")) %>' MaxLength="3"
                                                        onkeypress="return isNumberKey(event)" onchange="chechZero(this);">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="160px" HeaderText="Vender">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSupplierAllocation" runat="server" Width="96%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlSupplierAllocation_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnSupplierId" runat="server" Value='<%# Eval("SupplierId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="90px">
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                                        <tr>
                                                            <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                                                Start Date
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                End Date
                                                            </th>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("StartDate", "{0:dd MMM yy (ddd)}")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("EndDate", "{0:dd MMM yy (ddd)}")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Perday Output" ItemStyle-Width="42px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPerdayOutput" ReadOnly="true" runat="server" Width="39px" Height="90%"
                                                        Text='<%# string.Format("{0:#,#0}", Eval("PerDayOutPut"))%>' MaxLength="3" onkeypress="return isNumberKey(event)"
                                                        onchange="chechZero(this);"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Commited End Date" ItemStyle-Width="98px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCommitted_EndDate" runat="server" CssClass="date-picker th" Height="95%"
                                                        onkeydown="return validNumeric(event);" onkeypress="return validNumeric(event);"
                                                        onkeyup="return validNumeric(event);" Text='<%# Convert.ToDateTime(Eval("Committed_EndDate")) == Convert.ToDateTime("1/1/1900") ? "" : Convert.ToDateTime(Eval("Committed_EndDate")).ToString("dd MMM yy (ddd)")%>'
                                                        Width="92%" style="border:0px !important"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-Width="20px" DeleteImageUrl="../../images/del-butt.png" />
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="img_btnAdd" runat="server" CssClass="IsEnable" CommandName="AddNew"
                                        OnClientClick="return confirm('Are you sure you want to add this row?');" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                        ImageUrl="~/images/add-butt.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
              
                    <div style="width: 99%; vertical-align: top; margin-top:10px; border: 0px solid #000000;" align="left">
                        <asp:Button ID="btnVA_Quantity_Allocation" runat="server" Text="Submit" CssClass="submit"
                            OnClick="btnVA_Quantity_Allocation_Click" OnClientClick="setvalue();" />
                    </div>
                </div>
            </div>
            <div id="spinnL">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
